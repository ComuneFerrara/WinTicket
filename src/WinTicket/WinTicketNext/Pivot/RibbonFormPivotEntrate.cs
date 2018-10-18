using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.IO;
using System.Diagnostics;
using DevExpress.Data.Filtering;
using Musei.Module;
using DevExpress.XtraPrinting;
using DevExpress.Utils;
using DevExpress.Xpo;
using DevExpress.XtraEditors;

namespace WinTicketNext
{
    public partial class RibbonFormPivotEntrate : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonFormPivotEntrate()
        {
            InitializeComponent();

            DateTime data = DateTime.Now.Date.AddMonths(-1);

            this.dateEditStart.DateTime = new DateTime(data.Year, data.Month, 1);
            this.dateEditEnd.DateTime = this.dateEditStart.DateTime.AddMonths(1).AddDays(-1);

            XPCollection<Ingresso> ingressi = Program.UtenteCollegato.GetMioElencoIngressi(this.unitOfWork1, Program.Postazione);
            this.checkedListBoxControl1.DataSource = ingressi;

            foreach (DevExpress.XtraPivotGrid.PivotGridField field in this.pivotGridControlStampe.Fields)
            {
                field.ToolTips.HeaderText = field.FieldName;
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

            int dateStartDay = this.dateEditStart.DateTime.Day;
            int dateStartMonth = this.dateEditStart.DateTime.Month;
            int dateStartYear = this.dateEditStart.DateTime.Year;

            int dateEndDay = this.dateEditEnd.DateTime.Day;
            int dateEndMonth = this.dateEditEnd.DateTime.Month;
            int dateEndYear = this.dateEditEnd.DateTime.Year;

            if (checkEditPeriodo.Checked)
            {
                GroupOperator rangeOrCriteria = new GroupOperator(GroupOperatorType.Or);

                for (int anno = dateStartYear; anno <= dateEndYear; anno++)
                {
                    GroupOperator rangeAndCriteria = new GroupOperator(GroupOperatorType.And);

                    DateTime startDate = new DateTime(anno, dateStartMonth, dateStartDay);
                    DateTime endDate = new DateTime(anno, dateEndMonth, dateEndDay).AddDays(1);
                    rangeAndCriteria.Operands.Add(new BinaryOperator("DataOraEntrata", startDate, BinaryOperatorType.GreaterOrEqual));
                    rangeAndCriteria.Operands.Add(new BinaryOperator("DataOraEntrata", endDate, BinaryOperatorType.Less));

                    rangeOrCriteria.Operands.Add(rangeAndCriteria);

                }

                newCriteria.Operands.Add(rangeOrCriteria);
            }
            else
            {
                DateTime startDate = new DateTime(dateStartYear, dateStartMonth, dateStartDay);
                DateTime endDate = new DateTime(dateEndYear, dateEndMonth, dateEndDay).AddDays(1);

                newCriteria.Operands.Add(new BinaryOperator("DataOraEntrata", startDate, BinaryOperatorType.GreaterOrEqual));
                newCriteria.Operands.Add(new BinaryOperator("DataOraEntrata", endDate, BinaryOperatorType.Less));
            }

            if (this.checkedListBoxControl1.CheckedItems.Count > 0)
            {
                GroupOperator orCriteria = new GroupOperator(GroupOperatorType.Or);
                foreach (Ingresso item in this.checkedListBoxControl1.CheckedItems)
                {
                    orCriteria.Operands.Add(new BinaryOperator("RigaStampaIngresso.Ingresso.Oid", item.Oid));
                }

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
                    this.xpCollectionEntrata.Criteria = GetNewCriteria();
                    this.xpCollectionEntrata.Load();

                    this.pivotGridControlStampe.BestFit();
                }
                else
                    XtraMessageBox.Show("Selezionare almeno un ingresso", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = saveCursor;
            }
        }

        private void pivotGridControlStampe_CellDoubleClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
        {
            XtraFormPivotDettaglioEntrate dettaglio = new XtraFormPivotDettaglioEntrate();
            dettaglio.DataBind(e.CreateDrillDownDataSource());
            dettaglio.Show();
        }

        private void barButtonItemLoadLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.openFileDialogXML.ShowDialog(this) == DialogResult.OK)
            {
                this.pivotGridControlStampe.RestoreLayoutFromXml(this.openFileDialogXML.FileName, OptionsLayoutBase.FullLayout);
                this.pivotGridControlStampe.BestFit();

                //barCheckItemCols.Checked = this.pivotGridControlStampe.OptionsView.ShowColumnGrandTotals;
                //barCheckItemRow.Checked = this.pivotGridControlStampe.OptionsView.ShowRowGrandTotals;
                //this.chartControl1.Enabled = barCheckItemGrafico.Checked;
            }
        }

        private void barButtonItemSaveLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.saveFileDialogXML.ShowDialog(this) == DialogResult.OK)
            {
                this.pivotGridControlStampe.SaveLayoutToXml(this.saveFileDialogXML.FileName, OptionsLayoutBase.FullLayout);
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
            //string name = e.DataField.FieldName; // Stampa.Vendita.Oid;

            //if (e.DataField.SummaryType == DevExpress.Data.PivotGrid.PivotSummaryType.Custom)
            //{
            //    if (name == "Vendita.Oid")
            //    {
            //        IList list = e.CreateDrillDownDataSource();
            //        Hashtable ht = new Hashtable();
            //        for (int i = 0; i < list.Count; i++)
            //        {
            //            DevExpress.XtraPivotGrid.PivotDrillDownDataRow row = list[i] as DevExpress.XtraPivotGrid.PivotDrillDownDataRow;

            //            object v = row[name];

            //            if (v != null && v != DBNull.Value)
            //                ht[v] = null;
            //        }

            //        e.CustomValue = ht.Count;
            //    }
            //}
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
    }
}

