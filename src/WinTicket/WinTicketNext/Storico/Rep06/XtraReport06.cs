using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WinTicketNext.Storico.Rep06
{
    public partial class XtraReport06 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport06()
        {
            InitializeComponent();
        }

        internal void Init(System.Collections.Generic.List<DatiReport06> _List, DateTime inizio, DateTime fine, string info)
        {
            this.xrLabelTitolo.Text = String.Format("Visitatori dei musei e spazi espositivi: {0:d} - {1:d}", inizio, fine).ToUpper();
            foreach (DatiReport06 dato in _List)
            {
                if (dato.Totale == 0 && dato.Tipologia == Musei.Module.EnumTipologiaIngresso.Sistema)
                {
                    // questi non devono comparire nel report
                }
                else
                    this.bindingSource1.Add(dato);
            }

            this.xrLabelInfo.Text = info;

            this.xrTableCellAnno.Text = string.Format("ANNO {0}", inizio.Year);
            this.xrTableCellAnno1.Text = string.Format("{0}", inizio.Year - 1);
            this.xrTableCellAnno2.Text = string.Format("{0}", inizio.Year - 2);
            this.xrTableCellAnnoPerc1.Text = string.Format("% {0}-{1}", inizio.Year, inizio.Year - 1);
            this.xrTableCellAnnoPerc2.Text = string.Format("% {0}-{1}", inizio.Year, inizio.Year - 2);
        }
    }
}
