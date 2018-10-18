using System;

using DevExpress.Xpo;
using System.ComponentModel;

namespace Musei.Module
{
    public class MessaggioConferma : MuseiBase
    {
        private Messaggio _Messaggio;
        [Association("Messaggio-Conferme")]
        public Messaggio Messaggio
        {
            get
            {
                return _Messaggio;
            }
            set
            {
                SetPropertyValue("Messaggio", ref _Messaggio, value);
            }
        }

        private Utente _Utente;
        public Utente Utente
        {
            get
            {
                return _Utente;
            }
            set
            {
                SetPropertyValue("Utente", ref _Utente, value);
            }
        }

        private DateTime _Data;
        public DateTime Data
        {
            get
            {
                return _Data;
            }
            set
            {
                SetPropertyValue("Data", ref _Data, value);
            }
        }

        private bool _Letto;
        public bool Letto
        {
            get
            {
                return _Letto;
            }
            set
            {
                SetPropertyValue("Letto", ref _Letto, value);
            }
        }

        public MessaggioConferma(Session session) : base(session) { }
    }

}
