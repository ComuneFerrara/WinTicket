using System;

using DevExpress.Xpo;
using System.Collections.Generic;
using System.Data;

namespace Musei.Module
{
    public class Card : MuseiBase
    {
        private bool _EmessoBiglietto;
        private bool _VendutaOnline;
        private DateTime _AssegnataIl;
        private Utente _AssegnataUtente;
        private Struttura _AssegnataStruttura;
        private AnagraficaCard _Albergo;
        private Stampa _Stampa;
        private EnumStatoCard _Status;
        private EnumTipologiaCard _TipologiaCard;
        private string m_Codice;
        private string m_Email;
        private string m_Cliente;
        private string m_TitolareCarta;
        private string m_CodiceOperazione;
        private string m_Transazione;

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

        public EnumTipologiaCard TipologiaCard
        {
            get
            {
                return _TipologiaCard;
            }
            set
            {
                SetPropertyValue("TipologiaCard", ref _TipologiaCard, value);
            }
        }

        public EnumStatoCard Status
        {
            get
            {
                return _Status;
            }
            set
            {
                SetPropertyValue("Status", ref _Status, value);
            }
        }

        public Stampa Stampa
        {
            get
            {
                return _Stampa;
            }
            set
            {
                SetPropertyValue("Stampa", ref _Stampa, value);
            }
        }

        public AnagraficaCard Albergo
        {
            get
            {
                return _Albergo;
            }
            set
            {
                SetPropertyValue("Albergo", ref _Albergo, value);
            }
        }

        public Struttura AssegnataStruttura
        {
            get
            {
                return _AssegnataStruttura;
            }
            set
            {
                SetPropertyValue("AssegnataStruttura", ref _AssegnataStruttura, value);
            }
        }

        public Utente AssegnataUtente
        {
            get
            {
                return _AssegnataUtente;
            }
            set
            {
                SetPropertyValue("AssegnataUtente", ref _AssegnataUtente, value);
            }
        }

        public DateTime AssegnataIl
        {
            get
            {
                return _AssegnataIl;
            }
            set
            {
                SetPropertyValue("AssegnataIl", ref _AssegnataIl, value);
            }
        }

        // CAMPI PER VENDITA ONLINE

        public bool VendutaOnline
        {
            get
            {
                return _VendutaOnline;
            }
            set
            {
                SetPropertyValue("VendutaOnline", ref _VendutaOnline, value);
            }
        }

        public bool EmessoBiglietto
        {
            get
            {
                return _EmessoBiglietto;
            }
            set
            {
                SetPropertyValue("EmessoBiglietto", ref _EmessoBiglietto, value);
            }
        }

        public string Email
        {
            get
            {
                return m_Email;
            }
            set
            {
                SetPropertyValue("Email", ref m_Email, value);
            }
        }

        public string Cliente
        {
            get
            {
                return m_Cliente;
            }
            set
            {
                SetPropertyValue("Cliente", ref m_Cliente, value);
            }
        }

        public string TitolareCarta
        {
            get
            {
                return m_TitolareCarta;
            }
            set
            {
                SetPropertyValue("TitolareCarta", ref m_TitolareCarta, value);
            }
        }

        public string CodiceOperazione
        {
            get
            {
                return m_CodiceOperazione;
            }
            set
            {
                SetPropertyValue("CodiceOperazione", ref m_CodiceOperazione, value);
            }
        }

        public string Transazione
        {
            get
            {
                return m_Transazione;
            }
            set
            {
                SetPropertyValue("Transazione", ref m_Transazione, value);
            }
        }

        public Card(Session session) : base(session) { }

        public int Giorni()
        {
            return GiorniCard(TipologiaCard);
        }

        [NonPersistent]
        public decimal Importo
        {
            get
            {
                return PrezzoCard(this.TipologiaCard);
            }
        }

        public static decimal PrezzoCard(EnumTipologiaCard tipoCard)
        {
            switch (tipoCard)
            {
                case EnumTipologiaCard.Card2Giorni:
                    return 12;
                case EnumTipologiaCard.Card3Giorni:
                    return 14;
                case EnumTipologiaCard.Card6Giorni:
                    return 18;
                default:
                    throw new Exception("tipologia card non prevista");
            }
        }

        public static int GiorniCard(EnumTipologiaCard enumTipologiaCard)
        {
            switch (enumTipologiaCard)
            {
                case EnumTipologiaCard.None:
                    return 0;
                case EnumTipologiaCard.Bonus:
                    return 0;
                case EnumTipologiaCard.Card2Giorni:
                    return 2;
                case EnumTipologiaCard.Card3Giorni:
                    return 3;
                case EnumTipologiaCard.Card6Giorni:
                    return 6;
                default:
                    throw new Exception("tipologia card non prevista");
            }
        }
    }

}
