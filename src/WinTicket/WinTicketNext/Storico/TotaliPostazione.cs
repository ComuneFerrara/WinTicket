using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinTicketNext.Storico
{
    public class TotaliPostazione
    {
        //public DateTime Data { get; set; }

        public string Biglietto { get; set; }
        public string Variante { get; set; }
        public string Titolo { get; set; }

        public decimal Qta { get; set; }
        public decimal Tot { get; set; }

        public decimal Pos { get; set; }
        public decimal Contanti { get; set; }
        public decimal Online { get; set; }
        public decimal FatturaElettronica { get; set; }
    }
}
