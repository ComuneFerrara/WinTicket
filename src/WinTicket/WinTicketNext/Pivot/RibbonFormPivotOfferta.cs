using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.IO;
using System.Diagnostics;
using DevExpress.Data.Filtering;
using Musei.Module;
using DevExpress.XtraPrinting;
using DevExpress.Utils;
using System.Collections;
using System.Collections.Generic;
using WinTicketNext.Pivot;
using DevExpress.Xpo;

namespace WinTicketNext
{
    public partial class RibbonFormPivotOfferta : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonFormPivotOfferta()
        {
            InitializeComponent();

            foreach (DevExpress.XtraPivotGrid.PivotGridField field in this.pivotGridControlStampe.Fields)
            {
                field.ToolTips.HeaderText = field.FieldName;
            }
        }

        private void barButtonItemExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (saveFileDialogXls.ShowDialog(this) == DialogResult.OK)
            {
                this.pivotGridControlStampe.ExportToXls(saveFileDialogXls.FileName, new XlsExportOptions(TextExportMode.Value));
                if (File.Exists(saveFileDialogXls.FileName))
                {
                    Process.Start(saveFileDialogXls.FileName);
                }
            }
        }

        private void barButtonItemPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.pivotGridControlStampe.ShowPrintPreview();
        }

        private void GetNewCriteria()
        {
            if (this.checkedListBoxControl1.CheckedItems.Count > 0)
            {
                List<PivotOffertaItem> elenco = new List<PivotOffertaItem>();
                XPCollection<Titolo> titoli = new XPCollection<Titolo>(this.unitOfWork1);

                foreach (Percorso percorso in this.checkedListBoxControl1.CheckedItems)
                {
                    foreach (Biglietto itemBig in percorso.BigliettiValidi)
                    {
                        foreach (Variante itemVar in itemBig.Varianti)
                        {
                            if (itemVar.ElencoTitoli.Count == 0)
                            {
                                PivotOffertaItem npivot = new PivotOffertaItem();
                                npivot.Percorso = percorso.Descrizione;
                                npivot.Titolo = " SENZA TITOLI";
                                npivot.Gruppo = "";
                                npivot.TipologiaUno = itemVar.TipologiaUno;
                                npivot.TipologiaDue = itemVar.TipologiaDue;
                                npivot.TipologiaTre = itemVar.TipologiaTre;
                                npivot.Importo = itemVar.PrezzoAttuale.Prezzo;

                                elenco.Add(npivot);
                            }
                            else
                            {
                                foreach (Titolo itemTit in itemVar.ElencoTitoli)
                                {
                                    PivotOffertaItem npivot = new PivotOffertaItem();
                                    npivot.Percorso = percorso.Descrizione;
                                    npivot.Titolo = itemTit.Descrizione;
                                    npivot.Gruppo = itemTit.Gruppo;
                                    npivot.TipologiaUno = itemVar.TipologiaUno;
                                    npivot.TipologiaDue = itemVar.TipologiaDue;
                                    npivot.TipologiaTre = itemVar.TipologiaTre;
                                    npivot.Importo = itemVar.PrezzoAttuale.Prezzo;

                                    elenco.Add(npivot);
                                }
                            }
                        }
                    }
                }

                this.pivotGridControlStampe.DataSource = elenco;
            }
        }

        private void simpleButtonQuery_Click(object sender, EventArgs e)
        {
            Cursor saveCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                GetNewCriteria();

                this.pivotGridControlStampe.BestFit();
            }
            finally
            {
                Cursor.Current = saveCursor;
            }
        }

        private void barButtonItemLoadLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.openFileDialogXML.ShowDialog(this) == DialogResult.OK)
            {
                this.pivotGridControlStampe.RestoreLayoutFromXml(this.openFileDialogXML.FileName, OptionsLayoutBase.FullLayout);
                this.pivotGridControlStampe.BestFit();

                //barCheckItemCols.Checked = this.pivotGridControlStampe.OptionsView.ShowColumnGrandTotals;
                //barCheckItemRow.Checked = this.pivotGridControlStampe.OptionsView.ShowRowGrandTotals;
                //this.chartControl1.Enabled = barCheckItemGrafico.Checked;
            }
        }

        private void barButtonItemSaveLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.saveFileDialogXML.ShowDialog(this) == DialogResult.OK)
            {
                this.pivotGridControlStampe.SaveLayoutToXml(this.saveFileDialogXML.FileName, OptionsLayoutBase.FullLayout);
            }
        }

        private void barButtonShowFields_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.pivotGridControlStampe.FieldsCustomization();
        }

        private void barButtonItemBestFit_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.pivotGridControlStampe.BestFit();
        }

        private void ribbon_ApplicationButtonClick(object sender, EventArgs e)
        {
            Process.Start("http://www.xpsoft.it");
        }
    }
}

