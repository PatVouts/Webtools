namespace RefplusWebtools.Contact
{
    partial class FrmContactManager
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
            GlacialComponents.Controls.GLColumn glColumn7 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn8 = new GlacialComponents.Controls.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmContactManager));
            this.lstContact = new GlacialComponents.Controls.GlacialList();
            this.cmdAddContact = new System.Windows.Forms.Button();
            this.lblGroupFilter = new System.Windows.Forms.Label();
            this.cboGroupList = new System.Windows.Forms.ComboBox();
            this.cmdManageGroups = new System.Windows.Forms.Button();
            this.chkUserManagingMode = new System.Windows.Forms.CheckBox();
            this.lblFilterByLetter = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstContact
            // 
            this.lstContact.AllowColumnResize = true;
            this.lstContact.AllowMultiselect = false;
            this.lstContact.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lstContact.AlternatingColors = false;
            this.lstContact.AutoHeight = false;
            this.lstContact.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lstContact.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1";
            glColumn1.NumericSort = false;
            glColumn1.Text = "ContactID";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 0;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column1x";
            glColumn2.NumericSort = false;
            glColumn2.Text = "sName";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 150;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Column2";
            glColumn3.NumericSort = false;
            glColumn3.Text = "sTitle";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 100;
            glColumn4.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn4.CheckBoxes = false;
            glColumn4.DatetimeSort = false;
            glColumn4.ImageIndex = -1;
            glColumn4.Name = "Column1xx";
            glColumn4.NumericSort = false;
            glColumn4.Text = "sCompany";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn4.Width = 150;
            glColumn5.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn5.CheckBoxes = false;
            glColumn5.DatetimeSort = false;
            glColumn5.ImageIndex = -1;
            glColumn5.Name = "Column3";
            glColumn5.NumericSort = false;
            glColumn5.Text = "sPhone";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn5.Width = 100;
            glColumn6.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn6.CheckBoxes = false;
            glColumn6.DatetimeSort = false;
            glColumn6.ImageIndex = -1;
            glColumn6.Name = "Column4";
            glColumn6.NumericSort = false;
            glColumn6.Text = "sExt";
            glColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn6.Width = 40;
            glColumn7.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn7.CheckBoxes = false;
            glColumn7.DatetimeSort = false;
            glColumn7.ImageIndex = -1;
            glColumn7.Name = "Column5";
            glColumn7.NumericSort = false;
            glColumn7.Text = "sEmail";
            glColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn7.Width = 120;
            glColumn8.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn8.CheckBoxes = false;
            glColumn8.DatetimeSort = false;
            glColumn8.ImageIndex = -1;
            glColumn8.Name = "Column2x";
            glColumn8.NumericSort = false;
            glColumn8.Text = "sEdit";
            glColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn8.Width = 60;
            this.lstContact.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3,
            glColumn4,
            glColumn5,
            glColumn6,
            glColumn7,
            glColumn8});
            this.lstContact.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lstContact.FullRowSelect = true;
            this.lstContact.GridColor = System.Drawing.Color.LightGray;
            this.lstContact.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lstContact.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridSolid;
            this.lstContact.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lstContact.HeaderHeight = 22;
            this.lstContact.HeaderVisible = true;
            this.lstContact.HeaderWordWrap = false;
            this.lstContact.HotColumnTracking = false;
            this.lstContact.HotItemTracking = false;
            this.lstContact.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lstContact.HoverEvents = false;
            this.lstContact.HoverTime = 1;
            this.lstContact.ImageList = null;
            this.lstContact.ItemHeight = 24;
            this.lstContact.ItemWordWrap = false;
            this.lstContact.Location = new System.Drawing.Point(12, 38);
            this.lstContact.Name = "lstContact";
            this.lstContact.Selectable = true;
            this.lstContact.SelectedTextColor = System.Drawing.Color.White;
            this.lstContact.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lstContact.ShowBorder = true;
            this.lstContact.ShowFocusRect = false;
            this.lstContact.Size = new System.Drawing.Size(742, 569);
            this.lstContact.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lstContact.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lstContact.TabIndex = 0;
            this.lstContact.Text = "glacialList1";
            this.lstContact.DoubleClick += new System.EventHandler(this.lstContact_DoubleClick);
            this.lstContact.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstContact_KeyDown);
            // 
            // cmdAddContact
            // 
            this.cmdAddContact.Image = ((System.Drawing.Image)(resources.GetObject("cmdAddContact.Image")));
            this.cmdAddContact.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAddContact.Location = new System.Drawing.Point(12, 609);
            this.cmdAddContact.Name = "cmdAddContact";
            this.cmdAddContact.Size = new System.Drawing.Size(116, 25);
            this.cmdAddContact.TabIndex = 1;
            this.cmdAddContact.Text = "sAdd Contact";
            this.cmdAddContact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAddContact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAddContact.UseVisualStyleBackColor = true;
            this.cmdAddContact.Click += new System.EventHandler(this.cmdAddContact_Click);
            // 
            // lblGroupFilter
            // 
            this.lblGroupFilter.AutoSize = true;
            this.lblGroupFilter.Location = new System.Drawing.Point(441, 616);
            this.lblGroupFilter.Name = "lblGroupFilter";
            this.lblGroupFilter.Size = new System.Drawing.Size(66, 13);
            this.lblGroupFilter.TabIndex = 2;
            this.lblGroupFilter.Text = "sFilter Group";
            // 
            // cboGroupList
            // 
            this.cboGroupList.DropDownHeight = 500;
            this.cboGroupList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGroupList.DropDownWidth = 300;
            this.cboGroupList.FormattingEnabled = true;
            this.cboGroupList.IntegralHeight = false;
            this.cboGroupList.Location = new System.Drawing.Point(537, 613);
            this.cboGroupList.Name = "cboGroupList";
            this.cboGroupList.Size = new System.Drawing.Size(217, 21);
            this.cboGroupList.TabIndex = 5;
            this.cboGroupList.SelectedIndexChanged += new System.EventHandler(this.cboGroupList_SelectedIndexChanged);
            // 
            // cmdManageGroups
            // 
            this.cmdManageGroups.Image = ((System.Drawing.Image)(resources.GetObject("cmdManageGroups.Image")));
            this.cmdManageGroups.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdManageGroups.Location = new System.Drawing.Point(134, 609);
            this.cmdManageGroups.Name = "cmdManageGroups";
            this.cmdManageGroups.Size = new System.Drawing.Size(116, 25);
            this.cmdManageGroups.TabIndex = 2;
            this.cmdManageGroups.Text = "sManage Groups";
            this.cmdManageGroups.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdManageGroups.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdManageGroups.UseVisualStyleBackColor = true;
            this.cmdManageGroups.Click += new System.EventHandler(this.cmdManageGroups_Click);
            // 
            // chkUserManagingMode
            // 
            this.chkUserManagingMode.AutoSize = true;
            this.chkUserManagingMode.Location = new System.Drawing.Point(256, 614);
            this.chkUserManagingMode.Name = "chkUserManagingMode";
            this.chkUserManagingMode.Size = new System.Drawing.Size(133, 17);
            this.chkUserManagingMode.TabIndex = 3;
            this.chkUserManagingMode.Text = "sUser Managing Mode";
            this.chkUserManagingMode.UseVisualStyleBackColor = true;
            this.chkUserManagingMode.Visible = false;
            // 
            // lblFilterByLetter
            // 
            this.lblFilterByLetter.AutoSize = true;
            this.lblFilterByLetter.Location = new System.Drawing.Point(12, 0);
            this.lblFilterByLetter.Name = "lblFilterByLetter";
            this.lblFilterByLetter.Size = new System.Drawing.Size(85, 13);
            this.lblFilterByLetter.TabIndex = 6;
            this.lblFilterByLetter.Text = "sFilter By Letter :";
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(401, 610);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmContactManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(766, 639);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblFilterByLetter);
            this.Controls.Add(this.chkUserManagingMode);
            this.Controls.Add(this.cmdManageGroups);
            this.Controls.Add(this.cboGroupList);
            this.Controls.Add(this.lblGroupFilter);
            this.Controls.Add(this.cmdAddContact);
            this.Controls.Add(this.lstContact);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmContactManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "sContact Manager";
            this.Load += new System.EventHandler(this.frmContactManager_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmContactManager_HelpRequested);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GlacialComponents.Controls.GlacialList lstContact;
        private System.Windows.Forms.Button cmdAddContact;
        private System.Windows.Forms.Label lblGroupFilter;
        private System.Windows.Forms.ComboBox cboGroupList;
        private System.Windows.Forms.Button cmdManageGroups;
        private System.Windows.Forms.CheckBox chkUserManagingMode;
        private System.Windows.Forms.Label lblFilterByLetter;
        private System.Windows.Forms.Button btnHelp;
    }
}