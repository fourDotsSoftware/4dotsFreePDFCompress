using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _4dotsFreePDFCompress
{
    public partial class frmMultipleFiles : _4dotsFreePDFCompress.CustomForm
    {
        public string Output = "";

        private bool BatchJoin = false;

        public frmMultipleFiles():this(false,"")
        {
            
        }

        public frmMultipleFiles(bool batchjoin,string txt)
        {
            InitializeComponent();

            lblBatchJoin.Visible = batchjoin;

            txtFiles.Text = txt;

            BatchJoin = batchjoin;            
            
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            
            /*
            string str = "";

            for (int k = 0; k < txtFiles.Lines.Length; k++)
            {
                if (txtFiles.Lines[k].Trim() == string.Empty) continue;

                if (!System.IO.Directory.Exists(txtFiles.Lines[k]) && !System.IO.File.Exists(txtFiles.Lines[k]))
                {
                    Module.ShowMessage("The directory or file specified does not exist ! Path : " + txtFiles.Lines[k]);
                    return;
                }

                if (str != string.Empty)
                {
                    str += ",";
                }
                str += "\"" + txtFiles.Lines[k] + "\"";
            }

            if (str == string.Empty)
            {
                Module.ShowMessage("Please insert at least one valid File or Folder !");
                return;
            }

            Output = str;
            */

            this.DialogResult = DialogResult.OK;
        }

        private void frmMultipleFiles_Load(object sender, EventArgs e)
        {
        }

        private void frmMultipleFiles_Activated(object sender, EventArgs e)
        {
            this.AcceptButton = null;
            this.CancelButton = null;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = Module.DialogFilesFilter;
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                for (int k = 0; k < openFileDialog1.FileNames.Length; k++)
                {
                    txtFiles.Text += openFileDialog1.FileNames[k] + Environment.NewLine;
                }
            }
        }
    }
}