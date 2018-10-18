namespace WinTicketNext.CostruzionePercorso
{
    partial class XtraFormCheckRegola
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonAnnulla = new DevExpress.XtraEditors.SimpleButton();
            this.checkEditIgnora = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButtonProsegui = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditIgnora.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.AllowHtmlString = true;
            this.labelControl1.Appearance.Image = global::WinTicketNext.Properties.Resources.sign_warning_BF_32_S;
            this.labelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(545, 51);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "labelControl1 <b>bold</b>";
            // 
            // simpleButtonAnnulla
            // 
            this.simpleButtonAnnulla.Appearance.Options.UseTextOptions = true;
            this.simpleButtonAnnulla.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.simpleButtonAnnulla.Location = new System.Drawing.Point(406, 215);
            this.simpleButtonAnnulla.Name = "simpleButtonAnnulla";
            this.simpleButtonAnnulla.Size = new System.Drawing.Size(151, 62);
            this.simpleButtonAnnulla.TabIndex = 1;
            this.simpleButtonAnnulla.Text = "annulla e ritorna alla maschera per modificare i profili";
            this.simpleButtonAnnulla.Click += new System.EventHandler(this.simpleButtonAnnulla_Click);
            // 
            // checkEditIgnora
            // 
            this.checkEditIgnora.Location = new System.Drawing.Point(12, 213);
            this.checkEditIgnora.Name = "checkEditIgnora";
            this.checkEditIgnora.Properties.Caption = "Ignora questa regola";
            this.checkEditIgnora.Size = new System.Drawing.Size(152, 19);
            this.checkEditIgnora.TabIndex = 2;
            this.checkEditIgnora.CheckedChanged += new System.EventHandler(this.checkEditIgnora_CheckedChanged);
            // 
            // simpleButtonProsegui
            // 
            this.simpleButtonProsegui.Enabled = false;
            this.simpleButtonProsegui.Location = new System.Drawing.Point(12, 238);
            this.simpleButtonProsegui.Name = "simpleButtonProsegui";
            this.simpleButtonProsegui.Size = new System.Drawing.Size(132, 39);
            this.simpleButtonProsegui.TabIndex = 3;
            this.simpleButtonProsegui.Text = "prosegui con la vendita";
            this.simpleButtonProsegui.Click += new System.EventHandler(this.simpleButtonProsegui_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(13, 69);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(544, 123);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "labelControl2";
            // 
            // XtraFormCheckRegola
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 289);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.simpleButtonProsegui);
            this.Controls.Add(this.checkEditIgnora);
            this.Controls.Add(this.simpleButtonAnnulla);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XtraFormCheckRegola";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Regola non verificata";
            ((System.ComponentModel.ISupportInitialize)(this.checkEditIgnora.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonAnnulla;
        private DevExpress.XtraEditors.CheckEdit checkEditIgnora;
        private DevExpress.XtraEditors.SimpleButton simpleButtonProsegui;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}