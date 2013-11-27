using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;


namespace RefplusWebtools.QuickCondenser
{
    public partial class FrmQuickCondenser : Form
    {
        //form need access to his background code
        private readonly QuickCondenserCode _backgroundCode = new QuickCondenserCode();

        //datatable containing condenser to show up in the list
        private DataTable _dtCondenserResult = new DataTable();

        //list of tables
        private readonly string[] _strTableList = { "CondenserNREHermeticFactor", "CondenserNREOpenDriveFactor", "CondenserNRECompressorType", "Drawings", "CondenserModel", "CondenserFanArrangement", "Voltage", "CondenserRefrigerant", "CondenserType", "CondenserXref", "CondenserSerie", "AirFlowType", "CondenserFPI", "MotorFLA", "StandardConnectionCondenserInlet", "StandardConnectionCondenserOutlet", "CondenserMotor", "CondenserMotorMount", "CondenserFan", "CondenserFanGuard", "MotorModel", "MotorMountModel", "FanModel", "FanGuardModel", "FuseSize", "ControlPanel_SpecialPrice", "ControlPanel_PanelOptionPrices", "ControlPanel_Options", "ControlPanel_OptionsSelection", "ControlPanel_Panels", "ControlPanel_PanelsSelection", "ControlPanel_PanelVoltage", "PumpOption", "ReceiverType", "ReceiverModels", "ReceiverHeater", "ReceiverTransformers", "ReceiverValves", "PumpAmps", "PumpGPM", "PumpHP", "PumpInfo", "PumpSelection", "PumpTubeDiameter", "HeatRejectionFactor", "ReceiverReinforcedBasePrice", "ControlPanel_PanelPrices" };

        //datatable that contain the rerigerant circuit informations
        public DataTable DtRefrigrantCircuit = new DataTable();

        //tables that holds all selected values over the multiple windows
        DataTable _dtCondenserInputs = new DataTable();
        DataTable _dtControlPanelInputs = new DataTable();
        DataTable _dtReceiverInputs = new DataTable();
        DataTable _dtSecondaryOptionsInputs = new DataTable();

        //this is used to build the approval drawing nomenclature.
        //since the value is in the secondary form we need to retreive it then use it.
        private static string _legNomenclature = "";

        private bool _blockRatingChkToTriggerSelection;

        //link to the quote form
        private readonly Quotes.FrmQuotes _quoteform;
        //dataset of the quote
        private readonly DataSet _dsQuoteData;
        //index of the row, -1 mean not loading so we know it's a new record
        private readonly int _intIndex = -1;
        //is true if the form is loaded from quote, false if loaded ordinary
        private readonly bool _bolQuoteSelection;

        //these variable are used to store the latest value of all controls in the
        //circuit add/edit form
        public string LastCapacityType = "THR - Total Heat Rejection / Reclaim Capacity";
        public string LastCompressorType = "Open Drive";
        public decimal LastSST = 45m;
        public string LastRefrigerant = "R-134a";
        public decimal LastCondensingTemp = 110m;
        public decimal LastTHR = 1m;

        public FrmQuickCondenser()
        {
            InitializeComponent();
        }

        public FrmQuickCondenser(Quotes.FrmQuotes quoteform, DataSet dsQuoteData, int intIndex)
        {
            InitializeComponent();
            _quoteform = quoteform;
            _dsQuoteData = dsQuoteData;
            _intIndex = intIndex;
            _bolQuoteSelection = true;

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void chkAttachToCondensingUnit_CheckedChanged(object sender, EventArgs e)
        {
            cboCondensingUnit.Visible = chkAttachToCondensingUnit.Checked;
        }

        private void AutoSelectTextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }

        private void frmQuickCondenser_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            Query.LoadTables(_strTableList);

            DtRefrigrantCircuit = Tables.DtCondenserRefrigerantCircuits();

            //load the color settings for condenser type labels legend
            LoadColorLabels();

            //fill all the combobox
            Fill_Combobox();

            //set all the defaults
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

            DataTable dtSavedInfo = Public.SelectAndSortTable(_dsQuoteData.Tables["Condensers"], "ItemType = " + Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.Condenser) + " AND ItemID = " + _intIndex, "");
            DataRow drSavedInfo = dtSavedInfo.NewRow();
            drSavedInfo.ItemArray = dtSavedInfo.Rows[0].ItemArray;

            chkAttachToCondensingUnit.Checked = (drSavedInfo["Input_AttachedToCondensingUnit"].ToString() == "1");

            if (chkAttachToCondensingUnit.Checked)
            {
                if (cboCondensingUnit.FindString(drSavedInfo["Input_CondensingUnitSystemName"].ToString()) >= 0)
                {
                    cboCondensingUnit.SelectedIndex = cboCondensingUnit.FindString(drSavedInfo["Input_CondensingUnitSystemName"].ToString());
                }
                else
                {
                    strErrors = strErrors + Public.LanguageString("- Cannot find linked Condensing Unit", "- Incapable de trouver le groupe compresseur-condenseur sélectionné") + Environment.NewLine;
                }
            }

            txtTag.Text = drSavedInfo["Input_Tag"].ToString();

            numQuantity.Value = Convert.ToDecimal(drSavedInfo["Quantity"]);

            numAltitude.Value = Convert.ToDecimal(drSavedInfo["Input_Altitude"]);

            numAmbientTemperature.Value = Convert.ToDecimal(drSavedInfo["Input_AmbientTemperature"]);

            if (cboFanArrangement.FindString(drSavedInfo["Input_FanArrangement"].ToString()) >= 0)
            {
                cboFanArrangement.SelectedIndex = cboFanArrangement.FindString(drSavedInfo["Input_FanArrangement"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected fan arrangement", "- Incapable de trouver l'arrangment des ailettes sélectionné") + Environment.NewLine;
            }

            if (cboTypeOfCondenser.FindString(drSavedInfo["Input_TypeOfCondenser"].ToString()) >= 0)
            {
                cboTypeOfCondenser.SelectedIndex = cboTypeOfCondenser.FindString(drSavedInfo["Input_TypeOfCondenser"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected type of condenser", "- Incapable de trouver le type de condenseur sélectionné") + Environment.NewLine;
            }

            //2011-04-21 : inverted the air flow type and type of condenser loading because of a change that make
            //type of condenser refreshing content of the air flow type.
            if (cboAirFlowType.FindString(drSavedInfo["Input_AirFlowType"].ToString()) >= 0)
            {
                cboAirFlowType.SelectedIndex = cboAirFlowType.FindString(drSavedInfo["Input_AirFlowType"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected air flow type", "- Incapable de trouver le type de débit d'air sélectionné") + Environment.NewLine;
            }

            if (cboTypeOfCondenser.FindString(drSavedInfo["Input_TypeOfCondenser"].ToString()) >= 0)
            {
                cboTypeOfCondenser.SelectedIndex = cboTypeOfCondenser.FindString(drSavedInfo["Input_TypeOfCondenser"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected type of condenser", "- Incapable de trouver le type de condenseur sélectionné") + Environment.NewLine;
            }

            if (cboCondenserSerie.FindString(drSavedInfo["Input_CondenserSerie"].ToString()) >= 0)
            {
                cboCondenserSerie.SelectedIndex = cboCondenserSerie.FindString(drSavedInfo["Input_CondenserSerie"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected condenser serie", "- Incapable de trouver la série de condenseur sélectionné") + Environment.NewLine;
            }

            numTotalHeatRecovery.Value = Convert.ToDecimal(drSavedInfo["Input_TotalHeatRecovery"]);

            if (cboFPI.FindString(drSavedInfo["Input_FinsPerInch"].ToString()) >= 0)
            {
                cboFPI.SelectedIndex = cboFPI.FindString(drSavedInfo["Input_FinsPerInch"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected fins per inch", "- Incapable de trouver le nombre d'ailettes par pouces sélectionné") + Environment.NewLine;
            }

            chkRating.Checked = true;

            if (cboModel.FindString(drSavedInfo["Input_RatingModel"].ToString()) >= 0)
            {
                cboModel.SelectedIndex = cboModel.FindString(drSavedInfo["Input_RatingModel"].ToString());
            }
            else
            {
                strErrors = strErrors + Public.LanguageString("- Cannot find selected condenser model", "- Incapable de trouver le condenseur sélectionné") + Environment.NewLine;
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

            DataTable dtLoadRefrigerant = Public.SelectAndSortTable(_dsQuoteData.Tables["RefrigerantCircuits"], "ItemType = " + Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.Condenser) + " AND ItemID = " + _intIndex, "");

            //to be reworked

            foreach (DataRow drRefCirc in dtLoadRefrigerant.Rows)
            {
                AddNewCircuit(drRefCirc["RefrigerantType"].ToString(),
                              Convert.ToDecimal(drRefCirc["CondenserTemperature"]),
                              Convert.ToDecimal(drRefCirc["THR"]),
                              Convert.ToDecimal(drRefCirc["RefrigerantMultiplier"]),
                              drRefCirc["CircuitType"].ToString(),
                              Convert.ToDecimal(drRefCirc["NonConvertedTHR"]),
                              drRefCirc["CompressorType"].ToString(),
                              Convert.ToDecimal(drRefCirc["SST"]));

            }

            ConfirmCircuits();

            dtLoadRefrigerant.Dispose();

            if (strErrors != "")
            {
                MessageBox.Show(Public.LanguageString("The following error(s) happened while loading", "La/Les erreur(s) suivantes sont survenue(s) lors du chargement") + Environment.NewLine + strErrors, Public.LanguageString("Error while loading", "Erreur lors du chargement"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Fill_Combobox()
        {
            //fill fan arangement
            Fill_FanArrangement();

            //fill the type of condenser
            Fill_TypeOfCondenser();

            //fill voltage
            //Fill_Voltage();

            ////fill the condenser Serie
            //Fill_CondenserSerie();

            //2011-04-21 : this is change to be executed when the type of condenser change
            //fill air flow type
            //Fill_AirFlowType();

            //fill fpi
            Fill_FPI();

            //fill model
            Fill_Model();

        }

        private void LoadColorLabels()
        {
            lblUnderSizeColor.BackColor = CondenserSelectionType.ColorUndersize;
            lblOverSizeColor.BackColor = CondenserSelectionType.ColorOversize;
            lblPerfectMatchColor.BackColor = CondenserSelectionType.ColorPerfectMatch;
        }

        private void SetDefaults()
        {
            //select all fan arrangment
            ComboBoxControl.SetIDDefaultValue(cboFanArrangement, "ALL");

            //select air cooled (1) type of condenser
            ComboBoxControl.SetIDDefaultValue(cboTypeOfCondenser, "1");

            //240/3/60 = 3
            ComboBoxControl.SetIDDefaultValue(cboVoltage, "3");

            ////set air flow type vertical = 2
            //ComboBoxControl.SetIDDefaultValue(cboAirFlowType, "2");

            //set standard fin
            cboFPI.SelectedIndex = 0;

            //select first model
            cboModel.SelectedIndex = 0;

        }

        private string FPIParameter()
        {
            string strFPIParameter = ComboBoxControl.ItemInformations(cboFPI, Public.DSDatabase.Tables["CondenserFPI"], "UniqueID")[0]["FPIParameter"].ToString();

            if (strFPIParameter == "0")
            {//0 mean standard fin
                //we need to check if the series on "std product" if yes hardcode 10,12 FPI
                //otherwise use the value from the series column "standardfpi"
                if (cboCondenserSerie.Text == @"STANDARD PRODUCT LINE")
                {
                    strFPIParameter = "10,12";
                }
                else
                {
                    string strCondenserSeries = CondenserSerie();
                    strFPIParameter = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondenserSerie"], "Motor ='" + strCondenserSeries.Substring(0, 1) + "' AND CoilArr = '" + strCondenserSeries.Substring(1, 1) + "'", "").Rows[0]["StandardFPI"].ToString();
                }
            }

            return strFPIParameter;
        }

        //fill the fpi
        private void Fill_FPI()
        {
            cboFPI.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox

            //loop through all fpi
            foreach (DataRow drFPI in Public.DSDatabase.Tables["CondenserFPI"].Rows)
            {
                string strIndex = drFPI["UniqueID"].ToString();
                string strText = drFPI["FPI"].ToString();
                ComboBoxControl.AddItem(cboFPI, strIndex, strText);
            }
        }

        private string RatingModelParameter()
        {
            return chkRating.Checked ? ComboBoxControl.IndexInformation(cboModel) : "ALL";
        }

        //fill model for rating mode
        private void Fill_Model()
        {
            cboModel.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox

            DataTable dtListOfModels = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondenserXref"], UserInformation.CurrentSite + "_condenserXRefModel <> ''", UserInformation.CurrentSite + "_condenserXRefModel ASC");

            //loop through all model
            foreach (DataRow drModels in dtListOfModels.Rows)
            {
                string strIndex = drModels["CondenserType"] + "," +
                                  drModels["Motor"] + "," +
                                  drModels["CoilArr"] + "," +
                                  drModels["FanWide"] + "," +
                                  drModels["FanLong"] + "," +
                                  drModels["Row"] + "," +
                                  drModels["FPI"] + "," +
                                  drModels["AirFlow"];

                string strText = drModels[UserInformation.CurrentSite + "_condenserXRefModel"].ToString();
                ComboBoxControl.AddItem(cboModel, strIndex, strText);
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

            DataTable dtValidAirFlow = Public.SelectAndSortTable(Public.DSDatabase.Tables["AirFlowType"], "CondenserType LIKE '%" + TypeOfCondenserParameter() + "%'", "AirFlowType");

            //loop through all air flow
            foreach (DataRow drAirFlowType in dtValidAirFlow.Rows)
            {
                string strIndex = drAirFlowType["UniqueID"].ToString();
                string strText = drAirFlowType["AirFlowType"].ToString();
                ComboBoxControl.AddItem(cboAirFlowType, strIndex, strText);
            }

            cboAirFlowType.SelectedIndex = cboAirFlowType.FindString("VERTICAL") >= 0 ? cboAirFlowType.FindString("VERTICAL") : 0;
        }

        private string[] CoilArrangement()
        {
            //list of unit type
            string[] strCondenserSerie = ComboBoxControl.IndexInformation(cboCondenserSerie).Split(Convert.ToChar(","));

            //array that will contain the list of coilarr
            var strCoilArrangement = new string[strCondenserSerie.Length];

            //fill the array
            for (int intCondenserSerie = 0; intCondenserSerie < strCondenserSerie.Length; intCondenserSerie++)
            {
                strCoilArrangement[intCondenserSerie] = strCondenserSerie[intCondenserSerie].Substring(1, 1);
            }

            return strCoilArrangement;
        }

        private string[] Motor()
        {
            //list of unit type
            string[] strCondenserSerie = ComboBoxControl.IndexInformation(cboCondenserSerie).Split(Convert.ToChar(","));

            //array that will contain the list of motor
            var strMotors = new string[strCondenserSerie.Length];

            //fill the array
            for (int intCondenserSerie = 0; intCondenserSerie < strCondenserSerie.Length; intCondenserSerie++)
            {
                strMotors[intCondenserSerie] = strCondenserSerie[intCondenserSerie].Substring(0, 1);
            }

            return strMotors;
        }

        private string CondenserSerie()
        {
            return ComboBoxControl.IndexInformation(cboCondenserSerie);
        }

        private void Fill_CondenserSerie()
        {
            //2011-02-21 : Simon is making me change this to display specific serie depending on the condenser type

            cboCondenserSerie.Items.Clear();

            if (TypeOfCondenserParameter() == "C")
            {
                ComboBoxControl.AddItem(cboCondenserSerie, "CR,MR,LR,VR,NR", "STANDARD PRODUCT LINE");
            }

            //these variable as use for easier modification of index or text showing
            //in the combobox

            //clean the inactive record
            DataTable dtClearedCondenserSerie = Public.SelectAndSortTable(Query.RemoveInactiveRecords(Public.DSDatabase.Tables["CondenserSerie"]), "Sites like '%" + UserInformation.CurrentSite + "%' AND Type = '" + TypeOfCondenserParameter() + "'", "");

            //loop through all conenser serie
            foreach (DataRow drCondenserSerie in dtClearedCondenserSerie.Rows)
            {
                string strIndex = drCondenserSerie["Motor"] + drCondenserSerie["CoilArr"].ToString();
                string strText = drCondenserSerie["Motor"].ToString().Replace("S", "V") + drCondenserSerie["CoilArr"] + " - " + drCondenserSerie["Description"];
                ComboBoxControl.AddItem(cboCondenserSerie, strIndex, strText);
            }

            //set condenser serie to first
            cboCondenserSerie.SelectedIndex = 0;

            //cboCondenserSerie.Items.Clear();
            //ComboBoxControl.AddItem(cboCondenserSerie, "CR,MR,LR,VR,NR", "STANDARD PRODUCT LINE");
            ////these variable as use for easier modification of index or text showing
            ////in the combobox
            //string strIndex = "";
            //string strText = "";

            ////clean the inactive record
            //DataTable dtClearedCondenserSerie = Public.SelectAndSortTable(Query.RemoveInactiveRecords(Public.dsDATABASE.Tables["CondenserSerie"]), "Sites like '%" + UserInformation.CURRENT_SITE + "%'", "");

            ////loop through all conenser serie
            //foreach (DataRow drCondenserSerie in dtClearedCondenserSerie.Rows)
            //{
            //    strIndex = drCondenserSerie["Motor"].ToString() + drCondenserSerie["CoilArr"].ToString();
            //    strText = drCondenserSerie["Motor"].ToString().Replace("S", "V") + drCondenserSerie["CoilArr"].ToString() + " - " + drCondenserSerie["Description"].ToString();
            //    ComboBoxControl.AddItem(cboCondenserSerie, strIndex, strText);
            //}
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

        //get voltageID
        private int VoltageID()
        {
            return Convert.ToInt32(ComboBoxControl.ItemInformations(cboVoltage, Public.DSDatabase.Tables["Voltage"], "UniqueID")[0]["VoltageID"]);
        }

        //get frequency capacity adjustement
        private decimal FrequencyCapacityAdjustment()
        {
            return Convert.ToDecimal(ComboBoxControl.ItemInformations(cboVoltage, Public.DSDatabase.Tables["Voltage"], "UniqueID")[0]["CapacityMultiplier"]);
        }


        private void Fill_Voltage_Filter(string motorCoilArr)
        {
            //2012-03-01 : #2664 : voltage should reselect same all the time
            string strCurrentValue = ComboBoxControl.IndexInformation(cboVoltage);

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

            ComboBoxControl.SetIDDefaultValueIfExistOnly(cboVoltage, strCurrentValue);

            if (cboVoltage.SelectedIndex == -1)
            {
                ComboBoxControl.SetIDDefaultValue(cboVoltage, "3");
            }
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
            //these variable as use for easier modification of index or text showing
            //in the combobox
            //for each type of condenser
            foreach (DataRow drTypeOfCondenser in Public.DSDatabase.Tables["CondenserType"].Rows)
            {
                string strIndex = drTypeOfCondenser["UniqueID"].ToString();
                string strText = drTypeOfCondenser["CondenserType"].ToString();
                ComboBoxControl.AddItem(cboTypeOfCondenser, strIndex, strText);
            }

            cboTypeOfCondenser.SelectedIndex = 0;
        }

        //this return the Fan Adjustement 
        private string FanArangementParameter()
        {
            if (ComboBoxControl.IndexInformation(cboFanArrangement) == "ALL")
            {//if ALL return ALL
                return "ALL";
            }
            //if Not ALL return "(fanlong)x(fanwide)"
            return ComboBoxControl.ItemInformations(cboFanArrangement, Public.DSDatabase.Tables["CondenserFanArrangement"], "UniqueID")[0]["FanWide"] + "x" + ComboBoxControl.ItemInformations(cboFanArrangement, Public.DSDatabase.Tables["CondenserFanArrangement"], "UniqueID")[0]["FanLong"];
        }

        //fill fan arrangement
        private void Fill_FanArrangement()
        {
            cboFanArrangement.Items.Clear();
            ComboBoxControl.AddItem(cboFanArrangement, "ALL", "ALL");
            //these variable as use for easier modification of index or text showing
            //in the combobox
            //for each fan arangement
            foreach (DataRow drFanArrangement in Public.DSDatabase.Tables["CondenserFanArrangement"].Rows)
            {
                string strIndex = drFanArrangement["UniqueID"].ToString();
                string strText = drFanArrangement["FanArrangement"].ToString();
                ComboBoxControl.AddItem(cboFanArrangement, strIndex, strText);
            }
        }

        private void cmdAddCircuit_Click(object sender, EventArgs e)
        {
            var frmCirc = new FrmCircuitEdit(this, TypeOfCondenserParameter(), -1, numAmbientTemperature.Value);
            frmCirc.ShowDialog();

            //AddCircuit();
        }

        public void ConfirmCircuits()
        {
            //fill the list of circuit
            Fill_RefrigerantCircuitsList(false);
        }

        public void EditCircuit(int circuitIndex, string refrigerant, decimal condensingTemperature, decimal capacity, decimal refrigerantCapacityAdjustement, string circuitType, decimal nonConvertedTHR, string compressorType, decimal sst)
        {
            DataTable dtTemp = DtRefrigrantCircuit.Copy();

            DtRefrigrantCircuit.Rows.Clear();

            //this readd in order the circuit and when it get to the index of the one we edit it replace with received values
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                if (i == circuitIndex)
                {
                    AddNewCircuit(refrigerant, condensingTemperature, capacity, refrigerantCapacityAdjustement, circuitType, nonConvertedTHR, compressorType, sst);
                }
                else
                {
                    AddNewCircuit(dtTemp.Rows[i]["RefrigerantType"].ToString(), Convert.ToDecimal(dtTemp.Rows[i]["CondenserTemperature"]), Convert.ToDecimal(dtTemp.Rows[i]["THR"]), Convert.ToDecimal(dtTemp.Rows[i]["RefrigerantMultiplier"]), dtTemp.Rows[i]["CircuitType"].ToString(), Convert.ToDecimal(dtTemp.Rows[i]["NonConvertedTHR"]), dtTemp.Rows[i]["CompressorType"].ToString(), Convert.ToDecimal(dtTemp.Rows[i]["SST"]));
                }
            }
        }

        public void AddNewCircuit(string refrigerant, decimal condensingTemperature, decimal capacity, decimal refrigerantCapacityAdjustement, string circuitType, decimal nonConvertedTHR, string compressorType, decimal sst)
        {
            //add a circuit
            _backgroundCode.AddCircuit(DtRefrigrantCircuit, Public.DSDatabase.Tables["StandardConnectionCondenserInlet"], Public.DSDatabase.Tables["StandardConnectionCondenserOutlet"], refrigerant, condensingTemperature, capacity, refrigerantCapacityAdjustement, numAmbientTemperature.Value, circuitType, nonConvertedTHR, compressorType, sst);

            UpdateAmbientTempMaxValue();
        }

        private void UpdateAmbientTempMaxValue()
        {
            numAmbientTemperature.Maximum = _backgroundCode.GetLowestCondensingTemperature(DtRefrigrantCircuit) - 1m;
        }

        //fill the refrigerant circuit listview
        private void Fill_RefrigerantCircuitsList(bool bolSelectingByClickingCondenser)
        {
            //clear the total thr/td label
            Clear_lblTotalCapacityValue();

            //clear the listview
            lvCircuits.Items.Clear();

            //total the thr/td
            decimal decTotalCapacityPerTD = 0;

            //for each circuits
            for (int intRefrigerantCircuits = 0; intRefrigerantCircuits < DtRefrigrantCircuit.Rows.Count; intRefrigerantCircuits++)
            {
                lvCircuits.Items.Add(new ListViewItem(new[] { intRefrigerantCircuits.ToString(CultureInfo.InvariantCulture), DtRefrigrantCircuit.Rows[intRefrigerantCircuits]["RefrigerantType"].ToString(), DtRefrigrantCircuit.Rows[intRefrigerantCircuits]["CondenserTemperature"].ToString(), DtRefrigrantCircuit.Rows[intRefrigerantCircuits]["THR"].ToString(), DtRefrigrantCircuit.Rows[intRefrigerantCircuits]["TD"].ToString(), Convert.ToDecimal(Math.Round(Convert.ToDecimal(DtRefrigrantCircuit.Rows[intRefrigerantCircuits]["THR_PER_TD"]) / 1000m, 2)).ToString(CultureInfo.InvariantCulture), "", "", "", "" }));

                //running total of capacity
                decTotalCapacityPerTD = decTotalCapacityPerTD + Convert.ToDecimal(DtRefrigrantCircuit.Rows[intRefrigerantCircuits]["THR_PER_TD"]);
            }

            //fill the total thr/td label
            Set_lblTotalCapacityValue(decTotalCapacityPerTD);

            //check if we need to fill the condenser list
            CheckToFillCondenserList(bolSelectingByClickingCondenser);
        }

        //Set lblTotalCapacityValue
        private void Set_lblTotalCapacityValue(decimal decTotalCapacityPerTD)
        {
            lblTotalCapacityValue.Text = Convert.ToDecimal(Math.Round(decTotalCapacityPerTD / 1000m, 2)) + @" MBH";
        }

        //Clear lblTotalCapacityValue
        private void Clear_lblTotalCapacityValue()
        {
            lblTotalCapacityValue.Text = "";
        }

        private void GetCondenserModelList(bool bolSelectingByClickingCondenser)
        {
            Cursor = Cursors.WaitCursor;

            //get the list of condensers
            _dtCondenserResult = _backgroundCode.GetCondenserModels(DtRefrigrantCircuit, Query.RemoveInactiveRecords(Public.DSDatabase.Tables["CondenserModel"].Copy()), Public.DSDatabase.Tables["CondenserXref"], FrequencyCapacityAdjustment(), VoltageID(), cboVoltage.Text, numAltitude.Value, numAmbientTemperature.Value, TypeOfCondenserParameter(), FanArangementParameter(), Motor(), CoilArrangement(), VoltageMotor(), VoltageCoilArr(), AirFlowTypeParameter(), numTotalHeatRecovery.Value, FPIParameter(), RatingModelParameter());

            //if we have condensers
            if (_dtCondenserResult.Rows.Count > 0)
            {
                //fill the list view
                Fill_CondenserModelList(bolSelectingByClickingCondenser);
            }
            else
            {
                lvCondenser.Items.Clear();
                lvCondenser.Refresh();
            }

            Cursor = Cursors.Default;
        }

        private void Fill_CondenserModelList(bool bolSelectingByClickingCondenser)
        {
            lvCondenser.Items.Clear();
            lvCondenser.Refresh();

            //this variable will changed to the best match
            //position if there is one, it will be pass to a function
            //to select the best match by default
            int intBestMatchingCondenserPosition = -1;

            //for each model, add it to the list
            for (int intCondenserModel = 0; intCondenserModel < _dtCondenserResult.Rows.Count; intCondenserModel++)
            {
                //create a selection type object
                var cstMyType = new CondenserSelectionType(Convert.ToInt32(_dtCondenserResult.Rows[intCondenserModel]["CondenserSelectionType"]));

                //if it's a perfect match, store the position so we can
                //select it by default after the listview is filled
                if (cstMyType.Identification == CondenserSelectionType.PerfectMatch)
                {
                    intBestMatchingCondenserPosition = intCondenserModel;
                }

                //create list item to be able to modify it's structure and GUI
                var newItem = new GlacialComponents.Controls.GLItem(lvCondenser);
                newItem.SubItems[0].Text = intCondenserModel.ToString(CultureInfo.InvariantCulture);
                newItem.SubItems[1].Text = _dtCondenserResult.Rows[intCondenserModel]["CondenserModel"].ToString();
                newItem.SubItems[2].Text = _dtCondenserResult.Rows[intCondenserModel]["CondenserCircQty"].ToString();
                newItem.SubItems[3].Text = _dtCondenserResult.Rows[intCondenserModel]["THR_at_1F"].ToString();
                newItem.SubItems[4].Text = Convert.ToInt32(_dtCondenserResult.Rows[intCondenserModel]["FanWide"]) + " x " + Convert.ToInt32(_dtCondenserResult.Rows[intCondenserModel]["FanLong"]);
                //NewItem.SubItems[5].Text = dtCondenserResult.Rows[intCondenserModel]["ConnDischarge"].ToString();
                //NewItem.SubItems[6].Text = dtCondenserResult.Rows[intCondenserModel]["ConnLiquid"].ToString();
                newItem.SubItems[5].Control = GetAdjustAmbientButton(intCondenserModel.ToString(CultureInfo.InvariantCulture), cstMyType.Color, _dtCondenserResult.Rows[intCondenserModel]["Final_Ambient"] + " °F");
                newItem.SubItems[6].Text = Math.Round(Convert.ToDecimal(_dtCondenserResult.Rows[intCondenserModel]["CurrentCapacity"]) / 1000m, 2).ToString(CultureInfo.InvariantCulture);
                newItem.SubItems[7].Text = Math.Round(Convert.ToDecimal(_dtCondenserResult.Rows[intCondenserModel]["Final_Capacity"]) / 1000m, 2).ToString(CultureInfo.InvariantCulture);
                newItem.SubItems[8].Control = RateButtonInList(intCondenserModel.ToString(CultureInfo.InvariantCulture), cstMyType.Color);
                newItem.SubItems[9].Text = _dtCondenserResult.Rows[intCondenserModel]["FPI"].ToString();

                //change the color according to the selected selection type
                newItem.BackColor = cstMyType.Color;

                //add the list item
                lvCondenser.Items.Add(newItem);
            }

            lvCondenser.Refresh();

            if (bolSelectingByClickingCondenser == false)
            {
                //if in rating mode we display the info of the first index
                //else (not rating mode) we display the info of the best match if there is.
                DisplayInfoOfIndex(chkRating.Checked ? 0 : intBestMatchingCondenserPosition);
            }

        }

        //remove a circuit
        private void cmdRemoveCircuit_Click(object sender, EventArgs e)
        {
            if (lvCircuits.SelectedItems.Count > 0)
            {
                ThreadProcess.Start(Public.LanguageString("Running Selection", "Sélection en cours"));
                //extract the row id of the listview
                int intRow = Convert.ToInt32(lvCircuits.SelectedItems[0].SubItems[0].Text);

                //remove the circuits
                _backgroundCode.RemoveCircuit(DtRefrigrantCircuit, intRow, numAmbientTemperature.Value);
            }

            //refresh the listview
            Fill_RefrigerantCircuitsList(false);
        }

        //when the ambient temp change refresh the refrigerant values
        private void numAmbientTemperature_ValueChanged(object sender, EventArgs e)
        {

            //refresh the circuits with the new ambient temp
            _backgroundCode.RecalculateCircuits(DtRefrigrantCircuit, numAmbientTemperature.Value);

            //refresh the listview
            Fill_RefrigerantCircuitsList(false);

            UpdateAmbientTempMaxValue();

        }

        //Set lblTotalCircuitsLabel
        private void Set_lblTotalCircuitsValue(int intTotalNumberOfCircuits)
        {
            lblTotalCircuitsValue.Text = intTotalNumberOfCircuits.ToString(CultureInfo.InvariantCulture);
        }

        //Clear lblTotalCircuitsLabel
        private void Clear_lblTotalCircuitsValue()
        {
            lblTotalCircuitsValue.Text = "";
        }

        //this function check if we can get a condenser list fro mthe refrigerant circuits
        //selected
        private void CheckToFillCondenserList(bool bolSelectingByClickingCondenser)
        {
            ThreadProcess.Start(Public.LanguageString("Running Selection", "Sélection en cours"));
            //if we have circuits, get the condensers and fill the list
            if (lvCircuits.Items.Count > 0)
            {
                //fill the condenser list
                GetCondenserModelList(bolSelectingByClickingCondenser);
            }
            else
            {
                lvCondenser.Items.Clear();
                lvCondenser.Refresh();
            }
            ThreadProcess.Stop();
            Focus();
        }

        private void numAltitude_ValueChanged(object sender, EventArgs e)
        {
            CheckToFillCondenserList(false);
        }

        private void cboTypeOfCondenser_SelectedIndexChanged(object sender, EventArgs e)
        {

            Fill_AirFlowType();

            CheckToFillCondenserList(false);

            ValidateCapacityType();

            Fill_CondenserSerie();
        }

        private void ValidateCapacityType()
        {

            //if heat reclaim is selected we can choose how much
            //heat recovery the unit will do in percentage
            if (cboTypeOfCondenser.Text == @"HEAT RECLAIM")
            {
                lblTotalHeatRecovery.Enabled = true;
                numTotalHeatRecovery.Enabled = true;
            }
            else
            {
                lblTotalHeatRecovery.Enabled = false;
                numTotalHeatRecovery.Enabled = false;
            }
        }

        private void cboFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckToFillCondenserList(false);
        }

        private void cboFanArrangement_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckToFillCondenserList(false);
        }

        private void cboCondenserSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_Voltage_Filter(CondenserSerie());

            CheckToFillCondenserList(false);
        }

        private void cboAirFlowType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckToFillCondenserList(false);
        }

       

        private bool AdvancedConfiguration_ControlPanel()
        {
            bool bolSelectionIsComplete;

            //GlacialComponents.Controls.GLItem MyItem = ((GlacialComponents.Controls.GLItem)((ArrayList)lvCondenser.SelectedItems)[0]);

            //extract the row id of the listview
            const int intRow = 0; //Convert.ToInt32(MyItem.SubItems[0].Text);

            var circuitCapacity = new List<decimal>();
            var circuitCondensing = new List<decimal>();
            var circuitRefrigerant = new List<string>();

            for (int i = 0; i < DtRefrigrantCircuit.Rows.Count; i++)
            {
                circuitCapacity.Add(Convert.ToDecimal(DtRefrigrantCircuit.Rows[i]["THR"]));
                circuitCondensing.Add(Convert.ToDecimal(DtRefrigrantCircuit.Rows[i]["CondenserTemperature"]));
                circuitRefrigerant.Add(DtRefrigrantCircuit.Rows[i]["RefrigerantType"].ToString());
            }

            ThreadProcess.Start(Public.LanguageString("Preparing Control Panel Selection", "Préparation de la sélection du panneau de contrôle"));
            //open the control panel
            var controlpanel = new QuickControlPanel.FrmQuickControlPanel(
                _dtCondenserResult.Rows[intRow]["Motor"].ToString(),
                _dtCondenserResult.Rows[intRow]["CoilArr"].ToString(),
                _dtCondenserResult.Rows[intRow]["FinType"].ToString(),
                QuickControlPanel.FrmQuickControlPanel.CoolerType.Condenser,
                circuitCapacity,
                Convert.ToInt32(_dtCondenserResult.Rows[intRow]["FanWide"]),
                Convert.ToInt32(_dtCondenserResult.Rows[intRow]["FanLong"]),
                Convert.ToInt32(_dtCondenserResult.Rows[intRow]["VoltageID"]),
                0m,
                0m,
                circuitCondensing,
                circuitRefrigerant,
                Convert.ToInt32(Convert.ToDecimal(_dtCondenserResult.Rows[intRow]["FinHeight"]) / (_dtCondenserResult.Rows[intRow]["FinType"].ToString() == "F" ? 1.5m : 1.25m)),
                Convert.ToInt32(_dtCondenserResult.Rows[intRow]["Row"]),
                Convert.ToDecimal(_dtCondenserResult.Rows[intRow]["FinLength"]),
                _dtCondenserResult.Rows[intRow]["AirFlowType"].ToString());

            if (controlpanel.ShowDialog() == DialogResult.OK)
            {
                _dtControlPanelInputs = controlpanel.ControlPanelInputs;
                _dtReceiverInputs = controlpanel.ReceiverInputs;

                bolSelectionIsComplete = true;
            }
            else
            {
                _dtControlPanelInputs.Clear();
                _dtReceiverInputs.Clear();
                bolSelectionIsComplete = false;
            }
            controlpanel.Dispose();

            return bolSelectionIsComplete;
        }

        private bool IsBaseInstalled()
        {

            if (_dtReceiverInputs.Rows.Count > 0)
            {
                if (Convert.ToInt32(_dtReceiverInputs.Rows[0]["ReceiverReinforcedBaseQty"]) >= 1)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsFactoryInstalledReceiverPresent()
        {
            //this function is only to be used from AdvancedConfiguration_CoatingMaterialEtc because
            //of the order of execution. highly dependend on the value saved in the receiver

            bool factoryInstlReceiverPresent = false;

            if (_dtReceiverInputs.Rows.Count > 0)
            {
                if (_dtReceiverInputs.Rows[0]["ReceiverInstall"].ToString().Contains("INSTALLED"))
                {
                    factoryInstlReceiverPresent = true;
                }
            }

            return factoryInstlReceiverPresent;
        }

        private int GetQuantityOfReceivers()
        {
            int quantityOfReceiver = 0;

            if (_dtReceiverInputs.Rows.Count > 0)
            {
                if (_dtReceiverInputs.Rows[0]["Receiver1Model"].ToString() != "" && _dtReceiverInputs.Rows[0]["Receiver1Model"] != null)
                {
                    ++quantityOfReceiver;
                }

                if (_dtReceiverInputs.Rows[0]["Receiver2Model"].ToString() != "" && _dtReceiverInputs.Rows[0]["Receiver2Model"] != null)
                {
                    ++quantityOfReceiver;
                }
            }

            return quantityOfReceiver;
        }

        private decimal GetBiggestReceiverDiameter()
        {
            decimal biggestDiameter = 0m;

            //I know that if it's shipped loose there is receiver and they have diameter but in this case
            //it's use for leg logic and the diameter is actually ONLY used if it Factory Installed, nothing else
            //so this is the reason why i check only for this one.
            if (IsFactoryInstalledReceiverPresent())
            {
                biggestDiameter = Math.Max(Convert.ToDecimal(_dtReceiverInputs.Rows[0]["Receiver1Diameter"]), Convert.ToDecimal(_dtReceiverInputs.Rows[0]["Receiver2Diameter"]));
            }

            return biggestDiameter;
        }

        private bool IsShippedLooseReceiverPresent()
        {
            //this function is only to be used from AdvancedConfiguration_CoatingMaterialEtc because
            //of the order of execution. highly dependend on the value saved in the receiver

            bool shippedLooseReceiverPresent = false;

            if (_dtReceiverInputs.Rows.Count > 0)
            {
                if (_dtReceiverInputs.Rows[0]["ReceiverInstall"].ToString().Contains("SHIPPED"))
                {
                    shippedLooseReceiverPresent = true;
                }
            }

            return shippedLooseReceiverPresent;
        }



        private bool AdvancedConfiguration_CoatingMaterialEtc()
        {

            //extract the row id of the listview
            const int intRow = 0; //Convert.ToInt32(MyItem.SubItems[0].Text);
            ThreadProcess.Start(Public.LanguageString("Preparing Secondary Options Selection", "Préparation de la sélection des options secondaires"));

            var secondaryOptions = new FluidCoolerCondenserOptions.FrmFluidCoolerCondenserOptions(
                FluidCoolerCondenserOptions.FrmFluidCoolerCondenserOptions.OpenFrom.Condenser,
                _dtCondenserResult.Rows[intRow]["Motor"].ToString(),
                _dtCondenserResult.Rows[intRow]["AirFlowType"].ToString(),
                _dtCondenserResult.Rows[intRow]["FinType"].ToString(),
                Convert.ToDecimal(_dtCondenserResult.Rows[intRow]["FPI"]),
                Convert.ToDecimal(_dtCondenserResult.Rows[intRow]["Row"]),
                Convert.ToDecimal(_dtCondenserResult.Rows[intRow]["FinHeight"]),
                Convert.ToDecimal(_dtCondenserResult.Rows[intRow]["FinLength"]),
                Convert.ToInt32(_dtCondenserResult.Rows[intRow]["FanWide"]),
                Convert.ToInt32(_dtCondenserResult.Rows[intRow]["FanLong"]),
                _dtCondenserResult.Rows[intRow]["CoilArr"].ToString(),
                IsFactoryInstalledReceiverPresent(),
                IsShippedLooseReceiverPresent(),
                _dtCondenserResult.Rows[intRow]["CondenserType"].ToString(),
                GetBiggestReceiverDiameter(),
                _bolQuoteSelection);

            if (secondaryOptions.ShowDialog() == DialogResult.OK)
            {
                _dtSecondaryOptionsInputs = secondaryOptions.SecondaryOptionsInput;
                _legNomenclature = secondaryOptions.GetLegNomenclature();
                secondaryOptions.Dispose();
                return true;
            }
            secondaryOptions.Dispose();
            _dtSecondaryOptionsInputs.Clear();
            return false;
        }

        private decimal GetBiggestCircuitTD()
        {
            decimal biggestTD = 0m;

            for (int i = 0; i < DtRefrigrantCircuit.Rows.Count; i++)
            {
                biggestTD = Math.Max(Convert.ToDecimal(DtRefrigrantCircuit.Rows[i]["TD"]), biggestTD);
            }

            return biggestTD;
        }

        private bool IsTDBValid()
        {
            bool tdValid = true;

            if (TypeOfCondenserParameter() == "C")
            {
                if (GetBiggestCircuitTD() > 30m)
                {
                    tdValid = false;
                }
            }

            return tdValid;
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            //2012-02-16 : #2653 : this is done wrong. should be within the try catch
            //and after it has check a condenser is selected.
            try
            {
                //TMEPORARY REMOVED UNTIL SELECTION FIXED
                //only open if and item exist and is on rating mode
                if (lvCondenser.Items.Count > 0 && chkRating.Checked)
                 {
                    if (IsTDBValid())
                    {
                        if (AdvancedConfiguration_ControlPanel())
                        {
                            if (AdvancedConfiguration_CoatingMaterialEtc())
                             {
                                ThreadProcess.Start(Public.LanguageString("Preparing data", "Préparation des données"));
                                _dtCondenserInputs = SaveTable();
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
                                            _quoteform.DeleteFromQuoteCondenser(_intIndex);
                                            newIndexToPush = _intIndex;
                                            _quoteform.UpdateAdditionalItems(_intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.Condenser), newIndexToPush);
                                            //Quoteform.UpdateAdditionalItems(intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.Condenser), Quoteform.GetNextID("Condensers"));
                                            //Quoteform.DeleteFromQuoteAdditionalItems(intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.Condenser));
                                        }
                                        else
                                        {
                                            //since we actually always recreate the record
                                            // save as new is simple, all i have to do is copy the additionnal items
                                            //if reused the update function to instead duplicate record.
                                            newIndexToPush = _quoteform.GetNextID("Condensers");
                                            _quoteform.CopyAdditionalItems(_intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.Condenser), newIndexToPush);

                                        }

                                        ThreadProcess.Start(Public.LanguageString("Adding to quote", "Ajout à la soumission"));
                                    }
                                    else
                                    {
                                        newIndexToPush = _quoteform.GetNextID("Condensers");
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
                                    CondenserReport.GenerateDataReport(_dtCondenserInputs, DtRefrigrantCircuit, _dtControlPanelInputs, _dtReceiverInputs, _dtSecondaryOptionsInputs, true, 0, "");



                                    //CreateReport();
                                    ThreadProcess.Stop();
                                    Focus();
                                }
                            }
                        }
                    }
                    else
                    {
                        Public.LanguageBox("You must adjust your temperatures to have your TD below 30°F.", "Vous devez ajuster vos températures afin d'avoir votre TD en dessous de 30°F.");
                    }
                }
                else
                {
                    Public.LanguageBox("You must select a Condenser in rating mode before selecting further options", "Vous devez sélectionner un Condenseur en mode performance avant de configurer les options suivantes");
                }
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"frmQuickCondenser cmdAccept_Click");
                ThreadProcess.Stop();
                Focus();
            }
            finally
            {
                ThreadProcess.Stop();
                Focus();
            }
            //}
            //else
            //{
            //    Public.LanguageBox("You must adjust your temperatures to have your TD below 30°F.", "Vous devez ajuster votre température d'avoir votre TD dessous de 30°F.");
            //}
        }

        private void AddToQuote(int itemID)
        {
            _dtCondenserInputs.Rows[0]["ItemType"] = Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.Condenser);
            _dtCondenserInputs.Rows[0]["ItemID"] = itemID;
            _dsQuoteData.Tables["Condensers"].Rows.Add(_dtCondenserInputs.Rows[0].ItemArray);
            DataTable copy = _dsQuoteData.Tables["Condensers"].Copy();
            DataRow[] list = copy.Select("", "itemID");

            _dsQuoteData.Tables["Condensers"].Rows.Clear();
            foreach (DataRow row in list)
            {
                _dsQuoteData.Tables["Condensers"].Rows.Add(row["QuoteID"], row["QuoteRevision"], row["QuoteRevisionText"], row["ItemType"], row["ItemID"], row["Username"], row["Input_attachedTOCondensingUnit"], row["Input_CondensingUnitSystemName"], row["Input_CondensingUnitItemID"], row["Input_Tag"], row["Quantity"], row["Input_Rating"], row["Input_RatingModel"], row["Input_Altitude"], row["Input_AmbientTemperature"], row["Input_FanArrangement"], row["Input_AirFlowType"], row["Input_TypeOfCondenser"], row["Input_CondenserSerie"], row["Input_Voltage"], row["Input_TotalHeatRecovery"], row["Input_FinsPerInch"], row["CondenserType"], row["Motor"], row["CoilArr"], row["FanWide"], row["FanLong"], row["Row"], row["FPI"], row["FinType"], row["FinHeight"], row["FinLength"], row["CondenserCircQty"], row["Capacity_per_Circuit"], row["THR_at_1F"], row["ConnDischarge"], row["ConnLiquid"], row["ConnQty"], row["RefChargeSummer"], row["RefChargeWinter"], row["ShipWeight"], row["CondenserPrice"], row["Active"], row["CondenserSelectionType"], row["CondenserModel"], row["ApprovalDrawing"], row["VoltageID"], row["VoltageDescription"], row["AirFlowType"], row["TotalHeatRecoveryPercentage"], row["Altitude"], row["MotorFLA"], row["MotorHP"], row["MotorRPM"], row["MotorID"], row["MotorHPNumber"], row["MotorRPMNumber"], row["MotorRotType"], row["MotorFrameType"], row["MotorShaftLength"], row["MotorMount"], row["MotorMountFanSize"], row["MotorMountFrameSize"], row["MotorMountComposition"], row["Fan"], row["FanDiameter"], row["FanBladeQuantity"], row["FanRotationType"], row["FanComposition"], row["FanPitch"], row["FanGuard"], row["FanGuardFanSize"], row["FanGuardComposition"], row["CoilModel"], row["MCA"], row["MOP"], row["FUSE"], row["RatioTD"], row["TargetCapacity"], row["CurrentCapacity"], row["Target_TD_Per_Condenser"], row["TDDifference"], row["Target_Ambient"], row["Final_Ambient"], row["Final_CapacityPerTD"], row["Final_Capacity"], row["Final_Circuit"], row["Final_CircuitCondenserTHRPerTDDifference"], row["Final_AmbientTD"]);
            }

            foreach (DataRow drControlPanel in _dtControlPanelInputs.Rows)
            {
                drControlPanel["ItemType"] = _dtCondenserInputs.Rows[0]["ItemType"];
                drControlPanel["ItemID"] = itemID;
                _dsQuoteData.Tables["ControlPanelInputs"].Rows.Add(drControlPanel.ItemArray);
            }

            foreach (DataRow drReceiver in _dtReceiverInputs.Rows)
            {
                drReceiver["ItemType"] = _dtCondenserInputs.Rows[0]["ItemType"];
                drReceiver["ItemID"] = itemID;
                _dsQuoteData.Tables["ReceiverInputs"].Rows.Add(drReceiver.ItemArray);
            }

            foreach (DataRow drRefrigerant in DtRefrigrantCircuit.Rows)
            {
                drRefrigerant["ItemType"] = _dtCondenserInputs.Rows[0]["ItemType"];
                drRefrigerant["ItemID"] = itemID;
                _dsQuoteData.Tables["RefrigerantCircuits"].Rows.Add(drRefrigerant.ItemArray);
            }

            _dtSecondaryOptionsInputs.Rows[0]["ItemType"] = _dtCondenserInputs.Rows[0]["ItemType"];
            _dtSecondaryOptionsInputs.Rows[0]["ItemID"] = itemID;
            _dsQuoteData.Tables["SecondaryOptions"].Rows.Add(_dtSecondaryOptionsInputs.Rows[0].ItemArray);

        }

        
        //auto-select content of numerical up and down on tab
        private void AutoSelectOnTab(object sender, EventArgs e)
        {
            //numerical up and down do not select text by default when we tab
            //or clik in the control. This code make him do it
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
        }

        private void cboFPI_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckToFillCondenserList(false);
        }

        //this return the saved data
        private DataTable SaveTable()
        {
            //create the table
            DataTable dtSaveTable = Tables.DtCondenser();

            //create a new row
            DataRow drSaveTable = dtSaveTable.NewRow();

            //header
            drSaveTable["QuoteID"] = 0;
            drSaveTable["QuoteRevision"] = 0;
            drSaveTable["QuoteRevisionText"] = "";
            drSaveTable["ItemType"] = 0;
            drSaveTable["ItemID"] = 0;
            drSaveTable["Username"] = "";

            //inputs
            drSaveTable["Input_AttachedToCondensingUnit"] = (chkAttachToCondensingUnit.Checked ? 1 : 0);
            drSaveTable["Input_CondensingUnitSystemName"] = cboCondensingUnit.Text;
            drSaveTable["Input_CondensingUnitItemID"] = 0;//TO DE ADDED ONCE CU IS DONE
            drSaveTable["Input_Tag"] = txtTag.Text;
            drSaveTable["Quantity"] = Convert.ToInt32(numQuantity.Value);
            drSaveTable["Input_Rating"] = (chkRating.Checked ? 1 : 0);
            drSaveTable["Input_RatingModel"] = cboModel.Text;
            drSaveTable["Input_Altitude"] = numAltitude.Value;
            drSaveTable["Input_AmbientTemperature"] = numAmbientTemperature.Value;
            drSaveTable["Input_FanArrangement"] = cboFanArrangement.Text;
            drSaveTable["Input_AirFlowType"] = cboAirFlowType.Text;
            drSaveTable["Input_TypeOfCondenser"] = cboTypeOfCondenser.Text;
            drSaveTable["Input_CondenserSerie"] = cboCondenserSerie.Text;
            drSaveTable["Input_Voltage"] = cboVoltage.Text;
            drSaveTable["Input_TotalHeatRecovery"] = numTotalHeatRecovery.Value;
            drSaveTable["Input_FinsPerInch"] = cboFPI.Text;

            foreach (DataColumn dc in _dtCondenserResult.Columns)
            {
                drSaveTable[dc.ColumnName] = _dtCondenserResult.Rows[0][dc.ColumnName];
            }

            //2010-09-23 : Database Note. according to a sheet Refplus gave us
            //the motor "N" is the only motor to have different FLA depending on the
            //voltage being 208/3/60 or 230/3/60. all the other one have the same
            //since it always been combined in 1 voltage and they only have 1 voltage id
            //for both we used the biggest FLA as the value in the database

            const int intRow = 0; // Convert.ToInt32(MyItem.SubItems[0].Text);

            //2011-05-12
            drSaveTable["ApprovalDrawing"] = GetApprovalDrawing(
                 _dtCondenserResult.Rows[intRow]["Motor"].ToString(),
                 _dtCondenserResult.Rows[intRow]["CoilArr"].ToString(),
                 _dtCondenserResult.Rows[intRow]["CondenserType"].ToString(),
                 _dtCondenserResult.Rows[intRow]["FanWide"].ToString(),
                 _dtCondenserResult.Rows[intRow]["FanLong"].ToString(),
                 IsBaseInstalled(),
                 _dtCondenserResult.Rows[intRow]["AirFlowType"].ToString(),
                 IsFactoryInstalledReceiverPresent(),
                 GetQuantityOfReceivers(),
                 _legNomenclature);

            DataRow[] drMotorFLA = Public.DSDatabase.Tables["MotorFLA"].Select("Motor = '" + _dtCondenserResult.Rows[intRow]["Motor"] + "' AND CoilArr = '" + _dtCondenserResult.Rows[intRow]["CoilArr"] + "' AND VoltageID = " + _dtCondenserResult.Rows[intRow]["VoltageID"]);
            if (drMotorFLA.Length > 0)
            {
                drSaveTable["MotorFLA"] = Convert.ToDecimal(drMotorFLA[0]["FLA"]);
            }
            else
            {
                drSaveTable["MotorFLA"] = 0m;
            }

            DataRow[] drMotorHPRpm = Public.DSDatabase.Tables["CondenserSerie"].Select("Motor = '" + _dtCondenserResult.Rows[intRow]["Motor"] + "' AND CoilArr = '" + _dtCondenserResult.Rows[intRow]["CoilArr"] + "'");
            if (drMotorHPRpm.Length > 0)
            {
                drSaveTable["MotorHP"] = drMotorHPRpm[0]["HP"].ToString();
                drSaveTable["MotorRPM"] = drMotorHPRpm[0]["RPM"].ToString();
            }
            else
            {
                drSaveTable["MotorHP"] = "";
                drSaveTable["MotorRPM"] = "";
            }

            drSaveTable["MotorID"] = "";
            drSaveTable["MotorHPNumber"] = 0m;
            drSaveTable["MotorRPMNumber"] = 0m;
            drSaveTable["MotorRotType"] = "";
            drSaveTable["MotorFrameType"] = "";
            drSaveTable["MotorShaftLength"] = 0m;
            drSaveTable["MotorMount"] = "";
            drSaveTable["MotorMountFanSize"] = 0m;
            drSaveTable["MotorMountFrameSize"] = 0m;
            drSaveTable["MotorMountComposition"] = "";
            drSaveTable["Fan"] = "";
            drSaveTable["FanDiameter"] = 0m;
            drSaveTable["FanBladeQuantity"] = 0;
            drSaveTable["FanRotationType"] = "";
            drSaveTable["FanComposition"] = "";
            drSaveTable["FanPitch"] = 0m;
            drSaveTable["FanGuard"] = "";
            drSaveTable["FanGuardFanSize"] = 0m;
            drSaveTable["FanGuardComposition"] = "";
            drSaveTable["MCA"] = 0m;
            drSaveTable["MOP"] = 0m;
            drSaveTable["FUSE"] = 0m;



            string motorModel = GetMotorModel(drSaveTable["Motor"].ToString(), drSaveTable["CoilArr"].ToString(), Convert.ToInt32(drSaveTable["VoltageID"]));
            string motorMountModel = GetMotorMountModel(drSaveTable["Motor"].ToString(), drSaveTable["CoilArr"].ToString(), Convert.ToInt32(drSaveTable["VoltageID"]));
            string fanModel = GetFanModel(drSaveTable["Motor"].ToString(), drSaveTable["CoilArr"].ToString(), Convert.ToInt32(drSaveTable["VoltageID"]));
            string fanGuardModel = GetFanGuardModel(drSaveTable["Motor"].ToString(), drSaveTable["CoilArr"].ToString(), Convert.ToInt32(drSaveTable["VoltageID"]));

            if (motorModel != "")
            {
                DataTable dtMotor = Public.SelectAndSortTable(Public.DSDatabase.Tables["MotorModel"], "MotorID = '" + motorModel + "'", "");

                if (dtMotor.Rows.Count > 0)
                {
                    drSaveTable["MotorID"] = motorModel;
                    drSaveTable["MotorHPNumber"] = Convert.ToDecimal(dtMotor.Rows[0]["HP"]);
                    drSaveTable["MotorRPMNumber"] = Convert.ToDecimal(dtMotor.Rows[0]["RPM"]);
                    drSaveTable["MotorRotType"] = dtMotor.Rows[0]["RotType"].ToString();
                    drSaveTable["MotorFrameType"] = dtMotor.Rows[0]["FrameType"].ToString();
                    drSaveTable["MotorShaftLength"] = Convert.ToDecimal(dtMotor.Rows[0]["ShaftLength"]);
                }
            }

            if (motorMountModel != "")
            {
                DataTable dtMotorMount = Public.SelectAndSortTable(Public.DSDatabase.Tables["MotorMountModel"], "MotorMountID = '" + motorMountModel + "'", "");

                if (dtMotorMount.Rows.Count > 0)
                {
                    drSaveTable["MotorMount"] = motorMountModel;
                    drSaveTable["MotorMountFanSize"] = Convert.ToDecimal(dtMotorMount.Rows[0]["FanSize"]);
                    drSaveTable["MotorMountFrameSize"] = Convert.ToDecimal(dtMotorMount.Rows[0]["FrameSize"]);
                    drSaveTable["MotorMountComposition"] = dtMotorMount.Rows[0]["Composition"].ToString();
                }
            }

            if (fanModel != "")
            {
                DataTable dtFan = Public.SelectAndSortTable(Public.DSDatabase.Tables["FanModel"], "FanID = '" + fanModel + "'", "");

                if (dtFan.Rows.Count > 0)
                {
                    drSaveTable["Fan"] = fanModel;
                    drSaveTable["FanDiameter"] = Convert.ToDecimal(dtFan.Rows[0]["Diameter"]);
                    drSaveTable["FanBladeQuantity"] = Convert.ToInt32(dtFan.Rows[0]["BladeQuantity"]);
                    drSaveTable["FanRotationType"] = dtFan.Rows[0]["RotationType"].ToString();
                    drSaveTable["FanComposition"] = dtFan.Rows[0]["Composition"].ToString();
                    drSaveTable["FanPitch"] = Convert.ToDecimal(dtFan.Rows[0]["Pitch"]);
                }
            }

            if (fanGuardModel != "")
            {
                DataTable dtFanGuard = Public.SelectAndSortTable(Public.DSDatabase.Tables["FanGuardModel"], "FanGuardID = '" + fanGuardModel + "'", "");

                if (dtFanGuard.Rows.Count > 0)
                {
                    drSaveTable["FanGuard"] = fanGuardModel;
                    drSaveTable["FanGuardFanSize"] = Convert.ToDecimal(dtFanGuard.Rows[0]["FanSize"]);
                    drSaveTable["FanGuardComposition"] = dtFanGuard.Rows[0]["Composition"].ToString();
                }
            }

            var qec = new QuickEvaporator.QuickEvaporatorCode();

            drSaveTable["MCA"] = qec.GetMotorMCA(Convert.ToInt32(drSaveTable["FanLong"]) * Convert.ToInt32(drSaveTable["FanWide"]), Convert.ToDecimal(drSaveTable["MotorFLA"]));
            drSaveTable["MOP"] = qec.GetMotorMOP(Convert.ToInt32(drSaveTable["FanLong"]) * Convert.ToInt32(drSaveTable["FanWide"]), Convert.ToDecimal(drSaveTable["MotorFLA"]));
            drSaveTable["FUSE"] = qec.GetMotorFuseSize(Public.DSDatabase.Tables["FuseSize"], Convert.ToDecimal(drSaveTable["MCA"]), Convert.ToDecimal(drSaveTable["MOP"]));


            //add the row to the table
            dtSaveTable.Rows.Add(drSaveTable);

            return dtSaveTable;
        }

        private static string GetMotorModel(string motor, string coilArr, int voltageID)
        {
            string strModel = "";

            DataTable dtModel = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondenserMotor"], "Motor = '" + motor + "' AND CoilArr = '" + coilArr + "' AND VoltageID = " + voltageID, "");

            if (dtModel.Rows.Count > 0)
            {
                strModel = dtModel.Rows[0]["MotorID"].ToString();
            }

            return strModel;
        }

        private static string GetMotorMountModel(string motor, string coilArr, int voltageID)
        {
            string strModel = "";

            DataTable dtModel = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondenserMotorMount"], "Motor = '" + motor + "' AND CoilArr = '" + coilArr + "' AND VoltageID = " + voltageID, "");

            if (dtModel.Rows.Count > 0)
            {
                strModel = dtModel.Rows[0]["MotorMountID"].ToString();
            }

            return strModel;
        }

        private static string GetFanModel(string motor, string coilArr, int voltageID)
        {
            string strModel = "";

            DataTable dtModel = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondenserFan"], "Motor = '" + motor + "' AND CoilArr = '" + coilArr + "' AND VoltageID = " + voltageID, "");

            if (dtModel.Rows.Count > 0)
            {
                strModel = dtModel.Rows[0]["FanID"].ToString();
            }

            return strModel;
        }

        private static string GetFanGuardModel(string motor, string coilArr, int voltageID)
        {
            string strModel = "";

            DataTable dtModel = Public.SelectAndSortTable(Public.DSDatabase.Tables["CondenserFanGuard"], "Motor = '" + motor + "' AND CoilArr = '" + coilArr + "' AND VoltageID = " + voltageID, "");

            if (dtModel.Rows.Count > 0)
            {
                strModel = dtModel.Rows[0]["FanGuardID"].ToString();
            }

            return strModel;
        }

        private void cmdRateButton_Click(object sender, EventArgs e)
        {
            if (chkRating.Checked)
            {
                chkRating.Checked = false;
            }
            else
            {
                //2012-03-01 : #2664 : Voltage should always stay the same
                string defaultVoltage = ComboBoxControl.IndexInformation(cboVoltage);

                string strTag = ((Button)sender).Tag.ToString();
                string strModelName = _dtCondenserResult.Rows[Convert.ToInt32(strTag)]["CondenserModel"].ToString();

                _blockRatingChkToTriggerSelection = true;
                chkRating.Checked = true;
                _blockRatingChkToTriggerSelection = false;

                if (cboModel.FindString(strModelName) >= 0)
                {
                    cboModel.SelectedIndex = -1;
                    cboModel.SelectedIndex = cboModel.FindString(strModelName);
                }

                //2012-03-01 : #2664 : Voltage should always stay the same
                ComboBoxControl.SetIDDefaultValueIfExistOnly(cboVoltage, defaultVoltage);
            }
        }

        private Button RateButtonInList(string strTag, Color myColor)
        {
            var myButton = new Button();
            if (chkRating.Checked)
            {
                myButton.Text = Public.Language == Tools.LanguageType.English ? "Cancel selection" : "Désélectionner";
            }
            else
            {
                myButton.Text = Public.Language == Tools.LanguageType.English ? "Select this condenser" : "Sélectionner";
            }
            myButton.Tag = strTag;
            myButton.Width = 110;
            myButton.Height = 25;
            myButton.AutoSize = false;
            myButton.BackColor = myColor;
            myButton.Click += cmdRateButton_Click;
            return myButton;
        }

        private void DisplayInfoOfIndex(int intIndex)
        {
            if (lvCondenser.Items.Count > 0 && lvCircuits.Items.Count > 0 && intIndex != -1)
            {
                //GlacialComponents.Controls.GLItem MyItem = ((GlacialComponents.Controls.GLItem)((ArrayList)lvCondenser.SelectedItems)[0]);

                //extract the row id of the listview
                int intRow = intIndex;

                ////select the condenser type label
                //SelectCondenserType(Convert.ToInt32(dtCondenserResult.Rows[intRow]["CondenserSelectionType"]));

                //clear circuits and refill
                lvCircuits.Items.Clear();

                //running to total for number of circuits
                int intCircuitQuantityTotal = 0;

                //total the thr/td
                decimal decTotalCapacityPerTD = 0;

                //for each circuits
                for (int intRefrigerantCircuits = 0; intRefrigerantCircuits < DtRefrigrantCircuit.Rows.Count; intRefrigerantCircuits++)
                {
                    //quantity of circuits for this refrigerant

                    decimal decCircuitCalculated = _backgroundCode.Circuit_Formula_1(Convert.ToDecimal(DtRefrigrantCircuit.Rows[intRefrigerantCircuits]["THR_PER_TD"]), Convert.ToDecimal(_dtCondenserResult.Rows[intRow]["Capacity_per_circuit"]), Convert.ToDecimal(DtRefrigrantCircuit.Rows[intRefrigerantCircuits]["RefrigerantMultiplier"]), Convert.ToDecimal(DtRefrigrantCircuit.Rows[intRefrigerantCircuits]["AltitudeAdjustment"]), Convert.ToDecimal(DtRefrigrantCircuit.Rows[intRefrigerantCircuits]["HertzAdjustment"]));
                    int intCircuitQuantity = _backgroundCode.GetCircuitAmount(decCircuitCalculated);

                    //save the circuit quantity in the datatable
                    DtRefrigrantCircuit.Rows[intRefrigerantCircuits]["Circ_Quantity"] = intCircuitQuantity;

                    //get the calculated
                    DtRefrigrantCircuit.Rows[intRefrigerantCircuits]["Calculated"] = decCircuitCalculated;

                    //running total
                    intCircuitQuantityTotal = intCircuitQuantityTotal + intCircuitQuantity;

                    //running total of capacity
                    decTotalCapacityPerTD = decTotalCapacityPerTD + Convert.ToDecimal(DtRefrigrantCircuit.Rows[intRefrigerantCircuits]["THR_PER_TD"]);

                    decimal decShowedCapacityPerCircuit = Convert.ToDecimal(_dtCondenserResult.Rows[intRow]["Capacity_per_Circuit"]) * Convert.ToDecimal(DtRefrigrantCircuit.Rows[intRefrigerantCircuits]["RefrigerantMultiplier"]) * Convert.ToDecimal(DtRefrigrantCircuit.Rows[intRefrigerantCircuits]["AltitudeAdjustment"]) * Convert.ToDecimal(DtRefrigrantCircuit.Rows[intRefrigerantCircuits]["HertzAdjustment"]);

                    lvCircuits.Items.Add(new ListViewItem(new[] { intRefrigerantCircuits.ToString(CultureInfo.InvariantCulture), DtRefrigrantCircuit.Rows[intRefrigerantCircuits]["RefrigerantType"].ToString(), DtRefrigrantCircuit.Rows[intRefrigerantCircuits]["CondenserTemperature"].ToString(), DtRefrigrantCircuit.Rows[intRefrigerantCircuits]["THR"].ToString(), DtRefrigrantCircuit.Rows[intRefrigerantCircuits]["TD"].ToString(), Convert.ToDecimal(Math.Round(Convert.ToDecimal(DtRefrigrantCircuit.Rows[intRefrigerantCircuits]["THR_PER_TD"]) / 1000m, 2)).ToString(CultureInfo.InvariantCulture), Convert.ToDecimal(Math.Floor(decShowedCapacityPerCircuit)).ToString(CultureInfo.InvariantCulture), DtRefrigrantCircuit.Rows[intRefrigerantCircuits]["Calculated"].ToString(), intCircuitQuantity.ToString(CultureInfo.InvariantCulture), intCircuitQuantityTotal.ToString(CultureInfo.InvariantCulture) }));
                }

                //fill the total thr/td label
                Set_lblTotalCapacityValue(decTotalCapacityPerTD);

                //fill the total number of circuits
                Set_lblTotalCircuitsValue(intCircuitQuantityTotal);

            }
            else
            {

                //clear the total thr/td label
                Clear_lblTotalCapacityValue();

                //clear lblTotalCircuitsLabel
                Clear_lblTotalCircuitsValue();

                //if we have refrigerant circutis, fill the list
                if (lvCircuits.Items.Count > 0)
                {
                    //refill the refrigerant
                    Fill_RefrigerantCircuitsList(true);
                }
            }
        }

        private void chkRating_CheckedChanged(object sender, EventArgs e)
        {
            cboModel.Enabled = chkRating.Checked;
            cboFanArrangement.Enabled = !chkRating.Checked;
            cboAirFlowType.Enabled = !chkRating.Checked;
            cboTypeOfCondenser.Enabled = !chkRating.Checked;
            cboCondenserSerie.Enabled = !chkRating.Checked;
            cboFPI.Enabled = !chkRating.Checked;

            ManageRatingModeModel();

            if (chkRating.Checked)
            {
                string ratingModel = RatingModelParameter();
                Fill_Voltage_Filter(ratingModel.Split(',')[1] + ratingModel.Split(',')[2]);
            }
            else
            {
                Fill_Voltage_Filter(CondenserSerie());
            }

            if (!_blockRatingChkToTriggerSelection)
            {
                //refresh the listview
                Fill_RefrigerantCircuitsList(false);
            }
        }

        private void cboModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModel.SelectedIndex >= 0)
            {
                string ratingParams = RatingModelParameter();

                //2012-02-10 : #2642 : Mike didnt test this code below he added. it crashes
                //ratingparams can be = "ALL" which contain no comma for spliut. therfore crashes
                //string MotorCoilArr = RatingParams.Split(',')[1] + RatingParams.Split(',')[2];

                if (ratingParams != "ALL")
                {
                    //2011-02-21 : added for heat reclaim
                    cboTypeOfCondenser.SelectedIndex = cboTypeOfCondenser.FindString(ratingParams.Split(',')[0] == "C" ? "AIR COOLED" : "HEAT RECLAIM");

                    cboAirFlowType.SelectedIndex = cboAirFlowType.FindString(ratingParams.Split(',')[7] == "H" ? "HORIZONTAL" : "VERTICAL");

                    //2012-02-10 : #2642 : this is where is code should be
                    string motorCoilArr = ratingParams.Split(',')[1] + ratingParams.Split(',')[2];

                    Fill_Voltage_Filter(motorCoilArr);
                }

                //refresh the listview
                Fill_RefrigerantCircuitsList(false);
            }
        }

        private void ManageRatingModeModel()
        {
            if (chkRating.Checked)
            {
                string[] strRatingModelSplit = ComboBoxControl.IndexInformation(cboModel).Split(Convert.ToChar(","));
                cboTypeOfCondenser.SelectedIndex = strRatingModelSplit[0] == "C" ? 0 : 1;
            }
        }

        private Button GetAdjustAmbientButton(string strTag, Color myColor, string strTextValue)
        {
            var myButton = new Button
            {
                Tag = strTag,
                Text = strTextValue,
                Width = 80,
                Height = 25,
                AutoSize = false,
                BackColor = myColor
            };
            myButton.Click += cmdAdjustAmbient_Click;
            return myButton;
        }

        private void cmdAdjustAmbient_Click(object sender, EventArgs e)
        {
            string strTag = ((Button)sender).Tag.ToString();
            decimal decAjustedAmbientTemp = Convert.ToDecimal(_dtCondenserResult.Rows[Convert.ToInt32(strTag)]["Final_Ambient"]);
            if (decAjustedAmbientTemp > numAmbientTemperature.Maximum || decAjustedAmbientTemp < numAmbientTemperature.Minimum)
            {
                Public.LanguageBox("This ambient temperature is outside allowed range", "Cette température ambiante est hors de la limite permise");
            }
            else
            {
                numAmbientTemperature.Value = decAjustedAmbientTemp;
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmQuickCondenser_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }

       
        private void lvCircuits_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdEditCircuit_Click(object sender, EventArgs e)
        {
            if (lvCircuits.SelectedItems.Count > 0)
            {
                var frmCirc = new FrmCircuitEdit(this, TypeOfCondenserParameter(), Convert.ToInt32(lvCircuits.SelectedItems[0].SubItems[0].Text), numAmbientTemperature.Value);
                frmCirc.ShowDialog();
            }
            else
            {
                Public.LanguageBox("You must select a circuit to edit first", "Vous devez d'abord sélectionner un circuit à modifier");
            }
        }

        public static string GetApprovalDrawing(string motor, string coilArr, string condenserType, string fanWide, string fanLong, bool baseInstalled, string airFlow, bool installedReceiver, int quantityOfReceiver, string legs)
        {
            string strApprovalDrawing = "";

            //company
            strApprovalDrawing += "R";

            //Unit Size Type
            string unitSizeType = GetUnitSizeType(motor, coilArr);
            strApprovalDrawing += unitSizeType;

            //unit type
            strApprovalDrawing += condenserType;

            //split
            strApprovalDrawing += "-";

            //fan arrangement
            strApprovalDrawing += fanWide + fanLong;

            //2011-06-09 :as per simon email it should work as follow.
            //1 circuit if 1 fan wide non v shape
            //2 circuit if 2 fan wide non v shape
            //2 circuit if 1 fan wide V shape
            //4 circuit if 2 fan wide V shape
            int unitSizeTypeCircuitMultiplier = 1;

            if (unitSizeType == "X" || unitSizeType == "Z")
            {
                unitSizeTypeCircuitMultiplier = 2;
            }

            //2011-07-13 : change logic
            //number of circuit
            strApprovalDrawing += Convert.ToInt32(Convert.ToInt32(fanWide) * unitSizeTypeCircuitMultiplier).ToString(CultureInfo.InvariantCulture);
            

            //split
            strApprovalDrawing += "-";

            if ((condenserType == "C" && coilArr == "X") || (condenserType == "F" && coilArr == "V") &&  (motor == "L" ||motor == "N" || motor == "V") )
            {
                   strApprovalDrawing += "B";
            }
            else
            {
            //unit coil setup
                strApprovalDrawing += GetUnitCoilSetup(baseInstalled, airFlow);
            }

            //split
            strApprovalDrawing += "-";

            //leg
            strApprovalDrawing += legs;

            //split
            strApprovalDrawing += "-";

            //receiver kit
            strApprovalDrawing += GetReceiverKitNomenclature(installedReceiver, quantityOfReceiver);

            return strApprovalDrawing;
        }

        private static string GetReceiverKitNomenclature(bool installedReceiver, int quantityOfReceiver)
        {
            string receiverKit = installedReceiver ? quantityOfReceiver.ToString(CultureInfo.InvariantCulture) : "N";

            return receiverKit;
        }

        private static string GetUnitCoilSetup(bool baseInstalled, string airFlow)
        {
            string unitCoilSetup = "";

            if (baseInstalled && airFlow == "H")
            {
                unitCoilSetup = "D";
            }
            
            else if (baseInstalled && airFlow == "V")
            {
                unitCoilSetup = "B";
            }
            else if (!baseInstalled && airFlow == "H")
            {
                unitCoilSetup = "H";
            }
            else if (!baseInstalled && airFlow == "V")
            {
                unitCoilSetup = "N";
            }
            return unitCoilSetup;
        }

        private static string GetUnitSizeType(string motor, string coilArr)
        {
            string unitSizeType = "";

            DataTable dtCondenserSerie = Query.Select("Select * from CondenserSerie where Motor = '" + motor + "' AND CoilArr = '" + coilArr + "'");
            
            if (dtCondenserSerie.Rows.Count > 0)
            {
                unitSizeType = dtCondenserSerie.Rows[0]["UnitSizeTypeNomenclature"].ToString();
            }

            return unitSizeType;
        }
    }
}