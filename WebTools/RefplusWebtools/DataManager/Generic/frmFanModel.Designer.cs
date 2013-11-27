namespace RefplusWebtools.DataManager.Generic
{
    partial class FrmFanModel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFanModel));
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.lblFanModel = new System.Windows.Forms.Label();
            this.txtFanModel = new System.Windows.Forms.TextBox();
            this.numDiameter = new System.Windows.Forms.NumericUpDown();
            this.lblDiameter = new System.Windows.Forms.Label();
            this.lblBladeQuantity = new System.Windows.Forms.Label();
            this.numBladeQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblRotationType = new System.Windows.Forms.Label();
            this.txtRotationType = new System.Windows.Forms.TextBox();
            this.txtComposition = new System.Windows.Forms.TextBox();
            this.lblComposition = new System.Windows.Forms.Label();
            this.lblPitch = new System.Windows.Forms.Label();
            this.numPitch = new System.Windows.Forms.NumericUpDown();
            this.lblPrice = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.dgTable = new System.Windows.Forms.DataGridView();
            this.grpInputs = new System.Windows.Forms.GroupBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.grpTableView = new System.Windows.Forms.GroupBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numDiameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBladeQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTable)).BeginInit();
            this.grpInputs.SuspendLayout();
            this.grpTableView.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboModel
            // 
            this.cboModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModel.FormattingEnabled = true;
            this.cboModel.Location = new System.Drawing.Point(6, 35);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(237, 21);
            this.cboModel.TabIndex = 0;
            this.cboModel.SelectedIndexChanged += new System.EventHandler(this.cboModel_SelectedIndexChanged);
            // 
            // lblFanModel
            // 
            this.lblFanModel.AutoSize = true;
            this.lblFanModel.Location = new System.Drawing.Point(6, 19);
            this.lblFanModel.Name = "lblFanModel";
            this.lblFanModel.Size = new System.Drawing.Size(62, 13);
            this.lblFanModel.TabIndex = 1;
            this.lblFanModel.Text = "sFan Model";
            // 
            // txtFanModel
            // 
            this.txtFanModel.Location = new System.Drawing.Point(6, 62);
            this.txtFanModel.Name = "txtFanModel";
            this.txtFanModel.Size = new System.Drawing.Size(237, 20);
            this.txtFanModel.TabIndex = 1;
            this.txtFanModel.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // numDiameter
            // 
            this.numDiameter.Location = new System.Drawing.Point(9, 113);
            this.numDiameter.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numDiameter.Name = "numDiameter";
            this.numDiameter.Size = new System.Drawing.Size(234, 20);
            this.numDiameter.TabIndex = 2;
            this.numDiameter.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblDiameter
            // 
            this.lblDiameter.AutoSize = true;
            this.lblDiameter.Location = new System.Drawing.Point(6, 97);
            this.lblDiameter.Name = "lblDiameter";
            this.lblDiameter.Size = new System.Drawing.Size(54, 13);
            this.lblDiameter.TabIndex = 4;
            this.lblDiameter.Text = "sDiameter";
            // 
            // lblBladeQuantity
            // 
            this.lblBladeQuantity.AutoSize = true;
            this.lblBladeQuantity.Location = new System.Drawing.Point(6, 136);
            this.lblBladeQuantity.Name = "lblBladeQuantity";
            this.lblBladeQuantity.Size = new System.Drawing.Size(81, 13);
            this.lblBladeQuantity.TabIndex = 6;
            this.lblBladeQuantity.Text = "sBlade Quantity";
            // 
            // numBladeQuantity
            // 
            this.numBladeQuantity.Location = new System.Drawing.Point(9, 152);
            this.numBladeQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numBladeQuantity.Name = "numBladeQuantity";
            this.numBladeQuantity.Size = new System.Drawing.Size(234, 20);
            this.numBladeQuantity.TabIndex = 3;
            this.numBladeQuantity.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblRotationType
            // 
            this.lblRotationType.AutoSize = true;
            this.lblRotationType.Location = new System.Drawing.Point(6, 175);
            this.lblRotationType.Name = "lblRotationType";
            this.lblRotationType.Size = new System.Drawing.Size(79, 13);
            this.lblRotationType.TabIndex = 8;
            this.lblRotationType.Text = "sRotation Type";
            // 
            // txtRotationType
            // 
            this.txtRotationType.Location = new System.Drawing.Point(9, 191);
            this.txtRotationType.MaxLength = 50;
            this.txtRotationType.Name = "txtRotationType";
            this.txtRotationType.Size = new System.Drawing.Size(234, 20);
            this.txtRotationType.TabIndex = 4;
            this.txtRotationType.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // txtComposition
            // 
            this.txtComposition.Location = new System.Drawing.Point(11, 230);
            this.txtComposition.MaxLength = 50;
            this.txtComposition.Name = "txtComposition";
            this.txtComposition.Size = new System.Drawing.Size(234, 20);
            this.txtComposition.TabIndex = 5;
            this.txtComposition.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblComposition
            // 
            this.lblComposition.AutoSize = true;
            this.lblComposition.Location = new System.Drawing.Point(8, 214);
            this.lblComposition.Name = "lblComposition";
            this.lblComposition.Size = new System.Drawing.Size(69, 13);
            this.lblComposition.TabIndex = 10;
            this.lblComposition.Text = "sComposition";
            // 
            // lblPitch
            // 
            this.lblPitch.AutoSize = true;
            this.lblPitch.Location = new System.Drawing.Point(6, 253);
            this.lblPitch.Name = "lblPitch";
            this.lblPitch.Size = new System.Drawing.Size(36, 13);
            this.lblPitch.TabIndex = 13;
            this.lblPitch.Text = "sPitch";
            // 
            // numPitch
            // 
            this.numPitch.Location = new System.Drawing.Point(9, 269);
            this.numPitch.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPitch.Name = "numPitch";
            this.numPitch.Size = new System.Drawing.Size(234, 20);
            this.numPitch.TabIndex = 6;
            this.numPitch.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(6, 292);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(36, 13);
            this.lblPrice.TabIndex = 15;
            this.lblPrice.Text = "sPrice";
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new System.Drawing.Point(9, 308);
            this.numPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(234, 20);
            this.numPrice.TabIndex = 7;
            this.numPrice.Enter += new System.EventHandler(this.AutoSelectOnTab);
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
            this.dgTable.Size = new System.Drawing.Size(503, 309);
            this.dgTable.TabIndex = 0;
            this.dgTable.SelectionChanged += new System.EventHandler(this.dgTable_SelectionChanged);
            // 
            // grpInputs
            // 
            this.grpInputs.Controls.Add(this.cmdSave);
            this.grpInputs.Controls.Add(this.lblFanModel);
            this.grpInputs.Controls.Add(this.cboModel);
            this.grpInputs.Controls.Add(this.lblPrice);
            this.grpInputs.Controls.Add(this.txtFanModel);
            this.grpInputs.Controls.Add(this.numPrice);
            this.grpInputs.Controls.Add(this.numDiameter);
            this.grpInputs.Controls.Add(this.lblPitch);
            this.grpInputs.Controls.Add(this.lblDiameter);
            this.grpInputs.Controls.Add(this.numPitch);
            this.grpInputs.Controls.Add(this.numBladeQuantity);
            this.grpInputs.Controls.Add(this.txtComposition);
            this.grpInputs.Controls.Add(this.lblBladeQuantity);
            this.grpInputs.Controls.Add(this.lblComposition);
            this.grpInputs.Controls.Add(this.lblRotationType);
            this.grpInputs.Controls.Add(this.txtRotationType);
            this.grpInputs.Location = new System.Drawing.Point(5, 1);
            this.grpInputs.Name = "grpInputs";
            this.grpInputs.Size = new System.Drawing.Size(254, 364);
            this.grpInputs.TabIndex = 0;
            this.grpInputs.TabStop = false;
            this.grpInputs.Text = "sInputs";
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(9, 331);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(232, 27);
            this.cmdSave.TabIndex = 8;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // grpTableView
            // 
            this.grpTableView.Controls.Add(this.dgTable);
            this.grpTableView.Location = new System.Drawing.Point(265, 1);
            this.grpTableView.Name = "grpTableView";
            this.grpTableView.Size = new System.Drawing.Size(509, 328);
            this.grpTableView.TabIndex = 1;
            this.grpTableView.TabStop = false;
            this.grpTableView.Text = "sTable View";
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(542, 332);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(232, 27);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(376, 335);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmFanModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(781, 369);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.grpInputs);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.grpTableView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmFanModel";
            this.Text = "sData Manager - Fan Model";
            this.Load += new System.EventHandler(this.frmFanModel_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmFanModel_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.numDiameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBladeQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTable)).EndInit();
            this.grpInputs.ResumeLayout(false);
            this.grpInputs.PerformLayout();
            this.grpTableView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboModel;
        private System.Windows.Forms.Label lblFanModel;
        private System.Windows.Forms.TextBox txtFanModel;
        private System.Windows.Forms.NumericUpDown numDiameter;
        private System.Windows.Forms.Label lblDiameter;
        private System.Windows.Forms.Label lblBladeQuantity;
        private System.Windows.Forms.NumericUpDown numBladeQuantity;
        private System.Windows.Forms.Label lblRotationType;
        private System.Windows.Forms.TextBox txtRotationType;
        private System.Windows.Forms.TextBox txtComposition;
        private System.Windows.Forms.Label lblComposition;
        private System.Windows.Forms.Label lblPitch;
        private System.Windows.Forms.NumericUpDown numPitch;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.DataGridView dgTable;
        private System.Windows.Forms.GroupBox grpInputs;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.GroupBox grpTableView;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button btnHelp;
    }
}