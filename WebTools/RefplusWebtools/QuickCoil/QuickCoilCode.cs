using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace RefplusWebtools.QuickCoil
{
    class QuickCoilCode
    {
        //2008-10-24: now fin height change depending on the coil type
        ////this is the max fin height for the coils
        ////i use a variable public to the coil only because we 
        ////may want coil to have a certain maximum and fluid cooler another
        //public const decimal DEC_MAX_FIN_HEIGHT = 240m;

        //this is the minimum height of a coil for now it's 2 face tubes
        //so 3 inch face tube the min height will be 6 inch
        public const decimal DecMinHeightInFaceTubes = 2;

        public const string AriCertified = "Certified in accordance with the AHRI Forced-Circulation Air-Cooling and Air-Heating Coils Certification Program which is based on AHRI Standard 410 within the Range of Standard Rating Conditions listed in Table 1 of the Standard. Certified units may be found in the AHRI Directory at www.ahridirectory.com.   VERSION AHRI 1.1";
        public const string AriRated = "";
        //2012-10-25 : #3473 : adding new ARI text as per jacques b
        public const string AriOutside = "Coil is outside of the scope of AHRI Standard 410.   VERSION AHRI 1.1";

        //return the max fin Height
        public decimal MaxFinHeight(string strCoilType)
        {
            decimal decReturnValue;
            switch (strCoilType)
            {
                case "FC":
                    decReturnValue = 192m;
                    break;
                default:
                    decReturnValue = 240m;
                    break;
            }
            return decReturnValue;
        }

        public bool Run_DX_Selection(DataTable dtQuickCoil, ref string errorMessage)
        {
            //create DX object
            var coilSelection = new DXcoil
            {
                Altitude = float.Parse(dtQuickCoil.Rows[0]["DXAltitude"].ToString()),
                CFM = float.Parse(dtQuickCoil.Rows[0]["DXAirFlowRate"].ToString()),
                CoilHeight = float.Parse(dtQuickCoil.Rows[0]["FinHeight"].ToString()),
                CoilLength = float.Parse(dtQuickCoil.Rows[0]["FinLength"].ToString()),
                EnteringDryBulb = float.Parse(dtQuickCoil.Rows[0]["DXEnteringDryBulb"].ToString()),
                EnteringWetBulb = float.Parse(dtQuickCoil.Rows[0]["DXEnteringWetBulb"].ToString()),
                FinMaterial = dtQuickCoil.Rows[0]["FinMaterial"].ToString(),
                FinShape = dtQuickCoil.Rows[0]["FinShape"].ToString(),
                FinsPerInch = float.Parse(dtQuickCoil.Rows[0]["FPI"].ToString()),
                FinThickness = float.Parse(dtQuickCoil.Rows[0]["FinThickness"].ToString()),
                FinType = dtQuickCoil.Rows[0]["FinType"].ToString(),
                LiquidTemperature = float.Parse(dtQuickCoil.Rows[0]["DXLiquidTemp"].ToString())
            };
            
            //set the value

            //if it's not automatic, set the number of circuit
            //when we are not setting the value it's selected by the dll
            if (dtQuickCoil.Rows[0]["DXNumberOfCircuit"].ToString() != "AUTOMATIC")
            {
                coilSelection.NumberOfCircuits = float.Parse(dtQuickCoil.Rows[0]["DXNumberOfCircuit"].ToString());
            }

            coilSelection.NumberOfRows = float.Parse(dtQuickCoil.Rows[0]["Row"].ToString());
            coilSelection.RefrigerantType = dtQuickCoil.Rows[0]["DXRefrigerantType"].ToString();
            coilSelection.SuctionTemperature = float.Parse(dtQuickCoil.Rows[0]["DXSuctionTemperature"].ToString());
            coilSelection.TubeMaterial = dtQuickCoil.Rows[0]["TubeMaterial"].ToString();
            coilSelection.TubeThickness = float.Parse(dtQuickCoil.Rows[0]["TubeThickness"].ToString());
            coilSelection.TubeType = dtQuickCoil.Rows[0]["TubeType"].ToString();

            //Coil are selected in Rating mode only.
            //will have this in their respective section
            //so we can allow Selection for some other coils.
            coilSelection.Type = Type.RATING;

            //execute the selection and pass the table to fill
            bool bolSelectionResult = coilSelection.ExecuteSelection(dtQuickCoil, ref errorMessage);

            //dispose object

            return bolSelectionResult;
        }

        /// <summary>
        /// return True if the fin type is available for the selected
        /// </summary>
        /// <param name="dtvCoilFinTypeDefaults"></param>
        /// <param name="strFinType"></param>
        /// <param name="strCoilType"></param>
        /// <param name="bolHRWithR410A"></param>
        /// <returns></returns>
        public bool IsFinTypeAvailableForThisCoil(DataTable dtvCoilFinTypeDefaults, string strFinType, string strCoilType, bool bolHRWithR410A)
        {
            if (dtvCoilFinTypeDefaults.Select("FinTypeID = " + strFinType + " AND CoilTypeID = " + strCoilType).Length > 0)
            {
                return true;
            }
            return false;
        }

        public string FinHeightSelectClosestValueOfPreviouslySelectedOne(decimal decSelectedHeight, decimal decFaceTubes)
        {
            //this is the Result of the division to know how much time we will
            //approximately need the new face tubes to be close ot the new value
            decimal decResult = decSelectedHeight / decFaceTubes;
            //essentially the Division result rounded so we get the height
            //the closest to our previous selected one. and so the value is good
            //for our selection
            decimal decIterance = Math.Round(decResult, 0);
            //if the nubmer of iterance is lower than the min number of face tube allow
            //bump up the value
            if (decIterance < DecMinHeightInFaceTubes)
            {
                decIterance = DecMinHeightInFaceTubes;
            }
            //so to have the height we are looking for it's Iterance X Face Tube
            decSelectedHeight = decIterance * decFaceTubes;
            return decSelectedHeight.ToString(CultureInfo.InvariantCulture);
        }

// ReSharper disable RedundantAssignment
        public void MinMaxFPI(DataTable dtvCoilFinDefaults, string strFinType, ref int intMinFPI, ref int intMaxFPI)
// ReSharper restore RedundantAssignment
        {
            //select thh fin type
            DataRow[] drvCoilFinDefaults = dtvCoilFinDefaults.Select("FinType = '" + strFinType + "'");

            //put a big value so the MIN funtion select at least the first result
            intMinFPI = 100000;
            //put a small value so the MAX funtion select at least the first result
            intMaxFPI = -100000;
            
            //for each result of our select test the last value with the new in a 
            //min function and max. In the end only the lower one stays in Min and bigger
            //in Max
            for (int intLenght = 0; intLenght < drvCoilFinDefaults.Length; intLenght++)
            {
                intMinFPI = Math.Min(intMinFPI, Convert.ToInt32(drvCoilFinDefaults[intLenght]["FPI_MIN"]));
                intMaxFPI = Math.Max(intMaxFPI, Convert.ToInt32(drvCoilFinDefaults[intLenght]["FPI_MAX"]));
            }
        }

        //is fin material available
        public bool IsFinMaterialAvailable(DataTable dtvCoilFinDefaults, string strFinType,string strFinShape, int intFPI, string strFinMaterial)
        {
            //check is the fin material is available for the specific conditions
            if (dtvCoilFinDefaults.Select("FinType = '" + strFinType + "' AND FinShape = '" + strFinShape + "' AND FPI_MIN <= " + intFPI + " AND FPI_MAX >= " + intFPI + " AND FinMaterialID = " + strFinMaterial).Length > 0)
            {
                return true;
            }
            return false;
        }

        //is fin thickness available
        public bool IsFinThicknessAvailable(DataTable dtvCoilFinDefaults, string strFinType, int intFPI, string strFinMaterial,string strFinThickness)
        {
            //check is the fin thickness is available for the specific conditions
            if (dtvCoilFinDefaults.Select("FinType = '" + strFinType + "' AND FPI_MIN <= " + intFPI + " AND FPI_MAX >= " + intFPI + " AND FinMaterialID = " + strFinMaterial + " AND FinThickness = " + strFinThickness).Length > 0)
            {
                return true;
            }
            return false;
        }

        //this return the fin thickness default
        public string FinThicknessDefault(DataTable dtvCoilFinDefaults, string strFinType,string strFinShape, int intFPI, string strFinMaterial)
        {
            //if this stays empty that mean no default exist
            //else it will be filled with the thickness that is the default
            string strFinThicknessDefault = "";

            //select the default
            DataRow[] drvCoilFinDefaults = dtvCoilFinDefaults.Select("FinType = '" + strFinType + "' AND FinShape = '" + strFinShape + "' AND FPI_MIN <= " + intFPI + " AND FPI_MAX >= " + intFPI + " AND FinMaterialID = " + strFinMaterial + " AND DefaultValue = 1");

            //if we have record(s) that mean we have a default found
            if (drvCoilFinDefaults.Length > 0)
            {
                strFinThicknessDefault = drvCoilFinDefaults[0]["FinThickness"].ToString();
            }


            return strFinThicknessDefault;
        }

        //is tube Material available
        public bool IsTubeMaterialAvailable(DataTable dtvCoilTubeDefaults, string strCoilType, string strFinType, string strTubeMaterial, bool bolHRWithR410A)
        {
            //check is the tube thickness is available for the specific conditions
            if (dtvCoilTubeDefaults.Select("UniqueID = " + strTubeMaterial + " AND CoilType = '" + strCoilType + "' AND FinType = '" + strFinType + "'" + (bolHRWithR410A ? " AND R410A = 1" : "")).Length > 0)
            {
                return true;
            }
            return false;
        }

        //is tube thickness available
        public bool IsTubeThicknessAvailable(DataTable dtvCoilTubeDefaults, string strCoilType, string strFinType, string strTubeMaterial, string strTubeThickness, bool bolHRWithR410A)
        {
            //check is the tube thickness is available for the specific conditions
            
            if (dtvCoilTubeDefaults.Select("UniqueID = " + strTubeMaterial + (strCoilType == ""? "": " AND CoilType = '" + strCoilType + "'") +" AND FinType = '" + strFinType + "' AND TubeSize = " + strTubeThickness + (bolHRWithR410A ? " AND R410A = 1" : "")).Length > 0)
            {
                return true;
            }
            return false;
        }

        //this return the tube thickness default
        public string TubeThicknessDefault(DataTable dtvCoilTubeDefaults, string strCoilType, string strFinType, string strTubeMaterial, bool bolHRWithR410A)
        {
            //if this stays empty that mean no default exist
            //else it will be filled with the thickness that is the default
            string strTubeThicknessDefault = "";

            //select the default
            DataRow[] drvCoilTubeDefaults = dtvCoilTubeDefaults.Select("UniqueID = " + (strTubeMaterial == ""?"1":strTubeMaterial) + (strCoilType == ""? "":" AND CoilType = '" + strCoilType + "'") + " AND FinType = '" + strFinType + "' AND DefaultValue = 1" + (bolHRWithR410A ? " AND R410A = 1" : ""));

            //if we have record(s) that mean we have a default found
            if (drvCoilTubeDefaults.Length > 0)
            {
                strTubeThicknessDefault = drvCoilTubeDefaults[0]["TubeSize"].ToString();
            }


            return strTubeThicknessDefault;
        }

        public bool Run_HR_Selection(DataTable dtQuickCoil, ref string errorMessage)
        {
            //create HR object
            var coilSelection = new HeatReclaim
            {
                Altitude = float.Parse(dtQuickCoil.Rows[0]["HRAltitude"].ToString()),
                CFM = float.Parse(dtQuickCoil.Rows[0]["HRAirFlowRate"].ToString()),
                CoilHeight = float.Parse(dtQuickCoil.Rows[0]["FinHeight"].ToString()),
                CoilLength = float.Parse(dtQuickCoil.Rows[0]["FinLength"].ToString()),
                CoilDesign = dtQuickCoil.Rows[0]["HRCoilDesign"].ToString().Substring(0, 1),
                CondenserCircuit = float.Parse(dtQuickCoil.Rows[0]["HRCircuits"].ToString()),
                CondenserCondensingTemperature = float.Parse(dtQuickCoil.Rows[0]["HRCondensingTemperature"].ToString()),
                EnteringDryBulb = float.Parse(dtQuickCoil.Rows[0]["HREnteringDryBulb"].ToString()),
                FaceTubes = dtQuickCoil.Rows[0]["HRFaceTubes"].ToString(),
                FinMaterial = dtQuickCoil.Rows[0]["FinMaterial"].ToString(),
                FinShape = dtQuickCoil.Rows[0]["FinShape"].ToString(),
                FinsPerInch = float.Parse(dtQuickCoil.Rows[0]["FPI"].ToString()),
                FinThickness = float.Parse(dtQuickCoil.Rows[0]["FinThickness"].ToString()),
                FinType = dtQuickCoil.Rows[0]["FinType"].ToString(),
                HeatRecovery = float.Parse(dtQuickCoil.Rows[0]["HRHeatRecovery"].ToString())
            };

            //set the value

            //if it's not automatic, set the number of circuit
            //when we are not setting the value it's selected by the dll
            if (dtQuickCoil.Rows[0]["HRNumberOfCircuit"].ToString() != "AUTOMATIC")
            {
                coilSelection.NumberOfCircuits = float.Parse(dtQuickCoil.Rows[0]["HRNumberOfCircuit"].ToString());
            }

            coilSelection.NumberOfRows = float.Parse(dtQuickCoil.Rows[0]["Row"].ToString());
            coilSelection.RefrigerantType = dtQuickCoil.Rows[0]["HRRefrigerantType"].ToString();
            coilSelection.SubCooler = dtQuickCoil.Rows[0]["HRSubCooler"].ToString().Substring(0,1);//Y or N
            coilSelection.SuctionTemperature = float.Parse(dtQuickCoil.Rows[0]["HRSuctionTemperature"].ToString());
            coilSelection.TubeMaterial = dtQuickCoil.Rows[0]["TubeMaterial"].ToString();
            coilSelection.TubeThickness = float.Parse(dtQuickCoil.Rows[0]["TubeThickness"].ToString());
            coilSelection.TubeType = dtQuickCoil.Rows[0]["TubeType"].ToString();

            //Coil are selected in Rating mode only.
            //will have this in their respective section
            //so we can allow Selection for some other coils.
            coilSelection.Type = Type.RATING;

            //execute the selection and pass the table to fill
            bool bolSelectionResult = coilSelection.ExecuteSelection(dtQuickCoil,ref errorMessage);

            //dispose object

            return bolSelectionResult;
        }

        public bool Run_FH_Selection(DataTable dtQuickCoil, ref string errorMessage)
        {
            //create FH object
            var coilSelection = new FluidHeating
            {
                Altitude = float.Parse(dtQuickCoil.Rows[0]["FHAltitude"].ToString()),
                CFM = float.Parse(dtQuickCoil.Rows[0]["FHAirFlowRate"].ToString()),
                CoilHeight = float.Parse(dtQuickCoil.Rows[0]["FinHeight"].ToString()),
                CoilLength = float.Parse(dtQuickCoil.Rows[0]["FinLength"].ToString()),
                Concentration = float.Parse(dtQuickCoil.Rows[0]["FHConcentration"].ToString()),
                ConnectionSize = dtQuickCoil.Rows[0]["FHConnectionSizeIn"].ToString(),
                DifferenceBetweenEnteringAndLeaving =
                    float.Parse(dtQuickCoil.Rows[0]["FHEnteringLiquidTemperature"].ToString()) -
                    float.Parse(dtQuickCoil.Rows[0]["FHLeavingLiquidTemperature"].ToString()),
                EnteringDryBulb = float.Parse(dtQuickCoil.Rows[0]["FHEnteringDryBulb"].ToString()),
                EnteringLiquidTemperature = float.Parse(dtQuickCoil.Rows[0]["FHEnteringLiquidTemperature"].ToString()),
                FinMaterial = dtQuickCoil.Rows[0]["FinMaterial"].ToString(),
                FinShape = dtQuickCoil.Rows[0]["FinShape"].ToString(),
                FinsPerInch = float.Parse(dtQuickCoil.Rows[0]["FPI"].ToString()),
                FinThickness = float.Parse(dtQuickCoil.Rows[0]["FinThickness"].ToString()),
                FinType = dtQuickCoil.Rows[0]["FinType"].ToString(),
                GPM = float.Parse(dtQuickCoil.Rows[0]["FHUSGPM"].ToString()),
                NumberOfCircuits =
                    dtQuickCoil.Rows[0]["FHNumberOfCircuit"].ToString() != "AUTOMATIC"
                        ? float.Parse(dtQuickCoil.Rows[0]["FHNumberOfCircuit"].ToString())
                        : 0f,
                NumberOfRows = float.Parse(dtQuickCoil.Rows[0]["Row"].ToString()),
                RefrigerantType = dtQuickCoil.Rows[0]["FHFluidType"].ToString(),
                TubeMaterial = dtQuickCoil.Rows[0]["TubeMaterial"].ToString(),
                TubeThickness = float.Parse(dtQuickCoil.Rows[0]["TubeThickness"].ToString()),
                Turbulator = dtQuickCoil.Rows[0]["Turbulators"].ToString().Substring(0, 1),
                Type = Type.RATING
            };

            //set the value
            //if it's not automatic, set the number of circuit
            //when we are not setting the value it's selected by the dll

            //Coil are selected in Rating mode only.
            //will have this in their respective section
            //so we can allow Selection for some other coils.

            bool bolSelectionResult = dtQuickCoil.Rows[0]["FHNumberOfCircuit"].ToString() != "AUTOMATIC" ? coilSelection.ExecuteSelection(dtQuickCoil, ref errorMessage) : coilSelection.ExecuteAutomaticCircuitingSelection(dtQuickCoil, ref errorMessage);         

            //dispose object

            return bolSelectionResult;
        }

        public bool Run_FC_Selection(DataTable dtQuickCoil, ref string errorMessage)
        {
            //create FH object
            var coilSelection = new FluidCooling
            {
                Altitude = float.Parse(dtQuickCoil.Rows[0]["FCAltitude"].ToString()),
                CFM = float.Parse(dtQuickCoil.Rows[0]["FCAirFlowRate"].ToString()),
                CoilHeight = float.Parse(dtQuickCoil.Rows[0]["FinHeight"].ToString()),
                CoilLength = float.Parse(dtQuickCoil.Rows[0]["FinLength"].ToString()),
                Concentration = float.Parse(dtQuickCoil.Rows[0]["FCConcentration"].ToString()),
                ConnectionSize = dtQuickCoil.Rows[0]["FCConnectionSizeIn"].ToString(),
                DifferenceBetweenEnteringAndLeaving =
                    (float)
                        Math.Abs(Convert.ToDecimal(dtQuickCoil.Rows[0]["FCEnteringLiquidTemperature"]) -
                                 Convert.ToDecimal(dtQuickCoil.Rows[0]["FCLeavingLiquidTemperature"])),
                EnteringDryBulb = float.Parse(dtQuickCoil.Rows[0]["FCEnteringDryBulb"].ToString()),
                EnteringWetBulb = float.Parse(dtQuickCoil.Rows[0]["FCEnteringWetBulb"].ToString()),
                EnteringLiquidTemperature = float.Parse(dtQuickCoil.Rows[0]["FCEnteringLiquidTemperature"].ToString()),
                FinMaterial = dtQuickCoil.Rows[0]["FinMaterial"].ToString(),
                FinShape = dtQuickCoil.Rows[0]["FinShape"].ToString(),
                FinsPerInch = float.Parse(dtQuickCoil.Rows[0]["FPI"].ToString()),
                FinThickness = float.Parse(dtQuickCoil.Rows[0]["FinThickness"].ToString()),
                FinType = dtQuickCoil.Rows[0]["FinType"].ToString(),
                GPM = float.Parse(dtQuickCoil.Rows[0]["FCUSGPM"].ToString()),
                NumberOfCircuits =
                    dtQuickCoil.Rows[0]["FCNumberOfCircuits"].ToString() != "AUTOMATIC"
                        ? float.Parse(dtQuickCoil.Rows[0]["FCNumberOfCircuits"].ToString())
                        : 0f,
                NumberOfRows = float.Parse(dtQuickCoil.Rows[0]["Row"].ToString()),
                RefrigerantType = dtQuickCoil.Rows[0]["FCFluidType"].ToString(),
                TubeMaterial = dtQuickCoil.Rows[0]["TubeMaterial"].ToString(),
                TubeThickness = float.Parse(dtQuickCoil.Rows[0]["TubeThickness"].ToString()),
                Turbulator = dtQuickCoil.Rows[0]["Turbulators"].ToString().Substring(0, 1),
                Type = Type.RATING
            };

            //set the value
            //if it's not automatic, set the number of circuit
            //when we are not setting the value it's selected by the dll

            //Coil are selected in Rating mode only.
            //will have this in their respective section
            //so we can allow Selection for some other coils.

            bool bolSelectionResult = dtQuickCoil.Rows[0]["FCNumberOfCircuits"].ToString() != "AUTOMATIC" ? coilSelection.ExecuteSelection(dtQuickCoil, ref errorMessage) : coilSelection.ExecuteAutomaticCircuitingSelection(dtQuickCoil, ref errorMessage);  

            //dispose object

            return bolSelectionResult;
        }

        public bool Run_GC_Selection(DataTable dtQuickCoil, ref string errorMessage)
        {
            //create GC object
            var coilSelection = new GasCooler
            {
                Altitude = float.Parse(dtQuickCoil.Rows[0]["GCAltitude"].ToString()),
                CFM = float.Parse(dtQuickCoil.Rows[0]["GCAirFlowRate"].ToString()),
                CoilHeight = float.Parse(dtQuickCoil.Rows[0]["FinHeight"].ToString()),
                CoilLength = float.Parse(dtQuickCoil.Rows[0]["FinLength"].ToString()),
                EnteringDryBulb = float.Parse(dtQuickCoil.Rows[0]["GCEnteringDryBulb"].ToString()),
                FinMaterial = dtQuickCoil.Rows[0]["FinMaterial"].ToString(),
                FinShape = dtQuickCoil.Rows[0]["FinShape"].ToString(),
                FinsPerInch = float.Parse(dtQuickCoil.Rows[0]["FPI"].ToString()),
                FinThickness = float.Parse(dtQuickCoil.Rows[0]["FinThickness"].ToString()),
                FinType = dtQuickCoil.Rows[0]["FinType"].ToString(),
                NumberOfCircuits =
                    dtQuickCoil.Rows[0]["GCNumberOfCircuits"].ToString() != "AUTOMATIC"
                        ? float.Parse(dtQuickCoil.Rows[0]["GCNumberOfCircuits"].ToString())
                        : 0f,
                NumberOfRows = float.Parse(dtQuickCoil.Rows[0]["Row"].ToString()),
                TubeMaterial = dtQuickCoil.Rows[0]["TubeMaterial"].ToString(),
                TubeThickness = float.Parse(dtQuickCoil.Rows[0]["TubeThickness"].ToString()),
                RefrigerantType = "R-744",
                GasTempIn = float.Parse(dtQuickCoil.Rows[0]["GCGIN"].ToString()),
                GasOperatingPressure = float.Parse(dtQuickCoil.Rows[0]["GCGPSI"].ToString()),
                GasAirFlow = float.Parse(dtQuickCoil.Rows[0]["GCGFLO"].ToString())/60.0F,
                Type = Type.RATING
            };

            //Coil are selected in Rating mode only.
            //will have this in their respective section
            //so we can allow Selection for some other coils.

            bool bolSelectionResult = dtQuickCoil.Rows[0]["GCNumberOfCircuits"].ToString() != "AUTOMATIC" ? coilSelection.ExecuteSelection(dtQuickCoil, ref errorMessage) : coilSelection.ExecuteAutomaticCircuitingSelection(dtQuickCoil, ref errorMessage);

            //dispose object

            return bolSelectionResult;
        }

        public bool Run_STEAM_Selection(DataTable dtQuickCoil, ref string errorMessage)
        {
            //create FH object
            var coilSelection = new Steam
            {
                Altitude = float.Parse(dtQuickCoil.Rows[0]["STEAMAltitude"].ToString()),
                CFM = float.Parse(dtQuickCoil.Rows[0]["STEAMAirFlowRate"].ToString()),
                CoilHeight = float.Parse(dtQuickCoil.Rows[0]["FinHeight"].ToString()),
                CoilLength = float.Parse(dtQuickCoil.Rows[0]["FinLength"].ToString()),
                EnteringDryBulb = float.Parse(dtQuickCoil.Rows[0]["STEAMEnteringDryBulb"].ToString()),
                FinMaterial = dtQuickCoil.Rows[0]["FinMaterial"].ToString(),
                FinShape = dtQuickCoil.Rows[0]["FinShape"].ToString(),
                FinsPerInch = float.Parse(dtQuickCoil.Rows[0]["FPI"].ToString()),
                FinThickness = float.Parse(dtQuickCoil.Rows[0]["FinThickness"].ToString()),
                FinType = dtQuickCoil.Rows[0]["FinType"].ToString(),
                NumberOfRows = float.Parse(dtQuickCoil.Rows[0]["Row"].ToString()),
                SteamPressure = float.Parse(dtQuickCoil.Rows[0]["STEAMSaturatedSteamPressure"].ToString()),
                TubeMaterial = dtQuickCoil.Rows[0]["TubeMaterial"].ToString(),
                TubeThickness = float.Parse(dtQuickCoil.Rows[0]["TubeThickness"].ToString()),
                Type = Type.RATING
            };

            //set the value

            //Coil are selected in Rating mode only.
            //will have this in their respective section
            //so we can allow Selection for some other coils.

            //execute the selection and pass the table to fill
            bool bolSelectionResult = coilSelection.ExecuteSelection(dtQuickCoil, ref errorMessage);

            //dispose object

            return bolSelectionResult;
        }

        //filter the casing material depending on the coil type
        public DataTable FilterCasingMaterial(DataTable dtvCoilCaisingMaterialDefaults, string strCoilType)
        {
            //filter on coil type
            DataRow[] drvCoilCaisingMaterialDefaults = dtvCoilCaisingMaterialDefaults.Copy().Select((strCoilType == ""? "":"CoilTypeParameter ='" + strCoilType + "'"));

            //create a clone table
            DataTable dtReturn = dtvCoilCaisingMaterialDefaults.Clone();

            //for each result add it to the cloned table
            for (int intArray = 0; intArray < drvCoilCaisingMaterialDefaults.Length; intArray++)
            {
                dtReturn.Rows.Add(drvCoilCaisingMaterialDefaults[intArray].ItemArray);
            }

            return dtReturn;
        }

        //filter the casing thickness depending on the casing material
        public DataTable FilterCasingThickness(DataTable dtCoilCasingThickness, int intCasingMaterialID)
        {
            //filter on casing material
            DataRow[] drCoilCasingThickness = dtCoilCasingThickness.Copy().Select("CasingMaterialID =" + intCasingMaterialID);

            //create a clone table
            DataTable dtReturn = dtCoilCasingThickness.Clone();

            //for each result add it to the cloned table
            for (int intArray = 0; intArray < drCoilCasingThickness.Length; intArray++)
            {
                dtReturn.Rows.Add(drCoilCasingThickness[intArray].ItemArray);
            }

            return dtReturn;
        }

        //filter the Header Diameter to get only the corresponding one to the coil type
        public DataTable FilterHeaderDiameter(DataTable dtvCoilHeaderDiameter, string strCoilType)
        {
            //filter on coil type
            DataRow[] drvCoilHeaderDiameter = dtvCoilHeaderDiameter.Copy().Select("CoilTypeParameter ='" + strCoilType + "'");

            //create a clone table
            DataTable dtReturn = dtvCoilHeaderDiameter.Clone();

            //for each result add it to the cloned table
            for (int intArray = 0; intArray < drvCoilHeaderDiameter.Length; intArray++)
            {
                dtReturn.Rows.Add(drvCoilHeaderDiameter[intArray].ItemArray);
            }

            //use dataview to sort
            DataView dvReturn = dtReturn.DefaultView;

            //sort
            dvReturn.Sort = "HeaderDiameterValue ASC";

            //set the return table
            dtReturn = dvReturn.ToTable();

            //disposed
            dvReturn.Dispose();

            return dtReturn;
        }
        //fill the circuits
        public void Fill_Circuit(ComboBox cboCircuits, int intMin/*, decimal decNumberOfHeaders*/)
        {
            //clean the combobox
            cboCircuits.Items.Clear();

            ////if the number of headers is 0 then only 1 circuits available
            //if (decNumberOfHeaders == 0m)
            //{
            //    cboCircuits.Items.Add("1");
            //}
            //else
            //{//if 1 or more header selected then automatic is available
            //    //and from 2 to 96 circuits

            //add automatic
            cboCircuits.Items.Add("AUTOMATIC");
            //loop to add circuits from 2 to 350
            for (int intLoop = intMin; intLoop <= 350; intLoop++)
            {
                cboCircuits.Items.Add(intLoop.ToString(CultureInfo.InvariantCulture));
            }
            //}

            //if something is in the combobox select the first item
            if (cboCircuits.Items.Count > 0)
            {
                cboCircuits.SelectedIndex = 0;
            }
        }

        //fill the circuits
        public void Fill_Circuit(ComboBox cboCircuits/*, decimal decNumberOfHeaders*/)
        {
            Fill_Circuit(cboCircuits, 2);
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

        public decimal GetFreezingPoint(DataTable dtFluidFreezingPointTable, int intConcentration)
        {
            return Convert.ToDecimal(dtFluidFreezingPointTable.Select("Concentration = " + intConcentration)[0]["FreezingPoint"]);
        }

        public bool IsFinShapeAvailable(DataTable dtCoilFinTypeShape, string strFinType,string strFinShape)
        {
            if (dtCoilFinTypeShape.Select("FinType = '" + strFinType + "' AND FinShape = '" + strFinShape + "'").Length > 0)
            {
                return true;
            }
            return false;
        }

        //get the coil weight
        public decimal GetCoilWeight(decimal decFinHeight, decimal decFinLength, decimal decFaceTube, decimal decTubeDiameter, decimal decTubeRow, decimal decNumberOfRow, decimal decFPI, decimal decCasingDensity, decimal decCasingThickness, decimal decFinDensity, decimal decFinThickness, decimal decTubeDensity, decimal decTubeThickness, decimal decHeaderPoundsPerSquareFoot)
        {
            //create class
            var cw = new CoilWeight();
            //get the weight
            decimal decCoilWeight = cw.GetCoilTotalWeight(decFinHeight, decFinLength, decFaceTube, decTubeDiameter, decTubeRow, decNumberOfRow, decFPI, decCasingDensity, decCasingThickness, decFinDensity, decFinThickness, decTubeDensity, decTubeThickness, decHeaderPoundsPerSquareFoot);
            //dispose class
            //return value
            return decCoilWeight;
        }

        public enum SteamCoilConnection{Steam=0,Condensate=1};
        //this return the connection of the steam. if std it replace
        //by the good one
        public string GetSteamConnection(DataTable dtCoilSteamMPTConnection, string strSteamCoilType, decimal decFinHeight, decimal decFinLength, decimal decNumberOfRows, string strConnectionSize, SteamCoilConnection connection)
        {
            //if it's STD change it
            if (strConnectionSize == "STD")
            {
                DataRow[] drCoilSteamMPTConnection = dtCoilSteamMPTConnection.Select("Type ='" + strSteamCoilType + "' AND FinHeightMin <= " + decFinHeight + " AND FinHeightMax >= " + decFinHeight + " AND FinLengthMin <= " + decFinLength + " AND FinLengthMax >= " + decFinLength + " AND Row =" + decNumberOfRows);
                if (drCoilSteamMPTConnection.Length > 0)
                {
                    if (connection == SteamCoilConnection.Steam)
                    {
                        return drCoilSteamMPTConnection[0]["SteamConnection"].ToString();
                    }
                    return drCoilSteamMPTConnection[0]["CondensateConnection"].ToString();
                }
                return strConnectionSize;
            }
            return strConnectionSize;
        }

        public int GetHeaderQuantity_ST(string strSteamCoilType, decimal decFinLength)
        {
            //2008-12-05: this logic doesn't follow any table logic given by Sylvain
            if (strSteamCoilType == "Steam Distributing" && decFinLength <= 84m)
            {
                return 1;
            }
            return 2;
        }

        //return the header quantity
        public int GetHeaderQuantity_FC_FH_DX_HR(DataTable dtCoilFinType, decimal decFinHeight, string strFinType)
        {
            //this is the max height per sets of header
            //i.e the max is 60 inch if we have lower than 60 inch high coil only 1 set
            // 61 to 120 (2X60) 2 sets
            decimal decMaxFinHeightPerHeaderSet = Convert.ToDecimal(dtCoilFinType.Select("FinType = '" + strFinType + "'")[0]["FinHeightPerSetOfHeader"]);

            //if we do a ceiling of fin height / by the max it will 
            //give us the exact amout of headers we need
            return Convert.ToInt32(Math.Ceiling(decFinHeight / decMaxFinHeightPerHeaderSet));
        }

        //return the connection size for the FC and FH, they use same logic and table
        public decimal GetConnectionSizeFCFH(DataTable dtConnectionSizeFluidHeatingFluidCooling, decimal decGPM, string coilDesign, string connectionType)
        {
            decimal decReturnValue = 99m;

            string strFilter = connectionType + (coilDesign == "Standard" ? "NB" : "B");

            //get the connection list
            DataTable dtProperConnectionSize = Public.SelectAndSortTable(dtConnectionSizeFluidHeatingFluidCooling, "Availability Like '%" + strFilter + "%' AND MaxGPM >= " + decGPM, "MaxGPM");

            if (dtProperConnectionSize.Rows.Count > 0)
            {
                decReturnValue = Convert.ToDecimal(dtProperConnectionSize.Rows[0]["value"]);
            }

            dtProperConnectionSize.Dispose();

            return decReturnValue;
        }

        //return the connection size of the DX OutLet
        public decimal GetConnectionSizeDXOutlet(DataTable dtStandardConnectionDXOutlet,decimal decSaturatedSuctionTemperature, decimal decCapacity, decimal decLine, string strRefrigerant)
        {
            DataRow[] drStandardConnectionDXOutlet = dtStandardConnectionDXOutlet.Select( decSaturatedSuctionTemperature + " >= MinTemp AND " +decSaturatedSuctionTemperature + " < MaxTemp AND " + decCapacity + " > MinCap AND " + decCapacity + " <= MaxCap AND " + decLine + " > MinLine AND " + decLine + " <= MaxLine AND Refrigerant = '" + strRefrigerant.ToUpper() + "'");

            //if we have result return the connection, else special
            if (drStandardConnectionDXOutlet.Length > 0)
            {
                return Convert.ToDecimal(drStandardConnectionDXOutlet[0]["Value"]);
            }
            //return 99 so we know the connection has not been selected
            return 99m;
        }

        //return the connection size of the DX Inlet
        public decimal GetConnectionSizeDXInlet(DataTable dtStandardConnectionDXInlet, decimal decCapacity, decimal decLine, string strRefrigerant)
        {
            DataRow[] drStandardConnectionDXInlet = dtStandardConnectionDXInlet.Select( decCapacity + " > MinCap AND " +  decCapacity + " <= MaxCap AND " + decLine + " > MinLine AND " + decLine + " <= MaxLine AND Refrigerant = '" + strRefrigerant.ToUpper() + "'");

            //if we have result return the connection, else special
            if (drStandardConnectionDXInlet.Length > 0)
            {
                return Convert.ToDecimal(drStandardConnectionDXInlet[0]["Value"]);
            }
            //return 99 so we know the connection has not been selected
            return 99m;
        }

        //return the connection size of the COND Outlet
        public decimal GetConnectionSizeHROutlet(DataTable dtStandardConnectionCondenserOutlet, decimal decCapacity, decimal decLine, string strRefrigerant)
        {
            DataRow[] drStandardConnectionCondenserOutlet = dtStandardConnectionCondenserOutlet.Select(0.75m * decCapacity + " > MinCap AND " + 0.75m * decCapacity + " <= MaxCap AND " + decLine + " > MinLine AND " + decLine + " <= MaxLine AND Refrigerant = '" + strRefrigerant.ToUpper() + "'");

            //if we have result return the connection, else special
            if (drStandardConnectionCondenserOutlet.Length > 0)
            {
                decimal decConnection = Convert.ToDecimal(drStandardConnectionCondenserOutlet[0]["Value"]);

                //2010-09-23 : As per email confirmation of Simon on 2010-09-22 3:09 PM
                //Question : 
                //Toutes les restrictions sur quoi que ce soit, qui ont rapport au R-410a 
                //et qui touche au Coil ou au Condensers doivent etre enlevées. 
                //Answer : 
                //Oui c’est confirmé.
                
                ////2009-05-26: Added because Anthony said : 
                ////on R-410A Only connection sizes that are presently certified are 1 1/8 and 2 1/8
                ////All connections sizes that are 1 3/8, 1 5/8 or 1 7/8 should be changed to 2 1/8.  
                ////Anything below 1 1/8 should be increased to 1 1/8.
                ////All connections that are larger than 2 1/8....should contact 
                ////factory for special verification
                //if (strRefrigerant == "R-410A")
                //{
                //    if (decConnection < 1.125m)
                //    {
                //        decConnection = 1.125m;
                //    }
                //    else if (decConnection < 2.125m)
                //    {
                //        decConnection = 2.125m;
                //    }
                //    else
                //    {
                //        //10 is use to know it's special
                //        decConnection = 10m;
                //    }
                //}

                return decConnection;
            }
            //return 99 so we know the connection has not been selected
            return 99m;
        }

        //return the connection size of the COND Inlet
        public decimal GetConnectionSizeHRInlet(DataTable dtStandardConnectionCondenserInlet, decimal decCapacity, decimal decLine, string strRefrigerant)
        {
            DataRow[] drStandardConnectionCondenserInlet = dtStandardConnectionCondenserInlet.Select(0.75m * decCapacity + " > MinCap AND " + 0.75m * decCapacity + " <= MaxCap AND " + decLine + " > MinLine AND " + decLine + " <= MaxLine AND Refrigerant = '" + strRefrigerant.ToUpper() + "'");

            //if we have result return the connection, else special
            if (drStandardConnectionCondenserInlet.Length > 0)
            {
                decimal decConnection = Convert.ToDecimal(drStandardConnectionCondenserInlet[0]["Value"]);
                return decConnection;
            }
            //return 99 so we know the connection has not been selected
            return 99m;
        }

        //return the pounds per foot of the header (inlet ocnnection)
        public decimal ConnectionSizePoundsPerFoot(DataTable dtConnectionSizePoundsPerFoot, decimal decConnectionSize)
        {
            //select the connection
            DataRow[] drConnectionSizePoundsPerFoot = dtConnectionSizePoundsPerFoot.Select("ConnectionSize = " + decConnectionSize);

            //if the connection exist return the value else return 0
            if (drConnectionSizePoundsPerFoot.Length > 0)
            {
                return Convert.ToDecimal(drConnectionSizePoundsPerFoot[0]["LbsPerFoot"]);
            }
            return 0m;
        }

        public string ARI_Standard_DX()
        {
            return AriRated;
        }

        public string ARI_Standard_HR()
        {
            return AriRated;
        }

        public string ARI_Standard_STEAM()
        {
            return AriRated;
        }

        public string ARI_Standard_FC(string strFinType, decimal decFinHeight, decimal decFinTypeFaceTube, decimal decFaceVelocity, decimal decEnteringDryBulb, decimal decEnteringWetBulb, decimal decFluidVelocity, decimal decEnteringLiquidTemperature, string strFluidType, decimal decConcentration)
        {
            //2012-02-17 : #1974 : ARI certified range change for water coil water velocity
            //must be between 1.5 and 5.5 to be certified
            if ((strFinType == "G" || strFinType == "F" ) && ((decFaceVelocity >= 200m && decFaceVelocity <= 800m) &&
                (decEnteringDryBulb >= 65m && decEnteringDryBulb <= 100m) &&
                (decEnteringWetBulb >= 65m && decEnteringWetBulb <= 85m) &&
                (((decFluidVelocity >= 1.5m && decFluidVelocity <= 8m))) &&
                (((decEnteringLiquidTemperature >= 35m && decEnteringLiquidTemperature <= 65m) && strFluidType == "WTR"))))
            {
                return AriCertified;
            }
            return ((strFinType == "G" || strFinType == "F") && strFluidType == "WTR")? AriOutside : AriRated;
        }

        public string ARI_Standard_FH(string strFinType, decimal decFinHeight, decimal decFinTypeFaceTube, decimal decFaceVelocity, decimal decEnteringDryBulb, decimal decFluidVelocity, decimal decEnteringLiquidTemperature, string strFluidType, decimal decConcentration)
        {
            //2012-10-25 : #3473 : new condition and rating
            if ((strFinType == "G" || strFinType == "F") && ((decFaceVelocity >= 200m && decFaceVelocity <= 1500m) &&
                (((decEnteringDryBulb >= 0m && decEnteringDryBulb <= 100m) && strFluidType == "WTR")) &&
                (((decFluidVelocity >= 1.5m && decFluidVelocity <= 8m) && strFluidType == "WTR")) &&
                (((decEnteringLiquidTemperature >= 120m && decEnteringLiquidTemperature <= 250m) && strFluidType == "WTR"))))
            {
                return AriCertified;
            }
            return ((strFinType == "G" || strFinType == "F") && strFluidType == "WTR") ? AriOutside : AriRated;
        }

        public void Fill_FC_FH_Circuits(ComboBox cboCircuits,DesignType design)
        {
            cboCircuits.Items.Clear();
            cboCircuits.Items.Add("AUTOMATIC");

            if (design == DesignType.Standard)
            {//standard have from 2 to 350
                for (int intCircuits = 2; intCircuits <= 350; intCircuits++)
                {
                    cboCircuits.Items.Add(intCircuits.ToString(CultureInfo.InvariantCulture));
                }
            }
            else
            {//Booster have only 1 and 2
                cboCircuits.Items.Add("1");
                cboCircuits.Items.Add("2");
            }

            cboCircuits.SelectedIndex = 0;
        }

    }

    enum DesignType {Standard=0,Booster=1};
}
