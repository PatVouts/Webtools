namespace RefplusWebtools.DataManager.Generic
{
    partial class FrmPublicityManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPublicityManager));
            this.lvPublicity = new GlacialComponents.Controls.GlacialList();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvPublicity
            // 
            this.lvPublicity.AllowColumnResize = false;
            this.lvPublicity.AllowMultiselect = false;
            this.lvPublicity.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvPublicity.AlternatingColors = false;
            this.lvPublicity.AutoHeight = false;
            this.lvPublicity.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvPublicity.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.UserType;
            glColumn1.CheckBoxes = true;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column2";
            glColumn1.NumericSort = false;
            glColumn1.Text = "";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn1.Width = 25;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column1x";
            glColumn2.NumericSort = false;
            glColumn2.Text = "sName";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn2.Width = 200;
            this.lvPublicity.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2});
            this.lvPublicity.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvPublicity.FullRowSelect = true;
            this.lvPublicity.GridColor = System.Drawing.Color.LightGray;
            this.lvPublicity.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvPublicity.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvPublicity.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lvPublicity.HeaderHeight = 22;
            this.lvPublicity.HeaderVisible = true;
            this.lvPublicity.HeaderWordWrap = false;
            this.lvPublicity.HotColumnTracking = false;
            this.lvPublicity.HotItemTracking = false;
            this.lvPublicity.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvPublicity.HoverEvents = false;
            this.lvPublicity.HoverTime = 1;
            this.lvPublicity.ImageList = null;
            this.lvPublicity.ItemHeight = 25;
            this.lvPublicity.ItemWordWrap = false;
            this.lvPublicity.Location = new System.Drawing.Point(12, 12);
            this.lvPublicity.Name = "lvPublicity";
            this.lvPublicity.Selectable = true;
            this.lvPublicity.SelectedTextColor = System.Drawing.Color.White;
            this.lvPublicity.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvPublicity.ShowBorder = true;
            this.lvPublicity.ShowFocusRect = true;
            this.lvPublicity.Size = new System.Drawing.Size(272, 445);
            this.lvPublicity.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lvPublicity.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvPublicity.TabIndex = 2;
            this.lvPublicity.Text = "glacialList1";
            this.lvPublicity.DoubleClick += new System.EventHandler(this.lvPublicity_DoubleClick);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(12, 463);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(134, 23);
            this.cmdAdd.TabIndex = 3;
            this.cmdAdd.Text = "sAdd";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(150, 463);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(134, 23);
            this.cmdEdit.TabIndex = 8;
            this.cmdEdit.Text = "sEdit";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(160, 521);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(124, 23);
            this.cmdClose.TabIndex = 9;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(12, 492);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(272, 23);
            this.cmdSave.TabIndex = 10;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmPublicityManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(293, 548);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.lvPublicity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPublicityManager";
            this.Text = "sData Manager - Publicity Manager";
            this.Load += new System.EventHandler(this.frmPublicityManager_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GlacialComponents.Controls.GlacialList lvPublicity;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSave;
    }
}