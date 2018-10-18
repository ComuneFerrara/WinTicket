using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using WinTicketNext.CostruzionePercorso;
using DevExpress.Data.Filtering;
using Musei.Module;
using WinTicketNext.Storico;
using WinTicketNext.Validazione;
using System.Diagnostics;
using DevExpress.Xpo;
using DevExpress.XtraBars.Helpers;
using DevExpress.Xpo.DB;
using System.Threading;
using WinTicketNext.Storico.Rep01;
using DevExpress.XtraCharts;
using WinTicketNext.Storico.Rep02;
using WinTicketNext.Storico.Rep03b;
using WinTicketNext.Storico.Rep01b;
using WinTicketNext.Storico.RepBv1;
using WinTicketNext.Storico.RepBv2;
using WinTicketNext.Storico.Rep03;
using WinTicketNext.Storico.Rep04;
using WinTicketNext.Storico.Rep06;
using WinTicketNext.Storico.Rep01t;
using System.Collections.Generic;
using DevExpress.XtraLayout.Customization;
using WinTicketNext.Storico.Rep07;

namespace WinTicketNext
{
    public partial class RibbonFormDashBoard : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonFormDashBoard()
        {
            InitializeComponent();

            SkinHelper.InitSkinGallery(ribbonGalleryBarItemSkin, true, true);

            CriteriaOperator criteria1 = new GroupOperator(GroupOperatorType.And,
                new CriteriaOperator[]{
                    new BinaryOperator("Data", DateTime.Now.Date.AddMonths(-4), BinaryOperatorType.GreaterOrEqual),
                    new BinaryOperator("Data", DateTime.Now.Date.AddDays(1), BinaryOperatorType.Less)
                });
            CriteriaOperator criteria2 = new GroupOperator(GroupOperatorType.And,
                new CriteriaOperator[]{
                    new BinaryOperator("Data", DateTime.Now.Date.AddMonths(-4), BinaryOperatorType.GreaterOrEqual),
                    new BinaryOperator("Autore.Oid", Program.UtenteCollegato.Oid, BinaryOperatorType.Equal)
                });
            CriteriaOperator criteria = new GroupOperator(GroupOperatorType.Or, new CriteriaOperator[] { criteria1, criteria2 });
            this.xpCollectionMessaggi.Criteria = criteria;

            this.xpCollectionPostazioni.Criteria = new BinaryOperator("SyncSuccess", DateTime.Now.AddDays(-100), BinaryOperatorType.GreaterOrEqual);

            //new GroupOperator(GroupOperatorType.Or, new CriteriaOperator[]{
            //new BinaryOperator("Tipologia", EnumTipoMessaggio.MessaggioInformativo),
            //new BinaryOperator("Tipologia", EnumTipoMessaggio.Eliminazione),
            //new BinaryOperator("Tipologia", EnumTipoMessaggio.EliminazioneConPrenotazione),
            //new BinaryOperator("Tipologia", EnumTipoMessaggio.Ristampa)});

            timerMessaggi_Tick(null, null);

            StaticInfo.DataAgg(barStaticItemInfo);

            this.backgroundWorkerPush.RunWorkerAsync();

            try
            {
                this.Text = String.Format("Win Ticket Next ({0})",
                    Program.UtenteCollegato.FullName);

                string sw = MostraVersione();
                this.barStaticItemInfo1.Caption = sw;
                this.barStaticItemInfo2.Caption = Program.Postazione.Nome;
                this.barStaticItemInfo3.Caption = Program.UtenteCollegato.FullName;

                Program.Postazione.Reload();
                if (Program.Postazione.SoftwareVersion != sw || Program.Postazione.Utente != Program.UtenteCollegato.FullName)
                {
                    Program.Postazione.SoftwareVersion = sw;
                    Program.Postazione.Utente = Program.UtenteCollegato.FullName;
                    Program.Postazione.Save();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Errore: " + ex.Message, "ERRORE2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!Program.UtenteCollegato.Autorizzato(Utente.OperazioneRiepiloghi))
            {
                this.barButtonItemPivotRiga.Enabled = false;
                this.barButtonItemPivotEntrate.Enabled = false;
                this.barButtonItemPivotVendite.Enabled = false;
            }

            if (!Program.UtenteCollegato.Autorizzato(Utente.OperazioneRiepiloghiGenerali))
            {
                this.barButtonItemReport03.Enabled = false;
                this.barButtonItemReport03b.Enabled = false;
                this.barButtonItemReport06.Enabled = false;
                this.barButtonItemReport07.Enabled = false;
                this.barButtonItemReportBv1.Enabled = false;
                this.barButtonItemReportBv2.Enabled = false;
            }

            VisualizzaMessaggi();

            Stampa.SetProgressivoMinimo(this.unitOfWork1, Program.Postazione.Oid);
        }

        private void VisualizzaMessaggi()
        {
            using (XPCollection<Messaggio> msgs = new XPCollection<Messaggio>(this.unitOfWork1))
            {
                msgs.Criteria = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[] { 
                    new BinaryOperator("Data", DateTime.Now.Date, BinaryOperatorType.LessOrEqual), 
                    new BinaryOperator("DataFine", DateTime.Now.Date, BinaryOperatorType.GreaterOrEqual), 
                    new BinaryOperator("Tipologia", EnumTipoMessaggio.MessaggioInformativo) });

                foreach (Messaggio msg in msgs)
                {
                    if (!msg.Letto(Program.UtenteCollegato.Oid))
                    {
                        using (XtraFormMessaggio form = new XtraFormMessaggio())
                        {
                            form.Init(msg);
                            form.ShowDialog();
                        }
                    }
                }
            }
        }

        private static string MostraVersione()
        {
            string versione = "";
            try
            {
                versione = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion + " C";
            }
            catch (Exception)
            {
                versione = Application.ProductVersion + " L";
            }

            return versione;
        }

        private void barButtonItemMulti_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (RibbonFormMultiploAdv falt = new RibbonFormMultiploAdv())
            {
                falt.ShowDialog(this);
            }
        }

        private void barButtonItemReport1_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (RibbonFormPivotRigaVenditaVariante stampe = new RibbonFormPivotRigaVenditaVariante())
            {
                stampe.ShowDialog(this);
            }
        }

        private void RibbonFormDashBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.Postazione != null)
            {
                using (Session session = new Session())
                {
                    Postazione postazione = session.GetObjectByKey<Postazione>(Program.Postazione.Oid);
                    postazione.Utente = "--";
                    postazione.Save();
                }

                using (XtraFormSync form = new XtraFormSync())
                {
                    if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        this.backgroundWorkerPush.CancelAsync();
                        Program.UtenteCollegato = null;
                        Program.Postazione = null;
                    }
                }
            }
        }

        private bool BigliettiPerAltriMuseiDopoIl(DateTime dateTime)
        {
            return false;
            // basta, e la manutenzione e' onerosa ... sync ogni 12 minuti
            // dovrebbe garantire lo scambio corretto.

            if (StaticInfo.NoSync()) return false;

            try
            {
                using (Session session = new Session())
                {

                    GroupOperator newGroupOperator = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]
                    {
                        new BinaryOperator("Stampa.Vendita.Struttura.Oid", Program.Postazione.Struttura.Oid),
                        new BinaryOperator("Stampa.Vendita.DataOraStampa", dateTime, BinaryOperatorType.Greater)
                    });

                    GroupOperator ingressi = new GroupOperator(GroupOperatorType.Or);
                    foreach (Ingresso ingresso in Program.Postazione.IngressiControllatiDaAltrePostazioni())
                    {
                        ingressi.Operands.Add(new BinaryOperator("Ingresso.Oid", ingresso.Oid));
                    }

                    newGroupOperator.Operands.Add(ingressi);

                    using (XPCollection<RigaStampaIngresso> righe = new XPCollection<RigaStampaIngresso>(session) { TopReturnedObjects = 1, Criteria = newGroupOperator })
                    {
                        syncReason = string.Format("ho {0} RigaStampaIngresso per altre postazioni", righe.Count);
                        return righe.Count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                this.backgroundWorkerPush.ReportProgress(20, ex.Message);
                return false;
            }
        }

        private string syncReason = string.Empty;
        private bool EsistonoMieiBigliettiSulServer(DateTime dateTime)
        {
            return false;

            // basta, e la manutenzione e' onerosa ... sync ogni 12 minuti
            // dovrebbe garantire lo scambio corretto.
            if (StaticInfo.NoSync()) return false;

            try
            {
                IDataStore store = XpoDefault.GetConnectionProvider("http://webdals.winticket.xpsoft.it/WebServiceConnection001.asmx", AutoCreateOption.None);
                using (IDataLayer layer = new SimpleDataLayer(store))
                {
                    using (Session session = new Session(layer))
                    {
                        GroupOperator newGroupOperator = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[] { 
                            new BinaryOperator("Stampa.Vendita.Postazione.Oid", Program.Postazione.Oid, BinaryOperatorType.NotEqual), 
                            new BinaryOperator("Stampa.Vendita.DataOraStampa", dateTime, BinaryOperatorType.Greater) });

                        GroupOperator ingressi = new GroupOperator(GroupOperatorType.Or);

                        foreach (PostazioneIngresso postazioneIngresso in Program.Postazione.Ingressi)
                        {
                            ingressi.Operands.Add(new BinaryOperator("Ingresso.Oid", postazioneIngresso.Ingresso.Oid));
                        }

                        if (ingressi.Operands.Count == 0)
                            return false;

                        newGroupOperator.Operands.Add(ingressi);

                        XPView vista = new XPView(session, typeof(RigaStampaIngresso));
                        vista.Criteria = newGroupOperator;
                        vista.Properties.Add(new ViewProperty("Oid", SortDirection.None, "Oid", false, true));

                        if (vista.Count > 0)
                        {
                            using (Session localSession = new Session())
                            {
                                //this.backgroundWorkerPush.ReportProgress(10, string.Format("la vista ha {0} record", vista.Count));

                                foreach (ViewRecord viewRecord in vista)
                                {
                                    Guid oid = (Guid)viewRecord[0];
                                    if (localSession.GetObjectByKey<RigaStampaIngresso>(oid) == null)
                                    {
                                        syncReason = string.Format("mi manca RigaStampaIngresso {0} (la vista contiene {1} record)", oid, vista.Count);
                                        return true;
                                    }
                                }
                            }
                        }

                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                this.backgroundWorkerPush.ReportProgress(10, ex.Message);
                // silente
                return false;
            }
        }

        private int nvolte = 0;

        private void AggiornaGriglie()
        {
            Cursor saveCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.xpCollectionMessaggi.Reload();
                this.gridViewMessaggi.BestFitColumns();

                this.xpCollectionPostazioni.Reload();
                this.gridView1.RefreshData();
                this.gridView1.BestFitColumns();

                Program.Postazione.Reload();

                //if (nvolte > 0)
                //    AggiornaGrigliaMyFE();

                nvolte++;
            }
            finally
            {
                Cursor.Current = saveCursor;
            }
        }

        private DateTime grigliaDateTime = DateTime.Now;
        private void AggiornaGrigliaMyFE()
        {
            try
            {
                if ((DateTime.Now - grigliaDateTime).TotalMinutes < 10) return;

                grigliaDateTime = DateTime.Now;
                using (Session ses = new Session())
                {
                    var tutte = new XPCollection<Card>(ses, new BinaryOperator("Status", EnumStatoCard.Emessa));

                    var elenco = new List<InfoGrigliaCard>();

                    elenco.Add(new InfoGrigliaCard() { Tipologia = EnumTipologiaCard.Card2Giorni });
                    elenco.Add(new InfoGrigliaCard() { Tipologia = EnumTipologiaCard.Card3Giorni });
                    elenco.Add(new InfoGrigliaCard() { Tipologia = EnumTipologiaCard.Card6Giorni });

                    DateTime dt = DateTime.Now.Date;
                    DateTime qm1 = new DateTime(dt.Year, dt.Month, 1);
                    DateTime sm1 = new DateTime(dt.Year, dt.Month, 1).AddMonths(-1);

                    DateTime qs1 = dt;
                    while (qs1.DayOfWeek != DayOfWeek.Monday)
                    {
                        qs1 = qs1.AddDays(-1);
                    }
                    DateTime ss1 = qs1.AddDays(-7);

                    foreach (var item in tutte)
                    {
                        foreach (var cti in elenco)
                        {
                            if (cti.Tipologia == item.TipologiaCard)
                            {
                                cti.Totale++;
                                if (item.Stampa != null && item.Stampa.Vendita != null)
                                {
                                    if (item.Stampa.Vendita.DataContabile >= qm1)
                                        cti.QuestoMese++;
                                    if (item.Stampa.Vendita.DataContabile >= sm1 && item.Stampa.Vendita.DataContabile < qm1)
                                        cti.ScorsoMese++;
                                    if (item.Stampa.Vendita.DataContabile >= qs1)
                                        cti.QuestaSettimana++;
                                    if (item.Stampa.Vendita.DataContabile >= ss1 && item.Stampa.Vendita.DataContabile < qs1)
                                        cti.ScorsaSettimana++;
                                }
                            }
                        }
                    }

                    this.gridControlCardMyFE.DataSource = elenco;

                    //this.Invoke((MethodInvoker)delegate()
                    //{
                    //    this.gridControlCardMyFE.DataSource = elenco;
                    //});

                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraBars.Alerter.AlertInfo info = new DevExpress.XtraBars.Alerter.AlertInfo("ERRORE", String.Format("12: ERRORE: {0}", ex.Message), Properties.Resources.delete);
                this.alertControlInfo.Show(this, info);                
            }
        }

        private void timerMessaggi_Tick(object sender, EventArgs e)
        {
            try
            {
                // la prima volta dopo 10 secondi ... poi ogni 50
                if (timerMessaggi.Interval != 50000 && nvolte > 0)
                    timerMessaggi.Interval = 50000;

                AggiornaGriglie();

                // CHECK AGGIORNAMENTO PREZZI CARD
                //if (Program.Postazione.MachineName == "PC01")
                //{
                //    using (UnitOfWork uow = new UnitOfWork())
                //    {
                //        var tutte = new XPCollection<Card>(uow,
                //            new BinaryOperator("Status", EnumStatoCard.Emessa));
                //        if (tutte.Count >= 5000)
                //        {
                //            Percorso per = uow.FindObject<Percorso>(new BinaryOperator("Descrizione", "MyFE"));

                //            Variante v2c = per.GetVarianteMyFe("Com", "A", EnumTipologiaCard.Card2Giorni);
                //            Variante v2p = per.GetVarianteMyFe("Prov", "A", EnumTipologiaCard.Card2Giorni);

                //            Variante v3c = per.GetVarianteMyFe("Com", "A", EnumTipologiaCard.Card3Giorni);
                //            Variante v3p = per.GetVarianteMyFe("Prov", "A", EnumTipologiaCard.Card3Giorni);

                //            Variante v6c = per.GetVarianteMyFe("Com", "A", EnumTipologiaCard.Card6Giorni);
                //            Variante v6p = per.GetVarianteMyFe("Prov", "A", EnumTipologiaCard.Card6Giorni);

                //            bool change = false;

                //            if (v2c.PrezzoAttuale.Prezzo != 6)
                //            {
                //                v2c.PrezzoAttuale.Prezzo = 6;
                //                v2p.PrezzoAttuale.Prezzo = 4;

                //                v2c.PrezzoAttuale.Save();
                //                v2p.PrezzoAttuale.Save();

                //                uow.CommitChanges();
                //                change = true;
                //            }

                //            if (v3c.PrezzoAttuale.Prezzo != 8)
                //            {
                //                v3c.PrezzoAttuale.Prezzo = 8;
                //                v3p.PrezzoAttuale.Prezzo = 4;

                //                v3c.PrezzoAttuale.Save();
                //                v3p.PrezzoAttuale.Save();

                //                uow.CommitChanges();
                //                change = true;
                //            }

                //            if (v6c.PrezzoAttuale.Prezzo != 14)
                //            {
                //                v6c.PrezzoAttuale.Prezzo = 14;
                //                v6p.PrezzoAttuale.Prezzo = 4;

                //                v6c.PrezzoAttuale.Save();
                //                v6p.PrezzoAttuale.Save();

                //                uow.CommitChanges();
                //                change = true;
                //            }

                //            if (change)
                //            {
                //                Messaggio msg = new Messaggio(uow);
                //                msg.Autore = uow.GetObjectByKey<Utente>(Program.UtenteCollegato.Oid);
                //                msg.Data = DateTime.Now;
                //                msg.Oggetto = "MyFE (cambio tariffa)";
                //                msg.TestoEsteso = "Suddivisione importi card MyFE cambiata per superamento prime 5000 card." + Environment.NewLine;
                //                msg.TestoEsteso = string.Format("Totale card MyFE: vendute {0} al {1:g}.", tutte.Count, DateTime.Now) + Environment.NewLine;
                //                msg.Tipologia = EnumTipoMessaggio.MessaggioInformativo;
                //                msg.Save();

                //                uow.CommitChanges();
                //            }
                //        }
                //    }
                //}

                if (Program.Postazione.SyncResult == EnumSyncResult.Ok)
                {
                    if (Program.Postazione.SyncTry.AddMinutes(Program.Postazione.SyncEveryMinutes) < DateTime.Now && Program.Postazione.SyncEveryMinutes > 0)
                    {
                        barButtonItemSync_ItemClick(null, null);
                    }
                    else
                    {
                        // Non programmata
                        if (_DeviSincronizzareIn || _DeviSincronizzareOut)
                        {
                            barButtonItemSync_ItemClick(null, null);

                            //using (Session session = new Session())
                            //{
                            //    Messaggio msg = new Messaggio(session);
                            //    msg.Data = DateTime.Now;

                            //    if (_DeviSincronizzareIn)
                            //        msg.Oggetto = String.Format("FS-IN {0}", Program.Postazione.Nome);
                            //    if (_DeviSincronizzareOut)
                            //        msg.Oggetto = String.Format("FS-OUT {0}", Program.Postazione.Nome);
                            //    if (_DeviSincronizzareOut && _DeviSincronizzareIn)
                            //        msg.Oggetto = String.Format("FS-IN-OUT {0}", Program.Postazione.Nome);

                            //    msg.TestoEsteso = syncReason;
                            //    msg.Autore = session.GetObjectByKey<Utente>(Program.UtenteCollegato.Oid);
                            //    msg.Tipologia = EnumTipoMessaggio.SyncDelay;
                            //    msg.Save();
                            //}
                        }
                    }
                }
                else
                {
                    if (Program.Postazione.SyncTry.AddMinutes(3) < DateTime.Now && Program.Postazione.SyncEveryMinutes > 0)
                        barButtonItemSync_ItemClick(null, null);
                }

                this.barStaticItemInfoSync.Caption = string.Format("LastSyncSuccess: {0:F}", Program.Postazione.SyncSuccess);
            }
            catch (Exception ex)
            {
                DevExpress.XtraBars.Alerter.AlertInfo info = new DevExpress.XtraBars.Alerter.AlertInfo("ERRORE", String.Format("11: ERRORE: {0}", ex.Message), Properties.Resources.delete);
                this.alertControlInfo.Show(this, info);
            }
        }

        private void gridControlMessaggi_DoubleClick(object sender, EventArgs e)
        {
            Messaggio msg = this.gridViewMessaggi.GetRow(this.gridViewMessaggi.FocusedRowHandle) as Messaggio;
            if (msg != null)
            {
                using (XtraFormMessaggio fmsg = new XtraFormMessaggio())
                {
                    fmsg.Init(msg);
                    if (fmsg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        AggiornaGriglie();
                }
            }
        }


        private void gridControlMessaggi_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Append)
            {
                e.Handled = true;

                if (Program.UtenteCollegato.Autorizzato(Utente.OperazioneRiepiloghi))
                {
                    using (XtraFormMessaggio fmsg = new XtraFormMessaggio())
                    {
                        fmsg.Init(null);

                        if (fmsg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                            AggiornaGriglie();
                    }
                } else
                    XtraMessageBox.Show("Utente non autorizzato a comporre nuovi messaggi.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItemStorico_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (RibbonFormStorico ribbonFormStorico = new RibbonFormStorico())
            {
                ribbonFormStorico.ShowDialog(this);
            }
        }

        private void barButtonItemReportA_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (XtraFormAskReportPostazione form = new XtraFormAskReportPostazione())
            {
                form.ShowDialog(this);
            }
        }

        private void barButtonItemValida_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (RibbonFormValidazione form = new RibbonFormValidazione())
            {
                form.ShowDialog(this);
            }
        }

        private Sync.SyncHelper m_Shelp;
        private void barButtonItemSync_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m_Shelp == null || m_Shelp.ResultProcessed)
            {
                StartSync();

                m_Shelp = new Sync.SyncHelper();
                m_Shelp.GoSync();
            }
        }

        private void StartSync()
        {
            this.barButtonItemSync.Enabled = false;
            if (Program.Postazione.SyncSuccess.Date != DateTime.Now.Date)
            {
                // pagina di avviso primo sync della giornata
                this.xtraTabControlMain.SelectedTabPage = this.xtraTabPageWaitSync;
                Set(this.ribbonPageReport, false);
            }
        }

        private static void Set(DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage, bool flag)
        {
            foreach (DevExpress.XtraBars.Ribbon.RibbonPageGroup group in ribbonPage.Groups)
            {
                foreach (BarItemLink itemLink in group.ItemLinks)
                {
                    itemLink.Item.Enabled = flag;
                }
            }
        }

        private void timerSync_Tick(object sender, EventArgs e)
        {
            this.barButtonItemSync.Enabled = (m_Shelp == null || m_Shelp.ResultProcessed);
            if (m_Shelp != null && m_Shelp.SyncFinished && !m_Shelp.ResultProcessed)
            {
                m_Shelp.End();

                if (m_Shelp.Result)
                {
                    _DeviSincronizzareIn = false;
                    _DeviSincronizzareOut = false;
                    syncReason = string.Empty;

                    if (this.xtraTabControlMain.SelectedTabPage == this.xtraTabPageWaitSync)
                    {
                        this.xtraTabControlMain.SelectedTabPage = this.xtraTabPageHomePage;
                        Set(this.ribbonPageReport, true);
                    }
                }
                else
                {
                    DevExpress.XtraBars.Alerter.AlertInfo info = new DevExpress.XtraBars.Alerter.AlertInfo("ERRORE", "ERRORE di sincronizzazione con il server. Contattare l'assistenza tecnica se il problema persiste.", Properties.Resources.delete);
                    this.alertControlInfo.Show(this, info);
                }

                // refresh
                AggiornaGriglie();

                StaticInfo.DataAgg(barStaticItemInfo);
            }
        }

        private void ribbon_ApplicationButtonClick(object sender, EventArgs e)
        {
            Process.Start("http://www.xpsoft.it");
        }

        private void barButtonItemPivotOfferta_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (RibbonFormPivotOfferta offerta = new RibbonFormPivotOfferta())
            {
                offerta.ShowDialog(this);
            }
        }

        private void barButtonItemPassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (XtraFormCambiaPassword password = new XtraFormCambiaPassword())
            {
                password.ShowDialog(this);
            }
        }

        //private void chartControl1_CustomDrawAxisLabel(object sender, DevExpress.XtraCharts.CustomDrawAxisLabelEventArgs e)
        //{
        //    if (e.Item.Axis == (this.chartControl1.Diagram as XYDiagram).AxisX)
        //    {
        //        switch (e.Item.Text)
        //        {
        //            case "1":
        //                e.Item.Text = "1.Lun";
        //                break;
        //            case "2":
        //                e.Item.Text = "2.Mar";
        //                break;
        //            case "3":
        //                e.Item.Text = "3.Mer";
        //                break;
        //            case "4":
        //                e.Item.Text = "4.Gio";
        //                break;
        //            case "5":
        //                e.Item.Text = "5.Ven";
        //                break;
        //            case "6":
        //                e.Item.Text = "6.Sab";
        //                break;
        //            case "7":
        //                e.Item.Text = "7.Dom";
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //}

        private void barButtonItemPivotEntrate_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (RibbonFormPivotEntrate stampe = new RibbonFormPivotEntrate())
            {
                stampe.ShowDialog(this);
            }
        }

        private bool _DeviSincronizzareIn = false;
        private bool _DeviSincronizzareOut = false;
        private void backgroundWorkerPush_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Program.ProceduraDiServizioPostLogon();

            while (!this.backgroundWorkerPush.CancellationPending)
            {
                //for (int i = 0; i < 180; i++)
                //{
                //    Thread.Sleep(1000);
                //    if (this.backgroundWorkerPush.CancellationPending) return;
                //}

                //if (EsistonoMieiBigliettiSulServer(Program.Postazione.SyncSuccess.AddMinutes(-30)))
                //    _DeviSincronizzareIn = true;

                for (int i = 0; i < 180; i++)
                {
                    Thread.Sleep(1000);
                    if (this.backgroundWorkerPush.CancellationPending) return;
                }

                if (BigliettiPerAltriMuseiDopoIl(Program.Postazione.SyncSuccess))
                    _DeviSincronizzareOut = true;

                // per la seconda postazione del castello estense, nosync, ma controlla se il principale e' sincronizzato
                if (StaticInfo.NoSync())
                {
                    var info = StaticInfo.NoSyncInfo();
                    if (!string.IsNullOrEmpty(info[4]))
                    {
                        using (UnitOfWork uow = new UnitOfWork())
                        {
                            var master = uow.FindObject<Postazione>(new BinaryOperator("MachineName", info[4]));
                            if (master == null || master.SyncSuccess < DateTime.Now.AddMinutes(-25))
                                backgroundWorkerPush.ReportProgress(30, "Master non sincronizzato!");
                        }
                    }
                }
            }
        }

        private void backgroundWorkerPush_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 10)
            {
                DevExpress.XtraBars.Alerter.AlertInfo info = new DevExpress.XtraBars.Alerter.AlertInfo("ERRORE", String.Format("10: ERRORE: {0}", e.UserState), Properties.Resources.delete);
                this.alertControlInfo.Show(this, info);
            }

            if (e.ProgressPercentage == 20)
            {
                DevExpress.XtraBars.Alerter.AlertInfo info = new DevExpress.XtraBars.Alerter.AlertInfo("ERRORE", String.Format("20: ERRORE: {0}", e.UserState), Properties.Resources.delete);
                this.alertControlInfo.Show(this, info);
            }

            if (e.ProgressPercentage == 30)
            {
                DevExpress.XtraBars.Alerter.AlertInfo info = new DevExpress.XtraBars.Alerter.AlertInfo("ERRORE", String.Format("30: ERRORE: {0}", e.UserState), Properties.Resources.delete);
                this.alertControlInfo.Show(this, info);
            }
        }

        private void barButtonItemVersamenti_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (RibbonFormVersamenti form = new RibbonFormVersamenti())
            {
                form.ShowDialog(this);
            }
        }

        private void barButtonItemReport01_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (XtraFormReport01 form = new XtraFormReport01())
            {
                form.ShowDialog(this);
            }
        }

        private void barButtonItemReport02_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (XtraFormReport02 form = new XtraFormReport02())
            {
                form.ShowDialog(this);
            }
        }

        private void barButtonItemPivotRiga_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (RibbonFormPivotRigaIngresso stampe = new RibbonFormPivotRigaIngresso())
            {
                stampe.ShowDialog(this);
            }
        }

        private void barButtonItemInserimentoStorico_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (RibbonFormStoricoInserimento form = new RibbonFormStoricoInserimento())
            {
                form.ShowDialog(this);
            }
        }

        private void barButtonItemReport03b_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (XtraFormReport03b form = new XtraFormReport03b())
            {
                form.ShowDialog(this);
            }
        }

        private void barButtonItemReport01b_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (XtraFormReport01b form = new XtraFormReport01b())
            {
                form.ShowDialog(this);
            }
        }

        private void barButtonItemReportBv1_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (XtraFormReportBv1 form = new XtraFormReportBv1())
            {
                form.ShowDialog(this);
            }
        }

        private void barButtonItemReportBv2_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (XtraFormReportBv2 form = new XtraFormReportBv2())
            {
                form.ShowDialog(this);
            }
        }

        private void barButtonItemReport03_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (XtraFormReport03 form = new XtraFormReport03())
            {
                form.ShowDialog(this);
            }
        }

        private void barButtonItemCalendarioAperture_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (XtraFormCalendarioAperture form = new XtraFormCalendarioAperture())
            {
                form.ShowDialog(this);
            }
        }

        private void barButtonItemReport04_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (XtraFormReport04 form = new XtraFormReport04())
            {
                form.ShowDialog(this);
            }
        }

        private void barButtonItemReport06_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (XtraFormReport06 form = new XtraFormReport06())
            {
                form.ShowDialog(this);
            }
        }

        private void barButtonItemEventi_ItemClick(object sender, ItemClickEventArgs e)
        {
            //using (RibbonFormCalendario form = new RibbonFormCalendario())
            //{
            //    form.InitGenerale();
            //    form.ShowDialog(this);
            //}
        }

        private void barButtonItemElencoCard_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (RibbonFormElencoCard form = new RibbonFormElencoCard())
            {
                form.ShowDialog(this);
            }
        }

        private void barButtonItemReport01t_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (XtraFormReport01t form = new XtraFormReport01t())
            {
                form.ShowDialog(this);
            }
        }

        private void gridControlCardMyFE_DoubleClick(object sender, EventArgs e)
        {
            this.gridControlCardMyFE.ShowRibbonPrintPreview();
        }

        private void barButtonItemReport07_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (XtraFormReport07 form = new XtraFormReport07())
            {
                form.ShowDialog(this);
            }
        }

        private void barButtonItemPivotCard_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (RibbonFormPivotCard form = new RibbonFormPivotCard())
            {
                form.ShowDialog(this);
            }
        }

        private void barButtonItemTransazioni_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (RibbonFormElencoTransazioni form = new RibbonFormElencoTransazioni())
            {
                form.ShowDialog(this);
            }
        }

    }
}