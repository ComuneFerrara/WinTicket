using System;

using DevExpress.Xpo;
using System.ComponentModel;
using System.Collections.Generic;

namespace Musei.Module
{
    public class PostazioneAccesso : MuseiBase
    {
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

        private Ingresso _Ingresso;
        public Ingresso Ingresso
        {
            get
            {
                return _Ingresso;
            }
            set
            {
                SetPropertyValue("Ingresso", ref _Ingresso, value);
            }
        }

        private DateTime _Data;
        [Indexed]
        public DateTime Data
        {
            get
            {
                return _Data;
            }
            set
            {
                SetPropertyValue("Data", ref _Data, value);
            }
        }

        //private DateTime _DataFine;
        //public DateTime DataFine
        //{
        //    get
        //    {
        //        return _DataFine;
        //    }
        //    set
        //    {
        //        SetPropertyValue("DataFine", ref _DataFine, value);
        //    }
        //}

        //private int _NumeroGiorni;
        //public int NumeroGiorni
        //{
        //    get
        //    {
        //        return _NumeroGiorni;
        //    }
        //    set
        //    {
        //        SetPropertyValue("NumeroGiorni", ref _NumeroGiorni, value);
        //    }
        //}

        public PostazioneAccesso(Session session) : base(session) { }

    }

}
