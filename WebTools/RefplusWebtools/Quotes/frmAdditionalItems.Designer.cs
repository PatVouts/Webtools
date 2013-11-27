namespace RefplusWebtools.Quotes
{
    partial class FrmAdditionalItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdditionalItems));
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lstAdditionnalItems = new GlacialComponents.Controls.GlacialList();
            this.cmdAddItem = new System.Windows.Forms.Button();
            this.cmdRemoveItem = new System.Windows.Forms.Button();
            this.lblMaxCharacters = new System.Windows.Forms.Label();
            this.cmdCopy = new System.Windows.Forms.Button();
            this.cmdPaste = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.cboSpecial = new System.Windows.Forms.ComboBox();
            this.cmdAddNewSpecial = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(12, 371);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(117, 24);
            this.cmdSave.TabIndex = 5;
            this.cmdSave.Text = "sSave";
            this.cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lstAdditionnalItems
            // 
            this.lstAdditionnalItems.AllowColumnResize = false;
            this.lstAdditionnalItems.AllowMultiselect = false;
            this.lstAdditionnalItems.AlternateBackground = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lstAdditionnalItems.AlternatingColors = false;
            this.lstAdditionnalItems.AutoHeight = true;
            this.lstAdditionnalItems.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lstAdditionnalItems.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.TextBox;
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
            glColumn2.Name = "Quantity";
            glColumn2.NumericSort = false;
            glColumn2.Text = "sQTY";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn2.Width = 60;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "PriceEach";
            glColumn3.NumericSort = false;
            glColumn3.Text = "sList Price Each";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            glColumn3.Width = 150;
            this.lstAdditionnalItems.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3});
            this.lstAdditionnalItems.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lstAdditionnalItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAdditionnalItems.FullRowSelect = true;
            this.lstAdditionnalItems.GridColor = System.Drawing.Color.Silver;
            this.lstAdditionnalItems.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lstAdditionnalItems.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lstAdditionnalItems.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lstAdditionnalItems.HeaderHeight = 20;
            this.lstAdditionnalItems.HeaderVisible = true;
            this.lstAdditionnalItems.HeaderWordWrap = false;
            this.lstAdditionnalItems.HotColumnTracking = false;
            this.lstAdditionnalItems.HotItemTracking = false;
            this.lstAdditionnalItems.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lstAdditionnalItems.HoverEvents = false;
            this.lstAdditionnalItems.HoverTime = 1;
            this.lstAdditionnalItems.ImageList = null;
            this.lstAdditionnalItems.ItemHeight = 17;
            this.lstAdditionnalItems.ItemWordWrap = true;
            this.lstAdditionnalItems.Location = new System.Drawing.Point(12, 21);
            this.lstAdditionnalItems.Name = "lstAdditionnalItems";
            this.lstAdditionnalItems.Selectable = true;
            this.lstAdditionnalItems.SelectedTextColor = System.Drawing.Color.White;
            this.lstAdditionnalItems.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lstAdditionnalItems.ShowBorder = true;
            this.lstAdditionnalItems.ShowFocusRect = true;
            this.lstAdditionnalItems.Size = new System.Drawing.Size(694, 314);
            this.lstAdditionnalItems.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lstAdditionnalItems.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lstAdditionnalItems.TabIndex = 0;
            this.lstAdditionnalItems.Text = "glacialList1";
            // 
            // cmdAddItem
            // 
            this.cmdAddItem.Image = ((System.Drawing.Image)(resources.GetObject("cmdAddItem.Image")));
            this.cmdAddItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAddItem.Location = new System.Drawing.Point(12, 341);
            this.cmdAddItem.Name = "cmdAddItem";
            this.cmdAddItem.Size = new System.Drawing.Size(117, 24);
            this.cmdAddItem.TabIndex = 1;
            this.cmdAddItem.Text = "sAdd New Item";
            this.cmdAddItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAddItem.UseVisualStyleBackColor = true;
            this.cmdAddItem.Click += new System.EventHandler(this.cmdAddItem_Click);
            // 
            // cmdRemoveItem
            // 
            this.cmdRemoveItem.Image = ((System.Drawing.Image)(resources.GetObject("cmdRemoveItem.Image")));
            this.cmdRemoveItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRemoveItem.Location = new System.Drawing.Point(135, 341);
            this.cmdRemoveItem.Name = "cmdRemoveItem";
            this.cmdRemoveItem.Size = new System.Drawing.Size(117, 24);
            this.cmdRemoveItem.TabIndex = 2;
            this.cmdRemoveItem.Text = "sRemove Item";
            this.cmdRemoveItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdRemoveItem.UseVisualStyleBackColor = true;
            this.cmdRemoveItem.Click += new System.EventHandler(this.cmdRemoveItem_Click);
            // 
            // lblMaxCharacters
            // 
            this.lblMaxCharacters.AutoSize = true;
            this.lblMaxCharacters.Location = new System.Drawing.Point(12, 5);
            this.lblMaxCharacters.Name = "lblMaxCharacters";
            this.lblMaxCharacters.Size = new System.Drawing.Size(460, 13);
            this.lblMaxCharacters.TabIndex = 81;
            this.lblMaxCharacters.Text = "sA maximum of 200 characters is allowed for description. Extra character after th" +
    "is limit will be cut";
            this.lblMaxCharacters.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMaxCharacters.Click += new System.EventHandler(this.lblMaxCharacters_Click);
            // 
            // cmdCopy
            // 
            this.cmdCopy.Image = ((System.Drawing.Image)(resources.GetObject("cmdCopy.Image")));
            this.cmdCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCopy.Location = new System.Drawing.Point(258, 341);
            this.cmdCopy.Name = "cmdCopy";
            this.cmdCopy.Size = new System.Drawing.Size(66, 24);
            this.cmdCopy.TabIndex = 3;
            this.cmdCopy.Text = "sCopy";
            this.cmdCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdCopy.UseVisualStyleBackColor = true;
            this.cmdCopy.Click += new System.EventHandler(this.cmdCopy_Click);
            // 
            // cmdPaste
            // 
            this.cmdPaste.Image = ((System.Drawing.Image)(resources.GetObject("cmdPaste.Image")));
            this.cmdPaste.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPaste.Location = new System.Drawing.Point(330, 341);
            this.cmdPaste.Name = "cmdPaste";
            this.cmdPaste.Size = new System.Drawing.Size(66, 24);
            this.cmdPaste.TabIndex = 4;
            this.cmdPaste.Text = "sPaste";
            this.cmdPaste.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPaste.UseVisualStyleBackColor = true;
            this.cmdPaste.Click += new System.EventHandler(this.cmdPaste_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(548, 371);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(158, 24);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(317, 371);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 6;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // cboSpecial
            // 
            this.cboSpecial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSpecial.FormattingEnabled = true;
            this.cboSpecial.Items.AddRange(new object[] {
            "Condensing Unit Options",
            "Evaporator Options"});
            this.cboSpecial.Location = new System.Drawing.Point(454, 342);
            this.cboSpecial.Name = "cboSpecial";
            this.cboSpecial.Size = new System.Drawing.Size(158, 21);
            this.cboSpecial.TabIndex = 82;
            this.cboSpecial.Visible = false;
            // 
            // cmdAddNewSpecial
            // 
            this.cmdAddNewSpecial.Image = ((System.Drawing.Image)(resources.GetObject("cmdAddNewSpecial.Image")));
            this.cmdAddNewSpecial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAddNewSpecial.Location = new System.Drawing.Point(618, 341);
            this.cmdAddNewSpecial.Name = "cmdAddNewSpecial";
            this.cmdAddNewSpecial.Size = new System.Drawing.Size(88, 24);
            this.cmdAddNewSpecial.TabIndex = 83;
            this.cmdAddNewSpecial.Text = "sAdd New";
            this.cmdAddNewSpecial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAddNewSpecial.UseVisualStyleBackColor = true;
            this.cmdAddNewSpecial.Visible = false;
            this.cmdAddNewSpecial.Click += new System.EventHandler(this.cmdAddNewSpecial_Click);
            // 
            // frmAdditionalItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(718, 401);
            this.Controls.Add(this.cmdAddNewSpecial);
            this.Controls.Add(this.cboSpecial);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cmdPaste);
            this.Controls.Add(this.cmdCopy);
            this.Controls.Add(this.lblMaxCharacters);
            this.Controls.Add(this.cmdRemoveItem);
            this.Controls.Add(this.cmdAddItem);
            this.Controls.Add(this.lstAdditionnalItems);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAdditionalItems";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Additional Items";
            this.Load += new System.EventHandler(this.frmAdditionalItems_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmAdditionalItems_HelpRequested);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSave;
        private GlacialComponents.Controls.GlacialList lstAdditionnalItems;
        private System.Windows.Forms.Button cmdAddItem;
        private System.Windows.Forms.Button cmdRemoveItem;
        private System.Windows.Forms.Label lblMaxCharacters;
        private System.Windows.Forms.Button cmdCopy;
        private System.Windows.Forms.Button cmdPaste;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.ComboBox cboSpecial;
        private System.Windows.Forms.Button cmdAddNewSpecial;
    }
}