using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using System.Reflection;

namespace RefplusWebtools.QuickHeatPipe
{
    public partial class FrmQuickHeatPipe : Form
    {
        //form need access to his background code
        private readonly QuickHeatPipeCode _backgroundCode = new QuickHeatPipeCode();

        //Lock RH and WetBulb Calculation
        private bool _bolLockRHAndWetBulbCalculation;

        private readonly string[] _strTableList = { "HeatPipeFinType", "HeatPipeFlowType", "HeatPipeFPI", "HeatPipeShape", "CoilFinMaterial", "CoilTubeMaterial", "CoilCasingMaterial" };

        //this datatable hold the last selection
        DataTable _dtHeatPipe = new DataTable();

        //link to the quote form
        private readonly Quotes.FrmQuotes _quoteform;
        //dataset of the quote
        private readonly DataSet _dsQuoteData;
        //index of the row, -1 mean not loading so we know it's a new record
        private readonly int _intIndex = -1;
        //is true if the form is loaded from quote, false if loaded ordinary
        private readonly bool _bolQuoteSelection;

        public FrmQuickHeatPipe()
        {
            InitializeComponent();
        }

        public FrmQuickHeatPipe(Quotes.FrmQuotes quoteform, DataSet dsQuoteData, int intIndex)
        {
            InitializeComponent();
            _quoteform = quoteform;
            _dsQuoteData = dsQuoteData;
            _intIndex = intIndex;
            _bolQuoteSelection = true;

        }

        //auto-select content of numerical up and down on tab
        private void AutoSelectOnTab(object sender, EventArgs e)
        {
            //numerical up and down do not select text by default when we tab
            //or clik in the control. This code make him do it
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
        }

        private void AutoSelectTextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }

        private void frmQuickHeatPipe_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            Query.LoadTables(_strTableList);

            //fill all the combobox
            Fill_Combobox();

            //set defaults
            SetDefaults();

            if (_bolQuoteSelection && _intIndex != -1)
            {
                ThreadProcess.UpdateMessage(Public.LanguageString("Loading saved data", "Chargement des données"));
                LoadSavedData();
            }
            ThreadProcess.Stop();
            Focus();
        }

        private void LoadSavedData()
        {
            //will contain all errors
            string strErrors = "";

            DataTable dtSavedInfo = Public.SelectAndSortTable(_dsQuoteData.Tables["HeatPipes"], "ItemType = " + Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.HeatPipe) + " AND ItemID = " + _intIndex, "");
            DataRow drSavedInfo = dtSavedInfo.NewRow();
            drSavedInfo.ItemArray = dtSavedInfo.Rows[0].ItemArray;

            txtTag.Text = drSavedInfo["Tag"].ToString();

            numAirFlowSupply.Value = Convert.ToDecimal(drSavedInfo["AirFlowSupply"]);

            numAirFlowExhaust.Value = Convert.ToDecimal(drSavedInfo["AirFlowExhaust"]);

            if (cboSymmetrical.FindString(drSavedInfo["Symmetrical"].ToString()) >= 0)
            {
                cboSymmetrical.SelectedIndex = cboSymmetrical.FindString(drSavedInfo["Symmetrical"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected symmetrical option", "- Incapable de trouver l'option de symétrie sélectionnée") + Environment.NewLine;
            }

            numAltitude.Value = Convert.ToDecimal(drSavedInfo["Altitude"]);

            numOADB.Value = Convert.ToDecimal(drSavedInfo["Summer_OADB"]);

            numOAWB.Value = Convert.ToDecimal(drSavedInfo["Summer_OAWB"]);

            numOARH.Value = Convert.ToDecimal(drSavedInfo["Summer_OARH"]);

            numRADB.Value = Convert.ToDecimal(drSavedInfo["Summer_RADB"]);

            numRAWB.Value = Convert.ToDecimal(drSavedInfo["Summer_RAWB"]);

            numRARH.Value = Convert.ToDecimal(drSavedInfo["Summer_RARH"]);

            numOADBWinter.Value = Convert.ToDecimal(drSavedInfo["Winter_OADB"]);

            numOAWBWinter.Value = Convert.ToDecimal(drSavedInfo["Winter_OAWB"]);

            numOARHWinter.Value = Convert.ToDecimal(drSavedInfo["Winter_OARH"]);

            numRADBWinter.Value = Convert.ToDecimal(drSavedInfo["Winter_RADB"]);

            numRAWBWinter.Value = Convert.ToDecimal(drSavedInfo["Winter_RAWB"]);

            numRARHWinter.Value = Convert.ToDecimal(drSavedInfo["Winter_RARH"]);

            if (cboFinType.FindString(drSavedInfo["FinType"].ToString()) >= 0)
            {
                cboFinType.SelectedIndex = cboFinType.FindString(drSavedInfo["FinType"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected fin type", "- Incapable de trouver le type d'ailette sélectionné") + Environment.NewLine;
            }

            ComboBoxControl.SetIDDefaultValue(cboFinHeight, drSavedInfo["FinHeight"].ToString());

            numFinLength.Value = Convert.ToDecimal(drSavedInfo["FinLength"]);

            if (cboFPI.FindString(drSavedInfo["Input_FPI"].ToString()) >= 0)
            {
                cboFPI.SelectedIndex = cboFPI.FindString(drSavedInfo["Input_FPI"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected FPI", "- Incapable de trouver le nombre d'ailettes par pouces sélectionné") + Environment.NewLine;
            }

            numNumberOfRows.Value = Convert.ToDecimal(drSavedInfo["Rows"]);

            if (cboShape.FindString(drSavedInfo["Shape"].ToString()) >= 0)
            {
                cboShape.SelectedIndex = cboShape.FindString(drSavedInfo["Shape"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected shape", "- Incapable de trouver la forme sélectionnée") + Environment.NewLine;
            }

            numAtmosphericPressure.Value = Convert.ToDecimal(drSavedInfo["AtmosphericPressure"]);

            if (cboFlowType.FindString(drSavedInfo["FlowType"].ToString()) >= 0)
            {
                cboFlowType.SelectedIndex = cboFlowType.FindString(drSavedInfo["FlowType"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected flow type", "- Incapable de trouver le type de débit d'air sélectionné") + Environment.NewLine;
            }

            numTiltAngle.Value = Convert.ToDecimal(drSavedInfo["TiltAngle"]);

            numDefrostSetPoint.Value = Convert.ToDecimal(drSavedInfo["DefrostSetPoint"]);

            if (strErrors != "")
            {
                MessageBox.Show(Public.LanguageString("The following error(s) happened while loading", "La/Les erreur(s) suivante(s) sont survenue(s) lors du chargement") + Environment.NewLine + strErrors, Public.LanguageString("Error while loading", "Erreur lors du chargement"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void SetDefaults()
        {
            //set G as fin type (1)
            ComboBoxControl.SetIDDefaultValue(cboFinType, "1");

            //set 11 as default fpi
            ComboBoxControl.SetIDDefaultValue(cboFPI, "7");

            //set symmetrical yes
            ComboBoxControl.SetIDDefaultValue(cboSymmetrical, "1");

            //set shape to straight
            ComboBoxControl.SetIDDefaultValue(cboShape, "2");

            //set flow type to counter flow (1)
            ComboBoxControl.SetIDDefaultValue(cboFlowType, "1");
        }

        private void Fill_Combobox()
        {
            //fill the fin types
            Fill_FinType();

            //fill fpi
            Fill_FPI();

            //fill symmetrical
            Fill_Symmetrical();

            //fill shape
            Fill_Shape();

            //fill the flow type
            Fill_FlowType();
        }

        //return if the flow type is parallel flow
        private bool FlowType()
        {
            //if it's parallel flow (2) return true
            if (ComboBoxControl.IndexInformation(cboFlowType) == "2")
            {
                return true;
            }
            return false;
        }

        //fill shape
        private void Fill_FlowType()
        {
            cboFlowType.Items.Clear();

            //these variable as use for easier modification of index or text showing
            //in the combobox

            //for each fin type
            foreach (DataRow drFinType in Public.DSDatabase.Tables["HeatPipeFlowType"].Rows)
            {
                string strIndex = drFinType["UniqueID"].ToString();
                string strText = drFinType["FlowType"].ToString();
                ComboBoxControl.AddItem(cboFlowType, strIndex, strText);
            }
        }

        //return is the shape is U shape
        private bool Shape()
        {
            //if shape = u shape (1) then true
            return ComboBoxControl.IndexInformation(cboShape) == "1";
        }

        //fill shape
        private void Fill_Shape()
        {
            cboShape.Items.Clear();

            //these variable as use for easier modification of index or text showing
            //in the combobox

            //for each fin type
            foreach (DataRow drFinType in Public.DSDatabase.Tables["HeatPipeShape"].Rows)
            {
                string strIndex = drFinType["UniqueID"].ToString();
                string strText = drFinType["Shape"].ToString();
                ComboBoxControl.AddItem(cboShape, strIndex, strText);
            }
        }

        private bool Symmetrical()
        {
            //if symmetrical is yes (1)
            return ComboBoxControl.IndexInformation(cboSymmetrical) == "1";
        }

        //fill symmetrical
        private void Fill_Symmetrical()
        {
            ComboBoxControl.AddItem(cboSymmetrical, "1", "YES");
            ComboBoxControl.AddItem(cboSymmetrical, "2", "NO");
        }

        //return the FPI index the dll needs
        private decimal FPIindex()
        {
            return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboFPI, Public.DSDatabase.Tables["HeatPipeFPI"], "UniqueID")[0]["FPIParameter"]);
        }

        //return the number of FPI
        private decimal FPI()
        {
            return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboFPI, Public.DSDatabase.Tables["HeatPipeFPI"], "UniqueID")[0]["FPI"]);
        }

        //fill fpi
        private void Fill_FPI()
        {
            cboFPI.Items.Clear();

            //these variable as use for easier modification of index or text showing
            //in the combobox

            //for each fin type
            foreach (DataRow drFinType in Public.DSDatabase.Tables["HeatPipeFPI"].Rows)
            {
                string strIndex = drFinType["UniqueID"].ToString();
                string strText = drFinType["FPI"].ToString();
                ComboBoxControl.AddItem(cboFPI, strIndex, strText);
            }
        }

        //return the FaceTube Amount of the selected FinType
        private decimal FinTypeFaceTube()
        {
            return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboFinType, Public.DSDatabase.Tables["HeatPipeFinType"], "UniqueID")[0]["FaceTube"]);
        }

        /// <summary>
        /// Return the fin type selected by the user (i.e. : "C", "F, ...)
        /// </summary>
        /// <returns></returns>
        private string FinTypeParameter()
        {
            return ComboBoxControl.ItemInformations(cboFinType, Public.DSDatabase.Tables["HeatPipeFinType"], "UniqueID")[0]["FinType"].ToString();
        }

        private void Fill_FinType()
        {
            cboFinType.Items.Clear();

            //these variable as use for easier modification of index or text showing
            //in the combobox

            //for each fin type
            foreach (DataRow drFinType in Public.DSDatabase.Tables["HeatPipeFinType"].Rows)
            {
                //this is an output example
                //C - 3/8", 1" X 3/4"
                string strIndex = drFinType["UniqueID"].ToString();
                string strText = drFinType["FinType"] + " - " + drFinType["TubeDiameter"] + "\", " + drFinType["FaceTube"] + "\" X " + drFinType["TubeRow"] + "\"";
                ComboBoxControl.AddItem(cboFinType, strIndex, strText);
            }
        }

        private decimal FinHeightParameter()
        {
            return Convert.ToDecimal(ComboBoxControl.IndexInformation(cboFinHeight));
        }

        private void Fill_FinHeight()
        {
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

            //for each increment of face tubes, add the height
            for (decimal decFinHeight = decFaceTubes * QuickHeatPipeCode.DecMinHeightInFaceTubes; decFinHeight < QuickHeatPipeCode.DecMaxFinHeight; decFinHeight += decFaceTubes)
            {
                ComboBoxControl.AddItem(cboFinHeight, decFinHeight.ToString(CultureInfo.InvariantCulture), decFinHeight + "\"");
            }

            //now if the decSelectedHeight is Different than 0 it mean something was 
            //selected.
            if (decSelectedHeight != 0)
            {
                ComboBoxControl.SetIDDefaultValue(cboFinHeight, _backgroundCode.FinHeightSelectClosestValueOfPreviouslySelectedOne(decSelectedHeight, decFaceTubes));
            }
            else
            {
                cboFinHeight.SelectedIndex = 0;
            }
        }

        //this funtion fill the heat pipe dataset with entering and output values
        //output are read from the class object heatpipe i created
        private void Fill_HeatPipeDatatable()
        {
            var oHeatPipeSummer = new HeatPipe(
            HeatPipe.WeatherConditionType.Summer,
            Convert.ToInt16(FinHeightParameter() / FinTypeFaceTube())
            , Convert.ToDouble(FinTypeFaceTube())
          , Convert.ToDouble(numFinLength.Value)
          , Convert.ToInt16(FPI())
          , Convert.ToInt16(numNumberOfRows.Value)
          , Convert.ToDouble(numOADB.Value)
          , Convert.ToDouble(numRADB.Value)
          , Convert.ToDouble(numOARH.Value)
          , Convert.ToDouble(numRARH.Value)
          , false
          , Convert.ToDouble(numDefrostSetPoint.Value)
          , Symmetrical()
          , Convert.ToDouble(numAltitude.Value)
          , Convert.ToDouble(numAirFlowExhaust.Value)
          , Convert.ToDouble(numAirFlowSupply.Value)
          , Convert.ToInt16(FPIindex())
          , Convert.ToDouble(numOAWB.Value)
          , Convert.ToDouble(numRAWB.Value)
          , Shape()
          , Convert.ToDouble(numAtmosphericPressure.Value)
          , FlowType()
          , Convert.ToDouble(numTiltAngle.Value)
          , false);

            var oHeatPipeWinter = new HeatPipe(
            HeatPipe.WeatherConditionType.Winter,
            Convert.ToInt16(FinHeightParameter() / FinTypeFaceTube())
            , Convert.ToDouble(FinTypeFaceTube())
          , Convert.ToDouble(numFinLength.Value)
          , Convert.ToInt16(FPI())
          , Convert.ToInt16(numNumberOfRows.Value)
          , Convert.ToDouble(numOADBWinter.Value)
          , Convert.ToDouble(numRADBWinter.Value)
          , Convert.ToDouble(numOARHWinter.Value)
          , Convert.ToDouble(numRARHWinter.Value)
          , false
          , Convert.ToDouble(numDefrostSetPoint.Value)
          , Symmetrical()
          , Convert.ToDouble(numAltitude.Value)
          , Convert.ToDouble(numAirFlowExhaust.Value)
          , Convert.ToDouble(numAirFlowSupply.Value)
          , Convert.ToInt16(FPIindex())
          , Convert.ToDouble(numOAWBWinter.Value)
          , Convert.ToDouble(numRAWBWinter.Value)
          , Shape()
          , Convert.ToDouble(numAtmosphericPressure.Value)
          , FlowType()
          , Convert.ToDouble(numTiltAngle.Value)
          , false);

            //add the table format
            _dtHeatPipe = Tables.DtQuoteHeatPipe();

            DataRow drHeatPipe = _dtHeatPipe.NewRow();

            drHeatPipe["Tag"] = txtTag.Text;
            drHeatPipe["Quantity"] = 1;
            drHeatPipe["Model"] = "P" +
                                  FinTypeParameter() +
                                  "C" +
                                  "-" +
                                  Convert.ToDecimal(FinHeightParameter() / FinTypeFaceTube()).ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') +
                                  "-" +
                                  numNumberOfRows.Value.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') +
                                  "-" +
                                  FPI().ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') +
                                  "-" +
                                  oHeatPipeSummer.FinLengthOnSupplySide.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') +
                                  "-" +
                                  oHeatPipeSummer.FinLengthOnReturnSide.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') +
                                  "-" +
                                  (cboShape.Text.Contains("Straight") ? "S" : "U");
            drHeatPipe["AirFlowSupply"] = numAirFlowSupply.Value;
            drHeatPipe["AirFlowExhaust"] = numAirFlowExhaust.Value;
            drHeatPipe["Symmetrical"] = cboSymmetrical.Text;
            drHeatPipe["Altitude"] = numAltitude.Value;
            drHeatPipe["Summer_OADB"] = numOADB.Value;
            drHeatPipe["Summer_OAWB"] = numOAWB.Value;
            drHeatPipe["Summer_OARH"] = numOARH.Value;
            drHeatPipe["Summer_RADB"] = numRADB.Value;
            drHeatPipe["Summer_RAWB"] = numRAWB.Value;
            drHeatPipe["Summer_RARH"] = numRARH.Value;
            drHeatPipe["Winter_OADB"] = numOADBWinter.Value;
            drHeatPipe["Winter_OAWB"] = numOAWBWinter.Value;
            drHeatPipe["Winter_OARH"] = numOARHWinter.Value;
            drHeatPipe["Winter_RADB"] = numRADBWinter.Value;
            drHeatPipe["Winter_RAWB"] = numRAWBWinter.Value;
            drHeatPipe["Winter_RARH"] = numRARHWinter.Value;
            drHeatPipe["FinType"] = cboFinType.Text;
            drHeatPipe["FinHeight"] = FinHeightParameter();
            drHeatPipe["FinLength"] = numFinLength.Value;
            drHeatPipe["FPI"] = FPI();
            drHeatPipe["Input_FPI"] = cboFPI.Text;
            drHeatPipe["Rows"] = numNumberOfRows.Value;
            drHeatPipe["Shape"] = cboShape.Text;
            drHeatPipe["AtmosphericPressure"] = numAtmosphericPressure.Value;
            drHeatPipe["FlowType"] = cboFlowType.Text;
            drHeatPipe["TiltAngle"] = numTiltAngle.Value;
            drHeatPipe["DefrostSetPoint"] = numDefrostSetPoint.Value;
            drHeatPipe["Price"] = GetHeatPipePrice();

            //now for each properties in the heatpipe class fill the column if it exist
            //the columns that need to bi filled have a R_ in front of them meaning Return

            // Get all the public properties of the object class Heat Pipe
            PropertyInfo[] piHeatPipe = (typeof(HeatPipe)).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            //for each property check if a column exist with that name, if yes
            //add the value to it
            for (int i = 0; i < piHeatPipe.Length; i++)
            {
                //if the column exist
                if (_dtHeatPipe.Columns.IndexOf("R_Summer_" + piHeatPipe[i].Name) >= 0)
                {
                    //add the value
                    drHeatPipe["R_Summer_" + piHeatPipe[i].Name] = (typeof(HeatPipe)).GetProperty(piHeatPipe[i].Name).GetValue(oHeatPipeSummer, null);
                    drHeatPipe["R_Winter_" + piHeatPipe[i].Name] = (typeof(HeatPipe)).GetProperty(piHeatPipe[i].Name).GetValue(oHeatPipeWinter, null);

                }
            }

            //add the row to the datatable
            _dtHeatPipe.Rows.Add(drHeatPipe);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void numOADB_ValueChanged(object sender, EventArgs e)
        {
            RecalculateRH_WETBULB("WB", "OA", "SUMMER");
        }

        //pass RH or WB so it recalculate the good one, and the type, either OA or RA
        private void RecalculateRH_WETBULB(string strRHOrWb, string strOaOrRa, string strSummerOrWinter)
        {
            //if the calculation is not lock calculate
            //if it's false it mean that it's the current control
            //that triggered the calculation
            if (!_bolLockRHAndWetBulbCalculation)
            {
                //turn true to make sure other control don't retrigger
                //all calculation in a endless loop
                _bolLockRHAndWetBulbCalculation = true;

                if (strRHOrWb == "RH")
                {
                    if (strOaOrRa == "OA")
                    {
                        if (strSummerOrWinter == "SUMMER")
                        {
                            //recalculate the RH
                            numOARH.Value = Tools.Formula.WETBULB_To_RH(numOADB.Value, numOAWB.Value, numAltitude.Value);
                        }
                        else
                        {
                            //recalculate the RH
                            numOARHWinter.Value = Tools.Formula.WETBULB_To_RH(numOADBWinter.Value, numOAWBWinter.Value, numAltitude.Value);
                        }
                    }
                    else
                    {
                        if (strSummerOrWinter == "SUMMER")
                        {
                            //recalculate the RH
                            numRARH.Value = Tools.Formula.WETBULB_To_RH(numRADB.Value, numRAWB.Value, numAltitude.Value);
                        }
                        else
                        {
                            //recalculate the RH
                            numRARHWinter.Value = Tools.Formula.WETBULB_To_RH(numRADBWinter.Value, numRAWBWinter.Value, numAltitude.Value);
                        }
                    }
                }
                else
                {
                    if (strOaOrRa == "OA")
                    {
                        if (strSummerOrWinter == "SUMMER")
                        {
                            //recalculate the wet bulb
                            numOAWB.Value = Tools.Formula.RH_To_WETBULB(numOADB.Value, numOARH.Value, numAltitude.Value);
                        }
                        else
                        {
                            //recalculate the wet bulb
                            numOAWBWinter.Value = Tools.Formula.RH_To_WETBULB(numOADBWinter.Value, numOARHWinter.Value, numAltitude.Value);
                        }
                    }
                    else
                    {
                        if (strSummerOrWinter == "SUMMER")
                        {
                            //recalculate the wet bulb
                            numRAWB.Value = Tools.Formula.RH_To_WETBULB(numRADB.Value, numRARH.Value, numAltitude.Value);
                        }
                        else
                        {
                            //recalculate the wet bulb
                            numRAWBWinter.Value = Tools.Formula.RH_To_WETBULB(numRADBWinter.Value, numRARHWinter.Value, numAltitude.Value);
                        }
                    }

                }

                //turn it back off so it can be retrigger later on
                _bolLockRHAndWetBulbCalculation = false;
            }
        }

        private void numOARH_ValueChanged(object sender, EventArgs e)
        {
            RecalculateRH_WETBULB("WB", "OA", "SUMMER");
        }

        private void numAltitude_ValueChanged(object sender, EventArgs e)
        {
            //altitude is special, it's the only value used for both
            //temperature so we need update both side
            RecalculateRH_WETBULB("WB", "OA", "SUMMER");
            RecalculateRH_WETBULB("WB", "RA", "SUMMER");
            RecalculateRH_WETBULB("WB", "OA", "WINTER");
            RecalculateRH_WETBULB("WB", "RA", "WINTER");
        }

        private void numOAWB_ValueChanged(object sender, EventArgs e)
        {
            RecalculateRH_WETBULB("RH", "OA", "SUMMER");
        }

        private void numRADB_ValueChanged(object sender, EventArgs e)
        {
            RecalculateRH_WETBULB("WB", "RA", "SUMMER");
        }

        private void numRARH_ValueChanged(object sender, EventArgs e)
        {
            RecalculateRH_WETBULB("WB", "RA", "SUMMER");
        }

        private void numRAWB_ValueChanged(object sender, EventArgs e)
        {
            RecalculateRH_WETBULB("RH", "RA", "SUMMER");
        }

        private void cboFinType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fill fin height
            Fill_FinHeight();
        }

        private void cboFPI_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                Fill_HeatPipeDatatable();

                if (_dtHeatPipe != null && _dtHeatPipe.Rows.Count > 0)
                {
                    ThreadProcess.Start(Public.LanguageString("Preparing data", "Préparation des données"));

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
                                _quoteform.DeleteFromQuoteHeatPipe(_intIndex);
                                newIndexToPush = _intIndex;
                                _quoteform.UpdateAdditionalItems(_intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.HeatPipe), newIndexToPush);
                                //Quoteform.DeleteFromQuoteAdditionalItems(intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.HeatPipe));
                            }
                            else
                            {
                                //since we actually always recreate the record
                                // save as new is simple, all i have to do is copy the additionnal items
                                //if reused the update function to instead duplicate record.
                                newIndexToPush = _quoteform.GetNextID("HeatPipes");
                                _quoteform.CopyAdditionalItems(_intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.HeatPipe), newIndexToPush);

                            }

                            ThreadProcess.Start(Public.LanguageString("Adding to quote", "Ajout à la soumission"));
                        }
                        else
                        {
                            newIndexToPush = _quoteform.GetNextID("HeatPipes");
                        }
                        AddToQuote(newIndexToPush);
                        _quoteform.RefreshBasketList();
                        _quoteform.SetQuoteIsModified(true);
                        ThreadProcess.Stop();
                        Focus();
                        Dispose();
                        //since even on update we need recreate the unit we will always add
                    }
                    else
                    {
                        ThreadProcess.UpdateMessage(Public.LanguageString("Generating Report", "Création du rapport"));
                        //generate the report for non-quote also
                        //add if to check to either generate or
                        //save to quote
                        HeatPipeReport.GenerateDataReport(_dtHeatPipe, true, 0, "");

                        ThreadProcess.Stop();
                        Focus();
                    }
                }
            }
            catch(Exception ex)
            {
                Public.PushLog(ex.ToString(),"frmQuickheatPipe cmdSave_Click");
                ThreadProcess.Stop();
                Focus();
            }
            finally
            {
                ThreadProcess.Stop();
                Focus();
            }
        }

        private void AddToQuote(int itemID)
        {
            _dtHeatPipe.Rows[0]["ItemType"] = Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.HeatPipe);
            _dtHeatPipe.Rows[0]["ItemID"] = itemID;
            _dsQuoteData.Tables["HeatPipes"].Rows.Add(_dtHeatPipe.Rows[0].ItemArray);

            DataTable copy = _dsQuoteData.Tables["HeatPipes"].Copy();
            DataRow[] list = copy.Select("", "itemID");

            _dsQuoteData.Tables["HeatPipes"].Rows.Clear();
            foreach (DataRow row in list)
            {
                _dsQuoteData.Tables["HeatPipes"].Rows.Add(row["QuoteID"], row["QuoteRevision"], row["QuoteRevisionText"], row["ItemType"], row["ItemID"], row["Username"], row["Tag"], row["Quantity"], row["Model"], row["AirFlowSupply"], row["AirFlowExhaust"], row["Symmetrical"], row["Altitude"], row["Summer_OADB"], row["Summer_OAWB"], row["Summer_OARH"], row["Summer_RADB"], row["Summer_RAWB"], row["Summer_RARH"], row["Winter_OADB"], row["Winter_OAWB"], row["Winter_OARH"], row["Winter_RADB"], row["Winter_RAWB"], row["Winter_RARH"], row["FinType"], row["FinHeight"], row["FinLength"], row["FPI"], row["Input_FPI"], row["Rows"], row["Shape"], row["AtmosphericPressure"], row["FlowType"], row["TiltAngle"], row["DefrostSetPoint"], row["Price"], row["R_Summer_FaceTubes"], row["R_Summer_FinLength"], row["R_Summer_AirFlowVelocity"], row["R_Summer_FinLengthOnSupplySide"], row["R_Summer_FinLengthOnReturnSide"], row["R_Summer_FPI"], row["R_Summer_NumberOfRows"], row["R_Summer_OutsideAirDryBulb"], row["R_Summer_ReturnAirDryBulb"], row["R_Summer_SupplyDryBulb"], row["R_Summer_ReturnDryBulb"], row["R_Summer_OutsideAirRelativeHumidity"], row["R_Summer_Coating"], row["R_Summer_DefrostSetPoint"], row["R_Summer_Symmetrical"], row["R_Summer_Altitude"], row["R_Summer_Weight"], row["R_Summer_HeatPipeCapacity"], row["R_Summer_Condensate"], row["R_Summer_PressureDropExhaustSide"], row["R_Summer_SensibleEffectiveness"], row["R_Summer_LatentEffectiveness"], row["R_Summer_TotalEffectiveness"], row["R_Summer_SensibleCoolingCoilEffectiveness"], row["R_Summer_TotalCoolingCoilEffectiveness"], row["R_Summer_ExhaustAirRelativeHumidity"], row["R_Summer_SupplyAirRelativeHumidity"], row["R_Summer_AirFlowExhaust"], row["R_Summer_AirFlowSupply"], row["R_Summer_ReturnAirRelativeHumidity"], row["R_Summer_FinsIndex"], row["R_Summer_PressureDropSupplySide"], row["R_Summer_OutsideAirWetBulb"], row["R_Summer_ReturnAirWetBulb"], row["R_Summer_ReturnWetBulb"], row["R_Summer_SupplyWetBulb"], row["R_Summer_OutsideAirGrains"], row["R_Summer_ReturnAirGrains"], row["R_Summer_ReturnGrains"], row["R_Summer_SupplyGrains"], row["R_Summer_OutsideAirEnthalpy"], row["R_Summer_ReturnAirEnthalpy"], row["R_Summer_ReturnEnthalpy"], row["R_Summer_SupplyEnthalpy"], row["R_Summer_MixingAirFlowSupplyTemperature"], row["R_Summer_Shape"], row["R_Summer_AtmosphericPressure"], row["R_Summer_AirFlowSupplyBypass"], row["R_Summer_SupplyAirVelocity"], row["R_Summer_ExhaustAirVelocity"], row["R_Summer_ParallelFlow"], row["R_Summer_TiltAngle"], row["R_Summer_ShowWarningMessage"], row["R_Winter_FaceTubes"], row["R_Winter_FinLength"], row["R_Winter_AirFlowVelocity"], row["R_Winter_FinLengthOnSupplySide"], row["R_Winter_FinLengthOnReturnSide"], row["R_Winter_FPI"], row["R_Winter_NumberOfRows"], row["R_Winter_OutsideAirDryBulb"], row["R_Winter_ReturnAirDryBulb"], row["R_Winter_SupplyDryBulb"], row["R_Winter_ReturnDryBulb"], row["R_Winter_OutsideAirRelativeHumidity"], row["R_Winter_Coating"], row["R_Winter_DefrostSetPoint"], row["R_Winter_Symmetrical"], row["R_Winter_Altitude"], row["R_Winter_Weight"], row["R_Winter_HeatPipeCapacity"], row["R_Winter_Condensate"], row["R_Winter_PressureDropExhaustSide"], row["R_Winter_SensibleEffectiveness"], row["R_Winter_LatentEffectiveness"], row["R_Winter_TotalEffectiveness"], row["R_Winter_SensibleCoolingCoilEffectiveness"], row["R_Winter_TotalCoolingCoilEffectiveness"], row["R_Winter_ExhaustAirRelativeHumidity"], row["R_Winter_SupplyAirRelativeHumidity"], row["R_Winter_AirFlowExhaust"], row["R_Winter_AirFlowSupply"], row["R_Winter_ReturnAirRelativeHumidity"], row["R_Winter_FinsIndex"], row["R_Winter_PressureDropSupplySide"], row["R_Winter_OutsideAirWetBulb"], row["R_Winter_ReturnAirWetBulb"], row["R_Winter_ReturnWetBulb"], row["R_Winter_SupplyWetBulb"], row["R_Winter_OutsideAirGrains"], row["R_Winter_ReturnAirGrains"], row["R_Winter_ReturnGrains"], row["R_Winter_SupplyGrains"], row["R_Winter_OutsideAirEnthalpy"], row["R_Winter_ReturnAirEnthalpy"], row["R_Winter_ReturnEnthalpy"], row["R_Winter_SupplyEnthalpy"], row["R_Winter_MixingAirFlowSupplyTemperature"], row["R_Winter_Shape"], row["R_Winter_AtmosphericPressure"], row["R_Winter_AirFlowSupplyBypass"], row["R_Winter_SupplyAirVelocity"], row["R_Winter_ExhaustAirVelocity"], row["R_Winter_ParallelFlow"], row["R_Winter_TiltAngle"], row["R_Winter_ShowWarningMessage"]);
            }
        }

        private void numOADBWinter_ValueChanged(object sender, EventArgs e)
        {
            RecalculateRH_WETBULB("WB", "OA", "WINTER");
        }

        private void numOAWBWinter_ValueChanged(object sender, EventArgs e)
        {
            RecalculateRH_WETBULB("RH", "OA", "WINTER");
        }

        private void numOARHWinter_ValueChanged(object sender, EventArgs e)
        {
            RecalculateRH_WETBULB("WB", "OA", "WINTER");
        }

        private void numRADBWinter_ValueChanged(object sender, EventArgs e)
        {
            RecalculateRH_WETBULB("WB", "RA", "WINTER");
        }

        private void numRAWBWinter_ValueChanged(object sender, EventArgs e)
        {
            RecalculateRH_WETBULB("RH", "RA", "WINTER");
        }

        private void numRARHWinter_ValueChanged(object sender, EventArgs e)
        {
            RecalculateRH_WETBULB("WB", "RA", "WINTER");
        }

        /// <summary>
        /// Calculate the price of the heat pipe according to what the controls are set on.
        /// </summary>
        /// <returns>Price of Heat Pipe</returns>
        private decimal GetHeatPipePrice()
        {
            decimal decEquivalentCoilPrice = 0m;

            try
            {
                var heatPipeCoil = new Pricing.StandardCoil(
                    FinTypeParameter(),
                    1m,
                    numNumberOfRows.Value,
                    FPI(),
                    FinHeightParameter(),
                    numFinLength.Value,
                    2.5m,
                    0.008m,
                    "CU",
                    0.016m,
                    0.052m,
                    Convert.ToDecimal(
                        Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilFinMaterial"],
                            "FinMaterial = 'ALUMINIUM'", "").Rows[0]["MaterialDensity"]),
                    Convert.ToDecimal(
                        Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilFinMaterial"],
                            "FinMaterial = 'ALUMINIUM'", "").Rows[0]["PricePerLbs"]),
                    Convert.ToDecimal(
                        Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilCasingMaterial"],
                            "CasingMaterial = 'Galvanized Steel'", "").Rows[0]["MaterialDensity"]),
                    Convert.ToDecimal(
                        Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilCasingMaterial"],
                            "CasingMaterial = 'Galvanized Steel'", "").Rows[0]["PricePerLbs"]),
                    Convert.ToDecimal(
                        Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilTubeMaterial"],
                            "TubeMaterial = 'COPPER'", "").Rows[0]["MaterialDensity"]),
                    Convert.ToDecimal(
                        Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilTubeMaterial"],
                            "TubeMaterial = 'COPPER'", "").Rows[0]["PricePerLbs"]));

                decEquivalentCoilPrice = heatPipeCoil.Price;
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"frmQuickHeatPipe getHeatPipePrice");
            }

            //Heat Pipe price is 2 times the price of a normal coil
            return decEquivalentCoilPrice * 2m;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmQuickHeatPipe_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }

        private void numAirFlowSupply_ValueChanged(object sender, EventArgs e)
        {

        }

    }
}