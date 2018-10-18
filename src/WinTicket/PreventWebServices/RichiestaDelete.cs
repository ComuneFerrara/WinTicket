using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace PreventWebServices
{
    public class RichiestaDelete
    {
        public static prevent.verifica.Out UltimoErrore;

        public static prevent.verifica.Out MakeDelete(string codice)
        {
            UltimoErrore = null;

            PreventWebServices.WebReferencePrevent.WSPreventService wsp = new PreventWebServices.WebReferencePrevent.WSPreventService();
            string risposta = string.Empty;

            try
            {
                string richiesta = string.Format(@"<?xml version='1.0' encoding='utf-8'?><Parametri CodiceTransWinTicket=""{0}""></Parametri>", codice);

                Console.WriteLine("WS_URL: " + wsp.Url);

                risposta = wsp.delete("WinTicket", WsConfig.Username, WsConfig.Password, richiesta);
            }
            catch (Exception ex)
            {
                UltimoErrore = new prevent.verifica.Out();
                UltimoErrore.DescrizioneErrore = string.Format("Risposta non corretta dal servizio remoto: {0}: {1}", ex.Source, ex.Message);
                UltimoErrore.ReturnCode = "997";

                risposta = string.Empty;
            }

            if (!string.IsNullOrEmpty(risposta))
            {
                Console.WriteLine(risposta);

                try
                {
                    MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(risposta));
                    XmlSerializer xml = new XmlSerializer(typeof(prevent.verifica.Out));
                    prevent.verifica.Out dati = (prevent.verifica.Out)xml.Deserialize(stream);

                    if (dati.ReturnCode == "00" || dati.ReturnCode == "51" || dati.ReturnCode == "52")
                        return dati;
                    else
                        UltimoErrore = dati;
                }
                catch (Exception ex)
                {
                    UltimoErrore = new prevent.verifica.Out();
                    UltimoErrore.DescrizioneErrore = String.Format("Risposta non corretta dal servizio remoto: {0} ({1})", (risposta.Length < 200 ? risposta : string.Empty), ex.Message);
                    UltimoErrore.ReturnCode = "996";
                }
            }

            return null;
        }
    }
}
