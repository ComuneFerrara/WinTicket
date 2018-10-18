using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WinTicketNext.Storico.Rep03b
{
    public partial class XtraReport03b : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport03b()
        {
            InitializeComponent();
        }

        internal void Init(System.Collections.Generic.List<DatiReport03b> _List, int anno, string info)
        {
            this.xrLabelTitolo.Text = String.Format("Visitatori paganti e non paganti dei musei e spazi espositivi dell'anno {0}", anno).ToUpper();
            foreach (DatiReport03b datiReport03b in _List)
            {
                if (datiReport03b.Totale == 0 && datiReport03b.Tipologia == Musei.Module.EnumTipologiaIngresso.Sistema)
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
