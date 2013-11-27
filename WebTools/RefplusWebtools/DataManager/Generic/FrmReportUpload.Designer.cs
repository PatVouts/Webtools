namespace RefplusWebtools.DataManager.Generic
{
    partial class FrmReportUpload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportUpload));
            this.cmdSave = new System.Windows.Forms.Button();
            this.lblFrenchFilename = new System.Windows.Forms.Label();
            this.lblEnglishFilename = new System.Windows.Forms.Label();
            this.cmdBrowseFR = new System.Windows.Forms.Button();
            this.cmdBrowseEN = new System.Windows.Forms.Button();
            this.txtFrenchFile = new System.Windows.Forms.TextBox();
            this.txtEnglishFile = new System.Windows.Forms.TextBox();
            this.OpenDlg = new System.Windows.Forms.OpenFileDialog();
            this.cmdClose = new System.Windows.Forms.Button();
            this.lblENDescription = new System.Windows.Forms.Label();
            this.txtENDescription = new System.Windows.Forms.TextBox();
            this.lblFRDescription = new System.Windows.Forms.Label();
            this.txtFRDescription = new System.Windows.Forms.TextBox();
            this.cmbReports = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAddMachines = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdSave
            // 
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(16, 346);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(136, 23);
            this.cmdSave.TabIndex = 3;
            this.cmdSave.Text = "sAssign";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lblFrenchFilename
            // 
            this.lblFrenchFilename.AutoSize = true;
            this.lblFrenchFilename.Location = new System.Drawing.Point(13, 236);
            this.lblFrenchFilename.Name = "lblFrenchFilename";
            this.lblFrenchFilename.Size = new System.Drawing.Size(90, 13);
            this.lblFrenchFilename.TabIndex = 17;
            this.lblFrenchFilename.Text = "sFrench Filename";
            // 
            // lblEnglishFilename
            // 
            this.lblEnglishFilename.AutoSize = true;
            this.lblEnglishFilename.Location = new System.Drawing.Point(13, 151);
            this.lblEnglishFilename.Name = "lblEnglishFilename";
            this.lblEnglishFilename.Size = new System.Drawing.Size(91, 13);
            this.lblEnglishFilename.TabIndex = 16;
            this.lblEnglishFilename.Text = "sEnglish Filename";
            // 
            // cmdBrowseFR
            // 
            this.cmdBrowseFR.Image = ((System.Drawing.Image)(resources.GetObject("cmdBrowseFR.Image")));
            this.cmdBrowseFR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBrowseFR.Location = new System.Drawing.Point(264, 252);
            this.cmdBrowseFR.Name = "cmdBrowseFR";
            this.cmdBrowseFR.Size = new System.Drawing.Size(136, 23);
            this.cmdBrowseFR.TabIndex = 2;
            this.cmdBrowseFR.Text = "sBrowse FR";
            this.cmdBrowseFR.UseVisualStyleBackColor = true;
            this.cmdBrowseFR.Click += new System.EventHandler(this.cmdBrowseFR_Click_1);
            // 
            // cmdBrowseEN
            // 
            this.cmdBrowseEN.Image = ((System.Drawing.Image)(resources.GetObject("cmdBrowseEN.Image")));
            this.cmdBrowseEN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBrowseEN.Location = new System.Drawing.Point(264, 165);
            this.cmdBrowseEN.Name = "cmdBrowseEN";
            this.cmdBrowseEN.Size = new System.Drawing.Size(136, 23);
            this.cmdBrowseEN.TabIndex = 1;
            this.cmdBrowseEN.Text = "sBrowse EN";
            this.cmdBrowseEN.UseVisualStyleBackColor = true;
            this.cmdBrowseEN.Click += new System.EventHandler(this.cmdBrowseEN_Click_1);
            // 
            // txtFrenchFile
            // 
            this.txtFrenchFile.Enabled = false;
            this.txtFrenchFile.Location = new System.Drawing.Point(16, 252);
            this.txtFrenchFile.Name = "txtFrenchFile";
            this.txtFrenchFile.Size = new System.Drawing.Size(242, 20);
            this.txtFrenchFile.TabIndex = 13;
            this.txtFrenchFile.TabStop = false;
            // 
            // txtEnglishFile
            // 
            this.txtEnglishFile.Enabled = false;
            this.txtEnglishFile.Location = new System.Drawing.Point(16, 167);
            this.txtEnglishFile.Name = "txtEnglishFile";
            this.txtEnglishFile.Size = new System.Drawing.Size(242, 20);
            this.txtEnglishFile.TabIndex = 12;
            this.txtEnglishFile.TabStop = false;
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(264, 346);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(136, 23);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click_1);
            // 
            // lblENDescription
            // 
            this.lblENDescription.AutoSize = true;
            this.lblENDescription.Location = new System.Drawing.Point(13, 190);
            this.lblENDescription.Name = "lblENDescription";
            this.lblENDescription.Size = new System.Drawing.Size(102, 13);
            this.lblENDescription.TabIndex = 19;
            this.lblENDescription.Text = "sEnglish Description";
            // 
            // txtENDescription
            // 
            this.txtENDescription.Location = new System.Drawing.Point(16, 206);
            this.txtENDescription.Name = "txtENDescription";
            this.txtENDescription.Size = new System.Drawing.Size(242, 20);
            this.txtENDescription.TabIndex = 18;
            this.txtENDescription.TabStop = false;
            // 
            // lblFRDescription
            // 
            this.lblFRDescription.AutoSize = true;
            this.lblFRDescription.Location = new System.Drawing.Point(13, 282);
            this.lblFRDescription.Name = "lblFRDescription";
            this.lblFRDescription.Size = new System.Drawing.Size(101, 13);
            this.lblFRDescription.TabIndex = 21;
            this.lblFRDescription.Text = "sFrench Description";
            // 
            // txtFRDescription
            // 
            this.txtFRDescription.Location = new System.Drawing.Point(16, 298);
            this.txtFRDescription.Name = "txtFRDescription";
            this.txtFRDescription.Size = new System.Drawing.Size(242, 20);
            this.txtFRDescription.TabIndex = 20;
            this.txtFRDescription.TabStop = false;
            // 
            // cmbReports
            // 
            this.cmbReports.FormattingEnabled = true;
            this.cmbReports.Location = new System.Drawing.Point(12, 55);
            this.cmbReports.Name = "cmbReports";
            this.cmbReports.Size = new System.Drawing.Size(367, 21);
            this.cmbReports.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(12, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "sLoad Reports";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAddMachines
            // 
            this.btnAddMachines.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddMachines.Location = new System.Drawing.Point(154, 91);
            this.btnAddMachines.Name = "btnAddMachines";
            this.btnAddMachines.Size = new System.Drawing.Size(225, 23);
            this.btnAddMachines.TabIndex = 24;
            this.btnAddMachines.Text = "sLoad Reports";
            this.btnAddMachines.UseVisualStyleBackColor = true;
            this.btnAddMachines.Click += new System.EventHandler(this.btnAddMachines_Click);
            // 
            // FrmReportUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 392);
            this.Controls.Add(this.btnAddMachines);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbReports);
            this.Controls.Add(this.lblFRDescription);
            this.Controls.Add(this.txtFRDescription);
            this.Controls.Add(this.lblENDescription);
            this.Controls.Add(this.txtENDescription);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.lblFrenchFilename);
            this.Controls.Add(this.lblEnglishFilename);
            this.Controls.Add(this.cmdBrowseFR);
            this.Controls.Add(this.cmdBrowseEN);
            this.Controls.Add(this.txtFrenchFile);
            this.Controls.Add(this.txtEnglishFile);
            this.Controls.Add(this.cmdClose);
            this.Name = "FrmReportUpload";
            this.Text = "FrmReportUpload";
            this.Load += new System.EventHandler(this.FrmReportUpload_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label lblFrenchFilename;
        private System.Windows.Forms.Label lblEnglishFilename;
        private System.Windows.Forms.Button cmdBrowseFR;
        private System.Windows.Forms.Button cmdBrowseEN;
        private System.Windows.Forms.TextBox txtFrenchFile;
        private System.Windows.Forms.TextBox txtEnglishFile;
        private System.Windows.Forms.OpenFileDialog OpenDlg;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Label lblENDescription;
        private System.Windows.Forms.TextBox txtENDescription;
        private System.Windows.Forms.Label lblFRDescription;
        private System.Windows.Forms.TextBox txtFRDescription;
        private System.Windows.Forms.ComboBox cmbReports;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAddMachines;

    }
}