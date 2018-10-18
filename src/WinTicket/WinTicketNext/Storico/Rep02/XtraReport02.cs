using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WinTicketNext.Storico.Rep02
{
    public partial class XtraReport02 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport02()
        {
            InitializeComponent();
        }

        internal void Init(System.Collections.Generic.List<DatiReport02> _List, DateTime inizio, DateTime fine)
        {
            foreach (DatiReport02 datiReport02 in _List)
            {
                this.bindingSource1.Add(datiReport02);
            }

            this.xrLabelDate.Text = string.Format("dal {0:d} al {1:d}", inizio, fine);
        }
    }
}
