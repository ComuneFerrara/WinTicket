namespace WinTicketNext
{
    partial class Splash
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
            this.backgroundWorkerMain = new System.ComponentModel.BackgroundWorker();
            this.labelVersione = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorkerMain
            // 
            this.backgroundWorkerMain.WorkerReportsProgress = true;
            this.backgroundWorkerMain.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerMain_DoWork);
            this.backgroundWorkerMain.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerMain_RunWorkerCompleted);
            // 
            // labelVersione
            // 
            this.labelVersione.BackColor = System.Drawing.Color.Transparent;
            this.labelVersione.Location = new System.Drawing.Point(268, 87);
            this.labelVersione.Name = "labelVersione";
            this.labelVersione.Size = new System.Drawing.Size(100, 13);
            this.labelVersione.TabIndex = 0;
            this.labelVersione.Text = "Ver 0.1.30.3283";
            this.labelVersione.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelInfo.ForeColor = System.Drawing.Color.Peru;
            this.labelInfo.Location = new System.Drawing.Point(12, 109);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(252, 26);
            this.labelInfo.TabIndex = 1;
            this.labelInfo.Text = "L\'uso di questo software implica l\'accettazione della \r\ncorrispondente \"End User " +
    "License Agreement\"";
            // 
            // marqueeProgressBarControl1
            // 
            this.marqueeProgressBarControl1.EditValue = "";
            this.marqueeProgressBarControl1.Location = new System.Drawing.Point(271, 109);
            this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            this.marqueeProgressBarControl1.Properties.AllowFocused = false;
            this.marqueeProgressBarControl1.Properties.Appearance.BackColor = System.Drawing.Color.Cornsilk;
            this.marqueeProgressBarControl1.Properties.ShowTitle = true;
            this.marqueeProgressBarControl1.Properties.UseParentBackground = true;
            this.marqueeProgressBarControl1.Size = new System.Drawing.Size(97, 26);
            this.marqueeProgressBarControl1.TabIndex = 2;
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::WinTicketNext.Properties.Resources.WinTicketSplash;
            this.ClientSize = new System.Drawing.Size(380, 140);
            this.Controls.Add(this.marqueeProgressBarControl1);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelVersione);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Shown += new System.EventHandler(this.Splash_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorkerMain;
        private System.Windows.Forms.Label labelVersione;
        private System.Windows.Forms.Label labelInfo;
        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
    }
}