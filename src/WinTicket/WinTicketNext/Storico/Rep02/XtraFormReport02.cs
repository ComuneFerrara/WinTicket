using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using Musei.Module;
using DevExpress.XtraReports.UI;

namespace WinTicketNext.Storico.Rep02
{
    public partial class XtraFormReport02 : DevExpress.XtraEditors.XtraForm
    {
        private const string STR_BigliettoIntero = "Biglietto Intero";
        private const string STR_CumulativoIntero = "Cumulativo Intero";
        private const string STR_CumulativoRidotto = "Cumulativo Ridotto";
        private const string STR_CardMuseiIntero = "Card Musei Intero";
        private const string STR_CardMuseiRidotto = "Card Musei Ridotto";
        private const string STR_GruppiIngressoOmaggio = "Gruppi (ingresso omaggio)";
        private const string STR_Gruppi = "Gruppi";
        private const string STR_Scuola = "Scuola";
        private const string STR_Bigliettone = "Bigliettone";
        private const string STR_CardMyFE = "Card MyFE";

        public XtraFormReport02()
        {
            InitializeComponent();

            this.dateEditInizio.DateTime = DateTime.Now.Date.AddDays(1 - DateTime.Now.Date.Day).AddMonths(-1);
            this.dateEditFine.DateTime = this.dateEditInizio.DateTime.AddMonths(1).AddDays(-1);
            //this.lookUpEdit1.Properties.DataSource = Program.UtenteCollegato.GetMioElencoIngressi(this.unitOfWork1, Program.Postazione);
            this.checkedListBoxControl1.DataSource = Program.UtenteCollegato.GetMioElencoIngressi(this.unitOfWork1, Program.Postazione);
        }

        private List<DatiReport02> _List = null;
        private string _Descrizione;
        //private Ingresso _Ingresso = null;
        private List<Ingresso> _Ingressi = null;
        private GestoreAperture _Aperture = null;
        private void simpleButtonReport_Click(object sender, EventArgs e)
        {
            //_Ingresso = this.lookUpEdit1.EditValue as Ingresso;
            _List = new List<DatiReport02>();
            _Ingressi = new List<Ingresso>();
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

                InitList();

                _Aperture.CaricaApertureIngressi(this.dateEditInizio.DateTime, this.dateEditFine.DateTime.AddMonths(1), this.unitOfWork1);

                XPCollection<Vendita> vendite = new XPCollection<Vendita>(this.unitOfWork1);
                vendite.Criteria = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                new BinaryOperator("DataContabile", this.dateEditInizio.DateTime, BinaryOperatorType.GreaterOrEqual),
                new BinaryOperator("DataContabile", this.dateEditFine.DateTime, BinaryOperatorType.LessOrEqual)});

                foreach (Vendita item in vendite)
                {
                    foreach (RigaVenditaVariante rigaVenditaVariante in item.RigheVenditaVariante)
                    {
                        foreach (Ingresso ingresso in rigaVenditaVariante.Variante.Biglietto.Percorso.Ingressi)
                        {
                            if (_Ingressi.Contains(ingresso))
                            {
                                AddToList(rigaVenditaVariante, ingresso);
                            }
                        }
                    }
                }

                XPCollection<Entrata> entrate = new XPCollection<Entrata>(this.unitOfWork1);
                entrate.Criteria = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]
                {
                    new BinaryOperator("DataOraEntrata", this.dateEditInizio.DateTime, BinaryOperatorType.GreaterOrEqual),
                    new BinaryOperator("DataOraEntrata", this.dateEditFine.DateTime.AddDays(1), BinaryOperatorType.Less),
                    new NotOperator(new NullOperator("RigaStampaIngresso.Stampa.Card"))
                });

                foreach (var entrata in entrate)
                {
                    if (_Ingressi.Contains(entrata.RigaStampaIngresso.Ingresso))
                        AddCardToList(entrata);
                }

                foreach (DatiReport02 datiReport02 in _List)
                {
                    datiReport02.CalcolaPercentuali(_List);
                }

                XtraReport02 report = new XtraReport02();

                report.Init(_List, this.dateEditInizio.DateTime, this.dateEditFine.DateTime);

                report.ShowRibbonPreviewDialog();
            }
            finally
            {
                Cursor.Current = saveCursor;
            }
        }

        private void InitList()
        {
            _Descrizione = string.Empty;

            foreach (Ingresso ingresso in _Ingressi)
            {
                _Descrizione += string.IsNullOrEmpty(_Descrizione) ? ingresso.Descrizione : ", " + ingresso.Descrizione;
            }

            foreach (Ingresso ingresso in _Ingressi)
            {
                foreach (Percorso percorso in ingresso.Percorsi)
                {
                    foreach (Biglietto biglietto in percorso.BigliettiValidi)
                    {
                        foreach (Variante variante in biglietto.Varianti)
                        {
                            foreach (Titolo titolo in variante.ElencoTitoli)
                            {
                                AddToList(titolo, _Descrizione);
                            }
                        }
                    }
                }
            }

            // INTERO
            var target = new DatiReport02();
            target.Museo = _Descrizione;
            target.Titolo = null;
            target.Descrizione = STR_BigliettoIntero;
            target.Tipologia = EnumTipologiaBiglietto.Museo;
            target.TipologiaUno = EnumTipologiaUno.Singolo;
            target.TipologiaDue = EnumTipologiaDue.Intero;
            target.TipologiaTre = EnumTipologiaTre.Standard;
            target.Ordine = 10;
            _List.Add(target);

            // CUMULATIVO INTERO
            target = new DatiReport02();
            target.Museo = _Descrizione;
            target.Titolo = null;
            target.Descrizione = STR_CumulativoIntero;
            target.Tipologia = EnumTipologiaBiglietto.Cumulativo;
            target.TipologiaUno = EnumTipologiaUno.Singolo;
            target.TipologiaDue = EnumTipologiaDue.Intero;
            target.TipologiaTre = EnumTipologiaTre.Standard;
            target.Ordine = 10;
            _List.Add(target);

            // CUMULATIVO RIDOTTO
            target = new DatiReport02();
            target.Museo = _Descrizione;
            target.Titolo = null;
            target.Descrizione = STR_CumulativoRidotto;
            target.Tipologia = EnumTipologiaBiglietto.Cumulativo;
            target.TipologiaUno = EnumTipologiaUno.Singolo;
            target.TipologiaDue = EnumTipologiaDue.Ridotto;
            target.Ordine = 10;
            target.TipologiaTre = EnumTipologiaTre.Standard;
            _List.Add(target);

            // CARD INTERO
            target = new DatiReport02();
            target.Museo = _Descrizione;
            target.Titolo = null;
            target.Descrizione = STR_CardMuseiIntero;
            target.Tipologia = EnumTipologiaBiglietto.Card;
            target.TipologiaUno = EnumTipologiaUno.Singolo;
            target.TipologiaDue = EnumTipologiaDue.Intero;
            target.TipologiaTre = EnumTipologiaTre.Standard;
            target.Ordine = 10;
            _List.Add(target);

            // CARD RIDOTTO
            target = new DatiReport02();
            target.Museo = _Descrizione;
            target.Titolo = null;
            target.Descrizione = STR_CardMuseiRidotto;
            target.Tipologia = EnumTipologiaBiglietto.Card;
            target.TipologiaUno = EnumTipologiaUno.Singolo;
            target.TipologiaDue = EnumTipologiaDue.Ridotto;
            target.TipologiaTre = EnumTipologiaTre.Standard;
            target.Ordine = 10;
            _List.Add(target);

            // Bigliettone
            target = new DatiReport02();
            target.Museo = _Descrizione;
            target.Titolo = null;
            target.Descrizione = STR_Bigliettone;
            target.Tipologia = EnumTipologiaBiglietto.Museo;
            target.TipologiaUno = EnumTipologiaUno.Singolo;
            target.TipologiaDue = EnumTipologiaDue.Ridotto;
            target.TipologiaTre = EnumTipologiaTre.Bigliettone;
            target.Ordine = 10;
            _List.Add(target);

            // CardMyFE
            target = new DatiReport02();
            target.Museo = _Descrizione;
            target.Titolo = null;
            target.Descrizione = STR_CardMyFE;
            target.Tipologia = EnumTipologiaBiglietto.Museo;
            target.TipologiaUno = EnumTipologiaUno.Singolo;
            target.TipologiaDue = EnumTipologiaDue.Intero;
            target.TipologiaTre = EnumTipologiaTre.CardMyFE;
            target.Ordine = 10;
            _List.Add(target);

            // Gruppi
            target = new DatiReport02();
            target.Museo = _Descrizione;
            target.Titolo = null;
            target.Descrizione = STR_Gruppi;
            target.Tipologia = EnumTipologiaBiglietto.Museo;
            target.TipologiaUno = EnumTipologiaUno.Gruppo;
            target.TipologiaDue = EnumTipologiaDue.Ridotto;
            target.TipologiaTre = EnumTipologiaTre.Standard;
            target.Ordine = 10;
            _List.Add(target);

            // Gruppi (gratuita')
            target = new DatiReport02();
            target.Museo = _Descrizione;
            target.Titolo = null;
            target.Descrizione = STR_GruppiIngressoOmaggio;
            target.Tipologia = EnumTipologiaBiglietto.Museo;
            target.TipologiaUno = EnumTipologiaUno.Gruppo;
            target.TipologiaDue = EnumTipologiaDue.Omaggio;
            target.TipologiaTre = EnumTipologiaTre.OmaggioGruppo;
            target.Ordine = 10;
            _List.Add(target);

            // Scuola
            target = new DatiReport02();
            target.Museo = _Descrizione;
            target.Titolo = null;
            target.Descrizione = STR_Scuola;
            target.Tipologia = EnumTipologiaBiglietto.Museo;
            target.TipologiaUno = EnumTipologiaUno.Scuola;
            target.TipologiaDue = EnumTipologiaDue.Ridotto;
            target.TipologiaTre = EnumTipologiaTre.Standard;
            target.Ordine = 10;
            _List.Add(target);

            // Omaggio ?
            //target = new DatiReport02();
            //target.Museo = _Ingresso.Descrizione;
            //target.Titolo = null;
            //target.Descrizione = "Omaggio";
            //target.Tipologia = EnumTipologiaBiglietto.Museo;
            //target.TipologiaUno = EnumTipologiaUno.Singolo;
            //target.TipologiaDue = EnumTipologiaDue.Omaggio;
            //target.TipologiaTre = EnumTipologiaTre.Standard;
            //_List.Add(target);
        }

        private void AddCardToList(Entrata entrata)
        {
            DatiReport02 target = null;
            foreach (DatiReport02 dataReport02 in _List)
            {
                if (dataReport02.TipologiaTre == EnumTipologiaTre.CardMyFE)
                {
                    target = dataReport02;
                }
            }

            if (target == null)
                throw new Exception(String.Format("Target not found. CardMyFE"));

            // card myfe sempre come intero (erano ridotto, ma Zerbinati ha optato per intero il 24/09/2014),
            // anche se museo di storia naturale inserisce cardmye come omaggi
            target.PagantiIntero += entrata.RigaStampaIngresso.TotaleIngressi;

            target.CalcolaTotali();
        }

        private void AddToList(Titolo titolo, string descrizione)
        {
            DatiReport02 target = null;
            foreach (DatiReport02 dataReport02 in _List)
            {
                if (dataReport02.Titolo == titolo)
                    target = dataReport02;
            }

            if (target == null)
            {
                target = new DatiReport02();
                target.Museo = descrizione;
                target.Titolo = titolo;
                target.Descrizione = titolo.Descrizione;
                target.Tipologia = EnumTipologiaBiglietto.Museo;
                target.TipologiaUno = EnumTipologiaUno.Singolo;
                target.TipologiaDue = EnumTipologiaDue.Ridotto;
                target.TipologiaTre = EnumTipologiaTre.Standard;

                target.Ordine = 50;

                _List.Add(target);
            }
        }

        private void AddToList(RigaVenditaVariante riga, Ingresso ingresso, int level = 0)
        {
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

            DatiReport02 target = null;
            foreach (DatiReport02 dataReport02 in _List)
            {
                if (riga.Variante.Biglietto.Tipologia == EnumTipologiaBiglietto.Museo)
                {
                    if (riga.Variante.TipologiaTre == EnumTipologiaTre.Bigliettone)
                    {
                        if (dataReport02.Titolo == null && dataReport02.Descrizione == STR_Bigliettone)
                            target = dataReport02;
                    }

                    if (riga.Variante.TipologiaTre == EnumTipologiaTre.OmaggioGruppo)
                    {
                        if (riga.Variante.TipologiaUno == EnumTipologiaUno.Gruppo && riga.Variante.TipologiaDue == EnumTipologiaDue.Omaggio && riga.Variante.TipologiaTre == EnumTipologiaTre.OmaggioGruppo)
                        {
                            if (dataReport02.Titolo == null && dataReport02.Descrizione == STR_GruppiIngressoOmaggio)
                                target = dataReport02;
                        }
                    }

                    if (riga.Variante.TipologiaTre == EnumTipologiaTre.Standard)
                    {
                        if (riga.Variante.TipologiaUno == EnumTipologiaUno.Singolo)
                        {
                            if (riga.Titolo == null && dataReport02.Titolo == null && dataReport02.Descrizione == STR_BigliettoIntero)
                                target = dataReport02;

                            if (riga.Titolo != null && dataReport02.Titolo == riga.Titolo && dataReport02.Tipologia == EnumTipologiaBiglietto.Museo)
                                target = dataReport02;
                        }

                        if (riga.Variante.TipologiaUno == EnumTipologiaUno.Gruppo)
                        {
                            if (riga.Titolo == null)
                            {
                                if (dataReport02.Titolo == null && dataReport02.Descrizione == STR_Gruppi)
                                    target = dataReport02;
                            }
                            else
                            {
                                if (riga.Titolo != null && dataReport02.Titolo == riga.Titolo && dataReport02.Tipologia == EnumTipologiaBiglietto.Museo)
                                    target = dataReport02;
                            }
                        }

                        if (riga.Variante.TipologiaUno == EnumTipologiaUno.Scuola)
                        {
                            if (dataReport02.Titolo == null && dataReport02.Descrizione == STR_Scuola)
                                target = dataReport02;
                        }
                    }
                }

                if (riga.Variante.Biglietto.Tipologia == EnumTipologiaBiglietto.Cumulativo)
                {
                    if (riga.Variante.TipologiaDue == EnumTipologiaDue.Intero && dataReport02.Descrizione == STR_CumulativoIntero)
                        target = dataReport02;

                    if ((riga.Variante.TipologiaDue == EnumTipologiaDue.Ridotto || riga.Variante.TipologiaDue == EnumTipologiaDue.Omaggio) && dataReport02.Descrizione == STR_CumulativoRidotto)
                        target = dataReport02;

                    //if (riga.Variante.TipologiaUno == EnumTipologiaUno.Gruppo && riga.Variante.TipologiaDue == EnumTipologiaDue.Omaggio && riga.Variante.TipologiaTre == EnumTipologiaTre.NFR)
                    //{
                    //    if (dataReport02.Titolo == null && dataReport02.Descrizione == STR_GruppiIngressoOmaggio)
                    //        target = dataReport02;
                    //}
                }

                if (riga.Variante.Biglietto.Tipologia == EnumTipologiaBiglietto.Card && riga.Variante.TipologiaTre != EnumTipologiaTre.CardMyFE)
                {
                    if (riga.Variante.TipologiaDue == EnumTipologiaDue.Intero && dataReport02.Descrizione == STR_CardMuseiIntero)
                        target = dataReport02;

                    if ((riga.Variante.TipologiaDue == EnumTipologiaDue.Ridotto || riga.Variante.TipologiaDue == EnumTipologiaDue.Omaggio) && dataReport02.Descrizione == STR_CardMuseiRidotto)
                        target = dataReport02;
                }

                if (riga.Variante.TipologiaTre == EnumTipologiaTre.CardMyFE)
                {
                    if (dataReport02.TipologiaTre == EnumTipologiaTre.CardMyFE)
                    {
                        target = dataReport02;
                    }
                }

                if (target != null) break;
            }

            if (target == null)
            {
                //throw new Exception(String.Format("Target not found. Tipologia Variante: {0} / Biglietto: {1} / Titolo: {2}", riga.Variante.Tipologia, riga.Variante.Biglietto.Tipologia, riga.Titolo != null ? riga.Titolo.Descrizione : string.Empty));
                if (riga.Titolo != null && level == 0)
                {
                    AddToList(riga.Titolo, _Descrizione);
                    AddToList(riga, ingresso, level + 1);
                    return;
                }
                else
                {
                    XtraMessageBox.Show(String.Format("Target not found. Variante: {0} / Biglietto: {1} / Titolo: {2}", riga.Variante.Tipologia, riga.Variante.Biglietto.Tipologia, riga.Titolo != null ? riga.Titolo.Descrizione : string.Empty));
                    return;
                }
            }

            if (target.TipologiaTre == EnumTipologiaTre.CardMyFE)
            {
                // card myfe sempre come intero (erano ridotto, ma Zerbinati ha optato per intero il 24/09/2014),
                // anche se museo di storia naturale inserisce cardmye come omaggi
                target.PagantiIntero += riga.Quantita;
            }
            else
            {
                switch (riga.Variante.TipologiaDue)
                {
                    case EnumTipologiaDue.Intero:
                        target.PagantiIntero += riga.Quantita;
                        break;
                    case EnumTipologiaDue.Ridotto:
                        target.PagantiRidotto += riga.Quantita;
                        break;
                    case EnumTipologiaDue.Omaggio:
                        target.NonPaganti += riga.Quantita;
                        break;
                }
            }

            target.CalcolaTotali();

        }
    }
}