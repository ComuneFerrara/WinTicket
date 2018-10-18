using System;
using DevExpress.Xpo;
using System.ComponentModel;
using System.Data;
using DevExpress.Data.Filtering;

namespace Musei.Module
{
    public class ConfigurazionePivot : ObjectDomainBase
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

        private string _Codice;
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

        private string _Tipo;
        public string Tipo
        {
            get
            {
                return _Tipo;
            }
            set
            {
                SetPropertyValue("Tipo", ref _Tipo, value);
            }
        }

        private string _XML;
        [Size(SizeAttribute.Unlimited)]
        public string XML
        {
            get
            {
                return _XML;
            }
            set
            {
                SetPropertyValue("XML", ref _XML, value);
            }
        }

        public ConfigurazionePivot(Session session) : base(session) { }
    }

}
