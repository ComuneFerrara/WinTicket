using System;

using DevExpress.Xpo;
using System.ComponentModel;
using System.Collections.Generic;

namespace Musei.Module
{
    [DefaultProperty("Descrizione")]
    public class Progressivo : MuseiBase
    {
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

        private int _UltimoNumero;
        public int UltimoNumero
        {
            get
            {
                return _UltimoNumero;
            }
            set
            {
                SetPropertyValue("UltimoNumero", ref _UltimoNumero, value);
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

        public bool IsAttrib(string request)
        {
            if (string.IsNullOrEmpty(Attributi))
                return false;
            else
                return Attributi.ToUpper().Contains(request.ToUpper());
        }



        public Progressivo(Session session) : base(session) { }

       
    }

}
