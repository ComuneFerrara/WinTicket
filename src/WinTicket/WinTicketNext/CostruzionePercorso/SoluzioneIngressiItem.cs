using System;
using Musei.Module;
using System.Collections.Generic;

namespace WinTicketNext
{
    public class SoluzioneIngressiItem : IComparable<SoluzioneIngressiItem>
    {
        public List<Card> ElencoCardMyFE = new List<Card>();
        
        private Variante m_Variante;
        public Variante Variante
        {
            get { return m_Variante; }
            set
            {
                m_Variante = value;
            }
        }

        private Titolo m_Titolo;
        public Titolo Titolo
        {
            get { return m_Titolo; }
            set
            {
                m_Titolo = value;
            }
        }

        private decimal m_PrezzoUnitario;
        public decimal PrezzoUnitario
        {
            get { return m_PrezzoUnitario; }
            set
            {
                m_PrezzoUnitario = value;
            }
        }

        private int m_Quantita;
        public int Quantita
        {
            get { return m_Quantita; }
            set
            {
                m_Quantita = value;
            }
        }

        private decimal m_PrezzoTotale;
        public decimal PrezzoTotale
        {
            get { return m_PrezzoTotale; }
            set
            {
                m_PrezzoTotale = value;
            }
        }

        public SoluzioneIngressiItem(Variante variante)
        {
            Variante = variante;
            Titolo = null;
            Quantita = 1;

            m_PrezzoUnitario = Variante.Prezzo;
            m_PrezzoTotale = PrezzoUnitario * Quantita;
        }

        public SoluzioneIngressiItem(Variante variante, Titolo titolo)
        {
            Variante = variante;
            Titolo = titolo;
            Quantita = 1;

            m_PrezzoUnitario = Variante.Prezzo;
            m_PrezzoTotale = PrezzoUnitario * Quantita;
        }

        public SoluzioneIngressiItem(Variante variante, Titolo titolo, int quantita)
        {
            Variante = variante;
            Titolo = titolo;
            Quantita = quantita;

            m_PrezzoUnitario = Variante.Prezzo;
            m_PrezzoTotale = PrezzoUnitario * Quantita;
        }

        public string Descrizione
        {
            get
            {
                return String.Format("{0} x {1}{2}", Quantita, Variante.Descrizione, (Titolo != null ? " [" + Titolo.Descrizione + "]" : string.Empty));
            }
        }

        public string TitoloDescrizione
        {
            get
            {
                return Titolo != null ? Titolo.Descrizione : string.Empty;
            }
        }

        public string VarianteDescrizione
        {
            get
            {
                return Variante != null ? Variante.Descrizione : string.Empty;
            }
        }

        public int CompareTo(SoluzioneIngressiItem other)
        {
            return Descrizione.CompareTo(other.Descrizione);
        }
    }
}
