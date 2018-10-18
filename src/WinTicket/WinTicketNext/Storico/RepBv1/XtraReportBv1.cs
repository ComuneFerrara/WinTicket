using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WinTicketNext.Storico.RepBv1
{
    public partial class XtraReportBv1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportBv1()
        {
            InitializeComponent();
        }


        internal void Init(DatiReportBv1 dati)
        {
            this.bindingSource1.Add(dati);

            this.xrLabelPeriodo.Text = string.Format("Periodo: dal {0:d} al {1:d}", dati.Inizio, dati.Fine);
            this.xrLabelH1.Text = string.Format("Biglietti emessi da {0} per sè", dati.Struttura);
            this.xrLabelH2.Text = string.Format("Biglietti emessi da {0} per altre strutture", dati.Struttura);
            this.xrLabelH3.Text = string.Format("Biglietti cumulativi emessi da {0}", dati.Struttura);
        }
    }
}
