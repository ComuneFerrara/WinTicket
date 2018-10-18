using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WinTicketNext
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            this.labelVersione.Text = string.Format("Ver. {0}", MostraVersione());
        }

        private bool _InitMain = true;
        private bool _InitSync = false;

        public Splash NoInit()
        {
            _InitMain = false;
            _InitSync = true;

            return this;
        }

        private static string MostraVersione()
        {
            string versione = "";
            try
            {
                versione = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion + " C";
            }
            catch (Exception)
            {
                versione = Application.ProductVersion + " L";
            }

            return versione;
        }

        private void backgroundWorkerMain_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (_InitMain) Program.InitMain();
                if (_InitSync) TryToSync("Postazione od Utente non trovato!");
            }
            catch (Exception ex)
            {
                // try to sync
                TryToSync(ex.Message);
            }
        }

        public static void TryToSync(string ex)
        {
            try
            {
                MergeSyncLib.ReplicamenteInfo ri = new MergeSyncLib.ReplicamenteInfo();
                MergeSyncLib.Replicamente rx = new MergeSyncLib.Replicamente(ri);
                bool result = rx.Go("(local)\\SQLEXPRESS", "MuseiXafRev1locale");

                if (!result)
                {
                    XtraMessageBox.Show("Errore: " + ex, "ERRORE ON START", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex2)
            {
                XtraMessageBox.Show("Errore: " + ex2.Message, "ERRORE ON START", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorkerMain_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void Splash_Shown(object sender, EventArgs e)
        {
            this.backgroundWorkerMain.RunWorkerAsync();
        }
    }
}
