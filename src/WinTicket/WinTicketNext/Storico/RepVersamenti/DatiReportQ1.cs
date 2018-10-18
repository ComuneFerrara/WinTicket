using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WinTicketNext.Storico.RepVersamenti
{
    public class DatiReportQ1
    {
        public int MeseInizio { get; set; }

        public string Periodo { get; set; }
        public string RicevutePeriodo { get; set; }
        public decimal ImportoPeriodo { get; set; }

        public string Note { get; set; }

        public List<DatiReportQ1Sub> Elenco { get; set; }

        internal void CalcolaTotale()
        {
            ImportoPeriodo = 0;
            foreach (DatiReportQ1Sub datiReportQ1Sub in Elenco)
            {
                ImportoPeriodo += datiReportQ1Sub.Importo;

                // caso Q1A (solo un elemento nella lista dei versamenti per ogni mese
                Quietanza = datiReportQ1Sub.Quietanza;
                Importo = datiReportQ1Sub.Importo;
            }
        }

        public string Quietanza { get; set; }
        public decimal Importo { get; set; }
    }

    public class DatiReportQ1Sub
    {
        public string Quietanza { get; set; }
        public decimal Importo { get; set; }
    }
}
