namespace RefplusWebtools.DataManager.ControlPanel
{
    partial class FrmAddEditPanelLogic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddEditPanelLogic));
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn4 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn5 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn6 = new GlacialComponents.Controls.GLColumn();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.lblPanel = new System.Windows.Forms.Label();
            this.txtPanel = new System.Windows.Forms.TextBox();
            this.cboCoolerType = new System.Windows.Forms.ComboBox();
            this.lblCoolerType = new System.Windows.Forms.Label();
            this.numMinFanWide = new System.Windows.Forms.NumericUpDown();
            this.numMaxFanWide = new System.Windows.Forms.NumericUpDown();
            this.lblFanWideTo = new System.Windows.Forms.Label();
            this.lblFanWide = new System.Windows.Forms.Label();
            this.lblCircuit = new System.Windows.Forms.Label();
            this.lblCircuitTo = new System.Windows.Forms.Label();
            this.numMaxCircuit = new System.Windows.Forms.NumericUpDown();
            this.numMinCircuit = new System.Windows.Forms.NumericUpDown();
            this.lblEqualCapacity = new System.Windows.Forms.Label();
            this.cboEqualCapacity = new System.Windows.Forms.ComboBox();
            this.lvSeries = new GlacialComponents.Controls.GlacialList();
            this.cmdSeriePickAll = new System.Windows.Forms.Button();
            this.cmdSerieUnpickAll = new System.Windows.Forms.Button();
            this.lvPanelVoltage = new GlacialComponents.Controls.GlacialList();
            this.cmdVoltagePickAll = new System.Windows.Forms.Button();
            this.cmdVoltageUnpickAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numMinFanWide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxFanWide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxCircuit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinCircuit)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(15, 377);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(239, 26);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(487, 377);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(239, 26);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "sCancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // lblPanel
            // 
            this.lblPanel.AutoSize = true;
            this.lblPanel.Location = new System.Drawing.Point(12, 22);
            this.lblPanel.Name = "lblPanel";
            this.lblPanel.Size = new System.Drawing.Size(39, 13);
            this.lblPanel.TabIndex = 6;
            this.lblPanel.Text = "sPanel";
            // 
            // txtPanel
            // 
            this.txtPanel.Enabled = false;
            this.txtPanel.Location = new System.Drawing.Point(101, 19);
            this.txtPanel.MaxLength = 3;
            this.txtPanel.Name = "txtPanel";
            this.txtPanel.Size = new System.Drawing.Size(153, 20);
            this.txtPanel.TabIndex = 7;
            this.txtPanel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboCoolerType
            // 
            this.cboCoolerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCoolerType.FormattingEnabled = true;
            this.cboCoolerType.Location = new System.Drawing.Point(101, 58);
            this.cboCoolerType.Name = "cboCoolerType";
            this.cboCoolerType.Size = new System.Drawing.Size(153, 21);
            this.cboCoolerType.TabIndex = 8;
            this.cboCoolerType.SelectedIndexChanged += new System.EventHandler(this.cboCoolerType_SelectedIndexChanged);
            // 
            // lblCoolerType
            // 
            this.lblCoolerType.AutoSize = true;
            this.lblCoolerType.Location = new System.Drawing.Point(12, 61);
            this.lblCoolerType.Name = "lblCoolerType";
            this.lblCoolerType.Size = new System.Drawing.Size(69, 13);
            this.lblCoolerType.TabIndex = 9;
            this.lblCoolerType.Text = "sCooler Type";
            // 
            // numMinFanWide
            // 
            this.numMinFanWide.Location = new System.Drawing.Point(101, 98);
            this.numMinFanWide.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numMinFanWide.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinFanWide.Name = "numMinFanWide";
            this.numMinFanWide.Size = new System.Drawing.Size(58, 20);
            this.numMinFanWide.TabIndex = 10;
            this.numMinFanWide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numMinFanWide.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numMaxFanWide
            // 
            this.numMaxFanWide.Location = new System.Drawing.Point(196, 98);
            this.numMaxFanWide.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numMaxFanWide.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxFanWide.Name = "numMaxFanWide";
            this.numMaxFanWide.Size = new System.Drawing.Size(58, 20);
            this.numMaxFanWide.TabIndex = 11;
            this.numMaxFanWide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numMaxFanWide.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblFanWideTo
            // 
            this.lblFanWideTo.AutoSize = true;
            this.lblFanWideTo.Location = new System.Drawing.Point(165, 100);
            this.lblFanWideTo.Name = "lblFanWideTo";
            this.lblFanWideTo.Size = new System.Drawing.Size(25, 13);
            this.lblFanWideTo.TabIndex = 12;
            this.lblFanWideTo.Text = "sTo";
            // 
            // lblFanWide
            // 
            this.lblFanWide.AutoSize = true;
            this.lblFanWide.Location = new System.Drawing.Point(12, 100);
            this.lblFanWide.Name = "lblFanWide";
            this.lblFanWide.Size = new System.Drawing.Size(58, 13);
            this.lblFanWide.TabIndex = 13;
            this.lblFanWide.Text = "sFan Wide";
            // 
            // lblCircuit
            // 
            this.lblCircuit.AutoSize = true;
            this.lblCircuit.Location = new System.Drawing.Point(12, 139);
            this.lblCircuit.Name = "lblCircuit";
            this.lblCircuit.Size = new System.Drawing.Size(41, 13);
            this.lblCircuit.TabIndex = 17;
            this.lblCircuit.Text = "sCircuit";
            // 
            // lblCircuitTo
            // 
            this.lblCircuitTo.AutoSize = true;
            this.lblCircuitTo.Location = new System.Drawing.Point(165, 139);
            this.lblCircuitTo.Name = "lblCircuitTo";
            this.lblCircuitTo.Size = new System.Drawing.Size(25, 13);
            this.lblCircuitTo.TabIndex = 16;
            this.lblCircuitTo.Text = "sTo";
            // 
            // numMaxCircuit
            // 
            this.numMaxCircuit.Location = new System.Drawing.Point(196, 137);
            this.numMaxCircuit.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMaxCircuit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxCircuit.Name = "numMaxCircuit";
            this.numMaxCircuit.Size = new System.Drawing.Size(58, 20);
            this.numMaxCircuit.TabIndex = 15;
            this.numMaxCircuit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numMaxCircuit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numMinCircuit
            // 
            this.numMinCircuit.Location = new System.Drawing.Point(101, 137);
            this.numMinCircuit.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMinCircuit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinCircuit.Name = "numMinCircuit";
            this.numMinCircuit.Size = new System.Drawing.Size(58, 20);
            this.numMinCircuit.TabIndex = 14;
            this.numMinCircuit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numMinCircuit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblEqualCapacity
            // 
            this.lblEqualCapacity.AutoSize = true;
            this.lblEqualCapacity.Location = new System.Drawing.Point(12, 179);
            this.lblEqualCapacity.Name = "lblEqualCapacity";
            this.lblEqualCapacity.Size = new System.Drawing.Size(83, 13);
            this.lblEqualCapacity.TabIndex = 19;
            this.lblEqualCapacity.Text = "sEqual Capacity";
            // 
            // cboEqualCapacity
            // 
            this.cboEqualCapacity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEqualCapacity.FormattingEnabled = true;
            this.cboEqualCapacity.Location = new System.Drawing.Point(101, 176);
            this.cboEqualCapacity.Name = "cboEqualCapacity";
            this.cboEqualCapacity.Size = new System.Drawing.Size(153, 21);
            this.cboEqualCapacity.TabIndex = 18;
            // 
            // lvSeries
            // 
            this.lvSeries.AllowColumnResize = false;
            this.lvSeries.AllowMultiselect = false;
            this.lvSeries.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvSeries.AlternatingColors = false;
            this.lvSeries.AutoHeight = true;
            this.lvSeries.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvSeries.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = true;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1";
            glColumn1.NumericSort = false;
            glColumn1.Text = "";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn1.Width = 30;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column1x";
            glColumn2.NumericSort = false;
            glColumn2.Text = "sSerie";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 410;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Column1xx";
            glColumn3.NumericSort = false;
            glColumn3.Text = "";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 0;
            this.lvSeries.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3});
            this.lvSeries.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvSeries.FullRowSelect = true;
            this.lvSeries.GridColor = System.Drawing.Color.LightGray;
            this.lvSeries.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvSeries.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvSeries.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvSeries.HeaderHeight = 22;
            this.lvSeries.HeaderVisible = true;
            this.lvSeries.HeaderWordWrap = false;
            this.lvSeries.HotColumnTracking = false;
            this.lvSeries.HotItemTracking = false;
            this.lvSeries.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvSeries.HoverEvents = false;
            this.lvSeries.HoverTime = 1;
            this.lvSeries.ImageList = null;
            this.lvSeries.ItemHeight = 17;
            this.lvSeries.ItemWordWrap = false;
            this.lvSeries.Location = new System.Drawing.Point(260, 37);
            this.lvSeries.Name = "lvSeries";
            this.lvSeries.Selectable = true;
            this.lvSeries.SelectedTextColor = System.Drawing.Color.White;
            this.lvSeries.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvSeries.ShowBorder = true;
            this.lvSeries.ShowFocusRect = false;
            this.lvSeries.Size = new System.Drawing.Size(466, 305);
            this.lvSeries.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lvSeries.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvSeries.TabIndex = 162;
            this.lvSeries.Text = "glacialList1";
            // 
            // cmdSeriePickAll
            // 
            this.cmdSeriePickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdSeriePickAll.Image")));
            this.cmdSeriePickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSeriePickAll.Location = new System.Drawing.Point(260, 12);
            this.cmdSeriePickAll.Name = "cmdSeriePickAll";
            this.cmdSeriePickAll.Size = new System.Drawing.Size(466, 23);
            this.cmdSeriePickAll.TabIndex = 163;
            this.cmdSeriePickAll.Text = "sPick All";
            this.cmdSeriePickAll.UseVisualStyleBackColor = true;
            this.cmdSeriePickAll.Click += new System.EventHandler(this.cmdSeriePickAll_Click);
            // 
            // cmdSerieUnpickAll
            // 
            this.cmdSerieUnpickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdSerieUnpickAll.Image")));
            this.cmdSerieUnpickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSerieUnpickAll.Location = new System.Drawing.Point(260, 348);
            this.cmdSerieUnpickAll.Name = "cmdSerieUnpickAll";
            this.cmdSerieUnpickAll.Size = new System.Drawing.Size(466, 23);
            this.cmdSerieUnpickAll.TabIndex = 164;
            this.cmdSerieUnpickAll.Text = "sUnpick All";
            this.cmdSerieUnpickAll.UseVisualStyleBackColor = true;
            this.cmdSerieUnpickAll.Click += new System.EventHandler(this.cmdSerieUnpickAll_Click);
            // 
            // lvPanelVoltage
            // 
            this.lvPanelVoltage.AllowColumnResize = false;
            this.lvPanelVoltage.AllowMultiselect = false;
            this.lvPanelVoltage.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvPanelVoltage.AlternatingColors = false;
            this.lvPanelVoltage.AutoHeight = true;
            this.lvPanelVoltage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvPanelVoltage.BackgroundStretchToFit = true;
            glColumn4.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn4.CheckBoxes = true;
            glColumn4.DatetimeSort = false;
            glColumn4.ImageIndex = -1;
            glColumn4.Name = "Column1";
            glColumn4.NumericSort = false;
            glColumn4.Text = "";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn4.Width = 30;
            glColumn5.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn5.CheckBoxes = false;
            glColumn5.DatetimeSort = false;
            glColumn5.ImageIndex = -1;
            glColumn5.Name = "Column1x";
            glColumn5.NumericSort = false;
            glColumn5.Text = "sVoltage";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn5.Width = 175;
            glColumn6.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn6.CheckBoxes = false;
            glColumn6.DatetimeSort = false;
            glColumn6.ImageIndex = -1;
            glColumn6.Name = "Column1xx";
            glColumn6.NumericSort = false;
            glColumn6.Text = "";
            glColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn6.Width = 0;
            this.lvPanelVoltage.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn4,
            glColumn5,
            glColumn6});
            this.lvPanelVoltage.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvPanelVoltage.FullRowSelect = true;
            this.lvPanelVoltage.GridColor = System.Drawing.Color.LightGray;
            this.lvPanelVoltage.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvPanelVoltage.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvPanelVoltage.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvPanelVoltage.HeaderHeight = 22;
            this.lvPanelVoltage.HeaderVisible = true;
            this.lvPanelVoltage.HeaderWordWrap = false;
            this.lvPanelVoltage.HotColumnTracking = false;
            this.lvPanelVoltage.HotItemTracking = false;
            this.lvPanelVoltage.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvPanelVoltage.HoverEvents = false;
            this.lvPanelVoltage.HoverTime = 1;
            this.lvPanelVoltage.ImageList = null;
            this.lvPanelVoltage.ItemHeight = 17;
            this.lvPanelVoltage.ItemWordWrap = false;
            this.lvPanelVoltage.Location = new System.Drawing.Point(15, 241);
            this.lvPanelVoltage.Name = "lvPanelVoltage";
            this.lvPanelVoltage.Selectable = true;
            this.lvPanelVoltage.SelectedTextColor = System.Drawing.Color.White;
            this.lvPanelVoltage.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvPanelVoltage.ShowBorder = true;
            this.lvPanelVoltage.ShowFocusRect = false;
            this.lvPanelVoltage.Size = new System.Drawing.Size(239, 102);
            this.lvPanelVoltage.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lvPanelVoltage.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvPanelVoltage.TabIndex = 165;
            this.lvPanelVoltage.Text = "glacialList1";
            // 
            // cmdVoltagePickAll
            // 
            this.cmdVoltagePickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdVoltagePickAll.Image")));
            this.cmdVoltagePickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdVoltagePickAll.Location = new System.Drawing.Point(15, 214);
            this.cmdVoltagePickAll.Name = "cmdVoltagePickAll";
            this.cmdVoltagePickAll.Size = new System.Drawing.Size(239, 23);
            this.cmdVoltagePickAll.TabIndex = 166;
            this.cmdVoltagePickAll.Text = "sPick All";
            this.cmdVoltagePickAll.UseVisualStyleBackColor = true;
            this.cmdVoltagePickAll.Click += new System.EventHandler(this.cmdVoltagePickAll_Click);
            // 
            // cmdVoltageUnpickAll
            // 
            this.cmdVoltageUnpickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdVoltageUnpickAll.Image")));
            this.cmdVoltageUnpickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdVoltageUnpickAll.Location = new System.Drawing.Point(15, 348);
            this.cmdVoltageUnpickAll.Name = "cmdVoltageUnpickAll";
            this.cmdVoltageUnpickAll.Size = new System.Drawing.Size(239, 23);
            this.cmdVoltageUnpickAll.TabIndex = 167;
            this.cmdVoltageUnpickAll.Text = "sUnpick All";
            this.cmdVoltageUnpickAll.UseVisualStyleBackColor = true;
            this.cmdVoltageUnpickAll.Click += new System.EventHandler(this.cmdVoltageUnpickAll_Click);
            // 
            // frmAddEditPanelLogic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(738, 412);
            this.Controls.Add(this.cmdVoltagePickAll);
            this.Controls.Add(this.cmdVoltageUnpickAll);
            this.Controls.Add(this.lvPanelVoltage);
            this.Controls.Add(this.cmdSeriePickAll);
            this.Controls.Add(this.cmdSerieUnpickAll);
            this.Controls.Add(this.lvSeries);
            this.Controls.Add(this.lblEqualCapacity);
            this.Controls.Add(this.cboEqualCapacity);
            this.Controls.Add(this.lblCircuit);
            this.Controls.Add(this.lblCircuitTo);
            this.Controls.Add(this.numMaxCircuit);
            this.Controls.Add(this.numMinCircuit);
            this.Controls.Add(this.lblFanWide);
            this.Controls.Add(this.lblFanWideTo);
            this.Controls.Add(this.numMaxFanWide);
            this.Controls.Add(this.numMinFanWide);
            this.Controls.Add(this.lblCoolerType);
            this.Controls.Add(this.cboCoolerType);
            this.Controls.Add(this.txtPanel);
            this.Controls.Add(this.lblPanel);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddEditPanelLogic";
            this.Text = "sAdd / Edit Panel Logic";
            this.Load += new System.EventHandler(this.frmAddEditPanelLogic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numMinFanWide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxFanWide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxCircuit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinCircuit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label lblPanel;
        private System.Windows.Forms.TextBox txtPanel;
        private System.Windows.Forms.ComboBox cboCoolerType;
        private System.Windows.Forms.Label lblCoolerType;
        private System.Windows.Forms.NumericUpDown numMinFanWide;
        private System.Windows.Forms.NumericUpDown numMaxFanWide;
        private System.Windows.Forms.Label lblFanWideTo;
        private System.Windows.Forms.Label lblFanWide;
        private System.Windows.Forms.Label lblCircuit;
        private System.Windows.Forms.Label lblCircuitTo;
        private System.Windows.Forms.NumericUpDown numMaxCircuit;
        private System.Windows.Forms.NumericUpDown numMinCircuit;
        private System.Windows.Forms.Label lblEqualCapacity;
        private System.Windows.Forms.ComboBox cboEqualCapacity;
        private GlacialComponents.Controls.GlacialList lvSeries;
        private System.Windows.Forms.Button cmdSeriePickAll;
        private System.Windows.Forms.Button cmdSerieUnpickAll;
        private GlacialComponents.Controls.GlacialList lvPanelVoltage;
        private System.Windows.Forms.Button cmdVoltagePickAll;
        private System.Windows.Forms.Button cmdVoltageUnpickAll;
    }
}