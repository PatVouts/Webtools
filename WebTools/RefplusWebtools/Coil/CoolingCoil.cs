using System;

namespace RefplusWebtools.Coil
{
    //Object class to call a dll.  Has a good amount of attributes to build the correct cooling coil, before calling the function to actually calculate performances.
    class CoolingCoil
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
        private string _finType = "";
        private string _finShape = "";

        public CoolingCoil()
        {
            ErrorMessage = "";
            SpecificHeat = 0f;
            Density = 0f;
            Viscosity = 0f;
            ConnectionSizeNumber = 0f;
            ThermalConductivity = 0f;
            CoilFaceArea = 0f;
            FaceVelocity = 0f;
            AirPressureDrop = 0f;
            LeavingDryBulb = 0f;
            LeavingWetBulb = 0f;
            SensibleHeat = 0f;
            TotalHeat = 0f;
            LeavingLiquidTemperature = 0f;
            WaterVelocity = 0f;
            IsValid = false;
            RefrigerantPressureDrop = 0f;
        }

        //parameters defintion.  These are juste standard gets and sets.
        public float EnteringWetBulb{get { return _wbe; }set { _wbe = value; }}
        public string ConnectionSize{get { return _connectionSize; }set { _connectionSize = value; }}
        public float DifferenceBetweenEnteringAndLeaving{get { return _dt; }set { _dt = value; }}
        public float GPM{get { return _gpm; }set { _gpm = value; }}
        public string Turbulator{get { return _turb; }set { _turb = value; }}
        public float EnteringLiquidTemperature{get { return _we; }set { _we = value; }}
        public float Concentration{get { return _cg; }set { _cg = value; }}
        public string Type{get { return _cho; }set { _cho = value; }}
        public float CoilHeight{get { return _ch; }set { _ch = value; }}
        public float CoilLength{get { return _cl; }set { _cl = value; }}
        public string RefrigerantType{get { return _fl; }set { _fl = value; }}
        public float CFM{get { return _cfm; }set { _cfm = value; }}
        public float EnteringDryBulb{get { return _dbe; }set { _dbe = value; }}
        public float NumberOfCircuits{get { return _cir; }set { _cir = value; }}
        public float FinsPerInch{get { return _fpi; }set { _fpi = value; }}
        public string FinMaterial{get { return _fm; }set { _fm = value; }}
        public float FinThickness{get { return _yf; }set { _yf = value; }}
        public string TubeMaterial { get { return _tm; } set { _tm = value; }}        
        public float TubeThickness{get { return _tt; }set { _tt = value; }}
        public float Altitude{get { return _altd; }set { _altd = value; }}
        public string ErrorMessage { get; set; }
        public float SpecificHeat { get; set; }
        public float Density { get; set; }
        public float Viscosity { get; set; }
        public float ThermalConductivity { get; set; }
        public float ConnectionSizeNumber { get; private set; }
        public float CoilFaceArea { get; private set; }
        public float FaceVelocity { get; private set; }
        public float AirPressureDrop { get; private set; }
        public float LeavingDryBulb { get; private set; }
        public float LeavingWetBulb { get; private set; }
        public float SensibleHeat { get; private set; }
        public float TotalHeat { get; private set; }
        public float LeavingLiquidTemperature { get; private set; }
        public float WaterVelocity { get; private set; }
        public float RefrigerantPressureDrop { get; private set; }
        public bool IsValid { get; private set; }

        //Special parameters.  Changes the set a BIT (not by much)
        public float NumberOfRows { get { return _row; } set { _row = value; _oddf = (_row % 2.0F > 0) ? "Y" : "N"; /*Odd Rows Y = yes or N = no*/} }
        public string FinType { get { return _finType; } set { _finType = value; _ctyp = _finType + _finShape; } }
        public string FinShape { get { return _finShape; } set { _finShape = value; _ctyp = _finType + _finShape; } }
        
        //Creates a chillWaterCoil object then runs the DLL on it
        public void RunPerformance()
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
                TURB = _turb,
                FFO = 0f,
                FFI = 0f,
                Conn = _connectionSize,
                ODDF = _oddf
            };

            if (_gpm > 0)
            {
                kfFC.GPM = _gpm; //GPM
            }
            else
            {
                kfFC.DT = _dt; //Difference between entering and leaving
            }

            try
            {
                kfFC.DESIGN(Public.CoilDllKey);
                NumberOfRows = kfFC.Row;
                NumberOfCircuits = kfFC.CIRZ;
                ConnectionSizeNumber = kfFC.conns;
                CoilFaceArea = kfFC.FA;
                FaceVelocity = kfFC.AFAV;
                AirPressureDrop = kfFC.DPAJZ;
                LeavingDryBulb = kfFC.AT2Z;
                LeavingWetBulb = kfFC.WBLAZ;
                SensibleHeat = kfFC.SHAZ;
                TotalHeat = kfFC.QAZ;
                LeavingLiquidTemperature = kfFC.AWLZ;
                _gpm = kfFC.GPMZ;
                WaterVelocity = kfFC.VWZ;
                RefrigerantPressureDrop = kfFC.DP1Z / 2.306666666666f;

                if (kfFC.SHAZ < 0 || kfFC.QAZ < 0)
                {
                    ErrorMessage = "Invalid Parameter";
                    IsValid = false;
                }
                else
                {
                    IsValid = true;
                }
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"CoolingCoil RunPerformance");
                ErrorMessage = ex.Message;
                //an error happen while selecting a coil, return false
                IsValid = false;
            }
        }
    }
}
