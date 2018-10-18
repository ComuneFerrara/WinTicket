using System;
using DevExpress.Xpo;
using System.ComponentModel;

namespace Musei.Module
{
    public enum EnumTipologiaPostazione : int
    {
        Attiva = 0,         // normale
        NonAttiva = 1       // non può stampare
    }
}
