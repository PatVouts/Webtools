namespace RefplusWebtools.DataManager.Pricing
{
    partial class FrmPricingCoilHeader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPricingCoilHeader));
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lvCoilHeader = new GlacialComponents.Controls.GlacialList();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(256, 604);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(150, 25);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(12, 604);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(150, 25);
            this.cmdSave.TabIndex = 1;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lvCoilHeader
            // 
            this.lvCoilHeader.AllowColumnResize = false;
            this.lvCoilHeader.AllowMultiselect = false;
            this.lvCoilHeader.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvCoilHeader.AlternatingColors = false;
            this.lvCoilHeader.AutoHeight = false;
            this.lvCoilHeader.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvCoilHeader.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1x";
            glColumn1.NumericSort = false;
            glColumn1.Text = "sHeader Diameter";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn1.Width = 120;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column2";
            glColumn2.NumericSort = false;
            glColumn2.Text = "sHeader Thickness";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn2.Width = 120;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Column1xx";
            glColumn3.NumericSort = false;
            glColumn3.Text = "sCost Per Foot";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn3.Width = 120;
            this.lvCoilHeader.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3});
            this.lvCoilHeader.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvCoilHeader.FullRowSelect = true;
            this.lvCoilHeader.GridColor = System.Drawing.Color.LightGray;
            this.lvCoilHeader.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvCoilHeader.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvCoilHeader.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvCoilHeader.HeaderHeight = 22;
            this.lvCoilHeader.HeaderVisible = true;
            this.lvCoilHeader.HeaderWordWrap = false;
            this.lvCoilHeader.HotColumnTracking = false;
            this.lvCoilHeader.HotItemTracking = false;
            this.lvCoilHeader.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvCoilHeader.HoverEvents = false;
            this.lvCoilHeader.HoverTime = 1;
            this.lvCoilHeader.ImageList = null;
            this.lvCoilHeader.ItemHeight = 25;
            this.lvCoilHeader.ItemWordWrap = false;
            this.lvCoilHeader.Location = new System.Drawing.Point(12, 12);
            this.lvCoilHeader.Name = "lvCoilHeader";
            this.lvCoilHeader.Selectable = true;
            this.lvCoilHeader.SelectedTextColor = System.Drawing.Color.White;
            this.lvCoilHeader.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvCoilHeader.ShowBorder = true;
            this.lvCoilHeader.ShowFocusRect = true;
            this.lvCoilHeader.Size = new System.Drawing.Size(394, 586);
            this.lvCoilHeader.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lvCoilHeader.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvCoilHeader.TabIndex = 0;
            this.lvCoilHeader.Text = "glacialList1";
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(195, 605);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmPricingCoilHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(418, 636);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.lvCoilHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmPricingCoilHeader";
            this.Text = "sData Manager - Pricing Coil Header";
            this.Load += new System.EventHandler(this.frmPricingCoilHeader_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmPricingCoilHeader_HelpRequested);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSave;
        private GlacialComponents.Controls.GlacialList lvCoilHeader;
        private System.Windows.Forms.Button btnHelp;
    }
}