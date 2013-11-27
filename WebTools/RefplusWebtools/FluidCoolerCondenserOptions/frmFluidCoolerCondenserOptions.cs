using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.FluidCoolerCondenserOptions
{
    public partial class FrmFluidCoolerCondenserOptions : Form
    {
        private readonly string _strMotor = "";
        private readonly string _strAirFlowType = "";
        private readonly string _strFinType = "";
        private readonly decimal _decFPI;
        private readonly decimal _decNumberOfRows;
        private readonly decimal _decFinHeight;
        private readonly decimal _decFinLength;
        private readonly int _intFanWide = 1;
        private readonly int _intFanLong = 1;
        private readonly string _strCoilArr = "";
        private readonly bool _factoryInstalledReceiver;
        private readonly bool _shippedLooseReceiver;
        private readonly string _condenserType = "";
        private readonly decimal _biggestReceiverDiameter;
        private readonly bool _openFromQuote;

        private readonly string[] _strTableList = { "ElectroFinAdjustement", "HeresiteSafety", "FluidCoolerLegs", "CoilFinMaterial", "v_CoilFinDefaults", "CoilTubeMaterial", "v_CoilTubeDefaults", "CasingFinish", "CoilCasingMaterial", "LegLogic", "LegPrice1", "LegPrice2", "LegPrice3", "LegPrice4", "LegPrice5", "LegPrice6", "LegPrice7", "LegPrice8", "LegPrice9", "LegPrice10", "LegPrice11", "LegPrice12", "LegPrice13", "LegPrice14", "LegPrice15", "LegPrice16", "LegPrice17", "LegPrice18", "LegPrice19", "LegPrice20", "LegPrice21", "Legs" };
                       
        //will hold all value set in this form to show on the report (text value, price)
        private readonly DataTable _dtSecondaryOptions = Tables.DtSecondaryOptions();

        public enum OpenFrom { FluidCooler, Condenser };
        private readonly OpenFrom _of = OpenFrom.Condenser;
        private List<Leg> _legs = new List<Leg>();

        private string _legNomenclature = "";
        private bool _legInstalled;

        public FrmFluidCoolerCondenserOptions(OpenFrom of, string strMotor, string strAirFlowType, string strFinType, decimal decFPI, decimal decNumberOfRows, decimal decFinHeight, decimal decFinLength, int intFanWide, int intFanLong, string strCoilArr, bool factoryInstalledReceiver, bool shippedLooseReceiver, string condenserType, decimal biggestReceiverDiameter, bool openFromQuote)
        {
            InitializeComponent();
            _of = of;
            _strMotor = strMotor;
            _strAirFlowType = strAirFlowType;
            _strFinType = strFinType;
            _decFPI = decFPI;
            _decNumberOfRows = decNumberOfRows;
            _decFinHeight = decFinHeight;
            _decFinLength = decFinLength;
            _intFanWide = intFanWide;
            _intFanLong = intFanLong;
            _strCoilArr = strCoilArr;
            _factoryInstalledReceiver = factoryInstalledReceiver;
            _shippedLooseReceiver = shippedLooseReceiver;
            _condenserType = condenserType;
            _biggestReceiverDiameter = biggestReceiverDiameter;
            _openFromQuote = openFromQuote;
        }

        private void frmFluidCoolerCondenserOptions_Load(object sender, EventArgs e)
        {
            Public.ChangeColor(this);

            Public.ChangeFormLanguage(this);

            Query.LoadTables(_strTableList);

            Fill_Combobox();

            lblLegPrice.Visible = _openFromQuote;

            ThreadProcess.Stop();
            Focus();
        }

        private void Fill_Combobox()
        {
            Fill_FinMaterial();

            Fill_TubeMaterial();

            Fill_CoilCoating();

            //2010-08-04 : need to add back legs otherwise i can't build the nomenclature to get the proper drawing.
            Fill_Legs();

            Fill_CasingFinish();
        }

        public string GetLegNomenclature()
        {
            return _legNomenclature;
        }

        public bool GetLegInstalled()
        {
            return _legInstalled;
        }

        private string GetCasingFinishMaterial()
        {
            return Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilCasingMaterial"], "UniqueID = " + Convert.ToInt32(ComboBoxControl.ItemInformations(cboCasingFinish, Public.DSDatabase.Tables["CasingFinish"], "UniqueID")[0]["CoilCasingMaterialID"]), "").Rows[0]["CasingMaterial"].ToString();
        }

        //fill casing finish
        private void Fill_CasingFinish()
        {
            cboCasingFinish.Items.Clear();

            //these variable as use for easier modification of index or text showing
            //in the combobox

            //loop through all casing finish
            foreach (DataRow drCasingFinish in Public.DSDatabase.Tables["CasingFinish"].Rows)
            {
                string strIndex = drCasingFinish["UniqueID"].ToString();
                string strText = drCasingFinish["Description"].ToString();
                ComboBoxControl.AddItem(cboCasingFinish, strIndex, strText);
            }

            if (cboCasingFinish.Items.Count > 0)
            {
                cboCasingFinish.SelectedIndex = 0;
            }
        }

        //fill coil coating
        private void Fill_CoilCoating()
        {
            cboCoilCoating.Items.Clear();
            ComboBoxControl.AddItem(cboCoilCoating, "1", "None");
            ComboBoxControl.AddItem(cboCoilCoating, "2", "Blygold");

            if (Query.IsElectroFinAvailable(Public.DSDatabase.Tables["ElectroFinAdjustement"].Copy(), (int)_decNumberOfRows, (int)_decFPI))
            {//if i find a result in the ElectroFinAdjustement table that
                //match the fluid cooler selected
                ComboBoxControl.AddItem(cboCoilCoating, "3", "ElectroFin");
            }

            if (Query.IsHeresiteAvailable(Public.DSDatabase.Tables["HeresiteSafety"].Copy(), _decFinHeight, _decFinLength))
            {
                ComboBoxControl.AddItem(cboCoilCoating, "4", "Heresite");
            }

            if (cboCoilCoating.Items.Count > 0)
            {
                cboCoilCoating.SelectedIndex = 0;
            }
        }

        //fill legs
        private void Fill_Legs()
        {
            //2011-04-27 : the whole code is bad i made new one using the new logic as well.
            cboLegs.Items.Clear();

            string receiverType = "";

            receiverType += (_factoryInstalledReceiver ? "I" : "");
            receiverType += (_shippedLooseReceiver ? "SL" : "");
            receiverType += (!_factoryInstalledReceiver && !_shippedLooseReceiver ? "N" : "");

            var lc = new LegCode(
                (_of == OpenFrom.Condenser ? "COND" : "FC"),
                receiverType,
                _strAirFlowType,
                (_of == OpenFrom.Condenser ? _condenserType : "F") + _strMotor + _strCoilArr,
                _intFanWide,
                _intFanLong,
                _biggestReceiverDiameter);

            _legs = lc.GetListOfLegs();

            for (int i = 0; i < _legs.Count; i++)
            {
                ComboBoxControl.AddItem(cboLegs, _legs[i].LegID, _legs[i].Description);
            }

            ComboBoxControl.SetIDDefaultValue(cboLegs, lc.GetDefaultLeg());


            
        }

        private int FinMaterialID()
        {
            return Convert.ToInt32(ComboBoxControl.ItemInformations(cboFinMaterial, Public.DSDatabase.Tables["CoilFinMaterial"], "UniqueID")[0]["UniqueID"]);
        }

        //fill the fin material
        private void Fill_FinMaterial()
        {
            cboFinMaterial.Items.Clear();
            //these variable as use for easier modification of index or text showing
            //in the combobox
            //loop through all fin material
            foreach (DataRow drFinMaterial in Public.DSDatabase.Tables["CoilFinMaterial"].Rows)
            {
                //if we can found the fintype in the table that mean it's available for
                //the selected coil type so we can show it
                //2009-07-16: we were forcing 5 FPI, now they want ot use the real fpi
                if (IsFinMaterialAvailable(Public.DSDatabase.Tables["v_CoilFinDefaults"].Copy(), _strFinType,(int)_decFPI /*5*/, drFinMaterial["UniqueID"].ToString()))
                {
                    string strIndex = drFinMaterial["UniqueID"].ToString();
                    string strText = drFinMaterial["FinMaterial"].ToString();
                    ComboBoxControl.AddItem(cboFinMaterial, strIndex, strText);
                }
            }

            //select first if exist
            if (cboFinMaterial.Items.Count > 0)
            {
                cboFinMaterial.SelectedIndex = 0;
            }
        }

        private int TubeMaterialID()
        {
            return Convert.ToInt32(ComboBoxControl.ItemInformations(cboTubeMaterial, Public.DSDatabase.Tables["CoilTubeMaterial"], "UniqueID")[0]["UniqueID"]);
        }


        //fill tube material
        private void Fill_TubeMaterial()
        {
            cboTubeMaterial.Items.Clear();

            //these variable as use for easier modification of index or text showing
            //in the combobox

            DataTable dtTubeMaterial = Query.RemoveInactiveRecords(Public.DSDatabase.Tables["CoilTubeMaterial"].Copy());

            //for each material type
            foreach (DataRow drTubeMaterial in dtTubeMaterial.Rows)
            {
                //is tube material available for the following parameter
                if (IsTubeMaterialAvailable(Public.DSDatabase.Tables["v_CoilTubeDefaults"], "FH", _strFinType, drTubeMaterial["UniqueID"].ToString()))
                {
                    string strIndex = drTubeMaterial["UniqueID"].ToString();
                    string strText = drTubeMaterial["TubeMaterial"].ToString();
                    ComboBoxControl.AddItem(cboTubeMaterial, strIndex, strText);
                }
            }

            dtTubeMaterial.Dispose();

            //if there items in the list select the first
            if (cboTubeMaterial.Items.Count > 0)
            {
                cboTubeMaterial.SelectedIndex = 0;
            }

        }

        //is fin material available
        public bool IsFinMaterialAvailable(DataTable dtvCoilFinDefaults, string strFinType, int intFPI, string strFinMaterial)
        {
            //check is the fin material is available for the specific conditions
            return dtvCoilFinDefaults.Select("FinType = '" + strFinType + "' AND FinShape = 'C' AND FPI_MIN <= " + intFPI + " AND FPI_MAX >= " + intFPI + " AND FinMaterialID = " + strFinMaterial).Length > 0;
        }

        //is tube Material available
        public bool IsTubeMaterialAvailable(DataTable dtvCoilTubeDefaults, string strCoilType, string strFinType, string strTubeMaterial)
        {
            //check is the tube thickness is available for the specific conditions
            return dtvCoilTubeDefaults.Select("UniqueID = " + strTubeMaterial + " AND CoilType = '" + strCoilType + "' AND FinType = '" + strFinType + "'").Length > 0;
        }

        //fill all the input values into the table that will be used to show the report
        private void FillInputValues()
        {
            DataRow drCoatingAndMaterialFluidCoolerCondenser = _dtSecondaryOptions.NewRow();
            drCoatingAndMaterialFluidCoolerCondenser["QuoteID"] = 0;
            drCoatingAndMaterialFluidCoolerCondenser["QuoteRevision"] = 0;
            drCoatingAndMaterialFluidCoolerCondenser["QuoteRevisionText"] = "";
            drCoatingAndMaterialFluidCoolerCondenser["ItemType"] = 0;
            drCoatingAndMaterialFluidCoolerCondenser["ItemID"] = 0;
            drCoatingAndMaterialFluidCoolerCondenser["Username"] = "";

            var optionsPricing = new Pricing.FCOaccOptionsPricing();

            //2010-07-30 : Simon told us that the the price shall be standard on AL Fin and CU Tube
            //(following logic apply to Fin and Tube)
            //the problem is that we are using the coil of the condenser to find the standard thickness of the
            //selected material and then compare price to hardcoded default. this work with all
            //material excluding if Fin is AL or Tube is CU. so if AL is selected we will put 0$ else we get
            //the price difference. same goes for the tube, if it's CU we put 0$ else run the code.

            drCoatingAndMaterialFluidCoolerCondenser["FinMaterial"] = cboFinMaterial.Text;
            drCoatingAndMaterialFluidCoolerCondenser["FinMaterialPrice"] = (cboFinMaterial.Text == @"ALUMINIUM" ? 0m : optionsPricing.GetMaterialPrice(Public.DSDatabase.Tables["CoilFinMaterial"], Public.DSDatabase.Tables["CoilCasingMaterial"], Public.DSDatabase.Tables["CoilTubeMaterial"], Public.DSDatabase.Tables["V_CoilFinDefaults"], Public.DSDatabase.Tables["V_CoilTubeDefaults"], Pricing.FCOaccOptionsPricing.MaterialTypeToPrice.Fin, _strFinType, (int)_decFPI, _decNumberOfRows, _decFinHeight, _decFinLength, cboFinMaterial.Text, cboTubeMaterial.Text, GetCasingFinishMaterial(), FinMaterialID(), TubeMaterialID(), (_of == OpenFrom.FluidCooler), (_of == OpenFrom.Condenser), _condenserType));
            drCoatingAndMaterialFluidCoolerCondenser["TubeMaterial"] = cboTubeMaterial.Text;
            drCoatingAndMaterialFluidCoolerCondenser["TubeMaterialPrice"] = (cboTubeMaterial.Text == @"COPPER" ? 0m : optionsPricing.GetMaterialPrice(Public.DSDatabase.Tables["CoilFinMaterial"], Public.DSDatabase.Tables["CoilCasingMaterial"], Public.DSDatabase.Tables["CoilTubeMaterial"], Public.DSDatabase.Tables["V_CoilFinDefaults"], Public.DSDatabase.Tables["V_CoilTubeDefaults"], Pricing.FCOaccOptionsPricing.MaterialTypeToPrice.Tube, _strFinType, (int)_decFPI, _decNumberOfRows, _decFinHeight, _decFinLength, cboFinMaterial.Text, cboTubeMaterial.Text, GetCasingFinishMaterial(), FinMaterialID(), TubeMaterialID(), (_of == OpenFrom.FluidCooler), (_of == OpenFrom.Condenser), _condenserType));
            drCoatingAndMaterialFluidCoolerCondenser["CoilCoating"] = cboCoilCoating.Text;
            drCoatingAndMaterialFluidCoolerCondenser["CoilCoatingPrice"] = GetCoatingPrice();
            drCoatingAndMaterialFluidCoolerCondenser["CasingFinish"] = cboCasingFinish.Text;
            var casingFinishPrice = new Pricing.CasingFinishPricing();
            drCoatingAndMaterialFluidCoolerCondenser["CasingFinishPrice"] = casingFinishPrice.Price;

            //2011-04-27 : new leg logic require new code.
            drCoatingAndMaterialFluidCoolerCondenser["LegSize"] = _legs[cboLegs.SelectedIndex].LegSize;
            //2011-05-11 : added so i can retreive from the condenser form to build the drawing name
            _legNomenclature = _legs[cboLegs.SelectedIndex].Nomenclature;
            _legInstalled = _legs[cboLegs.SelectedIndex].LegID.Contains("I");
            drCoatingAndMaterialFluidCoolerCondenser["Legs"] = cboLegs.Text;
            drCoatingAndMaterialFluidCoolerCondenser["LegsPrice"] = _legs[cboLegs.SelectedIndex].Price;


            _dtSecondaryOptions.Rows.Add(drCoatingAndMaterialFluidCoolerCondenser);

        }

        private decimal GetCoatingPrice()
        {
            decimal decCoatingPrice = 0m;

            if (cboCoilCoating.Text == @"Blygold")
            {
                var coating = new Pricing.BlyGoldCoating(_strFinType, 1m, _decNumberOfRows, _decFPI, _decFinHeight, _decFinLength);
                decCoatingPrice = coating.Price;
            }
            else if (cboCoilCoating.Text == @"ElectroFin")
            {
                var coating = new Pricing.ElectroFinCoating(1m, _decNumberOfRows, _decFPI, _decFinHeight, _decFinLength);
                decCoatingPrice = coating.Price;
            }
            else if (cboCoilCoating.Text == @"Heresite")
            {
                var coating = new Pricing.HeresiteCoating(1m, _decNumberOfRows, _decFinHeight, _decFinLength);
                decCoatingPrice = coating.Price;
            }

            return decCoatingPrice;
        }

        //return the input table
        public DataTable SecondaryOptionsInput
        {
            get { return _dtSecondaryOptions; }
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            FillInputValues();

            Dispose();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFiles.Show(this);
        }

        private void frmFluidCoolerCondenserOptions_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            HelpFiles.Show(this);
        }

        private void cboLegs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLegs.SelectedIndex >= 0)
            {
                lblLegPrice.Text = _legs[cboLegs.SelectedIndex].Price.ToString("N2") + @" $";
            }
        }
    }
}