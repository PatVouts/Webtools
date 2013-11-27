using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Pricing
{
    public partial class FrmPricingCoilBlygold : Form
    {
        public FrmPricingCoilBlygold()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCoilBlygold_Load(object sender, EventArgs e)
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
            DataTable dtPricingCoilBlyGold = Query.Select("SELECT * FROM PricingCoilBlyGold");

            numPolualCost.Value = Convert.ToDecimal(dtPricingCoilBlyGold.Rows[0]["PolualCosts"]);
            numPolualCoverage.Value = Convert.ToDecimal(dtPricingCoilBlyGold.Rows[0]["PolualCoverage"]);
            numPretreatmentCosts.Value = Convert.ToDecimal(dtPricingCoilBlyGold.Rows[0]["PreTreatmentCosts"]);
            numPretreatmentCoverage.Value = Convert.ToDecimal(dtPricingCoilBlyGold.Rows[0]["PreTreatmentCoverage"]);
            numSafeCost.Value = Convert.ToDecimal(dtPricingCoilBlyGold.Rows[0]["SafeCosts"]);
            numSafeCoverage.Value = Convert.ToDecimal(dtPricingCoilBlyGold.Rows[0]["SafeCoverage"]);
            numLaborCost.Value = Convert.ToDecimal(dtPricingCoilBlyGold.Rows[0]["LaborCost"]);
            numFacedAreaOutput.Value = Convert.ToDecimal(dtPricingCoilBlyGold.Rows[0]["FacedAreaOutput"]);
            numUSD.Value = Convert.ToDecimal(dtPricingCoilBlyGold.Rows[0]["USD"]);
            numExchange.Value = Convert.ToDecimal(dtPricingCoilBlyGold.Rows[0]["Exchange"]);
            numSundry.Value = Convert.ToDecimal(dtPricingCoilBlyGold.Rows[0]["Sundry"]);
            numReturnBends.Value = Convert.ToDecimal(dtPricingCoilBlyGold.Rows[0]["ReturnBends"]);
            numTransportProducts.Value = Convert.ToDecimal(dtPricingCoilBlyGold.Rows[0]["TransportProducts"]);
            
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
            Query.UpdateServerTableVersion("PricingCoilBlyGold");
        }

        private string GetSaveQueryString()
        {
            string tsql = @"UPDATE PricingCoilBlyGold
                     SET [PolualCosts] = " + numPolualCost.Value + @"
                         ,[PolualCoverage] = " + numPolualCoverage.Value + @"
                         ,[PreTreatmentCosts] =" + numPretreatmentCosts.Value + @"
                         ,[PreTreatmentCoverage] = " + numPretreatmentCoverage.Value + @"
                         ,[SafeCosts] = " + numSafeCost.Value + @"
                         ,[SafeCoverage] = " + numSafeCoverage.Value + @"
                         ,[LaborCost] = " + numLaborCost.Value + @"
                         ,[FacedAreaOutput] = " + numFacedAreaOutput.Value + @"
                         ,[USD] = " + numUSD.Value + @"
                         ,[Exchange] = " + numExchange.Value + @"
                         ,[Sundry] = " + numSundry.Value + @"
                         ,[ReturnBends] = " + numReturnBends.Value + @"
                         ,[TransportProducts] = " + numTransportProducts.Value;

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

        private void frmPricingCoilBlygold_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }
    }
}