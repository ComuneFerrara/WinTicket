using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Threading;

namespace PreventWebServices
{
    public class GestoreCalendario
    {
        public static object SyncRoot = new object();
        private static List<RisultatoCalendario> Elenco = new List<RisultatoCalendario>();
        private static List<RichiestaCalendario> ElencoRichiesteAttive = new List<RichiestaCalendario>();
        private static List<RichiestaCalendario> ElencoNuoveRichieste = new List<RichiestaCalendario>();
        private static List<RichiestaCalendario> ElencoRichiesteEvase = new List<RichiestaCalendario>();
        private static List<Exception> ErroriWeb = new List<Exception>();

        public static string TipoGS = "S";
        public static string TipoScuola = "AD";

        public static void Clear(string gruppo, string scuola, bool clearall)
        {
            TipoGS = gruppo;
            TipoScuola = scuola;

            if (clearall)
            {
                lock (SyncRoot)
                {
                    Elenco.Clear();
                    ElencoRichiesteAttive.Clear();
                    ElencoRichiesteEvase.Clear();
                    ElencoNuoveRichieste.Clear();
                }
            }
        }

        public static void ClearAltriIngressi(List<int> ingressi)
        {
            lock (SyncRoot)
            {
                Elenco.RemoveAll((e) => ingressi.IndexOf(e.Ingresso) < 0);
            }
        }

        private static RisultatoCalendario CercaRisultato(DateTime inizio, int ingresso)
        {
            lock (SyncRoot)
            {
                foreach (RisultatoCalendario risultato in Elenco)
                {
                    if (risultato.Ingresso == ingresso && risultato.DataOra == inizio)
                    {
                        return risultato;
                    }
                }

                return null;
            }
        }

        public static RisultatoCalendario GeneraRichiesta(DateTime inizio, int ingresso)
        {
            lock (SyncRoot)
            {
                RisultatoCalendario risultato = CercaRisultato(inizio, ingresso);

                if (risultato == null)
                {
                    AccodaRichiesta(inizio.Date, ingresso);
                    return null;
                }
                else
                {
                    return risultato;
                }
            }
        }

        private static void AccodaRichiesta(DateTime inizio, int ingresso)
        {
            lock (SyncRoot)
            {
                bool found = false;
                foreach (RichiestaCalendario richiestaCalendario in ElencoNuoveRichieste)
                {
                    if (richiestaCalendario.Ingresso == ingresso)
                    {
                        if (richiestaCalendario.Espandi(inizio, inizio))
                        {
                            //Console.WriteLine("Espando una richiesta {0} - {1}", richiestaCalendario.DataInizio, richiestaCalendario.DataFine);
                            found = true;
                            break;
                        }
                    }
                }
                if (!found)
                {
                    foreach (RichiestaCalendario richiestaCalendario in ElencoRichiesteEvase)
                    {
                        // richiesta già fatta ...
                        if (richiestaCalendario.Ingresso == ingresso && richiestaCalendario.DataFine >= inizio && richiestaCalendario.DataInizio <= inizio)
                            found = true;
                    }

                    if (!found)
                    {
                        foreach (RichiestaCalendario richiestaCalendario in ElencoRichiesteAttive)
                        {
                            if (richiestaCalendario.Ingresso == ingresso && richiestaCalendario.DataFine >= inizio && richiestaCalendario.DataInizio <= inizio)
                                found = true;
                        }

                        if (!found)
                        {
                            Console.WriteLine("Genero nuova richiesta {0}", inizio.Date);

                            RichiestaCalendario nuova = new RichiestaCalendario();
                            nuova.Ingresso = ingresso;
                            nuova.DataInizio = inizio.Date;
                            nuova.DataFine = inizio.Date.AddDays(1);
                            //nuova.NuovaRichiesta = true;
                            nuova.Risposta = false;
                            nuova.TipoRichiesta = TipoGS;

                            ElencoNuoveRichieste.Add(nuova);
                        }
                    }
                    //NuoveRichieste = true;
                }
            }
        }

        //private static volatile bool NuoveRichieste = false;

        private static void QueryRichieste()
        {
            for (int i = ElencoNuoveRichieste.Count - 1; i >= 0; i--)
            {
                RichiestaCalendario richiestaCalendario = ElencoNuoveRichieste[i];

                ElencoNuoveRichieste.RemoveAt(i);
                ElencoRichiesteAttive.Add(richiestaCalendario);

                prevent.calendar.Parametri parametri = new prevent.calendar.Parametri();

                parametri.DataInizio = richiestaCalendario.DataInizio;
                parametri.DataFine = richiestaCalendario.DataFine;
                parametri.TipoGS = richiestaCalendario.TipoRichiesta;
                parametri.IdSito = new string[1];
                parametri.IdSito[0] = richiestaCalendario.Ingresso.ToString();

                richiestaCalendario.ParametriXml = parametri;

                // attivo un thread che effettua la chiamata al web service
                ParameterizedThreadStart newThreadStart = new ParameterizedThreadStart(TaskAsincrono);
                Thread nuovo = new Thread(newThreadStart);
                nuovo.Start(richiestaCalendario);

                if (i > 0)
                    Thread.Sleep(300);
            }
        }

        private static string GetXmlRichiesta(prevent.calendar.Parametri parametri)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                XmlSerializer xml = new XmlSerializer(typeof(prevent.calendar.Parametri));
                xml.Serialize(stream, parametri, ns);

                string xmlstr = Encoding.UTF8.GetString(stream.ToArray());
                return xmlstr;
            }
        }

        private static void TaskAsincrono(object data)
        {
            RichiestaCalendario item = (RichiestaCalendario)data;

            try
            {
                Console.WriteLine("RICHIESTA: INIZIO: " + item.DataInizio);
                Console.WriteLine("RICHIESTA: FINE: " + item.DataFine);

                string richiesta = GetXmlRichiesta(item.ParametriXml);
                Console.WriteLine(richiesta);

                DateTime start = DateTime.Now;
                PreventWebServices.WebReferencePrevent.WSPreventService wsp = new PreventWebServices.WebReferencePrevent.WSPreventService();
                string risposta = wsp.calendar("WinTicket", WsConfig.Username, WsConfig.Password, richiesta);

                DateTime end = DateTime.Now;
                Console.WriteLine("START: " + start.ToLongTimeString());
                Console.WriteLine("END: " + end.ToLongTimeString());
                Console.WriteLine("DURATA: " + (end - start).TotalMilliseconds);

                //Console.WriteLine(risposta);

                MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(risposta));
                XmlSerializer xml = new XmlSerializer(typeof(prevent.calendar.Out));
                prevent.calendar.Out outrisposta = (prevent.calendar.Out)xml.Deserialize(stream);

                lock (SyncRoot)
                {

                    //for (int i = 0; i < outrisposta.SitoCalendario.Length; i++)
                    //{
                    //    for (int j = 0; j < outrisposta.SitoCalendario[i].Giornata.Length; j++)
                    //    {
                    //        for (int p = 0; p < outrisposta.SitoCalendario[i].Giornata[j].Periodo.Length; p++)
                    //        {
                    //            if (outrisposta.SitoCalendario[i].Giornata[j].Data.Day == 15)
                    //                Console.WriteLine("Disp: {0:d} {1}: {2}",
                    //                    outrisposta.SitoCalendario[i].Giornata[j].Data,
                    //                    outrisposta.SitoCalendario[i].Giornata[j].Periodo[p].Ora.Replace("00.0000+01:00", ""),
                    //                    outrisposta.SitoCalendario[i].Giornata[j].Periodo[p].Max);
                    //        }
                    //    }
                    //}

                    foreach (prevent.calendar.OutSitoCalendario outSitoCalendario in outrisposta.SitoCalendario)
                    {
                        int sito = int.Parse(outSitoCalendario.IdSito);
                        if (outSitoCalendario.Giornata == null) continue;

                        foreach (prevent.calendar.OutSitoCalendarioGiornata outSitoCalendarioGiornata in outSitoCalendario.Giornata)
                        {
                            if (outSitoCalendarioGiornata.Periodo == null) continue;

                            RisultatoCalendario infog = new RisultatoCalendario();
                            infog.Ingresso = sito;
                            infog.InfoGiornata = outSitoCalendarioGiornata.Note;
                            infog.PostiDisponibili = 0;
                            infog.MaxPostiDisponibili = 0;
                            infog.DataOra = outSitoCalendarioGiornata.Data;

                            AggiornaEdInserisci(infog);

                            foreach (prevent.calendar.OutSitoCalendarioGiornataPeriodo outSitoCalendarioGiornataPeriodo in outSitoCalendarioGiornata.Periodo)
                            {
                                RisultatoCalendario risultato = new RisultatoCalendario();
                                risultato.Ingresso = sito;
                                risultato.InfoGiornata = outSitoCalendarioGiornata.Note;
                                risultato.PostiDisponibili = int.Parse(outSitoCalendarioGiornataPeriodo.Disponibili);
                                risultato.MaxPostiDisponibili = int.Parse(outSitoCalendarioGiornataPeriodo.Max);
                                risultato.DataOra = outSitoCalendarioGiornata.Data;

                                string ora = outSitoCalendarioGiornataPeriodo.Ora.Substring(0, 2);
                                string minuti = outSitoCalendarioGiornataPeriodo.Ora.Substring(3, 2);
                                risultato.DataOra = risultato.DataOra.AddMinutes(int.Parse(minuti));
                                risultato.DataOra = risultato.DataOra.AddHours(int.Parse(ora));

                                AggiornaEdInserisci(risultato);
                            }
                        }
                    }

                    ElencoRichiesteAttive.Remove(item);
                    ElencoRichiesteEvase.Add(item);

                    NewData = true;
                }
            }
            catch (Exception ex)
            {
                // eseguo di nuovo se ho avuto dei problemi...
                //item.NuovaRichiesta = true;

                Console.Write(ex.Message);

                lock (SyncRoot)
                {
                    ErroriWeb.Add(ex);

                    item.TimeToLive++;
                    ElencoRichiesteAttive.Remove(item);
                    if (item.TimeToLive < 4)
                        ElencoNuoveRichieste.Add(item);
                    else
                    {
                        // log errore Prevent
                    }
                }
            }
        }

        private static volatile bool NewData = false;

        public static void Dump()
        {
            lock (SyncRoot)
            {
                QueryRichieste();
            }
        }

        public static bool Dump(ref TaskCalendarioInfo info)
        {
            bool result = false;

            lock (SyncRoot)
            {
                info.ElencoNuoveRichieste = ElencoNuoveRichieste.Count;
                info.ElencoRichiesteAttive = ElencoRichiesteAttive.Count;
                info.ElencoRichiesteEvase = ElencoRichiesteEvase.Count;
                info.ErroriWeb = ErroriWeb.ToArray();

                ErroriWeb.Clear();

                QueryRichieste();

                result = NewData;
                NewData = false;
            }

            return result;
        }

        private static void AggiornaEdInserisci(RisultatoCalendario risultato)
        {
            bool found = false;
            foreach (RisultatoCalendario risultatoCalendario in Elenco)
            {
                if (risultatoCalendario.Ingresso == risultato.Ingresso && risultatoCalendario.DataOra == risultato.DataOra)
                {
                    risultatoCalendario.MaxPostiDisponibili = risultatoCalendario.MaxPostiDisponibili;
                    risultatoCalendario.PostiDisponibili = risultato.PostiDisponibili;
                    risultatoCalendario.InfoGiornata = risultato.InfoGiornata;
                    found = true;
                }
            }
            if (!found)
                Elenco.Add(risultato);
        }

        public static int GetTimeSpan()
        {
            int[] deltaq = new int[100];

            lock (SyncRoot)
            {
                foreach (RisultatoCalendario r1 in Elenco)
                {
                    foreach (RisultatoCalendario r2 in Elenco)
                    {
                        if (r1.Ingresso == r2.Ingresso)
                        {
                            TimeSpan delta = r2.DataOra - r1.DataOra;
                            delta = delta.Duration();

                            if (delta.TotalMinutes != 0 && delta.TotalMinutes < 99)
                                deltaq[(int)delta.TotalMinutes]++;
                        }
                    }
                }
            }

            int timespan = 30;
            for (int i = 1; i < deltaq.Length; i++)
            {
                if (deltaq[i] > 0)
                    timespan = gcd(timespan, i);
            }

            return Math.Max(5, timespan);
        }

        public static int GetTimeSpan(int ingresso)
        {
            int[] deltaq = new int[100];

            lock (SyncRoot)
            {
                foreach (RisultatoCalendario r1 in Elenco)
                {
                    if (r1.Ingresso != ingresso) continue;

                    foreach (RisultatoCalendario r2 in Elenco)
                    {
                        if (r1.Ingresso == r2.Ingresso)
                        {
                            TimeSpan delta = r2.DataOra - r1.DataOra;
                            delta = delta.Duration();

                            if (delta.TotalMinutes != 0 && delta.TotalMinutes < 99)
                                deltaq[(int)delta.TotalMinutes]++;
                        }
                    }
                }
            }

            int timespan = 30;
            for (int i = 1; i < deltaq.Length; i++)
            {
                if (deltaq[i] > 0)
                    timespan = gcd(timespan, i);
            }

            return Math.Max(5, timespan);
        }

        private static int gcd(int a, int b)
        {
            if (a == 1 || b == 1 || a == b)
            {
                return a;
            }
            else if (a > b)
            {
                return gcd(a - b, b);
            }
            else
            {
                return gcd(b, b - a);
            }
        }

        public static int RichiesteInCoda()
        {
            lock (SyncRoot)
            {
                return ElencoRichiesteAttive.Count;
            }
        }

        public static int Capacita(int ingresso, DateTime doinizio)
        {
            int cap = int.MaxValue;
            lock (SyncRoot)
            {
                foreach (RisultatoCalendario r1 in Elenco)
                {
                    if (r1.Ingresso == ingresso && r1.DataOra.Date == doinizio.Date)
                    {
                        if (r1.MaxPostiDisponibili < cap && r1.MaxPostiDisponibili > 0)
                            cap = r1.MaxPostiDisponibili;
                    }
                }

                if (cap == int.MaxValue)
                {
                    foreach (RisultatoCalendario r1 in Elenco)
                    {
                        if (r1.Ingresso == ingresso)
                        {
                            if (r1.MaxPostiDisponibili < cap && r1.MaxPostiDisponibili > 0)
                                cap = r1.MaxPostiDisponibili;
                        }
                    }
                }

                if (cap == int.MaxValue)
                    throw new Exception("emtpy set");
            }

            return cap;
        }
    }
}
