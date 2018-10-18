using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Xpo;
using Musei.Module;
using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;


namespace WinTicketNext.Storico
{
    public partial class XtraFormCreaVersamento : XtraForm
    {
        public XtraFormCreaVersamento()
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
            this.dateEdit1.DateTime = DateTime.Now.Date;

            this.groupControl1.Visible = false;
        }

        public void WipeOutPos()
        {
            // wipe out
            XPCollection<Versamento> todeletePos = new XPCollection<Versamento>(this.unitOfWork1, new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                new BinaryOperator("Struttura.Oid", _Struttura.Oid),
                new BinaryOperator("DataVersamento", _Inizio, BinaryOperatorType.GreaterOrEqual),
                new BinaryOperator("DataVersamento", _Fine, BinaryOperatorType.LessOrEqual),
                new BinaryOperator("Tipologia", EnumTipologiaVersamento.Incasso_Pos)
            }));
            this.unitOfWork1.Delete(todeletePos);

            XPCollection<Versamento> todeleteCon = new XPCollection<Versamento>(this.unitOfWork1, new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                new BinaryOperator("Struttura.Oid", _Struttura.Oid),
                new BinaryOperator("InizioPeriodo", _Inizio, BinaryOperatorType.Equal),
                new BinaryOperator("Tipologia", EnumTipologiaVersamento.Incasso_Contanti)
            }));
            this.unitOfWork1.Delete(todeleteCon);

            this.unitOfWork1.CommitChanges();
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

                    case EnumIncasso.Internet:
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

            this.spinEditVersamento.Value = conquesta - posaltre;

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

            if (this.dateEdit1.DateTime.Date < _Fine)
            {
                // errore
                XtraMessageBox.Show("La data del versamento deve essere dopo la data di fine periodo.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Fine >= DateTime.Now.Date)
            {
                // errore
                XtraMessageBox.Show("La data di fine periodo non può essere oggi o nel futuro.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if (this.dateEdit1.DateTime.Date > DateTime.Now.Date)
            //{
            //    // errore
            //    XtraMessageBox.Show("La data del versamento non può essere nel futuro.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            // CHECK INIZIO
            XPCollection<Versamento> check = new XPCollection<Versamento>(this.unitOfWork1, new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                new BinaryOperator("FinePeriodo", _Inizio.AddDays(-1), BinaryOperatorType.Equal),
                new BinaryOperator("Struttura.Oid", _Struttura.Oid),
                new BinaryOperator("Tipologia", EnumTipologiaVersamento.Incasso_Contanti)
            }));
            check.TopReturnedObjects = 1;
            if (check.Count == 0)
            {
                check = new XPCollection<Versamento>(this.unitOfWork1, new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                    new GroupOperator(GroupOperatorType.Or, new CriteriaOperator[]{
                        new BinaryOperator("FinePeriodo", _Inizio.AddDays(-1), BinaryOperatorType.Less),
                        new BinaryOperator("InizioPeriodo", _Inizio, BinaryOperatorType.Less)}),
                    new BinaryOperator("Struttura.Oid", _Struttura.Oid),
                    new BinaryOperator("Tipologia", EnumTipologiaVersamento.Incasso_Contanti) }));

                if (check.Count == 0)
                {
                    // ok
                }
                else
                {
                    // errore
                    XtraMessageBox.Show("Data inizio periodo NON combacia con periodo precedente", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            } // else OK

            // CHECK FINE
            check = new XPCollection<Versamento>(this.unitOfWork1, new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                    new BinaryOperator("InizioPeriodo", _Fine, BinaryOperatorType.LessOrEqual),
                    new BinaryOperator("InizioPeriodo", _Inizio, BinaryOperatorType.Greater),
                    new BinaryOperator("Struttura.Oid", _Struttura.Oid),
                    new BinaryOperator("Tipologia", EnumTipologiaVersamento.Incasso_Contanti) }));
            if (check.Count != 0)
            {
                XtraMessageBox.Show("Data fine periodo NON combacia con i dati presenti in archivio", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } // else OK

            if (this.spinEditFondoCassaTrattenuti.Value > 0 && this.spinEditFondoCassaVersamento.Value > 0)
                throw new Exception("imprevisto da gestire");

            WipeOutPos();

            Guid gruppo = Guid.NewGuid();

            foreach (KeyValuePair<DateTime, Decimal> vpo in _PosTot)
            {
                Versamento versamento = new Versamento(this.unitOfWork1);
                versamento.DataVersamento = vpo.Key;
                versamento.InizioPeriodo = versamento.FinePeriodo = vpo.Key;
                versamento.Tipologia = EnumTipologiaVersamento.Incasso_Pos;
                versamento.Incassi = versamento.Pos = vpo.Value;
                if (_PosAltri.ContainsKey(vpo.Key)) versamento.PosAltriEnti = _PosAltri[vpo.Key];
                versamento.ContanteAltriEnti = 0;
                versamento.Struttura = _Struttura;
                versamento.Gruppo = gruppo;
                versamento.Save();
            }

            Versamento vcq = new Versamento(this.unitOfWork1);
            vcq.DataVersamento = this.dateEdit1.DateTime.Date;
            vcq.InizioPeriodo = _Inizio;
            vcq.FinePeriodo = _Fine;
            vcq.Tipologia = EnumTipologiaVersamento.Incasso_Contanti;
            vcq.Incassi = this.textEditConQuesto.Value - this.textEditPosAltri.Value;
            vcq.Pos = 0;
            vcq.ContanteAltriEnti = 0;
            vcq.PosAltriEnti = 0;
            vcq.ImportoVersato = this.textEditConQuesto.Value - this.textEditPosAltri.Value - this.spinEditFondoCassaTrattenuti.Value;
            vcq.Struttura = _Struttura;
            vcq.SoggettoEconomico = null;
            vcq.Gruppo = gruppo;
            vcq.Save();

            decimal altrienti = this.textEditConAltri.Value + this.textEditPosAltri.Value;
            if (altrienti > 0)
            {
                Versamento vca = new Versamento(this.unitOfWork1);
                vca.DataVersamento = this.dateEdit1.DateTime.Date;
                vca.InizioPeriodo = _Inizio;
                vca.FinePeriodo = _Fine;
                vca.Tipologia = EnumTipologiaVersamento.Incasso_Contanti_AltriEnti;
                vca.Incassi = altrienti;
                vca.Pos = 0;
                vca.ContanteAltriEnti = altrienti;
                vca.PosAltriEnti = 0;
                vca.ImportoVersato = altrienti;
                vca.Struttura = _Struttura;
                vca.SoggettoEconomico = this.unitOfWork1.FindObject<SoggettoEconomico>(new BinaryOperator("RagioneSociale", "%provincia%", BinaryOperatorType.Like));
                vca.Gruppo = gruppo;
                vca.Save();
            }

            if (this.spinEditFondoCassaVersamento.Value > 0)
            {
                Versamento vcassa = new Versamento(this.unitOfWork1);
                vcassa.DataVersamento = this.dateEdit1.DateTime.Date;
                vcassa.InizioPeriodo = _Fine;
                vcassa.FinePeriodo = _Fine;
                vcassa.Tipologia = EnumTipologiaVersamento.FondoCassa_Versamento;
                vcassa.Incassi = 0;
                vcassa.Pos = 0;
                vcassa.ContanteAltriEnti = 0;
                vcassa.PosAltriEnti = 0;
                vcassa.ImportoVersato = this.spinEditFondoCassaVersamento.Value;
                vcassa.Struttura = _Struttura;
                vcassa.SoggettoEconomico = null;
                vcassa.Gruppo = gruppo;
                vcassa.Save();
            }

            if (this.spinEditFondoCassaTrattenuti.Value > 0)
            {
                Versamento vcassa = new Versamento(this.unitOfWork1);
                vcassa.DataVersamento = this.dateEdit1.DateTime.Date;
                vcassa.InizioPeriodo = _Fine;
                vcassa.FinePeriodo = _Fine;
                vcassa.Tipologia = EnumTipologiaVersamento.FondoCassa_Trattenuta;
                vcassa.Incassi = 0;
                vcassa.Pos = 0;
                vcassa.ContanteAltriEnti = 0;
                vcassa.PosAltriEnti = 0;
                vcassa.ImportoVersato = this.spinEditFondoCassaTrattenuti.Value;
                vcassa.Struttura = _Struttura;
                vcassa.SoggettoEconomico = null;
                vcassa.Gruppo = gruppo;
                vcassa.Save();
            }

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