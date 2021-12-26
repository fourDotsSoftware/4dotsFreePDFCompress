using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Net;

namespace _4dotsFreePDFCompress
{
    public partial class frmDownloadUpdate : CustomForm
    {
        private string _DownloadFile = "";

        public string DownloadFile
        {
            get
            {
                if (_DownloadFile == string.Empty)
                {
                    int spos = DownloadURL.LastIndexOf("/");
                    string file = DownloadURL.Substring(spos + 1);

                    string tempdir = System.IO.Path.GetTempFileName() + "setup";

                    System.IO.Directory.CreateDirectory(tempdir);

                    _DownloadFile =System.IO.Path.Combine(tempdir, file);
                }
                                
                return _DownloadFile;
                
            }
        }
        public string DownloadURL
        {
            get
            {
                return GetEXEDownloadURL();
            }
        }

        public WebClient client = null;
        public bool Cancelled = false;

        public frmDownloadUpdate()
        {
            InitializeComponent();
            
            pgBar.Value = 0;
            pgBar.Maximum = 100;
        }

        private void frmDownloadUpdate_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(DownloadFile))
            {
                System.IO.File.Delete(DownloadFile);
            }

            client = new WebClient();
            client.DownloadProgressChanged +=client_DownloadProgressChanged;
            client.DownloadFileCompleted +=client_DownloadFileCompleted;
            client.DownloadFileAsync(new Uri(DownloadURL), DownloadFile);
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (!Cancelled)
            {
                Module.ShowMessage("The application will now exit and run the updated setup file");

                try
                {
                    System.Diagnostics.Process.Start(DownloadFile);

                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    Module.ShowError("Error. Could not run new Setup File !", ex);

                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            pgBar.Value = e.ProgressPercentage;
            pgBar.SetText(e.ProgressPercentage.ToString() + " %");
            
            decimal ukb=(decimal)e.TotalBytesToReceive/(decimal)1024;
            decimal umb=ukb/(decimal)1024;

            lblTotalSize.Text = umb.ToString("#0.0") + " MB";
        }

        public string GetEXEDownloadURL()
        {
            string durl = Module.DownloadURL;

            if (!durl.ToLower().EndsWith(".exe"))
            {
                if (durl.EndsWith("/"))
                {
                    durl = durl.Substring(0, durl.Length - 1);
                }
                int spos = durl.LastIndexOf("/", durl.Length - 1);

                string program = durl.Substring(spos + 1);

                return "http://www.4dots-software.com/downloads/" + program + "Setup.exe";
            }
            else
            {
                return durl;
            }
        }

        private void btnCancelDownload_Click(object sender, EventArgs e)
        {
            Cancelled = true;

            client.CancelAsync();

            this.DialogResult = DialogResult.Cancel;
        }
    }
}
