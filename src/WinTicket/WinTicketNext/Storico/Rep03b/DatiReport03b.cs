using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Musei.Module;

namespace WinTicketNext.Storico.Rep03b
{
    public class DatiReport03b
    {
        public EnumTipologiaIngresso Tipologia { get; set; }
        public string Tipo { get; set; }
        public string OrdineTipo { get; set; }
        public string Museo { get; set; }
        public string Ordine { get; set; }

        public string TipoPart2
        {
            get
            {
                return Tipo.Length > 29 ? Tipo.Substring(29, Tipo.Length - 29) : string.Empty;
            }
        }
        public string TipoPart1
        {
            get
            {
                return Tipo.Length > 29 ? Tipo.Substring(0, 29) : Tipo;
            }
        }

        public int M01 { get; set; }
        public int M02 { get; set; }
        public int M03 { get; set; }
        public int M04 { get; set; }
        public int M05 { get; set; }
        public int M06 { get; set; }
        public int M07 { get; set; }
        public int M08 { get; set; }
        public int M09 { get; set; }
        public int M10 { get; set; }
        public int M11 { get; set; }
        public int M12 { get; set; }

        public int M01Pag { get; set; }
        public int M01NPag { get; set; }

        public int M02Pag { get; set; }
        public int M02NPag { get; set; }

        public int M03Pag { get; set; }
        public int M03NPag { get; set; }

        public int M04Pag { get; set; }
        public int M04NPag { get; set; }

        public int M05Pag { get; set; }
        public int M05NPag { get; set; }

        public int M06Pag { get; set; }
        public int M06NPag { get; set; }

        public int M07Pag { get; set; }
        public int M07NPag { get; set; }

        public int M08Pag { get; set; }
        public int M08NPag { get; set; }

        public int M09Pag { get; set; }
        public int M09NPag { get; set; }

        public int M10Pag { get; set; }
        public int M10NPag { get; set; }

        public int M11Pag { get; set; }
        public int M11NPag { get; set; }

        public int M12Pag { get; set; }
        public int M12NPag { get; set; }

        public int Totale { get; set; }

        public void CalcolaTotale()
        {
            Totale =
                M01NPag +
                M02NPag +
                M03NPag +
                M04NPag +
                M05NPag +
                M06NPag +
                M07NPag +
                M08NPag +
                M09NPag +
                M10NPag +
                M11NPag +
                M12NPag;
            Totale +=
                M01Pag +
                M02Pag +
                M03Pag +
                M04Pag +
                M05Pag +
                M06Pag +
                M07Pag +
                M08Pag +
                M09Pag +
                M10Pag +
                M11Pag +
                M12Pag;

            M01 = M01NPag + M01Pag;
            M02 = M02NPag + M02Pag;
            M03 = M03NPag + M03Pag;
            M04 = M04NPag + M04Pag;
            M05 = M05NPag + M05Pag;
            M06 = M06NPag + M06Pag;
            M07 = M07NPag + M07Pag;
            M08 = M08NPag + M08Pag;
            M09 = M09NPag + M09Pag;
            M10 = M10NPag + M10Pag;
            M11 = M11NPag + M11Pag;
            M12 = M12NPag + M12Pag;

            if (Tipo.Contains("pagamento"))
                OrdineTipo = String.Format("111{0}", Tipo);
            else
                OrdineTipo = String.Format("222{0}", Tipo);
        }
    }
}
