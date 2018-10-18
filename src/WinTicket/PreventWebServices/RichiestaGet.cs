using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace PreventWebServices
{
    public class RichiestaGet
    {
        public static prevent.verifica.Out UltimoErrore;

        public static prevent.get.Out MakeGet()
        {
            UltimoErrore = null;

            PreventWebServices.WebReferencePrevent.WSPreventService wsp = new PreventWebServices.WebReferencePrevent.WSPreventService();
            string risposta = string.Empty;

            try
            {
                Console.WriteLine("WS_URL: " + wsp.Url);
                risposta = wsp.book("WinTicket", WsConfig.Username, WsConfig.Password, "G", string.Empty);
            }
            catch (Exception ex)
            {
                UltimoErrore = new prevent.verifica.Out();
                UltimoErrore.DescrizioneErrore = string.Format("Risposta non corretta dal servizio remoto: {0}: {1}", ex.Source, ex.Message);
                UltimoErrore.ReturnCode = "998";

                risposta = string.Empty;
            }

            if (!string.IsNullOrEmpty(risposta))
            {
                Console.WriteLine(risposta);
                risposta = risposta.Replace("+01:00", string.Empty);
                risposta = risposta.Replace("+02:00", string.Empty);

                try
                {
                    if (!risposta.Contains("ReturnCode"))
                    {
                        MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(risposta));
                        XmlSerializer xml = new XmlSerializer(typeof(prevent.get.Out));
                        prevent.get.Out dati = (prevent.get.Out)xml.Deserialize(stream);

                        dati.MostraTipo = "0";

                        var mostra = new int[] { 277, 278, 279 };

                        foreach (var num in mostra) {
                            if (risposta.Contains(string.Format("<IdTipoBiglietto>{0}</IdTipoBiglietto>", num))) 
                                dati.MostraTipo = "1";
                        }

                        return dati;
                    }
                    else
                    {
                        // errore
                        MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(risposta));
                        XmlSerializer xml = new XmlSerializer(typeof(prevent.verifica.Out));
                        UltimoErrore = (prevent.verifica.Out)xml.Deserialize(stream);
                    }
                }
                catch (Exception ex)
                {
                    UltimoErrore = new prevent.verifica.Out();
                    UltimoErrore.DescrizioneErrore = String.Format("Risposta non corretta dal servizio remoto: {0} ({1})", (risposta.Length < 200 ? risposta : string.Empty), ex.Message);
                    UltimoErrore.ReturnCode = "999";
                }
            }

            return null;
        }
    }
}
