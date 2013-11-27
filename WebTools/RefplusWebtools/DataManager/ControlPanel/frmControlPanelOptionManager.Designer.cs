namespace RefplusWebtools.DataManager.ControlPanel
{
    partial class FrmControlPanelOptionManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmControlPanelOptionManager));
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn4 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn5 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn6 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn7 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn8 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn9 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn10 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn11 = new GlacialComponents.Controls.GLColumn();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdEditLogic = new System.Windows.Forms.Button();
            this.cmdAddLogic = new System.Windows.Forms.Button();
            this.lvSelection = new GlacialComponents.Controls.GlacialList();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.lvOptions = new GlacialComponents.Controls.GlacialList();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(623, 497);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(159, 24);
            this.cmdClose.TabIndex = 178;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdEditLogic
            // 
            this.cmdEditLogic.Image = ((System.Drawing.Image)(resources.GetObject("cmdEditLogic.Image")));
            this.cmdEditLogic.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEditLogic.Location = new System.Drawing.Point(179, 497);
            this.cmdEditLogic.Name = "cmdEditLogic";
            this.cmdEditLogic.Size = new System.Drawing.Size(159, 24);
            this.cmdEditLogic.TabIndex = 177;
            this.cmdEditLogic.Text = "sEdit Logic";
            this.cmdEditLogic.UseVisualStyleBackColor = true;
            this.cmdEditLogic.Click += new System.EventHandler(this.cmdEditLogic_Click);
            // 
            // cmdAddLogic
            // 
            this.cmdAddLogic.Image = ((System.Drawing.Image)(resources.GetObject("cmdAddLogic.Image")));
            this.cmdAddLogic.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAddLogic.Location = new System.Drawing.Point(12, 497);
            this.cmdAddLogic.Name = "cmdAddLogic";
            this.cmdAddLogic.Size = new System.Drawing.Size(159, 25);
            this.cmdAddLogic.TabIndex = 176;
            this.cmdAddLogic.Text = "sAdd Logic";
            this.cmdAddLogic.UseVisualStyleBackColor = true;
            this.cmdAddLogic.Click += new System.EventHandler(this.cmdAddLogic_Click);
            // 
            // lvSelection
            // 
            this.lvSelection.AllowColumnResize = true;
            this.lvSelection.AllowMultiselect = false;
            this.lvSelection.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvSelection.AlternatingColors = false;
            this.lvSelection.AutoHeight = false;
            this.lvSelection.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvSelection.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1";
            glColumn1.NumericSort = false;
            glColumn1.Text = "sOption";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn1.Width = 50;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column1x";
            glColumn2.NumericSort = false;
            glColumn2.Text = "sCooler Type";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn2.Width = 100;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Column1xx";
            glColumn3.NumericSort = true;
            glColumn3.Text = "sMin FW";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn3.Width = 60;
            glColumn4.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn4.CheckBoxes = false;
            glColumn4.DatetimeSort = false;
            glColumn4.ImageIndex = -1;
            glColumn4.Name = "Column1xxx";
            glColumn4.NumericSort = true;
            glColumn4.Text = "sMax FW";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn4.Width = 60;
            glColumn5.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn5.CheckBoxes = false;
            glColumn5.DatetimeSort = false;
            glColumn5.ImageIndex = -1;
            glColumn5.Name = "Column4";
            glColumn5.NumericSort = false;
            glColumn5.Text = "sSerie";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn5.Width = 360;
            glColumn6.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn6.CheckBoxes = false;
            glColumn6.DatetimeSort = false;
            glColumn6.ImageIndex = -1;
            glColumn6.Name = "Column1xxxxx";
            glColumn6.NumericSort = false;
            glColumn6.Text = "";
            glColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn6.Width = 100;
            this.lvSelection.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3,
            glColumn4,
            glColumn5,
            glColumn6});
            this.lvSelection.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvSelection.FullRowSelect = true;
            this.lvSelection.GridColor = System.Drawing.Color.LightGray;
            this.lvSelection.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvSelection.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvSelection.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvSelection.HeaderHeight = 40;
            this.lvSelection.HeaderVisible = true;
            this.lvSelection.HeaderWordWrap = true;
            this.lvSelection.HotColumnTracking = false;
            this.lvSelection.HotItemTracking = false;
            this.lvSelection.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvSelection.HoverEvents = false;
            this.lvSelection.HoverTime = 1;
            this.lvSelection.ImageList = null;
            this.lvSelection.ItemHeight = 25;
            this.lvSelection.ItemWordWrap = false;
            this.lvSelection.Location = new System.Drawing.Point(12, 276);
            this.lvSelection.Name = "lvSelection";
            this.lvSelection.Selectable = true;
            this.lvSelection.SelectedTextColor = System.Drawing.Color.White;
            this.lvSelection.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvSelection.ShowBorder = true;
            this.lvSelection.ShowFocusRect = false;
            this.lvSelection.Size = new System.Drawing.Size(770, 215);
            this.lvSelection.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lvSelection.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvSelection.TabIndex = 175;
            this.lvSelection.Text = "glacialList1";
            // 
            // cmdEdit
            // 
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(179, 245);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(159, 24);
            this.cmdEdit.TabIndex = 174;
            this.cmdEdit.Text = "sEdit";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(12, 245);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(159, 25);
            this.cmdAdd.TabIndex = 173;
            this.cmdAdd.Text = "sAdd";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // lvOptions
            // 
            this.lvOptions.AllowColumnResize = true;
            this.lvOptions.AllowMultiselect = false;
            this.lvOptions.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvOptions.AlternatingColors = false;
            this.lvOptions.AutoHeight = false;
            this.lvOptions.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvOptions.BackgroundStretchToFit = true;
            glColumn7.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn7.CheckBoxes = false;
            glColumn7.DatetimeSort = false;
            glColumn7.ImageIndex = -1;
            glColumn7.Name = "Column1";
            glColumn7.NumericSort = false;
            glColumn7.Text = "sOption";
            glColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn7.Width = 50;
            glColumn8.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn8.CheckBoxes = false;
            glColumn8.DatetimeSort = false;
            glColumn8.ImageIndex = -1;
            glColumn8.Name = "Column1x";
            glColumn8.NumericSort = false;
            glColumn8.Text = "sDescription";
            glColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn8.Width = 470;
            glColumn9.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn9.CheckBoxes = false;
            glColumn9.DatetimeSort = false;
            glColumn9.ImageIndex = -1;
            glColumn9.Name = "Column1xx";
            glColumn9.NumericSort = true;
            glColumn9.Text = "sGroup";
            glColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn9.Width = 60;
            glColumn10.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn10.CheckBoxes = false;
            glColumn10.DatetimeSort = false;
            glColumn10.ImageIndex = -1;
            glColumn10.Name = "Column2";
            glColumn10.NumericSort = true;
            glColumn10.Text = "sUnique";
            glColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn10.Width = 60;
            glColumn11.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn11.CheckBoxes = false;
            glColumn11.DatetimeSort = false;
            glColumn11.ImageIndex = -1;
            glColumn11.Name = "Column1xxx";
            glColumn11.NumericSort = false;
            glColumn11.Text = "";
            glColumn11.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn11.Width = 100;
            this.lvOptions.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn7,
            glColumn8,
            glColumn9,
            glColumn10,
            glColumn11});
            this.lvOptions.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvOptions.FullRowSelect = true;
            this.lvOptions.GridColor = System.Drawing.Color.LightGray;
            this.lvOptions.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvOptions.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvOptions.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvOptions.HeaderHeight = 22;
            this.lvOptions.HeaderVisible = true;
            this.lvOptions.HeaderWordWrap = false;
            this.lvOptions.HotColumnTracking = false;
            this.lvOptions.HotItemTracking = false;
            this.lvOptions.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvOptions.HoverEvents = false;
            this.lvOptions.HoverTime = 1;
            this.lvOptions.ImageList = null;
            this.lvOptions.ItemHeight = 25;
            this.lvOptions.ItemWordWrap = false;
            this.lvOptions.Location = new System.Drawing.Point(12, 12);
            this.lvOptions.Name = "lvOptions";
            this.lvOptions.Selectable = true;
            this.lvOptions.SelectedTextColor = System.Drawing.Color.White;
            this.lvOptions.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvOptions.ShowBorder = true;
            this.lvOptions.ShowFocusRect = false;
            this.lvOptions.Size = new System.Drawing.Size(770, 227);
            this.lvOptions.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lvOptions.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvOptions.TabIndex = 172;
            this.lvOptions.Text = "glacialList1";
            this.lvOptions.Click += new System.EventHandler(this.lvOptions_Click);
            // 
            // frmControlPanelOptionManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(794, 529);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdEditLogic);
            this.Controls.Add(this.cmdAddLogic);
            this.Controls.Add(this.lvSelection);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.lvOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmControlPanelOptionManager";
            this.Text = "sData Manager - Control Panel - Options and Selection";
            this.Load += new System.EventHandler(this.frmControlPanelOptionManager_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdEditLogic;
        private System.Windows.Forms.Button cmdAddLogic;
        private GlacialComponents.Controls.GlacialList lvSelection;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdAdd;
        private GlacialComponents.Controls.GlacialList lvOptions;
    }
}