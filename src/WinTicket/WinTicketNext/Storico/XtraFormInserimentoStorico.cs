using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Musei.Module;
using DevExpress.Data.Filtering;
using WinTicketNext.CostruzionePercorso.GestionePrenotazione;

namespace WinTicketNext.Storico
{
    public partial class XtraFormInserimentoStorico : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormInserimentoStorico()
        {
            InitializeComponent();

            this.dateEditData.DateTime = DateTime.Now.Date;
            this.timeEditOra.Time = new DateTime(2011, 1, 1);
            this.spinEditQta.Value = 1;
            this.imageComboBoxEditIncasso.Properties.Items.AddEnum(typeof(EnumIncasso));
            this.imageComboBoxEditIncasso.EditValue = EnumIncasso.Contanti;

            this.lookUpEdit1.EditValue = this.unitOfWork1.GetObjectByKey<Postazione>(Program.Postazione.Oid);
        }

        private DateTime DateStart { get; set; }
        private DateTime DateEnd { get; set; }

        private void lookUpEditPercorso_EditValueChanged(object sender, EventArgs e)
        {
            Percorso percorso = this.lookUpEditPercorso.EditValue as Percorso;
            if (percorso != null)
            {
                List<Variante> elenco = new List<Variante>();

                this.lookUpEditVariante.EditValue = null;
                foreach (Biglietto item in percorso.BigliettiValidi)
                {
                    elenco.AddRange(item.VariantiValide);
                }

                this.lookUpEditVariante.Properties.DataSource = elenco;
                if (elenco.Count > 0)
                    this.lookUpEditVariante.EditValue = elenco[0];
            }
        }

        private void lookUpEditTitolo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                this.lookUpEditTitolo.EditValue = null;
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            Variante variante = this.lookUpEditVariante.EditValue as Variante;
            Titolo titolo = this.lookUpEditTitolo.EditValue as Titolo;
            Postazione postazione = this.lookUpEdit1.EditValue as Postazione;
            int quantita = (int)this.spinEditQta.Value;
            DateTime dataVendita = this.dateEditData.DateTime;

            if (dataVendita > DateEnd || dataVendita < DateStart)
            {
                this.dateEditData.ErrorText = string.Format("Deve essere compresa fra {0:g} e {1:g}", DateStart, DateEnd);
                return;
            }

            if (dataVendita > DateTime.Today)
            {
                this.dateEditData.ErrorText = string.Format("Non può essere nel futuro ...");
                return;
            }

            if ((DateTime.Today - dataVendita).TotalDays > 240)
            {
                this.dateEditData.ErrorText = string.Format("Non può essere oltre 8 mesi indietro");
                return;
            }

            if (dataVendita.Year <= 2013)
            {
                this.dateEditData.ErrorText = string.Format("Non può essere nel 2013 o prima");
                return;
            }

            if (variante != null && postazione != null)
            {
                if (!variante.Biglietto.IsAttrib(Biglietto.STR_BIGLIETTO_STORICO))
                {
                    if (dataVendita.Date > new DateTime(2011, 6, 1))
                    {
                        XtraMessageBox.Show("Data deve essere precedente a giugno 2011.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (variante.Biglietto.Percorso.Ingressi.Count > 1)
                {
                    XtraMessageBox.Show("Non biglietti cumulativi", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Ingresso ingresso = variante.Biglietto.Percorso.Ingressi[0];

                    Vendita vendita = new Vendita(this.unitOfWork1);
                    vendita.DataContabile = dataVendita.Date;
                    vendita.DataOraStampa = dataVendita.Add(this.timeEditOra.Time.TimeOfDay);
                    vendita.Incasso = (EnumIncasso)this.imageComboBoxEditIncasso.EditValue;
                    vendita.Postazione = postazione;
                    vendita.Struttura = ingresso.Struttura;
                    vendita.TotaleImporto = variante.PrezzoAttuale.Prezzo * quantita;
                    vendita.TotalePersone = quantita;
                    vendita.Utente = this.unitOfWork1.GetObjectByKey<Utente>(Program.UtenteCollegato.Oid);
                    vendita.CodiceLeggibile = Vendita.NuovoCodiceVendita();
                    vendita.Save();

                    RigaVenditaVariante riga = new RigaVenditaVariante(this.unitOfWork1);
                    riga.PrezzoTotale = vendita.TotaleImporto;
                    riga.PrezzoUnitario = variante.PrezzoAttuale.Prezzo;
                    riga.Quantita = quantita;
                    riga.Titolo = titolo;
                    riga.Variante = variante;
                    riga.Vendita = vendita;
                    riga.Save();

                    Stampa stampa = new Stampa(this.unitOfWork1);
                    stampa.FineValidita = vendita.DataContabile;
                    stampa.InizioValidita = vendita.DataContabile;
                    stampa.ImportoTotale = vendita.TotaleImporto;
                    stampa.Quantita = quantita;
                    stampa.Vendita = vendita;
                    stampa.Save();

                    stampa.GeneraBarCode(Program.Postazione, new List<Ingresso>());
                    stampa.Save();

                    RigaStampaIngresso rigastampa = new RigaStampaIngresso(this.unitOfWork1);
                    rigastampa.Ingresso = ingresso;
                    rigastampa.Stampa = stampa;
                    rigastampa.TotaleIngressi = quantita;
                    rigastampa.TotalePersone = quantita;
                    rigastampa.Save();

                    Entrata entrata = new Entrata(this.unitOfWork1);
                    entrata.DataOraEntrata = vendita.DataOraStampa;
                    entrata.Quantita = quantita;
                    entrata.RigaStampaIngresso = rigastampa;
                    entrata.Save();

                    this.unitOfWork1.CommitChanges();

                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            else
                XtraMessageBox.Show("Selezionare Variante e Postazione", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal void Init(Ingresso ingresso, DateTime start, DateTime end)
        {
            DateStart = start;
            DateEnd = end;

            this.dateEditData.DateTime = start;

            this.xpCollectionPercorso.Criteria = CriteriaOperator.Parse("Ingressi[Oid=?]", ingresso.Oid);
            if (this.xpCollectionPercorso.Count > 0)
                this.lookUpEditPercorso.EditValue = this.xpCollectionPercorso[0];
        }

        private void lookUpEditVariante_EditValueChanged(object sender, EventArgs e)
        {
            this.lookUpEditTitolo.EditValue = null;

            Variante variante = this.lookUpEditVariante.EditValue as Variante;
            if (variante != null)
            {
                this.lookUpEditTitolo.Properties.DataSource = variante.ElencoTitoli;
            }
        }
    }
}