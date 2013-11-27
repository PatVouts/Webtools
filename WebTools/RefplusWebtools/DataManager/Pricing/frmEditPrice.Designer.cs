namespace RefplusWebtools.DataManager.Pricing
{
    partial class FrmEditPrice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditPrice));
            this.cmdAccept = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.numNewPrice = new System.Windows.Forms.NumericUpDown();
            this.lblNewPrice = new System.Windows.Forms.Label();
            this.lblCurrentPrice = new System.Windows.Forms.Label();
            this.lblCurrentPriceValue = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numNewPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdAccept
            // 
            this.cmdAccept.Image = ((System.Drawing.Image)(resources.GetObject("cmdAccept.Image")));
            this.cmdAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAccept.Location = new System.Drawing.Point(12, 77);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(139, 25);
            this.cmdAccept.TabIndex = 1;
            this.cmdAccept.Text = "sAccept";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(189, 77);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(139, 25);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "sCancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // numNewPrice
            // 
            this.numNewPrice.DecimalPlaces = 2;
            this.numNewPrice.Location = new System.Drawing.Point(145, 41);
            this.numNewPrice.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numNewPrice.Name = "numNewPrice";
            this.numNewPrice.Size = new System.Drawing.Size(183, 20);
            this.numNewPrice.TabIndex = 0;
            this.numNewPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numNewPrice.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblNewPrice
            // 
            this.lblNewPrice.AutoSize = true;
            this.lblNewPrice.Location = new System.Drawing.Point(9, 43);
            this.lblNewPrice.Name = "lblNewPrice";
            this.lblNewPrice.Size = new System.Drawing.Size(61, 13);
            this.lblNewPrice.TabIndex = 14;
            this.lblNewPrice.Text = "sNew Price";
            // 
            // lblCurrentPrice
            // 
            this.lblCurrentPrice.AutoSize = true;
            this.lblCurrentPrice.Location = new System.Drawing.Point(12, 9);
            this.lblCurrentPrice.Name = "lblCurrentPrice";
            this.lblCurrentPrice.Size = new System.Drawing.Size(73, 13);
            this.lblCurrentPrice.TabIndex = 16;
            this.lblCurrentPrice.Text = "sCurrent Price";
            // 
            // lblCurrentPriceValue
            // 
            this.lblCurrentPriceValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblCurrentPriceValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentPriceValue.Location = new System.Drawing.Point(145, 8);
            this.lblCurrentPriceValue.Name = "lblCurrentPriceValue";
            this.lblCurrentPriceValue.Size = new System.Drawing.Size(183, 20);
            this.lblCurrentPriceValue.TabIndex = 17;
            this.lblCurrentPriceValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(156, 78);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmEditPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(337, 112);
            this.ControlBox = false;
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblCurrentPriceValue);
            this.Controls.Add(this.lblCurrentPrice);
            this.Controls.Add(this.numNewPrice);
            this.Controls.Add(this.lblNewPrice);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.cmdCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditPrice";
            this.ShowInTaskbar = false;
            this.Text = "sEdit Price";
            this.Load += new System.EventHandler(this.frmEditPrice_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmEditPrice_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.numNewPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdAccept;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.NumericUpDown numNewPrice;
        private System.Windows.Forms.Label lblNewPrice;
        private System.Windows.Forms.Label lblCurrentPrice;
        private System.Windows.Forms.Label lblCurrentPriceValue;
        private System.Windows.Forms.Button btnHelp;
    }
}