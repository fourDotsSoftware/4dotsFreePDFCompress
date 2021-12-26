using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _4dotsFreePDFCompress
{
    public partial class frmResult : _4dotsFreePDFCompress.CustomForm
    {
        public frmResult(long _bytesbefore,long _bytesafter)
        {
            InitializeComponent();

            long bytessaved = _bytesbefore - _bytesafter;

            decimal kbsaved = (decimal)bytessaved / (decimal)1024;

            decimal kbbefore = (decimal)_bytesbefore / (decimal)1024;
            decimal kbafter = (decimal)_bytesafter / (decimal)1024;

            lblSizeAfter.Text = kbafter.ToString("#0.0") + " KB";
            lblSizeBefore.Text = kbbefore.ToString("#0.0") + " KB";

            if (kbsaved > 1024)
            {
                decimal mbsaved = (decimal)bytessaved / (decimal)(1024 * 1024);

                lblSaved.Text = mbsaved.ToString("#0.0") + " MB";
            }
            else
            {
                lblSaved.Text = kbsaved.ToString("#0.0") + " KB";
            }

            decimal perc_cr = 100 * (decimal)(_bytesbefore-_bytesafter) / (decimal)_bytesbefore;

            decimal percafter = 100 * (decimal)_bytesafter / (decimal)_bytesbefore;

            lblCompressionLevel.Text = perc_cr.ToString("#0.0") + " %";

            pbAfter.Value = 0;
            pbAfter.Maximum = 100;
            pbAfter.Value = Math.Max(0,Math.Min(100,(int)percafter));

            lblPercentageAfter.Text = percafter.ToString("#0.0") + "%";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}
