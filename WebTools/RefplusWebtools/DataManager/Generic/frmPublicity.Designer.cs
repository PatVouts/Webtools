namespace RefplusWebtools.DataManager.Generic
{
    partial class FrmPublicity
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
            this.picPublicity = new System.Windows.Forms.PictureBox();
            this.chkNoShow = new System.Windows.Forms.CheckBox();
            this.minimizeLabel = new System.Windows.Forms.LinkLabel();
            this.maximizeLabel = new System.Windows.Forms.LinkLabel();
            this.closeLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picPublicity)).BeginInit();
            this.SuspendLayout();
            // 
            // picPublicity
            // 
            this.picPublicity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picPublicity.BackColor = System.Drawing.SystemColors.Control;
            this.picPublicity.ErrorImage = null;
            this.picPublicity.InitialImage = null;
            this.picPublicity.Location = new System.Drawing.Point(0, 31);
            this.picPublicity.Name = "picPublicity";
            this.picPublicity.Size = new System.Drawing.Size(661, 326);
            this.picPublicity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPublicity.TabIndex = 0;
            this.picPublicity.TabStop = false;
            // 
            // chkNoShow
            // 
            this.chkNoShow.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkNoShow.AutoSize = true;
            this.chkNoShow.Location = new System.Drawing.Point(268, 363);
            this.chkNoShow.Name = "chkNoShow";
            this.chkNoShow.Size = new System.Drawing.Size(125, 17);
            this.chkNoShow.TabIndex = 1;
            this.chkNoShow.Text = "sDo Not Show Again";
            this.chkNoShow.UseVisualStyleBackColor = true;
            this.chkNoShow.Visible = false;
            this.chkNoShow.CheckedChanged += new System.EventHandler(this.chkNoShow_CheckedChanged);
            // 
            // minimizeLabel
            // 
            this.minimizeLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.minimizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeLabel.AutoSize = true;
            this.minimizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeLabel.Location = new System.Drawing.Point(471, 6);
            this.minimizeLabel.Name = "minimizeLabel";
            this.minimizeLabel.Size = new System.Drawing.Size(84, 18);
            this.minimizeLabel.TabIndex = 2;
            this.minimizeLabel.TabStop = true;
            this.minimizeLabel.Text = "sMinimize";
            this.minimizeLabel.Click += new System.EventHandler(this.minimizeLabel_Click);
            // 
            // maximizeLabel
            // 
            this.maximizeLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.maximizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximizeLabel.AutoSize = true;
            this.maximizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maximizeLabel.Location = new System.Drawing.Point(561, 6);
            this.maximizeLabel.Name = "maximizeLabel";
            this.maximizeLabel.Size = new System.Drawing.Size(88, 18);
            this.maximizeLabel.TabIndex = 3;
            this.maximizeLabel.TabStop = true;
            this.maximizeLabel.Text = "sMaximize";
            this.maximizeLabel.Click += new System.EventHandler(this.maximizeLabel_Click);
            // 
            // closeLabel
            // 
            this.closeLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.closeLabel.AutoSize = true;
            this.closeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeLabel.Location = new System.Drawing.Point(12, 6);
            this.closeLabel.Name = "closeLabel";
            this.closeLabel.Size = new System.Drawing.Size(61, 18);
            this.closeLabel.TabIndex = 4;
            this.closeLabel.TabStop = true;
            this.closeLabel.Text = "sClose";
            this.closeLabel.Click += new System.EventHandler(this.closeLabel_Click);
            // 
            // frmPublicity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 384);
            this.Controls.Add(this.closeLabel);
            this.Controls.Add(this.maximizeLabel);
            this.Controls.Add(this.minimizeLabel);
            this.Controls.Add(this.chkNoShow);
            this.Controls.Add(this.picPublicity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPublicity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPublicity";
            this.Load += new System.EventHandler(this.frmPublicity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPublicity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPublicity;
        private System.Windows.Forms.CheckBox chkNoShow;
        private System.Windows.Forms.LinkLabel minimizeLabel;
        private System.Windows.Forms.LinkLabel maximizeLabel;
        private System.Windows.Forms.LinkLabel closeLabel;
    }
}