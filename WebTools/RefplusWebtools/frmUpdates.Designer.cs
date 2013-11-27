namespace RefplusWebtools
{
    partial class FrmUpdates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUpdates));
            this.tabUpdates = new System.Windows.Forms.TabControl();
            this.tabBugFixes = new System.Windows.Forms.TabPage();
            this.dgBugFix = new System.Windows.Forms.DataGridView();
            this.tabImprovements = new System.Windows.Forms.TabPage();
            this.dgImprovements = new System.Windows.Forms.DataGridView();
            this.tabFormation = new System.Windows.Forms.TabPage();
            this.btn_OpenDocument = new System.Windows.Forms.Button();
            this.dgFormation = new System.Windows.Forms.DataGridView();
            this.cmdClose = new System.Windows.Forms.Button();
            this.tabUpdates.SuspendLayout();
            this.tabBugFixes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBugFix)).BeginInit();
            this.tabImprovements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgImprovements)).BeginInit();
            this.tabFormation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFormation)).BeginInit();
            this.SuspendLayout();
            // 
            // tabUpdates
            // 
            this.tabUpdates.Controls.Add(this.tabBugFixes);
            this.tabUpdates.Controls.Add(this.tabImprovements);
            this.tabUpdates.Controls.Add(this.tabFormation);
            this.tabUpdates.Location = new System.Drawing.Point(12, 13);
            this.tabUpdates.Name = "tabUpdates";
            this.tabUpdates.SelectedIndex = 0;
            this.tabUpdates.Size = new System.Drawing.Size(580, 292);
            this.tabUpdates.TabIndex = 0;
            this.tabUpdates.Tag = "";
            // 
            // tabBugFixes
            // 
            this.tabBugFixes.Controls.Add(this.dgBugFix);
            this.tabBugFixes.Location = new System.Drawing.Point(4, 22);
            this.tabBugFixes.Name = "tabBugFixes";
            this.tabBugFixes.Padding = new System.Windows.Forms.Padding(3);
            this.tabBugFixes.Size = new System.Drawing.Size(572, 266);
            this.tabBugFixes.TabIndex = 0;
            this.tabBugFixes.Text = "sBug Fixes";
            this.tabBugFixes.UseVisualStyleBackColor = true;
            // 
            // dgBugFix
            // 
            this.dgBugFix.AllowUserToAddRows = false;
            this.dgBugFix.AllowUserToDeleteRows = false;
            this.dgBugFix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBugFix.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgBugFix.Location = new System.Drawing.Point(0, 0);
            this.dgBugFix.Name = "dgBugFix";
            this.dgBugFix.Size = new System.Drawing.Size(576, 263);
            this.dgBugFix.TabIndex = 0;
            this.dgBugFix.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBugFix_CellContentClick);
            // 
            // tabImprovements
            // 
            this.tabImprovements.Controls.Add(this.dgImprovements);
            this.tabImprovements.Location = new System.Drawing.Point(4, 22);
            this.tabImprovements.Name = "tabImprovements";
            this.tabImprovements.Padding = new System.Windows.Forms.Padding(3);
            this.tabImprovements.Size = new System.Drawing.Size(572, 266);
            this.tabImprovements.TabIndex = 1;
            this.tabImprovements.Text = "sImprovements";
            this.tabImprovements.UseVisualStyleBackColor = true;
            // 
            // dgImprovements
            // 
            this.dgImprovements.AllowUserToAddRows = false;
            this.dgImprovements.AllowUserToDeleteRows = false;
            this.dgImprovements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgImprovements.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgImprovements.Location = new System.Drawing.Point(0, 0);
            this.dgImprovements.Name = "dgImprovements";
            this.dgImprovements.Size = new System.Drawing.Size(569, 263);
            this.dgImprovements.TabIndex = 0;
            // 
            // tabFormation
            // 
            this.tabFormation.Controls.Add(this.btn_OpenDocument);
            this.tabFormation.Controls.Add(this.dgFormation);
            this.tabFormation.Location = new System.Drawing.Point(4, 22);
            this.tabFormation.Name = "tabFormation";
            this.tabFormation.Padding = new System.Windows.Forms.Padding(3);
            this.tabFormation.Size = new System.Drawing.Size(572, 266);
            this.tabFormation.TabIndex = 2;
            this.tabFormation.Text = "sFormation";
            this.tabFormation.UseVisualStyleBackColor = true;
            // 
            // btn_OpenDocument
            // 
            this.btn_OpenDocument.Location = new System.Drawing.Point(388, 231);
            this.btn_OpenDocument.Name = "btn_OpenDocument";
            this.btn_OpenDocument.Size = new System.Drawing.Size(181, 29);
            this.btn_OpenDocument.TabIndex = 1;
            this.btn_OpenDocument.Text = "sOpen Formation Document";
            this.btn_OpenDocument.UseVisualStyleBackColor = true;
            this.btn_OpenDocument.Click += new System.EventHandler(this.btn_OpenDocument_Click);
            // 
            // dgFormation
            // 
            this.dgFormation.AllowUserToAddRows = false;
            this.dgFormation.AllowUserToDeleteRows = false;
            this.dgFormation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFormation.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgFormation.Location = new System.Drawing.Point(0, 0);
            this.dgFormation.MultiSelect = false;
            this.dgFormation.Name = "dgFormation";
            this.dgFormation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFormation.Size = new System.Drawing.Size(569, 225);
            this.dgFormation.TabIndex = 0;
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(438, 313);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(150, 25);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmUpdates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(604, 350);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.tabUpdates);
            this.Name = "FrmUpdates";
            this.Text = "frmUpdates";
            this.Load += new System.EventHandler(this.frmUpdates_Load);
            this.tabUpdates.ResumeLayout(false);
            this.tabBugFixes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBugFix)).EndInit();
            this.tabImprovements.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgImprovements)).EndInit();
            this.tabFormation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFormation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabUpdates;
        private System.Windows.Forms.TabPage tabBugFixes;
        private System.Windows.Forms.TabPage tabImprovements;
        private System.Windows.Forms.TabPage tabFormation;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.DataGridView dgBugFix;
        private System.Windows.Forms.DataGridView dgImprovements;
        private System.Windows.Forms.Button btn_OpenDocument;
        private System.Windows.Forms.DataGridView dgFormation;
    }
}