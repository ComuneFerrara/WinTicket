using System;
using System.Collections.Generic;
using Musei.Module;

namespace WinTicketNext
{
    public class SoluzioneIngressi
    {
        public List<SoluzioneIngressiItem> Elenco = new List<SoluzioneIngressiItem>();

        public int NumeroPercorsi { get; set; }
        public int NumeroIngressi { get; set; }
        public decimal ImportoTotale { get; set; }
        public int NumeroPersone { get; set; }
        public decimal ImportoUnitario { get; set; }        

        private string m_Tipologia = "Standard";
        public string Tipologia
        {
            get { return m_Tipologia; }
            set
            {
                m_Tipologia = value;
            }
        }

        public bool ContieneGruppoOppureScuola()
        {
            foreach (SoluzioneIngressiItem t in Elenco)
            {
                if (t.Variante.TipologiaUno == EnumTipologiaUno.Gruppo || t.Variante.TipologiaUno == EnumTipologiaUno.Scuola)
                    return true;                
            }
            return false;
        }

        public int NumeroDiGruppiOppureScuola()
        {
            int numero = 0;
            foreach (SoluzioneIngressiItem t in Elenco)
            {
                if (t.Variante.TipologiaTre == EnumTipologiaTre.OmaggioGruppo) continue;

                if (t.Variante.TipologiaUno == EnumTipologiaUno.Gruppo || t.Variante.TipologiaUno == EnumTipologiaUno.Scuola)                    
                    numero++;
            }
            return numero;
        }

        public bool Bigliettone()
        {
            foreach (SoluzioneIngressiItem t in Elenco)
            {
                if (t.Variante.TipologiaTre == EnumTipologiaTre.Bigliettone)
                    return true;
            }
            return false;
        }

        internal bool CardMusei()
        {
            foreach (SoluzioneIngressiItem t in Elenco)
            {
                if (t.Variante.Biglietto.Tipologia == EnumTipologiaBiglietto.Card && t.Variante.TipologiaTre != EnumTipologiaTre.CardMyFE)
                    return true;
            }
            return false;            
        }

        internal bool CardMyFE()
        {
            foreach (SoluzioneIngressiItem t in Elenco)
            {
                if (t.Variante.TipologiaTre == EnumTipologiaTre.CardMyFE)
                    return true;
            }
            return false;
        }

        internal bool Cumulativo()
        {
            foreach (SoluzioneIngressiItem t in Elenco)
            {
                if (t.Variante.Biglietto.Tipologia == EnumTipologiaBiglietto.Cumulativo)
                    return true;
            }
            return false;
        }

        internal Card[] GetElencoCardMyFE(DevExpress.Xpo.UnitOfWork uow)
        {
            // assumo che la card, se c'è ci sia per TUTTI
            Card[] elenco = new Card[this.NumeroPersone];

            int index = 0;
            foreach (SoluzioneIngressiItem sol in this.Elenco)
            {
                if (sol.ElencoCardMyFE != null)
                {
                    foreach (Card card in sol.ElencoCardMyFE)
                    {
                        elenco[index] = uow.GetObjectByKey<Card>(card.Oid);
                        index++;
                    }
                }
            }

            return elenco;
        }
    }
}