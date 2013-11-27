using System;
using System.Data;

namespace RefplusWebtools.QuickCoil
{
    class DXDimensions
    {
        //private variable that will contain the value we are looking for
        private decimal _g;
        private decimal _j;
        private decimal _k;
        private decimal _q;
        private decimal _y;
        private decimal _z;
        private decimal _offset;
        private decimal _overall;

        //all the getter funcitons of the class
        public decimal G
        {
            get { return _g; }
        }

        public decimal J
        {
            get { return _j; }
        }

        public decimal K
        {
            get { return _k; }
        }

        public decimal Q
        {
            get { return _q; }
        }

        public decimal Y
        {
            get { return _y; }
        }

        public decimal Z
        {
            get { return _z; }
        }

        public decimal Offset
        {
            get { return _offset; }
        }

        public decimal OVERALL
        {
            get { return _overall; }
        }

        //here are the variables used in the formula in the excel sheet.
        //i Kept the same name since it's easier to understand.
        private readonly DataTable _dtCoilFrameSize = new DataTable();
        private readonly decimal _decFinHeight;
        private readonly decimal _decFinLength;
        private readonly decimal _decFaceTube;
        private readonly decimal _decTubeRow;
        private readonly string _strFinType = "";
        private readonly decimal _decNumberOfRows;
        private readonly decimal _decOutletConnection;

        private decimal _m7;
        private decimal _m6;
        private decimal _m3;
        private decimal _m5;
        private decimal _c31;
        private decimal _c32;
        private decimal _dG32;
        private decimal _m8;
        private decimal _p15;
        private decimal _p12;
        private decimal _m10;
        private decimal _m9;

        public DXDimensions(DataTable dtCoilFrameSize, decimal decFinHeight, decimal decFinLength, decimal decFaceTube, decimal decTubeRow, string strFinType, decimal decNumberOfRows, decimal decOutletConnection)
        {
            //assign passed parameter
            _dtCoilFrameSize = dtCoilFrameSize;
            _decFinHeight = decFinHeight;
            _decFinLength = decFinLength;
            _decFaceTube = decFaceTube;
            _decTubeRow = decTubeRow;
            _strFinType = strFinType;
            _decNumberOfRows = decNumberOfRows;
            _decOutletConnection = decOutletConnection;

            //set each letters
            Set_G();
            Set_J();
            Set_Q();
            Set_K();
            Set_Y();
            Set_Z();
            Set_OFFSET();
            Set_OVERALL();
        }

        private void Set_G()
        {
            _g = _decFinLength;
        }

        private void Set_J()
        {
            _j = _decFinHeight;
        }

        private void Set_K()
        {
            _dG32 = _decOutletConnection;

            _m8 = _m6 / _m3;

            _p12 = _dG32 - (_m6 - _m8);

            if (_p12 < 0.001m)
            {
                _p15 = 0m;
            }
            else if (_p12 < 0.501m)
            {
                _p15 = 0.5m;
            }
            else if (_p12 < 0.751m)
            {
                _p15 = 0.75m;
            }
            else if (_p12 < 1.001m)
            {
                _p15 = 1m;
            }
            else if (_p12 < 1.501m)
            {
                _p15 = 1.5m;
            }
            else if (_p12 < 2.001m)
            {
                _p15 = 2m;
            }
            else if (_p12 < 2.501m)
            {
                _p15 = 2.5m;
            }
            else
            {
                _p15 = 3m;
            }

            _c32 = _m6 - _m8 + _p15;

            _m5 = Convert.ToDecimal(_dtCoilFrameSize.Select("Row = " + _decNumberOfRows)[0]["FinType_" + _strFinType]);

            _c31 = _m5 - _q - _c32;

            _k = (_c31 < (_dG32 / 2m) ? _m5 + 2m : _m5);
        }

        private void Set_Q()
        {
            _m3 = _decNumberOfRows;

            _m6 = _decNumberOfRows * _decTubeRow;

            _m7 = _m6 / _m3 / 2m;

            _q = _m7;
        }

        private void Set_Y()
        {
            _m9 = _decFaceTube;

            _m10 = (_m3 == 1m ? _m9 * 3m / 4m : _m9 / 4m);

            _y = _m10 - 0.75m + 0.25m + (_dG32 / 2m);
        }

        private void Set_Z()
        {
            _z = _m6;
        }

        private void Set_OFFSET()
        {
            _offset = _p15;
        }

        private void Set_OVERALL()
        {
            _overall = 0m;
        }

    }

    class HRDimensions
    {
        //private variable that will contain the value we are looking for
        private decimal _g;
        private decimal _j;
        private decimal _k;
        private decimal _q;
        private decimal _r;
        private decimal _y;
        private const decimal X1 = 0m;
        private decimal _z;
        private decimal _offset;
        private decimal _overall;

        //all the getter funcitons of the class
        public decimal G
        {
            get { return _g; }
        }

        public decimal J
        {
            get { return _j; }
        }

        public decimal K
        {
            get { return _k; }
        }

        public decimal Q
        {
            get { return _q; }
        }

        public decimal R
        {
            get { return _r; }
        }

        public decimal Y
        {
            get { return _y; }
        }

        public decimal X
        {
            get { return X1; }
        }

        public decimal Z
        {
            get { return _z; }
        }

        public decimal OFFSET
        {
            get { return _offset; }
        }

        public decimal OVERALL
        {
            get { return _overall; }
        }

        //here are the variables used in the formula in the excel sheet.
        //i Kept the same name since it's easier to understand.
        private readonly DataTable _dtCoilFrameSize = new DataTable();
        private readonly decimal _decFinHeight;
        private readonly decimal _decFinLength;
        private readonly decimal _decFaceTube;
        private readonly decimal _decTubeRow;
        private readonly string _strFinType = "";
        private readonly decimal _decNumberOfRows;
        private readonly decimal _decInletConnection;

        private decimal _m7;
        private decimal _m6;
        private decimal _m3;
        private decimal _m5;
        private decimal _dG32;
        private decimal _m8;
        private decimal _p15;
        private decimal _p12;
        private decimal _m10;
        private decimal _m9;
        private decimal _e27;
        private decimal _n10;

        public HRDimensions(DataTable dtCoilFrameSize, decimal decFinHeight, decimal decFinLength, decimal decFaceTube, decimal decTubeRow, string strFinType, decimal decNumberOfRows, decimal decInletConnection)
        {
            //assign passed parameter
            _dtCoilFrameSize = dtCoilFrameSize;
            _decFinHeight = decFinHeight;
            _decFinLength = decFinLength;
            _decFaceTube = decFaceTube;
            _decTubeRow = decTubeRow;
            _strFinType = strFinType;
            _decNumberOfRows = decNumberOfRows;
            _decInletConnection = decInletConnection;

            //set each letters
            Set_G();
            Set_J();
            Set_Q();
            Set_R();
            Set_K();
            Set_Y();
            Set_X();
            Set_Z();
            Set_OFFSET();
            Set_OVERALL();
        }

        private void Set_G()
        {
            _g = _decFinLength;
        }

        private void Set_J()
        {
            _j = _decFinHeight;
        }

        private void Set_K()
        {

            _m5 = Convert.ToDecimal(_dtCoilFrameSize.Select("Row = " + _decNumberOfRows)[0]["FinType_" + _strFinType]); 
            _e27 = _m5 - _q - _r;

            

            _k = (_e27 < (_dG32 / 2m) ? _m5 + 2m : _m5);
        }

        private void Set_Q()
        {
            _m3 = _decNumberOfRows;

            _m6 = _decNumberOfRows * _decTubeRow;

            _m7 = _m6 / _m3 / 2m;

            _q = _m7;
        }

        private void Set_R()
        {
            _dG32 = _decInletConnection;

            _m8 = _m6 / _m3;

            _p12 = _dG32 - (_m6 - _m8);

            if (_p12 < 0.001m)
            {
                _p15 = 0m;
            }
            else if (_p12 < 0.501m)
            {
                _p15 = 0.5m;
            }
            else if (_p12 < 0.751m)
            {
                _p15 = 0.75m;
            }
            else if (_p12 < 1.001m)
            {
                _p15 = 1m;
            }
            else if (_p12 < 1.501m)
            {
                _p15 = 1.5m;
            }
            else if (_p12 < 2.001m)
            {
                _p15 = 2m;
            }
            else if (_p12 < 2.501m)
            {
                _p15 = 2.5m;
            }
            else
            {
                _p15 = 3m;
            }            

            _r = _m6 - _m8 + _p15;
        }

        private void Set_Y()
        {
            _m9 = _decFaceTube;

            _m10 = (_m3 == 1m ? _m9 * 3m / 4m : _m9 / 4m);

            _y = _m10 - 0.75m + 0.25m + (_dG32 / 2m);
        }

        private void Set_X()
        {
            _n10 = _m9 / 4m;

            _y = _n10 - 0.75m + 0.25m + (_dG32 / 2m);
        }

        private void Set_Z()
        {
            _z = _m6;
        }

        private void Set_OFFSET()
        {
            _offset = _p15;
        }

        private void Set_OVERALL()
        {
            _overall = 0m;
        }

    }

    class FCFHDimensions
    {
        //private variable that will contain the value we are looking for
        private decimal _f;
        private decimal _g;
        private decimal _j;
        private decimal _k;
        private decimal _q;
        private decimal _r;
        private decimal _y;
        private decimal _x;
        private decimal _z;
        private const decimal MPT1 = 0m;
        private decimal _offset;
        private decimal _overall;
        private decimal _overalla;
        private decimal _overallb;

        //all the getter funcitons of the class
        public decimal F
        {
            get { return _f; }
        }

        public decimal G
        {
            get { return _g; }
        }

        public decimal J
        {
            get { return _j; }
        }

        public decimal K
        {
            get { return _k; }
        }

        public decimal Q
        {
            get { return _q; }
        }

        public decimal R
        {
            get { return _r; }
        }

        public decimal Y
        {
            get { return _y; }
        }

        public decimal X
        {
            get { return _x; }
        }

        public decimal Z
        {
            get { return _z; }
        }

        public decimal MPT
        {
            get { return MPT1; }
        }

        public decimal OFFSET
        {
            get { return _offset; }
        }

        public decimal OVERALL
        {
            get { return _overall; }
        }

        public decimal OVERALLA
        {
            get { return _overalla; }
        }

        public decimal OVERALLB
        {
            get { return _overallb; }
        }

        //here are the variables used in the formula in the excel sheet.
        //i Kept the same name since it's easier to understand.
        private readonly DataTable _dtCoilFrameSize = new DataTable();
        private readonly DataTable _dtConnectionSizeFluidHeatingFluidCooling = new DataTable();
        private readonly decimal _decFinHeight;
        private readonly decimal _decFinLength;
        private readonly decimal _decFaceTube;
        private readonly decimal _decTubeRow;
        private readonly string _strFinType = "";
        private readonly decimal _decNumberOfRows;
        private readonly decimal _decInletConnection;

        private decimal _m7;
        private decimal _m6;
        private decimal _m3;
        private decimal _m5;
        private decimal _dG32;
        private decimal _m8;
        private decimal _p15;
        private decimal _p12;
        private decimal _m10;
        private decimal _m9;
        private decimal _e27;
        private decimal _n10;
        private readonly DesignType _coilDesignType = DesignType.Standard;

        public FCFHDimensions(DataTable dtCoilFrameSize, DataTable dtConnectionSizeFluidHeatingFluidCooling, decimal decFinHeight, decimal decFinLength, decimal decFaceTube, decimal decTubeRow, string strFinType, decimal decNumberOfRows, decimal decInletConnection,DesignType coilDesignType)
        {
            //assign passed parameter
            _dtCoilFrameSize = dtCoilFrameSize;
            _dtConnectionSizeFluidHeatingFluidCooling = dtConnectionSizeFluidHeatingFluidCooling;
            _decFinHeight = decFinHeight;
            _decFinLength = decFinLength;
            _decFaceTube = decFaceTube;
            _decTubeRow = decTubeRow;
            _strFinType = strFinType;
            _decNumberOfRows = decNumberOfRows;
            _decInletConnection = decInletConnection;
            _coilDesignType = coilDesignType;

            //set each letters
            Set_G();
            Set_J();
            Set_Q();
            Set_R();
            Set_K();
            Set_Y();
            Set_X();
            Set_Z();
            Set_F();
            Set_OFFSET();
            Set_OVERALL();
            Set_OVERALLA();
            Set_OVERALLB();
        }

        private void Set_F()
        {
            if (_coilDesignType == DesignType.Booster)
            {
                if (_decNumberOfRows <= 2m)
                {
                    _f = (4m - _z) / 2m;
                }
                else
                {
                    _f = (6m - _z) / 2m;
                }
            }
        }

        private void Set_G()
        {
            _g = _decFinLength;
        }

        private void Set_J()
        {
            _j = _decFinHeight;
        }

        private void Set_K()
        {
            _m5 = Convert.ToDecimal(_dtCoilFrameSize.Select("Row = " + _decNumberOfRows)[0]["FinType_" + _strFinType]);

            _e27 = _m5 - _q - _r;

            _k = (_e27 < (_dG32 / 2m) ? _m5 + 2m : _m5);
        }

        private void Set_Q()
        {
            _m3 = _decNumberOfRows;

            _m6 = _decNumberOfRows * _decTubeRow;

            _m7 = _m6 / _m3 / 2m;

            _q = _m7;
        }

        private void Set_R()
        {
            _dG32 = (_decInletConnection == 99m ? 0m : Convert.ToDecimal(_dtConnectionSizeFluidHeatingFluidCooling.Select("Value = " + _decInletConnection)[0]["HeaderValue"]));

            _m8 = _m6 / _m3;

            _p12 = _dG32 - (_m6 - _m8);

            if (_p12 < 0.001m)
            {
                _p15 = 0m;
            }
            else if (_p12 < 0.501m)
            {
                _p15 = 0.5m;
            }
            else if (_p12 < 0.751m)
            {
                _p15 = 0.75m;
            }
            else if (_p12 < 1.001m)
            {
                _p15 = 1m;
            }
            else if (_p12 < 1.501m)
            {
                _p15 = 1.5m;
            }
            else if (_p12 < 2.001m)
            {
                _p15 = 2m;
            }
            else if (_p12 < 2.501m)
            {
                _p15 = 2.5m;
            }
            else
            {
                _p15 = 3m;
            }

            _r = _m6 - _m8 + _p15;
        }

        private void Set_Y()
        {
            _m9 = _decFaceTube;

            _m10 = (_m3 == 1m ? _m9 * 3m / 4m : _m9 / 4m);

            _y = _m10 - 0.75m + 0.25m + (_dG32 / 2m);
        }

        private void Set_X()
        {
            _n10 = _m9 / 4m;

            _x = _n10 - 0.75m + 0.25m + (_dG32 / 2m);
        }

        private void Set_Z()
        {
            _z = _m6;
        }


        private void Set_OFFSET()
        {
            _offset = _p15;
        }

        private void Set_OVERALL()
        {
            if (_coilDesignType == DesignType.Booster)
            {
                if (_decNumberOfRows == 1m)
                {
                    _overall = _g + 2.0625m + 4m;
                }
                else if (_decNumberOfRows == 3m)
                {
                    _overall = _g + 2.84375m + 4m;
                }
                else if (_decNumberOfRows == 4m)
                {
                    _overall = _g + 2.84375m + 4m;
                }
            }
        }

        private void Set_OVERALLA()
        {
            if (_coilDesignType == DesignType.Booster)
            {
                if (_decNumberOfRows == 2m)
                {
                    _overalla = _g + 2.0625m + 4m;
                }
            }
        }

        private void Set_OVERALLB()
        {
            if (_coilDesignType == DesignType.Booster)
            {
                if (_decNumberOfRows == 2m)
                {
                    _overallb = _g + 2.84375m + 4m;
                }
            }
        }

    }

    class STEAMDimensions
    {
        //private variable that will contain the value we are looking for
        private decimal _g;
        private decimal _j;
        private decimal _k;
        private decimal _a;
        private decimal _b;
        private decimal _f;
        private decimal _z;
        private decimal _overall;

        //all the getter funcitons of the class
        public decimal G
        {
            get { return _g; }
        }

        public decimal J
        {
            get { return _j; }
        }

        public decimal K
        {
            get { return _k; }
        }

        public decimal A
        {
            get { return _a; }
        }

        public decimal B
        {
            get { return _b; }
        }

        public decimal F
        {
            get { return _f; }
        }

        public decimal Z
        {
            get { return _z; }
        }

        public decimal OVERALL
        {
            get { return _overall; }
        }

        //here are the variables used in the formula in the excel sheet.
        //i Kept the same name since it's easier to understand.
        private readonly DataTable _dtCoilFrameSize = new DataTable();
        private readonly decimal _decFinHeight;
        private readonly decimal _decFinLength;
        private readonly string _strFinType = "";
        private readonly decimal _decNumberOfRows;
        private readonly decimal _decOutletConnection;

        private const decimal M6 = 0m;
        private decimal _m5;
        private decimal _dG32;
        private decimal _c27;

        public STEAMDimensions(DataTable dtCoilFrameSize, decimal decFinHeight, decimal decFinLength, string strFinType, decimal decNumberOfRows, decimal decOutletConnection)
        {
            //assign passed parameter
            _dtCoilFrameSize = dtCoilFrameSize;
            _decFinHeight = decFinHeight;
            _decFinLength = decFinLength;
            _strFinType = strFinType;
            _decNumberOfRows = decNumberOfRows;
            _decOutletConnection = decOutletConnection;

            //set each letters
            Set_G();
            Set_J();
            Set_A();
            Set_B();
            Set_K();
            Set_Z();
            Set_F();
            Set_OVERALL();
        }

        private void Set_G()
        {
            _g = _decFinLength;
        }

        private void Set_J()
        {
            _j = _decFinHeight;
        }

        private void Set_K()
        {
            _dG32 = _decOutletConnection;

            _m5 = Convert.ToDecimal(_dtCoilFrameSize.Select("Row = " + _decNumberOfRows)[0]["FinType_" + _strFinType]);

            _c27 = _m5 - _a - _b;

            _k = (_c27 < (_dG32 / 2m) ? _m5 + 2m : _m5);
        }

        private void Set_A()
        {
            _a = 1m;
        }

        private void Set_B()
        {
            _b = 2m;
        }

        private void Set_F()
        {
            _f = _k - _z;
        }

        private void Set_Z()
        {
            _z = M6;
        }

        private void Set_OVERALL()
        {
            _overall = 0m;
        }

    }
    class GasDimensions
    {
        //private variable that will contain the value we are looking for
        private decimal _g;
        private decimal _j;
        private decimal _k;
        private decimal _a;
        private decimal _b;
        private decimal _f;
        private decimal _z;
        private decimal _overall;

        //all the getter funcitons of the class
        public decimal G
        {
            get { return _g; }
        }

        public decimal J
        {
            get { return _j; }
        }

        public decimal K
        {
            get { return _k; }
        }

        public decimal A
        {
            get { return _a; }
        }

        public decimal B
        {
            get { return _b; }
        }

        public decimal F
        {
            get { return _f; }
        }

        public decimal Z
        {
            get { return _z; }
        }

        public decimal OVERALL
        {
            get { return _overall; }
        }

        //here are the variables used in the formula in the excel sheet.
        //i Kept the same name since it's easier to understand.
        private readonly DataTable _dtCoilFrameSize = new DataTable();
        private readonly decimal _decFinHeight;
        private readonly decimal _decFinLength;
        private readonly string _strFinType = "";
        private readonly decimal _decNumberOfRows;

        private const decimal M6 = 0m;
        private decimal _m5;
        private decimal _dG32;
        private decimal _c27;

        public GasDimensions(DataTable dtCoilFrameSize, decimal decFinHeight, decimal decFinLength, string strFinType, decimal decNumberOfRows)
        {
            //assign passed parameter
            _dtCoilFrameSize = dtCoilFrameSize;
            _decFinHeight = decFinHeight;
            _decFinLength = decFinLength;
            _strFinType = strFinType;
            _decNumberOfRows = decNumberOfRows;

            //set each letters
            Set_G();
            Set_J();
            Set_A();
            Set_B();
            Set_K();
            Set_Z();
            Set_F();
            Set_OVERALL();
        }

        private void Set_G()
        {
            _g = _decFinLength;
        }

        private void Set_J()
        {
            _j = _decFinHeight;
        }

        private void Set_K()
        {
            _dG32 = 0m;

            _m5 = Convert.ToDecimal(_dtCoilFrameSize.Select("Row = " + _decNumberOfRows)[0]["FinType_" + _strFinType]);

            _c27 = _m5 - _a - _b;

            _k = (_c27 < (_dG32 / 2m) ? _m5 + 2m : _m5);
        }

        private void Set_A()
        {
            _a = 1m;
        }

        private void Set_B()
        {
            _b = 2m;
        }

        private void Set_F()
        {
            _f = _k - _z;
        }

        private void Set_Z()
        {
            _z = M6;
        }

        private void Set_OVERALL()
        {
            _overall = 0m;
        }

    }
}
