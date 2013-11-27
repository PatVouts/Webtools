using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Condenser
{
    public partial class FrmCondenserManager : Form
    {
        //list of tables
        private readonly string[] _strTableList = { "CondenserFanArrangement", "CondenserType", "CondenserSerie", "AirFlowType" };

        public FrmCondenserManager()
        {
            InitializeComponent();
        }

        private void frmCondenserManager_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            Query.LoadTables(_strTableList);

            //fill all the combobox
            Fill_Combobox();
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

        private void Fill_Combobox()
        {
            Fill_TypeOfCondenser();
            Fill_CondenserSerie();
            Fill_FanArrangement();
            Fill_ListOfModel();
        }

        private void Fill_ListOfModel()
        {
            cboCondenserModel.Items.Clear();

            DataTable dtModelList = Query.Select("SELECT * FROM CondenserXref ORDER BY refplus_condenserxrefmodel, Dectron_condenserxrefmodel, ecosaire_condenserxrefmodel, circulaire_condenserxrefmodel");
            ComboBoxControl.AddItem(
                cboCondenserModel,
                "TITLE",
                "REF".PadRight(9, ' ') + " - " +
                "DECT".PadRight(9, ' ') + " - " +
                "CIRC".PadRight(9, ' ') + " - " +
                "ECO");


            foreach (DataRow dr in dtModelList.Rows)
            {
                ComboBoxControl.AddItem(
                    cboCondenserModel,
                    dr["CondenserType"]
                    + "," + dr["Motor"]
                    + "," + dr["CoilArr"]
                    + "," + dr["FanWide"]
                    + "," + dr["FanLong"]
                    + "," + dr["Row"]
                    + "," + dr["Fpi"]
                    + "," + dr["AirFlow"],
                    dr["REFPLUS_CondenserXrefModel"].ToString().PadRight(9,' ') + " - " +
                    dr["DECTRON_CondenserXrefModel"].ToString().PadRight(9, ' ') + " - " +
                    dr["CIRCULAIRE_CondenserXrefModel"].ToString().PadRight(9, ' ') + " - " +
                    dr["ECOSAIRE_CondenserXrefModel"]);
            }

            cboCondenserModel.SelectedIndex = 0;
        }

        //this return the condenser type parameter
        private string TypeOfCondenserParameter()
        {
            return ComboBoxControl.ItemInformations(cboTypeOfCondenser, Public.DSDatabase.Tables["CondenserType"], "UniqueID")[0]["CondenserTypeParameter"].ToString();
        }

        //fill type of condenser
        private void Fill_TypeOfCondenser()
        {
            cboTypeOfCondenser.Items.Clear();

            //for each type of condenser
            foreach (DataRow drTypeOfCondenser in Public.DSDatabase.Tables["CondenserType"].Rows)
            {
                string strIndex = drTypeOfCondenser["UniqueID"].ToString();
                string strText = drTypeOfCondenser["CondenserType"].ToString();
                ComboBoxControl.AddItem(cboTypeOfCondenser, strIndex, strText);
            }
        }
 
        private string FanWide()
        {
            return ComboBoxControl.ItemInformations(cboFanArrangement, Public.DSDatabase.Tables["CondenserFanArrangement"], "UniqueID")[0]["FanWide"].ToString();
        }

        private string FanLong()
        {
            return ComboBoxControl.ItemInformations(cboFanArrangement, Public.DSDatabase.Tables["CondenserFanArrangement"], "UniqueID")[0]["FanLong"].ToString();
        }

        //fill fan arrangement
        private void Fill_FanArrangement()
        {
            cboFanArrangement.Items.Clear();
            

            //for each fan arangement
            foreach (DataRow drFanArrangement in Public.DSDatabase.Tables["CondenserFanArrangement"].Rows)
            {
                string strIndex = drFanArrangement["UniqueID"].ToString();
                string strText = drFanArrangement["FanArrangement"].ToString();
                ComboBoxControl.AddItem(cboFanArrangement, strIndex, strText);
            }
        }

        private string Motor()
        {
            return ComboBoxControl.IndexInformation(cboCondenserSerie).Substring(0, 1);
        }

        private string CoilArr()
        {
            return ComboBoxControl.IndexInformation(cboCondenserSerie).Substring(1, 1);
        }

        private void Fill_CondenserSerie()
        {
            cboCondenserSerie.Items.Clear();


            //clean the inactive record
            DataTable dtClearedCondenserSerie = Public.DSDatabase.Tables["CondenserSerie"];

            //loop through all conenser serie
            foreach (DataRow drCondenserSerie in dtClearedCondenserSerie.Rows)
            {
                string strIndex = drCondenserSerie["Motor"] + drCondenserSerie["CoilArr"].ToString();
                string strText = drCondenserSerie["Motor"].ToString().Replace("S", "V") + drCondenserSerie["CoilArr"] + " - " + drCondenserSerie["Description"];
                ComboBoxControl.AddItem(cboCondenserSerie, strIndex, strText);
            }
        }

        private void cboCondenserSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void cmdLoadModel_Click(object sender, EventArgs e)
        {
            LoadCondenser();
        }

        private void LoadCondenser()
        {
            //greater than 0 that's because 0 actually contain data
            //for the header so it's no loadable. first real model show index 1 (second item)
            if (cboCondenserModel.SelectedIndex > 0)
            {
                //get the model selected parameter and split to retreive them
                string[] strModelInfo = ComboBoxControl.IndexInformation(cboCondenserModel).Split(',');

                //store them idividually for better readability and use
                string condenserType = strModelInfo[0];
                string motor = strModelInfo[1];
                string coilArr = strModelInfo[2];
                string fanWide = strModelInfo[3];
                string fanLong = strModelInfo[4];
                string row = strModelInfo[5];
                string fpi = strModelInfo[6];

                //get data of the condensermodel and xref table. both will be used to load the data.
                DataTable dtCondenserXrefData = Query.Select("SELECT * FROM CondenserXref WHERE CondenserType = '" + condenserType + "' AND Motor = '" + motor + "' AND CoilArr = '" + coilArr + "' AND FanWide = " + fanWide + " AND FanLong = " + fanLong + " AND Row = " + row + " AND FPI = " + fpi);
                DataTable dtCondenserModelData = Query.Select("SELECT * FROM CondenserModel WHERE CondenserType = '" + condenserType + "' AND Motor = '" + motor + "' AND CoilArr = '" + coilArr + "' AND FanWide = " + fanWide + " AND FanLong = " + fanLong + " AND Row = " + row + " AND FPI = " + fpi);

                ComboBoxControl.SetIDDefaultValue(cboTypeOfCondenser, Public.SelectAndSortTable(Public.DSDatabase.Tables["CondenserType"], "CondenserTypeParameter = '" + condenserType + "'", "").Rows[0]["UniqueID"].ToString());
                
                ComboBoxControl.SetIDDefaultValue(cboCondenserSerie, dtCondenserModelData.Rows[0]["Motor"] + dtCondenserModelData.Rows[0]["CoilArr"].ToString());

                ComboBoxControl.SetIDDefaultValue(cboFanArrangement, Public.SelectAndSortTable(Public.DSDatabase.Tables["CondenserFanArrangement"], "FanWide = " + fanWide + " AND FanLong = " + fanLong, "").Rows[0]["UniqueID"].ToString());

                bool horizontalAvailable = false;
                bool verticalAvailable = false;

                for (int i = 0; i < dtCondenserXrefData.Rows.Count; i++)
                {
                    if (dtCondenserXrefData.Rows[i]["AirFlow"].ToString() == "H")
                    {
                        horizontalAvailable = true;
                    }

                    if (dtCondenserXrefData.Rows[i]["AirFlow"].ToString() == "V")
                    {
                        verticalAvailable = true;
                    }
                }

                chkHorizontal.Checked = horizontalAvailable;
                chkVertical.Checked = verticalAvailable;

                txtFinType.Text = dtCondenserModelData.Rows[0]["FinType"].ToString();

                numFinHeight.Value = Convert.ToDecimal(dtCondenserModelData.Rows[0]["FinHeight"]);

                numFinLength.Value = Convert.ToDecimal(dtCondenserModelData.Rows[0]["FinLength"]);

                numRow.Value = Convert.ToDecimal(dtCondenserModelData.Rows[0]["Row"]);

                numFPI.Value = Convert.ToDecimal(dtCondenserModelData.Rows[0]["FPI"]);

                txtCoilModel.Text = dtCondenserXrefData.Rows[0]["CoilModel"].ToString();

                numCondenserCircQty.Value = Convert.ToDecimal(dtCondenserModelData.Rows[0]["CondenserCircQty"]);

                numCapacity_Per_Circuit.Value = Convert.ToDecimal(dtCondenserModelData.Rows[0]["Capacity_per_Circuit"]);

                numTHR_at_1F.Value = Convert.ToDecimal(dtCondenserModelData.Rows[0]["THR_at_1F"]);

                numDischarge.Value = Convert.ToDecimal(dtCondenserModelData.Rows[0]["ConnDischarge"]);

                numLiquid.Value = Convert.ToDecimal(dtCondenserModelData.Rows[0]["ConnLiquid"]);

                numConnQty.Value = Convert.ToDecimal(dtCondenserModelData.Rows[0]["ConnQty"]);

                numRefSummerCharge.Value = Convert.ToDecimal(dtCondenserModelData.Rows[0]["RefChargeSummer"]);

                numRefWinterCharge.Value = Convert.ToDecimal(dtCondenserModelData.Rows[0]["RefChargeWinter"]);

                numWeight.Value = Convert.ToDecimal(dtCondenserModelData.Rows[0]["ShipWeight"]);

                numPrice.Value = Convert.ToDecimal(dtCondenserXrefData.Rows[0]["Price"]);

                chkActive.Checked = (Convert.ToInt32(dtCondenserModelData.Rows[0]["Active"]) == 1);

                txtModelREF.Text = GetParseModelWithoutAirflowNomenclature(dtCondenserXrefData.Rows[0]["REFPLUS_CondenserXrefModel"].ToString());

                txtModelDECT.Text = GetParseModelWithoutAirflowNomenclature(dtCondenserXrefData.Rows[0]["DECTRON_CondenserXrefModel"].ToString());

                txtModelCIRC.Text = GetParseModelWithoutAirflowNomenclature(dtCondenserXrefData.Rows[0]["CIRCULAIRE_CondenserXrefModel"].ToString());

                txtModelECO.Text = GetParseModelWithoutAirflowNomenclature(dtCondenserXrefData.Rows[0]["ECOSAIRE_CondenserXrefModel"].ToString());

            }
            else
            {
                Public.LanguageBox("You must select a model.", "Vous devez séléctionner un modèle.");
            }
        }

        private string GetParseModelWithoutAirflowNomenclature(string model)
        {
            if (model.Length > 0)
            {
                if (IsLetter(model.Substring(model.Length - 1, 1)))
                {
                    model = model.Substring(0, model.Length - 1);
                }
            }

            return model;
        }

        private bool IsLetter(string character)
        {
            return char.IsLetter(character, 0);
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
            if (Public.LanguageQuestionBox("Are you sure you want to save this condenser ?", "Êtes-vous sûr de vouloir sauvegarder ce condenseur ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (CheckForModelThatCannotBeChanged())
                {
                    if (CheckForAirFlow())
                    {
                        if (CheckForOverwrite())
                        {
                            if (DeleteUnit(TypeOfCondenserParameter(), Motor(), CoilArr(), FanWide(), FanLong(), numRow.Value.ToString(CultureInfo.InvariantCulture), numFPI.Value.ToString(CultureInfo.InvariantCulture)))
                            {
                                if (Query.Execute(GetCondenserModelSaveQuery() + " " + GetCondenserXrefSaveQuery()))
                                {
                                    UpdateTableVersions();
                                    Fill_ListOfModel();

                                    Public.LanguageBox("Saving completed", "Sauvegarde completée");
                                }
                                else
                                {
                                    Public.LanguageBox("An error occured while trying to save", "Une erreur est survenue lors de la sauvegarde");
                                }
                            }
                            else
                            {
                                Public.LanguageBox("An error occured while trying to save", "Une erreur est survenue lors de la sauvegarde");
                            }
                        }
                        else
                        {
                            Public.LanguageBox("Saving canceled !", "Sauvegarde annulée !");
                        }
                    }
                }
                else
                {
                    Public.LanguageBox("You cannot save or modify this model. It is using a different logic than the other condenser", "Vous ne pouvez pas sauvegarder ou modifier ce model. Il utilise une logique différente des autres condenseur.");
                }
            }
            else
            {
                Public.LanguageBox("You must pick at least 1 air flow type", "Vous devez sélectionner au moins 1 type de débit d'air");
            }
        }

        private bool CheckForModelThatCannotBeChanged()
        {
            string strMotor = Motor();

            return !(strMotor == "T" || strMotor == "0"); 
        }

        private bool CheckForAirFlow()
        {
            return !(!chkHorizontal.Checked && !chkVertical.Checked);
        }

        private string GetCondenserXrefSaveQuery()
        {
            string htsql = @"INSERT INTO CondenserXref
                                   ([CondenserType]
                                   ,[Motor]
                                   ,[CoilArr]
                                   ,[FanWide]
                                   ,[FanLong]
                                   ,[Row]
                                   ,[FPI]
                                   ,[AirFlow]
                                   ,[REFPLUS_CondenserXRefModel]
                                   ,[ECOSAIRE_CondenserXRefModel]
                                   ,[DECTRON_CondenserXRefModel]
                                   ,[CIRCULAIRE_CondenserXRefModel]
                                   ,[CoilModel]
                                   ,[Price])
                             VALUES
                                   ('" + TypeOfCondenserParameter() + @"'
                                   ,'" + Motor() + @"'
                                   ,'" + CoilArr() + @"'
                                   ," + FanWide() + @"
                                   ," + FanLong() + @"
                                   ," + numRow.Value + @"
                                   ," + numFPI.Value + @"
                                   ,'H'
                                   ,'" + ConvertModel(txtModelREF.Text, "H") + @"'
                                   ,'" + ConvertModel(txtModelECO.Text, "H") + @"'
                                   ,'" + ConvertModel(txtModelDECT.Text, "H") + @"'
                                   ,'" + ConvertModel(txtModelCIRC.Text, "H") + @"'
                                   ,'" + txtCoilModel.Text + @"'
                                   ," + numPrice.Value + @")";

            string vtsql = @"INSERT INTO CondenserXref
                                   ([CondenserType]
                                   ,[Motor]
                                   ,[CoilArr]
                                   ,[FanWide]
                                   ,[FanLong]
                                   ,[Row]
                                   ,[FPI]
                                   ,[AirFlow]
                                   ,[REFPLUS_CondenserXRefModel]
                                   ,[ECOSAIRE_CondenserXRefModel]
                                   ,[DECTRON_CondenserXRefModel]
                                   ,[CIRCULAIRE_CondenserXRefModel]
                                   ,[CoilModel]
                                   ,[Price])
                             VALUES
                                   ('" + TypeOfCondenserParameter() + @"'
                                   ,'" + Motor() + @"'
                                   ,'" + CoilArr() + @"'
                                   ," + FanWide() + @"
                                   ," + FanLong() + @"
                                   ," + numRow.Value + @"
                                   ," + numFPI.Value + @"
                                   ,'V'
                                   ,'" + ConvertModel(txtModelREF.Text, "V") + @"'
                                   ,'" + ConvertModel(txtModelECO.Text, "V") + @"'
                                   ,'" + ConvertModel(txtModelDECT.Text, "V") + @"'
                                   ,'" + ConvertModel(txtModelCIRC.Text, "V") + @"'
                                   ,'" + txtCoilModel.Text + @"'
                                   ," + numPrice.Value + @")";

            string tsql = "";

            if (chkHorizontal.Checked)
            {
                tsql += " " + htsql;
            }

            if (chkVertical.Checked)
            {
                tsql += " " + vtsql;
            }

            return tsql;
        }

        private string ConvertModel(string modelName, string orientation)
        {
            if (modelName.Length > 0)
            {
                if (orientation == "H")
                {
                    modelName += (Motor() == "S" ? "S" : "H");
                }
                else
                {
                    modelName += (Motor() == "S" ? "L" : "");
                }
            }

            return modelName;
        }

        private string GetCondenserModelSaveQuery()
        {
            string tsql = @"INSERT INTO CondenserModel
                                 ([CondenserType]
                                 ,[Motor]
                                 ,[CoilArr]
                                 ,[FanWide]
                                 ,[FanLong]
                                 ,[Row]
                                 ,[FPI]
                                 ,[FinType]
                                 ,[FinHeight]
                                 ,[FinLength]
                                 ,[CondenserCircQty]
                                 ,[Capacity_per_Circuit]
                                 ,[THR_at_1F]
                                 ,[ConnDischarge]
                                 ,[ConnLiquid]
                                 ,[ConnQty]
                                 ,[RefChargeSummer]
                                 ,[RefChargeWinter]
                                 ,[ShipWeight]
                                 ,[CondenserPrice]
                                 ,[Active])
                           VALUES
                                 ('" + TypeOfCondenserParameter() + @"'
                                 ,'" + Motor() + @"'
                                 ,'" + CoilArr() + @"'
                                 ," + FanWide() + @"
                                 ," + FanLong() + @"
                                 ," + numRow.Value + @"
                                 ," + numFPI.Value + @"
                                 ,'" + txtFinType.Text + @"'
                                 ," + numFinHeight.Value + @"
                                 ," + numFinLength.Value + @"
                                 ," + numCondenserCircQty.Value + @"
                                 ," + numCapacity_Per_Circuit.Value + @"
                                 ," + numTHR_at_1F.Value + @"
                                 ," + numDischarge.Value + @"
                                 ," + numLiquid.Value + @"
                                 ," + numConnQty.Value + @"
                                 ," + numRefSummerCharge.Value + @"
                                 ," + numRefWinterCharge.Value + @"
                                 ," + numWeight.Value + @"
                                 ,0
                                 ," + (chkActive.Checked ? "1" : "0") + ")";

            return tsql;
        }

        private void UpdateTableVersions()
        {
            Query.UpdateServerTableVersion("CondenserModel");
            Query.UpdateServerTableVersion("CondenserXref");
        }

        private bool DeleteUnit(string condenserType, string motor, string coilArr, string fanWide, string fanLong, string row, string fpi)
        {
            string tsql = "";
            tsql += " DELETE FROM CondenserModel WHERE CondenserType = '" + condenserType + "' AND Motor = '" + motor + "' AND CoilArr = '" + coilArr + "' AND FanWide = " + fanWide + " AND FanLong = " + fanLong + " AND Row = " + row + " AND FPI = " + fpi;
            tsql += " DELETE FROM CondenserXref WHERE CondenserType = '" + condenserType + "' AND Motor = '" + motor + "' AND CoilArr = '" + coilArr + "' AND FanWide = " + fanWide + " AND FanLong = " + fanLong + " AND Row = " + row + " AND FPI = " + fpi;

            return Query.Execute(tsql);
        }

        private bool CheckForOverwrite()
        {

            DataTable dtCondenserModel = Query.Select("SELECT * FROM CondenserXref WHERE CondenserType = '" + TypeOfCondenserParameter() + "' AND Motor = '" + Motor() + "' AND CoilArr = '" + CoilArr() + "' AND FanWide = " + FanWide() + " AND FanLong = " + FanLong() + " AND Row = " + numRow.Value + " AND FPI = " + numFPI.Value);

            if (dtCondenserModel.Rows.Count > 0)
            {
                string strModel = dtCondenserModel.Rows[0]["CondenserType"].ToString() +
                                  dtCondenserModel.Rows[0]["Motor"] +
                                  dtCondenserModel.Rows[0]["CoilArr"] +
                                  "\n" +
                                  dtCondenserModel.Rows[0]["FanWide"] +
                                  " x " +
                                  dtCondenserModel.Rows[0]["FanLong"] +
                                  "\n" +
                                  dtCondenserModel.Rows[0]["Row"] +
                                  Public.LanguageString( " row "," rangée ") +
                                  "\n" +
                                  dtCondenserModel.Rows[0]["FPI"] +
                                  Public.LanguageString(" fpi", " ailettes par pouce");
                
                
                dtCondenserModel.Dispose();
                
                
                if (Public.LanguageQuestionBox("There is already a condenser with the following specifications :\n\n" + strModel + "\n\n Do you wish to overwrite it ?", "Il existe déja un condenseur avec les spécifications suivantes :\n\n" + strModel + "\n\n Voulez-vous l'écraser avec votre condenseur ?", MessageBoxButtons.YesNo) == DialogResult.No)
                {
            
                    return false;
                }
            }


            return true;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmCondenserManager_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }

        private void cboTypeOfCondenser_SelectedIndexChanged(object sender, EventArgs e)
        {
            //2011-04-25 : ticket #20 - Simon said Heat reclaim can
            //ONLY be horizontal
            chkVertical.Enabled = TypeOfCondenserParameter() != "H";
        }
    }
}