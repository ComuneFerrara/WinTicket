namespace WinTicketNext.CostruzionePercorso
{
    partial class RibbonFormAskBonus
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
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButtonCheck = new DevExpress.XtraEditors.SimpleButton();
            this.buttonEditCodice = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButtonRemove = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOk = new DevExpress.XtraEditors.SimpleButton();
            this.labelControlInfoText = new DevExpress.XtraEditors.LabelControl();
            this.textEditDisplayBonus = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.timerTick = new System.Windows.Forms.Timer(this.components);
            this.labelControlSearchResult = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditCodice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDisplayBonus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonText = "XPSoft";
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 1;
            this.ribbon.Name = "ribbon";
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.Size = new System.Drawing.Size(696, 49);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 432);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(696, 31);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControlSearchResult);
            this.groupControl1.Controls.Add(this.simpleButtonCheck);
            this.groupControl1.Controls.Add(this.buttonEditCodice);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 49);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(696, 155);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Ricerca Codice Sconto";
            // 
            // simpleButtonCheck
            // 
            this.simpleButtonCheck.Image = global::WinTicketNext.Properties.Resources.view_BF_32_S;
            this.simpleButtonCheck.Location = new System.Drawing.Point(311, 50);
            this.simpleButtonCheck.Name = "simpleButtonCheck";
            this.simpleButtonCheck.Size = new System.Drawing.Size(97, 55);
            this.simpleButtonCheck.TabIndex = 2;
            this.simpleButtonCheck.TabStop = false;
            this.simpleButtonCheck.Text = "RICERCA";
            this.simpleButtonCheck.Click += new System.EventHandler(this.simpleButtonCheck_Click);
            // 
            // buttonEditCodice
            // 
            this.buttonEditCodice.Location = new System.Drawing.Point(125, 66);
            this.buttonEditCodice.MenuManager = this.ribbon;
            this.buttonEditCodice.Name = "buttonEditCodice";
            this.buttonEditCodice.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditCodice.Properties.Appearance.Options.UseFont = true;
            this.buttonEditCodice.Size = new System.Drawing.Size(180, 22);
            this.buttonEditCodice.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 71);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Scansione Bonus:";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.simpleButtonRemove);
            this.groupControl2.Controls.Add(this.simpleButtonOk);
            this.groupControl2.Controls.Add(this.labelControlInfoText);
            this.groupControl2.Controls.Add(this.textEditDisplayBonus);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 204);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(696, 228);
            this.groupControl2.TabIndex = 3;
            this.groupControl2.Text = "Risultato Ricerca";
            // 
            // simpleButtonRemove
            // 
            this.simpleButtonRemove.Image = global::WinTicketNext.Properties.Resources.delete_BF_32_S;
            this.simpleButtonRemove.Location = new System.Drawing.Point(12, 130);
            this.simpleButtonRemove.Name = "simpleButtonRemove";
            this.simpleButtonRemove.Size = new System.Drawing.Size(95, 57);
            this.simpleButtonRemove.TabIndex = 4;
            this.simpleButtonRemove.Text = "Rimuovi";
            this.simpleButtonRemove.Click += new System.EventHandler(this.simpleButtonRemove_Click);
            // 
            // simpleButtonOk
            // 
            this.simpleButtonOk.Appearance.Options.UseTextOptions = true;
            this.simpleButtonOk.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.simpleButtonOk.Image = global::WinTicketNext.Properties.Resources.check;
            this.simpleButtonOk.Location = new System.Drawing.Point(553, 130);
            this.simpleButtonOk.Name = "simpleButtonOk";
            this.simpleButtonOk.Size = new System.Drawing.Size(131, 57);
            this.simpleButtonOk.TabIndex = 3;
            this.simpleButtonOk.Text = "Conferma e Applica";
            this.simpleButtonOk.Click += new System.EventHandler(this.simpleButtonOk_Click);
            // 
            // labelControlInfoText
            // 
            this.labelControlInfoText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlInfoText.Location = new System.Drawing.Point(12, 73);
            this.labelControlInfoText.Name = "labelControlInfoText";
            this.labelControlInfoText.Size = new System.Drawing.Size(672, 51);
            this.labelControlInfoText.TabIndex = 2;
            this.labelControlInfoText.Text = "info text";
            // 
            // textEditDisplayBonus
            // 
            this.textEditDisplayBonus.EditValue = "info";
            this.textEditDisplayBonus.Location = new System.Drawing.Point(125, 38);
            this.textEditDisplayBonus.MenuManager = this.ribbon;
            this.textEditDisplayBonus.Name = "textEditDisplayBonus";
            this.textEditDisplayBonus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditDisplayBonus.Properties.Appearance.Options.UseFont = true;
            this.textEditDisplayBonus.Properties.ReadOnly = true;
            this.textEditDisplayBonus.Size = new System.Drawing.Size(559, 22);
            this.textEditDisplayBonus.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 43);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(68, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Codice Bonus:";
            // 
            // timerTick
            // 
            this.timerTick.Enabled = true;
            this.timerTick.Interval = 2000;
            this.timerTick.Tick += new System.EventHandler(this.timerTick_Tick);
            // 
            // labelControlSearchResult
            // 
            this.labelControlSearchResult.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlSearchResult.Location = new System.Drawing.Point(125, 113);
            this.labelControlSearchResult.Name = "labelControlSearchResult";
            this.labelControlSearchResult.Size = new System.Drawing.Size(559, 24);
            this.labelControlSearchResult.TabIndex = 3;
            this.labelControlSearchResult.Text = "Risultato Ricerca:";
            // 
            // RibbonFormAskBonus
            // 
            this.AcceptButton = this.simpleButtonCheck;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 463);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RibbonFormAskBonus";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "XPSoft";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditCodice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDisplayBonus.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit buttonEditCodice;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCheck;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit textEditDisplayBonus;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOk;
        private DevExpress.XtraEditors.LabelControl labelControlInfoText;
        private DevExpress.XtraEditors.SimpleButton simpleButtonRemove;
        private System.Windows.Forms.Timer timerTick;
        private DevExpress.XtraEditors.LabelControl labelControlSearchResult;
    }
}