namespace WinTicketNext.Storico.Rep07
{
    partial class XtraFormReport07
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
            this.dateEditInizio = new DevExpress.XtraEditors.DateEdit();
            this.dateEditFine = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonReport = new DevExpress.XtraEditors.SimpleButton();
            this.unitOfWork1 = new DevExpress.Xpo.UnitOfWork(this.components);
            this.memoEditInfo = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInizio.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInizio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFine.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditInfo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dateEditInizio
            // 
            this.dateEditInizio.EditValue = null;
            this.dateEditInizio.Location = new System.Drawing.Point(144, 39);
            this.dateEditInizio.Name = "dateEditInizio";
            this.dateEditInizio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditInizio.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditInizio.Size = new System.Drawing.Size(100, 20);
            this.dateEditInizio.TabIndex = 0;
            // 
            // dateEditFine
            // 
            this.dateEditFine.EditValue = null;
            this.dateEditFine.Location = new System.Drawing.Point(144, 66);
            this.dateEditFine.Name = "dateEditFine";
            this.dateEditFine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFine.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditFine.Size = new System.Drawing.Size(100, 20);
            this.dateEditFine.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Data Inizio:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(25, 69);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Data Fine:";
            // 
            // simpleButtonReport
            // 
            this.simpleButtonReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonReport.Image = global::WinTicketNext.Properties.Resources.printer;
            this.simpleButtonReport.Location = new System.Drawing.Point(314, 302);
            this.simpleButtonReport.Name = "simpleButtonReport";
            this.simpleButtonReport.Size = new System.Drawing.Size(145, 56);
            this.simpleButtonReport.TabIndex = 4;
            this.simpleButtonReport.Text = "Anteprima Report";
            this.simpleButtonReport.Click += new System.EventHandler(this.simpleButtonReport_Click);
            // 
            // unitOfWork1
            // 
            this.unitOfWork1.TrackPropertiesModifications = false;
            // 
            // memoEditInfo
            // 
            this.memoEditInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memoEditInfo.Location = new System.Drawing.Point(144, 92);
            this.memoEditInfo.Name = "memoEditInfo";
            this.memoEditInfo.Size = new System.Drawing.Size(315, 204);
            this.memoEditInfo.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(25, 94);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(27, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Note:";
            // 
            // XtraFormReport07
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 372);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.memoEditInfo);
            this.Controls.Add(this.simpleButtonReport);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dateEditFine);
            this.Controls.Add(this.dateEditInizio);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XtraFormReport07";
            this.Text = "Report 07 (MyFE)";
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInizio.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInizio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFine.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditInfo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dateEditInizio;
        private DevExpress.XtraEditors.DateEdit dateEditFine;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonReport;
        private DevExpress.Xpo.UnitOfWork unitOfWork1;
        private DevExpress.XtraEditors.MemoEdit memoEditInfo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}