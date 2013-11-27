namespace RefplusWebtools.Contact
{
    partial class FrmUserInformations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserInformations));
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword2 = new System.Windows.Forms.TextBox();
            this.lblPassword2 = new System.Windows.Forms.Label();
            this.chkEcosaire = new System.Windows.Forms.CheckBox();
            this.chkRefplus = new System.Windows.Forms.CheckBox();
            this.lblSiteAccess = new System.Windows.Forms.Label();
            this.lblUserLevel = new System.Windows.Forms.Label();
            this.cboUserLevel = new System.Windows.Forms.ComboBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.lblMinMultiplier = new System.Windows.Forms.Label();
            this.lblMaxMultiplier = new System.Windows.Forms.Label();
            this.numMinMultiplier = new System.Windows.Forms.NumericUpDown();
            this.numMaxMultiplier = new System.Windows.Forms.NumericUpDown();
            this.chkQuote = new System.Windows.Forms.CheckBox();
            this.chkQuoteCoil = new System.Windows.Forms.CheckBox();
            this.chkQuoteCondenser = new System.Windows.Forms.CheckBox();
            this.chkQuoteEvaporator = new System.Windows.Forms.CheckBox();
            this.chkQuoteCondensingUnit = new System.Windows.Forms.CheckBox();
            this.chkQuoteAdditionnalItems = new System.Windows.Forms.CheckBox();
            this.chkQuoteCustomUnit = new System.Windows.Forms.CheckBox();
            this.chkQuoteHeatPipe = new System.Windows.Forms.CheckBox();
            this.chkQuoteFluidCooler = new System.Windows.Forms.CheckBox();
            this.chkQuickCustomUnit = new System.Windows.Forms.CheckBox();
            this.chkQuickHeatPipe = new System.Windows.Forms.CheckBox();
            this.chkQuickFluidCooler = new System.Windows.Forms.CheckBox();
            this.chkQuickEvaporator = new System.Windows.Forms.CheckBox();
            this.chkQuickCondensingUnit = new System.Windows.Forms.CheckBox();
            this.chkQuickCondenser = new System.Windows.Forms.CheckBox();
            this.chkQuickCoil = new System.Windows.Forms.CheckBox();
            this.chkUserManager = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkQuoteManualCoil = new System.Windows.Forms.CheckBox();
            this.pnlRights = new System.Windows.Forms.Panel();
            this.chkOEMCoilProfitMargin = new System.Windows.Forms.CheckBox();
            this.chkQuickWaterEvaporator = new System.Windows.Forms.CheckBox();
            this.chkQuoteWaterEvaporator = new System.Windows.Forms.CheckBox();
            this.chkEngineeringReport = new System.Windows.Forms.CheckBox();
            this.chkReport = new System.Windows.Forms.CheckBox();
            this.chkAdvancedSalesReport = new System.Windows.Forms.CheckBox();
            this.chkQuoteOEMCoil = new System.Windows.Forms.CheckBox();
            this.chkDataManager = new System.Windows.Forms.CheckBox();
            this.chkBalancingModule = new System.Windows.Forms.CheckBox();
            this.chkAdvancedSearch = new System.Windows.Forms.CheckBox();
            this.chkQuickGravityCoil = new System.Windows.Forms.CheckBox();
            this.chkQuoteGravityCoil = new System.Windows.Forms.CheckBox();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numMinMultiplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxMultiplier)).BeginInit();
            this.pnlRights.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(7, 263);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(113, 27);
            this.cmdSave.TabIndex = 12;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(569, 263);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(113, 26);
            this.cmdCancel.TabIndex = 14;
            this.cmdCancel.Text = "sCancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(4, 9);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(60, 13);
            this.lblUsername.TabIndex = 82;
            this.lblUsername.Text = "sUsername";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(131, 6);
            this.txtUsername.MaxLength = 50;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(191, 20);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(131, 32);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(191, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(4, 35);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(58, 13);
            this.lblPassword.TabIndex = 84;
            this.lblPassword.Text = "sPassword";
            // 
            // txtPassword2
            // 
            this.txtPassword2.Location = new System.Drawing.Point(131, 58);
            this.txtPassword2.MaxLength = 50;
            this.txtPassword2.Name = "txtPassword2";
            this.txtPassword2.PasswordChar = '*';
            this.txtPassword2.Size = new System.Drawing.Size(191, 20);
            this.txtPassword2.TabIndex = 2;
            this.txtPassword2.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblPassword2
            // 
            this.lblPassword2.AutoSize = true;
            this.lblPassword2.Location = new System.Drawing.Point(4, 61);
            this.lblPassword2.Name = "lblPassword2";
            this.lblPassword2.Size = new System.Drawing.Size(102, 13);
            this.lblPassword2.TabIndex = 86;
            this.lblPassword2.Text = "sRe-Type Password";
            // 
            // chkEcosaire
            // 
            this.chkEcosaire.AutoSize = true;
            this.chkEcosaire.Location = new System.Drawing.Point(131, 101);
            this.chkEcosaire.Name = "chkEcosaire";
            this.chkEcosaire.Size = new System.Drawing.Size(80, 17);
            this.chkEcosaire.TabIndex = 4;
            this.chkEcosaire.Text = "ECOSAIRE";
            this.chkEcosaire.UseVisualStyleBackColor = true;
            // 
            // chkRefplus
            // 
            this.chkRefplus.AutoSize = true;
            this.chkRefplus.Location = new System.Drawing.Point(131, 81);
            this.chkRefplus.Name = "chkRefplus";
            this.chkRefplus.Size = new System.Drawing.Size(75, 17);
            this.chkRefplus.TabIndex = 6;
            this.chkRefplus.Text = "REFPLUS";
            this.chkRefplus.UseVisualStyleBackColor = true;
            // 
            // lblSiteAccess
            // 
            this.lblSiteAccess.AutoSize = true;
            this.lblSiteAccess.Location = new System.Drawing.Point(4, 85);
            this.lblSiteAccess.Name = "lblSiteAccess";
            this.lblSiteAccess.Size = new System.Drawing.Size(68, 13);
            this.lblSiteAccess.TabIndex = 93;
            this.lblSiteAccess.Text = "sSite Access";
            // 
            // lblUserLevel
            // 
            this.lblUserLevel.AutoSize = true;
            this.lblUserLevel.Location = new System.Drawing.Point(4, 161);
            this.lblUserLevel.Name = "lblUserLevel";
            this.lblUserLevel.Size = new System.Drawing.Size(63, 13);
            this.lblUserLevel.TabIndex = 94;
            this.lblUserLevel.Text = "sUser Level";
            // 
            // cboUserLevel
            // 
            this.cboUserLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUserLevel.FormattingEnabled = true;
            this.cboUserLevel.Location = new System.Drawing.Point(131, 158);
            this.cboUserLevel.Name = "cboUserLevel";
            this.cboUserLevel.Size = new System.Drawing.Size(191, 21);
            this.cboUserLevel.TabIndex = 7;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(131, 185);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(61, 17);
            this.chkActive.TabIndex = 8;
            this.chkActive.Text = "sActive";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // lblMinMultiplier
            // 
            this.lblMinMultiplier.AutoSize = true;
            this.lblMinMultiplier.Location = new System.Drawing.Point(4, 210);
            this.lblMinMultiplier.Name = "lblMinMultiplier";
            this.lblMinMultiplier.Size = new System.Drawing.Size(73, 13);
            this.lblMinMultiplier.TabIndex = 97;
            this.lblMinMultiplier.Text = "sMin Multiplier";
            // 
            // lblMaxMultiplier
            // 
            this.lblMaxMultiplier.AutoSize = true;
            this.lblMaxMultiplier.Location = new System.Drawing.Point(4, 236);
            this.lblMaxMultiplier.Name = "lblMaxMultiplier";
            this.lblMaxMultiplier.Size = new System.Drawing.Size(76, 13);
            this.lblMaxMultiplier.TabIndex = 98;
            this.lblMaxMultiplier.Text = "sMax Multiplier";
            // 
            // numMinMultiplier
            // 
            this.numMinMultiplier.DecimalPlaces = 3;
            this.numMinMultiplier.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numMinMultiplier.Location = new System.Drawing.Point(131, 208);
            this.numMinMultiplier.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinMultiplier.Name = "numMinMultiplier";
            this.numMinMultiplier.Size = new System.Drawing.Size(120, 20);
            this.numMinMultiplier.TabIndex = 9;
            this.numMinMultiplier.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // numMaxMultiplier
            // 
            this.numMaxMultiplier.DecimalPlaces = 3;
            this.numMaxMultiplier.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numMaxMultiplier.Location = new System.Drawing.Point(131, 234);
            this.numMaxMultiplier.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxMultiplier.Name = "numMaxMultiplier";
            this.numMaxMultiplier.Size = new System.Drawing.Size(120, 20);
            this.numMaxMultiplier.TabIndex = 10;
            this.numMaxMultiplier.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxMultiplier.Enter += new System.EventHandler(this.AutoSelectOnTab);
            // 
            // chkQuote
            // 
            this.chkQuote.AutoSize = true;
            this.chkQuote.Location = new System.Drawing.Point(3, 3);
            this.chkQuote.Name = "chkQuote";
            this.chkQuote.Size = new System.Drawing.Size(60, 17);
            this.chkQuote.TabIndex = 0;
            this.chkQuote.Text = "sQuote";
            this.chkQuote.UseVisualStyleBackColor = true;
            // 
            // chkQuoteCoil
            // 
            this.chkQuoteCoil.AutoSize = true;
            this.chkQuoteCoil.Location = new System.Drawing.Point(3, 20);
            this.chkQuoteCoil.Name = "chkQuoteCoil";
            this.chkQuoteCoil.Size = new System.Drawing.Size(80, 17);
            this.chkQuoteCoil.TabIndex = 1;
            this.chkQuoteCoil.Text = "sQuote Coil";
            this.chkQuoteCoil.UseVisualStyleBackColor = true;
            // 
            // chkQuoteCondenser
            // 
            this.chkQuoteCondenser.AutoSize = true;
            this.chkQuoteCondenser.Location = new System.Drawing.Point(3, 54);
            this.chkQuoteCondenser.Name = "chkQuoteCondenser";
            this.chkQuoteCondenser.Size = new System.Drawing.Size(114, 17);
            this.chkQuoteCondenser.TabIndex = 3;
            this.chkQuoteCondenser.Text = "sQuote Condenser";
            this.chkQuoteCondenser.UseVisualStyleBackColor = true;
            // 
            // chkQuoteEvaporator
            // 
            this.chkQuoteEvaporator.AutoSize = true;
            this.chkQuoteEvaporator.Location = new System.Drawing.Point(3, 88);
            this.chkQuoteEvaporator.Name = "chkQuoteEvaporator";
            this.chkQuoteEvaporator.Size = new System.Drawing.Size(115, 17);
            this.chkQuoteEvaporator.TabIndex = 5;
            this.chkQuoteEvaporator.Text = "sQuote Evaporator";
            this.chkQuoteEvaporator.UseVisualStyleBackColor = true;
            // 
            // chkQuoteCondensingUnit
            // 
            this.chkQuoteCondensingUnit.AutoSize = true;
            this.chkQuoteCondensingUnit.Location = new System.Drawing.Point(3, 71);
            this.chkQuoteCondensingUnit.Name = "chkQuoteCondensingUnit";
            this.chkQuoteCondensingUnit.Size = new System.Drawing.Size(141, 17);
            this.chkQuoteCondensingUnit.TabIndex = 4;
            this.chkQuoteCondensingUnit.Text = "sQuote Condensing Unit";
            this.chkQuoteCondensingUnit.UseVisualStyleBackColor = true;
            // 
            // chkQuoteAdditionnalItems
            // 
            this.chkQuoteAdditionnalItems.AutoSize = true;
            this.chkQuoteAdditionnalItems.Location = new System.Drawing.Point(3, 190);
            this.chkQuoteAdditionnalItems.Name = "chkQuoteAdditionnalItems";
            this.chkQuoteAdditionnalItems.Size = new System.Drawing.Size(143, 17);
            this.chkQuoteAdditionnalItems.TabIndex = 10;
            this.chkQuoteAdditionnalItems.Text = "sQuote Additionnal Items";
            this.chkQuoteAdditionnalItems.UseVisualStyleBackColor = true;
            // 
            // chkQuoteCustomUnit
            // 
            this.chkQuoteCustomUnit.AutoSize = true;
            this.chkQuoteCustomUnit.Location = new System.Drawing.Point(3, 173);
            this.chkQuoteCustomUnit.Name = "chkQuoteCustomUnit";
            this.chkQuoteCustomUnit.Size = new System.Drawing.Size(120, 17);
            this.chkQuoteCustomUnit.TabIndex = 9;
            this.chkQuoteCustomUnit.Text = "sQuote Custom Unit";
            this.chkQuoteCustomUnit.UseVisualStyleBackColor = true;
            // 
            // chkQuoteHeatPipe
            // 
            this.chkQuoteHeatPipe.AutoSize = true;
            this.chkQuoteHeatPipe.Location = new System.Drawing.Point(3, 156);
            this.chkQuoteHeatPipe.Name = "chkQuoteHeatPipe";
            this.chkQuoteHeatPipe.Size = new System.Drawing.Size(110, 17);
            this.chkQuoteHeatPipe.TabIndex = 8;
            this.chkQuoteHeatPipe.Text = "sQuote Heat Pipe";
            this.chkQuoteHeatPipe.UseVisualStyleBackColor = true;
            // 
            // chkQuoteFluidCooler
            // 
            this.chkQuoteFluidCooler.AutoSize = true;
            this.chkQuoteFluidCooler.Location = new System.Drawing.Point(3, 139);
            this.chkQuoteFluidCooler.Name = "chkQuoteFluidCooler";
            this.chkQuoteFluidCooler.Size = new System.Drawing.Size(118, 17);
            this.chkQuoteFluidCooler.TabIndex = 7;
            this.chkQuoteFluidCooler.Text = "sQuote Fluid Cooler";
            this.chkQuoteFluidCooler.UseVisualStyleBackColor = true;
            // 
            // chkQuickCustomUnit
            // 
            this.chkQuickCustomUnit.AutoSize = true;
            this.chkQuickCustomUnit.Location = new System.Drawing.Point(3, 360);
            this.chkQuickCustomUnit.Name = "chkQuickCustomUnit";
            this.chkQuickCustomUnit.Size = new System.Drawing.Size(119, 17);
            this.chkQuickCustomUnit.TabIndex = 19;
            this.chkQuickCustomUnit.Text = "sQuick Custom Unit";
            this.chkQuickCustomUnit.UseVisualStyleBackColor = true;
            // 
            // chkQuickHeatPipe
            // 
            this.chkQuickHeatPipe.AutoSize = true;
            this.chkQuickHeatPipe.Location = new System.Drawing.Point(3, 343);
            this.chkQuickHeatPipe.Name = "chkQuickHeatPipe";
            this.chkQuickHeatPipe.Size = new System.Drawing.Size(109, 17);
            this.chkQuickHeatPipe.TabIndex = 18;
            this.chkQuickHeatPipe.Text = "sQuick Heat Pipe";
            this.chkQuickHeatPipe.UseVisualStyleBackColor = true;
            // 
            // chkQuickFluidCooler
            // 
            this.chkQuickFluidCooler.AutoSize = true;
            this.chkQuickFluidCooler.Location = new System.Drawing.Point(3, 326);
            this.chkQuickFluidCooler.Name = "chkQuickFluidCooler";
            this.chkQuickFluidCooler.Size = new System.Drawing.Size(117, 17);
            this.chkQuickFluidCooler.TabIndex = 17;
            this.chkQuickFluidCooler.Text = "sQuick Fluid Cooler";
            this.chkQuickFluidCooler.UseVisualStyleBackColor = true;
            // 
            // chkQuickEvaporator
            // 
            this.chkQuickEvaporator.AutoSize = true;
            this.chkQuickEvaporator.Location = new System.Drawing.Point(3, 275);
            this.chkQuickEvaporator.Name = "chkQuickEvaporator";
            this.chkQuickEvaporator.Size = new System.Drawing.Size(114, 17);
            this.chkQuickEvaporator.TabIndex = 15;
            this.chkQuickEvaporator.Text = "sQuick Evaporator";
            this.chkQuickEvaporator.UseVisualStyleBackColor = true;
            // 
            // chkQuickCondensingUnit
            // 
            this.chkQuickCondensingUnit.AutoSize = true;
            this.chkQuickCondensingUnit.Location = new System.Drawing.Point(3, 258);
            this.chkQuickCondensingUnit.Name = "chkQuickCondensingUnit";
            this.chkQuickCondensingUnit.Size = new System.Drawing.Size(140, 17);
            this.chkQuickCondensingUnit.TabIndex = 14;
            this.chkQuickCondensingUnit.Text = "sQuick Condensing Unit";
            this.chkQuickCondensingUnit.UseVisualStyleBackColor = true;
            // 
            // chkQuickCondenser
            // 
            this.chkQuickCondenser.AutoSize = true;
            this.chkQuickCondenser.Location = new System.Drawing.Point(3, 241);
            this.chkQuickCondenser.Name = "chkQuickCondenser";
            this.chkQuickCondenser.Size = new System.Drawing.Size(113, 17);
            this.chkQuickCondenser.TabIndex = 13;
            this.chkQuickCondenser.Text = "sQuick Condenser";
            this.chkQuickCondenser.UseVisualStyleBackColor = true;
            // 
            // chkQuickCoil
            // 
            this.chkQuickCoil.AutoSize = true;
            this.chkQuickCoil.Location = new System.Drawing.Point(3, 224);
            this.chkQuickCoil.Name = "chkQuickCoil";
            this.chkQuickCoil.Size = new System.Drawing.Size(79, 17);
            this.chkQuickCoil.TabIndex = 12;
            this.chkQuickCoil.Text = "sQuick Coil";
            this.chkQuickCoil.UseVisualStyleBackColor = true;
            // 
            // chkUserManager
            // 
            this.chkUserManager.AutoSize = true;
            this.chkUserManager.Location = new System.Drawing.Point(3, 377);
            this.chkUserManager.Name = "chkUserManager";
            this.chkUserManager.Size = new System.Drawing.Size(98, 17);
            this.chkUserManager.TabIndex = 20;
            this.chkUserManager.Text = "sUser Manager";
            this.chkUserManager.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(328, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 119;
            this.label1.Text = "sRights / Access";
            // 
            // chkQuoteManualCoil
            // 
            this.chkQuoteManualCoil.AutoSize = true;
            this.chkQuoteManualCoil.Location = new System.Drawing.Point(3, 37);
            this.chkQuoteManualCoil.Name = "chkQuoteManualCoil";
            this.chkQuoteManualCoil.Size = new System.Drawing.Size(118, 17);
            this.chkQuoteManualCoil.TabIndex = 2;
            this.chkQuoteManualCoil.Text = "sQuote Manual Coil";
            this.chkQuoteManualCoil.UseVisualStyleBackColor = true;
            // 
            // pnlRights
            // 
            this.pnlRights.AutoScroll = true;
            this.pnlRights.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlRights.Controls.Add(this.chkOEMCoilProfitMargin);
            this.pnlRights.Controls.Add(this.chkQuickWaterEvaporator);
            this.pnlRights.Controls.Add(this.chkQuoteWaterEvaporator);
            this.pnlRights.Controls.Add(this.chkEngineeringReport);
            this.pnlRights.Controls.Add(this.chkReport);
            this.pnlRights.Controls.Add(this.chkAdvancedSalesReport);
            this.pnlRights.Controls.Add(this.chkQuoteOEMCoil);
            this.pnlRights.Controls.Add(this.chkDataManager);
            this.pnlRights.Controls.Add(this.chkBalancingModule);
            this.pnlRights.Controls.Add(this.chkAdvancedSearch);
            this.pnlRights.Controls.Add(this.chkQuickGravityCoil);
            this.pnlRights.Controls.Add(this.chkQuoteGravityCoil);
            this.pnlRights.Controls.Add(this.chkQuote);
            this.pnlRights.Controls.Add(this.chkQuoteManualCoil);
            this.pnlRights.Controls.Add(this.chkQuoteCoil);
            this.pnlRights.Controls.Add(this.chkQuoteCondenser);
            this.pnlRights.Controls.Add(this.chkUserManager);
            this.pnlRights.Controls.Add(this.chkQuoteCondensingUnit);
            this.pnlRights.Controls.Add(this.chkQuickCustomUnit);
            this.pnlRights.Controls.Add(this.chkQuoteEvaporator);
            this.pnlRights.Controls.Add(this.chkQuickHeatPipe);
            this.pnlRights.Controls.Add(this.chkQuoteFluidCooler);
            this.pnlRights.Controls.Add(this.chkQuickFluidCooler);
            this.pnlRights.Controls.Add(this.chkQuoteHeatPipe);
            this.pnlRights.Controls.Add(this.chkQuickEvaporator);
            this.pnlRights.Controls.Add(this.chkQuoteCustomUnit);
            this.pnlRights.Controls.Add(this.chkQuickCondensingUnit);
            this.pnlRights.Controls.Add(this.chkQuoteAdditionnalItems);
            this.pnlRights.Controls.Add(this.chkQuickCondenser);
            this.pnlRights.Controls.Add(this.chkQuickCoil);
            this.pnlRights.Location = new System.Drawing.Point(422, 6);
            this.pnlRights.Name = "pnlRights";
            this.pnlRights.Size = new System.Drawing.Size(260, 248);
            this.pnlRights.TabIndex = 11;
            // 
            // chkOEMCoilProfitMargin
            // 
            this.chkOEMCoilProfitMargin.AutoSize = true;
            this.chkOEMCoilProfitMargin.Location = new System.Drawing.Point(3, 496);
            this.chkOEMCoilProfitMargin.Name = "chkOEMCoilProfitMargin";
            this.chkOEMCoilProfitMargin.Size = new System.Drawing.Size(137, 17);
            this.chkOEMCoilProfitMargin.TabIndex = 29;
            this.chkOEMCoilProfitMargin.Text = "sOEM Coil Profit Margin";
            this.chkOEMCoilProfitMargin.UseVisualStyleBackColor = true;
            // 
            // chkQuickWaterEvaporator
            // 
            this.chkQuickWaterEvaporator.AutoSize = true;
            this.chkQuickWaterEvaporator.Location = new System.Drawing.Point(3, 292);
            this.chkQuickWaterEvaporator.Name = "chkQuickWaterEvaporator";
            this.chkQuickWaterEvaporator.Size = new System.Drawing.Size(146, 17);
            this.chkQuickWaterEvaporator.TabIndex = 28;
            this.chkQuickWaterEvaporator.Text = "sQuick Water Evaporator";
            this.chkQuickWaterEvaporator.UseVisualStyleBackColor = true;
            // 
            // chkQuoteWaterEvaporator
            // 
            this.chkQuoteWaterEvaporator.AutoSize = true;
            this.chkQuoteWaterEvaporator.Location = new System.Drawing.Point(3, 105);
            this.chkQuoteWaterEvaporator.Name = "chkQuoteWaterEvaporator";
            this.chkQuoteWaterEvaporator.Size = new System.Drawing.Size(147, 17);
            this.chkQuoteWaterEvaporator.TabIndex = 27;
            this.chkQuoteWaterEvaporator.Text = "sQuote Water Evaporator";
            this.chkQuoteWaterEvaporator.UseVisualStyleBackColor = true;
            // 
            // chkEngineeringReport
            // 
            this.chkEngineeringReport.AutoSize = true;
            this.chkEngineeringReport.Location = new System.Drawing.Point(3, 462);
            this.chkEngineeringReport.Name = "chkEngineeringReport";
            this.chkEngineeringReport.Size = new System.Drawing.Size(122, 17);
            this.chkEngineeringReport.TabIndex = 25;
            this.chkEngineeringReport.Text = "sEngineering Report";
            this.chkEngineeringReport.UseVisualStyleBackColor = true;
            // 
            // chkReport
            // 
            this.chkReport.AutoSize = true;
            this.chkReport.Location = new System.Drawing.Point(3, 445);
            this.chkReport.Name = "chkReport";
            this.chkReport.Size = new System.Drawing.Size(63, 17);
            this.chkReport.TabIndex = 24;
            this.chkReport.Text = "sReport";
            this.chkReport.UseVisualStyleBackColor = true;
            // 
            // chkAdvancedSalesReport
            // 
            this.chkAdvancedSalesReport.AutoSize = true;
            this.chkAdvancedSalesReport.Location = new System.Drawing.Point(3, 479);
            this.chkAdvancedSalesReport.Name = "chkAdvancedSalesReport";
            this.chkAdvancedSalesReport.Size = new System.Drawing.Size(144, 17);
            this.chkAdvancedSalesReport.TabIndex = 26;
            this.chkAdvancedSalesReport.Text = "sAdvanced Sales Report";
            this.chkAdvancedSalesReport.UseVisualStyleBackColor = true;
            // 
            // chkQuoteOEMCoil
            // 
            this.chkQuoteOEMCoil.AutoSize = true;
            this.chkQuoteOEMCoil.Location = new System.Drawing.Point(3, 207);
            this.chkQuoteOEMCoil.Name = "chkQuoteOEMCoil";
            this.chkQuoteOEMCoil.Size = new System.Drawing.Size(107, 17);
            this.chkQuoteOEMCoil.TabIndex = 11;
            this.chkQuoteOEMCoil.Text = "sQuote OEM Coil";
            this.chkQuoteOEMCoil.UseVisualStyleBackColor = true;
            // 
            // chkDataManager
            // 
            this.chkDataManager.AutoSize = true;
            this.chkDataManager.Location = new System.Drawing.Point(3, 428);
            this.chkDataManager.Name = "chkDataManager";
            this.chkDataManager.Size = new System.Drawing.Size(99, 17);
            this.chkDataManager.TabIndex = 23;
            this.chkDataManager.Text = "sData Manager";
            this.chkDataManager.UseVisualStyleBackColor = true;
            // 
            // chkBalancingModule
            // 
            this.chkBalancingModule.AutoSize = true;
            this.chkBalancingModule.Location = new System.Drawing.Point(3, 411);
            this.chkBalancingModule.Name = "chkBalancingModule";
            this.chkBalancingModule.Size = new System.Drawing.Size(116, 17);
            this.chkBalancingModule.TabIndex = 22;
            this.chkBalancingModule.Text = "sBalancing Module";
            this.chkBalancingModule.UseVisualStyleBackColor = true;
            // 
            // chkAdvancedSearch
            // 
            this.chkAdvancedSearch.AutoSize = true;
            this.chkAdvancedSearch.Location = new System.Drawing.Point(3, 394);
            this.chkAdvancedSearch.Name = "chkAdvancedSearch";
            this.chkAdvancedSearch.Size = new System.Drawing.Size(117, 17);
            this.chkAdvancedSearch.TabIndex = 21;
            this.chkAdvancedSearch.Text = "sAdvanced Search";
            this.chkAdvancedSearch.UseVisualStyleBackColor = true;
            // 
            // chkQuickGravityCoil
            // 
            this.chkQuickGravityCoil.AutoSize = true;
            this.chkQuickGravityCoil.Location = new System.Drawing.Point(3, 309);
            this.chkQuickGravityCoil.Name = "chkQuickGravityCoil";
            this.chkQuickGravityCoil.Size = new System.Drawing.Size(115, 17);
            this.chkQuickGravityCoil.TabIndex = 16;
            this.chkQuickGravityCoil.Text = "sQuick Gravity Coil";
            this.chkQuickGravityCoil.UseVisualStyleBackColor = true;
            // 
            // chkQuoteGravityCoil
            // 
            this.chkQuoteGravityCoil.AutoSize = true;
            this.chkQuoteGravityCoil.Location = new System.Drawing.Point(3, 122);
            this.chkQuoteGravityCoil.Name = "chkQuoteGravityCoil";
            this.chkQuoteGravityCoil.Size = new System.Drawing.Size(116, 17);
            this.chkQuoteGravityCoil.TabIndex = 6;
            this.chkQuoteGravityCoil.Text = "sQuote Gravity Coil";
            this.chkQuoteGravityCoil.UseVisualStyleBackColor = true;
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(320, 264);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 13;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmUserInformations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(694, 294);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.pnlRights);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numMaxMultiplier);
            this.Controls.Add(this.numMinMultiplier);
            this.Controls.Add(this.lblMaxMultiplier);
            this.Controls.Add(this.lblMinMultiplier);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.cboUserLevel);
            this.Controls.Add(this.lblUserLevel);
            this.Controls.Add(this.lblSiteAccess);
            this.Controls.Add(this.chkRefplus);
            this.Controls.Add(this.chkEcosaire);
            this.Controls.Add(this.txtPassword2);
            this.Controls.Add(this.lblPassword2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserInformations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "sUser Informations";
            this.Load += new System.EventHandler(this.frmUserInformations_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmUserInformations_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.numMinMultiplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxMultiplier)).EndInit();
            this.pnlRights.ResumeLayout(false);
            this.pnlRights.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword2;
        private System.Windows.Forms.Label lblPassword2;
        private System.Windows.Forms.CheckBox chkEcosaire;
        private System.Windows.Forms.CheckBox chkRefplus;
        private System.Windows.Forms.Label lblSiteAccess;
        private System.Windows.Forms.Label lblUserLevel;
        private System.Windows.Forms.ComboBox cboUserLevel;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label lblMinMultiplier;
        private System.Windows.Forms.Label lblMaxMultiplier;
        private System.Windows.Forms.NumericUpDown numMinMultiplier;
        private System.Windows.Forms.NumericUpDown numMaxMultiplier;
        private System.Windows.Forms.CheckBox chkQuote;
        private System.Windows.Forms.CheckBox chkQuoteCoil;
        private System.Windows.Forms.CheckBox chkQuoteCondenser;
        private System.Windows.Forms.CheckBox chkQuoteEvaporator;
        private System.Windows.Forms.CheckBox chkQuoteCondensingUnit;
        private System.Windows.Forms.CheckBox chkQuoteAdditionnalItems;
        private System.Windows.Forms.CheckBox chkQuoteCustomUnit;
        private System.Windows.Forms.CheckBox chkQuoteHeatPipe;
        private System.Windows.Forms.CheckBox chkQuoteFluidCooler;
        private System.Windows.Forms.CheckBox chkQuickCustomUnit;
        private System.Windows.Forms.CheckBox chkQuickHeatPipe;
        private System.Windows.Forms.CheckBox chkQuickFluidCooler;
        private System.Windows.Forms.CheckBox chkQuickEvaporator;
        private System.Windows.Forms.CheckBox chkQuickCondensingUnit;
        private System.Windows.Forms.CheckBox chkQuickCondenser;
        private System.Windows.Forms.CheckBox chkQuickCoil;
        private System.Windows.Forms.CheckBox chkUserManager;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkQuoteManualCoil;
        private System.Windows.Forms.Panel pnlRights;
        private System.Windows.Forms.CheckBox chkQuoteGravityCoil;
        private System.Windows.Forms.CheckBox chkQuickGravityCoil;
        private System.Windows.Forms.CheckBox chkAdvancedSearch;
        private System.Windows.Forms.CheckBox chkBalancingModule;
        private System.Windows.Forms.CheckBox chkDataManager;
        private System.Windows.Forms.CheckBox chkQuoteOEMCoil;
        private System.Windows.Forms.CheckBox chkEngineeringReport;
        private System.Windows.Forms.CheckBox chkReport;
        private System.Windows.Forms.CheckBox chkAdvancedSalesReport;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.CheckBox chkQuickWaterEvaporator;
        private System.Windows.Forms.CheckBox chkQuoteWaterEvaporator;
        private System.Windows.Forms.CheckBox chkOEMCoilProfitMargin;
    }
}