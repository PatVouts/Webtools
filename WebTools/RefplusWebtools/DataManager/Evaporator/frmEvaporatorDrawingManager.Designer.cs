namespace RefplusWebtools.DataManager.Evaporator
{
    partial class FrmEvaporatorDrawingManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEvaporatorDrawingManager));
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn4 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn5 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn6 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn7 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn8 = new GlacialComponents.Controls.GLColumn();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdLoad = new System.Windows.Forms.Button();
            this.lvDrawingList = new GlacialComponents.Controls.GlacialList();
            this.cmdUploadAndPreviewFile = new System.Windows.Forms.Button();
            this.cboDrawing = new System.Windows.Forms.ComboBox();
            this.lblDrawing = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.grpSerie = new System.Windows.Forms.GroupBox();
            this.cmdSeriePickAll = new System.Windows.Forms.Button();
            this.lvSerie = new GlacialComponents.Controls.GlacialList();
            this.cmdSerieUnpickAll = new System.Windows.Forms.Button();
            this.grpCapacity = new System.Windows.Forms.GroupBox();
            this.lblCapacityTo = new System.Windows.Forms.Label();
            this.cmdCapacityPickAll = new System.Windows.Forms.Button();
            this.numMinCapacity = new System.Windows.Forms.NumericUpDown();
            this.numMaxCapacity = new System.Windows.Forms.NumericUpDown();
            this.cmdCapacityUnpickAll = new System.Windows.Forms.Button();
            this.grpVoltage = new System.Windows.Forms.GroupBox();
            this.cmdVoltagePickAll = new System.Windows.Forms.Button();
            this.lvVoltage = new GlacialComponents.Controls.GlacialList();
            this.cmdVoltageUnpickAll = new System.Windows.Forms.Button();
            this.grpSerie.SuspendLayout();
            this.grpCapacity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxCapacity)).BeginInit();
            this.grpVoltage.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdDelete
            // 
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(12, 563);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(256, 23);
            this.cmdDelete.TabIndex = 167;
            this.cmdDelete.Text = "sDelete Selected Option";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdLoad
            // 
            this.cmdLoad.Image = ((System.Drawing.Image)(resources.GetObject("cmdLoad.Image")));
            this.cmdLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLoad.Location = new System.Drawing.Point(12, 537);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(256, 23);
            this.cmdLoad.TabIndex = 166;
            this.cmdLoad.Text = "sLoad Selected Option";
            this.cmdLoad.UseVisualStyleBackColor = true;
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
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
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1";
            glColumn1.NumericSort = false;
            glColumn1.Text = "sDescription";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 225;
            this.lvDrawingList.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1});
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
            this.lvDrawingList.TabIndex = 165;
            this.lvDrawingList.Text = "glacialList1";
            this.lvDrawingList.SelectedIndexChanged += new GlacialComponents.Controls.GlacialList.ClickedEventHandler(this.lvDrawingList_SelectedIndexChanged);
            this.lvDrawingList.Click += new System.EventHandler(this.lvDrawingList_Click);
            // 
            // cmdUploadAndPreviewFile
            // 
            this.cmdUploadAndPreviewFile.Image = ((System.Drawing.Image)(resources.GetObject("cmdUploadAndPreviewFile.Image")));
            this.cmdUploadAndPreviewFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUploadAndPreviewFile.Location = new System.Drawing.Point(610, 34);
            this.cmdUploadAndPreviewFile.Name = "cmdUploadAndPreviewFile";
            this.cmdUploadAndPreviewFile.Size = new System.Drawing.Size(168, 25);
            this.cmdUploadAndPreviewFile.TabIndex = 164;
            this.cmdUploadAndPreviewFile.Text = "sUpload and preview files";
            this.cmdUploadAndPreviewFile.UseVisualStyleBackColor = true;
            this.cmdUploadAndPreviewFile.Click += new System.EventHandler(this.cmdUploadAndPreviewFile_Click);
            // 
            // cboDrawing
            // 
            this.cboDrawing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDrawing.FormattingEnabled = true;
            this.cboDrawing.Location = new System.Drawing.Point(345, 37);
            this.cboDrawing.Name = "cboDrawing";
            this.cboDrawing.Size = new System.Drawing.Size(259, 21);
            this.cboDrawing.TabIndex = 163;
            // 
            // lblDrawing
            // 
            this.lblDrawing.AutoSize = true;
            this.lblDrawing.Location = new System.Drawing.Point(274, 40);
            this.lblDrawing.Name = "lblDrawing";
            this.lblDrawing.Size = new System.Drawing.Size(51, 13);
            this.lblDrawing.TabIndex = 162;
            this.lblDrawing.Text = "sDrawing";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(274, 15);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(65, 13);
            this.lblDescription.TabIndex = 161;
            this.lblDescription.Text = "sDescription";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(345, 12);
            this.txtDescription.MaxLength = 255;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(433, 20);
            this.txtDescription.TabIndex = 160;
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(641, 562);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(150, 25);
            this.cmdClose.TabIndex = 159;
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
            this.cmdSave.TabIndex = 158;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // grpSerie
            // 
            this.grpSerie.Controls.Add(this.cmdSeriePickAll);
            this.grpSerie.Controls.Add(this.lvSerie);
            this.grpSerie.Controls.Add(this.cmdSerieUnpickAll);
            this.grpSerie.Location = new System.Drawing.Point(277, 172);
            this.grpSerie.Name = "grpSerie";
            this.grpSerie.Size = new System.Drawing.Size(161, 251);
            this.grpSerie.TabIndex = 168;
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
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = true;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column1";
            glColumn2.NumericSort = false;
            glColumn2.Text = "";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn2.Width = 20;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Column2";
            glColumn3.NumericSort = false;
            glColumn3.Text = "";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn3.Width = 30;
            glColumn4.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn4.CheckBoxes = false;
            glColumn4.DatetimeSort = false;
            glColumn4.ImageIndex = -1;
            glColumn4.Name = "Column3";
            glColumn4.NumericSort = false;
            glColumn4.Text = "";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn4.Width = 30;
            glColumn5.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn5.CheckBoxes = false;
            glColumn5.DatetimeSort = false;
            glColumn5.ImageIndex = -1;
            glColumn5.Name = "Column4";
            glColumn5.NumericSort = false;
            glColumn5.Text = "";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn5.Width = 30;
            this.lvSerie.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn2,
            glColumn3,
            glColumn4,
            glColumn5});
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
            // grpCapacity
            // 
            this.grpCapacity.Controls.Add(this.lblCapacityTo);
            this.grpCapacity.Controls.Add(this.cmdCapacityPickAll);
            this.grpCapacity.Controls.Add(this.numMinCapacity);
            this.grpCapacity.Controls.Add(this.numMaxCapacity);
            this.grpCapacity.Controls.Add(this.cmdCapacityUnpickAll);
            this.grpCapacity.Location = new System.Drawing.Point(444, 172);
            this.grpCapacity.Name = "grpCapacity";
            this.grpCapacity.Size = new System.Drawing.Size(158, 251);
            this.grpCapacity.TabIndex = 169;
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
            // grpVoltage
            // 
            this.grpVoltage.Controls.Add(this.cmdVoltagePickAll);
            this.grpVoltage.Controls.Add(this.lvVoltage);
            this.grpVoltage.Controls.Add(this.cmdVoltageUnpickAll);
            this.grpVoltage.Location = new System.Drawing.Point(608, 172);
            this.grpVoltage.Name = "grpVoltage";
            this.grpVoltage.Size = new System.Drawing.Size(171, 251);
            this.grpVoltage.TabIndex = 170;
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
            glColumn7.Width = 100;
            glColumn8.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn8.CheckBoxes = false;
            glColumn8.DatetimeSort = false;
            glColumn8.ImageIndex = -1;
            glColumn8.Name = "Column1x";
            glColumn8.NumericSort = false;
            glColumn8.Text = "sVoltageID";
            glColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn8.Width = 0;
            this.lvVoltage.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn6,
            glColumn7,
            glColumn8});
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
            // frmEvaporatorDrawingManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(811, 597);
            this.Controls.Add(this.grpSerie);
            this.Controls.Add(this.grpCapacity);
            this.Controls.Add(this.grpVoltage);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdLoad);
            this.Controls.Add(this.lvDrawingList);
            this.Controls.Add(this.cmdUploadAndPreviewFile);
            this.Controls.Add(this.cboDrawing);
            this.Controls.Add(this.lblDrawing);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEvaporatorDrawingManager";
            this.Text = "sData Manager - Drawings Manager Evaporator";
            this.Load += new System.EventHandler(this.frmEvaporatorDrawingManager_Load);
            this.grpSerie.ResumeLayout(false);
            this.grpCapacity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numMinCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxCapacity)).EndInit();
            this.grpVoltage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdLoad;
        private GlacialComponents.Controls.GlacialList lvDrawingList;
        private System.Windows.Forms.Button cmdUploadAndPreviewFile;
        private System.Windows.Forms.ComboBox cboDrawing;
        private System.Windows.Forms.Label lblDrawing;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.GroupBox grpSerie;
        private System.Windows.Forms.Button cmdSeriePickAll;
        private GlacialComponents.Controls.GlacialList lvSerie;
        private System.Windows.Forms.Button cmdSerieUnpickAll;
        private System.Windows.Forms.GroupBox grpCapacity;
        private System.Windows.Forms.Label lblCapacityTo;
        private System.Windows.Forms.Button cmdCapacityPickAll;
        private System.Windows.Forms.NumericUpDown numMinCapacity;
        private System.Windows.Forms.NumericUpDown numMaxCapacity;
        private System.Windows.Forms.Button cmdCapacityUnpickAll;
        private System.Windows.Forms.GroupBox grpVoltage;
        private System.Windows.Forms.Button cmdVoltagePickAll;
        private GlacialComponents.Controls.GlacialList lvVoltage;
        private System.Windows.Forms.Button cmdVoltageUnpickAll;
    }
}