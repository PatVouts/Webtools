namespace RefplusWebtools.DataManager.Generic
{
    partial class FrmCompressor
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
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn4 = new GlacialComponents.Controls.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompressor));
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.lblCompressor = new System.Windows.Forms.Label();
            this.txtCompressor = new System.Windows.Forms.TextBox();
            this.numRLA = new System.Windows.Forms.NumericUpDown();
            this.lblRLA = new System.Windows.Forms.Label();
            this.dgTable = new System.Windows.Forms.DataGridView();
            this.grpInputs = new System.Windows.Forms.GroupBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.cboManufacturer = new System.Windows.Forms.ComboBox();
            this.glPoly = new GlacialComponents.Controls.GlacialList();
            this.lblPolyLegend = new System.Windows.Forms.Label();
            this.lblDisplayLRA = new System.Windows.Forms.Label();
            this.lblDisplayRLA = new System.Windows.Forms.Label();
            this.txtLRA = new System.Windows.Forms.TextBox();
            this.txtRLA = new System.Windows.Forms.TextBox();
            this.chkTandemCompressor = new System.Windows.Forms.CheckBox();
            this.lblVoltage = new System.Windows.Forms.Label();
            this.cboVoltage = new System.Windows.Forms.ComboBox();
            this.lblRefrigerant = new System.Windows.Forms.Label();
            this.cboRefrigerant = new System.Windows.Forms.ComboBox();
            this.numLRA = new System.Windows.Forms.NumericUpDown();
            this.lblLRA = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.grpTableView = new System.Windows.Forms.GroupBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.cmdImportExport = new System.Windows.Forms.Button();
            this.loadingCircle1 = new RefplusWebtools.LoadingCircle();
            ((System.ComponentModel.ISupportInitialize)(this.numRLA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTable)).BeginInit();
            this.grpInputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLRA)).BeginInit();
            this.grpTableView.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboModel
            // 
            this.cboModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModel.FormattingEnabled = true;
            this.cboModel.Location = new System.Drawing.Point(7, 30);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(237, 21);
            this.cboModel.TabIndex = 0;
            this.cboModel.SelectedIndexChanged += new System.EventHandler(this.cboModel_SelectedIndexChanged);
            // 
            // lblCompressor
            // 
            this.lblCompressor.AutoSize = true;
            this.lblCompressor.Location = new System.Drawing.Point(7, 14);
            this.lblCompressor.Name = "lblCompressor";
            this.lblCompressor.Size = new System.Drawing.Size(67, 13);
            this.lblCompressor.TabIndex = 1;
            this.lblCompressor.Text = "sCompressor";
            // 
            // txtCompressor
            // 
            this.txtCompressor.Location = new System.Drawing.Point(7, 55);
            this.txtCompressor.Name = "txtCompressor";
            this.txtCompressor.Size = new System.Drawing.Size(237, 20);
            this.txtCompressor.TabIndex = 1;
            this.txtCompressor.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // numRLA
            // 
            this.numRLA.DecimalPlaces = 3;
            this.numRLA.Location = new System.Drawing.Point(11, 246);
            this.numRLA.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numRLA.Name = "numRLA";
            this.numRLA.Size = new System.Drawing.Size(109, 20);
            this.numRLA.TabIndex = 6;
            this.numRLA.ValueChanged += new System.EventHandler(this.numRLA_ValueChanged);
            this.numRLA.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblRLA
            // 
            this.lblRLA.AutoSize = true;
            this.lblRLA.Location = new System.Drawing.Point(11, 230);
            this.lblRLA.Name = "lblRLA";
            this.lblRLA.Size = new System.Drawing.Size(33, 13);
            this.lblRLA.TabIndex = 4;
            this.lblRLA.Text = "sRLA";
            // 
            // dgTable
            // 
            this.dgTable.AllowUserToAddRows = false;
            this.dgTable.AllowUserToDeleteRows = false;
            this.dgTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTable.Location = new System.Drawing.Point(3, 16);
            this.dgTable.MultiSelect = false;
            this.dgTable.Name = "dgTable";
            this.dgTable.ReadOnly = true;
            this.dgTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTable.Size = new System.Drawing.Size(389, 556);
            this.dgTable.TabIndex = 0;
            this.dgTable.SelectionChanged += new System.EventHandler(this.dgTable_SelectionChanged);
            this.dgTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgTable_KeyDown);
            // 
            // grpInputs
            // 
            this.grpInputs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpInputs.Controls.Add(this.lblType);
            this.grpInputs.Controls.Add(this.cboType);
            this.grpInputs.Controls.Add(this.lblManufacturer);
            this.grpInputs.Controls.Add(this.cboManufacturer);
            this.grpInputs.Controls.Add(this.glPoly);
            this.grpInputs.Controls.Add(this.lblPolyLegend);
            this.grpInputs.Controls.Add(this.lblDisplayLRA);
            this.grpInputs.Controls.Add(this.lblDisplayRLA);
            this.grpInputs.Controls.Add(this.txtLRA);
            this.grpInputs.Controls.Add(this.txtRLA);
            this.grpInputs.Controls.Add(this.chkTandemCompressor);
            this.grpInputs.Controls.Add(this.lblVoltage);
            this.grpInputs.Controls.Add(this.cboVoltage);
            this.grpInputs.Controls.Add(this.lblRefrigerant);
            this.grpInputs.Controls.Add(this.cboRefrigerant);
            this.grpInputs.Controls.Add(this.numLRA);
            this.grpInputs.Controls.Add(this.lblLRA);
            this.grpInputs.Controls.Add(this.lblCompressor);
            this.grpInputs.Controls.Add(this.cboModel);
            this.grpInputs.Controls.Add(this.txtCompressor);
            this.grpInputs.Controls.Add(this.numRLA);
            this.grpInputs.Controls.Add(this.lblRLA);
            this.grpInputs.Location = new System.Drawing.Point(9, 6);
            this.grpInputs.Name = "grpInputs";
            this.grpInputs.Size = new System.Drawing.Size(254, 577);
            this.grpInputs.TabIndex = 0;
            this.grpInputs.TabStop = false;
            this.grpInputs.Text = "sInputs";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(11, 191);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(36, 13);
            this.lblType.TabIndex = 34;
            this.lblType.Text = "sType";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(11, 207);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(237, 21);
            this.cboType.TabIndex = 5;
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.AutoSize = true;
            this.lblManufacturer.Location = new System.Drawing.Point(11, 152);
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.Size = new System.Drawing.Size(75, 13);
            this.lblManufacturer.TabIndex = 32;
            this.lblManufacturer.Text = "sManufacturer";
            // 
            // cboManufacturer
            // 
            this.cboManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboManufacturer.FormattingEnabled = true;
            this.cboManufacturer.Location = new System.Drawing.Point(11, 168);
            this.cboManufacturer.Name = "cboManufacturer";
            this.cboManufacturer.Size = new System.Drawing.Size(237, 21);
            this.cboManufacturer.TabIndex = 4;
            // 
            // glPoly
            // 
            this.glPoly.AllowColumnResize = false;
            this.glPoly.AllowMultiselect = false;
            this.glPoly.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.glPoly.AlternatingColors = false;
            this.glPoly.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glPoly.AutoHeight = true;
            this.glPoly.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.glPoly.BackgroundStretchToFit = true;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Desc";
            glColumn3.NumericSort = false;
            glColumn3.Text = "sDesc";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 35;
            glColumn4.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.TextBox;
            glColumn4.CheckBoxes = false;
            glColumn4.DatetimeSort = false;
            glColumn4.ImageIndex = -1;
            glColumn4.Name = "Polynomial";
            glColumn4.NumericSort = false;
            glColumn4.Text = "sPolynomial (double click to edit)";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn4.Width = 180;
            this.glPoly.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn3,
            glColumn4});
            this.glPoly.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.glPoly.FullRowSelect = true;
            this.glPoly.GridColor = System.Drawing.Color.LightGray;
            this.glPoly.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.glPoly.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.glPoly.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.glPoly.HeaderHeight = 22;
            this.glPoly.HeaderVisible = true;
            this.glPoly.HeaderWordWrap = false;
            this.glPoly.HotColumnTracking = false;
            this.glPoly.HotItemTracking = false;
            this.glPoly.HotTrackingColor = System.Drawing.Color.LightGray;
            this.glPoly.HoverEvents = false;
            this.glPoly.HoverTime = 1;
            this.glPoly.ImageList = null;
            this.glPoly.ItemHeight = 17;
            this.glPoly.ItemWordWrap = false;
            this.glPoly.Location = new System.Drawing.Point(7, 326);
            this.glPoly.Name = "glPoly";
            this.glPoly.Selectable = true;
            this.glPoly.SelectedTextColor = System.Drawing.Color.White;
            this.glPoly.SelectionColor = System.Drawing.Color.DarkBlue;
            this.glPoly.ShowBorder = true;
            this.glPoly.ShowFocusRect = false;
            this.glPoly.Size = new System.Drawing.Size(244, 215);
            this.glPoly.SortType = GlacialComponents.Controls.SortTypes.None;
            this.glPoly.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.glPoly.TabIndex = 11;
            this.glPoly.Text = "glacialList1";
            // 
            // lblPolyLegend
            // 
            this.lblPolyLegend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPolyLegend.ForeColor = System.Drawing.Color.Red;
            this.lblPolyLegend.Location = new System.Drawing.Point(4, 545);
            this.lblPolyLegend.Name = "lblPolyLegend";
            this.lblPolyLegend.Size = new System.Drawing.Size(237, 29);
            this.lblPolyLegend.TabIndex = 30;
            this.lblPolyLegend.Text = "sC[1-10] = Capacity Polynomial\r\nP[1-10] = Power Polynomials";
            // 
            // lblDisplayLRA
            // 
            this.lblDisplayLRA.AutoSize = true;
            this.lblDisplayLRA.Location = new System.Drawing.Point(134, 267);
            this.lblDisplayLRA.Name = "lblDisplayLRA";
            this.lblDisplayLRA.Size = new System.Drawing.Size(70, 13);
            this.lblDisplayLRA.TabIndex = 27;
            this.lblDisplayLRA.Text = "sDisplay LRA";
            // 
            // lblDisplayRLA
            // 
            this.lblDisplayRLA.AutoSize = true;
            this.lblDisplayRLA.Location = new System.Drawing.Point(12, 267);
            this.lblDisplayRLA.Name = "lblDisplayRLA";
            this.lblDisplayRLA.Size = new System.Drawing.Size(70, 13);
            this.lblDisplayRLA.TabIndex = 26;
            this.lblDisplayRLA.Text = "sDisplay RLA";
            // 
            // txtLRA
            // 
            this.txtLRA.BackColor = System.Drawing.Color.White;
            this.txtLRA.Enabled = false;
            this.txtLRA.Location = new System.Drawing.Point(137, 283);
            this.txtLRA.Name = "txtLRA";
            this.txtLRA.Size = new System.Drawing.Size(109, 20);
            this.txtLRA.TabIndex = 9;
            this.txtLRA.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // txtRLA
            // 
            this.txtRLA.BackColor = System.Drawing.Color.White;
            this.txtRLA.Enabled = false;
            this.txtRLA.Location = new System.Drawing.Point(11, 283);
            this.txtRLA.Name = "txtRLA";
            this.txtRLA.Size = new System.Drawing.Size(110, 20);
            this.txtRLA.TabIndex = 8;
            this.txtRLA.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // chkTandemCompressor
            // 
            this.chkTandemCompressor.AutoSize = true;
            this.chkTandemCompressor.Location = new System.Drawing.Point(11, 306);
            this.chkTandemCompressor.Name = "chkTandemCompressor";
            this.chkTandemCompressor.Size = new System.Drawing.Size(128, 17);
            this.chkTandemCompressor.TabIndex = 10;
            this.chkTandemCompressor.Text = "sTandem Compressor";
            this.chkTandemCompressor.UseVisualStyleBackColor = true;
            this.chkTandemCompressor.CheckedChanged += new System.EventHandler(this.chkTandemCompressor_CheckedChanged);
            // 
            // lblVoltage
            // 
            this.lblVoltage.AutoSize = true;
            this.lblVoltage.Location = new System.Drawing.Point(11, 114);
            this.lblVoltage.Name = "lblVoltage";
            this.lblVoltage.Size = new System.Drawing.Size(48, 13);
            this.lblVoltage.TabIndex = 22;
            this.lblVoltage.Text = "sVoltage";
            // 
            // cboVoltage
            // 
            this.cboVoltage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVoltage.FormattingEnabled = true;
            this.cboVoltage.Location = new System.Drawing.Point(11, 130);
            this.cboVoltage.Name = "cboVoltage";
            this.cboVoltage.Size = new System.Drawing.Size(237, 21);
            this.cboVoltage.TabIndex = 3;
            // 
            // lblRefrigerant
            // 
            this.lblRefrigerant.AutoSize = true;
            this.lblRefrigerant.Location = new System.Drawing.Point(11, 76);
            this.lblRefrigerant.Name = "lblRefrigerant";
            this.lblRefrigerant.Size = new System.Drawing.Size(64, 13);
            this.lblRefrigerant.TabIndex = 20;
            this.lblRefrigerant.Text = "sRefrigerant";
            // 
            // cboRefrigerant
            // 
            this.cboRefrigerant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRefrigerant.FormattingEnabled = true;
            this.cboRefrigerant.Location = new System.Drawing.Point(11, 92);
            this.cboRefrigerant.Name = "cboRefrigerant";
            this.cboRefrigerant.Size = new System.Drawing.Size(237, 21);
            this.cboRefrigerant.TabIndex = 2;
            // 
            // numLRA
            // 
            this.numLRA.DecimalPlaces = 3;
            this.numLRA.Location = new System.Drawing.Point(136, 246);
            this.numLRA.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numLRA.Name = "numLRA";
            this.numLRA.Size = new System.Drawing.Size(109, 20);
            this.numLRA.TabIndex = 7;
            this.numLRA.ValueChanged += new System.EventHandler(this.numLRA_ValueChanged);
            this.numLRA.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblLRA
            // 
            this.lblLRA.AutoSize = true;
            this.lblLRA.Location = new System.Drawing.Point(133, 230);
            this.lblLRA.Name = "lblLRA";
            this.lblLRA.Size = new System.Drawing.Size(33, 13);
            this.lblLRA.TabIndex = 18;
            this.lblLRA.Text = "sLRA";
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(9, 588);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(185, 27);
            this.cmdSave.TabIndex = 2;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // grpTableView
            // 
            this.grpTableView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTableView.Controls.Add(this.loadingCircle1);
            this.grpTableView.Controls.Add(this.dgTable);
            this.grpTableView.Location = new System.Drawing.Point(269, 8);
            this.grpTableView.Name = "grpTableView";
            this.grpTableView.Size = new System.Drawing.Size(395, 575);
            this.grpTableView.TabIndex = 1;
            this.grpTableView.TabStop = false;
            this.grpTableView.Text = "sTable View";
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(479, 588);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(185, 27);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(446, 589);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // cmdImportExport
            // 
            this.cmdImportExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdImportExport.Image = global::RefplusWebtools.Properties.Resources.EditItem;
            this.cmdImportExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdImportExport.Location = new System.Drawing.Point(269, 589);
            this.cmdImportExport.Name = "cmdImportExport";
            this.cmdImportExport.Size = new System.Drawing.Size(135, 27);
            this.cmdImportExport.TabIndex = 5;
            this.cmdImportExport.Text = "sImport/Export";
            this.cmdImportExport.UseVisualStyleBackColor = true;
            this.cmdImportExport.Click += new System.EventHandler(this.cmdImportExport_Click);
            // 
            // loadingCircle1
            // 
            this.loadingCircle1.Active = false;
            this.loadingCircle1.Color = System.Drawing.Color.DarkGray;
            this.loadingCircle1.InnerCircleRadius = 8;
            this.loadingCircle1.Location = new System.Drawing.Point(165, 182);
            this.loadingCircle1.Name = "loadingCircle1";
            this.loadingCircle1.NumberSpoke = 10;
            this.loadingCircle1.OuterCircleRadius = 10;
            this.loadingCircle1.RotationSpeed = 100;
            this.loadingCircle1.Size = new System.Drawing.Size(75, 23);
            this.loadingCircle1.SpokeThickness = 4;
            this.loadingCircle1.StylePreset = RefplusWebtools.LoadingCircle.StylePresets.MacOSX;
            this.loadingCircle1.TabIndex = 1;
            this.loadingCircle1.Text = "loadingCircle1";
            // 
            // FrmCompressor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(673, 620);
            this.Controls.Add(this.cmdImportExport);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.grpInputs);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.grpTableView);
            this.Controls.Add(this.cmdSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmCompressor";
            this.Text = "sData Manager - Compressor Data";
            this.Load += new System.EventHandler(this.frmCompressor_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmCompressor_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.numRLA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTable)).EndInit();
            this.grpInputs.ResumeLayout(false);
            this.grpInputs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLRA)).EndInit();
            this.grpTableView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboModel;
        private System.Windows.Forms.Label lblCompressor;
        private System.Windows.Forms.TextBox txtCompressor;
        private System.Windows.Forms.NumericUpDown numRLA;
        private System.Windows.Forms.Label lblRLA;
        private System.Windows.Forms.DataGridView dgTable;
        private System.Windows.Forms.GroupBox grpInputs;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.GroupBox grpTableView;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.NumericUpDown numLRA;
        private System.Windows.Forms.Label lblLRA;
        private System.Windows.Forms.Label lblVoltage;
        private System.Windows.Forms.ComboBox cboVoltage;
        private System.Windows.Forms.Label lblRefrigerant;
        private System.Windows.Forms.ComboBox cboRefrigerant;
        private System.Windows.Forms.TextBox txtRLA;
        private System.Windows.Forms.CheckBox chkTandemCompressor;
        private System.Windows.Forms.TextBox txtLRA;
        private GlacialComponents.Controls.GlacialList glPoly;
        private System.Windows.Forms.Label lblDisplayLRA;
        private System.Windows.Forms.Label lblDisplayRLA;
        private System.Windows.Forms.Label lblPolyLegend;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.ComboBox cboManufacturer;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button cmdImportExport;
        private LoadingCircle loadingCircle1;
    }
}