using System;
using DevExpress.Xpo;
using System.ComponentModel;

namespace Musei.Module
{
    public enum EnumTipoMessaggio : int
    {
        None = 0,
        SyncError = 1,
        SyncDelay = 2,
        Ristampa = 3,
        Eliminazione = 4,
        EliminazioneConPrenotazione = 5,
        MessaggioInformativo = 6,
        EntrataPosticipata = 7,
        RecuperoEntrataPosticipata = 8
    }
}
