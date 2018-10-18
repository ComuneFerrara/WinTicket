using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Xpo;
using Musei.Module;
using DevExpress.XtraTreeList.Nodes;

namespace WinTicketNext.CostruzionePercorso
{
    public partial class XtraFormProfiloClienteNT1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormProfiloClienteNT1()
        {
            InitializeComponent();
        }

        private GestoreTitoli m_GestoreTitoliSingoliGruppi;
        private GestoreTitoli m_GestoreTitoliScuole;
        private ProfiloCliente m_Profilo;
        private GestoreProfili m_GestoreProfili;
        public void Init(UnitOfWork session, List<Ingresso> percorso, ProfiloCliente profilo, GestoreProfili gestore)
        {
            m_Profilo = profilo;
            m_GestoreProfili = gestore;

            m_GestoreTitoliSingoliGruppi = new GestoreTitoli(session);
            m_GestoreTitoliSingoliGruppi.ReBuildElencoTitoli(percorso, false, this.treeListSingolo);
            m_GestoreTitoliSingoliGruppi.ApplyElencoTitoli(m_Profilo.ElencoTitoli, this.treeListSingolo);

            m_GestoreTitoliScuole = new GestoreTitoli(session);
            m_GestoreTitoliScuole.ReBuildElencoTitoli(percorso, true, this.treeListScuola);
            m_GestoreTitoliScuole.ApplyElencoTitoli(m_Profilo.ElencoTitoli, this.treeListScuola);

            this.spinEditNumero.Value = m_Profilo.NumeroPersone;
            this.simpleButtonDelete.Enabled = m_GestoreProfili.ElencoProfili.Contains(m_Profilo);

            this.checkEditScuola.Checked = m_Profilo.Scuola;
            checkEditScuola_CheckedChanged(null, null);

            SetupAlbero();
        }

        private void SetupAlbero()
        {
            foreach (TreeListNode treeListNode in this.treeListScuola.Nodes)
            {
                if (treeListNode.HasChildren)
                {
                    foreach (TreeListNode item in treeListNode.Nodes)
                    {
                        if (item.Checked)
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
                        if (item.Checked)
                            treeListNode.ExpandAll();
                    }
                }
            }
        }

        private void treeList1_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            if (e.Node.HasChildren)
            {
                e.CanCheck = false;
            }
            else
                e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
        }

        private void treeList1_CustomDrawNodeCheckBox(object sender, DevExpress.XtraTreeList.CustomDrawNodeCheckBoxEventArgs e)
        {
            if (e.Node.HasChildren)
                e.Handled = true;
        }

        private void treeList1_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            if (e.Node.Checked)
            {
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                e.Appearance.ForeColor = Color.Red;
            }

            if (e.Node.HasChildren)
            {
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Regular);
                foreach (TreeListNode item in e.Node.Nodes)
                {
                    if (item.Checked)
                    {
                        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                        e.Appearance.ForeColor = Color.Red;
                        break;
                    }
                }
            }
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            List<Titolo> titoli = new List<Titolo>();
            foreach (TreeListNode treeListNode in this.treeListScuola.Nodes)
            {
                if (treeListNode.Checked)
                    titoli.Add((Titolo)treeListNode.Tag);
                if (treeListNode.HasChildren)
                    CheckChildrens(treeListNode, titoli);
            }
            foreach (TreeListNode treeListNode in this.treeListSingolo.Nodes)
            {
                if (treeListNode.Checked)
                    titoli.Add((Titolo)treeListNode.Tag);
                if (treeListNode.HasChildren)
                    CheckChildrens(treeListNode, titoli);
            }

            m_Profilo.ElencoTitoli = titoli;
            m_Profilo.NumeroPersone = (int)this.spinEditNumero.Value;
            m_Profilo.Scuola = this.checkEditScuola.Checked;

            DialogResult = DialogResult.OK;
        }

        private void CheckChildrens(TreeListNode treeListNode, List<Titolo> titoli)
        {
            foreach (TreeListNode nodo in treeListNode.Nodes)
            {
                if (nodo.Checked)
                    titoli.Add((Titolo)nodo.Tag);
                if (nodo.HasChildren)
                    CheckChildrens(nodo, titoli);
            }            
        }

        private void simpleButtonMeno_Click(object sender, EventArgs e)
        {
            if (this.spinEditNumero.Value > 1)
                this.spinEditNumero.Value -= 1;
        }

        private void simpleButtonPiu_Click(object sender, EventArgs e)
        {
            if (this.spinEditNumero.Value < 999)
                this.spinEditNumero.Value += 1;
        }

        private void simpleButtonDelete_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Confermi di rimuovere questo profilo ?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                m_GestoreProfili.ElencoProfili.Remove(m_Profilo);
                DialogResult = DialogResult.OK;
            }
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
            }
            else
            {
                if (this.xtraTabControl1.TabPages.Contains(this.xtraTabPage1))
                    this.xtraTabControl1.TabPages.Remove(this.xtraTabPage1);
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            this.treeListScuola.BestFitColumns();
            this.treeListSingolo.BestFitColumns();
        }

        private void treeListScuola_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            List<Titolo> titoli = new List<Titolo>();
            foreach (TreeListNode treeListNode in this.treeListScuola.Nodes)
            {
                if (treeListNode.Checked)
                    titoli.Add((Titolo)treeListNode.Tag);
                if (treeListNode.HasChildren)
                    CheckChildrens(treeListNode, titoli);
            }

            if (titoli.Count > 0)
            {
                this.xtraTabPage1.Appearance.Header.Font = new Font(this.xtraTabPage1.Appearance.Header.Font, FontStyle.Bold);
            }
            else
            {
                this.xtraTabPage1.Appearance.Header.Font = new Font(this.xtraTabPage1.Appearance.Header.Font, FontStyle.Regular);
            }
        }

        private void treeListSingolo_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            List<Titolo> titoli = new List<Titolo>();
            foreach (TreeListNode treeListNode in this.treeListSingolo.Nodes)
            {
                if (treeListNode.Checked)
                    titoli.Add((Titolo)treeListNode.Tag);
                if (treeListNode.HasChildren)
                    CheckChildrens(treeListNode, titoli);
            }

            if (titoli.Count > 0)
            {
                this.xtraTabPage2.Appearance.Header.Font = new Font(this.xtraTabPage2.Appearance.Header.Font, FontStyle.Bold);
            }
            else
            {
                this.xtraTabPage2.Appearance.Header.Font = new Font(this.xtraTabPage2.Appearance.Header.Font, FontStyle.Regular);
            }
        }

    }
}