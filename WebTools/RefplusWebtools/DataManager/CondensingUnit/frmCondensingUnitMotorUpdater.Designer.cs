namespace RefplusWebtools.DataManager.CondensingUnit
{
    partial class FrmCondensingUnitMotorUpdater
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCondensingUnitMotorUpdater));
            GlacialComponents.Controls.GLColumn glColumn14 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn15 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn16 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn17 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn4 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn5 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn6 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn7 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn8 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn9 = new GlacialComponents.Controls.GLColumn();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.cmdOptionsPickAll = new System.Windows.Forms.Button();
            this.lvOptions = new GlacialComponents.Controls.GlacialList();
            this.cmdOptionsUnpickAll = new System.Windows.Forms.Button();
            this.grpFirstPart = new System.Windows.Forms.GroupBox();
            this.cmdFirstPartPickAll = new System.Windows.Forms.Button();
            this.lvFirstPart = new GlacialComponents.Controls.GlacialList();
            this.cmdFirstPartUnpickAll = new System.Windows.Forms.Button();
            this.grpHP = new System.Windows.Forms.GroupBox();
            this.lblHPTo = new System.Windows.Forms.Label();
            this.cmdHPPickAll = new System.Windows.Forms.Button();
            this.numMinHP = new System.Windows.Forms.NumericUpDown();
            this.numMaxHP = new System.Windows.Forms.NumericUpDown();
            this.cmdHPUnpickAll = new System.Windows.Forms.Button();
            this.grpCompressors = new System.Windows.Forms.GroupBox();
            this.cmdCompressorPickAll = new System.Windows.Forms.Button();
            this.lvCompressor = new GlacialComponents.Controls.GlacialList();
            this.cmdCompressorUnpickAll = new System.Windows.Forms.Button();
            this.grpThirdPart = new System.Windows.Forms.GroupBox();
            this.cmdThirdPartPickAll = new System.Windows.Forms.Button();
            this.lvThirdPart = new GlacialComponents.Controls.GlacialList();
            this.cmdThirdPartUnpickAll = new System.Windows.Forms.Button();
            this.cboMotor = new System.Windows.Forms.ComboBox();
            this.lblMotor = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cboVoltage = new System.Windows.Forms.ComboBox();
            this.lblVoltage = new System.Windows.Forms.Label();
            this.grpOptions.SuspendLayout();
            this.grpFirstPart.SuspendLayout();
            this.grpHP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxHP)).BeginInit();
            this.grpCompressors.SuspendLayout();
            this.grpThirdPart.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.cmdOptionsPickAll);
            this.grpOptions.Controls.Add(this.lvOptions);
            this.grpOptions.Controls.Add(this.cmdOptionsUnpickAll);
            this.grpOptions.Location = new System.Drawing.Point(355, 282);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(158, 264);
            this.grpOptions.TabIndex = 5;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "sOptions";
            // 
            // cmdOptionsPickAll
            // 
            this.cmdOptionsPickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdOptionsPickAll.Image")));
            this.cmdOptionsPickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOptionsPickAll.Location = new System.Drawing.Point(6, 32);
            this.cmdOptionsPickAll.Name = "cmdOptionsPickAll";
            this.cmdOptionsPickAll.Size = new System.Drawing.Size(145, 23);
            this.cmdOptionsPickAll.TabIndex = 0;
            this.cmdOptionsPickAll.Text = "sPick All";
            this.cmdOptionsPickAll.UseVisualStyleBackColor = true;
            this.cmdOptionsPickAll.Click += new System.EventHandler(this.cmdOptionsPickAll_Click);
            // 
            // lvOptions
            // 
            this.lvOptions.AllowColumnResize = true;
            this.lvOptions.AllowMultiselect = false;
            this.lvOptions.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvOptions.AlternatingColors = false;
            this.lvOptions.AutoHeight = true;
            this.lvOptions.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvOptions.BackgroundStretchToFit = true;
            glColumn14.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn14.CheckBoxes = true;
            glColumn14.DatetimeSort = false;
            glColumn14.ImageIndex = -1;
            glColumn14.Name = "Column1";
            glColumn14.NumericSort = false;
            glColumn14.Text = "";
            glColumn14.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn14.Width = 20;
            glColumn15.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn15.CheckBoxes = false;
            glColumn15.DatetimeSort = false;
            glColumn15.ImageIndex = -1;
            glColumn15.Name = "Column2";
            glColumn15.NumericSort = false;
            glColumn15.Text = "";
            glColumn15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn15.Width = 100;
            glColumn16.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn16.CheckBoxes = false;
            glColumn16.DatetimeSort = false;
            glColumn16.ImageIndex = -1;
            glColumn16.Name = "Column1x";
            glColumn16.NumericSort = false;
            glColumn16.Text = "sVoltageID";
            glColumn16.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn16.Width = 0;
            this.lvOptions.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn14,
            glColumn15,
            glColumn16});
            this.lvOptions.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvOptions.FullRowSelect = true;
            this.lvOptions.GridColor = System.Drawing.Color.LightGray;
            this.lvOptions.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvOptions.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridSolid;
            this.lvOptions.GridTypes = GlacialComponents.Controls.GLGridTypes.gridOnExists;
            this.lvOptions.HeaderHeight = 22;
            this.lvOptions.HeaderVisible = true;
            this.lvOptions.HeaderWordWrap = false;
            this.lvOptions.HotColumnTracking = false;
            this.lvOptions.HotItemTracking = false;
            this.lvOptions.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvOptions.HoverEvents = false;
            this.lvOptions.HoverTime = 1;
            this.lvOptions.ImageList = null;
            this.lvOptions.ItemHeight = 4;
            this.lvOptions.ItemWordWrap = false;
            this.lvOptions.Location = new System.Drawing.Point(6, 61);
            this.lvOptions.Name = "lvOptions";
            this.lvOptions.Selectable = true;
            this.lvOptions.SelectedTextColor = System.Drawing.Color.White;
            this.lvOptions.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvOptions.ShowBorder = true;
            this.lvOptions.ShowFocusRect = false;
            this.lvOptions.Size = new System.Drawing.Size(145, 166);
            this.lvOptions.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lvOptions.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvOptions.TabIndex = 1;
            this.lvOptions.Text = "glacialList1";
            // 
            // cmdOptionsUnpickAll
            // 
            this.cmdOptionsUnpickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdOptionsUnpickAll.Image")));
            this.cmdOptionsUnpickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOptionsUnpickAll.Location = new System.Drawing.Point(6, 233);
            this.cmdOptionsUnpickAll.Name = "cmdOptionsUnpickAll";
            this.cmdOptionsUnpickAll.Size = new System.Drawing.Size(145, 23);
            this.cmdOptionsUnpickAll.TabIndex = 2;
            this.cmdOptionsUnpickAll.Text = "sUnpick All";
            this.cmdOptionsUnpickAll.UseVisualStyleBackColor = true;
            this.cmdOptionsUnpickAll.Click += new System.EventHandler(this.cmdOptionsUnpickAll_Click);
            // 
            // grpFirstPart
            // 
            this.grpFirstPart.Controls.Add(this.cmdFirstPartPickAll);
            this.grpFirstPart.Controls.Add(this.lvFirstPart);
            this.grpFirstPart.Controls.Add(this.cmdFirstPartUnpickAll);
            this.grpFirstPart.Location = new System.Drawing.Point(64, 12);
            this.grpFirstPart.Name = "grpFirstPart";
            this.grpFirstPart.Size = new System.Drawing.Size(161, 264);
            this.grpFirstPart.TabIndex = 0;
            this.grpFirstPart.TabStop = false;
            this.grpFirstPart.Text = "sUnit Type / Air Flow / Compressor Type";
            // 
            // cmdFirstPartPickAll
            // 
            this.cmdFirstPartPickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdFirstPartPickAll.Image")));
            this.cmdFirstPartPickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdFirstPartPickAll.Location = new System.Drawing.Point(6, 32);
            this.cmdFirstPartPickAll.Name = "cmdFirstPartPickAll";
            this.cmdFirstPartPickAll.Size = new System.Drawing.Size(150, 23);
            this.cmdFirstPartPickAll.TabIndex = 0;
            this.cmdFirstPartPickAll.Text = "sPick All";
            this.cmdFirstPartPickAll.UseVisualStyleBackColor = true;
            this.cmdFirstPartPickAll.Click += new System.EventHandler(this.cmdFirstPartPickAll_Click);
            // 
            // lvFirstPart
            // 
            this.lvFirstPart.AllowColumnResize = true;
            this.lvFirstPart.AllowMultiselect = false;
            this.lvFirstPart.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvFirstPart.AlternatingColors = false;
            this.lvFirstPart.AutoHeight = true;
            this.lvFirstPart.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvFirstPart.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = true;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1";
            glColumn1.NumericSort = false;
            glColumn1.Text = "";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn1.Width = 20;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column2";
            glColumn2.NumericSort = false;
            glColumn2.Text = "";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn2.Width = 30;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Column3";
            glColumn3.NumericSort = false;
            glColumn3.Text = "";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn3.Width = 30;
            glColumn17.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn17.CheckBoxes = false;
            glColumn17.DatetimeSort = false;
            glColumn17.ImageIndex = -1;
            glColumn17.Name = "Column4";
            glColumn17.NumericSort = false;
            glColumn17.Text = "";
            glColumn17.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn17.Width = 30;
            this.lvFirstPart.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3,
            glColumn17});
            this.lvFirstPart.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvFirstPart.FullRowSelect = true;
            this.lvFirstPart.GridColor = System.Drawing.Color.LightGray;
            this.lvFirstPart.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvFirstPart.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridSolid;
            this.lvFirstPart.GridTypes = GlacialComponents.Controls.GLGridTypes.gridOnExists;
            this.lvFirstPart.HeaderHeight = 22;
            this.lvFirstPart.HeaderVisible = true;
            this.lvFirstPart.HeaderWordWrap = false;
            this.lvFirstPart.HotColumnTracking = false;
            this.lvFirstPart.HotItemTracking = false;
            this.lvFirstPart.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvFirstPart.HoverEvents = false;
            this.lvFirstPart.HoverTime = 1;
            this.lvFirstPart.ImageList = null;
            this.lvFirstPart.ItemHeight = 4;
            this.lvFirstPart.ItemWordWrap = false;
            this.lvFirstPart.Location = new System.Drawing.Point(6, 61);
            this.lvFirstPart.Name = "lvFirstPart";
            this.lvFirstPart.Selectable = true;
            this.lvFirstPart.SelectedTextColor = System.Drawing.Color.White;
            this.lvFirstPart.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvFirstPart.ShowBorder = true;
            this.lvFirstPart.ShowFocusRect = false;
            this.lvFirstPart.Size = new System.Drawing.Size(150, 166);
            this.lvFirstPart.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lvFirstPart.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvFirstPart.TabIndex = 1;
            this.lvFirstPart.Text = "glacialList1";
            // 
            // cmdFirstPartUnpickAll
            // 
            this.cmdFirstPartUnpickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdFirstPartUnpickAll.Image")));
            this.cmdFirstPartUnpickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdFirstPartUnpickAll.Location = new System.Drawing.Point(6, 233);
            this.cmdFirstPartUnpickAll.Name = "cmdFirstPartUnpickAll";
            this.cmdFirstPartUnpickAll.Size = new System.Drawing.Size(150, 23);
            this.cmdFirstPartUnpickAll.TabIndex = 2;
            this.cmdFirstPartUnpickAll.Text = "sUnpick All";
            this.cmdFirstPartUnpickAll.UseVisualStyleBackColor = true;
            this.cmdFirstPartUnpickAll.Click += new System.EventHandler(this.cmdFirstPartUnpickAll_Click);
            // 
            // grpHP
            // 
            this.grpHP.Controls.Add(this.lblHPTo);
            this.grpHP.Controls.Add(this.cmdHPPickAll);
            this.grpHP.Controls.Add(this.numMinHP);
            this.grpHP.Controls.Add(this.numMaxHP);
            this.grpHP.Controls.Add(this.cmdHPUnpickAll);
            this.grpHP.Location = new System.Drawing.Point(231, 12);
            this.grpHP.Name = "grpHP";
            this.grpHP.Size = new System.Drawing.Size(100, 264);
            this.grpHP.TabIndex = 1;
            this.grpHP.TabStop = false;
            this.grpHP.Text = "sHP Range";
            // 
            // lblHPTo
            // 
            this.lblHPTo.Location = new System.Drawing.Point(6, 110);
            this.lblHPTo.Name = "lblHPTo";
            this.lblHPTo.Size = new System.Drawing.Size(88, 68);
            this.lblHPTo.TabIndex = 25;
            this.lblHPTo.Text = "sTo";
            this.lblHPTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdHPPickAll
            // 
            this.cmdHPPickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdHPPickAll.Image")));
            this.cmdHPPickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdHPPickAll.Location = new System.Drawing.Point(6, 32);
            this.cmdHPPickAll.Name = "cmdHPPickAll";
            this.cmdHPPickAll.Size = new System.Drawing.Size(88, 23);
            this.cmdHPPickAll.TabIndex = 0;
            this.cmdHPPickAll.Text = "sPick All";
            this.cmdHPPickAll.UseVisualStyleBackColor = true;
            this.cmdHPPickAll.Click += new System.EventHandler(this.cmdHPPickAll_Click);
            // 
            // numMinHP
            // 
            this.numMinHP.DecimalPlaces = 2;
            this.numMinHP.Location = new System.Drawing.Point(6, 87);
            this.numMinHP.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numMinHP.Name = "numMinHP";
            this.numMinHP.Size = new System.Drawing.Size(88, 20);
            this.numMinHP.TabIndex = 1;
            this.numMinHP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numMinHP.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // numMaxHP
            // 
            this.numMaxHP.DecimalPlaces = 2;
            this.numMaxHP.Location = new System.Drawing.Point(6, 181);
            this.numMaxHP.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numMaxHP.Name = "numMaxHP";
            this.numMaxHP.Size = new System.Drawing.Size(88, 20);
            this.numMaxHP.TabIndex = 2;
            this.numMaxHP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numMaxHP.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // cmdHPUnpickAll
            // 
            this.cmdHPUnpickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdHPUnpickAll.Image")));
            this.cmdHPUnpickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdHPUnpickAll.Location = new System.Drawing.Point(6, 233);
            this.cmdHPUnpickAll.Name = "cmdHPUnpickAll";
            this.cmdHPUnpickAll.Size = new System.Drawing.Size(88, 23);
            this.cmdHPUnpickAll.TabIndex = 3;
            this.cmdHPUnpickAll.Text = "sUnpick All";
            this.cmdHPUnpickAll.UseVisualStyleBackColor = true;
            this.cmdHPUnpickAll.Click += new System.EventHandler(this.cmdHPUnpickAll_Click);
            // 
            // grpCompressors
            // 
            this.grpCompressors.Controls.Add(this.cmdCompressorPickAll);
            this.grpCompressors.Controls.Add(this.lvCompressor);
            this.grpCompressors.Controls.Add(this.cmdCompressorUnpickAll);
            this.grpCompressors.Location = new System.Drawing.Point(337, 12);
            this.grpCompressors.Name = "grpCompressors";
            this.grpCompressors.Size = new System.Drawing.Size(112, 264);
            this.grpCompressors.TabIndex = 2;
            this.grpCompressors.TabStop = false;
            this.grpCompressors.Text = "s# Compressor(s)";
            // 
            // cmdCompressorPickAll
            // 
            this.cmdCompressorPickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdCompressorPickAll.Image")));
            this.cmdCompressorPickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCompressorPickAll.Location = new System.Drawing.Point(6, 32);
            this.cmdCompressorPickAll.Name = "cmdCompressorPickAll";
            this.cmdCompressorPickAll.Size = new System.Drawing.Size(101, 23);
            this.cmdCompressorPickAll.TabIndex = 0;
            this.cmdCompressorPickAll.Text = "sPick All";
            this.cmdCompressorPickAll.UseVisualStyleBackColor = true;
            this.cmdCompressorPickAll.Click += new System.EventHandler(this.cmdCompressorPickAll_Click);
            // 
            // lvCompressor
            // 
            this.lvCompressor.AllowColumnResize = true;
            this.lvCompressor.AllowMultiselect = false;
            this.lvCompressor.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvCompressor.AlternatingColors = false;
            this.lvCompressor.AutoHeight = true;
            this.lvCompressor.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvCompressor.BackgroundStretchToFit = true;
            glColumn4.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn4.CheckBoxes = true;
            glColumn4.DatetimeSort = false;
            glColumn4.ImageIndex = -1;
            glColumn4.Name = "Column1";
            glColumn4.NumericSort = false;
            glColumn4.Text = "";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn4.Width = 20;
            glColumn5.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn5.CheckBoxes = false;
            glColumn5.DatetimeSort = false;
            glColumn5.ImageIndex = -1;
            glColumn5.Name = "Column2";
            glColumn5.NumericSort = false;
            glColumn5.Text = "";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn5.Width = 40;
            this.lvCompressor.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn4,
            glColumn5});
            this.lvCompressor.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvCompressor.FullRowSelect = true;
            this.lvCompressor.GridColor = System.Drawing.Color.LightGray;
            this.lvCompressor.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvCompressor.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridSolid;
            this.lvCompressor.GridTypes = GlacialComponents.Controls.GLGridTypes.gridOnExists;
            this.lvCompressor.HeaderHeight = 22;
            this.lvCompressor.HeaderVisible = true;
            this.lvCompressor.HeaderWordWrap = false;
            this.lvCompressor.HotColumnTracking = false;
            this.lvCompressor.HotItemTracking = false;
            this.lvCompressor.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvCompressor.HoverEvents = false;
            this.lvCompressor.HoverTime = 1;
            this.lvCompressor.ImageList = null;
            this.lvCompressor.ItemHeight = 4;
            this.lvCompressor.ItemWordWrap = false;
            this.lvCompressor.Location = new System.Drawing.Point(6, 61);
            this.lvCompressor.Name = "lvCompressor";
            this.lvCompressor.Selectable = true;
            this.lvCompressor.SelectedTextColor = System.Drawing.Color.White;
            this.lvCompressor.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvCompressor.ShowBorder = true;
            this.lvCompressor.ShowFocusRect = false;
            this.lvCompressor.Size = new System.Drawing.Size(101, 166);
            this.lvCompressor.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lvCompressor.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvCompressor.TabIndex = 1;
            this.lvCompressor.Text = "glacialList1";
            // 
            // cmdCompressorUnpickAll
            // 
            this.cmdCompressorUnpickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdCompressorUnpickAll.Image")));
            this.cmdCompressorUnpickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCompressorUnpickAll.Location = new System.Drawing.Point(6, 233);
            this.cmdCompressorUnpickAll.Name = "cmdCompressorUnpickAll";
            this.cmdCompressorUnpickAll.Size = new System.Drawing.Size(101, 23);
            this.cmdCompressorUnpickAll.TabIndex = 2;
            this.cmdCompressorUnpickAll.Text = "sUnpick All";
            this.cmdCompressorUnpickAll.UseVisualStyleBackColor = true;
            this.cmdCompressorUnpickAll.Click += new System.EventHandler(this.cmdCompressorUnpickAll_Click);
            // 
            // grpThirdPart
            // 
            this.grpThirdPart.Controls.Add(this.cmdThirdPartPickAll);
            this.grpThirdPart.Controls.Add(this.lvThirdPart);
            this.grpThirdPart.Controls.Add(this.cmdThirdPartUnpickAll);
            this.grpThirdPart.Location = new System.Drawing.Point(12, 282);
            this.grpThirdPart.Name = "grpThirdPart";
            this.grpThirdPart.Size = new System.Drawing.Size(160, 264);
            this.grpThirdPart.TabIndex = 3;
            this.grpThirdPart.TabStop = false;
            this.grpThirdPart.Text = "sCompressor Manufacturer / Application / Refrigerant";
            // 
            // cmdThirdPartPickAll
            // 
            this.cmdThirdPartPickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdThirdPartPickAll.Image")));
            this.cmdThirdPartPickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdThirdPartPickAll.Location = new System.Drawing.Point(6, 32);
            this.cmdThirdPartPickAll.Name = "cmdThirdPartPickAll";
            this.cmdThirdPartPickAll.Size = new System.Drawing.Size(150, 23);
            this.cmdThirdPartPickAll.TabIndex = 0;
            this.cmdThirdPartPickAll.Text = "sPick All";
            this.cmdThirdPartPickAll.UseVisualStyleBackColor = true;
            this.cmdThirdPartPickAll.Click += new System.EventHandler(this.cmdThirdPartPickAll_Click);
            // 
            // lvThirdPart
            // 
            this.lvThirdPart.AllowColumnResize = true;
            this.lvThirdPart.AllowMultiselect = false;
            this.lvThirdPart.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvThirdPart.AlternatingColors = false;
            this.lvThirdPart.AutoHeight = true;
            this.lvThirdPart.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvThirdPart.BackgroundStretchToFit = true;
            glColumn6.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn6.CheckBoxes = true;
            glColumn6.DatetimeSort = false;
            glColumn6.ImageIndex = -1;
            glColumn6.Name = "Column1";
            glColumn6.NumericSort = false;
            glColumn6.Text = "";
            glColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn6.Width = 20;
            glColumn7.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn7.CheckBoxes = false;
            glColumn7.DatetimeSort = false;
            glColumn7.ImageIndex = -1;
            glColumn7.Name = "Column2";
            glColumn7.NumericSort = false;
            glColumn7.Text = "";
            glColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn7.Width = 30;
            glColumn8.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn8.CheckBoxes = false;
            glColumn8.DatetimeSort = false;
            glColumn8.ImageIndex = -1;
            glColumn8.Name = "Column3";
            glColumn8.NumericSort = false;
            glColumn8.Text = "";
            glColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn8.Width = 30;
            glColumn9.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn9.CheckBoxes = false;
            glColumn9.DatetimeSort = false;
            glColumn9.ImageIndex = -1;
            glColumn9.Name = "Column4";
            glColumn9.NumericSort = false;
            glColumn9.Text = "";
            glColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn9.Width = 30;
            this.lvThirdPart.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn6,
            glColumn7,
            glColumn8,
            glColumn9});
            this.lvThirdPart.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvThirdPart.FullRowSelect = true;
            this.lvThirdPart.GridColor = System.Drawing.Color.LightGray;
            this.lvThirdPart.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvThirdPart.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridSolid;
            this.lvThirdPart.GridTypes = GlacialComponents.Controls.GLGridTypes.gridOnExists;
            this.lvThirdPart.HeaderHeight = 22;
            this.lvThirdPart.HeaderVisible = true;
            this.lvThirdPart.HeaderWordWrap = false;
            this.lvThirdPart.HotColumnTracking = false;
            this.lvThirdPart.HotItemTracking = false;
            this.lvThirdPart.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvThirdPart.HoverEvents = false;
            this.lvThirdPart.HoverTime = 1;
            this.lvThirdPart.ImageList = null;
            this.lvThirdPart.ItemHeight = 4;
            this.lvThirdPart.ItemWordWrap = false;
            this.lvThirdPart.Location = new System.Drawing.Point(6, 61);
            this.lvThirdPart.Name = "lvThirdPart";
            this.lvThirdPart.Selectable = true;
            this.lvThirdPart.SelectedTextColor = System.Drawing.Color.White;
            this.lvThirdPart.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvThirdPart.ShowBorder = true;
            this.lvThirdPart.ShowFocusRect = false;
            this.lvThirdPart.Size = new System.Drawing.Size(150, 166);
            this.lvThirdPart.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lvThirdPart.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvThirdPart.TabIndex = 1;
            this.lvThirdPart.Text = "glacialList1";
            // 
            // cmdThirdPartUnpickAll
            // 
            this.cmdThirdPartUnpickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdThirdPartUnpickAll.Image")));
            this.cmdThirdPartUnpickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdThirdPartUnpickAll.Location = new System.Drawing.Point(6, 233);
            this.cmdThirdPartUnpickAll.Name = "cmdThirdPartUnpickAll";
            this.cmdThirdPartUnpickAll.Size = new System.Drawing.Size(150, 23);
            this.cmdThirdPartUnpickAll.TabIndex = 2;
            this.cmdThirdPartUnpickAll.Text = "sUnpick All";
            this.cmdThirdPartUnpickAll.UseVisualStyleBackColor = true;
            this.cmdThirdPartUnpickAll.Click += new System.EventHandler(this.cmdThirdPartUnpickAll_Click);
            // 
            // cboMotor
            // 
            this.cboMotor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotor.FormattingEnabled = true;
            this.cboMotor.Location = new System.Drawing.Point(239, 555);
            this.cboMotor.Name = "cboMotor";
            this.cboMotor.Size = new System.Drawing.Size(153, 21);
            this.cboMotor.TabIndex = 6;
            // 
            // lblMotor
            // 
            this.lblMotor.AutoSize = true;
            this.lblMotor.Location = new System.Drawing.Point(138, 558);
            this.lblMotor.Name = "lblMotor";
            this.lblMotor.Size = new System.Drawing.Size(39, 13);
            this.lblMotor.TabIndex = 73;
            this.lblMotor.Text = "sMotor";
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(12, 586);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(150, 25);
            this.cmdSave.TabIndex = 7;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(368, 586);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(150, 25);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cboVoltage
            // 
            this.cboVoltage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVoltage.FormattingEnabled = true;
            this.cboVoltage.Location = new System.Drawing.Point(178, 428);
            this.cboVoltage.Name = "cboVoltage";
            this.cboVoltage.Size = new System.Drawing.Size(171, 21);
            this.cboVoltage.TabIndex = 4;
            this.cboVoltage.SelectedIndexChanged += new System.EventHandler(this.cboVoltage_SelectedIndexChanged);
            // 
            // lblVoltage
            // 
            this.lblVoltage.AutoSize = true;
            this.lblVoltage.Location = new System.Drawing.Point(178, 412);
            this.lblVoltage.Name = "lblVoltage";
            this.lblVoltage.Size = new System.Drawing.Size(48, 13);
            this.lblVoltage.TabIndex = 110;
            this.lblVoltage.Text = "sVoltage";
            // 
            // frmCondensingUnitMotorUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(530, 620);
            this.Controls.Add(this.cboVoltage);
            this.Controls.Add(this.lblVoltage);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cboMotor);
            this.Controls.Add(this.lblMotor);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.grpFirstPart);
            this.Controls.Add(this.grpHP);
            this.Controls.Add(this.grpCompressors);
            this.Controls.Add(this.grpThirdPart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCondensingUnitMotorUpdater";
            this.Text = "sData Manager - Condensing Unit Motor Updater";
            this.Load += new System.EventHandler(this.frmCondensingUnitMotorUpdater_Load);
            this.grpOptions.ResumeLayout(false);
            this.grpFirstPart.ResumeLayout(false);
            this.grpHP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numMinHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxHP)).EndInit();
            this.grpCompressors.ResumeLayout(false);
            this.grpThirdPart.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.Button cmdOptionsPickAll;
        private GlacialComponents.Controls.GlacialList lvOptions;
        private System.Windows.Forms.Button cmdOptionsUnpickAll;
        private System.Windows.Forms.GroupBox grpFirstPart;
        private System.Windows.Forms.Button cmdFirstPartPickAll;
        private GlacialComponents.Controls.GlacialList lvFirstPart;
        private System.Windows.Forms.Button cmdFirstPartUnpickAll;
        private System.Windows.Forms.GroupBox grpHP;
        private System.Windows.Forms.Label lblHPTo;
        private System.Windows.Forms.Button cmdHPPickAll;
        private System.Windows.Forms.NumericUpDown numMinHP;
        private System.Windows.Forms.NumericUpDown numMaxHP;
        private System.Windows.Forms.Button cmdHPUnpickAll;
        private System.Windows.Forms.GroupBox grpCompressors;
        private System.Windows.Forms.Button cmdCompressorPickAll;
        private GlacialComponents.Controls.GlacialList lvCompressor;
        private System.Windows.Forms.Button cmdCompressorUnpickAll;
        private System.Windows.Forms.GroupBox grpThirdPart;
        private System.Windows.Forms.Button cmdThirdPartPickAll;
        private GlacialComponents.Controls.GlacialList lvThirdPart;
        private System.Windows.Forms.Button cmdThirdPartUnpickAll;
        private System.Windows.Forms.ComboBox cboMotor;
        private System.Windows.Forms.Label lblMotor;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.ComboBox cboVoltage;
        private System.Windows.Forms.Label lblVoltage;
    }
}