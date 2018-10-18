using System;
using DevExpress.Xpo;
using System.ComponentModel;
using System.Data;
using DevExpress.Data.Filtering;

namespace Musei.Module
{
    public class Versamento : ObjectDomainBase
    {
        private Struttura _Struttura;
        public Struttura Struttura
        {
            get
            {
                return _Struttura;
            }
            set
            {
                SetPropertyValue("Struttura", ref _Struttura, value);
            }
        }

        private DateTime _InizioPeriodo;
        public DateTime InizioPeriodo
        {
            get
            {
                return _InizioPeriodo;
            }
            set
            {
                SetPropertyValue("InizioPeriodo", ref _InizioPeriodo, value);
            }
        }

        private DateTime _FinePeriodo;
        public DateTime FinePeriodo
        {
            get
            {
                return _FinePeriodo;
            }
            set
            {
                SetPropertyValue("FinePeriodo", ref _FinePeriodo, value);
            }
        }

        private DateTime _DataVersamento;
        public DateTime DataVersamento
        {
            get
            {
                return _DataVersamento;
            }
            set
            {
                SetPropertyValue("DataVersamento", ref _DataVersamento, value);
            }
        }

        private EnumTipologiaVersamento _Tipologia;
        public EnumTipologiaVersamento Tipologia
        {
            get
            {
                return _Tipologia;
            }
            set
            {
                SetPropertyValue("Tipologia", ref _Tipologia, value);
            }
        }

        private decimal _Incassi;
        public decimal Incassi
        {
            get
            {
                return _Incassi;
            }
            set
            {
                SetPropertyValue("Incassi", ref _Incassi, value);
            }
        }

        private decimal _Pos;
        public decimal Pos
        {
            get
            {
                return _Pos;
            }
            set
            {
                SetPropertyValue("Pos", ref _Pos, value);
            }
        }

        private decimal _ImportoVersato;
        public decimal ImportoVersato
        {
            get
            {
                return _ImportoVersato;
            }
            set
            {
                SetPropertyValue("ImportoVersato", ref _ImportoVersato, value);
            }
        }

        private decimal _PosAltriEnti;
        public decimal PosAltriEnti
        {
            get
            {
                return _PosAltriEnti;
            }
            set
            {
                SetPropertyValue("PosAltriEnti", ref _PosAltriEnti, value);
            }
        }

        private decimal _ContanteAltriEnti;
        public decimal ContanteAltriEnti
        {
            get
            {
                return _ContanteAltriEnti;
            }
            set
            {
                SetPropertyValue("ContanteAltriEnti", ref _ContanteAltriEnti, value);
            }
        }

        private string _Quietanza;
        public string Quietanza
        {
            get
            {
                return _Quietanza;
            }
            set
            {
                SetPropertyValue("Quietanza", ref _Quietanza, value);
            }
        }

        private SoggettoEconomico _SoggettoEconomico;
        public SoggettoEconomico SoggettoEconomico
        {
            get
            {
                return _SoggettoEconomico;
            }
            set
            {
                SetPropertyValue("SoggettoEconomico", ref _SoggettoEconomico, value);
            }
        }

        private Guid _Gruppo;
        [Indexed]
        public Guid Gruppo
        {
            get
            {
                return _Gruppo;
            }
            set
            {
                SetPropertyValue("Gruppo", ref _Gruppo, value);
            }
        }

        public Versamento(Session session) : base(session) { }
    }

}
