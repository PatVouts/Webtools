using System;
using System.Data;

namespace RefplusWebtools.Pricing
{
    class ControlPanelPricing
    {
        public decimal GetPanelPrice(DataTable dtControlPanelPrices, int intFanWide, int intFanLong, string strPanelNumber)
        {
            DataTable dtSelectPrice = Public.SelectAndSortTable(dtControlPanelPrices, "FanWide = " + intFanWide + " AND FanLong = " + intFanLong + " AND Panel = '" + strPanelNumber + "'", "");

            return dtSelectPrice.Rows.Count > 0 ? Convert.ToDecimal(dtSelectPrice.Rows[0]["PanelPrice"]) : Public.InvalidPrice;
        }

        public decimal GetOptionPrice(DataTable dtControlPanelPrices, int intFanWide, int intFanLong, string strPanelNumber,string strOption)
        {
            DataTable dtSelectPrice = Public.SelectAndSortTable(dtControlPanelPrices, "FanWide = " + intFanWide + " AND FanLong = " + intFanLong + " AND Panel = '" + strPanelNumber + "'", "");

            return dtSelectPrice.Rows.Count > 0 ? Convert.ToDecimal(dtSelectPrice.Rows[0][strOption]) : Public.InvalidPrice;
        }
    }
}
