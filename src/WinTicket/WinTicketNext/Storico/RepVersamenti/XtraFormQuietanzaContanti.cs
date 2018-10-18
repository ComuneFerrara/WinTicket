using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Musei.Module;

namespace WinTicketNext.Storico.RepVersamenti
{
    public partial class XtraFormQuietanzaContanti : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormQuietanzaContanti()
        {
            InitializeComponent();
        }

        private Versamento _versamento = null;
        public void Init(Versamento versamento)
        {
            _versamento = versamento;

            this.dateEditInizio.DateTime = _versamento.InizioPeriodo;
            this.dateEditFine.DateTime = _versamento.FinePeriodo;
            this.spinEditVersamento.Value = _versamento.Incassi;
            this.spinEditPosAltri.Value = _versamento.PosAltriEnti;
            this.spinEditConAltri.Value = _versamento.ContanteAltriEnti;
            this.spinEditTotale.Value = _versamento.Incassi - _versamento.ContanteAltriEnti;

            this.textEditQuietanza.Text = _versamento.Quietanza;
            this.dateEditVersamento.DateTime = _versamento.DataVersamento;
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            _versamento.Quietanza = this.textEditQuietanza.Text;
            _versamento.DataVersamento = this.dateEditVersamento.DateTime;

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}