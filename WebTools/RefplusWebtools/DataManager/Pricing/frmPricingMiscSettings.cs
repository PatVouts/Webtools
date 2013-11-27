using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Pricing
{
    public partial class FrmPricingMiscSettings : Form
    {
        public FrmPricingMiscSettings()
        {
            InitializeComponent();
        }

        private void frmPricingMiscSettings_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            Fill_MiscSettings();
        }

        private void Fill_MiscSettings()
        {
            lvMiscSettings.Items.Clear();

            DataTable dtPricingMISCSETTING = Query.Select("SELECT * FROM PricingMISCSETTING ORDEr BY ID");

            foreach (DataRow dr in dtPricingMISCSETTING.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvMiscSettings);

                myItem.SubItems[0].Text = dr["ID"].ToString();
                myItem.SubItems[1].Text = dr["MISCDESC"].ToString();
                myItem.SubItems[2].Control = GetNumericUpDown(Convert.ToDecimal(dr["Price"]));

                lvMiscSettings.Items.Add(myItem);
            }

            lvMiscSettings.Refresh();
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
            Query.UpdateServerTableVersion("PricingMISCSETTING");
        }

        private string GetSaveQueryString()
        {
            string tsql = "";

            for (int i = 0; i < lvMiscSettings.Items.Count; i++)
            {
                decimal id = Convert.ToDecimal(lvMiscSettings.Items[i].SubItems[0].Text);
                decimal price = ((NumericUpDown)lvMiscSettings.Items[i].SubItems[2].Control).Value;

                tsql += " UPDATE PricingMISCSETTING SET Price = " + price + " WHERE ID = " + id;
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

        private void frmPricingMiscSettings_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }
    }
}