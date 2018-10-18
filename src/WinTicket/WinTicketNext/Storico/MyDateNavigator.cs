using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraScheduler;

namespace WinTicketNext.Storico
{
    public class MyDateNavigator : DateNavigator
    {
        public DateTime MyStartDate
        {
            get
            {
                return StartDate;
            }
        }
        public DateTime MyEndDate
        {
            get
            {
                return EndDate;
            }
        }
    }
}
