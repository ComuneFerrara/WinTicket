using System;
using System.Linq;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.Xpo;
using System.Collections.Generic;
using Musei.Module;

namespace WinTicketNext.Storico.RepVersamenti
{
    public partial class XtraReportCorrispettiviBiglietteria : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportCorrispettiviBiglietteria()
        {
            InitializeComponent();
        }

        internal void Init(XPCollection<Vendita> elenco, DateTime inizio, DateTime fine, Struttura struttura)
        {
            List<DatiReportCorrispettivi> dati = new List<DatiReportCorrispettivi>();

            DateTime giro = inizio;
            while (giro <= fine)
            {
                dati.Add(new DatiReportCorrispettivi() { Giornata = giro, Struttura = struttura.Descrizione });
                giro = giro.AddDays(1);
            }

            foreach (Vendita vendita in elenco)
            {
                DatiReportCorrispettivi riga = dati.Where(a => a.Giornata == vendita.DataContabile).FirstOrDefault();
                if (riga == null)
                {
                    riga = new DatiReportCorrispettivi();
                    riga.Giornata = vendita.DataContabile;
                    riga.Struttura = vendita.Struttura.Descrizione;

                    dati.Add(riga);
                }

                riga.Totale += vendita.TotaleImporto;
                riga.Contanti += vendita.Incasso == EnumIncasso.Contanti ? vendita.TotaleImporto : 0;
                riga.Pos += vendita.Incasso == EnumIncasso.Pos ? vendita.TotaleImporto : 0;
                riga.Internet += vendita.Incasso == EnumIncasso.Internet ? vendita.TotaleImporto : 0;
            }

            foreach (DatiReportCorrispettivi datiReportCorrispettivi in dati)
            {
                this.bindingSource1.Add(datiReportCorrispettivi);
            }

            this.xrLabelPeriodo.Text = string.Format("Periodo: dal {0:d} al {1:d}", inizio, fine);
        }
    }
}
