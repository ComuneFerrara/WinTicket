namespace WinTicketNext.Storico.RepVersamenti
{
    partial class XtraFormReportQ1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioGroupPeriodo = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonStampa = new DevExpress.XtraEditors.SimpleButton();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.unitOfWork1 = new DevExpress.Xpo.UnitOfWork();
            this.xpCollection1 = new DevExpress.Xpo.XPCollection();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // radioGroupPeriodo
            // 
            this.radioGroupPeriodo.EditValue = 3;
            this.radioGroupPeriodo.Location = new System.Drawing.Point(73, 27);
            this.radioGroupPeriodo.Name = "radioGroupPeriodo";
            this.radioGroupPeriodo.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "Trimestrale"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(12, "Annuale")});
            this.radioGroupPeriodo.Size = new System.Drawing.Size(100, 75);
            this.radioGroupPeriodo.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Periodo:";
            // 
            // simpleButtonStampa
            // 
            this.simpleButtonStampa.Location = new System.Drawing.Point(250, 215);
            this.simpleButtonStampa.Name = "simpleButtonStampa";
            this.simpleButtonStampa.Size = new System.Drawing.Size(86, 34);
            this.simpleButtonStampa.TabIndex = 2;
            this.simpleButtonStampa.Text = "Stampa";
            this.simpleButtonStampa.Click += new System.EventHandler(this.simpleButtonStampa_Click);
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(73, 133);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RagioneSociale", "RagioneSociale", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.lookUpEdit1.Properties.DataSource = this.xpCollection1;
            this.lookUpEdit1.Properties.DisplayMember = "RagioneSociale";
            this.lookUpEdit1.Properties.NullText = "";
            this.lookUpEdit1.Properties.ValueMember = "This";
            this.lookUpEdit1.Size = new System.Drawing.Size(263, 20);
            this.lookUpEdit1.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 136);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(26, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Ente:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(73, 159);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(172, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "non selezionare se si vuole il proprio";
            // 
            // xpCollection1
            // 
            this.xpCollection1.ObjectType = typeof(Musei.Module.SoggettoEconomico);
            this.xpCollection1.Session = this.unitOfWork1;
            // 
            // XtraFormReportQ1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 261);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lookUpEdit1);
            this.Controls.Add(this.simpleButtonStampa);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.radioGroupPeriodo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XtraFormReportQ1";
            this.Text = "Report Agente Contabile Q1";
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollection1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup radioGroupPeriodo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonStampa;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.Xpo.UnitOfWork unitOfWork1;
        private DevExpress.Xpo.XPCollection xpCollection1;
    }
}