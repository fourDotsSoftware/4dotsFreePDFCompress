using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _4dotsFreePDFCompress
{
    public partial class frmMessage : CustomForm
    {
        public frmMessage()
        {
            InitializeComponent();
        }

        private bool ForCommandLineArgs = false;

        public frmMessage(bool forCmdArgs):this()
        {
            btnCopy.Visible = true;

            this.Text = TranslateHelper.Translate("Command Line Arguments");

            txtMsg.Text = ArgsHelper.GetCommandUsage();

            chkShow.Visible = false;

            ForCommandLineArgs = true;

            txtMsg.ForeColor = Color.Black;

            txtMsg.BackColor = Color.White;

            txtMsg.Font = new Font(this.Font.FontFamily, 10, FontStyle.Regular);
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ForCommandLineArgs)
            {
                //Properties.Settings.Default.ShowMessage = !chkShow.Checked;
            }

            this.DialogResult = DialogResult.OK;

            try
            {
                this.Close();
            }
            catch { }
        }

        private void frmMessage_Load(object sender, EventArgs e)
        {

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(txtMsg.Text);
        }
    }
}

