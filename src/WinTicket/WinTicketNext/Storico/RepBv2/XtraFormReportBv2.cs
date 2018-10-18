using System;
using System.Collections.Generic;
using Musei.Module;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace WinTicketNext.Storico.RepBv2
{
    public partial class XtraFormReportBv2 : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormReportBv2()
        {
            InitializeComponent();

            this.dateEditInizio.DateTime = DateTime.Now.Date.AddDays(1 - DateTime.Now.Date.Day).AddMonths(-1);
            this.dateEditFine.DateTime = this.dateEditInizio.DateTime.AddMonths(1).AddDays(-1);
            this.lookUpEdit1.Properties.DataSource = Program.UtenteCollegato.GetMioElencoStrutture(this.unitOfWork1, Program.Postazione);
        }

        private DatiReportBv2 _Dati = null;
        private Struttura _Struttura = null;
        private void simpleButtonReport_Click(object sender, EventArgs e)
        {
            if (this.dateEditFine.DateTime.Date >= DateTime.Now.Date)
            {
                XtraMessageBox.Show("Data Fine non può essere maggiore della data odierna", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Struttura = this.lookUpEdit1.EditValue as Struttura;

            if (_Struttura != null)
            {
                _Dati = new DatiReportBv2
                {
                    PerAltri = new List<VendutiPerTerzi>(),
                    Cumulativi = new List<Cumulativi>(),
                    Inizio = this.dateEditInizio.DateTime,
                    Fine = this.dateEditFine.DateTime,
                    Struttura = _Struttura.Descrizione
                };

                XPCollection<Vendita> vendite = new XPCollection<Vendita>(this.unitOfWork1);
                vendite.Criteria = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                new BinaryOperator("DataContabile", this.dateEditInizio.DateTime, BinaryOperatorType.GreaterOrEqual),
                new BinaryOperator("DataContabile", this.dateEditFine.DateTime, BinaryOperatorType.LessOrEqual)});

                foreach (Vendita item in vendite)
                {
                    // vendita effettuata da questa struttura
                    foreach (RigaVenditaVariante rigaVenditaVariante in item.RigheVenditaVariante)
                    {
                        List<Struttura> strutture = new List<Struttura>();
                        int numeroIngressi = rigaVenditaVariante.Variante.Biglietto.Percorso.Ingressi.Count;
                        int questaStruttura = 0;
                        foreach (Ingresso ingresso in rigaVenditaVariante.Variante.Biglietto.Percorso.Ingressi)
                        {
                            if (!strutture.Contains(ingresso.Struttura))
                                strutture.Add(ingresso.Struttura);

                            if (ingresso.Struttura == _Struttura)
                                questaStruttura++;
                        }

                        if (questaStruttura == numeroIngressi)
                        {
                            // la variante comprende SOLO ingressi di questa struttura
                            SoloQuesta(item, rigaVenditaVariante);
                        }
                        else if (questaStruttura == 0 && strutture.Count == 1)
                        {
                            // solo ALTRI musei
                            SoloAltre(item, rigaVenditaVariante);
                        }
                        else
                        {
                            // cumulativo/card
                            Cumulativo(item, rigaVenditaVariante, strutture);
                        }
                    }
                }

                XtraReportBv2 report = new XtraReportBv2();
                report.Init(_Dati);

                report.ShowRibbonPreviewDialog(DevExpress.LookAndFeel.UserLookAndFeel.Default);

            }
        }

        private void Cumulativo(Vendita item, RigaVenditaVariante rigaVenditaVariante, List<Struttura> strutture)
        {
            if (item.Struttura == _Struttura)
            {
                // non interessa
            }
            else
            {
                if (strutture.Contains(_Struttura))
                {
                    Cumulativi dato = _Dati.CumulativiCerca(rigaVenditaVariante.Variante, item.Struttura);

                    if (rigaVenditaVariante.Variante.TipologiaTre == EnumTipologiaTre.CardMyFE && !rigaVenditaVariante.Variante.MyFeComune())
                    {

                    }
                    else
                    {
                        dato.Pax += rigaVenditaVariante.Quantita;
                        _Dati.TotalePax += rigaVenditaVariante.Quantita;
                    }

                    //dato.Pax += rigaVenditaVariante.Quantita;
                    //_Dati.TotalePax += rigaVenditaVariante.Quantita;

                    if (item.Incasso == EnumIncasso.Contanti)
                    {
                        dato.TotaleContanti += rigaVenditaVariante.PrezzoTotale;
                        _Dati.TotaleContanti += rigaVenditaVariante.PrezzoTotale;
                    }
                    else
                    {
                        dato.TotalePos += rigaVenditaVariante.PrezzoTotale;
                        _Dati.TotalePos += rigaVenditaVariante.PrezzoTotale;
                    }
                }
            }
        }

        private void SoloAltre(Vendita item, RigaVenditaVariante rigaVenditaVariante)
        {
            if (item.Struttura == _Struttura)
            {
                // non interessa
            }
            else
            {
                // non interessa
            }
        }

        private void SoloQuesta(Vendita item, RigaVenditaVariante rigaVenditaVariante)
        {
            if (item.Struttura == _Struttura)
            {
                // non interessa
            }
            else
            {
                VendutiPerTerzi dato = _Dati.PerAltriCerca(rigaVenditaVariante.Variante, item.Struttura);

                dato.Pax += rigaVenditaVariante.Quantita;
                _Dati.TotalePax += rigaVenditaVariante.Quantita;

                if (item.Incasso == EnumIncasso.Contanti)
                {
                    dato.TotaleContanti += rigaVenditaVariante.PrezzoTotale;
                    _Dati.TotaleContanti += rigaVenditaVariante.PrezzoTotale;
                }
                else
                {
                    dato.TotalePos += rigaVenditaVariante.PrezzoTotale;
                    _Dati.TotalePos += rigaVenditaVariante.PrezzoTotale;
                }

            }
        }

    }
}