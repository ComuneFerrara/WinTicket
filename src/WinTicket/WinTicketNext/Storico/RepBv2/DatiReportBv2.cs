using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinTicketNext.Storico.RepBv2
{
    public class DatiReportBv2
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
        public List<Cumulativi> Cumulativi { get; set; }

        private string strip(string str)
        {
            return str.Replace("Biglietto per", string.Empty);
        }

        public VendutiPerTerzi PerAltriCerca(Musei.Module.Variante variante, Musei.Module.Struttura struttura)
        {
            foreach (VendutiPerTerzi vendutiPerTerzi in PerAltri)
            {
                if (vendutiPerTerzi.Struttura == struttura.Descrizione && vendutiPerTerzi.Biglietto == variante.Descrizione)
                    return vendutiPerTerzi;
            }

            VendutiPerTerzi nuovo = new VendutiPerTerzi();
            nuovo.Struttura = struttura.Descrizione;
            nuovo.SoggettoEconomico = struttura.SoggettoEconomico.RagioneSociale;
            nuovo.Biglietto = variante.Descrizione;

            PerAltri.Add(nuovo);
            return nuovo;
        }

        public Cumulativi CumulativiCerca(Musei.Module.Variante variante, Musei.Module.Struttura struttura)
        {
            string search = strip(variante.Biglietto.Descrizione);
            if (variante.TipologiaTre == Musei.Module.EnumTipologiaTre.CardMyFE && variante.PrezzoAttuale.PrezzoRidotto != null)
                search = strip(variante.PrezzoAttuale.PrezzoRidotto.Biglietto.Descrizione);

            foreach (var item in Cumulativi)
            {
                if (item.Struttura == struttura.Descrizione && item.Biglietto == search)
                    return item;
            }

            Cumulativi nuovo = new Cumulativi();
            nuovo.Struttura = struttura.Descrizione;
            nuovo.SoggettoEconomico = struttura.SoggettoEconomico.RagioneSociale;
            nuovo.Biglietto = search;

            Cumulativi.Add(nuovo);
            return nuovo;
        }
    }

    public class Cumulativi
    {
        public string Struttura { get; set; }
        public string SoggettoEconomico { get; set; }
        public string Biglietto { get; set; }

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
        public string Biglietto { get; set; }

        public int Pax { get; set; }
        public decimal TotaleContanti { get; set; }
        public decimal TotalePos { get; set; }

        public decimal Totale
        {
            get { return TotaleContanti + TotalePos; }
        }
    }

}
