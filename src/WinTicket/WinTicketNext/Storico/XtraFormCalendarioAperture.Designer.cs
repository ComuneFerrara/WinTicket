namespace WinTicketNext.Storico
{
    partial class XtraFormCalendarioAperture
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
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.xpCollectionPostazioni = new DevExpress.Xpo.XPCollection();
            this.unitOfWork1 = new DevExpress.Xpo.UnitOfWork();
            this.simpleButtonQuery = new DevExpress.XtraEditors.SimpleButton();
            this.labelControlInfo = new DevExpress.XtraEditors.LabelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditStart = new DevExpress.XtraEditors.DateEdit();
            this.dateEditEnd = new DevExpress.XtraEditors.DateEdit();
            this.simpleButtonChiuso = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonAperto = new DevExpress.XtraEditors.SimpleButton();
            this.dateNavigatorAperture = new WinTicketNext.Storico.MyDateNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollectionPostazioni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigatorAperture)).BeginInit();
            this.SuspendLayout();
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(65, 37);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nome", "Nome", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.lookUpEdit1.Properties.DataSource = this.xpCollectionPostazioni;
            this.lookUpEdit1.Properties.DisplayMember = "Nome";
            this.lookUpEdit1.Properties.ValueMember = "This";
            this.lookUpEdit1.Size = new System.Drawing.Size(377, 20);
            this.lookUpEdit1.TabIndex = 1;
            // 
            // xpCollectionPostazioni
            // 
            this.xpCollectionPostazioni.CriteriaString = "[Tipologia] = 0L";
            this.xpCollectionPostazioni.ObjectType = typeof(Musei.Module.Postazione);
            this.xpCollectionPostazioni.Session = this.unitOfWork1;
            // 
            // simpleButtonQuery
            // 
            this.simpleButtonQuery.Appearance.Options.UseTextOptions = true;
            this.simpleButtonQuery.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.simpleButtonQuery.Location = new System.Drawing.Point(462, 23);
            this.simpleButtonQuery.Name = "simpleButtonQuery";
            this.simpleButtonQuery.Size = new System.Drawing.Size(91, 47);
            this.simpleButtonQuery.TabIndex = 2;
            this.simpleButtonQuery.Text = "Visualizza Aperture";
            this.simpleButtonQuery.Click += new System.EventHandler(this.simpleButtonQuery_Click);
            // 
            // labelControlInfo
            // 
            this.labelControlInfo.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlInfo.Location = new System.Drawing.Point(13, 144);
            this.labelControlInfo.Name = "labelControlInfo";
            this.labelControlInfo.Size = new System.Drawing.Size(6, 25);
            this.labelControlInfo.TabIndex = 3;
            this.labelControlInfo.Text = ".";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 40);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Ingresso:";
            // 
            // dateEditStart
            // 
            this.dateEditStart.EditValue = null;
            this.dateEditStart.Location = new System.Drawing.Point(13, 83);
            this.dateEditStart.Name = "dateEditStart";
            this.dateEditStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStart.Properties.DisplayFormat.FormatString = "D";
            this.dateEditStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditStart.Properties.ReadOnly = true;
            this.dateEditStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditStart.Size = new System.Drawing.Size(198, 20);
            this.dateEditStart.TabIndex = 5;
            // 
            // dateEditEnd
            // 
            this.dateEditEnd.EditValue = null;
            this.dateEditEnd.Location = new System.Drawing.Point(13, 109);
            this.dateEditEnd.Name = "dateEditEnd";
            this.dateEditEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEnd.Properties.DisplayFormat.FormatString = "D";
            this.dateEditEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditEnd.Properties.ReadOnly = true;
            this.dateEditEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditEnd.Size = new System.Drawing.Size(198, 20);
            this.dateEditEnd.TabIndex = 6;
            // 
            // simpleButtonChiuso
            // 
            this.simpleButtonChiuso.Image = global::WinTicketNext.Properties.Resources.signal_flag_red_OPI_32_S;
            this.simpleButtonChiuso.Location = new System.Drawing.Point(367, 86);
            this.simpleButtonChiuso.Name = "simpleButtonChiuso";
            this.simpleButtonChiuso.Size = new System.Drawing.Size(83, 43);
            this.simpleButtonChiuso.TabIndex = 8;
            this.simpleButtonChiuso.Text = "Chiuso";
            this.simpleButtonChiuso.Click += new System.EventHandler(this.simpleButtonChiuso_Click);
            // 
            // simpleButtonAperto
            // 
            this.simpleButtonAperto.Image = global::WinTicketNext.Properties.Resources.signal_flag_green_OPI_32_S;
            this.simpleButtonAperto.Location = new System.Drawing.Point(248, 86);
            this.simpleButtonAperto.Name = "simpleButtonAperto";
            this.simpleButtonAperto.Size = new System.Drawing.Size(83, 43);
            this.simpleButtonAperto.TabIndex = 7;
            this.simpleButtonAperto.Text = "Aperto";
            this.simpleButtonAperto.Click += new System.EventHandler(this.simpleButtonAperto_Click);
            // 
            // dateNavigatorAperture
            // 
            this.dateNavigatorAperture.DateTime = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dateNavigatorAperture.HotDate = null;
            this.dateNavigatorAperture.Location = new System.Drawing.Point(12, 175);
            this.dateNavigatorAperture.Name = "dateNavigatorAperture";
            this.dateNavigatorAperture.ShowTodayButton = false;
            this.dateNavigatorAperture.Size = new System.Drawing.Size(1128, 312);
            this.dateNavigatorAperture.TabIndex = 0;
            this.dateNavigatorAperture.EditDateModified += new System.EventHandler(this.dateNavigatorAperture_EditDateModified);
            this.dateNavigatorAperture.CustomDrawDayNumberCell += new DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventHandler(this.dateNavigatorAperture_CustomDrawDayNumberCell);
            this.dateNavigatorAperture.DoubleClick += new System.EventHandler(this.dateNavigatorAperture_DoubleClick);
            // 
            // XtraFormCalendarioAperture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 499);
            this.Controls.Add(this.simpleButtonChiuso);
            this.Controls.Add(this.simpleButtonAperto);
            this.Controls.Add(this.dateEditEnd);
            this.Controls.Add(this.dateEditStart);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControlInfo);
            this.Controls.Add(this.simpleButtonQuery);
            this.Controls.Add(this.lookUpEdit1);
            this.Controls.Add(this.dateNavigatorAperture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XtraFormCalendarioAperture";
            this.Text = "Gestione Calendario Aperture Biglietterie";
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollectionPostazioni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigatorAperture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyDateNavigator dateNavigatorAperture;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.Xpo.UnitOfWork unitOfWork1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonQuery;
        private DevExpress.XtraEditors.LabelControl labelControlInfo;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.Xpo.XPCollection xpCollectionPostazioni;
        private DevExpress.XtraEditors.DateEdit dateEditStart;
        private DevExpress.XtraEditors.DateEdit dateEditEnd;
        private DevExpress.XtraEditors.SimpleButton simpleButtonAperto;
        private DevExpress.XtraEditors.SimpleButton simpleButtonChiuso;
    }
}