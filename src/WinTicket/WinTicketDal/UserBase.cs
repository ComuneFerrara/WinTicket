using System;
using DevExpress.Xpo;

namespace Musei.Module
{
    [NonPersistent]
    public class UserBase : ObjectDomainBase
    {
        private string m_FullName;
        [Indexed(Unique=true)]
        public string FullName
        {
            get
            {
                return m_FullName;
            }
            set
            {
                SetPropertyValue("FullName", ref m_FullName, value);
            }
        }

        private string m_username;
        public string Username
        {
            get
            {
                return m_username;
            }
            set
            {
                SetPropertyValue("Username", ref m_username, value);
            }
        }

        private string m_adUsername;
        public string AdUsername
        {
            get
            {
                return m_adUsername;
            }
            set
            {
                SetPropertyValue("AdUsername", ref m_adUsername, value);
            }
        }

        private string m_password;
        public string Password
        {
            get
            {
                return m_password;
            }
            set
            {
                SetPropertyValue("Password", ref m_password, value);
            }
        }

        public UserBase(Session session) : base(session)
        {
        }
    }
}
