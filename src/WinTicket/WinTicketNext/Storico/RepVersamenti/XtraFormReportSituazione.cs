using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WinTicketNext.Storico.RepVersamenti
{
    public partial class XtraFormReportSituazione : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormReportSituazione()
        {
            InitializeComponent();

            this.textEditData.Text = String.Format("Ferrara, {0:d}", DateTime.Now.Date);
            this.memoEdit1.Text = string.Empty;
        }

        public string s1 = string.Empty;
        public string s2 = string.Empty;
        public bool moltipos = false;
        private void simpleButtonReport_Click(object sender, EventArgs e)
        {
            s1 = this.textEditData.Text;
            s2 = this.memoEdit1.Text;
            moltipos = this.checkEditMoltiPos.Checked;

            DialogResult = DialogResult.OK;
        }
    }
}