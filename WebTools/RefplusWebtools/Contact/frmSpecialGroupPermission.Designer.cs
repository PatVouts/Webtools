namespace RefplusWebtools.Contact
{
    partial class FrmSpecialGroupPermission
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
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn4 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn5 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn6 = new GlacialComponents.Controls.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSpecialGroupPermission));
            this.lstUser = new GlacialComponents.Controls.GlacialList();
            this.lstUnassignedGroups = new GlacialComponents.Controls.GlacialList();
            this.lstAssignedGroups = new GlacialComponents.Controls.GlacialList();
            this.picAdd = new System.Windows.Forms.PictureBox();
            this.picRemove = new System.Windows.Forms.PictureBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblAssignableGroups = new System.Windows.Forms.Label();
            this.lblGroupAssignedTo = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRemove)).BeginInit();
            this.SuspendLayout();
            // 
            // lstUser
            // 
            this.lstUser.AllowColumnResize = true;
            this.lstUser.AllowMultiselect = false;
            this.lstUser.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lstUser.AlternatingColors = false;
            this.lstUser.AutoHeight = true;
            this.lstUser.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lstUser.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1";
            glColumn1.NumericSort = false;
            glColumn1.Text = "sUsername";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 0;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column2";
            glColumn2.NumericSort = false;
            glColumn2.Text = "sName";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 250;
            this.lstUser.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2});
            this.lstUser.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lstUser.FullRowSelect = true;
            this.lstUser.GridColor = System.Drawing.Color.LightGray;
            this.lstUser.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lstUser.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridSolid;
            this.lstUser.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lstUser.HeaderHeight = 22;
            this.lstUser.HeaderVisible = true;
            this.lstUser.HeaderWordWrap = false;
            this.lstUser.HotColumnTracking = false;
            this.lstUser.HotItemTracking = false;
            this.lstUser.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lstUser.HoverEvents = false;
            this.lstUser.HoverTime = 1;
            this.lstUser.ImageList = null;
            this.lstUser.ItemHeight = 17;
            this.lstUser.ItemWordWrap = false;
            this.lstUser.Location = new System.Drawing.Point(7, 21);
            this.lstUser.Name = "lstUser";
            this.lstUser.Selectable = true;
            this.lstUser.SelectedTextColor = System.Drawing.Color.White;
            this.lstUser.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lstUser.ShowBorder = true;
            this.lstUser.ShowFocusRect = false;
            this.lstUser.Size = new System.Drawing.Size(277, 450);
            this.lstUser.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lstUser.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lstUser.TabIndex = 0;
            this.lstUser.Text = "glacialList1";
            this.lstUser.Click += new System.EventHandler(this.lstUser_Click);
            // 
            // lstUnassignedGroups
            // 
            this.lstUnassignedGroups.AllowColumnResize = true;
            this.lstUnassignedGroups.AllowMultiselect = false;
            this.lstUnassignedGroups.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lstUnassignedGroups.AlternatingColors = false;
            this.lstUnassignedGroups.AutoHeight = true;
            this.lstUnassignedGroups.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lstUnassignedGroups.BackgroundStretchToFit = true;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Column1";
            glColumn3.NumericSort = false;
            glColumn3.Text = "sGroupID";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 0;
            glColumn4.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn4.CheckBoxes = false;
            glColumn4.DatetimeSort = false;
            glColumn4.ImageIndex = -1;
            glColumn4.Name = "Column2";
            glColumn4.NumericSort = false;
            glColumn4.Text = "sGroup Name";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn4.Width = 200;
            this.lstUnassignedGroups.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn3,
            glColumn4});
            this.lstUnassignedGroups.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lstUnassignedGroups.FullRowSelect = true;
            this.lstUnassignedGroups.GridColor = System.Drawing.Color.LightGray;
            this.lstUnassignedGroups.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lstUnassignedGroups.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridSolid;
            this.lstUnassignedGroups.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lstUnassignedGroups.HeaderHeight = 22;
            this.lstUnassignedGroups.HeaderVisible = true;
            this.lstUnassignedGroups.HeaderWordWrap = false;
            this.lstUnassignedGroups.HotColumnTracking = false;
            this.lstUnassignedGroups.HotItemTracking = false;
            this.lstUnassignedGroups.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lstUnassignedGroups.HoverEvents = false;
            this.lstUnassignedGroups.HoverTime = 1;
            this.lstUnassignedGroups.ImageList = null;
            this.lstUnassignedGroups.ItemHeight = 17;
            this.lstUnassignedGroups.ItemWordWrap = false;
            this.lstUnassignedGroups.Location = new System.Drawing.Point(290, 21);
            this.lstUnassignedGroups.Name = "lstUnassignedGroups";
            this.lstUnassignedGroups.Selectable = true;
            this.lstUnassignedGroups.SelectedTextColor = System.Drawing.Color.White;
            this.lstUnassignedGroups.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lstUnassignedGroups.ShowBorder = true;
            this.lstUnassignedGroups.ShowFocusRect = false;
            this.lstUnassignedGroups.Size = new System.Drawing.Size(226, 450);
            this.lstUnassignedGroups.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lstUnassignedGroups.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lstUnassignedGroups.TabIndex = 1;
            this.lstUnassignedGroups.Text = "glacialList1";
            // 
            // lstAssignedGroups
            // 
            this.lstAssignedGroups.AllowColumnResize = true;
            this.lstAssignedGroups.AllowMultiselect = false;
            this.lstAssignedGroups.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lstAssignedGroups.AlternatingColors = false;
            this.lstAssignedGroups.AutoHeight = true;
            this.lstAssignedGroups.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lstAssignedGroups.BackgroundStretchToFit = true;
            glColumn5.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn5.CheckBoxes = false;
            glColumn5.DatetimeSort = false;
            glColumn5.ImageIndex = -1;
            glColumn5.Name = "Column1";
            glColumn5.NumericSort = false;
            glColumn5.Text = "sGroupID";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn5.Width = 0;
            glColumn6.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn6.CheckBoxes = false;
            glColumn6.DatetimeSort = false;
            glColumn6.ImageIndex = -1;
            glColumn6.Name = "Column2";
            glColumn6.NumericSort = false;
            glColumn6.Text = "sGroup Name";
            glColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn6.Width = 200;
            this.lstAssignedGroups.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn5,
            glColumn6});
            this.lstAssignedGroups.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lstAssignedGroups.FullRowSelect = true;
            this.lstAssignedGroups.GridColor = System.Drawing.Color.LightGray;
            this.lstAssignedGroups.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lstAssignedGroups.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridSolid;
            this.lstAssignedGroups.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lstAssignedGroups.HeaderHeight = 22;
            this.lstAssignedGroups.HeaderVisible = true;
            this.lstAssignedGroups.HeaderWordWrap = false;
            this.lstAssignedGroups.HotColumnTracking = false;
            this.lstAssignedGroups.HotItemTracking = false;
            this.lstAssignedGroups.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lstAssignedGroups.HoverEvents = false;
            this.lstAssignedGroups.HoverTime = 1;
            this.lstAssignedGroups.ImageList = null;
            this.lstAssignedGroups.ItemHeight = 17;
            this.lstAssignedGroups.ItemWordWrap = false;
            this.lstAssignedGroups.Location = new System.Drawing.Point(544, 21);
            this.lstAssignedGroups.Name = "lstAssignedGroups";
            this.lstAssignedGroups.Selectable = true;
            this.lstAssignedGroups.SelectedTextColor = System.Drawing.Color.White;
            this.lstAssignedGroups.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lstAssignedGroups.ShowBorder = true;
            this.lstAssignedGroups.ShowFocusRect = false;
            this.lstAssignedGroups.Size = new System.Drawing.Size(226, 450);
            this.lstAssignedGroups.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lstAssignedGroups.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lstAssignedGroups.TabIndex = 2;
            this.lstAssignedGroups.Text = "glacialList1";
            // 
            // picAdd
            // 
            this.picAdd.Image = ((System.Drawing.Image)(resources.GetObject("picAdd.Image")));
            this.picAdd.Location = new System.Drawing.Point(522, 201);
            this.picAdd.Name = "picAdd";
            this.picAdd.Size = new System.Drawing.Size(16, 16);
            this.picAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picAdd.TabIndex = 79;
            this.picAdd.TabStop = false;
            this.picAdd.Click += new System.EventHandler(this.picAdd_Click);
            // 
            // picRemove
            // 
            this.picRemove.Image = ((System.Drawing.Image)(resources.GetObject("picRemove.Image")));
            this.picRemove.Location = new System.Drawing.Point(522, 256);
            this.picRemove.Name = "picRemove";
            this.picRemove.Size = new System.Drawing.Size(16, 16);
            this.picRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picRemove.TabIndex = 80;
            this.picRemove.TabStop = false;
            this.picRemove.Click += new System.EventHandler(this.picRemove_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(12, 5);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(34, 13);
            this.lblUser.TabIndex = 81;
            this.lblUser.Text = "sUser";
            // 
            // lblAssignableGroups
            // 
            this.lblAssignableGroups.AutoSize = true;
            this.lblAssignableGroups.Location = new System.Drawing.Point(287, 5);
            this.lblAssignableGroups.Name = "lblAssignableGroups";
            this.lblAssignableGroups.Size = new System.Drawing.Size(98, 13);
            this.lblAssignableGroups.TabIndex = 82;
            this.lblAssignableGroups.Text = "sAssignable groups";
            // 
            // lblGroupAssignedTo
            // 
            this.lblGroupAssignedTo.AutoSize = true;
            this.lblGroupAssignedTo.Location = new System.Drawing.Point(541, 5);
            this.lblGroupAssignedTo.Name = "lblGroupAssignedTo";
            this.lblGroupAssignedTo.Size = new System.Drawing.Size(164, 13);
            this.lblGroupAssignedTo.TabIndex = 83;
            this.lblGroupAssignedTo.Text = "sGroup assigned to selected user";
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(544, 477);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(226, 26);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(7, 478);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmSpecialGroupPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(781, 507);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.lblGroupAssignedTo);
            this.Controls.Add(this.lblAssignableGroups);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.picRemove);
            this.Controls.Add(this.picAdd);
            this.Controls.Add(this.lstAssignedGroups);
            this.Controls.Add(this.lstUnassignedGroups);
            this.Controls.Add(this.lstUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSpecialGroupPermission";
            this.Text = "sSpecial Group Permission";
            this.Load += new System.EventHandler(this.frmSpecialGroupPermission_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmSpecialGroupPermission_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRemove)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GlacialComponents.Controls.GlacialList lstUser;
        private GlacialComponents.Controls.GlacialList lstUnassignedGroups;
        private GlacialComponents.Controls.GlacialList lstAssignedGroups;
        private System.Windows.Forms.PictureBox picAdd;
        private System.Windows.Forms.PictureBox picRemove;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblAssignableGroups;
        private System.Windows.Forms.Label lblGroupAssignedTo;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button btnHelp;
    }
}