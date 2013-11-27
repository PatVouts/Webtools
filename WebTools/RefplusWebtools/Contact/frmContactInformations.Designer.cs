namespace RefplusWebtools.Contact
{
    partial class FrmContactInformations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmContactInformations));
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhoneExt = new System.Windows.Forms.TextBox();
            this.lblPhoneExt = new System.Windows.Forms.Label();
            this.lblFax = new System.Windows.Forms.Label();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.lblStreet = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.lblZip = new System.Windows.Forms.Label();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.lblWebsite = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtCellphone = new System.Windows.Forms.TextBox();
            this.lblCellphone = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.picEmail = new System.Windows.Forms.PictureBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cboGroup = new System.Windows.Forms.ComboBox();
            this.lblGroup = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.lblSpecify = new System.Windows.Forms.Label();
            this.cboCountry = new System.Windows.Forms.ComboBox();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picEmail)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(4, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(40, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "sName";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(127, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(193, 20);
            this.txtName.TabIndex = 0;
            this.txtName.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(127, 32);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(193, 20);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(4, 35);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(32, 13);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "sTitle";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(4, 61);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(43, 13);
            this.lblPhone.TabIndex = 4;
            this.lblPhone.Text = "sPhone";
            // 
            // txtPhoneExt
            // 
            this.txtPhoneExt.Location = new System.Drawing.Point(127, 84);
            this.txtPhoneExt.Name = "txtPhoneExt";
            this.txtPhoneExt.Size = new System.Drawing.Size(193, 20);
            this.txtPhoneExt.TabIndex = 3;
            this.txtPhoneExt.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblPhoneExt
            // 
            this.lblPhoneExt.AutoSize = true;
            this.lblPhoneExt.Location = new System.Drawing.Point(4, 87);
            this.lblPhoneExt.Name = "lblPhoneExt";
            this.lblPhoneExt.Size = new System.Drawing.Size(90, 13);
            this.lblPhoneExt.TabIndex = 6;
            this.lblPhoneExt.Text = "sPhone Extention";
            // 
            // lblFax
            // 
            this.lblFax.AutoSize = true;
            this.lblFax.Location = new System.Drawing.Point(4, 139);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(29, 13);
            this.lblFax.TabIndex = 8;
            this.lblFax.Text = "sFax";
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(408, 110);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(230, 20);
            this.txtCountry.TabIndex = 12;
            this.txtCountry.Visible = false;
            this.txtCountry.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(330, 87);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(48, 13);
            this.lblCountry.TabIndex = 18;
            this.lblCountry.Text = "sCountry";
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(408, 58);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(230, 20);
            this.txtState.TabIndex = 10;
            this.txtState.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(330, 61);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(37, 13);
            this.lblState.TabIndex = 16;
            this.lblState.Text = "sState";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(408, 32);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(230, 20);
            this.txtCity.TabIndex = 9;
            this.txtCity.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(330, 35);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(29, 13);
            this.lblCity.TabIndex = 14;
            this.lblCity.Text = "sCity";
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(408, 6);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(230, 20);
            this.txtStreet.TabIndex = 8;
            this.txtStreet.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(330, 9);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(40, 13);
            this.lblStreet.TabIndex = 12;
            this.lblStreet.Text = "sStreet";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(127, 162);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(193, 20);
            this.txtEmail.TabIndex = 6;
            this.txtEmail.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(4, 165);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(37, 13);
            this.lblEmail.TabIndex = 20;
            this.lblEmail.Text = "sEmail";
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(408, 136);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(230, 20);
            this.txtZip.TabIndex = 13;
            this.txtZip.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblZip
            // 
            this.lblZip.AutoSize = true;
            this.lblZip.Location = new System.Drawing.Point(330, 139);
            this.lblZip.Name = "lblZip";
            this.lblZip.Size = new System.Drawing.Size(27, 13);
            this.lblZip.TabIndex = 22;
            this.lblZip.Text = "sZip";
            // 
            // txtWebsite
            // 
            this.txtWebsite.Location = new System.Drawing.Point(127, 188);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(193, 20);
            this.txtWebsite.TabIndex = 7;
            this.txtWebsite.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblWebsite
            // 
            this.lblWebsite.AutoSize = true;
            this.lblWebsite.Location = new System.Drawing.Point(4, 191);
            this.lblWebsite.Name = "lblWebsite";
            this.lblWebsite.Size = new System.Drawing.Size(51, 13);
            this.lblWebsite.TabIndex = 24;
            this.lblWebsite.Text = "sWebsite";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(127, 214);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComment.Size = new System.Drawing.Size(511, 84);
            this.txtComment.TabIndex = 16;
            this.txtComment.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(4, 217);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(56, 13);
            this.lblComment.TabIndex = 29;
            this.lblComment.Text = "sComment";
            // 
            // txtCellphone
            // 
            this.txtCellphone.Location = new System.Drawing.Point(127, 110);
            this.txtCellphone.Name = "txtCellphone";
            this.txtCellphone.Size = new System.Drawing.Size(193, 20);
            this.txtCellphone.TabIndex = 4;
            this.txtCellphone.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblCellphone
            // 
            this.lblCellphone.AutoSize = true;
            this.lblCellphone.Location = new System.Drawing.Point(4, 113);
            this.lblCellphone.Name = "lblCellphone";
            this.lblCellphone.Size = new System.Drawing.Size(59, 13);
            this.lblCellphone.TabIndex = 33;
            this.lblCellphone.Text = "sCellphone";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(127, 136);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(193, 20);
            this.txtFax.TabIndex = 5;
            this.txtFax.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(127, 58);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(193, 20);
            this.txtPhone.TabIndex = 2;
            this.txtPhone.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(7, 301);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(113, 26);
            this.cmdSave.TabIndex = 17;
            this.cmdSave.Text = "sSave";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(525, 301);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(113, 25);
            this.cmdCancel.TabIndex = 19;
            this.cmdCancel.Text = "sCancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click_1);
            // 
            // picEmail
            // 
            this.picEmail.Image = ((System.Drawing.Image)(resources.GetObject("picEmail.Image")));
            this.picEmail.Location = new System.Drawing.Point(108, 164);
            this.picEmail.Name = "picEmail";
            this.picEmail.Size = new System.Drawing.Size(16, 16);
            this.picEmail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picEmail.TabIndex = 80;
            this.picEmail.TabStop = false;
            this.picEmail.Click += new System.EventHandler(this.picEmail_Click);
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(330, 165);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(56, 13);
            this.lblCompany.TabIndex = 81;
            this.lblCompany.Text = "sCompany";
            // 
            // cboGroup
            // 
            this.cboGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGroup.DropDownWidth = 300;
            this.cboGroup.FormattingEnabled = true;
            this.cboGroup.Location = new System.Drawing.Point(408, 188);
            this.cboGroup.Name = "cboGroup";
            this.cboGroup.Size = new System.Drawing.Size(230, 21);
            this.cboGroup.TabIndex = 15;
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(330, 191);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(41, 13);
            this.lblGroup.TabIndex = 83;
            this.lblGroup.Text = "sGroup";
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(408, 162);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(230, 20);
            this.txtCompany.TabIndex = 14;
            this.txtCompany.Enter += new System.EventHandler(this.AutoSelectTextBox_Enter);
            // 
            // lblSpecify
            // 
            this.lblSpecify.AutoSize = true;
            this.lblSpecify.Location = new System.Drawing.Point(330, 113);
            this.lblSpecify.Name = "lblSpecify";
            this.lblSpecify.Size = new System.Drawing.Size(47, 13);
            this.lblSpecify.TabIndex = 84;
            this.lblSpecify.Text = "sSpecify";
            this.lblSpecify.Visible = false;
            // 
            // cboCountry
            // 
            this.cboCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCountry.DropDownWidth = 300;
            this.cboCountry.FormattingEnabled = true;
            this.cboCountry.Items.AddRange(new object[] {
            "Canada",
            "United States",
            "Other"});
            this.cboCountry.Location = new System.Drawing.Point(408, 84);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(230, 21);
            this.cboCountry.TabIndex = 11;
            this.cboCountry.SelectedIndexChanged += new System.EventHandler(this.cboCountry_SelectedIndexChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(308, 301);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 18;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmContactInformations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(644, 329);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cboCountry);
            this.Controls.Add(this.lblSpecify);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.cboGroup);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.picEmail);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.txtCellphone);
            this.Controls.Add(this.lblCellphone);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtStreet);
            this.Controls.Add(this.lblPhoneExt);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhoneExt);
            this.Controls.Add(this.lblStreet);
            this.Controls.Add(this.lblZip);
            this.Controls.Add(this.lblFax);
            this.Controls.Add(this.txtWebsite);
            this.Controls.Add(this.txtZip);
            this.Controls.Add(this.lblWebsite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmContactInformations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "sContact Informations";
            this.Load += new System.EventHandler(this.frmContactInformations_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmContactInformations_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.picEmail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhoneExt;
        private System.Windows.Forms.Label lblPhoneExt;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.Label lblZip;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.Label lblWebsite;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtCellphone;
        private System.Windows.Forms.Label lblCellphone;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.PictureBox picEmail;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.ComboBox cboGroup;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label lblSpecify;
        private System.Windows.Forms.ComboBox cboCountry;
        private System.Windows.Forms.Button btnHelp;
    }
}