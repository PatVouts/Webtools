namespace RefplusWebtools.QuickWaterEvaporator
{
    partial class FrmQuickWaterEvaporator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQuickWaterEvaporator));
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            this.cmdRunSelection = new System.Windows.Forms.Button();
            this.cboCoilCoating = new System.Windows.Forms.ComboBox();
            this.lblCoilCoating = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.lblTag = new System.Windows.Forms.Label();
            this.lblFluidType = new System.Windows.Forms.Label();
            this.cboFluidType = new System.Windows.Forms.ComboBox();
            this.lblVoltage = new System.Windows.Forms.Label();
            this.cboVoltage = new System.Windows.Forms.ComboBox();
            this.lblConcentration = new System.Windows.Forms.Label();
            this.numConcentration = new System.Windows.Forms.NumericUpDown();
            this.cboGPM_LeavingLiquidTemp = new System.Windows.Forms.ComboBox();
            this.cboNumberOfCircuits = new System.Windows.Forms.ComboBox();
            this.lblNumberOfCircuits = new System.Windows.Forms.Label();
            this.numLeavingLiquidTemperature = new System.Windows.Forms.NumericUpDown();
            this.numUSGPM = new System.Windows.Forms.NumericUpDown();
            this.numAltitude = new System.Windows.Forms.NumericUpDown();
            this.numELT = new System.Windows.Forms.NumericUpDown();
            this.lblELT = new System.Windows.Forms.Label();
            this.lblAltitude = new System.Windows.Forms.Label();
            this.lblEWB = new System.Windows.Forms.Label();
            this.lblEDB = new System.Windows.Forms.Label();
            this.numEWB = new System.Windows.Forms.NumericUpDown();
            this.numEDB = new System.Windows.Forms.NumericUpDown();
            this.lstResults = new GlacialComponents.Controls.GlacialList();
            this.cboFPI = new System.Windows.Forms.ComboBox();
            this.lblFPI = new System.Windows.Forms.Label();
            this.cboFinMaterial = new System.Windows.Forms.ComboBox();
            this.lblFinMaterial = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numConcentration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLeavingLiquidTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUSGPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numELT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEWB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEDB)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdRunSelection
            // 
            this.cmdRunSelection.Image = ((System.Drawing.Image)(resources.GetObject("cmdRunSelection.Image")));
            this.cmdRunSelection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRunSelection.Location = new System.Drawing.Point(12, 222);
            this.cmdRunSelection.Name = "cmdRunSelection";
            this.cmdRunSelection.Size = new System.Drawing.Size(617, 25);
            this.cmdRunSelection.TabIndex = 16;
            this.cmdRunSelection.Text = "sRun Selection";
            this.cmdRunSelection.UseVisualStyleBackColor = true;
            this.cmdRunSelection.Click += new System.EventHandler(this.cmdRunSelection_Click);
            // 
            // cboCoilCoating
            // 
            this.cboCoilCoating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCoilCoating.FormattingEnabled = true;
            this.cboCoilCoating.Location = new System.Drawing.Point(302, 492);
            this.cboCoilCoating.Name = "cboCoilCoating";
            this.cboCoilCoating.Size = new System.Drawing.Size(152, 21);
            this.cboCoilCoating.TabIndex = 18;
            this.cboCoilCoating.Visible = false;
            // 
            // lblCoilCoating
            // 
            this.lblCoilCoating.AutoSize = true;
            this.lblCoilCoating.Location = new System.Drawing.Point(186, 495);
            this.lblCoilCoating.Name = "lblCoilCoating";
            this.lblCoilCoating.Size = new System.Drawing.Size(68, 13);
            this.lblCoilCoating.TabIndex = 92;
            this.lblCoilCoating.Text = "sCoil Coating";
            this.lblCoilCoating.Visible = false;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(479, 488);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(150, 25);
            this.cmdCancel.TabIndex = 21;
            this.cmdCancel.Text = "sCancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdAccept
            // 
            this.cmdAccept.Image = ((System.Drawing.Image)(resources.GetObject("cmdAccept.Image")));
            this.cmdAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAccept.Location = new System.Drawing.Point(12, 488);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(150, 25);
            this.cmdAccept.TabIndex = 20;
            this.cmdAccept.Text = "sAccept";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // cboModel
            // 
            this.cboModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModel.FormattingEnabled = true;
            this.cboModel.Location = new System.Drawing.Point(125, 63);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(152, 21);
            this.cboModel.TabIndex = 2;
            this.cboModel.SelectedIndexChanged += new System.EventHandler(this.cboModel_SelectedIndexChanged);
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(9, 66);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(41, 13);
            this.lblModel.TabIndex = 91;
            this.lblModel.Text = "sModel";
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(125, 37);
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(152, 20);
            this.numQuantity.TabIndex = 1;
            this.numQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.ValueChanged += new System.EventHandler(this.numQuantity_ValueChanged);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(9, 39);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(51, 13);
            this.lblQuantity.TabIndex = 86;
            this.lblQuantity.Text = "sQuantity";
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(125, 11);
            this.txtTag.MaxLength = 50;
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(504, 20);
            this.txtTag.TabIndex = 0;
            // 
            // lblTag
            // 
            this.lblTag.AutoSize = true;
            this.lblTag.Location = new System.Drawing.Point(9, 14);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(31, 13);
            this.lblTag.TabIndex = 82;
            this.lblTag.Text = "sTag";
            // 
            // lblFluidType
            // 
            this.lblFluidType.AutoSize = true;
            this.lblFluidType.Location = new System.Drawing.Point(283, 39);
            this.lblFluidType.Name = "lblFluidType";
            this.lblFluidType.Size = new System.Drawing.Size(61, 13);
            this.lblFluidType.TabIndex = 4;
            this.lblFluidType.Text = "sFluid Type";
            // 
            // cboFluidType
            // 
            this.cboFluidType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFluidType.FormattingEnabled = true;
            this.cboFluidType.Items.AddRange(new object[] {
            "R-22",
            "R-502",
            "R-134A",
            "R-410A",
            "R-407C",
            "R-404A",
            "R-507"});
            this.cboFluidType.Location = new System.Drawing.Point(477, 36);
            this.cboFluidType.Name = "cboFluidType";
            this.cboFluidType.Size = new System.Drawing.Size(152, 21);
            this.cboFluidType.TabIndex = 7;
            this.cboFluidType.SelectedIndexChanged += new System.EventHandler(this.cboFluidType_SelectedIndexChanged);
            // 
            // lblVoltage
            // 
            this.lblVoltage.AutoSize = true;
            this.lblVoltage.Location = new System.Drawing.Point(9, 93);
            this.lblVoltage.Name = "lblVoltage";
            this.lblVoltage.Size = new System.Drawing.Size(48, 13);
            this.lblVoltage.TabIndex = 63;
            this.lblVoltage.Text = "sVoltage";
            // 
            // cboVoltage
            // 
            this.cboVoltage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVoltage.FormattingEnabled = true;
            this.cboVoltage.Location = new System.Drawing.Point(125, 90);
            this.cboVoltage.Name = "cboVoltage";
            this.cboVoltage.Size = new System.Drawing.Size(152, 21);
            this.cboVoltage.TabIndex = 3;
            // 
            // lblConcentration
            // 
            this.lblConcentration.AutoSize = true;
            this.lblConcentration.Location = new System.Drawing.Point(283, 65);
            this.lblConcentration.Name = "lblConcentration";
            this.lblConcentration.Size = new System.Drawing.Size(95, 13);
            this.lblConcentration.TabIndex = 98;
            this.lblConcentration.Text = "sConcentration (%)";
            // 
            // numConcentration
            // 
            this.numConcentration.Location = new System.Drawing.Point(477, 63);
            this.numConcentration.Name = "numConcentration";
            this.numConcentration.Size = new System.Drawing.Size(152, 20);
            this.numConcentration.TabIndex = 8;
            this.numConcentration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numConcentration.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numConcentration.ValueChanged += new System.EventHandler(this.numConcentration_ValueChanged);
            // 
            // cboGPM_LeavingLiquidTemp
            // 
            this.cboGPM_LeavingLiquidTemp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGPM_LeavingLiquidTemp.FormattingEnabled = true;
            this.cboGPM_LeavingLiquidTemp.Items.AddRange(new object[] {
            "USGPM",
            "Leaving Liquid Temp"});
            this.cboGPM_LeavingLiquidTemp.Location = new System.Drawing.Point(286, 114);
            this.cboGPM_LeavingLiquidTemp.Name = "cboGPM_LeavingLiquidTemp";
            this.cboGPM_LeavingLiquidTemp.Size = new System.Drawing.Size(151, 21);
            this.cboGPM_LeavingLiquidTemp.TabIndex = 10;
            this.cboGPM_LeavingLiquidTemp.SelectedIndexChanged += new System.EventHandler(this.cboGPM_LeavingLiquidTemp_SelectedIndexChanged);
            // 
            // cboNumberOfCircuits
            // 
            this.cboNumberOfCircuits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNumberOfCircuits.FormattingEnabled = true;
            this.cboNumberOfCircuits.Location = new System.Drawing.Point(477, 141);
            this.cboNumberOfCircuits.Name = "cboNumberOfCircuits";
            this.cboNumberOfCircuits.Size = new System.Drawing.Size(152, 21);
            this.cboNumberOfCircuits.TabIndex = 13;
            this.cboNumberOfCircuits.SelectedIndexChanged += new System.EventHandler(this.cboNumberOfCircuits_SelectedIndexChanged);
            // 
            // lblNumberOfCircuits
            // 
            this.lblNumberOfCircuits.AutoSize = true;
            this.lblNumberOfCircuits.Location = new System.Drawing.Point(283, 144);
            this.lblNumberOfCircuits.Name = "lblNumberOfCircuits";
            this.lblNumberOfCircuits.Size = new System.Drawing.Size(68, 13);
            this.lblNumberOfCircuits.TabIndex = 103;
            this.lblNumberOfCircuits.Text = "s# of Circuits";
            // 
            // numLeavingLiquidTemperature
            // 
            this.numLeavingLiquidTemperature.DecimalPlaces = 1;
            this.numLeavingLiquidTemperature.Location = new System.Drawing.Point(477, 115);
            this.numLeavingLiquidTemperature.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numLeavingLiquidTemperature.Name = "numLeavingLiquidTemperature";
            this.numLeavingLiquidTemperature.Size = new System.Drawing.Size(152, 20);
            this.numLeavingLiquidTemperature.TabIndex = 11;
            this.numLeavingLiquidTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numLeavingLiquidTemperature.Visible = false;
            this.numLeavingLiquidTemperature.ValueChanged += new System.EventHandler(this.numLeavingLiquidTemperature_ValueChanged);
            // 
            // numUSGPM
            // 
            this.numUSGPM.DecimalPlaces = 1;
            this.numUSGPM.Location = new System.Drawing.Point(477, 115);
            this.numUSGPM.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUSGPM.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numUSGPM.Name = "numUSGPM";
            this.numUSGPM.Size = new System.Drawing.Size(152, 20);
            this.numUSGPM.TabIndex = 12;
            this.numUSGPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUSGPM.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUSGPM.Visible = false;
            this.numUSGPM.ValueChanged += new System.EventHandler(this.numUSGPM_ValueChanged);
            // 
            // numAltitude
            // 
            this.numAltitude.Location = new System.Drawing.Point(125, 169);
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
            this.numAltitude.Size = new System.Drawing.Size(152, 20);
            this.numAltitude.TabIndex = 6;
            this.numAltitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numAltitude.ValueChanged += new System.EventHandler(this.numAltitude_ValueChanged);
            // 
            // numELT
            // 
            this.numELT.DecimalPlaces = 1;
            this.numELT.Location = new System.Drawing.Point(477, 89);
            this.numELT.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numELT.Minimum = new decimal(new int[] {
            70,
            0,
            0,
            -2147483648});
            this.numELT.Name = "numELT";
            this.numELT.Size = new System.Drawing.Size(152, 20);
            this.numELT.TabIndex = 9;
            this.numELT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numELT.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.numELT.ValueChanged += new System.EventHandler(this.numELT_ValueChanged);
            // 
            // lblELT
            // 
            this.lblELT.AutoSize = true;
            this.lblELT.Location = new System.Drawing.Point(283, 91);
            this.lblELT.Name = "lblELT";
            this.lblELT.Size = new System.Drawing.Size(164, 13);
            this.lblELT.TabIndex = 108;
            this.lblELT.Text = "sEntering Liquid Temperature (°F)";
            // 
            // lblAltitude
            // 
            this.lblAltitude.AutoSize = true;
            this.lblAltitude.Location = new System.Drawing.Point(9, 171);
            this.lblAltitude.Name = "lblAltitude";
            this.lblAltitude.Size = new System.Drawing.Size(62, 13);
            this.lblAltitude.TabIndex = 109;
            this.lblAltitude.Text = "sAltitude (ft)";
            // 
            // lblEWB
            // 
            this.lblEWB.AutoSize = true;
            this.lblEWB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEWB.Location = new System.Drawing.Point(9, 145);
            this.lblEWB.Name = "lblEWB";
            this.lblEWB.Size = new System.Drawing.Size(56, 13);
            this.lblEWB.TabIndex = 113;
            this.lblEWB.Text = "sEWB (°F)";
            this.lblEWB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEDB
            // 
            this.lblEDB.AutoSize = true;
            this.lblEDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEDB.Location = new System.Drawing.Point(9, 119);
            this.lblEDB.Name = "lblEDB";
            this.lblEDB.Size = new System.Drawing.Size(53, 13);
            this.lblEDB.TabIndex = 112;
            this.lblEDB.Text = "sEDB (°F)";
            this.lblEDB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numEWB
            // 
            this.numEWB.BackColor = System.Drawing.Color.White;
            this.numEWB.DecimalPlaces = 1;
            this.numEWB.Location = new System.Drawing.Point(125, 143);
            this.numEWB.Maximum = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.numEWB.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numEWB.Name = "numEWB";
            this.numEWB.Size = new System.Drawing.Size(152, 20);
            this.numEWB.TabIndex = 5;
            this.numEWB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numEWB.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numEWB.ValueChanged += new System.EventHandler(this.numEWB_ValueChanged);
            // 
            // numEDB
            // 
            this.numEDB.BackColor = System.Drawing.Color.White;
            this.numEDB.DecimalPlaces = 1;
            this.numEDB.Location = new System.Drawing.Point(125, 117);
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
            this.numEDB.Size = new System.Drawing.Size(152, 20);
            this.numEDB.TabIndex = 4;
            this.numEDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numEDB.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numEDB.ValueChanged += new System.EventHandler(this.numEDB_ValueChanged);
            // 
            // lstResults
            // 
            this.lstResults.AllowColumnResize = false;
            this.lstResults.AllowMultiselect = false;
            this.lstResults.AlternateBackground = System.Drawing.Color.LightGray;
            this.lstResults.AlternatingColors = true;
            this.lstResults.AutoHeight = false;
            this.lstResults.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lstResults.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1";
            glColumn1.NumericSort = false;
            glColumn1.Text = "ID";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 300;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column1x";
            glColumn2.NumericSort = false;
            glColumn2.Text = "sModel";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn2.Width = 200;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Column2";
            glColumn3.NumericSort = false;
            glColumn3.Text = "sCapacity";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn3.Width = 80;
            this.lstResults.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3});
            this.lstResults.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lstResults.FullRowSelect = true;
            this.lstResults.GridColor = System.Drawing.Color.LightGray;
            this.lstResults.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lstResults.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lstResults.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lstResults.HeaderHeight = 0;
            this.lstResults.HeaderVisible = false;
            this.lstResults.HeaderWordWrap = false;
            this.lstResults.HotColumnTracking = false;
            this.lstResults.HotItemTracking = false;
            this.lstResults.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lstResults.HoverEvents = false;
            this.lstResults.HoverTime = 1;
            this.lstResults.ImageList = null;
            this.lstResults.ItemHeight = 18;
            this.lstResults.ItemWordWrap = false;
            this.lstResults.Location = new System.Drawing.Point(12, 253);
            this.lstResults.Name = "lstResults";
            this.lstResults.Selectable = false;
            this.lstResults.SelectedTextColor = System.Drawing.Color.White;
            this.lstResults.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lstResults.ShowBorder = true;
            this.lstResults.ShowFocusRect = true;
            this.lstResults.Size = new System.Drawing.Size(617, 229);
            this.lstResults.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lstResults.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lstResults.TabIndex = 17;
            this.lstResults.Text = "glacialList1";
            // 
            // cboFPI
            // 
            this.cboFPI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFPI.FormattingEnabled = true;
            this.cboFPI.Items.AddRange(new object[] {
            "AUTOMATIC",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96"});
            this.cboFPI.Location = new System.Drawing.Point(477, 168);
            this.cboFPI.Name = "cboFPI";
            this.cboFPI.Size = new System.Drawing.Size(152, 21);
            this.cboFPI.TabIndex = 15;
            this.cboFPI.SelectedIndexChanged += new System.EventHandler(this.cboFPI_SelectedIndexChanged);
            // 
            // lblFPI
            // 
            this.lblFPI.AutoSize = true;
            this.lblFPI.Location = new System.Drawing.Point(283, 171);
            this.lblFPI.Name = "lblFPI";
            this.lblFPI.Size = new System.Drawing.Size(28, 13);
            this.lblFPI.TabIndex = 117;
            this.lblFPI.Text = "sFPI";
            // 
            // cboFinMaterial
            // 
            this.cboFinMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFinMaterial.FormattingEnabled = true;
            this.cboFinMaterial.Location = new System.Drawing.Point(477, 195);
            this.cboFinMaterial.Name = "cboFinMaterial";
            this.cboFinMaterial.Size = new System.Drawing.Size(152, 21);
            this.cboFinMaterial.TabIndex = 118;
            this.cboFinMaterial.SelectedIndexChanged += new System.EventHandler(this.cboFinMaterial_SelectedIndexChanged);
            // 
            // lblFinMaterial
            // 
            this.lblFinMaterial.AutoSize = true;
            this.lblFinMaterial.Location = new System.Drawing.Point(283, 198);
            this.lblFinMaterial.Name = "lblFinMaterial";
            this.lblFinMaterial.Size = new System.Drawing.Size(66, 13);
            this.lblFinMaterial.TabIndex = 119;
            this.lblFinMaterial.Text = "sFin Material";
            // 
            // frmQuickWaterEvaporator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(641, 521);
            this.Controls.Add(this.cboFinMaterial);
            this.Controls.Add(this.lblFinMaterial);
            this.Controls.Add(this.cboFPI);
            this.Controls.Add(this.lblFPI);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.lblEWB);
            this.Controls.Add(this.lblEDB);
            this.Controls.Add(this.numEWB);
            this.Controls.Add(this.numEDB);
            this.Controls.Add(this.numAltitude);
            this.Controls.Add(this.numELT);
            this.Controls.Add(this.lblELT);
            this.Controls.Add(this.lblAltitude);
            this.Controls.Add(this.cboGPM_LeavingLiquidTemp);
            this.Controls.Add(this.cboNumberOfCircuits);
            this.Controls.Add(this.lblNumberOfCircuits);
            this.Controls.Add(this.numLeavingLiquidTemperature);
            this.Controls.Add(this.numUSGPM);
            this.Controls.Add(this.lblConcentration);
            this.Controls.Add(this.numConcentration);
            this.Controls.Add(this.cboFluidType);
            this.Controls.Add(this.lblFluidType);
            this.Controls.Add(this.cboVoltage);
            this.Controls.Add(this.lblVoltage);
            this.Controls.Add(this.cmdRunSelection);
            this.Controls.Add(this.cboCoilCoating);
            this.Controls.Add(this.lblCoilCoating);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.cboModel);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtTag);
            this.Controls.Add(this.lblTag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQuickWaterEvaporator";
            this.Text = "sQuick Water Evaporator";
            this.Load += new System.EventHandler(this.frmQuickWaterEvaporator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numConcentration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLeavingLiquidTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUSGPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numELT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEWB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEDB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdRunSelection;
        private System.Windows.Forms.ComboBox cboCoilCoating;
        private System.Windows.Forms.Label lblCoilCoating;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdAccept;
        private System.Windows.Forms.ComboBox cboModel;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.Label lblTag;
        private System.Windows.Forms.Label lblFluidType;
        private System.Windows.Forms.ComboBox cboFluidType;
        private System.Windows.Forms.Label lblVoltage;
        private System.Windows.Forms.ComboBox cboVoltage;
        private System.Windows.Forms.Label lblConcentration;
        private System.Windows.Forms.NumericUpDown numConcentration;
        private System.Windows.Forms.ComboBox cboGPM_LeavingLiquidTemp;
        private System.Windows.Forms.ComboBox cboNumberOfCircuits;
        private System.Windows.Forms.Label lblNumberOfCircuits;
        private System.Windows.Forms.NumericUpDown numLeavingLiquidTemperature;
        private System.Windows.Forms.NumericUpDown numUSGPM;
        private System.Windows.Forms.NumericUpDown numAltitude;
        private System.Windows.Forms.NumericUpDown numELT;
        private System.Windows.Forms.Label lblELT;
        private System.Windows.Forms.Label lblAltitude;
        private System.Windows.Forms.Label lblEWB;
        private System.Windows.Forms.Label lblEDB;
        private System.Windows.Forms.NumericUpDown numEWB;
        private System.Windows.Forms.NumericUpDown numEDB;
        private GlacialComponents.Controls.GlacialList lstResults;
        private System.Windows.Forms.ComboBox cboFPI;
        private System.Windows.Forms.Label lblFPI;
        private System.Windows.Forms.ComboBox cboFinMaterial;
        private System.Windows.Forms.Label lblFinMaterial;
    }
}