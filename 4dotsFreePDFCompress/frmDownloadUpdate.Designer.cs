namespace _4dotsFreePDFCompress
{
    partial class frmDownloadUpdate
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
            this.pgBar = new _4dotsFreePDFCompress.ucTextProgressBar();
            this.btnCancelDownload = new System.Windows.Forms.Button();
            this.bwDownload = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pgBar
            // 
            this.pgBar.BackColor = System.Drawing.SystemColors.Control;
            this.pgBar.Location = new System.Drawing.Point(12, 20);
            this.pgBar.Name = "pgBar";
            this.pgBar.Size = new System.Drawing.Size(380, 34);
            this.pgBar.TabIndex = 0;
            // 
            // btnCancelDownload
            // 
            this.btnCancelDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelDownload.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelDownload.Location = new System.Drawing.Point(403, 22);
            this.btnCancelDownload.Name = "btnCancelDownload";
            this.btnCancelDownload.Size = new System.Drawing.Size(135, 29);
            this.btnCancelDownload.TabIndex = 6;
            this.btnCancelDownload.Text = "&Cancel";
            this.btnCancelDownload.UseVisualStyleBackColor = true;
            this.btnCancelDownload.Click += new System.EventHandler(this.btnCancelDownload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Update File Size ;";
            // 
            // lblTotalSize
            // 
            this.lblTotalSize.AutoSize = true;
            this.lblTotalSize.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalSize.Location = new System.Drawing.Point(108, 71);
            this.lblTotalSize.Name = "lblTotalSize";
            this.lblTotalSize.Size = new System.Drawing.Size(16, 13);
            this.lblTotalSize.TabIndex = 8;
            this.lblTotalSize.Text = "...";
            // 
            // frmDownloadUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(555, 118);
            this.Controls.Add(this.lblTotalSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelDownload);
            this.Controls.Add(this.pgBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDownloadUpdate";
            this.Text = "Downloading Update";
            this.Load += new System.EventHandler(this.frmDownloadUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucTextProgressBar pgBar;
        private System.Windows.Forms.Button btnCancelDownload;
        private System.ComponentModel.BackgroundWorker bwDownload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalSize;
    }
}
