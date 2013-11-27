namespace RefplusWebtools.Report.SalesReport
{
    partial class FrmResults
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
            this.lvResults = new System.Windows.Forms.ListView();
            this.QuoteID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QuoteRevision = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProjectName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QuotationDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QuotationBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Multiplier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Contact = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Company = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnChangeSearch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvResults
            // 
            this.lvResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.QuoteID,
            this.QuoteRevision,
            this.ProjectName,
            this.QuotationDate,
            this.QuotationBy,
            this.Multiplier,
            this.Price,
            this.Contact,
            this.Company});
            this.lvResults.FullRowSelect = true;
            this.lvResults.GridLines = true;
            this.lvResults.Location = new System.Drawing.Point(5, 10);
            this.lvResults.MultiSelect = false;
            this.lvResults.Name = "lvResults";
            this.lvResults.Size = new System.Drawing.Size(954, 486);
            this.lvResults.TabIndex = 1;
            this.lvResults.UseCompatibleStateImageBehavior = false;
            this.lvResults.View = System.Windows.Forms.View.Details;

            this.lvResults.DoubleClick += new System.EventHandler(this.lvResults_DoubleClick);
            // 
            // QuoteID
            // 
            this.QuoteID.Text = "sQuote ID";
            // 
            // QuoteRevision
            // 
            this.QuoteRevision.Text = "sQuote Revision";
            this.QuoteRevision.Width = 25;
            // 
            // ProjectName
            // 
            this.ProjectName.Text = "sProject Name";
            this.ProjectName.Width = 120;
            // 
            // QuotationDate
            // 
            this.QuotationDate.Text = "sQuotation Date";
            this.QuotationDate.Width = 90;
            // 
            // QuotationBy
            // 
            this.QuotationBy.Text = "sQuotation By";
            this.QuotationBy.Width = 150;
            // 
            // Multiplier
            // 
            this.Multiplier.Text = "sMultiplier";
            // 
            // Price
            // 
            this.Price.Text = "Price";
            this.Price.Width = 70;
            // 
            // Contact
            // 
            this.Contact.Text = "Contact Name";
            this.Contact.Width = 185;
            // 
            // Company
            // 
            this.Company.Text = "Company";
            this.Company.Width = 185;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(294, 511);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(172, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "sOpen";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnChangeSearch
            // 
            this.btnChangeSearch.Location = new System.Drawing.Point(488, 511);
            this.btnChangeSearch.Name = "btnChangeSearch";
            this.btnChangeSearch.Size = new System.Drawing.Size(172, 23);
            this.btnChangeSearch.TabIndex = 3;
            this.btnChangeSearch.Text = "sSearch";
            this.btnChangeSearch.UseVisualStyleBackColor = true;
            this.btnChangeSearch.Click += new System.EventHandler(this.btnChangeSearch_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(680, 511);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(172, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "button3";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 546);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnChangeSearch);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.lvResults);
            this.Name = "FrmResults";
            this.Text = "frmResults";
            this.Load += new System.EventHandler(this.frmResults_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvResults;
        private System.Windows.Forms.ColumnHeader QuoteID;
        private System.Windows.Forms.ColumnHeader QuoteRevision;
        private System.Windows.Forms.ColumnHeader ProjectName;
        private System.Windows.Forms.ColumnHeader QuotationDate;
        private System.Windows.Forms.ColumnHeader QuotationBy;
        private System.Windows.Forms.ColumnHeader Multiplier;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.ColumnHeader Contact;
        private System.Windows.Forms.ColumnHeader Company;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnChangeSearch;
        private System.Windows.Forms.Button btnClose;
    }
}