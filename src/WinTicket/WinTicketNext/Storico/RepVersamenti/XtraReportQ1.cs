using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Musei.Module;
using System.Collections.Generic;

namespace WinTicketNext.Storico.RepVersamenti
{
    public partial class XtraReportQ1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportQ1()
        {
            InitializeComponent();
        }


        internal void Init(List<DatiReportQ1> elenco, Struttura struttura, DateTime inizio, int mesi)
        {
            foreach (DatiReportQ1 dati in elenco)
            {
                this.bindingSource1.Add(dati);
            }

            this.xrLabelT1.Text = string.Format("{0} - CONTO DELLA GESTIONE DELL'AGENTE CONTABILE - ANNO {1}", struttura.Descrizione, inizio.Year).ToUpper();
            if (mesi == 3)
                this.xrLabelT2.Text = string.Format("{0}° TRIMESTRE", inizio.Month / 3 + 1).ToUpper();
            else
                this.xrLabelT2.Text = "Report Annuale";

            this.xrLabelAgente.Text = struttura.Titolo;
            this.xrLabelNome.Text = struttura.Responsabile;
        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRSubreport)sender).ReportSource.DataSource = GetCurrentColumnValue("Elenco");
        }

    }
}
