namespace WinTicketNext.Storico.Rep03b
{
    partial class XtraFormReport03b
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
            this.simpleButtonReport = new DevExpress.XtraEditors.SimpleButton();
            this.unitOfWork1 = new DevExpress.Xpo.UnitOfWork(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditAnno = new DevExpress.XtraEditors.SpinEdit();
            this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.memoEditInfo = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.checkedListBoxControl2 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditAnno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButtonReport
            // 
            this.simpleButtonReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonReport.Image = global::WinTicketNext.Properties.Resources.printer;
            this.simpleButtonReport.Location = new System.Drawing.Point(437, 569);
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
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(25, 14);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(29, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Anno:";
            // 
            // spinEditAnno
            // 
            this.spinEditAnno.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditAnno.Location = new System.Drawing.Point(144, 11);
            this.spinEditAnno.Name = "spinEditAnno";
            this.spinEditAnno.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditAnno.Properties.IsFloatValue = false;
            this.spinEditAnno.Properties.Mask.EditMask = "N00";
            this.spinEditAnno.Size = new System.Drawing.Size(100, 20);
            this.spinEditAnno.TabIndex = 7;
            // 
            // checkedListBoxControl1
            // 
            this.checkedListBoxControl1.CheckOnClick = true;
            this.checkedListBoxControl1.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.checkedListBoxControl1.HotTrackItems = true;
            this.checkedListBoxControl1.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(1, "Gennaio", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(2, "Febbraio", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(3, "Marzo", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(4, "Aprile", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(5, "Maggio", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(6, "Giugno", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(7, "Luglio", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(8, "Agosto", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(9, "Settembre", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(10, "Ottobre", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(11, "Novembre", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(12, "Dicembre", System.Windows.Forms.CheckState.Checked)});
            this.checkedListBoxControl1.Location = new System.Drawing.Point(144, 37);
            this.checkedListBoxControl1.MultiColumn = true;
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.Size = new System.Drawing.Size(305, 115);
            this.checkedListBoxControl1.TabIndex = 8;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(25, 13);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Mesi:";
            // 
            // memoEditInfo
            // 
            this.memoEditInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memoEditInfo.Location = new System.Drawing.Point(144, 159);
            this.memoEditInfo.Name = "memoEditInfo";
            this.memoEditInfo.Size = new System.Drawing.Size(438, 74);
            this.memoEditInfo.TabIndex = 10;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(25, 161);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(27, 13);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Note:";
            // 
            // checkedListBoxControl2
            // 
            this.checkedListBoxControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxControl2.CheckOnClick = true;
            this.checkedListBoxControl2.DisplayMember = "Descrizione";
            this.checkedListBoxControl2.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.checkedListBoxControl2.HotTrackItems = true;
            this.checkedListBoxControl2.Location = new System.Drawing.Point(144, 239);
            this.checkedListBoxControl2.Name = "checkedListBoxControl2";
            this.checkedListBoxControl2.Size = new System.Drawing.Size(438, 324);
            this.checkedListBoxControl2.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.checkedListBoxControl2.TabIndex = 13;
            this.checkedListBoxControl2.ValueMember = "This";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(23, 239);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(42, 13);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "Ingressi:";
            // 
            // XtraFormReport03b
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 637);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.checkedListBoxControl2);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.memoEditInfo);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.checkedListBoxControl1);
            this.Controls.Add(this.spinEditAnno);
            this.Controls.Add(this.simpleButtonReport);
            this.Controls.Add(this.labelControl2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XtraFormReport03b";
            this.Text = "Report 03b";
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditAnno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButtonReport;
        private DevExpress.Xpo.UnitOfWork unitOfWork1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SpinEdit spinEditAnno;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit memoEditInfo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl2;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}