namespace RefplusWebtools.DataManager.Costing
{
    partial class FrmRatio
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
            this.lblRatio = new System.Windows.Forms.Label();
            this.num_Ratio = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_Ratio)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRatio
            // 
            this.lblRatio.AutoSize = true;
            this.lblRatio.Location = new System.Drawing.Point(13, 13);
            this.lblRatio.Name = "lblRatio";
            this.lblRatio.Size = new System.Drawing.Size(35, 13);
            this.lblRatio.TabIndex = 0;
            this.lblRatio.Text = "label1";
            // 
            // num_Ratio
            // 
            this.num_Ratio.Location = new System.Drawing.Point(16, 45);
            this.num_Ratio.Name = "num_Ratio";
            this.num_Ratio.Size = new System.Drawing.Size(86, 20);
            this.num_Ratio.TabIndex = 1;
            this.num_Ratio.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.num_Ratio.Enter += new System.EventHandler(this.num_Ratio_Enter);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 85);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "button1";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmRatio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(284, 133);
            this.ControlBox = false;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.num_Ratio);
            this.Controls.Add(this.lblRatio);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRatio";
            this.Text = "frmRatio";
            this.Load += new System.EventHandler(this.frmRatio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_Ratio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRatio;
        private System.Windows.Forms.NumericUpDown num_Ratio;
        private System.Windows.Forms.Button btnSave;
    }
}