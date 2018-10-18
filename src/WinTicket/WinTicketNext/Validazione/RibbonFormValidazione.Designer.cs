namespace WinTicketNext.Validazione
{
    partial class RibbonFormValidazione
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlIngressi = new DevExpress.XtraGrid.GridControl();
            this.gridViewIngressi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTotaleIngressi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalePersone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnIngresso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItemIngresso = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAltre = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItemInfo = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItemStampaMyFE = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupIngressi = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.unitOfWork1 = new DevExpress.Xpo.UnitOfWork(this.components);
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.panelControlInfo = new DevExpress.XtraEditors.PanelControl();
            this.groupControlDue = new DevExpress.XtraEditors.GroupControl();
            this.groupControlUno = new DevExpress.XtraEditors.GroupControl();
            this.labelControlStatus = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.dateEditEnd = new DevExpress.XtraEditors.DateEdit();
            this.dateEditStart = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.textEditProg = new DevExpress.XtraEditors.TextEdit();
            this.textEditBarCode = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButtonRegistra = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonVerifica = new DevExpress.XtraEditors.SimpleButton();
            this.buttonEditCodice = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.timerTick = new System.Windows.Forms.Timer(this.components);
            this.textEditIntestazioneCard = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlIngressi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewIngressi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlInfo)).BeginInit();
            this.panelControlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDue)).BeginInit();
            this.groupControlDue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlUno)).BeginInit();
            this.groupControlUno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditProg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBarCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditCodice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIntestazioneCard.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.GridControl = this.gridControlIngressi;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Creato Da";
            this.gridColumn3.FieldName = "CreatoDa";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Entrata";
            this.gridColumn1.DisplayFormat.FormatString = "g";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn1.FieldName = "DataOraEntrata";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Quantita";
            this.gridColumn2.FieldName = "Quantita";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridControlIngressi
            // 
            this.gridControlIngressi.DataMember = "RigheStampaIngresso";
            this.gridControlIngressi.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode2.LevelTemplate = this.gridView1;
            gridLevelNode2.RelationName = "Entrate";
            this.gridControlIngressi.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gridControlIngressi.Location = new System.Drawing.Point(2, 21);
            this.gridControlIngressi.MainView = this.gridViewIngressi;
            this.gridControlIngressi.MenuManager = this.ribbon;
            this.gridControlIngressi.Name = "gridControlIngressi";
            this.gridControlIngressi.ShowOnlyPredefinedDetails = true;
            this.gridControlIngressi.Size = new System.Drawing.Size(863, 230);
            this.gridControlIngressi.TabIndex = 0;
            this.gridControlIngressi.TabStop = false;
            this.gridControlIngressi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewIngressi,
            this.gridView1});
            // 
            // gridViewIngressi
            // 
            this.gridViewIngressi.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewIngressi.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewIngressi.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gridViewIngressi.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridViewIngressi.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridViewIngressi.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridViewIngressi.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridViewIngressi.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridViewIngressi.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridViewIngressi.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridViewIngressi.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridViewIngressi.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridViewIngressi.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewIngressi.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridViewIngressi.Appearance.Empty.Options.UseBackColor = true;
            this.gridViewIngressi.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridViewIngressi.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridViewIngressi.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewIngressi.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridViewIngressi.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridViewIngressi.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridViewIngressi.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridViewIngressi.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridViewIngressi.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gridViewIngressi.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridViewIngressi.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridViewIngressi.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridViewIngressi.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewIngressi.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridViewIngressi.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridViewIngressi.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridViewIngressi.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridViewIngressi.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(114)))), ((int)(((byte)(113)))));
            this.gridViewIngressi.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridViewIngressi.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridViewIngressi.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridViewIngressi.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridViewIngressi.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridViewIngressi.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(192)))), ((int)(((byte)(157)))));
            this.gridViewIngressi.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(219)))), ((int)(((byte)(188)))));
            this.gridViewIngressi.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewIngressi.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewIngressi.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridViewIngressi.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewIngressi.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridViewIngressi.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridViewIngressi.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridViewIngressi.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridViewIngressi.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridViewIngressi.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridViewIngressi.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridViewIngressi.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridViewIngressi.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridViewIngressi.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridViewIngressi.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewIngressi.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewIngressi.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridViewIngressi.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridViewIngressi.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridViewIngressi.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridViewIngressi.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            this.gridViewIngressi.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridViewIngressi.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridViewIngressi.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridViewIngressi.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridViewIngressi.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewIngressi.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewIngressi.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewIngressi.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridViewIngressi.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridViewIngressi.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridViewIngressi.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridViewIngressi.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridViewIngressi.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridViewIngressi.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridViewIngressi.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridViewIngressi.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewIngressi.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridViewIngressi.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridViewIngressi.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewIngressi.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridViewIngressi.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridViewIngressi.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridViewIngressi.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridViewIngressi.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridViewIngressi.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridViewIngressi.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridViewIngressi.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewIngressi.Appearance.OddRow.Options.UseBackColor = true;
            this.gridViewIngressi.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridViewIngressi.Appearance.OddRow.Options.UseForeColor = true;
            this.gridViewIngressi.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.gridViewIngressi.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridViewIngressi.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.gridViewIngressi.Appearance.Preview.Options.UseBackColor = true;
            this.gridViewIngressi.Appearance.Preview.Options.UseFont = true;
            this.gridViewIngressi.Appearance.Preview.Options.UseForeColor = true;
            this.gridViewIngressi.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridViewIngressi.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridViewIngressi.Appearance.Row.Options.UseBackColor = true;
            this.gridViewIngressi.Appearance.Row.Options.UseForeColor = true;
            this.gridViewIngressi.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewIngressi.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridViewIngressi.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridViewIngressi.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(215)))), ((int)(((byte)(188)))));
            this.gridViewIngressi.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridViewIngressi.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewIngressi.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewIngressi.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.gridViewIngressi.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridViewIngressi.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridViewIngressi.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridViewIngressi.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridViewIngressi.Appearance.VertLine.Options.UseBackColor = true;
            this.gridViewIngressi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTotaleIngressi,
            this.colTotalePersone,
            this.gridColumnIngresso});
            this.gridViewIngressi.GridControl = this.gridControlIngressi;
            this.gridViewIngressi.Name = "gridViewIngressi";
            this.gridViewIngressi.OptionsBehavior.Editable = false;
            this.gridViewIngressi.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewIngressi.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridViewIngressi.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewIngressi.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewIngressi.OptionsView.ShowGroupPanel = false;
            // 
            // colTotaleIngressi
            // 
            this.colTotaleIngressi.Caption = "Ingressi Registrati";
            this.colTotaleIngressi.FieldName = "TotaleIngressi";
            this.colTotaleIngressi.Name = "colTotaleIngressi";
            this.colTotaleIngressi.Visible = true;
            this.colTotaleIngressi.VisibleIndex = 2;
            // 
            // colTotalePersone
            // 
            this.colTotalePersone.Caption = "Qtà Prevista";
            this.colTotalePersone.FieldName = "TotalePersone";
            this.colTotalePersone.Name = "colTotalePersone";
            this.colTotalePersone.Visible = true;
            this.colTotalePersone.VisibleIndex = 1;
            // 
            // gridColumnIngresso
            // 
            this.gridColumnIngresso.Caption = "Ingresso";
            this.gridColumnIngresso.FieldName = "Ingresso.Descrizione";
            this.gridColumnIngresso.Name = "gridColumnIngresso";
            this.gridColumnIngresso.Visible = true;
            this.gridColumnIngresso.VisibleIndex = 0;
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonText = "XPSoft";
            this.ribbon.ApplicationIcon = global::WinTicketNext.Properties.Resources.Logo;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barButtonItemIngresso,
            this.barButtonItemAltre,
            this.barStaticItemInfo,
            this.barButtonItemStampaMyFE});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 9;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(871, 144);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            this.ribbon.ApplicationButtonClick += new System.EventHandler(this.ribbon_ApplicationButtonClick);
            // 
            // barButtonItemIngresso
            // 
            this.barButtonItemIngresso.Caption = "Registra Ingresso";
            this.barButtonItemIngresso.Id = 0;
            this.barButtonItemIngresso.LargeGlyph = global::WinTicketNext.Properties.Resources.add_BF_32_S;
            this.barButtonItemIngresso.Name = "barButtonItemIngresso";
            // 
            // barButtonItemAltre
            // 
            this.barButtonItemAltre.Caption = "Altre Operazioni";
            this.barButtonItemAltre.Id = 1;
            this.barButtonItemAltre.LargeGlyph = global::WinTicketNext.Properties.Resources.document_edit;
            this.barButtonItemAltre.Name = "barButtonItemAltre";
            this.barButtonItemAltre.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAnnulla_ItemClick);
            // 
            // barStaticItemInfo
            // 
            this.barStaticItemInfo.Glyph = global::WinTicketNext.Properties.Resources.about_BF_16_P;
            this.barStaticItemInfo.Id = 7;
            this.barStaticItemInfo.Name = "barStaticItemInfo";
            this.barStaticItemInfo.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonItemStampaMyFE
            // 
            this.barButtonItemStampaMyFE.Caption = "Stampa per Card MyFE";
            this.barButtonItemStampaMyFE.Enabled = false;
            this.barButtonItemStampaMyFE.Id = 8;
            this.barButtonItemStampaMyFE.LargeGlyph = global::WinTicketNext.Properties.Resources.printer;
            this.barButtonItemStampaMyFE.Name = "barButtonItemStampaMyFE";
            this.barButtonItemStampaMyFE.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemStampaMyFE_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroupIngressi,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Biglietto";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemAltre, true);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Operazioni";
            // 
            // ribbonPageGroupIngressi
            // 
            this.ribbonPageGroupIngressi.Name = "ribbonPageGroupIngressi";
            this.ribbonPageGroupIngressi.Text = "Ingressi da registare";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItemStampaMyFE);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "MyFE";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItemInfo);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 618);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(871, 31);
            // 
            // unitOfWork1
            // 
            this.unitOfWork1.TrackPropertiesModifications = false;
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.panelControlInfo);
            this.clientPanel.Controls.Add(this.groupControl1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 144);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(871, 474);
            this.clientPanel.TabIndex = 2;
            // 
            // panelControlInfo
            // 
            this.panelControlInfo.Controls.Add(this.groupControlDue);
            this.panelControlInfo.Controls.Add(this.groupControlUno);
            this.panelControlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlInfo.Location = new System.Drawing.Point(0, 117);
            this.panelControlInfo.Name = "panelControlInfo";
            this.panelControlInfo.Size = new System.Drawing.Size(871, 357);
            this.panelControlInfo.TabIndex = 3;
            // 
            // groupControlDue
            // 
            this.groupControlDue.Controls.Add(this.gridControlIngressi);
            this.groupControlDue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlDue.Location = new System.Drawing.Point(2, 102);
            this.groupControlDue.Name = "groupControlDue";
            this.groupControlDue.Size = new System.Drawing.Size(867, 253);
            this.groupControlDue.TabIndex = 2;
            this.groupControlDue.Text = "Dettagli Ingressi";
            // 
            // groupControlUno
            // 
            this.groupControlUno.Controls.Add(this.textEditIntestazioneCard);
            this.groupControlUno.Controls.Add(this.labelControlStatus);
            this.groupControlUno.Controls.Add(this.labelControl6);
            this.groupControlUno.Controls.Add(this.textEdit1);
            this.groupControlUno.Controls.Add(this.dateEditEnd);
            this.groupControlUno.Controls.Add(this.dateEditStart);
            this.groupControlUno.Controls.Add(this.labelControl5);
            this.groupControlUno.Controls.Add(this.labelControl4);
            this.groupControlUno.Controls.Add(this.textEditProg);
            this.groupControlUno.Controls.Add(this.textEditBarCode);
            this.groupControlUno.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlUno.Location = new System.Drawing.Point(2, 2);
            this.groupControlUno.Name = "groupControlUno";
            this.groupControlUno.Size = new System.Drawing.Size(867, 100);
            this.groupControlUno.TabIndex = 1;
            this.groupControlUno.Text = "Informazioni di Base";
            // 
            // labelControlStatus
            // 
            this.labelControlStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlStatus.Location = new System.Drawing.Point(479, 52);
            this.labelControlStatus.Name = "labelControlStatus";
            this.labelControlStatus.Size = new System.Drawing.Size(220, 16);
            this.labelControlStatus.TabIndex = 8;
            this.labelControlStatus.Text = "no ingressi per questa postazione";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 54);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(55, 13);
            this.labelControl6.TabIndex = 7;
            this.labelControl6.Text = "Emesso da:";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(73, 51);
            this.textEdit1.MenuManager = this.ribbon;
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Properties.ReadOnly = true;
            this.textEdit1.Size = new System.Drawing.Size(400, 20);
            this.textEdit1.TabIndex = 6;
            // 
            // dateEditEnd
            // 
            this.dateEditEnd.EditValue = null;
            this.dateEditEnd.Location = new System.Drawing.Point(479, 25);
            this.dateEditEnd.MenuManager = this.ribbon;
            this.dateEditEnd.Name = "dateEditEnd";
            this.dateEditEnd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEditEnd.Properties.Appearance.Options.UseFont = true;
            this.dateEditEnd.Properties.Appearance.Options.UseTextOptions = true;
            this.dateEditEnd.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dateEditEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEnd.Properties.ReadOnly = true;
            this.dateEditEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditEnd.Size = new System.Drawing.Size(100, 20);
            this.dateEditEnd.TabIndex = 5;
            // 
            // dateEditStart
            // 
            this.dateEditStart.EditValue = null;
            this.dateEditStart.Location = new System.Drawing.Point(373, 25);
            this.dateEditStart.MenuManager = this.ribbon;
            this.dateEditStart.Name = "dateEditStart";
            this.dateEditStart.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEditStart.Properties.Appearance.Options.UseFont = true;
            this.dateEditStart.Properties.Appearance.Options.UseTextOptions = true;
            this.dateEditStart.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dateEditStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStart.Properties.ReadOnly = true;
            this.dateEditStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditStart.Size = new System.Drawing.Size(100, 20);
            this.dateEditStart.TabIndex = 4;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(302, 28);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(69, 13);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "Valido Dal / Al:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 28);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 13);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Codice:";
            // 
            // textEditProg
            // 
            this.textEditProg.EditValue = "info";
            this.textEditProg.Location = new System.Drawing.Point(174, 25);
            this.textEditProg.MenuManager = this.ribbon;
            this.textEditProg.Name = "textEditProg";
            this.textEditProg.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditProg.Properties.Appearance.Options.UseFont = true;
            this.textEditProg.Properties.Appearance.Options.UseTextOptions = true;
            this.textEditProg.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEditProg.Properties.ReadOnly = true;
            this.textEditProg.Size = new System.Drawing.Size(109, 20);
            this.textEditProg.TabIndex = 1;
            // 
            // textEditBarCode
            // 
            this.textEditBarCode.EditValue = "info";
            this.textEditBarCode.Location = new System.Drawing.Point(73, 25);
            this.textEditBarCode.MenuManager = this.ribbon;
            this.textEditBarCode.Name = "textEditBarCode";
            this.textEditBarCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditBarCode.Properties.Appearance.Options.UseFont = true;
            this.textEditBarCode.Properties.Appearance.Options.UseTextOptions = true;
            this.textEditBarCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEditBarCode.Properties.ReadOnly = true;
            this.textEditBarCode.Size = new System.Drawing.Size(95, 20);
            this.textEditBarCode.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButtonRegistra);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.spinEdit1);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.simpleButtonVerifica);
            this.groupControl1.Controls.Add(this.buttonEditCodice);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(871, 117);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Ricerca Biglietto";
            // 
            // simpleButtonRegistra
            // 
            this.simpleButtonRegistra.Image = global::WinTicketNext.Properties.Resources.add_BF_32_S;
            this.simpleButtonRegistra.Location = new System.Drawing.Point(746, 35);
            this.simpleButtonRegistra.Name = "simpleButtonRegistra";
            this.simpleButtonRegistra.Size = new System.Drawing.Size(104, 67);
            this.simpleButtonRegistra.TabIndex = 6;
            this.simpleButtonRegistra.TabStop = false;
            this.simpleButtonRegistra.Text = "REGISTRA";
            this.simpleButtonRegistra.Click += new System.EventHandler(this.simpleButtonRegistra_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(622, 37);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(85, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Registra Ingresso";
            // 
            // spinEdit1
            // 
            this.spinEdit1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit1.Location = new System.Drawing.Point(622, 56);
            this.spinEdit1.MenuManager = this.ribbon;
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinEdit1.Properties.Appearance.Options.UseFont = true;
            this.spinEdit1.Properties.Appearance.Options.UseTextOptions = true;
            this.spinEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit1.Size = new System.Drawing.Size(100, 22);
            this.spinEdit1.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(105, 87);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(166, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Codice a Barre oppure Progressivo";
            // 
            // simpleButtonVerifica
            // 
            this.simpleButtonVerifica.Image = global::WinTicketNext.Properties.Resources.view_BF_32_S;
            this.simpleButtonVerifica.Location = new System.Drawing.Point(277, 35);
            this.simpleButtonVerifica.Name = "simpleButtonVerifica";
            this.simpleButtonVerifica.Size = new System.Drawing.Size(104, 67);
            this.simpleButtonVerifica.TabIndex = 2;
            this.simpleButtonVerifica.TabStop = false;
            this.simpleButtonVerifica.Text = "RICERCA";
            this.simpleButtonVerifica.Click += new System.EventHandler(this.simpleButtonVerifica_Click);
            // 
            // buttonEditCodice
            // 
            this.buttonEditCodice.Location = new System.Drawing.Point(105, 56);
            this.buttonEditCodice.MenuManager = this.ribbon;
            this.buttonEditCodice.Name = "buttonEditCodice";
            this.buttonEditCodice.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditCodice.Properties.Appearance.Options.UseFont = true;
            this.buttonEditCodice.Size = new System.Drawing.Size(166, 22);
            this.buttonEditCodice.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 61);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(77, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Codice biglietto:";
            // 
            // timerTick
            // 
            this.timerTick.Enabled = true;
            this.timerTick.Interval = 2000;
            this.timerTick.Tick += new System.EventHandler(this.timerTick_Tick);
            // 
            // textEditIntestazioneCard
            // 
            this.textEditIntestazioneCard.Location = new System.Drawing.Point(585, 25);
            this.textEditIntestazioneCard.MenuManager = this.ribbon;
            this.textEditIntestazioneCard.Name = "textEditIntestazioneCard";
            this.textEditIntestazioneCard.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditIntestazioneCard.Properties.Appearance.Options.UseFont = true;
            this.textEditIntestazioneCard.Properties.ReadOnly = true;
            this.textEditIntestazioneCard.Size = new System.Drawing.Size(263, 20);
            this.textEditIntestazioneCard.TabIndex = 9;
            // 
            // RibbonFormValidazione
            // 
            this.AcceptButton = this.simpleButtonVerifica;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 649);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "RibbonFormValidazione";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Validazione Biglietto";
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlIngressi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewIngressi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlInfo)).EndInit();
            this.panelControlInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDue)).EndInit();
            this.groupControlDue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlUno)).EndInit();
            this.groupControlUno.ResumeLayout(false);
            this.groupControlUno.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditProg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBarCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditCodice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIntestazioneCard.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonVerifica;
        private DevExpress.XtraEditors.ButtonEdit buttonEditCodice;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControlDue;
        private DevExpress.XtraEditors.GroupControl groupControlUno;
        private DevExpress.XtraBars.BarButtonItem barButtonItemIngresso;
        private DevExpress.XtraGrid.GridControl gridControlIngressi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewIngressi;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonRegistra;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit spinEdit1;
        private DevExpress.Xpo.UnitOfWork unitOfWork1;
        private DevExpress.XtraGrid.Columns.GridColumn colTotaleIngressi;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalePersone;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnIngresso;
        private DevExpress.XtraEditors.TextEdit textEditProg;
        private DevExpress.XtraEditors.TextEdit textEditBarCode;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DateEdit dateEditEnd;
        private DevExpress.XtraEditors.DateEdit dateEditStart;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.PanelControl panelControlInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAltre;
        private DevExpress.XtraEditors.LabelControl labelControlStatus;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupIngressi;
        private System.Windows.Forms.Timer timerTick;
        private DevExpress.XtraBars.BarStaticItem barStaticItemInfo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraBars.BarButtonItem barButtonItemStampaMyFE;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraEditors.TextEdit textEditIntestazioneCard;
    }
}