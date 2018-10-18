using System;
using DevExpress.XtraReports.UI;
using Musei.Module;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.Drawing;

namespace WinTicketNext.Storico
{
    public partial class XtraReportFattura : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportFattura()
        {
            InitializeComponent();
        }


        public void Init(Fattura fattura)
        {
            Session session = new Session();

            var nfattura = session.GetObjectByKey<Fattura>(fattura.Oid);

            //this.DataSource = nfattura;

            this.xpCollectionFattura.Criteria = new BinaryOperator("Oid", nfattura.Oid);

        }

    }
}
