using System;

using DevExpress.Xpo;
using System.ComponentModel;
using System.Collections.Generic;

namespace Musei.Module
{
    public class IngressoCalendario : MuseiBase
    {
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

        private DateTime _DataOra;
        public DateTime DataOra
        {
            get
            {
                return _DataOra;
            }
            set
            {
                SetPropertyValue("DataOra", ref _DataOra, value);
            }
        }

        private int _PaxMax;
        public int PaxMax
        {
            get
            {
                return _PaxMax;
            }
            set
            {
                SetPropertyValue("PaxMax", ref _PaxMax, value);
            }
        }

        public IngressoCalendario(Session session) : base(session) { }

    }

}
