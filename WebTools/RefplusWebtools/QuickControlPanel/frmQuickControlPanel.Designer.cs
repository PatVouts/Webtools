namespace RefplusWebtools.QuickControlPanel
{
    partial class FrmQuickControlPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQuickControlPanel));
            this.cboControlPanel = new System.Windows.Forms.ComboBox();
            this.lblControlPanel = new System.Windows.Forms.Label();
            this.lblControlOptions = new System.Windows.Forms.Label();
            this.cboControlVoltage = new System.Windows.Forms.ComboBox();
            this.lblControlVoltage = new System.Windows.Forms.Label();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.pnlPumpPackage = new System.Windows.Forms.Panel();
            this.cboPumpExpansionTankKitModel = new System.Windows.Forms.ComboBox();
            this.lblPumpExpansionTankKitModel = new System.Windows.Forms.Label();
            this.cboPumpExpansionTankKit = new System.Windows.Forms.ComboBox();
            this.lblPumpExpansionTankKit = new System.Windows.Forms.Label();
            this.lvPumpOptions = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numPumpTotalFeetOfWater = new System.Windows.Forms.NumericUpDown();
            this.lblPumpTotalFeetOfWater = new System.Windows.Forms.Label();
            this.cboPumpWaterValve = new System.Windows.Forms.ComboBox();
            this.lblPumpWaterValve = new System.Windows.Forms.Label();
            this.cboPumpNumberOfPump = new System.Windows.Forms.ComboBox();
            this.lblPumpNumberOfPump = new System.Windows.Forms.Label();
            this.cboPump = new System.Windows.Forms.ComboBox();
            this.pnlReceiver = new System.Windows.Forms.Panel();
            this.lblReceiverSST = new System.Windows.Forms.Label();
            this.lblFloodingValveKit = new System.Windows.Forms.Label();
            this.lblReceiverModel = new System.Windows.Forms.Label();
            this.lblReceiverCharge = new System.Windows.Forms.Label();
            this.pnlReceiverCircuit1 = new System.Windows.Forms.Panel();
            this.txtCircuit1SST = new System.Windows.Forms.TextBox();
            this.lblReceiverModel1 = new System.Windows.Forms.Label();
            this.chkCircuit1SightGlass = new System.Windows.Forms.CheckBox();
            this.numCircuit1SST = new System.Windows.Forms.NumericUpDown();
            this.lblReceiverCircuit1 = new System.Windows.Forms.Label();
            this.numCircuit1Charge = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cboReceiverFloodingValveKit1 = new System.Windows.Forms.ComboBox();
            this.pnlReceiverCircuit2 = new System.Windows.Forms.Panel();
            this.txtCircuit2SST = new System.Windows.Forms.TextBox();
            this.lblReceiverModel2 = new System.Windows.Forms.Label();
            this.chkCircuit2SightGlass = new System.Windows.Forms.CheckBox();
            this.numCircuit2SST = new System.Windows.Forms.NumericUpDown();
            this.lblReceiverCircuit2 = new System.Windows.Forms.Label();
            this.cboReceiverFloodingValveKit2 = new System.Windows.Forms.ComboBox();
            this.numCircuit2Charge = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPump = new System.Windows.Forms.Label();
            this.cboReceiver = new System.Windows.Forms.ComboBox();
            this.lblReceiver = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.lblSpecialPrice = new System.Windows.Forms.Label();
            this.numControlPanelPrice = new System.Windows.Forms.NumericUpDown();
            this.pnlPumpPackage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPumpTotalFeetOfWater)).BeginInit();
            this.pnlReceiver.SuspendLayout();
            this.pnlReceiverCircuit1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCircuit1SST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCircuit1Charge)).BeginInit();
            this.pnlReceiverCircuit2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCircuit2SST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCircuit2Charge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numControlPanelPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // cboControlPanel
            // 
            this.cboControlPanel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboControlPanel.DropDownWidth = 441;
            this.cboControlPanel.FormattingEnabled = true;
            this.cboControlPanel.Location = new System.Drawing.Point(180, 8);
            this.cboControlPanel.MaxDropDownItems = 35;
            this.cboControlPanel.Name = "cboControlPanel";
            this.cboControlPanel.Size = new System.Drawing.Size(443, 21);
            this.cboControlPanel.TabIndex = 0;
            this.cboControlPanel.SelectedIndexChanged += new System.EventHandler(this.cboControlPanel_SelectedIndexChanged);
            // 
            // lblControlPanel
            // 
            this.lblControlPanel.AutoSize = true;
            this.lblControlPanel.Location = new System.Drawing.Point(17, 10);
            this.lblControlPanel.Name = "lblControlPanel";
            this.lblControlPanel.Size = new System.Drawing.Size(75, 13);
            this.lblControlPanel.TabIndex = 60;
            this.lblControlPanel.Text = "sControl Panel";
            // 
            // lblControlOptions
            // 
            this.lblControlOptions.AutoSize = true;
            this.lblControlOptions.Location = new System.Drawing.Point(17, 58);
            this.lblControlOptions.Name = "lblControlOptions";
            this.lblControlOptions.Size = new System.Drawing.Size(84, 13);
            this.lblControlOptions.TabIndex = 64;
            this.lblControlOptions.Text = "sControl Options";
            // 
            // cboControlVoltage
            // 
            this.cboControlVoltage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboControlVoltage.FormattingEnabled = true;
            this.cboControlVoltage.Location = new System.Drawing.Point(180, 260);
            this.cboControlVoltage.Name = "cboControlVoltage";
            this.cboControlVoltage.Size = new System.Drawing.Size(443, 21);
            this.cboControlVoltage.TabIndex = 2;
            // 
            // lblControlVoltage
            // 
            this.lblControlVoltage.AutoSize = true;
            this.lblControlVoltage.Location = new System.Drawing.Point(17, 262);
            this.lblControlVoltage.Name = "lblControlVoltage";
            this.lblControlVoltage.Size = new System.Drawing.Size(84, 13);
            this.lblControlVoltage.TabIndex = 72;
            this.lblControlVoltage.Text = "sControl Voltage";
            // 
            // cmdAccept
            // 
            this.cmdAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdAccept.Image = ((System.Drawing.Image)(resources.GetObject("cmdAccept.Image")));
            this.cmdAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAccept.Location = new System.Drawing.Point(18, 477);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(605, 25);
            this.cmdAccept.TabIndex = 6;
            this.cmdAccept.Text = "sAccept";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // pnlPumpPackage
            // 
            this.pnlPumpPackage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnlPumpPackage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPumpPackage.Controls.Add(this.cboPumpExpansionTankKitModel);
            this.pnlPumpPackage.Controls.Add(this.lblPumpExpansionTankKitModel);
            this.pnlPumpPackage.Controls.Add(this.cboPumpExpansionTankKit);
            this.pnlPumpPackage.Controls.Add(this.lblPumpExpansionTankKit);
            this.pnlPumpPackage.Controls.Add(this.lvPumpOptions);
            this.pnlPumpPackage.Controls.Add(this.numPumpTotalFeetOfWater);
            this.pnlPumpPackage.Controls.Add(this.lblPumpTotalFeetOfWater);
            this.pnlPumpPackage.Controls.Add(this.cboPumpWaterValve);
            this.pnlPumpPackage.Controls.Add(this.lblPumpWaterValve);
            this.pnlPumpPackage.Controls.Add(this.cboPumpNumberOfPump);
            this.pnlPumpPackage.Controls.Add(this.lblPumpNumberOfPump);
            this.pnlPumpPackage.Enabled = false;
            this.pnlPumpPackage.Location = new System.Drawing.Point(18, 314);
            this.pnlPumpPackage.Name = "pnlPumpPackage";
            this.pnlPumpPackage.Size = new System.Drawing.Size(605, 158);
            this.pnlPumpPackage.TabIndex = 5;
            this.pnlPumpPackage.Visible = false;
            // 
            // cboPumpExpansionTankKitModel
            // 
            this.cboPumpExpansionTankKitModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPumpExpansionTankKitModel.Enabled = false;
            this.cboPumpExpansionTankKitModel.FormattingEnabled = true;
            this.cboPumpExpansionTankKitModel.Location = new System.Drawing.Point(136, 84);
            this.cboPumpExpansionTankKitModel.Name = "cboPumpExpansionTankKitModel";
            this.cboPumpExpansionTankKitModel.Size = new System.Drawing.Size(176, 21);
            this.cboPumpExpansionTankKitModel.TabIndex = 83;
            // 
            // lblPumpExpansionTankKitModel
            // 
            this.lblPumpExpansionTankKitModel.AutoSize = true;
            this.lblPumpExpansionTankKitModel.Location = new System.Drawing.Point(6, 92);
            this.lblPumpExpansionTankKitModel.Name = "lblPumpExpansionTankKitModel";
            this.lblPumpExpansionTankKitModel.Size = new System.Drawing.Size(41, 13);
            this.lblPumpExpansionTankKitModel.TabIndex = 84;
            this.lblPumpExpansionTankKitModel.Text = "sModel";
            // 
            // cboPumpExpansionTankKit
            // 
            this.cboPumpExpansionTankKit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPumpExpansionTankKit.FormattingEnabled = true;
            this.cboPumpExpansionTankKit.Location = new System.Drawing.Point(136, 57);
            this.cboPumpExpansionTankKit.Name = "cboPumpExpansionTankKit";
            this.cboPumpExpansionTankKit.Size = new System.Drawing.Size(176, 21);
            this.cboPumpExpansionTankKit.TabIndex = 81;
            this.cboPumpExpansionTankKit.SelectedIndexChanged += new System.EventHandler(this.cboPumpExpansionTankKit_SelectedIndexChanged);
            // 
            // lblPumpExpansionTankKit
            // 
            this.lblPumpExpansionTankKit.AutoSize = true;
            this.lblPumpExpansionTankKit.Location = new System.Drawing.Point(6, 64);
            this.lblPumpExpansionTankKit.Name = "lblPumpExpansionTankKit";
            this.lblPumpExpansionTankKit.Size = new System.Drawing.Size(104, 13);
            this.lblPumpExpansionTankKit.TabIndex = 82;
            this.lblPumpExpansionTankKit.Text = "sExpansion Tank Kit";
            // 
            // lvPumpOptions
            // 
            this.lvPumpOptions.CheckBoxes = true;
            this.lvPumpOptions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvPumpOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvPumpOptions.FullRowSelect = true;
            this.lvPumpOptions.GridLines = true;
            this.lvPumpOptions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvPumpOptions.HideSelection = false;
            this.lvPumpOptions.Location = new System.Drawing.Point(316, 3);
            this.lvPumpOptions.MultiSelect = false;
            this.lvPumpOptions.Name = "lvPumpOptions";
            this.lvPumpOptions.Size = new System.Drawing.Size(279, 142);
            this.lvPumpOptions.TabIndex = 78;
            this.lvPumpOptions.UseCompatibleStateImageBehavior = false;
            this.lvPumpOptions.View = System.Windows.Forms.View.Details;
            this.lvPumpOptions.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvPumpOptions_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 26;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID";
            this.columnHeader2.Width = 0;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "sOption";
            this.columnHeader3.Width = 228;
            // 
            // numPumpTotalFeetOfWater
            // 
            this.numPumpTotalFeetOfWater.Location = new System.Drawing.Point(136, 4);
            this.numPumpTotalFeetOfWater.Maximum = new decimal(new int[] {
            125,
            0,
            0,
            0});
            this.numPumpTotalFeetOfWater.Name = "numPumpTotalFeetOfWater";
            this.numPumpTotalFeetOfWater.Size = new System.Drawing.Size(176, 20);
            this.numPumpTotalFeetOfWater.TabIndex = 73;
            this.numPumpTotalFeetOfWater.Value = new decimal(new int[] {
            125,
            0,
            0,
            0});
            this.numPumpTotalFeetOfWater.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblPumpTotalFeetOfWater
            // 
            this.lblPumpTotalFeetOfWater.AutoSize = true;
            this.lblPumpTotalFeetOfWater.Location = new System.Drawing.Point(6, 10);
            this.lblPumpTotalFeetOfWater.Name = "lblPumpTotalFeetOfWater";
            this.lblPumpTotalFeetOfWater.Size = new System.Drawing.Size(85, 13);
            this.lblPumpTotalFeetOfWater.TabIndex = 72;
            this.lblPumpTotalFeetOfWater.Text = "sTotal Ft of H2O";
            // 
            // cboPumpWaterValve
            // 
            this.cboPumpWaterValve.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPumpWaterValve.FormattingEnabled = true;
            this.cboPumpWaterValve.Location = new System.Drawing.Point(136, 111);
            this.cboPumpWaterValve.Name = "cboPumpWaterValve";
            this.cboPumpWaterValve.Size = new System.Drawing.Size(176, 21);
            this.cboPumpWaterValve.TabIndex = 69;
            // 
            // lblPumpWaterValve
            // 
            this.lblPumpWaterValve.AutoSize = true;
            this.lblPumpWaterValve.Location = new System.Drawing.Point(6, 118);
            this.lblPumpWaterValve.Name = "lblPumpWaterValve";
            this.lblPumpWaterValve.Size = new System.Drawing.Size(71, 13);
            this.lblPumpWaterValve.TabIndex = 70;
            this.lblPumpWaterValve.Text = "sWater Valve";
            // 
            // cboPumpNumberOfPump
            // 
            this.cboPumpNumberOfPump.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPumpNumberOfPump.FormattingEnabled = true;
            this.cboPumpNumberOfPump.Location = new System.Drawing.Point(136, 30);
            this.cboPumpNumberOfPump.Name = "cboPumpNumberOfPump";
            this.cboPumpNumberOfPump.Size = new System.Drawing.Size(176, 21);
            this.cboPumpNumberOfPump.TabIndex = 63;
            // 
            // lblPumpNumberOfPump
            // 
            this.lblPumpNumberOfPump.AutoSize = true;
            this.lblPumpNumberOfPump.Location = new System.Drawing.Point(6, 37);
            this.lblPumpNumberOfPump.Name = "lblPumpNumberOfPump";
            this.lblPumpNumberOfPump.Size = new System.Drawing.Size(90, 13);
            this.lblPumpNumberOfPump.TabIndex = 64;
            this.lblPumpNumberOfPump.Text = "sNumber of pump";
            // 
            // cboPump
            // 
            this.cboPump.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPump.FormattingEnabled = true;
            this.cboPump.Location = new System.Drawing.Point(97, 287);
            this.cboPump.Name = "cboPump";
            this.cboPump.Size = new System.Drawing.Size(176, 21);
            this.cboPump.TabIndex = 3;
            this.cboPump.Visible = false;
            this.cboPump.SelectedIndexChanged += new System.EventHandler(this.cboPump_SelectedIndexChanged);
            // 
            // pnlReceiver
            // 
            this.pnlReceiver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnlReceiver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReceiver.Controls.Add(this.lblReceiverSST);
            this.pnlReceiver.Controls.Add(this.lblFloodingValveKit);
            this.pnlReceiver.Controls.Add(this.lblReceiverModel);
            this.pnlReceiver.Controls.Add(this.lblReceiverCharge);
            this.pnlReceiver.Controls.Add(this.pnlReceiverCircuit1);
            this.pnlReceiver.Controls.Add(this.pnlReceiverCircuit2);
            this.pnlReceiver.Enabled = false;
            this.pnlReceiver.Location = new System.Drawing.Point(45, 314);
            this.pnlReceiver.Name = "pnlReceiver";
            this.pnlReceiver.Size = new System.Drawing.Size(578, 158);
            this.pnlReceiver.TabIndex = 77;
            this.pnlReceiver.Visible = false;
            // 
            // lblReceiverSST
            // 
            this.lblReceiverSST.Location = new System.Drawing.Point(267, 2);
            this.lblReceiverSST.Name = "lblReceiverSST";
            this.lblReceiverSST.Size = new System.Drawing.Size(48, 17);
            this.lblReceiverSST.TabIndex = 93;
            this.lblReceiverSST.Text = "sSST";
            this.lblReceiverSST.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFloodingValveKit
            // 
            this.lblFloodingValveKit.Location = new System.Drawing.Point(319, 1);
            this.lblFloodingValveKit.Name = "lblFloodingValveKit";
            this.lblFloodingValveKit.Size = new System.Drawing.Size(122, 17);
            this.lblFloodingValveKit.TabIndex = 90;
            this.lblFloodingValveKit.Text = "sFlooding Valve Kit";
            this.lblFloodingValveKit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReceiverModel
            // 
            this.lblReceiverModel.Location = new System.Drawing.Point(138, 2);
            this.lblReceiverModel.Name = "lblReceiverModel";
            this.lblReceiverModel.Size = new System.Drawing.Size(125, 17);
            this.lblReceiverModel.TabIndex = 89;
            this.lblReceiverModel.Text = "sReceiver Model";
            this.lblReceiverModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReceiverCharge
            // 
            this.lblReceiverCharge.Location = new System.Drawing.Point(68, 2);
            this.lblReceiverCharge.Name = "lblReceiverCharge";
            this.lblReceiverCharge.Size = new System.Drawing.Size(48, 17);
            this.lblReceiverCharge.TabIndex = 88;
            this.lblReceiverCharge.Text = "sCharge";
            this.lblReceiverCharge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlReceiverCircuit1
            // 
            this.pnlReceiverCircuit1.Controls.Add(this.txtCircuit1SST);
            this.pnlReceiverCircuit1.Controls.Add(this.lblReceiverModel1);
            this.pnlReceiverCircuit1.Controls.Add(this.chkCircuit1SightGlass);
            this.pnlReceiverCircuit1.Controls.Add(this.numCircuit1SST);
            this.pnlReceiverCircuit1.Controls.Add(this.lblReceiverCircuit1);
            this.pnlReceiverCircuit1.Controls.Add(this.numCircuit1Charge);
            this.pnlReceiverCircuit1.Controls.Add(this.label1);
            this.pnlReceiverCircuit1.Controls.Add(this.cboReceiverFloodingValveKit1);
            this.pnlReceiverCircuit1.Location = new System.Drawing.Point(3, 21);
            this.pnlReceiverCircuit1.Name = "pnlReceiverCircuit1";
            this.pnlReceiverCircuit1.Size = new System.Drawing.Size(568, 26);
            this.pnlReceiverCircuit1.TabIndex = 87;
            // 
            // txtCircuit1SST
            // 
            this.txtCircuit1SST.Location = new System.Drawing.Point(262, 3);
            this.txtCircuit1SST.MaxLength = 3;
            this.txtCircuit1SST.Name = "txtCircuit1SST";
            this.txtCircuit1SST.Size = new System.Drawing.Size(48, 20);
            this.txtCircuit1SST.TabIndex = 96;
            this.txtCircuit1SST.Text = "45";
            this.txtCircuit1SST.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCircuit1SST.Validated += new System.EventHandler(this.txtCircuit1SST_Validated);
            // 
            // lblReceiverModel1
            // 
            this.lblReceiverModel1.BackColor = System.Drawing.Color.White;
            this.lblReceiverModel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReceiverModel1.Location = new System.Drawing.Point(133, 2);
            this.lblReceiverModel1.Name = "lblReceiverModel1";
            this.lblReceiverModel1.Size = new System.Drawing.Size(125, 22);
            this.lblReceiverModel1.TabIndex = 95;
            this.lblReceiverModel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkCircuit1SightGlass
            // 
            this.chkCircuit1SightGlass.AutoSize = true;
            this.chkCircuit1SightGlass.Location = new System.Drawing.Point(446, 5);
            this.chkCircuit1SightGlass.Name = "chkCircuit1SightGlass";
            this.chkCircuit1SightGlass.Size = new System.Drawing.Size(84, 17);
            this.chkCircuit1SightGlass.TabIndex = 94;
            this.chkCircuit1SightGlass.Text = "sSight Glass";
            this.chkCircuit1SightGlass.UseVisualStyleBackColor = true;
            // 
            // numCircuit1SST
            // 
            this.numCircuit1SST.Location = new System.Drawing.Point(538, 2);
            this.numCircuit1SST.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.numCircuit1SST.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            -2147483648});
            this.numCircuit1SST.Name = "numCircuit1SST";
            this.numCircuit1SST.Size = new System.Drawing.Size(25, 20);
            this.numCircuit1SST.TabIndex = 85;
            this.numCircuit1SST.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.numCircuit1SST.Visible = false;
            this.numCircuit1SST.ValueChanged += new System.EventHandler(this.numCircuit1SST_ValueChanged);
            this.numCircuit1SST.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblReceiverCircuit1
            // 
            this.lblReceiverCircuit1.AutoSize = true;
            this.lblReceiverCircuit1.Location = new System.Drawing.Point(3, 5);
            this.lblReceiverCircuit1.Name = "lblReceiverCircuit1";
            this.lblReceiverCircuit1.Size = new System.Drawing.Size(57, 13);
            this.lblReceiverCircuit1.TabIndex = 84;
            this.lblReceiverCircuit1.Text = "sCircuit #1";
            // 
            // numCircuit1Charge
            // 
            this.numCircuit1Charge.Location = new System.Drawing.Point(63, 3);
            this.numCircuit1Charge.Name = "numCircuit1Charge";
            this.numCircuit1Charge.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numCircuit1Charge.Size = new System.Drawing.Size(48, 20);
            this.numCircuit1Charge.TabIndex = 80;
            this.numCircuit1Charge.ValueChanged += new System.EventHandler(this.numCircuit1Charge_ValueChanged);
            this.numCircuit1Charge.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 82;
            this.label1.Text = "%";
            // 
            // cboReceiverFloodingValveKit1
            // 
            this.cboReceiverFloodingValveKit1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReceiverFloodingValveKit1.FormattingEnabled = true;
            this.cboReceiverFloodingValveKit1.Location = new System.Drawing.Point(314, 2);
            this.cboReceiverFloodingValveKit1.Name = "cboReceiverFloodingValveKit1";
            this.cboReceiverFloodingValveKit1.Size = new System.Drawing.Size(126, 21);
            this.cboReceiverFloodingValveKit1.TabIndex = 79;
            // 
            // pnlReceiverCircuit2
            // 
            this.pnlReceiverCircuit2.Controls.Add(this.txtCircuit2SST);
            this.pnlReceiverCircuit2.Controls.Add(this.lblReceiverModel2);
            this.pnlReceiverCircuit2.Controls.Add(this.chkCircuit2SightGlass);
            this.pnlReceiverCircuit2.Controls.Add(this.numCircuit2SST);
            this.pnlReceiverCircuit2.Controls.Add(this.lblReceiverCircuit2);
            this.pnlReceiverCircuit2.Controls.Add(this.cboReceiverFloodingValveKit2);
            this.pnlReceiverCircuit2.Controls.Add(this.numCircuit2Charge);
            this.pnlReceiverCircuit2.Controls.Add(this.label2);
            this.pnlReceiverCircuit2.Location = new System.Drawing.Point(3, 46);
            this.pnlReceiverCircuit2.Name = "pnlReceiverCircuit2";
            this.pnlReceiverCircuit2.Size = new System.Drawing.Size(568, 26);
            this.pnlReceiverCircuit2.TabIndex = 86;
            // 
            // txtCircuit2SST
            // 
            this.txtCircuit2SST.Location = new System.Drawing.Point(262, 2);
            this.txtCircuit2SST.MaxLength = 3;
            this.txtCircuit2SST.Name = "txtCircuit2SST";
            this.txtCircuit2SST.Size = new System.Drawing.Size(48, 20);
            this.txtCircuit2SST.TabIndex = 97;
            this.txtCircuit2SST.Text = "45";
            this.txtCircuit2SST.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCircuit2SST.Validated += new System.EventHandler(this.txtCircuit2SST_Validated);
            // 
            // lblReceiverModel2
            // 
            this.lblReceiverModel2.BackColor = System.Drawing.Color.White;
            this.lblReceiverModel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReceiverModel2.Location = new System.Drawing.Point(133, 2);
            this.lblReceiverModel2.Name = "lblReceiverModel2";
            this.lblReceiverModel2.Size = new System.Drawing.Size(125, 22);
            this.lblReceiverModel2.TabIndex = 96;
            this.lblReceiverModel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkCircuit2SightGlass
            // 
            this.chkCircuit2SightGlass.AutoSize = true;
            this.chkCircuit2SightGlass.Location = new System.Drawing.Point(446, 5);
            this.chkCircuit2SightGlass.Name = "chkCircuit2SightGlass";
            this.chkCircuit2SightGlass.Size = new System.Drawing.Size(84, 17);
            this.chkCircuit2SightGlass.TabIndex = 95;
            this.chkCircuit2SightGlass.Text = "sSight Glass";
            this.chkCircuit2SightGlass.UseVisualStyleBackColor = true;
            // 
            // numCircuit2SST
            // 
            this.numCircuit2SST.Location = new System.Drawing.Point(538, 3);
            this.numCircuit2SST.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.numCircuit2SST.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            -2147483648});
            this.numCircuit2SST.Name = "numCircuit2SST";
            this.numCircuit2SST.Size = new System.Drawing.Size(25, 20);
            this.numCircuit2SST.TabIndex = 86;
            this.numCircuit2SST.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.numCircuit2SST.Visible = false;
            this.numCircuit2SST.ValueChanged += new System.EventHandler(this.numCircuit2SST_ValueChanged);
            this.numCircuit2SST.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblReceiverCircuit2
            // 
            this.lblReceiverCircuit2.AutoSize = true;
            this.lblReceiverCircuit2.Location = new System.Drawing.Point(3, 5);
            this.lblReceiverCircuit2.Name = "lblReceiverCircuit2";
            this.lblReceiverCircuit2.Size = new System.Drawing.Size(57, 13);
            this.lblReceiverCircuit2.TabIndex = 85;
            this.lblReceiverCircuit2.Text = "sCircuit #2";
            // 
            // cboReceiverFloodingValveKit2
            // 
            this.cboReceiverFloodingValveKit2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReceiverFloodingValveKit2.FormattingEnabled = true;
            this.cboReceiverFloodingValveKit2.Location = new System.Drawing.Point(314, 2);
            this.cboReceiverFloodingValveKit2.Name = "cboReceiverFloodingValveKit2";
            this.cboReceiverFloodingValveKit2.Size = new System.Drawing.Size(126, 21);
            this.cboReceiverFloodingValveKit2.TabIndex = 85;
            // 
            // numCircuit2Charge
            // 
            this.numCircuit2Charge.Location = new System.Drawing.Point(63, 3);
            this.numCircuit2Charge.Name = "numCircuit2Charge";
            this.numCircuit2Charge.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numCircuit2Charge.Size = new System.Drawing.Size(48, 20);
            this.numCircuit2Charge.TabIndex = 81;
            this.numCircuit2Charge.ValueChanged += new System.EventHandler(this.numCircuit2Charge_ValueChanged);
            this.numCircuit2Charge.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 83;
            this.label2.Text = "%";
            // 
            // lblPump
            // 
            this.lblPump.AutoSize = true;
            this.lblPump.Location = new System.Drawing.Point(17, 289);
            this.lblPump.Name = "lblPump";
            this.lblPump.Size = new System.Drawing.Size(39, 13);
            this.lblPump.TabIndex = 62;
            this.lblPump.Text = "sPump";
            this.lblPump.Visible = false;
            // 
            // cboReceiver
            // 
            this.cboReceiver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReceiver.FormattingEnabled = true;
            this.cboReceiver.Location = new System.Drawing.Point(97, 287);
            this.cboReceiver.Name = "cboReceiver";
            this.cboReceiver.Size = new System.Drawing.Size(392, 21);
            this.cboReceiver.TabIndex = 4;
            this.cboReceiver.Visible = false;
            this.cboReceiver.SelectedIndexChanged += new System.EventHandler(this.cboReceiver_SelectedIndexChanged);
            // 
            // lblReceiver
            // 
            this.lblReceiver.AutoSize = true;
            this.lblReceiver.Location = new System.Drawing.Point(17, 289);
            this.lblReceiver.Name = "lblReceiver";
            this.lblReceiver.Size = new System.Drawing.Size(55, 13);
            this.lblReceiver.TabIndex = 79;
            this.lblReceiver.Text = "sReceiver";
            this.lblReceiver.Visible = false;
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(57, 127);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(29, 24);
            this.btnHelp.TabIndex = 240;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // pnlOptions
            // 
            this.pnlOptions.AutoScroll = true;
            this.pnlOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOptions.Location = new System.Drawing.Point(180, 59);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(443, 195);
            this.pnlOptions.TabIndex = 241;
            // 
            // lblSpecialPrice
            // 
            this.lblSpecialPrice.AutoSize = true;
            this.lblSpecialPrice.Location = new System.Drawing.Point(17, 34);
            this.lblSpecialPrice.Name = "lblSpecialPrice";
            this.lblSpecialPrice.Size = new System.Drawing.Size(74, 13);
            this.lblSpecialPrice.TabIndex = 242;
            this.lblSpecialPrice.Text = "sSpecial Price";
            this.lblSpecialPrice.Visible = false;
            // 
            // numControlPanelPrice
            // 
            this.numControlPanelPrice.Location = new System.Drawing.Point(180, 33);
            this.numControlPanelPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numControlPanelPrice.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.numControlPanelPrice.Name = "numControlPanelPrice";
            this.numControlPanelPrice.Size = new System.Drawing.Size(443, 20);
            this.numControlPanelPrice.TabIndex = 243;
            this.numControlPanelPrice.Visible = false;
            // 
            // FrmQuickControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(642, 507);
            this.Controls.Add(this.numControlPanelPrice);
            this.Controls.Add(this.lblSpecialPrice);
            this.Controls.Add(this.pnlOptions);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.cboControlVoltage);
            this.Controls.Add(this.lblControlVoltage);
            this.Controls.Add(this.lblControlOptions);
            this.Controls.Add(this.cboControlPanel);
            this.Controls.Add(this.lblControlPanel);
            this.Controls.Add(this.cboPump);
            this.Controls.Add(this.lblPump);
            this.Controls.Add(this.cboReceiver);
            this.Controls.Add(this.lblReceiver);
            this.Controls.Add(this.pnlPumpPackage);
            this.Controls.Add(this.pnlReceiver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQuickControlPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "sQuick Control Panel";
            this.Load += new System.EventHandler(this.frmQuickControlPanel_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmQuickControlPanel_HelpRequested);
            this.pnlPumpPackage.ResumeLayout(false);
            this.pnlPumpPackage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPumpTotalFeetOfWater)).EndInit();
            this.pnlReceiver.ResumeLayout(false);
            this.pnlReceiverCircuit1.ResumeLayout(false);
            this.pnlReceiverCircuit1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCircuit1SST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCircuit1Charge)).EndInit();
            this.pnlReceiverCircuit2.ResumeLayout(false);
            this.pnlReceiverCircuit2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCircuit2SST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCircuit2Charge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numControlPanelPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboControlPanel;
        private System.Windows.Forms.Label lblControlPanel;
        private System.Windows.Forms.Label lblControlOptions;
        private System.Windows.Forms.ComboBox cboControlVoltage;
        private System.Windows.Forms.Label lblControlVoltage;
        private System.Windows.Forms.Button cmdAccept;
        private System.Windows.Forms.Panel pnlPumpPackage;
        private System.Windows.Forms.ComboBox cboPumpNumberOfPump;
        private System.Windows.Forms.Label lblPumpNumberOfPump;
        private System.Windows.Forms.ComboBox cboPump;
        private System.Windows.Forms.ComboBox cboPumpWaterValve;
        private System.Windows.Forms.Label lblPumpWaterValve;
        private System.Windows.Forms.Panel pnlReceiver;
        private System.Windows.Forms.ComboBox cboReceiverFloodingValveKit1;
        private System.Windows.Forms.Label lblPump;
        private System.Windows.Forms.NumericUpDown numPumpTotalFeetOfWater;
        private System.Windows.Forms.Label lblPumpTotalFeetOfWater;
        private System.Windows.Forms.ComboBox cboReceiver;
        private System.Windows.Forms.Label lblReceiver;
        private System.Windows.Forms.ComboBox cboReceiverFloodingValveKit2;
        private System.Windows.Forms.ListView lvPumpOptions;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ComboBox cboPumpExpansionTankKit;
        private System.Windows.Forms.Label lblPumpExpansionTankKit;
        private System.Windows.Forms.ComboBox cboPumpExpansionTankKitModel;
        private System.Windows.Forms.Label lblPumpExpansionTankKitModel;
        private System.Windows.Forms.NumericUpDown numCircuit1Charge;
        private System.Windows.Forms.NumericUpDown numCircuit2Charge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblReceiverCircuit1;
        private System.Windows.Forms.Label lblReceiverCircuit2;
        private System.Windows.Forms.Panel pnlReceiverCircuit2;
        private System.Windows.Forms.Panel pnlReceiverCircuit1;
        private System.Windows.Forms.Label lblReceiverCharge;
        private System.Windows.Forms.Label lblReceiverModel;
        private System.Windows.Forms.Label lblFloodingValveKit;
        private System.Windows.Forms.Label lblReceiverSST;
        private System.Windows.Forms.NumericUpDown numCircuit1SST;
        private System.Windows.Forms.NumericUpDown numCircuit2SST;
        private System.Windows.Forms.CheckBox chkCircuit1SightGlass;
        private System.Windows.Forms.CheckBox chkCircuit2SightGlass;
        private System.Windows.Forms.Label lblReceiverModel1;
        private System.Windows.Forms.Label lblReceiverModel2;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Label lblSpecialPrice;
        private System.Windows.Forms.NumericUpDown numControlPanelPrice;
        private System.Windows.Forms.TextBox txtCircuit1SST;
        private System.Windows.Forms.TextBox txtCircuit2SST;
    }
}