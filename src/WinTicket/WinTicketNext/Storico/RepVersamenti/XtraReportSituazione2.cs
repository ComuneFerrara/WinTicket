using System;
using DevExpress.XtraReports.UI;
using Musei.Module;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.Drawing;

namespace WinTicketNext.Storico.RepVersamenti
{
    public partial class XtraReportSituazione2 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportSituazione2()
        {
            InitializeComponent();
        }

        private Struttura _Struttura;
        private DateTime _Inizio;
        private DateTime _Fine;

        public void Init(Struttura struttura, DateTime inizio, DateTime fine)
        {
            Session session = new Session();

            _Struttura = session.GetObjectByKey<Struttura>(struttura.Oid);
            _Inizio = inizio;
            _Fine = fine;

            this.xrLabelErr.Visible = false;

            CreaTabellaVersamenti(session);
            CreaTabellaIncassi(session);

            this.xrLabelHeader.Text = string.Format("{0} - dati biglietteria mese di {1:MMMM}", _Struttura.Descrizione, _Inizio).ToUpper();
            this.xrLabelResponsabile.Text = _Struttura.Responsabile;
            this.xrLabelMuseo.Text = _Struttura.Intestazione;
            this.xrLabelTitolo.Text = _Struttura.Titolo;
        }

        private void CreaTabellaIncassi(Session session)
        {
            ClassNumerazione numerazione = new ClassNumerazione();

            XPCollection<Vendita> vendite = new XPCollection<Vendita>(session);
            vendite.Criteria = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                new BinaryOperator("Struttura.Oid", _Struttura.Oid),
                new BinaryOperator("DataContabile", _Inizio, BinaryOperatorType.GreaterOrEqual),
                new BinaryOperator("DataContabile", _Fine, BinaryOperatorType.LessOrEqual)});

            decimal posquesta = 0;
            decimal posaltre = 0;

            decimal conquesta = 0;
            decimal conaltre = 0;

            var incassi = new Dictionary<string, decimal>();

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

                                if (!incassi.ContainsKey(rigaVenditaVariante.Variante.Biglietto.Gestore.RagioneSociale)) incassi[rigaVenditaVariante.Variante.Biglietto.Gestore.RagioneSociale] = 0;
                                incassi[rigaVenditaVariante.Variante.Biglietto.Gestore.RagioneSociale] += rigaVenditaVariante.PrezzoTotale;
                            }
                        }
                        break;

                    case EnumIncasso.Contanti:
                        foreach (RigaVenditaVariante rigaVenditaVariante in vendita.RigheVenditaVariante)
                        {
                            if (rigaVenditaVariante.Variante.Biglietto.Gestore == _Struttura.SoggettoEconomico)
                                conquesta += rigaVenditaVariante.PrezzoTotale;
                            else
                            {
                                conaltre += rigaVenditaVariante.PrezzoTotale;

                                if (!incassi.ContainsKey(rigaVenditaVariante.Variante.Biglietto.Gestore.RagioneSociale)) incassi[rigaVenditaVariante.Variante.Biglietto.Gestore.RagioneSociale] = 0;
                                incassi[rigaVenditaVariante.Variante.Biglietto.Gestore.RagioneSociale] += rigaVenditaVariante.PrezzoTotale;
                            }
                        }
                        break;

                    default:
                        throw new Exception(String.Format("Cason non previsto: {0}", vendita.Incasso));
                }

                foreach (Stampa stampa in vendita.Stampe)
                {
                    numerazione.Add(stampa.Vendita.Postazione, stampa.NumeroProgressivo, stampa.Vendita.DataContabile.Year);
                }
            }

            XRTableRow lastrow = this.xrTableIncassi.Rows[this.xrTableIncassi.Rows.Count - 1];

            lastrow.Cells[0].Text = string.Format("{0:MMMM}", _Inizio).ToUpper();
                    lastrow.Cells[0].TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    lastrow.Cells[0].Font = xrLabelTitoloTabVersamenti.Font;
                    lastrow.Cells[0].Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5);

            lastrow.Cells[1].Text = (conquesta + posquesta).ToString("c");
                    lastrow.Cells[1].TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    lastrow.Cells[1].Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5);

            lastrow.Cells[2].Text = (posquesta + posaltre).ToString("c");
                    lastrow.Cells[2].TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    lastrow.Cells[2].Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5);

            lastrow.Cells[3].Text = (conquesta - posaltre).ToString("c");
                    lastrow.Cells[3].TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    lastrow.Cells[3].Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5);

            lastrow = this.xrTableAltriEnti.Rows[0];

            foreach (var item in incassi)
            {
                lastrow = this.xrTableAltriEnti.InsertRowBelow(lastrow);

                lastrow.Cells[0].Text = item.Key;
                lastrow.Cells[0].TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                lastrow.Cells[0].Font = xrLabelTitoloTabVersamenti.Font;
                lastrow.Cells[0].Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5);

                lastrow.Cells[1].Text = item.Value.ToString("c");
                lastrow.Cells[1].TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                lastrow.Cells[1].Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5);               
            }

            lastrow = this.xrTableAltriEnti.InsertRowBelow(lastrow);

            lastrow.Cells[0].Text = "TOTALI";
            lastrow.Cells[0].TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            lastrow.Cells[0].Font = xrLabelTitoloTabVersamenti.Font;
            lastrow.Cells[0].Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5);

            lastrow.Cells[1].Text = (conaltre + posaltre).ToString("c");
            lastrow.Cells[1].TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            lastrow.Cells[1].Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5);

            lastrow = this.xrTableTotale.Rows[0];

            lastrow.Cells[0].Text = "TOTALE INCASSI";
            lastrow.Cells[0].TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            lastrow.Cells[0].Font = xrLabelTitoloTabVersamenti.Font;
            lastrow.Cells[0].Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5);

            lastrow.Cells[1].Text = (conquesta + conaltre + posquesta + posaltre).ToString("c");
            lastrow.Cells[1].TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            lastrow.Cells[1].Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5);

            foreach (var item in numerazione.Elenco)
            {
                this.xrLabelBiglietti.Text +=
                    string.Format("{0}: {1} biglietti: {2}", item.Key.Nome, numerazione.NB(item.Key), numerazione.EB(item.Key)) + Environment.NewLine;
            }

            if (totalone != (conquesta + conaltre + posquesta + posaltre)) this.xrLabelErr.Visible = true;
        }

        private decimal totalone = 0;
        private void CreaTabellaVersamenti(Session session)
        {
            XPCollection<Versamento> versamenti = new XPCollection<Versamento>(session);
            versamenti.Sorting = new SortingCollection(new SortProperty[] { new SortProperty("DataVersamento", DevExpress.Xpo.DB.SortingDirection.Ascending) });
            GroupOperator tipo =
                new GroupOperator(GroupOperatorType.Or, new CriteriaOperator[]{
                        new BinaryOperator("Tipologia", EnumTipologiaVersamento.Incasso_Pos),
                        new BinaryOperator("Tipologia", EnumTipologiaVersamento.Incasso_Contanti),
                        new BinaryOperator("Tipologia", EnumTipologiaVersamento.Incasso_Contanti_AltriEnti),
                        new BinaryOperator("Tipologia", EnumTipologiaVersamento.FondoCassa_Trattenuta),
                        new BinaryOperator("Tipologia", EnumTipologiaVersamento.FondoCassa_Versamento)
                    });
            versamenti.Criteria = 
                new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                        new BinaryOperator("Struttura.Oid", _Struttura.Oid),
                        new BinaryOperator("InizioPeriodo", _Inizio, BinaryOperatorType.GreaterOrEqual),
                        new BinaryOperator("FinePeriodo", _Fine, BinaryOperatorType.LessOrEqual),
                        tipo
                    });

            decimal fondocassaTrattenuta = 0;
            decimal fondocassaVersata = 0; 
            decimal[] totali = new decimal[4];
            bool primariga = true;
            foreach (Versamento versamento in versamenti)
            {
                if (versamento.Tipologia == EnumTipologiaVersamento.FondoCassa_Trattenuta)
                {
                    fondocassaTrattenuta += versamento.ImportoVersato;
                }
                else
                {
                    if (versamento.Tipologia == EnumTipologiaVersamento.FondoCassa_Versamento)
                        fondocassaVersata += versamento.ImportoVersato;

                    XRTableRow row = this.xrTableVersamenti.Rows[this.xrTableVersamenti.Rows.Count - 1];
                    if (!primariga)
                        this.xrTableVersamenti.InsertRowBelow(row);

                    row = this.xrTableVersamenti.Rows[this.xrTableVersamenti.Rows.Count - 1];

                    row.Cells[0].Text = versamento.DataVersamento.ToString("d");
                    row.Cells[0].TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    row.Cells[0].Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5);

                    totali[1] += versamento.Incassi;
                    row.Cells[1].Text = versamento.Incassi == 0 ? string.Empty : versamento.Incassi.ToString("c");
                    row.Cells[1].TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    row.Cells[1].Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5);

                    totali[2] += versamento.Pos;
                    row.Cells[2].Text = versamento.Pos == 0 ? string.Empty : versamento.Pos.ToString("c");
                    row.Cells[2].TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    row.Cells[2].Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5);

                    totali[3] += versamento.ImportoVersato;
                    row.Cells[3].Text = versamento.ImportoVersato == 0 ? string.Empty : versamento.ImportoVersato.ToString("c");
                    row.Cells[3].TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    row.Cells[3].Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5);

                    //if (versamento.Tipologia == EnumTipologiaVersamento.Incassso_Contanti_AltriEnti)
                    //{
                    //    row.Cells[1].ForeColor = Color.Red;
                    //    row.Cells[2].ForeColor = Color.Red;
                    //    row.Cells[3].ForeColor = Color.Red;
                    //    row.Cells[2].Text = "PROV.FE";
                    //}

                    primariga = false;
                }
            }
            // totali

            XRTableRow lastrow = this.xrTableVersamenti.Rows[this.xrTableVersamenti.Rows.Count - 1];
            this.xrTableVersamenti.InsertRowBelow(lastrow);
            lastrow = this.xrTableVersamenti.Rows[this.xrTableVersamenti.Rows.Count - 1];

            lastrow.Cells[0].Text = "TOTALI";
                    lastrow.Cells[0].TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    lastrow.Cells[0].Font = xrLabelTitoloTabVersamenti.Font;
                    lastrow.Cells[0].Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5);

            lastrow.Cells[1].Text = totali[1].ToString("c");
                    lastrow.Cells[1].TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    lastrow.Cells[1].Font = xrLabelTitoloTabVersamenti.Font;
                    lastrow.Cells[1].Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5);

            lastrow.Cells[2].Text = totali[2].ToString("c");
                    lastrow.Cells[2].TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    lastrow.Cells[2].Font = xrLabelTitoloTabVersamenti.Font;
                    lastrow.Cells[2].Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5);

            lastrow.Cells[3].Text = totali[3].ToString("c");
                    lastrow.Cells[3].TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    lastrow.Cells[3].Font = xrLabelTitoloTabVersamenti.Font;
                    lastrow.Cells[3].Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5);

            totalone = totali[2] + totali[3] + fondocassaTrattenuta - fondocassaVersata;

            if (totali[1] != totalone) this.xrLabelErr.Visible = true;

            if (fondocassaTrattenuta > 0)
            {
                this.xrLabelNote.Text += string.Format("Trattenuti {0:c} per fondo cassa", fondocassaTrattenuta) + Environment.NewLine;
            }
            if (fondocassaVersata > 0)
            {
                this.xrLabelNote.Text += string.Format("Versato Fondo Cassa di {0:c}", fondocassaVersata) + Environment.NewLine;
            }
        }

        internal void Init(XtraFormReportSituazione form)
        {
            this.xrLabelFerrara.Text = form.s1;
            this.xrLabelNote.Text += form.s2;
        }
    }
}
