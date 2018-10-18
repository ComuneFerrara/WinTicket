namespace WinTicketNext.Storico
{
    partial class XtraFormAskReportPostazione
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
            this.dateEditGiorno = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonStampa = new DevExpress.XtraEditors.SimpleButton();
            this.checkedListBoxControlPostazioni = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.unitOfWork1 = new DevExpress.Xpo.UnitOfWork();
            this.dateEditFine = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditGiorno.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditGiorno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControlPostazioni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFine.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFine.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dateEditGiorno
            // 
            this.dateEditGiorno.EditValue = null;
            this.dateEditGiorno.Location = new System.Drawing.Point(51, 12);
            this.dateEditGiorno.Name = "dateEditGiorno";
            this.dateEditGiorno.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditGiorno.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditGiorno.Size = new System.Drawing.Size(100, 20);
            this.dateEditGiorno.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(15, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Dal";
            // 
            // simpleButtonStampa
            // 
            this.simpleButtonStampa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonStampa.Image = global::WinTicketNext.Properties.Resources.check;
            this.simpleButtonStampa.Location = new System.Drawing.Point(430, 247);
            this.simpleButtonStampa.Name = "simpleButtonStampa";
            this.simpleButtonStampa.Size = new System.Drawing.Size(114, 41);
            this.simpleButtonStampa.TabIndex = 2;
            this.simpleButtonStampa.Text = "Stampa";
            this.simpleButtonStampa.Click += new System.EventHandler(this.simpleButtonStampa_Click);
            // 
            // checkedListBoxControlPostazioni
            // 
            this.checkedListBoxControlPostazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxControlPostazioni.CheckOnClick = true;
            this.checkedListBoxControlPostazioni.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.checkedListBoxControlPostazioni.Location = new System.Drawing.Point(51, 38);
            this.checkedListBoxControlPostazioni.Name = "checkedListBoxControlPostazioni";
            this.checkedListBoxControlPostazioni.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.checkedListBoxControlPostazioni.Size = new System.Drawing.Size(373, 250);
            this.checkedListBoxControlPostazioni.TabIndex = 3;
            // 
            // dateEditFine
            // 
            this.dateEditFine.EditValue = null;
            this.dateEditFine.Location = new System.Drawing.Point(218, 12);
            this.dateEditFine.Name = "dateEditFine";
            this.dateEditFine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFine.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditFine.Size = new System.Drawing.Size(100, 20);
            this.dateEditFine.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(197, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(9, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Al";
            // 
            // XtraFormAskReportPostazione
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 300);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.dateEditFine);
            this.Controls.Add(this.dateEditGiorno);
            this.Controls.Add(this.checkedListBoxControlPostazioni);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.simpleButtonStampa);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XtraFormAskReportPostazione";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stampa Report Postazione";
            ((System.ComponentModel.ISupportInitialize)(this.dateEditGiorno.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditGiorno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControlPostazioni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFine.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFine.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dateEditGiorno;
        private DevExpress.XtraEditors.SimpleButton simpleButtonStampa;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControlPostazioni;
        private DevExpress.Xpo.UnitOfWork unitOfWork1;
        private DevExpress.XtraEditors.DateEdit dateEditFine;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}