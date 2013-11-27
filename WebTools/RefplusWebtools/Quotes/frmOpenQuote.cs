using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace RefplusWebtools.Quotes
{
    public partial class FrmOpenQuote : Form
    {
        DataTable _dtQuoteList;

        readonly FrmMain _mainForm;

        public FrmOpenQuote(FrmMain parentForm)
        {
            InitializeComponent();
            _mainForm = parentForm;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmOpenQuote_Load(object sender, EventArgs e)
        {
           

           
            
            Public.ChangeFormLanguage(this);
            
            FillDateFilter();

            ValidateDateFilterAppearance();

            if (UserInformation.AccessAdvancedSearch)
            {
                cmdAdvancedSearch.Visible = true;
            }
        }

        private void FillDateFilter()
        {
            ComboBoxControl.AddItem(cboDateFilter, "1", "Today");
            ComboBoxControl.AddItem(cboDateFilter, "7", "Last Week");
            ComboBoxControl.AddItem(cboDateFilter, "14", "Last 2 Weeks");
            ComboBoxControl.AddItem(cboDateFilter, "21", "Last 3 Weeks");
            ComboBoxControl.AddItem(cboDateFilter, "30", "Last Month");
            ComboBoxControl.AddItem(cboDateFilter, "60", "Last 2 Months");
            ComboBoxControl.AddItem(cboDateFilter, "90", "Last 3 Months");
            ComboBoxControl.AddItem(cboDateFilter, "180", "Last 6 months");
            ComboBoxControl.AddItem(cboDateFilter, "365", "Last Year");
            ComboBoxControl.AddItem(cboDateFilter, "-1", "All Time");

            ComboBoxControl.SetDefaultValue(cboDateFilter, "Last Week");
        }

        private string GetQuoteNumberFilter()
        {
            string quoteNumberFilter = "";

            try
            {
                if (txtSearchByQuoteNumber.Text.Trim() != "")
                {
                    quoteNumberFilter += " QuoteID = " + Convert.ToInt32(txtSearchByQuoteNumber.Text);
                }
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(), "frmOpenQuote getQuoteNumberFilter");
            }

            return quoteNumberFilter;
        }

        private void FillListOfQuote()
        {
            ThreadProcess.Start(Public.LanguageString("Loading quotes", "Chargement des soumissions"));
         
            //fill the list of quotes
            lstQuoteList.Items.Clear();

            //2011-05-24 : adding quote # filter
            //if we filter the quote number we must bypass the datetime search

            string strQuoteNumberFilter = GetQuoteNumberFilter();

            _dtQuoteList = strQuoteNumberFilter == "" ? 
                Query.Select("SELECT * FROM QuoteData WHERE QuotationDate >= '" + DateFilter().ToShortDateString() + "' " + QuoteVisibilityWhereClause() + " AND QuotationSite = '" + UserInformation.CurrentSite + "' ORDER BY QuotationDate DESC") 
                : Query.Select("SELECT * FROM QuoteData WHERE " + GetQuoteNumberFilter() + " " + QuoteVisibilityWhereClause() + " AND QuotationSite = '" + UserInformation.CurrentSite + "' ORDER BY QuotationDate DESC");

            for (int irow = 0; irow < _dtQuoteList.Rows.Count; irow++)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lstQuoteList);

                myItem.SubItems[0].Text = irow.ToString(CultureInfo.InvariantCulture);
                myItem.SubItems[1].Text = _dtQuoteList.Rows[irow]["ProjectName"].ToString();
                myItem.SubItems[2].Text = _dtQuoteList.Rows[irow]["ContactName"].ToString();
                myItem.SubItems[3].Text = _dtQuoteList.Rows[irow]["QuoteID"] + "-" + _dtQuoteList.Rows[irow]["QuoteRevisionText"];
                myItem.SubItems[4].Text = _dtQuoteList.Rows[irow]["QuotationBy"].ToString();
                myItem.SubItems[5].Text = _dtQuoteList.Rows[irow]["LastUpdateBy"].ToString();
                myItem.SubItems[6].Text = Convert.ToDateTime(_dtQuoteList.Rows[irow]["QuotationDate"]).ToString(CultureInfo.InvariantCulture);

                lstQuoteList.Items.Add(myItem);
            }

            lstQuoteList.Refresh();

            ThreadProcess.Stop();
            Focus();
        }

        private void cmdOpen_Click(object sender, EventArgs e)
        {
            OpenQuote();
        }

        private void lstQuoteList_DoubleClick(object sender, EventArgs e)
        {
            OpenQuote();
        }

        private void OpenQuote()
        {
            if (lstQuoteList.SelectedItems.Count > 0)
            {
                int rowIndex = Convert.ToInt32(((GlacialComponents.Controls.GLItem)lstQuoteList.SelectedItems[0]).SubItems[0].Text);

                int intQuoteID = Convert.ToInt32(_dtQuoteList.Rows[rowIndex]["QuoteID"]);
                int intRevision = Convert.ToInt32(_dtQuoteList.Rows[rowIndex]["QuoteRevision"]);

                _mainForm.LoadQuote(intQuoteID, intRevision);

                Dispose();
            }
            else
            {
                Public.LanguageBox("You must select a quote to open", "Vous devez sélectionner une soumission a ouvrir");
            }
        }

        private DateTime DateFilter()
        {
            DateTime dtDateFilter = DateTime.Now;
            switch (ComboBoxControl.IndexInformation(cboDateFilter))
            {
                case "1": dtDateFilter = DateTime.Now; break;
                case "7": dtDateFilter = DateTime.Now.AddDays(-7); break;
                case "14": dtDateFilter = DateTime.Now.AddDays(-14); break;
                case "21": dtDateFilter = DateTime.Now.AddDays(-21); break;
                case "30": dtDateFilter = DateTime.Now.AddMonths(-1); break;
                case "60": dtDateFilter = DateTime.Now.AddMonths(-2); break;
                case "90": dtDateFilter = DateTime.Now.AddMonths(-3); break;
                case "180": dtDateFilter = DateTime.Now.AddMonths(-6); break;
                case "365": dtDateFilter = DateTime.Now.AddYears(-1); break;
                case "-1": dtDateFilter = Convert.ToDateTime("01-01-2000"); break;
            }
            return dtDateFilter;
        }

        private void cboDateFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillListOfQuote();
        }

        private string QuoteVisibilityWhereClause()
        {
            string strQuoteVisibilityWhereClause;

            //user level 90++ can see all quotes
            if (UserInformation.RequiredPermissionLevel(90))
            {
                strQuoteVisibilityWhereClause = "";
            }
            else
            {
                //see quotes created by someone within groups
                //you have acccess to
                //and the one created for them as well.
                strQuoteVisibilityWhereClause = " AND (QuotationByGroupID IN (" + UserInformation.UserGroups + ") OR GroupID IN (" + UserInformation.UserGroups + "))";
            }

            return strQuoteVisibilityWhereClause;
        }

        private void cmdAdvancedSearch_Click(object sender, EventArgs e)
        {
            _mainForm.OpenAdvancedSearch();

            Dispose();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void txtSearchByQuoteNumber_TextChanged(object sender, EventArgs e)
        {
            ValidateDateFilterAppearance();
        }

        private void ValidateDateFilterAppearance()
        {
            cboDateFilter.Visible = txtSearchByQuoteNumber.Text == "";
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            FillListOfQuote();
        }

        private void lstQuoteList_Click(object sender, EventArgs e)
        {

        }
    }
}