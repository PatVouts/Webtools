namespace RefplusWebtools.DataManager.Generic
{
    partial class FrmDrawingUpload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDrawingUpload));
            this.lblWarning = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.cmdUpload = new System.Windows.Forms.Button();
            this.cmdBrowseFile = new System.Windows.Forms.Button();
            this.OpenDlg = new System.Windows.Forms.OpenFileDialog();
            this.cmdClose = new System.Windows.Forms.Button();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(14, 44);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(197, 13);
            this.lblWarning.TabIndex = 172;
            this.lblWarning.Text = "sIf the file already exist it will be replaced";
            // 
            // txtFile
            // 
            this.txtFile.BackColor = System.Drawing.Color.White;
            this.txtFile.Enabled = false;
            this.txtFile.Location = new System.Drawing.Point(12, 21);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(413, 20);
            this.txtFile.TabIndex = 169;
            // 
            // cmdUpload
            // 
            this.cmdUpload.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpload.Image")));
            this.cmdUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUpload.Location = new System.Drawing.Point(682, 18);
            this.cmdUpload.Name = "cmdUpload";
            this.cmdUpload.Size = new System.Drawing.Size(96, 25);
            this.cmdUpload.TabIndex = 171;
            this.cmdUpload.Text = "sUpload";
            this.cmdUpload.UseVisualStyleBackColor = true;
            this.cmdUpload.Click += new System.EventHandler(this.cmdUpload_Click);
            // 
            // cmdBrowseFile
            // 
            this.cmdBrowseFile.Image = ((System.Drawing.Image)(resources.GetObject("cmdBrowseFile.Image")));
            this.cmdBrowseFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBrowseFile.Location = new System.Drawing.Point(580, 18);
            this.cmdBrowseFile.Name = "cmdBrowseFile";
            this.cmdBrowseFile.Size = new System.Drawing.Size(96, 25);
            this.cmdBrowseFile.TabIndex = 170;
            this.cmdBrowseFile.Text = "sBrowse";
            this.cmdBrowseFile.UseVisualStyleBackColor = true;
            this.cmdBrowseFile.Click += new System.EventHandler(this.cmdBrowseFile_Click);
            // 
            // OpenDlg
            // 
            this.OpenDlg.Filter = "Acrobat Reader|*.pdf";
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(580, 49);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(198, 25);
            this.cmdClose.TabIndex = 173;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(431, 5);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 183;
            this.lblCategory.Text = "Category";
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Items.AddRange(new object[] {
            "Condenser",
            "Condensing Unit",
            "Evaporator",
            "Fluid Cooler",
            "Gravity Coil"});
            this.cboCategory.Location = new System.Drawing.Point(431, 21);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(143, 21);
            this.cboCategory.TabIndex = 182;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(14, 5);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(28, 13);
            this.lblFile.TabIndex = 184;
            this.lblFile.Text = "sFile";
            // 
            // frmDrawingUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(785, 80);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.cmdUpload);
            this.Controls.Add(this.cmdBrowseFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDrawingUpload";
            this.Text = "sUpload Drawing";
            this.Load += new System.EventHandler(this.frmDrawingUpload_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button cmdUpload;
        private System.Windows.Forms.Button cmdBrowseFile;
        private System.Windows.Forms.OpenFileDialog OpenDlg;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblFile;
    }
}