using System;
using System.Data;

namespace RefplusWebtools.QuickCoil
{
    class Steam
    {
        private string _ctyp = ""; //Coil Type
        //used to set CoilType which is _fintype + _finshape
        private string _finType = "";
        private string _finShape = "";

        public Steam()
        {
            TubeMaterial = "";
            FinMaterial = "";
            Type = "R";
        }

        public string Type { get; set; }

        public float CoilHeight { get; set; }

        public float SteamPressure { get; set; }

        public float CoilLength { get; set; }

        public float CFM { get; set; }

        public float EnteringDryBulb { get; set; }

        public float FinsPerInch { get; set; }

        public string FinMaterial { get; set; }

        public float FinThickness { get; set; }

        public string TubeMaterial { get; set; }

        public float NumberOfRows { get; set; }

        public float TubeThickness { get; set; }

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

        public float Altitude { get; set; }

        public bool ExecuteSelection(DataTable dtQuickCoilInformations, ref string errorMessage)
        {
            var kfSteam = new SteamCoil.SteamCoil
            {
                CHO = Type,
                CH = CoilHeight,
                CL = CoilLength,
                STMP = SteamPressure,
                CFM = CFM,
                DBE = EnteringDryBulb,
                FPI = FinsPerInch,
                FM = FinMaterial,
                YF = FinThickness,
                TM = TubeMaterial,
                Row = NumberOfRows,
                TT = TubeThickness,
                CTYP = _ctyp,
                ALTD = (Altitude <= 500f ? 0f : Altitude),
                CFMT = "A",
                FFO = 0f
            };
            //KFRefplus.SteamClass kfSTEAM = new KFRefplus.SteamClass();

            //2011-08-22 : #1146 due to cfm being miscalculated we need to use ACFM and < 500ft count as 0ft
            //kfSTEAM.ALTD = _ALTD; //Altitude  
            //kfSTEAM.CFMT = _CFMT; //air flow type

            try
            {
                kfSteam.DESIGN(Public.CoilDllKey);

                dtQuickCoilInformations.Rows[0]["R_Rows"] = (decimal)kfSteam.Row;
                dtQuickCoilInformations.Rows[0]["R_FPI"] = (decimal)kfSteam.FPIZ;
                dtQuickCoilInformations.Rows[0]["R_CoilFaceArea"] = (decimal)kfSteam.FA;
                dtQuickCoilInformations.Rows[0]["R_FaceVelocity"] = (decimal)kfSteam.AFAV;
                dtQuickCoilInformations.Rows[0]["R_AirPressureDrop"] = (decimal)kfSteam.DPAJZ;
                dtQuickCoilInformations.Rows[0]["R_LeavingDryBulb"] = (decimal)kfSteam.AT2Z;
                dtQuickCoilInformations.Rows[0]["R_SensibleHeat"] = (decimal)kfSteam.SHAZ;
                dtQuickCoilInformations.Rows[0]["R_TotalHeat"] = (decimal)kfSteam.SHAZ;
                dtQuickCoilInformations.Rows[0]["R_SteamConsumption"] = (decimal)kfSteam.STMLDZ;
                dtQuickCoilInformations.Rows[0]["R_SteamTemperature"] = (decimal)kfSteam.TSS;


                if (kfSteam.SHAZ < 0)
                {
                    errorMessage = "Invalid Parameter";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"Steam ExecuteSelection");
                errorMessage = ex.Message;
                //an error happen while selecting a coil, return false
                return false;
            }
        }
    }
}
