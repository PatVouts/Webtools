using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Pricing
{
    public partial class FrmFinMaterialDensityPrices : Form
    {
        public FrmFinMaterialDensityPrices()
        {
            InitializeComponent();
        }

        private void frmFinMaterialDensityPrices_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            Fill_Material();
        }

        private void Fill_Material()
        {
            lvFinMaterial.Items.Clear();

            DataTable dtFinMaterial = Query.Select("SELECT * FROM CoilFinMaterial");

            foreach (DataRow dr in dtFinMaterial.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvFinMaterial);

                myItem.SubItems[0].Text = dr["UniqueID"].ToString();
                myItem.SubItems[1].Text = dr["FinMaterial"].ToString();
                myItem.SubItems[2].Control = GetNumericUpDown(Convert.ToDecimal(dr["MaterialDensity"]));
                myItem.SubItems[3].Control = GetNumericUpDown(Convert.ToDecimal(dr["PricePerLbs"]));

                lvFinMaterial.Items.Add(myItem);
            }

            lvFinMaterial.Refresh();
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
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
                    Public.LanguageBox("Saving completed", "Sauvegarde completée");
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
            Query.UpdateServerTableVersion("CoilFinMaterial");
        }

        private string GetSaveQueryString()
        {
            string tsql = "";

            for (int i = 0; i < lvFinMaterial.Items.Count; i++)
            {
                string uniqueID = lvFinMaterial.Items[i].SubItems[0].Text;
                //no index 1 sicne it's simply the material text value
                decimal density = ((NumericUpDown)lvFinMaterial.Items[i].SubItems[2].Control).Value;
                decimal price = ((NumericUpDown)lvFinMaterial.Items[i].SubItems[3].Control).Value;

                tsql += " UPDATE CoilFinMaterial SET MaterialDensity = " + density + ", PricePerLbs = " + price + " WHERE UniqueID = " + uniqueID;
            }

            return tsql;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmFinMaterialDensityPrices_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }
    }
}