using System;
using System.Data;

namespace RefplusWebtools.QuickCoil
{
    class HeatReclaim
    {
        private string _cho = "R"; //type R = rating S = Selection
        private float _ch; //Coil Height
        private float _cl; //Coil Lenght
        private string _fl = ""; //R-22 R-502 R-134A R-410A R-407C R-404A R-507
        private float _cfm; //CFM
        private float _dbe; //Entering Dry Bulb
        private float _cond; //Condenser Condensing Temperature
        private float _suct; //Suction temperature
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
        private string _des = ""; //Coil Design
        private string _sb = ""; //SubCooler
        private float _scir; //Condenser Circuit
        private string _ft = ""; //face tubes
        private float _htr; //Heat Recovery
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

        public float CondenserCondensingTemperature
        {
            get { return _cond; }
            set { _cond = value; }
        }

        public float SuctionTemperature
        {
            get { return _suct; }
            set { _suct = value; }
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

        public string CoilDesign
        {
            get { return _des; }
            set { _des = value; }
        }

        public string SubCooler
        {
            get { return _sb; }
            set { _sb = value; }
        }

        public float CondenserCircuit
        {
            get { return _scir; }
            set { _scir = value; }
        }

        public string FaceTubes
        {
            get { return _ft; }
            set { _ft = value; }
        }
        
        public float HeatRecovery
        {
            get { return _htr; }
            set { _htr = value; }
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
            var kfHR = new CondenserCoil.CondenserCoil
            {
                CHO = _cho,
                CH = _ch,
                CL = _cl,
                CFM = _cfm,
                DBE = _dbe,
                COND = _cond,
                SUCT = _suct,
                FL = _fl,
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
                ODDF = _oddf,
                TTYP = _ttyp,
                DES = _des,
                SB = _sb
            };
            //KFRefplus.CondensorClass kfHR = new KFRefplus.CondensorClass();
            //2011-08-22 : #1146 due to cfm being miscalculated we need to use ACFM and < 500ft count as 0ft
            //kfHR.CFMT = _CFMT; //air flow type
            //kfHR.ALTD = _ALTD; //Altitude
            if (_sb == "Y" && _des != "H")
            {
                kfHR.SCIR = _scir; //Condenser Circuit
                kfHR.FT = Convert.ToDouble(_ft); //face tubes
            }
            if (_des == "H")
            {
                kfHR.HTR = _htr;//heat recovery
            }
            try
            {
                kfHR.DESIGN(Public.CoilDllKey);

                dtQuickCoilInformations.Rows[0]["R_Rows"] = (decimal)kfHR.Row;
                dtQuickCoilInformations.Rows[0]["R_NumberOfCircuits"] = (decimal)kfHR.CIRZ;
                dtQuickCoilInformations.Rows[0]["R_FPI"] = (decimal)kfHR.FPIZ;
                dtQuickCoilInformations.Rows[0]["R_CoilFaceArea"] = (decimal)kfHR.FA;
                dtQuickCoilInformations.Rows[0]["R_FaceVelocity"] = (decimal)kfHR.AFAV;
                dtQuickCoilInformations.Rows[0]["R_AirPressureDrop"] = (decimal)kfHR.DPAJZ;
                dtQuickCoilInformations.Rows[0]["R_LeavingDryBulb"] = (decimal)kfHR.AT2Z;
                dtQuickCoilInformations.Rows[0]["R_SensibleHeat"] = (decimal)kfHR.SHAZ;
                if (_des == "H")
                {
                    dtQuickCoilInformations.Rows[0]["R_TotalHeat"] = (decimal)kfHR.SHAZ / ((decimal)kfHR.HTR / 100m);
                }
                else
                {
                    dtQuickCoilInformations.Rows[0]["R_TotalHeat"] = dtQuickCoilInformations.Rows[0]["R_SensibleHeat"];
                }
                dtQuickCoilInformations.Rows[0]["R_RefrigerantPressureDrop"] = (decimal)kfHR.DP1Z;
                dtQuickCoilInformations.Rows[0]["R_SubCoolerCapacity"] = (decimal)kfHR.QS;
                dtQuickCoilInformations.Rows[0]["R_SubCoolerRefrigerantLeavingTemperature"] = (decimal)kfHR.REL;
                dtQuickCoilInformations.Rows[0]["R_SubCoolerPressureDrop"] = (decimal)kfHR.SDP;

                if (kfHR.SHAZ < 0)
                {
                    errorMessage = "Invalid Parameter";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"HeatReclaim ExecuteSelection");
                errorMessage = ex.Message;
                //an error happen while selecting a coil, return false
                return false;
            }
        }

    }
}
