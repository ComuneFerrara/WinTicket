using System;
using DevExpress.Xpo;
using System.ComponentModel;
using System.Collections.Generic;

namespace Musei.Module
{
    [DefaultProperty("Descrizione")]
    public class Variante : MuseiBase
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

        private string m_Tipologia;
        public string Tipologia
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

        private string m_Note;
        public string Note
        {
            get
            {
                return m_Note;
            }
            set
            {
                SetPropertyValue("Note", ref m_Note, value);
            }
        }

        private EnumTipologiaUno m_TipologiaUno;
        public EnumTipologiaUno TipologiaUno
        {
            get
            {
                return m_TipologiaUno;
            }
            set
            {
                SetPropertyValue("TipologiaUno", ref m_TipologiaUno, value);
            }
        }

        private EnumTipologiaDue m_TipologiaDue;
        public EnumTipologiaDue TipologiaDue
        {
            get
            {
                return m_TipologiaDue;
            }
            set
            {
                SetPropertyValue("TipologiaDue", ref m_TipologiaDue, value);
            }
        }

        private EnumTipologiaTre m_TipologiaTre;
        public EnumTipologiaTre TipologiaTre
        {
            get
            {
                return m_TipologiaTre;
            }
            set
            {
                SetPropertyValue("TipologiaTre", ref m_TipologiaTre, value);
            }
        }

        [NonPersistent]
        public EnumTipologiaEconomica TipologiaEconomica
        {
            get
            {
                // caso speciale per le registrazioni card MyFE del museo di storia naturale
                if (TipologiaTre == EnumTipologiaTre.CardMyFE && TipologiaDue == EnumTipologiaDue.Omaggio)
                    return EnumTipologiaEconomica.Pagante;

                return TipologiaDue == EnumTipologiaDue.Omaggio ? EnumTipologiaEconomica.Gratuito : EnumTipologiaEconomica.Pagante;
            }
        }

        private string m_codicePrevent;
        public string CodicePrevent
        {
            get
            {
                return m_codicePrevent;
            }
            set
            {
                SetPropertyValue("CodicePrevent", ref m_codicePrevent, value);
            }
        }

        private DateTime m_InizioPeriodo;
        public DateTime InizioPeriodo
        {
            get
            {
                return m_InizioPeriodo;
            }
            set
            {
                SetPropertyValue("InizioPeriodo", ref m_InizioPeriodo, value);
            }
        }

        private DateTime m_FinePeriodo;
        public DateTime FinePeriodo
        {
            get
            {
                return m_FinePeriodo;
            }
            set
            {
                SetPropertyValue("FinePeriodo", ref m_FinePeriodo, value);
            }
        }

        [NonPersistent]
        public TimeSpan Intervallo
        {
            get
            {
                return FinePeriodo - InizioPeriodo;
            }
        }

        public bool ComprendeData(DateTime data)
        {
            if (InizioPeriodo <= data && FinePeriodo >= data)
                return true;
            else
                return false;
        }

        private bool m_VenditaAbilitata;
        public bool VenditaAbilitata
        {
            get
            {
                return m_VenditaAbilitata;
            }
            set
            {
                SetPropertyValue("VenditaAbilitata", ref m_VenditaAbilitata, value);
            }
        }

        [Association("Variante-Titolo", UseAssociationNameAsIntermediateTableName = true)]
        public XPCollection<Titolo> ElencoTitoli
        {
            get
            {
                return GetCollection<Titolo>("ElencoTitoli");
            }
        }

        //[Association("Variante-CodiceSconto", UseAssociationNameAsIntermediateTableName = true)]
        //public XPCollection<CodiceSconto> ElencoCodiciSconto
        //{
        //    get
        //    {
        //        return GetCollection<CodiceSconto>("ElencoCodiciSconto");
        //    }
        //}

        [Association("Variante-StoricoPrezzi"), Aggregated]
        public XPCollection<Importo> StoricoPrezzi
        {
            get
            {
                return GetCollection<Importo>("StoricoPrezzi");
            }
        }

        private Importo m_PrezzoAttuale;
        [NonPersistent]
        public Importo PrezzoAttuale
        {
            get
            {
                if (m_PrezzoAttuale == null)
                {
                    foreach (Importo item in StoricoPrezzi)
                    {
                        if (item.ComprendeData(DateTime.Now))
                        {
                            if (m_PrezzoAttuale == null)
                                m_PrezzoAttuale = item;
                            else
                                if (item.Intervallo < m_PrezzoAttuale.Intervallo)
                                    m_PrezzoAttuale = item;
                        }
                    }
                }

                return m_PrezzoAttuale;
            }
        }

        [NonPersistent]
        public decimal Prezzo
        {
            get
            {
                return PrezzoAttuale != null ? PrezzoAttuale.Prezzo : 0;
            }
        }        

        private Biglietto m_Biglietto;
        [Association("Biglietto-Varianti")]
        public Biglietto Biglietto
        {
            get
            {
                return m_Biglietto;
            }
            set
            {
                SetPropertyValue("Biglietto", ref m_Biglietto, value);
            }
        }

        protected override void OnSaving()
        {
            base.OnSaving();

            if (StoricoPrezzi.Count == 0)
            {
                Importo importo = new Importo(Session);
                importo.Variante = this;
                importo.Save();

                this.StoricoPrezzi.Add(importo);
            }
        }

        public Variante(Session session) : base(session) { }

        public bool ComprendeAlmenoUno(IEnumerable<Ingresso> dafare)
        {
            int found = 0;
            foreach (Ingresso item in dafare)
            {
                if (Biglietto == null) continue;
                if (Biglietto.Percorso == null) continue;

                if (Biglietto.Percorso.Ingressi.IndexOf(item) >= 0)
                {
                    found++;
                    break;
                }
            }

            return found != 0;
        }

        public bool HoTitoloPerComprarlo(IEnumerable<Titolo> titoli, IEnumerable<CodiceSconto> sconti, int numeroPersone, bool scuola, out Titolo titolo)
        {
            titolo = null;

            if (TipologiaUno == EnumTipologiaUno.Scuola && !scuola)
                return false;

            if (TipologiaTre == EnumTipologiaTre.OmaggioGruppo)
                return false;

            //int numRequisiti = 0;
            int numTitoli = 0;
            if (titoli != null)
            {
                foreach (Titolo item in titoli)
                {
                    if (ElencoTitoli.IndexOf(item) >= 0)
                    {
                        numTitoli++;

                        if (titolo == null)
                            titolo = item;
                        else
                            if (titolo.Priority > item.Priority)
                                titolo = item;
                    }
                    foreach (Titolo subitem in item.TitoliCompresi)
                    {
                        if (ElencoTitoli.IndexOf(subitem) >= 0)
                        {
                            numTitoli++;

                            if (titolo == null)
                                titolo = subitem;
                            else
                                if (titolo.Priority > subitem.Priority)
                                    titolo = subitem;
                        }
                    }
                }
            }

            // se NON sono stati definiti dei TITOLI, posso acquistare
            if (ElencoTitoli.Count == 0)
                numTitoli = 1;

            // per il GRUPPO devo avere un minimo di persone
            if (TipologiaUno == EnumTipologiaUno.Gruppo && numeroPersone < this.Biglietto.MinimoPerGruppo)
                numTitoli = 0;

            return numTitoli != 0;
        }

        public EnumTipologiaCard GiorniCardMyFe()
        {
            if (!string.IsNullOrEmpty(Note) && Note.Contains(EnumTipologiaCard.Card2Giorni.ToString())) return EnumTipologiaCard.Card2Giorni;
            if (!string.IsNullOrEmpty(Note) && Note.Contains(EnumTipologiaCard.Card3Giorni.ToString())) return EnumTipologiaCard.Card3Giorni;
            if (!string.IsNullOrEmpty(Note) && Note.Contains(EnumTipologiaCard.Card6Giorni.ToString())) return EnumTipologiaCard.Card6Giorni;
            return EnumTipologiaCard.None;
        }

        public bool MyFeComune()
        {
            return (TipologiaTre == EnumTipologiaTre.CardMyFE && (Note ?? "").Contains("-Com-"));
        }
    }
}
