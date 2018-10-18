using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Musei.Module;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;

namespace WinTicketNext.Storico
{
    public partial class XtraFormAssegnaCards : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormAssegnaCards()
        {
            InitializeComponent();

            if (Program.UtenteCollegato.Amministratore)
            {
                this.simpleButtonEsegui.Text = "ASSEGNA";
            }
            else
            {
                this.lookUpEdit1.EditValue = this.session1.GetObjectByKey<Struttura>(Program.Postazione.Struttura.Oid);
                this.lookUpEdit1.Enabled = false;
                this.simpleButtonEsegui.Text = string.Format("Assegna a: {0}", Program.Postazione.Struttura.Descrizione);
            }
        }

        private void simpleButtonEsegui_Click(object sender, EventArgs e)
        {
            string codice1 = this.textEdit1.Text;
            string codice2 = this.textEdit2.Text;

            if (string.IsNullOrEmpty(codice1) || string.IsNullOrEmpty(codice2))
            {
                XtraMessageBox.Show("Indicare i codici inizio / fine", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Struttura struttura = this.lookUpEdit1.EditValue as Struttura;
            if (struttura == null)
            {
                XtraMessageBox.Show("Indicare la struttura di pertinenza", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Utente utente = this.session1.GetObjectByKey<Utente>(Program.UtenteCollegato.Oid);

            Card c1 = session1.FindObject<Card>(new BinaryOperator("Codice", codice1));
            Card c2 = session1.FindObject<Card>(new BinaryOperator("Codice", codice2));

            if (c1 == null || c2 == null)
            {
                if (Program.UtenteCollegato.Amministratore)
                {
                    XtraMessageBox.Show("Codici non trovati!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    XtraMessageBox.Show("Codici non trovati!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (c1.TipologiaCard != c2.TipologiaCard)
            {
                XtraMessageBox.Show(string.Format("Le tipologie di card sono diverse: {0} / {1}!", c1.TipologiaCard, c2.TipologiaCard), "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cursor saveCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var tutte = new XPCollection<Card>(this.session1, new GroupOperator(new CriteriaOperator[] { 
                new BinaryOperator("Codice", c1.Codice, BinaryOperatorType.GreaterOrEqual),
                new BinaryOperator("Codice", c2.Codice, BinaryOperatorType.LessOrEqual) }));

                bool giafatto = false;
                foreach (var item in tutte)
                {
                    if (item.Status == EnumStatoCard.Assegnata && item.AssegnataStruttura != null && item.AssegnataStruttura != struttura) giafatto = true;
                    if (item.Status == EnumStatoCard.Emessa) giafatto = true;
                    if (item.Status == EnumStatoCard.Soppressa) giafatto = true;
                }

                if (giafatto && !Program.UtenteCollegato.Amministratore)
                {
                    XtraMessageBox.Show("Impossibile prosegure: almeno una card è già stata assegnata (od emessa).", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (var item in tutte)
                {
                    item.AssegnataStruttura = struttura;
                    item.AssegnataUtente = utente;
                    item.AssegnataIl = DateTime.Now.Date;
                    if (item.Status == EnumStatoCard.Nuova)
                        item.Status = EnumStatoCard.Assegnata;

                    item.Save();
                }
            }
            finally
            {
                Cursor.Current = saveCursor;
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Struttura struttura = this.lookUpEdit1.EditValue as Struttura;
            if (struttura == null)
                this.simpleButtonEsegui.Text = "ASSEGNA";
            else
                this.simpleButtonEsegui.Text = string.Format("Assegna a: {0}", struttura.Descrizione);
        }

    }
}