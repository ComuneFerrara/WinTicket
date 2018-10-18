using System;

using DevExpress.Xpo;
using System.Collections.Generic;

namespace Musei.Module
{
    public class CodiceSconto : MuseiBase
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

        private string m_Codice;
        [Indexed(Unique = true)]
        public string Codice
        {
            get
            {
                return m_Codice;
            }
            set
            {
                SetPropertyValue("Codice", ref m_Codice, value);
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

        //[Association("Variante-CodiceSconto", UseAssociationNameAsIntermediateTableName = true)]
        //public XPCollection<Variante> ElencoVarianti
        //{
        //    get
        //    {
        //        return GetCollection<Variante>("ElencoVarianti");
        //    }
        //}


        public CodiceSconto(Session session) : base(session) { }

    }

}
