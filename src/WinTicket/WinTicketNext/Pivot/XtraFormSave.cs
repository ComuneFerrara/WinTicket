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
    public partial class XtraFormSave : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormSave()
        {
            InitializeComponent();
        }

        public void Init(ConfigurazionePivot cfg)
        {
            target = cfg;
            if (target == null)
                this.checkEditSaveNew.Checked = true;
            else
                this.textEdit1.Text = target.Descrizione;

            UpdateInfo();
        }

        private void UpdateInfo()
        {
            if (target != null && !this.checkEditSaveNew.Checked)
                this.labelControlInfo.Text = "Verrà sovrascritta la configurazione precedente: " + target.Descrizione;
            else
                this.labelControlInfo.Text = "Verrà salvata una nuova configurazione";
        }

        public bool SalvaNuovo = false;
        public string SalvaNome = string.Empty;
        public ConfigurazionePivot target = null;

        private void simpleButtonSalva_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                SalvaNome = this.textEdit1.Text;
                SalvaNuovo = this.checkEditSaveNew.Checked;

                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void checkEditSaveNew_CheckedChanged(object sender, EventArgs e)
        {
            UpdateInfo();
        }
    }
}