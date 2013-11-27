namespace RefplusWebtools
{
    partial class FrmBugReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBugReport));
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.rdioBug = new System.Windows.Forms.RadioButton();
            this.rdioImprv = new System.Windows.Forms.RadioButton();
            this.lblType = new System.Windows.Forms.Label();
            this.cmb_Priority = new System.Windows.Forms.ComboBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.txtProblem = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblProblem = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdClear = new System.Windows.Forms.Button();
            this.cmdSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(116, 12);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(385, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(12, 15);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";
            // 
            // rdioBug
            // 
            this.rdioBug.AutoSize = true;
            this.rdioBug.Location = new System.Drawing.Point(116, 50);
            this.rdioBug.Name = "rdioBug";
            this.rdioBug.Size = new System.Drawing.Size(44, 17);
            this.rdioBug.TabIndex = 2;
            this.rdioBug.TabStop = true;
            this.rdioBug.Text = "Bug";
            this.rdioBug.UseVisualStyleBackColor = true;
            // 
            // rdioImprv
            // 
            this.rdioImprv.AutoSize = true;
            this.rdioImprv.Location = new System.Drawing.Point(116, 73);
            this.rdioImprv.Name = "rdioImprv";
            this.rdioImprv.Size = new System.Drawing.Size(140, 17);
            this.rdioImprv.TabIndex = 3;
            this.rdioImprv.TabStop = true;
            this.rdioImprv.Text = "Suggested Improvement";
            this.rdioImprv.UseVisualStyleBackColor = true;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(12, 64);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Type";
            // 
            // cmb_Priority
            // 
            this.cmb_Priority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Priority.FormattingEnabled = true;
            this.cmb_Priority.Items.AddRange(new object[] {
            "Critical (cannot work)",
            "High (workaround exists but is tedious and long)",
            "Medium (workaround)",
            "low (easy workaround / esthetic change)"});
            this.cmb_Priority.Location = new System.Drawing.Point(116, 111);
            this.cmb_Priority.Name = "cmb_Priority";
            this.cmb_Priority.Size = new System.Drawing.Size(385, 21);
            this.cmb_Priority.TabIndex = 5;
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(12, 119);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(38, 13);
            this.lblPriority.TabIndex = 6;
            this.lblPriority.Text = "Priority";
            // 
            // txtProblem
            // 
            this.txtProblem.Location = new System.Drawing.Point(116, 195);
            this.txtProblem.Multiline = true;
            this.txtProblem.Name = "txtProblem";
            this.txtProblem.Size = new System.Drawing.Size(385, 191);
            this.txtProblem.TabIndex = 7;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 160);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(68, 13);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Problem Title";
            // 
            // lblProblem
            // 
            this.lblProblem.AutoSize = true;
            this.lblProblem.Location = new System.Drawing.Point(12, 195);
            this.lblProblem.Name = "lblProblem";
            this.lblProblem.Size = new System.Drawing.Size(45, 13);
            this.lblProblem.TabIndex = 9;
            this.lblProblem.Text = "Problem";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(116, 153);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(385, 20);
            this.txtTitle.TabIndex = 10;
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(464, 392);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(150, 25);
            this.cmdClose.TabIndex = 11;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdClear
            // 
            this.cmdClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClear.Location = new System.Drawing.Point(241, 392);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(150, 25);
            this.cmdClear.TabIndex = 12;
            this.cmdClear.Text = "sClear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // cmdSend
            // 
            this.cmdSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSend.Location = new System.Drawing.Point(40, 392);
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.Size = new System.Drawing.Size(150, 25);
            this.cmdSend.TabIndex = 13;
            this.cmdSend.Text = "sSend";
            this.cmdSend.UseVisualStyleBackColor = true;
            this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
            // 
            // FrmBugReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(626, 424);
            this.Controls.Add(this.cmdSend);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblProblem);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtProblem);
            this.Controls.Add(this.lblPriority);
            this.Controls.Add(this.cmb_Priority);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.rdioImprv);
            this.Controls.Add(this.rdioBug);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Name = "FrmBugReport";
            this.Text = "FrmBugReport";
            this.Load += new System.EventHandler(this.FrmBugReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.RadioButton rdioBug;
        private System.Windows.Forms.RadioButton rdioImprv;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmb_Priority;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.TextBox txtProblem;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblProblem;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.Button cmdSend;
    }
}