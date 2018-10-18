using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Xpo;
using Musei.Module;
using DevExpress.Data.Filtering;

namespace WinTicketNext.CostruzionePercorso
{
    public partial class RibbonFormAskBonus : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private UnitOfWork _UnitOfWork;
        private GestoreProfili _GestoreProfili;
        private CodiceSconto _CodiceSconto;
        //private ProfiloCliente _Profilo;
        
        public RibbonFormAskBonus()
        {
            InitializeComponent();
        }

        private void timerTick_Tick(object sender, EventArgs e)
        {
            if (!this.buttonEditCodice.EditorContainsFocus)
                this.buttonEditCodice.Focus();
        }

        internal void Init(UnitOfWork unitOfWork, GestoreProfili gestoreProfili)
        {
            //_Profilo = profilo;
            _GestoreProfili = gestoreProfili;
            _UnitOfWork = unitOfWork;

            if (_GestoreProfili.ElencoCodiciSconto.Count > 0)
                _CodiceSconto = _GestoreProfili.ElencoCodiciSconto[0];
            else
                _CodiceSconto = null;

            UpdateInfo();
        }

        private void UpdateInfo()
        {
            if (_CodiceSconto == null)
            {
                this.textEditDisplayBonus.Text = "-- nessun codice sconto --";
                this.labelControlInfoText.Text = "";
                this.simpleButtonRemove.Enabled = false;
            }
            else
            {
                this.textEditDisplayBonus.Text = String.Format("{0} ({1})", _CodiceSconto.Descrizione, _CodiceSconto.Codice);
                this.labelControlInfoText.Text = String.Format("ATTENZIONE: il codice sconto verrà applicato a tutta la vendita ({0} pax)", _GestoreProfili.TotalePersone());
                this.simpleButtonRemove.Enabled = true;
            }
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            _GestoreProfili.SetCodiceSconto(_CodiceSconto);

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void simpleButtonRemove_Click(object sender, EventArgs e)
        {
            _CodiceSconto = null;
            UpdateInfo();
        }

        private void SetCodiceSconto(CodiceSconto codice)
        {
            this.labelControlSearchResult.Text = String.Format("Risultato ricerca: {0} ({1})", codice.Descrizione, codice.Codice);
            _CodiceSconto = codice;
        }

        private void simpleButtonCheck_Click(object sender, EventArgs e)
        {
            Cursor saveCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string str = this.buttonEditCodice.Text.Trim();

                CodiceSconto codice = _UnitOfWork.FindObject<CodiceSconto>(new BinaryOperator("Codice", str));
                if (codice != null)
                {
                    SetCodiceSconto(codice);
                }
                else
                {
                    // cerca 
                    var str1 = String.Format("%{0}", str);
                    codice = _UnitOfWork.FindObject<CodiceSconto>(new BinaryOperator("Codice", str1, BinaryOperatorType.Like));
                    if (codice != null)
                    {
                        SetCodiceSconto(codice);
                    }
                    else
                    {
                        var str2 = String.Format("%{0}%", str);
                        codice = _UnitOfWork.FindObject<CodiceSconto>(new BinaryOperator("Descrizione", str2, BinaryOperatorType.Like));
                        if (codice != null)
                        {
                            SetCodiceSconto(codice);
                        }
                        else
                            this.labelControlSearchResult.Text = string.Format("Codice {0} NON trovato!", str);
                    }
                }

                UpdateInfo();
            }
            finally
            {
                Cursor.Current = saveCursor;
            }
        }
    }
}