using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace RefplusWebtools.DataManager.Evaporator
{
    public partial class FrmEvaporatorModel : Form
    {
        private readonly string[] _strTableList = { "Voltage", "CoilFinShape", "CoilFinType", "v_CoilFinTypeDefaults", "CoilFinTypeShape", "v_CoilFinDefaults", "EvaporatorFanArrangement" };
        private DataTable _dtDefrostType;
        private DataTable _dtEvapType;
        private DataTable _dtEvapStyle;

        public FrmEvaporatorModel()
        {
            InitializeComponent();
        }

        private void frmEvaporatorModel_Load(object sender, EventArgs e)
        {
            Public.ChangeFormLanguage(this);

            Public.ChangeColor(this);

            Query.LoadTables(_strTableList);

            FillComboBoxes();

            SetDefaults();

            //SetTabsEnabledProperty(false);

            WindowState = FormWindowState.Maximized;
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

        private void FillComboBoxes()
        {
            FillEvapModel();
            FillDefrostType();
            FillEvapType();
            FillEvapStyle();
            FillCoilFinType();
            Fill_FanArrangement();
            FillVoltage();
        }

        private void SetDefaults()
        {
            cboEvapModel.SelectedIndex = 0;
            cboDefrostType.SelectedIndex = 0;
            cboEvapStyle.SelectedIndex = 0;
            cboEvapType.SelectedIndex = 0;
            cboFanArrangement.SelectedIndex = 0;
            cboVoltage.SelectedIndex = 0;
        }

        private void FillDefrostType()
        {
            cboDefrostType.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox
            _dtDefrostType = Query.Select("Select * from EvaporatorDefrostType");

            foreach (DataRow drDefrostType in _dtDefrostType.Rows)
            {
                string strIndex = drDefrostType["UniqueID"].ToString();
                string strText = drDefrostType["DefrostType"].ToString();
                ComboBoxControl.AddItem(cboDefrostType, strIndex, strText);
            }
        }

        private void FillVoltage()
        {
            cboVoltage.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox
            DataTable dtVoltage = Query.Select("SELECT * from EvaporatorVoltage");

            foreach (DataRow dr in dtVoltage.Rows)
            {
                string strIndex = dr["VoltageID"].ToString();
                string strText = dr["VoltDescription"].ToString();
                ComboBoxControl.AddItem(cboVoltage, strIndex, strText);
            }
        }

        private void FillFPI()
        {
            var coilBackCode = new QuickCoil.QuickCoilCode();

            cboFPI.Items.Clear();

            //min and max fpi
            int intMinFPI = 0;
            int intMaxFPI = 0;

            //pass by reference the 2 variable which will return me the min and max fpi
            //available for this fin type
            coilBackCode.MinMaxFPI(Public.DSDatabase.Tables["v_CoilFinDefaults"], FinTypeParameter(), ref intMinFPI, ref intMaxFPI);

            //from the min to the max we add an item
            for (int intFPI = intMinFPI; intFPI <= intMaxFPI; intFPI++)
            {
                ComboBoxControl.AddItem(cboFPI, intFPI.ToString(CultureInfo.InvariantCulture), intFPI.ToString(CultureInfo.InvariantCulture));
            }

            if (cboFPI.Items.Count > 0)
            {
                //cboFPI.SelectedIndex = cboFPI.FindString(Public.SelectAndSortTable(dtEvapModel, "EvaporatorID = '" + cboEvapModel.Text + "'", "").Rows[0]["CoilFPI"].ToString());
                cboFPI.SelectedIndex = 0;
            }
        }

        private void Fill_Motor(ref ComboBox cbo, int voltageID)
        {
            DataTable dtModel = Query.Select("SELECT MotorModel.*, MainVoltage.VoltageID FROM MotorModel LEFT JOIN MotorModelFLA ON MotorModel.MotorID = MotorModelFLA.MotorID LEFT JOIN MainVoltage ON MotorModelFLA.VoltageID = MainVoltage.VoltageID WHERE MainVoltage.VoltageID = " + voltageID + " ORDER BY MotorModel.MotorID, MotorModelFLA.VoltageID");

            foreach (DataRow dr in dtModel.Rows)
            {
                ComboBoxControl.AddItem(cbo, dr["MotorID"].ToString(), dr["MotorID"].ToString());
            }

            if (cbo.Items.Count > 0)
            {
                cbo.SelectedIndex = 0;
            }
        }

        private void Fill_MotorMount(ref ComboBox cbo)
        {
            DataTable dtModel = Query.Select("SELECT * FROM MotorMountModel");

            foreach (DataRow dr in dtModel.Rows)
            {
                ComboBoxControl.AddItem(cbo, dr["MotorMountID"].ToString(), dr["MotorMountID"].ToString());
            }

            if (cbo.Items.Count > 0)
            {
                cbo.SelectedIndex = 0;
            }
        }

        private void Fill_Fan(ref ComboBox cbo)
        {
            DataTable dtModel = Query.Select("SELECT * FROM FanModel");

            foreach (DataRow dr in dtModel.Rows)
            {
                ComboBoxControl.AddItem(cbo, dr["FanID"].ToString(), dr["FanID"].ToString());
            }

            if (cbo.Items.Count > 0)
            {
                cbo.SelectedIndex = 0;
            }
        }

        private void Fill_FanGuard(ref ComboBox cbo)
        {
            DataTable dtModel = Query.Select("SELECT * FROM FanGuardModel");

            foreach (DataRow dr in dtModel.Rows)
            {
                ComboBoxControl.AddItem(cbo, dr["FanGuardID"].ToString(), dr["FanGuardID"].ToString());
            }

            if (cbo.Items.Count > 0)
            {
                cbo.SelectedIndex = 0;
            }
        }

        private void Fill_DefrostHeater(ref ComboBox cbo)
        {
            DataTable dtModel = Query.Select("SELECT * FROM DefrostHeater");

            foreach (DataRow dr in dtModel.Rows)
            {
                ComboBoxControl.AddItem(cbo, dr["DefrostHeater"].ToString(), dr["DefrostHeater"].ToString());
            }

            if (cbo.Items.Count > 0)
            {
                cbo.SelectedIndex = 0;
            }
        }

        private void FillEvapModel()
        {
            cboEvapModel.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox
            DataTable dtEvapModel = Query.Select("SELECT * FROM Evaporators ORDER BY EvaporatorID");

            foreach (DataRow drEvapModel in dtEvapModel.Rows)
            {
                string strIndex = drEvapModel["EvaporatorID"].ToString();
                string strText = drEvapModel["EvaporatorID"].ToString();
                ComboBoxControl.AddItem(cboEvapModel, strIndex, strText);
            }
        }

        private void FillEvapType()
        {
            cboEvapType.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox
            _dtEvapType = Query.Select("Select * from EvaporatorType");

            foreach (DataRow drEvapType in _dtEvapType.Rows)
            {
                string strIndex = drEvapType["EvaporatorType"].ToString();
                string strText = drEvapType["Description"].ToString();
                ComboBoxControl.AddItem(cboEvapType, strIndex, strText);
            }
        }

        private void FillEvapStyle()
        {
            cboEvapStyle.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox
            _dtEvapStyle = Query.Select("Select * from EvaporatorStyle");

            foreach (DataRow drEvapStyle in _dtEvapStyle.Rows)
            {
                string strIndex = drEvapStyle["EvaporatorStyle"].ToString();
                string strText = drEvapStyle["Description"].ToString();
                ComboBoxControl.AddItem(cboEvapStyle, strIndex, strText);
            }
        }

        private void FillCoilFinType()
        {
            cboFinType.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox

            var coilBackCode = new QuickCoil.QuickCoilCode();

            foreach (DataRow drFinType in Public.DSDatabase.Tables["CoilFinType"].Rows)
            {
                if (coilBackCode.IsFinTypeAvailableForThisCoil(Public.DSDatabase.Tables["v_CoilFinTypeDefaults"].Copy(), drFinType["UniqueID"].ToString(), "3" /*Evaporator Coil is 3*/ , false))
                {
                    //this is an output example
                    //C - 3/8", 1" X 3/4"
                    string strIndex = drFinType["UniqueID"].ToString();
                    string strText = drFinType["FinType"] + " - " + drFinType["TubeDiameter"] + "\", " + drFinType["FaceTube"] + "\" X " + drFinType["TubeRow"] + "\"";
                    ComboBoxControl.AddItem(cboFinType, strIndex, strText);
                }
            }

            cboFinType.SelectedIndex = 0;
        }

        private void FillFinShape()
        {
            cboFinShape.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox

            //fin type
            string strFinType = FinTypeParameter();

            var coilBackCode = new QuickCoil.QuickCoilCode();

            //for each fin Shape
            foreach (DataRow drFinShape in Public.DSDatabase.Tables["CoilFinShape"].Rows)
            {
                if (coilBackCode.IsFinShapeAvailable(Public.DSDatabase.Tables["CoilFinTypeShape"], strFinType, drFinShape["FinShapeParameter"].ToString()))
                {
                    string strIndex = drFinShape["UniqueID"].ToString();
                    string strText = drFinShape["FinShape"].ToString();
                    ComboBoxControl.AddItem(cboFinShape, strIndex, strText);
                }
            }

            if (cboFinShape.Items.Count > 0)
            {
                cboFinShape.SelectedIndex = 0;
            }
        }

        private void FillFinHeight()
        {
            var coilBackCode = new QuickCoil.QuickCoilCode();

            //this variable will be set to the height selected if one selected
            //since 0 in not possible as a choice it is used to check if there was something 
            //selected in the first place.
            decimal decSelectedHeight = 0;

            //if we have something selected save the selected value
            if (cboFinHeight.SelectedIndex >= 0)
            {
                decSelectedHeight = Convert.ToDecimal(ComboBoxControl.IndexInformation(cboFinHeight));
            }
            cboFinHeight.Items.Clear();

            //this is the face tube value (i.e. 1.5,1.25,1) this number
            //is the "Steps" of possible fin height. If we have 1.5 the 3 first
            //possible height will be 1.5,3,4.5...
            decimal decFaceTubes = FinTypeFaceTube();

            decimal decMaxFinHeight = coilBackCode.MaxFinHeight("DX");

            //for each increment of face tubes, add the height
            for (decimal decFinHeight = decFaceTubes * QuickCoil.QuickCoilCode.DecMinHeightInFaceTubes; decFinHeight < decMaxFinHeight; decFinHeight += decFaceTubes)
            {
                ComboBoxControl.AddItem(cboFinHeight, decFinHeight.ToString(CultureInfo.InvariantCulture), decFinHeight.ToString(CultureInfo.InvariantCulture));
            }

            //now if the decSelectedHeight is Different than 0 it mean something was 
            //selected.
            if (decSelectedHeight != 0)
            {
                ComboBoxControl.SetIDDefaultValue(cboFinHeight, coilBackCode.FinHeightSelectClosestValueOfPreviouslySelectedOne(decSelectedHeight, decFaceTubes));
            }
            else
            {
                cboFinHeight.SelectedIndex = 0;
            }
        }

        
        private string EvaporatorType()
        {
            return ComboBoxControl.ItemInformations(cboEvapType, _dtEvapType, "EvaporatorType")[0]["EvaporatorType"].ToString();
        }

        private string EvaporatorStyle()
        {
            return ComboBoxControl.ItemInformations(cboEvapStyle, _dtEvapStyle, "EvaporatorStyle")[0]["EvaporatorStyle"].ToString();
        }

        //fill fan arrangement
        private void Fill_FanArrangement()
        {
            cboFanArrangement.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox
            //for each fan arangement
            foreach (DataRow drFanArrangement in Public.DSDatabase.Tables["EvaporatorFanArrangement"].Rows)
            {
                string strIndex = drFanArrangement["UniqueID"].ToString();
                string strText = drFanArrangement["FanArrangement"].ToString();
                ComboBoxControl.AddItem(cboFanArrangement, strIndex, strText);
            }
        }

        //return the defrost type parameter (mostly used in tables as reference
        private string DefrostTypeParameter()
        {
            return ComboBoxControl.ItemInformations(cboDefrostType, _dtDefrostType, "UniqueID")[0]["DefrostTypeParameter"].ToString();
        }

        //return the FinType Parameter
        private string FinTypeParameter()
        {
            return ComboBoxControl.ItemInformations(cboFinType, Public.DSDatabase.Tables["CoilFinType"], "UniqueID")[0]["FinType"].ToString();
        }

        //return the Fin shape parameter needed i nthe DLL and maybe some conditions
        private string FinShapeParameter()
        {
            return ComboBoxControl.ItemInformations(cboFinShape, Public.DSDatabase.Tables["CoilFinShape"], "UniqueID")[0]["FinShapeParameter"].ToString();
        }

        //return the FaceTube Amount of the selected FinType
        private decimal FinTypeFaceTube()
        {
            return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboFinType, Public.DSDatabase.Tables["CoilFinType"], "UniqueID")[0]["FaceTube"]);
        }

        private bool IsAllLetter(string valueText)
        {
            bool bolIsLetter = true;

            for (int i = 0; i < valueText.Length; i++)
            {
                if (!IsLetter(valueText.Substring(i, 1)))
                {
                    bolIsLetter = false;
                }
            }

            return bolIsLetter;
        }

        private bool IsAllNumeric(string valueText)
        {
            bool bolIsNumeric = true;

            for (int i = 0; i < valueText.Length; i++)
            {
                if (!IsNumeric(valueText.Substring(i, 1)))
                {
                    bolIsNumeric = false;
                }
            }

            return bolIsNumeric;
        }

        private bool IsNumeric(string character)
        {
            return char.IsNumber(character, 0);
        }

        private bool IsLetter(string character)
        {
            return char.IsLetter(character, 0);
        }

        private static ComboBox GetPartCombobox()
        {
            var cbo = new ComboBox {DropDownStyle = ComboBoxStyle.DropDownList};
            return cbo;
        }

        private void cmdLoadModel_Click(object sender, EventArgs e)
        {
            LoadModel();
        }

        private void LoadModel()
        {
            string strModelToLoad = cboEvapModel.Text;

            SetTabsEnabledProperty(true);

            DataTable dtEvapModel = Query.Select("SELECT * FROM Evaporators WHERE EvaporatorID = '" + strModelToLoad + "'");

            DataRow drEvaporatorData = dtEvapModel.NewRow();

            drEvaporatorData.ItemArray = dtEvapModel.Rows[0].ItemArray;


            string finType = drEvaporatorData["CoilType"].ToString().Substring(1, 1);
            string finShape = drEvaporatorData["CoilType"].ToString().Substring(2, 1);
            int fanQty = Convert.ToInt32(drEvaporatorData["EvaporatorFanQty"].ToString());
            int fanArrangement = Convert.ToInt32(drEvaporatorData["FanArrangement"].ToString());
            int fanLong = fanQty / fanArrangement;
            decimal coilTubes = Convert.ToDecimal(drEvaporatorData["CoilTubes"].ToString());

            DataTable dtFinType = Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilFinType"], "FinType = '" + finType + "'", "");
            DataTable dtFinShape = Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilFinShape"], "FinShapeParameter = '" + finShape + "'", "");

            if (strModelToLoad != "")
            {
                txtModelText.Text = strModelToLoad;
                ValidateModel();
                

                    ComboBoxControl.SetIDDefaultValue(cboFinType, dtFinType.Rows[0]["UniqueID"].ToString());
                    ComboBoxControl.SetIDDefaultValue(cboFinShape, dtFinShape.Rows[0]["UniqueID"].ToString());
                    numPrice.Value = Convert.ToDecimal(drEvaporatorData["EvaporatorPrice"]);
                    numWeight.Value = Convert.ToDecimal(drEvaporatorData["EvaporatorWeight"]);
                    cboFPI.Text = drEvaporatorData["CoilFPI"].ToString();
                    ComboBoxControl.SetDefaultValue(cboFanArrangement, fanArrangement + " X " + fanLong);

                    numCFM.Value = Convert.ToDecimal(drEvaporatorData["EvaporatorCFM"].ToString());
                    numRows.Value = Convert.ToDecimal(drEvaporatorData["CoilRow"].ToString());
                    numLength.Value = Convert.ToDecimal(drEvaporatorData["CoilLength"].ToString());
                    numCapacityAt10TD.Value = Convert.ToDecimal(drEvaporatorData["CapacityAt10TD"].ToString());
                    numCapacity.Value = Convert.ToDecimal(drEvaporatorData["EvaporatorCapacity"].ToString());
                    numCoilQty.Value = Convert.ToDecimal(drEvaporatorData["EvaporatorCoilQty"].ToString());
                    numFanQty.Value = Convert.ToDecimal(drEvaporatorData["EvaporatorFanQty"].ToString());
                    numLiquid.Value = Convert.ToDecimal(drEvaporatorData["Liquid"].ToString());
                    numSuction.Value = Convert.ToDecimal(drEvaporatorData["Suction"].ToString());
                    numHotGas.Value = Convert.ToDecimal(drEvaporatorData["HotGas"].ToString() == "-99" ? 0 : Convert.ToDecimal(drEvaporatorData["HotGas"].ToString()));
                    numConnQty.Value = Convert.ToDecimal(drEvaporatorData["ConnQty"].ToString());
                    numHeaterQty.Value = Convert.ToDecimal(drEvaporatorData["EvaporatorHeaterQty"].ToString());
                    numStartTemp.Value = Convert.ToDecimal(drEvaporatorData["SSucTemp"].ToString());
                    numFinishTemp.Value = Convert.ToDecimal(drEvaporatorData["FSucTemp"].ToString());
                    numBlygoldPrice.Value = Convert.ToDecimal(drEvaporatorData["BlygoldPrice"].ToString());
                    numRefCharge.Value = Convert.ToDecimal(drEvaporatorData["EvaporatorRefCharge"].ToString());
                    chkLowVelocity.Checked = Convert.ToInt32(drEvaporatorData["LowVelocity"].ToString()) == 1;
                    chkWaterCoilSelection.Checked = Convert.ToInt32(drEvaporatorData["WaterCoilSelection"].ToString()) == 1;

                    decimal faceTubes = FinTypeFaceTube();
                    decimal finHeight = coilTubes * faceTubes;

                    cboFinHeight.SelectedIndex = cboFinHeight.FindString(finHeight.ToString(CultureInfo.InvariantCulture)) > 0 ? cboFinHeight.FindString(finHeight.ToString(CultureInfo.InvariantCulture)) : 0;

                    Fill_ListOfParts();
                    GenerateCoilModel();
                //}
            }
        }

        private void GenerateCoilModel()
        {
            txtCoilModel.Text = CoilModelName();
        }

        private decimal GetCoilTubes()
        {
            decimal faceTubes = FinTypeFaceTube();
            decimal coilTubes = Convert.ToDecimal(cboFinHeight.Text) / faceTubes;
            return coilTubes;
        }

        private string CoilModelName()
        {
            //add the prefix
            string strReturnValue = "D";

            //add the fin Type
            strReturnValue = strReturnValue + FinTypeParameter();

            //add the fin shape
            strReturnValue = strReturnValue + FinShapeParameter();

            //add a dash
            strReturnValue = strReturnValue + "-";

            //add the tubes
            strReturnValue = strReturnValue + Convert.ToDecimal(GetCoilTubes()).ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');

            //add a dash
            strReturnValue = strReturnValue + "-";

            //add number of rows (make usre always 2 characters so use padleft)
            strReturnValue = strReturnValue + Convert.ToInt32(numRows.Value).ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');

            //add a dash
            strReturnValue = strReturnValue + "-";

            //add FPI (make usre always 2 characters so use padleft)
            strReturnValue = strReturnValue + cboFPI.Text.PadLeft(2, '0');

            //add a dash
            strReturnValue = strReturnValue + "-";

            //add fin length (make usre always 2 characters so use padleft)
            strReturnValue = strReturnValue + numLength.Value.ToString("0#.###");

            return strReturnValue;
        }

        private void SetTabsEnabledProperty(bool valueEnabled)
        {
            ((Control)tabCoilInfo).Enabled = valueEnabled;
            ((Control)tabParts).Enabled = valueEnabled;
        }

        private void ValidateModel()
        {
            string strModel = txtModelText.Text;

            bool error = true;

            if (strModel.Length >= 4 && strModel.Length <= 9)
            {
                if (IsAllLetter(strModel.Substring(0, 3)))
                {
                    if (IsAllNumeric(strModel.Substring(3)))
                    {
                        var splitModel = new string[2];
                        splitModel[0] = strModel.Substring(0, 3);
                        splitModel[1] = strModel.Substring(3);
                        string strEvapType = splitModel[0].Substring(0, 1);
                        //DataTable dtEvapType = Public.SelectAndSortTable(dtEvapType, "EvaporatorType = '" + strEvapType + "'", "");
                        if (Public.SelectAndSortTable(_dtEvapType, "EvaporatorType = '" + strEvapType + "'", "").Rows.Count > 0)
                        {
                            int evapType = cboEvapType.FindStringExact(Public.SelectAndSortTable(_dtEvapType, "EvaporatorType = '" + strEvapType + "'", "").Rows[0]["Description"].ToString());
                            if (evapType >= 0)
                            {
                                cboEvapType.SelectedIndex = evapType;

                                string strEvapStyle = splitModel[0].Substring(1, 1);
                                //DataTable dtEvapStyle = Public.SelectAndSortTable(dtEvapStyle, "EvaporatorStyle = '" + strEvapStyle + "'", "");
                                if (Public.SelectAndSortTable(_dtEvapStyle, "EvaporatorStyle = '" + strEvapStyle + "'", "").Rows.Count > 0)
                                {
                                    int evapStyle = cboEvapStyle.FindStringExact(Public.SelectAndSortTable(_dtEvapStyle, "EvaporatorStyle = '" + strEvapStyle + "'", "").Rows[0]["Description"].ToString());
                                    if (evapStyle >= 0)
                                    {
                                        cboEvapStyle.SelectedIndex = evapStyle;

                                        string strDefrostType = splitModel[0].Substring(2, 1);
                                        //DataTable dtDefrostType = Public.SelectAndSortTable(dtDefrostType, "DefrostTypeParameter = '" + strDefrostType + "'", "");
                                        if (Public.SelectAndSortTable(_dtDefrostType, "DefrostTypeParameter = '" + strDefrostType + "'", "").Rows.Count > 0)
                                        {
                                            int defrostType = cboDefrostType.FindStringExact(Public.SelectAndSortTable(_dtDefrostType, "DefrostTypeParameter = '" + strDefrostType + "'", "").Rows[0]["DefrostType"].ToString());
                                            if (defrostType >= 0)
                                            {
                                                cboDefrostType.SelectedIndex = defrostType;
                                                error = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (error)
            {
                Public.LanguageBox("Invalid Model Name", "Nom de modèle invalide");
            }

        }

        private void cboFinType_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillFinShape();

            FillFinHeight();

            FillFPI();
        }

        private void cboFinShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillFPI();
        }

        private void cmdDeleteModel_Click(object sender, EventArgs e)
        {
            string strModeltoDelete = txtModelText.Text;

            if (strModeltoDelete != "")
            {
                if (Public.LanguageQuestionBox("Are you sure you want to suppress this unit?", "Êtes-vous sûr de vouloir supprimer cette unité?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string tsql = "";

                    tsql += " DELETE FROM EvaporatorDefrostHeater WHERE Model = '" + strModeltoDelete + "'";
                    tsql += " DELETE FROM Evaporators WHERE EvaporatorID = '" + strModeltoDelete + "'";
                    tsql += " DELETE FROM EvaporatorFan WHERE Model = '" + strModeltoDelete + "'";
                    tsql += " DELETE FROM EvaporatorFanGuard WHERE Model = '" + strModeltoDelete + "'";
                    tsql += " DELETE FROM EvaporatorMotor WHERE Model = '" + strModeltoDelete + "'";
                    tsql += " DELETE FROM EvaporatorMotorMount WHERE Model = '" + strModeltoDelete + "'";

                    Query.Execute(tsql);

                    UpdateTableVersions();

                    RefreshEvaporatorModelList();

                    Public.LanguageBox("Delete Successful.", "Supprimé avec succès.");

                    txtModelText.Text = "";
                    txtCoilModel.Text = "";
                    lvParts.Items.Clear();
                }
            }
        }

        private void RefreshEvaporatorModelList()
        {
            cboEvapModel.Items.Clear();

            //2011-08-24 : #1081 : part of that ticket is ordering issue. ther is none, i fix this right here
            DataTable dtRefreshedModelList = Query.Select("SELECT * FROM Evaporators ORDER BY EvaporatorID");

            for (int i = 0; i < dtRefreshedModelList.Rows.Count; i++)
            {
                ComboBoxControl.AddItem(cboEvapModel, dtRefreshedModelList.Rows[i]["EvaporatorID"].ToString(), dtRefreshedModelList.Rows[i]["EvaporatorID"].ToString());
            }

            dtRefreshedModelList.Dispose();

            if (cboEvapModel.Items.Count > 0)
            {
                cboEvapModel.SelectedIndex = 0;
            }
        }

        private bool IsCoilModelValidated()
        {
            return txtCoilModel.Text != "";
        }

        private bool IsVoltageAdded()
        {
            return lvParts.Items.Count > 0;
        }

        private bool IsEvapModelValidated()
        {
            return txtModelText.Text != "";
        }

        private void btnGenerateCoilModel_Click(object sender, EventArgs e)
        {
            txtCoilModel.Text = CoilModelName();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            string strErrors = "";

            if (IsEvapModelValidated())
            {
                
            }
            else
            {
                strErrors += Public.LanguageString("You must enter a model number for this unit.\n", "Vous devez entrer un numéro de modèle pour cette unité.\n");
            }

            if (IsCoilModelValidated())
            {
                
            }
            else
            {
                strErrors += Public.LanguageString("You must generate a coil model for this model.\n", "Vous devez générer un modèle de serpentin pour ce modèle.\n");
            }

            if (IsVoltageAdded())
            {
                
            }
            else
            {
                strErrors += Public.LanguageString("You must add at least 1 voltage to the model.\n", "Vous devez ajouter au moins 1 voltage au modèle.\n");
            }

            if (strErrors != "")
            {
                MessageBox.Show(strErrors, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Save();
            }
        }

        private void Save()
        {
            if (Public.LanguageQuestionBox("Are you sure you want to save these changes?", "Êtes-vous sûr de vouloir sauvegarder ces changements?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DeleteAll();
                if (Query.Execute(BuildSaveQuery()))
                {
                    UpdateTableVersions();
                    Public.LanguageBox("Saving completed", "Sauvegarde completée");
                }
                else
                {
                    Public.LanguageBox("An error occured while saving", "Une erreur est survenue lors de la sauvegarde");
                }
                //txtModelText.Text = "";
                RefreshEvaporatorModelList();
            }
        }

        private void DeleteAll()
        {
            string strModeltoDelete = txtModelText.Text;

            if (strModeltoDelete != "")
            {
                string tsql = "";

                tsql += " DELETE FROM EvaporatorDefrostHeater WHERE Model = '" + strModeltoDelete + "'";
                tsql += " DELETE FROM Evaporators WHERE EvaporatorID = '" + strModeltoDelete + "'";
                tsql += " DELETE FROM EvaporatorFan WHERE Model = '" + strModeltoDelete + "'";
                tsql += " DELETE FROM EvaporatorFanGuard WHERE Model = '" + strModeltoDelete + "'";
                tsql += " DELETE FROM EvaporatorMotor WHERE Model = '" + strModeltoDelete + "'";
                tsql += " DELETE FROM EvaporatorMotorMount WHERE Model = '" + strModeltoDelete + "'";
                tsql += " DELETE FROM Relation_ModelVoltage WHERE UnitID = '" + strModeltoDelete + "'";

                Query.Execute(tsql);
            }
        }

        private string BuildSaveQuery()
        {
            string tsql = "";

            tsql += GetEvaporatorTSQL();
            tsql += GetEvaporatorPartsTSQL();

            return tsql;
        }

        private void UpdateTableVersions()
        {
            Query.UpdateServerTableVersion("EvaporatorDefrostHeater");
            Query.UpdateServerTableVersion("Evaporators");
            Query.UpdateServerTableVersion("EvaporatorFan");
            Query.UpdateServerTableVersion("EvaporatorFanGuard");
            Query.UpdateServerTableVersion("EvaporatorMotor");
            Query.UpdateServerTableVersion("EvaporatorMotorMount");
            Query.UpdateServerTableVersion("Relation_ModelVoltage");
            Query.UpdateServerTableVersion("v_Evaporators");
        }

        private string GetEvaporatorTSQL()
        {
            string tsql = "";
            string strModel = txtModelText.Text;

            if (strModel != "")
            {
                tsql += "INSERT INTO Evaporators (EvaporatorID, CapacityAt10TD, DefrostType, EvaporatorCapacity, EvaporatorWeight, EvaporatorCoilQty, EvaporatorFanQty, EvaporatorHeaterQTY, EvaporatorCFM, EvaporatorRefCharge, EvaporatorPrice, BlygoldPrice, LowVelocity, Liquid, Suction, HotGas, ConnQty, FanArrangement, SSucTemp, FSucTemp, EvaporatorType, Style, CoilType, CoilTubes, CoilRow, CoilFPI, CoilLength, Active, WaterCoilSelection) ";
                tsql += " VALUES( '" + strModel + "' , " + numCapacityAt10TD.Value + ", '" + DefrostTypeParameter() + "' , " + numCapacity.Value + " , " + numWeight.Value + " , " + numCoilQty.Value + " , " + numFanQty.Value + " , " + numHeaterQty.Value + " , " + numCFM.Value + " , " + numRefCharge.Value + " , " + numPrice.Value + " , " + numBlygoldPrice.Value + " , " + (chkLowVelocity.Checked ? "1" : "0") + " , " + numLiquid.Value + " , " + numSuction.Value + " , " + numHotGas.Value + " , " + numConnQty.Value + " , " + cboFanArrangement.Text.Substring(0, 1) + " , " + numStartTemp.Value + " , " + numFinishTemp.Value + " , '" + EvaporatorType() + "' , '" + EvaporatorStyle() + "' , '" + txtCoilModel.Text.Substring(0, 3) + "' , " + GetCoilTubes() + " , " + numRows.Value + " , " + cboFPI.Text + " , " + numLength.Value + " , 1 , " + (chkWaterCoilSelection.Checked ? "1" : "0") + ")";
            }

            return tsql;
        }

        private string GetEvaporatorPartsTSQL()
        {
            string tsql = "";
            string strModel = txtModelText.Text;

            if (strModel != "")
            {
                for (int i = 0; i < lvParts.Items.Count; i++)
                {
                    string strVoltageID = lvParts.Items[i].SubItems[0].Text;

                    tsql += " INSERT INTO EvaporatorMotor (Model,VoltageID,Motor) ";
                    tsql += " VALUES ('" + strModel + "' , " + strVoltageID + " , '" + lvParts.Items[i].SubItems[2].Control.Text + "') ";

                    tsql += " INSERT INTO EvaporatorMotorMount (Model,VoltageID,MotorMount) ";
                    tsql += " VALUES ('" + strModel + "' , " + strVoltageID + " , '" + lvParts.Items[i].SubItems[3].Control.Text + "') ";

                    tsql += " INSERT INTO EvaporatorFan (Model,VoltageID,Fan) ";
                    tsql += " VALUES ('" + strModel + "' , " + strVoltageID + " , '" + lvParts.Items[i].SubItems[4].Control.Text + "') ";

                    tsql += " INSERT INTO EvaporatorFanGuard (Model,VoltageID,FanGuard) ";
                    tsql += " VALUES ('" + strModel + "' , " + strVoltageID + " , '" + lvParts.Items[i].SubItems[5].Control.Text + "') ";

                    tsql += " INSERT INTO EvaporatorDefrostHeater (Model,VoltageID,DefrostHeater) ";
                    tsql += " VALUES ('" + strModel + "' , " + strVoltageID + " , '" + lvParts.Items[i].SubItems[6].Control.Text + "') ";

                    tsql += " INSERT INTO Relation_ModelVoltage(UnitID, VoltageID) ";
                    tsql += " VALUES ('" + strModel + "' , " + strVoltageID + ") ";
                }
            }

            return tsql;
        }

        private void Fill_ListOfParts()
        {
            lvParts.Items.Clear();

            DataTable dtValidVoltage = Query.Select("Select * from Relation_ModelVoltage as rmv left join MainVoltage as v on rmv.voltageid = v.voltageid where rmv.unitid = '" + cboEvapModel.Text + "'");

            foreach (DataRow row in dtValidVoltage.Rows)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lvParts);

                myItem.SubItems[0].Text = row["VoltageID"].ToString();
                myItem.SubItems[1].Text = row["VoltDescription"].ToString();

                ComboBox cboMotor = GetPartCombobox();
                ComboBox cboMotorMount = GetPartCombobox();
                ComboBox cboFan = GetPartCombobox();
                ComboBox cboFanGuard = GetPartCombobox();
                ComboBox cboDefrostHeater = GetPartCombobox();

                Fill_Motor(ref cboMotor, Convert.ToInt32(row["VoltageID"]));
                Fill_MotorMount(ref cboMotorMount);
                Fill_Fan(ref cboFan);
                Fill_FanGuard(ref cboFanGuard);
                Fill_DefrostHeater(ref cboDefrostHeater);

                myItem.SubItems[2].Control = cboMotor;
                myItem.SubItems[3].Control = cboMotorMount;
                myItem.SubItems[4].Control = cboFan;
                myItem.SubItems[5].Control = cboFanGuard;
                myItem.SubItems[6].Control = cboDefrostHeater;

                lvParts.Items.Add(myItem);
            }

            LoadParts();

            lvParts.Refresh();
        }

        private string getDefault_Motor( string model, string voltageID)
        {
            string Default = "";

            DataTable dt = Query.Select("SELECT * FROM EvaporatorMotor WHERE Model = '" + model + "' AND VoltageID = " + voltageID);

            if (dt.Rows.Count > 0)
            {
                Default = dt.Rows[0]["Motor"].ToString();
            }

            return Default;
        }

        private string getDefault_MotorMount(string model, string voltageID)
        {
            string Default = "";

            DataTable dt = Query.Select("SELECT * FROM EvaporatorMotorMount WHERE Model = '" + model + "' AND VoltageID = " + voltageID);

            if (dt.Rows.Count > 0)
            {
                Default = dt.Rows[0]["MotorMount"].ToString();
            }

            return Default;
        }

        private string getDefault_Fan(string model, string voltageID)
        {
            string Default = "";

            DataTable dt = Query.Select("SELECT * FROM EvaporatorFan WHERE Model = '" + model + "' AND VoltageID = " + voltageID);

            if (dt.Rows.Count > 0)
            {
                Default = dt.Rows[0]["Fan"].ToString();
            }

            return Default;
        }

        private string getDefault_FanGuard(string model, string voltageID)
        {
            string Default = "";

            DataTable dt = Query.Select("SELECT * FROM EvaporatorFanGuard WHERE Model = '" + model + "' AND VoltageID = " + voltageID);
            
            if (dt.Rows.Count > 0)
            {
                Default = dt.Rows[0]["FanGuard"].ToString();
            }

            return Default;
        }

        private string getDefault_DefrostHeater(string model, string voltageID)
        {
            string Default = "";

            DataTable dt = Query.Select("SELECT * FROM EvaporatorDefrostHeater WHERE Model = '" + model + "' AND VoltageID = " + voltageID);

            if (dt.Rows.Count > 0)
            {
                Default = dt.Rows[0]["DefrostHeater"].ToString();
            }

            return Default;
        }

        private void LoadParts()
        {
            for (int i = 0; i < lvParts.Items.Count; i++)
            {
                string defaultMotor = getDefault_Motor(txtModelText.Text, lvParts.Items[i].SubItems[0].Text);
                string defaultMotorMount = getDefault_MotorMount(txtModelText.Text, lvParts.Items[i].SubItems[0].Text);
                string defaultFan = getDefault_Fan(txtModelText.Text, lvParts.Items[i].SubItems[0].Text);
                string defaultFanGuard = getDefault_FanGuard(txtModelText.Text, lvParts.Items[i].SubItems[0].Text);
                string defaultDefrostHeater = getDefault_DefrostHeater(txtModelText.Text, lvParts.Items[i].SubItems[0].Text);

                if (((ComboBox)lvParts.Items[i].SubItems[2].Control).FindString(defaultMotor) >= 0)
                {
                    ((ComboBox)lvParts.Items[i].SubItems[2].Control).SelectedIndex = ((ComboBox)lvParts.Items[i].SubItems[2].Control).FindString(defaultMotor);
                }

                if (((ComboBox)lvParts.Items[i].SubItems[3].Control).FindString(defaultMotorMount) >= 0)
                {
                    ((ComboBox)lvParts.Items[i].SubItems[3].Control).SelectedIndex = ((ComboBox)lvParts.Items[i].SubItems[3].Control).FindString(defaultMotorMount);
                }

                if (((ComboBox)lvParts.Items[i].SubItems[4].Control).FindString(defaultFan) >= 0)
                {
                    ((ComboBox)lvParts.Items[i].SubItems[4].Control).SelectedIndex = ((ComboBox)lvParts.Items[i].SubItems[4].Control).FindString(defaultFan);
                }

                if (((ComboBox)lvParts.Items[i].SubItems[5].Control).FindString(defaultFanGuard) >= 0)
                {
                    ((ComboBox)lvParts.Items[i].SubItems[5].Control).SelectedIndex = ((ComboBox)lvParts.Items[i].SubItems[5].Control).FindString(defaultFanGuard);
                }

                if (((ComboBox)lvParts.Items[i].SubItems[6].Control).FindString(defaultDefrostHeater) >= 0)
                {
                    ((ComboBox)lvParts.Items[i].SubItems[6].Control).SelectedIndex = ((ComboBox)lvParts.Items[i].SubItems[6].Control).FindString(defaultDefrostHeater);
                }
            }
        }

        private void numHeaterQty_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lvParts.Items.Count; i++)
            {
                if (numHeaterQty.Value != 0)
                {
                    lvParts.Items[i].SubItems[6].Control.Enabled = true;
                }
                else
                {
                    ((ComboBox)lvParts.Items[i].SubItems[6].Control).SelectedIndex = ((ComboBox)lvParts.Items[i].SubItems[6].Control).FindString("Not Available");
                    lvParts.Items[i].SubItems[6].Control.Enabled = false;
                }
            }
        }

        private void btnAddVoltage_Click(object sender, EventArgs e)
        {
            bool voltageExists = false;

            for (int i = 0; i < lvParts.Items.Count; i++)
            {
                if (lvParts.Items[i].SubItems[1].Text == cboVoltage.Text)
                {
                    Public.LanguageBox("The selected voltage already exists for this model.", "La voltage sélectionné existe déjà pour ce modèle.");
                    voltageExists = true;
                    i = lvParts.Items.Count;
                }
            }

            if (!voltageExists)
            {
                ComboBox cboMotor = GetPartCombobox();
                ComboBox cboMotorMount = GetPartCombobox();
                ComboBox cboFan = GetPartCombobox();
                ComboBox cboFanGuard = GetPartCombobox();
                ComboBox cboDefrostHeater = GetPartCombobox();

                Fill_Motor(ref cboMotor, Convert.ToInt32(ComboBoxControl.IndexInformation(cboVoltage)));
                Fill_MotorMount(ref cboMotorMount);
                Fill_Fan(ref cboFan);
                Fill_FanGuard(ref cboFanGuard);
                Fill_DefrostHeater(ref cboDefrostHeater);

                var myItem = new GlacialComponents.Controls.GLItem(lvParts);
                myItem.SubItems[0].Text = ComboBoxControl.IndexInformation(cboVoltage);
                myItem.SubItems[1].Text = cboVoltage.Text;
                myItem.SubItems[2].Control = cboMotor;
                myItem.SubItems[3].Control = cboMotorMount;
                myItem.SubItems[4].Control = cboFan;
                myItem.SubItems[5].Control = cboFanGuard;
                myItem.SubItems[6].Control = cboDefrostHeater;

                lvParts.Items.Add(myItem);
            }
            lvParts.Refresh();
        }

        private void btnRemoveVoltage_Click(object sender, EventArgs e)
        {
            if (lvParts.SelectedItems.Count > 0)
            {
                DialogResult result = Public.LanguageQuestionBox("Are you sure you wish to remove this voltage?", "Êtes-vous sûr de vouloir supprimer ce voltage?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    lvParts.Items.RemoveAt(lvParts.Items.FindItemIndex((GlacialComponents.Controls.GLItem)lvParts.SelectedItems[0]));
                }
            }
            else
            {
                Public.LanguageBox("You must select a voltage to remove.", "Vous devez sélectionner une voltage à supprimer.");
            }
            lvParts.Refresh();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmEvaporatorModel_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }

        private void cboVoltage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboFanArrangement_SelectedIndexChanged(object sender, EventArgs e)
        {
            int fanQTY = Convert.ToInt32(cboFanArrangement.Text.Substring(0, 1)) * Convert.ToInt32(cboFanArrangement.Text.Substring(4, 1));
            numFanQty.Value = Convert.ToDecimal(fanQTY);
        }

        
    }
}