using System;
using System.Data;
using System.Windows.Forms;


namespace RefplusWebtools.Report.SalesReport
{
    //This form takes all results from the FrmSalesReport form and displays them in a listView
    public partial class FrmResults : Form
    {
        //Contains the datatable to be displayed and the main form so we can open a quote
        private readonly DataTable _toDisplay;
        private readonly FrmMain _parent;

        //Basic constructor, only assigning the datatable to the passed results, and the mainform from the sales report form that opened the results
        public FrmResults(DataTable quotes, FrmMain mainForm)
        {
            InitializeComponent();
            _toDisplay = quotes;
            _parent = mainForm;
        }


        //starts by assigning color and language to the form, followed with the display of all the info from the datatable in the listview
        private void frmResults_Load(object sender, EventArgs e)
        {
            Public.ChangeFormLanguage(this);
            Public.ChangeColor(this);

            foreach (DataRow row in _toDisplay.Rows)
            {
                var myItem = new ListViewItem(row["quoteID"].ToString());
                myItem.SubItems.Add(row["quoteRevision"].ToString());
                myItem.SubItems.Add(row["projectName"].ToString());
                myItem.SubItems.Add(Convert.ToDateTime(row["quotationDate"]).ToString("dd/MM/yyyy"));
                myItem.SubItems.Add(row["quotationBy"].ToString());
                myItem.SubItems.Add(row["multiplier"].ToString());
                //0:C is to display in Currency mode.
                myItem.SubItems.Add(string.Format("{0:C}",Convert.ToDecimal(row["Price"].ToString())));
                myItem.SubItems.Add(row["Name"].ToString());
                myItem.SubItems.Add(row["CompanyName"].ToString());
                lvResults.Items.Add(myItem);
            }
            Focus();
        }

        //If there's a quotation selected, we open it.  If there's none, we say it.
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if(lvResults.SelectedItems.Count > 0)
            {
                _parent.LoadQuote(Convert.ToInt32(lvResults.SelectedItems[0].SubItems[0].Text), Convert.ToInt32(lvResults.SelectedItems[0].SubItems[1].Text));
            }
            else
            {
                Public.LanguageBox("Please select one quote before clicking on open.  Thank you!", "S'il vous plaît, sélectionnez une soumission avant de cliquer sur ce bouton.  Merci!");
            }
        }

        //Reloading the sales report
        private void btnChangeSearch_Click(object sender, EventArgs e)
        {
            var search = new FrmSalesReport(_parent);
            Close();
            search.Show();
        }

        // closing the form
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Same as "open".  When you double click on a quote, it opens it.  Check for the "selected Items = 0" because you can actually doubleclick in the list view without selecting anything
        private void lvResults_DoubleClick(object sender, EventArgs e)
        {
            if(lvResults.SelectedItems.Count > 0)
            {
                _parent.LoadQuote(Convert.ToInt32(lvResults.SelectedItems[0].SubItems[0].Text),Convert.ToInt32(lvResults.SelectedItems[0].SubItems[1].Text));
            }
            else
            {
                Public.LanguageBox("Please select one quote before clicking on open.  Thank you!", "S'il vous plaît, sélectionnez une soumission avant de cliquer sur ce bouton.  Merci!");
            }
        }
    }
}
