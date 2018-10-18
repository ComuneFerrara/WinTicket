using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using Musei.Module;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
using DevExpress.XtraEditors;

namespace WinTicketNext.Storico.Rep06
{
    public partial class XtraFormReport06 : DevExpress.XtraEditors.XtraForm
    {

        public XtraFormReport06()
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

        private List<DatiReport06> _List = null;
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
            _List = new List<DatiReport06>();
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
                _Aperture.CaricaApertureIngressi(_Inizio.AddYears(-2), _Fine.AddYears(-2), this.unitOfWork1);

                XPCollection<Vendita> vendite = new XPCollection<Vendita>(this.unitOfWork1);

                GroupOperator periodo1 = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                                    new BinaryOperator("DataContabile", _Inizio, BinaryOperatorType.GreaterOrEqual),
                                    new BinaryOperator("DataContabile", _Fine, BinaryOperatorType.LessOrEqual)});
                GroupOperator periodo2 = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                                    new BinaryOperator("DataContabile", _Inizio.AddYears(-1), BinaryOperatorType.GreaterOrEqual),
                                    new BinaryOperator("DataContabile", _Fine.AddYears(-1), BinaryOperatorType.LessOrEqual)});
                GroupOperator periodo3 = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                                    new BinaryOperator("DataContabile", _Inizio.AddYears(-2), BinaryOperatorType.GreaterOrEqual),
                                    new BinaryOperator("DataContabile", _Fine.AddYears(-2), BinaryOperatorType.LessOrEqual)});

                vendite.Criteria = new GroupOperator(GroupOperatorType.Or,
                    new CriteriaOperator[] {periodo1, periodo2, periodo3});

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
                GroupOperator cardPeriodo3 = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]
                {
                    new BinaryOperator("DataOraEntrata", _Inizio.AddYears(-2), BinaryOperatorType.GreaterOrEqual),
                    new BinaryOperator("DataOraEntrata", _Fine.AddYears(-2).AddDays(1), BinaryOperatorType.Less),
                    new NotOperator(new NullOperator("RigaStampaIngresso.Stampa.Card"))
                });

                XPCollection<Entrata> entrate = new XPCollection<Entrata>(this.unitOfWork1);
                entrate.Criteria = new GroupOperator(GroupOperatorType.Or, new CriteriaOperator[]
                {
                    cardPeriodo1, cardPeriodo2, cardPeriodo3
                });

                foreach (var entrata in entrate)
                {
                    if (_Ingressi.Contains(entrata.RigaStampaIngresso.Ingresso))
                        AddCardToList(entrata);
                }

                foreach (DatiReport06 dato in _List)
                {
                    dato.CalcolaTotale(_List);
                }

                XtraReport06 report = new XtraReport06();

                report.Init(_List, _Inizio, _Fine, this.memoEditInfo.Text);

                report.ShowRibbonPreviewDialog();
            }
            finally
            {
                Cursor.Current = saveCursor;
            }
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

        private void AddCardToList(Entrata entrata)
        {
            DatiReport06 target = null;
            foreach (DatiReport06 datiReport06 in _List)
            {
                if (datiReport06.Museo == entrata.RigaStampaIngresso.Ingresso.Descrizione)
                    target = datiReport06;
            }

            if (target == null)
            {
                target = new DatiReport06();
                target.Museo = entrata.RigaStampaIngresso.Ingresso.Descrizione;
                target.Tipo = entrata.RigaStampaIngresso.Ingresso.DescrizioneTipo;
                target.Ordine = entrata.RigaStampaIngresso.Ingresso.OrdineReport01;
                target.Tipologia = entrata.RigaStampaIngresso.Ingresso.Tipologia;

                _List.Add(target);
            }

            int qta = entrata.RigaStampaIngresso.TotaleIngressi;
            int mese = entrata.DataOraEntrata.Month;
            int anno = entrata.DataOraEntrata.Year;

            if (anno == _AnnoInCorso)
            {
                switch (mese)
                {
                    case 1:
                        target.Gennaio += qta;
                        break;
                    case 2:
                        target.Febbraio += qta;
                        break;
                    case 3:
                        target.Marzo += qta;
                        break;
                    case 4:
                        target.Aprile += qta;
                        break;
                    case 5:
                        target.Maggio += qta;
                        break;
                    case 6:
                        target.Giugno += qta;
                        break;
                    case 7:
                        target.Luglio += qta;
                        break;
                    case 8:
                        target.Agosto += qta;
                        break;
                    case 9:
                        target.Settembre += qta;
                        break;
                    case 10:
                        target.Ottobre += qta;
                        break;
                    case 11:
                        target.Novembre += qta;
                        break;
                    case 12:
                        target.Dicembre += qta;
                        break;
                    default:
                        throw new Exception("Mese non previsto");
                }

            }
            else if (anno == _AnnoInCorso - 1)
            {
                target.AnnoMeno1 += qta;
            }
            else if (anno == _AnnoInCorso - 2)
            {
                target.AnnoMeno2 += qta;
            }
            else
                throw new Exception("Anno non valido");

            target.CalcolaTotale();
        }

        private void AddToList(Ingresso ingresso, int qta, DateTime dateTime, EnumTipologiaEconomica enumTipologiaEconomica, RigaVenditaVariante riga)
        {
            DatiReport06 target = null;
            foreach (DatiReport06 dato in _List)
            {
                if (dato.Museo == ingresso.Descrizione)
                    target = dato;
            }

            if (target == null)
            {
                target = new DatiReport06();
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

            int mese = dateTime.Month;
            int anno = dateTime.Year;

            if (anno == _AnnoInCorso)
            {
                switch (mese)
                {
                    case 1:
                        target.Gennaio += qta;
                        break;
                    case 2:
                        target.Febbraio += qta;
                        break;
                    case 3:
                        target.Marzo += qta;
                        break;
                    case 4:
                        target.Aprile += qta;
                        break;
                    case 5:
                        target.Maggio += qta;
                        break;
                    case 6:
                        target.Giugno += qta;
                        break;
                    case 7:
                        target.Luglio += qta;
                        break;
                    case 8:
                        target.Agosto += qta;
                        break;
                    case 9:
                        target.Settembre += qta;
                        break;
                    case 10:
                        target.Ottobre += qta;
                        break;
                    case 11:
                        target.Novembre += qta;
                        break;
                    case 12:
                        target.Dicembre += qta;
                        break;
                    default:
                        throw new Exception("Mese non previsto");
                }
                
            }
            else if (anno == _AnnoInCorso - 1)
            {
                target.AnnoMeno1 += qta;
            }
            else if (anno == _AnnoInCorso - 2)
            {
                target.AnnoMeno2 += qta;
            }
            else
                throw new Exception("Anno non valido");

            target.CalcolaTotale();
        }


    }
}