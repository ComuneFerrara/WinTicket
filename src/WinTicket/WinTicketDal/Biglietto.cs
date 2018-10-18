using System;
using DevExpress.Xpo;
using System.ComponentModel;
using System.Collections.Generic;

namespace Musei.Module
{
    [DefaultProperty("Descrizione")]
    public class Biglietto : MuseiBase
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

        private string m_Note;
        public string Note
        {
            get
            {
                return m_Note;
            }
            set
            {
                SetPropertyValue("Note", ref m_Note, value);
            }
        }

        private DateTime m_InizioPeriodo;
        public DateTime InizioPeriodo
        {
            get
            {
                return m_InizioPeriodo;
            }
            set
            {
                SetPropertyValue("InizioPeriodo", ref m_InizioPeriodo, value);
            }
        }

        private DateTime m_FinePeriodo;
        public DateTime FinePeriodo
        {
            get
            {
                return m_FinePeriodo;
            }
            set
            {
                SetPropertyValue("FinePeriodo", ref m_FinePeriodo, value);
            }
        }

        [NonPersistent]
        public TimeSpan Intervallo
        {
            get
            {
                return FinePeriodo - InizioPeriodo;
            }
        }

        public bool ComprendeData(DateTime data)
        {
            if (InizioPeriodo <= data && FinePeriodo >= data)
                return true;
            else
                return false;
        }

        private Percorso m_Percorso;
        [Association("BigliettoPercorso")]
        public Percorso Percorso
        {
            get
            {
                return m_Percorso;
            }
            set
            {
                SetPropertyValue("Percorso", ref m_Percorso, value);
            }
        }

        private SoggettoEconomico m_Gestore;
        public SoggettoEconomico Gestore
        {
            get
            {
                return m_Gestore;
            }
            set
            {
                SetPropertyValue("Gestore", ref m_Gestore, value);
            }
        }

        private int m_MinimoPerGruppo;
        public int MinimoPerGruppo
        {
            get
            {
                return m_MinimoPerGruppo;
            }
            set
            {
                SetPropertyValue("MinimoPerGruppo", ref m_MinimoPerGruppo, value);
            }
        }

        private EnumTipologiaBiglietto _Tipologia;
        public EnumTipologiaBiglietto Tipologia
        {
            get
            {
                return _Tipologia;
            }
            set
            {
                SetPropertyValue("Tipologia", ref _Tipologia, value);
            }
        }

        [Association("Biglietto-Varianti"), Aggregated]
        public XPCollection<Variante> Varianti
        {
            get
            {
                return GetCollection<Variante>("Varianti");
            }
        }

        [Association("Biglietto-Eventi")]
        public XPCollection<EventoParticolare> Eventi
        {
            get
            {
                return GetCollection<EventoParticolare>("Eventi");
            }
        }
      
        public Biglietto(Session session) : base(session) { }

        public bool IsAttrib(string request)
        {
            if (string.IsNullOrEmpty(Note))
                return false;
            else
                return Note.ToUpper().Contains(request.ToUpper());
        }

        public const string STR_BIGLIETTO_STORICO = "[STORICO]";

        private List<Variante> m_VariantiValide;
        [NonPersistent]
        public List<Variante> VariantiValide
        {
            get
            {
                if (m_VariantiValide == null)
                {
                    m_VariantiValide = new List<Variante>();
                    foreach (Variante item in Varianti)
                    {
                        if (item.ComprendeData(DateTime.Now))
                            m_VariantiValide.Add(item);
                    }
                }

                return m_VariantiValide;
            }
        }
    }

}
