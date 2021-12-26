namespace _4dotsFreePDFCompress
{
    partial class frmResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResult));
            this.btnOK = new System.Windows.Forms.Button();
            this.pbAfter = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCompressionLevel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSaved = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPercentageAfter = new System.Windows.Forms.Label();
            this.lblSizeBefore = new System.Windows.Forms.Label();
            this.lblSizeAfter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Image = global::_4dotsFreePDFCompress.Properties.Resources.check;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pbAfter
            // 
            resources.ApplyResources(this.pbAfter, "pbAfter");
            this.pbAfter.Name = "pbAfter";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Name = "label4";
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Value = 100;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // lblCompressionLevel
            // 
            resources.ApplyResources(this.lblCompressionLevel, "lblCompressionLevel");
            this.lblCompressionLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblCompressionLevel.Name = "lblCompressionLevel";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Name = "label3";
            // 
            // lblSaved
            // 
            resources.ApplyResources(this.lblSaved, "lblSaved");
            this.lblSaved.BackColor = System.Drawing.Color.Transparent;
            this.lblSaved.Name = "lblSaved";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Name = "label5";
            // 
            // lblPercentageAfter
            // 
            resources.ApplyResources(this.lblPercentageAfter, "lblPercentageAfter");
            this.lblPercentageAfter.BackColor = System.Drawing.Color.Transparent;
            this.lblPercentageAfter.Name = "lblPercentageAfter";
            // 
            // lblSizeBefore
            // 
            resources.ApplyResources(this.lblSizeBefore, "lblSizeBefore");
            this.lblSizeBefore.BackColor = System.Drawing.Color.Transparent;
            this.lblSizeBefore.Name = "lblSizeBefore";
            // 
            // lblSizeAfter
            // 
            resources.ApplyResources(this.lblSizeAfter, "lblSizeAfter");
            this.lblSizeAfter.BackColor = System.Drawing.Color.Transparent;
            this.lblSizeAfter.Name = "lblSizeAfter";
            // 
            // frmResult
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.lblSizeAfter);
            this.Controls.Add(this.lblSizeBefore);
            this.Controls.Add(this.lblPercentageAfter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.pbAfter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCompressionLevel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSaved);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmResult";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblSaved;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblCompressionLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.ProgressBar pbAfter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lblPercentageAfter;
        public System.Windows.Forms.Label lblSizeBefore;
        public System.Windows.Forms.Label lblSizeAfter;
    }
}
