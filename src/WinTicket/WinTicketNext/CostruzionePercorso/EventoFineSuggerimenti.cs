using System;
using System.Collections.Generic;

namespace WinTicketNext.CostruzionePercorso
{
    public class EventoFineSuggerimenti : EventArgs
    {
        public OptimizationFactory OptFactory;
        public List<Suggerimento> ElencoSuggerimenti;

        public EventoFineSuggerimenti(OptimizationFactory opt, List<Suggerimento> elenco)
        {
            OptFactory = opt;
            ElencoSuggerimenti = elenco;
        }
    }
}
