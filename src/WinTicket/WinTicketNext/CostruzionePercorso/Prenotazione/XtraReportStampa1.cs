using System;
using DevExpress.XtraReports.UI;
using DevExpress.Data.Filtering;
using Musei.Module;

namespace WinTicketNext.CostruzionePercorso.GestionePrenotazione
{
    public partial class XtraReportStampa1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportStampa1()
        {
            InitializeComponent();
        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XtraReportRigaStampa1)((XRSubreport)sender).ReportSource).xpCollection1.Criteria = 
                new BinaryOperator("Stampa.Oid", GetCurrentColumnValue("Oid"));
        }

        private string GetDesc(Stampa stampa)
        {
            Vendita vendita = stampa.Vendita;
            int profilo = stampa.StatoStampa;

            string result1 = string.Empty;
            string result2 = string.Empty;

            foreach (EnumTipologiaUno uno in Enum.GetValues(typeof(EnumTipologiaUno)))
            {
                foreach (RigaVenditaVariante item in vendita.RigheVenditaVariante)
                {
                    if (item.Profilo == profilo || profilo == -1)
                    {
                        if (item.Variante.TipologiaUno == uno)
                        {
                            string def1 = item.Variante.TipologiaUno.ToString();
                            if (!result1.Contains(def1))
                                result1 += (string.IsNullOrEmpty(result1) ? "" : "-") + def1;
                        }
                    }
                }
            }

            foreach (EnumTipologiaDue due in Enum.GetValues(typeof(EnumTipologiaDue)))
            {
                foreach (RigaVenditaVariante item in vendita.RigheVenditaVariante)
                {
                    if (item.Profilo == profilo || profilo == -1)
                    {
                        if (item.Variante.TipologiaDue == due)
                        {
                            string def2 = item.Variante.TipologiaDue.ToString();
                            if (!result2.Contains(def2))
                                result2 += (string.IsNullOrEmpty(result2) ? "" : "-") + def2;
                        }
                    }
                }
            }

            return string.Format("{0} {1}", result1, result2);
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

                    if (stampa.Quantita == 1)
                    {
                        this.xrLabelTitleRiga1.Text =
                        string.Format("Ingresso ({0:c} {1})", stampa.ImportoTotale, GetDesc(stampa));
                    }
                    else
                    {
                        this.xrLabelTitleRiga1.Text =
                        string.Format("Ingresso {0} pax {1:c}: {2}", stampa.Quantita, stampa.ImportoTotale, GetDesc(stampa));
                    }

                    if (stampa.InizioValidita == stampa.FineValidita)
                    {
                        this.xrLabelTitleRiga2.Text =
                        string.Format("Valido il giorno {0:d}", stampa.InizioValidita);
                    }
                    else
                    {
                        this.xrLabelTitleRiga2.Text =
                        string.Format("Validità dal {0:d} al {1:d}", stampa.InizioValidita, stampa.FineValidita);
                    }

                    string descrizione = 
                    string.Format("Emesso da {0} ({1}) il {2}.", stampa.Vendita.Struttura.Descrizione, stampa.CodiceProgressivo, stampa.Vendita.DataContabile.ToShortDateString());

                    if (string.IsNullOrEmpty(stampa.Vendita.CodicePrevent))
                        descrizione += " Valido per i seguenti ingressi:";
                    else
                        descrizione += string.Format(" Valido per i seguenti ingressi (prenotazione {0}):", stampa.Vendita.CodicePrevent);

                    this.xrLabelInfo1.Text = descrizione;
                }
            }
            else
                throw new Exception("STAMPA is wrong");
        }
    }
}
