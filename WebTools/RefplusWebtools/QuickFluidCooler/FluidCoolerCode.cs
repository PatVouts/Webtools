using System;
using System.Data;
using System.Globalization;

namespace RefplusWebtools.QuickFluidCooler
{
    class FluidCoolerCode
    {
        
        //Fill the missing value of the fluid table
        private DataTable SelectFluidCooler(DataTable dtFluidCoolerInformations, float fltEnteringDryBulb, string strFluidType, float fltEnteringWaterTemperature, float fltAltitude, float fltConcentration, float fltGPM,float fltCfmCorrectionFactor, float fltCircuitCorrectionFactor, float fltPowerFactor,float fltSpecificHeat, float fltDensity,float fltViscosity,float fltThermalConductivity,string strPowerSupply,string strFluidTypeName,int intVoltageID)
        {
            //instanciate the class
            //KFRefplus.HeaterClass kfHeating = new KFRefplus.HeaterClass();

            //for each rows (fluid cooler) run the dll and output the value
            foreach (DataRow drFluidCooler in dtFluidCoolerInformations.Rows)
            {
                //kfHeating = new KFRefplus.HeaterClass();
                var kfHeating = new HotWaterCoil.HotWaterCoil
                {
                    DBE = fltEnteringDryBulb,
                    CHO = "R",
                    FL = strFluidType,
                    CG = fltConcentration,
                    WE = fltEnteringWaterTemperature,
                    DT = 0f,
                    CFMT = "A",
                    ALTD = (fltAltitude <= 500f ? 0f : fltAltitude),
                    GPM = fltGPM
                };
                //set the parameters that never change
                //2011-08-22 : #1146 due to cfm being miscalculated we need to use ACFM and < 500ft count as 0ft
                //kfHeating.CFMT = "S";
                //kfHeating.ALTD = fltAltitude;
                const string strConns = "STD";
                //object objConns = strConns;
                //kfHeating.let_conns(ref objConns);
                kfHeating.conns = strConns;
                kfHeating.FM = "AL";
                kfHeating.TM = "CU";
                kfHeating.FFI = 0;
                kfHeating.FFO = 0;
                kfHeating.TURB = "N";

                //set the variable parameters
                kfHeating.CFM = float.Parse(drFluidCooler["CFM"].ToString()) * float.Parse(drFluidCooler["fanwide"].ToString()) * float.Parse(drFluidCooler["fanlong"].ToString()) * fltCfmCorrectionFactor * fltPowerFactor;
                kfHeating.YF = Convert.ToInt32(drFluidCooler["fpi"]) == 8 ? 0.008f : 0.006f;
                kfHeating.TT = drFluidCooler["fin"].ToString() == "G" ? 0.018f : 0.016f;
                kfHeating.CTYP = drFluidCooler["fin"] + "C";
                kfHeating.CH = float.Parse(drFluidCooler["finheight"].ToString());
                kfHeating.CL = float.Parse(drFluidCooler["coillength"].ToString());
                kfHeating.FPI = float.Parse(drFluidCooler["fpi"].ToString()) + fltCircuitCorrectionFactor;
                kfHeating.Row = float.Parse(drFluidCooler["row"].ToString());
                
                kfHeating.ODDF = kfHeating.Row % 2.0F > 0 ? "Y" : "N";

                kfHeating.CIR = float.Parse(drFluidCooler["cir1"].ToString());

                //special parameter to add for OTHER as fluid type
                if (strFluidType == "OTHER")
                {
                    kfHeating.CPG = fltSpecificHeat;
                    kfHeating.DPG = fltDensity;
                    kfHeating.UVG = fltViscosity;
                    kfHeating.TKG = fltThermalConductivity;
                }

                try
                {
                    //run the dll
                    kfHeating.DESIGN(Public.CoilDllKey);

                    //fill the value
                    drFluidCooler["cap"] = Convert.ToDecimal(Math.Round(kfHeating.SHAZ / 1000, 1)).ToString(CultureInfo.InvariantCulture);
                    drFluidCooler["leavingliquid"] = Convert.ToDecimal(Math.Round((decimal)kfHeating.AWLZ, 1)).ToString(CultureInfo.InvariantCulture);
                    drFluidCooler["pressuredrop"] = Convert.ToDecimal(Math.Round(kfHeating.DP1Z / 2.306666666666f, 1)).ToString(CultureInfo.InvariantCulture);
                    drFluidCooler["leavingair"] = Convert.ToDecimal(Math.Round(kfHeating.AT2Z, 1)).ToString(CultureInfo.InvariantCulture);
                    drFluidCooler["liquidvelocity"] = Convert.ToDecimal(Math.Round(kfHeating.VWZ, 1));
                    drFluidCooler["gpm"] = Convert.ToDecimal(Math.Round(kfHeating.GPM, 1));
                    drFluidCooler["ConnectionSize"] = Convert.ToDecimal(Math.Round(kfHeating.Connz, 3));
                    drFluidCooler["CoilFaceArea"] = Convert.ToDecimal(Math.Round(kfHeating.FA, 2));
                    drFluidCooler["FaceVelocity"] = Convert.ToDecimal(Math.Round(kfHeating.AFAV, 2));
                    drFluidCooler["AirPressureDrop"] = Convert.ToDecimal(Math.Round(kfHeating.DPAJZ, 2));
                    drFluidCooler["EnteringDryBulb"] = (decimal)fltEnteringDryBulb;
                    drFluidCooler["EnteringLiquidTemperature"] = (decimal)fltEnteringWaterTemperature;
                    drFluidCooler["FluidType"] = strFluidType;
                    drFluidCooler["Concentration"] = (decimal)fltConcentration;
                    drFluidCooler["Altitude"] = (decimal)fltAltitude;
                    drFluidCooler["PowerSupply"] = strPowerSupply;
                    drFluidCooler["SpecificHeat"] = (decimal)fltSpecificHeat;
                    drFluidCooler["Density"] = (decimal)fltDensity;
                    drFluidCooler["Viscosity"] = (decimal)fltViscosity;
                    drFluidCooler["ThermalConductivity"] = (decimal)fltThermalConductivity;
                    drFluidCooler["FluidTypeName"] = strFluidTypeName;
                    drFluidCooler["VoltageID"] = intVoltageID;
                }
                catch (Exception ex)
                {
                    Public.PushLog(ex.ToString(),"FluidCoolerCode SelectFluidCooler");
                }
            }

            return dtFluidCoolerInformations;
        }

        //Fill the missing value of the fluid table on rating mode
        private DataTable SelectFluidCoolerRating_LLT_MODE(DataTable dtFluidCoolerInformations, float fltEnteringDryBulb, string strFluidType, float fltEnteringWaterTemperature, float fltLeavingWaterTemperature, float fltAltitude, float fltConcentration, float fltCfmCorrectionFactor, float fltCircuitCorrectionFactor, float fltPowerFactor, float fltSpecificHeat, float fltDensity, float fltViscosity, float fltThermalConductivity, string strPowerSupply, string strFluidTypeName,int intVoltageID)
        {
            //these handle the gpm gap we use
            float[] fltGap = { 50f, 25f, 12f, 6f, 1f, 0.1f };

            //instanciate the class
            //KFRefplus.HeaterClass kfHeating = new KFRefplus.HeaterClass();
            var kfHeating = new HotWaterCoil.HotWaterCoil();

            float fltLastGPM = 0f;
            float fltLastGap = 0f;
            //for each rows (fluid cooler) run the dll and output the value
            foreach (DataRow drFluidCooler in dtFluidCoolerInformations.Rows)
            {
                kfHeating.GPM = 0f;
                for (int intGap = 0; intGap < fltGap.Length; intGap++)
                {
                    //if we have more than 1000 gpm break the loop
                    if (kfHeating.GPM > 1000)
                    {
                        break;
                    }
                    fltLastGPM = kfHeating.GPM;
                    //kfHeating = new KFRefplus.HeaterClass();
                    kfHeating = new HotWaterCoil.HotWaterCoil {GPM = fltLastGPM, AWLZ = 0f};
                    //2008-10-27: domenico said to put the LLT at 10000 to be sure
                    //that the LLT is always greater than what we are looking for

                    while (kfHeating.AWLZ < fltLeavingWaterTemperature)
                    {
                        //if we have more than 1000 gpm break the loop
                        if (kfHeating.GPM > 1000)
                        {
                            break;
                        }
                        fltLastGPM = kfHeating.GPM;
                        //kfHeating = new KFRefplus.HeaterClass();
                        kfHeating = new HotWaterCoil.HotWaterCoil
                        {
                            DBE = fltEnteringDryBulb,
                            CHO = "R",
                            FL = strFluidType,
                            CG = fltConcentration,
                            WE = fltEnteringWaterTemperature,
                            DT = fltEnteringWaterTemperature - fltLeavingWaterTemperature,
                            CFMT = "A",
                            ALTD = (fltAltitude <= 500f ? 0f : fltAltitude),
                            GPM = fltLastGPM + fltGap[intGap]
                        };
                        //set the parameters that never change
                        //2011-08-22 : #1146 due to cfm being miscalculated we need to use ACFM and < 500ft count as 0ft
                        //kfHeating.CFMT = "S";
                        //kfHeating.ALTD = fltAltitude;
                        fltLastGap = fltGap[intGap];
                        const string strConns = "STD";
                        //object objConns = strConns;
                        //kfHeating.let_conns(ref objConns);
                        kfHeating.conns = strConns;
                        kfHeating.FM = "AL";
                        kfHeating.TM = "CU";
                        kfHeating.FFI = 0;
                        kfHeating.FFO = 0;
                        kfHeating.TURB = "N";

                        //set the variable parameters
                        kfHeating.CFM = float.Parse(drFluidCooler["CFM"].ToString()) * float.Parse(drFluidCooler["fanwide"].ToString()) * float.Parse(drFluidCooler["fanlong"].ToString()) * fltCfmCorrectionFactor * fltPowerFactor;
                        kfHeating.YF = Convert.ToInt32(drFluidCooler["fpi"]) == 8 ? 0.008f : 0.006f;
                        kfHeating.TT = drFluidCooler["fin"].ToString() == "G" ? 0.018f : 0.016f;
                        kfHeating.CTYP = drFluidCooler["fin"] + "C";
                        kfHeating.CH = float.Parse(drFluidCooler["finheight"].ToString());
                        kfHeating.CL = float.Parse(drFluidCooler["coillength"].ToString());
                        kfHeating.FPI = float.Parse(drFluidCooler["fpi"].ToString()) + fltCircuitCorrectionFactor;
                        kfHeating.Row = float.Parse(drFluidCooler["row"].ToString());

                        kfHeating.ODDF = kfHeating.Row % 2.0F > 0 ? "Y" : "N";

                        kfHeating.CIR = float.Parse(drFluidCooler["cir1"].ToString());

                        //special parameter to add for OTHER as fluid type
                        if (strFluidType == "OTHER")
                        {
                            kfHeating.CPG = fltSpecificHeat;
                            kfHeating.DPG = fltDensity;
                            kfHeating.UVG = fltViscosity;
                            kfHeating.TKG = fltThermalConductivity;
                        }

                        try
                        {
                            //run the dll
                            kfHeating.DESIGN(Public.CoilDllKey);
                        }
                        catch (Exception ex)
                        {
                            Public.PushLog(ex.ToString(),"FluidCoolerCode SelectFluidCoolerRating_LLT_MODE");
                        }
                    }
                    kfHeating.GPM = kfHeating.GPM - fltGap[intGap];
                }

                //if we have more than 1000 gpm we have broken the loop
                //so we don't fill anything for this model
                if (kfHeating.GPM > 1000)
                {
                    break;
                }
                //kfHeating = new KFRefplus.HeaterClass();
                kfHeating = new HotWaterCoil.HotWaterCoil
                {
                    DBE = fltEnteringDryBulb,
                    CHO = "R",
                    FL = strFluidType,
                    CG = fltConcentration,
                    WE = fltEnteringWaterTemperature,
                    DT = fltEnteringWaterTemperature - fltLeavingWaterTemperature,
                    CFMT = "A",
                    ALTD = (fltAltitude <= 500f ? 0f : fltAltitude),
                    GPM = fltLastGPM + fltLastGap
                };

                //set the parameters that never change
                //2011-08-22 : #1146 due to cfm being miscalculated we need to use ACFM and < 500ft count as 0ft
                //kfHeating.CFMT = "S";
                //kfHeating.ALTD = fltAltitude;
                const string strConns2 = "STD";
                //object objConns = strConns;
                //kfHeating.let_conns(ref objConns);
                kfHeating.conns = strConns2;
                kfHeating.FM = "AL";
                kfHeating.TM = "CU";
                kfHeating.FFI = 0;
                kfHeating.FFO = 0;
                kfHeating.TURB = "N";

                //set the variable parameters
                kfHeating.CFM = float.Parse(drFluidCooler["CFM"].ToString()) * float.Parse(drFluidCooler["fanwide"].ToString()) * float.Parse(drFluidCooler["fanlong"].ToString()) * fltCfmCorrectionFactor * fltPowerFactor;
                kfHeating.YF = Convert.ToInt32(drFluidCooler["fpi"]) == 8 ? 0.008f : 0.006f;
                kfHeating.TT = drFluidCooler["fin"].ToString() == "G" ? 0.018f : 0.016f;
                kfHeating.CTYP = drFluidCooler["fin"] + "C";
                kfHeating.CH = float.Parse(drFluidCooler["finheight"].ToString());
                kfHeating.CL = float.Parse(drFluidCooler["coillength"].ToString());
                kfHeating.FPI = float.Parse(drFluidCooler["fpi"].ToString()) + fltCircuitCorrectionFactor;
                kfHeating.Row = float.Parse(drFluidCooler["row"].ToString());

                kfHeating.ODDF = kfHeating.Row % 2.0F > 0 ? "Y" : "N";

                kfHeating.CIR = float.Parse(drFluidCooler["cir1"].ToString());

                //special parameter to add for OTHER as fluid type
                if (strFluidType == "OTHER")
                {
                    kfHeating.CPG = fltSpecificHeat;
                    kfHeating.DPG = fltDensity;
                    kfHeating.UVG = fltViscosity;
                    kfHeating.TKG = fltThermalConductivity;
                }


                //run the dll with the gpm substracted
                //because in hte loop it's 1 gap too far and we reduce it at the end
                //of the loop but iwthout running it.
                kfHeating.DESIGN(Public.CoilDllKey);

                //fill the value
                drFluidCooler["cap"] = Convert.ToDecimal(Math.Round(kfHeating.SHAZ / 1000, 1)).ToString(CultureInfo.InvariantCulture);
                drFluidCooler["leavingliquid"] = Convert.ToDecimal(Math.Round((decimal)kfHeating.AWLZ, 1)).ToString(CultureInfo.InvariantCulture);
                drFluidCooler["pressuredrop"] = Convert.ToDecimal(Math.Round(kfHeating.DP1Z / 2.306666666666f, 1)).ToString(CultureInfo.InvariantCulture);
                drFluidCooler["leavingair"] = Convert.ToDecimal(Math.Round(kfHeating.AT2Z, 1)).ToString(CultureInfo.InvariantCulture);
                drFluidCooler["liquidvelocity"] = Convert.ToDecimal(Math.Round(kfHeating.VWZ, 1));
                drFluidCooler["gpm"] = Convert.ToDecimal(Math.Round(kfHeating.GPM, 1));
                drFluidCooler["ConnectionSize"] = Convert.ToDecimal(Math.Round(kfHeating.Connz, 3));
                drFluidCooler["CoilFaceArea"] = Convert.ToDecimal(Math.Round(kfHeating.FA, 2));
                drFluidCooler["FaceVelocity"] = Convert.ToDecimal(Math.Round(kfHeating.AFAV, 2));
                drFluidCooler["AirPressureDrop"] = Convert.ToDecimal(Math.Round(kfHeating.DPAJZ, 2));
                drFluidCooler["EnteringDryBulb"] = (decimal)fltEnteringDryBulb;
                drFluidCooler["EnteringLiquidTemperature"] = (decimal)fltEnteringWaterTemperature;
                drFluidCooler["FluidType"] = strFluidType;
                drFluidCooler["Concentration"] = (decimal)fltConcentration;
                drFluidCooler["Altitude"] = (decimal)fltAltitude;
                drFluidCooler["PowerSupply"] = strPowerSupply;
                drFluidCooler["SpecificHeat"] = (decimal)fltSpecificHeat;
                drFluidCooler["Density"] = (decimal)fltDensity;
                drFluidCooler["Viscosity"] = (decimal)fltViscosity;
                drFluidCooler["ThermalConductivity"] = (decimal)fltThermalConductivity;
                drFluidCooler["FluidTypeName"] = strFluidTypeName;
                drFluidCooler["VoltageID"] = intVoltageID;
            }
            return dtFluidCoolerInformations;
        }

        //Fill the missing value of the fluid table on rating mode
        private DataTable SelectFluidCoolerRating_GPM_MODE(DataTable dtFluidCoolerInformations, float fltEnteringDryBulb, string strFluidType, float fltEnteringWaterTemperature, float fltAltitude, float fltConcentration, float fltGPM, float fltCfmCorrectionFactor, float fltCircuitCorrectionFactor, float fltPowerFactor, float fltSpecificHeat, float fltDensity, float fltViscosity, float fltThermalConductivity, string strPowerSupply, string strFluidTypeName, int intVoltageID)
        {
            //instanciate the class
            //KFRefplus.HeaterClass kfHeating = new KFRefplus.HeaterClass();
            //for each rows (fluid cooler) run the dll and output the value
            foreach (DataRow drFluidCooler in dtFluidCoolerInformations.Rows)
            {
                //kfHeating = new KFRefplus.HeaterClass();
                var kfHeating = new HotWaterCoil.HotWaterCoil
                {
                    DBE = fltEnteringDryBulb,
                    CHO = "R",
                    FL = strFluidType,
                    CG = fltConcentration,
                    WE = fltEnteringWaterTemperature,
                    DT = 0f,
                    CFMT = "A",
                    ALTD = (fltAltitude <= 500f ? 0f : fltAltitude),
                    GPM = fltGPM
                };

                //set the parameters that never change
                //2011-08-22 : #1146 due to cfm being miscalculated we need to use ACFM and < 500ft count as 0ft
                //kfHeating.CFMT = "S";
                //kfHeating.ALTD = fltAltitude;
                const string strConns = "STD";
                //object objConns = strConns;
                //kfHeating.let_conns(ref objConns);
                kfHeating.conns = strConns;
                kfHeating.FM = "AL";
                kfHeating.TM = "CU";
                kfHeating.FFI = 0;
                kfHeating.FFO = 0;
                kfHeating.TURB = "N";

                //set the variable parameters
                kfHeating.CFM = float.Parse(drFluidCooler["CFM"].ToString()) * float.Parse(drFluidCooler["fanwide"].ToString()) * float.Parse(drFluidCooler["fanlong"].ToString()) * fltCfmCorrectionFactor * fltPowerFactor;
                kfHeating.YF = Convert.ToInt32(drFluidCooler["fpi"]) == 8 ? 0.008f : 0.006f;
                kfHeating.TT = drFluidCooler["fin"].ToString() == "G" ? 0.018f : 0.016f;
                kfHeating.CTYP = drFluidCooler["fin"] + "C";
                kfHeating.CH = float.Parse(drFluidCooler["finheight"].ToString());
                kfHeating.CL = float.Parse(drFluidCooler["coillength"].ToString());
                kfHeating.FPI = float.Parse(drFluidCooler["fpi"].ToString()) + fltCircuitCorrectionFactor;
                kfHeating.Row = float.Parse(drFluidCooler["row"].ToString());

                kfHeating.ODDF = kfHeating.Row % 2.0F > 0 ? "Y" : "N";

                kfHeating.CIR = float.Parse(drFluidCooler["cir1"].ToString());

                //special parameter to add for OTHER as fluid type
                if (strFluidType == "OTHER")
                {
                    kfHeating.CPG = fltSpecificHeat;
                    kfHeating.DPG = fltDensity;
                    kfHeating.UVG = fltViscosity;
                    kfHeating.TKG = fltThermalConductivity;
                }

                try
                {
                    //run the dll
                    kfHeating.DESIGN(Public.CoilDllKey);

                    //fill the value
                    drFluidCooler["cap"] = Convert.ToDecimal(Math.Round(kfHeating.SHAZ / 1000, 1)).ToString(CultureInfo.InvariantCulture);
                    drFluidCooler["leavingliquid"] = Convert.ToDecimal(Math.Round((decimal)kfHeating.AWLZ, 1)).ToString(CultureInfo.InvariantCulture);
                    drFluidCooler["pressuredrop"] = Convert.ToDecimal(Math.Round(kfHeating.DP1Z / 2.306666666666f, 1)).ToString(CultureInfo.InvariantCulture);
                    drFluidCooler["leavingair"] = Convert.ToDecimal(Math.Round(kfHeating.AT2Z, 1)).ToString(CultureInfo.InvariantCulture);
                    drFluidCooler["liquidvelocity"] = Convert.ToDecimal(Math.Round(kfHeating.VWZ, 1));
                    drFluidCooler["gpm"] = Convert.ToDecimal(Math.Round(kfHeating.GPM, 1));
                    drFluidCooler["ConnectionSize"] = Convert.ToDecimal(Math.Round(kfHeating.Connz, 3));
                    drFluidCooler["CoilFaceArea"] = Convert.ToDecimal(Math.Round(kfHeating.FA, 2));
                    drFluidCooler["FaceVelocity"] = Convert.ToDecimal(Math.Round(kfHeating.AFAV, 2));
                    drFluidCooler["AirPressureDrop"] = Convert.ToDecimal(Math.Round(kfHeating.DPAJZ, 2));
                    drFluidCooler["EnteringDryBulb"] = (decimal)fltEnteringDryBulb;
                    drFluidCooler["EnteringLiquidTemperature"] = (decimal)fltEnteringWaterTemperature;
                    drFluidCooler["FluidType"] = strFluidType;
                    drFluidCooler["Concentration"] = (decimal)fltConcentration;
                    drFluidCooler["Altitude"] = (decimal)fltAltitude;
                    drFluidCooler["PowerSupply"] = strPowerSupply;
                    drFluidCooler["SpecificHeat"] = (decimal)fltSpecificHeat;
                    drFluidCooler["Density"] = (decimal)fltDensity;
                    drFluidCooler["Viscosity"] = (decimal)fltViscosity;
                    drFluidCooler["ThermalConductivity"] = (decimal)fltThermalConductivity;
                    drFluidCooler["FluidTypeName"] = strFluidTypeName;
                    drFluidCooler["VoltageID"] = intVoltageID;
                }
                catch (Exception ex)
                {
                    Public.PushLog(ex.ToString(),"FluidCoolerCode SelectFluidCoolerRating_GPM_MODE");
                }
            }
            return dtFluidCoolerInformations;
        }

        //this function will process all informations and return up to 3 tables in a dataset
        //this is the only accessible function for the filtering, all others are private.
        public DataSet Process_SelectFluidCooler(DataTable dtSelectFluidCooler, string strFilter, float fltLeavingLiquidTemperature, float fltMaxPressureDrop, float fltMaxLeavingAir, string[] strMotor, string[] strCoilArr, string[] strVoltageMotor, string[] strVoltageCoilArr, string strFanArrangementFilter, string strSpecificModel, string strAirFlowTypeFilter, float fltEnteringDryBulb, string strFluidType, float fltEnteringWaterTemperature, float fltAltitude, float fltConcentration, float fltGPM, float fltCfmCorrectionFactor, float fltCircuitCorrectionFactor, float fltPowerFactor, float fltSpecificHeat, float fltDensity, float fltViscosity, float fltThermalConductivity, string strPowerSupply, string strFluidTypeName, string strFPI, int intVoltageID, decimal decMBH)
        {
//this function related to the result of SelectFluidCooler()

            //if the selection is "Selection"
            if (strFilter == "Selection")
            {           //this does the xref model name
                return LoadModelReference_SelectFluidCooler
                       (
                    //select 3 models or up to 3
                    //between E, F, G you specify the quantity
                    //of each you want
                            SelectThreeModel_SelectFluidCooler
                            (
                    //that sort the whole thing before selecting
                    //the final fluid cooler
                                Sort_SelectFluidCooler
                                (
                    //this filter out all the Fluid Cooler that
                    //their calculated value don't match what we want
                                    Filter_SelectFluidCoolerCalculatedValues
                                    (
                    //this select the fluid cooler by calculating
                    //their values in the dll
                                        SelectFluidCooler
                                        (
                    //this is the first filter that reduce
                    //by alot the list of fluid cooler to run throuh
                    //the dll
                                            Filter_SelectFluidCooler
                                            (
                                                dtSelectFluidCooler
                                                , strMotor
                                                , strCoilArr
                                                , strVoltageMotor
                                                , strVoltageCoilArr
                                                , strFanArrangementFilter
                                                , strSpecificModel
                                                , strFPI
                                                , strAirFlowTypeFilter
                                            )
                                            , fltEnteringDryBulb
                                            , strFluidType
                                            , fltEnteringWaterTemperature, fltAltitude
                                            , fltConcentration
                                            , fltGPM
                                            , fltCfmCorrectionFactor
                                            , fltCircuitCorrectionFactor
                                            , fltPowerFactor
                                            , fltSpecificHeat
                                            , fltDensity
                                            , fltViscosity
                                            , fltThermalConductivity
                                            , strPowerSupply
                                            , strFluidTypeName
                                            , intVoltageID
                                        )
                                        , fltLeavingLiquidTemperature
                                        , fltMaxPressureDrop
                                        , fltMaxLeavingAir
                                        , decMBH
                                    )
                                    , decMBH
                                )
                                , 1
                                , 1
                                , 1
                            )
                            , strAirFlowTypeFilter
                       );
            }
            if (strFilter == "Rating" && fltLeavingLiquidTemperature >= 0)//if it's a rating on LLT (looking for GPM at that LLT)
            {           //this does the xref model name
                return LoadModelReference_SelectFluidCooler
                    (
                        //select 3 models or up to 3
                        //between E, F, G you specify the quantity
                        //of each you want
                        SelectThreeModel_SelectFluidCooler
                            (
                                //that sort the whole thing before selecting
                                //the final fluid cooler
                                Sort_SelectFluidCooler
                                    (
                                        //this filter out all the Fluid Cooler that
                                        //their calculated value don't match what we want
                                        Filter_SelectFluidCoolerCalculatedValues
                                            (
                                                //this select the fluid cooler by calculating
                                                //their values in the dll
                                                SelectFluidCoolerRating_LLT_MODE
                                                    (
                                                        //this is the first filter that reduce
                                                        //by alot the list of fluid cooler to run throuh
                                                        //the dll
                                                        Filter_SelectFluidCooler
                                                            (
                                                                dtSelectFluidCooler
                                                                , strMotor
                                                                , strCoilArr
                                                                , strVoltageMotor
                                                                , strVoltageCoilArr
                                                                , strFanArrangementFilter
                                                                , strSpecificModel
                                                                , strFPI
                                                                , strAirFlowTypeFilter
                                                            )
                                                        , fltEnteringDryBulb
                                                        , strFluidType
                                                        , fltEnteringWaterTemperature
                                                        , fltLeavingLiquidTemperature
                                                        , fltAltitude
                                                        , fltConcentration, fltCfmCorrectionFactor
                                                        , fltCircuitCorrectionFactor
                                                        , fltPowerFactor
                                                        , fltSpecificHeat
                                                        , fltDensity
                                                        , fltViscosity
                                                        , fltThermalConductivity
                                                        , strPowerSupply
                                                        , strFluidTypeName
                                                        , intVoltageID
                                                    )
                                                , 1000000f
                                                , 1000000f
                                                , fltMaxLeavingAir
                                                , 0m
                                            )
                                        , 0m
                                    )
                                , 1
                                , 1
                                , 1
                            )
                        , strSpecificModel.Split(Convert.ToChar(","))[6]
                    );
            }
            //this does the xref model name
            return LoadModelReference_SelectFluidCooler
                (
                    //select 3 models or up to 3
                    //between E, F, G you specify the quantity
                    //of each you want
                    SelectThreeModel_SelectFluidCooler
                        (
                            //that sort the whole thing before selecting
                            //the final fluid cooler
                            Sort_SelectFluidCooler
                                (
                                    //this filter out all the Fluid Cooler that
                                    //their calculated value don't match what we want
                                    Filter_SelectFluidCoolerCalculatedValues
                                        (
                                            //this select the fluid cooler by calculating
                                            //their values in the dll
                                            SelectFluidCoolerRating_GPM_MODE
                                                (
                                                    //this is the first filter that reduce
                                                    //by alot the list of fluid cooler to run throuh
                                                    //the dll
                                                    Filter_SelectFluidCooler
                                                        (
                                                            dtSelectFluidCooler
                                                            , strMotor
                                                            , strCoilArr
                                                            , strVoltageMotor
                                                            , strVoltageCoilArr
                                                            , strFanArrangementFilter
                                                            , strSpecificModel
                                                            , strFPI
                                                            , strAirFlowTypeFilter
                                                        )
                                                    , fltEnteringDryBulb
                                                    , strFluidType
                                                    , fltEnteringWaterTemperature, fltAltitude
                                                    , fltConcentration
                                                    , fltGPM
                                                    , fltCfmCorrectionFactor
                                                    , fltCircuitCorrectionFactor
                                                    , fltPowerFactor
                                                    , fltSpecificHeat
                                                    , fltDensity
                                                    , fltViscosity
                                                    , fltThermalConductivity
                                                    , strPowerSupply
                                                    , strFluidTypeName
                                                    , intVoltageID
                                                )
                                            , 1000000f
                                            , 1000000f
                                            , fltMaxLeavingAir
                                            , 0m
                                        )
                                    , 0m
                                )
                            , 1
                            , 1
                            , 1
                        )
                    , strSpecificModel.Split(Convert.ToChar(","))[6]
                );
        }

        //this function get the 3 fluid cooler and create up to 3 table he can found any
        private DataSet SelectThreeModel_SelectFluidCooler(DataTable dtSelectFluidCooler,int intNumberOfOutputModelE,int intNumberOfOutputModelF ,int intNumberOfOutputModelG)
        {//this function related to the result of SelectFluidCooler()
            //loop variable
            int intLoopThroughtDatasetRecord;

            //create the dataset object with 3 tables "E", "F", "G" that will contain all we need
            DataSet dsModels = DatasetFormatOfFluidCoolerModel_SelectFluidCooler(dtSelectFluidCooler);

            for (intLoopThroughtDatasetRecord = 0;
                intLoopThroughtDatasetRecord < dtSelectFluidCooler.Rows.Count;
                intLoopThroughtDatasetRecord++)
            {
                if (dtSelectFluidCooler.Rows[intLoopThroughtDatasetRecord]["Fin"].ToString() == "E" && dsModels.Tables["E"].Rows.Count < intNumberOfOutputModelE)
                {//if the FinType is E and we haven't found all model we want (see intNumberOfOutputModel_E)
                    //add the new row to the table
                    dsModels.Tables["E"].Rows.Add(dtSelectFluidCooler.Rows[intLoopThroughtDatasetRecord].ItemArray);
                }
                else if (dtSelectFluidCooler.Rows[intLoopThroughtDatasetRecord]["Fin"].ToString() == "F" && dsModels.Tables["F"].Rows.Count < intNumberOfOutputModelF)
                {//if the FinType is F and we haven't found all model we want (see intNumberOfOutputModel_F)
                    //add the new row to the table
                    dsModels.Tables["F"].Rows.Add(dtSelectFluidCooler.Rows[intLoopThroughtDatasetRecord].ItemArray);
                }
                else if (dtSelectFluidCooler.Rows[intLoopThroughtDatasetRecord]["Fin"].ToString() == "G" && dsModels.Tables["G"].Rows.Count < intNumberOfOutputModelG)
                {//if the FinType is G and we haven't found all model we want (see intNumberOfOutputModel_G)
                    //add the new row to the table
                    dsModels.Tables["G"].Rows.Add(dtSelectFluidCooler.Rows[intLoopThroughtDatasetRecord].ItemArray);
                }
                
                //check if all models needed were found, if yes don't waste
                //time looping and break outside this loop
                if (dsModels.Tables["E"].Rows.Count == intNumberOfOutputModelE && dsModels.Tables["F"].Rows.Count == intNumberOfOutputModelF && dsModels.Tables["G"].Rows.Count == intNumberOfOutputModelG)
                {//if the number of models we need are reached, break out loop
                    break;
                }
            }
       
            return dsModels;
        }

        //this function return the dataset format to be used
        //to fill the 3 differents model we want
        private DataSet DatasetFormatOfFluidCoolerModel_SelectFluidCooler(DataTable dtSelectFluidCooler)
        {
            //declare the dataset to hold the 3 tables
            var dsModel = new DataSet("Model");

            //clone the format of the table we are working with
            DataTable dtModelE = dtSelectFluidCooler.Clone();
            DataTable dtModelF = dtSelectFluidCooler.Clone();
            DataTable dtModelG = dtSelectFluidCooler.Clone();

            //rename the tables for easy access
            dtModelE.TableName = "E";
            dtModelF.TableName = "F";
            dtModelG.TableName = "G";

            //add the tables to our dataset
            dsModel.Tables.Add(dtModelE);
            dsModel.Tables.Add(dtModelF);
            dsModel.Tables.Add(dtModelG);

            //disposed object correctly for garbage collector
            dtModelE.Dispose();
            dtModelF.Dispose();
            dtModelG.Dispose();

            return dsModel;
        }

        //this function sort the dataset
        private DataTable Sort_SelectFluidCooler(DataTable dtSelectFluidCooler, decimal decMBH)
        {//this function related to the result of SelectFluidCooler()
            //create a dataview object to sort the table fro mthe table
            DataView dvSelectFluidCoolerView = dtSelectFluidCooler.DefaultView;
            //sort parameter
            //following are just reference to column names we use
            //Columns.Add("LeavingLiquid", typeof(decimal));
            //Columns.Add("PressureDrop", typeof(decimal));
            //Columns.Add("LeavingAir", typeof(decimal));
            //dvSelectFluidCoolerView.Sort = "LeavingLiquid DESC, PressureDrop DESC, Cap DESC, LeavingAir DESC";

            //0 mbh mean it's run on gpm else it's run as mbh
            dvSelectFluidCoolerView.Sort = decMBH == 0m ? "FanQty ASC, PressureDrop DESC, LeavingLiquid DESC, FPI DESC, Row ASC, LeavingAir DESC, CAP ASC" : "FanQty ASC, CAP ASC, PressureDrop DESC, LeavingLiquid DESC, FPI DESC, Row ASC, LeavingAir DESC";

            DataTable dt = dvSelectFluidCoolerView.ToTable();

            dvSelectFluidCoolerView.Dispose();

            return dt;
        }

        //this function filter the dataset accordign to parameter needed
        private DataTable Filter_SelectFluidCooler(DataTable dtSelectFluidCooler, string[] strMotor, string[] strCoilArr, string[] strVoltageMotor, string[] strVoltageCoilArr, string strFanArrangementFilter, string strSpecificModel, string strFPI, string strAirFlowTypeFilter)
        {//this function related to the result of SelectFluidCooler()

            //additionnal filter
            string strAdditionnalFilter = "";

            //check for additional filtering on Fan Arrangement
            if (strFanArrangementFilter != "ALL")
            {
                //add the filter, split on "x" because format is i.e. 1x2, 2x3, 2x6
                //first is fanwide, second fanlong
                strAdditionnalFilter = strAdditionnalFilter +
                                        " AND Fanwide = " + strFanArrangementFilter.Split(Convert.ToChar("x")).GetValue(0) +
                                        " AND FanLong = " + strFanArrangementFilter.Split(Convert.ToChar("x")).GetValue(1);
            }

            //if it's rating
            if (strSpecificModel != "ALL")
            {
                strAdditionnalFilter = strAdditionnalFilter +
                                       " AND Motor = '" + strSpecificModel.Split(Convert.ToChar(","))[0] + "'" +
                                       " AND Coilarr = '" + strSpecificModel.Split(Convert.ToChar(","))[1] + "'" +
                                       " AND Fanwide = " + strSpecificModel.Split(Convert.ToChar(","))[2] +
                                       " AND FanLong = " + strSpecificModel.Split(Convert.ToChar(","))[3] +
                                       " AND Row = " + strSpecificModel.Split(Convert.ToChar(","))[4] +
                                       " AND Fpi = " + strSpecificModel.Split(Convert.ToChar(","))[5] +
                                       " AND AirFlow = '" + strSpecificModel.Split(Convert.ToChar(","))[6] + "'" +
                                       " AND Fin = '" + strSpecificModel.Split(Convert.ToChar(","))[7] + "'" +
                                       " AND Cir1 = " + strSpecificModel.Split(Convert.ToChar(","))[8];

                //2011-03-14 : rating mode still require voltage to filter.
                //will ocntaint the motor coil arr condition
                string strVoltageMotorCoilArr = "";

                //for each motor add the condition
                for (int intMotorCoilArr = 0; intMotorCoilArr < strVoltageMotor.Length; intMotorCoilArr++)
                {
                    strVoltageMotorCoilArr += " OR (Motor = '" + strVoltageMotor[intMotorCoilArr] + "' AND CoilArr = '" + strVoltageCoilArr[intMotorCoilArr] + "')";
                }

                //add parentesis is case other filter applied
                strVoltageMotorCoilArr = " AND (" + strVoltageMotorCoilArr.Substring(4) + ")";

                //add the filter
                strAdditionnalFilter += strVoltageMotorCoilArr;

            }
            else// if it's selection
            {
                //split on comma
                string[] strFPISplit = strFPI.Split(Convert.ToChar(","));

                //the first one is special
                strAdditionnalFilter = strAdditionnalFilter + " AND (FPI = " + strFPISplit[0];

                //for each subsequent possible FPI add them to the condition
                for (int intSplit = 1; intSplit < strFPISplit.Length; intSplit++)
                {
                    strAdditionnalFilter = strAdditionnalFilter + " OR FPI = " + strFPISplit[intSplit];
                }

                //finally close the parenthesis
                strAdditionnalFilter = strAdditionnalFilter + ")";

                //will ocntaint the motor coil arr condition
                string strMotorCoilArr = "";

                //for each motor add the condition
                for (int intMotorCoilArr = 0; intMotorCoilArr < strMotor.Length; intMotorCoilArr++)
                {
                    strMotorCoilArr = strMotorCoilArr + " OR (Motor = '" + strMotor[intMotorCoilArr] + "' AND CoilArr = '" + strCoilArr[intMotorCoilArr] + "')";
                }

                //add parentesis is case other filter applied
                strMotorCoilArr = " AND (" + strMotorCoilArr.Substring(4) + ")";

                //add the filter
                strAdditionnalFilter = strAdditionnalFilter + strMotorCoilArr;

                //will ocntaint the motor coil arr condition
                strMotorCoilArr = "";

                //for each motor add the condition
                for (int intMotorCoilArr = 0; intMotorCoilArr < strVoltageMotor.Length; intMotorCoilArr++)
                {
                    strMotorCoilArr = strMotorCoilArr + " OR (Motor = '" + strVoltageMotor[intMotorCoilArr] + "' AND CoilArr = '" + strVoltageCoilArr[intMotorCoilArr] + "')";
                }

                //add parentesis is case other filter applied
                strMotorCoilArr = " AND (" + strMotorCoilArr.Substring(4) + ")";

                //add the filter
                strAdditionnalFilter = strAdditionnalFilter + strMotorCoilArr;

                strAdditionnalFilter += " AND AirFlow = '" + strAirFlowTypeFilter + "'";
            }

            strAdditionnalFilter = strAdditionnalFilter.Substring(4);
            //the filtering
            DataRow[] drSelectFluidCooler = dtSelectFluidCooler.Copy().Select(strAdditionnalFilter);

            //clear the table
            dtSelectFluidCooler.Clear();
            //for each result (matching the condition) add it to the cleared table
            for (int intLoopSelectedResult = 0;
                     intLoopSelectedResult < drSelectFluidCooler.Length;
                     intLoopSelectedResult++)
            {
                //add row to the table
                dtSelectFluidCooler.Rows.Add(drSelectFluidCooler[intLoopSelectedResult].ItemArray);
            }

            return dtSelectFluidCooler;
        }

        //this function filter the dataset according to the calculated values
        private DataTable Filter_SelectFluidCoolerCalculatedValues(DataTable dtSelectFluidCooler, float fltLeavingLiquidTemperature, float fltMaxPressureDrop, float fltMaxLeavingAir, decimal decMBH)
        {
            //following are just reference to column names we use
            //Columns.Add("LeavingLiquid", typeof(decimal));
            //Columns.Add("PressureDrop", typeof(decimal));
            //Columns.Add("LeavingAir", typeof(decimal));
            DataRow[] drSelectFluidCooler = dtSelectFluidCooler.Copy().Select(
                "LeavingLiquid <= " + fltLeavingLiquidTemperature +
                " AND PressureDrop <= " + fltMaxPressureDrop +
                " AND LeavingAir <= " + fltMaxLeavingAir +
                " AND LeavingAir > 0 " +
                " AND LiquidVelocity > 2 " +
                " AND Cap >= " + decMBH);

 

            //clear the table
            dtSelectFluidCooler.Clear();
            //for each result (matching the condition) add it to the cleared table
            for (int intLoopSelectedResult = 0;
                     intLoopSelectedResult < drSelectFluidCooler.Length;
                     intLoopSelectedResult++)
            {
                //add row to the table
                dtSelectFluidCooler.Rows.Add(drSelectFluidCooler[intLoopSelectedResult].ItemArray);
            }
            
            return dtSelectFluidCooler;
        }


        //load the model from the reference file
        private DataSet LoadModelReference_SelectFluidCooler(DataSet dsSelectFluidCooler, string strAirFlowTypeFilter)
        {
            //for each tables
            foreach (DataTable dtModelTable in dsSelectFluidCooler.Tables)
            {
                //for each rows in each table
                for (int intLoopThroughtDatasetRecord = 0;
                    intLoopThroughtDatasetRecord < dtModelTable.Rows.Count;
                    intLoopThroughtDatasetRecord++)
                {
                    //add the reference to our dataset
                    dsSelectFluidCooler.Tables[dtModelTable.TableName].Rows[intLoopThroughtDatasetRecord]["FluidCoolerModel"] = dsSelectFluidCooler.Tables[dtModelTable.TableName].Rows[intLoopThroughtDatasetRecord][UserInformation.CurrentSite + "_FluidXRefModel"].ToString();
                    dsSelectFluidCooler.Tables[dtModelTable.TableName].Rows[intLoopThroughtDatasetRecord]["AirFlowType"] = strAirFlowTypeFilter;
                    dsSelectFluidCooler.Tables[dtModelTable.TableName].Rows[intLoopThroughtDatasetRecord]["FluidCoolerPrice"] = Convert.ToDecimal(dsSelectFluidCooler.Tables[dtModelTable.TableName].Rows[intLoopThroughtDatasetRecord]["Price"]);
                }
            }

            //disposing object

            return dsSelectFluidCooler;
        }

        //this funciton return the GPM value when using MBH to calculate
        public decimal MBH_to_GPM(decimal decMBH,decimal decELT,decimal decLLT, string strFluidType, decimal decConcentration)
        {
            //the formula
            decimal decFormula = (decMBH * 1000) / ((decELT - decLLT) * (500 * MBH_to_GPM_CorrectionFactor(strFluidType, decConcentration, decELT, decLLT) * MBH_to_GPM_SpecificHeat(strFluidType, decConcentration, decELT, decLLT)));

            //return the result
            return decFormula;
        }

        private decimal MBH_to_GPM_CorrectionFactor(string strFluidType, decimal decConcentration, decimal decELT, decimal decLLT)
        {
            decimal decFormula;

            if (strFluidType == "WTR")
            {//if it's water
                //water Correction Factor is always 1
                decFormula = 1;
            }
            else
            {
                //contain the table name
                //this value is the searched temperature in the table
                decimal decSearchedTemperature = Math.Floor((decELT + decLLT) / 2);

                string strTable = strFluidType == "EG" ? "Density_Ethylene" : "Density_Propylene";

                //result of the search glycol
                DataRow[] drSearchResult = Public.DSDatabase.Tables[strTable].Select("t = " + decSearchedTemperature);
                decimal decGlycolDensity = Convert.ToDecimal(drSearchResult[0]["p" + decConcentration]);

                //result of the search water
                drSearchResult = Public.DSDatabase.Tables["Density_Water"].Select("temperature = " + decSearchedTemperature);
                decimal decWaterDensity = Convert.ToDecimal(drSearchResult[0]["Density"]);

                //(Water Density at Mean temperature) / (Glycol Density at Mean temperature st specific concentration)
                decFormula = decGlycolDensity / decWaterDensity;

            }

            return decFormula;
        }

        private decimal MBH_to_GPM_SpecificHeat(string strFluidType, decimal decConcentration, decimal decELT, decimal decLLT)
        {
            //this value is the searched temperature in the table
            decimal decSearchedTemperature = Math.Floor((decELT + decLLT) / 2);

            //return value for specific heat 
            decimal decSpecificHeat;

            if (strFluidType == "WTR")
            {//if it's water


                //result of the search water
                DataRow[] drSearchResult = Public.DSDatabase.Tables["SensibleHeat_Water"].Select("temperature = " + decSearchedTemperature);
                decSpecificHeat = Convert.ToDecimal(drSearchResult[0]["SensibleHeat"]);

            }
            else
            {
                //contain the table name

                string strTable = strFluidType == "EG" ? "SensibleHeat_Ethylene" : "SensibleHeat_Propylene";

                //result of the search glycol
                DataRow[] drSearchResult = Public.DSDatabase.Tables[strTable].Select("t = " + decSearchedTemperature);
                decSpecificHeat = Convert.ToDecimal(drSearchResult[0]["p" + decConcentration]);

            }

            return decSpecificHeat;
        }

        public DataTable FilterLegs(DataTable dtFluidCoolerLegs, string strMotor)
        {
            DataRow[] drFilterLegs = dtFluidCoolerLegs.Copy().Select("Motors LIKE '%" + strMotor + "%'");

            DataTable dtLegs = dtFluidCoolerLegs.Clone();
           
            //for each result (matching the condition) add it to the cleared table
            for (int intLoopSelectedResult = 0;
                     intLoopSelectedResult < drFilterLegs.Length;
                     intLoopSelectedResult++)
            {
                //add row to the table
                dtLegs.Rows.Add(drFilterLegs[intLoopSelectedResult].ItemArray);
            }

            return dtLegs;
        }

        //is fin material available
        public bool IsFinMaterialAvailable(DataTable dtvCoilFinDefaults, string strFinType, int intFPI, string strFinMaterial)
        {
            //check is the fin material is available for the specific conditions
            if (dtvCoilFinDefaults.Select("FinType = '" + strFinType + "' AND FinShape = 'C' AND FPI_MIN <= " + intFPI + " AND FPI_MAX >= " + intFPI + " AND FinMaterialID = " + strFinMaterial).Length > 0)
            {
                return true;
            }
            return false;
        }

        //is tube Material available
        public bool IsTubeMaterialAvailable(DataTable dtvCoilTubeDefaults, string strCoilType, string strFinType, string strTubeMaterial)
        {
            //check is the tube thickness is available for the specific conditions
            if (dtvCoilTubeDefaults.Select("UniqueID = " + strTubeMaterial + " AND CoilType = '" + strCoilType + "' AND FinType = '" + strFinType + "'").Length > 0)
            {
                return true;
            }
            return false;
        }

        //this return the tube thickness default
        public decimal TubeThicknessDefault(DataTable dtvCoilTubeDefaults, string strFinType, string strTubeMaterial)
        {
            //if this stays empty that mean no default exist
            //else it will be filled with the thickness that is the default
            decimal decTubeThicknessDefault = 0m;

            //select the default
            DataRow[] drvCoilTubeDefaults = dtvCoilTubeDefaults.Select("TubeMaterial = '" + strTubeMaterial + "' AND CoilType = 'FH' AND FinType = '" + strFinType + "' AND DefaultValue = 1");

            DataTable dtSort = dtvCoilTubeDefaults.Clone();
            for (int introw = 0; introw < drvCoilTubeDefaults.Length; introw++)
            {
                dtSort.Rows.Add(drvCoilTubeDefaults[introw].ItemArray);
            }

            DataView dvSort = dtSort.DefaultView;
            dvSort.Sort = "DefaultValue DESC, TubeSize ASC";

            //if we have record(s) that mean we have a default found
            if (dvSort.ToTable().Rows.Count > 0)
            {
                decTubeThicknessDefault = Convert.ToDecimal(dvSort.ToTable().Rows[0]["TubeSize"]);
            }

            dtSort.Dispose();
            dvSort.Dispose();

            return decTubeThicknessDefault;
        }

        //this return the fin thickness default
        public decimal FinThicknessDefault(DataTable dtvCoilFinDefaults, string strFinType, int intFPI, string strFinMaterial)
        {
            //if this stays empty that mean no default exist
            //else it will be filled with the thickness that is the default
            decimal decFinThicknessDefault = 0m;

            //select the default
            DataRow[] drvCoilFinDefaults = dtvCoilFinDefaults.Select("FinType = '" + strFinType + "' AND FinShape = 'C' AND FPI_MIN <= " + intFPI + " AND FPI_MAX >= " + intFPI + " AND FinMaterial = '" + strFinMaterial + "'");

            DataTable dtSort =  dtvCoilFinDefaults.Clone();
            for (int introw = 0; introw < drvCoilFinDefaults.Length; introw++)
            {
                dtSort.Rows.Add(drvCoilFinDefaults[introw].ItemArray);
            }

            DataView dvSort = dtSort.DefaultView;
            dvSort.Sort = "DefaultValue DESC, FinThickness ASC";

            //if we have record(s) that mean we have a default found
            if (dvSort.ToTable().Rows.Count > 0)
            {
                decFinThicknessDefault = Convert.ToDecimal(dvSort.ToTable().Rows[0]["FinThickness"]);
            }

            dtSort.Dispose();
            dvSort.Dispose();

            return decFinThicknessDefault;
        }

        //order the weather informations
        public DataTable OrderWeatherInformations(DataTable dtWeather)
        {
            //create a view from the datatable to sort it afterward
            DataView dvWeather = dtWeather.DefaultView;

            //sort the data
            dvWeather.Sort = "Country ASC, State ASC, City ASC";

            //return the table
            return dvWeather.ToTable();
        }
        //Get Models For Rating Mode Model List
        public DataTable GetModelsForRatingModeModelList(DataTable dtFluidCoolerModel)
        {
            //clone the table for the new result
            var dtResultTable = new DataTable();
            dtResultTable.Columns.Add("Value", typeof(string));
            dtResultTable.Columns.Add("Text", typeof(string));

            foreach (DataRow drFluidCooler in dtFluidCoolerModel.Rows)
            {
                DataRow drResultTable = dtResultTable.NewRow();

                //add the value of the 2 fields from the selection table
                drResultTable["Value"] = drFluidCooler["Motor"] + "," + drFluidCooler["Coilarr"] + "," + drFluidCooler["FanWide"] + "," + drFluidCooler["FanLong"] + "," + drFluidCooler["Row"] + "," + drFluidCooler["FPI"] + "," + drFluidCooler["AirFlow"] + "," + drFluidCooler["Fin"] + "," + drFluidCooler["Cir1"];
                drResultTable["Text"] = drFluidCooler[UserInformation.CurrentSite + "_FluidXRefModel"] + "-" + drFluidCooler["Fin"] + drFluidCooler["Cir1"];

                //add the row
                dtResultTable.Rows.Add(drResultTable.ItemArray);
            }

            //sort the result
            DataView dvResultTable = dtResultTable.Copy().DefaultView;
            dvResultTable.Sort = "Text ASC";

            //put the result in the table
            dtResultTable = dvResultTable.ToTable();

            //disposed
            dvResultTable.Dispose();

            return dtResultTable;
        }

        //return the list filtered and ordered for the fan arrangement
        public DataTable GetFanArrangement(DataTable dtFluidCoolerFanArrangement, string[] strMotor, string[] strCoilArr)
        {
            //filter on the table
            string strFilter = "";

            //build the filter
            for (int intMotorCoilArr = 0; intMotorCoilArr < strMotor.Length; intMotorCoilArr++)
            {
                strFilter = strFilter + " OR (Motor = '" + strMotor[intMotorCoilArr] + "' AND CoilArr = '" + strCoilArr[intMotorCoilArr] + "')";
            }

            //remove the first OR
            strFilter = strFilter.Substring(4);

            //filter the list
            DataRow[] drFluidCoolerFanArrangement = dtFluidCoolerFanArrangement.Select(strFilter);

            //this table will contaitn the filtered result
            DataTable dtFluidCoolerFanArrangementFiltered = dtFluidCoolerFanArrangement.Clone();

            //fill the table
            for (int intRow = 0; intRow < drFluidCoolerFanArrangement.Length; intRow++)
            {
                //if the fan arrangement doesnt already exist add it
                if (dtFluidCoolerFanArrangementFiltered.Select("FanArrangement = '" + drFluidCoolerFanArrangement[intRow]["FanArrangement"] + "'").Length == 0)
                {
                    dtFluidCoolerFanArrangementFiltered.Rows.Add(drFluidCoolerFanArrangement[intRow].ItemArray);
                }
            }

            //create a view to sort it
            DataView dvFluidCoolerFanArrangement = dtFluidCoolerFanArrangementFiltered.DefaultView;

            //sort
            dvFluidCoolerFanArrangement.Sort = "FanWide ASC, FanLong ASC";

            //set back the value to the filtered table
            dtFluidCoolerFanArrangementFiltered = dvFluidCoolerFanArrangement.ToTable();
            
            //disposed objects
            dvFluidCoolerFanArrangement.Dispose();

            //return result
            return dtFluidCoolerFanArrangementFiltered;

        }

        //return the freezing point value
        public decimal GetFreezingPoint(DataTable dtFluidFreezingPointTable, int intConcentration)
        {
            return Convert.ToDecimal(dtFluidFreezingPointTable.Select("Concentration = " + intConcentration)[0]["FreezingPoint"]);
        }
    }
}
