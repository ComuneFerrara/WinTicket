using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Musei.Module;
using DevExpress.XtraTab;
using DevExpress.XtraScheduler;
using DevExpress.Utils;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.XtraEditors;
using System.Drawing;
using PreventWebServices;
using System.Drawing.Drawing2D;
using DevExpress.XtraScheduler.Printing;

namespace WinTicketNext.CostruzionePercorso.GestionePrenotazione
{
    public partial class RibbonFormPrenotazione2 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonFormPrenotazione2()
        {
            InitializeComponent();

            MoveRibbonSchedulerControl();

            this.Text = String.Format("Win Ticket Next ({0})", Program.UtenteCollegato.FullName);
        }

        private void MoveRibbonSchedulerControl()
        {
            if (ribbon.Pages.Count >= 2)
            {
                ribbon.Pages[0].Groups.Add(ribbon.Pages[1].Groups[0]);
                ribbon.Pages[1].Visible = false;
            }

            //if (ribbon.Pages.Count >= 2)
            //{
            //    ribbon.Pages[0].Groups.Add(ribbon.Pages[2].Groups[0]);
            //    ribbon.Pages[2].Visible = false;
            //}
        }

        private List<Ingresso> m_Elenco;
        private PrenotazioneComplessiva m_Prenotazione;
        public void Init(List<Ingresso> elenco, PrenotazioneComplessiva prenotazione)
        {
            CorreggiTimeScale();

            saved = false;

            //this.xpCollectionPrenotazioni = new DevExpress.Xpo.XPCollection(this.unitOfWork1, typeof(Prenotazione));
            for (int i = this.xpCollectionPrenotazioni.Count - 1; i >= 0; i--)
            {
                this.xpCollectionPrenotazioni.Remove(this.xpCollectionPrenotazioni[i]);
            }

            m_Elenco = elenco;
            m_Prenotazione = prenotazione;
            m_Prenotazione.CollectionPrenotazione = this.xpCollectionPrenotazioni;

            GestoreCalendario.Clear(m_Prenotazione.TipoGS(), m_Prenotazione.TipoScuola(), false);

            //if (string.IsNullOrEmpty(m_Prenotazione.RiferimentoVendita))
            //{
            //    XtraFormAskInfoPrenotazione info = new XtraFormAskInfoPrenotazione();
            //    info.Init(m_Prenotazione);
            //    info.ShowDialog();
            //}

            this.xtraTabControlIngressi.BeginUpdate();
            this.xtraTabControlIngressi.TabPages.Clear();
            //int timespan = 60;

            m_Prenotazione.InitRefreshPrenotazione(m_Elenco);

            foreach (Ingresso item in m_Elenco)
            {
                XtraTabPage pagina = new XtraTabPage();
                pagina.Text = item.DescrizioneBreve;

                PrenotazioneIngresso newPrenotazioneIngresso = null;
                foreach (PrenotazioneIngresso prenotazioneIngresso in m_Prenotazione.Prenotazioni)
                {
                    if (prenotazioneIngresso.Ingresso.Oid == item.Oid)
                        newPrenotazioneIngresso = prenotazioneIngresso;
                }

                switch (item.Prenotazione)
                {
                    case EnumPrenotazioneIngresso.NonGestita:
                        pagina.Text += ": NG";
                        //pagina.ImageIndex = 0;
                        break;
                    case EnumPrenotazioneIngresso.Facoltativa:
                        pagina.Text += ": FAC";
                        pagina.ImageIndex = 1;
                        break;
                    case EnumPrenotazioneIngresso.Consigliata:
                        pagina.Text += ": CON";
                        pagina.ImageIndex = 2;
                        break;
                    case EnumPrenotazioneIngresso.Obbligatoria:
                        pagina.Text += ": OBL";
                        pagina.ImageIndex = 3;
                        break;
                }

                pagina.Tag = newPrenotazioneIngresso;
                this.xtraTabControlIngressi.TabPages.Add(pagina);

                XtraUserControlCalendario2 ucal = new XtraUserControlCalendario2();
                ucal.Init(newPrenotazioneIngresso, pagina, this.xpCollectionPrenotazioni, this.schedulerControlPrenotazioni, m_Prenotazione);
                ucal.Dock = DockStyle.Fill;
                pagina.Controls.Add(ucal);

                //if (item.DurataSlot(GestoreCalendario.TipoGS) > 0)
                //    timespan = gcd(timespan, item.DurataSlot(GestoreCalendario.TipoGS));
            }

            // attivo la tab relativa alle prenotazioni prevent
            //foreach (XtraTabPage xtraTabPage in this.xtraTabControlIngressi.TabPages)
            //{
            //    m_ActiveControl = xtraTabPage.Controls[0] as XtraUserControlCalendario2;
            //    m_ActiveControl.CreaPrenotazione(false);
            //}

            this.xtraTabControlIngressi.EndUpdate();

            this.xtraTabControlIngressi.SelectedTabPage = this.xtraTabControlIngressi.TabPages[0];
            xtraTabControlIngressi_SelectedPageChanged(null, new TabPageChangedEventArgs(null, this.xtraTabControlIngressi.TabPages[0]));

            this.barStaticItemInfo1.Caption = string.Format("{0} persone per un totale di {1:c}", m_Prenotazione.GestoreProfili.TotalePersone(), m_Prenotazione.GestoreProfili.TotaleImporto());
            this.barStaticItemInfo2.Caption = m_Prenotazione.RiferimentoVendita;
            this.barStaticItemInfoG.Caption = string.Format("TipoGS: {0}", GestoreCalendario.TipoGS);
            this.barStaticItemInfoS.Caption = string.Format("Scuola: {0}", GestoreCalendario.TipoScuola);

            // Imposta la griglia temporale
            //this.schedulerControlPrenotazioni.DayView.TimeSlots.Clear();
            //this.schedulerControlPrenotazioni.WorkWeekView.TimeSlots.Clear();

            //int durata = timespan;
            //while (durata <= 60)
            //{
            //    this.schedulerControlPrenotazioni.DayView.TimeSlots.Add(new DevExpress.XtraScheduler.TimeSlot(new TimeSpan(0, durata, 0), "slotx1"));
            //    this.schedulerControlPrenotazioni.WorkWeekView.TimeSlots.Add(new DevExpress.XtraScheduler.TimeSlot(new TimeSpan(0, durata, 0), "slotx1"));
            //    durata += timespan;
            //}

            //this.schedulerControlPrenotazioni.DayView.TimeScale = new TimeSpan(0, timespan, 0);
            //this.schedulerControlPrenotazioni.WorkWeekView.TimeScale = new TimeSpan(0, timespan, 0);

            this.schedulerControlPrenotazioni.Start = DateTime.Now.Date.AddDays(-1);
            this.schedulerControlPrenotazioni.GoToToday();

            this.schedulerControlPrenotazioni.LimitInterval.Start = DateTime.Now.Date.AddDays(-1);
            this.schedulerControlPrenotazioni.LimitInterval.End = DateTime.Now.Date.AddDays(20);

            this.schedulerControlPrenotazioni.Refresh();
        }

        private XtraUserControlCalendario2 m_ActiveControl = null;
        private void xtraTabControlIngressi_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (e.Page == null)
                return;

            // notifico di visualizzare solo la pagina corrente
            foreach (XtraTabPage xtraTabPage in this.xtraTabControlIngressi.TabPages)
            {
                if (xtraTabPage.Controls.Count == 0) continue;

                XtraUserControlCalendario2 ucal = xtraTabPage.Controls[0] as XtraUserControlCalendario2;
                if (ucal != null)
                {
                    if (ucal.NotificaAttivazione(e.Page))
                        m_ActiveControl = ucal;
                }
            }

            this.schedulerControlPrenotazioni.Refresh();
        }

        private void barButtonItemInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            //XtraFormCodiciPrenotazione codici = new XtraFormCodiciPrenotazione();
            //codici.Init(m_Elenco, m_Prenotazione);

            //if (codici.ShowDialog(this) == DialogResult.OK)
            //{
            //    // aggiorna info
            //    this.barStaticItemInfo2.Caption = m_Prenotazione.RiferimentoVendita;
            //}

            // salva la prenotazione corrente e chiude la finestra

            if (ErroreSuPrenotazione())
            {
                XtraMessageBox.Show("Ci sono errori sulle prenotazioni. Non e' possibile proseguire", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (XtraTabPage xtraTabPage in this.xtraTabControlIngressi.TabPages)
            {
                if (xtraTabPage.Controls.Count == 0) continue;

                XtraUserControlCalendario2 ucal = xtraTabPage.Controls[0] as XtraUserControlCalendario2;
                if (ucal != null)
                {
                    ucal.SalvaTutto();
                }
            }

            saved = true;
            DialogResult = DialogResult.OK;
        }

        private void schedulerControlPrenotazioni_EditAppointmentFormShowing(object sender, DevExpress.XtraScheduler.AppointmentFormEventArgs e)
        {
            Prenotazione prenotazione = e.Appointment.GetSourceObject(this.schedulerStoragePrenotazioni) as Prenotazione;
            if (prenotazione != null && prenotazione.Label != Prenotazione.LabelDisabled)
            {
                XtraFormEditPrenotazione formpre = new XtraFormEditPrenotazione();
                formpre.Init(prenotazione);

                if (formpre.ShowDialog(this) == DialogResult.OK)
                {
                    XtraUserControlCalendario2 ucal = this.xtraTabControlIngressi.SelectedTabPage.Controls[0] as XtraUserControlCalendario2;
                    ucal.NotificaAttivazione(this.xtraTabControlIngressi.SelectedTabPage);
                }
            }

            this.schedulerControlPrenotazioni.Refresh();
            e.Handled = true;
        }

        private void schedulerStoragePrenotazioni_AppointmentsChanged(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e)
        {
            foreach (Appointment item in e.Objects)
            {
                Prenotazione prenotazione = (item.GetSourceObject(this.schedulerStoragePrenotazioni) as Prenotazione);

                item.LabelId = Prenotazione.LabelDaControllare;
                item.Start = prenotazione.FixStartDate();
                item.End = prenotazione.EndDate;

                prenotazione.Notify();
            }            
        }

        private void schedulerControlPrenotazioni_AppointmentDrag(object sender, AppointmentDragEventArgs e)
        {
            if (e.SourceAppointment.LabelId == Prenotazione.LabelDisabled)
            {
                e.Handled = true;
                e.Allow = false;
            }
        }

        private void schedulerStoragePrenotazioni_AppointmentDeleting(object sender, PersistentObjectCancelEventArgs e)
        {
            Appointment apt = e.Object as Appointment;
            if (apt != null && apt.LabelId == Prenotazione.LabelDisabled)
            {
                e.Cancel = true;
            }
        }

        private void toolTipController1_BeforeShow(object sender, DevExpress.Utils.ToolTipControllerShowEventArgs e)
        {
            // Get the ToolTipController.
            ToolTipController controller = sender as ToolTipController;

            // Check, if it's an appointment or not.
            // If it's not an appointment, then exit.
            AppointmentViewInfo aptViewInfo = controller.ActiveObject as AppointmentViewInfo;
            if (aptViewInfo == null) return;

            // Set a custom icon for a tooltip.
            e.IconType = ToolTipIconType.Information;

            // Set a custom title for a tooltip.
            e.Title = aptViewInfo.Appointment.Description;

            // Set a custom text for a tooltip.
            e.ToolTip = aptViewInfo.Appointment.Subject + " (" + aptViewInfo.Appointment.Location + ")"
                + Environment.NewLine +
                aptViewInfo.Appointment.Start.ToShortTimeString() + " - " + aptViewInfo.Appointment.End.ToShortTimeString();
        }

        private void barButtonItemAllDay_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.schedulerControlPrenotazioni.DayView.ShowWorkTimeOnly = !this.schedulerControlPrenotazioni.DayView.ShowWorkTimeOnly;
            this.schedulerControlPrenotazioni.WorkWeekView.ShowWorkTimeOnly = this.schedulerControlPrenotazioni.DayView.ShowWorkTimeOnly;
        }

        private void barButtonItemPiuGiorni_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.schedulerControlPrenotazioni.ActiveView == this.schedulerControlPrenotazioni.DayView)
            {
                if (this.schedulerControlPrenotazioni.DayView.DayCount < 10)
                    this.schedulerControlPrenotazioni.DayView.DayCount++;
            }
        }

        private void barButtonItemMenoGiorni_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.schedulerControlPrenotazioni.ActiveView == this.schedulerControlPrenotazioni.DayView)
            {
                if (this.schedulerControlPrenotazioni.DayView.DayCount > 2)
                    this.schedulerControlPrenotazioni.DayView.DayCount--;
            }
        }

        private bool ErroreSuPrenotazione()
        {
            bool errore = false;
            foreach (XtraTabPage xtraTabPage in this.xtraTabControlIngressi.TabPages)
            {
                if (xtraTabPage.Controls.Count == 0) continue;

                XtraUserControlCalendario2 ucal = xtraTabPage.Controls[0] as XtraUserControlCalendario2;
                if (ucal != null)
                {
                    if (ucal.VerificaStato())
                        errore = true;
                }
            }

            return errore;
        }

        private void barButtonItemConferma_ItemClick(object sender, ItemClickEventArgs e)
        {
            // controllo ...
            if (!ErroreSuPrenotazione())
            {
                this.schedulerControlPrenotazioni.ShowPrintPreview(this.schedulerControlPrenotazioni.PrintStyles[SchedulerPrintStyleKind.CalendarDetails]);

                //XtraFormStampa stampa = new XtraFormStampa();
                //stampa.Init(m_Prenotazione);
                //if (stampa.ShowDialog(this) == DialogResult.OK)
                //{
                //    this.schedulerControlPrenotazioni.ShowPrintPreview(this.schedulerControlPrenotazioni.PrintStyles[SchedulerPrintStyleKind.CalendarDetails]);                    
                //    DialogResult = DialogResult.OK;
                //}
            }
            else
            {
                XtraMessageBox.Show("Sono presenti degli errori di prenotazione, o delle prenotazioni obbligatorie.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Font font = new Font(FontFamily.GenericMonospace, 12);
        private Brush brush_green = new SolidBrush(Color.Green);
        private Brush brush_white = new SolidBrush(Color.White);
        private Pen pen_green = new Pen(new LinearGradientBrush(new Point(0, 0), new Point(0, 4), Color.LightGray, Color.Yellow), 4);
        private void schedulerControlPrenotazioni_CustomDrawTimeCell(object sender, CustomDrawObjectEventArgs e)
        {
            SelectableIntervalViewInfo obj = e.ObjectInfo as DevExpress.XtraScheduler.Drawing.SelectableIntervalViewInfo;
            if (obj != null)
            {
                e.DrawDefault();

                if (m_ActiveControl != null && m_ActiveControl.Ingresso.CodicePrevent > 0 && m_ActiveControl.Ingresso.Prenotazione != EnumPrenotazioneIngresso.NonGestita)
                {
                    RisultatoCalendario ris = GestoreCalendario.GeneraRichiesta(obj.Interval.Start, m_ActiveControl.Ingresso.CodicePrevent);

                    if (ris != null)
                    {
                        int numero = ris.PostiDisponibili;

                        if (obj.Selected)
                            e.Graphics.DrawString(numero.ToString(), font, brush_white, e.Bounds);
                        else
                            e.Graphics.DrawString(numero.ToString(), font, brush_green, e.Bounds);

                        if (numero > 0)
                        {
                            // int massimo = Math.Max(numero, m_ActiveControl.Ingresso.CapacitaSlot(GestoreCalendario.TipoGS));
                            int massimo = Math.Max(numero, ris.MaxPostiDisponibili);
                            e.Graphics.DrawLine(pen_green, e.Bounds.X + 1, e.Bounds.Y + 16, e.Bounds.X + e.Bounds.Width * numero / massimo - 1, e.Bounds.Y + 16);
                        }
                    }
                }

                e.Handled = true;
            }            
        }

        private void CorreggiTimeScale()
        {
            int timespan = GestoreCalendario.GetTimeSpan();

            if (this.schedulerControlPrenotazioni.DayView.TimeScale.TotalMinutes != timespan)
            {
                this.schedulerControlPrenotazioni.DayView.TimeScale = new TimeSpan(0, timespan, 0);
                this.schedulerControlPrenotazioni.WorkWeekView.TimeScale = new TimeSpan(0, timespan, 0);
            }
        }

        private TaskCalendarioInfo info = new TaskCalendarioInfo();
        private int tick = 0;
        private void timerTick_Tick(object sender, EventArgs e)
        {
            tick++;

            if (GestoreCalendario.Dump(ref info) || tick > 20)
            {
                CorreggiTimeScale();

                tick = 0;
                this.schedulerControlPrenotazioni.Focus();
                this.schedulerControlPrenotazioni.Refresh();
            }

            this.barStaticItemInfo3.Caption =
                info.ElencoRichiesteEvase + " / " +
                info.ElencoRichiesteAttive + " / " +
                info.ElencoNuoveRichieste;

            if (info.ElencoRichiesteAttive > 0)
                this.barStaticItemInfo3.Glyph = Properties.Resources.bullet_ball_red;
            else
                this.barStaticItemInfo3.Glyph = Properties.Resources.bullet_ball_green;

            foreach (Exception item in info.ErroriWeb)
            {
                DevExpress.XtraBars.Alerter.AlertInfo ainfo = new DevExpress.XtraBars.Alerter.AlertInfo("ERRORE Query Calendario", string.Format("Errore {0}", item.Message), Properties.Resources.delete);
                this.alertControl1.Show(this, ainfo);
            }
        }

        private void schedulerControlPrenotazioni_AllowAppointmentDrag(object sender, AppointmentOperationEventArgs e)
        {
            if (e.Appointment.LabelId == Prenotazione.LabelDisabled)
            {
                e.Allow = false;
            }
        }

        private bool saved = false;
        private void RibbonFormPrenotazione2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved)
            {
                if (XtraMessageBox.Show("Attenzione, se hai fatto delle modifiche alla prenotazione NON verranno salvate. Chiudo la finestra ?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void schedulerControlPrenotazioni_CustomDrawDayViewAllDayArea(object sender, CustomDrawObjectEventArgs e)
        {
            AllDayAreaCell cell = (AllDayAreaCell)e.ObjectInfo;

            RisultatoCalendario ris = GestoreCalendario.GeneraRichiesta(cell.Interval.Start, m_ActiveControl.Ingresso.CodicePrevent);

            if (ris != null)
            {
                if (!string.IsNullOrEmpty(ris.InfoGiornata))
                {
                    if (cell.Selected)
                        e.Cache.FillRectangle(Brushes.LightCyan, e.Bounds);
                    else
                        e.Cache.FillRectangle(Brushes.Yellow, e.Bounds);

                    e.Cache.DrawString(ris.InfoGiornata, cell.Appearance.Font, Brushes.Black, e.Bounds, cell.Appearance.TextOptions.GetStringFormat());

                    cell.ToolTipText = String.Format("{0} : {1}", cell.Interval.Start.ToShortDateString(), ris.InfoGiornata);

                    e.Handled = true;
                }
            }
        }
    }
}