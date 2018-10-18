namespace WinTicketNext.CostruzionePercorso
{
    partial class RibbonFormCardMyFeTurista
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
            this.labelControlSearchResult = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonCheck = new DevExpress.XtraEditors.SimpleButton();
            this.buttonEditCodice = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.timerTick = new System.Windows.Forms.Timer(this.components);
            this.simpleButtonOk = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControlInfoText = new DevExpress.XtraEditors.LabelControl();
            this.groupControlAlbergo = new DevExpress.XtraEditors.GroupControl();
            this.lookUpEditAlbergo = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.checkEditContanti = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditPos = new DevExpress.XtraEditors.CheckEdit();
            this.labelControlTotale = new DevExpress.XtraEditors.LabelControl();
            this.gridControlElencoCard = new DevExpress.XtraGrid.GridControl();
            this.gridViewElencoCard = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnCodice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTipologia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnImporto = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditCodice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlAlbergo)).BeginInit();
            this.groupControlAlbergo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditAlbergo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditContanti.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditPos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlElencoCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewElencoCard)).BeginInit();
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
            this.ribbon.Size = new System.Drawing.Size(728, 49);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 644);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(728, 31);
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
            this.groupControl1.Size = new System.Drawing.Size(728, 155);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Immissione Codice Carta";
            // 
            // labelControlSearchResult
            // 
            this.labelControlSearchResult.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlSearchResult.Location = new System.Drawing.Point(125, 113);
            this.labelControlSearchResult.Name = "labelControlSearchResult";
            this.labelControlSearchResult.Size = new System.Drawing.Size(437, 24);
            this.labelControlSearchResult.TabIndex = 3;
            this.labelControlSearchResult.Text = "Risultato Ricerca:";
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
            this.labelControl1.Size = new System.Drawing.Size(107, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Scansione Card MyFE:";
            // 
            // timerTick
            // 
            this.timerTick.Enabled = true;
            this.timerTick.Interval = 2000;
            this.timerTick.Tick += new System.EventHandler(this.timerTick_Tick);
            // 
            // simpleButtonOk
            // 
            this.simpleButtonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonOk.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonOk.Appearance.Options.UseFont = true;
            this.simpleButtonOk.Appearance.Options.UseTextOptions = true;
            this.simpleButtonOk.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.simpleButtonOk.Image = global::WinTicketNext.Properties.Resources.check;
            this.simpleButtonOk.Location = new System.Drawing.Point(585, 342);
            this.simpleButtonOk.Name = "simpleButtonOk";
            this.simpleButtonOk.Size = new System.Drawing.Size(131, 92);
            this.simpleButtonOk.TabIndex = 3;
            this.simpleButtonOk.Text = "Conferma && Stampa";
            this.simpleButtonOk.Click += new System.EventHandler(this.simpleButtonOk_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.labelControlInfoText);
            this.groupControl2.Controls.Add(this.groupControlAlbergo);
            this.groupControl2.Controls.Add(this.groupControl3);
            this.groupControl2.Controls.Add(this.labelControlTotale);
            this.groupControl2.Controls.Add(this.gridControlElencoCard);
            this.groupControl2.Controls.Add(this.simpleButtonOk);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 204);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(728, 440);
            this.groupControl2.TabIndex = 3;
            this.groupControl2.Text = "Elenco Card Acquisite";
            // 
            // labelControlInfoText
            // 
            this.labelControlInfoText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControlInfoText.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlInfoText.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControlInfoText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControlInfoText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlInfoText.Location = new System.Drawing.Point(12, 307);
            this.labelControlInfoText.Name = "labelControlInfoText";
            this.labelControlInfoText.Size = new System.Drawing.Size(704, 29);
            this.labelControlInfoText.TabIndex = 14;
            this.labelControlInfoText.Text = "Mettere DATA sulle CARD !";
            // 
            // groupControlAlbergo
            // 
            this.groupControlAlbergo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControlAlbergo.Controls.Add(this.lookUpEditAlbergo);
            this.groupControlAlbergo.Location = new System.Drawing.Point(219, 342);
            this.groupControlAlbergo.Name = "groupControlAlbergo";
            this.groupControlAlbergo.Size = new System.Drawing.Size(360, 92);
            this.groupControlAlbergo.TabIndex = 13;
            this.groupControlAlbergo.Text = "Albergo acquirente";
            // 
            // lookUpEditAlbergo
            // 
            this.lookUpEditAlbergo.Location = new System.Drawing.Point(22, 35);
            this.lookUpEditAlbergo.MenuManager = this.ribbon;
            this.lookUpEditAlbergo.Name = "lookUpEditAlbergo";
            this.lookUpEditAlbergo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditAlbergo.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditAlbergo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditAlbergo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RagioneSociale", "Ragione Sociale", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Indirizzo", "Indirizzo")});
            this.lookUpEditAlbergo.Properties.DisplayMember = "RagioneSociale";
            this.lookUpEditAlbergo.Properties.NullText = "";
            this.lookUpEditAlbergo.Properties.ValueMember = "This";
            this.lookUpEditAlbergo.Size = new System.Drawing.Size(305, 20);
            this.lookUpEditAlbergo.TabIndex = 0;
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl3.Controls.Add(this.checkEditContanti);
            this.groupControl3.Controls.Add(this.checkEditPos);
            this.groupControl3.Location = new System.Drawing.Point(12, 342);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(200, 92);
            this.groupControl3.TabIndex = 12;
            this.groupControl3.Text = "Incasso:";
            // 
            // checkEditContanti
            // 
            this.checkEditContanti.Location = new System.Drawing.Point(5, 34);
            this.checkEditContanti.Name = "checkEditContanti";
            this.checkEditContanti.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEditContanti.Properties.Appearance.Options.UseFont = true;
            this.checkEditContanti.Properties.Caption = "Incasso in contanti";
            this.checkEditContanti.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.checkEditContanti.Properties.RadioGroupIndex = 1;
            this.checkEditContanti.Size = new System.Drawing.Size(202, 19);
            this.checkEditContanti.TabIndex = 9;
            this.checkEditContanti.TabStop = false;
            // 
            // checkEditPos
            // 
            this.checkEditPos.Location = new System.Drawing.Point(5, 59);
            this.checkEditPos.Name = "checkEditPos";
            this.checkEditPos.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEditPos.Properties.Appearance.Options.UseFont = true;
            this.checkEditPos.Properties.Caption = "Incasso tramite POS";
            this.checkEditPos.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.checkEditPos.Properties.RadioGroupIndex = 1;
            this.checkEditPos.Size = new System.Drawing.Size(141, 19);
            this.checkEditPos.TabIndex = 10;
            this.checkEditPos.TabStop = false;
            // 
            // labelControlTotale
            // 
            this.labelControlTotale.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlTotale.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControlTotale.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlTotale.Location = new System.Drawing.Point(12, 267);
            this.labelControlTotale.Name = "labelControlTotale";
            this.labelControlTotale.Size = new System.Drawing.Size(704, 34);
            this.labelControlTotale.TabIndex = 11;
            this.labelControlTotale.Text = "Importo TOTALE:";
            // 
            // gridControlElencoCard
            // 
            this.gridControlElencoCard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlElencoCard.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControlElencoCard.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControlElencoCard.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControlElencoCard.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControlElencoCard.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControlElencoCard.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(7, "ELIMINA CARD")});
            this.gridControlElencoCard.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridControlElencoCard_EmbeddedNavigator_ButtonClick);
            this.gridControlElencoCard.Location = new System.Drawing.Point(12, 33);
            this.gridControlElencoCard.MainView = this.gridViewElencoCard;
            this.gridControlElencoCard.MenuManager = this.ribbon;
            this.gridControlElencoCard.Name = "gridControlElencoCard";
            this.gridControlElencoCard.Size = new System.Drawing.Size(704, 228);
            this.gridControlElencoCard.TabIndex = 5;
            this.gridControlElencoCard.UseEmbeddedNavigator = true;
            this.gridControlElencoCard.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewElencoCard});
            // 
            // gridViewElencoCard
            // 
            this.gridViewElencoCard.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewElencoCard.Appearance.Row.Options.UseFont = true;
            this.gridViewElencoCard.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnCodice,
            this.gridColumnTipologia,
            this.gridColumnImporto});
            this.gridViewElencoCard.GridControl = this.gridControlElencoCard;
            this.gridViewElencoCard.Name = "gridViewElencoCard";
            this.gridViewElencoCard.OptionsBehavior.Editable = false;
            this.gridViewElencoCard.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewElencoCard.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewElencoCard.OptionsView.ShowFooter = true;
            this.gridViewElencoCard.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnCodice
            // 
            this.gridColumnCodice.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnCodice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnCodice.Caption = "Codice";
            this.gridColumnCodice.FieldName = "Codice";
            this.gridColumnCodice.Name = "gridColumnCodice";
            this.gridColumnCodice.Visible = true;
            this.gridColumnCodice.VisibleIndex = 1;
            // 
            // gridColumnTipologia
            // 
            this.gridColumnTipologia.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnTipologia.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnTipologia.Caption = "Tipologia";
            this.gridColumnTipologia.FieldName = "TipologiaCard";
            this.gridColumnTipologia.Name = "gridColumnTipologia";
            this.gridColumnTipologia.Visible = true;
            this.gridColumnTipologia.VisibleIndex = 0;
            // 
            // gridColumnImporto
            // 
            this.gridColumnImporto.Caption = "Importo";
            this.gridColumnImporto.DisplayFormat.FormatString = "c";
            this.gridColumnImporto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnImporto.FieldName = "Importo";
            this.gridColumnImporto.Name = "gridColumnImporto";
            this.gridColumnImporto.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Importo", "{0:c}")});
            this.gridColumnImporto.Visible = true;
            this.gridColumnImporto.VisibleIndex = 2;
            // 
            // RibbonFormCardMyFeTurista
            // 
            this.AcceptButton = this.simpleButtonCheck;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 675);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RibbonFormCardMyFeTurista";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Card MyFE";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditCodice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlAlbergo)).EndInit();
            this.groupControlAlbergo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditAlbergo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEditContanti.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditPos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlElencoCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewElencoCard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit buttonEditCodice;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCheck;
        private System.Windows.Forms.Timer timerTick;
        private DevExpress.XtraEditors.LabelControl labelControlSearchResult;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOk;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridControlElencoCard;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewElencoCard;
        private DevExpress.XtraEditors.CheckEdit checkEditPos;
        private DevExpress.XtraEditors.CheckEdit checkEditContanti;
        private DevExpress.XtraEditors.LabelControl labelControlTotale;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCodice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTipologia;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.GroupControl groupControlAlbergo;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditAlbergo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnImporto;
        private DevExpress.XtraEditors.LabelControl labelControlInfoText;
    }
}