using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Pricing
{
    public partial class FrmPricingCoilHeader : Form
    {
        public FrmPricingCoilHeader()
        {
            InitializeComponent();
        }

        private void frmPricingCoilHeader_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            Fill_CoilHeader();
        }

        private void Fill_CoilHeader()
        {
            lvCoilHeader.Items.Clear();

            DataTable dtCoilHeader = Query.Select("SELECT * FROM PricingCoilHeader ORDEr BY HeaderDiameter");

            foreach (DataRow dr in dtCoilHeader.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvCoilHeader);

                myItem.SubItems[0].Text = dr["HeaderDiameter"].ToString();
                myItem.SubItems[1].Control = GetNumericUpDown(Convert.ToDecimal(dr["HeaderThickness"]));
                myItem.SubItems[2].Control = GetNumericUpDown(Convert.ToDecimal(dr["CostPerFoot"]));

                lvCoilHeader.Items.Add(myItem);
            }

            lvCoilHeader.Refresh();
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
            Query.UpdateServerTableVersion("PricingCoilHeader");
        }

        private string GetSaveQueryString()
        {
            string tsql = "";

            for (int i = 0; i < lvCoilHeader.Items.Count; i++)
            {
                decimal headerDiameter = Convert.ToDecimal(lvCoilHeader.Items[i].SubItems[0].Text);
                decimal headerThickness = ((NumericUpDown)lvCoilHeader.Items[i].SubItems[1].Control).Value;
                decimal costPerFoot = ((NumericUpDown)lvCoilHeader.Items[i].SubItems[2].Control).Value;

                tsql += " UPDATE PricingCoilHeader SET HeaderThickness = " + headerThickness + ", CostPerFoot = " + costPerFoot + " WHERE HeaderDiameter = " + headerDiameter;
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

        private void frmPricingCoilHeader_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }
    }
}