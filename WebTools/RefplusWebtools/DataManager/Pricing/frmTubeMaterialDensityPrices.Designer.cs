namespace RefplusWebtools.DataManager.Pricing
{
    partial class FrmTubeMaterialDensityPrices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTubeMaterialDensityPrices));
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn4 = new GlacialComponents.Controls.GLColumn();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lvTubeMaterial = new GlacialComponents.Controls.GlacialList();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(242, 179);
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
            this.cmdSave.Location = new System.Drawing.Point(12, 179);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(150, 25);
            this.cmdSave.TabIndex = 1;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lvTubeMaterial
            // 
            this.lvTubeMaterial.AllowColumnResize = false;
            this.lvTubeMaterial.AllowMultiselect = false;
            this.lvTubeMaterial.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvTubeMaterial.AlternatingColors = false;
            this.lvTubeMaterial.AutoHeight = false;
            this.lvTubeMaterial.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvTubeMaterial.BackgroundStretchToFit = true;
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
            this.lvTubeMaterial.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3,
            glColumn4});
            this.lvTubeMaterial.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvTubeMaterial.FullRowSelect = true;
            this.lvTubeMaterial.GridColor = System.Drawing.Color.LightGray;
            this.lvTubeMaterial.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvTubeMaterial.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvTubeMaterial.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvTubeMaterial.HeaderHeight = 22;
            this.lvTubeMaterial.HeaderVisible = true;
            this.lvTubeMaterial.HeaderWordWrap = false;
            this.lvTubeMaterial.HotColumnTracking = false;
            this.lvTubeMaterial.HotItemTracking = false;
            this.lvTubeMaterial.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvTubeMaterial.HoverEvents = false;
            this.lvTubeMaterial.HoverTime = 1;
            this.lvTubeMaterial.ImageList = null;
            this.lvTubeMaterial.ItemHeight = 25;
            this.lvTubeMaterial.ItemWordWrap = false;
            this.lvTubeMaterial.Location = new System.Drawing.Point(12, 11);
            this.lvTubeMaterial.Name = "lvTubeMaterial";
            this.lvTubeMaterial.Selectable = true;
            this.lvTubeMaterial.SelectedTextColor = System.Drawing.Color.White;
            this.lvTubeMaterial.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvTubeMaterial.ShowBorder = true;
            this.lvTubeMaterial.ShowFocusRect = true;
            this.lvTubeMaterial.Size = new System.Drawing.Size(380, 162);
            this.lvTubeMaterial.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lvTubeMaterial.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvTubeMaterial.TabIndex = 0;
            this.lvTubeMaterial.Text = "glacialList1";
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(189, 180);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmTubeMaterialDensityPrices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(404, 210);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.lvTubeMaterial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmTubeMaterialDensityPrices";
            this.Text = "sData Manager - Tube Material Density & Prices";
            this.Load += new System.EventHandler(this.frmTubeMaterialDensityPrices_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmTubeMaterialDensityPrices_HelpRequested);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSave;
        private GlacialComponents.Controls.GlacialList lvTubeMaterial;
        private System.Windows.Forms.Button btnHelp;
    }
}