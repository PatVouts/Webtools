using System;
using System.Collections.Generic;
using System.Data;

namespace RefplusWebtools
{
    //return all table format
    class Tables
    {
        public static DataTable DtLanguage()
        {
            //create datatable
            var dtLanguage = new DataTable("Language");
            //add all columns
            dtLanguage.Columns.Add("LanguageID", typeof(int));
            dtLanguage.Columns.Add("Type", typeof(string));
            dtLanguage.Columns.Add("FormName", typeof(string));
            dtLanguage.Columns.Add("ControlName", typeof(string));
            dtLanguage.Columns.Add("Text", typeof(string));
            return dtLanguage;
        }

        public static DataTable DtQuickManualCoil()
        {
            //create datatable
            var dtQuickManualCoil = new DataTable("QuickManualCoil");
            //add columns

            dtQuickManualCoil.Columns.Add("QuoteID", typeof(int));
            dtQuickManualCoil.Columns.Add("QuoteRevision", typeof(int));
            dtQuickManualCoil.Columns.Add("QuoteRevisionText", typeof(string));
            dtQuickManualCoil.Columns.Add("ItemType", typeof(int));
            dtQuickManualCoil.Columns.Add("ItemID", typeof(int));
            dtQuickManualCoil.Columns.Add("Username", typeof(string));

            dtQuickManualCoil.Columns.Add("Tag", typeof(string));
            dtQuickManualCoil.Columns.Add("CoilModel", typeof(string));
            dtQuickManualCoil.Columns.Add("Input_ConnectionSide", typeof(string));
            dtQuickManualCoil.Columns.Add("Input_CasingMaterial", typeof(string));
            dtQuickManualCoil.Columns.Add("Input_CasingThickness", typeof(string));
            dtQuickManualCoil.Columns.Add("Quantity", typeof(int));
            dtQuickManualCoil.Columns.Add("Input_FinMaterial", typeof(string));
            dtQuickManualCoil.Columns.Add("Input_FinThickness", typeof(string));
            dtQuickManualCoil.Columns.Add("Input_TubeMaterial", typeof(string));
            dtQuickManualCoil.Columns.Add("Input_TubeThickness", typeof(string));
            dtQuickManualCoil.Columns.Add("Input_ConnectionType", typeof(string));
            dtQuickManualCoil.Columns.Add("Input_ConnectionSize", typeof(string));
            dtQuickManualCoil.Columns.Add("Input_CoilCoating", typeof(string));
            dtQuickManualCoil.Columns.Add("Input_Turbulator", typeof(string));
            //2012-04-24 : #2992 : adding the sample coil
            dtQuickManualCoil.Columns.Add("Input_SampleCoil", typeof(int));
            dtQuickManualCoil.Columns.Add("Price", typeof(decimal));
            dtQuickManualCoil.Columns.Add("CoatingPrice", typeof(decimal));
            dtQuickManualCoil.Columns.Add("TurbulatorPrice", typeof(decimal));

            return dtQuickManualCoil;
        }

        public static DataTable DtQuickCoil()
        {
            //create datatable
            var dtQuickCoil = new DataTable("QuickCoil");
            //add columns

            dtQuickCoil.Columns.Add("QuoteID", typeof(int));
            dtQuickCoil.Columns.Add("QuoteRevision", typeof(int));
            dtQuickCoil.Columns.Add("QuoteRevisionText", typeof(string));
            dtQuickCoil.Columns.Add("ItemType", typeof(int));
            dtQuickCoil.Columns.Add("ItemID", typeof(int));
            dtQuickCoil.Columns.Add("Username", typeof(string));

            dtQuickCoil.Columns.Add("CoilType", typeof(string));
            dtQuickCoil.Columns.Add("CoilModel", typeof(string));
            dtQuickCoil.Columns.Add("Tag", typeof(string));
            dtQuickCoil.Columns.Add("Quantity", typeof(int));
            dtQuickCoil.Columns.Add("CasingMaterial", typeof(string));
            dtQuickCoil.Columns.Add("CasingThickness", typeof(string));
            //dtQuickCoil.Columns.Add("HeaderDiameter", typeof(decimal));
            dtQuickCoil.Columns.Add("HeaderQuantity", typeof(int));
            dtQuickCoil.Columns.Add("ConnectionSide", typeof(string));
            dtQuickCoil.Columns.Add("ConstructionType", typeof(string));
            dtQuickCoil.Columns.Add("CoilCoating", typeof(string));
            dtQuickCoil.Columns.Add("DXRefrigerantType", typeof(string));
            dtQuickCoil.Columns.Add("DXAirFlowRate", typeof(decimal));
            dtQuickCoil.Columns.Add("DXEnteringDryBulb", typeof(decimal));
            dtQuickCoil.Columns.Add("DXEnteringWetBulb", typeof(decimal));
            dtQuickCoil.Columns.Add("DXFreshCFM", typeof(decimal));
            dtQuickCoil.Columns.Add("DXFreshEDB", typeof(decimal));
            dtQuickCoil.Columns.Add("DXFreshEWB", typeof(decimal));
            dtQuickCoil.Columns.Add("DXReturnCFM", typeof(decimal));
            dtQuickCoil.Columns.Add("DXReturnEDB", typeof(decimal));
            dtQuickCoil.Columns.Add("DXReturnEWB", typeof(decimal));
            dtQuickCoil.Columns.Add("DXSuctionTemperature", typeof(decimal));
            dtQuickCoil.Columns.Add("DXAltitude", typeof(decimal));
            dtQuickCoil.Columns.Add("DXLiquidTemp", typeof(decimal));
            dtQuickCoil.Columns.Add("DXNumberOfCircuit", typeof(string));
            dtQuickCoil.Columns.Add("DXConnectionSizeIn", typeof(decimal));
            dtQuickCoil.Columns.Add("DXConnectionSizeOut", typeof(decimal));
            dtQuickCoil.Columns.Add("HRRefrigerantType", typeof(string));
            dtQuickCoil.Columns.Add("HRAirFlowRate", typeof(decimal));
            dtQuickCoil.Columns.Add("HREnteringDryBulb", typeof(decimal));
            dtQuickCoil.Columns.Add("HRFreshCFM", typeof(decimal));
            dtQuickCoil.Columns.Add("HRFreshEDB", typeof(decimal));
            dtQuickCoil.Columns.Add("HRReturnCFM", typeof(decimal));
            dtQuickCoil.Columns.Add("HRReturnEDB", typeof(decimal));
            dtQuickCoil.Columns.Add("HRCondensingTemperature", typeof(decimal));
            dtQuickCoil.Columns.Add("HRSuctionTemperature", typeof(decimal));
            dtQuickCoil.Columns.Add("HRAltitude", typeof(decimal));
            dtQuickCoil.Columns.Add("HRNumberOfCircuit", typeof(string));
            dtQuickCoil.Columns.Add("HRCoilDesign", typeof(string));
            dtQuickCoil.Columns.Add("HRSubCooler", typeof(string));
            dtQuickCoil.Columns.Add("HRFaceTubes", typeof(decimal));
            dtQuickCoil.Columns.Add("HRCircuits", typeof(decimal));
            dtQuickCoil.Columns.Add("HRHeatRecovery", typeof(decimal));
            dtQuickCoil.Columns.Add("HRConnectionSizeIn", typeof(decimal));
            dtQuickCoil.Columns.Add("HRConnectionSizeOut", typeof(decimal));
            dtQuickCoil.Columns.Add("HRSubCoolerConnectionSizeIn", typeof(decimal));
            dtQuickCoil.Columns.Add("HRSubCoolerConnectionSizeOut", typeof(decimal));
            dtQuickCoil.Columns.Add("FCDesignType", typeof(string));
            dtQuickCoil.Columns.Add("FCConnectionType", typeof(string));
            dtQuickCoil.Columns.Add("FCConnectionSizeIn", typeof(decimal));
            dtQuickCoil.Columns.Add("FCConnectionSizeOut", typeof(decimal));
            dtQuickCoil.Columns.Add("FCAirFlowRate", typeof(decimal));
            dtQuickCoil.Columns.Add("FCEnteringDryBulb", typeof(decimal));
            dtQuickCoil.Columns.Add("FCEnteringWetBulb", typeof(decimal));
            dtQuickCoil.Columns.Add("FCFreshCFM", typeof(decimal));
            dtQuickCoil.Columns.Add("FCFreshEDB", typeof(decimal));
            dtQuickCoil.Columns.Add("FCFreshEWB", typeof(decimal));
            dtQuickCoil.Columns.Add("FCReturnCFM", typeof(decimal));
            dtQuickCoil.Columns.Add("FCReturnEDB", typeof(decimal));
            dtQuickCoil.Columns.Add("FCReturnEWB", typeof(decimal));
            dtQuickCoil.Columns.Add("FCEnteringLiquidTemperature", typeof(decimal));
            dtQuickCoil.Columns.Add("FCAltitude", typeof(decimal));
            dtQuickCoil.Columns.Add("FCFluidType", typeof(string));
            dtQuickCoil.Columns.Add("FCConcentration", typeof(decimal));
            dtQuickCoil.Columns.Add("FCUSGPM", typeof(decimal));
            dtQuickCoil.Columns.Add("FCLeavingLiquidTemperature", typeof(decimal));
            dtQuickCoil.Columns.Add("FCNumberOfCircuits", typeof(string));
            dtQuickCoil.Columns.Add("FCMaxPressure", typeof(decimal));
            //new columns
            dtQuickCoil.Columns.Add("FCFluidTypeName", typeof(string));
            dtQuickCoil.Columns.Add("FCSpecificHeat", typeof(decimal));
            dtQuickCoil.Columns.Add("FCDensity", typeof(decimal));
            dtQuickCoil.Columns.Add("FCViscosity", typeof(decimal));
            dtQuickCoil.Columns.Add("FCThermalConductivity", typeof(decimal));

            dtQuickCoil.Columns.Add("STEAMSteamCoilType", typeof(string));
            dtQuickCoil.Columns.Add("STEAMConnectionType", typeof(string));
            dtQuickCoil.Columns.Add("STEAMCondensateConnection", typeof(string));
            dtQuickCoil.Columns.Add("STEAMSteamConnection", typeof(string));
            dtQuickCoil.Columns.Add("STEAMAirFlowRate", typeof(decimal));
            dtQuickCoil.Columns.Add("STEAMEnteringDryBulb", typeof(decimal));
            dtQuickCoil.Columns.Add("STEAMFreshCFM", typeof(decimal));
            dtQuickCoil.Columns.Add("STEAMFreshEDB", typeof(decimal));
            dtQuickCoil.Columns.Add("STEAMReturnCFM", typeof(decimal));
            dtQuickCoil.Columns.Add("STEAMReturnEDB", typeof(decimal));
            dtQuickCoil.Columns.Add("STEAMSaturatedSteamPressure", typeof(decimal));
            dtQuickCoil.Columns.Add("STEAMAltitude", typeof(decimal));
            dtQuickCoil.Columns.Add("FHDesignType", typeof(string));
            dtQuickCoil.Columns.Add("FHConnectionType", typeof(string));
            dtQuickCoil.Columns.Add("FHConnectionSizeIn", typeof(decimal));
            dtQuickCoil.Columns.Add("FHConnectionSizeOut", typeof(decimal));
            dtQuickCoil.Columns.Add("FHAirFlowRate", typeof(decimal));
            dtQuickCoil.Columns.Add("FHEnteringDryBulb", typeof(decimal));
            dtQuickCoil.Columns.Add("FHFreshCFM", typeof(decimal));
            dtQuickCoil.Columns.Add("FHFreshEDB", typeof(decimal));
            dtQuickCoil.Columns.Add("FHReturnCFM", typeof(decimal));
            dtQuickCoil.Columns.Add("FHReturnEDB", typeof(decimal));
            dtQuickCoil.Columns.Add("FHEnteringLiquidTemperature", typeof(decimal));
            dtQuickCoil.Columns.Add("FHAltitude", typeof(decimal));
            dtQuickCoil.Columns.Add("FHFluidType", typeof(string));
            dtQuickCoil.Columns.Add("FHConcentration", typeof(decimal));
            dtQuickCoil.Columns.Add("FHUSGPM", typeof(decimal));
            dtQuickCoil.Columns.Add("FHLeavingLiquidTemperature", typeof(decimal));
            dtQuickCoil.Columns.Add("FHNumberOfCircuit", typeof(string));
            dtQuickCoil.Columns.Add("FHMaxPressure", typeof(decimal));
            //new columns
            dtQuickCoil.Columns.Add("FHFluidTypeName", typeof(string));
            dtQuickCoil.Columns.Add("FHSpecificHeat", typeof(decimal));
            dtQuickCoil.Columns.Add("FHDensity", typeof(decimal));
            dtQuickCoil.Columns.Add("FHViscosity", typeof(decimal));
            dtQuickCoil.Columns.Add("FHThermalConductivity", typeof(decimal));

            dtQuickCoil.Columns.Add("FinType", typeof(string));
            dtQuickCoil.Columns.Add("FinTypeText", typeof(string));
            dtQuickCoil.Columns.Add("TubeDiameter", typeof(decimal));
            dtQuickCoil.Columns.Add("FaceTube", typeof(decimal));
            dtQuickCoil.Columns.Add("TubeRow", typeof(decimal));
            dtQuickCoil.Columns.Add("TubeDiagonal", typeof(decimal));
            dtQuickCoil.Columns.Add("FinShape", typeof(string));
            dtQuickCoil.Columns.Add("FinShapeText", typeof(string));
            dtQuickCoil.Columns.Add("TubeType", typeof(string));
            dtQuickCoil.Columns.Add("Turbulators", typeof(string));
            dtQuickCoil.Columns.Add("FinHeight", typeof(decimal));
            dtQuickCoil.Columns.Add("FinLength", typeof(decimal));
            dtQuickCoil.Columns.Add("Row", typeof(decimal));
            dtQuickCoil.Columns.Add("FPI", typeof(decimal));
            dtQuickCoil.Columns.Add("TubeMaterial", typeof(string));
            dtQuickCoil.Columns.Add("TubeMaterialText", typeof(string));
            dtQuickCoil.Columns.Add("TubeThickness", typeof(string));
            dtQuickCoil.Columns.Add("FinMaterial", typeof(string));
            dtQuickCoil.Columns.Add("FinMaterialText", typeof(string));
            dtQuickCoil.Columns.Add("FinThickness", typeof(string));
            dtQuickCoil.Columns.Add("CasingDensity", typeof(decimal));
            dtQuickCoil.Columns.Add("CasingPricePerLbs", typeof(decimal));
            dtQuickCoil.Columns.Add("FinDensity", typeof(decimal));
            dtQuickCoil.Columns.Add("FinPricePerLbs", typeof(decimal));
            dtQuickCoil.Columns.Add("TubeDensity", typeof(decimal));
            dtQuickCoil.Columns.Add("TubePricePerLbs", typeof(decimal));
            dtQuickCoil.Columns.Add("Weight", typeof(decimal));
            //R_ is a prefix for return values
            dtQuickCoil.Columns.Add("R_Rows", typeof(decimal));
            dtQuickCoil.Columns.Add("R_Circuiting", typeof(decimal));
            dtQuickCoil.Columns.Add("R_NumberOfCircuits", typeof(decimal));
            dtQuickCoil.Columns.Add("R_FPI", typeof(decimal));
            dtQuickCoil.Columns.Add("R_CoilFaceArea", typeof(decimal));
            dtQuickCoil.Columns.Add("R_FaceVelocity", typeof(decimal));
            dtQuickCoil.Columns.Add("R_AirPressureDrop", typeof(decimal));
            dtQuickCoil.Columns.Add("R_LeavingDryBulb", typeof(decimal));
            dtQuickCoil.Columns.Add("R_LeavingWetBulb", typeof(decimal));
            dtQuickCoil.Columns.Add("R_TotalHeat", typeof(decimal));
            dtQuickCoil.Columns.Add("R_SensibleHeat", typeof(decimal));
            dtQuickCoil.Columns.Add("R_LeavingLiquidTemperature", typeof(decimal));
            dtQuickCoil.Columns.Add("R_CircuitLoad", typeof(decimal));
            dtQuickCoil.Columns.Add("R_RefrigerantPressureDrop", typeof(decimal));
            dtQuickCoil.Columns.Add("R_RefrigerantPressureDropPerDegree", typeof(decimal));
            dtQuickCoil.Columns.Add("R_FaceTube", typeof(decimal));
            dtQuickCoil.Columns.Add("R_SteamConsumption", typeof(decimal));
            dtQuickCoil.Columns.Add("R_SteamTemperature", typeof(decimal));
            dtQuickCoil.Columns.Add("R_SubCoolerCapacity", typeof(decimal));
            dtQuickCoil.Columns.Add("R_SubCoolerRefrigerantLeavingTemperature", typeof(decimal));
            dtQuickCoil.Columns.Add("R_SubCoolerPressureDrop", typeof(decimal));
            dtQuickCoil.Columns.Add("R_ConnectionSize", typeof(decimal));
            dtQuickCoil.Columns.Add("R_GPM", typeof(decimal));
            dtQuickCoil.Columns.Add("R_WaterVelocity", typeof(decimal));
            dtQuickCoil.Columns.Add("R_ARI_STANDARD", typeof(string));
            dtQuickCoil.Columns.Add("FHFreezeStat", typeof(decimal));
            dtQuickCoil.Columns.Add("CoilPrice", typeof(decimal));
            dtQuickCoil.Columns.Add("CoatingPrice", typeof(decimal));
            dtQuickCoil.Columns.Add("TurbulatorPrice", typeof(decimal));
            dtQuickCoil.Columns.Add("Input_CoilType", typeof(string));
            dtQuickCoil.Columns.Add("Input_ConstructionType", typeof(string));
            dtQuickCoil.Columns.Add("Input_Location", typeof(string));
            dtQuickCoil.Columns.Add("Input_ConnectionSide", typeof(string));
            dtQuickCoil.Columns.Add("Input_CasingMaterial", typeof(string));
            dtQuickCoil.Columns.Add("Input_CasingThickness", typeof(string));
            dtQuickCoil.Columns.Add("Input_DX_RefrigerantType", typeof(string));
            dtQuickCoil.Columns.Add("Input_DX_ConnectionSizeInlet", typeof(string));
            dtQuickCoil.Columns.Add("Input_DX_ConnectionSizeOutlet", typeof(string));
            dtQuickCoil.Columns.Add("Input_DX_HeaderQuantity", typeof(string));
            dtQuickCoil.Columns.Add("Input_HR_CoilDesign", typeof(string));
            dtQuickCoil.Columns.Add("Input_HR_ConnectionSizeInlet", typeof(string));
            dtQuickCoil.Columns.Add("Input_HR_ConnectionSizeOutlet", typeof(string));
            dtQuickCoil.Columns.Add("Input_HR_HeaderQuantity", typeof(string));
            dtQuickCoil.Columns.Add("Input_HR_SubCoolerConnIn", typeof(string));
            dtQuickCoil.Columns.Add("Input_HR_SubCoolerConnOut", typeof(string));
            dtQuickCoil.Columns.Add("Input_FH_DesignType", typeof(string));
            dtQuickCoil.Columns.Add("Input_FH_ConnectionSize", typeof(string));
            dtQuickCoil.Columns.Add("Input_FH_HeaderQuantity", typeof(string));
            dtQuickCoil.Columns.Add("Input_FH_GPM_LLT", typeof(string));
            dtQuickCoil.Columns.Add("Input_FC_DesignType", typeof(string));
            dtQuickCoil.Columns.Add("Input_FC_ConnectionSize", typeof(string));
            dtQuickCoil.Columns.Add("Input_FC_HeaderQuantity", typeof(string));
            dtQuickCoil.Columns.Add("Input_FC_GPM_LLT", typeof(string));
            dtQuickCoil.Columns.Add("Input_STEAM_TubeOrientation", typeof(string));
            dtQuickCoil.Columns.Add("FHFreezing", typeof(decimal));
            dtQuickCoil.Columns.Add("FCFreezing", typeof(decimal));
            
            dtQuickCoil.Columns.Add("GCAirFlowRate", typeof(decimal));
            dtQuickCoil.Columns.Add("GCAltitude", typeof(decimal));
            dtQuickCoil.Columns.Add("GCEnteringDryBulb", typeof(decimal));
            
            dtQuickCoil.Columns.Add("GCGIN", typeof(decimal));
            dtQuickCoil.Columns.Add("GCGFLO", typeof(decimal));
            dtQuickCoil.Columns.Add("GCGPSI", typeof(decimal));
            dtQuickCoil.Columns.Add("GCNumberOfCircuits", typeof(string));
            dtQuickCoil.Columns.Add("R_GOUT", typeof(decimal));
            return dtQuickCoil;
        }

        public static DataTable DtCondensingUnitWaterCooledCondensers()
        {
            //create datatable
            var dtCondensingUnitWaterCooledCondenser = new DataTable("CondensingUnitWaterCooledCondenser");
            //add columns
            dtCondensingUnitWaterCooledCondenser.Columns.Add("QuoteID", typeof(int));
            dtCondensingUnitWaterCooledCondenser.Columns.Add("QuoteRevision", typeof(int));
            dtCondensingUnitWaterCooledCondenser.Columns.Add("QuoteRevisionText", typeof(string));
            dtCondensingUnitWaterCooledCondenser.Columns.Add("ItemType", typeof(int));
            dtCondensingUnitWaterCooledCondenser.Columns.Add("ItemID", typeof(int));
            dtCondensingUnitWaterCooledCondenser.Columns.Add("Username", typeof(string));

            dtCondensingUnitWaterCooledCondenser.Columns.Add("WaterCooledNumber", typeof(int));
            dtCondensingUnitWaterCooledCondenser.Columns.Add("WaterCooledModel", typeof(string));
            dtCondensingUnitWaterCooledCondenser.Columns.Add("PumpDownCapacity", typeof(decimal));
           
            return dtCondensingUnitWaterCooledCondenser;
        }

        public static DataTable DtCondensingUnitCompressors()
        {
            //create datatable
            var dtCondensingUnitCompressor = new DataTable("CondensingUnitCompressorReceiver");
            //add columns
            dtCondensingUnitCompressor.Columns.Add("QuoteID", typeof(int));
            dtCondensingUnitCompressor.Columns.Add("QuoteRevision", typeof(int));
            dtCondensingUnitCompressor.Columns.Add("QuoteRevisionText", typeof(string));
            dtCondensingUnitCompressor.Columns.Add("ItemType", typeof(int));
            dtCondensingUnitCompressor.Columns.Add("ItemID", typeof(int));
            dtCondensingUnitCompressor.Columns.Add("Username", typeof(string));

            dtCondensingUnitCompressor.Columns.Add("CompressorNumber", typeof(int));
            dtCondensingUnitCompressor.Columns.Add("CompressorModel", typeof(string));
            dtCondensingUnitCompressor.Columns.Add("VoltageID", typeof(int));
            dtCondensingUnitCompressor.Columns.Add("RefrigerantID", typeof(int));
            dtCondensingUnitCompressor.Columns.Add("RLA", typeof(decimal));
            dtCondensingUnitCompressor.Columns.Add("LRA", typeof(decimal));
            dtCondensingUnitCompressor.Columns.Add("SinglePhaseTandem", typeof(int));
            dtCondensingUnitCompressor.Columns.Add("Liquid", typeof(decimal));
            dtCondensingUnitCompressor.Columns.Add("Suction", typeof(decimal));
            dtCondensingUnitCompressor.Columns.Add("Discharge", typeof(decimal));
            dtCondensingUnitCompressor.Columns.Add("LiquidText", typeof(string));
            dtCondensingUnitCompressor.Columns.Add("SuctionText", typeof(string));
            dtCondensingUnitCompressor.Columns.Add("DischargeText", typeof(string));
            dtCondensingUnitCompressor.Columns.Add("ReceiverModel", typeof(string));
            dtCondensingUnitCompressor.Columns.Add("CoilCapacityRatio", typeof(decimal));
            dtCondensingUnitCompressor.Columns.Add("ReceiverPumpDownCapacity", typeof(decimal));

            return dtCondensingUnitCompressor;
        }

        public static DataTable DtCondensingUnitOptions()
        {
            //create datatable
            var dtCondensingUnitOption = new DataTable("CondensingUnitOption");
            //add columns
            dtCondensingUnitOption.Columns.Add("QuoteID", typeof(int));
            dtCondensingUnitOption.Columns.Add("QuoteRevision", typeof(int));
            dtCondensingUnitOption.Columns.Add("QuoteRevisionText", typeof(string));
            dtCondensingUnitOption.Columns.Add("ItemType", typeof(int));
            dtCondensingUnitOption.Columns.Add("ItemID", typeof(int));
            dtCondensingUnitOption.Columns.Add("Username", typeof(string));

            dtCondensingUnitOption.Columns.Add("GroupName", typeof(string));
            dtCondensingUnitOption.Columns.Add("Description", typeof(string));
            dtCondensingUnitOption.Columns.Add("Price", typeof(decimal));

            return dtCondensingUnitOption;
        }

        public static DataTable DtCondensingUnit()
        {
            //create datatable
            var dtCondensingUnit = new DataTable("CondensingUnit");
            //add columns
            dtCondensingUnit.Columns.Add("QuoteID", typeof(int));
            dtCondensingUnit.Columns.Add("QuoteRevision", typeof(int));
            dtCondensingUnit.Columns.Add("QuoteRevisionText", typeof(string));
            dtCondensingUnit.Columns.Add("ItemType", typeof(int));
            dtCondensingUnit.Columns.Add("ItemID", typeof(int));
            dtCondensingUnit.Columns.Add("Username", typeof(string));

            dtCondensingUnit.Columns.Add("Input_Tag", typeof(string));
            dtCondensingUnit.Columns.Add("Quantity", typeof(int));
            dtCondensingUnit.Columns.Add("Input_Filter", typeof(string));
            dtCondensingUnit.Columns.Add("Input_Model", typeof(string));
            dtCondensingUnit.Columns.Add("Input_Type", typeof(string));
            dtCondensingUnit.Columns.Add("Input_CompressorType", typeof(string));
            dtCondensingUnit.Columns.Add("Input_CompressorManufacturer", typeof(string));
            dtCondensingUnit.Columns.Add("Input_NumberOfCompressor", typeof(string));
            dtCondensingUnit.Columns.Add("Input_Refrigerant", typeof(string));
            dtCondensingUnit.Columns.Add("Input_Capacity", typeof(decimal));
            dtCondensingUnit.Columns.Add("Input_CapacityRange", typeof(string));
            dtCondensingUnit.Columns.Add("Input_SST", typeof(decimal));
            dtCondensingUnit.Columns.Add("Input_Balancing", typeof(decimal));
            dtCondensingUnit.Columns.Add("Input_Voltage", typeof(string));
            dtCondensingUnit.Columns.Add("Input_CoilCoating", typeof(string));
            dtCondensingUnit.Columns.Add("Input_FinMaterial", typeof(string));

            //model
            dtCondensingUnit.Columns.Add("Model", typeof(string));
            dtCondensingUnit.Columns.Add("UnitType", typeof(string));
            dtCondensingUnit.Columns.Add("AirFlow", typeof(string));
            dtCondensingUnit.Columns.Add("CompressorType", typeof(string));
            dtCondensingUnit.Columns.Add("CompressorTypeText", typeof(string));
            dtCondensingUnit.Columns.Add("CompressorManufacturer", typeof(int));
            dtCondensingUnit.Columns.Add("CompressorManufacturerText", typeof(string));
            dtCondensingUnit.Columns.Add("Application", typeof(string));
            dtCondensingUnit.Columns.Add("ApplicationText", typeof(string));
            dtCondensingUnit.Columns.Add("RefrigerantID", typeof(int));
            dtCondensingUnit.Columns.Add("VoltageID", typeof(int));
            dtCondensingUnit.Columns.Add("HP", typeof(decimal));
            dtCondensingUnit.Columns.Add("Price", typeof(decimal));
            dtCondensingUnit.Columns.Add("Weight", typeof(decimal));
            dtCondensingUnit.Columns.Add("NumberOfCompressor", typeof(int));
            dtCondensingUnit.Columns.Add("MinBalancing", typeof(int));
            dtCondensingUnit.Columns.Add("MaxBalancing", typeof(int));
            dtCondensingUnit.Columns.Add("MinSST", typeof(int));
            dtCondensingUnit.Columns.Add("MaxSST", typeof(int));
            dtCondensingUnit.Columns.Add("FinMaterialPrice", typeof(decimal));
            dtCondensingUnit.Columns.Add("CoilCoatingPrice", typeof(decimal));
            dtCondensingUnit.Columns.Add("MCA", typeof(decimal));
            dtCondensingUnit.Columns.Add("MOP", typeof(decimal));
            dtCondensingUnit.Columns.Add("FUSE", typeof(decimal));
            dtCondensingUnit.Columns.Add("RefrigerantSummerCharge", typeof(decimal));
            dtCondensingUnit.Columns.Add("RefrigerantWinterCharge", typeof(decimal));
            dtCondensingUnit.Columns.Add("UnitCapacity", typeof(decimal));
            dtCondensingUnit.Columns.Add("UnitDrawing", typeof(string));
            dtCondensingUnit.Columns.Add("ElectricalDrawing", typeof(string));

            //coil
            dtCondensingUnit.Columns.Add("CoilModel", typeof(string));
            dtCondensingUnit.Columns.Add("CFM", typeof(decimal));
            dtCondensingUnit.Columns.Add("CoilType", typeof(string));
            dtCondensingUnit.Columns.Add("FinType", typeof(string));
            dtCondensingUnit.Columns.Add("FinShape", typeof(string));
            dtCondensingUnit.Columns.Add("Tubes", typeof(int));
            dtCondensingUnit.Columns.Add("Row", typeof(int));
            dtCondensingUnit.Columns.Add("FPI", typeof(int));
            dtCondensingUnit.Columns.Add("Circuit", typeof(int));
            dtCondensingUnit.Columns.Add("FinHeight", typeof(decimal));
            dtCondensingUnit.Columns.Add("FinLength", typeof(decimal));
            dtCondensingUnit.Columns.Add("FinMaterial", typeof(string));
            dtCondensingUnit.Columns.Add("FinMaterialParameter", typeof(string));
            dtCondensingUnit.Columns.Add("FinThickness", typeof(decimal));
            dtCondensingUnit.Columns.Add("TubeMaterial", typeof(string));
            dtCondensingUnit.Columns.Add("TubeMaterialParameter", typeof(string));
            dtCondensingUnit.Columns.Add("TubeThickness", typeof(decimal));
            dtCondensingUnit.Columns.Add("FanWide", typeof(int));
            dtCondensingUnit.Columns.Add("FanLong", typeof(int));
            dtCondensingUnit.Columns.Add("MotorModel", typeof(string));
            dtCondensingUnit.Columns.Add("MotorMountModel", typeof(string));
            dtCondensingUnit.Columns.Add("FanModel", typeof(string));
            dtCondensingUnit.Columns.Add("FanGuardModel", typeof(string));

            //motor
            dtCondensingUnit.Columns.Add("MotorHP", typeof(decimal));
            dtCondensingUnit.Columns.Add("MotorRPM", typeof(decimal));
            dtCondensingUnit.Columns.Add("MotorRotType", typeof(string));
            dtCondensingUnit.Columns.Add("MotorFrameType", typeof(string));
            dtCondensingUnit.Columns.Add("MotorShaftLength", typeof(decimal));
            dtCondensingUnit.Columns.Add("MotorPrice", typeof(decimal));
            dtCondensingUnit.Columns.Add("MotorFLA", typeof(decimal));

            //motor mount
            dtCondensingUnit.Columns.Add("MotorMountFanSize", typeof(decimal));
            dtCondensingUnit.Columns.Add("MotorMountFrameSize", typeof(decimal));
            dtCondensingUnit.Columns.Add("MotorMountComposition", typeof(string));
            dtCondensingUnit.Columns.Add("MotorMountPrice", typeof(decimal));

            //fan
            dtCondensingUnit.Columns.Add("FanDiameter", typeof(decimal));
            dtCondensingUnit.Columns.Add("FanBladeQuantity", typeof(int));
            dtCondensingUnit.Columns.Add("FanRotationType", typeof(string));
            dtCondensingUnit.Columns.Add("FanComposition", typeof(string));
            dtCondensingUnit.Columns.Add("FanPitch", typeof(decimal));
            dtCondensingUnit.Columns.Add("FanPrice", typeof(decimal));

            //fan guard
            dtCondensingUnit.Columns.Add("FanGuardFanSize", typeof(decimal));
            dtCondensingUnit.Columns.Add("FanGuardComposition", typeof(string));
            dtCondensingUnit.Columns.Add("FanGuardPrice", typeof(decimal));

            return dtCondensingUnit;
        }

        public static DataTable DtCondenserRefrigerantCircuits()
        {
            //create datatable
            var dtCondenserRefrigerantCircuits = new DataTable("RefrigerantCircuits");
            //add columns

            dtCondenserRefrigerantCircuits.Columns.Add("QuoteID", typeof(int));
            dtCondenserRefrigerantCircuits.Columns.Add("QuoteRevision", typeof(int));
            dtCondenserRefrigerantCircuits.Columns.Add("QuoteRevisionText", typeof(string));
            dtCondenserRefrigerantCircuits.Columns.Add("ItemType", typeof(int));
            dtCondenserRefrigerantCircuits.Columns.Add("ItemID", typeof(int));
            dtCondenserRefrigerantCircuits.Columns.Add("Username", typeof(string));

            dtCondenserRefrigerantCircuits.Columns.Add("RefrigerantType", typeof(string));
            dtCondenserRefrigerantCircuits.Columns.Add("CondenserTemperature", typeof(decimal));
            dtCondenserRefrigerantCircuits.Columns.Add("THR", typeof(decimal));
            dtCondenserRefrigerantCircuits.Columns.Add("RefrigerantMultiplier", typeof(decimal));
            dtCondenserRefrigerantCircuits.Columns.Add("CircuitType", typeof(string));
            dtCondenserRefrigerantCircuits.Columns.Add("NonConvertedTHR", typeof(decimal));
            dtCondenserRefrigerantCircuits.Columns.Add("CompressorType", typeof(string));
            dtCondenserRefrigerantCircuits.Columns.Add("SST", typeof(decimal));
            dtCondenserRefrigerantCircuits.Columns.Add("TD", typeof(decimal));
            dtCondenserRefrigerantCircuits.Columns.Add("THR_PER_TD", typeof(decimal));
            dtCondenserRefrigerantCircuits.Columns.Add("Circ_Capacity", typeof(decimal));
            dtCondenserRefrigerantCircuits.Columns.Add("Circ_Quantity", typeof(int));
            dtCondenserRefrigerantCircuits.Columns.Add("Circ_Quantity_Total", typeof(int));
            dtCondenserRefrigerantCircuits.Columns.Add("AltitudeAdjustment", typeof(decimal)); 
            dtCondenserRefrigerantCircuits.Columns.Add("HertzAdjustment", typeof(decimal));
            dtCondenserRefrigerantCircuits.Columns.Add("AmbientTemperature", typeof(decimal));
            dtCondenserRefrigerantCircuits.Columns.Add("Calculated", typeof(decimal));
            dtCondenserRefrigerantCircuits.Columns.Add("Inlet", typeof(decimal));
            dtCondenserRefrigerantCircuits.Columns.Add("Outlet", typeof(decimal));

            return dtCondenserRefrigerantCircuits;
        }

        public static DataTable DtHeatPipe()
        {
            //create datatable
            var dtHeatPipe = new DataTable("HeatPipeXSD");
            dtHeatPipe.Columns.Add("AirFlowSupply", typeof(decimal));
            dtHeatPipe.Columns.Add("AirFlowExhaust", typeof(decimal));
            dtHeatPipe.Columns.Add("Symmetrical", typeof(string));
            dtHeatPipe.Columns.Add("Altitude", typeof(decimal));
            dtHeatPipe.Columns.Add("OADB", typeof(decimal));
            dtHeatPipe.Columns.Add("OAWB", typeof(decimal));
            dtHeatPipe.Columns.Add("OARH", typeof(decimal));
            dtHeatPipe.Columns.Add("RADB", typeof(decimal));
            dtHeatPipe.Columns.Add("RAWB", typeof(decimal));
            dtHeatPipe.Columns.Add("RARH", typeof(decimal));
            dtHeatPipe.Columns.Add("FinType", typeof(string));
            dtHeatPipe.Columns.Add("FinHeight", typeof(decimal));
            dtHeatPipe.Columns.Add("FinLength", typeof(decimal));
            dtHeatPipe.Columns.Add("FPI", typeof(decimal));
            dtHeatPipe.Columns.Add("Rows", typeof(decimal));
            dtHeatPipe.Columns.Add("Shape", typeof(string));
            dtHeatPipe.Columns.Add("AtmosphericPressure", typeof(decimal));
            dtHeatPipe.Columns.Add("FlowType", typeof(string));
            dtHeatPipe.Columns.Add("TiltAngle", typeof(decimal));
            dtHeatPipe.Columns.Add("DefrostSetPoint", typeof(decimal));
            //following are return values
            dtHeatPipe.Columns.Add("R_FaceTubes", typeof(Int16));
            dtHeatPipe.Columns.Add("R_FinLength", typeof(decimal));
            dtHeatPipe.Columns.Add("R_AirFlowVelocity", typeof(decimal));
            dtHeatPipe.Columns.Add("R_FinLengthOnSupplySide", typeof(decimal));
            dtHeatPipe.Columns.Add("R_FinLengthOnReturnSide", typeof(decimal));
            dtHeatPipe.Columns.Add("R_FPI", typeof(Int16));
            dtHeatPipe.Columns.Add("R_NumberOfRows", typeof(Int16));
            dtHeatPipe.Columns.Add("R_OutsideAirDryBulb", typeof(decimal));
            dtHeatPipe.Columns.Add("R_ReturnAirDryBulb", typeof(decimal));
            dtHeatPipe.Columns.Add("R_SupplyDryBulb", typeof(decimal));
            dtHeatPipe.Columns.Add("R_ReturnDryBulb", typeof(decimal));
            dtHeatPipe.Columns.Add("R_OutsideAirRelativeHumidity", typeof(decimal));
            dtHeatPipe.Columns.Add("R_Coating", typeof(bool));
            dtHeatPipe.Columns.Add("R_DefrostSetPoint", typeof(decimal));
            dtHeatPipe.Columns.Add("R_Symmetrical", typeof(bool));
            dtHeatPipe.Columns.Add("R_Altitude", typeof(decimal));
            dtHeatPipe.Columns.Add("R_Weight", typeof(decimal));
            dtHeatPipe.Columns.Add("R_HeatPipeCapacity", typeof(decimal));
            dtHeatPipe.Columns.Add("R_Condensate", typeof(decimal));
            dtHeatPipe.Columns.Add("R_PressureDropExhaustSide", typeof(decimal));
            dtHeatPipe.Columns.Add("R_SensibleEffectiveness", typeof(decimal));
            dtHeatPipe.Columns.Add("R_LatentEffectiveness", typeof(decimal));
            dtHeatPipe.Columns.Add("R_TotalEffectiveness", typeof(decimal));
            dtHeatPipe.Columns.Add("R_SensibleCoolingCoilEffectiveness", typeof(decimal));
            dtHeatPipe.Columns.Add("R_TotalCoolingCoilEffectiveness", typeof(decimal));
            dtHeatPipe.Columns.Add("R_ExhaustAirRelativeHumidity", typeof(decimal));
            dtHeatPipe.Columns.Add("R_SupplyAirRelativeHumidity", typeof(decimal));
            dtHeatPipe.Columns.Add("R_AirFlowExhaust", typeof(decimal));
            dtHeatPipe.Columns.Add("R_AirFlowSupply", typeof(decimal));
            dtHeatPipe.Columns.Add("R_ReturnAirRelativeHumidity", typeof(decimal));
            dtHeatPipe.Columns.Add("R_FinsIndex", typeof(Int16));
            dtHeatPipe.Columns.Add("R_PressureDropSupplySide", typeof(decimal));
            dtHeatPipe.Columns.Add("R_OutsideAirWetBulb", typeof(decimal));
            dtHeatPipe.Columns.Add("R_ReturnAirWetBulb", typeof(decimal));
            dtHeatPipe.Columns.Add("R_ReturnWetBulb", typeof(decimal));
            dtHeatPipe.Columns.Add("R_SupplyWetBulb", typeof(decimal));
            dtHeatPipe.Columns.Add("R_OutsideAirGrains", typeof(decimal));
            dtHeatPipe.Columns.Add("R_ReturnAirGrains", typeof(decimal));
            dtHeatPipe.Columns.Add("R_ReturnGrains", typeof(decimal));
            dtHeatPipe.Columns.Add("R_SupplyGrains", typeof(decimal));
            dtHeatPipe.Columns.Add("R_OutsideAirEnthalpy", typeof(decimal));
            dtHeatPipe.Columns.Add("R_ReturnAirEnthalpy", typeof(decimal));
            dtHeatPipe.Columns.Add("R_ReturnEnthalpy", typeof(decimal));
            dtHeatPipe.Columns.Add("R_SupplyEnthalpy", typeof(decimal));
            dtHeatPipe.Columns.Add("R_MixingAirFlowSupplyTemperature", typeof(decimal));
            dtHeatPipe.Columns.Add("R_Shape", typeof(bool));
            dtHeatPipe.Columns.Add("R_AtmosphericPressure", typeof(decimal));
            dtHeatPipe.Columns.Add("R_AirFlowSupplyBypass", typeof(decimal));
            dtHeatPipe.Columns.Add("R_SupplyAirVelocity", typeof(decimal));
            dtHeatPipe.Columns.Add("R_ExhaustAirVelocity", typeof(decimal));
            dtHeatPipe.Columns.Add("R_ParallelFlow", typeof(bool));
            dtHeatPipe.Columns.Add("R_TiltAngle", typeof(decimal));
            dtHeatPipe.Columns.Add("R_ShowWarningMessage", typeof(bool));

            return dtHeatPipe;
        }

        public static DataTable DtQuoteHeatPipe()
        {
            //create datatable
            var dtHeatPipe = new DataTable("HeatPipes");

            dtHeatPipe.Columns.Add("QuoteID", typeof(int));
            dtHeatPipe.Columns.Add("QuoteRevision", typeof(int));
            dtHeatPipe.Columns.Add("QuoteRevisionText", typeof(string));
            dtHeatPipe.Columns.Add("ItemType", typeof(int));
            dtHeatPipe.Columns.Add("ItemID", typeof(int));
            dtHeatPipe.Columns.Add("Username", typeof(string));

            dtHeatPipe.Columns.Add("Tag", typeof(string));
            dtHeatPipe.Columns.Add("Quantity", typeof(int));
            dtHeatPipe.Columns.Add("Model", typeof(string));
            dtHeatPipe.Columns.Add("AirFlowSupply", typeof(decimal));
            dtHeatPipe.Columns.Add("AirFlowExhaust", typeof(decimal));
            dtHeatPipe.Columns.Add("Symmetrical", typeof(string));
            dtHeatPipe.Columns.Add("Altitude", typeof(decimal));
            dtHeatPipe.Columns.Add("Summer_OADB", typeof(decimal));
            dtHeatPipe.Columns.Add("Summer_OAWB", typeof(decimal));
            dtHeatPipe.Columns.Add("Summer_OARH", typeof(decimal));
            dtHeatPipe.Columns.Add("Summer_RADB", typeof(decimal));
            dtHeatPipe.Columns.Add("Summer_RAWB", typeof(decimal));
            dtHeatPipe.Columns.Add("Summer_RARH", typeof(decimal));
            dtHeatPipe.Columns.Add("Winter_OADB", typeof(decimal));
            dtHeatPipe.Columns.Add("Winter_OAWB", typeof(decimal));
            dtHeatPipe.Columns.Add("Winter_OARH", typeof(decimal));
            dtHeatPipe.Columns.Add("Winter_RADB", typeof(decimal));
            dtHeatPipe.Columns.Add("Winter_RAWB", typeof(decimal));
            dtHeatPipe.Columns.Add("Winter_RARH", typeof(decimal));
            dtHeatPipe.Columns.Add("FinType", typeof(string));
            dtHeatPipe.Columns.Add("FinHeight", typeof(decimal));
            dtHeatPipe.Columns.Add("FinLength", typeof(decimal));
            dtHeatPipe.Columns.Add("FPI", typeof(decimal));
            dtHeatPipe.Columns.Add("Input_FPI", typeof(string));
            dtHeatPipe.Columns.Add("Rows", typeof(decimal));
            dtHeatPipe.Columns.Add("Shape", typeof(string));
            dtHeatPipe.Columns.Add("AtmosphericPressure", typeof(decimal));
            dtHeatPipe.Columns.Add("FlowType", typeof(string));
            dtHeatPipe.Columns.Add("TiltAngle", typeof(decimal));
            dtHeatPipe.Columns.Add("DefrostSetPoint", typeof(decimal));
            dtHeatPipe.Columns.Add("Price", typeof(decimal));

            //following are return values
            dtHeatPipe.Columns.Add("R_Summer_FaceTubes", typeof(int));
            dtHeatPipe.Columns.Add("R_Summer_FinLength", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_AirFlowVelocity", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_FinLengthOnSupplySide", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_FinLengthOnReturnSide", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_FPI", typeof(int));
            dtHeatPipe.Columns.Add("R_Summer_NumberOfRows", typeof(int));
            dtHeatPipe.Columns.Add("R_Summer_OutsideAirDryBulb", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_ReturnAirDryBulb", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_SupplyDryBulb", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_ReturnDryBulb", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_OutsideAirRelativeHumidity", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_Coating", typeof(bool));
            dtHeatPipe.Columns.Add("R_Summer_DefrostSetPoint", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_Symmetrical", typeof(bool));
            dtHeatPipe.Columns.Add("R_Summer_Altitude", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_Weight", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_HeatPipeCapacity", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_Condensate", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_PressureDropExhaustSide", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_SensibleEffectiveness", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_LatentEffectiveness", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_TotalEffectiveness", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_SensibleCoolingCoilEffectiveness", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_TotalCoolingCoilEffectiveness", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_ExhaustAirRelativeHumidity", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_SupplyAirRelativeHumidity", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_AirFlowExhaust", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_AirFlowSupply", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_ReturnAirRelativeHumidity", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_FinsIndex", typeof(int));
            dtHeatPipe.Columns.Add("R_Summer_PressureDropSupplySide", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_OutsideAirWetBulb", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_ReturnAirWetBulb", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_ReturnWetBulb", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_SupplyWetBulb", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_OutsideAirGrains", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_ReturnAirGrains", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_ReturnGrains", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_SupplyGrains", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_OutsideAirEnthalpy", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_ReturnAirEnthalpy", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_ReturnEnthalpy", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_SupplyEnthalpy", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_MixingAirFlowSupplyTemperature", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_Shape", typeof(bool));
            dtHeatPipe.Columns.Add("R_Summer_AtmosphericPressure", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_AirFlowSupplyBypass", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_SupplyAirVelocity", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_ExhaustAirVelocity", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_ParallelFlow", typeof(bool));
            dtHeatPipe.Columns.Add("R_Summer_TiltAngle", typeof(double));
            dtHeatPipe.Columns.Add("R_Summer_ShowWarningMessage", typeof(bool));

            dtHeatPipe.Columns.Add("R_Winter_FaceTubes", typeof(int));
            dtHeatPipe.Columns.Add("R_Winter_FinLength", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_AirFlowVelocity", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_FinLengthOnSupplySide", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_FinLengthOnReturnSide", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_FPI", typeof(int));
            dtHeatPipe.Columns.Add("R_Winter_NumberOfRows", typeof(int));
            dtHeatPipe.Columns.Add("R_Winter_OutsideAirDryBulb", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_ReturnAirDryBulb", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_SupplyDryBulb", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_ReturnDryBulb", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_OutsideAirRelativeHumidity", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_Coating", typeof(bool));
            dtHeatPipe.Columns.Add("R_Winter_DefrostSetPoint", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_Symmetrical", typeof(bool));
            dtHeatPipe.Columns.Add("R_Winter_Altitude", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_Weight", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_HeatPipeCapacity", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_Condensate", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_PressureDropExhaustSide", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_SensibleEffectiveness", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_LatentEffectiveness", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_TotalEffectiveness", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_SensibleCoolingCoilEffectiveness", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_TotalCoolingCoilEffectiveness", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_ExhaustAirRelativeHumidity", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_SupplyAirRelativeHumidity", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_AirFlowExhaust", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_AirFlowSupply", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_ReturnAirRelativeHumidity", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_FinsIndex", typeof(int));
            dtHeatPipe.Columns.Add("R_Winter_PressureDropSupplySide", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_OutsideAirWetBulb", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_ReturnAirWetBulb", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_ReturnWetBulb", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_SupplyWetBulb", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_OutsideAirGrains", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_ReturnAirGrains", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_ReturnGrains", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_SupplyGrains", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_OutsideAirEnthalpy", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_ReturnAirEnthalpy", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_ReturnEnthalpy", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_SupplyEnthalpy", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_MixingAirFlowSupplyTemperature", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_Shape", typeof(bool));
            dtHeatPipe.Columns.Add("R_Winter_AtmosphericPressure", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_AirFlowSupplyBypass", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_SupplyAirVelocity", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_ExhaustAirVelocity", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_ParallelFlow", typeof(bool));
            dtHeatPipe.Columns.Add("R_Winter_TiltAngle", typeof(double));
            dtHeatPipe.Columns.Add("R_Winter_ShowWarningMessage", typeof(bool));

            return dtHeatPipe;
        }

        public static DataTable DtTableVersion()
        {
            //create datatable
            var dtTableVersion = new DataTable("TableVersion");
            //add columns
            dtTableVersion.Columns.Add("Name", typeof(string));
            dtTableVersion.Columns.Add("Version", typeof(int));

            return dtTableVersion;
        }

        public static DataTable DtCustomUnitReport()
        {
            var dtCustomUnitReport = new DataTable("CustomUnitTable");
            //dtCustomUnitReport.Columns.Add("Text", typeof(string));
            //dtCustomUnitReport.Columns.Add("Value", typeof(string));
            //dtCustomUnitReport.Columns.Add("Unit", typeof(string));

            //main informations
            dtCustomUnitReport.Columns.Add("QuoteID", typeof(int));
            dtCustomUnitReport.Columns.Add("QuoteRevision", typeof(int));
            dtCustomUnitReport.Columns.Add("QuoteRevisionText", typeof(string));
            dtCustomUnitReport.Columns.Add("ItemType", typeof(int));
            dtCustomUnitReport.Columns.Add("ItemID", typeof(int));
            dtCustomUnitReport.Columns.Add("Username", typeof(string));
            dtCustomUnitReport.Columns.Add("Tag", typeof(string));
            dtCustomUnitReport.Columns.Add("Quantity", typeof(int));
            dtCustomUnitReport.Columns.Add("Description", typeof(string));
            dtCustomUnitReport.Columns.Add("Price", typeof(decimal));

            dtCustomUnitReport.Columns.Add("Text1", typeof(string));
            dtCustomUnitReport.Columns.Add("Value1", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit1", typeof(string));
            dtCustomUnitReport.Columns.Add("Text2", typeof(string));
            dtCustomUnitReport.Columns.Add("Value2", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit2", typeof(string));
            dtCustomUnitReport.Columns.Add("Text3", typeof(string));
            dtCustomUnitReport.Columns.Add("Value3", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit3", typeof(string));
            dtCustomUnitReport.Columns.Add("Text4", typeof(string));
            dtCustomUnitReport.Columns.Add("Value4", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit4", typeof(string));
            dtCustomUnitReport.Columns.Add("Text5", typeof(string));
            dtCustomUnitReport.Columns.Add("Value5", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit5", typeof(string));
            dtCustomUnitReport.Columns.Add("Text6", typeof(string));
            dtCustomUnitReport.Columns.Add("Value6", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit6", typeof(string));
            dtCustomUnitReport.Columns.Add("Text7", typeof(string));
            dtCustomUnitReport.Columns.Add("Value7", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit7", typeof(string));
            dtCustomUnitReport.Columns.Add("Text8", typeof(string));
            dtCustomUnitReport.Columns.Add("Value8", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit8", typeof(string));
            dtCustomUnitReport.Columns.Add("Text9", typeof(string));
            dtCustomUnitReport.Columns.Add("Value9", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit9", typeof(string));
            dtCustomUnitReport.Columns.Add("Text10", typeof(string));
            dtCustomUnitReport.Columns.Add("Value10", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit10", typeof(string));
            dtCustomUnitReport.Columns.Add("Text11", typeof(string));
            dtCustomUnitReport.Columns.Add("Value11", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit11", typeof(string));
            dtCustomUnitReport.Columns.Add("Text12", typeof(string));
            dtCustomUnitReport.Columns.Add("Value12", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit12", typeof(string));
            dtCustomUnitReport.Columns.Add("Text13", typeof(string));
            dtCustomUnitReport.Columns.Add("Value13", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit13", typeof(string));
            dtCustomUnitReport.Columns.Add("Text14", typeof(string));
            dtCustomUnitReport.Columns.Add("Value14", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit14", typeof(string));
            dtCustomUnitReport.Columns.Add("Text15", typeof(string));
            dtCustomUnitReport.Columns.Add("Value15", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit15", typeof(string));
            dtCustomUnitReport.Columns.Add("Text16", typeof(string));
            dtCustomUnitReport.Columns.Add("Value16", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit16", typeof(string));
            dtCustomUnitReport.Columns.Add("Text17", typeof(string));
            dtCustomUnitReport.Columns.Add("Value17", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit17", typeof(string));
            dtCustomUnitReport.Columns.Add("Text18", typeof(string));
            dtCustomUnitReport.Columns.Add("Value18", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit18", typeof(string));
            dtCustomUnitReport.Columns.Add("Text19", typeof(string));
            dtCustomUnitReport.Columns.Add("Value19", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit19", typeof(string));
            dtCustomUnitReport.Columns.Add("Text20", typeof(string));
            dtCustomUnitReport.Columns.Add("Value20", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit20", typeof(string));
            dtCustomUnitReport.Columns.Add("Text21", typeof(string));
            dtCustomUnitReport.Columns.Add("Value21", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit21", typeof(string));
            dtCustomUnitReport.Columns.Add("Text22", typeof(string));
            dtCustomUnitReport.Columns.Add("Value22", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit22", typeof(string));
            dtCustomUnitReport.Columns.Add("Text23", typeof(string));
            dtCustomUnitReport.Columns.Add("Value23", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit23", typeof(string));
            dtCustomUnitReport.Columns.Add("Text24", typeof(string));
            dtCustomUnitReport.Columns.Add("Value24", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit24", typeof(string));
            dtCustomUnitReport.Columns.Add("Text25", typeof(string));
            dtCustomUnitReport.Columns.Add("Value25", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit25", typeof(string));
            dtCustomUnitReport.Columns.Add("Text26", typeof(string));
            dtCustomUnitReport.Columns.Add("Value26", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit26", typeof(string));
            dtCustomUnitReport.Columns.Add("Text27", typeof(string));
            dtCustomUnitReport.Columns.Add("Value27", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit27", typeof(string));
            dtCustomUnitReport.Columns.Add("Text28", typeof(string));
            dtCustomUnitReport.Columns.Add("Value28", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit28", typeof(string));
            dtCustomUnitReport.Columns.Add("Text29", typeof(string));
            dtCustomUnitReport.Columns.Add("Value29", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit29", typeof(string));
            dtCustomUnitReport.Columns.Add("Text30", typeof(string));
            dtCustomUnitReport.Columns.Add("Value30", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit30", typeof(string));
            dtCustomUnitReport.Columns.Add("Text31", typeof(string));
            dtCustomUnitReport.Columns.Add("Value31", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit31", typeof(string));
            dtCustomUnitReport.Columns.Add("Text32", typeof(string));
            dtCustomUnitReport.Columns.Add("Value32", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit32", typeof(string));
            dtCustomUnitReport.Columns.Add("Text33", typeof(string));
            dtCustomUnitReport.Columns.Add("Value33", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit33", typeof(string));
            dtCustomUnitReport.Columns.Add("Text34", typeof(string));
            dtCustomUnitReport.Columns.Add("Value34", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit34", typeof(string));
            dtCustomUnitReport.Columns.Add("Text35", typeof(string));
            dtCustomUnitReport.Columns.Add("Value35", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit35", typeof(string));
            dtCustomUnitReport.Columns.Add("Text36", typeof(string));
            dtCustomUnitReport.Columns.Add("Value36", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit36", typeof(string));
            dtCustomUnitReport.Columns.Add("Text37", typeof(string));
            dtCustomUnitReport.Columns.Add("Value37", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit37", typeof(string));
            dtCustomUnitReport.Columns.Add("Text38", typeof(string));
            dtCustomUnitReport.Columns.Add("Value38", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit38", typeof(string));
            dtCustomUnitReport.Columns.Add("Text39", typeof(string));
            dtCustomUnitReport.Columns.Add("Value39", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit39", typeof(string));
            dtCustomUnitReport.Columns.Add("Text40", typeof(string));
            dtCustomUnitReport.Columns.Add("Value40", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit40", typeof(string));
            dtCustomUnitReport.Columns.Add("Text41", typeof(string));
            dtCustomUnitReport.Columns.Add("Value41", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit41", typeof(string));
            dtCustomUnitReport.Columns.Add("Text42", typeof(string));
            dtCustomUnitReport.Columns.Add("Value42", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit42", typeof(string));
            dtCustomUnitReport.Columns.Add("Text43", typeof(string));
            dtCustomUnitReport.Columns.Add("Value43", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit43", typeof(string));
            dtCustomUnitReport.Columns.Add("Text44", typeof(string));
            dtCustomUnitReport.Columns.Add("Value44", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit44", typeof(string));
            dtCustomUnitReport.Columns.Add("Text45", typeof(string));
            dtCustomUnitReport.Columns.Add("Value45", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit45", typeof(string));
            dtCustomUnitReport.Columns.Add("Text46", typeof(string));
            dtCustomUnitReport.Columns.Add("Value46", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit46", typeof(string));
            dtCustomUnitReport.Columns.Add("Text47", typeof(string));
            dtCustomUnitReport.Columns.Add("Value47", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit47", typeof(string));
            dtCustomUnitReport.Columns.Add("Text48", typeof(string));
            dtCustomUnitReport.Columns.Add("Value48", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit48", typeof(string));
            dtCustomUnitReport.Columns.Add("Text49", typeof(string));
            dtCustomUnitReport.Columns.Add("Value49", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit49", typeof(string));
            dtCustomUnitReport.Columns.Add("Text50", typeof(string));
            dtCustomUnitReport.Columns.Add("Value50", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit50", typeof(string));
            dtCustomUnitReport.Columns.Add("Text51", typeof(string));
            dtCustomUnitReport.Columns.Add("Value51", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit51", typeof(string));
            dtCustomUnitReport.Columns.Add("Text52", typeof(string));
            dtCustomUnitReport.Columns.Add("Value52", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit52", typeof(string));
            dtCustomUnitReport.Columns.Add("Text53", typeof(string));
            dtCustomUnitReport.Columns.Add("Value53", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit53", typeof(string));
            dtCustomUnitReport.Columns.Add("Text54", typeof(string));
            dtCustomUnitReport.Columns.Add("Value54", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit54", typeof(string));
            dtCustomUnitReport.Columns.Add("Text55", typeof(string));
            dtCustomUnitReport.Columns.Add("Value55", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit55", typeof(string));
            dtCustomUnitReport.Columns.Add("Text56", typeof(string));
            dtCustomUnitReport.Columns.Add("Value56", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit56", typeof(string));
            dtCustomUnitReport.Columns.Add("Text57", typeof(string));
            dtCustomUnitReport.Columns.Add("Value57", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit57", typeof(string));
            dtCustomUnitReport.Columns.Add("Text58", typeof(string));
            dtCustomUnitReport.Columns.Add("Value58", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit58", typeof(string));
            dtCustomUnitReport.Columns.Add("Text59", typeof(string));
            dtCustomUnitReport.Columns.Add("Value59", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit59", typeof(string));
            dtCustomUnitReport.Columns.Add("Text60", typeof(string));
            dtCustomUnitReport.Columns.Add("Value60", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit60", typeof(string));
            dtCustomUnitReport.Columns.Add("Text61", typeof(string));
            dtCustomUnitReport.Columns.Add("Value61", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit61", typeof(string));
            dtCustomUnitReport.Columns.Add("Text62", typeof(string));
            dtCustomUnitReport.Columns.Add("Value62", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit62", typeof(string));
            dtCustomUnitReport.Columns.Add("Text63", typeof(string));
            dtCustomUnitReport.Columns.Add("Value63", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit63", typeof(string));
            dtCustomUnitReport.Columns.Add("Text64", typeof(string));
            dtCustomUnitReport.Columns.Add("Value64", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit64", typeof(string));
            dtCustomUnitReport.Columns.Add("Text65", typeof(string));
            dtCustomUnitReport.Columns.Add("Value65", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit65", typeof(string));
            dtCustomUnitReport.Columns.Add("Text66", typeof(string));
            dtCustomUnitReport.Columns.Add("Value66", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit66", typeof(string));
            dtCustomUnitReport.Columns.Add("Text67", typeof(string));
            dtCustomUnitReport.Columns.Add("Value67", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit67", typeof(string));
            dtCustomUnitReport.Columns.Add("Text68", typeof(string));
            dtCustomUnitReport.Columns.Add("Value68", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit68", typeof(string));
            dtCustomUnitReport.Columns.Add("Text69", typeof(string));
            dtCustomUnitReport.Columns.Add("Value69", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit69", typeof(string));
            dtCustomUnitReport.Columns.Add("Text70", typeof(string));
            dtCustomUnitReport.Columns.Add("Value70", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit70", typeof(string));
            dtCustomUnitReport.Columns.Add("Text71", typeof(string));
            dtCustomUnitReport.Columns.Add("Value71", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit71", typeof(string));
            dtCustomUnitReport.Columns.Add("Text72", typeof(string));
            dtCustomUnitReport.Columns.Add("Value72", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit72", typeof(string));
            dtCustomUnitReport.Columns.Add("Text73", typeof(string));
            dtCustomUnitReport.Columns.Add("Value73", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit73", typeof(string));
            dtCustomUnitReport.Columns.Add("Text74", typeof(string));
            dtCustomUnitReport.Columns.Add("Value74", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit74", typeof(string));
            dtCustomUnitReport.Columns.Add("Text75", typeof(string));
            dtCustomUnitReport.Columns.Add("Value75", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit75", typeof(string));
            dtCustomUnitReport.Columns.Add("Text76", typeof(string));
            dtCustomUnitReport.Columns.Add("Value76", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit76", typeof(string));
            dtCustomUnitReport.Columns.Add("Text77", typeof(string));
            dtCustomUnitReport.Columns.Add("Value77", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit77", typeof(string));
            dtCustomUnitReport.Columns.Add("Text78", typeof(string));
            dtCustomUnitReport.Columns.Add("Value78", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit78", typeof(string));
            dtCustomUnitReport.Columns.Add("Text79", typeof(string));
            dtCustomUnitReport.Columns.Add("Value79", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit79", typeof(string));
            dtCustomUnitReport.Columns.Add("Text80", typeof(string));
            dtCustomUnitReport.Columns.Add("Value80", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit80", typeof(string));
            dtCustomUnitReport.Columns.Add("Text81", typeof(string));
            dtCustomUnitReport.Columns.Add("Value81", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit81", typeof(string));
            dtCustomUnitReport.Columns.Add("Text82", typeof(string));
            dtCustomUnitReport.Columns.Add("Value82", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit82", typeof(string));
            dtCustomUnitReport.Columns.Add("Text83", typeof(string));
            dtCustomUnitReport.Columns.Add("Value83", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit83", typeof(string));
            dtCustomUnitReport.Columns.Add("Text84", typeof(string));
            dtCustomUnitReport.Columns.Add("Value84", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit84", typeof(string));
            dtCustomUnitReport.Columns.Add("Text85", typeof(string));
            dtCustomUnitReport.Columns.Add("Value85", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit85", typeof(string));
            dtCustomUnitReport.Columns.Add("Text86", typeof(string));
            dtCustomUnitReport.Columns.Add("Value86", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit86", typeof(string));
            dtCustomUnitReport.Columns.Add("Text87", typeof(string));
            dtCustomUnitReport.Columns.Add("Value87", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit87", typeof(string));
            dtCustomUnitReport.Columns.Add("Text88", typeof(string));
            dtCustomUnitReport.Columns.Add("Value88", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit88", typeof(string));
            dtCustomUnitReport.Columns.Add("Text89", typeof(string));
            dtCustomUnitReport.Columns.Add("Value89", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit89", typeof(string));
            dtCustomUnitReport.Columns.Add("Text90", typeof(string));
            dtCustomUnitReport.Columns.Add("Value90", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit90", typeof(string));
            dtCustomUnitReport.Columns.Add("Text91", typeof(string));
            dtCustomUnitReport.Columns.Add("Value91", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit91", typeof(string));
            dtCustomUnitReport.Columns.Add("Text92", typeof(string));
            dtCustomUnitReport.Columns.Add("Value92", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit92", typeof(string));
            dtCustomUnitReport.Columns.Add("Text93", typeof(string));
            dtCustomUnitReport.Columns.Add("Value93", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit93", typeof(string));
            dtCustomUnitReport.Columns.Add("Text94", typeof(string));
            dtCustomUnitReport.Columns.Add("Value94", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit94", typeof(string));
            dtCustomUnitReport.Columns.Add("Text95", typeof(string));
            dtCustomUnitReport.Columns.Add("Value95", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit95", typeof(string));
            dtCustomUnitReport.Columns.Add("Text96", typeof(string));
            dtCustomUnitReport.Columns.Add("Value96", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit96", typeof(string));
            dtCustomUnitReport.Columns.Add("Text97", typeof(string));
            dtCustomUnitReport.Columns.Add("Value97", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit97", typeof(string));
            dtCustomUnitReport.Columns.Add("Text98", typeof(string));
            dtCustomUnitReport.Columns.Add("Value98", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit98", typeof(string));
            dtCustomUnitReport.Columns.Add("Text99", typeof(string));
            dtCustomUnitReport.Columns.Add("Value99", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit99", typeof(string));
            dtCustomUnitReport.Columns.Add("Text100", typeof(string));
            dtCustomUnitReport.Columns.Add("Value100", typeof(string));
            dtCustomUnitReport.Columns.Add("Unit100", typeof(string));
            dtCustomUnitReport.Columns.Add("Count", typeof(int));

            return dtCustomUnitReport;
        }

        public static DataTable DtCustomUnitTemplate()
        {
            var dtTemplate = new DataTable("CustomTemplate");
            dtTemplate.Columns.Add("Description", typeof(string));
            dtTemplate.Columns.Add("UserID", typeof(string));
            dtTemplate.Columns.Add("Text1", typeof(string));
            dtTemplate.Columns.Add("Value1", typeof(string));
            dtTemplate.Columns.Add("Unit1", typeof(string));
            dtTemplate.Columns.Add("Text2", typeof(string));
            dtTemplate.Columns.Add("Value2", typeof(string));
            dtTemplate.Columns.Add("Unit2", typeof(string));
            dtTemplate.Columns.Add("Text3", typeof(string));
            dtTemplate.Columns.Add("Value3", typeof(string));
            dtTemplate.Columns.Add("Unit3", typeof(string));
            dtTemplate.Columns.Add("Text4", typeof(string));
            dtTemplate.Columns.Add("Value4", typeof(string));
            dtTemplate.Columns.Add("Unit4", typeof(string));
            dtTemplate.Columns.Add("Text5", typeof(string));
            dtTemplate.Columns.Add("Value5", typeof(string));
            dtTemplate.Columns.Add("Unit5", typeof(string));
            dtTemplate.Columns.Add("Text6", typeof(string));
            dtTemplate.Columns.Add("Value6", typeof(string));
            dtTemplate.Columns.Add("Unit6", typeof(string));
            dtTemplate.Columns.Add("Text7", typeof(string));
            dtTemplate.Columns.Add("Value7", typeof(string));
            dtTemplate.Columns.Add("Unit7", typeof(string));
            dtTemplate.Columns.Add("Text8", typeof(string));
            dtTemplate.Columns.Add("Value8", typeof(string));
            dtTemplate.Columns.Add("Unit8", typeof(string));
            dtTemplate.Columns.Add("Text9", typeof(string));
            dtTemplate.Columns.Add("Value9", typeof(string));
            dtTemplate.Columns.Add("Unit9", typeof(string));
            dtTemplate.Columns.Add("Text10", typeof(string));
            dtTemplate.Columns.Add("Value10", typeof(string));
            dtTemplate.Columns.Add("Unit10", typeof(string));
            dtTemplate.Columns.Add("Text11", typeof(string));
            dtTemplate.Columns.Add("Value11", typeof(string));
            dtTemplate.Columns.Add("Unit11", typeof(string));
            dtTemplate.Columns.Add("Text12", typeof(string));
            dtTemplate.Columns.Add("Value12", typeof(string));
            dtTemplate.Columns.Add("Unit12", typeof(string));
            dtTemplate.Columns.Add("Text13", typeof(string));
            dtTemplate.Columns.Add("Value13", typeof(string));
            dtTemplate.Columns.Add("Unit13", typeof(string));
            dtTemplate.Columns.Add("Text14", typeof(string));
            dtTemplate.Columns.Add("Value14", typeof(string));
            dtTemplate.Columns.Add("Unit14", typeof(string));
            dtTemplate.Columns.Add("Text15", typeof(string));
            dtTemplate.Columns.Add("Value15", typeof(string));
            dtTemplate.Columns.Add("Unit15", typeof(string));
            dtTemplate.Columns.Add("Text16", typeof(string));
            dtTemplate.Columns.Add("Value16", typeof(string));
            dtTemplate.Columns.Add("Unit16", typeof(string));
            dtTemplate.Columns.Add("Text17", typeof(string));
            dtTemplate.Columns.Add("Value17", typeof(string));
            dtTemplate.Columns.Add("Unit17", typeof(string));
            dtTemplate.Columns.Add("Text18", typeof(string));
            dtTemplate.Columns.Add("Value18", typeof(string));
            dtTemplate.Columns.Add("Unit18", typeof(string));
            dtTemplate.Columns.Add("Text19", typeof(string));
            dtTemplate.Columns.Add("Value19", typeof(string));
            dtTemplate.Columns.Add("Unit19", typeof(string));
            dtTemplate.Columns.Add("Text20", typeof(string));
            dtTemplate.Columns.Add("Value20", typeof(string));
            dtTemplate.Columns.Add("Unit20", typeof(string));
            dtTemplate.Columns.Add("Text21", typeof(string));
            dtTemplate.Columns.Add("Value21", typeof(string));
            dtTemplate.Columns.Add("Unit21", typeof(string));
            dtTemplate.Columns.Add("Text22", typeof(string));
            dtTemplate.Columns.Add("Value22", typeof(string));
            dtTemplate.Columns.Add("Unit22", typeof(string));
            dtTemplate.Columns.Add("Text23", typeof(string));
            dtTemplate.Columns.Add("Value23", typeof(string));
            dtTemplate.Columns.Add("Unit23", typeof(string));
            dtTemplate.Columns.Add("Text24", typeof(string));
            dtTemplate.Columns.Add("Value24", typeof(string));
            dtTemplate.Columns.Add("Unit24", typeof(string));
            dtTemplate.Columns.Add("Text25", typeof(string));
            dtTemplate.Columns.Add("Value25", typeof(string));
            dtTemplate.Columns.Add("Unit25", typeof(string));
            dtTemplate.Columns.Add("Text26", typeof(string));
            dtTemplate.Columns.Add("Value26", typeof(string));
            dtTemplate.Columns.Add("Unit26", typeof(string));
            dtTemplate.Columns.Add("Text27", typeof(string));
            dtTemplate.Columns.Add("Value27", typeof(string));
            dtTemplate.Columns.Add("Unit27", typeof(string));
            dtTemplate.Columns.Add("Text28", typeof(string));
            dtTemplate.Columns.Add("Value28", typeof(string));
            dtTemplate.Columns.Add("Unit28", typeof(string));
            dtTemplate.Columns.Add("Text29", typeof(string));
            dtTemplate.Columns.Add("Value29", typeof(string));
            dtTemplate.Columns.Add("Unit29", typeof(string));
            dtTemplate.Columns.Add("Text30", typeof(string));
            dtTemplate.Columns.Add("Value30", typeof(string));
            dtTemplate.Columns.Add("Unit30", typeof(string));
            dtTemplate.Columns.Add("Text31", typeof(string));
            dtTemplate.Columns.Add("Value31", typeof(string));
            dtTemplate.Columns.Add("Unit31", typeof(string));
            dtTemplate.Columns.Add("Text32", typeof(string));
            dtTemplate.Columns.Add("Value32", typeof(string));
            dtTemplate.Columns.Add("Unit32", typeof(string));
            dtTemplate.Columns.Add("Text33", typeof(string));
            dtTemplate.Columns.Add("Value33", typeof(string));
            dtTemplate.Columns.Add("Unit33", typeof(string));
            dtTemplate.Columns.Add("Text34", typeof(string));
            dtTemplate.Columns.Add("Value34", typeof(string));
            dtTemplate.Columns.Add("Unit34", typeof(string));
            dtTemplate.Columns.Add("Text35", typeof(string));
            dtTemplate.Columns.Add("Value35", typeof(string));
            dtTemplate.Columns.Add("Unit35", typeof(string));
            dtTemplate.Columns.Add("Text36", typeof(string));
            dtTemplate.Columns.Add("Value36", typeof(string));
            dtTemplate.Columns.Add("Unit36", typeof(string));
            dtTemplate.Columns.Add("Text37", typeof(string));
            dtTemplate.Columns.Add("Value37", typeof(string));
            dtTemplate.Columns.Add("Unit37", typeof(string));
            dtTemplate.Columns.Add("Text38", typeof(string));
            dtTemplate.Columns.Add("Value38", typeof(string));
            dtTemplate.Columns.Add("Unit38", typeof(string));
            dtTemplate.Columns.Add("Text39", typeof(string));
            dtTemplate.Columns.Add("Value39", typeof(string));
            dtTemplate.Columns.Add("Unit39", typeof(string));
            dtTemplate.Columns.Add("Text40", typeof(string));
            dtTemplate.Columns.Add("Value40", typeof(string));
            dtTemplate.Columns.Add("Unit40", typeof(string));
            dtTemplate.Columns.Add("Text41", typeof(string));
            dtTemplate.Columns.Add("Value41", typeof(string));
            dtTemplate.Columns.Add("Unit41", typeof(string));
            dtTemplate.Columns.Add("Text42", typeof(string));
            dtTemplate.Columns.Add("Value42", typeof(string));
            dtTemplate.Columns.Add("Unit42", typeof(string));
            dtTemplate.Columns.Add("Text43", typeof(string));
            dtTemplate.Columns.Add("Value43", typeof(string));
            dtTemplate.Columns.Add("Unit43", typeof(string));
            dtTemplate.Columns.Add("Text44", typeof(string));
            dtTemplate.Columns.Add("Value44", typeof(string));
            dtTemplate.Columns.Add("Unit44", typeof(string));
            dtTemplate.Columns.Add("Text45", typeof(string));
            dtTemplate.Columns.Add("Value45", typeof(string));
            dtTemplate.Columns.Add("Unit45", typeof(string));
            dtTemplate.Columns.Add("Text46", typeof(string));
            dtTemplate.Columns.Add("Value46", typeof(string));
            dtTemplate.Columns.Add("Unit46", typeof(string));
            dtTemplate.Columns.Add("Text47", typeof(string));
            dtTemplate.Columns.Add("Value47", typeof(string));
            dtTemplate.Columns.Add("Unit47", typeof(string));
            dtTemplate.Columns.Add("Text48", typeof(string));
            dtTemplate.Columns.Add("Value48", typeof(string));
            dtTemplate.Columns.Add("Unit48", typeof(string));
            dtTemplate.Columns.Add("Text49", typeof(string));
            dtTemplate.Columns.Add("Value49", typeof(string));
            dtTemplate.Columns.Add("Unit49", typeof(string));
            dtTemplate.Columns.Add("Text50", typeof(string));
            dtTemplate.Columns.Add("Value50", typeof(string));
            dtTemplate.Columns.Add("Unit50", typeof(string));
            dtTemplate.Columns.Add("Text51", typeof(string));
            dtTemplate.Columns.Add("Value51", typeof(string));
            dtTemplate.Columns.Add("Unit51", typeof(string));
            dtTemplate.Columns.Add("Text52", typeof(string));
            dtTemplate.Columns.Add("Value52", typeof(string));
            dtTemplate.Columns.Add("Unit52", typeof(string));
            dtTemplate.Columns.Add("Text53", typeof(string));
            dtTemplate.Columns.Add("Value53", typeof(string));
            dtTemplate.Columns.Add("Unit53", typeof(string));
            dtTemplate.Columns.Add("Text54", typeof(string));
            dtTemplate.Columns.Add("Value54", typeof(string));
            dtTemplate.Columns.Add("Unit54", typeof(string));
            dtTemplate.Columns.Add("Text55", typeof(string));
            dtTemplate.Columns.Add("Value55", typeof(string));
            dtTemplate.Columns.Add("Unit55", typeof(string));
            dtTemplate.Columns.Add("Text56", typeof(string));
            dtTemplate.Columns.Add("Value56", typeof(string));
            dtTemplate.Columns.Add("Unit56", typeof(string));
            dtTemplate.Columns.Add("Text57", typeof(string));
            dtTemplate.Columns.Add("Value57", typeof(string));
            dtTemplate.Columns.Add("Unit57", typeof(string));
            dtTemplate.Columns.Add("Text58", typeof(string));
            dtTemplate.Columns.Add("Value58", typeof(string));
            dtTemplate.Columns.Add("Unit58", typeof(string));
            dtTemplate.Columns.Add("Text59", typeof(string));
            dtTemplate.Columns.Add("Value59", typeof(string));
            dtTemplate.Columns.Add("Unit59", typeof(string));
            dtTemplate.Columns.Add("Text60", typeof(string));
            dtTemplate.Columns.Add("Value60", typeof(string));
            dtTemplate.Columns.Add("Unit60", typeof(string));
            dtTemplate.Columns.Add("Text61", typeof(string));
            dtTemplate.Columns.Add("Value61", typeof(string));
            dtTemplate.Columns.Add("Unit61", typeof(string));
            dtTemplate.Columns.Add("Text62", typeof(string));
            dtTemplate.Columns.Add("Value62", typeof(string));
            dtTemplate.Columns.Add("Unit62", typeof(string));
            dtTemplate.Columns.Add("Text63", typeof(string));
            dtTemplate.Columns.Add("Value63", typeof(string));
            dtTemplate.Columns.Add("Unit63", typeof(string));
            dtTemplate.Columns.Add("Text64", typeof(string));
            dtTemplate.Columns.Add("Value64", typeof(string));
            dtTemplate.Columns.Add("Unit64", typeof(string));
            dtTemplate.Columns.Add("Text65", typeof(string));
            dtTemplate.Columns.Add("Value65", typeof(string));
            dtTemplate.Columns.Add("Unit65", typeof(string));
            dtTemplate.Columns.Add("Text66", typeof(string));
            dtTemplate.Columns.Add("Value66", typeof(string));
            dtTemplate.Columns.Add("Unit66", typeof(string));
            dtTemplate.Columns.Add("Text67", typeof(string));
            dtTemplate.Columns.Add("Value67", typeof(string));
            dtTemplate.Columns.Add("Unit67", typeof(string));
            dtTemplate.Columns.Add("Text68", typeof(string));
            dtTemplate.Columns.Add("Value68", typeof(string));
            dtTemplate.Columns.Add("Unit68", typeof(string));
            dtTemplate.Columns.Add("Text69", typeof(string));
            dtTemplate.Columns.Add("Value69", typeof(string));
            dtTemplate.Columns.Add("Unit69", typeof(string));
            dtTemplate.Columns.Add("Text70", typeof(string));
            dtTemplate.Columns.Add("Value70", typeof(string));
            dtTemplate.Columns.Add("Unit70", typeof(string));
            dtTemplate.Columns.Add("Text71", typeof(string));
            dtTemplate.Columns.Add("Value71", typeof(string));
            dtTemplate.Columns.Add("Unit71", typeof(string));
            dtTemplate.Columns.Add("Text72", typeof(string));
            dtTemplate.Columns.Add("Value72", typeof(string));
            dtTemplate.Columns.Add("Unit72", typeof(string));
            dtTemplate.Columns.Add("Text73", typeof(string));
            dtTemplate.Columns.Add("Value73", typeof(string));
            dtTemplate.Columns.Add("Unit73", typeof(string));
            dtTemplate.Columns.Add("Text74", typeof(string));
            dtTemplate.Columns.Add("Value74", typeof(string));
            dtTemplate.Columns.Add("Unit74", typeof(string));
            dtTemplate.Columns.Add("Text75", typeof(string));
            dtTemplate.Columns.Add("Value75", typeof(string));
            dtTemplate.Columns.Add("Unit75", typeof(string));
            dtTemplate.Columns.Add("Text76", typeof(string));
            dtTemplate.Columns.Add("Value76", typeof(string));
            dtTemplate.Columns.Add("Unit76", typeof(string));
            dtTemplate.Columns.Add("Text77", typeof(string));
            dtTemplate.Columns.Add("Value77", typeof(string));
            dtTemplate.Columns.Add("Unit77", typeof(string));
            dtTemplate.Columns.Add("Text78", typeof(string));
            dtTemplate.Columns.Add("Value78", typeof(string));
            dtTemplate.Columns.Add("Unit78", typeof(string));
            dtTemplate.Columns.Add("Text79", typeof(string));
            dtTemplate.Columns.Add("Value79", typeof(string));
            dtTemplate.Columns.Add("Unit79", typeof(string));
            dtTemplate.Columns.Add("Text80", typeof(string));
            dtTemplate.Columns.Add("Value80", typeof(string));
            dtTemplate.Columns.Add("Unit80", typeof(string));
            dtTemplate.Columns.Add("Text81", typeof(string));
            dtTemplate.Columns.Add("Value81", typeof(string));
            dtTemplate.Columns.Add("Unit81", typeof(string));
            dtTemplate.Columns.Add("Text82", typeof(string));
            dtTemplate.Columns.Add("Value82", typeof(string));
            dtTemplate.Columns.Add("Unit82", typeof(string));
            dtTemplate.Columns.Add("Text83", typeof(string));
            dtTemplate.Columns.Add("Value83", typeof(string));
            dtTemplate.Columns.Add("Unit83", typeof(string));
            dtTemplate.Columns.Add("Text84", typeof(string));
            dtTemplate.Columns.Add("Value84", typeof(string));
            dtTemplate.Columns.Add("Unit84", typeof(string));
            dtTemplate.Columns.Add("Text85", typeof(string));
            dtTemplate.Columns.Add("Value85", typeof(string));
            dtTemplate.Columns.Add("Unit85", typeof(string));
            dtTemplate.Columns.Add("Text86", typeof(string));
            dtTemplate.Columns.Add("Value86", typeof(string));
            dtTemplate.Columns.Add("Unit86", typeof(string));
            dtTemplate.Columns.Add("Text87", typeof(string));
            dtTemplate.Columns.Add("Value87", typeof(string));
            dtTemplate.Columns.Add("Unit87", typeof(string));
            dtTemplate.Columns.Add("Text88", typeof(string));
            dtTemplate.Columns.Add("Value88", typeof(string));
            dtTemplate.Columns.Add("Unit88", typeof(string));
            dtTemplate.Columns.Add("Text89", typeof(string));
            dtTemplate.Columns.Add("Value89", typeof(string));
            dtTemplate.Columns.Add("Unit89", typeof(string));
            dtTemplate.Columns.Add("Text90", typeof(string));
            dtTemplate.Columns.Add("Value90", typeof(string));
            dtTemplate.Columns.Add("Unit90", typeof(string));
            dtTemplate.Columns.Add("Text91", typeof(string));
            dtTemplate.Columns.Add("Value91", typeof(string));
            dtTemplate.Columns.Add("Unit91", typeof(string));
            dtTemplate.Columns.Add("Text92", typeof(string));
            dtTemplate.Columns.Add("Value92", typeof(string));
            dtTemplate.Columns.Add("Unit92", typeof(string));
            dtTemplate.Columns.Add("Text93", typeof(string));
            dtTemplate.Columns.Add("Value93", typeof(string));
            dtTemplate.Columns.Add("Unit93", typeof(string));
            dtTemplate.Columns.Add("Text94", typeof(string));
            dtTemplate.Columns.Add("Value94", typeof(string));
            dtTemplate.Columns.Add("Unit94", typeof(string));
            dtTemplate.Columns.Add("Text95", typeof(string));
            dtTemplate.Columns.Add("Value95", typeof(string));
            dtTemplate.Columns.Add("Unit95", typeof(string));
            dtTemplate.Columns.Add("Text96", typeof(string));
            dtTemplate.Columns.Add("Value96", typeof(string));
            dtTemplate.Columns.Add("Unit96", typeof(string));
            dtTemplate.Columns.Add("Text97", typeof(string));
            dtTemplate.Columns.Add("Value97", typeof(string));
            dtTemplate.Columns.Add("Unit97", typeof(string));
            dtTemplate.Columns.Add("Text98", typeof(string));
            dtTemplate.Columns.Add("Value98", typeof(string));
            dtTemplate.Columns.Add("Unit98", typeof(string));
            dtTemplate.Columns.Add("Text99", typeof(string));
            dtTemplate.Columns.Add("Value99", typeof(string));
            dtTemplate.Columns.Add("Unit99", typeof(string));
            dtTemplate.Columns.Add("Text100", typeof(string));
            dtTemplate.Columns.Add("Value100", typeof(string));
            dtTemplate.Columns.Add("Unit100", typeof(string));
            dtTemplate.Columns.Add("Count", typeof(int));
          
            return dtTemplate;
        }

        private static IEnumerable<DataColumn> ColQuoteHeaderColumns()
        {
            var dc = new DataColumn[6];
            dc[0].ColumnName = "QuoteID";
            dc[0].DataType = typeof(int);
            dc[0].ColumnName = "QuoteRevision";
            dc[0].DataType = typeof(int);
            dc[0].ColumnName = "QuoteRevisionText";
            dc[0].DataType = typeof(string);
            dc[0].ColumnName = "ItemType";
            dc[0].DataType = typeof(int);
            dc[0].ColumnName = "ItemID";
            dc[0].DataType = typeof(int);
            dc[0].ColumnName = "Username";
            dc[0].DataType = typeof(string);
            return dc;
        }

        public static void AddQuoteHeaderToTable(DataTable dtTable)
        {
            //create a copy
            DataTable dtTemp = dtTable.Copy();

            //clear row and column of original
            dtTable.Rows.Clear();
            dtTable.Columns.Clear();

            //get the list of new columns to add before
            IEnumerable<DataColumn> dcQuoteHeader = ColQuoteHeaderColumns();

            //add the columns
            foreach (DataColumn dcNewColumn in dcQuoteHeader)
            {
                dtTable.Columns.Add(dcNewColumn.ColumnName, dcNewColumn.DataType);
            }

            //re add the old columns
            foreach (DataColumn dcOriginal in dtTemp.Columns)
            {
                dtTable.Columns.Add(dcOriginal.ColumnName, dcOriginal.DataType);
            }

            //readd all the data
            for (int intRow = 0; intRow < dtTemp.Rows.Count; intRow++)
            {
                DataRow drFinal = dtTable.NewRow();

                drFinal["QuoteID"] = 0;
                drFinal["QuoteRevision"] = 0;
                drFinal["QuoteRevisionText"] = "";
                drFinal["ItemType"] = 0;
                drFinal["ItemID"] = 0;
                drFinal["Username"] = "";
                
                for (int intCol = 6; intCol < dtTemp.Columns.Count; intCol++)
                {
                    drFinal[intCol] = dtTemp.Rows[intRow][dtTable.Columns[intCol].ColumnName];
                }

                dtTable.Rows.Add(drFinal);
            }

        }

        public static DataTable DtControlPanelInputs()
        {
            var dtControlPanelInputs = new DataTable("ControlPanelInputs");
            //main informations
            dtControlPanelInputs.Columns.Add("QuoteID", typeof(int));
            dtControlPanelInputs.Columns.Add("QuoteRevision", typeof(int));
            dtControlPanelInputs.Columns.Add("QuoteRevisionText", typeof(string));
            dtControlPanelInputs.Columns.Add("ItemType", typeof(int));
            dtControlPanelInputs.Columns.Add("ItemID", typeof(int));
            dtControlPanelInputs.Columns.Add("Username", typeof(string));

            //Panel informations
            dtControlPanelInputs.Columns.Add("ControlPanelNomenclature", typeof(string));
            dtControlPanelInputs.Columns.Add("PanelDescription", typeof(string));

            dtControlPanelInputs.Columns.Add("Option", typeof(string));
            dtControlPanelInputs.Columns.Add("OptionPrice", typeof(decimal));
            dtControlPanelInputs.Columns.Add("ControlVoltage", typeof(string));
            dtControlPanelInputs.Columns.Add("Price", typeof(decimal));
            
            ////main informations
            //dtControlPanelInputs.Columns.Add("UserKey", typeof(string));
            //dtControlPanelInputs.Columns.Add("UniqueID", typeof(int));
            //dtControlPanelInputs.Columns.Add("QuoteUserKey", typeof(string));
            //dtControlPanelInputs.Columns.Add("QuoteUniqueID", typeof(int));

            ////Panel informations
            //dtControlPanelInputs.Columns.Add("ControlPanelNomenclature", typeof(string));
            //dtControlPanelInputs.Columns.Add("PanelDescription", typeof(string));

            //dtControlPanelInputs.Columns.Add("OptionList", typeof(string));
            //dtControlPanelInputs.Columns.Add("ControlVoltage", typeof(string));
            //dtControlPanelInputs.Columns.Add("Price", typeof(decimal));

            return dtControlPanelInputs;
        }

        public static DataTable DtReceiverInputs()
        {
            var dtReceiverInputs = new DataTable("ReceiverInputs");

            //main informations
            dtReceiverInputs.Columns.Add("QuoteID", typeof(int));
            dtReceiverInputs.Columns.Add("QuoteRevision", typeof(int));
            dtReceiverInputs.Columns.Add("QuoteRevisionText", typeof(string));
            dtReceiverInputs.Columns.Add("ItemType", typeof(int));
            dtReceiverInputs.Columns.Add("ItemID", typeof(int));
            dtReceiverInputs.Columns.Add("Username", typeof(string));

            //receiver base informations
            dtReceiverInputs.Columns.Add("ReceiverInstall", typeof(string));

            //receiver #1 info
            dtReceiverInputs.Columns.Add("Receiver1Model", typeof(string));
            dtReceiverInputs.Columns.Add("Receiver1Diameter", typeof(decimal));
            dtReceiverInputs.Columns.Add("Receiver1Length", typeof(decimal));
            dtReceiverInputs.Columns.Add("Receiver1Price", typeof(decimal));
            dtReceiverInputs.Columns.Add("Receiver1ValveModel", typeof(string));
            dtReceiverInputs.Columns.Add("Receiver1ValveManufacturer", typeof(string));
            dtReceiverInputs.Columns.Add("Receiver1ValveSST", typeof(int));
            dtReceiverInputs.Columns.Add("Receiver1ValveQty", typeof(int));
            dtReceiverInputs.Columns.Add("Receiver1ValvePriceIndividual", typeof(decimal));
            dtReceiverInputs.Columns.Add("Receiver1PatchHeaterModel", typeof(string));
            dtReceiverInputs.Columns.Add("Receiver1PatchHeaterQty", typeof(int));
            dtReceiverInputs.Columns.Add("Receiver1PatchHeaterPriceIndividual", typeof(decimal));
            dtReceiverInputs.Columns.Add("Receiver1SightGlassQty", typeof(int));
            dtReceiverInputs.Columns.Add("Receiver1SightGlassPrice", typeof(decimal));
            dtReceiverInputs.Columns.Add("Receiver1InsulationQty", typeof(int));
            dtReceiverInputs.Columns.Add("Receiver1InsulationPrice", typeof(decimal));
            dtReceiverInputs.Columns.Add("Receiver1ReliefValveQty", typeof(int));
            dtReceiverInputs.Columns.Add("Receiver1ReliefValvePrice", typeof(decimal));
            dtReceiverInputs.Columns.Add("Receiver1Weight", typeof(decimal));

            //receiver #2 info
            dtReceiverInputs.Columns.Add("Receiver2Model", typeof(string));
            dtReceiverInputs.Columns.Add("Receiver2Diameter", typeof(decimal));
            dtReceiverInputs.Columns.Add("Receiver2Length", typeof(decimal));
            dtReceiverInputs.Columns.Add("Receiver2Price", typeof(decimal));
            dtReceiverInputs.Columns.Add("Receiver2ValveModel", typeof(string));
            dtReceiverInputs.Columns.Add("Receiver2ValveManufacturer", typeof(string));
            dtReceiverInputs.Columns.Add("Receiver2ValveSST", typeof(int));
            dtReceiverInputs.Columns.Add("Receiver2ValveQty", typeof(int));
            dtReceiverInputs.Columns.Add("Receiver2ValvePriceIndividual", typeof(decimal));
            dtReceiverInputs.Columns.Add("Receiver2PatchHeaterModel", typeof(string));
            dtReceiverInputs.Columns.Add("Receiver2PatchHeaterQty", typeof(int));
            dtReceiverInputs.Columns.Add("Receiver2PatchHeaterPriceIndividual", typeof(decimal));
            dtReceiverInputs.Columns.Add("Receiver2SightGlassQty", typeof(int));
            dtReceiverInputs.Columns.Add("Receiver2SightGlassPrice", typeof(decimal));
            dtReceiverInputs.Columns.Add("Receiver2InsulationQty", typeof(int));
            dtReceiverInputs.Columns.Add("Receiver2InsulationPrice", typeof(decimal));
            dtReceiverInputs.Columns.Add("Receiver2ReliefValveQty", typeof(int));
            dtReceiverInputs.Columns.Add("Receiver2ReliefValvePrice", typeof(decimal));
            dtReceiverInputs.Columns.Add("Receiver2Weight", typeof(decimal));

            //tranfo #1
            dtReceiverInputs.Columns.Add("ReceiverTransformer1Model", typeof(string));
            dtReceiverInputs.Columns.Add("ReceiverTransformer1Qty", typeof(int));
            dtReceiverInputs.Columns.Add("ReceiverTransformer1Price", typeof(decimal));

            //tranfo #2
            dtReceiverInputs.Columns.Add("ReceiverTransformer2Model", typeof(string));
            dtReceiverInputs.Columns.Add("ReceiverTransformer2Qty", typeof(int));
            dtReceiverInputs.Columns.Add("ReceiverTransformer2Price", typeof(decimal));

            //reinforced base
            dtReceiverInputs.Columns.Add("ReceiverReinforcedBaseQty", typeof(int));
            dtReceiverInputs.Columns.Add("ReceiverReinforcedBasePrice", typeof(decimal));
            dtReceiverInputs.Columns.Add("ReceiverReinforcedBaseWeight", typeof(decimal));

            return dtReceiverInputs;
        }

        public static DataTable DtAdditionalItems()
        {
            var dtAdditionalItems = new DataTable("AdditionalItems");

            //main informations
            dtAdditionalItems.Columns.Add("QuoteID", typeof(int));
            dtAdditionalItems.Columns.Add("QuoteRevision", typeof(int));
            dtAdditionalItems.Columns.Add("QuoteRevisionText", typeof(string));
            dtAdditionalItems.Columns.Add("ItemType", typeof(int));
            dtAdditionalItems.Columns.Add("ItemID", typeof(int));
            dtAdditionalItems.Columns.Add("Username", typeof(string));

            dtAdditionalItems.Columns.Add("AdditionnalItemID", typeof(int));
            dtAdditionalItems.Columns.Add("Description", typeof(string));
            dtAdditionalItems.Columns.Add("Quantity", typeof(decimal));
            dtAdditionalItems.Columns.Add("Price", typeof(decimal));

            return dtAdditionalItems;
        }

        public static DataTable DtSecondaryOptions()
        {
            var dtSecondaryOptions = new DataTable("SecondaryOptions");

            dtSecondaryOptions.Columns.Add("QuoteID", typeof(int));
            dtSecondaryOptions.Columns.Add("QuoteRevision", typeof(int));
            dtSecondaryOptions.Columns.Add("QuoteRevisionText", typeof(string));
            dtSecondaryOptions.Columns.Add("ItemType", typeof(int));
            dtSecondaryOptions.Columns.Add("ItemID", typeof(int));
            dtSecondaryOptions.Columns.Add("Username", typeof(string));

            dtSecondaryOptions.Columns.Add("FinMaterial", typeof(string));
            dtSecondaryOptions.Columns.Add("FinMaterialPrice", typeof(decimal));
            dtSecondaryOptions.Columns.Add("TubeMaterial", typeof(string));
            dtSecondaryOptions.Columns.Add("TubeMaterialPrice", typeof(decimal));
            dtSecondaryOptions.Columns.Add("CoilCoating", typeof(string));
            dtSecondaryOptions.Columns.Add("CoilCoatingPrice", typeof(decimal));
            dtSecondaryOptions.Columns.Add("CasingFinish", typeof(string));
            dtSecondaryOptions.Columns.Add("CasingFinishPrice", typeof(decimal));
            dtSecondaryOptions.Columns.Add("LegSize", typeof(int));
            dtSecondaryOptions.Columns.Add("Legs", typeof(string));
            dtSecondaryOptions.Columns.Add("LegsPrice", typeof(decimal));

            return dtSecondaryOptions;
        }

        public static DataTable DtPumpInputs()
        {
            var dtPumpInputs = new DataTable("PumpInputs");

            dtPumpInputs.Columns.Add("QuoteID", typeof(int));
            dtPumpInputs.Columns.Add("QuoteRevision", typeof(int));
            dtPumpInputs.Columns.Add("QuoteRevisionText", typeof(string));
            dtPumpInputs.Columns.Add("ItemType", typeof(int));
            dtPumpInputs.Columns.Add("ItemID", typeof(int));
            dtPumpInputs.Columns.Add("Username", typeof(string));
   
            dtPumpInputs.Columns.Add("PumpNomenclature", typeof(string));
            dtPumpInputs.Columns.Add("PumpType", typeof(string));
            dtPumpInputs.Columns.Add("PumpModel", typeof(string));
            dtPumpInputs.Columns.Add("PumpPrice", typeof(decimal));
            dtPumpInputs.Columns.Add("Impellar", typeof(decimal));
            dtPumpInputs.Columns.Add("FLA", typeof(decimal));
            dtPumpInputs.Columns.Add("Frame", typeof(string));
            dtPumpInputs.Columns.Add("Drawing", typeof(string));
            dtPumpInputs.Columns.Add("PumpBoxDrawing", typeof(string));
            dtPumpInputs.Columns.Add("RPM", typeof(int));
            dtPumpInputs.Columns.Add("HP", typeof(decimal));
            dtPumpInputs.Columns.Add("TotalFeetOfHead", typeof(decimal));
            dtPumpInputs.Columns.Add("NumberOfPump", typeof(string));
            dtPumpInputs.Columns.Add("ExpansionTankKit", typeof(string));
            dtPumpInputs.Columns.Add("ExpansionTankKitModel", typeof(string));
            dtPumpInputs.Columns.Add("ExpansionTankKitPrice", typeof(decimal));
            dtPumpInputs.Columns.Add("Valve", typeof(string));
            dtPumpInputs.Columns.Add("ValveType", typeof(string));
            dtPumpInputs.Columns.Add("ValveCV", typeof(decimal));
            dtPumpInputs.Columns.Add("ValveConnectionSize", typeof(string));
            dtPumpInputs.Columns.Add("ValvePrice", typeof(decimal));
            dtPumpInputs.Columns.Add("TubeDiameter", typeof(string));
            dtPumpInputs.Columns.Add("PumpOption", typeof(string));
            dtPumpInputs.Columns.Add("OptionPrice", typeof(decimal));

            return dtPumpInputs;
        }

        public static DataTable DtOEMCoilPrice()
        {
            var dtOEMCoilPrice = new DataTable("OEMCoilPrice");

            dtOEMCoilPrice.Columns.Add("QuoteID", typeof(int));
            dtOEMCoilPrice.Columns.Add("QuoteRevision", typeof(int));
            dtOEMCoilPrice.Columns.Add("QuoteRevisionText", typeof(string));
            dtOEMCoilPrice.Columns.Add("ItemType", typeof(int));
            dtOEMCoilPrice.Columns.Add("ItemID", typeof(int));
            dtOEMCoilPrice.Columns.Add("Username", typeof(string));
            dtOEMCoilPrice.Columns.Add("PriceID", typeof(int));
            dtOEMCoilPrice.Columns.Add("Input_From", typeof(int));
            dtOEMCoilPrice.Columns.Add("Input_To", typeof(int));
            dtOEMCoilPrice.Columns.Add("Input_Price", typeof(decimal));

            return dtOEMCoilPrice;
        }

        public static DataTable DtOEMCoilDistributors()
        {
            var dtOEMCoilDistributors = new DataTable("OEMCoilDistributors");

            dtOEMCoilDistributors.Columns.Add("QuoteID", typeof(int));
            dtOEMCoilDistributors.Columns.Add("QuoteRevision", typeof(int));
            dtOEMCoilDistributors.Columns.Add("QuoteRevisionText", typeof(string));
            dtOEMCoilDistributors.Columns.Add("ItemType", typeof(int));
            dtOEMCoilDistributors.Columns.Add("ItemID", typeof(int));
            dtOEMCoilDistributors.Columns.Add("Username", typeof(string));
            dtOEMCoilDistributors.Columns.Add("DistributorsID", typeof(int));
            dtOEMCoilDistributors.Columns.Add("Input_Circuit", typeof(int));
            dtOEMCoilDistributors.Columns.Add("Input_Line", typeof(int));
            dtOEMCoilDistributors.Columns.Add("Input_Spigot", typeof(int));
            dtOEMCoilDistributors.Columns.Add("Input_Brand", typeof(string));
            dtOEMCoilDistributors.Columns.Add("Input_Model", typeof(string));

            return dtOEMCoilDistributors;
        }

        public static DataTable DtOEMCoilFlareFittings()
        {
            var dtOEMCoilFlareFittings = new DataTable("OEMCoilFlareFittings");

            dtOEMCoilFlareFittings.Columns.Add("QuoteID", typeof(int));
            dtOEMCoilFlareFittings.Columns.Add("QuoteRevision", typeof(int));
            dtOEMCoilFlareFittings.Columns.Add("QuoteRevisionText", typeof(string));
            dtOEMCoilFlareFittings.Columns.Add("ItemType", typeof(int));
            dtOEMCoilFlareFittings.Columns.Add("ItemID", typeof(int));
            dtOEMCoilFlareFittings.Columns.Add("Username", typeof(string));
            dtOEMCoilFlareFittings.Columns.Add("FlareFittingsID", typeof(int));
            dtOEMCoilFlareFittings.Columns.Add("Input_Quantity", typeof(int));
            dtOEMCoilFlareFittings.Columns.Add("Input_Type", typeof(string));
            dtOEMCoilFlareFittings.Columns.Add("Input_Model", typeof(string));

            return dtOEMCoilFlareFittings;
        }

        public static DataTable DtOEMCoilConnections()
        {
            var dtOEMCoilConnections = new DataTable("OEMCoilConnections");

            dtOEMCoilConnections.Columns.Add("QuoteID", typeof(int));
            dtOEMCoilConnections.Columns.Add("QuoteRevision", typeof(int));
            dtOEMCoilConnections.Columns.Add("QuoteRevisionText", typeof(string));
            dtOEMCoilConnections.Columns.Add("ItemType", typeof(int));
            dtOEMCoilConnections.Columns.Add("ItemID", typeof(int));
            dtOEMCoilConnections.Columns.Add("Username", typeof(string));
            dtOEMCoilConnections.Columns.Add("ConnectionID", typeof(int));
            dtOEMCoilConnections.Columns.Add("Input_Size", typeof(decimal));
            dtOEMCoilConnections.Columns.Add("Input_Length", typeof(decimal));

            return dtOEMCoilConnections;
        }

        public static DataTable DtOEMCoil()
        {
            
            var dtOEMCoil = new DataTable("OEMCoils");

            dtOEMCoil.Columns.Add("QuoteID", typeof(int));
            dtOEMCoil.Columns.Add("QuoteRevision", typeof(int));
            dtOEMCoil.Columns.Add("QuoteRevisionText", typeof(string));
            dtOEMCoil.Columns.Add("ItemType", typeof(int));
            dtOEMCoil.Columns.Add("ItemID", typeof(int));
            dtOEMCoil.Columns.Add("Username", typeof(string));
            dtOEMCoil.Columns.Add("Input_Tag", typeof(string));
            dtOEMCoil.Columns.Add("Input_Quantity", typeof(int));
            dtOEMCoil.Columns.Add("Input_Model", typeof(string));
            dtOEMCoil.Columns.Add("Input_CustomerDrawingNumber", typeof(string));
            dtOEMCoil.Columns.Add("Input_RefplusDrawingNumber", typeof(string));
            dtOEMCoil.Columns.Add("Input_CasingMaterial", typeof(string));
            dtOEMCoil.Columns.Add("Input_CasingThickness", typeof(decimal));
            dtOEMCoil.Columns.Add("Input_FinMaterial", typeof(string));
            dtOEMCoil.Columns.Add("Input_FinThickness", typeof(decimal));
            dtOEMCoil.Columns.Add("Input_TubeMaterial", typeof(string));
            dtOEMCoil.Columns.Add("Input_TubeThickness", typeof(decimal));
            dtOEMCoil.Columns.Add("Input_ReturnBendsQuantity", typeof(int));
            dtOEMCoil.Columns.Add("Input_EndPlateQuantity", typeof(int));
            dtOEMCoil.Columns.Add("Input_EndPlateHeight", typeof(decimal));
            dtOEMCoil.Columns.Add("Input_EndPlateWidth", typeof(decimal));
            dtOEMCoil.Columns.Add("Input_TopPlateQuantity", typeof(int));
            dtOEMCoil.Columns.Add("Input_TopPlateHeight", typeof(decimal));
            dtOEMCoil.Columns.Add("Input_TopPlateWidth", typeof(decimal));
            dtOEMCoil.Columns.Add("Input_BottomPlateQuantity", typeof(int));
            dtOEMCoil.Columns.Add("Input_BottomPlateHeight", typeof(decimal));
            dtOEMCoil.Columns.Add("Input_BottomPlateWidth", typeof(decimal));
            dtOEMCoil.Columns.Add("Input_CenterPlateQuantity", typeof(int));
            dtOEMCoil.Columns.Add("Input_CenterPlateHeight", typeof(decimal));
            dtOEMCoil.Columns.Add("Input_CenterPlateWidth", typeof(decimal));
            dtOEMCoil.Columns.Add("Input_WeldedCasing", typeof(string));
            dtOEMCoil.Columns.Add("WeldedCasing", typeof(int));
            dtOEMCoil.Columns.Add("NumberOfHeader", typeof(int));
            dtOEMCoil.Columns.Add("Input_FlareFittings", typeof(string));
            dtOEMCoil.Columns.Add("FlareFittings", typeof(int));
            dtOEMCoil.Columns.Add("Input_Distributors", typeof(string));
            dtOEMCoil.Columns.Add("Distributors", typeof(int));
            dtOEMCoil.Columns.Add("Input_AuxiliarySideConnection", typeof(string));
            dtOEMCoil.Columns.Add("AuxiliarySideConnection", typeof(int));
            dtOEMCoil.Columns.Add("Input_WeldNut", typeof(string));
            dtOEMCoil.Columns.Add("WeldNut", typeof(int));
            dtOEMCoil.Columns.Add("Input_WeldNutQuantity", typeof(int));
            dtOEMCoil.Columns.Add("Input_DrainPan", typeof(string));
            dtOEMCoil.Columns.Add("DrainPan", typeof(int));
            dtOEMCoil.Columns.Add("DrainPanQuantity", typeof(int));
            dtOEMCoil.Columns.Add("DrainPanMaterial", typeof(string));
            dtOEMCoil.Columns.Add("DrainPanHeight", typeof(decimal));
            dtOEMCoil.Columns.Add("DrainPanWidth", typeof(decimal));
            dtOEMCoil.Columns.Add("Input_Damper", typeof(string));
            dtOEMCoil.Columns.Add("Damper", typeof(int));
            dtOEMCoil.Columns.Add("DamperQuantity", typeof(int));
            dtOEMCoil.Columns.Add("DamperHeight", typeof(decimal));
            dtOEMCoil.Columns.Add("DamperWidth", typeof(decimal));
            dtOEMCoil.Columns.Add("Input_SpecialCustomFittings", typeof(string));
            dtOEMCoil.Columns.Add("SpecialCustomFittings", typeof(int));
            dtOEMCoil.Columns.Add("SpecialCustomFittingsDescription", typeof(string));
            dtOEMCoil.Columns.Add("SpecialCustomFittingsEstimatedCost", typeof(decimal));
            dtOEMCoil.Columns.Add("Input_ThreadedConnections", typeof(string));
            dtOEMCoil.Columns.Add("ThreadedConnections", typeof(int));
            dtOEMCoil.Columns.Add("ThreadedConnectionsQuantity", typeof(int));
            dtOEMCoil.Columns.Add("ThreadedConnectionsDiameter", typeof(decimal));
            dtOEMCoil.Columns.Add("ThreadedConnectionsVentQuantity", typeof(int));
            dtOEMCoil.Columns.Add("ThreadedConnectionsSpigotQuantity", typeof(int));
            dtOEMCoil.Columns.Add("Input_CoilComplexity", typeof(string));
            dtOEMCoil.Columns.Add("Input_ProfitMargin", typeof(decimal));
            dtOEMCoil.Columns.Add("Input_ExchangeRate", typeof(decimal));
            dtOEMCoil.Columns.Add("Input_AdditionalInformations", typeof(string));
            dtOEMCoil.Columns.Add("MaterialCost", typeof(decimal));
            dtOEMCoil.Columns.Add("LabourCalculated", typeof(decimal));
            dtOEMCoil.Columns.Add("LabourCalculatedWithCorrection", typeof(decimal));
            dtOEMCoil.Columns.Add("ManufacturingOverhead", typeof(decimal));
            dtOEMCoil.Columns.Add("HourlyRate", typeof(decimal));
            dtOEMCoil.Columns.Add("NetCostOfOEMCoil", typeof(decimal));
            dtOEMCoil.Columns.Add("CoilWeight", typeof(decimal));

            return dtOEMCoil;
        }

        public static DataTable DtEvaporator()
        {
            var dtEvaporator = new DataTable("Evaporators");

            dtEvaporator.Columns.Add("QuoteID", typeof(int));
            dtEvaporator.Columns.Add("QuoteRevision", typeof(int));
            dtEvaporator.Columns.Add("QuoteRevisionText", typeof(string));
            dtEvaporator.Columns.Add("ItemType", typeof(int));
            dtEvaporator.Columns.Add("ItemID", typeof(int));
            dtEvaporator.Columns.Add("Username", typeof(string));
          
            dtEvaporator.Columns.Add("AttachToCondensingUnit", typeof(int));
            dtEvaporator.Columns.Add("CondensingUnitItemID", typeof(int));
            dtEvaporator.Columns.Add("CondensingUnitSystemName", typeof(string));
            dtEvaporator.Columns.Add("Tag", typeof(string));
            dtEvaporator.Columns.Add("Quantity", typeof(int));
            dtEvaporator.Columns.Add("SuctionTemperature", typeof(decimal));
            dtEvaporator.Columns.Add("LiquidTemperature", typeof(decimal));
            dtEvaporator.Columns.Add("RefrigerantText", typeof(string));
            dtEvaporator.Columns.Add("DefrostText", typeof(string));
            dtEvaporator.Columns.Add("VoltageText", typeof(string));
            dtEvaporator.Columns.Add("FPIText", typeof(string));
            dtEvaporator.Columns.Add("TemperatureRangeMin", typeof(decimal));
            dtEvaporator.Columns.Add("TemperatureRangeMax", typeof(decimal));
            dtEvaporator.Columns.Add("RequiredCapacity", typeof(decimal));
            dtEvaporator.Columns.Add("SelectionTypeText", typeof(string));
            dtEvaporator.Columns.Add("ModelText", typeof(string));
            dtEvaporator.Columns.Add("CoilCoatingText", typeof(string));
            dtEvaporator.Columns.Add("CoilCoatingPrice", typeof(decimal));
            dtEvaporator.Columns.Add("FinMaterialText", typeof(string));
            dtEvaporator.Columns.Add("FinMaterialPrice", typeof(decimal));
            dtEvaporator.Columns.Add("Description", typeof(string));
            dtEvaporator.Columns.Add("Price", typeof(decimal));
            dtEvaporator.Columns.Add("RefrigerantChargeMultiplier", typeof(decimal));
            dtEvaporator.Columns.Add("MotorMCA", typeof(decimal));
            dtEvaporator.Columns.Add("MotorMOP", typeof(decimal));
            dtEvaporator.Columns.Add("MotorFUSE", typeof(decimal));
            dtEvaporator.Columns.Add("HeaterFLA", typeof(decimal));
            dtEvaporator.Columns.Add("HeaterMCA", typeof(decimal));
            dtEvaporator.Columns.Add("HeaterFUSE", typeof(decimal));
            dtEvaporator.Columns.Add("DimensionDrawing", typeof(string));
            dtEvaporator.Columns.Add("ElectricalDrawing", typeof(string));

            dtEvaporator.Columns.Add("EvaporatorID", typeof(string));
            dtEvaporator.Columns.Add("CapacityAt10TD", typeof(decimal));
            dtEvaporator.Columns.Add("DefrostType", typeof(string));
            dtEvaporator.Columns.Add("EvaporatorCapacity", typeof(decimal));
            dtEvaporator.Columns.Add("EvaporatorWeight", typeof(decimal));
            dtEvaporator.Columns.Add("EvaporatorCoilQty", typeof(decimal));
            dtEvaporator.Columns.Add("EvaporatorFanQty", typeof(decimal));
            dtEvaporator.Columns.Add("EvaporatorHeaterQTY", typeof(decimal));
            dtEvaporator.Columns.Add("EvaporatorCFM", typeof(decimal));
            dtEvaporator.Columns.Add("EvaporatorRefCharge", typeof(decimal));
            dtEvaporator.Columns.Add("EvaporatorPrice", typeof(decimal));
            dtEvaporator.Columns.Add("LowVelocity", typeof(int));
            dtEvaporator.Columns.Add("Liquid", typeof(decimal));
            dtEvaporator.Columns.Add("Suction", typeof(decimal));
            dtEvaporator.Columns.Add("HotGas", typeof(decimal));
            dtEvaporator.Columns.Add("ConnQty", typeof(decimal));
            dtEvaporator.Columns.Add("FanArrangement", typeof(decimal));
            dtEvaporator.Columns.Add("SSucTemp", typeof(decimal));
            dtEvaporator.Columns.Add("FSucTemp", typeof(decimal));
            dtEvaporator.Columns.Add("EvaporatorType", typeof(string));
            dtEvaporator.Columns.Add("CoilType", typeof(string));
            dtEvaporator.Columns.Add("CoilTubes", typeof(int));
            dtEvaporator.Columns.Add("CoilRow", typeof(int));
            dtEvaporator.Columns.Add("CoilFPI", typeof(int));
            dtEvaporator.Columns.Add("CoilLength", typeof(decimal));
            dtEvaporator.Columns.Add("CoilModel", typeof(string));
            dtEvaporator.Columns.Add("EvaporatorTypeDesc", typeof(string));
            dtEvaporator.Columns.Add("EvaporatorStyleDesc", typeof(string));
            dtEvaporator.Columns.Add("DefrostTypeID", typeof(string));
            dtEvaporator.Columns.Add("DefrostTypeDescription", typeof(string));
            dtEvaporator.Columns.Add("UnitID", typeof(string));
            dtEvaporator.Columns.Add("VoltageID", typeof(decimal));
            dtEvaporator.Columns.Add("StandardFPI", typeof(decimal));
            dtEvaporator.Columns.Add("CurrentFPI", typeof(decimal));
            dtEvaporator.Columns.Add("FPIMultiplier", typeof(decimal));
            dtEvaporator.Columns.Add("VoltDescription", typeof(string));
            dtEvaporator.Columns.Add("VoltsValue", typeof(decimal));
            dtEvaporator.Columns.Add("PhaseNumber", typeof(decimal));
            dtEvaporator.Columns.Add("HzValue", typeof(decimal));
            dtEvaporator.Columns.Add("WattMultiplier", typeof(decimal));
            dtEvaporator.Columns.Add("HeaterFLAMultiplier", typeof(decimal));
            dtEvaporator.Columns.Add("PowerFactorAdjustement", typeof(decimal));
            dtEvaporator.Columns.Add("MotorCoilArr", typeof(string));
            dtEvaporator.Columns.Add("PowerSupply", typeof(string));
            dtEvaporator.Columns.Add("CapacityMultiplier", typeof(decimal));
            dtEvaporator.Columns.Add("Motor", typeof(string));
            dtEvaporator.Columns.Add("MotorHP", typeof(decimal));
            dtEvaporator.Columns.Add("MotorRPM", typeof(decimal));
            dtEvaporator.Columns.Add("MotorRotType", typeof(string));
            dtEvaporator.Columns.Add("MotorFrameType", typeof(string));
            dtEvaporator.Columns.Add("MotorShaftLength", typeof(decimal));
            dtEvaporator.Columns.Add("MotorPrice", typeof(decimal));
            dtEvaporator.Columns.Add("MotorFLA", typeof(decimal));
            dtEvaporator.Columns.Add("MotorMount", typeof(string));
            dtEvaporator.Columns.Add("MotorMountFanSize", typeof(decimal));
            dtEvaporator.Columns.Add("MotorMountFrameSize", typeof(decimal));
            dtEvaporator.Columns.Add("MotorMountComposition", typeof(string));
            dtEvaporator.Columns.Add("MotorMountPrice", typeof(decimal));
            dtEvaporator.Columns.Add("Fan", typeof(string));
            dtEvaporator.Columns.Add("FanDiameter", typeof(decimal));
            dtEvaporator.Columns.Add("FanBladeQuantity", typeof(int));
            dtEvaporator.Columns.Add("FanRotationType", typeof(string));
            dtEvaporator.Columns.Add("FanComposition", typeof(string));
            dtEvaporator.Columns.Add("FanPitch", typeof(decimal));
            dtEvaporator.Columns.Add("FanPrice", typeof(decimal));
            dtEvaporator.Columns.Add("FanGuard", typeof(string));
            dtEvaporator.Columns.Add("FanGuardFanSize", typeof(decimal));
            dtEvaporator.Columns.Add("FanGuardComposition", typeof(string));             
            dtEvaporator.Columns.Add("DefrostHeater", typeof(string));
            dtEvaporator.Columns.Add("DefrostHeaterType", typeof(string));
            dtEvaporator.Columns.Add("DefrostHeaterVolt", typeof(int));
            dtEvaporator.Columns.Add("DefrostHeaterWatt", typeof(int));
            dtEvaporator.Columns.Add("DefrostHeaterDesc", typeof(string));
            dtEvaporator.Columns.Add("DefrostHeaterPrice", typeof(decimal));
            dtEvaporator.Columns.Add("DefrostHeaterKilowatts", typeof(decimal));
            dtEvaporator.Columns.Add("CapacityMultiplied", typeof(decimal));
            dtEvaporator.Columns.Add("TD_FOR_CAPACITY", typeof(decimal));
            dtEvaporator.Columns.Add("CAPACITY_FOR_TD", typeof(decimal));

            return dtEvaporator;
        }

        public static DataTable DtEvaporatorOptions()
        {
            //create datatable
            var dtEvaporatorOption = new DataTable("EvaporatorOption");
            //add columns
            dtEvaporatorOption.Columns.Add("QuoteID", typeof(int));
            dtEvaporatorOption.Columns.Add("QuoteRevision", typeof(int));
            dtEvaporatorOption.Columns.Add("QuoteRevisionText", typeof(string));
            dtEvaporatorOption.Columns.Add("ItemType", typeof(int));
            dtEvaporatorOption.Columns.Add("ItemID", typeof(int));
            dtEvaporatorOption.Columns.Add("Username", typeof(string));

            dtEvaporatorOption.Columns.Add("GroupName", typeof(string));
            dtEvaporatorOption.Columns.Add("Description", typeof(string));
            dtEvaporatorOption.Columns.Add("Price", typeof(decimal));

            return dtEvaporatorOption;
        }

        public static DataTable DtWaterEvaporatorOptions()
        {
            //create datatable
            var dtEvaporatorOption = new DataTable("WaterEvaporatorOption");
            //add columns
            dtEvaporatorOption.Columns.Add("QuoteID", typeof(int));
            dtEvaporatorOption.Columns.Add("QuoteRevision", typeof(int));
            dtEvaporatorOption.Columns.Add("QuoteRevisionText", typeof(string));
            dtEvaporatorOption.Columns.Add("ItemType", typeof(int));
            dtEvaporatorOption.Columns.Add("ItemID", typeof(int));
            dtEvaporatorOption.Columns.Add("Username", typeof(string));

            dtEvaporatorOption.Columns.Add("GroupName", typeof(string));
            dtEvaporatorOption.Columns.Add("Description", typeof(string));
            dtEvaporatorOption.Columns.Add("Price", typeof(decimal));

            return dtEvaporatorOption;
        }


        public static DataTable QuoteTable()
        {
            var dtData = new DataTable("QUOTE_DATA");

            dtData.Columns.Add("QuoteID", typeof(int));
            dtData.Columns.Add("QuoteRevision", typeof(int));
            dtData.Columns.Add("QuoteRevisionText", typeof(string));

            dtData.Columns.Add("ProjectName", typeof(string));
            dtData.Columns.Add("QuotationDate", typeof(DateTime));
            dtData.Columns.Add("QuotationBy", typeof(string));
            dtData.Columns.Add("QuotationByUsername", typeof(string));
            dtData.Columns.Add("QuotationByContactID", typeof(int));
            dtData.Columns.Add("QuotationByGroupID", typeof(int));
            dtData.Columns.Add("QuotationSite", typeof(string));
            dtData.Columns.Add("Email", typeof(string));
            dtData.Columns.Add("Rep", typeof(string));
            dtData.Columns.Add("Engineer", typeof(string));
            dtData.Columns.Add("ClientRefNumber", typeof(string));
            dtData.Columns.Add("EstimateNumber", typeof(string));
            dtData.Columns.Add("Terms", typeof(string));
            dtData.Columns.Add("Delivery", typeof(string));
            dtData.Columns.Add("Freight", typeof(string));
            dtData.Columns.Add("FreightPrice", typeof(decimal));
            dtData.Columns.Add("Multiplier", typeof(decimal));
            dtData.Columns.Add("ContactID", typeof(int));
            dtData.Columns.Add("GroupID", typeof(int));
            dtData.Columns.Add("ContactName", typeof(string));
            dtData.Columns.Add("ContactEmail", typeof(string));
            dtData.Columns.Add("ContactPhone", typeof(string));
            dtData.Columns.Add("Address", typeof(string));
            dtData.Columns.Add("City", typeof(string));
            dtData.Columns.Add("State", typeof(string));
            dtData.Columns.Add("Country", typeof(string));
            dtData.Columns.Add("ZipCode", typeof(string));
            dtData.Columns.Add("Notes", typeof(string));
            dtData.Columns.Add("Currency", typeof(string));
            dtData.Columns.Add("Attention", typeof(string));
            dtData.Columns.Add("LastUpdateBy", typeof(string));
            //dtData.Columns.Add("CompanyName", typeof(string));

            return dtData;
        }

        public static DataTable DtCondenser()
        {
            var dtData = new DataTable("Condensers");

            dtData.Columns.Add("QuoteID", typeof(int));
            dtData.Columns.Add("QuoteRevision", typeof(int));
            dtData.Columns.Add("QuoteRevisionText", typeof(string));
            dtData.Columns.Add("ItemType", typeof(int));
            dtData.Columns.Add("ItemID", typeof(int));
            dtData.Columns.Add("Username", typeof(string));

            dtData.Columns.Add("Input_AttachedToCondensingUnit", typeof(int));
            dtData.Columns.Add("Input_CondensingUnitSystemName", typeof(string));
            dtData.Columns.Add("Input_CondensingUnitItemID", typeof(int));
            dtData.Columns.Add("Input_Tag", typeof(string));
            dtData.Columns.Add("Quantity", typeof(int));
            dtData.Columns.Add("Input_Rating", typeof(int));
            dtData.Columns.Add("Input_RatingModel", typeof(string));
            dtData.Columns.Add("Input_Altitude", typeof(decimal));
            dtData.Columns.Add("Input_AmbientTemperature", typeof(decimal));
            dtData.Columns.Add("Input_FanArrangement", typeof(string));
            dtData.Columns.Add("Input_AirFlowType", typeof(string));
            dtData.Columns.Add("Input_TypeOfCondenser", typeof(string));
            dtData.Columns.Add("Input_CondenserSerie", typeof(string));
            dtData.Columns.Add("Input_Voltage", typeof(string));
            dtData.Columns.Add("Input_TotalHeatRecovery", typeof(decimal));
            dtData.Columns.Add("Input_FinsPerInch", typeof(string));

            dtData.Columns.Add("CondenserType", typeof(string));
            dtData.Columns.Add("Motor", typeof(string));
            dtData.Columns.Add("CoilArr", typeof(string));
            dtData.Columns.Add("FanWide", typeof(int));
            dtData.Columns.Add("FanLong", typeof(int));
            dtData.Columns.Add("Row", typeof(int));
            dtData.Columns.Add("FPI", typeof(int));
            dtData.Columns.Add("FinType", typeof(string));
            dtData.Columns.Add("FinHeight", typeof(decimal));
            dtData.Columns.Add("FinLength", typeof(decimal));
            dtData.Columns.Add("CondenserCircQty", typeof(decimal));
            dtData.Columns.Add("Capacity_per_Circuit", typeof(decimal));
            dtData.Columns.Add("THR_at_1F", typeof(decimal));
            dtData.Columns.Add("ConnDischarge", typeof(decimal));
            dtData.Columns.Add("ConnLiquid", typeof(decimal));
            dtData.Columns.Add("ConnQty", typeof(decimal));
            dtData.Columns.Add("RefChargeSummer", typeof(decimal));
            dtData.Columns.Add("RefChargeWinter", typeof(decimal));
            dtData.Columns.Add("ShipWeight", typeof(decimal));
            dtData.Columns.Add("CondenserPrice", typeof(decimal));
            dtData.Columns.Add("Active", typeof(string));
            dtData.Columns.Add("CondenserSelectionType", typeof(int));
            dtData.Columns.Add("CondenserModel", typeof(string));
            dtData.Columns.Add("ApprovalDrawing", typeof(string));
            dtData.Columns.Add("VoltageID", typeof(int));
            dtData.Columns.Add("VoltageDescription", typeof(string));
            dtData.Columns.Add("AirFlowType", typeof(string));
            dtData.Columns.Add("TotalHeatRecoveryPercentage", typeof(decimal));
            dtData.Columns.Add("Altitude", typeof(decimal));
            dtData.Columns.Add("MotorFLA", typeof(decimal));
            dtData.Columns.Add("MotorHP", typeof(string));
            dtData.Columns.Add("MotorRPM", typeof(string));

            dtData.Columns.Add("MotorID", typeof(string));
            dtData.Columns.Add("MotorHPNumber", typeof(decimal));
            dtData.Columns.Add("MotorRPMNumber", typeof(decimal));
            dtData.Columns.Add("MotorRotType", typeof(string));
            dtData.Columns.Add("MotorFrameType", typeof(string));
            dtData.Columns.Add("MotorShaftLength", typeof(decimal));
            dtData.Columns.Add("MotorMount", typeof(string));
            dtData.Columns.Add("MotorMountFanSize", typeof(decimal));
            dtData.Columns.Add("MotorMountFrameSize", typeof(decimal));
            dtData.Columns.Add("MotorMountComposition", typeof(string));
            dtData.Columns.Add("Fan", typeof(string));
            dtData.Columns.Add("FanDiameter", typeof(decimal));
            dtData.Columns.Add("FanBladeQuantity", typeof(int));
            dtData.Columns.Add("FanRotationType", typeof(string));
            dtData.Columns.Add("FanComposition", typeof(string));
            dtData.Columns.Add("FanPitch", typeof(decimal));
            dtData.Columns.Add("FanGuard", typeof(string));
            dtData.Columns.Add("FanGuardFanSize", typeof(decimal));
            dtData.Columns.Add("FanGuardComposition", typeof(string));
            dtData.Columns.Add("CoilModel", typeof(string));
            dtData.Columns.Add("MCA", typeof(decimal));
            dtData.Columns.Add("MOP", typeof(decimal));
            dtData.Columns.Add("FUSE", typeof(decimal));

            dtData.Columns.Add("RatioTD", typeof(decimal));
            dtData.Columns.Add("TargetCapacity", typeof(decimal));
            dtData.Columns.Add("CurrentCapacity", typeof(decimal));
            dtData.Columns.Add("Target_TD_Per_Condenser", typeof(decimal));
            dtData.Columns.Add("TDDifference", typeof(decimal));
            dtData.Columns.Add("Target_Ambient", typeof(decimal));
            dtData.Columns.Add("Final_Ambient", typeof(decimal));
            dtData.Columns.Add("Final_CapacityPerTD", typeof(decimal));
            dtData.Columns.Add("Final_Capacity", typeof(decimal));
            dtData.Columns.Add("Final_Circuit", typeof(int));
            dtData.Columns.Add("Final_CircuitCondenserTHRPerTDDifference", typeof(decimal));
            dtData.Columns.Add("Final_AmbientTD", typeof(decimal));

            return dtData;
        }

        public static DataTable DtFluidCooler()
        {
            var dtData = new DataTable("FluidCoolers");

            dtData.Columns.Add("QuoteID", typeof(int));
            dtData.Columns.Add("QuoteRevision", typeof(int));
            dtData.Columns.Add("QuoteRevisionText", typeof(string));
            dtData.Columns.Add("ItemType", typeof(int));
            dtData.Columns.Add("ItemID", typeof(int));
            dtData.Columns.Add("Username", typeof(string));

            dtData.Columns.Add("Input_Tag", typeof(string));
            dtData.Columns.Add("Quantity", typeof(int));
            dtData.Columns.Add("Input_Filter", typeof(string));
            dtData.Columns.Add("Input_Model", typeof(string));
            dtData.Columns.Add("Input_Location", typeof(string));
            dtData.Columns.Add("Input_EDB", typeof(decimal));
            dtData.Columns.Add("Input_Altitude", typeof(decimal));
            dtData.Columns.Add("Input_ELT", typeof(decimal));
            dtData.Columns.Add("Input_FluidType", typeof(string));
            dtData.Columns.Add("Input_Concentration", typeof(decimal));
            dtData.Columns.Add("Input_FluidTypeName", typeof(string));
            dtData.Columns.Add("Input_SpecificHeat", typeof(decimal));
            dtData.Columns.Add("Input_Density", typeof(decimal));
            dtData.Columns.Add("Input_Viscosity", typeof(decimal));
            dtData.Columns.Add("Input_ThermalConductivity", typeof(decimal));
            dtData.Columns.Add("Input_Voltage", typeof(string));
            dtData.Columns.Add("Input_MaxFluidPressure", typeof(decimal));
            dtData.Columns.Add("Input_UnitType", typeof(string));
            dtData.Columns.Add("Input_FanArrangement", typeof(string));
            dtData.Columns.Add("Input_LLT", typeof(decimal));
            dtData.Columns.Add("Input_USGPM_MBH", typeof(string));
            dtData.Columns.Add("Input_USGPM", typeof(decimal));
            dtData.Columns.Add("Input_MBH", typeof(decimal));
            dtData.Columns.Add("Input_RatingLLT", typeof(int));
            dtData.Columns.Add("Input_RatingGPM", typeof(int));
            dtData.Columns.Add("Input_AirFlowType", typeof(string));
            dtData.Columns.Add("Input_FPI", typeof(string));
            dtData.Columns.Add("ApprovalDrawing", typeof(string));

            dtData.Columns.Add("CFM", typeof(int));
            dtData.Columns.Add("Motor", typeof(string));
            dtData.Columns.Add("Coilarr", typeof(string));
            dtData.Columns.Add("Fanwide", typeof(int));
            dtData.Columns.Add("Fanlong", typeof(int));
            dtData.Columns.Add("FanQty", typeof(int));
            dtData.Columns.Add("Row", typeof(int));
            dtData.Columns.Add("Fpi", typeof(int));
            dtData.Columns.Add("Fin", typeof(string));
            dtData.Columns.Add("Tubes", typeof(int));
            dtData.Columns.Add("FinHeight", typeof(double));
            dtData.Columns.Add("coillength", typeof(double));
            dtData.Columns.Add("cir1", typeof(int));
            dtData.Columns.Add("TCFM", typeof(int));

            //2011-01-31 : new columns from fluid cooler change
            dtData.Columns.Add("AirFlow", typeof(string));
            dtData.Columns.Add("REFPLUS_FluidXRefModel", typeof(string));
            dtData.Columns.Add("ECOSAIRE_FluidXRefModel", typeof(string));
            dtData.Columns.Add("DECTRON_FluidXRefModel", typeof(string));
            dtData.Columns.Add("CIRCULAIRE_FluidXRefModel", typeof(string));
            dtData.Columns.Add("Price", typeof(decimal));
            dtData.Columns.Add("Weight", typeof(decimal));

            dtData.Columns.Add("Cap", typeof(decimal));
            dtData.Columns.Add("LeavingLiquid", typeof(decimal));
            dtData.Columns.Add("PressureDrop", typeof(decimal));
            dtData.Columns.Add("LeavingAir", typeof(decimal));
            dtData.Columns.Add("LiquidVelocity", typeof(decimal));
            dtData.Columns.Add("GPM", typeof(decimal));
            dtData.Columns.Add("FluidCoolerModel", typeof(string));
            //2011-01-31 : renamed column from fluid cooler change
            dtData.Columns.Add("FluidCoolerPrice", typeof(decimal));
            dtData.Columns.Add("ConnectionSize", typeof(decimal));
            dtData.Columns.Add("CoilFaceArea", typeof(decimal));
            dtData.Columns.Add("FaceVelocity", typeof(decimal));
            dtData.Columns.Add("AirPressureDrop", typeof(decimal));
            dtData.Columns.Add("EnteringDryBulb", typeof(decimal));
            dtData.Columns.Add("EnteringLiquidTemperature", typeof(decimal));
            dtData.Columns.Add("FluidType", typeof(string));
            dtData.Columns.Add("Concentration", typeof(decimal));
            dtData.Columns.Add("Altitude", typeof(decimal));
            dtData.Columns.Add("PowerSupply", typeof(string));
            dtData.Columns.Add("SpecificHeat", typeof(decimal));
            dtData.Columns.Add("Density", typeof(decimal));
            dtData.Columns.Add("Viscosity", typeof(decimal));
            dtData.Columns.Add("ThermalConductivity", typeof(decimal));
            dtData.Columns.Add("FluidTypeName", typeof(string));
            dtData.Columns.Add("VoltageID", typeof(int));
            dtData.Columns.Add("AirFlowType", typeof(string));
            dtData.Columns.Add("FLA", typeof(decimal));
            dtData.Columns.Add("PumpFLA", typeof(decimal));
            dtData.Columns.Add("ShipWeight", typeof(decimal));
            dtData.Columns.Add("Dwg", typeof(string));
            dtData.Columns.Add("FanHP", typeof(string));
            dtData.Columns.Add("FanRPM", typeof(string));

            return dtData;
        }

        public static DataTable DtQuotePricingCoverPage()
        {
            var dtData = new DataTable("PricingCoverPage");

            dtData.Columns.Add("QuoteID", typeof(int));
            dtData.Columns.Add("QuoteRevision", typeof(int));
            dtData.Columns.Add("QuoteRevisionText", typeof(string));

            dtData.Columns.Add("Tag", typeof(string));
            dtData.Columns.Add("Description", typeof(string));
            dtData.Columns.Add("Quantity", typeof(int));
            dtData.Columns.Add("UnitPrice", typeof(decimal));
            dtData.Columns.Add("TotalPrice", typeof(decimal));

            return dtData;
        }

        public static DataTable DtGravityCoil()
        {
            var dtData = new DataTable("GravityCoils");

            dtData.Columns.Add("QuoteID", typeof(int));
            dtData.Columns.Add("QuoteRevision", typeof(int));
            dtData.Columns.Add("QuoteRevisionText", typeof(string));
            dtData.Columns.Add("ItemType", typeof(int));
            dtData.Columns.Add("ItemID", typeof(int));
            dtData.Columns.Add("Username", typeof(string));

            dtData.Columns.Add("Input_Tag", typeof(string));
            dtData.Columns.Add("Quantity", typeof(int));
            dtData.Columns.Add("Description", typeof(string));
            dtData.Columns.Add("CapacityInput", typeof(int));
            dtData.Columns.Add("MinMultiplierInput", typeof(string));
            dtData.Columns.Add("MaxMultiplierInput", typeof(string));
            dtData.Columns.Add("FaceTubesInput", typeof(string));
            dtData.Columns.Add("RefrigerantInput", typeof(string));
            dtData.Columns.Add("CoilCoatingInput", typeof(string));
            dtData.Columns.Add("SSTInput", typeof(int));
            dtData.Columns.Add("TDInput", typeof(int));
            dtData.Columns.Add("SelectionInput", typeof(string));

            dtData.Columns.Add("Model", typeof(string));
            dtData.Columns.Add("Evaporator", typeof(string));
            dtData.Columns.Add("Gravity", typeof(string));
            dtData.Columns.Add("AirDefrost", typeof(string));
            dtData.Columns.Add("FaceTubes", typeof(int));
            dtData.Columns.Add("Slab", typeof(int));
            dtData.Columns.Add("FPI", typeof(string));
            dtData.Columns.Add("FinPattern", typeof(string));
            dtData.Columns.Add("FinLength", typeof(int));
            dtData.Columns.Add("Capacity", typeof(int));
            dtData.Columns.Add("ListPrice", typeof(decimal));
            dtData.Columns.Add("CoatingPrice", typeof(decimal));
            dtData.Columns.Add("Depth", typeof(int));
            dtData.Columns.Add("Height", typeof(string));
            dtData.Columns.Add("Width", typeof(string));
            dtData.Columns.Add("RefrigerantCharge", typeof(decimal));
            dtData.Columns.Add("ShippingWeight", typeof(int));
            dtData.Columns.Add("SuctionTemp", typeof(int));
            dtData.Columns.Add("CapacityPerTD", typeof(decimal));
            //2012-05-23 : #1355 : adding dwg name to all reports
            dtData.Columns.Add("ApprovalDrawing", typeof(string));

            return dtData;
        }

        public static DataTable DtQuickWaterEvaporator()
        {
            //create datatable
            var dtQuickWaterEvaporator = new DataTable("QuickWaterEvaporator");
            //add columns

            dtQuickWaterEvaporator.Columns.Add("QuoteID", typeof(int));
            dtQuickWaterEvaporator.Columns.Add("QuoteRevision", typeof(int));
            dtQuickWaterEvaporator.Columns.Add("QuoteRevisionText", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("ItemType", typeof(int));
            dtQuickWaterEvaporator.Columns.Add("ItemID", typeof(int));
            dtQuickWaterEvaporator.Columns.Add("Username", typeof(string));
            
            //inputs
            dtQuickWaterEvaporator.Columns.Add("Tag", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("Quantity", typeof(int));
            dtQuickWaterEvaporator.Columns.Add("EvaporatorID", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("Description", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("Input_VoltageID", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("Input_VoltDescription", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("Input_EDB", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("Input_EWB", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("Input_Altitude", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("Input_FluidTypeID", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("Input_FluidType", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("Input_Concentration", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("Input_EnteringLiquidTemperature", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("Input_GPM_LLT", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("Input_GPM", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("Input_LeavingLiquidTemperature", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("Input_NumberOfCircuits", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("Input_FPI", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("Input_FinMaterialID", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("Input_FinMaterialText", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("Input_CoilCoatingID", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("Input_CoilCoatingText", typeof(string));

            dtQuickWaterEvaporator.Columns.Add("CapacityAt10TD", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("EvaporatorWeight", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("EvaporatorCoilQty", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("EvaporatorFanQty", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("EvaporatorHeaterQTY", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("EvaporatorCFM", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("EvaporatorPrice", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("FanArrangement", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("DefrostTypeID", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("DefrostTypeDescription", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("VoltsValue", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("PhaseNumber", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("WattMultiplier", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("HeaterFLAMultiplier", typeof(decimal));
          

            dtQuickWaterEvaporator.Columns.Add("Motor", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("MotorHP", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("MotorRPM", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("MotorRotType", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("MotorFrameType", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("MotorShaftLength", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("MotorPrice", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("MotorFLA", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("MotorMount", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("MotorMountFanSize", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("MotorMountFrameSize", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("MotorMountComposition", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("MotorMountPrice", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("Fan", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("FanDiameter", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("FanBladeQuantity", typeof(int));
            dtQuickWaterEvaporator.Columns.Add("FanRotationType", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("FanComposition", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("FanPitch", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("FanPrice", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("FanGuard", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("FanGuardFanSize", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("FanGuardComposition", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("DefrostHeater", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("DefrostHeaterType", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("DefrostHeaterVolt", typeof(int));
            dtQuickWaterEvaporator.Columns.Add("DefrostHeaterWatt", typeof(int));
            dtQuickWaterEvaporator.Columns.Add("DefrostHeaterDesc", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("DefrostHeaterPrice", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("DefrostHeaterKilowatts", typeof(decimal));
         
            dtQuickWaterEvaporator.Columns.Add("FinType", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("FinShape", typeof(string));
            dtQuickWaterEvaporator.Columns.Add("FinHeight", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("FinLength", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("Row", typeof(decimal));
   
            dtQuickWaterEvaporator.Columns.Add("CoilFaceArea", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("FaceVelocity", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("AirPressureDrop", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("LeavingDryBulb", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("LeavingWetBulb", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("TotalHeat", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("SensibleHeat", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("LeavingLiquidTemperature", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("RefrigerantPressureDrop", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("GPM", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("WaterVelocity", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("MotorMCA", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("MotorMOP", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("MotorFUSE", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("HeaterFLA", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("HeaterMCA", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("HeaterFUSE", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("FinMaterialPrice", typeof(decimal));
            dtQuickWaterEvaporator.Columns.Add("CoilCoatingPrice", typeof(decimal));
            //2012-05-23 : #1355 : adding dwg name on all reports
            dtQuickWaterEvaporator.Columns.Add("ApprovalDrawing", typeof(string));

            return dtQuickWaterEvaporator;
        }

        public static DataRow SetToZero(DataRow dr)
        {
            foreach (DataColumn dc in dr.Table.Columns)
            {
                if (dc.DataType == typeof(string))
                {
                    dr[dc] = "";
                }
                else if (dc.DataType == typeof(int))
                {
                    dr[dc] = 0;
                }
                else if (dc.DataType == typeof(decimal))
                {
                    dr[dc] = 0m;
                }
                else if (dc.DataType == typeof(bool))
                {
                    dr[dc] = false;
                }
                else if (dc.DataType == typeof(DateTime))
                {
                    dr[dc] = DateTime.Now;
                }
                else if (dc.DataType == typeof(short))
                {
                    dr[dc] = 0;
                }
                else if (dc.DataType == typeof(double))
                {
                    dr[dc] = 0d;
                }
            }

            return dr;
        }
    }
}
