namespace RefplusWebtools.DataManager.OEMCoil
{
    partial class FrmOEMCoilHeaderInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOEMCoilHeaderInformation));
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn4 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn5 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn6 = new GlacialComponents.Controls.GLColumn();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lvHeaderInformation = new GlacialComponents.Controls.GlacialList();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(490, 554);
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
            this.cmdSave.Location = new System.Drawing.Point(12, 554);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(150, 25);
            this.cmdSave.TabIndex = 1;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lvHeaderInformation
            // 
            this.lvHeaderInformation.AllowColumnResize = false;
            this.lvHeaderInformation.AllowMultiselect = false;
            this.lvHeaderInformation.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvHeaderInformation.AlternatingColors = false;
            this.lvHeaderInformation.AutoHeight = false;
            this.lvHeaderInformation.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvHeaderInformation.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1x";
            glColumn1.NumericSort = false;
            glColumn1.Text = "sDiameter";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn1.Width = 70;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column2";
            glColumn2.NumericSort = false;
            glColumn2.Text = "sThickness";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn2.Width = 70;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Column1xx";
            glColumn3.NumericSort = false;
            glColumn3.Text = "sCost Per Foot";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn3.Width = 100;
            glColumn4.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn4.CheckBoxes = false;
            glColumn4.DatetimeSort = false;
            glColumn4.ImageIndex = -1;
            glColumn4.Name = "Column1";
            glColumn4.NumericSort = false;
            glColumn4.Text = "sTCCOST";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn4.Width = 100;
            glColumn5.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn5.CheckBoxes = false;
            glColumn5.DatetimeSort = false;
            glColumn5.ImageIndex = -1;
            glColumn5.Name = "Column1xxx";
            glColumn5.NumericSort = false;
            glColumn5.Text = "sLBSft";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn5.Width = 100;
            glColumn6.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn6.CheckBoxes = false;
            glColumn6.DatetimeSort = false;
            glColumn6.ImageIndex = -1;
            glColumn6.Name = "Column2x";
            glColumn6.NumericSort = false;
            glColumn6.Text = "sST. Steel Cost Per Foot";
            glColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn6.Width = 150;
            this.lvHeaderInformation.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3,
            glColumn4,
            glColumn5,
            glColumn6});
            this.lvHeaderInformation.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvHeaderInformation.FullRowSelect = true;
            this.lvHeaderInformation.GridColor = System.Drawing.Color.LightGray;
            this.lvHeaderInformation.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvHeaderInformation.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvHeaderInformation.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvHeaderInformation.HeaderHeight = 22;
            this.lvHeaderInformation.HeaderVisible = true;
            this.lvHeaderInformation.HeaderWordWrap = false;
            this.lvHeaderInformation.HotColumnTracking = false;
            this.lvHeaderInformation.HotItemTracking = false;
            this.lvHeaderInformation.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvHeaderInformation.HoverEvents = false;
            this.lvHeaderInformation.HoverTime = 1;
            this.lvHeaderInformation.ImageList = null;
            this.lvHeaderInformation.ItemHeight = 25;
            this.lvHeaderInformation.ItemWordWrap = false;
            this.lvHeaderInformation.Location = new System.Drawing.Point(12, 12);
            this.lvHeaderInformation.Name = "lvHeaderInformation";
            this.lvHeaderInformation.Selectable = true;
            this.lvHeaderInformation.SelectedTextColor = System.Drawing.Color.White;
            this.lvHeaderInformation.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvHeaderInformation.ShowBorder = true;
            this.lvHeaderInformation.ShowFocusRect = true;
            this.lvHeaderInformation.Size = new System.Drawing.Size(628, 536);
            this.lvHeaderInformation.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lvHeaderInformation.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvHeaderInformation.TabIndex = 0;
            this.lvHeaderInformation.Text = "glacialList1";
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(307, 555);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmOEMCoilHeaderInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(652, 584);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.lvHeaderInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmOEMCoilHeaderInformation";
            this.Text = "sData Manager - OEM Coil Header Informations";
            this.Load += new System.EventHandler(this.frmOEMCoilHeaderInformation_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmOEMCoilHeaderInformation_HelpRequested);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSave;
        private GlacialComponents.Controls.GlacialList lvHeaderInformation;
        private System.Windows.Forms.Button btnHelp;
    }
}