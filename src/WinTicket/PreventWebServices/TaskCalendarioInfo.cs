using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Threading;

namespace PreventWebServices
{
    public class TaskCalendarioInfo
    {
        public int ElencoRichiesteAttive;
        public int ElencoNuoveRichieste;
        public int ElencoRichiesteEvase;

        public Exception[] ErroriWeb { get; set; }
    }
}
