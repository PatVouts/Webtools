using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Collections;

namespace RefplusWebtools.QuickFluidCooler
{
    public partial class FrmQuickFluidCooler : Form
    {
        //form need access to his background code
        private readonly FluidCoolerCode _backgroundCode = new FluidCoolerCode();
        //dataset holding last values of selection
        private DataSet _dsFluidCoolerList = new DataSet();
        //list of table the form use
        private readonly string[] _strTableList = { "FluidCoolerModel", "FluidCoolerFanArrangement", "FluidCoolerFinMaterial", "FluidCoolerFluidType", "Voltage", "CoilInfo", "ElectroFinAdjustement", "HeresiteSafety", "AirFlowType", "FluidCoolerFPI", "FluidCoolerLegs", "CoilTubeMaterial", "CoilFinMaterial", "v_CoilFinDefaults", "v_CoilTubeDefaults", "Weather", "Density_Ethylene", "Density_Propylene", "Density_Water", "SensibleHeat_Water", "SensibleHeat_Ethylene", "SensibleHeat_Propylene", "FreezingPointPropylene", "FreezingPointEthylene", "MotorFLA", "ControlPanel_SpecialPrice", "ControlPanel_PanelOptionPrices", "ControlPanel_Options", "ControlPanel_OptionsSelection", "ControlPanel_Panels", "ControlPanel_PanelsSelection", "ControlPanel_PanelVoltage", "PumpOption", "ReceiverType", "ReceiverModels", "ReceiverHeater", "ReceiverTransformers", "ReceiverValves", "PumpAmps", "PumpGPM", "PumpHP", "PumpInfo", "PumpSelection", "PumpTubeDiameter", "HeatRejectionFactor", "ReceiverReinforcedBasePrice", "ControlPanel_PanelPrices" };
        
        //tables that holds all selected values over the multiple windows
        DataTable _dtControlPanelInputs = new DataTable();
        DataTable _dtPumpInputs = new DataTable();
        DataTable _dtSecondaryOptionsInputs = new DataTable();

        //this is used to build the approval drawing nomenclature.
        //since the value is in the secondary form we need to retreive it then use it.
        private string _legNomenclature = "";
        private bool _legInstalled;

        //link to the quote form
        private readonly Quotes.FrmQuotes _quoteform;
        //dataset of the quote
        private readonly DataSet _dsQuoteData;
        //index of the row, -1 mean not loading so we know it's a new record
        private readonly int _intIndex = -1;
        //is true if the form is loaded from quote, false if loaded ordinary
        private readonly bool _bolQuoteSelection;

        private bool _isLoading = true;
        private bool _valueHaveChanged;

        public FrmQuickFluidCooler(Quotes.FrmQuotes quoteform, DataSet dsQuoteData, int intIndex)
        {
            InitializeComponent();
            _quoteform = quoteform;
            _dsQuoteData = dsQuoteData;
            _intIndex = intIndex;
            _bolQuoteSelection = true;
        }

        public FrmQuickFluidCooler()
        {
            InitializeComponent(); 
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void ConfirmChangesHappen()
        {
            if (!_isLoading)
            {
                _valueHaveChanged = true;
            }
        }

        private void frmQuickFluidCooler_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            //load into memory the needed tables
            Query.LoadTables(_strTableList);

            //make sure columns are added correctly
            Query.Set_FluidCoolerModel(Public.DSDatabase.Tables["FluidCoolerModel"]);

            //this call all the fill combobox function needed
            Fill_Combobox();

            //this function sets all the defaults at loading
            SetDefaults();

            ThreadProcess.Stop();
            Focus();
            if (_bolQuoteSelection && _intIndex != -1)
            {
                LoadSavedData();
            }


            _isLoading = false;
        }

        private void AutoSelectTextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }

        private void LoadSavedData()
        {
            //will contain all errors
            string strErrors = "";

            DataTable dtSavedInfo = Public.SelectAndSortTable(_dsQuoteData.Tables["FluidCoolers"], "ItemType = " + Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.FluidCooler) + " AND ItemID = " + _intIndex, "");
            DataRow drSavedInfo = dtSavedInfo.NewRow();
            drSavedInfo.ItemArray = dtSavedInfo.Rows[0].ItemArray;

            txtTag.Text = drSavedInfo["Input_Tag"].ToString();

            numQuantity.Value = Convert.ToDecimal(drSavedInfo["Quantity"]);

            if (cboLocation.FindString(drSavedInfo["Input_Location"].ToString()) >= 0)
            {
                cboLocation.SelectedIndex = cboLocation.FindString(drSavedInfo["Input_Location"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected location", "- Incapable de trouver l'endroit sélectionné") + Environment.NewLine;
            }

            numEDB.Value = Convert.ToDecimal(drSavedInfo["Input_EDB"]);

            numAltitude.Value = Convert.ToDecimal(drSavedInfo["Input_Altitude"]);

            numELT.Value = Convert.ToDecimal(drSavedInfo["Input_ELT"]);

            if (cboFluidType.FindString(drSavedInfo["Input_FluidType"].ToString()) >= 0)
            {
                cboFluidType.SelectedIndex = cboFluidType.FindString(drSavedInfo["Input_FluidType"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected fluid type", "- Incapable de trouver le type de fluide sélectionné") + Environment.NewLine;
            }

            numConcentration.Value = Convert.ToDecimal(drSavedInfo["Input_Concentration"]);

            txtFluidTypeName.Text = drSavedInfo["Input_FluidTypeName"].ToString();

            numSpecificHeat.Value = Convert.ToDecimal(drSavedInfo["Input_SpecificHeat"]);

            numDensity.Value = Convert.ToDecimal(drSavedInfo["Input_Density"]);

            numViscosity.Value = Convert.ToDecimal(drSavedInfo["Input_Viscosity"]);

            numThermalConductivity.Value = Convert.ToDecimal(drSavedInfo["Input_ThermalConductivity"]);

            numPSI.Value = Convert.ToDecimal(drSavedInfo["Input_MaxFluidPressure"]);

            if (cboUnitType.FindString(drSavedInfo["Input_UnitType"].ToString()) >= 0)
            {
                cboUnitType.SelectedIndex = cboUnitType.FindString(drSavedInfo["Input_UnitType"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected unit type", "- Incapable de trouver le type d'unité sélectionné") + Environment.NewLine;
            }

            if (cboFanArrangement.FindString(drSavedInfo["Input_FanArrangement"].ToString()) >= 0)
            {
                cboFanArrangement.SelectedIndex = cboFanArrangement.FindString(drSavedInfo["Input_FanArrangement"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected fan arrangement", "- Incapable de trouver l'arrangement des ailettes sélectionné") + Environment.NewLine;
            }

            numLeavingLiquidTemperature.Value = Convert.ToDecimal(drSavedInfo["Input_LLT"]);

            numUSGPM.Value = Convert.ToDecimal(drSavedInfo["Input_USGPM"]);

            numTotalHeat.Value = Convert.ToDecimal(drSavedInfo["Input_MBH"]);

            if (cboGPM_TotalHeat.FindString(drSavedInfo["Input_USGPM_MBH"].ToString()) >= 0)
            {
                cboGPM_TotalHeat.SelectedIndex = cboGPM_TotalHeat.FindString(drSavedInfo["Input_USGPM_MBH"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected multichoice selection criteria", "- Incapable de trouver le critère de sélection à choix multiple sélectionné") + Environment.NewLine;
            }

            if (drSavedInfo["Input_RatingLLT"].ToString() == "1")
            {
                radRatingLLT.Checked = true;
            }
            else
            {
                radRatingGPM.Checked = true;
            }

            if (cboAirFlowType.FindString(drSavedInfo["Input_AirFlowType"].ToString()) >= 0)
            {
                cboAirFlowType.SelectedIndex = cboAirFlowType.FindString(drSavedInfo["Input_AirFlowType"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected air flow type", "- Incapable de trouver le type de débit d'air sélectionné") + Environment.NewLine;
            }

            if (cboFPI.FindString(drSavedInfo["Input_FPI"].ToString()) >= 0)
            {
                cboFPI.SelectedIndex = cboFPI.FindString(drSavedInfo["Input_FPI"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected fins per inch", "- Incapable de trouver le nombre d'ailettes par pouces sélectionné") + Environment.NewLine;
            }

            if (cboFilter.FindString(drSavedInfo["Input_Filter"].ToString()) >= 0)
            {
                cboFilter.SelectedIndex = cboFilter.FindString(drSavedInfo["Input_Filter"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected filter", "- Incapable de trouver le filtre sélectionné") + Environment.NewLine;
            }

            if (cboModel.FindString(drSavedInfo["Input_Model"].ToString()) >= 0)
            {
                cboModel.SelectedIndex = cboModel.FindString(drSavedInfo["Input_Model"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected specific model filter", "- Incapable de trouver le filtre de modèle spécifique sélectionné") + Environment.NewLine;
            }

            //2012-02-15 : #2664 : changing loading order. something changed somewhere that cause the voltage to refresh
            //anyway the loading order could not stay as his without issues.
            if (cboVoltage.FindString(drSavedInfo["Input_Voltage"].ToString()) >= 0)
            {
                cboVoltage.SelectedIndex = cboVoltage.FindString(drSavedInfo["Input_Voltage"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected voltage", "- Incapable de trouver le voltage sélectionné") + Environment.NewLine;
            }

            RunSelection();

            bool bolFoundModel = false;

            for (int iresult = 0; iresult < lvFluidCooler.Items.Count; iresult++)
            {
                if (!bolFoundModel)
                {
                    if (lvFluidCooler.Items[iresult].SubItems[1].Text == drSavedInfo["FluidCoolerModel"] + @"-" + drSavedInfo["fin"] + drSavedInfo["cir1"])
                    {
                        bolFoundModel = true;
                        lvFluidCooler.Items[iresult].Selected = true;
                        lvFluidCooler.Select();
                    }
                }
            }

            if (!bolFoundModel)
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected model", "- Incapable de trouver le modèle sélectionné") + Environment.NewLine;
            }

            if (strErrors != "")
            {
                MessageBox.Show(Public.LanguageString("The following error(s) happened while loading", "La/Les erreur(s) suivantes sont survenue(s) lors du chargement") + Environment.NewLine + strErrors, Public.LanguageString("Error while loading", "Erreur lors du chargement"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Fill_Combobox()
        {
            //fill the model list of cboModel
            Fill_ModelList();

            //fill the fluid type combobox
            Fill_FluidType();

            //fill the unit type
            Fill_UnitType();

            //fill air flow type
            Fill_AirFlowType();

            //fill FPI
            Fill_FPI();

            //fill location
            Fill_Location();
        }

        private void SetDefaults()
        {
            //WTR = 1
            ComboBoxControl.SetIDDefaultValue(cboFluidType, "1");

            //240/3/60 = 3
            ComboBoxControl.SetIDDefaultValue(cboVoltage, "3");

            //ALL = ALL
            ComboBoxControl.SetIDDefaultValue(cboUnitType, "STANDARD PRODUCT LINE");

            //USGPM
            //this control doesn't use the same format as other combobox
            //its a normal combobox with hardcoded option in Design Mode
            cboGPM_TotalHeat.SelectedIndex = 0;

            //this control doesn't use the same format as other combobox
            //its a normal combobox with hardcoded option in Design Mode
            cboFilter.SelectedIndex = 0;

            ////ALL = ALL
            //ComboBoxControl.SetIDDefaultValue(cboModel, "ALL");

            //set air flow type vertical = 2
            ComboBoxControl.SetIDDefaultValue(cboAirFlowType, "2");

            //set the dpi to standard
            cboFPI.SelectedIndex = 0;
        }

        //refresh the location informations
        private void RefreshLocationWeatherInfromations()
        {
            numEDB.Value = LocationSummerDB();
            numAltitude.Value = LocationAltitude();
        }

        //return the location altitude
        private decimal LocationAltitude()
        {
            return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboLocation, Public.DSDatabase.Tables["Weather"], "UniqueID")[0]["Altitude"]);
        }

        //return the location Summer DB
        private decimal LocationSummerDB()
        {
            return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboLocation, Public.DSDatabase.Tables["Weather"], "UniqueID")[0]["SummerDryBulb"]);
        }

        //fill locations
        private void Fill_Location()
        {
            cboLocation.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox

            //sort the weather informations
            DataTable dtSortedWeather = _backgroundCode.OrderWeatherInformations(Public.DSDatabase.Tables["Weather"]);

            //for each location
            foreach (DataRow drLocation in dtSortedWeather.Rows)
            {
                string strIndex = drLocation["UniqueID"].ToString();
                //format ex : "CAN, QC, Montréal"
                string strText = drLocation["Country"] + ", " + drLocation["State"] + ", " + drLocation["City"];
                ComboBoxControl.AddItem(cboLocation, strIndex, strText);
            }

            //select the one we have saved in registry or first if nothing
            ComboBoxControl.SetIDDefaultValue(cboLocation, Reg.Get(Reg.Key.Location));
        }

        private string FPIParameter()
        {
            return ComboBoxControl.ItemInformations(cboFPI, Public.DSDatabase.Tables["FluidCoolerFPI"], "UniqueID")[0]["FPIParameter"].ToString();
        }

        private void Fill_FPI()
        {
            cboFPI.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox
            //loop through all fpi
            foreach (DataRow drFPI in Public.DSDatabase.Tables["FluidCoolerFPI"].Rows)
            {
                string strIndex = drFPI["UniqueID"].ToString();
                string strText = drFPI["FPI"].ToString();
                ComboBoxControl.AddItem(cboFPI, strIndex, strText);
            }
        }

        private string AirFlowTypeParameter()
        {
            return ComboBoxControl.ItemInformations(cboAirFlowType, Public.DSDatabase.Tables["AirFlowType"], "UniqueID")[0]["AirFlowTypeParameter"].ToString();
        }

        private void Fill_AirFlowType()
        {
            cboAirFlowType.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox
            //loop through all air flow type
            foreach (DataRow drAirFlowType in Public.DSDatabase.Tables["AirFlowType"].Rows)
            {
                string strIndex = drAirFlowType["UniqueID"].ToString();
                string strText = drAirFlowType["AirFlowType"].ToString();
                ComboBoxControl.AddItem(cboAirFlowType, strIndex, strText);
            }
        }

        //this return the Fan Adjustement 
        private string FanArangementParameter()
        {
            if (ComboBoxControl.IndexInformation(cboFanArrangement) == "ALL")
            {//if ALL return ALL
                return "ALL";
            }
            //if Not ALL return "(fanlong)x(fanwide)"
            return ComboBoxControl.ItemInformations(cboFanArrangement, Public.DSDatabase.Tables["FluidCoolerFanArrangement"], "UniqueID")[0]["FanWide"] + "x" + ComboBoxControl.ItemInformations(cboFanArrangement, Public.DSDatabase.Tables["FluidCoolerFanArrangement"], "UniqueID")[0]["FanLong"];
        }

        private void Fill_FanArrangement()
        {
            cboFanArrangement.Items.Clear();
            ComboBoxControl.AddItem(cboFanArrangement, "ALL", "ALL");
            //these variable as use for easier modification of index or text showing
            //in the combobox

            DataTable dtFilteredFanArrangmeentList = _backgroundCode.GetFanArrangement(Public.DSDatabase.Tables["FluidCoolerFanArrangement"], UnitTypeMotor(), UnitTypeCoilArrangement());

            //loop through all fan arrangement
            foreach (DataRow drFanArrangement in dtFilteredFanArrangmeentList.Rows)
            {
                string strIndex = drFanArrangement["UniqueID"].ToString();
                string strText = drFanArrangement["FanArrangement"].ToString();
                ComboBoxControl.AddItem(cboFanArrangement, strIndex, strText);
            }

            dtFilteredFanArrangmeentList.Dispose();

            if (cboFanArrangement.Items.Count > 0)
            {
                cboFanArrangement.SelectedIndex = 0;
            }
        }

        private string[] UnitTypeCoilArrangement()
        {
            //list of unit type
            string[] strUnitTypes = ComboBoxControl.IndexInformation(cboUnitType).Split(Convert.ToChar(","));

            //array that will contain the list of unit type
            var strCoilArrangement = new string[strUnitTypes.Length];

            //fill the array
            for (int intUnitTypes = 0; intUnitTypes < strUnitTypes.Length; intUnitTypes++)
            {
                strCoilArrangement[intUnitTypes] = strUnitTypes[intUnitTypes].Substring(1, 1);
            }

            return strCoilArrangement;
        }

        private string[] UnitTypeMotor()
        {
            //list of unit type
            string[] strUnitTypes = ComboBoxControl.IndexInformation(cboUnitType).Split(Convert.ToChar(","));

            //array that will contain the list of unit type
            var strMotors = new string[strUnitTypes.Length];

            //fill the array
            for (int intUnitTypes = 0; intUnitTypes < strUnitTypes.Length; intUnitTypes++)
            {
                strMotors[intUnitTypes] = strUnitTypes[intUnitTypes].Substring(0, 1);
            }

            return strMotors;
        }

        private void Fill_UnitType()
        {
            cboUnitType.Items.Clear();
            ComboBoxControl.AddItem(cboUnitType, "CD,MD,LD,VD,ND", "STANDARD PRODUCT LINE");
            //these variable as use for easier modification of index or text showing
            //in the combobox
            //loop through all coil info
            foreach (DataRow drUnitType in Public.DSDatabase.Tables["CoilInfo"].Rows)
            {
                string strIndex = drUnitType["Motor"] + drUnitType["CoilArr"].ToString();
                string strText = drUnitType["Motor"].ToString().Replace("S", "V") + drUnitType["CoilArr"] + " - " + drUnitType["Description"];
                ComboBoxControl.AddItem(cboUnitType, strIndex, strText);
            }
        }

        private string UnitTypeParameter()
        {
            return ComboBoxControl.IndexInformation(cboUnitType);
        }

        //Voltage CoilArr
        private string[] VoltageCoilArr()
        {
            //list of unit type
            string[] strVoltage = ComboBoxControl.ItemInformations(cboVoltage, Public.DSDatabase.Tables["Voltage"], "UniqueID")[0]["MotorCoilArr"].ToString().Split(Convert.ToChar(","));

            //array that will contain the list of coilarr
            var strCoilArrangement = new string[strVoltage.Length];

            //fill the array
            for (int intVoltage = 0; intVoltage < strVoltage.Length; intVoltage++)
            {
                strCoilArrangement[intVoltage] = strVoltage[intVoltage].Substring(1, 1);
            }

            return strCoilArrangement;
        }

        //Voltage Motor
        private string[] VoltageMotor()
        {
            //list of unit type
            string[] strVoltage = ComboBoxControl.ItemInformations(cboVoltage, Public.DSDatabase.Tables["Voltage"], "UniqueID")[0]["MotorCoilArr"].ToString().Split(Convert.ToChar(","));

            //array that will contain the list of motor
            var strMotor = new string[strVoltage.Length];

            //fill the array
            for (int intVoltage = 0; intVoltage < strVoltage.Length; intVoltage++)
            {
                strMotor[intVoltage] = strVoltage[intVoltage].Substring(0, 1);
            }

            return strMotor;
        }

        //this return the voltage id
        private int VoltageID()
        {
            return Convert.ToInt32(ComboBoxControl.ItemInformations(cboVoltage, Public.DSDatabase.Tables["Voltage"], "UniqueID")[0]["VoltageID"]);
        }

        private void Fill_Voltage_Filter(string motorCoilArr)
        {
            //2012-03-01 : #2664 : Voltage must always stay the same
            string defaultVoltage = ComboBoxControl.IndexInformation(cboVoltage);

            cboVoltage.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox
            string query = "";

            string[] array = motorCoilArr.Split(',');
            for (int i = 0; i < array.Length; i++)
            {
                query = query + " MotorCoilArr LIKE '%" + array[i] + "%' OR ";
            }
            query = query.Substring(0, query.Length - 3);
            DataTable dtVoltage = Public.SelectAndSortTable(Public.DSDatabase.Tables["Voltage"], query, "VoltDescription");

            //for each voltage
            foreach (DataRow drVoltage in dtVoltage.Rows)
            {
                //2011-05-27 : We add 120v to the voltage table but it must not be available in condenser and fluid cooler
                if (drVoltage["VoltageID"].ToString() != "1")
                {
                    string strIndex = drVoltage["UniqueID"].ToString();
                    string strText = drVoltage["VoltDescription"].ToString();
                    ComboBoxControl.AddItem(cboVoltage, strIndex, strText);
                }
            }

            ComboBoxControl.SetIDDefaultValueIfExistOnly(cboVoltage, defaultVoltage);

            if (cboVoltage.SelectedIndex == -1)
            {
                ComboBoxControl.SetIDDefaultValue(cboVoltage, "3");
            }
        }

        //this return the power Adjustement factor of the voltage
        private float Voltage_AdjustementFactor()
        {
            return float.Parse(ComboBoxControl.ItemInformations(cboVoltage, Public.DSDatabase.Tables["Voltage"], "UniqueID")[0]["PowerFactorAdjustement"].ToString());
        }

        private void cmdRunSelection_Click(object sender, EventArgs e)
        {
            RunSelection();
        }

        private void RunSelection()
        {
            if (CheckIfInputValuesAreGood())
            {
                //start working process
                ThreadProcess.Start(Public.LanguageString("Running Selection", "Sélection en cours"));

                //clear the item of the list view
                lvFluidCooler.Items.Clear();

                //this variable is 0 is ran on gpm or = to the mbh if ran on mbh mode
                decimal decMBH = 0m;

                //if it's MBH
                if (cboGPM_TotalHeat.Text == @"MBH")
                {
                    //calculate the gpm with all the values and set it into the usgpm numeric
                    //up down.
                    numUSGPM.Value = _backgroundCode.MBH_to_GPM(numTotalHeat.Value, numELT.Value, numLeavingLiquidTemperature.Value, FluidTypeParameter(), numConcentration.Value);
                    decMBH = numTotalHeat.Value;
                }

                var fltLeavingLiquidTemp = (float)numLeavingLiquidTemperature.Value;
                var fltGPM = (float)numUSGPM.Value;

                //if rating
                //put the value we are looking for at -1 so we know which function to run on.
                if (cboFilter.SelectedIndex == 1)
                {
                    //if llt is the one checked
                    if (radRatingLLT.Checked)
                    {
                        fltGPM = -1f;
                    }
                    else //gpm is selected
                    {
                        fltLeavingLiquidTemp = -1f;
                    }
                }

                //filter, calculate and output the fluid cooler respecting our criteria
                _dsFluidCoolerList = new DataSet();
                _dsFluidCoolerList = _backgroundCode.Process_SelectFluidCooler(Public.DSDatabase.Tables["FluidCoolerModel"].Copy(), cboFilter.Text, fltLeavingLiquidTemp, (float)numPSI.Value, 140f, UnitTypeMotor(), UnitTypeCoilArrangement(), VoltageMotor(), VoltageCoilArr(), FanArangementParameter(), ModelListParameter(), AirFlowTypeParameter(), (float)numEDB.Value, FluidTypeParameter(), (float)numELT.Value, (float)numAltitude.Value, (float)numConcentration.Value, fltGPM, 1.08f, 1f, Voltage_AdjustementFactor(), (float)numSpecificHeat.Value, (float)numDensity.Value, (float)numViscosity.Value, (float)numThermalConductivity.Value, cboVoltage.Text, txtFluidTypeName.Text, FPIParameter(), VoltageID(), decMBH);

                ModifyFluidCoolerTables();

                //we output the result in the listview
                for (int intModels = 0; intModels < _dsFluidCoolerList.Tables["FluidCoolers"].Rows.Count; intModels++)
                {
                    lvFluidCooler.Items.Add(new ListViewItem(new[] { intModels.ToString(CultureInfo.InvariantCulture), _dsFluidCoolerList.Tables["FluidCoolers"].Rows[intModels]["FluidCoolerModel"] + "-" + _dsFluidCoolerList.Tables["FluidCoolers"].Rows[intModels]["fin"] + _dsFluidCoolerList.Tables["FluidCoolers"].Rows[intModels]["cir1"], _dsFluidCoolerList.Tables["FluidCoolers"].Rows[intModels]["LeavingLiquid"].ToString(), _dsFluidCoolerList.Tables["FluidCoolers"].Rows[intModels]["LeavingAir"].ToString(), _dsFluidCoolerList.Tables["FluidCoolers"].Rows[intModels]["GPM"].ToString(), _dsFluidCoolerList.Tables["FluidCoolers"].Rows[intModels]["Cap"].ToString(), _dsFluidCoolerList.Tables["FluidCoolers"].Rows[intModels]["PressureDrop"].ToString(), _dsFluidCoolerList.Tables["FluidCoolers"].Rows[intModels]["LiquidVelocity"].ToString() }));
                }

                //if no fluid cooler found
                if (lvFluidCooler.Items.Count < 1)
                {
                    Public.LanguageBox("No Fluid Cooler found for given parameter.", "Aucun Refroidisseur Liquide n'a été trouvé avec les paramètres entrés.");
                }

                _valueHaveChanged = false;

                //stop working process
                ThreadProcess.Stop();
                Focus();
            }
        }

        private void ModifyFluidCoolerTables()
        {
            //dsFluidCoolerList.Tables.Add(Tables.dtFluidCooler());
            //dsFluidCoolerList.Tables["FluidCoolers"].n
            DataTable dtNewTable = Tables.DtFluidCooler();

            foreach (DataTable dtModelTable in _dsFluidCoolerList.Tables)
            {
                if (dtModelTable.Rows.Count > 0)
                {
                    DataRow drNewTable = dtNewTable.NewRow();

                    drNewTable["QuoteID"] = 0;
                    drNewTable["QuoteRevision"] = 0;
                    drNewTable["QuoteRevisionText"] = "";
                    drNewTable["ItemType"] = Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.FluidCooler);
                    drNewTable["ItemID"] = 0;
                    drNewTable["Username"] = "";

                    drNewTable["Input_Tag"] = txtTag.Text;
                    drNewTable["Quantity"] = numQuantity.Value;
                    drNewTable["Input_Filter"] = cboFilter.Text;
                    drNewTable["Input_Model"] = cboModel.Text;
                    drNewTable["Input_Location"] = cboLocation.Text;
                    drNewTable["Input_EDB"] = numEDB.Value;
                    drNewTable["Input_Altitude"] = numAltitude.Value;
                    drNewTable["Input_ELT"] = numELT.Value;
                    drNewTable["Input_FluidType"] = cboFluidType.Text;
                    drNewTable["Input_Concentration"] = numConcentration.Value;
                    drNewTable["Input_FluidTypeName"] = txtFluidTypeName.Text;
                    drNewTable["Input_SpecificHeat"] = numSpecificHeat.Value;
                    drNewTable["Input_Density"] = numDensity.Value;
                    drNewTable["Input_Viscosity"] = numViscosity.Value;
                    drNewTable["Input_ThermalConductivity"] = numThermalConductivity.Value;
                    drNewTable["Input_Voltage"] = cboVoltage.Text;
                    drNewTable["Input_MaxFluidPressure"] = numPSI.Value;
                    drNewTable["Input_UnitType"] = cboUnitType.Text;
                    drNewTable["Input_FanArrangement"] = cboFanArrangement.Text;
                    drNewTable["Input_LLT"] = numLeavingLiquidTemperature.Value;
                    drNewTable["Input_USGPM_MBH"] = cboGPM_TotalHeat.Text;
                    drNewTable["Input_USGPM"] = numUSGPM.Value;
                    drNewTable["Input_MBH"] = numTotalHeat.Value;
                    drNewTable["Input_RatingLLT"] = (radRatingLLT.Checked ? 1 : 0);
                    drNewTable["Input_RatingGPM"] = (radRatingGPM.Checked ? 1 : 0);
                    drNewTable["Input_AirFlowType"] = cboAirFlowType.Text;
                    drNewTable["Input_FPI"] = cboFPI.Text;


                    foreach (DataRow dr in dtModelTable.Rows)
                    {
                        foreach (DataColumn dc in dtModelTable.Columns)
                        {
                            drNewTable[dc.ColumnName] = dr[dc.ColumnName];
                        }
                    }

                    dtNewTable.Rows.Add(drNewTable);
                }
            }

            _dsFluidCoolerList.Tables.Clear();
            _dsFluidCoolerList.Tables.Add(dtNewTable);
        }

        private bool CheckIfInputValuesAreGood()
        {
            //value to be returned
            bool bolReturnValue = true;

            string strFluidType = FluidTypeParameter();
            if (strFluidType == "WTR" || strFluidType == "EG" || strFluidType == "PG")
            {
                //check min max EDB EWB
                decimal decMinEDB = 0m;
                decimal decMaxEDB = 0m;
                decimal decFreezingPoint;
                //get min max and freezing point
                switch (strFluidType)
                {
                    case "WTR":
                        decMinEDB = 44m;
                        decMaxEDB = 350m;
                        break;
                    case "EG":
                        decFreezingPoint = _backgroundCode.GetFreezingPoint(Public.DSDatabase.Tables["FreezingPointEthylene"], Convert.ToInt32(numConcentration.Value));
                        decMinEDB = decFreezingPoint + 10m;
                        decMaxEDB = 350m;
                        break;
                    case "PG":
                        decFreezingPoint = _backgroundCode.GetFreezingPoint(Public.DSDatabase.Tables["FreezingPointPropylene"], Convert.ToInt32(numConcentration.Value));
                        decMinEDB = decFreezingPoint + 10m;
                        decMaxEDB = 350m;
                        break;
                }
                //validations
                if (numEDB.Value < decMinEDB || numEDB.Value > decMaxEDB)
                {
                    bolReturnValue = false;
                    Public.LanguageBox("EDB must be between " + decMinEDB + " and " + decMaxEDB, "EDB doit être entre " + decMinEDB + " et " + decMaxEDB);
                }
            }

            //validations
            if ((numLeavingLiquidTemperature.Value >= numELT.Value || numLeavingLiquidTemperature.Value <= numEDB.Value) && radRatingLLT.Checked)
            {
                bolReturnValue = false;
                Public.LanguageBox("Leaving Liquid Temperature must be between " + numEDB.Value + " and " + numELT.Value, "La Température de sortie du liquide doit être entre " + numEDB.Value + " et " + numELT.Value);
            }

            return bolReturnValue;
        }

        private void cboGPM_TotalHeat_SelectedIndexChanged(object sender, EventArgs e)
        {
            //depending on what option selected, show the good control
            //and hide the other one
            if (cboGPM_TotalHeat.Text == @"USGPM")
            {//if we select USGPM
                numUSGPM.Visible = true;
                numTotalHeat.Visible = false;
            }
            else
            {//if we select MBH
                numUSGPM.Visible = false;
                numTotalHeat.Visible = true;
            }

            ConfirmChangesHappen();
        }

        private void Fill_FluidType()
        {
            cboFluidType.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox
            //loop through all fluid type
            foreach (DataRow drFluidType in Public.DSDatabase.Tables["FluidCoolerFluidType"].Rows)
            {
                string strIndex = drFluidType["UniqueID"].ToString();
                string strText = drFluidType["FluidType"].ToString();
                ComboBoxControl.AddItem(cboFluidType, strIndex, strText);
            }
        }

        //this return the parameter of the fluid type. It's used in couple conditions
        //and also use to pass in the DLL
        private string FluidTypeParameter()
        {
            return ComboBoxControl.ItemInformations(cboFluidType, Public.DSDatabase.Tables["FluidCoolerFluidType"], "UniqueID")[0]["FluidTypeParameter"].ToString();
        }

        private void cboFluidType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboFluidType.Text == "OTHER")
            if (FluidTypeParameter() == "OTHER")
            {//if fluid type is OTHER
                //enable the control for other
                numSpecificHeat.Enabled = true;
                numDensity.Enabled = true;
                numViscosity.Enabled = true;
                numThermalConductivity.Enabled = true;
                txtFluidTypeName.Enabled = true;
                //force to select USGPM
                cboGPM_TotalHeat.SelectedIndex = cboGPM_TotalHeat.FindString("USGPM");
                //disable the control so it can't be changed
                cboGPM_TotalHeat.Enabled = false;
            }
            else
            {//any other fluid type than OTHER
                //disable all OTHER controls
                numSpecificHeat.Enabled = false;
                numDensity.Enabled = false;
                numViscosity.Enabled = false;
                numThermalConductivity.Enabled = false;
                txtFluidTypeName.Enabled = false;
                txtFluidTypeName.Text = "";
                //this control can now be selected as user wish
                cboGPM_TotalHeat.Enabled = true;
            }

            switch (FluidTypeParameter())
            {
                case "WTR":
                case "OTHER"://water and other are 100% and cannot be changed
                    numConcentration.Minimum = 0;
                    numConcentration.Maximum = 100;
                    numConcentration.Value = 100;
                    numConcentration.Enabled = false;
                    break;
                case "EG":
                case "PG"://PG and EG are default to 40 and the range is 10-60 and we can
                    //change the value
                    numConcentration.Value = 40;
                    numConcentration.Minimum = 10;
                    numConcentration.Maximum = 60;
                    numConcentration.Enabled = true;
                    break;
            }

            ConfirmChangesHappen();
        }

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFilter.Text == @"Selection")
            {//if the filter is on Selection
                //Lock Model
                cboModel.Enabled = false;
                //we unlock controls we locked
                cboUnitType.Enabled = true;
                cboFanArrangement.Enabled = true;
                cboFPI.Enabled = true;
                cboAirFlowType.Enabled = true;
                numPSI.Enabled = true;
                cboGPM_TotalHeat.Enabled = true;
                Fill_Voltage_Filter(UnitTypeParameter());
            }
            else
            {//so far only 2 filter exist so this else is for Rating
                //unlock Model
                cboModel.Enabled = true;
                //the unit type select ALL
                cboUnitType.SelectedIndex = cboUnitType.FindString("STANDARD PRODUCT LINE");
                //and then we disable unit type
                cboUnitType.Enabled = false;
                //the fan arrangement is ALL
                cboFanArrangement.SelectedIndex = cboFanArrangement.FindString("ALL");
                //and we disabled the fan arrangement
                cboFanArrangement.Enabled = false;
                //set the fpi on stardard just for the look
                cboFPI.SelectedIndex = cboFPI.FindString("STANDARD FINS");
                //set USGPM
                cboGPM_TotalHeat.SelectedIndex = 0;
                cboGPM_TotalHeat.Enabled = false;
                //disable the control
                cboFPI.Enabled = false;
                cboAirFlowType.Enabled = false;
                numPSI.Enabled = false;

                string ratingModel = ModelListParameter();
                Fill_Voltage_Filter(ratingModel.Split(',')[0] + ratingModel.Split(',')[1]);
            }

            ValidateRatingRadioButton();

            ConfirmChangesHappen();
        }


        private string ModelListParameter()
        {
            if (cboFilter.SelectedIndex == 0)
            {
                return "ALL";
            }
            return cboModel.SelectedValue.ToString();
        }

        private void Fill_ModelList()
        {
            //clear the combobox
            cboModel.Items.Clear();

            //fluid cooler list
            DataTable dtFluidCoolerList = _backgroundCode.GetModelsForRatingModeModelList(Public.DSDatabase.Tables["FluidCoolerModel"]);

            dtFluidCoolerList.TableName = "FluidCoolerList";
            var dsFluidCoolerList = new DataSet();
            dsFluidCoolerList.Tables.Add(dtFluidCoolerList);

            cboModel.DataSource = dsFluidCoolerList;
            cboModel.DisplayMember = "FluidCoolerList.Text";
            cboModel.ValueMember = "FluidCoolerList.Value";

            dtFluidCoolerList.Dispose();
        }


        private void lvFluidCooler_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if there is items
            if (lvFluidCooler.Items.Count > 0)
            {
                //if somethign selected
                if (lvFluidCooler.SelectedItems.Count > 0)
                {
                    //for each item put background white
                    for (int intItem = 0; intItem < lvFluidCooler.Items.Count; intItem++)
                    {
                        lvFluidCooler.Items[intItem].BackColor = Color.White;
                    }

                    //light blue the selection
                    lvFluidCooler.SelectedItems[0].BackColor = Color.LightBlue;
                }
            }
        }

        private void cboUnitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //on v motor only vertical available
            if (new ArrayList(UnitTypeCoilArrangement()).Contains("V"))
            {
                //so we lock on vertical the choice
                cboAirFlowType.SelectedIndex = cboAirFlowType.FindString("VERTICAL");
                cboAirFlowType.Enabled = false;
            }
            else
            {
                //on other we give back access to the control
                cboAirFlowType.Enabled = true;
            }

            Fill_FanArrangement();

            Fill_Voltage_Filter(UnitTypeParameter());

            ConfirmChangesHappen();
        }

       

        private void cboLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            //refresh the wether informations
            RefreshLocationWeatherInfromations();

            //save the city in the registry key
            Reg.Set(Reg.Key.Location, ComboBoxControl.IndexInformation(cboLocation));

            ConfirmChangesHappen();
        }

        private void cboModel_Leave(object sender, EventArgs e)
        {
            if (cboModel.SelectedIndex == -1)
            {
                cboModel.SelectedIndex = 0;
            }
        }

        //validate the control to show in rating mode
        private void ValidateRatingRadioButton()
        {
            if (cboFilter.SelectedIndex == 0)
            {
                lblLeavingLiquidTemperature.Enabled = true;
                numLeavingLiquidTemperature.Enabled = true;
                numUSGPM.Enabled = true;
                lblUSGPM.Visible = false;
                cboGPM_TotalHeat.Visible = true;
                radRatingGPM.Visible = false;
                radRatingLLT.Visible = false;
            }
            else
            {
                radRatingGPM.Visible = true;
                radRatingLLT.Visible = true;
                lblUSGPM.Visible = true;
                cboGPM_TotalHeat.Visible = false;
                if (radRatingLLT.Checked)
                {
                    lblLeavingLiquidTemperature.Enabled = true;
                    numLeavingLiquidTemperature.Enabled = true;
                    numUSGPM.Enabled = false;
                    lblUSGPM.Enabled = false;
                }
                else
                {
                    lblLeavingLiquidTemperature.Enabled = false;
                    numLeavingLiquidTemperature.Enabled = false;
                    numUSGPM.Enabled = true;
                    lblUSGPM.Enabled = true;
                }
            }

        }

        private void radRatingLLT_CheckedChanged(object sender, EventArgs e)
        {
            ValidateRatingRadioButton();

            ConfirmChangesHappen();
        }

        private void radRatingGPM_CheckedChanged(object sender, EventArgs e)
        {
            ValidateRatingRadioButton();

            ConfirmChangesHappen();
        }

        private bool AdvancedConfiguration_ControlPanel()
        {
            //extract the tablename and row id of the listview
            int intRow = Convert.ToInt32(lvFluidCooler.SelectedItems[0].SubItems[0].Text);

            var circuitCapacity = new List<decimal>();
            var circuitCondensing = new List<decimal>();
            var circuitRefrigerant = new List<string>();

            circuitCapacity.Add(0m);
            circuitCondensing.Add(0m);
            circuitRefrigerant.Add("");

            //open the control panel
            var controlpanel = new QuickControlPanel.FrmQuickControlPanel(
                _dsFluidCoolerList.Tables["FluidCoolers"].Rows[intRow]["Motor"].ToString(),
                _dsFluidCoolerList.Tables["FluidCoolers"].Rows[intRow]["CoilArr"].ToString(),
                _dsFluidCoolerList.Tables["FluidCoolers"].Rows[intRow]["Fin"].ToString(),
                QuickControlPanel.FrmQuickControlPanel.CoolerType.FluidCooler,
                circuitCapacity,
                Convert.ToInt32(_dsFluidCoolerList.Tables["FluidCoolers"].Rows[intRow]["FanWide"]),
                Convert.ToInt32(_dsFluidCoolerList.Tables["FluidCoolers"].Rows[intRow]["FanLong"]),
                Convert.ToInt32(_dsFluidCoolerList.Tables["FluidCoolers"].Rows[intRow]["VoltageID"]),
                Convert.ToDecimal(_dsFluidCoolerList.Tables["FluidCoolers"].Rows[intRow]["GPM"]),
                Convert.ToDecimal(_dsFluidCoolerList.Tables["FluidCoolers"].Rows[intRow]["PressureDrop"]),
                circuitCondensing,
                circuitRefrigerant,
                0,
                0,
                0m,
                _dsFluidCoolerList.Tables["FluidCoolers"].Rows[intRow]["AirFlow"].ToString());

            if (controlpanel.ShowDialog() == DialogResult.OK)
            {
                controlpanel.Dispose();
                _dtControlPanelInputs = controlpanel.ControlPanelInputs;
                _dtPumpInputs = controlpanel.PumpInputs;
                return true;
            }
                _dtControlPanelInputs.Clear();
                _dtPumpInputs.Clear();
            
            

            return false;
        }

        private bool AdvancedConfiguration_CoatingMaterialEtc()
        {
            //extract the tablename and row id of the listview
            int intRow = Convert.ToInt32(lvFluidCooler.SelectedItems[0].SubItems[0].Text);

            var secondaryOptions = new FluidCoolerCondenserOptions.FrmFluidCoolerCondenserOptions(
                FluidCoolerCondenserOptions.FrmFluidCoolerCondenserOptions.OpenFrom.FluidCooler,
                _dsFluidCoolerList.Tables["FluidCoolers"].Rows[intRow]["Motor"].ToString(),
                _dsFluidCoolerList.Tables["FluidCoolers"].Rows[intRow]["AirFlowType"].ToString(),
                _dsFluidCoolerList.Tables["FluidCoolers"].Rows[intRow]["Fin"].ToString(),
                Convert.ToDecimal(_dsFluidCoolerList.Tables["FluidCoolers"].Rows[intRow]["FPI"]),
                Convert.ToDecimal(_dsFluidCoolerList.Tables["FluidCoolers"].Rows[intRow]["Row"]),
                Convert.ToDecimal(_dsFluidCoolerList.Tables["FluidCoolers"].Rows[intRow]["FinHeight"]),
                Convert.ToDecimal(_dsFluidCoolerList.Tables["FluidCoolers"].Rows[intRow]["CoilLength"]),
                Convert.ToInt32(_dsFluidCoolerList.Tables["FluidCoolers"].Rows[intRow]["FanWide"]),
                Convert.ToInt32(_dsFluidCoolerList.Tables["FluidCoolers"].Rows[intRow]["FanLong"]),
                _dsFluidCoolerList.Tables["FluidCoolers"].Rows[intRow]["CoilArr"].ToString(),
                false,
                false,
                "",
                0m,
                _bolQuoteSelection);

            if (secondaryOptions.ShowDialog() == DialogResult.OK)
            {
                _dtSecondaryOptionsInputs = secondaryOptions.SecondaryOptionsInput;
                _legNomenclature = secondaryOptions.GetLegNomenclature();
                _legInstalled = secondaryOptions.GetLegInstalled();
                secondaryOptions.Dispose();
                return true;
            }
            _dtSecondaryOptionsInputs.Clear();
            return false;
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            if (_valueHaveChanged)
            {
                Public.LanguageBox("Values have changed since you last ran the selection. You need to rerun selection in order to save", "Une ou plusieurs valeurs ont changé depuis la dernière sélection. Vous devez réexecuter la sélection pour pouvoir sauvegarder.");
            }
            else
            {
                if (lvFluidCooler.SelectedItems.Count > 0)
                {
                    if (AdvancedConfiguration_ControlPanel())
                    {
                        if (AdvancedConfiguration_CoatingMaterialEtc())
                        {
                            ThreadProcess.Start(Public.LanguageString("Preparing data", "Préparation des données"));
                            UpdateLastValues();
                            DataSet dsFluidCoolerListCopy = _dsFluidCoolerList.Copy();

                            DataRow drSelectedValue = dsFluidCoolerListCopy.Tables["FluidCoolers"].NewRow();
                            drSelectedValue.ItemArray = dsFluidCoolerListCopy.Tables["FluidCoolers"].Rows[Convert.ToInt32(lvFluidCooler.SelectedItems[0].SubItems[0].Text)].ItemArray;

                            drSelectedValue["ApprovalDrawing"] = GetApprovalDrawing(
                                                                 drSelectedValue["Motor"].ToString(),
                                                                 drSelectedValue["CoilArr"].ToString(),
                                                                 drSelectedValue["FanWide"].ToString(),
                                                                 drSelectedValue["FanLong"].ToString(),
                                                                 drSelectedValue["AirFlow"].ToString());


                            dsFluidCoolerListCopy.Tables["FluidCoolers"].Rows.Clear();
                            dsFluidCoolerListCopy.Tables["FluidCoolers"].Rows.Add(drSelectedValue);

                            //if press when form loaded from quote form
                            if (_bolQuoteSelection)
                            {
                                int newIndexToPush;
                                ThreadProcess.UpdateMessage(Public.LanguageString("Adding to quote", "Ajout à la soumission"));
                                if (_intIndex != -1)
                                {
                                    var savingoption = new FrmSavingOption();

                                    ThreadProcess.Stop();
                                    Focus();

                                    if (savingoption.ShowDialog() == DialogResult.Yes)
                                    {//if he want to overwrite
                                        //it's a modification unit so we delete and recreate records

                                        //we delete
                                        _quoteform.DeleteFromQuoteFluidCooler(_intIndex);
                                        newIndexToPush = _intIndex;
                                        _quoteform.UpdateAdditionalItems(_intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.FluidCooler), newIndexToPush);
                                        //Quoteform.DeleteFromQuoteAdditionalItems(intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.FluidCooler));
                                    }
                                    else
                                    {
                                        //since we actually always recreate the record
                                        // save as new is simple, all i have to do is copy the additionnal items
                                        //if reused the update function to instead duplicate record.
                                        newIndexToPush = _quoteform.GetNextID("FluidCoolers");
                                        _quoteform.CopyAdditionalItems(_intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.FluidCooler), newIndexToPush);

                                    }

                                    ThreadProcess.Start(Public.LanguageString("Adding to quote", "Ajout à la soumission"));

                                }
                                else
                                {
                                    newIndexToPush = _quoteform.GetNextID("FluidCoolers");
                                }
                                //add record
                                AddToQuote(dsFluidCoolerListCopy, newIndexToPush);
                                _quoteform.RefreshBasketList();
                                _quoteform.SetQuoteIsModified(true);
                                Dispose();
                            }
                            else
                            {
                                ThreadProcess.UpdateMessage(Public.LanguageString("Generating Report", "Création du rapport"));
                                FluidCoolerReport.GenerateDataReport(dsFluidCoolerListCopy.Tables["FluidCoolers"], _dtControlPanelInputs, _dtPumpInputs, _dtSecondaryOptionsInputs, true, 0, "");
                            }
                            ThreadProcess.Stop();
                            Focus();
                        }
                    }
                }
                else
                {
                    Public.LanguageBox("You must select a fluid cooler before selecting further options", "Vous devez sélectionner un refroidisseur liquide avant de configurer les options suivantes");
                }
            }
        }

        private void AddToQuote(DataSet dsFluidCoolerListCopy, int itemID)
        {
            const int intSelectedRowIndex = 0;
            dsFluidCoolerListCopy.Tables["FluidCoolers"].Rows[intSelectedRowIndex]["ItemType"] = Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.FluidCooler);
            dsFluidCoolerListCopy.Tables["FluidCoolers"].Rows[intSelectedRowIndex]["ItemID"] = itemID;
            _dsQuoteData.Tables["FluidCoolers"].Rows.Add(dsFluidCoolerListCopy.Tables["FluidCoolers"].Rows[intSelectedRowIndex].ItemArray);

            foreach (DataRow drControlPanel in _dtControlPanelInputs.Rows)
            {
                drControlPanel["ItemType"] = dsFluidCoolerListCopy.Tables["FluidCoolers"].Rows[intSelectedRowIndex]["ItemType"];
                drControlPanel["ItemID"] = dsFluidCoolerListCopy.Tables["FluidCoolers"].Rows[intSelectedRowIndex]["ItemID"];
                _dsQuoteData.Tables["ControlPanelInputs"].Rows.Add(drControlPanel.ItemArray);
            }

            foreach (DataRow drPump in _dtPumpInputs.Rows)
            {
                drPump["ItemType"] = dsFluidCoolerListCopy.Tables["FluidCoolers"].Rows[intSelectedRowIndex]["ItemType"];
                drPump["ItemID"] = dsFluidCoolerListCopy.Tables["FluidCoolers"].Rows[intSelectedRowIndex]["ItemID"];
                _dsQuoteData.Tables["PumpInputs"].Rows.Add(drPump.ItemArray);
            }


            _dtSecondaryOptionsInputs.Rows[0]["ItemType"] = dsFluidCoolerListCopy.Tables["FluidCoolers"].Rows[intSelectedRowIndex]["ItemType"];
            _dtSecondaryOptionsInputs.Rows[0]["ItemID"] = dsFluidCoolerListCopy.Tables["FluidCoolers"].Rows[intSelectedRowIndex]["ItemID"];
            _dsQuoteData.Tables["SecondaryOptions"].Rows.Add(_dtSecondaryOptionsInputs.Rows[0].ItemArray);

            DataTable copy = _dsQuoteData.Tables["FluidCoolers"].Copy();
            DataRow[] list = copy.Select("", "itemID");

            _dsQuoteData.Tables["FluidCoolers"].Rows.Clear();
            foreach (DataRow row in list)
            {
                _dsQuoteData.Tables["FluidCoolers"].Rows.Add(row["QuoteID"], row["QuoteRevision"], row["QuoteRevisionText"], row["ItemType"], row["ItemID"], row["Username"], row["Input_Tag"], row["Quantity"], row["Input_Filter"], row["Input_Model"], row["Input_Location"], row["Input_EDB"], row["Input_Altitude"], row["Input_ELT"], row["Input_FluidType"], row["Input_Concentration"], row["Input_FluidTypeName"], row["Input_SpecificHeat"], row["Input_Density"], row["Input_Viscosity"], row["Input_ThermalConductivity"], row["Input_Voltage"], row["Input_MaxFluidPressure"], row["Input_UnitType"], row["Input_FanArrangement"], row["Input_LLT"], row["Input_USGPM_MBH"], row["Input_USGPM"], row["Input_MBH"], row["Input_RatingLLT"], row["Input_RatingGPM"], row["Input_AirFlowType"], row["Input_FPI"], row["ApprovalDrawing"], row["CFM"], row["Motor"], row["Coilarr"], row["Fanwide"], row["Fanlong"], row["FanQty"], row["Row"], row["Fpi"], row["Fin"], row["Tubes"], row["FinHeight"], row["coillength"], row["cir1"], row["TCFM"], row["AirFlow"], row["REFPLUS_FluidXRefModel"], row["ECOSAIRE_FluidXRefModel"], row["DECTRON_FluidXRefModel"], row["CIRCULAIRE_FluidXRefModel"], row["Price"], row["Weight"], row["Cap"], row["LeavingLiquid"], row["PressureDrop"], row["LeavingAir"], row["LiquidVelocity"], row["GPM"], row["FluidCoolerModel"], row["FluidCoolerPrice"], row["ConnectionSize"], row["CoilFaceArea"], row["FaceVelocity"], row["AirPressureDrop"], row["EnteringDryBulb"], row["EnteringLiquidTemperature"], row["FluidType"], row["Concentration"], row["Altitude"], row["PowerSupply"], row["SpecificHeat"], row["Density"], row["Viscosity"], row["ThermalConductivity"], row["FluidTypeName"], row["VoltageID"], row["AirFlowType"], row["FLA"], row["PumpFLA"], row["ShipWeight"], row["Dwg"], row["FanHP"], row["FanRPM"]);
            }

        }

        

        private void UpdateLastValues()
        {
            foreach (DataRow dr in _dsFluidCoolerList.Tables["FluidCoolers"].Rows)
            {
                //2010-09-23 : Database Note. according to a sheet Refplus gave us
                //the motor "N" is the only motor to have different FLA depending on the
                //voltage being 208/3/60 or 230/3/60. all the other one have the same
                //since it always been combined in 1 voltage and they only have 1 voltage id
                //for both we used the biggest FLA as the value in the database


                dr["FLA"] = Convert.ToDecimal(Public.DSDatabase.Tables["MotorFLA"].Select("Motor = '" + dr["Motor"] + "' AND CoilArr = '" + dr["CoilArr"] + "' AND VoltageID = " + dr["VoltageID"])[0]["FLA"]);
                dr["PumpFLA"] = 0m;

                //2009-09-02: Added weight fluid cooler table
                dr["ShipWeight"] = Convert.ToDecimal(dr["Weight"]);

                //if theres a pump and it's integrated then the ampacity is calculated
                //with the Fluid Cooler, else it will be 0 so it's wont be taken into consideration
                if (_dtPumpInputs.Rows.Count > 0)
                {
                    if (_dtPumpInputs.Rows[0]["PumpType"].ToString() == "PUMP KIT INTEGRATED")
                    {
                        dr["PumpFLA"] = Convert.ToDecimal(_dtPumpInputs.Rows[0]["FLA"]);
                        //also change if it's ecosaire site the model name to start with a E
                        if (UserInformation.CurrentSite == "ECOSAIRE")
                        {
                            dr["FluidCoolerModel"] = "E" + dr["FluidCoolerModel"].ToString().Substring(1);
                        }
                    }
                }

                dr["Dwg"] = "N/A";
                dr["FanHP"] = Public.DSDatabase.Tables["CoilInfo"].Select("Motor = '" + dr["Motor"] + "' AND CoilArr = '" + dr["CoilArr"] + "'")[0]["HP"].ToString();
                dr["FanRPM"] = Public.DSDatabase.Tables["CoilInfo"].Select("Motor = '" + dr["Motor"] + "' AND CoilArr = '" + dr["CoilArr"] + "'")[0]["RPM"].ToString();
            }
        }

        //auto-select content of numerical up and down on tab
        private void AutoSelectOnTab(object sender, EventArgs e)
        {
            //numerical up and down do not select text by default when we tab
            //or clik in the control. This code make him do it
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmQuickFluidCooler_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }

        private void txtTag_TextChanged(object sender, EventArgs e)
        {
            ConfirmChangesHappen();
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            ConfirmChangesHappen();
        }

        private void cboModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFilter.Text == @"Rating")
            {
                string ratingModel = ModelListParameter();
                Fill_Voltage_Filter(ratingModel.Split(',')[0] + ratingModel.Split(',')[1]);
            }

            ConfirmChangesHappen();
        }

        private void numEDB_ValueChanged(object sender, EventArgs e)
        {
            ConfirmChangesHappen();
        }

        private void numAltitude_ValueChanged(object sender, EventArgs e)
        {
            ConfirmChangesHappen();
        }

        private void numELT_ValueChanged(object sender, EventArgs e)
        {
            ConfirmChangesHappen();
        }

        private void numConcentration_ValueChanged(object sender, EventArgs e)
        {
            ConfirmChangesHappen();
        }

        private void txtFluidTypeName_TextChanged(object sender, EventArgs e)
        {
            ConfirmChangesHappen();
        }

        private void numSpecificHeat_ValueChanged(object sender, EventArgs e)
        {
            ConfirmChangesHappen();
        }

        private void numDensity_ValueChanged(object sender, EventArgs e)
        {
            ConfirmChangesHappen();
        }

        private void numViscosity_ValueChanged(object sender, EventArgs e)
        {
            ConfirmChangesHappen();
        }

        private void numThermalConductivity_ValueChanged(object sender, EventArgs e)
        {
            ConfirmChangesHappen();
        }

        private void cboVoltage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfirmChangesHappen();
        }

        private void numPSI_ValueChanged(object sender, EventArgs e)
        {
            ConfirmChangesHappen();
        }

        private void cboFanArrangement_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfirmChangesHappen();
        }

        private void numLeavingLiquidTemperature_ValueChanged(object sender, EventArgs e)
        {
            ConfirmChangesHappen();
        }

        private void numUSGPM_ValueChanged(object sender, EventArgs e)
        {
            ConfirmChangesHappen();
        }

        private void numTotalHeat_ValueChanged(object sender, EventArgs e)
        {
            ConfirmChangesHappen();
        }

        private void cboAirFlowType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfirmChangesHappen();
        }

        private void cboFPI_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfirmChangesHappen();
        }

        private string GetApprovalDrawing(string motor, string coilArr, string fanWide, string fanLong, string airFlow)
        {
            string strApprovalDrawing = "";

            //company
            strApprovalDrawing += "R";

            //Unit Size Type
            string unitSizeType = GetUnitSizeType(motor, coilArr);
            strApprovalDrawing += unitSizeType;

            //unit type
            strApprovalDrawing += "F";

            //split
            strApprovalDrawing += "-";

            //fan arrangement
            strApprovalDrawing += fanWide + fanLong;

            //number of circuit
            //logic : 
            //1 fan wide = 1 circuit
            //2 fan wide = 2 circuit
            //if X or Z sizr type then
            // 2 circuit per fan wide instead
            int unitSizeTypeCircuitMultiplier = 1;

            if (unitSizeType == "X" || unitSizeType == "Z")
            {
                unitSizeTypeCircuitMultiplier = 2;
            }

            strApprovalDrawing += Convert.ToInt32(Convert.ToInt32(fanWide) * unitSizeTypeCircuitMultiplier).ToString(CultureInfo.InvariantCulture);

            //split
            strApprovalDrawing += "-";

            //unit coil setup
            strApprovalDrawing += GetUnitCoilSetup(airFlow);

            //split
            strApprovalDrawing += "-";

            //leg
            strApprovalDrawing += _legNomenclature;

            //split
            strApprovalDrawing += "-";

            //receiver kit
            strApprovalDrawing += "N";

            return strApprovalDrawing;
        }

        private string GetUnitCoilSetup(string airFlow)
        {
            string unitCoilSetup = "";

            if (_legInstalled && airFlow == "H")
            {
                unitCoilSetup = "D";
            }
            else if (_legInstalled && airFlow == "V")
            {
                unitCoilSetup = "B";
            }
            else if (!_legInstalled && airFlow == "H")
            {
                unitCoilSetup = "H";
            }
            else if (!_legInstalled && airFlow == "V")
            {
                unitCoilSetup = "N";
            }

            return unitCoilSetup;
        }

        private string GetUnitSizeType(string motor, string coilArr)
        {
            string unitSizeType = "";

            DataTable dtCoilInfo = Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilInfo"], "Motor = '" + motor + "' AND CoilArr = '" + coilArr + "'", "");

            if (dtCoilInfo.Rows.Count > 0)
            {
                unitSizeType = dtCoilInfo.Rows[0]["UnitSizeTypeNomenclature"].ToString();
            }

            return unitSizeType;
        }
    }
}