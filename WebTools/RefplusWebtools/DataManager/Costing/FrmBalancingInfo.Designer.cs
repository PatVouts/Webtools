namespace RefplusWebtools.DataManager.Costing
{
    partial class FrmBalancingInfo
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
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblCommercializedPercentage = new System.Windows.Forms.Label();
            this.numCommercializedFactor = new System.Windows.Forms.NumericUpDown();
            this.lblBalancing = new System.Windows.Forms.Label();
            this.lblBalancingTo = new System.Windows.Forms.Label();
            this.numSSTMin = new System.Windows.Forms.NumericUpDown();
            this.numBalancingMax = new System.Windows.Forms.NumericUpDown();
            this.numSSTMax = new System.Windows.Forms.NumericUpDown();
            this.numBalancingMin = new System.Windows.Forms.NumericUpDown();
            this.lblSST = new System.Windows.Forms.Label();
            this.lblSSTTo = new System.Windows.Forms.Label();
            this.btnContinue = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCommercializedFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSSTMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBalancingMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSSTMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBalancingMin)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(268, 69);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(15, 13);
            this.lblPercent.TabIndex = 154;
            this.lblPercent.Text = "%";
            this.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCommercializedPercentage
            // 
            this.lblCommercializedPercentage.AutoSize = true;
            this.lblCommercializedPercentage.Location = new System.Drawing.Point(9, 69);
            this.lblCommercializedPercentage.Name = "lblCommercializedPercentage";
            this.lblCommercializedPercentage.Size = new System.Drawing.Size(162, 13);
            this.lblCommercializedPercentage.TabIndex = 153;
            this.lblCommercializedPercentage.Text = "sCommercialized Capacity Factor";
            this.lblCommercializedPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numCommercializedFactor
            // 
            this.numCommercializedFactor.DecimalPlaces = 2;
            this.numCommercializedFactor.Location = new System.Drawing.Point(199, 67);
            this.numCommercializedFactor.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numCommercializedFactor.Name = "numCommercializedFactor";
            this.numCommercializedFactor.Size = new System.Drawing.Size(63, 20);
            this.numCommercializedFactor.TabIndex = 148;
            this.numCommercializedFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBalancing
            // 
            this.lblBalancing.AutoSize = true;
            this.lblBalancing.Location = new System.Drawing.Point(9, 19);
            this.lblBalancing.Name = "lblBalancing";
            this.lblBalancing.Size = new System.Drawing.Size(59, 13);
            this.lblBalancing.TabIndex = 149;
            this.lblBalancing.Text = "sBalancing";
            this.lblBalancing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBalancingTo
            // 
            this.lblBalancingTo.AutoSize = true;
            this.lblBalancingTo.Location = new System.Drawing.Point(190, 19);
            this.lblBalancingTo.Name = "lblBalancingTo";
            this.lblBalancingTo.Size = new System.Drawing.Size(25, 13);
            this.lblBalancingTo.TabIndex = 150;
            this.lblBalancingTo.Text = "sTo";
            this.lblBalancingTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numSSTMin
            // 
            this.numSSTMin.Location = new System.Drawing.Point(143, 43);
            this.numSSTMin.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numSSTMin.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.numSSTMin.Name = "numSSTMin";
            this.numSSTMin.Size = new System.Drawing.Size(45, 20);
            this.numSSTMin.TabIndex = 145;
            this.numSSTMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSSTMin.Value = new decimal(new int[] {
            40,
            0,
            0,
            -2147483648});
            // 
            // numBalancingMax
            // 
            this.numBalancingMax.Location = new System.Drawing.Point(217, 17);
            this.numBalancingMax.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numBalancingMax.Name = "numBalancingMax";
            this.numBalancingMax.Size = new System.Drawing.Size(45, 20);
            this.numBalancingMax.TabIndex = 146;
            this.numBalancingMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numBalancingMax.Value = new decimal(new int[] {
            105,
            0,
            0,
            0});
            // 
            // numSSTMax
            // 
            this.numSSTMax.Location = new System.Drawing.Point(217, 43);
            this.numSSTMax.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numSSTMax.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.numSSTMax.Name = "numSSTMax";
            this.numSSTMax.Size = new System.Drawing.Size(45, 20);
            this.numSSTMax.TabIndex = 147;
            this.numSSTMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSSTMax.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // numBalancingMin
            // 
            this.numBalancingMin.Location = new System.Drawing.Point(143, 17);
            this.numBalancingMin.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numBalancingMin.Name = "numBalancingMin";
            this.numBalancingMin.Size = new System.Drawing.Size(45, 20);
            this.numBalancingMin.TabIndex = 144;
            this.numBalancingMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numBalancingMin.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // lblSST
            // 
            this.lblSST.AutoSize = true;
            this.lblSST.Location = new System.Drawing.Point(9, 45);
            this.lblSST.Name = "lblSST";
            this.lblSST.Size = new System.Drawing.Size(33, 13);
            this.lblSST.TabIndex = 151;
            this.lblSST.Text = "sSST";
            this.lblSST.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSSTTo
            // 
            this.lblSSTTo.AutoSize = true;
            this.lblSSTTo.Location = new System.Drawing.Point(190, 45);
            this.lblSSTTo.Name = "lblSSTTo";
            this.lblSSTTo.Size = new System.Drawing.Size(25, 13);
            this.lblSSTTo.TabIndex = 152;
            this.lblSSTTo.Text = "sTo";
            this.lblSSTTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(113, 100);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(75, 23);
            this.btnContinue.TabIndex = 155;
            this.btnContinue.Text = "button1";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // FrmBalancingInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 142);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.lblCommercializedPercentage);
            this.Controls.Add(this.numCommercializedFactor);
            this.Controls.Add(this.lblBalancing);
            this.Controls.Add(this.lblBalancingTo);
            this.Controls.Add(this.numSSTMin);
            this.Controls.Add(this.numBalancingMax);
            this.Controls.Add(this.numSSTMax);
            this.Controls.Add(this.numBalancingMin);
            this.Controls.Add(this.lblSST);
            this.Controls.Add(this.lblSSTTo);
            this.Name = "FrmBalancingInfo";
            this.Text = "FrmBalancingInfo";
            this.Load += new System.EventHandler(this.FrmBalancingInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numCommercializedFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSSTMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBalancingMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSSTMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBalancingMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Label lblCommercializedPercentage;
        private System.Windows.Forms.NumericUpDown numCommercializedFactor;
        private System.Windows.Forms.Label lblBalancing;
        private System.Windows.Forms.Label lblBalancingTo;
        private System.Windows.Forms.NumericUpDown numSSTMin;
        private System.Windows.Forms.NumericUpDown numBalancingMax;
        private System.Windows.Forms.NumericUpDown numSSTMax;
        private System.Windows.Forms.NumericUpDown numBalancingMin;
        private System.Windows.Forms.Label lblSST;
        private System.Windows.Forms.Label lblSSTTo;
        private System.Windows.Forms.Button btnContinue;
    }
}