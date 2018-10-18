namespace WinTicketNext.Storico.RepVersamenti
{
    partial class XtraFormReportSituazione
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
            this.textEditData = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.simpleButtonReport = new DevExpress.XtraEditors.SimpleButton();
            this.checkEditMoltiPos = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditMoltiPos.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEditData
            // 
            this.textEditData.Location = new System.Drawing.Point(72, 12);
            this.textEditData.Name = "textEditData";
            this.textEditData.Size = new System.Drawing.Size(277, 20);
            this.textEditData.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(27, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Data:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(27, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Note:";
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(72, 38);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(387, 119);
            this.memoEdit1.TabIndex = 3;
            // 
            // simpleButtonReport
            // 
            this.simpleButtonReport.Location = new System.Drawing.Point(335, 163);
            this.simpleButtonReport.Name = "simpleButtonReport";
            this.simpleButtonReport.Size = new System.Drawing.Size(124, 52);
            this.simpleButtonReport.TabIndex = 4;
            this.simpleButtonReport.Text = "Genera Report";
            this.simpleButtonReport.Click += new System.EventHandler(this.simpleButtonReport_Click);
            // 
            // checkEditMoltiPos
            // 
            this.checkEditMoltiPos.Location = new System.Drawing.Point(72, 164);
            this.checkEditMoltiPos.Name = "checkEditMoltiPos";
            this.checkEditMoltiPos.Properties.Caption = "Stampa variante per molti POS";
            this.checkEditMoltiPos.Size = new System.Drawing.Size(209, 19);
            this.checkEditMoltiPos.TabIndex = 5;
            // 
            // XtraFormReportSituazione
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 227);
            this.Controls.Add(this.checkEditMoltiPos);
            this.Controls.Add(this.simpleButtonReport);
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.textEditData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XtraFormReportSituazione";
            this.Text = "Report Versamenti";
            ((System.ComponentModel.ISupportInitialize)(this.textEditData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditMoltiPos.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEditData;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonReport;
        private DevExpress.XtraEditors.CheckEdit checkEditMoltiPos;
    }
}