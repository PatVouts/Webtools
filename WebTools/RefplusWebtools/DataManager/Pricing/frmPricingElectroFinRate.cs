using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Pricing
{
    public partial class FrmPricingElectroFinRate : Form
    {
        public FrmPricingElectroFinRate()
        {
            InitializeComponent();
        }

        private void frmPricingElectroFinRate_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            Fill_ElectroRate();
        }

        private void Fill_ElectroRate()
        {
            lvElectroRate.Items.Clear();

            DataTable dtPricingElectroFinRate = Query.Select("SELECT * FROM PricingElectroFinRate ORDER BY Row, FPI");

            foreach (DataRow dr in dtPricingElectroFinRate.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvElectroRate);

                myItem.SubItems[0].Text = dr["Row"].ToString();
                myItem.SubItems[1].Text = dr["FPI"].ToString();
                myItem.SubItems[2].Control = GetNumericUpDown(Convert.ToDecimal(dr["Rate"]));
                myItem.SubItems[3].Control = GetNumericUpDown(Convert.ToDecimal(dr["Min"]));

                lvElectroRate.Items.Add(myItem);
            }

            lvElectroRate.Refresh();
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
            Query.UpdateServerTableVersion("PricingElectroFinRate");
        }

        private string GetSaveQueryString()
        {
            string tsql = "";

            for (int i = 0; i < lvElectroRate.Items.Count; i++)
            {
                decimal row = Convert.ToDecimal(lvElectroRate.Items[i].SubItems[0].Text);
                decimal fpi = Convert.ToDecimal(lvElectroRate.Items[i].SubItems[1].Text);
                decimal rate = ((NumericUpDown)lvElectroRate.Items[i].SubItems[2].Control).Value;
                decimal min = ((NumericUpDown)lvElectroRate.Items[i].SubItems[3].Control).Value;

                tsql += " UPDATE PricingElectroFinRate SET Rate = " + rate + ", Min = " + min + " WHERE Row = " + row + " AND FPI = " + fpi;
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

        private void frmPricingElectroFinRate_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }


    }
}