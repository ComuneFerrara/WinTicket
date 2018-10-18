using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;
using Musei.Module;
using WinTicketNext.Storico;
using DevExpress.Xpo;
using System.Diagnostics;
using WinTicketNext.CostruzionePercorso;

namespace WinTicketNext.Validazione
{
    public partial class RibbonFormValidazione : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private void MoveFocus()
        {
            this.buttonEditCodice.Focus();
            this.buttonEditCodice.SelectAll();
        }

        public RibbonFormValidazione()
        {
            InitializeComponent();

            foreach (PostazioneIngresso postazioneIngresso in Program.Postazione.Ingressi)
            {
                BarButtonItem btn = new BarButtonItem();
                btn.Caption = postazioneIngresso.Ingresso.Descrizione;
                btn.LargeGlyph = WinTicketNext.Properties.Resources.checkbox_unchecked;
                btn.Tag = postazioneIngresso.Ingresso;
                btn.Enabled = false;

                this.ribbonPageGroupIngressi.ItemLinks.Add(btn);
            }

            Pulisci();
        }

        private void Pulisci()
        {
            this.textEditIntestazioneCard.Text = string.Empty;
            this.buttonEditCodice.Text = string.Empty;
            this.spinEdit1.Value = 0;
            this.spinEdit1.Enabled = false;
            this.simpleButtonRegistra.Enabled = false;
            this.panelControlInfo.Visible = false;
            this.barButtonItemIngresso.Enabled = false;
            this.barButtonItemAltre.Enabled = false;

            // toglie tutti i check
            foreach (BarItemLink itemLink in this.ribbonPageGroupIngressi.ItemLinks)
            {
                itemLink.Item.LargeGlyph = WinTicketNext.Properties.Resources.checkbox_unchecked;
                itemLink.Item.Enabled = false;
            }

            StaticInfo.DataAgg(this.barStaticItemInfo);

            MoveFocus();
        }

        private XPCollection<Stampa> CoStampa = null;

        private void ImpostaValiditaCard(Stampa stampa)
        {
            if (stampa.Card != null && stampa.Card.Albergo != null && !stampa.EsistonoEntrate() && stampa.InizioValidita != DateTime.Today)
            {
                if (XtraMessageBox.Show(string.Format("La card {0}:{1} risulta NON essere stata ancora usata. Imposto la validità a partire da oggi ?",
                    stampa.Card.Codice, stampa.Card.Albergo.RagioneSociale),
                    "Validità Card", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    stampa.InizioValidita = DateTime.Today;
                    stampa.FineValidita = DateTime.Today.AddDays(stampa.Card.Giorni());
                    stampa.Save();

                    this.unitOfWork1.CommitChanges();
                }
            }
        }
        private void StampaVenditaOnline(Stampa stampa, bool force)
        {
            if (stampa.Card != null && stampa.Card.VendutaOnline && (!stampa.Card.EmessoBiglietto || force))
            {
                ReportHelper.Print(stampa.Vendita);

                stampa.Card.EmessoBiglietto = true;
                stampa.Card.Save();
                this.unitOfWork1.CommitChanges();
            }
        }

        private void simpleButtonVerifica_Click(object sender, EventArgs e)
        {
            string codice = this.buttonEditCodice.Text;

            CoStampa = new XPCollection<Stampa>(this.unitOfWork1);
            CoStampa.Criteria = new GroupOperator(GroupOperatorType.Or,
                new CriteriaOperator[]{
                    new BinaryOperator("BarCode", codice),
                    new BinaryOperator("CodiceProgressivo", codice),
                    new BinaryOperator("Card.Codice", codice)
                });
            CoStampa.Sorting = new SortingCollection(new SortProperty[] { new SortProperty("Vendita.DataOraStampa", DevExpress.Xpo.DB.SortingDirection.Descending) });

            this.gridControlIngressi.DataSource = CoStampa;

            if (CoStampa.Count == 0)
            {
                Pulisci();
                if (!string.IsNullOrEmpty(codice) && codice.Length > 3)
                {
                    Postazione postazione = this.unitOfWork1.GetObjectByKey<Postazione>(Program.Postazione.Oid);
                    EntrataPosticipata entrata = this.unitOfWork1.FindObject<EntrataPosticipata>(new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{ 
                        new BinaryOperator("BarCode", codice),
                        new BinaryOperator("Postazione", postazione),
                        new BinaryOperator("Status", EnumStatusEntrata.InCoda)}));

                    if (entrata == null)
                    {
                        entrata = new EntrataPosticipata(this.unitOfWork1);
                        entrata.BarCode = codice;
                        entrata.DataOraEntrata = DateTime.Now;
                        entrata.Postazione = postazione;
                        entrata.Utente = this.unitOfWork1.GetObjectByKey<Utente>(Program.UtenteCollegato.Oid);
                        entrata.Status = EnumStatusEntrata.InCoda;
                        entrata.Save();

                        Messaggio msg = new Messaggio(this.unitOfWork1);
                        msg.Data = DateTime.Now;
                        msg.Oggetto = String.Format("BarCode {0}", codice);
                        msg.TestoEsteso = String.Format("BarCode {0} non trovato, utente {1}, postazione {2} ! (inserito nella lista per il recupero posticipato)", codice,
                            Program.UtenteCollegato.FullName,
                            Program.Postazione.Nome);
                        msg.Autore = entrata.Utente;
                        msg.Tipologia = EnumTipoMessaggio.EntrataPosticipata;
                        msg.Save();

                        this.unitOfWork1.CommitChanges();

                        XtraMessageBox.Show(String.Format("Codice {0} NON trovato! (inserito nella lista per il recupero posticipato)", codice), "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        XtraMessageBox.Show(String.Format("Codice {0} NON trovato! (il codice è già presente nella lista per il recupero posticipato)", codice), "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    XtraMessageBox.Show(String.Format("Codice {0} errato!", codice), "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.spinEdit1.Value = 0;
                this.spinEdit1.Enabled = false;
                this.simpleButtonRegistra.Enabled = false;
                this.barButtonItemAltre.Enabled = true;

                this.panelControlInfo.Visible = true;
                this.gridViewIngressi.BestFitColumns();

                this.barButtonItemIngresso.Enabled = true;

                // prendo la prima stampa (dovrebbe essere l'unica, se non ho cercato per vendita.codiceleggibile)
                Stampa stampa = CoStampa[0];
                ImpostaValiditaCard(stampa);
                AbilitaStampaCardMyFE(stampa);

                this.textEditIntestazioneCard.Text = "";
                if (stampa.Card != null)
                {
                    if (stampa.Card.Albergo != null)
                        this.textEditIntestazioneCard.Text = stampa.Card.Albergo.RagioneSociale;
                    if (stampa.Card.VendutaOnline)
                        this.textEditIntestazioneCard.Text = stampa.Card.TitolareCarta;
                }

                this.textEditBarCode.Text = stampa.BarCode;
                this.textEditProg.Text = stampa.CodiceProgressivo;
                this.dateEditStart.DateTime = stampa.InizioValidita;
                this.dateEditEnd.DateTime = stampa.FineValidita;
                this.textEdit1.Text = stampa.Vendita.Postazione.Nome;

                this.labelControlStatus.Text = "Regolare";
                this.labelControlStatus.ForeColor = Color.Green;

                // toglie tutti i check
                foreach (BarItemLink itemLink in this.ribbonPageGroupIngressi.ItemLinks)
                {
                    itemLink.Item.LargeGlyph = WinTicketNext.Properties.Resources.checkbox_unchecked;
                    itemLink.Item.Enabled = false;
                }

                int qta = int.MaxValue;
                int totali = 0;
                foreach (PostazioneIngresso postazioneIngresso in Program.Postazione.Ingressi)
                {
                    RigaStampaIngresso elemento = GetElemento(stampa, postazioneIngresso.Ingresso);
                    if (elemento != null)
                    {
                        totali += elemento.TotalePersone;

                        int poq = elemento.TotalePersone - elemento.TotaleIngressi;
                        if (poq > 0)
                        {
                            qta = Math.Min(poq, qta);

                            foreach (BarItemLink itemLink in this.ribbonPageGroupIngressi.ItemLinks)
                            {
                                Ingresso ingre = itemLink.Item.Tag as Ingresso;
                                if (ingre != null && ingre.Oid == elemento.Ingresso.Oid)
                                {
                                    itemLink.Item.LargeGlyph = WinTicketNext.Properties.Resources.checkbox;
                                    itemLink.Item.Enabled = true;
                                }
                            }
                        }
                    }
                }

                if (qta > 0 && qta < 10000)
                {
                    StampaVenditaOnline(stampa, false);

                    this.spinEdit1.Value = qta;
                    this.spinEdit1.Enabled = true;
                    this.simpleButtonRegistra.Enabled = true;
                }
                else
                {
                    if (totali > 0)
                    {
                        this.labelControlStatus.Text = "Già utilizzato";
                        this.labelControlStatus.ForeColor = Color.Orange;
                    }
                    else
                    {
                        this.labelControlStatus.Text = "non valido per questa postazione";
                        this.labelControlStatus.ForeColor = Color.Orange;
                    }
                }

                DateTime adesso = DateTime.Now.Date;
                if (adesso >= stampa.InizioValidita && adesso <= stampa.FineValidita)
                {
                    this.dateEditEnd.BackColor = Color.FromArgb(247, 245, 241);
                    this.dateEditStart.BackColor = Color.FromArgb(247, 245, 241);

                    this.labelControlStatus.Text += " (non scaduto)";
                }
                else
                {
                    this.dateEditEnd.BackColor = Color.Orange;
                    this.dateEditStart.BackColor = Color.Orange;

                    this.labelControlStatus.Text += " (SCADUTO)";
                }
            }

            MoveFocus();
        }

        private void AbilitaStampaCardMyFE(Stampa stampa)
        {
            this.barButtonItemStampaMyFE.Enabled = (stampa.Card != null && stampa.Card.VendutaOnline);
        }

        private static RigaStampaIngresso GetElemento(Stampa stampa, Ingresso ingresso)
        {
            // cerca ingresso giusto
            RigaStampaIngresso elemento = null;
            foreach (RigaStampaIngresso item in stampa.RigheStampaIngresso)
            {
                if (item.Ingresso.Oid == ingresso.Oid)
                    elemento = item;
            }
            return elemento;
        }

        private void simpleButtonRegistra_Click(object sender, EventArgs e)
        {
            int pax = (int)this.spinEdit1.Value;

            Stampa stampa = CoStampa[0];
            ImpostaValiditaCard(stampa);

            if (stampa != null && pax > 0)
            {
                string descrizione = string.Empty;
                foreach (PostazioneIngresso postazioneIngresso in Program.Postazione.Ingressi)
                {
                    RigaStampaIngresso elemento = GetElemento(stampa, postazioneIngresso.Ingresso);
                    if (elemento != null)
                    { 
                        int poq = elemento.TotalePersone - elemento.TotaleIngressi; 
                        if (poq > 0 && poq >= pax)
                            descrizione += string.Format("-< {0} >-", elemento.Ingresso.Descrizione);
                    }
                }

                if (!string.IsNullOrEmpty(descrizione))
                {
                    if (XtraMessageBox.Show(
                        string.Format("Confermi l'ingresso di {0} persone a: {1}",
                        pax, descrizione),
                        "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (PostazioneIngresso postazioneIngresso in Program.Postazione.Ingressi)
                        {
                            RigaStampaIngresso elemento = GetElemento(stampa, postazioneIngresso.Ingresso);
                            if (elemento != null)
                            {
                                int poq = elemento.TotalePersone - elemento.TotaleIngressi;
                                if (poq > 0 && poq >= pax)
                                {
                                    elemento.TotaleIngressi += pax;
                                    elemento.Save();

                                    Entrata entrata = new Entrata(this.unitOfWork1);
                                    entrata.DataOraEntrata = DateTime.Now;
                                    entrata.Quantita = pax;
                                    entrata.RigaStampaIngresso = elemento;
                                    entrata.Save();
                                }
                            }
                        }

                        this.unitOfWork1.CommitChanges();

                        Pulisci();
                    }
                }
                else
                    XtraMessageBox.Show("Errore");
            }
            else
                XtraMessageBox.Show("Errore");

            MoveFocus();
        }

        private void barButtonItemAnnulla_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CoStampa.Count > 0)
            {
                Stampa stampa = CoStampa[0];
                if (stampa != null)
                {
                    using (XtraFormDettaglioVendita dettaglio = new XtraFormDettaglioVendita())
                    {
                        dettaglio.Init(stampa.Vendita);
                        if (dettaglio.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            Pulisci();
                    }
                }
            }

            MoveFocus();
        }

        private void timerTick_Tick(object sender, EventArgs e)
        {
            if (!this.buttonEditCodice.EditorContainsFocus)
                this.buttonEditCodice.Focus();
        }

        private void ribbon_ApplicationButtonClick(object sender, EventArgs e)
        {
            Process.Start("http://www.xpsoft.it");
        }

        private void barButtonItemStampaMyFE_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CoStampa.Count > 0)
            {
                Stampa stampa = CoStampa[0];
                if (stampa != null)
                {
                    StampaVenditaOnline(stampa, true);
                }
            }
        }
    }
}