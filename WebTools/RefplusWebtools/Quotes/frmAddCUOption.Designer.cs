namespace RefplusWebtools.Quotes
{
    partial class FrmAddCUOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddCUOption));
            this.lstCUOptions = new GlacialComponents.Controls.GlacialList();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstCUOptions
            // 
            this.lstCUOptions.AllowColumnResize = false;
            this.lstCUOptions.AllowMultiselect = false;
            this.lstCUOptions.AlternateBackground = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lstCUOptions.AlternatingColors = false;
            this.lstCUOptions.AutoHeight = true;
            this.lstCUOptions.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lstCUOptions.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Description";
            glColumn1.NumericSort = false;
            glColumn1.Text = "sDescription";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            glColumn1.Width = 450;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "PriceEach";
            glColumn2.NumericSort = false;
            glColumn2.Text = "sList Price";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            glColumn2.Width = 150;
            this.lstCUOptions.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2});
            this.lstCUOptions.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lstCUOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCUOptions.FullRowSelect = true;
            this.lstCUOptions.GridColor = System.Drawing.Color.Silver;
            this.lstCUOptions.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lstCUOptions.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lstCUOptions.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lstCUOptions.HeaderHeight = 20;
            this.lstCUOptions.HeaderVisible = true;
            this.lstCUOptions.HeaderWordWrap = false;
            this.lstCUOptions.HotColumnTracking = false;
            this.lstCUOptions.HotItemTracking = false;
            this.lstCUOptions.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lstCUOptions.HoverEvents = false;
            this.lstCUOptions.HoverTime = 1;
            this.lstCUOptions.ImageList = null;
            this.lstCUOptions.ItemHeight = 17;
            this.lstCUOptions.ItemWordWrap = true;
            this.lstCUOptions.Location = new System.Drawing.Point(12, 12);
            this.lstCUOptions.Name = "lstCUOptions";
            this.lstCUOptions.Selectable = true;
            this.lstCUOptions.SelectedTextColor = System.Drawing.Color.White;
            this.lstCUOptions.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lstCUOptions.ShowBorder = true;
            this.lstCUOptions.ShowFocusRect = true;
            this.lstCUOptions.Size = new System.Drawing.Size(627, 314);
            this.lstCUOptions.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lstCUOptions.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lstCUOptions.TabIndex = 1;
            this.lstCUOptions.Text = "glacialList1";
            // 
            // cmdAdd
            // 
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(12, 332);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(150, 25);
            this.cmdAdd.TabIndex = 7;
            this.cmdAdd.Text = "sAdd";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(489, 332);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(150, 25);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmAddCUOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(651, 364);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.lstCUOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddCUOption";
            this.Text = "sAdd Condensing Unit Options";
            this.Load += new System.EventHandler(this.frmAddCUOption_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GlacialComponents.Controls.GlacialList lstCUOptions;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdClose;
    }
}