using System;

using DevExpress.Xpo;
using System.ComponentModel;
using System.Collections.Generic;

namespace Musei.Module
{
    [DefaultProperty("Descrizione")]
    public class Ingresso : MuseiBase
    {
        private string _Descrizione;
        [Indexed(Unique=true)]
        public string Descrizione
        {
            get
            {
                return _Descrizione;
            }
            set
            {
                SetPropertyValue("Descrizione", ref _Descrizione, value);
            }
        }

        private string m_descrizioneBreve;
        [Indexed(Unique = true)]
        public string DescrizioneBreve
        {
            get
            {
                return m_descrizioneBreve;
            }
            set
            {
                SetPropertyValue("DescrizioneBreve", ref m_descrizioneBreve, value);
            }
        }

        private string m_intestazioneStampa;
        public string IntestazioneStampa
        {
            get
            {
                return m_intestazioneStampa;
            }
            set
            {
                SetPropertyValue("IntestazioneStampa", ref m_intestazioneStampa, value);
            }
        }

        private int m_codicePrevent;
        public int CodicePrevent
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

        private EnumPrenotazioneIngresso m_Prenotazione;
        public EnumPrenotazioneIngresso Prenotazione
        {
            get
            {
                return m_Prenotazione;
            }
            set
            {
                SetPropertyValue("Prenotazione", ref m_Prenotazione, value);
            }
        }

        private string _DescrizioneTipo;
        public string DescrizioneTipo
        {
            get
            {
                return _DescrizioneTipo;
            }
            set
            {
                SetPropertyValue("DescrizioneTipo", ref _DescrizioneTipo, value);
            }
        }

        private EnumTipologiaIngresso m_Tipologia;
        public EnumTipologiaIngresso Tipologia
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

        private SoggettoEconomico m_SoggettoEconomico;
        [Association("SoggettoEconomico-Ingressi")]
        public SoggettoEconomico SoggettoEconomico
        {
            get
            {
                return m_SoggettoEconomico;
            }
            set
            {
                SetPropertyValue("SoggettoEconomico", ref m_SoggettoEconomico, value);
            }
        }

        private Struttura m_Struttura;
        [Association("Struttura-Ingressi")]
        public Struttura Struttura
        {
            get
            {
                return m_Struttura;
            }
            set
            {
                SetPropertyValue("Struttura", ref m_Struttura, value);
            }
        }

        //private bool _Calendario;
        //public bool Calendario
        //{
        //    get
        //    {
        //        return _Calendario;
        //    }
        //    set
        //    {
        //        SetPropertyValue("Calendario", ref _Calendario, value);
        //    }
        //}

        //private bool _VerificaCalendario;
        //public bool VerificaCalendario
        //{
        //    get
        //    {
        //        return _VerificaCalendario;
        //    }
        //    set
        //    {
        //        SetPropertyValue("VerificaCalendario", ref _VerificaCalendario, value);
        //    }
        //}

        private string _Attributi;
        public string Attributi
        {
            get
            {
                return _Attributi;
            }
            set
            {
                SetPropertyValue("Attributi", ref _Attributi, value);
            }
        }

        public bool IsAttrib(string request)
        {
            if (string.IsNullOrEmpty(Attributi))
                return false;
            else
                return Attributi.ToUpper().Contains(request.ToUpper());
        }

        [NonPersistent]
        public string OrdineReport01
        {
            get
            {
                if (string.IsNullOrEmpty(Attributi))
                    return string.Empty;
                else
                {
                    string[] token = Attributi.Split(new char[] { '[', ']', '-' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < token.Length - 1; i++)
                    {
                        if (token[i] == "orep01") return token[i + 1];
                    }
                    return string.Empty;
                }
            }
        }
        
        [NonPersistent]
        public string OrdineBiglietto
        {
            get
            {
                if (string.IsNullOrEmpty(Attributi))
                    return Descrizione;
                else
                {
                    string[] token = Attributi.Split(new char[] { '[', ']', '-' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < token.Length - 1; i++)
                    {
                        if (token[i] == "orept") return token[i + 1];
                    }
                    return Descrizione;
                }
            }
        }

        [Association("RigaPercorsoIngresso", UseAssociationNameAsIntermediateTableName = true)]
        public XPCollection<Percorso> Percorsi
        {
            get
            {
                return GetCollection<Percorso>("Percorsi");
            }
        }

        [Association("Ingresso-Opzioni")]
        public XPCollection<Ingresso> Opzioni
        {
            get
            {
                return GetCollection<Ingresso>("Opzioni");
            }
        }

        private Ingresso m_IngressoPrincipale;
        [Association("Ingresso-Opzioni")]
        public Ingresso IngressoPrincipale
        {
            get
            {
                return m_IngressoPrincipale;
            }
            set
            {
                SetPropertyValue("IngressoPrincipale", ref m_IngressoPrincipale, value);
            }
        }

        [Association("Ingresso-OrdineIngressi"), Aggregated]
        public XPCollection<OrdineIngresso> OrdineIngressi
        {
            get
            {
                return GetCollection<OrdineIngresso>("OrdineIngressi");
            }
        }

        public Ingresso(Session session) : base(session) { }

        [NonPersistent]
        private List<Titolo> m_ElencoTitoli;
        private List<Titolo> GetElencoTitoli()
        {
            if (m_ElencoTitoli == null)
            {
                m_ElencoTitoli = new List<Titolo>();
                foreach (Percorso percorso in this.Percorsi)
                {
                    foreach (Biglietto biglietto in percorso.BigliettiValidi)
                    {
                        foreach (Variante variante in biglietto.Varianti)
                        {
                            foreach (Titolo titolo in variante.ElencoTitoli)
                            {
                                if (!m_ElencoTitoli.Contains(titolo))
                                    m_ElencoTitoli.Add(titolo);
                            }
                        }
                    }
                }
            }

            return m_ElencoTitoli;
        }

        public bool TitoliDifferenti(Ingresso ingresso)
        {
            List<Titolo> elenco1 = GetElencoTitoli();
            List<Titolo> elenco2 = ingresso.GetElencoTitoli();

            if (elenco1.Count != elenco2.Count)
                return true;

            foreach (Titolo titolo in elenco1)
            {
                if (!elenco2.Contains(titolo))
                    return true;
            }

            return false;
        }

        //public int DurataSlot(string tipo)
        //{
        //    int retValue = 60;

        //    switch (tipo)
        //    {
        //        case "S":
        //            retValue = DurataSlotSingoli;
        //            break;

        //        case "G":
        //            retValue = DurataSlotGruppi;
        //            break;

        //        default:
        //            break;
        //    }

        //    return retValue;
        //}

        //public int CapacitaSlot(string tipo)
        //{
        //    int retValue = 10;

        //    switch (tipo)
        //    {
        //        case "S":
        //            retValue = CapacitaSlotSingoli;
        //            break;

        //        case "G":
        //            retValue = CapacitaSlotGruppi;
        //            break;

        //        default:
        //            break;
        //    }

        //    return retValue;
        //}

        public EnumAccesso GetAccesso(Ingresso ingresso)
        {
            foreach (OrdineIngresso item in this.OrdineIngressi)
            {
                if (item.Ingresso != null && item.Ingresso.Oid == ingresso.Oid)
                {
                    return item.Accesso;
                }
            }

            MakeDefault(ingresso);
            OrdineIngressi.Reload();

            return GetAccesso(ingresso);
        }

        private void MakeDefault(Ingresso ingresso)
        {
            using (Session session = new Session())
            {
                OrdineIngresso ordine = new OrdineIngresso(session);
                ordine.Riferimento = session.GetObjectByKey<Ingresso>(this.Oid);
                ordine.Ingresso = session.GetObjectByKey<Ingresso>(ingresso.Oid);
                ordine.Posizione = 10 * Ordine(session, ingresso);
                ordine.Accesso = ingresso.Tipologia == EnumTipologiaIngresso.Museo ? EnumAccesso.Visibile : EnumAccesso.Nascosto;
                ordine.Save();
            }
        }

        public int GetPosizione(Ingresso ingresso)
        {
            if (ingresso.Tipologia == EnumTipologiaIngresso.Sistema) return -1;

            foreach (OrdineIngresso item in this.OrdineIngressi)
            {
                if (item.Ingresso != null && item.Ingresso.Oid == ingresso.Oid)
                {
                    if (item.Accesso == EnumAccesso.Nascosto)
                        return -1;
                    else
                        return item.Posizione;
                }
            }

            try
            {
                MakeDefault(ingresso);
                OrdineIngressi.Reload();

                return GetPosizione(ingresso);
            }
            catch (Exception)
            {
                
            }

            return 0;
        }

        private static int Ordine(Session session, Ingresso ingresso)
        {
            using (XPCollection<Ingresso> all = new XPCollection<Ingresso>(session))
            {
                all.Sorting = new SortingCollection(new SortProperty[] { new SortProperty("Descrizione", DevExpress.Xpo.DB.SortingDirection.Ascending) });
                for (int i = 0; i < all.Count; i++)
                    if (all[i].Oid == ingresso.Oid)
                        return (i + 1);
            }

            return 0;
        }

        private static int Ordine(Session session, SoggettoEconomico soggetto)
        {
            using (XPCollection<SoggettoEconomico> all = new XPCollection<SoggettoEconomico>(session))
            {
                all.Sorting = new SortingCollection(new SortProperty[] { new SortProperty("RagioneSociale", DevExpress.Xpo.DB.SortingDirection.Ascending) });
                for (int i = 0; i < all.Count; i++)
                    if (all[i].Oid == soggetto.Oid)
                        return (i + 1);
            }

            return 0;
        }

        public int GetPosizione(Module.SoggettoEconomico soggetto)
        {
            foreach (OrdineIngresso item in this.OrdineIngressi)
            {
                if (item.SoggettoEconomico != null && item.SoggettoEconomico.Oid == soggetto.Oid)
                    return item.Posizione;
            }

            try
            {
                using (Session session = new Session())
                {
                    OrdineIngresso ordine = new OrdineIngresso(session);
                    ordine.Riferimento = session.GetObjectByKey<Ingresso>(this.Oid);
                    ordine.SoggettoEconomico = session.GetObjectByKey<SoggettoEconomico>(soggetto.Oid);
                    ordine.Posizione = 10 * Ordine(session, soggetto);
                    ordine.Accesso = EnumAccesso.Visibile;
                    ordine.Save();
                }

                OrdineIngressi.Reload();
            }
            catch (Exception)
            {

            }

            return 0;
        }
    }

}
