using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Musei.Module;

namespace WinTicketNext.Storico.Rep06
{
    public class DatiReport06
    {
        public EnumTipologiaIngresso Tipologia { get; set; }
        public string Tipo { get; set; }
        public string OrdineTipo { get; set; }
        public string Museo { get; set; }
        public string Ordine { get; set; }

        public int Gennaio { get; set; }
        public int Febbraio { get; set; }
        public int Marzo { get; set; }
        public int Aprile { get; set; }
        public int Maggio { get; set; }
        public int Giugno { get; set; }
        public int Luglio { get; set; }
        public int Agosto { get; set; }
        public int Settembre { get; set; }
        public int Ottobre { get; set; }
        public int Novembre { get; set; }
        public int Dicembre { get; set; }

        public int Totale { get; set; }

        public int AnnoMeno1 { get; set; }
        public int AnnoMeno2 { get; set; }

        public double PercAnnoMeno1 { get; set; }
        public double PercAnnoMeno2 { get; set; }

        public double PercGruppoAnnoMeno1 { get; set; }
        public double PercGruppoAnnoMeno2 { get; set; }

        public double PercTotAnnoMeno1 { get; set; }
        public double PercTotAnnoMeno2 { get; set; }

        public void CalcolaTotale()
        {
            Totale = Gennaio + Febbraio + Marzo + Aprile + Maggio + Giugno + Luglio + Agosto + Settembre + Ottobre + Novembre + Dicembre;
            if (AnnoMeno1 > 0) PercAnnoMeno1 = (Totale - (double)AnnoMeno1) / (double)AnnoMeno1;
            if (AnnoMeno2 > 0) PercAnnoMeno2 = (Totale - (double)AnnoMeno2) / (double)AnnoMeno2;

            if (Tipo.Contains("pagamento"))
                OrdineTipo = String.Format("111{0}", Tipo);
            else
                OrdineTipo = String.Format("222{0}", Tipo);
        }

        public void CalcolaTotale(List<DatiReport06> elenco)
        {
            int tot0 = 0;
            int tot1 = 0;
            int tot2 = 0;

            int totGruppo0 = 0;
            int totGruppo1 = 0; 
            int totGruppo2 = 0;
            foreach (DatiReport06 dato in elenco)
            {
                if (dato.Tipo == this.Tipo)
                {
                    totGruppo0 += dato.Totale;
                    totGruppo1 += dato.AnnoMeno1;
                    totGruppo2 += dato.AnnoMeno2;
                }

                tot0 += dato.Totale;
                tot1 += dato.AnnoMeno1;
                tot2 += dato.AnnoMeno2;
            }

            if (totGruppo1 > 0) PercGruppoAnnoMeno1 = (totGruppo0 - (double)totGruppo1) / (double)totGruppo1;
            if (totGruppo2 > 0) PercGruppoAnnoMeno2 = (totGruppo0 - (double)totGruppo2) / (double)totGruppo2;

            if (tot1 > 0) PercTotAnnoMeno1 = (tot0 - (double)tot1) / (double)tot1;
            if (tot2 > 0) PercTotAnnoMeno2 = (tot0 - (double)tot2) / (double)tot2;
        }
    }
}
