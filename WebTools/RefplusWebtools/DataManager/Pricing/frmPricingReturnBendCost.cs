using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Pricing
{
    public partial class FrmPricingReturnBendCost : Form
    {
        public FrmPricingReturnBendCost()
        {
            InitializeComponent();
        }

        private void frmPricingReturnBendCost_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            Fill_ReturnBendCost();
        }

        private void Fill_ReturnBendCost()
        {
            lvReturnBendCost.Items.Clear();

            DataTable dtPricingReturnBendCost = Query.Select("SELECT * FROM PricingReturnBendCost ORDEr BY FinType");

            foreach (DataRow dr in dtPricingReturnBendCost.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvReturnBendCost);

                myItem.SubItems[0].Text = dr["FinType"].ToString();
                myItem.SubItems[1].Control = GetNumericUpDown(Convert.ToDecimal(dr["ReturnBendCost"]));

                lvReturnBendCost.Items.Add(myItem);
            }

            lvReturnBendCost.Refresh();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private NumericUpDown GetNumericUpDown(decimal Default)
        {
            var num = new NumericUpDown {Minimum = 0m, Maximum = 1000m, Value = Default};
            num.ValueChanged += num_ValueChanged;
            num.DecimalPlaces = 6;
            return num;
        }

        private void num_ValueChanged(object sender, EventArgs e)
        {
            ((NumericUpDown)sender).Value = Convert.ToDecimal(((NumericUpDown)sender).Text);
        }

        private void Save()
        {
            if (Public.LanguageQuestionBox("Are you sure you want to save ?", "Êtes-vous sûr de vouloir sauvegarder ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (Query.Execute(GetSaveQueryString()))
                {
                    UpdateTableVersions();
                    Public.LanguageBox("Saving completed", "Sauvegarde complétée");
                }
                else
                {
                    Public.LanguageBox("An error occured while saving", "Une erreur est survenue lors de la sauvegarde");
                }
            }
            else
            {
                Public.LanguageBox("Saving canceled", "Sauvegarde annulée");
            }
        }

        private void UpdateTableVersions()
        {
            Query.UpdateServerTableVersion("PricingReturnBendCost");
        }

        private string GetSaveQueryString()
        {
            string tsql = "";

            for (int i = 0; i < lvReturnBendCost.Items.Count; i++)
            {
                string finType = lvReturnBendCost.Items[i].SubItems[0].Text;
                decimal returnBendCost = ((NumericUpDown)lvReturnBendCost.Items[i].SubItems[1].Control).Value;

                tsql += " UPDATE PricingReturnBendCost SET ReturnBendCost = " + returnBendCost + " WHERE FinType = '" + finType + "'";
            }

            return tsql;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmPricingReturnBendCost_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }
    }
}