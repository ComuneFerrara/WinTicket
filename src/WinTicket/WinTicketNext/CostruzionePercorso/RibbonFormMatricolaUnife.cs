using System;
using System.Collections.Generic;
using DevExpress.Xpo;
using Musei.Module;
using DevExpress.Data.Filtering;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WinTicketNext.CostruzionePercorso.GestionePrenotazione;

namespace WinTicketNext.CostruzionePercorso
{
    public partial class RibbonFormMatricolaUnife : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private UnitOfWork _UnitOfWork;
        //private bool _Albergo;
        private Vendita m_Vendita;

        public List<Matricola> ElencoCard = new List<Matricola>();
        private List<Ingresso> ElencoIngressi = new List<Ingresso>();

        public RibbonFormMatricolaUnife()
        {
            InitializeComponent();
        }

        private void timerTick_Tick(object sender, EventArgs e)
        {
            if (!this.buttonEditCodice.EditorContainsFocus)
                this.buttonEditCodice.Focus();
        }

        internal void Init(List<Ingresso> percorso)
        {
            ElencoIngressi = percorso;

            //_Albergo = albergo;
            _UnitOfWork = new UnitOfWork();

            this.gridControlElencoCard.DataSource = ElencoCard;
            //if (_Albergo)
            //    this.lookUpEditAlbergo.Properties.DataSource = new XPCollection<AnagraficaCard>(this._UnitOfWork);

            UpdateInfo();
        }

        private void UpdateInfo()
        {
            this.gridControlElencoCard.RefreshDataSource();
            this.labelControlTotale.Text = string.Format("Importo totale: {0:c} ({1} pax)", CalcolaTotale(ElencoCard), ElencoCard.Count);
            this.simpleButtonOk.Enabled = ElencoCard.Count != 0;
            //this.groupControlAlbergo.Visible = _Albergo;
            this.labelControlInfoText.Visible = true;
        }

        private decimal CalcolaTotale(List<Matricola> ElencoCard)
        {
            return 0;
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            if (Program.Postazione.Tipologia == EnumTipologiaPostazione.NonAttiva)
            {
                XtraMessageBox.Show("Questa postazione non e' abilitata per emettere biglietti.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if (_Albergo && this.lookUpEditAlbergo.EditValue == null)
            //{
            //    XtraMessageBox.Show("Specificare il nominativo dell'albergo (oppure 'Altro')", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            if (CreaVendita())
            {
                ReportHelper.Print(m_Vendita);

                DialogResult = DialogResult.OK;
            }
        }

        private bool CreaVendita()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Vendita vendita = new Vendita(uow);

                vendita.Incasso = this.checkEditPos.Checked ? EnumIncasso.Pos : EnumIncasso.Contanti;
                vendita.CodiceLeggibile = Vendita.NuovoCodiceVendita();
                vendita.CodicePrevent = "";

                vendita.DataContabile = DateTime.Now.Date;
                vendita.DataOraStampa = DateTime.Now;

                vendita.Descrizione = "";

                vendita.Utente = uow.GetObjectByKey<Utente>(Program.UtenteCollegato.Oid);
                vendita.Postazione = uow.GetObjectByKey<Postazione>(Program.Postazione.Oid);
                vendita.Struttura = uow.GetObjectByKey<Struttura>(Program.Postazione.Struttura.Oid);
                vendita.TotalePersone = ElencoCard.Count;
                vendita.TotaleImporto = CalcolaTotale(ElencoCard);
                vendita.Save();

                //Percorso per = uow.FindObject<Percorso>(new BinaryOperator("Descrizione", "MyFE"));
                for (int i = 0; i < ElencoCard.Count; i++)
                {
                    Matricola card = uow.GetObjectByKey<Matricola>(ElencoCard[i].Oid);
                    Titolo unife = uow.FindObject<Titolo>(new BinaryOperator("Attributi", "-UNIFE-"));

                    //Variante v1 = per.GetVarianteMyFe("Com", "C", card.TipologiaCard);
                    //Variante v2 = per.GetVarianteMyFe("Pin", "C", card.TipologiaCard);

                    if (unife == null)
                    {
                        XtraMessageBox.Show("Titolo per -UNIFE- mancante", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (card == null)
                    {
                        XtraMessageBox.Show("Tessera unife mancante", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (card.ValidaDal > DateTime.Today)
                    {
                        XtraMessageBox.Show("Tessera " + card.Codice + " valida dal " + card.ValidaDal.ToString("d"), "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (card.ValidaAl < DateTime.Today)
                    {
                        XtraMessageBox.Show("Tessera " + card.Codice + " valida fino al " + card.ValidaAl.ToString("d"), "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    decimal totale = 0; // = v1.Prezzo + v2.Prezzo;

                    //List<Ingresso> ingressi = new List<Ingresso>();
                    //ingressi.AddRange(per.Ingressi);

                    foreach (Ingresso ingresso in ElencoIngressi)
                    {
                        Variante v1 = FindVarianteSingoleOmaggio(uow, ingresso);

                        if (v1 == null)
                        {
                            XtraMessageBox.Show("Per ingresso " + ingresso.Descrizione + " non esiste una variante adeguata.", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        RigaVenditaVariante rvv1 = new RigaVenditaVariante(uow);
                        rvv1.PrezzoTotale = v1.Prezzo;
                        rvv1.PrezzoUnitario = v1.Prezzo;
                        rvv1.Profilo = i;
                        rvv1.Quantita = 1;
                        rvv1.Variante = v1;
                        rvv1.Vendita = vendita;
                        rvv1.Titolo = unife;
                        //rvv1.Card = card;
                        rvv1.Matricola = card.Codice;
                        rvv1.Save();

                        totale += v1.Prezzo;
                    }

                    //RigaVenditaVariante rvv2 = new RigaVenditaVariante(uow);
                    //rvv2.PrezzoTotale = v2.Prezzo;
                    //rvv2.PrezzoUnitario = v2.Prezzo;
                    //rvv2.Profilo = i;
                    //rvv2.Quantita = 1;
                    //rvv2.Variante = v2;
                    //rvv2.Vendita = vendita;
                    //rvv2.Card = card;
                    //rvv2.Save();

                    DateTime inizioVal = DateTime.Now.Date;
                    DateTime fineVal = DateTime.Now.Date;

                    Stampa stampa = new Stampa(uow);
                    stampa.Vendita = vendita;
                    stampa.InizioValidita = inizioVal;
                    stampa.FineValidita = fineVal;
                    stampa.Quantita = 1;
                    stampa.ImportoTotale = totale;
                    stampa.StatoStampa = i;
                    stampa.TipoStampa = EnumTipoStampa.Standard;
                    //stampa.Card = card;
                    stampa.Matricola = card.Codice;
                    stampa.Save();
                    stampa.GeneraBarCode(Program.Postazione, ElencoIngressi);

                    //card.Status = EnumStatoCard.Emessa;
                    //card.Stampa = stampa;
                    ////if (_Albergo)
                    ////    card.Albergo = uow.GetObjectByKey<AnagraficaCard>((this.lookUpEditAlbergo.EditValue as AnagraficaCard).Oid);
                    //card.Save();

                    Stampa doppia = uow.FindObject<Stampa>(new BinaryOperator("BarCode", stampa.BarCode));
                    if (doppia != null)
                    {
                        stampa.GeneraBarCode(Program.Postazione, ElencoIngressi);

                        doppia = uow.FindObject<Stampa>(new BinaryOperator("BarCode", stampa.BarCode));
                        if (doppia != null)
                        {
                            stampa.GeneraBarCode(Program.Postazione, ElencoIngressi);

                            doppia = uow.FindObject<Stampa>(new BinaryOperator("BarCode", stampa.BarCode));
                            if (doppia != null)
                            {
                                stampa.GeneraBarCode(Program.Postazione, ElencoIngressi);
                            }
                        }
                    }

                    stampa.Save();

                    foreach (Ingresso ingresso in ElencoIngressi)
                    {
                        RigaStampaIngresso rigaingresso = new RigaStampaIngresso(uow);
                        rigaingresso.Ingresso = uow.GetObjectByKey<Ingresso>(ingresso.Oid);
                        rigaingresso.Stampa = stampa;
                        rigaingresso.TotalePersone = 1;
                        rigaingresso.Save();
                    }
                }

                // registra ingressi per QUESTA postazione
                foreach (Stampa item1 in vendita.Stampe)
                {
                    foreach (RigaStampaIngresso item2 in item1.RigheStampaIngresso)
                    {
                        if (VarcoPostazione(item2))
                        {
                            Entrata entrata = new Entrata(uow);
                            entrata.DataOraEntrata = vendita.DataOraStampa;
                            entrata.Quantita = item2.TotalePersone;
                            entrata.RigaStampaIngresso = item2;
                            entrata.Save();

                            item2.TotaleIngressi = item2.TotalePersone;
                            item2.Save();
                        }
                    }
                }

                uow.CommitChanges();

                m_Vendita = this._UnitOfWork.GetObjectByKey<Vendita>(vendita.Oid);
            }

            return true;
        }

        private Variante FindVarianteSingoleOmaggio(UnitOfWork uow, Ingresso myin)
        {
            var ingresso = uow.GetObjectByKey<Ingresso>(myin.Oid);
            foreach (var p in ingresso.Percorsi)
            {
                if (p.Ingressi.Count != 1) continue;
                foreach (var b in p.BigliettiValidi)
                {
                    foreach (var v in b.VariantiValide)
                    {
                        if (!(v.Note ?? "").Contains("[UNIFE]")) continue;
                        if (v.PrezzoAttuale == null) continue;

                        return v;
                    }
                }
            }
            return null;
        }

        private static bool VarcoPostazione(RigaStampaIngresso item2)
        {
            foreach (PostazioneIngresso postazioneIngresso in Program.Postazione.Ingressi)
            {
                if (postazioneIngresso.Tipologia == EnumTipologiaPostazioneIngresso.MarcaturaAutomatica && postazioneIngresso.Ingresso.Oid == item2.Ingresso.Oid)
                    return true;
            }

            return false;
        }

        private void simpleButtonCheck_Click(object sender, EventArgs e)
        {
            string str = this.buttonEditCodice.Text;

            while (str.Length > 6 && str.StartsWith("0"))
            {
                str = str.Substring(1, str.Length - 1);
            }

            Matricola card = _UnitOfWork.FindObject<Matricola>(new BinaryOperator("Codice", str));
            if (card != null)
            {
                this.labelControlSearchResult.Text = string.Format("OK: {0} trovato", str);

                bool valida = true;

                if (card.ValidaDal > DateTime.Today || card.ValidaAl < DateTime.Today)
                {
                    XtraMessageBox.Show("Tessera " + card.Codice + 
                        " valida dal " + card.ValidaDal.ToString("d") + 
                        " al " + card.ValidaAl.ToString("d")
                        , "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valida = false;
                }

                if (valida && !ElencoCard.Contains(card))
                    ElencoCard.Add(card);

                //if (card.Status == EnumStatoCard.Assegnata && card.AssegnataStruttura != null && card.AssegnataStruttura.Oid == Program.Postazione.Struttura.Oid)
                //{
                //    if (!ElencoCard.Contains(card))
                //        ElencoCard.Add(card);
                //}
                //else
                //{
                //    if (card.Status == EnumStatoCard.Emessa)
                //        XtraMessageBox.Show(string.Format("Errore: la card {0} risulta emessa il {1} da {2}.",
                //            card.Codice,
                //            card.Stampa.Vendita.DataOraStampa,
                //            card.Stampa.Vendita.Postazione.Nome
                //            ), "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    else
                //        XtraMessageBox.Show(string.Format("Errore: la card {0} non è vendibile: {1} - {2}.",
                //            card.Codice,
                //            card.Status, card.AssegnataStruttura == null ? "" : card.AssegnataStruttura.Descrizione), "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
            else
            {
                this.labelControlSearchResult.Text = string.Format("Codice {0} NON trovato!", str);
            }

            this.buttonEditCodice.Text = "";
            UpdateInfo();
        }

        private void gridControlElencoCard_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Custom)
            {
                Matricola obj = this.gridViewElencoCard.GetFocusedRow() as Matricola;
                if (obj != null)
                {
                    ElencoCard.Remove(obj);
                    UpdateInfo();
                }
            }
        }

    }
}