using System;
using System.Collections.Generic;
using System.Text;
using Musei.Module;

namespace WinTicketNext.Pivot
{
    public class PivotOffertaItem
    {
        private string m_Percorso;
        public string Percorso
        {
            get { return m_Percorso; }
            set
            {
                m_Percorso = value;
            }
        }
        
        private string m_Titolo;
        public string Titolo
        {
            get { return m_Titolo; }
            set
            {
                m_Titolo = value;
            }
        }

        private string m_Gruppo;
        public string Gruppo
        {
            get { return m_Gruppo; }
            set
            {
                m_Gruppo = value;
            }
        }

        private EnumTipologiaUno m_TipologiaUno;
        public EnumTipologiaUno TipologiaUno
        {
            get { return m_TipologiaUno; }
            set
            {
                m_TipologiaUno = value;
            }
        }

        private EnumTipologiaDue m_TipologiaDue;
        public EnumTipologiaDue TipologiaDue
        {
            get { return m_TipologiaDue; }
            set
            {
                m_TipologiaDue = value;
            }
        }

        private EnumTipologiaTre m_TipologiaTre;
        public EnumTipologiaTre TipologiaTre
        {
            get { return m_TipologiaTre; }
            set
            {
                m_TipologiaTre = value;
            }
        }

        private decimal? m_Importo;
        public decimal? Importo
        {
            get { return m_Importo; }
            set
            {
                m_Importo = value;
            }
        }        
    }
}
