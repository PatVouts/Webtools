using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RefplusWebtools.Drawing
{
    class CondenserDrawing
    {
        private string strNomenclature = "";
        private string Motor = "";
        private string CoillArr = "";
        private int FanWide = 0;
        private int FanLong = 0;
        private int NumberOfCircuit = 0;
        private string AirFlow = "";
        private int LegSize = 0;
        private int NumberOfReceiver = 0;
        private bool FactoryInstalledReceivers = false;

        public CondenserDrawing(string _Motor, string _CoillArr, int _FanWide, int _FanLong, int _NumberOfCircuit, string _AirFlow, int _LegSize, int _NumberOfReceiver, bool _FactoryInstalledReceivers)
        {
            Motor = _Motor;
            CoillArr = _CoillArr;
            FanWide = _FanWide;
            FanLong = _FanLong;
            NumberOfCircuit = _NumberOfCircuit;
            AirFlow = _AirFlow;
            LegSize = _LegSize;
            NumberOfReceiver = _NumberOfReceiver;
            FactoryInstalledReceivers = _FactoryInstalledReceivers;
        }

        public string Nomenclature
        {
            get { return strNomenclature; }
        }

        private void BuildNomenclature()
        {
            strNomenclature = getCompany() + getUnitSizeType() + getUnitType() + "-" + getFanArrangement() + getCircuitQuantity() + "-" + getUnitCoilSetup() + "-" + getSpecialLegtType() + "-" + getReceiverList();
        }

        private string getReceiverList()
        {
            string strNomenclature = "";

            if (NumberOfReceiver >= 1 && FactoryInstalledReceivers)
            {
                strNomenclature = NumberOfReceiver.ToString();
            }
            else
            {
                strNomenclature = "N";
            }

            return strNomenclature;
        }

        private string getSpecialLegtType()
        {
            string strNomenclature = "";

            //no leg has special nomenclature otherwise it follow simple logic with airflow direction and size.
            if (LegSize == 0)
            {
                strNomenclature = "N00";
            }
            else if (AirFlow == "V")
            {
                strNomenclature = "L" + LegSize.ToString();
            }
            else if (AirFlow == "H")
            {
                strNomenclature = "H" + LegSize.ToString();
            }

            return strNomenclature;
        }

        private string getUnitCoilSetup()
        {
            string strNomenclature = "";

            //this is a complex logic for that part of the nomenclature.
            //First of if you have factory installed receiver you have a base.
            //if you have shipped loose receiver you dont have a base.
            //if you dont have receivers you dont have the base
            //NOTE : note that later on they will add a base option to the condenser itself
            //which will void this logic.
            //So base is prioritary to Air flow direction
            //so if base present it superseed all, otherwise use airflow nomenclature directly.

            if (NumberOfReceiver >= 1 && FactoryInstalledReceivers && AirFlow == "V")
            {
                strNomenclature = "D";
            }
            else if (NumberOfReceiver >= 1 && FactoryInstalledReceivers && AirFlow == "H")
            {
                strNomenclature = "D";
            }
            else if (NumberOfReceiver >= 1 && !FactoryInstalledReceivers && AirFlow == "V")
            {
                strNomenclature = "N";
            }
            else if (NumberOfReceiver >= 1 && !FactoryInstalledReceivers && AirFlow == "H")
            {
                strNomenclature = "H";
            }
            else if (NumberOfReceiver == 0 && AirFlow == "H")
            {
                strNomenclature = "N";
            }
            else if (NumberOfReceiver == 0 && AirFlow == "V")
            {
                strNomenclature = "H";
            }

            return strNomenclature;
        }

        private string getCircuitQuantity()
        {
            //1 circuit = 1, 2 circuit = 2
            return NumberOfCircuit.ToString();
        }

        private string getFanArrangement()
        {
            // 2 x 4 = 24, 1 x 7 = 17
            return FanWide.ToString() + FanLong.ToString();
        }

        private string getUnitType()
        {
            //C for Condenser
            return "C";
        }

        private string getUnitSizeType()
        {
            string strNomenclature = "";

            DataTable dtUnitSizeType = Query.Select("SELECT * FROM CondenserSerie WHERE Motor = '" + Motor + "' AND CoilArr = '" + CoillArr + "'");

            if (dtUnitSizeType.Rows.Count > 0)
            {
                strNomenclature = dtUnitSizeType.Rows[0]["UnitSizeTypeNomenclature"].ToString();
            }

            return strNomenclature;
        }

        private string getCompany()
        {
            string strNomenclature = "";

            if (UserInformation.CURRENT_SITE == "REFPLUS")
            {
                strNomenclature = "R";
            }
            else if (UserInformation.CURRENT_SITE == "DECTRON")
            {
                strNomenclature = "D";
            }
            else if (UserInformation.CURRENT_SITE == "ECOSAIRE")
            {
                strNomenclature = "E";
            }
            else if (UserInformation.CURRENT_SITE == "CIRCULAIRE")
            {
                strNomenclature = "D";
            }
       
            return strNomenclature;
        }
    }
}
