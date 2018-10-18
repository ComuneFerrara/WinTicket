using System;

using DevExpress.Xpo;
using System.ComponentModel;
using System.Collections.Generic;

namespace Musei.Module
{
    [DefaultProperty("Descrizione")]
    public class IngressoCategoria : MuseiBase
    {
        private string _Descrizione;
        public string Descrizione
        {
            get
            {
                return _Descrizione;
            }
            set
            {
                SetPropertyValue("Descrizione", ref _Descrizione, value);
            }
        }

        private int _Progressivo;
        public int Progressivo
        {
            get
            {
                return _Progressivo;
            }
            set
            {
                SetPropertyValue("Progressivo", ref _Progressivo, value);
            }
        }

        public IngressoCategoria(Session session) : base(session) { }
    }
}
