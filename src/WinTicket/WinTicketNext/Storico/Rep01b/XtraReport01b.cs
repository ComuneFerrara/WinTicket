using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WinTicketNext.Storico.Rep01b
{
    public partial class XtraReport01b : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport01b()
        {
            InitializeComponent();
        }

        internal void Init(System.Collections.Generic.List<DatiReport01b> _List, DateTime inizio, DateTime fine, string info)
        {
            foreach (DatiReport01b datiReport01 in _List)
            {
                this.bindingSource1.Add(datiReport01);
            }

            this.xrLabelDate.Text = string.Format("Visitatori musei civici: dal {0:d} al {1:d}", inizio, fine);
            this.xrLabelInfo.Text = info;
        }
    }
}
