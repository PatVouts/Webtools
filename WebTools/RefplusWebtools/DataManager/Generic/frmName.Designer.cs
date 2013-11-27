namespace RefplusWebtools.DataManager.Generic
{
    partial class FrmName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmName));
            this.lblText = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmd_delete = new System.Windows.Forms.Button();
            this.cmd_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(13, 13);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(35, 13);
            this.lblText.TabIndex = 1;
            this.lblText.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(276, 20);
            this.textBox1.TabIndex = 2;
            // 
            // cmd_delete
            // 
            this.cmd_delete.Image = ((System.Drawing.Image)(resources.GetObject("cmd_delete.Image")));
            this.cmd_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmd_delete.Location = new System.Drawing.Point(262, 108);
            this.cmd_delete.Name = "cmd_delete";
            this.cmd_delete.Size = new System.Drawing.Size(126, 24);
            this.cmd_delete.TabIndex = 11;
            this.cmd_delete.Text = "sDelete Kit";
            this.cmd_delete.UseVisualStyleBackColor = true;
            this.cmd_delete.Click += new System.EventHandler(this.cmd_delete_Click);
            // 
            // cmd_save
            // 
            this.cmd_save.Image = ((System.Drawing.Image)(resources.GetObject("cmd_save.Image")));
            this.cmd_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmd_save.Location = new System.Drawing.Point(112, 108);
            this.cmd_save.Name = "cmd_save";
            this.cmd_save.Size = new System.Drawing.Size(125, 24);
            this.cmd_save.TabIndex = 10;
            this.cmd_save.Text = "sSave Kit";
            this.cmd_save.UseVisualStyleBackColor = true;
            this.cmd_save.Click += new System.EventHandler(this.cmd_save_Click);
            // 
            // frmName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(395, 142);
            this.Controls.Add(this.cmd_delete);
            this.Controls.Add(this.cmd_save);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblText);
            this.Name = "FrmName";
            this.Text = "frmName";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button cmd_delete;
        private System.Windows.Forms.Button cmd_save;
    }
}