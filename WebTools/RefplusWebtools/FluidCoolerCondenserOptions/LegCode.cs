using System;
using System.Collections.Generic;
using System.Data;

namespace RefplusWebtools.FluidCoolerCondenserOptions
{
    class LegCode
    {
        private readonly DataTable _dtLegLogic;
        private string _legPriceTablename = "";
        private string _defaultLeg = "";
        private List<Leg> _legs = new List<Leg>();

        public LegCode(string coolerType, string receiverType, string orientation, string condenserTypeMotorCoilArr, int fanWide, int fanLong, decimal biggestReceiverDiameter)
        {
            _dtLegLogic = Public.SelectAndSortTable(Public.DSDatabase.Tables["LegLogic"], "CoolerType = '" + coolerType + "' AND Receiver = '" + receiverType + "' AND Orientation = '" + orientation + "' AND MotorCoilArr LIKE '%" + condenserTypeMotorCoilArr + "%' AND MinFanWide <= " + fanWide + " AND MaxFanWide >= " + fanWide + " AND MinReceiverDiameter < " + biggestReceiverDiameter + " AND MaxReceiverDiameter >= " + biggestReceiverDiameter, "");

            SetLegs(fanWide, fanLong, orientation);
        }

        public string GetDefaultLeg()
        {
            return _defaultLeg;
        }

        private void SetLegs(int fanWide, int fanLong, string orientation)
        {
            _legs = new List<Leg>();

            if (_dtLegLogic.Rows.Count > 0)
            {
                _legPriceTablename = "LegPrice" + _dtLegLogic.Rows[0]["Pricing"];
                _defaultLeg = _dtLegLogic.Rows[0]["DefaultLeg"].ToString();
                string[] validLegs = _dtLegLogic.Rows[0]["Legs"].ToString().Split(',');

                foreach (string s in validLegs)
                {
                    if (s.Length > 0)
                    {
                        DataTable dtLegDetail = Public.SelectAndSortTable(Public.DSDatabase.Tables[_legPriceTablename], "LegID = '" + s + "' AND FanWide = " + fanWide + " AND FanLong = " + fanLong, "");

                        if (dtLegDetail.Rows.Count > 0)
                        {
                            DataTable dtLegInfo = Public.SelectAndSortTable(Public.DSDatabase.Tables["Legs"], "LegID = '" + s + "'", "");

                            if (dtLegInfo.Rows.Count > 0)
                            {
                                _legs.Add(new Leg(s, dtLegInfo.Rows[0]["Description"].ToString(), Convert.ToDecimal(dtLegDetail.Rows[0]["Price"]), dtLegInfo.Rows[0]["Nomenclature" + orientation].ToString()));
                            }
                        }
                    }
                }
            }
        }

        public List<Leg> GetListOfLegs()
        {
            return _legs;
        }       
    }

    class Leg
    {
        private string _strLegID = "";
        private string _strDescription = "";
        private decimal _decPrice;
        private string _strNomenclature = "";
        private int _intLegSize;

        public Leg(string legID, string description, decimal price, string nomenclature)
        {
            FillValues(legID, description, price, nomenclature);
        }

        //copy constructor
        public Leg(Leg l)
        {
            FillValues(l._strLegID, l._strDescription, l._decPrice, l._strNomenclature);
        }

        private void FillValues(string legID, string description, decimal price, string nomenclature)
        {
            _strLegID = legID;
            _strDescription = description;
            _decPrice = price;
            _strNomenclature = nomenclature;
            SetLegSize();
        }

        public string LegID
        {
            get { return _strLegID ; }
            set { 
                _strLegID = value;
                SetLegSize();
            }
        }

        public string Description
        {
            get { return _strDescription; }
            set { _strDescription = value; }
        }

        public decimal Price
        {
            get { return _decPrice; }
            set { _decPrice = value; }
        }

        public string Nomenclature
        {
            get { return _strNomenclature; }
            set { _strNomenclature = value; }
        }

        public int LegSize
        {
            get { return _intLegSize; }
        }

        private void SetLegSize()
        {
            if (_strLegID == "NL")
            {
                _intLegSize = 0;
            }
            else
            {
                string strNumbers = "";

                for (int i = 0; i < _strLegID.Length; i++)
                {
                    int testInteger;
                    if (int.TryParse(_strLegID.Substring(i, 1), out testInteger))
                    {
                        strNumbers += _strLegID.Substring(i, 1);
                    }
                    else
                    {
                        break;
                    }
                }

                _intLegSize = Convert.ToInt32(strNumbers);
            }
        }

    }
}
