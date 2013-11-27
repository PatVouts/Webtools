namespace RefplusWebtools.DataManager.Generic
{
    partial class FrmModelList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModelList));
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            this.grpInside = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmd_Assign = new System.Windows.Forms.Button();
            this.lblNewModel = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.MaskedTextBox();
            this.AddItem = new System.Windows.Forms.Button();
            this.lvModels = new GlacialComponents.Controls.GlacialList();
            this.grpOutside = new System.Windows.Forms.GroupBox();
            this.cmd_AddListOfModels = new System.Windows.Forms.Button();
            this.grpInside.SuspendLayout();
            this.grpOutside.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpInside
            // 
            this.grpInside.AutoSize = true;
            this.grpInside.Controls.Add(this.label1);
            this.grpInside.Controls.Add(this.maskedTextBox1);
            this.grpInside.Controls.Add(this.button1);
            this.grpInside.Controls.Add(this.cmd_Assign);
            this.grpInside.Controls.Add(this.lblNewModel);
            this.grpInside.Controls.Add(this.txtModel);
            this.grpInside.Controls.Add(this.AddItem);
            this.grpInside.Controls.Add(this.lvModels);
            this.grpInside.Location = new System.Drawing.Point(6, 10);
            this.grpInside.Name = "grpInside";
            this.grpInside.Size = new System.Drawing.Size(918, 636);
            this.grpInside.TabIndex = 29;
            this.grpInside.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "sText To Remove";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.HideSelection = false;
            this.maskedTextBox1.Location = new System.Drawing.Point(122, 24);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(247, 20);
            this.maskedTextBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(392, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(515, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "sRemove all items containing entered text";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // cmd_Assign
            // 
            this.cmd_Assign.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmd_Assign.Location = new System.Drawing.Point(715, 589);
            this.cmd_Assign.Name = "cmd_Assign";
            this.cmd_Assign.Size = new System.Drawing.Size(192, 28);
            this.cmd_Assign.TabIndex = 6;
            this.cmd_Assign.Text = "sAssign models to options";
            this.cmd_Assign.UseVisualStyleBackColor = true;
            this.cmd_Assign.Click += new System.EventHandler(this.cmd_Assign_Click);
            // 
            // lblNewModel
            // 
            this.lblNewModel.AutoSize = true;
            this.lblNewModel.Location = new System.Drawing.Point(11, 597);
            this.lblNewModel.Name = "lblNewModel";
            this.lblNewModel.Size = new System.Drawing.Size(66, 13);
            this.lblNewModel.TabIndex = 36;
            this.lblNewModel.Text = "sNew Model";
            // 
            // txtModel
            // 
            this.txtModel.HideSelection = false;
            this.txtModel.Location = new System.Drawing.Point(122, 594);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(264, 20);
            this.txtModel.TabIndex = 4;
            // 
            // AddItem
            // 
            this.AddItem.Image = ((System.Drawing.Image)(resources.GetObject("AddItem.Image")));
            this.AddItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddItem.Location = new System.Drawing.Point(392, 589);
            this.AddItem.Name = "AddItem";
            this.AddItem.Size = new System.Drawing.Size(192, 28);
            this.AddItem.TabIndex = 5;
            this.AddItem.Text = "sAdd Item To List";
            this.AddItem.UseVisualStyleBackColor = true;
            this.AddItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // lvModels
            // 
            this.lvModels.AllowColumnResize = true;
            this.lvModels.AllowMultiselect = true;
            this.lvModels.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.lvModels.AlternatingColors = false;
            this.lvModels.AutoHeight = true;
            this.lvModels.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvModels.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.DatetimeSort = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "Column1";
            glColumn1.NumericSort = false;
            glColumn1.Text = "Models";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn1.Width = 897;
            this.lvModels.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1});
            this.lvModels.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.lvModels.FullRowSelect = true;
            this.lvModels.GridColor = System.Drawing.Color.LightGray;
            this.lvModels.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.lvModels.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridSolid;
            this.lvModels.GridTypes = GlacialComponents.Controls.GLGridTypes.gridOnExists;
            this.lvModels.HeaderHeight = 22;
            this.lvModels.HeaderVisible = true;
            this.lvModels.HeaderWordWrap = false;
            this.lvModels.HotColumnTracking = false;
            this.lvModels.HotItemTracking = false;
            this.lvModels.HotTrackingColor = System.Drawing.Color.LightGray;
            this.lvModels.HoverEvents = false;
            this.lvModels.HoverTime = 1;
            this.lvModels.ImageList = null;
            this.lvModels.ItemHeight = 17;
            this.lvModels.ItemWordWrap = false;
            this.lvModels.Location = new System.Drawing.Point(6, 53);
            this.lvModels.Name = "lvModels";
            this.lvModels.Selectable = true;
            this.lvModels.SelectedTextColor = System.Drawing.Color.White;
            this.lvModels.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvModels.ShowBorder = true;
            this.lvModels.ShowFocusRect = false;
            this.lvModels.Size = new System.Drawing.Size(901, 530);
            this.lvModels.SortType = GlacialComponents.Controls.SortTypes.InsertionSort;
            this.lvModels.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvModels.TabIndex = 3;
            this.lvModels.Text = "glacialList1";
            this.lvModels.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvModels_KeyDown_1);
            // 
            // grpOutside
            // 
            this.grpOutside.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOutside.Controls.Add(this.grpInside);
            this.grpOutside.Location = new System.Drawing.Point(6, 2);
            this.grpOutside.Name = "grpOutside";
            this.grpOutside.Size = new System.Drawing.Size(941, 657);
            this.grpOutside.TabIndex = 30;
            this.grpOutside.TabStop = false;
            // 
            // cmd_AddListOfModels
            // 
            this.cmd_AddListOfModels.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmd_AddListOfModels.Location = new System.Drawing.Point(26, 665);
            this.cmd_AddListOfModels.Name = "cmd_AddListOfModels";
            this.cmd_AddListOfModels.Size = new System.Drawing.Size(274, 35);
            this.cmd_AddListOfModels.TabIndex = 40;
            this.cmd_AddListOfModels.Text = "sSelect list of models to add";
            this.cmd_AddListOfModels.UseVisualStyleBackColor = true;
            this.cmd_AddListOfModels.Click += new System.EventHandler(this.cmd_AddListOfModels_Click);
            // 
            // FrmModelList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(953, 712);
            this.Controls.Add(this.cmd_AddListOfModels);
            this.Controls.Add(this.grpOutside);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmModelList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "sData Manager - Condensing Unit Options";
            this.Load += new System.EventHandler(this.frmModelList_Load);
            this.grpInside.ResumeLayout(false);
            this.grpInside.PerformLayout();
            this.grpOutside.ResumeLayout(false);
            this.grpOutside.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInside;
        private System.Windows.Forms.GroupBox grpOutside;
        private GlacialComponents.Controls.GlacialList lvModels;
        private System.Windows.Forms.Button AddItem;
        private System.Windows.Forms.MaskedTextBox txtModel;
        private System.Windows.Forms.Label lblNewModel;
        private System.Windows.Forms.Button cmd_Assign;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmd_AddListOfModels;

    }
}