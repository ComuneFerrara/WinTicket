using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WinTicketNext.Storico.Rep01
{
    public partial class XtraReport01 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport01()
        {
            InitializeComponent();
        }


        internal void Init(System.Collections.Generic.List<DatiReport01> _List, DateTime inizio, DateTime fine, string info)
        {
            foreach (DatiReport01 datiReport01 in _List)
            {
                this.bindingSource1.Add(datiReport01);
            }

            this.xrLabelDate.Text = string.Format("dal {0:d} al {1:d}", inizio, fine);
            this.xrLabelInfo.Text = info;
        }
    }
}
