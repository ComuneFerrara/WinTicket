using System;
using DevExpress.Xpo;
using Musei.Module;

namespace Musei.Module
{
    public class EntrataPosticipata : MuseiBase
    {
        private string _BarCode;
        public string BarCode
        {
            get
            {
                return _BarCode;
            }
            set
            {
                SetPropertyValue("BarCode", ref _BarCode, value);
            }
        }

        private DateTime _DataOraEntrata;
        public DateTime DataOraEntrata
        {
            get
            {
                return _DataOraEntrata;
            }
            set
            {
                SetPropertyValue("DataOraEntrata", ref _DataOraEntrata, value);
            }
        }

        private Utente _Utente;
        public Utente Utente
        {
            get
            {
                return _Utente;
            }
            set
            {
                SetPropertyValue("Utente", ref _Utente, value);
            }
        }

        private Postazione _Postazione;
        [Indexed]
        public Postazione Postazione
        {
            get
            {
                return _Postazione;
            }
            set
            {
                SetPropertyValue("Postazione", ref _Postazione, value);
            }
        }

        //private bool _Evasa;
        //public bool Evasa
        //{
        //    get
        //    {
        //        return _Evasa;
        //    }
        //    set
        //    {
        //        SetPropertyValue("Evasa", ref _Evasa, value);
        //    }
        //}

        private EnumStatusEntrata _Status;
        public EnumStatusEntrata Status
        {
            get
            {
                return _Status;
            }
            set
            {
                SetPropertyValue("Status", ref _Status, value);
            }
        }

        private DateTime _DataEvasione;
        [Indexed]
        public DateTime DataEvasione
        {
            get
            {
                return _DataEvasione;
            }
            set
            {
                SetPropertyValue("DataEvasione", ref _DataEvasione, value);
            }
        }

        public EntrataPosticipata(Session session) : base(session) { }
    }
}
