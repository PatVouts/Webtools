using System;

namespace RefplusWebtools
{
    public class Compressor
    {
        private readonly decimal _decCapacity1;
        private readonly decimal _decCapacity2;
        private readonly decimal _decCapacity3;
        private readonly decimal _decCapacity4;
        private readonly decimal _decCapacity5;
        private readonly decimal _decCapacity6;
        private readonly decimal _decCapacity7;
        private readonly decimal _decCapacity8;
        private readonly decimal _decCapacity9;
        private readonly decimal _decCapacity10;
        private readonly decimal _decPower1;
        private readonly decimal _decPower2;
        private readonly decimal _decPower3;
        private readonly decimal _decPower4;
        private readonly decimal _decPower5;
        private readonly decimal _decPower6;
        private readonly decimal _decPower7;
        private readonly decimal _decPower8;
        private readonly decimal _decPower9;
        private readonly decimal _decPower10;

        public Compressor(string strModel, decimal decCapacity1, decimal decCapacity2, decimal decCapacity3, decimal decCapacity4, decimal decCapacity5, decimal decCapacity6, decimal decCapacity7, decimal decCapacity8, decimal decCapacity9, decimal decCapacity10, decimal decPower1, decimal decPower2, decimal decPower3, decimal decPower4, decimal decPower5, decimal decPower6, decimal decPower7, decimal decPower8, decimal decPower9, decimal decPower10, decimal decRla, string strLra)
        {
            Model = strModel;
            _decCapacity1 = decCapacity1;
            _decCapacity2 = decCapacity2;
            _decCapacity3 = decCapacity3;
            _decCapacity4 = decCapacity4;
            _decCapacity5 = decCapacity5;
            _decCapacity6 = decCapacity6;
            _decCapacity7 = decCapacity7;
            _decCapacity8 = decCapacity8;
            _decCapacity9 = decCapacity9;
            _decCapacity10 = decCapacity10;
            _decPower1 = decPower1;
            _decPower2 = decPower2;
            _decPower3 = decPower3;
            _decPower4 = decPower4;
            _decPower5 = decPower5;
            _decPower6 = decPower6;
            _decPower7 = decPower7;
            _decPower8 = decPower8;
            _decPower9 = decPower9;
            _decPower10 = decPower10;
            Rla = decRla;
            Lra = strLra;
        }

        public string Model { get; private set; }

        public decimal BTUH(decimal decSaturatedSuctionTemperature, decimal decCondensingTemperature)
        {
            return THR_MBH(decSaturatedSuctionTemperature, decCondensingTemperature) * 1000m;
        }

        public decimal EVAP_MBH(decimal decSaturatedSuctionTemperature, decimal decCondensingTemperature)
        {
            return PolynomialFormula(_decCapacity1, _decCapacity2, _decCapacity3, _decCapacity4, _decCapacity5, _decCapacity6, _decCapacity7, _decCapacity8, _decCapacity9, _decCapacity10, decSaturatedSuctionTemperature, decCondensingTemperature) / 1000m;
        }

        public decimal THR_MBH(decimal decSaturatedSuctionTemperature, decimal decCondensingTemperature)
        {
            return EVAP_MBH(decSaturatedSuctionTemperature, decCondensingTemperature) + (KW(decSaturatedSuctionTemperature, decCondensingTemperature) * 3.413m);
        }

        public decimal KW(decimal decSaturatedSuctionTemperature, decimal decCondensingTemperature)
        {
            return PolynomialFormula(_decPower1, _decPower2, _decPower3, _decPower4, _decPower5, _decPower6, _decPower7, _decPower8, _decPower9, _decPower10, decSaturatedSuctionTemperature, decCondensingTemperature) / 1000m;
        }

        public decimal SubCoolingCapacityAdjustment(decimal decSaturatedSuctionTemperature, decimal decCondensingTemperature, decimal decSubCoolingTemperature)
        {
            return 0.005m * decSubCoolingTemperature * (EVAP_MBH(decSaturatedSuctionTemperature, decCondensingTemperature) * 1000m);
        }

        public string Lra { get; private set; }

        public decimal Rla { get; private set; }

        public decimal GetCapacity1 { get { return _decCapacity1; } }
        public decimal GetCapacity2 { get { return _decCapacity2; } }
        public decimal GetCapacity3 { get { return _decCapacity3; } }
        public decimal GetCapacity4 { get { return _decCapacity4; } }
        public decimal GetCapacity5 { get { return _decCapacity5; } }
        public decimal GetCapacity6 { get { return _decCapacity6; } }
        public decimal GetCapacity7 { get { return _decCapacity7; } }
        public decimal GetCapacity8 { get { return _decCapacity8; } }
        public decimal GetCapacity9 { get { return _decCapacity9; } }
        public decimal GetCapacity10 { get { return _decCapacity10; } }
        public decimal GetPower1 { get { return _decPower1; } }
        public decimal GetPower2 { get { return _decPower2; } }
        public decimal GetPower3 { get { return _decPower3; } }
        public decimal GetPower4 { get { return _decPower4; } }
        public decimal GetPower5 { get { return _decPower5; } }
        public decimal GetPower6 { get { return _decPower6; } }
        public decimal GetPower7 { get { return _decPower7; } }
        public decimal GetPower8 { get { return _decPower8; } }
        public decimal GetPower9 { get { return _decPower9; } }
        public decimal GetPower10 { get { return _decPower10; } }

        private decimal PolynomialFormula(decimal decPoly1, decimal decPoly2, decimal decPoly3, decimal decPoly4, decimal decPoly5, decimal decPoly6, decimal decPoly7, decimal decPoly8, decimal decPoly9, decimal decPoly10, decimal decSaturatedSuctionTemperature, decimal decCondensingTemperature)
        {
            return decPoly1 +
                    decPoly2 * decSaturatedSuctionTemperature +
                    decPoly3 * decCondensingTemperature +
                    decPoly4 * Convert.ToDecimal(Math.Pow((double)decSaturatedSuctionTemperature, 2d)) +
                    decPoly5 * decSaturatedSuctionTemperature * decCondensingTemperature +
                    decPoly6 * Convert.ToDecimal(Math.Pow((double)decCondensingTemperature, 2d)) +
                    decPoly7 * Convert.ToDecimal(Math.Pow((double)decSaturatedSuctionTemperature, 3d)) +
                    decPoly8 * Convert.ToDecimal(Math.Pow((double)decSaturatedSuctionTemperature, 2d)) * decCondensingTemperature +
                    decPoly9 * decSaturatedSuctionTemperature * Convert.ToDecimal(Math.Pow((double)decCondensingTemperature, 2d)) +
                    decPoly10 * Convert.ToDecimal(Math.Pow((double)decCondensingTemperature, 3d));
            //y = c1 + c2*to + c3*tc + c4*to^2 + c5*to*tc + c6*tc^2 + c7*to^3 + c8*tc*to^2 + c9*to*tc^2 + c10*tc^3
        }
    }
}
