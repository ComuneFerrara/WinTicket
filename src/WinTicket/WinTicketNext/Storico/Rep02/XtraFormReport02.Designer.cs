namespace WinTicketNext.Storico.Rep02
{
    partial class XtraFormReport02
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
            this.dateEditInizio = new DevExpress.XtraEditors.DateEdit();
            this.dateEditFine = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonReport = new DevExpress.XtraEditors.SimpleButton();
            this.unitOfWork1 = new DevExpress.Xpo.UnitOfWork();
            this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInizio.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInizio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFine.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
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
            this.simpleButtonReport.Image = global::WinTicketNext.Properties.Resources.printer;
            this.simpleButtonReport.Location = new System.Drawing.Point(304, 462);
            this.simpleButtonReport.Name = "simpleButtonReport";
            this.simpleButtonReport.Size = new System.Drawing.Size(145, 56);
            this.simpleButtonReport.TabIndex = 4;
            this.simpleButtonReport.Text = "Anteprima Report";
            this.simpleButtonReport.Click += new System.EventHandler(this.simpleButtonReport_Click);
            // 
            // checkedListBoxControl1
            // 
            this.checkedListBoxControl1.CheckOnClick = true;
            this.checkedListBoxControl1.DisplayMember = "Descrizione";
            this.checkedListBoxControl1.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.checkedListBoxControl1.HotTrackItems = true;
            this.checkedListBoxControl1.Location = new System.Drawing.Point(25, 92);
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.Size = new System.Drawing.Size(424, 364);
            this.checkedListBoxControl1.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.checkedListBoxControl1.TabIndex = 7;
            this.checkedListBoxControl1.ValueMember = "This";
            // 
            // XtraFormReport02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 530);
            this.Controls.Add(this.checkedListBoxControl1);
            this.Controls.Add(this.simpleButtonReport);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dateEditFine);
            this.Controls.Add(this.dateEditInizio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XtraFormReport02";
            this.Text = "Report 02";
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInizio.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInizio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFine.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
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
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
    }
}