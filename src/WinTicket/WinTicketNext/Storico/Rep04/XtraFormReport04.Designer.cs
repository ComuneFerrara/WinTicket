namespace WinTicketNext.Storico.Rep04
{
    partial class XtraFormReport04
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
            this.simpleButtonReport = new DevExpress.XtraEditors.SimpleButton();
            this.unitOfWork1 = new DevExpress.Xpo.UnitOfWork();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditInizio = new DevExpress.XtraEditors.DateEdit();
            this.dateEditFine = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.memoEditInfo = new DevExpress.XtraEditors.MemoEdit();
            this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonMusei = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSpazi = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInizio.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInizio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFine.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButtonReport
            // 
            this.simpleButtonReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonReport.Image = global::WinTicketNext.Properties.Resources.printer;
            this.simpleButtonReport.Location = new System.Drawing.Point(473, 611);
            this.simpleButtonReport.Name = "simpleButtonReport";
            this.simpleButtonReport.Size = new System.Drawing.Size(145, 39);
            this.simpleButtonReport.TabIndex = 4;
            this.simpleButtonReport.Text = "Anteprima Report";
            this.simpleButtonReport.Click += new System.EventHandler(this.simpleButtonReport_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(25, 44);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(19, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Dal:";
            // 
            // dateEditInizio
            // 
            this.dateEditInizio.EditValue = null;
            this.dateEditInizio.Location = new System.Drawing.Point(144, 41);
            this.dateEditInizio.Name = "dateEditInizio";
            this.dateEditInizio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditInizio.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditInizio.Size = new System.Drawing.Size(100, 20);
            this.dateEditInizio.TabIndex = 7;
            // 
            // dateEditFine
            // 
            this.dateEditFine.EditValue = null;
            this.dateEditFine.Location = new System.Drawing.Point(144, 67);
            this.dateEditFine.Name = "dateEditFine";
            this.dateEditFine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFine.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditFine.Size = new System.Drawing.Size(100, 20);
            this.dateEditFine.TabIndex = 8;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 70);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(13, 13);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Al:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(25, 380);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(27, 13);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "Note:";
            // 
            // memoEditInfo
            // 
            this.memoEditInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memoEditInfo.Location = new System.Drawing.Point(144, 377);
            this.memoEditInfo.Name = "memoEditInfo";
            this.memoEditInfo.Size = new System.Drawing.Size(474, 228);
            this.memoEditInfo.TabIndex = 11;
            // 
            // checkedListBoxControl1
            // 
            this.checkedListBoxControl1.CheckOnClick = true;
            this.checkedListBoxControl1.DisplayMember = "Descrizione";
            this.checkedListBoxControl1.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.checkedListBoxControl1.HotTrackItems = true;
            this.checkedListBoxControl1.Location = new System.Drawing.Point(144, 93);
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.Size = new System.Drawing.Size(474, 278);
            this.checkedListBoxControl1.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.checkedListBoxControl1.TabIndex = 12;
            this.checkedListBoxControl1.ValueMember = "This";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(25, 93);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(42, 13);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "Ingressi:";
            // 
            // simpleButtonMusei
            // 
            this.simpleButtonMusei.Location = new System.Drawing.Point(25, 133);
            this.simpleButtonMusei.Name = "simpleButtonMusei";
            this.simpleButtonMusei.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonMusei.TabIndex = 14;
            this.simpleButtonMusei.Text = "Musei";
            this.simpleButtonMusei.Click += new System.EventHandler(this.simpleButtonMusei_Click);
            // 
            // simpleButtonSpazi
            // 
            this.simpleButtonSpazi.Location = new System.Drawing.Point(25, 162);
            this.simpleButtonSpazi.Name = "simpleButtonSpazi";
            this.simpleButtonSpazi.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonSpazi.TabIndex = 15;
            this.simpleButtonSpazi.Text = "Spazi Esp.";
            this.simpleButtonSpazi.Click += new System.EventHandler(this.simpleButtonSpazi_Click);
            // 
            // XtraFormReport04
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 662);
            this.Controls.Add(this.simpleButtonSpazi);
            this.Controls.Add(this.simpleButtonMusei);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.checkedListBoxControl1);
            this.Controls.Add(this.memoEditInfo);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dateEditFine);
            this.Controls.Add(this.dateEditInizio);
            this.Controls.Add(this.simpleButtonReport);
            this.Controls.Add(this.labelControl2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XtraFormReport04";
            this.Text = "Report 04";
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInizio.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInizio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFine.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButtonReport;
        private DevExpress.Xpo.UnitOfWork unitOfWork1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateEditInizio;
        private DevExpress.XtraEditors.DateEdit dateEditFine;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.MemoEdit memoEditInfo;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton simpleButtonMusei;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSpazi;
    }
}