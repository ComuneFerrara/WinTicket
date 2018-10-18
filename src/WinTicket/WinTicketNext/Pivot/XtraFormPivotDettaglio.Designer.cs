namespace WinTicketNext
{
    partial class XtraFormPivotDettaglio
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnQuantita = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTotale = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnUtente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnData = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnVariante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTitolo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBiglietto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRagioneSociale = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPercorso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnT1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnT2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnT3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTipologia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barLargeButtonItemExcel = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barLargeButtonItemStampa = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barLargeButtonItemCampi = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.saveFileDialogXls = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 58);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(888, 259);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView1.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView1.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView1.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(114)))), ((int)(((byte)(113)))));
            this.gridView1.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(192)))), ((int)(((byte)(157)))));
            this.gridView1.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(219)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView1.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            this.gridView1.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView1.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView1.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView1.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.gridView1.Appearance.Preview.Options.UseBackColor = true;
            this.gridView1.Appearance.Preview.Options.UseFont = true;
            this.gridView1.Appearance.Preview.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseForeColor = true;
            this.gridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(215)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnQuantita,
            this.gridColumnTotale,
            this.gridColumnUtente,
            this.gridColumnData,
            this.gridColumnVariante,
            this.gridColumnTitolo,
            this.gridColumnBiglietto,
            this.gridColumnRagioneSociale,
            this.gridColumnPercorso,
            this.gridColumnT1,
            this.gridColumnT2,
            this.gridColumnT3,
            this.gridColumnTipologia,
            this.gridColumn1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantita", null, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PrezzoTotale", null, "{0:c}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumnData, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumnQuantita
            // 
            this.gridColumnQuantita.Caption = "Quantità";
            this.gridColumnQuantita.FieldName = "Quantita";
            this.gridColumnQuantita.Name = "gridColumnQuantita";
            this.gridColumnQuantita.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridColumnQuantita.Visible = true;
            this.gridColumnQuantita.VisibleIndex = 6;
            // 
            // gridColumnTotale
            // 
            this.gridColumnTotale.Caption = "Totale";
            this.gridColumnTotale.DisplayFormat.FormatString = "c";
            this.gridColumnTotale.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnTotale.FieldName = "PrezzoTotale";
            this.gridColumnTotale.Name = "gridColumnTotale";
            this.gridColumnTotale.SummaryItem.DisplayFormat = "{0:c}";
            this.gridColumnTotale.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridColumnTotale.Visible = true;
            this.gridColumnTotale.VisibleIndex = 7;
            // 
            // gridColumnUtente
            // 
            this.gridColumnUtente.Caption = "Utente";
            this.gridColumnUtente.FieldName = "Vendita.Utente.FullName";
            this.gridColumnUtente.Name = "gridColumnUtente";
            // 
            // gridColumnData
            // 
            this.gridColumnData.Caption = "Data";
            this.gridColumnData.DisplayFormat.FormatString = "d";
            this.gridColumnData.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnData.FieldName = "Vendita.DataContabile";
            this.gridColumnData.Name = "gridColumnData";
            this.gridColumnData.Visible = true;
            this.gridColumnData.VisibleIndex = 1;
            // 
            // gridColumnVariante
            // 
            this.gridColumnVariante.Caption = "Variante";
            this.gridColumnVariante.FieldName = "Variante.Descrizione";
            this.gridColumnVariante.Name = "gridColumnVariante";
            // 
            // gridColumnTitolo
            // 
            this.gridColumnTitolo.Caption = "Titolo";
            this.gridColumnTitolo.FieldName = "Titolo.Descrizione";
            this.gridColumnTitolo.Name = "gridColumnTitolo";
            this.gridColumnTitolo.Visible = true;
            this.gridColumnTitolo.VisibleIndex = 5;
            // 
            // gridColumnBiglietto
            // 
            this.gridColumnBiglietto.Caption = "Biglietto";
            this.gridColumnBiglietto.FieldName = "Variante.Biglietto.Descrizione";
            this.gridColumnBiglietto.Name = "gridColumnBiglietto";
            this.gridColumnBiglietto.Visible = true;
            this.gridColumnBiglietto.VisibleIndex = 3;
            // 
            // gridColumnRagioneSociale
            // 
            this.gridColumnRagioneSociale.Caption = "Ragione Sociale";
            this.gridColumnRagioneSociale.FieldName = "Vendita.Struttura.SoggettoEconomico.RagioneSociale";
            this.gridColumnRagioneSociale.Name = "gridColumnRagioneSociale";
            this.gridColumnRagioneSociale.Visible = true;
            this.gridColumnRagioneSociale.VisibleIndex = 2;
            // 
            // gridColumnPercorso
            // 
            this.gridColumnPercorso.Caption = "Percorso";
            this.gridColumnPercorso.FieldName = "Variante.Biglietto.Percorso.Descrizione";
            this.gridColumnPercorso.Name = "gridColumnPercorso";
            // 
            // gridColumnT1
            // 
            this.gridColumnT1.Caption = "T1";
            this.gridColumnT1.FieldName = "Variante.TipologiaUno";
            this.gridColumnT1.Name = "gridColumnT1";
            // 
            // gridColumnT2
            // 
            this.gridColumnT2.Caption = "T2";
            this.gridColumnT2.FieldName = "Variante.TipologiaDue";
            this.gridColumnT2.Name = "gridColumnT2";
            // 
            // gridColumnT3
            // 
            this.gridColumnT3.Caption = "T3";
            this.gridColumnT3.FieldName = "Variante.TipologiaTre";
            this.gridColumnT3.Name = "gridColumnT3";
            // 
            // gridColumnTipologia
            // 
            this.gridColumnTipologia.Caption = "Tipologia";
            this.gridColumnTipologia.FieldName = "Variante.Tipologia";
            this.gridColumnTipologia.Name = "gridColumnTipologia";
            this.gridColumnTipologia.Visible = true;
            this.gridColumnTipologia.VisibleIndex = 4;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Vendita";
            this.gridColumn1.FieldName = "Vendita.CodiceLeggibile";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barLargeButtonItemExcel,
            this.barLargeButtonItemStampa,
            this.barLargeButtonItemCampi});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 3;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barLargeButtonItemExcel),
            new DevExpress.XtraBars.LinkPersistInfo(this.barLargeButtonItemStampa),
            new DevExpress.XtraBars.LinkPersistInfo(this.barLargeButtonItemCampi)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barLargeButtonItemExcel
            // 
            this.barLargeButtonItemExcel.Caption = "Excel";
            this.barLargeButtonItemExcel.Id = 0;
            this.barLargeButtonItemExcel.LargeGlyph = global::WinTicketNext.Properties.Resources.symbol_sum;
            this.barLargeButtonItemExcel.Name = "barLargeButtonItemExcel";
            this.barLargeButtonItemExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barLargeButtonItemExcel_ItemClick);
            // 
            // barLargeButtonItemStampa
            // 
            this.barLargeButtonItemStampa.Caption = "Stampa";
            this.barLargeButtonItemStampa.Id = 1;
            this.barLargeButtonItemStampa.LargeGlyph = global::WinTicketNext.Properties.Resources.printer;
            this.barLargeButtonItemStampa.Name = "barLargeButtonItemStampa";
            this.barLargeButtonItemStampa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barLargeButtonItemStampa_ItemClick);
            // 
            // barLargeButtonItemCampi
            // 
            this.barLargeButtonItemCampi.Caption = "Altri Campi";
            this.barLargeButtonItemCampi.Id = 2;
            this.barLargeButtonItemCampi.Name = "barLargeButtonItemCampi";
            this.barLargeButtonItemCampi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barLargeButtonItemCampi_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(888, 58);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 317);
            this.barDockControlBottom.Size = new System.Drawing.Size(888, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 58);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 259);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(888, 58);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 259);
            // 
            // saveFileDialogXls
            // 
            this.saveFileDialogXls.DefaultExt = "xls";
            this.saveFileDialogXls.Filter = "File Excel (*.xls)|*.xls|Tutti i file (*.*)|*.*";
            // 
            // XtraFormPivotDettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 340);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "XtraFormPivotDettaglio";
            this.Text = "Pivot - Dettaglio";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnQuantita;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTotale;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUtente;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnData;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnVariante;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTitolo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBiglietto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRagioneSociale;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPercorso;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnT1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnT2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnT3;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItemExcel;
        private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItemStampa;
        private System.Windows.Forms.SaveFileDialog saveFileDialogXls;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTipologia;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItemCampi;
    }
}