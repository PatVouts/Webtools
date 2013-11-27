using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.QuickWaterEvaporator
{
    public partial class FrmQuickWaterEvaporator : Form
    {
        //form need access to his background code
        private readonly QuickWaterEvaporatorCode _backgroundCode = new QuickWaterEvaporatorCode();

        private readonly string[] _strTableList = { "FuseSize", "CoilCasingMaterial", "FreezingPointEthylene", "FreezingPointPropylene", "ElectroFinAdjustement", "HeresiteSafety", "v_CoilTubeDefaults", "v_CoilFinDefaults", "CoilTubeMaterial", "CoilFinMaterial", "CoilFluidType", "EvaporatorVoltage", "Evaporators", "v_Evaporators", "CoilFinType" };

        //link to the quote form
        private readonly Quotes.FrmQuotes _quoteform;
        //dataset of the quote
        private readonly DataSet _dsQuoteData;
        //index of the row, -1 mean not loading so we know it's a new record
        private readonly int _intIndex = -1;
        //is true if the form is loaded from quote, false if loaded ordinary
        private readonly bool _bolQuoteSelection;

        public FrmQuickWaterEvaporator()
        {
            InitializeComponent();
        }

        public FrmQuickWaterEvaporator(Quotes.FrmQuotes quoteform, DataSet dsQuoteData, int intIndex)
        {
            InitializeComponent();
            _quoteform = quoteform;
            _dsQuoteData = dsQuoteData;
            _intIndex = intIndex;
            _bolQuoteSelection = true;
        }

        private void frmQuickWaterEvaporator_Load(object sender, EventArgs e)
        {
            Public.ChangeFormLanguage(this);

            Public.ChangeColor(this);

            Query.LoadTables(_strTableList);

            //fill all the combobox
            Fill_Combobox();

            //set defaults
            SetDefaults();

            ThreadProcess.Stop();
            Focus();

            if (_bolQuoteSelection && _intIndex != -1)
            {
                LoadSavedData();
                RunSelection();
            }
        }

        private void Fill_Combobox()
        {
            FillModel();
            FillFluidType();
        }

        private void FillModel()
        {
            _backgroundCode.FillModel(cboModel, Public.DSDatabase.Tables["Evaporators"].Copy());
        }

        private void FillFluidType()
        {
            _backgroundCode.FillFluidType(cboFluidType, Public.DSDatabase.Tables["CoilFluidType"].Copy());
        }

        private void SetDefaults()
        {
            cboModel.SelectedIndex = 0;
            cboGPM_LeavingLiquidTemp.SelectedIndex = 0;
            cboFluidType.SelectedIndex = 0;
        }

        private void LoadSavedData()
        {
            _backgroundCode.LoadData(_dsQuoteData, _intIndex, txtTag, numQuantity, cboModel, cboVoltage, numEDB, numEWB, numAltitude, cboFluidType, numConcentration, numELT, cboGPM_LeavingLiquidTemp, numUSGPM, numLeavingLiquidTemperature, cboNumberOfCircuits, cboFPI, cboFinMaterial, cboCoilCoating);
        }

        private void cboModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillVoltage();
            FillNumberOfCircuit();
            FillFPI();
            FillCoilCoating();
            FillFinMaterial();
            CleanPerformance();
        }

        private void FillNumberOfCircuit()
        {
            _backgroundCode.FillNumberOfCircuits(cboNumberOfCircuits, cboModel, Public.DSDatabase.Tables["v_Evaporators"].Copy());
        }

        private void FillFPI()
        {
            _backgroundCode.FillFPI(cboFPI, cboModel, Public.DSDatabase.Tables["v_Evaporators"].Copy());
        }

        private void FillVoltage()
        {
            _backgroundCode.FillVoltage(cboVoltage, cboModel, Public.DSDatabase.Tables["v_Evaporators"].Copy(), Public.DSDatabase.Tables["EvaporatorVoltage"].Copy());
        }

        private void cboGPM_LeavingLiquidTemp_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateGPM_LLT();
            CleanPerformance();
        }

        private void ValidateGPM_LLT()
        {
            _backgroundCode.ValidateGPM_LLT(cboGPM_LeavingLiquidTemp, numUSGPM, numLeavingLiquidTemperature);
        }

        private void cboFluidType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateConcentration();
            CleanPerformance();
        }

        private void ValidateConcentration()
        {
            _backgroundCode.ValidateConcentration(cboFluidType, numConcentration, Public.DSDatabase.Tables["CoilFluidType"].Copy());
        }

        private void cmdRunSelection_Click(object sender, EventArgs e)
        {
            RunSelection();
        }

        private void RunSelection()
        {
            _latestSelection = GetCoilSelection();
            _backgroundCode.DisplayResult(lstResults, _latestSelection, numQuantity, cboModel, Public.DSDatabase.Tables["v_Evaporators"].Copy());
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            Accept();
        }

        private Coil.CoolingCoil _latestSelection = new Coil.CoolingCoil();

        private Coil.CoolingCoil GetCoilSelection()
        {
            return _backgroundCode.GetCoilSelection(cboModel, numAltitude, cboFluidType, numConcentration, numELT, numEDB, numEWB, cboGPM_LeavingLiquidTemp, numUSGPM, numLeavingLiquidTemperature, cboNumberOfCircuits, numQuantity, cboFPI, cboFinMaterial, Public.DSDatabase.Tables["v_Evaporators"].Copy(), Public.DSDatabase.Tables["CoilFinType"].Copy(), Public.DSDatabase.Tables["CoilFluidType"].Copy(), Public.DSDatabase.Tables["CoilFinMaterial"].Copy(), Public.DSDatabase.Tables["CoilTubeMaterial"].Copy(), Public.DSDatabase.Tables["v_CoilFinDefaults"].Copy(), Public.DSDatabase.Tables["v_CoilTubeDefaults"].Copy(), Public.DSDatabase.Tables["FreezingPointEthylene"].Copy(), Public.DSDatabase.Tables["FreezingPointPropylene"].Copy());
        }

        private void Accept()
        {
            bool closeFormOnSuccess = false;

            if (_backgroundCode.Accept(_quoteform, _dsQuoteData, _bolQuoteSelection, _intIndex, _latestSelection, txtTag, numQuantity, cboModel, cboVoltage, numEDB, numEWB, numAltitude, cboFluidType, numConcentration, numELT, cboGPM_LeavingLiquidTemp, numUSGPM, numLeavingLiquidTemperature, cboNumberOfCircuits, cboFPI, cboFinMaterial, cboCoilCoating, Public.DSDatabase.Tables["v_Evaporators"].Copy(), Public.DSDatabase.Tables["CoilFinMaterial"].Copy(), Public.DSDatabase.Tables["CoilCasingMaterial"].Copy(), Public.DSDatabase.Tables["CoilTubeMaterial"].Copy(), Public.DSDatabase.Tables["v_CoilFinDefaults"].Copy(), Public.DSDatabase.Tables["FuseSize"].Copy(), Public.DSDatabase.Tables["EvaporatorDrawingManager"].Copy(), ref closeFormOnSuccess))
            {
                if (closeFormOnSuccess) Dispose();
            }
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            CleanPerformance();
        }

        private void numEDB_ValueChanged(object sender, EventArgs e)
        {
            CleanPerformance();
        }

        private void numEWB_ValueChanged(object sender, EventArgs e)
        {
            CleanPerformance();
        }

        private void numAltitude_ValueChanged(object sender, EventArgs e)
        {
            CleanPerformance();
        }

        private void numConcentration_ValueChanged(object sender, EventArgs e)
        {
            CleanPerformance();
        }

        private void numELT_ValueChanged(object sender, EventArgs e)
        {
            CleanPerformance();
        }

        private void numLeavingLiquidTemperature_ValueChanged(object sender, EventArgs e)
        {
            CleanPerformance();
        }

        private void numUSGPM_ValueChanged(object sender, EventArgs e)
        {
            CleanPerformance();
        }

        private void cboNumberOfCircuits_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleanPerformance();
        }

        private void cboFPI_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillFinMaterial();
            FillCoilCoating();
            CleanPerformance();
        }
        
        private void cboFinMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleanPerformance();
        }

        private void CleanPerformance()
        {
            _latestSelection = new Coil.CoolingCoil();
            _backgroundCode.ClearPerformanceDisplay(lstResults);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FillFinMaterial()
        {
            _backgroundCode.FillFinMaterial(cboFinMaterial, cboModel, cboFPI, Public.DSDatabase.Tables["v_Evaporators"].Copy(), Public.DSDatabase.Tables["CoilFinType"].Copy(), Public.DSDatabase.Tables["CoilFinMaterial"].Copy(), Public.DSDatabase.Tables["v_CoilFinDefaults"].Copy());
        }

        private void FillCoilCoating()
        {
            _backgroundCode.FillCoilCoating(cboCoilCoating, cboModel, cboFPI, Public.DSDatabase.Tables["v_Evaporators"].Copy(), Public.DSDatabase.Tables["ElectroFinAdjustement"].Copy(), Public.DSDatabase.Tables["HeresiteSafety"].Copy(), Public.DSDatabase.Tables["CoilFinType"].Copy());
        }

       
    }
}