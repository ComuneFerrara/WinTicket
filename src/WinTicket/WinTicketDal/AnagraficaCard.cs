using System;

using DevExpress.Xpo;
using System.Collections.Generic;

namespace Musei.Module
{
    public class AnagraficaCard : MuseiBase
    {
        // Fields...
        private string _Email;
        private string _Indirizzo;
        private string _RagioneSociale;

        public string RagioneSociale
        {
            get
            {
                return _RagioneSociale;
            }
            set
            {
                SetPropertyValue("RagioneSociale", ref _RagioneSociale, value);
            }
        }

        public string Indirizzo
        {
            get
            {
                return _Indirizzo;
            }
            set
            {
                SetPropertyValue("Indirizzo", ref _Indirizzo, value);
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                SetPropertyValue("Email", ref _Email, value);
            }
        }

        public AnagraficaCard(Session session) : base(session) { }
    }

}
