using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Musei.Module;

namespace WinTicketNext.Storico.Rep04
{
    public class DatiReport04
    {
        public string Tipo { get; set; }
        public string OrdineTipo { get; set; }
        public string Museo { get; set; }
        public string Ordine { get; set; }

        public int VisAnno1 { get; set; }
        public int GioAnno1 { get; set; }
        public int MedAnno1 { get; set; }
        public int VisAnno2 { get; set; }
        public int GioAnno2 { get; set; }
        public int MedAnno2 { get; set; }
        public int VisAnno3 { get; set; }
        public int GioAnno3 { get; set; }
        public int MedAnno3 { get; set; }
        public int VisAnno4 { get; set; }
        public int GioAnno4 { get; set; }
        public int MedAnno4 { get; set; }
        public int VisAnno5 { get; set; }
        public int GioAnno5 { get; set; }
        public int MedAnno5 { get; set; }

        public int TVisAnno1 { get; set; }
        public int TGioAnno1 { get; set; }
        public int TMedAnno1 { get; set; }
        public int TVisAnno2 { get; set; }
        public int TGioAnno2 { get; set; }
        public int TMedAnno2 { get; set; }
        public int TVisAnno3 { get; set; }
        public int TGioAnno3 { get; set; }
        public int TMedAnno3 { get; set; }
        public int TVisAnno4 { get; set; }
        public int TGioAnno4 { get; set; }
        public int TMedAnno4 { get; set; }
        public int TVisAnno5 { get; set; }
        public int TGioAnno5 { get; set; }
        public int TMedAnno5 { get; set; }


        public void CalcolaTotale()
        {
            if (Tipo.Contains("pagamento"))
                OrdineTipo = String.Format("111{0}", Tipo);
            else
                OrdineTipo = String.Format("222{0}", Tipo);

            if (GioAnno1 != 0) MedAnno1 = VisAnno1 / GioAnno1;
            if (GioAnno2 != 0) MedAnno2 = VisAnno2 / GioAnno2;
            if (GioAnno3 != 0) MedAnno3 = VisAnno3 / GioAnno3;
            if (GioAnno4 != 0) MedAnno4 = VisAnno4 / GioAnno4;
            if (GioAnno5 != 0) MedAnno5 = VisAnno5 / GioAnno5;
        }

        public void CalcolaTotale(List<DatiReport04> elenco)
        {
            foreach (DatiReport04 dao in elenco)
            {
                TVisAnno1 += dao.VisAnno1;
                TVisAnno2 += dao.VisAnno2;
                TVisAnno3 += dao.VisAnno3;
                TVisAnno4 += dao.VisAnno4;
                TVisAnno5 += dao.VisAnno5;

                TGioAnno1 += dao.GioAnno1;
                TGioAnno2 += dao.GioAnno2;
                TGioAnno3 += dao.GioAnno3;
                TGioAnno4 += dao.GioAnno4;
                TGioAnno5 += dao.GioAnno5;
            }

            if (TGioAnno1 != 0) TMedAnno1 = TVisAnno1 / TGioAnno1;
            if (TGioAnno2 != 0) TMedAnno2 = TVisAnno2 / TGioAnno2;
            if (TGioAnno3 != 0) TMedAnno3 = TVisAnno3 / TGioAnno3;
            if (TGioAnno4 != 0) TMedAnno4 = TVisAnno4 / TGioAnno4;
            if (TGioAnno5 != 0) TMedAnno5 = TVisAnno5 / TGioAnno5;
        }
    }
}
