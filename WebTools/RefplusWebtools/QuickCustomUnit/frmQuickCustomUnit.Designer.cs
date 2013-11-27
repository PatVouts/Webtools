namespace RefplusWebtools.QuickCustomUnit
{
    partial class FrmQuickCustomUnit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQuickCustomUnit));
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn4 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn5 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn6 = new GlacialComponents.Controls.GLColumn();
            this.lblLeftColumn = new System.Windows.Forms.Label();
            this.lblRightColumn = new System.Windows.Forms.Label();
            this.cmdLeftMoveUp = new System.Windows.Forms.Button();
            this.cmdRightMoveUp = new System.Windows.Forms.Button();
            this.cmdLeftMoveDown = new System.Windows.Forms.Button();
            this.cmdRightMoveDown = new System.Windows.Forms.Button();
            this.lblText = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cboColumn = new System.Windows.Forms.ComboBox();
            this.lblColumn = new System.Windows.Forms.Label();
            this.grpAddItem = new System.Windows.Forms.GroupBox();
            this.cboText = new System.Windows.Forms.ComboBox();
            this.lblDelete = new System.Windows.Forms.Label();
            this.grpAddBlankLine = new System.Windows.Forms.GroupBox();
            this.lblBlankColumn = new System.Windows.Forms.Label();
            this.cboBlankColumn = new System.Windows.Forms.ComboBox();
            this.cmdBlankAdd = new System.Windows.Forms.Button();
            this.cmdGenerateReport = new System.Windows.Forms.Button();
            this.lvLeft = new GlacialComponents.Controls.GlacialList();
            this.lvRight = new GlacialComponents.Controls.GlacialList();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.lblTag = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdTemplate = new System.Windows.Forms.ToolStripDropDownButton();
            this.sLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sSaveAsNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPrice = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.btnHelp = new System.Windows.Forms.Button();
            this.grpFullCustom = new System.Windows.Forms.GroupBox();
            this.grpAddItem.SuspendLayout();
            this.grpAddBlankLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            this.grpFullCustom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLeftColumn
            // 
            this.lblLeftColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeftColumn.Location = new System.Drawing.Point(5, 17);
            this.lblLeftColumn.Name = "lblLeftColumn";
            this.lblLeftColumn.Size = new System.Drawing.Size(380, 20);
            this.lblLeftColumn.TabIndex = 17;
            this.lblLeftColumn.Text = "sLeft Column";
            this.lblLeftColumn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRightColumn
            // 
            this.lblRightColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRightColumn.Location = new System.Drawing.Point(391, 17);
            this.lblRightColumn.Name = "lblRightColumn";
            this.lblRightColumn.Size = new System.Drawing.Size(380, 20);
            this.lblRightColumn.TabIndex = 18;
            this.lblRightColumn.Text = "sRight Column";
            this.lblRightColumn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdLeftMoveUp
            // 
            this.cmdLeftMoveUp.Image = ((System.Drawing.Image)(resources.GetObject("cmdLeftMoveUp.Image")));
            this.cmdLeftMoveUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLeftMoveUp.Location = new System.Drawing.Point(5, 294);
            this.cmdLeftMoveUp.Name = "cmdLeftMoveUp";
            this.cmdLeftMoveUp.Size = new System.Drawing.Size(190, 25);
            this.cmdLeftMoveUp.TabIndex = 4;
            this.cmdLeftMoveUp.Text = "sMove Up";
            this.cmdLeftMoveUp.UseVisualStyleBackColor = true;
            this.cmdLeftMoveUp.Click += new System.EventHandler(this.cmdLeftMoveUp_Click);
            // 
            // cmdRightMoveUp
            // 
            this.cmdRightMoveUp.Image = ((System.Drawing.Image)(resources.GetObject("cmdRightMoveUp.Image")));
            this.cmdRightMoveUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRightMoveUp.Location = new System.Drawing.Point(391, 294);
            this.cmdRightMoveUp.Name = "cmdRightMoveUp";
            this.cmdRightMoveUp.Size = new System.Drawing.Size(190, 25);
            this.cmdRightMoveUp.TabIndex = 7;
            this.cmdRightMoveUp.Text = "sMove Up";
            this.cmdRightMoveUp.UseVisualStyleBackColor = true;
            this.cmdRightMoveUp.Click += new System.EventHandler(this.cmdRightMoveUp_Click);
            // 
            // cmdLeftMoveDown
            // 
            this.cmdLeftMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("cmdLeftMoveDown.Image")));
            this.cmdLeftMoveDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLeftMoveDown.Location = new System.Drawing.Point(195, 294);
            this.cmdLeftMoveDown.Name = "cmdLeftMoveDown";
            this.cmdLeftMoveDown.Size = new System.Drawing.Size(190, 25);
            this.cmdLeftMoveDown.TabIndex = 5;
            this.cmdLeftMoveDown.Text = "sMove Down";
            this.cmdLeftMoveDown.UseVisualStyleBackColor = true;
            this.cmdLeftMoveDown.Click += new System.EventHandler(this.cmdLeftMoveDown_Click);
            // 
            // cmdRightMoveDown
            // 
            this.cmdRightMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("cmdRightMoveDown.Image")));
            this.cmdRightMoveDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRightMoveDown.Location = new System.Drawing.Point(581, 294);
            this.cmdRightMoveDown.Name = "cmdRightMoveDown";
            this.cmdRightMoveDown.Size = new System.Drawing.Size(190, 25);
            this.cmdRightMoveDown.TabIndex = 8;
            this.cmdRightMoveDown.Text = "sMove Down";
            this.cmdRightMoveDown.UseVisualStyleBackColor = true;
            this.cmdRightMoveDown.Click += new System.EventHandler(this.cmdRightMoveDown_Click);
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(6, 16);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(33, 13);
            this.lblText.TabIndex = 23;
            this.lblText.Text = "sText";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(263, 32);
            this.txtValue.MaxLength = 75;
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(90, 20);
            this.txtValue.TabIndex = 1;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(260, 16);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(39, 13);
            this.lblValue.TabIndex = 25;
            this.lblValue.Text = "sValue";
            // 
            // cboUnit
            // 
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(359, 32);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(94, 21);
            this.cboUnit.TabIndex = 2;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(356, 16);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(31, 13);
            this.lblUnit.TabIndex = 28;
            this.lblUnit.Text = "sUnit";
            // 
            // cmdAdd
            // 
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(459, 59);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(138, 25);
            this.cmdAdd.TabIndex = 4;
            this.cmdAdd.Text = "sAdd";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cboColumn
            // 
            this.cboColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColumn.FormattingEnabled = true;
            this.cboColumn.Items.AddRange(new object[] {
            "LEFT COLUMN",
            "RIGHT COLUMN"});
            this.cboColumn.Location = new System.Drawing.Point(459, 32);
            this.cboColumn.Name = "cboColumn";
            this.cboColumn.Size = new System.Drawing.Size(138, 21);
            this.cboColumn.TabIndex = 3;
            // 
            // lblColumn
            // 
            this.lblColumn.AutoSize = true;
            this.lblColumn.Location = new System.Drawing.Point(456, 16);
            this.lblColumn.Name = "lblColumn";
            this.lblColumn.Size = new System.Drawing.Size(47, 13);
            this.lblColumn.TabIndex = 31;
            this.lblColumn.Text = "sColumn";
            // 
            // grpAddItem
            // 
            this.grpAddItem.Controls.Add(this.cboText);
            this.grpAddItem.Controls.Add(this.lblDelete);
            this.grpAddItem.Controls.Add(this.lblColumn);
            this.grpAddItem.Controls.Add(this.lblText);
            this.grpAddItem.Controls.Add(this.cboColumn);
            this.grpAddItem.Controls.Add(this.lblValue);
            this.grpAddItem.Controls.Add(this.cmdAdd);
            this.grpAddItem.Controls.Add(this.txtValue);
            this.grpAddItem.Controls.Add(this.lblUnit);
            this.grpAddItem.Controls.Add(this.cboUnit);
            this.grpAddItem.Location = new System.Drawing.Point(5, 325);
            this.grpAddItem.Name = "grpAddItem";
            this.grpAddItem.Size = new System.Drawing.Size(605, 91);
            this.grpAddItem.TabIndex = 9;
            this.grpAddItem.TabStop = false;
            this.grpAddItem.Text = "sAdd Item";
            // 
            // cboText
            // 
            this.cboText.FormattingEnabled = true;
            this.cboText.Location = new System.Drawing.Point(4, 32);
            this.cboText.Name = "cboText";
            this.cboText.Size = new System.Drawing.Size(253, 21);
            this.cboText.TabIndex = 0;
            // 
            // lblDelete
            // 
            this.lblDelete.AutoSize = true;
            this.lblDelete.ForeColor = System.Drawing.Color.Black;
            this.lblDelete.Location = new System.Drawing.Point(6, 65);
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.Size = new System.Drawing.Size(326, 13);
            this.lblDelete.TabIndex = 32;
            this.lblDelete.Text = "sTo delete an item, select it and hit the key delete on your keyboard";
            // 
            // grpAddBlankLine
            // 
            this.grpAddBlankLine.Controls.Add(this.lblBlankColumn);
            this.grpAddBlankLine.Controls.Add(this.cboBlankColumn);
            this.grpAddBlankLine.Controls.Add(this.cmdBlankAdd);
            this.grpAddBlankLine.Location = new System.Drawing.Point(616, 324);
            this.grpAddBlankLine.Name = "grpAddBlankLine";
            this.grpAddBlankLine.Size = new System.Drawing.Size(155, 91);
            this.grpAddBlankLine.TabIndex = 11;
            this.grpAddBlankLine.TabStop = false;
            this.grpAddBlankLine.Text = "sAdd Blank Line";
            // 
            // lblBlankColumn
            // 
            this.lblBlankColumn.AutoSize = true;
            this.lblBlankColumn.Location = new System.Drawing.Point(6, 16);
            this.lblBlankColumn.Name = "lblBlankColumn";
            this.lblBlankColumn.Size = new System.Drawing.Size(47, 13);
            this.lblBlankColumn.TabIndex = 31;
            this.lblBlankColumn.Text = "sColumn";
            // 
            // cboBlankColumn
            // 
            this.cboBlankColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBlankColumn.FormattingEnabled = true;
            this.cboBlankColumn.Items.AddRange(new object[] {
            "LEFT COLUMN",
            "RIGHT COLUMN"});
            this.cboBlankColumn.Location = new System.Drawing.Point(9, 32);
            this.cboBlankColumn.Name = "cboBlankColumn";
            this.cboBlankColumn.Size = new System.Drawing.Size(139, 21);
            this.cboBlankColumn.TabIndex = 0;
            // 
            // cmdBlankAdd
            // 
            this.cmdBlankAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdBlankAdd.Image")));
            this.cmdBlankAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBlankAdd.Location = new System.Drawing.Point(9, 60);
            this.cmdBlankAdd.Name = "cmdBlankAdd";
            this.cmdBlankAdd.Size = new System.Drawing.Size(139, 25);
            this.cmdBlankAdd.TabIndex = 1;
            this.cmdBlankAdd.Text = "sAdd";
            this.cmdBlankAdd.UseVisualStyleBackColor = true;
            this.cmdBlankAdd.Click += new System.EventHandler(this.cmdBlankAdd_Click);
            // 
            // cmdGenerateReport
            // 
            this.cmdGenerateReport.Image = ((System.Drawing.Image)(resources.GetObject("cmdGenerateReport.Image")));
            this.cmdGenerateReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGenerateReport.Location = new System.Drawing.Point(623, 530);
            this.cmdGenerateReport.Name = "cmdGenerateReport";
            this.cmdGenerateReport.Size = new System.Drawing.Size(139, 27);
            this.cmdGenerateReport.TabIndex = 13;
            this.cmdGenerateReport.Text = "sGenerate Report";
            this.cmdGenerateReport.UseVisualStyleBackColor = true;
            this.cmdGenerateReport.Click += new System.EventHandler(this.cmdGenerateReport_Click);
            // 
            // lvLeft
            // 
            this.lvLeft.AllowColumnResize = false;
            this.lvLeft.AllowMultiselect = false;
            this.lvLeft.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvLeft.AlternatingColors = false;
            this.lvLeft.AutoHeight = false;
            this.lvLeft.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvLeft.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.TextBox;
            glColumn1.CheckBoxes = false;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "colText";
            glColumn1.NumericSort = false;
            glColumn1.Text = "Text";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn1.Width = 189;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.TextBox;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "colValue";
            glColumn2.NumericSort = false;
            glColumn2.Text = "Value";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn2.Width = 89;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.TextBox;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "colUnit";
            glColumn3.NumericSort = false;
            glColumn3.Text = "Unit";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn3.Width = 95;
            this.lvLeft.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3});
            this.lvLeft.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvLeft.FullRowSelect = true;
            this.lvLeft.GridColor = System.Drawing.Color.LightGray;
            this.lvLeft.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvLeft.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvLeft.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvLeft.HeaderHeight = 22;
            this.lvLeft.HeaderVisible = true;
            this.lvLeft.HeaderWordWrap = false;
            this.lvLeft.HotColumnTracking = false;
            this.lvLeft.HotItemTracking = false;
            this.lvLeft.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvLeft.HoverEvents = false;
            this.lvLeft.HoverTime = 1;
            this.lvLeft.ImageList = null;
            this.lvLeft.ItemHeight = 25;
            this.lvLeft.ItemWordWrap = false;
            this.lvLeft.Location = new System.Drawing.Point(5, 38);
            this.lvLeft.Name = "lvLeft";
            this.lvLeft.Selectable = true;
            this.lvLeft.SelectedTextColor = System.Drawing.Color.White;
            this.lvLeft.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvLeft.ShowBorder = true;
            this.lvLeft.ShowFocusRect = true;
            this.lvLeft.Size = new System.Drawing.Size(380, 255);
            this.lvLeft.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lvLeft.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvLeft.TabIndex = 3;
            this.lvLeft.Text = "glacialList1";
            this.lvLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvLeft_KeyDown);
            // 
            // lvRight
            // 
            this.lvRight.AllowColumnResize = false;
            this.lvRight.AllowMultiselect = false;
            this.lvRight.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvRight.AlternatingColors = false;
            this.lvRight.AutoHeight = false;
            this.lvRight.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvRight.BackgroundStretchToFit = true;
            glColumn4.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.TextBox;
            glColumn4.CheckBoxes = false;
            glColumn4.DatetimeSort = false;
            glColumn4.ImageIndex = -1;
            glColumn4.Name = "colText";
            glColumn4.NumericSort = false;
            glColumn4.Text = "Text";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn4.Width = 189;
            glColumn5.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.TextBox;
            glColumn5.CheckBoxes = false;
            glColumn5.DatetimeSort = false;
            glColumn5.ImageIndex = -1;
            glColumn5.Name = "colValue";
            glColumn5.NumericSort = false;
            glColumn5.Text = "Value";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn5.Width = 89;
            glColumn6.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.TextBox;
            glColumn6.CheckBoxes = false;
            glColumn6.DatetimeSort = false;
            glColumn6.ImageIndex = -1;
            glColumn6.Name = "colUnit";
            glColumn6.NumericSort = false;
            glColumn6.Text = "Unit";
            glColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn6.Width = 95;
            this.lvRight.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn4,
            glColumn5,
            glColumn6});
            this.lvRight.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvRight.FullRowSelect = true;
            this.lvRight.GridColor = System.Drawing.Color.LightGray;
            this.lvRight.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvRight.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvRight.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvRight.HeaderHeight = 22;
            this.lvRight.HeaderVisible = true;
            this.lvRight.HeaderWordWrap = false;
            this.lvRight.HotColumnTracking = false;
            this.lvRight.HotItemTracking = false;
            this.lvRight.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvRight.HoverEvents = false;
            this.lvRight.HoverTime = 1;
            this.lvRight.ImageList = null;
            this.lvRight.ItemHeight = 25;
            this.lvRight.ItemWordWrap = false;
            this.lvRight.Location = new System.Drawing.Point(391, 38);
            this.lvRight.Name = "lvRight";
            this.lvRight.Selectable = true;
            this.lvRight.SelectedTextColor = System.Drawing.Color.White;
            this.lvRight.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvRight.ShowBorder = true;
            this.lvRight.ShowFocusRect = true;
            this.lvRight.Size = new System.Drawing.Size(380, 255);
            this.lvRight.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lvRight.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvRight.TabIndex = 6;
            this.lvRight.Text = "glacialList1";
            this.lvRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvRight_KeyDown);
            // 
            // cmdAccept
            // 
            this.cmdAccept.Image = ((System.Drawing.Image)(resources.GetObject("cmdAccept.Image")));
            this.cmdAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAccept.Location = new System.Drawing.Point(7, 563);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(139, 25);
            this.cmdAccept.TabIndex = 12;
            this.cmdAccept.Text = "sAccept";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(623, 563);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(139, 25);
            this.cmdCancel.TabIndex = 14;
            this.cmdCancel.Text = "sCancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(111, 60);
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(50, 20);
            this.numQuantity.TabIndex = 1;
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
            this.lblQuantity.Location = new System.Drawing.Point(43, 62);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(51, 13);
            this.lblQuantity.TabIndex = 111;
            this.lblQuantity.Text = "sQuantity";
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(111, 38);
            this.txtTag.MaxLength = 50;
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(593, 20);
            this.txtTag.TabIndex = 0;
            this.txtTag.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblTag
            // 
            this.lblTag.AutoSize = true;
            this.lblTag.Location = new System.Drawing.Point(43, 41);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(31, 13);
            this.lblTag.TabIndex = 110;
            this.lblTag.Text = "sTag";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(171, 63);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(65, 13);
            this.lblModel.TabIndex = 116;
            this.lblModel.Text = "sModel Text";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(263, 60);
            this.txtModel.MaxLength = 75;
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(225, 20);
            this.txtModel.TabIndex = 2;
            this.txtModel.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(211)))), ((int)(((byte)(233)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdTemplate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(804, 25);
            this.toolStrip1.TabIndex = 118;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cmdTemplate
            // 
            this.cmdTemplate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdTemplate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sLoadToolStripMenuItem,
            this.sSaveToolStripMenuItem,
            this.sSaveAsNewToolStripMenuItem});
            this.cmdTemplate.Image = ((System.Drawing.Image)(resources.GetObject("cmdTemplate.Image")));
            this.cmdTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdTemplate.Name = "cmdTemplate";
            this.cmdTemplate.Size = new System.Drawing.Size(75, 22);
            this.cmdTemplate.Text = "sTemplate";
            this.cmdTemplate.ToolTipText = "sTemplate";
            // 
            // sLoadToolStripMenuItem
            // 
            this.sLoadToolStripMenuItem.Name = "sLoadToolStripMenuItem";
            this.sLoadToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.sLoadToolStripMenuItem.Text = "sLoad";
            // 
            // sSaveToolStripMenuItem
            // 
            this.sSaveToolStripMenuItem.Name = "sSaveToolStripMenuItem";
            this.sSaveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.sSaveToolStripMenuItem.Text = "sSave";
            this.sSaveToolStripMenuItem.Click += new System.EventHandler(this.sSaveToolStripMenuItem_Click);
            // 
            // sSaveAsNewToolStripMenuItem
            // 
            this.sSaveAsNewToolStripMenuItem.Name = "sSaveAsNewToolStripMenuItem";
            this.sSaveAsNewToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.sSaveAsNewToolStripMenuItem.Text = "sSave As New";
            this.sSaveAsNewToolStripMenuItem.Click += new System.EventHandler(this.sSaveAsNewToolStripMenuItem_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(275, 546);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(36, 13);
            this.lblPrice.TabIndex = 119;
            this.lblPrice.Text = "sPrice";
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new System.Drawing.Point(352, 544);
            this.numPrice.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(120, 20);
            this.numPrice.TabIndex = 10;
            this.numPrice.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(540, 546);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 15;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // grpFullCustom
            // 
            this.grpFullCustom.Controls.Add(this.lblRightColumn);
            this.grpFullCustom.Controls.Add(this.lblLeftColumn);
            this.grpFullCustom.Controls.Add(this.cmdLeftMoveUp);
            this.grpFullCustom.Controls.Add(this.cmdRightMoveUp);
            this.grpFullCustom.Controls.Add(this.cmdLeftMoveDown);
            this.grpFullCustom.Controls.Add(this.cmdRightMoveDown);
            this.grpFullCustom.Controls.Add(this.grpAddItem);
            this.grpFullCustom.Controls.Add(this.grpAddBlankLine);
            this.grpFullCustom.Controls.Add(this.lvLeft);
            this.grpFullCustom.Controls.Add(this.lvRight);
            this.grpFullCustom.Location = new System.Drawing.Point(7, 104);
            this.grpFullCustom.Name = "grpFullCustom";
            this.grpFullCustom.Size = new System.Drawing.Size(787, 420);
            this.grpFullCustom.TabIndex = 120;
            this.grpFullCustom.TabStop = false;
            // 
            // FrmQuickCustomUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(804, 593);
            this.Controls.Add(this.grpFullCustom);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtTag);
            this.Controls.Add(this.lblTag);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdGenerateReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQuickCustomUnit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "sQuick Custom Unit";
            this.Load += new System.EventHandler(this.frmQuickCustomUnit_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmQuickCustomUnit_HelpRequested);
            this.grpAddItem.ResumeLayout(false);
            this.grpAddItem.PerformLayout();
            this.grpAddBlankLine.ResumeLayout(false);
            this.grpAddBlankLine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            this.grpFullCustom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLeftColumn;
        private System.Windows.Forms.Label lblRightColumn;
        private System.Windows.Forms.Button cmdLeftMoveUp;
        private System.Windows.Forms.Button cmdRightMoveUp;
        private System.Windows.Forms.Button cmdLeftMoveDown;
        private System.Windows.Forms.Button cmdRightMoveDown;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.ComboBox cboColumn;
        private System.Windows.Forms.Label lblColumn;
        private System.Windows.Forms.GroupBox grpAddItem;
        private System.Windows.Forms.GroupBox grpAddBlankLine;
        private System.Windows.Forms.Label lblBlankColumn;
        private System.Windows.Forms.ComboBox cboBlankColumn;
        private System.Windows.Forms.Button cmdBlankAdd;
        private System.Windows.Forms.Button cmdGenerateReport;
        private System.Windows.Forms.Label lblDelete;
        private System.Windows.Forms.ComboBox cboText;
        private GlacialComponents.Controls.GlacialList lvLeft;
        private GlacialComponents.Controls.GlacialList lvRight;
        private System.Windows.Forms.Button cmdAccept;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.Label lblTag;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton cmdTemplate;
        private System.Windows.Forms.ToolStripMenuItem sLoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sSaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sSaveAsNewToolStripMenuItem;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.GroupBox grpFullCustom;
    }
}