using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using Musei.Module;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace WinTicketNext.Storico.Rep01
{
    public partial class XtraFormReport01 : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormReport01()
        {
            InitializeComponent();

            this.dateEditInizio.DateTime = DateTime.Now.Date.AddDays(1 - DateTime.Now.Date.Day).AddMonths(-1);
            this.dateEditFine.DateTime = this.dateEditInizio.DateTime.AddMonths(1).AddDays(-1);
            this.lookUpEdit1.Properties.DataSource = Program.UtenteCollegato.GetMioElencoIngressi(this.unitOfWork1, Program.Postazione);
        }

        private List<DatiReport01> _List = null;
        private Ingresso _Ingresso = null;
        private GestoreAperture _Aperture = null;
        private void simpleButtonReport_Click(object sender, EventArgs e)
        {
            _Ingresso = this.lookUpEdit1.EditValue as Ingresso;
            _List = new List<DatiReport01>();
            _Aperture = new GestoreAperture();

            if (_Ingresso == null) return;

            if (this.dateEditFine.DateTime.Date >= DateTime.Now.Date)
            {
                XtraMessageBox.Show("Data Fine non può essere maggiore della data odierna", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cursor saveCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _Aperture.CaricaApertureIngressi(this.dateEditInizio.DateTime, this.dateEditFine.DateTime.AddMonths(1), this.unitOfWork1);

                XPCollection<Vendita> vendite = new XPCollection<Vendita>(this.unitOfWork1);
                vendite.Criteria = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]
                {
                    new BinaryOperator("DataContabile", this.dateEditInizio.DateTime, BinaryOperatorType.GreaterOrEqual),
                    new BinaryOperator("DataContabile", this.dateEditFine.DateTime, BinaryOperatorType.LessOrEqual)
                });

                foreach (Vendita item in vendite)
                {
                    foreach (RigaVenditaVariante rigaVenditaVariante in item.RigheVenditaVariante)
                    {
                        foreach (Ingresso ingresso in rigaVenditaVariante.Variante.Biglietto.Percorso.Ingressi)
                        {
                            if (ingresso.Oid == _Ingresso.Oid)
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
                    new BinaryOperator("RigaStampaIngresso.Ingresso.Oid", _Ingresso.Oid), 
                    new NotOperator(new NullOperator("RigaStampaIngresso.Stampa.Card"))
                });

                foreach (var entrata in entrate)
                {
                    AddCardToList(entrata, _Ingresso);
                }


                XtraReport01 report = new XtraReport01();

                report.Init(_List, this.dateEditInizio.DateTime, this.dateEditFine.DateTime, this.memoEditInfo.Text);

                report.ShowRibbonPreviewDialog();
            }
            finally
            {
                Cursor.Current = saveCursor;
            }
        }

        private void AddCardToList(Entrata entrata, Ingresso ingresso)
        {
            int fascia = entrata.DataOraEntrata.Hour;

            DatiReport01 target = null;
            foreach (DatiReport01 dataReport01 in _List)
            {
                if (dataReport01.InizioFasciaOraria == fascia)
                    target = dataReport01;
            }

            if (target == null)
            {
                target = new DatiReport01();
                target.Museo = ingresso.Descrizione;
                target.InizioFasciaOraria = fascia;

                _List.Add(target);
            }

            //if (riga.Vendita.Struttura.Oid == _Ingresso.Struttura.Oid)
            if (entrata.RigaStampaIngresso.Stampa.Vendita.Struttura.Oid == ingresso.Struttura.Oid)
                target.MuseoMyFE += entrata.RigaStampaIngresso.TotaleIngressi;
            else
                target.AltriMyFE += entrata.RigaStampaIngresso.TotaleIngressi;

            target.CalcolaTotali();
        }

        private void AddToList(RigaVenditaVariante riga, Ingresso ingresso)
        {
            int fascia = riga.Vendita.DataOraStampa.Hour;

            DatiReport01 target = null;
            foreach (DatiReport01 dataReport01 in _List)
            {
                if (dataReport01.InizioFasciaOraria == fascia)
                    target = dataReport01;
            }

            if (target == null)
            {
                target = new DatiReport01();
                target.Museo = ingresso.Descrizione;
                target.InizioFasciaOraria = fascia;

                _List.Add(target);
            }

            // filtro in base alle giornate di apertura
            //if (ingresso.IsAttrib(EventoParticolare.STR_INGRESSI_VERIFICA_VALIDITA) && !_Aperture.Valido(ingresso.Oid, riga.Vendita.DataContabile))
            //    return;
            if (ingresso.IsAttrib(EventoParticolare.STR_INGRESSI_NO_VENDITA_DA_ALTRI) && riga.Vendita.Struttura != ingresso.Struttura)
                return;
            if (riga.Vendita.Struttura != ingresso.Struttura && riga.Vendita.DataContabile.Year <= 2011 && riga.Vendita.DataContabile.Month < 6)
                return;
            if (ingresso.IsAttrib(EventoParticolare.STR_INGRESSI_MOD_TERREMOTO_1) && (riga.Vendita.DataContabile > EventoParticolare.EQDataEvento && riga.Vendita.DataContabile.Year < 2015 && !_Aperture.Valido(ingresso.Oid, riga.Vendita.DataContabile)))
                return;
            // esclusione doppia card provincia per split prezzo
            if (riga.Variante.TipologiaTre == EnumTipologiaTre.CardMyFE && riga.Variante.TipologiaDue == EnumTipologiaDue.Ridotto && riga.Variante.PrezzoAttuale.PrezzoRidotto == null)
                return;
            // esclusione di tutte le card ridotte (gli omaggio sono del museo di storia naturale e vanno conteggiati)
            if (riga.Variante.TipologiaTre == EnumTipologiaTre.CardMyFE && riga.Variante.TipologiaDue == EnumTipologiaDue.Ridotto)
                return;

            if (riga.Vendita.Struttura.Oid == ingresso.Struttura.Oid)
            {
                // emesso da questa struttura

                switch (riga.Variante.TipologiaTre)
                {
                    case EnumTipologiaTre.Standard:

                        switch (riga.Variante.Biglietto.Tipologia)
                        {
                            case EnumTipologiaBiglietto.Museo:
                                switch (riga.Variante.TipologiaDue)
                                {
                                    case EnumTipologiaDue.Intero:
                                        target.MuseoStandardIntero += riga.Quantita;
                                        break;
                                    case EnumTipologiaDue.Ridotto:
                                        target.MuseoStandardRidotto += riga.Quantita;
                                        break;
                                    case EnumTipologiaDue.Omaggio:
                                        target.MuseoOmaggio += riga.Quantita;
                                        break;
                                    default:
                                        throw new Exception(String.Format("Caso non previsto riga.Variante.TipologiaDue={0}", riga.Variante.TipologiaDue));
                                }
                                break;
                            case EnumTipologiaBiglietto.Cumulativo:
                                switch (riga.Variante.TipologiaDue)
                                {
                                    case EnumTipologiaDue.Intero:
                                        target.MuseoCumulativoIntero += riga.Quantita;
                                        break;
                                    case EnumTipologiaDue.Ridotto:
                                        target.MuseoCumulativoRidotto += riga.Quantita;
                                        break;
                                    case EnumTipologiaDue.Omaggio:
                                        target.MuseoOmaggio += riga.Quantita;
                                        break;
                                    default:
                                        throw new Exception(String.Format("Caso non previsto riga.Variante.TipologiaDue={0}", riga.Variante.TipologiaDue));
                                }
                                break;
                            case EnumTipologiaBiglietto.Card:
                                switch (riga.Variante.TipologiaDue)
                                {
                                    case EnumTipologiaDue.Intero:
                                        target.MuseoCardIntero += riga.Quantita;
                                        break;
                                    case EnumTipologiaDue.Ridotto:
                                        target.MuseoCardRidotto += riga.Quantita;
                                        break;
                                    case EnumTipologiaDue.Omaggio:
                                        target.MuseoOmaggio += riga.Quantita;
                                        break;
                                    default:
                                        throw new Exception(String.Format("Caso non previsto riga.Variante.TipologiaDue={0}", riga.Variante.TipologiaDue));
                                }
                                break;
                            default:
                                throw new Exception(String.Format("Caso non previsto riga.Variante.Biglietto.Tipologia={0}", riga.Variante.Biglietto.Tipologia));
                        }

                        break;
                    case EnumTipologiaTre.Bigliettone:
                        target.MuseoBigliettone += riga.Quantita;
                        break;
                    case EnumTipologiaTre.OmaggioGruppo:
                        target.MuseoOmaggio += riga.Quantita;
                        break;
                    case EnumTipologiaTre.CardMyFE:
                        target.MuseoMyFE += riga.Quantita;
                        break;
                    default:
                        throw new Exception(String.Format("Caso non previsto riga.Variante.TipologiaTre={0}", riga.Variante.TipologiaTre));
                }

            }
            else
            {
                // altre strutture

                switch (riga.Variante.TipologiaTre)
                {
                    case EnumTipologiaTre.Standard:

                        switch (riga.Variante.Biglietto.Tipologia)
                        {
                            case EnumTipologiaBiglietto.Museo:
                                switch (riga.Variante.TipologiaDue)
                                {
                                    case EnumTipologiaDue.Intero:
                                        target.AltriStandardIntero += riga.Quantita;
                                        //riga.Vendita.Stampe[0].StatoStampa == riga.Profilo;
                                        //riga.Vendita.Stampe[0].RigheStampaIngresso[0].Entrate
                                        break;
                                    case EnumTipologiaDue.Ridotto:
                                        target.AltriStandardRidotto += riga.Quantita;
                                        break;
                                    case EnumTipologiaDue.Omaggio:
                                        target.AltriOmaggio += riga.Quantita;
                                        break;
                                    default:
                                        throw new Exception(String.Format("Caso non previsto riga.Variante.TipologiaDue={0}", riga.Variante.TipologiaDue));
                                }
                                break;
                            case EnumTipologiaBiglietto.Cumulativo:
                                switch (riga.Variante.TipologiaDue)
                                {
                                    case EnumTipologiaDue.Intero:
                                        target.AltriCumulativoIntero += riga.Quantita;
                                        break;
                                    case EnumTipologiaDue.Ridotto:
                                        target.AltriCumulativoRidotto += riga.Quantita;
                                        break;
                                    case EnumTipologiaDue.Omaggio:
                                        target.AltriOmaggio += riga.Quantita;
                                        break;
                                    default:
                                        throw new Exception(String.Format("Caso non previsto riga.Variante.TipologiaDue={0}", riga.Variante.TipologiaDue));
                                }
                                break;
                            case EnumTipologiaBiglietto.Card:
                                switch (riga.Variante.TipologiaDue)
                                {
                                    case EnumTipologiaDue.Intero:
                                        target.AltriCardIntero += riga.Quantita;
                                        break;
                                    case EnumTipologiaDue.Ridotto:
                                        target.AltriCardRidotto += riga.Quantita;
                                        break;
                                    case EnumTipologiaDue.Omaggio:
                                        target.AltriOmaggio += riga.Quantita;
                                        break;
                                    default:
                                        throw new Exception(String.Format("Caso non previsto riga.Variante.TipologiaDue={0}", riga.Variante.TipologiaDue));
                                }
                                break;
                            default:
                                throw new Exception(String.Format("Caso non previsto riga.Variante.Biglietto.Tipologia={0}", riga.Variante.Biglietto.Tipologia));
                        }

                        break;
                    case EnumTipologiaTre.Bigliettone:
                        target.AltriBigliettone += riga.Quantita;
                        break;
                    case EnumTipologiaTre.OmaggioGruppo:
                        target.AltriOmaggio += riga.Quantita;
                        break;
                    case EnumTipologiaTre.CardMyFE:
                        target.AltriMyFE += riga.Quantita;
                        break;
                    default:
                        throw new Exception(String.Format("Caso non previsto riga.Variante.TipologiaTre={0}", riga.Variante.TipologiaTre));
                }
            }

            target.CalcolaTotali();

        }
    }
}