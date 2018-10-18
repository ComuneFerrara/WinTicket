using System;
using DevExpress.Xpo;
using System.ComponentModel;
using System.Data;
using DevExpress.Data.Filtering;

namespace Musei.Module
{
    [DefaultProperty("Descrizione")]
    public class Vendita : MuseiBase
    {
        private string m_Descrizione;
        public string Descrizione
        {
            get
            {
                return m_Descrizione;
            }
            set
            {
                SetPropertyValue("Descrizione", ref m_Descrizione, value);
            }
        }

        private Utente m_Utente;
        [Indexed]
        public Utente Utente
        {
            get
            {
                return m_Utente;
            }
            set
            {
                SetPropertyValue("Utente", ref m_Utente, value);
            }
        }

        private Postazione m_postazione;
        [Indexed]
        public Postazione Postazione
        {
            get
            {
                return m_postazione;
            }
            set
            {
                SetPropertyValue("Postazione", ref m_postazione, value);
            }
        }

        private Struttura _Struttura;
        [Indexed]
        public Struttura Struttura
        {
            get
            {
                return _Struttura;
            }
            set
            {
                SetPropertyValue("Struttura", ref _Struttura, value);
            }
        }

        private string m_CodiceLeggibile;
        [Indexed]
        public string CodiceLeggibile
        {
            get
            {
                return m_CodiceLeggibile;
            }
            set
            {
                SetPropertyValue("CodiceLeggibile", ref m_CodiceLeggibile, value);
            }
        }

        private DateTime m_DataOraStampa;
        [Indexed]
        public DateTime DataOraStampa
        {
            get
            {
                return m_DataOraStampa;
            }
            set
            {
                SetPropertyValue("DataOraStampa", ref m_DataOraStampa, value);
            }
        }

        private DateTime m_DataContabile;
        [Indexed]
        public DateTime DataContabile
        {
            get
            {
                return m_DataContabile;
            }
            set
            {
                SetPropertyValue("DataContabile", ref m_DataContabile, value);
            }
        }

        private int m_totalePersone;
        public int TotalePersone
        {
            get
            {
                return m_totalePersone;
            }
            set
            {
                SetPropertyValue("TotalePersone", ref m_totalePersone, value);
            }
        }

        private decimal m_totaleImporto;
        public decimal TotaleImporto
        {
            get
            {
                return m_totaleImporto;
            }
            set
            {
                SetPropertyValue("TotaleImporto", ref m_totaleImporto, value);
            }
        }

        private EnumIncasso m_Incasso;
        public EnumIncasso Incasso
        {
            get
            {
                return m_Incasso;
            }
            set
            {
                SetPropertyValue("Incasso", ref m_Incasso, value);
            }
        }

        private string m_codicePrevent;
        public string CodicePrevent
        {
            get
            {
                return m_codicePrevent;
            }
            set
            {
                SetPropertyValue("CodicePrevent", ref m_codicePrevent, value);
            }
        }

        private Provenienza m_Provenienza;
        public Provenienza Provenienza
        {
            get
            {
                return m_Provenienza;
            }
            set
            {
                SetPropertyValue("Provenienza", ref m_Provenienza, value);
            }
        }

        [Association("VenditaStampe"), Aggregated]
        public XPCollection<Stampa> Stampe
        {
            get
            {
                return GetCollection<Stampa>("Stampe");
            }
        }

        [Association("Vendita-Prenotazioni"), Aggregated]
        public XPCollection<Prenotazione> Prenotazioni
        {
            get
            {
                return GetCollection<Prenotazione>("Prenotazioni");
            }
        }

        [Association("Vendita-RigheVenditaVariante"), Aggregated]
        public XPCollection<RigaVenditaVariante> RigheVenditaVariante
        {
            get
            {
                return GetCollection<RigaVenditaVariante>("RigheVenditaVariante");
            }
        }

        [Association("Vendita-Fattura")]
        public XPCollection<Fattura> Fatture
        {
            get
            {
                return GetCollection<Fattura>("Fatture");
            }
        }

        public Vendita(Session session) : base(session) { }

        public bool EsistonoEntrate()
        {
            foreach (Stampa item in Stampe)
            {
                if (item.EsistonoEntrate()) return true;
            }

            return false;
        }

        public bool PossoEliminarla()
        {
            using (XPCollection<Versamento> versamenti = new XPCollection<Versamento>(this.Session))
            {
                versamenti.Criteria = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[] { 
                    new BinaryOperator("InizioPeriodo", this.DataContabile, BinaryOperatorType.LessOrEqual), 
                    new BinaryOperator("FinePeriodo", this.DataContabile, BinaryOperatorType.GreaterOrEqual) });

                foreach (Versamento versamento in versamenti)
                {
                    if (versamento.Struttura == this.Struttura)
                        return false;
                }
            }

            if (this.DataContabile.Year <= 2013)
                return false;

            return true;
        }

        public void EliminaVendita()
        {
            foreach (RigaVenditaVariante rigaVenditaVariante in this.RigheVenditaVariante)
            {
                if (rigaVenditaVariante.Card != null)
                {
                    rigaVenditaVariante.Card.Stampa = null;
                    rigaVenditaVariante.Card.Albergo = null;
                    rigaVenditaVariante.Card.Status = EnumStatoCard.Assegnata;
                    rigaVenditaVariante.Card.Save();
                }
            }

            this.Delete();
        }

        public bool EsistonoCardMyFE()
        {
            foreach (Stampa item in Stampe)
            {
                if (item.Card != null) return true;
            }

            return false;
        }

        private readonly static Random m_Rnd = new Random();

        public static string NuovoCodiceVendita()
        {
            const string alfabeto = "1234567890";
            const string alfabetonz = "123456789";

            // prima cifra diversa da ZERO!
            string result = string.Empty;
            result += alfabetonz[m_Rnd.Next(alfabetonz.Length)];
            for (int i = 0; i < 9; i++)
            {
                result += alfabeto[m_Rnd.Next(alfabeto.Length)];
            }

            return result;
        }
    }

}
