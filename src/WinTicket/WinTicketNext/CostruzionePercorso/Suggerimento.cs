using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Xpo;
using Musei.Module;

namespace WinTicketNext.CostruzionePercorso
{
    public class Suggerimento
    {
        private decimal m_Importo;
        public decimal Importo
        {
            get { return m_Importo; }
            set
            {
                m_Importo = value;
            }
        }

        private string m_DescrizioneUno;
        public string DescrizioneUno
        {
            get { return m_DescrizioneUno; }
            set
            {
                m_DescrizioneUno = value;
            }
        }

        private string m_DescrizioneDue;
        public string DescrizioneDue
        {
            get { return m_DescrizioneDue; }
            set
            {
                m_DescrizioneDue = value;
            }
        }
        
        private Ingresso m_IngressoUno;
        public Ingresso IngressoUno
        {
            get { return m_IngressoUno; }
            set
            {
                m_IngressoUno = value;
            }
        }

        private Ingresso m_IngressoDue;
        public Ingresso IngressoDue
        {
            get { return m_IngressoDue; }
            set
            {
                m_IngressoDue = value;
            }
        }

        internal string DescrizioneCompleta()
        {
            string str = DescrizioneUno;
            if (!string.IsNullOrEmpty(DescrizioneDue))
                str += " e " + DescrizioneDue;

            return str;
        }
    }
}
