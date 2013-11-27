namespace RefplusWebtools.QuickCondenser
{
    partial class FrmCircuitEdit
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
            this.lblNRE = new System.Windows.Forms.Label();
            this.pnlNRE = new System.Windows.Forms.Panel();
            this.numSST = new System.Windows.Forms.NumericUpDown();
            this.lblSST = new System.Windows.Forms.Label();
            this.lblCompressorType = new System.Windows.Forms.Label();
            this.cboCompressorType = new System.Windows.Forms.ComboBox();
            this.lblCapacityType = new System.Windows.Forms.Label();
            this.cboCapacityType = new System.Windows.Forms.ComboBox();
            this.cboRefrigerant = new System.Windows.Forms.ComboBox();
            this.lblRefrigerant = new System.Windows.Forms.Label();
            this.numTotalHeatRejection = new System.Windows.Forms.NumericUpDown();
            this.numCondenserTemperature = new System.Windows.Forms.NumericUpDown();
            this.lblCondenserTemperature = new System.Windows.Forms.Label();
            this.lblReclaimCapacity = new System.Windows.Forms.Label();
            this.lblTotalHeatRejection = new System.Windows.Forms.Label();
            this.cmdSaveCircuit = new System.Windows.Forms.Button();
            this.pnlNRE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalHeatRejection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCondenserTemperature)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNRE
            // 
            this.lblNRE.AutoSize = true;
            this.lblNRE.Location = new System.Drawing.Point(326, 61);
            this.lblNRE.Name = "lblNRE";
            this.lblNRE.Size = new System.Drawing.Size(115, 13);
            this.lblNRE.TabIndex = 90;
            this.lblNRE.Text = "sNet Refrigerant Effect";
            this.lblNRE.Visible = false;
            // 
            // pnlNRE
            // 
            this.pnlNRE.Controls.Add(this.numSST);
            this.pnlNRE.Controls.Add(this.lblSST);
            this.pnlNRE.Controls.Add(this.lblCompressorType);
            this.pnlNRE.Controls.Add(this.cboCompressorType);
            this.pnlNRE.Location = new System.Drawing.Point(325, 7);
            this.pnlNRE.Name = "pnlNRE";
            this.pnlNRE.Size = new System.Drawing.Size(333, 51);
            this.pnlNRE.TabIndex = 82;
            // 
            // numSST
            // 
            this.numSST.Location = new System.Drawing.Point(160, 27);
            this.numSST.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numSST.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            -2147483648});
            this.numSST.Name = "numSST";
            this.numSST.Size = new System.Drawing.Size(170, 20);
            this.numSST.TabIndex = 1;
            this.numSST.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // lblSST
            // 
            this.lblSST.AutoSize = true;
            this.lblSST.Location = new System.Drawing.Point(157, 11);
            this.lblSST.Name = "lblSST";
            this.lblSST.Size = new System.Drawing.Size(160, 13);
            this.lblSST.TabIndex = 79;
            this.lblSST.Text = "sSaturated Suction Temperature";
            // 
            // lblCompressorType
            // 
            this.lblCompressorType.AutoSize = true;
            this.lblCompressorType.Location = new System.Drawing.Point(1, 10);
            this.lblCompressorType.Name = "lblCompressorType";
            this.lblCompressorType.Size = new System.Drawing.Size(94, 13);
            this.lblCompressorType.TabIndex = 78;
            this.lblCompressorType.Text = "sCompressor Type";
            // 
            // cboCompressorType
            // 
            this.cboCompressorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompressorType.FormattingEnabled = true;
            this.cboCompressorType.Location = new System.Drawing.Point(4, 26);
            this.cboCompressorType.Name = "cboCompressorType";
            this.cboCompressorType.Size = new System.Drawing.Size(150, 21);
            this.cboCompressorType.TabIndex = 0;
            // 
            // lblCapacityType
            // 
            this.lblCapacityType.AutoSize = true;
            this.lblCapacityType.Location = new System.Drawing.Point(12, 17);
            this.lblCapacityType.Name = "lblCapacityType";
            this.lblCapacityType.Size = new System.Drawing.Size(80, 13);
            this.lblCapacityType.TabIndex = 89;
            this.lblCapacityType.Text = "sCapacity Type";
            // 
            // cboCapacityType
            // 
            this.cboCapacityType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCapacityType.FormattingEnabled = true;
            this.cboCapacityType.Items.AddRange(new object[] {
            "THR - Total Heat Rejection / Reclaim Capacity",
            "NRE - Net Refrigerant Effect"});
            this.cboCapacityType.Location = new System.Drawing.Point(11, 33);
            this.cboCapacityType.Name = "cboCapacityType";
            this.cboCapacityType.Size = new System.Drawing.Size(310, 21);
            this.cboCapacityType.TabIndex = 80;
            this.cboCapacityType.SelectedIndexChanged += new System.EventHandler(this.cboCapacityType_SelectedIndexChanged);
            // 
            // cboRefrigerant
            // 
            this.cboRefrigerant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRefrigerant.FormattingEnabled = true;
            this.cboRefrigerant.Location = new System.Drawing.Point(12, 77);
            this.cboRefrigerant.Name = "cboRefrigerant";
            this.cboRefrigerant.Size = new System.Drawing.Size(150, 21);
            this.cboRefrigerant.TabIndex = 83;
            // 
            // lblRefrigerant
            // 
            this.lblRefrigerant.AutoSize = true;
            this.lblRefrigerant.Location = new System.Drawing.Point(9, 61);
            this.lblRefrigerant.Name = "lblRefrigerant";
            this.lblRefrigerant.Size = new System.Drawing.Size(64, 13);
            this.lblRefrigerant.TabIndex = 87;
            this.lblRefrigerant.Text = "sRefrigerant";
            // 
            // numTotalHeatRejection
            // 
            this.numTotalHeatRejection.Location = new System.Drawing.Point(329, 78);
            this.numTotalHeatRejection.Maximum = new decimal(new int[] {
            5000000,
            0,
            0,
            0});
            this.numTotalHeatRejection.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTotalHeatRejection.Name = "numTotalHeatRejection";
            this.numTotalHeatRejection.Size = new System.Drawing.Size(150, 20);
            this.numTotalHeatRejection.TabIndex = 86;
            this.numTotalHeatRejection.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numCondenserTemperature
            // 
            this.numCondenserTemperature.Location = new System.Drawing.Point(172, 78);
            this.numCondenserTemperature.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numCondenserTemperature.Name = "numCondenserTemperature";
            this.numCondenserTemperature.Size = new System.Drawing.Size(150, 20);
            this.numCondenserTemperature.TabIndex = 85;
            this.numCondenserTemperature.Value = new decimal(new int[] {
            110,
            0,
            0,
            0});
            this.numCondenserTemperature.ValueChanged += new System.EventHandler(this.numCondenserTemperature_ValueChanged);
            // 
            // lblCondenserTemperature
            // 
            this.lblCondenserTemperature.AutoSize = true;
            this.lblCondenserTemperature.Location = new System.Drawing.Point(169, 61);
            this.lblCondenserTemperature.Name = "lblCondenserTemperature";
            this.lblCondenserTemperature.Size = new System.Drawing.Size(126, 13);
            this.lblCondenserTemperature.TabIndex = 81;
            this.lblCondenserTemperature.Text = "sCondenser Temperature";
            // 
            // lblReclaimCapacity
            // 
            this.lblReclaimCapacity.AutoSize = true;
            this.lblReclaimCapacity.Location = new System.Drawing.Point(326, 61);
            this.lblReclaimCapacity.Name = "lblReclaimCapacity";
            this.lblReclaimCapacity.Size = new System.Drawing.Size(94, 13);
            this.lblReclaimCapacity.TabIndex = 88;
            this.lblReclaimCapacity.Text = "sReclaim Capacity";
            this.lblReclaimCapacity.Visible = false;
            // 
            // lblTotalHeatRejection
            // 
            this.lblTotalHeatRejection.AutoSize = true;
            this.lblTotalHeatRejection.Location = new System.Drawing.Point(326, 61);
            this.lblTotalHeatRejection.Name = "lblTotalHeatRejection";
            this.lblTotalHeatRejection.Size = new System.Drawing.Size(110, 13);
            this.lblTotalHeatRejection.TabIndex = 84;
            this.lblTotalHeatRejection.Text = "sTotal Heat Rejection";
            // 
            // cmdSaveCircuit
            // 
            this.cmdSaveCircuit.Location = new System.Drawing.Point(485, 75);
            this.cmdSaveCircuit.Name = "cmdSaveCircuit";
            this.cmdSaveCircuit.Size = new System.Drawing.Size(169, 23);
            this.cmdSaveCircuit.TabIndex = 91;
            this.cmdSaveCircuit.Text = "sSave Circuit";
            this.cmdSaveCircuit.UseVisualStyleBackColor = true;
            this.cmdSaveCircuit.Click += new System.EventHandler(this.cmdSaveCircuit_Click);
            // 
            // frmCircuitEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(666, 112);
            this.Controls.Add(this.cmdSaveCircuit);
            this.Controls.Add(this.lblNRE);
            this.Controls.Add(this.pnlNRE);
            this.Controls.Add(this.lblCapacityType);
            this.Controls.Add(this.cboCapacityType);
            this.Controls.Add(this.cboRefrigerant);
            this.Controls.Add(this.lblRefrigerant);
            this.Controls.Add(this.numCondenserTemperature);
            this.Controls.Add(this.lblCondenserTemperature);
            this.Controls.Add(this.lblReclaimCapacity);
            this.Controls.Add(this.lblTotalHeatRejection);
            this.Controls.Add(this.numTotalHeatRejection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCircuitEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "sAdd/Edit Circuit";
            this.Load += new System.EventHandler(this.frmCircuitEdit_Load);
            this.pnlNRE.ResumeLayout(false);
            this.pnlNRE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalHeatRejection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCondenserTemperature)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNRE;
        private System.Windows.Forms.Panel pnlNRE;
        private System.Windows.Forms.NumericUpDown numSST;
        private System.Windows.Forms.Label lblSST;
        private System.Windows.Forms.Label lblCompressorType;
        private System.Windows.Forms.ComboBox cboCompressorType;
        private System.Windows.Forms.Label lblCapacityType;
        private System.Windows.Forms.ComboBox cboCapacityType;
        private System.Windows.Forms.ComboBox cboRefrigerant;
        private System.Windows.Forms.Label lblRefrigerant;
        private System.Windows.Forms.NumericUpDown numTotalHeatRejection;
        private System.Windows.Forms.NumericUpDown numCondenserTemperature;
        private System.Windows.Forms.Label lblCondenserTemperature;
        private System.Windows.Forms.Label lblReclaimCapacity;
        private System.Windows.Forms.Label lblTotalHeatRejection;
        private System.Windows.Forms.Button cmdSaveCircuit;
    }
}