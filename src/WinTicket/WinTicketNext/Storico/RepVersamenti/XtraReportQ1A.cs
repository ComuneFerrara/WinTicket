using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Musei.Module;
using System.Collections.Generic;

namespace WinTicketNext.Storico.RepVersamenti
{
    public partial class XtraReportQ1A : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportQ1A()
        {
            InitializeComponent();
        }


        internal void Init(List<DatiReportQ1> elenco, Struttura struttura, DateTime inizio, SoggettoEconomico destinazione)
        {
            foreach (DatiReportQ1 dati in elenco)
            {
                this.bindingSource1.Add(dati);
            }

            this.xrLabelT1.Text = string.Format("{0} - {1} - CONTO DELLA GESTIONE DELL'AGENTE CONTABILE ESTERNO COMPILATO PER {2} - ANNO {3}", 
                struttura.Descrizione,
                struttura.SoggettoEconomico.RagioneSociale, 
                destinazione.RagioneSociale,
                inizio.Year).ToUpper();

            this.xrLabelAgente.Text = string.Format("L'agente contabile {0}", struttura.Descrizione);
            this.xrLabelNome.Text = struttura.Responsabile;
            xrTableCellNote.Text = string.Format("Numerazione compresa in quella complessiva della biglietteria elettronica di: {0}", struttura.SoggettoEconomico.RagioneSociale);
        }

        //private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        //{
        //    ((XRSubreport)sender).ReportSource.DataSource = GetCurrentColumnValue("Elenco");
        //}

    }
}
