namespace WinTicketNext.Storico.RepVersamenti
{
    partial class XtraFormQuietanzaContanti
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
            this.dateEditInizio = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditFine = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditPosAltri = new DevExpress.XtraEditors.SpinEdit();
            this.spinEditConAltri = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditTotale = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditVersamento = new DevExpress.XtraEditors.DateEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.textEditQuietanza.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditVersamento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInizio.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInizio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFine.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPosAltri.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditConAltri.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditTotale.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditVersamento.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditVersamento.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEditQuietanza
            // 
            this.textEditQuietanza.Location = new System.Drawing.Point(112, 209);
            this.textEditQuietanza.Name = "textEditQuietanza";
            this.textEditQuietanza.Size = new System.Drawing.Size(179, 20);
            this.textEditQuietanza.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 212);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(81, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Num. Quietanza:";
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
            this.spinEditVersamento.Location = new System.Drawing.Point(112, 39);
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
            this.simpleButtonOk.Location = new System.Drawing.Point(205, 235);
            this.simpleButtonOk.Name = "simpleButtonOk";
            this.simpleButtonOk.Size = new System.Drawing.Size(86, 29);
            this.simpleButtonOk.TabIndex = 4;
            this.simpleButtonOk.Text = "Conferma";
            this.simpleButtonOk.Click += new System.EventHandler(this.simpleButtonOk_Click);
            // 
            // dateEditInizio
            // 
            this.dateEditInizio.EditValue = null;
            this.dateEditInizio.Location = new System.Drawing.Point(85, 13);
            this.dateEditInizio.Name = "dateEditInizio";
            this.dateEditInizio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditInizio.Properties.ReadOnly = true;
            this.dateEditInizio.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditInizio.Size = new System.Drawing.Size(100, 20);
            this.dateEditInizio.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 16);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(59, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Inizio / Fine:";
            // 
            // dateEditFine
            // 
            this.dateEditFine.EditValue = null;
            this.dateEditFine.Location = new System.Drawing.Point(191, 13);
            this.dateEditFine.Name = "dateEditFine";
            this.dateEditFine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFine.Properties.ReadOnly = true;
            this.dateEditFine.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditFine.Size = new System.Drawing.Size(100, 20);
            this.dateEditFine.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 68);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(64, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Altri Enti Pos:";
            // 
            // spinEditPosAltri
            // 
            this.spinEditPosAltri.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditPosAltri.Location = new System.Drawing.Point(112, 65);
            this.spinEditPosAltri.Name = "spinEditPosAltri";
            this.spinEditPosAltri.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditPosAltri.Properties.DisplayFormat.FormatString = "c";
            this.spinEditPosAltri.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEditPosAltri.Properties.EditFormat.FormatString = "c";
            this.spinEditPosAltri.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEditPosAltri.Properties.ReadOnly = true;
            this.spinEditPosAltri.Size = new System.Drawing.Size(100, 20);
            this.spinEditPosAltri.TabIndex = 9;
            // 
            // spinEditConAltri
            // 
            this.spinEditConAltri.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditConAltri.Location = new System.Drawing.Point(112, 91);
            this.spinEditConAltri.Name = "spinEditConAltri";
            this.spinEditConAltri.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditConAltri.Properties.DisplayFormat.FormatString = "c";
            this.spinEditConAltri.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEditConAltri.Properties.EditFormat.FormatString = "c";
            this.spinEditConAltri.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEditConAltri.Properties.ReadOnly = true;
            this.spinEditConAltri.Size = new System.Drawing.Size(100, 20);
            this.spinEditConAltri.TabIndex = 10;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 94);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(92, 13);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "Altri Enti Contante:";
            // 
            // spinEditTotale
            // 
            this.spinEditTotale.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditTotale.Location = new System.Drawing.Point(112, 131);
            this.spinEditTotale.Name = "spinEditTotale";
            this.spinEditTotale.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditTotale.Properties.DisplayFormat.FormatString = "c";
            this.spinEditTotale.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEditTotale.Properties.EditFormat.FormatString = "c";
            this.spinEditTotale.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEditTotale.Properties.ReadOnly = true;
            this.spinEditTotale.Size = new System.Drawing.Size(100, 20);
            this.spinEditTotale.TabIndex = 12;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 134);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(94, 13);
            this.labelControl6.TabIndex = 13;
            this.labelControl6.Text = "Importo Quietanza:";
            // 
            // dateEditVersamento
            // 
            this.dateEditVersamento.EditValue = null;
            this.dateEditVersamento.Location = new System.Drawing.Point(112, 183);
            this.dateEditVersamento.Name = "dateEditVersamento";
            this.dateEditVersamento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditVersamento.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditVersamento.Size = new System.Drawing.Size(100, 20);
            this.dateEditVersamento.TabIndex = 14;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 186);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(87, 13);
            this.labelControl7.TabIndex = 15;
            this.labelControl7.Text = "Data Versamento:";
            // 
            // XtraFormQuietanzaContanti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 290);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.dateEditVersamento);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.spinEditTotale);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.spinEditConAltri);
            this.Controls.Add(this.spinEditPosAltri);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.dateEditFine);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.dateEditInizio);
            this.Controls.Add(this.simpleButtonOk);
            this.Controls.Add(this.spinEditVersamento);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.textEditQuietanza);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XtraFormQuietanzaContanti";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quietanza Versamento Contanti";
            ((System.ComponentModel.ISupportInitialize)(this.textEditQuietanza.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditVersamento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInizio.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInizio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFine.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPosAltri.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditConAltri.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditTotale.Properties)).EndInit();
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
        private DevExpress.XtraEditors.DateEdit dateEditInizio;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dateEditFine;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SpinEdit spinEditPosAltri;
        private DevExpress.XtraEditors.SpinEdit spinEditConAltri;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SpinEdit spinEditTotale;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.DateEdit dateEditVersamento;
        private DevExpress.XtraEditors.LabelControl labelControl7;
    }
}