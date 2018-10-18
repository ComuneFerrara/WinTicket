using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Threading;
using prevent;

namespace PreventWebServices
{
    public class PrenotazioneFinale
    {
        private static string GetXmlRichiesta(prevent.prenotazione.Parametri parametri)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                XmlSerializer xml = new XmlSerializer(typeof(prevent.prenotazione.Parametri));
                xml.Serialize(stream, parametri, ns);

                string xmlstr = Encoding.UTF8.GetString(stream.ToArray());
                return xmlstr;
            }
        }

        private static string GetXmlRichiesta(prevent.update.Parametri parametri)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                XmlSerializer xml = new XmlSerializer(typeof(prevent.update.Parametri));
                xml.Serialize(stream, parametri, ns);

                string xmlstr = Encoding.UTF8.GetString(stream.ToArray());
                return xmlstr;
            }
        }

        public static prevent.verifica.Out UltimoErrore;

        public static bool Prenota(prevent.prenotazione.Parametri parametri, prevent.get.Out vecchiaprenotazione)
        {
            UltimoErrore = null;
            PreventWebServices.WebReferencePrevent.WSPreventService wsp = new PreventWebServices.WebReferencePrevent.WSPreventService();
            string richiesta = GetXmlRichiesta(parametri);
            if (vecchiaprenotazione != null)
            {
                richiesta = GetXmlRichiesta(CreaUpdate(parametri, vecchiaprenotazione));
            }
            string risposta = string.Empty;

            try
            {
                if (vecchiaprenotazione != null)
                    risposta = wsp.book("WinTicket", WsConfig.Username, WsConfig.Password, "U", richiesta);
                else
                    risposta = wsp.book("WinTicket", WsConfig.Username, WsConfig.Password, "P", richiesta);
            }
            catch (Exception)
            {
                risposta = string.Empty;
            }

            Console.WriteLine(richiesta);
            Console.WriteLine(risposta);

            parametri.CodiceTransWinTicket = string.Empty;

            if (risposta.Contains(@"ReturnCode=""00"""))
            {
                if (vecchiaprenotazione != null)
                {
                    parametri.CodiceTransWinTicket = vecchiaprenotazione.NumeroPrenotazione;
                }
                else
                {
                    int len1 = @"<NumeroPrenotazione>".Length;
                    int pos1 = risposta.IndexOf(@"<NumeroPrenotazione>");
                    int pos2 = risposta.IndexOf(@"</NumeroPrenotazione>");

                    parametri.CodiceTransWinTicket = risposta.Substring(pos1 + len1, pos2 - pos1 - len1);

                    Console.WriteLine(String.Format("PRENOTAZIONE:[{0}]", parametri.CodiceTransWinTicket));
                }

                return true;
            }
            else
            {
                if (!string.IsNullOrEmpty(risposta))
                {
                    // errore
                    MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(risposta));
                    XmlSerializer xml = new XmlSerializer(typeof(prevent.verifica.Out));
                    UltimoErrore = (prevent.verifica.Out)xml.Deserialize(stream);
                }

                return false;
            }
        }

        private static prevent.update.Parametri CreaUpdate(prevent.prenotazione.Parametri parametri, prevent.get.Out vecchiaprenotazione)
        {
            prevent.update.Parametri nuovo = new prevent.update.Parametri();

            nuovo.CodiceTransWinTicket = parametri.CodiceTransWinTicket;
            nuovo.Denominazione = parametri.Denominazione;
            nuovo.NumeroPrenotazione = vecchiaprenotazione.NumeroPrenotazione;
            nuovo.PaxTotali = parametri.PaxTotali;
            nuovo.RigaBiglietti = new prevent.update.ParametriRigaBiglietti[parametri.RigaBiglietti.Length];
            nuovo.RigaPercorsoVisita = new prevent.update.ParametriRigaPercorsoVisita[parametri.RigaPercorsoVisita.Length];

            for (int i = 0; i < parametri.RigaBiglietti.Length; i++)
            {
                nuovo.RigaBiglietti[i] = new prevent.update.ParametriRigaBiglietti();
                nuovo.RigaBiglietti[i].IdTipoBiglietto = parametri.RigaBiglietti[i].IdTipoBiglietto;
                nuovo.RigaBiglietti[i].Quantita = parametri.RigaBiglietti[i].Quantita;
            }

            for (int i = 0; i < parametri.RigaPercorsoVisita.Length; i++)
            {
                nuovo.RigaPercorsoVisita[i] = new prevent.update.ParametriRigaPercorsoVisita();
                nuovo.RigaPercorsoVisita[i].DataVisita = parametri.RigaPercorsoVisita[i].DataVisita;
                nuovo.RigaPercorsoVisita[i].IdMostra = parametri.RigaPercorsoVisita[i].IdMostra;
                nuovo.RigaPercorsoVisita[i].OraVisita = parametri.RigaPercorsoVisita[i].OraVisita;
                nuovo.RigaPercorsoVisita[i].PaxVisita = parametri.RigaPercorsoVisita[i].PaxVisita;
            }

            nuovo.TipoGS = parametri.TipoGS;
            nuovo.Scuola = parametri.Scuola;

            return nuovo;
        }
    }
}
