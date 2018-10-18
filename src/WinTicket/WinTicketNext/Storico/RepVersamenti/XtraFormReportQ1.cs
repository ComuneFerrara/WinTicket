using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Musei.Module;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.XtraReports.UI;

namespace WinTicketNext.Storico.RepVersamenti
{
    public partial class XtraFormReportQ1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormReportQ1()
        {
            InitializeComponent();
        }

        private Struttura _Struttura;
        private DateTime _Inizio;

        private void ReportQ1(int mesi)
        {
            DateTime inizio = _Inizio;
            DateTime fine = inizio.AddMonths(3).AddDays(-1);

            if (mesi == 3)
            {
                while (inizio.Month != 1 && inizio.Month != 4 && inizio.Month != 7 && inizio.Month != 10)
                {
                    inizio = inizio.AddMonths(-1);
                }
                fine = inizio.AddMonths(3).AddDays(-1);
            }
            else if (mesi == 12)
            {
                inizio = new DateTime(_Inizio.Year, 1, 1);
                fine = new DateTime(_Inizio.Year, 12, 31);
            }
            else throw new Exception("periodo non previsto");

            XPCollection<Versamento> versamenti = new XPCollection<Versamento>(this.unitOfWork1);
            GroupOperator tipo =
                new GroupOperator(GroupOperatorType.Or, new CriteriaOperator[]{
                            new BinaryOperator("Tipologia", EnumTipologiaVersamento.Incasso_Pos),
                            new BinaryOperator("Tipologia", EnumTipologiaVersamento.Incasso_Contanti),
                            new BinaryOperator("Tipologia", EnumTipologiaVersamento.FondoCassa_Versamento)
                        });
            versamenti.Criteria =
                new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                            new BinaryOperator("Struttura.Oid", _Struttura.Oid),
                            new BinaryOperator("InizioPeriodo", inizio, BinaryOperatorType.GreaterOrEqual),
                            new BinaryOperator("FinePeriodo", fine, BinaryOperatorType.LessOrEqual),
                            tipo
                        });
            versamenti.Sorting = new SortingCollection(new SortProperty[] { new SortProperty("DataVersamento", DevExpress.Xpo.DB.SortingDirection.Ascending) });

            List<DatiReportQ1> elenco = new List<DatiReportQ1>();
            foreach (Versamento item in versamenti)
            {
                DatiReportQ1Sub dati = new DatiReportQ1Sub();

                dati.Quietanza = item.Quietanza;
                switch (item.Tipologia)
                {
                    case EnumTipologiaVersamento.Incasso_Pos:
                        dati.Importo = item.Incassi;
                        break;
                    case EnumTipologiaVersamento.Incasso_Contanti:
                        dati.Importo = item.ImportoVersato - item.ContanteAltriEnti;
                        break;
                    case EnumTipologiaVersamento.FondoCassa_Versamento:
                        dati.Importo = item.ImportoVersato;
                        break;
                    default:
                        throw new Exception(String.Format("Valore (versamento.tipologia) non previsto: {0}", item.Tipologia));
                }

                if (string.IsNullOrEmpty(item.Quietanza))
                {
                    XtraMessageBox.Show("Errore ReportQ1: non sono state inserite tutte le quietanze del periodo considerato.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DatiReportQ1 target = null;
                foreach (DatiReportQ1 datiReportQ1 in elenco)
                {
                    if (datiReportQ1.MeseInizio == item.InizioPeriodo.Month)
                        target = datiReportQ1;
                }

                if (target == null)
                {
                    target = new DatiReportQ1();
                    target.Periodo = string.Format("{0:MMMM}", item.InizioPeriodo).ToUpper();
                    target.MeseInizio = item.InizioPeriodo.Month;
                    target.RicevutePeriodo = RicevuteMesePeriodo(item.InizioPeriodo, null);
                    target.ImportoPeriodo = 0;
                    target.Elenco = new List<DatiReportQ1Sub>();

                    elenco.Add(target);
                }

                target.Elenco.Add(dati);
                target.CalcolaTotale();
            }

            XtraReportQ1 report = new XtraReportQ1();
            report.Init(elenco, _Struttura, inizio, mesi);

            report.ShowRibbonPreviewDialog();
        }

        private string RicevuteMesePeriodo(DateTime dateTime, SoggettoEconomico soggetto)
        {
            DateTime mese = new DateTime(dateTime.Year, dateTime.Month, 1);

            ClassNumerazione numerazione = new ClassNumerazione();

            XPCollection<Vendita> vendite = new XPCollection<Vendita>(this.unitOfWork1);
            vendite.Criteria = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                new BinaryOperator("Struttura.Oid", _Struttura.Oid),
                new BinaryOperator("DataContabile", mese, BinaryOperatorType.GreaterOrEqual),
                new BinaryOperator("DataContabile", mese.AddMonths(1).AddDays(-1), BinaryOperatorType.LessOrEqual)});

            foreach (Vendita vendita in vendite)
            {
                foreach (Stampa stampa in vendita.Stampe)
                {
                    if (soggetto == null)
                        numerazione.Add(stampa.Vendita.Postazione, stampa.NumeroProgressivo, stampa.Vendita.DataContabile.Year);
                    else
                    {
                        foreach (RigaStampaIngresso riga in stampa.RigheStampaIngresso)
                        {
                            if (riga.Ingresso.SoggettoEconomico.Oid == soggetto.Oid)
                                numerazione.Add(stampa.Vendita.Postazione, stampa.NumeroProgressivo, stampa.Vendita.DataContabile.Year);
                        }
                    }
                }
            }

            return numerazione.EB();
        }

        private int RicevutePeriodo(DateTime inizio, DateTime fine, SoggettoEconomico soggetto)
        {
            ClassNumerazione numerazione = new ClassNumerazione();

            XPCollection<Vendita> vendite = new XPCollection<Vendita>(this.unitOfWork1);
            vendite.Criteria = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                new BinaryOperator("Struttura.Oid", _Struttura.Oid),
                new BinaryOperator("DataContabile", inizio, BinaryOperatorType.GreaterOrEqual),
                new BinaryOperator("DataContabile", fine, BinaryOperatorType.LessOrEqual)});

            foreach (Vendita vendita in vendite)
            {
                bool soggettoEsterno = false;
                if (soggetto != null)
                {
                    foreach (var rigaVenditaVariante in vendita.RigheVenditaVariante)
                    {
                        if (rigaVenditaVariante.Card != null &&
                            rigaVenditaVariante.Variante.Biglietto.Gestore.Oid == soggetto.Oid)
                            soggettoEsterno = true;
                    }
                }

                foreach (Stampa stampa in vendita.Stampe)
                {
                    foreach (RigaStampaIngresso riga in stampa.RigheStampaIngresso)
                    {
                        if (riga.Ingresso.SoggettoEconomico.Oid == soggetto.Oid || soggettoEsterno)
                            numerazione.Add(stampa.Vendita.Postazione, stampa.NumeroProgressivo, stampa.Vendita.DataContabile.Year);
                    }
                }
            }

            return numerazione.NB();
        }

        internal void Init(DateTime inizio, Struttura struttura)
        {
            _Inizio = inizio;
            _Struttura = this.unitOfWork1.GetObjectByKey<Struttura>(struttura.Oid);
        }

        private void simpleButtonStampa_Click(object sender, EventArgs e)
        {
            int mesi = (int)this.radioGroupPeriodo.EditValue;
            SoggettoEconomico soggetto = this.lookUpEdit1.EditValue as SoggettoEconomico;

            if (soggetto == null || _Struttura.SoggettoEconomico == soggetto)
                ReportQ1(mesi);
            else
            {
                if (mesi == 12)
                    ReportQ1A(soggetto);
                else
                    XtraMessageBox.Show("solo per 12 mesi");
            }
        }

        private void ReportQ1A(SoggettoEconomico soggetto)
        {
            DateTime inizio = new DateTime(_Inizio.Year, 1, 1);
            DateTime fine = new DateTime(_Inizio.Year, 12, 31);

            XPCollection<Versamento> versamenti = new XPCollection<Versamento>(this.unitOfWork1);
            GroupOperator tipo =
                new GroupOperator(GroupOperatorType.Or, new CriteriaOperator[]{
                            new BinaryOperator("Tipologia", EnumTipologiaVersamento.Versamento_AdAltriEnti)
                        });

            versamenti.Criteria =
                new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                            new BinaryOperator("Struttura.Oid", _Struttura.Oid),
                            new BinaryOperator("InizioPeriodo", inizio, BinaryOperatorType.GreaterOrEqual),
                            new BinaryOperator("FinePeriodo", fine, BinaryOperatorType.LessOrEqual),
                            tipo
                        });
            versamenti.Sorting = new SortingCollection(new SortProperty[] { new SortProperty("DataVersamento", DevExpress.Xpo.DB.SortingDirection.Ascending) });

            List<DatiReportQ1> elenco = new List<DatiReportQ1>();
            foreach (Versamento item in versamenti)
            {
                DatiReportQ1Sub dati = new DatiReportQ1Sub();

                dati.Quietanza = item.Quietanza;
                switch (item.Tipologia)
                {
                    case EnumTipologiaVersamento.Versamento_AdAltriEnti:
                        dati.Importo = -item.ContanteAltriEnti;
                        break;
                    default:
                        throw new Exception(String.Format("Valore (versamento.tipologia) non previsto: {0}", item.Tipologia));
                }

                if (string.IsNullOrEmpty(item.Quietanza))
                {
                    XtraMessageBox.Show("Errore ReportQ1A: non sono state inserite tutte le quietanze del periodo considerato.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //return;
                }

                DatiReportQ1 target = null;
                foreach (DatiReportQ1 datiReportQ1 in elenco)
                {
                    if (datiReportQ1.MeseInizio == item.InizioPeriodo.Month)
                        target = datiReportQ1;
                }

                if (target == null)
                {
                    target = new DatiReportQ1();
                    target.Periodo = string.Format("{0:MMMM} - {1:MMMM}", item.InizioPeriodo, item.FinePeriodo).ToUpper();
                    target.MeseInizio = item.InizioPeriodo.Month;
                    target.RicevutePeriodo = string.Format("n. {0} biglietti", RicevutePeriodo(item.InizioPeriodo, item.FinePeriodo, soggetto));
                    target.ImportoPeriodo = 0;
                    target.Elenco = new List<DatiReportQ1Sub>();

                    elenco.Add(target);
                }

                target.Elenco.Add(dati);
                target.CalcolaTotale();
            }

            XtraReportQ1A report = new XtraReportQ1A();
            report.Init(elenco, _Struttura, inizio, soggetto);

            report.ShowRibbonPreviewDialog();
        }
    }
}