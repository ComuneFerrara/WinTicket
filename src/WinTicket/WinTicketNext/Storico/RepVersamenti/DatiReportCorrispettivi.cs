using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WinTicketNext.Storico.RepVersamenti
{
    public class DatiReportCorrispettivi
    {
        public string Struttura { get; set; }

        public DateTime Giornata { get; set; }

        public decimal Totale { get; set; }

        public decimal Contanti { get; set; }
        public decimal Pos { get; set; }
        public decimal Internet { get; set; }
    }
}
