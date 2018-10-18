using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Threading;

namespace PreventWebServices
{
    public class RichiestaCalendario
    {
        private int m_ingresso;
        public int Ingresso
        {
            get { return m_ingresso; }
            set
            {
                m_ingresso = value;
            }
        }

        private DateTime m_dataInizio;
        public DateTime DataInizio
        {
            get { return m_dataInizio; }
            set
            {
                m_dataInizio = value;
            }
        }

        private DateTime m_dataFine;
        public DateTime DataFine
        {
            get { return m_dataFine; }
            set
            {
                m_dataFine = value;
            }
        }

        private string m_tipoRichiesta;
        public string TipoRichiesta
        {
            get { return m_tipoRichiesta; }
            set
            {
                m_tipoRichiesta = value;
            }
        }

        private int m_timeToLive;
        public int TimeToLive
        {
            get { return m_timeToLive; }
            set
            {
                m_timeToLive = value;
            }
        }        

        //private bool m_nuovaRichiesta;
        //public bool NuovaRichiesta
        //{
        //    get { return m_nuovaRichiesta; }
        //    set
        //    {
        //        m_nuovaRichiesta = value;
        //    }
        //}

        private bool m_risposta;
        public bool Risposta
        {
            get { return m_risposta; }
            set
            {
                m_risposta = value;
            }
        }

        private prevent.calendar.Parametri m_parametriXml;
        public prevent.calendar.Parametri ParametriXml
        {
            get { return m_parametriXml; }
            set
            {
                m_parametriXml = value;
            }
        }       

        internal bool Espandi(DateTime inizio, DateTime fine)
        {
            DateTime start = inizio.Date;
            DateTime end = fine.Date.AddDays(1);

            if (DataInizio < start)
            {
                start = DataInizio;
            }

            if (DataFine > end)
            {
                end = DataFine;
            }

            TimeSpan tempo = end - start;

            //Console.WriteLine("TEMPO: " + tempo.TotalDays);

            if (tempo.TotalDays <= 7)
            {
                DataInizio = start;
                DataFine = end;

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
