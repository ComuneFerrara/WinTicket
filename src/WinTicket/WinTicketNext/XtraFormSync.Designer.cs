namespace WinTicketNext
{
    partial class XtraFormSync
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
            this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButtonChiusura = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonForza = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // marqueeProgressBarControl1
            // 
            this.marqueeProgressBarControl1.Location = new System.Drawing.Point(5, 25);
            this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            this.marqueeProgressBarControl1.Size = new System.Drawing.Size(360, 40);
            this.marqueeProgressBarControl1.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.marqueeProgressBarControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(370, 79);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Chiusura in corso";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.simpleButtonForza);
            this.groupControl2.Controls.Add(this.simpleButtonChiusura);
            this.groupControl2.Location = new System.Drawing.Point(13, 98);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(369, 86);
            this.groupControl2.TabIndex = 3;
            this.groupControl2.Text = "Operazioni";
            // 
            // simpleButtonChiusura
            // 
            this.simpleButtonChiusura.Location = new System.Drawing.Point(218, 26);
            this.simpleButtonChiusura.Name = "simpleButtonChiusura";
            this.simpleButtonChiusura.Size = new System.Drawing.Size(146, 55);
            this.simpleButtonChiusura.TabIndex = 0;
            this.simpleButtonChiusura.Text = "Chiudi Applicativo";
            this.simpleButtonChiusura.Click += new System.EventHandler(this.simpleButtonChiusura_Click);
            // 
            // simpleButtonForza
            // 
            this.simpleButtonForza.Location = new System.Drawing.Point(6, 38);
            this.simpleButtonForza.Name = "simpleButtonForza";
            this.simpleButtonForza.Size = new System.Drawing.Size(103, 33);
            this.simpleButtonForza.TabIndex = 1;
            this.simpleButtonForza.Text = "Chiusura Forzata";
            this.simpleButtonForza.Click += new System.EventHandler(this.simpleButtonForza_Click);
            // 
            // XtraFormSync
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 196);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "XtraFormSync";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XtraFormSync";
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonForza;
        private DevExpress.XtraEditors.SimpleButton simpleButtonChiusura;
    }
}