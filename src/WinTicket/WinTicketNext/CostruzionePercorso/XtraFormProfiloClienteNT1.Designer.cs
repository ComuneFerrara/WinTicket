namespace WinTicketNext.CostruzionePercorso
{
    partial class XtraFormProfiloClienteNT1
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditNumero = new DevExpress.XtraEditors.SpinEdit();
            this.treeListScuola = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.simpleButtonOk = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonDelete = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonMeno = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonPiu = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.treeListSingolo = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.checkEditScuola = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditNumero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListScuola)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListSingolo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditScuola.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(271, 55);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 19);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Persone:";
            // 
            // spinEditNumero
            // 
            this.spinEditNumero.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditNumero.Location = new System.Drawing.Point(388, 52);
            this.spinEditNumero.Name = "spinEditNumero";
            this.spinEditNumero.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinEditNumero.Properties.Appearance.Options.UseFont = true;
            this.spinEditNumero.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditNumero.Properties.IsFloatValue = false;
            this.spinEditNumero.Properties.Mask.EditMask = "N00";
            this.spinEditNumero.Properties.MaxValue = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.spinEditNumero.Size = new System.Drawing.Size(67, 26);
            this.spinEditNumero.TabIndex = 0;
            // 
            // treeListScuola
            // 
            this.treeListScuola.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3});
            this.treeListScuola.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListScuola.Location = new System.Drawing.Point(0, 0);
            this.treeListScuola.Name = "treeListScuola";
            this.treeListScuola.OptionsBehavior.AllowIndeterminateCheckState = true;
            this.treeListScuola.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeListScuola.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.treeListScuola.OptionsView.ShowCheckBoxes = true;
            this.treeListScuola.Size = new System.Drawing.Size(435, 382);
            this.treeListScuola.TabIndex = 3;
            this.treeListScuola.BeforeCheckNode += new DevExpress.XtraTreeList.CheckNodeEventHandler(this.treeList1_BeforeCheckNode);
            this.treeListScuola.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeListScuola_AfterCheckNode);
            this.treeListScuola.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.treeList1_CustomDrawNodeCell);
            this.treeListScuola.CustomDrawNodeCheckBox += new DevExpress.XtraTreeList.CustomDrawNodeCheckBoxEventHandler(this.treeList1_CustomDrawNodeCheckBox);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Elenco Titolarità";
            this.treeListColumn1.FieldName = "Elenco Titolarità";
            this.treeListColumn1.MinWidth = 32;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.treeListColumn1.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "Rid.";
            this.treeListColumn2.FieldName = "Ridotto";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowEdit = false;
            this.treeListColumn2.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "Oma.";
            this.treeListColumn3.FieldName = "Omaggio";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.OptionsColumn.AllowEdit = false;
            this.treeListColumn3.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 2;
            // 
            // simpleButtonOk
            // 
            this.simpleButtonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonOk.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonOk.Appearance.Options.UseFont = true;
            this.simpleButtonOk.Image = global::WinTicketNext.Properties.Resources.check;
            this.simpleButtonOk.Location = new System.Drawing.Point(461, 510);
            this.simpleButtonOk.Name = "simpleButtonOk";
            this.simpleButtonOk.Size = new System.Drawing.Size(100, 42);
            this.simpleButtonOk.TabIndex = 4;
            this.simpleButtonOk.Text = "OK";
            this.simpleButtonOk.Click += new System.EventHandler(this.simpleButtonOk_Click);
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonCancel.Appearance.Options.UseFont = true;
            this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButtonCancel.Image = global::WinTicketNext.Properties.Resources.sign_stop;
            this.simpleButtonCancel.Location = new System.Drawing.Point(612, 510);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(100, 42);
            this.simpleButtonCancel.TabIndex = 5;
            this.simpleButtonCancel.Text = "Cancel";
            // 
            // simpleButtonDelete
            // 
            this.simpleButtonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonDelete.Image = global::WinTicketNext.Properties.Resources.delete;
            this.simpleButtonDelete.Location = new System.Drawing.Point(629, 48);
            this.simpleButtonDelete.Name = "simpleButtonDelete";
            this.simpleButtonDelete.Size = new System.Drawing.Size(82, 42);
            this.simpleButtonDelete.TabIndex = 6;
            this.simpleButtonDelete.Text = "Elimina";
            this.simpleButtonDelete.Click += new System.EventHandler(this.simpleButtonDelete_Click);
            // 
            // simpleButtonMeno
            // 
            this.simpleButtonMeno.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonMeno.Appearance.Options.UseFont = true;
            this.simpleButtonMeno.Location = new System.Drawing.Point(351, 46);
            this.simpleButtonMeno.Name = "simpleButtonMeno";
            this.simpleButtonMeno.Size = new System.Drawing.Size(31, 42);
            this.simpleButtonMeno.TabIndex = 7;
            this.simpleButtonMeno.Text = "-";
            this.simpleButtonMeno.Click += new System.EventHandler(this.simpleButtonMeno_Click);
            // 
            // simpleButtonPiu
            // 
            this.simpleButtonPiu.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonPiu.Appearance.Options.UseFont = true;
            this.simpleButtonPiu.Location = new System.Drawing.Point(461, 46);
            this.simpleButtonPiu.Name = "simpleButtonPiu";
            this.simpleButtonPiu.Size = new System.Drawing.Size(31, 42);
            this.simpleButtonPiu.TabIndex = 8;
            this.simpleButtonPiu.Text = "+";
            this.simpleButtonPiu.Click += new System.EventHandler(this.simpleButtonPiu_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(271, 96);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(441, 408);
            this.xtraTabControl1.TabIndex = 10;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            this.xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.treeListScuola);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(435, 382);
            this.xtraTabPage1.Text = "Scuole";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.treeListSingolo);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(435, 382);
            this.xtraTabPage2.Text = "Singoli e Gruppi";
            // 
            // treeListSingolo
            // 
            this.treeListSingolo.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn4,
            this.treeListColumn5,
            this.treeListColumn6});
            this.treeListSingolo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListSingolo.Location = new System.Drawing.Point(0, 0);
            this.treeListSingolo.Name = "treeListSingolo";
            this.treeListSingolo.OptionsBehavior.AllowIndeterminateCheckState = true;
            this.treeListSingolo.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeListSingolo.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.treeListSingolo.OptionsView.ShowCheckBoxes = true;
            this.treeListSingolo.Size = new System.Drawing.Size(435, 382);
            this.treeListSingolo.TabIndex = 4;
            this.treeListSingolo.BeforeCheckNode += new DevExpress.XtraTreeList.CheckNodeEventHandler(this.treeList1_BeforeCheckNode);
            this.treeListSingolo.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeListSingolo_AfterCheckNode);
            this.treeListSingolo.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.treeList1_CustomDrawNodeCell);
            this.treeListSingolo.CustomDrawNodeCheckBox += new DevExpress.XtraTreeList.CustomDrawNodeCheckBoxEventHandler(this.treeList1_CustomDrawNodeCheckBox);
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "Elenco Titolarità";
            this.treeListColumn4.FieldName = "Elenco Titolarità";
            this.treeListColumn4.MinWidth = 32;
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.OptionsColumn.AllowEdit = false;
            this.treeListColumn4.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.treeListColumn4.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 0;
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.Caption = "Rid.";
            this.treeListColumn5.FieldName = "Ridotto";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.OptionsColumn.AllowEdit = false;
            this.treeListColumn5.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 1;
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.Caption = "Oma.";
            this.treeListColumn6.FieldName = "Omaggio";
            this.treeListColumn6.Name = "treeListColumn6";
            this.treeListColumn6.OptionsColumn.AllowEdit = false;
            this.treeListColumn6.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            this.treeListColumn6.Visible = true;
            this.treeListColumn6.VisibleIndex = 2;
            // 
            // checkEditScuola
            // 
            this.checkEditScuola.Location = new System.Drawing.Point(269, 12);
            this.checkEditScuola.Name = "checkEditScuola";
            this.checkEditScuola.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEditScuola.Properties.Appearance.Options.UseFont = true;
            this.checkEditScuola.Properties.Caption = "Abilita profilo SCUOLA";
            this.checkEditScuola.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.checkEditScuola.Properties.PictureChecked = global::WinTicketNext.Properties.Resources.checkbox;
            this.checkEditScuola.Properties.PictureUnchecked = global::WinTicketNext.Properties.Resources.checkbox_unchecked;
            this.checkEditScuola.Size = new System.Drawing.Size(312, 28);
            this.checkEditScuola.TabIndex = 11;
            this.checkEditScuola.CheckedChanged += new System.EventHandler(this.checkEditScuola_CheckedChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Image = global::WinTicketNext.Properties.Resources.about;
            this.labelControl2.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.labelControl2.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.labelControl2.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Horizontal;
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 510);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(443, 50);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "A tutte le persone indicate vengono assegnati tutti i titoli di ingresso selezion" +
    "ati.";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureEdit1.EditValue = global::WinTicketNext.Properties.Resources.BigliettoNT1;
            this.pictureEdit1.Location = new System.Drawing.Point(2, 14);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.PictureAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.pictureEdit1.Properties.ReadOnly = true;
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Size = new System.Drawing.Size(263, 546);
            this.pictureEdit1.TabIndex = 14;
            // 
            // XtraFormProfiloClienteNT1
            // 
            this.AcceptButton = this.simpleButtonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.simpleButtonCancel;
            this.ClientSize = new System.Drawing.Size(724, 564);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.checkEditScuola);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.simpleButtonPiu);
            this.Controls.Add(this.simpleButtonMeno);
            this.Controls.Add(this.simpleButtonDelete);
            this.Controls.Add(this.simpleButtonCancel);
            this.Controls.Add(this.simpleButtonOk);
            this.Controls.Add(this.spinEditNumero);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XtraFormProfiloClienteNT1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Profilo";
            this.Activated += new System.EventHandler(this.XtraFormProfiloCliente_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.spinEditNumero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListScuola)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListSingolo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditScuola.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SpinEdit spinEditNumero;
        private DevExpress.XtraTreeList.TreeList treeListScuola;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOk;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonDelete;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonMeno;
        private DevExpress.XtraEditors.SimpleButton simpleButtonPiu;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.CheckEdit checkEditScuola;
        private DevExpress.XtraTreeList.TreeList treeListSingolo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}