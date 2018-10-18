namespace WinTicketNext.CostruzionePercorso.GestionePrenotazione
{
    partial class XtraReportStampa1
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrSubreport1 = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrLabelInfo1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelTitleRiga1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrBarCode1 = new DevExpress.XtraReports.UI.XRBarCode();
            this.xrLabelTitleRiga2 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xpCollection1 = new DevExpress.Xpo.XPCollection(this.components);
            this.unitOfWork1 = new DevExpress.Xpo.UnitOfWork(this.components);
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreport1,
            this.xrLabelInfo1,
            this.xrLabelTitleRiga1,
            this.xrBarCode1,
            this.xrLabelTitleRiga2});
            this.Detail.Dpi = 254F;
            this.Detail.HeightF = 800F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // xrSubreport1
            // 
            this.xrSubreport1.Dpi = 254F;
            this.xrSubreport1.LocationFloat = new DevExpress.Utils.PointFloat(125.0414F, 208F);
            this.xrSubreport1.Name = "xrSubreport1";
            this.xrSubreport1.ReportSource = new WinTicketNext.CostruzionePercorso.GestionePrenotazione.XtraReportRigaStampa1();
            this.xrSubreport1.SizeF = new System.Drawing.SizeF(954F, 584F);
            this.xrSubreport1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrSubreport1_BeforePrint);
            // 
            // xrLabelInfo1
            // 
            this.xrLabelInfo1.CanGrow = false;
            this.xrLabelInfo1.Dpi = 254F;
            this.xrLabelInfo1.Font = new System.Drawing.Font("Arial", 7F);
            this.xrLabelInfo1.LocationFloat = new DevExpress.Utils.PointFloat(125F, 128F);
            this.xrLabelInfo1.Name = "xrLabelInfo1";
            this.xrLabelInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelInfo1.SizeF = new System.Drawing.SizeF(955F, 80F);
            this.xrLabelInfo1.StylePriority.UseFont = false;
            this.xrLabelInfo1.Text = "info";
            // 
            // xrLabelTitleRiga1
            // 
            this.xrLabelTitleRiga1.Dpi = 254F;
            this.xrLabelTitleRiga1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabelTitleRiga1.LocationFloat = new DevExpress.Utils.PointFloat(125F, 0F);
            this.xrLabelTitleRiga1.Multiline = true;
            this.xrLabelTitleRiga1.Name = "xrLabelTitleRiga1";
            this.xrLabelTitleRiga1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelTitleRiga1.SizeF = new System.Drawing.SizeF(954.9999F, 64F);
            this.xrLabelTitleRiga1.StylePriority.UseFont = false;
            this.xrLabelTitleRiga1.StylePriority.UseTextAlignment = false;
            this.xrLabelTitleRiga1.Text = "Ingresso 29 pax € 181: Singolo Gruppo Ridotto Omaggio";
            this.xrLabelTitleRiga1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrBarCode1
            // 
            this.xrBarCode1.Alignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrBarCode1.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom;
            this.xrBarCode1.BarCodeOrientation = DevExpress.XtraPrinting.BarCode.BarCodeOrientation.RotateRight;
            this.xrBarCode1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BarCode")});
            this.xrBarCode1.Dpi = 254F;
            this.xrBarCode1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrBarCode1.Module = 2.5F;
            this.xrBarCode1.Name = "xrBarCode1";
            this.xrBarCode1.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 11, 0, 0, 254F);
            this.xrBarCode1.ShowText = false;
            this.xrBarCode1.SizeF = new System.Drawing.SizeF(125F, 800F);
            this.xrBarCode1.StylePriority.UsePadding = false;
            this.xrBarCode1.StylePriority.UseTextAlignment = false;
            this.xrBarCode1.Symbology = code128Generator1;
            this.xrBarCode1.Text = "000";
            this.xrBarCode1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            // 
            // xrLabelTitleRiga2
            // 
            this.xrLabelTitleRiga2.Dpi = 254F;
            this.xrLabelTitleRiga2.Font = new System.Drawing.Font("Verdana", 9F);
            this.xrLabelTitleRiga2.LocationFloat = new DevExpress.Utils.PointFloat(125F, 64.00001F);
            this.xrLabelTitleRiga2.Multiline = true;
            this.xrLabelTitleRiga2.Name = "xrLabelTitleRiga2";
            this.xrLabelTitleRiga2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelTitleRiga2.SizeF = new System.Drawing.SizeF(954.9999F, 63.99999F);
            this.xrLabelTitleRiga2.StylePriority.UseFont = false;
            this.xrLabelTitleRiga2.StylePriority.UseTextAlignment = false;
            this.xrLabelTitleRiga2.Text = "xrLabelTitleRiga2";
            this.xrLabelTitleRiga2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // PageHeader
            // 
            this.PageHeader.Dpi = 254F;
            this.PageHeader.HeightF = 0F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageFooter
            // 
            this.PageFooter.Dpi = 254F;
            this.PageFooter.HeightF = 0F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xpCollection1
            // 
            this.xpCollection1.ObjectType = typeof(Musei.Module.Stampa);
            this.xpCollection1.Session = this.unitOfWork1;
            // 
            // unitOfWork1
            // 
            this.unitOfWork1.TrackPropertiesModifications = false;
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.Dpi = 254F;
            this.topMarginBand1.HeightF = 0F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.Dpi = 254F;
            this.bottomMarginBand1.HeightF = 0F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // XtraReportStampa1
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.DataSource = this.xpCollection1;
            this.Dpi = 254F;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.PageHeight = 820;
            this.PageWidth = 1080;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.Version = "12.2";
            ((System.ComponentModel.ISupportInitialize)(this.xpCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.Xpo.UnitOfWork unitOfWork1;
        private DevExpress.XtraReports.UI.XRBarCode xrBarCode1;
        private DevExpress.XtraReports.UI.XRLabel xrLabelTitleRiga1;
        public DevExpress.Xpo.XPCollection xpCollection1;
        private DevExpress.XtraReports.UI.XRLabel xrLabelInfo1;
        private DevExpress.XtraReports.UI.XRSubreport xrSubreport1;
        private DevExpress.XtraReports.UI.XRLabel xrLabelTitleRiga2;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
    }
}
