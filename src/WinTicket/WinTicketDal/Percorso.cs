using System;

using DevExpress.Xpo;
using System.ComponentModel;
using System.Collections.Generic;

namespace Musei.Module
{
    [DefaultProperty("Descrizione")]
    public class Percorso : MuseiBase
    {
        private string m_Descrizione;
        public string Descrizione
        {
            get
            {
                return m_Descrizione;
            }
            set
            {
                SetPropertyValue("Descrizione", ref m_Descrizione, value);
            }
        }

        private EnumTipologiaPercorso m_Tipologia;
        public EnumTipologiaPercorso Tipologia
        {
            get
            {
                return m_Tipologia;
            }
            set
            {
                SetPropertyValue("Tipologia", ref m_Tipologia, value);
            }
        }

        [Association("RigaPercorsoIngresso", UseAssociationNameAsIntermediateTableName = true)]
        public XPCollection<Ingresso> Ingressi
        {
            get
            {
                return GetCollection<Ingresso>("Ingressi");
            }
        }

        [Association("BigliettoPercorso")]
        public XPCollection<Biglietto> Biglietti
        {
            get
            {
                return GetCollection<Biglietto>("Biglietti");
            }
        }

        private List<Biglietto> m_BigliettiValidi;
        [NonPersistent]
        public List<Biglietto> BigliettiValidi
        {
            get
            {
                if (m_BigliettiValidi == null)
                {
                    m_BigliettiValidi = new List<Biglietto>();
                    foreach (Biglietto item in Biglietti)
                    {
                        if (item.ComprendeData(DateTime.Now))
                            m_BigliettiValidi.Add(item);
                    }
                }

                return m_BigliettiValidi;
            }
        }

        public Percorso(Session session) : base(session) { }

        public Variante GetVarianteMyFe(string ente, string v2, EnumTipologiaCard card)
        {
            string key = string.Format("[MYFE:{0}-{1}-{2}]", card, ente, v2);

            foreach (Biglietto biglietto in Biglietti)
            {
                if (biglietto.ComprendeData(DateTime.Now))
                {
                    foreach (Variante variante in biglietto.Varianti)
                    {
                        if (variante.VenditaAbilitata && variante.ComprendeData(DateTime.Now) && variante.TipologiaTre == EnumTipologiaTre.CardMyFE && 
                            variante.Note.Contains(key))
                            return variante;
                    }
                }
            }

            return null;
        }
    }

}
