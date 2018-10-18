using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Threading;
using prevent;

namespace PreventWebServices
{
    public class VerificaDisponibilita
    {
        public static object SyncRoot = new object();

        private static List<RichiestaVerifica> Elenco = new List<RichiestaVerifica>();

        public static void Verifica(prevent.verifica.Parametri parametri, Guid richiesta, PreventWebServices.RichiestaVerifica.ObjCallback funzione)
        {
            RichiestaVerifica item = new RichiestaVerifica();
            item.IdRichiesta = richiesta;
            item.Parametri = parametri;
            item.XmlRichiesta = GetXmlRichiesta(parametri);
            item.FunzioneDaChiamare = funzione;

            lock (SyncRoot)
            {
                for (int i = Elenco.Count - 1; i >= 0; i--)
                {
                    RichiestaVerifica richiestaVerifica = Elenco[i];

                    TimeSpan tempo = DateTime.Now - richiestaVerifica.DataRisposta;
                    if (tempo.TotalSeconds < 30)
                    {
                        if (richiestaVerifica.XmlRichiesta == item.XmlRichiesta)
                        {
                            item.CodiceErrore = richiestaVerifica.CodiceErrore;
                            item.XmlRisposta = richiestaVerifica.XmlRisposta;
                            item.DataRisposta = richiestaVerifica.DataRisposta;
                            item.Disponibile = richiestaVerifica.Disponibile;
                        }
                    }
                    else
                        Elenco.Remove(richiestaVerifica);
                }
            }

            if (!string.IsNullOrEmpty(item.XmlRisposta))
            {
                // ok trovato nella cache
                item.FunzioneDaChiamare(item);
            }
            else
            {
                // attivo un thread che effettua la chiamata
                ParameterizedThreadStart newThreadStart = new ParameterizedThreadStart(TaskAsincrono);
                Thread nuovo = new Thread(newThreadStart);
                nuovo.Start(item);
            }
        }

        private static string GetXmlRichiesta(prevent.verifica.Parametri parametri)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                XmlSerializer xml = new XmlSerializer(typeof(prevent.verifica.Parametri));
                xml.Serialize(stream, parametri, ns);

                string xmlstr = Encoding.UTF8.GetString(stream.ToArray());
                return xmlstr;
            }
        }

        private static void TaskAsincrono(object data)
        {
            RichiestaVerifica item = (RichiestaVerifica)data;

            try
            {
                PreventWebServices.WebReferencePrevent.WSPreventService wsp = new PreventWebServices.WebReferencePrevent.WSPreventService();
                item.XmlRisposta = wsp.book("WinTicket", WsConfig.Username, WsConfig.Password, "V", item.XmlRichiesta);
                //item.XmlRisposta = wsp.book("WinTicket", "Luca", "3292285430", "V", item.XmlRichiesta);
                item.DataRisposta = DateTime.Now;

                Console.WriteLine(item.XmlRichiesta);
                Console.WriteLine(item.XmlRisposta);

                MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(item.XmlRisposta));
                XmlSerializer xml = new XmlSerializer(typeof(prevent.verifica.Out));
                prevent.verifica.Out risposta = (prevent.verifica.Out)xml.Deserialize(stream);

                item.CodiceErrore = risposta.DescrizioneErrore;
                if (risposta.ReturnCode == "00")
                    item.Disponibile = true;
                else
                    item.Disponibile = false;
            }
            catch (Exception ex)
            {
                item.CodiceErrore = ex.Message;
                item.XmlRisposta = string.Empty;
                item.DataRisposta = DateTime.Now;
                item.Disponibile = false;
            }

            lock (SyncRoot)
            {
                Elenco.Add(item);
            }
        }

        public static void GeneraEventi()
        {
            lock (SyncRoot)
            {
                foreach (RichiestaVerifica richiestaVerifica in Elenco)
                {
                    if (!richiestaVerifica.FunzioneChiamata)
                    {
                        richiestaVerifica.FunzioneDaChiamare(richiestaVerifica);
                        richiestaVerifica.FunzioneChiamata = true;
                    }
                }
            }
        }
    }
}
