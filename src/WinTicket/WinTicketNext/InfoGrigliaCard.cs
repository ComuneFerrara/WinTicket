using Musei.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinTicketNext
{
    public class InfoGrigliaCard
    {
        public EnumTipologiaCard Tipologia { get; set; }
        public int QuestaSettimana { get; set; }
        public int ScorsaSettimana { get; set; }
        public int QuestoMese { get; set; }
        public int ScorsoMese { get; set; }
        public int Totale { get; set; }
    }
}
