using System;
using DevExpress.Data.Filtering;
using Musei.Module;
using DevExpress.XtraEditors.Controls;
using DevExpress.Xpo;
using System.Windows.Forms;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace WinTicketNext.Storico
{
    public partial class XtraFormAskReportPostazione : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormAskReportPostazione()
        {
            InitializeComponent();

            this.dateEditGiorno.DateTime = DateTime.Now.Date;
            this.dateEditFine.DateTime = DateTime.Now.Date;

            using (XPCollection<Postazione> postazioni = Program.UtenteCollegato.GetMioElencoPostazioni(this.unitOfWork1, Program.Postazione))
            {
                postazioni.Sorting = new SortingCollection(new SortProperty[] { new SortProperty("Ingresso.Descrizione", DevExpress.Xpo.DB.SortingDirection.Ascending) });

                foreach (Postazione postazione in postazioni)
                {
                    bool found = false;
                    foreach (CheckedListBoxItem item in this.checkedListBoxControlPostazioni.Items)
                    {
                        if (item.Description == postazione.Ingresso.Descrizione)
                            found = true;
                    }

                    if (!found)
                    {
                        if (Program.Postazione.Ingresso.Descrizione == postazione.Ingresso.Descrizione)
                            this.checkedListBoxControlPostazioni.Items.Add(postazione, postazione.Ingresso.Descrizione, CheckState.Checked, true);
                        else
                            this.checkedListBoxControlPostazioni.Items.Add(postazione, postazione.Ingresso.Descrizione, CheckState.Unchecked, true);
                    }
                }
            }
        }

        private void simpleButtonStampa_Click(object sender, EventArgs e)
        {
            if (this.checkedListBoxControlPostazioni.CheckedItems.Count > 0)
            {
                DateTime dataInizio = this.dateEditGiorno.DateTime.Date;
                DateTime dataFine = this.dateEditFine.DateTime.Date;

                XtraReportPostazione5 report = new XtraReportPostazione5();
                report.ImpostaData(dataInizio, dataFine);

                CriteriaOperator criteria = new GroupOperator(GroupOperatorType.And,
                    new CriteriaOperator[] { 
                    new BinaryOperator("Vendita.DataContabile", dataInizio, BinaryOperatorType.GreaterOrEqual), 
                    new BinaryOperator("Vendita.DataContabile", dataFine, BinaryOperatorType.LessOrEqual) });

                criteria = GetPostazioni(criteria);

                report.AddData(new XPCollection<RigaVenditaVariante>(this.unitOfWork1, criteria), ElencoPostazioni());
                //report.Postazioni(ElencoPostazioni());

                report.CreateDocument();
                report.ShowRibbonPreviewDialog();
            } else
                XtraMessageBox.Show("Selezionare almeno un ingresso", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private CriteriaOperator GetPostazioni(CriteriaOperator original)
        {
            GroupOperator op = new GroupOperator(GroupOperatorType.Or);
            for (int i = 0; i < this.checkedListBoxControlPostazioni.CheckedItems.Count; i++)
            {
                Postazione item = (Postazione)this.checkedListBoxControlPostazioni.CheckedItems[i];
                op.Operands.Add(new BinaryOperator("Vendita.Postazione.Ingresso.Oid", item.Ingresso.Oid));
            }

            if (op.Operands.Count == 0)
                return original;
            else
                return new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                    op,original});
        }

        private List<Postazione> ElencoPostazioni()
        {
            List<Postazione> elenco = new List<Postazione>();
            for (int i = 0; i < this.checkedListBoxControlPostazioni.CheckedItems.Count; i++)
            {
                Postazione item = (Postazione)this.checkedListBoxControlPostazioni.CheckedItems[i];

                XPCollection<Postazione> queste = new XPCollection<Postazione>(this.unitOfWork1, new BinaryOperator("Ingresso", item.Ingresso));
                elenco.AddRange(queste);
            }

            return elenco;
        }
    }
}