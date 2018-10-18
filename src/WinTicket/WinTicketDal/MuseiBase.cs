using System;
using DevExpress.Xpo;

namespace Musei.Module
{
    [NonPersistent]
    public class MuseiBase : ObjectDomainBase
    {
        public MuseiBase(Session session)
            : base(session)
        {
        }   
    }
}
