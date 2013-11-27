namespace RefplusWebtools.DataManager.FluidCooler
{
    partial class FrmFluidCoolerPricingReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFluidCoolerPricingReport));
            this.MyFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.cmdGenerateReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdGenerateReport
            // 
            this.cmdGenerateReport.Image = ((System.Drawing.Image)(resources.GetObject("cmdGenerateReport.Image")));
            this.cmdGenerateReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGenerateReport.Location = new System.Drawing.Point(12, 11);
            this.cmdGenerateReport.Name = "cmdGenerateReport";
            this.cmdGenerateReport.Size = new System.Drawing.Size(281, 25);
            this.cmdGenerateReport.TabIndex = 8;
            this.cmdGenerateReport.Text = "sGenerate Report";
            this.cmdGenerateReport.UseVisualStyleBackColor = true;
            this.cmdGenerateReport.Click += new System.EventHandler(this.cmdGenerateReport_Click);
            // 
            // frmFluidCoolerPricingReport
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(310, 48);
            this.Controls.Add(this.cmdGenerateReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFluidCoolerPricingReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "sFluid Cooler List Price & Blygold Report";
            this.Load += new System.EventHandler(this.frmFluidCoolerPricingReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog MyFolderBrowser;
        private System.Windows.Forms.Button cmdGenerateReport;
    }
}