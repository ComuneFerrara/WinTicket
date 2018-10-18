using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using Musei.Module;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace WinTicketNext.Storico.Rep04
{
    public partial class XtraFormReport04 : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormReport04()
        {
            InitializeComponent();

            this.dateEditInizio.DateTime = DateTime.Now.Date.AddDays(1 - DateTime.Now.Date.Day).AddMonths(-1);
            this.dateEditFine.DateTime = this.dateEditInizio.DateTime.AddMonths(1).AddDays(-1);
            this.checkedListBoxControl1.DataSource = Program.UtenteCollegato.GetMioElencoIngressi(this.unitOfWork1, Program.Postazione);
        }

        private List<DatiReport04> _List = null;
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
            _Ingressi = new List<Ingresso>();
            _List = new List<DatiReport04>();
            _Aperture = new GestoreAperture();

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
                _Aperture.CaricaApertureIngressi(_Inizio.AddYears(-3), _Fine.AddYears(-3), this.unitOfWork1);
                _Aperture.CaricaApertureIngressi(_Inizio.AddYears(-4), _Fine.AddYears(-4), this.unitOfWork1);

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
                GroupOperator periodo4 = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                                    new BinaryOperator("DataContabile", _Inizio.AddYears(-3), BinaryOperatorType.GreaterOrEqual),
                                    new BinaryOperator("DataContabile", _Fine.AddYears(-3), BinaryOperatorType.LessOrEqual)});
                GroupOperator periodo5 = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                                    new BinaryOperator("DataContabile", _Inizio.AddYears(-4), BinaryOperatorType.GreaterOrEqual),
                                    new BinaryOperator("DataContabile", _Fine.AddYears(-4), BinaryOperatorType.LessOrEqual)});

                vendite.Criteria = new GroupOperator(GroupOperatorType.Or,
                    new CriteriaOperator[] {periodo1, periodo2, periodo3, periodo4, periodo5});

                foreach (Vendita vendita in vendite)
                {
                    foreach (RigaVenditaVariante riga in vendita.RigheVenditaVariante)
                    {
                        foreach (Ingresso ingresso in riga.Variante.Biglietto.Percorso.Ingressi)
                        {
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
                GroupOperator cardPeriodo4 = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]
                {
                    new BinaryOperator("DataOraEntrata", _Inizio.AddYears(-3), BinaryOperatorType.GreaterOrEqual),
                    new BinaryOperator("DataOraEntrata", _Fine.AddYears(-3).AddDays(1), BinaryOperatorType.Less),
                    new NotOperator(new NullOperator("RigaStampaIngresso.Stampa.Card"))
                });
                GroupOperator cardPeriodo5 = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]
                {
                    new BinaryOperator("DataOraEntrata", _Inizio.AddYears(-4), BinaryOperatorType.GreaterOrEqual),
                    new BinaryOperator("DataOraEntrata", _Fine.AddYears(-4).AddDays(1), BinaryOperatorType.Less),
                    new NotOperator(new NullOperator("RigaStampaIngresso.Stampa.Card"))
                });

                XPCollection<Entrata> entrate = new XPCollection<Entrata>(this.unitOfWork1);
                entrate.Criteria = new GroupOperator(GroupOperatorType.Or, new CriteriaOperator[]
                {
                    cardPeriodo1, cardPeriodo2, cardPeriodo3, cardPeriodo4, cardPeriodo5
                });

                foreach (var entrata in entrate)
                {
                    if (_Ingressi.Contains(entrata.RigaStampaIngresso.Ingresso))
                        AddCardToList(entrata);
                }


                foreach (Ingresso ingresso in _Ingressi)
                {
                    AddToList(ingresso, _Aperture.TotaleGiornate(ingresso.Oid, _Inizio, _Fine), "1");
                    AddToList(ingresso, _Aperture.TotaleGiornate(ingresso.Oid, _Inizio.AddYears(-1), _Fine.AddYears(-1)), "2");
                    AddToList(ingresso, _Aperture.TotaleGiornate(ingresso.Oid, _Inizio.AddYears(-2), _Fine.AddYears(-2)), "3");
                    AddToList(ingresso, _Aperture.TotaleGiornate(ingresso.Oid, _Inizio.AddYears(-3), _Fine.AddYears(-3)), "4");
                    AddToList(ingresso, _Aperture.TotaleGiornate(ingresso.Oid, _Inizio.AddYears(-4), _Fine.AddYears(-4)), "5");
                }

                foreach (DatiReport04 dato in _List)
                {
                    dato.CalcolaTotale(_List);
                }

                XtraReport04 report = new XtraReport04();

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
                    if (_Ingressi.Contains(ingresso))
                        AddToList(ingresso, 0, inizio, EnumTipologiaEconomica.Gratuito, null);
                }
            }
        }

        private void AddCardToList(Entrata entrata)
        {
            DatiReport04 target = null;
            foreach (DatiReport04 datiReport04 in _List)
            {
                if (datiReport04.Museo == entrata.RigaStampaIngresso.Ingresso.Descrizione)
                    target = datiReport04;
            }

            if (target == null)
            {
                target = new DatiReport04();
                target.Museo = entrata.RigaStampaIngresso.Ingresso.Descrizione;
                target.Tipo = entrata.RigaStampaIngresso.Ingresso.DescrizioneTipo;
                target.Ordine = entrata.RigaStampaIngresso.Ingresso.OrdineReport01;

                _List.Add(target);
            }

            if (entrata.DataOraEntrata.Year == _AnnoInCorso)
                target.VisAnno1 += entrata.RigaStampaIngresso.TotaleIngressi;
            else if (entrata.DataOraEntrata.Year == _AnnoInCorso - 1)
                target.VisAnno2 += entrata.RigaStampaIngresso.TotaleIngressi;
            else if (entrata.DataOraEntrata.Year == _AnnoInCorso - 2)
                target.VisAnno3 += entrata.RigaStampaIngresso.TotaleIngressi;
            else if (entrata.DataOraEntrata.Year == _AnnoInCorso - 3)
                target.VisAnno4 += entrata.RigaStampaIngresso.TotaleIngressi;
            else if (entrata.DataOraEntrata.Year == _AnnoInCorso - 4)
                target.VisAnno5 += entrata.RigaStampaIngresso.TotaleIngressi;


            target.CalcolaTotale();
        }


        private void AddToList(Ingresso ingresso, int ng, string anno)
        {
            DatiReport04 target = null;
            foreach (DatiReport04 dato in _List)
            {
                if (dato.Museo == ingresso.Descrizione)
                    target = dato;
            }

            if (target == null)
            {
                target = new DatiReport04();
                target.Museo = ingresso.Descrizione;
                target.Tipo = ingresso.DescrizioneTipo;
                target.Ordine = ingresso.OrdineReport01;

                _List.Add(target);
            }

            switch (anno)
            {
                case "1":
                    target.GioAnno1 += ng;
                    break;
                case "2":
                    target.GioAnno2 += ng;
                    break;
                case "3":
                    target.GioAnno3 += ng;
                    break;
                case "4":
                    target.GioAnno4 += ng;
                    break;
                case "5":
                    target.GioAnno5 += ng;
                    break;
                default:
                    throw new Exception("errore");
            }

            target.CalcolaTotale();
        }

        private void AddToList(Ingresso ingresso, int qta, DateTime dateTime, EnumTipologiaEconomica enumTipologiaEconomica, RigaVenditaVariante riga)
        {
            DatiReport04 target = null;
            foreach (DatiReport04 dato in _List)
            {
                if (dato.Museo == ingresso.Descrizione)
                    target = dato;
            }

            if (target == null)
            {
                target = new DatiReport04();
                target.Museo = ingresso.Descrizione;
                target.Tipo = ingresso.DescrizioneTipo;
                target.Ordine = ingresso.OrdineReport01;

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

            if (dateTime.Year == _AnnoInCorso)
                target.VisAnno1 += qta;
            else if (dateTime.Year == _AnnoInCorso - 1)
                target.VisAnno2 += qta;
            else if (dateTime.Year == _AnnoInCorso - 2)
                target.VisAnno3 += qta;
            else if (dateTime.Year == _AnnoInCorso - 3)
                target.VisAnno4 += qta;
            else if (dateTime.Year == _AnnoInCorso - 4)
                target.VisAnno5 += qta;

            target.CalcolaTotale();
        }

        private void simpleButtonMusei_Click(object sender, EventArgs e)
        {
            XPCollection<Ingresso> elenco = this.checkedListBoxControl1.DataSource as XPCollection<Ingresso>;

            for (int i = 0; i < elenco.Count; i++)
            {
                Ingresso ingresso = this.checkedListBoxControl1.GetItem(i) as Ingresso;
                if (!string.IsNullOrEmpty(ingresso.DescrizioneTipo) && ingresso.DescrizioneTipo.ToUpper().Contains("MUSEI"))
                    this.checkedListBoxControl1.SetItemChecked(i, true);
            }
        }

        private void simpleButtonSpazi_Click(object sender, EventArgs e)
        {
            XPCollection<Ingresso> elenco = this.checkedListBoxControl1.DataSource as XPCollection<Ingresso>;

            for (int i = 0; i < elenco.Count; i++)
            {
                Ingresso ingresso = this.checkedListBoxControl1.GetItem(i) as Ingresso;
                if (!string.IsNullOrEmpty(ingresso.DescrizioneTipo) && ingresso.DescrizioneTipo.ToUpper().Contains("SPAZI"))
                    this.checkedListBoxControl1.SetItemChecked(i, true);
            }
        }
    }
}