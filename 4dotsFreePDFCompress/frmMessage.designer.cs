namespace _4dotsFreePDFCompress
{
    partial class frmMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMessage));
            this.btnOK = new System.Windows.Forms.Button();
            this.chkShow = new System.Windows.Forms.CheckBox();
            this.txtMsg = new System.Windows.Forms.RichTextBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Image = global::_4dotsFreePDFCompress.Properties.Resources.check;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkShow
            // 
            resources.ApplyResources(this.chkShow, "chkShow");
            this.chkShow.BackColor = System.Drawing.Color.Transparent;
            this.chkShow.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkShow.Name = "chkShow";
            this.chkShow.UseVisualStyleBackColor = false;
            // 
            // txtMsg
            // 
            resources.ApplyResources(this.txtMsg, "txtMsg");
            this.txtMsg.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ReadOnly = true;
            this.txtMsg.TabStop = false;
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblMsg, "lblMsg");
            this.lblMsg.Name = "lblMsg";
            // 
            // btnCopy
            // 
            resources.ApplyResources(this.btnCopy, "btnCopy");
            this.btnCopy.Image = global::_4dotsFreePDFCompress.Properties.Resources.copy;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // frmMessage
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.chkShow);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.lblMsg);
            this.Name = "frmMessage";
            this.Load += new System.EventHandler(this.frmMessage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblMsg;
        public System.Windows.Forms.RichTextBox txtMsg;
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.CheckBox chkShow;
        private System.Windows.Forms.Button btnCopy;
    }
}
