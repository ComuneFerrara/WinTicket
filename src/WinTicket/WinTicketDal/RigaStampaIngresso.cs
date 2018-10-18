using System;
using DevExpress.Xpo;
using System.Collections.Generic;

namespace Musei.Module
{
    public class RigaStampaIngresso : MuseiBase
    {
        private Stampa m_Stampa;
        [Association("StampaRigheStampaIngresso")]
        public Stampa Stampa
        {
            get
            {
                return m_Stampa;
            }
            set
            {
                SetPropertyValue("Stampa", ref m_Stampa, value);
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

        private int m_totalePersone;
        public int TotalePersone
        {
            get
            {
                return m_totalePersone;
            }
            set
            {
                SetPropertyValue("TotalePersone", ref m_totalePersone, value);
            }
        }

        private int m_TotaleIngressi;
        public int TotaleIngressi
        {
            get
            {
                return m_TotaleIngressi;
            }
            set
            {
                SetPropertyValue("TotaleIngressi", ref m_TotaleIngressi, value);
            }
        }

        [Association("RigaStampaIngressoEntrate"), Aggregated]
        public XPCollection<Entrata> Entrate
        {
            get
            {
                return GetCollection<Entrata>("Entrate");
            }
        }

        //[Association("RigaStampaIngressoPrenotazioni")]
        //public XPCollection<Prenotazione> Prenotazioni
        //{
        //    get
        //    {
        //        return GetCollection<Prenotazione>("Prenotazioni");
        //    }
        //}

        private List<Prenotazione> m_Prenotazioni;
        [NonPersistent]
        public List<Prenotazione> Prenotazioni
        {
            get
            {
                if (m_Prenotazioni == null)
                {
                    m_Prenotazioni = new List<Prenotazione>();
                    foreach (Prenotazione item in Stampa.Vendita.Prenotazioni)
                    {
                        if (item.Ingresso == this.Ingresso)
                            m_Prenotazioni.Add(item);
                    }
                }

                return m_Prenotazioni;
            }
        }

        public RigaStampaIngresso(Session session) : base(session) { }
    }

}
