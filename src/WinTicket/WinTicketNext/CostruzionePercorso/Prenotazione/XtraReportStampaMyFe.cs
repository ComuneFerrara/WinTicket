using System;
using DevExpress.XtraReports.UI;
using DevExpress.Data.Filtering;
using Musei.Module;
using System.Collections.Generic;

namespace WinTicketNext.CostruzionePercorso.GestionePrenotazione
{
    public partial class XtraReportStampaMyFe : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportStampaMyFe()
        {
            InitializeComponent();
        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XtraReportRigaStampaMyFE)((XRSubreport)sender).ReportSource).xpCollection1.Criteria = 
                new BinaryOperator("Stampa.Oid", GetCurrentColumnValue("Oid"));
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (this.xpCollection1.Count == 1)
            {
                Stampa stampa = this.xpCollection1[0] as Stampa;

                if (stampa != null)
                {
                    stampa.NumeroStampe++;
                    stampa.Save();
                    this.unitOfWork1.CommitChanges();

                    foreach (XRTableCell cell in this.xrTable1.Rows[0].Cells)
                    {
                        cell.Text = string.Empty;
                    }

                    List<RigaStampaIngresso> sl = new List<RigaStampaIngresso>(stampa.RigheStampaIngresso);
                    sl.Sort((a, b) => a.Ingresso.Descrizione.CompareTo(b.Ingresso.Descrizione));
                    for (int i = 0; i < sl.Count; i++)
                    {
                        this.xrTable1.Rows[0].Cells[i].Text = sl[i].Ingresso.IntestazioneStampa;
                    }
                    foreach (XRTableCell cell in this.xrTable1.Rows[0].Cells)
                    {
                        if (string.IsNullOrEmpty(cell.Text)) cell.Visible = false;
                    }

                    this.xrLabelTitleRiga1.Text = string.Format("MyFE CARD - {0} days {1:c}", stampa.Card.Giorni(), stampa.ImportoTotale);

                    string descrizione =
                    string.Format("Emesso da {0} il {1:g}. Validità dal {2:d} al {3:d} per i seguenti musei:",
                        stampa.Vendita.Struttura.Descrizione,
                        stampa.Vendita.DataOraStampa,
                        stampa.InizioValidita,
                        stampa.FineValidita
                        );

                    this.xrLabelInfo1.Text = descrizione;
                }
            }
            else
                throw new Exception("STAMPA is wrong");
        }
    }
}
