using System;
using System.Collections.Generic;
using DevExpress.XtraBars;
using Musei.Module;
using DevExpress.XtraEditors;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;

namespace WinTicketNext
{
    public partial class RibbonFormNuovoTask : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonFormNuovoTask()
        {
            InitializeComponent();
        }

        private TaskGroup _taskGroup;
        public void Init(TaskGroup taskGroup)
        {
            _taskGroup = taskGroup;

            this.barButtonItemElimina.Links[0].Visible = true;
            this.barButtonItemSave.Links[0].Visible = true;
            this.barButtonItemUtilizza.Links[0].Visible = false;

            Init();
        }

        public void InitVendita(TaskGroup taskGroup)
        {
            _taskGroup = taskGroup;

            this.barButtonItemElimina.Links[0].Visible = false;
            this.barButtonItemSave.Links[0].Visible = false;
            this.barButtonItemUtilizza.Links[0].Visible = true;

            Init();
        }

        private void Init()
        {
            //this.lookUpEditIngresso.EditValue = this.unitOfWork1.GetObjectByKey<Ingresso>(_taskGroup.ResourceId);
            this.memoEditNote.Text = _taskGroup.Description;
            //this.dateEditData.DateTime = _taskGroup.Start.Date;
            //this.timeEditOra.Time = _taskGroup.Start;
            this.textEditSubject.Text = _taskGroup.Subject;
            this.spinEditPersone.Value = _taskGroup.Pax;
            this.spinEditAnticipo.Value = _taskGroup.Anticipo;
            this.checkEditUtilizzata.Checked = _taskGroup.Utilizzata;

            this.labelControlInfo.Text = String.Format("Prenotazione: {0}", _taskGroup.Codice);

            this.gridControl1.DataSource = _taskGroup.ElencoTask;
            this.gridView1.BestFitColumns();
        }

        private static int atype = new Random().Next(0, 11);
        private void barButtonItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (SaveChanges())
                DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                XtraMessageBox.Show("Esistono errori sulle prenotazioni", "Errore", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }

        private bool SaveChanges()
        {
            this.gridView1.CloseEditor();

            //_taskGroup.ResourceId = (this.lookUpEditIngresso.EditValue as Ingresso).Oid;
            _taskGroup.Description = this.memoEditNote.Text;
            //_taskGroup.Start = this.dateEditData.DateTime.Date + this.timeEditOra.Time.TimeOfDay;
            //_taskGroup.Finish = _task.Start.AddMinutes(30);
            //_taskGroup.Location = (this.lookUpEditIngresso.EditValue as Ingresso).Descrizione;
            _taskGroup.Subject = this.textEditSubject.Text;
            _taskGroup.Pax = (int)this.spinEditPersone.Value;
            _taskGroup.Anticipo = this.spinEditAnticipo.Value;
            _taskGroup.Utilizzata = this.checkEditUtilizzata.Checked;

            foreach (var item in _taskGroup.ElencoTask)
            {
                item.Label = atype;
                item.Finish = item.Start.AddMinutes(30);
                item.Subject = string.Format("{0} {1}", item.Pax, _taskGroup.Subject);
                item.Location = this.unitOfWork1.GetObjectByKey<Ingresso>(item.ResourceId).Descrizione;
            }

            atype++;
            if (atype == 11) atype = 0;

            _taskGroup.Save();

            // verifica ingressi
            foreach (var item in _taskGroup.ElencoTask)
            {
                Ingresso ingr = this.unitOfWork1.GetObjectByKey<Ingresso>(item.ResourceId);
                if (ingr.VerificaCalendario)
                {
                    GroupOperator criteria1 = new GroupOperator(GroupOperatorType.And);
                    criteria1.Operands.Add(new BinaryOperator("Ingresso.Oid", item.ResourceId));
                    criteria1.Operands.Add(new BinaryOperator("DataOra", item.Start));

                    IngressoCalendario calendario = this.unitOfWork1.FindObject<IngressoCalendario>(criteria1);
                    if (calendario != null)
                    {
                        GroupOperator criteria = new GroupOperator(GroupOperatorType.And);
                        criteria.Operands.Add(new BinaryOperator("ResourceId", item.ResourceId));
                        criteria.Operands.Add(new BinaryOperator("Start", item.Start));

                        XPCollection<Task> tcheck = new XPCollection<Task>(this.unitOfWork1, criteria);
                        tcheck.Criteria = criteria;

                        int totale = 0;
                        foreach (Task task in tcheck)
                        {
                            totale += task.Pax;
                        }
                        if (calendario.PaxMax < totale)
                        {
                            item.Status = 3;
                            item.Errore = true;
                            item.Save();
                            return false;
                        }
                    }
                    else
                    {
                        item.Status = 3;
                        item.Errore = true;
                        item.Save();
                        return false;
                    }
                }

                item.Status = 0;
                item.Errore = false;
                item.Save();
            }

            return true;
        }

        private void barButtonItemElimina_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Confermi l'eliminazione di questa prenotazione ?", "Conferma", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                _taskGroup.Delete();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void barButtonItemUtilizza_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (SaveChanges())
                DialogResult = System.Windows.Forms.DialogResult.Yes;
            else
                XtraMessageBox.Show("Esistono errori sulle prenotazioni", "Errore", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }

        private void spinEditPersone_EditValueChanged(object sender, EventArgs e)
        {
            foreach (var item in _taskGroup.ElencoTask)
                if (item.Pax == Task.PaxDefault)
                    item.Pax = (int)this.spinEditPersone.Value;

            Task.PaxDefault = (int)this.spinEditPersone.Value;
        }

        private void barButtonItemStampa_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}