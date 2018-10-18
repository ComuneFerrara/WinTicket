using System;

using DevExpress.Xpo;
using System.Collections.Generic;
using System.Data;

namespace Musei.Module
{
    public class Matricola : MuseiBase
    {
        private DateTime _ValidaDal;
        private DateTime _ValidaAl;
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


        public DateTime ValidaDal
        {
            get
            {
                return _ValidaDal;
            }
            set
            {
                SetPropertyValue("ValidaDal", ref _ValidaDal, value);
            }
        }


        public DateTime ValidaAl
        {
            get
            {
                return _ValidaAl;
            }
            set
            {
                SetPropertyValue("ValidaAl", ref _ValidaAl, value);
            }
        }


        public Matricola(Session session) : base(session) { }

       
    }

}
