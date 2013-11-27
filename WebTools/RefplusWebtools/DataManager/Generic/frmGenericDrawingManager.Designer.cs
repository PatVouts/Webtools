namespace RefplusWebtools.DataManager.Generic
{
    partial class FrmGenericDrawingManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGenericDrawingManager));
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            this.cmdUploadAndPreviewFile = new System.Windows.Forms.Button();
            this.cboDrawing = new System.Windows.Forms.ComboBox();
            this.lblDrawing = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.lvDrawingList = new GlacialComponents.Controls.GlacialList();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdLoad = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdUploadAndPreviewFile
            // 
            this.cmdUploadAndPreviewFile.Image = ((System.Drawing.Image)(resources.GetObject("cmdUploadAndPreviewFile.Image")));
            this.cmdUploadAndPreviewFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUploadAndPreviewFile.Location = new System.Drawing.Point(354, 405);
            this.cmdUploadAndPreviewFile.Name = "cmdUploadAndPreviewFile";
            this.cmdUploadAndPreviewFile.Size = new System.Drawing.Size(183, 25);
            this.cmdUploadAndPreviewFile.TabIndex = 157;
            this.cmdUploadAndPreviewFile.Text = "sUpload and preview files";
            this.cmdUploadAndPreviewFile.UseVisualStyleBackColor = true;
            this.cmdUploadAndPreviewFile.Click += new System.EventHandler(this.cmdUploadFileAndPreview_Click);
            // 
            // cboDrawing
            // 
            this.cboDrawing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDrawing.FormattingEnabled = true;
            this.cboDrawing.Location = new System.Drawing.Point(80, 408);
            this.cboDrawing.Name = "cboDrawing";
            this.cboDrawing.Size = new System.Drawing.Size(268, 21);
            this.cboDrawing.TabIndex = 156;
            // 
            // lblDrawing
            // 
            this.lblDrawing.AutoSize = true;
            this.lblDrawing.Location = new System.Drawing.Point(9, 411);
            this.lblDrawing.Name = "lblDrawing";
            this.lblDrawing.Size = new System.Drawing.Size(51, 13);
            this.lblDrawing.TabIndex = 155;
            this.lblDrawing.Text = "sDrawing";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(9, 385);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(41, 13);
            this.lblModel.TabIndex = 159;
            this.lblModel.Text = "sModel";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(80, 382);
            this.txtModel.MaxLength = 255;
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(457, 20);
            this.txtModel.TabIndex = 158;
            // 
            // lvDrawingList
            // 
            this.lvDrawingList.AllowColumnResize = true;
            this.lvDrawingList.AllowMultiselect = false;
            this.lvDrawingList.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvDrawingList.AlternatingColors = false;
            this.lvDrawingList.AutoHeight = true;
            this.lvDrawingList.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvDrawingList.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1";
            glColumn1.NumericSort = false;
            glColumn1.Text = "sModel";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 250;
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn2.CheckBoxes = false;
            glColumn2.DatetimeSort = false;
            glColumn2.ImageIndex = -1;
            glColumn2.Name = "Column1x";
            glColumn2.NumericSort = false;
            glColumn2.Text = "sFile";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 250;
            this.lvDrawingList.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2});
            this.lvDrawingList.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvDrawingList.FullRowSelect = true;
            this.lvDrawingList.GridColor = System.Drawing.Color.LightGray;
            this.lvDrawingList.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvDrawingList.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridDashed;
            this.lvDrawingList.GridTypes = GlacialComponents.Controls.GLGridTypes.gridOnExists;
            this.lvDrawingList.HeaderHeight = 22;
            this.lvDrawingList.HeaderVisible = true;
            this.lvDrawingList.HeaderWordWrap = false;
            this.lvDrawingList.HotColumnTracking = false;
            this.lvDrawingList.HotItemTracking = false;
            this.lvDrawingList.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvDrawingList.HoverEvents = false;
            this.lvDrawingList.HoverTime = 1;
            this.lvDrawingList.ImageList = null;
            this.lvDrawingList.ItemHeight = 17;
            this.lvDrawingList.ItemWordWrap = false;
            this.lvDrawingList.Location = new System.Drawing.Point(11, 12);
            this.lvDrawingList.Name = "lvDrawingList";
            this.lvDrawingList.Selectable = true;
            this.lvDrawingList.SelectedTextColor = System.Drawing.Color.White;
            this.lvDrawingList.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvDrawingList.ShowBorder = true;
            this.lvDrawingList.ShowFocusRect = false;
            this.lvDrawingList.Size = new System.Drawing.Size(526, 335);
            this.lvDrawingList.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lvDrawingList.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvDrawingList.TabIndex = 160;
            this.lvDrawingList.Text = "glacialList1";
            this.lvDrawingList.Click += new System.EventHandler(this.lvDrawingList_Click);
            this.lvDrawingList.DoubleClick += new System.EventHandler(this.lvDrawingList_DoubleClick);
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(11, 435);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(183, 25);
            this.cmdSave.TabIndex = 161;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(354, 436);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(183, 25);
            this.cmdClose.TabIndex = 162;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdLoad
            // 
            this.cmdLoad.Image = ((System.Drawing.Image)(resources.GetObject("cmdLoad.Image")));
            this.cmdLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLoad.Location = new System.Drawing.Point(11, 353);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(183, 23);
            this.cmdLoad.TabIndex = 163;
            this.cmdLoad.Text = "sLoad Selected";
            this.cmdLoad.UseVisualStyleBackColor = true;
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(354, 353);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(183, 23);
            this.cmdDelete.TabIndex = 164;
            this.cmdDelete.Text = "sDelete Selected";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // FrmGenericDrawingManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(547, 470);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdLoad);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.lvDrawingList);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.cmdUploadAndPreviewFile);
            this.Controls.Add(this.cboDrawing);
            this.Controls.Add(this.lblDrawing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGenericDrawingManager";
            this.Text = "sData Manager - Generic Drawing Manager";
            this.Load += new System.EventHandler(this.frmCondenserDrawingManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdUploadAndPreviewFile;
        private System.Windows.Forms.ComboBox cboDrawing;
        private System.Windows.Forms.Label lblDrawing;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TextBox txtModel;
        private GlacialComponents.Controls.GlacialList lvDrawingList;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdLoad;
        private System.Windows.Forms.Button cmdDelete;
    }
}