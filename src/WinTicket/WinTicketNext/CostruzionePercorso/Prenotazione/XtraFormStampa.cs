using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Musei.Module;
using DevExpress.Xpo;
using PreventWebServices;
using DevExpress.Data.Filtering;
using System.Drawing;

namespace WinTicketNext.CostruzionePercorso.GestionePrenotazione
{
    public partial class XtraFormStampa : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormStampa()
        {
            InitializeComponent();
        }

        private PrenotazioneComplessiva m_Prenotazione;
        private List<Ingresso> m_Elenco;
        private bool m_ImponiData;
        private bool m_Prevendita;
        private DateTime m_DataImposta;
        public void Init(PrenotazioneComplessiva prenotazione, List<Ingresso> elenco, bool imponiData, DateTime dataImposta, bool prevendita)
        {
            m_Prenotazione = prenotazione;
            m_Elenco = elenco;
            m_ImponiData = imponiData;
            m_DataImposta = dataImposta;
            m_Prevendita = prevendita;

            m_Prenotazione.StampaSingolaPersona = m_Prenotazione.SoloProfiliSingoli() || m_Prenotazione.CardMusei() || m_Prenotazione.CardMyFE();

            this.labelControlInfo1.Text = String.Format("Totale Biglietti: {0}", 
                m_Prenotazione.StampaSingolaPersona ? 
                m_Prenotazione.GestoreProfili.TotalePersone() : 1);

            this.labelControlInfo2.Text = String.Format("Totale Persone: {0}", m_Prenotazione.GestoreProfili.TotalePersone());
            if (m_Prenotazione.GestoreProfili.TotalePersoneScuole() > 0)
                this.labelControlInfo2.Text += String.Format(" ({0} scuole)", m_Prenotazione.GestoreProfili.TotalePersoneScuole());

            this.labelControlInfo3.Text = String.Format("Importo Totale: {0:c}", m_Prenotazione.GestoreProfili.TotaleImporto());

            // IMPOSTO CONTANTI
            if (m_Prenotazione.GestoreProfili.TotaleImporto() == 0)
                this.checkEditContanti.Checked = true;
            else if (Program.Postazione.Opzione(Postazione.SoloContanti))
                this.checkEditContanti.Checked = true;

            if (m_Prenotazione.ConPrenotazione())
            {
                this.labelControlRiferimento.Text = "Riferimento:";
                this.textEditRiferimento.Text = m_Prenotazione.RiferimentoVendita;

                if (m_Prenotazione.PreventObj != null)
                    this.labelControlPrevent.Text = String.Format("Modifica prenotazione: {0}", m_Prenotazione.PreventObj.NumeroPrenotazione);
                //else if (m_Prenotazione.TaskGroup != null)
                //    this.labelControlPrevent.Text = String.Format("Prenotazione: {0}", m_Prenotazione.TaskGroup.Codice);
                else
                    this.labelControlPrevent.Text = "Nuova prenotazione";
            }
            else
            {
                this.labelControlRiferimento.Text = "Senza prenotazione.";
                this.textEditRiferimento.Visible = false;
                this.labelControlPrevent.Visible = false;
            }

            // calcola e visualizza data di validità dei biglietti
            if (!m_ImponiData)
            {
                m_DataImposta = DateTime.Now;
            }

            DateTime inizioVal = m_DataImposta.Date;
            DateTime fineVal = m_DataImposta.Date;

            if (m_Prenotazione.GestoreProfili.Bigliettone() || m_Prenotazione.GestoreProfili.Cumulativo())
            {
                fineVal = inizioVal.AddDays(15);
            }

            if (m_Prenotazione.GestoreProfili.CardMusei())
            {
                fineVal = new DateTime(inizioVal.Year, 12, 31);
            }

            if (m_Prenotazione.ConPrenotazione())
            {
                inizioVal = m_Prenotazione.InizioPrenotazioni(inizioVal);
                fineVal = m_Prenotazione.FinePrenotazioni(fineVal);
            }

            this.labelControlValidita.Text = string.Format("Validità: dal {0:d} al {1:d}", inizioVal, fineVal);

            //MessageBox.Show(String.Format("{0} / {1}", GestoreCalendario.TipoGS, GestoreCalendario.TipoScuola));
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            if (Program.Postazione.Tipologia == EnumTipologiaPostazione.NonAttiva)
            {
                XtraMessageBox.Show("Questa postazione non e' abilitata per emettere biglietti.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.checkEditContanti.Checked || this.checkEditPos.Checked)
            {
                if (m_Prenotazione.ConPrenotazione())
                {
                    if (this.dxValidationProvider1.Validate())
                        m_Prenotazione.RiferimentoVendita = this.textEditRiferimento.Text;
                    else
                        return;
                }

                if (CreaVendita())
                {
                    ReportHelper.Print(m_Prenotazione.Vendita);

                    //XtraReportStampa1 stampa = new XtraReportStampa1();
                    //stampa.xpCollection1.Criteria = new BinaryOperator("Vendita.Oid", m_Prenotazione.Vendita.Oid);

                    //stampa.ShowPrintMarginsWarning = false;

                    //if (string.IsNullOrEmpty(Program.Postazione.PrinterName))
                    //    stampa.ShowPreviewDialog();
                    //else
                    //    stampa.Print(Program.Postazione.PrinterName);

                    DialogResult = DialogResult.OK;
                }
                else
                    DialogResult = DialogResult.Cancel;
            }
            else
                XtraMessageBox.Show("Specificare il tipo di incasso (Contanti/POS)", "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void CreaStampa(UnitOfWork uow, 
            DateTime inizioVal, DateTime fineVal, 
            Vendita vendita, int qta, decimal totale, List<Ingresso> ingressi, int profilo, Card cardMyFE = null)
        {
            Stampa stampa = new Stampa(uow);
            stampa.Vendita = vendita;
            stampa.InizioValidita = inizioVal;
            stampa.FineValidita = fineVal;
            stampa.Quantita = qta;
            stampa.ImportoTotale = totale;
            stampa.Save();
            stampa.GeneraBarCode(Program.Postazione, ingressi);
            stampa.StatoStampa = profilo;
            stampa.TipoStampa = EnumTipoStampa.Standard;
            if (cardMyFE != null)
            {
                stampa.FineValidita = stampa.InizioValidita.AddDays(cardMyFE.Giorni() - 1);
                stampa.TipoStampa = EnumTipoStampa.Card;
                stampa.Card = cardMyFE;

                cardMyFE.Stampa = stampa;
                cardMyFE.Status = EnumStatoCard.Emessa;
                cardMyFE.Save();
            }

            Stampa doppia = uow.FindObject<Stampa>(new BinaryOperator("BarCode", stampa.BarCode));
            if (doppia != null)
            {
                stampa.GeneraBarCode(Program.Postazione, ingressi);

                doppia = uow.FindObject<Stampa>(new BinaryOperator("BarCode", stampa.BarCode));
                if (doppia != null)
                {
                    stampa.GeneraBarCode(Program.Postazione, ingressi);

                    doppia = uow.FindObject<Stampa>(new BinaryOperator("BarCode", stampa.BarCode));
                    if (doppia != null)
                    {
                        stampa.GeneraBarCode(Program.Postazione, ingressi);
                    }
                }
            }

            stampa.Save();

            //Dictionary<Guid, RigaStampaIngresso> elencoingressi = new Dictionary<Guid, RigaStampaIngresso>();
            foreach (Ingresso ingresso in ingressi)
            {
                RigaStampaIngresso rigaingresso = new RigaStampaIngresso(uow);
                rigaingresso.Ingresso = uow.GetObjectByKey<Ingresso>(ingresso.Oid);
                rigaingresso.Stampa = stampa;
                rigaingresso.TotalePersone = qta;
                rigaingresso.Save();

                //elencoingressi.Add(ingresso.Oid, rigaingresso);
            }
        }

        private static bool VarcoPostazione(RigaStampaIngresso item2)
        {
            foreach (PostazioneIngresso postazioneIngresso in Program.Postazione.Ingressi)
            {
                if (postazioneIngresso.Tipologia == EnumTipologiaPostazioneIngresso.MarcaturaAutomatica && postazioneIngresso.Ingresso.Oid == item2.Ingresso.Oid)
                    return true;
            }

            return false;
        }

        private static void CreaVenditaElencoRigheUniche(List<prevent.prenotazione.ParametriRigaBiglietti> elencorigheuniche, RigaVenditaVariante riga)
        {
            if (!string.IsNullOrEmpty(riga.Variante.CodicePrevent))
            {
                prevent.prenotazione.ParametriRigaBiglietti parariga = new prevent.prenotazione.ParametriRigaBiglietti();
                parariga.Quantita = riga.Quantita.ToString();
                parariga.IdTipoBiglietto = riga.Variante.CodicePrevent;

                bool found = false;
                foreach (prevent.prenotazione.ParametriRigaBiglietti item in elencorigheuniche)
                {
                    if (item.IdTipoBiglietto == parariga.IdTipoBiglietto)
                    {
                        // devo fare cosi' perche' il campo Quantita e' una stringa
                        string newqta = (int.Parse(item.Quantita) + int.Parse(parariga.Quantita)).ToString();

                        item.Quantita = newqta;

                        found = true;
                    }
                }

                if (!found)
                    elencorigheuniche.Add(parariga);
            }
        }

        private bool CreaVendita()
        {
            bool result = false;
            using (UnitOfWork uow = new UnitOfWork())
            {
                if (!m_ImponiData)
                {
                    m_DataImposta = DateTime.Now;
                }

                bool conPrenotazione = false;
                DateTime inizioVal = m_DataImposta.Date;
                DateTime fineVal = m_DataImposta.Date;

                if (m_Prenotazione.GestoreProfili.Bigliettone() || m_Prenotazione.GestoreProfili.Cumulativo())
                {
                    fineVal = inizioVal.AddDays(15);
                }

                if (m_Prenotazione.GestoreProfili.CardMusei())
                {
                    fineVal = new DateTime(inizioVal.Year, 12, 31);
                }

                if (m_Prenotazione.GestoreProfili.NumeroCardMyFE() > 0)
                {
                    fineVal = inizioVal.AddDays(Card.GiorniCard(m_Prenotazione.GestoreProfili.TipologiaMyFe) - 1);
                }

                if (m_Prenotazione.ConPrenotazione())
                {
                    conPrenotazione = true;
                    inizioVal = m_Prenotazione.InizioPrenotazioni(inizioVal);
                    fineVal = m_Prenotazione.FinePrenotazioni(fineVal);
                }

                Vendita vendita = new Vendita(uow);

                vendita.Incasso = this.checkEditPos.Checked ? EnumIncasso.Pos : EnumIncasso.Contanti;
                vendita.CodiceLeggibile = m_Prenotazione.CodiceVendita;
                vendita.CodicePrevent = m_Prenotazione.PrenotazionePrevent;

                vendita.Descrizione = m_Prenotazione.RiferimentoVendita;

                if (m_Prevendita)
                {
                    vendita.Descrizione = "PREVENDITA";
                    vendita.DataContabile = DateTime.Today;
                    vendita.DataOraStampa = DateTime.Now;
                }
                else
                {
                    vendita.DataContabile = m_DataImposta.Date;
                    vendita.DataOraStampa = m_DataImposta;
                }

                vendita.Provenienza = _provenienza != null ? uow.GetObjectByKey<Provenienza>(_provenienza.Oid) : null;

                vendita.Utente = uow.GetObjectByKey<Utente>(Program.UtenteCollegato.Oid);
                vendita.Postazione = uow.GetObjectByKey<Postazione>(Program.Postazione.Oid);
                vendita.Struttura = uow.GetObjectByKey<Struttura>(Program.Postazione.Struttura.Oid);
                vendita.TotalePersone = m_Prenotazione.GestoreProfili.TotalePersone();
                vendita.TotaleImporto = m_Prenotazione.GestoreProfili.TotaleImporto();
                vendita.Save();

                #region PRENOTAZIONE
                prevent.prenotazione.Parametri parametri = new prevent.prenotazione.Parametri();
                //List<prevent.prenotazione.ParametriRigaBiglietti> elencorighe = new List<prevent.prenotazione.ParametriRigaBiglietti>();
                List<prevent.prenotazione.ParametriRigaBiglietti> elencorigheuniche = new List<prevent.prenotazione.ParametriRigaBiglietti>();

                if (conPrenotazione)
                {
                    parametri.CodiceTransWinTicket = vendita.CodiceLeggibile;
                    parametri.Denominazione = vendita.Descrizione;
                    parametri.PaxTotali = m_Prenotazione.GestoreProfili.TotalePersone().ToString();
                    parametri.TipoGS = GestoreCalendario.TipoGS;
                    parametri.Scuola = GestoreCalendario.TipoScuola;
                    parametri.RigaPercorsoVisita = new prevent.prenotazione.ParametriRigaPercorsoVisita[m_Prenotazione.NumeroTotalePrenotazioni()];

                    // creazione prenotazione
                    int count = 0;
                    foreach (PrenotazioneIngresso prenotazioneIngresso in m_Prenotazione.Prenotazioni)
                    {
                        foreach (SingolaPrenotazione singolaPrenotazione in prenotazioneIngresso.Prenotazioni)
                        {
                            Prenotazione nuovaPrenotazione = new Prenotazione(uow);

                            nuovaPrenotazione.Vendita = vendita;
                            //nuovaPrenotazione.RigaStampaIngresso = elencoingressi[prenotazioneIngresso.Ingresso.Oid];

                            //nuovaPrenotazione.AllDay = item.AllDay;
                            //nuovaPrenotazione.AppointmentType = item.AppointmentType;
                            //nuovaPrenotazione.Description = item.Description;
                            nuovaPrenotazione.Disponibilita = EnumDisponibilita.Disponibile; //item.Disponibilita;
                            nuovaPrenotazione.EndDate = singolaPrenotazione.OrarioFine;
                            //nuovaPrenotazione.IdRichiesta = item.IdRichiesta;
                            nuovaPrenotazione.Ingresso = uow.GetObjectByKey<Ingresso>(prenotazioneIngresso.Ingresso.Oid);
                            //nuovaPrenotazione.Label = item.Label;
                            //nuovaPrenotazione.Location = item.Location;
                            nuovaPrenotazione.NumeroPersone = singolaPrenotazione.NumeroPersone;
                            nuovaPrenotazione.StartDate = singolaPrenotazione.Orario;
                            //nuovaPrenotazione.Status = item.Status;
                            nuovaPrenotazione.Subject = singolaPrenotazione.Descrizione;
                            nuovaPrenotazione.Save();

                            parametri.RigaPercorsoVisita[count] = new prevent.prenotazione.ParametriRigaPercorsoVisita();
                            parametri.RigaPercorsoVisita[count].DataVisita = nuovaPrenotazione.StartDate.Date;
                            parametri.RigaPercorsoVisita[count].IdMostra = nuovaPrenotazione.Ingresso.CodicePrevent.ToString();
                            parametri.RigaPercorsoVisita[count].PaxVisita = nuovaPrenotazione.NumeroPersone.ToString();
                            parametri.RigaPercorsoVisita[count].OraVisita = String.Format("{0:HH}:{1:mm}:{2:ss}.{3:ffffzzz}", nuovaPrenotazione.StartDate, nuovaPrenotazione.StartDate, nuovaPrenotazione.StartDate, nuovaPrenotazione.StartDate);
                            count++;
                        }
                    }
                }
                #endregion

                // Numerazione dei profili
                int profiloCount = 0;
                foreach (ProfiloCliente profiloCliente in m_Prenotazione.GestoreProfili.ElencoProfili)
                {
                    profiloCliente.CodiceProgressivo = profiloCount++;
                }

                if (m_Prenotazione.StampaSingolaPersona)
                {
                    // ho già controllato che non ci siano gruppi oppure scuole
                    foreach (ProfiloCliente profiloCliente in m_Prenotazione.GestoreProfili.ElencoProfili)
                    {
                        var elencocard = profiloCliente.SoluzionePreferita.GetElencoCardMyFE(uow);

                        List<Ingresso> elenco = profiloCliente.ElencoIngressiSoluzionePreferita();
                        for (int i = 0; i < profiloCliente.NumeroPersone; i++)
                        {
                            CreaStampa(uow, inizioVal, fineVal, vendita, 1, 
                                profiloCliente.SoluzionePreferita.ImportoUnitario, elenco, profiloCliente.CodiceProgressivo, elencocard[i]);
                        }
                    }
                }
                else
                {
                    // DEVE esserci almeno un PROFILO gruppo OPPURE un profilo SCUOLA

                    ProfiloCliente profiloBase = m_Prenotazione.GestoreProfili.ElencoProfili[0];
                    List<Ingresso> elencoBase = profiloBase.ElencoIngressiSoluzionePreferita();

                    bool tuttiuguali = true;
                    foreach (ProfiloCliente profiloCliente in m_Prenotazione.GestoreProfili.ElencoProfili)
                    {
                        if (Diversi(elencoBase, profiloCliente.ElencoIngressiSoluzionePreferita()))
                        {
                            tuttiuguali = false;
                            break;
                        }
                        if (!profiloCliente.SoluzionePreferita.ContieneGruppoOppureScuola())
                        {
                            tuttiuguali = false;
                            break;
                        }
                    }

                    if (tuttiuguali)
                    {
                        // stampa UNICA per TUTTI i profili
                        if (m_Prenotazione.GestoreProfili.ElencoProfili.Count > 1)
                            CreaStampa(uow, inizioVal, fineVal, vendita, vendita.TotalePersone, vendita.TotaleImporto, elencoBase, -1);
                        else
                            CreaStampa(uow, inizioVal, fineVal, vendita, vendita.TotalePersone, vendita.TotaleImporto, elencoBase, 0);
                    }
                    else
                    {
                        // una stampa per ogni PROFILO
                        foreach (ProfiloCliente profiloCliente in m_Prenotazione.GestoreProfili.ElencoProfili)
                        {
                            List<Ingresso> elenco = profiloCliente.ElencoIngressiSoluzionePreferita();

                            if (profiloCliente.SoluzionePreferita.ContieneGruppoOppureScuola())
                            {
                                // questo profilo è un gruppo
                                CreaStampa(uow, inizioVal, fineVal, vendita, profiloCliente.NumeroPersone, profiloCliente.ImportoTotale, elenco, profiloCliente.CodiceProgressivo);
                            }
                            else
                            {
                                // questo profilo lo tratto come singolo
                                for (int i = 0; i < profiloCliente.NumeroPersone; i++)
                                {
                                    CreaStampa(uow, inizioVal, fineVal, vendita, 1, profiloCliente.SoluzionePreferita.ImportoUnitario, elenco, profiloCliente.CodiceProgressivo);
                                }
                            }
                        }
                    }
                }

                // creazione righe vendita
                foreach (ProfiloCliente profiloCliente in m_Prenotazione.GestoreProfili.ElencoProfili)
                {
                    foreach (SoluzioneIngressiItem sol in profiloCliente.SoluzionePreferita.Elenco)
                    {
                        if (profiloCliente.SoluzionePreferita.CardMyFE() && sol.Variante.TipologiaTre == EnumTipologiaTre.CardMyFE)
                        {
                            var elencoCard = profiloCliente.SoluzionePreferita.GetElencoCardMyFE(uow);
                            for (int i = 0; i < sol.Quantita; i++)
                            {
                                RigaVenditaVariante riga = new RigaVenditaVariante(uow);
                                riga.PrezzoTotale = sol.PrezzoUnitario;
                                riga.PrezzoUnitario = sol.PrezzoUnitario;
                                riga.Quantita = 1;
                                riga.Vendita = vendita;
                                riga.Profilo = profiloCliente.CodiceProgressivo;
                                riga.Variante = uow.GetObjectByKey<Variante>(sol.Variante.Oid);
                                riga.CodiceSconto = null;
                                riga.Card = elencoCard[i];
                                riga.Save();

                                CreaVenditaElencoRigheUniche(elencorigheuniche, riga);
                            }
                        }
                        else
                        {
                            CodiceSconto cs = null;
                            if (profiloCliente.ElencoCodiciSconto.Count > 0 && sol.Titolo != null && sol.Titolo.Bonus())
                                cs = uow.GetObjectByKey<CodiceSconto>(profiloCliente.ElencoCodiciSconto[0].Oid);

                            RigaVenditaVariante riga = new RigaVenditaVariante(uow);
                            riga.PrezzoTotale = sol.PrezzoTotale;
                            riga.PrezzoUnitario = sol.PrezzoUnitario;
                            riga.Quantita = sol.Quantita;
                            riga.Vendita = vendita;
                            riga.Profilo = profiloCliente.CodiceProgressivo;

                            if (sol.Titolo != null)
                                riga.Titolo = uow.GetObjectByKey<Titolo>(sol.Titolo.Oid);

                            riga.Variante = uow.GetObjectByKey<Variante>(sol.Variante.Oid);
                            riga.CodiceSconto = cs;
                            riga.Save();

                            CreaVenditaElencoRigheUniche(elencorigheuniche, riga);
                        }
                    }

                    profiloCount++;
                }

                parametri.RigaBiglietti = elencorigheuniche.ToArray();

                m_Prenotazione.Vendita = vendita;

                // registra ingressi per QUESTA postazione
                foreach (Stampa item1 in vendita.Stampe)
                {
                    foreach (RigaStampaIngresso item2 in item1.RigheStampaIngresso)
                    {
                        if (VarcoPostazione(item2))
                        {
                            Entrata entrata = new Entrata(uow);
                            entrata.DataOraEntrata = vendita.DataOraStampa;
                            entrata.Quantita = item2.TotalePersone;
                            entrata.RigaStampaIngresso = item2;
                            entrata.Save();

                            item2.TotaleIngressi = item2.TotalePersone;
                            item2.Save();
                        }
                    }
                }

                // QUERY WEB ... per confermare prenotazione
                if (conPrenotazione)
                {
                    if (PrenotazioneFinale.Prenota(parametri, m_Prenotazione.PreventObj))
                    {
                        vendita.CodicePrevent = parametri.CodiceTransWinTicket;
                        vendita.Save();

                        // Salvo tutto ...
                        uow.CommitChanges();
                        result = true;
                    }
                    else
                    {
                        // errore
                        if (PrenotazioneFinale.UltimoErrore != null)
                            XtraMessageBox.Show(String.Format("Errore: {0}", PrenotazioneFinale.UltimoErrore.DescrizioneErrore), "Errore: " + PrenotazioneFinale.UltimoErrore.ReturnCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            XtraMessageBox.Show("Impossibile completare la prenotazione. Ritornare alla maschera precedente e riprovare.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Salvo tutto ...
                    uow.CommitChanges();
                    result = true;
                }
            }

            return result;
        }

        private static bool Diversi(List<Ingresso> elencoBase, List<Ingresso> list)
        {
            foreach (Ingresso item in elencoBase)
            {
                if (!list.Contains(item))
                    return true;
            }

            foreach (Ingresso item in list)
            {
                if (!elencoBase.Contains(item))
                    return true;
            }

            return false;
        }

        private Provenienza _provenienza = null;

        private void buttonEditProvenienza_EditValueChanged(object sender, EventArgs e)
        {
            UpdateProvenienza();
        }

        private void UpdateProvenienza()
        {
            _provenienza = null;

            string cap = (this.buttonEditProvenienza.Text ?? string.Empty).Trim().ToLower();

            if (!string.IsNullOrEmpty(cap))
            {
                foreach (Provenienza provenienza in Program.Provenienze)
                    if (provenienza.CAP.ToLower() == cap) SetProvenienza(provenienza);

                foreach (Provenienza provenienza in Program.Provenienze)
                    if (provenienza.Provincia.ToLower() == cap) SetProvenienza(provenienza);

                foreach (Provenienza provenienza in Program.Provenienze)
                    if (provenienza.Regione.ToLower() == cap) SetProvenienza(provenienza);

                foreach (Provenienza provenienza in Program.Provenienze)
                    if (provenienza.Stato.ToLower() == cap) SetProvenienza(provenienza);

                if (cap.Length >= 3)
                {
                    // INIZIA CON
                    foreach (Provenienza provenienza in Program.Provenienze)
                        if (provenienza.Provincia.ToLower().StartsWith(cap)) SetProvenienza(provenienza);

                    foreach (Provenienza provenienza in Program.Provenienze)
                        if (provenienza.Regione.ToLower().StartsWith(cap)) SetProvenienza(provenienza);

                    foreach (Provenienza provenienza in Program.Provenienze)
                        if (provenienza.Stato.ToLower().StartsWith(cap)) SetProvenienza(provenienza);

                    // CONTIENE
                    foreach (Provenienza provenienza in Program.Provenienze)
                        if (provenienza.Provincia.ToLower().Contains(cap)) SetProvenienza(provenienza);

                    foreach (Provenienza provenienza in Program.Provenienze)
                        if (provenienza.Regione.ToLower().Contains(cap)) SetProvenienza(provenienza);

                    foreach (Provenienza provenienza in Program.Provenienze)
                        if (provenienza.Stato.ToLower().Contains(cap)) SetProvenienza(provenienza);
                }
            }

            // display
            if (_provenienza != null)
            {
                this.buttonEditProvenienza.BackColor = Color.White;
                this.labelControlProvenienza.Text = string.Format("{0} / {1} / {2} / {3}",
                    _provenienza.CAP,
                    _provenienza.Provincia,
                    _provenienza.Regione,
                    _provenienza.Stato);
            }
            else
            {
                this.buttonEditProvenienza.BackColor = string.IsNullOrEmpty(cap) ? Color.White : Color.LightPink;
                this.labelControlProvenienza.Text = string.Empty;
            }
        }

        private void SetProvenienza(Provenienza provenienza)
        {
            if (_provenienza == null) _provenienza = provenienza;
        }

        private void buttonEditProvenienza_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            this.buttonEditProvenienza.Text = "";
        }
    }
}