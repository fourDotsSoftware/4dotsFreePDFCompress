namespace _4dotsFreePDFCompress
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentsMedataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.bwCompress = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnChangeFolder = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.chkImages = new System.Windows.Forms.CheckBox();
            this.grpImageQuality = new System.Windows.Forms.GroupBox();
            this.nudQuality = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tbQuality = new System.Windows.Forms.TrackBar();
            this.rdDecompress = new System.Windows.Forms.RadioButton();
            this.rdCompress = new System.Windows.Forms.RadioButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsdbAddFile = new System.Windows.Forms.ToolStripSplitButton();
            this.tsbRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsdbAddFolder = new System.Windows.Forms.ToolStripSplitButton();
            this.tsdbImportList = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbShare = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsiFacebook = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiTwitter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiGooglePlus = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiLinkedIn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCompress = new System.Windows.Forms.ToolStripButton();
            this.dgFiles = new System.Windows.Forms.DataGridView();
            this.colFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFileDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkKeepBackup = new System.Windows.Forms.CheckBox();
            this.cmbOutputDir = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.importFromTextFileListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromExcelFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.enterFileListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectNoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepFolderStructureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doNotAskForPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepCreationDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepLastModificationDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreOutputFolderWhenDoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMessageOnSuccessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showResultWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandLineArgumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateViaPaypalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForNewVersionEachWeekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiHelpFeedback = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.youtubeChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.followUsOnTwitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visit4dotsSoftwareWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkInvert = new System.Windows.Forms.CheckBox();
            this.chkInvert2 = new System.Windows.Forms.CheckBox();
            this.chkBlackWhiteImages = new System.Windows.Forms.CheckBox();
            this.chkGrayscale = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this.grpImageQuality.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbQuality)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exploreToolStripMenuItem,
            this.documentsMedataToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::_4dotsFreePDFCompress.Properties.Resources.folder;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exploreToolStripMenuItem
            // 
            this.exploreToolStripMenuItem.Name = "exploreToolStripMenuItem";
            resources.ApplyResources(this.exploreToolStripMenuItem, "exploreToolStripMenuItem");
            this.exploreToolStripMenuItem.Click += new System.EventHandler(this.exploreToolStripMenuItem_Click);
            // 
            // documentsMedataToolStripMenuItem
            // 
            this.documentsMedataToolStripMenuItem.Image = global::_4dotsFreePDFCompress.Properties.Resources.information;
            this.documentsMedataToolStripMenuItem.Name = "documentsMedataToolStripMenuItem";
            resources.ApplyResources(this.documentsMedataToolStripMenuItem, "documentsMedataToolStripMenuItem");
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Image = global::_4dotsFreePDFCompress.Properties.Resources.delete;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            resources.ApplyResources(this.removeToolStripMenuItem, "removeToolStripMenuItem");
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // bwCompress
            // 
            this.bwCompress.WorkerReportsProgress = true;
            this.bwCompress.WorkerSupportsCancellation = true;
            this.bwCompress.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwCompress_DoWork);
            this.bwCompress.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwCompress_ProgressChanged);
            this.bwCompress.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwCompress_RunWorkerCompleted);
            // 
            // btnChangeFolder
            // 
            resources.ApplyResources(this.btnChangeFolder, "btnChangeFolder");
            this.btnChangeFolder.Name = "btnChangeFolder";
            this.toolTip1.SetToolTip(this.btnChangeFolder, resources.GetString("btnChangeFolder.ToolTip"));
            this.btnChangeFolder.UseVisualStyleBackColor = true;
            this.btnChangeFolder.Click += new System.EventHandler(this.btnChangeFolder_Click);
            // 
            // btnOpenFolder
            // 
            resources.ApplyResources(this.btnOpenFolder, "btnOpenFolder");
            this.btnOpenFolder.Image = global::_4dotsFreePDFCompress.Properties.Resources.folder1;
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.toolTip1.SetToolTip(this.btnOpenFolder, resources.GetString("btnOpenFolder.ToolTip"));
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // chkImages
            // 
            resources.ApplyResources(this.chkImages, "chkImages");
            this.chkImages.BackColor = System.Drawing.Color.Transparent;
            this.chkImages.Checked = true;
            this.chkImages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImages.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkImages.Name = "chkImages";
            this.chkImages.UseVisualStyleBackColor = false;
            this.chkImages.CheckedChanged += new System.EventHandler(this.chkImages_CheckedChanged);
            // 
            // grpImageQuality
            // 
            resources.ApplyResources(this.grpImageQuality, "grpImageQuality");
            this.grpImageQuality.BackColor = System.Drawing.Color.Transparent;
            this.grpImageQuality.Controls.Add(this.nudQuality);
            this.grpImageQuality.Controls.Add(this.label1);
            this.grpImageQuality.Controls.Add(this.tbQuality);
            this.grpImageQuality.Name = "grpImageQuality";
            this.grpImageQuality.TabStop = false;
            // 
            // nudQuality
            // 
            resources.ApplyResources(this.nudQuality, "nudQuality");
            this.nudQuality.Name = "nudQuality";
            this.nudQuality.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudQuality.ValueChanged += new System.EventHandler(this.nudQuality_ValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tbQuality
            // 
            resources.ApplyResources(this.tbQuality, "tbQuality");
            this.tbQuality.BackColor = System.Drawing.Color.White;
            this.tbQuality.Maximum = 100;
            this.tbQuality.Name = "tbQuality";
            this.tbQuality.TickFrequency = 10;
            this.tbQuality.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbQuality.Value = 25;
            this.tbQuality.ValueChanged += new System.EventHandler(this.tbQuality_ValueChanged);
            // 
            // rdDecompress
            // 
            resources.ApplyResources(this.rdDecompress, "rdDecompress");
            this.rdDecompress.BackColor = System.Drawing.Color.Transparent;
            this.rdDecompress.Name = "rdDecompress";
            this.rdDecompress.UseVisualStyleBackColor = false;
            // 
            // rdCompress
            // 
            resources.ApplyResources(this.rdCompress, "rdCompress");
            this.rdCompress.BackColor = System.Drawing.Color.Transparent;
            this.rdCompress.Checked = true;
            this.rdCompress.Name = "rdCompress";
            this.rdCompress.TabStop = true;
            this.rdCompress.UseVisualStyleBackColor = false;
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsdbAddFile,
            this.tsbRemove,
            this.toolStripSeparator3,
            this.tsdbAddFolder,
            this.tsdbImportList,
            this.toolStripSeparator2,
            this.tsbShare,
            this.toolStripSeparator1,
            this.tsbCompress});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // tsdbAddFile
            // 
            resources.ApplyResources(this.tsdbAddFile, "tsdbAddFile");
            this.tsdbAddFile.Image = global::_4dotsFreePDFCompress.Properties.Resources.add2;
            this.tsdbAddFile.Name = "tsdbAddFile";
            this.tsdbAddFile.ButtonClick += new System.EventHandler(this.btnAddFiles_Click);
            this.tsdbAddFile.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsdbAddFile_DropDownItemClicked);
            // 
            // tsbRemove
            // 
            resources.ApplyResources(this.tsbRemove, "tsbRemove");
            this.tsbRemove.Image = global::_4dotsFreePDFCompress.Properties.Resources.delete1;
            this.tsbRemove.Name = "tsbRemove";
            this.tsbRemove.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // tsdbAddFolder
            // 
            resources.ApplyResources(this.tsdbAddFolder, "tsdbAddFolder");
            this.tsdbAddFolder.Image = global::_4dotsFreePDFCompress.Properties.Resources.folder_add1;
            this.tsdbAddFolder.Name = "tsdbAddFolder";
            this.tsdbAddFolder.ButtonClick += new System.EventHandler(this.tsdbAddFolder_ButtonClick);
            this.tsdbAddFolder.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsdbAddFolder_DropDownItemClicked);
            // 
            // tsdbImportList
            // 
            resources.ApplyResources(this.tsdbImportList, "tsdbImportList");
            this.tsdbImportList.Image = global::_4dotsFreePDFCompress.Properties.Resources.import1;
            this.tsdbImportList.Name = "tsdbImportList";
            this.tsdbImportList.ButtonClick += new System.EventHandler(this.tsdbImportList_ButtonClick);
            this.tsdbImportList.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsdbImportList_DropDownItemClicked);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // tsbShare
            // 
            resources.ApplyResources(this.tsbShare, "tsbShare");
            this.tsbShare.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiFacebook,
            this.tsiTwitter,
            this.tsiGooglePlus,
            this.tsiLinkedIn,
            this.tsiEmail});
            this.tsbShare.Image = global::_4dotsFreePDFCompress.Properties.Resources.facebook_24;
            this.tsbShare.Name = "tsbShare";
            // 
            // tsiFacebook
            // 
            this.tsiFacebook.Image = global::_4dotsFreePDFCompress.Properties.Resources.facebook_24;
            this.tsiFacebook.Name = "tsiFacebook";
            resources.ApplyResources(this.tsiFacebook, "tsiFacebook");
            this.tsiFacebook.Click += new System.EventHandler(this.tsiFacebook_Click);
            // 
            // tsiTwitter
            // 
            this.tsiTwitter.Image = global::_4dotsFreePDFCompress.Properties.Resources.twitter_24;
            this.tsiTwitter.Name = "tsiTwitter";
            resources.ApplyResources(this.tsiTwitter, "tsiTwitter");
            this.tsiTwitter.Click += new System.EventHandler(this.tsiTwitter_Click);
            // 
            // tsiGooglePlus
            // 
            this.tsiGooglePlus.Image = global::_4dotsFreePDFCompress.Properties.Resources.googleplus_24;
            this.tsiGooglePlus.Name = "tsiGooglePlus";
            resources.ApplyResources(this.tsiGooglePlus, "tsiGooglePlus");
            this.tsiGooglePlus.Click += new System.EventHandler(this.tsiGooglePlus_Click);
            // 
            // tsiLinkedIn
            // 
            this.tsiLinkedIn.Image = global::_4dotsFreePDFCompress.Properties.Resources.linkedin_24;
            this.tsiLinkedIn.Name = "tsiLinkedIn";
            resources.ApplyResources(this.tsiLinkedIn, "tsiLinkedIn");
            this.tsiLinkedIn.Click += new System.EventHandler(this.tsiLinkedIn_Click);
            // 
            // tsiEmail
            // 
            this.tsiEmail.Image = global::_4dotsFreePDFCompress.Properties.Resources.mail;
            this.tsiEmail.Name = "tsiEmail";
            resources.ApplyResources(this.tsiEmail, "tsiEmail");
            this.tsiEmail.Click += new System.EventHandler(this.tsiEmail_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // tsbCompress
            // 
            resources.ApplyResources(this.tsbCompress, "tsbCompress");
            this.tsbCompress.ForeColor = System.Drawing.Color.DarkBlue;
            this.tsbCompress.Image = global::_4dotsFreePDFCompress.Properties.Resources.package1;
            this.tsbCompress.Name = "tsbCompress";
            this.tsbCompress.Click += new System.EventHandler(this.btnCompressPDF_Click);
            // 
            // dgFiles
            // 
            this.dgFiles.AllowDrop = true;
            this.dgFiles.AllowUserToAddRows = false;
            this.dgFiles.AllowUserToDeleteRows = false;
            this.dgFiles.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dgFiles, "dgFiles");
            this.dgFiles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(227)))));
            this.dgFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFilename,
            this.colUserPassword,
            this.colSize,
            this.colFileDate,
            this.colFullFilePath});
            this.dgFiles.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgFiles.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgFiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgFiles.GridColor = System.Drawing.Color.Black;
            this.dgFiles.Name = "dgFiles";
            this.dgFiles.RowHeadersVisible = false;
            this.dgFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragDrop);
            this.dgFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragEnter);
            this.dgFiles.DragOver += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragOver);
            // 
            // colFilename
            // 
            this.colFilename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFilename.DataPropertyName = "filename";
            resources.ApplyResources(this.colFilename, "colFilename");
            this.colFilename.Name = "colFilename";
            this.colFilename.ReadOnly = true;
            // 
            // colUserPassword
            // 
            this.colUserPassword.DataPropertyName = "userpassword";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.colUserPassword.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.colUserPassword, "colUserPassword");
            this.colUserPassword.Name = "colUserPassword";
            // 
            // colSize
            // 
            this.colSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSize.DataPropertyName = "sizekb";
            resources.ApplyResources(this.colSize, "colSize");
            this.colSize.Name = "colSize";
            this.colSize.ReadOnly = true;
            // 
            // colFileDate
            // 
            this.colFileDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFileDate.DataPropertyName = "filedate";
            resources.ApplyResources(this.colFileDate, "colFileDate");
            this.colFileDate.Name = "colFileDate";
            this.colFileDate.ReadOnly = true;
            // 
            // colFullFilePath
            // 
            this.colFullFilePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFullFilePath.DataPropertyName = "fullfilepath";
            resources.ApplyResources(this.colFullFilePath, "colFullFilePath");
            this.colFullFilePath.Name = "colFullFilePath";
            this.colFullFilePath.ReadOnly = true;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.chkKeepBackup);
            this.groupBox1.Controls.Add(this.cmbOutputDir);
            this.groupBox1.Controls.Add(this.btnChangeFolder);
            this.groupBox1.Controls.Add(this.btnOpenFolder);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // chkKeepBackup
            // 
            resources.ApplyResources(this.chkKeepBackup, "chkKeepBackup");
            this.chkKeepBackup.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkKeepBackup.Name = "chkKeepBackup";
            this.chkKeepBackup.UseVisualStyleBackColor = true;
            // 
            // cmbOutputDir
            // 
            resources.ApplyResources(this.cmbOutputDir, "cmbOutputDir");
            this.cmbOutputDir.FormattingEnabled = true;
            this.cmbOutputDir.Name = "cmbOutputDir";
            this.cmbOutputDir.SelectedIndexChanged += new System.EventHandler(this.cmbOutputDir_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.downloadToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFilesToolStripMenuItem,
            this.addFolderToolStripMenuItem,
            this.toolStripMenuItem2,
            this.importFromTextFileListToolStripMenuItem,
            this.importFromExcelFileToolStripMenuItem,
            this.toolStripMenuItem3,
            this.enterFileListToolStripMenuItem,
            this.saveFileListToolStripMenuItem,
            this.toolStripMenuItem5,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // addFilesToolStripMenuItem
            // 
            this.addFilesToolStripMenuItem.Image = global::_4dotsFreePDFCompress.Properties.Resources.add2;
            this.addFilesToolStripMenuItem.Name = "addFilesToolStripMenuItem";
            resources.ApplyResources(this.addFilesToolStripMenuItem, "addFilesToolStripMenuItem");
            this.addFilesToolStripMenuItem.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // addFolderToolStripMenuItem
            // 
            this.addFolderToolStripMenuItem.Image = global::_4dotsFreePDFCompress.Properties.Resources.folder_add;
            this.addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            resources.ApplyResources(this.addFolderToolStripMenuItem, "addFolderToolStripMenuItem");
            this.addFolderToolStripMenuItem.Click += new System.EventHandler(this.tsdbAddFolder_ButtonClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // importFromTextFileListToolStripMenuItem
            // 
            this.importFromTextFileListToolStripMenuItem.Image = global::_4dotsFreePDFCompress.Properties.Resources.import1;
            this.importFromTextFileListToolStripMenuItem.Name = "importFromTextFileListToolStripMenuItem";
            resources.ApplyResources(this.importFromTextFileListToolStripMenuItem, "importFromTextFileListToolStripMenuItem");
            this.importFromTextFileListToolStripMenuItem.Click += new System.EventHandler(this.tsdbImportList_ButtonClick);
            // 
            // importFromExcelFileToolStripMenuItem
            // 
            this.importFromExcelFileToolStripMenuItem.Image = global::_4dotsFreePDFCompress.Properties.Resources.import1;
            this.importFromExcelFileToolStripMenuItem.Name = "importFromExcelFileToolStripMenuItem";
            resources.ApplyResources(this.importFromExcelFileToolStripMenuItem, "importFromExcelFileToolStripMenuItem");
            this.importFromExcelFileToolStripMenuItem.Click += new System.EventHandler(this.importFromExcelFileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // enterFileListToolStripMenuItem
            // 
            this.enterFileListToolStripMenuItem.Name = "enterFileListToolStripMenuItem";
            resources.ApplyResources(this.enterFileListToolStripMenuItem, "enterFileListToolStripMenuItem");
            this.enterFileListToolStripMenuItem.Click += new System.EventHandler(this.enterFileListToolStripMenuItem_Click);
            // 
            // saveFileListToolStripMenuItem
            // 
            this.saveFileListToolStripMenuItem.Name = "saveFileListToolStripMenuItem";
            resources.ApplyResources(this.saveFileListToolStripMenuItem, "saveFileListToolStripMenuItem");
            this.saveFileListToolStripMenuItem.Click += new System.EventHandler(this.saveFileListToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::_4dotsFreePDFCompress.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem1,
            this.clearToolStripMenuItem,
            this.toolStripMenuItem4,
            this.selectAllToolStripMenuItem,
            this.selectNoneToolStripMenuItem,
            this.invertSelectionToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            // 
            // removeToolStripMenuItem1
            // 
            this.removeToolStripMenuItem1.Image = global::_4dotsFreePDFCompress.Properties.Resources.delete;
            this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
            resources.ApplyResources(this.removeToolStripMenuItem1, "removeToolStripMenuItem1");
            this.removeToolStripMenuItem1.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Image = global::_4dotsFreePDFCompress.Properties.Resources.brush2;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            resources.ApplyResources(this.clearToolStripMenuItem, "clearToolStripMenuItem");
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            resources.ApplyResources(this.selectAllToolStripMenuItem, "selectAllToolStripMenuItem");
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // selectNoneToolStripMenuItem
            // 
            this.selectNoneToolStripMenuItem.Name = "selectNoneToolStripMenuItem";
            resources.ApplyResources(this.selectNoneToolStripMenuItem, "selectNoneToolStripMenuItem");
            this.selectNoneToolStripMenuItem.Click += new System.EventHandler(this.selectNoneToolStripMenuItem_Click);
            // 
            // invertSelectionToolStripMenuItem
            // 
            this.invertSelectionToolStripMenuItem.Name = "invertSelectionToolStripMenuItem";
            resources.ApplyResources(this.invertSelectionToolStripMenuItem, "invertSelectionToolStripMenuItem");
            this.invertSelectionToolStripMenuItem.Click += new System.EventHandler(this.invertSelectionToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keepFolderStructureToolStripMenuItem,
            this.doNotAskForPasswordToolStripMenuItem,
            this.keepCreationDateToolStripMenuItem,
            this.keepLastModificationDateToolStripMenuItem,
            this.exploreOutputFolderWhenDoneToolStripMenuItem,
            this.showMessageOnSuccessToolStripMenuItem,
            this.showResultWindowToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            // 
            // keepFolderStructureToolStripMenuItem
            // 
            this.keepFolderStructureToolStripMenuItem.Name = "keepFolderStructureToolStripMenuItem";
            resources.ApplyResources(this.keepFolderStructureToolStripMenuItem, "keepFolderStructureToolStripMenuItem");
            this.keepFolderStructureToolStripMenuItem.Click += new System.EventHandler(this.keepFolderStructureToolStripMenuItem_Click);
            // 
            // doNotAskForPasswordToolStripMenuItem
            // 
            this.doNotAskForPasswordToolStripMenuItem.CheckOnClick = true;
            this.doNotAskForPasswordToolStripMenuItem.Name = "doNotAskForPasswordToolStripMenuItem";
            resources.ApplyResources(this.doNotAskForPasswordToolStripMenuItem, "doNotAskForPasswordToolStripMenuItem");
            this.doNotAskForPasswordToolStripMenuItem.Click += new System.EventHandler(this.doNotAskForPasswordToolStripMenuItem_Click);
            // 
            // keepCreationDateToolStripMenuItem
            // 
            this.keepCreationDateToolStripMenuItem.CheckOnClick = true;
            this.keepCreationDateToolStripMenuItem.Name = "keepCreationDateToolStripMenuItem";
            resources.ApplyResources(this.keepCreationDateToolStripMenuItem, "keepCreationDateToolStripMenuItem");
            // 
            // keepLastModificationDateToolStripMenuItem
            // 
            this.keepLastModificationDateToolStripMenuItem.CheckOnClick = true;
            this.keepLastModificationDateToolStripMenuItem.Name = "keepLastModificationDateToolStripMenuItem";
            resources.ApplyResources(this.keepLastModificationDateToolStripMenuItem, "keepLastModificationDateToolStripMenuItem");
            // 
            // exploreOutputFolderWhenDoneToolStripMenuItem
            // 
            this.exploreOutputFolderWhenDoneToolStripMenuItem.CheckOnClick = true;
            this.exploreOutputFolderWhenDoneToolStripMenuItem.Name = "exploreOutputFolderWhenDoneToolStripMenuItem";
            resources.ApplyResources(this.exploreOutputFolderWhenDoneToolStripMenuItem, "exploreOutputFolderWhenDoneToolStripMenuItem");
            // 
            // showMessageOnSuccessToolStripMenuItem
            // 
            this.showMessageOnSuccessToolStripMenuItem.CheckOnClick = true;
            this.showMessageOnSuccessToolStripMenuItem.Name = "showMessageOnSuccessToolStripMenuItem";
            resources.ApplyResources(this.showMessageOnSuccessToolStripMenuItem, "showMessageOnSuccessToolStripMenuItem");
            // 
            // showResultWindowToolStripMenuItem
            // 
            this.showResultWindowToolStripMenuItem.CheckOnClick = true;
            this.showResultWindowToolStripMenuItem.Name = "showResultWindowToolStripMenuItem";
            resources.ApplyResources(this.showResultWindowToolStripMenuItem, "showResultWindowToolStripMenuItem");
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compressToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // compressToolStripMenuItem
            // 
            this.compressToolStripMenuItem.Image = global::_4dotsFreePDFCompress.Properties.Resources.package;
            this.compressToolStripMenuItem.Name = "compressToolStripMenuItem";
            resources.ApplyResources(this.compressToolStripMenuItem, "compressToolStripMenuItem");
            this.compressToolStripMenuItem.Click += new System.EventHandler(this.btnCompressPDF_Click);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            resources.ApplyResources(this.downloadToolStripMenuItem, "downloadToolStripMenuItem");
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpGuideToolStripMenuItem,
            this.tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem,
            this.commandLineArgumentsToolStripMenuItem,
            this.donateViaPaypalToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.checkForNewVersionEachWeekToolStripMenuItem,
            this.tiHelpFeedback,
            this.toolStripMenuItem1,
            this.youtubeChannelToolStripMenuItem,
            this.followUsOnTwitterToolStripMenuItem,
            this.visit4dotsSoftwareWebsiteToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // helpGuideToolStripMenuItem
            // 
            this.helpGuideToolStripMenuItem.Image = global::_4dotsFreePDFCompress.Properties.Resources.help2;
            this.helpGuideToolStripMenuItem.Name = "helpGuideToolStripMenuItem";
            resources.ApplyResources(this.helpGuideToolStripMenuItem, "helpGuideToolStripMenuItem");
            this.helpGuideToolStripMenuItem.Click += new System.EventHandler(this.helpGuideToolStripMenuItem_Click);
            // 
            // tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem
            // 
            resources.ApplyResources(this.tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem, "tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem");
            this.tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem.Name = "tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem";
            this.tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem.Click += new System.EventHandler(this.tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem_Click);
            // 
            // commandLineArgumentsToolStripMenuItem
            // 
            this.commandLineArgumentsToolStripMenuItem.Name = "commandLineArgumentsToolStripMenuItem";
            resources.ApplyResources(this.commandLineArgumentsToolStripMenuItem, "commandLineArgumentsToolStripMenuItem");
            this.commandLineArgumentsToolStripMenuItem.Click += new System.EventHandler(this.commandLineArgumentsToolStripMenuItem_Click);
            // 
            // donateViaPaypalToolStripMenuItem
            // 
            this.donateViaPaypalToolStripMenuItem.BackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.donateViaPaypalToolStripMenuItem, "donateViaPaypalToolStripMenuItem");
            this.donateViaPaypalToolStripMenuItem.Name = "donateViaPaypalToolStripMenuItem";
            this.donateViaPaypalToolStripMenuItem.Click += new System.EventHandler(this.donateViaPaypalToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::_4dotsFreePDFCompress.Properties.Resources.about;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // checkForNewVersionEachWeekToolStripMenuItem
            // 
            this.checkForNewVersionEachWeekToolStripMenuItem.CheckOnClick = true;
            this.checkForNewVersionEachWeekToolStripMenuItem.Name = "checkForNewVersionEachWeekToolStripMenuItem";
            resources.ApplyResources(this.checkForNewVersionEachWeekToolStripMenuItem, "checkForNewVersionEachWeekToolStripMenuItem");
            // 
            // tiHelpFeedback
            // 
            this.tiHelpFeedback.Image = global::_4dotsFreePDFCompress.Properties.Resources.edit;
            this.tiHelpFeedback.Name = "tiHelpFeedback";
            resources.ApplyResources(this.tiHelpFeedback, "tiHelpFeedback");
            this.tiHelpFeedback.Click += new System.EventHandler(this.tiHelpFeedback_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // youtubeChannelToolStripMenuItem
            // 
            this.youtubeChannelToolStripMenuItem.Image = global::_4dotsFreePDFCompress.Properties.Resources.youtube_32;
            this.youtubeChannelToolStripMenuItem.Name = "youtubeChannelToolStripMenuItem";
            resources.ApplyResources(this.youtubeChannelToolStripMenuItem, "youtubeChannelToolStripMenuItem");
            this.youtubeChannelToolStripMenuItem.Click += new System.EventHandler(this.youtubeChannelToolStripMenuItem_Click);
            // 
            // followUsOnTwitterToolStripMenuItem
            // 
            this.followUsOnTwitterToolStripMenuItem.Image = global::_4dotsFreePDFCompress.Properties.Resources.social_twitter_box_white_icon_24;
            this.followUsOnTwitterToolStripMenuItem.Name = "followUsOnTwitterToolStripMenuItem";
            resources.ApplyResources(this.followUsOnTwitterToolStripMenuItem, "followUsOnTwitterToolStripMenuItem");
            this.followUsOnTwitterToolStripMenuItem.Click += new System.EventHandler(this.followUsOnTwitterToolStripMenuItem_Click);
            // 
            // visit4dotsSoftwareWebsiteToolStripMenuItem
            // 
            this.visit4dotsSoftwareWebsiteToolStripMenuItem.Name = "visit4dotsSoftwareWebsiteToolStripMenuItem";
            resources.ApplyResources(this.visit4dotsSoftwareWebsiteToolStripMenuItem, "visit4dotsSoftwareWebsiteToolStripMenuItem");
            this.visit4dotsSoftwareWebsiteToolStripMenuItem.Click += new System.EventHandler(this.visit4dotsSoftwareWebsiteToolStripMenuItem_Click);
            // 
            // chkInvert
            // 
            resources.ApplyResources(this.chkInvert, "chkInvert");
            this.chkInvert.BackColor = System.Drawing.Color.Transparent;
            this.chkInvert.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkInvert.Name = "chkInvert";
            this.chkInvert.UseVisualStyleBackColor = false;
            // 
            // chkInvert2
            // 
            resources.ApplyResources(this.chkInvert2, "chkInvert2");
            this.chkInvert2.BackColor = System.Drawing.Color.Transparent;
            this.chkInvert2.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkInvert2.Name = "chkInvert2";
            this.chkInvert2.UseVisualStyleBackColor = false;
            // 
            // chkBlackWhiteImages
            // 
            resources.ApplyResources(this.chkBlackWhiteImages, "chkBlackWhiteImages");
            this.chkBlackWhiteImages.BackColor = System.Drawing.Color.Transparent;
            this.chkBlackWhiteImages.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkBlackWhiteImages.Name = "chkBlackWhiteImages";
            this.chkBlackWhiteImages.UseVisualStyleBackColor = false;
            // 
            // chkGrayscale
            // 
            resources.ApplyResources(this.chkGrayscale, "chkGrayscale");
            this.chkGrayscale.BackColor = System.Drawing.Color.Transparent;
            this.chkGrayscale.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkGrayscale.Name = "chkGrayscale";
            this.chkGrayscale.UseVisualStyleBackColor = false;
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.chkImages);
            this.Controls.Add(this.chkGrayscale);
            this.Controls.Add(this.chkBlackWhiteImages);
            this.Controls.Add(this.chkInvert2);
            this.Controls.Add(this.chkInvert);
            this.Controls.Add(this.rdDecompress);
            this.Controls.Add(this.rdCompress);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgFiles);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.grpImageQuality);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.ShowInTaskbar = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.grpImageQuality.ResumeLayout(false);
            this.grpImageQuality.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbQuality)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpGuideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem tiHelpFeedback;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exploreToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.DataGridView dgFiles;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visit4dotsSoftwareWebsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnChangeFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.ComponentModel.BackgroundWorker bwCompress;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbCompress;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.ComboBox cmbOutputDir;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFilename;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullFilePath;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem followUsOnTwitterToolStripMenuItem;
        public System.Windows.Forms.CheckBox chkKeepBackup;
        private System.Windows.Forms.ToolStripMenuItem documentsMedataToolStripMenuItem;
        public System.Windows.Forms.RadioButton rdCompress;
        public System.Windows.Forms.RadioButton rdDecompress;
        public System.Windows.Forms.CheckBox chkImages;
        private System.Windows.Forms.GroupBox grpImageQuality;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tbQuality;
        public System.Windows.Forms.NumericUpDown nudQuality;
        private System.Windows.Forms.ToolStripDropDownButton tsbShare;
        private System.Windows.Forms.ToolStripMenuItem tsiFacebook;
        private System.Windows.Forms.ToolStripMenuItem tsiTwitter;
        private System.Windows.Forms.ToolStripMenuItem tsiGooglePlus;
        private System.Windows.Forms.ToolStripMenuItem tsiLinkedIn;
        private System.Windows.Forms.ToolStripMenuItem tsiEmail;
        public System.Windows.Forms.ToolStripSplitButton tsdbImportList;
        public System.Windows.Forms.ToolStripSplitButton tsdbAddFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripSplitButton tsdbAddFolder;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keepFolderStructureToolStripMenuItem;
        public System.Windows.Forms.CheckBox chkInvert;
        public System.Windows.Forms.CheckBox chkInvert2;
        public System.Windows.Forms.CheckBox chkBlackWhiteImages;
        public System.Windows.Forms.CheckBox chkGrayscale;
        private System.Windows.Forms.ToolStripMenuItem doNotAskForPasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem importFromTextFileListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromExcelFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectNoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enterFileListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem donateViaPaypalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem youtubeChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForNewVersionEachWeekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keepCreationDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keepLastModificationDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exploreOutputFolderWhenDoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMessageOnSuccessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showResultWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandLineArgumentsToolStripMenuItem;
    }
}
