namespace RefplusWebtools
{
    partial class FrmClipboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClipboard));
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn4 = new GlacialComponents.Controls.GLColumn();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabAdditionnalItems = new System.Windows.Forms.TabPage();
            this.cmdAdditionalItemsClear = new System.Windows.Forms.Button();
            this.cmdAdditionalItemsUnpickAll = new System.Windows.Forms.Button();
            this.cmdAdditionalItemsPickAll = new System.Windows.Forms.Button();
            this.lstAdditionalItems = new GlacialComponents.Controls.GlacialList();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.tabMain.SuspendLayout();
            this.tabAdditionnalItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabAdditionnalItems);
            this.tabMain.Location = new System.Drawing.Point(12, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(733, 458);
            this.tabMain.TabIndex = 0;
            // 
            // tabAdditionnalItems
            // 
            this.tabAdditionnalItems.Controls.Add(this.cmdAdditionalItemsClear);
            this.tabAdditionnalItems.Controls.Add(this.cmdAdditionalItemsUnpickAll);
            this.tabAdditionnalItems.Controls.Add(this.cmdAdditionalItemsPickAll);
            this.tabAdditionnalItems.Controls.Add(this.lstAdditionalItems);
            this.tabAdditionnalItems.Location = new System.Drawing.Point(4, 22);
            this.tabAdditionnalItems.Name = "tabAdditionnalItems";
            this.tabAdditionnalItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdditionnalItems.Size = new System.Drawing.Size(725, 432);
            this.tabAdditionnalItems.TabIndex = 0;
            this.tabAdditionnalItems.Text = "sAdditionnal Items";
            this.tabAdditionnalItems.UseVisualStyleBackColor = true;
            // 
            // cmdAdditionalItemsClear
            // 
            this.cmdAdditionalItemsClear.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdditionalItemsClear.Image")));
            this.cmdAdditionalItemsClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdditionalItemsClear.Location = new System.Drawing.Point(612, 402);
            this.cmdAdditionalItemsClear.Name = "cmdAdditionalItemsClear";
            this.cmdAdditionalItemsClear.Size = new System.Drawing.Size(107, 25);
            this.cmdAdditionalItemsClear.TabIndex = 3;
            this.cmdAdditionalItemsClear.Text = "sClear";
            this.cmdAdditionalItemsClear.UseVisualStyleBackColor = true;
            this.cmdAdditionalItemsClear.Click += new System.EventHandler(this.cmdAdditionalItemsClear_Click);
            // 
            // cmdAdditionalItemsUnpickAll
            // 
            this.cmdAdditionalItemsUnpickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdditionalItemsUnpickAll.Image")));
            this.cmdAdditionalItemsUnpickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdditionalItemsUnpickAll.Location = new System.Drawing.Point(167, 401);
            this.cmdAdditionalItemsUnpickAll.Name = "cmdAdditionalItemsUnpickAll";
            this.cmdAdditionalItemsUnpickAll.Size = new System.Drawing.Size(148, 25);
            this.cmdAdditionalItemsUnpickAll.TabIndex = 2;
            this.cmdAdditionalItemsUnpickAll.Text = "sUnpick All";
            this.cmdAdditionalItemsUnpickAll.UseVisualStyleBackColor = true;
            this.cmdAdditionalItemsUnpickAll.Click += new System.EventHandler(this.cmdAdditionalItemsUnpickAll_Click);
            // 
            // cmdAdditionalItemsPickAll
            // 
            this.cmdAdditionalItemsPickAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdditionalItemsPickAll.Image")));
            this.cmdAdditionalItemsPickAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdditionalItemsPickAll.Location = new System.Drawing.Point(14, 401);
            this.cmdAdditionalItemsPickAll.Name = "cmdAdditionalItemsPickAll";
            this.cmdAdditionalItemsPickAll.Size = new System.Drawing.Size(147, 25);
            this.cmdAdditionalItemsPickAll.TabIndex = 1;
            this.cmdAdditionalItemsPickAll.Text = "sPick All";
            this.cmdAdditionalItemsPickAll.UseVisualStyleBackColor = true;
            this.cmdAdditionalItemsPickAll.Click += new System.EventHandler(this.cmdAdditionalItemsPickAll_Click);
            // 
            // lstAdditionalItems
            // 
            this.lstAdditionalItems.AllowColumnResize = true;
            this.lstAdditionalItems.AllowMultiselect = false;
            this.lstAdditionalItems.AlternateBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lstAdditionalItems.AlternatingColors = true;
            this.lstAdditionalItems.AutoHeight = true;
            this.lstAdditionalItems.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lstAdditionalItems.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = true;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1";
            glColumn1.NumericSort = false;
            glColumn1.Text = "";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 30;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column2";
            glColumn2.NumericSort = false;
            glColumn2.Text = "sDescription";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 300;
            glColumn3.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn3.CheckBoxes = false;
            glColumn3.DatetimeSort = false;
            glColumn3.ImageIndex = -1;
            glColumn3.Name = "Column1x";
            glColumn3.NumericSort = false;
            glColumn3.Text = "sQuantity";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn3.Width = 100;
            glColumn4.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn4.CheckBoxes = false;
            glColumn4.DatetimeSort = false;
            glColumn4.ImageIndex = -1;
            glColumn4.Name = "Column2x";
            glColumn4.NumericSort = false;
            glColumn4.Text = "sPrice";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            glColumn4.Width = 100;
            this.lstAdditionalItems.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3,
            glColumn4});
            this.lstAdditionalItems.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lstAdditionalItems.FullRowSelect = true;
            this.lstAdditionalItems.GridColor = System.Drawing.Color.LightGray;
            this.lstAdditionalItems.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lstAdditionalItems.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lstAdditionalItems.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.lstAdditionalItems.HeaderHeight = 22;
            this.lstAdditionalItems.HeaderVisible = true;
            this.lstAdditionalItems.HeaderWordWrap = false;
            this.lstAdditionalItems.HotColumnTracking = false;
            this.lstAdditionalItems.HotItemTracking = false;
            this.lstAdditionalItems.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lstAdditionalItems.HoverEvents = false;
            this.lstAdditionalItems.HoverTime = 1;
            this.lstAdditionalItems.ImageList = null;
            this.lstAdditionalItems.ItemHeight = 17;
            this.lstAdditionalItems.ItemWordWrap = false;
            this.lstAdditionalItems.Location = new System.Drawing.Point(6, 6);
            this.lstAdditionalItems.Name = "lstAdditionalItems";
            this.lstAdditionalItems.Selectable = true;
            this.lstAdditionalItems.SelectedTextColor = System.Drawing.Color.White;
            this.lstAdditionalItems.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lstAdditionalItems.ShowBorder = true;
            this.lstAdditionalItems.ShowFocusRect = false;
            this.lstAdditionalItems.Size = new System.Drawing.Size(713, 392);
            this.lstAdditionalItems.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lstAdditionalItems.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lstAdditionalItems.TabIndex = 0;
            this.lstAdditionalItems.Text = "glacialList1";
            // 
            // cmdAccept
            // 
            this.cmdAccept.Image = ((System.Drawing.Image)(resources.GetObject("cmdAccept.Image")));
            this.cmdAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAccept.Location = new System.Drawing.Point(12, 475);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(157, 25);
            this.cmdAccept.TabIndex = 1;
            this.cmdAccept.Text = "sAccept";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(588, 475);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(157, 25);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "sCancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(359, 476);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmClipboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(757, 505);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.tabMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmClipboard";
            this.Text = "sClipboard";
            this.Load += new System.EventHandler(this.frmClipboard_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmClipboard_HelpRequested);
            this.tabMain.ResumeLayout(false);
            this.tabAdditionnalItems.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabAdditionnalItems;
        private System.Windows.Forms.Button cmdAccept;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdAdditionalItemsUnpickAll;
        private System.Windows.Forms.Button cmdAdditionalItemsPickAll;
        private GlacialComponents.Controls.GlacialList lstAdditionalItems;
        private System.Windows.Forms.Button cmdAdditionalItemsClear;
        private System.Windows.Forms.Button btnHelp;
    }
}