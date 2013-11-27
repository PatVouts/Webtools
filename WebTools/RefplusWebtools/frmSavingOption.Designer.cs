namespace RefplusWebtools
{
    partial class FrmSavingOption
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmdOverwrite = new System.Windows.Forms.Button();
            this.cmdSaveAsCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "sThis unit is part of a quote. You may overwrite it or save as a copy.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdOverwrite
            // 
            this.cmdOverwrite.Location = new System.Drawing.Point(12, 51);
            this.cmdOverwrite.Name = "cmdOverwrite";
            this.cmdOverwrite.Size = new System.Drawing.Size(152, 31);
            this.cmdOverwrite.TabIndex = 0;
            this.cmdOverwrite.Text = "sOverwrite";
            this.cmdOverwrite.UseVisualStyleBackColor = true;
            this.cmdOverwrite.Click += new System.EventHandler(this.cmdOverwrite_Click);
            // 
            // cmdSaveAsCopy
            // 
            this.cmdSaveAsCopy.Location = new System.Drawing.Point(185, 51);
            this.cmdSaveAsCopy.Name = "cmdSaveAsCopy";
            this.cmdSaveAsCopy.Size = new System.Drawing.Size(152, 31);
            this.cmdSaveAsCopy.TabIndex = 1;
            this.cmdSaveAsCopy.Text = "sSave as copy";
            this.cmdSaveAsCopy.UseVisualStyleBackColor = true;
            this.cmdSaveAsCopy.Click += new System.EventHandler(this.cmdSaveAsCopy_Click);
            // 
            // frmSavingOption
            // 
            this.AcceptButton = this.cmdOverwrite;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(349, 95);
            this.ControlBox = false;
            this.Controls.Add(this.cmdSaveAsCopy);
            this.Controls.Add(this.cmdOverwrite);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmSavingOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "sSaving Option";
            this.Load += new System.EventHandler(this.frmSavingOption_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdOverwrite;
        private System.Windows.Forms.Button cmdSaveAsCopy;
    }
}