namespace WinTicketNext.CostruzionePercorso.GestionePrenotazione
{
    partial class XtraUserControlCalendario2
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraUserControlCalendario2));
            this.simpleButtonCrea = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlPrenotazioni = new DevExpress.XtraGrid.GridControl();
            this.gridViewPrenotazioni = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAppointmentType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLabel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageCollectionLabel = new DevExpress.Utils.ImageCollection(this.components);
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumeroPersone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timerTick = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPrenotazioni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPrenotazioni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionLabel)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButtonCrea
            // 
            this.simpleButtonCrea.Location = new System.Drawing.Point(3, 3);
            this.simpleButtonCrea.Name = "simpleButtonCrea";
            this.simpleButtonCrea.Size = new System.Drawing.Size(118, 54);
            this.simpleButtonCrea.TabIndex = 1;
            this.simpleButtonCrea.Text = "Crea Prenotazioni";
            this.simpleButtonCrea.Click += new System.EventHandler(this.simpleButtonCrea_Click);
            // 
            // gridControlPrenotazioni
            // 
            this.gridControlPrenotazioni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPrenotazioni.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControlPrenotazioni.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControlPrenotazioni.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControlPrenotazioni.EmbeddedNavigator.Buttons.First.Visible = false;
            this.gridControlPrenotazioni.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.gridControlPrenotazioni.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gridControlPrenotazioni.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gridControlPrenotazioni.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridControlPrenotazioni_EmbeddedNavigator_ButtonClick);
            this.gridControlPrenotazioni.Location = new System.Drawing.Point(0, 0);
            this.gridControlPrenotazioni.MainView = this.gridViewPrenotazioni;
            this.gridControlPrenotazioni.Name = "gridControlPrenotazioni";
            this.gridControlPrenotazioni.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemImageComboBox1});
            this.gridControlPrenotazioni.ShowOnlyPredefinedDetails = true;
            this.gridControlPrenotazioni.Size = new System.Drawing.Size(675, 261);
            this.gridControlPrenotazioni.TabIndex = 0;
            this.gridControlPrenotazioni.UseEmbeddedNavigator = true;
            this.gridControlPrenotazioni.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPrenotazioni});
            this.gridControlPrenotazioni.DoubleClick += new System.EventHandler(this.gridControlPrenotazioni_DoubleClick);
            // 
            // gridViewPrenotazioni
            // 
            this.gridViewPrenotazioni.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewPrenotazioni.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewPrenotazioni.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gridViewPrenotazioni.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridViewPrenotazioni.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridViewPrenotazioni.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridViewPrenotazioni.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridViewPrenotazioni.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridViewPrenotazioni.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridViewPrenotazioni.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridViewPrenotazioni.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridViewPrenotazioni.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridViewPrenotazioni.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewPrenotazioni.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridViewPrenotazioni.Appearance.Empty.Options.UseBackColor = true;
            this.gridViewPrenotazioni.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridViewPrenotazioni.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridViewPrenotazioni.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewPrenotazioni.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridViewPrenotazioni.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridViewPrenotazioni.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridViewPrenotazioni.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridViewPrenotazioni.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridViewPrenotazioni.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gridViewPrenotazioni.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridViewPrenotazioni.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridViewPrenotazioni.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridViewPrenotazioni.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewPrenotazioni.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridViewPrenotazioni.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridViewPrenotazioni.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridViewPrenotazioni.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridViewPrenotazioni.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(114)))), ((int)(((byte)(113)))));
            this.gridViewPrenotazioni.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridViewPrenotazioni.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridViewPrenotazioni.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridViewPrenotazioni.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridViewPrenotazioni.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridViewPrenotazioni.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(192)))), ((int)(((byte)(157)))));
            this.gridViewPrenotazioni.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(219)))), ((int)(((byte)(188)))));
            this.gridViewPrenotazioni.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewPrenotazioni.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewPrenotazioni.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridViewPrenotazioni.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewPrenotazioni.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridViewPrenotazioni.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridViewPrenotazioni.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridViewPrenotazioni.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridViewPrenotazioni.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridViewPrenotazioni.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridViewPrenotazioni.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridViewPrenotazioni.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridViewPrenotazioni.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridViewPrenotazioni.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridViewPrenotazioni.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewPrenotazioni.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewPrenotazioni.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridViewPrenotazioni.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridViewPrenotazioni.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridViewPrenotazioni.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridViewPrenotazioni.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            this.gridViewPrenotazioni.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridViewPrenotazioni.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridViewPrenotazioni.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridViewPrenotazioni.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridViewPrenotazioni.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewPrenotazioni.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewPrenotazioni.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewPrenotazioni.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridViewPrenotazioni.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridViewPrenotazioni.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridViewPrenotazioni.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridViewPrenotazioni.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridViewPrenotazioni.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridViewPrenotazioni.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridViewPrenotazioni.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridViewPrenotazioni.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewPrenotazioni.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridViewPrenotazioni.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridViewPrenotazioni.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewPrenotazioni.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridViewPrenotazioni.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridViewPrenotazioni.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridViewPrenotazioni.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridViewPrenotazioni.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridViewPrenotazioni.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridViewPrenotazioni.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridViewPrenotazioni.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewPrenotazioni.Appearance.OddRow.Options.UseBackColor = true;
            this.gridViewPrenotazioni.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridViewPrenotazioni.Appearance.OddRow.Options.UseForeColor = true;
            this.gridViewPrenotazioni.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.gridViewPrenotazioni.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridViewPrenotazioni.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.gridViewPrenotazioni.Appearance.Preview.Options.UseBackColor = true;
            this.gridViewPrenotazioni.Appearance.Preview.Options.UseFont = true;
            this.gridViewPrenotazioni.Appearance.Preview.Options.UseForeColor = true;
            this.gridViewPrenotazioni.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridViewPrenotazioni.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridViewPrenotazioni.Appearance.Row.Options.UseBackColor = true;
            this.gridViewPrenotazioni.Appearance.Row.Options.UseForeColor = true;
            this.gridViewPrenotazioni.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridViewPrenotazioni.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridViewPrenotazioni.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridViewPrenotazioni.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(215)))), ((int)(((byte)(188)))));
            this.gridViewPrenotazioni.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridViewPrenotazioni.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewPrenotazioni.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewPrenotazioni.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.gridViewPrenotazioni.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridViewPrenotazioni.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridViewPrenotazioni.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridViewPrenotazioni.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridViewPrenotazioni.Appearance.VertLine.Options.UseBackColor = true;
            this.gridViewPrenotazioni.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAppointmentType,
            this.colStartDate,
            this.colEndDate,
            this.colSubject,
            this.colLocation,
            this.colDescription,
            this.colStatus,
            this.colLabel,
            this.gridColumn2,
            this.colNumeroPersone});
            this.gridViewPrenotazioni.GridControl = this.gridControlPrenotazioni;
            this.gridViewPrenotazioni.Name = "gridViewPrenotazioni";
            this.gridViewPrenotazioni.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewPrenotazioni.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewPrenotazioni.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewPrenotazioni.OptionsView.ShowGroupPanel = false;
            // 
            // colAppointmentType
            // 
            this.colAppointmentType.Caption = "AppointmentType";
            this.colAppointmentType.FieldName = "AppointmentType";
            this.colAppointmentType.Name = "colAppointmentType";
            this.colAppointmentType.OptionsColumn.AllowEdit = false;
            // 
            // colStartDate
            // 
            this.colStartDate.Caption = "StartDate";
            this.colStartDate.ColumnEdit = this.repositoryItemDateEdit1;
            this.colStartDate.DisplayFormat.FormatString = "g";
            this.colStartDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colStartDate.FieldName = "StartDate";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.OptionsColumn.AllowEdit = false;
            this.colStartDate.OptionsColumn.FixedWidth = true;
            this.colStartDate.Visible = true;
            this.colStartDate.VisibleIndex = 2;
            this.colStartDate.Width = 110;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.DisplayFormat.FormatString = "g";
            this.repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.EditFormat.FormatString = "g";
            this.repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.Mask.EditMask = "g";
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemDateEdit1.VistaTimeProperties.DisplayFormat.FormatString = "g";
            this.repositoryItemDateEdit1.VistaTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.VistaTimeProperties.EditFormat.FormatString = "g";
            this.repositoryItemDateEdit1.VistaTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.VistaTimeProperties.Mask.EditMask = "g";
            // 
            // colEndDate
            // 
            this.colEndDate.Caption = "EndDate";
            this.colEndDate.DisplayFormat.FormatString = "g";
            this.colEndDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colEndDate.FieldName = "EndDate";
            this.colEndDate.Name = "colEndDate";
            this.colEndDate.OptionsColumn.AllowEdit = false;
            this.colEndDate.OptionsColumn.FixedWidth = true;
            this.colEndDate.Width = 110;
            // 
            // colSubject
            // 
            this.colSubject.Caption = "Descrizione Gruppo";
            this.colSubject.FieldName = "Subject";
            this.colSubject.Name = "colSubject";
            this.colSubject.OptionsColumn.AllowEdit = false;
            this.colSubject.Visible = true;
            this.colSubject.VisibleIndex = 4;
            this.colSubject.Width = 171;
            // 
            // colLocation
            // 
            this.colLocation.Caption = "Location";
            this.colLocation.FieldName = "Location";
            this.colLocation.Name = "colLocation";
            this.colLocation.OptionsColumn.AllowEdit = false;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.Width = 118;
            // 
            // colLabel
            // 
            this.colLabel.Caption = "Label";
            this.colLabel.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colLabel.FieldName = "Label";
            this.colLabel.Name = "colLabel";
            this.colLabel.OptionsColumn.AllowEdit = false;
            this.colLabel.OptionsColumn.FixedWidth = true;
            this.colLabel.Visible = true;
            this.colLabel.VisibleIndex = 0;
            this.colLabel.Width = 125;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("No Disponibilità", 1, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("OK", 3, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("... attendere", 0, 2)});
            this.repositoryItemImageComboBox1.LargeImages = this.imageCollectionLabel;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.SmallImages = this.imageCollectionLabel;
            // 
            // imageCollectionLabel
            // 
            this.imageCollectionLabel.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionLabel.ImageStream")));
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Ingresso";
            this.gridColumn2.FieldName = "Ingresso.Descrizione";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 173;
            // 
            // colNumeroPersone
            // 
            this.colNumeroPersone.Caption = "Numero";
            this.colNumeroPersone.FieldName = "NumeroPersone";
            this.colNumeroPersone.Name = "colNumeroPersone";
            this.colNumeroPersone.OptionsColumn.AllowEdit = false;
            this.colNumeroPersone.OptionsColumn.FixedWidth = true;
            this.colNumeroPersone.Visible = true;
            this.colNumeroPersone.VisibleIndex = 3;
            // 
            // timerTick
            // 
            this.timerTick.Enabled = true;
            this.timerTick.Interval = 400;
            this.timerTick.Tick += new System.EventHandler(this.timerTick_Tick);
            // 
            // XtraUserControlCalendario2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simpleButtonCrea);
            this.Controls.Add(this.gridControlPrenotazioni);
            this.Name = "XtraUserControlCalendario2";
            this.Size = new System.Drawing.Size(675, 261);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPrenotazioni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPrenotazioni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionLabel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlPrenotazioni;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPrenotazioni;
        private DevExpress.XtraGrid.Columns.GridColumn colAppointmentType;
        private DevExpress.XtraGrid.Columns.GridColumn colStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colLocation;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colLabel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colNumeroPersone;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private System.Windows.Forms.Timer timerTick;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCrea;
        private DevExpress.Utils.ImageCollection imageCollectionLabel;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
    }
}
