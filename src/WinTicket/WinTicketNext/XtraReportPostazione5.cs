using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.Xpo;
using Musei.Module;
using WinTicketNext.Storico;
using System.Collections.Generic;

namespace WinTicketNext
{
    public partial class XtraReportPostazione5 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportPostazione5()
        {
            InitializeComponent();
        }

        public void ImpostaData(DateTime inizio, DateTime fine)
        {
            if (inizio != fine)
                this.xrLabelTitolo.Text = string.Format("Riepilogo {0:d} - {1:d}", inizio, fine);
            else
                this.xrLabelTitolo.Text = string.Format("Riepilogo {0:d}", inizio);
        }

        public void AddData(XPCollection<RigaVenditaVariante> elenco, List<Postazione> postazioni)
        {
            ClassNumerazione numerazione = new ClassNumerazione();

            List<TotaliPostazione> listaReport = new List<TotaliPostazione>();
            foreach (RigaVenditaVariante rigaVenditaVariante in elenco)
            {
                bool found = false;
                foreach (TotaliPostazione totaliPostazione in listaReport)
                {
                    if (totaliPostazione.Biglietto == rigaVenditaVariante.Variante.Biglietto.Descrizione && totaliPostazione.Variante == rigaVenditaVariante.Variante.Descrizione)
                    {
                        found = true;

                        totaliPostazione.Qta += rigaVenditaVariante.Quantita;
                        totaliPostazione.Tot += rigaVenditaVariante.PrezzoTotale;
                        totaliPostazione.Contanti += rigaVenditaVariante.IncassoContanti;
                        totaliPostazione.Pos += rigaVenditaVariante.IncassoPos;
                        totaliPostazione.Online += rigaVenditaVariante.IncassoOnline;
                        totaliPostazione.FatturaElettronica += rigaVenditaVariante.IncassoFatturaElettronica;

                        break;
                    }
                }

                if (!found)
                {
                    TotaliPostazione nriga = new TotaliPostazione();

                    nriga.Biglietto = rigaVenditaVariante.Variante.Biglietto.Descrizione;
                    nriga.Variante = rigaVenditaVariante.Variante.Descrizione;
                    nriga.Qta = rigaVenditaVariante.Quantita;
                    nriga.Tot = rigaVenditaVariante.PrezzoTotale;
                    nriga.Contanti = rigaVenditaVariante.IncassoContanti;
                    nriga.Pos = rigaVenditaVariante.IncassoPos;
                    nriga.Online += rigaVenditaVariante.IncassoOnline;
                    nriga.FatturaElettronica += rigaVenditaVariante.IncassoFatturaElettronica;

                    listaReport.Add(nriga);
                }

                foreach (Stampa stampa in rigaVenditaVariante.Vendita.Stampe)
                {
                    numerazione.Add(stampa.Vendita.Postazione, stampa.NumeroProgressivo, stampa.Vendita.DataContabile.Year);
                }
            }

            foreach (TotaliPostazione totaliPostazione in listaReport)
            {
                this.bindingSource1.Add(totaliPostazione);
            }

            Postazioni(postazioni, numerazione);
        }

        private void Postazioni(List<Postazione> list, ClassNumerazione numerazione)
        {
            string posta = string.Empty;
            DateTime lastUpdate = DateTime.MaxValue;

            foreach (Postazione postazione in list)
            {
                posta += 
                    string.Format("{0}: {1} biglietti: {2}", postazione.Nome, numerazione.NB(postazione), numerazione.EB(postazione)) +
                    Environment.NewLine;

                if (postazione.Oid != Program.Postazione.Oid)
                {
                    if (postazione.LastUpdate < lastUpdate)
                        lastUpdate = postazione.LastUpdate;
                }
                else
                {
                    // Questa postazione e', per definizione, sempre aggiornata
                    if (DateTime.Now < lastUpdate)
                        lastUpdate = DateTime.Now;
                }
            }

            this.xrLabelPostazioni.Text = String.Format("Elenco postazioni:\n{0}", posta);
            this.xrLabelAggiornamento.Text = string.Format("Dati aggiornati a {0:g}", lastUpdate);
        }
    }
}
