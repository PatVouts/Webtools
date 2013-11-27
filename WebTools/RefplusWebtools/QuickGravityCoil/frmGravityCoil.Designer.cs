namespace RefplusWebtools.QuickGravityCoil
{
    partial class FrmGravityCoil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGravityCoil));
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.lblTag = new System.Windows.Forms.Label();
            this.grpInputs = new System.Windows.Forms.GroupBox();
            this.lblSuctionTemp = new System.Windows.Forms.Label();
            this.numSuctionTemp = new System.Windows.Forms.NumericUpDown();
            this.lblTD = new System.Windows.Forms.Label();
            this.numTD = new System.Windows.Forms.NumericUpDown();
            this.lblRefrigerant = new System.Windows.Forms.Label();
            this.cboRefrigerant = new System.Windows.Forms.ComboBox();
            this.lblMinMultiplier = new System.Windows.Forms.Label();
            this.lblMaxMultiplier = new System.Windows.Forms.Label();
            this.cboMinCapacityPercentage = new System.Windows.Forms.ComboBox();
            this.cboMaxCapacityPercentage = new System.Windows.Forms.ComboBox();
            this.lblFaceTubes = new System.Windows.Forms.Label();
            this.cboFaceTubes = new System.Windows.Forms.ComboBox();
            this.numCapacity = new System.Windows.Forms.NumericUpDown();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.lblCoilCoating = new System.Windows.Forms.Label();
            this.cboCoilCoating = new System.Windows.Forms.ComboBox();
            this.cmdRunSelection = new System.Windows.Forms.Button();
            this.lvGravityCoil = new System.Windows.Forms.ListView();
            this.Model = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FaceTubes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Capacity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Height = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Width = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Depth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RefrigerantCharge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ShippingWeight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdAccept = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.lblModel = new System.Windows.Forms.Label();
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.lblSelection = new System.Windows.Forms.Label();
            this.cboSelection = new System.Windows.Forms.ComboBox();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.grpInputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSuctionTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).BeginInit();
            this.SuspendLayout();
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(77, 39);
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(50, 20);
            this.numQuantity.TabIndex = 1;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(9, 41);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(51, 13);
            this.lblQuantity.TabIndex = 16;
            this.lblQuantity.Text = "sQuantity";
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(77, 12);
            this.txtTag.MaxLength = 50;
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(550, 20);
            this.txtTag.TabIndex = 0;
            this.txtTag.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblTag
            // 
            this.lblTag.AutoSize = true;
            this.lblTag.Location = new System.Drawing.Point(9, 15);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(31, 13);
            this.lblTag.TabIndex = 15;
            this.lblTag.Text = "sTag";
            // 
            // grpInputs
            // 
            this.grpInputs.Controls.Add(this.lblSuctionTemp);
            this.grpInputs.Controls.Add(this.numSuctionTemp);
            this.grpInputs.Controls.Add(this.lblTD);
            this.grpInputs.Controls.Add(this.numTD);
            this.grpInputs.Controls.Add(this.lblRefrigerant);
            this.grpInputs.Controls.Add(this.cboRefrigerant);
            this.grpInputs.Controls.Add(this.lblMinMultiplier);
            this.grpInputs.Controls.Add(this.lblMaxMultiplier);
            this.grpInputs.Controls.Add(this.cboMinCapacityPercentage);
            this.grpInputs.Controls.Add(this.cboMaxCapacityPercentage);
            this.grpInputs.Controls.Add(this.lblFaceTubes);
            this.grpInputs.Controls.Add(this.cboFaceTubes);
            this.grpInputs.Controls.Add(this.numCapacity);
            this.grpInputs.Controls.Add(this.lblCapacity);
            this.grpInputs.Location = new System.Drawing.Point(12, 60);
            this.grpInputs.Name = "grpInputs";
            this.grpInputs.Size = new System.Drawing.Size(614, 137);
            this.grpInputs.TabIndex = 4;
            this.grpInputs.TabStop = false;
            this.grpInputs.Text = "sInputs";
            // 
            // lblSuctionTemp
            // 
            this.lblSuctionTemp.AutoSize = true;
            this.lblSuctionTemp.Location = new System.Drawing.Point(357, 21);
            this.lblSuctionTemp.Name = "lblSuctionTemp";
            this.lblSuctionTemp.Size = new System.Drawing.Size(81, 13);
            this.lblSuctionTemp.TabIndex = 15;
            this.lblSuctionTemp.Text = "sSuction Temp.";
            // 
            // numSuctionTemp
            // 
            this.numSuctionTemp.Location = new System.Drawing.Point(479, 19);
            this.numSuctionTemp.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numSuctionTemp.Minimum = new decimal(new int[] {
            35,
            0,
            0,
            0});
            this.numSuctionTemp.Name = "numSuctionTemp";
            this.numSuctionTemp.Size = new System.Drawing.Size(120, 20);
            this.numSuctionTemp.TabIndex = 5;
            this.numSuctionTemp.Value = new decimal(new int[] {
            35,
            0,
            0,
            0});
            this.numSuctionTemp.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblTD
            // 
            this.lblTD.AutoSize = true;
            this.lblTD.Location = new System.Drawing.Point(357, 48);
            this.lblTD.Name = "lblTD";
            this.lblTD.Size = new System.Drawing.Size(27, 13);
            this.lblTD.TabIndex = 13;
            this.lblTD.Text = "sTD";
            // 
            // numTD
            // 
            this.numTD.Location = new System.Drawing.Point(478, 43);
            this.numTD.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numTD.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numTD.Name = "numTD";
            this.numTD.Size = new System.Drawing.Size(120, 20);
            this.numTD.TabIndex = 6;
            this.numTD.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numTD.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblRefrigerant
            // 
            this.lblRefrigerant.AutoSize = true;
            this.lblRefrigerant.Location = new System.Drawing.Point(5, 21);
            this.lblRefrigerant.Name = "lblRefrigerant";
            this.lblRefrigerant.Size = new System.Drawing.Size(64, 13);
            this.lblRefrigerant.TabIndex = 11;
            this.lblRefrigerant.Text = "sRefrigerant";
            // 
            // cboRefrigerant
            // 
            this.cboRefrigerant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRefrigerant.FormattingEnabled = true;
            this.cboRefrigerant.Location = new System.Drawing.Point(103, 18);
            this.cboRefrigerant.Name = "cboRefrigerant";
            this.cboRefrigerant.Size = new System.Drawing.Size(121, 21);
            this.cboRefrigerant.TabIndex = 0;
            // 
            // lblMinMultiplier
            // 
            this.lblMinMultiplier.AutoSize = true;
            this.lblMinMultiplier.Location = new System.Drawing.Point(272, 120);
            this.lblMinMultiplier.Name = "lblMinMultiplier";
            this.lblMinMultiplier.Size = new System.Drawing.Size(10, 13);
            this.lblMinMultiplier.TabIndex = 9;
            this.lblMinMultiplier.Text = "-";
            // 
            // lblMaxMultiplier
            // 
            this.lblMaxMultiplier.AutoSize = true;
            this.lblMaxMultiplier.Location = new System.Drawing.Point(272, 53);
            this.lblMaxMultiplier.Name = "lblMaxMultiplier";
            this.lblMaxMultiplier.Size = new System.Drawing.Size(13, 13);
            this.lblMaxMultiplier.TabIndex = 8;
            this.lblMaxMultiplier.Text = "+";
            // 
            // cboMinCapacityPercentage
            // 
            this.cboMinCapacityPercentage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMinCapacityPercentage.FormattingEnabled = true;
            this.cboMinCapacityPercentage.Location = new System.Drawing.Point(246, 96);
            this.cboMinCapacityPercentage.Name = "cboMinCapacityPercentage";
            this.cboMinCapacityPercentage.Size = new System.Drawing.Size(61, 21);
            this.cboMinCapacityPercentage.TabIndex = 4;
            // 
            // cboMaxCapacityPercentage
            // 
            this.cboMaxCapacityPercentage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaxCapacityPercentage.FormattingEnabled = true;
            this.cboMaxCapacityPercentage.Location = new System.Drawing.Point(246, 69);
            this.cboMaxCapacityPercentage.Name = "cboMaxCapacityPercentage";
            this.cboMaxCapacityPercentage.Size = new System.Drawing.Size(61, 21);
            this.cboMaxCapacityPercentage.TabIndex = 3;
            // 
            // lblFaceTubes
            // 
            this.lblFaceTubes.AutoSize = true;
            this.lblFaceTubes.Location = new System.Drawing.Point(5, 48);
            this.lblFaceTubes.Name = "lblFaceTubes";
            this.lblFaceTubes.Size = new System.Drawing.Size(69, 13);
            this.lblFaceTubes.TabIndex = 5;
            this.lblFaceTubes.Text = "sFace Tubes";
            // 
            // cboFaceTubes
            // 
            this.cboFaceTubes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFaceTubes.FormattingEnabled = true;
            this.cboFaceTubes.Location = new System.Drawing.Point(103, 45);
            this.cboFaceTubes.Name = "cboFaceTubes";
            this.cboFaceTubes.Size = new System.Drawing.Size(121, 21);
            this.cboFaceTubes.TabIndex = 1;
            // 
            // numCapacity
            // 
            this.numCapacity.Location = new System.Drawing.Point(103, 82);
            this.numCapacity.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.numCapacity.Name = "numCapacity";
            this.numCapacity.Size = new System.Drawing.Size(120, 20);
            this.numCapacity.TabIndex = 2;
            this.numCapacity.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Location = new System.Drawing.Point(5, 84);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(53, 13);
            this.lblCapacity.TabIndex = 0;
            this.lblCapacity.Text = "sCapacity";
            // 
            // lblCoilCoating
            // 
            this.lblCoilCoating.AutoSize = true;
            this.lblCoilCoating.Location = new System.Drawing.Point(168, 441);
            this.lblCoilCoating.Name = "lblCoilCoating";
            this.lblCoilCoating.Size = new System.Drawing.Size(68, 13);
            this.lblCoilCoating.TabIndex = 3;
            this.lblCoilCoating.Text = "sCoil Coating";
            // 
            // cboCoilCoating
            // 
            this.cboCoilCoating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCoilCoating.FormattingEnabled = true;
            this.cboCoilCoating.Location = new System.Drawing.Point(311, 438);
            this.cboCoilCoating.Name = "cboCoilCoating";
            this.cboCoilCoating.Size = new System.Drawing.Size(121, 21);
            this.cboCoilCoating.TabIndex = 7;
            // 
            // cmdRunSelection
            // 
            this.cmdRunSelection.Image = ((System.Drawing.Image)(resources.GetObject("cmdRunSelection.Image")));
            this.cmdRunSelection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRunSelection.Location = new System.Drawing.Point(12, 203);
            this.cmdRunSelection.Name = "cmdRunSelection";
            this.cmdRunSelection.Size = new System.Drawing.Size(615, 25);
            this.cmdRunSelection.TabIndex = 5;
            this.cmdRunSelection.Text = "sRun Selection";
            this.cmdRunSelection.UseVisualStyleBackColor = true;
            this.cmdRunSelection.Click += new System.EventHandler(this.cmdRunSelection_Click);
            // 
            // lvGravityCoil
            // 
            this.lvGravityCoil.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Model,
            this.FaceTubes,
            this.Capacity,
            this.Height,
            this.Width,
            this.Depth,
            this.RefrigerantCharge,
            this.ShippingWeight});
            this.lvGravityCoil.FullRowSelect = true;
            this.lvGravityCoil.GridLines = true;
            this.lvGravityCoil.Location = new System.Drawing.Point(20, 245);
            this.lvGravityCoil.MultiSelect = false;
            this.lvGravityCoil.Name = "lvGravityCoil";
            this.lvGravityCoil.Size = new System.Drawing.Size(603, 187);
            this.lvGravityCoil.TabIndex = 6;
            this.lvGravityCoil.UseCompatibleStateImageBehavior = false;
            this.lvGravityCoil.View = System.Windows.Forms.View.Details;
            // 
            // Model
            // 
            this.Model.Text = "sModel";
            this.Model.Width = 120;
            // 
            // FaceTubes
            // 
            this.FaceTubes.Text = "sFace Tubes";
            this.FaceTubes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FaceTubes.Width = 82;
            // 
            // Capacity
            // 
            this.Capacity.Text = "Capacity";
            this.Capacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Capacity.Width = 120;
            // 
            // Height
            // 
            this.Height.Text = "sHeight";
            this.Height.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Width
            // 
            this.Width.Text = "sWidth";
            this.Width.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Width.Width = 63;
            // 
            // Depth
            // 
            this.Depth.Text = "sDepth";
            this.Depth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RefrigerantCharge
            // 
            this.RefrigerantCharge.Text = "Refrigerant Charge";
            this.RefrigerantCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RefrigerantCharge.Width = 120;
            // 
            // ShippingWeight
            // 
            this.ShippingWeight.Text = "Shipping Weight";
            this.ShippingWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ShippingWeight.Width = 120;
            // 
            // cmdAccept
            // 
            this.cmdAccept.Image = ((System.Drawing.Image)(resources.GetObject("cmdAccept.Image")));
            this.cmdAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAccept.Location = new System.Drawing.Point(10, 463);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(139, 25);
            this.cmdAccept.TabIndex = 8;
            this.cmdAccept.Text = "sAccept";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(485, 463);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(139, 25);
            this.cmdCancel.TabIndex = 10;
            this.cmdCancel.Text = "sCancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(404, 41);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(41, 13);
            this.lblModel.TabIndex = 23;
            this.lblModel.Text = "sModel";
            // 
            // cboModel
            // 
            this.cboModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModel.FormattingEnabled = true;
            this.cboModel.Location = new System.Drawing.Point(502, 38);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(121, 21);
            this.cboModel.TabIndex = 3;
            // 
            // lblSelection
            // 
            this.lblSelection.AutoSize = true;
            this.lblSelection.Location = new System.Drawing.Point(151, 41);
            this.lblSelection.Name = "lblSelection";
            this.lblSelection.Size = new System.Drawing.Size(56, 13);
            this.lblSelection.TabIndex = 25;
            this.lblSelection.Text = "sSelection";
            // 
            // cboSelection
            // 
            this.cboSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelection.FormattingEnabled = true;
            this.cboSelection.Items.AddRange(new object[] {
            "SELECTION",
            "RATING"});
            this.cboSelection.Location = new System.Drawing.Point(249, 38);
            this.cboSelection.Name = "cboSelection";
            this.cboSelection.Size = new System.Drawing.Size(121, 21);
            this.cboSelection.TabIndex = 2;
            this.cboSelection.SelectedIndexChanged += new System.EventHandler(this.cboSelection_SelectedIndexChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(301, 465);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 9;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmGravityCoil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(638, 498);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblSelection);
            this.Controls.Add(this.cboSelection);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.cboModel);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.lvGravityCoil);
            this.Controls.Add(this.cmdRunSelection);
            this.Controls.Add(this.grpInputs);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtTag);
            this.Controls.Add(this.lblCoilCoating);
            this.Controls.Add(this.lblTag);
            this.Controls.Add(this.cboCoilCoating);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGravityCoil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "sGravity Coil";
            this.Load += new System.EventHandler(this.frmGravityCoil_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmGravityCoil_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.grpInputs.ResumeLayout(false);
            this.grpInputs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSuctionTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.Label lblTag;
        private System.Windows.Forms.GroupBox grpInputs;
        private System.Windows.Forms.Button cmdRunSelection;
        private System.Windows.Forms.ListView lvGravityCoil;
        private System.Windows.Forms.Button cmdAccept;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.NumericUpDown numCapacity;
        private System.Windows.Forms.Label lblCoilCoating;
        private System.Windows.Forms.ComboBox cboCoilCoating;
        private System.Windows.Forms.Label lblFaceTubes;
        private System.Windows.Forms.ComboBox cboFaceTubes;
        private System.Windows.Forms.ComboBox cboMinCapacityPercentage;
        private System.Windows.Forms.ComboBox cboMaxCapacityPercentage;
        private System.Windows.Forms.Label lblMinMultiplier;
        private System.Windows.Forms.Label lblMaxMultiplier;
        private System.Windows.Forms.ColumnHeader Model;
        private System.Windows.Forms.Label lblRefrigerant;
        private System.Windows.Forms.ComboBox cboRefrigerant;
        private System.Windows.Forms.ColumnHeader Capacity;
        private System.Windows.Forms.ColumnHeader Depth;
        new private System.Windows.Forms.ColumnHeader Height;
        new private System.Windows.Forms.ColumnHeader Width;
        private System.Windows.Forms.ColumnHeader FaceTubes;
        private System.Windows.Forms.NumericUpDown numTD;
        private System.Windows.Forms.Label lblSuctionTemp;
        private System.Windows.Forms.NumericUpDown numSuctionTemp;
        private System.Windows.Forms.Label lblTD;
        private System.Windows.Forms.ColumnHeader RefrigerantCharge;
        private System.Windows.Forms.ColumnHeader ShippingWeight;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.ComboBox cboModel;
        private System.Windows.Forms.Label lblSelection;
        private System.Windows.Forms.ComboBox cboSelection;
        private System.Windows.Forms.Button btnHelp;
    }
}