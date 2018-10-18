using System;
using DevExpress.Xpo;

namespace Musei.Module
{
    public class RigaVenditaVariante : MuseiBase
    {
        private Vendita m_Vendita;
        [Association("Vendita-RigheVenditaVariante")]
        public Vendita Vendita
        {
            get
            {
                return m_Vendita;
            }
            set
            {
                SetPropertyValue("Vendita", ref m_Vendita, value);
            }
        }

        private int m_Profilo;
        public int Profilo
        {
            get
            {
                return m_Profilo;
            }
            set
            {
                SetPropertyValue("Profilo", ref m_Profilo, value);
            }
        }

        private Variante m_Variante;
        public Variante Variante
        {
            get
            {
                return m_Variante;
            }
            set
            {
                SetPropertyValue("Variante", ref m_Variante, value);
            }
        }

        private Titolo m_Titolo;
        public Titolo Titolo
        {
            get
            {
                return m_Titolo;
            }
            set
            {
                SetPropertyValue("Titolo", ref m_Titolo, value);
            }
        }

        private CodiceSconto m_CodiceSconto;
        public CodiceSconto CodiceSconto
        {
            get
            {
                return m_CodiceSconto;
            }
            set
            {
                SetPropertyValue("CodiceSconto", ref m_CodiceSconto, value);
            }
        }

        private Card m_Card;
        public Card Card
        {
            get
            {
                return m_Card;
            }
            set
            {
                SetPropertyValue("Card", ref m_Card, value);
            }
        }

        private string m_Matricola;
        public string Matricola
        {
            get
            {
                return m_Matricola;
            }
            set
            {
                SetPropertyValue("Matricola", ref m_Matricola, value);
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

        [NonPersistent]
        public decimal IncassoContanti
        {
            get
            {
                return Vendita.Incasso == EnumIncasso.Contanti ? PrezzoTotale : 0;
            }
        }

        [NonPersistent]
        public decimal IncassoPos
        {
            get
            {
                return Vendita.Incasso == EnumIncasso.Pos ? PrezzoTotale : 0;
            }
        }

        [NonPersistent]
        public decimal IncassoOnline
        {
            get
            {
                return Vendita.Incasso == EnumIncasso.Internet ? PrezzoTotale : 0;
            }
        }

        [NonPersistent]
        public decimal IncassoFatturaElettronica
        {
            get
            {
                return Vendita.Incasso == EnumIncasso.FatturaElettronica ? PrezzoTotale : 0;
            }
        }

        public RigaVenditaVariante(Session session) : base(session) { }
    }

}
