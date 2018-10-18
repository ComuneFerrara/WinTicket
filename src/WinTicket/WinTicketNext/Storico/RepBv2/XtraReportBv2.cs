using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WinTicketNext.Storico.RepBv2
{
    public partial class XtraReportBv2 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportBv2()
        {
            InitializeComponent();
        }


        internal void Init(DatiReportBv2 dati)
        {
            this.bindingSource1.Add(dati);

            this.xrLabelPeriodo.Text = string.Format("Periodo: dal {0:d} al {1:d}", dati.Inizio, dati.Fine);
            this.xrLabelH1.Text = string.Format("Biglietti emessi da altri musei per {0}", dati.Struttura);
            this.xrLabelH2.Text = string.Format("Biglietti cumulativi emessi da altri per {0}", dati.Struttura);
        }
    }
}
