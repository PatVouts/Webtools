using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.Quotes
{
    public partial class FrmAddCUOption : Form
    {
        private readonly string[] _strTableList = { "CondensingUnitOptions" };

        private string _description = "";
        private decimal _price;
        private readonly FrmAdditionalItems _frmParentForm;

        public FrmAddCUOption(FrmAdditionalItems frmParentForm)
        {
           InitializeComponent();
           _frmParentForm = frmParentForm;
        }

        private void frmAddCUOption_Load(object sender, EventArgs e)
        {
            Public.ChangeFormLanguage(this);

            Public.ChangeColor(this);

            Query.LoadTables(_strTableList);

            FillListOfOptions();
        }

        public string GetDescription()
        {
            return _description;
        }

        public decimal GetPrice()
        {
            return _price;
        }


        private void FillListOfOptions()
        {
            lstCUOptions.Items.Clear();

            DataTable dtCUOptions = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondensingUnitOptions"], "", "GroupName, Description, Price");

            for (int i = 0; i < dtCUOptions.Rows.Count; i++)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lstCUOptions);

                string groupName = dtCUOptions.Rows[i]["GroupName"].ToString();
                string description = dtCUOptions.Rows[i]["Description"].ToString();

                if (groupName == description)
                {
                    myItem.SubItems[0].Text = description;
                }
                else
                {
                    myItem.SubItems[0].Text = groupName + " - " + description;
                }
                myItem.SubItems[1].Text = Convert.ToDecimal(dtCUOptions.Rows[i]["Price"]).ToString("N2");

                lstCUOptions.Items.Add(myItem);
            }

            lstCUOptions.Refresh();

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (lstCUOptions.SelectedItems.Count > 0)
            {
                _description = ((GlacialComponents.Controls.GLItem)lstCUOptions.SelectedItems[0]).SubItems[0].Text;
                _price = Convert.ToDecimal(((GlacialComponents.Controls.GLItem)lstCUOptions.SelectedItems[0]).SubItems[1].Text);

                _frmParentForm.AddItem(_description, 1m, _price);

                Public.LanguageBox("Item added", "Item ajouté");
                //this.DialogResult = DialogResult.Yes;
            }
            else
            {
                Public.LanguageBox("You must pick an option to add first", "Vous devez sélectionner une option à ajouter");
            }
        }
       
    }
}