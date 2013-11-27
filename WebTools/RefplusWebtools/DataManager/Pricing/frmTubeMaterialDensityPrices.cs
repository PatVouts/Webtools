using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Pricing
{
    public partial class FrmTubeMaterialDensityPrices : Form
    {
        public FrmTubeMaterialDensityPrices()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmTubeMaterialDensityPrices_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            Fill_Material();
        }

        private void Fill_Material()
        {
            lvTubeMaterial.Items.Clear();

            DataTable dtMaterial = Query.Select("SELECT * FROM CoilTubeMaterial");

            foreach (DataRow dr in dtMaterial.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvTubeMaterial);

                myItem.SubItems[0].Text = dr["UniqueID"].ToString();
                myItem.SubItems[1].Text = dr["TubeMaterial"].ToString();
                myItem.SubItems[2].Control = GetNumericUpDown(Convert.ToDecimal(dr["MaterialDensity"]));
                myItem.SubItems[3].Control = GetNumericUpDown(Convert.ToDecimal(dr["PricePerLbs"]));

                lvTubeMaterial.Items.Add(myItem);
            }

            lvTubeMaterial.Refresh();
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

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Save();
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
            Query.UpdateServerTableVersion("CoilTubeMaterial");
        }

        private string GetSaveQueryString()
        {
            string tsql = "";

            for (int i = 0; i < lvTubeMaterial.Items.Count; i++)
            {
                string uniqueID = lvTubeMaterial.Items[i].SubItems[0].Text;
                //no index 1 sicne it's simply the material text value
                decimal density = ((NumericUpDown)lvTubeMaterial.Items[i].SubItems[2].Control).Value;
                decimal price = ((NumericUpDown)lvTubeMaterial.Items[i].SubItems[3].Control).Value;

                tsql += " UPDATE CoilTubeMaterial SET MaterialDensity = " + density + ", PricePerLbs = " + price + " WHERE UniqueID = " + uniqueID;
            }

            return tsql;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmTubeMaterialDensityPrices_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }
    }
}