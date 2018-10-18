namespace WinTicketNext
{
    partial class RibbonFormPivotOfferta
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItemExcel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSaveLayout = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemLoadLayout = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonShowFields = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemBestFit = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupOpt = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.pivotGridControlStampe = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField5 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField6 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField7 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.unitOfWork1 = new DevExpress.Xpo.UnitOfWork();
            this.dockPanelGrafico = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.chartControlPivot = new DevExpress.XtraCharts.ChartControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanelFiltro = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.simpleButtonQuery = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.xpCollectionPercorsi = new DevExpress.Xpo.XPCollection();
            this.saveFileDialogXls = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogXML = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogXML = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControlStampe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).BeginInit();
            this.dockPanelGrafico.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlPivot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanelFiltro.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollectionPercorsi)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonText = "XPSoft";
            this.ribbon.ApplicationIcon = global::WinTicketNext.Properties.Resources.Logo;
            // 
            // 
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barButtonItemExcel,
            this.barButtonItemPrint,
            this.barButtonItemSaveLayout,
            this.barButtonItemLoadLayout,
            this.barButtonShowFields,
            this.barButtonItemBestFit});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 15;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbon.SelectedPage = this.ribbonPage1;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(758, 145);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            this.ribbon.ApplicationButtonClick += new System.EventHandler(this.ribbon_ApplicationButtonClick);
            // 
            // barButtonItemExcel
            // 
            this.barButtonItemExcel.Caption = "Excel";
            this.barButtonItemExcel.Id = 0;
            this.barButtonItemExcel.LargeGlyph = global::WinTicketNext.Properties.Resources.symbol_sum;
            this.barButtonItemExcel.Name = "barButtonItemExcel";
            this.barButtonItemExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemExcel_ItemClick);
            // 
            // barButtonItemPrint
            // 
            this.barButtonItemPrint.Caption = "Stampa";
            this.barButtonItemPrint.Id = 1;
            this.barButtonItemPrint.LargeGlyph = global::WinTicketNext.Properties.Resources.printer;
            this.barButtonItemPrint.Name = "barButtonItemPrint";
            this.barButtonItemPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemPrint_ItemClick);
            // 
            // barButtonItemSaveLayout
            // 
            this.barButtonItemSaveLayout.Caption = "Save";
            this.barButtonItemSaveLayout.Id = 4;
            this.barButtonItemSaveLayout.LargeGlyph = global::WinTicketNext.Properties.Resources.floppy_disk_yellow;
            this.barButtonItemSaveLayout.Name = "barButtonItemSaveLayout";
            this.barButtonItemSaveLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSaveLayout_ItemClick);
            // 
            // barButtonItemLoadLayout
            // 
            this.barButtonItemLoadLayout.Caption = "Load";
            this.barButtonItemLoadLayout.Id = 5;
            this.barButtonItemLoadLayout.LargeGlyph = global::WinTicketNext.Properties.Resources.folder_document;
            this.barButtonItemLoadLayout.Name = "barButtonItemLoadLayout";
            this.barButtonItemLoadLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemLoadLayout_ItemClick);
            // 
            // barButtonShowFields
            // 
            this.barButtonShowFields.Caption = "Elenco Campi";
            this.barButtonShowFields.Id = 10;
            this.barButtonShowFields.Name = "barButtonShowFields";
            this.barButtonShowFields.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonShowFields_ItemClick);
            // 
            // barButtonItemBestFit
            // 
            this.barButtonItemBestFit.Caption = "Adatta Colonne";
            this.barButtonItemBestFit.Id = 11;
            this.barButtonItemBestFit.Name = "barButtonItemBestFit";
            this.barButtonItemBestFit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemBestFit_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup1,
            this.ribbonPageGroupOpt});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Pivot Grid";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItemLoadLayout);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItemSaveLayout, true);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Layout";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemExcel);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemPrint, true);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Pivot";
            // 
            // ribbonPageGroupOpt
            // 
            this.ribbonPageGroupOpt.ItemLinks.Add(this.barButtonItemBestFit);
            this.ribbonPageGroupOpt.ItemLinks.Add(this.barButtonShowFields);
            this.ribbonPageGroupOpt.Name = "ribbonPageGroupOpt";
            this.ribbonPageGroupOpt.Text = "Comandi";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 696);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(758, 31);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.pivotGridControlStampe);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(180, 145);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(578, 551);
            this.clientPanel.TabIndex = 2;
            // 
            // pivotGridControlStampe
            // 
            this.pivotGridControlStampe.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.pivotGridControlStampe.Appearance.FieldValueGrandTotal.Options.UseFont = true;
            this.pivotGridControlStampe.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.pivotGridControlStampe.Appearance.FieldValueTotal.Options.UseFont = true;
            this.pivotGridControlStampe.Appearance.GrandTotalCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pivotGridControlStampe.Appearance.GrandTotalCell.Options.UseBackColor = true;
            this.pivotGridControlStampe.Appearance.TotalCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pivotGridControlStampe.Appearance.TotalCell.Options.UseBackColor = true;
            this.pivotGridControlStampe.Cursor = System.Windows.Forms.Cursors.Default;
            this.pivotGridControlStampe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControlStampe.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivotGridField1,
            this.pivotGridField2,
            this.pivotGridField3,
            this.pivotGridField4,
            this.pivotGridField5,
            this.pivotGridField6,
            this.pivotGridField7});
            this.pivotGridControlStampe.Location = new System.Drawing.Point(0, 0);
            this.pivotGridControlStampe.Name = "pivotGridControlStampe";
            this.pivotGridControlStampe.OptionsChartDataSource.FieldValuesProvideMode = DevExpress.XtraPivotGrid.PivotChartFieldValuesProvideMode.DisplayText;
            this.pivotGridControlStampe.OptionsLayout.StoreAllOptions = true;
            this.pivotGridControlStampe.OptionsPrint.PageSettings.Landscape = true;
            this.pivotGridControlStampe.OptionsPrint.PageSettings.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
            this.pivotGridControlStampe.OptionsPrint.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.pivotGridControlStampe.OptionsView.ShowColumnGrandTotalHeader = false;
            this.pivotGridControlStampe.OptionsView.ShowColumnGrandTotals = false;
            this.pivotGridControlStampe.OptionsView.ShowColumnTotals = false;
            this.pivotGridControlStampe.OptionsView.ShowRowGrandTotalHeader = false;
            this.pivotGridControlStampe.OptionsView.ShowRowGrandTotals = false;
            this.pivotGridControlStampe.OptionsView.ShowRowTotals = false;
            this.pivotGridControlStampe.Size = new System.Drawing.Size(578, 551);
            this.pivotGridControlStampe.TabIndex = 0;
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField1.AreaIndex = 1;
            this.pivotGridField1.FieldName = "Titolo";
            this.pivotGridField1.Name = "pivotGridField1";
            // 
            // pivotGridField2
            // 
            this.pivotGridField2.AreaIndex = 0;
            this.pivotGridField2.FieldName = "Gruppo";
            this.pivotGridField2.Name = "pivotGridField2";
            // 
            // pivotGridField3
            // 
            this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField3.AreaIndex = 0;
            this.pivotGridField3.FieldName = "TipologiaUno";
            this.pivotGridField3.Name = "pivotGridField3";
            // 
            // pivotGridField4
            // 
            this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField4.AreaIndex = 1;
            this.pivotGridField4.FieldName = "TipologiaDue";
            this.pivotGridField4.Name = "pivotGridField4";
            // 
            // pivotGridField5
            // 
            this.pivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField5.AreaIndex = 2;
            this.pivotGridField5.FieldName = "TipologiaTre";
            this.pivotGridField5.Name = "pivotGridField5";
            // 
            // pivotGridField6
            // 
            this.pivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField6.AreaIndex = 0;
            this.pivotGridField6.FieldName = "Importo";
            this.pivotGridField6.Name = "pivotGridField6";
            // 
            // pivotGridField7
            // 
            this.pivotGridField7.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField7.AreaIndex = 0;
            this.pivotGridField7.FieldName = "Percorso";
            this.pivotGridField7.Name = "pivotGridField7";
            // 
            // dockPanelGrafico
            // 
            this.dockPanelGrafico.Controls.Add(this.controlContainer1);
            this.dockPanelGrafico.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanelGrafico.ID = new System.Guid("4687cf1d-5f4c-4189-a660-fb5e452d1fd2");
            this.dockPanelGrafico.Location = new System.Drawing.Point(200, 502);
            this.dockPanelGrafico.Name = "dockPanelGrafico";
            this.dockPanelGrafico.OriginalSize = new System.Drawing.Size(758, 200);
            this.dockPanelGrafico.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanelGrafico.SavedIndex = 1;
            this.dockPanelGrafico.Size = new System.Drawing.Size(558, 200);
            this.dockPanelGrafico.Text = "Chart";
            this.dockPanelGrafico.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // controlContainer1
            // 
            this.controlContainer1.Controls.Add(this.chartControlPivot);
            this.controlContainer1.Location = new System.Drawing.Point(3, 25);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(552, 172);
            this.controlContainer1.TabIndex = 0;
            // 
            // chartControlPivot
            // 
            this.chartControlPivot.DataSource = this.pivotGridControlStampe;
            xyDiagram1.AxisX.Label.Staggered = true;
            xyDiagram1.AxisX.Range.ScrollingRange.SideMarginsEnabled = true;
            xyDiagram1.AxisX.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Range.ScrollingRange.SideMarginsEnabled = true;
            xyDiagram1.AxisY.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControlPivot.Diagram = xyDiagram1;
            this.chartControlPivot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControlPivot.Enabled = false;
            this.chartControlPivot.Legend.MaxHorizontalPercentage = 30D;
            this.chartControlPivot.Location = new System.Drawing.Point(0, 0);
            this.chartControlPivot.Name = "chartControlPivot";
            this.chartControlPivot.SeriesDataMember = "Series";
            this.chartControlPivot.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControlPivot.SeriesTemplate.ArgumentDataMember = "Arguments";
            sideBySideBarSeriesLabel1.LineVisible = true;
            this.chartControlPivot.SeriesTemplate.Label = sideBySideBarSeriesLabel1;
            this.chartControlPivot.SeriesTemplate.ValueDataMembersSerializable = "Values";
            this.chartControlPivot.Size = new System.Drawing.Size(552, 172);
            this.chartControlPivot.TabIndex = 0;
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanelGrafico});
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanelFiltro});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanelFiltro
            // 
            this.dockPanelFiltro.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.dockPanelFiltro.Appearance.Options.UseBackColor = true;
            this.dockPanelFiltro.Controls.Add(this.dockPanel1_Container);
            this.dockPanelFiltro.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanelFiltro.ID = new System.Guid("b27d6157-0761-400f-8b25-71104558d951");
            this.dockPanelFiltro.Location = new System.Drawing.Point(0, 145);
            this.dockPanelFiltro.Name = "dockPanelFiltro";
            this.dockPanelFiltro.OriginalSize = new System.Drawing.Size(180, 200);
            this.dockPanelFiltro.Size = new System.Drawing.Size(180, 551);
            this.dockPanelFiltro.Text = "Filtro";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.simpleButtonQuery);
            this.dockPanel1_Container.Controls.Add(this.labelControl3);
            this.dockPanel1_Container.Controls.Add(this.checkedListBoxControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(172, 524);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // simpleButtonQuery
            // 
            this.simpleButtonQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonQuery.Image = global::WinTicketNext.Properties.Resources.media_play_green;
            this.simpleButtonQuery.Location = new System.Drawing.Point(68, 307);
            this.simpleButtonQuery.Name = "simpleButtonQuery";
            this.simpleButtonQuery.Size = new System.Drawing.Size(100, 40);
            this.simpleButtonQuery.TabIndex = 6;
            this.simpleButtonQuery.Text = "Esegui";
            this.simpleButtonQuery.Click += new System.EventHandler(this.simpleButtonQuery_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(38, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Percorsi";
            // 
            // checkedListBoxControl1
            // 
            this.checkedListBoxControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxControl1.CheckOnClick = true;
            this.checkedListBoxControl1.DataSource = this.xpCollectionPercorsi;
            this.checkedListBoxControl1.DisplayMember = "Descrizione";
            this.checkedListBoxControl1.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.checkedListBoxControl1.Location = new System.Drawing.Point(9, 23);
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.Size = new System.Drawing.Size(159, 278);
            this.checkedListBoxControl1.TabIndex = 4;
            this.checkedListBoxControl1.ValueMember = "This";
            // 
            // xpCollectionPercorsi
            // 
            this.xpCollectionPercorsi.DisplayableProperties = "This;Oid;ModificatoDa;ModificatoIl;Descrizione;Ingressi;Biglietti";
            this.xpCollectionPercorsi.ObjectType = typeof(Musei.Module.Percorso);
            this.xpCollectionPercorsi.Session = this.unitOfWork1;
            this.xpCollectionPercorsi.Sorting.AddRange(new DevExpress.Xpo.SortProperty[] {
            new DevExpress.Xpo.SortProperty("[Descrizione]", DevExpress.Xpo.DB.SortingDirection.Ascending)});
            // 
            // saveFileDialogXls
            // 
            this.saveFileDialogXls.DefaultExt = "xls";
            this.saveFileDialogXls.Filter = "File Excel (*.xls)|*.xls|Tutti i file (*.*)|*.*";
            // 
            // openFileDialogXML
            // 
            this.openFileDialogXML.Filter = "File XML (*.xml)|*.xml|Tutti i file (*.*)|*.*";
            // 
            // saveFileDialogXML
            // 
            this.saveFileDialogXML.Filter = "File XML (*.xml)|*.xml|Tutti i file (*.*)|*.*";
            // 
            // RibbonFormPivotOfferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 727);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.dockPanelFiltro);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "RibbonFormPivotOfferta";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Pivot Offerta Economica";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControlStampe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).EndInit();
            this.dockPanelGrafico.ResumeLayout(false);
            this.controlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlPivot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanelFiltro.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanel1_Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollectionPercorsi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private DevExpress.Xpo.UnitOfWork unitOfWork1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelFiltro;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControlStampe;
        private DevExpress.XtraBars.BarButtonItem barButtonItemExcel;
        private DevExpress.XtraBars.BarButtonItem barButtonItemPrint;
        private System.Windows.Forms.SaveFileDialog saveFileDialogXls;
        private DevExpress.XtraEditors.SimpleButton simpleButtonQuery;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
        private DevExpress.Xpo.XPCollection xpCollectionPercorsi;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSaveLayout;
        private DevExpress.XtraBars.BarButtonItem barButtonItemLoadLayout;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private System.Windows.Forms.OpenFileDialog openFileDialogXML;
        private System.Windows.Forms.SaveFileDialog saveFileDialogXML;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupOpt;
        private DevExpress.XtraBars.BarButtonItem barButtonShowFields;
        private DevExpress.XtraBars.BarButtonItem barButtonItemBestFit;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelGrafico;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraCharts.ChartControl chartControlPivot;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField5;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField6;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField7;
    }
}