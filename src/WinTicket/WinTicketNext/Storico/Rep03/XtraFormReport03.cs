using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using Musei.Module;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace WinTicketNext.Storico.Rep03
{
    public partial class XtraFormReport03 : DevExpress.XtraEditors.XtraForm
    {

        public XtraFormReport03()
        {
            InitializeComponent();

            this.dateEditInizio.DateTime = DateTime.Now.Date.AddDays(1 - DateTime.Now.Date.Day).AddMonths(-1);
            this.dateEditFine.DateTime = this.dateEditInizio.DateTime.AddMonths(1).AddDays(-1);

            //this.lookUpEdit1.Properties.DataSource = new XPCollection<SoggettoEconomico>(this.unitOfWork1);

            XPCollection<Ingresso> data = Program.UtenteCollegato.GetMioElencoIngressi(this.unitOfWork1, Program.Postazione);
            this.checkedListBoxControl1.DataSource = data;
            //for (int i = 0; i < data.Count; i++)
            //{
            //    Ingresso ingresso = data[i];
            //    if (ingresso.Struttura.SoggettoEconomico.RagioneSociale.ToLower().Contains("comune"))
            //        this.checkedListBoxControl1.SetItemChecked(i, true);
            //}
        }

        private List<DatiReport03> _List = null;
        //private SoggettoEconomico _Soggetto = null;
        private List<Ingresso> _Ingressi = null;
        private GestoreAperture _Aperture = null;
        private int _AnnoInCorso;
        private DateTime _Inizio;
        private DateTime _Fine;
        private void simpleButtonReport_Click(object sender, EventArgs e)
        {
            _AnnoInCorso = this.dateEditInizio.DateTime.Year;
            _Inizio = this.dateEditInizio.DateTime;
            _Fine = this.dateEditFine.DateTime;
            //_Soggetto = this.lookUpEdit1.EditValue as SoggettoEconomico;
            _Ingressi = new List<Ingresso>();
            _List = new List<DatiReport03>();
            _Aperture = new GestoreAperture();

            //if (_Soggetto == null)
            //{
            //    XtraMessageBox.Show("Selezionare un soggetto");
            //    return;
            //}

            foreach (var item in this.checkedListBoxControl1.CheckedItems)
            {
                Ingresso ingresso = item as Ingresso;
                if (ingresso != null)
                    _Ingressi.Add(ingresso);
            }

            if (_Ingressi.Count == 0)
            {
                XtraMessageBox.Show("Selezionare un ingresso");
                return;
            }

            if (this.dateEditFine.DateTime.Date >= DateTime.Now.Date)
            {
                XtraMessageBox.Show("Data Fine non può essere maggiore della data odierna", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cursor saveCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                InitList(_Inizio);

                _Aperture.CaricaApertureIngressi(_Inizio, _Fine, this.unitOfWork1);
                _Aperture.CaricaApertureIngressi(_Inizio.AddYears(-1), _Fine.AddYears(-1), this.unitOfWork1);

                XPCollection<Vendita> vendite = new XPCollection<Vendita>(this.unitOfWork1);

                GroupOperator periodo1 = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                                    new BinaryOperator("DataContabile", _Inizio, BinaryOperatorType.GreaterOrEqual),
                                    new BinaryOperator("DataContabile", _Fine, BinaryOperatorType.LessOrEqual)});
                GroupOperator periodo2 = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                                    new BinaryOperator("DataContabile", _Inizio.AddYears(-1), BinaryOperatorType.GreaterOrEqual),
                                    new BinaryOperator("DataContabile", _Fine.AddYears(-1), BinaryOperatorType.LessOrEqual)});

                vendite.Criteria = new GroupOperator(GroupOperatorType.Or, new CriteriaOperator[] { periodo1, periodo2 });

                foreach (Vendita vendita in vendite)
                {
                    foreach (RigaVenditaVariante riga in vendita.RigheVenditaVariante)
                    {
                        foreach (Ingresso ingresso in riga.Variante.Biglietto.Percorso.Ingressi)
                        {
                            //if (ingresso.SoggettoEconomico == _Soggetto)
                            if (_Ingressi.Contains(ingresso))
                            {
                                AddToList(ingresso, riga.Quantita, vendita.DataContabile, riga.Variante.TipologiaEconomica, riga);
                            }
                        }
                    }
                }

                GroupOperator cardPeriodo1 = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]
                {
                    new BinaryOperator("DataOraEntrata", _Inizio, BinaryOperatorType.GreaterOrEqual),
                    new BinaryOperator("DataOraEntrata", _Fine.AddDays(1), BinaryOperatorType.Less),
                    new NotOperator(new NullOperator("RigaStampaIngresso.Stampa.Card"))
                });
                GroupOperator cardPeriodo2 = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]
                {
                    new BinaryOperator("DataOraEntrata", _Inizio.AddYears(-1), BinaryOperatorType.GreaterOrEqual),
                    new BinaryOperator("DataOraEntrata", _Fine.AddYears(-1).AddDays(1), BinaryOperatorType.Less),
                    new NotOperator(new NullOperator("RigaStampaIngresso.Stampa.Card"))
                });

                XPCollection<Entrata> entrate = new XPCollection<Entrata>(this.unitOfWork1);
                entrate.Criteria = new GroupOperator(GroupOperatorType.Or, new CriteriaOperator[]
                {
                    cardPeriodo1, cardPeriodo2
                });

                foreach (var entrata in entrate)
                {
                    if (_Ingressi.Contains(entrata.RigaStampaIngresso.Ingresso))
                        AddCardToList(entrata);
                }

                //foreach (Ingresso ingresso in _Soggetto.Ingressi)
                foreach (Ingresso ingresso in _Ingressi)
                {
                    AddToList(ingresso, _Aperture.TotaleGiornate(ingresso.Oid, _Inizio, _Fine), "ac");
                    AddToList(ingresso, _Aperture.TotaleGiornate(ingresso.Oid, _Inizio.AddYears(-1), _Fine.AddYears(-1)), "ap");
                }

                foreach (DatiReport03 datiReport03 in _List)
                {
                    datiReport03.CalcolaTotale(_List);
                }

                XtraReport03 report = new XtraReport03();

                report.Init(_List, _Inizio, _Fine, this.memoEditInfo.Text);

                report.ShowRibbonPreviewDialog();
            }
            finally
            {
                Cursor.Current = saveCursor;
            }
        }

        private void AddCardToList(Entrata entrata)
        {
            DatiReport03 target = null;
            foreach (DatiReport03 datiReport03 in _List)
            {
                if (datiReport03.Museo == entrata.RigaStampaIngresso.Ingresso.Descrizione)
                    target = datiReport03;
            }

            if (target == null)
            {
                target = new DatiReport03();
                target.Museo = entrata.RigaStampaIngresso.Ingresso.Descrizione;
                target.Tipo = entrata.RigaStampaIngresso.Ingresso.DescrizioneTipo;
                target.Ordine = entrata.RigaStampaIngresso.Ingresso.OrdineReport01;
                target.Tipologia = entrata.RigaStampaIngresso.Ingresso.Tipologia;

                _List.Add(target);
            }

            if (entrata.DataOraEntrata.Year == _AnnoInCorso)
                target.PagantiAC += entrata.RigaStampaIngresso.TotaleIngressi;
            else
                target.PagantiAP += entrata.RigaStampaIngresso.TotaleIngressi;

            target.CalcolaTotale();
        }

        private void InitList(DateTime inizio)
        {
            using (XPCollection<Ingresso> ingressi = new XPCollection<Ingresso>(this.unitOfWork1))
            {
                foreach (Ingresso ingresso in ingressi)
                {
                    //if (ingresso.SoggettoEconomico == _Soggetto)
                    if (_Ingressi.Contains(ingresso))
                        AddToList(ingresso, 0, inizio, EnumTipologiaEconomica.Gratuito, null);
                }
            }
        }

        private void AddToList(Ingresso ingresso, int ng, string anno)
        {
            DatiReport03 target = null;
            foreach (DatiReport03 datiReport03 in _List)
            {
                if (datiReport03.Museo == ingresso.Descrizione)
                    target = datiReport03;
            }

            if (target == null)
            {
                target = new DatiReport03();
                target.Museo = ingresso.Descrizione;
                target.Tipo = ingresso.DescrizioneTipo;
                target.Ordine = ingresso.OrdineReport01;
                target.Tipologia = ingresso.Tipologia;

                _List.Add(target);
            }

            if (anno == "ac")
                target.GiorniAC += ng;
            else
                target.GiorniAP += ng;

            target.CalcolaTotale();
        }

        private void AddToList(Ingresso ingresso, int qta, DateTime dateTime, EnumTipologiaEconomica enumTipologiaEconomica, RigaVenditaVariante riga)
        {
            DatiReport03 target = null;
            foreach (DatiReport03 datiReport03 in _List)
            {
                if (datiReport03.Museo == ingresso.Descrizione)
                    target = datiReport03;
            }

            if (target == null)
            {
                target = new DatiReport03();
                target.Museo = ingresso.Descrizione;
                target.Tipo = ingresso.DescrizioneTipo;
                target.Ordine = ingresso.OrdineReport01;
                target.Tipologia = ingresso.Tipologia;

                _List.Add(target);
            }

            if (riga == null) { target.CalcolaTotale(); return; }

            // filtro in base alle giornate di apertura
            //if (ingresso.IsAttrib(EventoParticolare.STR_INGRESSI_VERIFICA_VALIDITA) && !_Aperture.Valido(ingresso.Oid, riga.Vendita.DataContabile))
            //    return;
            if (ingresso.IsAttrib(EventoParticolare.STR_INGRESSI_NO_VENDITA_DA_ALTRI) && riga.Vendita.Struttura != ingresso.Struttura)
                return;
            if (riga.Vendita.Struttura != ingresso.Struttura && riga.Vendita.DataContabile.Year <= 2011 && riga.Vendita.DataContabile.Month < 6)
                return;
            if (ingresso.IsAttrib(EventoParticolare.STR_INGRESSI_MOD_TERREMOTO_1) && (riga.Vendita.DataContabile > EventoParticolare.EQDataEvento && riga.Vendita.DataContabile.Year < 2015 && !_Aperture.Valido(ingresso.Oid, riga.Vendita.DataContabile)))
                return;
            if (riga.Variante.TipologiaTre == EnumTipologiaTre.CardMyFE && riga.Variante.TipologiaDue == EnumTipologiaDue.Ridotto && riga.Variante.PrezzoAttuale.PrezzoRidotto == null)
                return;
            if (riga.Variante.TipologiaTre == EnumTipologiaTre.CardMyFE && riga.Variante.TipologiaDue == EnumTipologiaDue.Ridotto)
                return;

            if (enumTipologiaEconomica == EnumTipologiaEconomica.Pagante)
            {
                if (dateTime.Year == _AnnoInCorso)
                    target.PagantiAC += qta;
                else
                    target.PagantiAP += qta;
            }
            else if (enumTipologiaEconomica == EnumTipologiaEconomica.Gratuito)
            {
                if (dateTime.Year == _AnnoInCorso)
                    target.NonPagantiAC += qta;
                else
                    target.NonPagantiAP += qta;
            }
            else throw new Exception("EnumTipologiaEconomica non previsto: " + enumTipologiaEconomica);

            target.CalcolaTotale();
        }


    }
}