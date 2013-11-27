using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Pricing
{
    public partial class FrmPricingMadocRate : Form
    {
        public FrmPricingMadocRate()
        {
            InitializeComponent();
        }

        private void frmPricingMadocRate_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            Fill_MadocRate();
        }

        private void Fill_MadocRate()
        {
            lvMadocRate.Items.Clear();

            DataTable dtPricingMadocRate = Query.Select("SELECT * FROM PricingMadocRate ORDEr BY Row");

            foreach (DataRow dr in dtPricingMadocRate.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvMadocRate);

                myItem.SubItems[0].Text = dr["Row"].ToString();
                myItem.SubItems[1].Control = GetNumericUpDown(Convert.ToDecimal(dr["Price"]));

                lvMadocRate.Items.Add(myItem);
            }

            lvMadocRate.Refresh();
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
            Query.UpdateServerTableVersion("PricingMadocRate");
        }

        private string GetSaveQueryString()
        {
            string tsql = "";

            for (int i = 0; i < lvMadocRate.Items.Count; i++)
            {
                decimal row = Convert.ToDecimal(lvMadocRate.Items[i].SubItems[0].Text);
                decimal price = ((NumericUpDown)lvMadocRate.Items[i].SubItems[1].Control).Value;

                tsql += " UPDATE PricingMadocRate SET Price = " + price + " WHERE Row = " + row;
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

        private void frmPricingMadocRate_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }

    }
}