namespace WinTicketNext.Storico
{
    partial class XtraFormCreaFattura
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
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemModifica = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemStampa = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemStampaAnteprima = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemElimina = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupModifica = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupStampa = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupElimina = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnDescrizioneRiga = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnQuantita = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPrezzoUnitario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPrezzoTotale = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textEditIntestazione1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEditIntestazione2 = new DevExpress.XtraEditors.TextEdit();
            this.textEditIntestazione3 = new DevExpress.XtraEditors.TextEdit();
            this.textEditFatturaNumero = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.textEditIntestazione4 = new DevExpress.XtraEditors.TextEdit();
            this.textEditNote = new DevExpress.XtraEditors.MemoEdit();
            this.textEditFatturaData = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIntestazione1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIntestazione2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIntestazione3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditFatturaNumero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIntestazione4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditFatturaData.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditFatturaData.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // unitOfWork1
            // 
            this.unitOfWork1.TrackPropertiesModifications = true;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barButtonItemSave,
            this.barButtonItemModifica,
            this.barButtonItemStampa,
            this.barButtonItemStampaAnteprima,
            this.barButtonItemElimina});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 6;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl1.Size = new System.Drawing.Size(680, 117);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // barButtonItemSave
            // 
            this.barButtonItemSave.Caption = "Salva";
            this.barButtonItemSave.Glyph = global::WinTicketNext.Properties.Resources.floppy_disk_yellow;
            this.barButtonItemSave.Id = 1;
            this.barButtonItemSave.LargeGlyph = global::WinTicketNext.Properties.Resources.floppy_disk_yellow;
            this.barButtonItemSave.Name = "barButtonItemSave";
            this.barButtonItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSave_ItemClick);
            // 
            // barButtonItemModifica
            // 
            this.barButtonItemModifica.Caption = "Modifica";
            this.barButtonItemModifica.Id = 2;
            this.barButtonItemModifica.LargeGlyph = global::WinTicketNext.Properties.Resources.document_edit;
            this.barButtonItemModifica.Name = "barButtonItemModifica";
            this.barButtonItemModifica.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemModifica_ItemClick);
            // 
            // barButtonItemStampa
            // 
            this.barButtonItemStampa.Caption = "Stampa Diretta";
            this.barButtonItemStampa.Glyph = global::WinTicketNext.Properties.Resources.printer;
            this.barButtonItemStampa.Id = 3;
            this.barButtonItemStampa.LargeGlyph = global::WinTicketNext.Properties.Resources.printer;
            this.barButtonItemStampa.Name = "barButtonItemStampa";
            this.barButtonItemStampa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemStampa_ItemClick);
            // 
            // barButtonItemStampaAnteprima
            // 
            this.barButtonItemStampaAnteprima.Caption = "Stampa con Anteprima";
            this.barButtonItemStampaAnteprima.Id = 4;
            this.barButtonItemStampaAnteprima.LargeGlyph = global::WinTicketNext.Properties.Resources.printer;
            this.barButtonItemStampaAnteprima.Name = "barButtonItemStampaAnteprima";
            this.barButtonItemStampaAnteprima.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemStampaAnteprima_ItemClick);
            // 
            // barButtonItemElimina
            // 
            this.barButtonItemElimina.Caption = "Elimina";
            this.barButtonItemElimina.Id = 5;
            this.barButtonItemElimina.LargeGlyph = global::WinTicketNext.Properties.Resources.delete_BF_32_S;
            this.barButtonItemElimina.Name = "barButtonItemElimina";
            this.barButtonItemElimina.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemElimina_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupModifica,
            this.ribbonPageGroupStampa,
            this.ribbonPageGroupElimina});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Gestione Fattura";
            // 
            // ribbonPageGroupModifica
            // 
            this.ribbonPageGroupModifica.ItemLinks.Add(this.barButtonItemSave);
            this.ribbonPageGroupModifica.ItemLinks.Add(this.barButtonItemModifica);
            this.ribbonPageGroupModifica.Name = "ribbonPageGroupModifica";
            this.ribbonPageGroupModifica.Text = "Fattura";
            // 
            // ribbonPageGroupStampa
            // 
            this.ribbonPageGroupStampa.ItemLinks.Add(this.barButtonItemStampaAnteprima);
            this.ribbonPageGroupStampa.ItemLinks.Add(this.barButtonItemStampa, true);
            this.ribbonPageGroupStampa.Name = "ribbonPageGroupStampa";
            this.ribbonPageGroupStampa.Text = "Stampa";
            // 
            // ribbonPageGroupElimina
            // 
            this.ribbonPageGroupElimina.ItemLinks.Add(this.barButtonItemElimina);
            this.ribbonPageGroupElimina.Name = "ribbonPageGroupElimina";
            this.ribbonPageGroupElimina.Text = "Elimina";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(12, 202);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ShowOnlyPredefinedDetails = true;
            this.gridControl1.Size = new System.Drawing.Size(656, 243);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnDescrizioneRiga,
            this.gridColumnQuantita,
            this.gridColumnPrezzoUnitario,
            this.gridColumnPrezzoTotale});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnDescrizioneRiga
            // 
            this.gridColumnDescrizioneRiga.Caption = "Descrizione Riga";
            this.gridColumnDescrizioneRiga.FieldName = "DescrizioneRiga";
            this.gridColumnDescrizioneRiga.Name = "gridColumnDescrizioneRiga";
            this.gridColumnDescrizioneRiga.Visible = true;
            this.gridColumnDescrizioneRiga.VisibleIndex = 0;
            // 
            // gridColumnQuantita
            // 
            this.gridColumnQuantita.Caption = "Quantità";
            this.gridColumnQuantita.FieldName = "Quantita";
            this.gridColumnQuantita.Name = "gridColumnQuantita";
            this.gridColumnQuantita.Visible = true;
            this.gridColumnQuantita.VisibleIndex = 2;
            // 
            // gridColumnPrezzoUnitario
            // 
            this.gridColumnPrezzoUnitario.Caption = "Prezzo Unitario";
            this.gridColumnPrezzoUnitario.DisplayFormat.FormatString = "c";
            this.gridColumnPrezzoUnitario.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnPrezzoUnitario.FieldName = "PrezzoUnitario";
            this.gridColumnPrezzoUnitario.Name = "gridColumnPrezzoUnitario";
            this.gridColumnPrezzoUnitario.Visible = true;
            this.gridColumnPrezzoUnitario.VisibleIndex = 1;
            // 
            // gridColumnPrezzoTotale
            // 
            this.gridColumnPrezzoTotale.Caption = "Prezzo Totale";
            this.gridColumnPrezzoTotale.DisplayFormat.FormatString = "c";
            this.gridColumnPrezzoTotale.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnPrezzoTotale.FieldName = "PrezzoTotale";
            this.gridColumnPrezzoTotale.Name = "gridColumnPrezzoTotale";
            this.gridColumnPrezzoTotale.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PrezzoTotale", "{0:c}")});
            this.gridColumnPrezzoTotale.Visible = true;
            this.gridColumnPrezzoTotale.VisibleIndex = 3;
            // 
            // textEditIntestazione1
            // 
            this.textEditIntestazione1.EditValue = "Spett.le";
            this.textEditIntestazione1.Location = new System.Drawing.Point(324, 32);
            this.textEditIntestazione1.MenuManager = this.ribbonControl1;
            this.textEditIntestazione1.Name = "textEditIntestazione1";
            this.textEditIntestazione1.Size = new System.Drawing.Size(344, 20);
            this.textEditIntestazione1.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(196, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(122, 17);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Intestazione :";
            // 
            // textEditIntestazione2
            // 
            this.textEditIntestazione2.Location = new System.Drawing.Point(324, 58);
            this.textEditIntestazione2.MenuManager = this.ribbonControl1;
            this.textEditIntestazione2.Name = "textEditIntestazione2";
            this.textEditIntestazione2.Size = new System.Drawing.Size(344, 20);
            this.textEditIntestazione2.TabIndex = 4;
            // 
            // textEditIntestazione3
            // 
            this.textEditIntestazione3.Location = new System.Drawing.Point(324, 84);
            this.textEditIntestazione3.MenuManager = this.ribbonControl1;
            this.textEditIntestazione3.Name = "textEditIntestazione3";
            this.textEditIntestazione3.Size = new System.Drawing.Size(344, 20);
            this.textEditIntestazione3.TabIndex = 6;
            // 
            // textEditFatturaNumero
            // 
            this.textEditFatturaNumero.Enabled = false;
            this.textEditFatturaNumero.Location = new System.Drawing.Point(63, 32);
            this.textEditFatturaNumero.MenuManager = this.ribbonControl1;
            this.textEditFatturaNumero.Name = "textEditFatturaNumero";
            this.textEditFatturaNumero.Properties.ReadOnly = true;
            this.textEditFatturaNumero.Size = new System.Drawing.Size(127, 20);
            this.textEditFatturaNumero.TabIndex = 8;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.textEditIntestazione4);
            this.groupControl1.Controls.Add(this.textEditFatturaNumero);
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Controls.Add(this.textEditIntestazione1);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.textEditIntestazione2);
            this.groupControl1.Controls.Add(this.textEditIntestazione3);
            this.groupControl1.Controls.Add(this.textEditNote);
            this.groupControl1.Controls.Add(this.textEditFatturaData);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 117);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(680, 457);
            this.groupControl1.TabIndex = 11;
            this.groupControl1.Text = "Dati Fattura";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Location = new System.Drawing.Point(12, 113);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(45, 20);
            this.labelControl6.TabIndex = 16;
            this.labelControl6.Text = "Note :";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Location = new System.Drawing.Point(9, 59);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 17);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "Data :";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(9, 33);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 17);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "Nr :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(196, 59);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(122, 17);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "Indirizzo :";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(172, 110);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(146, 20);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Codice Fiscale e/o P.IVA :";
            // 
            // textEditIntestazione4
            // 
            this.textEditIntestazione4.Location = new System.Drawing.Point(324, 110);
            this.textEditIntestazione4.MenuManager = this.ribbonControl1;
            this.textEditIntestazione4.Name = "textEditIntestazione4";
            this.textEditIntestazione4.Size = new System.Drawing.Size(344, 20);
            this.textEditIntestazione4.TabIndex = 10;
            // 
            // textEditNote
            // 
            this.textEditNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditNote.Location = new System.Drawing.Point(12, 136);
            this.textEditNote.MenuManager = this.ribbonControl1;
            this.textEditNote.Name = "textEditNote";
            this.textEditNote.Size = new System.Drawing.Size(656, 60);
            this.textEditNote.TabIndex = 15;
            // 
            // textEditFatturaData
            // 
            this.textEditFatturaData.EditValue = null;
            this.textEditFatturaData.Location = new System.Drawing.Point(63, 58);
            this.textEditFatturaData.MenuManager = this.ribbonControl1;
            this.textEditFatturaData.Name = "textEditFatturaData";
            this.textEditFatturaData.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textEditFatturaData.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.textEditFatturaData.Size = new System.Drawing.Size(127, 20);
            this.textEditFatturaData.TabIndex = 9;
            // 
            // XtraFormCreaFattura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 574);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XtraFormCreaFattura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fattura";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XtraFormCreaFattura_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIntestazione1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIntestazione2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIntestazione3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditFatturaNumero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditIntestazione4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditFatturaData.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditFatturaData.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Xpo.UnitOfWork unitOfWork1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupModifica;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit textEditIntestazione1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEditIntestazione2;
        private DevExpress.XtraEditors.TextEdit textEditIntestazione3;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSave;
        private DevExpress.XtraEditors.TextEdit textEditFatturaNumero;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDescrizioneRiga;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPrezzoTotale;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnQuantita;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPrezzoUnitario;
        private DevExpress.XtraBars.BarButtonItem barButtonItemModifica;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemStampa;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit textEditIntestazione4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraBars.BarButtonItem barButtonItemStampaAnteprima;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.MemoEdit textEditNote;
        private DevExpress.XtraBars.BarButtonItem barButtonItemElimina;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupStampa;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupElimina;
        private DevExpress.XtraEditors.DateEdit textEditFatturaData;
    }
}