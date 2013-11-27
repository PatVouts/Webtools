namespace RefplusWebtools.Report.EngineeringReport
{
    partial class FrmEngineeringReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEngineeringReport));
            this.cboUnitSerie = new System.Windows.Forms.ComboBox();
            this.lblUnitSerie = new System.Windows.Forms.Label();
            this.lvModel = new GlacialComponents.Controls.GlacialList();
            this.cmdGenerate = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboUnitSerie
            // 
            this.cboUnitSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnitSerie.FormattingEnabled = true;
            this.cboUnitSerie.Items.AddRange(new object[] {
            "Condenser",
            "Condensing Unit",
            "Evaporator",
            "Fluid Cooler",
            "Gravity Coil"});
            this.cboUnitSerie.Location = new System.Drawing.Point(73, 6);
            this.cboUnitSerie.Name = "cboUnitSerie";
            this.cboUnitSerie.Size = new System.Drawing.Size(316, 21);
            this.cboUnitSerie.TabIndex = 0;
            this.cboUnitSerie.SelectedIndexChanged += new System.EventHandler(this.cboUnitSerie_SelectedIndexChanged);
            // 
            // lblUnitSerie
            // 
            this.lblUnitSerie.AutoSize = true;
            this.lblUnitSerie.Location = new System.Drawing.Point(9, 9);
            this.lblUnitSerie.Name = "lblUnitSerie";
            this.lblUnitSerie.Size = new System.Drawing.Size(58, 13);
            this.lblUnitSerie.TabIndex = 1;
            this.lblUnitSerie.Text = "sUnit Serie";
            // 
            // lvModel
            // 
            this.lvModel.AllowColumnResize = true;
            this.lvModel.AllowMultiselect = false;
            this.lvModel.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvModel.AlternatingColors = false;
            this.lvModel.AutoHeight = true;
            this.lvModel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvModel.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = true;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1";
            glColumn1.NumericSort = false;
            glColumn1.Text = "";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn1.Width = 25;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column2";
            glColumn2.NumericSort = false;
            glColumn2.Text = "";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn2.Width = 320;
            this.lvModel.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2});
            this.lvModel.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvModel.FullRowSelect = true;
            this.lvModel.GridColor = System.Drawing.Color.LightGray;
            this.lvModel.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvModel.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridSolid;
            this.lvModel.GridTypes = GlacialComponents.Controls.GLGridTypes.gridOnExists;
            this.lvModel.HeaderHeight = 22;
            this.lvModel.HeaderVisible = true;
            this.lvModel.HeaderWordWrap = false;
            this.lvModel.HotColumnTracking = false;
            this.lvModel.HotItemTracking = false;
            this.lvModel.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvModel.HoverEvents = false;
            this.lvModel.HoverTime = 1;
            this.lvModel.ImageList = null;
            this.lvModel.ItemHeight = 4;
            this.lvModel.ItemWordWrap = false;
            this.lvModel.Location = new System.Drawing.Point(12, 33);
            this.lvModel.Name = "lvModel";
            this.lvModel.Selectable = true;
            this.lvModel.SelectedTextColor = System.Drawing.Color.White;
            this.lvModel.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvModel.ShowBorder = true;
            this.lvModel.ShowFocusRect = false;
            this.lvModel.Size = new System.Drawing.Size(377, 356);
            this.lvModel.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lvModel.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvModel.TabIndex = 1;
            this.lvModel.Text = "glacialList1";
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.Image = ((System.Drawing.Image)(resources.GetObject("cmdGenerate.Image")));
            this.cmdGenerate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGenerate.Location = new System.Drawing.Point(12, 395);
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Size = new System.Drawing.Size(377, 25);
            this.cmdGenerate.TabIndex = 2;
            this.cmdGenerate.Text = "sGenerate";
            this.cmdGenerate.UseVisualStyleBackColor = true;
            this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(184, 426);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmEngineeringReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(399, 454);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cmdGenerate);
            this.Controls.Add(this.lvModel);
            this.Controls.Add(this.lblUnitSerie);
            this.Controls.Add(this.cboUnitSerie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEngineeringReport";
            this.Text = "sEngineering Report";
            this.Load += new System.EventHandler(this.frmEngineeringReport_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmEngineeringReport_HelpRequested);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboUnitSerie;
        private System.Windows.Forms.Label lblUnitSerie;
        private GlacialComponents.Controls.GlacialList lvModel;
        private System.Windows.Forms.Button cmdGenerate;
        private System.Windows.Forms.Button btnHelp;
    }
}