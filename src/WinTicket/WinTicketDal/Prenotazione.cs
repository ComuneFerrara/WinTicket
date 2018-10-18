using System;
using DevExpress.Xpo;
using System.ComponentModel;

namespace Musei.Module
{
    public class Prenotazione : MuseiBase
    {
        public const int LabelDaControllare = 0;
        public const int LabelDisabled = 11;

        public void Notify()
        {
            Status = 2;
            Label = LabelDaControllare;
            Disponibilita = EnumDisponibilita.DaControllare;
        }

        private int m_AppointmentType;
        public int AppointmentType
        {
            get
            {
                return m_AppointmentType;
            }
            set
            {
                SetPropertyValue("AppointmentType", ref m_AppointmentType, value);
            }
        }

        private DateTime m_StartDate;
        public DateTime StartDate
        {
            get
            {
                return m_StartDate;
            }
            set
            {
                if (SetPropertyValue("StartDate", ref m_StartDate, value))
                {
                    Notify();
                    if (Ingresso != null)
                    {
                        EndDate = StartDate + new TimeSpan(0, DurataSlot, 0);
                    }
                }
            }
        }

        private DateTime m_preventStartDate;
        [NonPersistent]
        public DateTime PreventStartDate
        {
            get
            {
                return m_preventStartDate;
            }
            set
            {
                SetPropertyValue("PreventStartDate", ref m_preventStartDate, value);
            }
        }

        private DateTime m_EndDate;
        public DateTime EndDate
        {
            get
            {
                return m_EndDate;
            }
            set
            {
                if (SetPropertyValue("EndDate", ref m_EndDate, value))
                {
                    Notify();
                    if (Ingresso != null)
                    {
                        EndDate = StartDate + new TimeSpan(0, DurataSlot, 0);
                    }
                }
            }
        }

        private bool m_AllDay;
        public bool AllDay
        {
            get
            {
                return m_AllDay;
            }
            set
            {
                SetPropertyValue("AllDay", ref m_AllDay, value);
            }
        }

        private string m_Subject;
        public string Subject
        {
            get
            {
                return m_Subject;
            }
            set
            {
                SetPropertyValue("Subject", ref m_Subject, value);
            }
        }

        private string m_Location;
        public string Location
        {
            get
            {
                return m_Location;
            }
            set
            {
                SetPropertyValue("Location", ref m_Location, value);
            }
        }

        [Size(SizeAttribute.Unlimited)]
        private string m_Description;
        public string Description
        {
            get
            {
                return m_Description;
            }
            set
            {
                SetPropertyValue("Description", ref m_Description, value);
            }
        }

        private int m_Status;
        public int Status
        {
            get
            {
                return m_Status;
            }
            set
            {
                SetPropertyValue("Status", ref m_Status, value);
            }
        }

        private int m_Label;
        public int Label
        {
            get
            {
                return m_Label;
            }
            set
            {
                SetPropertyValue("Label", ref m_Label, value);
            }
        }

        private EnumDisponibilita m_disponibilita;
        public EnumDisponibilita Disponibilita
        {
            get
            {
                return m_disponibilita;
            }
            set
            {
                SetPropertyValue("Disponibilita", ref m_disponibilita, value);
            }
        }

        //[Size(SizeAttribute.Unlimited)]
        //public string RecurrenceInfo;

        //[Size(SizeAttribute.Unlimited)]
        //public string ReminderInfo;

        //[Size(SizeAttribute.Unlimited)]
        //public string CustomField1;

        //public CustomResource Resource;

        private Ingresso m_Ingresso;
        public Ingresso Ingresso
        {
            get
            {
                return m_Ingresso;
            }
            set
            {
                SetPropertyValue("Ingresso", ref m_Ingresso, value);
            }
        }

        private int m_NumeroPersone;
        public int NumeroPersone
        {
            get
            {
                return m_NumeroPersone;
            }
            set
            {
                if (SetPropertyValue("NumeroPersone", ref m_NumeroPersone, value))
                    Notify();

                Location = String.Format("pax: {0}", m_NumeroPersone);
            }
        }

        private Vendita m_vendita;
        [Association("Vendita-Prenotazioni")]
        public Vendita Vendita
        {
            get { return m_vendita; }
            set
            {
                m_vendita = value;
            }
        }

        //private RigaStampaIngresso m_RigaStampaIngresso;
        //[Association("RigaStampaIngressoPrenotazioni")]
        //public RigaStampaIngresso RigaStampaIngresso
        //{
        //    get
        //    {
        //        return m_RigaStampaIngresso;
        //    }
        //    set
        //    {
        //        SetPropertyValue("RigaStampaIngresso", ref m_RigaStampaIngresso, value);
        //    }
        //}

        private Guid m_idRichiesta;
        [NonPersistent]
        public Guid IdRichiesta
        {
            get
            {
                return m_idRichiesta;
            }
            set
            {
                SetPropertyValue("IdRichiesta", ref m_idRichiesta, value);
            }
        }

        private int m_durataSlot = 60;
        [NonPersistent]
        public int DurataSlot
        {
            get { return m_durataSlot; }
            set
            {
                m_durataSlot = value;
            }
        }

        private bool m_originataPrevent;
        [NonPersistent]
        public bool OriginataPrevent
        {
            get
            {
                return m_originataPrevent;
            }
            set
            {
                SetPropertyValue("OriginataPrevent", ref m_originataPrevent, value);
            }
        }

        public Prenotazione(Session session)
            : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.

            Status = 2;
            Label = LabelDaControllare;
            Disponibilita = EnumDisponibilita.DaControllare;
        }

        public void SetLabel(bool attivo)
        {
            if (attivo)
            {
                switch (Disponibilita)
                {
                    case EnumDisponibilita.DaControllare:
                        Label = LabelDaControllare;
                        break;
                    case EnumDisponibilita.ControlloInCorso:
                        Label = LabelDaControllare;
                        break;
                    case EnumDisponibilita.NonDisponibile:
                        Label = 1;
                        break;
                    case EnumDisponibilita.Disponibile:
                        Label = 3;
                        break;
                    case EnumDisponibilita.Errore:
                        Label = 1;
                        break;
                }
            }
            else
            {
                Label = LabelDisabled;
            }

            if (OriginataPrevent)
                Status = 3;
            else
                Status = 2;
        }

        public DateTime FixStartDate()
        {
            DateTime data = StartDate.Date;
            TimeSpan ora = StartDate.TimeOfDay;
            int minuti = (int)ora.TotalMinutes;

            int durataSlot = DurataSlot;
            if (durataSlot == 0)
                durataSlot = 60;

            minuti = (minuti / durataSlot) * durataSlot;

            return data + new TimeSpan(0, minuti, 0);
        }
    }
}