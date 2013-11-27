namespace RefplusWebtools.QuickCoil
{
    partial class FrmOtherFluid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOtherFluid));
            this.txtFluidTypeName = new System.Windows.Forms.TextBox();
            this.lblFluidTypeName = new System.Windows.Forms.Label();
            this.lblThermalConductivity = new System.Windows.Forms.Label();
            this.numThermalConductivity = new System.Windows.Forms.NumericUpDown();
            this.lblViscosity = new System.Windows.Forms.Label();
            this.numViscosity = new System.Windows.Forms.NumericUpDown();
            this.lblDensity = new System.Windows.Forms.Label();
            this.numDensity = new System.Windows.Forms.NumericUpDown();
            this.lblSpecificHeat = new System.Windows.Forms.Label();
            this.numSpecificHeat = new System.Windows.Forms.NumericUpDown();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.lblFreezing = new System.Windows.Forms.Label();
            this.numFreezing = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numThermalConductivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numViscosity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecificHeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFreezing)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFluidTypeName
            // 
            this.txtFluidTypeName.Location = new System.Drawing.Point(198, 6);
            this.txtFluidTypeName.MaxLength = 15;
            this.txtFluidTypeName.Name = "txtFluidTypeName";
            this.txtFluidTypeName.Size = new System.Drawing.Size(102, 20);
            this.txtFluidTypeName.TabIndex = 0;
            this.txtFluidTypeName.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblFluidTypeName
            // 
            this.lblFluidTypeName.AutoSize = true;
            this.lblFluidTypeName.Location = new System.Drawing.Point(12, 9);
            this.lblFluidTypeName.Name = "lblFluidTypeName";
            this.lblFluidTypeName.Size = new System.Drawing.Size(92, 13);
            this.lblFluidTypeName.TabIndex = 101;
            this.lblFluidTypeName.Text = "sFluid Type Name";
            // 
            // lblThermalConductivity
            // 
            this.lblThermalConductivity.AutoSize = true;
            this.lblThermalConductivity.Location = new System.Drawing.Point(12, 102);
            this.lblThermalConductivity.Name = "lblThermalConductivity";
            this.lblThermalConductivity.Size = new System.Drawing.Size(180, 13);
            this.lblThermalConductivity.TabIndex = 100;
            this.lblThermalConductivity.Text = "sThermal Conductivity (BTU/H/sq.ft)";
            // 
            // numThermalConductivity
            // 
            this.numThermalConductivity.DecimalPlaces = 4;
            this.numThermalConductivity.Location = new System.Drawing.Point(198, 100);
            this.numThermalConductivity.Name = "numThermalConductivity";
            this.numThermalConductivity.Size = new System.Drawing.Size(102, 20);
            this.numThermalConductivity.TabIndex = 4;
            this.numThermalConductivity.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblViscosity
            // 
            this.lblViscosity.AutoSize = true;
            this.lblViscosity.Location = new System.Drawing.Point(12, 78);
            this.lblViscosity.Name = "lblViscosity";
            this.lblViscosity.Size = new System.Drawing.Size(111, 13);
            this.lblViscosity.TabIndex = 99;
            this.lblViscosity.Text = "sViscosity (Centipoise)";
            // 
            // numViscosity
            // 
            this.numViscosity.DecimalPlaces = 4;
            this.numViscosity.Location = new System.Drawing.Point(198, 76);
            this.numViscosity.Name = "numViscosity";
            this.numViscosity.Size = new System.Drawing.Size(102, 20);
            this.numViscosity.TabIndex = 3;
            this.numViscosity.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblDensity
            // 
            this.lblDensity.AutoSize = true;
            this.lblDensity.Location = new System.Drawing.Point(12, 55);
            this.lblDensity.Name = "lblDensity";
            this.lblDensity.Size = new System.Drawing.Size(90, 13);
            this.lblDensity.TabIndex = 98;
            this.lblDensity.Text = "sDensity (lb/cu.ft)";
            // 
            // numDensity
            // 
            this.numDensity.DecimalPlaces = 4;
            this.numDensity.Location = new System.Drawing.Point(198, 53);
            this.numDensity.Name = "numDensity";
            this.numDensity.Size = new System.Drawing.Size(102, 20);
            this.numDensity.TabIndex = 2;
            this.numDensity.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblSpecificHeat
            // 
            this.lblSpecificHeat.AutoSize = true;
            this.lblSpecificHeat.Location = new System.Drawing.Point(12, 31);
            this.lblSpecificHeat.Name = "lblSpecificHeat";
            this.lblSpecificHeat.Size = new System.Drawing.Size(135, 13);
            this.lblSpecificHeat.TabIndex = 97;
            this.lblSpecificHeat.Text = "sSpecific Heat (BTU/lb/°F)";
            // 
            // numSpecificHeat
            // 
            this.numSpecificHeat.DecimalPlaces = 4;
            this.numSpecificHeat.Location = new System.Drawing.Point(198, 29);
            this.numSpecificHeat.Name = "numSpecificHeat";
            this.numSpecificHeat.Size = new System.Drawing.Size(102, 20);
            this.numSpecificHeat.TabIndex = 1;
            this.numSpecificHeat.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // btnAccept
            // 
            this.btnAccept.Image = ((System.Drawing.Image)(resources.GetObject("btnAccept.Image")));
            this.btnAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccept.Location = new System.Drawing.Point(15, 163);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(104, 23);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "sSave";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(199, 163);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "sCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(146, 163);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 6;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // lblFreezing
            // 
            this.lblFreezing.AutoSize = true;
            this.lblFreezing.Location = new System.Drawing.Point(12, 128);
            this.lblFreezing.Name = "lblFreezing";
            this.lblFreezing.Size = new System.Drawing.Size(98, 13);
            this.lblFreezing.TabIndex = 103;
            this.lblFreezing.Text = "sFreezing Point (°F)";
            // 
            // numFreezing
            // 
            this.numFreezing.DecimalPlaces = 4;
            this.numFreezing.Location = new System.Drawing.Point(198, 126);
            this.numFreezing.Maximum = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.numFreezing.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numFreezing.Name = "numFreezing";
            this.numFreezing.Size = new System.Drawing.Size(102, 20);
            this.numFreezing.TabIndex = 102;
            // 
            // frmOtherFluid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(324, 212);
            this.Controls.Add(this.lblFreezing);
            this.Controls.Add(this.numFreezing);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtFluidTypeName);
            this.Controls.Add(this.lblFluidTypeName);
            this.Controls.Add(this.lblThermalConductivity);
            this.Controls.Add(this.numThermalConductivity);
            this.Controls.Add(this.lblViscosity);
            this.Controls.Add(this.numViscosity);
            this.Controls.Add(this.lblDensity);
            this.Controls.Add(this.numDensity);
            this.Controls.Add(this.lblSpecificHeat);
            this.Controls.Add(this.numSpecificHeat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOtherFluid";
            this.ShowIcon = false;
            this.Text = "sCustom Fluid";
            this.Load += new System.EventHandler(this.frmOtherFluid_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmOtherFluid_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.numThermalConductivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numViscosity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecificHeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFreezing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFluidTypeName;
        private System.Windows.Forms.Label lblFluidTypeName;
        private System.Windows.Forms.Label lblThermalConductivity;
        private System.Windows.Forms.NumericUpDown numThermalConductivity;
        private System.Windows.Forms.Label lblViscosity;
        private System.Windows.Forms.NumericUpDown numViscosity;
        private System.Windows.Forms.Label lblDensity;
        private System.Windows.Forms.NumericUpDown numDensity;
        private System.Windows.Forms.Label lblSpecificHeat;
        private System.Windows.Forms.NumericUpDown numSpecificHeat;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label lblFreezing;
        private System.Windows.Forms.NumericUpDown numFreezing;
    }
}