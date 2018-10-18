using System;

using DevExpress.Xpo;

using System.ComponentModel;

namespace Musei.Module
{
    [DefaultProperty("RagioneSociale")]
    public class SoggettoEconomico : MuseiBase
    {
        private string m_RagioneSociale;
        [Indexed(Unique=true)]
        public string RagioneSociale
        {
            get
            {
                return m_RagioneSociale;
            }
            set
            {
                SetPropertyValue("RagioneSociale", ref m_RagioneSociale, value);
            }
        }

        private string m_PartitaIva;
        public string PartitaIva
        {
            get
            {
                return m_PartitaIva;
            }
            set
            {
                SetPropertyValue("PartitaIva", ref m_PartitaIva, value);
            }
        }

        private string m_CodiceFiscale;
        public string CodiceFiscale
        {
            get
            {
                return m_CodiceFiscale;
            }
            set
            {
                SetPropertyValue("CodiceFiscale", ref m_CodiceFiscale, value);
            }
        }

        private string _Attributi;
        public string Attributi
        {
            get
            {
                return _Attributi;
            }
            set
            {
                SetPropertyValue("Attributi", ref _Attributi, value);
            }
        }

        [Association("SoggettoEconomico-Ingressi")]
        public XPCollection<Ingresso> Ingressi
        {
            get
            {
                return GetCollection<Ingresso>("Ingressi");
            }
        }

        public SoggettoEconomico(Session session) : base(session) { }

        public bool IsAttrib(string request)
        {
            if (string.IsNullOrEmpty(Attributi))
                return false;
            else
                return Attributi.ToUpper().Contains(request.ToUpper());
        }
    }

}
