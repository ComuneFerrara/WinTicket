using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Musei.Module;
using DevExpress.XtraEditors;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;

namespace WinTicketNext.Storico
{
    public partial class RibbonFormElencoCard : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonFormElencoCard()
        {
            InitializeComponent();
        }

        private XPCollection<Card> _Collection;
        private void barButtonItemQuery_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor saveCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                GroupOperator criteria1 = new GroupOperator(GroupOperatorType.Or);
                GroupOperator criteria2 = new GroupOperator(GroupOperatorType.Or);
                GroupOperator criteria = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[] { criteria1, criteria2 });

                if (this.barCheckItem2gg.Checked)
                    criteria1.Operands.Add(new BinaryOperator("TipologiaCard", EnumTipologiaCard.Card2Giorni));
                if (this.barCheckItem3gg.Checked)
                    criteria1.Operands.Add(new BinaryOperator("TipologiaCard", EnumTipologiaCard.Card3Giorni));
                if (this.barCheckItem6gg.Checked)
                    criteria1.Operands.Add(new BinaryOperator("TipologiaCard", EnumTipologiaCard.Card6Giorni));

                if (this.barCheckItemEmesse.Checked)
                    criteria2.Operands.Add(new BinaryOperator("Status", EnumStatoCard.Emessa));
                if (this.barCheckItemAssegnate.Checked)
                    criteria2.Operands.Add(new BinaryOperator("Status", EnumStatoCard.Assegnata));
                if (this.barCheckItemNuova.Checked)
                    criteria2.Operands.Add(new BinaryOperator("Status", EnumStatoCard.Nuova));
                if (this.barCheckItemSoppresse.Checked)
                    criteria2.Operands.Add(new BinaryOperator("Status", EnumStatoCard.Soppressa));

                if (this.barEditItemDalla.EditValue != null)
                {
                    var dt = (DateTime)this.barEditItemDalla.EditValue;
                    criteria.Operands.Add(new BinaryOperator("Stampa.Vendita.DataContabile", dt, BinaryOperatorType.GreaterOrEqual));
                }
                if (this.barEditItemAlla.EditValue != null)
                {
                    var dt = (DateTime)this.barEditItemAlla.EditValue;
                    criteria.Operands.Add(new BinaryOperator("Stampa.Vendita.DataContabile", dt, BinaryOperatorType.LessOrEqual));
                }

                _Collection = new XPCollection<Card>(this.unitOfWork1, criteria);
                this.gridControlCard.DataSource = _Collection;

                this.gridViewCard.BestFitMaxRowCount = 100;
                this.gridViewCard.BestFitColumns();
            }
            finally
            {
                Cursor.Current = saveCursor;
            }
        }

        private void barButtonItemCestina_ItemClick(object sender, ItemClickEventArgs e)
        {
            Card card = this.gridViewCard.GetFocusedRow() as Card;
            if (card != null && !card.VendutaOnline)
            {
                if (card.Stampa != null)
                {
                    XtraMessageBox.Show("La card è inclusa in una vendita, non posso effettuare questa operazione.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (XtraMessageBox.Show(string.Format("Imposto la Card {0} come SOPPRESSA ?", card.Codice), "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        card.Status = EnumStatoCard.Soppressa;
                        card.Save();
                    }
                }
            }
        }

        private void barButtonItemRecupera_ItemClick(object sender, ItemClickEventArgs e)
        {
            Card card = this.gridViewCard.GetFocusedRow() as Card;
            if (card != null && !card.VendutaOnline)
            {
                if (card.Stampa != null)
                {
                    XtraMessageBox.Show("La card è inclusa in una vendita, non posso effettuare questa operazione.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (XtraMessageBox.Show(string.Format("Imposto la Card {0} come NUOVA ?", card.Codice), "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        card.Status = EnumStatoCard.Nuova;
                        card.Save();
                    }
                }
            }
        }

        private void barButtonItemStampa_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.gridControlCard.ShowRibbonPrintPreview();
        }

        private void barButtonItemAssegna_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraFormAssegnaCards ca = new XtraFormAssegnaCards();
            if (ca.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                barButtonItemQuery_ItemClick(null, null);
            }
        }
    }
}