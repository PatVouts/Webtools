namespace RefplusWebtools.DataManager.Evaporator
{
    partial class FrmEvaporatorModel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEvaporatorModel));
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn2 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn3 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn4 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn5 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn6 = new GlacialComponents.Controls.GLColumn();
            GlacialComponents.Controls.GLColumn glColumn7 = new GlacialComponents.Controls.GLColumn();
            this.cboEvapModel = new System.Windows.Forms.ComboBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.cmdLoadModel = new System.Windows.Forms.Button();
            this.cmdDeleteModel = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.tabEvaporator = new System.Windows.Forms.TabControl();
            this.tabInformation = new System.Windows.Forms.TabPage();
            this.chkWaterCoilSelection = new System.Windows.Forms.CheckBox();
            this.lblCapacityAt10TD = new System.Windows.Forms.Label();
            this.numCapacityAt10TD = new System.Windows.Forms.NumericUpDown();
            this.lblModelText = new System.Windows.Forms.Label();
            this.txtModelText = new System.Windows.Forms.TextBox();
            this.cboEvapType = new System.Windows.Forms.ComboBox();
            this.lblEvapType = new System.Windows.Forms.Label();
            this.lblFinishTemp = new System.Windows.Forms.Label();
            this.numFinishTemp = new System.Windows.Forms.NumericUpDown();
            this.lblStartTemp = new System.Windows.Forms.Label();
            this.numStartTemp = new System.Windows.Forms.NumericUpDown();
            this.cboFanArrangement = new System.Windows.Forms.ComboBox();
            this.lblFanArrangement = new System.Windows.Forms.Label();
            this.lblConnQty = new System.Windows.Forms.Label();
            this.numConnQty = new System.Windows.Forms.NumericUpDown();
            this.lblSuction = new System.Windows.Forms.Label();
            this.numSuction = new System.Windows.Forms.NumericUpDown();
            this.lblLiquid = new System.Windows.Forms.Label();
            this.numLiquid = new System.Windows.Forms.NumericUpDown();
            this.lblHotGas = new System.Windows.Forms.Label();
            this.numHotGas = new System.Windows.Forms.NumericUpDown();
            this.chkLowVelocity = new System.Windows.Forms.CheckBox();
            this.lblBlygoldPrice = new System.Windows.Forms.Label();
            this.numBlygoldPrice = new System.Windows.Forms.NumericUpDown();
            this.lblRefCharge = new System.Windows.Forms.Label();
            this.numRefCharge = new System.Windows.Forms.NumericUpDown();
            this.lblHeaterQty = new System.Windows.Forms.Label();
            this.numHeaterQty = new System.Windows.Forms.NumericUpDown();
            this.lblFanQty = new System.Windows.Forms.Label();
            this.numFanQty = new System.Windows.Forms.NumericUpDown();
            this.lblCoilQty = new System.Windows.Forms.Label();
            this.numCoilQty = new System.Windows.Forms.NumericUpDown();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.numCapacity = new System.Windows.Forms.NumericUpDown();
            this.lblWeight = new System.Windows.Forms.Label();
            this.numWeight = new System.Windows.Forms.NumericUpDown();
            this.cboEvapStyle = new System.Windows.Forms.ComboBox();
            this.lblEvapStyle = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.cboDefrostType = new System.Windows.Forms.ComboBox();
            this.lblDefrostType = new System.Windows.Forms.Label();
            this.tabCoilInfo = new System.Windows.Forms.TabPage();
            this.btnGenerateCoilModel = new System.Windows.Forms.Button();
            this.lblFinHeight = new System.Windows.Forms.Label();
            this.cboFinHeight = new System.Windows.Forms.ComboBox();
            this.cboFinShape = new System.Windows.Forms.ComboBox();
            this.lblFinShape = new System.Windows.Forms.Label();
            this.cboFinType = new System.Windows.Forms.ComboBox();
            this.lblFinType = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.numLength = new System.Windows.Forms.NumericUpDown();
            this.lblRows = new System.Windows.Forms.Label();
            this.numRows = new System.Windows.Forms.NumericUpDown();
            this.lblCFM = new System.Windows.Forms.Label();
            this.numCFM = new System.Windows.Forms.NumericUpDown();
            this.lblCoilModel = new System.Windows.Forms.Label();
            this.txtCoilModel = new System.Windows.Forms.TextBox();
            this.cboFPI = new System.Windows.Forms.ComboBox();
            this.lblFPI = new System.Windows.Forms.Label();
            this.tabParts = new System.Windows.Forms.TabPage();
            this.cboVoltage = new System.Windows.Forms.ComboBox();
            this.btnRemoveVoltage = new System.Windows.Forms.Button();
            this.btnAddVoltage = new System.Windows.Forms.Button();
            this.lvParts = new GlacialComponents.Controls.GlacialList();
            this.btnHelp = new System.Windows.Forms.Button();
            this.tabEvaporator.SuspendLayout();
            this.tabInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacityAt10TD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFinishTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numConnQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSuction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLiquid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHotGas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlygoldPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRefCharge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeaterQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFanQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoilQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            this.tabCoilInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCFM)).BeginInit();
            this.tabParts.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboEvapModel
            // 
            this.cboEvapModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEvapModel.FormattingEnabled = true;
            this.cboEvapModel.Location = new System.Drawing.Point(134, 12);
            this.cboEvapModel.Name = "cboEvapModel";
            this.cboEvapModel.Size = new System.Drawing.Size(154, 21);
            this.cboEvapModel.TabIndex = 0;
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(17, 15);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(96, 13);
            this.lblModel.TabIndex = 1;
            this.lblModel.Text = "sEvaporator Model";
            // 
            // cmdLoadModel
            // 
            this.cmdLoadModel.Image = ((System.Drawing.Image)(resources.GetObject("cmdLoadModel.Image")));
            this.cmdLoadModel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLoadModel.Location = new System.Drawing.Point(328, 12);
            this.cmdLoadModel.Name = "cmdLoadModel";
            this.cmdLoadModel.Size = new System.Drawing.Size(198, 23);
            this.cmdLoadModel.TabIndex = 1;
            this.cmdLoadModel.Text = "sLoad Selected Model";
            this.cmdLoadModel.UseVisualStyleBackColor = true;
            this.cmdLoadModel.Click += new System.EventHandler(this.cmdLoadModel_Click);
            // 
            // cmdDeleteModel
            // 
            this.cmdDeleteModel.Image = ((System.Drawing.Image)(resources.GetObject("cmdDeleteModel.Image")));
            this.cmdDeleteModel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDeleteModel.Location = new System.Drawing.Point(555, 12);
            this.cmdDeleteModel.Name = "cmdDeleteModel";
            this.cmdDeleteModel.Size = new System.Drawing.Size(198, 23);
            this.cmdDeleteModel.TabIndex = 2;
            this.cmdDeleteModel.Text = "sDelete Selected Model";
            this.cmdDeleteModel.UseVisualStyleBackColor = true;
            this.cmdDeleteModel.Click += new System.EventHandler(this.cmdDeleteModel_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(143, 539);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(117, 23);
            this.cmdSave.TabIndex = 5;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(512, 539);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(117, 23);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "sClose";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // tabEvaporator
            // 
            this.tabEvaporator.Controls.Add(this.tabInformation);
            this.tabEvaporator.Controls.Add(this.tabCoilInfo);
            this.tabEvaporator.Controls.Add(this.tabParts);
            this.tabEvaporator.Location = new System.Drawing.Point(12, 55);
            this.tabEvaporator.Name = "tabEvaporator";
            this.tabEvaporator.SelectedIndex = 0;
            this.tabEvaporator.Size = new System.Drawing.Size(757, 478);
            this.tabEvaporator.TabIndex = 4;
            // 
            // tabInformation
            // 
            this.tabInformation.Controls.Add(this.chkWaterCoilSelection);
            this.tabInformation.Controls.Add(this.lblCapacityAt10TD);
            this.tabInformation.Controls.Add(this.numCapacityAt10TD);
            this.tabInformation.Controls.Add(this.lblModelText);
            this.tabInformation.Controls.Add(this.txtModelText);
            this.tabInformation.Controls.Add(this.cboEvapType);
            this.tabInformation.Controls.Add(this.lblEvapType);
            this.tabInformation.Controls.Add(this.lblFinishTemp);
            this.tabInformation.Controls.Add(this.numFinishTemp);
            this.tabInformation.Controls.Add(this.lblStartTemp);
            this.tabInformation.Controls.Add(this.numStartTemp);
            this.tabInformation.Controls.Add(this.cboFanArrangement);
            this.tabInformation.Controls.Add(this.lblFanArrangement);
            this.tabInformation.Controls.Add(this.lblConnQty);
            this.tabInformation.Controls.Add(this.numConnQty);
            this.tabInformation.Controls.Add(this.lblSuction);
            this.tabInformation.Controls.Add(this.numSuction);
            this.tabInformation.Controls.Add(this.lblLiquid);
            this.tabInformation.Controls.Add(this.numLiquid);
            this.tabInformation.Controls.Add(this.lblHotGas);
            this.tabInformation.Controls.Add(this.numHotGas);
            this.tabInformation.Controls.Add(this.chkLowVelocity);
            this.tabInformation.Controls.Add(this.lblBlygoldPrice);
            this.tabInformation.Controls.Add(this.numBlygoldPrice);
            this.tabInformation.Controls.Add(this.lblRefCharge);
            this.tabInformation.Controls.Add(this.numRefCharge);
            this.tabInformation.Controls.Add(this.lblHeaterQty);
            this.tabInformation.Controls.Add(this.numHeaterQty);
            this.tabInformation.Controls.Add(this.lblFanQty);
            this.tabInformation.Controls.Add(this.numFanQty);
            this.tabInformation.Controls.Add(this.lblCoilQty);
            this.tabInformation.Controls.Add(this.numCoilQty);
            this.tabInformation.Controls.Add(this.lblCapacity);
            this.tabInformation.Controls.Add(this.numCapacity);
            this.tabInformation.Controls.Add(this.lblWeight);
            this.tabInformation.Controls.Add(this.numWeight);
            this.tabInformation.Controls.Add(this.cboEvapStyle);
            this.tabInformation.Controls.Add(this.lblEvapStyle);
            this.tabInformation.Controls.Add(this.lblPrice);
            this.tabInformation.Controls.Add(this.numPrice);
            this.tabInformation.Controls.Add(this.cboDefrostType);
            this.tabInformation.Controls.Add(this.lblDefrostType);
            this.tabInformation.Location = new System.Drawing.Point(4, 22);
            this.tabInformation.Name = "tabInformation";
            this.tabInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tabInformation.Size = new System.Drawing.Size(749, 452);
            this.tabInformation.TabIndex = 0;
            this.tabInformation.Text = "sInformation";
            this.tabInformation.UseVisualStyleBackColor = true;
            // 
            // chkWaterCoilSelection
            // 
            this.chkWaterCoilSelection.AutoSize = true;
            this.chkWaterCoilSelection.Location = new System.Drawing.Point(205, 343);
            this.chkWaterCoilSelection.Name = "chkWaterCoilSelection";
            this.chkWaterCoilSelection.Size = new System.Drawing.Size(127, 17);
            this.chkWaterCoilSelection.TabIndex = 94;
            this.chkWaterCoilSelection.Text = "sWater Coil Selection";
            this.chkWaterCoilSelection.UseVisualStyleBackColor = true;
            // 
            // lblCapacityAt10TD
            // 
            this.lblCapacityAt10TD.AutoSize = true;
            this.lblCapacityAt10TD.Location = new System.Drawing.Point(57, 209);
            this.lblCapacityAt10TD.Name = "lblCapacityAt10TD";
            this.lblCapacityAt10TD.Size = new System.Drawing.Size(97, 13);
            this.lblCapacityAt10TD.TabIndex = 93;
            this.lblCapacityAt10TD.Text = "sCapacity @ 10TD";
            // 
            // numCapacityAt10TD
            // 
            this.numCapacityAt10TD.Location = new System.Drawing.Point(205, 209);
            this.numCapacityAt10TD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numCapacityAt10TD.Name = "numCapacityAt10TD";
            this.numCapacityAt10TD.Size = new System.Drawing.Size(154, 20);
            this.numCapacityAt10TD.TabIndex = 5;
            this.numCapacityAt10TD.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblModelText
            // 
            this.lblModelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelText.Location = new System.Drawing.Point(130, 7);
            this.lblModelText.Name = "lblModelText";
            this.lblModelText.Size = new System.Drawing.Size(500, 38);
            this.lblModelText.TabIndex = 89;
            this.lblModelText.Text = "sModel Name";
            this.lblModelText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtModelText
            // 
            this.txtModelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelText.Location = new System.Drawing.Point(59, 48);
            this.txtModelText.Name = "txtModelText";
            this.txtModelText.Size = new System.Drawing.Size(632, 47);
            this.txtModelText.TabIndex = 0;
            this.txtModelText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtModelText.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // cboEvapType
            // 
            this.cboEvapType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEvapType.FormattingEnabled = true;
            this.cboEvapType.Location = new System.Drawing.Point(205, 155);
            this.cboEvapType.Name = "cboEvapType";
            this.cboEvapType.Size = new System.Drawing.Size(154, 21);
            this.cboEvapType.TabIndex = 3;
            // 
            // lblEvapType
            // 
            this.lblEvapType.AutoSize = true;
            this.lblEvapType.Location = new System.Drawing.Point(57, 156);
            this.lblEvapType.Name = "lblEvapType";
            this.lblEvapType.Size = new System.Drawing.Size(91, 13);
            this.lblEvapType.TabIndex = 86;
            this.lblEvapType.Text = "sEvaporator Type";
            // 
            // lblFinishTemp
            // 
            this.lblFinishTemp.AutoSize = true;
            this.lblFinishTemp.Location = new System.Drawing.Point(388, 236);
            this.lblFinishTemp.Name = "lblFinishTemp";
            this.lblFinishTemp.Size = new System.Drawing.Size(72, 13);
            this.lblFinishTemp.TabIndex = 85;
            this.lblFinishTemp.Text = "sFinish Temp.";
            // 
            // numFinishTemp
            // 
            this.numFinishTemp.Location = new System.Drawing.Point(537, 234);
            this.numFinishTemp.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.numFinishTemp.Name = "numFinishTemp";
            this.numFinishTemp.Size = new System.Drawing.Size(154, 20);
            this.numFinishTemp.TabIndex = 15;
            this.numFinishTemp.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblStartTemp
            // 
            this.lblStartTemp.AutoSize = true;
            this.lblStartTemp.Location = new System.Drawing.Point(388, 209);
            this.lblStartTemp.Name = "lblStartTemp";
            this.lblStartTemp.Size = new System.Drawing.Size(67, 13);
            this.lblStartTemp.TabIndex = 83;
            this.lblStartTemp.Text = "sStart Temp.";
            // 
            // numStartTemp
            // 
            this.numStartTemp.Location = new System.Drawing.Point(536, 208);
            this.numStartTemp.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.numStartTemp.Name = "numStartTemp";
            this.numStartTemp.Size = new System.Drawing.Size(154, 20);
            this.numStartTemp.TabIndex = 14;
            this.numStartTemp.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // cboFanArrangement
            // 
            this.cboFanArrangement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFanArrangement.FormattingEnabled = true;
            this.cboFanArrangement.Location = new System.Drawing.Point(205, 182);
            this.cboFanArrangement.Name = "cboFanArrangement";
            this.cboFanArrangement.Size = new System.Drawing.Size(154, 21);
            this.cboFanArrangement.TabIndex = 4;
            this.cboFanArrangement.SelectedIndexChanged += new System.EventHandler(this.cboFanArrangement_SelectedIndexChanged);
            // 
            // lblFanArrangement
            // 
            this.lblFanArrangement.AutoSize = true;
            this.lblFanArrangement.Location = new System.Drawing.Point(57, 183);
            this.lblFanArrangement.Name = "lblFanArrangement";
            this.lblFanArrangement.Size = new System.Drawing.Size(93, 13);
            this.lblFanArrangement.TabIndex = 80;
            this.lblFanArrangement.Text = "sFan Arrangement";
            // 
            // lblConnQty
            // 
            this.lblConnQty.AutoSize = true;
            this.lblConnQty.Location = new System.Drawing.Point(388, 154);
            this.lblConnQty.Name = "lblConnQty";
            this.lblConnQty.Size = new System.Drawing.Size(56, 13);
            this.lblConnQty.TabIndex = 79;
            this.lblConnQty.Text = "sConn Qty";
            // 
            // numConnQty
            // 
            this.numConnQty.Location = new System.Drawing.Point(536, 156);
            this.numConnQty.Name = "numConnQty";
            this.numConnQty.Size = new System.Drawing.Size(154, 20);
            this.numConnQty.TabIndex = 12;
            this.numConnQty.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblSuction
            // 
            this.lblSuction.AutoSize = true;
            this.lblSuction.Location = new System.Drawing.Point(57, 290);
            this.lblSuction.Name = "lblSuction";
            this.lblSuction.Size = new System.Drawing.Size(48, 13);
            this.lblSuction.TabIndex = 77;
            this.lblSuction.Text = "sSuction";
            // 
            // numSuction
            // 
            this.numSuction.DecimalPlaces = 3;
            this.numSuction.Location = new System.Drawing.Point(205, 287);
            this.numSuction.Minimum = new decimal(new int[] {
            99,
            0,
            0,
            -2147483648});
            this.numSuction.Name = "numSuction";
            this.numSuction.Size = new System.Drawing.Size(154, 20);
            this.numSuction.TabIndex = 8;
            this.numSuction.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblLiquid
            // 
            this.lblLiquid.AutoSize = true;
            this.lblLiquid.Location = new System.Drawing.Point(57, 264);
            this.lblLiquid.Name = "lblLiquid";
            this.lblLiquid.Size = new System.Drawing.Size(40, 13);
            this.lblLiquid.TabIndex = 75;
            this.lblLiquid.Text = "sLiquid";
            // 
            // numLiquid
            // 
            this.numLiquid.DecimalPlaces = 3;
            this.numLiquid.Location = new System.Drawing.Point(205, 261);
            this.numLiquid.Minimum = new decimal(new int[] {
            99,
            0,
            0,
            -2147483648});
            this.numLiquid.Name = "numLiquid";
            this.numLiquid.Size = new System.Drawing.Size(154, 20);
            this.numLiquid.TabIndex = 7;
            this.numLiquid.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblHotGas
            // 
            this.lblHotGas.AutoSize = true;
            this.lblHotGas.Location = new System.Drawing.Point(57, 315);
            this.lblHotGas.Name = "lblHotGas";
            this.lblHotGas.Size = new System.Drawing.Size(51, 13);
            this.lblHotGas.TabIndex = 73;
            this.lblHotGas.Text = "sHot Gas";
            // 
            // numHotGas
            // 
            this.numHotGas.DecimalPlaces = 3;
            this.numHotGas.Location = new System.Drawing.Point(205, 313);
            this.numHotGas.Minimum = new decimal(new int[] {
            99,
            0,
            0,
            -2147483648});
            this.numHotGas.Name = "numHotGas";
            this.numHotGas.Size = new System.Drawing.Size(154, 20);
            this.numHotGas.TabIndex = 9;
            this.numHotGas.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // chkLowVelocity
            // 
            this.chkLowVelocity.AutoSize = true;
            this.chkLowVelocity.Location = new System.Drawing.Point(537, 368);
            this.chkLowVelocity.Name = "chkLowVelocity";
            this.chkLowVelocity.Size = new System.Drawing.Size(91, 17);
            this.chkLowVelocity.TabIndex = 20;
            this.chkLowVelocity.Text = "sLow Velocity";
            this.chkLowVelocity.UseVisualStyleBackColor = true;
            // 
            // lblBlygoldPrice
            // 
            this.lblBlygoldPrice.AutoSize = true;
            this.lblBlygoldPrice.Location = new System.Drawing.Point(388, 315);
            this.lblBlygoldPrice.Name = "lblBlygoldPrice";
            this.lblBlygoldPrice.Size = new System.Drawing.Size(73, 13);
            this.lblBlygoldPrice.TabIndex = 70;
            this.lblBlygoldPrice.Text = "sBlygold Price";
            // 
            // numBlygoldPrice
            // 
            this.numBlygoldPrice.Location = new System.Drawing.Point(536, 312);
            this.numBlygoldPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numBlygoldPrice.Name = "numBlygoldPrice";
            this.numBlygoldPrice.Size = new System.Drawing.Size(154, 20);
            this.numBlygoldPrice.TabIndex = 18;
            this.numBlygoldPrice.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblRefCharge
            // 
            this.lblRefCharge.AutoSize = true;
            this.lblRefCharge.Location = new System.Drawing.Point(388, 262);
            this.lblRefCharge.Name = "lblRefCharge";
            this.lblRefCharge.Size = new System.Drawing.Size(66, 13);
            this.lblRefCharge.TabIndex = 68;
            this.lblRefCharge.Text = "sRef Charge";
            // 
            // numRefCharge
            // 
            this.numRefCharge.DecimalPlaces = 1;
            this.numRefCharge.Location = new System.Drawing.Point(536, 260);
            this.numRefCharge.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numRefCharge.Name = "numRefCharge";
            this.numRefCharge.Size = new System.Drawing.Size(154, 20);
            this.numRefCharge.TabIndex = 16;
            this.numRefCharge.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblHeaterQty
            // 
            this.lblHeaterQty.AutoSize = true;
            this.lblHeaterQty.Location = new System.Drawing.Point(388, 182);
            this.lblHeaterQty.Name = "lblHeaterQty";
            this.lblHeaterQty.Size = new System.Drawing.Size(63, 13);
            this.lblHeaterQty.TabIndex = 66;
            this.lblHeaterQty.Text = "sHeater Qty";
            // 
            // numHeaterQty
            // 
            this.numHeaterQty.Location = new System.Drawing.Point(536, 182);
            this.numHeaterQty.Name = "numHeaterQty";
            this.numHeaterQty.Size = new System.Drawing.Size(154, 20);
            this.numHeaterQty.TabIndex = 13;
            this.numHeaterQty.ValueChanged += new System.EventHandler(this.numHeaterQty_ValueChanged);
            this.numHeaterQty.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblFanQty
            // 
            this.lblFanQty.AutoSize = true;
            this.lblFanQty.Location = new System.Drawing.Point(389, 131);
            this.lblFanQty.Name = "lblFanQty";
            this.lblFanQty.Size = new System.Drawing.Size(49, 13);
            this.lblFanQty.TabIndex = 64;
            this.lblFanQty.Text = "sFan Qty";
            // 
            // numFanQty
            // 
            this.numFanQty.Enabled = false;
            this.numFanQty.Location = new System.Drawing.Point(537, 130);
            this.numFanQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFanQty.Name = "numFanQty";
            this.numFanQty.Size = new System.Drawing.Size(154, 20);
            this.numFanQty.TabIndex = 11;
            this.numFanQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFanQty.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblCoilQty
            // 
            this.lblCoilQty.AutoSize = true;
            this.lblCoilQty.Location = new System.Drawing.Point(389, 105);
            this.lblCoilQty.Name = "lblCoilQty";
            this.lblCoilQty.Size = new System.Drawing.Size(48, 13);
            this.lblCoilQty.TabIndex = 62;
            this.lblCoilQty.Text = "sCoil Qty";
            // 
            // numCoilQty
            // 
            this.numCoilQty.Location = new System.Drawing.Point(537, 104);
            this.numCoilQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCoilQty.Name = "numCoilQty";
            this.numCoilQty.Size = new System.Drawing.Size(154, 20);
            this.numCoilQty.TabIndex = 10;
            this.numCoilQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCoilQty.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Location = new System.Drawing.Point(57, 237);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(53, 13);
            this.lblCapacity.TabIndex = 60;
            this.lblCapacity.Text = "sCapacity";
            // 
            // numCapacity
            // 
            this.numCapacity.DecimalPlaces = 2;
            this.numCapacity.Location = new System.Drawing.Point(205, 235);
            this.numCapacity.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numCapacity.Name = "numCapacity";
            this.numCapacity.Size = new System.Drawing.Size(154, 20);
            this.numCapacity.TabIndex = 6;
            this.numCapacity.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(388, 343);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(46, 13);
            this.lblWeight.TabIndex = 58;
            this.lblWeight.Text = "sWeight";
            // 
            // numWeight
            // 
            this.numWeight.DecimalPlaces = 1;
            this.numWeight.Location = new System.Drawing.Point(536, 338);
            this.numWeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numWeight.Name = "numWeight";
            this.numWeight.Size = new System.Drawing.Size(154, 20);
            this.numWeight.TabIndex = 19;
            this.numWeight.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // cboEvapStyle
            // 
            this.cboEvapStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEvapStyle.DropDownWidth = 200;
            this.cboEvapStyle.FormattingEnabled = true;
            this.cboEvapStyle.Location = new System.Drawing.Point(205, 101);
            this.cboEvapStyle.Name = "cboEvapStyle";
            this.cboEvapStyle.Size = new System.Drawing.Size(154, 21);
            this.cboEvapStyle.TabIndex = 1;
            // 
            // lblEvapStyle
            // 
            this.lblEvapStyle.AutoSize = true;
            this.lblEvapStyle.Location = new System.Drawing.Point(57, 104);
            this.lblEvapStyle.Name = "lblEvapStyle";
            this.lblEvapStyle.Size = new System.Drawing.Size(90, 13);
            this.lblEvapStyle.TabIndex = 53;
            this.lblEvapStyle.Text = "sEvaporator Style";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(388, 289);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(36, 13);
            this.lblPrice.TabIndex = 42;
            this.lblPrice.Text = "sPrice";
            // 
            // numPrice
            // 
            this.numPrice.Location = new System.Drawing.Point(536, 286);
            this.numPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(154, 20);
            this.numPrice.TabIndex = 17;
            this.numPrice.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // cboDefrostType
            // 
            this.cboDefrostType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDefrostType.DropDownWidth = 400;
            this.cboDefrostType.FormattingEnabled = true;
            this.cboDefrostType.Location = new System.Drawing.Point(205, 128);
            this.cboDefrostType.Name = "cboDefrostType";
            this.cboDefrostType.Size = new System.Drawing.Size(154, 21);
            this.cboDefrostType.TabIndex = 2;
            // 
            // lblDefrostType
            // 
            this.lblDefrostType.AutoSize = true;
            this.lblDefrostType.Location = new System.Drawing.Point(57, 128);
            this.lblDefrostType.Name = "lblDefrostType";
            this.lblDefrostType.Size = new System.Drawing.Size(73, 13);
            this.lblDefrostType.TabIndex = 35;
            this.lblDefrostType.Text = "sDefrost Type";
            // 
            // tabCoilInfo
            // 
            this.tabCoilInfo.Controls.Add(this.btnGenerateCoilModel);
            this.tabCoilInfo.Controls.Add(this.lblFinHeight);
            this.tabCoilInfo.Controls.Add(this.cboFinHeight);
            this.tabCoilInfo.Controls.Add(this.cboFinShape);
            this.tabCoilInfo.Controls.Add(this.lblFinShape);
            this.tabCoilInfo.Controls.Add(this.cboFinType);
            this.tabCoilInfo.Controls.Add(this.lblFinType);
            this.tabCoilInfo.Controls.Add(this.lblLength);
            this.tabCoilInfo.Controls.Add(this.numLength);
            this.tabCoilInfo.Controls.Add(this.lblRows);
            this.tabCoilInfo.Controls.Add(this.numRows);
            this.tabCoilInfo.Controls.Add(this.lblCFM);
            this.tabCoilInfo.Controls.Add(this.numCFM);
            this.tabCoilInfo.Controls.Add(this.lblCoilModel);
            this.tabCoilInfo.Controls.Add(this.txtCoilModel);
            this.tabCoilInfo.Controls.Add(this.cboFPI);
            this.tabCoilInfo.Controls.Add(this.lblFPI);
            this.tabCoilInfo.Location = new System.Drawing.Point(4, 22);
            this.tabCoilInfo.Name = "tabCoilInfo";
            this.tabCoilInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoilInfo.Size = new System.Drawing.Size(749, 452);
            this.tabCoilInfo.TabIndex = 1;
            this.tabCoilInfo.Text = "sCoil, Fan Info";
            this.tabCoilInfo.UseVisualStyleBackColor = true;
            // 
            // btnGenerateCoilModel
            // 
            this.btnGenerateCoilModel.Location = new System.Drawing.Point(508, 142);
            this.btnGenerateCoilModel.Name = "btnGenerateCoilModel";
            this.btnGenerateCoilModel.Size = new System.Drawing.Size(137, 23);
            this.btnGenerateCoilModel.TabIndex = 8;
            this.btnGenerateCoilModel.Text = "sGenerate Model";
            this.btnGenerateCoilModel.UseVisualStyleBackColor = true;
            this.btnGenerateCoilModel.Click += new System.EventHandler(this.btnGenerateCoilModel_Click);
            // 
            // lblFinHeight
            // 
            this.lblFinHeight.AutoSize = true;
            this.lblFinHeight.Location = new System.Drawing.Point(44, 142);
            this.lblFinHeight.Name = "lblFinHeight";
            this.lblFinHeight.Size = new System.Drawing.Size(60, 13);
            this.lblFinHeight.TabIndex = 84;
            this.lblFinHeight.Text = "sFin Height";
            // 
            // cboFinHeight
            // 
            this.cboFinHeight.FormattingEnabled = true;
            this.cboFinHeight.Location = new System.Drawing.Point(153, 139);
            this.cboFinHeight.Name = "cboFinHeight";
            this.cboFinHeight.Size = new System.Drawing.Size(158, 21);
            this.cboFinHeight.TabIndex = 3;
            // 
            // cboFinShape
            // 
            this.cboFinShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFinShape.FormattingEnabled = true;
            this.cboFinShape.Location = new System.Drawing.Point(153, 112);
            this.cboFinShape.Name = "cboFinShape";
            this.cboFinShape.Size = new System.Drawing.Size(158, 21);
            this.cboFinShape.TabIndex = 2;
            this.cboFinShape.SelectedIndexChanged += new System.EventHandler(this.cboFinShape_SelectedIndexChanged);
            // 
            // lblFinShape
            // 
            this.lblFinShape.AutoSize = true;
            this.lblFinShape.Location = new System.Drawing.Point(44, 115);
            this.lblFinShape.Name = "lblFinShape";
            this.lblFinShape.Size = new System.Drawing.Size(60, 13);
            this.lblFinShape.TabIndex = 81;
            this.lblFinShape.Text = "sFin Shape";
            // 
            // cboFinType
            // 
            this.cboFinType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFinType.FormattingEnabled = true;
            this.cboFinType.Location = new System.Drawing.Point(153, 85);
            this.cboFinType.Name = "cboFinType";
            this.cboFinType.Size = new System.Drawing.Size(158, 21);
            this.cboFinType.TabIndex = 1;
            this.cboFinType.SelectedIndexChanged += new System.EventHandler(this.cboFinType_SelectedIndexChanged);
            // 
            // lblFinType
            // 
            this.lblFinType.AutoSize = true;
            this.lblFinType.Location = new System.Drawing.Point(44, 88);
            this.lblFinType.Name = "lblFinType";
            this.lblFinType.Size = new System.Drawing.Size(53, 13);
            this.lblFinType.TabIndex = 79;
            this.lblFinType.Text = "sFin Type";
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(44, 168);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(45, 13);
            this.lblLength.TabIndex = 78;
            this.lblLength.Text = "sLength";
            // 
            // numLength
            // 
            this.numLength.DecimalPlaces = 2;
            this.numLength.Location = new System.Drawing.Point(153, 166);
            this.numLength.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numLength.Name = "numLength";
            this.numLength.Size = new System.Drawing.Size(158, 20);
            this.numLength.TabIndex = 4;
            this.numLength.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Location = new System.Drawing.Point(401, 61);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(39, 13);
            this.lblRows.TabIndex = 74;
            this.lblRows.Text = "sRows";
            // 
            // numRows
            // 
            this.numRows.Location = new System.Drawing.Point(497, 59);
            this.numRows.Name = "numRows";
            this.numRows.Size = new System.Drawing.Size(158, 20);
            this.numRows.TabIndex = 5;
            this.numRows.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblCFM
            // 
            this.lblCFM.AutoSize = true;
            this.lblCFM.Location = new System.Drawing.Point(44, 61);
            this.lblCFM.Name = "lblCFM";
            this.lblCFM.Size = new System.Drawing.Size(34, 13);
            this.lblCFM.TabIndex = 72;
            this.lblCFM.Text = "sCFM";
            // 
            // numCFM
            // 
            this.numCFM.DecimalPlaces = 2;
            this.numCFM.Location = new System.Drawing.Point(153, 59);
            this.numCFM.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numCFM.Name = "numCFM";
            this.numCFM.Size = new System.Drawing.Size(158, 20);
            this.numCFM.TabIndex = 0;
            this.numCFM.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // lblCoilModel
            // 
            this.lblCoilModel.AutoSize = true;
            this.lblCoilModel.Location = new System.Drawing.Point(401, 115);
            this.lblCoilModel.Name = "lblCoilModel";
            this.lblCoilModel.Size = new System.Drawing.Size(61, 13);
            this.lblCoilModel.TabIndex = 70;
            this.lblCoilModel.Text = "sCoil Model";
            // 
            // txtCoilModel
            // 
            this.txtCoilModel.Enabled = false;
            this.txtCoilModel.Location = new System.Drawing.Point(497, 115);
            this.txtCoilModel.Name = "txtCoilModel";
            this.txtCoilModel.Size = new System.Drawing.Size(158, 20);
            this.txtCoilModel.TabIndex = 7;
            this.txtCoilModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCoilModel.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // cboFPI
            // 
            this.cboFPI.FormattingEnabled = true;
            this.cboFPI.Location = new System.Drawing.Point(497, 88);
            this.cboFPI.Name = "cboFPI";
            this.cboFPI.Size = new System.Drawing.Size(158, 21);
            this.cboFPI.TabIndex = 6;
            // 
            // lblFPI
            // 
            this.lblFPI.AutoSize = true;
            this.lblFPI.Location = new System.Drawing.Point(401, 91);
            this.lblFPI.Name = "lblFPI";
            this.lblFPI.Size = new System.Drawing.Size(28, 13);
            this.lblFPI.TabIndex = 67;
            this.lblFPI.Text = "sFPI";
            // 
            // tabParts
            // 
            this.tabParts.Controls.Add(this.cboVoltage);
            this.tabParts.Controls.Add(this.btnRemoveVoltage);
            this.tabParts.Controls.Add(this.btnAddVoltage);
            this.tabParts.Controls.Add(this.lvParts);
            this.tabParts.Location = new System.Drawing.Point(4, 22);
            this.tabParts.Name = "tabParts";
            this.tabParts.Padding = new System.Windows.Forms.Padding(3);
            this.tabParts.Size = new System.Drawing.Size(749, 452);
            this.tabParts.TabIndex = 2;
            this.tabParts.Text = "sParts";
            this.tabParts.UseVisualStyleBackColor = true;
            // 
            // cboVoltage
            // 
            this.cboVoltage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVoltage.FormattingEnabled = true;
            this.cboVoltage.Location = new System.Drawing.Point(40, 419);
            this.cboVoltage.Name = "cboVoltage";
            this.cboVoltage.Size = new System.Drawing.Size(154, 21);
            this.cboVoltage.TabIndex = 1;
            this.cboVoltage.SelectedIndexChanged += new System.EventHandler(this.cboVoltage_SelectedIndexChanged);
            // 
            // btnRemoveVoltage
            // 
            this.btnRemoveVoltage.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveVoltage.Image")));
            this.btnRemoveVoltage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveVoltage.Location = new System.Drawing.Point(539, 417);
            this.btnRemoveVoltage.Name = "btnRemoveVoltage";
            this.btnRemoveVoltage.Size = new System.Drawing.Size(137, 23);
            this.btnRemoveVoltage.TabIndex = 3;
            this.btnRemoveVoltage.Text = "sRemove Voltage";
            this.btnRemoveVoltage.UseVisualStyleBackColor = true;
            this.btnRemoveVoltage.Click += new System.EventHandler(this.btnRemoveVoltage_Click);
            // 
            // btnAddVoltage
            // 
            this.btnAddVoltage.Image = ((System.Drawing.Image)(resources.GetObject("btnAddVoltage.Image")));
            this.btnAddVoltage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddVoltage.Location = new System.Drawing.Point(230, 417);
            this.btnAddVoltage.Name = "btnAddVoltage";
            this.btnAddVoltage.Size = new System.Drawing.Size(137, 23);
            this.btnAddVoltage.TabIndex = 2;
            this.btnAddVoltage.Text = "sAdd Voltage";
            this.btnAddVoltage.UseVisualStyleBackColor = true;
            this.btnAddVoltage.Click += new System.EventHandler(this.btnAddVoltage_Click);
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
            glColumn2.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.TextBox;
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
            glColumn7.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn7.CheckBoxes = false;
            glColumn7.DatetimeSort = false;
            glColumn7.ImageIndex = -1;
            glColumn7.Name = "Column1xxx";
            glColumn7.NumericSort = false;
            glColumn7.Text = "sDefrost Heater";
            glColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn7.Width = 120;
            this.lvParts.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3,
            glColumn4,
            glColumn5,
            glColumn6,
            glColumn7});
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
            this.lvParts.Location = new System.Drawing.Point(6, 6);
            this.lvParts.Name = "lvParts";
            this.lvParts.Selectable = true;
            this.lvParts.SelectedTextColor = System.Drawing.Color.White;
            this.lvParts.SelectionColor = System.Drawing.Color.DarkBlue;
            this.lvParts.ShowBorder = true;
            this.lvParts.ShowFocusRect = true;
            this.lvParts.Size = new System.Drawing.Size(737, 405);
            this.lvParts.SortType = GlacialComponents.Controls.SortTypes.None;
            this.lvParts.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.lvParts.TabIndex = 0;
            this.lvParts.Text = "glacialList1";
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(368, 538);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 6;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmEvaporatorModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(781, 588);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.tabEvaporator);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdDeleteModel);
            this.Controls.Add(this.cmdLoadModel);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.cboEvapModel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmEvaporatorModel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "sData Manager - Evaporator Model";
            this.Load += new System.EventHandler(this.frmEvaporatorModel_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmEvaporatorModel_HelpRequested);
            this.tabEvaporator.ResumeLayout(false);
            this.tabInformation.ResumeLayout(false);
            this.tabInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacityAt10TD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFinishTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numConnQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSuction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLiquid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHotGas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlygoldPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRefCharge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeaterQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFanQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoilQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            this.tabCoilInfo.ResumeLayout(false);
            this.tabCoilInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCFM)).EndInit();
            this.tabParts.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboEvapModel;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Button cmdLoadModel;
        private System.Windows.Forms.Button cmdDeleteModel;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.TabControl tabEvaporator;
        private System.Windows.Forms.TabPage tabInformation;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.NumericUpDown numWeight;
        private System.Windows.Forms.ComboBox cboEvapStyle;
        private System.Windows.Forms.Label lblEvapStyle;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.ComboBox cboDefrostType;
        private System.Windows.Forms.Label lblDefrostType;
        private System.Windows.Forms.TabPage tabCoilInfo;
        private System.Windows.Forms.Label lblCoilModel;
        private System.Windows.Forms.TextBox txtCoilModel;
        private System.Windows.Forms.ComboBox cboFPI;
        private System.Windows.Forms.Label lblFPI;
        private System.Windows.Forms.NumericUpDown numCFM;
        private System.Windows.Forms.Label lblCFM;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.NumericUpDown numLength;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.NumericUpDown numRows;
        private System.Windows.Forms.ComboBox cboFinShape;
        private System.Windows.Forms.Label lblFinShape;
        private System.Windows.Forms.ComboBox cboFinType;
        private System.Windows.Forms.Label lblFinType;
        private System.Windows.Forms.Label lblFinHeight;
        private System.Windows.Forms.ComboBox cboFinHeight;
        private System.Windows.Forms.Button btnGenerateCoilModel;
        private System.Windows.Forms.Label lblCoilQty;
        private System.Windows.Forms.NumericUpDown numCoilQty;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.NumericUpDown numCapacity;
        private System.Windows.Forms.Label lblHeaterQty;
        private System.Windows.Forms.NumericUpDown numHeaterQty;
        private System.Windows.Forms.Label lblFanQty;
        private System.Windows.Forms.NumericUpDown numFanQty;
        private System.Windows.Forms.Label lblBlygoldPrice;
        private System.Windows.Forms.NumericUpDown numBlygoldPrice;
        private System.Windows.Forms.Label lblRefCharge;
        private System.Windows.Forms.NumericUpDown numRefCharge;
        private System.Windows.Forms.CheckBox chkLowVelocity;
        private System.Windows.Forms.Label lblHotGas;
        private System.Windows.Forms.NumericUpDown numHotGas;
        private System.Windows.Forms.Label lblSuction;
        private System.Windows.Forms.NumericUpDown numSuction;
        private System.Windows.Forms.Label lblLiquid;
        private System.Windows.Forms.NumericUpDown numLiquid;
        private System.Windows.Forms.Label lblConnQty;
        private System.Windows.Forms.NumericUpDown numConnQty;
        private System.Windows.Forms.ComboBox cboFanArrangement;
        private System.Windows.Forms.Label lblFanArrangement;
        private System.Windows.Forms.Label lblFinishTemp;
        private System.Windows.Forms.NumericUpDown numFinishTemp;
        private System.Windows.Forms.Label lblStartTemp;
        private System.Windows.Forms.NumericUpDown numStartTemp;
        private System.Windows.Forms.ComboBox cboEvapType;
        private System.Windows.Forms.Label lblEvapType;
        private System.Windows.Forms.TabPage tabParts;
        private GlacialComponents.Controls.GlacialList lvParts;
        private System.Windows.Forms.Label lblModelText;
        private System.Windows.Forms.TextBox txtModelText;
        private System.Windows.Forms.Button btnRemoveVoltage;
        private System.Windows.Forms.Button btnAddVoltage;
        private System.Windows.Forms.ComboBox cboVoltage;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label lblCapacityAt10TD;
        private System.Windows.Forms.NumericUpDown numCapacityAt10TD;
        private System.Windows.Forms.CheckBox chkWaterCoilSelection;
    }
}