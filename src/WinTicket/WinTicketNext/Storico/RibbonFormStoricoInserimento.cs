using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.Data.Filtering;
using DevExpress.XtraPrinting;
using System.IO;
using System.Diagnostics;
using Musei.Module;
using DevExpress.XtraEditors;

namespace WinTicketNext.Storico
{
    public partial class RibbonFormStoricoInserimento : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonFormStoricoInserimento()
        {
            InitializeComponent();

            this.Text = String.Format("Win Ticket Next ({0})", Program.UtenteCollegato.FullName);

            repositoryItemLookUpEditIngresso.DataSource = Program.UtenteCollegato.GetMioElencoIngressi(this.unitOfWork1, Program.Postazione);

            this.barEditItemAlla.EditValue = DateTime.Today.AddDays(-1);
            this.barEditItemDalla.EditValue = DateTime.Today.AddDays(-1);

            StaticInfo.DataAgg(this.barStaticItemInfo);
        }

        private void barButtonItemQuery_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor saveCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                StaticInfo.DataAgg(this.barStaticItemInfo);

                DateTime inizio = (DateTime)this.barEditItemDalla.EditValue;
                DateTime fine = (DateTime)this.barEditItemAlla.EditValue;

                Ingresso ingresso = barEditItemIngressi.EditValue as Ingresso;

                //GroupOperator criteria1 = new GroupOperator(
                //    new CriteriaOperator[]{
                //        new BinaryOperator("DataContabile", inizio, BinaryOperatorType.GreaterOrEqual),
                //        new BinaryOperator("DataContabile", fine, BinaryOperatorType.LessOrEqual)
                //    });

                GroupOperator criteria4 = new GroupOperator(
                    new CriteriaOperator[] {
                        new BinaryOperator("Variante.TipologiaTre", EnumTipologiaTre.CardMyFE, BinaryOperatorType.Equal),
                        new BinaryOperator("Variante.TipologiaDue", EnumTipologiaDue.Omaggio, BinaryOperatorType.Equal)
                    });

                GroupOperator criteria3 = new GroupOperator(GroupOperatorType.Or,
                    new CriteriaOperator[] {
                        new BinaryOperator("Variante.TipologiaTre", EnumTipologiaTre.CardMyFE, BinaryOperatorType.NotEqual),
                        criteria4
                    });

                GroupOperator criteria2 = new GroupOperator(
                    new CriteriaOperator[] {
                    new BinaryOperator("Vendita.DataContabile", inizio, BinaryOperatorType.GreaterOrEqual),
                    new BinaryOperator("Vendita.DataContabile", fine, BinaryOperatorType.LessOrEqual),
                    CriteriaOperator.Parse("Variante.Biglietto.Percorso.Ingressi[Oid=?]", ingresso.Oid),
                    criteria3
                });

                //this.xpServerCollectionSourceVendite.FixedFilterCriteria = criteria1;
                this.xpCollectionRigaVenditaVariante.Criteria = criteria2;

                this.gridViewRigheStampa.BestFitMaxRowCount = 50;
                this.gridViewRigheStampa.BestFitColumns();

                foreach (BarItemLink itemLink in this.ribbonPageGroupInvia.ItemLinks)
                {
                    itemLink.Item.Enabled = true;
                }

                foreach (BarItemLink itemLink in this.ribbonPageGroupOperazioni.ItemLinks)
                {
                    itemLink.Item.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        
            finally
            {
                Cursor.Current = saveCursor;
            }
        }

        private void barButtonItemExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (saveFileDialogXls.ShowDialog(this) == DialogResult.OK)
            {
                this.gridControlRigheStampa.ExportToXls(saveFileDialogXls.FileName, new XlsExportOptions(TextExportMode.Value));
                if (File.Exists(saveFileDialogXls.FileName))
                {
                    Process.Start(saveFileDialogXls.FileName);
                }
            }
        }

        private void gridViewRigheStampa_DoubleClick(object sender, EventArgs e)
        {
            RigaVenditaVariante riga = this.gridViewRigheStampa.GetFocusedRow() as RigaVenditaVariante;
            if (riga != null)
            {
                Vendita vendita = riga.Vendita;
                if (vendita != null)
                {
                    XtraFormDettaglioVendita dettaglio = new XtraFormDettaglioVendita();
                    dettaglio.Init(vendita);

                    if (dettaglio.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        //this.xpServerCollectionSourceVendite.Reload();
                        this.xpCollectionRigaVenditaVariante.Reload();
                    }
                }
            }
        }

        private void barButtonItemAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (XtraFormInserimentoStorico inserimento = new XtraFormInserimentoStorico())
            {
                DateTime inizio = (DateTime)this.barEditItemDalla.EditValue;
                DateTime fine = (DateTime)this.barEditItemAlla.EditValue;
                Ingresso ingresso = barEditItemIngressi.EditValue as Ingresso;

                inserimento.Init(ingresso, inizio, fine);

                if (inserimento.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    //this.xpServerCollectionSourceVendite.Reload();
                    this.xpCollectionRigaVenditaVariante.Reload();
                }
            }
        }

        private void ribbon_ApplicationButtonClick(object sender, EventArgs e)
        {
            Process.Start("http://www.xpsoft.it");
        }

        private void barEditItemIngressi_EditValueChanged(object sender, EventArgs e)
        {
            foreach (BarItemLink itemLink in this.ribbonPageGroupInvia.ItemLinks)
            {
                itemLink.Item.Enabled = false;
            }

            foreach (BarItemLink itemLink in this.ribbonPageGroupOperazioni.ItemLinks)
            {
                itemLink.Item.Enabled = false;
            }
        }

        private void barEditItemDalla_EditValueChanged(object sender, EventArgs e)
        {
            barEditItemIngressi_EditValueChanged(null, null);
        }

        private void barEditItemAlla_EditValueChanged(object sender, EventArgs e)
        {
            barEditItemIngressi_EditValueChanged(null, null);
        }

        private void barButtonItemStampa_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.gridControlRigheStampa.ShowRibbonPrintPreview();
        }
    }
}