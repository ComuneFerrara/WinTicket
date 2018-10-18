using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WinTicketNext.Storico.Rep03
{
    public partial class XtraReport03 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport03()
        {
            InitializeComponent();
        }

        internal void Init(System.Collections.Generic.List<DatiReport03> _List, DateTime inizio, DateTime fine, string info)
        {
            this.xrTableCellAnnoC.Text = inizio.Year.ToString();
            this.xrTableCellAnnoP.Text = (inizio.Year - 1).ToString();
            this.xrTableCellAnni.Text = string.Format("{0} / {1}", inizio.Year, inizio.Year - 1);
            this.xrLabelTitolo.Text = String.Format("Visitatori paganti e non paganti dei musei e spazi espositivi: {0:d} - {1:d}", inizio, fine).ToUpper();
            foreach (DatiReport03 datiReport03b in _List)
            {
                if (datiReport03b.TotaleAC == 0 && datiReport03b.TotaleAP == 0 && datiReport03b.Tipologia == Musei.Module.EnumTipologiaIngresso.Sistema)
                {
                    // questi non devono comparire nel report
                }
                else
                    this.bindingSource1.Add(datiReport03b);
            }

            this.xrLabelInfo.Text = info;
        }
    }
}
