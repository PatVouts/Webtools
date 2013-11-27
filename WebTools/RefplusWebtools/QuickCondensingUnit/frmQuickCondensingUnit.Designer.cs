namespace RefplusWebtools.QuickCondensingUnit
{
    partial class FrmQuickCondensingUnit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQuickCondensingUnit));
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn4 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn5 = new GlacialComponents.Controls.GLColumn();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.lblTag = new System.Windows.Forms.Label();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.txtSaturatedSuctionTemp = new System.Windows.Forms.TextBox();
            this.txtBalancingTemperature = new System.Windows.Forms.TextBox();
            this.cboCapacityRange = new System.Windows.Forms.ComboBox();
            this.cboNumberOfCompressors = new System.Windows.Forms.ComboBox();
            this.lblNumberOfCompressors = new System.Windows.Forms.Label();
            this.lblCondensingTemperature = new System.Windows.Forms.Label();
            this.cboVoltage = new System.Windows.Forms.ComboBox();
            this.lblVoltage = new System.Windows.Forms.Label();
            this.cboRefrigerant = new System.Windows.Forms.ComboBox();
            this.lblRefrigerant = new System.Windows.Forms.Label();
            this.cboCompressorManufacturer = new System.Windows.Forms.ComboBox();
            this.lblCompressorManufacturer = new System.Windows.Forms.Label();
            this.numCapacity = new System.Windows.Forms.NumericUpDown();
            this.numSaturatedSuctionTemp = new System.Windows.Forms.NumericUpDown();
            this.lblSaturatedSuctionTemperature = new System.Windows.Forms.Label();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.cboCompressorType = new System.Windows.Forms.ComboBox();
            this.lblCompressorType = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.lblAmbientTemperature = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.numBalancingTemperature = new System.Windows.Forms.NumericUpDown();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.cboFinMaterial = new System.Windows.Forms.ComboBox();
            this.lblFinMaterial = new System.Windows.Forms.Label();
            this.cboCoilCoating = new System.Windows.Forms.ComboBox();
            this.lblCoilCoating = new System.Windows.Forms.Label();
            this.cmdRunSelection = new System.Windows.Forms.Button();
            this.lvCondensingUnit = new GlacialComponents.Controls.GlacialList();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSaturatedSuctionTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBalancingTemperature)).BeginInit();
            this.SuspendLayout();
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(177, 29);
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(44, 20);
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
            this.lblQuantity.Location = new System.Drawing.Point(12, 31);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(51, 13);
            this.lblQuantity.TabIndex = 8;
            this.lblQuantity.Text = "sQuantity";
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(177, 6);
            this.txtTag.MaxLength = 50;
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(453, 20);
            this.txtTag.TabIndex = 0;
            this.txtTag.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblTag
            // 
            this.lblTag.AutoSize = true;
            this.lblTag.Location = new System.Drawing.Point(12, 9);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(31, 13);
            this.lblTag.TabIndex = 6;
            this.lblTag.Text = "sTag";
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.txtSaturatedSuctionTemp);
            this.grpInput.Controls.Add(this.txtBalancingTemperature);
            this.grpInput.Controls.Add(this.cboCapacityRange);
            this.grpInput.Controls.Add(this.cboNumberOfCompressors);
            this.grpInput.Controls.Add(this.lblNumberOfCompressors);
            this.grpInput.Controls.Add(this.lblCondensingTemperature);
            this.grpInput.Controls.Add(this.cboVoltage);
            this.grpInput.Controls.Add(this.lblVoltage);
            this.grpInput.Controls.Add(this.cboRefrigerant);
            this.grpInput.Controls.Add(this.lblRefrigerant);
            this.grpInput.Controls.Add(this.cboCompressorManufacturer);
            this.grpInput.Controls.Add(this.lblCompressorManufacturer);
            this.grpInput.Controls.Add(this.numCapacity);
            this.grpInput.Controls.Add(this.numSaturatedSuctionTemp);
            this.grpInput.Controls.Add(this.lblSaturatedSuctionTemperature);
            this.grpInput.Controls.Add(this.lblCapacity);
            this.grpInput.Controls.Add(this.cboCompressorType);
            this.grpInput.Controls.Add(this.lblCompressorType);
            this.grpInput.Controls.Add(this.cboType);
            this.grpInput.Controls.Add(this.lblAmbientTemperature);
            this.grpInput.Controls.Add(this.lblType);
            this.grpInput.Controls.Add(this.numBalancingTemperature);
            this.grpInput.Location = new System.Drawing.Point(15, 75);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(615, 127);
            this.grpInput.TabIndex = 4;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "sInputs";
            // 
            // txtSaturatedSuctionTemp
            // 
            this.txtSaturatedSuctionTemp.Location = new System.Drawing.Point(479, 57);
            this.txtSaturatedSuctionTemp.MaxLength = 10;
            this.txtSaturatedSuctionTemp.Name = "txtSaturatedSuctionTemp";
            this.txtSaturatedSuctionTemp.Size = new System.Drawing.Size(130, 20);
            this.txtSaturatedSuctionTemp.TabIndex = 87;
            this.txtSaturatedSuctionTemp.Text = "45";
            this.txtSaturatedSuctionTemp.TextChanged += new System.EventHandler(this.txtSaturatedSuctionTemp_TextChanged);
            this.txtSaturatedSuctionTemp.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            this.txtSaturatedSuctionTemp.Validated += new System.EventHandler(this.txtSaturatedSuctionTemp_Validated);
            // 
            // txtBalancingTemperature
            // 
            this.txtBalancingTemperature.Location = new System.Drawing.Point(479, 34);
            this.txtBalancingTemperature.MaxLength = 10;
            this.txtBalancingTemperature.Name = "txtBalancingTemperature";
            this.txtBalancingTemperature.Size = new System.Drawing.Size(130, 20);
            this.txtBalancingTemperature.TabIndex = 86;
            this.txtBalancingTemperature.Text = "95";
            this.txtBalancingTemperature.TextChanged += new System.EventHandler(this.txtBalancingTemperature_TextChanged);
            this.txtBalancingTemperature.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            this.txtBalancingTemperature.Validated += new System.EventHandler(this.txtBalancingTemperature_Validated);
            // 
            // cboCapacityRange
            // 
            this.cboCapacityRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCapacityRange.FormattingEnabled = true;
            this.cboCapacityRange.Location = new System.Drawing.Point(549, 12);
            this.cboCapacityRange.Name = "cboCapacityRange";
            this.cboCapacityRange.Size = new System.Drawing.Size(60, 21);
            this.cboCapacityRange.TabIndex = 6;
            this.cboCapacityRange.SelectedIndexChanged += new System.EventHandler(this.cboCapacityRange_SelectedIndexChanged);
            // 
            // cboNumberOfCompressors
            // 
            this.cboNumberOfCompressors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNumberOfCompressors.FormattingEnabled = true;
            this.cboNumberOfCompressors.Location = new System.Drawing.Point(162, 101);
            this.cboNumberOfCompressors.Name = "cboNumberOfCompressors";
            this.cboNumberOfCompressors.Size = new System.Drawing.Size(130, 21);
            this.cboNumberOfCompressors.TabIndex = 4;
            this.cboNumberOfCompressors.SelectedIndexChanged += new System.EventHandler(this.cboNumberOfCompressors_SelectedIndexChanged);
            // 
            // lblNumberOfCompressors
            // 
            this.lblNumberOfCompressors.AutoSize = true;
            this.lblNumberOfCompressors.Location = new System.Drawing.Point(6, 104);
            this.lblNumberOfCompressors.Name = "lblNumberOfCompressors";
            this.lblNumberOfCompressors.Size = new System.Drawing.Size(94, 13);
            this.lblNumberOfCompressors.TabIndex = 85;
            this.lblNumberOfCompressors.Text = "s# of Compressors";
            // 
            // lblCondensingTemperature
            // 
            this.lblCondensingTemperature.AutoSize = true;
            this.lblCondensingTemperature.Location = new System.Drawing.Point(323, 36);
            this.lblCondensingTemperature.Name = "lblCondensingTemperature";
            this.lblCondensingTemperature.Size = new System.Drawing.Size(131, 13);
            this.lblCondensingTemperature.TabIndex = 83;
            this.lblCondensingTemperature.Text = "sCondensing Temperature";
            // 
            // cboVoltage
            // 
            this.cboVoltage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVoltage.FormattingEnabled = true;
            this.cboVoltage.Location = new System.Drawing.Point(479, 79);
            this.cboVoltage.Name = "cboVoltage";
            this.cboVoltage.Size = new System.Drawing.Size(130, 21);
            this.cboVoltage.TabIndex = 9;
            this.cboVoltage.SelectedIndexChanged += new System.EventHandler(this.cboVoltage_SelectedIndexChanged);
            // 
            // lblVoltage
            // 
            this.lblVoltage.AutoSize = true;
            this.lblVoltage.Location = new System.Drawing.Point(323, 82);
            this.lblVoltage.Name = "lblVoltage";
            this.lblVoltage.Size = new System.Drawing.Size(48, 13);
            this.lblVoltage.TabIndex = 81;
            this.lblVoltage.Text = "sVoltage";
            // 
            // cboRefrigerant
            // 
            this.cboRefrigerant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRefrigerant.FormattingEnabled = true;
            this.cboRefrigerant.Location = new System.Drawing.Point(162, 79);
            this.cboRefrigerant.Name = "cboRefrigerant";
            this.cboRefrigerant.Size = new System.Drawing.Size(130, 21);
            this.cboRefrigerant.TabIndex = 3;
            this.cboRefrigerant.SelectedIndexChanged += new System.EventHandler(this.cboRefrigerant_SelectedIndexChanged);
            // 
            // lblRefrigerant
            // 
            this.lblRefrigerant.AutoSize = true;
            this.lblRefrigerant.Location = new System.Drawing.Point(6, 82);
            this.lblRefrigerant.Name = "lblRefrigerant";
            this.lblRefrigerant.Size = new System.Drawing.Size(64, 13);
            this.lblRefrigerant.TabIndex = 79;
            this.lblRefrigerant.Text = "sRefrigerant";
            // 
            // cboCompressorManufacturer
            // 
            this.cboCompressorManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompressorManufacturer.FormattingEnabled = true;
            this.cboCompressorManufacturer.Location = new System.Drawing.Point(162, 57);
            this.cboCompressorManufacturer.Name = "cboCompressorManufacturer";
            this.cboCompressorManufacturer.Size = new System.Drawing.Size(130, 21);
            this.cboCompressorManufacturer.TabIndex = 2;
            this.cboCompressorManufacturer.SelectedIndexChanged += new System.EventHandler(this.cboCompressorManufacturer_SelectedIndexChanged);
            // 
            // lblCompressorManufacturer
            // 
            this.lblCompressorManufacturer.AutoSize = true;
            this.lblCompressorManufacturer.Location = new System.Drawing.Point(6, 60);
            this.lblCompressorManufacturer.Name = "lblCompressorManufacturer";
            this.lblCompressorManufacturer.Size = new System.Drawing.Size(133, 13);
            this.lblCompressorManufacturer.TabIndex = 77;
            this.lblCompressorManufacturer.Text = "sCompressor Manufacturer";
            // 
            // numCapacity
            // 
            this.numCapacity.DecimalPlaces = 2;
            this.numCapacity.Location = new System.Drawing.Point(479, 13);
            this.numCapacity.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numCapacity.Name = "numCapacity";
            this.numCapacity.Size = new System.Drawing.Size(60, 20);
            this.numCapacity.TabIndex = 5;
            this.numCapacity.ValueChanged += new System.EventHandler(this.numCapacity_ValueChanged);
            this.numCapacity.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // numSaturatedSuctionTemp
            // 
            this.numSaturatedSuctionTemp.Location = new System.Drawing.Point(549, 102);
            this.numSaturatedSuctionTemp.Maximum = new decimal(new int[] {
            55,
            0,
            0,
            0});
            this.numSaturatedSuctionTemp.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numSaturatedSuctionTemp.Name = "numSaturatedSuctionTemp";
            this.numSaturatedSuctionTemp.Size = new System.Drawing.Size(60, 20);
            this.numSaturatedSuctionTemp.TabIndex = 8;
            this.numSaturatedSuctionTemp.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.numSaturatedSuctionTemp.Visible = false;
            this.numSaturatedSuctionTemp.ValueChanged += new System.EventHandler(this.numSaturatedSuctionTemp_ValueChanged);
            this.numSaturatedSuctionTemp.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblSaturatedSuctionTemperature
            // 
            this.lblSaturatedSuctionTemperature.AutoSize = true;
            this.lblSaturatedSuctionTemperature.Location = new System.Drawing.Point(323, 59);
            this.lblSaturatedSuctionTemperature.Name = "lblSaturatedSuctionTemperature";
            this.lblSaturatedSuctionTemperature.Size = new System.Drawing.Size(127, 13);
            this.lblSaturatedSuctionTemperature.TabIndex = 65;
            this.lblSaturatedSuctionTemperature.Text = "sSaturated Suction Temp";
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Location = new System.Drawing.Point(323, 16);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(86, 13);
            this.lblCapacity.TabIndex = 63;
            this.lblCapacity.Text = "sCapacity (MBH)";
            // 
            // cboCompressorType
            // 
            this.cboCompressorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompressorType.FormattingEnabled = true;
            this.cboCompressorType.Location = new System.Drawing.Point(162, 35);
            this.cboCompressorType.Name = "cboCompressorType";
            this.cboCompressorType.Size = new System.Drawing.Size(130, 21);
            this.cboCompressorType.TabIndex = 1;
            this.cboCompressorType.SelectedIndexChanged += new System.EventHandler(this.cboCompressorType_SelectedIndexChanged);
            // 
            // lblCompressorType
            // 
            this.lblCompressorType.AutoSize = true;
            this.lblCompressorType.Location = new System.Drawing.Point(6, 38);
            this.lblCompressorType.Name = "lblCompressorType";
            this.lblCompressorType.Size = new System.Drawing.Size(94, 13);
            this.lblCompressorType.TabIndex = 61;
            this.lblCompressorType.Text = "sCompressor Type";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.DropDownWidth = 250;
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(162, 13);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(130, 21);
            this.cboType.TabIndex = 0;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // lblAmbientTemperature
            // 
            this.lblAmbientTemperature.AutoSize = true;
            this.lblAmbientTemperature.Location = new System.Drawing.Point(323, 36);
            this.lblAmbientTemperature.Name = "lblAmbientTemperature";
            this.lblAmbientTemperature.Size = new System.Drawing.Size(113, 13);
            this.lblAmbientTemperature.TabIndex = 2;
            this.lblAmbientTemperature.Text = "sAmbient Temperature";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(6, 16);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(36, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "sType";
            // 
            // numBalancingTemperature
            // 
            this.numBalancingTemperature.Location = new System.Drawing.Point(481, 102);
            this.numBalancingTemperature.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numBalancingTemperature.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numBalancingTemperature.Name = "numBalancingTemperature";
            this.numBalancingTemperature.Size = new System.Drawing.Size(60, 20);
            this.numBalancingTemperature.TabIndex = 7;
            this.numBalancingTemperature.Value = new decimal(new int[] {
            95,
            0,
            0,
            0});
            this.numBalancingTemperature.Visible = false;
            this.numBalancingTemperature.ValueChanged += new System.EventHandler(this.numBalancingTemperature_ValueChanged);
            this.numBalancingTemperature.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(483, 544);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(150, 25);
            this.cmdCancel.TabIndex = 11;
            this.cmdCancel.Text = "sCancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cboModel
            // 
            this.cboModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModel.FormattingEnabled = true;
            this.cboModel.Location = new System.Drawing.Point(494, 52);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(130, 21);
            this.cboModel.TabIndex = 3;
            this.cboModel.SelectedIndexChanged += new System.EventHandler(this.cboModel_SelectedIndexChanged);
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(338, 55);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(41, 13);
            this.lblModel.TabIndex = 71;
            this.lblModel.Text = "sModel";
            // 
            // cboFilter
            // 
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.FormattingEnabled = true;
            this.cboFilter.Items.AddRange(new object[] {
            "Selection",
            "Rating"});
            this.cboFilter.Location = new System.Drawing.Point(177, 52);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(130, 21);
            this.cboFilter.TabIndex = 2;
            this.cboFilter.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(12, 55);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(34, 13);
            this.lblFilter.TabIndex = 69;
            this.lblFilter.Text = "sFilter";
            // 
            // cmdAccept
            // 
            this.cmdAccept.Image = ((System.Drawing.Image)(resources.GetObject("cmdAccept.Image")));
            this.cmdAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAccept.Location = new System.Drawing.Point(15, 544);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(150, 25);
            this.cmdAccept.TabIndex = 9;
            this.cmdAccept.Text = "sAccept";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // cboFinMaterial
            // 
            this.cboFinMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFinMaterial.FormattingEnabled = true;
            this.cboFinMaterial.Location = new System.Drawing.Point(157, 517);
            this.cboFinMaterial.Name = "cboFinMaterial";
            this.cboFinMaterial.Size = new System.Drawing.Size(150, 21);
            this.cboFinMaterial.TabIndex = 7;
            this.cboFinMaterial.SelectedIndexChanged += new System.EventHandler(this.cboFinMaterial_SelectedIndexChanged);
            // 
            // lblFinMaterial
            // 
            this.lblFinMaterial.AutoSize = true;
            this.lblFinMaterial.Location = new System.Drawing.Point(21, 520);
            this.lblFinMaterial.Name = "lblFinMaterial";
            this.lblFinMaterial.Size = new System.Drawing.Size(66, 13);
            this.lblFinMaterial.TabIndex = 79;
            this.lblFinMaterial.Text = "sFin Material";
            // 
            // cboCoilCoating
            // 
            this.cboCoilCoating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCoilCoating.FormattingEnabled = true;
            this.cboCoilCoating.Location = new System.Drawing.Point(483, 517);
            this.cboCoilCoating.Name = "cboCoilCoating";
            this.cboCoilCoating.Size = new System.Drawing.Size(150, 21);
            this.cboCoilCoating.TabIndex = 8;
            this.cboCoilCoating.SelectedIndexChanged += new System.EventHandler(this.cboCoilCoating_SelectedIndexChanged);
            // 
            // lblCoilCoating
            // 
            this.lblCoilCoating.AutoSize = true;
            this.lblCoilCoating.Location = new System.Drawing.Point(338, 520);
            this.lblCoilCoating.Name = "lblCoilCoating";
            this.lblCoilCoating.Size = new System.Drawing.Size(68, 13);
            this.lblCoilCoating.TabIndex = 77;
            this.lblCoilCoating.Text = "sCoil Coating";
            // 
            // cmdRunSelection
            // 
            this.cmdRunSelection.Image = ((System.Drawing.Image)(resources.GetObject("cmdRunSelection.Image")));
            this.cmdRunSelection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRunSelection.Location = new System.Drawing.Point(15, 208);
            this.cmdRunSelection.Name = "cmdRunSelection";
            this.cmdRunSelection.Size = new System.Drawing.Size(618, 25);
            this.cmdRunSelection.TabIndex = 5;
            this.cmdRunSelection.Text = "sRun Selection";
            this.cmdRunSelection.UseVisualStyleBackColor = true;
            this.cmdRunSelection.Click += new System.EventHandler(this.cmdRunSelection_Click);
            // 
            // lvCondensingUnit
            // 
            this.lvCondensingUnit.AllowColumnResize = false;
            this.lvCondensingUnit.AllowMultiselect = false;
            this.lvCondensingUnit.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvCondensingUnit.AlternatingColors = false;
            this.lvCondensingUnit.AutoHeight = true;
            this.lvCondensingUnit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvCondensingUnit.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1";
            glColumn1.NumericSort = false;
            glColumn1.Text = "sIndex";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 0;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column1x";
            glColumn2.NumericSort = false;
            glColumn2.Text = "sModel";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 200;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Column2";
            glColumn3.NumericSort = false;
            glColumn3.Text = "sCapacity (MBH)";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn3.Width = 100;
            glColumn4.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn4.CheckBoxes = false;
            glColumn4.DatetimeSort = false;
            glColumn4.ImageIndex = -1;
            glColumn4.Name = "Column1xx";
            glColumn4.NumericSort = false;
            glColumn4.Text = "sRefrigerant";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn4.Width = 100;
            glColumn5.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn5.CheckBoxes = false;
            glColumn5.DatetimeSort = false;
            glColumn5.ImageIndex = -1;
            glColumn5.Name = "Column1xxx";
            glColumn5.NumericSort = false;
            glColumn5.Text = "sPrice";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            glColumn5.Width = 100;
            this.lvCondensingUnit.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3,
            glColumn4,
            glColumn5});
            this.lvCondensingUnit.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvCondensingUnit.FullRowSelect = true;
            this.lvCondensingUnit.GridColor = System.Drawing.Color.LightGray;
            this.lvCondensingUnit.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvCondensingUnit.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridSolid;
            this.lvCondensingUnit.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvCondensingUnit.HeaderHeight = 22;
            this.lvCondensingUnit.HeaderVisible = true;
            this.lvCondensingUnit.HeaderWordWrap = false;
            this.lvCondensingUnit.HotColumnTracking = false;
            this.lvCondensingUnit.HotItemTracking = false;
            this.lvCondensingUnit.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvCondensingUnit.HoverEvents = false;
            this.lvCondensingUnit.HoverTime = 1;
            this.lvCondensingUnit.ImageList = null;
            this.lvCondensingUnit.ItemHeight = 17;
            this.lvCondensingUnit.ItemWordWrap = false;
            this.lvCondensingUnit.Location = new System.Drawing.Point(18, 237);
            this.lvCondensingUnit.Name = "lvCondensingUnit";
            this.lvCondensingUnit.Selectable = true;
            this.lvCondensingUnit.SelectedTextColor = System.Drawing.Color.White;
            this.lvCondensingUnit.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvCondensingUnit.ShowBorder = true;
            this.lvCondensingUnit.ShowFocusRect = false;
            this.lvCondensingUnit.Size = new System.Drawing.Size(615, 274);
            this.lvCondensingUnit.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lvCondensingUnit.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvCondensingUnit.TabIndex = 6;
            this.lvCondensingUnit.Text = "glacialList1";
            this.lvCondensingUnit.Click += new System.EventHandler(this.lvCondensingUnit_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(301, 545);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 10;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmQuickCondensingUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(643, 578);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lvCondensingUnit);
            this.Controls.Add(this.cmdRunSelection);
            this.Controls.Add(this.cboFinMaterial);
            this.Controls.Add(this.lblFinMaterial);
            this.Controls.Add(this.cboCoilCoating);
            this.Controls.Add(this.lblCoilCoating);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.cboModel);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.cboFilter);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtTag);
            this.Controls.Add(this.lblTag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQuickCondensingUnit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "sQuick Condensing Unit";
            this.Load += new System.EventHandler(this.frmQuickCondensingUnit_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmQuickCondensingUnit_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSaturatedSuctionTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBalancingTemperature)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.Label lblTag;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.NumericUpDown numBalancingTemperature;
        private System.Windows.Forms.Label lblAmbientTemperature;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cboCompressorType;
        private System.Windows.Forms.Label lblCompressorType;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label lblSaturatedSuctionTemperature;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.NumericUpDown numCapacity;
        private System.Windows.Forms.NumericUpDown numSaturatedSuctionTemp;
        private System.Windows.Forms.ComboBox cboRefrigerant;
        private System.Windows.Forms.Label lblRefrigerant;
        private System.Windows.Forms.ComboBox cboCompressorManufacturer;
        private System.Windows.Forms.Label lblCompressorManufacturer;
        private System.Windows.Forms.ComboBox cboModel;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.ComboBox cboFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Button cmdAccept;
        private System.Windows.Forms.ComboBox cboFinMaterial;
        private System.Windows.Forms.Label lblFinMaterial;
        private System.Windows.Forms.ComboBox cboCoilCoating;
        private System.Windows.Forms.Label lblCoilCoating;
        private System.Windows.Forms.ComboBox cboVoltage;
        private System.Windows.Forms.Label lblVoltage;
        private System.Windows.Forms.Button cmdRunSelection;
        private System.Windows.Forms.Label lblCondensingTemperature;
        private GlacialComponents.Controls.GlacialList lvCondensingUnit;
        private System.Windows.Forms.ComboBox cboCapacityRange;
        private System.Windows.Forms.ComboBox cboNumberOfCompressors;
        private System.Windows.Forms.Label lblNumberOfCompressors;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.TextBox txtBalancingTemperature;
        private System.Windows.Forms.TextBox txtSaturatedSuctionTemp;
    }
}