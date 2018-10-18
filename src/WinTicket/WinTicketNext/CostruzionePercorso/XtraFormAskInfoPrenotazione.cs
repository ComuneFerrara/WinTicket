using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WinTicketNext.CostruzionePercorso.GestionePrenotazione;
using PreventWebServices;

namespace WinTicketNext.CostruzionePercorso
{
    public partial class XtraFormAskInfoPrenotazione : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormAskInfoPrenotazione()
        {
            InitializeComponent();
            timer1_Tick(null, null);
        }

        private PrenotazioneComplessiva m_Prenotazione;
        public void Init(PrenotazioneComplessiva prenotazione)
        {
            m_Prenotazione = prenotazione;

            this.textEditDescrizione.Text = m_Prenotazione.RiferimentoVendita;
            if (m_Prenotazione.PreventObj != null)
            {
                this.labelControl1.Text = "Codice Prevent: " + m_Prenotazione.PreventObj.NumeroPrenotazione;
                if (string.IsNullOrEmpty(m_Prenotazione.RiferimentoVendita))
                    this.textEditDescrizione.Text = m_Prenotazione.PreventObj.Denominazione;
            }
            else
            {
                this.labelControl1.Text = "Inserire un riferimento per questa prenotazione.";
            }
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            if (this.dxValidationProvider1.Validate())
            {
                this.m_Prenotazione.RiferimentoVendita = this.textEditDescrizione.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GestoreCalendario.RichiesteInCoda() == 0)
            {
                this.simpleButtonOk.Enabled = true;
                this.simpleButtonOk.Text = "Conferma";

                if (!layoutControlItemProgress.IsHidden)
                    this.layoutControlItemProgress.HideToCustomization();
            }
            else
            {
                this.simpleButtonOk.Enabled = false;
                this.simpleButtonOk.Text = String.Format("Attendere {0}", GestoreCalendario.RichiesteInCoda());

                if (layoutControlItemProgress.IsHidden)
                    this.layoutControlItemProgress.RestoreFromCustomization(emptySpaceItem2, DevExpress.XtraLayout.Utils.InsertType.Left);
            }
        }
    }
}