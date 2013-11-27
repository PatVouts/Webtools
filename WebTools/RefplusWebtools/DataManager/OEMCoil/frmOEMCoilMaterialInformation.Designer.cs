namespace RefplusWebtools.DataManager.OEMCoil
{
    partial class FrmOEMCoilMaterialInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOEMCoilMaterialInformation));
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn4 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn5 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn6 = new GlacialComponents.Controls.GLColumn();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lvMaterialInfo = new GlacialComponents.Controls.GlacialList();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(548, 326);
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
            this.cmdSave.Location = new System.Drawing.Point(12, 326);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(150, 25);
            this.cmdSave.TabIndex = 1;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lvMaterialInfo
            // 
            this.lvMaterialInfo.AllowColumnResize = false;
            this.lvMaterialInfo.AllowMultiselect = false;
            this.lvMaterialInfo.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvMaterialInfo.AlternatingColors = false;
            this.lvMaterialInfo.AutoHeight = false;
            this.lvMaterialInfo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvMaterialInfo.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1x";
            glColumn1.NumericSort = false;
            glColumn1.Text = "sCoil Fin Material";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn1.Width = 150;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column2";
            glColumn2.NumericSort = false;
            glColumn2.Text = "sMaterial Density";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn2.Width = 100;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Column1xx";
            glColumn3.NumericSort = false;
            glColumn3.Text = "sFin Cost/Lbs";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn3.Width = 90;
            glColumn4.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn4.CheckBoxes = false;
            glColumn4.DatetimeSort = false;
            glColumn4.ImageIndex = -1;
            glColumn4.Name = "Column1";
            glColumn4.NumericSort = false;
            glColumn4.Text = "sCasing Cost/Lbs";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn4.Width = 100;
            glColumn5.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn5.CheckBoxes = false;
            glColumn5.DatetimeSort = false;
            glColumn5.ImageIndex = -1;
            glColumn5.Name = "Column1xxx";
            glColumn5.NumericSort = false;
            glColumn5.Text = "sTube Cost/Lbs";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn5.Width = 100;
            glColumn6.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn6.CheckBoxes = false;
            glColumn6.DatetimeSort = false;
            glColumn6.ImageIndex = -1;
            glColumn6.Name = "Column2x";
            glColumn6.NumericSort = false;
            glColumn6.Text = "sDrain Pan Cost/Lbs";
            glColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn6.Width = 120;
            this.lvMaterialInfo.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3,
            glColumn4,
            glColumn5,
            glColumn6});
            this.lvMaterialInfo.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvMaterialInfo.FullRowSelect = true;
            this.lvMaterialInfo.GridColor = System.Drawing.Color.LightGray;
            this.lvMaterialInfo.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvMaterialInfo.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvMaterialInfo.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvMaterialInfo.HeaderHeight = 22;
            this.lvMaterialInfo.HeaderVisible = true;
            this.lvMaterialInfo.HeaderWordWrap = false;
            this.lvMaterialInfo.HotColumnTracking = false;
            this.lvMaterialInfo.HotItemTracking = false;
            this.lvMaterialInfo.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvMaterialInfo.HoverEvents = false;
            this.lvMaterialInfo.HoverTime = 1;
            this.lvMaterialInfo.ImageList = null;
            this.lvMaterialInfo.ItemHeight = 25;
            this.lvMaterialInfo.ItemWordWrap = false;
            this.lvMaterialInfo.Location = new System.Drawing.Point(12, 12);
            this.lvMaterialInfo.Name = "lvMaterialInfo";
            this.lvMaterialInfo.Selectable = true;
            this.lvMaterialInfo.SelectedTextColor = System.Drawing.Color.White;
            this.lvMaterialInfo.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvMaterialInfo.ShowBorder = true;
            this.lvMaterialInfo.ShowFocusRect = true;
            this.lvMaterialInfo.Size = new System.Drawing.Size(688, 308);
            this.lvMaterialInfo.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lvMaterialInfo.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvMaterialInfo.TabIndex = 0;
            this.lvMaterialInfo.Text = "glacialList1";
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(338, 327);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmOEMCoilMaterialInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(709, 357);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.lvMaterialInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmOEMCoilMaterialInformation";
            this.Text = "sData Manager - OEM Coil Material Information";
            this.Load += new System.EventHandler(this.frmOEMCoilMaterialInformation_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmOEMCoilMaterialInformation_HelpRequested);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSave;
        private GlacialComponents.Controls.GlacialList lvMaterialInfo;
        private System.Windows.Forms.Button btnHelp;
    }
}