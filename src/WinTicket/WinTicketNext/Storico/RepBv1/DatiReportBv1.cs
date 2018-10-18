using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinTicketNext.Storico.RepBv1
{
    public class DatiReportBv1
    {
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public string Struttura { get; set; }

        // venduti in proprio
        public int TotalePax { get; set; }
        public decimal TotaleContanti { get; set; }
        public decimal TotalePos { get; set; }
        public decimal Totale
        {
            get { return TotaleContanti + TotalePos; }
        }

        public List<VendutiPerTerzi> PerAltri { get; set; }
        public List<BigliettiInProprio> InProprio { get; set; }
        public List<Cumulativi> Cumulativi { get; set; }

        public VendutiPerTerzi PerAltriCerca(Musei.Module.Struttura struttura)
        {
            foreach (VendutiPerTerzi vendutiPerTerzi in PerAltri)
            {
                if (vendutiPerTerzi.Struttura == struttura.Descrizione)
                    return vendutiPerTerzi;
            }

            VendutiPerTerzi nuovo = new VendutiPerTerzi();
            nuovo.Struttura = struttura.Descrizione;
            nuovo.SoggettoEconomico = struttura.SoggettoEconomico.RagioneSociale;

            PerAltri.Add(nuovo);
            return nuovo;
        }

        public BigliettiInProprio InProprioCerca(Musei.Module.Variante variante)
        {
            foreach (var item in InProprio)
            {
                if (item.Variante == variante.Descrizione)
                    return item;
            }

            BigliettiInProprio nuovo = new BigliettiInProprio();
            nuovo.Variante = variante.Descrizione;

            InProprio.Add(nuovo);
            return nuovo;
        }

        public Cumulativi CumulativiCerca(Musei.Module.Variante variante)
        {
            string search = variante.Descrizione;
            if (variante.TipologiaTre == Musei.Module.EnumTipologiaTre.CardMyFE && variante.PrezzoAttuale.PrezzoRidotto != null)
                search = variante.PrezzoAttuale.PrezzoRidotto.Descrizione;

            foreach (var item in Cumulativi)
            {
                if (item.Variante == search)
                    return item;
            }

            Cumulativi nuovo = new Cumulativi();
            nuovo.Variante = search;

            Cumulativi.Add(nuovo);
            return nuovo;
        }
    }

    public class BigliettiInProprio
    {
        public string Variante { get; set; }

        public int Pax { get; set; }
        public decimal TotaleContanti { get; set; }
        public decimal TotalePos { get; set; }

        public decimal Totale
        {
            get { return TotaleContanti + TotalePos; }
        }
    }

    public class Cumulativi
    {
        public string Variante { get; set; }

        public int Pax { get; set; }
        public decimal TotaleContanti { get; set; }
        public decimal TotalePos { get; set; }

        public decimal Totale
        {
            get { return TotaleContanti + TotalePos; }
        }
    }

    public class VendutiPerTerzi
    {
        public string Struttura { get; set; }
        public string SoggettoEconomico { get; set; }

        public int Pax { get; set; }
        public decimal TotaleContanti { get; set; }
        public decimal TotalePos { get; set; }

        public decimal Totale
        {
            get { return TotaleContanti + TotalePos; }
        }
    }

}
