namespace RefplusWebtools.Report
{
    partial class FrmExtraReports
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
            this.FilesView = new System.Windows.Forms.DataGridView();
            this.ToPrint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdOk = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FilesView)).BeginInit();
            this.SuspendLayout();
            // 
            // FilesView
            // 
            this.FilesView.AllowUserToAddRows = false;
            this.FilesView.AllowUserToDeleteRows = false;
            this.FilesView.AllowUserToOrderColumns = true;
            this.FilesView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FilesView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ToPrint,
            this.FileName,
            this.DateModified});
            this.FilesView.Location = new System.Drawing.Point(12, 28);
            this.FilesView.Name = "FilesView";
            this.FilesView.Size = new System.Drawing.Size(491, 235);
            this.FilesView.TabIndex = 1;
            // 
            // ToPrint
            // 
            this.ToPrint.HeaderText = "To print?";
            this.ToPrint.Name = "ToPrint";
            // 
            // FileName
            // 
            this.FileName.HeaderText = "Report Name";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            // 
            // DateModified
            // 
            this.DateModified.HeaderText = "Description";
            this.DateModified.Name = "DateModified";
            this.DateModified.ReadOnly = true;
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(13, 270);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(231, 36);
            this.cmdOk.TabIndex = 2;
            this.cmdOk.Text = "button1";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(272, 269);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(231, 36);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "button1";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // FrmExtraReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 318);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.FilesView);
            this.Name = "FrmExtraReports";
            this.Text = "frmExtraReports";
            this.Load += new System.EventHandler(this.FrmExtraReports_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.FilesView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView FilesView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ToPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateModified;
        private System.Windows.Forms.Button cmdOk;
        private System.Windows.Forms.Button cmdClose;
    }
}