namespace RefplusWebtools
{
    partial class FrmCustomReportLogo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomReportLogo));
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblPictureSize = new System.Windows.Forms.Label();
            this.opendlg = new System.Windows.Forms.OpenFileDialog();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.radDefault = new System.Windows.Forms.RadioButton();
            this.radCustom = new System.Windows.Forms.RadioButton();
            this.pnlCustom = new System.Windows.Forms.Panel();
            this.lblLocationWarning = new System.Windows.Forms.Label();
            this.cmdBrowseFile = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlCustom.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogo.Location = new System.Drawing.Point(6, 19);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(200, 60);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // lblPictureSize
            // 
            this.lblPictureSize.AutoSize = true;
            this.lblPictureSize.Location = new System.Drawing.Point(3, 3);
            this.lblPictureSize.Name = "lblPictureSize";
            this.lblPictureSize.Size = new System.Drawing.Size(76, 13);
            this.lblPictureSize.TabIndex = 1;
            this.lblPictureSize.Text = "sSize 200 x 60";
            // 
            // opendlg
            // 
            this.opendlg.FileName = "openFileDialog1";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(212, 19);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(153, 91);
            this.txtAddress.TabIndex = 2;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(209, 2);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(50, 13);
            this.lblAddress.TabIndex = 3;
            this.lblAddress.Text = "sAddress";
            // 
            // radDefault
            // 
            this.radDefault.AutoSize = true;
            this.radDefault.Checked = true;
            this.radDefault.Location = new System.Drawing.Point(12, 10);
            this.radDefault.Name = "radDefault";
            this.radDefault.Size = new System.Drawing.Size(109, 17);
            this.radDefault.TabIndex = 4;
            this.radDefault.TabStop = true;
            this.radDefault.Text = "sSoftware Default";
            this.radDefault.UseVisualStyleBackColor = true;
            this.radDefault.CheckedChanged += new System.EventHandler(this.radDefault_CheckedChanged);
            // 
            // radCustom
            // 
            this.radCustom.AutoSize = true;
            this.radCustom.Location = new System.Drawing.Point(12, 33);
            this.radCustom.Name = "radCustom";
            this.radCustom.Size = new System.Drawing.Size(65, 17);
            this.radCustom.TabIndex = 5;
            this.radCustom.TabStop = true;
            this.radCustom.Text = "sCustom";
            this.radCustom.UseVisualStyleBackColor = true;
            this.radCustom.CheckedChanged += new System.EventHandler(this.radCustom_CheckedChanged);
            // 
            // pnlCustom
            // 
            this.pnlCustom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCustom.Controls.Add(this.lblLocationWarning);
            this.pnlCustom.Controls.Add(this.cmdBrowseFile);
            this.pnlCustom.Controls.Add(this.lblPictureSize);
            this.pnlCustom.Controls.Add(this.picLogo);
            this.pnlCustom.Controls.Add(this.txtAddress);
            this.pnlCustom.Controls.Add(this.lblAddress);
            this.pnlCustom.Enabled = false;
            this.pnlCustom.Location = new System.Drawing.Point(12, 56);
            this.pnlCustom.Name = "pnlCustom";
            this.pnlCustom.Size = new System.Drawing.Size(379, 133);
            this.pnlCustom.TabIndex = 6;
            // 
            // lblLocationWarning
            // 
            this.lblLocationWarning.AutoSize = true;
            this.lblLocationWarning.ForeColor = System.Drawing.Color.Red;
            this.lblLocationWarning.Location = new System.Drawing.Point(3, 113);
            this.lblLocationWarning.Name = "lblLocationWarning";
            this.lblLocationWarning.Size = new System.Drawing.Size(260, 13);
            this.lblLocationWarning.TabIndex = 172;
            this.lblLocationWarning.Text = "sAll logo files should be stored locally on the computer";
            // 
            // cmdBrowseFile
            // 
            this.cmdBrowseFile.Image = ((System.Drawing.Image)(resources.GetObject("cmdBrowseFile.Image")));
            this.cmdBrowseFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBrowseFile.Location = new System.Drawing.Point(6, 85);
            this.cmdBrowseFile.Name = "cmdBrowseFile";
            this.cmdBrowseFile.Size = new System.Drawing.Size(200, 25);
            this.cmdBrowseFile.TabIndex = 171;
            this.cmdBrowseFile.Text = "sBrowse";
            this.cmdBrowseFile.UseVisualStyleBackColor = true;
            this.cmdBrowseFile.Click += new System.EventHandler(this.cmdBrowseFile_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(239, 195);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(152, 27);
            this.cmdClose.TabIndex = 9;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(12, 195);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(152, 27);
            this.cmdSave.TabIndex = 10;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // frmCustomReportLogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(402, 228);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.pnlCustom);
            this.Controls.Add(this.radCustom);
            this.Controls.Add(this.radDefault);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCustomReportLogo";
            this.Text = "sCustom Report Logo";
            this.Load += new System.EventHandler(this.frmCustomReportLogo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlCustom.ResumeLayout(false);
            this.pnlCustom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblPictureSize;
        private System.Windows.Forms.OpenFileDialog opendlg;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.RadioButton radDefault;
        private System.Windows.Forms.RadioButton radCustom;
        private System.Windows.Forms.Panel pnlCustom;
        private System.Windows.Forms.Button cmdBrowseFile;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label lblLocationWarning;
    }
}