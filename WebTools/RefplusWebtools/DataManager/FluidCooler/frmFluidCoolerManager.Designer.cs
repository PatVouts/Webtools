namespace RefplusWebtools.DataManager.FluidCooler
{
    partial class FrmFluidCoolerManager
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
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFluidCoolerManager));
            this.numCFM = new System.Windows.Forms.NumericUpDown();
            this.lblCFM = new System.Windows.Forms.Label();
            this.cboUnitType = new System.Windows.Forms.ComboBox();
            this.lblUnitType = new System.Windows.Forms.Label();
            this.cboFanArrangement = new System.Windows.Forms.ComboBox();
            this.lblFanArrangement = new System.Windows.Forms.Label();
            this.numRow = new System.Windows.Forms.NumericUpDown();
            this.lblRow = new System.Windows.Forms.Label();
            this.cboFPI = new System.Windows.Forms.ComboBox();
            this.lblFPI = new System.Windows.Forms.Label();
            this.numFinLength = new System.Windows.Forms.NumericUpDown();
            this.lblFinLength = new System.Windows.Forms.Label();
            this.lblE = new System.Windows.Forms.Label();
            this.lblF = new System.Windows.Forms.Label();
            this.lblG = new System.Windows.Forms.Label();
            this.numTubesE = new System.Windows.Forms.NumericUpDown();
            this.numTubesF = new System.Windows.Forms.NumericUpDown();
            this.numTubesG = new System.Windows.Forms.NumericUpDown();
            this.pnlE = new System.Windows.Forms.Panel();
            this.cmdRemoveCircuitE = new System.Windows.Forms.Button();
            this.cmdAddCircuitE = new System.Windows.Forms.Button();
            this.numCircuitE = new System.Windows.Forms.NumericUpDown();
            this.lvCircuitE = new GlacialComponents.Controls.GlacialList();
            this.numWeightE = new System.Windows.Forms.NumericUpDown();
            this.pnlG = new System.Windows.Forms.Panel();
            this.cmdRemoveCircuitG = new System.Windows.Forms.Button();
            this.cmdAddCircuitG = new System.Windows.Forms.Button();
            this.numCircuitG = new System.Windows.Forms.NumericUpDown();
            this.lvCircuitG = new GlacialComponents.Controls.GlacialList();
            this.numWeightG = new System.Windows.Forms.NumericUpDown();
            this.pnlF = new System.Windows.Forms.Panel();
            this.cmdRemoveCircuitF = new System.Windows.Forms.Button();
            this.cmdAddCircuitF = new System.Windows.Forms.Button();
            this.numCircuitF = new System.Windows.Forms.NumericUpDown();
            this.lvCircuitF = new GlacialComponents.Controls.GlacialList();
            this.numWeightF = new System.Windows.Forms.NumericUpDown();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.lblPrice = new System.Windows.Forms.Label();
            this.cboModels = new System.Windows.Forms.ComboBox();
            this.cmdLoadModel = new System.Windows.Forms.Button();
            this.cmdDeleteModel = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.radVertical = new System.Windows.Forms.RadioButton();
            this.radHorizontal = new System.Windows.Forms.RadioButton();
            this.lblAirFlow = new System.Windows.Forms.Label();
            this.lblTubes = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblCircuits = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numCFM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFinLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTubesE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTubesF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTubesG)).BeginInit();
            this.pnlE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCircuitE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeightE)).BeginInit();
            this.pnlG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCircuitG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeightG)).BeginInit();
            this.pnlF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCircuitF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeightF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // numCFM
            // 
            this.numCFM.Location = new System.Drawing.Point(121, 88);
            this.numCFM.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numCFM.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCFM.Name = "numCFM";
            this.numCFM.Size = new System.Drawing.Size(131, 20);
            this.numCFM.TabIndex = 0;
            this.numCFM.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCFM
            // 
            this.lblCFM.AutoSize = true;
            this.lblCFM.Location = new System.Drawing.Point(9, 90);
            this.lblCFM.Name = "lblCFM";
            this.lblCFM.Size = new System.Drawing.Size(34, 13);
            this.lblCFM.TabIndex = 1;
            this.lblCFM.Text = "sCFM";
            // 
            // cboUnitType
            // 
            this.cboUnitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnitType.DropDownWidth = 300;
            this.cboUnitType.FormattingEnabled = true;
            this.cboUnitType.Location = new System.Drawing.Point(121, 114);
            this.cboUnitType.Name = "cboUnitType";
            this.cboUnitType.Size = new System.Drawing.Size(131, 21);
            this.cboUnitType.TabIndex = 76;
            this.cboUnitType.SelectedIndexChanged += new System.EventHandler(this.cboUnitType_SelectedIndexChanged);
            // 
            // lblUnitType
            // 
            this.lblUnitType.AutoSize = true;
            this.lblUnitType.Location = new System.Drawing.Point(9, 117);
            this.lblUnitType.Name = "lblUnitType";
            this.lblUnitType.Size = new System.Drawing.Size(58, 13);
            this.lblUnitType.TabIndex = 77;
            this.lblUnitType.Text = "sUnit Type";
            // 
            // cboFanArrangement
            // 
            this.cboFanArrangement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFanArrangement.FormattingEnabled = true;
            this.cboFanArrangement.Location = new System.Drawing.Point(121, 141);
            this.cboFanArrangement.Name = "cboFanArrangement";
            this.cboFanArrangement.Size = new System.Drawing.Size(131, 21);
            this.cboFanArrangement.TabIndex = 78;
            // 
            // lblFanArrangement
            // 
            this.lblFanArrangement.AutoSize = true;
            this.lblFanArrangement.Location = new System.Drawing.Point(9, 144);
            this.lblFanArrangement.Name = "lblFanArrangement";
            this.lblFanArrangement.Size = new System.Drawing.Size(93, 13);
            this.lblFanArrangement.TabIndex = 79;
            this.lblFanArrangement.Text = "sFan Arrangement";
            // 
            // numRow
            // 
            this.numRow.Location = new System.Drawing.Point(121, 168);
            this.numRow.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numRow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRow.Name = "numRow";
            this.numRow.Size = new System.Drawing.Size(131, 20);
            this.numRow.TabIndex = 80;
            this.numRow.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblRow
            // 
            this.lblRow.AutoSize = true;
            this.lblRow.Location = new System.Drawing.Point(9, 170);
            this.lblRow.Name = "lblRow";
            this.lblRow.Size = new System.Drawing.Size(34, 13);
            this.lblRow.TabIndex = 81;
            this.lblRow.Text = "sRow";
            // 
            // cboFPI
            // 
            this.cboFPI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboFPI.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFPI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFPI.FormattingEnabled = true;
            this.cboFPI.Location = new System.Drawing.Point(121, 194);
            this.cboFPI.Name = "cboFPI";
            this.cboFPI.Size = new System.Drawing.Size(131, 21);
            this.cboFPI.TabIndex = 82;
            // 
            // lblFPI
            // 
            this.lblFPI.AutoSize = true;
            this.lblFPI.Location = new System.Drawing.Point(9, 197);
            this.lblFPI.Name = "lblFPI";
            this.lblFPI.Size = new System.Drawing.Size(82, 13);
            this.lblFPI.TabIndex = 83;
            this.lblFPI.Text = "sFins/Inch (FPI)";
            // 
            // numFinLength
            // 
            this.numFinLength.DecimalPlaces = 3;
            this.numFinLength.Location = new System.Drawing.Point(121, 221);
            this.numFinLength.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numFinLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFinLength.Name = "numFinLength";
            this.numFinLength.Size = new System.Drawing.Size(131, 20);
            this.numFinLength.TabIndex = 84;
            this.numFinLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblFinLength
            // 
            this.lblFinLength.AutoSize = true;
            this.lblFinLength.Location = new System.Drawing.Point(9, 223);
            this.lblFinLength.Name = "lblFinLength";
            this.lblFinLength.Size = new System.Drawing.Size(62, 13);
            this.lblFinLength.TabIndex = 85;
            this.lblFinLength.Text = "sFin Length";
            // 
            // lblE
            // 
            this.lblE.BackColor = System.Drawing.Color.Black;
            this.lblE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblE.ForeColor = System.Drawing.Color.White;
            this.lblE.Location = new System.Drawing.Point(3, 2);
            this.lblE.Name = "lblE";
            this.lblE.Size = new System.Drawing.Size(143, 18);
            this.lblE.TabIndex = 86;
            this.lblE.Text = "E";
            this.lblE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblF
            // 
            this.lblF.BackColor = System.Drawing.Color.Black;
            this.lblF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblF.ForeColor = System.Drawing.Color.White;
            this.lblF.Location = new System.Drawing.Point(3, 2);
            this.lblF.Name = "lblF";
            this.lblF.Size = new System.Drawing.Size(143, 18);
            this.lblF.TabIndex = 87;
            this.lblF.Text = "F";
            this.lblF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblG
            // 
            this.lblG.BackColor = System.Drawing.Color.Black;
            this.lblG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblG.ForeColor = System.Drawing.Color.White;
            this.lblG.Location = new System.Drawing.Point(3, 2);
            this.lblG.Name = "lblG";
            this.lblG.Size = new System.Drawing.Size(143, 18);
            this.lblG.TabIndex = 88;
            this.lblG.Text = "G";
            this.lblG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numTubesE
            // 
            this.numTubesE.Location = new System.Drawing.Point(3, 23);
            this.numTubesE.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numTubesE.Name = "numTubesE";
            this.numTubesE.Size = new System.Drawing.Size(143, 20);
            this.numTubesE.TabIndex = 90;
            this.numTubesE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numTubesF
            // 
            this.numTubesF.Location = new System.Drawing.Point(3, 23);
            this.numTubesF.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numTubesF.Name = "numTubesF";
            this.numTubesF.Size = new System.Drawing.Size(143, 20);
            this.numTubesF.TabIndex = 91;
            this.numTubesF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numTubesG
            // 
            this.numTubesG.Location = new System.Drawing.Point(3, 23);
            this.numTubesG.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numTubesG.Name = "numTubesG";
            this.numTubesG.Size = new System.Drawing.Size(143, 20);
            this.numTubesG.TabIndex = 92;
            this.numTubesG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlE
            // 
            this.pnlE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlE.Controls.Add(this.cmdRemoveCircuitE);
            this.pnlE.Controls.Add(this.cmdAddCircuitE);
            this.pnlE.Controls.Add(this.numCircuitE);
            this.pnlE.Controls.Add(this.lvCircuitE);
            this.pnlE.Controls.Add(this.numWeightE);
            this.pnlE.Controls.Add(this.lblE);
            this.pnlE.Controls.Add(this.numTubesE);
            this.pnlE.Location = new System.Drawing.Point(323, 12);
            this.pnlE.Name = "pnlE";
            this.pnlE.Size = new System.Drawing.Size(150, 302);
            this.pnlE.TabIndex = 93;
            // 
            // cmdRemoveCircuitE
            // 
            this.cmdRemoveCircuitE.Location = new System.Drawing.Point(3, 272);
            this.cmdRemoveCircuitE.Name = "cmdRemoveCircuitE";
            this.cmdRemoveCircuitE.Size = new System.Drawing.Size(142, 23);
            this.cmdRemoveCircuitE.TabIndex = 102;
            this.cmdRemoveCircuitE.Text = "sRemove Circuit";
            this.cmdRemoveCircuitE.UseVisualStyleBackColor = true;
            this.cmdRemoveCircuitE.Click += new System.EventHandler(this.cmdRemoveCircuitE_Click);
            // 
            // cmdAddCircuitE
            // 
            this.cmdAddCircuitE.Location = new System.Drawing.Point(58, 244);
            this.cmdAddCircuitE.Name = "cmdAddCircuitE";
            this.cmdAddCircuitE.Size = new System.Drawing.Size(87, 23);
            this.cmdAddCircuitE.TabIndex = 101;
            this.cmdAddCircuitE.Text = "sAdd Circuit";
            this.cmdAddCircuitE.UseVisualStyleBackColor = true;
            this.cmdAddCircuitE.Click += new System.EventHandler(this.cmdAddCircuitE_Click);
            // 
            // numCircuitE
            // 
            this.numCircuitE.Location = new System.Drawing.Point(3, 246);
            this.numCircuitE.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numCircuitE.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCircuitE.Name = "numCircuitE";
            this.numCircuitE.Size = new System.Drawing.Size(49, 20);
            this.numCircuitE.TabIndex = 100;
            this.numCircuitE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numCircuitE.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lvCircuitE
            // 
            this.lvCircuitE.AllowColumnResize = false;
            this.lvCircuitE.AllowMultiselect = false;
            this.lvCircuitE.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvCircuitE.AlternatingColors = false;
            this.lvCircuitE.AutoHeight = false;
            this.lvCircuitE.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvCircuitE.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1x";
            glColumn1.NumericSort = false;
            glColumn1.Text = "";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn1.Width = 115;
            this.lvCircuitE.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1});
            this.lvCircuitE.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvCircuitE.FullRowSelect = true;
            this.lvCircuitE.GridColor = System.Drawing.Color.LightGray;
            this.lvCircuitE.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvCircuitE.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvCircuitE.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvCircuitE.HeaderHeight = 0;
            this.lvCircuitE.HeaderVisible = false;
            this.lvCircuitE.HeaderWordWrap = false;
            this.lvCircuitE.HotColumnTracking = false;
            this.lvCircuitE.HotItemTracking = false;
            this.lvCircuitE.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvCircuitE.HoverEvents = false;
            this.lvCircuitE.HoverTime = 1;
            this.lvCircuitE.ImageList = null;
            this.lvCircuitE.ItemHeight = 25;
            this.lvCircuitE.ItemWordWrap = false;
            this.lvCircuitE.Location = new System.Drawing.Point(2, 75);
            this.lvCircuitE.Name = "lvCircuitE";
            this.lvCircuitE.Selectable = true;
            this.lvCircuitE.SelectedTextColor = System.Drawing.Color.White;
            this.lvCircuitE.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvCircuitE.ShowBorder = true;
            this.lvCircuitE.ShowFocusRect = true;
            this.lvCircuitE.Size = new System.Drawing.Size(143, 165);
            this.lvCircuitE.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lvCircuitE.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvCircuitE.TabIndex = 99;
            this.lvCircuitE.Text = "glacialList1";
            // 
            // numWeightE
            // 
            this.numWeightE.DecimalPlaces = 2;
            this.numWeightE.Location = new System.Drawing.Point(2, 49);
            this.numWeightE.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numWeightE.Name = "numWeightE";
            this.numWeightE.Size = new System.Drawing.Size(143, 20);
            this.numWeightE.TabIndex = 91;
            this.numWeightE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlG
            // 
            this.pnlG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pnlG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlG.Controls.Add(this.cmdRemoveCircuitG);
            this.pnlG.Controls.Add(this.cmdAddCircuitG);
            this.pnlG.Controls.Add(this.numCircuitG);
            this.pnlG.Controls.Add(this.lvCircuitG);
            this.pnlG.Controls.Add(this.numWeightG);
            this.pnlG.Controls.Add(this.lblG);
            this.pnlG.Controls.Add(this.numTubesG);
            this.pnlG.Location = new System.Drawing.Point(635, 12);
            this.pnlG.Name = "pnlG";
            this.pnlG.Size = new System.Drawing.Size(150, 302);
            this.pnlG.TabIndex = 94;
            // 
            // cmdRemoveCircuitG
            // 
            this.cmdRemoveCircuitG.Location = new System.Drawing.Point(3, 272);
            this.cmdRemoveCircuitG.Name = "cmdRemoveCircuitG";
            this.cmdRemoveCircuitG.Size = new System.Drawing.Size(142, 23);
            this.cmdRemoveCircuitG.TabIndex = 104;
            this.cmdRemoveCircuitG.Text = "sRemove Circuit";
            this.cmdRemoveCircuitG.UseVisualStyleBackColor = true;
            this.cmdRemoveCircuitG.Click += new System.EventHandler(this.cmdRemoveCircuitG_Click);
            // 
            // cmdAddCircuitG
            // 
            this.cmdAddCircuitG.Location = new System.Drawing.Point(58, 244);
            this.cmdAddCircuitG.Name = "cmdAddCircuitG";
            this.cmdAddCircuitG.Size = new System.Drawing.Size(87, 23);
            this.cmdAddCircuitG.TabIndex = 103;
            this.cmdAddCircuitG.Text = "sAdd Circuit";
            this.cmdAddCircuitG.UseVisualStyleBackColor = true;
            this.cmdAddCircuitG.Click += new System.EventHandler(this.cmdAddCircuitG_Click);
            // 
            // numCircuitG
            // 
            this.numCircuitG.Location = new System.Drawing.Point(3, 246);
            this.numCircuitG.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numCircuitG.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCircuitG.Name = "numCircuitG";
            this.numCircuitG.Size = new System.Drawing.Size(49, 20);
            this.numCircuitG.TabIndex = 102;
            this.numCircuitG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numCircuitG.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lvCircuitG
            // 
            this.lvCircuitG.AllowColumnResize = false;
            this.lvCircuitG.AllowMultiselect = false;
            this.lvCircuitG.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvCircuitG.AlternatingColors = false;
            this.lvCircuitG.AutoHeight = false;
            this.lvCircuitG.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvCircuitG.BackgroundStretchToFit = true;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column1x";
            glColumn2.NumericSort = false;
            glColumn2.Text = "";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn2.Width = 115;
            this.lvCircuitG.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn2});
            this.lvCircuitG.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvCircuitG.FullRowSelect = true;
            this.lvCircuitG.GridColor = System.Drawing.Color.LightGray;
            this.lvCircuitG.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvCircuitG.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvCircuitG.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvCircuitG.HeaderHeight = 0;
            this.lvCircuitG.HeaderVisible = false;
            this.lvCircuitG.HeaderWordWrap = false;
            this.lvCircuitG.HotColumnTracking = false;
            this.lvCircuitG.HotItemTracking = false;
            this.lvCircuitG.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvCircuitG.HoverEvents = false;
            this.lvCircuitG.HoverTime = 1;
            this.lvCircuitG.ImageList = null;
            this.lvCircuitG.ItemHeight = 25;
            this.lvCircuitG.ItemWordWrap = false;
            this.lvCircuitG.Location = new System.Drawing.Point(2, 75);
            this.lvCircuitG.Name = "lvCircuitG";
            this.lvCircuitG.Selectable = true;
            this.lvCircuitG.SelectedTextColor = System.Drawing.Color.White;
            this.lvCircuitG.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvCircuitG.ShowBorder = true;
            this.lvCircuitG.ShowFocusRect = true;
            this.lvCircuitG.Size = new System.Drawing.Size(143, 165);
            this.lvCircuitG.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lvCircuitG.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvCircuitG.TabIndex = 101;
            this.lvCircuitG.Text = "glacialList1";
            // 
            // numWeightG
            // 
            this.numWeightG.DecimalPlaces = 2;
            this.numWeightG.Location = new System.Drawing.Point(3, 49);
            this.numWeightG.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numWeightG.Name = "numWeightG";
            this.numWeightG.Size = new System.Drawing.Size(143, 20);
            this.numWeightG.TabIndex = 93;
            this.numWeightG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlF
            // 
            this.pnlF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlF.Controls.Add(this.cmdRemoveCircuitF);
            this.pnlF.Controls.Add(this.cmdAddCircuitF);
            this.pnlF.Controls.Add(this.numCircuitF);
            this.pnlF.Controls.Add(this.lvCircuitF);
            this.pnlF.Controls.Add(this.numWeightF);
            this.pnlF.Controls.Add(this.lblF);
            this.pnlF.Controls.Add(this.numTubesF);
            this.pnlF.Location = new System.Drawing.Point(479, 12);
            this.pnlF.Name = "pnlF";
            this.pnlF.Size = new System.Drawing.Size(150, 302);
            this.pnlF.TabIndex = 95;
            // 
            // cmdRemoveCircuitF
            // 
            this.cmdRemoveCircuitF.Location = new System.Drawing.Point(3, 272);
            this.cmdRemoveCircuitF.Name = "cmdRemoveCircuitF";
            this.cmdRemoveCircuitF.Size = new System.Drawing.Size(142, 23);
            this.cmdRemoveCircuitF.TabIndex = 103;
            this.cmdRemoveCircuitF.Text = "sRemove Circuit";
            this.cmdRemoveCircuitF.UseVisualStyleBackColor = true;
            this.cmdRemoveCircuitF.Click += new System.EventHandler(this.cmdRemoveCircuitF_Click);
            // 
            // cmdAddCircuitF
            // 
            this.cmdAddCircuitF.Location = new System.Drawing.Point(58, 244);
            this.cmdAddCircuitF.Name = "cmdAddCircuitF";
            this.cmdAddCircuitF.Size = new System.Drawing.Size(87, 23);
            this.cmdAddCircuitF.TabIndex = 102;
            this.cmdAddCircuitF.Text = "sAdd Circuit";
            this.cmdAddCircuitF.UseVisualStyleBackColor = true;
            this.cmdAddCircuitF.Click += new System.EventHandler(this.cmdAddCircuitF_Click);
            // 
            // numCircuitF
            // 
            this.numCircuitF.Location = new System.Drawing.Point(3, 246);
            this.numCircuitF.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numCircuitF.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCircuitF.Name = "numCircuitF";
            this.numCircuitF.Size = new System.Drawing.Size(49, 20);
            this.numCircuitF.TabIndex = 101;
            this.numCircuitF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numCircuitF.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lvCircuitF
            // 
            this.lvCircuitF.AllowColumnResize = false;
            this.lvCircuitF.AllowMultiselect = false;
            this.lvCircuitF.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvCircuitF.AlternatingColors = false;
            this.lvCircuitF.AutoHeight = false;
            this.lvCircuitF.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvCircuitF.BackgroundStretchToFit = true;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Column1x";
            glColumn3.NumericSort = false;
            glColumn3.Text = "";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn3.Width = 115;
            this.lvCircuitF.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn3});
            this.lvCircuitF.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvCircuitF.FullRowSelect = true;
            this.lvCircuitF.GridColor = System.Drawing.Color.LightGray;
            this.lvCircuitF.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvCircuitF.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvCircuitF.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvCircuitF.HeaderHeight = 0;
            this.lvCircuitF.HeaderVisible = false;
            this.lvCircuitF.HeaderWordWrap = false;
            this.lvCircuitF.HotColumnTracking = false;
            this.lvCircuitF.HotItemTracking = false;
            this.lvCircuitF.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvCircuitF.HoverEvents = false;
            this.lvCircuitF.HoverTime = 1;
            this.lvCircuitF.ImageList = null;
            this.lvCircuitF.ItemHeight = 25;
            this.lvCircuitF.ItemWordWrap = false;
            this.lvCircuitF.Location = new System.Drawing.Point(2, 75);
            this.lvCircuitF.Name = "lvCircuitF";
            this.lvCircuitF.Selectable = true;
            this.lvCircuitF.SelectedTextColor = System.Drawing.Color.White;
            this.lvCircuitF.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvCircuitF.ShowBorder = true;
            this.lvCircuitF.ShowFocusRect = true;
            this.lvCircuitF.Size = new System.Drawing.Size(143, 165);
            this.lvCircuitF.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lvCircuitF.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvCircuitF.TabIndex = 100;
            this.lvCircuitF.Text = "glacialList1";
            // 
            // numWeightF
            // 
            this.numWeightF.DecimalPlaces = 2;
            this.numWeightF.Location = new System.Drawing.Point(2, 49);
            this.numWeightF.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numWeightF.Name = "numWeightF";
            this.numWeightF.Size = new System.Drawing.Size(143, 20);
            this.numWeightF.TabIndex = 92;
            this.numWeightF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new System.Drawing.Point(121, 247);
            this.numPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(131, 20);
            this.numPrice.TabIndex = 96;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(9, 249);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(36, 13);
            this.lblPrice.TabIndex = 97;
            this.lblPrice.Text = "sPrice";
            // 
            // cboModels
            // 
            this.cboModels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModels.DropDownWidth = 300;
            this.cboModels.FormattingEnabled = true;
            this.cboModels.Location = new System.Drawing.Point(12, 12);
            this.cboModels.Name = "cboModels";
            this.cboModels.Size = new System.Drawing.Size(240, 21);
            this.cboModels.TabIndex = 100;
            // 
            // cmdLoadModel
            // 
            this.cmdLoadModel.Image = ((System.Drawing.Image)(resources.GetObject("cmdLoadModel.Image")));
            this.cmdLoadModel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLoadModel.Location = new System.Drawing.Point(12, 39);
            this.cmdLoadModel.Name = "cmdLoadModel";
            this.cmdLoadModel.Size = new System.Drawing.Size(115, 23);
            this.cmdLoadModel.TabIndex = 103;
            this.cmdLoadModel.Text = "sLoad Model";
            this.cmdLoadModel.UseVisualStyleBackColor = true;
            this.cmdLoadModel.Click += new System.EventHandler(this.cmdLoadModel_Click);
            // 
            // cmdDeleteModel
            // 
            this.cmdDeleteModel.Image = ((System.Drawing.Image)(resources.GetObject("cmdDeleteModel.Image")));
            this.cmdDeleteModel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDeleteModel.Location = new System.Drawing.Point(137, 39);
            this.cmdDeleteModel.Name = "cmdDeleteModel";
            this.cmdDeleteModel.Size = new System.Drawing.Size(115, 23);
            this.cmdDeleteModel.TabIndex = 104;
            this.cmdDeleteModel.Text = "sDelete Model";
            this.cmdDeleteModel.UseVisualStyleBackColor = true;
            this.cmdDeleteModel.Click += new System.EventHandler(this.cmdDeleteModel_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(12, 321);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(240, 27);
            this.cmdSave.TabIndex = 105;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(545, 321);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(240, 27);
            this.cmdClose.TabIndex = 106;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // radVertical
            // 
            this.radVertical.AutoSize = true;
            this.radVertical.Checked = true;
            this.radVertical.Location = new System.Drawing.Point(121, 296);
            this.radVertical.Name = "radVertical";
            this.radVertical.Size = new System.Drawing.Size(65, 17);
            this.radVertical.TabIndex = 107;
            this.radVertical.TabStop = true;
            this.radVertical.Text = "sVertical";
            this.radVertical.UseVisualStyleBackColor = true;
            // 
            // radHorizontal
            // 
            this.radHorizontal.AutoSize = true;
            this.radHorizontal.Location = new System.Drawing.Point(121, 273);
            this.radHorizontal.Name = "radHorizontal";
            this.radHorizontal.Size = new System.Drawing.Size(77, 17);
            this.radHorizontal.TabIndex = 108;
            this.radHorizontal.Text = "sHorizontal";
            this.radHorizontal.UseVisualStyleBackColor = true;
            // 
            // lblAirFlow
            // 
            this.lblAirFlow.AutoSize = true;
            this.lblAirFlow.Location = new System.Drawing.Point(9, 275);
            this.lblAirFlow.Name = "lblAirFlow";
            this.lblAirFlow.Size = new System.Drawing.Size(49, 13);
            this.lblAirFlow.TabIndex = 110;
            this.lblAirFlow.Text = "sAir Flow";
            // 
            // lblTubes
            // 
            this.lblTubes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTubes.Location = new System.Drawing.Point(264, 36);
            this.lblTubes.Name = "lblTubes";
            this.lblTubes.Size = new System.Drawing.Size(60, 20);
            this.lblTubes.TabIndex = 111;
            this.lblTubes.Text = "sTubes";
            this.lblTubes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWeight
            // 
            this.lblWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWeight.Location = new System.Drawing.Point(264, 62);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(60, 20);
            this.lblWeight.TabIndex = 112;
            this.lblWeight.Text = "sWeight";
            this.lblWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCircuits
            // 
            this.lblCircuits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCircuits.Location = new System.Drawing.Point(264, 88);
            this.lblCircuits.Name = "lblCircuits";
            this.lblCircuits.Size = new System.Drawing.Size(60, 226);
            this.lblCircuits.TabIndex = 113;
            this.lblCircuits.Text = "sCircuits";
            this.lblCircuits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmFluidCoolerManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(789, 354);
            this.Controls.Add(this.lblCircuits);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.lblAirFlow);
            this.Controls.Add(this.radHorizontal);
            this.Controls.Add(this.radVertical);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdDeleteModel);
            this.Controls.Add(this.cmdLoadModel);
            this.Controls.Add(this.cboModels);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.pnlF);
            this.Controls.Add(this.pnlG);
            this.Controls.Add(this.pnlE);
            this.Controls.Add(this.numFinLength);
            this.Controls.Add(this.lblFinLength);
            this.Controls.Add(this.cboFPI);
            this.Controls.Add(this.lblFPI);
            this.Controls.Add(this.numRow);
            this.Controls.Add(this.lblRow);
            this.Controls.Add(this.cboFanArrangement);
            this.Controls.Add(this.lblFanArrangement);
            this.Controls.Add(this.cboUnitType);
            this.Controls.Add(this.lblUnitType);
            this.Controls.Add(this.lblCFM);
            this.Controls.Add(this.numCFM);
            this.Controls.Add(this.lblTubes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFluidCoolerManager";
            this.Text = "sData Manager - Fluid Cooler";
            this.Load += new System.EventHandler(this.frmFluidCoolerManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numCFM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFinLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTubesE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTubesF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTubesG)).EndInit();
            this.pnlE.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numCircuitE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeightE)).EndInit();
            this.pnlG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numCircuitG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeightG)).EndInit();
            this.pnlF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numCircuitF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeightF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numCFM;
        private System.Windows.Forms.Label lblCFM;
        private System.Windows.Forms.ComboBox cboUnitType;
        private System.Windows.Forms.Label lblUnitType;
        private System.Windows.Forms.ComboBox cboFanArrangement;
        private System.Windows.Forms.Label lblFanArrangement;
        private System.Windows.Forms.NumericUpDown numRow;
        private System.Windows.Forms.Label lblRow;
        private System.Windows.Forms.ComboBox cboFPI;
        private System.Windows.Forms.Label lblFPI;
        private System.Windows.Forms.NumericUpDown numFinLength;
        private System.Windows.Forms.Label lblFinLength;
        private System.Windows.Forms.Label lblE;
        private System.Windows.Forms.Label lblF;
        private System.Windows.Forms.Label lblG;
        private System.Windows.Forms.NumericUpDown numTubesE;
        private System.Windows.Forms.NumericUpDown numTubesF;
        private System.Windows.Forms.NumericUpDown numTubesG;
        private System.Windows.Forms.Panel pnlE;
        private System.Windows.Forms.Panel pnlG;
        private System.Windows.Forms.Panel pnlF;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown numWeightE;
        private System.Windows.Forms.NumericUpDown numWeightG;
        private System.Windows.Forms.NumericUpDown numWeightF;
        private GlacialComponents.Controls.GlacialList lvCircuitE;
        private System.Windows.Forms.Button cmdAddCircuitE;
        private System.Windows.Forms.NumericUpDown numCircuitE;
        private System.Windows.Forms.Button cmdAddCircuitG;
        private System.Windows.Forms.NumericUpDown numCircuitG;
        private GlacialComponents.Controls.GlacialList lvCircuitG;
        private System.Windows.Forms.Button cmdAddCircuitF;
        private System.Windows.Forms.NumericUpDown numCircuitF;
        private GlacialComponents.Controls.GlacialList lvCircuitF;
        private System.Windows.Forms.Button cmdRemoveCircuitE;
        private System.Windows.Forms.Button cmdRemoveCircuitG;
        private System.Windows.Forms.Button cmdRemoveCircuitF;
        private System.Windows.Forms.ComboBox cboModels;
        private System.Windows.Forms.Button cmdLoadModel;
        private System.Windows.Forms.Button cmdDeleteModel;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.RadioButton radVertical;
        private System.Windows.Forms.RadioButton radHorizontal;
        private System.Windows.Forms.Label lblAirFlow;
        private System.Windows.Forms.Label lblTubes;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblCircuits;

    }
}