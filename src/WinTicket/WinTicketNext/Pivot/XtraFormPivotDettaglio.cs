using System;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraPrinting;
using DevExpress.Xpo;
using Musei.Module;
using DevExpress.Data.Filtering;
using WinTicketNext.Storico;

namespace WinTicketNext
{
    public partial class XtraFormPivotDettaglio : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormPivotDettaglio()
        {
            InitializeComponent();
        }

        public void DataBind(PivotDrillDownDataSource dataset)
        {
            this.gridControl1.DataSource = dataset;
            this.gridView1.BestFitColumns();
        }

        private void barLargeButtonItemExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (saveFileDialogXls.ShowDialog(this) == DialogResult.OK)
            {
                this.gridControl1.ExportToXls(saveFileDialogXls.FileName, new XlsExportOptions(TextExportMode.Value));
                if (File.Exists(saveFileDialogXls.FileName))
                {
                    Process.Start(saveFileDialogXls.FileName);
                }
            }
        }

        private void barLargeButtonItemStampa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.gridControl1.ShowPrintPreview();
        }

        private void barLargeButtonItemCampi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.gridView1.ShowCustomization();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            PivotDrillDownDataRow row = this.gridView1.GetFocusedRow() as PivotDrillDownDataRow;
            if (row != null)
            {
                string codice = row.DataSource.GetValue(row.Index, "Vendita.CodiceLeggibile") as string;

                using (UnitOfWork uow = new UnitOfWork()) 
                {
                    Vendita vendita = uow.FindObject<Vendita>(new BinaryOperator("CodiceLeggibile", codice));

                    XtraFormDettaglioVendita dettaglio = new XtraFormDettaglioVendita();
                    dettaglio.Init(vendita);
                    dettaglio.ShowDialog(this);
                }
            }
        }
    }
}