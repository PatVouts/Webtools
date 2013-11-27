namespace RefplusWebtools.DataManager.CondensingUnit
{
    partial class FrmDrawingManagerCondesingUnit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDrawingManagerCondesingUnit));
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
            GlacialComponents.Controls.GLColumn glColumn11 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn12 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn13 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn14 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn15 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn16 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn17 = new GlacialComponents.Controls.GLColumn();
            this.grpVoltage = new System.Windows.Forms.GroupBox();
            this.cmdVoltagePickAll = new System.Windows.Forms.Button();
            this.lvVoltage = new GlacialComponents.Controls.GlacialList();
            this.cmdVoltageUnpickAll = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
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
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblDrawing = new System.Windows.Forms.Label();
            this.cboDrawing = new System.Windows.Forms.ComboBox();
            this.cmdUploadAndPreviewFile = new System.Windows.Forms.Button();
            this.lvDrawingList = new GlacialComponents.Controls.GlacialList();
            this.cmdLoad = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.grpVoltage.SuspendLayout();
            this.grpOptions.SuspendLayout();
            this.grpFirstPart.SuspendLayout();
            this.grpHP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxHP)).BeginInit();
            this.grpCompressors.SuspendLayout();
            this.grpThirdPart.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpVoltage
            // 
            this.grpVoltage.Controls.Add(this.cmdVoltagePickAll);
            this.grpVoltage.Controls.Add(this.lvVoltage);
            this.grpVoltage.Controls.Add(this.cmdVoltageUnpickAll);
            this.grpVoltage.Location = new System.Drawing.Point(451, 313);
            this.grpVoltage.Name = "grpVoltage";
            this.grpVoltage.Size = new System.Drawing.Size(171, 243);
            this.grpVoltage.TabIndex = 145;
            this.grpVoltage.TabStop = false;
            this.grpVoltage.Text = "sVoltage";
            // 
            // cmdVoltagePickAll
            // 
            this.cmdVoltagePickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdVoltagePickAll.Image")));
            this.cmdVoltagePickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdVoltagePickAll.Location = new System.Drawing.Point(6, 32);
            this.cmdVoltagePickAll.Name = "cmdVoltagePickAll";
            this.cmdVoltagePickAll.Size = new System.Drawing.Size(160, 23);
            this.cmdVoltagePickAll.TabIndex = 0;
            this.cmdVoltagePickAll.Text = "sPick All";
            this.cmdVoltagePickAll.UseVisualStyleBackColor = true;
            this.cmdVoltagePickAll.Click += new System.EventHandler(this.cmdVoltagePickAll_Click);
            // 
            // lvVoltage
            // 
            this.lvVoltage.AllowColumnResize = true;
            this.lvVoltage.AllowMultiselect = false;
            this.lvVoltage.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvVoltage.AlternatingColors = false;
            this.lvVoltage.AutoHeight = true;
            this.lvVoltage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvVoltage.BackgroundStretchToFit = true;
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
            glColumn2.Width = 100;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Column1x";
            glColumn3.NumericSort = false;
            glColumn3.Text = "sVoltageID";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 0;
            this.lvVoltage.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3});
            this.lvVoltage.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvVoltage.FullRowSelect = true;
            this.lvVoltage.GridColor = System.Drawing.Color.LightGray;
            this.lvVoltage.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvVoltage.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridSolid;
            this.lvVoltage.GridTypes = GlacialComponents.Controls.GLGridTypes.gridOnExists;
            this.lvVoltage.HeaderHeight = 22;
            this.lvVoltage.HeaderVisible = true;
            this.lvVoltage.HeaderWordWrap = false;
            this.lvVoltage.HotColumnTracking = false;
            this.lvVoltage.HotItemTracking = false;
            this.lvVoltage.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvVoltage.HoverEvents = false;
            this.lvVoltage.HoverTime = 1;
            this.lvVoltage.ImageList = null;
            this.lvVoltage.ItemHeight = 4;
            this.lvVoltage.ItemWordWrap = false;
            this.lvVoltage.Location = new System.Drawing.Point(6, 61);
            this.lvVoltage.Name = "lvVoltage";
            this.lvVoltage.Selectable = true;
            this.lvVoltage.SelectedTextColor = System.Drawing.Color.White;
            this.lvVoltage.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvVoltage.ShowBorder = true;
            this.lvVoltage.ShowFocusRect = false;
            this.lvVoltage.Size = new System.Drawing.Size(160, 143);
            this.lvVoltage.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lvVoltage.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvVoltage.TabIndex = 1;
            this.lvVoltage.Text = "glacialList1";
            // 
            // cmdVoltageUnpickAll
            // 
            this.cmdVoltageUnpickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdVoltageUnpickAll.Image")));
            this.cmdVoltageUnpickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdVoltageUnpickAll.Location = new System.Drawing.Point(6, 213);
            this.cmdVoltageUnpickAll.Name = "cmdVoltageUnpickAll";
            this.cmdVoltageUnpickAll.Size = new System.Drawing.Size(160, 23);
            this.cmdVoltageUnpickAll.TabIndex = 2;
            this.cmdVoltageUnpickAll.Text = "sUnpick All";
            this.cmdVoltageUnpickAll.UseVisualStyleBackColor = true;
            this.cmdVoltageUnpickAll.Click += new System.EventHandler(this.cmdVoltageUnpickAll_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(641, 562);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(150, 25);
            this.cmdClose.TabIndex = 149;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(285, 562);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(150, 25);
            this.cmdSave.TabIndex = 148;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.cmdOptionsPickAll);
            this.grpOptions.Controls.Add(this.lvOptions);
            this.grpOptions.Controls.Add(this.cmdOptionsUnpickAll);
            this.grpOptions.Location = new System.Drawing.Point(628, 313);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(158, 243);
            this.grpOptions.TabIndex = 146;
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
            glColumn5.Width = 100;
            glColumn6.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn6.CheckBoxes = false;
            glColumn6.DatetimeSort = false;
            glColumn6.ImageIndex = -1;
            glColumn6.Name = "Column1x";
            glColumn6.NumericSort = false;
            glColumn6.Text = "sVoltageID";
            glColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn6.Width = 0;
            this.lvOptions.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn4,
            glColumn5,
            glColumn6});
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
            this.lvOptions.Size = new System.Drawing.Size(145, 143);
            this.lvOptions.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lvOptions.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvOptions.TabIndex = 1;
            this.lvOptions.Text = "glacialList1";
            // 
            // cmdOptionsUnpickAll
            // 
            this.cmdOptionsUnpickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdOptionsUnpickAll.Image")));
            this.cmdOptionsUnpickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOptionsUnpickAll.Location = new System.Drawing.Point(6, 213);
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
            this.grpFirstPart.Location = new System.Drawing.Point(337, 64);
            this.grpFirstPart.Name = "grpFirstPart";
            this.grpFirstPart.Size = new System.Drawing.Size(161, 243);
            this.grpFirstPart.TabIndex = 141;
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
            glColumn7.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn7.CheckBoxes = true;
            glColumn7.DatetimeSort = false;
            glColumn7.ImageIndex = -1;
            glColumn7.Name = "Column1";
            glColumn7.NumericSort = false;
            glColumn7.Text = "";
            glColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn7.Width = 20;
            glColumn8.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn8.CheckBoxes = false;
            glColumn8.DatetimeSort = false;
            glColumn8.ImageIndex = -1;
            glColumn8.Name = "Column2";
            glColumn8.NumericSort = false;
            glColumn8.Text = "";
            glColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn8.Width = 30;
            glColumn9.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn9.CheckBoxes = false;
            glColumn9.DatetimeSort = false;
            glColumn9.ImageIndex = -1;
            glColumn9.Name = "Column3";
            glColumn9.NumericSort = false;
            glColumn9.Text = "";
            glColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn9.Width = 30;
            glColumn10.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn10.CheckBoxes = false;
            glColumn10.DatetimeSort = false;
            glColumn10.ImageIndex = -1;
            glColumn10.Name = "Column4";
            glColumn10.NumericSort = false;
            glColumn10.Text = "";
            glColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn10.Width = 30;
            this.lvFirstPart.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn7,
            glColumn8,
            glColumn9,
            glColumn10});
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
            this.lvFirstPart.Size = new System.Drawing.Size(150, 143);
            this.lvFirstPart.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lvFirstPart.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvFirstPart.TabIndex = 1;
            this.lvFirstPart.Text = "glacialList1";
            // 
            // cmdFirstPartUnpickAll
            // 
            this.cmdFirstPartUnpickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdFirstPartUnpickAll.Image")));
            this.cmdFirstPartUnpickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdFirstPartUnpickAll.Location = new System.Drawing.Point(6, 213);
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
            this.grpHP.Location = new System.Drawing.Point(504, 64);
            this.grpHP.Name = "grpHP";
            this.grpHP.Size = new System.Drawing.Size(100, 243);
            this.grpHP.TabIndex = 142;
            this.grpHP.TabStop = false;
            this.grpHP.Text = "sHP Range";
            // 
            // lblHPTo
            // 
            this.lblHPTo.Location = new System.Drawing.Point(6, 100);
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
            this.numMinHP.Location = new System.Drawing.Point(6, 77);
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
            this.numMaxHP.Location = new System.Drawing.Point(6, 171);
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
            this.cmdHPUnpickAll.Location = new System.Drawing.Point(6, 213);
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
            this.grpCompressors.Location = new System.Drawing.Point(610, 64);
            this.grpCompressors.Name = "grpCompressors";
            this.grpCompressors.Size = new System.Drawing.Size(112, 243);
            this.grpCompressors.TabIndex = 143;
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
            glColumn11.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn11.CheckBoxes = true;
            glColumn11.DatetimeSort = false;
            glColumn11.ImageIndex = -1;
            glColumn11.Name = "Column1";
            glColumn11.NumericSort = false;
            glColumn11.Text = "";
            glColumn11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn11.Width = 20;
            glColumn12.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn12.CheckBoxes = false;
            glColumn12.DatetimeSort = false;
            glColumn12.ImageIndex = -1;
            glColumn12.Name = "Column2";
            glColumn12.NumericSort = false;
            glColumn12.Text = "";
            glColumn12.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn12.Width = 40;
            this.lvCompressor.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn11,
            glColumn12});
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
            this.lvCompressor.Size = new System.Drawing.Size(101, 143);
            this.lvCompressor.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lvCompressor.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvCompressor.TabIndex = 1;
            this.lvCompressor.Text = "glacialList1";
            // 
            // cmdCompressorUnpickAll
            // 
            this.cmdCompressorUnpickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdCompressorUnpickAll.Image")));
            this.cmdCompressorUnpickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCompressorUnpickAll.Location = new System.Drawing.Point(6, 213);
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
            this.grpThirdPart.Location = new System.Drawing.Point(285, 313);
            this.grpThirdPart.Name = "grpThirdPart";
            this.grpThirdPart.Size = new System.Drawing.Size(160, 243);
            this.grpThirdPart.TabIndex = 144;
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
            glColumn13.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn13.CheckBoxes = true;
            glColumn13.DatetimeSort = false;
            glColumn13.ImageIndex = -1;
            glColumn13.Name = "Column1";
            glColumn13.NumericSort = false;
            glColumn13.Text = "";
            glColumn13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn13.Width = 20;
            glColumn14.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn14.CheckBoxes = false;
            glColumn14.DatetimeSort = false;
            glColumn14.ImageIndex = -1;
            glColumn14.Name = "Column2";
            glColumn14.NumericSort = false;
            glColumn14.Text = "";
            glColumn14.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn14.Width = 30;
            glColumn15.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn15.CheckBoxes = false;
            glColumn15.DatetimeSort = false;
            glColumn15.ImageIndex = -1;
            glColumn15.Name = "Column3";
            glColumn15.NumericSort = false;
            glColumn15.Text = "";
            glColumn15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn15.Width = 30;
            glColumn16.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn16.CheckBoxes = false;
            glColumn16.DatetimeSort = false;
            glColumn16.ImageIndex = -1;
            glColumn16.Name = "Column4";
            glColumn16.NumericSort = false;
            glColumn16.Text = "";
            glColumn16.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn16.Width = 30;
            this.lvThirdPart.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn13,
            glColumn14,
            glColumn15,
            glColumn16});
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
            this.lvThirdPart.Size = new System.Drawing.Size(150, 143);
            this.lvThirdPart.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lvThirdPart.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvThirdPart.TabIndex = 1;
            this.lvThirdPart.Text = "glacialList1";
            // 
            // cmdThirdPartUnpickAll
            // 
            this.cmdThirdPartUnpickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdThirdPartUnpickAll.Image")));
            this.cmdThirdPartUnpickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdThirdPartUnpickAll.Location = new System.Drawing.Point(6, 213);
            this.cmdThirdPartUnpickAll.Name = "cmdThirdPartUnpickAll";
            this.cmdThirdPartUnpickAll.Size = new System.Drawing.Size(150, 23);
            this.cmdThirdPartUnpickAll.TabIndex = 2;
            this.cmdThirdPartUnpickAll.Text = "sUnpick All";
            this.cmdThirdPartUnpickAll.UseVisualStyleBackColor = true;
            this.cmdThirdPartUnpickAll.Click += new System.EventHandler(this.cmdThirdPartUnpickAll_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(345, 12);
            this.txtDescription.MaxLength = 255;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(433, 20);
            this.txtDescription.TabIndex = 150;
            this.txtDescription.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(274, 15);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(65, 13);
            this.lblDescription.TabIndex = 151;
            this.lblDescription.Text = "sDescription";
            // 
            // lblDrawing
            // 
            this.lblDrawing.AutoSize = true;
            this.lblDrawing.Location = new System.Drawing.Point(274, 40);
            this.lblDrawing.Name = "lblDrawing";
            this.lblDrawing.Size = new System.Drawing.Size(51, 13);
            this.lblDrawing.TabIndex = 152;
            this.lblDrawing.Text = "sDrawing";
            // 
            // cboDrawing
            // 
            this.cboDrawing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDrawing.FormattingEnabled = true;
            this.cboDrawing.Location = new System.Drawing.Point(345, 37);
            this.cboDrawing.Name = "cboDrawing";
            this.cboDrawing.Size = new System.Drawing.Size(259, 21);
            this.cboDrawing.TabIndex = 153;
            // 
            // cmdUploadAndPreviewFile
            // 
            this.cmdUploadAndPreviewFile.Image = ((System.Drawing.Image)(resources.GetObject("cmdUploadAndPreviewFile.Image")));
            this.cmdUploadAndPreviewFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUploadAndPreviewFile.Location = new System.Drawing.Point(610, 34);
            this.cmdUploadAndPreviewFile.Name = "cmdUploadAndPreviewFile";
            this.cmdUploadAndPreviewFile.Size = new System.Drawing.Size(168, 25);
            this.cmdUploadAndPreviewFile.TabIndex = 154;
            this.cmdUploadAndPreviewFile.Text = "sUpload and preview files";
            this.cmdUploadAndPreviewFile.UseVisualStyleBackColor = true;
            this.cmdUploadAndPreviewFile.Click += new System.EventHandler(this.cmdUploadAndPreviewFile_Click);
            // 
            // lvDrawingList
            // 
            this.lvDrawingList.AllowColumnResize = true;
            this.lvDrawingList.AllowMultiselect = false;
            this.lvDrawingList.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvDrawingList.AlternatingColors = false;
            this.lvDrawingList.AutoHeight = true;
            this.lvDrawingList.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvDrawingList.BackgroundStretchToFit = true;
            glColumn17.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn17.CheckBoxes = false;
            glColumn17.DatetimeSort = false;
            glColumn17.ImageIndex = -1;
            glColumn17.Name = "Column1";
            glColumn17.NumericSort = false;
            glColumn17.Text = "sDescription";
            glColumn17.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn17.Width = 225;
            this.lvDrawingList.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn17});
            this.lvDrawingList.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvDrawingList.FullRowSelect = true;
            this.lvDrawingList.GridColor = System.Drawing.Color.LightGray;
            this.lvDrawingList.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvDrawingList.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvDrawingList.GridTypes = GlacialComponents.Controls.GLGridTypes.gridOnExists;
            this.lvDrawingList.HeaderHeight = 22;
            this.lvDrawingList.HeaderVisible = true;
            this.lvDrawingList.HeaderWordWrap = false;
            this.lvDrawingList.HotColumnTracking = false;
            this.lvDrawingList.HotItemTracking = false;
            this.lvDrawingList.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvDrawingList.HoverEvents = false;
            this.lvDrawingList.HoverTime = 1;
            this.lvDrawingList.ImageList = null;
            this.lvDrawingList.ItemHeight = 17;
            this.lvDrawingList.ItemWordWrap = false;
            this.lvDrawingList.Location = new System.Drawing.Point(12, 12);
            this.lvDrawingList.Name = "lvDrawingList";
            this.lvDrawingList.Selectable = true;
            this.lvDrawingList.SelectedTextColor = System.Drawing.Color.White;
            this.lvDrawingList.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvDrawingList.ShowBorder = true;
            this.lvDrawingList.ShowFocusRect = false;
            this.lvDrawingList.Size = new System.Drawing.Size(256, 519);
            this.lvDrawingList.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lvDrawingList.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvDrawingList.TabIndex = 155;
            this.lvDrawingList.Text = "glacialList1";
            this.lvDrawingList.SelectedIndexChanged += new GlacialComponents.Controls.GlacialList.ClickedEventHandler(this.lvDrawingList_SelectedIndexChanged);
            this.lvDrawingList.Click += new System.EventHandler(this.lvDrawingList_Click);
            // 
            // cmdLoad
            // 
            this.cmdLoad.Image = ((System.Drawing.Image)(resources.GetObject("cmdLoad.Image")));
            this.cmdLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLoad.Location = new System.Drawing.Point(12, 537);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(256, 23);
            this.cmdLoad.TabIndex = 156;
            this.cmdLoad.Text = "sLoad Selected Option";
            this.cmdLoad.UseVisualStyleBackColor = true;
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(12, 563);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(256, 23);
            this.cmdDelete.TabIndex = 157;
            this.cmdDelete.Text = "sDelete Selected Option";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // frmDrawingManagerCondesingUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(794, 591);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdLoad);
            this.Controls.Add(this.lvDrawingList);
            this.Controls.Add(this.cmdUploadAndPreviewFile);
            this.Controls.Add(this.cboDrawing);
            this.Controls.Add(this.lblDrawing);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.grpVoltage);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.grpFirstPart);
            this.Controls.Add(this.grpHP);
            this.Controls.Add(this.grpCompressors);
            this.Controls.Add(this.grpThirdPart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDrawingManagerCondesingUnit";
            this.Text = "sData Manager - Drawings Manager Condensing Units";
            this.Load += new System.EventHandler(this.frmDrawingManagerCondesingUnit_Load);
            this.grpVoltage.ResumeLayout(false);
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

        private System.Windows.Forms.GroupBox grpVoltage;
        private System.Windows.Forms.Button cmdVoltagePickAll;
        private GlacialComponents.Controls.GlacialList lvVoltage;
        private System.Windows.Forms.Button cmdVoltageUnpickAll;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSave;
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
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblDrawing;
        private System.Windows.Forms.ComboBox cboDrawing;
        private System.Windows.Forms.Button cmdUploadAndPreviewFile;
        private GlacialComponents.Controls.GlacialList lvDrawingList;
        private System.Windows.Forms.Button cmdLoad;
        private System.Windows.Forms.Button cmdDelete;
    }
}