using System;

using DevExpress.Xpo;
using System.ComponentModel;
using System.Collections.Generic;

namespace Musei.Module
{
    public class TaskGroup : MuseiBase
    {
        public TaskGroup(Session session) : base(session) { }

        private string _Codice;
        public string Codice
        {
            get
            {
                return _Codice;
            }
            set
            {
                SetPropertyValue("Codice", ref _Codice, value);
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

        private decimal _Anticipo;
        public decimal Anticipo
        {
            get
            {
                return _Anticipo;
            }
            set
            {
                SetPropertyValue("Anticipo", ref _Anticipo, value);
            }
        }

        private bool _Utilizzata;
        public bool Utilizzata
        {
            get
            {
                return _Utilizzata;
            }
            set
            {
                SetPropertyValue("Utilizzata", ref _Utilizzata, value);
            }
        }

        private string _Subject;
        public string Subject
        {
            get
            {
                return _Subject;
            }
            set
            {
                SetPropertyValue("Subject", ref _Subject, value);
            }
        }

        private string _Description;
        [Size(SizeAttribute.Unlimited)]
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                SetPropertyValue("Description", ref _Description, value);
            }
        }

        [Association("TaskGroup-ElencoTask"), Aggregated]
        public XPCollection<Task> ElencoTask
        {
            get
            {
                return GetCollection<Task>("ElencoTask");
            }
        }

        protected override void OnSaving()
        {
            const string alfabeto1 = "QWERTYUIOPASDFGHJKLZXCVBNM";
            const string alfabeto2 = "0123456789";

            base.OnSaving();

            if (string.IsNullOrEmpty(Codice))
            {
                Random rnd = new Random();
                for (int i = 0; i < 2; i++)
                {
                    Codice += alfabeto1[rnd.Next(0, alfabeto1.Length)];
                }
                for (int i = 0; i < 4; i++)
                {
                    Codice += alfabeto2[rnd.Next(0, alfabeto2.Length)];
                }
            }
        }

    }
}
