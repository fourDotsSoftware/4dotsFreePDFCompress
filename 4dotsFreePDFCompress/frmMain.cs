using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
/*
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
*/
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace _4dotsFreePDFCompress
{
    public partial class frmMain : CustomForm
    {
        public static frmMain _Instance = null;

        public static frmMain Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new frmMain();
                }

                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }

        public DataTable dt = new DataTable("pdfs");

        public frmMain()
        {
            InitializeComponent();
            
            Instance = this;

            if (Module.IsCommandLine)
            {
                this.Visible = false;
                this.ShowInTaskbar = false;
            }

            this.Icon = Properties.Resources.pdf_compress_48;

            dt.Columns.Add("filename");
            dt.Columns.Add("sizekb");
            dt.Columns.Add("fullfilepath");
            dt.Columns.Add("filedate");
            dt.Columns.Add("userpassword");
            dt.Columns.Add("rootfolder");

            dgFiles.AutoGenerateColumns = false;

            if (Properties.Settings.Default.ShowPromotion)
            {
                frmPromotion fp = new frmPromotion();
                //fp.ShowDialog(this);
                fp.Show(this);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //iTextSharp.text.Document doc = new iTextSharp.text.Document();
            /*
            PdfReader reader = new PdfReader(@"c:\4\head first ajax.pdf");

            Document doc = new Document(reader.GetPageSizeWithRotation(1));

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@"c:\4\test.pdf",FileMode.Create));
            doc.Open();
            PdfContentByte cb = writer.DirectContent;
            */
            /*
            for (int k = 1; k <= reader.NumberOfPages; k++)
            {
                doc.SetPageSize(reader.GetPageSizeWithRotation(i));
                PdfDictionary pdfdict=pdfReader.GetPageN(k);
                PdfImportedPage imp=pdfWriter.GetImportedPage(pdfReader, k);
                pdfWriter.Add(imp);

            }
            */
        }

        private void AddVisual(string[] argsvisual)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //Module.ShowMessage("Is From Windows Explorer");                                

                for (int k = 0; k < argsvisual.Length; k++)
                {
                    if (System.IO.File.Exists(argsvisual[k]))
                    {
                        AddFile(argsvisual[k]);

                    }
                    else if (System.IO.Directory.Exists(argsvisual[k]))
                    {
                        AddFolder(argsvisual[k]);
                    }
                }
            }
            finally
            {
                this.Cursor = null;
            }
        }

        private void SetupOutputFolders()
        {
            cmbOutputDir.Items.Add(TranslateHelper.Translate("Same Folder of PDF Document"));
            cmbOutputDir.Items.Add(TranslateHelper.Translate("Overwrite PDF Document"));
            cmbOutputDir.Items.Add(TranslateHelper.Translate("Subfolder of PDF Document"));
            cmbOutputDir.Items.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString());
            cmbOutputDir.Items.Add("---------------------------------------------------------------------------------------");

            OutputFolderHelper.LoadOutputFolders();
            cmbOutputDir.SelectedIndex = Properties.Settings.Default.OutputFolderIndex;

            if (cmbOutputDir.SelectedIndex == 1)
            {
                chkKeepBackup.Visible = true;
            }

            chkKeepBackup.Checked = Properties.Settings.Default.KeepBackup;

        }
        private void SetupOnLoad()
        {
            dgFiles.DataSource = dt;

            this.Icon = Properties.Resources.pdf_compress_48;

            this.Text = Module.ApplicationTitle;
            //this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            //this.Left = 0;
            AddLanguageMenuItems();

            DownloadSuggestionsHelper ds = new DownloadSuggestionsHelper();
            ds.SetupDownloadMenuItems(downloadToolStripMenuItem);

            AdjustSizeLocation();

            SetupOutputFolders();

            chkImages.Checked = Properties.Settings.Default.CompressImages;
            nudQuality.Value = (decimal)Properties.Settings.Default.ImageQuality;

            keepFolderStructureToolStripMenuItem.Checked = Properties.Settings.Default.KeepFolderStructure;

            if (!ArgsHelper.IsFromCommandLine)
            {
                RecentFilesHelper.FillMenuRecentFile();
                RecentFilesHelper.FillMenuRecentFolder();
                RecentFilesHelper.FillMenuRecentImportList();
            }

            chkInvert.Checked = Properties.Settings.Default.InvertImages;
            chkInvert2.Checked = Properties.Settings.Default.InvertImages2;

            chkGrayscale.Checked = Properties.Settings.Default.Grayscale;

            chkBlackWhiteImages.Checked = Properties.Settings.Default.BlackAndWhite;

            doNotAskForPasswordToolStripMenuItem.Checked = Properties.Settings.Default.DoNotAskForPassword;

            checkForNewVersionEachWeekToolStripMenuItem.Checked = Properties.Settings.Default.CheckWeek;

            //=========

            exploreOutputFolderWhenDoneToolStripMenuItem.Checked =
                Properties.Settings.Default.ExploreOutputFolder;

            keepCreationDateToolStripMenuItem.Checked =
                Properties.Settings.Default.KeepCreationDate;

            keepLastModificationDateToolStripMenuItem.Checked =
                Properties.Settings.Default.KeepLastModificatonDate;

            showMessageOnSuccessToolStripMenuItem.Checked =
                Properties.Settings.Default.ShowMessageOnSucess;

            showResultWindowToolStripMenuItem.Checked =
                Properties.Settings.Default.ShowResultWindow;
        }


        private void AdjustSizeLocation()
        {
            if (Properties.Settings.Default.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {

                if (Properties.Settings.Default.Width == -1)
                {
                    this.CenterToScreen();
                    return;
                }
                else
                {
                    this.Width = Properties.Settings.Default.Width;
                }
                if (Properties.Settings.Default.Height != 0)
                {
                    this.Height = Properties.Settings.Default.Height;
                }

                if (Properties.Settings.Default.Left != -1)
                {
                    this.Left = Properties.Settings.Default.Left;
                }

                if (Properties.Settings.Default.Top != -1)
                {
                    this.Top = Properties.Settings.Default.Top;
                }

                if (this.Width < 300)
                {
                    this.Width = 300;
                }

                if (this.Height < 300)
                {
                    this.Height = 300;
                }

                if (this.Left < 0)
                {
                    this.Left = 0;
                }

                if (this.Top < 0)
                {
                    this.Top = 0;
                }
            }

        }

        private void SaveSizeLocation()
        {
            Properties.Settings.Default.Maximized = (this.WindowState == FormWindowState.Maximized);
            Properties.Settings.Default.Left = this.Left;
            Properties.Settings.Default.Top = this.Top;
            Properties.Settings.Default.Width = this.Width;
            Properties.Settings.Default.Height = this.Height;
            Properties.Settings.Default.Save();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {           
                                    
            //dtcustom.Rows.Add(dtcustom.NewRow());

            SetupOnLoad();

            if (Properties.Settings.Default.CheckWeek)
            {
                UpdateHelper.InitializeCheckVersionWeek();
            }

            if (Module.IsFromWindowsExplorer)
            {
                AddVisual(Module.args);
            }           
        }

        #region Localization

        private void AddLanguageMenuItems()
        {
            for (int k = 0; k < frmLanguage.LangCodes.Count; k++)
            {
                ToolStripMenuItem ti = new ToolStripMenuItem();
                ti.Text = frmLanguage.LangDesc[k];
                ti.Tag = frmLanguage.LangCodes[k];
                ti.Image = frmLanguage.LangImg[k];

                if (Module.SelectedLanguage == frmLanguage.LangCodes[k])
                {
                    ti.Checked = true;
                }

                ti.Click += new EventHandler(tiLang_Click);
                languageToolStripMenuItem.DropDownItems.Add(ti);
            }
        }

        void tiLang_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ti = (ToolStripMenuItem)sender;
            string langcode = ti.Tag.ToString();
            ChangeLanguage(langcode);

            for (int k = 0; k < languageToolStripMenuItem.DropDownItems.Count; k++)
            {
                ToolStripMenuItem til = (ToolStripMenuItem)languageToolStripMenuItem.DropDownItems[k];
                if (til == ti)
                {
                    til.Checked = true;
                }
                else
                {
                    til.Checked = false;
                }
            }
        }

        private void ChangeLanguage(string language_code)
        {
            Properties.Settings.Default.Language = language_code;
            frmLanguage.SetLanguage();

            Properties.Settings.Default.Save();
            Module.ShowMessage("Please restart the application !");
            Application.Exit();
            return;

            bool maximized = (this.WindowState == FormWindowState.Maximized);
            this.WindowState = FormWindowState.Normal;

            SaveSizeLocation();

            this.Controls.Clear();

            InitializeComponent();

            SetupOnLoad();

            if (maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            this.ResumeLayout(true);
        }

        #endregion
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout f = new frmAbout();
            f.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Module.DialogFilesFilter;
            openFileDialog1.Multiselect = true;
            
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    for (int k = 0; k < openFileDialog1.FileNames.Length; k++)
                    {                        
                        AddFile(openFileDialog1.FileNames[k]);
                    }
                }
                finally
                {
                    this.Cursor = null;
                }
            }
        }

        public bool AddFile(string filepath)
        {
            return AddFile(filepath, "","");
        }

        public bool AddFile(string filepath, string password)
        {
            return AddFile(filepath, password, "");
        }

        public bool AddFile(string filepath,string password,string rootfolder)
        {
            if (filepath.Trim() == string.Empty) return false;

            if (System.IO.Path.GetExtension(filepath).ToLower() != ".pdf")
            {
                if (!SilentAdd)
                {
                    Module.ShowMessage("Please add only PDF Files !");
                }
                return false;
            }

            DataRow dr = dt.NewRow();
                        
            FileInfo fi=new FileInfo(filepath);

            long sizekb=fi.Length/1024;
            dr["filename"]=fi.Name;
            dr["fullfilepath"] = filepath;
            dr["sizekb"] = sizekb.ToString() + "KB";
            dr["filedate"] = fi.LastWriteTime.ToString();
            dr["rootfolder"] = rootfolder;

            if (password != string.Empty)
            {
                dr["userpassword"] = password;
            }
            dt.Rows.Add(dr);

            return true;
        }                                                                

        private void btnAddFolder_Click(object sender, EventArgs e)
        {            
            folderBrowserDialog1.SelectedPath = "";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                AddFolder(folderBrowserDialog1.SelectedPath);   
            }
        }

        public void AddFolder(string folder_path)
        {
            AddFolder(folder_path, "");
        }

        public void AddFolder(string folder_path,string password)
        {
            string[] filez = null;

            if (Module.IsCommandLine)
            {
                if (Module.CmdAddSubdirectories)
                {
                    filez = System.IO.Directory.GetFiles(folder_path, "*.pdf", SearchOption.AllDirectories);
                }
                else
                {
                    filez = System.IO.Directory.GetFiles(folder_path, "*.pdf", SearchOption.TopDirectoryOnly);
                }
            }
            else
            {
                if (!SilentAdd)
                {
                    if (System.IO.Directory.GetDirectories(folder_path).Length > 0)
                    {
                        DialogResult dres = Module.ShowQuestionDialog("Would you like to add also Subdirectories ?", TranslateHelper.Translate("Add Subdirectories ?"));

                        if (dres == DialogResult.Yes)
                        {
                            filez = System.IO.Directory.GetFiles(folder_path, "*.pdf", SearchOption.AllDirectories);
                        }
                        else
                        {
                            filez = System.IO.Directory.GetFiles(folder_path, "*.pdf", SearchOption.TopDirectoryOnly);
                        }
                    }
                    else
                    {
                        filez = System.IO.Directory.GetFiles(folder_path, "*.pdf", SearchOption.TopDirectoryOnly);
                    }
                }
                else
                {
                    // silent add for import list
                    filez = System.IO.Directory.GetFiles(folder_path, "*.pdf", SearchOption.AllDirectories);
                }

            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                for (int k = 0; k < filez.Length; k++)
                {
                    if (filez[k].ToLower().EndsWith(".pdf"))
                    {
                        AddFile(filez[k],password,folder_path);
                    }
                    
                }
            }
            finally
            {
                this.Cursor = null;
            }

        }                              

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection cells = dgFiles.SelectedCells;
            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            for (int k = 0; k < cells.Count; k++)
            {
                if (rows.IndexOf(dgFiles.Rows[cells[k].RowIndex]) < 0)
                {
                    rows.Add(dgFiles.Rows[cells[k].RowIndex]);
                }
            }

            for (int k = 0; k < rows.Count; k++)
            {
                dgFiles.Rows.Remove(rows[k]);
            }
                       
        }

        private void tiHelpFeedback_Click(object sender, EventArgs e)
        {
            /*
            frmUninstallQuestionnaire f = new frmUninstallQuestionnaire(false);
            f.ShowDialog();
            */

            System.Diagnostics.Process.Start("https://www.4dots-software.com/support/bugfeature.php?app=" + System.Web.HttpUtility.UrlEncode(Module.ShortApplicationTitle));
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgFiles.CurrentRow==null) return;

            System.Diagnostics.Process.Start(dgFiles.CurrentRow.Cells["colFullFilepath"].Value.ToString());

        }               

        private bool IsDragging = false;

        /*
        private void lvDocs_DragOver(object sender, DragEventArgs e)
        {
            
        }

        private void lvDocs_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop,false))
            {
                IsDragging = true;
                e.Effect = DragDropEffects.All;

            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void lvDocs_DragDrop(object sender, DragEventArgs e)
        {           

            Point pt = lvDocs.PointToClient(Cursor.Position);
            ListViewHitTestInfo hiti = lvDocs.HitTest(pt.X, pt.Y);

            //if (hiti.Item != null)
            //{

            int ind = -1;
            if (hiti.Item != null)
            {
                ind = hiti.Item.Index;
            }

            List<ListViewItem> lst = new List<ListViewItem>();

            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] filez = (string[])e.Data.GetData(DataFormats.FileDrop);

                for (int k = 0; k < filez.Length; k++)
                {
                    bool isimage = false;                                        

                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        AddFile(filez[k]);
                    }
                    finally
                    {
                        this.Cursor = null;
                    }

                    lst.Add(lvDocs.Items[lvDocs.Items.Count - 1]);
                }

                if (hiti.Item != null && (lvDocs.Items.Count != lst.Count))
                {
                    for (int k = 0; k < lst.Count; k++)
                    {
                        lvDocs.Items.Remove(lst[k]);
                    }

                    for (int k = 0; k < lst.Count; k++)
                    {
                        lvDocs.Items.Insert(ind + k, lst[k]);
                    }
                }
            }


            //}

        }
        */                                                             

        private void buyNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Module.StoreUrl);
        }
                
        /*
        protected override void WndProc(ref Message m)
        {            

            if (m.Msg == MessageHelper.WM_COPYDATA)
            {
                MessageHelper.COPYDATASTRUCT mystr = new MessageHelper.COPYDATASTRUCT();
                Type mytype = mystr.GetType();
                mystr = (MessageHelper.COPYDATASTRUCT)m.GetLParam(mytype);
                //MessageBox.Show(mystr.lpData);

                string arg = mystr.lpData;

                //MessageBox.Show("RECEIVED MESSAGE :" + arg);
                string[] args = arg.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

                //frmClientImages.Instance.ShowSendToMenuForm(args);
                for (int n = 1; n <= args.GetUpperBound(0); n++)
                {
                    //MessageBox.Show(args[n]);
                }

                AddVisual(args);


            }
            else if (m.Msg == MessageHelper.WM_ACTIVATEAPP)
            {
                this.WindowState = FormWindowState.Normal;
                this.Show();
            }



            base.WndProc(ref m);
        }
        */
        private void helpGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Module.HelpURL);
        }

        private void btnClearMerge_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();                        
            
        }


        private void CompressDecompressPDF(bool compress)
        {
            
        }

        private bool CompressImages = true;
        private int ImagesQuality = 25;
        private string OutputDir = "";
        private bool OverwritePDF = false;
        private bool KeepBackup = false;

        private void btnCompressPDF_Click(object sender, EventArgs e)
        {
            //=========

            Properties.Settings.Default.ExploreOutputFolder = exploreOutputFolderWhenDoneToolStripMenuItem.Checked;


            Properties.Settings.Default.KeepCreationDate = keepCreationDateToolStripMenuItem.Checked;


            Properties.Settings.Default.KeepLastModificatonDate = keepLastModificationDateToolStripMenuItem.Checked;


            Properties.Settings.Default.ShowMessageOnSucess = showMessageOnSuccessToolStripMenuItem.Checked;


            Properties.Settings.Default.ShowResultWindow = showResultWindowToolStripMenuItem.Checked;

            bool compress = true;
            rdCompress.Checked = compress;
            rdDecompress.Checked = !compress;

            try
            {
                dgFiles.EndEdit();
                dgFiles.BindingContext[dt].EndCurrentEdit();


                if (dt.Rows.Count == 0)
                {
                    Module.ShowMessage("Please add PDF Files first !");
                    return;
                }

                //this.Enabled = false;

                EnableDisableForm(false);

                frmProgress.Instance.progressBar1.Maximum = dt.Rows.Count;
                frmProgress.Instance.progressBar1.Value = 0;
                
                CompressImages= frmMain.Instance.chkImages.Checked;
                ImagesQuality = (int)frmMain.Instance.nudQuality.Value;
                OutputDir = cmbOutputDir.Text;
                KeepBackup = false;

                Properties.Settings.Default.InvertImages = chkInvert.Checked;
                Properties.Settings.Default.InvertImages2 = chkInvert2.Checked;

                Properties.Settings.Default.Grayscale = chkGrayscale.Checked;

                Properties.Settings.Default.BlackAndWhite = chkBlackWhiteImages.Checked;


                if (OutputDir == TranslateHelper.Translate("Overwrite PDF Document"))
                {
                    OverwritePDF = true;
                    KeepBackup = chkKeepBackup.Checked;
                }
                else
                {
                    OverwritePDF = false;
                }

                OutputFolderHelper.SaveOutputFolder(cmbOutputDir.Text);

                frmProgress.Instance.Secs = 0;
                frmProgress.Instance.timTime.Enabled = true;

                //this.Enabled = false;

                EnableDisableForm(false);

                frmProgress.Instance.Show(this);                
                
                bwCompress.RunWorkerAsync();
                                                
                while (bwCompress.IsBusy)
                {
                    Application.DoEvents();
                    //System.Threading.Thread.Sleep(100);
                    
                }

                frmProgress.Instance.timTime.Enabled = false;
                frmProgress.Instance.Hide();

                //this.Enabled = true;

                EnableDisableForm(true);

                if (PDFCompressHelper.CANCELLED)
                {
                    Module.ShowMessage("Operation Cancelled !");
                    return;
                }

                if (PDFCompressHelper.ErrMultiple == String.Empty)
                {
                    if (Properties.Settings.Default.ShowMessageOnSucess)
                    {
                        Module.ShowMessage("Operation completed successfully !");
                    }

                    if (Properties.Settings.Default.ExploreOutputFolder)
                    {
                        btnOpenFolder_Click(null, null);
                    }
                }
                else
                {
                    frmMessage f = new frmMessage();
                    f.lblMsg.Text = TranslateHelper.Translate("Operation completed with Errors !");
                    f.txtMsg.Text = PDFCompressHelper.ErrMultiple;

                    f.Show(this);
                }

                if (Properties.Settings.Default.ShowResultWindow)
                {
                    if (!(PDFCompressHelper.BytesBefore == 0 && PDFCompressHelper.BytesAfter == 0))
                    {
                        frmResult frmres = new frmResult(PDFCompressHelper.BytesBefore, PDFCompressHelper.BytesAfter);
                        //frmres.ShowDialog();

                        frmres.Show(this);
                    }
                }
            }
            catch (Exception ex)
            {
                Module.ShowError("Error", ex);
            }
            finally
            {
                //this.Enabled = true;
                EnableDisableForm(true);
                this.BringToFront();
            }

            

            
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            /*
            int bsize = btnEncrypt.Width + 20 + btnExit.Width;
            btnEncrypt.Left = (this.ClientRectangle.Width / 2) - (bsize / 2);
            btnExit.Left = btnEncrypt.Right + 20;
            */
            
        }

        private void dgFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] filez = (string[])e.Data.GetData(DataFormats.FileDrop);

                for (int k = 0; k < filez.Length; k++)
                {
                    bool isimage = false;

                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        AddFile(filez[k]);
                    }
                    finally
                    {
                        this.Cursor = null;
                    }                    
                }                
            }

        }

        private void dgFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                IsDragging = true;
                e.Effect = DragDropEffects.All;

            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void dgFiles_DragOver(object sender, DragEventArgs e)
        {
            IsDragging = true;
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }                

        private void visit4dotsSoftwareWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.4dots-software.com");
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            dgFiles.EndEdit();

            if (dt.Rows.Count == 0)
            {
                Module.ShowMessage("Please add a PDF File first !");

            }
            else
            {
                string dirpath = "";
                string filepath = "";
                string outfilepath = "";

                if (dgFiles.SelectedCells.Count == 0)
                {
                    filepath = dgFiles.Rows[0].Cells["colFullfilepath"].Value.ToString();
                }
                else
                {
                    filepath = dgFiles.SelectedCells[0].OwningRow.Cells["colFullfilepath"].Value.ToString();
                }

                if (frmMain.Instance.cmbOutputDir.Text.Trim() == TranslateHelper.Translate("Same Folder of PDF Document"))
                {
                    dirpath = System.IO.Path.GetDirectoryName(filepath);

                    if (rdCompress.Checked)
                    {
                        outfilepath = System.IO.Path.Combine(dirpath, System.IO.Path.GetFileNameWithoutExtension(filepath) + "_compressed.pdf");
                    }
                    else if (rdDecompress.Checked)
                    {
                        outfilepath = System.IO.Path.Combine(dirpath, System.IO.Path.GetFileNameWithoutExtension(filepath) + "_decompressed.pdf");
                    }
                }
                else if (frmMain.Instance.cmbOutputDir.Text.ToString().StartsWith(TranslateHelper.Translate("Subfolder") + " : "))
                {
                    int subfolderspos = (TranslateHelper.Translate("Subfolder") + " : ").Length;
                    string subfolder = frmMain.Instance.cmbOutputDir.Text.ToString().Substring(subfolderspos);

                    outfilepath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(filepath) + "\\" + subfolder, System.IO.Path.GetFileName(filepath));
                }
                else if (frmMain.Instance.cmbOutputDir.Text.Trim() == TranslateHelper.Translate("Overwrite PDF Document"))
                {
                    outfilepath = filepath;
                }
                else
                {
                    outfilepath = System.IO.Path.Combine(frmMain.Instance.cmbOutputDir.Text, System.IO.Path.GetFileName(filepath));
                }

                string args = string.Format("/e, /select, \"{0}\"", outfilepath);
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = "explorer";
                info.UseShellExecute = true;
                info.Arguments = args;
                Process.Start(info);
            }
        }

        private void btnChangeFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                OutputFolderHelper.SaveOutputFolder(folderBrowserDialog2.SelectedPath);
            }
        }

        

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            frmProgress fp = new frmProgress();
            fp.Show();

            while (true)
            {
                if (bwCompress.CancellationPending)
                {
                    fp.Close();
                    return;
                }

                Application.DoEvents();
                
            }
        }                   

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSizeLocation();

            Properties.Settings.Default.KeepFolderStructure = keepFolderStructureToolStripMenuItem.Checked;

            Properties.Settings.Default.KeepBackup = chkKeepBackup.Checked;
            Properties.Settings.Default.OutputFolderIndex = cmbOutputDir.SelectedIndex;
            Properties.Settings.Default.CompressImages=chkImages.Checked;
            Properties.Settings.Default.ImageQuality = (int)nudQuality.Value;

            Properties.Settings.Default.InvertImages = chkInvert.Checked;
            Properties.Settings.Default.InvertImages2 = chkInvert2.Checked;

            Properties.Settings.Default.Grayscale = chkGrayscale.Checked;

            Properties.Settings.Default.BlackAndWhite = chkBlackWhiteImages.Checked;

            Properties.Settings.Default.CheckWeek = checkForNewVersionEachWeekToolStripMenuItem.Checked;

            //=========

            Properties.Settings.Default.ExploreOutputFolder = exploreOutputFolderWhenDoneToolStripMenuItem.Checked;


            Properties.Settings.Default.KeepCreationDate = keepCreationDateToolStripMenuItem.Checked;


            Properties.Settings.Default.KeepLastModificatonDate = keepLastModificationDateToolStripMenuItem.Checked;


            Properties.Settings.Default.ShowMessageOnSucess = showMessageOnSuccessToolStripMenuItem.Checked;


            Properties.Settings.Default.ShowResultWindow = showResultWindowToolStripMenuItem.Checked;
                

            Properties.Settings.Default.Save();
        }

        private void cmbOutputDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkKeepBackup.Visible = false;

            if (cmbOutputDir.SelectedIndex == 4)
            {
                Module.ShowMessage("Please specify another option as the Output Folder !");
                cmbOutputDir.SelectedIndex = Properties.Settings.Default.OutputFolderIndex;
            }
            else if (cmbOutputDir.SelectedIndex == 2)
            {
                frmOutputSubFolder fob = new frmOutputSubFolder();

                if (fob.ShowDialog() == DialogResult.OK)
                {
                    OutputFolderHelper.SaveOutputFolder(TranslateHelper.Translate("Subfolder") + " : " + fob.txtSubfolder.Text);
                }
                else
                {
                    return;
                }
            }
            else if (cmbOutputDir.SelectedIndex == 1)
            {
                chkKeepBackup.Visible = true;
            }
        }               
                
        private void exploreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgFiles.CurrentRow==null) return;

            string filepath = dgFiles.CurrentRow.Cells["colFullFilepath"].Value.ToString();            

            string args = string.Format("/e, /select, \"{0}\"", filepath);
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "explorer";
            info.UseShellExecute = true;
            info.Arguments = args;
            Process.Start(info);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            Point p = dgFiles.PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
            DataGridView.HitTestInfo hit=dgFiles.HitTest(p.X,p.Y);

            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                dgFiles.CurrentCell = dgFiles.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
            }
            
            if (dgFiles.CurrentRow==null)
            {
                e.Cancel = true;
            }
        }               

        private void followUsOnTwitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.twitter.com/4dotsSoftware");
        }

        private void tsbDecompress_Click(object sender, EventArgs e)
        {
            CompressDecompressPDF(false);
        }

        private void txtImageQuality_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void tbQuality_ValueChanged(object sender, EventArgs e)
        {
            nudQuality.Value = tbQuality.Value;
        }

        private void nudQuality_ValueChanged(object sender, EventArgs e)
        {
            tbQuality.Value = (int)nudQuality.Value;
        }

        private void chkImages_CheckedChanged(object sender, EventArgs e)
        {
            grpImageQuality.Enabled = chkImages.Checked;
        }

        public bool SilentAdd = false;
        public string SilentAddErr = "";

        public void ImportList(string listfilepath)
        {
            string curdir = Environment.CurrentDirectory;

            try
            {
                SilentAdd = true;
                using (StreamReader sr = new StreamReader(listfilepath,Encoding.Default,true))
                {
                    string line = null;

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.StartsWith("#"))
                        {
                            continue;
                        }

                        string filepath = line;
                        string password = "";

                        try
                        {
                            if (line.StartsWith("\""))
                            {
                                int epos = line.IndexOf("\"", 1);

                                if (epos > 0)
                                {
                                    filepath = line.Substring(1, epos - 1);
                                }
                            }
                            else if (line.StartsWith("'"))
                            {
                                int epos = line.IndexOf("'", 1);

                                if (epos > 0)
                                {
                                    filepath = line.Substring(1, epos - 1);
                                }
                            }

                            int compos = line.IndexOf(",");

                            if (compos > 0)
                            {
                                password = line.Substring(compos + 1);

                                if (!line.StartsWith("\"") && !line.StartsWith("'"))
                                {
                                    filepath = line.Substring(0, compos);
                                }

                                if ((password.StartsWith("\"") && password.EndsWith("\""))
                                    || (password.StartsWith("'") && password.EndsWith("'")))
                                {
                                    if (password.Length == 2)
                                    {
                                        password = "";
                                    }
                                    else
                                    {
                                        password = password.Substring(1, password.Length - 2);
                                    }
                                }
                                
                            }
                        }
                        catch (Exception exq)
                        {
                            SilentAddErr += TranslateHelper.Translate("Error while processing List !") + " " + line + " " + exq.Message + "\r\n";
                        }

                        line = filepath;

                        Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(listfilepath);

                        line = System.IO.Path.GetFullPath(line);

                        if (System.IO.File.Exists(line))
                        {
                            if (System.IO.Path.GetExtension(line).ToLower() == ".pdf")
                            {
                                AddFile(line, password);
                            }
                            else
                            {
                                SilentAddErr += TranslateHelper.Translate("Error wrong file type !") + " " + line + "\r\n";
                            }
                        }
                        else if (System.IO.Directory.Exists(line))
                        {
                            AddFolder(line, password);
                        }
                        else
                        {
                            SilentAddErr += TranslateHelper.Translate("Error. File or Directory not found !") + " " + line + "\r\n";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SilentAddErr += TranslateHelper.Translate("Error could not read file !") + " " + ex.Message + "\r\n";
            }
            finally
            {
                Environment.CurrentDirectory = curdir;

                SilentAdd = false;
            }
        }

        private void tsbImportList_Click(object sender, EventArgs e)
        {
            SilentAddErr = "";

            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImportList(openFileDialog1.FileName);

                if (SilentAddErr != string.Empty)
                {
                    frmMessage f = new frmMessage();
                    f.txtMsg.Text = SilentAddErr;
                    f.ShowDialog();
                    
                }
            }
        }

        private void bwCompress_DoWork(object sender, DoWorkEventArgs e)
        {            
           PDFCompressHelper.ErrMultiple = PDFCompressHelper.CompressDecompressMultiplePDF(dt, OutputDir, CompressImages, ImagesQuality, OverwritePDF, KeepBackup);
         
        }

        private void bwCompress_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (frmProgress.Instance.progressBar1.Value < frmProgress.Instance.progressBar1.Maximum)
            {
                frmProgress.Instance.progressBar1.Value++;
            }
        }

        private void bwCompress_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        #region Share

        private void tsiFacebook_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareFacebook();
        }

        private void tsiTwitter_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareTwitter();
        }

        private void tsiGooglePlus_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareGooglePlus();
        }

        private void tsiLinkedIn_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareLinkedIn();
        }

        private void tsiEmail_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareEmail();
        }

        #endregion

        private void EnableDisableForm(bool enable)
        {
            foreach (Control co in this.Controls)
            {
                co.Enabled = enable;
            }
        }
        private void tsdbAddFile_ButtonClick(object sender, EventArgs e)
        {

        }

        private void tsdbAddFile_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                AddFile(e.ClickedItem.Text);
                RecentFilesHelper.AddRecentFile(e.ClickedItem.Text);

            }
            finally
            {
                this.Cursor = null;
            }
        }

        private void tsdbAddFolder_ButtonClick(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = "";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                AddFolder(folderBrowserDialog1.SelectedPath);
                RecentFilesHelper.AddRecentFolder(folderBrowserDialog1.SelectedPath);
            }
        }

        private void tsdbAddFolder_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            AddFolder(e.ClickedItem.Text, "");
            RecentFilesHelper.AddRecentFolder(e.ClickedItem.Text);
        }

        private void tsdbImportList_ButtonClick(object sender, EventArgs e)
        {
            SilentAddErr = "";

            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImportList(openFileDialog1.FileName);
                RecentFilesHelper.ImportListRecent(openFileDialog1.FileName);

                if (SilentAddErr != string.Empty)
                {
                    frmMessage f = new frmMessage();
                    f.txtMsg.Text = SilentAddErr;
                    f.ShowDialog();

                }
            }
        }

        private void tsdbImportList_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {            
            SilentAddErr = "";

            ImportList(e.ClickedItem.Text);
            RecentFilesHelper.ImportListRecent(e.ClickedItem.Text);

            if (SilentAddErr != string.Empty)
            {
                frmMessage f = new frmMessage();
                f.txtMsg.Text = SilentAddErr;
                f.ShowDialog();

            }
        }

        private void keepFolderStructureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            keepFolderStructureToolStripMenuItem.Checked = !keepFolderStructureToolStripMenuItem.Checked;

            Properties.Settings.Default.KeepFolderStructure = keepFolderStructureToolStripMenuItem.Checked;
        }

        private void luminatiHelperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void doNotAskForPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DoNotAskForPassword = doNotAskForPasswordToolStripMenuItem.Checked;
        }

        private void enterFileListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string txt = "";

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                txt += dt.Rows[k]["fullfilepath"].ToString() + "\r\n";
            }

            frmMultipleFiles f = new frmMultipleFiles(false, txt);

            if (f.ShowDialog() == DialogResult.OK)
            {
                dt.Rows.Clear();

                for (int k = 0; k < f.txtFiles.Lines.Length; k++)
                {
                    AddFile(f.txtFiles.Lines[k].Trim());
                }
            }

        }

        private void saveFileListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
            {
                Module.ShowMessage("Current Selection is Empty !");
                return;
            }

            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.Default))
                {
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {                        
                        sw.WriteLine(dt.Rows[k]["fullfilepath"].ToString());
                    }
                }
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int k=0;k<dgFiles.Rows.Count;k++)
            {
                dgFiles.Rows[k].Selected = true;
            }
        }

        private void selectNoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < dgFiles.Rows.Count; k++)
            {
                dgFiles.Rows[k].Selected = false;
            }
        }

        private void invertSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < dgFiles.Rows.Count; k++)
            {
                dgFiles.Rows[k].Selected = !dgFiles.Rows[k].Selected;
            }
        }

        private void importFromExcelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Excel Files (*.xls;*.xlsx;*.xlt)|*.xls;*.xlsx;*.xlt";
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ExcelImporter xl = new ExcelImporter();
                xl.ImportListExcel(openFileDialog1.FileName);
            }
        }

        private void youtubeChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCovA-lld9Q79l08K-V1QEng");
        }

        private void donateViaPaypalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.4dots-software.com/donate.php");
        }

        private void tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://onlinepdfapps.com");
        }

        private void commandLineArgumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMessage fm = new frmMessage(true);
            fm.ShowDialog(this);
        }
    }
}

