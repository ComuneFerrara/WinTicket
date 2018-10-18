using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.IO;
using System.Diagnostics;
using DevExpress.Data.Filtering;
using Musei.Module;
using DevExpress.XtraPrinting;
using DevExpress.Utils;
using System.Collections;
using System.Text;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace WinTicketNext
{
    public partial class RibbonFormPivotRigaVenditaVariante : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private const string STR_PivotRigaVenditaVariante = "PivotRigaVenditaVariante";
        public RibbonFormPivotRigaVenditaVariante()
        {
            InitializeComponent();

            DateTime data = DateTime.Now.Date.AddMonths(-1);

            this.dateEditStart.DateTime = new DateTime(data.Year, data.Month, 1);
            this.dateEditEnd.DateTime = this.dateEditStart.DateTime.AddMonths(1).AddDays(-1);
            this.imageComboBoxEditMode.EditValue = 1;

            XPCollection<Struttura> strutture = Program.UtenteCollegato.GetMioElencoStrutture(this.unitOfWork1, Program.Postazione);
            this.checkedListBoxControl1.DataSource = strutture;

            foreach (DevExpress.XtraPivotGrid.PivotGridField field in this.pivotGridControlStampe.Fields)
            {
                field.ToolTips.HeaderText = field.FieldName;
            }

            this.ribbonGalleryBarItemLayout.Gallery.Groups.Add(new DevExpress.XtraBars.Ribbon.GalleryItemGroup());
            var layout = new XPCollection<ConfigurazionePivot>(this.unitOfWork1);
            foreach (var item in layout)
            {
                this.ribbonGalleryBarItemLayout.Gallery.Groups[0].Items.Add(new DevExpress.XtraBars.Ribbon.GalleryItem(null, item.Descrizione, item.Descrizione));
            }
        }

        private void barButtonItemExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (saveFileDialogXls.ShowDialog(this) == DialogResult.OK)
            {
                this.pivotGridControlStampe.ExportToXls(saveFileDialogXls.FileName, new XlsExportOptions(TextExportMode.Value));
                if (File.Exists(saveFileDialogXls.FileName))
                {
                    Process.Start(saveFileDialogXls.FileName);
                }
            }
        }

        private void barButtonItemPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.pivotGridControlStampe.ShowPrintPreview();
        }

        private GroupOperator GetNewCriteria()
        {
            GroupOperator newCriteria = new GroupOperator(GroupOperatorType.And);

            //GroupOperator myfe1p1 = new GroupOperator(GroupOperatorType.And);
            //myfe1p1.Operands.Add(new BinaryOperator("Variante.TipologiaTre", EnumTipologiaTre.CardMyFE, BinaryOperatorType.Equal));
            //myfe1p1.Operands.Add(new NotOperator(new NullOperator("Variante.PrezzoAttuale.PrezzoRidotto")));

            //GroupOperator myfe1 = new GroupOperator(GroupOperatorType.Or);
            //myfe1.Operands.Add(new BinaryOperator("Variante.TipologiaTre", EnumTipologiaTre.CardMyFE, BinaryOperatorType.NotEqual));
            //myfe1.Operands.Add(myfe1p1);

            //newCriteria.Operands.Add(myfe1);

            if (checkEditPeriodo.Checked)
            {
                int dateStartDay = this.dateEditStart.DateTime.Day;
                int dateStartMonth = this.dateEditStart.DateTime.Month;
                int dateStartYear = this.dateEditStart.DateTime.Year;

                int dateEndDay = this.dateEditEnd.DateTime.Day;
                int dateEndMonth = this.dateEditEnd.DateTime.Month;
                int dateEndYear = this.dateEditEnd.DateTime.Year;
               
                GroupOperator rangeOrCriteria = new GroupOperator(GroupOperatorType.Or);

                for (int anno = dateStartYear; anno <= dateEndYear; anno++)
                {
                    GroupOperator rangeAndCriteria = new GroupOperator(GroupOperatorType.And);

                    DateTime startDate = new DateTime(anno, dateStartMonth, dateStartDay);
                    DateTime endDate = new DateTime(anno, dateEndMonth, dateEndDay);
                    rangeAndCriteria.Operands.Add(new BinaryOperator("Vendita.DataContabile", startDate, BinaryOperatorType.GreaterOrEqual));
                    rangeAndCriteria.Operands.Add(new BinaryOperator("Vendita.DataContabile", endDate, BinaryOperatorType.LessOrEqual));

                    rangeOrCriteria.Operands.Add(rangeAndCriteria);
                }

                newCriteria.Operands.Add(rangeOrCriteria);

                _filterData = string.Format("{0:d} - {1:d}[periodi su anni diversi]", this.dateEditStart.DateTime, this.dateEditEnd.DateTime);
            }
            else
            {
                newCriteria.Operands.Add(new BinaryOperator("Vendita.DataContabile", this.dateEditStart.DateTime, BinaryOperatorType.GreaterOrEqual));
                newCriteria.Operands.Add(new BinaryOperator("Vendita.DataContabile", this.dateEditEnd.DateTime, BinaryOperatorType.LessOrEqual));

                _filterData = string.Format("{0:d} - {1:d}", this.dateEditStart.DateTime, this.dateEditEnd.DateTime);
            }

            if (this.checkedListBoxControl1.CheckedItems.Count > 0)
            {
                int mode = (int)this.imageComboBoxEditMode.EditValue;

                GroupOperator orCriteria = new GroupOperator(GroupOperatorType.Or);

                if (mode == 1) // emesso da
                {
                    _filterModo = "emessoda";
                    _filterStrutture = "";

                    foreach (Struttura item in this.checkedListBoxControl1.CheckedItems)
                    {
                        _filterStrutture += (string.IsNullOrEmpty(_filterStrutture) ? "" : ", ") +
                            item.Descrizione;

                        orCriteria.Operands.Add(new BinaryOperator("Vendita.Struttura.Oid", item.Oid));
                    }
                }

                if (mode == 2) // validi per
                {
                    _filterModo = "validiper";
                    _filterStrutture = "";

                    foreach (Struttura item in this.checkedListBoxControl1.CheckedItems)
                    {
                        _filterStrutture += (string.IsNullOrEmpty(_filterStrutture) ? "" : ", ") +
                            item.Descrizione;

                        foreach (Ingresso ingresso in item.Ingressi)
                        {
                            foreach (Percorso per in ingresso.Percorsi)
                            {
                                orCriteria.Operands.Add(new BinaryOperator("Variante.Biglietto.Percorso.Oid", per.Oid));
                            }
                        }
                    }
                }

                if (orCriteria.Operands.Count == 0)
                    orCriteria.Operands.Add(new BinaryOperator("Oid", Guid.Empty));

                newCriteria.Operands.Add(orCriteria);
            }

            return newCriteria;
        }

        private void simpleButtonQuery_Click(object sender, EventArgs e)
        {
            Cursor saveCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ApplicaOpzioni();

                if (this.checkedListBoxControl1.CheckedItems.Count > 0)
                {
                    this.xpCollectionRigheVendita.Criteria = GetNewCriteria();
                    this.xpCollectionRigheVendita.Load();

                    this.pivotGridControlStampe.BestFit();
                }
                else
                    XtraMessageBox.Show("Selezionare almeno una struttura", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = saveCursor;
            }
        }

        private void pivotGridControlStampe_CellDoubleClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
        {
            XtraFormPivotDettaglio dettaglio = new XtraFormPivotDettaglio();
            dettaglio.DataBind(e.CreateDrillDownDataSource());
            dettaglio.Show();
        }

        private void barButtonItemPrint1_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraReportStampePeriodo stampa1 = new XtraReportStampePeriodo();
            stampa1.xpCollectionRigaStampa.Criteria = GetNewCriteria();
            stampa1.xrLabelDatePeriodo.Text = String.Format("dal {0} al {1}", this.dateEditStart.DateTime.ToShortDateString(), this.dateEditEnd.DateTime.ToShortDateString());
            stampa1.ShowRibbonPreview();
        }

        private void barButtonItemPrint2_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraReportStampePeriodo3 stampa1 = new XtraReportStampePeriodo3();
            stampa1.xpCollectionRigaStampa.Criteria = GetNewCriteria();
            stampa1.xrLabelDatePeriodo.Text = String.Format("dal {0} al {1}", this.dateEditStart.DateTime.ToShortDateString(), this.dateEditEnd.DateTime.ToShortDateString());
            stampa1.ShowRibbonPreview();
        }

        private void LoadLayout()
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(ConfigurazioneCaricata.XML);
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                this.pivotGridControlStampe.RestoreLayoutFromStream(stream, OptionsLayoutBase.FullLayout);
                this.pivotGridControlStampe.BestFit();
            }
        }

        private void barButtonItemLoadLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            Pivot.XtraFormLoad load = new Pivot.XtraFormLoad();
            load.Init(STR_PivotRigaVenditaVariante);
            if (load.ShowDialog(this) == DialogResult.OK)
            {
                ConfigurazioneCaricata = load.target;

                LoadLayout();
            }
        }

        ConfigurazionePivot ConfigurazioneCaricata = null;
        private void barButtonItemSaveLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            Pivot.XtraFormSave save = new Pivot.XtraFormSave();
            save.Init(ConfigurazioneCaricata);

            if (save.ShowDialog(this) == DialogResult.OK)
            {
                MemoryStream stream = new MemoryStream();
                this.pivotGridControlStampe.SaveLayoutToStream(stream, OptionsLayoutBase.FullLayout);
                stream.Seek(0, SeekOrigin.Begin);

                StreamReader reader = new StreamReader(stream);
                string text = reader.ReadToEnd();

                if (save.SalvaNuovo || ConfigurazioneCaricata == null)
                {
                    ConfigurazionePivot pivot = new ConfigurazionePivot(new Session());
                    pivot.Tipo = STR_PivotRigaVenditaVariante;
                    pivot.Descrizione = save.SalvaNome;
                    pivot.XML = text;

                    pivot.Save();
                }
                else
                {
                    ConfigurazioneCaricata.XML = text;
                    ConfigurazioneCaricata.Descrizione = save.SalvaNome;
                    ConfigurazioneCaricata.Save();
                }
            }
        }

        private void barButtonShowFields_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.pivotGridControlStampe.FieldsCustomization();
        }

        private void barButtonItemBestFit_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.pivotGridControlStampe.BestFit();
        }

        private void pivotGridControlStampe_CustomSummary(object sender, DevExpress.XtraPivotGrid.PivotGridCustomSummaryEventArgs e)
        {
            string name = e.DataField.FieldName; // Stampa.Vendita.Oid;

            if (e.DataField.SummaryType == DevExpress.Data.PivotGrid.PivotSummaryType.Custom)
            {
                if (name == "Vendita.Oid")
                {
                    IList list = e.CreateDrillDownDataSource();
                    Hashtable ht = new Hashtable();
                    for (int i = 0; i < list.Count; i++)
                    {
                        DevExpress.XtraPivotGrid.PivotDrillDownDataRow row = list[i] as DevExpress.XtraPivotGrid.PivotDrillDownDataRow;

                        object v = row[name];

                        if (v != null && v != DBNull.Value)
                            ht[v] = null;
                    }

                    e.CustomValue = ht.Count;
                }
            }
        }

        private void barCheckItemRow_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            ApplicaOpzioni();
        }

        private void barCheckItemCols_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            ApplicaOpzioni();
        }

        private void barCheckItemGrafico_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            ApplicaOpzioni();
        }

        private void ApplicaOpzioni()
        {
            this.pivotGridControlStampe.OptionsView.ShowColumnGrandTotals = barCheckItemCols.Checked;
            this.pivotGridControlStampe.OptionsView.ShowRowGrandTotals = barCheckItemRow.Checked;
            this.chartControlPivot.DataSource = barCheckItemGrafico.Checked ? pivotGridControlStampe : null;
            this.dockPanelGrafico.Visibility = barCheckItemGrafico.Checked ? DevExpress.XtraBars.Docking.DockVisibility.Visible : DevExpress.XtraBars.Docking.DockVisibility.Hidden;
        }

        private void barButtonItemStampaGrafico_ItemClick(object sender, ItemClickEventArgs e)
        {
            chartControlPivot.OptionsPrint.SizeMode = DevExpress.XtraCharts.Printing.PrintSizeMode.Stretch;
            this.chartControlPivot.ShowPrintPreview();
        }

        private void barButtonItemExcelChart_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (saveFileDialogXls.ShowDialog(this) == DialogResult.OK)
            {
                this.chartControlPivot.ExportToXls(saveFileDialogXls.FileName);
                if (File.Exists(saveFileDialogXls.FileName))
                {
                    Process.Start(saveFileDialogXls.FileName);
                }
            }
        }

        private void ribbon_ApplicationButtonClick(object sender, EventArgs e)
        {
            Process.Start("http://www.xpsoft.it");
        }

        private bool mcheck = false;
        private void simpleButtonTutti_Click(object sender, EventArgs e)
        {
            if (mcheck)
                this.checkedListBoxControl1.UnCheckAll();
            else
                this.checkedListBoxControl1.CheckAll();

            mcheck = !mcheck;
        }

        private string _filterStrutture = string.Empty;
        private string _filterData = string.Empty;
        private string _filterModo = string.Empty;
        private void barButtonItemStampaPS_ItemClick(object sender, ItemClickEventArgs e)
        {
            //PageHeaderFooter header = new PageHeaderFooter();
            //header.Footer.Content.Add(Program.UtenteCollegato.FullName);
            //header.Footer.Content.Add(Program.Postazione.Nome);
            //header.Footer.Content.Add(string.Format("{0:g}", DateTime.Now));

            //header.Header.Content.Add("");
            //header.Header.Content.Add(_filter);
            //header.Header.Content.Add("");

            //this.printableComponentLink1.PageHeaderFooter = header;

            string str = "";

            switch (_filterModo)
            {
                case "emessoda":
                    str = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1040{\fonttbl{\f0\fnil\fcharset0 Calibri;}}
{\*\generator Msftedit 5.41.21.2510;}\viewkind4\uc1\pard\sa200\sl276\slmult1\lang16\f0\fs22 Vendite effettuate \b (data1)\b0  nelle seguenti strutture: (aa1)\par}";
                    break;
                case "validiper":
                str = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1040{\fonttbl{\f0\fnil\fcharset0 Calibri;}}
{\*\generator Msftedit 5.41.21.2510;}\viewkind4\uc1\pard\sa200\sl276\slmult1\lang16\f0\fs22 Biglietti emessi \b (data1)\b0  per le seguenti strutture: (aa1)\par}";
                    break;
                default:
                    throw new Exception("non previsto");
            }

            str = str.Replace("(data1)", _filterData);
            str = str.Replace("(aa1)", _filterStrutture);

            this.printableComponentLink1.RtfReportHeader = str;

            this.printableComponentLink1.CreateDocument();
            this.printableComponentLink1.ShowRibbonPreviewDialog(DevExpress.LookAndFeel.UserLookAndFeel.Default);
        }

        private void ribbonGalleryBarItemLayout_Gallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            string nome = e.Item.Caption;
            ConfigurazioneCaricata = this.unitOfWork1.FindObject<ConfigurazionePivot>(new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                new BinaryOperator("Descrizione", nome),
                new BinaryOperator("Tipo", STR_PivotRigaVenditaVariante)
            }));

            if (ConfigurazioneCaricata != null)
                LoadLayout();
        }
    }
}

