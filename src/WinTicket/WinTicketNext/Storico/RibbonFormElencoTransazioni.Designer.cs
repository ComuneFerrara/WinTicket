namespace WinTicketNext.Storico
{
    partial class RibbonFormElencoTransazioni
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
            this.barButtonItemStampa = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItemDalla = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barEditItemAlla = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barButtonGroup1 = new DevExpress.XtraBars.BarButtonGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.unitOfWork1 = new DevExpress.Xpo.UnitOfWork(this.components);
            this.gridControlCard = new DevExpress.XtraGrid.GridControl();
            this.gridViewCard = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModificatoDa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModificatoIl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatoDa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatoIl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPuntoVendita = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmailCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransazione = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInseritaIl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitolareCarta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmailTitolare = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInizio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGiorni = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProdotto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodiceOperazione = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodiceTessera = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoOperazione = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantita = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInseritaIlDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInizioDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFineDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.barButtonItemStampa,
            this.barEditItemDalla,
            this.barEditItemAlla,
            this.barButtonGroup1});
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
            // barButtonItemStampa
            // 
            this.barButtonItemStampa.Caption = "Stampa / Esporta";
            this.barButtonItemStampa.Id = 10;
            this.barButtonItemStampa.LargeGlyph = global::WinTicketNext.Properties.Resources.printer;
            this.barButtonItemStampa.Name = "barButtonItemStampa";
            this.barButtonItemStampa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemStampa_ItemClick);
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
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Transazioni Online";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barEditItemDalla, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.barEditItemAlla);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemQuery, true);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Elenco MyFE";
            // 
            // ribbonPageGroup2
            // 
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
            this.colModificatoDa,
            this.colModificatoIl,
            this.colCreatoDa,
            this.colCreatoIl,
            this.colPuntoVendita,
            this.colCliente,
            this.colEmailCliente,
            this.colIDCliente,
            this.colTransazione,
            this.colInseritaIl,
            this.colTitolareCarta,
            this.colEmailTitolare,
            this.colInizio,
            this.colFine,
            this.colGiorni,
            this.colProdotto,
            this.colCodiceOperazione,
            this.colCodiceTessera,
            this.colTipoOperazione,
            this.colQuantita,
            this.colInseritaIlDateTime,
            this.colInizioDateTime,
            this.colFineDateTime});
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
            this.colCreatoDa.VisibleIndex = 0;
            // 
            // colCreatoIl
            // 
            this.colCreatoIl.FieldName = "CreatoIl";
            this.colCreatoIl.Name = "colCreatoIl";
            this.colCreatoIl.Visible = true;
            this.colCreatoIl.VisibleIndex = 1;
            // 
            // colPuntoVendita
            // 
            this.colPuntoVendita.FieldName = "PuntoVendita";
            this.colPuntoVendita.Name = "colPuntoVendita";
            this.colPuntoVendita.Visible = true;
            this.colPuntoVendita.VisibleIndex = 2;
            // 
            // colCliente
            // 
            this.colCliente.FieldName = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.Visible = true;
            this.colCliente.VisibleIndex = 3;
            // 
            // colEmailCliente
            // 
            this.colEmailCliente.FieldName = "EmailCliente";
            this.colEmailCliente.Name = "colEmailCliente";
            this.colEmailCliente.Visible = true;
            this.colEmailCliente.VisibleIndex = 4;
            // 
            // colIDCliente
            // 
            this.colIDCliente.FieldName = "IDCliente";
            this.colIDCliente.Name = "colIDCliente";
            this.colIDCliente.Visible = true;
            this.colIDCliente.VisibleIndex = 5;
            // 
            // colTransazione
            // 
            this.colTransazione.FieldName = "Transazione";
            this.colTransazione.Name = "colTransazione";
            this.colTransazione.Visible = true;
            this.colTransazione.VisibleIndex = 6;
            // 
            // colInseritaIl
            // 
            this.colInseritaIl.FieldName = "InseritaIl";
            this.colInseritaIl.Name = "colInseritaIl";
            this.colInseritaIl.Visible = true;
            this.colInseritaIl.VisibleIndex = 7;
            // 
            // colTitolareCarta
            // 
            this.colTitolareCarta.FieldName = "TitolareCarta";
            this.colTitolareCarta.Name = "colTitolareCarta";
            this.colTitolareCarta.Visible = true;
            this.colTitolareCarta.VisibleIndex = 8;
            // 
            // colEmailTitolare
            // 
            this.colEmailTitolare.FieldName = "EmailTitolare";
            this.colEmailTitolare.Name = "colEmailTitolare";
            this.colEmailTitolare.Visible = true;
            this.colEmailTitolare.VisibleIndex = 9;
            // 
            // colInizio
            // 
            this.colInizio.FieldName = "Inizio";
            this.colInizio.Name = "colInizio";
            this.colInizio.Visible = true;
            this.colInizio.VisibleIndex = 10;
            // 
            // colFine
            // 
            this.colFine.FieldName = "Fine";
            this.colFine.Name = "colFine";
            this.colFine.Visible = true;
            this.colFine.VisibleIndex = 11;
            // 
            // colGiorni
            // 
            this.colGiorni.FieldName = "Giorni";
            this.colGiorni.Name = "colGiorni";
            this.colGiorni.Visible = true;
            this.colGiorni.VisibleIndex = 12;
            // 
            // colProdotto
            // 
            this.colProdotto.FieldName = "Prodotto";
            this.colProdotto.Name = "colProdotto";
            this.colProdotto.Visible = true;
            this.colProdotto.VisibleIndex = 13;
            // 
            // colCodiceOperazione
            // 
            this.colCodiceOperazione.FieldName = "CodiceOperazione";
            this.colCodiceOperazione.Name = "colCodiceOperazione";
            this.colCodiceOperazione.Visible = true;
            this.colCodiceOperazione.VisibleIndex = 14;
            // 
            // colCodiceTessera
            // 
            this.colCodiceTessera.FieldName = "CodiceTessera";
            this.colCodiceTessera.Name = "colCodiceTessera";
            this.colCodiceTessera.Visible = true;
            this.colCodiceTessera.VisibleIndex = 15;
            // 
            // colTipoOperazione
            // 
            this.colTipoOperazione.FieldName = "TipoOperazione";
            this.colTipoOperazione.Name = "colTipoOperazione";
            this.colTipoOperazione.Visible = true;
            this.colTipoOperazione.VisibleIndex = 16;
            // 
            // colQuantita
            // 
            this.colQuantita.FieldName = "Quantita";
            this.colQuantita.Name = "colQuantita";
            this.colQuantita.Visible = true;
            this.colQuantita.VisibleIndex = 17;
            // 
            // colInseritaIlDateTime
            // 
            this.colInseritaIlDateTime.FieldName = "InseritaIlDateTime";
            this.colInseritaIlDateTime.Name = "colInseritaIlDateTime";
            // 
            // colInizioDateTime
            // 
            this.colInizioDateTime.FieldName = "InizioDateTime";
            this.colInizioDateTime.Name = "colInizioDateTime";
            // 
            // colFineDateTime
            // 
            this.colFineDateTime.FieldName = "FineDateTime";
            this.colFineDateTime.Name = "colFineDateTime";
            // 
            // RibbonFormElencoTransazioni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 543);
            this.Controls.Add(this.gridControlCard);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "RibbonFormElencoTransazioni";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Elenco Transazioni Online";
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
        private DevExpress.XtraBars.BarButtonItem barButtonItemQuery;
        private DevExpress.XtraBars.BarButtonItem barButtonItemStampa;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarEditItem barEditItemDalla;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarEditItem barEditItemAlla;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraBars.BarButtonGroup barButtonGroup1;
        private DevExpress.XtraGrid.Columns.GridColumn colOid;
        private DevExpress.XtraGrid.Columns.GridColumn colModificatoDa;
        private DevExpress.XtraGrid.Columns.GridColumn colModificatoIl;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatoDa;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatoIl;
        private DevExpress.XtraGrid.Columns.GridColumn colPuntoVendita;
        private DevExpress.XtraGrid.Columns.GridColumn colCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colEmailCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colIDCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colTransazione;
        private DevExpress.XtraGrid.Columns.GridColumn colInseritaIl;
        private DevExpress.XtraGrid.Columns.GridColumn colTitolareCarta;
        private DevExpress.XtraGrid.Columns.GridColumn colEmailTitolare;
        private DevExpress.XtraGrid.Columns.GridColumn colInizio;
        private DevExpress.XtraGrid.Columns.GridColumn colFine;
        private DevExpress.XtraGrid.Columns.GridColumn colGiorni;
        private DevExpress.XtraGrid.Columns.GridColumn colProdotto;
        private DevExpress.XtraGrid.Columns.GridColumn colCodiceOperazione;
        private DevExpress.XtraGrid.Columns.GridColumn colCodiceTessera;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoOperazione;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantita;
        private DevExpress.XtraGrid.Columns.GridColumn colInseritaIlDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colInizioDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colFineDateTime;
    }
}