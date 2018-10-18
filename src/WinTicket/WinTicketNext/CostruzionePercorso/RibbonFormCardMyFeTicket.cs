using System;
using System.Collections.Generic;
using DevExpress.Xpo;
using Musei.Module;
using DevExpress.Data.Filtering;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;

namespace WinTicketNext.CostruzionePercorso
{
    public partial class RibbonFormCardMyFeTicket : RibbonForm
    {
        private UnitOfWork _UnitOfWork;

        public List<Card> ElencoCard = new List<Card>();
        private EnumTipologiaCard _TipoCard;
        private int _NumeroCard;
        
        public RibbonFormCardMyFeTicket()
        {
            InitializeComponent();
        }

        private void timerTick_Tick(object sender, EventArgs e)
        {
            if (!this.buttonEditCodice.EditorContainsFocus)
                this.buttonEditCodice.Focus();
        }

        internal void Init(int numeroCard, EnumTipologiaCard tipoCard)
        {
            _NumeroCard = numeroCard;
            _TipoCard = tipoCard;
            _UnitOfWork = new UnitOfWork();

            this.gridControlElencoCard.DataSource = ElencoCard;

            UpdateInfo();
        }

        private void UpdateInfo()
        {
            this.gridControlElencoCard.RefreshDataSource();
            this.simpleButtonOk.Enabled = ElencoCard.Count == _NumeroCard;
            if (ElencoCard.Count == _NumeroCard)
                this.labelControlTotale.Text = "OK";
            else
                this.labelControlTotale.Text = string.Format("Mancano {0} card", _NumeroCard - ElencoCard.Count);
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            if (Program.Postazione.Tipologia == EnumTipologiaPostazione.NonAttiva)
            {
                XtraMessageBox.Show("Questa postazione non e' abilitata per emettere biglietti.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void simpleButtonCheck_Click(object sender, EventArgs e)
        {
            string str = this.buttonEditCodice.Text;
            Card card = _UnitOfWork.FindObject<Card>(new BinaryOperator("Codice", str));
            if (card != null)
            {
                this.labelControlSearchResult.Text = string.Format("OK: {0} trovato", str);

                if (card.Status == EnumStatoCard.Assegnata && card.AssegnataStruttura != null && card.AssegnataStruttura.Oid == Program.Postazione.Struttura.Oid)
                {
                    if (!ElencoCard.Contains(card))
                    {
                        if (card.TipologiaCard == _TipoCard)
                        {
                            if (ElencoCard.Count < _NumeroCard)
                                ElencoCard.Add(card);
                            else
                                XtraMessageBox.Show("Errore: troppe card!", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            XtraMessageBox.Show(string.Format("Errore: la card {0} ({1}) risulta non essere: {2}",
                                card.Codice,
                                card.Status,
                                _TipoCard
                                ), "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        XtraMessageBox.Show("Errore: già presente nell'elenco!", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (card.Status == EnumStatoCard.Emessa)
                        XtraMessageBox.Show(string.Format("Errore: la card {0} risulta emessa il {1} da {2}.",
                            card.Codice,
                            card.Stampa.Vendita.DataOraStampa,
                            card.Stampa.Vendita.Postazione.Nome
                            ), "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        XtraMessageBox.Show(string.Format("Errore: la card {0} non è vendibile da questa postazione: {1} - {2}.",
                            card.Codice,
                            card.Status, card.AssegnataStruttura == null ? "" : card.AssegnataStruttura.Descrizione), "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                this.labelControlSearchResult.Text = string.Format("Codice {0} NON trovato!", str);
            }

            this.buttonEditCodice.Text = "";
            UpdateInfo();
        }

        private void gridControlElencoCard_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Custom)
            {
                Card obj = this.gridViewElencoCard.GetFocusedRow() as Card;
                if (obj != null)
                {
                    ElencoCard.Remove(obj);
                    UpdateInfo();
                }
            }
        }
    }
}