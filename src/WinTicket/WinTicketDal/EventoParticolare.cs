using System;

using DevExpress.Xpo;
using System.ComponentModel;

namespace Musei.Module
{
    public class EventoParticolare : MuseiBase
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

        private string _DescrizioneEstesa;
        [Size(SizeAttribute.Unlimited)]
        public string DescrizioneEstesa
        {
            get
            {
                return _DescrizioneEstesa;
            }
            set
            {
                SetPropertyValue("DescrizioneEstesa", ref _DescrizioneEstesa, value);
            }
        }

        private DateTime _DataOraInizio;
        [Indexed]
        public DateTime DataOraInizio
        {
            get
            {
                return _DataOraInizio;
            }
            set
            {
                SetPropertyValue("DataOraInizio", ref _DataOraInizio, value);
            }
        }

        private DateTime _DataOraFine;
        [Indexed]
        public DateTime DataOraFine
        {
            get
            {
                return _DataOraFine;
            }
            set
            {
                SetPropertyValue("DataOraFine", ref _DataOraFine, value);
            }
        }

        private EnumTipologiaEventoParticolare _Tipologia;
        public EnumTipologiaEventoParticolare Tipologia
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

        private Biglietto _Biglietto;
        [Association("Biglietto-Eventi")]
        public Biglietto Biglietto
        {
            get
            {
                return _Biglietto;
            }
            set
            {
                SetPropertyValue("Biglietto", ref _Biglietto, value);
            }
        }

        private Titolo _Titolo;
        public Titolo Titolo
        {
            get
            {
                return _Titolo;
            }
            set
            {
                SetPropertyValue("Titolo", ref _Titolo, value);
            }
        }

        // nel campo 'Attributi' della tabella 'TITOLO'
        public const string STR_COM_EVT_OMAGGIO = "[COM_EVT_OMAGGIO]";
        public const string STR_PROV_EVT_RIDOTTO = "[PROV_EVT_RIDOTTO]";

        // nella tabella STRUTTURA e SOGGETTO_ECONOMICO
        public const string STR_COMUNE_FE = "[COMUNE_FE]";
        //public const string STR_CASTELLO = "[CASTELLO]";
        public const string STR_PROVINCIA_FE = "[PROVINCIA_FE]";
        public const string STR_NOFREE = "[NO-ENTRATA-EVENTO-FREE]";

        // nella tabella INGRESSI
        public const string STR_INGRESSI_TORRE_FE = "[TORRE]";
        //public const string STR_INGRESSI_VERIFICA_VALIDITA = "[V.VAL]";
        public const string STR_INGRESSI_NO_VENDITA_DA_ALTRI = "[NOSELL]";

        public const string STR_INGRESSI_MOD_TERREMOTO_1 = "[EQ1]";
        public static readonly DateTime EQDataEvento = new DateTime(2012, 5, 20);

        public EventoParticolare(Session session) : base(session) { }

    }

}
