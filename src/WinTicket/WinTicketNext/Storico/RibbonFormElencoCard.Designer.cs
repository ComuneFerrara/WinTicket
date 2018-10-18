namespace WinTicketNext.Storico
{
    partial class RibbonFormElencoCard
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
            this.barButtonItemQuery = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCestina = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemRecupera = new DevExpress.XtraBars.BarButtonItem();
            this.barCheckItem2gg = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItem3gg = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItem6gg = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItemNuova = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItemEmesse = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItemSoppresse = new DevExpress.XtraBars.BarCheckItem();
            this.barButtonItemStampa = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAssegna = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItemDalla = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barEditItemAlla = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barButtonGroup1 = new DevExpress.XtraBars.BarButtonGroup();
            this.barCheckItemAssegnate = new DevExpress.XtraBars.BarCheckItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.Operazioni = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.unitOfWork1 = new DevExpress.Xpo.UnitOfWork(this.components);
            this.gridControlCard = new DevExpress.XtraGrid.GridControl();
            this.gridViewCard = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipologiaCard = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAssegnataUtente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAssegnataStruttura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAssegnataIl = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCard)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barButtonItemQuery,
            this.barButtonItemCestina,
            this.barButtonItemRecupera,
            this.barCheckItem2gg,
            this.barCheckItem3gg,
            this.barCheckItem6gg,
            this.barCheckItemNuova,
            this.barCheckItemEmesse,
            this.barCheckItemSoppresse,
            this.barButtonItemStampa,
            this.barButtonItemAssegna,
            this.barEditItemDalla,
            this.barEditItemAlla,
            this.barButtonGroup1,
            this.barCheckItemAssegnate});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 17;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemDateEdit2});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(907, 144);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // barButtonItemQuery
            // 
            this.barButtonItemQuery.Caption = "Esegui Query";
            this.barButtonItemQuery.Id = 1;
            this.barButtonItemQuery.LargeGlyph = global::WinTicketNext.Properties.Resources.bullet_triangle_green_BF_32_S;
            this.barButtonItemQuery.Name = "barButtonItemQuery";
            this.barButtonItemQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemQuery_ItemClick);
            // 
            // barButtonItemCestina
            // 
            this.barButtonItemCestina.Caption = "Sopprimi card";
            this.barButtonItemCestina.Id = 2;
            this.barButtonItemCestina.LargeGlyph = global::WinTicketNext.Properties.Resources.garbage_full_BF_32_S;
            this.barButtonItemCestina.Name = "barButtonItemCestina";
            this.barButtonItemCestina.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemCestina_ItemClick);
            // 
            // barButtonItemRecupera
            // 
            this.barButtonItemRecupera.Caption = "Recupera Card";
            this.barButtonItemRecupera.Id = 3;
            this.barButtonItemRecupera.LargeGlyph = global::WinTicketNext.Properties.Resources.garbage_make_empty_BF_32_S;
            this.barButtonItemRecupera.Name = "barButtonItemRecupera";
            this.barButtonItemRecupera.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemRecupera_ItemClick);
            // 
            // barCheckItem2gg
            // 
            this.barCheckItem2gg.Caption = "2gg";
            this.barCheckItem2gg.Checked = true;
            this.barCheckItem2gg.Id = 4;
            this.barCheckItem2gg.Name = "barCheckItem2gg";
            // 
            // barCheckItem3gg
            // 
            this.barCheckItem3gg.Caption = "3gg";
            this.barCheckItem3gg.Checked = true;
            this.barCheckItem3gg.Id = 5;
            this.barCheckItem3gg.Name = "barCheckItem3gg";
            // 
            // barCheckItem6gg
            // 
            this.barCheckItem6gg.Caption = "6gg";
            this.barCheckItem6gg.Checked = true;
            this.barCheckItem6gg.Id = 6;
            this.barCheckItem6gg.Name = "barCheckItem6gg";
            // 
            // barCheckItemNuova
            // 
            this.barCheckItemNuova.Caption = "Nuove";
            this.barCheckItemNuova.Id = 7;
            this.barCheckItemNuova.Name = "barCheckItemNuova";
            // 
            // barCheckItemEmesse
            // 
            this.barCheckItemEmesse.Caption = "Emesse";
            this.barCheckItemEmesse.Checked = true;
            this.barCheckItemEmesse.Id = 8;
            this.barCheckItemEmesse.Name = "barCheckItemEmesse";
            // 
            // barCheckItemSoppresse
            // 
            this.barCheckItemSoppresse.Caption = "Soppresse";
            this.barCheckItemSoppresse.Id = 9;
            this.barCheckItemSoppresse.Name = "barCheckItemSoppresse";
            // 
            // barButtonItemStampa
            // 
            this.barButtonItemStampa.Caption = "Stampa / Esporta";
            this.barButtonItemStampa.Id = 10;
            this.barButtonItemStampa.LargeGlyph = global::WinTicketNext.Properties.Resources.printer;
            this.barButtonItemStampa.Name = "barButtonItemStampa";
            this.barButtonItemStampa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemStampa_ItemClick);
            // 
            // barButtonItemAssegna
            // 
            this.barButtonItemAssegna.Caption = "Assegna Card";
            this.barButtonItemAssegna.Id = 11;
            this.barButtonItemAssegna.LargeGlyph = global::WinTicketNext.Properties.Resources.check;
            this.barButtonItemAssegna.Name = "barButtonItemAssegna";
            this.barButtonItemAssegna.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAssegna_ItemClick);
            // 
            // barEditItemDalla
            // 
            this.barEditItemDalla.Caption = "Dalla Data";
            this.barEditItemDalla.Edit = this.repositoryItemDateEdit1;
            this.barEditItemDalla.Id = 12;
            this.barEditItemDalla.Name = "barEditItemDalla";
            this.barEditItemDalla.Width = 120;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // barEditItemAlla
            // 
            this.barEditItemAlla.Caption = "Alla Data  ";
            this.barEditItemAlla.Edit = this.repositoryItemDateEdit2;
            this.barEditItemAlla.Id = 13;
            this.barEditItemAlla.Name = "barEditItemAlla";
            this.barEditItemAlla.Width = 120;
            // 
            // repositoryItemDateEdit2
            // 
            this.repositoryItemDateEdit2.AutoHeight = false;
            this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
            this.repositoryItemDateEdit2.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // barButtonGroup1
            // 
            this.barButtonGroup1.Caption = "barButtonGroup1";
            this.barButtonGroup1.Id = 14;
            this.barButtonGroup1.Name = "barButtonGroup1";
            // 
            // barCheckItemAssegnate
            // 
            this.barCheckItemAssegnate.Caption = "Assegnate";
            this.barCheckItemAssegnate.Id = 16;
            this.barCheckItemAssegnate.Name = "barCheckItemAssegnate";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.Operazioni,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "MyFE CARD";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barCheckItem2gg);
            this.ribbonPageGroup1.ItemLinks.Add(this.barCheckItem3gg);
            this.ribbonPageGroup1.ItemLinks.Add(this.barCheckItem6gg);
            this.ribbonPageGroup1.ItemLinks.Add(this.barCheckItemNuova, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.barCheckItemAssegnate);
            this.ribbonPageGroup1.ItemLinks.Add(this.barCheckItemEmesse, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.barCheckItemSoppresse);
            this.ribbonPageGroup1.ItemLinks.Add(this.barEditItemDalla, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.barEditItemAlla);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemQuery, true);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Elenco MyFE";
            // 
            // Operazioni
            // 
            this.Operazioni.ItemLinks.Add(this.barButtonItemCestina);
            this.Operazioni.ItemLinks.Add(this.barButtonItemRecupera, true);
            this.Operazioni.Name = "Operazioni";
            this.Operazioni.Text = "Sopprimi card";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItemAssegna);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItemStampa, true);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Operazioni";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 512);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(907, 31);
            // 
            // unitOfWork1
            // 
            this.unitOfWork1.TrackPropertiesModifications = false;
            // 
            // gridControlCard
            // 
            this.gridControlCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlCard.Location = new System.Drawing.Point(0, 144);
            this.gridControlCard.MainView = this.gridViewCard;
            this.gridControlCard.MenuManager = this.ribbon;
            this.gridControlCard.Name = "gridControlCard";
            this.gridControlCard.ShowOnlyPredefinedDetails = true;
            this.gridControlCard.Size = new System.Drawing.Size(907, 368);
            this.gridControlCard.TabIndex = 2;
            this.gridControlCard.UseEmbeddedNavigator = true;
            this.gridControlCard.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCard});
            // 
            // gridViewCard
            // 
            this.gridViewCard.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOid,
            this.colCodice,
            this.colTipologiaCard,
            this.colStatus,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumnAssegnataUtente,
            this.gridColumnAssegnataStruttura,
            this.gridColumnAssegnataIl});
            this.gridViewCard.GridControl = this.gridControlCard;
            this.gridViewCard.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Oid", null, " (Conteggio: {0:n0})")});
            this.gridViewCard.Name = "gridViewCard";
            this.gridViewCard.OptionsBehavior.Editable = false;
            this.gridViewCard.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewCard.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewCard.OptionsView.ShowAutoFilterRow = true;
            // 
            // colOid
            // 
            this.colOid.FieldName = "Oid";
            this.colOid.Name = "colOid";
            // 
            // colCodice
            // 
            this.colCodice.FieldName = "Codice";
            this.colCodice.Name = "colCodice";
            this.colCodice.Visible = true;
            this.colCodice.VisibleIndex = 0;
            // 
            // colTipologiaCard
            // 
            this.colTipologiaCard.FieldName = "TipologiaCard";
            this.colTipologiaCard.Name = "colTipologiaCard";
            this.colTipologiaCard.Visible = true;
            this.colTipologiaCard.VisibleIndex = 1;
            this.colTipologiaCard.Width = 87;
            // 
            // colStatus
            // 
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 2;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Postazione";
            this.gridColumn1.FieldName = "Stampa.Vendita.Postazione.Nome";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Utente";
            this.gridColumn2.FieldName = "Stampa.Vendita.Utente.FullName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 5;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Albergo";
            this.gridColumn3.FieldName = "Albergo.RagioneSociale";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 6;
            this.gridColumn3.Width = 135;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Data Vendita";
            this.gridColumn4.FieldName = "Stampa.Vendita.DataContabile";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumnAssegnataUtente
            // 
            this.gridColumnAssegnataUtente.Caption = "Assegnata";
            this.gridColumnAssegnataUtente.FieldName = "AssegnataUtente.FullName";
            this.gridColumnAssegnataUtente.Name = "gridColumnAssegnataUtente";
            this.gridColumnAssegnataUtente.Visible = true;
            this.gridColumnAssegnataUtente.VisibleIndex = 7;
            // 
            // gridColumnAssegnataStruttura
            // 
            this.gridColumnAssegnataStruttura.Caption = "Assegnata";
            this.gridColumnAssegnataStruttura.FieldName = "AssegnataStruttura.Descrizione";
            this.gridColumnAssegnataStruttura.Name = "gridColumnAssegnataStruttura";
            this.gridColumnAssegnataStruttura.Visible = true;
            this.gridColumnAssegnataStruttura.VisibleIndex = 8;
            // 
            // gridColumnAssegnataIl
            // 
            this.gridColumnAssegnataIl.Caption = "Assegnata Il";
            this.gridColumnAssegnataIl.FieldName = "AssegnataIl";
            this.gridColumnAssegnataIl.Name = "gridColumnAssegnataIl";
            this.gridColumnAssegnataIl.Visible = true;
            this.gridColumnAssegnataIl.VisibleIndex = 9;
            // 
            // RibbonFormElencoCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 543);
            this.Controls.Add(this.gridControlCard);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "RibbonFormElencoCard";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Elenco Card";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.Xpo.UnitOfWork unitOfWork1;
        private DevExpress.XtraGrid.GridControl gridControlCard;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCard;
        private DevExpress.XtraGrid.Columns.GridColumn colOid;
        private DevExpress.XtraGrid.Columns.GridColumn colCodice;
        private DevExpress.XtraGrid.Columns.GridColumn colTipologiaCard;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraBars.BarButtonItem barButtonItemQuery;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCestina;
        private DevExpress.XtraBars.BarButtonItem barButtonItemRecupera;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup Operazioni;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraBars.BarCheckItem barCheckItem2gg;
        private DevExpress.XtraBars.BarCheckItem barCheckItem3gg;
        private DevExpress.XtraBars.BarCheckItem barCheckItem6gg;
        private DevExpress.XtraBars.BarCheckItem barCheckItemNuova;
        private DevExpress.XtraBars.BarCheckItem barCheckItemEmesse;
        private DevExpress.XtraBars.BarCheckItem barCheckItemSoppresse;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAssegnataUtente;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAssegnataStruttura;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAssegnataIl;
        private DevExpress.XtraBars.BarButtonItem barButtonItemStampa;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAssegna;
        private DevExpress.XtraBars.BarEditItem barEditItemDalla;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarEditItem barEditItemAlla;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraBars.BarButtonGroup barButtonGroup1;
        private DevExpress.XtraBars.BarCheckItem barCheckItemAssegnate;
    }
}