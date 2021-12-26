using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace _4dotsFreePDFCompress
{
    public partial class ucTextProgressBar : System.Windows.Forms.ProgressBar 
    {
        public string lblText = "";
        public ucTextProgressBar()
        {
            InitializeComponent();
            lblText= "";
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //SetStyle(ControlStyles.UserPaint, true);
            this.Value = 0;
            this.Maximum = 100;
        }

        public void SetText(string str)
        {               
            if (lblText != str)
            {
                lblText = str;
                this.Refresh();                
            }
        }

        public void UpdatePercentage()
        {
            // maxval curval
            // 100       x;

            int curval=this.Value;
            int maxval = this.Maximum;

            double perc = (double)(100 * curval) / (double)maxval;

            SetText(perc.ToString("#0.#") + " %");
        }

        public void zOnPaint(PaintEventArgs e)
        {
            
            using (Brush brBack = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillRectangle(brBack, this.ClientRectangle);
            }


            int curval = this.Value;
            int maxval = this.Maximum;

            double perc = (double)(curval) / (double)maxval;

            Rectangle rangerect = new Rectangle(0, 0, (int)(perc * this.Width), this.Height);

            System.Drawing.Font font = new Font(this.Parent.Font, FontStyle.Bold);

            if (rangerect.Width > 0)
            {

                using (LinearGradientBrush fillBrush = new LinearGradientBrush(rangerect, Color.LightGreen, Color.DarkGreen, LinearGradientMode.Vertical))
                {

                    e.Graphics.FillRectangle(fillBrush, rangerect);

                    PointF sPoint = new PointF(this.Width / 2 - (e.Graphics.MeasureString(lblText,
                font).Width / 2.0F),
            this.Height / 2 - (e.Graphics.MeasureString(lblText,
                font).Height / 2.0F));

                    e.Graphics.DrawString(lblText, font, Brushes.Black, sPoint);
                    
                }
            }

            using (Pen p=new Pen(SystemColors.ControlDark))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(0,0,this.Width-1,this.Height-1));
            }

        }

        const int WmPaint = 15;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            switch (m.Msg)
            {
                case WmPaint:
                    using (Graphics graphics = Graphics.FromHwnd(Handle))
                    {
                        using (System.Drawing.Font font = new System.Drawing.Font(this.Parent.Font, FontStyle.Bold))
                        {
                            SizeF textSize = graphics.MeasureString(lblText, font);

                            graphics.DrawString(lblText, font, Brushes.Black, (Width / 2) - (textSize.Width / 2), (Height / 2) - (textSize.Height / 2));
                        }
                    }
                    break;
            }
        }
    }
}
