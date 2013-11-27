namespace RefplusWebtools.DataManager.Generic
{
    partial class FrmFanGuard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFanGuard));
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.lblFanModel = new System.Windows.Forms.Label();
            this.txtFanModel = new System.Windows.Forms.TextBox();
            this.numFanSize = new System.Windows.Forms.NumericUpDown();
            this.lblFanSize = new System.Windows.Forms.Label();
            this.txtComposition = new System.Windows.Forms.TextBox();
            this.lblComposition = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.dgTable = new System.Windows.Forms.DataGridView();
            this.grpInputs = new System.Windows.Forms.GroupBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.grpTableView = new System.Windows.Forms.GroupBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numFanSize)).BeginInit();
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
            this.lblFanModel.Text = "sFan Guard";
            // 
            // txtFanModel
            // 
            this.txtFanModel.Location = new System.Drawing.Point(6, 62);
            this.txtFanModel.Name = "txtFanModel";
            this.txtFanModel.Size = new System.Drawing.Size(237, 20);
            this.txtFanModel.TabIndex = 1;
            this.txtFanModel.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
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
            this.txtComposition.Location = new System.Drawing.Point(9, 152);
            this.txtComposition.MaxLength = 50;
            this.txtComposition.Name = "txtComposition";
            this.txtComposition.Size = new System.Drawing.Size(234, 20);
            this.txtComposition.TabIndex = 3;
            this.txtComposition.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblComposition
            // 
            this.lblComposition.AutoSize = true;
            this.lblComposition.Location = new System.Drawing.Point(6, 136);
            this.lblComposition.Name = "lblComposition";
            this.lblComposition.Size = new System.Drawing.Size(69, 13);
            this.lblComposition.TabIndex = 10;
            this.lblComposition.Text = "sComposition";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(6, 175);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(36, 13);
            this.lblPrice.TabIndex = 15;
            this.lblPrice.Text = "sPrice";
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new System.Drawing.Point(9, 191);
            this.numPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(234, 20);
            this.numPrice.TabIndex = 4;
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
            this.dgTable.Size = new System.Drawing.Size(504, 188);
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
            this.grpInputs.Controls.Add(this.numFanSize);
            this.grpInputs.Controls.Add(this.lblFanSize);
            this.grpInputs.Controls.Add(this.txtComposition);
            this.grpInputs.Controls.Add(this.lblComposition);
            this.grpInputs.Location = new System.Drawing.Point(2, 2);
            this.grpInputs.Name = "grpInputs";
            this.grpInputs.Size = new System.Drawing.Size(254, 244);
            this.grpInputs.TabIndex = 0;
            this.grpInputs.TabStop = false;
            this.grpInputs.Text = "sInputs";
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(9, 213);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(234, 27);
            this.cmdSave.TabIndex = 5;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // grpTableView
            // 
            this.grpTableView.Controls.Add(this.dgTable);
            this.grpTableView.Location = new System.Drawing.Point(262, 2);
            this.grpTableView.Name = "grpTableView";
            this.grpTableView.Size = new System.Drawing.Size(510, 207);
            this.grpTableView.TabIndex = 1;
            this.grpTableView.TabStop = false;
            this.grpTableView.Text = "sTable View";
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(538, 215);
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
            this.btnHelp.Location = new System.Drawing.Point(367, 218);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmFanGuard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(779, 248);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.grpInputs);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.grpTableView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmFanGuard";
            this.Text = "sData Manager - Fan Guard";
            this.Load += new System.EventHandler(this.frmFanGuard_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmFanGuard_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.numFanSize)).EndInit();
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
        private System.Windows.Forms.Button btnHelp;
    }
}