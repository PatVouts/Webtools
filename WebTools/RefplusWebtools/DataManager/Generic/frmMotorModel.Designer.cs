namespace RefplusWebtools.DataManager.Generic
{
    partial class FrmMotorModel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMotorModel));
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.lblMotorModel = new System.Windows.Forms.Label();
            this.txtMotorModel = new System.Windows.Forms.TextBox();
            this.numHP = new System.Windows.Forms.NumericUpDown();
            this.lblHP = new System.Windows.Forms.Label();
            this.txtRotationType = new System.Windows.Forms.TextBox();
            this.lblRotationType = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.dgTable = new System.Windows.Forms.DataGridView();
            this.grpInputs = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.num120_1_60_FLA = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFLA = new System.Windows.Forms.Label();
            this.lblVoltage = new System.Windows.Forms.Label();
            this.num600_3_60_FLA = new System.Windows.Forms.NumericUpDown();
            this.num480_3_60_FLA = new System.Windows.Forms.NumericUpDown();
            this.num208_240_3_60_FLA = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.num208_240_1_60_FLA = new System.Windows.Forms.NumericUpDown();
            this.numShaftLength = new System.Windows.Forms.NumericUpDown();
            this.lblShaftLength = new System.Windows.Forms.Label();
            this.txtFrameType = new System.Windows.Forms.TextBox();
            this.lblFrameType = new System.Windows.Forms.Label();
            this.numRPM = new System.Windows.Forms.NumericUpDown();
            this.lblRPM = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.grpTableView = new System.Windows.Forms.GroupBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTable)).BeginInit();
            this.grpInputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num120_1_60_FLA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num600_3_60_FLA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num480_3_60_FLA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num208_240_3_60_FLA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num208_240_1_60_FLA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShaftLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRPM)).BeginInit();
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
            // lblMotorModel
            // 
            this.lblMotorModel.AutoSize = true;
            this.lblMotorModel.Location = new System.Drawing.Point(6, 19);
            this.lblMotorModel.Name = "lblMotorModel";
            this.lblMotorModel.Size = new System.Drawing.Size(71, 13);
            this.lblMotorModel.TabIndex = 1;
            this.lblMotorModel.Text = "sMotor Model";
            // 
            // txtMotorModel
            // 
            this.txtMotorModel.Location = new System.Drawing.Point(6, 62);
            this.txtMotorModel.Name = "txtMotorModel";
            this.txtMotorModel.Size = new System.Drawing.Size(237, 20);
            this.txtMotorModel.TabIndex = 1;
            this.txtMotorModel.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // numHP
            // 
            this.numHP.DecimalPlaces = 3;
            this.numHP.Location = new System.Drawing.Point(9, 113);
            this.numHP.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numHP.Name = "numHP";
            this.numHP.Size = new System.Drawing.Size(234, 20);
            this.numHP.TabIndex = 2;
            this.numHP.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblHP
            // 
            this.lblHP.AutoSize = true;
            this.lblHP.Location = new System.Drawing.Point(6, 97);
            this.lblHP.Name = "lblHP";
            this.lblHP.Size = new System.Drawing.Size(27, 13);
            this.lblHP.TabIndex = 4;
            this.lblHP.Text = "sHP";
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
            // lblRotationType
            // 
            this.lblRotationType.AutoSize = true;
            this.lblRotationType.Location = new System.Drawing.Point(6, 175);
            this.lblRotationType.Name = "lblRotationType";
            this.lblRotationType.Size = new System.Drawing.Size(79, 13);
            this.lblRotationType.TabIndex = 10;
            this.lblRotationType.Text = "sRotation Type";
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
            this.dgTable.Size = new System.Drawing.Size(503, 455);
            this.dgTable.TabIndex = 0;
            this.dgTable.SelectionChanged += new System.EventHandler(this.dgTable_SelectionChanged);
            // 
            // grpInputs
            // 
            this.grpInputs.Controls.Add(this.label5);
            this.grpInputs.Controls.Add(this.num120_1_60_FLA);
            this.grpInputs.Controls.Add(this.label4);
            this.grpInputs.Controls.Add(this.label3);
            this.grpInputs.Controls.Add(this.label2);
            this.grpInputs.Controls.Add(this.lblFLA);
            this.grpInputs.Controls.Add(this.lblVoltage);
            this.grpInputs.Controls.Add(this.num600_3_60_FLA);
            this.grpInputs.Controls.Add(this.num480_3_60_FLA);
            this.grpInputs.Controls.Add(this.num208_240_3_60_FLA);
            this.grpInputs.Controls.Add(this.label1);
            this.grpInputs.Controls.Add(this.num208_240_1_60_FLA);
            this.grpInputs.Controls.Add(this.numShaftLength);
            this.grpInputs.Controls.Add(this.lblShaftLength);
            this.grpInputs.Controls.Add(this.txtFrameType);
            this.grpInputs.Controls.Add(this.lblFrameType);
            this.grpInputs.Controls.Add(this.numRPM);
            this.grpInputs.Controls.Add(this.lblRPM);
            this.grpInputs.Controls.Add(this.cmdSave);
            this.grpInputs.Controls.Add(this.lblMotorModel);
            this.grpInputs.Controls.Add(this.cboModel);
            this.grpInputs.Controls.Add(this.lblPrice);
            this.grpInputs.Controls.Add(this.txtMotorModel);
            this.grpInputs.Controls.Add(this.numPrice);
            this.grpInputs.Controls.Add(this.numHP);
            this.grpInputs.Controls.Add(this.lblHP);
            this.grpInputs.Controls.Add(this.txtRotationType);
            this.grpInputs.Controls.Add(this.lblRotationType);
            this.grpInputs.Location = new System.Drawing.Point(3, 4);
            this.grpInputs.Name = "grpInputs";
            this.grpInputs.Size = new System.Drawing.Size(254, 510);
            this.grpInputs.TabIndex = 0;
            this.grpInputs.TabStop = false;
            this.grpInputs.Text = "sInputs";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(10, 352);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "120/1/60";
            // 
            // num120_1_60_FLA
            // 
            this.num120_1_60_FLA.DecimalPlaces = 2;
            this.num120_1_60_FLA.Location = new System.Drawing.Point(159, 350);
            this.num120_1_60_FLA.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.num120_1_60_FLA.Name = "num120_1_60_FLA";
            this.num120_1_60_FLA.Size = new System.Drawing.Size(84, 20);
            this.num120_1_60_FLA.TabIndex = 8;
            this.num120_1_60_FLA.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(10, 456);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "600/3/60";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(10, 430);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "480/3/60";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(10, 404);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "208-240/3/60";
            // 
            // lblFLA
            // 
            this.lblFLA.AutoSize = true;
            this.lblFLA.Location = new System.Drawing.Point(156, 331);
            this.lblFLA.Name = "lblFLA";
            this.lblFLA.Size = new System.Drawing.Size(31, 13);
            this.lblFLA.TabIndex = 29;
            this.lblFLA.Text = "sFLA";
            // 
            // lblVoltage
            // 
            this.lblVoltage.AutoSize = true;
            this.lblVoltage.Location = new System.Drawing.Point(6, 331);
            this.lblVoltage.Name = "lblVoltage";
            this.lblVoltage.Size = new System.Drawing.Size(48, 13);
            this.lblVoltage.TabIndex = 28;
            this.lblVoltage.Text = "sVoltage";
            // 
            // num600_3_60_FLA
            // 
            this.num600_3_60_FLA.DecimalPlaces = 2;
            this.num600_3_60_FLA.Location = new System.Drawing.Point(159, 454);
            this.num600_3_60_FLA.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.num600_3_60_FLA.Name = "num600_3_60_FLA";
            this.num600_3_60_FLA.Size = new System.Drawing.Size(84, 20);
            this.num600_3_60_FLA.TabIndex = 12;
            this.num600_3_60_FLA.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // num480_3_60_FLA
            // 
            this.num480_3_60_FLA.DecimalPlaces = 2;
            this.num480_3_60_FLA.Location = new System.Drawing.Point(159, 428);
            this.num480_3_60_FLA.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.num480_3_60_FLA.Name = "num480_3_60_FLA";
            this.num480_3_60_FLA.Size = new System.Drawing.Size(84, 20);
            this.num480_3_60_FLA.TabIndex = 11;
            this.num480_3_60_FLA.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // num208_240_3_60_FLA
            // 
            this.num208_240_3_60_FLA.DecimalPlaces = 2;
            this.num208_240_3_60_FLA.Location = new System.Drawing.Point(159, 402);
            this.num208_240_3_60_FLA.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.num208_240_3_60_FLA.Name = "num208_240_3_60_FLA";
            this.num208_240_3_60_FLA.Size = new System.Drawing.Size(84, 20);
            this.num208_240_3_60_FLA.TabIndex = 10;
            this.num208_240_3_60_FLA.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(10, 378);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "208-240/1/60";
            // 
            // num208_240_1_60_FLA
            // 
            this.num208_240_1_60_FLA.DecimalPlaces = 2;
            this.num208_240_1_60_FLA.Location = new System.Drawing.Point(159, 376);
            this.num208_240_1_60_FLA.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.num208_240_1_60_FLA.Name = "num208_240_1_60_FLA";
            this.num208_240_1_60_FLA.Size = new System.Drawing.Size(84, 20);
            this.num208_240_1_60_FLA.TabIndex = 9;
            this.num208_240_1_60_FLA.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // numShaftLength
            // 
            this.numShaftLength.DecimalPlaces = 4;
            this.numShaftLength.Location = new System.Drawing.Point(9, 269);
            this.numShaftLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numShaftLength.Name = "numShaftLength";
            this.numShaftLength.Size = new System.Drawing.Size(234, 20);
            this.numShaftLength.TabIndex = 6;
            this.numShaftLength.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblShaftLength
            // 
            this.lblShaftLength.AutoSize = true;
            this.lblShaftLength.Location = new System.Drawing.Point(6, 253);
            this.lblShaftLength.Name = "lblShaftLength";
            this.lblShaftLength.Size = new System.Drawing.Size(73, 13);
            this.lblShaftLength.TabIndex = 22;
            this.lblShaftLength.Text = "sShaft Length";
            // 
            // txtFrameType
            // 
            this.txtFrameType.Location = new System.Drawing.Point(9, 230);
            this.txtFrameType.MaxLength = 50;
            this.txtFrameType.Name = "txtFrameType";
            this.txtFrameType.Size = new System.Drawing.Size(234, 20);
            this.txtFrameType.TabIndex = 5;
            this.txtFrameType.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblFrameType
            // 
            this.lblFrameType.AutoSize = true;
            this.lblFrameType.Location = new System.Drawing.Point(6, 214);
            this.lblFrameType.Name = "lblFrameType";
            this.lblFrameType.Size = new System.Drawing.Size(68, 13);
            this.lblFrameType.TabIndex = 19;
            this.lblFrameType.Text = "sFrame Type";
            // 
            // numRPM
            // 
            this.numRPM.Location = new System.Drawing.Point(9, 152);
            this.numRPM.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numRPM.Name = "numRPM";
            this.numRPM.Size = new System.Drawing.Size(234, 20);
            this.numRPM.TabIndex = 3;
            this.numRPM.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblRPM
            // 
            this.lblRPM.AutoSize = true;
            this.lblRPM.Location = new System.Drawing.Point(6, 136);
            this.lblRPM.Name = "lblRPM";
            this.lblRPM.Size = new System.Drawing.Size(36, 13);
            this.lblRPM.TabIndex = 18;
            this.lblRPM.Text = "sRPM";
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(6, 478);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(234, 27);
            this.cmdSave.TabIndex = 13;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // grpTableView
            // 
            this.grpTableView.Controls.Add(this.dgTable);
            this.grpTableView.Location = new System.Drawing.Point(263, 4);
            this.grpTableView.Name = "grpTableView";
            this.grpTableView.Size = new System.Drawing.Size(509, 474);
            this.grpTableView.TabIndex = 1;
            this.grpTableView.TabStop = false;
            this.grpTableView.Text = "sTable View";
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(535, 482);
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
            this.btnHelp.Location = new System.Drawing.Point(367, 485);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmMotorModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(778, 517);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.grpInputs);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.grpTableView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmMotorModel";
            this.Text = "sData Manager - Motor Model";
            this.Load += new System.EventHandler(this.frmMotorModel_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmMotorModel_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.numHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTable)).EndInit();
            this.grpInputs.ResumeLayout(false);
            this.grpInputs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num120_1_60_FLA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num600_3_60_FLA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num480_3_60_FLA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num208_240_3_60_FLA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num208_240_1_60_FLA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShaftLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRPM)).EndInit();
            this.grpTableView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboModel;
        private System.Windows.Forms.Label lblMotorModel;
        private System.Windows.Forms.TextBox txtMotorModel;
        private System.Windows.Forms.NumericUpDown numHP;
        private System.Windows.Forms.Label lblHP;
        private System.Windows.Forms.TextBox txtRotationType;
        private System.Windows.Forms.Label lblRotationType;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.DataGridView dgTable;
        private System.Windows.Forms.GroupBox grpInputs;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.GroupBox grpTableView;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.NumericUpDown numRPM;
        private System.Windows.Forms.Label lblRPM;
        private System.Windows.Forms.TextBox txtFrameType;
        private System.Windows.Forms.Label lblFrameType;
        private System.Windows.Forms.NumericUpDown numShaftLength;
        private System.Windows.Forms.Label lblShaftLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFLA;
        private System.Windows.Forms.Label lblVoltage;
        private System.Windows.Forms.NumericUpDown num600_3_60_FLA;
        private System.Windows.Forms.NumericUpDown num480_3_60_FLA;
        private System.Windows.Forms.NumericUpDown num208_240_3_60_FLA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num208_240_1_60_FLA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown num120_1_60_FLA;
        private System.Windows.Forms.Button btnHelp;
    }
}