namespace RefplusWebtools.DataManager.ControlPanel
{
    partial class frmControlPanelOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControlPanelOption));
            this.lblOption = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.txtOption = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblOption
            // 
            this.lblOption.AutoSize = true;
            this.lblOption.Location = new System.Drawing.Point(8, 19);
            this.lblOption.Name = "lblOption";
            this.lblOption.Size = new System.Drawing.Size(43, 13);
            this.lblOption.TabIndex = 1;
            this.lblOption.Text = "sOption";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(11, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "sSave";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(57, 19);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(65, 13);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "sDescription";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(60, 35);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(581, 20);
            this.txtDescription.TabIndex = 4;
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(498, 61);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(143, 23);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            // 
            // txtOption
            // 
            this.txtOption.Location = new System.Drawing.Point(11, 35);
            this.txtOption.Name = "txtOption";
            this.txtOption.Size = new System.Drawing.Size(40, 20);
            this.txtOption.TabIndex = 6;
            // 
            // frmControlPanelOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 91);
            this.Controls.Add(this.txtOption);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblOption);
            this.Name = "frmControlPanelOption";
            this.Text = "sControl Panel Option";
            this.Load += new System.EventHandler(this.frmControlPanelOption_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOption;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.TextBox txtOption;
    }
}