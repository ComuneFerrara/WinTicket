using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WinTicketNext.Properties;
using DevExpress.Xpo;
using Musei.Module;
using DevExpress.Data.Filtering;
using PreventWebServices;

namespace WinTicketNext
{
    public partial class XtraFormUserLogon : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormUserLogon()
        {
            InitializeComponent();

            this.textEditNome.Text = Settings.Default.LastUserName;

            textEditNome_ButtonClick(null, null);
        }

        private static bool Esiste(string user)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Utente utente = uow.FindObject<Utente>(new BinaryOperator("AdUsername", user));
                return utente != null;
            }
        }

        private void simpleButtonLogon_Click(object sender, EventArgs e)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                if (this.textEditNome.Properties.ReadOnly)
                {
                    string user = String.Format(@"{0}\{1}", Environment.UserDomainName, Environment.UserName);
                    Utente utente = uow.FindObject<Utente>(new BinaryOperator("AdUsername", user));
                    if (utente != null)
                    {
                        utente.LastLogonTry = DateTime.Now;
                        utente.LastLogon = DateTime.Now;
                        utente.ErroriPassword = 0;
                        utente.Save();

                        // ok 
                        Settings.Default.LastUserName = this.textEditNome.Text;
                        Settings.Default.Save();

                        Program.UtenteCollegato = utente;

                        MuseiBase.CurrentUser = utente;

                        WsConfig.Username = utente.Username;
                        WsConfig.Password = utente.Password;

                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        // nome utente non trovato
                        XtraMessageBox.Show("Utente non trovato !", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Utente utente = uow.FindObject<Utente>(new BinaryOperator("Username", this.textEditNome.Text));
                    if (utente != null)
                    {
                        if (utente.Bloccato(DateTime.Now))
                        {
                            // utente bloccato
                            if (utente.ErroriPassword < 10)
                                XtraMessageBox.Show("Troppi errori sulla password. Riprova fra 10 minuti.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                                XtraMessageBox.Show("Troppi errori sulla password. Utente BLOCCATO !", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            utente.LastLogonTry = DateTime.Now;
                            utente.Save();
                        }
                        else
                        {
                            if (utente.Password == this.textEditPassword.Text)
                            {
                                utente.LastLogonTry = DateTime.Now;
                                utente.LastLogon = DateTime.Now;
                                utente.ErroriPassword = 0;
                                utente.Save();

                                // ok 
                                Settings.Default.LastUserName = this.textEditNome.Text;
                                Settings.Default.Save();

                                Program.UtenteCollegato = utente;

                                MuseiBase.CurrentUser = utente;

                                WsConfig.Username = utente.Username;
                                WsConfig.Password = utente.Password;

                                DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                // password errata
                                XtraMessageBox.Show("Password errata !", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                utente.LastLogonTry = DateTime.Now;
                                utente.ErroriPassword++;
                                utente.Save();
                            }
                        }
                    }
                    else
                    {
                        // nome utente non trovato
                        XtraMessageBox.Show("Nome utente non trovato !", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                uow.CommitChanges();
            }
        }

        private void textEditNome_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.textEditNome.Properties.ReadOnly)
            {
                this.textEditNome.Properties.ReadOnly = false;
                this.textEditNome.Properties.UseParentBackground = false;
                this.textEditNome.Text = string.Empty;

                this.textEditPassword.Properties.ReadOnly = false;
                this.textEditPassword.Properties.UseParentBackground = false;
                this.textEditPassword.Text = string.Empty;
            }
            else
            {
                string user = String.Format(@"{0}\{1}", Environment.UserDomainName, Environment.UserName);

                if (Esiste(user))
                {
                    this.textEditNome.Properties.ReadOnly = true;
                    this.textEditNome.Properties.UseParentBackground = true;
                    this.textEditNome.Text = user;

                    this.textEditPassword.Properties.ReadOnly = true;
                    this.textEditPassword.Properties.UseParentBackground = true;
                    this.textEditPassword.Text = user;
                }
            }
        }
    }
}