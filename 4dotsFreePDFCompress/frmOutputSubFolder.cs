using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _4dotsFreePDFCompress
{
    public partial class frmOutputSubFolder : CustomForm
    {
        public frmOutputSubFolder()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtSubfolder.Text.Trim() == string.Empty)
            {
                Module.ShowMessage("Please enter a Subfolder Name !");
                return;
            }
            else if (!IsLegalFilename(txtSubfolder.Text))
            {
                Module.ShowMessage("Please enter a valid Subfolder Name !");
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        public static bool IsLegalFilename(string name)
        {
            try
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(name);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void frmOutputSubFolder_Load(object sender, EventArgs e)
        {

        }
    }
}
