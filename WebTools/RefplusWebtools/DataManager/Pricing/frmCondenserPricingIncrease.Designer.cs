namespace RefplusWebtools.DataManager.Pricing
{
    partial class FrmCondenserPricingIncrease
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCondenserPricingIncrease));
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn4 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn5 = new GlacialComponents.Controls.GLColumn();
            this.tabParent = new System.Windows.Forms.TabControl();
            this.tabChoose = new System.Windows.Forms.TabPage();
            this.cmdPreview = new System.Windows.Forms.Button();
            this.lblIncreaseDecreaseFactor = new System.Windows.Forms.Label();
            this.numFactor = new System.Windows.Forms.NumericUpDown();
            this.lblSerie = new System.Windows.Forms.Label();
            this.cboSerie = new System.Windows.Forms.ComboBox();
            this.tabReview = new System.Windows.Forms.TabPage();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.lvReview = new GlacialComponents.Controls.GlacialList();
            this.cmdGoToConfirmation = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.tabParent.SuspendLayout();
            this.tabChoose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFactor)).BeginInit();
            this.tabReview.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabParent
            // 
            this.tabParent.Controls.Add(this.tabChoose);
            this.tabParent.Controls.Add(this.tabReview);
            this.tabParent.Location = new System.Drawing.Point(2, 8);
            this.tabParent.Name = "tabParent";
            this.tabParent.SelectedIndex = 0;
            this.tabParent.Size = new System.Drawing.Size(608, 487);
            this.tabParent.TabIndex = 0;
            // 
            // tabChoose
            // 
            this.tabChoose.Controls.Add(this.cmdPreview);
            this.tabChoose.Controls.Add(this.lblIncreaseDecreaseFactor);
            this.tabChoose.Controls.Add(this.numFactor);
            this.tabChoose.Controls.Add(this.lblSerie);
            this.tabChoose.Controls.Add(this.cboSerie);
            this.tabChoose.Location = new System.Drawing.Point(4, 22);
            this.tabChoose.Name = "tabChoose";
            this.tabChoose.Padding = new System.Windows.Forms.Padding(3);
            this.tabChoose.Size = new System.Drawing.Size(600, 461);
            this.tabChoose.TabIndex = 0;
            this.tabChoose.Text = "sSelect";
            this.tabChoose.UseVisualStyleBackColor = true;
            // 
            // cmdPreview
            // 
            this.cmdPreview.Image = ((System.Drawing.Image)(resources.GetObject("cmdPreview.Image")));
            this.cmdPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdPreview.Location = new System.Drawing.Point(416, 430);
            this.cmdPreview.Name = "cmdPreview";
            this.cmdPreview.Size = new System.Drawing.Size(178, 25);
            this.cmdPreview.TabIndex = 2;
            this.cmdPreview.Text = "sProceed to preview";
            this.cmdPreview.UseVisualStyleBackColor = true;
            this.cmdPreview.Click += new System.EventHandler(this.cmdPreview_Click);
            // 
            // lblIncreaseDecreaseFactor
            // 
            this.lblIncreaseDecreaseFactor.Location = new System.Drawing.Point(80, 217);
            this.lblIncreaseDecreaseFactor.Name = "lblIncreaseDecreaseFactor";
            this.lblIncreaseDecreaseFactor.Size = new System.Drawing.Size(183, 13);
            this.lblIncreaseDecreaseFactor.TabIndex = 3;
            this.lblIncreaseDecreaseFactor.Text = "sIncease/Decrease Factor";
            this.lblIncreaseDecreaseFactor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numFactor
            // 
            this.numFactor.DecimalPlaces = 2;
            this.numFactor.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numFactor.Location = new System.Drawing.Point(269, 215);
            this.numFactor.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numFactor.Name = "numFactor";
            this.numFactor.Size = new System.Drawing.Size(186, 20);
            this.numFactor.TabIndex = 1;
            this.numFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numFactor.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblSerie
            // 
            this.lblSerie.Location = new System.Drawing.Point(83, 174);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(180, 13);
            this.lblSerie.TabIndex = 1;
            this.lblSerie.Text = "sSerie";
            this.lblSerie.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboSerie
            // 
            this.cboSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSerie.FormattingEnabled = true;
            this.cboSerie.Location = new System.Drawing.Point(269, 171);
            this.cboSerie.Name = "cboSerie";
            this.cboSerie.Size = new System.Drawing.Size(186, 21);
            this.cboSerie.TabIndex = 0;
            // 
            // tabReview
            // 
            this.tabReview.Controls.Add(this.cmdCancel);
            this.tabReview.Controls.Add(this.lvReview);
            this.tabReview.Controls.Add(this.cmdGoToConfirmation);
            this.tabReview.Location = new System.Drawing.Point(4, 22);
            this.tabReview.Name = "tabReview";
            this.tabReview.Padding = new System.Windows.Forms.Padding(3);
            this.tabReview.Size = new System.Drawing.Size(600, 461);
            this.tabReview.TabIndex = 1;
            this.tabReview.Text = "sPreview and corrections";
            this.tabReview.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(416, 430);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(178, 25);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "sCancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // lvReview
            // 
            this.lvReview.AllowColumnResize = false;
            this.lvReview.AllowMultiselect = false;
            this.lvReview.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvReview.AlternatingColors = false;
            this.lvReview.AutoHeight = false;
            this.lvReview.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvReview.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1";
            glColumn1.NumericSort = false;
            glColumn1.Text = "sModel";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 250;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column2";
            glColumn2.NumericSort = false;
            glColumn2.Text = "sCurrent Price";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            glColumn2.Width = 150;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Column3";
            glColumn3.NumericSort = false;
            glColumn3.Text = "sNew Price";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            glColumn3.Width = 150;
            glColumn4.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn4.CheckBoxes = false;
            glColumn4.DatetimeSort = false;
            glColumn4.ImageIndex = -1;
            glColumn4.Name = "Column4";
            glColumn4.NumericSort = false;
            glColumn4.Text = "sModified";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn4.Width = 0;
            glColumn5.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn5.CheckBoxes = false;
            glColumn5.DatetimeSort = false;
            glColumn5.ImageIndex = -1;
            glColumn5.Name = "Column1x";
            glColumn5.NumericSort = false;
            glColumn5.Text = "sID";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn5.Width = 0;
            this.lvReview.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3,
            glColumn4,
            glColumn5});
            this.lvReview.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvReview.FullRowSelect = true;
            this.lvReview.GridColor = System.Drawing.Color.LightGray;
            this.lvReview.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvReview.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvReview.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvReview.HeaderHeight = 22;
            this.lvReview.HeaderVisible = true;
            this.lvReview.HeaderWordWrap = false;
            this.lvReview.HotColumnTracking = false;
            this.lvReview.HotItemTracking = false;
            this.lvReview.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvReview.HoverEvents = false;
            this.lvReview.HoverTime = 1;
            this.lvReview.ImageList = null;
            this.lvReview.ItemHeight = 25;
            this.lvReview.ItemWordWrap = false;
            this.lvReview.Location = new System.Drawing.Point(12, 6);
            this.lvReview.Name = "lvReview";
            this.lvReview.Selectable = true;
            this.lvReview.SelectedTextColor = System.Drawing.Color.White;
            this.lvReview.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvReview.ShowBorder = true;
            this.lvReview.ShowFocusRect = true;
            this.lvReview.Size = new System.Drawing.Size(577, 418);
            this.lvReview.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lvReview.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvReview.TabIndex = 0;
            this.lvReview.Text = "glacialList1";
            this.lvReview.DoubleClick += new System.EventHandler(this.lvReview_DoubleClick);
            // 
            // cmdGoToConfirmation
            // 
            this.cmdGoToConfirmation.Image = ((System.Drawing.Image)(resources.GetObject("cmdGoToConfirmation.Image")));
            this.cmdGoToConfirmation.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdGoToConfirmation.Location = new System.Drawing.Point(232, 430);
            this.cmdGoToConfirmation.Name = "cmdGoToConfirmation";
            this.cmdGoToConfirmation.Size = new System.Drawing.Size(178, 25);
            this.cmdGoToConfirmation.TabIndex = 1;
            this.cmdGoToConfirmation.Text = "sGo to confirmation";
            this.cmdGoToConfirmation.UseVisualStyleBackColor = true;
            this.cmdGoToConfirmation.Click += new System.EventHandler(this.cmdGoToConfirmation_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(422, 497);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(178, 25);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(12, 497);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 1;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmCondenserPricingIncrease
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(612, 524);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.tabParent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCondenserPricingIncrease";
            this.Text = "sData Manager - Condenser Pricing";
            this.Load += new System.EventHandler(this.frmCondenserPricingIncrease_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmCondenserPricingIncrease_HelpRequested);
            this.tabParent.ResumeLayout(false);
            this.tabChoose.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numFactor)).EndInit();
            this.tabReview.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabParent;
        private System.Windows.Forms.TabPage tabChoose;
        private System.Windows.Forms.TabPage tabReview;
        private System.Windows.Forms.Label lblIncreaseDecreaseFactor;
        private System.Windows.Forms.NumericUpDown numFactor;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.ComboBox cboSerie;
        private System.Windows.Forms.Button cmdPreview;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdGoToConfirmation;
        private GlacialComponents.Controls.GlacialList lvReview;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button btnHelp;
    }
}