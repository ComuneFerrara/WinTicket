using System;

using DevExpress.Xpo;
using System.ComponentModel;
using System.Collections.Generic;

namespace Musei.Module
{
    [DefaultProperty("Descrizione")]
    public class RigaFattura : MuseiBase
    {
        private Fattura m_Fattura;
        [Association("Fattura-RigaFattura")]
        public Fattura Fattura
        {
            get
            {
                return m_Fattura;
            }
            set
            {
                SetPropertyValue("Fattura", ref m_Fattura, value);
            }
        }

        private string _DescrizioneRiga;
        [Size(SizeAttribute.Unlimited)]
        public string DescrizioneRiga
        {
            get
            {
                return _DescrizioneRiga;
            }
            set
            {
                SetPropertyValue("DescrizioneRiga", ref _DescrizioneRiga, value);
            }
        }

        private decimal m_PrezzoUnitario;
        public decimal PrezzoUnitario
        {
            get
            {
                return m_PrezzoUnitario;
            }
            set
            {
                SetPropertyValue("PrezzoUnitario", ref m_PrezzoUnitario, value);
            }
        }

        private int m_Quantita;
        public int Quantita
        {
            get
            {
                return m_Quantita;
            }
            set
            {
                SetPropertyValue("Quantita", ref m_Quantita, value);
            }
        }

        private decimal m_PrezzoTotale;
        public decimal PrezzoTotale
        {
            get
            {
                return m_PrezzoTotale;
            }
            set
            {
                SetPropertyValue("PrezzoTotale", ref m_PrezzoTotale, value);
            }
        }

        public RigaFattura(Session session) : base(session) { }

       
    }

}
