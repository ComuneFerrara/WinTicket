using System;
using System.Collections.Generic;
using System.Linq;

namespace WinTicketNext.Storico
{
    class GestioneApertureIngresso
    {
        public Guid Ingresso { get; set; }
        public List<DateTime> Aperture { get; private set; }

        public GestioneApertureIngresso(Guid ingresso)
        {
            Ingresso = ingresso;
            Aperture = new List<DateTime>();
        }

        internal void Add(DateTime data)
        {
            if (!Aperture.Contains(data))
                Aperture.Add(data);
        }

        internal bool Esiste(DateTime data)
        {
            return Aperture.Contains(data);
        }
    }
}
