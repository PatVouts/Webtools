namespace RefplusWebtools.DataManager.Pricing
{
    partial class FrmPricingReturnBendCost
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPricingReturnBendCost));
            this.lvReturnBendCost = new GlacialComponents.Controls.GlacialList();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvReturnBendCost
            // 
            this.lvReturnBendCost.AllowColumnResize = false;
            this.lvReturnBendCost.AllowMultiselect = false;
            this.lvReturnBendCost.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvReturnBendCost.AlternatingColors = false;
            this.lvReturnBendCost.AutoHeight = false;
            this.lvReturnBendCost.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvReturnBendCost.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1x";
            glColumn1.NumericSort = false;
            glColumn1.Text = "sFin Type";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn1.Width = 120;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column2";
            glColumn2.NumericSort = false;
            glColumn2.Text = "sReturn Bend Cost";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn2.Width = 150;
            this.lvReturnBendCost.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2});
            this.lvReturnBendCost.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvReturnBendCost.FullRowSelect = true;
            this.lvReturnBendCost.GridColor = System.Drawing.Color.LightGray;
            this.lvReturnBendCost.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvReturnBendCost.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvReturnBendCost.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvReturnBendCost.HeaderHeight = 22;
            this.lvReturnBendCost.HeaderVisible = true;
            this.lvReturnBendCost.HeaderWordWrap = false;
            this.lvReturnBendCost.HotColumnTracking = false;
            this.lvReturnBendCost.HotItemTracking = false;
            this.lvReturnBendCost.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvReturnBendCost.HoverEvents = false;
            this.lvReturnBendCost.HoverTime = 1;
            this.lvReturnBendCost.ImageList = null;
            this.lvReturnBendCost.ItemHeight = 25;
            this.lvReturnBendCost.ItemWordWrap = false;
            this.lvReturnBendCost.Location = new System.Drawing.Point(12, 12);
            this.lvReturnBendCost.Name = "lvReturnBendCost";
            this.lvReturnBendCost.Selectable = true;
            this.lvReturnBendCost.SelectedTextColor = System.Drawing.Color.White;
            this.lvReturnBendCost.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvReturnBendCost.ShowBorder = true;
            this.lvReturnBendCost.ShowFocusRect = true;
            this.lvReturnBendCost.Size = new System.Drawing.Size(343, 237);
            this.lvReturnBendCost.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lvReturnBendCost.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvReturnBendCost.TabIndex = 0;
            this.lvReturnBendCost.Text = "glacialList1";
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(205, 255);
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
            this.cmdSave.Location = new System.Drawing.Point(12, 255);
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
            this.btnHelp.Location = new System.Drawing.Point(171, 256);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmPricingReturnBendCost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(367, 286);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.lvReturnBendCost);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmPricingReturnBendCost";
            this.Text = "sData Manager - Pricing Return Bend Cost";
            this.Load += new System.EventHandler(this.frmPricingReturnBendCost_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmPricingReturnBendCost_HelpRequested);
            this.ResumeLayout(false);

        }

        #endregion

        private GlacialComponents.Controls.GlacialList lvReturnBendCost;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button btnHelp;
    }
}