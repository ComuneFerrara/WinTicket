using System;
using System.Collections.Generic;
using Musei.Module;
using PreventWebServices;

namespace WinTicketNext.CostruzionePercorso.GestionePrenotazione
{
    public class PrenotazioneIngresso
    {
        public Ingresso Ingresso { get; set; }
        public int NumeroPersone { get; set; }
        public List<SingolaPrenotazione> Prenotazioni { get; set; }

        public bool Attivo
        {
            get { return Prenotazioni.Count > 0; }
        }

        public bool ForzaturaPrevent { get; set; }        
    
        public PrenotazioneIngresso(Ingresso ingresso, int persone)
        {
            Prenotazioni = new List<SingolaPrenotazione>();

            Ingresso = ingresso;
            NumeroPersone = persone;
        }

        public void Init(DevExpress.Xpo.XPCollection xPCollection, DateTime inizio, string tipoGS)
        {
            if (ForzaturaPrevent)
                return;

            RisultatoCalendario risultato = GestoreCalendario.GeneraRichiesta(inizio, Ingresso.CodicePrevent);
            if (risultato == null)
                return;

            int ingressoCapacitaSlot = risultato.MaxPostiDisponibili;
            if (ingressoCapacitaSlot <= 0)
                ingressoCapacitaSlot = NumeroPersone;

            //int durataSlot = Ingresso.DurataSlot(tipoGS);
            int durataSlot = GestoreCalendario.GetTimeSpan(Ingresso.CodicePrevent);

            DateTime origine = inizio;

            int slot = NumeroPersone / ingressoCapacitaSlot;
            int resto = NumeroPersone - ingressoCapacitaSlot * slot;
            if (resto > 0)
                slot++;
            int media = NumeroPersone / slot;
            resto = NumeroPersone - media * slot;

            int persone = NumeroPersone;
            List<SingolaPrenotazione> ListaTemp = new List<SingolaPrenotazione>();
            while (persone > 0)
            {
                while (Occupato(xPCollection, inizio, durataSlot) || risultato == null)
                {
                    inizio += new TimeSpan(0, durataSlot, 0);
                    risultato = GestoreCalendario.GeneraRichiesta(inizio, Ingresso.CodicePrevent);
                    TimeSpan tempo = inizio - origine;
                    if (tempo.TotalDays > 3)
                        return;
                }

                int nump = media;
                if (persone >= media)
                {
                    if (resto > 0 && risultato.MaxPostiDisponibili > media)
                    {
                        nump++;
                        resto--;
                    }
                }
                else
                    nump = resto;

                SingolaPrenotazione pre = new SingolaPrenotazione();

                pre.NumeroPersone = nump;
                pre.Orario = inizio;
                pre.OrarioFine = inizio + new TimeSpan(0, durataSlot, 0);
                pre.Descrizione = PrenotazioneComplessiva.RiferimentoGlobale;
                pre.OriginataPrevent = false;

                ListaTemp.Add(pre);

                persone -= nump;

                inizio += new TimeSpan(0, durataSlot, 0);
                risultato = GestoreCalendario.GeneraRichiesta(inizio, Ingresso.CodicePrevent);
            }

            if (persone == 0)
                Prenotazioni = ListaTemp;
        }

        private static bool Occupato(DevExpress.Xpo.XPCollection xPCollection, DateTime inizio, int durataSlot)
        {
            DateTime fine = inizio + new TimeSpan(0, durataSlot, 0);
            foreach (Prenotazione item in xPCollection)
            {
                if (inizio >= item.StartDate && item.EndDate > inizio)
                    return true;

                if (fine >= item.StartDate && item.EndDate > fine)
                    return true;
            }
            return false;
        }

        internal bool PaxErrati()
        {
            int numero = 0;
            foreach (SingolaPrenotazione singolaPrenotazione in this.Prenotazioni)
            {
                numero += singolaPrenotazione.NumeroPersone;
            }

            if (numero != NumeroPersone)
                return true;
            else
                return false;
        }

        internal int SlotMaggiore()
        {
            int pos = 0;
            for (int i = 0; i < this.Prenotazioni.Count; i++)
            {
                if (this.Prenotazioni[i].NumeroPersone > this.Prenotazioni[pos].NumeroPersone)
                    pos = i;
            }

            return pos;
        }

        internal int SlotMinore()
        {
            int pos = 0;
            for (int i = 0; i < this.Prenotazioni.Count; i++)
            {
                if (this.Prenotazioni[i].NumeroPersone < this.Prenotazioni[pos].NumeroPersone)
                    pos = i;
            }

            return pos;
        }
    }
}
