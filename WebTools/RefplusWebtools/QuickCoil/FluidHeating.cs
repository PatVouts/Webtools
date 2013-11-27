using System;
using System.Data;
using System.Collections;

namespace RefplusWebtools.QuickCoil
{
    class FluidHeating
    {
        private string _cho = "R"; //type R = rating S = Selection
        private float _ch; //Coil Height
        private float _cl; //Coil Lenght
        private string _fl = ""; //Water EG PG
        private float _cg; //concentration of fluid 100 for water
        private float _cfm; //CFM
        private float _dbe; //Entering Dry Bulb
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
            var kfFH = new HotWaterCoil.HotWaterCoil
            {
                CHO = _cho,
                CH = _ch,
                CL = _cl,
                FL = _fl,
                CG = _cg,
                CFM = _cfm,
                DBE = _dbe,
                WE = _we,
                CIR = _cir,
                FPI = _fpi,
                FM = _fm,
                YF = _yf,
                TM = _tm,
                Row = _row,
                TT = _tt,
                CTYP = _ctyp,
                ALTD = (_altd <= 500f ? 0f : _altd),
                CFMT = "A",
                TURB = _turb,
                DP = 10f*2.306f
            };
            //KFRefplus.HeaterClass kfFH = new KFRefplus.HeaterClass();

            //2011-08-22 : #1146 due to cfm being miscalculated we need to use ACFM and < 500ft count as 0ft
            //kfFH.ALTD = _ALTD; //Altitude 
            //kfFH.CFMT = _CFMT; //air flow type

            if (_gpm > 0)
            {
                kfFH.GPM = _gpm; //GPM
            }
            else
            {
                kfFH.DT = _dt; //Difference between entering and leaving
            }

            kfFH.FFO = 0f;
            kfFH.FFI = 0f;

            //object obj = _ConnectionSize;
            kfFH.conns = _connectionSize;
            //kfFH.let_conns(ref obj);
            kfFH.ODDF = _oddf; //Odd Rows Y = yes or N = no
            if (dtQuickCoilInformations.Rows[0]["FHFluidType"].ToString() == "OTHER")
            {
                kfFH.CPG = float.Parse(dtQuickCoilInformations.Rows[0]["FHSpecificHeat"].ToString());
                kfFH.DPG = float.Parse(dtQuickCoilInformations.Rows[0]["FHDensity"].ToString());
                kfFH.UVG = float.Parse(dtQuickCoilInformations.Rows[0]["FHViscosity"].ToString());
                kfFH.TKG = float.Parse(dtQuickCoilInformations.Rows[0]["FHThermalConductivity"].ToString());
            }
            try
            {
                kfFH.DESIGN(Public.CoilDllKey);

                dtQuickCoilInformations.Rows[0]["R_Rows"] = (decimal)kfFH.Row;
                dtQuickCoilInformations.Rows[0]["R_NumberOfCircuits"] = (decimal)kfFH.CIRZ;
                dtQuickCoilInformations.Rows[0]["R_FPI"] = (decimal)kfFH.FPIZ;
                dtQuickCoilInformations.Rows[0]["R_ConnectionSize"] = (decimal)kfFH.Connz;
                dtQuickCoilInformations.Rows[0]["R_CoilFaceArea"] = (decimal)kfFH.FA;
                dtQuickCoilInformations.Rows[0]["R_FaceVelocity"] = (decimal)kfFH.AFAV;
                dtQuickCoilInformations.Rows[0]["R_AirPressureDrop"] = (decimal)kfFH.DPAJZ;
                dtQuickCoilInformations.Rows[0]["R_LeavingDryBulb"] = (decimal)kfFH.AT2Z;
                dtQuickCoilInformations.Rows[0]["R_SensibleHeat"] = (decimal)kfFH.SHAZ;
                dtQuickCoilInformations.Rows[0]["R_TotalHeat"] = (decimal)kfFH.SHAZ;
                dtQuickCoilInformations.Rows[0]["R_LeavingLiquidTemperature"] = (decimal)kfFH.AWLZ;
                dtQuickCoilInformations.Rows[0]["R_GPM"] = (decimal)kfFH.GPMZ;
                dtQuickCoilInformations.Rows[0]["R_WaterVelocity"] = (decimal)kfFH.VWZ;
                dtQuickCoilInformations.Rows[0]["R_RefrigerantPressureDrop"] = (decimal)kfFH.DP1Z / 2.306666666666m;

                if (kfFH.SHAZ < 0)
                {
                    errorMessage = "Invalid Parameter";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"FluidHeating ExecuteSelection");
                errorMessage = ex.Message;
                //an error happen while selecting a coil, return false
                return false;
            }
        }

        public bool ExecuteAutomaticCircuitingSelection(DataTable dtQuickCoilInformations, ref string errorMessage)
        {
            //this return the possible circuits automatic
            int[] intPossibleCircuits = GetPossibleCircuits((dtQuickCoilInformations.Rows[0]["FHDesignType"].ToString() == "Standard" ? DesignType.Standard : DesignType.Booster), Convert.ToDecimal(dtQuickCoilInformations.Rows[0]["FinHeight"]) / Convert.ToDecimal(dtQuickCoilInformations.Rows[0]["FaceTube"]) * Convert.ToDecimal(dtQuickCoilInformations.Rows[0]["Row"]));

            //2012-08-01 : #3249 : changing the automatic selection to run all circuit since some are
            //crashing in ravi dll and keep the best one of them
            int bestCircuit = 0;
            float bestCircuitPressureDrop = 0f;
            float maxPressureDropAllowed = float.Parse(dtQuickCoilInformations.Rows[0]["FHMaxPressure"].ToString()) * 2.306666666666f;



            ////these handle the gpm gap we use
            //float[] fltGap = { 10f, 5f, 2f, 1f};
            HotWaterCoil.HotWaterCoil kfFH;
            //KFRefplus.HeaterClass kfFH = new KFRefplus.HeaterClass();

            //for (int intGap = 0; intGap < fltGap.Length; intGap++)
            for (int intGap = 0; intGap < intPossibleCircuits.Length; intGap++)
            {
                //kfFH.DP1Z = 10000f;
                //while (kfFH.DP1Z > float.Parse(dtQuickCoilInformations.Rows[0]["FHMaxPressure"].ToString())* 2.306666666666f)
                //{
                kfFH = new HotWaterCoil.HotWaterCoil
                {
                    CHO = _cho,
                    CH = _ch,
                    CL = _cl,
                    FL = _fl,
                    CG = _cg,
                    CFM = _cfm,
                    DBE = _dbe,
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
                    TURB = _turb,
                    DP = float.Parse(dtQuickCoilInformations.Rows[0]["FHMaxPressure"].ToString())*2.306666666666f
                };
                //kfFH = new KFRefplus.HeaterClass();

                //kfFH.CIR = kfFH.CIR + fltGap[intGap]; //number of circuits
                //2011-08-22 : #1146 due to cfm being miscalculated we need to use ACFM and < 500ft count as 0ft
                //kfFH.ALTD = _ALTD; //Altitude 
                //kfFH.CFMT = _CFMT; //air flow type

                if (_gpm > 0)
                {
                    kfFH.GPM = _gpm; //GPM
                }
                else
                {
                    kfFH.DT = _dt; //Difference between entering and leaving
                }

                kfFH.FFO = 0f;
                kfFH.FFI = 0f;

                //object obj = _ConnectionSize;
                //kfFH.let_conns(ref obj);

                kfFH.conns = _connectionSize;

                kfFH.ODDF = _oddf; //Odd Rows Y = yes or N = no

                if (dtQuickCoilInformations.Rows[0]["FHFluidType"].ToString() == "OTHER")
                {
                    kfFH.CPG = float.Parse(dtQuickCoilInformations.Rows[0]["FHSpecificHeat"].ToString());
                    kfFH.DPG = float.Parse(dtQuickCoilInformations.Rows[0]["FHDensity"].ToString());
                    kfFH.UVG = float.Parse(dtQuickCoilInformations.Rows[0]["FHViscosity"].ToString());
                    kfFH.TKG = float.Parse(dtQuickCoilInformations.Rows[0]["FHThermalConductivity"].ToString());
                }

                try
                {
                    kfFH.DESIGN(Public.CoilDllKey);

                    if (kfFH.DP1Z <= maxPressureDropAllowed && kfFH.DP1Z > bestCircuitPressureDrop)
                    {
                        bestCircuitPressureDrop = kfFH.DP1Z;
                        bestCircuit = intPossibleCircuits[intGap];
                    }
                }
                catch (Exception ex)
                {
                    Public.PushLog(ex.ToString(),"FluidHeating ExecuteAutomaticCircuitingSelection");
                }

            }

            try
            {

                var fltLastCircuit = (float)bestCircuit;

                kfFH = new HotWaterCoil.HotWaterCoil
                {
                    CHO = _cho,
                    CH = _ch,
                    CL = _cl,
                    FL = _fl,
                    CG = _cg,
                    CFM = _cfm,
                    DBE = _dbe,
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
                    TURB = _turb,
                    DP = float.Parse(dtQuickCoilInformations.Rows[0]["FHMaxPressure"].ToString())*2.306666666666f
                };
                //kfFH = new KFRefplus.HeaterClass();

                //kfFH.CIR = kfFH.CIR + fltGap[intGap]; //number of circuits
                //2011-08-22 : #1146 due to cfm being miscalculated we need to use ACFM and < 500ft count as 0ft
                //kfFH.ALTD = _ALTD; //Altitude 
                //kfFH.CFMT = _CFMT; //air flow type

                if (_gpm > 0)
                {
                    kfFH.GPM = _gpm; //GPM
                }
                else
                {
                    kfFH.DT = _dt; //Difference between entering and leaving
                }

                kfFH.FFO = 0f;
                kfFH.FFI = 0f;

                //object obj = _ConnectionSize;
                //kfFH.let_conns(ref obj);

                kfFH.conns = _connectionSize;

                kfFH.ODDF = _oddf; //Odd Rows Y = yes or N = no

                ////since we increase 1 value and the other lower we need to add
                ////the last gap we are using
                //kfFH.CIR = kfFH.CIR + fltGap[fltGap.Length - 1];

                if (dtQuickCoilInformations.Rows[0]["FHFluidType"].ToString() == "OTHER")
                {
                    kfFH.CPG = float.Parse(dtQuickCoilInformations.Rows[0]["FHSpecificHeat"].ToString());
                    kfFH.DPG = float.Parse(dtQuickCoilInformations.Rows[0]["FHDensity"].ToString());
                    kfFH.UVG = float.Parse(dtQuickCoilInformations.Rows[0]["FHViscosity"].ToString());
                    kfFH.TKG = float.Parse(dtQuickCoilInformations.Rows[0]["FHThermalConductivity"].ToString());
                }

                kfFH.DESIGN(Public.CoilDllKey);

                dtQuickCoilInformations.Rows[0]["R_Rows"] = (decimal)kfFH.Row;
                dtQuickCoilInformations.Rows[0]["R_NumberOfCircuits"] = (decimal)kfFH.CIRZ;
                dtQuickCoilInformations.Rows[0]["R_FPI"] = (decimal)kfFH.FPIZ;
                dtQuickCoilInformations.Rows[0]["R_ConnectionSize"] = (decimal)kfFH.Connz;
                dtQuickCoilInformations.Rows[0]["R_CoilFaceArea"] = (decimal)kfFH.FA;
                dtQuickCoilInformations.Rows[0]["R_FaceVelocity"] = (decimal)kfFH.AFAV;
                dtQuickCoilInformations.Rows[0]["R_AirPressureDrop"] = (decimal)kfFH.DPAJZ;
                dtQuickCoilInformations.Rows[0]["R_LeavingDryBulb"] = (decimal)kfFH.AT2Z;
                dtQuickCoilInformations.Rows[0]["R_SensibleHeat"] = (decimal)kfFH.SHAZ;
                dtQuickCoilInformations.Rows[0]["R_TotalHeat"] = (decimal)kfFH.SHAZ;
                dtQuickCoilInformations.Rows[0]["R_LeavingLiquidTemperature"] = (decimal)kfFH.AWLZ;
                dtQuickCoilInformations.Rows[0]["R_GPM"] = (decimal)kfFH.GPMZ;
                dtQuickCoilInformations.Rows[0]["R_WaterVelocity"] = (decimal)kfFH.VWZ;
                dtQuickCoilInformations.Rows[0]["R_RefrigerantPressureDrop"] = (decimal)kfFH.DP1Z / 2.306666666666m;

                if (kfFH.SHAZ < 0)
                {
                    errorMessage = "Invalid Parameter";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"FluidHeating ExecuteAutomaticCircuitingSelection");
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

                    //decimal decNotOppositeSideConnectionTest = Math.Floor(decTubesPerCircuits) / 2m;

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
