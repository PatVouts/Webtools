using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.Quotes
{
    public partial class FrmAdditionalItems : Form
    {
        //link to the quote form
        private readonly FrmQuotes _quoteform;
        //dataset of the quote
        private readonly DataSet _dsQuoteData;
        //index of the row, -1 mean not loading so we know it's a new record
        private readonly int _intIndex = -1;
        //item type
        private readonly int _itemType = -1;

        public FrmAdditionalItems()
        {
            InitializeComponent();
        }

        public FrmAdditionalItems(FrmQuotes quoteform, DataSet dsQuoteData, int intIndex, int itemType)
        {
            InitializeComponent();
            _quoteform = quoteform;
            _dsQuoteData = dsQuoteData;
            _intIndex = intIndex;
            _itemType = itemType;
        }

        private void cmdAddItem_Click(object sender, EventArgs e)
        {
            AddItem(Public.LanguageString("NEW ITEM (double click here to edit)", "NOUVEL ITEM (double-cliquez ici pour modifier)"), 1m, 0m);
            lstAdditionnalItems.Refresh();
        }

        public void AddItem(string description, decimal quantity, decimal listPrice)
        {
            var myItem = new GlacialComponents.Controls.GLItem(lstAdditionnalItems);
            myItem.SubItems[0].Text = description;
            myItem.SubItems[1].Control = QuantityUpDown(quantity);
            myItem.SubItems[2].Control = PriceUpDown(listPrice);
            lstAdditionnalItems.Items.Add(myItem);

            lstAdditionnalItems.Refresh();
        }

        private NumericUpDown QuantityUpDown(decimal quantity)
        {
            var num = new NumericUpDown {Value = 1m, Minimum = 1m, Maximum = 100m};
            num.Value = quantity;
            return num;
        }
        private NumericUpDown PriceUpDown(decimal listPrice)
        {
            var num = new NumericUpDown
            {
                Minimum = -10000000m,
                Maximum = 10000000m,
                DecimalPlaces = 2,
                Value = listPrice
            };
            return num;
        }

        private void RefreshList()
        {
            DataTable dtAdditionnalItemsOfTheUnit = Public.SelectAndSortTable(_dsQuoteData.Tables["AdditionalItems"], "ItemType = " + _itemType + " AND ItemID = " + _intIndex, "AdditionnalItemID ASC");

            if (dtAdditionnalItemsOfTheUnit.Rows.Count > 0)
            {
                ThreadProcess.Start(Public.LanguageString("Loading addtionnal items", "Chargement des items additionnels"));
                for (int i = 0; i < dtAdditionnalItemsOfTheUnit.Rows.Count; i++)
                {
                    AddItem(dtAdditionnalItemsOfTheUnit.Rows[i]["Description"].ToString(), Convert.ToDecimal(dtAdditionnalItemsOfTheUnit.Rows[i]["Quantity"]), Convert.ToDecimal(dtAdditionnalItemsOfTheUnit.Rows[i]["Price"]));
                }

                lstAdditionnalItems.Refresh();
                ThreadProcess.Stop();
                Focus();
            }
        }

        private void frmAdditionalItems_Load(object sender, EventArgs e)
        {
            Public.ChangeFormLanguage(this);

            Public.ChangeColor(this);

            RefreshList();


            if (UserInformation.RequiredPermissionLevel(99))
            {
                cboSpecial.Visible = true;
                cmdAddNewSpecial.Visible = true;
            }

            cboSpecial.SelectedIndex = 0;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            //#1840: Instead of cutting off text, will put message box indicating limit has been reached
            bool isLimitGood = true;
            for (int i = 0; i < lstAdditionnalItems.Items.Count; i++)
            {
                if (lstAdditionnalItems.Items[i].SubItems[0].Text.Length > 200)
                {
                    isLimitGood = false;
                    i = lstAdditionnalItems.Items.Count;
                }
            }
            if (isLimitGood)
            {
                _quoteform.DeleteFromQuoteAdditionalItems(_intIndex, _itemType);

                for (int i = 0; i < lstAdditionnalItems.Items.Count; i++)
                {
                    DataRow drAdditionalItems = _dsQuoteData.Tables["AdditionalItems"].NewRow();

                    drAdditionalItems["QuoteID"] = 0;
                    drAdditionalItems["QuoteRevision"] = 0;
                    drAdditionalItems["QuoteRevisionText"] = "";
                    drAdditionalItems["ItemType"] = _itemType;
                    drAdditionalItems["ItemID"] = _intIndex;
                    drAdditionalItems["Username"] = "";

                    drAdditionalItems["AdditionnalItemID"] = i;

                    //keep max 200 characters
                    string strDescription = lstAdditionnalItems.Items[i].SubItems[0].Text;
                    //strDescription = (strDescription.Length > 200 ? strDescription.Substring(0, 200) : strDescription);

                    drAdditionalItems["Description"] = strDescription;
                    drAdditionalItems["Quantity"] = ((NumericUpDown)lstAdditionnalItems.Items[i].SubItems[1].Control).Value;
                    drAdditionalItems["Price"] = ((NumericUpDown)lstAdditionnalItems.Items[i].SubItems[2].Control).Value;

                    _dsQuoteData.Tables["AdditionalItems"].Rows.Add(drAdditionalItems);
                }

                _quoteform.RefreshBasketList();
                _quoteform.SetQuoteIsModified(true);

                Close();
            }
            else
            {
                Public.LanguageBox("One or more descriptions is more than 200 characters. Please revise.", "Un ou plusieurs descriptions de plus de 200 caractères. S'il vous plaît réviser.");
            }
        }

        private void cmdRemoveItem_Click(object sender, EventArgs e)
        {
            if (lstAdditionnalItems.SelectedItems.Count > 0)
            {
                lstAdditionnalItems.Items.Remove(((GlacialComponents.Controls.GLItem)lstAdditionnalItems.SelectedItems[0]));
            }
            lstAdditionnalItems.Refresh();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblMaxCharacters_Click(object sender, EventArgs e)
        {

        }

        private void cmdCopy_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstAdditionnalItems.Items.Count; i++)
            {
                string strDescription = lstAdditionnalItems.Items[i].SubItems[0].Text;
                strDescription = (strDescription.Length > 200 ? strDescription.Substring(0, 200) : strDescription);

                InternalClipboard.Add_AdditionalItem(strDescription, Convert.ToInt32(((NumericUpDown)lstAdditionnalItems.Items[i].SubItems[1].Control).Value), ((NumericUpDown)lstAdditionnalItems.Items[i].SubItems[2].Control).Value);
            }
        }

        private void cmdPaste_Click(object sender, EventArgs e)
        {
            var clipboard = new FrmClipboard(FrmClipboard.OpenType.AdditionalItems);

            if (clipboard.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = clipboard.GetSelectedItems();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AddItem(dt.Rows[i]["Description"].ToString(), Convert.ToDecimal(dt.Rows[i]["Quantity"]), Convert.ToDecimal(dt.Rows[i]["Price"]));
                }

                lstAdditionnalItems.Refresh();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmAdditionalItems_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }

        private void cmdAddNewSpecial_Click(object sender, EventArgs e)
        {
            switch (cboSpecial.SelectedIndex)
            {
                case 0: //condensing unit options
                    var frmcuoption = new FrmAddCUOption(this);
                    frmcuoption.ShowDialog();
                    //if (frmcuoption.ShowDialog() == DialogResult.Yes)
                    //{
                    //    AddItem(frmcuoption.getDescription(), 1m, frmcuoption.getPrice());
                    //}
                    break;
                case 1: //condensing unit options
                    var frmevapoption = new FrmAddEvapOption(this);
                    frmevapoption.ShowDialog();
                    //if (frmcuoption.ShowDialog() == DialogResult.Yes)
                    //{
                    //    AddItem(frmcuoption.getDescription(), 1m, frmcuoption.getPrice());
                    //}
                    break;
            }
        }
    }
}