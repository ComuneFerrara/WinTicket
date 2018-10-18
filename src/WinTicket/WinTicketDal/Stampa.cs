using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.Net;
using DevExpress.XtraPrinting.Native;

namespace Musei.Module
{
    public class Stampa : MuseiBase
    {
        private string m_BarCode;
        [Indexed]
        public string BarCode
        {
            get
            {
                return m_BarCode;
            }
            set
            {
                SetPropertyValue("BarCode", ref m_BarCode, value);
            }
        }

        private string m_CodiceProgressivo;
        [Indexed]
        public string CodiceProgressivo
        {
            get
            {
                return m_CodiceProgressivo;
            }
            set
            {
                SetPropertyValue("CodiceProgressivo", ref m_CodiceProgressivo, value);
            }
        }

        private int m_NumeroProgressivo;
        [Indexed]
        public int NumeroProgressivo
        {
            get
            {
                return m_NumeroProgressivo;
            }
            set
            {
                SetPropertyValue("NumeroProgressivo", ref m_NumeroProgressivo, value);
            }
        }

        private DateTime m_inizioValidita;
        public DateTime InizioValidita
        {
            get
            {
                return m_inizioValidita;
            }
            set
            {
                SetPropertyValue("InizioValidita", ref m_inizioValidita, value);
            }
        }

        private DateTime m_fineValidita;
        public DateTime FineValidita
        {
            get
            {
                return m_fineValidita;
            }
            set
            {
                SetPropertyValue("FineValidita", ref m_fineValidita, value);
            }
        }

        private Vendita m_Vendita;
        [Association("VenditaStampe")]
        public Vendita Vendita
        {
            get
            {
                return m_Vendita;
            }
            set
            {
                SetPropertyValue("Vendita", ref m_Vendita, value);
            }
        }

        private int m_quantita;
        public int Quantita
        {
            get
            {
                return m_quantita;
            }
            set
            {
                SetPropertyValue("Quantita", ref m_quantita, value);
            }
        }

        private decimal m_ImportoTotale;
        public decimal ImportoTotale
        {
            get
            {
                return m_ImportoTotale;
            }
            set
            {
                SetPropertyValue("ImportoTotale", ref m_ImportoTotale, value);
            }
        }

        private int m_StatoStampa;
        public int StatoStampa
        {
            get
            {
                return m_StatoStampa;
            }
            set
            {
                SetPropertyValue("StatoStampa", ref m_StatoStampa, value);
            }
        }

        private int m_NumeroStampe;
        public int NumeroStampe
        {
            get
            {
                return m_NumeroStampe;
            }
            set
            {
                SetPropertyValue("NumeroStampe", ref m_NumeroStampe, value);
            }
        }

        private EnumTipoStampa m_TipoStampa;
        public EnumTipoStampa TipoStampa
        {
            get
            {
                return m_TipoStampa;
            }
            set
            {
                SetPropertyValue("TipoStampa", ref m_TipoStampa, value);
            }
        }

        private Card m_Card;
        public Card Card
        {
            get
            {
                return m_Card;
            }
            set
            {
                SetPropertyValue("Card", ref m_Card, value);
            }
        }

        private string m_Matricola;
        public string Matricola
        {
            get
            {
                return m_Matricola;
            }
            set
            {
                SetPropertyValue("Matricola", ref m_Matricola, value);
            }
        }

        [Association("StampaRigheStampaIngresso"), Aggregated]
        public XPCollection<RigaStampaIngresso> RigheStampaIngresso
        {
            get
            {
                return GetCollection<RigaStampaIngresso>("RigheStampaIngresso");
            }
        }

        public Stampa(Session session) : base(session) { }

        private static string GetRandom(int len)
        {
            string result = "";
            while (result.Length != len)
            {
                int r = m_rnd.Next(0, 10);
                string ch = r.ToString();
                if (ch.Length == 1)
                    result += ch;
            }

            return result;
        }

        private static string Check1(string toc)
        {
            string result = "";
            int crc = 0;
            int factor = 1;

            if (toc.Length != 11)
                throw new Exception("Attesi 11 caratteri");

            for (int i = 0; i < 11; i++)
            {
                crc += (toc[i] - '0') * factor;

                factor = 4 - factor;
            }

            crc %= 10;

            result = crc.ToString();

            return result;
        }

        private string CreaBarCode12(Postazione postazione)
        {
            // Codice a barre:
            // postazione:      xx       ,2
            // anno:            x        ,1
            // random:          xxxxxx   ,6
            // controllo:       x        ,1
            // numero giri tornello: xx  ,2

            //if (RigaBasket == null) return false;
            //if (RigaBasket.Basket == null) return false;
            //if (RigaBasket.Basket.Postazione == null) return false;

            int anno = Vendita.DataContabile.Year - 2000;

            string random = GetRandom(8);

            //string bc1 = "00000" + postazione.CodiceUnivoco;
            //bc1 = bc1.Substring(bc1.Length - 2, 2);

            string bc2 = "00000" + anno;
            bc2 = bc2.Substring(bc2.Length - 1, 1);

            string bc3 = "00000" + Quantita;
            bc3 = bc3.Substring(bc3.Length - 2, 2);

            random = bc2 + bc3 + random;
            string check = Check1(random);

            random = random + check;

            if (random.Length == 12)
            {
                return random;
            }
            else
                throw new Exception("Calcolo BarCode12 ERRATO!");
        }

        public static void SetProgressivoMinimo(Session session, Guid postazioneOid)
        {
            int dbMinimo = 0;

            int anno = DateTime.Today.Year;

            var ret = session.ExecuteScalar(@"select max(NumeroProgressivo) from Stampa inner join Vendita on Stampa.Vendita=Vendita.Oid where year(Vendita.DataContabile)=@anno and Vendita.Postazione=@postazione",
                new string[] { @"anno", @"postazione" },
                new object[] { anno, postazioneOid });

            if (ret != null)
            {
                dbMinimo = (int) ret;
                m_ProgressivoMinimo = dbMinimo;
            }

        }

        private readonly static Random m_rnd = new Random();
        private readonly static string m_alfabeto = "0123456789";
        private static int m_ProgressivoMinimo = 0;
        public void GeneraBarCode(Postazione postazione, List<Ingresso> ingressi)
        {
            bool castello = false;
            foreach (Ingresso riga in ingressi)
            {
                if (riga.IntestazioneStampa == "C")
                    castello = true;
            }

            if (castello)
            {
                BarCode = CreaBarCode12(postazione);
            }
            else
            {
                BarCode = string.Empty;
                for (int i = 0; i < 8; i++)
                {
                    BarCode += m_alfabeto[m_rnd.Next(m_alfabeto.Length)];
                }
                BarCode = string.Format("{0:0}{1:00}{2}", (Vendita.DataContabile.Year - 2000) % 10, postazione.CodiceUnivoco, BarCode);
            }

            if (m_ProgressivoMinimo == 0)
            {
                // cerca progressivo
                int anno = Vendita.DataContabile.Year;
                int dbMinimo = 0;

                var ret = this.Session.ExecuteScalar(@"select max(NumeroProgressivo) from Stampa inner join Vendita on Stampa.Vendita=Vendita.Oid where year(Vendita.DataContabile)=@anno and Vendita.Postazione=@postazione", 
                    new string[] {@"anno", @"postazione"},
                    new object[] {anno, postazione.Oid});

                if (ret != null)
                    dbMinimo = (int) ret;

                NumeroProgressivo = Math.Max(dbMinimo + 1, m_ProgressivoMinimo + 1);
            }
            else
            {
                NumeroProgressivo = m_ProgressivoMinimo + 1;
            }

            CodiceProgressivo = string.Format("{0:00}{1:00}{2:000000}",
                Vendita.DataContabile.Year - 2000,
                postazione.CodiceUnivoco, NumeroProgressivo);

            m_ProgressivoMinimo = NumeroProgressivo;
        }

        public bool EsistonoEntrate()
        {
            foreach (RigaStampaIngresso item in RigheStampaIngresso)
            {
                if (item.TotaleIngressi > 0)
                    return true;
            }

            return false;
        }
    }

}
