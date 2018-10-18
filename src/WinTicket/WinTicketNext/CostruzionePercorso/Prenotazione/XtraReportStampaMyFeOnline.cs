using System;
using DevExpress.XtraReports.UI;
using DevExpress.Data.Filtering;
using Musei.Module;
using System.Collections.Generic;

namespace WinTicketNext.CostruzionePercorso.GestionePrenotazione
{
    public partial class XtraReportStampaMyFeOnline : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportStampaMyFeOnline()
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

                    this.xrLabelTitleRiga1.Text = string.Format("MyFE CARD - {0} days", stampa.Card.Giorni());

                    string descrizione =
                        string.Format("Vendita online del {0:g}. Validità dal {1:d} al {2:d} per i seguenti musei:",
                            stampa.Card.AssegnataIl,
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
