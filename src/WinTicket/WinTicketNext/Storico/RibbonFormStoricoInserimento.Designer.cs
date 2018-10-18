namespace WinTicketNext.Storico
{
    partial class RibbonFormStoricoInserimento
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
            this.unitOfWork1 = new DevExpress.Xpo.UnitOfWork(this.components);
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItemQuery = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItemAlla = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barButtonItemExcel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemStampa = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItemInfo = new DevExpress.XtraBars.BarStaticItem();
            this.barEditItemDalla = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barEditItemIngressi = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemLookUpEditIngresso = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupInvia = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupOperazioni = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageRighe = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlRigheStampa = new DevExpress.XtraGrid.GridControl();
            this.xpCollectionRigaVenditaVariante = new DevExpress.Xpo.XPCollection(this.components);
            this.gridViewRigheStampa = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrezzoUnitario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantita = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrezzoTotale = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.saveFileDialogXls = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditIngresso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPageRighe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRigheStampa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollectionRigaVenditaVariante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRigheStampa)).BeginInit();
            this.SuspendLayout();
            // 
            // unitOfWork1
            // 
            this.unitOfWork1.TrackPropertiesModifications = false;
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonText = "XPSoft";
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barButtonItemQuery,
            this.barEditItemAlla,
            this.barButtonItemExcel,
            this.barButtonItemStampa,
            this.barButtonItemAdd,
            this.barStaticItemInfo,
            this.barEditItemDalla,
            this.barEditItemIngressi});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 17;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemCheckEdit1,
            this.repositoryItemDateEdit2,
            this.repositoryItemLookUpEditIngresso});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(919, 144);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            this.ribbon.ApplicationButtonClick += new System.EventHandler(this.ribbon_ApplicationButtonClick);
            // 
            // barButtonItemQuery
            // 
            this.barButtonItemQuery.Caption = "Esegui Query";
            this.barButtonItemQuery.Id = 0;
            this.barButtonItemQuery.LargeGlyph = global::WinTicketNext.Properties.Resources.media_play_green;
            this.barButtonItemQuery.Name = "barButtonItemQuery";
            this.barButtonItemQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemQuery_ItemClick);
            // 
            // barEditItemAlla
            // 
            this.barEditItemAlla.Caption = "  Alla data:";
            this.barEditItemAlla.Edit = this.repositoryItemDateEdit1;
            this.barEditItemAlla.Id = 6;
            this.barEditItemAlla.Name = "barEditItemAlla";
            this.barEditItemAlla.Width = 120;
            this.barEditItemAlla.EditValueChanged += new System.EventHandler(this.barEditItemAlla_EditValueChanged);
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.ShowWeekNumbers = true;
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // barButtonItemExcel
            // 
            this.barButtonItemExcel.Caption = "Excel";
            this.barButtonItemExcel.Id = 7;
            this.barButtonItemExcel.LargeGlyph = global::WinTicketNext.Properties.Resources.symbol_sum;
            this.barButtonItemExcel.Name = "barButtonItemExcel";
            this.barButtonItemExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemExcel_ItemClick);
            // 
            // barButtonItemStampa
            // 
            this.barButtonItemStampa.Caption = "Stampa Griglia";
            this.barButtonItemStampa.Id = 8;
            this.barButtonItemStampa.LargeGlyph = global::WinTicketNext.Properties.Resources.printer;
            this.barButtonItemStampa.Name = "barButtonItemStampa";
            this.barButtonItemStampa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemStampa_ItemClick);
            // 
            // barButtonItemAdd
            // 
            this.barButtonItemAdd.Caption = "Aggiungi Vendita";
            this.barButtonItemAdd.Glyph = global::WinTicketNext.Properties.Resources.add_BF_32_S;
            this.barButtonItemAdd.Id = 13;
            this.barButtonItemAdd.Name = "barButtonItemAdd";
            this.barButtonItemAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAdd_ItemClick);
            // 
            // barStaticItemInfo
            // 
            this.barStaticItemInfo.Id = 14;
            this.barStaticItemInfo.Name = "barStaticItemInfo";
            this.barStaticItemInfo.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barEditItemDalla
            // 
            this.barEditItemDalla.Caption = "Dalla data:";
            this.barEditItemDalla.Edit = this.repositoryItemDateEdit2;
            this.barEditItemDalla.Id = 15;
            this.barEditItemDalla.Name = "barEditItemDalla";
            this.barEditItemDalla.Width = 120;
            this.barEditItemDalla.EditValueChanged += new System.EventHandler(this.barEditItemDalla_EditValueChanged);
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
            // barEditItemIngressi
            // 
            this.barEditItemIngressi.Caption = "Ingresso:";
            this.barEditItemIngressi.Edit = this.repositoryItemLookUpEditIngresso;
            this.barEditItemIngressi.Id = 16;
            this.barEditItemIngressi.Name = "barEditItemIngressi";
            this.barEditItemIngressi.Width = 200;
            this.barEditItemIngressi.EditValueChanged += new System.EventHandler(this.barEditItemIngressi_EditValueChanged);
            // 
            // repositoryItemLookUpEditIngresso
            // 
            this.repositoryItemLookUpEditIngresso.AutoHeight = false;
            this.repositoryItemLookUpEditIngresso.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditIngresso.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descrizione", "Descrizione", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.repositoryItemLookUpEditIngresso.DisplayMember = "Descrizione";
            this.repositoryItemLookUpEditIngresso.Name = "repositoryItemLookUpEditIngresso";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroupInvia,
            this.ribbonPageGroupOperazioni});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Database";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barEditItemIngressi);
            this.ribbonPageGroup1.ItemLinks.Add(this.barEditItemDalla, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.barEditItemAlla);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemQuery, true);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Storico";
            // 
            // ribbonPageGroupInvia
            // 
            this.ribbonPageGroupInvia.ItemLinks.Add(this.barButtonItemExcel);
            this.ribbonPageGroupInvia.ItemLinks.Add(this.barButtonItemStampa, true);
            this.ribbonPageGroupInvia.Name = "ribbonPageGroupInvia";
            this.ribbonPageGroupInvia.Text = "Invia";
            // 
            // ribbonPageGroupOperazioni
            // 
            this.ribbonPageGroupOperazioni.ItemLinks.Add(this.barButtonItemAdd);
            this.ribbonPageGroupOperazioni.Name = "ribbonPageGroupOperazioni";
            this.ribbonPageGroupOperazioni.Text = "Operazioni";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItemInfo);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 529);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(919, 31);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.xtraTabControl1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 144);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(919, 385);
            this.clientPanel.TabIndex = 2;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPageRighe;
            this.xtraTabControl1.Size = new System.Drawing.Size(919, 385);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageRighe});
            // 
            // xtraTabPageRighe
            // 
            this.xtraTabPageRighe.Controls.Add(this.gridControlRigheStampa);
            this.xtraTabPageRighe.Name = "xtraTabPageRighe";
            this.xtraTabPageRighe.Size = new System.Drawing.Size(913, 357);
            this.xtraTabPageRighe.Text = "Riga Vendita Variante";
            // 
            // gridControlRigheStampa
            // 
            this.gridControlRigheStampa.DataSource = this.xpCollectionRigaVenditaVariante;
            this.gridControlRigheStampa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlRigheStampa.Location = new System.Drawing.Point(0, 0);
            this.gridControlRigheStampa.MainView = this.gridViewRigheStampa;
            this.gridControlRigheStampa.Name = "gridControlRigheStampa";
            this.gridControlRigheStampa.ShowOnlyPredefinedDetails = true;
            this.gridControlRigheStampa.Size = new System.Drawing.Size(913, 357);
            this.gridControlRigheStampa.TabIndex = 0;
            this.gridControlRigheStampa.UseEmbeddedNavigator = true;
            this.gridControlRigheStampa.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewRigheStampa});
            // 
            // xpCollectionRigaVenditaVariante
            // 
            this.xpCollectionRigaVenditaVariante.CriteriaString = "[Oid] Is Null";
            this.xpCollectionRigaVenditaVariante.ObjectType = typeof(Musei.Module.RigaVenditaVariante);
            this.xpCollectionRigaVenditaVariante.Session = this.unitOfWork1;
            // 
            // gridViewRigheStampa
            // 
            this.gridViewRigheStampa.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewRigheStampa.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewRigheStampa.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gridViewRigheStampa.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridViewRigheStampa.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridViewRigheStampa.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridViewRigheStampa.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridViewRigheStampa.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridViewRigheStampa.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridViewRigheStampa.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridViewRigheStampa.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridViewRigheStampa.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridViewRigheStampa.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewRigheStampa.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridViewRigheStampa.Appearance.Empty.Options.UseBackColor = true;
            this.gridViewRigheStampa.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridViewRigheStampa.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridViewRigheStampa.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewRigheStampa.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridViewRigheStampa.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridViewRigheStampa.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridViewRigheStampa.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridViewRigheStampa.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridViewRigheStampa.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gridViewRigheStampa.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridViewRigheStampa.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridViewRigheStampa.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridViewRigheStampa.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewRigheStampa.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridViewRigheStampa.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridViewRigheStampa.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridViewRigheStampa.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridViewRigheStampa.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(114)))), ((int)(((byte)(113)))));
            this.gridViewRigheStampa.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridViewRigheStampa.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridViewRigheStampa.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridViewRigheStampa.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridViewRigheStampa.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridViewRigheStampa.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(192)))), ((int)(((byte)(157)))));
            this.gridViewRigheStampa.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(219)))), ((int)(((byte)(188)))));
            this.gridViewRigheStampa.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewRigheStampa.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewRigheStampa.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridViewRigheStampa.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewRigheStampa.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridViewRigheStampa.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridViewRigheStampa.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridViewRigheStampa.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridViewRigheStampa.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridViewRigheStampa.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridViewRigheStampa.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridViewRigheStampa.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridViewRigheStampa.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridViewRigheStampa.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridViewRigheStampa.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewRigheStampa.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewRigheStampa.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridViewRigheStampa.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridViewRigheStampa.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridViewRigheStampa.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridViewRigheStampa.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            this.gridViewRigheStampa.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridViewRigheStampa.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridViewRigheStampa.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridViewRigheStampa.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridViewRigheStampa.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewRigheStampa.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewRigheStampa.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewRigheStampa.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridViewRigheStampa.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridViewRigheStampa.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridViewRigheStampa.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridViewRigheStampa.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridViewRigheStampa.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridViewRigheStampa.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridViewRigheStampa.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridViewRigheStampa.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewRigheStampa.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridViewRigheStampa.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridViewRigheStampa.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewRigheStampa.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridViewRigheStampa.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridViewRigheStampa.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridViewRigheStampa.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridViewRigheStampa.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridViewRigheStampa.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridViewRigheStampa.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridViewRigheStampa.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewRigheStampa.Appearance.OddRow.Options.UseBackColor = true;
            this.gridViewRigheStampa.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridViewRigheStampa.Appearance.OddRow.Options.UseForeColor = true;
            this.gridViewRigheStampa.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.gridViewRigheStampa.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridViewRigheStampa.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.gridViewRigheStampa.Appearance.Preview.Options.UseBackColor = true;
            this.gridViewRigheStampa.Appearance.Preview.Options.UseFont = true;
            this.gridViewRigheStampa.Appearance.Preview.Options.UseForeColor = true;
            this.gridViewRigheStampa.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridViewRigheStampa.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridViewRigheStampa.Appearance.Row.Options.UseBackColor = true;
            this.gridViewRigheStampa.Appearance.Row.Options.UseForeColor = true;
            this.gridViewRigheStampa.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewRigheStampa.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridViewRigheStampa.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridViewRigheStampa.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(215)))), ((int)(((byte)(188)))));
            this.gridViewRigheStampa.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridViewRigheStampa.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewRigheStampa.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewRigheStampa.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.gridViewRigheStampa.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridViewRigheStampa.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridViewRigheStampa.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridViewRigheStampa.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridViewRigheStampa.Appearance.VertLine.Options.UseBackColor = true;
            this.gridViewRigheStampa.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn6,
            this.colPrezzoUnitario,
            this.colQuantita,
            this.colPrezzoTotale,
            this.gridColumn7,
            this.gridColumn1,
            this.gridColumn5,
            this.gridColumn8});
            this.gridViewRigheStampa.GridControl = this.gridControlRigheStampa;
            this.gridViewRigheStampa.Name = "gridViewRigheStampa";
            this.gridViewRigheStampa.OptionsBehavior.Editable = false;
            this.gridViewRigheStampa.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewRigheStampa.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewRigheStampa.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewRigheStampa.OptionsView.ShowAutoFilterRow = true;
            this.gridViewRigheStampa.OptionsView.ShowFooter = true;
            this.gridViewRigheStampa.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn8, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewRigheStampa.DoubleClick += new System.EventHandler(this.gridViewRigheStampa_DoubleClick);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Postazione";
            this.gridColumn3.FieldName = "Vendita.Postazione.Nome";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Utente";
            this.gridColumn2.FieldName = "Vendita.Utente.FullName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Variante";
            this.gridColumn4.FieldName = "Variante.Descrizione";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Titolo";
            this.gridColumn6.FieldName = "Titolo.Descrizione";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            // 
            // colPrezzoUnitario
            // 
            this.colPrezzoUnitario.Caption = "PrezzoUnitario";
            this.colPrezzoUnitario.DisplayFormat.FormatString = "c";
            this.colPrezzoUnitario.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrezzoUnitario.FieldName = "PrezzoUnitario";
            this.colPrezzoUnitario.GroupFormat.FormatString = "c";
            this.colPrezzoUnitario.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrezzoUnitario.Name = "colPrezzoUnitario";
            this.colPrezzoUnitario.Visible = true;
            this.colPrezzoUnitario.VisibleIndex = 7;
            // 
            // colQuantita
            // 
            this.colQuantita.Caption = "Quantita";
            this.colQuantita.FieldName = "Quantita";
            this.colQuantita.Name = "colQuantita";
            this.colQuantita.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colQuantita.Visible = true;
            this.colQuantita.VisibleIndex = 8;
            // 
            // colPrezzoTotale
            // 
            this.colPrezzoTotale.Caption = "PrezzoTotale";
            this.colPrezzoTotale.DisplayFormat.FormatString = "c";
            this.colPrezzoTotale.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrezzoTotale.FieldName = "PrezzoTotale";
            this.colPrezzoTotale.GroupFormat.FormatString = "c";
            this.colPrezzoTotale.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrezzoTotale.Name = "colPrezzoTotale";
            this.colPrezzoTotale.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PrezzoTotale", "{0:c}")});
            this.colPrezzoTotale.Visible = true;
            this.colPrezzoTotale.VisibleIndex = 9;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Vendita";
            this.gridColumn7.FieldName = "Vendita.CodiceLeggibile";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Data Contabile";
            this.gridColumn1.FieldName = "Vendita";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Struttura";
            this.gridColumn5.FieldName = "Vendita.Struttura.Descrizione";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Data Stampa";
            this.gridColumn8.DisplayFormat.FormatString = "g";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn8.FieldName = "Vendita.DataOraStampa";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            // 
            // saveFileDialogXls
            // 
            this.saveFileDialogXls.DefaultExt = "xls";
            this.saveFileDialogXls.Filter = "File Excel (*.xls)|*.xls|Tutti i file (*.*)|*.*";
            // 
            // RibbonFormStoricoInserimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 560);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "RibbonFormStoricoInserimento";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Elenco Storico (per inserimento)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditIngresso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPageRighe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRigheStampa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollectionRigaVenditaVariante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRigheStampa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private DevExpress.Xpo.UnitOfWork unitOfWork1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageRighe;
        private DevExpress.XtraBars.BarButtonItem barButtonItemQuery;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarEditItem barEditItemAlla;
        private DevExpress.XtraGrid.GridControl gridControlRigheStampa;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRigheStampa;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn colPrezzoUnitario;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantita;
        private DevExpress.XtraGrid.Columns.GridColumn colPrezzoTotale;
        private DevExpress.Xpo.XPCollection xpCollectionRigaVenditaVariante;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraBars.BarButtonItem barButtonItemExcel;
        private DevExpress.XtraBars.BarButtonItem barButtonItemStampa;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupInvia;
        private System.Windows.Forms.SaveFileDialog saveFileDialogXls;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAdd;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupOperazioni;
        private DevExpress.XtraBars.BarStaticItem barStaticItemInfo;
        private DevExpress.XtraBars.BarEditItem barEditItemDalla;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraBars.BarEditItem barEditItemIngressi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditIngresso;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
    }
}