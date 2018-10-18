using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Musei.Module;

namespace WinTicketNext.Storico.Rep02
{
    public class DatiReport02
    {
        public string Museo { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }

        public string Descrizione { get; set; }
        public Titolo Titolo { get; set; }
        public EnumTipologiaBiglietto Tipologia { get; set; }
        public EnumTipologiaUno TipologiaUno { get; set; }
        public EnumTipologiaDue TipologiaDue { get; set; }
        public EnumTipologiaTre TipologiaTre { get; set; }

        public int Ordine { get; set; }

        public int PagantiIntero { get; set; }
        public int PagantiRidotto { get; set; }
        public int PagantiTotale { get; set; }

        public int NonPaganti { get; set; }

        public int TotaleVisitatori { get; set; }

        public decimal PercTotale { get; set; }

        // totali generali percentuali
        public decimal TPagantiIntero { get; set; }
        public decimal TPagantiRidotto { get; set; }
        public decimal TPagantiTotale { get; set; }
        public decimal TNonPaganti { get; set; }
        public decimal TVisitatori { get; set; }

        internal void CalcolaTotali()
        {
            PagantiTotale = PagantiIntero + PagantiRidotto;
            TotaleVisitatori = PagantiTotale + NonPaganti;
        }

        internal void CalcolaPercentuali(List<DatiReport02> list)
        {
            if (Ordine == 50)
            {
                if (NonPaganti == 0)
                    Ordine -= 5;
                else if (PagantiTotale == 0)
                    Ordine += 5;
            }

            int totTotaleVisitatori = 0;
            foreach (DatiReport02 datiReport02 in list)
            {
                totTotaleVisitatori += datiReport02.TotaleVisitatori;
                TPagantiIntero += datiReport02.PagantiIntero;
                TPagantiRidotto += datiReport02.PagantiRidotto;
                TPagantiTotale += datiReport02.PagantiTotale;
                TNonPaganti += datiReport02.NonPaganti;
                //TTotaleVisitatori += datiReport02.TotaleVisitatori;
            }

            PercTotale = Math.Round(TotaleVisitatori / (decimal)totTotaleVisitatori, 4);

            TPagantiIntero = Math.Round(TPagantiIntero / (decimal)totTotaleVisitatori, 4);
            TPagantiRidotto = Math.Round(TPagantiRidotto / (decimal)totTotaleVisitatori, 4);
            TPagantiTotale = Math.Round(TPagantiTotale / (decimal)totTotaleVisitatori, 4);
            TNonPaganti = Math.Round(TNonPaganti / (decimal)totTotaleVisitatori, 4);

            TVisitatori = TNonPaganti + TPagantiTotale;

        }
    }
}
