namespace WinTicketNext.Storico
{
    partial class RibbonFormPivotCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RibbonFormPivotCard));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barEditItemDateStart = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barEditItemDateEnd = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barButtonItemQuery = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.xpCollectionCard = new DevExpress.Xpo.XPCollection(this.components);
            this.fieldCodice = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldStatus = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldTipologiaCard = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldAssegnataUtenteFullName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldAssegnataStrutturaDescrizione = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldAlbergoRagioneSociale = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldCodiceConteggioCard = new DevExpress.XtraPivotGrid.PivotGridField();
            this.unitOfWork1 = new DevExpress.Xpo.UnitOfWork(this.components);
            this.barCheckItemTutto = new DevExpress.XtraBars.BarCheckItem();
            this.fieldStampaVenditaStrutturaDescrizione = new DevExpress.XtraPivotGrid.PivotGridField();
            this.barButtonItemPrint = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollectionCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printableComponentLink1.ImageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barEditItemDateStart,
            this.barEditItemDateEnd,
            this.barButtonItemQuery,
            this.barCheckItemTutto,
            this.barButtonItemPrint});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 6;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemDateEdit2});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbon.Size = new System.Drawing.Size(676, 144);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // barEditItemDateStart
            // 
            this.barEditItemDateStart.Caption = "Vendute Dal";
            this.barEditItemDateStart.Edit = this.repositoryItemDateEdit1;
            this.barEditItemDateStart.Id = 1;
            this.barEditItemDateStart.Name = "barEditItemDateStart";
            this.barEditItemDateStart.Width = 100;
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
            // barEditItemDateEnd
            // 
            this.barEditItemDateEnd.Caption = "Vendute Al  ";
            this.barEditItemDateEnd.Edit = this.repositoryItemDateEdit2;
            this.barEditItemDateEnd.Id = 2;
            this.barEditItemDateEnd.Name = "barEditItemDateEnd";
            this.barEditItemDateEnd.Width = 100;
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
            // barButtonItemQuery
            // 
            this.barButtonItemQuery.Caption = "Query";
            this.barButtonItemQuery.Id = 3;
            this.barButtonItemQuery.LargeGlyph = global::WinTicketNext.Properties.Resources.media_play_green;
            this.barButtonItemQuery.Name = "barButtonItemQuery";
            this.barButtonItemQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemQuery_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Card MyFE";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barEditItemDateStart);
            this.ribbonPageGroup1.ItemLinks.Add(this.barEditItemDateEnd);
            this.ribbonPageGroup1.ItemLinks.Add(this.barCheckItemTutto);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemQuery, true);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Filtro";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 451);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(676, 31);
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.pivotGridControl1.Appearance.FieldValueGrandTotal.Options.UseFont = true;
            this.pivotGridControl1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.pivotGridControl1.Appearance.FieldValueTotal.Options.UseFont = true;
            this.pivotGridControl1.Appearance.GrandTotalCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pivotGridControl1.Appearance.GrandTotalCell.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.TotalCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pivotGridControl1.Appearance.TotalCell.Options.UseBackColor = true;
            this.pivotGridControl1.DataSource = this.xpCollectionCard;
            this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldCodice,
            this.fieldStatus,
            this.fieldTipologiaCard,
            this.fieldAssegnataUtenteFullName,
            this.fieldAssegnataStrutturaDescrizione,
            this.fieldAlbergoRagioneSociale,
            this.fieldCodiceConteggioCard,
            this.fieldStampaVenditaStrutturaDescrizione});
            this.pivotGridControl1.Location = new System.Drawing.Point(0, 144);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.Size = new System.Drawing.Size(676, 307);
            this.pivotGridControl1.TabIndex = 2;
            // 
            // xpCollectionCard
            // 
            this.xpCollectionCard.CriteriaString = "[Oid] Is Null";
            this.xpCollectionCard.ObjectType = typeof(Musei.Module.Card);
            this.xpCollectionCard.Session = this.unitOfWork1;
            // 
            // fieldCodice
            // 
            this.fieldCodice.AreaIndex = 2;
            this.fieldCodice.FieldName = "Codice";
            this.fieldCodice.Name = "fieldCodice";
            this.fieldCodice.Visible = false;
            // 
            // fieldStatus
            // 
            this.fieldStatus.AreaIndex = 2;
            this.fieldStatus.FieldName = "Status";
            this.fieldStatus.Name = "fieldStatus";
            this.fieldStatus.Visible = false;
            // 
            // fieldTipologiaCard
            // 
            this.fieldTipologiaCard.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldTipologiaCard.AreaIndex = 1;
            this.fieldTipologiaCard.FieldName = "TipologiaCard";
            this.fieldTipologiaCard.Name = "fieldTipologiaCard";
            // 
            // fieldAssegnataUtenteFullName
            // 
            this.fieldAssegnataUtenteFullName.AreaIndex = 1;
            this.fieldAssegnataUtenteFullName.Caption = "Assegnata Utente";
            this.fieldAssegnataUtenteFullName.FieldName = "AssegnataUtente.FullName";
            this.fieldAssegnataUtenteFullName.Name = "fieldAssegnataUtenteFullName";
            this.fieldAssegnataUtenteFullName.Visible = false;
            // 
            // fieldAssegnataStrutturaDescrizione
            // 
            this.fieldAssegnataStrutturaDescrizione.AreaIndex = 0;
            this.fieldAssegnataStrutturaDescrizione.Caption = "Assegnata Struttura";
            this.fieldAssegnataStrutturaDescrizione.FieldName = "AssegnataStruttura.Descrizione";
            this.fieldAssegnataStrutturaDescrizione.Name = "fieldAssegnataStrutturaDescrizione";
            this.fieldAssegnataStrutturaDescrizione.Visible = false;
            // 
            // fieldAlbergoRagioneSociale
            // 
            this.fieldAlbergoRagioneSociale.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldAlbergoRagioneSociale.AreaIndex = 0;
            this.fieldAlbergoRagioneSociale.Caption = "Albergo";
            this.fieldAlbergoRagioneSociale.FieldName = "Albergo.RagioneSociale";
            this.fieldAlbergoRagioneSociale.Name = "fieldAlbergoRagioneSociale";
            // 
            // fieldCodiceConteggioCard
            // 
            this.fieldCodiceConteggioCard.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldCodiceConteggioCard.AreaIndex = 0;
            this.fieldCodiceConteggioCard.Caption = "Conteggio";
            this.fieldCodiceConteggioCard.CellFormat.FormatString = "n0";
            this.fieldCodiceConteggioCard.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldCodiceConteggioCard.FieldName = "Codice";
            this.fieldCodiceConteggioCard.GrandTotalCellFormat.FormatString = "n0";
            this.fieldCodiceConteggioCard.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldCodiceConteggioCard.Name = "fieldCodiceConteggioCard";
            this.fieldCodiceConteggioCard.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            this.fieldCodiceConteggioCard.TotalValueFormat.FormatString = "n0";
            this.fieldCodiceConteggioCard.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldCodiceConteggioCard.ValueFormat.FormatString = "n0";
            this.fieldCodiceConteggioCard.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // unitOfWork1
            // 
            this.unitOfWork1.TrackPropertiesModifications = false;
            // 
            // barCheckItemTutto
            // 
            this.barCheckItemTutto.Caption = "Carica anche card non emesse";
            this.barCheckItemTutto.Id = 4;
            this.barCheckItemTutto.Name = "barCheckItemTutto";
            // 
            // fieldStampaVenditaStrutturaDescrizione
            // 
            this.fieldStampaVenditaStrutturaDescrizione.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldStampaVenditaStrutturaDescrizione.AreaIndex = 0;
            this.fieldStampaVenditaStrutturaDescrizione.Caption = "Struttura Venditrice";
            this.fieldStampaVenditaStrutturaDescrizione.FieldName = "Stampa.Vendita.Struttura.Descrizione";
            this.fieldStampaVenditaStrutturaDescrizione.Name = "fieldStampaVenditaStrutturaDescrizione";
            // 
            // barButtonItemPrint
            // 
            this.barButtonItemPrint.Caption = "Stampa / Esporta";
            this.barButtonItemPrint.Id = 5;
            this.barButtonItemPrint.LargeGlyph = global::WinTicketNext.Properties.Resources.printer;
            this.barButtonItemPrint.Name = "barButtonItemPrint";
            this.barButtonItemPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemPrint_ItemClick);
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItemPrint);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Operazioni";
            // 
            // printingSystem1
            // 
            this.printingSystem1.Links.AddRange(new object[] {
            this.printableComponentLink1});
            // 
            // printableComponentLink1
            // 
            this.printableComponentLink1.Component = this.pivotGridControl1;
            // 
            // 
            // 
            this.printableComponentLink1.ImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink1.ImageCollection.ImageStream")));
            this.printableComponentLink1.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
            this.printableComponentLink1.Owner = null;
            this.printableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.printableComponentLink1.PrintingSystem = this.printingSystem1;
            this.printableComponentLink1.PrintingSystemBase = this.printingSystem1;
            // 
            // RibbonFormPivotCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 482);
            this.Controls.Add(this.pivotGridControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "RibbonFormPivotCard";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Pivot Card MyFE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollectionCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printableComponentLink1.ImageCollection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.Xpo.UnitOfWork unitOfWork1;
        private DevExpress.Xpo.XPCollection xpCollectionCard;
        private DevExpress.XtraPivotGrid.PivotGridField fieldCodice;
        private DevExpress.XtraPivotGrid.PivotGridField fieldStatus;
        private DevExpress.XtraPivotGrid.PivotGridField fieldTipologiaCard;
        private DevExpress.XtraPivotGrid.PivotGridField fieldAssegnataUtenteFullName;
        private DevExpress.XtraPivotGrid.PivotGridField fieldAssegnataStrutturaDescrizione;
        private DevExpress.XtraPivotGrid.PivotGridField fieldAlbergoRagioneSociale;
        private DevExpress.XtraPivotGrid.PivotGridField fieldCodiceConteggioCard;
        private DevExpress.XtraBars.BarEditItem barEditItemDateStart;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarEditItem barEditItemDateEnd;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraBars.BarButtonItem barButtonItemQuery;
        private DevExpress.XtraBars.BarCheckItem barCheckItemTutto;
        private DevExpress.XtraPivotGrid.PivotGridField fieldStampaVenditaStrutturaDescrizione;
        private DevExpress.XtraBars.BarButtonItem barButtonItemPrint;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
    }
}