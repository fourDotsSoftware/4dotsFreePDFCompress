namespace _4dotsFreePDFCompress
{
    partial class frmPromotion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPromotion));
            this.label1 = new System.Windows.Forms.Label();
            this.lnkPromotion = new System.Windows.Forms.LinkLabel();
            this.picPromotion = new System.Windows.Forms.PictureBox();
            this.chkVisitWebpage = new System.Windows.Forms.CheckBox();
            this.chkDoNotShowAgain = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPromotion)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Name = "label1";
            // 
            // lnkPromotion
            // 
            resources.ApplyResources(this.lnkPromotion, "lnkPromotion");
            this.lnkPromotion.BackColor = System.Drawing.Color.Transparent;
            this.lnkPromotion.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkPromotion.Name = "lnkPromotion";
            this.lnkPromotion.TabStop = true;
            this.lnkPromotion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPromotion_LinkClicked);
            // 
            // picPromotion
            // 
            this.picPromotion.Image = global::_4dotsFreePDFCompress.Properties.Resources.onlinepdfapps_com_main_screen_700_373;
            resources.ApplyResources(this.picPromotion, "picPromotion");
            this.picPromotion.Name = "picPromotion";
            this.picPromotion.TabStop = false;
            this.picPromotion.Click += new System.EventHandler(this.picPromotion_Click);
            // 
            // chkVisitWebpage
            // 
            resources.ApplyResources(this.chkVisitWebpage, "chkVisitWebpage");
            this.chkVisitWebpage.BackColor = System.Drawing.Color.Transparent;
            this.chkVisitWebpage.Checked = true;
            this.chkVisitWebpage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVisitWebpage.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkVisitWebpage.Name = "chkVisitWebpage";
            this.chkVisitWebpage.UseVisualStyleBackColor = false;
            // 
            // chkDoNotShowAgain
            // 
            resources.ApplyResources(this.chkDoNotShowAgain, "chkDoNotShowAgain");
            this.chkDoNotShowAgain.BackColor = System.Drawing.Color.Transparent;
            this.chkDoNotShowAgain.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkDoNotShowAgain.Name = "chkDoNotShowAgain";
            this.chkDoNotShowAgain.UseVisualStyleBackColor = false;
            // 
            // btnOK
            // 
            this.btnOK.Image = global::_4dotsFreePDFCompress.Properties.Resources.check;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmPromotion
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkDoNotShowAgain);
            this.Controls.Add(this.chkVisitWebpage);
            this.Controls.Add(this.picPromotion);
            this.Controls.Add(this.lnkPromotion);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPromotion";
            this.ShowInTaskbar = true;
            ((System.ComponentModel.ISupportInitialize)(this.picPromotion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkPromotion;
        private System.Windows.Forms.PictureBox picPromotion;
        public System.Windows.Forms.CheckBox chkVisitWebpage;
        public System.Windows.Forms.CheckBox chkDoNotShowAgain;
        private System.Windows.Forms.Button btnOK;
    }
}
