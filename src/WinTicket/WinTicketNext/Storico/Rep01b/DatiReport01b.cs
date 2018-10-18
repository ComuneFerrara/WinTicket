using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinTicketNext.Storico.Rep01b
{
    public class DatiReport01b
    {
        public string Museo { get; set; }
        public string Ordine { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }

        public int MuseoStandardIntero { get; set; }
        public int MuseoStandardRidotto { get; set; }

        public int MuseoCardIntero { get; set; }
        public int MuseoCardRidotto { get; set; }

        public int MuseoCumulativoIntero { get; set; }
        public int MuseoCumulativoRidotto { get; set; }

        public int MuseoBigliettone { get; set; }
        public int MuseoOmaggio { get; set; }

        public int MuseoTotale { get; set; }

        public int AltriStandardIntero { get; set; }
        public int AltriStandardRidotto { get; set; }

        public int AltriCardIntero { get; set; }
        public int AltriCardRidotto { get; set; }

        public int AltriCumulativoIntero { get; set; }
        public int AltriCumulativoRidotto { get; set; }

        public int AltriBigliettone { get; set; }
        public int AltriOmaggio { get; set; }

        public int AltriTotale { get; set; }

        public int Totale { get; set; }

        internal void CalcolaTotali()
        {
            MuseoTotale = MuseoStandardIntero + MuseoStandardRidotto + MuseoCardIntero + MuseoCardRidotto + MuseoCumulativoIntero + MuseoCumulativoRidotto + MuseoBigliettone + MuseoOmaggio;
            AltriTotale = AltriStandardIntero + AltriStandardRidotto + AltriCardIntero + AltriCardRidotto + AltriCumulativoIntero + AltriCumulativoRidotto + AltriBigliettone + AltriOmaggio;
            Totale = MuseoTotale + AltriTotale;
        }
    }
}
