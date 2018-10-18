using System;

using DevExpress.Xpo;
using System.ComponentModel;

namespace Musei.Module
{
    [DefaultProperty("Oggetto")]
    public class Messaggio : MuseiBase
    {
        private EnumTipoMessaggio m_Tipologia;
        [Indexed]
        public EnumTipoMessaggio Tipologia
        {
            get
            {
                return m_Tipologia;
            }
            set
            {
                SetPropertyValue("Tipologia", ref m_Tipologia, value);
            }
        }

        [NonPersistent]
        public int TipologiaInt
        {
            get
            {
                return (int)Tipologia;
            }
        }

        private Utente m_Autore;
        public Utente Autore
        {
            get
            {
                return m_Autore;
            }
            set
            {
                SetPropertyValue("Autore", ref m_Autore, value);
            }
        }

        private string m_Oggetto;
        public string Oggetto
        {
            get
            {
                return m_Oggetto;
            }
            set
            {
                SetPropertyValue("Oggetto", ref m_Oggetto, value);
            }
        }

        private DateTime m_Data;
        [Indexed]
        public DateTime Data
        {
            get
            {
                return m_Data;
            }
            set
            {
                SetPropertyValue("Data", ref m_Data, value);
            }
        }

        private DateTime _DataFine;
        [Indexed]
        public DateTime DataFine
        {
            get
            {
                return _DataFine;
            }
            set
            {
                SetPropertyValue("DataFine", ref _DataFine, value);
            }
        }

        private string m_TestoEsteso;
        [Size(SizeAttribute.Unlimited)]
        public string TestoEsteso
        {
            get
            {
                return m_TestoEsteso;
            }
            set
            {
                SetPropertyValue("TestoEsteso", ref m_TestoEsteso, value);
            }
        }

        [Association("Messaggio-Conferme"), Aggregated]
        public XPCollection<MessaggioConferma> Conferme
        {
            get
            {
                return GetCollection<MessaggioConferma>("Conferme");
            }
        }

        public Messaggio(Session session) : base(session) { }

        public bool Letto(Guid userguid)
        {
            foreach (MessaggioConferma messaggioConferma in Conferme)
            {
                if (messaggioConferma.Utente.Oid == userguid && messaggioConferma.Letto)
                    return true;
            }

            return false;
        }

        protected override void OnSaving()
        {
            base.OnSaving();

            if (DataFine < Data)
                DataFine = Data;
        }
    }

}
