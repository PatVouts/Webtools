using Microsoft.Win32;

namespace RefplusWebtools.DataManager.Costing
{
    partial class FrmLogic
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
            this.grpCompressor = new System.Windows.Forms.GroupBox();
            this.lblCompressorPounds = new System.Windows.Forms.Label();
            this.nUdCompressorWeight = new System.Windows.Forms.NumericUpDown();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblCompressorValue = new System.Windows.Forms.Label();
            this.lblModule = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.btn_Details = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.grpConnexions = new System.Windows.Forms.GroupBox();
            this.cboDischarge = new System.Windows.Forms.ComboBox();
            this.cboSuction = new System.Windows.Forms.ComboBox();
            this.cboLiquid = new System.Windows.Forms.ComboBox();
            this.lblDischarge = new System.Windows.Forms.Label();
            this.lblSuction = new System.Windows.Forms.Label();
            this.lblLiquid = new System.Windows.Forms.Label();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.lblTandemValue = new System.Windows.Forms.Label();
            this.lblVoltageValue = new System.Windows.Forms.Label();
            this.lblRefrigerantValue = new System.Windows.Forms.Label();
            this.lblManufacturerValue = new System.Windows.Forms.Label();
            this.lblLRAValue = new System.Windows.Forms.Label();
            this.lblRLAValue = new System.Windows.Forms.Label();
            this.lblTypeValue = new System.Windows.Forms.Label();
            this.lblTandem = new System.Windows.Forms.Label();
            this.lblVoltage = new System.Windows.Forms.Label();
            this.lblRefrigerant = new System.Windows.Forms.Label();
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.lblLRA = new System.Windows.Forms.Label();
            this.lblRLA = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblCompressorSelected = new System.Windows.Forms.Label();
            this.grpPolynomials = new System.Windows.Forms.GroupBox();
            this.lblPower9Value = new System.Windows.Forms.Label();
            this.lblCapacity1Value = new System.Windows.Forms.Label();
            this.lblPower3Value = new System.Windows.Forms.Label();
            this.lblCapacity8Value = new System.Windows.Forms.Label();
            this.lblPower8Value = new System.Windows.Forms.Label();
            this.lblCapacity9Value = new System.Windows.Forms.Label();
            this.lblPower4Value = new System.Windows.Forms.Label();
            this.lblCapacity10Value = new System.Windows.Forms.Label();
            this.lblPower7Value = new System.Windows.Forms.Label();
            this.lblPower1Value = new System.Windows.Forms.Label();
            this.lblPower5Value = new System.Windows.Forms.Label();
            this.lblCapacity4Value = new System.Windows.Forms.Label();
            this.lblPower6Value = new System.Windows.Forms.Label();
            this.lblPower2Value = new System.Windows.Forms.Label();
            this.lblPower10Value = new System.Windows.Forms.Label();
            this.lblCapacity3Value = new System.Windows.Forms.Label();
            this.lblCapacity7Value = new System.Windows.Forms.Label();
            this.lblCapacity5Value = new System.Windows.Forms.Label();
            this.lblCapacity2Value = new System.Windows.Forms.Label();
            this.lblCapacity6Value = new System.Windows.Forms.Label();
            this.lblPower9 = new System.Windows.Forms.Label();
            this.lblCapacity1 = new System.Windows.Forms.Label();
            this.lblPower3 = new System.Windows.Forms.Label();
            this.lblCapacity8 = new System.Windows.Forms.Label();
            this.lblPower8 = new System.Windows.Forms.Label();
            this.lblCapacity9 = new System.Windows.Forms.Label();
            this.lblPower4 = new System.Windows.Forms.Label();
            this.lblCapacity10 = new System.Windows.Forms.Label();
            this.lblPower7 = new System.Windows.Forms.Label();
            this.lblPower1 = new System.Windows.Forms.Label();
            this.lblPower5 = new System.Windows.Forms.Label();
            this.lblCapacity4 = new System.Windows.Forms.Label();
            this.lblPower6 = new System.Windows.Forms.Label();
            this.lblPower2 = new System.Windows.Forms.Label();
            this.lblPower10 = new System.Windows.Forms.Label();
            this.lblCapacity3 = new System.Windows.Forms.Label();
            this.lblCapacity7 = new System.Windows.Forms.Label();
            this.lblCapacity5 = new System.Windows.Forms.Label();
            this.lblCapacity2 = new System.Windows.Forms.Label();
            this.lblCapacity6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpMotor = new System.Windows.Forms.GroupBox();
            this.llblMotorPounds = new System.Windows.Forms.Label();
            this.lblFarenheit = new System.Windows.Forms.Label();
            this.lblMotorValue = new System.Windows.Forms.Label();
            this.txtTempMax = new System.Windows.Forms.TextBox();
            this.lblMotor = new System.Windows.Forms.Label();
            this.cboMotorType = new System.Windows.Forms.ComboBox();
            this.txtTempMin = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.nUdFLA = new System.Windows.Forms.NumericUpDown();
            this.cboVoltage = new System.Windows.Forms.ComboBox();
            this.nUdRPM = new System.Windows.Forms.NumericUpDown();
            this.nUdHP = new System.Windows.Forms.NumericUpDown();
            this.nUdMotorWeight = new System.Windows.Forms.NumericUpDown();
            this.lblMotorType = new System.Windows.Forms.Label();
            this.lblWeightMotor = new System.Windows.Forms.Label();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.dgCFM = new System.Windows.Forms.DataGridView();
            this.CoilModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTempRange = new System.Windows.Forms.Label();
            this.lblRPM = new System.Windows.Forms.Label();
            this.lblVoltageMotor = new System.Windows.Forms.Label();
            this.lblHP = new System.Windows.Forms.Label();
            this.lblFLA = new System.Windows.Forms.Label();
            this.grpCoil = new System.Windows.Forms.GroupBox();
            this.cboSubCoolerCircuits = new System.Windows.Forms.ComboBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.nUdCoilWeight = new System.Windows.Forms.NumericUpDown();
            this.lblCoilWeight = new System.Windows.Forms.Label();
            this.lblSubCoolerCircuits = new System.Windows.Forms.Label();
            this.nUdFaceTube = new System.Windows.Forms.NumericUpDown();
            this.lblFaceTube = new System.Windows.Forms.Label();
            this.cboSubCooler = new System.Windows.Forms.ComboBox();
            this.lblSubCooler = new System.Windows.Forms.Label();
            this.cboCircuits = new System.Windows.Forms.ComboBox();
            this.lblCircuits = new System.Windows.Forms.Label();
            this.nUdFanLong = new System.Windows.Forms.NumericUpDown();
            this.lblFanLong = new System.Windows.Forms.Label();
            this.lblCoilModel = new System.Windows.Forms.Label();
            this.nUdFanWide = new System.Windows.Forms.NumericUpDown();
            this.lblFanWide = new System.Windows.Forms.Label();
            this.cboFPI = new System.Windows.Forms.ComboBox();
            this.cboFinHeight = new System.Windows.Forms.ComboBox();
            this.nUdRows = new System.Windows.Forms.NumericUpDown();
            this.nUdFinLength = new System.Windows.Forms.NumericUpDown();
            this.cboFinThickness = new System.Windows.Forms.ComboBox();
            this.lblFinThickness = new System.Windows.Forms.Label();
            this.cboFinMaterial = new System.Windows.Forms.ComboBox();
            this.lblFinMaterial = new System.Windows.Forms.Label();
            this.cboTubeThickness = new System.Windows.Forms.ComboBox();
            this.lblTubeThickness = new System.Windows.Forms.Label();
            this.cboTubeMaterial = new System.Windows.Forms.ComboBox();
            this.lblTubeMaterial = new System.Windows.Forms.Label();
            this.lblFPI = new System.Windows.Forms.Label();
            this.lblRow = new System.Windows.Forms.Label();
            this.lblFinLength = new System.Windows.Forms.Label();
            this.lblFinHeight = new System.Windows.Forms.Label();
            this.cboFinShape = new System.Windows.Forms.ComboBox();
            this.lblFinShape = new System.Windows.Forms.Label();
            this.cboFinType = new System.Windows.Forms.ComboBox();
            this.lblFinType = new System.Windows.Forms.Label();
            this.grpBase = new System.Windows.Forms.GroupBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.nUdBaseWeight = new System.Windows.Forms.NumericUpDown();
            this.lblBaseWeight = new System.Windows.Forms.Label();
            this.grpWCC = new System.Windows.Forms.GroupBox();
            this.txtWCCModel = new System.Windows.Forms.TextBox();
            this.txtWCCR744 = new System.Windows.Forms.TextBox();
            this.txtWCCR407A = new System.Windows.Forms.TextBox();
            this.txtWCCR410A = new System.Windows.Forms.TextBox();
            this.txtWCCR407C = new System.Windows.Forms.TextBox();
            this.txtWCCR404A = new System.Windows.Forms.TextBox();
            this.txtWCCR134A = new System.Windows.Forms.TextBox();
            this.txtWCCR22 = new System.Windows.Forms.TextBox();
            this.lblWCCModel = new System.Windows.Forms.Label();
            this.lblWCCR744 = new System.Windows.Forms.Label();
            this.lblWCCR407A = new System.Windows.Forms.Label();
            this.lblWCCR410A = new System.Windows.Forms.Label();
            this.lblWCCR507A = new System.Windows.Forms.Label();
            this.lblWCCR407C = new System.Windows.Forms.Label();
            this.lblWCCR404A = new System.Windows.Forms.Label();
            this.lblWCCR134A = new System.Windows.Forms.Label();
            this.txtWCCR507A = new System.Windows.Forms.TextBox();
            this.lblWCCR22 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.nUdWCCWeight = new System.Windows.Forms.NumericUpDown();
            this.lblWCCWeight = new System.Windows.Forms.Label();
            this.grpGeneric = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.nUdGenericWeight = new System.Windows.Forms.NumericUpDown();
            this.lblGenericWeight = new System.Windows.Forms.Label();
            this.lblReceiverWeight = new System.Windows.Forms.Label();
            this.nUdReceiverWeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.lblR22 = new System.Windows.Forms.Label();
            this.txtR507A = new System.Windows.Forms.TextBox();
            this.lblR134A = new System.Windows.Forms.Label();
            this.lblR404A = new System.Windows.Forms.Label();
            this.lblR407C = new System.Windows.Forms.Label();
            this.lblR507A = new System.Windows.Forms.Label();
            this.lblR410A = new System.Windows.Forms.Label();
            this.lblR407A = new System.Windows.Forms.Label();
            this.lblR744 = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.txtR22 = new System.Windows.Forms.TextBox();
            this.txtR134A = new System.Windows.Forms.TextBox();
            this.txtR404A = new System.Windows.Forms.TextBox();
            this.txtR407C = new System.Windows.Forms.TextBox();
            this.txtR410A = new System.Windows.Forms.TextBox();
            this.txtR407A = new System.Windows.Forms.TextBox();
            this.txtR744 = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.btnShowSizes = new System.Windows.Forms.Button();
            this.grpReceiver = new System.Windows.Forms.GroupBox();
            this.grpCompressor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUdCompressorWeight)).BeginInit();
            this.grpConnexions.SuspendLayout();
            this.grpInfo.SuspendLayout();
            this.grpPolynomials.SuspendLayout();
            this.grpMotor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUdFLA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUdRPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUdHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUdMotorWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCFM)).BeginInit();
            this.grpCoil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUdCoilWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUdFaceTube)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUdFanLong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUdFanWide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUdRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUdFinLength)).BeginInit();
            this.grpBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUdBaseWeight)).BeginInit();
            this.grpWCC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUdWCCWeight)).BeginInit();
            this.grpGeneric.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUdGenericWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUdReceiverWeight)).BeginInit();
            this.grpReceiver.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCompressor
            // 
            this.grpCompressor.Controls.Add(this.lblCompressorPounds);
            this.grpCompressor.Controls.Add(this.nUdCompressorWeight);
            this.grpCompressor.Controls.Add(this.lblWeight);
            this.grpCompressor.Controls.Add(this.lblCompressorValue);
            this.grpCompressor.Controls.Add(this.lblModule);
            this.grpCompressor.Controls.Add(this.label28);
            this.grpCompressor.Controls.Add(this.btn_Details);
            this.grpCompressor.Controls.Add(this.label29);
            this.grpCompressor.Controls.Add(this.cboModel);
            this.grpCompressor.Controls.Add(this.grpConnexions);
            this.grpCompressor.Controls.Add(this.grpInfo);
            this.grpCompressor.Controls.Add(this.lblCompressorSelected);
            this.grpCompressor.Controls.Add(this.grpPolynomials);
            this.grpCompressor.Location = new System.Drawing.Point(10, 6);
            this.grpCompressor.Name = "grpCompressor";
            this.grpCompressor.Size = new System.Drawing.Size(651, 552);
            this.grpCompressor.TabIndex = 4;
            this.grpCompressor.TabStop = false;
            this.grpCompressor.Text = "Compressor";
            this.grpCompressor.Visible = false;
            // 
            // lblCompressorPounds
            // 
            this.lblCompressorPounds.AutoSize = true;
            this.lblCompressorPounds.Location = new System.Drawing.Point(607, 525);
            this.lblCompressorPounds.Name = "lblCompressorPounds";
            this.lblCompressorPounds.Size = new System.Drawing.Size(20, 13);
            this.lblCompressorPounds.TabIndex = 65;
            this.lblCompressorPounds.Text = "lbs";
            // 
            // nUdCompressorWeight
            // 
            this.nUdCompressorWeight.Location = new System.Drawing.Point(423, 523);
            this.nUdCompressorWeight.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nUdCompressorWeight.Name = "nUdCompressorWeight";
            this.nUdCompressorWeight.Size = new System.Drawing.Size(178, 20);
            this.nUdCompressorWeight.TabIndex = 6;
            this.nUdCompressorWeight.Enter += new System.EventHandler(this.nUdCompressorWeight_Enter);
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(370, 525);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(35, 13);
            this.lblWeight.TabIndex = 34;
            this.lblWeight.Text = "label3";
            // 
            // lblCompressorValue
            // 
            this.lblCompressorValue.AutoSize = true;
            this.lblCompressorValue.Location = new System.Drawing.Point(98, 33);
            this.lblCompressorValue.Name = "lblCompressorValue";
            this.lblCompressorValue.Size = new System.Drawing.Size(0, 13);
            this.lblCompressorValue.TabIndex = 33;
            // 
            // lblModule
            // 
            this.lblModule.AutoSize = true;
            this.lblModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModule.Location = new System.Drawing.Point(9, 33);
            this.lblModule.Name = "lblModule";
            this.lblModule.Size = new System.Drawing.Size(41, 13);
            this.lblModule.TabIndex = 32;
            this.lblModule.Text = "label3";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(700, 568);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(41, 13);
            this.label28.TabIndex = 31;
            this.label28.Text = "label28";
            // 
            // btn_Details
            // 
            this.btn_Details.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Details.Location = new System.Drawing.Point(145, 133);
            this.btn_Details.Name = "btn_Details";
            this.btn_Details.Size = new System.Drawing.Size(94, 23);
            this.btn_Details.TabIndex = 2;
            this.btn_Details.Text = "View Details";
            this.btn_Details.UseVisualStyleBackColor = true;
            this.btn_Details.Click += new System.EventHandler(this.btn_Details_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(700, 546);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(41, 13);
            this.label29.TabIndex = 30;
            this.label29.Text = "label29";
            // 
            // cboModel
            // 
            this.cboModel.FormattingEnabled = true;
            this.cboModel.Location = new System.Drawing.Point(59, 94);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(308, 21);
            this.cboModel.TabIndex = 1;
            this.cboModel.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // grpConnexions
            // 
            this.grpConnexions.Controls.Add(this.cboDischarge);
            this.grpConnexions.Controls.Add(this.cboSuction);
            this.grpConnexions.Controls.Add(this.cboLiquid);
            this.grpConnexions.Controls.Add(this.lblDischarge);
            this.grpConnexions.Controls.Add(this.lblSuction);
            this.grpConnexions.Controls.Add(this.lblLiquid);
            this.grpConnexions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpConnexions.Location = new System.Drawing.Point(6, 363);
            this.grpConnexions.Name = "grpConnexions";
            this.grpConnexions.Size = new System.Drawing.Size(361, 180);
            this.grpConnexions.TabIndex = 1;
            this.grpConnexions.TabStop = false;
            this.grpConnexions.Text = "Connexions";
            // 
            // cboDischarge
            // 
            this.cboDischarge.FormattingEnabled = true;
            this.cboDischarge.Location = new System.Drawing.Point(127, 120);
            this.cboDischarge.Name = "cboDischarge";
            this.cboDischarge.Size = new System.Drawing.Size(121, 21);
            this.cboDischarge.TabIndex = 5;
            // 
            // cboSuction
            // 
            this.cboSuction.FormattingEnabled = true;
            this.cboSuction.Location = new System.Drawing.Point(127, 82);
            this.cboSuction.Name = "cboSuction";
            this.cboSuction.Size = new System.Drawing.Size(121, 21);
            this.cboSuction.TabIndex = 4;
            // 
            // cboLiquid
            // 
            this.cboLiquid.FormattingEnabled = true;
            this.cboLiquid.Location = new System.Drawing.Point(127, 46);
            this.cboLiquid.Name = "cboLiquid";
            this.cboLiquid.Size = new System.Drawing.Size(121, 21);
            this.cboLiquid.TabIndex = 3;
            // 
            // lblDischarge
            // 
            this.lblDischarge.AutoSize = true;
            this.lblDischarge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDischarge.Location = new System.Drawing.Point(50, 123);
            this.lblDischarge.Name = "lblDischarge";
            this.lblDischarge.Size = new System.Drawing.Size(41, 13);
            this.lblDischarge.TabIndex = 5;
            this.lblDischarge.Text = "label6";
            // 
            // lblSuction
            // 
            this.lblSuction.AutoSize = true;
            this.lblSuction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuction.Location = new System.Drawing.Point(50, 85);
            this.lblSuction.Name = "lblSuction";
            this.lblSuction.Size = new System.Drawing.Size(41, 13);
            this.lblSuction.TabIndex = 4;
            this.lblSuction.Text = "label5";
            // 
            // lblLiquid
            // 
            this.lblLiquid.AutoSize = true;
            this.lblLiquid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLiquid.Location = new System.Drawing.Point(50, 49);
            this.lblLiquid.Name = "lblLiquid";
            this.lblLiquid.Size = new System.Drawing.Size(41, 13);
            this.lblLiquid.TabIndex = 3;
            this.lblLiquid.Text = "label4";
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.lblTandemValue);
            this.grpInfo.Controls.Add(this.lblVoltageValue);
            this.grpInfo.Controls.Add(this.lblRefrigerantValue);
            this.grpInfo.Controls.Add(this.lblManufacturerValue);
            this.grpInfo.Controls.Add(this.lblLRAValue);
            this.grpInfo.Controls.Add(this.lblRLAValue);
            this.grpInfo.Controls.Add(this.lblTypeValue);
            this.grpInfo.Controls.Add(this.lblTandem);
            this.grpInfo.Controls.Add(this.lblVoltage);
            this.grpInfo.Controls.Add(this.lblRefrigerant);
            this.grpInfo.Controls.Add(this.lblManufacturer);
            this.grpInfo.Controls.Add(this.lblLRA);
            this.grpInfo.Controls.Add(this.lblRLA);
            this.grpInfo.Controls.Add(this.lblType);
            this.grpInfo.Location = new System.Drawing.Point(6, 165);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(361, 192);
            this.grpInfo.TabIndex = 3;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Informations";
            // 
            // lblTandemValue
            // 
            this.lblTandemValue.AutoSize = true;
            this.lblTandemValue.Location = new System.Drawing.Point(92, 160);
            this.lblTandemValue.Name = "lblTandemValue";
            this.lblTandemValue.Size = new System.Drawing.Size(0, 13);
            this.lblTandemValue.TabIndex = 17;
            // 
            // lblVoltageValue
            // 
            this.lblVoltageValue.AutoSize = true;
            this.lblVoltageValue.Location = new System.Drawing.Point(92, 138);
            this.lblVoltageValue.Name = "lblVoltageValue";
            this.lblVoltageValue.Size = new System.Drawing.Size(0, 13);
            this.lblVoltageValue.TabIndex = 16;
            // 
            // lblRefrigerantValue
            // 
            this.lblRefrigerantValue.AutoSize = true;
            this.lblRefrigerantValue.Location = new System.Drawing.Point(92, 116);
            this.lblRefrigerantValue.Name = "lblRefrigerantValue";
            this.lblRefrigerantValue.Size = new System.Drawing.Size(0, 13);
            this.lblRefrigerantValue.TabIndex = 15;
            // 
            // lblManufacturerValue
            // 
            this.lblManufacturerValue.AutoSize = true;
            this.lblManufacturerValue.Location = new System.Drawing.Point(92, 94);
            this.lblManufacturerValue.Name = "lblManufacturerValue";
            this.lblManufacturerValue.Size = new System.Drawing.Size(0, 13);
            this.lblManufacturerValue.TabIndex = 14;
            // 
            // lblLRAValue
            // 
            this.lblLRAValue.AutoSize = true;
            this.lblLRAValue.Location = new System.Drawing.Point(92, 72);
            this.lblLRAValue.Name = "lblLRAValue";
            this.lblLRAValue.Size = new System.Drawing.Size(0, 13);
            this.lblLRAValue.TabIndex = 13;
            // 
            // lblRLAValue
            // 
            this.lblRLAValue.AutoSize = true;
            this.lblRLAValue.Location = new System.Drawing.Point(92, 49);
            this.lblRLAValue.Name = "lblRLAValue";
            this.lblRLAValue.Size = new System.Drawing.Size(0, 13);
            this.lblRLAValue.TabIndex = 12;
            // 
            // lblTypeValue
            // 
            this.lblTypeValue.AutoSize = true;
            this.lblTypeValue.Location = new System.Drawing.Point(92, 27);
            this.lblTypeValue.Name = "lblTypeValue";
            this.lblTypeValue.Size = new System.Drawing.Size(0, 13);
            this.lblTypeValue.TabIndex = 11;
            // 
            // lblTandem
            // 
            this.lblTandem.AutoSize = true;
            this.lblTandem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTandem.Location = new System.Drawing.Point(6, 160);
            this.lblTandem.Name = "lblTandem";
            this.lblTandem.Size = new System.Drawing.Size(48, 13);
            this.lblTandem.TabIndex = 10;
            this.lblTandem.Text = "label13";
            // 
            // lblVoltage
            // 
            this.lblVoltage.AutoSize = true;
            this.lblVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoltage.Location = new System.Drawing.Point(6, 138);
            this.lblVoltage.Name = "lblVoltage";
            this.lblVoltage.Size = new System.Drawing.Size(48, 13);
            this.lblVoltage.TabIndex = 9;
            this.lblVoltage.Text = "label12";
            // 
            // lblRefrigerant
            // 
            this.lblRefrigerant.AutoSize = true;
            this.lblRefrigerant.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefrigerant.Location = new System.Drawing.Point(6, 116);
            this.lblRefrigerant.Name = "lblRefrigerant";
            this.lblRefrigerant.Size = new System.Drawing.Size(48, 13);
            this.lblRefrigerant.TabIndex = 8;
            this.lblRefrigerant.Text = "label11";
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.AutoSize = true;
            this.lblManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManufacturer.Location = new System.Drawing.Point(6, 94);
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.Size = new System.Drawing.Size(48, 13);
            this.lblManufacturer.TabIndex = 7;
            this.lblManufacturer.Text = "label10";
            // 
            // lblLRA
            // 
            this.lblLRA.AutoSize = true;
            this.lblLRA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLRA.Location = new System.Drawing.Point(6, 72);
            this.lblLRA.Name = "lblLRA";
            this.lblLRA.Size = new System.Drawing.Size(41, 13);
            this.lblLRA.TabIndex = 6;
            this.lblLRA.Text = "label9";
            // 
            // lblRLA
            // 
            this.lblRLA.AutoSize = true;
            this.lblRLA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRLA.Location = new System.Drawing.Point(6, 49);
            this.lblRLA.Name = "lblRLA";
            this.lblRLA.Size = new System.Drawing.Size(41, 13);
            this.lblRLA.TabIndex = 5;
            this.lblRLA.Text = "label8";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(6, 27);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(41, 13);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "label7";
            // 
            // lblCompressorSelected
            // 
            this.lblCompressorSelected.AutoSize = true;
            this.lblCompressorSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompressorSelected.Location = new System.Drawing.Point(9, 65);
            this.lblCompressorSelected.Name = "lblCompressorSelected";
            this.lblCompressorSelected.Size = new System.Drawing.Size(41, 13);
            this.lblCompressorSelected.TabIndex = 2;
            this.lblCompressorSelected.Text = "label3";
            // 
            // grpPolynomials
            // 
            this.grpPolynomials.Controls.Add(this.lblPower9Value);
            this.grpPolynomials.Controls.Add(this.lblCapacity1Value);
            this.grpPolynomials.Controls.Add(this.lblPower3Value);
            this.grpPolynomials.Controls.Add(this.lblCapacity8Value);
            this.grpPolynomials.Controls.Add(this.lblPower8Value);
            this.grpPolynomials.Controls.Add(this.lblCapacity9Value);
            this.grpPolynomials.Controls.Add(this.lblPower4Value);
            this.grpPolynomials.Controls.Add(this.lblCapacity10Value);
            this.grpPolynomials.Controls.Add(this.lblPower7Value);
            this.grpPolynomials.Controls.Add(this.lblPower1Value);
            this.grpPolynomials.Controls.Add(this.lblPower5Value);
            this.grpPolynomials.Controls.Add(this.lblCapacity4Value);
            this.grpPolynomials.Controls.Add(this.lblPower6Value);
            this.grpPolynomials.Controls.Add(this.lblPower2Value);
            this.grpPolynomials.Controls.Add(this.lblPower10Value);
            this.grpPolynomials.Controls.Add(this.lblCapacity3Value);
            this.grpPolynomials.Controls.Add(this.lblCapacity7Value);
            this.grpPolynomials.Controls.Add(this.lblCapacity5Value);
            this.grpPolynomials.Controls.Add(this.lblCapacity2Value);
            this.grpPolynomials.Controls.Add(this.lblCapacity6Value);
            this.grpPolynomials.Controls.Add(this.lblPower9);
            this.grpPolynomials.Controls.Add(this.lblCapacity1);
            this.grpPolynomials.Controls.Add(this.lblPower3);
            this.grpPolynomials.Controls.Add(this.lblCapacity8);
            this.grpPolynomials.Controls.Add(this.lblPower8);
            this.grpPolynomials.Controls.Add(this.lblCapacity9);
            this.grpPolynomials.Controls.Add(this.lblPower4);
            this.grpPolynomials.Controls.Add(this.lblCapacity10);
            this.grpPolynomials.Controls.Add(this.lblPower7);
            this.grpPolynomials.Controls.Add(this.lblPower1);
            this.grpPolynomials.Controls.Add(this.lblPower5);
            this.grpPolynomials.Controls.Add(this.lblCapacity4);
            this.grpPolynomials.Controls.Add(this.lblPower6);
            this.grpPolynomials.Controls.Add(this.lblPower2);
            this.grpPolynomials.Controls.Add(this.lblPower10);
            this.grpPolynomials.Controls.Add(this.lblCapacity3);
            this.grpPolynomials.Controls.Add(this.lblCapacity7);
            this.grpPolynomials.Controls.Add(this.lblCapacity5);
            this.grpPolynomials.Controls.Add(this.lblCapacity2);
            this.grpPolynomials.Controls.Add(this.lblCapacity6);
            this.grpPolynomials.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPolynomials.Location = new System.Drawing.Point(373, 47);
            this.grpPolynomials.Name = "grpPolynomials";
            this.grpPolynomials.Size = new System.Drawing.Size(272, 466);
            this.grpPolynomials.TabIndex = 0;
            this.grpPolynomials.TabStop = false;
            this.grpPolynomials.Text = "Polynomials";
            // 
            // lblPower9Value
            // 
            this.lblPower9Value.AutoSize = true;
            this.lblPower9Value.Location = new System.Drawing.Point(171, 418);
            this.lblPower9Value.Name = "lblPower9Value";
            this.lblPower9Value.Size = new System.Drawing.Size(0, 13);
            this.lblPower9Value.TabIndex = 58;
            // 
            // lblCapacity1Value
            // 
            this.lblCapacity1Value.AutoSize = true;
            this.lblCapacity1Value.Location = new System.Drawing.Point(171, 16);
            this.lblCapacity1Value.Name = "lblCapacity1Value";
            this.lblCapacity1Value.Size = new System.Drawing.Size(0, 13);
            this.lblCapacity1Value.TabIndex = 40;
            // 
            // lblPower3Value
            // 
            this.lblPower3Value.AutoSize = true;
            this.lblPower3Value.Location = new System.Drawing.Point(171, 285);
            this.lblPower3Value.Name = "lblPower3Value";
            this.lblPower3Value.Size = new System.Drawing.Size(0, 13);
            this.lblPower3Value.TabIndex = 52;
            // 
            // lblCapacity8Value
            // 
            this.lblCapacity8Value.AutoSize = true;
            this.lblCapacity8Value.Location = new System.Drawing.Point(171, 171);
            this.lblCapacity8Value.Name = "lblCapacity8Value";
            this.lblCapacity8Value.Size = new System.Drawing.Size(0, 13);
            this.lblCapacity8Value.TabIndex = 47;
            // 
            // lblPower8Value
            // 
            this.lblPower8Value.AutoSize = true;
            this.lblPower8Value.Location = new System.Drawing.Point(171, 396);
            this.lblPower8Value.Name = "lblPower8Value";
            this.lblPower8Value.Size = new System.Drawing.Size(0, 13);
            this.lblPower8Value.TabIndex = 57;
            // 
            // lblCapacity9Value
            // 
            this.lblCapacity9Value.AutoSize = true;
            this.lblCapacity9Value.Location = new System.Drawing.Point(171, 193);
            this.lblCapacity9Value.Name = "lblCapacity9Value";
            this.lblCapacity9Value.Size = new System.Drawing.Size(0, 13);
            this.lblCapacity9Value.TabIndex = 48;
            // 
            // lblPower4Value
            // 
            this.lblPower4Value.AutoSize = true;
            this.lblPower4Value.Location = new System.Drawing.Point(171, 307);
            this.lblPower4Value.Name = "lblPower4Value";
            this.lblPower4Value.Size = new System.Drawing.Size(0, 13);
            this.lblPower4Value.TabIndex = 53;
            // 
            // lblCapacity10Value
            // 
            this.lblCapacity10Value.AutoSize = true;
            this.lblCapacity10Value.Location = new System.Drawing.Point(171, 216);
            this.lblCapacity10Value.Name = "lblCapacity10Value";
            this.lblCapacity10Value.Size = new System.Drawing.Size(0, 13);
            this.lblCapacity10Value.TabIndex = 49;
            // 
            // lblPower7Value
            // 
            this.lblPower7Value.AutoSize = true;
            this.lblPower7Value.Location = new System.Drawing.Point(171, 374);
            this.lblPower7Value.Name = "lblPower7Value";
            this.lblPower7Value.Size = new System.Drawing.Size(0, 13);
            this.lblPower7Value.TabIndex = 56;
            // 
            // lblPower1Value
            // 
            this.lblPower1Value.AutoSize = true;
            this.lblPower1Value.Location = new System.Drawing.Point(171, 238);
            this.lblPower1Value.Name = "lblPower1Value";
            this.lblPower1Value.Size = new System.Drawing.Size(0, 13);
            this.lblPower1Value.TabIndex = 50;
            // 
            // lblPower5Value
            // 
            this.lblPower5Value.AutoSize = true;
            this.lblPower5Value.Location = new System.Drawing.Point(171, 330);
            this.lblPower5Value.Name = "lblPower5Value";
            this.lblPower5Value.Size = new System.Drawing.Size(0, 13);
            this.lblPower5Value.TabIndex = 54;
            // 
            // lblCapacity4Value
            // 
            this.lblCapacity4Value.AutoSize = true;
            this.lblCapacity4Value.Location = new System.Drawing.Point(171, 83);
            this.lblCapacity4Value.Name = "lblCapacity4Value";
            this.lblCapacity4Value.Size = new System.Drawing.Size(0, 13);
            this.lblCapacity4Value.TabIndex = 43;
            // 
            // lblPower6Value
            // 
            this.lblPower6Value.AutoSize = true;
            this.lblPower6Value.Location = new System.Drawing.Point(171, 352);
            this.lblPower6Value.Name = "lblPower6Value";
            this.lblPower6Value.Size = new System.Drawing.Size(0, 13);
            this.lblPower6Value.TabIndex = 55;
            // 
            // lblPower2Value
            // 
            this.lblPower2Value.AutoSize = true;
            this.lblPower2Value.Location = new System.Drawing.Point(171, 260);
            this.lblPower2Value.Name = "lblPower2Value";
            this.lblPower2Value.Size = new System.Drawing.Size(0, 13);
            this.lblPower2Value.TabIndex = 51;
            // 
            // lblPower10Value
            // 
            this.lblPower10Value.AutoSize = true;
            this.lblPower10Value.Location = new System.Drawing.Point(171, 440);
            this.lblPower10Value.Name = "lblPower10Value";
            this.lblPower10Value.Size = new System.Drawing.Size(0, 13);
            this.lblPower10Value.TabIndex = 59;
            // 
            // lblCapacity3Value
            // 
            this.lblCapacity3Value.AutoSize = true;
            this.lblCapacity3Value.Location = new System.Drawing.Point(171, 61);
            this.lblCapacity3Value.Name = "lblCapacity3Value";
            this.lblCapacity3Value.Size = new System.Drawing.Size(0, 13);
            this.lblCapacity3Value.TabIndex = 42;
            // 
            // lblCapacity7Value
            // 
            this.lblCapacity7Value.AutoSize = true;
            this.lblCapacity7Value.Location = new System.Drawing.Point(171, 149);
            this.lblCapacity7Value.Name = "lblCapacity7Value";
            this.lblCapacity7Value.Size = new System.Drawing.Size(0, 13);
            this.lblCapacity7Value.TabIndex = 46;
            // 
            // lblCapacity5Value
            // 
            this.lblCapacity5Value.AutoSize = true;
            this.lblCapacity5Value.Location = new System.Drawing.Point(171, 105);
            this.lblCapacity5Value.Name = "lblCapacity5Value";
            this.lblCapacity5Value.Size = new System.Drawing.Size(0, 13);
            this.lblCapacity5Value.TabIndex = 44;
            // 
            // lblCapacity2Value
            // 
            this.lblCapacity2Value.AutoSize = true;
            this.lblCapacity2Value.Location = new System.Drawing.Point(171, 38);
            this.lblCapacity2Value.Name = "lblCapacity2Value";
            this.lblCapacity2Value.Size = new System.Drawing.Size(0, 13);
            this.lblCapacity2Value.TabIndex = 41;
            // 
            // lblCapacity6Value
            // 
            this.lblCapacity6Value.AutoSize = true;
            this.lblCapacity6Value.Location = new System.Drawing.Point(171, 127);
            this.lblCapacity6Value.Name = "lblCapacity6Value";
            this.lblCapacity6Value.Size = new System.Drawing.Size(0, 13);
            this.lblCapacity6Value.TabIndex = 45;
            // 
            // lblPower9
            // 
            this.lblPower9.AutoSize = true;
            this.lblPower9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPower9.Location = new System.Drawing.Point(17, 418);
            this.lblPower9.Name = "lblPower9";
            this.lblPower9.Size = new System.Drawing.Size(48, 13);
            this.lblPower9.TabIndex = 38;
            this.lblPower9.Text = "label35";
            // 
            // lblCapacity1
            // 
            this.lblCapacity1.AutoSize = true;
            this.lblCapacity1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapacity1.Location = new System.Drawing.Point(17, 16);
            this.lblCapacity1.Name = "lblCapacity1";
            this.lblCapacity1.Size = new System.Drawing.Size(48, 13);
            this.lblCapacity1.TabIndex = 18;
            this.lblCapacity1.Text = "label27";
            // 
            // lblPower3
            // 
            this.lblPower3.AutoSize = true;
            this.lblPower3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPower3.Location = new System.Drawing.Point(17, 285);
            this.lblPower3.Name = "lblPower3";
            this.lblPower3.Size = new System.Drawing.Size(48, 13);
            this.lblPower3.TabIndex = 32;
            this.lblPower3.Text = "label36";
            // 
            // lblCapacity8
            // 
            this.lblCapacity8.AutoSize = true;
            this.lblCapacity8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapacity8.Location = new System.Drawing.Point(17, 171);
            this.lblCapacity8.Name = "lblCapacity8";
            this.lblCapacity8.Size = new System.Drawing.Size(48, 13);
            this.lblCapacity8.TabIndex = 25;
            this.lblCapacity8.Text = "label34";
            // 
            // lblPower8
            // 
            this.lblPower8.AutoSize = true;
            this.lblPower8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPower8.Location = new System.Drawing.Point(17, 396);
            this.lblPower8.Name = "lblPower8";
            this.lblPower8.Size = new System.Drawing.Size(48, 13);
            this.lblPower8.TabIndex = 37;
            this.lblPower8.Text = "label37";
            // 
            // lblCapacity9
            // 
            this.lblCapacity9.AutoSize = true;
            this.lblCapacity9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapacity9.Location = new System.Drawing.Point(17, 193);
            this.lblCapacity9.Name = "lblCapacity9";
            this.lblCapacity9.Size = new System.Drawing.Size(48, 13);
            this.lblCapacity9.TabIndex = 26;
            this.lblCapacity9.Text = "label33";
            // 
            // lblPower4
            // 
            this.lblPower4.AutoSize = true;
            this.lblPower4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPower4.Location = new System.Drawing.Point(17, 307);
            this.lblPower4.Name = "lblPower4";
            this.lblPower4.Size = new System.Drawing.Size(48, 13);
            this.lblPower4.TabIndex = 33;
            this.lblPower4.Text = "label38";
            // 
            // lblCapacity10
            // 
            this.lblCapacity10.AutoSize = true;
            this.lblCapacity10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapacity10.Location = new System.Drawing.Point(17, 216);
            this.lblCapacity10.Name = "lblCapacity10";
            this.lblCapacity10.Size = new System.Drawing.Size(48, 13);
            this.lblCapacity10.TabIndex = 27;
            this.lblCapacity10.Text = "label32";
            // 
            // lblPower7
            // 
            this.lblPower7.AutoSize = true;
            this.lblPower7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPower7.Location = new System.Drawing.Point(17, 374);
            this.lblPower7.Name = "lblPower7";
            this.lblPower7.Size = new System.Drawing.Size(48, 13);
            this.lblPower7.TabIndex = 36;
            this.lblPower7.Text = "label39";
            // 
            // lblPower1
            // 
            this.lblPower1.AutoSize = true;
            this.lblPower1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPower1.Location = new System.Drawing.Point(17, 238);
            this.lblPower1.Name = "lblPower1";
            this.lblPower1.Size = new System.Drawing.Size(48, 13);
            this.lblPower1.TabIndex = 28;
            this.lblPower1.Text = "label31";
            // 
            // lblPower5
            // 
            this.lblPower5.AutoSize = true;
            this.lblPower5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPower5.Location = new System.Drawing.Point(17, 330);
            this.lblPower5.Name = "lblPower5";
            this.lblPower5.Size = new System.Drawing.Size(48, 13);
            this.lblPower5.TabIndex = 34;
            this.lblPower5.Text = "label40";
            // 
            // lblCapacity4
            // 
            this.lblCapacity4.AutoSize = true;
            this.lblCapacity4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapacity4.Location = new System.Drawing.Point(17, 83);
            this.lblCapacity4.Name = "lblCapacity4";
            this.lblCapacity4.Size = new System.Drawing.Size(48, 13);
            this.lblCapacity4.TabIndex = 21;
            this.lblCapacity4.Text = "label24";
            // 
            // lblPower6
            // 
            this.lblPower6.AutoSize = true;
            this.lblPower6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPower6.Location = new System.Drawing.Point(17, 352);
            this.lblPower6.Name = "lblPower6";
            this.lblPower6.Size = new System.Drawing.Size(48, 13);
            this.lblPower6.TabIndex = 35;
            this.lblPower6.Text = "label41";
            // 
            // lblPower2
            // 
            this.lblPower2.AutoSize = true;
            this.lblPower2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPower2.Location = new System.Drawing.Point(17, 260);
            this.lblPower2.Name = "lblPower2";
            this.lblPower2.Size = new System.Drawing.Size(48, 13);
            this.lblPower2.TabIndex = 29;
            this.lblPower2.Text = "label30";
            // 
            // lblPower10
            // 
            this.lblPower10.AutoSize = true;
            this.lblPower10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPower10.Location = new System.Drawing.Point(17, 440);
            this.lblPower10.Name = "lblPower10";
            this.lblPower10.Size = new System.Drawing.Size(48, 13);
            this.lblPower10.TabIndex = 39;
            this.lblPower10.Text = "label42";
            // 
            // lblCapacity3
            // 
            this.lblCapacity3.AutoSize = true;
            this.lblCapacity3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapacity3.Location = new System.Drawing.Point(17, 61);
            this.lblCapacity3.Name = "lblCapacity3";
            this.lblCapacity3.Size = new System.Drawing.Size(48, 13);
            this.lblCapacity3.TabIndex = 20;
            this.lblCapacity3.Text = "label25";
            // 
            // lblCapacity7
            // 
            this.lblCapacity7.AutoSize = true;
            this.lblCapacity7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapacity7.Location = new System.Drawing.Point(17, 149);
            this.lblCapacity7.Name = "lblCapacity7";
            this.lblCapacity7.Size = new System.Drawing.Size(48, 13);
            this.lblCapacity7.TabIndex = 24;
            this.lblCapacity7.Text = "label21";
            // 
            // lblCapacity5
            // 
            this.lblCapacity5.AutoSize = true;
            this.lblCapacity5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapacity5.Location = new System.Drawing.Point(17, 105);
            this.lblCapacity5.Name = "lblCapacity5";
            this.lblCapacity5.Size = new System.Drawing.Size(48, 13);
            this.lblCapacity5.TabIndex = 22;
            this.lblCapacity5.Text = "label23";
            // 
            // lblCapacity2
            // 
            this.lblCapacity2.AutoSize = true;
            this.lblCapacity2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapacity2.Location = new System.Drawing.Point(17, 38);
            this.lblCapacity2.Name = "lblCapacity2";
            this.lblCapacity2.Size = new System.Drawing.Size(48, 13);
            this.lblCapacity2.TabIndex = 19;
            this.lblCapacity2.Text = "label26";
            // 
            // lblCapacity6
            // 
            this.lblCapacity6.AutoSize = true;
            this.lblCapacity6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapacity6.Location = new System.Drawing.Point(17, 127);
            this.lblCapacity6.Name = "lblCapacity6";
            this.lblCapacity6.Size = new System.Drawing.Size(48, 13);
            this.lblCapacity6.TabIndex = 23;
            this.lblCapacity6.Text = "label22";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 569);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 999;
            this.btnSave.Text = "sSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpMotor
            // 
            this.grpMotor.Controls.Add(this.llblMotorPounds);
            this.grpMotor.Controls.Add(this.lblFarenheit);
            this.grpMotor.Controls.Add(this.lblMotorValue);
            this.grpMotor.Controls.Add(this.txtTempMax);
            this.grpMotor.Controls.Add(this.lblMotor);
            this.grpMotor.Controls.Add(this.cboMotorType);
            this.grpMotor.Controls.Add(this.txtTempMin);
            this.grpMotor.Controls.Add(this.label11);
            this.grpMotor.Controls.Add(this.nUdFLA);
            this.grpMotor.Controls.Add(this.cboVoltage);
            this.grpMotor.Controls.Add(this.nUdRPM);
            this.grpMotor.Controls.Add(this.nUdHP);
            this.grpMotor.Controls.Add(this.nUdMotorWeight);
            this.grpMotor.Controls.Add(this.lblMotorType);
            this.grpMotor.Controls.Add(this.lblWeightMotor);
            this.grpMotor.Controls.Add(this.btnDeleteRow);
            this.grpMotor.Controls.Add(this.btnAddRow);
            this.grpMotor.Controls.Add(this.dgCFM);
            this.grpMotor.Controls.Add(this.lblTempRange);
            this.grpMotor.Controls.Add(this.lblRPM);
            this.grpMotor.Controls.Add(this.lblVoltageMotor);
            this.grpMotor.Controls.Add(this.lblHP);
            this.grpMotor.Controls.Add(this.lblFLA);
            this.grpMotor.Location = new System.Drawing.Point(10, 12);
            this.grpMotor.Name = "grpMotor";
            this.grpMotor.Size = new System.Drawing.Size(300, 543);
            this.grpMotor.TabIndex = 6;
            this.grpMotor.TabStop = false;
            this.grpMotor.Text = "groupBox1";
            // 
            // llblMotorPounds
            // 
            this.llblMotorPounds.AutoSize = true;
            this.llblMotorPounds.Location = new System.Drawing.Point(263, 517);
            this.llblMotorPounds.Name = "llblMotorPounds";
            this.llblMotorPounds.Size = new System.Drawing.Size(20, 13);
            this.llblMotorPounds.TabIndex = 64;
            this.llblMotorPounds.Text = "lbs";
            // 
            // lblFarenheit
            // 
            this.lblFarenheit.AutoSize = true;
            this.lblFarenheit.Location = new System.Drawing.Point(253, 166);
            this.lblFarenheit.Name = "lblFarenheit";
            this.lblFarenheit.Size = new System.Drawing.Size(20, 13);
            this.lblFarenheit.TabIndex = 63;
            this.lblFarenheit.Text = "º F";
            // 
            // lblMotorValue
            // 
            this.lblMotorValue.AutoSize = true;
            this.lblMotorValue.Location = new System.Drawing.Point(114, 25);
            this.lblMotorValue.Name = "lblMotorValue";
            this.lblMotorValue.Size = new System.Drawing.Size(0, 13);
            this.lblMotorValue.TabIndex = 62;
            // 
            // txtTempMax
            // 
            this.txtTempMax.Location = new System.Drawing.Point(207, 163);
            this.txtTempMax.Name = "txtTempMax";
            this.txtTempMax.Size = new System.Drawing.Size(40, 20);
            this.txtTempMax.TabIndex = 6;
            this.txtTempMax.Enter += new System.EventHandler(this.txtTempMax_Enter);
            // 
            // lblMotor
            // 
            this.lblMotor.AutoSize = true;
            this.lblMotor.Location = new System.Drawing.Point(7, 25);
            this.lblMotor.Name = "lblMotor";
            this.lblMotor.Size = new System.Drawing.Size(41, 13);
            this.lblMotor.TabIndex = 60;
            this.lblMotor.Text = "label44";
            // 
            // cboMotorType
            // 
            this.cboMotorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotorType.FormattingEnabled = true;
            this.cboMotorType.Items.AddRange(new object[] {
            "TEAO - Inverter Duty",
            "TEAO - Standard Duty",
            "TEFC - Inverter Duty",
            "TEFC - Standard Duty",
            "ODP - Inverter Duty",
            "ODP - Standard Duty"});
            this.cboMotorType.Location = new System.Drawing.Point(117, 190);
            this.cboMotorType.Name = "cboMotorType";
            this.cboMotorType.Size = new System.Drawing.Size(130, 21);
            this.cboMotorType.TabIndex = 7;
            // 
            // txtTempMin
            // 
            this.txtTempMin.Location = new System.Drawing.Point(117, 163);
            this.txtTempMin.Name = "txtTempMin";
            this.txtTempMin.Size = new System.Drawing.Size(40, 20);
            this.txtTempMin.TabIndex = 5;
            this.txtTempMin.Enter += new System.EventHandler(this.txtTempMin_Enter);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(163, 166);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 42;
            this.label11.Text = "label11";
            // 
            // nUdFLA
            // 
            this.nUdFLA.DecimalPlaces = 2;
            this.nUdFLA.Location = new System.Drawing.Point(117, 133);
            this.nUdFLA.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nUdFLA.Name = "nUdFLA";
            this.nUdFLA.Size = new System.Drawing.Size(130, 20);
            this.nUdFLA.TabIndex = 4;
            this.nUdFLA.Enter += new System.EventHandler(this.nUdFLA_Enter);
            // 
            // cboVoltage
            // 
            this.cboVoltage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVoltage.FormattingEnabled = true;
            this.cboVoltage.Items.AddRange(new object[] {
            "120/1/60",
            "240/1/60",
            "208-240/3/60",
            "200/3/50",
            "480/3/60",
            "400/3/50",
            "575/3/60"});
            this.cboVoltage.Location = new System.Drawing.Point(117, 103);
            this.cboVoltage.Name = "cboVoltage";
            this.cboVoltage.Size = new System.Drawing.Size(130, 21);
            this.cboVoltage.TabIndex = 3;
            // 
            // nUdRPM
            // 
            this.nUdRPM.Location = new System.Drawing.Point(117, 75);
            this.nUdRPM.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nUdRPM.Name = "nUdRPM";
            this.nUdRPM.Size = new System.Drawing.Size(130, 20);
            this.nUdRPM.TabIndex = 2;
            this.nUdRPM.Enter += new System.EventHandler(this.nUdRPM_Enter);
            // 
            // nUdHP
            // 
            this.nUdHP.DecimalPlaces = 3;
            this.nUdHP.Location = new System.Drawing.Point(117, 47);
            this.nUdHP.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nUdHP.Name = "nUdHP";
            this.nUdHP.Size = new System.Drawing.Size(130, 20);
            this.nUdHP.TabIndex = 1;
            this.nUdHP.Enter += new System.EventHandler(this.nUdHP_Enter);
            // 
            // nUdMotorWeight
            // 
            this.nUdMotorWeight.Location = new System.Drawing.Point(71, 515);
            this.nUdMotorWeight.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nUdMotorWeight.Name = "nUdMotorWeight";
            this.nUdMotorWeight.Size = new System.Drawing.Size(186, 20);
            this.nUdMotorWeight.TabIndex = 10;
            this.nUdMotorWeight.Enter += new System.EventHandler(this.nUdMotorWeight_Enter);
            // 
            // lblMotorType
            // 
            this.lblMotorType.AutoSize = true;
            this.lblMotorType.Location = new System.Drawing.Point(7, 193);
            this.lblMotorType.Name = "lblMotorType";
            this.lblMotorType.Size = new System.Drawing.Size(35, 13);
            this.lblMotorType.TabIndex = 5;
            this.lblMotorType.Text = "label8";
            // 
            // lblWeightMotor
            // 
            this.lblWeightMotor.AutoSize = true;
            this.lblWeightMotor.Location = new System.Drawing.Point(6, 517);
            this.lblWeightMotor.Name = "lblWeightMotor";
            this.lblWeightMotor.Size = new System.Drawing.Size(35, 13);
            this.lblWeightMotor.TabIndex = 36;
            this.lblWeightMotor.Text = "label3";
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteRow.Location = new System.Drawing.Point(12, 483);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(245, 23);
            this.btnDeleteRow.TabIndex = 9;
            this.btnDeleteRow.Text = "sRemove Row";
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRow.Location = new System.Drawing.Point(12, 454);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(245, 23);
            this.btnAddRow.TabIndex = 8;
            this.btnAddRow.Text = "sAdd Row";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // dgCFM
            // 
            this.dgCFM.AllowUserToAddRows = false;
            this.dgCFM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCFM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CoilModel,
            this.CFM});
            this.dgCFM.Location = new System.Drawing.Point(9, 220);
            this.dgCFM.Name = "dgCFM";
            this.dgCFM.Size = new System.Drawing.Size(240, 225);
            this.dgCFM.TabIndex = 7;
            // 
            // CoilModel
            // 
            this.CoilModel.HeaderText = "Coil Model";
            this.CoilModel.Name = "CoilModel";
            this.CoilModel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CoilModel.Width = 50;
            // 
            // CFM
            // 
            this.CFM.HeaderText = "CFM";
            this.CFM.Name = "CFM";
            this.CFM.Width = 50;
            // 
            // lblTempRange
            // 
            this.lblTempRange.AutoSize = true;
            this.lblTempRange.Location = new System.Drawing.Point(7, 166);
            this.lblTempRange.Name = "lblTempRange";
            this.lblTempRange.Size = new System.Drawing.Size(35, 13);
            this.lblTempRange.TabIndex = 4;
            this.lblTempRange.Text = "label7";
            // 
            // lblRPM
            // 
            this.lblRPM.AutoSize = true;
            this.lblRPM.Location = new System.Drawing.Point(7, 77);
            this.lblRPM.Name = "lblRPM";
            this.lblRPM.Size = new System.Drawing.Size(35, 13);
            this.lblRPM.TabIndex = 1;
            this.lblRPM.Text = "label4";
            // 
            // lblVoltageMotor
            // 
            this.lblVoltageMotor.AutoSize = true;
            this.lblVoltageMotor.Location = new System.Drawing.Point(7, 106);
            this.lblVoltageMotor.Name = "lblVoltageMotor";
            this.lblVoltageMotor.Size = new System.Drawing.Size(35, 13);
            this.lblVoltageMotor.TabIndex = 2;
            this.lblVoltageMotor.Text = "label5";
            // 
            // lblHP
            // 
            this.lblHP.AutoSize = true;
            this.lblHP.Location = new System.Drawing.Point(7, 49);
            this.lblHP.Name = "lblHP";
            this.lblHP.Size = new System.Drawing.Size(35, 13);
            this.lblHP.TabIndex = 0;
            this.lblHP.Text = "label3";
            // 
            // lblFLA
            // 
            this.lblFLA.AutoSize = true;
            this.lblFLA.Location = new System.Drawing.Point(7, 136);
            this.lblFLA.Name = "lblFLA";
            this.lblFLA.Size = new System.Drawing.Size(35, 13);
            this.lblFLA.TabIndex = 3;
            this.lblFLA.Text = "label6";
            // 
            // grpCoil
            // 
            this.grpCoil.Controls.Add(this.cboSubCoolerCircuits);
            this.grpCoil.Controls.Add(this.txtModel);
            this.grpCoil.Controls.Add(this.label21);
            this.grpCoil.Controls.Add(this.nUdCoilWeight);
            this.grpCoil.Controls.Add(this.lblCoilWeight);
            this.grpCoil.Controls.Add(this.lblSubCoolerCircuits);
            this.grpCoil.Controls.Add(this.nUdFaceTube);
            this.grpCoil.Controls.Add(this.lblFaceTube);
            this.grpCoil.Controls.Add(this.cboSubCooler);
            this.grpCoil.Controls.Add(this.lblSubCooler);
            this.grpCoil.Controls.Add(this.cboCircuits);
            this.grpCoil.Controls.Add(this.lblCircuits);
            this.grpCoil.Controls.Add(this.nUdFanLong);
            this.grpCoil.Controls.Add(this.lblFanLong);
            this.grpCoil.Controls.Add(this.lblCoilModel);
            this.grpCoil.Controls.Add(this.nUdFanWide);
            this.grpCoil.Controls.Add(this.lblFanWide);
            this.grpCoil.Controls.Add(this.cboFPI);
            this.grpCoil.Controls.Add(this.cboFinHeight);
            this.grpCoil.Controls.Add(this.nUdRows);
            this.grpCoil.Controls.Add(this.nUdFinLength);
            this.grpCoil.Controls.Add(this.cboFinThickness);
            this.grpCoil.Controls.Add(this.lblFinThickness);
            this.grpCoil.Controls.Add(this.cboFinMaterial);
            this.grpCoil.Controls.Add(this.lblFinMaterial);
            this.grpCoil.Controls.Add(this.cboTubeThickness);
            this.grpCoil.Controls.Add(this.lblTubeThickness);
            this.grpCoil.Controls.Add(this.cboTubeMaterial);
            this.grpCoil.Controls.Add(this.lblTubeMaterial);
            this.grpCoil.Controls.Add(this.lblFPI);
            this.grpCoil.Controls.Add(this.lblRow);
            this.grpCoil.Controls.Add(this.lblFinLength);
            this.grpCoil.Controls.Add(this.lblFinHeight);
            this.grpCoil.Controls.Add(this.cboFinShape);
            this.grpCoil.Controls.Add(this.lblFinShape);
            this.grpCoil.Controls.Add(this.cboFinType);
            this.grpCoil.Controls.Add(this.lblFinType);
            this.grpCoil.Location = new System.Drawing.Point(7, 12);
            this.grpCoil.Name = "grpCoil";
            this.grpCoil.Size = new System.Drawing.Size(291, 531);
            this.grpCoil.TabIndex = 7;
            this.grpCoil.TabStop = false;
            this.grpCoil.Text = "groupBox1";
            // 
            // cboSubCoolerCircuits
            // 
            this.cboSubCoolerCircuits.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSubCoolerCircuits.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSubCoolerCircuits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubCoolerCircuits.Enabled = false;
            this.cboSubCoolerCircuits.FormattingEnabled = true;
            this.cboSubCoolerCircuits.Items.AddRange(new object[] {
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
            "96",
            "97",
            "98",
            "99",
            "100",
            "101",
            "102",
            "103",
            "104",
            "105",
            "106",
            "107",
            "108",
            "109",
            "110",
            "111",
            "112",
            "113",
            "114",
            "115",
            "116",
            "117",
            "118",
            "119",
            "120",
            "121",
            "122",
            "123",
            "124",
            "125",
            "126",
            "127",
            "128",
            "129",
            "130",
            "131",
            "132",
            "133",
            "134",
            "135",
            "136",
            "137",
            "138",
            "139",
            "140",
            "141",
            "142",
            "143",
            "144",
            "145",
            "146",
            "147",
            "148",
            "149",
            "150",
            "151",
            "152",
            "153",
            "154",
            "155",
            "156",
            "157",
            "158",
            "159",
            "160",
            "161",
            "162",
            "163",
            "164",
            "165",
            "166",
            "167",
            "168",
            "169",
            "170",
            "171",
            "172",
            "173",
            "174",
            "175",
            "176",
            "177",
            "178",
            "179",
            "180",
            "181",
            "182",
            "183",
            "184",
            "185",
            "186",
            "187",
            "188",
            "189",
            "190",
            "191",
            "192",
            "193",
            "194",
            "195",
            "196",
            "197",
            "198",
            "199",
            "200",
            "201",
            "202",
            "203",
            "204",
            "205",
            "206",
            "207",
            "208",
            "209",
            "210",
            "211",
            "212",
            "213",
            "214",
            "215",
            "216",
            "217",
            "218",
            "219",
            "220",
            "221",
            "222",
            "223",
            "224",
            "225",
            "226",
            "227",
            "228",
            "229",
            "230",
            "231",
            "232",
            "233",
            "234",
            "235",
            "236",
            "237",
            "238",
            "239",
            "240",
            "241",
            "242",
            "243",
            "244",
            "245",
            "246",
            "247",
            "248",
            "249",
            "250",
            "251",
            "252",
            "253",
            "254",
            "255",
            "256",
            "257",
            "258",
            "259",
            "260",
            "261",
            "262",
            "263",
            "264",
            "265",
            "266",
            "267",
            "268",
            "269",
            "270",
            "271",
            "272",
            "273",
            "274",
            "275",
            "276",
            "277",
            "278",
            "279",
            "280",
            "281",
            "282",
            "283",
            "284",
            "285",
            "286",
            "287",
            "288",
            "289",
            "290",
            "291",
            "292",
            "293",
            "294",
            "295",
            "296",
            "297",
            "298",
            "299",
            "300",
            "301",
            "302",
            "303",
            "304",
            "305",
            "306",
            "307",
            "308",
            "309",
            "310",
            "311",
            "312",
            "313",
            "314",
            "315",
            "316",
            "317",
            "318",
            "319",
            "320",
            "321",
            "322",
            "323",
            "324",
            "325",
            "326",
            "327",
            "328",
            "329",
            "330",
            "331",
            "332",
            "333",
            "334",
            "335",
            "336",
            "337",
            "338",
            "339",
            "340",
            "341",
            "342",
            "343",
            "344",
            "345",
            "346",
            "347",
            "348",
            "349",
            "350"});
            this.cboSubCoolerCircuits.Location = new System.Drawing.Point(116, 471);
            this.cboSubCoolerCircuits.Name = "cboSubCoolerCircuits";
            this.cboSubCoolerCircuits.Size = new System.Drawing.Size(153, 21);
            this.cboSubCoolerCircuits.TabIndex = 16;
            this.cboSubCoolerCircuits.SelectedIndexChanged += new System.EventHandler(this.cboSubCoolerCircuits_SelectedIndexChanged);
            // 
            // txtModel
            // 
            this.txtModel.Enabled = false;
            this.txtModel.Location = new System.Drawing.Point(23, 35);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(246, 20);
            this.txtModel.TabIndex = 126;
            this.txtModel.TabStop = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(253, 503);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(20, 13);
            this.label21.TabIndex = 68;
            this.label21.Text = "lbs";
            // 
            // nUdCoilWeight
            // 
            this.nUdCoilWeight.DecimalPlaces = 2;
            this.nUdCoilWeight.Enabled = false;
            this.nUdCoilWeight.Location = new System.Drawing.Point(116, 501);
            this.nUdCoilWeight.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nUdCoilWeight.Name = "nUdCoilWeight";
            this.nUdCoilWeight.Size = new System.Drawing.Size(131, 20);
            this.nUdCoilWeight.TabIndex = 17;
            this.nUdCoilWeight.Enter += new System.EventHandler(this.nUdCoilWeight_Enter);
            // 
            // lblCoilWeight
            // 
            this.lblCoilWeight.AutoSize = true;
            this.lblCoilWeight.Location = new System.Drawing.Point(20, 503);
            this.lblCoilWeight.Name = "lblCoilWeight";
            this.lblCoilWeight.Size = new System.Drawing.Size(35, 13);
            this.lblCoilWeight.TabIndex = 66;
            this.lblCoilWeight.Text = "label3";
            // 
            // lblSubCoolerCircuits
            // 
            this.lblSubCoolerCircuits.AutoSize = true;
            this.lblSubCoolerCircuits.Location = new System.Drawing.Point(17, 468);
            this.lblSubCoolerCircuits.Name = "lblSubCoolerCircuits";
            this.lblSubCoolerCircuits.Size = new System.Drawing.Size(41, 13);
            this.lblSubCoolerCircuits.TabIndex = 125;
            this.lblSubCoolerCircuits.Text = "Circuits";
            // 
            // nUdFaceTube
            // 
            this.nUdFaceTube.Enabled = false;
            this.nUdFaceTube.Location = new System.Drawing.Point(116, 440);
            this.nUdFaceTube.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nUdFaceTube.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUdFaceTube.Name = "nUdFaceTube";
            this.nUdFaceTube.Size = new System.Drawing.Size(153, 20);
            this.nUdFaceTube.TabIndex = 15;
            this.nUdFaceTube.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nUdFaceTube.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUdFaceTube.ValueChanged += new System.EventHandler(this.nUdFaceTube_ValueChanged);
            this.nUdFaceTube.Enter += new System.EventHandler(this.nUdFaceTube_Enter);
            // 
            // lblFaceTube
            // 
            this.lblFaceTube.AutoSize = true;
            this.lblFaceTube.Location = new System.Drawing.Point(17, 442);
            this.lblFaceTube.Name = "lblFaceTube";
            this.lblFaceTube.Size = new System.Drawing.Size(58, 13);
            this.lblFaceTube.TabIndex = 124;
            this.lblFaceTube.Text = "sFan Wide";
            // 
            // cboSubCooler
            // 
            this.cboSubCooler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubCooler.FormattingEnabled = true;
            this.cboSubCooler.Items.AddRange(new object[] {
            "YES",
            "NO"});
            this.cboSubCooler.Location = new System.Drawing.Point(116, 413);
            this.cboSubCooler.Name = "cboSubCooler";
            this.cboSubCooler.Size = new System.Drawing.Size(153, 21);
            this.cboSubCooler.TabIndex = 14;
            this.cboSubCooler.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblSubCooler
            // 
            this.lblSubCooler.AutoSize = true;
            this.lblSubCooler.Location = new System.Drawing.Point(17, 417);
            this.lblSubCooler.Name = "lblSubCooler";
            this.lblSubCooler.Size = new System.Drawing.Size(89, 13);
            this.lblSubCooler.TabIndex = 121;
            this.lblSubCooler.Text = "sTube Thickness";
            // 
            // cboCircuits
            // 
            this.cboCircuits.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCircuits.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCircuits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCircuits.FormattingEnabled = true;
            this.cboCircuits.Items.AddRange(new object[] {
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
            "96",
            "97",
            "98",
            "99",
            "100",
            "101",
            "102",
            "103",
            "104",
            "105",
            "106",
            "107",
            "108",
            "109",
            "110",
            "111",
            "112",
            "113",
            "114",
            "115",
            "116",
            "117",
            "118",
            "119",
            "120",
            "121",
            "122",
            "123",
            "124",
            "125",
            "126",
            "127",
            "128",
            "129",
            "130",
            "131",
            "132",
            "133",
            "134",
            "135",
            "136",
            "137",
            "138",
            "139",
            "140",
            "141",
            "142",
            "143",
            "144",
            "145",
            "146",
            "147",
            "148",
            "149",
            "150",
            "151",
            "152",
            "153",
            "154",
            "155",
            "156",
            "157",
            "158",
            "159",
            "160",
            "161",
            "162",
            "163",
            "164",
            "165",
            "166",
            "167",
            "168",
            "169",
            "170",
            "171",
            "172",
            "173",
            "174",
            "175",
            "176",
            "177",
            "178",
            "179",
            "180",
            "181",
            "182",
            "183",
            "184",
            "185",
            "186",
            "187",
            "188",
            "189",
            "190",
            "191",
            "192",
            "193",
            "194",
            "195",
            "196",
            "197",
            "198",
            "199",
            "200",
            "201",
            "202",
            "203",
            "204",
            "205",
            "206",
            "207",
            "208",
            "209",
            "210",
            "211",
            "212",
            "213",
            "214",
            "215",
            "216",
            "217",
            "218",
            "219",
            "220",
            "221",
            "222",
            "223",
            "224",
            "225",
            "226",
            "227",
            "228",
            "229",
            "230",
            "231",
            "232",
            "233",
            "234",
            "235",
            "236",
            "237",
            "238",
            "239",
            "240",
            "241",
            "242",
            "243",
            "244",
            "245",
            "246",
            "247",
            "248",
            "249",
            "250",
            "251",
            "252",
            "253",
            "254",
            "255",
            "256",
            "257",
            "258",
            "259",
            "260",
            "261",
            "262",
            "263",
            "264",
            "265",
            "266",
            "267",
            "268",
            "269",
            "270",
            "271",
            "272",
            "273",
            "274",
            "275",
            "276",
            "277",
            "278",
            "279",
            "280",
            "281",
            "282",
            "283",
            "284",
            "285",
            "286",
            "287",
            "288",
            "289",
            "290",
            "291",
            "292",
            "293",
            "294",
            "295",
            "296",
            "297",
            "298",
            "299",
            "300",
            "301",
            "302",
            "303",
            "304",
            "305",
            "306",
            "307",
            "308",
            "309",
            "310",
            "311",
            "312",
            "313",
            "314",
            "315",
            "316",
            "317",
            "318",
            "319",
            "320",
            "321",
            "322",
            "323",
            "324",
            "325",
            "326",
            "327",
            "328",
            "329",
            "330",
            "331",
            "332",
            "333",
            "334",
            "335",
            "336",
            "337",
            "338",
            "339",
            "340",
            "341",
            "342",
            "343",
            "344",
            "345",
            "346",
            "347",
            "348",
            "349",
            "350"});
            this.cboCircuits.Location = new System.Drawing.Point(116, 122);
            this.cboCircuits.Name = "cboCircuits";
            this.cboCircuits.Size = new System.Drawing.Size(153, 21);
            this.cboCircuits.TabIndex = 3;
            this.cboCircuits.SelectedIndexChanged += new System.EventHandler(this.cboCircuits_SelectedIndexChanged);
            // 
            // lblCircuits
            // 
            this.lblCircuits.AutoSize = true;
            this.lblCircuits.Location = new System.Drawing.Point(15, 125);
            this.lblCircuits.Name = "lblCircuits";
            this.lblCircuits.Size = new System.Drawing.Size(46, 13);
            this.lblCircuits.TabIndex = 119;
            this.lblCircuits.Text = "sCircuits";
            // 
            // nUdFanLong
            // 
            this.nUdFanLong.Location = new System.Drawing.Point(116, 384);
            this.nUdFanLong.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nUdFanLong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUdFanLong.Name = "nUdFanLong";
            this.nUdFanLong.Size = new System.Drawing.Size(153, 20);
            this.nUdFanLong.TabIndex = 13;
            this.nUdFanLong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nUdFanLong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUdFanLong.ValueChanged += new System.EventHandler(this.nUdFanLong_ValueChanged);
            this.nUdFanLong.Enter += new System.EventHandler(this.nUdFanLong_Enter);
            // 
            // lblFanLong
            // 
            this.lblFanLong.AutoSize = true;
            this.lblFanLong.Location = new System.Drawing.Point(17, 386);
            this.lblFanLong.Name = "lblFanLong";
            this.lblFanLong.Size = new System.Drawing.Size(57, 13);
            this.lblFanLong.TabIndex = 118;
            this.lblFanLong.Text = "sFan Long";
            // 
            // lblCoilModel
            // 
            this.lblCoilModel.Location = new System.Drawing.Point(15, 16);
            this.lblCoilModel.Name = "lblCoilModel";
            this.lblCoilModel.Size = new System.Drawing.Size(251, 15);
            this.lblCoilModel.TabIndex = 116;
            this.lblCoilModel.Text = "sCoil Model";
            this.lblCoilModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nUdFanWide
            // 
            this.nUdFanWide.Location = new System.Drawing.Point(116, 358);
            this.nUdFanWide.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nUdFanWide.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUdFanWide.Name = "nUdFanWide";
            this.nUdFanWide.Size = new System.Drawing.Size(153, 20);
            this.nUdFanWide.TabIndex = 12;
            this.nUdFanWide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nUdFanWide.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUdFanWide.ValueChanged += new System.EventHandler(this.nUdFanWide_ValueChanged);
            this.nUdFanWide.Enter += new System.EventHandler(this.nUdFanWide_Enter);
            // 
            // lblFanWide
            // 
            this.lblFanWide.AutoSize = true;
            this.lblFanWide.Location = new System.Drawing.Point(17, 360);
            this.lblFanWide.Name = "lblFanWide";
            this.lblFanWide.Size = new System.Drawing.Size(58, 13);
            this.lblFanWide.TabIndex = 115;
            this.lblFanWide.Text = "sFan Wide";
            // 
            // cboFPI
            // 
            this.cboFPI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboFPI.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFPI.FormattingEnabled = true;
            this.cboFPI.Location = new System.Drawing.Point(116, 226);
            this.cboFPI.Name = "cboFPI";
            this.cboFPI.Size = new System.Drawing.Size(153, 21);
            this.cboFPI.TabIndex = 7;
            this.cboFPI.SelectedIndexChanged += new System.EventHandler(this.cboFPI_SelectedIndexChanged);
            // 
            // cboFinHeight
            // 
            this.cboFinHeight.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboFinHeight.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFinHeight.FormattingEnabled = true;
            this.cboFinHeight.Location = new System.Drawing.Point(116, 148);
            this.cboFinHeight.Name = "cboFinHeight";
            this.cboFinHeight.Size = new System.Drawing.Size(153, 21);
            this.cboFinHeight.TabIndex = 4;
            this.cboFinHeight.SelectedIndexChanged += new System.EventHandler(this.cboFinHeight_SelectedIndexChanged);
            // 
            // nUdRows
            // 
            this.nUdRows.Location = new System.Drawing.Point(116, 200);
            this.nUdRows.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nUdRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUdRows.Name = "nUdRows";
            this.nUdRows.Size = new System.Drawing.Size(153, 20);
            this.nUdRows.TabIndex = 6;
            this.nUdRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nUdRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nUdRows.ValueChanged += new System.EventHandler(this.nUdRows_ValueChanged);
            this.nUdRows.Enter += new System.EventHandler(this.nUdRows_Enter);
            // 
            // nUdFinLength
            // 
            this.nUdFinLength.DecimalPlaces = 3;
            this.nUdFinLength.Location = new System.Drawing.Point(116, 174);
            this.nUdFinLength.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nUdFinLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUdFinLength.Name = "nUdFinLength";
            this.nUdFinLength.Size = new System.Drawing.Size(153, 20);
            this.nUdFinLength.TabIndex = 5;
            this.nUdFinLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUdFinLength.ValueChanged += new System.EventHandler(this.nUdFinLength_ValueChanged);
            this.nUdFinLength.Enter += new System.EventHandler(this.nUdFinLength_Enter);
            // 
            // cboFinThickness
            // 
            this.cboFinThickness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFinThickness.FormattingEnabled = true;
            this.cboFinThickness.Location = new System.Drawing.Point(116, 278);
            this.cboFinThickness.Name = "cboFinThickness";
            this.cboFinThickness.Size = new System.Drawing.Size(153, 21);
            this.cboFinThickness.TabIndex = 9;
            this.cboFinThickness.SelectedIndexChanged += new System.EventHandler(this.cboFinThickness_SelectedIndexChanged);
            // 
            // lblFinThickness
            // 
            this.lblFinThickness.AutoSize = true;
            this.lblFinThickness.Location = new System.Drawing.Point(15, 283);
            this.lblFinThickness.Name = "lblFinThickness";
            this.lblFinThickness.Size = new System.Drawing.Size(78, 13);
            this.lblFinThickness.TabIndex = 113;
            this.lblFinThickness.Text = "sFin Thickness";
            // 
            // cboFinMaterial
            // 
            this.cboFinMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFinMaterial.FormattingEnabled = true;
            this.cboFinMaterial.Location = new System.Drawing.Point(116, 253);
            this.cboFinMaterial.Name = "cboFinMaterial";
            this.cboFinMaterial.Size = new System.Drawing.Size(153, 21);
            this.cboFinMaterial.TabIndex = 8;
            this.cboFinMaterial.SelectedIndexChanged += new System.EventHandler(this.cboFinMaterial_SelectedIndexChanged);
            // 
            // lblFinMaterial
            // 
            this.lblFinMaterial.AutoSize = true;
            this.lblFinMaterial.Location = new System.Drawing.Point(15, 256);
            this.lblFinMaterial.Name = "lblFinMaterial";
            this.lblFinMaterial.Size = new System.Drawing.Size(66, 13);
            this.lblFinMaterial.TabIndex = 112;
            this.lblFinMaterial.Text = "sFin Material";
            // 
            // cboTubeThickness
            // 
            this.cboTubeThickness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTubeThickness.FormattingEnabled = true;
            this.cboTubeThickness.Location = new System.Drawing.Point(116, 329);
            this.cboTubeThickness.Name = "cboTubeThickness";
            this.cboTubeThickness.Size = new System.Drawing.Size(153, 21);
            this.cboTubeThickness.TabIndex = 11;
            this.cboTubeThickness.SelectedIndexChanged += new System.EventHandler(this.cboTubeThickness_SelectedIndexChanged);
            // 
            // lblTubeThickness
            // 
            this.lblTubeThickness.AutoSize = true;
            this.lblTubeThickness.Location = new System.Drawing.Point(15, 334);
            this.lblTubeThickness.Name = "lblTubeThickness";
            this.lblTubeThickness.Size = new System.Drawing.Size(89, 13);
            this.lblTubeThickness.TabIndex = 111;
            this.lblTubeThickness.Text = "sTube Thickness";
            // 
            // cboTubeMaterial
            // 
            this.cboTubeMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTubeMaterial.FormattingEnabled = true;
            this.cboTubeMaterial.Location = new System.Drawing.Point(116, 304);
            this.cboTubeMaterial.Name = "cboTubeMaterial";
            this.cboTubeMaterial.Size = new System.Drawing.Size(153, 21);
            this.cboTubeMaterial.TabIndex = 10;
            this.cboTubeMaterial.SelectedIndexChanged += new System.EventHandler(this.cboTubeMaterial_SelectedIndexChanged);
            // 
            // lblTubeMaterial
            // 
            this.lblTubeMaterial.AutoSize = true;
            this.lblTubeMaterial.Location = new System.Drawing.Point(15, 309);
            this.lblTubeMaterial.Name = "lblTubeMaterial";
            this.lblTubeMaterial.Size = new System.Drawing.Size(77, 13);
            this.lblTubeMaterial.TabIndex = 110;
            this.lblTubeMaterial.Text = "sTube Material";
            // 
            // lblFPI
            // 
            this.lblFPI.AutoSize = true;
            this.lblFPI.Location = new System.Drawing.Point(15, 229);
            this.lblFPI.Name = "lblFPI";
            this.lblFPI.Size = new System.Drawing.Size(82, 13);
            this.lblFPI.TabIndex = 109;
            this.lblFPI.Text = "sFins/Inch (FPI)";
            // 
            // lblRow
            // 
            this.lblRow.AutoSize = true;
            this.lblRow.Location = new System.Drawing.Point(15, 202);
            this.lblRow.Name = "lblRow";
            this.lblRow.Size = new System.Drawing.Size(34, 13);
            this.lblRow.TabIndex = 108;
            this.lblRow.Text = "sRow";
            // 
            // lblFinLength
            // 
            this.lblFinLength.AutoSize = true;
            this.lblFinLength.Location = new System.Drawing.Point(15, 176);
            this.lblFinLength.Name = "lblFinLength";
            this.lblFinLength.Size = new System.Drawing.Size(62, 13);
            this.lblFinLength.TabIndex = 107;
            this.lblFinLength.Text = "sFin Length";
            // 
            // lblFinHeight
            // 
            this.lblFinHeight.AutoSize = true;
            this.lblFinHeight.Location = new System.Drawing.Point(15, 151);
            this.lblFinHeight.Name = "lblFinHeight";
            this.lblFinHeight.Size = new System.Drawing.Size(60, 13);
            this.lblFinHeight.TabIndex = 106;
            this.lblFinHeight.Text = "sFin Height";
            // 
            // cboFinShape
            // 
            this.cboFinShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFinShape.FormattingEnabled = true;
            this.cboFinShape.Location = new System.Drawing.Point(116, 97);
            this.cboFinShape.Name = "cboFinShape";
            this.cboFinShape.Size = new System.Drawing.Size(153, 21);
            this.cboFinShape.TabIndex = 2;
            this.cboFinShape.SelectedIndexChanged += new System.EventHandler(this.cboFinShape_SelectedIndexChanged);
            // 
            // lblFinShape
            // 
            this.lblFinShape.AutoSize = true;
            this.lblFinShape.Location = new System.Drawing.Point(15, 100);
            this.lblFinShape.Name = "lblFinShape";
            this.lblFinShape.Size = new System.Drawing.Size(60, 13);
            this.lblFinShape.TabIndex = 105;
            this.lblFinShape.Text = "sFin Shape";
            // 
            // cboFinType
            // 
            this.cboFinType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFinType.FormattingEnabled = true;
            this.cboFinType.Location = new System.Drawing.Point(116, 70);
            this.cboFinType.Name = "cboFinType";
            this.cboFinType.Size = new System.Drawing.Size(153, 21);
            this.cboFinType.TabIndex = 1;
            this.cboFinType.SelectedIndexChanged += new System.EventHandler(this.cboFinType_SelectedIndexChanged);
            // 
            // lblFinType
            // 
            this.lblFinType.AutoSize = true;
            this.lblFinType.Location = new System.Drawing.Point(15, 73);
            this.lblFinType.Name = "lblFinType";
            this.lblFinType.Size = new System.Drawing.Size(53, 13);
            this.lblFinType.TabIndex = 104;
            this.lblFinType.Text = "sFin Type";
            // 
            // grpBase
            // 
            this.grpBase.Controls.Add(this.txtHeight);
            this.grpBase.Controls.Add(this.txtWidth);
            this.grpBase.Controls.Add(this.txtLength);
            this.grpBase.Controls.Add(this.lblHeight);
            this.grpBase.Controls.Add(this.lblWidth);
            this.grpBase.Controls.Add(this.lblLength);
            this.grpBase.Controls.Add(this.label14);
            this.grpBase.Controls.Add(this.nUdBaseWeight);
            this.grpBase.Controls.Add(this.lblBaseWeight);
            this.grpBase.Location = new System.Drawing.Point(16, 12);
            this.grpBase.Name = "grpBase";
            this.grpBase.Size = new System.Drawing.Size(266, 117);
            this.grpBase.TabIndex = 130;
            this.grpBase.TabStop = false;
            this.grpBase.Text = "groupBox1";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(125, 66);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(100, 20);
            this.txtHeight.TabIndex = 3;
            this.txtHeight.Enter += new System.EventHandler(this.txtHeight_Enter);
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(125, 46);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(100, 20);
            this.txtWidth.TabIndex = 2;
            this.txtWidth.Enter += new System.EventHandler(this.txtWidth_Enter);
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(125, 26);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(100, 20);
            this.txtLength.TabIndex = 1;
            this.txtLength.Enter += new System.EventHandler(this.txtLength_Enter);
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(17, 69);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(35, 13);
            this.lblHeight.TabIndex = 71;
            this.lblHeight.Text = "label7";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(17, 49);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(35, 13);
            this.lblWidth.TabIndex = 70;
            this.lblWidth.Text = "label6";
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(17, 29);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(35, 13);
            this.lblLength.TabIndex = 69;
            this.lblLength.Text = "label5";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(231, 88);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 13);
            this.label14.TabIndex = 68;
            this.label14.Text = "lbs";
            // 
            // nUdBaseWeight
            // 
            this.nUdBaseWeight.Location = new System.Drawing.Point(125, 86);
            this.nUdBaseWeight.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nUdBaseWeight.Name = "nUdBaseWeight";
            this.nUdBaseWeight.Size = new System.Drawing.Size(100, 20);
            this.nUdBaseWeight.TabIndex = 4;
            this.nUdBaseWeight.Enter += new System.EventHandler(this.nUdBaseWeight_Enter);
            // 
            // lblBaseWeight
            // 
            this.lblBaseWeight.AutoSize = true;
            this.lblBaseWeight.Location = new System.Drawing.Point(18, 88);
            this.lblBaseWeight.Name = "lblBaseWeight";
            this.lblBaseWeight.Size = new System.Drawing.Size(35, 13);
            this.lblBaseWeight.TabIndex = 66;
            this.lblBaseWeight.Text = "label3";
            // 
            // grpWCC
            // 
            this.grpWCC.Controls.Add(this.txtWCCModel);
            this.grpWCC.Controls.Add(this.txtWCCR744);
            this.grpWCC.Controls.Add(this.txtWCCR407A);
            this.grpWCC.Controls.Add(this.txtWCCR410A);
            this.grpWCC.Controls.Add(this.txtWCCR407C);
            this.grpWCC.Controls.Add(this.txtWCCR404A);
            this.grpWCC.Controls.Add(this.txtWCCR134A);
            this.grpWCC.Controls.Add(this.txtWCCR22);
            this.grpWCC.Controls.Add(this.lblWCCModel);
            this.grpWCC.Controls.Add(this.lblWCCR744);
            this.grpWCC.Controls.Add(this.lblWCCR407A);
            this.grpWCC.Controls.Add(this.lblWCCR410A);
            this.grpWCC.Controls.Add(this.lblWCCR507A);
            this.grpWCC.Controls.Add(this.lblWCCR407C);
            this.grpWCC.Controls.Add(this.lblWCCR404A);
            this.grpWCC.Controls.Add(this.lblWCCR134A);
            this.grpWCC.Controls.Add(this.txtWCCR507A);
            this.grpWCC.Controls.Add(this.lblWCCR22);
            this.grpWCC.Controls.Add(this.label15);
            this.grpWCC.Controls.Add(this.nUdWCCWeight);
            this.grpWCC.Controls.Add(this.lblWCCWeight);
            this.grpWCC.Location = new System.Drawing.Point(7, 9);
            this.grpWCC.Name = "grpWCC";
            this.grpWCC.Size = new System.Drawing.Size(257, 245);
            this.grpWCC.TabIndex = 131;
            this.grpWCC.TabStop = false;
            this.grpWCC.Text = "groupBox1";
            // 
            // txtWCCModel
            // 
            this.txtWCCModel.Location = new System.Drawing.Point(125, 186);
            this.txtWCCModel.Name = "txtWCCModel";
            this.txtWCCModel.Size = new System.Drawing.Size(100, 20);
            this.txtWCCModel.TabIndex = 9;
            this.txtWCCModel.Enter += new System.EventHandler(this.txtWCCModel_Enter);
            // 
            // txtWCCR744
            // 
            this.txtWCCR744.Location = new System.Drawing.Point(125, 166);
            this.txtWCCR744.Name = "txtWCCR744";
            this.txtWCCR744.Size = new System.Drawing.Size(100, 20);
            this.txtWCCR744.TabIndex = 8;
            this.txtWCCR744.Enter += new System.EventHandler(this.txtWCCR744_Enter);
            // 
            // txtWCCR407A
            // 
            this.txtWCCR407A.Location = new System.Drawing.Point(125, 146);
            this.txtWCCR407A.Name = "txtWCCR407A";
            this.txtWCCR407A.Size = new System.Drawing.Size(100, 20);
            this.txtWCCR407A.TabIndex = 7;
            this.txtWCCR407A.Enter += new System.EventHandler(this.txtWCCR407A_Enter);
            // 
            // txtWCCR410A
            // 
            this.txtWCCR410A.Location = new System.Drawing.Point(125, 126);
            this.txtWCCR410A.Name = "txtWCCR410A";
            this.txtWCCR410A.Size = new System.Drawing.Size(100, 20);
            this.txtWCCR410A.TabIndex = 6;
            this.txtWCCR410A.Enter += new System.EventHandler(this.txtWCCR410A_Enter);
            // 
            // txtWCCR407C
            // 
            this.txtWCCR407C.Location = new System.Drawing.Point(125, 86);
            this.txtWCCR407C.Name = "txtWCCR407C";
            this.txtWCCR407C.Size = new System.Drawing.Size(100, 20);
            this.txtWCCR407C.TabIndex = 4;
            this.txtWCCR407C.Enter += new System.EventHandler(this.txtWCCR407C_Enter);
            // 
            // txtWCCR404A
            // 
            this.txtWCCR404A.Location = new System.Drawing.Point(125, 66);
            this.txtWCCR404A.Name = "txtWCCR404A";
            this.txtWCCR404A.Size = new System.Drawing.Size(100, 20);
            this.txtWCCR404A.TabIndex = 3;
            this.txtWCCR404A.Enter += new System.EventHandler(this.txtWCCR404A_Enter);
            // 
            // txtWCCR134A
            // 
            this.txtWCCR134A.Location = new System.Drawing.Point(125, 46);
            this.txtWCCR134A.Name = "txtWCCR134A";
            this.txtWCCR134A.Size = new System.Drawing.Size(100, 20);
            this.txtWCCR134A.TabIndex = 2;
            this.txtWCCR134A.Enter += new System.EventHandler(this.txtWCCR134A_Enter);
            // 
            // txtWCCR22
            // 
            this.txtWCCR22.Location = new System.Drawing.Point(125, 26);
            this.txtWCCR22.Name = "txtWCCR22";
            this.txtWCCR22.Size = new System.Drawing.Size(100, 20);
            this.txtWCCR22.TabIndex = 1;
            this.txtWCCR22.Enter += new System.EventHandler(this.txtWCCR22_Enter);
            // 
            // lblWCCModel
            // 
            this.lblWCCModel.AutoSize = true;
            this.lblWCCModel.Location = new System.Drawing.Point(17, 189);
            this.lblWCCModel.Name = "lblWCCModel";
            this.lblWCCModel.Size = new System.Drawing.Size(41, 13);
            this.lblWCCModel.TabIndex = 77;
            this.lblWCCModel.Text = "label13";
            // 
            // lblWCCR744
            // 
            this.lblWCCR744.AutoSize = true;
            this.lblWCCR744.Location = new System.Drawing.Point(17, 169);
            this.lblWCCR744.Name = "lblWCCR744";
            this.lblWCCR744.Size = new System.Drawing.Size(41, 13);
            this.lblWCCR744.TabIndex = 76;
            this.lblWCCR744.Text = "label13";
            // 
            // lblWCCR407A
            // 
            this.lblWCCR407A.AutoSize = true;
            this.lblWCCR407A.Location = new System.Drawing.Point(17, 149);
            this.lblWCCR407A.Name = "lblWCCR407A";
            this.lblWCCR407A.Size = new System.Drawing.Size(41, 13);
            this.lblWCCR407A.TabIndex = 75;
            this.lblWCCR407A.Text = "label12";
            // 
            // lblWCCR410A
            // 
            this.lblWCCR410A.AutoSize = true;
            this.lblWCCR410A.Location = new System.Drawing.Point(17, 129);
            this.lblWCCR410A.Name = "lblWCCR410A";
            this.lblWCCR410A.Size = new System.Drawing.Size(41, 13);
            this.lblWCCR410A.TabIndex = 74;
            this.lblWCCR410A.Text = "label10";
            // 
            // lblWCCR507A
            // 
            this.lblWCCR507A.AutoSize = true;
            this.lblWCCR507A.Location = new System.Drawing.Point(17, 109);
            this.lblWCCR507A.Name = "lblWCCR507A";
            this.lblWCCR507A.Size = new System.Drawing.Size(35, 13);
            this.lblWCCR507A.TabIndex = 73;
            this.lblWCCR507A.Text = "label9";
            // 
            // lblWCCR407C
            // 
            this.lblWCCR407C.AutoSize = true;
            this.lblWCCR407C.Location = new System.Drawing.Point(17, 89);
            this.lblWCCR407C.Name = "lblWCCR407C";
            this.lblWCCR407C.Size = new System.Drawing.Size(35, 13);
            this.lblWCCR407C.TabIndex = 72;
            this.lblWCCR407C.Text = "label8";
            // 
            // lblWCCR404A
            // 
            this.lblWCCR404A.AutoSize = true;
            this.lblWCCR404A.Location = new System.Drawing.Point(17, 69);
            this.lblWCCR404A.Name = "lblWCCR404A";
            this.lblWCCR404A.Size = new System.Drawing.Size(35, 13);
            this.lblWCCR404A.TabIndex = 71;
            this.lblWCCR404A.Text = "label7";
            // 
            // lblWCCR134A
            // 
            this.lblWCCR134A.AutoSize = true;
            this.lblWCCR134A.Location = new System.Drawing.Point(17, 49);
            this.lblWCCR134A.Name = "lblWCCR134A";
            this.lblWCCR134A.Size = new System.Drawing.Size(35, 13);
            this.lblWCCR134A.TabIndex = 70;
            this.lblWCCR134A.Text = "label6";
            // 
            // txtWCCR507A
            // 
            this.txtWCCR507A.Location = new System.Drawing.Point(125, 106);
            this.txtWCCR507A.Name = "txtWCCR507A";
            this.txtWCCR507A.Size = new System.Drawing.Size(100, 20);
            this.txtWCCR507A.TabIndex = 5;
            this.txtWCCR507A.Enter += new System.EventHandler(this.txtWCCR507A_Enter);
            // 
            // lblWCCR22
            // 
            this.lblWCCR22.AutoSize = true;
            this.lblWCCR22.Location = new System.Drawing.Point(17, 29);
            this.lblWCCR22.Name = "lblWCCR22";
            this.lblWCCR22.Size = new System.Drawing.Size(35, 13);
            this.lblWCCR22.TabIndex = 69;
            this.lblWCCR22.Text = "label5";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(231, 209);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 13);
            this.label15.TabIndex = 68;
            this.label15.Text = "lbs";
            // 
            // nUdWCCWeight
            // 
            this.nUdWCCWeight.Location = new System.Drawing.Point(125, 207);
            this.nUdWCCWeight.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nUdWCCWeight.Name = "nUdWCCWeight";
            this.nUdWCCWeight.Size = new System.Drawing.Size(100, 20);
            this.nUdWCCWeight.TabIndex = 10;
            this.nUdWCCWeight.Enter += new System.EventHandler(this.nUdWCCWeight_Enter);
            // 
            // lblWCCWeight
            // 
            this.lblWCCWeight.AutoSize = true;
            this.lblWCCWeight.Location = new System.Drawing.Point(18, 209);
            this.lblWCCWeight.Name = "lblWCCWeight";
            this.lblWCCWeight.Size = new System.Drawing.Size(35, 13);
            this.lblWCCWeight.TabIndex = 66;
            this.lblWCCWeight.Text = "label3";
            // 
            // grpGeneric
            // 
            this.grpGeneric.Controls.Add(this.label16);
            this.grpGeneric.Controls.Add(this.nUdGenericWeight);
            this.grpGeneric.Controls.Add(this.lblGenericWeight);
            this.grpGeneric.Location = new System.Drawing.Point(10, 12);
            this.grpGeneric.Name = "grpGeneric";
            this.grpGeneric.Size = new System.Drawing.Size(257, 60);
            this.grpGeneric.TabIndex = 132;
            this.grpGeneric.TabStop = false;
            this.grpGeneric.Text = "groupBox1";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(219, 28);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(20, 13);
            this.label16.TabIndex = 68;
            this.label16.Text = "lbs";
            // 
            // nUdGenericWeight
            // 
            this.nUdGenericWeight.Location = new System.Drawing.Point(113, 26);
            this.nUdGenericWeight.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nUdGenericWeight.Name = "nUdGenericWeight";
            this.nUdGenericWeight.Size = new System.Drawing.Size(100, 20);
            this.nUdGenericWeight.TabIndex = 1;
            this.nUdGenericWeight.ValueChanged += new System.EventHandler(this.nUdGenericWeight_ValueChanged);
            // 
            // lblGenericWeight
            // 
            this.lblGenericWeight.AutoSize = true;
            this.lblGenericWeight.Location = new System.Drawing.Point(6, 28);
            this.lblGenericWeight.Name = "lblGenericWeight";
            this.lblGenericWeight.Size = new System.Drawing.Size(35, 13);
            this.lblGenericWeight.TabIndex = 66;
            this.lblGenericWeight.Text = "label3";
            // 
            // lblReceiverWeight
            // 
            this.lblReceiverWeight.AutoSize = true;
            this.lblReceiverWeight.Location = new System.Drawing.Point(18, 209);
            this.lblReceiverWeight.Name = "lblReceiverWeight";
            this.lblReceiverWeight.Size = new System.Drawing.Size(35, 13);
            this.lblReceiverWeight.TabIndex = 66;
            this.lblReceiverWeight.Text = "label3";
            // 
            // nUdReceiverWeight
            // 
            this.nUdReceiverWeight.Location = new System.Drawing.Point(125, 207);
            this.nUdReceiverWeight.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nUdReceiverWeight.Name = "nUdReceiverWeight";
            this.nUdReceiverWeight.Size = new System.Drawing.Size(100, 20);
            this.nUdReceiverWeight.TabIndex = 11;
            this.nUdReceiverWeight.Enter += new System.EventHandler(this.nUdReceiverWeight_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 68;
            this.label3.Text = "lbs";
            // 
            // lblR22
            // 
            this.lblR22.AutoSize = true;
            this.lblR22.Location = new System.Drawing.Point(17, 29);
            this.lblR22.Name = "lblR22";
            this.lblR22.Size = new System.Drawing.Size(35, 13);
            this.lblR22.TabIndex = 69;
            this.lblR22.Text = "label5";
            // 
            // txtR507A
            // 
            this.txtR507A.Location = new System.Drawing.Point(125, 106);
            this.txtR507A.Name = "txtR507A";
            this.txtR507A.Size = new System.Drawing.Size(100, 20);
            this.txtR507A.TabIndex = 5;
            this.txtR507A.Enter += new System.EventHandler(this.txtR507A_Enter);
            // 
            // lblR134A
            // 
            this.lblR134A.AutoSize = true;
            this.lblR134A.Location = new System.Drawing.Point(17, 49);
            this.lblR134A.Name = "lblR134A";
            this.lblR134A.Size = new System.Drawing.Size(35, 13);
            this.lblR134A.TabIndex = 70;
            this.lblR134A.Text = "label6";
            // 
            // lblR404A
            // 
            this.lblR404A.AutoSize = true;
            this.lblR404A.Location = new System.Drawing.Point(17, 69);
            this.lblR404A.Name = "lblR404A";
            this.lblR404A.Size = new System.Drawing.Size(35, 13);
            this.lblR404A.TabIndex = 71;
            this.lblR404A.Text = "label7";
            // 
            // lblR407C
            // 
            this.lblR407C.AutoSize = true;
            this.lblR407C.Location = new System.Drawing.Point(17, 89);
            this.lblR407C.Name = "lblR407C";
            this.lblR407C.Size = new System.Drawing.Size(35, 13);
            this.lblR407C.TabIndex = 72;
            this.lblR407C.Text = "label8";
            // 
            // lblR507A
            // 
            this.lblR507A.AutoSize = true;
            this.lblR507A.Location = new System.Drawing.Point(17, 109);
            this.lblR507A.Name = "lblR507A";
            this.lblR507A.Size = new System.Drawing.Size(35, 13);
            this.lblR507A.TabIndex = 73;
            this.lblR507A.Text = "label9";
            // 
            // lblR410A
            // 
            this.lblR410A.AutoSize = true;
            this.lblR410A.Location = new System.Drawing.Point(17, 129);
            this.lblR410A.Name = "lblR410A";
            this.lblR410A.Size = new System.Drawing.Size(41, 13);
            this.lblR410A.TabIndex = 74;
            this.lblR410A.Text = "label10";
            // 
            // lblR407A
            // 
            this.lblR407A.AutoSize = true;
            this.lblR407A.Location = new System.Drawing.Point(17, 149);
            this.lblR407A.Name = "lblR407A";
            this.lblR407A.Size = new System.Drawing.Size(41, 13);
            this.lblR407A.TabIndex = 75;
            this.lblR407A.Text = "label12";
            // 
            // lblR744
            // 
            this.lblR744.AutoSize = true;
            this.lblR744.Location = new System.Drawing.Point(17, 169);
            this.lblR744.Name = "lblR744";
            this.lblR744.Size = new System.Drawing.Size(41, 13);
            this.lblR744.TabIndex = 76;
            this.lblR744.Text = "label13";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(17, 189);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(41, 13);
            this.lblSize.TabIndex = 77;
            this.lblSize.Text = "label13";
            // 
            // txtR22
            // 
            this.txtR22.Location = new System.Drawing.Point(125, 26);
            this.txtR22.Name = "txtR22";
            this.txtR22.Size = new System.Drawing.Size(100, 20);
            this.txtR22.TabIndex = 1;
            this.txtR22.Enter += new System.EventHandler(this.txtR22_Enter);
            // 
            // txtR134A
            // 
            this.txtR134A.Location = new System.Drawing.Point(125, 46);
            this.txtR134A.Name = "txtR134A";
            this.txtR134A.Size = new System.Drawing.Size(100, 20);
            this.txtR134A.TabIndex = 2;
            this.txtR134A.Enter += new System.EventHandler(this.txtR134A_Enter);
            // 
            // txtR404A
            // 
            this.txtR404A.Location = new System.Drawing.Point(125, 66);
            this.txtR404A.Name = "txtR404A";
            this.txtR404A.Size = new System.Drawing.Size(100, 20);
            this.txtR404A.TabIndex = 3;
            this.txtR404A.Enter += new System.EventHandler(this.txtR404A_Enter);
            // 
            // txtR407C
            // 
            this.txtR407C.Location = new System.Drawing.Point(125, 86);
            this.txtR407C.Name = "txtR407C";
            this.txtR407C.Size = new System.Drawing.Size(100, 20);
            this.txtR407C.TabIndex = 4;
            this.txtR407C.Enter += new System.EventHandler(this.txtR407C_Enter);
            // 
            // txtR410A
            // 
            this.txtR410A.Location = new System.Drawing.Point(125, 126);
            this.txtR410A.Name = "txtR410A";
            this.txtR410A.Size = new System.Drawing.Size(100, 20);
            this.txtR410A.TabIndex = 6;
            this.txtR410A.Enter += new System.EventHandler(this.txtR410A_Enter);
            // 
            // txtR407A
            // 
            this.txtR407A.Location = new System.Drawing.Point(125, 146);
            this.txtR407A.Name = "txtR407A";
            this.txtR407A.Size = new System.Drawing.Size(100, 20);
            this.txtR407A.TabIndex = 7;
            this.txtR407A.Enter += new System.EventHandler(this.txtR407A_Enter);
            // 
            // txtR744
            // 
            this.txtR744.Location = new System.Drawing.Point(125, 166);
            this.txtR744.Name = "txtR744";
            this.txtR744.Size = new System.Drawing.Size(100, 20);
            this.txtR744.TabIndex = 8;
            this.txtR744.Enter += new System.EventHandler(this.txtR744_Enter);
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(125, 186);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(100, 20);
            this.txtSize.TabIndex = 9;
            this.txtSize.Enter += new System.EventHandler(this.txtSize_Enter);
            // 
            // btnShowSizes
            // 
            this.btnShowSizes.Location = new System.Drawing.Point(231, 182);
            this.btnShowSizes.Name = "btnShowSizes";
            this.btnShowSizes.Size = new System.Drawing.Size(81, 23);
            this.btnShowSizes.TabIndex = 10;
            this.btnShowSizes.Text = "sShow sizes";
            this.btnShowSizes.UseVisualStyleBackColor = true;
            this.btnShowSizes.Click += new System.EventHandler(this.btnShowSizes_Click);
            // 
            // grpReceiver
            // 
            this.grpReceiver.Controls.Add(this.btnShowSizes);
            this.grpReceiver.Controls.Add(this.txtSize);
            this.grpReceiver.Controls.Add(this.txtR744);
            this.grpReceiver.Controls.Add(this.txtR407A);
            this.grpReceiver.Controls.Add(this.txtR410A);
            this.grpReceiver.Controls.Add(this.txtR407C);
            this.grpReceiver.Controls.Add(this.txtR404A);
            this.grpReceiver.Controls.Add(this.txtR134A);
            this.grpReceiver.Controls.Add(this.txtR22);
            this.grpReceiver.Controls.Add(this.lblSize);
            this.grpReceiver.Controls.Add(this.lblR744);
            this.grpReceiver.Controls.Add(this.lblR407A);
            this.grpReceiver.Controls.Add(this.lblR410A);
            this.grpReceiver.Controls.Add(this.lblR507A);
            this.grpReceiver.Controls.Add(this.lblR407C);
            this.grpReceiver.Controls.Add(this.lblR404A);
            this.grpReceiver.Controls.Add(this.lblR134A);
            this.grpReceiver.Controls.Add(this.txtR507A);
            this.grpReceiver.Controls.Add(this.lblR22);
            this.grpReceiver.Controls.Add(this.label3);
            this.grpReceiver.Controls.Add(this.nUdReceiverWeight);
            this.grpReceiver.Controls.Add(this.lblReceiverWeight);
            this.grpReceiver.Location = new System.Drawing.Point(12, 12);
            this.grpReceiver.Name = "grpReceiver";
            this.grpReceiver.Size = new System.Drawing.Size(327, 245);
            this.grpReceiver.TabIndex = 126;
            this.grpReceiver.TabStop = false;
            this.grpReceiver.Text = "groupBox1";
            // 
            // FrmLogic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1617, 598);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpMotor);
            this.Controls.Add(this.grpCoil);
            this.Controls.Add(this.grpWCC);
            this.Controls.Add(this.grpBase);
            this.Controls.Add(this.grpGeneric);
            this.Controls.Add(this.grpReceiver);
            this.Controls.Add(this.grpCompressor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogic";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FrmLogic";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmLogic_Load);
            this.grpCompressor.ResumeLayout(false);
            this.grpCompressor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUdCompressorWeight)).EndInit();
            this.grpConnexions.ResumeLayout(false);
            this.grpConnexions.PerformLayout();
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.grpPolynomials.ResumeLayout(false);
            this.grpPolynomials.PerformLayout();
            this.grpMotor.ResumeLayout(false);
            this.grpMotor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUdFLA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUdRPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUdHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUdMotorWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCFM)).EndInit();
            this.grpCoil.ResumeLayout(false);
            this.grpCoil.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUdCoilWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUdFaceTube)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUdFanLong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUdFanWide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUdRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUdFinLength)).EndInit();
            this.grpBase.ResumeLayout(false);
            this.grpBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUdBaseWeight)).EndInit();
            this.grpWCC.ResumeLayout(false);
            this.grpWCC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUdWCCWeight)).EndInit();
            this.grpGeneric.ResumeLayout(false);
            this.grpGeneric.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUdGenericWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUdReceiverWeight)).EndInit();
            this.grpReceiver.ResumeLayout(false);
            this.grpReceiver.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCompressor;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btn_Details;
        private System.Windows.Forms.ComboBox cboModel;
        private System.Windows.Forms.GroupBox grpConnexions;
        private System.Windows.Forms.ComboBox cboDischarge;
        private System.Windows.Forms.ComboBox cboSuction;
        private System.Windows.Forms.ComboBox cboLiquid;
        private System.Windows.Forms.Label lblDischarge;
        private System.Windows.Forms.Label lblSuction;
        private System.Windows.Forms.Label lblLiquid;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblCompressorSelected;
        private System.Windows.Forms.GroupBox grpPolynomials;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label lblTandemValue;
        private System.Windows.Forms.Label lblVoltageValue;
        private System.Windows.Forms.Label lblRefrigerantValue;
        private System.Windows.Forms.Label lblManufacturerValue;
        private System.Windows.Forms.Label lblLRAValue;
        private System.Windows.Forms.Label lblRLAValue;
        private System.Windows.Forms.Label lblTypeValue;
        private System.Windows.Forms.Label lblTandem;
        private System.Windows.Forms.Label lblVoltage;
        private System.Windows.Forms.Label lblRefrigerant;
        private System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.Label lblLRA;
        private System.Windows.Forms.Label lblRLA;
        private System.Windows.Forms.Label lblPower9Value;
        private System.Windows.Forms.Label lblCapacity1Value;
        private System.Windows.Forms.Label lblPower3Value;
        private System.Windows.Forms.Label lblCapacity8Value;
        private System.Windows.Forms.Label lblPower8Value;
        private System.Windows.Forms.Label lblCapacity9Value;
        private System.Windows.Forms.Label lblPower4Value;
        private System.Windows.Forms.Label lblCapacity10Value;
        private System.Windows.Forms.Label lblPower7Value;
        private System.Windows.Forms.Label lblPower1Value;
        private System.Windows.Forms.Label lblPower5Value;
        private System.Windows.Forms.Label lblCapacity4Value;
        private System.Windows.Forms.Label lblPower6Value;
        private System.Windows.Forms.Label lblPower2Value;
        private System.Windows.Forms.Label lblPower10Value;
        private System.Windows.Forms.Label lblCapacity3Value;
        private System.Windows.Forms.Label lblCapacity7Value;
        private System.Windows.Forms.Label lblCapacity5Value;
        private System.Windows.Forms.Label lblCapacity2Value;
        private System.Windows.Forms.Label lblCapacity6Value;
        private System.Windows.Forms.Label lblPower9;
        private System.Windows.Forms.Label lblCapacity1;
        private System.Windows.Forms.Label lblPower3;
        private System.Windows.Forms.Label lblCapacity8;
        private System.Windows.Forms.Label lblPower8;
        private System.Windows.Forms.Label lblCapacity9;
        private System.Windows.Forms.Label lblPower4;
        private System.Windows.Forms.Label lblCapacity10;
        private System.Windows.Forms.Label lblPower7;
        private System.Windows.Forms.Label lblPower1;
        private System.Windows.Forms.Label lblPower5;
        private System.Windows.Forms.Label lblCapacity4;
        private System.Windows.Forms.Label lblPower6;
        private System.Windows.Forms.Label lblPower2;
        private System.Windows.Forms.Label lblPower10;
        private System.Windows.Forms.Label lblCapacity3;
        private System.Windows.Forms.Label lblCapacity7;
        private System.Windows.Forms.Label lblCapacity5;
        private System.Windows.Forms.Label lblCapacity2;
        private System.Windows.Forms.Label lblCapacity6;
        private System.Windows.Forms.Label lblCompressorValue;
        private System.Windows.Forms.Label lblModule;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.NumericUpDown nUdCompressorWeight;
        private System.Windows.Forms.GroupBox grpMotor;
        private System.Windows.Forms.Label lblTempRange;
        private System.Windows.Forms.Label lblFLA;
        private System.Windows.Forms.Label lblVoltageMotor;
        private System.Windows.Forms.Label lblRPM;
        private System.Windows.Forms.Label lblHP;
        private System.Windows.Forms.NumericUpDown nUdMotorWeight;
        private System.Windows.Forms.Label lblWeightMotor;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.DataGridView dgCFM;
        private System.Windows.Forms.NumericUpDown nUdHP;
        private System.Windows.Forms.NumericUpDown nUdRPM;
        private System.Windows.Forms.ComboBox cboVoltage;
        private System.Windows.Forms.NumericUpDown nUdFLA;
        private System.Windows.Forms.ComboBox cboMotorType;
        private System.Windows.Forms.TextBox txtTempMin;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblMotorType;
        private System.Windows.Forms.Label lblMotorValue;
        private System.Windows.Forms.TextBox txtTempMax;
        private System.Windows.Forms.Label lblMotor;
        private System.Windows.Forms.Label llblMotorPounds;
        private System.Windows.Forms.Label lblFarenheit;
        private System.Windows.Forms.Label lblCompressorPounds;
        private System.Windows.Forms.GroupBox grpCoil;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown nUdCoilWeight;
        private System.Windows.Forms.Label lblCoilWeight;
        private System.Windows.Forms.Label lblSubCoolerCircuits;
        private System.Windows.Forms.NumericUpDown nUdFaceTube;
        private System.Windows.Forms.Label lblFaceTube;
        private System.Windows.Forms.ComboBox cboSubCooler;
        private System.Windows.Forms.Label lblSubCooler;
        private System.Windows.Forms.ComboBox cboCircuits;
        private System.Windows.Forms.Label lblCircuits;
        private System.Windows.Forms.NumericUpDown nUdFanLong;
        private System.Windows.Forms.Label lblFanLong;
        private System.Windows.Forms.Label lblCoilModel;
        private System.Windows.Forms.NumericUpDown nUdFanWide;
        private System.Windows.Forms.Label lblFanWide;
        private System.Windows.Forms.ComboBox cboFPI;
        private System.Windows.Forms.ComboBox cboFinHeight;
        private System.Windows.Forms.NumericUpDown nUdRows;
        private System.Windows.Forms.NumericUpDown nUdFinLength;
        private System.Windows.Forms.ComboBox cboFinThickness;
        private System.Windows.Forms.Label lblFinThickness;
        private System.Windows.Forms.ComboBox cboFinMaterial;
        private System.Windows.Forms.Label lblFinMaterial;
        private System.Windows.Forms.ComboBox cboTubeThickness;
        private System.Windows.Forms.Label lblTubeThickness;
        private System.Windows.Forms.ComboBox cboTubeMaterial;
        private System.Windows.Forms.Label lblTubeMaterial;
        private System.Windows.Forms.Label lblFPI;
        private System.Windows.Forms.Label lblRow;
        private System.Windows.Forms.Label lblFinLength;
        private System.Windows.Forms.Label lblFinHeight;
        private System.Windows.Forms.ComboBox cboFinShape;
        private System.Windows.Forms.Label lblFinShape;
        private System.Windows.Forms.ComboBox cboFinType;
        private System.Windows.Forms.Label lblFinType;
        private System.Windows.Forms.GroupBox grpBase;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown nUdBaseWeight;
        private System.Windows.Forms.Label lblBaseWeight;
        private System.Windows.Forms.GroupBox grpWCC;
        private System.Windows.Forms.TextBox txtWCCModel;
        private System.Windows.Forms.TextBox txtWCCR744;
        private System.Windows.Forms.TextBox txtWCCR407A;
        private System.Windows.Forms.TextBox txtWCCR410A;
        private System.Windows.Forms.TextBox txtWCCR407C;
        private System.Windows.Forms.TextBox txtWCCR404A;
        private System.Windows.Forms.TextBox txtWCCR134A;
        private System.Windows.Forms.TextBox txtWCCR22;
        private System.Windows.Forms.Label lblWCCModel;
        private System.Windows.Forms.Label lblWCCR744;
        private System.Windows.Forms.Label lblWCCR407A;
        private System.Windows.Forms.Label lblWCCR410A;
        private System.Windows.Forms.Label lblWCCR507A;
        private System.Windows.Forms.Label lblWCCR407C;
        private System.Windows.Forms.Label lblWCCR404A;
        private System.Windows.Forms.Label lblWCCR134A;
        private System.Windows.Forms.TextBox txtWCCR507A;
        private System.Windows.Forms.Label lblWCCR22;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown nUdWCCWeight;
        private System.Windows.Forms.Label lblWCCWeight;
        private System.Windows.Forms.GroupBox grpGeneric;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown nUdGenericWeight;
        private System.Windows.Forms.Label lblGenericWeight;
        private System.Windows.Forms.Label lblReceiverWeight;
        private System.Windows.Forms.NumericUpDown nUdReceiverWeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblR22;
        private System.Windows.Forms.TextBox txtR507A;
        private System.Windows.Forms.Label lblR134A;
        private System.Windows.Forms.Label lblR404A;
        private System.Windows.Forms.Label lblR407C;
        private System.Windows.Forms.Label lblR507A;
        private System.Windows.Forms.Label lblR410A;
        private System.Windows.Forms.Label lblR407A;
        private System.Windows.Forms.Label lblR744;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TextBox txtR22;
        private System.Windows.Forms.TextBox txtR134A;
        private System.Windows.Forms.TextBox txtR404A;
        private System.Windows.Forms.TextBox txtR407C;
        private System.Windows.Forms.TextBox txtR410A;
        private System.Windows.Forms.TextBox txtR407A;
        private System.Windows.Forms.TextBox txtR744;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Button btnShowSizes;
        private System.Windows.Forms.GroupBox grpReceiver;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.ComboBox cboSubCoolerCircuits;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoilModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFM;
    }
}