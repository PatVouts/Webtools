using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Pricing
{
    public partial class FrmHeresiteSafety : Form
    {
        public FrmHeresiteSafety()
        {
            InitializeComponent();
        }

        private void frmHeresiteSafety_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            Fill_Data();
        }

        //auto-select content of numerical up and down on tab
        private void AutoSelectOnTab(object sender, EventArgs e)
        {
            //numerical up and down do not select text by default when we tab
            //or clik in the control. This code make him do it
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
        }

        private void Fill_Data()
        {
            DataTable dtHeresiteSafety = Query.Select("SELECT * FROM HeresiteSafety");

            numBathHeight.Value = Convert.ToDecimal(dtHeresiteSafety.Rows[0]["BathHeight"]);
            numHeightSafety.Value = Convert.ToDecimal(dtHeresiteSafety.Rows[0]["HeightSafety"]);
            numBathLength.Value = Convert.ToDecimal(dtHeresiteSafety.Rows[0]["BathLength"]);
            numLengthSafety.Value = Convert.ToDecimal(dtHeresiteSafety.Rows[0]["LengthSafety"]);
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
            Query.UpdateServerTableVersion("HeresiteSafety");
        }

        private string GetSaveQueryString()
        {
            string tsql = @"UPDATE HeresiteSafety
                    SET [BathHeight] = " + numBathHeight.Value + @"
                        ,[HeightSafety] = " + numHeightSafety.Value + @"
                        ,[BathLength] = " + numBathLength.Value + @"
                        ,[LengthSafety] = " + numLengthSafety.Value;

            return tsql;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmHeresiteSafety_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }
    }
}