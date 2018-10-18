using System;
using System.Windows.Forms;
using Musei.Module;
using DevExpress.Xpo.DB;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;
using System.IO;
using GemBox.Spreadsheet;
using System.Collections.Generic;
using System.Globalization;
using WinTicketNext.CostruzionePercorso.GestionePrenotazione;

namespace WinTicketNext
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Skin();

                new Splash().ShowDialog();

                XtraFormUserLogon logon = new XtraFormUserLogon();
                if (logon.ShowDialog() == DialogResult.OK)
                {
                    if (Program.Postazione != null && Program.UtenteCollegato != null)
                    {
                        RegistrazioneAccesso();
                        RecuperaEntratePosticipate();
                        // ProceduraDiServizioPostLogon(); // MESSO DOPO APERTURA FINESTRA PRINCIPALE

                        Application.Run(new RibbonFormDashBoard());
                    }
                    else
                    {
                        MessageBox.Show("Postazione o Utente non configurata", "Errore", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                new Splash().NoInit().ShowDialog();
            }
        }

        private static void Skin()
        {
            try
            {
                //DevExpress.UserSkins.OfficeSkins.Register();
                DevExpress.UserSkins.BonusSkins.Register();
                DevExpress.Skins.SkinManager.EnableFormSkinsIfNotVista();
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Properties.Settings.Default.Skin;
                DevExpress.LookAndFeel.UserLookAndFeel.Default.StyleChanged += Default_StyleChanged;
            }
            catch (Exception)
            {

            }
        }

        static void Default_StyleChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Skin = DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName;
            Properties.Settings.Default.Save();
        }

        public static void InitMain()
        {
            //if (!StaticInfo.UfficioXPSoft())

            CreaIconaSulDesktop();

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();

            ConnectToDatabase();
            //SetInMemoryDataStore();

            SetPostazione();

            ProceduraDiServizio();
        }

        private static void CreaIconaSulDesktop()
        {
            try
            {
                string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string fileName = String.Format("{0}\\{1}.url", deskDir, "Assistenza XPSOFT");
                if (File.Exists(fileName))
                    File.Delete(fileName);

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.WriteLine("[InternetShortcut]");
                    writer.WriteLine(@"URL=http://soft.xpsoft.it/help");
                    writer.WriteLine(@"IconFile=http://soft.xpsoft.it/help/favicon.ico");
                    writer.WriteLine("IconIndex=1");
                    writer.Flush();
                }
            } catch (Exception ex)
            {
                //ignora
            }
        }

        private static bool RegistrazioneAccesso()
        {
            // registrazione accesso
            try
            {
                using (Session ses = new Session())
                {
                    PostazioneAccesso access =
                        ses.FindObject<PostazioneAccesso>(new GroupOperator(GroupOperatorType.And,
                            new CriteriaOperator[]
                            {
                                new BinaryOperator("Data", DateTime.Now.Date),
                                new BinaryOperator("Postazione.Oid", Program.Postazione.Oid)
                            }));

                    if (access == null)
                    {
                        access = new PostazioneAccesso(ses);
                        access.Postazione = ses.GetObjectByKey<Postazione>(Program.Postazione.Oid);
                        access.Data = DateTime.Now.Date;
                        access.Save();
                    }
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Errore nella registrazione dell'accesso. Riavviare il programma e riprovare.",
                    "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private static bool RecuperaEntratePosticipate()
        {
            try
            {
                using (UnitOfWork ses = new UnitOfWork())
                {
                    Postazione postazione = ses.GetObjectByKey<Postazione>(Program.Postazione.Oid);
                    XPCollection<EntrataPosticipata> entrate = new XPCollection<EntrataPosticipata>(ses,
                        new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]
                        {
                            //new BinaryOperator("")
                            new BinaryOperator("Postazione", postazione),
                            new BinaryOperator("Status", EnumStatusEntrata.InCoda)
                        }));

                    foreach (var item in entrate)
                    {
                        XPCollection<Stampa> stampe = new XPCollection<Stampa>(ses,
                            new GroupOperator(GroupOperatorType.Or,
                                new CriteriaOperator[]
                                {
                                    new BinaryOperator("BarCode", item.BarCode),
                                    new BinaryOperator("CodiceProgressivo", item.BarCode),
                                    new BinaryOperator("Card.Codice", item.BarCode)
                                }));
                        stampe.Sorting =
                            new DevExpress.Xpo.SortingCollection(new SortProperty[]
                            {
                                new SortProperty("Vendita.DataOraStampa", DevExpress.Xpo.DB.SortingDirection.Descending)
                            });

                        if (stampe.Count > 0)
                        {
                            Stampa stampa = stampe[0];
                            foreach (PostazioneIngresso ping in postazione.Ingressi)
                            {
                                if (ping.Tipologia == EnumTipologiaPostazioneIngresso.MarcaturaAutomatica)
                                {
                                    foreach (RigaStampaIngresso riga in stampa.RigheStampaIngresso)
                                    {
                                        if (riga.Ingresso == ping.Ingresso)
                                        {
                                            if (riga.TotalePersone > riga.TotaleIngressi)
                                            {
                                                // registra entrate su questo ingresso
                                                Entrata entrata = new Entrata(ses);
                                                entrata.DataOraEntrata = item.DataOraEntrata;
                                                entrata.Quantita = riga.TotalePersone - riga.TotaleIngressi;
                                                entrata.RigaStampaIngresso = riga;
                                                entrata.Save();

                                                riga.TotaleIngressi = riga.TotalePersone;
                                                riga.Save();
                                            }
                                        }
                                    }
                                }
                            }

                            item.DataEvasione = DateTime.Now;
                            item.Status = EnumStatusEntrata.Evasa;
                            item.Save();

                            Messaggio msg = new Messaggio(ses);
                            msg.Data = DateTime.Now;
                            msg.Oggetto = String.Format("BarCode {0} evaso", item.BarCode);
                            msg.TestoEsteso = String.Format("BarCode {0} evaso", item.BarCode);
                            msg.Autore = ses.GetObjectByKey<Utente>(Program.UtenteCollegato.Oid);
                            msg.Tipologia = EnumTipoMessaggio.RecuperoEntrataPosticipata;
                            msg.Save();

                        }
                        else
                        {
                            if (item.DataOraEntrata.AddMonths(1) < DateTime.Now)
                            {
                                item.DataEvasione = DateTime.Now;
                                item.Status = EnumStatusEntrata.Annullata;
                                item.Save();

                                Messaggio msg = new Messaggio(ses);
                                msg.Data = DateTime.Now;
                                msg.Oggetto = String.Format("BarCode {0} annullato", item.BarCode);
                                msg.TestoEsteso =
                                    String.Format(
                                        "BarCode {0} annullato perche' risale a piu' di un mese fa ed attualmente non ancora presente in archivio ...",
                                        item.BarCode);
                                msg.Autore = ses.GetObjectByKey<Utente>(Program.UtenteCollegato.Oid);
                                msg.Tipologia = EnumTipoMessaggio.RecuperoEntrataPosticipata;
                                msg.Save();
                            }
                        }
                    }

                    ses.CommitChanges();
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show(
                    "Errore nel recupero dei codici a barre posticipati. Riavviare il programma e riprovare.", "Errore",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public static bool ProceduraDiServizioPostLogon()
        {
            try
            {
                using (Session ses = new Session())
                {
                    DateTime inizioAnno = new DateTime(DateTime.Today.Year, 1, 1);
                    DateTime fineAnno = new DateTime(DateTime.Today.Year + 1, 1, 1);

                    GroupOperator criteria = new GroupOperator(GroupOperatorType.And);
                    criteria.Operands.Add(new BinaryOperator("Vendita.DataContabile", inizioAnno,
                        BinaryOperatorType.GreaterOrEqual));
                    criteria.Operands.Add(new BinaryOperator("Vendita.DataContabile", fineAnno, BinaryOperatorType.Less));
                    criteria.Operands.Add(new BinaryOperator("Vendita.Postazione.Oid", Program.Postazione.Oid));

                    XPCollection<Stampa> stampe = new XPCollection<Stampa>(ses, criteria);
                    stampe.TopReturnedObjects = 1;

                    if (stampe.Count > 0)
                    {
                        XtraReportStampa2 report = new XtraReportStampa2();
                        report.xpCollection1.Criteria = new BinaryOperator("Oid", stampe[0].Oid);

                        report.ShowPrintMarginsWarning = false;
                        report.ShowPrintStatusDialog = false;
                        report.ExportToPdf("tmp.pdf");
                    }
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    String.Format(
                        "Errore nella procedura di servizio post logon ({0}). Riavviare il programma e riprovare.",
                        ex.Message), "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private static void ProceduraDiServizio()
        {
            // recupero myvendute e non segnate come ingressi
            //using (Session ses = new Session())
            //{
            //    DateTime data = new DateTime(2016, 1, 1);

            //    int et1 = 0;
            //    int et2 = 0;
            //    int et3 = 0;
            //    var kpos = "Castello";
            //    var postazioni = new XPCollection<Postazione>(ses);

            //    do
            //    {
            //        int venditegiornata = 0;
            //        foreach (var postazione in postazioni)
            //        {
            //            if (postazione.Ingresso.Descrizione.Contains(kpos))
            //            {
            //                var vendite = new XPCollection<Vendita>(ses);
            //                vendite.Criteria =
            //                    new GroupOperator(GroupOperatorType.And,
            //                        new CriteriaOperator[]
            //                        {
            //                            new BinaryOperator("DataContabile", data),
            //                            new BinaryOperator("Postazione.Oid", postazione.Oid)
            //                        });

            //                foreach (var vendita in vendite)
            //                {
            //                    foreach (var stampa in vendita.Stampe)
            //                    {
            //                        if (stampa.Card == null) continue;

            //                        foreach (var riga in stampa.RigheStampaIngresso)
            //                        {
            //                            if (riga.Ingresso.Descrizione == "Castello Estense (MUSEO)")
            //                            {
            //                                int qta = 0;
            //                                foreach (var entrata in riga.Entrate)
            //                                {
            //                                    qta += entrata.Quantita;
            //                                }

            //                                if (qta > riga.TotaleIngressi)
            //                                {
            //                                    et1++;
            //                                }
            //                                if (qta < riga.TotaleIngressi)
            //                                {
            //                                    et2++;
            //                                    if (riga.Entrate.Count == 0)
            //                                    {
            //                                        et3++;

            //                                        Entrata enw = new Entrata(ses);

            //                                        enw.Quantita = riga.TotaleIngressi;
            //                                        enw.DataOraEntrata = vendita.DataOraStampa;
            //                                        enw.RigaStampaIngresso = riga;

            //                                        enw.CreatoDa = "RECUPERO";
            //                                        enw.CreatoIl = vendita.DataOraStampa;

            //                                        enw.Save();
            //                                    }
            //                                }
            //                            }
            //                        }

            //                    }
            //                }
            //            }
            //        }

            //        data = data.AddDays(1);
            //    } while (data.Year == 2016);

            //    XtraMessageBox.Show("ERR1: " + et1 + " ERR2: " + et2 + " ERR3: " + et3);

            //}



            // IMPORTANTE: allineamento vendite / aperture
            //using (Session ses = new Session())
            //{
            //    DateTime data = new DateTime(2016, 1, 1);

            //    var kpos = "Bonac";
            //    var postazioni = new XPCollection<Postazione>(ses);

            //    do
            //    {
            //        int venditegiornata = 0;
            //        foreach (var postazione in postazioni)
            //        {
            //            if (postazione.Ingresso.Descrizione.Contains(kpos))
            //            {
            //                var vendite = new XPCollection<Vendita>(ses);
            //                vendite.Criteria =
            //                    new GroupOperator(GroupOperatorType.And,
            //                        new CriteriaOperator[]
            //                        {
            //                            new BinaryOperator("DataContabile", data),
            //                            new BinaryOperator("Postazione.Oid", postazione.Oid)
            //                        });

            //                venditegiornata += vendite.Count;
            //            }
            //        }

            //        if (venditegiornata == 0)
            //        {

            //            foreach (var postazione in postazioni)
            //            {
            //                if (postazione.Ingresso.Descrizione.Contains(kpos))
            //                {
            //                    var accessi =
            //                        new XPCollection<PostazioneAccesso>(ses, new GroupOperator(GroupOperatorType.And,
            //                            new CriteriaOperator[]
            //                            {
            //                                new BinaryOperator("Data", data),
            //                                new BinaryOperator("Postazione.Oid", postazione.Oid)
            //                            }));

            //                    if (accessi.Count > 0)
            //                    {
            //                        //XtraMessageBox.Show("Nessuna vendita per " + kpos + " nella giornata di " +
            //                        //                    data.ToString("d") + " ma accesso da " + postazione.Nome);

            //                        //return;
            //                    }
            //                }
            //            }

            //        }
            //        else
            //        {
            //            int totaccessi = 0;
            //            foreach (var postazione in postazioni)
            //            {
            //                if (postazione.Opzione("[NOACCESSI]")) continue;
                            
            //                if (postazione.Ingresso.Descrizione.Contains(kpos))
            //                {
            //                    var accessi =
            //                        new XPCollection<PostazioneAccesso>(ses, new GroupOperator(GroupOperatorType.And,
            //                            new CriteriaOperator[]
            //                            {
            //                                new BinaryOperator("Data", data),
            //                                new BinaryOperator("Postazione.Oid", postazione.Oid)
            //                            }));

            //                    totaccessi += accessi.Count;
            //                }
            //            }

            //            if (totaccessi == 0)
            //            {
            //                if (
            //                    XtraMessageBox.Show("Vendite senza aperture per " + kpos + " nella giornata di " +
            //                                        data.ToString("d"), "correggo ?", MessageBoxButtons.YesNo) ==
            //                    DialogResult.Yes)
            //                {
            //                    foreach (var postazione in postazioni)
            //                    {
            //                        if (postazione.Ingresso.Descrizione.Contains(kpos))
            //                        {
            //                            var vendite = new XPCollection<Vendita>(ses);
            //                            vendite.Criteria =
            //                                new GroupOperator(GroupOperatorType.And,
            //                                    new CriteriaOperator[]
            //                                    {
            //                                        new BinaryOperator("DataContabile", data),
            //                                        new BinaryOperator("Postazione.Oid", postazione.Oid)
            //                                    });

            //                            foreach (var vendita in vendite)
            //                            {
            //                                vendita.DataContabile = vendita.DataContabile.AddDays(1);
            //                                vendita.DataOraStampa = vendita.DataOraStampa.AddDays(1);
            //                                vendita.Save();
            //                            }

            //                        }
            //                    }
            //                }

            //                //return;
            //            }

            //        }

            //        data = data.AddDays(1);
            //    } while (data.Year == 2016);

            //}

            //using (Session ses = new Session())
            //{
            //    int n = 28001;
            //    int d = 2;

            //    for (int i = n; i < n + 40000; i++)
            //    {
            //        string codice = string.Format("{0:000}{1:000000}", d, i);

            //        var old = ses.FindObject<Card>(new BinaryOperator("Codice", codice));
            //        if (old == null)
            //        {
            //            Card card = new Card(ses);

            //            card.Codice = codice;
            //            card.Status = EnumStatoCard.Nuova;
            //            card.TipologiaCard = EnumTipologiaCard.Card2Giorni;
            //            card.Save();

            //            Console.WriteLine(codice);
            //        }
            //    }
            //}

            //using (Session ses = new Session())
            //{
            //    var infos = CultureInfo.GetCultures(CultureTypes.AllCultures);
            //    foreach (CultureInfo culture in infos)
            //    {
            //        try
            //        {
            //            RegionInfo regionInfo = new RegionInfo(culture.LCID);

            //            // regionInfo.DisplayName
            //            //regionInfo.EnglishName

            //            var obj = ses.FindObject<Provenienza>(new BinaryOperator("CAP", regionInfo.Name));
            //            if (obj == null)
            //            {
            //                obj = new Provenienza(ses);

            //                obj.CAP = regionInfo.Name;
            //                obj.Regione = regionInfo.EnglishName;
            //                obj.Provincia = "";
            //                obj.Comune = "";
            //                obj.Stato = regionInfo.DisplayName;
            //                obj.Save();
            //            }
            //        }
            //        catch (Exception)
            //        { }
            //    }
            //}

            //using (Session ses = new Session())
            //{
            //    SpreadsheetInfo.SetLicense("E3JO-RSBH-88H3-MVUJ");

            //    var esf = ExcelFile.Load(@"C:\Users\Luca\Dropbox\PROGETTI\101-PROVFE-WinTicketNext\doc\GeoPC_IT\GeoPC_IT2.xlsx");

            //    var wsdati = esf.Worksheets[0];

            //    for (int i = 1; i < wsdati.Rows.Count; i++)
            //    {
            //        var r1 = wsdati.Rows[i].Cells[4].Value.ToString();
            //        var r2 = wsdati.Rows[i].Cells[5].Value.ToString();
            //        var r3 = wsdati.Rows[i].Cells[6].Value.ToString();
            //        var rz = wsdati.Rows[i].Cells[8].Value.ToString();

            //        var obj = ses.FindObject<Provenienza>(new BinaryOperator("CAP", rz));
            //        if (obj == null)
            //        {
            //            obj = new Provenienza(ses);

            //            obj.CAP = rz;
            //            obj.Regione = r1;
            //            obj.Provincia = r2;
            //            obj.Comune = r3;
            //            obj.Stato = "Italia";
            //            obj.Save();
            //        }
            //    }
            //}
        }

        private static void SetPostazione()
        {
            Session session = new Session();

            string key = Environment.MachineName;

            Postazione posto = session.FindObject<Postazione>(new BinaryOperator("MachineName", key));

            if (posto == null)
            {
                XtraMessageBox.Show(string.Format("Postazione '{0}' non trovata o non codificata. Impossibile proseguire.", key), "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Program.Postazione = posto;

            XPCollection<Provenienza> provol = new XPCollection<Provenienza>(session);
            Program.Provenienze = new List<Provenienza>();
            Program.Provenienze.AddRange(provol);
        }

        private static void ConnectToDatabase()
        {
            // generazione sequenziale dei GUID
            XpoDefault.GuidGenerationMode = GuidGenerationMode.UuidCreateSequential;

            string conn = string.Empty;

            if (StaticInfo.NoSync())
            {
                string[] info = StaticInfo.NoSyncInfo();
                conn = MSSqlConnectionProvider.GetConnectionString(info[0], info[1], info[2], info[3]);
            }
            else
                conn = MSSqlConnectionProvider.GetConnectionString("(local)\\SQLEXPRESS", "MuseiXafRev1locale");

            if (StaticInfo.UpdateSchema())
            {
                // update schema:
                try
                {
                    IDataLayer dl = XpoDefault.GetDataLayer(conn, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
                    using (Session session = new Session(dl))
                    {
                        System.Reflection.Assembly[] assemblies = new System.Reflection.Assembly[] {
                                                    typeof(Ingresso).Assembly
                                            };

                        session.UpdateSchema(assemblies);
                        session.CreateObjectTypeRecords(assemblies);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Unable to update database schema: {0}", ex.Message));
                }
            }

            IDataStore store = XpoDefault.GetConnectionProvider(conn, AutoCreateOption.None);

            if (conn.EndsWith(".asmx"))
                store = new DevExpress.Xpo.DB.DataCacheNode(new DevExpress.Xpo.DB.DataCacheRoot(store));

            XpoDefault.DataLayer = new SimpleDataLayer(store);

            XpoDefault.Session = null;
        }

        public static Utente UtenteCollegato;
        public static Postazione Postazione;
        public static List<Provenienza> Provenienze;
    }
}
