using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.Replication;
using Microsoft.SqlServer.Management.Common;

namespace MergeSyncLib
{
    public class ReplicamenteInfo
    {
        public int ModificheSub { get; set; }
        public int ModifichePub { get; set; }
        public int ConflittiSub { get; set; }
        public int ConflittiPub { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Info { get; set; }
        public bool Result { get; set; }

        public int Durata()
        {
            TimeSpan times = this.DateEnd - this.DateStart;
            return (int)(times.TotalSeconds / 2);
        }
    }
}
