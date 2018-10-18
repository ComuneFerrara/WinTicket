using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Musei.Module;
using DevExpress.Xpo;
using WinTicketNext.CostruzionePercorso;
using PreventWebServices;

namespace WinTicketNext.Storico
{
    public partial class XtraFormDettaglioVendita : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormDettaglioVendita()
        {
            InitializeComponent();
        }

        private Vendita m_Vendita;
        public void Init(Vendita vendita)
        {
            vendita.Reload();
            vendita.RigheVenditaVariante.Reload();
            vendita.Stampe.Reload();
            vendita.Fatture.Reload();

            m_Vendita = vendita;

            this.Text = String.Format("Dettaglio Vendita {0}", m_Vendita.CodiceLeggibile);
            this.labelControlRiga1.Text = String.Format("Vendita effettuata da: <b>{0}</b> il <b>{1}</b> dalla postazione <b>{2}</b>", m_Vendita.Utente.FullName, m_Vendita.DataOraStampa, m_Vendita.Postazione.Nome);

            this.gridControl1.DataSource = m_Vendita.Stampe;
            this.gridControl2.DataSource = m_Vendita.RigheVenditaVariante;

            this.gridControl3.DataSource = m_Vendita.Fatture;

            this.gridView1.BestFitColumns();
            this.gridView3.BestFitColumns();
            this.gridView4.BestFitColumns();

            this.gridViewFatture.BestFitColumns();

            if (string.IsNullOrEmpty(m_Vendita.CodicePrevent))
            {
                this.labelControlRiga2.Text = String.Format("Totale <b>{0}</b> <b>{1:c}</b> per <b>{2}</b> persone", m_Vendita.Incasso, m_Vendita.TotaleImporto, m_Vendita.TotalePersone);

                this.barButtonItemAnnulla.Caption = "Elimina VENDITA";
            }
            else
            {
                this.labelControlRiga2.Text = String.Format("Totale <b>{0}</b> <b>{1:c}</b> per <b>{2}</b> persone (prenotazione <b>{3}</b>)", m_Vendita.Incasso, m_Vendita.TotaleImporto, m_Vendita.TotalePersone, m_Vendita.CodicePrevent);

                this.barButtonItemAnnulla.Caption = "Ripristino PRENOTAZIONE ed eliminazione VENDITA";
            }

            this.barButtonItemPos.Enabled = m_Vendita.Incasso != EnumIncasso.Pos;
            this.barButtonItemContanti.Enabled = m_Vendita.Incasso != EnumIncasso.Contanti;
            this.barButtonItemOnline.Enabled = m_Vendita.Incasso != EnumIncasso.Internet;
            this.barButtonItemFElettronica.Enabled = m_Vendita.Incasso != EnumIncasso.FatturaElettronica;
        }

        private void barButtonItemStampa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportHelper.Print(m_Vendita);
        }

        private void barButtonItemAnnulla_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!m_Vendita.PossoEliminarla())
            {
                XtraMessageBox.Show("Non puoi eliminare questa vendita perchè è già stata inserita in un report contabile.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Program.UtenteCollegato.Amministratore)
            {
                if (m_Vendita.Postazione.Oid != Program.Postazione.Oid)
                {
                    XtraMessageBox.Show("Non puoi eliminare questa vendita perchè è stata effettuata da un'altra postazione e non sei amministratore.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (m_Vendita.EsistonoCardMyFE())
            {
                if (XtraMessageBox.Show("Attenzione, esistono delle Card MyFE associate a questa vendita. Vuoi proseguire ugualmente (IMPLICA IL RECUPERO DELLE CARD) ?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
            }

            if (m_Vendita.EsistonoEntrate())
            {
                if (XtraMessageBox.Show("Attenzione, esistono delle entrate associate a questa vendita. Vuoi proseguire ugualmente ?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
            }

            if (XtraMessageBox.Show(string.Format("Confermi l'eliminazione di TUTTA la vendita ({0:c} persone {1}) ?", m_Vendita.TotaleImporto, m_Vendita.TotalePersone), "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(m_Vendita.CodicePrevent))
                {
                    using (Session delSession = new Session())
                    {
                        Vendita toDelete = delSession.GetObjectByKey<Vendita>(m_Vendita.Oid);
                        if (toDelete != null)
                        {
                            Messaggio msg = new Messaggio(delSession);
                            msg.Autore = delSession.GetObjectByKey<Utente>(Program.UtenteCollegato.Oid);
                            msg.Data = DateTime.Now;
                            msg.Oggetto = "Eliminazione " + toDelete.CodiceLeggibile;
                            msg.TestoEsteso = String.Format("L'utente {0} ha eliminato la vendita {1} di importo totale {2:c} dalla postazione {3}.", Program.UtenteCollegato.FullName, toDelete.CodiceLeggibile, toDelete.TotaleImporto, Program.Postazione.Nome);
                            msg.TestoEsteso += Descrizione(toDelete);
                            msg.Tipologia = EnumTipoMessaggio.Eliminazione;
                            msg.Save();

                            toDelete.EliminaVendita();
                        }
                    }

                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    if (XtraMessageBox.Show(string.Format("La prenotazione {0} verrà ripristinata al suo stato originario. Vuoi proseguire ?", m_Vendita.CodicePrevent), "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // RIPRISTINO PRENOTAZIONE
                        prevent.verifica.Out obj = RichiestaDelete.MakeDelete(m_Vendita.CodiceLeggibile);
                        if (obj != null && (obj.ReturnCode == "00" || obj.ReturnCode == "51" || obj.ReturnCode == "52"))
                        {
                            using (Session delSession = new Session())
                            {
                                Vendita toDelete = delSession.GetObjectByKey<Vendita>(m_Vendita.Oid);
                                if (toDelete != null)
                                {
                                    Messaggio msg = new Messaggio(delSession);
                                    msg.Autore = delSession.GetObjectByKey<Utente>(Program.UtenteCollegato.Oid);
                                    msg.Data = DateTime.Now;
                                    msg.Oggetto = String.Format("Eliminazione {0} con prenotazione {1}", toDelete.CodiceLeggibile, toDelete.CodicePrevent);
                                    msg.TestoEsteso = String.Format("L'utente {0} ha eliminato la vendita {1} di importo totale {2:c} dalla postazione {3} associata alla prenotazione {4}.", Program.UtenteCollegato.FullName, toDelete.CodiceLeggibile, toDelete.TotaleImporto, Program.Postazione.Nome, toDelete.CodicePrevent);
                                    msg.TestoEsteso += Descrizione(toDelete);
                                    msg.Tipologia = EnumTipoMessaggio.EliminazioneConPrenotazione;
                                    msg.Save();

                                    toDelete.EliminaVendita();
                                }
                            }

                            DialogResult = System.Windows.Forms.DialogResult.OK;
                        }
                        else
                        {
                            XtraMessageBox.Show(
                                String.Format("Errore: {0}", RichiestaDelete.UltimoErrore.DescrizioneErrore,
                                String.Format("Errore Web: {0}", RichiestaDelete.UltimoErrore.ReturnCode), MessageBoxButtons.OK, MessageBoxIcon.Error));
                        }
                    }
                }
            }
        }

        public static string Descrizione(Vendita toDelete)
        {
            string result = String.Format("{0}{0}Righe-Vendita-Variante:{0}", Environment.NewLine);

            foreach (var item in toDelete.RigheVenditaVariante)
            {
                result += string.Format("pax {0} importo unitario {1:c} => {2} [{3}] | Card: {4} | Bonus: {5}",
                    item.Quantita,
                    item.PrezzoUnitario,
                    item.Variante.Descrizione,
                    item.Titolo != null ? item.Titolo.Descrizione : "",
                    item.Card != null ? item.Card.Codice : "",
                    item.CodiceSconto != null ? item.CodiceSconto.Codice : ""
                    ) + Environment.NewLine;
            }

            result += String.Format("{0}Stampe:{0}", Environment.NewLine);
            foreach (var item in toDelete.Stampe)
            {
                result += string.Format("barcode {0} valido per {1} pax dal {2:d} al {3:d}, importo {4:c}",
                    item.BarCode,
                    item.Quantita,
                    item.InizioValidita,
                    item.FineValidita,
                    item.ImportoTotale) + Environment.NewLine;
            }

            return result;
        }

        private void barButtonItemPos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!m_Vendita.PossoEliminarla())
            {
                XtraMessageBox.Show("Non puoi modificare questa vendita perchè è già stata inserita in un report contabile.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (XtraMessageBox.Show("Vuoi cambiare modalità di pagamento in: POS ?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            using (Session delSession = new Session())
            {
                Vendita toModify = delSession.GetObjectByKey<Vendita>(m_Vendita.Oid);
                if (toModify != null && toModify.Incasso != EnumIncasso.Pos)
                {
                    toModify.Incasso = EnumIncasso.Pos;
                    toModify.Save();
                }
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void barButtonItemContanti_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!m_Vendita.PossoEliminarla())
            {
                XtraMessageBox.Show("Non puoi modificare questa vendita perchè è già stata inserita in un report contabile.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (XtraMessageBox.Show("Vuoi cambiare modalità di pagamento da POS a CONTANTI ?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            using (Session delSession = new Session())
            {
                Vendita toModify = delSession.GetObjectByKey<Vendita>(m_Vendita.Oid);
                if (toModify != null && toModify.Incasso != EnumIncasso.Contanti)
                {
                    toModify.Incasso = EnumIncasso.Contanti;
                    toModify.Save();
                }
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void barButtonItemCreaFattura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.xtraTabControlVendita.SelectedTabPage == xtraTabPageFatture)
            {
                XtraFormCreaFattura dettaglio = new XtraFormCreaFattura();
                dettaglio.Init(m_Vendita, null);

                if (dettaglio.ShowDialog(this) == DialogResult.OK)
                {
                    Init(m_Vendita);
                }
            }
            else
                this.xtraTabControlVendita.SelectedTabPage = xtraTabPageFatture;
        }

        private void gridViewFatture_DoubleClick(object sender, EventArgs e)
        {
            Fattura fattura = this.gridViewFatture.GetFocusedRow() as Fattura;
            if (fattura != null)
            {
                XtraFormCreaFattura dettaglio = new XtraFormCreaFattura();
                dettaglio.Init(fattura.Vendita, fattura);

                if (dettaglio.ShowDialog(this) == DialogResult.OK)
                {
                    Init(m_Vendita);
                }
            }
        }

        private void barButtonItemOnline_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraMessageBox.Show("Non puoi impostare questa modalità, è gestita in automatico per le vendite online.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void barButtonItemFElettronica_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!m_Vendita.PossoEliminarla())
            {
                XtraMessageBox.Show("Non puoi modificare questa vendita perchè è già stata inserita in un report contabile.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (XtraMessageBox.Show("Vuoi cambiare modalità di pagamento in: FATTURA ELETTRONICA ?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            using (Session delSession = new Session())
            {
                Vendita toModify = delSession.GetObjectByKey<Vendita>(m_Vendita.Oid);
                if (toModify != null && toModify.Incasso != EnumIncasso.FatturaElettronica)
                {
                    toModify.Incasso = EnumIncasso.FatturaElettronica;
                    toModify.Save();
                }
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}