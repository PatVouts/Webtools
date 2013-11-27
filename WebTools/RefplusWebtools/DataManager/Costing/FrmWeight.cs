using System;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Costing
{
    public partial class FrmWeight : Form
    {
        private decimal _weight;

        public FrmWeight()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            decimal test;
            if (Decimal.TryParse(txtWeight.Text, out test))
            {
                _weight = Convert.ToDecimal(txtWeight.Text);
                Close();    
            }
            else
            {
                Public.LanguageBox("Please enter a valid decimal number before saving.  Thank you!", "Veuillez entrer un nombre décimal valide avant de sauvegarder.  Merci!");
            }

            
        }

        private void FrmWeight_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);
            Public.ChangeFormLanguage(this);
        }

        public Decimal GetWeight()
        {
            return _weight;
        }

        private void txtWeight_Enter(object sender, EventArgs e)
        {
            txtWeight.SelectAll();
        }
    }
}
