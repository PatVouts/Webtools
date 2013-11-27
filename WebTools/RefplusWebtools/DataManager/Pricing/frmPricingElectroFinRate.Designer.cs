namespace RefplusWebtools.DataManager.Pricing
{
    partial class FrmPricingElectroFinRate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPricingElectroFinRate));
            this.lvElectroRate = new GlacialComponents.Controls.GlacialList();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvElectroRate
            // 
            this.lvElectroRate.AllowColumnResize = false;
            this.lvElectroRate.AllowMultiselect = false;
            this.lvElectroRate.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvElectroRate.AlternatingColors = false;
            this.lvElectroRate.AutoHeight = false;
            this.lvElectroRate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvElectroRate.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1x";
            glColumn1.NumericSort = false;
            glColumn1.Text = "sRow";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn1.Width = 60;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column2";
            glColumn2.NumericSort = false;
            glColumn2.Text = "sFPI";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn2.Width = 60;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Column1xx";
            glColumn3.NumericSort = false;
            glColumn3.Text = "sRate";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn3.Width = 120;
            glColumn4.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn4.CheckBoxes = false;
            glColumn4.DatetimeSort = false;
            glColumn4.ImageIndex = -1;
            glColumn4.Name = "Column1";
            glColumn4.NumericSort = false;
            glColumn4.Text = "sMin";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn4.Width = 120;
            this.lvElectroRate.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3,
            glColumn4});
            this.lvElectroRate.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvElectroRate.FullRowSelect = true;
            this.lvElectroRate.GridColor = System.Drawing.Color.LightGray;
            this.lvElectroRate.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvElectroRate.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvElectroRate.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvElectroRate.HeaderHeight = 22;
            this.lvElectroRate.HeaderVisible = true;
            this.lvElectroRate.HeaderWordWrap = false;
            this.lvElectroRate.HotColumnTracking = false;
            this.lvElectroRate.HotItemTracking = false;
            this.lvElectroRate.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvElectroRate.HoverEvents = false;
            this.lvElectroRate.HoverTime = 1;
            this.lvElectroRate.ImageList = null;
            this.lvElectroRate.ItemHeight = 25;
            this.lvElectroRate.ItemWordWrap = false;
            this.lvElectroRate.Location = new System.Drawing.Point(12, 12);
            this.lvElectroRate.Name = "lvElectroRate";
            this.lvElectroRate.Selectable = true;
            this.lvElectroRate.SelectedTextColor = System.Drawing.Color.White;
            this.lvElectroRate.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvElectroRate.ShowBorder = true;
            this.lvElectroRate.ShowFocusRect = true;
            this.lvElectroRate.Size = new System.Drawing.Size(394, 586);
            this.lvElectroRate.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lvElectroRate.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvElectroRate.TabIndex = 0;
            this.lvElectroRate.Text = "glacialList1";
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
            // frmPricingElectroFinRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(418, 635);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.lvElectroRate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmPricingElectroFinRate";
            this.Text = "sData Manager - Pricing Electro Fin Rate";
            this.Load += new System.EventHandler(this.frmPricingElectroFinRate_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmPricingElectroFinRate_HelpRequested);
            this.ResumeLayout(false);

        }

        #endregion

        private GlacialComponents.Controls.GlacialList lvElectroRate;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button btnHelp;
    }
}