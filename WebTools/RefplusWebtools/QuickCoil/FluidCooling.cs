using System;
using System.Data;
using System.Collections;

namespace RefplusWebtools.QuickCoil
{
    class FluidCooling
    {
        private string _cho = "R"; //type R = rating S = Selection
        private float _ch; //Coil Height
        private float _cl; //Coil Lenght
        private string _fl = ""; //Water EG PG
        private float _cg; //concentration of fluid 100 for water
        private const string Cfmt = "S"; //air flow type
        private float _cfm; //CFM
        private float _dbe; //Entering Dry Bulb
        private float _wbe; //Entering Wet Bulb
        private float _we; //Entering Liquid Temperature
        private float _cir; //number of circuits
        private float _fpi; //fins per inch
        private string _fm = ""; // Fin Material
        private float _yf; //fins thickness
        private string _tm = ""; //tube material
        private float _row; //number of rows
        private float _tt; //tube thickness
        private string _ctyp = ""; //Coil Type
        private float _altd; //Altitude
        private string _turb = ""; //Turbulator
        private float _gpm; //GPM
        private float _dt; //Difference between entering and leaving
        private string _oddf = ""; //Odd Rows Y = yes or N = no
        private string _connectionSize = ""; //connection size
        //used to set CoilType which is _fintype + _finshape
        private string _finType = "";
        private string _finShape = "";

        public float EnteringWetBulb
        {
            get { return _wbe; }
            set { _wbe = value; }
        }

        public string ConnectionSize
        {
            get { return _connectionSize; }
            set { _connectionSize = value; }
        }

        public float DifferenceBetweenEnteringAndLeaving
        {
            get { return _dt; }
            set { _dt = value; }
        }

        public float GPM
        {
            get { return _gpm; }
            set { _gpm = value; }
        }

        public string Turbulator
        {
            get { return _turb; }
            set { _turb = value; }
        }

        public float EnteringLiquidTemperature
        {
            get { return _we; }
            set { _we = value; }
        }

        public float Concentration
        {
            get { return _cg; }
            set { _cg = value; }
        }

        public string Type
        {
            get { return _cho; }
            set { _cho = value; }
        }

        public float CoilHeight
        {
            get { return _ch; }
            set { _ch = value; }
        }

        public float CoilLength
        {
            get { return _cl; }
            set { _cl = value; }
        }

        public string RefrigerantType
        {
            get { return _fl; }
            set { _fl = value; }
        }

        public float CFM
        {
            get { return _cfm; }
            set { _cfm = value; }
        }

        public float EnteringDryBulb
        {
            get { return _dbe; }
            set { _dbe = value; }
        }
        
        public float NumberOfCircuits
        {
            get { return _cir; }
            set { _cir = value; }
        }

        public float FinsPerInch
        {
            get { return _fpi; }
            set { _fpi = value; }
        }

        public string FinMaterial
        {
            get { return _fm; }
            set { _fm = value; }
        }

        public float FinThickness
        {
            get { return _yf; }
            set { _yf = value; }
        }

        public string TubeMaterial
        {
            get { return _tm; }
            set { _tm = value; }
        }

        public float NumberOfRows
        {
            get { return _row; }
            set
            {
                _row = value;
                _oddf = _row % 2.0F > 0 ? "Y" : "N";
            }
        }

        public float TubeThickness
        {
            get { return _tt; }
            set { _tt = value; }
        }

        public string FinType
        {
            get { return _finType; }
            set
            {
                _finType = value;
                _ctyp = _finType + _finShape;
            }
        }

        public string FinShape
        {
            get { return _finShape; }
            set
            {
                _finShape = value;
                _ctyp = _finType + _finShape;
            }
        }

        public float Altitude
        {
            get { return _altd; }
            set { _altd = value; }
        }

        public bool ExecuteSelection(DataTable dtQuickCoilInformations, ref string errorMessage)
        {
            var kfFC = new ChillWaterCoil.ChillWaterCoil
            {
                CHO = _cho,
                CH = _ch,
                CL = _cl,
                FL = _fl,
                CG = _cg,
                CFMT = Cfmt,
                CFM = _cfm,
                DBE = _dbe,
                WBE = _wbe,
                WE = _we,
                CIR = _cir,
                FPI = _fpi,
                FM = _fm,
                YF = _yf,
                TM = _tm,
                Row = _row,
                TT = _tt,
                CTYP = _ctyp,
                ALTD = _altd,
                TURB = _turb
            };
            //KFRefplus.CoolingClass kfFC = new KFRefplus.CoolingClass();

            if (_gpm > 0)
            {
                kfFC.GPM = _gpm; //GPM
            }
            else
            {
                kfFC.DT = _dt; //Difference between entering and leaving
            }

            kfFC.FFO = 0f;
            kfFC.FFI = 0f;

            //object obj = _ConnectionSize;
            //kfFC.let_Conn(ref obj);

            kfFC.Conn = (float)Convert.ToDecimal( _connectionSize);

            kfFC.ODDF = _oddf; //Odd Rows Y = yes or N = no
            if (dtQuickCoilInformations.Rows[0]["FCFluidType"].ToString() == "OTHER")
            {
                kfFC.CPG = float.Parse(dtQuickCoilInformations.Rows[0]["FCSpecificHeat"].ToString());
                kfFC.DPG = float.Parse(dtQuickCoilInformations.Rows[0]["FCDensity"].ToString());
                kfFC.UVG = float.Parse(dtQuickCoilInformations.Rows[0]["FCViscosity"].ToString());
                kfFC.TKG = float.Parse(dtQuickCoilInformations.Rows[0]["FCThermalConductivity"].ToString());
            }
            try
            {
                kfFC.DESIGN(Public.CoilDllKey);

                dtQuickCoilInformations.Rows[0]["R_Rows"] = (decimal)kfFC.Row;
                dtQuickCoilInformations.Rows[0]["R_NumberOfCircuits"] = (decimal)kfFC.CIRZ;
                dtQuickCoilInformations.Rows[0]["R_FPI"] = (decimal)kfFC.FPIZ;
                dtQuickCoilInformations.Rows[0]["R_ConnectionSize"] = (decimal)kfFC.conns;
                dtQuickCoilInformations.Rows[0]["R_CoilFaceArea"] = (decimal)kfFC.FA;
                dtQuickCoilInformations.Rows[0]["R_FaceVelocity"] = (decimal)kfFC.AFAV;
                dtQuickCoilInformations.Rows[0]["R_AirPressureDrop"] = (decimal)kfFC.DPAJZ;
                dtQuickCoilInformations.Rows[0]["R_LeavingDryBulb"] = (decimal)kfFC.AT2Z;
                dtQuickCoilInformations.Rows[0]["R_LeavingWetBulb"] = (decimal)kfFC.WBLAZ;
                dtQuickCoilInformations.Rows[0]["R_SensibleHeat"] = (decimal)kfFC.SHAZ;
                dtQuickCoilInformations.Rows[0]["R_TotalHeat"] = (decimal)kfFC.QAZ;
                dtQuickCoilInformations.Rows[0]["R_LeavingLiquidTemperature"] = (decimal)kfFC.AWLZ;
                dtQuickCoilInformations.Rows[0]["R_GPM"] = (decimal)kfFC.GPMZ;
                dtQuickCoilInformations.Rows[0]["R_WaterVelocity"] = (decimal)kfFC.VWZ;
                dtQuickCoilInformations.Rows[0]["R_RefrigerantPressureDrop"] = (decimal)kfFC.DP1Z / 2.306666666666m;

                if (kfFC.SHAZ < 0 || kfFC.QAZ < 0)
                {
                    errorMessage = "Invalid Parameter";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"FluidCooling ExecuteSelection");
                errorMessage = ex.Message;
                //an error happen while selecting a coil, return false
                return false;
            }
        }

        public bool ExecuteAutomaticCircuitingSelection(DataTable dtQuickCoilInformations, ref string errorMessage)
        {
            //this return the possible circuits automatic
            int[] intPossibleCircuits = GetPossibleCircuits((dtQuickCoilInformations.Rows[0]["FCDesignType"].ToString() == "Standard" ? DesignType.Standard : DesignType.Booster), Convert.ToDecimal(dtQuickCoilInformations.Rows[0]["FinHeight"]) / Convert.ToDecimal(dtQuickCoilInformations.Rows[0]["FaceTube"]) * Convert.ToDecimal(dtQuickCoilInformations.Rows[0]["Row"]));

            //2012-07-31 : #3249 : changing the automatic selection to run all circuit since some are
            //crashing in ravi dll and keep the best one of them
            int bestCircuit = 0;
            float bestCircuitPressureDrop = 0f;
            float maxPressureDropAllowed = float.Parse(dtQuickCoilInformations.Rows[0]["FCMaxPressure"].ToString()) * 2.306666666666f;

            ////these handle the gpm gap we use
            //float[] fltGap = { 10f, 5f, 2f, 1f };

            ChillWaterCoil.ChillWaterCoil kfFC;
            //KFRefplus.CoolingClass kfFC = new KFRefplus.CoolingClass();

            //for (int intGap = 0; intGap < fltGap.Length; intGap++)
            for (int intGap = 0; intGap < intPossibleCircuits.Length; intGap++)
            {
                //kfFC.DP1Z = 10000f;
                //while (kfFC.DP1Z > float.Parse(dtQuickCoilInformations.Rows[0]["FCMaxPressure"].ToString()) * 2.306666666666f)
                //{
                kfFC = new ChillWaterCoil.ChillWaterCoil
                {
                    CHO = _cho,
                    CH = _ch,
                    CL = _cl,
                    FL = _fl,
                    CG = _cg,
                    CFM = _cfm,
                    DBE = _dbe,
                    WBE = _wbe,
                    WE = _we,
                    CIR = intPossibleCircuits[intGap],
                    FPI = _fpi,
                    FM = _fm,
                    YF = _yf,
                    TM = _tm,
                    Row = _row,
                    TT = _tt,
                    CTYP = _ctyp,
                    ALTD = (_altd <= 500f ? 0f : _altd),
                    CFMT = "A",
                    TURB = _turb
                };
                //kfFC = new KFRefplus.CoolingClass();

                //kfFC.CIR = kfFC.CIR + fltGap[intGap];//number of circuits
                //2011-08-22 : #1146 due to cfm being miscalculated we need to use ACFM and < 500ft count as 0ft
                //kfFC.ALTD = _ALTD; //Altitude
                //kfFC.CFMT = _CFMT; //air flow type

                if (_gpm > 0)
                {
                    kfFC.GPM = _gpm; //GPM
                }
                else
                {
                    kfFC.DT = _dt; //Difference between entering and leaving
                }

                kfFC.FFO = 0f;
                kfFC.FFI = 0f;

                //object obj = _ConnectionSize;
                //kfFC.let_Conn(ref obj);

                kfFC.Conn = (float)Convert.ToDecimal(_connectionSize);

                kfFC.ODDF = _oddf; //Odd Rows Y = yes or N = no
                if (dtQuickCoilInformations.Rows[0]["FCFluidType"].ToString() == "OTHER")
                {
                    kfFC.CPG = float.Parse(dtQuickCoilInformations.Rows[0]["FCSpecificHeat"].ToString());
                    kfFC.DPG = float.Parse(dtQuickCoilInformations.Rows[0]["FCDensity"].ToString());
                    kfFC.UVG = float.Parse(dtQuickCoilInformations.Rows[0]["FCViscosity"].ToString());
                    kfFC.TKG = float.Parse(dtQuickCoilInformations.Rows[0]["FCThermalConductivity"].ToString());
                }

                try
                {
                    kfFC.DESIGN(Public.CoilDllKey);

                    if (kfFC.DP1Z <= maxPressureDropAllowed && kfFC.DP1Z > bestCircuitPressureDrop)
                    {
                        bestCircuitPressureDrop = kfFC.DP1Z;
                        bestCircuit = intPossibleCircuits[intGap];
                    }
                }
                catch (Exception ex)
                {
                    Public.PushLog(ex.ToString(),"FluidCooling ExecuteAutomaticCircuitingSelection");
                }
            }

            try
            {

                var fltLastCircuit = (float)bestCircuit;

                kfFC = new ChillWaterCoil.ChillWaterCoil
                {
                    CHO = _cho,
                    CH = _ch,
                    CL = _cl,
                    FL = _fl,
                    CG = _cg,
                    CFM = _cfm,
                    DBE = _dbe,
                    WBE = _wbe,
                    WE = _we,
                    CIR = fltLastCircuit,
                    FPI = _fpi,
                    FM = _fm,
                    YF = _yf,
                    TM = _tm,
                    Row = _row,
                    TT = _tt,
                    CTYP = _ctyp,
                    ALTD = (_altd <= 500f ? 0f : _altd),
                    CFMT = "A",
                    TURB = _turb
                };
                //kfFC = new KFRefplus.CoolingClass();
                //kfFC.CIR = kfFC.CIR + fltGap[intGap];//number of circuits
                //2011-08-22 : #1146 due to cfm being miscalculated we need to use ACFM and < 500ft count as 0ft
                //kfFC.ALTD = _ALTD; //Altitude 
                //kfFC.CFMT = _CFMT; //air flow type

                if (_gpm > 0)
                {
                    kfFC.GPM = _gpm; //GPM
                }
                else
                {
                    kfFC.DT = _dt; //Difference between entering and leaving
                }

                kfFC.FFO = 0f;
                kfFC.FFI = 0f;

                //object obj = _ConnectionSize;
                //kfFC.let_Conn(ref obj);

                kfFC.Conn = (float)Convert.ToDecimal(_connectionSize);

                kfFC.ODDF = _oddf; //Odd Rows Y = yes or N = no
                if (dtQuickCoilInformations.Rows[0]["FCFluidType"].ToString() == "OTHER")
                {
                    kfFC.CPG = float.Parse(dtQuickCoilInformations.Rows[0]["FCSpecificHeat"].ToString());
                    kfFC.DPG = float.Parse(dtQuickCoilInformations.Rows[0]["FCDensity"].ToString());
                    kfFC.UVG = float.Parse(dtQuickCoilInformations.Rows[0]["FCViscosity"].ToString());
                    kfFC.TKG = float.Parse(dtQuickCoilInformations.Rows[0]["FCThermalConductivity"].ToString());
                }

                ////since we increase 1 value and the other lower we need to add
                ////the last gap we are using
                ////kfFC.CIR = kfFC.CIR + fltGap[fltGap.Length - 1];
                //kfFC.CIR = (float)intPossibleCircuits[intPossibleCircuits.Length - 1];


                kfFC.DESIGN(Public.CoilDllKey);

                dtQuickCoilInformations.Rows[0]["R_Rows"] = (decimal)kfFC.Row;
                dtQuickCoilInformations.Rows[0]["R_NumberOfCircuits"] = (decimal)kfFC.CIRZ;
                dtQuickCoilInformations.Rows[0]["R_FPI"] = (decimal)kfFC.FPIZ;
                dtQuickCoilInformations.Rows[0]["R_ConnectionSize"] = (decimal)kfFC.conns;
                dtQuickCoilInformations.Rows[0]["R_CoilFaceArea"] = (decimal)kfFC.FA;
                dtQuickCoilInformations.Rows[0]["R_FaceVelocity"] = (decimal)kfFC.AFAV;
                dtQuickCoilInformations.Rows[0]["R_AirPressureDrop"] = (decimal)kfFC.DPAJZ;
                dtQuickCoilInformations.Rows[0]["R_LeavingDryBulb"] = (decimal)kfFC.AT2Z;
                dtQuickCoilInformations.Rows[0]["R_LeavingWetBulb"] = (decimal)kfFC.WBLAZ;
                dtQuickCoilInformations.Rows[0]["R_SensibleHeat"] = (decimal)kfFC.SHAZ;
                dtQuickCoilInformations.Rows[0]["R_TotalHeat"] = (decimal)kfFC.QAZ;
                dtQuickCoilInformations.Rows[0]["R_LeavingLiquidTemperature"] = (decimal)kfFC.AWLZ;
                dtQuickCoilInformations.Rows[0]["R_GPM"] = (decimal)kfFC.GPMZ;
                dtQuickCoilInformations.Rows[0]["R_WaterVelocity"] = (decimal)kfFC.VWZ;
                dtQuickCoilInformations.Rows[0]["R_RefrigerantPressureDrop"] = (decimal)kfFC.DP1Z / 2.306666666666m;

                if (kfFC.SHAZ < 0 || kfFC.QAZ < 0)
                {
                    errorMessage = "Invalid Parameter";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"FluidCooling ExecuteAutomaticCircuitingSelection catch2");
                if (ex != null)
                {
                    errorMessage = ex.Message;
                }
                //an error happen while selecting a coil, return false
                return false;
            }
        }

        private int[] GetPossibleCircuits(DesignType design, decimal decTotalNumberOfTubes)
        {
            if (design == DesignType.Standard)
            {
                var arList = new ArrayList();

                //loop to find all possible circuits
                for (int intCircuits = 350; intCircuits >= 2; intCircuits--)
                {
                    decimal decTubesPerCircuits = decTotalNumberOfTubes / intCircuits;

                    //decimal decNotOppositeSideConnectionTest = Math  .Floor(decTubesPerCircuits) / 2m;

                    //if (decTubesPerCircuits == Math.Floor(decTubesPerCircuits) && decNotOppositeSideConnectionTest == Math.Floor(decNotOppositeSideConnectionTest))
                    //{
                    //    arList.Add(intCircuits);
                    //}

                    if (decTubesPerCircuits == Math.Floor(decTubesPerCircuits))
                    {
                        arList.Add(intCircuits);
                    }
                }

                //put them in a int array
                var intReturnValue = new int[arList.Count];
                for (int intResult = 0; intResult < intReturnValue.Length; intResult++)
                {
                    intReturnValue[intResult] = Convert.ToInt32(arList[intResult]);
                }

                return intReturnValue;
            }
            //booster is only 1 and 2 all time
            return new[] { 1, 2 };
        }
    }
}
