using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.OEMCoil
{
    public partial class FrmOEMCoilHeaderInformation : Form
    {
        public FrmOEMCoilHeaderInformation()
        {
            InitializeComponent();
        }

        private void frmOEMCoilHeaderInformation_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            Fill_HeaderInformation();
        }

        private void Fill_HeaderInformation()
        {
            lvHeaderInformation.Items.Clear();

            DataTable dtHeaderInformation = Query.Select("SELECT * FROM HeaderInformation ORDER BY CopperHeaderDiameter");

            foreach (DataRow dr in dtHeaderInformation.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvHeaderInformation);

                myItem.SubItems[0].Text = dr["CopperHeaderDiameter"].ToString();
                myItem.SubItems[1].Control = GetNumericUpDown(Convert.ToDecimal(dr["CopperHeaderThickness"]));
                myItem.SubItems[2].Control = GetNumericUpDown(Convert.ToDecimal(dr["CostPerFoot"]));
                myItem.SubItems[3].Control = GetNumericUpDown(Convert.ToDecimal(dr["TCCOST"]));
                myItem.SubItems[4].Control = GetNumericUpDown(Convert.ToDecimal(dr["LBSft"]));
                myItem.SubItems[5].Control = GetNumericUpDown(Convert.ToDecimal(dr["StainlessSteelCostPerFoot"]));

                lvHeaderInformation.Items.Add(myItem);
            }

            lvHeaderInformation.Refresh();
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
            Query.UpdateServerTableVersion("HeaderInformation");
        }

        private string GetSaveQueryString()
        {
            string tsql = "";

            for (int i = 0; i < lvHeaderInformation.Items.Count; i++)
            {
                decimal diameter = Convert.ToDecimal(lvHeaderInformation.Items[i].SubItems[0].Text);
                decimal thick = ((NumericUpDown)lvHeaderInformation.Items[i].SubItems[1].Control).Value;
                decimal costperfoot = ((NumericUpDown)lvHeaderInformation.Items[i].SubItems[2].Control).Value;
                decimal tccost = ((NumericUpDown)lvHeaderInformation.Items[i].SubItems[3].Control).Value;
                decimal lbsft = ((NumericUpDown)lvHeaderInformation.Items[i].SubItems[4].Control).Value;
                decimal ststeelcostperfoot = ((NumericUpDown)lvHeaderInformation.Items[i].SubItems[5].Control).Value;

                tsql += " UPDATE HeaderInformation SET CopperHeaderThickness = " + thick + ", CostPerFoot = " + costperfoot + ", TCCOST = " + tccost + ", LBSft = " + lbsft + ", StainlessSteelCostPerFoot = " + ststeelcostperfoot + " WHERE CopperHeaderDiameter = " + diameter;
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

        private void frmOEMCoilHeaderInformation_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }
    }
}