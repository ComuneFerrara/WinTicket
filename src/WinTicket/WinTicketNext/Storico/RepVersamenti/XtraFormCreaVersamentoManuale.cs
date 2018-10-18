using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Xpo;
using Musei.Module;
using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;


namespace WinTicketNext.Storico
{
    public partial class XtraFormCreaVersamentoManuale : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormCreaVersamentoManuale()
        {
            InitializeComponent();
        }

        private Dictionary<DateTime, Decimal> _PosTot;
        private Dictionary<DateTime, Decimal> _PosAltri;
        private Struttura _Struttura;
        private DateTime _Inizio;
        private DateTime _Fine;

        public void Init(Struttura struttura, DateTime inizio, DateTime fine)
        {
            _Struttura = this.unitOfWork1.GetObjectByKey<Struttura>(struttura.Oid);
            _Inizio = inizio;
            _Fine = fine;

            this.Text = "Crea versamento: " + _Struttura.Descrizione;
            this.dateEditInizioPeriodo.DateTime = _Inizio;
            this.dateEditFinePeriodo.DateTime = _Fine;
            this.dateEditDataVersamento.DateTime = DateTime.Now.Date;

            this.groupControl1.Visible = false;
        }

        private void simpleButtonCalcola_Click(object sender, EventArgs e)
        {
            _Inizio = this.dateEditInizioPeriodo.DateTime.Date;
            _Fine = this.dateEditFinePeriodo.DateTime.Date;

            //this.dateEditInizioPeriodo.Enabled = false;
            this.dateEditInizioPeriodo.Properties.ReadOnly = true;

            //this.dateEditFinePeriodo.Enabled = false;
            this.dateEditFinePeriodo.Properties.ReadOnly = true;

            this.simpleButtonCalcola.Visible = false;

            this.groupControl1.Visible = true;
            this.groupControl1.Text = string.Format("Importi registrati dal {0:d} al {1:d}", _Inizio, _Fine);

            _PosTot = new Dictionary<DateTime, decimal>();
            _PosAltri = new Dictionary<DateTime, decimal>();

            XPCollection<Vendita> vendite = new XPCollection<Vendita>(this.unitOfWork1);
            vendite.Criteria = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                new BinaryOperator("Struttura.Oid", _Struttura.Oid),
                new BinaryOperator("DataContabile", _Inizio, BinaryOperatorType.GreaterOrEqual),
                new BinaryOperator("DataContabile", _Fine, BinaryOperatorType.LessOrEqual)});

            decimal posquesta = 0;
            decimal posaltre = 0;

            decimal conquesta = 0;
            decimal conaltre = 0;

            foreach (Vendita vendita in vendite)
            {
                switch (vendita.Incasso)
                {
                    case EnumIncasso.Pos:
                        foreach (RigaVenditaVariante rigaVenditaVariante in vendita.RigheVenditaVariante)
                        {
                            if (rigaVenditaVariante.Variante.Biglietto.Gestore == _Struttura.SoggettoEconomico)
                                posquesta += rigaVenditaVariante.PrezzoTotale;
                            else
                            {
                                posaltre += rigaVenditaVariante.PrezzoTotale;

                                if (_PosAltri.ContainsKey(vendita.DataContabile))
                                    _PosAltri[vendita.DataContabile] += rigaVenditaVariante.PrezzoTotale;
                                else
                                    _PosAltri[vendita.DataContabile] = rigaVenditaVariante.PrezzoTotale;
                            }

                            if (_PosTot.ContainsKey(vendita.DataContabile))
                                _PosTot[vendita.DataContabile] += rigaVenditaVariante.PrezzoTotale;
                            else
                                _PosTot[vendita.DataContabile] = rigaVenditaVariante.PrezzoTotale;
                        }
                        break;

                    case EnumIncasso.Contanti:
                        foreach (RigaVenditaVariante rigaVenditaVariante in vendita.RigheVenditaVariante)
                        {
                            if (rigaVenditaVariante.Variante.Biglietto.Gestore == _Struttura.SoggettoEconomico)
                                conquesta += rigaVenditaVariante.PrezzoTotale;
                            else
                                conaltre += rigaVenditaVariante.PrezzoTotale;
                        }
                        break;

                    default:
                        throw new Exception(String.Format("Caso non previsto: {0}", vendita.Incasso));
                }
            }

            this.textEditPosQuesto.Value = posquesta;
            this.textEditPosAltri.Value = posaltre;
            this.textEditPosTotale.Value = posquesta + posaltre;

            this.textEditConQuesto.Value = conquesta;
            this.textEditConAltri.Value = conaltre;
            this.textEditConTotale.Value = conquesta + conaltre;

            this.simpleButtonRegistra.Enabled = true;
        }

        private void simpleButtonRegistra_Click(object sender, EventArgs e)
        {
            // controlli ..
            _Inizio = this.dateEditInizioPeriodo.DateTime.Date;
            _Fine = this.dateEditFinePeriodo.DateTime.Date;

            if (_Fine < _Inizio)
            {
                // errore
                XtraMessageBox.Show("Data inizio periodo maggiore della data di fine.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Fine.Month != _Inizio.Month)
            {
                // errore
                XtraMessageBox.Show("Inizio e Fine periodo devono essere nello stesso mese.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Fine.Year != _Inizio.Year)
            {
                // errore
                XtraMessageBox.Show("Inizio e Fine periodo devono essere nello stesso anno.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Fine >= DateTime.Now.Date)
            {
                // errore
                XtraMessageBox.Show("La data di fine periodo non può essere oggi o nel futuro.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if (this.dateEditDataVersamento.DateTime.Date > DateTime.Now.Date)
            //{
            //    // errore
            //    XtraMessageBox.Show("La data del versamento non può essere nel futuro.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            Guid gruppo = Guid.NewGuid();

            Versamento vcq = new Versamento(this.unitOfWork1);
            vcq.DataVersamento = this.dateEditDataVersamento.DateTime.Date;
            vcq.InizioPeriodo = _Inizio;
            vcq.FinePeriodo = _Fine;
            vcq.Tipologia = EnumTipologiaVersamento.Incasso_Contanti;
            vcq.Incassi = this.spinEditVersamento.Value;
            vcq.Pos = 0;
            vcq.PosAltriEnti = 0;
            vcq.ImportoVersato = this.spinEditVersamento.Value;
            vcq.Struttura = _Struttura;
            vcq.SoggettoEconomico = null;
            if (this.lookUpEditBeneficiario.EditValue != null)
            {
                SoggettoEconomico soggetto = this.lookUpEditBeneficiario.EditValue as SoggettoEconomico;
                if (soggetto != null && soggetto.Oid != _Struttura.SoggettoEconomico.Oid)
                {
                    vcq.Incassi = 0;
                    vcq.SoggettoEconomico = soggetto;
                    vcq.ContanteAltriEnti = this.spinEditVersamento.Value;
                    vcq.Tipologia = EnumTipologiaVersamento.Incasso_Contanti_AltriEnti;
                }
            }
            vcq.Quietanza = this.textEditQuietanza.Text;
            vcq.Gruppo = gruppo;
            vcq.Save();

            this.unitOfWork1.CommitChanges();

            DialogResult = DialogResult.OK;
        }

        private void dateEditInizioPeriodo_EditValueChanged(object sender, EventArgs e)
        {
            this.groupControl1.Visible = false;
            this.simpleButtonRegistra.Enabled = false;
        }

        private void dateEditFinePeriodo_EditValueChanged(object sender, EventArgs e)
        {
            this.groupControl1.Visible = false;
            this.simpleButtonRegistra.Enabled = false;
        }
    }
}