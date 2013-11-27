namespace RefplusWebtools.DataManager.Pricing
{
    partial class FrmHeresiteSafety
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHeresiteSafety));
            this.numBathHeight = new System.Windows.Forms.NumericUpDown();
            this.lblBathHeight = new System.Windows.Forms.Label();
            this.numHeightSafety = new System.Windows.Forms.NumericUpDown();
            this.lblHeightSafety = new System.Windows.Forms.Label();
            this.numBathLength = new System.Windows.Forms.NumericUpDown();
            this.lblBathLength = new System.Windows.Forms.Label();
            this.numLengthSafety = new System.Windows.Forms.NumericUpDown();
            this.lblLengthSafety = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numBathHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeightSafety)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBathLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLengthSafety)).BeginInit();
            this.SuspendLayout();
            // 
            // numBathHeight
            // 
            this.numBathHeight.DecimalPlaces = 4;
            this.numBathHeight.Location = new System.Drawing.Point(172, 12);
            this.numBathHeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numBathHeight.Name = "numBathHeight";
            this.numBathHeight.Size = new System.Drawing.Size(120, 20);
            this.numBathHeight.TabIndex = 0;
            this.numBathHeight.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblBathHeight
            // 
            this.lblBathHeight.AutoSize = true;
            this.lblBathHeight.Location = new System.Drawing.Point(10, 14);
            this.lblBathHeight.Name = "lblBathHeight";
            this.lblBathHeight.Size = new System.Drawing.Size(68, 13);
            this.lblBathHeight.TabIndex = 166;
            this.lblBathHeight.Text = "sBath Height";
            // 
            // numHeightSafety
            // 
            this.numHeightSafety.DecimalPlaces = 4;
            this.numHeightSafety.Location = new System.Drawing.Point(172, 38);
            this.numHeightSafety.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numHeightSafety.Name = "numHeightSafety";
            this.numHeightSafety.Size = new System.Drawing.Size(120, 20);
            this.numHeightSafety.TabIndex = 1;
            this.numHeightSafety.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblHeightSafety
            // 
            this.lblHeightSafety.AutoSize = true;
            this.lblHeightSafety.Location = new System.Drawing.Point(10, 40);
            this.lblHeightSafety.Name = "lblHeightSafety";
            this.lblHeightSafety.Size = new System.Drawing.Size(76, 13);
            this.lblHeightSafety.TabIndex = 168;
            this.lblHeightSafety.Text = "sHeight Safety";
            // 
            // numBathLength
            // 
            this.numBathLength.DecimalPlaces = 4;
            this.numBathLength.Location = new System.Drawing.Point(172, 64);
            this.numBathLength.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numBathLength.Name = "numBathLength";
            this.numBathLength.Size = new System.Drawing.Size(120, 20);
            this.numBathLength.TabIndex = 2;
            this.numBathLength.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblBathLength
            // 
            this.lblBathLength.AutoSize = true;
            this.lblBathLength.Location = new System.Drawing.Point(10, 66);
            this.lblBathLength.Name = "lblBathLength";
            this.lblBathLength.Size = new System.Drawing.Size(70, 13);
            this.lblBathLength.TabIndex = 170;
            this.lblBathLength.Text = "sBath Length";
            // 
            // numLengthSafety
            // 
            this.numLengthSafety.DecimalPlaces = 4;
            this.numLengthSafety.Location = new System.Drawing.Point(172, 90);
            this.numLengthSafety.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numLengthSafety.Name = "numLengthSafety";
            this.numLengthSafety.Size = new System.Drawing.Size(120, 20);
            this.numLengthSafety.TabIndex = 3;
            this.numLengthSafety.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblLengthSafety
            // 
            this.lblLengthSafety.AutoSize = true;
            this.lblLengthSafety.Location = new System.Drawing.Point(10, 92);
            this.lblLengthSafety.Name = "lblLengthSafety";
            this.lblLengthSafety.Size = new System.Drawing.Size(78, 13);
            this.lblLengthSafety.TabIndex = 172;
            this.lblLengthSafety.Text = "sLength Safety";
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(182, 116);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(110, 25);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(13, 116);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(110, 25);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(139, 117);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 5;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmHeresiteSafety
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(308, 147);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.numLengthSafety);
            this.Controls.Add(this.lblLengthSafety);
            this.Controls.Add(this.numBathLength);
            this.Controls.Add(this.lblBathLength);
            this.Controls.Add(this.numHeightSafety);
            this.Controls.Add(this.lblHeightSafety);
            this.Controls.Add(this.numBathHeight);
            this.Controls.Add(this.lblBathHeight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmHeresiteSafety";
            this.Text = "sData Manager - Heresite Safety";
            this.Load += new System.EventHandler(this.frmHeresiteSafety_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmHeresiteSafety_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.numBathHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeightSafety)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBathLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLengthSafety)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numBathHeight;
        private System.Windows.Forms.Label lblBathHeight;
        private System.Windows.Forms.NumericUpDown numHeightSafety;
        private System.Windows.Forms.Label lblHeightSafety;
        private System.Windows.Forms.NumericUpDown numBathLength;
        private System.Windows.Forms.Label lblBathLength;
        private System.Windows.Forms.NumericUpDown numLengthSafety;
        private System.Windows.Forms.Label lblLengthSafety;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button btnHelp;
    }
}