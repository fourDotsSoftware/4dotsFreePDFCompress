using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _4dotsFreePDFCompress
{
    public partial class frmPassword : CustomForm
    {
        private string InputFile = "";

        public frmPassword(string inputfile)
        {
            InitializeComponent();
            TextBox lbl = new TextBox();
            lbl.Left = 0;
            lbl.Top = 0;
            lbl.Width = this.Width;
          //  lbl.BackColor = Color.Transparent;
            lbl.Text = inputfile;
            lbl.ReadOnly = true;
            this.Controls.Add(lbl);

            chkPassword.Checked = true;
            chkPassword.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                Module.ShowMessage("Please insert a valid Password !");
                return;

            }
            this.DialogResult = DialogResult.OK;
        }

        private void frmPassword_Load(object sender, EventArgs e)
        {

        }
    }
}

