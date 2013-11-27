namespace RefplusWebtools.DataManager.Pricing
{
    partial class FrmPricingCoilBlygold
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPricingCoilBlygold));
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lblPolualCost = new System.Windows.Forms.Label();
            this.numPolualCost = new System.Windows.Forms.NumericUpDown();
            this.numPolualCoverage = new System.Windows.Forms.NumericUpDown();
            this.lblPolualCoverage = new System.Windows.Forms.Label();
            this.numPretreatmentCosts = new System.Windows.Forms.NumericUpDown();
            this.lblPretreatmentCosts = new System.Windows.Forms.Label();
            this.numSafeCost = new System.Windows.Forms.NumericUpDown();
            this.lblSafeCosts = new System.Windows.Forms.Label();
            this.numPretreatmentCoverage = new System.Windows.Forms.NumericUpDown();
            this.lblPretreatmentCoverage = new System.Windows.Forms.Label();
            this.numLaborCost = new System.Windows.Forms.NumericUpDown();
            this.lblLaborCost = new System.Windows.Forms.Label();
            this.numSafeCoverage = new System.Windows.Forms.NumericUpDown();
            this.lblSafeCoverage = new System.Windows.Forms.Label();
            this.numUSD = new System.Windows.Forms.NumericUpDown();
            this.lblUSD = new System.Windows.Forms.Label();
            this.numFacedAreaOutput = new System.Windows.Forms.NumericUpDown();
            this.lblFacedAreaOutput = new System.Windows.Forms.Label();
            this.numSundry = new System.Windows.Forms.NumericUpDown();
            this.lblSundry = new System.Windows.Forms.Label();
            this.numExchange = new System.Windows.Forms.NumericUpDown();
            this.lblExchange = new System.Windows.Forms.Label();
            this.numTransportProducts = new System.Windows.Forms.NumericUpDown();
            this.lblTransportProducts = new System.Windows.Forms.Label();
            this.numReturnBends = new System.Windows.Forms.NumericUpDown();
            this.lblReturnBends = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPolualCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPolualCoverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPretreatmentCosts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSafeCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPretreatmentCoverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLaborCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSafeCoverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUSD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFacedAreaOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSundry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExchange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTransportProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReturnBends)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(448, 194);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(150, 25);
            this.cmdClose.TabIndex = 15;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(12, 194);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(150, 25);
            this.cmdSave.TabIndex = 13;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lblPolualCost
            // 
            this.lblPolualCost.AutoSize = true;
            this.lblPolualCost.Location = new System.Drawing.Point(9, 9);
            this.lblPolualCost.Name = "lblPolualCost";
            this.lblPolualCost.Size = new System.Drawing.Size(70, 13);
            this.lblPolualCost.TabIndex = 162;
            this.lblPolualCost.Text = "sPolual Costs";
            // 
            // numPolualCost
            // 
            this.numPolualCost.DecimalPlaces = 4;
            this.numPolualCost.Location = new System.Drawing.Point(171, 7);
            this.numPolualCost.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPolualCost.Name = "numPolualCost";
            this.numPolualCost.Size = new System.Drawing.Size(120, 20);
            this.numPolualCost.TabIndex = 0;
            this.numPolualCost.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // numPolualCoverage
            // 
            this.numPolualCoverage.DecimalPlaces = 4;
            this.numPolualCoverage.Location = new System.Drawing.Point(171, 33);
            this.numPolualCoverage.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPolualCoverage.Name = "numPolualCoverage";
            this.numPolualCoverage.Size = new System.Drawing.Size(120, 20);
            this.numPolualCoverage.TabIndex = 1;
            this.numPolualCoverage.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblPolualCoverage
            // 
            this.lblPolualCoverage.AutoSize = true;
            this.lblPolualCoverage.Location = new System.Drawing.Point(9, 35);
            this.lblPolualCoverage.Name = "lblPolualCoverage";
            this.lblPolualCoverage.Size = new System.Drawing.Size(90, 13);
            this.lblPolualCoverage.TabIndex = 164;
            this.lblPolualCoverage.Text = "sPolual Coverage";
            // 
            // numPretreatmentCosts
            // 
            this.numPretreatmentCosts.DecimalPlaces = 4;
            this.numPretreatmentCosts.Location = new System.Drawing.Point(171, 59);
            this.numPretreatmentCosts.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPretreatmentCosts.Name = "numPretreatmentCosts";
            this.numPretreatmentCosts.Size = new System.Drawing.Size(120, 20);
            this.numPretreatmentCosts.TabIndex = 2;
            this.numPretreatmentCosts.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblPretreatmentCosts
            // 
            this.lblPretreatmentCosts.AutoSize = true;
            this.lblPretreatmentCosts.Location = new System.Drawing.Point(9, 61);
            this.lblPretreatmentCosts.Name = "lblPretreatmentCosts";
            this.lblPretreatmentCosts.Size = new System.Drawing.Size(101, 13);
            this.lblPretreatmentCosts.TabIndex = 166;
            this.lblPretreatmentCosts.Text = "sPretreatment Costs";
            // 
            // numSafeCost
            // 
            this.numSafeCost.DecimalPlaces = 4;
            this.numSafeCost.Location = new System.Drawing.Point(171, 111);
            this.numSafeCost.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numSafeCost.Name = "numSafeCost";
            this.numSafeCost.Size = new System.Drawing.Size(120, 20);
            this.numSafeCost.TabIndex = 4;
            this.numSafeCost.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblSafeCosts
            // 
            this.lblSafeCosts.AutoSize = true;
            this.lblSafeCosts.Location = new System.Drawing.Point(9, 113);
            this.lblSafeCosts.Name = "lblSafeCosts";
            this.lblSafeCosts.Size = new System.Drawing.Size(58, 13);
            this.lblSafeCosts.TabIndex = 170;
            this.lblSafeCosts.Text = "sSafe Cost";
            // 
            // numPretreatmentCoverage
            // 
            this.numPretreatmentCoverage.DecimalPlaces = 4;
            this.numPretreatmentCoverage.Location = new System.Drawing.Point(171, 85);
            this.numPretreatmentCoverage.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPretreatmentCoverage.Name = "numPretreatmentCoverage";
            this.numPretreatmentCoverage.Size = new System.Drawing.Size(120, 20);
            this.numPretreatmentCoverage.TabIndex = 3;
            this.numPretreatmentCoverage.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblPretreatmentCoverage
            // 
            this.lblPretreatmentCoverage.AutoSize = true;
            this.lblPretreatmentCoverage.Location = new System.Drawing.Point(9, 87);
            this.lblPretreatmentCoverage.Name = "lblPretreatmentCoverage";
            this.lblPretreatmentCoverage.Size = new System.Drawing.Size(121, 13);
            this.lblPretreatmentCoverage.TabIndex = 168;
            this.lblPretreatmentCoverage.Text = "sPretreatment Coverage";
            // 
            // numLaborCost
            // 
            this.numLaborCost.DecimalPlaces = 4;
            this.numLaborCost.Location = new System.Drawing.Point(171, 163);
            this.numLaborCost.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numLaborCost.Name = "numLaborCost";
            this.numLaborCost.Size = new System.Drawing.Size(120, 20);
            this.numLaborCost.TabIndex = 6;
            this.numLaborCost.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblLaborCost
            // 
            this.lblLaborCost.AutoSize = true;
            this.lblLaborCost.Location = new System.Drawing.Point(9, 165);
            this.lblLaborCost.Name = "lblLaborCost";
            this.lblLaborCost.Size = new System.Drawing.Size(63, 13);
            this.lblLaborCost.TabIndex = 174;
            this.lblLaborCost.Text = "sLabor Cost";
            // 
            // numSafeCoverage
            // 
            this.numSafeCoverage.DecimalPlaces = 4;
            this.numSafeCoverage.Location = new System.Drawing.Point(171, 137);
            this.numSafeCoverage.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numSafeCoverage.Name = "numSafeCoverage";
            this.numSafeCoverage.Size = new System.Drawing.Size(120, 20);
            this.numSafeCoverage.TabIndex = 5;
            this.numSafeCoverage.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblSafeCoverage
            // 
            this.lblSafeCoverage.AutoSize = true;
            this.lblSafeCoverage.Location = new System.Drawing.Point(9, 139);
            this.lblSafeCoverage.Name = "lblSafeCoverage";
            this.lblSafeCoverage.Size = new System.Drawing.Size(83, 13);
            this.lblSafeCoverage.TabIndex = 172;
            this.lblSafeCoverage.Text = "sSafe Coverage";
            // 
            // numUSD
            // 
            this.numUSD.DecimalPlaces = 4;
            this.numUSD.Location = new System.Drawing.Point(478, 33);
            this.numUSD.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numUSD.Name = "numUSD";
            this.numUSD.Size = new System.Drawing.Size(120, 20);
            this.numUSD.TabIndex = 8;
            this.numUSD.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblUSD
            // 
            this.lblUSD.AutoSize = true;
            this.lblUSD.Location = new System.Drawing.Point(316, 35);
            this.lblUSD.Name = "lblUSD";
            this.lblUSD.Size = new System.Drawing.Size(35, 13);
            this.lblUSD.TabIndex = 178;
            this.lblUSD.Text = "sUSD";
            // 
            // numFacedAreaOutput
            // 
            this.numFacedAreaOutput.DecimalPlaces = 4;
            this.numFacedAreaOutput.Location = new System.Drawing.Point(478, 7);
            this.numFacedAreaOutput.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numFacedAreaOutput.Name = "numFacedAreaOutput";
            this.numFacedAreaOutput.Size = new System.Drawing.Size(120, 20);
            this.numFacedAreaOutput.TabIndex = 7;
            this.numFacedAreaOutput.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblFacedAreaOutput
            // 
            this.lblFacedAreaOutput.AutoSize = true;
            this.lblFacedAreaOutput.Location = new System.Drawing.Point(316, 9);
            this.lblFacedAreaOutput.Name = "lblFacedAreaOutput";
            this.lblFacedAreaOutput.Size = new System.Drawing.Size(102, 13);
            this.lblFacedAreaOutput.TabIndex = 176;
            this.lblFacedAreaOutput.Text = "sFaced Area Output";
            // 
            // numSundry
            // 
            this.numSundry.DecimalPlaces = 4;
            this.numSundry.Location = new System.Drawing.Point(478, 85);
            this.numSundry.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numSundry.Name = "numSundry";
            this.numSundry.Size = new System.Drawing.Size(120, 20);
            this.numSundry.TabIndex = 10;
            this.numSundry.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblSundry
            // 
            this.lblSundry.AutoSize = true;
            this.lblSundry.Location = new System.Drawing.Point(316, 87);
            this.lblSundry.Name = "lblSundry";
            this.lblSundry.Size = new System.Drawing.Size(45, 13);
            this.lblSundry.TabIndex = 182;
            this.lblSundry.Text = "sSundry";
            // 
            // numExchange
            // 
            this.numExchange.DecimalPlaces = 4;
            this.numExchange.Location = new System.Drawing.Point(478, 59);
            this.numExchange.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numExchange.Name = "numExchange";
            this.numExchange.Size = new System.Drawing.Size(120, 20);
            this.numExchange.TabIndex = 9;
            this.numExchange.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblExchange
            // 
            this.lblExchange.AutoSize = true;
            this.lblExchange.Location = new System.Drawing.Point(316, 61);
            this.lblExchange.Name = "lblExchange";
            this.lblExchange.Size = new System.Drawing.Size(60, 13);
            this.lblExchange.TabIndex = 180;
            this.lblExchange.Text = "sExchange";
            // 
            // numTransportProducts
            // 
            this.numTransportProducts.DecimalPlaces = 4;
            this.numTransportProducts.Location = new System.Drawing.Point(478, 137);
            this.numTransportProducts.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numTransportProducts.Name = "numTransportProducts";
            this.numTransportProducts.Size = new System.Drawing.Size(120, 20);
            this.numTransportProducts.TabIndex = 12;
            this.numTransportProducts.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblTransportProducts
            // 
            this.lblTransportProducts.AutoSize = true;
            this.lblTransportProducts.Location = new System.Drawing.Point(316, 139);
            this.lblTransportProducts.Name = "lblTransportProducts";
            this.lblTransportProducts.Size = new System.Drawing.Size(102, 13);
            this.lblTransportProducts.TabIndex = 186;
            this.lblTransportProducts.Text = "sTransport Products";
            // 
            // numReturnBends
            // 
            this.numReturnBends.DecimalPlaces = 4;
            this.numReturnBends.Location = new System.Drawing.Point(478, 111);
            this.numReturnBends.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numReturnBends.Name = "numReturnBends";
            this.numReturnBends.Size = new System.Drawing.Size(120, 20);
            this.numReturnBends.TabIndex = 11;
            this.numReturnBends.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblReturnBends
            // 
            this.lblReturnBends.AutoSize = true;
            this.lblReturnBends.Location = new System.Drawing.Point(316, 113);
            this.lblReturnBends.Name = "lblReturnBends";
            this.lblReturnBends.Size = new System.Drawing.Size(77, 13);
            this.lblReturnBends.TabIndex = 184;
            this.lblReturnBends.Text = "sReturn Bends";
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(287, 195);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 14;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmPricingCoilBlygold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(613, 229);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.numTransportProducts);
            this.Controls.Add(this.lblTransportProducts);
            this.Controls.Add(this.numReturnBends);
            this.Controls.Add(this.lblReturnBends);
            this.Controls.Add(this.numSundry);
            this.Controls.Add(this.lblSundry);
            this.Controls.Add(this.numExchange);
            this.Controls.Add(this.lblExchange);
            this.Controls.Add(this.numUSD);
            this.Controls.Add(this.lblUSD);
            this.Controls.Add(this.numFacedAreaOutput);
            this.Controls.Add(this.lblFacedAreaOutput);
            this.Controls.Add(this.numLaborCost);
            this.Controls.Add(this.lblLaborCost);
            this.Controls.Add(this.numSafeCoverage);
            this.Controls.Add(this.lblSafeCoverage);
            this.Controls.Add(this.numSafeCost);
            this.Controls.Add(this.lblSafeCosts);
            this.Controls.Add(this.numPretreatmentCoverage);
            this.Controls.Add(this.lblPretreatmentCoverage);
            this.Controls.Add(this.numPretreatmentCosts);
            this.Controls.Add(this.lblPretreatmentCosts);
            this.Controls.Add(this.numPolualCoverage);
            this.Controls.Add(this.lblPolualCoverage);
            this.Controls.Add(this.numPolualCost);
            this.Controls.Add(this.lblPolualCost);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmPricingCoilBlygold";
            this.Text = "sData Manager - Pricing Coil Blygold";
            this.Load += new System.EventHandler(this.frmCoilBlygold_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmPricingCoilBlygold_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.numPolualCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPolualCoverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPretreatmentCosts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSafeCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPretreatmentCoverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLaborCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSafeCoverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUSD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFacedAreaOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSundry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExchange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTransportProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReturnBends)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label lblPolualCost;
        private System.Windows.Forms.NumericUpDown numPolualCost;
        private System.Windows.Forms.NumericUpDown numPolualCoverage;
        private System.Windows.Forms.Label lblPolualCoverage;
        private System.Windows.Forms.NumericUpDown numPretreatmentCosts;
        private System.Windows.Forms.Label lblPretreatmentCosts;
        private System.Windows.Forms.NumericUpDown numSafeCost;
        private System.Windows.Forms.Label lblSafeCosts;
        private System.Windows.Forms.NumericUpDown numPretreatmentCoverage;
        private System.Windows.Forms.Label lblPretreatmentCoverage;
        private System.Windows.Forms.NumericUpDown numLaborCost;
        private System.Windows.Forms.Label lblLaborCost;
        private System.Windows.Forms.NumericUpDown numSafeCoverage;
        private System.Windows.Forms.Label lblSafeCoverage;
        private System.Windows.Forms.NumericUpDown numUSD;
        private System.Windows.Forms.Label lblUSD;
        private System.Windows.Forms.NumericUpDown numFacedAreaOutput;
        private System.Windows.Forms.Label lblFacedAreaOutput;
        private System.Windows.Forms.NumericUpDown numSundry;
        private System.Windows.Forms.Label lblSundry;
        private System.Windows.Forms.NumericUpDown numExchange;
        private System.Windows.Forms.Label lblExchange;
        private System.Windows.Forms.NumericUpDown numTransportProducts;
        private System.Windows.Forms.Label lblTransportProducts;
        private System.Windows.Forms.NumericUpDown numReturnBends;
        private System.Windows.Forms.Label lblReturnBends;
        private System.Windows.Forms.Button btnHelp;
    }
}