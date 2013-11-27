namespace RefplusWebtools.DataManager.Pricing
{
    partial class FrmCasingMaterialDensityPrices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCasingMaterialDensityPrices));
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn4 = new GlacialComponents.Controls.GLColumn();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lvCasingMaterial = new GlacialComponents.Controls.GlacialList();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(242, 178);
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
            this.cmdSave.Location = new System.Drawing.Point(12, 178);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(150, 25);
            this.cmdSave.TabIndex = 1;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lvCasingMaterial
            // 
            this.lvCasingMaterial.AllowColumnResize = false;
            this.lvCasingMaterial.AllowMultiselect = false;
            this.lvCasingMaterial.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvCasingMaterial.AlternatingColors = false;
            this.lvCasingMaterial.AutoHeight = false;
            this.lvCasingMaterial.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvCasingMaterial.BackgroundStretchToFit = true;
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
            this.lvCasingMaterial.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3,
            glColumn4});
            this.lvCasingMaterial.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvCasingMaterial.FullRowSelect = true;
            this.lvCasingMaterial.GridColor = System.Drawing.Color.LightGray;
            this.lvCasingMaterial.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvCasingMaterial.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvCasingMaterial.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvCasingMaterial.HeaderHeight = 22;
            this.lvCasingMaterial.HeaderVisible = true;
            this.lvCasingMaterial.HeaderWordWrap = false;
            this.lvCasingMaterial.HotColumnTracking = false;
            this.lvCasingMaterial.HotItemTracking = false;
            this.lvCasingMaterial.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvCasingMaterial.HoverEvents = false;
            this.lvCasingMaterial.HoverTime = 1;
            this.lvCasingMaterial.ImageList = null;
            this.lvCasingMaterial.ItemHeight = 25;
            this.lvCasingMaterial.ItemWordWrap = false;
            this.lvCasingMaterial.Location = new System.Drawing.Point(12, 11);
            this.lvCasingMaterial.Name = "lvCasingMaterial";
            this.lvCasingMaterial.Selectable = true;
            this.lvCasingMaterial.SelectedTextColor = System.Drawing.Color.White;
            this.lvCasingMaterial.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvCasingMaterial.ShowBorder = true;
            this.lvCasingMaterial.ShowFocusRect = true;
            this.lvCasingMaterial.Size = new System.Drawing.Size(380, 161);
            this.lvCasingMaterial.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lvCasingMaterial.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvCasingMaterial.TabIndex = 0;
            this.lvCasingMaterial.Text = "glacialList1";
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(189, 179);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmCasingMaterialDensityPrices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(404, 211);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.lvCasingMaterial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmCasingMaterialDensityPrices";
            this.Text = "sData Manager - Casing Material Density & Prices";
            this.Load += new System.EventHandler(this.frmCasingMaterialDensityPrices_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmCasingMaterialDensityPrices_HelpRequested);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSave;
        private GlacialComponents.Controls.GlacialList lvCasingMaterial;
        private System.Windows.Forms.Button btnHelp;

    }
}