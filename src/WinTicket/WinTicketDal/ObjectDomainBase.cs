using System;
using DevExpress.Xpo;

namespace Musei.Module
{
    [NonPersistent]
    public class ObjectDomainBase : XPBaseObject
    {
        private Guid m_Oid;
        [Key(true)]
        public Guid Oid
        {
            get
            {
                return m_Oid;
            }
            set
            {
                SetPropertyValue("Oid", ref m_Oid, value);
            }
        }

        private string m_ModificatoDa;
        public string ModificatoDa
        {
            get
            {
                return m_ModificatoDa;
            }
            set
            {
                SetPropertyValue("ModificatoDa", ref m_ModificatoDa, value);
            }
        }

        private DateTime m_ModificatoIl;
        public DateTime ModificatoIl
        {
            get
            {
                return m_ModificatoIl;
            }
            set
            {
                SetPropertyValue("ModificatoIl", ref m_ModificatoIl, value);
            }
        }

        private string m_creatoDa;
        public string CreatoDa
        {
            get
            {
                return m_creatoDa;
            }
            set
            {
                SetPropertyValue("CreatoDa", ref m_creatoDa, value);
            }
        }

        private DateTime m_creatoIl;
        [Indexed]
        public DateTime CreatoIl
        {
            get
            {
                return m_creatoIl;
            }
            set
            {
                SetPropertyValue("CreatoIl", ref m_creatoIl, value);
            }
        }

        public static bool Diversi(ObjectDomainBase a, ObjectDomainBase b)
        {
            if (a == null && b == null)
                return false;
            if (a == null && b != null)
                return true;
            if (a != null && b == null)
                return true;
            if (a.Oid == b.Oid)
                return false;
            else
                return true;
        }

        protected override XPCollection<T> CreateCollection<T>(DevExpress.Xpo.Metadata.XPMemberInfo property)
        {
            XPCollection<T> retvalue = base.CreateCollection<T>(property);
            retvalue.CollectionChanged += new XPCollectionChangedEventHandler(OnCollectionChanged);
            return retvalue;
        }

        protected void OnCollectionChanged(object sender, XPCollectionChangedEventArgs e)
        {
            UpdateTotals();
        }

        public virtual void UpdateTotals() 
        {

        }

        public ObjectDomainBase(Session session)
            : base(session)
        {
            this.Changed += new ObjectChangeEventHandler(ObjectDomainBase_Changed);
        }

        void ObjectDomainBase_Changed(object sender, ObjectChangeEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.PropertyName))
                needUpdate = true;
        }

        public static string CurrentUserName
        {
            get
            {
                return CurrentUser == null ? Environment.UserName : CurrentUser.FullName;
            }
        }

        public static UserBase CurrentUser
        {
            get; set;
        }

        [NonPersistent]
        private bool needUpdate = false;

        protected override void OnSaving()
        {
            UserBase account = CurrentUser;
            if (account == null)
            {
                if (SavingEvent != null)
                {
                    ObjectInfo info = new ObjectInfo { Session = this.Session, Object = this };

                    SavingEvent.Invoke(this, info);

                    account = info.User;
                }
            }

            if (account != null)
            {
                this.ModificatoIl = DateTime.Now;
                this.ModificatoDa = account.FullName;

                if (string.IsNullOrEmpty(this.CreatoDa))
                {
                    this.CreatoIl = DateTime.Now;
                    this.CreatoDa = account.FullName;
                }
            }

            if (needUpdate)
            {
                UpdateTotals();
                needUpdate = false;
            }

            base.OnSaving();
        }

        public static event EventHandler<ObjectInfo> SavingEvent;
    }
}
