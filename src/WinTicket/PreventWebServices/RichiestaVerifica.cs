using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Threading;

namespace PreventWebServices
{
    public class RichiestaVerifica
    {
        private prevent.verifica.Parametri m_parametri;
        public prevent.verifica.Parametri Parametri
        {
            get { return m_parametri; }
            set
            {
                m_parametri = value;
            }
        }

        private Guid m_idRichiesta;
        public Guid IdRichiesta
        {
            get { return m_idRichiesta; }
            set
            {
                m_idRichiesta = value;
            }
        }

        private string m_xmlRichiesta;
        public string XmlRichiesta
        {
            get { return m_xmlRichiesta; }
            set
            {
                m_xmlRichiesta = value;
            }
        }

        private string m_xmlRisposta;
        public string XmlRisposta
        {
            get { return m_xmlRisposta; }
            set
            {
                m_xmlRisposta = value;
            }
        }

        private DateTime m_dataRisposta;
        public DateTime DataRisposta
        {
            get { return m_dataRisposta; }
            set
            {
                m_dataRisposta = value;
            }
        }

        private bool m_disponibile;
        public bool Disponibile
        {
            get { return m_disponibile; }
            set
            {
                m_disponibile = value;
            }
        }

        private string m_codiceErrore;
        public string CodiceErrore
        {
            get { return m_codiceErrore; }
            set
            {
                m_codiceErrore = value;
            }
        }        

        public delegate void ObjCallback(RichiestaVerifica dato);
        public ObjCallback FunzioneDaChiamare;

        private bool m_funzioneChiamata;
        public bool FunzioneChiamata
        {
            get { return m_funzioneChiamata; }
            set
            {
                m_funzioneChiamata = value;
            }
        }
    }
}
