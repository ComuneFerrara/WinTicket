namespace WinTicketNext.Storico
{
    partial class RibbonFormVersamenti
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition6 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition7 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition8 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition9 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition10 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.colPosAltriEnti = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContanteAltriEnti = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImportoVersato = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIncassi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipologia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemLookUpEditStruttura = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.barButtonItemRegistraVersamento = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemReport1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemQuery = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemElimina = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItemMese = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.barEditItemAnno = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.barButtonItemReportQ1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemVersamentoAltriEnti = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemVersamentoManuale = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupReports = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupOperazioni = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupAltre = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemDateEditData = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.unitOfWork1 = new DevExpress.Xpo.UnitOfWork(this.components);
            this.xpCollectionVersamenti = new DevExpress.Xpo.XPCollection(this.components);
            this.gridControlVersamenti = new DevExpress.XtraGrid.GridControl();
            this.gridViewVersamenti = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colModificatoDa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModificatoIl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatoDa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatoIl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInizioPeriodo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinePeriodo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataVersamento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuietanza = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barButtonItemCorrispettivi = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditStruttura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditData.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollectionVersamenti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlVersamenti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewVersamenti)).BeginInit();
            this.SuspendLayout();
            // 
            // colPosAltriEnti
            // 
            this.colPosAltriEnti.Caption = "Pos (altri enti)";
            this.colPosAltriEnti.DisplayFormat.FormatString = "c";
            this.colPosAltriEnti.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPosAltriEnti.FieldName = "PosAltriEnti";
            this.colPosAltriEnti.GroupFormat.FormatString = "c";
            this.colPosAltriEnti.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPosAltriEnti.Name = "colPosAltriEnti";
            this.colPosAltriEnti.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PosAltriEnti", "{0:c}")});
            this.colPosAltriEnti.Visible = true;
            this.colPosAltriEnti.VisibleIndex = 9;
            // 
            // colContanteAltriEnti
            // 
            this.colContanteAltriEnti.Caption = "Cont. (altri enti)";
            this.colContanteAltriEnti.DisplayFormat.FormatString = "c";
            this.colContanteAltriEnti.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colContanteAltriEnti.FieldName = "ContanteAltriEnti";
            this.colContanteAltriEnti.GroupFormat.FormatString = "c";
            this.colContanteAltriEnti.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colContanteAltriEnti.Name = "colContanteAltriEnti";
            this.colContanteAltriEnti.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ContanteAltriEnti", "{0:c}")});
            this.colContanteAltriEnti.Visible = true;
            this.colContanteAltriEnti.VisibleIndex = 10;
            // 
            // colImportoVersato
            // 
            this.colImportoVersato.DisplayFormat.FormatString = "c";
            this.colImportoVersato.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImportoVersato.FieldName = "ImportoVersato";
            this.colImportoVersato.GroupFormat.FormatString = "c";
            this.colImportoVersato.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImportoVersato.Name = "colImportoVersato";
            this.colImportoVersato.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImportoVersato", "{0:c}")});
            this.colImportoVersato.Visible = true;
            this.colImportoVersato.VisibleIndex = 8;
            // 
            // colPos
            // 
            this.colPos.DisplayFormat.FormatString = "c";
            this.colPos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPos.FieldName = "Pos";
            this.colPos.GroupFormat.FormatString = "c";
            this.colPos.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPos.Name = "colPos";
            this.colPos.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Pos", "{0:c}")});
            this.colPos.Visible = true;
            this.colPos.VisibleIndex = 7;
            // 
            // colIncassi
            // 
            this.colIncassi.DisplayFormat.FormatString = "c";
            this.colIncassi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colIncassi.FieldName = "Incassi";
            this.colIncassi.GroupFormat.FormatString = "c";
            this.colIncassi.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colIncassi.Name = "colIncassi";
            this.colIncassi.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Incassi", "{0:c}")});
            this.colIncassi.Visible = true;
            this.colIncassi.VisibleIndex = 6;
            // 
            // colTipologia
            // 
            this.colTipologia.FieldName = "Tipologia";
            this.colTipologia.Name = "colTipologia";
            this.colTipologia.Visible = true;
            this.colTipologia.VisibleIndex = 5;
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonText = "XPSoft";
            this.ribbon.ApplicationCaption = "Versamenti";
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barEditItem1,
            this.barButtonItemRegistraVersamento,
            this.barButtonItemReport1,
            this.barButtonItemQuery,
            this.barButtonItemElimina,
            this.barEditItemMese,
            this.barEditItemAnno,
            this.barButtonItemReportQ1,
            this.barButtonItemVersamentoAltriEnti,
            this.barButtonItemVersamentoManuale,
            this.barButtonItemCorrispettivi});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 15;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEditStruttura,
            this.repositoryItemDateEditData,
            this.repositoryItemImageComboBox1,
            this.repositoryItemSpinEdit1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbon.Size = new System.Drawing.Size(1123, 144);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            this.ribbon.ApplicationButtonClick += new System.EventHandler(this.ribbon_ApplicationButtonClick);
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "Struttura:";
            this.barEditItem1.Edit = this.repositoryItemLookUpEditStruttura;
            this.barEditItem1.Id = 1;
            this.barEditItem1.Name = "barEditItem1";
            this.barEditItem1.Width = 200;
            this.barEditItem1.EditValueChanged += new System.EventHandler(this.barEditItem1_EditValueChanged);
            // 
            // repositoryItemLookUpEditStruttura
            // 
            this.repositoryItemLookUpEditStruttura.AutoHeight = false;
            this.repositoryItemLookUpEditStruttura.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditStruttura.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descrizione", "Descrizione")});
            this.repositoryItemLookUpEditStruttura.DisplayMember = "Descrizione";
            this.repositoryItemLookUpEditStruttura.Name = "repositoryItemLookUpEditStruttura";
            this.repositoryItemLookUpEditStruttura.ValueMember = "This";
            // 
            // barButtonItemRegistraVersamento
            // 
            this.barButtonItemRegistraVersamento.Caption = "Registra Versamento";
            this.barButtonItemRegistraVersamento.Glyph = global::WinTicketNext.Properties.Resources.money2_add_BFD_16_P;
            this.barButtonItemRegistraVersamento.Id = 3;
            this.barButtonItemRegistraVersamento.LargeGlyph = global::WinTicketNext.Properties.Resources.money2_add_BFD_32_S;
            this.barButtonItemRegistraVersamento.Name = "barButtonItemRegistraVersamento";
            this.barButtonItemRegistraVersamento.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemRegistraVersamento_ItemClick);
            // 
            // barButtonItemReport1
            // 
            this.barButtonItemReport1.Caption = "Report Mensile";
            this.barButtonItemReport1.Glyph = global::WinTicketNext.Properties.Resources.printer_BF_16_P;
            this.barButtonItemReport1.Id = 4;
            this.barButtonItemReport1.LargeGlyph = global::WinTicketNext.Properties.Resources.printer;
            this.barButtonItemReport1.Name = "barButtonItemReport1";
            this.barButtonItemReport1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemReport1_ItemClick);
            // 
            // barButtonItemQuery
            // 
            this.barButtonItemQuery.Caption = "Query";
            this.barButtonItemQuery.Id = 5;
            this.barButtonItemQuery.LargeGlyph = global::WinTicketNext.Properties.Resources.media_play_green;
            this.barButtonItemQuery.Name = "barButtonItemQuery";
            this.barButtonItemQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemQuery_ItemClick);
            // 
            // barButtonItemElimina
            // 
            this.barButtonItemElimina.Caption = "Elimina Registrazione";
            this.barButtonItemElimina.Glyph = global::WinTicketNext.Properties.Resources.delete_BF_16_P;
            this.barButtonItemElimina.Id = 7;
            this.barButtonItemElimina.LargeGlyph = global::WinTicketNext.Properties.Resources.delete_BF_32_S;
            this.barButtonItemElimina.Name = "barButtonItemElimina";
            this.barButtonItemElimina.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemElimina_ItemClick);
            // 
            // barEditItemMese
            // 
            this.barEditItemMese.Caption = "Mese:";
            this.barEditItemMese.Edit = this.repositoryItemImageComboBox1;
            this.barEditItemMese.Id = 8;
            this.barEditItemMese.Name = "barEditItemMese";
            this.barEditItemMese.Width = 100;
            this.barEditItemMese.EditValueChanged += new System.EventHandler(this.barEditItemMese_EditValueChanged);
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Gennaio", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Febbraio", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Marzo", 3, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Aprile", 4, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Maggio", 5, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Giugno", 6, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Luglio", 7, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Agosto", 8, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Settembre", 9, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Ottobre", 10, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Novembre", 11, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Dicembre", 12, -1)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // barEditItemAnno
            // 
            this.barEditItemAnno.Caption = "Anno:";
            this.barEditItemAnno.Edit = this.repositoryItemSpinEdit1;
            this.barEditItemAnno.Id = 9;
            this.barEditItemAnno.Name = "barEditItemAnno";
            this.barEditItemAnno.Width = 80;
            this.barEditItemAnno.EditValueChanged += new System.EventHandler(this.barEditItemAnno_EditValueChanged);
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit1.DisplayFormat.FormatString = "0000";
            this.repositoryItemSpinEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit1.EditFormat.FormatString = "0000";
            this.repositoryItemSpinEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit1.IsFloatValue = false;
            this.repositoryItemSpinEdit1.Mask.EditMask = "0000";
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // barButtonItemReportQ1
            // 
            this.barButtonItemReportQ1.Caption = "Report Agente Q1";
            this.barButtonItemReportQ1.Glyph = global::WinTicketNext.Properties.Resources.printer_BF_16_P;
            this.barButtonItemReportQ1.Id = 10;
            this.barButtonItemReportQ1.LargeGlyph = global::WinTicketNext.Properties.Resources.printer;
            this.barButtonItemReportQ1.Name = "barButtonItemReportQ1";
            this.barButtonItemReportQ1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemReportQ1_ItemClick);
            // 
            // barButtonItemVersamentoAltriEnti
            // 
            this.barButtonItemVersamentoAltriEnti.Caption = "Versamento ad Altri Enti";
            this.barButtonItemVersamentoAltriEnti.Glyph = global::WinTicketNext.Properties.Resources.users2_OPI_16_P;
            this.barButtonItemVersamentoAltriEnti.Id = 11;
            this.barButtonItemVersamentoAltriEnti.LargeGlyph = global::WinTicketNext.Properties.Resources.users2;
            this.barButtonItemVersamentoAltriEnti.Name = "barButtonItemVersamentoAltriEnti";
            this.barButtonItemVersamentoAltriEnti.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemVersamentoAltriEnti_ItemClick);
            // 
            // barButtonItemVersamentoManuale
            // 
            this.barButtonItemVersamentoManuale.Caption = "Versamento Manuale";
            this.barButtonItemVersamentoManuale.Glyph = global::WinTicketNext.Properties.Resources.money2_add_BFD_16_P;
            this.barButtonItemVersamentoManuale.Id = 13;
            this.barButtonItemVersamentoManuale.LargeGlyph = global::WinTicketNext.Properties.Resources.money2_add_BFD_32_S;
            this.barButtonItemVersamentoManuale.Name = "barButtonItemVersamentoManuale";
            this.barButtonItemVersamentoManuale.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemVersamentoManuale_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroupReports,
            this.ribbonPageGroupOperazioni,
            this.ribbonPageGroupAltre});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Versamenti";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barEditItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.barEditItemMese, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.barEditItemAnno);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemQuery, true);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Parametri di selezione";
            // 
            // ribbonPageGroupReports
            // 
            this.ribbonPageGroupReports.ItemLinks.Add(this.barButtonItemReport1);
            this.ribbonPageGroupReports.ItemLinks.Add(this.barButtonItemReportQ1);
            this.ribbonPageGroupReports.ItemLinks.Add(this.barButtonItemCorrispettivi);
            this.ribbonPageGroupReports.Name = "ribbonPageGroupReports";
            this.ribbonPageGroupReports.Text = "Reports";
            // 
            // ribbonPageGroupOperazioni
            // 
            this.ribbonPageGroupOperazioni.ItemLinks.Add(this.barButtonItemRegistraVersamento);
            this.ribbonPageGroupOperazioni.ItemLinks.Add(this.barButtonItemVersamentoManuale);
            this.ribbonPageGroupOperazioni.ItemLinks.Add(this.barButtonItemVersamentoAltriEnti);
            this.ribbonPageGroupOperazioni.Name = "ribbonPageGroupOperazioni";
            this.ribbonPageGroupOperazioni.Text = "Operazioni";
            // 
            // ribbonPageGroupAltre
            // 
            this.ribbonPageGroupAltre.ItemLinks.Add(this.barButtonItemElimina);
            this.ribbonPageGroupAltre.Name = "ribbonPageGroupAltre";
            this.ribbonPageGroupAltre.Text = "Altre Cose";
            // 
            // repositoryItemDateEditData
            // 
            this.repositoryItemDateEditData.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.repositoryItemDateEditData.AutoHeight = false;
            this.repositoryItemDateEditData.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEditData.Name = "repositoryItemDateEditData";
            this.repositoryItemDateEditData.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 480);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1123, 31);
            // 
            // unitOfWork1
            // 
            this.unitOfWork1.TrackPropertiesModifications = false;
            // 
            // xpCollectionVersamenti
            // 
            this.xpCollectionVersamenti.CriteriaString = "[Oid] Is Null";
            this.xpCollectionVersamenti.ObjectType = typeof(Musei.Module.Versamento);
            this.xpCollectionVersamenti.Session = this.unitOfWork1;
            // 
            // gridControlVersamenti
            // 
            this.gridControlVersamenti.DataSource = this.xpCollectionVersamenti;
            this.gridControlVersamenti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlVersamenti.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControlVersamenti.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControlVersamenti.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControlVersamenti.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControlVersamenti.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControlVersamenti.Location = new System.Drawing.Point(0, 144);
            this.gridControlVersamenti.MainView = this.gridViewVersamenti;
            this.gridControlVersamenti.MenuManager = this.ribbon;
            this.gridControlVersamenti.Name = "gridControlVersamenti";
            this.gridControlVersamenti.ShowOnlyPredefinedDetails = true;
            this.gridControlVersamenti.Size = new System.Drawing.Size(1123, 336);
            this.gridControlVersamenti.TabIndex = 2;
            this.gridControlVersamenti.UseEmbeddedNavigator = true;
            this.gridControlVersamenti.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewVersamenti});
            this.gridControlVersamenti.DoubleClick += new System.EventHandler(this.gridControlVersamenti_DoubleClick);
            // 
            // gridViewVersamenti
            // 
            this.gridViewVersamenti.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gridViewVersamenti.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(153)))), ((int)(((byte)(182)))));
            this.gridViewVersamenti.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gridViewVersamenti.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gridViewVersamenti.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridViewVersamenti.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridViewVersamenti.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridViewVersamenti.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridViewVersamenti.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.White;
            this.gridViewVersamenti.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(215)))));
            this.gridViewVersamenti.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.White;
            this.gridViewVersamenti.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridViewVersamenti.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridViewVersamenti.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridViewVersamenti.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridViewVersamenti.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridViewVersamenti.Appearance.Empty.BackColor = System.Drawing.Color.White;
            this.gridViewVersamenti.Appearance.Empty.Options.UseBackColor = true;
            this.gridViewVersamenti.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gridViewVersamenti.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewVersamenti.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridViewVersamenti.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridViewVersamenti.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gridViewVersamenti.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(153)))), ((int)(((byte)(182)))));
            this.gridViewVersamenti.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gridViewVersamenti.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridViewVersamenti.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridViewVersamenti.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridViewVersamenti.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(131)))), ((int)(((byte)(161)))));
            this.gridViewVersamenti.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White;
            this.gridViewVersamenti.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridViewVersamenti.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridViewVersamenti.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(148)))));
            this.gridViewVersamenti.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridViewVersamenti.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(180)))), ((int)(((byte)(191)))));
            this.gridViewVersamenti.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewVersamenti.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewVersamenti.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewVersamenti.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gridViewVersamenti.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(153)))), ((int)(((byte)(182)))));
            this.gridViewVersamenti.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gridViewVersamenti.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridViewVersamenti.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridViewVersamenti.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridViewVersamenti.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridViewVersamenti.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridViewVersamenti.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.gridViewVersamenti.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridViewVersamenti.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridViewVersamenti.Appearance.GroupButton.Options.UseForeColor = true;
            this.gridViewVersamenti.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridViewVersamenti.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridViewVersamenti.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridViewVersamenti.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridViewVersamenti.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridViewVersamenti.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridViewVersamenti.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(131)))), ((int)(((byte)(161)))));
            this.gridViewVersamenti.Appearance.GroupPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gridViewVersamenti.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridViewVersamenti.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridViewVersamenti.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridViewVersamenti.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridViewVersamenti.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridViewVersamenti.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewVersamenti.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridViewVersamenti.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridViewVersamenti.Appearance.GroupRow.Options.UseFont = true;
            this.gridViewVersamenti.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridViewVersamenti.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gridViewVersamenti.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(153)))), ((int)(((byte)(182)))));
            this.gridViewVersamenti.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gridViewVersamenti.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridViewVersamenti.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridViewVersamenti.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridViewVersamenti.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridViewVersamenti.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewVersamenti.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(226)))));
            this.gridViewVersamenti.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(131)))), ((int)(((byte)(161)))));
            this.gridViewVersamenti.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridViewVersamenti.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridViewVersamenti.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(164)))), ((int)(((byte)(188)))));
            this.gridViewVersamenti.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridViewVersamenti.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.gridViewVersamenti.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewVersamenti.Appearance.OddRow.Options.UseBackColor = true;
            this.gridViewVersamenti.Appearance.OddRow.Options.UseForeColor = true;
            this.gridViewVersamenti.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.gridViewVersamenti.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(165)))), ((int)(((byte)(177)))));
            this.gridViewVersamenti.Appearance.Preview.Options.UseBackColor = true;
            this.gridViewVersamenti.Appearance.Preview.Options.UseForeColor = true;
            this.gridViewVersamenti.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.gridViewVersamenti.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridViewVersamenti.Appearance.Row.Options.UseBackColor = true;
            this.gridViewVersamenti.Appearance.Row.Options.UseForeColor = true;
            this.gridViewVersamenti.Appearance.RowSeparator.BackColor = System.Drawing.Color.White;
            this.gridViewVersamenti.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridViewVersamenti.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(205)))));
            this.gridViewVersamenti.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewVersamenti.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewVersamenti.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridViewVersamenti.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(164)))), ((int)(((byte)(188)))));
            this.gridViewVersamenti.Appearance.VertLine.Options.UseBackColor = true;
            this.gridViewVersamenti.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colModificatoDa,
            this.colModificatoIl,
            this.colCreatoDa,
            this.colCreatoIl,
            this.gridColumn1,
            this.colInizioPeriodo,
            this.colFinePeriodo,
            this.colDataVersamento,
            this.colTipologia,
            this.colIncassi,
            this.colPos,
            this.colImportoVersato,
            this.colPosAltriEnti,
            this.colContanteAltriEnti,
            this.colQuietanza,
            this.gridColumn2});
            styleFormatCondition6.Appearance.ForeColor = System.Drawing.Color.Transparent;
            styleFormatCondition6.Appearance.Options.HighPriority = true;
            styleFormatCondition6.Appearance.Options.UseForeColor = true;
            styleFormatCondition6.Column = this.colPosAltriEnti;
            styleFormatCondition6.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition6.Value1 = new decimal(new int[] {
            0,
            0,
            0,
            0});
            styleFormatCondition7.Appearance.ForeColor = System.Drawing.Color.Transparent;
            styleFormatCondition7.Appearance.Options.HighPriority = true;
            styleFormatCondition7.Appearance.Options.UseForeColor = true;
            styleFormatCondition7.Column = this.colContanteAltriEnti;
            styleFormatCondition7.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition7.Value1 = new decimal(new int[] {
            0,
            0,
            0,
            0});
            styleFormatCondition8.Appearance.ForeColor = System.Drawing.Color.Transparent;
            styleFormatCondition8.Appearance.Options.HighPriority = true;
            styleFormatCondition8.Appearance.Options.UseForeColor = true;
            styleFormatCondition8.Column = this.colImportoVersato;
            styleFormatCondition8.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition8.Value1 = new decimal(new int[] {
            0,
            0,
            0,
            0});
            styleFormatCondition9.Appearance.ForeColor = System.Drawing.Color.Transparent;
            styleFormatCondition9.Appearance.Options.HighPriority = true;
            styleFormatCondition9.Appearance.Options.UseForeColor = true;
            styleFormatCondition9.Column = this.colPos;
            styleFormatCondition9.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition9.Value1 = new decimal(new int[] {
            0,
            0,
            0,
            0});
            styleFormatCondition10.Appearance.ForeColor = System.Drawing.Color.Transparent;
            styleFormatCondition10.Appearance.Options.HighPriority = true;
            styleFormatCondition10.Appearance.Options.UseForeColor = true;
            styleFormatCondition10.Column = this.colIncassi;
            styleFormatCondition10.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition10.Value1 = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.gridViewVersamenti.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition6,
            styleFormatCondition7,
            styleFormatCondition8,
            styleFormatCondition9,
            styleFormatCondition10});
            this.gridViewVersamenti.GridControl = this.gridControlVersamenti;
            this.gridViewVersamenti.Name = "gridViewVersamenti";
            this.gridViewVersamenti.OptionsBehavior.Editable = false;
            this.gridViewVersamenti.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewVersamenti.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewVersamenti.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewVersamenti.OptionsView.ShowFooter = true;
            this.gridViewVersamenti.OptionsView.ShowGroupPanel = false;
            this.gridViewVersamenti.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colFinePeriodo, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDataVersamento, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colModificatoDa
            // 
            this.colModificatoDa.FieldName = "ModificatoDa";
            this.colModificatoDa.Name = "colModificatoDa";
            // 
            // colModificatoIl
            // 
            this.colModificatoIl.FieldName = "ModificatoIl";
            this.colModificatoIl.Name = "colModificatoIl";
            // 
            // colCreatoDa
            // 
            this.colCreatoDa.FieldName = "CreatoDa";
            this.colCreatoDa.Name = "colCreatoDa";
            this.colCreatoDa.Visible = true;
            this.colCreatoDa.VisibleIndex = 1;
            // 
            // colCreatoIl
            // 
            this.colCreatoIl.FieldName = "CreatoIl";
            this.colCreatoIl.Name = "colCreatoIl";
            this.colCreatoIl.Visible = true;
            this.colCreatoIl.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Struttura";
            this.gridColumn1.FieldName = "Struttura.Descrizione";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // colInizioPeriodo
            // 
            this.colInizioPeriodo.FieldName = "InizioPeriodo";
            this.colInizioPeriodo.Name = "colInizioPeriodo";
            this.colInizioPeriodo.Visible = true;
            this.colInizioPeriodo.VisibleIndex = 2;
            // 
            // colFinePeriodo
            // 
            this.colFinePeriodo.FieldName = "FinePeriodo";
            this.colFinePeriodo.Name = "colFinePeriodo";
            this.colFinePeriodo.Visible = true;
            this.colFinePeriodo.VisibleIndex = 3;
            // 
            // colDataVersamento
            // 
            this.colDataVersamento.FieldName = "DataVersamento";
            this.colDataVersamento.Name = "colDataVersamento";
            this.colDataVersamento.Visible = true;
            this.colDataVersamento.VisibleIndex = 4;
            // 
            // colQuietanza
            // 
            this.colQuietanza.AppearanceCell.Options.UseTextOptions = true;
            this.colQuietanza.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colQuietanza.FieldName = "Quietanza";
            this.colQuietanza.Name = "colQuietanza";
            this.colQuietanza.Visible = true;
            this.colQuietanza.VisibleIndex = 11;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Soggetto";
            this.gridColumn2.FieldName = "SoggettoEconomico.RagioneSociale";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 12;
            // 
            // barButtonItemCorrispettivi
            // 
            this.barButtonItemCorrispettivi.Caption = "Registro Corrispettivi";
            this.barButtonItemCorrispettivi.Glyph = global::WinTicketNext.Properties.Resources.printer_BF_16_P;
            this.barButtonItemCorrispettivi.Id = 14;
            this.barButtonItemCorrispettivi.LargeGlyph = global::WinTicketNext.Properties.Resources.printer;
            this.barButtonItemCorrispettivi.Name = "barButtonItemCorrispettivi";
            this.barButtonItemCorrispettivi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemCorrispettivi_ItemClick);
            // 
            // RibbonFormVersamenti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 511);
            this.Controls.Add(this.gridControlVersamenti);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "RibbonFormVersamenti";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Versamenti";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditStruttura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditData.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollectionVersamenti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlVersamenti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewVersamenti)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.Xpo.UnitOfWork unitOfWork1;
        private DevExpress.Xpo.XPCollection xpCollectionVersamenti;
        private DevExpress.XtraGrid.GridControl gridControlVersamenti;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewVersamenti;
        private DevExpress.XtraGrid.Columns.GridColumn colModificatoDa;
        private DevExpress.XtraGrid.Columns.GridColumn colModificatoIl;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatoDa;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatoIl;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colInizioPeriodo;
        private DevExpress.XtraGrid.Columns.GridColumn colFinePeriodo;
        private DevExpress.XtraGrid.Columns.GridColumn colDataVersamento;
        private DevExpress.XtraGrid.Columns.GridColumn colTipologia;
        private DevExpress.XtraGrid.Columns.GridColumn colIncassi;
        private DevExpress.XtraGrid.Columns.GridColumn colPos;
        private DevExpress.XtraGrid.Columns.GridColumn colImportoVersato;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditStruttura;
        private DevExpress.XtraBars.BarButtonItem barButtonItemRegistraVersamento;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupOperazioni;
        private DevExpress.XtraBars.BarButtonItem barButtonItemReport1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemQuery;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEditData;
        private DevExpress.XtraBars.BarButtonItem barButtonItemElimina;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupAltre;
        private DevExpress.XtraBars.BarEditItem barEditItemMese;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraBars.BarEditItem barEditItemAnno;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colPosAltriEnti;
        private DevExpress.XtraGrid.Columns.GridColumn colContanteAltriEnti;
        private DevExpress.XtraBars.BarButtonItem barButtonItemReportQ1;
        private DevExpress.XtraGrid.Columns.GridColumn colQuietanza;
        private DevExpress.XtraBars.BarButtonItem barButtonItemVersamentoAltriEnti;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupReports;
        private DevExpress.XtraBars.BarButtonItem barButtonItemVersamentoManuale;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCorrispettivi;
    }
}