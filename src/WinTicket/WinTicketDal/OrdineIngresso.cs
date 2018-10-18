using System;

using DevExpress.Xpo;
using System.Collections.Generic;

namespace Musei.Module
{
    public class OrdineIngresso : MuseiBase
    {
        private Ingresso m_Riferimento;
        [Association("Ingresso-OrdineIngressi")]
        public Ingresso Riferimento
        {
            get
            {
                return m_Riferimento;
            }
            set
            {
                SetPropertyValue("Riferimento", ref m_Riferimento, value);
            }
        }

        private Ingresso m_Ingresso;
        public Ingresso Ingresso
        {
            get
            {
                return m_Ingresso;
            }
            set
            {
                SetPropertyValue("Ingresso", ref m_Ingresso, value);
            }
        }

        private SoggettoEconomico m_SoggettoEconomico;
        public SoggettoEconomico SoggettoEconomico
        {
            get
            {
                return m_SoggettoEconomico;
            }
            set
            {
                SetPropertyValue("SoggettoEconomico", ref m_SoggettoEconomico, value);
            }
        }

        private int m_Posizione;
        public int Posizione
        {
            get
            {
                return m_Posizione;
            }
            set
            {
                SetPropertyValue("Posizione", ref m_Posizione, value);
            }
        }

        private EnumAccesso m_Accesso;
        public EnumAccesso Accesso
        {
            get
            {
                return m_Accesso;
            }
            set
            {
                SetPropertyValue("Accesso", ref m_Accesso, value);
            }
        }

        //private bool _Checked;
        //public bool Checked
        //{
        //    get
        //    {
        //        return _Checked;
        //    }
        //    set
        //    {
        //        SetPropertyValue("Checked", ref _Checked, value);
        //    }
        //}

        public OrdineIngresso(Session session) : base(session) { }
    }

}
