namespace RefplusWebtools.DataManager.Costing
{
    partial class FrmBacklog
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
            this.lvUnits = new System.Windows.Forms.ListView();
            this.machine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.module = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.modifier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rebalanced = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnUnbalanced = new System.Windows.Forms.RadioButton();
            this.btnNormal = new System.Windows.Forms.RadioButton();
            this.btnrebalance = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvUnits
            // 
            this.lvUnits.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.machine,
            this.module,
            this.Date,
            this.modifier,
            this.rebalanced});
            this.lvUnits.FullRowSelect = true;
            this.lvUnits.GridLines = true;
            this.lvUnits.HideSelection = false;
            this.lvUnits.Location = new System.Drawing.Point(13, 12);
            this.lvUnits.Name = "lvUnits";
            this.lvUnits.Size = new System.Drawing.Size(601, 406);
            this.lvUnits.TabIndex = 1;
            this.lvUnits.UseCompatibleStateImageBehavior = false;
            this.lvUnits.View = System.Windows.Forms.View.Details;
            // 
            // machine
            // 
            this.machine.Text = "Modified Machine";
            this.machine.Width = 120;
            // 
            // module
            // 
            this.module.Text = "Modified module";
            this.module.Width = 120;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.Width = 80;
            // 
            // modifier
            // 
            this.modifier.Text = "modifier";
            this.modifier.Width = 100;
            // 
            // rebalanced
            // 
            this.rebalanced.Text = "Rebalanced since?";
            this.rebalanced.Width = 100;
            // 
            // btnUnbalanced
            // 
            this.btnUnbalanced.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnUnbalanced.AutoSize = true;
            this.btnUnbalanced.Location = new System.Drawing.Point(620, 41);
            this.btnUnbalanced.Name = "btnUnbalanced";
            this.btnUnbalanced.Size = new System.Drawing.Size(77, 23);
            this.btnUnbalanced.TabIndex = 2;
            this.btnUnbalanced.TabStop = true;
            this.btnUnbalanced.Text = "radioButton1";
            this.btnUnbalanced.UseVisualStyleBackColor = true;
            // 
            // btnNormal
            // 
            this.btnNormal.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnNormal.AutoSize = true;
            this.btnNormal.Location = new System.Drawing.Point(620, 12);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(77, 23);
            this.btnNormal.TabIndex = 3;
            this.btnNormal.TabStop = true;
            this.btnNormal.Text = "radioButton2";
            this.btnNormal.UseVisualStyleBackColor = true;
            this.btnNormal.CheckedChanged += new System.EventHandler(this.btnNormal_CheckedChanged);
            // 
            // btnrebalance
            // 
            this.btnrebalance.Location = new System.Drawing.Point(620, 346);
            this.btnrebalance.Name = "btnrebalance";
            this.btnrebalance.Size = new System.Drawing.Size(226, 72);
            this.btnrebalance.TabIndex = 4;
            this.btnrebalance.Text = "button1";
            this.btnrebalance.UseVisualStyleBackColor = true;
            this.btnrebalance.Visible = false;
            this.btnrebalance.Click += new System.EventHandler(this.btnrebalance_Click);
            // 
            // FrmBacklog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 430);
            this.Controls.Add(this.btnrebalance);
            this.Controls.Add(this.btnNormal);
            this.Controls.Add(this.btnUnbalanced);
            this.Controls.Add(this.lvUnits);
            this.Name = "FrmBacklog";
            this.Text = "FrmBacklog";
            this.Load += new System.EventHandler(this.FrmBacklog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvUnits;
        private System.Windows.Forms.ColumnHeader machine;
        private System.Windows.Forms.ColumnHeader module;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader modifier;
        private System.Windows.Forms.ColumnHeader rebalanced;
        private System.Windows.Forms.RadioButton btnUnbalanced;
        private System.Windows.Forms.RadioButton btnNormal;
        private System.Windows.Forms.Button btnrebalance;
    }
}