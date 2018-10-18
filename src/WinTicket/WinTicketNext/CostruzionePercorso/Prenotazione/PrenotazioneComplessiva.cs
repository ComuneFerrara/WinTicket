using System;
using System.Collections.Generic;
using Musei.Module;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using PreventWebServices;

namespace WinTicketNext.CostruzionePercorso.GestionePrenotazione
{
    public class PrenotazioneComplessiva
    {
        public GestoreProfili GestoreProfili { get; set; }
        public List<PrenotazioneIngresso> Prenotazioni { get; set; }
        public prevent.get.Out PreventObj { get; set; }
        //public TaskGroup TaskGroup { get; set; }
        public string PrenotazionePrevent { get; set; }
        public string CodiceVendita { get; set; }
        public Vendita Vendita { get; set; }
        public DevExpress.Xpo.XPCollection CollectionPrenotazione { get; set; }

        public static string RiferimentoGlobale;
        private string m_RiferimentoVendita;
        public string RiferimentoVendita
        {
            get { return m_RiferimentoVendita; }
            set
            {
                m_RiferimentoVendita = value;
                RiferimentoGlobale = m_RiferimentoVendita;
            }
        }

        public PrenotazioneComplessiva(GestoreProfili profili)
        {
            GestoreProfili = profili;
            Prenotazioni = new List<PrenotazioneIngresso>();

            CodiceVendita = Vendita.NuovoCodiceVendita();
        }

        internal string TipoGS()
        {
            foreach (ProfiloCliente profilo in GestoreProfili.ElencoProfili)
            {
                if (profilo.SoluzionePreferita.ContieneGruppoOppureScuola())
                {
                    return "G";
                }                
            }

            return "S";
        }

        internal bool SoloProfiliSingoli()
        {
            foreach (ProfiloCliente profilo in GestoreProfili.ElencoProfili)
            {
                if (profilo.SoluzionePreferita.ContieneGruppoOppureScuola())
                {
                    return false;
                }
            }

            return true;
        }

        internal bool CardMusei()
        {
            foreach (ProfiloCliente profilo in GestoreProfili.ElencoProfili)
            {
                if (profilo.SoluzionePreferita.CardMusei())
                {
                    return true;
                }
            }

            return false;
        }

        internal string TipoScuola()
        {
            foreach (ProfiloCliente profilo in GestoreProfili.ElencoProfili)
            {
                if (profilo.Scuola)
                {
                    return "S";
                }
            }

            return "N";
        }


        public bool StampaSingolaPersona { get; set; }        

        //private bool fattoPrevent = false;
        private bool CreaSlotPrevent()
        {
            //string nomegruppo = "ABCDEFGHIJKLMNOPQRSTUWXYZ";

            if (PreventObj == null) return false;
            //if (fattoPrevent) return false;

            // costruisce la prenotazione prevent
            foreach (PrenotazioneIngresso prenotazioneIngresso in this.Prenotazioni)
            {
                if (Esiste(PreventObj, prenotazioneIngresso.Ingresso.CodicePrevent))
                {
                    prenotazioneIngresso.Prenotazioni.Clear();
                    prenotazioneIngresso.ForzaturaPrevent = true;
                    foreach (prevent.get.OutRigaPercorsoVisita item in PreventObj.RigaPercorsoVisita)
                    {
                        if (item.IdMostra == prenotazioneIngresso.Ingresso.CodicePrevent.ToString())
                        {
                            SingolaPrenotazione prenotazione = new SingolaPrenotazione();
                            prenotazione.NumeroPersone = int.Parse(item.PaxVisita);
                            prenotazione.Orario = item.DataVisita.Date + item.OraVisita.TimeOfDay;
                            prenotazione.OrarioFine = prenotazione.Orario + new TimeSpan(0, GestoreCalendario.GetTimeSpan(prenotazioneIngresso.Ingresso.CodicePrevent), 0);
                                //prenotazioneIngresso.Ingresso.DurataSlot(PreventObj.TipoGS), 0);
                                //new TimeSpan(0, prenotazioneIngresso.Ingresso.DurataSlot(PreventObj.TipoGS), 0);
                            prenotazione.OriginataPrevent = true;
                            prenotazione.OrarioPrevent = prenotazione.Orario;
                            prenotazione.Descrizione = RiferimentoVendita;
                                // "Squadra " + nomegruppo[prenotazioneIngresso.Prenotazioni.Count % nomegruppo.Length];

                            prenotazioneIngresso.Prenotazioni.Add(prenotazione);

                            //Console.WriteLine("Prenotazione " + prenotazione.Orario);
                        }
                    }
                }
            }

            //fattoPrevent = true;

            return true;
        }

        private static bool Esiste(prevent.get.Out infoPrevent, int idprevent)
        {
            string id = idprevent.ToString();
            foreach (prevent.get.OutRigaPercorsoVisita item in infoPrevent.RigaPercorsoVisita)
            {
                if (item.IdMostra == id)
                    return true;
            }
            return false;
        }

        public bool CreaProfiliPrevent()
        {
            if (PreventObj == null) return false;

            this.RiferimentoVendita = PreventObj.Denominazione;

            ProfiloCliente nuovo = this.GestoreProfili.ElencoProfili.AddNew();
            nuovo.NumeroPersone = int.Parse(PreventObj.PaxTotali);
            nuovo.Scuola = PreventObj.Scuola == "S" ? true : false;

            return true;
        }

        public List<Ingresso> CreaElencoPrevent(UnitOfWork unitOfWork)
        {
            List<Ingresso> elenco = new List<Ingresso>();

            if (PreventObj == null) return elenco;

            foreach (prevent.get.OutRigaPercorsoVisita outRigaPercorsoVisita in PreventObj.RigaPercorsoVisita)
            {
                if (outRigaPercorsoVisita.IdMostra == "240")
                {
                    if (PreventObj.MostraTipo == "1")
                        elenco.Add(
                            unitOfWork.FindObject<Ingresso>(new BinaryOperator("IntestazioneStampa", "CS"))
                        );
                    else
                        elenco.Add(
                            unitOfWork.FindObject<Ingresso>(new BinaryOperator("IntestazioneStampa", "C"))
                        );

                }
                else
                {
                    elenco.Add(
                        unitOfWork.FindObject<Ingresso>(new BinaryOperator("CodicePrevent", outRigaPercorsoVisita.IdMostra))
                    );
                }
            }

            return elenco;
        }

        public void CreaSlotPrevent(List<Ingresso> elenco)
        {
            InitRefreshPrenotazione(elenco);

            //this.Prenotazioni.Clear();
            //foreach (Ingresso ingresso in elenco)
            //{
            //    PrenotazioneIngresso prenotazioneIngresso = new PrenotazioneIngresso(ingresso,
            //        int.Parse(PreventObj.PaxTotali));
            //    this.Prenotazioni.Add(prenotazioneIngresso);                
            //}

            CreaSlotPrevent();
        }

        public bool PaxErrati()
        {
            int numeroGiusto = this.GestoreProfili.TotalePersone();
            foreach (PrenotazioneIngresso prenotazioneIngresso in this.Prenotazioni)
            {
                if (prenotazioneIngresso.Attivo)
                {
                    if (prenotazioneIngresso.NumeroPersone != numeroGiusto)
                        return true;

                    if (prenotazioneIngresso.PaxErrati())
                        return true;
                }
            }

            return false;
        }

        public void SistemaPrenotazione()
        {
            int numeroGiusto = this.GestoreProfili.TotalePersone();
            foreach (PrenotazioneIngresso prenotazioneIngresso in this.Prenotazioni)
            {
                if (prenotazioneIngresso.Attivo)
                {
                    prenotazioneIngresso.NumeroPersone = numeroGiusto;

                    int attuale = 0;
                    foreach (SingolaPrenotazione singolaPrenotazione in prenotazioneIngresso.Prenotazioni)
                    {
                        attuale += singolaPrenotazione.NumeroPersone;
                    }

                    if (attuale == numeroGiusto) continue;

                    DateTime doinizio = new DateTime(1900, 1, 1);
                    foreach (SingolaPrenotazione item in prenotazioneIngresso.Prenotazioni)
                    {
                        if (item.Orario > doinizio)
                            doinizio = item.Orario;
                    }

                    //int ingressoCapacitaSlot = prenotazioneIngresso.Ingresso.CapacitaSlot(TipoGS());
                    int ingressoCapacitaSlot = GestoreCalendario.Capacita(prenotazioneIngresso.Ingresso.CodicePrevent, doinizio);

                    //MessageBox.Show(ingressoCapacitaSlot.ToString());

                    int slot = numeroGiusto / ingressoCapacitaSlot;
                    int resto = numeroGiusto - ingressoCapacitaSlot * slot;
                    if (resto > 0)
                        slot++;
                    int media = numeroGiusto / slot;
                    resto = numeroGiusto - media * slot;

                    if (prenotazioneIngresso.Prenotazioni.Count < slot)
                    {
                        // creo i nuovi slot se sono necessari
                        DateTime inizio = new DateTime(1900,1,1);
                        int durataSlot = GestoreCalendario.GetTimeSpan(prenotazioneIngresso.Ingresso.CodicePrevent);
                        //int durataSlot = prenotazioneIngresso.Ingresso.DurataSlot(TipoGS());
                        //if (durataSlot == 0)
                        //    durataSlot = 60;

                        foreach (SingolaPrenotazione item in prenotazioneIngresso.Prenotazioni)
                        {
                            item.NumeroPersone = media;
                            if (item.Orario > inizio)
                                inizio = item.Orario;
                        }

                        inizio = inizio + new TimeSpan(0, durataSlot, 0);

                        for (int i = prenotazioneIngresso.Prenotazioni.Count; i < slot; i++)
                        {
                            SingolaPrenotazione nuova = new SingolaPrenotazione();

                            nuova.NumeroPersone = media;
                            nuova.Orario = inizio;
                            nuova.OrarioFine = inizio + new TimeSpan(0, durataSlot, 0);
                            nuova.Descrizione = PrenotazioneComplessiva.RiferimentoGlobale;
                            nuova.OriginataPrevent = !string.IsNullOrEmpty(this.PrenotazionePrevent);

                            prenotazioneIngresso.Prenotazioni.Add(nuova);

                            inizio = inizio + new TimeSpan(0, durataSlot, 0);
                        }

                        attuale = media * slot;
                    }
                    else if (prenotazioneIngresso.Prenotazioni.Count > slot)
                    {
                        // devo togliere degli slot ...
                        while (prenotazioneIngresso.Prenotazioni.Count > slot)
                        {
                            prenotazioneIngresso.Prenotazioni.Remove(prenotazioneIngresso.Prenotazioni[prenotazioneIngresso.Prenotazioni.Count - 1]);
                        }

                        foreach (SingolaPrenotazione item in prenotazioneIngresso.Prenotazioni)
                        {
                            item.NumeroPersone = media;
                        }

                        attuale = media * slot;
                    }

                    // raggiungo il numero corretto di persone
                    while (attuale != numeroGiusto)
                    {
                        if (attuale > numeroGiusto)
                        {
                            int pos = prenotazioneIngresso.SlotMaggiore();
                            prenotazioneIngresso.Prenotazioni[pos].NumeroPersone--;
                            attuale--;
                        }
                        else if (attuale < numeroGiusto)
                        {
                            int pos = prenotazioneIngresso.SlotMinore();
                            prenotazioneIngresso.Prenotazioni[pos].NumeroPersone++;
                            attuale++;
                        }
                    } 
                }
            }
        }

        public void InitRefreshPrenotazione(List<Ingresso> elenco)
        {
            // toglie tutte le prenotazioni relative ad ingressi che non esistono piu'
            // nell'elenco degli ingressi selezionati
            for (int i = this.Prenotazioni.Count - 1; i >= 0; i--)
            {
                bool found = false;
                foreach (Ingresso item in elenco)
                {
                    if (item.Oid == this.Prenotazioni[i].Ingresso.Oid)
                        found = true;
                }
                if (!found)
                    this.Prenotazioni.RemoveAt(i);
            }

            foreach (Ingresso item in elenco)
            {
                PrenotazioneIngresso newPrenotazioneIngresso = null;
                foreach (PrenotazioneIngresso prenotazioneIngresso in this.Prenotazioni)
                {
                    if (prenotazioneIngresso.Ingresso.Oid == item.Oid)
                        newPrenotazioneIngresso = prenotazioneIngresso;
                }
                if (newPrenotazioneIngresso == null)
                {
                    newPrenotazioneIngresso = new PrenotazioneIngresso(item, this.GestoreProfili.TotalePersone());
                    this.Prenotazioni.Add(newPrenotazioneIngresso);
                }
                else
                    newPrenotazioneIngresso.NumeroPersone = this.GestoreProfili.TotalePersone();
            }
        }

        public bool ConPrenotazione()
        {
            foreach (PrenotazioneIngresso prenotazioneIngresso in this.Prenotazioni)
            {
                if (prenotazioneIngresso.Attivo)
                    return true;
            }

            return false;
        }

        internal int NumeroTotalePrenotazioni()
        {
            int totale = 0;
            foreach (PrenotazioneIngresso prenotazioneIngresso in this.Prenotazioni)
            {
                totale += prenotazioneIngresso.Prenotazioni.Count;
            }
            return totale;
        }

        internal DateTime InizioPrenotazioni(DateTime inizio)
        {
            foreach (PrenotazioneIngresso prenotazioneIngresso in this.Prenotazioni)
            {
                foreach (SingolaPrenotazione item in prenotazioneIngresso.Prenotazioni)
                {
                    if (item.Orario < inizio)
                        inizio = item.Orario;
                }
            }

            return inizio;
        }

        internal DateTime FinePrenotazioni(DateTime fine)
        {
            foreach (PrenotazioneIngresso prenotazioneIngresso in this.Prenotazioni)
            {
                foreach (SingolaPrenotazione item in prenotazioneIngresso.Prenotazioni)
                {
                    if (item.Orario > fine)
                        fine = item.Orario;
                }
            }

            return fine;
        }


        internal int NumeroSlot()
        {
            int count = 0;
            foreach (PrenotazioneIngresso prenotazioneIngresso in this.Prenotazioni)
            {
                foreach (SingolaPrenotazione item in prenotazioneIngresso.Prenotazioni)
                {
                    count++;
                }
            }
            return count;
        }

        internal bool CardMyFE()
        {
            foreach (ProfiloCliente profilo in GestoreProfili.ElencoProfili)
            {
                if (profilo.SoluzionePreferita.CardMyFE())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
