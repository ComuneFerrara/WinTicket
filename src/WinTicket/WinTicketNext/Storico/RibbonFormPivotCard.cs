using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.Data.Filtering;
using Musei.Module;

namespace WinTicketNext.Storico
{
    public partial class RibbonFormPivotCard : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonFormPivotCard()
        {
            InitializeComponent();

            DateTime to = DateTime.Today;
            DateTime dt = to.AddMonths(-1);
            this.barEditItemDateStart.EditValue = new DateTime(dt.Year, dt.Month, 1);
            this.barEditItemDateEnd.EditValue = new DateTime(to.Year, to.Month, 1).AddDays(-1);
        }

        private void barButtonItemQuery_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor saveCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                GroupOperator criteria = new GroupOperator(GroupOperatorType.And);

                if (this.barEditItemDateStart.EditValue != null)
                {
                    var dt = (DateTime)this.barEditItemDateStart.EditValue;
                    criteria.Operands.Add(new BinaryOperator("Stampa.Vendita.DataContabile", dt, BinaryOperatorType.GreaterOrEqual));
                }
                if (this.barEditItemDateEnd.EditValue != null)
                {
                    var dt = (DateTime)this.barEditItemDateEnd.EditValue;
                    criteria.Operands.Add(new BinaryOperator("Stampa.Vendita.DataContabile", dt, BinaryOperatorType.LessOrEqual));
                }
                if (!this.barCheckItemTutto.Checked)
                {
                    criteria.Operands.Add(new BinaryOperator("Status", EnumStatoCard.Emessa));
                }

                this.xpCollectionCard.Criteria = criteria;
                this.pivotGridControl1.BestFit();
            }
            finally
            {
                Cursor.Current = saveCursor;
            }
        }

        private void barButtonItemPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            string str = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1040{\fonttbl{\f0\fnil\fcharset0 Calibri;}}
{\*\generator Msftedit 5.41.21.2510;}\viewkind4\uc1\pard\sa200\sl276\slmult1\lang16\f0\fs22 Card MyFE \b (data1)\b0\par}";

            var dt1 = (DateTime)this.barEditItemDateStart.EditValue;
            var dt2 = (DateTime)this.barEditItemDateEnd.EditValue;

            str = str.Replace("data1", string.Format("dal {0:d} al {1:d}", dt1, dt2));

            this.printableComponentLink1.RtfReportHeader = str;

            this.printableComponentLink1.CreateDocument();
            this.printableComponentLink1.ShowRibbonPreviewDialog(DevExpress.LookAndFeel.UserLookAndFeel.Default);

            //this.pivotGridControl1.ShowRibbonPrintPreview();
        }
    }
}