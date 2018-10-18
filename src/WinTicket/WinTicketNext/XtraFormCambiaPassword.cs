using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Xpo;
using Musei.Module;

namespace WinTicketNext
{
    public partial class XtraFormCambiaPassword : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormCambiaPassword()
        {
            InitializeComponent();
        }

        private void simpleButtonCambia_Click(object sender, EventArgs e)
        {
            Session session = new Session();

            if (!string.IsNullOrEmpty(this.textEdit2.Text) && this.textEdit2.Text == this.textEdit3.Text && this.textEdit2.Text.Length >= 6)
            {
                Utente user = session.GetObjectByKey<Utente>(Program.UtenteCollegato.Oid);
                if (user != null)
                {
                    user.Password = this.textEdit2.Text;
                    user.Save();

                    XtraMessageBox.Show("Password cambiata !", "Conferma", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    XtraMessageBox.Show("Vecchia password errata!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                XtraMessageBox.Show("Verifica della nuova password non superata (inserire due volte la nuova password di almeno 6 caratteri) !", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}