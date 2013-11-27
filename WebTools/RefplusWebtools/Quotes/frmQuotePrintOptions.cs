using System;
using System.Windows.Forms;

namespace RefplusWebtools.Quotes
{
    public partial class FrmQuotePrintOptions : Form
    {
        public FrmQuotePrintOptions()
        {
            InitializeComponent();
        }

        private void frmQuotePrintFormat_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);
            Public.ChangeFormLanguage(this);
        }

        public bool PricingHeaderPage()
        {
            return chkPricingHeaderPage.Checked;
        }

        public bool PricingPages()
        {
            return chkPricingPages.Checked;
        }

        public bool DetailPricingPages()
        {
            return radDetailed.Checked;
        }

        public bool PerformanceSheets()
        {
            return chkPerformanceSheets.Checked;
        }

  

        public bool Drawings()
        {
            return chkDrawings.Checked;
        }
        public bool Dimensions()
        {
            return chkDimensions.Checked;
        }

        private void cmdContinue_Click(object sender, EventArgs e)
        {
            if (PricingHeaderPage() || PricingPages() || PerformanceSheets() ||  Drawings() || Dimensions())
            {
                Close();
            }
            else
            {
                Public.LanguageBox("You must at least pick one option", "Vous devez sélectionner au moins une option.");
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmQuotePrintOptions_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }

        private void chkPricingPages_CheckedChanged(object sender, EventArgs e)
        {
            pnlPricingPage.Enabled = chkPricingPages.Checked;
        }
    }
}