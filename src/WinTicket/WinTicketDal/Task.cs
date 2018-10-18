using System;

using DevExpress.Xpo;
using System.ComponentModel;
using System.Collections.Generic;

namespace Musei.Module
{
    public class Task : MuseiBase
    {
        public Task(Session session) : base(session) { }

        public static DateTime StartDefault;
        public static int PaxDefault;
        public static Guid ResourceIdDefault;

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Start = StartDefault;
            Pax = PaxDefault;
            ResourceId = ResourceIdDefault;
        }

        // Appointment.AllDay
        bool _allDay;
        public bool AllDay
        {
            get { return _allDay; }
            set { SetPropertyValue("AllDay", ref _allDay, value); }
        }

        // Appointment.Description
        string _description;
        [Size(SizeAttribute.Unlimited)]
        public string Description
        {
            get { return _description; }
            set { SetPropertyValue("Description", ref _description, value); }
        }

        // Appointment.End
        DateTime _finish;
        public DateTime Finish
        {
            get { return _finish; }
            set { SetPropertyValue("Finish", ref _finish, value); }
        }

        // Appointment.Label
        int _label;
        public int Label
        {
            get { return _label; }
            set { SetPropertyValue("Label", ref _label, value); }
        }

        // Appointment.Location
        string _location;
        public string Location
        {
            get { return _location; }
            set { SetPropertyValue("Location", ref _location, value); }
        }

        // Appointment.RecurrenceInfo
        string _recurrence;
        [Size(SizeAttribute.Unlimited)]
        public string Recurrence
        {
            get { return _recurrence; }
            set { SetPropertyValue("Recurrence", ref _recurrence, value); }
        }

        // Appointment.ReminderInfo
        string _reminder;
        [Size(SizeAttribute.Unlimited)]
        public string Reminder
        {
            get { return _reminder; }
            set { SetPropertyValue("Reminder", ref _reminder, value); }
        }

        // Appointment.Start
        DateTime _start;
        public DateTime Start
        {
            get { return _start; }
            set { SetPropertyValue("Start", ref _start, value); }
        }

        // Appointment.Status
        int _status;
        public int Status
        {
            get { return _status; }
            set { SetPropertyValue("Status", ref _status, value); }
        }

        // Appointment.Subject
        string _subject;
        public string Subject
        {
            get { return _subject; }
            set { SetPropertyValue("Subject", ref _subject, value); }
        }

        // Appointment.Type
        int _appointmentType;
        public int AppointmentType
        {
            get { return _appointmentType; }
            set { SetPropertyValue("AppointmentType", ref _appointmentType, value); }
        }

        // Appointment.ResourceId
        Guid _resourceId;
        public Guid ResourceId
        {
            get { return _resourceId; }
            set { SetPropertyValue("ResourceId", ref _resourceId, value); }
        }

        private TaskGroup _Gruppo;
        [Association("TaskGroup-ElencoTask")]
        public TaskGroup Gruppo
        {
            get
            {
                return _Gruppo;
            }
            set
            {
                SetPropertyValue("Gruppo", ref _Gruppo, value);
            }
        }

        private int _Pax;
        public int Pax
        {
            get
            {
                return _Pax;
            }
            set
            {
                SetPropertyValue("Pax", ref _Pax, value);
            }
        }

        private bool _Errore;
        public bool Errore
        {
            get
            {
                return _Errore;
            }
            set
            {
                SetPropertyValue("Errore", ref _Errore, value);
            }
        }

    }
}
