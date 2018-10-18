using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Musei.Module;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;

namespace ServerSide
{
    class Program
    {
        static void SendMsg(string subject, string body)
        {
            using (SmtpClient smtp = new SmtpClient("127.0.0.1", 25))
            {
                MailMessage msg = new MailMessage() { SubjectEncoding = Encoding.UTF8, BodyEncoding = Encoding.UTF8 };
                msg.Body = body;
                msg.Subject = subject;
                msg.From = new MailAddress("admin@qualitando.com", "winticket");
                msg.To.Add("poretti@xpsoft.it");

                smtp.Send(msg);
            }
        }

        static void Main(string[] args)
        {
            //DBSetup();

            //if (args.Length == 1 && args[0] == "RIDOTTO")
            //    TariffeCastelloRidotte();
            //else if (args.Length == 1 && args[0] == "STANDARD")
            //    TariffeCastelloStandard();
            //else SendMsg("Server Side - ERRORE NESSUN PARAMETRO", "Server Side - ERRORE NESSUN PARAMETRO");

            //return;

            try
            {
                if (ExitRequest()) return;

                DBSetup();


                //EliminaSchifanoia2018();
                //return;

                //PistolaVendite2018(); 
                
                //return;

                //Tariffe2016();

                Aperture();

                SendMsg("START - Server Side - WinTicket", "START - Server Side - WinTicket");

                // circa 8 ore
                for (int j = 0; j < 100; j++)
                {
                    Console.WriteLine("Processing ...");

                    GO();

                    Console.WriteLine("Spleeping ...");
                    for (int i = 0; i < 60; i++)
                    {
                        if (ExitRequest()) return;
                        Thread.Sleep(5000);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                SendMsg("Server Side - WinTicket", ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }


        private static void EliminaSchifanoia2018()
        {
            using (Session ses = new Session())
            {
                var dt = new DateTime(2018, 1, 1);
                
                var allv = new XPCollection<Variante>(ses);
                Console.WriteLine("Caricate {0} varianti", allv.Count);

                var cv = new XPCollection<Vendita>(ses, new BinaryOperator("DataContabile", new DateTime(2018, 1, 1), BinaryOperatorType.GreaterOrEqual));
                foreach (var v in cv)
                {

                    var t1 = v.RigheVenditaVariante.Where(a => a.Variante.Descrizione.Contains("Cumulativo"));
                    if (t1.Count() > 0)
                    {
                        Console.WriteLine("Cumulativo venduto il " + v.DataContabile + " v:" + v.CodiceLeggibile);

                        foreach (var rvv in v.RigheVenditaVariante)
                        {
                            Console.WriteLine(" " + rvv.Variante.Biglietto.Percorso.Descrizione);

                            if (v.DataContabile > dt && rvv.Variante.Biglietto.Percorso.Descrizione.Contains("OLD"))
                            {
                                var nv = allv.FirstOrDefault(a =>
                                    a.Biglietto.Percorso.Descrizione == "Cumulativo Musei d'Arte Antica e Museo della Cattedrale" &&
                                    a.TipologiaUno == rvv.Variante.TipologiaUno &&
                                    a.TipologiaDue == rvv.Variante.TipologiaDue &&
                                    a.TipologiaTre == rvv.Variante.TipologiaTre
                                    );

                                if (nv != null)
                                {
                                    Console.WriteLine(" Cambio con " + nv.Biglietto.Percorso.Descrizione);
                                    rvv.Variante = nv;
                                    rvv.Save();
                                }
                            }
                        }
                        
                    }

                }
            }
        }

        //private static void PistolaVendite2018()
        //{
        //    using (Session ses = new Session())
        //    {
        //        int c = 0;
        //        var biglietto = ses.FindObject<Biglietto>(new BinaryOperator("Descrizione", "Biglietto per Castello Estense: Museo"));

        //        var cv = new XPCollection<Vendita>(ses, new BinaryOperator("DataContabile", new DateTime(2018, 1, 1), BinaryOperatorType.GreaterOrEqual));
        //        foreach (var v in cv)
        //        {

        //            var t1 = v.RigheVenditaVariante.Where(a => a.Variante.Descrizione.Contains("Sgarbi")).Sum(a => a.Quantita);

        //            if (t1 > 0)
        //            {
        //                var t2 = v.RigheVenditaVariante.Where(a => a.Variante.Descrizione.Contains("Castello Estense: Museo")).Sum(a => a.Quantita);

        //                Console.WriteLine("c={0}, d={1}", c, v.DataContabile);

        //                if (t2 > 0) {
        //                    Console.WriteLine("t1 {0}, t2 {1}, v= {2}", t1, t2, v.CodiceLeggibile);
        //                    return;
        //                }

        //                foreach (var rvv in v.RigheVenditaVariante.Where(a => a.Variante.Descrizione.Contains("Sgarbi")).ToList())
        //                {
        //                    var riga = new RigaVenditaVariante(ses);
        //                    riga.PrezzoTotale = 0;
        //                    riga.PrezzoUnitario = 0;
        //                    riga.Quantita = rvv.Quantita;
        //                    riga.Vendita = v;
        //                    riga.Profilo = rvv.Profilo;
        //                    riga.Variante = biglietto.Varianti.FirstOrDefault(a => a.VenditaAbilitata && a.TipologiaDue == rvv.Variante.TipologiaDue && a.TipologiaTre == rvv.Variante.TipologiaTre && a.TipologiaUno == rvv.Variante.TipologiaUno);
        //                    riga.Titolo = rvv.Titolo;
        //                    //riga.CodiceSconto = null;
        //                    riga.Card = null;

        //                    if (riga.Variante == null)
        //                    {
        //                        Console.WriteLine("nessuna variante per {0}, {1}, {2}", rvv.Variante.TipologiaUno, rvv.Variante.TipologiaDue, rvv.Variante.TipologiaTre);
        //                        return;
        //                    }

        //                    riga.Save();                 
        //                    c += riga.Quantita;

        //                }

        //            }

        //        }
        //    }
        //}

        private static void TariffeCastelloStandard()
        {
            using (Session ses = new Session())
            {
                // INTERO
                var v1 = ses.GetObjectByKey<Importo>(Guid.Parse("007f31be-75be-4f05-8a16-4c71f08d6aa4"));
                v1.Prezzo = 8;
                v1.Save();

                // INTERO-V
                var v2 = ses.GetObjectByKey<Importo>(Guid.Parse("e1e902c4-3d12-477d-bd67-eaf3061bd43f"));
                v2.Prezzo = 7;
                v2.Save();

                // SINGOLO RIDOTTO
                var v3 = ses.GetObjectByKey<Importo>(Guid.Parse("72e1f1fe-3304-4476-8e5b-3f381e2e6e58"));
                v3.Prezzo = 6;
                v3.Save();

                // GRUPPO RIDOTTO
                var v4 = ses.GetObjectByKey<Importo>(Guid.Parse("f7f82a8d-2650-4083-b1d9-6f3b7f809bb0"));
                v4.Prezzo = 6;
                v4.Save();

                // SINGOLO RIDOTTO-V
                var v5 = ses.GetObjectByKey<Importo>(Guid.Parse("c4c05c8f-a935-4eea-bfae-d0abce3a0a0a"));
                v5.Prezzo = 5;
                v5.Save();

                // GRUPPO RIDOTTO-V
                var v6 = ses.GetObjectByKey<Importo>(Guid.Parse("72df332f-1030-40d4-984d-68bad4265167"));
                v6.Prezzo = 5;
                v6.Save();

            }

            SendMsg("Server Side: TariffeCastelloStandard", "Server Side: TariffeCastelloStandard");
        }

        private static void TariffeCastelloRidotte()
        {
            using (Session ses = new Session())
            {
                // INTERO
                var v1 = ses.GetObjectByKey<Importo>(Guid.Parse("007f31be-75be-4f05-8a16-4c71f08d6aa4"));
                v1.Prezzo = 6;
                v1.Save();

                // INTERO-V
                var v2 = ses.GetObjectByKey<Importo>(Guid.Parse("e1e902c4-3d12-477d-bd67-eaf3061bd43f"));
                v2.Prezzo = 5;
                v2.Save();

                // SINGOLO RIDOTTO
                var v3 = ses.GetObjectByKey<Importo>(Guid.Parse("72e1f1fe-3304-4476-8e5b-3f381e2e6e58"));
                v3.Prezzo = 4;
                v3.Save();

                // GRUPPO RIDOTTO
                var v4 = ses.GetObjectByKey<Importo>(Guid.Parse("f7f82a8d-2650-4083-b1d9-6f3b7f809bb0"));
                v4.Prezzo = 4;
                v4.Save();

                // SINGOLO RIDOTTO-V
                var v5 = ses.GetObjectByKey<Importo>(Guid.Parse("c4c05c8f-a935-4eea-bfae-d0abce3a0a0a"));
                v5.Prezzo = 3;
                v5.Save();

                // GRUPPO RIDOTTO-V
                var v6 = ses.GetObjectByKey<Importo>(Guid.Parse("72df332f-1030-40d4-984d-68bad4265167"));
                v6.Prezzo = 3;
                v6.Save();

            }

            SendMsg("Server Side: TariffeCastelloRidotte", "Server Side: TariffeCastelloRidotte");
        }

        //private static void Tariffe2016()
        //{
        //    try
        //    {
        //        if (DateTime.Today.Year < 2016)
        //        {
        //            SendMsg("Server Side - Tariffe2016", "non è ancora l'anno giusto :-)");
        //            return;
        //        }

        //        using (Session ses = new Session())
        //        {
        //            XPCollection<Importo> prices = new XPCollection<Importo>(ses);
        //            foreach (Importo var in prices)
        //            {
        //                if (var.UnaRiduzioneOgni == 10 && var.PrezzoRidotto != null)
        //                {
        //                    var.PrezzoRidotto.VenditaAbilitata = false;
        //                    var.PrezzoRidotto.Save();

        //                    var.PrezzoRidotto = null;
        //                    var.UnaRiduzioneOgni = 0;
        //                    var.Save();

        //                    SendMsg("Tariffe2016: Importo", "Importo (UnaRiduzioneOgni=0): " + var.Variante.Descrizione);
        //                }
        //            }

        //            XPCollection<Biglietto> variantes = new XPCollection<Biglietto>(ses);
        //            foreach (Biglietto var in variantes)
        //            {
        //                if (var.MinimoPerGruppo == 10)
        //                {
        //                    var.MinimoPerGruppo = 15;
        //                    var.Save();

        //                    SendMsg("Tariffe2016: Biglietto", "Biglietto (MinimoPerGruppo=15): " + var.Descrizione);
        //                }
        //            }

        //        }

        //        SendMsg("Server Side - Tariffe2016", "tariffe cambiate :-)");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);

        //        SendMsg("Server Side - Tariffe2016", ex.Message + Environment.NewLine + ex.StackTrace);
        //    }
        //}

        static void Aperture()
        {
            using (Session ses = new Session())
            {
                XPCollection<Postazione> tpost = new XPCollection<Postazione>(ses);

                DateTime dateValue = DateTime.Today;

                foreach (Postazione postazione in tpost)
                {
                    if (postazione.Opzione("[OPEN-"))
                    {
                        var str = String.Format("-{0}-", dateValue.ToString("ddd", new CultureInfo("it-IT")));

                        if (postazione.Opzione(str))
                        {
                            PostazioneAccesso access = ses.FindObject<PostazioneAccesso>(new GroupOperator(GroupOperatorType.And,
                                new CriteriaOperator[] { 
                                new BinaryOperator("Data", dateValue), 
                                new BinaryOperator("Postazione.Oid", postazione.Oid) }));

                            if (access == null)
                            {
                                access = new PostazioneAccesso(ses);
                                access.Postazione = postazione;
                                access.Data = dateValue;
                                access.Save();
                            }

                            postazione.SyncSuccess = DateTime.Now;
                            postazione.SyncResult = EnumSyncResult.Ok;
                            postazione.Save();
                        }
                    }
                }
            }
        }

        private static bool ExitRequest()
        {
            if (File.Exists("app_offline.htm")) return true;
            if (Console.KeyAvailable) return true;
            return false;
        }


        public static readonly string ticketUrl = @"http://ferrara.artacom.it/biglietteria/query/doQueryFromUrl.do?tipoOutput=4&cn=fecomune&userid=xxx&password=xxx&querytag=listaMyfecard&p_inizio={0:yyyy-MM-dd}&p_fine={1:yyyy-MM-dd}";
        static void GO()
        {
            List<MyFeData> elenco = DownloadData();

            List<MyFeData> elencoNuovi = new List<MyFeData>();

            using (Session session = new Session())
            {
                Utente utente = session.FindObject<Utente>(new BinaryOperator("AdUsername", "Internet"));
                MuseiBase.CurrentUser = utente;

                Postazione postazione = session.FindObject<Postazione>(new BinaryOperator("CodiceUnivoco", 1));
                postazione.Utente = utente.FullName;
                postazione.SyncSuccess = postazione.SyncTry = DateTime.Now;
                postazione.SyncResult = EnumSyncResult.Ok;
                postazione.Save();

                foreach (MyFeData myFeData in elenco)
                {
                    var trans = session.FindObject<TransazioneWeb>(new GroupOperator(GroupOperatorType.And,
                        new CriteriaOperator[] {
                            new BinaryOperator("Transazione", myFeData.Transazione),
                            new BinaryOperator("CodiceOperazione", myFeData.CodiceOperazione)
                        }));
                    if (trans == null)
                    {
                        elencoNuovi.Add(myFeData);
                    }
                }

                var mioelenco = elencoNuovi.OrderBy(m => m.InseritaIlDateTime).ToArray();
                List<string> log = new List<string>();

                foreach (MyFeData myFeData in mioelenco)
                {
                    if (myFeData.TipoOperazione == "vendita")
                    {
                        CreaVendita(myFeData);

                        string logitem = string.Format("Creata Vendita {0} del {1:g}", myFeData.CodiceTessera, myFeData.InseritaIlDateTime);
                        log.Add(logitem);
                        Console.WriteLine(logitem);
                    }

                    if (myFeData.TipoOperazione == "annullo")
                    {
                        AnnullaVendita(myFeData);

                        string logitem = string.Format("Annullata Vendita {0} del {1:g}", myFeData.CodiceTessera, myFeData.InseritaIlDateTime);
                        log.Add(logitem);
                        Console.WriteLine(logitem);
                    }
                }

                if (log.Count > 0)
                {
                    // send email

                }
            }
        }

        private static void AnnullaVendita(MyFeData myFeData)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Utente utente = uow.FindObject<Utente>(new BinaryOperator("AdUsername", "Internet"));
                Postazione postazione = uow.FindObject<Postazione>(new BinaryOperator("CodiceUnivoco", 1));

                if (utente == null)
                    throw new Exception("Manca utente INTERNET");

                if (postazione == null)
                    throw new Exception("Manca postazione INTERNET, CodiceUnivoco==1");

                var obj = uow.FindObject<Card>(new BinaryOperator("Codice", myFeData.CodiceTessera));
                if (obj == null)
                {
                    throw new Exception("ANNULLO: Manca card con codice: " + myFeData.CodiceTessera);
                }

                TransazioneWeb trans = new TransazioneWeb(uow);
                trans.PuntoVendita = myFeData.PuntoVendita;
                trans.Cliente = myFeData.Cliente;
                trans.EmailCliente = myFeData.EmailCliente;
                trans.IDCliente = myFeData.IDCliente;
                trans.Transazione = myFeData.Transazione;
                trans.InseritaIl = myFeData.InseritaIl;
                trans.TitolareCarta = myFeData.TitolareCarta;
                trans.EmailTitolare = myFeData.EmailTitolare;
                trans.Inizio = myFeData.Inizio;
                trans.Fine = myFeData.Fine;
                trans.Giorni = myFeData.Giorni;
                trans.Prodotto = myFeData.Prodotto;
                trans.CodiceOperazione = myFeData.CodiceOperazione;
                trans.CodiceTessera = myFeData.CodiceTessera;
                trans.TipoOperazione = myFeData.TipoOperazione;
                trans.Quantita = myFeData.Quantita;
                trans.InseritaIlDateTime = myFeData.InseritaIlDateTime;
                trans.InizioDateTime = myFeData.InizioDateTime;
                trans.FineDateTime = myFeData.FineDateTime;
                trans.Save();

                obj.Stampa.Vendita.EliminaVendita();
                obj.Delete();

                uow.CommitChanges();
            }
        }

        private static void CreaVendita(MyFeData myFeData)
        {
            //var aprile = new DateTime(2016, 4, 1);
            //if (myFeData.InseritaIlDateTime.Date >= aprile) return;

            using (UnitOfWork uow = new UnitOfWork())
            {
                Utente utente = uow.FindObject<Utente>(new BinaryOperator("AdUsername", "Internet"));
                Postazione postazione = uow.FindObject<Postazione>(new BinaryOperator("CodiceUnivoco", 1));

                if (utente == null)
                    throw new Exception("Manca utente INTERNET");

                if (postazione == null)
                    throw new Exception("Manca postazione INTERNET, CodiceUnivoco==1");

                var obj = uow.FindObject<Card>(new BinaryOperator("Codice", myFeData.CodiceTessera));
                if (obj != null)
                    throw new Exception("VENDITA: Esiste già card con codice: " + myFeData.CodiceTessera);

                TransazioneWeb trans = new TransazioneWeb(uow);
                trans.PuntoVendita = myFeData.PuntoVendita;
                trans.Cliente = myFeData.Cliente;
                trans.EmailCliente = myFeData.EmailCliente;
                trans.IDCliente = myFeData.IDCliente;
                trans.Transazione = myFeData.Transazione;
                trans.InseritaIl = myFeData.InseritaIl;
                trans.TitolareCarta = myFeData.TitolareCarta;
                trans.EmailTitolare = myFeData.EmailTitolare;
                trans.Inizio = myFeData.Inizio;
                trans.Fine = myFeData.Fine;
                trans.Giorni = myFeData.Giorni;
                trans.Prodotto = myFeData.Prodotto;
                trans.CodiceOperazione = myFeData.CodiceOperazione;
                trans.CodiceTessera = myFeData.CodiceTessera;
                trans.TipoOperazione = myFeData.TipoOperazione;
                trans.Quantita = myFeData.Quantita;
                trans.InseritaIlDateTime = myFeData.InseritaIlDateTime;
                trans.InizioDateTime = myFeData.InizioDateTime;
                trans.FineDateTime = myFeData.FineDateTime;
                trans.Save();

                Card card = new Card(uow);
                card.Codice = myFeData.CodiceTessera;
                card.AssegnataIl = myFeData.InseritaIlDateTime;
                card.AssegnataStruttura = postazione.Struttura;
                card.AssegnataUtente = utente;
                card.Status = EnumStatoCard.Emessa;
                card.Email = myFeData.EmailTitolare;
                card.Cliente = myFeData.Cliente;
                card.TitolareCarta = myFeData.TitolareCarta;
                card.CodiceOperazione = myFeData.CodiceOperazione;
                card.Transazione = myFeData.Transazione;
                card.VendutaOnline = true;
                card.EmessoBiglietto = false;

                switch (myFeData.Giorni)
                {
                    case "2":
                        card.TipologiaCard = EnumTipologiaCard.Card2Giorni;
                        break;
                    case "3":
                        card.TipologiaCard = EnumTipologiaCard.Card3Giorni;
                        break;
                    case "6":
                        card.TipologiaCard = EnumTipologiaCard.Card6Giorni;
                        break;
                }
                card.Save();

                Vendita vendita = new Vendita(uow);

                vendita.Incasso = EnumIncasso.Internet;
                vendita.CodiceLeggibile = Vendita.NuovoCodiceVendita();
                vendita.CodicePrevent = "";

                vendita.DataContabile = myFeData.InseritaIlDateTime.Date;
                vendita.DataOraStampa = myFeData.InseritaIlDateTime;

                vendita.Descrizione = myFeData.TitolareCarta;

                vendita.Utente = utente;
                vendita.Postazione = postazione;
                vendita.Struttura = postazione.Struttura;
                vendita.TotalePersone = 1;
                vendita.TotaleImporto = card.Importo;
                vendita.Save();

                Percorso per = uow.FindObject<Percorso>(new BinaryOperator("Descrizione", "MyFE"));

                Variante v1 = per.GetVarianteMyFe("Com", "C", card.TipologiaCard);
                Variante v2 = per.GetVarianteMyFe("Pin", "C", card.TipologiaCard);

                if (v1 == null || v2 == null)
                //if (v1 == null)
                {
                    throw new Exception("Manca tariffa");
                    //XtraMessageBox.Show("Tariffa per le card mancante", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return false;
                }

                decimal totale = v1.Prezzo + (v2 != null ? v2.Prezzo : 0);

                List<Ingresso> ingressi = new List<Ingresso>();
                ingressi.AddRange(per.Ingressi);

                RigaVenditaVariante rvv1 = new RigaVenditaVariante(uow);
                rvv1.PrezzoTotale = v1.Prezzo;
                rvv1.PrezzoUnitario = v1.Prezzo;
                rvv1.Profilo = 0;
                rvv1.Quantita = 1;
                rvv1.Variante = v1;
                rvv1.Vendita = vendita;
                rvv1.Card = card;
                rvv1.Save();

                if (v2 != null)
                {
                    RigaVenditaVariante rvv2 = new RigaVenditaVariante(uow);
                    rvv2.PrezzoTotale = v2.Prezzo;
                    rvv2.PrezzoUnitario = v2.Prezzo;
                    rvv2.Profilo = 0;
                    rvv2.Quantita = 1;
                    rvv2.Variante = v2;
                    rvv2.Vendita = vendita;
                    rvv2.Card = card;
                    rvv2.Save();
                }

                DateTime inizioVal = myFeData.InizioDateTime.Date;
                DateTime fineVal = inizioVal.AddDays(card.Giorni() - 1);

                Stampa stampa = new Stampa(uow);
                stampa.Vendita = vendita;
                stampa.InizioValidita = inizioVal;
                stampa.FineValidita = fineVal;
                stampa.Quantita = 1;
                stampa.ImportoTotale = totale;
                stampa.StatoStampa = 0;
                stampa.TipoStampa = EnumTipoStampa.CardInternet;
                stampa.Card = card;
                stampa.Save();
                stampa.GeneraBarCode(postazione, ingressi);

                card.Status = EnumStatoCard.Emessa;
                card.Stampa = stampa;
                card.Save();

                Stampa doppia = uow.FindObject<Stampa>(new BinaryOperator("BarCode", stampa.BarCode));
                if (doppia != null)
                {
                    stampa.GeneraBarCode(postazione, ingressi);

                    doppia = uow.FindObject<Stampa>(new BinaryOperator("BarCode", stampa.BarCode));
                    if (doppia != null)
                    {
                        stampa.GeneraBarCode(postazione, ingressi);

                        doppia = uow.FindObject<Stampa>(new BinaryOperator("BarCode", stampa.BarCode));
                        if (doppia != null)
                        {
                            stampa.GeneraBarCode(postazione, ingressi);
                        }
                    }
                }

                stampa.Save();

                foreach (Ingresso ingresso in per.Ingressi)
                {
                    RigaStampaIngresso rigaingresso = new RigaStampaIngresso(uow);
                    rigaingresso.Ingresso = uow.GetObjectByKey<Ingresso>(ingresso.Oid);
                    rigaingresso.Stampa = stampa;
                    rigaingresso.TotalePersone = 1;
                    rigaingresso.Save();
                }

                uow.CommitChanges();
            }
        }

        private static List<MyFeData> DownloadData()
        {
            string result = "";
            var elenco = new List<MyFeData>();

            try
            {
                DateTime start = DateTime.Today.AddDays(-5);
                DateTime end = DateTime.Today.AddDays(1);

                string sUrl = string.Format(ticketUrl, start, end);

                WebClient wclient = new WebClient();
                result = wclient.DownloadString(sUrl);
                
                if (!string.IsNullOrWhiteSpace(result))
                {
                    string[] lines = result.Split(new char[] { '\n' });
                    for (int i = 0; i < lines.Length; i++)
                    {
                        //Console.WriteLine("-------------");
                        //Console.WriteLine(lines[i]);
                        //Console.WriteLine("-------------");

                        if (i > 0 && !string.IsNullOrWhiteSpace(lines[i]))
                        {
                            MyFeData newData = new MyFeData(lines[i]);
                            elenco.Add(newData);

                            //Console.WriteLine(String.Format("PuntoVendita          : [{0}]", newData.PuntoVendita));
                            //Console.WriteLine(String.Format("Cliente               : [{0}]", newData.Cliente));
                            //Console.WriteLine(String.Format("EmailCliente          : [{0}]", newData.EmailCliente));
                            //Console.WriteLine(String.Format("IDCliente             : [{0}]", newData.IDCliente));
                            //Console.WriteLine(String.Format("Transazione           : [{0}]", newData.Transazione));
                            //Console.WriteLine(String.Format("InseritaIl            : [{0}]", newData.InseritaIl));
                            //Console.WriteLine(String.Format("TitolareCarta         : [{0}]", newData.TitolareCarta));
                            //Console.WriteLine(String.Format("Inizio                : [{0}]", newData.Inizio));
                            //Console.WriteLine(String.Format("Fine                  : [{0}]", newData.Fine));
                            //Console.WriteLine(String.Format("Giorni                : [{0}]", newData.Giorni));
                            //Console.WriteLine(String.Format("Prodotto              : [{0}]", newData.Prodotto));
                            //Console.WriteLine(String.Format("CodiceOperazione      : [{0}]", newData.CodiceOperazione));
                            //Console.WriteLine(String.Format("CodiceTessera         : [{0}]", newData.CodiceTessera));
                            //Console.WriteLine(String.Format("TipoOperazione        : [{0}]", newData.TipoOperazione));
                            //Console.WriteLine(String.Format("Quantità              : [{0}]", newData.Quantita));

                            //Console.WriteLine(String.Format("InseritaIlDateTime    : [{0}]", newData.InseritaIlDateTime));
                            //Console.WriteLine(String.Format("Inizio                : [{0}]", newData.InizioDateTime));
                            //Console.WriteLine(String.Format("Fine                  : [{0}]", newData.FineDateTime));
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                SendMsg("Server Side Exception - WinTicket",
                    ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + "[" + Environment.NewLine +
                    result + Environment.NewLine + "]");
            }

            return elenco;
        }

        private static void DBSetup()
        {
            XpoDefault.GuidGenerationMode = GuidGenerationMode.UuidCreateSequential;

            string conn = MSSqlConnectionProvider.GetConnectionString("hde01", "sa", "xxx", "MuseiXafTest1");

            IDataStore store = XpoDefault.GetConnectionProvider(conn, AutoCreateOption.None);

            XpoDefault.DataLayer = new SimpleDataLayer(store);

            XpoDefault.Session = null;
        }
    }
}
