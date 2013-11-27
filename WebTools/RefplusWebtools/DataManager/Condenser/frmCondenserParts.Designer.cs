namespace RefplusWebtools.DataManager.Condenser
{
    partial class FrmCondenserParts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCondenserParts));
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn4 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn5 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn6 = new GlacialComponents.Controls.GLColumn();
            this.cboCondenserSerie = new System.Windows.Forms.ComboBox();
            this.lblCondenserSerie = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lvParts = new GlacialComponents.Controls.GlacialList();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboCondenserSerie
            // 
            this.cboCondenserSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondenserSerie.DropDownWidth = 400;
            this.cboCondenserSerie.FormattingEnabled = true;
            this.cboCondenserSerie.Location = new System.Drawing.Point(130, 8);
            this.cboCondenserSerie.Name = "cboCondenserSerie";
            this.cboCondenserSerie.Size = new System.Drawing.Size(547, 21);
            this.cboCondenserSerie.TabIndex = 0;
            this.cboCondenserSerie.SelectedIndexChanged += new System.EventHandler(this.cboCondenserSerie_SelectedIndexChanged);
            // 
            // lblCondenserSerie
            // 
            this.lblCondenserSerie.AutoSize = true;
            this.lblCondenserSerie.Location = new System.Drawing.Point(12, 10);
            this.lblCondenserSerie.Name = "lblCondenserSerie";
            this.lblCondenserSerie.Size = new System.Drawing.Size(90, 13);
            this.lblCondenserSerie.TabIndex = 106;
            this.lblCondenserSerie.Text = "sCondenser Serie";
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(530, 246);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(150, 25);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(18, 246);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(150, 25);
            this.cmdSave.TabIndex = 2;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lvParts
            // 
            this.lvParts.AllowColumnResize = false;
            this.lvParts.AllowMultiselect = false;
            this.lvParts.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvParts.AlternatingColors = false;
            this.lvParts.AutoHeight = false;
            this.lvParts.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvParts.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1";
            glColumn1.NumericSort = false;
            glColumn1.Text = "sID";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn1.Width = 30;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column1x";
            glColumn2.NumericSort = false;
            glColumn2.Text = "sVoltage";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn2.Width = 100;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Column2";
            glColumn3.NumericSort = false;
            glColumn3.Text = "sMotor";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn3.Width = 120;
            glColumn4.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn4.CheckBoxes = false;
            glColumn4.DatetimeSort = false;
            glColumn4.ImageIndex = -1;
            glColumn4.Name = "Column4";
            glColumn4.NumericSort = false;
            glColumn4.Text = "sMotor Mount";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn4.Width = 120;
            glColumn5.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn5.CheckBoxes = false;
            glColumn5.DatetimeSort = false;
            glColumn5.ImageIndex = -1;
            glColumn5.Name = "Column1xx";
            glColumn5.NumericSort = false;
            glColumn5.Text = "sFan";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn5.Width = 120;
            glColumn6.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn6.CheckBoxes = false;
            glColumn6.DatetimeSort = false;
            glColumn6.ImageIndex = -1;
            glColumn6.Name = "Column2x";
            glColumn6.NumericSort = false;
            glColumn6.Text = "sFan Guard";
            glColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn6.Width = 120;
            this.lvParts.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3,
            glColumn4,
            glColumn5,
            glColumn6});
            this.lvParts.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvParts.FullRowSelect = true;
            this.lvParts.GridColor = System.Drawing.Color.LightGray;
            this.lvParts.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvParts.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvParts.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvParts.HeaderHeight = 22;
            this.lvParts.HeaderVisible = true;
            this.lvParts.HeaderWordWrap = false;
            this.lvParts.HotColumnTracking = false;
            this.lvParts.HotItemTracking = false;
            this.lvParts.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvParts.HoverEvents = false;
            this.lvParts.HoverTime = 1;
            this.lvParts.ImageList = null;
            this.lvParts.ItemHeight = 25;
            this.lvParts.ItemWordWrap = false;
            this.lvParts.Location = new System.Drawing.Point(15, 37);
            this.lvParts.Name = "lvParts";
            this.lvParts.Selectable = true;
            this.lvParts.SelectedTextColor = System.Drawing.Color.White;
            this.lvParts.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvParts.ShowBorder = true;
            this.lvParts.ShowFocusRect = true;
            this.lvParts.Size = new System.Drawing.Size(665, 203);
            this.lvParts.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lvParts.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvParts.TabIndex = 1;
            this.lvParts.Text = "glacialList1";
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(336, 247);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmCondenserParts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(692, 278);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lvParts);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cboCondenserSerie);
            this.Controls.Add(this.lblCondenserSerie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmCondenserParts";
            this.Text = "sData Manager - Condenser Parts";
            this.Load += new System.EventHandler(this.frmCondenserParts_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmCondenserParts_HelpRequested);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCondenserSerie;
        private System.Windows.Forms.Label lblCondenserSerie;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSave;
        private GlacialComponents.Controls.GlacialList lvParts;
        private System.Windows.Forms.Button btnHelp;
    }
}