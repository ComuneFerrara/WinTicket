using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using Musei.Module;
using DevExpress.XtraTab;
using DevExpress.Xpo;
using PreventWebServices;

namespace WinTicketNext.CostruzionePercorso.GestionePrenotazione
{
    public partial class XtraUserControlCalendario2 : DevExpress.XtraEditors.XtraUserControl
    {
        public XtraUserControlCalendario2()
        {
            InitializeComponent();
        }

        public Ingresso Ingresso
        {
            get
            {
                return m_Ingresso;
            }
        }

        private PrenotazioneIngresso m_Prenotazione;
        private PrenotazioneComplessiva m_PrenotazioneComplessiva;
        private Ingresso m_Ingresso;
        private XtraTabPage m_Pagina;
        private XPCollection m_CollectionPrenotazioni;
        private XPCollection<Prenotazione> m_CollectionMySet;
        private UnitOfWork m_UnitOfWork;
        private SchedulerControl m_Scheduler;

        private bool m_PrenotazioneAttiva = false;
        private bool m_PrenotazioneErrore = false;

        public void Init(PrenotazioneIngresso prenotazione, XtraTabPage pagina, XPCollection collectionPrenotazioni, SchedulerControl scheduler, PrenotazioneComplessiva complessiva)
        {
            m_Scheduler = scheduler;
            m_UnitOfWork = (UnitOfWork)collectionPrenotazioni.Session;
            m_CollectionMySet = new XPCollection<Prenotazione>(m_UnitOfWork, false);
            m_CollectionPrenotazioni = collectionPrenotazioni;
            m_Pagina = pagina;
            m_Prenotazione = prenotazione;
            m_PrenotazioneComplessiva = complessiva;
            m_Ingresso = m_UnitOfWork.GetObjectByKey<Ingresso>(m_Prenotazione.Ingresso.Oid);

            m_PrenotazioneAttiva = prenotazione.Attivo;
            m_PrenotazioneErrore = false;

            CreaPrenotazione(false);

            VerificaStato();
        }

        private void AggiornaVideo()
        {
            if (m_PrenotazioneAttiva)
            {
                this.gridControlPrenotazioni.Visible = true;
                this.simpleButtonCrea.Visible = false;
            }
            else
            {
                this.gridControlPrenotazioni.Visible = false;
                this.simpleButtonCrea.Visible = true;
            }
        }

        private void gridControlPrenotazioni_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Append)
            {
                e.Handled = true;

                Prenotazione prenotazione = new Prenotazione(m_UnitOfWork);
                prenotazione.Ingresso = m_Ingresso;
                prenotazione.Description = m_Ingresso.Descrizione;
                prenotazione.Subject = PrenotazioneComplessiva.RiferimentoGlobale;
                    // "nuova squadra";
                //prenotazione.DurataSlot = m_Ingresso.DurataSlot(GestoreCalendario.TipoGS);
                prenotazione.DurataSlot = GestoreCalendario.GetTimeSpan(m_Ingresso.CodicePrevent);
                prenotazione.StartDate = this.m_Scheduler.SelectedInterval.Start;
                prenotazione.StartDate = prenotazione.FixStartDate();

                using (XtraFormEditPrenotazione formpre = new XtraFormEditPrenotazione())
                {
                    formpre.Init(prenotazione);
                    if (formpre.ShowDialog(this) == DialogResult.OK)
                    {
                        prenotazione.Save();
                        this.m_CollectionMySet.Add(prenotazione);
                        this.m_CollectionPrenotazioni.Add(prenotazione);
                        VerificaStato();
                    }
                }
            }

            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                e.Handled = true;

                Prenotazione prenotazione = this.gridViewPrenotazioni.GetRow(this.gridViewPrenotazioni.FocusedRowHandle) as Prenotazione;
                if (prenotazione != null)
                {
                    prenotazione.Delete();
                    VerificaStato();
                }
            }
        }

        public bool VerificaStato()
        {
            int count = 0;
            int totalepersone = 0;
            bool errore = false;
            foreach (Prenotazione item in this.m_CollectionMySet)
            {
                count++;
                totalepersone += item.NumeroPersone;
                if (item.Disponibilita != EnumDisponibilita.Disponibile)
                    errore = true;
            }

            this.gridViewPrenotazioni.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridViewPrenotazioni.Appearance.OddRow.ForeColor = Color.Black;
            this.gridViewPrenotazioni.Appearance.EvenRow.ForeColor = Color.Black;
            this.gridViewPrenotazioni.Appearance.Row.ForeColor = Color.Black;

            if (count == 0)
            {
                m_PrenotazioneAttiva = false;
                errore = false;
            }
            else
            {
                m_PrenotazioneAttiva = true;
                if (totalepersone != m_Prenotazione.NumeroPersone)
                {
                    this.gridViewPrenotazioni.Appearance.FocusedRow.ForeColor = Color.Red;
                    this.gridViewPrenotazioni.Appearance.OddRow.ForeColor = Color.Red;
                    this.gridViewPrenotazioni.Appearance.EvenRow.ForeColor = Color.Red;
                    this.gridViewPrenotazioni.Appearance.Row.ForeColor = Color.Red;

                    errore = true;
                }
            }

            AggiornaVideo();

            if (m_PrenotazioneAttiva)
            {
                if (errore)
                {
                    m_Pagina.ImageIndex = 7;
                    m_PrenotazioneErrore = true;
                }
                else
                {
                    m_Pagina.ImageIndex = 6;
                    m_PrenotazioneErrore = false;
                }
            }
            else
            {
                m_PrenotazioneErrore = false;

                switch (m_Prenotazione.Ingresso.Prenotazione)
                {
                    case EnumPrenotazioneIngresso.NonGestita:
                        //m_Pagina.ImageIndex = 0;
                        break;
                    case EnumPrenotazioneIngresso.Facoltativa:
                        m_Pagina.ImageIndex = 1;
                        break;
                    case EnumPrenotazioneIngresso.Consigliata:
                        m_Pagina.ImageIndex = 2;
                        break;
                    case EnumPrenotazioneIngresso.Obbligatoria:
                        m_Pagina.ImageIndex = 3;
                        break;
                }
            }

            return m_PrenotazioneErrore;
        }

        public void Elabora(RichiestaVerifica dato)
        {
            foreach (Prenotazione item in this.m_CollectionMySet)
            {
                if (item.IdRichiesta == dato.IdRichiesta)
                {
                    if (dato.Disponibile)
                    {
                        item.Disponibilita = EnumDisponibilita.Disponibile;
                        item.Description = item.Ingresso.Descrizione;
                    }
                    else
                    {
                        item.Disponibilita = EnumDisponibilita.NonDisponibile;
                        item.Description = item.Ingresso.Descrizione + Environment.NewLine + dato.CodiceErrore;
                    }

                    item.SetLabel(m_PaginaAttiva);

                    //Console.WriteLine(dato.XmlRisposta);
                }
            }
        }

        private void timerTick_Tick(object sender, EventArgs e)
        {
            VerificaDisponibilita.GeneraEventi();

            foreach (Prenotazione item in this.m_CollectionMySet)
            {
                if (item.Disponibilita == EnumDisponibilita.DaControllare)
                {
                    if (item.OriginataPrevent && item.StartDate == item.PreventStartDate)
                    {
                        item.Disponibilita = EnumDisponibilita.Disponibile;
                        item.Description = item.Ingresso.Descrizione;
                        item.SetLabel(m_PaginaAttiva);                    
                    }
                    else
                    {
                        item.IdRichiesta = Guid.NewGuid();
                        item.Disponibilita = EnumDisponibilita.ControlloInCorso;

                        prevent.verifica.Parametri parametri = new prevent.verifica.Parametri();
                        parametri.Denominazione = "VERIFICA";
                        parametri.PaxTotali = item.NumeroPersone.ToString();
                        parametri.TipoGS = GestoreCalendario.TipoGS;
                        if (!string.IsNullOrEmpty(m_PrenotazioneComplessiva.PrenotazionePrevent))
                            parametri.NumeroPrenotazione = m_PrenotazioneComplessiva.PrenotazionePrevent;

                        parametri.RigaPercorsoVisita = new prevent.verifica.ParametriRigaPercorsoVisita[1];
                        parametri.RigaPercorsoVisita[0] = new prevent.verifica.ParametriRigaPercorsoVisita();

                        parametri.RigaPercorsoVisita[0].DataVisita = item.StartDate.Date;
                        parametri.RigaPercorsoVisita[0].OraVisita = String.Format("{0:HH}:{1:mm}:{2:ss}.{3:ffffzzz}", item.StartDate, item.StartDate, item.StartDate, item.StartDate);
                        parametri.RigaPercorsoVisita[0].PaxVisita = item.NumeroPersone.ToString();
                        parametri.RigaPercorsoVisita[0].IdMostra = item.Ingresso.CodicePrevent.ToString();

                        VerificaDisponibilita.Verifica(parametri, item.IdRichiesta, Elabora);
                    }
                }
            }

            VerificaStato();
        }

        public void CreaPrenotazione(bool manuale)
        {
            // cancello se presenti nel calendario
            foreach (Prenotazione item in this.m_CollectionMySet)
            {
                this.m_CollectionPrenotazioni.Remove(item);
            }

            this.m_CollectionMySet = new XPCollection<Prenotazione>(m_UnitOfWork, false);

            m_Ingresso = m_UnitOfWork.GetObjectByKey<Ingresso>(m_Prenotazione.Ingresso.Oid);

            if (manuale)
                m_Prenotazione.Init(this.m_CollectionPrenotazioni, this.m_Scheduler.SelectedInterval.Start, GestoreCalendario.TipoGS);

            foreach (SingolaPrenotazione singolaPrenotazione in m_Prenotazione.Prenotazioni)
            {
                Prenotazione pren = new Prenotazione(m_UnitOfWork);
                //pren.DurataSlot = m_Ingresso.DurataSlot(GestoreCalendario.TipoGS);
                pren.DurataSlot = GestoreCalendario.GetTimeSpan(m_Ingresso.CodicePrevent);
                pren.StartDate = singolaPrenotazione.Orario;
                pren.EndDate = singolaPrenotazione.Orario + new TimeSpan(0, GestoreCalendario.GetTimeSpan(m_Ingresso.CodicePrevent), 0);
                    //new TimeSpan(0, m_Ingresso.DurataSlot(GestoreCalendario.TipoGS), 0);
                pren.Subject = singolaPrenotazione.Descrizione;
                    //"Squadra " + nomegruppo[this.m_CollectionMySet.Count % nomegruppo.Length]; // +" (" + singolaPrenotazione.NumeroPersone.ToString() + " persone)";
                pren.Ingresso = m_Ingresso;
                pren.Description = m_Ingresso.Descrizione;
                pren.NumeroPersone = singolaPrenotazione.NumeroPersone;
                pren.OriginataPrevent = singolaPrenotazione.OriginataPrevent;
                pren.PreventStartDate = pren.StartDate;
                pren.SetLabel(m_PaginaAttiva);

                pren.Save();

                this.m_CollectionMySet.Add(pren);
                this.m_CollectionPrenotazioni.Add(pren);
            }

            VerificaStato();

            this.m_Scheduler.RefreshData();

            this.gridControlPrenotazioni.DataSource = this.m_CollectionMySet;
            this.gridViewPrenotazioni.BestFitColumns();
        }

        private void simpleButtonCrea_Click(object sender, EventArgs e)
        {
            if (m_Ingresso.Prenotazione == EnumPrenotazioneIngresso.NonGestita || m_Ingresso.CodicePrevent == 0)
            {
                XtraMessageBox.Show("La prenotazione per questo ingresso NON è possibile.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CreaPrenotazione(true);
                VerificaStato();
            }
        }

        private bool m_PaginaAttiva = true;
        public bool NotificaAttivazione(XtraTabPage xtraTabPage)
        {
            m_PaginaAttiva = (xtraTabPage == this.m_Pagina);
            foreach (Prenotazione item in this.m_CollectionMySet)
            {
                item.SetLabel(m_PaginaAttiva);
            }

            VerificaStato();

            return m_PaginaAttiva;
        }

        private void gridControlPrenotazioni_DoubleClick(object sender, EventArgs e)
        {
            Prenotazione prenotazione = this.gridViewPrenotazioni.GetRow(this.gridViewPrenotazioni.FocusedRowHandle) as Prenotazione;
            if (prenotazione != null)
            {
                using (XtraFormEditPrenotazione formpre = new XtraFormEditPrenotazione())
                {
                    formpre.Init(prenotazione);
                    if (formpre.ShowDialog(this) == DialogResult.OK)
                    {
                        prenotazione.Save();
                        this.m_CollectionMySet.Add(prenotazione);
                        this.m_CollectionPrenotazioni.Add(prenotazione);
                        VerificaStato();
                    }
                }
            }
        }

        public void SalvaTutto()
        {
            VerificaStato();

            m_Prenotazione.Prenotazioni.Clear();
            if (m_PrenotazioneAttiva)
            {
                foreach (Prenotazione item in m_CollectionMySet)
                {
                    SingolaPrenotazione singolaPrenotazione = new SingolaPrenotazione();
                    singolaPrenotazione.NumeroPersone = item.NumeroPersone;
                    singolaPrenotazione.Orario = item.StartDate;
                    singolaPrenotazione.OrarioFine = item.EndDate;
                    singolaPrenotazione.Descrizione = item.Subject;
                    singolaPrenotazione.OriginataPrevent = item.OriginataPrevent;
                    singolaPrenotazione.OrarioPrevent = item.PreventStartDate;

                    m_Prenotazione.Prenotazioni.Add(singolaPrenotazione);
                }
            }
        }
    }
}
