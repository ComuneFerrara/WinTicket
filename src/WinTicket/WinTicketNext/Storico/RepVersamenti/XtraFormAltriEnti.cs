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
using DevExpress.XtraPrinting;

namespace WinTicketNext.Storico.RepVersamenti
{
    public partial class XtraFormAltriEnti : DevExpress.XtraEditors.XtraForm
    {
        private DatiVersamentiAltriEnti _Dato;
        private Struttura _Struttura;
        private List<DatiVersamentiAltriEnti> _Elenco;

        public XtraFormAltriEnti()
        {
            InitializeComponent();
        }

        public void Init(Struttura struttura)
        {
            _Struttura = this.unitOfWork1.GetObjectByKey<Struttura>(struttura.Oid);
            this.dateEditDataFinePeriodo.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1);
            this.dateEditVersamento.DateTime = DateTime.Now.Date;

            layoutControlGroup3.HideToCustomization();
        }

        private void Calcola()
        {
            _Elenco = new List<DatiVersamentiAltriEnti>();

            XPCollection<SoggettoEconomico> soggetti = new XPCollection<SoggettoEconomico>(this.unitOfWork1);
            foreach (SoggettoEconomico soggettoEconomico in soggetti)
            {
                if (soggettoEconomico == _Struttura.SoggettoEconomico) continue;

                XPCollection<Versamento> precedenti = new XPCollection<Versamento>(this.unitOfWork1,
                    new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                            new BinaryOperator("Tipologia", EnumTipologiaVersamento.Versamento_AdAltriEnti),
                            new BinaryOperator("Struttura", _Struttura),
                            new BinaryOperator("SoggettoEconomico", soggettoEconomico)
                        }));
                precedenti.Sorting = new SortingCollection(new SortProperty[] { new SortProperty("FinePeriodo", DevExpress.Xpo.DB.SortingDirection.Descending) });
                precedenti.TopReturnedObjects = 1;

                DatiVersamentiAltriEnti dato = new DatiVersamentiAltriEnti();
                dato.SoggettoEconomico = soggettoEconomico;
                dato.Soggetto = soggettoEconomico.RagioneSociale;

                dato.DataFine = this.dateEditDataFinePeriodo.DateTime.Date;
                if (precedenti.Count > 0)
                    dato.DataInizio = precedenti[0].FinePeriodo.AddDays(1);
                else
                    dato.DataInizio = new DateTime(2011, 6, 1);

                dato.Importo = ImportoVendite(_Struttura, dato.DataInizio, dato.DataFine, soggettoEconomico);

                _Elenco.Add(dato);
            }

            this.gridControl1.DataSource = _Elenco;
            this.gridView1.BestFitColumns();
        }

        private decimal ImportoVendite(Struttura struttura, DateTime inizio, DateTime fine, SoggettoEconomico soggetto)
        {
            XPCollection<Vendita> vendite = new XPCollection<Vendita>(this.unitOfWork1);
            vendite.Criteria = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                new BinaryOperator("Struttura", struttura),
                new BinaryOperator("DataContabile", inizio, BinaryOperatorType.GreaterOrEqual),
                new BinaryOperator("DataContabile", fine, BinaryOperatorType.LessOrEqual)});

            decimal result = 0;
            foreach (Vendita vendita in vendite)
            {
                foreach (RigaVenditaVariante rigaVenditaVariante in vendita.RigheVenditaVariante)
                {
                    if (rigaVenditaVariante.Variante.Biglietto.Gestore == soggetto)
                        result += rigaVenditaVariante.PrezzoTotale;                   
                }
            }

            return result;
        }

        private void simpleButtonCalcola_Click(object sender, EventArgs e)
        {
            Cursor saveCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.tabbedControlGroup1.SelectedTabPage = layoutControlGroup2;

                Calcola();
            }
            finally
            {
                Cursor.Current = saveCursor;
            }
        }

        private void simpleButtonRegistra_Click(object sender, EventArgs e)
        {
            Guid gruppo = Guid.NewGuid();

            Versamento versamento = new Versamento(this.unitOfWork1);
            versamento.ContanteAltriEnti = -_Dato.Importo;
            versamento.DataVersamento = this.dateEditVersamento.DateTime.Date;
            versamento.FinePeriodo = _Dato.DataFine;
            versamento.InizioPeriodo = _Dato.DataInizio;
            versamento.SoggettoEconomico = _Dato.SoggettoEconomico;
            versamento.Struttura = _Struttura;
            versamento.Tipologia = EnumTipologiaVersamento.Versamento_AdAltriEnti;
            versamento.Gruppo = gruppo;
            versamento.Save();

            this.unitOfWork1.CommitChanges();

            DialogResult = DialogResult.OK;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            _Dato = this.gridView1.GetFocusedRow() as DatiVersamentiAltriEnti;
            if (_Dato != null)
            {
                this.textEditStruttura.Text = _Struttura.Descrizione;
                this.textEditSoggetto.Text = _Struttura.SoggettoEconomico.RagioneSociale;
                this.textEditDestinatario.Text = _Dato.SoggettoEconomico.RagioneSociale;
                this.dateEditInizio.DateTime = _Dato.DataInizio;
                this.dateEditFine.DateTime = _Dato.DataFine;
                this.spinEditImporto.Value = _Dato.Importo;

                layoutControlGroup2.HideToCustomization();
                tabbedControlGroup1.HideToCustomization();
                layoutControlGroup3.RestoreFromCustomization();
            }
        }

        private void simpleButtonStampa_Click(object sender, EventArgs e)
        {
            PageHeaderFooter header = new PageHeaderFooter();
            header.Footer.Content.Add(Program.UtenteCollegato.FullName);
            header.Footer.Content.Add(Program.Postazione.Nome);
            header.Footer.Content.Add(string.Format("{0:g}", DateTime.Now));

            header.Header.Content.Add("");
            header.Header.Content.Add("Importi dovuti ad altri enti");
            header.Header.Content.Add("");

            if (layoutControlGroup3.Visible)
            {
                this.printableComponentLink2.PageHeaderFooter = header;

                this.printableComponentLink2.CreateDocument();
                this.printableComponentLink2.ShowRibbonPreviewDialog(DevExpress.LookAndFeel.UserLookAndFeel.Default);
            }
            else
            {
                this.printableComponentLink1.PageHeaderFooter = header;

                this.printableComponentLink1.CreateDocument();
                this.printableComponentLink1.ShowRibbonPreviewDialog(DevExpress.LookAndFeel.UserLookAndFeel.Default);
            }
        }
    }
}