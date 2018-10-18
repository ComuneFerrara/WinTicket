namespace WinTicketNext.CostruzionePercorso.GestionePrenotazione
{
    partial class RibbonFormPrenotazione2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RibbonFormPrenotazione2));
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barStaticItemInfo1 = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItemPiuGiorni = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMenoGiorni = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAllDay = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemInfo = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemConferma = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItemInfo2 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemInfo3 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemInfoG = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemInfoS = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.xtraTabControlIngressi = new DevExpress.XtraTab.XtraTabControl();
            this.imageCollectionStatus = new DevExpress.Utils.ImageCollection(this.components);
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.schedulerControlPrenotazioni = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerStoragePrenotazioni = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.xpCollectionPrenotazioni = new DevExpress.Xpo.XPCollection(this.components);
            this.unitOfWork1 = new DevExpress.Xpo.UnitOfWork(this.components);
            this.xpCollectionRisorse = new DevExpress.Xpo.XPCollection(this.components);
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.timerTick = new System.Windows.Forms.Timer(this.components);
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlIngressi)).BeginInit();
            this.xtraTabControlIngressi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControlPrenotazioni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStoragePrenotazioni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollectionPrenotazioni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollectionRisorse)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonText = null;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barStaticItemInfo1,
            this.barButtonItemPiuGiorni,
            this.barButtonItemMenoGiorni,
            this.barButtonItemAllDay,
            this.barButtonItemInfo,
            this.barButtonItemConferma,
            this.barStaticItemInfo2,
            this.barStaticItemInfo3,
            this.barStaticItem1,
            this.barStaticItemInfoG,
            this.barStaticItemInfoS});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 32;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(778, 144);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // barStaticItemInfo1
            // 
            this.barStaticItemInfo1.Caption = "info";
            this.barStaticItemInfo1.Id = 0;
            this.barStaticItemInfo1.Name = "barStaticItemInfo1";
            this.barStaticItemInfo1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonItemPiuGiorni
            // 
            this.barButtonItemPiuGiorni.Caption = "+ Giorni";
            this.barButtonItemPiuGiorni.Id = 22;
            this.barButtonItemPiuGiorni.Name = "barButtonItemPiuGiorni";
            this.barButtonItemPiuGiorni.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemPiuGiorni_ItemClick);
            // 
            // barButtonItemMenoGiorni
            // 
            this.barButtonItemMenoGiorni.Caption = "- Giorni";
            this.barButtonItemMenoGiorni.Id = 23;
            this.barButtonItemMenoGiorni.Name = "barButtonItemMenoGiorni";
            this.barButtonItemMenoGiorni.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemMenoGiorni_ItemClick);
            // 
            // barButtonItemAllDay
            // 
            this.barButtonItemAllDay.Caption = "Giornata Intera";
            this.barButtonItemAllDay.Id = 24;
            this.barButtonItemAllDay.Name = "barButtonItemAllDay";
            this.barButtonItemAllDay.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAllDay_ItemClick);
            // 
            // barButtonItemInfo
            // 
            this.barButtonItemInfo.Caption = "Salva Prenotazione";
            this.barButtonItemInfo.Id = 25;
            this.barButtonItemInfo.LargeGlyph = global::WinTicketNext.Properties.Resources.floppy_disk_yellow;
            this.barButtonItemInfo.Name = "barButtonItemInfo";
            this.barButtonItemInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemInfo_ItemClick);
            // 
            // barButtonItemConferma
            // 
            this.barButtonItemConferma.Caption = "Stampa Prenotazione";
            this.barButtonItemConferma.Id = 26;
            this.barButtonItemConferma.LargeGlyph = global::WinTicketNext.Properties.Resources.printer;
            this.barButtonItemConferma.Name = "barButtonItemConferma";
            this.barButtonItemConferma.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemConferma_ItemClick);
            // 
            // barStaticItemInfo2
            // 
            this.barStaticItemInfo2.Caption = "info";
            this.barStaticItemInfo2.Id = 27;
            this.barStaticItemInfo2.Name = "barStaticItemInfo2";
            this.barStaticItemInfo2.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItemInfo3
            // 
            this.barStaticItemInfo3.Caption = "info";
            this.barStaticItemInfo3.Glyph = global::WinTicketNext.Properties.Resources.bullet_ball_green;
            this.barStaticItemInfo3.Id = 28;
            this.barStaticItemInfo3.Name = "barStaticItemInfo3";
            this.barStaticItemInfo3.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Web Services:";
            this.barStaticItem1.Id = 29;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItemInfoG
            // 
            this.barStaticItemInfoG.Caption = "TipoGS:";
            this.barStaticItemInfoG.Id = 30;
            this.barStaticItemInfoG.Name = "barStaticItemInfoG";
            this.barStaticItemInfoG.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItemInfoS
            // 
            this.barStaticItemInfoS.Caption = "Scuola:";
            this.barStaticItemInfoS.Id = 31;
            this.barStaticItemInfoS.Name = "barStaticItemInfoS";
            this.barStaticItemInfoS.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup1,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Prenotazione";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItemInfo, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItemConferma, true);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Prenotazione";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemAllDay);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemPiuGiorni, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemMenoGiorni);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Visualizza";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barStaticItem1);
            this.ribbonPageGroup3.ItemLinks.Add(this.barStaticItemInfo3);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Query";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItemInfoG);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItemInfoS, true);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItemInfo1, true);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItemInfo2, true);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItemInfo3, true);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 620);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(778, 31);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.splitContainerControl1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 144);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(778, 476);
            this.clientPanel.TabIndex = 2;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.xtraTabControlIngressi);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.schedulerControlPrenotazioni);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(778, 476);
            this.splitContainerControl1.SplitterPosition = 141;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // xtraTabControlIngressi
            // 
            this.xtraTabControlIngressi.AppearancePage.Header.Options.UseTextOptions = true;
            this.xtraTabControlIngressi.AppearancePage.Header.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.xtraTabControlIngressi.AppearancePage.HeaderActive.Options.UseTextOptions = true;
            this.xtraTabControlIngressi.AppearancePage.HeaderActive.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.xtraTabControlIngressi.AppearancePage.HeaderDisabled.Options.UseTextOptions = true;
            this.xtraTabControlIngressi.AppearancePage.HeaderDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.xtraTabControlIngressi.AppearancePage.HeaderHotTracked.Options.UseTextOptions = true;
            this.xtraTabControlIngressi.AppearancePage.HeaderHotTracked.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.xtraTabControlIngressi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlIngressi.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.xtraTabControlIngressi.Images = this.imageCollectionStatus;
            this.xtraTabControlIngressi.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlIngressi.Name = "xtraTabControlIngressi";
            this.xtraTabControlIngressi.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControlIngressi.Size = new System.Drawing.Size(778, 141);
            this.xtraTabControlIngressi.TabIndex = 0;
            this.xtraTabControlIngressi.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            this.xtraTabControlIngressi.TabStop = false;
            this.xtraTabControlIngressi.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControlIngressi_SelectedPageChanged);
            // 
            // imageCollectionStatus
            // 
            this.imageCollectionStatus.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionStatus.ImageStream")));
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(772, 113);
            this.xtraTabPage1.Text = "museo civico della nave romana in comacchio";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(772, 113);
            this.xtraTabPage2.Text = "Mueso della cattedrala in convento";
            // 
            // schedulerControlPrenotazioni
            // 
            this.schedulerControlPrenotazioni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControlPrenotazioni.Location = new System.Drawing.Point(0, 0);
            this.schedulerControlPrenotazioni.MenuManager = this.ribbon;
            this.schedulerControlPrenotazioni.Name = "schedulerControlPrenotazioni";
            this.schedulerControlPrenotazioni.OptionsBehavior.ShowRemindersForm = false;
            this.schedulerControlPrenotazioni.OptionsCustomization.AllowAppointmentCopy = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControlPrenotazioni.OptionsCustomization.AllowAppointmentDrag = DevExpress.XtraScheduler.UsedAppointmentType.Custom;
            this.schedulerControlPrenotazioni.OptionsCustomization.AllowAppointmentDragBetweenResources = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControlPrenotazioni.OptionsCustomization.AllowAppointmentMultiSelect = false;
            this.schedulerControlPrenotazioni.OptionsCustomization.AllowAppointmentResize = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControlPrenotazioni.OptionsCustomization.AllowInplaceEditor = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControlPrenotazioni.OptionsView.ToolTipVisibility = DevExpress.XtraScheduler.ToolTipVisibility.Always;
            this.schedulerControlPrenotazioni.Size = new System.Drawing.Size(778, 330);
            this.schedulerControlPrenotazioni.Start = new System.DateTime(2008, 12, 29, 0, 0, 0, 0);
            this.schedulerControlPrenotazioni.Storage = this.schedulerStoragePrenotazioni;
            this.schedulerControlPrenotazioni.TabIndex = 0;
            this.schedulerControlPrenotazioni.Text = "schedulerControl1";
            this.schedulerControlPrenotazioni.ToolTipController = this.toolTipController1;
            this.schedulerControlPrenotazioni.Views.DayView.Appearance.AllDayArea.Options.UseTextOptions = true;
            this.schedulerControlPrenotazioni.Views.DayView.Appearance.AllDayArea.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.schedulerControlPrenotazioni.Views.DayView.DayCount = 7;
            this.schedulerControlPrenotazioni.Views.DayView.ShowWorkTimeOnly = true;
            timeRuler1.ShowMinutes = true;
            this.schedulerControlPrenotazioni.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControlPrenotazioni.Views.MonthView.Enabled = false;
            this.schedulerControlPrenotazioni.Views.TimelineView.Enabled = false;
            this.schedulerControlPrenotazioni.Views.WeekView.Enabled = false;
            this.schedulerControlPrenotazioni.Views.WorkWeekView.Enabled = false;
            this.schedulerControlPrenotazioni.Views.WorkWeekView.NavigationButtonVisibility = DevExpress.XtraScheduler.NavigationButtonVisibility.Never;
            this.schedulerControlPrenotazioni.Views.WorkWeekView.ShowAllDayArea = false;
            this.schedulerControlPrenotazioni.Views.WorkWeekView.ShowFullWeek = true;
            this.schedulerControlPrenotazioni.Views.WorkWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControlPrenotazioni.AllowAppointmentDrag += new DevExpress.XtraScheduler.AppointmentOperationEventHandler(this.schedulerControlPrenotazioni_AllowAppointmentDrag);
            this.schedulerControlPrenotazioni.AppointmentDrag += new DevExpress.XtraScheduler.AppointmentDragEventHandler(this.schedulerControlPrenotazioni_AppointmentDrag);
            this.schedulerControlPrenotazioni.EditAppointmentFormShowing += new DevExpress.XtraScheduler.AppointmentFormEventHandler(this.schedulerControlPrenotazioni_EditAppointmentFormShowing);
            this.schedulerControlPrenotazioni.CustomDrawTimeCell += new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.schedulerControlPrenotazioni_CustomDrawTimeCell);
            this.schedulerControlPrenotazioni.CustomDrawDayViewAllDayArea += new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.schedulerControlPrenotazioni_CustomDrawDayViewAllDayArea);
            // 
            // schedulerStoragePrenotazioni
            // 
            this.schedulerStoragePrenotazioni.Appointments.DataSource = this.xpCollectionPrenotazioni;
            this.schedulerStoragePrenotazioni.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192))))), "None", "&None"));
            this.schedulerStoragePrenotazioni.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(194)))), ((int)(((byte)(190))))), "Important", "&Important"));
            this.schedulerStoragePrenotazioni.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(213)))), ((int)(((byte)(255))))), "Business", "&Business"));
            this.schedulerStoragePrenotazioni.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(244)))), ((int)(((byte)(156))))), "Personal", "&Personal"));
            this.schedulerStoragePrenotazioni.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(228)))), ((int)(((byte)(199))))), "Vacation", "&Vacation"));
            this.schedulerStoragePrenotazioni.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(206)))), ((int)(((byte)(147))))), "Must Attend", "Must &Attend"));
            this.schedulerStoragePrenotazioni.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(244)))), ((int)(((byte)(255))))), "Travel Required", "&Travel Required"));
            this.schedulerStoragePrenotazioni.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(152))))), "Needs Preparation", "&Needs Preparation"));
            this.schedulerStoragePrenotazioni.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(207)))), ((int)(((byte)(233))))), "Birthday", "&Birthday"));
            this.schedulerStoragePrenotazioni.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(233)))), ((int)(((byte)(223))))), "Anniversary", "&Anniversary"));
            this.schedulerStoragePrenotazioni.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(165))))), "Phone Call", "Phone &Call"));
            this.schedulerStoragePrenotazioni.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.Gainsboro, "Disabled"));
            this.schedulerStoragePrenotazioni.Appointments.Mappings.AllDay = "AllDay";
            this.schedulerStoragePrenotazioni.Appointments.Mappings.Description = "Description";
            this.schedulerStoragePrenotazioni.Appointments.Mappings.End = "EndDate";
            this.schedulerStoragePrenotazioni.Appointments.Mappings.Label = "Label";
            this.schedulerStoragePrenotazioni.Appointments.Mappings.Location = "Location";
            this.schedulerStoragePrenotazioni.Appointments.Mappings.ResourceId = "Ingresso!";
            this.schedulerStoragePrenotazioni.Appointments.Mappings.Start = "StartDate";
            this.schedulerStoragePrenotazioni.Appointments.Mappings.Status = "Status";
            this.schedulerStoragePrenotazioni.Appointments.Mappings.Subject = "Subject";
            this.schedulerStoragePrenotazioni.Appointments.Mappings.Type = "AppointmentType";
            this.schedulerStoragePrenotazioni.EnableReminders = false;
            this.schedulerStoragePrenotazioni.Resources.DataSource = this.xpCollectionRisorse;
            this.schedulerStoragePrenotazioni.Resources.Mappings.Caption = "Descrizione";
            this.schedulerStoragePrenotazioni.Resources.Mappings.Id = "This";
            this.schedulerStoragePrenotazioni.AppointmentsChanged += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStoragePrenotazioni_AppointmentsChanged);
            this.schedulerStoragePrenotazioni.AppointmentDeleting += new DevExpress.XtraScheduler.PersistentObjectCancelEventHandler(this.schedulerStoragePrenotazioni_AppointmentDeleting);
            // 
            // xpCollectionPrenotazioni
            // 
            this.xpCollectionPrenotazioni.DeleteObjectOnRemove = true;
            this.xpCollectionPrenotazioni.DisplayableProperties = resources.GetString("xpCollectionPrenotazioni.DisplayableProperties");
            this.xpCollectionPrenotazioni.LoadingEnabled = false;
            this.xpCollectionPrenotazioni.ObjectType = typeof(Musei.Module.Prenotazione);
            this.xpCollectionPrenotazioni.Session = this.unitOfWork1;
            // 
            // unitOfWork1
            // 
            this.unitOfWork1.TrackPropertiesModifications = false;
            // 
            // xpCollectionRisorse
            // 
            this.xpCollectionRisorse.DisplayableProperties = "This;Oid;ModificatoDa;ModificatoIl;Descrizione;Prenotazione;DurataSlot;CapacitaSl" +
    "ot;Percorsi";
            this.xpCollectionRisorse.ObjectType = typeof(Musei.Module.Ingresso);
            this.xpCollectionRisorse.Session = this.unitOfWork1;
            // 
            // toolTipController1
            // 
            this.toolTipController1.AutoPopDelay = 4000;
            this.toolTipController1.ToolTipType = DevExpress.Utils.ToolTipType.Standard;
            this.toolTipController1.BeforeShow += new DevExpress.Utils.ToolTipControllerBeforeShowEventHandler(this.toolTipController1_BeforeShow);
            // 
            // timerTick
            // 
            this.timerTick.Enabled = true;
            this.timerTick.Interval = 250;
            this.timerTick.Tick += new System.EventHandler(this.timerTick_Tick);
            // 
            // alertControl1
            // 
            this.alertControl1.AllowHtmlText = true;
            this.alertControl1.AutoHeight = true;
            this.alertControl1.ShowToolTips = false;
            // 
            // RibbonFormPrenotazione2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 651);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Name = "RibbonFormPrenotazione2";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Prenotazione";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RibbonFormPrenotazione2_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlIngressi)).EndInit();
            this.xtraTabControlIngressi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControlPrenotazioni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStoragePrenotazioni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollectionPrenotazioni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollectionRisorse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private DevExpress.XtraBars.BarStaticItem barStaticItemInfo1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControlIngressi;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.Utils.ImageCollection imageCollectionStatus;
        private DevExpress.XtraScheduler.SchedulerControl schedulerControlPrenotazioni;
        private DevExpress.XtraBars.BarButtonItem barButtonItemPiuGiorni;
        private DevExpress.XtraBars.BarButtonItem barButtonItemMenoGiorni;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAllDay;
        private DevExpress.XtraBars.BarButtonItem barButtonItemInfo;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barButtonItemConferma;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStoragePrenotazioni;
        private DevExpress.Xpo.UnitOfWork unitOfWork1;
        private DevExpress.Xpo.XPCollection xpCollectionRisorse;
        private DevExpress.Xpo.XPCollection xpCollectionPrenotazioni;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraBars.BarStaticItem barStaticItemInfo2;
        private System.Windows.Forms.Timer timerTick;
        private DevExpress.XtraBars.BarStaticItem barStaticItemInfo3;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private DevExpress.XtraBars.BarStaticItem barStaticItemInfoG;
        private DevExpress.XtraBars.BarStaticItem barStaticItemInfoS;
    }
}