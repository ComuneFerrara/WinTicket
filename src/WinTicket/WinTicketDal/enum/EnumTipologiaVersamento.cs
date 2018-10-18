using System;
using DevExpress.Xpo;
using System.ComponentModel;

namespace Musei.Module
{
    public enum EnumTipologiaVersamento : int
    {
        Incasso_Contanti = 0,
        Incasso_Pos = 1,
        Versamento_AdAltriEnti = 2,
        Incasso_Contanti_AltriEnti = 3,
        FondoCassa_Versamento = 4,
        FondoCassa_Trattenuta = 5
    }
}
