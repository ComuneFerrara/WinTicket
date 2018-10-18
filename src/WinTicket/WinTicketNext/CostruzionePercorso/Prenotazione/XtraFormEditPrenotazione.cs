using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Musei.Module;

namespace WinTicketNext.CostruzionePercorso.GestionePrenotazione
{
    public partial class XtraFormEditPrenotazione : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormEditPrenotazione()
        {
            InitializeComponent();
        }

        private Prenotazione m_Prenotazione;
        public void Init(Prenotazione prenotazione)
        {
            m_Prenotazione = prenotazione;

            this.textEditIngresso.Text = m_Prenotazione.Ingresso.Descrizione;
            this.dateEditStart.DateTime = m_Prenotazione.StartDate;
            this.textEditNote.Text = m_Prenotazione.Subject;
            this.spinEditPersone.Value = m_Prenotazione.NumeroPersone;
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                m_Prenotazione.StartDate = this.dateEditStart.DateTime;
                m_Prenotazione.StartDate = m_Prenotazione.FixStartDate();

                m_Prenotazione.Subject = this.textEditNote.Text;
                m_Prenotazione.NumeroPersone = (int)this.spinEditPersone.Value;
                m_Prenotazione.Save();

                DialogResult = DialogResult.OK;
            }
        }
    }

}