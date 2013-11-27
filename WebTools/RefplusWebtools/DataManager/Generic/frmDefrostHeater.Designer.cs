namespace RefplusWebtools.DataManager.Generic
{
    partial class FrmDefrostHeater
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDefrostHeater));
            this.grpTableView = new System.Windows.Forms.GroupBox();
            this.dgTable = new System.Windows.Forms.DataGridView();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lblDefrostHeaterModel = new System.Windows.Forms.Label();
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.grpInputs = new System.Windows.Forms.GroupBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtDefrostHeaterModel = new System.Windows.Forms.TextBox();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.numVolts = new System.Windows.Forms.NumericUpDown();
            this.lblType = new System.Windows.Forms.Label();
            this.numWatts = new System.Windows.Forms.NumericUpDown();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblVolts = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblWatts = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.grpTableView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTable)).BeginInit();
            this.grpInputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVolts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWatts)).BeginInit();
            this.SuspendLayout();
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
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(9, 331);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(232, 27);
            this.cmdSave.TabIndex = 7;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lblDefrostHeaterModel
            // 
            this.lblDefrostHeaterModel.AutoSize = true;
            this.lblDefrostHeaterModel.Location = new System.Drawing.Point(6, 19);
            this.lblDefrostHeaterModel.Name = "lblDefrostHeaterModel";
            this.lblDefrostHeaterModel.Size = new System.Drawing.Size(113, 13);
            this.lblDefrostHeaterModel.TabIndex = 1;
            this.lblDefrostHeaterModel.Text = "sDefrost Heater Model";
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
            // grpInputs
            // 
            this.grpInputs.Controls.Add(this.cmdSave);
            this.grpInputs.Controls.Add(this.lblDefrostHeaterModel);
            this.grpInputs.Controls.Add(this.cboModel);
            this.grpInputs.Controls.Add(this.lblPrice);
            this.grpInputs.Controls.Add(this.txtDefrostHeaterModel);
            this.grpInputs.Controls.Add(this.numPrice);
            this.grpInputs.Controls.Add(this.numVolts);
            this.grpInputs.Controls.Add(this.lblType);
            this.grpInputs.Controls.Add(this.numWatts);
            this.grpInputs.Controls.Add(this.txtDescription);
            this.grpInputs.Controls.Add(this.lblVolts);
            this.grpInputs.Controls.Add(this.lblDescription);
            this.grpInputs.Controls.Add(this.lblWatts);
            this.grpInputs.Controls.Add(this.txtType);
            this.grpInputs.Location = new System.Drawing.Point(5, 1);
            this.grpInputs.Name = "grpInputs";
            this.grpInputs.Size = new System.Drawing.Size(254, 364);
            this.grpInputs.TabIndex = 0;
            this.grpInputs.TabStop = false;
            this.grpInputs.Text = "sInputs";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(10, 253);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(36, 13);
            this.lblPrice.TabIndex = 15;
            this.lblPrice.Text = "sPrice";
            // 
            // txtDefrostHeaterModel
            // 
            this.txtDefrostHeaterModel.Location = new System.Drawing.Point(6, 62);
            this.txtDefrostHeaterModel.Name = "txtDefrostHeaterModel";
            this.txtDefrostHeaterModel.Size = new System.Drawing.Size(237, 20);
            this.txtDefrostHeaterModel.TabIndex = 1;
            this.txtDefrostHeaterModel.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new System.Drawing.Point(13, 269);
            this.numPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(234, 20);
            this.numPrice.TabIndex = 6;
            this.numPrice.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // numVolts
            // 
            this.numVolts.Location = new System.Drawing.Point(9, 152);
            this.numVolts.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numVolts.Name = "numVolts";
            this.numVolts.Size = new System.Drawing.Size(234, 20);
            this.numVolts.TabIndex = 3;
            this.numVolts.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(6, 97);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(36, 13);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "sType";
            // 
            // numWatts
            // 
            this.numWatts.Location = new System.Drawing.Point(9, 191);
            this.numWatts.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWatts.Name = "numWatts";
            this.numWatts.Size = new System.Drawing.Size(234, 20);
            this.numWatts.TabIndex = 4;
            this.numWatts.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(11, 230);
            this.txtDescription.MaxLength = 50;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(234, 20);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblVolts
            // 
            this.lblVolts.AutoSize = true;
            this.lblVolts.Location = new System.Drawing.Point(6, 136);
            this.lblVolts.Name = "lblVolts";
            this.lblVolts.Size = new System.Drawing.Size(35, 13);
            this.lblVolts.TabIndex = 6;
            this.lblVolts.Text = "sVolts";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(8, 214);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(65, 13);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "sDescription";
            // 
            // lblWatts
            // 
            this.lblWatts.AutoSize = true;
            this.lblWatts.Location = new System.Drawing.Point(6, 175);
            this.lblWatts.Name = "lblWatts";
            this.lblWatts.Size = new System.Drawing.Size(40, 13);
            this.lblWatts.TabIndex = 8;
            this.lblWatts.Text = "sWatts";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(9, 113);
            this.txtType.MaxLength = 50;
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(234, 20);
            this.txtType.TabIndex = 2;
            this.txtType.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
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
            this.btnHelp.Location = new System.Drawing.Point(380, 335);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmDefrostHeater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(781, 369);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.grpTableView);
            this.Controls.Add(this.grpInputs);
            this.Controls.Add(this.cmdClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmDefrostHeater";
            this.Text = "sData Manager - Defrost Heater";
            this.Load += new System.EventHandler(this.frmDefrostHeater_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmDefrostHeater_HelpRequested);
            this.grpTableView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTable)).EndInit();
            this.grpInputs.ResumeLayout(false);
            this.grpInputs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVolts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWatts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTableView;
        private System.Windows.Forms.DataGridView dgTable;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label lblDefrostHeaterModel;
        private System.Windows.Forms.ComboBox cboModel;
        private System.Windows.Forms.GroupBox grpInputs;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtDefrostHeaterModel;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.NumericUpDown numVolts;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.NumericUpDown numWatts;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblVolts;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblWatts;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button btnHelp;
    }
}