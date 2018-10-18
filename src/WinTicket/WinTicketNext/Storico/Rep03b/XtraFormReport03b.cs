using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using Musei.Module;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace WinTicketNext.Storico.Rep03b
{
    public partial class XtraFormReport03b : DevExpress.XtraEditors.XtraForm
    {

        public XtraFormReport03b()
        {
            InitializeComponent();

            this.spinEditAnno.Value = DateTime.Now.Year;
            //this.lookUpEdit1.Properties.DataSource = new XPCollection<SoggettoEconomico>(this.unitOfWork1);

            XPCollection<Ingresso> data = Program.UtenteCollegato.GetMioElencoIngressi(this.unitOfWork1, Program.Postazione);
            this.checkedListBoxControl2.DataSource = data;
            //for (int i = 0; i < data.Count; i++)
            //{
            //    Ingresso ingresso = data[i];
            //    if (ingresso.Struttura.SoggettoEconomico.RagioneSociale.ToLower().Contains("comune"))
            //        this.checkedListBoxControl2.SetItemChecked(i, true);
            //}

        }

        private List<DatiReport03b> _List = null;
        //private SoggettoEconomico _Soggetto = null;
        private GestoreAperture _Aperture = null;
        private List<Ingresso> _Ingressi = null;
        private void simpleButtonReport_Click(object sender, EventArgs e)
        {
            //_Soggetto = this.lookUpEdit1.EditValue as SoggettoEconomico;
            _List = new List<DatiReport03b>();
            _Aperture = new GestoreAperture();
            _Ingressi = new List<Ingresso>();

            //if (_Soggetto == null)
            //{
            //    XtraMessageBox.Show("Selezionare un soggetto");
            //    return;
            //}

            foreach (var item in this.checkedListBoxControl2.CheckedItems)
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

            Cursor saveCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                int anno = (int)this.spinEditAnno.Value;
                DateTime inizio = new DateTime(anno, 1, 1);
                DateTime fine = new DateTime(anno, 12, 31);

                InitList(inizio);

                _Aperture.CaricaApertureIngressi(inizio, fine.AddMonths(1), this.unitOfWork1);

                XPCollection<Vendita> vendite = new XPCollection<Vendita>(this.unitOfWork1);
                vendite.Criteria = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]
                {
                    new BinaryOperator("DataContabile", inizio, BinaryOperatorType.GreaterOrEqual),
                    new BinaryOperator("DataContabile", fine, BinaryOperatorType.LessOrEqual)
                });

                bool[] mesi = new bool[20];
                foreach (CheckedListBoxItem item in this.checkedListBoxControl1.CheckedItems)
                {
                    mesi[(int)item.Value] = true;
                }                    

                foreach (Vendita vendita in vendite)
                {
                    if (!mesi[vendita.DataContabile.Month]) continue;

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

                XPCollection<Entrata> entrate = new XPCollection<Entrata>(this.unitOfWork1);
                entrate.Criteria = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]
                {
                    new BinaryOperator("DataOraEntrata", inizio, BinaryOperatorType.GreaterOrEqual),
                    new BinaryOperator("DataOraEntrata", fine.AddDays(1), BinaryOperatorType.Less),
                    new NotOperator(new NullOperator("RigaStampaIngresso.Stampa.Card"))
                });

                foreach (var entrata in entrate)
                {
                    if (_Ingressi.Contains(entrata.RigaStampaIngresso.Ingresso))
                        AddCardToList(mesi, entrata);
                }


                XtraReport03b report = new XtraReport03b();

                report.Init(_List, anno, this.memoEditInfo.Text);

                report.ShowRibbonPreviewDialog();
            }
            finally
            {
                Cursor.Current = saveCursor;
            }
        }

        private void AddCardToList(bool[] mesi, Entrata entrata)
        {
            DatiReport03b target = null;
            foreach (DatiReport03b datiReport03b in _List)
            {
                if (datiReport03b.Museo == entrata.RigaStampaIngresso.Ingresso.Descrizione)
                    target = datiReport03b;
            }

            if (target == null)
            {
                target = new DatiReport03b();
                target.Museo = entrata.RigaStampaIngresso.Ingresso.Descrizione;
                target.Tipo = entrata.RigaStampaIngresso.Ingresso.DescrizioneTipo;
                target.Ordine = entrata.RigaStampaIngresso.Ingresso.OrdineReport01;
                target.Tipologia = entrata.RigaStampaIngresso.Ingresso.Tipologia;

                _List.Add(target);
            }

            if (!mesi[entrata.DataOraEntrata.Month]) return;

            switch (entrata.DataOraEntrata.Month)
            {
                case 1:
                    target.M01Pag += entrata.RigaStampaIngresso.TotaleIngressi;
                    break;
                case 2:
                    target.M02Pag += entrata.RigaStampaIngresso.TotaleIngressi;
                    break;
                case 3:
                    target.M03Pag += entrata.RigaStampaIngresso.TotaleIngressi;
                    break;
                case 4:
                    target.M04Pag += entrata.RigaStampaIngresso.TotaleIngressi;
                    break;
                case 5:
                    target.M05Pag += entrata.RigaStampaIngresso.TotaleIngressi;
                    break;
                case 6:
                    target.M06Pag += entrata.RigaStampaIngresso.TotaleIngressi;
                    break;
                case 7:
                    target.M07Pag += entrata.RigaStampaIngresso.TotaleIngressi;
                    break;
                case 8:
                    target.M08Pag += entrata.RigaStampaIngresso.TotaleIngressi;
                    break;
                case 9:
                    target.M09Pag += entrata.RigaStampaIngresso.TotaleIngressi;
                    break;
                case 10:
                    target.M10Pag += entrata.RigaStampaIngresso.TotaleIngressi;
                    break;
                case 11:
                    target.M11Pag += entrata.RigaStampaIngresso.TotaleIngressi;
                    break;
                case 12:
                    target.M12Pag += entrata.RigaStampaIngresso.TotaleIngressi;
                    break;
                default:
                    throw new Exception("Mese non previsto");
            }

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

        private void AddToList(Ingresso ingresso, int qta, DateTime dateTime, EnumTipologiaEconomica enumTipologiaEconomica, RigaVenditaVariante riga)
        {
            DatiReport03b target = null;
            foreach (DatiReport03b datiReport03b in _List)
            {
                if (datiReport03b.Museo == ingresso.Descrizione)
                    target = datiReport03b;
            }

            if (target == null)
            {
                target = new DatiReport03b();
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
                switch (dateTime.Month)
                {
                    case 1:
                        target.M01Pag += qta;
                        break;
                    case 2:
                        target.M02Pag += qta;
                        break;
                    case 3:
                        target.M03Pag += qta;
                        break;
                    case 4:
                        target.M04Pag += qta;
                        break;
                    case 5:
                        target.M05Pag += qta;
                        break;
                    case 6:
                        target.M06Pag += qta;
                        break;
                    case 7:
                        target.M07Pag += qta;
                        break;
                    case 8:
                        target.M08Pag += qta;
                        break;
                    case 9:
                        target.M09Pag += qta;
                        break;
                    case 10:
                        target.M10Pag += qta;
                        break;
                    case 11:
                        target.M11Pag += qta;
                        break;
                    case 12:
                        target.M12Pag += qta;
                        break;
                    default:
                        throw new Exception("Mese non previsto");
                }
            }
            else if (enumTipologiaEconomica == EnumTipologiaEconomica.Gratuito)
            {
                switch (dateTime.Month)
                {
                    case 1:
                        target.M01NPag += qta;
                        break;
                    case 2:
                        target.M02NPag += qta;
                        break;
                    case 3:
                        target.M03NPag += qta;
                        break;
                    case 4:
                        target.M04NPag += qta;
                        break;
                    case 5:
                        target.M05NPag += qta;
                        break;
                    case 6:
                        target.M06NPag += qta;
                        break;
                    case 7:
                        target.M07NPag += qta;
                        break;
                    case 8:
                        target.M08NPag += qta;
                        break;
                    case 9:
                        target.M09NPag += qta;
                        break;
                    case 10:
                        target.M10NPag += qta;
                        break;
                    case 11:
                        target.M11NPag += qta;
                        break;
                    case 12:
                        target.M12NPag += qta;
                        break;
                    default:
                        throw new Exception("Mese non previsto");
                }
            }
            else throw new Exception("EnumTipologiaEconomica non previsto: " + enumTipologiaEconomica);

            target.CalcolaTotale();
        }


    }
}