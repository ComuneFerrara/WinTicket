using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Xpo;
using Musei.Module;
using DevExpress.Data.Filtering;

namespace WinTicketNext.Pivot
{
    public partial class XtraFormLoad : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormLoad()
        {
            InitializeComponent();
        }

        public void Init(string tipo)
        {
            this.xpCollection1.Criteria = new BinaryOperator("Tipo", tipo);

            this.gridView1.BestFitColumns();
        }

        public ConfigurazionePivot target = null;
        private void gridControlElenco_DoubleClick(object sender, EventArgs e)
        {            
            target = this.gridView1.GetFocusedRow() as ConfigurazionePivot;

            if (target != null)
                DialogResult = DialogResult.OK;
        }

        private void gridControlElenco_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Custom)
            {
                e.Handled = true;

                target = this.gridView1.GetFocusedRow() as ConfigurazionePivot;
                if (target != null)
                {
                    string msg = string.Format("Vuoi veramente eleminare la voce: {0}", target.Descrizione);
                    if (XtraMessageBox.Show(msg, "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        target.Delete();

                        this.xpCollection1.Reload();
                    }
                }
            }
        }

    }
}