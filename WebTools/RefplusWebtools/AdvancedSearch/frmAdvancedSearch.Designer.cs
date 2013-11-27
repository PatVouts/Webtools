namespace RefplusWebtools.AdvancedSearch
{
    partial class FrmAdvancedSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdvancedSearch));
            this.grpSearchCriteria = new System.Windows.Forms.GroupBox();
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.pnlSearchCriteriaList = new System.Windows.Forms.Panel();
            this.cmdAddFilter = new System.Windows.Forms.Button();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.lvResults = new System.Windows.Forms.ListView();
            this.QuoteID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QuoteRevisionNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QuoteRevision = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProjectName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QuotationDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QuotationBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QuotationByUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Rep = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Engineer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Terms = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Delivery = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Freight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContactName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.City = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Country = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CompanyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Notes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Attention = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastUpdateBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CoilModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CondenserModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EvapModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FluidCoolerModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HeatPipeModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CondUnitModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GravityCoilModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CustomUnitModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ManualCoilModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OEMCoilModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdOpen = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.grpSearchCriteria.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSearchCriteria
            // 
            this.grpSearchCriteria.Controls.Add(this.cboFilter);
            this.grpSearchCriteria.Controls.Add(this.pnlSearchCriteriaList);
            this.grpSearchCriteria.Controls.Add(this.cmdAddFilter);
            this.grpSearchCriteria.Controls.Add(this.cmdSearch);
            this.grpSearchCriteria.Controls.Add(this.cmdReset);
            this.grpSearchCriteria.Location = new System.Drawing.Point(8, 4);
            this.grpSearchCriteria.Name = "grpSearchCriteria";
            this.grpSearchCriteria.Size = new System.Drawing.Size(783, 211);
            this.grpSearchCriteria.TabIndex = 0;
            this.grpSearchCriteria.TabStop = false;
            this.grpSearchCriteria.Text = "sSearch Criteria";
            // 
            // cboFilter
            // 
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.FormattingEnabled = true;
            this.cboFilter.Location = new System.Drawing.Point(9, 18);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(188, 21);
            this.cboFilter.TabIndex = 24;
            // 
            // pnlSearchCriteriaList
            // 
            this.pnlSearchCriteriaList.AutoScroll = true;
            this.pnlSearchCriteriaList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearchCriteriaList.Location = new System.Drawing.Point(9, 45);
            this.pnlSearchCriteriaList.Name = "pnlSearchCriteriaList";
            this.pnlSearchCriteriaList.Size = new System.Drawing.Size(765, 160);
            this.pnlSearchCriteriaList.TabIndex = 23;
            // 
            // cmdAddFilter
            // 
            this.cmdAddFilter.Image = ((System.Drawing.Image)(resources.GetObject("cmdAddFilter.Image")));
            this.cmdAddFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAddFilter.Location = new System.Drawing.Point(203, 15);
            this.cmdAddFilter.Name = "cmdAddFilter";
            this.cmdAddFilter.Size = new System.Drawing.Size(130, 24);
            this.cmdAddFilter.TabIndex = 22;
            this.cmdAddFilter.Text = "sAdd Filter";
            this.cmdAddFilter.UseVisualStyleBackColor = true;
            this.cmdAddFilter.Click += new System.EventHandler(this.cmdAddFilter_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSearch.Location = new System.Drawing.Point(339, 15);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(130, 24);
            this.cmdSearch.TabIndex = 19;
            this.cmdSearch.Text = "sSearch";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.Image = ((System.Drawing.Image)(resources.GetObject("cmdReset.Image")));
            this.cmdReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdReset.Location = new System.Drawing.Point(644, 14);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(130, 24);
            this.cmdReset.TabIndex = 18;
            this.cmdReset.Text = "sReset";
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // lvResults
            // 
            this.lvResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.QuoteID,
            this.QuoteRevisionNum,
            this.QuoteRevision,
            this.ProjectName,
            this.QuotationDate,
            this.QuotationBy,
            this.QuotationByUsername,
            this.Email,
            this.Rep,
            this.Engineer,
            this.Terms,
            this.Delivery,
            this.Freight,
            this.ContactName,
            this.Address,
            this.City,
            this.State,
            this.Country,
            this.CompanyName,
            this.Notes,
            this.Attention,
            this.LastUpdateBy,
            this.CoilModel,
            this.CondenserModel,
            this.EvapModel,
            this.FluidCoolerModel,
            this.HeatPipeModel,
            this.CondUnitModel,
            this.GravityCoilModel,
            this.CustomUnitModel,
            this.ManualCoilModel,
            this.OEMCoilModel});
            this.lvResults.FullRowSelect = true;
            this.lvResults.GridLines = true;
            this.lvResults.Location = new System.Drawing.Point(8, 221);
            this.lvResults.MultiSelect = false;
            this.lvResults.Name = "lvResults";
            this.lvResults.Size = new System.Drawing.Size(774, 298);
            this.lvResults.TabIndex = 1;
            this.lvResults.UseCompatibleStateImageBehavior = false;
            this.lvResults.View = System.Windows.Forms.View.Details;
            this.lvResults.DoubleClick += new System.EventHandler(this.lvResults_DoubleClick);
            // 
            // QuoteID
            // 
            this.QuoteID.Text = "sQuote ID";
            // 
            // QuoteRevisionNum
            // 
            this.QuoteRevisionNum.Text = "";
            this.QuoteRevisionNum.Width = 0;
            // 
            // QuoteRevision
            // 
            this.QuoteRevision.Text = "sQuote Revision";
            this.QuoteRevision.Width = 100;
            // 
            // ProjectName
            // 
            this.ProjectName.Text = "sProject Name";
            this.ProjectName.Width = 120;
            // 
            // QuotationDate
            // 
            this.QuotationDate.Text = "sQuotation Date";
            this.QuotationDate.Width = 200;
            // 
            // QuotationBy
            // 
            this.QuotationBy.Text = "sQuotation By";
            this.QuotationBy.Width = 150;
            // 
            // QuotationByUsername
            // 
            this.QuotationByUsername.Text = "sQuotationByUsername";
            this.QuotationByUsername.Width = 150;
            // 
            // Email
            // 
            this.Email.Text = "sEmail";
            this.Email.Width = 120;
            // 
            // Rep
            // 
            this.Rep.Text = "sRep";
            this.Rep.Width = 120;
            // 
            // Engineer
            // 
            this.Engineer.Text = "sEngineer";
            this.Engineer.Width = 75;
            // 
            // Terms
            // 
            this.Terms.Text = "sTerms";
            this.Terms.Width = 90;
            // 
            // Delivery
            // 
            this.Delivery.Text = "sDelivery";
            // 
            // Freight
            // 
            this.Freight.Text = "sFreight";
            this.Freight.Width = 85;
            // 
            // ContactName
            // 
            this.ContactName.Text = "sContact Name";
            this.ContactName.Width = 250;
            // 
            // Address
            // 
            this.Address.Text = "sAddress";
            this.Address.Width = 175;
            // 
            // City
            // 
            this.City.Text = "sCity";
            this.City.Width = 140;
            // 
            // State
            // 
            this.State.Text = "sState";
            // 
            // Country
            // 
            this.Country.Text = "sCountry";
            this.Country.Width = 80;
            // 
            // CompanyName
            // 
            this.CompanyName.Text = "sCompany Name";
            this.CompanyName.Width = 200;
            // 
            // Notes
            // 
            this.Notes.Text = "sNotes";
            // 
            // Attention
            // 
            this.Attention.Text = "sAttention";
            // 
            // LastUpdateBy
            // 
            this.LastUpdateBy.Text = "sLast Update By";
            this.LastUpdateBy.Width = 190;
            // 
            // CoilModel
            // 
            this.CoilModel.Text = "sCoil Model";
            this.CoilModel.Width = 200;
            // 
            // CondenserModel
            // 
            this.CondenserModel.Text = "sCondenser Model";
            this.CondenserModel.Width = 200;
            // 
            // EvapModel
            // 
            this.EvapModel.Text = "sEvaporator Model";
            this.EvapModel.Width = 200;
            // 
            // FluidCoolerModel
            // 
            this.FluidCoolerModel.Text = "sFluid Cooler Model";
            this.FluidCoolerModel.Width = 200;
            // 
            // HeatPipeModel
            // 
            this.HeatPipeModel.Text = "sHeat Pipe Model";
            this.HeatPipeModel.Width = 200;
            // 
            // CondUnitModel
            // 
            this.CondUnitModel.Text = "sCondensing Unit Model";
            this.CondUnitModel.Width = 200;
            // 
            // GravityCoilModel
            // 
            this.GravityCoilModel.Text = "sGravity Coil Model";
            this.GravityCoilModel.Width = 200;
            // 
            // CustomUnitModel
            // 
            this.CustomUnitModel.Text = "sCustom Unit Model";
            this.CustomUnitModel.Width = 200;
            // 
            // ManualCoilModel
            // 
            this.ManualCoilModel.Text = "sManual Coil Model";
            this.ManualCoilModel.Width = 200;
            // 
            // OEMCoilModel
            // 
            this.OEMCoilModel.Text = "sOEM Coil Model";
            this.OEMCoilModel.Width = 200;
            // 
            // cmdOpen
            // 
            this.cmdOpen.Image = ((System.Drawing.Image)(resources.GetObject("cmdOpen.Image")));
            this.cmdOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOpen.Location = new System.Drawing.Point(8, 525);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(165, 24);
            this.cmdOpen.TabIndex = 76;
            this.cmdOpen.Text = "sOpen";
            this.cmdOpen.UseVisualStyleBackColor = true;
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.Location = new System.Drawing.Point(617, 525);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(165, 24);
            this.cmdClose.TabIndex = 75;
            this.cmdClose.Text = "sClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(372, 525);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(27, 24);
            this.btnHelp.TabIndex = 77;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmAdvancedSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(794, 554);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cmdOpen);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.lvResults);
            this.Controls.Add(this.grpSearchCriteria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAdvancedSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "sAdvanced Search";
            this.Load += new System.EventHandler(this.frmAdvancedSearch_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmAdvancedSearch_HelpRequested);
            this.grpSearchCriteria.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSearchCriteria;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdAddFilter;
        private System.Windows.Forms.ListView lvResults;
        private System.Windows.Forms.Panel pnlSearchCriteriaList;
        private System.Windows.Forms.ComboBox cboFilter;
        private System.Windows.Forms.ColumnHeader QuoteID;
        private System.Windows.Forms.ColumnHeader QuoteRevisionNum;
        private System.Windows.Forms.ColumnHeader QuoteRevision;
        private System.Windows.Forms.ColumnHeader ProjectName;
        private System.Windows.Forms.ColumnHeader QuotationDate;
        private System.Windows.Forms.ColumnHeader QuotationBy;
        private System.Windows.Forms.ColumnHeader QuotationByUsername;
        private System.Windows.Forms.ColumnHeader Email;
        private System.Windows.Forms.ColumnHeader Rep;
        private System.Windows.Forms.ColumnHeader Engineer;
        private System.Windows.Forms.ColumnHeader Terms;
        private System.Windows.Forms.ColumnHeader Delivery;
        private System.Windows.Forms.ColumnHeader Freight;
        private System.Windows.Forms.ColumnHeader ContactName;
        private System.Windows.Forms.ColumnHeader Address;
        private System.Windows.Forms.ColumnHeader City;
        private System.Windows.Forms.ColumnHeader State;
        private System.Windows.Forms.ColumnHeader Country;
        private System.Windows.Forms.ColumnHeader Notes;
        private System.Windows.Forms.ColumnHeader Attention;
        private System.Windows.Forms.ColumnHeader LastUpdateBy;
        private System.Windows.Forms.ColumnHeader CoilModel;
        private System.Windows.Forms.ColumnHeader CondenserModel;
        private System.Windows.Forms.ColumnHeader EvapModel;
        private System.Windows.Forms.ColumnHeader FluidCoolerModel;
        private System.Windows.Forms.ColumnHeader HeatPipeModel;
        private System.Windows.Forms.Button cmdOpen;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.ColumnHeader CondUnitModel;
        private System.Windows.Forms.ColumnHeader GravityCoilModel;
        private System.Windows.Forms.ColumnHeader CustomUnitModel;
        private System.Windows.Forms.ColumnHeader ManualCoilModel;
        private System.Windows.Forms.ColumnHeader OEMCoilModel;
        private System.Windows.Forms.Button btnHelp;
        new private System.Windows.Forms.ColumnHeader CompanyName;
    }
}