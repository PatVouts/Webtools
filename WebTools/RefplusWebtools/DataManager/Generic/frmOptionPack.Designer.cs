namespace RefplusWebtools.DataManager.Generic
{
    partial class FrmOptionPack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOptionPack));
            this.PieceTableView = new System.Windows.Forms.GroupBox();
            this.dgPieces = new System.Windows.Forms.DataGridView();
            this.PartNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Each = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdClose = new System.Windows.Forms.Button();
            this.KitManagement = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnLogic = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.sMinimumAccessLevel = new System.Windows.Forms.Label();
            this.rdioUpdated = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.rdioCurrent = new System.Windows.Forms.RadioButton();
            this.txtListPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdChoose = new System.Windows.Forms.Button();
            this.txtBoxFactor = new System.Windows.Forms.TextBox();
            this.lblFactor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblModified = new System.Windows.Forms.Label();
            this.txtModified = new System.Windows.Forms.TextBox();
            this.lblLoaded = new System.Windows.Forms.Label();
            this.txtLoaded = new System.Windows.Forms.TextBox();
            this.cmd_remove = new System.Windows.Forms.Button();
            this.lblKitType = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtCostUpdated = new System.Windows.Forms.TextBox();
            this.txtCostNotUpdated = new System.Windows.Forms.TextBox();
            this.lblTotalCostUpdated = new System.Windows.Forms.Label();
            this.lblTotalCostNotUpdated = new System.Windows.Forms.Label();
            this.cmdUpdatePrice = new System.Windows.Forms.Button();
            this.kitsComboBox = new System.Windows.Forms.ComboBox();
            this.cmdDeleteKit = new System.Windows.Forms.Button();
            this.cmdSaveKit = new System.Windows.Forms.Button();
            this.grpOpenedKit = new System.Windows.Forms.GroupBox();
            this.dgKits = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdAddKit = new System.Windows.Forms.Button();
            this.PieceSearch = new System.Windows.Forms.GroupBox();
            this.sInitialize = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.cmdSearchPieces = new System.Windows.Forms.Button();
            this.DescriptionRadio = new System.Windows.Forms.RadioButton();
            this.PartRadio = new System.Windows.Forms.RadioButton();
            this.sDateUpdated = new System.Windows.Forms.Label();
            this.txt_date = new System.Windows.Forms.TextBox();
            this.btnSytelineOpen = new System.Windows.Forms.Button();
            this.btnManualListOpen = new System.Windows.Forms.Button();
            this.PieceTableView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPieces)).BeginInit();
            this.KitManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.grpOpenedKit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgKits)).BeginInit();
            this.PieceSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // PieceTableView
            // 
            this.PieceTableView.Controls.Add(this.dgPieces);
            this.PieceTableView.Location = new System.Drawing.Point(541, 101);
            this.PieceTableView.Name = "PieceTableView";
            this.PieceTableView.Size = new System.Drawing.Size(620, 670);
            this.PieceTableView.TabIndex = 999;
            this.PieceTableView.TabStop = false;
            this.PieceTableView.Text = "sPieces View";
            // 
            // dgPieces
            // 
            this.dgPieces.AllowUserToAddRows = false;
            this.dgPieces.AllowUserToDeleteRows = false;
            this.dgPieces.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgPieces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPieces.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PartNumber,
            this.Description,
            this.Price,
            this.Each});
            this.dgPieces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPieces.Location = new System.Drawing.Point(3, 16);
            this.dgPieces.Name = "dgPieces";
            this.dgPieces.ReadOnly = true;
            this.dgPieces.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPieces.Size = new System.Drawing.Size(614, 651);
            this.dgPieces.TabIndex = 23;
            this.dgPieces.TabStop = false;
            this.dgPieces.DoubleClick += new System.EventHandler(this.dgPieces_DoubleClick);
            this.dgPieces.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgPieces_KeyPress);
            // 
            // PartNumber
            // 
            this.PartNumber.HeaderText = "Part Number";
            this.PartNumber.Name = "PartNumber";
            this.PartNumber.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 370;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 50;
            // 
            // Each
            // 
            this.Each.HeaderText = "Each";
            this.Each.Name = "Each";
            this.Each.ReadOnly = true;
            this.Each.Width = 50;
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(1043, 775);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(113, 27);
            this.cmdClose.TabIndex = 25;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click_1);
            // 
            // KitManagement
            // 
            this.KitManagement.Controls.Add(this.button3);
            this.KitManagement.Controls.Add(this.button2);
            this.KitManagement.Controls.Add(this.btnLogic);
            this.KitManagement.Controls.Add(this.numericUpDown1);
            this.KitManagement.Controls.Add(this.sMinimumAccessLevel);
            this.KitManagement.Controls.Add(this.rdioUpdated);
            this.KitManagement.Controls.Add(this.label3);
            this.KitManagement.Controls.Add(this.rdioCurrent);
            this.KitManagement.Controls.Add(this.txtListPrice);
            this.KitManagement.Controls.Add(this.label4);
            this.KitManagement.Controls.Add(this.cmdChoose);
            this.KitManagement.Controls.Add(this.txtBoxFactor);
            this.KitManagement.Controls.Add(this.lblFactor);
            this.KitManagement.Controls.Add(this.label1);
            this.KitManagement.Controls.Add(this.label2);
            this.KitManagement.Controls.Add(this.lblModified);
            this.KitManagement.Controls.Add(this.txtModified);
            this.KitManagement.Controls.Add(this.lblLoaded);
            this.KitManagement.Controls.Add(this.txtLoaded);
            this.KitManagement.Controls.Add(this.cmd_remove);
            this.KitManagement.Controls.Add(this.lblKitType);
            this.KitManagement.Controls.Add(this.comboBox1);
            this.KitManagement.Controls.Add(this.txtCostUpdated);
            this.KitManagement.Controls.Add(this.txtCostNotUpdated);
            this.KitManagement.Controls.Add(this.lblTotalCostUpdated);
            this.KitManagement.Controls.Add(this.lblTotalCostNotUpdated);
            this.KitManagement.Controls.Add(this.cmdUpdatePrice);
            this.KitManagement.Controls.Add(this.kitsComboBox);
            this.KitManagement.Controls.Add(this.cmdDeleteKit);
            this.KitManagement.Controls.Add(this.cmdSaveKit);
            this.KitManagement.Controls.Add(this.grpOpenedKit);
            this.KitManagement.Location = new System.Drawing.Point(5, 13);
            this.KitManagement.Name = "KitManagement";
            this.KitManagement.Size = new System.Drawing.Size(528, 826);
            this.KitManagement.TabIndex = 999;
            this.KitManagement.TabStop = false;
            this.KitManagement.Text = "sKit Management";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(12, 373);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(27, 34);
            this.button3.TabIndex = 1009;
            this.button3.Text = "v";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(12, 335);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 32);
            this.button2.TabIndex = 1008;
            this.button2.Text = "^";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnLogic
            // 
            this.btnLogic.Image = ((System.Drawing.Image)(resources.GetObject("btnLogic.Image")));
            this.btnLogic.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogic.Location = new System.Drawing.Point(277, 792);
            this.btnLogic.Name = "btnLogic";
            this.btnLogic.Size = new System.Drawing.Size(238, 28);
            this.btnLogic.TabIndex = 1007;
            this.btnLogic.Text = "sChoose Models for This Option Kit";
            this.btnLogic.UseVisualStyleBackColor = true;
            this.btnLogic.Click += new System.EventHandler(this.btnLogic_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(457, 762);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown1.TabIndex = 1006;
            // 
            // sMinimumAccessLevel
            // 
            this.sMinimumAccessLevel.AutoSize = true;
            this.sMinimumAccessLevel.Location = new System.Drawing.Point(287, 765);
            this.sMinimumAccessLevel.Name = "sMinimumAccessLevel";
            this.sMinimumAccessLevel.Size = new System.Drawing.Size(120, 13);
            this.sMinimumAccessLevel.TabIndex = 1005;
            this.sMinimumAccessLevel.Text = "sMinimum Access Level";
            // 
            // rdioUpdated
            // 
            this.rdioUpdated.AutoSize = true;
            this.rdioUpdated.Location = new System.Drawing.Point(277, 701);
            this.rdioUpdated.Name = "rdioUpdated";
            this.rdioUpdated.Size = new System.Drawing.Size(140, 17);
            this.rdioUpdated.TabIndex = 24;
            this.rdioUpdated.TabStop = true;
            this.rdioUpdated.Text = "sCurrent Database Price";
            this.rdioUpdated.UseVisualStyleBackColor = true;
            this.rdioUpdated.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 796);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 1002;
            this.label3.Text = "$";
            // 
            // rdioCurrent
            // 
            this.rdioCurrent.AutoSize = true;
            this.rdioCurrent.Location = new System.Drawing.Point(277, 678);
            this.rdioCurrent.Name = "rdioCurrent";
            this.rdioCurrent.Size = new System.Drawing.Size(88, 17);
            this.rdioCurrent.TabIndex = 23;
            this.rdioCurrent.TabStop = true;
            this.rdioCurrent.Text = "sSaved Price";
            this.rdioCurrent.UseVisualStyleBackColor = true;
            this.rdioCurrent.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // txtListPrice
            // 
            this.txtListPrice.Enabled = false;
            this.txtListPrice.Location = new System.Drawing.Point(194, 789);
            this.txtListPrice.Name = "txtListPrice";
            this.txtListPrice.Size = new System.Drawing.Size(58, 20);
            this.txtListPrice.TabIndex = 1001;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 792);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 1003;
            this.label4.Text = "TOTAL CURRENT COST";
            // 
            // cmdChoose
            // 
            this.cmdChoose.Image = ((System.Drawing.Image)(resources.GetObject("cmdChoose.Image")));
            this.cmdChoose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdChoose.Location = new System.Drawing.Point(277, 792);
            this.cmdChoose.Name = "cmdChoose";
            this.cmdChoose.Size = new System.Drawing.Size(238, 28);
            this.cmdChoose.TabIndex = 17;
            this.cmdChoose.Text = "sChoose Models for This Option Kit";
            this.cmdChoose.UseVisualStyleBackColor = true;
            this.cmdChoose.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtBoxFactor
            // 
            this.txtBoxFactor.Location = new System.Drawing.Point(457, 735);
            this.txtBoxFactor.Name = "txtBoxFactor";
            this.txtBoxFactor.Size = new System.Drawing.Size(58, 20);
            this.txtBoxFactor.TabIndex = 14;
            this.txtBoxFactor.TextChanged += new System.EventHandler(this.txtBoxFactor_TextChanged);
            // 
            // lblFactor
            // 
            this.lblFactor.AutoSize = true;
            this.lblFactor.Location = new System.Drawing.Point(392, 742);
            this.lblFactor.Name = "lblFactor";
            this.lblFactor.Size = new System.Drawing.Size(42, 13);
            this.lblFactor.TabIndex = 1000;
            this.lblFactor.Text = "sFactor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 772);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "$";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 749);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "$";
            // 
            // lblModified
            // 
            this.lblModified.AutoSize = true;
            this.lblModified.Location = new System.Drawing.Point(346, 43);
            this.lblModified.Name = "lblModified";
            this.lblModified.Size = new System.Drawing.Size(66, 13);
            this.lblModified.TabIndex = 23;
            this.lblModified.Text = "sModified by";
            // 
            // txtModified
            // 
            this.txtModified.Location = new System.Drawing.Point(457, 40);
            this.txtModified.Name = "txtModified";
            this.txtModified.Size = new System.Drawing.Size(62, 20);
            this.txtModified.TabIndex = 3;
            // 
            // lblLoaded
            // 
            this.lblLoaded.AutoSize = true;
            this.lblLoaded.Location = new System.Drawing.Point(7, 43);
            this.lblLoaded.Name = "lblLoaded";
            this.lblLoaded.Size = new System.Drawing.Size(63, 13);
            this.lblLoaded.TabIndex = 21;
            this.lblLoaded.Text = "sLoaded Kit";
            // 
            // txtLoaded
            // 
            this.txtLoaded.Location = new System.Drawing.Point(116, 40);
            this.txtLoaded.Name = "txtLoaded";
            this.txtLoaded.Size = new System.Drawing.Size(213, 20);
            this.txtLoaded.TabIndex = 2;
            // 
            // cmd_remove
            // 
            this.cmd_remove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmd_remove.Location = new System.Drawing.Point(7, 672);
            this.cmd_remove.Name = "cmd_remove";
            this.cmd_remove.Size = new System.Drawing.Size(245, 28);
            this.cmd_remove.TabIndex = 11;
            this.cmd_remove.Text = "sRemove Item From Kit";
            this.cmd_remove.UseVisualStyleBackColor = true;
            this.cmd_remove.Click += new System.EventHandler(this.cmd_remove_Click);
            // 
            // lblKitType
            // 
            this.lblKitType.AutoSize = true;
            this.lblKitType.Location = new System.Drawing.Point(4, 709);
            this.lblKitType.Name = "lblKitType";
            this.lblKitType.Size = new System.Drawing.Size(31, 13);
            this.lblKitType.TabIndex = 999;
            this.lblKitType.Text = "Type";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(88, 709);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(164, 21);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtCostUpdated
            // 
            this.txtCostUpdated.Enabled = false;
            this.txtCostUpdated.Location = new System.Drawing.Point(194, 765);
            this.txtCostUpdated.Name = "txtCostUpdated";
            this.txtCostUpdated.Size = new System.Drawing.Size(58, 20);
            this.txtCostUpdated.TabIndex = 16;
            this.txtCostUpdated.TextChanged += new System.EventHandler(this.txtCostUpdated_TextChanged);
            // 
            // txtCostNotUpdated
            // 
            this.txtCostNotUpdated.Enabled = false;
            this.txtCostNotUpdated.Location = new System.Drawing.Point(194, 742);
            this.txtCostNotUpdated.Name = "txtCostNotUpdated";
            this.txtCostNotUpdated.Size = new System.Drawing.Size(58, 20);
            this.txtCostNotUpdated.TabIndex = 15;
            this.txtCostNotUpdated.TextChanged += new System.EventHandler(this.txtCostNotUpdated_TextChanged);
            // 
            // lblTotalCostUpdated
            // 
            this.lblTotalCostUpdated.AutoSize = true;
            this.lblTotalCostUpdated.Location = new System.Drawing.Point(4, 770);
            this.lblTotalCostUpdated.Name = "lblTotalCostUpdated";
            this.lblTotalCostUpdated.Size = new System.Drawing.Size(129, 13);
            this.lblTotalCostUpdated.TabIndex = 999;
            this.lblTotalCostUpdated.Text = "TOTAL UPDATED COST";
            // 
            // lblTotalCostNotUpdated
            // 
            this.lblTotalCostNotUpdated.AutoSize = true;
            this.lblTotalCostNotUpdated.Location = new System.Drawing.Point(4, 745);
            this.lblTotalCostNotUpdated.Name = "lblTotalCostNotUpdated";
            this.lblTotalCostNotUpdated.Size = new System.Drawing.Size(130, 13);
            this.lblTotalCostNotUpdated.TabIndex = 999;
            this.lblTotalCostNotUpdated.Text = "TOTAL CURRENT COST";
            // 
            // cmdUpdatePrice
            // 
            this.cmdUpdatePrice.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpdatePrice.Image")));
            this.cmdUpdatePrice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdUpdatePrice.Location = new System.Drawing.Point(6, 105);
            this.cmdUpdatePrice.Name = "cmdUpdatePrice";
            this.cmdUpdatePrice.Size = new System.Drawing.Size(208, 24);
            this.cmdUpdatePrice.TabIndex = 7;
            this.cmdUpdatePrice.Text = "sUpdate Price";
            this.cmdUpdatePrice.UseVisualStyleBackColor = true;
            this.cmdUpdatePrice.Click += new System.EventHandler(this.cmdUpdatePrice_Click);
            // 
            // kitsComboBox
            // 
            this.kitsComboBox.FormattingEnabled = true;
            this.kitsComboBox.Items.AddRange(new object[] {
            "(New)"});
            this.kitsComboBox.Location = new System.Drawing.Point(7, 16);
            this.kitsComboBox.Name = "kitsComboBox";
            this.kitsComboBox.Size = new System.Drawing.Size(512, 21);
            this.kitsComboBox.TabIndex = 1;
            this.kitsComboBox.SelectedIndexChanged += new System.EventHandler(this.kitsComboBox_SelectedIndexChanged);
            // 
            // cmdDeleteKit
            // 
            this.cmdDeleteKit.Image = ((System.Drawing.Image)(resources.GetObject("cmdDeleteKit.Image")));
            this.cmdDeleteKit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDeleteKit.Location = new System.Drawing.Point(231, 106);
            this.cmdDeleteKit.Name = "cmdDeleteKit";
            this.cmdDeleteKit.Size = new System.Drawing.Size(192, 24);
            this.cmdDeleteKit.TabIndex = 8;
            this.cmdDeleteKit.Text = "sDelete Kit";
            this.cmdDeleteKit.UseVisualStyleBackColor = true;
            this.cmdDeleteKit.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdSaveKit
            // 
            this.cmdSaveKit.Image = ((System.Drawing.Image)(resources.GetObject("cmdSaveKit.Image")));
            this.cmdSaveKit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSaveKit.Location = new System.Drawing.Point(231, 74);
            this.cmdSaveKit.Name = "cmdSaveKit";
            this.cmdSaveKit.Size = new System.Drawing.Size(192, 24);
            this.cmdSaveKit.TabIndex = 5;
            this.cmdSaveKit.Text = "sSave Kit";
            this.cmdSaveKit.UseVisualStyleBackColor = true;
            this.cmdSaveKit.Click += new System.EventHandler(this.cmdSaveKit_Click);
            // 
            // grpOpenedKit
            // 
            this.grpOpenedKit.Controls.Add(this.dgKits);
            this.grpOpenedKit.Location = new System.Drawing.Point(42, 133);
            this.grpOpenedKit.Name = "grpOpenedKit";
            this.grpOpenedKit.Size = new System.Drawing.Size(480, 533);
            this.grpOpenedKit.TabIndex = 999;
            this.grpOpenedKit.TabStop = false;
            this.grpOpenedKit.Text = "sOpened Kit";
            // 
            // dgKits
            // 
            this.dgKits.AllowUserToAddRows = false;
            this.dgKits.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgKits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgKits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column2,
            this.Column6});
            this.dgKits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgKits.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgKits.Location = new System.Drawing.Point(3, 16);
            this.dgKits.MultiSelect = false;
            this.dgKits.Name = "dgKits";
            this.dgKits.ReadOnly = true;
            this.dgKits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgKits.Size = new System.Drawing.Size(474, 514);
            this.dgKits.TabIndex = 10;
            this.dgKits.TabStop = false;
            this.dgKits.DoubleClick += new System.EventHandler(this.dgKits_DoubleClick);
            this.dgKits.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgKits_KeyDown);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "PartNumber";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 60;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Description";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 235;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "EA";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 23;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Unit Price";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 38;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Amount";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 25;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Total Price";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 50;
            // 
            // cmdAddKit
            // 
            this.cmdAddKit.Image = ((System.Drawing.Image)(resources.GetObject("cmdAddKit.Image")));
            this.cmdAddKit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAddKit.Location = new System.Drawing.Point(883, 774);
            this.cmdAddKit.Name = "cmdAddKit";
            this.cmdAddKit.Size = new System.Drawing.Size(154, 28);
            this.cmdAddKit.TabIndex = 24;
            this.cmdAddKit.Text = "sAdd Item To Kit";
            this.cmdAddKit.UseVisualStyleBackColor = true;
            this.cmdAddKit.Click += new System.EventHandler(this.cmdAddKit_Click);
            // 
            // PieceSearch
            // 
            this.PieceSearch.Controls.Add(this.sInitialize);
            this.PieceSearch.Controls.Add(this.SearchTextBox);
            this.PieceSearch.Controls.Add(this.cmdSearchPieces);
            this.PieceSearch.Controls.Add(this.DescriptionRadio);
            this.PieceSearch.Controls.Add(this.PartRadio);
            this.PieceSearch.Location = new System.Drawing.Point(539, 13);
            this.PieceSearch.Name = "PieceSearch";
            this.PieceSearch.Size = new System.Drawing.Size(620, 80);
            this.PieceSearch.TabIndex = 999;
            this.PieceSearch.TabStop = false;
            this.PieceSearch.Text = "sSearch For Pieces";
            // 
            // sInitialize
            // 
            this.sInitialize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sInitialize.Location = new System.Drawing.Point(238, 50);
            this.sInitialize.Name = "sInitialize";
            this.sInitialize.Size = new System.Drawing.Size(218, 24);
            this.sInitialize.TabIndex = 21;
            this.sInitialize.Text = "sInitialize";
            this.sInitialize.UseVisualStyleBackColor = true;
            this.sInitialize.Click += new System.EventHandler(this.button1_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(112, 24);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(501, 20);
            this.SearchTextBox.TabIndex = 20;
            this.SearchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchTextBox_KeyDown);
            // 
            // cmdSearchPieces
            // 
            this.cmdSearchPieces.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearchPieces.Image")));
            this.cmdSearchPieces.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSearchPieces.Location = new System.Drawing.Point(462, 50);
            this.cmdSearchPieces.Name = "cmdSearchPieces";
            this.cmdSearchPieces.Size = new System.Drawing.Size(151, 24);
            this.cmdSearchPieces.TabIndex = 22;
            this.cmdSearchPieces.Text = "sSearch";
            this.cmdSearchPieces.UseVisualStyleBackColor = true;
            this.cmdSearchPieces.Click += new System.EventHandler(this.cmdSearchPieces_Click);
            // 
            // DescriptionRadio
            // 
            this.DescriptionRadio.AutoSize = true;
            this.DescriptionRadio.Location = new System.Drawing.Point(7, 43);
            this.DescriptionRadio.Name = "DescriptionRadio";
            this.DescriptionRadio.Size = new System.Drawing.Size(86, 17);
            this.DescriptionRadio.TabIndex = 19;
            this.DescriptionRadio.TabStop = true;
            this.DescriptionRadio.Text = "sDescription:";
            this.DescriptionRadio.UseVisualStyleBackColor = true;
            // 
            // PartRadio
            // 
            this.PartRadio.AutoSize = true;
            this.PartRadio.Location = new System.Drawing.Point(7, 20);
            this.PartRadio.Name = "PartRadio";
            this.PartRadio.Size = new System.Drawing.Size(62, 17);
            this.PartRadio.TabIndex = 18;
            this.PartRadio.TabStop = true;
            this.PartRadio.Text = "sPart #:";
            this.PartRadio.UseVisualStyleBackColor = true;
            // 
            // sDateUpdated
            // 
            this.sDateUpdated.AutoSize = true;
            this.sDateUpdated.Location = new System.Drawing.Point(578, 782);
            this.sDateUpdated.Name = "sDateUpdated";
            this.sDateUpdated.Size = new System.Drawing.Size(102, 13);
            this.sDateUpdated.TabIndex = 1000;
            this.sDateUpdated.Text = "sLast Date Updated";
            // 
            // txt_date
            // 
            this.txt_date.Enabled = false;
            this.txt_date.Location = new System.Drawing.Point(725, 778);
            this.txt_date.Name = "txt_date";
            this.txt_date.Size = new System.Drawing.Size(129, 20);
            this.txt_date.TabIndex = 1001;
            // 
            // btnSytelineOpen
            // 
            this.btnSytelineOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSytelineOpen.Location = new System.Drawing.Point(544, 815);
            this.btnSytelineOpen.Name = "btnSytelineOpen";
            this.btnSytelineOpen.Size = new System.Drawing.Size(279, 28);
            this.btnSytelineOpen.TabIndex = 1002;
            this.btnSytelineOpen.Text = "sAdd Item To Kit";
            this.btnSytelineOpen.UseVisualStyleBackColor = true;
            this.btnSytelineOpen.Click += new System.EventHandler(this.btnSytelineOpen_Click);
            // 
            // btnManualListOpen
            // 
            this.btnManualListOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManualListOpen.Location = new System.Drawing.Point(829, 815);
            this.btnManualListOpen.Name = "btnManualListOpen";
            this.btnManualListOpen.Size = new System.Drawing.Size(332, 28);
            this.btnManualListOpen.TabIndex = 1003;
            this.btnManualListOpen.Text = "sAdd Item To Kit";
            this.btnManualListOpen.UseVisualStyleBackColor = true;
            this.btnManualListOpen.Click += new System.EventHandler(this.btnManualListOpen_Click);
            // 
            // FrmOptionPack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1173, 855);
            this.Controls.Add(this.btnManualListOpen);
            this.Controls.Add(this.btnSytelineOpen);
            this.Controls.Add(this.txt_date);
            this.Controls.Add(this.sDateUpdated);
            this.Controls.Add(this.cmdAddKit);
            this.Controls.Add(this.PieceSearch);
            this.Controls.Add(this.KitManagement);
            this.Controls.Add(this.PieceTableView);
            this.Controls.Add(this.cmdClose);
            this.Name = "FrmOptionPack";
            this.Text = "sKit Management";
            this.Load += new System.EventHandler(this.frmOptionPack_Load);
            this.PieceTableView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPieces)).EndInit();
            this.KitManagement.ResumeLayout(false);
            this.KitManagement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.grpOpenedKit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgKits)).EndInit();
            this.PieceSearch.ResumeLayout(false);
            this.PieceSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox PieceTableView;
        private System.Windows.Forms.DataGridView dgPieces;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.GroupBox KitManagement;
        private System.Windows.Forms.GroupBox PieceSearch;
        private System.Windows.Forms.GroupBox grpOpenedKit;
        private System.Windows.Forms.RadioButton DescriptionRadio;
        private System.Windows.Forms.RadioButton PartRadio;
        private System.Windows.Forms.Button cmdSaveKit;
        private System.Windows.Forms.Button cmdDeleteKit;
        private System.Windows.Forms.ComboBox kitsComboBox;
        private System.Windows.Forms.DataGridView dgKits;
        private System.Windows.Forms.Button cmdSearchPieces;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button cmdUpdatePrice;
        private System.Windows.Forms.Label lblTotalCostNotUpdated;
        private System.Windows.Forms.TextBox txtCostUpdated;
        private System.Windows.Forms.TextBox txtCostNotUpdated;
        private System.Windows.Forms.Label lblTotalCostUpdated;
        private System.Windows.Forms.Button cmdAddKit;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblKitType;
        private System.Windows.Forms.Button cmd_remove;
        private System.Windows.Forms.Label lblLoaded;
        private System.Windows.Forms.TextBox txtLoaded;
        private System.Windows.Forms.Label lblModified;
        private System.Windows.Forms.TextBox txtModified;
        private System.Windows.Forms.Button sInitialize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdChoose;
        private System.Windows.Forms.TextBox txtBoxFactor;
        private System.Windows.Forms.Label lblFactor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtListPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdioUpdated;
        private System.Windows.Forms.RadioButton rdioCurrent;
        private System.Windows.Forms.Label sMinimumAccessLevel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label sDateUpdated;
        private System.Windows.Forms.TextBox txt_date;
        private System.Windows.Forms.Button btnSytelineOpen;
        private System.Windows.Forms.Button btnManualListOpen;
        private System.Windows.Forms.Button btnLogic;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Each;
    }
}