using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using RefplusWebtools.QuickCondenser;

namespace RefplusWebtools.QuickControlPanel
{
    public partial class FrmQuickControlPanel : Form
    {
        //form need access to his background code
        private readonly ControlPanelCode _backgroundCode = new ControlPanelCode();

        //this Value is used to store the control panel nomenclature
        private string _strControlPanelNomenclature = "";

        //this Value is used to store the pump nomenclature
        private string _strPumpNomenclature = "";

        //this Value is used to store the Receiver nomenclature
        private string _strReceiverNomenclature = "";

        //this is the Coil arrangement that is passed as parameter to the form
        private readonly string _strCoilArr = "";

        //this is the motor type that is passed as parameter to the form
        private readonly string _strMotor = "";

        //this will containt the fin type. it's used for the condenser calculation of charge.
        private readonly string _strCoilFinType = "";

        private readonly int _intNumberOfFaceTubes;
        private readonly int _intNumberOfRows;
        private readonly decimal _decFinLength;

        //multiple option that are used to filter on the table
        private readonly CoolerType _ct = CoolerType.FluidCooler;
        private readonly List<decimal> _circuitCapacity = new List<decimal>();
        private readonly int _fanWide;
        private readonly int _fanLong;
        private readonly int _intVoltageID;
        readonly List<decimal> _circuitCondensing = new List<decimal>();
        readonly List<string> _circuitRefrigerant = new List<string>();
        private readonly string _airFlow = "";

        //variable use for pump package
        private readonly decimal _decLiquidPressureDropInFth2O;
        private readonly decimal _decGPM;

        private const decimal SightGlassPrice = 500m;
        private const decimal ReliefValvePrice = 170m;

        //variable for condenser only

        private bool _preventCircuitValueChangeCodeTrigger;
        
        //boolean to prevent the code to run in some place
        //private bool bolPreventCodeFromRunning = true;

        //boolean to prevent the code to run in some place for the pump
        private bool _bolPreventCodeFromRunningPump = true;

        //boolean that prevent the auto select change fo the receiver from trigering
        //private bool bolPreventAutoSelectChangeForReceiver = false;

        //private const decimal decLIQUID_LEVEL_INDICATOR_MINIMUM_DIAMETER_TO_HAVE_THE_OPTION = 8.625m;

        //create an instance of the control panel inputs for saving purpose
        private readonly DataTable _dtControlPanelInputs = Tables.DtControlPanelInputs();

        //create an instance of the control panel Receiver inputs for saving purpose
        private readonly DataTable _dtReceiverInputs = Tables.DtReceiverInputs();

        //create an instance of the control panel Pump inputs for saving purpose
        private readonly DataTable _dtPumpInputs = Tables.DtPumpInputs();

        public enum CoolerType { FluidCooler, Condenser };

        private List<CheckBox> _chkOptions = new List<CheckBox>();

        private bool _optionCheckChangedUnlock = true;

        public FrmQuickControlPanel(
            string strMotor, 
            string strCoilArr, 
            string strCoilFinType, 
            CoolerType ct,
            List<decimal> circuitCapacity, 
            int fanWide,
            int fanLong,
            int intVoltageID, 
            decimal decGPM, 
            decimal decLiquidPressureDropInPsi, 
            List<decimal> circuitCondensing, 
            List<string> circuitRefrigerant,
            int intNumberOfFaceTubes, 
            int intNumberOfRows, 
            decimal decFinLength,
            string airFlow)
        {
            InitializeComponent();

            _strMotor = strMotor;
            _strCoilArr = strCoilArr;
            _strCoilFinType = strCoilFinType;
            _ct = ct;
            _circuitCapacity = circuitCapacity;
            _fanWide = fanWide;
            _fanLong = fanLong;
            _intVoltageID = intVoltageID;
            _decGPM = decGPM;

            //transform into FTH2O
            _decLiquidPressureDropInFth2O = decLiquidPressureDropInPsi * 2.306666666666m;

            _circuitCondensing = circuitCondensing;
            _circuitRefrigerant = circuitRefrigerant;
            _intNumberOfFaceTubes = intNumberOfFaceTubes;
            _intNumberOfRows = intNumberOfRows;
            _decFinLength = decFinLength;
            _airFlow = airFlow;

        }

        public string ControlPanelNomenclature
        {
            get { return _strControlPanelNomenclature; }
        }

        public string PumpNomenclature
        {
            get { return _strPumpNomenclature; }
        }

        public string ReceiverNomenclature
        {
            get { return _strReceiverNomenclature; }
        }

        public DataTable ControlPanelInputs
        {
            get { return _dtControlPanelInputs; }
        }

        public DataTable ReceiverInputs
        {
            get { return _dtReceiverInputs; }
        }

        public DataTable PumpInputs
        {
            get { return _dtPumpInputs; }
        }

        //this build up the Pump nomenclature
        private void BuildPumpNomenclature()
        {
            _strPumpNomenclature = "";

            _strPumpNomenclature = _strPumpNomenclature + Pump();
            _strPumpNomenclature = _strPumpNomenclature + PumpNumberOfPump();

            DataTable dtPumpSelection = Public.SelectAndSortTable(Public.DSDatabase.Tables["PumpSelection"], "Pressure >=" + numPumpTotalFeetOfWater.Value + " AND GPM >= " + _decGPM, "Pressure ASC, GPM ASC");

            _strPumpNomenclature = _strPumpNomenclature + Public.DSDatabase.Tables["PumpHP"].Select("HP = " + dtPumpSelection.Rows[0]["HP"])[0]["Nomenclature"] + "-";
            
            _strPumpNomenclature = _strPumpNomenclature + _intVoltageID + "-";
            _strPumpNomenclature = _strPumpNomenclature + ControlVoltageParameter() + "-";
            _strPumpNomenclature = _strPumpNomenclature + dtPumpSelection.Rows[0]["Nomenclature"];
            _strPumpNomenclature = _strPumpNomenclature + "A";
            _strPumpNomenclature = _strPumpNomenclature + PumpExpansionTankKit();
            if (PumpExpansionTankKit() == "N")
            {
                _strPumpNomenclature = _strPumpNomenclature + "N";
            }
            else
            {
                _strPumpNomenclature = _strPumpNomenclature + PumpExpansionTankKitModel();
            }
            _strPumpNomenclature = _strPumpNomenclature + PumpValve();
            switch (PumpValve())
            {
                case "N":
                    _strPumpNomenclature = _strPumpNomenclature + "0";
                    break;
                case "2":
                case "4":
                    var vlPump2Way = new ValveList((float)_decGPM);
                    Valve vPump2Way = vlPump2Way.Get2WayHWValveSelection((float)_decGPM);
                    _strPumpNomenclature = _strPumpNomenclature + Convert.ToInt32(Math.Ceiling((decimal)vPump2Way.GetCvValue())).ToString(CultureInfo.InvariantCulture).PadLeft(2, Convert.ToChar("0"));
                    break;
                case "3":
                case "5":
                    var vlPump3Way = new ValveList((float)_decGPM);
                    Valve vPump3Way = vlPump3Way.Get3WayHWValveSelection((float)_decGPM);
                    _strPumpNomenclature = _strPumpNomenclature + Convert.ToInt32(Math.Ceiling((decimal)vPump3Way.GetCvValue())).ToString(CultureInfo.InvariantCulture).PadLeft(2, Convert.ToChar("0"));
                    break;
            }

            _strPumpNomenclature = _strPumpNomenclature + Public.SelectAndSortTable(Public.DSDatabase.Tables["PumpGPM"], "GPMMin <" + _decGPM + " AND GPMMax >= " + _decGPM, "GPMMin ASC").Rows[0]["Nomenclature"] + "-";

            _strPumpNomenclature = _strPumpNomenclature + PumpOptionsList();

        }

        private bool AreCircuitEqualCapacity()
        {
            bool equalCapacity = true;

            //this start at 1 since if 1 circuits i dont want to run because
            //circuit as considered even. so this run for 2 or more circuit
            for (int i = 1; i < _circuitCapacity.Count; i++)
            {
                if (_circuitCapacity[i] != _circuitCapacity[i - 1])
                {
                    equalCapacity = false;
                    i = _circuitCapacity.Count;
                }
            }

            return equalCapacity;
        }
       
        //this build up the Receiver nomenclature
        private void BuildReceiverNomenclature()
        {
            _strReceiverNomenclature = "";

            _strReceiverNomenclature = _strReceiverNomenclature + "PL";
            _strReceiverNomenclature = _strReceiverNomenclature + Receiver() + "-";
            //strReceiverNomenclature = strReceiverNomenclature + ComboBoxControl.IndexInformation(cboReceiverFirstReceiver) + ReceiverType() + "-";
            //strReceiverNomenclature = strReceiverNomenclature + ComboBoxControl.IndexInformation(cboReceiverSecondReceiver) + ReceiverType() + "-";
            
            //strReceiverNomenclature = strReceiverNomenclature + Tranformer1Nomenclature() + "-";
            //strReceiverNomenclature = strReceiverNomenclature + Tranformer2Nomenclature() + "-";
            _strReceiverNomenclature = _strReceiverNomenclature + ComboBoxControl.IndexInformation(cboReceiverFloodingValveKit1) + "-";
            _strReceiverNomenclature = _strReceiverNomenclature + ComboBoxControl.IndexInformation(cboReceiverFloodingValveKit2) + "-";
            //if (chkNone.Checked)
            //{
            //    strReceiverNomenclature = strReceiverNomenclature + "N";
            //}
            //else
            //{
            //    if (chkAluminiumBox.Checked)
            //    {
            //        strReceiverNomenclature = strReceiverNomenclature + "A";
            //    }
            //    if (chkBullseye.Checked)
            //    {
            //        strReceiverNomenclature = strReceiverNomenclature + "B";
            //    }
            //    if (chkDualReliefValve.Checked)
            //    {
            //        strReceiverNomenclature = strReceiverNomenclature + "R";
            //    }
            //    if (chkInsulation.Checked)
            //    {
            //        strReceiverNomenclature = strReceiverNomenclature + "S";
            //    }
            //    if (chkLiquidLevelIndicator.Checked)
            //    {
            //        strReceiverNomenclature = strReceiverNomenclature + "T";
            //    }
            //    if (chkLiquidLevelAlarm.Checked)
            //    {
            //        strReceiverNomenclature = strReceiverNomenclature + "U";
            //    }
            //}
        }

        //this build up the control panel nomenclature
        private void BuildControlPanelNomenclature()
        {
            //clean the control panel model
            _strControlPanelNomenclature = "";

            //add the motor
            _strControlPanelNomenclature = _strControlPanelNomenclature + _strMotor.Replace("S", "V");

            //panel
            //if fluid cooler and pump selected
            if (_ct == CoolerType.FluidCooler && Pump() != "NONE")
            {
                _strControlPanelNomenclature = _strControlPanelNomenclature + "PP";
            }
            else if (_ct== CoolerType.Condenser && Receiver() != "NONE")
            {//if condenser and receiver selected
                _strControlPanelNomenclature = _strControlPanelNomenclature + "PL";
            }
            else
            {//no pump or receiver selected
                _strControlPanelNomenclature = _strControlPanelNomenclature + "PC";
            }

            //Dash split
            _strControlPanelNomenclature = _strControlPanelNomenclature + "-";

            //control panel
            _strControlPanelNomenclature = _strControlPanelNomenclature + ComboBoxControl.IndexInformation(cboControlPanel);

            //Dash split
            _strControlPanelNomenclature = _strControlPanelNomenclature + "-";

            //Fan Arrangement
            _strControlPanelNomenclature = _strControlPanelNomenclature + _fanWide + _fanLong;

            //Dash split
            _strControlPanelNomenclature = _strControlPanelNomenclature + "-";

            //Unit Voltage
            _strControlPanelNomenclature = _strControlPanelNomenclature + _intVoltageID;

            //Dash split
            _strControlPanelNomenclature = _strControlPanelNomenclature + "-";

            //Control Voltage
            _strControlPanelNomenclature = _strControlPanelNomenclature + ControlVoltageParameter();

            //Dash split
            _strControlPanelNomenclature = _strControlPanelNomenclature + "-";

            //Options
            _strControlPanelNomenclature = _strControlPanelNomenclature + ControlOptionsList();
        }

        //fill the pump inputs table
        private void FillPumpInputs()
        {
            //This contain the PumpModel,hp
            DataTable dtPumpSelection = Public.SelectAndSortTable(Public.DSDatabase.Tables["PumpSelection"], "Pressure >=" + numPumpTotalFeetOfWater.Value + " AND GPM >= " + _decGPM, "Pressure ASC, GPM ASC");

            //for each item in the list
            for (int intIndex = 0; intIndex < lvPumpOptions.Items.Count; intIndex++)
            {
                //if the item is checked get the letter and add it
                if (lvPumpOptions.Items[intIndex].Checked)
                {
                    //i will fill in the row an then add it to the table
                    DataRow drPumpInputs = _dtPumpInputs.NewRow();

                    drPumpInputs["QuoteID"] = 0;
                    drPumpInputs["QuoteRevision"] = 0;
                    drPumpInputs["QuoteRevisionText"] = "";
                    drPumpInputs["ItemType"] = 0;
                    drPumpInputs["ItemID"] = 0;
                    drPumpInputs["Username"] = "";

                    drPumpInputs["PumpNomenclature"] = _strPumpNomenclature;
                    drPumpInputs["PumpType"] = cboPump.Text;
                    drPumpInputs["PumpModel"] = dtPumpSelection.Rows[0]["Nomenclature"].ToString();
                    drPumpInputs["PumpPrice"] = 0m;
                    //This contain the Impellar,Frame,Drawings
                    DataRow[] drPumpInfo = Public.DSDatabase.Tables["PumpInfo"].Select("PumpNomenclature = '" + drPumpInputs["PumpModel"] + "' AND HP = " + dtPumpSelection.Rows[0]["HP"]);

                    drPumpInputs["Impellar"] = Convert.ToDecimal(drPumpInfo[0]["Impellar"]);
                    drPumpInputs["FLA"] = Convert.ToDecimal(Public.DSDatabase.Tables["PumpAmps"].Select("VoltageID = " + _intVoltageID + " AND HP = " + dtPumpSelection.Rows[0]["HP"])[0]["Amps"]);
                    drPumpInputs["Frame"] = drPumpInfo[0]["Frame"].ToString();
                    drPumpInputs["Drawing"] = drPumpInfo[0]["Drawing"].ToString();
                    drPumpInputs["PumpBoxDrawing"] = (PumpNumberOfPump() == "S" ? Public.DSDatabase.Tables["PumpHP"].Select("HP = " + dtPumpSelection.Rows[0]["HP"])[0]["DWG_SIMPLEX"].ToString() : Public.DSDatabase.Tables["PumpHP"].Select("HP = " + dtPumpSelection.Rows[0]["HP"])[0]["DWG_DUPLEX"].ToString());
                    drPumpInputs["RPM"] = 3500;//for now it's fix, later we will ahve a choice
                    drPumpInputs["HP"] = Convert.ToDecimal(dtPumpSelection.Rows[0]["HP"]);
                    drPumpInputs["TotalFeetOfHead"] = numPumpTotalFeetOfWater.Value;
                    drPumpInputs["NumberOfPump"] = cboPumpNumberOfPump.Text;
                    drPumpInputs["ExpansionTankKit"] = cboPumpExpansionTankKit.Text;
                    drPumpInputs["ExpansionTankKitModel"] = cboPumpExpansionTankKitModel.Text;
                    drPumpInputs["ExpansionTankKitPrice"] = 0m;

                    var vlPump = new ValveList((float)_decGPM);
                    Valve vPump = null;
                    switch (PumpValve())
                    {
                        case "2":
                        case "4":
                            vPump = vlPump.Get2WayHWValveSelection((float)_decGPM);
                            break;
                        case "3":
                        case "5":
                            vPump = vlPump.Get3WayHWValveSelection((float)_decGPM);
                            break;
                    }

                    if (PumpValve() == "N")
                    {
                        drPumpInputs["Valve"] = "NONE";
                        drPumpInputs["ValveType"] = "";
                        drPumpInputs["ValveCV"] = 0m;
                        drPumpInputs["ValveConnectionSize"] = "";
                        drPumpInputs["ValvePrice"] = 0m;
                    }
                    else
                    {
                        drPumpInputs["Valve"] = cboPumpWaterValve.Text;
                        if (vPump != null)
                        {
                            drPumpInputs["ValveType"] = vPump.GetValveType();
                            drPumpInputs["ValveCV"] = Convert.ToDecimal(vPump.GetCvValue());
                            drPumpInputs["ValveConnectionSize"] = vPump.GetFractionRepresentationOfConn();
                        }
                        drPumpInputs["ValvePrice"] = 0m;
                    }

                    drPumpInputs["TubeDiameter"] = Public.DSDatabase.Tables["PumpTubeDiameter"].Select("GPMMin < " + _decGPM + " AND GPMMax >= " + _decGPM)[0]["TubeDiameter"].ToString();
                    drPumpInputs["PumpOption"] = lvPumpOptions.Items[intIndex].SubItems[2].Text;
                    drPumpInputs["OptionPrice"] = 0m;

                    _dtPumpInputs.Rows.Add(drPumpInputs);
                }
            }     
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            BuildControlPanelNomenclature();
            FillControlPanelInputs();

            //if fluid cooler and pump selected
            if (_ct == CoolerType.FluidCooler && Pump() != "NONE")
            {
                BuildPumpNomenclature();
                FillPumpInputs();
            }
            else if (_ct == CoolerType.Condenser && Receiver() != "NONE")
            {//if condenser and receiver selected
                BuildReceiverNomenclature();
                FillReceiverInputs();
            }

            Dispose();
        }

        //fill the control panel inputs for the report
        private void FillControlPanelInputs()
        {
            for (int i = 0; i < _chkOptions.Count; i++)
            {
                
                if (_chkOptions[i].Checked)
                {
                    DataRow drControlPanelInputs = _dtControlPanelInputs.NewRow();

                    drControlPanelInputs["QuoteID"] = 0;
                    drControlPanelInputs["QuoteRevision"] = 0;
                    drControlPanelInputs["QuoteRevisionText"] = "";
                    drControlPanelInputs["ItemType"] = 0;
                    drControlPanelInputs["ItemID"] = 0;
                    drControlPanelInputs["Username"] = "";

                    //Panel informations
                    drControlPanelInputs["ControlPanelNomenclature"] = _strControlPanelNomenclature;
                    drControlPanelInputs["PanelDescription"] = cboControlPanel.Text;
                    drControlPanelInputs["Option"] = _chkOptions[i].Text;
                    drControlPanelInputs["OptionPrice"] = _backgroundCode.GetOptionPrice(Public.DSDatabase.Tables["ControlPanel_PanelOptionPrices"], ComboBoxControl.IndexInformation(cboControlPanel), GetOptionText(_chkOptions[i]), _intVoltageID, _fanWide, _fanLong);
                    drControlPanelInputs["ControlVoltage"] = cboControlVoltage.Text;
                    drControlPanelInputs["Price"] = numControlPanelPrice.Value;

                    _dtControlPanelInputs.Rows.Add(drControlPanelInputs);
                }
            }
        }

        //fill the receiver input values for the report
        private void FillReceiverInputs()
        {
            DataRow drReceiverInputs = _dtReceiverInputs.NewRow();

            //main informations
            drReceiverInputs["QuoteID"] = 0;
            drReceiverInputs["QuoteRevision"] = 0;
            drReceiverInputs["QuoteRevisionText"] = "";
            drReceiverInputs["ItemType"] = 0;
            drReceiverInputs["ItemID"] = 0;
            drReceiverInputs["Username"] = "";

            //receiver base informations

            drReceiverInputs["ReceiverInstall"] = cboReceiver.Text;

            //set everything to empty value before to not get problem having null in filed once on the report
            drReceiverInputs["Receiver1Model"] = "";
            drReceiverInputs["Receiver1Diameter"] = 0m;
            drReceiverInputs["Receiver1Length"] = 0m;
            drReceiverInputs["Receiver1Price"] = 0m;
            drReceiverInputs["Receiver1Weight"] = 0m;
            drReceiverInputs["Receiver1ValveModel"] = "";
            drReceiverInputs["Receiver1ValveManufacturer"] = "";
            drReceiverInputs["Receiver1ValveSST"] = 0;
            drReceiverInputs["Receiver1ValveQty"] = 0;
            drReceiverInputs["Receiver1ValvePriceIndividual"] = 0m;
            drReceiverInputs["Receiver1PatchHeaterModel"] = "";
            drReceiverInputs["Receiver1PatchHeaterQty"] = 0;
            drReceiverInputs["Receiver1PatchHeaterPriceIndividual"] = 0m;
            drReceiverInputs["Receiver1SightGlassQty"] = 0;
            drReceiverInputs["Receiver1SightGlassPrice"] = 0m;
            drReceiverInputs["Receiver1InsulationQty"] = 0;
            drReceiverInputs["Receiver1InsulationPrice"] = 0m;
            drReceiverInputs["Receiver1ReliefValveQty"] = 0;
            drReceiverInputs["Receiver1ReliefValvePrice"] = 0m;
            drReceiverInputs["Receiver2Model"] = "";
            drReceiverInputs["Receiver2Diameter"] = 0m;
            drReceiverInputs["Receiver2Length"] = 0m;
            drReceiverInputs["Receiver2Price"] = 0m;
            drReceiverInputs["Receiver2Weight"] = 0m;
            drReceiverInputs["Receiver2ValveModel"] = "";
            drReceiverInputs["Receiver2ValveManufacturer"] = "";
            drReceiverInputs["Receiver2ValveSST"] = 0;
            drReceiverInputs["Receiver2ValveQty"] = 0;
            drReceiverInputs["Receiver2ValvePriceIndividual"] = 0m;
            drReceiverInputs["Receiver2PatchHeaterModel"] = "";
            drReceiverInputs["Receiver2PatchHeaterQty"] = 0;
            drReceiverInputs["Receiver2PatchHeaterPriceIndividual"] = 0m;
            drReceiverInputs["Receiver2SightGlassQty"] = 0;
            drReceiverInputs["Receiver2SightGlassPrice"] = 0m;
            drReceiverInputs["Receiver2InsulationQty"] = 0;
            drReceiverInputs["Receiver2InsulationPrice"] = 0m;
            drReceiverInputs["Receiver2ReliefValveQty"] = 0;
            drReceiverInputs["Receiver2ReliefValvePrice"] = 0m;
            drReceiverInputs["ReceiverTransformer1Model"] = "";
            drReceiverInputs["ReceiverTransformer1Qty"] = 0;
            drReceiverInputs["ReceiverTransformer1Price"] = 0m;
            drReceiverInputs["ReceiverTransformer2Model"] = "";
            drReceiverInputs["ReceiverTransformer2Qty"] = 0;
            drReceiverInputs["ReceiverTransformer2Price"] = 0m;
            drReceiverInputs["ReceiverReinforcedBaseQty"] = 0;
            drReceiverInputs["ReceiverReinforcedBasePrice"] = 0m;
            drReceiverInputs["ReceiverReinforcedBaseWeight"] = 0m;


            DataTable dtReceiver1 = null;
            DataTable dtReceiver2 = null;

            if (_circuitCapacity.Count >= 1)
            {
                dtReceiver1 = Public.SelectAndSortTable(Public.DSDatabase.Tables["ReceiverModels"], "Receiver = '" + lblReceiverModel1.Text + "'", "");
            }

            if (_circuitCapacity.Count == 2)
            {
                dtReceiver2 = Public.SelectAndSortTable(Public.DSDatabase.Tables["ReceiverModels"], "Receiver = '" + lblReceiverModel2.Text + "'", "");
            }

            decimal decTotalWatts = 0m;

            if (dtReceiver1 != null && dtReceiver1.Rows.Count > 0)
            {
                drReceiverInputs["Receiver1Model"] = dtReceiver1.Rows[0]["Receiver"].ToString();
                drReceiverInputs["Receiver1Diameter"] = Convert.ToDecimal(dtReceiver1.Rows[0]["Diameter"]);
                drReceiverInputs["Receiver1Length"] = Convert.ToDecimal(dtReceiver1.Rows[0]["Length"]);
                drReceiverInputs["Receiver1Price"] = Convert.ToDecimal(dtReceiver1.Rows[0]["Price"]);
                drReceiverInputs["Receiver1Weight"] = Convert.ToDecimal(dtReceiver1.Rows[0]["Weight"]);

                //get valve info
                DataTable dtValve1 = Public.SelectAndSortTable(_backgroundCode.GetValveList(Public.DSDatabase.Tables["ReceiverValves"], _circuitRefrigerant[0], _backgroundCode.GetHeatRejectionFactor(Public.DSDatabase.Tables["HeatRejectionFactor"],Convert.ToDecimal(txtCircuit1SST.Text), _circuitCondensing[0]), _circuitCapacity[0]), "Manufacturer = '" + cboReceiverFloodingValveKit1.Text + "'", "");

                if (dtValve1.Rows.Count > 0)
                {
                    drReceiverInputs["Receiver1ValveModel"] = dtValve1.Rows[0]["Description"].ToString();
                    drReceiverInputs["Receiver1ValveManufacturer"] = dtValve1.Rows[0]["Manufacturer"].ToString();
                    drReceiverInputs["Receiver1ValveSST"] = Convert.ToInt32(txtCircuit1SST.Text);
                    drReceiverInputs["Receiver1ValveQty"] = Convert.ToInt32(dtValve1.Rows[0]["QTY"]);
                    drReceiverInputs["Receiver1ValvePriceIndividual"] = Convert.ToDecimal(dtValve1.Rows[0]["Price"]);
                }

                DataTable dtHeater = Public.SelectAndSortTable(Public.DSDatabase.Tables["ReceiverHeater"], "Watt = " + dtReceiver1.Rows[0]["Watts"], "");

                if (dtHeater.Rows.Count > 0)
                {
                    drReceiverInputs["Receiver1PatchHeaterModel"] = dtHeater.Rows[0]["Description"].ToString();
                    drReceiverInputs["Receiver1PatchHeaterQty"] = Convert.ToInt32(dtReceiver1.Rows[0]["HeaterQTY"]);
                    drReceiverInputs["Receiver1PatchHeaterPriceIndividual"] = Convert.ToDecimal(dtHeater.Rows[0]["Price"]);

                    decTotalWatts += (Convert.ToDecimal(dtReceiver1.Rows[0]["HeaterQTY"]) * Convert.ToDecimal(dtReceiver1.Rows[0]["Watts"]));
                }

                if (chkCircuit1SightGlass.Checked)
                {
                    drReceiverInputs["Receiver1SightGlassQty"] = 1;
                    drReceiverInputs["Receiver1SightGlassPrice"] = SightGlassPrice;
                }

                //always there and 10% of the receiver price
                drReceiverInputs["Receiver1InsulationQty"] = 1;
                drReceiverInputs["Receiver1InsulationPrice"] = Convert.ToDecimal(drReceiverInputs["Receiver1Price"]) * 0.10m;

                //always there
                drReceiverInputs["Receiver1ReliefValveQty"] = 1;
                drReceiverInputs["Receiver1ReliefValvePrice"] = ReliefValvePrice;
            }


            if (dtReceiver2 != null && dtReceiver2.Rows.Count > 0)
            {
                drReceiverInputs["Receiver2Model"] = dtReceiver2.Rows[0]["Receiver"].ToString();
                drReceiverInputs["Receiver2Diameter"] = Convert.ToDecimal(dtReceiver2.Rows[0]["Diameter"]);
                drReceiverInputs["Receiver2Length"] = Convert.ToDecimal(dtReceiver2.Rows[0]["Length"]);
                drReceiverInputs["Receiver2Price"] = Convert.ToDecimal(dtReceiver2.Rows[0]["Price"]);
                drReceiverInputs["Receiver2Weight"] = Convert.ToDecimal(dtReceiver2.Rows[0]["Weight"]);

                //get valve info
                DataTable dtValve2 = Public.SelectAndSortTable(_backgroundCode.GetValveList(Public.DSDatabase.Tables["ReceiverValves"], _circuitRefrigerant[1], _backgroundCode.GetHeatRejectionFactor(Public.DSDatabase.Tables["HeatRejectionFactor"],Convert.ToDecimal(txtCircuit2SST.Text), _circuitCondensing[1]), _circuitCapacity[1]), "Manufacturer = '" + cboReceiverFloodingValveKit2.Text + "'", "");

                if (dtValve2.Rows.Count > 0)
                {
                    drReceiverInputs["Receiver2ValveModel"] = dtValve2.Rows[0]["Description"].ToString();
                    drReceiverInputs["Receiver2ValveManufacturer"] = dtValve2.Rows[0]["Manufacturer"].ToString();
                    drReceiverInputs["Receiver2ValveSST"] = Convert.ToInt32(txtCircuit2SST.Text);
                    drReceiverInputs["Receiver2ValveQty"] = Convert.ToInt32(dtValve2.Rows[0]["QTY"]);
                    drReceiverInputs["Receiver2ValvePriceIndividual"] = Convert.ToDecimal(dtValve2.Rows[0]["Price"]);
                }

                DataTable dtHeater = Public.SelectAndSortTable(Public.DSDatabase.Tables["ReceiverHeater"], "Watt = " + dtReceiver2.Rows[0]["Watts"], "");

                if (dtHeater.Rows.Count > 0)
                {
                    drReceiverInputs["Receiver2PatchHeaterModel"] = dtHeater.Rows[0]["Description"].ToString();
                    drReceiverInputs["Receiver2PatchHeaterQty"] = Convert.ToInt32(dtReceiver2.Rows[0]["HeaterQTY"]);
                    drReceiverInputs["Receiver2PatchHeaterPriceIndividual"] = Convert.ToDecimal(dtHeater.Rows[0]["Price"]);

                    decTotalWatts += (Convert.ToDecimal(dtReceiver2.Rows[0]["HeaterQTY"]) * Convert.ToDecimal(dtReceiver2.Rows[0]["Watts"]));
                }

                if (chkCircuit2SightGlass.Checked)
                {
                    drReceiverInputs["Receiver2SightGlassQty"] = 1;
                    drReceiverInputs["Receiver2SightGlassPrice"] = SightGlassPrice;
                }

                //always there and 10% of the receiver price
                drReceiverInputs["Receiver2InsulationQty"] = 1;
                drReceiverInputs["Receiver2InsulationPrice"] = Convert.ToDecimal(drReceiverInputs["Receiver2Price"]) * 0.10m;

                //always there
                drReceiverInputs["Receiver2ReliefValveQty"] = 1;
                drReceiverInputs["Receiver2ReliefValvePrice"] = ReliefValvePrice;
            }

            int intAmountOfTransformerNeeded = GetAmountOfTransformerNeeded();

            if (intAmountOfTransformerNeeded > 0)
            {
                //total all Watts of both receiver
                int intWattsPerTransformer = Convert.ToInt32(decTotalWatts / intAmountOfTransformerNeeded);

                DataTable dtTransformerInfo = Public.SelectAndSortTable(Public.DSDatabase.Tables["ReceiverTransformers"], "Watts >= " + intWattsPerTransformer, "Watts ASC");

                if (intAmountOfTransformerNeeded >= 1 && dtTransformerInfo.Rows.Count > 0)
                {
                    drReceiverInputs["ReceiverTransformer1Model"] = dtTransformerInfo.Rows[0]["Description"].ToString();
                    drReceiverInputs["ReceiverTransformer1Qty"] = 1;
                    drReceiverInputs["ReceiverTransformer1Price"] = Convert.ToDecimal(dtTransformerInfo.Rows[0]["Price"]);
                }

                if (intAmountOfTransformerNeeded >= 2 && dtTransformerInfo.Rows.Count > 0)
                {
                    drReceiverInputs["ReceiverTransformer2Model"] = dtTransformerInfo.Rows[0]["Description"].ToString();
                    drReceiverInputs["ReceiverTransformer2Qty"] = 1;
                    drReceiverInputs["ReceiverTransformer2Price"] = Convert.ToDecimal(dtTransformerInfo.Rows[0]["Price"]);
                }
            }

            //on installed reveicer it's automatic. on shipped loose it's not priced
            if (cboReceiver.Text == @"FACTORY INSTALLED")
            {
                //reinforced base
                drReceiverInputs["ReceiverReinforcedBaseQty"] = 1;
                drReceiverInputs["ReceiverReinforcedBasePrice"] = _backgroundCode.GetReinforcedBasePrice(Public.DSDatabase.Tables["ReceiverReinforcedBasePrice"], _strMotor, _strCoilArr, _fanWide, _fanLong);
                drReceiverInputs["ReceiverReinforcedBaseWeight"] = _backgroundCode.GetReinforcedBaseWeight(Public.DSDatabase.Tables["ReceiverReinforcedBasePrice"], _strMotor, _strCoilArr, _fanWide, _fanLong);
            }

            //add the row
            _dtReceiverInputs.Rows.Add(drReceiverInputs);
        }

        private int GetAmountOfTransformerNeeded()
        {
            int intAmountOfTransformer = 0;

            if (_intVoltageID != 2 && _intVoltageID != 5)
            {
                //only have transformer if the voltage is not 240/1/60 or 240/3/60
                //and in that case we get 1 transfo
                intAmountOfTransformer = 1;

                //now check for split electrical panel that would make qty of transfo needed to be 2
                if (cboControlPanel.Text.Contains("Split"))
                {
                    intAmountOfTransformer = 2;
                }
            }

            return intAmountOfTransformer;
        }

        //auto-select content of numerical up and down on tab
        private void AutoSelectOnTab(object sender, EventArgs e)
        {
            //numerical up and down do not select text by default when we tab
            //or clik in the control. This code make him do it
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
        }

        private void frmQuickControlPanel_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            //2011-04-12 : all tables got removed from control panel to bring the loading time to the condenser or fluid cooler form
            //Query.LoadTables(strTableList);

            Fill_Controls();

            SetDefaults();

            //let the code run normally
            //bolPreventCodeFromRunning = false;
            _bolPreventCodeFromRunningPump = false;

            //if its fluid cooler
            if (_ct == CoolerType.FluidCooler)
            {
                lblPump.Visible = true;
                cboPump.Visible = true;
                pnlPumpPackage.Visible = true;
            }
            else // if it's condenser
            {
                lblReceiver.Visible = true;
                cboReceiver.Visible = true;
                pnlReceiver.Visible = true;
            }

            ThreadProcess.Stop();
            Focus();
        }

        //this fill all the controls
        private void Fill_Controls()
        {
            //fill control panels
            Fill_ControlPanels();

            //2011-04-11 : control voltage now get filled from the choice of panel
            ////fill control voltage
            //Fill_ControlVoltage();

            //fill pump
            Fill_Pump();

            //fill number of pump
            Fill_PumpNumberOfPump();

            //fill pump valve
            Fill_PumpValve();

            //fill pump pressure
            Fill_PumpPressure();

            //fill pump expansion tank kit
            Fill_PumpExpansionTankKit();

            //fill pump expansion tank kit models
            Fill_PumpExpansionTankKitModel();

            //fill the receiver
            Fill_Receiver();

            ////fill receiver type
            //Fill_ReceiverType();

            //if its condenser
            if (_ct == CoolerType.Condenser)
            {
                SetReceiverCircuit();
                Fill_ReceiverModels();
                Fill_ValveCircuit1();
                Fill_ValveCircuit2();
            }
        }

        //fill the pump pressure
        private void Fill_PumpPressure()
        {
            //if it's greater than 125 then set min,max and value to the passed value
            //this is to prevent possible problem in pressure that Ravi has in the DLL
            if (_decLiquidPressureDropInFth2O > 125)
            {
                numPumpTotalFeetOfWater.Maximum = _decLiquidPressureDropInFth2O;
                numPumpTotalFeetOfWater.Value = _decLiquidPressureDropInFth2O;
                numPumpTotalFeetOfWater.Minimum = _decLiquidPressureDropInFth2O;
            }
            else
            {//normal pressure
                //set the value to the max just to make sure the min changing doesnt
                //cause error
                numPumpTotalFeetOfWater.Value = numPumpTotalFeetOfWater.Maximum;

                //set the min to the passed value
                numPumpTotalFeetOfWater.Minimum = _decLiquidPressureDropInFth2O;

                //if the value pass is under 100 then fine set the value to 100
                numPumpTotalFeetOfWater.Value = _decLiquidPressureDropInFth2O < 100m ? 100m : _decLiquidPressureDropInFth2O;
            }
        }

        //Return Pump Valve parameter
        private string PumpValve()
        {
            return ComboBoxControl.IndexInformation(cboPumpWaterValve);
        }

        //Fill Pump Valve
        private void Fill_PumpValve()
        {
            cboPumpWaterValve.Items.Clear();

            if (cboPump.SelectedIndex == -1)
            {//this is to prevent error and have a complete list of options
                ComboBoxControl.AddItem(cboPumpWaterValve, "N", "NO MODUL. VALVE");
                ComboBoxControl.AddItem(cboPumpWaterValve, "2", "2-WAY MODUL. VALVE (INSTALLED)");
                ComboBoxControl.AddItem(cboPumpWaterValve, "4", "2-WAY MODUL. VALVE (SHIPPED LOOSE)");
                ComboBoxControl.AddItem(cboPumpWaterValve, "3", "3-WAY MODUL. VALVE (INSTALLLED)");
                ComboBoxControl.AddItem(cboPumpWaterValve, "5", "3-WAY MODUL. VALVE (SHIPPED LOOSE)");
            }
            else if (cboPump.Text != @"PUMP KIT INTEGRATED")
            {
                ComboBoxControl.AddItem(cboPumpWaterValve, "N", "NO MODUL. VALVE");
                ComboBoxControl.AddItem(cboPumpWaterValve, "4", "2-WAY MODUL. VALVE (SHIPPED LOOSE)");
                ComboBoxControl.AddItem(cboPumpWaterValve, "5", "3-WAY MODUL. VALVE (SHIPPED LOOSE)");
            }
            else
            {
                ComboBoxControl.AddItem(cboPumpWaterValve, "N", "NO MODUL. VALVE");
                ComboBoxControl.AddItem(cboPumpWaterValve, "2", "2-WAY MODUL. VALVE (INSTALLED)");
                ComboBoxControl.AddItem(cboPumpWaterValve, "4", "2-WAY MODUL. VALVE (SHIPPED LOOSE)");
                ComboBoxControl.AddItem(cboPumpWaterValve, "3", "3-WAY MODUL. VALVE (INSTALLLED)");
                ComboBoxControl.AddItem(cboPumpWaterValve, "5", "3-WAY MODUL. VALVE (SHIPPED LOOSE)");
            }

            cboPumpWaterValve.SelectedIndex = 0;
        }

        //return Pump Number Of Pump parameter
        private string PumpNumberOfPump()
        {
            return ComboBoxControl.IndexInformation(cboPumpNumberOfPump);
        }

        //Fill Pump Number Of Pump
        private void Fill_PumpNumberOfPump()
        {
            ComboBoxControl.AddItem(cboPumpNumberOfPump, "S", "SIMPLEX (ONE PUMP)");
            ComboBoxControl.AddItem(cboPumpNumberOfPump, "D", "DUPLEX (1 PUMP + 1 STANDBY PUMP)");
        }

        //return pump unit type parameter
        private string Pump()
        {
            return ComboBoxControl.IndexInformation(cboPump);
        }

        //fill pump unit type
        private void Fill_Pump()
        {
            ComboBoxControl.AddItem(cboPump, "NONE", "NONE");
            //2010-02-11 : We remove pump since we have no price
            ////cannot have pump if you have more than 240 GPM or 0 GPM
            //if (decGPM > 0m && decGPM <= 240m)
            //{
            //    ComboBoxControl.AddItem(cboPump, "PK", "PUMP KIT INTEGRATED");
            //    ComboBoxControl.AddItem(cboPump, "PK", "PUMP KIT SHIPPED LOOSE");
            //    ComboBoxControl.AddItem(cboPump, "PB", "PUMP BOX REMOTE");
            //}
        }

        //return pump Expansion Tank Kit parameter
        private string PumpExpansionTankKit()
        {
            return ComboBoxControl.IndexInformation(cboPumpExpansionTankKit);
        }

        private void Fill_PumpExpansionTankKit()
        {
            ComboBoxControl.AddItem(cboPumpExpansionTankKit, "N", "NONE");
            ComboBoxControl.AddItem(cboPumpExpansionTankKit, "L", "INSTALLED");
            ComboBoxControl.AddItem(cboPumpExpansionTankKit, "S", "SHIPPED LOOSE");
        }

        //return pump Expansion Tank Kit Model parameter
        private string PumpExpansionTankKitModel()
        {
            return ComboBoxControl.IndexInformation(cboPumpExpansionTankKitModel);
        }

        private void Fill_PumpExpansionTankKitModel()
        {
            ComboBoxControl.AddItem(cboPumpExpansionTankKitModel, "E1", "EXTROL#15");
            ComboBoxControl.AddItem(cboPumpExpansionTankKitModel, "E3", "EXTROL#30");
            ComboBoxControl.AddItem(cboPumpExpansionTankKitModel, "E6", "EXTROL#60");
            ComboBoxControl.AddItem(cboPumpExpansionTankKitModel, "E9", "EXTROL#90");
            ComboBoxControl.AddItem(cboPumpExpansionTankKitModel, "S3", "EXTROL SX30");
            ComboBoxControl.AddItem(cboPumpExpansionTankKitModel, "S4", "EXTROL SX40");
            ComboBoxControl.AddItem(cboPumpExpansionTankKitModel, "S6", "EXTROL SX60");
            ComboBoxControl.AddItem(cboPumpExpansionTankKitModel, "S9", "EXTROL SX90");

        }

        private void RemoveAllOptions()
        {
            for (int i = 0; i < _chkOptions.Count; i++)
            {
                pnlOptions.Controls.Remove(_chkOptions[i]);
            }

            _chkOptions = new List<CheckBox>();
        }

        //this set default of controls
        private void SetDefaults()
        {
            //set none for pump
            ComboBoxControl.SetDefaultValue(cboPump, "NONE");

            if (cboControlPanel.Items.Count > 0)
            {
                cboControlPanel.SelectedIndex = 0;
            }
            ////select panel 1 as default
            //ComboBoxControl.SetIDDefaultValue(cboControlPanel, "1");

            //set Simplex quantity of pump
            ComboBoxControl.SetDefaultValue(cboPumpNumberOfPump, "S");

            //set no expansion tnak kit defaulted
            ComboBoxControl.SetDefaultValue(cboPumpExpansionTankKit, "N");

            //set no expansion tnak kit model on the first one
            ComboBoxControl.SetDefaultValue(cboPumpExpansionTankKitModel, "E1");

            //set none for default receiver
            cboReceiver.SelectedIndex = 0;

            //if (intOnlyCondenser == 1)
            //{
            //    //select heated for receiver type
            //    cboReceiverType.SelectedIndex = 0;
            //}
            
        }

        //control voltage parameter
        private string ControlVoltageParameter()
        {
            return ComboBoxControl.ItemInformations(cboControlVoltage, Public.DSDatabase.Tables["ControlPanel_PanelVoltage"], "UniqueID")[0]["VoltageParameter"].ToString();
        }

        //fill control voltage
        private void Fill_ControlVoltage()
        {
            cboControlVoltage.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox

            DataTable dtVoltage = _backgroundCode.GetListOfControlVoltage(Public.DSDatabase.Tables["ControlPanel_PanelVoltage"], ComboBoxControl.IndexInformation(cboControlPanel), Public.DSDatabase.Tables["ControlPanel_PanelsSelection"], _ct, _fanWide, _circuitCapacity.Count, AreCircuitEqualCapacity(), _strMotor + _strCoilArr);

            //loop through all control voltage
            foreach (DataRow drControlVoltage in dtVoltage.Rows)
            {
                string strIndex = drControlVoltage["UniqueID"].ToString();
                string strText = drControlVoltage["Voltage"].ToString();
                ComboBoxControl.AddItem(cboControlVoltage, strIndex, strText);
            }

            if (cboControlVoltage.Items.Count > 0)
            {
                cboControlVoltage.SelectedIndex = 0;
            }
        }


        //this fill the control panel combobox
        private void Fill_ControlPanels()
        {
            cboControlPanel.Items.Clear();

            DataTable dtPanels = _backgroundCode.GetListOfPanels(Public.DSDatabase.Tables["ControlPanel_Panels"], Public.DSDatabase.Tables["ControlPanel_PanelsSelection"], Public.DSDatabase.Tables["ControlPanel_PanelOptionPrices"], Public.DSDatabase.Tables["ControlPanel_PanelPrices"], _ct, _fanWide, _fanLong, _circuitCapacity.Count, AreCircuitEqualCapacity(), _strMotor + _strCoilArr);

            for (int i = 0; i < dtPanels.Rows.Count; i++)
            {
                ComboBoxControl.AddItem(cboControlPanel, dtPanels.Rows[i]["Panel"].ToString(), dtPanels.Rows[i]["Panel"] + " - " + dtPanels.Rows[i]["Description"]);
            }

        }
        private string ControlOptionsList()
        {
            string strOptionList = "";

            for (int i = 0; i < _chkOptions.Count; i++)
            {
                if (_chkOptions[i].Checked)
                {
                    strOptionList += GetOptionText(_chkOptions[i]);
                }
            }

            return strOptionList;
        }

        private string PumpOptionsList()
        {
            string strOptionList = "";

            //for each item in the list
            for (int intIndex = 0; intIndex < lvPumpOptions.Items.Count; intIndex++)
            {
                //if the item is checked get the letter and add it
                if (lvPumpOptions.Items[intIndex].Checked)
                {
                    strOptionList = strOptionList + lvPumpOptions.Items[intIndex].SubItems[2].Text.Substring(0, 1);
                }
            }

            return strOptionList;
        }

        private void Fill_ControlOptions()
        {
            RemoveAllOptions();

            DataTable dtOptions = _backgroundCode.GetListOfOptions(Public.DSDatabase.Tables["ControlPanel_Options"], Public.DSDatabase.Tables["ControlPanel_OptionsSelection"], Public.DSDatabase.Tables["ControlPanel_PanelOptionPrices"], Public.DSDatabase.Tables["ControlPanel_PanelPrices"], ComboBoxControl.IndexInformation(cboControlPanel), _intVoltageID, _ct, _fanWide, _fanLong, _strMotor + _strCoilArr);

            for (int i = 0; i < dtOptions.Rows.Count; i++)
            {
                _chkOptions.Add(GetOptionCheck(dtOptions.Rows[i]["PanelOption"] + " - " + dtOptions.Rows[i]["Description"], dtOptions.Rows[i]["PanelOption"] + "," + dtOptions.Rows[i]["GroupID"] + "," + dtOptions.Rows[i]["UniqueSelection"]));
            }

            FillOptionPanel();

            ChangeCheckSpecificOption("N", true);
        }

        private void FillOptionPanel()
        {
            const int x = 10;
            if (_chkOptions.Count > 0)
            {
                pnlOptions.Controls.Add(_chkOptions[0]);
                _chkOptions[0].Left = x;
                _chkOptions[0].Top = 0;

                for (int i = 1; i < _chkOptions.Count; i++)
                {
                    pnlOptions.Controls.Add(_chkOptions[i]);

                    _chkOptions[i].Left = x;
                    _chkOptions[i].Top = _chkOptions[i - 1].Bottom + 5;
                }
            }
        }

        private CheckBox GetOptionCheck(string text, string tag)
        {
            var chk = new CheckBox {AutoSize = true, Text = text, Tag = tag};
            chk.CheckedChanged += chkOptions_CheckedChanged;

            return chk;
        }

        private string GetOptionText(CheckBox chk)
        {
            return chk.Tag.ToString().Split(',')[0];
        }

        private string GetOptionText(object chk)
        {
            return GetOptionText((CheckBox)chk);
        }

        private int GetOptionGroup(CheckBox chk)
        {
            return Convert.ToInt32( chk.Tag.ToString().Split(',')[1]);
        }

        private int GetOptionGroup(object chk)
        {
            return GetOptionGroup((CheckBox)chk);
        }

        private bool GetOptionUnique(CheckBox chk)
        {
            return (chk.Tag.ToString().Split(',')[2] == "1");
        }

        private bool GetOptionUnique(object chk)
        {
            return GetOptionUnique((CheckBox)chk);
        }

        private void chkOptions_CheckedChanged(object sender, EventArgs e)
        {
            if (_optionCheckChangedUnlock)
            {
                //temporary block the possible recusivity when checking / unchecking options
                //to prevent dead loop
                _optionCheckChangedUnlock = false;

                if (((CheckBox)sender).Checked)
                {

                    if (GetOptionUnique(sender))
                    {//if unique uncheck all other options

                        for (int i = 0; i < _chkOptions.Count; i++)
                        {
                            //if it's not the option we just checked
                            if (GetOptionText(_chkOptions[i]) != GetOptionText(sender))
                            {
                                //uncheck it
                                ChangeCheckSpecificOption(GetOptionText(_chkOptions[i]), false);
                            }
                        }
                    }
                    else
                    {//not unique uncheck all unique options and all OTHER option from same group
                       
                        for (int i = 0; i < _chkOptions.Count; i++)
                        {
                            if (GetOptionUnique(_chkOptions[i])
                                || (GetOptionGroup(_chkOptions[i]) == GetOptionGroup(sender) &&
                                    GetOptionText(_chkOptions[i]) != GetOptionText(sender))
                                )
                            {// If ( [Unique] OR ([Same Group] AND [Not same option])
                                ChangeCheckSpecificOption(GetOptionText(_chkOptions[i]), false);
                            }
                        }
                    }
                }
                else
                {
                    bool isSomethingChecked = false;

                    for (int i = 0; i < _chkOptions.Count; i++)
                    {
                        if (_chkOptions[i].Checked)
                        {
                            isSomethingChecked = true;
                            i = _chkOptions.Count;
                        }
                    }

                    if (!isSomethingChecked)
                    {//if nothing checked anymore automatically check none.
                        //this should be the only hardcoded thing about options. the rest get selected in accordance
                        //with logic from database
                        ChangeCheckSpecificOption("N", true);
                    }
                }

                //re enable the possible checking / unchecking of options
                _optionCheckChangedUnlock = true;
            }
        }

        private void ChangeCheckSpecificOption(string option, bool checkState)
        {
            for (int i = 0; i < _chkOptions.Count; i++)
            {
                if (GetOptionText(_chkOptions[i]) == option)
                {
                    _chkOptions[i].Checked = checkState;
                    i = _chkOptions.Count;
                }
            }
        }

        private void cboControlPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //refill the control options list
            Fill_ControlOptions();
            Fill_ControlVoltage();

            FillPanelPrice();
        }

        private void FillPanelPrice()
        {
            lblSpecialPrice.Visible = false;
            numControlPanelPrice.Visible = false;

            numControlPanelPrice.Value = _backgroundCode.GetPanelPrice(Public.DSDatabase.Tables["ControlPanel_PanelPrices"], ComboBoxControl.IndexInformation(cboControlPanel), _fanWide, _fanLong);

            if (_backgroundCode.IsPanelPriceSpecial(Public.DSDatabase.Tables["ControlPanel_SpecialPrice"], ComboBoxControl.IndexInformation(cboControlPanel), _fanWide, _fanLong))
            {
                numControlPanelPrice.Value = 0m;
                lblSpecialPrice.Visible = true;
                numControlPanelPrice.Visible = true;
            }
        }

        private void cboPump_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPumpExpansionTankKit.Enabled = true;
            if (Pump() == "NONE")
            {
                pnlPumpPackage.Enabled = false;
            }
            else
            {
                pnlPumpPackage.Enabled = true;
                if (cboPump.Text != @"PUMP KIT INTEGRATED")
                {
                    //only integrated can select expansion tnak kit
                    cboPumpExpansionTankKit.SelectedIndex = 0;
                    cboPumpExpansionTankKit.Enabled = false;

                    Fill_PumpValve();
                }
            }

            //fill pump option
            Fill_PumpOption();

            //UnCheck Fuse For Control Panel Option On Integrated Pump
            UnCheckFuseForControlPanelOptionOnIntegratedPump();
        }

        //UnCheck Fuse For Control Panel Option On Integrated Pump
        private void UnCheckFuseForControlPanelOptionOnIntegratedPump()
        {
            ////only if integrated
            //if (cboPump.Text == "PUMP KIT INTEGRATED")
            //{
            //    //loop on all options of the list
            //    for (int intIndex = 0; intIndex < lvControlOptions.Items.Count; intIndex++)
            //    {
            //        //if the item is checked and it E or F then uncheck them
            //        if (lvControlOptions.Items[intIndex].Checked && (lvControlOptions.Items[intIndex].SubItems[2].Text.StartsWith("E") || lvControlOptions.Items[intIndex].SubItems[2].Text.StartsWith("F")))
            //        {
            //            lvControlOptions.Items[intIndex].Checked = false;
            //        }
            //    }
            //}
        }

        //fill the pump option
        private void Fill_PumpOption()
        {
            lvPumpOptions.Items.Clear();

            DataTable dtActivePumpOption = _backgroundCode.FilteredPumpOptions(Public.DSDatabase.Tables["PumpOption"], Pump());

            //loop through all ControlOptions
            for (int intPumpOption = 0; intPumpOption < dtActivePumpOption.Rows.Count; intPumpOption++)
            {
                lvPumpOptions.Items.Add(new ListViewItem(new[] { "", dtActivePumpOption.Rows[intPumpOption]["UniqueID"].ToString(), dtActivePumpOption.Rows[intPumpOption]["OptionID"] + " - " + dtActivePumpOption.Rows[intPumpOption]["OptionDescription"]}));
            }

            if (lvPumpOptions.Items.Count > 0)
            {
                //select none by default
                lvPumpOptions.Items[0].Checked = true;
            }
        }

        private void lvPumpOptions_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!_bolPreventCodeFromRunningPump)
            {
                //first we only do stuff if an item is checked
                if (e.Item.Checked)
                {
                    //if it's not None selected, automaticly 
                    //uncheck none if not already done
                    if (e.Item.SubItems[1].Text != @"1")
                    {
                        //uncheck none
                        lvPumpOptions.Items[0].Checked = false;

                        //get teh group the option selected is part of
                        int groupToVerify = _backgroundCode.PumpOptionGrouping(Public.DSDatabase.Tables["PumpOption"], Convert.ToInt32(e.Item.SubItems[1].Text));

                        //group 0 mean there is no grouping on this option
                        if (groupToVerify > 0)
                        {
                            //bolPreventCodeFromRunning = true;
                            for (int intPumpOption = 0; intPumpOption < lvPumpOptions.Items.Count; intPumpOption++)
                            {
                                //if it's none or the group of the option match the one we want remove
                                //and it's not the current item that has been clicked
                                if (lvPumpOptions.Items[intPumpOption].SubItems[1].Text == @"1"
                                    || (_backgroundCode.PumpOptionGrouping(Public.DSDatabase.Tables["PumpOption"], Convert.ToInt32(lvPumpOptions.Items[intPumpOption].SubItems[1].Text)) == groupToVerify
                                    && intPumpOption != e.Item.Index))
                                {
                                    lvPumpOptions.Items[intPumpOption].Checked = false;
                                }
                            }
                        }
                    }
                    else
                    {//none is checked uncheck all except none
                        _bolPreventCodeFromRunningPump = true;
                        for (int intPumpOption = 0; intPumpOption < lvPumpOptions.Items.Count; intPumpOption++)
                        {
                            if (lvPumpOptions.Items[intPumpOption].SubItems[1].Text != @"1")
                            {
                                lvPumpOptions.Items[intPumpOption].Checked = false;
                            }
                        }
                        _bolPreventCodeFromRunningPump = false;
                    }
                    //MessageBox.Show(e.Item.SubItems[2].Text.ToString());
                }
                else
                {
                    //will contain the number of checked options
                    int intNumberOfChecked = 0;

                    //loop on all options of the list
                    for (int intIndex = 0; intIndex < lvPumpOptions.Items.Count; intIndex++)
                    {
                        //if the item is checked increase the amount of items checked
                        if (lvPumpOptions.Items[intIndex].Checked)
                        {
                            ++intNumberOfChecked;
                        }
                    }

                    //if we have no item checked
                    if (intNumberOfChecked == 0)
                    {
                        _bolPreventCodeFromRunningPump = true;

                        //force to check none
                        lvPumpOptions.Items[0].Checked = true;

                        _bolPreventCodeFromRunningPump = false;
                    }
                }
            }
        }

        //return the receiver selected
        private string Receiver()
        {
            return ComboBoxControl.IndexInformation(cboReceiver);
        }

        private void Fill_Receiver()
        {
            bool reInforcedBasePriceAvailable = _backgroundCode.GetReinforcedBasePrice(Public.DSDatabase.Tables["ReceiverReinforcedBasePrice"], _strMotor, _strCoilArr, _fanWide, _fanLong) != -999999;


            //if no circuits
            if (_circuitCapacity.Count == 0)
            {
                ComboBoxControl.AddItem(cboReceiver, "NONE", "NONE");
            }
            //if 1 circuits
            else if (_circuitCapacity.Count == 1)
            {
                ComboBoxControl.AddItem(cboReceiver, "NONE", "NONE");
                //2011-06-17 : adding logic that only vertical can have factory installed
                //2010-07-08 : We have price so we add it back but it has major change
                //over what we had before.
                //2010-02-11 : We remove recevier since we have no price
                if (reInforcedBasePriceAvailable && _airFlow == "V")
                {
                    ComboBoxControl.AddItem(cboReceiver, "1R", "FACTORY INSTALLED");
                }
                ComboBoxControl.AddItem(cboReceiver, "1S", "SHIPPED LOOSE");
            }
            //if 2 circuits
            else if (_circuitCapacity.Count == 2)
            {
                //only if both refrigerant are the same that we can offer receiver
                if (_circuitRefrigerant[0] == _circuitRefrigerant[1])
                {
                    ComboBoxControl.AddItem(cboReceiver, "NONE", "NONE");
                    //2011-06-17 : adding logic that only vertical can have factory installed
                    if (reInforcedBasePriceAvailable && _airFlow == "V")
                    {
                        ComboBoxControl.AddItem(cboReceiver, "2E", "FACTORY INSTALLED");
                    }
                    ComboBoxControl.AddItem(cboReceiver, "2L", "SHIPPED LOOSE");
                }
                else
                {
                    ComboBoxControl.AddItem(cboReceiver, "NONE", "NONE");
                }
            }
            //if more than 2 circuits
            else
            {
                ComboBoxControl.AddItem(cboReceiver, "NONE", "NONE - CONTACT FACTORY FOR MORE THAN 2 CIRCUITS");
            }
        }

        private void cboReceiver_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Receiver() == "NONE")
            {
                pnlReceiver.Enabled = false;
            }
            else
            {
                pnlReceiver.Enabled = true;
                Fill_ReceiverModels();
            }
        }

        private void SetReceiverCircuit()
        {
            _preventCircuitValueChangeCodeTrigger = true;

            pnlReceiverCircuit1.Enabled = false;
            pnlReceiverCircuit2.Enabled = false;

            if (_circuitCapacity.Count == 1)
            {
                pnlReceiverCircuit1.Enabled = true;

                numCircuit1Charge.Minimum = 0;
                numCircuit1Charge.Maximum = 100;
                numCircuit1Charge.Value = 100;
                numCircuit1Charge.Enabled = false;
                numCircuit1Charge.BackColor = Color.White;
            }
            else if (_circuitCapacity.Count == 2)
            {
                pnlReceiverCircuit1.Enabled = true;
                pnlReceiverCircuit2.Enabled = true;

                //min and max is to make sure the number is lowered to 99
                //if over and bump up to 1 if lower
                numCircuit1Charge.Value = Math.Min(Math.Max(Math.Ceiling((_circuitCapacity[0] / (_circuitCapacity[0] + _circuitCapacity[1])) * 100m), 1m), 99m);
                numCircuit1Charge.Minimum = 1m;
                numCircuit1Charge.Maximum = 99m;
                numCircuit1Charge.Enabled = false;
                numCircuit1Charge.BackColor = Color.White;

                numCircuit2Charge.Value = 100m - numCircuit1Charge.Value;
                numCircuit2Charge.Minimum = 1m;
                numCircuit2Charge.Maximum = 99m;
                numCircuit2Charge.Enabled = false;
                numCircuit2Charge.BackColor = Color.White;
            }

            _preventCircuitValueChangeCodeTrigger = false;
        }


        private void Fill_ReceiverModels()
        {
            ThreadProcess.Start(Public.LanguageString("Selecting Receiver Models", "Sélection des Réservoirs"));

            Charge chargeCircuit1 = null;
            Charge chargeCircuit2 = null;

            //fill circ 1 charge
            if (_circuitCapacity.Count >= 1)
            {
                chargeCircuit1 =  CondenserReceiverCharge.GetCharge(_circuitRefrigerant[0], _strCoilFinType, _intNumberOfFaceTubes, _intNumberOfRows, _decFinLength, numCircuit1Charge.Value / 100m);
            }
            
            //fill circ 2 charge
            if (_circuitCapacity.Count == 2)
            {
                chargeCircuit2 = CondenserReceiverCharge.GetCharge(_circuitRefrigerant[1], _strCoilFinType, _intNumberOfFaceTubes, _intNumberOfRows, _decFinLength, numCircuit2Charge.Value / 100m);
            }

            //fill receiver model 1
            if (_circuitCapacity.Count >= 1)
            {
                //circuit charge is : (Vapor + Liquid) + 25%
                if (chargeCircuit1 != null)
                {
                    decimal circ1SecuredWinterCharge = (chargeCircuit1.WinterLiquid + chargeCircuit1.WinterVapor) * 1.25m;

                    DataTable dtGoodModels = Public.SelectAndSortTable(Public.DSDatabase.Tables["ReceiverModels"], "Min <= " + circ1SecuredWinterCharge + " AND Max > " + circ1SecuredWinterCharge, "Min ASC");
                    if (dtGoodModels.Rows.Count > 0)
                    {
                        lblReceiverModel1.Text = dtGoodModels.Rows[0]["Receiver"].ToString();

                        if (Convert.ToDecimal(dtGoodModels.Rows[0]["Diameter"]) >= 8.625m)
                        {
                            chkCircuit1SightGlass.Enabled = true;
                            chkCircuit1SightGlass.Checked = false;
                        }
                        else
                        {
                            chkCircuit1SightGlass.Enabled = false;
                            chkCircuit1SightGlass.Checked = false;
                        }
                    }
                }
            }

            //fill receiver model 2
            if (_circuitCapacity.Count == 2)
            {
                //circuit charge is : (Vapor + Liquid) + 25%
                if (chargeCircuit2 != null)
                {
                    decimal circ2SecuredWinterCharge = (chargeCircuit2.WinterLiquid + chargeCircuit2.WinterVapor) * 1.25m;

                    DataTable dtGoodModels = Public.SelectAndSortTable(Public.DSDatabase.Tables["ReceiverModels"], "Min <= " + circ2SecuredWinterCharge + " AND Max > " + circ2SecuredWinterCharge, "Min ASC");
                    if (dtGoodModels.Rows.Count > 0)
                    {
                        lblReceiverModel2.Text = dtGoodModels.Rows[0]["Receiver"].ToString();

                        if (Convert.ToDecimal(dtGoodModels.Rows[0]["Diameter"]) >= 8.625m)
                        {
                            chkCircuit2SightGlass.Enabled = true;
                            chkCircuit2SightGlass.Checked = false;
                        }
                        else
                        {
                            chkCircuit2SightGlass.Enabled = false;
                            chkCircuit2SightGlass.Checked = false;
                        }
                    }
                }
            }

            ThreadProcess.Stop();
            Focus();
        }


        //private string Tranformer2Nomenclature()
        //{
        //    //if the tranformer quantity is 2 it mean we have a secodn transformer
        //    //but check also if th receiver type is not selected on None (Receiver Only)
        //    if (TransformerQuantity() >= 2 && ReceiverType() != "0")
        //    {
        //        int intHeaterQty = Convert.ToInt32(ComboBoxControl.ItemInformations(cboReceiverSecondReceiver, Public.dsDATABASE.Tables["ReceiverModels"], "Nomenclature")[0]["HeaterQty"]);
        //        int intWatts = Convert.ToInt32(ComboBoxControl.ItemInformations(cboReceiverSecondReceiver, Public.dsDATABASE.Tables["ReceiverModels"], "Nomenclature")[0]["Watts"]);
        //        int intVA = Convert.ToInt32(Public.dsDATABASE.Tables["ReceiverTransformers"].Select("Watts = " + intWatts.ToString())[0]["VA"]);
        //        int intTotalVA = intHeaterQty * intVA;

        //        //format the total watts of the receiver
        //        return intTotalVA.ToString().PadLeft(4, Convert.ToChar("0"));
        //    }
        //    else
        //    {
        //        //this is the nomenclature for no transformers
        //        return "N";
        //    }
        //}

        //private string Tranformer1Nomenclature()
        //{
        //    //if the tranformer quantity is 1 it mean we have a transformer
        //    //but check also if th receiver type is not selected on None (Receiver Only)
        //    if (TransformerQuantity() >= 1 && ReceiverType() != "0")
        //    {
        //        int intHeaterQty = Convert.ToInt32(ComboBoxControl.ItemInformations(cboReceiverFirstReceiver, Public.dsDATABASE.Tables["ReceiverModels"], "Nomenclature")[0]["HeaterQty"]);
        //        int intWatts = Convert.ToInt32(ComboBoxControl.ItemInformations(cboReceiverFirstReceiver, Public.dsDATABASE.Tables["ReceiverModels"], "Nomenclature")[0]["Watts"]);
        //        int intVA = Convert.ToInt32(Public.dsDATABASE.Tables["ReceiverTransformers"].Select("Watts = " + intWatts.ToString())[0]["VA"]);
        //        int intTotalVA = intHeaterQty * intVA;

        //        //format the total watts of the receiver
        //        return intTotalVA.ToString().PadLeft(4, Convert.ToChar("0"));
        //    }
        //    else
        //    {
        //        //this is the nomenclature for no transformers
        //        return "N";
        //    }
        //}

        //private int TransformerQuantity()
        //{
        //    //the following voltage are voltage id that do not allow transformer
        //    if (intVoltageID == 1 || intVoltageID == 2 || intVoltageID == 3 || intVoltageID == 5)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        //the number of circuit is actually the number of transformer
        //        //but up to 2 circuits, anyway we do not offer receiver on 3 circuits
        //        //so this else cannot cause any problem
        //        return intNumberOfRefrigerantCircuit;
        //    }
        //}

        private void Fill_ValveFromList(DataTable dtValveList, ComboBox cboValve)
        {
            cboValve.Items.Clear();

            //if we have valves
            if (dtValveList.Rows.Count > 0)
            {
                //for each valve add the maufacturer
                for (int intRow = 0; intRow < dtValveList.Rows.Count; intRow++)
                {
                    ComboBoxControl.AddItem(cboValve, "", dtValveList.Rows[intRow]["Manufacturer"].ToString());                 
                }
            }
            else
            {
                //no valve add the option
                ComboBoxControl.AddItem(cboValve, "N", "No Valve");
            }

            cboValve.SelectedIndex = 0;
        }

        private void Fill_ValveCircuit1()
        {
            //fill the valve 1
            Fill_ValveFromList(_backgroundCode.GetValveList(Public.DSDatabase.Tables["ReceiverValves"], _circuitRefrigerant[0], _backgroundCode.GetHeatRejectionFactor(Public.DSDatabase.Tables["HeatRejectionFactor"], Convert.ToDecimal(txtCircuit1SST.Text), _circuitCondensing[0]), _circuitCapacity[0]), cboReceiverFloodingValveKit1);
        }

        private void Fill_ValveCircuit2()
        {
            //fill the valve 2
            Fill_ValveFromList(_backgroundCode.GetValveList(Public.DSDatabase.Tables["ReceiverValves"], (_circuitCapacity.Count >= 2 ? _circuitRefrigerant[1] : ""), _backgroundCode.GetHeatRejectionFactor(Public.DSDatabase.Tables["HeatRejectionFactor"], Convert.ToDecimal(txtCircuit2SST.Text), (_circuitCapacity.Count >= 2 ? _circuitCondensing[1] : 0m)), (_circuitCapacity.Count >= 2 ? _circuitCapacity[1] : 0m)), cboReceiverFloodingValveKit2);
        }

        private void cboPumpExpansionTankKit_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPumpExpansionTankKitModel.Enabled = PumpExpansionTankKit() != "N";
        }

        private void numCircuit1Charge_ValueChanged(object sender, EventArgs e)
        {
            if (!_preventCircuitValueChangeCodeTrigger)
            {
                _preventCircuitValueChangeCodeTrigger = true;
                numCircuit2Charge.Value = 100m - numCircuit1Charge.Value;
                Fill_ReceiverModels();
                _preventCircuitValueChangeCodeTrigger = false;
            }
        }

        private void numCircuit2Charge_ValueChanged(object sender, EventArgs e)
        {
            if (!_preventCircuitValueChangeCodeTrigger)
            {
                _preventCircuitValueChangeCodeTrigger = true;
                numCircuit1Charge.Value = 100m - numCircuit2Charge.Value;
                Fill_ReceiverModels();
                _preventCircuitValueChangeCodeTrigger = false;
            }
        }

        private void numCircuit1SST_ValueChanged(object sender, EventArgs e)
        {
            Fill_ValveCircuit1();
        }

        private void numCircuit2SST_ValueChanged(object sender, EventArgs e)
        {
            Fill_ValveCircuit2();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmQuickControlPanel_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }

        private void txtCircuit1SST_Validated(object sender, EventArgs e)
        {
            if (IsNumber(txtCircuit1SST.Text))
            {
                int sst = Convert.ToInt32(Math.Round(Convert.ToDecimal(txtCircuit1SST.Text), 0));

                if (sst < -40)
                {
                    sst = -40;
                }

                if (sst > 45)
                {
                    sst = 45;
                }

                txtCircuit1SST.Text = sst.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                txtCircuit1SST.Text = @"45";
            }

            Fill_ValveCircuit1();
        }

        private bool IsNumber(string s)
        {
            decimal testDecimal;

            return Decimal.TryParse(s, out testDecimal);
        }



        private void txtCircuit2SST_Validated(object sender, EventArgs e)
        {
            if (IsNumber(txtCircuit2SST.Text))
            {
                int sst = Convert.ToInt32(Math.Round(Convert.ToDecimal(txtCircuit2SST.Text), 0));

                if (sst < -40)
                {
                    sst = -40;
                }

                if (sst > 45)
                {
                    sst = 45;
                }

                txtCircuit2SST.Text = sst.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                txtCircuit2SST.Text = @"45";
            }

            Fill_ValveCircuit2();
        }
    }
}