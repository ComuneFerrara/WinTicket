using System;
using System.Collections.Generic;
using Musei.Module;
using WinTicketNext.CostruzionePercorso.GestionePrenotazione;
using DevExpress.Data.Filtering;
using DevExpress.XtraReports.UI;

namespace WinTicketNext.CostruzionePercorso
{
    public class ReportHelper
    {
        public static void Print(Vendita vendita)
        {
            foreach (Stampa item in vendita.Stampe)
            {
                Print(item);
            }
        }

        private static void Print(Stampa stampa)
        {
            if (stampa.TipoStampa == EnumTipoStampa.Standard)
            {
                XtraReportStampa2 report = new XtraReportStampa2();
                report.xpCollection1.Criteria = new BinaryOperator("Oid", stampa.Oid);

                report.ShowPrintMarginsWarning = false;
                report.ShowPrintStatusDialog = false;

                if (string.IsNullOrEmpty(Program.Postazione.PrinterName))
                    report.ShowPreview();
                else
                    report.Print(Program.Postazione.PrinterName);
            }

            if (stampa.TipoStampa == EnumTipoStampa.Card)
            {
                XtraReportStampaMyFe report = new XtraReportStampaMyFe();
                report.xpCollection1.Criteria = new BinaryOperator("Oid", stampa.Oid);

                report.ShowPrintMarginsWarning = false;
                report.ShowPrintStatusDialog = false;

                if (string.IsNullOrEmpty(Program.Postazione.PrinterName))
                    report.ShowPreview();
                else
                    report.Print(Program.Postazione.PrinterName);
            }

            if (stampa.TipoStampa == EnumTipoStampa.CardInternet)
            {
                XtraReportStampaMyFeOnline report = new XtraReportStampaMyFeOnline();
                report.xpCollection1.Criteria = new BinaryOperator("Oid", stampa.Oid);

                report.ShowPrintMarginsWarning = false;
                report.ShowPrintStatusDialog = false;

                if (string.IsNullOrEmpty(Program.Postazione.PrinterName))
                    report.ShowPreview();
                else
                    report.Print(Program.Postazione.PrinterName);
            }

            if (stampa.TipoStampa == EnumTipoStampa.CardAlbergatori)
            {
                XtraReportStampaMyFeAlberghi report = new XtraReportStampaMyFeAlberghi();
                report.xpCollection1.Criteria = new BinaryOperator("Oid", stampa.Oid);

                report.ShowPrintMarginsWarning = false;
                report.ShowPrintStatusDialog = false;

                if (string.IsNullOrEmpty(Program.Postazione.PrinterName))
                    report.ShowPreview();
                else
                    report.Print(Program.Postazione.PrinterName);
            }
        }
    }
}
