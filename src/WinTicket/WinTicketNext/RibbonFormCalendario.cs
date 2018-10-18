using System;
using System.Collections.Generic;
using DevExpress.XtraBars;
using DevExpress.XtraScheduler;
using DevExpress.Xpo;
using Musei.Module;
using DevExpress.XtraScheduler.Drawing;
using System.Drawing;
using DevExpress.Data.Filtering;

namespace WinTicketNext
{
    public partial class RibbonFormCalendario : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public TaskGroup NewTask { get; set; }
        private int PaxDefault = 1;

        public RibbonFormCalendario()
        {
            InitializeComponent();
        }

        public void InitGenerale()
        {
            XPCollection<Ingresso> alli = new XPCollection<Ingresso>(this.session1);
            foreach (Ingresso ingresso in alli)
            {
                if (ingresso.Calendario)
                    this.xpCollectionIngressi.Add(ingresso);
            }

            this.resourcesCheckedListBoxControl1.UnCheckAll();
            this.resourcesCheckedListBoxControl1.SetItemChecked(0, true);
        }

        public void InitPrenotazione(List<Ingresso> elenco, TaskGroup task, int pax)
        {
            PaxDefault = pax;

            foreach (Ingresso ingresso in elenco)
            {
                this.xpCollectionIngressi.Add(this.session1.GetObjectByKey<Ingresso>(ingresso.Oid));
            }

            this.resourcesCheckedListBoxControl1.CheckAll();
            if (task != null)
            {
                this.barButtonItemNewItem.Enabled = false;
                NewTask = this.session1.GetObjectByKey<TaskGroup>(task.Oid);
                barButtonItemSoloQuesta_ItemClick(null, null);
            }
        }

        private void schedulerStorage1_AppointmentsChanged(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e)
        {
            foreach (Appointment apt in e.Objects)
            {
                XPBaseObject o = apt.GetSourceObject(schedulerStorage1) as XPBaseObject;
                if (o != null)
                    o.Save();
            }
        }

        private void schedulerStorage1_AppointmentsInserted(object sender, PersistentObjectsEventArgs e)
        {
            foreach (Appointment apt in e.Objects)
            {
                XPBaseObject o = apt.GetSourceObject(schedulerStorage1) as XPBaseObject;
                if (o != null)
                    o.Save();
            }
        }

        private void barButtonItemNewItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (RibbonFormNuovoTask form = new RibbonFormNuovoTask())
            {
                SetDefault();

                NewTask = new TaskGroup(this.session1);
                NewTask.Pax = PaxDefault;
                
                form.Init(NewTask);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    NewTask.Save();

                    this.xpCollectionTask.Reload();
                    this.schedulerStorage1.RefreshData();
                }
            }
        }

        private void SetDefault()
        {
            Task.StartDefault = this.schedulerControl1.SelectedInterval.Start;
            if (this.schedulerControl1.SelectedResource.Id is Guid)
                Task.ResourceIdDefault = (Guid)this.schedulerControl1.SelectedResource.Id;
            else
                Task.ResourceIdDefault = Guid.Empty;
        }

        private void schedulerControl1_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            Task singletask = this.session1.GetObjectByKey<Task>(e.Appointment.Id);
            if (singletask != null)
            {
                SetDefault();

                using (RibbonFormNuovoTask form = new RibbonFormNuovoTask())
                {
                    TaskGroup taskgruppo = singletask.Gruppo;
                    form.Init(taskgruppo);
                    if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        this.xpCollectionTask.Reload();
                        this.schedulerStorage1.RefreshData();

                        NewTask = taskgruppo;
                    }
                }
            }

            e.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.schedulerControl1.Refresh();
            e.Handled = true;
        }

        private void barCheckItemOrario_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            this.schedulerControl1.WorkWeekView.ShowWorkTimeOnly = this.barCheckItemOrario.Checked;
            this.schedulerControl1.DayView.ShowWorkTimeOnly = this.barCheckItemOrario.Checked;
        }

        private void barButtonItemGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (this.schedulerControl1.GroupType)
            {
                case SchedulerGroupType.None:
                    this.schedulerControl1.GroupType = SchedulerGroupType.Date;
                    break;
                case SchedulerGroupType.Date:
                    this.schedulerControl1.GroupType = SchedulerGroupType.Resource;
                    break;
                case SchedulerGroupType.Resource:
                    this.schedulerControl1.GroupType = SchedulerGroupType.None;
                    break;
            }
        }

        private void barButtonItemModifica_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (NewTask != null)
            {
                SetDefault();

                using (RibbonFormNuovoTask form = new RibbonFormNuovoTask())
                {
                    form.Init(NewTask);
                    if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        this.xpCollectionTask.Reload();
                        this.schedulerStorage1.RefreshData();
                    }
                }
            }
        }

        private void timerTick_Tick(object sender, EventArgs e)
        {
            if (NewTask != null)
            {
                this.barButtonItemSoloQuesta.Enabled = true;
                this.barButtonItemSoloQuesta.Caption = String.Format("Vedi solo {0}", NewTask.Codice);

                this.barButtonItemModifica.Enabled = true;
                this.barButtonItemModifica.Caption = String.Format("Modifica {0}", NewTask.Codice);
            }
            else
            {
                this.barButtonItemSoloQuesta.Enabled = false;
                this.barButtonItemModifica.Caption = "Solo Questa";

                this.barButtonItemModifica.Enabled = false;
                this.barButtonItemModifica.Caption = "Modifica Prenotazione";
            }
        }

        private Font font = new Font(FontFamily.GenericMonospace, 12);
        private Brush brush_green = new SolidBrush(Color.Green);
        XPCollection<IngressoCalendario> calendario;

        private void schedulerControl1_CustomDrawTimeCell(object sender, CustomDrawObjectEventArgs e)
        {
            SelectableIntervalViewInfo obj = e.ObjectInfo as SelectableIntervalViewInfo;
            if (obj != null)
            {
                e.DrawDefault();

                if (obj.Resource.Id is Guid)
                {
                    Ingresso ingresso = obj.Resource.GetSourceObject(this.schedulerStorage1) as Ingresso;
                    if (ingresso != null && ingresso.VerificaCalendario)
                    {
                        if (calendario == null)
                            calendario = new XPCollection<IngressoCalendario>(this.session1);

                        int numero = 0;
                        if (Trova(ingresso, obj.Interval.Start, out numero))
                            e.Graphics.DrawString(numero.ToString(), font, brush_green, e.Bounds);
                    }
                }

                e.Handled = true;
            }
        }

        private bool Trova(Ingresso ingresso, DateTime dateTime, out int numero)
        {
            numero = 0;
            foreach (IngressoCalendario item in calendario)
            {
                if (item.Ingresso == ingresso && item.DataOra == dateTime)
                {
                    numero = item.PaxMax;
                    return true;
                }
            }
            return false;
        }

        private void barButtonItemSoloQuesta_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (NewTask != null)
            {
                this.xpCollectionTask.Criteria = new BinaryOperator("Gruppo.Codice", NewTask.Codice);
                this.xpCollectionTask.Reload();
            }
        }

        private void barButtonItemTutti_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.xpCollectionTask.Criteria = null;
            this.xpCollectionTask.Reload();
        }

        private void schedulerControl1_AppointmentDrop(object sender, AppointmentDragEventArgs e)
        {
            
        }
    }
}