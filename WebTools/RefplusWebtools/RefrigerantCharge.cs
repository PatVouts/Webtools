using System;
using System.Data;

namespace RefplusWebtools
{
    class RefrigerantCharge
    {
        private readonly string[] _strTableList = { "RefrigerantCharge" };
        public enum ChargeType { Liquid, Vapor };

        public RefrigerantCharge()
        {
            Query.LoadTables(_strTableList);
        }

// ReSharper disable RedundantAssignment
        public void SetCharges(ref decimal summerCharge, ref decimal winterCharge, decimal volumeInFt3, int refrigerantID, decimal summerTemperature, decimal summerLiquidPercentage, decimal summerVaporPercentage, decimal winterTemperature, decimal winterLiquidPercentage, decimal winterVaporPercentage)
// ReSharper restore RedundantAssignment
        {
            summerCharge = GetPoundsPerSquareFootAtSpecificVolume(volumeInFt3, refrigerantID, ChargeType.Liquid, summerTemperature, summerLiquidPercentage) + GetPoundsPerSquareFootAtSpecificVolume(volumeInFt3, refrigerantID, ChargeType.Vapor, summerTemperature, summerVaporPercentage);
            winterCharge = GetPoundsPerSquareFootAtSpecificVolume(volumeInFt3, refrigerantID, ChargeType.Liquid, winterTemperature, winterLiquidPercentage) + GetPoundsPerSquareFootAtSpecificVolume(volumeInFt3, refrigerantID, ChargeType.Vapor, winterTemperature, winterVaporPercentage);
        }
        private decimal GetPoundsPerSquareFootAtSpecificVolume(decimal volumeInFt3, int refrigerantID, ChargeType ct, decimal temperature, decimal percentage)
        {
            return volumeInFt3 * GetPoundsPerSquareFoot(refrigerantID, ct, temperature, percentage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refrigerantID">Refrigerant ID</param>
        /// <param name="ct">Liquid or Vapor</param>
        /// <param name="temperature">Temperature at which the Liquid or Vapor work</param>
        /// <param name="percentage">Percentage as decimal i.e : 0.3 = 30%</param>
        /// <returns></returns>
        private decimal GetPoundsPerSquareFoot(int refrigerantID, ChargeType ct, decimal temperature, decimal percentage)
        {
            decimal decResult = 0m;

            //2010-11-03 : Sylvain told me that even if it's for vapor the temperature always base on liquid
            //the vapor temp only tell whats the temp of the vapor when the liquid at x°F
            const string temperatureColumn = "LiquidTemp";
            string valueColumn = (ct == ChargeType.Liquid ? "LiquidDensity" : "VaporVolume");

            DataTable dtUnderRange = Public.SelectAndSortTable(Public.DSDatabase.Tables["RefrigerantCharge"], temperatureColumn + " <= " + temperature + " AND RefrigerantID = " + refrigerantID, temperatureColumn + " DESC");
            DataTable dtOverRange = Public.SelectAndSortTable(Public.DSDatabase.Tables["RefrigerantCharge"], temperatureColumn + " >= " + temperature + " AND RefrigerantID = " + refrigerantID, temperatureColumn + " ASC");

            if (dtUnderRange.Rows.Count > 0 && dtOverRange.Rows.Count > 0)
            {
                decimal start = Convert.ToDecimal(dtUnderRange.Rows[0][temperatureColumn]);
                decimal end = Convert.ToDecimal(dtOverRange.Rows[0][temperatureColumn]);
                decimal startValue = Convert.ToDecimal(dtUnderRange.Rows[0][valueColumn]);
                decimal endValue = Convert.ToDecimal(dtOverRange.Rows[0][valueColumn]);

                //vapor is in ft3/lb it need to be transformed into density (lb/ft3)
                if (ct == ChargeType.Vapor)
                {
                    startValue = 1m / startValue;
                    endValue = 1m / endValue;
                }

                if (temperature == start)
                {
                    decResult = percentage * startValue;
                }
                else if (temperature == end)
                {
                    decResult = percentage * endValue;
                }
                else
                {
                    decResult = percentage * Extrapolation(start, end, startValue, endValue, temperature);
                }
            }

            dtUnderRange.Dispose();
            dtOverRange.Dispose();

            return decResult;
        }

        private decimal Extrapolation(decimal start, decimal end, decimal startValue, decimal endValue, decimal requiredValue)
        {
            decimal ratio = ((requiredValue - start) / (end - start));
            decimal totalValueRange = (endValue - startValue);

            return startValue + (ratio * totalValueRange);
        }
    }
}
