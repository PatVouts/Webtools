namespace RefplusWebtools.DataManager.Evaporator
{
    partial class FrmEvaporatorOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEvaporatorOptions));
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn4 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn5 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn6 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn7 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn8 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn9 = new GlacialComponents.Controls.GLColumn();
            this.lvOptionsList = new GlacialComponents.Controls.GlacialList();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdLoad = new System.Windows.Forms.Button();
            this.pnlOption = new System.Windows.Forms.Panel();
            this.grpEvaporatorCoolant = new System.Windows.Forms.GroupBox();
            this.chkWater = new System.Windows.Forms.CheckBox();
            this.chkRefrigerant = new System.Windows.Forms.CheckBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lblPrice = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.lblGroup = new System.Windows.Forms.Label();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.grpSerie = new System.Windows.Forms.GroupBox();
            this.cmdSeriePickAll = new System.Windows.Forms.Button();
            this.lvSerie = new GlacialComponents.Controls.GlacialList();
            this.cmdSerieUnpickAll = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.grpCapacity = new System.Windows.Forms.GroupBox();
            this.lblCapacityTo = new System.Windows.Forms.Label();
            this.cmdCapacityPickAll = new System.Windows.Forms.Button();
            this.numMinCapacity = new System.Windows.Forms.NumericUpDown();
            this.numMaxCapacity = new System.Windows.Forms.NumericUpDown();
            this.cmdCapacityUnpickAll = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.grpVoltage = new System.Windows.Forms.GroupBox();
            this.cmdVoltagePickAll = new System.Windows.Forms.Button();
            this.lvVoltage = new GlacialComponents.Controls.GlacialList();
            this.cmdVoltageUnpickAll = new System.Windows.Forms.Button();
            this.pnlOption.SuspendLayout();
            this.grpEvaporatorCoolant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            this.grpSerie.SuspendLayout();
            this.grpCapacity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxCapacity)).BeginInit();
            this.grpVoltage.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvOptionsList
            // 
            this.lvOptionsList.AllowColumnResize = true;
            this.lvOptionsList.AllowMultiselect = false;
            this.lvOptionsList.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvOptionsList.AlternatingColors = false;
            this.lvOptionsList.AutoHeight = true;
            this.lvOptionsList.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvOptionsList.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1";
            glColumn1.NumericSort = false;
            glColumn1.Text = "sGroup";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 300;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column2";
            glColumn2.NumericSort = false;
            glColumn2.Text = "sDescription";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 445;
            this.lvOptionsList.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2});
            this.lvOptionsList.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvOptionsList.FullRowSelect = true;
            this.lvOptionsList.GridColor = System.Drawing.Color.LightGray;
            this.lvOptionsList.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvOptionsList.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvOptionsList.GridTypes = GlacialComponents.Controls.GLGridTypes.gridOnExists;
            this.lvOptionsList.HeaderHeight = 22;
            this.lvOptionsList.HeaderVisible = true;
            this.lvOptionsList.HeaderWordWrap = false;
            this.lvOptionsList.HotColumnTracking = false;
            this.lvOptionsList.HotItemTracking = false;
            this.lvOptionsList.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvOptionsList.HoverEvents = false;
            this.lvOptionsList.HoverTime = 1;
            this.lvOptionsList.ImageList = null;
            this.lvOptionsList.ItemHeight = 17;
            this.lvOptionsList.ItemWordWrap = false;
            this.lvOptionsList.Location = new System.Drawing.Point(11, 12);
            this.lvOptionsList.Name = "lvOptionsList";
            this.lvOptionsList.Selectable = true;
            this.lvOptionsList.SelectedTextColor = System.Drawing.Color.White;
            this.lvOptionsList.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvOptionsList.ShowBorder = true;
            this.lvOptionsList.ShowFocusRect = false;
            this.lvOptionsList.Size = new System.Drawing.Size(771, 175);
            this.lvOptionsList.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lvOptionsList.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvOptionsList.TabIndex = 0;
            this.lvOptionsList.Text = "glacialList1";
            this.lvOptionsList.SelectedIndexChanged += new GlacialComponents.Controls.GlacialList.ClickedEventHandler(this.lvOptionsList_SelectedIndexChanged);
            this.lvOptionsList.Click += new System.EventHandler(this.lvOptionsList_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(602, 193);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(180, 23);
            this.cmdDelete.TabIndex = 2;
            this.cmdDelete.Text = "sDelete Selected Option";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdLoad
            // 
            this.cmdLoad.Image = ((System.Drawing.Image)(resources.GetObject("cmdLoad.Image")));
            this.cmdLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLoad.Location = new System.Drawing.Point(11, 193);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(585, 23);
            this.cmdLoad.TabIndex = 1;
            this.cmdLoad.Text = "sLoad Selected Option";
            this.cmdLoad.UseVisualStyleBackColor = true;
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
            // 
            // pnlOption
            // 
            this.pnlOption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnlOption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOption.Controls.Add(this.grpEvaporatorCoolant);
            this.pnlOption.Controls.Add(this.cmdSave);
            this.pnlOption.Controls.Add(this.lblPrice);
            this.pnlOption.Controls.Add(this.numPrice);
            this.pnlOption.Controls.Add(this.lblGroup);
            this.pnlOption.Controls.Add(this.txtGroup);
            this.pnlOption.Controls.Add(this.grpSerie);
            this.pnlOption.Controls.Add(this.lblDescription);
            this.pnlOption.Controls.Add(this.grpCapacity);
            this.pnlOption.Controls.Add(this.txtDescription);
            this.pnlOption.Controls.Add(this.grpVoltage);
            this.pnlOption.Location = new System.Drawing.Point(12, 222);
            this.pnlOption.Name = "pnlOption";
            this.pnlOption.Size = new System.Drawing.Size(770, 377);
            this.pnlOption.TabIndex = 3;
            // 
            // grpEvaporatorCoolant
            // 
            this.grpEvaporatorCoolant.Controls.Add(this.chkWater);
            this.grpEvaporatorCoolant.Controls.Add(this.chkRefrigerant);
            this.grpEvaporatorCoolant.Location = new System.Drawing.Point(604, 85);
            this.grpEvaporatorCoolant.Name = "grpEvaporatorCoolant";
            this.grpEvaporatorCoolant.Size = new System.Drawing.Size(133, 251);
            this.grpEvaporatorCoolant.TabIndex = 6;
            this.grpEvaporatorCoolant.TabStop = false;
            this.grpEvaporatorCoolant.Text = "sCoolant Availaible";
            // 
            // chkWater
            // 
            this.chkWater.AutoSize = true;
            this.chkWater.Location = new System.Drawing.Point(28, 169);
            this.chkWater.Name = "chkWater";
            this.chkWater.Size = new System.Drawing.Size(60, 17);
            this.chkWater.TabIndex = 26;
            this.chkWater.Text = "sWater";
            this.chkWater.UseVisualStyleBackColor = true;
            // 
            // chkRefrigerant
            // 
            this.chkRefrigerant.AutoSize = true;
            this.chkRefrigerant.Location = new System.Drawing.Point(28, 75);
            this.chkRefrigerant.Name = "chkRefrigerant";
            this.chkRefrigerant.Size = new System.Drawing.Size(83, 17);
            this.chkRefrigerant.TabIndex = 25;
            this.chkRefrigerant.Text = "sRefrigerant";
            this.chkRefrigerant.UseVisualStyleBackColor = true;
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(7, 342);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(750, 23);
            this.cmdSave.TabIndex = 6;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(11, 59);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(36, 13);
            this.lblPrice.TabIndex = 24;
            this.lblPrice.Text = "sPrice";
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new System.Drawing.Point(82, 57);
            this.numPrice.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numPrice.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(675, 20);
            this.numPrice.TabIndex = 2;
            this.numPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numPrice.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(11, 9);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(41, 13);
            this.lblGroup.TabIndex = 21;
            this.lblGroup.Text = "sGroup";
            // 
            // txtGroup
            // 
            this.txtGroup.Location = new System.Drawing.Point(82, 6);
            this.txtGroup.MaxLength = 255;
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(675, 20);
            this.txtGroup.TabIndex = 0;
            this.txtGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGroup.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // grpSerie
            // 
            this.grpSerie.Controls.Add(this.cmdSeriePickAll);
            this.grpSerie.Controls.Add(this.lvSerie);
            this.grpSerie.Controls.Add(this.cmdSerieUnpickAll);
            this.grpSerie.Location = new System.Drawing.Point(96, 85);
            this.grpSerie.Name = "grpSerie";
            this.grpSerie.Size = new System.Drawing.Size(161, 251);
            this.grpSerie.TabIndex = 3;
            this.grpSerie.TabStop = false;
            this.grpSerie.Text = "sType / Style / Defrost Type";
            // 
            // cmdSeriePickAll
            // 
            this.cmdSeriePickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdSeriePickAll.Image")));
            this.cmdSeriePickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSeriePickAll.Location = new System.Drawing.Point(6, 19);
            this.cmdSeriePickAll.Name = "cmdSeriePickAll";
            this.cmdSeriePickAll.Size = new System.Drawing.Size(150, 23);
            this.cmdSeriePickAll.TabIndex = 0;
            this.cmdSeriePickAll.Text = "sPick All";
            this.cmdSeriePickAll.UseVisualStyleBackColor = true;
            this.cmdSeriePickAll.Click += new System.EventHandler(this.cmdSeriePickAll_Click);
            // 
            // lvSerie
            // 
            this.lvSerie.AllowColumnResize = true;
            this.lvSerie.AllowMultiselect = false;
            this.lvSerie.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvSerie.AlternatingColors = false;
            this.lvSerie.AutoHeight = true;
            this.lvSerie.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvSerie.BackgroundStretchToFit = true;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = true;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Column1";
            glColumn3.NumericSort = false;
            glColumn3.Text = "";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn3.Width = 20;
            glColumn4.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn4.CheckBoxes = false;
            glColumn4.DatetimeSort = false;
            glColumn4.ImageIndex = -1;
            glColumn4.Name = "Column2";
            glColumn4.NumericSort = false;
            glColumn4.Text = "";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn4.Width = 30;
            glColumn5.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn5.CheckBoxes = false;
            glColumn5.DatetimeSort = false;
            glColumn5.ImageIndex = -1;
            glColumn5.Name = "Column3";
            glColumn5.NumericSort = false;
            glColumn5.Text = "";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn5.Width = 30;
            glColumn6.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn6.CheckBoxes = false;
            glColumn6.DatetimeSort = false;
            glColumn6.ImageIndex = -1;
            glColumn6.Name = "Column4";
            glColumn6.NumericSort = false;
            glColumn6.Text = "";
            glColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn6.Width = 30;
            this.lvSerie.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn3,
            glColumn4,
            glColumn5,
            glColumn6});
            this.lvSerie.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvSerie.FullRowSelect = true;
            this.lvSerie.GridColor = System.Drawing.Color.LightGray;
            this.lvSerie.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvSerie.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridSolid;
            this.lvSerie.GridTypes = GlacialComponents.Controls.GLGridTypes.gridOnExists;
            this.lvSerie.HeaderHeight = 22;
            this.lvSerie.HeaderVisible = true;
            this.lvSerie.HeaderWordWrap = false;
            this.lvSerie.HotColumnTracking = false;
            this.lvSerie.HotItemTracking = false;
            this.lvSerie.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvSerie.HoverEvents = false;
            this.lvSerie.HoverTime = 1;
            this.lvSerie.ImageList = null;
            this.lvSerie.ItemHeight = 4;
            this.lvSerie.ItemWordWrap = false;
            this.lvSerie.Location = new System.Drawing.Point(6, 48);
            this.lvSerie.Name = "lvSerie";
            this.lvSerie.Selectable = true;
            this.lvSerie.SelectedTextColor = System.Drawing.Color.White;
            this.lvSerie.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvSerie.ShowBorder = true;
            this.lvSerie.ShowFocusRect = false;
            this.lvSerie.Size = new System.Drawing.Size(150, 166);
            this.lvSerie.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lvSerie.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvSerie.TabIndex = 1;
            this.lvSerie.Text = "glacialList1";
            // 
            // cmdSerieUnpickAll
            // 
            this.cmdSerieUnpickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdSerieUnpickAll.Image")));
            this.cmdSerieUnpickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSerieUnpickAll.Location = new System.Drawing.Point(6, 220);
            this.cmdSerieUnpickAll.Name = "cmdSerieUnpickAll";
            this.cmdSerieUnpickAll.Size = new System.Drawing.Size(150, 23);
            this.cmdSerieUnpickAll.TabIndex = 2;
            this.cmdSerieUnpickAll.Text = "sUnpick All";
            this.cmdSerieUnpickAll.UseVisualStyleBackColor = true;
            this.cmdSerieUnpickAll.Click += new System.EventHandler(this.cmdSerieUnpickAll_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(11, 35);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(65, 13);
            this.lblDescription.TabIndex = 22;
            this.lblDescription.Text = "sDescription";
            // 
            // grpCapacity
            // 
            this.grpCapacity.Controls.Add(this.lblCapacityTo);
            this.grpCapacity.Controls.Add(this.cmdCapacityPickAll);
            this.grpCapacity.Controls.Add(this.numMinCapacity);
            this.grpCapacity.Controls.Add(this.numMaxCapacity);
            this.grpCapacity.Controls.Add(this.cmdCapacityUnpickAll);
            this.grpCapacity.Location = new System.Drawing.Point(263, 85);
            this.grpCapacity.Name = "grpCapacity";
            this.grpCapacity.Size = new System.Drawing.Size(158, 251);
            this.grpCapacity.TabIndex = 4;
            this.grpCapacity.TabStop = false;
            this.grpCapacity.Text = "sCapacity Range (btuh)";
            // 
            // lblCapacityTo
            // 
            this.lblCapacityTo.Location = new System.Drawing.Point(6, 97);
            this.lblCapacityTo.Name = "lblCapacityTo";
            this.lblCapacityTo.Size = new System.Drawing.Size(145, 68);
            this.lblCapacityTo.TabIndex = 25;
            this.lblCapacityTo.Text = "sTo";
            this.lblCapacityTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdCapacityPickAll
            // 
            this.cmdCapacityPickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdCapacityPickAll.Image")));
            this.cmdCapacityPickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCapacityPickAll.Location = new System.Drawing.Point(6, 19);
            this.cmdCapacityPickAll.Name = "cmdCapacityPickAll";
            this.cmdCapacityPickAll.Size = new System.Drawing.Size(145, 23);
            this.cmdCapacityPickAll.TabIndex = 0;
            this.cmdCapacityPickAll.Text = "sPick All";
            this.cmdCapacityPickAll.UseVisualStyleBackColor = true;
            this.cmdCapacityPickAll.Click += new System.EventHandler(this.cmdCapacityPickAll_Click);
            // 
            // numMinCapacity
            // 
            this.numMinCapacity.Location = new System.Drawing.Point(6, 74);
            this.numMinCapacity.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numMinCapacity.Name = "numMinCapacity";
            this.numMinCapacity.Size = new System.Drawing.Size(145, 20);
            this.numMinCapacity.TabIndex = 1;
            this.numMinCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numMinCapacity.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // numMaxCapacity
            // 
            this.numMaxCapacity.Location = new System.Drawing.Point(6, 168);
            this.numMaxCapacity.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numMaxCapacity.Name = "numMaxCapacity";
            this.numMaxCapacity.Size = new System.Drawing.Size(145, 20);
            this.numMaxCapacity.TabIndex = 2;
            this.numMaxCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numMaxCapacity.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // cmdCapacityUnpickAll
            // 
            this.cmdCapacityUnpickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdCapacityUnpickAll.Image")));
            this.cmdCapacityUnpickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCapacityUnpickAll.Location = new System.Drawing.Point(6, 220);
            this.cmdCapacityUnpickAll.Name = "cmdCapacityUnpickAll";
            this.cmdCapacityUnpickAll.Size = new System.Drawing.Size(145, 23);
            this.cmdCapacityUnpickAll.TabIndex = 3;
            this.cmdCapacityUnpickAll.Text = "sUnpick All";
            this.cmdCapacityUnpickAll.UseVisualStyleBackColor = true;
            this.cmdCapacityUnpickAll.Click += new System.EventHandler(this.cmdCapacityUnpickAll_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(82, 32);
            this.txtDescription.MaxLength = 255;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(675, 20);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDescription.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // grpVoltage
            // 
            this.grpVoltage.Controls.Add(this.cmdVoltagePickAll);
            this.grpVoltage.Controls.Add(this.lvVoltage);
            this.grpVoltage.Controls.Add(this.cmdVoltageUnpickAll);
            this.grpVoltage.Location = new System.Drawing.Point(427, 85);
            this.grpVoltage.Name = "grpVoltage";
            this.grpVoltage.Size = new System.Drawing.Size(171, 251);
            this.grpVoltage.TabIndex = 5;
            this.grpVoltage.TabStop = false;
            this.grpVoltage.Text = "sVoltage";
            // 
            // cmdVoltagePickAll
            // 
            this.cmdVoltagePickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdVoltagePickAll.Image")));
            this.cmdVoltagePickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdVoltagePickAll.Location = new System.Drawing.Point(5, 19);
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
            glColumn8.Width = 100;
            glColumn9.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn9.CheckBoxes = false;
            glColumn9.DatetimeSort = false;
            glColumn9.ImageIndex = -1;
            glColumn9.Name = "Column1x";
            glColumn9.NumericSort = false;
            glColumn9.Text = "sVoltageID";
            glColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn9.Width = 0;
            this.lvVoltage.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn7,
            glColumn8,
            glColumn9});
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
            this.lvVoltage.Location = new System.Drawing.Point(5, 48);
            this.lvVoltage.Name = "lvVoltage";
            this.lvVoltage.Selectable = true;
            this.lvVoltage.SelectedTextColor = System.Drawing.Color.White;
            this.lvVoltage.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvVoltage.ShowBorder = true;
            this.lvVoltage.ShowFocusRect = false;
            this.lvVoltage.Size = new System.Drawing.Size(160, 166);
            this.lvVoltage.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lvVoltage.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvVoltage.TabIndex = 1;
            this.lvVoltage.Text = "glacialList1";
            // 
            // cmdVoltageUnpickAll
            // 
            this.cmdVoltageUnpickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdVoltageUnpickAll.Image")));
            this.cmdVoltageUnpickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdVoltageUnpickAll.Location = new System.Drawing.Point(5, 220);
            this.cmdVoltageUnpickAll.Name = "cmdVoltageUnpickAll";
            this.cmdVoltageUnpickAll.Size = new System.Drawing.Size(160, 23);
            this.cmdVoltageUnpickAll.TabIndex = 2;
            this.cmdVoltageUnpickAll.Text = "sUnpick All";
            this.cmdVoltageUnpickAll.UseVisualStyleBackColor = true;
            this.cmdVoltageUnpickAll.Click += new System.EventHandler(this.cmdVoltageUnpickAll_Click);
            // 
            // frmEvaporatorOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(794, 609);
            this.Controls.Add(this.pnlOption);
            this.Controls.Add(this.lvOptionsList);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEvaporatorOptions";
            this.Text = "sData Manager - Evaporator Options";
            this.Load += new System.EventHandler(this.frmEvaporatorOptions_Load);
            this.pnlOption.ResumeLayout(false);
            this.pnlOption.PerformLayout();
            this.grpEvaporatorCoolant.ResumeLayout(false);
            this.grpEvaporatorCoolant.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            this.grpSerie.ResumeLayout(false);
            this.grpCapacity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numMinCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxCapacity)).EndInit();
            this.grpVoltage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GlacialComponents.Controls.GlacialList lvOptionsList;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdLoad;
        private System.Windows.Forms.Panel pnlOption;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.GroupBox grpSerie;
        private System.Windows.Forms.Button cmdSeriePickAll;
        private GlacialComponents.Controls.GlacialList lvSerie;
        private System.Windows.Forms.Button cmdSerieUnpickAll;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.GroupBox grpCapacity;
        private System.Windows.Forms.Label lblCapacityTo;
        private System.Windows.Forms.Button cmdCapacityPickAll;
        private System.Windows.Forms.NumericUpDown numMinCapacity;
        private System.Windows.Forms.NumericUpDown numMaxCapacity;
        private System.Windows.Forms.Button cmdCapacityUnpickAll;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox grpVoltage;
        private System.Windows.Forms.Button cmdVoltagePickAll;
        private GlacialComponents.Controls.GlacialList lvVoltage;
        private System.Windows.Forms.Button cmdVoltageUnpickAll;
        private System.Windows.Forms.GroupBox grpEvaporatorCoolant;
        private System.Windows.Forms.CheckBox chkWater;
        private System.Windows.Forms.CheckBox chkRefrigerant;
    }
}