namespace RefplusWebtools.Contact
{
    partial class frmGroupManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGroupManager));
            this.lstGroup = new GlacialComponents.Controls.GlacialList();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdAddNewGroup = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstGroup
            // 
            this.lstGroup.AllowColumnResize = true;
            this.lstGroup.AllowMultiselect = false;
            this.lstGroup.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lstGroup.AlternatingColors = false;
            this.lstGroup.AutoHeight = false;
            this.lstGroup.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lstGroup.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1";
            glColumn1.NumericSort = false;
            glColumn1.Text = "sGroup ID";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn1.Width = 70;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.TextBox;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column2";
            glColumn2.NumericSort = false;
            glColumn2.Text = "sGroup Name";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 390;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.TextBox;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Column1x";
            glColumn3.NumericSort = false;
            glColumn3.Text = "sDefault Multiplier";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 110;
            this.lstGroup.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3});
            this.lstGroup.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lstGroup.FullRowSelect = true;
            this.lstGroup.GridColor = System.Drawing.Color.LightGray;
            this.lstGroup.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lstGroup.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridSolid;
            this.lstGroup.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lstGroup.HeaderHeight = 22;
            this.lstGroup.HeaderVisible = true;
            this.lstGroup.HeaderWordWrap = false;
            this.lstGroup.HotColumnTracking = false;
            this.lstGroup.HotItemTracking = false;
            this.lstGroup.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lstGroup.HoverEvents = false;
            this.lstGroup.HoverTime = 1;
            this.lstGroup.ImageList = null;
            this.lstGroup.ItemHeight = 18;
            this.lstGroup.ItemWordWrap = false;
            this.lstGroup.Location = new System.Drawing.Point(12, 12);
            this.lstGroup.Name = "lstGroup";
            this.lstGroup.Selectable = true;
            this.lstGroup.SelectedTextColor = System.Drawing.Color.White;
            this.lstGroup.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lstGroup.ShowBorder = true;
            this.lstGroup.ShowFocusRect = false;
            this.lstGroup.Size = new System.Drawing.Size(597, 258);
            this.lstGroup.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lstGroup.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lstGroup.TabIndex = 0;
            this.lstGroup.Text = "glacialList1";
            this.lstGroup.ItemChangedEvent += new GlacialComponents.Controls.ChangedEventHandler(this.lstGroup_ItemChangedEvent);
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(12, 304);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(175, 23);
            this.cmdSave.TabIndex = 1;
            this.cmdSave.Text = "sSave Changes";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdAddNewGroup
            // 
            this.cmdAddNewGroup.Image = ((System.Drawing.Image)(resources.GetObject("cmdAddNewGroup.Image")));
            this.cmdAddNewGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAddNewGroup.Location = new System.Drawing.Point(12, 276);
            this.cmdAddNewGroup.Name = "cmdAddNewGroup";
            this.cmdAddNewGroup.Size = new System.Drawing.Size(175, 22);
            this.cmdAddNewGroup.TabIndex = 2;
            this.cmdAddNewGroup.Text = "sAdd New Group Entry";
            this.cmdAddNewGroup.UseVisualStyleBackColor = true;
            this.cmdAddNewGroup.Click += new System.EventHandler(this.cmdAddNewGroup_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(434, 304);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(175, 23);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "sCancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmGroupManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 335);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAddNewGroup);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.lstGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGroupManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "sGroup Manager";
            this.Load += new System.EventHandler(this.frmGroupManager_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GlacialComponents.Controls.GlacialList lstGroup;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdAddNewGroup;
        private System.Windows.Forms.Button cmdCancel;
    }
}