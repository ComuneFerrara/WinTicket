using System;
using DevExpress.Xpo;
using System.ComponentModel;
using System.Collections.Generic;

namespace Musei.Module
{
    [DefaultProperty("Nome")]
    public class Postazione : MuseiBase
    {
        private string m_Nome;
        [Indexed(Unique=true)]
        public string Nome
        {
            get
            {
                return m_Nome;
            }
            set
            {
                SetPropertyValue("Nome", ref m_Nome, value);
            }
        }

        private Struttura _Struttura;
        [Association("Struttura-Postazioni")]
        public Struttura Struttura
        {
            get
            {
                return _Struttura;
            }
            set
            {
                SetPropertyValue("Struttura", ref _Struttura, value);
            }
        }

        private Ingresso m_Ingresso;
        public Ingresso Ingresso
        {
            get
            {
                return m_Ingresso;
            }
            set
            {
                SetPropertyValue("Ingresso", ref m_Ingresso, value);
            }
        }

        //private Ingresso m_IngressoVarcoUno;
        //public Ingresso IngressoVarcoUno
        //{
        //    get
        //    {
        //        return m_IngressoVarcoUno;
        //    }
        //    set
        //    {
        //        SetPropertyValue("IngressoVarcoUno", ref m_IngressoVarcoUno, value);
        //    }
        //}

        //private Ingresso m_IngressoVarcoDue;
        //public Ingresso IngressoVarcoDue
        //{
        //    get
        //    {
        //        return m_IngressoVarcoDue;
        //    }
        //    set
        //    {
        //        SetPropertyValue("IngressoVarcoDue", ref m_IngressoVarcoDue, value);
        //    }
        //}

        private int m_CodiceUnivoco;
        [Indexed(Unique=true)]
        public int CodiceUnivoco
        {
            get
            {
                return m_CodiceUnivoco;
            }
            set
            {
                SetPropertyValue("CodiceUnivoco", ref m_CodiceUnivoco, value);
            }
        }

        private string m_PrinterName;
        public string PrinterName
        {
            get
            {
                return m_PrinterName;
            }
            set
            {
                SetPropertyValue("PrinterName", ref m_PrinterName, value);
            }
        }

        private DateTime m_syncTry;
        public DateTime SyncTry
        {
            get
            {
                return m_syncTry;
            }
            set
            {
                SetPropertyValue("SyncTry", ref m_syncTry, value);
            }
        }

        private DateTime m_syncSuccess;
        public DateTime SyncSuccess
        {
            get
            {
                return m_syncSuccess;
            }
            set
            {
                SetPropertyValue("SyncSuccess", ref m_syncSuccess, value);
            }
        }

        private EnumSyncResult m_SyncResult;
        public EnumSyncResult SyncResult
        {
            get
            {
                return m_SyncResult;
            }
            set
            {
                SetPropertyValue("SyncResult", ref m_SyncResult, value);
            }
        }

        [NonPersistent]
        public DateTime LastUpdate
        {
            get
            {
                return SyncTry > SyncSuccess ? SyncTry : SyncSuccess;
            }
        }

        [NonPersistent]
        public int LastUpdateInt
        {
            get
            {
                if (Tipologia == EnumTipologiaPostazione.Attiva)
                {
                    TimeSpan tspan = DateTime.Now - LastUpdate;
                    return (int)tspan.TotalHours;
                }
                else return 0;
            }
        }

        private string DataFiga()
        {
            if (LastUpdate.Date == DateTime.Now.Date)
                return string.Format("oggi alle {0:t}", LastUpdate);
            else
                return string.Format("{0:f}", LastUpdate);
        }

        [NonPersistent]
        public string LastUpdateStr
        {
            get
            {
                TimeSpan tspan = DateTime.Now - LastUpdate;
                if (tspan.Days == 0 && tspan.Hours == 0)
                {
                    return string.Format("{0} minuti fa ({1:f})", tspan.Minutes, DataFiga());
                }
                else
                {
                    if (tspan.Days == 0)
                        return string.Format("{0} ore {1} minuti fa ({2:f})", tspan.Hours, tspan.Minutes, DataFiga());
                    else
                        return string.Format("{0} giorni e {1} ore fa ({2:f})", tspan.Days, tspan.Hours, DataFiga());
                }
            }
        }

        private int m_SyncEveryMinutes;
        public int SyncEveryMinutes
        {
            get
            {
                return m_SyncEveryMinutes;
            }
            set
            {
                SetPropertyValue("SyncEveryMinutes", ref m_SyncEveryMinutes, value);
            }
        }

        private string m_SoftwareVersion;
        public string SoftwareVersion
        {
            get
            {
                return m_SoftwareVersion;
            }
            set
            {
                SetPropertyValue("SoftwareVersion", ref m_SoftwareVersion, value);
            }
        }

        private string m_Opzioni;
        [Size(400)]
        public string Opzioni
        {
            get
            {
                return m_Opzioni;
            }
            set
            {
                SetPropertyValue("Opzioni", ref m_Opzioni, value);
            }
        }

        private string m_MachineName;
        public string MachineName
        {
            get
            {
                return m_MachineName;
            }
            set
            {
                SetPropertyValue("MachineName", ref m_MachineName, value);
            }
        }

        private string m_Telefono;
        public string Telefono
        {
            get
            {
                return m_Telefono;
            }
            set
            {
                SetPropertyValue("Telefono", ref m_Telefono, value);
            }
        }

        private EnumTipologiaPostazione _Tipologia;
        public EnumTipologiaPostazione Tipologia
        {
            get
            {
                return _Tipologia;
            }
            set
            {
                SetPropertyValue("Tipologia", ref _Tipologia, value);
            }
        }

        private EnumSyncMode _SyncMode;
        public EnumSyncMode SyncMode
        {
            get
            {
                return _SyncMode;
            }
            set
            {
                SetPropertyValue("SyncMode", ref _SyncMode, value);
            }
        }

        private string _Utente;
        public string Utente
        {
            get
            {
                return _Utente;
            }
            set
            {
                SetPropertyValue("Utente", ref _Utente, value);
            }
        }

        [Association("Postazione-Ingressi"), Aggregated]
        public XPCollection<PostazioneIngresso> Ingressi
        {
            get
            {
                return GetCollection<PostazioneIngresso>("Ingressi");
            }
        }

        public Postazione(Session session) : base(session) { }

        public bool Opzione(string operazione)
        {
            if (string.IsNullOrEmpty(Opzioni))
                return false;
            else
                return Opzioni.Contains(operazione);
        }

        public const string SoloContanti = "[CASHONLY]";

        private List<Ingresso> _Result;
        public List<Ingresso> IngressiControllatiDaAltrePostazioni()
        {
            if (_Result == null)
            {
                _Result = new List<Ingresso>();

                using (XPCollection<PostazioneIngresso> posta = new XPCollection<PostazioneIngresso>(this.Session))
                {
                    foreach (PostazioneIngresso postin in posta)
                    {
                        if (postin.Postazione.Oid != this.Oid && postin.Postazione.SyncMode == EnumSyncMode.Sync && !_Result.Contains(postin.Ingresso))
                            _Result.Add(postin.Ingresso);
                    }
                }
            }

            return _Result;
        }

        public static DateTime DataSicuroAggiornamento()
        {
            using (Session session = new Session())
            {
                using (XPCollection<Postazione> postazioni = new XPCollection<Postazione>(session))
                {
                    DateTime minabs = DateTime.MaxValue;
                    foreach (Postazione postazione in postazioni)
                    {
                        if (postazione.Tipologia == EnumTipologiaPostazione.Attiva)
                        {
                            DateTime minp = postazione.SyncSuccess > postazione.SyncTry ? postazione.SyncSuccess : postazione.SyncTry;
                            minabs = minp < minabs ? minp : minabs;
                        }
                    }

                    return minabs;
                }
            }            
        }
    }

}
