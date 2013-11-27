namespace RefplusWebtools.DataManager.ControlPanel
{
    partial class FrmAddEditOptionLogic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddEditOptionLogic));
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            this.cmdSeriePickAll = new System.Windows.Forms.Button();
            this.cmdSerieUnpickAll = new System.Windows.Forms.Button();
            this.lvSeries = new GlacialComponents.Controls.GlacialList();
            this.lblFanWide = new System.Windows.Forms.Label();
            this.lblFanWideTo = new System.Windows.Forms.Label();
            this.numMaxFanWide = new System.Windows.Forms.NumericUpDown();
            this.numMinFanWide = new System.Windows.Forms.NumericUpDown();
            this.lblCoolerType = new System.Windows.Forms.Label();
            this.cboCoolerType = new System.Windows.Forms.ComboBox();
            this.txtOption = new System.Windows.Forms.TextBox();
            this.lblOption = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxFanWide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinFanWide)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdSeriePickAll
            // 
            this.cmdSeriePickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdSeriePickAll.Image")));
            this.cmdSeriePickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSeriePickAll.Location = new System.Drawing.Point(260, 12);
            this.cmdSeriePickAll.Name = "cmdSeriePickAll";
            this.cmdSeriePickAll.Size = new System.Drawing.Size(466, 23);
            this.cmdSeriePickAll.TabIndex = 180;
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
            this.cmdSerieUnpickAll.TabIndex = 181;
            this.cmdSerieUnpickAll.Text = "sUnpick All";
            this.cmdSerieUnpickAll.UseVisualStyleBackColor = true;
            this.cmdSerieUnpickAll.Click += new System.EventHandler(this.cmdSerieUnpickAll_Click);
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
            this.lvSeries.TabIndex = 179;
            this.lvSeries.Text = "glacialList1";
            // 
            // lblFanWide
            // 
            this.lblFanWide.AutoSize = true;
            this.lblFanWide.Location = new System.Drawing.Point(12, 100);
            this.lblFanWide.Name = "lblFanWide";
            this.lblFanWide.Size = new System.Drawing.Size(58, 13);
            this.lblFanWide.TabIndex = 174;
            this.lblFanWide.Text = "sFan Wide";
            // 
            // lblFanWideTo
            // 
            this.lblFanWideTo.AutoSize = true;
            this.lblFanWideTo.Location = new System.Drawing.Point(165, 100);
            this.lblFanWideTo.Name = "lblFanWideTo";
            this.lblFanWideTo.Size = new System.Drawing.Size(25, 13);
            this.lblFanWideTo.TabIndex = 173;
            this.lblFanWideTo.Text = "sTo";
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
            this.numMaxFanWide.TabIndex = 172;
            this.numMaxFanWide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numMaxFanWide.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.numMinFanWide.TabIndex = 171;
            this.numMinFanWide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numMinFanWide.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCoolerType
            // 
            this.lblCoolerType.AutoSize = true;
            this.lblCoolerType.Location = new System.Drawing.Point(12, 61);
            this.lblCoolerType.Name = "lblCoolerType";
            this.lblCoolerType.Size = new System.Drawing.Size(69, 13);
            this.lblCoolerType.TabIndex = 170;
            this.lblCoolerType.Text = "sCooler Type";
            // 
            // cboCoolerType
            // 
            this.cboCoolerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCoolerType.FormattingEnabled = true;
            this.cboCoolerType.Location = new System.Drawing.Point(101, 58);
            this.cboCoolerType.Name = "cboCoolerType";
            this.cboCoolerType.Size = new System.Drawing.Size(153, 21);
            this.cboCoolerType.TabIndex = 169;
            this.cboCoolerType.SelectedIndexChanged += new System.EventHandler(this.cboCoolerType_SelectedIndexChanged);
            // 
            // txtOption
            // 
            this.txtOption.Enabled = false;
            this.txtOption.Location = new System.Drawing.Point(101, 19);
            this.txtOption.MaxLength = 1;
            this.txtOption.Name = "txtOption";
            this.txtOption.Size = new System.Drawing.Size(153, 20);
            this.txtOption.TabIndex = 168;
            this.txtOption.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblOption
            // 
            this.lblOption.AutoSize = true;
            this.lblOption.Location = new System.Drawing.Point(12, 22);
            this.lblOption.Name = "lblOption";
            this.lblOption.Size = new System.Drawing.Size(43, 13);
            this.lblOption.TabIndex = 167;
            this.lblOption.Text = "sOption";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(487, 377);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(239, 26);
            this.cmdCancel.TabIndex = 166;
            this.cmdCancel.Text = "sCancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(15, 377);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(239, 26);
            this.cmdSave.TabIndex = 165;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // frmAddEditOptionLogic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(738, 412);
            this.Controls.Add(this.cmdSeriePickAll);
            this.Controls.Add(this.cmdSerieUnpickAll);
            this.Controls.Add(this.lvSeries);
            this.Controls.Add(this.lblFanWide);
            this.Controls.Add(this.lblFanWideTo);
            this.Controls.Add(this.numMaxFanWide);
            this.Controls.Add(this.numMinFanWide);
            this.Controls.Add(this.lblCoolerType);
            this.Controls.Add(this.cboCoolerType);
            this.Controls.Add(this.txtOption);
            this.Controls.Add(this.lblOption);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddEditOptionLogic";
            this.Text = "sAdd / Edit Option Logic";
            this.Load += new System.EventHandler(this.frmAddEditOptionLogic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numMaxFanWide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinFanWide)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSeriePickAll;
        private System.Windows.Forms.Button cmdSerieUnpickAll;
        private GlacialComponents.Controls.GlacialList lvSeries;
        private System.Windows.Forms.Label lblFanWide;
        private System.Windows.Forms.Label lblFanWideTo;
        private System.Windows.Forms.NumericUpDown numMaxFanWide;
        private System.Windows.Forms.NumericUpDown numMinFanWide;
        private System.Windows.Forms.Label lblCoolerType;
        private System.Windows.Forms.ComboBox cboCoolerType;
        private System.Windows.Forms.TextBox txtOption;
        private System.Windows.Forms.Label lblOption;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdSave;
    }
}