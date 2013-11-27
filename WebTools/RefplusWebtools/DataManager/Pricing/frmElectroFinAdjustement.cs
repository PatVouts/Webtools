using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Pricing
{
    public partial class FrmElectroFinAdjustement : Form
    {
        public FrmElectroFinAdjustement()
        {
            InitializeComponent();
        }

        private void frmElectroFinAdjustement_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            Fill_ElectroAdjustement();
        }

        private void Fill_ElectroAdjustement()
        {
            lvElectroAdjustement.Items.Clear();

            DataTable dtElectroFinAdjustement = Query.Select("SELECT * FROM ElectroFinAdjustement ORDER BY Rows, FPI");

            foreach (DataRow dr in dtElectroFinAdjustement.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvElectroAdjustement);

                myItem.SubItems[0].Text = dr["UniqueID"].ToString();
                myItem.SubItems[1].Text = dr["Rows"].ToString();
                myItem.SubItems[2].Text = dr["FPI"].ToString();
                myItem.SubItems[3].Control = GetNumericUpDown(Convert.ToDecimal(dr["ElectroRate"]));
                myItem.SubItems[4].Control = GetNumericUpDown(Convert.ToDecimal(dr["Min"]));

                lvElectroAdjustement.Items.Add(myItem);
            }

            lvElectroAdjustement.Refresh();
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
            Query.UpdateServerTableVersion("ElectroFinAdjustement");
        }

        private string GetSaveQueryString()
        {
            string tsql = "";

            for (int i = 0; i < lvElectroAdjustement.Items.Count; i++)
            {
                decimal id = Convert.ToDecimal(lvElectroAdjustement.Items[i].SubItems[0].Text);
                decimal rate = ((NumericUpDown)lvElectroAdjustement.Items[i].SubItems[3].Control).Value;
                decimal min = ((NumericUpDown)lvElectroAdjustement.Items[i].SubItems[4].Control).Value;

                tsql += " UPDATE ElectroFinAdjustement SET ElectroRate = " + rate + ", Min = " + min + " WHERE UniqueID = " + id;
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

        private void frmElectroFinAdjustement_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }

    }
}