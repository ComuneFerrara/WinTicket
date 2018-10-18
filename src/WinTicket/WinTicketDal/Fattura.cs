using System;

using DevExpress.Xpo;
using System.ComponentModel;
using System.Collections.Generic;

namespace Musei.Module
{
    [DefaultProperty("Descrizione")]
    public class Fattura : MuseiBase
    {
        private Struttura m_Struttura;
        [Association("Struttura-Fattura")]
        public Struttura Struttura
        {
            get
            {
                return m_Struttura;
            }
            set
            {
                SetPropertyValue("Struttura", ref m_Struttura, value);
            }
        }

        private Vendita m_Vendita;
        [Association("Vendita-Fattura")]
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

        private string _Codice;
        [Indexed]
        public string Codice
        {
            get
            {
                return _Codice;
            }
            set
            {
                SetPropertyValue("Codice", ref _Codice, value);
            }
        }

        private string _CodiceCompleto;
        [Indexed(Unique = true)]
        public string CodiceCompleto
        {
            get
            {
                return _CodiceCompleto;
            }
            set
            {
                SetPropertyValue("CodiceCompleto", ref _CodiceCompleto, value);
            }
        }
        private DateTime _DataContabile;
        [Indexed]
        public DateTime DataContabile
        {
            get
            {
                return _DataContabile;
            }
            set
            {
                SetPropertyValue("DataContabile", ref _DataContabile, value);
            }
        }

        private int _Anno;
        [Indexed]
        public int Anno
        {
            get
            {
                return _Anno;
            }
            set
            {
                SetPropertyValue("Anno", ref _Anno, value);
            }
        }

        private int _Numero;
        public int Numero
        {
            get
            {
                return _Numero;
            }
            set
            {
                SetPropertyValue("Numero", ref _Numero, value);
            }
        }

        private string _IntestazioneRiga1;
        [Size(SizeAttribute.Unlimited)]
        public string IntestazioneRiga1
        {
            get
            {
                return _IntestazioneRiga1;
            }
            set
            {
                SetPropertyValue("IntestazioneRiga1", ref _IntestazioneRiga1, value);
            }
        }

        private string _IntestazioneRiga2;
        [Size(SizeAttribute.Unlimited)]
        public string IntestazioneRiga2
        {
            get
            {
                return _IntestazioneRiga2;
            }
            set
            {
                SetPropertyValue("IntestazioneRiga2", ref _IntestazioneRiga2, value);
            }
        }

        private string _IntestazioneRiga3;
        [Size(SizeAttribute.Unlimited)]
        public string IntestazioneRiga3
        {
            get
            {
                return _IntestazioneRiga3;
            }
            set
            {
                SetPropertyValue("IntestazioneRiga3", ref _IntestazioneRiga3, value);
            }
        }


        private string _IntestazioneRiga4;
        [Size(SizeAttribute.Unlimited)]
        public string IntestazioneRiga4
        {
            get
            {
                return _IntestazioneRiga4;
            }
            set
            {
                SetPropertyValue("IntestazioneRiga4", ref _IntestazioneRiga4, value);
            }
        }

        //private string _IntestazioneRiga5;
        //[Size(SizeAttribute.Unlimited)]
        //public string IntestazioneRiga5
        //{
        //    get
        //    {
        //        return _IntestazioneRiga5;
        //    }
        //    set
        //    {
        //        SetPropertyValue("IntestazioneRiga5", ref _IntestazioneRiga5, value);
        //    }
        //}

        //private string _CodiceApp18;
        //[Size(SizeAttribute.Unlimited)]
        //public string CodiceApp18
        //{
        //    get
        //    {
        //        return _CodiceApp18;
        //    }
        //    set
        //    {
        //        SetPropertyValue("CodiceApp18", ref _CodiceApp18, value);
        //    }
        //}

        private string _Note;
        [Size(SizeAttribute.Unlimited)]
        public string Note
        {
            get
            {
                return _Note;
            }
            set
            {
                SetPropertyValue("Note", ref _Note, value);
            }
        }

        private int _Stampe;
        public int Stampe
        {
            get
            {
                return _Stampe;
            }
            set
            {
                SetPropertyValue("Stampe", ref _Stampe, value);
            }
        }

        private decimal _Totale;
        public decimal Totale
        {
            get
            {
                return _Totale;
            }
            set
            {
                SetPropertyValue("Totale", ref _Totale, value);
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

        [Association("Fattura-RigaFattura"), Aggregated]
        public XPCollection<RigaFattura> RigheFattura
        {
            get
            {
                return GetCollection<RigaFattura>("RigheFattura");
            }
        }

        public Fattura(Session session) : base(session) { }

       
    }

}
