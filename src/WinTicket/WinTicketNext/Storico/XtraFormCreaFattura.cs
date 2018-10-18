using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Musei.Module;

namespace WinTicketNext.Storico
{
    public partial class XtraFormCreaFattura : XtraForm
    {
        public XtraFormCreaFattura()
        {
            InitializeComponent();
        }

        private Vendita m_Vendita;
        private Struttura m_Struttura;
        private Fattura m_Fattura;
        private bool m_IsNewInvoice;

        internal void Init(Vendita vendita, Fattura fattura)
        {
            m_Vendita = this.unitOfWork1.GetObjectByKey<Vendita>(vendita.Oid);
            m_Struttura = m_Vendita.Struttura;

            if (m_Struttura.Oid != Program.Postazione.Struttura.Oid && !Program.UtenteCollegato.Amministratore)
                throw new Exception("non autorizzato");

            if (fattura != null)
            {
                m_Fattura = this.unitOfWork1.GetObjectByKey<Fattura>(fattura.Oid);

                this.textEditFatturaNumero.Text = m_Fattura.Codice;

                Lock(true);
            }
            else
            {
                m_IsNewInvoice = true;
                m_Fattura = new Fattura(this.unitOfWork1);

                m_Fattura.Vendita = m_Vendita;
                m_Fattura.Struttura = m_Struttura;
                m_Fattura.DataContabile = m_Vendita.DataContabile;

                m_Fattura.Codice = m_Struttura.SiglaFattura;
                m_Fattura.Anno = m_Fattura.DataContabile.Year;

                if (string.IsNullOrEmpty(m_Fattura.Codice))
                    throw new Exception("Nessuna SiglaFattura associata alla struttura " + m_Struttura.Descrizione);

                var prog = this.unitOfWork1.FindObject<Progressivo>(new GroupOperator(new CriteriaOperator[]
                    {
                        new BinaryOperator("Codice", m_Fattura.Codice),
                        new BinaryOperator("Anno", m_Fattura.Anno)
                    }));

                if (prog == null)
                    m_Fattura.Numero = 1;
                else
                    m_Fattura.Numero = prog.UltimoNumero + 1;

                m_Fattura.CodiceCompleto = string.Format("{0}/{1}/{2}", m_Fattura.Numero, m_Fattura.Codice,
                    m_Fattura.Anno);

                m_Fattura.IntestazioneRiga1 = "Spett.le ";
                m_Fattura.IntestazioneRiga4 = "C.F. : ";

                m_Fattura.Note = "Pagamento effettuato in contante";

                m_Fattura.Utente = this.unitOfWork1.GetObjectByKey<Utente>(Program.UtenteCollegato.Oid);
                m_Fattura.Postazione = this.unitOfWork1.GetObjectByKey<Postazione>(Program.Postazione.Oid);

                foreach (var rv in m_Vendita.RigheVenditaVariante)
                {
                    if (rv.PrezzoTotale > 0)
                    {
                        if (rv.Variante.TipologiaTre == EnumTipologiaTre.CardMyFE)
                        {
                            if (rv.Variante.MyFeComune())
                            {
                                var mrr = new RigaFattura(this.unitOfWork1);

                                mrr.Fattura = m_Fattura;
                                mrr.DescrizioneRiga = rv.Variante.Descrizione;
                                mrr.PrezzoUnitario = Card.PrezzoCard(rv.Card.TipologiaCard);
                                mrr.Quantita = rv.Quantita;
                                mrr.PrezzoTotale = mrr.PrezzoUnitario * rv.Quantita;

                                m_Fattura.RigheFattura.Add(mrr);
                            }

                        }
                        else
                        {
                            var mrr = new RigaFattura(this.unitOfWork1);

                            mrr.Fattura = m_Fattura;
                            mrr.DescrizioneRiga = rv.Variante.Descrizione;
                            mrr.PrezzoUnitario = rv.PrezzoUnitario;
                            mrr.Quantita = rv.Quantita;
                            mrr.PrezzoTotale = rv.PrezzoTotale;

                            m_Fattura.RigheFattura.Add(mrr);
                        }
                    }
                }

                Lock(false);
            }

            this.textEditFatturaNumero.Text = m_Fattura.CodiceCompleto;
            this.textEditFatturaData.DateTime = m_Fattura.DataContabile;

            this.textEditIntestazione1.Text = m_Fattura.IntestazioneRiga1;
            this.textEditIntestazione2.Text = m_Fattura.IntestazioneRiga2;
            this.textEditIntestazione3.Text = m_Fattura.IntestazioneRiga3;
            this.textEditIntestazione4.Text = m_Fattura.IntestazioneRiga4;

            this.textEditNote.Text = m_Fattura.Note;

            this.gridControl1.DataSource = m_Fattura.RigheFattura;
            this.gridView1.BestFitColumns();
        }

        private void barButtonItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.gridView1.CloseEditor();
            this.gridControl1.EndUpdate();

            if (XtraMessageBox.Show("Salva le modifiche ?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                m_Fattura.DataContabile = this.textEditFatturaData.DateTime.Date;
                m_Fattura.IntestazioneRiga1 = this.textEditIntestazione1.Text;
                m_Fattura.IntestazioneRiga2 = this.textEditIntestazione2.Text;
                m_Fattura.IntestazioneRiga3 = this.textEditIntestazione3.Text;
                m_Fattura.IntestazioneRiga4 = this.textEditIntestazione4.Text;

                m_Fattura.Note = this.textEditNote.Text;

                if (m_IsNewInvoice)
                {
                    if (string.IsNullOrEmpty(m_Fattura.Codice))
                        throw new Exception("Nessuna SiglaFattura associata alla struttura " + m_Struttura.Descrizione);

                    var prog = this.unitOfWork1.FindObject<Progressivo>(new GroupOperator(new CriteriaOperator[]
                    {
                        new BinaryOperator("Codice", m_Fattura.Codice),
                        new BinaryOperator("Anno", m_Fattura.Anno)
                    }));

                    if (prog == null)
                        m_Fattura.Numero = 1;
                    else
                        m_Fattura.Numero = prog.UltimoNumero + 1;

                    m_Fattura.CodiceCompleto = string.Format("{0}/{1}/{2}", m_Fattura.Numero, m_Fattura.Codice,
                        m_Fattura.Anno);
                }

                m_Fattura.Totale = m_Fattura.RigheFattura.Sum(a => a.PrezzoTotale);

                if (string.IsNullOrEmpty(m_Fattura.Codice))
                    throw new Exception("Manca il codice fattura nella struttura");

                var fprev = this.unitOfWork1.FindObject<Fattura>(new GroupOperator(new CriteriaOperator[]
                {
                    new BinaryOperator("Codice", m_Fattura.Codice),
                    new BinaryOperator("Numero", m_Fattura.Numero - 1),
                    new BinaryOperator("Anno", m_Fattura.Anno)
                }));
                
                var fsucc = this.unitOfWork1.FindObject<Fattura>(new GroupOperator(new CriteriaOperator[]
                {
                    new BinaryOperator("Codice", m_Fattura.Codice),
                    new BinaryOperator("Numero", m_Fattura.Numero + 1),
                    new BinaryOperator("Anno", m_Fattura.Anno)
                }));

                if (fprev != null && fprev.DataContabile > m_Fattura.DataContabile)
                {
                    XtraMessageBox.Show(
                        "Esiste una fattura precedente " +
                        fprev.CodiceCompleto + " con data successiva.", "Errore",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;                    
                }

                if (fsucc != null && fsucc.DataContabile < m_Fattura.DataContabile)
                {
                    XtraMessageBox.Show(
                        "Esiste una fattura successiva " +
                        fsucc.CodiceCompleto + " con data precedente.", "Errore",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                foreach (var item in m_Fattura.RigheFattura)
                {
                    if (item.PrezzoTotale != item.Quantita*item.PrezzoUnitario)
                    {
                        XtraMessageBox.Show("Il totale non coincide per la riga: " + item.DescrizioneRiga, "Errore",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }
                }

                if (m_Fattura.Totale > m_Vendita.TotaleImporto)
                {
                    XtraMessageBox.Show(
                        "Il totale in fattura non può essere maggiore della vendita selezionata: " +
                        m_Vendita.TotaleImporto.ToString("c"), "Errore",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                if (m_Fattura.Totale + m_Vendita.Fatture.Where(a => a.Oid != m_Fattura.Oid).Sum(a => a.Totale) > m_Vendita.TotaleImporto)
                {
                    XtraMessageBox.Show(
                        "La somma delle fatture emesse non può essere maggiore della vendita selezionata: " +
                        m_Vendita.TotaleImporto.ToString("c"),
                        "Errore",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                m_Fattura.Save();

                this.unitOfWork1.CommitChanges();

                if (m_IsNewInvoice)
                {
                    m_IsNewInvoice = false;

                    var prog = this.unitOfWork1.FindObject<Progressivo>(new GroupOperator(new CriteriaOperator[]
                    {
                        new BinaryOperator("Codice", m_Fattura.Codice),
                        new BinaryOperator("Anno", m_Fattura.Anno)
                    }));

                    if (prog == null)
                    {
                        prog = new Progressivo(this.unitOfWork1);
                        prog.Codice = m_Fattura.Codice;
                        prog.Anno = m_Fattura.Anno;
                        prog.UltimoNumero = m_Fattura.Numero;

                        prog.Save();
                    }
                    else
                    {
                        prog.UltimoNumero = m_Fattura.Numero;

                        prog.Save();                        
                    }

                    this.unitOfWork1.CommitChanges();                    
                }

                Lock(true);

                this.textEditFatturaNumero.Text = m_Fattura.CodiceCompleto;

                modificata = true;
            }
        }

        private void Lock(bool mode)
        {
            this.groupControl1.Enabled = !mode;
            this.ribbonPageGroupElimina.Enabled = mode;
            this.ribbonPageGroupStampa.Enabled = mode;
            this.barButtonItemSave.Enabled = !mode;
            this.barButtonItemModifica.Enabled = mode;
        }

        public bool modificata = false;

        private void barButtonItemModifica_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!this.groupControl1.Enabled)
            {
                if (XtraMessageBox.Show("Attenzione vuoi veramente modificare la fattura ?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Lock(false);
                }
            }
        }

        private void barButtonItemStampa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!this.groupControl1.Enabled)
            {
                XtraReportFattura rfat = new XtraReportFattura();
                rfat.Init(m_Fattura);

                rfat.Print();
            }
            else
            {
                XtraMessageBox.Show("Attenzione prima di stampare devi salvare la fattura.", "Avviso",
                    MessageBoxButtons.OK);
            }
        }

        private void barButtonItemStampaAnteprima_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!this.groupControl1.Enabled)
            {
                XtraReportFattura rfat = new XtraReportFattura();
                rfat.Init(m_Fattura);

                rfat.ShowRibbonPreview();
            }
            else
            {
                XtraMessageBox.Show("Attenzione prima di stampare devi salvare la fattura.", "Avviso",
                    MessageBoxButtons.OK);
            }
        }

        private void XtraFormCreaFattura_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modificata)
                this.DialogResult = DialogResult.OK;
        }

        private void barButtonItemElimina_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!this.groupControl1.Enabled)
            {

                var prog = this.unitOfWork1.FindObject<Progressivo>(new GroupOperator(new CriteriaOperator[]
                {
                    new BinaryOperator("Codice", m_Fattura.Codice),
                    new BinaryOperator("Anno", m_Fattura.Anno)
                }));

                if (prog != null && prog.UltimoNumero == m_Fattura.Numero)
                {
                    if (
                        XtraMessageBox.Show("Confermi l'eliminazione della fattura ?", "Conferma", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        prog.UltimoNumero = prog.UltimoNumero - 1;
                        prog.Save();

                        this.unitOfWork1.Delete(m_Fattura.RigheFattura);
                        this.unitOfWork1.Delete(m_Fattura);

                        this.unitOfWork1.CommitChanges();

                        DialogResult = DialogResult.OK;
                    }
                }
                    else
                {
                    XtraMessageBox.Show("Puoi eliminare solo l'ultima fattura emessa.", "Errore",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}