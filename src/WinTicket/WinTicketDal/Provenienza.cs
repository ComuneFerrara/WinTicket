using System;
using DevExpress.Xpo;
using System.ComponentModel;
using System.Data;
using DevExpress.Data.Filtering;

namespace Musei.Module
{
    public class Provenienza : ObjectDomainBase
    {
        private string _Comune;
        private string _Provincia;
        private string _Regione;
        private string _Stato;
        private string _CAP;

        public string CAP
        {
            get
            {
                return _CAP;
            }
            set
            {
                SetPropertyValue("CAP", ref _CAP, value);
            }
        }

        public string Stato
        {
            get
            {
                return _Stato;
            }
            set
            {
                SetPropertyValue("Stato", ref _Stato, value);
            }
        }

        public string Regione
        {
            get
            {
                return _Regione;
            }
            set
            {
                SetPropertyValue("Regione", ref _Regione, value);
            }
        }

        public string Provincia
        {
            get
            {
                return _Provincia;
            }
            set
            {
                SetPropertyValue("Provincia", ref _Provincia, value);
            }
        }

        public string Comune
        {
            get
            {
                return _Comune;
            }
            set
            {
                SetPropertyValue("Comune", ref _Comune, value);
            }
        }

        public Provenienza(Session session) : base(session) { }
    }

}
