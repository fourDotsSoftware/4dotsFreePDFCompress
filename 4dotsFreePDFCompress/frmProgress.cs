using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _4dotsFreePDFCompress
{
    public partial class frmProgress : CustomForm
    {
        private static frmProgress _Instance = null;

        public static frmProgress Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new frmProgress();
                }

                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
                    
        public frmProgress()
        {
            InitializeComponent();
            Instance = this;
            
        }

        private delegate void HideFormDelegate();

        public void HideForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((HideFormDelegate)HideForm, null);
            }
            else
            {
                this.Visible = false;
            }
        }

        private delegate void ShowFormDelegate();

        public void ShowForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((ShowFormDelegate)ShowForm, null);
            }
            else
            {
                this.Visible = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PDFCompressHelper.CANCELLED = true;
            frmMain.Instance.bwCompress.CancelAsync();
        }

        public int Secs = 0;

        private void timTime_Tick(object sender, EventArgs e)
        {
            Application.DoEvents();
            
            Secs++;

            TimeSpan ts = new TimeSpan(0, 0, Secs);

            lblTime.Text = ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");
        }

        private void frmProgress_Activated(object sender, EventArgs e)
        {
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawRectangle(Pens.Gray, new Rectangle(2, 2, this.Width - 4, this.Height - 4));
        }

    }
}

