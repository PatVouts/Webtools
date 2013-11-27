namespace RefplusWebtools.QuickFluidCooler
{
    partial class FrmQuickFluidCooler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQuickFluidCooler));
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.lblTag = new System.Windows.Forms.Label();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.radRatingGPM = new System.Windows.Forms.RadioButton();
            this.radRatingLLT = new System.Windows.Forms.RadioButton();
            this.cboFPI = new System.Windows.Forms.ComboBox();
            this.lblFPI = new System.Windows.Forms.Label();
            this.cboAirFlowType = new System.Windows.Forms.ComboBox();
            this.lblAirFlowType = new System.Windows.Forms.Label();
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
            this.cboFanArrangement = new System.Windows.Forms.ComboBox();
            this.lblFanArrangement = new System.Windows.Forms.Label();
            this.cboUnitType = new System.Windows.Forms.ComboBox();
            this.lblUnitType = new System.Windows.Forms.Label();
            this.cboVoltage = new System.Windows.Forms.ComboBox();
            this.lblVoltage = new System.Windows.Forms.Label();
            this.numPSI = new System.Windows.Forms.NumericUpDown();
            this.lblPSI = new System.Windows.Forms.Label();
            this.lblAltitude = new System.Windows.Forms.Label();
            this.lblELT = new System.Windows.Forms.Label();
            this.lblEDB = new System.Windows.Forms.Label();
            this.lblLeavingLiquidTemperature = new System.Windows.Forms.Label();
            this.cboFluidType = new System.Windows.Forms.ComboBox();
            this.lblConcentration = new System.Windows.Forms.Label();
            this.numConcentration = new System.Windows.Forms.NumericUpDown();
            this.numEDB = new System.Windows.Forms.NumericUpDown();
            this.lblFluidType = new System.Windows.Forms.Label();
            this.numELT = new System.Windows.Forms.NumericUpDown();
            this.numAltitude = new System.Windows.Forms.NumericUpDown();
            this.numLeavingLiquidTemperature = new System.Windows.Forms.NumericUpDown();
            this.numUSGPM = new System.Windows.Forms.NumericUpDown();
            this.numTotalHeat = new System.Windows.Forms.NumericUpDown();
            this.cboGPM_TotalHeat = new System.Windows.Forms.ComboBox();
            this.lblUSGPM = new System.Windows.Forms.Label();
            this.cmdRunSelection = new System.Windows.Forms.Button();
            this.lvFluidCooler = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLLT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLAT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGPM = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTotalHeat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPressureDrop = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVelocity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.cboLocation = new System.Windows.Forms.ComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThermalConductivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numViscosity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecificHeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPSI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numConcentration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numELT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLeavingLiquidTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUSGPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalHeat)).BeginInit();
            this.SuspendLayout();
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(78, 29);
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
            this.numQuantity.ValueChanged += new System.EventHandler(this.numQuantity_ValueChanged);
            this.numQuantity.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(10, 31);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(51, 13);
            this.lblQuantity.TabIndex = 12;
            this.lblQuantity.Text = "sQuantity";
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(78, 7);
            this.txtTag.MaxLength = 50;
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(550, 20);
            this.txtTag.TabIndex = 0;
            this.txtTag.TextChanged += new System.EventHandler(this.txtTag_TextChanged);
            this.txtTag.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblTag
            // 
            this.lblTag.AutoSize = true;
            this.lblTag.Location = new System.Drawing.Point(10, 10);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(31, 13);
            this.lblTag.TabIndex = 10;
            this.lblTag.Text = "sTag";
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.radRatingGPM);
            this.grpInput.Controls.Add(this.radRatingLLT);
            this.grpInput.Controls.Add(this.cboFPI);
            this.grpInput.Controls.Add(this.lblFPI);
            this.grpInput.Controls.Add(this.cboAirFlowType);
            this.grpInput.Controls.Add(this.lblAirFlowType);
            this.grpInput.Controls.Add(this.txtFluidTypeName);
            this.grpInput.Controls.Add(this.lblFluidTypeName);
            this.grpInput.Controls.Add(this.lblThermalConductivity);
            this.grpInput.Controls.Add(this.numThermalConductivity);
            this.grpInput.Controls.Add(this.lblViscosity);
            this.grpInput.Controls.Add(this.numViscosity);
            this.grpInput.Controls.Add(this.lblDensity);
            this.grpInput.Controls.Add(this.numDensity);
            this.grpInput.Controls.Add(this.lblSpecificHeat);
            this.grpInput.Controls.Add(this.numSpecificHeat);
            this.grpInput.Controls.Add(this.cboFanArrangement);
            this.grpInput.Controls.Add(this.lblFanArrangement);
            this.grpInput.Controls.Add(this.cboUnitType);
            this.grpInput.Controls.Add(this.lblUnitType);
            this.grpInput.Controls.Add(this.cboVoltage);
            this.grpInput.Controls.Add(this.lblVoltage);
            this.grpInput.Controls.Add(this.numPSI);
            this.grpInput.Controls.Add(this.lblPSI);
            this.grpInput.Controls.Add(this.lblAltitude);
            this.grpInput.Controls.Add(this.lblELT);
            this.grpInput.Controls.Add(this.lblEDB);
            this.grpInput.Controls.Add(this.lblLeavingLiquidTemperature);
            this.grpInput.Controls.Add(this.cboFluidType);
            this.grpInput.Controls.Add(this.lblConcentration);
            this.grpInput.Controls.Add(this.numConcentration);
            this.grpInput.Controls.Add(this.numEDB);
            this.grpInput.Controls.Add(this.lblFluidType);
            this.grpInput.Controls.Add(this.numELT);
            this.grpInput.Controls.Add(this.numAltitude);
            this.grpInput.Controls.Add(this.numLeavingLiquidTemperature);
            this.grpInput.Controls.Add(this.numUSGPM);
            this.grpInput.Controls.Add(this.numTotalHeat);
            this.grpInput.Controls.Add(this.cboGPM_TotalHeat);
            this.grpInput.Controls.Add(this.lblUSGPM);
            this.grpInput.Location = new System.Drawing.Point(13, 73);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(615, 251);
            this.grpInput.TabIndex = 5;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "sInputs";
            // 
            // radRatingGPM
            // 
            this.radRatingGPM.AutoSize = true;
            this.radRatingGPM.Location = new System.Drawing.Point(305, 136);
            this.radRatingGPM.Name = "radRatingGPM";
            this.radRatingGPM.Size = new System.Drawing.Size(14, 13);
            this.radRatingGPM.TabIndex = 16;
            this.radRatingGPM.UseVisualStyleBackColor = true;
            this.radRatingGPM.Visible = false;
            this.radRatingGPM.CheckedChanged += new System.EventHandler(this.radRatingGPM_CheckedChanged);
            // 
            // radRatingLLT
            // 
            this.radRatingLLT.AutoSize = true;
            this.radRatingLLT.Checked = true;
            this.radRatingLLT.Location = new System.Drawing.Point(305, 112);
            this.radRatingLLT.Name = "radRatingLLT";
            this.radRatingLLT.Size = new System.Drawing.Size(14, 13);
            this.radRatingLLT.TabIndex = 14;
            this.radRatingLLT.TabStop = true;
            this.radRatingLLT.UseVisualStyleBackColor = true;
            this.radRatingLLT.Visible = false;
            this.radRatingLLT.CheckedChanged += new System.EventHandler(this.radRatingLLT_CheckedChanged);
            // 
            // cboFPI
            // 
            this.cboFPI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFPI.FormattingEnabled = true;
            this.cboFPI.Location = new System.Drawing.Point(476, 179);
            this.cboFPI.Name = "cboFPI";
            this.cboFPI.Size = new System.Drawing.Size(133, 21);
            this.cboFPI.TabIndex = 18;
            this.cboFPI.SelectedIndexChanged += new System.EventHandler(this.cboFPI_SelectedIndexChanged);
            // 
            // lblFPI
            // 
            this.lblFPI.AutoSize = true;
            this.lblFPI.Location = new System.Drawing.Point(316, 182);
            this.lblFPI.Name = "lblFPI";
            this.lblFPI.Size = new System.Drawing.Size(73, 13);
            this.lblFPI.TabIndex = 94;
            this.lblFPI.Text = "sFins per Inch";
            // 
            // cboAirFlowType
            // 
            this.cboAirFlowType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAirFlowType.FormattingEnabled = true;
            this.cboAirFlowType.Location = new System.Drawing.Point(476, 155);
            this.cboAirFlowType.Name = "cboAirFlowType";
            this.cboAirFlowType.Size = new System.Drawing.Size(132, 21);
            this.cboAirFlowType.TabIndex = 17;
            this.cboAirFlowType.SelectedIndexChanged += new System.EventHandler(this.cboAirFlowType_SelectedIndexChanged);
            // 
            // lblAirFlowType
            // 
            this.lblAirFlowType.AutoSize = true;
            this.lblAirFlowType.Location = new System.Drawing.Point(315, 158);
            this.lblAirFlowType.Name = "lblAirFlowType";
            this.lblAirFlowType.Size = new System.Drawing.Size(76, 13);
            this.lblAirFlowType.TabIndex = 92;
            this.lblAirFlowType.Text = "sAir Flow Type";
            // 
            // txtFluidTypeName
            // 
            this.txtFluidTypeName.Enabled = false;
            this.txtFluidTypeName.Location = new System.Drawing.Point(210, 130);
            this.txtFluidTypeName.MaxLength = 15;
            this.txtFluidTypeName.Name = "txtFluidTypeName";
            this.txtFluidTypeName.Size = new System.Drawing.Size(90, 20);
            this.txtFluidTypeName.TabIndex = 5;
            this.txtFluidTypeName.TextChanged += new System.EventHandler(this.txtFluidTypeName_TextChanged);
            this.txtFluidTypeName.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblFluidTypeName
            // 
            this.lblFluidTypeName.AutoSize = true;
            this.lblFluidTypeName.Location = new System.Drawing.Point(14, 133);
            this.lblFluidTypeName.Name = "lblFluidTypeName";
            this.lblFluidTypeName.Size = new System.Drawing.Size(92, 13);
            this.lblFluidTypeName.TabIndex = 91;
            this.lblFluidTypeName.Text = "sFluid Type Name";
            // 
            // lblThermalConductivity
            // 
            this.lblThermalConductivity.AutoSize = true;
            this.lblThermalConductivity.Location = new System.Drawing.Point(14, 226);
            this.lblThermalConductivity.Name = "lblThermalConductivity";
            this.lblThermalConductivity.Size = new System.Drawing.Size(180, 13);
            this.lblThermalConductivity.TabIndex = 86;
            this.lblThermalConductivity.Text = "sThermal Conductivity (BTU/H/sq.ft)";
            // 
            // numThermalConductivity
            // 
            this.numThermalConductivity.DecimalPlaces = 4;
            this.numThermalConductivity.Enabled = false;
            this.numThermalConductivity.Location = new System.Drawing.Point(210, 224);
            this.numThermalConductivity.Name = "numThermalConductivity";
            this.numThermalConductivity.Size = new System.Drawing.Size(90, 20);
            this.numThermalConductivity.TabIndex = 9;
            this.numThermalConductivity.ValueChanged += new System.EventHandler(this.numThermalConductivity_ValueChanged);
            this.numThermalConductivity.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblViscosity
            // 
            this.lblViscosity.AutoSize = true;
            this.lblViscosity.Location = new System.Drawing.Point(14, 202);
            this.lblViscosity.Name = "lblViscosity";
            this.lblViscosity.Size = new System.Drawing.Size(111, 13);
            this.lblViscosity.TabIndex = 84;
            this.lblViscosity.Text = "sViscosity (Centipoise)";
            // 
            // numViscosity
            // 
            this.numViscosity.DecimalPlaces = 4;
            this.numViscosity.Enabled = false;
            this.numViscosity.Location = new System.Drawing.Point(210, 200);
            this.numViscosity.Name = "numViscosity";
            this.numViscosity.Size = new System.Drawing.Size(90, 20);
            this.numViscosity.TabIndex = 8;
            this.numViscosity.ValueChanged += new System.EventHandler(this.numViscosity_ValueChanged);
            this.numViscosity.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblDensity
            // 
            this.lblDensity.AutoSize = true;
            this.lblDensity.Location = new System.Drawing.Point(14, 179);
            this.lblDensity.Name = "lblDensity";
            this.lblDensity.Size = new System.Drawing.Size(90, 13);
            this.lblDensity.TabIndex = 82;
            this.lblDensity.Text = "sDensity (lb/cu.ft)";
            // 
            // numDensity
            // 
            this.numDensity.DecimalPlaces = 4;
            this.numDensity.Enabled = false;
            this.numDensity.Location = new System.Drawing.Point(210, 177);
            this.numDensity.Name = "numDensity";
            this.numDensity.Size = new System.Drawing.Size(90, 20);
            this.numDensity.TabIndex = 7;
            this.numDensity.ValueChanged += new System.EventHandler(this.numDensity_ValueChanged);
            this.numDensity.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblSpecificHeat
            // 
            this.lblSpecificHeat.AutoSize = true;
            this.lblSpecificHeat.Location = new System.Drawing.Point(14, 155);
            this.lblSpecificHeat.Name = "lblSpecificHeat";
            this.lblSpecificHeat.Size = new System.Drawing.Size(135, 13);
            this.lblSpecificHeat.TabIndex = 80;
            this.lblSpecificHeat.Text = "sSpecific Heat (BTU/lb/°F)";
            // 
            // numSpecificHeat
            // 
            this.numSpecificHeat.DecimalPlaces = 4;
            this.numSpecificHeat.Enabled = false;
            this.numSpecificHeat.Location = new System.Drawing.Point(210, 153);
            this.numSpecificHeat.Name = "numSpecificHeat";
            this.numSpecificHeat.Size = new System.Drawing.Size(90, 20);
            this.numSpecificHeat.TabIndex = 6;
            this.numSpecificHeat.ValueChanged += new System.EventHandler(this.numSpecificHeat_ValueChanged);
            this.numSpecificHeat.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // cboFanArrangement
            // 
            this.cboFanArrangement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFanArrangement.FormattingEnabled = true;
            this.cboFanArrangement.Location = new System.Drawing.Point(476, 85);
            this.cboFanArrangement.Name = "cboFanArrangement";
            this.cboFanArrangement.Size = new System.Drawing.Size(131, 21);
            this.cboFanArrangement.TabIndex = 13;
            this.cboFanArrangement.SelectedIndexChanged += new System.EventHandler(this.cboFanArrangement_SelectedIndexChanged);
            // 
            // lblFanArrangement
            // 
            this.lblFanArrangement.AutoSize = true;
            this.lblFanArrangement.Location = new System.Drawing.Point(315, 88);
            this.lblFanArrangement.Name = "lblFanArrangement";
            this.lblFanArrangement.Size = new System.Drawing.Size(93, 13);
            this.lblFanArrangement.TabIndex = 77;
            this.lblFanArrangement.Text = "sFan Arrangement";
            // 
            // cboUnitType
            // 
            this.cboUnitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnitType.DropDownWidth = 300;
            this.cboUnitType.FormattingEnabled = true;
            this.cboUnitType.Location = new System.Drawing.Point(476, 61);
            this.cboUnitType.Name = "cboUnitType";
            this.cboUnitType.Size = new System.Drawing.Size(131, 21);
            this.cboUnitType.TabIndex = 12;
            this.cboUnitType.SelectedIndexChanged += new System.EventHandler(this.cboUnitType_SelectedIndexChanged);
            // 
            // lblUnitType
            // 
            this.lblUnitType.AutoSize = true;
            this.lblUnitType.Location = new System.Drawing.Point(315, 64);
            this.lblUnitType.Name = "lblUnitType";
            this.lblUnitType.Size = new System.Drawing.Size(58, 13);
            this.lblUnitType.TabIndex = 75;
            this.lblUnitType.Text = "sUnit Type";
            // 
            // cboVoltage
            // 
            this.cboVoltage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVoltage.FormattingEnabled = true;
            this.cboVoltage.Location = new System.Drawing.Point(476, 14);
            this.cboVoltage.Name = "cboVoltage";
            this.cboVoltage.Size = new System.Drawing.Size(131, 21);
            this.cboVoltage.TabIndex = 10;
            this.cboVoltage.SelectedIndexChanged += new System.EventHandler(this.cboVoltage_SelectedIndexChanged);
            // 
            // lblVoltage
            // 
            this.lblVoltage.AutoSize = true;
            this.lblVoltage.Location = new System.Drawing.Point(315, 17);
            this.lblVoltage.Name = "lblVoltage";
            this.lblVoltage.Size = new System.Drawing.Size(48, 13);
            this.lblVoltage.TabIndex = 73;
            this.lblVoltage.Text = "sVoltage";
            // 
            // numPSI
            // 
            this.numPSI.Location = new System.Drawing.Point(476, 38);
            this.numPSI.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPSI.Name = "numPSI";
            this.numPSI.Size = new System.Drawing.Size(131, 20);
            this.numPSI.TabIndex = 11;
            this.numPSI.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPSI.ValueChanged += new System.EventHandler(this.numPSI_ValueChanged);
            this.numPSI.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblPSI
            // 
            this.lblPSI.AutoSize = true;
            this.lblPSI.Location = new System.Drawing.Point(315, 40);
            this.lblPSI.Name = "lblPSI";
            this.lblPSI.Size = new System.Drawing.Size(127, 13);
            this.lblPSI.TabIndex = 71;
            this.lblPSI.Text = "sMax Fluid Pressure (PSI)";
            // 
            // lblAltitude
            // 
            this.lblAltitude.AutoSize = true;
            this.lblAltitude.Location = new System.Drawing.Point(14, 39);
            this.lblAltitude.Name = "lblAltitude";
            this.lblAltitude.Size = new System.Drawing.Size(62, 13);
            this.lblAltitude.TabIndex = 33;
            this.lblAltitude.Text = "sAltitude (ft)";
            // 
            // lblELT
            // 
            this.lblELT.AutoSize = true;
            this.lblELT.Location = new System.Drawing.Point(14, 62);
            this.lblELT.Name = "lblELT";
            this.lblELT.Size = new System.Drawing.Size(164, 13);
            this.lblELT.TabIndex = 29;
            this.lblELT.Text = "sEntering Liquid Temperature (°F)";
            // 
            // lblEDB
            // 
            this.lblEDB.AutoSize = true;
            this.lblEDB.Location = new System.Drawing.Point(14, 16);
            this.lblEDB.Name = "lblEDB";
            this.lblEDB.Size = new System.Drawing.Size(113, 13);
            this.lblEDB.TabIndex = 27;
            this.lblEDB.Text = "sEntering Dry Bulb (°F)";
            // 
            // lblLeavingLiquidTemperature
            // 
            this.lblLeavingLiquidTemperature.AutoSize = true;
            this.lblLeavingLiquidTemperature.Location = new System.Drawing.Point(315, 111);
            this.lblLeavingLiquidTemperature.Name = "lblLeavingLiquidTemperature";
            this.lblLeavingLiquidTemperature.Size = new System.Drawing.Size(144, 13);
            this.lblLeavingLiquidTemperature.TabIndex = 66;
            this.lblLeavingLiquidTemperature.Text = "sLeaving Liquid Temperature";
            // 
            // cboFluidType
            // 
            this.cboFluidType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFluidType.FormattingEnabled = true;
            this.cboFluidType.Location = new System.Drawing.Point(210, 83);
            this.cboFluidType.Name = "cboFluidType";
            this.cboFluidType.Size = new System.Drawing.Size(90, 21);
            this.cboFluidType.TabIndex = 3;
            this.cboFluidType.SelectedIndexChanged += new System.EventHandler(this.cboFluidType_SelectedIndexChanged);
            // 
            // lblConcentration
            // 
            this.lblConcentration.AutoSize = true;
            this.lblConcentration.Location = new System.Drawing.Point(14, 109);
            this.lblConcentration.Name = "lblConcentration";
            this.lblConcentration.Size = new System.Drawing.Size(95, 13);
            this.lblConcentration.TabIndex = 58;
            this.lblConcentration.Text = "sConcentration (%)";
            // 
            // numConcentration
            // 
            this.numConcentration.Location = new System.Drawing.Point(210, 107);
            this.numConcentration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numConcentration.Name = "numConcentration";
            this.numConcentration.Size = new System.Drawing.Size(90, 20);
            this.numConcentration.TabIndex = 4;
            this.numConcentration.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numConcentration.ValueChanged += new System.EventHandler(this.numConcentration_ValueChanged);
            this.numConcentration.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // numEDB
            // 
            this.numEDB.DecimalPlaces = 1;
            this.numEDB.Location = new System.Drawing.Point(210, 14);
            this.numEDB.Maximum = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.numEDB.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numEDB.Name = "numEDB";
            this.numEDB.Size = new System.Drawing.Size(90, 20);
            this.numEDB.TabIndex = 0;
            this.numEDB.Value = new decimal(new int[] {
            95,
            0,
            0,
            0});
            this.numEDB.ValueChanged += new System.EventHandler(this.numEDB_ValueChanged);
            this.numEDB.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblFluidType
            // 
            this.lblFluidType.AutoSize = true;
            this.lblFluidType.Location = new System.Drawing.Point(14, 86);
            this.lblFluidType.Name = "lblFluidType";
            this.lblFluidType.Size = new System.Drawing.Size(61, 13);
            this.lblFluidType.TabIndex = 56;
            this.lblFluidType.Text = "sFuild Type";
            // 
            // numELT
            // 
            this.numELT.DecimalPlaces = 1;
            this.numELT.Location = new System.Drawing.Point(210, 60);
            this.numELT.Maximum = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.numELT.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numELT.Name = "numELT";
            this.numELT.Size = new System.Drawing.Size(90, 20);
            this.numELT.TabIndex = 2;
            this.numELT.Value = new decimal(new int[] {
            110,
            0,
            0,
            0});
            this.numELT.ValueChanged += new System.EventHandler(this.numELT_ValueChanged);
            this.numELT.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // numAltitude
            // 
            this.numAltitude.Location = new System.Drawing.Point(210, 37);
            this.numAltitude.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numAltitude.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.numAltitude.Name = "numAltitude";
            this.numAltitude.Size = new System.Drawing.Size(90, 20);
            this.numAltitude.TabIndex = 1;
            this.numAltitude.ValueChanged += new System.EventHandler(this.numAltitude_ValueChanged);
            this.numAltitude.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // numLeavingLiquidTemperature
            // 
            this.numLeavingLiquidTemperature.DecimalPlaces = 1;
            this.numLeavingLiquidTemperature.Location = new System.Drawing.Point(476, 109);
            this.numLeavingLiquidTemperature.Maximum = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.numLeavingLiquidTemperature.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numLeavingLiquidTemperature.Name = "numLeavingLiquidTemperature";
            this.numLeavingLiquidTemperature.Size = new System.Drawing.Size(131, 20);
            this.numLeavingLiquidTemperature.TabIndex = 14;
            this.numLeavingLiquidTemperature.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numLeavingLiquidTemperature.ValueChanged += new System.EventHandler(this.numLeavingLiquidTemperature_ValueChanged);
            this.numLeavingLiquidTemperature.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // numUSGPM
            // 
            this.numUSGPM.DecimalPlaces = 1;
            this.numUSGPM.Location = new System.Drawing.Point(476, 132);
            this.numUSGPM.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numUSGPM.Name = "numUSGPM";
            this.numUSGPM.Size = new System.Drawing.Size(132, 20);
            this.numUSGPM.TabIndex = 16;
            this.numUSGPM.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numUSGPM.ValueChanged += new System.EventHandler(this.numUSGPM_ValueChanged);
            this.numUSGPM.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // numTotalHeat
            // 
            this.numTotalHeat.DecimalPlaces = 1;
            this.numTotalHeat.Location = new System.Drawing.Point(476, 132);
            this.numTotalHeat.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numTotalHeat.Name = "numTotalHeat";
            this.numTotalHeat.Size = new System.Drawing.Size(132, 20);
            this.numTotalHeat.TabIndex = 18;
            this.numTotalHeat.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numTotalHeat.Visible = false;
            this.numTotalHeat.ValueChanged += new System.EventHandler(this.numTotalHeat_ValueChanged);
            this.numTotalHeat.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // cboGPM_TotalHeat
            // 
            this.cboGPM_TotalHeat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGPM_TotalHeat.FormattingEnabled = true;
            this.cboGPM_TotalHeat.Items.AddRange(new object[] {
            "USGPM",
            "MBH"});
            this.cboGPM_TotalHeat.Location = new System.Drawing.Point(319, 132);
            this.cboGPM_TotalHeat.Name = "cboGPM_TotalHeat";
            this.cboGPM_TotalHeat.Size = new System.Drawing.Size(141, 21);
            this.cboGPM_TotalHeat.TabIndex = 15;
            this.cboGPM_TotalHeat.SelectedIndexChanged += new System.EventHandler(this.cboGPM_TotalHeat_SelectedIndexChanged);
            // 
            // lblUSGPM
            // 
            this.lblUSGPM.AutoSize = true;
            this.lblUSGPM.Location = new System.Drawing.Point(315, 136);
            this.lblUSGPM.Name = "lblUSGPM";
            this.lblUSGPM.Size = new System.Drawing.Size(51, 13);
            this.lblUSGPM.TabIndex = 97;
            this.lblUSGPM.Text = "sUSGPM";
            // 
            // cmdRunSelection
            // 
            this.cmdRunSelection.Image = ((System.Drawing.Image)(resources.GetObject("cmdRunSelection.Image")));
            this.cmdRunSelection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRunSelection.Location = new System.Drawing.Point(13, 331);
            this.cmdRunSelection.Name = "cmdRunSelection";
            this.cmdRunSelection.Size = new System.Drawing.Size(615, 25);
            this.cmdRunSelection.TabIndex = 6;
            this.cmdRunSelection.Text = "sRun Selection";
            this.cmdRunSelection.UseVisualStyleBackColor = true;
            this.cmdRunSelection.Click += new System.EventHandler(this.cmdRunSelection_Click);
            // 
            // lvFluidCooler
            // 
            this.lvFluidCooler.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colModel,
            this.colLLT,
            this.colLAT,
            this.colGPM,
            this.colTotalHeat,
            this.colPressureDrop,
            this.colVelocity});
            this.lvFluidCooler.FullRowSelect = true;
            this.lvFluidCooler.GridLines = true;
            this.lvFluidCooler.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvFluidCooler.Location = new System.Drawing.Point(13, 359);
            this.lvFluidCooler.MultiSelect = false;
            this.lvFluidCooler.Name = "lvFluidCooler";
            this.lvFluidCooler.Size = new System.Drawing.Size(612, 95);
            this.lvFluidCooler.TabIndex = 7;
            this.lvFluidCooler.UseCompatibleStateImageBehavior = false;
            this.lvFluidCooler.View = System.Windows.Forms.View.Details;
            this.lvFluidCooler.SelectedIndexChanged += new System.EventHandler(this.lvFluidCooler_SelectedIndexChanged);
            // 
            // colID
            // 
            this.colID.Text = "ID";
            this.colID.Width = 0;
            // 
            // colModel
            // 
            this.colModel.Text = "sModel";
            this.colModel.Width = 108;
            // 
            // colLLT
            // 
            this.colLLT.Text = "sLLT";
            // 
            // colLAT
            // 
            this.colLAT.Text = "sLAT";
            this.colLAT.Width = 51;
            // 
            // colGPM
            // 
            this.colGPM.Text = "sGPM";
            this.colGPM.Width = 53;
            // 
            // colTotalHeat
            // 
            this.colTotalHeat.Text = "sTotal Heat (MBH)";
            this.colTotalHeat.Width = 110;
            // 
            // colPressureDrop
            // 
            this.colPressureDrop.Text = "Pressure Drop (psi)";
            this.colPressureDrop.Width = 110;
            // 
            // colVelocity
            // 
            this.colVelocity.Text = "sVelocity (ft/sec)";
            this.colVelocity.Width = 99;
            // 
            // cboModel
            // 
            this.cboModel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModel.Enabled = false;
            this.cboModel.FormattingEnabled = true;
            this.cboModel.Location = new System.Drawing.Point(454, 29);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(174, 21);
            this.cboModel.TabIndex = 3;
            this.cboModel.SelectedIndexChanged += new System.EventHandler(this.cboModel_SelectedIndexChanged);
            this.cboModel.Leave += new System.EventHandler(this.cboModel_Leave);
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(375, 32);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(41, 13);
            this.lblModel.TabIndex = 82;
            this.lblModel.Text = "sModel";
            // 
            // cboFilter
            // 
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.FormattingEnabled = true;
            this.cboFilter.Items.AddRange(new object[] {
            "Selection",
            "Rating"});
            this.cboFilter.Location = new System.Drawing.Point(192, 29);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(174, 21);
            this.cboFilter.TabIndex = 2;
            this.cboFilter.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(135, 32);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(34, 13);
            this.lblFilter.TabIndex = 80;
            this.lblFilter.Text = "sFilter";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(488, 459);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(139, 25);
            this.cmdCancel.TabIndex = 10;
            this.cmdCancel.Text = "sCancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdAccept
            // 
            this.cmdAccept.Image = ((System.Drawing.Image)(resources.GetObject("cmdAccept.Image")));
            this.cmdAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAccept.Location = new System.Drawing.Point(13, 459);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(139, 25);
            this.cmdAccept.TabIndex = 8;
            this.cmdAccept.Text = "sAccept";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // cboLocation
            // 
            this.cboLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocation.FormattingEnabled = true;
            this.cboLocation.Location = new System.Drawing.Point(78, 52);
            this.cboLocation.MaxDropDownItems = 30;
            this.cboLocation.Name = "cboLocation";
            this.cboLocation.Size = new System.Drawing.Size(204, 21);
            this.cboLocation.TabIndex = 4;
            this.cboLocation.SelectedIndexChanged += new System.EventHandler(this.cboLocation_SelectedIndexChanged);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(10, 55);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(53, 13);
            this.lblLocation.TabIndex = 98;
            this.lblLocation.Text = "sLocation";
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(305, 460);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 9;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // FrmQuickFluidCooler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(639, 487);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cboLocation);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cboModel);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.cmdRunSelection);
            this.Controls.Add(this.lvFluidCooler);
            this.Controls.Add(this.cboFilter);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtTag);
            this.Controls.Add(this.lblTag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQuickFluidCooler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "sQuick Fluid Cooler";
            this.Load += new System.EventHandler(this.frmQuickFluidCooler_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmQuickFluidCooler_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThermalConductivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numViscosity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecificHeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPSI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numConcentration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numELT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLeavingLiquidTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUSGPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalHeat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.Label lblTag;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.NumericUpDown numPSI;
        private System.Windows.Forms.Label lblPSI;
        private System.Windows.Forms.Label lblAltitude;
        private System.Windows.Forms.NumericUpDown numTotalHeat;
        private System.Windows.Forms.NumericUpDown numUSGPM;
        private System.Windows.Forms.ComboBox cboGPM_TotalHeat;
        private System.Windows.Forms.Label lblELT;
        private System.Windows.Forms.NumericUpDown numLeavingLiquidTemperature;
        private System.Windows.Forms.Label lblEDB;
        private System.Windows.Forms.Label lblLeavingLiquidTemperature;
        private System.Windows.Forms.ComboBox cboFluidType;
        private System.Windows.Forms.Label lblConcentration;
        private System.Windows.Forms.NumericUpDown numConcentration;
        private System.Windows.Forms.NumericUpDown numEDB;
        private System.Windows.Forms.Label lblFluidType;
        private System.Windows.Forms.NumericUpDown numELT;
        private System.Windows.Forms.NumericUpDown numAltitude;
        private System.Windows.Forms.ComboBox cboVoltage;
        private System.Windows.Forms.Label lblVoltage;
        private System.Windows.Forms.ComboBox cboUnitType;
        private System.Windows.Forms.Label lblUnitType;
        private System.Windows.Forms.Button cmdRunSelection;
        private System.Windows.Forms.ListView lvFluidCooler;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colModel;
        private System.Windows.Forms.ComboBox cboModel;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.ComboBox cboFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.ColumnHeader colLLT;
        private System.Windows.Forms.ColumnHeader colGPM;
        private System.Windows.Forms.ColumnHeader colTotalHeat;
        private System.Windows.Forms.ColumnHeader colPressureDrop;
        private System.Windows.Forms.ColumnHeader colVelocity;
        private System.Windows.Forms.Button cmdAccept;
        private System.Windows.Forms.ColumnHeader colLAT;
        private System.Windows.Forms.ComboBox cboFanArrangement;
        private System.Windows.Forms.Label lblFanArrangement;
        private System.Windows.Forms.Label lblSpecificHeat;
        private System.Windows.Forms.NumericUpDown numSpecificHeat;
        private System.Windows.Forms.Label lblViscosity;
        private System.Windows.Forms.NumericUpDown numViscosity;
        private System.Windows.Forms.Label lblDensity;
        private System.Windows.Forms.NumericUpDown numDensity;
        private System.Windows.Forms.Label lblThermalConductivity;
        private System.Windows.Forms.NumericUpDown numThermalConductivity;
        private System.Windows.Forms.TextBox txtFluidTypeName;
        private System.Windows.Forms.Label lblFluidTypeName;
        private System.Windows.Forms.ComboBox cboAirFlowType;
        private System.Windows.Forms.Label lblAirFlowType;
        private System.Windows.Forms.ComboBox cboFPI;
        private System.Windows.Forms.Label lblFPI;
        private System.Windows.Forms.ComboBox cboLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.RadioButton radRatingLLT;
        private System.Windows.Forms.RadioButton radRatingGPM;
        private System.Windows.Forms.Label lblUSGPM;
        private System.Windows.Forms.Button btnHelp;
    }
}