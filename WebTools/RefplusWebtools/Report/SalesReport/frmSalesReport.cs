using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.Report.SalesReport
{
    //Pretty quick and easy form, just to display the correct quotations in the next interface (frmResults)

    public partial class FrmSalesReport : Form
    {
        //As much as I'd like to work another way, to open a quote you need to send it to the main form, so we have to save the parent form of this one (the main) to be able to open a quote in the next interface (ugh)
        //PVTO DO : SINGLETON FrmMAIN........ SIGH... WHY ISN'T IT ALREADY A FRAKKING SINGLETON

        private readonly FrmMain _parent;

        //Basic constructor, only assigning the mainForm
        public FrmSalesReport(FrmMain mainForm)
        {
            InitializeComponent();
            _parent = mainForm;
        }


        //Button "search for quotes"
        private void btnFind_Click(object sender, EventArgs e)
        {
            //Data validation that it makes sense
            if (num_Minimum.Value > num_Maximum.Value || d_End.Value < d_Start.Value)
            {
                Public.LanguageBox(
                    "Your dates are in the wrong order, or your minimum price is bigger than your maximum price.  Please correct before searching.",
                    "Vos dates entrées sont inversées, ou votre prix minimum est plus grand que votre prix maximum.  Veuillez corriger avant de relancer la rechercher.  Merci!");
            }
            else
            {
                //No matter what, we search.  If we find no results, we will display no results, that's it
                ThreadProcess.Start("Searching quotes");
                string toAdd = "";
                if (chkInternal.Checked)
                {
                    toAdd = " quotationByContactID in (select userID from useraccount_new where userlevel > 89) and ";
                }

//The Query is pretty simple.  We use a left join because not ALL contacts still exist, 
                DataTable quotes = Query.Select("Select qd.quoteID, qd.quotationDate,qd.quoterevision, qd.ProjectName, QuotationBy, qd.multiplier, cn.Name, cn.CompanyName, qp.Price from quoteData " +
                                                "as qd left join contact_new as cn on qd.ContactID = cn.ContactID inner join QuotePrice as qp on qp.QuoteId = qd.QuoteID and qp.QuoteRevision = " +
                                                "qd.Quoterevision where " + toAdd + " quotationDate between '" + d_Start.Value.ToString("MM/dd/yyyy") + "' and '" + d_End.Value.ToString("MM/dd/yyyy")
                                                + "' and qp.price > " + num_Minimum.Value + " and qp.price < " + num_Maximum.Value + "  order by qd.quoteID DESC , qd.quoteRevision");
                ThreadProcess.Stop();
                var results = new FrmResults(quotes, _parent);
                results.Show();
                Visible = false;
            }

        }

        //Closing the form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        //Load, so we just set the language, the color, and the dates.  THe end time is today, the start time is last week
        private void FrmSalesReport_Load(object sender, EventArgs e)
        {
            Public.ChangeFormLanguage(this);
            Public.ChangeColor(this);
            var now = DateTime.Now;
            d_End.Value = now;
            now = now.AddDays(-7);
            d_Start.Value = now;
            
        }

    }
}
