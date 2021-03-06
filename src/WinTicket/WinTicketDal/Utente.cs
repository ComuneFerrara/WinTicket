using System;
using DevExpress.Xpo;
using System.ComponentModel;
using System.Data;
using DevExpress.Data.Filtering;

namespace Musei.Module
{
    [DefaultProperty("Nome")]
    public class Utente : UserBase
    {
        private SoggettoEconomico m_SoggettoEconomico;
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

        private bool m_Amministratore;
        public bool Amministratore
        {
            get
            {
                return m_Amministratore;
            }
            set
            {
                SetPropertyValue("Amministratore", ref m_Amministratore, value);
            }
        }

        private string m_permessi;
        [Size(400)]
        public string Permessi
        {
            get
            {
                return m_permessi;
            }
            set
            {
                SetPropertyValue("Permessi", ref m_permessi, value);
            }
        }

        private DateTime m_LastLogon;
        public DateTime LastLogon
        {
            get
            {
                return m_LastLogon;
            }
            set
            {
                SetPropertyValue("LastLogon", ref m_LastLogon, value);
            }
        }

        private int m_ErroriPassword;
        public int ErroriPassword
        {
            get
            {
                return m_ErroriPassword;
            }
            set
            {
                SetPropertyValue("ErroriPassword", ref m_ErroriPassword, value);
            }
        }

        private DateTime m_LastLogonTry;
        public DateTime LastLogonTry
        {
            get
            {
                return m_LastLogonTry;
            }
            set
            {
                SetPropertyValue("LastLogonTry", ref m_LastLogonTry, value);
            }
        }

        public Utente(Session session) : base(session) { }

        public bool Bloccato(DateTime dateTime)
        {
            DateTime lasttry = LastLogonTry;
            if (lasttry.Year != dateTime.Year)
                lasttry = dateTime;

            TimeSpan elapsed = dateTime - lasttry;

            if (ErroriPassword > 3)
            {
                if (elapsed.TotalMinutes < 10)
                    return true;
            }

            if (ErroriPassword > 100)
                return true;

            return false;
        }

        public bool Autorizzato(string operazione)
        {
            if (string.IsNullOrEmpty(Permessi))
                return false;
            else
                return Permessi.Contains(operazione);
        }

        public XPCollection<Postazione> GetMioElencoPostazioni(UnitOfWork uow, Postazione postazione)
        {
            XPCollection<Postazione> tutte = new XPCollection<Postazione>(uow, new BinaryOperator("Tipologia", EnumTipologiaPostazione.Attiva));
            tutte.Sorting = new SortingCollection(new SortProperty[] { new SortProperty("CodiceUnivoco", DevExpress.Xpo.DB.SortingDirection.Ascending) });

            if (Amministratore)
                return tutte;
            else
            {
                if (Autorizzato(OperazioneRiepiloghi))
                {
                    // utente amministratrivo
                    // elenco postazioni formato da tutte le POSTAZIONI che hanno lo stesso SOGGETTOECONOMICO dell'utente attuale

                    XPCollection<Postazione> soggetto = new XPCollection<Postazione>(uow);
                    soggetto.Criteria = new GroupOperator(GroupOperatorType.Or);
                    soggetto.Sorting = new SortingCollection(new SortProperty[] { new SortProperty("CodiceUnivoco", DevExpress.Xpo.DB.SortingDirection.Ascending) });

                    foreach (Postazione item in tutte)
                    {
                        if (item.Struttura.SoggettoEconomico.Oid == this.SoggettoEconomico.Oid)
                            (soggetto.Criteria as GroupOperator).Operands.Add(new BinaryOperator("Oid", item.Oid));
                    }

                    return soggetto;
                }
                else
                {
                    // utente standard: 
                    // il mio elenco postazioni � composto da tutte le POSTAZIONI che hanno la stessa STRUTTURA della postazione in uso

                    XPCollection<Postazione> soggetto = new XPCollection<Postazione>(uow);
                    soggetto.Criteria = new GroupOperator(GroupOperatorType.Or);
                    soggetto.Sorting = new SortingCollection(new SortProperty[] { new SortProperty("CodiceUnivoco", DevExpress.Xpo.DB.SortingDirection.Ascending) });

                    foreach (Postazione item in tutte)
                    {
                        if (item.Struttura.Oid == postazione.Struttura.Oid)
                            (soggetto.Criteria as GroupOperator).Operands.Add(new BinaryOperator("Oid", item.Oid));
                    }

                    return soggetto;
                }
            }
        }

        public XPCollection<Ingresso> GetMioElencoIngressi(UnitOfWork uow, Postazione postazione)
        {
            XPCollection<Ingresso> tutte = new XPCollection<Ingresso>(uow);
            tutte.Sorting = new SortingCollection(new SortProperty[] { new SortProperty("Descrizione", DevExpress.Xpo.DB.SortingDirection.Ascending) });

            if (Amministratore)
                return tutte;
            else
            {
                if (Autorizzato(OperazioneRiepiloghi))
                {
                    XPCollection<Ingresso> soggetto = new XPCollection<Ingresso>(uow);
                    soggetto.Criteria = new GroupOperator(GroupOperatorType.Or);
                    soggetto.Sorting = new SortingCollection(new SortProperty[] { new SortProperty("Descrizione", DevExpress.Xpo.DB.SortingDirection.Ascending) });

                    foreach (Ingresso item in tutte)
                    {
                        if (item.SoggettoEconomico.Oid == this.SoggettoEconomico.Oid)
                            (soggetto.Criteria as GroupOperator).Operands.Add(new BinaryOperator("Oid", item.Oid));
                    }

                    if ((soggetto.Criteria as GroupOperator).Operands.Count == 0)
                        (soggetto.Criteria as GroupOperator).Operands.Add(new NullOperator("Oid"));

                    return soggetto;
                }
                else
                {
                    XPCollection<Ingresso> soggetto = new XPCollection<Ingresso>(uow);
                    soggetto.Criteria = new GroupOperator(GroupOperatorType.Or);
                    soggetto.Sorting = new SortingCollection(new SortProperty[] { new SortProperty("Descrizione", DevExpress.Xpo.DB.SortingDirection.Ascending) });

                    foreach (Ingresso item in tutte)
                    {
                        foreach (var ping in postazione.Ingressi)
                        {
                            if (item.Oid == ping.Ingresso.Oid)
                                (soggetto.Criteria as GroupOperator).Operands.Add(new BinaryOperator("Oid", item.Oid));
                        }
                    }

                    if ((soggetto.Criteria as GroupOperator).Operands.Count == 0)
                        (soggetto.Criteria as GroupOperator).Operands.Add(new NullOperator("Oid"));

                    return soggetto;
                }
            }
        }

        public XPCollection<Struttura> GetMioElencoStrutture(UnitOfWork uow, Postazione postazione)
        {
            if (Amministratore)
            {
                XPCollection<Struttura> tutte = new XPCollection<Struttura>(uow);
                tutte.Sorting = new SortingCollection(new SortProperty[] { new SortProperty("Descrizione", DevExpress.Xpo.DB.SortingDirection.Ascending) });

                return tutte;
            }
            else
            {
                if (Autorizzato(OperazioneRiepiloghi))
                {
                    XPCollection<Struttura> soggetto = new XPCollection<Struttura>(uow);
                    soggetto.Criteria = new BinaryOperator("SoggettoEconomico.Oid", SoggettoEconomico.Oid);
                    soggetto.Sorting = new SortingCollection(new SortProperty[] { new SortProperty("Descrizione", DevExpress.Xpo.DB.SortingDirection.Ascending) });

                    return soggetto;
                }
                else
                {
                    XPCollection<Struttura> soggetto = new XPCollection<Struttura>(uow);
                    soggetto.Criteria = new BinaryOperator("Oid", postazione.Ingresso.Struttura.Oid);
                    soggetto.Sorting = new SortingCollection(new SortProperty[] { new SortProperty("Descrizione", DevExpress.Xpo.DB.SortingDirection.Ascending) });

                    return soggetto;
                }
            }
        }


        //public const string OperazioneStampa = "[STAMPA]";
        //public const string OperazioneStampaPostadatata = "[STAMPARETRO]";
        public const string OperazioneRiepiloghi = "[STATS]";
        public const string OperazioneRiepiloghiGenerali = "[GENSTATS]";

    }

}
