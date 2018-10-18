using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;
using PreventWebServices;

namespace WinTicketNext.CostruzionePercorso
{
    public partial class XtraFormDownloadPrevent : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormDownloadPrevent()
        {
            InitializeComponent();

            GetInfo();
        }

        private void linkLabelWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"http://biglietteria.comune.fe.it");
        }

        private void GetInfo()
        {
            if (!string.IsNullOrEmpty(this.buttonEditCodice.Text))
            {
                XtraMessageBox.Show(string.Format("Non è possibile caricare la prenotazione {0}", this.buttonEditCodice.Text), "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor saveCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                prevent.get.Out obj = RichiestaGet.MakeGet();
                if (obj != null)
                {
                    this.labelControlInfo1.Text = string.Format("Codice: {0}", obj.NumeroPrenotazione);
                    this.labelControlInfo2.Text = string.Format("Denominazione: {0} (pax. {1})", obj.Denominazione, obj.PaxTotali);
                }
                else
                {
                    if (RichiestaGet.UltimoErrore != null)
                    {
                        this.labelControlInfo1.Text = string.Format("Error Code {0}", RichiestaGet.UltimoErrore.ReturnCode);
                        this.labelControlInfo2.Text = RichiestaGet.UltimoErrore.DescrizioneErrore;
                    }
                    else
                    {
                        this.labelControlInfo1.Text = string.Empty;
                        this.labelControlInfo2.Text = string.Empty;
                    }
                }
            }
            finally
            {
                Cursor.Current = saveCursor;
            }
        }

        private void buttonEditCodice_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GetInfo();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.buttonEditCodice.Text))
            {
                XtraMessageBox.Show(string.Format("Non è possibile caricare la prenotazione {0}", this.buttonEditCodice.Text), "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}