using System;
using System.Globalization;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Pricing
{
    public partial class FrmConfirmPriceChange : Form
    {
        private readonly int _amountOfUnits;
        private readonly string _type = "";

        public FrmConfirmPriceChange(int amountOfUnits,string type)
        {
            InitializeComponent();
            _amountOfUnits = amountOfUnits;
            _type = type;
        }

        public string GetReason()
        {
            return txtReason.Text;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            if (txtReason.Text.Trim().Length > 0)
            {
                DialogResult = DialogResult.Yes;
                Close();
            }
        }

        private void frmConfirmPriceChange_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            lblMessage.Text = Public.Language == "EN" ? "You are about to make changes to %QTY% %TYPE%.\n\n The changes are irreversible.\n\n To accept the changes you must specify a reason below." : "Vous êtes sur le point de faire des changements aux %QTY% %TYPE%.\n\n Les changements sont irréversibles.\n\n Pour accepter les modifications, vous devez spécifier une raison ci-dessous.";

            lblMessage.Text = lblMessage.Text.Replace("%QTY%", _amountOfUnits.ToString(CultureInfo.InvariantCulture).Replace("-1", ""));

            lblMessage.Text = lblMessage.Text.Replace("%TYPE%", _type);
            
        }

        private void AutoSelectTextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }
    }
}