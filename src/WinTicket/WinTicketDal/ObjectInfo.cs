using System;
using DevExpress.Xpo;

namespace Musei.Module
{
    public class ObjectInfo : EventArgs
    {
        public Session Session { get; set; }
        public ObjectDomainBase Object { get; set; }
        public UserBase User { get; set; }
    }
}
