namespace RefplusWebtools.DataManager.Pricing
{
    partial class FrmControlPanelAndOptionPriceIncrease
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmControlPanelAndOptionPriceIncrease));
            this.cmdClose = new System.Windows.Forms.Button();
            this.lblIncreaseDecreaseFactor = new System.Windows.Forms.Label();
            this.numFactor = new System.Windows.Forms.NumericUpDown();
            this.cmdGoToConfirmation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numFactor)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(355, 145);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(178, 25);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // lblIncreaseDecreaseFactor
            // 
            this.lblIncreaseDecreaseFactor.Location = new System.Drawing.Point(70, 66);
            this.lblIncreaseDecreaseFactor.Name = "lblIncreaseDecreaseFactor";
            this.lblIncreaseDecreaseFactor.Size = new System.Drawing.Size(182, 13);
            this.lblIncreaseDecreaseFactor.TabIndex = 3;
            this.lblIncreaseDecreaseFactor.Text = "sIncease/Decrease Factor";
            this.lblIncreaseDecreaseFactor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numFactor
            // 
            this.numFactor.DecimalPlaces = 2;
            this.numFactor.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numFactor.Location = new System.Drawing.Point(259, 64);
            this.numFactor.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numFactor.Name = "numFactor";
            this.numFactor.Size = new System.Drawing.Size(186, 20);
            this.numFactor.TabIndex = 2;
            this.numFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdGoToConfirmation
            // 
            this.cmdGoToConfirmation.Image = ((System.Drawing.Image)(resources.GetObject("cmdGoToConfirmation.Image")));
            this.cmdGoToConfirmation.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdGoToConfirmation.Location = new System.Drawing.Point(259, 90);
            this.cmdGoToConfirmation.Name = "cmdGoToConfirmation";
            this.cmdGoToConfirmation.Size = new System.Drawing.Size(186, 25);
            this.cmdGoToConfirmation.TabIndex = 6;
            this.cmdGoToConfirmation.Text = "sGo to confirmation";
            this.cmdGoToConfirmation.UseVisualStyleBackColor = true;
            this.cmdGoToConfirmation.Click += new System.EventHandler(this.cmdGoToConfirmation_Click);
            // 
            // frmControlPanelAndOptionPriceIncrease
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(545, 182);
            this.Controls.Add(this.cmdGoToConfirmation);
            this.Controls.Add(this.lblIncreaseDecreaseFactor);
            this.Controls.Add(this.numFactor);
            this.Controls.Add(this.cmdClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmControlPanelAndOptionPriceIncrease";
            this.Text = "sData Manager - Control Panel - Panel and Option Pricing";
            this.Load += new System.EventHandler(this.frmControlPanelAndOptionPriceIncrease_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numFactor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Label lblIncreaseDecreaseFactor;
        private System.Windows.Forms.NumericUpDown numFactor;
        private System.Windows.Forms.Button cmdGoToConfirmation;
    }
}