using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.XtraReports.UI;
using Musei.Module;

namespace WinTicketNext.Storico.Rep01b
{
    public partial class XtraFormReport01b : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormReport01b()
        {
            InitializeComponent();

            this.dateEditInizio.DateTime = DateTime.Now.Date.AddDays(1 - DateTime.Now.Date.Day).AddMonths(-1);
            this.dateEditFine.DateTime = this.dateEditInizio.DateTime.AddMonths(1).AddDays(-1);

            //this.lookUpEdit1.Properties.DataSource = new XPCollection<SoggettoEconomico>(this.unitOfWork1);

            XPCollection<Ingresso> data = Program.UtenteCollegato.GetMioElencoIngressi(this.unitOfWork1, Program.Postazione);
            this.checkedListBoxControl1.DataSource = data;

            //this.checkedListBoxControl1.CheckAll();
            for (int i = 0; i < data.Count; i++)
            {
                Ingresso ingresso = data[i];
                if (ingresso.Struttura.SoggettoEconomico.RagioneSociale.ToLower().Contains("comune"))
                    this.checkedListBoxControl1.SetItemChecked(i, true);
            }
        }

        private List<DatiReport01b> _List = null;
        //private SoggettoEconomico _Soggetto = null;
        private List<Ingresso> _Ingressi = null;
        private GestoreAperture _Aperture = null;
        private void simpleButtonReport_Click(object sender, EventArgs e)
        {
            _List = new List<DatiReport01b>();
            _Aperture = new GestoreAperture();
            _Ingressi = new List<Ingresso>();

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

                foreach (Ingresso ingresso in _Ingressi)
                {
                    DatiReport01b target = new DatiReport01b();
                    target.Museo = ingresso.Descrizione;
                    target.Ordine = ingresso.OrdineReport01;
                    _List.Add(target);                    
                }

                // per sicurezza aggiungo un mese alla data di fine periodo
                _Aperture.CaricaApertureIngressi(this.dateEditInizio.DateTime, this.dateEditFine.DateTime.AddMonths(1), this.unitOfWork1);
                //XPCollection<PostazioneAccesso> accessi = new XPCollection<PostazioneAccesso>(this.unitOfWork1);
                //GroupOperator periodoa1 = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                //                    new BinaryOperator("Data", this.dateEditInizio.DateTime, BinaryOperatorType.GreaterOrEqual),
                //                    new BinaryOperator("Data", this.dateEditFine.DateTime.AddMonths(1), BinaryOperatorType.LessOrEqual)});
                //accessi.Criteria = periodoa1;
                //foreach (PostazioneAccesso postazioneAccesso in accessi)
                //{
                //    foreach (PostazioneIngresso postazioneIngresso in postazioneAccesso.Postazione.Ingressi)
                //    {
                //        _Aperture.Add(postazioneIngresso.Ingresso.Oid, postazioneAccesso.Data);
                //    }
                //}

                XPCollection<Vendita> vendite = new XPCollection<Vendita>(this.unitOfWork1);
                vendite.Criteria = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                new BinaryOperator("DataContabile", this.dateEditInizio.DateTime, BinaryOperatorType.GreaterOrEqual),
                new BinaryOperator("DataContabile", this.dateEditFine.DateTime, BinaryOperatorType.LessOrEqual)});

                foreach (Vendita item in vendite)
                {
                    foreach (RigaVenditaVariante rigaVenditaVariante in item.RigheVenditaVariante)
                    {
                        AddToList(rigaVenditaVariante);
                    }
                }

                XtraReport01b report = new XtraReport01b();

                report.Init(_List, this.dateEditInizio.DateTime, this.dateEditFine.DateTime, this.memoEditInfo.Text);

                report.ShowRibbonPreviewDialog();
            }
            finally
            {
                Cursor.Current = saveCursor;
            }
        }

        private void AddToList(RigaVenditaVariante riga)
        {
            foreach (Ingresso ingresso in riga.Variante.Biglietto.Percorso.Ingressi)
            {
                //if (ingresso.SoggettoEconomico == _Soggetto)
                if (_Ingressi.Contains(ingresso))
                {
                    DatiReport01b target = null;
                    foreach (DatiReport01b dataReport01 in _List)
                    {
                        if (dataReport01.Museo == ingresso.Descrizione)
                            target = dataReport01;
                    }

                    if (target == null)
                    {
                        target = new DatiReport01b();
                        target.Museo = ingresso.Descrizione;
                        target.Ordine = ingresso.OrdineReport01;
                        _List.Add(target);
                    }

                    AddToList(target, ingresso, riga);
                }
            }
        }

        private void AddToList(DatiReport01b target, Ingresso ingresso, RigaVenditaVariante riga)
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

            // && riga.Variante.Biglietto.Tipologia == EnumTipologiaBiglietto.Museo

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
                    default:
                        throw new Exception(String.Format("Caso non previsto riga.Variante.TipologiaTre={0}", riga.Variante.TipologiaTre));
                }
            }

            target.CalcolaTotali();
        }
    }
}