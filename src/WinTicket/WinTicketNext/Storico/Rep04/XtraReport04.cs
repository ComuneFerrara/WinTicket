using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WinTicketNext.Storico.Rep04
{
    public partial class XtraReport04 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport04()
        {
            InitializeComponent();
        }

        internal void Init(System.Collections.Generic.List<DatiReport04> _List, DateTime inizio, DateTime fine, string info)
        {
            this.xrLabelTitolo.Text = String.Format("Visitatori del periodo: {0:00}/{1:00} - {2:00}/{3:00}", inizio.Day, inizio.Month, fine.Day, fine.Month ).ToUpper();
            foreach (DatiReport04 datiReport04 in _List)
            {
                this.bindingSource1.Add(datiReport04);
            }

            this.xrLabelInfo.Text = info;

            this.xrTableCellAnno1.Text = string.Format("{0}", inizio.Year);
            this.xrTableCellAnno2.Text = string.Format("{0}", inizio.Year-1);
            this.xrTableCellAnno3.Text = string.Format("{0}", inizio.Year-2);
            this.xrTableCellAnno4.Text = string.Format("{0}", inizio.Year-3);
            this.xrTableCellAnno5.Text = string.Format("{0}", inizio.Year-4);
        }
    }
}
