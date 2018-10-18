namespace WinTicketNext.Storico.RepVersamenti
{
    partial class XtraFormQuietanzaPos
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
            this.textEditQuietanza = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditVersamento = new DevExpress.XtraEditors.SpinEdit();
            this.simpleButtonOk = new DevExpress.XtraEditors.SimpleButton();
            this.dateEditVersamento = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.textEditQuietanza.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditVersamento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditVersamento.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditVersamento.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEditQuietanza
            // 
            this.textEditQuietanza.Location = new System.Drawing.Point(85, 71);
            this.textEditQuietanza.Name = "textEditQuietanza";
            this.textEditQuietanza.Size = new System.Drawing.Size(200, 20);
            this.textEditQuietanza.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 74);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(53, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Quietanza:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 42);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Versamento:";
            // 
            // spinEditVersamento
            // 
            this.spinEditVersamento.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditVersamento.Location = new System.Drawing.Point(85, 39);
            this.spinEditVersamento.Name = "spinEditVersamento";
            this.spinEditVersamento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditVersamento.Properties.DisplayFormat.FormatString = "c";
            this.spinEditVersamento.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEditVersamento.Properties.EditFormat.FormatString = "c";
            this.spinEditVersamento.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEditVersamento.Properties.ReadOnly = true;
            this.spinEditVersamento.Size = new System.Drawing.Size(100, 20);
            this.spinEditVersamento.TabIndex = 3;
            // 
            // simpleButtonOk
            // 
            this.simpleButtonOk.Location = new System.Drawing.Point(199, 116);
            this.simpleButtonOk.Name = "simpleButtonOk";
            this.simpleButtonOk.Size = new System.Drawing.Size(86, 29);
            this.simpleButtonOk.TabIndex = 4;
            this.simpleButtonOk.Text = "Conferma";
            this.simpleButtonOk.Click += new System.EventHandler(this.simpleButtonOk_Click);
            // 
            // dateEditVersamento
            // 
            this.dateEditVersamento.EditValue = null;
            this.dateEditVersamento.Location = new System.Drawing.Point(85, 13);
            this.dateEditVersamento.Name = "dateEditVersamento";
            this.dateEditVersamento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditVersamento.Properties.ReadOnly = true;
            this.dateEditVersamento.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditVersamento.Size = new System.Drawing.Size(100, 20);
            this.dateEditVersamento.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 16);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(27, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Data:";
            // 
            // XtraFormQuietanzaPos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 170);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.dateEditVersamento);
            this.Controls.Add(this.simpleButtonOk);
            this.Controls.Add(this.spinEditVersamento);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.textEditQuietanza);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XtraFormQuietanzaPos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quietanza Versamento Pos";
            ((System.ComponentModel.ISupportInitialize)(this.textEditQuietanza.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditVersamento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditVersamento.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditVersamento.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEditQuietanza;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SpinEdit spinEditVersamento;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOk;
        private DevExpress.XtraEditors.DateEdit dateEditVersamento;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}