using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Musei.Module;
using DevExpress.Xpo;

namespace WinTicketNext
{
    public partial class XtraFormMessaggio : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormMessaggio()
        {
            InitializeComponent();
        }

        private Messaggio m_Messaggio;
        public void Init(Messaggio msg)
        {
            if (msg == null)
            {
                m_Messaggio = new Messaggio(this.unitOfWork1);
                m_Messaggio.Tipologia = EnumTipoMessaggio.MessaggioInformativo;
                m_Messaggio.Autore = this.unitOfWork1.GetObjectByKey<Utente>(Program.UtenteCollegato.Oid);
                m_Messaggio.Data = DateTime.Now.Date.AddDays(1);
                m_Messaggio.DataFine = DateTime.Now.Date.AddMonths(1);

                this.ribbonPageGroupScrittura.Visible = true;
                this.ribbonPageGroupLettura.Visible = false;
                this.homeRibbonPage1.Visible = true;

                this.textEditOggetto.Properties.ReadOnly = false;
                this.dateEditData.Properties.ReadOnly = false;
                this.dateEditDataFine.Properties.ReadOnly = false;
                this.richEditControlMain.ReadOnly = false;
            }
            else
            {
                m_Messaggio = this.unitOfWork1.GetObjectByKey<Messaggio>(msg.Oid);

                if (m_Messaggio.Autore.Oid == Program.UtenteCollegato.Oid && m_Messaggio.Autore.Autorizzato(Utente.OperazioneRiepiloghi))
                {
                    this.ribbonPageGroupScrittura.Visible = true;
                    this.ribbonPageGroupLettura.Visible = true;
                    this.homeRibbonPage1.Visible = true;

                    this.textEditOggetto.Properties.ReadOnly = false;
                    this.dateEditData.Properties.ReadOnly = false;
                    this.dateEditDataFine.Properties.ReadOnly = false;
                    this.richEditControlMain.ReadOnly = false;
                }
                else
                {
                    this.ribbonPageGroupLettura.Visible = true;
                    this.ribbonPageGroupScrittura.Visible = false;
                    this.homeRibbonPage1.Visible = false;
                }
            }

            if (m_Messaggio.Tipologia != EnumTipoMessaggio.MessaggioInformativo)
            {
                this.ribbonPageGroupScrittura.Visible = false;
                this.ribbonPageGroupLettura.Visible = false;

                this.richEditControlMain.Text = m_Messaggio.TestoEsteso;
            }
            else
            {
                this.richEditControlMain.HtmlText = m_Messaggio.TestoEsteso;
            }

            this.textEditOggetto.Text = m_Messaggio.Oggetto;
            this.dateEditData.DateTime = m_Messaggio.Data;
            this.dateEditDataFine.DateTime = m_Messaggio.DataFine;
            this.gridControl1.DataSource = m_Messaggio.Conferme;

            if (string.IsNullOrEmpty(m_Messaggio.CreatoDa))
                this.labelControlInfo.Text = "composizione nuovo messaggio";
            else
                this.labelControlInfo.Text = string.Format("Messaggio creato il {0} da {1}, modificato il {2} da {3}",
                    m_Messaggio.CreatoIl, m_Messaggio.CreatoDa, m_Messaggio.ModificatoIl, m_Messaggio.ModificatoDa);

            MessaggioConferma mia = MiaConferma();
            if (mia != null)
            {
                if (mia.Letto)
                    this.barStaticItemInfo.Caption = String.Format("Hai confermato la lettura di questo messaggio il {0:g}", mia.Data);
                else
                    this.barStaticItemInfo.Caption = "[Messaggio non segnato come letto]";
            } else
                this.barStaticItemInfo.Caption = "[Messaggio non segnato come letto]";
        }

        private MessaggioConferma MiaConferma()
        {
            foreach (var item in m_Messaggio.Conferme)
            {
                if (item.Utente.Oid == Program.UtenteCollegato.Oid)
                    return item;
            }
            return null;
        }

        private void barLargeButtonItemLetto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.barEditItemCheck.EditValue != null)
            {
                if ((bool)this.barEditItemCheck.EditValue)
                {
                    MessaggioConferma mia = MiaConferma();
                    if (mia == null)
                    {
                        mia = new MessaggioConferma(this.unitOfWork1);
                        mia.Messaggio = m_Messaggio;
                        mia.Utente = this.unitOfWork1.GetObjectByKey<Utente>(Program.UtenteCollegato.Oid);
                    }
                    mia.Letto = true;
                    mia.Data = DateTime.Now;
                    mia.Save();

                    this.unitOfWork1.CommitChanges();

                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                    XtraMessageBox.Show("Devi confermare la lettura del messaggio", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
                XtraMessageBox.Show("Devi confermare la lettura del messaggio", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void barLargeButtonItemSalva_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_Messaggio.Tipologia == EnumTipoMessaggio.MessaggioInformativo)
            {
                if (Valido())
                {
                    m_Messaggio.Oggetto = this.textEditOggetto.Text;
                    m_Messaggio.Data = this.dateEditData.DateTime.Date;
                    m_Messaggio.DataFine = this.dateEditDataFine.DateTime.Date;
                    m_Messaggio.TestoEsteso = this.richEditControlMain.HtmlText;

                    if (this.unitOfWork1.InTransaction)
                    {
                        // elimina letture
                        this.unitOfWork1.Delete(m_Messaggio.Conferme);

                        //XPCollection<Utente> utenti = new XPCollection<Utente>(this.unitOfWork1);
                        //foreach (Utente utente in utenti)
                        //{
                        //    MessaggioConferma conferma = new MessaggioConferma(this.unitOfWork1);
                        //    conferma.Messaggio = m_Messaggio;
                        //    conferma.Utente = utente;
                        //    conferma.Save();
                        //}

                        this.unitOfWork1.CommitChanges();

                        DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                        XtraMessageBox.Show("Nessuna modifica rilevata. Utilizzare salva solo quando ci sono modifiche al testo");
                }
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private bool Valido()
        {
            if (string.IsNullOrEmpty(this.textEditOggetto.Text))
            {
                XtraMessageBox.Show("indicare un oggetto");
                return false;
            }

            if (dateEditData.DateTime.Year < DateTime.Now.Year)
            {
                XtraMessageBox.Show("manca data inizio periodo"); 
                return false;
            }

            if (dateEditDataFine.DateTime.Year < DateTime.Now.Year)
            {
                XtraMessageBox.Show("manca data fine periodo"); 
                return false;
            }

            if (dateEditDataFine.DateTime.Date == dateEditData.DateTime.Date)
            {
                XtraMessageBox.Show("data inizio e fine non possono coincidere");
                return false;
            }

            return true;
        }

        private void XtraFormMessaggio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.richEditControlMain.ReadOnly && !ConfermaLettura())
                e.Cancel = true;
        }

        private bool ConfermaLettura()
        {
            if (m_Messaggio.Tipologia != EnumTipoMessaggio.MessaggioInformativo)
                return true;

            foreach (var item in m_Messaggio.Conferme)
            {
                if (item.Utente.Oid == Program.UtenteCollegato.Oid && item.Letto)
                    return true;
            }

            return false;
        }

        private void barButtonItemElimina_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Confermi l'eliminazione definitiva di questo messaggio ?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.unitOfWork1.Delete(m_Messaggio);
                this.unitOfWork1.CommitChanges();

                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void barButtonItemStampa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.richEditControlMain.ShowPrintPreview();
            this.printableComponentLink1.ShowRibbonPreviewDialog(DevExpress.LookAndFeel.UserLookAndFeel.Default);
        }
    }
}