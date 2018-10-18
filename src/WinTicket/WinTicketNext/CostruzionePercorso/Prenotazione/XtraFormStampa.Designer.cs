namespace WinTicketNext.CostruzionePercorso.GestionePrenotazione
{
    partial class XtraFormStampa
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControlInfo1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonOk = new DevExpress.XtraEditors.SimpleButton();
            this.labelControlInfo2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControlInfo3 = new DevExpress.XtraEditors.LabelControl();
            this.unitOfWork1 = new DevExpress.Xpo.UnitOfWork(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControlPrevent = new DevExpress.XtraEditors.LabelControl();
            this.labelControlRiferimento = new DevExpress.XtraEditors.LabelControl();
            this.textEditRiferimento = new DevExpress.XtraEditors.TextEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControlValidita = new DevExpress.XtraEditors.LabelControl();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.checkEditContanti = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditPos = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.buttonEditProvenienza = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControlProvenienza = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditRiferimento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditContanti.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditPos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditProvenienza.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::WinTicketNext.Properties.Resources.printer2;
            this.pictureEdit1.Location = new System.Drawing.Point(12, 12);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ReadOnly = true;
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Size = new System.Drawing.Size(141, 149);
            this.pictureEdit1.TabIndex = 0;
            // 
            // labelControlInfo1
            // 
            this.labelControlInfo1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlInfo1.Location = new System.Drawing.Point(5, 23);
            this.labelControlInfo1.Name = "labelControlInfo1";
            this.labelControlInfo1.Size = new System.Drawing.Size(97, 16);
            this.labelControlInfo1.TabIndex = 1;
            this.labelControlInfo1.Text = "Totale biglietti: 4";
            // 
            // simpleButtonOk
            // 
            this.simpleButtonOk.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonOk.Appearance.Options.UseFont = true;
            this.simpleButtonOk.Appearance.Options.UseTextOptions = true;
            this.simpleButtonOk.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.simpleButtonOk.Image = global::WinTicketNext.Properties.Resources.check;
            this.simpleButtonOk.Location = new System.Drawing.Point(331, 286);
            this.simpleButtonOk.Name = "simpleButtonOk";
            this.simpleButtonOk.Size = new System.Drawing.Size(123, 100);
            this.simpleButtonOk.TabIndex = 2;
            this.simpleButtonOk.Text = "Conferma && Stampa";
            this.simpleButtonOk.Click += new System.EventHandler(this.simpleButtonOk_Click);
            // 
            // labelControlInfo2
            // 
            this.labelControlInfo2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlInfo2.Location = new System.Drawing.Point(5, 45);
            this.labelControlInfo2.Name = "labelControlInfo2";
            this.labelControlInfo2.Size = new System.Drawing.Size(118, 16);
            this.labelControlInfo2.TabIndex = 3;
            this.labelControlInfo2.Text = "Numero persone: 44";
            // 
            // labelControlInfo3
            // 
            this.labelControlInfo3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlInfo3.Location = new System.Drawing.Point(5, 67);
            this.labelControlInfo3.Name = "labelControlInfo3";
            this.labelControlInfo3.Size = new System.Drawing.Size(152, 16);
            this.labelControlInfo3.TabIndex = 4;
            this.labelControlInfo3.Text = "Importo totale: euro 10,00";
            // 
            // unitOfWork1
            // 
            this.unitOfWork1.TrackPropertiesModifications = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControlPrevent);
            this.groupControl1.Controls.Add(this.labelControlRiferimento);
            this.groupControl1.Controls.Add(this.textEditRiferimento);
            this.groupControl1.Location = new System.Drawing.Point(159, 136);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(295, 80);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Prenotazione";
            // 
            // labelControlPrevent
            // 
            this.labelControlPrevent.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlPrevent.Location = new System.Drawing.Point(5, 53);
            this.labelControlPrevent.Name = "labelControlPrevent";
            this.labelControlPrevent.Size = new System.Drawing.Size(69, 16);
            this.labelControlPrevent.TabIndex = 2;
            this.labelControlPrevent.Text = "Info prevent";
            // 
            // labelControlRiferimento
            // 
            this.labelControlRiferimento.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlRiferimento.Location = new System.Drawing.Point(5, 27);
            this.labelControlRiferimento.Name = "labelControlRiferimento";
            this.labelControlRiferimento.Size = new System.Drawing.Size(71, 16);
            this.labelControlRiferimento.TabIndex = 1;
            this.labelControlRiferimento.Text = "Riferimento:";
            // 
            // textEditRiferimento
            // 
            this.textEditRiferimento.Location = new System.Drawing.Point(90, 26);
            this.textEditRiferimento.Name = "textEditRiferimento";
            this.textEditRiferimento.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditRiferimento.Properties.Appearance.Options.UseFont = true;
            this.textEditRiferimento.Size = new System.Drawing.Size(200, 22);
            this.textEditRiferimento.TabIndex = 0;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.textEditRiferimento, conditionValidationRule1);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.labelControlValidita);
            this.groupControl2.Controls.Add(this.labelControlInfo2);
            this.groupControl2.Controls.Add(this.labelControlInfo1);
            this.groupControl2.Controls.Add(this.labelControlInfo3);
            this.groupControl2.Location = new System.Drawing.Point(159, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(295, 118);
            this.groupControl2.TabIndex = 6;
            this.groupControl2.Text = "Biglietti";
            // 
            // labelControlValidita
            // 
            this.labelControlValidita.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlValidita.Location = new System.Drawing.Point(5, 89);
            this.labelControlValidita.Name = "labelControlValidita";
            this.labelControlValidita.Size = new System.Drawing.Size(207, 16);
            this.labelControlValidita.TabIndex = 5;
            this.labelControlValidita.Text = "Valido: dal xx/yy/aaaa al xx/yy/aaaa";
            // 
            // checkEditContanti
            // 
            this.checkEditContanti.Location = new System.Drawing.Point(5, 24);
            this.checkEditContanti.Name = "checkEditContanti";
            this.checkEditContanti.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEditContanti.Properties.Appearance.Options.UseFont = true;
            this.checkEditContanti.Properties.Caption = "Incasso in contanti";
            this.checkEditContanti.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.checkEditContanti.Properties.RadioGroupIndex = 1;
            this.checkEditContanti.Size = new System.Drawing.Size(202, 21);
            this.checkEditContanti.TabIndex = 7;
            this.checkEditContanti.TabStop = false;
            // 
            // checkEditPos
            // 
            this.checkEditPos.Location = new System.Drawing.Point(296, 24);
            this.checkEditPos.Name = "checkEditPos";
            this.checkEditPos.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEditPos.Properties.Appearance.Options.UseFont = true;
            this.checkEditPos.Properties.Caption = "Incasso tramite POS";
            this.checkEditPos.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.checkEditPos.Properties.RadioGroupIndex = 1;
            this.checkEditPos.Size = new System.Drawing.Size(141, 21);
            this.checkEditPos.TabIndex = 8;
            this.checkEditPos.TabStop = false;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.checkEditContanti);
            this.groupControl3.Controls.Add(this.checkEditPos);
            this.groupControl3.Location = new System.Drawing.Point(12, 222);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(442, 58);
            this.groupControl3.TabIndex = 9;
            this.groupControl3.Text = "Incasso";
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.labelControlProvenienza);
            this.groupControl4.Controls.Add(this.labelControl1);
            this.groupControl4.Controls.Add(this.buttonEditProvenienza);
            this.groupControl4.Location = new System.Drawing.Point(12, 286);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(304, 100);
            this.groupControl4.TabIndex = 10;
            this.groupControl4.Text = "Provenienza Visitatori";
            // 
            // buttonEditProvenienza
            // 
            this.buttonEditProvenienza.Location = new System.Drawing.Point(119, 24);
            this.buttonEditProvenienza.Name = "buttonEditProvenienza";
            this.buttonEditProvenienza.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditProvenienza.Properties.Appearance.Options.UseFont = true;
            this.buttonEditProvenienza.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Close)});
            this.buttonEditProvenienza.Size = new System.Drawing.Size(180, 22);
            this.buttonEditProvenienza.TabIndex = 0;
            this.buttonEditProvenienza.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditProvenienza_ButtonClick);
            this.buttonEditProvenienza.EditValueChanged += new System.EventHandler(this.buttonEditProvenienza_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(7, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(106, 16);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "CAP / City / Nation";
            // 
            // labelControlProvenienza
            // 
            this.labelControlProvenienza.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlProvenienza.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControlProvenienza.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlProvenienza.Location = new System.Drawing.Point(7, 52);
            this.labelControlProvenienza.Name = "labelControlProvenienza";
            this.labelControlProvenienza.Size = new System.Drawing.Size(292, 43);
            this.labelControlProvenienza.TabIndex = 2;
            this.labelControlProvenienza.Text = ".";
            // 
            // XtraFormStampa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 399);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.simpleButtonOk);
            this.Controls.Add(this.pictureEdit1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XtraFormStampa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stampa";
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditRiferimento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditContanti.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditPos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditProvenienza.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControlInfo1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOk;
        private DevExpress.XtraEditors.LabelControl labelControlInfo2;
        private DevExpress.XtraEditors.LabelControl labelControlInfo3;
        private DevExpress.Xpo.UnitOfWork unitOfWork1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControlRiferimento;
        private DevExpress.XtraEditors.TextEdit textEditRiferimento;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControlPrevent;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.CheckEdit checkEditContanti;
        private DevExpress.XtraEditors.CheckEdit checkEditPos;
        private DevExpress.XtraEditors.LabelControl labelControlValidita;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.ButtonEdit buttonEditProvenienza;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControlProvenienza;
    }
}