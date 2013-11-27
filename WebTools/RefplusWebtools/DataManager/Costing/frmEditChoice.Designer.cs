namespace RefplusWebtools.DataManager.Costing
{
    partial class FrmEditChoice
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
            this.sModuleSelected = new System.Windows.Forms.Label();
            this.btn_EditPieces = new System.Windows.Forms.Button();
            this.btn_EditLogic = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sModuleSelected
            // 
            this.sModuleSelected.AutoSize = true;
            this.sModuleSelected.Enabled = false;
            this.sModuleSelected.Location = new System.Drawing.Point(31, 13);
            this.sModuleSelected.Name = "sModuleSelected";
            this.sModuleSelected.Size = new System.Drawing.Size(86, 13);
            this.sModuleSelected.TabIndex = 0;
            this.sModuleSelected.Text = "sModel Selected";
            // 
            // btn_EditPieces
            // 
            this.btn_EditPieces.Location = new System.Drawing.Point(34, 58);
            this.btn_EditPieces.Name = "btn_EditPieces";
            this.btn_EditPieces.Size = new System.Drawing.Size(180, 23);
            this.btn_EditPieces.TabIndex = 2;
            this.btn_EditPieces.Text = "sEdit pieces or price of module";
            this.btn_EditPieces.UseVisualStyleBackColor = true;
            this.btn_EditPieces.Click += new System.EventHandler(this.btn_EditPieces_Click);
            // 
            // btn_EditLogic
            // 
            this.btn_EditLogic.Location = new System.Drawing.Point(34, 87);
            this.btn_EditLogic.Name = "btn_EditLogic";
            this.btn_EditLogic.Size = new System.Drawing.Size(180, 23);
            this.btn_EditLogic.TabIndex = 3;
            this.btn_EditLogic.Text = "sEdit logic of module";
            this.btn_EditLogic.UseVisualStyleBackColor = true;
            this.btn_EditLogic.Click += new System.EventHandler(this.btn_EditLogic_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(34, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(180, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TabStop = false;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(34, 116);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(180, 23);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "sCancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // FrmEditChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 148);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_EditLogic);
            this.Controls.Add(this.btn_EditPieces);
            this.Controls.Add(this.sModuleSelected);
            this.Name = "FrmEditChoice";
            this.Text = "frmEditChoice";
            this.Load += new System.EventHandler(this.FrmEditChoice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sModuleSelected;
        private System.Windows.Forms.Button btn_EditPieces;
        private System.Windows.Forms.Button btn_EditLogic;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_Cancel;
    }
}