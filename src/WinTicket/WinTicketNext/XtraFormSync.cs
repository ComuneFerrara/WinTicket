using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WinTicketNext.Sync;
using Musei.Module;
using DevExpress.Xpo;

namespace WinTicketNext
{
    public partial class XtraFormSync : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormSync()
        {
            InitializeComponent();

            this.simpleButtonChiusura.Enabled = false;
            this.simpleButtonForza.Enabled = false;
        }

        private SyncHelper _Sync = null;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_Sync == null)
            {
                this.simpleButtonChiusura.Enabled = false;
                this.simpleButtonForza.Enabled = false;
                this.marqueeProgressBarControl1.Properties.Stopped = false;

                _Sync = new SyncHelper();
                _Sync.GoSync();
            }
            else
            {
                if (_Sync != null && _Sync.SyncFinished && !_Sync.ResultProcessed)
                {
                    _Sync.End();

                    if (_Sync.Result)
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        // retry or quit
                        this.marqueeProgressBarControl1.Properties.Stopped = true;
                        this.simpleButtonChiusura.Enabled = true;
                        this.simpleButtonForza.Enabled = true;

                        XtraMessageBox.Show("Errore durante la chiusura del programma.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
           }
        }

        private void simpleButtonChiusura_Click(object sender, EventArgs e)
        {
            _Sync = null;
        }

        private void simpleButtonForza_Click(object sender, EventArgs e)
        {
            using (Session session = new Session())
            {
                Messaggio msg = new Messaggio(session);
                msg.Data = DateTime.Now;
                msg.Oggetto = String.Format("FORZATA CHIUSURA {0}", Program.Postazione.Nome);
                msg.TestoEsteso = string.Empty;
                msg.Autore = session.GetObjectByKey<Utente>(Program.UtenteCollegato.Oid);
                msg.Tipologia = EnumTipoMessaggio.SyncDelay;
                msg.Save();
            }

            DialogResult = DialogResult.OK;
        }
    }
}