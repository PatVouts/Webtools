using System;
using System.Data;

namespace RefplusWebtools.QuickCondensingUnit
{
    class CondensingUnitCode
    {
        public DataTable SelectCondensingUnit(DataTable dtCondensingUnitModel, DataTable dtCondensingUnitSpecificBalancing, DataTable dtCondensingUnitRefrigerant, string strType, string strCompressorType, string strCompressorManufacturer, string strRefrigerant, string strVoltageID, string numberOfCompressor, decimal decCapacityMBH, decimal decCapacityRangeFactor, decimal decBalancingTemp, decimal decSST, string strRatingModel)
        {
            //add these column so i can display it on the selection form
            dtCondensingUnitSpecificBalancing.Columns.Add("Refrigerant", typeof(string));
            dtCondensingUnitSpecificBalancing.Columns.Add("Price", typeof(decimal));

            //figure firgure out our range of capacity using the factor
            decimal decMaxCapacity = decCapacityMBH * decCapacityRangeFactor;
            decimal decMinCapacity = decCapacityMBH - (decMaxCapacity - decCapacityMBH);

            //now get the list of matching unit within that range at the specific value
            DataTable dtUnitInRange = Public.SelectAndSortTable(dtCondensingUnitSpecificBalancing, "Balancing = " + decBalancingTemp + " AND SST = " + decSST + (strRatingModel != "" ? " AND Model = '" + strRatingModel + "'" : " AND CommercialCapacity >= " + decMinCapacity + " AND CommercialCapacity <= " + decMaxCapacity), "CommercialCapacity ASC");

            return FilterSelectedOptions(dtCondensingUnitModel, dtUnitInRange, dtCondensingUnitRefrigerant, strType, strCompressorType, strCompressorManufacturer, strRefrigerant, strVoltageID, numberOfCompressor, strRatingModel);
        }

        private DataTable FilterSelectedOptions(
            DataTable dtCondensingUnitModel, 
            DataTable dtUnitInRange, 
            DataTable dtCondensingUnitRefrigerant,
            string strType, 
            string strCompressorType, 
            string strCompressorManufacturer, 
            string strRefrigerant, 
            string strVoltageID, 
            string numberOfCompressor,
            string strRatingModel)
        {
            DataTable dtFilteredModel = Public.SelectAndSortTable(dtCondensingUnitModel, GetFilter(strType, strCompressorType, strCompressorManufacturer, strRefrigerant, strVoltageID, numberOfCompressor, strRatingModel), "");

            DataTable dtFinalResult = dtUnitInRange.Clone();

            for (int iRange = 0; iRange < dtUnitInRange.Rows.Count; iRange++)
            {
                for (int iFilter = 0; iFilter < dtFilteredModel.Rows.Count; iFilter++)
                {
                    if (dtUnitInRange.Rows[iRange]["Model"].ToString() == dtFilteredModel.Rows[iFilter]["Model"].ToString())
                    {
                        DataRow drFinalResult = dtFinalResult.NewRow();
                        drFinalResult.ItemArray = dtUnitInRange.Rows[iRange].ItemArray;
                        drFinalResult["Refrigerant"] = Public.SelectAndSortTable(dtCondensingUnitRefrigerant, "RefrigerantParameter = " + dtFilteredModel.Rows[iFilter]["RefrigerantID"], "").Rows[0]["Refrigerant"].ToString();
                        drFinalResult["Price"] = Convert.ToDecimal(dtFilteredModel.Rows[iFilter]["Price"]);

                        dtFinalResult.Rows.Add(drFinalResult);


                        iFilter = dtFilteredModel.Rows.Count;
                    }
                }
            }

            return dtFinalResult;
          
        }

        public decimal GetFuseSize(DataTable dtFuseSize, decimal mca, decimal mop)
        {
            DataTable dtSelectedMCAFuse = Public.SelectAndSortTable(dtFuseSize, "FuseSize > " + mca, "FuseSize ASC");
            DataTable dtSelectedMOPFuse = Public.SelectAndSortTable(dtFuseSize, "FuseSize < " + mop + " OR FuseSize = 15", "FuseSize DESC");

            decimal decFuse = Convert.ToDecimal(Convert.ToDecimal(dtSelectedMOPFuse.Rows[0]["FuseSize"]) <= mca ? dtSelectedMCAFuse.Rows[0]["FuseSize"] : dtSelectedMOPFuse.Rows[0]["FuseSize"]);


            return decFuse;
        }

        public decimal GetFinMaterialPrice(DataTable dtCoilFinMaterial, DataTable dtCoilCasingMaterial, DataTable dtCoilTubeMaterial, DataTable dtvCoilFinDefaults, string strFinType, string strFinShape, int fpi, decimal decRows, decimal decFinHeight, decimal decFinLength, string strFinMaterial)
        {
            var qcc = new QuickCoil.QuickCoilCode();
            //Get Price of Standard Coil Without Anything
            var sc = new Pricing.StandardCoil(
            strFinType,
            2m,
            decRows,
            fpi,
            decFinHeight,
            decFinLength,
            0.5m,
            Convert.ToDecimal("0" + qcc.FinThicknessDefault(dtvCoilFinDefaults, strFinType, strFinShape, fpi, "1")),
            "COPPER",
            0.016m,
            0.064m,
            Convert.ToDecimal(Public.SelectAndSortTable(dtCoilFinMaterial, "FinMaterial = 'ALUMINIUM'", "").Rows[0]["MaterialDensity"]),
            Convert.ToDecimal(Public.SelectAndSortTable(dtCoilFinMaterial, "FinMaterial = 'ALUMINIUM'", "").Rows[0]["PricePerLbs"]),
            Convert.ToDecimal(Public.SelectAndSortTable(dtCoilCasingMaterial, "CasingMaterial = 'Galvanized Steel'", "").Rows[0]["MaterialDensity"]),
            Convert.ToDecimal(Public.SelectAndSortTable(dtCoilCasingMaterial, "CasingMaterial = 'Galvanized Steel'", "").Rows[0]["PricePerLbs"]),
            Convert.ToDecimal(Public.SelectAndSortTable(dtCoilTubeMaterial, "TubeMaterial = 'COPPER'", "").Rows[0]["MaterialDensity"]),
            Convert.ToDecimal(Public.SelectAndSortTable(dtCoilTubeMaterial, "TubeMaterial = 'COPPER'", "").Rows[0]["PricePerLbs"]));

            decimal decStandardPrice = sc.Price;

            sc = new Pricing.StandardCoil(
                strFinType,
                2m,
                decRows,
                fpi,
                decFinHeight,
                decFinLength,
                0.5m,
                Convert.ToDecimal("0" + qcc.FinThicknessDefault(dtvCoilFinDefaults, strFinType, strFinShape, fpi, Public.SelectAndSortTable(dtCoilFinMaterial, "FinMaterial = '" + strFinMaterial + "'", "").Rows[0]["UniqueID"].ToString())),
                "COPPER",
                0.016m,
                0.064m,
               Convert.ToDecimal(Public.SelectAndSortTable(dtCoilFinMaterial, "FinMaterial = '" + strFinMaterial + "'", "").Rows[0]["MaterialDensity"]),
                Convert.ToDecimal(Public.SelectAndSortTable(dtCoilFinMaterial, "FinMaterial = '" + strFinMaterial + "'", "").Rows[0]["PricePerLbs"]),
                Convert.ToDecimal(Public.SelectAndSortTable(dtCoilCasingMaterial, "CasingMaterial = 'Galvanized Steel'", "").Rows[0]["MaterialDensity"]),
                Convert.ToDecimal(Public.SelectAndSortTable(dtCoilCasingMaterial, "CasingMaterial = 'Galvanized Steel'", "").Rows[0]["PricePerLbs"]),
                Convert.ToDecimal(Public.SelectAndSortTable(dtCoilTubeMaterial, "TubeMaterial = 'COPPER'", "").Rows[0]["MaterialDensity"]),
                Convert.ToDecimal(Public.SelectAndSortTable(dtCoilTubeMaterial, "TubeMaterial = 'COPPER'", "").Rows[0]["PricePerLbs"]));

            decimal decNewPrice = sc.Price;

            decimal decMaterialPrice = decNewPrice - decStandardPrice;

            return Math.Max(decMaterialPrice, 0m);
        }

        private string GetFilter(
            string strType,
            string strCompressorType,
            string strCompressorManufacturer,
            string strRefrigerant,
            string strVoltageID,
            string numberOfCompressor,
            string strRatingModel)
        {
            string strFilter = "";

            strFilter += "UnitType = '" + strType.Substring(0, 1) + "' AND AirFlow = '" + strType.Substring(1, 1) + "'";

            if (strCompressorType != "ALL")
                strFilter += " AND CompressorType = '" + strCompressorType + "'";

            if (strCompressorManufacturer != "ALL")
                strFilter += " AND CompressorManufacturer = '" + strCompressorManufacturer + "'";

            if (strRefrigerant != "ALL")
                strFilter += " AND RefrigerantID = " + strRefrigerant;

            strFilter += " AND VoltageID = " + strVoltageID;

            if (numberOfCompressor != "ALL")
                strFilter += " AND NumberOfCompressor = " + numberOfCompressor;

            if (strRatingModel != "")
                strFilter += " AND Model = '" + strRatingModel + "'";

            return strFilter;
        }
    }
}
