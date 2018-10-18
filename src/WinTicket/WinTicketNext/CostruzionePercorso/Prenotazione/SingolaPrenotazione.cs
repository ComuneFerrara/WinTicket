using System;
using System.Collections.Generic;
using System.Text;
using Musei.Module;
using DevExpress.Xpo;

namespace WinTicketNext.CostruzionePercorso.GestionePrenotazione
{
    public class SingolaPrenotazione
    {
        private DateTime m_Orario;
        public DateTime Orario
        {
            get { return m_Orario; }
            set
            {
                m_Orario = value;
            }
        }

        private DateTime m_orarioFine;
        public DateTime OrarioFine
        {
            get { return m_orarioFine; }
            set
            {
                m_orarioFine = value;
            }
        }        

        private int m_NumeroPersone;
        public int NumeroPersone
        {
            get { return m_NumeroPersone; }
            set
            {
                m_NumeroPersone = value;
            }
        }

        private string m_descrizione;
        public string Descrizione
        {
            get { return m_descrizione; }
            set
            {
                m_descrizione = value;
            }
        }        

        private bool m_originataPrevent;
        public bool OriginataPrevent
        {
            get { return m_originataPrevent; }
            set
            {
                m_originataPrevent = value;
            }
        }

        private DateTime m_orarioPrevent;
        public DateTime OrarioPrevent
        {
            get
            {
                return m_orarioPrevent;
            }
            set
            {
                m_orarioPrevent = value;
            }
        }
        
    }
}
