using System;

namespace PreventWebServices
{
    public class RisultatoCalendario
    {
        public DateTime DataOra { get; set; }
        public int Ingresso { get; set; }
        public int PostiDisponibili { get; set; }
        public int MaxPostiDisponibili { get; set; }
        public string InfoGiornata { get; set; }     
    }
}
