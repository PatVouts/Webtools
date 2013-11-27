using System;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Pricing
{
    public partial class FrmEditPrice : Form
    {
        private readonly decimal _currentPrice;
        private readonly decimal _newPrice;

        public FrmEditPrice(decimal currentPrice, decimal newPrice)
        {
            InitializeComponent();
            _currentPrice = currentPrice;
            _newPrice = newPrice;
        }

        public decimal GetNewPrice()
        {
            return numNewPrice.Value;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }
        
        private void frmEditPrice_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            lblCurrentPriceValue.Text = _currentPrice.ToString("N2");
            numNewPrice.Value = _newPrice;
        }

        //auto-select content of numerical up and down on tab
        private void AutoSelectOnTab(object sender, EventArgs e)
        {
            //numerical up and down do not select text by default when we tab
            //or clik in the control. This code make him do it
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmEditPrice_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }
    }
}