namespace RefplusWebtools.Contact
{
    partial class FrmContactGroupManager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmContactGroupManager));
            this.lblMultiplier = new System.Windows.Forms.Label();
            this.numMultiplier = new System.Windows.Forms.NumericUpDown();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.lvGroups = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tvParentGrouping = new System.Windows.Forms.TreeView();
            this.contextParentGroupList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsUnAttach = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cboGroupName = new System.Windows.Forms.ComboBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.lblAllGroups = new System.Windows.Forms.Label();
            this.lblGroupRelation = new System.Windows.Forms.Label();
            this.cmdManageSpecialGroupPermission = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numMultiplier)).BeginInit();
            this.contextParentGroupList.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMultiplier
            // 
            this.lblMultiplier.AutoSize = true;
            this.lblMultiplier.Location = new System.Drawing.Point(12, 455);
            this.lblMultiplier.Name = "lblMultiplier";
            this.lblMultiplier.Size = new System.Drawing.Size(53, 13);
            this.lblMultiplier.TabIndex = 2;
            this.lblMultiplier.Text = "sMultiplier";
            // 
            // numMultiplier
            // 
            this.numMultiplier.DecimalPlaces = 3;
            this.numMultiplier.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numMultiplier.Location = new System.Drawing.Point(15, 471);
            this.numMultiplier.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMultiplier.Name = "numMultiplier";
            this.numMultiplier.Size = new System.Drawing.Size(69, 20);
            this.numMultiplier.TabIndex = 2;
            this.numMultiplier.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(9, 427);
            this.txtGroupName.MaxLength = 50;
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(388, 20);
            this.txtGroupName.TabIndex = 4;
            this.txtGroupName.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Location = new System.Drawing.Point(9, 387);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(72, 13);
            this.lblGroupName.TabIndex = 5;
            this.lblGroupName.Text = "sGroup Name";
            // 
            // lvGroups
            // 
            this.lvGroups.AllowDrop = true;
            this.lvGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvGroups.FullRowSelect = true;
            this.lvGroups.GridLines = true;
            this.lvGroups.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvGroups.Location = new System.Drawing.Point(12, 22);
            this.lvGroups.Name = "lvGroups";
            this.lvGroups.Size = new System.Drawing.Size(385, 362);
            this.lvGroups.TabIndex = 0;
            this.lvGroups.UseCompatibleStateImageBehavior = false;
            this.lvGroups.View = System.Windows.Forms.View.Details;
            this.lvGroups.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvGroups_ItemDrag);
            this.lvGroups.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvGroups_MouseUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "sGroupID";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "sGroup Name";
            this.columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "sMultiplier";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 90;
            // 
            // tvParentGrouping
            // 
            this.tvParentGrouping.AllowDrop = true;
            this.tvParentGrouping.Location = new System.Drawing.Point(403, 22);
            this.tvParentGrouping.Name = "tvParentGrouping";
            this.tvParentGrouping.Size = new System.Drawing.Size(385, 362);
            this.tvParentGrouping.TabIndex = 4;
            this.tvParentGrouping.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvParentGrouping_DragDrop);
            this.tvParentGrouping.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvParentGrouping_DragEnter);
            this.tvParentGrouping.DragOver += new System.Windows.Forms.DragEventHandler(this.tvParentGrouping_DragOver);
            this.tvParentGrouping.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tvParentGrouping_MouseUp);
            // 
            // contextParentGroupList
            // 
            this.contextParentGroupList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsUnAttach,
            this.tsDelete});
            this.contextParentGroupList.Name = "contextParentGroupList";
            this.contextParentGroupList.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextParentGroupList.Size = new System.Drawing.Size(130, 48);
            // 
            // tsUnAttach
            // 
            this.tsUnAttach.Name = "tsUnAttach";
            this.tsUnAttach.Size = new System.Drawing.Size(129, 22);
            this.tsUnAttach.Text = "sUnAttach";
            this.tsUnAttach.Click += new System.EventHandler(this.tsUnAttach_Click);
            // 
            // tsDelete
            // 
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(129, 22);
            this.tsDelete.Text = "sDelete";
            this.tsDelete.Click += new System.EventHandler(this.tsDelete_Click);
            // 
            // cboGroupName
            // 
            this.cboGroupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGroupName.FormattingEnabled = true;
            this.cboGroupName.Location = new System.Drawing.Point(9, 403);
            this.cboGroupName.Name = "cboGroupName";
            this.cboGroupName.Size = new System.Drawing.Size(388, 21);
            this.cboGroupName.TabIndex = 1;
            this.cboGroupName.SelectedIndexChanged += new System.EventHandler(this.cboGroupName_SelectedIndexChanged);
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(90, 468);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(307, 26);
            this.cmdSave.TabIndex = 3;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(403, 468);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(385, 26);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // lblAllGroups
            // 
            this.lblAllGroups.AutoSize = true;
            this.lblAllGroups.Location = new System.Drawing.Point(12, 6);
            this.lblAllGroups.Name = "lblAllGroups";
            this.lblAllGroups.Size = new System.Drawing.Size(70, 13);
            this.lblAllGroups.TabIndex = 11;
            this.lblAllGroups.Text = "sGroup listing";
            // 
            // lblGroupRelation
            // 
            this.lblGroupRelation.AutoSize = true;
            this.lblGroupRelation.Location = new System.Drawing.Point(400, 6);
            this.lblGroupRelation.Name = "lblGroupRelation";
            this.lblGroupRelation.Size = new System.Drawing.Size(83, 13);
            this.lblGroupRelation.TabIndex = 12;
            this.lblGroupRelation.Text = "sGroup relations";
            // 
            // cmdManageSpecialGroupPermission
            // 
            this.cmdManageSpecialGroupPermission.Image = ((System.Drawing.Image)(resources.GetObject("cmdManageSpecialGroupPermission.Image")));
            this.cmdManageSpecialGroupPermission.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdManageSpecialGroupPermission.Location = new System.Drawing.Point(403, 436);
            this.cmdManageSpecialGroupPermission.Name = "cmdManageSpecialGroupPermission";
            this.cmdManageSpecialGroupPermission.Size = new System.Drawing.Size(385, 26);
            this.cmdManageSpecialGroupPermission.TabIndex = 5;
            this.cmdManageSpecialGroupPermission.Text = "sManage Special Group Permission";
            this.cmdManageSpecialGroupPermission.UseVisualStyleBackColor = true;
            this.cmdManageSpecialGroupPermission.Click += new System.EventHandler(this.cmdManageSpecialGroupPermission_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(581, 400);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 78;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // FrmContactGroupManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(798, 503);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cmdManageSpecialGroupPermission);
            this.Controls.Add(this.lblGroupRelation);
            this.Controls.Add(this.lblAllGroups);
            this.Controls.Add(this.tvParentGrouping);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.lvGroups);
            this.Controls.Add(this.lblGroupName);
            this.Controls.Add(this.cboGroupName);
            this.Controls.Add(this.lblMultiplier);
            this.Controls.Add(this.numMultiplier);
            this.Controls.Add(this.txtGroupName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmContactGroupManager";
            this.Text = "sContact Group Manager";
            this.Load += new System.EventHandler(this.frmContactGroupManager_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmContactGroupManager_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.numMultiplier)).EndInit();
            this.contextParentGroupList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMultiplier;
        private System.Windows.Forms.NumericUpDown numMultiplier;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.ListView lvGroups;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TreeView tvParentGrouping;
        private System.Windows.Forms.ContextMenuStrip contextParentGroupList;
        private System.Windows.Forms.ToolStripMenuItem tsUnAttach;
        private System.Windows.Forms.ComboBox cboGroupName;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.ToolStripMenuItem tsDelete;
        private System.Windows.Forms.Label lblAllGroups;
        private System.Windows.Forms.Label lblGroupRelation;
        private System.Windows.Forms.Button cmdManageSpecialGroupPermission;
        private System.Windows.Forms.Button btnHelp;
    }
}