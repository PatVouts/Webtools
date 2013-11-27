namespace RefplusWebtools.QuickHeatPipe
{
    partial class FrmQuickHeatPipe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQuickHeatPipe));
            this.numFinLength = new System.Windows.Forms.NumericUpDown();
            this.lblFinLength = new System.Windows.Forms.Label();
            this.numOADB = new System.Windows.Forms.NumericUpDown();
            this.lblOADB = new System.Windows.Forms.Label();
            this.numNumberOfRows = new System.Windows.Forms.NumericUpDown();
            this.lblNumberOfRows = new System.Windows.Forms.Label();
            this.lblFPI = new System.Windows.Forms.Label();
            this.numRADB = new System.Windows.Forms.NumericUpDown();
            this.lblRADB = new System.Windows.Forms.Label();
            this.numOARH = new System.Windows.Forms.NumericUpDown();
            this.lblOARH = new System.Windows.Forms.Label();
            this.numDefrostSetPoint = new System.Windows.Forms.NumericUpDown();
            this.lblDefrostSetPoint = new System.Windows.Forms.Label();
            this.lblSymmetrical = new System.Windows.Forms.Label();
            this.numAltitude = new System.Windows.Forms.NumericUpDown();
            this.lblAltitude = new System.Windows.Forms.Label();
            this.lblRAWB = new System.Windows.Forms.Label();
            this.numOAWB = new System.Windows.Forms.NumericUpDown();
            this.lblOAWB = new System.Windows.Forms.Label();
            this.cboSymmetrical = new System.Windows.Forms.ComboBox();
            this.lblShape = new System.Windows.Forms.Label();
            this.numAtmosphericPressure = new System.Windows.Forms.NumericUpDown();
            this.lblAtmosphericPressure = new System.Windows.Forms.Label();
            this.lblFlowType = new System.Windows.Forms.Label();
            this.numRAWB = new System.Windows.Forms.NumericUpDown();
            this.cboShape = new System.Windows.Forms.ComboBox();
            this.numTiltAngle = new System.Windows.Forms.NumericUpDown();
            this.lblTiltAngle = new System.Windows.Forms.Label();
            this.cboFlowType = new System.Windows.Forms.ComboBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.numAirFlowExhaust = new System.Windows.Forms.NumericUpDown();
            this.lblAirFlowExhaust = new System.Windows.Forms.Label();
            this.numAirFlowSupply = new System.Windows.Forms.NumericUpDown();
            this.lblAirFlowSupply = new System.Windows.Forms.Label();
            this.numRARH = new System.Windows.Forms.NumericUpDown();
            this.lblRARH = new System.Windows.Forms.Label();
            this.cboFinHeight = new System.Windows.Forms.ComboBox();
            this.lblFinHeight = new System.Windows.Forms.Label();
            this.cboFinType = new System.Windows.Forms.ComboBox();
            this.lblFinType = new System.Windows.Forms.Label();
            this.cboFPI = new System.Windows.Forms.ComboBox();
            this.numRARHWinter = new System.Windows.Forms.NumericUpDown();
            this.numOAWBWinter = new System.Windows.Forms.NumericUpDown();
            this.numRAWBWinter = new System.Windows.Forms.NumericUpDown();
            this.numOARHWinter = new System.Windows.Forms.NumericUpDown();
            this.numRADBWinter = new System.Windows.Forms.NumericUpDown();
            this.numOADBWinter = new System.Windows.Forms.NumericUpDown();
            this.lblSummer = new System.Windows.Forms.Label();
            this.lblWinter = new System.Windows.Forms.Label();
            this.lblTag = new System.Windows.Forms.Label();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numFinLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOADB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRADB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOARH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDefrostSetPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOAWB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAtmosphericPressure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRAWB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTiltAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAirFlowExhaust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAirFlowSupply)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRARH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRARHWinter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOAWBWinter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRAWBWinter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOARHWinter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRADBWinter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOADBWinter)).BeginInit();
            this.SuspendLayout();
            // 
            // numFinLength
            // 
            this.numFinLength.DecimalPlaces = 2;
            this.numFinLength.Location = new System.Drawing.Point(502, 65);
            this.numFinLength.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numFinLength.Name = "numFinLength";
            this.numFinLength.Size = new System.Drawing.Size(142, 20);
            this.numFinLength.TabIndex = 19;
            this.numFinLength.Value = new decimal(new int[] {
            84,
            0,
            0,
            0});
            this.numFinLength.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblFinLength
            // 
            this.lblFinLength.AutoSize = true;
            this.lblFinLength.Location = new System.Drawing.Point(340, 67);
            this.lblFinLength.Name = "lblFinLength";
            this.lblFinLength.Size = new System.Drawing.Size(62, 13);
            this.lblFinLength.TabIndex = 2;
            this.lblFinLength.Text = "sFin Length";
            // 
            // numOADB
            // 
            this.numOADB.DecimalPlaces = 2;
            this.numOADB.Location = new System.Drawing.Point(174, 153);
            this.numOADB.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numOADB.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numOADB.Name = "numOADB";
            this.numOADB.Size = new System.Drawing.Size(70, 20);
            this.numOADB.TabIndex = 5;
            this.numOADB.ValueChanged += new System.EventHandler(this.numOADB_ValueChanged);
            this.numOADB.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblOADB
            // 
            this.lblOADB.AutoSize = true;
            this.lblOADB.Location = new System.Drawing.Point(12, 155);
            this.lblOADB.Name = "lblOADB";
            this.lblOADB.Size = new System.Drawing.Size(106, 13);
            this.lblOADB.TabIndex = 10;
            this.lblOADB.Text = "sOutside Air Dry Bulb";
            // 
            // numNumberOfRows
            // 
            this.numNumberOfRows.DecimalPlaces = 2;
            this.numNumberOfRows.Location = new System.Drawing.Point(502, 117);
            this.numNumberOfRows.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numNumberOfRows.Name = "numNumberOfRows";
            this.numNumberOfRows.Size = new System.Drawing.Size(142, 20);
            this.numNumberOfRows.TabIndex = 21;
            this.numNumberOfRows.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numNumberOfRows.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblNumberOfRows
            // 
            this.lblNumberOfRows.AutoSize = true;
            this.lblNumberOfRows.Location = new System.Drawing.Point(340, 119);
            this.lblNumberOfRows.Name = "lblNumberOfRows";
            this.lblNumberOfRows.Size = new System.Drawing.Size(49, 13);
            this.lblNumberOfRows.TabIndex = 8;
            this.lblNumberOfRows.Text = "s# Rows";
            // 
            // lblFPI
            // 
            this.lblFPI.AutoSize = true;
            this.lblFPI.Location = new System.Drawing.Point(340, 93);
            this.lblFPI.Name = "lblFPI";
            this.lblFPI.Size = new System.Drawing.Size(57, 13);
            this.lblFPI.TabIndex = 6;
            this.lblFPI.Text = "sFins/Inch";
            // 
            // numRADB
            // 
            this.numRADB.DecimalPlaces = 2;
            this.numRADB.Location = new System.Drawing.Point(174, 231);
            this.numRADB.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numRADB.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numRADB.Name = "numRADB";
            this.numRADB.Size = new System.Drawing.Size(70, 20);
            this.numRADB.TabIndex = 8;
            this.numRADB.ValueChanged += new System.EventHandler(this.numRADB_ValueChanged);
            this.numRADB.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblRADB
            // 
            this.lblRADB.AutoSize = true;
            this.lblRADB.Location = new System.Drawing.Point(12, 233);
            this.lblRADB.Name = "lblRADB";
            this.lblRADB.Size = new System.Drawing.Size(102, 13);
            this.lblRADB.TabIndex = 12;
            this.lblRADB.Text = "sReturn Air Dry Bulb";
            // 
            // numOARH
            // 
            this.numOARH.DecimalPlaces = 2;
            this.numOARH.Location = new System.Drawing.Point(174, 205);
            this.numOARH.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numOARH.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numOARH.Name = "numOARH";
            this.numOARH.Size = new System.Drawing.Size(70, 20);
            this.numOARH.TabIndex = 7;
            this.numOARH.ValueChanged += new System.EventHandler(this.numOARH_ValueChanged);
            this.numOARH.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblOARH
            // 
            this.lblOARH.AutoSize = true;
            this.lblOARH.Location = new System.Drawing.Point(12, 207);
            this.lblOARH.Name = "lblOARH";
            this.lblOARH.Size = new System.Drawing.Size(148, 13);
            this.lblOARH.TabIndex = 14;
            this.lblOARH.Text = "sOutside Air Relative Humidity";
            // 
            // numDefrostSetPoint
            // 
            this.numDefrostSetPoint.DecimalPlaces = 2;
            this.numDefrostSetPoint.Location = new System.Drawing.Point(502, 247);
            this.numDefrostSetPoint.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numDefrostSetPoint.Name = "numDefrostSetPoint";
            this.numDefrostSetPoint.Size = new System.Drawing.Size(142, 20);
            this.numDefrostSetPoint.TabIndex = 26;
            this.numDefrostSetPoint.Value = new decimal(new int[] {
            38,
            0,
            0,
            0});
            this.numDefrostSetPoint.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblDefrostSetPoint
            // 
            this.lblDefrostSetPoint.AutoSize = true;
            this.lblDefrostSetPoint.Location = new System.Drawing.Point(340, 249);
            this.lblDefrostSetPoint.Name = "lblDefrostSetPoint";
            this.lblDefrostSetPoint.Size = new System.Drawing.Size(92, 13);
            this.lblDefrostSetPoint.TabIndex = 18;
            this.lblDefrostSetPoint.Text = "sDefrost Set Point";
            // 
            // lblSymmetrical
            // 
            this.lblSymmetrical.AutoSize = true;
            this.lblSymmetrical.Location = new System.Drawing.Point(12, 89);
            this.lblSymmetrical.Name = "lblSymmetrical";
            this.lblSymmetrical.Size = new System.Drawing.Size(68, 13);
            this.lblSymmetrical.TabIndex = 20;
            this.lblSymmetrical.Text = "sSymmetrical";
            // 
            // numAltitude
            // 
            this.numAltitude.DecimalPlaces = 2;
            this.numAltitude.Location = new System.Drawing.Point(174, 114);
            this.numAltitude.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numAltitude.Name = "numAltitude";
            this.numAltitude.Size = new System.Drawing.Size(142, 20);
            this.numAltitude.TabIndex = 4;
            this.numAltitude.ValueChanged += new System.EventHandler(this.numAltitude_ValueChanged);
            this.numAltitude.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblAltitude
            // 
            this.lblAltitude.AutoSize = true;
            this.lblAltitude.Location = new System.Drawing.Point(12, 116);
            this.lblAltitude.Name = "lblAltitude";
            this.lblAltitude.Size = new System.Drawing.Size(47, 13);
            this.lblAltitude.TabIndex = 23;
            this.lblAltitude.Text = "sAltitude";
            // 
            // lblRAWB
            // 
            this.lblRAWB.AutoSize = true;
            this.lblRAWB.Location = new System.Drawing.Point(12, 259);
            this.lblRAWB.Name = "lblRAWB";
            this.lblRAWB.Size = new System.Drawing.Size(106, 13);
            this.lblRAWB.TabIndex = 25;
            this.lblRAWB.Text = "sReturn Air Wet Bulb";
            // 
            // numOAWB
            // 
            this.numOAWB.DecimalPlaces = 2;
            this.numOAWB.Location = new System.Drawing.Point(174, 179);
            this.numOAWB.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numOAWB.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numOAWB.Name = "numOAWB";
            this.numOAWB.Size = new System.Drawing.Size(70, 20);
            this.numOAWB.TabIndex = 6;
            this.numOAWB.ValueChanged += new System.EventHandler(this.numOAWB_ValueChanged);
            this.numOAWB.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblOAWB
            // 
            this.lblOAWB.AutoSize = true;
            this.lblOAWB.Location = new System.Drawing.Point(12, 181);
            this.lblOAWB.Name = "lblOAWB";
            this.lblOAWB.Size = new System.Drawing.Size(110, 13);
            this.lblOAWB.TabIndex = 27;
            this.lblOAWB.Text = "sOutside Air Wet Bulb";
            // 
            // cboSymmetrical
            // 
            this.cboSymmetrical.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSymmetrical.FormattingEnabled = true;
            this.cboSymmetrical.Location = new System.Drawing.Point(174, 87);
            this.cboSymmetrical.Name = "cboSymmetrical";
            this.cboSymmetrical.Size = new System.Drawing.Size(142, 21);
            this.cboSymmetrical.TabIndex = 3;
            // 
            // lblShape
            // 
            this.lblShape.AutoSize = true;
            this.lblShape.Location = new System.Drawing.Point(340, 145);
            this.lblShape.Name = "lblShape";
            this.lblShape.Size = new System.Drawing.Size(43, 13);
            this.lblShape.TabIndex = 30;
            this.lblShape.Text = "sShape";
            // 
            // numAtmosphericPressure
            // 
            this.numAtmosphericPressure.DecimalPlaces = 2;
            this.numAtmosphericPressure.Location = new System.Drawing.Point(502, 169);
            this.numAtmosphericPressure.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numAtmosphericPressure.Name = "numAtmosphericPressure";
            this.numAtmosphericPressure.Size = new System.Drawing.Size(142, 20);
            this.numAtmosphericPressure.TabIndex = 23;
            this.numAtmosphericPressure.Value = new decimal(new int[] {
            101,
            0,
            0,
            0});
            this.numAtmosphericPressure.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblAtmosphericPressure
            // 
            this.lblAtmosphericPressure.AutoSize = true;
            this.lblAtmosphericPressure.Location = new System.Drawing.Point(340, 171);
            this.lblAtmosphericPressure.Name = "lblAtmosphericPressure";
            this.lblAtmosphericPressure.Size = new System.Drawing.Size(114, 13);
            this.lblAtmosphericPressure.TabIndex = 32;
            this.lblAtmosphericPressure.Text = "sAtmospheric Pressure";
            // 
            // lblFlowType
            // 
            this.lblFlowType.AutoSize = true;
            this.lblFlowType.Location = new System.Drawing.Point(340, 197);
            this.lblFlowType.Name = "lblFlowType";
            this.lblFlowType.Size = new System.Drawing.Size(61, 13);
            this.lblFlowType.TabIndex = 34;
            this.lblFlowType.Text = "sFlow Type";
            // 
            // numRAWB
            // 
            this.numRAWB.DecimalPlaces = 2;
            this.numRAWB.Location = new System.Drawing.Point(174, 257);
            this.numRAWB.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numRAWB.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numRAWB.Name = "numRAWB";
            this.numRAWB.Size = new System.Drawing.Size(70, 20);
            this.numRAWB.TabIndex = 9;
            this.numRAWB.ValueChanged += new System.EventHandler(this.numRAWB_ValueChanged);
            this.numRAWB.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // cboShape
            // 
            this.cboShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShape.FormattingEnabled = true;
            this.cboShape.Location = new System.Drawing.Point(502, 143);
            this.cboShape.Name = "cboShape";
            this.cboShape.Size = new System.Drawing.Size(142, 21);
            this.cboShape.TabIndex = 22;
            // 
            // numTiltAngle
            // 
            this.numTiltAngle.DecimalPlaces = 2;
            this.numTiltAngle.Location = new System.Drawing.Point(502, 221);
            this.numTiltAngle.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numTiltAngle.Name = "numTiltAngle";
            this.numTiltAngle.Size = new System.Drawing.Size(142, 20);
            this.numTiltAngle.TabIndex = 25;
            this.numTiltAngle.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblTiltAngle
            // 
            this.lblTiltAngle.AutoSize = true;
            this.lblTiltAngle.Location = new System.Drawing.Point(340, 223);
            this.lblTiltAngle.Name = "lblTiltAngle";
            this.lblTiltAngle.Size = new System.Drawing.Size(56, 13);
            this.lblTiltAngle.TabIndex = 37;
            this.lblTiltAngle.Text = "sTilt Angle";
            // 
            // cboFlowType
            // 
            this.cboFlowType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFlowType.FormattingEnabled = true;
            this.cboFlowType.Location = new System.Drawing.Point(502, 195);
            this.cboFlowType.Name = "cboFlowType";
            this.cboFlowType.Size = new System.Drawing.Size(142, 21);
            this.cboFlowType.TabIndex = 24;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(501, 309);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(143, 25);
            this.cmdCancel.TabIndex = 29;
            this.cmdCancel.Text = "sCancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdAccept
            // 
            this.cmdAccept.Image = ((System.Drawing.Image)(resources.GetObject("cmdAccept.Image")));
            this.cmdAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAccept.Location = new System.Drawing.Point(15, 309);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(142, 25);
            this.cmdAccept.TabIndex = 27;
            this.cmdAccept.Text = "sAccept";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // numAirFlowExhaust
            // 
            this.numAirFlowExhaust.DecimalPlaces = 2;
            this.numAirFlowExhaust.Location = new System.Drawing.Point(174, 61);
            this.numAirFlowExhaust.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numAirFlowExhaust.Name = "numAirFlowExhaust";
            this.numAirFlowExhaust.Size = new System.Drawing.Size(142, 20);
            this.numAirFlowExhaust.TabIndex = 2;
            this.numAirFlowExhaust.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numAirFlowExhaust.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblAirFlowExhaust
            // 
            this.lblAirFlowExhaust.AutoSize = true;
            this.lblAirFlowExhaust.Location = new System.Drawing.Point(12, 63);
            this.lblAirFlowExhaust.Name = "lblAirFlowExhaust";
            this.lblAirFlowExhaust.Size = new System.Drawing.Size(90, 13);
            this.lblAirFlowExhaust.TabIndex = 49;
            this.lblAirFlowExhaust.Text = "sAir Flow Exhaust";
            // 
            // numAirFlowSupply
            // 
            this.numAirFlowSupply.DecimalPlaces = 2;
            this.numAirFlowSupply.Location = new System.Drawing.Point(174, 35);
            this.numAirFlowSupply.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numAirFlowSupply.Name = "numAirFlowSupply";
            this.numAirFlowSupply.Size = new System.Drawing.Size(142, 20);
            this.numAirFlowSupply.TabIndex = 1;
            this.numAirFlowSupply.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numAirFlowSupply.ValueChanged += new System.EventHandler(this.numAirFlowSupply_ValueChanged);
            this.numAirFlowSupply.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblAirFlowSupply
            // 
            this.lblAirFlowSupply.AutoSize = true;
            this.lblAirFlowSupply.Location = new System.Drawing.Point(12, 37);
            this.lblAirFlowSupply.Name = "lblAirFlowSupply";
            this.lblAirFlowSupply.Size = new System.Drawing.Size(84, 13);
            this.lblAirFlowSupply.TabIndex = 51;
            this.lblAirFlowSupply.Text = "sAir Flow Supply";
            // 
            // numRARH
            // 
            this.numRARH.DecimalPlaces = 2;
            this.numRARH.Location = new System.Drawing.Point(174, 283);
            this.numRARH.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numRARH.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numRARH.Name = "numRARH";
            this.numRARH.Size = new System.Drawing.Size(70, 20);
            this.numRARH.TabIndex = 10;
            this.numRARH.ValueChanged += new System.EventHandler(this.numRARH_ValueChanged);
            this.numRARH.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblRARH
            // 
            this.lblRARH.AutoSize = true;
            this.lblRARH.Location = new System.Drawing.Point(12, 285);
            this.lblRARH.Name = "lblRARH";
            this.lblRARH.Size = new System.Drawing.Size(144, 13);
            this.lblRARH.TabIndex = 53;
            this.lblRARH.Text = "sReturn Air Relative Humidity";
            // 
            // cboFinHeight
            // 
            this.cboFinHeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFinHeight.FormattingEnabled = true;
            this.cboFinHeight.Location = new System.Drawing.Point(502, 39);
            this.cboFinHeight.Name = "cboFinHeight";
            this.cboFinHeight.Size = new System.Drawing.Size(142, 21);
            this.cboFinHeight.TabIndex = 18;
            // 
            // lblFinHeight
            // 
            this.lblFinHeight.AutoSize = true;
            this.lblFinHeight.Location = new System.Drawing.Point(340, 42);
            this.lblFinHeight.Name = "lblFinHeight";
            this.lblFinHeight.Size = new System.Drawing.Size(60, 13);
            this.lblFinHeight.TabIndex = 58;
            this.lblFinHeight.Text = "sFin Height";
            // 
            // cboFinType
            // 
            this.cboFinType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFinType.FormattingEnabled = true;
            this.cboFinType.Location = new System.Drawing.Point(502, 12);
            this.cboFinType.Name = "cboFinType";
            this.cboFinType.Size = new System.Drawing.Size(142, 21);
            this.cboFinType.TabIndex = 17;
            this.cboFinType.SelectedIndexChanged += new System.EventHandler(this.cboFinType_SelectedIndexChanged);
            // 
            // lblFinType
            // 
            this.lblFinType.AutoSize = true;
            this.lblFinType.Location = new System.Drawing.Point(340, 15);
            this.lblFinType.Name = "lblFinType";
            this.lblFinType.Size = new System.Drawing.Size(53, 13);
            this.lblFinType.TabIndex = 57;
            this.lblFinType.Text = "sFin Type";
            // 
            // cboFPI
            // 
            this.cboFPI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFPI.FormattingEnabled = true;
            this.cboFPI.Location = new System.Drawing.Point(501, 91);
            this.cboFPI.Name = "cboFPI";
            this.cboFPI.Size = new System.Drawing.Size(142, 21);
            this.cboFPI.TabIndex = 20;
            this.cboFPI.SelectedIndexChanged += new System.EventHandler(this.cboFPI_SelectedIndexChanged);
            // 
            // numRARHWinter
            // 
            this.numRARHWinter.DecimalPlaces = 2;
            this.numRARHWinter.Location = new System.Drawing.Point(246, 283);
            this.numRARHWinter.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numRARHWinter.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numRARHWinter.Name = "numRARHWinter";
            this.numRARHWinter.Size = new System.Drawing.Size(70, 20);
            this.numRARHWinter.TabIndex = 16;
            this.numRARHWinter.ValueChanged += new System.EventHandler(this.numRARHWinter_ValueChanged);
            this.numRARHWinter.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // numOAWBWinter
            // 
            this.numOAWBWinter.DecimalPlaces = 2;
            this.numOAWBWinter.Location = new System.Drawing.Point(246, 179);
            this.numOAWBWinter.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numOAWBWinter.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numOAWBWinter.Name = "numOAWBWinter";
            this.numOAWBWinter.Size = new System.Drawing.Size(70, 20);
            this.numOAWBWinter.TabIndex = 12;
            this.numOAWBWinter.ValueChanged += new System.EventHandler(this.numOAWBWinter_ValueChanged);
            this.numOAWBWinter.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // numRAWBWinter
            // 
            this.numRAWBWinter.DecimalPlaces = 2;
            this.numRAWBWinter.Location = new System.Drawing.Point(246, 257);
            this.numRAWBWinter.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numRAWBWinter.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numRAWBWinter.Name = "numRAWBWinter";
            this.numRAWBWinter.Size = new System.Drawing.Size(70, 20);
            this.numRAWBWinter.TabIndex = 15;
            this.numRAWBWinter.ValueChanged += new System.EventHandler(this.numRAWBWinter_ValueChanged);
            this.numRAWBWinter.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // numOARHWinter
            // 
            this.numOARHWinter.DecimalPlaces = 2;
            this.numOARHWinter.Location = new System.Drawing.Point(246, 205);
            this.numOARHWinter.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numOARHWinter.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numOARHWinter.Name = "numOARHWinter";
            this.numOARHWinter.Size = new System.Drawing.Size(70, 20);
            this.numOARHWinter.TabIndex = 13;
            this.numOARHWinter.ValueChanged += new System.EventHandler(this.numOARHWinter_ValueChanged);
            this.numOARHWinter.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // numRADBWinter
            // 
            this.numRADBWinter.DecimalPlaces = 2;
            this.numRADBWinter.Location = new System.Drawing.Point(246, 231);
            this.numRADBWinter.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numRADBWinter.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numRADBWinter.Name = "numRADBWinter";
            this.numRADBWinter.Size = new System.Drawing.Size(70, 20);
            this.numRADBWinter.TabIndex = 14;
            this.numRADBWinter.ValueChanged += new System.EventHandler(this.numRADBWinter_ValueChanged);
            this.numRADBWinter.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // numOADBWinter
            // 
            this.numOADBWinter.DecimalPlaces = 2;
            this.numOADBWinter.Location = new System.Drawing.Point(246, 153);
            this.numOADBWinter.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numOADBWinter.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numOADBWinter.Name = "numOADBWinter";
            this.numOADBWinter.Size = new System.Drawing.Size(70, 20);
            this.numOADBWinter.TabIndex = 11;
            this.numOADBWinter.ValueChanged += new System.EventHandler(this.numOADBWinter_ValueChanged);
            this.numOADBWinter.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblSummer
            // 
            this.lblSummer.AutoSize = true;
            this.lblSummer.Location = new System.Drawing.Point(171, 137);
            this.lblSummer.Name = "lblSummer";
            this.lblSummer.Size = new System.Drawing.Size(50, 13);
            this.lblSummer.TabIndex = 65;
            this.lblSummer.Text = "sSummer";
            // 
            // lblWinter
            // 
            this.lblWinter.AutoSize = true;
            this.lblWinter.Location = new System.Drawing.Point(243, 137);
            this.lblWinter.Name = "lblWinter";
            this.lblWinter.Size = new System.Drawing.Size(43, 13);
            this.lblWinter.TabIndex = 66;
            this.lblWinter.Text = "sWinter";
            // 
            // lblTag
            // 
            this.lblTag.AutoSize = true;
            this.lblTag.Location = new System.Drawing.Point(12, 12);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(31, 13);
            this.lblTag.TabIndex = 67;
            this.lblTag.Text = "sTag";
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(174, 9);
            this.txtTag.MaxLength = 50;
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(142, 20);
            this.txtTag.TabIndex = 0;
            this.txtTag.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(315, 310);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 28;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmQuickHeatPipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(656, 338);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.txtTag);
            this.Controls.Add(this.lblTag);
            this.Controls.Add(this.lblWinter);
            this.Controls.Add(this.lblSummer);
            this.Controls.Add(this.numRARHWinter);
            this.Controls.Add(this.numOAWBWinter);
            this.Controls.Add(this.numRAWBWinter);
            this.Controls.Add(this.numOARHWinter);
            this.Controls.Add(this.numRADBWinter);
            this.Controls.Add(this.numOADBWinter);
            this.Controls.Add(this.cboFPI);
            this.Controls.Add(this.cboFinHeight);
            this.Controls.Add(this.lblFinHeight);
            this.Controls.Add(this.cboFinType);
            this.Controls.Add(this.lblFinType);
            this.Controls.Add(this.numRARH);
            this.Controls.Add(this.lblRARH);
            this.Controls.Add(this.numAirFlowSupply);
            this.Controls.Add(this.lblAirFlowSupply);
            this.Controls.Add(this.numAirFlowExhaust);
            this.Controls.Add(this.lblAirFlowExhaust);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.cboFlowType);
            this.Controls.Add(this.numTiltAngle);
            this.Controls.Add(this.lblTiltAngle);
            this.Controls.Add(this.cboShape);
            this.Controls.Add(this.lblFlowType);
            this.Controls.Add(this.numAtmosphericPressure);
            this.Controls.Add(this.lblAtmosphericPressure);
            this.Controls.Add(this.lblShape);
            this.Controls.Add(this.cboSymmetrical);
            this.Controls.Add(this.numOAWB);
            this.Controls.Add(this.lblOAWB);
            this.Controls.Add(this.numRAWB);
            this.Controls.Add(this.lblRAWB);
            this.Controls.Add(this.numAltitude);
            this.Controls.Add(this.lblAltitude);
            this.Controls.Add(this.lblSymmetrical);
            this.Controls.Add(this.numDefrostSetPoint);
            this.Controls.Add(this.lblDefrostSetPoint);
            this.Controls.Add(this.numOARH);
            this.Controls.Add(this.lblOARH);
            this.Controls.Add(this.numRADB);
            this.Controls.Add(this.lblRADB);
            this.Controls.Add(this.numOADB);
            this.Controls.Add(this.lblOADB);
            this.Controls.Add(this.numNumberOfRows);
            this.Controls.Add(this.lblNumberOfRows);
            this.Controls.Add(this.lblFPI);
            this.Controls.Add(this.numFinLength);
            this.Controls.Add(this.lblFinLength);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQuickHeatPipe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "sQuick Heat Pipe";
            this.Load += new System.EventHandler(this.frmQuickHeatPipe_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmQuickHeatPipe_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.numFinLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOADB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberOfRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRADB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOARH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDefrostSetPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOAWB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAtmosphericPressure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRAWB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTiltAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAirFlowExhaust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAirFlowSupply)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRARH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRARHWinter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOAWBWinter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRAWBWinter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOARHWinter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRADBWinter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOADBWinter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numFinLength;
        private System.Windows.Forms.Label lblFinLength;
        private System.Windows.Forms.NumericUpDown numOADB;
        private System.Windows.Forms.Label lblOADB;
        private System.Windows.Forms.NumericUpDown numNumberOfRows;
        private System.Windows.Forms.Label lblNumberOfRows;
        private System.Windows.Forms.Label lblFPI;
        private System.Windows.Forms.NumericUpDown numRADB;
        private System.Windows.Forms.Label lblRADB;
        private System.Windows.Forms.NumericUpDown numOARH;
        private System.Windows.Forms.Label lblOARH;
        private System.Windows.Forms.NumericUpDown numDefrostSetPoint;
        private System.Windows.Forms.Label lblDefrostSetPoint;
        private System.Windows.Forms.Label lblSymmetrical;
        private System.Windows.Forms.NumericUpDown numAltitude;
        private System.Windows.Forms.Label lblAltitude;
        private System.Windows.Forms.Label lblRAWB;
        private System.Windows.Forms.NumericUpDown numOAWB;
        private System.Windows.Forms.Label lblOAWB;
        private System.Windows.Forms.ComboBox cboSymmetrical;
        private System.Windows.Forms.Label lblShape;
        private System.Windows.Forms.NumericUpDown numAtmosphericPressure;
        private System.Windows.Forms.Label lblAtmosphericPressure;
        private System.Windows.Forms.Label lblFlowType;
        private System.Windows.Forms.NumericUpDown numRAWB;
        private System.Windows.Forms.ComboBox cboShape;
        private System.Windows.Forms.NumericUpDown numTiltAngle;
        private System.Windows.Forms.Label lblTiltAngle;
        private System.Windows.Forms.ComboBox cboFlowType;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdAccept;
        private System.Windows.Forms.NumericUpDown numAirFlowExhaust;
        private System.Windows.Forms.Label lblAirFlowExhaust;
        private System.Windows.Forms.NumericUpDown numAirFlowSupply;
        private System.Windows.Forms.Label lblAirFlowSupply;
        private System.Windows.Forms.NumericUpDown numRARH;
        private System.Windows.Forms.Label lblRARH;
        private System.Windows.Forms.ComboBox cboFinHeight;
        private System.Windows.Forms.Label lblFinHeight;
        private System.Windows.Forms.ComboBox cboFinType;
        private System.Windows.Forms.Label lblFinType;
        private System.Windows.Forms.ComboBox cboFPI;
        private System.Windows.Forms.NumericUpDown numRARHWinter;
        private System.Windows.Forms.NumericUpDown numOAWBWinter;
        private System.Windows.Forms.NumericUpDown numRAWBWinter;
        private System.Windows.Forms.NumericUpDown numOARHWinter;
        private System.Windows.Forms.NumericUpDown numRADBWinter;
        private System.Windows.Forms.NumericUpDown numOADBWinter;
        private System.Windows.Forms.Label lblSummer;
        private System.Windows.Forms.Label lblWinter;
        private System.Windows.Forms.Label lblTag;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.Button btnHelp;
    }
}