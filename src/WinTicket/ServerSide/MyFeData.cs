using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering.Helpers;

namespace ServerSide
{
    public class MyFeData
    {
        public MyFeData(string p)
        {
            if (!string.IsNullOrWhiteSpace(p))
            {
                bool inside = false;
                string newp = "";
                foreach (char t in p.ToCharArray())
                {
                    if (t == '"') inside = !inside;
                    if (t != '\t' || !inside)
                    {
                        newp += t;
                    }
                }

                string[] cols = newp.Split(new char[] { '\t' });

                for (int index = 0; index < cols.Length; index++)
                {
                   Console.WriteLine("{0} : [{1}]", index, cols[index]);
                }

                PuntoVendita = cols[0];
                Cliente = cols[1];
                EmailCliente = cols[2];
                IDCliente = cols[3];
                Transazione = cols[4];
                InseritaIl = cols[5];
                TitolareCarta = cols[6];
                EmailTitolare = cols[7];
                Inizio = cols[8];
                Fine = cols[9];
                Giorni = cols[10];
                Prodotto = cols[11];
                CodiceOperazione = cols[12];
                CodiceTessera = cols[13];
                TipoOperazione = cols[14];
                Quantita = cols[15];

                //int pstart = Transazione.IndexOf(">");
                //int pend = Transazione.IndexOf("</a>");
                //Transazione = Transazione.Substring(pstart + 1, pend - pstart - 1);

                InseritaIlDateTime = DateTime.ParseExact(InseritaIl, "dd/MM/yy H.mm", CultureInfo.InvariantCulture);
                InizioDateTime = DateTime.ParseExact(Inizio, "dd/MM/yy H.mm", CultureInfo.InvariantCulture);
                FineDateTime = DateTime.ParseExact(Fine, "dd/MM/yy H.mm", CultureInfo.InvariantCulture);
            }
        }

        public string PuntoVendita { get; set; }
        public string Cliente { get; set; }
        public string EmailCliente { get; set; }
        public string IDCliente { get; set; }
        public string Transazione { get; set; }
        public string InseritaIl { get; set; }
        public string TitolareCarta { get; set; }
        public string EmailTitolare { get; set; }
        public string Inizio { get; set; }
        public string Fine { get; set; }
        public string Giorni { get; set; }
        public string Prodotto { get; set; }
        public string CodiceOperazione { get; set; }
        public string CodiceTessera { get; set; }
        public string TipoOperazione { get; set; }
        public string Quantita { get; set; }

        public DateTime InseritaIlDateTime { get; set; }
        public DateTime InizioDateTime { get; set; }
        public DateTime FineDateTime { get; set; }
    }
}
