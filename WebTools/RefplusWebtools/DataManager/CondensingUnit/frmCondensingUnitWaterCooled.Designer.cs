namespace RefplusWebtools.DataManager.CondensingUnit
{
    partial class FrmCondensingUnitWaterCooledCondenser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCondensingUnitWaterCooledCondenser));
            this.cmdClose = new System.Windows.Forms.Button();
            this.grpTableView = new System.Windows.Forms.GroupBox();
            this.dgTable = new System.Windows.Forms.DataGridView();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lblPumpDownCapacity = new System.Windows.Forms.Label();
            this.numPumpDownCapacity = new System.Windows.Forms.NumericUpDown();
            this.txtWaterCooledCondenserModel = new System.Windows.Forms.TextBox();
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.lblWaterCooledModel = new System.Windows.Forms.Label();
            this.grpInputs = new System.Windows.Forms.GroupBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.grpTableView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPumpDownCapacity)).BeginInit();
            this.grpInputs.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(429, 211);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(234, 26);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // grpTableView
            // 
            this.grpTableView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTableView.Controls.Add(this.dgTable);
            this.grpTableView.Location = new System.Drawing.Point(262, 5);
            this.grpTableView.Name = "grpTableView";
            this.grpTableView.Size = new System.Drawing.Size(401, 200);
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
            this.dgTable.Size = new System.Drawing.Size(395, 181);
            this.dgTable.TabIndex = 0;
            this.dgTable.SelectionChanged += new System.EventHandler(this.dgTable_SelectionChanged);
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(9, 206);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(234, 26);
            this.cmdSave.TabIndex = 3;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lblPumpDownCapacity
            // 
            this.lblPumpDownCapacity.AutoSize = true;
            this.lblPumpDownCapacity.Location = new System.Drawing.Point(6, 97);
            this.lblPumpDownCapacity.Name = "lblPumpDownCapacity";
            this.lblPumpDownCapacity.Size = new System.Drawing.Size(114, 13);
            this.lblPumpDownCapacity.TabIndex = 4;
            this.lblPumpDownCapacity.Text = "sPump Down Capacity";
            // 
            // numPumpDownCapacity
            // 
            this.numPumpDownCapacity.DecimalPlaces = 3;
            this.numPumpDownCapacity.Location = new System.Drawing.Point(9, 113);
            this.numPumpDownCapacity.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numPumpDownCapacity.Name = "numPumpDownCapacity";
            this.numPumpDownCapacity.Size = new System.Drawing.Size(234, 20);
            this.numPumpDownCapacity.TabIndex = 2;
            this.numPumpDownCapacity.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // txtWaterCooledCondenserModel
            // 
            this.txtWaterCooledCondenserModel.Location = new System.Drawing.Point(6, 62);
            this.txtWaterCooledCondenserModel.Name = "txtWaterCooledCondenserModel";
            this.txtWaterCooledCondenserModel.Size = new System.Drawing.Size(237, 20);
            this.txtWaterCooledCondenserModel.TabIndex = 1;
            this.txtWaterCooledCondenserModel.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
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
            // lblWaterCooledModel
            // 
            this.lblWaterCooledModel.AutoSize = true;
            this.lblWaterCooledModel.Location = new System.Drawing.Point(6, 19);
            this.lblWaterCooledModel.Name = "lblWaterCooledModel";
            this.lblWaterCooledModel.Size = new System.Drawing.Size(162, 13);
            this.lblWaterCooledModel.TabIndex = 1;
            this.lblWaterCooledModel.Text = "sWater Cooled condenser Model";
            // 
            // grpInputs
            // 
            this.grpInputs.Controls.Add(this.lblWaterCooledModel);
            this.grpInputs.Controls.Add(this.cboModel);
            this.grpInputs.Controls.Add(this.txtWaterCooledCondenserModel);
            this.grpInputs.Controls.Add(this.cmdSave);
            this.grpInputs.Controls.Add(this.numPumpDownCapacity);
            this.grpInputs.Controls.Add(this.lblPumpDownCapacity);
            this.grpInputs.Location = new System.Drawing.Point(2, 5);
            this.grpInputs.Name = "grpInputs";
            this.grpInputs.Size = new System.Drawing.Size(254, 237);
            this.grpInputs.TabIndex = 0;
            this.grpInputs.TabStop = false;
            this.grpInputs.Text = "sInputs";
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(319, 213);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmCondensingUnitWaterCooledCondenser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(675, 245);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.grpTableView);
            this.Controls.Add(this.grpInputs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmCondensingUnitWaterCooledCondenser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "sData Manager - Condensing Unit Water Cooled Condenser";
            this.Load += new System.EventHandler(this.frmCondensingUnitWaterCooledCondenser_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmCondensingUnitWaterCooledCondenser_HelpRequested);
            this.grpTableView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPumpDownCapacity)).EndInit();
            this.grpInputs.ResumeLayout(false);
            this.grpInputs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.GroupBox grpTableView;
        private System.Windows.Forms.DataGridView dgTable;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label lblPumpDownCapacity;
        private System.Windows.Forms.NumericUpDown numPumpDownCapacity;
        private System.Windows.Forms.TextBox txtWaterCooledCondenserModel;
        private System.Windows.Forms.ComboBox cboModel;
        private System.Windows.Forms.Label lblWaterCooledModel;
        private System.Windows.Forms.GroupBox grpInputs;
        private System.Windows.Forms.Button btnHelp;
    }
}