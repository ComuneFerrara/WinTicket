using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Musei.Module;

namespace WinTicketNext.CostruzionePercorso
{
    public partial class XtraFormCheckRegola : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormCheckRegola()
        {
            InitializeComponent();
        }

        private void checkEditIgnora_CheckedChanged(object sender, EventArgs e)
        {
            this.simpleButtonProsegui.Enabled = this.checkEditIgnora.Checked;
        }

        private void simpleButtonAnnulla_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void simpleButtonProsegui_Click(object sender, EventArgs e)
        {
            if (this.checkEditIgnora.Checked)
                this.DialogResult = System.Windows.Forms.DialogResult.Ignore;
        }

        internal void Init(EventoParticolare eventoParticolare)
        {
            this.labelControl1.Text = String.Format("Alcuni profili non rispettano le regole immesse: dal {0} al {1}: <b>{2}</b>", 
                eventoParticolare.DataOraInizio,
                eventoParticolare.DataOraFine,
                eventoParticolare.Descrizione);

            this.labelControl2.Text = eventoParticolare.DescrizioneEstesa;
        }
    }
}