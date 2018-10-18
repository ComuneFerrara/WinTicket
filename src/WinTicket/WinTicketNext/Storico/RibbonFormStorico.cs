using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.Data.Filtering;
using DevExpress.XtraPrinting;
using System.IO;
using System.Diagnostics;
using Musei.Module;
using DevExpress.Xpo;

namespace WinTicketNext.Storico
{
    public partial class RibbonFormStorico : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonFormStorico()
        {
            InitializeComponent();

            this.Text = String.Format("Win Ticket Next ({0})", Program.UtenteCollegato.FullName);

            this.barEditItemAlla.EditValue = DateTime.Now.Date;
            this.barEditItemDalla.EditValue = DateTime.Now.Date;

            this.barCheckItemPostazione.Caption = string.Format("Solo questa postazione ({0})", Program.Postazione.Nome);
            this.barCheckItemUtente.Caption = string.Format("Solo questo utente ({0})", Program.UtenteCollegato.FullName);

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

                GroupOperator criteria1 = new GroupOperator(new CriteriaOperator[]
                {
                    new BinaryOperator("DataContabile", inizio, BinaryOperatorType.GreaterOrEqual),
                    new BinaryOperator("DataContabile", fine, BinaryOperatorType.LessOrEqual)
                });

                GroupOperator criteria2 = new GroupOperator(new CriteriaOperator[]
                {
                    new BinaryOperator("Vendita.DataContabile", inizio, BinaryOperatorType.GreaterOrEqual),
                    new BinaryOperator("Vendita.DataContabile", fine, BinaryOperatorType.LessOrEqual)
                });

                GroupOperator criteriaFatture = new GroupOperator(new CriteriaOperator[]
                {
                    new BinaryOperator("DataContabile", inizio, BinaryOperatorType.GreaterOrEqual),
                    new BinaryOperator("DataContabile", fine, BinaryOperatorType.LessOrEqual)
                });

                if (this.barCheckItemUtente.Checked)
                {
                    criteria1.Operands.Add(new BinaryOperator("Utente.Oid", Program.UtenteCollegato.Oid));
                    criteria2.Operands.Add(new BinaryOperator("Vendita.Utente.Oid", Program.UtenteCollegato.Oid));
                    criteriaFatture.Operands.Add(new BinaryOperator("Utente.Oid", Program.UtenteCollegato.Oid));
                }

                if (this.barCheckItemPostazione.Checked)
                {
                    criteria1.Operands.Add(new BinaryOperator("Postazione.Oid", Program.Postazione.Oid));
                    criteria2.Operands.Add(new BinaryOperator("Vendita.Postazione.Oid", Program.Postazione.Oid));
                    
                }
                else
                {
                    GroupOperator pos1 = new GroupOperator(GroupOperatorType.Or);
                    GroupOperator pos2 = new GroupOperator(GroupOperatorType.Or);
                    GroupOperator pos3 = new GroupOperator(GroupOperatorType.Or);

                    XPCollection<Postazione> postazioni = Program.UtenteCollegato.GetMioElencoPostazioni(this.unitOfWork1, Program.Postazione);
                    foreach (Postazione postazione in postazioni)
                    {
                        pos1.Operands.Add(new BinaryOperator("Postazione.Oid", postazione.Oid));
                        pos2.Operands.Add(new BinaryOperator("Vendita.Postazione.Oid", postazione.Oid));
                        pos3.Operands.Add(new BinaryOperator("Postazione.Oid", Program.Postazione.Oid));
                    }

                    criteria1.Operands.Add(pos1);
                    criteria2.Operands.Add(pos2);
                    criteriaFatture.Operands.Add(pos2);
                }

                this.xpServerCollectionSourceVendite.FixedFilterCriteria = criteria1;
                this.xpCollectionRigaVenditaVariante.Criteria = criteria2;
                this.xpCollectionFatture.Criteria = criteriaFatture;

                this.gridViewVendite.BestFitMaxRowCount = 50;
                this.gridViewVendite.BestFitColumns();

                this.gridViewRigheStampa.BestFitMaxRowCount = 50;
                this.gridViewRigheStampa.BestFitColumns();

                this.gridViewFatture.BestFitMaxRowCount = 50;
                this.gridViewFatture.BestFitColumns();

                this.xtraTabPageFatture.Text = string.Format("Fatture emesse ({0})", this.xpCollectionFatture.Count);

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

        private void barButtonItemStampa_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.gridControlVendite.ShowPrintPreview();
        }

        private void gridControlVendite_DoubleClick(object sender, EventArgs e)
        {
            Vendita vendita = this.gridViewVendite.GetFocusedRow() as Vendita;
            if (vendita != null)
            {
                XtraFormDettaglioVendita dettaglio = new XtraFormDettaglioVendita();
                dettaglio.Init(vendita);
                if (dettaglio.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.xpServerCollectionSourceVendite.Reload();
                    this.xpCollectionRigaVenditaVariante.Reload();
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
                        this.xpServerCollectionSourceVendite.Reload();
                        this.xpCollectionRigaVenditaVariante.Reload();
                    }
                }
            }
        }

        private void ribbon_ApplicationButtonClick(object sender, EventArgs e)
        {
            Process.Start("http://www.xpsoft.it");
        }

        private void barButtonItemGoBonus_ItemClick(object sender, ItemClickEventArgs e)
        {
            string id = this.barEditItemID.EditValue.ToString();
            string num = this.barEditItemQta.EditValue.ToString();

            int qta = int.Parse(num);
            CodiceSconto cs = this.unitOfWork1.FindObject<CodiceSconto>(new BinaryOperator("Codice", String.Format("%{0}", id), BinaryOperatorType.Like));

            if (MessageBox.Show(string.Format("id={0}, qta={1}", cs.Descrizione, qta), "conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (RigaVenditaVariante item in this.xpCollectionRigaVenditaVariante)
                {
                    if (qta == 0) break;

                    if (item.Titolo != null && item.Titolo.Bonus() && item.CodiceSconto == null)
                    {
                        if (item.Quantita <= qta)
                        {
                            item.CodiceSconto = cs;
                            item.Save();

                            qta -= item.Quantita;
                        }
                    }
                }
                MessageBox.Show(String.Format("Qta Rimanente: {0}", qta));
                this.unitOfWork1.CommitChanges();
            }
        }

        private void barButtonItemClear_ItemClick(object sender, ItemClickEventArgs e)
        {
            RigaVenditaVariante riga = this.gridViewRigheStampa.GetFocusedRow() as RigaVenditaVariante;
            if (riga != null)
            {
                riga.CodiceSconto = null;
                riga.Save();
                this.unitOfWork1.CommitChanges();
            }
        }

        private void barButtonItemNewInvoice_ItemClick(object sender, ItemClickEventArgs e)
        {
            Vendita vendita = this.gridViewVendite.GetFocusedRow() as Vendita;
            if (vendita != null)
            {
                Fattura fattura = null;
                if (vendita.Fatture.Count > 0)
                    fattura = vendita.Fatture[0];

                XtraFormCreaFattura dettaglio = new XtraFormCreaFattura();
                dettaglio.Init(vendita, fattura);

                if (dettaglio.ShowDialog(this) == DialogResult.OK)
                {
                    this.xpServerCollectionSourceVendite.Reload();
                    this.xpCollectionRigaVenditaVariante.Reload();
                    this.xpCollectionFatture.Reload();
                }
            }
        }

        private void gridViewFatture_DoubleClick(object sender, EventArgs e)
        {
            Fattura fattura = this.gridViewFatture.GetFocusedRow() as Fattura;
            if (fattura != null)
            {
                XtraFormCreaFattura dettaglio = new XtraFormCreaFattura();
                dettaglio.Init(fattura.Vendita, fattura);

                if (dettaglio.ShowDialog(this) == DialogResult.OK)
                {
                    this.xpServerCollectionSourceVendite.Reload();
                    this.xpCollectionRigaVenditaVariante.Reload();
                    this.xpCollectionFatture.Reload();
                }
            }
        }

    }
}