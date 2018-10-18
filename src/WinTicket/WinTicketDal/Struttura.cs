using System;
using DevExpress.Xpo;
using System.ComponentModel;
using System.Data;
using DevExpress.Data.Filtering;

namespace Musei.Module
{
    public class Struttura : ObjectDomainBase
    {
        private string m_Descrizione;
        [Indexed(Unique=true)]
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

        private string _DescrizioneBreve;
        public string DescrizioneBreve
        {
            get
            {
                return _DescrizioneBreve;
            }
            set
            {
                SetPropertyValue("DescrizioneBreve", ref _DescrizioneBreve, value);
            }
        }

        private SoggettoEconomico _SoggettoEconomico;
        public SoggettoEconomico SoggettoEconomico
        {
            get
            {
                return _SoggettoEconomico;
            }
            set
            {
                SetPropertyValue("SoggettoEconomico", ref _SoggettoEconomico, value);
            }
        }

        private string _Intestazione;
        public string Intestazione
        {
            get
            {
                return _Intestazione;
            }
            set
            {
                SetPropertyValue("Intestazione", ref _Intestazione, value);
            }
        }

        private string _Responsabile;
        public string Responsabile
        {
            get
            {
                return _Responsabile;
            }
            set
            {
                SetPropertyValue("Responsabile", ref _Responsabile, value);
            }
        }

        private string _Titolo;
        public string Titolo
        {
            get
            {
                return _Titolo;
            }
            set
            {
                SetPropertyValue("Titolo", ref _Titolo, value);
            }
        }

        private string _Indirizzo;
        public string Indirizzo
        {
            get
            {
                return _Indirizzo;
            }
            set
            {
                SetPropertyValue("Indirizzo", ref _Indirizzo, value);
            }
        }

        private string _Footer1;
        public string Footer1
        {
            get
            {
                return _Footer1;
            }
            set
            {
                SetPropertyValue("Footer1", ref _Footer1, value);
            }
        }

        private string _Footer2;
        public string Footer2
        {
            get
            {
                return _Footer2;
            }
            set
            {
                SetPropertyValue("Footer2", ref _Footer2, value);
            }
        }
        private string _SiglaFattura;
        public string SiglaFattura
        {
            get
            {
                return _SiglaFattura;
            }
            set
            {
                SetPropertyValue("SiglaFattura", ref _SiglaFattura, value);
            }
        }

        [Association("Struttura-Postazioni")]
        public XPCollection<Postazione> Postazioni
        {
            get
            {
                return GetCollection<Postazione>("Postazioni");
            }
        }

        [Association("Struttura-Ingressi")]
        public XPCollection<Ingresso> Ingressi
        {
            get
            {
                return GetCollection<Ingresso>("Ingressi");
            }
        }

        [Association("Struttura-Fattura")]
        public XPCollection<Fattura> Fatture
        {
            get
            {
                return GetCollection<Fattura>("Fatture");
            }
        }


        public Struttura(Session session) : base(session) { }
    }

}
