using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.OEMCoil
{
    public partial class FrmOEMCoilMaterialInformation : Form
    {
        public FrmOEMCoilMaterialInformation()
        {
            InitializeComponent();
        }

        private void frmOEMCoilMaterialInformation_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            Fill_MaterialInformation();
        }

        private void Fill_MaterialInformation()
        {
            lvMaterialInfo.Items.Clear();

            DataTable dtMaterialInformation = Query.Select("SELECT * FROM MaterialInformation ORDER BY CoilFinMaterial");

            foreach (DataRow dr in dtMaterialInformation.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvMaterialInfo);

                myItem.SubItems[0].Text = dr["CoilFinMaterial"].ToString();
                myItem.SubItems[1].Control = GetNumericUpDown(Convert.ToDecimal(dr["MaterialDensity"]));
                myItem.SubItems[2].Control = GetNumericUpDown(Convert.ToDecimal(dr["FinCostPerLbs"]));
                myItem.SubItems[3].Control = GetNumericUpDown(Convert.ToDecimal(dr["CasingCostPerLbs"]));
                myItem.SubItems[4].Control = GetNumericUpDown(Convert.ToDecimal(dr["TubeCostPerLbs"]));
                myItem.SubItems[5].Control = GetNumericUpDown(Convert.ToDecimal(dr["DrainPanCostPerLbs"]));

                lvMaterialInfo.Items.Add(myItem);
            }

            lvMaterialInfo.Refresh();
        }

        private NumericUpDown GetNumericUpDown(decimal Default)
        {
            var num = new NumericUpDown {Minimum = -1000m, Maximum = 1000m, Value = Default, DecimalPlaces = 6};
            num.ValueChanged += num_ValueChanged;           
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
            Query.UpdateServerTableVersion("MaterialInformation");
        }

        private string GetSaveQueryString()
        {
            string tsql = "";

            for (int i = 0; i < lvMaterialInfo.Items.Count; i++)
            {
                string material = lvMaterialInfo.Items[i].SubItems[0].Text;
                decimal density = ((NumericUpDown)lvMaterialInfo.Items[i].SubItems[1].Control).Value;
                decimal fincost = ((NumericUpDown)lvMaterialInfo.Items[i].SubItems[2].Control).Value;
                decimal casingcost = ((NumericUpDown)lvMaterialInfo.Items[i].SubItems[3].Control).Value;
                decimal tubecost = ((NumericUpDown)lvMaterialInfo.Items[i].SubItems[4].Control).Value;
                decimal draincost = ((NumericUpDown)lvMaterialInfo.Items[i].SubItems[5].Control).Value;

                tsql += " UPDATE MaterialInformation SET MaterialDensity = " + density + ", FinCostPerLbs = " + fincost + ", CasingCostPerLbs = " + casingcost + ", TubeCostPerLbs = " + tubecost + ", DrainPanCostPerLbs = " + draincost + " WHERE CoilFinMaterial = '" + material + "'";
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

        private void frmOEMCoilMaterialInformation_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }
    }
}