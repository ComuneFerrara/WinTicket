using System;
using System.Collections.Generic;
using System.Text;

namespace WinTicketNext.CostruzionePercorso.GestionePrenotazione
{
    public class EventoNotificaScheduler : EventArgs
    {
        public PrenotazioneIngresso Prenotazione { get; set; }
        public int NumeroPersone { get; set; }
     
        public EventoNotificaScheduler(PrenotazioneIngresso prenotazione, int numeroPersone)
        {
            Prenotazione = prenotazione;
            NumeroPersone = numeroPersone;
        }

    }
}
