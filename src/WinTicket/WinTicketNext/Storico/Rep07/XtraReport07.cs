using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WinTicketNext.Storico.Rep07
{
    public partial class XtraReport07 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport07()
        {
            InitializeComponent();
        }

        internal void Init(System.Collections.Generic.List<DatiReport07> _List, DateTime inizio, DateTime fine, string info)
        {
            foreach (DatiReport07 datiReport01 in _List)
            {
                this.bindingSource1.Add(datiReport01);
            }

            this.xrLabelDate.Text = string.Format("Vendite MyFE: dal {0:d} al {1:d}", inizio, fine);
            this.xrLabelInfo.Text = info;
        }
    }
}
