using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Musei.Module;
using DevExpress.Data.Filtering;
using WinTicketNext.Storico.RepVersamenti;
using System.Diagnostics;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using DevExpress.Xpo;
using DevExpress.XtraReports.UI;

namespace WinTicketNext.Storico
{
    public partial class RibbonFormVersamenti : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonFormVersamenti()
        {
            InitializeComponent();

            this.repositoryItemLookUpEditStruttura.DataSource = Program.UtenteCollegato.GetMioElencoStrutture(this.unitOfWork1, Program.Postazione);
            this.barEditItem1.EditValue = this.unitOfWork1.GetObjectByKey<Struttura>(Program.Postazione.Struttura.Oid);

            this.barEditItemMese.EditValue = DateTime.Now.AddMonths(-1).Month;
            this.barEditItemAnno.EditValue = (decimal)DateTime.Now.Year;

            _Internet = false;
            if (Program.UtenteCollegato.SoggettoEconomico.RagioneSociale.ToUpper().Contains("COMUNE"))
                _Comune = true;
            if (Program.UtenteCollegato.SoggettoEconomico.RagioneSociale.ToUpper().Contains("PROVINCIA"))
                _Provincia = true;
        }

        private Struttura _Struttura;
        private DateTime _Inizio;
        private DateTime _Fine;
        private bool _Comune = false;
        private bool _Provincia = false;
        private bool _Internet = false;

        private bool Parametri()
        {
            _Struttura = this.barEditItem1.EditValue as Struttura;
            _Inizio = new DateTime((int)(decimal)this.barEditItemAnno.EditValue, (int)this.barEditItemMese.EditValue, 1);

            _Fine = _Inizio.AddMonths(1).AddDays(-1);

            _Comune = false;
            _Provincia = false;

            if (_Struttura.Descrizione.Contains("Online"))
                _Internet = true;

            if (_Struttura.SoggettoEconomico.RagioneSociale.ToUpper().Contains("COMUNE"))
                _Comune = true;
            if (_Struttura.SoggettoEconomico.RagioneSociale.ToUpper().Contains("PROVINCIA"))
                _Provincia = true;

            return _Struttura != null;
        }

        private void barButtonItemRegistraVersamento_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Parametri())
            {
                using (XtraFormCreaVersamento cform = new XtraFormCreaVersamento())
                {
                    cform.Init(_Struttura, _Inizio, _Fine);
                    if (cform.ShowDialog(this) == DialogResult.OK)
                        barButtonItemQuery_ItemClick(null, null);
                }
            }
        }

        private void Abilita(bool enable)
        {
            foreach (BarItemLink itemLink in this.ribbonPageGroupOperazioni.ItemLinks)
            {
                itemLink.Item.Enabled = enable;
            }
            foreach (BarItemLink itemLink in this.ribbonPageGroupReports.ItemLinks)
            {
                itemLink.Item.Enabled = enable;
            }
            foreach (BarItemLink itemLink in this.ribbonPageGroupAltre.ItemLinks)
            {
                itemLink.Item.Enabled = enable;
            }

            if (!Program.UtenteCollegato.Amministratore)
            {
                if (_Comune)
                {
                    this.barButtonItemVersamentoManuale.Enabled = false;
                }
                if (_Provincia)
                {
                    this.barButtonItemRegistraVersamento.Enabled = false;
                }
            }
        }

        private void barButtonItemQuery_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Parametri())
            {
                DateTime dataagg = Postazione.DataSicuroAggiornamento();

                if (dataagg <= _Fine)
                    XtraMessageBox.Show(string.Format("Attenzione: alcune biglietterie non hanno ancora conferito i dati per il periodo indicato. Data sicuro aggiornamento: {0:d}", Postazione.DataSicuroAggiornamento()), "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.xpCollectionVersamenti.Criteria =
                    new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                    new BinaryOperator("Struttura.Oid", _Struttura.Oid),
                    new BinaryOperator("FinePeriodo", _Inizio, BinaryOperatorType.GreaterOrEqual),
                    new BinaryOperator("FinePeriodo", _Fine, BinaryOperatorType.LessOrEqual)});

                this.gridViewVersamenti.BestFitColumns();

                Abilita(true);
            }
        }

        private void ribbon_ApplicationButtonClick(object sender, EventArgs e)
        {
            Process.Start(@"http://www.xpsoft.it");
        }

        private void barButtonItemElimina_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Parametri())
            {
                Versamento versamento = this.gridViewVersamenti.GetFocusedRow() as Versamento;
                if (versamento != null)
                {
                    XPCollection gruppo = this.xpCollectionVersamenti;
                    if (versamento.Gruppo != Guid.Empty)
                        gruppo = new XPCollection(this.unitOfWork1, typeof(Versamento), new BinaryOperator("Gruppo", versamento.Gruppo));

                    if (XtraMessageBox.Show(string.Format("Confermi l'eliminazione del gruppo selezionato composto da {0} registrazioni ?", gruppo.Count), "Eliminazione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.unitOfWork1.Delete(gruppo);
                        this.unitOfWork1.CommitChanges();

                        this.xpCollectionVersamenti.Reload();
                    }
                }
            }
        }

        private void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {
            Abilita(false);
        }

        private void barEditItemMese_EditValueChanged(object sender, EventArgs e)
        {
            Abilita(false);
        }

        private void barEditItemAnno_EditValueChanged(object sender, EventArgs e)
        {
            Abilita(false);
        }

        private void barButtonItemReportQ1_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ReportQ1(3);
            if (Parametri())
            {
                using (XtraFormReportQ1 form = new XtraFormReportQ1())
                {
                    form.Init(_Inizio, _Struttura);
                    form.ShowDialog(this);
                }
            }
        }

        private void gridControlVersamenti_DoubleClick(object sender, EventArgs e)
        {
            Versamento versamento = this.gridViewVersamenti.GetFocusedRow() as Versamento;
            if (versamento != null)
            {
                if (versamento.Tipologia == EnumTipologiaVersamento.Incasso_Pos)
                {
                    using (XtraFormQuietanzaPos form = new XtraFormQuietanzaPos())
                    {
                        form.Init(versamento);
                        if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                            this.unitOfWork1.CommitChanges();
                        else
                            versamento.Reload();
                    }
                }

                if (versamento.Tipologia == EnumTipologiaVersamento.Incasso_Contanti || versamento.Tipologia == EnumTipologiaVersamento.Incasso_Contanti_AltriEnti || versamento.Tipologia == EnumTipologiaVersamento.Versamento_AdAltriEnti || versamento.Tipologia == EnumTipologiaVersamento.FondoCassa_Versamento)
                {
                    using (XtraFormQuietanzaContanti form = new XtraFormQuietanzaContanti())
                    {
                        form.Init(versamento);
                        if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                            this.unitOfWork1.CommitChanges();
                        else
                            versamento.Reload();
                    }
                }
            }
        }

        private void barButtonItemVersamentoAltriEnti_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (XtraFormAltriEnti form = new XtraFormAltriEnti())
            {
                form.Init(_Struttura);
                if (form.ShowDialog(this) == DialogResult.OK)
                    this.xpCollectionVersamenti.Reload();
            }
        }


        private void barButtonItemReport1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Parametri())
            {
                using (XtraFormReportSituazione form = new XtraFormReportSituazione())
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        if (_Internet)
                        {
                            XtraReportSituazioneInternet report = new XtraReportSituazioneInternet();

                            report.Init(_Struttura, _Inizio, _Fine);
                            report.Init(form);

                            report.ShowRibbonPreviewDialog();

                            return;
                        }

                        if (_Comune)
                        {
                            if (form.moltipos)
                            {
                                XtraReportSituazione2 report = new XtraReportSituazione2();

                                report.Init(_Struttura, _Inizio, _Fine);
                                report.Init(form);

                                report.ShowRibbonPreviewDialog();
                            }
                            else
                            {
                                XtraReportSituazione report = new XtraReportSituazione();

                                report.Init(_Struttura, _Inizio, _Fine);
                                report.Init(form);

                                report.ShowRibbonPreviewDialog();
                            }
                        }

                        if (_Provincia)
                        {
                            XtraReportSituazioneProv report = new XtraReportSituazioneProv();

                            report.Init(_Struttura, _Inizio, _Fine);
                            report.Init(form);

                            report.ShowRibbonPreviewDialog();
                        }
                    }
                }
            }
        }

        private void barButtonItemVersamentoManuale_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Parametri())
            {
                using (XtraFormCreaVersamentoManuale cform = new XtraFormCreaVersamentoManuale())
                {
                    cform.Init(_Struttura, _Inizio, _Fine);
                    if (cform.ShowDialog(this) == DialogResult.OK)
                        barButtonItemQuery_ItemClick(null, null);
                }
            }
        }

        private void barButtonItemCorrispettivi_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Parametri())
            {
                DateTime dataagg = Postazione.DataSicuroAggiornamento();

                if (dataagg <= _Fine)
                    XtraMessageBox.Show(string.Format("Attenzione: alcune biglietterie non hanno ancora conferito i dati per il periodo indicato. Data sicuro aggiornamento: {0:d}", Postazione.DataSicuroAggiornamento()), "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                XPCollection<Vendita> vendite = new XPCollection<Vendita>(this.unitOfWork1, new GroupOperator(new CriteriaOperator[] {
                    new BinaryOperator("Struttura", _Struttura),
                    new BinaryOperator("DataContabile", _Inizio, BinaryOperatorType.GreaterOrEqual),
                    new BinaryOperator("DataContabile", _Fine, BinaryOperatorType.LessOrEqual)}));

                if (_Struttura.Descrizione == "Biglietteria Online")
                {
                    XtraReportCorrispettiviInternet rcs = new XtraReportCorrispettiviInternet();
                    rcs.Init(vendite, _Inizio, _Fine, _Struttura);

                    rcs.ShowRibbonPreview();
                }
                else
                {
                    XtraReportCorrispettiviBiglietteria rcs = new XtraReportCorrispettiviBiglietteria();
                    rcs.Init(vendite, _Inizio, _Fine, _Struttura);

                    rcs.ShowRibbonPreview();
                }
            }
        }
    }
}