namespace RefplusWebtools.DataManager.Generic
{
    partial class FrmMotorMount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMotorMount));
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.lblMotorMount = new System.Windows.Forms.Label();
            this.txtMotorMount = new System.Windows.Forms.TextBox();
            this.numFanSize = new System.Windows.Forms.NumericUpDown();
            this.lblFanSize = new System.Windows.Forms.Label();
            this.txtComposition = new System.Windows.Forms.TextBox();
            this.lblComposition = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.dgTable = new System.Windows.Forms.DataGridView();
            this.grpInputs = new System.Windows.Forms.GroupBox();
            this.numFrameSize = new System.Windows.Forms.NumericUpDown();
            this.lblFrameSize = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.grpTableView = new System.Windows.Forms.GroupBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numFanSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTable)).BeginInit();
            this.grpInputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFrameSize)).BeginInit();
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
            // lblMotorMount
            // 
            this.lblMotorMount.AutoSize = true;
            this.lblMotorMount.Location = new System.Drawing.Point(6, 19);
            this.lblMotorMount.Name = "lblMotorMount";
            this.lblMotorMount.Size = new System.Drawing.Size(72, 13);
            this.lblMotorMount.TabIndex = 1;
            this.lblMotorMount.Text = "sMotor Mount";
            // 
            // txtMotorMount
            // 
            this.txtMotorMount.Location = new System.Drawing.Point(6, 62);
            this.txtMotorMount.Name = "txtMotorMount";
            this.txtMotorMount.Size = new System.Drawing.Size(237, 20);
            this.txtMotorMount.TabIndex = 1;
            this.txtMotorMount.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // numFanSize
            // 
            this.numFanSize.Location = new System.Drawing.Point(9, 113);
            this.numFanSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numFanSize.Name = "numFanSize";
            this.numFanSize.Size = new System.Drawing.Size(234, 20);
            this.numFanSize.TabIndex = 2;
            this.numFanSize.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblFanSize
            // 
            this.lblFanSize.AutoSize = true;
            this.lblFanSize.Location = new System.Drawing.Point(6, 97);
            this.lblFanSize.Name = "lblFanSize";
            this.lblFanSize.Size = new System.Drawing.Size(53, 13);
            this.lblFanSize.TabIndex = 4;
            this.lblFanSize.Text = "sFan Size";
            // 
            // txtComposition
            // 
            this.txtComposition.Location = new System.Drawing.Point(9, 191);
            this.txtComposition.MaxLength = 50;
            this.txtComposition.Name = "txtComposition";
            this.txtComposition.Size = new System.Drawing.Size(234, 20);
            this.txtComposition.TabIndex = 4;
            this.txtComposition.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblComposition
            // 
            this.lblComposition.AutoSize = true;
            this.lblComposition.Location = new System.Drawing.Point(6, 175);
            this.lblComposition.Name = "lblComposition";
            this.lblComposition.Size = new System.Drawing.Size(69, 13);
            this.lblComposition.TabIndex = 10;
            this.lblComposition.Text = "sComposition";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(6, 214);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(36, 13);
            this.lblPrice.TabIndex = 15;
            this.lblPrice.Text = "sPrice";
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new System.Drawing.Point(9, 230);
            this.numPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(234, 20);
            this.numPrice.TabIndex = 5;
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
            this.dgTable.Size = new System.Drawing.Size(504, 228);
            this.dgTable.TabIndex = 0;
            this.dgTable.SelectionChanged += new System.EventHandler(this.dgTable_SelectionChanged);
            // 
            // grpInputs
            // 
            this.grpInputs.Controls.Add(this.numFrameSize);
            this.grpInputs.Controls.Add(this.lblFrameSize);
            this.grpInputs.Controls.Add(this.cmdSave);
            this.grpInputs.Controls.Add(this.lblMotorMount);
            this.grpInputs.Controls.Add(this.cboModel);
            this.grpInputs.Controls.Add(this.lblPrice);
            this.grpInputs.Controls.Add(this.txtMotorMount);
            this.grpInputs.Controls.Add(this.numPrice);
            this.grpInputs.Controls.Add(this.numFanSize);
            this.grpInputs.Controls.Add(this.lblFanSize);
            this.grpInputs.Controls.Add(this.txtComposition);
            this.grpInputs.Controls.Add(this.lblComposition);
            this.grpInputs.Location = new System.Drawing.Point(2, 5);
            this.grpInputs.Name = "grpInputs";
            this.grpInputs.Size = new System.Drawing.Size(254, 285);
            this.grpInputs.TabIndex = 0;
            this.grpInputs.TabStop = false;
            this.grpInputs.Text = "sInputs";
            // 
            // numFrameSize
            // 
            this.numFrameSize.DecimalPlaces = 3;
            this.numFrameSize.Location = new System.Drawing.Point(9, 152);
            this.numFrameSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numFrameSize.Name = "numFrameSize";
            this.numFrameSize.Size = new System.Drawing.Size(234, 20);
            this.numFrameSize.TabIndex = 3;
            this.numFrameSize.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblFrameSize
            // 
            this.lblFrameSize.AutoSize = true;
            this.lblFrameSize.Location = new System.Drawing.Point(6, 136);
            this.lblFrameSize.Name = "lblFrameSize";
            this.lblFrameSize.Size = new System.Drawing.Size(64, 13);
            this.lblFrameSize.TabIndex = 18;
            this.lblFrameSize.Text = "sFrame Size";
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(9, 253);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(234, 27);
            this.cmdSave.TabIndex = 6;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // grpTableView
            // 
            this.grpTableView.Controls.Add(this.dgTable);
            this.grpTableView.Location = new System.Drawing.Point(262, 5);
            this.grpTableView.Name = "grpTableView";
            this.grpTableView.Size = new System.Drawing.Size(510, 247);
            this.grpTableView.TabIndex = 1;
            this.grpTableView.TabStop = false;
            this.grpTableView.Text = "sTable View";
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(538, 258);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(234, 27);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(380, 261);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmMotorMount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(778, 292);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.grpInputs);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.grpTableView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmMotorMount";
            this.Text = "sData Manager - Motor Mount";
            this.Load += new System.EventHandler(this.frmMotorMount_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmMotorMount_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.numFanSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTable)).EndInit();
            this.grpInputs.ResumeLayout(false);
            this.grpInputs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFrameSize)).EndInit();
            this.grpTableView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboModel;
        private System.Windows.Forms.Label lblMotorMount;
        private System.Windows.Forms.TextBox txtMotorMount;
        private System.Windows.Forms.NumericUpDown numFanSize;
        private System.Windows.Forms.Label lblFanSize;
        private System.Windows.Forms.TextBox txtComposition;
        private System.Windows.Forms.Label lblComposition;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.DataGridView dgTable;
        private System.Windows.Forms.GroupBox grpInputs;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.GroupBox grpTableView;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.NumericUpDown numFrameSize;
        private System.Windows.Forms.Label lblFrameSize;
        private System.Windows.Forms.Button btnHelp;
    }
}