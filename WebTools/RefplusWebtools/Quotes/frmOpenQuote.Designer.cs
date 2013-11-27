namespace RefplusWebtools.Quotes
{
    partial class FrmOpenQuote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOpenQuote));
            GlacialComponents.Controls.GLColumn glColumn8 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn9 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn10 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn11 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn12 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn13 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn14 = new GlacialComponents.Controls.GLColumn();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.lstQuoteList = new GlacialComponents.Controls.GlacialList();
            this.lblDateFilter = new System.Windows.Forms.Label();
            this.cboDateFilter = new System.Windows.Forms.ComboBox();
            this.cmdAdvancedSearch = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.txtSearchByQuoteNumber = new System.Windows.Forms.TextBox();
            this.lblSearchByQuote = new System.Windows.Forms.Label();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(669, 560);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(113, 24);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdOpen
            // 
            this.cmdOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdOpen.Image = ((System.Drawing.Image)(resources.GetObject("cmdOpen.Image")));
            this.cmdOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOpen.Location = new System.Drawing.Point(12, 560);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(113, 24);
            this.cmdOpen.TabIndex = 1;
            this.cmdOpen.Text = "sOpen";
            this.cmdOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdOpen.UseVisualStyleBackColor = true;
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // lstQuoteList
            // 
            this.lstQuoteList.AllowColumnResize = true;
            this.lstQuoteList.AllowMultiselect = false;
            this.lstQuoteList.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lstQuoteList.AlternatingColors = false;
            this.lstQuoteList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstQuoteList.AutoHeight = true;
            this.lstQuoteList.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lstQuoteList.BackgroundStretchToFit = true;
            glColumn8.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn8.CheckBoxes = false;
            glColumn8.DatetimeSort = false;
            glColumn8.ImageIndex = -1;
            glColumn8.Name = "Column6";
            glColumn8.NumericSort = false;
            glColumn8.Text = "sID";
            glColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn8.Width = 0;
            glColumn9.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn9.CheckBoxes = false;
            glColumn9.DatetimeSort = false;
            glColumn9.ImageIndex = -1;
            glColumn9.Name = "Column1";
            glColumn9.NumericSort = false;
            glColumn9.Text = "sProject Name";
            glColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn9.Width = 160;
            glColumn10.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn10.CheckBoxes = false;
            glColumn10.DatetimeSort = false;
            glColumn10.ImageIndex = -1;
            glColumn10.Name = "Column2";
            glColumn10.NumericSort = false;
            glColumn10.Text = "sContact";
            glColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn10.Width = 150;
            glColumn11.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn11.CheckBoxes = false;
            glColumn11.DatetimeSort = false;
            glColumn11.ImageIndex = -1;
            glColumn11.Name = "Column3";
            glColumn11.NumericSort = false;
            glColumn11.Text = "sQuote #";
            glColumn11.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn11.Width = 65;
            glColumn12.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn12.CheckBoxes = false;
            glColumn12.DatetimeSort = false;
            glColumn12.ImageIndex = -1;
            glColumn12.Name = "Column4";
            glColumn12.NumericSort = false;
            glColumn12.Text = "sCreator";
            glColumn12.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn12.Width = 120;
            glColumn13.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn13.CheckBoxes = false;
            glColumn13.DatetimeSort = false;
            glColumn13.ImageIndex = -1;
            glColumn13.Name = "Column1x";
            glColumn13.NumericSort = false;
            glColumn13.Text = "sUpdate By";
            glColumn13.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn13.Width = 120;
            glColumn14.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn14.CheckBoxes = false;
            glColumn14.DatetimeSort = true;
            glColumn14.ImageIndex = -1;
            glColumn14.Name = "Column5";
            glColumn14.NumericSort = false;
            glColumn14.Text = "sCreationDate";
            glColumn14.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn14.Width = 130;
            this.lstQuoteList.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn8,
            glColumn9,
            glColumn10,
            glColumn11,
            glColumn12,
            glColumn13,
            glColumn14});
            this.lstQuoteList.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lstQuoteList.FullRowSelect = true;
            this.lstQuoteList.GridColor = System.Drawing.Color.LightGray;
            this.lstQuoteList.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lstQuoteList.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridSolid;
            this.lstQuoteList.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lstQuoteList.HeaderHeight = 22;
            this.lstQuoteList.HeaderVisible = true;
            this.lstQuoteList.HeaderWordWrap = false;
            this.lstQuoteList.HotColumnTracking = false;
            this.lstQuoteList.HotItemTracking = false;
            this.lstQuoteList.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lstQuoteList.HoverEvents = false;
            this.lstQuoteList.HoverTime = 1;
            this.lstQuoteList.ImageList = null;
            this.lstQuoteList.ItemHeight = 17;
            this.lstQuoteList.ItemWordWrap = false;
            this.lstQuoteList.Location = new System.Drawing.Point(12, 28);
            this.lstQuoteList.Name = "lstQuoteList";
            this.lstQuoteList.Selectable = true;
            this.lstQuoteList.SelectedTextColor = System.Drawing.Color.White;
            this.lstQuoteList.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lstQuoteList.ShowBorder = true;
            this.lstQuoteList.ShowFocusRect = false;
            this.lstQuoteList.Size = new System.Drawing.Size(770, 526);
            this.lstQuoteList.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lstQuoteList.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lstQuoteList.TabIndex = 0;
            this.lstQuoteList.Text = "glacialList1";
            this.lstQuoteList.Click += new System.EventHandler(this.lstQuoteList_Click);
            this.lstQuoteList.DoubleClick += new System.EventHandler(this.lstQuoteList_DoubleClick);
            // 
            // lblDateFilter
            // 
            this.lblDateFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateFilter.AutoSize = true;
            this.lblDateFilter.Location = new System.Drawing.Point(384, 568);
            this.lblDateFilter.Name = "lblDateFilter";
            this.lblDateFilter.Size = new System.Drawing.Size(60, 13);
            this.lblDateFilter.TabIndex = 76;
            this.lblDateFilter.Text = "sDate Filter";
            // 
            // cboDateFilter
            // 
            this.cboDateFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDateFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDateFilter.FormattingEnabled = true;
            this.cboDateFilter.Location = new System.Drawing.Point(461, 563);
            this.cboDateFilter.Name = "cboDateFilter";
            this.cboDateFilter.Size = new System.Drawing.Size(194, 21);
            this.cboDateFilter.TabIndex = 4;
            this.cboDateFilter.SelectedIndexChanged += new System.EventHandler(this.cboDateFilter_SelectedIndexChanged);
            // 
            // cmdAdvancedSearch
            // 
            this.cmdAdvancedSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAdvancedSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdvancedSearch.Image")));
            this.cmdAdvancedSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdvancedSearch.Location = new System.Drawing.Point(131, 560);
            this.cmdAdvancedSearch.Name = "cmdAdvancedSearch";
            this.cmdAdvancedSearch.Size = new System.Drawing.Size(151, 24);
            this.cmdAdvancedSearch.TabIndex = 2;
            this.cmdAdvancedSearch.Text = "sAdvanced Search";
            this.cmdAdvancedSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAdvancedSearch.UseVisualStyleBackColor = true;
            this.cmdAdvancedSearch.Visible = false;
            this.cmdAdvancedSearch.Click += new System.EventHandler(this.cmdAdvancedSearch_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(285, 560);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // txtSearchByQuoteNumber
            // 
            this.txtSearchByQuoteNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchByQuoteNumber.Location = new System.Drawing.Point(545, 4);
            this.txtSearchByQuoteNumber.Name = "txtSearchByQuoteNumber";
            this.txtSearchByQuoteNumber.Size = new System.Drawing.Size(127, 20);
            this.txtSearchByQuoteNumber.TabIndex = 77;
            this.txtSearchByQuoteNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearchByQuoteNumber.TextChanged += new System.EventHandler(this.txtSearchByQuoteNumber_TextChanged);
            // 
            // lblSearchByQuote
            // 
            this.lblSearchByQuote.AutoSize = true;
            this.lblSearchByQuote.Location = new System.Drawing.Point(372, 6);
            this.lblSearchByQuote.Name = "lblSearchByQuote";
            this.lblSearchByQuote.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSearchByQuote.Size = new System.Drawing.Size(102, 13);
            this.lblSearchByQuote.TabIndex = 78;
            this.lblSearchByQuote.Text = "sSearch by Quote #";
            this.lblSearchByQuote.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSearch.Location = new System.Drawing.Point(692, 2);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(90, 24);
            this.cmdSearch.TabIndex = 79;
            this.cmdSearch.Text = "sSearch";
            this.cmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // frmOpenQuote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(794, 592);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.lblSearchByQuote);
            this.Controls.Add(this.txtSearchByQuoteNumber);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cmdAdvancedSearch);
            this.Controls.Add(this.cboDateFilter);
            this.Controls.Add(this.lblDateFilter);
            this.Controls.Add(this.lstQuoteList);
            this.Controls.Add(this.cmdOpen);
            this.Controls.Add(this.cmdClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOpenQuote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "sOpen Quote";
            this.Load += new System.EventHandler(this.frmOpenQuote_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdOpen;
        private GlacialComponents.Controls.GlacialList lstQuoteList;
        private System.Windows.Forms.Label lblDateFilter;
        private System.Windows.Forms.ComboBox cboDateFilter;
        private System.Windows.Forms.Button cmdAdvancedSearch;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.TextBox txtSearchByQuoteNumber;
        private System.Windows.Forms.Label lblSearchByQuote;
        private System.Windows.Forms.Button cmdSearch;
    }
}