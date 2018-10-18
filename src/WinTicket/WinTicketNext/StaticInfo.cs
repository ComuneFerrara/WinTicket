using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraBars;
using Musei.Module;
using DevExpress.XtraEditors;

namespace WinTicketNext
{
    public class StaticInfo
    {
        public static void DataAgg(BarStaticItem item)
        {
            DateTime data = Postazione.DataSicuroAggiornamento();
            item.Caption = string.Format("Dati aggiornati a {0:F}", data);
            if ((DateTime.Now - data).TotalMinutes > 60)
                item.Glyph = WinTicketNext.Properties.Resources.sign_warning_BF_16_P;
            else
                item.Glyph = WinTicketNext.Properties.Resources.about_BF_16_P;
        }

        public static bool UpdateSchema()
        {
            if (Program.Postazione != null) return (Program.Postazione.SyncMode == EnumSyncMode.NoSync);

            string machine = Environment.MachineName.ToUpper();
            if (machine == "PC01") return true;
            if (machine == "HDE01") return true;

            return false;
        }


        public static bool NoSync()
        {
            if (Program.Postazione != null) return (Program.Postazione.SyncMode == EnumSyncMode.NoSync);

            string machine = Environment.MachineName.ToUpper();
            if (machine == "BIGLCASTELLO1") return true;
            if (machine == "PC01") return true;
            if (machine == "HDE01") return true;
            if (machine == "NBPC03") return true;
            if (machine == "DESKTOP-M8KML64") return true;

            return false;
        }

        internal static string[] NoSyncInfo()
        {
            string machine = Environment.MachineName.ToUpper();
            switch (machine)
            {
                //case "BIGLIETTERIA2":
                //    return new string[] { @"192.168.0.20", "sa", "1863487103" };
                case "DESKTOP-M8KML64":
                    return new string[] { "192.168.0.20", "sa", "xxx", "MuseiXafRev1locale", null };
                case "BIGLCASTELLO1":
                    return new string[] { "192.168.0.10", "sa", "xxx", "MuseiXafRev1locale", "BIGLIETTERIA2" };
                case "PC01":
                    return new string[] { "hde01", "sa", "xxx", "MuseiXafTest1", null };
                case "HDE01":
                    return new string[] { "(local)", "sa", "xxx", "MuseiXafTest1", null };
                case "NBPC03":
                    return new string[] { "(local)", "sa", "xxx", "MuseiXafRev1locale", null };
                default:
                    XtraMessageBox.Show("Errore di configurazione. Avvisare l'assistenza.", "Errore", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return new string[] { @"(local)\SQLEXPRESS", null, null, null };
            }
        }
    }
}
