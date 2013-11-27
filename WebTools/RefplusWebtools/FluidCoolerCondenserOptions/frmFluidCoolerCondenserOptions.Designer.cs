namespace RefplusWebtools.FluidCoolerCondenserOptions
{
    partial class FrmFluidCoolerCondenserOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFluidCoolerCondenserOptions));
            this.cboCoilCoating = new System.Windows.Forms.ComboBox();
            this.lblTubeMaterial = new System.Windows.Forms.Label();
            this.cboTubeMaterial = new System.Windows.Forms.ComboBox();
            this.lblLegs = new System.Windows.Forms.Label();
            this.cboLegs = new System.Windows.Forms.ComboBox();
            this.lblFinMaterial = new System.Windows.Forms.Label();
            this.cboFinMaterial = new System.Windows.Forms.ComboBox();
            this.lblCoilCoating = new System.Windows.Forms.Label();
            this.cboCasingFinish = new System.Windows.Forms.ComboBox();
            this.lblCasingFinish = new System.Windows.Forms.Label();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.lblLegPrice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboCoilCoating
            // 
            this.cboCoilCoating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCoilCoating.FormattingEnabled = true;
            this.cboCoilCoating.Location = new System.Drawing.Point(165, 62);
            this.cboCoilCoating.Name = "cboCoilCoating";
            this.cboCoilCoating.Size = new System.Drawing.Size(213, 21);
            this.cboCoilCoating.TabIndex = 2;
            // 
            // lblTubeMaterial
            // 
            this.lblTubeMaterial.AutoSize = true;
            this.lblTubeMaterial.Location = new System.Drawing.Point(7, 42);
            this.lblTubeMaterial.Name = "lblTubeMaterial";
            this.lblTubeMaterial.Size = new System.Drawing.Size(77, 13);
            this.lblTubeMaterial.TabIndex = 104;
            this.lblTubeMaterial.Text = "sTube Material";
            // 
            // cboTubeMaterial
            // 
            this.cboTubeMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTubeMaterial.FormattingEnabled = true;
            this.cboTubeMaterial.Location = new System.Drawing.Point(165, 35);
            this.cboTubeMaterial.Name = "cboTubeMaterial";
            this.cboTubeMaterial.Size = new System.Drawing.Size(213, 21);
            this.cboTubeMaterial.TabIndex = 1;
            // 
            // lblLegs
            // 
            this.lblLegs.AutoSize = true;
            this.lblLegs.Location = new System.Drawing.Point(7, 123);
            this.lblLegs.Name = "lblLegs";
            this.lblLegs.Size = new System.Drawing.Size(35, 13);
            this.lblLegs.TabIndex = 103;
            this.lblLegs.Text = "sLegs";
            // 
            // cboLegs
            // 
            this.cboLegs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLegs.FormattingEnabled = true;
            this.cboLegs.Location = new System.Drawing.Point(165, 116);
            this.cboLegs.Name = "cboLegs";
            this.cboLegs.Size = new System.Drawing.Size(130, 21);
            this.cboLegs.TabIndex = 4;
            this.cboLegs.SelectedIndexChanged += new System.EventHandler(this.cboLegs_SelectedIndexChanged);
            // 
            // lblFinMaterial
            // 
            this.lblFinMaterial.AutoSize = true;
            this.lblFinMaterial.Location = new System.Drawing.Point(7, 15);
            this.lblFinMaterial.Name = "lblFinMaterial";
            this.lblFinMaterial.Size = new System.Drawing.Size(66, 13);
            this.lblFinMaterial.TabIndex = 102;
            this.lblFinMaterial.Text = "sFin Material";
            // 
            // cboFinMaterial
            // 
            this.cboFinMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFinMaterial.FormattingEnabled = true;
            this.cboFinMaterial.Location = new System.Drawing.Point(165, 8);
            this.cboFinMaterial.Name = "cboFinMaterial";
            this.cboFinMaterial.Size = new System.Drawing.Size(213, 21);
            this.cboFinMaterial.TabIndex = 0;
            // 
            // lblCoilCoating
            // 
            this.lblCoilCoating.AutoSize = true;
            this.lblCoilCoating.Location = new System.Drawing.Point(7, 69);
            this.lblCoilCoating.Name = "lblCoilCoating";
            this.lblCoilCoating.Size = new System.Drawing.Size(68, 13);
            this.lblCoilCoating.TabIndex = 101;
            this.lblCoilCoating.Text = "sCoil Coating";
            // 
            // cboCasingFinish
            // 
            this.cboCasingFinish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCasingFinish.Enabled = false;
            this.cboCasingFinish.FormattingEnabled = true;
            this.cboCasingFinish.Location = new System.Drawing.Point(165, 89);
            this.cboCasingFinish.Name = "cboCasingFinish";
            this.cboCasingFinish.Size = new System.Drawing.Size(213, 21);
            this.cboCasingFinish.TabIndex = 3;
            // 
            // lblCasingFinish
            // 
            this.lblCasingFinish.AutoSize = true;
            this.lblCasingFinish.Location = new System.Drawing.Point(7, 96);
            this.lblCasingFinish.Name = "lblCasingFinish";
            this.lblCasingFinish.Size = new System.Drawing.Size(74, 13);
            this.lblCasingFinish.TabIndex = 106;
            this.lblCasingFinish.Text = "sCasing Finish";
            // 
            // cmdAccept
            // 
            this.cmdAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdAccept.Image = ((System.Drawing.Image)(resources.GetObject("cmdAccept.Image")));
            this.cmdAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAccept.Location = new System.Drawing.Point(10, 177);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(370, 25);
            this.cmdAccept.TabIndex = 6;
            this.cmdAccept.Text = "sAccept";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(221, 147);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 5;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // lblLegPrice
            // 
            this.lblLegPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblLegPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLegPrice.Location = new System.Drawing.Point(301, 116);
            this.lblLegPrice.Name = "lblLegPrice";
            this.lblLegPrice.Size = new System.Drawing.Size(77, 21);
            this.lblLegPrice.TabIndex = 107;
            this.lblLegPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmFluidCoolerCondenserOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(388, 214);
            this.Controls.Add(this.lblLegPrice);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.cboCasingFinish);
            this.Controls.Add(this.lblCasingFinish);
            this.Controls.Add(this.cboCoilCoating);
            this.Controls.Add(this.lblTubeMaterial);
            this.Controls.Add(this.cboTubeMaterial);
            this.Controls.Add(this.lblLegs);
            this.Controls.Add(this.cboLegs);
            this.Controls.Add(this.lblFinMaterial);
            this.Controls.Add(this.cboFinMaterial);
            this.Controls.Add(this.lblCoilCoating);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFluidCoolerCondenserOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "sOptions";
            this.Load += new System.EventHandler(this.frmFluidCoolerCondenserOptions_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmFluidCoolerCondenserOptions_HelpRequested);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCoilCoating;
        private System.Windows.Forms.Label lblTubeMaterial;
        private System.Windows.Forms.ComboBox cboTubeMaterial;
        private System.Windows.Forms.Label lblLegs;
        private System.Windows.Forms.ComboBox cboLegs;
        private System.Windows.Forms.Label lblFinMaterial;
        private System.Windows.Forms.ComboBox cboFinMaterial;
        private System.Windows.Forms.Label lblCoilCoating;
        private System.Windows.Forms.ComboBox cboCasingFinish;
        private System.Windows.Forms.Label lblCasingFinish;
        private System.Windows.Forms.Button cmdAccept;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label lblLegPrice;
    }
}