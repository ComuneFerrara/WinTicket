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
    public partial class XtraFormQuietanzaPos : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormQuietanzaPos()
        {
            InitializeComponent();
        }

        private Versamento _versamento = null;
        public void Init(Versamento versamento)
        {
            _versamento = versamento;
            this.spinEditVersamento.Value = _versamento.Pos;
            this.dateEditVersamento.DateTime = _versamento.DataVersamento;

            this.textEditQuietanza.Text = _versamento.Quietanza;
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            _versamento.Quietanza = this.textEditQuietanza.Text;

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}