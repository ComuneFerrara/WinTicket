using System;
using DevExpress.Xpo;
using Musei.Module;

namespace Musei.Module
{
    public class Entrata : MuseiBase
    {
        private RigaStampaIngresso m_RigaStampaIngresso;
        [Association("RigaStampaIngressoEntrate")]
        public RigaStampaIngresso RigaStampaIngresso
        {
            get
            {
                return m_RigaStampaIngresso;
            }
            set
            {
                SetPropertyValue("RigaStampaIngresso", ref m_RigaStampaIngresso, value);
            }
        }

        private DateTime _DataOraEntrata;
        public DateTime DataOraEntrata
        {
            get
            {
                return _DataOraEntrata;
            }
            set
            {
                SetPropertyValue("DataOraEntrata", ref _DataOraEntrata, value);
            }
        }

        private int _Quantita;
        public int Quantita
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

        public Entrata(Session session) : base(session) { }
    }
}
