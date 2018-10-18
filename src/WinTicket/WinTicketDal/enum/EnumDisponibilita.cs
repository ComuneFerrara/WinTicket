using System;
using DevExpress.Xpo;
using System.ComponentModel;

namespace Musei.Module
{
    public enum EnumDisponibilita : int
    {
        DaControllare = 0,
        ControlloInCorso = 1,
        NonDisponibile = 2,
        Disponibile = 3,
        Errore = 4
    }
}
