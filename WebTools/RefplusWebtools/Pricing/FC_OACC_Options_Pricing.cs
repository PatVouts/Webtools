using System;
using System.Data;
using System.Globalization;

namespace RefplusWebtools.Pricing
{
    class FCOaccOptionsPricing
    {
        public decimal GetLegPrice(DataTable dtLegPrice,int intLegSize,int intInstalled, int intFanWide, int intFanLong,string strCoilArr)
        {
            decimal decPrice = Public.InvalidPrice;

            DataTable dtSelectPrice = Public.SelectAndSortTable(dtLegPrice, "FanWide = " + intFanWide + " AND FanLong = " + intFanLong + " AND CoilArr LIKE '%" + strCoilArr + "%' AND LegSize = " + intLegSize + " AND Installed = " + intInstalled, "");

            if (dtSelectPrice.Rows.Count > 0)
            {
                decPrice = Convert.ToDecimal(dtSelectPrice.Rows[0]["Price"]);
            }
           
            return decPrice;
        }

        public enum MaterialTypeToPrice { Fin, Tube };

        public decimal GetMaterialPrice(DataTable dtCoilFinMaterial, DataTable dtCoilCasingMaterial, DataTable dtCoilTubeMaterial, DataTable dtvCoilFinDefaults, DataTable dtvCoilTubeDefaults, MaterialTypeToPrice mt, string strFinType, int intFPI, decimal decRows, decimal decFinHeight, decimal decFinLength, string strFinMaterial, string strTubeMaterial, string strCasingMaterial, int intFinMaterialID, int intTubeMaterialID, bool isFluidCooler,bool isCondenser, string strCondenserType)
        {
            //Get Price of Standard Coil Without Anything
            var sc = new StandardCoil(
                strFinType,
                2m,
                decRows,
                intFPI,
                decFinHeight,
                decFinLength,
                0.5m,
                0.006m,
                "COPPER",
                0.016m,
                0.064m,
                Convert.ToDecimal(Public.SelectAndSortTable(dtCoilFinMaterial, "FinMaterial = 'ALUMINIUM'", "").Rows[0]["MaterialDensity"]),
                Convert.ToDecimal(Public.SelectAndSortTable(dtCoilFinMaterial, "FinMaterial = 'ALUMINIUM'", "").Rows[0]["PricePerLbs"]),
                Convert.ToDecimal(Public.SelectAndSortTable(dtCoilCasingMaterial, "CasingMaterial = '" + strCasingMaterial + "'", "").Rows[0]["MaterialDensity"]),
                Convert.ToDecimal(Public.SelectAndSortTable(dtCoilCasingMaterial, "CasingMaterial = '" + strCasingMaterial + "'", "").Rows[0]["PricePerLbs"]),
                Convert.ToDecimal(Public.SelectAndSortTable(dtCoilTubeMaterial, "TubeMaterial = 'COPPER'", "").Rows[0]["MaterialDensity"]),
                Convert.ToDecimal(Public.SelectAndSortTable(dtCoilTubeMaterial, "TubeMaterial = 'COPPER'", "").Rows[0]["PricePerLbs"]));
            decimal decStandardPrice = sc.Price;

            var qcc = new QuickCoil.QuickCoilCode();

            //2010-09-15 : More recent Email, Simon is telling me to use "C" all time
            //2010-09-15 : Just got the information that should fix the problem from Simon
            //Fin Pattern was wrong. For Fluid Cooler it's always "C"
            //Condenser if it's a Heat Reclaim it's "C" otherwise "G"

            const string strFinPattern = "C";

            //if (IsFluidCooler)
            //{
            //    strFinPattern = "C";
            //}
            //else if (IsCondenser && strCondenserType == "C")
            //{
            //    strFinPattern = "G";
            //}
            //else if (IsCondenser && strCondenserType == "C")
            //{
            //    strFinPattern = "C";
            //}

            string strNewFinMaterial = (mt == MaterialTypeToPrice.Fin ? strFinMaterial : "ALUMINIUM");
            decimal decNewFinThickness = (mt == MaterialTypeToPrice.Fin ? Convert.ToDecimal("0" + qcc.FinThicknessDefault(dtvCoilFinDefaults, strFinType, strFinPattern, intFPI, intFinMaterialID.ToString(CultureInfo.InvariantCulture))) : 0.006m);
            
            string strNewTubeMaterial = (mt == MaterialTypeToPrice.Tube ? strTubeMaterial : "COPPER");
            decimal decNewTubeThickness = (mt == MaterialTypeToPrice.Tube ? Convert.ToDecimal("0" + qcc.TubeThicknessDefault(dtvCoilTubeDefaults, "FH", strFinType, intTubeMaterialID.ToString(CultureInfo.InvariantCulture), false)) : 0.016m);


            //Get the price of the current coil by replacing only what needed
            sc = new StandardCoil(
                strFinType,
                2m,
                decRows,
                intFPI,
                decFinHeight,
                decFinLength,
                0.5m,
                decNewFinThickness,
                strNewTubeMaterial,
                decNewTubeThickness,
                0.064m,
                Convert.ToDecimal(Public.SelectAndSortTable(dtCoilFinMaterial, "FinMaterial = '" + strNewFinMaterial + "'", "").Rows[0]["MaterialDensity"]),
                Convert.ToDecimal(Public.SelectAndSortTable(dtCoilFinMaterial, "FinMaterial = '" + strNewFinMaterial + "'", "").Rows[0]["PricePerLbs"]),
                Convert.ToDecimal(Public.SelectAndSortTable(dtCoilCasingMaterial, "CasingMaterial = '" + strCasingMaterial + "'", "").Rows[0]["MaterialDensity"]),
                Convert.ToDecimal(Public.SelectAndSortTable(dtCoilCasingMaterial, "CasingMaterial = '" + strCasingMaterial + "'", "").Rows[0]["PricePerLbs"]),
                Convert.ToDecimal(Public.SelectAndSortTable(dtCoilTubeMaterial, "TubeMaterial = '" + strNewTubeMaterial + "'", "").Rows[0]["MaterialDensity"]),
                Convert.ToDecimal(Public.SelectAndSortTable(dtCoilTubeMaterial, "TubeMaterial = '" + strNewTubeMaterial + "'", "").Rows[0]["PricePerLbs"]));
            decimal decNewPrice = sc.Price;

            decimal decMaterialPrice = decNewPrice - decStandardPrice;

            if (decNewFinThickness == 0m || decNewTubeThickness == 0m)
            {
                decMaterialPrice = Public.InvalidPrice;
            }
            //return the difference
            return decMaterialPrice;

        }
    }
}
