namespace RefplusWebtools.DataManager.Pricing
{
    partial class FrmPricingMiscSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPricingMiscSettings));
            this.lvMiscSettings = new GlacialComponents.Controls.GlacialList();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvMiscSettings
            // 
            this.lvMiscSettings.AllowColumnResize = false;
            this.lvMiscSettings.AllowMultiselect = false;
            this.lvMiscSettings.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvMiscSettings.AlternatingColors = false;
            this.lvMiscSettings.AutoHeight = false;
            this.lvMiscSettings.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvMiscSettings.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1x";
            glColumn1.NumericSort = false;
            glColumn1.Text = "sID";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn1.Width = 0;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column2";
            glColumn2.NumericSort = false;
            glColumn2.Text = "sMisc Desc";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 400;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Column1";
            glColumn3.NumericSort = false;
            glColumn3.Text = "sPrice";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn3.Width = 120;
            this.lvMiscSettings.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3});
            this.lvMiscSettings.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvMiscSettings.FullRowSelect = true;
            this.lvMiscSettings.GridColor = System.Drawing.Color.LightGray;
            this.lvMiscSettings.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvMiscSettings.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvMiscSettings.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvMiscSettings.HeaderHeight = 22;
            this.lvMiscSettings.HeaderVisible = true;
            this.lvMiscSettings.HeaderWordWrap = false;
            this.lvMiscSettings.HotColumnTracking = false;
            this.lvMiscSettings.HotItemTracking = false;
            this.lvMiscSettings.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvMiscSettings.HoverEvents = false;
            this.lvMiscSettings.HoverTime = 1;
            this.lvMiscSettings.ImageList = null;
            this.lvMiscSettings.ItemHeight = 25;
            this.lvMiscSettings.ItemWordWrap = false;
            this.lvMiscSettings.Location = new System.Drawing.Point(12, 12);
            this.lvMiscSettings.Name = "lvMiscSettings";
            this.lvMiscSettings.Selectable = true;
            this.lvMiscSettings.SelectedTextColor = System.Drawing.Color.White;
            this.lvMiscSettings.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvMiscSettings.ShowBorder = true;
            this.lvMiscSettings.ShowFocusRect = true;
            this.lvMiscSettings.Size = new System.Drawing.Size(558, 546);
            this.lvMiscSettings.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lvMiscSettings.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvMiscSettings.TabIndex = 0;
            this.lvMiscSettings.Text = "glacialList1";
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(420, 564);
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
            this.cmdSave.Location = new System.Drawing.Point(12, 564);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(150, 25);
            this.cmdSave.TabIndex = 1;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(273, 565);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmPricingMiscSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(582, 594);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.lvMiscSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmPricingMiscSettings";
            this.Text = "sData Manager - Pricing Misc Settings";
            this.Load += new System.EventHandler(this.frmPricingMiscSettings_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmPricingMiscSettings_HelpRequested);
            this.ResumeLayout(false);

        }

        #endregion

        private GlacialComponents.Controls.GlacialList lvMiscSettings;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button btnHelp;
    }
}