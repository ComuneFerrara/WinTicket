using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using Musei.Module;
using DevExpress.Utils.Drawing;
using DevExpress.LookAndFeel;
using DevExpress.Skins;

namespace WinTicketNext.Storico
{
    public partial class XtraFormCalendarioAperture : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormCalendarioAperture()
        {
            InitializeComponent();
            //this.lookUpEdit1.Properties.DataSource = Program.UtenteCollegato.GetMioElencoIngressi(this.unitOfWork1, Program.Postazione);
            this.dateNavigatorAperture.DateTime = new DateTime(DateTime.Now.Year, 1, 1);
        }

        private Postazione _Postazione;
        private GestoreAperture _Aperture = new GestoreAperture();
        private DateTime _Inizio = DateTime.Now;
        private DateTime _Fine = DateTime.Now;

        private void dateNavigatorAperture_CustomDrawDayNumberCell(object sender, DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventArgs e)
        {
            if (_Postazione == null)
            {
                e.Handled = false;
            }
            else
            {
                // Q343046

                var painter = sender as DevExpress.XtraScheduler.Drawing.DateNavigatorPainter;
                var selectedDates = painter.Calendar.Selection;

                if (_Aperture.Contiene(_Postazione.Oid, e.Date))
                {
                    //if (e.BackgroundElementInfo == null)
                    //    e.Cache.FillRectangle(e.Cache.GetSolidBrush(LookAndFeelHelper.GetSystemColor(LookAndFeel, SystemColors.Highlight)), e.Bounds);
                    //else
                    //    ObjectPainter.DrawObject(e.Cache, SkinElementPainter.Default, e.BackgroundElementInfo);

                    if (selectedDates.Contains(e.Date))
                    {
                        Color fillColor = Color.FromArgb(60, Color.DarkSeaGreen.R, Color.DarkSeaGreen.G, Color.DarkSeaGreen.B);
                        Brush fillBrush = new SolidBrush(fillColor);

                        Pen rectPen = new Pen(new SolidBrush(Color.DarkSeaGreen), 1);

                        e.Graphics.FillRectangle(fillBrush, e.Bounds);
                        e.Graphics.DrawRectangle(rectPen, e.Bounds);
                    }
                    else
                    {
                        Color fillColor = Color.FromArgb(60, Color.Goldenrod.R, Color.Goldenrod.G, Color.Goldenrod.B);
                        Brush fillBrush = new SolidBrush(fillColor);

                        Pen rectPen = new Pen(new SolidBrush(Color.Goldenrod), 1);

                        e.Graphics.FillRectangle(fillBrush, e.Bounds);
                        e.Graphics.DrawRectangle(rectPen, e.Bounds);
                    }

                    //specify formatting attributes for drawing text
                    var strFormat = new StringFormat();
                    strFormat.Alignment = StringAlignment.Center;
                    strFormat.LineAlignment = StringAlignment.Far;

                    //draw the day number
                    var fontBold = new Font(e.Style.Font, FontStyle.Bold);
                    if (e.Date.DayOfWeek == DayOfWeek.Sunday || e.Date.DayOfWeek == DayOfWeek.Saturday)
                        e.Graphics.DrawString(e.Date.Day.ToString(), fontBold, Brushes.Red, e.Bounds, strFormat);
                    else
                        e.Graphics.DrawString(e.Date.Day.ToString(), fontBold, Brushes.Black, e.Bounds, strFormat);

                    //no default drawing is required
                    e.Handled = true;
                }
                else if (selectedDates.Contains(e.Date))
                {
                    Color fillColor = Color.FromArgb(60, Color.PaleGreen.R, Color.PaleGreen.G, Color.PaleGreen.B);
                    Brush fillBrush = new SolidBrush(fillColor);

                    Pen rectPen = new Pen(new SolidBrush(Color.PaleGreen), 1);

                    e.Graphics.FillRectangle(fillBrush, e.Bounds);
                    e.Graphics.DrawRectangle(rectPen, e.Bounds);

                    //Pen p = e.Cache.GetPen(Color.Violet);

                    //if (e.BackgroundElementInfo == null)
                    //    e.Cache.FillRectangle(e.Cache.GetSolidBrush(LookAndFeelHelper.GetSystemColor(LookAndFeel, SystemColors.Highlight)), e.Bounds);
                    //else
                    //    ObjectPainter.DrawObject(e.Cache, SkinElementPainter.Default, e.BackgroundElementInfo);

                    //Pen violet = e.Cache.GetPen(Color.Violet);
                    //e.Graphics.DrawRectangle(violet, e.Bounds);

                    //specify formatting attributes for drawing text
                    var strFormat = new StringFormat();
                    strFormat.Alignment = StringAlignment.Center;
                    strFormat.LineAlignment = StringAlignment.Far;

                    //draw the day number
                    var fontBold = new Font(e.Style.Font, FontStyle.Bold);
                    if (e.Date.DayOfWeek == DayOfWeek.Sunday || e.Date.DayOfWeek == DayOfWeek.Saturday)
                        e.Graphics.DrawString(e.Date.Day.ToString(), fontBold, Brushes.Red, e.Bounds, strFormat);
                    else
                        e.Graphics.DrawString(e.Date.Day.ToString(), fontBold, Brushes.Black, e.Bounds, strFormat);

                    e.Handled = true;
                }
                else
                    e.Handled = false;


                //if (_Aperture.Contiene(_Ingresso, e.Date))
                //{
                //    Pen p = e.Cache.GetPen(Color.Violet);
                //    Rectangle r = e.Bounds;
                //    r.Inflate(-2, 0);
                //    r.Offset(3, 0);
                //    e.Cache.DrawRectangle(p, r);
                //}
            }
        }

        private void simpleButtonQuery_Click(object sender, EventArgs e)
        {
            Cursor saveCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _Inizio = this.dateNavigatorAperture.MyStartDate;
                _Fine = this.dateNavigatorAperture.MyEndDate;
                _Postazione = this.lookUpEdit1.EditValue as Postazione;

                if (_Postazione != null)
                {
                    _Aperture = new GestoreAperture();

                    // per sicurezza aggiungo un mese alla data di fine periodo
                    XPCollection<PostazioneAccesso> accessi = new XPCollection<PostazioneAccesso>(this.unitOfWork1);
                    GroupOperator periodoa1 = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                                    new BinaryOperator("Data", _Inizio, BinaryOperatorType.GreaterOrEqual),
                                    new BinaryOperator("Data", _Fine, BinaryOperatorType.LessOrEqual),
                                    new BinaryOperator("Postazione", _Postazione)
                    });
                    accessi.Criteria = periodoa1;
                    foreach (PostazioneAccesso postazioneAccesso in accessi)
                    {
                        _Aperture.Add(postazioneAccesso.Postazione.Oid, postazioneAccesso.Data);
                    }

                    this.labelControlInfo.Text = string.Format("{0} dal {1:d} al {2:d}",_Postazione.Nome, _Inizio, _Fine);
                }

                this.dateNavigatorAperture.Refresh();

                timer1.Enabled = true;
            }
            finally
            {
                Cursor.Current = saveCursor;
            }
        }

        private void dateNavigatorAperture_DoubleClick(object sender, EventArgs e)
        {
            //DateTime data = this.dateNavigatorAperture.DateTime;
            //if (_Aperture.Contiene(_Postazione.Oid, data))
            //{
            //    XPCollection<PostazioneAccesso> accessi = new XPCollection<PostazioneAccesso>(this.unitOfWork1);
            //    GroupOperator periodoa1 = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
            //                        new BinaryOperator("Data", data),
            //                        new BinaryOperator("Postazione", _Postazione)
            //        });
            //    accessi.Criteria = periodoa1;
            //    this.unitOfWork1.Delete(accessi);
            //    this.unitOfWork1.CommitChanges();

            //    simpleButtonQuery_Click(null, null);
            //}
            //else
            //{
            //    PostazioneAccesso accesso = new PostazioneAccesso(this.unitOfWork1);
            //    accesso.Postazione = _Postazione;
            //    accesso.Data = data;
            //    accesso.Save();
            //    this.unitOfWork1.CommitChanges();

            //    simpleButtonQuery_Click(null, null);
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_Inizio != this.dateNavigatorAperture.MyStartDate || _Fine != this.dateNavigatorAperture.MyEndDate)
            {
                timer1.Enabled = false;
                simpleButtonQuery_Click(null, null);
            }
        }

        private void dateNavigatorAperture_EditDateModified(object sender, EventArgs e)
        {
            this.dateEditStart.DateTime = this.dateNavigatorAperture.SelectionStart.Date;
            this.dateEditEnd.DateTime = this.dateNavigatorAperture.SelectionEnd.Date;
        }

        private void simpleButtonAperto_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(string.Format("Imposto come APERTO {0} per il periodo {1:d} - {2:d} ?", _Postazione.Nome, this.dateNavigatorAperture.SelectionStart, this.dateNavigatorAperture.SelectionEnd), "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Cursor saveCursor = Cursor.Current;
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    DateTime data = this.dateNavigatorAperture.SelectionStart.Date;
                    while (data <= this.dateNavigatorAperture.SelectionEnd.Date)
                    {
                        XPCollection<PostazioneAccesso> accessi = new XPCollection<PostazioneAccesso>(this.unitOfWork1);
                        accessi.Criteria = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                                    new BinaryOperator("Data", data),
                                    new BinaryOperator("Postazione", _Postazione) });

                        if (accessi.Count == 0)
                        {
                            PostazioneAccesso accesso = new PostazioneAccesso(this.unitOfWork1);
                            accesso.Postazione = _Postazione;
                            accesso.Data = data;
                            accesso.Save();
                        }

                        data = data.AddDays(1);
                    }

                    this.unitOfWork1.CommitChanges();
                    simpleButtonQuery_Click(null, null);
                }
                finally
                {
                    Cursor.Current = saveCursor;
                }
            }
        }

        private void simpleButtonChiuso_Click(object sender, EventArgs e)
        {
            XPCollection<PostazioneAccesso> accessi = new XPCollection<PostazioneAccesso>(this.unitOfWork1);
            accessi.Criteria = new GroupOperator(GroupOperatorType.And, new CriteriaOperator[]{
                                    new BinaryOperator("Data", this.dateNavigatorAperture.SelectionStart.Date, BinaryOperatorType.GreaterOrEqual),
                                    new BinaryOperator("Data", this.dateNavigatorAperture.SelectionEnd.Date, BinaryOperatorType.LessOrEqual),
                                    new BinaryOperator("Postazione", _Postazione)
                    });

            if (XtraMessageBox.Show(string.Format("Imposto come CHIUSO {0} per il periodo {1:d} - {2:d} ? (elimino {3} voci)", _Postazione.Nome, this.dateNavigatorAperture.SelectionStart.Date, this.dateNavigatorAperture.SelectionEnd.Date, accessi.Count), "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Cursor saveCursor = Cursor.Current;
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    this.unitOfWork1.Delete(accessi);
                    this.unitOfWork1.CommitChanges();

                    simpleButtonQuery_Click(null, null);
                }
                finally
                {
                    Cursor.Current = saveCursor;
                }
            }
        }
    }
}