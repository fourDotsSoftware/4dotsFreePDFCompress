using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _4dotsFreePDFCompress
{
    public partial class frmAbout : CustomForm
    {
        public static string lblf = "";

        public static string LDT = "";

        public frmAbout()
        {
            InitializeComponent();
        }
                     
        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblAbout.Text = Module.ApplicationTitle + "\n\n" +
            "Developed by Alexander Triantafyllou\n" +
            "2012-2014 - 4dots Software\n" +
            "http://www.4dots-software.com\n\n" +
            "License : Affero GPL";

            //lblAdeia.Text = "FREE FOR NON COMMERCIAL USE ONLY !";
            /*            
            if (LDT != String.Empty)
            {
                lblAdeia.Text = "Licensed To : " + LDT;

            }*/
                      
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {

            try
            {
                System.Drawing.Graphics g = e.Graphics;
                int x = this.Width;
                int y = this.Height;

                System.Drawing.Drawing2D.LinearGradientBrush
                    lgBrush = new System.Drawing.Drawing2D.LinearGradientBrush
                    (new System.Drawing.Point(0, 0), new System.Drawing.Point(x, y),
                    Color.White, Color.FromArgb(190, 190, 190));
                lgBrush.GammaCorrection = true;
                g.FillRectangle(lgBrush, 0, 0, x, y);

            }
            catch
            {
                base.OnPaintBackground(e);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void lblAdeia_Click(object sender, EventArgs e)
        {

        }
    }
}