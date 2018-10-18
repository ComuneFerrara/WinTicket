using System;

using DevExpress.Xpo;
using System.ComponentModel;
using System.Data;

namespace Musei.Module
{
    [DefaultProperty("Descrizione")]
    public class Importo : MuseiBase
    {
        [NonPersistent]
        public string Descrizione
        {
            get
            {
                return Prezzo.ToString("c");
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

        private DateTime m_InizioValidita;
        public DateTime InizioValidita
        {
            get
            {
                return m_InizioValidita;
            }
            set
            {
                SetPropertyValue("InizioValidita", ref m_InizioValidita, value);
            }
        }

        private DateTime m_FineValidita;
        public DateTime FineValidita
        {
            get
            {
                return m_FineValidita;
            }
            set
            {
                SetPropertyValue("FineValidita", ref m_FineValidita, value);
            }
        }

        [NonPersistent]
        public TimeSpan Intervallo
        {
            get
            {
                return FineValidita - InizioValidita;
            }
        }

        public bool ComprendeData(DateTime data)
        {
            if (InizioValidita <= data && FineValidita >= data)
                return true;
            else
                return false;
        }

        private decimal m_Prezzo;
        public decimal Prezzo
        {
            get
            {
                return m_Prezzo;
            }
            set
            {
                SetPropertyValue("Prezzo", ref m_Prezzo, value);
            }
        }

        private int m_UnaRiduzioneOgni;
        public int UnaRiduzioneOgni
        {
            get
            {
                return m_UnaRiduzioneOgni;
            }
            set
            {
                SetPropertyValue("UnaRiduzioneOgni", ref m_UnaRiduzioneOgni, value);
            }
        }

        private Variante m_PrezzoRidotto;
        public Variante PrezzoRidotto
        {
            get
            {
                return m_PrezzoRidotto;
            }
            set
            {
                SetPropertyValue("PrezzoRidotto", ref m_PrezzoRidotto, value);
            }
        }

        private Variante m_Variante;
        [Association("Variante-StoricoPrezzi")]
        public Variante Variante
        {
            get
            {
                return m_Variante;
            }
            set
            {
                SetPropertyValue("Variante", ref m_Variante, value);
            }
        }

        public Importo(Session session) : base(session) { }
    }

}
