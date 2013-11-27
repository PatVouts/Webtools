namespace RefplusWebtools.DataManager.Generic
{
    partial class FrmPublicityUpload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPublicityUpload));
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtEnglishFile = new System.Windows.Forms.TextBox();
            this.txtFrenchFile = new System.Windows.Forms.TextBox();
            this.cmdBrowseEN = new System.Windows.Forms.Button();
            this.cmdBrowseFR = new System.Windows.Forms.Button();
            this.lblEnglishFilename = new System.Windows.Forms.Label();
            this.lblFrenchFilename = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.OpenDlg = new System.Windows.Forms.OpenFileDialog();
            this.cmdClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(40, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "sName";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(15, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(242, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtEnglishFile
            // 
            this.txtEnglishFile.Location = new System.Drawing.Point(15, 75);
            this.txtEnglishFile.Name = "txtEnglishFile";
            this.txtEnglishFile.Size = new System.Drawing.Size(242, 20);
            this.txtEnglishFile.TabIndex = 2;
            // 
            // txtFrenchFile
            // 
            this.txtFrenchFile.Location = new System.Drawing.Point(15, 120);
            this.txtFrenchFile.Name = "txtFrenchFile";
            this.txtFrenchFile.Size = new System.Drawing.Size(242, 20);
            this.txtFrenchFile.TabIndex = 3;
            // 
            // cmdBrowseEN
            // 
            this.cmdBrowseEN.Image = ((System.Drawing.Image)(resources.GetObject("cmdBrowseEN.Image")));
            this.cmdBrowseEN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBrowseEN.Location = new System.Drawing.Point(263, 73);
            this.cmdBrowseEN.Name = "cmdBrowseEN";
            this.cmdBrowseEN.Size = new System.Drawing.Size(136, 23);
            this.cmdBrowseEN.TabIndex = 4;
            this.cmdBrowseEN.Text = "sBrowse EN";
            this.cmdBrowseEN.UseVisualStyleBackColor = true;
            this.cmdBrowseEN.Click += new System.EventHandler(this.cmdBrowseEN_Click);
            // 
            // cmdBrowseFR
            // 
            this.cmdBrowseFR.Image = ((System.Drawing.Image)(resources.GetObject("cmdBrowseFR.Image")));
            this.cmdBrowseFR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBrowseFR.Location = new System.Drawing.Point(263, 120);
            this.cmdBrowseFR.Name = "cmdBrowseFR";
            this.cmdBrowseFR.Size = new System.Drawing.Size(136, 23);
            this.cmdBrowseFR.TabIndex = 5;
            this.cmdBrowseFR.Text = "sBrowse FR";
            this.cmdBrowseFR.UseVisualStyleBackColor = true;
            this.cmdBrowseFR.Click += new System.EventHandler(this.cmdBrowseFR_Click);
            // 
            // lblEnglishFilename
            // 
            this.lblEnglishFilename.AutoSize = true;
            this.lblEnglishFilename.Location = new System.Drawing.Point(12, 59);
            this.lblEnglishFilename.Name = "lblEnglishFilename";
            this.lblEnglishFilename.Size = new System.Drawing.Size(91, 13);
            this.lblEnglishFilename.TabIndex = 6;
            this.lblEnglishFilename.Text = "sEnglish Filename";
            // 
            // lblFrenchFilename
            // 
            this.lblFrenchFilename.AutoSize = true;
            this.lblFrenchFilename.Location = new System.Drawing.Point(12, 104);
            this.lblFrenchFilename.Name = "lblFrenchFilename";
            this.lblFrenchFilename.Size = new System.Drawing.Size(90, 13);
            this.lblFrenchFilename.TabIndex = 7;
            this.lblFrenchFilename.Text = "sFrench Filename";
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(15, 192);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(136, 23);
            this.cmdSave.TabIndex = 8;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // OpenDlg
            // 
            this.OpenDlg.Filter = "Image Files|*.jpg|*.gif|*.png|*.bmp|*.jpeg";
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(263, 192);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(136, 23);
            this.cmdClose.TabIndex = 9;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmPublicityUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(414, 227);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.lblFrenchFilename);
            this.Controls.Add(this.lblEnglishFilename);
            this.Controls.Add(this.cmdBrowseFR);
            this.Controls.Add(this.cmdBrowseEN);
            this.Controls.Add(this.txtFrenchFile);
            this.Controls.Add(this.txtEnglishFile);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPublicityUpload";
            this.Text = "sData Manager - Publicity Upload";
            this.Load += new System.EventHandler(this.frmPublicityUpload_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtEnglishFile;
        private System.Windows.Forms.TextBox txtFrenchFile;
        private System.Windows.Forms.Button cmdBrowseEN;
        private System.Windows.Forms.Button cmdBrowseFR;
        private System.Windows.Forms.Label lblEnglishFilename;
        private System.Windows.Forms.Label lblFrenchFilename;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.OpenFileDialog OpenDlg;
        private System.Windows.Forms.Button cmdClose;
    }
}