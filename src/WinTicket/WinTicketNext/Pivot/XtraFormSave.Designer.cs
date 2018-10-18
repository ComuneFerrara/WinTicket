namespace WinTicketNext.Pivot
{
    partial class XtraFormSave
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.simpleButtonSalva = new DevExpress.XtraEditors.SimpleButton();
            this.groupControlSave = new DevExpress.XtraEditors.GroupControl();
            this.checkEditSaveNew = new DevExpress.XtraEditors.CheckEdit();
            this.labelControlInfo = new DevExpress.XtraEditors.LabelControl();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlSave)).BeginInit();
            this.groupControlSave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSaveNew.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(5, 25);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(727, 20);
            this.textEdit1.TabIndex = 1;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.textEdit1, conditionValidationRule1);
            // 
            // simpleButtonSalva
            // 
            this.simpleButtonSalva.Location = new System.Drawing.Point(644, 51);
            this.simpleButtonSalva.Name = "simpleButtonSalva";
            this.simpleButtonSalva.Size = new System.Drawing.Size(88, 37);
            this.simpleButtonSalva.TabIndex = 2;
            this.simpleButtonSalva.Text = "Salva";
            this.simpleButtonSalva.Click += new System.EventHandler(this.simpleButtonSalva_Click);
            // 
            // groupControlSave
            // 
            this.groupControlSave.Controls.Add(this.checkEditSaveNew);
            this.groupControlSave.Controls.Add(this.labelControlInfo);
            this.groupControlSave.Controls.Add(this.simpleButtonSalva);
            this.groupControlSave.Controls.Add(this.textEdit1);
            this.groupControlSave.Location = new System.Drawing.Point(12, 12);
            this.groupControlSave.Name = "groupControlSave";
            this.groupControlSave.Size = new System.Drawing.Size(737, 93);
            this.groupControlSave.TabIndex = 3;
            this.groupControlSave.Text = "Salva";
            // 
            // checkEditSaveNew
            // 
            this.checkEditSaveNew.Location = new System.Drawing.Point(6, 69);
            this.checkEditSaveNew.Name = "checkEditSaveNew";
            this.checkEditSaveNew.Properties.Caption = "Salva come nuova configurazione";
            this.checkEditSaveNew.Size = new System.Drawing.Size(226, 19);
            this.checkEditSaveNew.TabIndex = 4;
            this.checkEditSaveNew.CheckedChanged += new System.EventHandler(this.checkEditSaveNew_CheckedChanged);
            // 
            // labelControlInfo
            // 
            this.labelControlInfo.Location = new System.Drawing.Point(6, 52);
            this.labelControlInfo.Name = "labelControlInfo";
            this.labelControlInfo.Size = new System.Drawing.Size(63, 13);
            this.labelControlInfo.TabIndex = 3;
            this.labelControlInfo.Text = "labelControl1";
            // 
            // XtraFormSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 118);
            this.Controls.Add(this.groupControlSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XtraFormSave";
            this.Text = "Salva Configurazione";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlSave)).EndInit();
            this.groupControlSave.ResumeLayout(false);
            this.groupControlSave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSaveNew.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSalva;
        private DevExpress.XtraEditors.GroupControl groupControlSave;
        private DevExpress.XtraEditors.LabelControl labelControlInfo;
        private DevExpress.XtraEditors.CheckEdit checkEditSaveNew;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}