namespace RefplusWebtools.DataManager.Pricing
{
    partial class FrmControlPanelPanelAndOptionPrices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmControlPanelPanelAndOptionPrices));
            this.cboPanel = new System.Windows.Forms.ComboBox();
            this.cboFanArrangement = new System.Windows.Forms.ComboBox();
            this.dgPanelOptionPrices = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.numPanelPrice = new System.Windows.Forms.NumericUpDown();
            this.lblPanelPrice = new System.Windows.Forms.Label();
            this.chkSpecialPrice = new System.Windows.Forms.CheckBox();
            this.lblNotAvailable = new System.Windows.Forms.Label();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdMultiUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgPanelOptionPrices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPanelPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // cboPanel
            // 
            this.cboPanel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPanel.FormattingEnabled = true;
            this.cboPanel.Location = new System.Drawing.Point(4, 5);
            this.cboPanel.Name = "cboPanel";
            this.cboPanel.Size = new System.Drawing.Size(74, 21);
            this.cboPanel.TabIndex = 0;
            this.cboPanel.SelectedIndexChanged += new System.EventHandler(this.cboPanel_SelectedIndexChanged);
            // 
            // cboFanArrangement
            // 
            this.cboFanArrangement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFanArrangement.FormattingEnabled = true;
            this.cboFanArrangement.Location = new System.Drawing.Point(84, 5);
            this.cboFanArrangement.Name = "cboFanArrangement";
            this.cboFanArrangement.Size = new System.Drawing.Size(74, 21);
            this.cboFanArrangement.TabIndex = 1;
            this.cboFanArrangement.SelectedIndexChanged += new System.EventHandler(this.cboFanArrangement_SelectedIndexChanged);
            // 
            // dgPanelOptionPrices
            // 
            this.dgPanelOptionPrices.AllowUserToAddRows = false;
            this.dgPanelOptionPrices.AllowUserToDeleteRows = false;
            this.dgPanelOptionPrices.AllowUserToResizeColumns = false;
            this.dgPanelOptionPrices.AllowUserToResizeRows = false;
            this.dgPanelOptionPrices.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgPanelOptionPrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPanelOptionPrices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgPanelOptionPrices.Location = new System.Drawing.Point(4, 32);
            this.dgPanelOptionPrices.Name = "dgPanelOptionPrices";
            this.dgPanelOptionPrices.RowHeadersWidth = 25;
            this.dgPanelOptionPrices.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgPanelOptionPrices.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgPanelOptionPrices.Size = new System.Drawing.Size(573, 600);
            this.dgPanelOptionPrices.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Option";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Voltage-1";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 70;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Voltage-2";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 70;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Voltage-3";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 70;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Voltage-5";
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 70;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Voltage-6";
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 70;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Voltage-8";
            this.Column7.Name = "Column7";
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Width = 70;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Voltage-9";
            this.Column8.Name = "Column8";
            this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column8.Width = 70;
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(427, 638);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(150, 25);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(4, 638);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(150, 25);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // numPanelPrice
            // 
            this.numPanelPrice.DecimalPlaces = 2;
            this.numPanelPrice.Location = new System.Drawing.Point(227, 5);
            this.numPanelPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPanelPrice.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.numPanelPrice.Name = "numPanelPrice";
            this.numPanelPrice.Size = new System.Drawing.Size(88, 20);
            this.numPanelPrice.TabIndex = 6;
            // 
            // lblPanelPrice
            // 
            this.lblPanelPrice.AutoSize = true;
            this.lblPanelPrice.Location = new System.Drawing.Point(164, 8);
            this.lblPanelPrice.Name = "lblPanelPrice";
            this.lblPanelPrice.Size = new System.Drawing.Size(66, 13);
            this.lblPanelPrice.TabIndex = 7;
            this.lblPanelPrice.Text = "sPanel Price";
            // 
            // chkSpecialPrice
            // 
            this.chkSpecialPrice.AutoSize = true;
            this.chkSpecialPrice.Location = new System.Drawing.Point(321, 6);
            this.chkSpecialPrice.Name = "chkSpecialPrice";
            this.chkSpecialPrice.Size = new System.Drawing.Size(93, 17);
            this.chkSpecialPrice.TabIndex = 8;
            this.chkSpecialPrice.Text = "sSpecial Price";
            this.chkSpecialPrice.UseVisualStyleBackColor = true;
            // 
            // lblNotAvailable
            // 
            this.lblNotAvailable.ForeColor = System.Drawing.Color.Red;
            this.lblNotAvailable.Location = new System.Drawing.Point(175, 637);
            this.lblNotAvailable.Name = "lblNotAvailable";
            this.lblNotAvailable.Size = new System.Drawing.Size(229, 27);
            this.lblNotAvailable.TabIndex = 9;
            this.lblNotAvailable.Text = "sUse -1000000 (-1 million) to say the option / panel is not available";
            this.lblNotAvailable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdReset
            // 
            this.cmdReset.Location = new System.Drawing.Point(420, 3);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(101, 23);
            this.cmdReset.TabIndex = 10;
            this.cmdReset.Text = "sReset Prices";
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdMultiUpdate
            // 
            this.cmdMultiUpdate.Location = new System.Drawing.Point(583, 32);
            this.cmdMultiUpdate.Name = "cmdMultiUpdate";
            this.cmdMultiUpdate.Size = new System.Drawing.Size(140, 94);
            this.cmdMultiUpdate.TabIndex = 11;
            this.cmdMultiUpdate.Text = "sMulti Update";
            this.cmdMultiUpdate.UseVisualStyleBackColor = true;
            this.cmdMultiUpdate.Click += new System.EventHandler(this.cmdMultiUpdate_Click);
            // 
            // frmControlPanelPanelAndOptionPrices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(736, 666);
            this.Controls.Add(this.cmdMultiUpdate);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.lblNotAvailable);
            this.Controls.Add(this.chkSpecialPrice);
            this.Controls.Add(this.lblPanelPrice);
            this.Controls.Add(this.numPanelPrice);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.dgPanelOptionPrices);
            this.Controls.Add(this.cboFanArrangement);
            this.Controls.Add(this.cboPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmControlPanelPanelAndOptionPrices";
            this.Text = "sData Manager - Control Panel - Panel and Option Pricing";
            this.Load += new System.EventHandler(this.frmControlPanelPanelAndOptionPrices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPanelOptionPrices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPanelPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPanel;
        private System.Windows.Forms.ComboBox cboFanArrangement;
        private System.Windows.Forms.DataGridView dgPanelOptionPrices;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.NumericUpDown numPanelPrice;
        private System.Windows.Forms.Label lblPanelPrice;
        private System.Windows.Forms.CheckBox chkSpecialPrice;
        private System.Windows.Forms.Label lblNotAvailable;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdMultiUpdate;
    }
}