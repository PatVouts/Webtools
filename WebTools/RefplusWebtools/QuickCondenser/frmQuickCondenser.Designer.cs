namespace RefplusWebtools.QuickCondenser
{
    partial class FrmQuickCondenser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQuickCondenser));
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn4 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn5 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn6 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn7 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn8 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn9 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn10 = new GlacialComponents.Controls.GLColumn();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.lblTag = new System.Windows.Forms.Label();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.cboFPI = new System.Windows.Forms.ComboBox();
            this.lblFPI = new System.Windows.Forms.Label();
            this.lblTotalHeatRecovery = new System.Windows.Forms.Label();
            this.cboAirFlowType = new System.Windows.Forms.ComboBox();
            this.lblAirFlowType = new System.Windows.Forms.Label();
            this.cboVoltage = new System.Windows.Forms.ComboBox();
            this.lblVoltage = new System.Windows.Forms.Label();
            this.cboCondenserSerie = new System.Windows.Forms.ComboBox();
            this.lblCondenserSerie = new System.Windows.Forms.Label();
            this.cboTypeOfCondenser = new System.Windows.Forms.ComboBox();
            this.lblTypeOfCondenser = new System.Windows.Forms.Label();
            this.cboFanArrangement = new System.Windows.Forms.ComboBox();
            this.lblFanArrangement = new System.Windows.Forms.Label();
            this.numAmbientTemperature = new System.Windows.Forms.NumericUpDown();
            this.lblAmbientTemperature = new System.Windows.Forms.Label();
            this.numAltitude = new System.Windows.Forms.NumericUpDown();
            this.lblAltitude = new System.Windows.Forms.Label();
            this.numTotalHeatRecovery = new System.Windows.Forms.NumericUpDown();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.grpCircuits = new System.Windows.Forms.GroupBox();
            this.cmdEditCircuit = new System.Windows.Forms.Button();
            this.lblTotalCircuits = new System.Windows.Forms.Label();
            this.lblTotalCircuitsValue = new System.Windows.Forms.Label();
            this.lblTotalCapacity = new System.Windows.Forms.Label();
            this.lblTotalCapacityValue = new System.Windows.Forms.Label();
            this.cmdRemoveCircuit = new System.Windows.Forms.Button();
            this.lvCircuits = new System.Windows.Forms.ListView();
            this.colCircuitID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColRef = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSCT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCapacity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCapPerCirc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCalculated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEst = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdAddCircuit = new System.Windows.Forms.Button();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.cboCondensingUnit = new System.Windows.Forms.ComboBox();
            this.chkAttachToCondensingUnit = new System.Windows.Forms.CheckBox();
            this.lblUnderSizeColor = new System.Windows.Forms.Label();
            this.lblPerfectMatchColor = new System.Windows.Forms.Label();
            this.lblOverSizeColor = new System.Windows.Forms.Label();
            this.lblUnderSize = new System.Windows.Forms.Label();
            this.lblPerfectMatch = new System.Windows.Forms.Label();
            this.lblOverSize = new System.Windows.Forms.Label();
            this.lvCondenser = new GlacialComponents.Controls.GlacialList();
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.chkRating = new System.Windows.Forms.CheckBox();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmbientTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalHeatRecovery)).BeginInit();
            this.grpCircuits.SuspendLayout();
            this.SuspendLayout();
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(175, 53);
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
            this.numQuantity.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(3, 55);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(51, 13);
            this.lblQuantity.TabIndex = 8;
            this.lblQuantity.Text = "sQuantity";
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(176, 30);
            this.txtTag.MaxLength = 50;
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(489, 20);
            this.txtTag.TabIndex = 1;
            this.txtTag.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblTag
            // 
            this.lblTag.AutoSize = true;
            this.lblTag.Location = new System.Drawing.Point(3, 33);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(31, 13);
            this.lblTag.TabIndex = 6;
            this.lblTag.Text = "sTag";
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.cboFPI);
            this.grpInput.Controls.Add(this.lblFPI);
            this.grpInput.Controls.Add(this.lblTotalHeatRecovery);
            this.grpInput.Controls.Add(this.cboAirFlowType);
            this.grpInput.Controls.Add(this.lblAirFlowType);
            this.grpInput.Controls.Add(this.cboVoltage);
            this.grpInput.Controls.Add(this.lblVoltage);
            this.grpInput.Controls.Add(this.cboCondenserSerie);
            this.grpInput.Controls.Add(this.lblCondenserSerie);
            this.grpInput.Controls.Add(this.cboTypeOfCondenser);
            this.grpInput.Controls.Add(this.lblTypeOfCondenser);
            this.grpInput.Controls.Add(this.cboFanArrangement);
            this.grpInput.Controls.Add(this.lblFanArrangement);
            this.grpInput.Controls.Add(this.numAmbientTemperature);
            this.grpInput.Controls.Add(this.lblAmbientTemperature);
            this.grpInput.Controls.Add(this.numAltitude);
            this.grpInput.Controls.Add(this.lblAltitude);
            this.grpInput.Controls.Add(this.numTotalHeatRecovery);
            this.grpInput.Location = new System.Drawing.Point(6, 73);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(668, 126);
            this.grpInput.TabIndex = 5;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "sInputs";
            // 
            // cboFPI
            // 
            this.cboFPI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFPI.FormattingEnabled = true;
            this.cboFPI.Location = new System.Drawing.Point(479, 99);
            this.cboFPI.Name = "cboFPI";
            this.cboFPI.Size = new System.Drawing.Size(180, 21);
            this.cboFPI.TabIndex = 8;
            this.cboFPI.SelectedIndexChanged += new System.EventHandler(this.cboFPI_SelectedIndexChanged);
            // 
            // lblFPI
            // 
            this.lblFPI.AutoSize = true;
            this.lblFPI.Location = new System.Drawing.Point(328, 102);
            this.lblFPI.Name = "lblFPI";
            this.lblFPI.Size = new System.Drawing.Size(73, 13);
            this.lblFPI.TabIndex = 97;
            this.lblFPI.Text = "sFins per Inch";
            // 
            // lblTotalHeatRecovery
            // 
            this.lblTotalHeatRecovery.AutoSize = true;
            this.lblTotalHeatRecovery.Enabled = false;
            this.lblTotalHeatRecovery.Location = new System.Drawing.Point(328, 80);
            this.lblTotalHeatRecovery.Name = "lblTotalHeatRecovery";
            this.lblTotalHeatRecovery.Size = new System.Drawing.Size(122, 13);
            this.lblTotalHeatRecovery.TabIndex = 95;
            this.lblTotalHeatRecovery.Text = "sTotal Heat Recovery %";
            // 
            // cboAirFlowType
            // 
            this.cboAirFlowType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAirFlowType.FormattingEnabled = true;
            this.cboAirFlowType.Location = new System.Drawing.Point(142, 79);
            this.cboAirFlowType.Name = "cboAirFlowType";
            this.cboAirFlowType.Size = new System.Drawing.Size(180, 21);
            this.cboAirFlowType.TabIndex = 3;
            this.cboAirFlowType.SelectedIndexChanged += new System.EventHandler(this.cboAirFlowType_SelectedIndexChanged);
            // 
            // lblAirFlowType
            // 
            this.lblAirFlowType.AutoSize = true;
            this.lblAirFlowType.Location = new System.Drawing.Point(6, 82);
            this.lblAirFlowType.Name = "lblAirFlowType";
            this.lblAirFlowType.Size = new System.Drawing.Size(76, 13);
            this.lblAirFlowType.TabIndex = 94;
            this.lblAirFlowType.Text = "sAir Flow Type";
            // 
            // cboVoltage
            // 
            this.cboVoltage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVoltage.FormattingEnabled = true;
            this.cboVoltage.Location = new System.Drawing.Point(479, 56);
            this.cboVoltage.Name = "cboVoltage";
            this.cboVoltage.Size = new System.Drawing.Size(180, 21);
            this.cboVoltage.TabIndex = 6;
            this.cboVoltage.SelectedIndexChanged += new System.EventHandler(this.cboFrequency_SelectedIndexChanged);
            // 
            // lblVoltage
            // 
            this.lblVoltage.AutoSize = true;
            this.lblVoltage.Location = new System.Drawing.Point(328, 59);
            this.lblVoltage.Name = "lblVoltage";
            this.lblVoltage.Size = new System.Drawing.Size(48, 13);
            this.lblVoltage.TabIndex = 65;
            this.lblVoltage.Text = "sVoltage";
            // 
            // cboCondenserSerie
            // 
            this.cboCondenserSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondenserSerie.DropDownWidth = 400;
            this.cboCondenserSerie.FormattingEnabled = true;
            this.cboCondenserSerie.Location = new System.Drawing.Point(479, 34);
            this.cboCondenserSerie.Name = "cboCondenserSerie";
            this.cboCondenserSerie.Size = new System.Drawing.Size(180, 21);
            this.cboCondenserSerie.TabIndex = 5;
            this.cboCondenserSerie.SelectedIndexChanged += new System.EventHandler(this.cboCondenserSerie_SelectedIndexChanged);
            // 
            // lblCondenserSerie
            // 
            this.lblCondenserSerie.AutoSize = true;
            this.lblCondenserSerie.Location = new System.Drawing.Point(328, 37);
            this.lblCondenserSerie.Name = "lblCondenserSerie";
            this.lblCondenserSerie.Size = new System.Drawing.Size(90, 13);
            this.lblCondenserSerie.TabIndex = 63;
            this.lblCondenserSerie.Text = "sCondenser Serie";
            // 
            // cboTypeOfCondenser
            // 
            this.cboTypeOfCondenser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypeOfCondenser.FormattingEnabled = true;
            this.cboTypeOfCondenser.Location = new System.Drawing.Point(479, 11);
            this.cboTypeOfCondenser.Name = "cboTypeOfCondenser";
            this.cboTypeOfCondenser.Size = new System.Drawing.Size(180, 21);
            this.cboTypeOfCondenser.TabIndex = 4;
            this.cboTypeOfCondenser.SelectedIndexChanged += new System.EventHandler(this.cboTypeOfCondenser_SelectedIndexChanged);
            // 
            // lblTypeOfCondenser
            // 
            this.lblTypeOfCondenser.AutoSize = true;
            this.lblTypeOfCondenser.Location = new System.Drawing.Point(328, 15);
            this.lblTypeOfCondenser.Name = "lblTypeOfCondenser";
            this.lblTypeOfCondenser.Size = new System.Drawing.Size(102, 13);
            this.lblTypeOfCondenser.TabIndex = 61;
            this.lblTypeOfCondenser.Text = "sType of Condenser";
            // 
            // cboFanArrangement
            // 
            this.cboFanArrangement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFanArrangement.FormattingEnabled = true;
            this.cboFanArrangement.Location = new System.Drawing.Point(142, 57);
            this.cboFanArrangement.Name = "cboFanArrangement";
            this.cboFanArrangement.Size = new System.Drawing.Size(180, 21);
            this.cboFanArrangement.TabIndex = 2;
            this.cboFanArrangement.SelectedIndexChanged += new System.EventHandler(this.cboFanArrangement_SelectedIndexChanged);
            // 
            // lblFanArrangement
            // 
            this.lblFanArrangement.AutoSize = true;
            this.lblFanArrangement.Location = new System.Drawing.Point(6, 60);
            this.lblFanArrangement.Name = "lblFanArrangement";
            this.lblFanArrangement.Size = new System.Drawing.Size(93, 13);
            this.lblFanArrangement.TabIndex = 4;
            this.lblFanArrangement.Text = "sFan Arrangement";
            // 
            // numAmbientTemperature
            // 
            this.numAmbientTemperature.DecimalPlaces = 2;
            this.numAmbientTemperature.Location = new System.Drawing.Point(142, 36);
            this.numAmbientTemperature.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numAmbientTemperature.Name = "numAmbientTemperature";
            this.numAmbientTemperature.Size = new System.Drawing.Size(180, 20);
            this.numAmbientTemperature.TabIndex = 1;
            this.numAmbientTemperature.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numAmbientTemperature.ValueChanged += new System.EventHandler(this.numAmbientTemperature_ValueChanged);
            this.numAmbientTemperature.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblAmbientTemperature
            // 
            this.lblAmbientTemperature.AutoSize = true;
            this.lblAmbientTemperature.Location = new System.Drawing.Point(6, 38);
            this.lblAmbientTemperature.Name = "lblAmbientTemperature";
            this.lblAmbientTemperature.Size = new System.Drawing.Size(113, 13);
            this.lblAmbientTemperature.TabIndex = 2;
            this.lblAmbientTemperature.Text = "sAmbient Temperature";
            // 
            // numAltitude
            // 
            this.numAltitude.Location = new System.Drawing.Point(142, 14);
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
            this.numAltitude.Size = new System.Drawing.Size(180, 20);
            this.numAltitude.TabIndex = 0;
            this.numAltitude.ValueChanged += new System.EventHandler(this.numAltitude_ValueChanged);
            this.numAltitude.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblAltitude
            // 
            this.lblAltitude.AutoSize = true;
            this.lblAltitude.Location = new System.Drawing.Point(6, 16);
            this.lblAltitude.Name = "lblAltitude";
            this.lblAltitude.Size = new System.Drawing.Size(47, 13);
            this.lblAltitude.TabIndex = 0;
            this.lblAltitude.Text = "sAltitude";
            // 
            // numTotalHeatRecovery
            // 
            this.numTotalHeatRecovery.Enabled = false;
            this.numTotalHeatRecovery.Location = new System.Drawing.Point(479, 78);
            this.numTotalHeatRecovery.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numTotalHeatRecovery.Name = "numTotalHeatRecovery";
            this.numTotalHeatRecovery.Size = new System.Drawing.Size(180, 20);
            this.numTotalHeatRecovery.TabIndex = 7;
            this.numTotalHeatRecovery.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numTotalHeatRecovery.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(535, 576);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(139, 25);
            this.cmdCancel.TabIndex = 10;
            this.cmdCancel.Text = "sCancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // grpCircuits
            // 
            this.grpCircuits.Controls.Add(this.cmdEditCircuit);
            this.grpCircuits.Controls.Add(this.lblTotalCircuits);
            this.grpCircuits.Controls.Add(this.lblTotalCircuitsValue);
            this.grpCircuits.Controls.Add(this.lblTotalCapacity);
            this.grpCircuits.Controls.Add(this.lblTotalCapacityValue);
            this.grpCircuits.Controls.Add(this.cmdRemoveCircuit);
            this.grpCircuits.Controls.Add(this.lvCircuits);
            this.grpCircuits.Controls.Add(this.cmdAddCircuit);
            this.grpCircuits.Location = new System.Drawing.Point(6, 205);
            this.grpCircuits.Name = "grpCircuits";
            this.grpCircuits.Size = new System.Drawing.Size(668, 229);
            this.grpCircuits.TabIndex = 6;
            this.grpCircuits.TabStop = false;
            this.grpCircuits.Text = "sCircuits";
            // 
            // cmdEditCircuit
            // 
            this.cmdEditCircuit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEditCircuit.Image")));
            this.cmdEditCircuit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEditCircuit.Location = new System.Drawing.Point(185, 16);
            this.cmdEditCircuit.Name = "cmdEditCircuit";
            this.cmdEditCircuit.Size = new System.Drawing.Size(170, 25);
            this.cmdEditCircuit.TabIndex = 75;
            this.cmdEditCircuit.Text = "sEdit Circuit";
            this.cmdEditCircuit.UseVisualStyleBackColor = true;
            this.cmdEditCircuit.Click += new System.EventHandler(this.cmdEditCircuit_Click);
            // 
            // lblTotalCircuits
            // 
            this.lblTotalCircuits.AutoSize = true;
            this.lblTotalCircuits.Location = new System.Drawing.Point(271, 203);
            this.lblTotalCircuits.Name = "lblTotalCircuits";
            this.lblTotalCircuits.Size = new System.Drawing.Size(73, 13);
            this.lblTotalCircuits.TabIndex = 74;
            this.lblTotalCircuits.Text = "sTotal Circuits";
            // 
            // lblTotalCircuitsValue
            // 
            this.lblTotalCircuitsValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblTotalCircuitsValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalCircuitsValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotalCircuitsValue.Location = new System.Drawing.Point(350, 202);
            this.lblTotalCircuitsValue.Name = "lblTotalCircuitsValue";
            this.lblTotalCircuitsValue.Size = new System.Drawing.Size(94, 16);
            this.lblTotalCircuitsValue.TabIndex = 73;
            this.lblTotalCircuitsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalCapacity
            // 
            this.lblTotalCapacity.AutoSize = true;
            this.lblTotalCapacity.Location = new System.Drawing.Point(4, 203);
            this.lblTotalCapacity.Name = "lblTotalCapacity";
            this.lblTotalCapacity.Size = new System.Drawing.Size(133, 13);
            this.lblTotalCapacity.TabIndex = 72;
            this.lblTotalCapacity.Text = "sTotal Capacity MBH/FTD";
            // 
            // lblTotalCapacityValue
            // 
            this.lblTotalCapacityValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblTotalCapacityValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalCapacityValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotalCapacityValue.Location = new System.Drawing.Point(143, 202);
            this.lblTotalCapacityValue.Name = "lblTotalCapacityValue";
            this.lblTotalCapacityValue.Size = new System.Drawing.Size(94, 16);
            this.lblTotalCapacityValue.TabIndex = 71;
            this.lblTotalCapacityValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdRemoveCircuit
            // 
            this.cmdRemoveCircuit.Image = ((System.Drawing.Image)(resources.GetObject("cmdRemoveCircuit.Image")));
            this.cmdRemoveCircuit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRemoveCircuit.Location = new System.Drawing.Point(487, 197);
            this.cmdRemoveCircuit.Name = "cmdRemoveCircuit";
            this.cmdRemoveCircuit.Size = new System.Drawing.Size(170, 25);
            this.cmdRemoveCircuit.TabIndex = 7;
            this.cmdRemoveCircuit.Text = "sRemove Circuit";
            this.cmdRemoveCircuit.UseVisualStyleBackColor = true;
            this.cmdRemoveCircuit.Click += new System.EventHandler(this.cmdRemoveCircuit_Click);
            // 
            // lvCircuits
            // 
            this.lvCircuits.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCircuitID,
            this.ColRef,
            this.colSCT,
            this.colCapacity,
            this.colTD,
            this.colHR,
            this.colCapPerCirc,
            this.colCalculated,
            this.colEst,
            this.colTotal});
            this.lvCircuits.FullRowSelect = true;
            this.lvCircuits.GridLines = true;
            this.lvCircuits.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvCircuits.HideSelection = false;
            this.lvCircuits.Location = new System.Drawing.Point(7, 43);
            this.lvCircuits.MultiSelect = false;
            this.lvCircuits.Name = "lvCircuits";
            this.lvCircuits.Size = new System.Drawing.Size(650, 152);
            this.lvCircuits.TabIndex = 6;
            this.lvCircuits.UseCompatibleStateImageBehavior = false;
            this.lvCircuits.View = System.Windows.Forms.View.Details;
            this.lvCircuits.SelectedIndexChanged += new System.EventHandler(this.lvCircuits_SelectedIndexChanged);
            // 
            // colCircuitID
            // 
            this.colCircuitID.Text = "ID";
            this.colCircuitID.Width = 0;
            // 
            // ColRef
            // 
            this.ColRef.Text = "sRef";
            this.ColRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colSCT
            // 
            this.colSCT.Text = "sSCT";
            this.colSCT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colCapacity
            // 
            this.colCapacity.Text = "sCapacity";
            this.colCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colCapacity.Width = 96;
            // 
            // colTD
            // 
            this.colTD.Text = "sTD";
            this.colTD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colTD.Width = 57;
            // 
            // colHR
            // 
            this.colHR.Text = "sHR";
            this.colHR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colCapPerCirc
            // 
            this.colCapPerCirc.Text = "sCap/Circ";
            this.colCapPerCirc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colCapPerCirc.Width = 63;
            // 
            // colCalculated
            // 
            this.colCalculated.Text = "sCalculated";
            this.colCalculated.Width = 84;
            // 
            // colEst
            // 
            this.colEst.Text = "sEst.";
            this.colEst.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colTotal
            // 
            this.colTotal.Text = "sTotal";
            this.colTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdAddCircuit
            // 
            this.cmdAddCircuit.Image = ((System.Drawing.Image)(resources.GetObject("cmdAddCircuit.Image")));
            this.cmdAddCircuit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAddCircuit.Location = new System.Drawing.Point(9, 16);
            this.cmdAddCircuit.Name = "cmdAddCircuit";
            this.cmdAddCircuit.Size = new System.Drawing.Size(170, 25);
            this.cmdAddCircuit.TabIndex = 5;
            this.cmdAddCircuit.Text = "sAdd Circuit";
            this.cmdAddCircuit.UseVisualStyleBackColor = true;
            this.cmdAddCircuit.Click += new System.EventHandler(this.cmdAddCircuit_Click);
            // 
            // cmdAccept
            // 
            this.cmdAccept.Image = ((System.Drawing.Image)(resources.GetObject("cmdAccept.Image")));
            this.cmdAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAccept.Location = new System.Drawing.Point(6, 576);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(139, 25);
            this.cmdAccept.TabIndex = 8;
            this.cmdAccept.Text = "sAccept";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // cboCondensingUnit
            // 
            this.cboCondensingUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondensingUnit.FormattingEnabled = true;
            this.cboCondensingUnit.Location = new System.Drawing.Point(176, 5);
            this.cboCondensingUnit.Name = "cboCondensingUnit";
            this.cboCondensingUnit.Size = new System.Drawing.Size(236, 21);
            this.cboCondensingUnit.TabIndex = 0;
            this.cboCondensingUnit.Visible = false;
            // 
            // chkAttachToCondensingUnit
            // 
            this.chkAttachToCondensingUnit.AutoSize = true;
            this.chkAttachToCondensingUnit.Location = new System.Drawing.Point(6, 7);
            this.chkAttachToCondensingUnit.Name = "chkAttachToCondensingUnit";
            this.chkAttachToCondensingUnit.Size = new System.Drawing.Size(164, 17);
            this.chkAttachToCondensingUnit.TabIndex = 0;
            this.chkAttachToCondensingUnit.Text = "sAttach to a Condensing Unit";
            this.chkAttachToCondensingUnit.UseVisualStyleBackColor = true;
            this.chkAttachToCondensingUnit.CheckedChanged += new System.EventHandler(this.chkAttachToCondensingUnit_CheckedChanged);
            // 
            // lblUnderSizeColor
            // 
            this.lblUnderSizeColor.BackColor = System.Drawing.Color.White;
            this.lblUnderSizeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUnderSizeColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUnderSizeColor.Location = new System.Drawing.Point(12, 442);
            this.lblUnderSizeColor.Name = "lblUnderSizeColor";
            this.lblUnderSizeColor.Size = new System.Drawing.Size(12, 12);
            this.lblUnderSizeColor.TabIndex = 75;
            this.lblUnderSizeColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPerfectMatchColor
            // 
            this.lblPerfectMatchColor.BackColor = System.Drawing.Color.White;
            this.lblPerfectMatchColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPerfectMatchColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPerfectMatchColor.Location = new System.Drawing.Point(137, 442);
            this.lblPerfectMatchColor.Name = "lblPerfectMatchColor";
            this.lblPerfectMatchColor.Size = new System.Drawing.Size(12, 12);
            this.lblPerfectMatchColor.TabIndex = 97;
            this.lblPerfectMatchColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOverSizeColor
            // 
            this.lblOverSizeColor.BackColor = System.Drawing.Color.White;
            this.lblOverSizeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOverSizeColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblOverSizeColor.Location = new System.Drawing.Point(263, 442);
            this.lblOverSizeColor.Name = "lblOverSizeColor";
            this.lblOverSizeColor.Size = new System.Drawing.Size(13, 12);
            this.lblOverSizeColor.TabIndex = 98;
            this.lblOverSizeColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUnderSize
            // 
            this.lblUnderSize.Location = new System.Drawing.Point(30, 440);
            this.lblUnderSize.Name = "lblUnderSize";
            this.lblUnderSize.Size = new System.Drawing.Size(101, 16);
            this.lblUnderSize.TabIndex = 99;
            this.lblUnderSize.Text = "sUndersize";
            this.lblUnderSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPerfectMatch
            // 
            this.lblPerfectMatch.Location = new System.Drawing.Point(157, 440);
            this.lblPerfectMatch.Name = "lblPerfectMatch";
            this.lblPerfectMatch.Size = new System.Drawing.Size(97, 16);
            this.lblPerfectMatch.TabIndex = 100;
            this.lblPerfectMatch.Text = "sBest Match";
            this.lblPerfectMatch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOverSize
            // 
            this.lblOverSize.Location = new System.Drawing.Point(283, 440);
            this.lblOverSize.Name = "lblOverSize";
            this.lblOverSize.Size = new System.Drawing.Size(111, 16);
            this.lblOverSize.TabIndex = 101;
            this.lblOverSize.Text = "sOversize";
            this.lblOverSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvCondenser
            // 
            this.lvCondenser.AllowColumnResize = false;
            this.lvCondenser.AllowMultiselect = false;
            this.lvCondenser.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvCondenser.AlternatingColors = false;
            this.lvCondenser.AutoHeight = false;
            this.lvCondenser.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvCondenser.BackgroundStretchToFit = true;
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
            glColumn2.Width = 80;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Column2";
            glColumn3.NumericSort = false;
            glColumn3.Text = "s# Circuits";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn3.Width = 65;
            glColumn4.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn4.CheckBoxes = false;
            glColumn4.DatetimeSort = false;
            glColumn4.ImageIndex = -1;
            glColumn4.Name = "Column3";
            glColumn4.NumericSort = false;
            glColumn4.Text = "sTHR / TD";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn4.Width = 65;
            glColumn5.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn5.CheckBoxes = false;
            glColumn5.DatetimeSort = false;
            glColumn5.ImageIndex = -1;
            glColumn5.Name = "Column4";
            glColumn5.NumericSort = false;
            glColumn5.Text = "sFan Arr";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn5.Width = 60;
            glColumn6.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn6.CheckBoxes = false;
            glColumn6.DatetimeSort = false;
            glColumn6.ImageIndex = -1;
            glColumn6.Name = "Column8";
            glColumn6.NumericSort = false;
            glColumn6.Text = "sAdj. Ambient";
            glColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn6.Width = 80;
            glColumn7.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn7.CheckBoxes = false;
            glColumn7.DatetimeSort = false;
            glColumn7.ImageIndex = -1;
            glColumn7.Name = "Column9";
            glColumn7.NumericSort = false;
            glColumn7.Text = "sCur. Cap.";
            glColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn7.Width = 65;
            glColumn8.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn8.CheckBoxes = false;
            glColumn8.DatetimeSort = false;
            glColumn8.ImageIndex = -1;
            glColumn8.Name = "Column10";
            glColumn8.NumericSort = false;
            glColumn8.Text = "sAdj. Cap.";
            glColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn8.Width = 65;
            glColumn9.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn9.CheckBoxes = false;
            glColumn9.DatetimeSort = false;
            glColumn9.ImageIndex = -1;
            glColumn9.Name = "Column11";
            glColumn9.NumericSort = false;
            glColumn9.Text = "sRating";
            glColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn9.Width = 120;
            glColumn10.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn10.CheckBoxes = false;
            glColumn10.DatetimeSort = false;
            glColumn10.ImageIndex = -1;
            glColumn10.Name = "Column1xx";
            glColumn10.NumericSort = false;
            glColumn10.Text = "sFPI";
            glColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn10.Width = 40;
            this.lvCondenser.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3,
            glColumn4,
            glColumn5,
            glColumn6,
            glColumn7,
            glColumn8,
            glColumn9,
            glColumn10});
            this.lvCondenser.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvCondenser.FullRowSelect = true;
            this.lvCondenser.GridColor = System.Drawing.Color.LightGray;
            this.lvCondenser.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvCondenser.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvCondenser.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvCondenser.HeaderHeight = 22;
            this.lvCondenser.HeaderVisible = true;
            this.lvCondenser.HeaderWordWrap = false;
            this.lvCondenser.HotColumnTracking = false;
            this.lvCondenser.HotItemTracking = false;
            this.lvCondenser.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvCondenser.HoverEvents = false;
            this.lvCondenser.HoverTime = 1;
            this.lvCondenser.ImageList = null;
            this.lvCondenser.ItemHeight = 25;
            this.lvCondenser.ItemWordWrap = false;
            this.lvCondenser.Location = new System.Drawing.Point(6, 459);
            this.lvCondenser.Name = "lvCondenser";
            this.lvCondenser.Selectable = false;
            this.lvCondenser.SelectedTextColor = System.Drawing.Color.White;
            this.lvCondenser.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvCondenser.ShowBorder = true;
            this.lvCondenser.ShowFocusRect = false;
            this.lvCondenser.Size = new System.Drawing.Size(668, 111);
            this.lvCondenser.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lvCondenser.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvCondenser.TabIndex = 7;
            this.lvCondenser.Text = "glacialList1";
            // 
            // cboModel
            // 
            this.cboModel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModel.Enabled = false;
            this.cboModel.FormattingEnabled = true;
            this.cboModel.Location = new System.Drawing.Point(485, 53);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(180, 21);
            this.cboModel.TabIndex = 4;
            this.cboModel.SelectedIndexChanged += new System.EventHandler(this.cboModel_SelectedIndexChanged);
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(438, 57);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(41, 13);
            this.lblModel.TabIndex = 104;
            this.lblModel.Text = "sModel";
            // 
            // chkRating
            // 
            this.chkRating.AutoSize = true;
            this.chkRating.Location = new System.Drawing.Point(346, 56);
            this.chkRating.Name = "chkRating";
            this.chkRating.Size = new System.Drawing.Size(62, 17);
            this.chkRating.TabIndex = 3;
            this.chkRating.Text = "sRating";
            this.chkRating.UseVisualStyleBackColor = true;
            this.chkRating.CheckedChanged += new System.EventHandler(this.chkRating_CheckedChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(325, 577);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 9;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmQuickCondenser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(683, 608);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.chkRating);
            this.Controls.Add(this.cboModel);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.lvCondenser);
            this.Controls.Add(this.lblOverSizeColor);
            this.Controls.Add(this.lblPerfectMatchColor);
            this.Controls.Add(this.lblUnderSizeColor);
            this.Controls.Add(this.cboCondensingUnit);
            this.Controls.Add(this.chkAttachToCondensingUnit);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.grpCircuits);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtTag);
            this.Controls.Add(this.lblTag);
            this.Controls.Add(this.lblOverSize);
            this.Controls.Add(this.lblPerfectMatch);
            this.Controls.Add(this.lblUnderSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQuickCondenser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "sQuick Condenser";
            this.Load += new System.EventHandler(this.frmQuickCondenser_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmQuickCondenser_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmbientTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalHeatRecovery)).EndInit();
            this.grpCircuits.ResumeLayout(false);
            this.grpCircuits.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.Label lblTag;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.NumericUpDown numAmbientTemperature;
        private System.Windows.Forms.Label lblAmbientTemperature;
        private System.Windows.Forms.NumericUpDown numAltitude;
        private System.Windows.Forms.Label lblAltitude;
        private System.Windows.Forms.Label lblFanArrangement;
        private System.Windows.Forms.ComboBox cboTypeOfCondenser;
        private System.Windows.Forms.Label lblTypeOfCondenser;
        private System.Windows.Forms.ComboBox cboFanArrangement;
        private System.Windows.Forms.ComboBox cboVoltage;
        private System.Windows.Forms.Label lblVoltage;
        private System.Windows.Forms.ComboBox cboCondenserSerie;
        private System.Windows.Forms.Label lblCondenserSerie;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.GroupBox grpCircuits;
        private System.Windows.Forms.ListView lvCircuits;
        private System.Windows.Forms.ColumnHeader colCircuitID;
        private System.Windows.Forms.ColumnHeader ColRef;
        private System.Windows.Forms.Button cmdAddCircuit;
        private System.Windows.Forms.ColumnHeader colSCT;
        private System.Windows.Forms.ColumnHeader colCapacity;
        private System.Windows.Forms.ColumnHeader colTD;
        private System.Windows.Forms.ColumnHeader colHR;
        private System.Windows.Forms.ColumnHeader colCapPerCirc;
        private System.Windows.Forms.ColumnHeader colEst;
        private System.Windows.Forms.ColumnHeader colTotal;
        private System.Windows.Forms.Button cmdRemoveCircuit;
        private System.Windows.Forms.Label lblTotalCircuits;
        private System.Windows.Forms.Label lblTotalCircuitsValue;
        private System.Windows.Forms.Label lblTotalCapacity;
        private System.Windows.Forms.Label lblTotalCapacityValue;
        private System.Windows.Forms.Button cmdAccept;
        private System.Windows.Forms.ComboBox cboCondensingUnit;
        private System.Windows.Forms.CheckBox chkAttachToCondensingUnit;
        private System.Windows.Forms.Label lblUnderSizeColor;
        private System.Windows.Forms.Label lblPerfectMatchColor;
        private System.Windows.Forms.Label lblOverSizeColor;
        private System.Windows.Forms.Label lblUnderSize;
        private System.Windows.Forms.Label lblPerfectMatch;
        private System.Windows.Forms.Label lblOverSize;
        private System.Windows.Forms.ComboBox cboAirFlowType;
        private System.Windows.Forms.Label lblAirFlowType;
        private System.Windows.Forms.Label lblTotalHeatRecovery;
        private System.Windows.Forms.NumericUpDown numTotalHeatRecovery;
        private System.Windows.Forms.ComboBox cboFPI;
        private System.Windows.Forms.Label lblFPI;
        private GlacialComponents.Controls.GlacialList lvCondenser;
        private System.Windows.Forms.ComboBox cboModel;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.CheckBox chkRating;
        private System.Windows.Forms.ColumnHeader colCalculated;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button cmdEditCircuit;
    }
}