namespace RefplusWebtools.DataManager.Pricing
{
    partial class FrmPricingMadocRate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPricingMadocRate));
            this.lvMadocRate = new GlacialComponents.Controls.GlacialList();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvMadocRate
            // 
            this.lvMadocRate.AllowColumnResize = false;
            this.lvMadocRate.AllowMultiselect = false;
            this.lvMadocRate.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvMadocRate.AlternatingColors = false;
            this.lvMadocRate.AutoHeight = false;
            this.lvMadocRate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvMadocRate.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1x";
            glColumn1.NumericSort = false;
            glColumn1.Text = "sRow";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn1.Width = 120;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column2";
            glColumn2.NumericSort = false;
            glColumn2.Text = "sPrice";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn2.Width = 150;
            this.lvMadocRate.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2});
            this.lvMadocRate.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvMadocRate.FullRowSelect = true;
            this.lvMadocRate.GridColor = System.Drawing.Color.LightGray;
            this.lvMadocRate.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvMadocRate.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvMadocRate.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvMadocRate.HeaderHeight = 22;
            this.lvMadocRate.HeaderVisible = true;
            this.lvMadocRate.HeaderWordWrap = false;
            this.lvMadocRate.HotColumnTracking = false;
            this.lvMadocRate.HotItemTracking = false;
            this.lvMadocRate.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvMadocRate.HoverEvents = false;
            this.lvMadocRate.HoverTime = 1;
            this.lvMadocRate.ImageList = null;
            this.lvMadocRate.ItemHeight = 25;
            this.lvMadocRate.ItemWordWrap = false;
            this.lvMadocRate.Location = new System.Drawing.Point(12, 12);
            this.lvMadocRate.Name = "lvMadocRate";
            this.lvMadocRate.Selectable = true;
            this.lvMadocRate.SelectedTextColor = System.Drawing.Color.White;
            this.lvMadocRate.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvMadocRate.ShowBorder = true;
            this.lvMadocRate.ShowFocusRect = true;
            this.lvMadocRate.Size = new System.Drawing.Size(312, 490);
            this.lvMadocRate.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lvMadocRate.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvMadocRate.TabIndex = 0;
            this.lvMadocRate.Text = "glacialList1";
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(215, 508);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(109, 25);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(12, 508);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(109, 25);
            this.cmdSave.TabIndex = 1;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(153, 509);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmPricingMadocRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(336, 538);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.lvMadocRate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmPricingMadocRate";
            this.Text = "sData Manager - Pricing Madoc Rate";
            this.Load += new System.EventHandler(this.frmPricingMadocRate_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmPricingMadocRate_HelpRequested);
            this.ResumeLayout(false);

        }

        #endregion

        private GlacialComponents.Controls.GlacialList lvMadocRate;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button btnHelp;
    }
}