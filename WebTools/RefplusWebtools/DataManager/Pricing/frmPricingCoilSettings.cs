using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Pricing
{
    public partial class FrmPricingCoilSettings : Form
    {
        public FrmPricingCoilSettings()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPricingCoilSettings_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            Fill_Data();
        }

        private void AutoSelectTextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
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
            DataTable dtPricingCoilSetting = Query.Select("SELECT * FROM PricingCoilSetting");

            numCrossOverQty.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["CrossOverQty"]);
            numCrossOverPrice.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["CrossOverPrice"]);
            numEndPlateQty.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["EndPlateQty"]);
            numTopBottomPlatesQty.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["TopBottomPlatesQty"]);
            numCopperHeaderQty.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["CopperHeaderQty"]);
            numSecondCopperHeaderQty.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["SecondCopperHeaderQty"]);
            numSecondCopperHeaderDiam.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["SecondCopperHeaderDiam"]);
            numRedBrassConnQty.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["RedBrassConnQty"]);
            numRedBrassConnPrice.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["RedBrassConnPrice"]);
            numVentQty.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["VentQty"]);
            numVentLen.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["VentLen"]);
            numSpigotLen.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["SpigotLen"]);
            numDistributorQty.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["DistributorQty"]);
            numDistributorPrice.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["DistributorPrice"]);
            numDistributorLineQty.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["DistributorLineQty"]);
            numDistributorLineLen.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["DistributorLineLen"]);
            numDistributorLineDiam.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["DistributorLineDiam"]);
            numAuxSideQty.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["AuxSideQty"]);
            numAuxSidePrice.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["AuxSidePrice"]);
            numFittingQty.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["FittingQty"]);
            numFittingPrice.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["FittingPrice"]);
            numCrating.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["Crating"]);
            numScrap.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["Scrap"]);
            numProfit.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["Profit"]);
            numBrokerage.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["Brokerage"]);
            numExchange.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["Exchange"]);
            txtSetUp.Text = dtPricingCoilSetting.Rows[0]["SetUp"].ToString();
            numLaborCorr.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["LaborCorr"]);
            chkVertExpan.Checked = (Convert.ToInt32(dtPricingCoilSetting.Rows[0]["VertExpan"]) != 0);
            chkWelding.Checked = (Convert.ToInt32(dtPricingCoilSetting.Rows[0]["Welding"]) != 0);
            numMiscLaborMargin.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["MiscLaborMargin"]);
            numLaborSalary.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["LaborSalary"]);
            numBurden.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["Burden"]);
            numListPriceMult.Value = Convert.ToDecimal(dtPricingCoilSetting.Rows[0]["ListPriceMult"]);
        
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
            Query.UpdateServerTableVersion("PricingCoilSetting");
        }

        private string GetSaveQueryString()
        {
            string tsql = @"UPDATE PricingCoilSetting
                    SET [CrossOverQty] = " + numCrossOverQty.Value + @"
                        ,[CrossOverPrice] = " + numCrossOverPrice.Value + @"
                        ,[EndPlateQty] = " + numEndPlateQty.Value + @"
                        ,[TopBottomPlatesQty] = " + numTopBottomPlatesQty.Value + @"
                        ,[CopperHeaderQty] = " + numCopperHeaderQty.Value + @"
                        ,[SecondCopperHeaderQty] = " + numSecondCopperHeaderQty.Value + @"
                        ,[SecondCopperHeaderDiam] = " + numSecondCopperHeaderDiam.Value + @"
                        ,[RedBrassConnQty] = " + numRedBrassConnQty.Value + @"
                        ,[RedBrassConnPrice] = " + numRedBrassConnPrice.Value + @"
                        ,[VentQty] = " + numVentQty.Value + @"
                        ,[VentLen] = " + numVentLen.Value + @"
                        ,[SpigotLen] = " + numSpigotLen.Value + @"
                        ,[DistributorQty] = " + numDistributorQty.Value + @"
                        ,[DistributorPrice] = " + numDistributorPrice.Value + @"
                        ,[DistributorLineQty] = " + numDistributorLineQty.Value + @"
                        ,[DistributorLineLen] = " + numDistributorLineLen.Value + @"
                        ,[DistributorLineDiam] = " + numDistributorLineDiam.Value + @"
                        ,[AuxSideQty] = " + numAuxSideQty.Value + @"
                        ,[AuxSidePrice] = " + numAuxSidePrice.Value + @"
                        ,[FittingQty] = " + numFittingQty.Value + @"
                        ,[FittingPrice] = " + numFittingPrice.Value + @"
                        ,[Crating] = " + numCrating.Value + @"
                        ,[Scrap] = " + numScrap.Value + @"
                        ,[Profit] = " + numProfit.Value + @"
                        ,[Brokerage] = " + numBrokerage.Value + @"
                        ,[Exchange] = " + numExchange.Value + @"
                        ,[SetUp] = '" + txtSetUp.Text.Replace("'","") + @"'
                        ,[LaborCorr] = " + numLaborCorr.Value + @"
                        ,[VertExpan] = " + (chkVertExpan.Checked ? "1" : "0") + @"
                        ,[Welding] = " + (chkWelding.Checked ? "1" : "0") + @"
                        ,[MiscLaborMargin] = " + numMiscLaborMargin.Value + @"
                        ,[LaborSalary] = " + numLaborSalary.Value + @"
                        ,[Burden] = " + numBurden.Value + @"
                        ,[ListPriceMult] = " + numListPriceMult.Value;

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

        private void frmPricingCoilSettings_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }
    }
}