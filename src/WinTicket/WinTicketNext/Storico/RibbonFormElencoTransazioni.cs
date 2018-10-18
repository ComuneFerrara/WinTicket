using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Musei.Module;
using DevExpress.XtraEditors;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;

namespace WinTicketNext.Storico
{
    public partial class RibbonFormElencoTransazioni : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonFormElencoTransazioni()
        {
            InitializeComponent();
        }

        private XPCollection<TransazioneWeb> _Collection;
        private void barButtonItemQuery_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor saveCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                GroupOperator criteria = new GroupOperator(GroupOperatorType.And);

                if (this.barEditItemDalla.EditValue != null)
                {
                    var dt = (DateTime)this.barEditItemDalla.EditValue;
                    criteria.Operands.Add(new BinaryOperator("InseritaIlDateTime", dt, BinaryOperatorType.GreaterOrEqual));
                }
                if (this.barEditItemAlla.EditValue != null)
                {
                    var dt = (DateTime)this.barEditItemAlla.EditValue;
                    criteria.Operands.Add(new BinaryOperator("InseritaIlDateTime", dt, BinaryOperatorType.LessOrEqual));
                }

                _Collection = new XPCollection<TransazioneWeb>(this.unitOfWork1, criteria);
                this.gridControlCard.DataSource = _Collection;

                this.gridViewCard.BestFitMaxRowCount = 100;
                this.gridViewCard.BestFitColumns();
            }
            finally
            {
                Cursor.Current = saveCursor;
            }
        }

        private void barButtonItemStampa_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.gridControlCard.ShowRibbonPrintPreview();
        }
    }
}