namespace EatonLeonardConverter
{
    partial class Converter
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
            this.cmd_browse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBox_Folder = new System.Windows.Forms.TextBox();
            this.FilesView = new System.Windows.Forms.DataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFolderExport = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FilesView)).BeginInit();
            this.SuspendLayout();
            // 
            // cmd_browse
            // 
            this.cmd_browse.Location = new System.Drawing.Point(18, 13);
            this.cmd_browse.Name = "cmd_browse";
            this.cmd_browse.Size = new System.Drawing.Size(94, 51);
            this.cmd_browse.TabIndex = 0;
            this.cmd_browse.Text = "Choose a folder to import files";
            this.cmd_browse.UseVisualStyleBackColor = true;
            this.cmd_browse.Click += new System.EventHandler(this.cmd_browse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(151, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loaded Folder :";
            // 
            // txtBox_Folder
            // 
            this.txtBox_Folder.Enabled = false;
            this.txtBox_Folder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_Folder.Location = new System.Drawing.Point(154, 44);
            this.txtBox_Folder.Name = "txtBox_Folder";
            this.txtBox_Folder.Size = new System.Drawing.Size(311, 20);
            this.txtBox_Folder.TabIndex = 2;
            // 
            // FilesView
            // 
            this.FilesView.AllowUserToAddRows = false;
            this.FilesView.AllowUserToDeleteRows = false;
            this.FilesView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FilesView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName});
            this.FilesView.Location = new System.Drawing.Point(12, 170);
            this.FilesView.Name = "FilesView";
            this.FilesView.Size = new System.Drawing.Size(119, 171);
            this.FilesView.TabIndex = 3;
            // 
            // FileName
            // 
            this.FileName.HeaderText = "FileName";
            this.FileName.Name = "FileName";
            this.FileName.Width = 75;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Files in Folder";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(247, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 26);
            this.button1.TabIndex = 5;
            this.button1.Text = "Open Importing Folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(247, 315);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 26);
            this.button2.TabIndex = 6;
            this.button2.Text = "Quit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(18, 95);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 51);
            this.button3.TabIndex = 7;
            this.button3.Text = "Choose a folder to export files";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(151, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Target Folder for Export:";
            // 
            // txtFolderExport
            // 
            this.txtFolderExport.Enabled = false;
            this.txtFolderExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolderExport.Location = new System.Drawing.Point(154, 126);
            this.txtFolderExport.Name = "txtFolderExport";
            this.txtFolderExport.Size = new System.Drawing.Size(311, 20);
            this.txtFolderExport.TabIndex = 9;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(247, 230);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 26);
            this.button4.TabIndex = 10;
            this.button4.Text = "Open Exporting Folder";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(247, 273);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(120, 26);
            this.button5.TabIndex = 11;
            this.button5.Text = "Convert Files";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Converter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(477, 360);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtFolderExport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FilesView);
            this.Controls.Add(this.txtBox_Folder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmd_browse);
            this.Name = "Converter";
            this.ShowInTaskbar = false;
            this.Text = "Converter";
            ((System.ComponentModel.ISupportInitialize)(this.FilesView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmd_browse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBox_Folder;
        private System.Windows.Forms.DataGridView FilesView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFolderExport;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

