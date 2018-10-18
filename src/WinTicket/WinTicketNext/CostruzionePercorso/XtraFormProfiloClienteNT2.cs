using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Xpo;
using Musei.Module;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using DevExpress.XtraEditors;

namespace WinTicketNext.CostruzionePercorso
{
    public partial class XtraFormProfiloClienteNT2 : DevExpress.XtraEditors.XtraForm
    {
        private const int ColonnaQta = 3;

        public XtraFormProfiloClienteNT2()
        {
            InitializeComponent();
        }

        private GestoreTitoli m_GestoreTitoliSingoliGruppi;
        private GestoreTitoli m_GestoreTitoliScuole;
        private GestoreProfili m_GestoreProfili;
        public void Init(UnitOfWork session, List<Ingresso> percorso, GestoreProfili gestore)
        {
            m_GestoreProfili = gestore;

            m_GestoreTitoliSingoliGruppi = new GestoreTitoli(session);
            m_GestoreTitoliSingoliGruppi.ReBuildElencoTitoli(percorso, false, this.treeListSingolo);
            m_GestoreTitoliSingoliGruppi.ApplyElencoTitoli(m_GestoreProfili, this.treeListSingolo, false);

            m_GestoreTitoliScuole = new GestoreTitoli(session);
            m_GestoreTitoliScuole.ReBuildElencoTitoli(percorso, true, this.treeListScuola);
            m_GestoreTitoliScuole.ApplyElencoTitoli(m_GestoreProfili, this.treeListScuola, true);

            this.checkEditScuola.Checked = (m_GestoreProfili.TotalePersoneScuole() > 0);

            checkEditScuola_CheckedChanged(null, null);

            this.spinEditNumero.Value = m_GestoreProfili.TotalePersone();
            if (this.spinEditNumero.Value == 0)
                this.spinEditNumero.Value = 1;

            this.spinEditNumeroS.Value = m_GestoreProfili.TotalePersoneScuole();

            SetupAlbero();

            AggiornaTotale();
        }


        public void Init(UnitOfWork session, List<Ingresso> elencoIngressi, GestoreProfili gestore, Percorso percorso)
        {
            m_GestoreProfili = gestore;

            m_GestoreTitoliSingoliGruppi = new GestoreTitoli(session);
            m_GestoreTitoliSingoliGruppi.ReBuildElencoTitoli(percorso, false, this.treeListSingolo);
            m_GestoreTitoliSingoliGruppi.ApplyElencoTitoli(m_GestoreProfili, this.treeListSingolo, false);

            m_GestoreTitoliScuole = new GestoreTitoli(session);
            m_GestoreTitoliScuole.ReBuildElencoTitoli(percorso, true, this.treeListScuola);
            m_GestoreTitoliScuole.ApplyElencoTitoli(m_GestoreProfili, this.treeListScuola, true);

            this.checkEditScuola.Checked = (m_GestoreProfili.TotalePersoneScuole() > 0);

            checkEditScuola_CheckedChanged(null, null);

            this.spinEditNumero.Value = m_GestoreProfili.TotalePersone();
            if (this.spinEditNumero.Value == 0)
                this.spinEditNumero.Value = 1;

            this.spinEditNumeroS.Value = m_GestoreProfili.TotalePersoneScuole();

            SetupAlbero();

            AggiornaTotale();
        }

        private void SetupAlbero()
        {
            foreach (TreeListNode treeListNode in this.treeListScuola.Nodes)
            {
                if (treeListNode.HasChildren)
                {
                    foreach (TreeListNode item in treeListNode.Nodes)
                    {
                        if (item.GetValue(this.treeListScuola.Columns[ColonnaQta]) != null)
                            treeListNode.ExpandAll();
                    }
                }
            }

            foreach (TreeListNode treeListNode in this.treeListSingolo.Nodes)
            {
                if (treeListNode.HasChildren)
                {
                    foreach (TreeListNode item in treeListNode.Nodes)
                    {
                        if (item.GetValue(this.treeListScuola.Columns[ColonnaQta]) != null)
                            treeListNode.ExpandAll();
                    }
                }
            }
        }

        private void AggiornaTotale()
        {
            int totaleScuola = 0;
            if (this.checkEditScuola.Checked)
            {
                foreach (TreeListNode treeListNode in this.treeListScuola.Nodes)
                {
                    totaleScuola += SafeInt(treeListNode.GetValue(this.treeListScuola.Columns[ColonnaQta]));
                    if (treeListNode.HasChildren)
                        totaleScuola += GetTotale(treeListNode, this.treeListScuola);
                }
            }

            int totaleSingoli = 0;
            foreach (TreeListNode treeListNode in this.treeListSingolo.Nodes)
            {
                totaleSingoli += SafeInt(treeListNode.GetValue(this.treeListSingolo.Columns[ColonnaQta]));
                if (treeListNode.HasChildren)
                    totaleSingoli += GetTotale(treeListNode, this.treeListSingolo);
            }

            int totale = totaleSingoli + totaleScuola;

            if (totale > this.spinEditNumero.Value || (
                this.checkEditScuola.Checked && totaleSingoli + this.spinEditNumeroS.Value > this.spinEditNumero.Value
                ))
                this.spinEditNumero.BackColor = Color.LightSalmon;
            else
                this.spinEditNumero.BackColor = Color.White;

            if (totaleScuola > this.spinEditNumeroS.Value || this.spinEditNumeroS.Value > this.spinEditNumero.Value)
                this.spinEditNumeroS.BackColor = Color.LightSalmon;
            else
                this.spinEditNumeroS.BackColor = Color.White;

            if (totaleScuola != 0)
            {
                this.xtraTabPage1.Appearance.Header.Font = new Font(this.xtraTabPage1.Appearance.Header.Font, FontStyle.Bold);
                this.xtraTabPage1.Text = String.Format("Scuole ({0})", totaleScuola);
            }
            else
            {
                this.xtraTabPage1.Appearance.Header.Font = new Font(this.xtraTabPage1.Appearance.Header.Font, FontStyle.Regular);
                this.xtraTabPage1.Text = "Scuole";
            }

            if (totaleSingoli != 0)
            {
                this.xtraTabPage2.Appearance.Header.Font = new Font(this.xtraTabPage2.Appearance.Header.Font, FontStyle.Bold);
                this.xtraTabPage2.Text = String.Format("Singoli e gruppi ({0})", totaleSingoli);
            }
            else
            {
                this.xtraTabPage2.Appearance.Header.Font = new Font(this.xtraTabPage2.Appearance.Header.Font, FontStyle.Regular);
                this.xtraTabPage2.Text = "Singoli e gruppi";
            }
        }

        private static int SafeInt(object oggetto)
        {
            if (oggetto == null)
                return 0;

            string objstr = oggetto.ToString();
            if (string.IsNullOrEmpty(objstr))
                return 0;

            int objnum;
            if (Int32.TryParse(objstr, out objnum))
                return objnum;
            else
                return 0;
        }

        private static int GetTotale(TreeListNode treeListNode, TreeList treeList)
        {
            int totale = 0;
            foreach (TreeListNode nodo in treeListNode.Nodes)
            {
                totale += SafeInt(nodo.GetValue(treeList.Columns[ColonnaQta]));                
                if (nodo.HasChildren)
                    totale += GetTotale(nodo, treeList);
            }

            return totale;
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            AggiornaTotale();
            if (this.spinEditNumero.BackColor == Color.LightSalmon || this.spinEditNumeroS.BackColor == Color.LightSalmon)
            {
                XtraMessageBox.Show("Valori incongruenti, siete pregati di controllare.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            m_GestoreProfili.ElencoProfili.Clear();

            int totaleSingolo = 0;
            foreach (TreeListNode treeListNode in this.treeListSingolo.Nodes)
            {
                int valore = SafeInt(treeListNode.GetValue(this.treeListSingolo.Columns[ColonnaQta]));
                totaleSingolo += valore;
                if (valore != 0)
                {
                    ProfiloCliente newProfiloCliente = new ProfiloCliente(valore, treeListNode.Tag as Titolo, false);

                    m_GestoreProfili.ElencoProfili.Add(newProfiloCliente);
                }
                if (treeListNode.HasChildren)
                    totaleSingolo += CheckChildrens(treeListNode, this.treeListSingolo, false);
            }

            int totaleScuola = 0;
            if (this.checkEditScuola.Checked)
            {
                foreach (TreeListNode treeListNode in this.treeListScuola.Nodes)
                {
                    int valore = SafeInt(treeListNode.GetValue(this.treeListScuola.Columns[ColonnaQta]));
                    totaleScuola += valore;
                    if (valore != 0)
                    {
                        ProfiloCliente newProfiloCliente = new ProfiloCliente(valore, treeListNode.Tag as Titolo, true);

                        m_GestoreProfili.ElencoProfili.Add(newProfiloCliente);
                    }
                    if (treeListNode.HasChildren)
                        totaleScuola += CheckChildrens(treeListNode, this.treeListScuola, true);
                }

                int totale = (int)this.spinEditNumeroS.Value;
                totale = totale - totaleScuola;
                if (totale > 0)
                {
                    ProfiloCliente newProfiloCliente = new ProfiloCliente(totale, null, true);
                    m_GestoreProfili.ElencoProfili.Add(newProfiloCliente);
                    totaleScuola += totale;
                }
            }

            int totaleInteri = (int)this.spinEditNumero.Value;
            totaleInteri = totaleInteri - totaleScuola - totaleSingolo;
            if (totaleInteri > 0)
            {
                ProfiloCliente newProfiloCliente = new ProfiloCliente(totaleInteri, null, false);
                m_GestoreProfili.ElencoProfili.Add(newProfiloCliente);
            }

            m_GestoreProfili.SetCodiceSconto(m_GestoreProfili.GetCodiceSconto());

            DialogResult = DialogResult.OK;
        }

        private int CheckChildrens(TreeListNode treeListNode, TreeList albero, bool scuola)
        {
            int totale = 0;
            foreach (TreeListNode nodo in treeListNode.Nodes)
            {
                int valore = SafeInt(nodo.GetValue(albero.Columns[ColonnaQta]));
                totale += valore;

                if (valore != 0)
                {
                    m_GestoreProfili.ElencoProfili.Add(
                        new ProfiloCliente(valore, nodo.Tag as Titolo, scuola)
                    );
                }

                if (nodo.HasChildren)
                    totale += CheckChildrens(nodo, albero, scuola);
            }

            return totale;
        }

        private void XtraFormProfiloCliente_Activated(object sender, EventArgs e)
        {
            this.treeListScuola.BestFitColumns();
            this.treeListSingolo.BestFitColumns();
        }

        private void checkEditScuola_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkEditScuola.Checked)
            {
                if (!this.xtraTabControl1.TabPages.Contains(this.xtraTabPage1))
                    this.xtraTabControl1.TabPages.Add(this.xtraTabPage1);

                this.xtraTabControl1.TabPages.Move(0, this.xtraTabPage1);
                this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;

                this.labelControlS.Visible = true;
                this.spinEditNumeroS.Visible = true;

                if (sender != null)
                {
                    this.spinEditNumeroS.Value = this.spinEditNumero.Value;
                    AggiornaTotale();
                }
            }
            else
            {
                if (this.xtraTabControl1.TabPages.Contains(this.xtraTabPage1))
                    this.xtraTabControl1.TabPages.Remove(this.xtraTabPage1);

                this.labelControlS.Visible = false;
                this.spinEditNumeroS.Visible = false;
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            this.treeListScuola.BestFitColumns();
            this.treeListSingolo.BestFitColumns();
        }

        private void treeListScuola_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.treeListScuola.FocusedNode == null || this.treeListScuola.FocusedNode.HasChildren)
                e.Cancel = true;
        }

        private void treeListSingolo_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.treeListSingolo.FocusedNode == null || this.treeListSingolo.FocusedNode.HasChildren)
                e.Cancel = true;
        }

        private static bool IsNum(object eNodeGetValue)
        {
            return SafeInt(eNodeGetValue) > 0;
        }

        private void treeListScuola_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            if (IsNum(e.Node.GetValue(this.treeListScuola.Columns[ColonnaQta])))
            {
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                e.Appearance.ForeColor = Color.Red;
            }

            if (e.Node.HasChildren)
            {
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Regular);
                foreach (TreeListNode item in e.Node.Nodes)
                {
                    if (IsNum(item.GetValue(this.treeListScuola.Columns[ColonnaQta])))
                    {
                        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                        e.Appearance.ForeColor = Color.Red;
                        break;
                    }
                }
            }
        }

        private void treeListSingolo_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            if (IsNum(e.Node.GetValue(this.treeListSingolo.Columns[ColonnaQta])))
            {
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                e.Appearance.ForeColor = Color.Red;
            }

            if (e.Node.HasChildren)
            {
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Regular);
                foreach (TreeListNode item in e.Node.Nodes)
                {
                    if (IsNum(item.GetValue(this.treeListSingolo.Columns[ColonnaQta])))
                    {
                        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                        e.Appearance.ForeColor = Color.Red;
                        break;
                    }
                }
            }
        }

        private void treeListScuola_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            AggiornaTotale();
        }

        private void treeListSingolo_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            AggiornaTotale();
        }

        private void simpleButtonMeno_Click(object sender, EventArgs e)
        {
            if (this.spinEditNumero.Value > 1)
                this.spinEditNumero.Value -= 1;

            AggiornaTotale();
        }

        private void simpleButtonPiu_Click(object sender, EventArgs e)
        {
            if (this.spinEditNumero.Value < 999)
                this.spinEditNumero.Value += 1;

            AggiornaTotale();
        }

        private void spinEditNumero_EditValueChanged(object sender, EventArgs e)
        {
            AggiornaTotale();
        }

        private void spinEditNumeroS_EditValueChanged(object sender, EventArgs e)
        {
            AggiornaTotale();
        }

        private void spinEditNumeroS_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Right)
            {
                this.spinEditNumeroS.Value = this.spinEditNumero.Value;
                AggiornaTotale();
            }
        }

        private void repositoryItemSpinEditQta_EditValueChanged(object sender, EventArgs e)
        {
            this.treeListSingolo.PostEditor();
        }

        private void repositoryItemSpinEditQtaS_EditValueChanged(object sender, EventArgs e)
        {
            this.treeListScuola.PostEditor();
        }

        private void treeListScuola_DoubleClick(object sender, EventArgs e)
        {
            if (this.treeListScuola.FocusedNode.HasChildren) return;

            if (SafeInt(this.treeListScuola.FocusedNode[ColonnaQta]) == 0)
                this.treeListScuola.FocusedNode[ColonnaQta] = this.spinEditNumeroS.EditValue.ToString();
            else
                this.treeListScuola.FocusedNode[ColonnaQta] = string.Empty;

            AggiornaTotale();
        }

        private void treeListSingolo_DoubleClick(object sender, EventArgs e)
        {
            if (this.treeListSingolo.FocusedNode.HasChildren) return;

            if (SafeInt(this.treeListSingolo.FocusedNode[ColonnaQta]) == 0)
                this.treeListSingolo.FocusedNode[ColonnaQta] = this.spinEditNumero.EditValue.ToString();
            else
                this.treeListSingolo.FocusedNode[ColonnaQta] = string.Empty;

            AggiornaTotale();
        }
    }
}