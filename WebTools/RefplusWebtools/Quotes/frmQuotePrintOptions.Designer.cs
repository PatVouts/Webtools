namespace RefplusWebtools.Quotes
{
    partial class FrmQuotePrintOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQuotePrintOptions));
            this.chkPricingHeaderPage = new System.Windows.Forms.CheckBox();
            this.chkPricingPages = new System.Windows.Forms.CheckBox();
            this.chkPerformanceSheets = new System.Windows.Forms.CheckBox();
            this.chkDrawings = new System.Windows.Forms.CheckBox();
            this.cmdContinue = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.pnlPricingPage = new System.Windows.Forms.Panel();
            this.radNonDetailed = new System.Windows.Forms.RadioButton();
            this.radDetailed = new System.Windows.Forms.RadioButton();
            this.chkDimensions = new System.Windows.Forms.CheckBox();
            this.pnlPricingPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkPricingHeaderPage
            // 
            this.chkPricingHeaderPage.AutoSize = true;
            this.chkPricingHeaderPage.Checked = true;
            this.chkPricingHeaderPage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPricingHeaderPage.Location = new System.Drawing.Point(12, 12);
            this.chkPricingHeaderPage.Name = "chkPricingHeaderPage";
            this.chkPricingHeaderPage.Size = new System.Drawing.Size(129, 17);
            this.chkPricingHeaderPage.TabIndex = 0;
            this.chkPricingHeaderPage.Text = "sPricing Header Page";
            this.chkPricingHeaderPage.UseVisualStyleBackColor = true;
            // 
            // chkPricingPages
            // 
            this.chkPricingPages.AutoSize = true;
            this.chkPricingPages.Checked = true;
            this.chkPricingPages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPricingPages.Location = new System.Drawing.Point(12, 35);
            this.chkPricingPages.Name = "chkPricingPages";
            this.chkPricingPages.Size = new System.Drawing.Size(96, 17);
            this.chkPricingPages.TabIndex = 1;
            this.chkPricingPages.Text = "sPricing Pages";
            this.chkPricingPages.UseVisualStyleBackColor = true;
            this.chkPricingPages.CheckedChanged += new System.EventHandler(this.chkPricingPages_CheckedChanged);
            // 
            // chkPerformanceSheets
            // 
            this.chkPerformanceSheets.AutoSize = true;
            this.chkPerformanceSheets.Checked = true;
            this.chkPerformanceSheets.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPerformanceSheets.Location = new System.Drawing.Point(12, 97);
            this.chkPerformanceSheets.Name = "chkPerformanceSheets";
            this.chkPerformanceSheets.Size = new System.Drawing.Size(127, 17);
            this.chkPerformanceSheets.TabIndex = 2;
            this.chkPerformanceSheets.Text = "sPerformance Sheets";
            this.chkPerformanceSheets.UseVisualStyleBackColor = true;
            // 
            // chkDrawings
            // 
            this.chkDrawings.AutoSize = true;
            this.chkDrawings.Checked = true;
            this.chkDrawings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDrawings.Location = new System.Drawing.Point(12, 124);
            this.chkDrawings.Name = "chkDrawings";
            this.chkDrawings.Size = new System.Drawing.Size(75, 17);
            this.chkDrawings.TabIndex = 5;
            this.chkDrawings.Text = "sDrawings";
            this.chkDrawings.UseVisualStyleBackColor = true;
            // 
            // cmdContinue
            // 
            this.cmdContinue.Image = ((System.Drawing.Image)(resources.GetObject("cmdContinue.Image")));
            this.cmdContinue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdContinue.Location = new System.Drawing.Point(12, 177);
            this.cmdContinue.Name = "cmdContinue";
            this.cmdContinue.Size = new System.Drawing.Size(121, 25);
            this.cmdContinue.TabIndex = 6;
            this.cmdContinue.Text = "sContinue";
            this.cmdContinue.UseVisualStyleBackColor = true;
            this.cmdContinue.Click += new System.EventHandler(this.cmdContinue_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(139, 177);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 7;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // pnlPricingPage
            // 
            this.pnlPricingPage.Controls.Add(this.radNonDetailed);
            this.pnlPricingPage.Controls.Add(this.radDetailed);
            this.pnlPricingPage.Location = new System.Drawing.Point(40, 55);
            this.pnlPricingPage.Name = "pnlPricingPage";
            this.pnlPricingPage.Size = new System.Drawing.Size(107, 39);
            this.pnlPricingPage.TabIndex = 8;
            // 
            // radNonDetailed
            // 
            this.radNonDetailed.AutoSize = true;
            this.radNonDetailed.Location = new System.Drawing.Point(3, 19);
            this.radNonDetailed.Name = "radNonDetailed";
            this.radNonDetailed.Size = new System.Drawing.Size(90, 17);
            this.radNonDetailed.TabIndex = 1;
            this.radNonDetailed.Text = "sNon-detailed";
            this.radNonDetailed.UseVisualStyleBackColor = true;
            // 
            // radDetailed
            // 
            this.radDetailed.AutoSize = true;
            this.radDetailed.Checked = true;
            this.radDetailed.Location = new System.Drawing.Point(3, 3);
            this.radDetailed.Name = "radDetailed";
            this.radDetailed.Size = new System.Drawing.Size(69, 17);
            this.radDetailed.TabIndex = 0;
            this.radDetailed.TabStop = true;
            this.radDetailed.Text = "sDetailed";
            this.radDetailed.UseVisualStyleBackColor = true;
            // 
            // chkDimensions
            // 
            this.chkDimensions.AutoSize = true;
            this.chkDimensions.Checked = true;
            this.chkDimensions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDimensions.Location = new System.Drawing.Point(12, 147);
            this.chkDimensions.Name = "chkDimensions";
            this.chkDimensions.Size = new System.Drawing.Size(80, 17);
            this.chkDimensions.TabIndex = 9;
            this.chkDimensions.Text = "Dimensions";
            this.chkDimensions.UseVisualStyleBackColor = true;
            this.chkDimensions.Visible = false;
            // 
            // FrmQuotePrintOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(185, 214);
            this.ControlBox = false;
            this.Controls.Add(this.chkDimensions);
            this.Controls.Add(this.pnlPricingPage);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cmdContinue);
            this.Controls.Add(this.chkDrawings);
            this.Controls.Add(this.chkPerformanceSheets);
            this.Controls.Add(this.chkPricingPages);
            this.Controls.Add(this.chkPricingHeaderPage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQuotePrintOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "sPrinting Options";
            this.Load += new System.EventHandler(this.frmQuotePrintFormat_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmQuotePrintOptions_HelpRequested);
            this.pnlPricingPage.ResumeLayout(false);
            this.pnlPricingPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkPricingHeaderPage;
        private System.Windows.Forms.CheckBox chkPricingPages;
        private System.Windows.Forms.CheckBox chkPerformanceSheets;
        private System.Windows.Forms.CheckBox chkDrawings;
        private System.Windows.Forms.Button cmdContinue;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Panel pnlPricingPage;
        private System.Windows.Forms.RadioButton radNonDetailed;
        private System.Windows.Forms.RadioButton radDetailed;
        private System.Windows.Forms.CheckBox chkDimensions;
    }
}