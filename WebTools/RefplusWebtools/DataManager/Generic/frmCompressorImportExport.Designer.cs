namespace RefplusWebtools.DataManager.Generic
{
    partial class FrmCompressorImportExport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompressorImportExport));
            this.MyFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.MyOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.cmdExport = new System.Windows.Forms.Button();
            this.cmdImport = new System.Windows.Forms.Button();
            this.lblExport = new System.Windows.Forms.Label();
            this.lblRules = new System.Windows.Forms.Label();
            this.lblImport = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdExport
            // 
            this.cmdExport.Location = new System.Drawing.Point(209, 29);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(127, 27);
            this.cmdExport.TabIndex = 0;
            this.cmdExport.Text = "sExport";
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // cmdImport
            // 
            this.cmdImport.Location = new System.Drawing.Point(209, 536);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(127, 27);
            this.cmdImport.TabIndex = 1;
            this.cmdImport.Text = "sImport";
            this.cmdImport.UseVisualStyleBackColor = true;
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
            // 
            // lblExport
            // 
            this.lblExport.Location = new System.Drawing.Point(12, 9);
            this.lblExport.Name = "lblExport";
            this.lblExport.Size = new System.Drawing.Size(520, 21);
            this.lblExport.TabIndex = 2;
            this.lblExport.Text = "sThis will export the compressor data to a file. you will be prompt to select a l" +
    "ocation for the file to be created.";
            // 
            // lblRules
            // 
            this.lblRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRules.ForeColor = System.Drawing.Color.Red;
            this.lblRules.Location = new System.Drawing.Point(12, 59);
            this.lblRules.Name = "lblRules";
            this.lblRules.Size = new System.Drawing.Size(520, 440);
            this.lblRules.TabIndex = 3;
            this.lblRules.Text = resources.GetString("lblRules.Text");
            // 
            // lblImport
            // 
            this.lblImport.Location = new System.Drawing.Point(12, 499);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(520, 34);
            this.lblImport.TabIndex = 4;
            this.lblImport.Text = "sThis will import the file you exported. you will be prompt to select the file.\r\n" +
    "Make sure you did follow the list of rules.";
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(405, 536);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(127, 27);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmCompressorImportExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(544, 571);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.lblImport);
            this.Controls.Add(this.lblRules);
            this.Controls.Add(this.lblExport);
            this.Controls.Add(this.cmdImport);
            this.Controls.Add(this.cmdExport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCompressorImportExport";
            this.Text = "sCompressor Import/Export";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog MyFolderBrowser;
        private System.Windows.Forms.OpenFileDialog MyOpenFile;
        private System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.Button cmdImport;
        private System.Windows.Forms.Label lblExport;
        private System.Windows.Forms.Label lblRules;
        private System.Windows.Forms.Label lblImport;
        private System.Windows.Forms.Button cmdClose;
    }
}