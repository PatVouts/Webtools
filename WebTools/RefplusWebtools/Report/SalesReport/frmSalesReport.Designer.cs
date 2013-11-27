namespace RefplusWebtools.Report.SalesReport
{
    partial class FrmSalesReport
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
            this.sStartDate = new System.Windows.Forms.Label();
            this.sMinimumPrice = new System.Windows.Forms.Label();
            this.sEndDate = new System.Windows.Forms.Label();
            this.sMaximumPrice = new System.Windows.Forms.Label();
            this.d_Start = new System.Windows.Forms.DateTimePicker();
            this.d_End = new System.Windows.Forms.DateTimePicker();
            this.num_Minimum = new System.Windows.Forms.NumericUpDown();
            this.num_Maximum = new System.Windows.Forms.NumericUpDown();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkInternal = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.num_Minimum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Maximum)).BeginInit();
            this.SuspendLayout();
            // 
            // sStartDate
            // 
            this.sStartDate.AutoSize = true;
            this.sStartDate.Location = new System.Drawing.Point(26, 45);
            this.sStartDate.Name = "sStartDate";
            this.sStartDate.Size = new System.Drawing.Size(55, 13);
            this.sStartDate.TabIndex = 0;
            this.sStartDate.Text = "Start Date";
            // 
            // sMinimumPrice
            // 
            this.sMinimumPrice.AutoSize = true;
            this.sMinimumPrice.Location = new System.Drawing.Point(26, 84);
            this.sMinimumPrice.Name = "sMinimumPrice";
            this.sMinimumPrice.Size = new System.Drawing.Size(81, 13);
            this.sMinimumPrice.TabIndex = 1;
            this.sMinimumPrice.Text = "Minimum Price :";
            // 
            // sEndDate
            // 
            this.sEndDate.AutoSize = true;
            this.sEndDate.Location = new System.Drawing.Point(323, 45);
            this.sEndDate.Name = "sEndDate";
            this.sEndDate.Size = new System.Drawing.Size(52, 13);
            this.sEndDate.TabIndex = 2;
            this.sEndDate.Text = "End Date";
            // 
            // sMaximumPrice
            // 
            this.sMaximumPrice.AutoSize = true;
            this.sMaximumPrice.Location = new System.Drawing.Point(323, 84);
            this.sMaximumPrice.Name = "sMaximumPrice";
            this.sMaximumPrice.Size = new System.Drawing.Size(84, 13);
            this.sMaximumPrice.TabIndex = 3;
            this.sMaximumPrice.Text = "Maximum Price :";
            // 
            // d_Start
            // 
            this.d_Start.Location = new System.Drawing.Point(113, 39);
            this.d_Start.Name = "d_Start";
            this.d_Start.Size = new System.Drawing.Size(200, 20);
            this.d_Start.TabIndex = 1;
            // 
            // d_End
            // 
            this.d_End.Location = new System.Drawing.Point(381, 42);
            this.d_End.Name = "d_End";
            this.d_End.Size = new System.Drawing.Size(200, 20);
            this.d_End.TabIndex = 2;
            // 
            // num_Minimum
            // 
            this.num_Minimum.Location = new System.Drawing.Point(113, 82);
            this.num_Minimum.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.num_Minimum.Name = "num_Minimum";
            this.num_Minimum.Size = new System.Drawing.Size(120, 20);
            this.num_Minimum.TabIndex = 3;
            this.num_Minimum.Value = new decimal(new int[] {
            75000,
            0,
            0,
            0});
            // 
            // num_Maximum
            // 
            this.num_Maximum.Location = new System.Drawing.Point(422, 82);
            this.num_Maximum.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.num_Maximum.Name = "num_Maximum";
            this.num_Maximum.Size = new System.Drawing.Size(120, 20);
            this.num_Maximum.TabIndex = 4;
            this.num_Maximum.Value = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(131, 167);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(138, 23);
            this.btnFind.TabIndex = 6;
            this.btnFind.Text = "Find Quotes";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(275, 167);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(138, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkInternal
            // 
            this.chkInternal.AutoSize = true;
            this.chkInternal.Location = new System.Drawing.Point(29, 119);
            this.chkInternal.Name = "chkInternal";
            this.chkInternal.Size = new System.Drawing.Size(178, 17);
            this.chkInternal.TabIndex = 5;
            this.chkInternal.Text = "Quote created by internal sales?";
            this.chkInternal.UseVisualStyleBackColor = true;
            // 
            // FrmSalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 202);
            this.Controls.Add(this.chkInternal);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.num_Maximum);
            this.Controls.Add(this.num_Minimum);
            this.Controls.Add(this.d_End);
            this.Controls.Add(this.d_Start);
            this.Controls.Add(this.sMaximumPrice);
            this.Controls.Add(this.sEndDate);
            this.Controls.Add(this.sMinimumPrice);
            this.Controls.Add(this.sStartDate);
            this.Name = "FrmSalesReport";
            this.Text = "frmSalesReport";
            this.Load += new System.EventHandler(this.FrmSalesReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_Minimum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Maximum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sStartDate;
        private System.Windows.Forms.Label sMinimumPrice;
        private System.Windows.Forms.Label sEndDate;
        private System.Windows.Forms.Label sMaximumPrice;
        private System.Windows.Forms.DateTimePicker d_Start;
        private System.Windows.Forms.DateTimePicker d_End;
        private System.Windows.Forms.NumericUpDown num_Minimum;
        private System.Windows.Forms.NumericUpDown num_Maximum;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkInternal;
    }
}