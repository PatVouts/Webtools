using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.FluidCooler
{
    public partial class FrmFluidCoolerManager : Form
    {
        public FrmFluidCoolerManager()
        {
            InitializeComponent();
        }

        private void frmFluidCoolerManager_Load(object sender, EventArgs e)
        {
            Public.ChangeFormLanguage(this);

            Public.ChangeColor(this);

            FillControls();
        }

        private void FillControls()
        {
            Fill_Models();
            Fill_UnitType();
            Fill_FanArrangement();
            Fill_FPI();
        }


        private void LoadModel()
        {
            ClearAllValueEntered();

            DataTable dtModelInfo = Query.Select("SELECT * FROM FluidCoolerModel WHERE " + UserInformation.CurrentSite + "_FluidXRefModel = '" + cboModels.Text + "'");
            
            if (dtModelInfo.Rows.Count > 0)
            {
                numCFM.Value = Convert.ToDecimal(dtModelInfo.Rows[0]["CFM"]);
                ComboBoxControl.SetIDDefaultValue(cboUnitType, dtModelInfo.Rows[0]["Motor"] + dtModelInfo.Rows[0]["CoilArr"].ToString());
                ComboBoxControl.SetIDDefaultValue(cboFanArrangement, dtModelInfo.Rows[0]["FanWide"] + dtModelInfo.Rows[0]["FanLong"].ToString());
                numRow.Value = Convert.ToDecimal(dtModelInfo.Rows[0]["Row"]);
                cboFPI.SelectedIndex = cboFPI.FindString(dtModelInfo.Rows[0]["FPI"].ToString());
                numFinLength.Value = Convert.ToDecimal(dtModelInfo.Rows[0]["CoilLength"]);
                numPrice.Value = Convert.ToDecimal(dtModelInfo.Rows[0]["Price"]);
                if (dtModelInfo.Rows[0]["Row"].ToString() == "H")
                {
                    radHorizontal.Checked = true;
                }
                else
                {
                    radVertical.Checked = true;
                }

                SetFinBasedValues(dtModelInfo);
            }
        }

        private void SetFinBasedValues(DataTable dtModelInfo)
        {
            DataTable dtFinE = Public.SelectAndSortTable(dtModelInfo, "Fin = 'E'", "Cir1");
            DataTable dtFinF = Public.SelectAndSortTable(dtModelInfo, "Fin = 'F'", "Cir1");
            DataTable dtFinG = Public.SelectAndSortTable(dtModelInfo, "Fin = 'G'", "Cir1");

            //E Fin
            if (dtFinE.Rows.Count > 0)
            {
                numTubesE.Value = Convert.ToDecimal(dtFinE.Rows[0]["Tubes"]);
                numWeightE.Value = Convert.ToDecimal(dtFinE.Rows[0]["Weight"]);

                foreach (DataRow dr in dtFinE.Rows)
                {
                    var myItem = new GlacialComponents.Controls.GLItem(lvCircuitE);
                    myItem.SubItems[0].Text = dr["Cir1"].ToString();
                    lvCircuitE.Items.Add(myItem);
                }

                lvCircuitE.Refresh();
            }

            //F Fin
            if (dtFinF.Rows.Count > 0)
            {
                numTubesF.Value = Convert.ToDecimal(dtFinF.Rows[0]["Tubes"]);
                numWeightF.Value = Convert.ToDecimal(dtFinF.Rows[0]["Weight"]);

                foreach (DataRow dr in dtFinF.Rows)
                {
                    var myItem = new GlacialComponents.Controls.GLItem(lvCircuitF);
                    myItem.SubItems[0].Text = dr["Cir1"].ToString();
                    lvCircuitF.Items.Add(myItem);
                }

                lvCircuitF.Refresh();
            }

            //G Fin
            if (dtFinG.Rows.Count > 0)
            {
                numTubesG.Value = Convert.ToDecimal(dtFinG.Rows[0]["Tubes"]);
                numWeightG.Value = Convert.ToDecimal(dtFinG.Rows[0]["Weight"]);

                foreach (DataRow dr in dtFinG.Rows)
                {
                    var myItem = new GlacialComponents.Controls.GLItem(lvCircuitG);
                    myItem.SubItems[0].Text = dr["Cir1"].ToString();
                    lvCircuitG.Items.Add(myItem);
                }

                lvCircuitG.Refresh();
            }
        }

        private void ClearAllValueEntered()
        {
            ClearGenericOptions();
            ClearFinTypes();
        }

        private void ClearGenericOptions()
        {
            numCFM.Value = 1m;
            cboUnitType.SelectedIndex = 0;
            cboFanArrangement.SelectedIndex = 0;
            numRow.Value = 1m;
            cboFPI.SelectedIndex = 0;
            numFinLength.Value = 1m;
            numPrice.Value = 0m;
            radVertical.Checked = true;
        }

        private void ClearFinTypes()
        {
            numTubesE.Value = 0m;
            numTubesF.Value = 0m;
            numTubesG.Value = 0m;

            numWeightE.Value = 0m;
            numWeightF.Value = 0m;
            numWeightG.Value = 0m;

            lvCircuitE.Items.Clear();
            lvCircuitF.Items.Clear();
            lvCircuitG.Items.Clear();

            lvCircuitE.Refresh();
            lvCircuitF.Refresh();
            lvCircuitG.Refresh();

            numCircuitE.Value = 1m;
            numCircuitF.Value = 1m;
            numCircuitG.Value = 1m;
        }

        private void Fill_Models()
        {
            cboModels.Items.Clear();

            DataTable dtFluidCoolerModels = Query.Select("SELECT DISTINCT " + UserInformation.CurrentSite + "_FluidXRefModel as Model FROM FluidCoolerModel ORDER BY Model");

            foreach (DataRow drModel in dtFluidCoolerModels.Rows)
            {
                string strIndex = drModel["Model"].ToString();
                string strText = drModel["Model"].ToString();
                ComboBoxControl.AddItem(cboModels, strIndex, strText);
            }


            dtFluidCoolerModels.Dispose();

            if (cboModels.Items.Count > 0)
            {
                cboModels.SelectedIndex = 0;
            }
        }

        private string GetFPINomenclature()
        {
            return ComboBoxControl.IndexInformation(cboFPI).Substring(ComboBoxControl.IndexInformation(cboFPI).Length - 1, 1);
        }

        private void Fill_FPI()
        {
            cboFPI.Items.Clear();

            DataTable dtFPI = Query.Select("SELECT * FROM FluidCoolerFPINomenclature ORDER BY FPI");

            foreach (DataRow drFPI in dtFPI.Rows)
            {
                string strIndex = drFPI["FPI"] + drFPI["Nomenclature"].ToString();
                string strText = drFPI["FPI"].ToString();
                ComboBoxControl.AddItem(cboFPI, strIndex, strText);
            }

            dtFPI.Dispose();

            if (cboFPI.Items.Count > 0)
            {
                cboFPI.SelectedIndex = 0;
            }
        }

        private string GetFanWide()
        {
            return ComboBoxControl.IndexInformation(cboFanArrangement).Substring(0, 1);
        }

        private string GetFanLong()
        {
            return ComboBoxControl.IndexInformation(cboFanArrangement).Substring(1, 1);
        }

        private void Fill_FanArrangement()
        {
            cboFanArrangement.Items.Clear();

            DataTable dtFilteredFanArrangmeentList = Query.Select("SELECT * FROM FluidCoolerFanArrangement WHERE Motor = '" + GetUnitTypeMotor() + "' AND CoilArr = '" + GetUnitTypeCoilArr() + "'");

            //loop through all fan arrangement
            foreach (DataRow drFanArrangement in dtFilteredFanArrangmeentList.Rows)
            {
                string strIndex = drFanArrangement["FanWide"] + drFanArrangement["FanLong"].ToString();
                string strText = drFanArrangement["FanArrangement"].ToString();
                ComboBoxControl.AddItem(cboFanArrangement, strIndex, strText);
            }

            dtFilteredFanArrangmeentList.Dispose();

            if (cboFanArrangement.Items.Count > 0)
            {
                cboFanArrangement.SelectedIndex = 0;
            }
        }

        private string GetUnitTypeMotor()
        {
            return ComboBoxControl.IndexInformation(cboUnitType).Substring(0, 1);
        }

        private string GetUnitTypeCoilArr()
        {
            return ComboBoxControl.IndexInformation(cboUnitType).Substring(1, 1);
        }

        private void Fill_UnitType()
        {
            cboUnitType.Items.Clear();

            DataTable dtUnitType = Query.Select("SELECT * FROM CoilInfo ORDER BY Motor, CoilArr");

            foreach (DataRow drUnitType in dtUnitType.Rows)
            {
                string strIndex = drUnitType["Motor"] + drUnitType["CoilArr"].ToString();
                string strText = drUnitType["Motor"].ToString().Replace("S", "V") + drUnitType["CoilArr"] + " - " + drUnitType["Description"];
                ComboBoxControl.AddItem(cboUnitType, strIndex, strText);
            }

            cboUnitType.SelectedIndex = 0;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboUnitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_FanArrangement();
        }

        private void cmdLoadModel_Click(object sender, EventArgs e)
        {
            LoadModel();
        }

        private void cmdAddCircuitE_Click(object sender, EventArgs e)
        {
            int intCircuit = Convert.ToInt32(numCircuitE.Value);

            if (DoesCircuitExist(intCircuit, lvCircuitE) == false)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvCircuitE);
                myItem.SubItems[0].Text = intCircuit.ToString(CultureInfo.InvariantCulture);
                lvCircuitE.Items.Add(myItem);
                lvCircuitE.Refresh();
            }
            else
            {
                Public.LanguageBox("Cannot add circuit because it already exist", "Impossible d'ajouter ce circuit car il existe déja.");
            }
        }

        private bool DoesCircuitExist(int circuit, GlacialComponents.Controls.GlacialList lvList)
        {
            bool circuitExist = false;

            for (int i = 0; i < lvList.Items.Count; i++)
            {
                if (lvList.Items[i].SubItems[0].Text == circuit.ToString(CultureInfo.InvariantCulture))
                {
                    circuitExist = true;
                    i = lvList.Items.Count;
                }
            }

            return circuitExist;
        }

        private void cmdAddCircuitF_Click(object sender, EventArgs e)
        {
            int intCircuit = Convert.ToInt32(numCircuitF.Value);

            if (DoesCircuitExist(intCircuit, lvCircuitF) == false)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvCircuitF);
                myItem.SubItems[0].Text = intCircuit.ToString(CultureInfo.InvariantCulture);
                lvCircuitF.Items.Add(myItem);
                lvCircuitF.Refresh();
            }
            else
            {
                Public.LanguageBox("Cannot add circuit because it already exist", "Impossible d'ajouter ce circuit car il existe déja.");
            }
        }

        private void cmdAddCircuitG_Click(object sender, EventArgs e)
        {
            int intCircuit = Convert.ToInt32(numCircuitG.Value);

            if (DoesCircuitExist(intCircuit, lvCircuitG) == false)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvCircuitG);
                myItem.SubItems[0].Text = intCircuit.ToString(CultureInfo.InvariantCulture);
                lvCircuitG.Items.Add(myItem);
                lvCircuitG.Refresh();
            }
            else
            {
                Public.LanguageBox("Cannot add circuit because it already exist", "Impossible d'ajouter ce circuit car il existe déja.");
            }
        }

        private void cmdRemoveCircuitE_Click(object sender, EventArgs e)
        {
            if (lvCircuitE.SelectedItems.Count > 0)
            {
                lvCircuitE.Items.Remove(((GlacialComponents.Controls.GLItem)lvCircuitE.SelectedItems[0]));
                lvCircuitE.Refresh();
            }
            else
            {
                Public.LanguageBox("You must select a circuit to remove first", "Vous devez d'abord sélectionner un circuit à enlever ");
            }
        }

        private void cmdRemoveCircuitF_Click(object sender, EventArgs e)
        {
            if (lvCircuitF.SelectedItems.Count > 0)
            {
                lvCircuitF.Items.Remove(((GlacialComponents.Controls.GLItem)lvCircuitF.SelectedItems[0]));
                lvCircuitF.Refresh();
            }
            else
            {
                Public.LanguageBox("You must select a circuit to remove first", "Vous devez d'abord sélectionner un circuit à enlever ");
            }
        }

        private void cmdRemoveCircuitG_Click(object sender, EventArgs e)
        {
            if (lvCircuitG.SelectedItems.Count > 0)
            {
                lvCircuitG.Items.Remove(((GlacialComponents.Controls.GLItem)lvCircuitG.SelectedItems[0]));
                lvCircuitG.Refresh();
            }
            else
            {
                Public.LanguageBox("You must select a circuit to remove first", "Vous devez d'abord selectionner un circuit à enlever ");
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (Public.LanguageQuestionBox("Are you sure you want to save", "Êtes-vous sûr de vouloir sauvegarder?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (IsFinEUsed() || IsFinFUsed() || IsFinGUsed())
                {
                    string strModel = GetModelNomenclature();

                    DeleteModel(strModel);

                    SaveFinE(strModel);
                    SaveFinF(strModel);
                    SaveFinG(strModel);

                    //log after like that i can do a select and simplify the code.
                    //anyway in case of crash when saving it's better since log only
                    //log is the table passed to it contain something.
                    DataTable dtLog = Query.Select("SELECT * FROM FluidCoolerModel WHERE " + UserInformation.CurrentSite + "_FluidXRefModel = '" + strModel + "'");
                    Query.CreateLog(dtLog, "FluidCoolerModel_LOG", "INSERT");

                    Fill_Models();

                    Public.LanguageBox("Saving successful", "Sauvegarde réussie");
                }
                else
                {
                    Public.LanguageBox("You need to fill data for at least 1 fin", "Vous devez entrez les informations pour au moins 1 type d'ailette");
                }
            }
        }

        private void SaveFinE(string model)
        {
            for (int i = 0; i < lvCircuitE.Items.Count; i++)
            {
                string tsql = @"INSERT INTO FluidCoolerModel([CFM]
                                ,[Motor]
                                ,[Coilarr]
                                ,[Fanwide]
                                ,[Fanlong]
                                ,[FanQty]
                                ,[Row]
                                ,[Fpi]
                                ,[Fin]
                                ,[Tubes]
                                ,[FinHeight]
                                ,[coillength]
                                ,[cir1]
                                ,[TCFM]
                                ,[AirFlow]
                                ,[REFPLUS_FluidXRefModel]
                                ,[ECOSAIRE_FluidXRefModel]
                                ,[DECTRON_FluidXRefModel]
                                ,[CIRCULAIRE_FluidXRefModel]
                                ,[Price]
                                ,[Weight])
                                VALUES
                                (" + numCFM.Value + @"
                                ,'" + GetUnitTypeMotor() + @"'
                                ,'" + GetUnitTypeCoilArr() + @"'
                                ," + GetFanWide() + @"
                                ," + GetFanLong() + @"
                                ," + Convert.ToInt32(Convert.ToInt32(GetFanWide()) * Convert.ToInt32(GetFanLong())) + @"
                                ," + numRow.Value + @"
                                ," + cboFPI.Text + @"
                                ,'E'
                                ," + numTubesE.Value + @"
                                ," + Convert.ToDecimal(numTubesE.Value * 1.25m) + @"
                                ," + numFinLength.Value + @"
                                ," + lvCircuitE.Items[i].SubItems[0].Text + @"
                                ," + Convert.ToInt32(Convert.ToInt32(GetFanWide()) * Convert.ToInt32(GetFanLong()) * Convert.ToInt32(numCFM.Value)) + @"
                                ,'" + (radHorizontal.Checked ? "H" : "V") + @"'
                                ,'" + "F" + model.Substring(1) + @"'
                                ,'" + "G" + model.Substring(1) + @"'
                                ,'" + "G" + model.Substring(1) + @"'
                                ,'" + "G" + model.Substring(1) + @"'
                                ," + numPrice.Value + @"
                                ," + numWeightE.Value + @")";

                Query.Execute(tsql);
            }
        }

        private void SaveFinF(string model)
        {
            for (int i = 0; i < lvCircuitF.Items.Count; i++)
            {
                string tsql = @"INSERT INTO FluidCoolerModel([CFM]
                                ,[Motor]
                                ,[Coilarr]
                                ,[Fanwide]
                                ,[Fanlong]
                                ,[FanQty]
                                ,[Row]
                                ,[Fpi]
                                ,[Fin]
                                ,[Tubes]
                                ,[FinHeight]
                                ,[coillength]
                                ,[cir1]
                                ,[TCFM]
                                ,[AirFlow]
                                ,[REFPLUS_FluidXRefModel]
                                ,[ECOSAIRE_FluidXRefModel]
                                ,[DECTRON_FluidXRefModel]
                                ,[CIRCULAIRE_FluidXRefModel]
                                ,[Price]
                                ,[Weight])
                                VALUES
                                (" + numCFM.Value + @"
                                ,'" + GetUnitTypeMotor() + @"'
                                ,'" + GetUnitTypeCoilArr() + @"'
                                ," + GetFanWide() + @"
                                ," + GetFanLong() + @"
                                ," + Convert.ToInt32(Convert.ToInt32(GetFanWide()) * Convert.ToInt32(GetFanLong())) + @"
                                ," + numRow.Value + @"
                                ," + cboFPI.Text + @"
                                ,'F'
                                ," + numTubesF.Value + @"
                                ," + Convert.ToDecimal(numTubesF.Value * 1.5m) + @"
                                ," + numFinLength.Value + @"
                                ," + lvCircuitF.Items[i].SubItems[0].Text + @"
                                ," + Convert.ToInt32(Convert.ToInt32(GetFanWide()) * Convert.ToInt32(GetFanLong()) * Convert.ToInt32(numCFM.Value)) + @"
                                ,'" + (radHorizontal.Checked ? "H" : "V") + @"'
                                ,'" + "F" + model.Substring(1) + @"'
                                ,'" + "G" + model.Substring(1) + @"'
                                ,'" + "G" + model.Substring(1) + @"'
                                ,'" + "G" + model.Substring(1) + @"'
                                ," + numPrice.Value + @"
                                ," + numWeightF.Value + @")";

                Query.Execute(tsql);
            }
        }

        private void SaveFinG(string model)
        {
            for (int i = 0; i < lvCircuitG.Items.Count; i++)
            {
                string tsql = @"INSERT INTO FluidCoolerModel([CFM]
                                ,[Motor]
                                ,[Coilarr]
                                ,[Fanwide]
                                ,[Fanlong]
                                ,[FanQty]
                                ,[Row]
                                ,[Fpi]
                                ,[Fin]
                                ,[Tubes]
                                ,[FinHeight]
                                ,[coillength]
                                ,[cir1]
                                ,[TCFM]
                                ,[AirFlow]
                                ,[REFPLUS_FluidXRefModel]
                                ,[ECOSAIRE_FluidXRefModel]
                                ,[DECTRON_FluidXRefModel]
                                ,[CIRCULAIRE_FluidXRefModel]
                                ,[Price]
                                ,[Weight])
                                VALUES
                                (" + numCFM.Value + @"
                                ,'" + GetUnitTypeMotor() + @"'
                                ,'" + GetUnitTypeCoilArr() + @"'
                                ," + GetFanWide() + @"
                                ," + GetFanLong() + @"
                                ," + Convert.ToInt32(Convert.ToInt32(GetFanWide()) * Convert.ToInt32(GetFanLong())) + @"
                                ," + numRow.Value + @"
                                ," + cboFPI.Text + @"
                                ,'G'
                                ," + numTubesG.Value + @"
                                ," + Convert.ToDecimal(numTubesG.Value * 1.5m) + @"
                                ," + numFinLength.Value + @"
                                ," + lvCircuitG.Items[i].SubItems[0].Text + @"
                                ," + Convert.ToInt32(Convert.ToInt32(GetFanWide()) * Convert.ToInt32(GetFanLong()) * Convert.ToInt32(numCFM.Value)) + @"
                                ,'" + (radHorizontal.Checked ? "H" : "V") + @"'
                                ,'" + "F" + model.Substring(1) + @"'
                                ,'" + "G" + model.Substring(1) + @"'
                                ,'" + "G" + model.Substring(1) + @"'
                                ,'" + "G" + model.Substring(1) + @"'
                                ," + numPrice.Value + @"
                                ," + numWeightG.Value + @")";

                Query.Execute(tsql);
            }
        }

        private void DeleteModel(string model)
        {
            //LOG-------------------------------------------------->
            DataTable dtLog = Query.Select("SELECT * FROM FluidCoolerModel WHERE " + UserInformation.CurrentSite + "_FluidXRefModel = '" + model + "'");
            Query.CreateLog(dtLog, "FluidCoolerModel_LOG", "DELETE");
            //LOG-------------------------------------------------->

            Query.Execute("DELETE FROM FluidCoolerModel WHERE " + UserInformation.CurrentSite + "_FluidXRefModel = '" + model + "'");

            
        }

        private bool IsFinEUsed()
        {
            return !(numTubesE.Value == 0m || numWeightE.Value == 0m || lvCircuitE.Items.Count == 0);
        }

        private bool IsFinFUsed()
        {
            return !(numTubesF.Value == 0m || numWeightF.Value == 0m || lvCircuitF.Items.Count == 0);
        }

        private bool IsFinGUsed()
        {
            return !(numTubesG.Value == 0m || numWeightG.Value == 0m || lvCircuitG.Items.Count == 0);
        }

        private string GetModelNomenclature()
        {
            string modelNomenclature = (UserInformation.CurrentSite == "REFPLUS" ? "F" : "G");

            modelNomenclature += GetUnitTypeMotor().Replace("S", "V");
            modelNomenclature += GetUnitTypeCoilArr();
            modelNomenclature += GetFanWide();
            modelNomenclature += GetFanLong();
            modelNomenclature += numRow.Value.ToString(CultureInfo.InvariantCulture);
            modelNomenclature += GetFPINomenclature();

            if (GetUnitTypeMotor() == "S")
            {
                if (radHorizontal.Checked)
                {
                    modelNomenclature += "S";
                }
                else
                {
                    modelNomenclature += "L";
                }
            }
            else
            {
                if (radHorizontal.Checked)
                {
                    modelNomenclature += "H";
                }
            }

            return modelNomenclature;
        }

        private void cmdDeleteModel_Click(object sender, EventArgs e)
        {
            if (Public.LanguageQuestionBox("Are you sure you want to delete this model ?", "Êtes-vous sûr de vouloir supprimer ce modèle ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DeleteModel(cboModels.Text);
            }

            Fill_Models();
        }

    }
}