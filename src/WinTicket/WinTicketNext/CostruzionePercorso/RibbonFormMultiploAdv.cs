using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Musei.Module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WinTicketNext.CostruzionePercorso.GestionePrenotazione;
using PreventWebServices;
using DevExpress.XtraTreeList.Nodes;
using WinTicketNext.Validazione;
using System.Diagnostics;
using WinTicketNext.Storico;

namespace WinTicketNext.CostruzionePercorso
{
    public partial class RibbonFormMultiploAdv : RibbonForm
    {
        private readonly GestoreProfili m_GestoreProfili = new GestoreProfili(EnumTipologiaCard.Card2Giorni);

        public RibbonFormMultiploAdv()
        {
            InitializeComponent();

            RefreshGrid();

            this.Text = String.Format("Win Ticket Next ({0} on {1:000}-{2})",
                Program.UtenteCollegato.Username.ToLower(),
                Program.Postazione.CodiceUnivoco,
                Program.Postazione.Nome);

            this.checkEditPrevendita.Checked = false;
            this.checkEditImponiData.Checked = false;
            this.dateEditDataImposta.Visible = false;
            this.dateEditDataImposta.DateTime = DateTime.Now.Date;
        }

        private void RibbonFormMultiplo_Shown(object sender, EventArgs e)
        {
            // imposta come selezionato l'ingresso legato alla postazione
            barButtonItemClear_ItemClick(null, null);

            ribbonGalleryBarItemPercorsi.Gallery.ItemClick += Gallery_ItemClick;
            ribbonGalleryBarItemPercorsiBiglietto.Gallery.ItemClick += Gallery_ItemClick;
        }

        private void InitFull()
        {
            this.unitOfWork1 = new UnitOfWork();

            CaricaRegole();

            CreaGalleryPercorsiTematici();
            CreaGalleryPercorsiConBiglietto();

            // CARICAMENTO INGRESSI
            treeListIngressi.BeginUnboundLoad();
            treeListIngressi.ClearNodes();

            using (XPCollection<SoggettoEconomico> soggetti = new XPCollection<SoggettoEconomico>(unitOfWork1))
            {
                foreach (SoggettoEconomico soggetto in soggetti)
                {
                    AlberoSoggetto(soggetto);
                }
            }

            treeListIngressi.EndUnboundLoad();
            treeListIngressi.BestFitColumns();

            treeListIngressi.CollapseAll();
            foreach (TreeListNode node in treeListIngressi.Nodes)
            {
                node.Expanded = true;
            }

            GestoreCalendario.Clear(GestoreCalendario.TipoGS, GestoreCalendario.TipoScuola, true);
        }

        private void AlberoSoggetto(SoggettoEconomico soggetto)
        {
            if (soggetto == null) return;
            if (soggetto.Ingressi.Count > 0 && soggetto.RagioneSociale != "PROVE")
            {
                Postazione postazione = this.unitOfWork1.GetObjectByKey<Postazione>(Program.Postazione.Oid);

                // nodo del soggetto economico
                TreeListNode nodo = treeListIngressi.AppendNode(new object[] { soggetto.RagioneSociale, GetSortingString(postazione, soggetto), null }, null, soggetto);

                using (XPCollection<Struttura> strutture = new XPCollection<Struttura>(this.unitOfWork1))
                {
                    List<Ingresso> inseriti = new List<Ingresso>();
                    foreach (Struttura struttura in strutture)
                    {
                        if (EsistonoAlmenoDue(postazione, struttura, soggetto))
                        {
                            // nodo della struttura
                            TreeListNode nodostr = treeListIngressi.AppendNode(new object[] { struttura.Descrizione, GetSortingString(postazione, soggetto), null }, nodo, struttura);
                            foreach (Ingresso item in soggetto.Ingressi)
                            {
                                if (item.Struttura == struttura)
                                {
                                    InserisciIngresso(postazione, nodostr, item);
                                    inseriti.Add(item);
                                }
                            }
                        }
                    }

                    foreach (Ingresso item in soggetto.Ingressi)
                    {
                        if (!inseriti.Contains(item))
                            InserisciIngresso(postazione, nodo, item);
                    }
                }
            }
        }

        private void InserisciIngresso(Postazione postazione, TreeListNode nodo, Ingresso item)
        {
            // verifica che l'ingresso:
            // non sia un ingresso secondario
            // ci sia almeno un percorso che lo comprende
            // sia visibile da questa postazione
            if (item.IngressoPrincipale == null && item.Percorsi.Count > 0 && postazione.Ingresso.GetPosizione(item) >= 0)
            {
                TreeListNode nodoingresso = treeListIngressi.AppendNode(new object[] { item.Descrizione, GetSortingString(postazione, item), item.Oid }, nodo, item);
                //if (item.Descrizione.Contains("Naturale"))
                //    nodoingresso.
                
                foreach (Ingresso opzione in item.Opzioni)
                {
                    // ingressi secondari
                    TreeListNode nodoingressosec = treeListIngressi.AppendNode(new object[] { opzione.Descrizione, GetSortingString(postazione, opzione), opzione.Oid }, nodoingresso, opzione);
                }
            }
        }

        private bool EsistonoAlmenoDue(Postazione postazione, Struttura struttura, SoggettoEconomico soggetto)
        {
            using (XPCollection<Ingresso> ingressi = new XPCollection<Ingresso>(this.unitOfWork1))
            {
                GroupOperator criteria = new GroupOperator(GroupOperatorType.And);
                criteria.Operands.Add(new BinaryOperator("SoggettoEconomico", soggetto));
                criteria.Operands.Add(new BinaryOperator("Struttura", struttura));
                ingressi.Criteria = criteria;

                int count = 0;
                foreach (Ingresso item in ingressi)
                {
                    if (postazione.Ingresso.GetPosizione(item) >= 0)
                        count++;
                }

                return count > 1;
            }
        }

        private static string GetSortingString(Postazione postazione, Ingresso ingresso)
        {
            if (postazione == null)
                return ingresso.Descrizione;

            if (postazione.Ingresso.Oid == ingresso.Oid)
                return "A";

            int posizione = postazione.Ingresso.GetPosizione(ingresso);
            if (posizione > 0)
                return string.Format("Found{0:D5}", posizione);

            return "Z" + ingresso.Descrizione;
        }

        private static string GetSortingString(Postazione postazione, SoggettoEconomico soggetto)
        {
            if (postazione == null)
                return soggetto.RagioneSociale;

            if (postazione.Ingresso.SoggettoEconomico.Oid == soggetto.Oid)
                return "A";

            int posizione = postazione.Ingresso.GetPosizione(soggetto);
            if (posizione > 0)
                return string.Format("Found{0:D5}", posizione);

            return "Z" + soggetto.RagioneSociale;
        }

        private void RefreshGrid()
        {
            this.gridControlProfili.DataSource = null;
            this.gridControlProfili.DataSource = m_GestoreProfili.ElencoProfili;
            this.gridViewProfili.BestFitColumns();

            decimal totale = m_GestoreProfili.TotaleImporto();
            this.labelControlInfo.Text = string.Format("{0} persone {1}", m_GestoreProfili.TotalePersone(),
                totale.ToString("c"));

            decimal totProfiloUnico = (m_LastOpt == null ? totale : m_LastOpt.GestoreProfiloUnico.TotaleImporto());
            if (m_GestoreProfili.ConvieneCardMyFE())
            {
                labelControlInfoExtra.Text = "<color=255, 0, 0>(Proporre Card MYFE!)";
            }
            else if (totProfiloUnico < totale)
            {
                labelControlInfoExtra.Text = string.Format("<color=255, 0, 0>(<b>{0}</b> come gruppo!)", totProfiloUnico.ToString("c"));
            }
            else
            {
                decimal totNoBigliettone = m_GestoreProfili.TotaleImportoNoBigliettone();
                if (totNoBigliettone > 0 && totNoBigliettone != totale)
                {
                    labelControlInfoExtra.Text = string.Format("({0} senza B.ONE)", totNoBigliettone.ToString("c"));
                }
                else
                {
                    labelControlInfoExtra.Text = string.Empty;
                }
            }

            if (m_Prenotazione != null)
            {
                //this.simpleButtonModifica.Visible = true;
                this.labelControlPrenotazione.Text = string.Empty;
                foreach (PrenotazioneIngresso prenotazioneIngresso in m_Prenotazione.Prenotazioni)
                {
                    if (prenotazioneIngresso.Attivo)
                        this.labelControlPrenotazione.Text += String.Format("{0} ({1}){2}", 
                            prenotazioneIngresso.Ingresso.Descrizione, prenotazioneIngresso.Prenotazioni.Count, Environment.NewLine);
                }

                if (m_Prenotazione.PreventObj != null)
                    this.labelControlPrenotazione.Text += String.Format("{0}>{1} [{2}]", Environment.NewLine, m_Prenotazione.RiferimentoVendita, m_Prenotazione.PreventObj.NumeroPrenotazione);
                else
                    this.labelControlPrenotazione.Text += String.Format("{0}*>{1}", Environment.NewLine, m_Prenotazione.RiferimentoVendita);
            }
            else
            {
                //this.simpleButtonModifica.Visible = false; 
                this.labelControlPrenotazione.Text = string.Empty;
            }

            AggiornaBottoniPrenotazione();
        }

        private void CreaGalleryPercorsiTematici()
        {
            ribbonGalleryBarItemPercorsi.Gallery.Groups[0].Items.Clear();

            XPCollection<Percorso> percorsi = new XPCollection<Percorso>(this.unitOfWork1);
            percorsi.Sorting = new SortingCollection(new SortProperty[] { new SortProperty("Descrizione", DevExpress.Xpo.DB.SortingDirection.Ascending) });
            foreach (Percorso item in percorsi)
            {
                if (item.Ingressi.Count > 0 && item.BigliettiValidi.Count == 0)
                {
                    GalleryItem gItem = new GalleryItem();

                    gItem.Caption = item.Descrizione;
                    gItem.Caption = item.Descrizione;
                    gItem.Hint = item.Descrizione;

                    ribbonGalleryBarItemPercorsi.Gallery.Groups[0].Items.Add(gItem);
                }
            }
            ribbonGalleryBarItemPercorsi.Gallery.RefreshGallery();
        }

        private void CreaGalleryPercorsiConBiglietto()
        {
            ribbonGalleryBarItemPercorsiBiglietto.Gallery.Groups[0].Items.Clear();

            XPCollection<Percorso> percorsi = new XPCollection<Percorso>(this.unitOfWork1);
            percorsi.Sorting = new SortingCollection(new SortProperty[] { new SortProperty("Descrizione", DevExpress.Xpo.DB.SortingDirection.Ascending) });
            foreach (Percorso item in percorsi)
            {
                if (item.Ingressi.Count > 1 && item.BigliettiValidi.Count > 0)
                {
                    GalleryItem gItem = new GalleryItem();

                    gItem.Caption = item.Descrizione;
                    gItem.Caption = item.Descrizione;
                    gItem.Hint = item.Descrizione;

                    ribbonGalleryBarItemPercorsiBiglietto.Gallery.Groups[0].Items.Add(gItem);
                }
            }
            ribbonGalleryBarItemPercorsiBiglietto.Gallery.RefreshGallery();
        }

        private static void CheckThis(Percorso percorso, TreeListNode node2)
        {
            Ingresso ingresso = node2.Tag as Ingresso;
            if (ingresso != null && percorso.Ingressi.IndexOf(ingresso) >= 0)
            {
                node2.Checked = true;

                // espande tutti i padri
                TreeListNode nodo = node2.ParentNode;
                while (nodo != null)
                {
                    nodo.Expanded = true;
                    nodo = nodo.ParentNode;
                }
            }
            else
                node2.Checked = false;

            foreach (TreeListNode node3 in node2.Nodes)
                CheckThis(percorso, node3);
        }

        private void Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            Cursor saveCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Percorso percorso = this.unitOfWork1.FindObject<Percorso>(new BinaryOperator("Descrizione", e.Item.Caption));
                if (percorso != null)
                {
                    if (percorso.BigliettiValidi.Count > 0)
                    {
                        if (m_GestoreProfili.ElencoProfili.Count > 0)
                        {
                            XtraMessageBox.Show("Non è possibile effetuare l'operazione perchè ci sono profili già inseriti.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            m_CalcolaSoluzione_Sospesa = true;

                            ClearTreeIngressi(false);

                            this.treeListIngressi.BeginUpdate();
                            foreach (TreeListNode node1 in this.treeListIngressi.Nodes)
                            {
                                node1.Checked = false;
                                foreach (TreeListNode node2 in node1.Nodes)
                                {
                                    CheckThis(percorso, node2);
                                }
                            }
                            this.treeListIngressi.EndUpdate();

                            m_CalcolaSoluzione_Sospesa = false;

                            PulisciSoluzione();
                            CalcolaSoluzione();

                            CreaNuovoProfilo(ElencoIngressiDaFare(), percorso);
                        }
                    }
                    else
                    {
                        m_CalcolaSoluzione_Sospesa = true;

                        ClearTreeIngressi(false);

                        this.treeListIngressi.BeginUpdate();
                        foreach (TreeListNode node1 in this.treeListIngressi.Nodes)
                        {
                            node1.Checked = false;
                            foreach (TreeListNode node2 in node1.Nodes)
                            {
                                CheckThis(percorso, node2);
                            }
                        }
                        this.treeListIngressi.EndUpdate();

                        m_CalcolaSoluzione_Sospesa = false;

                        PulisciSoluzione();
                        CalcolaSoluzione();
                    }
                }

                if (ribbonGalleryBarItemPercorsiBiglietto.Gallery.Groups[0].Items.Contains(e.Item))
                    ribbonGalleryBarItemPercorsiBiglietto.MakeVisible(e.Item);

                if (ribbonGalleryBarItemPercorsi.Gallery.Groups[0].Items.Contains(e.Item))
                    ribbonGalleryBarItemPercorsi.MakeVisible(e.Item);
            }
            finally
            {
                Cursor.Current = saveCursor;
            }
        }

        private void PulisciSoluzione()
        {
            m_LastOpt = null;
            foreach (ProfiloCliente item in m_GestoreProfili.ElencoProfili)
            {
                if (item.ElencoSoluzioni.Count != 0)
                {
                    item.ElencoSoluzioni = new ElencoSoluzioni();
                    RefreshGrid();
                }
            }
        }

        private void ClearTreeIngressi(bool sethome)
        {
            this.treeListIngressi.BeginUpdate();
            foreach (TreeListNode node1 in this.treeListIngressi.Nodes)
            {
                ClearTreeIngressiRecursive(node1, sethome);
            }
            this.treeListIngressi.EndUpdate();
        }

        private static bool ClearTreeIngressiRecursive(TreeListNode nodo, bool sethome)
        {
            foreach (TreeListNode node2 in nodo.Nodes)
            {
                if (ClearTreeIngressiRecursive(node2, sethome))
                    nodo.Expanded = true;
            }

            nodo.Checked = false;
            Ingresso ingresso = nodo.Tag as Ingresso;
            if (sethome && ingresso != null && Program.Postazione.Ingresso != null && ingresso.Oid == Program.Postazione.Ingresso.Oid)
            {
                nodo.Checked = true;
                nodo.ExpandAll();
                return true;
            }
            return false;
        }

        private void barButtonItemClear_ItemClick(object sender, ItemClickEventArgs e)
        {
            m_CalcolaSoluzione_Sospesa = true;

            InitFull();

            ClearTreeIngressi(true);

            m_GestoreProfili.ElencoProfili.Clear();
            m_GestoreProfili.SetCodiceSconto(null);
            m_Prenotazione = null;
            //formPrenotazione = null;

            m_CalcolaSoluzione_Sospesa = false;

            PulisciSoluzione();
            CalcolaSoluzione();
        }

        private void EditProfilo(ProfiloCliente profilo)
        {
            if (profilo != null)
            {
                List<Ingresso> elencoIngressiDaFare = ElencoIngressiDaFare();
                if (Uniforme(elencoIngressiDaFare))
                {
                    // modifica TUTTI i profili contemporaneamente ...
                    using (XtraFormProfiloClienteNT2 formProfilo = new XtraFormProfiloClienteNT2())
                    {
                        formProfilo.Init(this.unitOfWork1, elencoIngressiDaFare, m_GestoreProfili);
                        if (formProfilo.ShowDialog(this) == DialogResult.OK)
                        {
                            PulisciSoluzione();
                            CalcolaSoluzione();
                        }
                    }
                }
                else
                {
                    // modifica solo il profilo selezionato
                    using (XtraFormProfiloClienteNT1 formProfilo = new XtraFormProfiloClienteNT1())
                    {
                        formProfilo.Init(this.unitOfWork1, elencoIngressiDaFare, profilo, m_GestoreProfili);
                        if (formProfilo.ShowDialog(this) == DialogResult.OK)
                        {
                            PulisciSoluzione();
                            CalcolaSoluzione();
                        }
                    }
                }
            }
        }

        private static bool Uniforme(List<Ingresso> elencoIngressiDaFare)
        {
            if (elencoIngressiDaFare.Count == 1)
                return true;

            List<Ingresso> dafare = elencoIngressiDaFare;
            for (int i = 0; i < dafare.Count; i++)
            {
                for (int j = i + 1; j < dafare.Count; j++)
                {
                    // confronta i e j
                    if (dafare[i].TitoliDifferenti(dafare[j]))
                        return false;
                }
            }

            return true;
        }

        private List<Ingresso> ElencoIngressiDaFare()
        {
            List<Ingresso> dafare = new List<Ingresso>();

            foreach (TreeListNode treeListNode in this.treeListIngressi.Nodes)
            {
                if (treeListNode.HasChildren)
                {
                    dafare.AddRange(ElencoIngressiDaFare(treeListNode));
                }
                if (treeListNode.Tag is Ingresso && treeListNode.Checked)
                    dafare.Add((Ingresso)treeListNode.Tag);
            }

            return dafare;
        }

        private static List<Ingresso> ElencoIngressiDaFare(TreeListNode nodo)
        {
            List<Ingresso> dafare = new List<Ingresso>();
            foreach (TreeListNode treeListNode in nodo.Nodes)
            {
                if (treeListNode.HasChildren)
                {
                    dafare.AddRange(ElencoIngressiDaFare(treeListNode));
                }
                if (treeListNode.Tag is Ingresso && treeListNode.Checked)
                    dafare.Add((Ingresso)treeListNode.Tag);
            }

            return dafare;
        }

        private void CreaNuovoProfilo(List<Ingresso> list, Percorso percorso)
        {
            using (XtraFormProfiloClienteNT2 formProfilo = new XtraFormProfiloClienteNT2())
            {
                formProfilo.Init(this.unitOfWork1, list, m_GestoreProfili, percorso);
                if (formProfilo.ShowDialog(this) == DialogResult.OK)
                {
                    PulisciSoluzione();
                    CalcolaSoluzione();
                }
            }
        }

        private void CreaNuovoProfilo(List<Ingresso> dafare)
        {
            if (Uniforme(dafare))
            {
                using (XtraFormProfiloClienteNT2 formProfilo = new XtraFormProfiloClienteNT2())
                {
                    formProfilo.Init(this.unitOfWork1, dafare, m_GestoreProfili);
                    if (formProfilo.ShowDialog(this) == DialogResult.OK)
                    {
                        PulisciSoluzione();
                        CalcolaSoluzione();
                    }
                }
            }
            else
            {
                using (XtraFormProfiloClienteNT1 formProfilo = new XtraFormProfiloClienteNT1())
                {
                    ProfiloCliente profilo = new ProfiloCliente();
                    formProfilo.Init(this.unitOfWork1, dafare, profilo, m_GestoreProfili);
                    if (formProfilo.ShowDialog(this) == DialogResult.OK)
                    {
                        m_GestoreProfili.ElencoProfili.Add(profilo);
                        PulisciSoluzione();
                        CalcolaSoluzione();
                    }
                }
            }
        }

        private void gridControlProfili_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            e.Handled = true;

            if (e.Button.ButtonType == NavigatorButtonType.Append)
            {
                List<Ingresso> dafare = ElencoIngressiDaFare();

                if (dafare.Count > 0)
                {
                    CreaNuovoProfilo(dafare);
                }
                else
                    XtraMessageBox.Show("Nessun ingresso selezionato !", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (e.Button.ButtonType == NavigatorButtonType.Custom && (int)e.Button.Tag == 1)
            {
                if (XtraMessageBox.Show("Cancellare TUTTI i profili ?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    m_GestoreProfili.ElencoProfili.Clear();
                    PulisciSoluzione();
                    CalcolaSoluzione();
                }
            }

            //if (e.Button.ButtonType == NavigatorButtonType.Custom && (int)e.Button.Tag == 2)
            //{
            //    ProfiloCliente profilo = this.gridViewProfili.GetRow(this.gridViewProfili.FocusedRowHandle) as ProfiloCliente;
            //    if (profilo != null)
            //    {
            //        RibbonFormAskBonus rfab = new RibbonFormAskBonus();
            //        rfab.Init(this.unitOfWork1, m_GestoreProfili, profilo);
            //        if (rfab.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            //        {
            //            PulisciSoluzione();
            //            CalcolaSoluzione();
            //        }
            //    }
            //}

            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                ProfiloCliente profilo = this.gridViewProfili.GetRow(this.gridViewProfili.FocusedRowHandle) as ProfiloCliente;
                if (profilo != null)
                {
                    if (XtraMessageBox.Show("Confermi di rimuovere questo profilo ?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        m_GestoreProfili.ElencoProfili.Remove(profilo);
                        PulisciSoluzione();
                        CalcolaSoluzione();
                    }
                }
            }
        }

        private void gridViewProfili_DoubleClick(object sender, EventArgs e)
        {
            ProfiloCliente profilo = this.gridViewProfili.GetRow(this.gridViewProfili.FocusedRowHandle) as ProfiloCliente;
            EditProfilo(profilo);
        }

        private bool m_CalcolaSoluzione_Sospesa = false;
        private OptimizationFactory m_LastOpt;
        private void CalcolaSoluzione()
        {
            if (m_CalcolaSoluzione_Sospesa) return;

            Cursor saveCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.labelControlInfoSuggerimenti.ForeColor = Color.Green;
                this.labelControlInfoSuggerimenti.Text = "Calcolo possibili suggerimenti in corso ...";
                this.gridControlSuggerimenti.Visible = false;

                m_LastOpt = new OptimizationFactory(m_GestoreProfili, this.unitOfWork1);
                m_LastOpt.CalcolaSoluzioneKernel(ElencoIngressiDaFare());

                BackgroundWorker bgw = new BackgroundWorker();
                bgw.DoWork += bgw_DoWork;
                bgw.RunWorkerCompleted += bgw_RunWorkerCompleted;
                bgw.RunWorkerAsync(m_LastOpt);

                RefreshGrid();
            }
            finally
            {
                Cursor.Current = saveCursor;
            }
        }

        void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EventoFineSuggerimenti result = e.Result as EventoFineSuggerimenti;
            if (result != null)
            {
                if (result.OptFactory == m_LastOpt)
                {
                    if (result.ElencoSuggerimenti.Count > 0)
                    {
                        this.gridControlSuggerimenti.DataSource = result.ElencoSuggerimenti;
                        this.gridViewSuggerimenti.BestFitColumns();
                        this.gridControlSuggerimenti.Visible = true;
                    }
                    else
                    {
                        if (m_GestoreProfili.TotalePersone() > 0)
                        {
                            this.labelControlInfoSuggerimenti.Text = "Nessun suggerimento :-(";
                            this.labelControlInfoSuggerimenti.ForeColor = Color.Black;
                        }
                        else
                        {
                            this.labelControlInfoSuggerimenti.Text = string.Empty;
                            this.labelControlInfoSuggerimenti.ForeColor = Color.Black;
                        }
                    }
                }
            }
        }

        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            OptimizationFactory optfact = e.Argument as OptimizationFactory;

            if (optfact != null)
            {
                List<Suggerimento> elenco = optfact.Suggerimenti(ElencoIngressiDaFare());

                e.Result = new EventoFineSuggerimenti(optfact, elenco);
            }
        }

        private void barButtonItemRicerca_ItemClick(object sender, ItemClickEventArgs e)
        {
            m_CalcolaSoluzione_Sospesa = false;

            PulisciSoluzione();
            CalcolaSoluzione();
        }

        PrenotazioneComplessiva m_Prenotazione;
        private void simpleButtonStampa_Click(object sender, EventArgs e)
        {
            if (m_GestoreProfili.TotalePersone() == 0)
            {
                XtraMessageBox.Show("Nessun profilo cliente inserito.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!m_GestoreProfili.SoluzioneTrovata())
            {
                XtraMessageBox.Show("Alcuni profili non permettono emissione del biglietto.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!RegoleVerificate())
            {
                //XtraMessageBox.Show("Alcuni profili non rispettano le regole immesse.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // verifica titoli per buoni sconto ...
            if (!VerificaBuoniSconto())
            {
                XtraMessageBox.Show("Alcuni profili richiedono la registrazione del codice sconto.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ServeCardMyFE())
            {
                m_GestoreProfili.ClearInfoCardMyFE();
                if (!AskCardMyFE())
                {
                    XtraMessageBox.Show("Alcuni profili richiedono la registrazione delle relative Card MyFE.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (m_Prenotazione == null)
            {
                if (this.checkEditImponiData.Checked && this.dateEditDataImposta.DateTime.Year <= 2013)
                {
                    XtraMessageBox.Show("Non posso impostare la data della vendita nel 2013 o antecedente.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // SENZA PRENOTAZIONE !!
                PrenotazioneComplessiva prenotazione = new PrenotazioneComplessiva(m_GestoreProfili);

                if (this.checkEditPrevendita.Checked && !ValidiPerPrevendita(prenotazione))
                {
                    XtraMessageBox.Show("Hai selezionato un biglietto non valido per la prevendita.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (XtraFormStampa stampa = new XtraFormStampa())
                {
                    stampa.Init(prenotazione, ElencoIngressiDaFare(), this.checkEditImponiData.Checked, this.dateEditDataImposta.DateTime, this.checkEditPrevendita.Checked);
                    if (stampa.ShowDialog(this) == DialogResult.OK)
                    {
                        // pulisce tutto ...
                        barButtonItemClear_ItemClick(null, null);
                        // toglie il flag DATA IMPOSTA
                        this.checkEditImponiData.Checked = false;
                        this.checkEditPrevendita.Checked = false;
                    }
                }
            }
            else
            {
                if (this.checkEditImponiData.Checked || this.checkEditPrevendita.Checked)
                {
                    XtraMessageBox.Show("Non posso impostare la data della vendita se e' presente una prenotazione.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                m_Prenotazione.InitRefreshPrenotazione(ElencoIngressiDaFare());
                GestoreCalendario.Clear(m_Prenotazione.TipoGS(), m_Prenotazione.TipoScuola(), false);

                // CON PRENOTAZIONE

                //if (formPrenotazione == null)
                //    formPrenotazione = new RibbonFormPrenotazione2();
                //formPrenotazione.Init(ElencoIngressiDaFare(), m_Prenotazione);

                // verifica numero persone (possibile modifica della prenotazione)
                if (m_Prenotazione.PaxErrati())
                {
                    XtraMessageBox.Show("Attenzione: il numero di paganti non corrisponde al numero di persone nella prenotazione.", "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    if (XtraMessageBox.Show(String.Format("Modifico la prenotazione automaticamente per indicare {0} persone ?", m_Prenotazione.GestoreProfili.TotalePersone())
                        , "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (!AggiornaCalendario()) return;

                        m_Prenotazione.SistemaPrenotazione();

                        RefreshGrid();

                        XtraMessageBox.Show(string.Format("Aggiornata la prenotazione che ora include {0} slot.\nControllare il risultato prima di stampare.", m_Prenotazione.NumeroSlot()), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    return;
                }

                using (XtraFormStampa stampa = new XtraFormStampa())
                {
                    stampa.Init(m_Prenotazione, ElencoIngressiDaFare(), false, DateTime.Now, false);
                    if (stampa.ShowDialog(this) == DialogResult.OK)
                    {
                        // pulisce tutto ...
                        barButtonItemClear_ItemClick(null, null);
                        // toglie il flag DATA IMPOSTA
                        this.checkEditImponiData.Checked = false;
                        this.checkEditPrevendita.Checked = false;
                    }
                }
            }
        }

        private bool ValidiPerPrevendita(PrenotazioneComplessiva prenotazione)
        {
            foreach (ProfiloCliente profiloCliente in prenotazione.GestoreProfili.ElencoProfili)
            {
                foreach (SoluzioneIngressiItem sol in profiloCliente.SoluzionePreferita.Elenco)
                {
                    if (!(sol.Variante.Note ?? "").Contains("[PREVENDITA]")) return false;
                }
            }

            return true;
        }

        private bool AskCardMyFE()
        {
            int numero = m_GestoreProfili.NumeroCardMyFE();

            RibbonFormCardMyFeTicket nform = new RibbonFormCardMyFeTicket();
            nform.Init(numero, m_GestoreProfili.TipologiaMyFe);
            if (nform.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                if (nform.ElencoCard.Count == numero)
                {
                    int index = 0;

                    foreach (ProfiloCliente profilo in m_GestoreProfili.ElencoProfili)
                    {
                        foreach (SoluzioneIngressiItem sol in profilo.SoluzionePreferita.Elenco)
                        {
                            if (sol.Variante.MyFeComune())
                            {
                                for (int i = 0; i < sol.Quantita; i++)
                                {
                                    sol.ElencoCardMyFE.Add(nform.ElencoCard[index]);
                                    index++;
                                }
                            }
                        }
                    }

                    return true;
                }
            }

            return false;
        }

        private bool ServeCardMyFE()
        {
            foreach (ProfiloCliente profiloCliente in m_GestoreProfili.ElencoProfili)
            {
                foreach (SoluzioneIngressiItem soluzioneIngressiItem in profiloCliente.SoluzionePreferita.Elenco)
                    if (soluzioneIngressiItem.Variante.TipologiaTre == EnumTipologiaTre.CardMyFE)
                        return true;
            }
            return false;
        }

        private bool VerificaBuoniSconto()
        {
            bool richiedi = false;
            foreach (ProfiloCliente profiloCliente in m_GestoreProfili.ElencoProfili)
            {
                bool buono = false;
                foreach (SoluzioneIngressiItem soluzioneIngressiItem in profiloCliente.SoluzionePreferita.Elenco)
                {
                    if (soluzioneIngressiItem.Titolo != null && soluzioneIngressiItem.Titolo.Bonus())
                        buono = true;
                }
                if (!buono)
                    profiloCliente.ElencoCodiciSconto.Clear();
                else
                    if (profiloCliente.ElencoCodiciSconto.Count == 0) richiedi = true;
            }

            if (richiedi)
            {
                RibbonFormAskBonus rfab = new RibbonFormAskBonus();
                rfab.Init(this.unitOfWork1, m_GestoreProfili);
                if (rfab.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    RefreshGrid();
                    return VerificaBuoniSconto();
                }
                else
                    return false;
            }

            return true;
        }

        private XPCollection<EventoParticolare> regoleValide;
        private void CaricaRegole()
        {
            regoleValide = new XPCollection<EventoParticolare>(this.unitOfWork1);
            regoleValide.Criteria = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[] {
                        new BinaryOperator("DataOraInizio", DateTime.Now, BinaryOperatorType.LessOrEqual),
                        new BinaryOperator("DataOraFine", DateTime.Now, BinaryOperatorType.GreaterOrEqual)
                });
        }

        private bool RegoleVerificate()
        {
            foreach (EventoParticolare eventoParticolare in regoleValide)
            {
                if (eventoParticolare.DataOraFine < DateTime.Now) continue;
                if (eventoParticolare.DataOraInizio > DateTime.Now) continue;

                if (!m_GestoreProfili.RispettaRegole(eventoParticolare))
                {
                    //XtraMessageBox.Show("Alcuni profili non rispettano le regole immesse: " + eventoParticolare.Descrizione, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return false;

                    using (XtraFormCheckRegola regola = new XtraFormCheckRegola())
                    {
                        regola.Init(eventoParticolare);
                        if (regola.ShowDialog(this) != DialogResult.Ignore)
                            return false;
                    }
                }
            }

            return true;
        }

        private void gridControlSuggerimenti_DoubleClick(object sender, EventArgs e)
        {
            Suggerimento sugg = this.gridViewSuggerimenti.GetFocusedRow() as Suggerimento;
            if (sugg != null)
            {
                if (XtraMessageBox.Show(String.Format("Aggiungo: {0} ?", sugg.DescrizioneCompleta()), "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    m_CalcolaSoluzione_Sospesa = true;

                    this.treeListIngressi.BeginUpdate();
                    if (sugg.IngressoUno != null)
                    {
                        TreeListNode nodo1 = this.treeListIngressi.FindNodeByFieldValue("treeKey", sugg.IngressoUno.Oid);
                        if (nodo1 != null)
                            nodo1.Checked = true;
                    }
                    if (sugg.IngressoDue != null)
                    {
                        TreeListNode nodo2 = this.treeListIngressi.FindNodeByFieldValue("treeKey", sugg.IngressoDue.Oid);
                        if (nodo2 != null)
                            nodo2.Checked = true;
                    }
                    this.treeListIngressi.EndUpdate();

                    m_CalcolaSoluzione_Sospesa = false;

                    PulisciSoluzione();
                    CalcolaSoluzione();
                }
            }
        }

        private void AggiornaBottoniPrenotazione()
        {
            if (m_Prenotazione == null)
            {
                this.barButtonItemGet.Enabled = true;
                this.barButtonItemPrenotazioneDelete.Enabled = false;
                this.barButtonItemPrenotazioneNew.Enabled = true;
            }
            else
            {
                this.barButtonItemGet.Enabled = false;
                this.barButtonItemPrenotazioneDelete.Enabled = true;
                this.barButtonItemPrenotazioneNew.Enabled = true;
            }
        }

        private void CaricaPrenotazioneDalWeb()
        {
            Cursor saveCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                m_Prenotazione = new PrenotazioneComplessiva(m_GestoreProfili);
                //formPrenotazione = null;

                m_Prenotazione.PreventObj = RichiestaGet.MakeGet();

                if (m_Prenotazione.PreventObj != null)
                {
                    m_CalcolaSoluzione_Sospesa = true;

                    m_Prenotazione.CreaProfiliPrevent();
                    List<Ingresso> elenco = m_Prenotazione.CreaElencoPrevent(this.unitOfWork1);

                    ClearTreeIngressi(false);

                    this.treeListIngressi.BeginUpdate();
                    foreach (Ingresso item in elenco)
                    {
                        TreeListNode nodo = this.treeListIngressi.FindNodeByFieldValue("treeKey", item.Oid);
                        nodo.Checked = true;
                    }
                    this.treeListIngressi.EndUpdate();

                    m_Prenotazione.CreaSlotPrevent(elenco);

                    m_CalcolaSoluzione_Sospesa = false;
                }
                else
                {
                    m_Prenotazione = null;
                    if (RichiestaGet.UltimoErrore != null)
                    {
                        XtraMessageBox.Show(RichiestaGet.UltimoErrore.DescrizioneErrore, "Errore: " + RichiestaGet.UltimoErrore.ReturnCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                PulisciSoluzione();
                CalcolaSoluzione();

                RefreshGrid();
            }
            finally
            {
                Cursor.Current = saveCursor;
            }
        }

        private void barButtonItemGet_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m_GestoreProfili.ElencoProfili.Count > 0)
            {
                XtraMessageBox.Show("Non è possibile effetuare l'operazione perchè ci sono profili già inseriti.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (XtraFormDownloadPrevent fdown = new XtraFormDownloadPrevent())
                {
                    if (fdown.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        CaricaPrenotazioneDalWeb();
                }
            }
        }

        private bool AggiornaCalendario()
        {
            GestoreCalendario.Clear(m_Prenotazione.TipoGS(), m_Prenotazione.TipoScuola(), false);

            List<Ingresso> elencoIngressiDaFare = ElencoIngressiDaFare();

            List<int> listingressi = new List<int>();
            foreach (Ingresso item in elencoIngressiDaFare)
            {
                if (item.CodicePrevent != 0)
                {
                    listingressi.Add(item.CodicePrevent);

                    GestoreCalendario.GeneraRichiesta(DateTime.Now.Date, item.CodicePrevent);
                    GestoreCalendario.GeneraRichiesta(DateTime.Now.Date.AddDays(1), item.CodicePrevent);
                }
            }

            foreach (PrenotazioneIngresso prenotazioneIngresso in m_Prenotazione.Prenotazioni)
            {
                foreach (SingolaPrenotazione singolaPrenotazione in prenotazioneIngresso.Prenotazioni)
                {
                    GestoreCalendario.GeneraRichiesta(singolaPrenotazione.Orario.Date, prenotazioneIngresso.Ingresso.CodicePrevent);
                    GestoreCalendario.GeneraRichiesta(singolaPrenotazione.Orario.Date.AddDays(-1), prenotazioneIngresso.Ingresso.CodicePrevent);
                    GestoreCalendario.GeneraRichiesta(singolaPrenotazione.Orario.Date.AddDays(1), prenotazioneIngresso.Ingresso.CodicePrevent);
                }
            }

            GestoreCalendario.Dump();

            do
            {
                using (XtraFormAskInfoPrenotazione info = new XtraFormAskInfoPrenotazione())
                {
                    info.Init(m_Prenotazione);
                    if (info.ShowDialog(this) == DialogResult.Cancel)
                        return false;
                }
            } while (GestoreCalendario.RichiesteInCoda() != 0);

            GestoreCalendario.ClearAltriIngressi(listingressi);

            return true;
        }

        //RibbonFormPrenotazione2 formPrenotazione = null;
        private void barButtonItemPrenotazioneNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            // crea o modifica una nuova prenotazione
            List<Ingresso> elencoIngressiDaFare = ElencoIngressiDaFare();

            if (m_GestoreProfili.TotalePersone() == 0 || elencoIngressiDaFare.Count == 0)
            {
                XtraMessageBox.Show("Nessun profilo cliente inserito.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (m_Prenotazione == null)
                {
                    m_Prenotazione = new PrenotazioneComplessiva(m_GestoreProfili);
                }

                if (!AggiornaCalendario()) return;

                if (string.IsNullOrEmpty(m_Prenotazione.RiferimentoVendita)) return;

                using (RibbonFormPrenotazione2 formPrenotazione = new RibbonFormPrenotazione2())
                {
                    formPrenotazione.Init(elencoIngressiDaFare, m_Prenotazione);
                    // visualizzo i dati della prenotazione
                    if (formPrenotazione.ShowDialog(this) == DialogResult.OK)
                        RefreshGrid();
                }
            }
        }

        private void barButtonItemPrenotazioneEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Senza prenotazione ?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                m_Prenotazione = null;
                RefreshGrid();
            }
        }

        private void checkEditImponiData_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.dateEditDataImposta.Visible && this.checkEditImponiData.Checked)
                this.dateEditDataImposta.DateTime = DateTime.Now;

            //this.dateEditDataImposta.DateTime = new DateTime(2018, 7, 14, 21, 0, 0);
            this.dateEditDataImposta.Visible = this.checkEditImponiData.Checked;
        }

        private void treeListIngressi_CustomDrawNodeCheckBox(object sender, DevExpress.XtraTreeList.CustomDrawNodeCheckBoxEventArgs e)
        {
            if (!(e.Node.Tag is Ingresso))
                e.Handled = true;
        }

        private void treeListIngressi_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            PulisciSoluzione();
            CalcolaSoluzione();
        }

        private void treeListIngressi_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            if (e.Node.Checked)
            {
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                e.Appearance.ForeColor = Color.Red;
            }

            if (e.Node.HasChildren && !(e.Node.Tag is Ingresso))
            {
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Regular);

                if (IsCheckedRecursive(e.Node))
                {
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                    e.Appearance.ForeColor = Color.Blue;
                }
            }

            if (e.Node.HasChildren && e.Node.Tag is Ingresso)
            {
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Regular);

                if (e.Node.Checked)
                {
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                    e.Appearance.ForeColor = Color.Red;
                }
                else if (IsCheckedRecursive(e.Node))
                {
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                    e.Appearance.ForeColor = Color.Black;
                }
            }

            Ingresso ingresso = e.Node.Tag as Ingresso;
            if (ingresso != null)
            {
                if (Program.Postazione.Ingresso.GetAccesso(ingresso) == EnumAccesso.VisibileDisabilitato)
                {
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Strikeout | e.Appearance.Font.Style);
                }
            }           
        }

        private static bool IsCheckedRecursive(TreeListNode nodo)
        {
            if (nodo.Checked) return true;
            foreach (TreeListNode item in nodo.Nodes)
                if (IsCheckedRecursive(item)) return true;
            return false;
        }

        private void treeListIngressi_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            Ingresso ingresso = e.Node.Tag as Ingresso;
            if (ingresso != null)
            {
                if (Program.Postazione.Ingresso.GetAccesso(ingresso) == EnumAccesso.VisibileDisabilitato)
                {
                    e.State = CheckState.Unchecked;
                    //XtraMessageBox.Show("a");
                }
                else
                {
                    e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);

                    if (e.State == CheckState.Checked && e.Node.ParentNode.Tag is Ingresso)
                    {
                        e.Node.ParentNode.Checked = true;
                    }

                    if (e.State == CheckState.Unchecked && e.Node.HasChildren)
                    {
                        foreach (TreeListNode node in e.Node.Nodes)
                        {
                            node.Checked = false;
                        }
                    }

                    // gestione MOSTRA CASTELLO
                    if (e.State == CheckState.Checked && ingresso.IsAttrib("[SG-M]"))
                    {
                        // sgarbi mostra, tolgo castello
                        foreach (TreeListNode node in e.Node.ParentNode.Nodes)
                        {
                            var i2 = node.Tag as Ingresso;
                            if (i2 != null && i2.IsAttrib("[SG-C]"))
                                node.Checked = false;
                        }
                    }
                    if (e.State == CheckState.Checked && ingresso.IsAttrib("[SG-C]"))
                    {
                        // castello, tolgo sgarbi mostra
                        foreach (TreeListNode node in e.Node.ParentNode.Nodes)
                        {
                            var i2 = node.Tag as Ingresso;
                            if (i2 != null && i2.IsAttrib("[SG-M]"))
                                node.Checked = false;
                        }
                    }


                }
            }
            else
            {
                e.CanCheck = false;
            }
        }

        private void barButtonItemStampa_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.printableComponentLink1.CreateDocument();
            this.printableComponentLink1.ShowPreviewDialog(this);
        }

        private void barButtonItemRistampa_ItemClick(object sender, ItemClickEventArgs e)
        {
            XPCollection<Vendita> vendite = new XPCollection<Vendita>(this.unitOfWork1) 
            { 
                TopReturnedObjects = 1, 
                Sorting = new SortingCollection(new SortProperty[] { new SortProperty("DataOraStampa", DevExpress.Xpo.DB.SortingDirection.Descending) }),
                Criteria = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                    new BinaryOperator("Postazione.Oid", Program.Postazione.Oid),
                    new BinaryOperator("DataContabile", DateTime.Now.Date)})
            };

            if (vendite.Count > 0)
            {
                if (XtraMessageBox.Show("Questa funzione ristampa l'ultima vendita effettuata da questa postazione. Il suo utilizzo dovrebbe essere limitato a problemi di stampa per inceppamenti, mancanza carta od altro. Confermi di voler ristampare l'ultima vendita ?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    using (Session session = new Session())
                    {
                        Messaggio msg = new Messaggio(session);
                        msg.Autore = session.GetObjectByKey<Utente>(Program.UtenteCollegato.Oid);
                        msg.Data = DateTime.Now;
                        msg.Oggetto = "Ristampa " + vendite[0].CodiceLeggibile;
                        msg.TestoEsteso = String.Format("L'utente {0} ha ristampato i biglietti relativi alla vendita {1} di importo totale {2:c} dalla postazione {3}.", Program.UtenteCollegato.FullName, vendite[0].CodiceLeggibile, vendite[0].TotaleImporto, Program.Postazione.Nome);
                        msg.TestoEsteso += XtraFormDettaglioVendita.Descrizione(vendite[0]);
                        msg.Tipologia = EnumTipoMessaggio.Ristampa;

                        msg.Save();
                    }

                    ReportHelper.Print(vendite[0]);
                }
            }
            else
                XtraMessageBox.Show("Nessuna vendita registrata da questa postazione in data odierna", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void barButtonItemBarCode_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (RibbonFormValidazione form = new RibbonFormValidazione())
            {
                form.ShowDialog(this);
            }
        }

        private void ribbon_ApplicationButtonClick(object sender, EventArgs e)
        {
            Process.Start("http://www.xpsoft.it");
        }

        private void barButtonItemMyFE1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m_GestoreProfili.ElencoProfili.Count != 0)
            {
                XtraMessageBox.Show("Per utilizzare questa funzione non devi avere profili in elenco", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (RibbonFormCardMyFeTurista turi = new RibbonFormCardMyFeTurista())
                {
                    turi.Init(false);
                    if (turi.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {

                    }
                }
            }
        }

        private void barButtonItemMyFE2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m_GestoreProfili.ElencoProfili.Count != 0)
            {
                XtraMessageBox.Show("Per utilizzare questa funzione non devi avere profili in elenco", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (RibbonFormCardMyFeTurista turi = new RibbonFormCardMyFeTurista())
                {
                    turi.Init(true);
                    if (turi.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {

                    }
                }
            }
        }

        private void FlagChanged()
        {
            if (barCheckItem2gg.Checked) m_GestoreProfili.TipologiaMyFe = EnumTipologiaCard.Card2Giorni;
            if (barCheckItem3gg.Checked) m_GestoreProfili.TipologiaMyFe = EnumTipologiaCard.Card3Giorni;
            if (barCheckItem6gg.Checked) m_GestoreProfili.TipologiaMyFe = EnumTipologiaCard.Card6Giorni;
            if (barCheckItemNoCard.Checked) m_GestoreProfili.TipologiaMyFe = EnumTipologiaCard.None;
            CalcolaSoluzione();
        }

        private void barCheckItem2gg_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            FlagChanged();
        }

        private void barCheckItem3gg_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            FlagChanged();
        }

        private void barCheckItem6gg_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            FlagChanged();
        }

        private void barCheckItemNoCard_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            FlagChanged();
        }

        private void barButtonItemVendita_ItemClick(object sender, ItemClickEventArgs e)
        {
            XPCollection<Vendita> vendite = new XPCollection<Vendita>(this.unitOfWork1)
            {
                TopReturnedObjects = 1,
                Sorting =
                    new SortingCollection(new SortProperty[]
                    {new SortProperty("DataOraStampa", DevExpress.Xpo.DB.SortingDirection.Descending)}),
                Criteria = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]
                {
                    new BinaryOperator("Postazione.Oid", Program.Postazione.Oid),
                    new BinaryOperator("DataContabile", DateTime.Now.Date)
                })
            };

            if (vendite.Count > 0)
            {
                XtraFormDettaglioVendita dettaglio = new XtraFormDettaglioVendita();
                dettaglio.Init(vendite[0]);
                if (dettaglio.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {


                }
            }
            else
            {
                XtraMessageBox.Show("Nessuna vendita da questa postazione in data odierna.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void barButtonItemMatricolaUnife_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ElencoIngressiDaFare().Count == 0)
            {
                XtraMessageBox.Show("Occorre selezionare almeno un ingresso.", "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (RibbonFormMatricolaUnife form = new RibbonFormMatricolaUnife())
                {
                    form.Init(ElencoIngressiDaFare());
                    form.ShowDialog(this);
                }
            }

        }

        private void checkEditPrevendita_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEditPrevendita.Checked)
            {
                this.checkEditImponiData.Checked = true;
                this.dateEditDataImposta.DateTime = new DateTime(2018, 7, 14, 21, 0, 0);
            }
        }
    }
}