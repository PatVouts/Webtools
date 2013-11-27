namespace RefplusWebtools.QuickEvaporator
{
    partial class FrmEvaporatorCoating
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEvaporatorCoating));
            this.cboCoilCoating = new System.Windows.Forms.ComboBox();
            this.lblCoilCoating = new System.Windows.Forms.Label();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboCoilCoating
            // 
            this.cboCoilCoating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCoilCoating.FormattingEnabled = true;
            this.cboCoilCoating.Location = new System.Drawing.Point(159, 6);
            this.cboCoilCoating.Name = "cboCoilCoating";
            this.cboCoilCoating.Size = new System.Drawing.Size(150, 21);
            this.cboCoilCoating.TabIndex = 74;
            // 
            // lblCoilCoating
            // 
            this.lblCoilCoating.AutoSize = true;
            this.lblCoilCoating.Location = new System.Drawing.Point(14, 9);
            this.lblCoilCoating.Name = "lblCoilCoating";
            this.lblCoilCoating.Size = new System.Drawing.Size(68, 13);
            this.lblCoilCoating.TabIndex = 75;
            this.lblCoilCoating.Text = "sCoil Coating";
            // 
            // cmdAccept
            // 
            this.cmdAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdAccept.Image = ((System.Drawing.Image)(resources.GetObject("cmdAccept.Image")));
            this.cmdAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAccept.Location = new System.Drawing.Point(86, 33);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(150, 25);
            this.cmdAccept.TabIndex = 76;
            this.cmdAccept.Text = "sAccept";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // frmEvaporatorCoating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(323, 65);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.cboCoilCoating);
            this.Controls.Add(this.lblCoilCoating);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEvaporatorCoating";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "sEvaporator Coating";
            this.Load += new System.EventHandler(this.frmEvaporatorCoating_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCoilCoating;
        private System.Windows.Forms.Label lblCoilCoating;
        private System.Windows.Forms.Button cmdAccept;
    }
}