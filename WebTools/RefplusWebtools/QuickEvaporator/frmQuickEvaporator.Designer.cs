namespace RefplusWebtools.QuickEvaporator
{
    partial class FrmQuickEvaporator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQuickEvaporator));
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
            this.numRequiredCapacity = new System.Windows.Forms.NumericUpDown();
            this.lblRequiredCapacity = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.numMaxTemp = new System.Windows.Forms.NumericUpDown();
            this.numMinTemp = new System.Windows.Forms.NumericUpDown();
            this.lblTemperatureRange = new System.Windows.Forms.Label();
            this.cboFinsPerInch = new System.Windows.Forms.ComboBox();
            this.lblFinsPerInch = new System.Windows.Forms.Label();
            this.cboVoltage = new System.Windows.Forms.ComboBox();
            this.lblVoltage = new System.Windows.Forms.Label();
            this.cboDefrostType = new System.Windows.Forms.ComboBox();
            this.lblDefrostType = new System.Windows.Forms.Label();
            this.cboRefrigerant = new System.Windows.Forms.ComboBox();
            this.lblRefrigerant = new System.Windows.Forms.Label();
            this.numLiquidTemperature = new System.Windows.Forms.NumericUpDown();
            this.lblLiquidTemperature = new System.Windows.Forms.Label();
            this.numSuctionTemperature = new System.Windows.Forms.NumericUpDown();
            this.lblSuctionTemperature = new System.Windows.Forms.Label();
            this.cboSelectionType = new System.Windows.Forms.ComboBox();
            this.lblSelectionType = new System.Windows.Forms.Label();
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.cboCoilCoating = new System.Windows.Forms.ComboBox();
            this.lblCoilCoating = new System.Windows.Forms.Label();
            this.cboFinMaterial = new System.Windows.Forms.ComboBox();
            this.lblFinMaterial = new System.Windows.Forms.Label();
            this.cmdRunSelection = new System.Windows.Forms.Button();
            this.cboCondensingUnit = new System.Windows.Forms.ComboBox();
            this.chkAttachToCondensingUnit = new System.Windows.Forms.CheckBox();
            this.lvEvaporators = new GlacialComponents.Controls.GlacialList();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRequiredCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLiquidTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSuctionTemperature)).BeginInit();
            this.SuspendLayout();
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(157, 56);
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(44, 20);
            this.numQuantity.TabIndex = 2;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.ValueChanged += new System.EventHandler(this.numQuantity_ValueChanged);
            this.numQuantity.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(12, 58);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(51, 13);
            this.lblQuantity.TabIndex = 8;
            this.lblQuantity.Text = "sQuantity";
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(157, 30);
            this.txtTag.MaxLength = 50;
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(473, 20);
            this.txtTag.TabIndex = 1;
            this.txtTag.TextChanged += new System.EventHandler(this.txtTag_TextChanged);
            this.txtTag.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblTag
            // 
            this.lblTag.AutoSize = true;
            this.lblTag.Location = new System.Drawing.Point(12, 33);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(31, 13);
            this.lblTag.TabIndex = 6;
            this.lblTag.Text = "sTag";
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.numRequiredCapacity);
            this.grpInput.Controls.Add(this.lblRequiredCapacity);
            this.grpInput.Controls.Add(this.lblTo);
            this.grpInput.Controls.Add(this.numMaxTemp);
            this.grpInput.Controls.Add(this.numMinTemp);
            this.grpInput.Controls.Add(this.lblTemperatureRange);
            this.grpInput.Controls.Add(this.cboFinsPerInch);
            this.grpInput.Controls.Add(this.lblFinsPerInch);
            this.grpInput.Controls.Add(this.cboVoltage);
            this.grpInput.Controls.Add(this.lblVoltage);
            this.grpInput.Controls.Add(this.cboDefrostType);
            this.grpInput.Controls.Add(this.lblDefrostType);
            this.grpInput.Controls.Add(this.cboRefrigerant);
            this.grpInput.Controls.Add(this.lblRefrigerant);
            this.grpInput.Controls.Add(this.numLiquidTemperature);
            this.grpInput.Controls.Add(this.lblLiquidTemperature);
            this.grpInput.Controls.Add(this.numSuctionTemperature);
            this.grpInput.Controls.Add(this.lblSuctionTemperature);
            this.grpInput.Location = new System.Drawing.Point(15, 82);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(615, 118);
            this.grpInput.TabIndex = 3;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "sInputs";
            // 
            // numRequiredCapacity
            // 
            this.numRequiredCapacity.Location = new System.Drawing.Point(459, 92);
            this.numRequiredCapacity.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numRequiredCapacity.Name = "numRequiredCapacity";
            this.numRequiredCapacity.Size = new System.Drawing.Size(150, 20);
            this.numRequiredCapacity.TabIndex = 8;
            this.numRequiredCapacity.ValueChanged += new System.EventHandler(this.numRequiredCapacity_ValueChanged);
            this.numRequiredCapacity.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblRequiredCapacity
            // 
            this.lblRequiredCapacity.AutoSize = true;
            this.lblRequiredCapacity.Location = new System.Drawing.Point(323, 94);
            this.lblRequiredCapacity.Name = "lblRequiredCapacity";
            this.lblRequiredCapacity.Size = new System.Drawing.Size(132, 13);
            this.lblRequiredCapacity.TabIndex = 71;
            this.lblRequiredCapacity.Text = "sRequired Capacity (MBH)";
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(520, 69);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(26, 13);
            this.lblTo.TabIndex = 70;
            this.lblTo.Text = "sTo";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numMaxTemp
            // 
            this.numMaxTemp.Location = new System.Drawing.Point(548, 66);
            this.numMaxTemp.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numMaxTemp.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numMaxTemp.Name = "numMaxTemp";
            this.numMaxTemp.Size = new System.Drawing.Size(61, 20);
            this.numMaxTemp.TabIndex = 7;
            this.numMaxTemp.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numMaxTemp.ValueChanged += new System.EventHandler(this.numMaxTemp_ValueChanged);
            this.numMaxTemp.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // numMinTemp
            // 
            this.numMinTemp.Location = new System.Drawing.Point(459, 66);
            this.numMinTemp.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numMinTemp.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numMinTemp.Name = "numMinTemp";
            this.numMinTemp.Size = new System.Drawing.Size(61, 20);
            this.numMinTemp.TabIndex = 6;
            this.numMinTemp.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numMinTemp.ValueChanged += new System.EventHandler(this.numMinTemp_ValueChanged);
            this.numMinTemp.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblTemperatureRange
            // 
            this.lblTemperatureRange.AutoSize = true;
            this.lblTemperatureRange.Location = new System.Drawing.Point(323, 68);
            this.lblTemperatureRange.Name = "lblTemperatureRange";
            this.lblTemperatureRange.Size = new System.Drawing.Size(107, 13);
            this.lblTemperatureRange.TabIndex = 67;
            this.lblTemperatureRange.Text = "sTemperature Range";
            // 
            // cboFinsPerInch
            // 
            this.cboFinsPerInch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFinsPerInch.FormattingEnabled = true;
            this.cboFinsPerInch.Location = new System.Drawing.Point(459, 39);
            this.cboFinsPerInch.Name = "cboFinsPerInch";
            this.cboFinsPerInch.Size = new System.Drawing.Size(150, 21);
            this.cboFinsPerInch.TabIndex = 5;
            this.cboFinsPerInch.SelectedIndexChanged += new System.EventHandler(this.cboFinsPerInch_SelectedIndexChanged);
            // 
            // lblFinsPerInch
            // 
            this.lblFinsPerInch.AutoSize = true;
            this.lblFinsPerInch.Location = new System.Drawing.Point(323, 42);
            this.lblFinsPerInch.Name = "lblFinsPerInch";
            this.lblFinsPerInch.Size = new System.Drawing.Size(74, 13);
            this.lblFinsPerInch.TabIndex = 65;
            this.lblFinsPerInch.Text = "sFins Per Inch";
            // 
            // cboVoltage
            // 
            this.cboVoltage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVoltage.FormattingEnabled = true;
            this.cboVoltage.Location = new System.Drawing.Point(459, 13);
            this.cboVoltage.Name = "cboVoltage";
            this.cboVoltage.Size = new System.Drawing.Size(150, 21);
            this.cboVoltage.TabIndex = 4;
            this.cboVoltage.SelectedIndexChanged += new System.EventHandler(this.cboVoltage_SelectedIndexChanged);
            // 
            // lblVoltage
            // 
            this.lblVoltage.AutoSize = true;
            this.lblVoltage.Location = new System.Drawing.Point(323, 16);
            this.lblVoltage.Name = "lblVoltage";
            this.lblVoltage.Size = new System.Drawing.Size(48, 13);
            this.lblVoltage.TabIndex = 63;
            this.lblVoltage.Text = "sVoltage";
            // 
            // cboDefrostType
            // 
            this.cboDefrostType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDefrostType.DropDownWidth = 400;
            this.cboDefrostType.FormattingEnabled = true;
            this.cboDefrostType.Location = new System.Drawing.Point(142, 92);
            this.cboDefrostType.Name = "cboDefrostType";
            this.cboDefrostType.Size = new System.Drawing.Size(150, 21);
            this.cboDefrostType.TabIndex = 3;
            this.cboDefrostType.SelectedIndexChanged += new System.EventHandler(this.cboDefrostType_SelectedIndexChanged);
            // 
            // lblDefrostType
            // 
            this.lblDefrostType.AutoSize = true;
            this.lblDefrostType.Location = new System.Drawing.Point(6, 95);
            this.lblDefrostType.Name = "lblDefrostType";
            this.lblDefrostType.Size = new System.Drawing.Size(73, 13);
            this.lblDefrostType.TabIndex = 61;
            this.lblDefrostType.Text = "sDefrost Type";
            // 
            // cboRefrigerant
            // 
            this.cboRefrigerant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRefrigerant.FormattingEnabled = true;
            this.cboRefrigerant.Items.AddRange(new object[] {
            "R-22",
            "R-502",
            "R-134A",
            "R-410A",
            "R-407C",
            "R-404A",
            "R-507"});
            this.cboRefrigerant.Location = new System.Drawing.Point(142, 65);
            this.cboRefrigerant.Name = "cboRefrigerant";
            this.cboRefrigerant.Size = new System.Drawing.Size(150, 21);
            this.cboRefrigerant.TabIndex = 2;
            this.cboRefrigerant.SelectedIndexChanged += new System.EventHandler(this.cboRefrigerant_SelectedIndexChanged);
            // 
            // lblRefrigerant
            // 
            this.lblRefrigerant.AutoSize = true;
            this.lblRefrigerant.Location = new System.Drawing.Point(6, 68);
            this.lblRefrigerant.Name = "lblRefrigerant";
            this.lblRefrigerant.Size = new System.Drawing.Size(64, 13);
            this.lblRefrigerant.TabIndex = 4;
            this.lblRefrigerant.Text = "sRefrigerant";
            // 
            // numLiquidTemperature
            // 
            this.numLiquidTemperature.DecimalPlaces = 1;
            this.numLiquidTemperature.Location = new System.Drawing.Point(142, 40);
            this.numLiquidTemperature.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numLiquidTemperature.Name = "numLiquidTemperature";
            this.numLiquidTemperature.Size = new System.Drawing.Size(150, 20);
            this.numLiquidTemperature.TabIndex = 1;
            this.numLiquidTemperature.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numLiquidTemperature.ValueChanged += new System.EventHandler(this.numLiquidTemperature_ValueChanged);
            this.numLiquidTemperature.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblLiquidTemperature
            // 
            this.lblLiquidTemperature.AutoSize = true;
            this.lblLiquidTemperature.Location = new System.Drawing.Point(6, 42);
            this.lblLiquidTemperature.Name = "lblLiquidTemperature";
            this.lblLiquidTemperature.Size = new System.Drawing.Size(103, 13);
            this.lblLiquidTemperature.TabIndex = 2;
            this.lblLiquidTemperature.Text = "sLiquid Temperature";
            // 
            // numSuctionTemperature
            // 
            this.numSuctionTemperature.DecimalPlaces = 1;
            this.numSuctionTemperature.Location = new System.Drawing.Point(142, 14);
            this.numSuctionTemperature.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numSuctionTemperature.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            -2147483648});
            this.numSuctionTemperature.Name = "numSuctionTemperature";
            this.numSuctionTemperature.Size = new System.Drawing.Size(150, 20);
            this.numSuctionTemperature.TabIndex = 0;
            this.numSuctionTemperature.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numSuctionTemperature.ValueChanged += new System.EventHandler(this.numSuctionTemperature_ValueChanged);
            this.numSuctionTemperature.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblSuctionTemperature
            // 
            this.lblSuctionTemperature.AutoSize = true;
            this.lblSuctionTemperature.Location = new System.Drawing.Point(6, 16);
            this.lblSuctionTemperature.Name = "lblSuctionTemperature";
            this.lblSuctionTemperature.Size = new System.Drawing.Size(111, 13);
            this.lblSuctionTemperature.TabIndex = 0;
            this.lblSuctionTemperature.Text = "sSuction Temperature";
            // 
            // cboSelectionType
            // 
            this.cboSelectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelectionType.FormattingEnabled = true;
            this.cboSelectionType.Items.AddRange(new object[] {
            "AUTOMATIC",
            "MANUAL"});
            this.cboSelectionType.Location = new System.Drawing.Point(157, 206);
            this.cboSelectionType.Name = "cboSelectionType";
            this.cboSelectionType.Size = new System.Drawing.Size(150, 21);
            this.cboSelectionType.TabIndex = 4;
            this.cboSelectionType.SelectedIndexChanged += new System.EventHandler(this.cboSelectionType_SelectedIndexChanged);
            // 
            // lblSelectionType
            // 
            this.lblSelectionType.AutoSize = true;
            this.lblSelectionType.Location = new System.Drawing.Point(12, 209);
            this.lblSelectionType.Name = "lblSelectionType";
            this.lblSelectionType.Size = new System.Drawing.Size(83, 13);
            this.lblSelectionType.TabIndex = 61;
            this.lblSelectionType.Text = "sSelection Type";
            // 
            // cboModel
            // 
            this.cboModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModel.FormattingEnabled = true;
            this.cboModel.Location = new System.Drawing.Point(474, 206);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(150, 21);
            this.cboModel.TabIndex = 5;
            this.cboModel.SelectedIndexChanged += new System.EventHandler(this.cboModel_SelectedIndexChanged);
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(338, 209);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(41, 13);
            this.lblModel.TabIndex = 63;
            this.lblModel.Text = "sModel";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(485, 482);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(150, 25);
            this.cmdCancel.TabIndex = 11;
            this.cmdCancel.Text = "sCancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdAccept
            // 
            this.cmdAccept.Image = ((System.Drawing.Image)(resources.GetObject("cmdAccept.Image")));
            this.cmdAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAccept.Location = new System.Drawing.Point(12, 482);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(150, 25);
            this.cmdAccept.TabIndex = 10;
            this.cmdAccept.Text = "sAccept";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // cboCoilCoating
            // 
            this.cboCoilCoating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCoilCoating.FormattingEnabled = true;
            this.cboCoilCoating.Location = new System.Drawing.Point(157, 455);
            this.cboCoilCoating.Name = "cboCoilCoating";
            this.cboCoilCoating.Size = new System.Drawing.Size(150, 21);
            this.cboCoilCoating.TabIndex = 8;
            this.cboCoilCoating.Visible = false;
            // 
            // lblCoilCoating
            // 
            this.lblCoilCoating.AutoSize = true;
            this.lblCoilCoating.Location = new System.Drawing.Point(12, 458);
            this.lblCoilCoating.Name = "lblCoilCoating";
            this.lblCoilCoating.Size = new System.Drawing.Size(68, 13);
            this.lblCoilCoating.TabIndex = 73;
            this.lblCoilCoating.Text = "sCoil Coating";
            this.lblCoilCoating.Visible = false;
            // 
            // cboFinMaterial
            // 
            this.cboFinMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFinMaterial.FormattingEnabled = true;
            this.cboFinMaterial.Location = new System.Drawing.Point(485, 455);
            this.cboFinMaterial.Name = "cboFinMaterial";
            this.cboFinMaterial.Size = new System.Drawing.Size(150, 21);
            this.cboFinMaterial.TabIndex = 9;
            // 
            // lblFinMaterial
            // 
            this.lblFinMaterial.AutoSize = true;
            this.lblFinMaterial.Location = new System.Drawing.Point(338, 458);
            this.lblFinMaterial.Name = "lblFinMaterial";
            this.lblFinMaterial.Size = new System.Drawing.Size(66, 13);
            this.lblFinMaterial.TabIndex = 75;
            this.lblFinMaterial.Text = "sFin Material";
            // 
            // cmdRunSelection
            // 
            this.cmdRunSelection.Image = ((System.Drawing.Image)(resources.GetObject("cmdRunSelection.Image")));
            this.cmdRunSelection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRunSelection.Location = new System.Drawing.Point(12, 233);
            this.cmdRunSelection.Name = "cmdRunSelection";
            this.cmdRunSelection.Size = new System.Drawing.Size(623, 25);
            this.cmdRunSelection.TabIndex = 6;
            this.cmdRunSelection.Text = "sRun Selection";
            this.cmdRunSelection.UseVisualStyleBackColor = true;
            this.cmdRunSelection.Click += new System.EventHandler(this.cmdRunSelection_Click);
            // 
            // cboCondensingUnit
            // 
            this.cboCondensingUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondensingUnit.FormattingEnabled = true;
            this.cboCondensingUnit.Location = new System.Drawing.Point(251, 5);
            this.cboCondensingUnit.Name = "cboCondensingUnit";
            this.cboCondensingUnit.Size = new System.Drawing.Size(236, 21);
            this.cboCondensingUnit.TabIndex = 0;
            this.cboCondensingUnit.Visible = false;
            // 
            // chkAttachToCondensingUnit
            // 
            this.chkAttachToCondensingUnit.AutoSize = true;
            this.chkAttachToCondensingUnit.Location = new System.Drawing.Point(12, 7);
            this.chkAttachToCondensingUnit.Name = "chkAttachToCondensingUnit";
            this.chkAttachToCondensingUnit.Size = new System.Drawing.Size(164, 17);
            this.chkAttachToCondensingUnit.TabIndex = 0;
            this.chkAttachToCondensingUnit.Text = "sAttach to a Condensing Unit";
            this.chkAttachToCondensingUnit.UseVisualStyleBackColor = true;
            this.chkAttachToCondensingUnit.CheckedChanged += new System.EventHandler(this.chkAttachToCondensingUnit_CheckedChanged);
            // 
            // lvEvaporators
            // 
            this.lvEvaporators.AllowColumnResize = false;
            this.lvEvaporators.AllowMultiselect = false;
            this.lvEvaporators.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvEvaporators.AlternatingColors = false;
            this.lvEvaporators.AutoHeight = false;
            this.lvEvaporators.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvEvaporators.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1";
            glColumn1.NumericSort = false;
            glColumn1.Text = "ID";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 0;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column1x";
            glColumn2.NumericSort = false;
            glColumn2.Text = "sModel";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn2.Width = 180;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Column2";
            glColumn3.NumericSort = false;
            glColumn3.Text = "sCapacity";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn3.Width = 150;
            glColumn4.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn4.CheckBoxes = false;
            glColumn4.DatetimeSort = false;
            glColumn4.ImageIndex = -1;
            glColumn4.Name = "Column4";
            glColumn4.NumericSort = false;
            glColumn4.Text = "sTD";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn4.Width = 150;
            glColumn5.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn5.CheckBoxes = false;
            glColumn5.DatetimeSort = false;
            glColumn5.ImageIndex = -1;
            glColumn5.Name = "Column1xx";
            glColumn5.NumericSort = false;
            glColumn5.Text = "sPrice";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            glColumn5.Width = 110;
            this.lvEvaporators.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3,
            glColumn4,
            glColumn5});
            this.lvEvaporators.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvEvaporators.FullRowSelect = true;
            this.lvEvaporators.GridColor = System.Drawing.Color.LightGray;
            this.lvEvaporators.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvEvaporators.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvEvaporators.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvEvaporators.HeaderHeight = 22;
            this.lvEvaporators.HeaderVisible = true;
            this.lvEvaporators.HeaderWordWrap = false;
            this.lvEvaporators.HotColumnTracking = false;
            this.lvEvaporators.HotItemTracking = false;
            this.lvEvaporators.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvEvaporators.HoverEvents = false;
            this.lvEvaporators.HoverTime = 1;
            this.lvEvaporators.ImageList = null;
            this.lvEvaporators.ItemHeight = 25;
            this.lvEvaporators.ItemWordWrap = false;
            this.lvEvaporators.Location = new System.Drawing.Point(12, 262);
            this.lvEvaporators.Name = "lvEvaporators";
            this.lvEvaporators.Selectable = true;
            this.lvEvaporators.SelectedTextColor = System.Drawing.Color.White;
            this.lvEvaporators.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvEvaporators.ShowBorder = true;
            this.lvEvaporators.ShowFocusRect = true;
            this.lvEvaporators.Size = new System.Drawing.Size(623, 186);
            this.lvEvaporators.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lvEvaporators.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvEvaporators.TabIndex = 7;
            this.lvEvaporators.Text = "glacialList1";
            this.lvEvaporators.SelectedIndexChanged += new GlacialComponents.Controls.GlacialList.ClickedEventHandler(this.lvEvaporators_SelectedIndexChanged);
            this.lvEvaporators.Click += new System.EventHandler(this.lvEvaporators_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(307, 482);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 76;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmQuickEvaporator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(643, 511);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lvEvaporators);
            this.Controls.Add(this.cboCondensingUnit);
            this.Controls.Add(this.chkAttachToCondensingUnit);
            this.Controls.Add(this.cmdRunSelection);
            this.Controls.Add(this.cboFinMaterial);
            this.Controls.Add(this.lblFinMaterial);
            this.Controls.Add(this.cboCoilCoating);
            this.Controls.Add(this.lblCoilCoating);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.cboModel);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.cboSelectionType);
            this.Controls.Add(this.lblSelectionType);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtTag);
            this.Controls.Add(this.lblTag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQuickEvaporator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "sQuick Evaporator";
            this.Load += new System.EventHandler(this.frmQuickEvaporator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRequiredCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLiquidTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSuctionTemperature)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.Label lblTag;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.NumericUpDown numLiquidTemperature;
        private System.Windows.Forms.Label lblLiquidTemperature;
        private System.Windows.Forms.NumericUpDown numSuctionTemperature;
        private System.Windows.Forms.Label lblSuctionTemperature;
        private System.Windows.Forms.Label lblRefrigerant;
        private System.Windows.Forms.ComboBox cboDefrostType;
        private System.Windows.Forms.Label lblDefrostType;
        private System.Windows.Forms.ComboBox cboRefrigerant;
        private System.Windows.Forms.NumericUpDown numMinTemp;
        private System.Windows.Forms.Label lblTemperatureRange;
        private System.Windows.Forms.ComboBox cboFinsPerInch;
        private System.Windows.Forms.Label lblFinsPerInch;
        private System.Windows.Forms.ComboBox cboVoltage;
        private System.Windows.Forms.Label lblVoltage;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.NumericUpDown numMaxTemp;
        private System.Windows.Forms.NumericUpDown numRequiredCapacity;
        private System.Windows.Forms.Label lblRequiredCapacity;
        private System.Windows.Forms.ComboBox cboSelectionType;
        private System.Windows.Forms.Label lblSelectionType;
        private System.Windows.Forms.ComboBox cboModel;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdAccept;
        private System.Windows.Forms.ComboBox cboCoilCoating;
        private System.Windows.Forms.Label lblCoilCoating;
        private System.Windows.Forms.ComboBox cboFinMaterial;
        private System.Windows.Forms.Label lblFinMaterial;
        private System.Windows.Forms.Button cmdRunSelection;
        private System.Windows.Forms.ComboBox cboCondensingUnit;
        private System.Windows.Forms.CheckBox chkAttachToCondensingUnit;
        private GlacialComponents.Controls.GlacialList lvEvaporators;
        private System.Windows.Forms.Button btnHelp;
    }
}