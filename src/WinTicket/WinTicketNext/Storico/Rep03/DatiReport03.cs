using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Musei.Module;

namespace WinTicketNext.Storico.Rep03
{
    public class DatiReport03
    {
        public EnumTipologiaIngresso Tipologia { get; set; }
        public string Tipo { get; set; }
        public string OrdineTipo { get; set; }
        public string Museo { get; set; }
        public string Ordine { get; set; }

        public int PagantiAC { get; set; }
        public int NonPagantiAC { get; set; }
        public int TotaleAC { get { return PagantiAC + NonPagantiAC; } }

        public int GiorniAC { get; set; }

        public int PagantiAP { get; set; }
        public int NonPagantiAP { get; set; }
        public int TotaleAP { get { return PagantiAP + NonPagantiAP; } }

        public int GiorniAP { get; set; }

        public string Perc { get; set; }
        public string PercGruppo { get; set; }
        public string PercTotale { get; set; }

        public string PercTotaleGruppoACPaganti { get; set; }
        public string PercTotaleGruppoACNonPaganti { get; set; }
        public string PercTotaleGruppoAPPaganti { get; set; }
        public string PercTotaleGruppoAPNonPaganti { get; set; }

        public string PercTotaleACPaganti { get; set; }
        public string PercTotaleACNonPaganti { get; set; }
        public string PercTotaleAPPaganti { get; set; }
        public string PercTotaleAPNonPaganti { get; set; }

        public void CalcolaTotale()
        {
            if (Tipo.Contains("pagamento"))
                OrdineTipo = String.Format("111{0}", Tipo);
            else
                OrdineTipo = String.Format("222{0}", Tipo);

            if (TotaleAP != 0)
                Perc = string.Format("{0:#,##0.0%;-#,##0.0%}", (TotaleAC - TotaleAP) / (double)TotaleAP);
            else
                Perc = "n/a";
        }

        public void CalcolaTotale(List<DatiReport03> elenco)
        {
            int totaletotaleac = 0;
            int totaletotaleap = 0;
            int totaletotaleacpag = 0;
            int totaletotaleacnonpag = 0;
            int totaletotaleappag = 0;
            int totaletotaleapnonpag = 0;

            int totalegruppoac = 0;
            int totalegruppoacpag = 0;
            int totalegruppoacnonpag = 0;

            int totalegruppoap = 0;
            int totalegruppoappag = 0;
            int totalegruppoapnonpag = 0;

            foreach (DatiReport03 datiReport03 in elenco)
            {
                totaletotaleac += datiReport03.TotaleAC;
                totaletotaleap += datiReport03.TotaleAP;

                totaletotaleacpag += datiReport03.PagantiAC;
                totaletotaleacnonpag += datiReport03.NonPagantiAC;

                totaletotaleappag += datiReport03.PagantiAP;
                totaletotaleapnonpag += datiReport03.NonPagantiAP;

                if (datiReport03.Tipo == this.Tipo)
                {
                    totalegruppoac += datiReport03.TotaleAC;
                    totalegruppoap += datiReport03.TotaleAP;

                    totalegruppoacpag += datiReport03.PagantiAC;
                    totalegruppoacnonpag += datiReport03.NonPagantiAC;

                    totalegruppoappag += datiReport03.PagantiAP;
                    totalegruppoapnonpag += datiReport03.NonPagantiAP;
                }
            }

            if (totalegruppoap != 0)
            {
                PercGruppo = string.Format("{0:#,##0.0%;-#,##0.0%}", (totalegruppoac - totalegruppoap) / (double)totalegruppoap);

                PercTotaleGruppoAPPaganti = string.Format("{0:#,##0.0%}", (totalegruppoappag) / (double)totalegruppoap);
                PercTotaleGruppoAPNonPaganti = string.Format("{0:#,##0.0%}", (totalegruppoapnonpag) / (double)totalegruppoap);
            }
            else
                PercGruppo = "n/a";

            if (totalegruppoac != 0)
            {
                PercTotaleGruppoACPaganti = string.Format("{0:#,##0.0%}", (totalegruppoacpag) / (double)totalegruppoac);
                PercTotaleGruppoACNonPaganti = string.Format("{0:#,##0.0%}", (totalegruppoacnonpag) / (double)totalegruppoac);
            }

            if (totaletotaleap != 0)
            {
                PercTotale = string.Format("{0:#,##0.0%;-#,##0.0%}", (totaletotaleac - totaletotaleap) / (double)totaletotaleap);

                PercTotaleAPPaganti = string.Format("{0:#,##0.0%}", (totaletotaleappag) / (double)totaletotaleap);
                PercTotaleAPNonPaganti = string.Format("{0:#,##0.0%}", (totaletotaleapnonpag) / (double)totaletotaleap);
            }
            else
                PercTotale = "n/a";

            if (totaletotaleac != 0)
            {
                PercTotaleACPaganti = string.Format("{0:#,##0.0%}", (totaletotaleacpag) / (double)totaletotaleac);
                PercTotaleACNonPaganti = string.Format("{0:#,##0.0%}", (totaletotaleacnonpag) / (double)totaletotaleac);
            }
        }
    }
}
