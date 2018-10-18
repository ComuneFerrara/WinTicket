using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Musei.Module;

namespace WinTicketNext.Storico
{
    public partial class XtraFormDatiFatturaApp18 : XtraForm
    {
        public XtraFormDatiFatturaApp18()
        {
            InitializeComponent();
        }

        public static string Riga1 { get; set; }
        public static string Riga2 { get; set; }
        public static string Riga3 { get; set; }
        public static string Riga4 { get; set; }
        public static string Riga5 { get; set; }
        public static string CodiceBarre { get; set; }
        public static string Note { get; set; }

        public static void PulisciCampi()
        {
            Riga1 = "";
            Riga2 = "";
            Riga3 = "";
            Riga4 = "";
            Riga5 = "";
            CodiceBarre = "";
            Note = "";
        }

        public void Init()
        {
            this.textEditIntestazione1.Text = Riga1;
            this.textEditIntestazione2.Text = Riga2;
            this.textEditIntestazione3.Text = Riga3;
            this.textEditIntestazione4.Text = Riga4;
            this.textEditIntestazione5.Text = Riga5;
            this.textEditBarCode.Text = CodiceBarre;
            this.textEditNote.Text = Note;
        }

        public void SalvaCampi()
        {
            Riga1 = this.textEditIntestazione1.Text;
            Riga2 = this.textEditIntestazione2.Text;
            Riga3 = this.textEditIntestazione3.Text;
            Riga4 = this.textEditIntestazione4.Text;
            Riga5 = this.textEditIntestazione5.Text;
            CodiceBarre = this.textEditBarCode.Text;
            Note = this.textEditNote.Text;
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            SalvaCampi();
            DialogResult = DialogResult.OK;
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            SalvaCampi();
            DialogResult = DialogResult.Cancel;
        }


    

      

    }
}