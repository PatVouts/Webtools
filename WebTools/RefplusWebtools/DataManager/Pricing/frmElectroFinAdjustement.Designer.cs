namespace RefplusWebtools.DataManager.Pricing
{
    partial class FrmElectroFinAdjustement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmElectroFinAdjustement));
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn4 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn5 = new GlacialComponents.Controls.GLColumn();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lvElectroAdjustement = new GlacialComponents.Controls.GlacialList();
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
            // lvElectroAdjustement
            // 
            this.lvElectroAdjustement.AllowColumnResize = false;
            this.lvElectroAdjustement.AllowMultiselect = false;
            this.lvElectroAdjustement.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvElectroAdjustement.AlternatingColors = false;
            this.lvElectroAdjustement.AutoHeight = false;
            this.lvElectroAdjustement.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvElectroAdjustement.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1";
            glColumn1.NumericSort = false;
            glColumn1.Text = "sUniqueID";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 0;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column1x";
            glColumn2.NumericSort = false;
            glColumn2.Text = "sRow";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn2.Width = 60;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Column2";
            glColumn3.NumericSort = false;
            glColumn3.Text = "sFPI";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn3.Width = 60;
            glColumn4.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn4.CheckBoxes = false;
            glColumn4.DatetimeSort = false;
            glColumn4.ImageIndex = -1;
            glColumn4.Name = "Column1xx";
            glColumn4.NumericSort = false;
            glColumn4.Text = "sElectro Rate";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn4.Width = 120;
            glColumn5.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn5.CheckBoxes = false;
            glColumn5.DatetimeSort = false;
            glColumn5.ImageIndex = -1;
            glColumn5.Name = "Column1xxx";
            glColumn5.NumericSort = false;
            glColumn5.Text = "sMin";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn5.Width = 120;
            this.lvElectroAdjustement.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3,
            glColumn4,
            glColumn5});
            this.lvElectroAdjustement.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvElectroAdjustement.FullRowSelect = true;
            this.lvElectroAdjustement.GridColor = System.Drawing.Color.LightGray;
            this.lvElectroAdjustement.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvElectroAdjustement.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvElectroAdjustement.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvElectroAdjustement.HeaderHeight = 22;
            this.lvElectroAdjustement.HeaderVisible = true;
            this.lvElectroAdjustement.HeaderWordWrap = false;
            this.lvElectroAdjustement.HotColumnTracking = false;
            this.lvElectroAdjustement.HotItemTracking = false;
            this.lvElectroAdjustement.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvElectroAdjustement.HoverEvents = false;
            this.lvElectroAdjustement.HoverTime = 1;
            this.lvElectroAdjustement.ImageList = null;
            this.lvElectroAdjustement.ItemHeight = 25;
            this.lvElectroAdjustement.ItemWordWrap = false;
            this.lvElectroAdjustement.Location = new System.Drawing.Point(12, 12);
            this.lvElectroAdjustement.Name = "lvElectroAdjustement";
            this.lvElectroAdjustement.Selectable = true;
            this.lvElectroAdjustement.SelectedTextColor = System.Drawing.Color.White;
            this.lvElectroAdjustement.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvElectroAdjustement.ShowBorder = true;
            this.lvElectroAdjustement.ShowFocusRect = true;
            this.lvElectroAdjustement.Size = new System.Drawing.Size(394, 586);
            this.lvElectroAdjustement.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lvElectroAdjustement.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvElectroAdjustement.TabIndex = 0;
            this.lvElectroAdjustement.Text = "glacialList1";
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(194, 605);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmElectroFinAdjustement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(418, 635);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.lvElectroAdjustement);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmElectroFinAdjustement";
            this.Text = "sData Manager - Electro Fin Adjustement";
            this.Load += new System.EventHandler(this.frmElectroFinAdjustement_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmElectroFinAdjustement_HelpRequested);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSave;
        private GlacialComponents.Controls.GlacialList lvElectroAdjustement;
        private System.Windows.Forms.Button btnHelp;
    }
}