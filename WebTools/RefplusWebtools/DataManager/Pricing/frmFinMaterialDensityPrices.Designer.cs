namespace RefplusWebtools.DataManager.Pricing
{
    partial class FrmFinMaterialDensityPrices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFinMaterialDensityPrices));
            this.lvFinMaterial = new GlacialComponents.Controls.GlacialList();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvFinMaterial
            // 
            this.lvFinMaterial.AllowColumnResize = false;
            this.lvFinMaterial.AllowMultiselect = false;
            this.lvFinMaterial.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvFinMaterial.AlternatingColors = false;
            this.lvFinMaterial.AutoHeight = false;
            this.lvFinMaterial.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvFinMaterial.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1";
            glColumn1.NumericSort = false;
            glColumn1.Text = "sID";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn1.Width = 0;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column1x";
            glColumn2.NumericSort = false;
            glColumn2.Text = "sMaterial";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn2.Width = 150;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Column2";
            glColumn3.NumericSort = false;
            glColumn3.Text = "sDensity";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn3.Width = 100;
            glColumn4.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn4.CheckBoxes = false;
            glColumn4.DatetimeSort = false;
            glColumn4.ImageIndex = -1;
            glColumn4.Name = "Column1xx";
            glColumn4.NumericSort = false;
            glColumn4.Text = "sPrice per lbs";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn4.Width = 100;
            this.lvFinMaterial.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3,
            glColumn4});
            this.lvFinMaterial.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvFinMaterial.FullRowSelect = true;
            this.lvFinMaterial.GridColor = System.Drawing.Color.LightGray;
            this.lvFinMaterial.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvFinMaterial.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvFinMaterial.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvFinMaterial.HeaderHeight = 22;
            this.lvFinMaterial.HeaderVisible = true;
            this.lvFinMaterial.HeaderWordWrap = false;
            this.lvFinMaterial.HotColumnTracking = false;
            this.lvFinMaterial.HotItemTracking = false;
            this.lvFinMaterial.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvFinMaterial.HoverEvents = false;
            this.lvFinMaterial.HoverTime = 1;
            this.lvFinMaterial.ImageList = null;
            this.lvFinMaterial.ItemHeight = 25;
            this.lvFinMaterial.ItemWordWrap = false;
            this.lvFinMaterial.Location = new System.Drawing.Point(12, 12);
            this.lvFinMaterial.Name = "lvFinMaterial";
            this.lvFinMaterial.Selectable = true;
            this.lvFinMaterial.SelectedTextColor = System.Drawing.Color.White;
            this.lvFinMaterial.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvFinMaterial.ShowBorder = true;
            this.lvFinMaterial.ShowFocusRect = true;
            this.lvFinMaterial.Size = new System.Drawing.Size(380, 184);
            this.lvFinMaterial.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lvFinMaterial.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvFinMaterial.TabIndex = 0;
            this.lvFinMaterial.Text = "glacialList1";
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(242, 202);
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
            this.cmdSave.Location = new System.Drawing.Point(12, 202);
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
            this.btnHelp.Location = new System.Drawing.Point(189, 203);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmFinMaterialDensityPrices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(404, 233);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.lvFinMaterial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmFinMaterialDensityPrices";
            this.Text = "sData Manager - Fin Material Density & Prices";
            this.Load += new System.EventHandler(this.frmFinMaterialDensityPrices_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmFinMaterialDensityPrices_HelpRequested);
            this.ResumeLayout(false);

        }

        #endregion

        private GlacialComponents.Controls.GlacialList lvFinMaterial;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button btnHelp;
    }
}