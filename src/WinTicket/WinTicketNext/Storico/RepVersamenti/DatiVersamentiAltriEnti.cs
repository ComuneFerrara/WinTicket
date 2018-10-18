using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Musei.Module;

namespace WinTicketNext.Storico.RepVersamenti
{
    public class DatiVersamentiAltriEnti
    {
        public string Soggetto { get; set; }
        public SoggettoEconomico SoggettoEconomico { get; set; }

        public decimal Importo { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
    }
}
