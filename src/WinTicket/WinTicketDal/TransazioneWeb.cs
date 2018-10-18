using System;

using DevExpress.Xpo;
using System.Collections.Generic;

namespace Musei.Module
{
    public class TransazioneWeb : MuseiBase
    {
        private string _PuntoVendita;
        public string PuntoVendita
        {
            get
            {
                return _PuntoVendita;
            }
            set
            {
                SetPropertyValue("PuntoVendita", ref _PuntoVendita, value);
            }
        }

        private string _Cliente;
        public string Cliente
        {
            get
            {
                return _Cliente;
            }
            set
            {
                SetPropertyValue("Cliente", ref _Cliente, value);
            }
        }

        private string _EmailCliente;
        public string EmailCliente
        {
            get
            {
                return _EmailCliente;
            }
            set
            {
                SetPropertyValue("EmailCliente", ref _EmailCliente, value);
            }
        }

        private string _IDCliente;
        public string IDCliente
        {
            get
            {
                return _IDCliente;
            }
            set
            {
                SetPropertyValue("IDCliente", ref _IDCliente, value);
            }
        }

        private string _Transazione;
        public string Transazione
        {
            get
            {
                return _Transazione;
            }
            set
            {
                SetPropertyValue("Transazione", ref _Transazione, value);
            }
        }

        private string _InseritaIl;
        public string InseritaIl
        {
            get
            {
                return _InseritaIl;
            }
            set
            {
                SetPropertyValue("InseritaIl", ref _InseritaIl, value);
            }
        }

        private string _TitolareCarta;
        public string TitolareCarta
        {
            get
            {
                return _TitolareCarta;
            }
            set
            {
                SetPropertyValue("TitolareCarta", ref _TitolareCarta, value);
            }
        }

        private string _EmailTitolare;
        public string EmailTitolare
        {
            get
            {
                return _EmailTitolare;
            }
            set
            {
                SetPropertyValue("EmailTitolare", ref _EmailTitolare, value);
            }
        }

        private string _Inizio;
        public string Inizio
        {
            get
            {
                return _Inizio;
            }
            set
            {
                SetPropertyValue("Inizio", ref _Inizio, value);
            }
        }

        private string _Fine;
        public string Fine
        {
            get
            {
                return _Fine;
            }
            set
            {
                SetPropertyValue("Fine", ref _Fine, value);
            }
        }

        private string _Giorni;
        public string Giorni
        {
            get
            {
                return _Giorni;
            }
            set
            {
                SetPropertyValue("Giorni", ref _Giorni, value);
            }
        }

        private string _Prodotto;
        public string Prodotto
        {
            get
            {
                return _Prodotto;
            }
            set
            {
                SetPropertyValue("Prodotto", ref _Prodotto, value);
            }
        }

        private string _CodiceOperazione;
        public string CodiceOperazione
        {
            get
            {
                return _CodiceOperazione;
            }
            set
            {
                SetPropertyValue("CodiceOperazione", ref _CodiceOperazione, value);
            }
        }

        private string _CodiceTessera;
        public string CodiceTessera
        {
            get
            {
                return _CodiceTessera;
            }
            set
            {
                SetPropertyValue("CodiceTessera", ref _CodiceTessera, value);
            }
        }

        private string _TipoOperazione;
        public string TipoOperazione
        {
            get
            {
                return _TipoOperazione;
            }
            set
            {
                SetPropertyValue("TipoOperazione", ref _TipoOperazione, value);
            }
        }

        private string _Quantita;
        public string Quantita
        {
            get
            {
                return _Quantita;
            }
            set
            {
                SetPropertyValue("Quantita", ref _Quantita, value);
            }
        }

        private DateTime _InseritaIlDateTime;
        public DateTime InseritaIlDateTime
        {
            get
            {
                return _InseritaIlDateTime;
            }
            set
            {
                SetPropertyValue("InseritaIlDateTime", ref _InseritaIlDateTime, value);
            }
        }

        private DateTime _InizioDateTime;
        public DateTime InizioDateTime
        {
            get
            {
                return _InizioDateTime;
            }
            set
            {
                SetPropertyValue("InizioDateTime", ref _InizioDateTime, value);
            }
        }

        private DateTime _FineDateTime;
        public DateTime FineDateTime
        {
            get
            {
                return _FineDateTime;
            }
            set
            {
                SetPropertyValue("FineDateTime", ref _FineDateTime, value);
            }
        }

        public TransazioneWeb(Session session) : base(session) { }

    }

}
