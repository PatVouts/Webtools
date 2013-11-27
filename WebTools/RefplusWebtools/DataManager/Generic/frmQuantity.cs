using System;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Generic
{
    /* this is just a small form to get the user to choose a quantity of pieces to add to the kit he selected*/
    public partial class FrmQuantity : Form
    {
        private decimal _quantity;
        private decimal _price;
        public FrmQuantity(bool toAdd, decimal price)
        {
            InitializeComponent();
            if (!toAdd)
            {
                lblText.Name = "lblText2";
            }
            nUdPrice.Value = price;
            nudQuantity.Select(0, nudQuantity.Text.Length);
        }

        /*When the user confirms, it saves the value and closes.... the value is still accessible from "getQUantity" until
         * the parent process (frmOptionPack in this case) closes it*/
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            _quantity = nudQuantity.Value;
            _price = nUdPrice.Value;
            Close();
        }


        /*Simple return to get the quantity*/
        public decimal GetQuantity()
        {
            return _quantity;
        }

        /*Simple return to get the price*/
        public decimal GetPrice()
        {
            return _price;
        }
        /*just loading language and color */
        private void frmQuantity_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);
            Public.ChangeFormLanguage(this);
        }

        private void nudQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btnConfirm_Click(sender, e);
            }
            
        }

    }
}
