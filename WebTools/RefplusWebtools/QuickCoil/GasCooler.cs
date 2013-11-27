using System;
using System.Data;
using System.Collections;

namespace RefplusWebtools.QuickCoil
{
    class GasCooler
    {
        private string _cho = "R"; //type R = rating S = Selection
        private float _ch; //Coil Height
        private float _cl; //Coil Lenght
        private string _fl = ""; //R-22 R-502 R-134A R-410A R-407C R-404A R-507
        private float _cfm; //CFM
        private float _dbe; //Entering Dry Bulb
        private float _cir; //number of circuits
        private float _fpi; //fins per inch
        private string _fm = ""; // Fin Material
        private float _yf; //fins thickness
        private string _tm = ""; //tube material
        private float _row; //number of rows
        private float _tt; //tube thickness
        private string _ctyp = ""; //Coil Type
        private const float Ffo = 0f; //Fin Side Fouling 
        private float _altd; //Altitude
        private string _ttyp = ""; //Tube Type
        private string _oddf = ""; //Odd Rows Y = yes or N = no
        private string _finType = "";
        private string _finShape = "";
        private float _gin; //Gas Entering Temperature
        private float _gpsi; //Gas Operating Pressure
        private float _gflo; //Gas Flow


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
                if (_finType == "K")
                {
                    _ctyp = _finType;
                }
                else
                {
                    _ctyp = _finType + _finShape;
                }
            }
        }

        public string FinShape
        {
            get { return _finShape; }
            set
            {
                _finShape = value;
                if (_finType == "K")
                {
                    _ctyp = _finType;
                }
                else
                {
                    _ctyp = _finType + _finShape;
                }
            }
        }

        public float Altitude
        {
            get { return _altd; }
            set { _altd = value; }
        }

        public string TubeType
        {
            get { return _ttyp; }
            set { _ttyp = value; }
        }

        public float GasTempIn
        {
            get { return _gin; }
            set { _gin = value; }
        }

        public float GasAirFlow
        {
            get { return _gflo; }
            set { _gflo = value; }
        }

        public float GasOperatingPressure
        {
            get { return _gpsi; }
            set { _gpsi = value; }
        }

        public bool ExecuteSelection(DataTable dtQuickCoilInformations, ref string errorMessage)
        {
            var kfGC = new GCCoil.Condensor
            {
                DES = "G",
                CHO = _cho,
                CH = _ch,
                CL = _cl,
                FL = _fl,
                CFM = _cfm,
                DBE = _dbe,
                CIR = _cir,
                FPI = _fpi,
                FM = _fm,
                YF = _yf,
                TM = _tm,
                Row = _row,
                TT = _tt,
                CTYP = _ctyp,
                FFO = Ffo,
                ALTD = (_altd <= 500f ? 0f : _altd),
                CFMT = "A",
                TTYP = "S",
                ODDF = _oddf,
                GPSI = _gpsi,
                GFLO = _gflo,
                GIN = _gin
            };


            try
            {
                kfGC.DESIGN(Public.CoilDllKey);

                //set the return values
                dtQuickCoilInformations.Rows[0]["R_NumberOfCircuits"] = (decimal)kfGC.CIRZ;
                dtQuickCoilInformations.Rows[0]["R_CoilFaceArea"] = (decimal)kfGC.FA;
                dtQuickCoilInformations.Rows[0]["R_FaceVelocity"] = (decimal)kfGC.AFAV;
                dtQuickCoilInformations.Rows[0]["R_AirPressureDrop"] = (decimal)kfGC.DPAJZ;
                dtQuickCoilInformations.Rows[0]["R_LeavingDryBulb"] = (decimal)kfGC.AT2Z;
                dtQuickCoilInformations.Rows[0]["R_RefrigerantPressureDrop"] = (decimal)kfGC.DP1Z;
                dtQuickCoilInformations.Rows[0]["R_GOUT"] = (decimal)kfGC.GOUT;
                dtQuickCoilInformations.Rows[0]["R_TotalHeat"] = (decimal)kfGC.SHAZ;
                

                if (kfGC.SHAZ < 0)
                {
                    errorMessage = "Invalid Parameter";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"GasCooler ExecuteSelection");
                errorMessage = ex.Message;
                //an error happen while selecting a coil, return false
                return false;
            }
        }

        public bool ExecuteAutomaticCircuitingSelection(DataTable dtQuickCoilInformations, ref string errorMessage)
        {
            //this return the possible circuits automatic
            int[] intPossibleCircuits = GetPossibleCircuits( Convert.ToDecimal(dtQuickCoilInformations.Rows[0]["FinHeight"]) / Convert.ToDecimal(dtQuickCoilInformations.Rows[0]["FaceTube"]) * Convert.ToDecimal(dtQuickCoilInformations.Rows[0]["Row"]));

            //2012-07-31 : #3249 : changing the automatic selection to run all circuit since some are
            //crashing in ravi dll and keep the best one of them
            int bestCircuit = 0;
            float bestCircuitPressureDrop = 0f;

            var kfGC = new GCCoil.Condensor();
            //KFRefplus.CoolingClass kfFC = new KFRefplus.CoolingClass();

            //for (int intGap = 0; intGap < fltGap.Length; intGap++)
            for (int intGap = 0; intGap < intPossibleCircuits.Length; intGap++)
            {
                kfGC.DES = "G";
                kfGC.CHO = _cho; //type R = rating S = Selection
                kfGC.CH = _ch; //Coil Height
                kfGC.CL = _cl; //Coil Lenght
                kfGC.FL = _fl; //R-22 R-502 R-134A R-410A R-407C R-404A R-507
                kfGC.CFM = _cfm; //CFM
                kfGC.DBE = _dbe; //Entering Dry Bulb
                
                kfGC.CIR = intPossibleCircuits[intGap]; //number of circuits
                kfGC.FPI = _fpi; //fins per inch
                kfGC.FM = _fm; // Fin Material
                kfGC.YF = _yf; //fins thickness
                kfGC.TM = _tm; //tube material
                kfGC.Row = _row; //number of rows
                kfGC.TT = _tt; //tube thickness
                kfGC.CTYP = _ctyp; //Coil Type
                kfGC.FFO = Ffo; //Fin Side Fouling 
                kfGC.ALTD = (_altd <= 500f ? 0f : _altd); //Altitude
                kfGC.CFMT = "A"; //air flow type
                kfGC.TTYP = "S"; //Tube Type
                kfGC.ODDF = _oddf; //Odd Rows Y = yes or N = no
                kfGC.GPSI = _gpsi;
                kfGC.GFLO = _gflo;
                kfGC.GIN = _gin;
                try
                {
                    kfGC.DESIGN(Public.CoilDllKey);

                    if (kfGC.DP1Z > bestCircuitPressureDrop)
                    {
                        bestCircuitPressureDrop = kfGC.DP1Z;
                        bestCircuit = intPossibleCircuits[intGap];
                    }
                }
                catch (Exception ex)
                {
                    Public.PushLog(ex.ToString(),"GasCooler ExecuteAutomaticCircuitingSelection");
                }


            }

            try
            {


                kfGC = new GCCoil.Condensor
                {
                    DES = "G",
                    CHO = _cho,
                    CH = _ch,
                    CL = _cl,
                    FL = _fl,
                    CFM = _cfm,
                    DBE = _dbe,
                    CIR = bestCircuit,
                    FPI = _fpi,
                    FM = _fm,
                    YF = _yf,
                    TM = _tm,
                    Row = _row,
                    TT = _tt,
                    CTYP = _ctyp,
                    FFO = Ffo,
                    ALTD = (_altd <= 500f ? 0f : _altd),
                    CFMT = "A",
                    TTYP = "S",
                    ODDF = _oddf,
                    GPSI = _gpsi,
                    GFLO = _gflo,
                    GIN = _gin
                };
                kfGC.DESIGN(Public.CoilDllKey);

                //set the return values
                dtQuickCoilInformations.Rows[0]["R_Rows"] = (decimal)kfGC.Row;
                dtQuickCoilInformations.Rows[0]["R_Circuiting"] = (decimal)kfGC.SERZ;
                dtQuickCoilInformations.Rows[0]["R_NumberOfCircuits"] = (decimal)kfGC.CIRZ;
                dtQuickCoilInformations.Rows[0]["R_FPI"] = (decimal)kfGC.FPIZ;
                dtQuickCoilInformations.Rows[0]["R_CoilFaceArea"] = (decimal)kfGC.FA;
                dtQuickCoilInformations.Rows[0]["R_FaceVelocity"] = (decimal)kfGC.AFAV;
                dtQuickCoilInformations.Rows[0]["R_AirPressureDrop"] = (decimal)kfGC.DPAJZ;
                dtQuickCoilInformations.Rows[0]["R_LeavingDryBulb"] = (decimal)kfGC.AT2Z;
                dtQuickCoilInformations.Rows[0]["R_SensibleHeat"] = (decimal)kfGC.SHAZ;
                dtQuickCoilInformations.Rows[0]["R_RefrigerantPressureDrop"] = (decimal)kfGC.DP1Z;
                dtQuickCoilInformations.Rows[0]["R_GOUT"] = (decimal)kfGC.GOUT;
                dtQuickCoilInformations.Rows[0]["R_TotalHeat"] = (decimal)kfGC.SHAZ;


                if (kfGC.SHAZ < 0 )
                {
                    errorMessage = "Invalid Parameter";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"GasCooler ExecuteAutomaticCircuitingSelection");
                errorMessage = ex.Message;
                //an error happen while selecting a coil, return false
                return false;
            }
        }
        private int[] GetPossibleCircuits(decimal decTotalNumberOfTubes)
        {
                var arList = new ArrayList();

                //loop to find all possible circuits
                for (int intCircuits = 350; intCircuits >= 2; intCircuits--)
                {
                    decimal decTubesPerCircuits = decTotalNumberOfTubes / intCircuits;


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

    }
}


