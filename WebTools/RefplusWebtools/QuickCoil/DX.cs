using System;
using System.Data;

namespace RefplusWebtools.QuickCoil
{
    class DXcoil
    {
        private string _cho = "R"; //type R = rating S = Selection
        private float _ch; //Coil Height
        private float _cl; //Coil Lenght
        private string _fl = ""; //R-22 R-502 R-134A R-410A R-407C R-404A R-507
        private float _cfm; //CFM
        private float _dbe; //Entering Dry Bulb
        private float _wbe; //Entering Wet Bulb
        private float _suct; //Suction temperature
        private float _liqt; //Liquid Temperature
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
       // private string _CFMT = "S"; //air flow type
        private string _ttyp = ""; //Tube Type
        private string _oddf = ""; //Odd Rows Y = yes or N = no
        //used to set CoilType which is _fintype + _finshape
        private string _finType = "";
        private string _finShape = "";

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

        public float EnteringWetBulb
        {
            get { return _wbe; }
            set { _wbe = value; }
        }

        public float SuctionTemperature
        {
            get { return _suct; }
            set { _suct = value; }
        }

        public float LiquidTemperature
        {
            get { return _liqt; }
            set { _liqt = value; }
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

        public string TubeType
        {
            get { return _ttyp; }
            set { _ttyp = value; }
        }

        public bool ExecuteSelection(DataTable dtQuickCoilInformations, ref string errorMessage)
        {
            var kfDX = new DXCoil.DXCoil
            {
                CHO = _cho,
                CH = _ch,
                CL = _cl,
                FL = _fl,
                CFM = _cfm,
                DBE = _dbe,
                WBE = _wbe,
                SUCT = _suct,
                LIQT = _liqt,
                CIR = _cir,
                FPI = _fpi,
                FM = _fm,
                YF = _yf,
                TM = _tm,
                Row = _row,
                TT = _tt,
                CTYP = (_ctyp=="KC"?"K":_ctyp),
                FFO = Ffo,
                ALTD = (_altd <= 500f ? 0f : _altd),
                CFMT = "A",
                TTYP = _ttyp,
                ODDF = _oddf
            };

            try
            {
                kfDX.DESIGN(Public.CoilDllKey);

                //set the return values
                dtQuickCoilInformations.Rows[0]["R_Rows"] = (decimal)kfDX.Row;
                dtQuickCoilInformations.Rows[0]["R_Circuiting"] = (decimal)kfDX.SERZ;
                dtQuickCoilInformations.Rows[0]["R_NumberOfCircuits"] = (decimal)kfDX.CIRZ;
                dtQuickCoilInformations.Rows[0]["R_FPI"] = (decimal)kfDX.FPIZ;
                dtQuickCoilInformations.Rows[0]["R_CoilFaceArea"] = (decimal)kfDX.FA;
                dtQuickCoilInformations.Rows[0]["R_FaceVelocity"] = (decimal)kfDX.AFAV;
                dtQuickCoilInformations.Rows[0]["R_AirPressureDrop"] = (decimal)kfDX.DPAJZ;
                dtQuickCoilInformations.Rows[0]["R_LeavingDryBulb"] = (decimal)kfDX.AT2Z;
                dtQuickCoilInformations.Rows[0]["R_LeavingWetBulb"] = (decimal)kfDX.WBLAZ;
                dtQuickCoilInformations.Rows[0]["R_TotalHeat"] = (decimal)kfDX.QAZ;
                dtQuickCoilInformations.Rows[0]["R_SensibleHeat"] = (decimal)kfDX.SHAZ;
                dtQuickCoilInformations.Rows[0]["R_LeavingLiquidTemperature"] = (decimal)kfDX.AWLZ;
                dtQuickCoilInformations.Rows[0]["R_CircuitLoad"] = (decimal)kfDX.REFLTZ;
                dtQuickCoilInformations.Rows[0]["R_RefrigerantPressureDrop"] = (decimal)kfDX.DP1Z;
                dtQuickCoilInformations.Rows[0]["R_RefrigerantPressureDropPerDegree"] = (decimal)kfDX.PERCZ;


                if (kfDX.SHAZ < 0 || kfDX.QAZ < 0)
                {
                    errorMessage = "Invalid Parameter";
                    return false;
                }
                return true;
            }
            catch(Exception ex)
            {
                Public.PushLog(ex.ToString(),"DX ExecuteSelection");
               errorMessage = ex.Message;
                //an error happen while selecting a coil, return false
                return false;
            }
        }

    }
    class Type
    {
        public const string SELECTION = "S";
        public const string RATING = "R"; 
    }
    class RefrigerantType
    {
        public const string R22 = "R-22";
        public const string R502 = "R-502";
        public const string R134A = "R-134A";
        public const string R410A = "R-410A";
        public const string R407C = "R-407C";
        public const string R404A = "R-404A";
        public const string R507 = "R-507";
    }

    class FinMaterial
    {
        public const string Aluminium = "AL";
        public const string Copper = "CU";
        public const string StainlessSteel = "SS";
    }

    class TubeMaterial
    {
        public const string Copper = "CU";
        public const string CopperNickel = "CU/NI";
        public const string StainlessSteel = "SS";
    }

    class FinType
    {
        public const string C = "C";
        public const string D = "D";
        public const string E = "E";
        public const string F = "F";
        public const string G = "G";
        public const string H = "H";
    }

    class FinShape
    {
        public const string C = "C";
        public const string F = "F";
        public const string S = "S";
    }

    class TubeType
    {
        public const string Smooth = "S";
        public const string Riffle = "R";
    }
}
