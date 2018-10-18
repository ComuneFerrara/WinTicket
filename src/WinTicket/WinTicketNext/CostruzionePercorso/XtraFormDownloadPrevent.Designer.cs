namespace WinTicketNext.CostruzionePercorso
{
    partial class XtraFormDownloadPrevent
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.linkLabelWeb = new System.Windows.Forms.LinkLabel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControlInfo1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControlInfo2 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonConferma = new DevExpress.XtraEditors.SimpleButton();
            this.buttonEditCodice = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditCodice.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabelWeb
            // 
            this.linkLabelWeb.Image = global::WinTicketNext.Properties.Resources.arrow2_right_green;
            this.linkLabelWeb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabelWeb.Location = new System.Drawing.Point(14, 11);
            this.linkLabelWeb.Name = "linkLabelWeb";
            this.linkLabelWeb.Size = new System.Drawing.Size(458, 48);
            this.linkLabelWeb.TabIndex = 0;
            this.linkLabelWeb.TabStop = true;
            this.linkLabelWeb.Text = "Clicca qui per cercare una prenotazione sul web";
            this.linkLabelWeb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelWeb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelWeb_LinkClicked);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(14, 63);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(121, 16);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Codice Prenotazione:";
            // 
            // labelControlInfo1
            // 
            this.labelControlInfo1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControlInfo1.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.labelControlInfo1.Appearance.Options.UseFont = true;
            this.labelControlInfo1.Appearance.Options.UseForeColor = true;
            this.labelControlInfo1.Location = new System.Drawing.Point(14, 126);
            this.labelControlInfo1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControlInfo1.Name = "labelControlInfo1";
            this.labelControlInfo1.Size = new System.Drawing.Size(75, 13);
            this.labelControlInfo1.TabIndex = 3;
            this.labelControlInfo1.Text = "labelControl2";
            // 
            // labelControlInfo2
            // 
            this.labelControlInfo2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControlInfo2.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.labelControlInfo2.Appearance.Options.UseFont = true;
            this.labelControlInfo2.Appearance.Options.UseForeColor = true;
            this.labelControlInfo2.Location = new System.Drawing.Point(14, 149);
            this.labelControlInfo2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControlInfo2.Name = "labelControlInfo2";
            this.labelControlInfo2.Size = new System.Drawing.Size(75, 13);
            this.labelControlInfo2.TabIndex = 4;
            this.labelControlInfo2.Text = "labelControl3";
            // 
            // simpleButtonConferma
            // 
            this.simpleButtonConferma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButtonConferma.Appearance.Options.UseTextOptions = true;
            this.simpleButtonConferma.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.simpleButtonConferma.Image = global::WinTicketNext.Properties.Resources.link_add;
            this.simpleButtonConferma.Location = new System.Drawing.Point(14, 181);
            this.simpleButtonConferma.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButtonConferma.Name = "simpleButtonConferma";
            this.simpleButtonConferma.Size = new System.Drawing.Size(146, 66);
            this.simpleButtonConferma.TabIndex = 5;
            this.simpleButtonConferma.Text = "Acquisisci Prenotazione";
            this.simpleButtonConferma.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // buttonEditCodice
            // 
            this.buttonEditCodice.Location = new System.Drawing.Point(14, 91);
            this.buttonEditCodice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonEditCodice.Name = "buttonEditCodice";
            this.buttonEditCodice.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditCodice.Properties.Appearance.Options.UseFont = true;
            this.buttonEditCodice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Lettura Prenotazione", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.buttonEditCodice.Properties.NullValuePrompt = "Web";
            this.buttonEditCodice.Size = new System.Drawing.Size(243, 22);
            this.buttonEditCodice.TabIndex = 6;
            this.buttonEditCodice.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditCodice_ButtonClick);
            // 
            // XtraFormDownloadPrevent
            // 
            this.AcceptButton = this.simpleButtonConferma;
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.Controls.Add(this.buttonEditCodice);
            this.Controls.Add(this.simpleButtonConferma);
            this.Controls.Add(this.labelControlInfo2);
            this.Controls.Add(this.labelControlInfo1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.linkLabelWeb);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "XtraFormDownloadPrevent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Acquisisci Prenotazione";
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditCodice.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabelWeb;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControlInfo1;
        private DevExpress.XtraEditors.LabelControl labelControlInfo2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonConferma;
        private DevExpress.XtraEditors.ButtonEdit buttonEditCodice;
    }
}