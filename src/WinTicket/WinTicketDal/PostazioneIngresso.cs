using System;

using DevExpress.Xpo;
using System.ComponentModel;
using System.Collections.Generic;

namespace Musei.Module
{
    public class PostazioneIngresso : MuseiBase
    {
        private Postazione _Postazione;
        [Association("Postazione-Ingressi")]
        public Postazione Postazione
        {
            get
            {
                return _Postazione;
            }
            set
            {
                SetPropertyValue("Postazione", ref _Postazione, value);
            }
        }

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

        private EnumTipologiaPostazioneIngresso _Tipologia;
        public EnumTipologiaPostazioneIngresso Tipologia
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

        public PostazioneIngresso(Session session) : base(session) { }

    }

}
