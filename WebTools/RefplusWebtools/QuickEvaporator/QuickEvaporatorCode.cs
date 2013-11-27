using System;
using System.Data;
using RefplusWebtools.Pricing;

namespace RefplusWebtools.QuickEvaporator
{
    class QuickEvaporatorCode
    {
        //Calculate Needed TD For A Capacity From Evaporator Capacity
        private decimal CalculateNeededTDForACapacityFromEvaporatorCapacity(decimal decCapacity, int intQuantityOfEvaporator, decimal decSaturatedSuctionTemperature, decimal decEvaporatorCapacity, bool bolIsStandard)
        {
            //return the Temperature Difference Needed for a specific 
            //evaporator capacity to match the capacity we are looking for

            //will contain the result of

            decimal decEvaporatorCapacityCalculatedAt1TD = bolIsStandard ? CalculateStandardCapacityPerTD(decEvaporatorCapacity) : CalculateNonStandardCapacityPerTD(decEvaporatorCapacity, decSaturatedSuctionTemperature);

            ////formula : 
            ////Temperature Difference Needed = 
            ////Searched Capacity / Evaporator Capacity at 1 Temperature Difference
            //return (decCapacity / intQuantityOfEvaporator) / decEvaporatorCapacity * 10;
            return (decCapacity / intQuantityOfEvaporator) / decEvaporatorCapacityCalculatedAt1TD;
        }

        //Calculate Capacity At Given TD
        //this function is used in automatic and manual selection. the automatic use it
        //in CalculateTD_v_Evaporators() and manual call it from the form.
        public decimal CalculateCapacityAtGivenTD(decimal decTD, decimal decCapacity, int intQuantityOfEvaporator, decimal decSaturatedSuctionTemperature, bool bolIsStandard)
        {
            if (bolIsStandard)
            {
                return Math.Round(decTD * CalculateStandardCapacityPerTD(decCapacity), 0);
            }
            return Math.Round(decTD * CalculateNonStandardCapacityPerTD(decCapacity, decSaturatedSuctionTemperature), 0);
        }

        //calculate the standard capacity per TD
        private decimal CalculateStandardCapacityPerTD(decimal decCapacity)
        {
            ////Cap per unit / 10 * Voltage Multiplier
            //return ((decCapacity / intQuantityOfEvaporator) / 10);
            //2010-12-14 : Simon said that capacity divided by qty and it should not so i remove it.
            return (decCapacity / 10m);
        }

        //calculate the non-standard capacity per TD
        private decimal CalculateNonStandardCapacityPerTD(decimal decCapacity, decimal decSaturatedSuctionTemperature)
        {
            ////Cap per unit X (1 - (0.00375 X (20 - SST))) / 10 / Voltage Multiplier
            //return (decCapacity / intQuantityOfEvaporator) * (1 - (0.00375m * (20m - decSaturatedSuctionTemperature))) / 10;
            //2010-12-14 : Simon said that capacity divided by qty and it should not so i remove it.
            return decCapacity * (1m - (0.00375m * (20m - decSaturatedSuctionTemperature))) / 10m;
        }

        //run the evaporator Selection
        public DataTable RunEvaporatorSelection(DataTable dtvEvaporators, decimal decCapacity, int intQuantityOfEvaporator, decimal decSaturatedSuctionTemperature, string strDefrostType, int intVoltageID, int intFPI, int intMinimumTD,int intMaximumTD)
        {
            //function call resumé
            //Sort(SecondFilter(CalculateTD(FirstFilter(AddColumn))))
            //steps detail
            //1 - add the column to be able to fill the new value of td
            //2 - then filter depending on voltage,defrost type and more..
            //3 - then calculate the good TD for these evap to have the needed capacity
            //4 - then filter the table on those that fits in ou TD range
            //5 - then sort by TD ASC
            return
            Sort_v_Evaporators
            (
                SecondFilter_v_Evaporators
                (
                    CalculateTD_v_Evaporators
                    (
                        FirstFilter_v_Evaporators
                        (
                            AddColumnTo_v_Evaporators(dtvEvaporators.Copy())
                            , strDefrostType
                            , intVoltageID
                            , intFPI
                            ,decSaturatedSuctionTemperature
                        )
                        ,decCapacity
                        ,intQuantityOfEvaporator
                        ,decSaturatedSuctionTemperature
                    )
                ,intMinimumTD
                ,intMaximumTD
                )
            );

        }

        //Second filter the table v_Evaporator to get only the range TD i want
        private DataTable Sort_v_Evaporators(DataTable dtvEvaporators)
        {
            DataView dvvEvaporators = dtvEvaporators.DefaultView;
            //sort ascending by TD_FOR_CAPACITY
            dvvEvaporators.Sort = "TD_FOR_CAPACITY ASC";

            return dvvEvaporators.ToTable();
        }

        //Second filter the table v_Evaporator to get only the range TD i want
        private DataTable SecondFilter_v_Evaporators(DataTable dtvEvaporators, int intMinimumTD, int intMaximumTD)
        {
            DataRow[] drSecondFilterVEvaporators = dtvEvaporators.Copy().Select("TD_FOR_CAPACITY >= " + intMinimumTD + " AND TD_FOR_CAPACITY <= " + intMaximumTD);

            //clear the table
            dtvEvaporators.Clear();

            //add all result to the new table
            for (int intLoopSelectedResult = 0;
                     intLoopSelectedResult < drSecondFilterVEvaporators.Length;
                     intLoopSelectedResult++)
            {
                //add row to the table
                dtvEvaporators.Rows.Add(drSecondFilterVEvaporators[intLoopSelectedResult].ItemArray);
            }
            
            return dtvEvaporators;
        }

        //Calculate TD of each evap in the table
        private DataTable CalculateTD_v_Evaporators(DataTable dtvEvaporators, decimal decCapacity, int intQuantityOfEvaporator, decimal decSaturatedSuctionTemperature)
        {
            //loop throught all records and calculate the TD needed for the evap capacity
            //to match what we want, and then round the result and recalculate the capacity
            foreach (DataRow drvEvaporators in dtvEvaporators.Rows)
            {
                //drv_Evaporators["TD_FOR_CAPACITY"] = Math.Ceiling(CalculateNeededTDForACapacityFromEvaporatorCapacity(decCapacity, intQuantityOfEvaporator, decSaturatedSuctionTemperature, Convert.ToDecimal(drv_Evaporators["CapacityMultiplied"]), IsEvaporatorStandard(Convert.ToInt32(drv_Evaporators["EvaporatorCoilQty"]), drv_Evaporators["EvaporatorType"].ToString())));
                //drv_Evaporators["CAPACITY_FOR_TD"] = CalculateCapacityAtGivenTD(Convert.ToDecimal(drv_Evaporators["TD_FOR_CAPACITY"]), Convert.ToDecimal(drv_Evaporators["CapacityMultiplied"]), intQuantityOfEvaporator, decSaturatedSuctionTemperature, IsEvaporatorStandard(Convert.ToInt32(drv_Evaporators["EvaporatorCoilQty"]), drv_Evaporators["EvaporatorType"].ToString()));

                drvEvaporators["TD_FOR_CAPACITY"] = Math.Floor(CalculateNeededTDForACapacityFromEvaporatorCapacity(decCapacity, intQuantityOfEvaporator, decSaturatedSuctionTemperature, Convert.ToDecimal(drvEvaporators["CapacityMultiplied"]), IsEvaporatorStandard((Convert.ToInt32(drvEvaporators["LowVelocity"]) == 1), drvEvaporators["DefrostType"].ToString())) * 10m + 0.9m) / 10m;
                drvEvaporators["CAPACITY_FOR_TD"] = Math.Floor(CalculateCapacityAtGivenTD(Convert.ToDecimal(drvEvaporators["TD_FOR_CAPACITY"]), Convert.ToDecimal(drvEvaporators["CapacityMultiplied"]), intQuantityOfEvaporator, decSaturatedSuctionTemperature, IsEvaporatorStandard((Convert.ToInt32(drvEvaporators["LowVelocity"]) == 1), drvEvaporators["DefrostType"].ToString())) * 10m + 0.9m) / 10m;
            }

            
            return dtvEvaporators;
        }

        //this return is the coil use standard or not as calculation
        public bool IsEvaporatorStandard(bool lowVelocity, string strDefrostType)
        {
            //2010-12-02 : Correction on the standard
            if (strDefrostType == "A")
            {
                return true;
            }
            if (lowVelocity)
            {
                return true;
            }
            return false;

            //////if 2 coil use Non - standard except it's Air Defrost (A)
            //////and all other case use standard

            ////2010-09-29 : Found bug with evap and fix it adding low velocity
            //if (LowVelocity && strDefrostType != "A")
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
        }

        //Modify Table To acomodate our TD calculation
        private DataTable AddColumnTo_v_Evaporators(DataTable dtvEvaporators)
        {
            dtvEvaporators.Columns.Add("TD_FOR_CAPACITY", typeof(decimal));
            dtvEvaporators.Columns.Add("CAPACITY_FOR_TD", typeof(decimal));
            return dtvEvaporators;
        }

        //First filter the table v_Evaporator for less calculation
        private DataTable FirstFilter_v_Evaporators(DataTable dtvEvaporators, string strDefrostType, int intVoltageID, int intFPI, decimal decSaturatedSuctionTemperature)
        {
            DataRow[] drFirstFilterVEvaporators = dtvEvaporators.Copy().Select("DefrostType = '" + strDefrostType + "' AND VoltageID = " + intVoltageID + " AND CurrentFPI = " + intFPI + " AND SSucTemp <= " + decSaturatedSuctionTemperature + " AND FSucTemp >= " + decSaturatedSuctionTemperature);

            //clear the table
            dtvEvaporators.Clear();

            //add all result to the new table
            for (int intLoopSelectedResult = 0;
                     intLoopSelectedResult < drFirstFilterVEvaporators.Length;
                     intLoopSelectedResult++)
            {
                //add row to the table
                dtvEvaporators.Rows.Add(drFirstFilterVEvaporators[intLoopSelectedResult].ItemArray);
            }
            
            return dtvEvaporators;
        }

        //search the model and return it's capacity at given parameter
        public DataTable ModelInformations(DataTable dtvEvaporators, string strModel,int intQuantityOfEvaporator, int intVoltageID, int intFPI, decimal decSaturatedSuctionTemperature, int intMinimumTD, int intMaximumTD, bool bolIsStandard)
        {
            dtvEvaporators = FilterModelInformations(dtvEvaporators, strModel, intVoltageID, intFPI, decSaturatedSuctionTemperature);

            //if we have records
            if (dtvEvaporators.Rows.Count > 0)
            {
                //from min TD to max TD
                for (decimal decTD = intMinimumTD; decTD <= intMaximumTD; decTD = decTD + 0.1m)
                {
                    //if dectd == intmintd that mean it's the first one, so we use the first
                    //row, else we create a new rows and copy from last one and add new value
                    if (decTD == intMinimumTD)
                    {
                        dtvEvaporators.Rows[0]["TD_FOR_CAPACITY"] = decTD;
                        dtvEvaporators.Rows[0]["CAPACITY_FOR_TD"] = CalculateCapacityAtGivenTD(decTD, Convert.ToDecimal(dtvEvaporators.Rows[0]["CapacityMultiplied"]), intQuantityOfEvaporator, decSaturatedSuctionTemperature, bolIsStandard);
                    }
                    else
                    {
                        DataRow drModel = dtvEvaporators.NewRow();
                        drModel.ItemArray = dtvEvaporators.Rows[0].ItemArray;
                        drModel["TD_FOR_CAPACITY"] = decTD;
                        drModel["CAPACITY_FOR_TD"] = CalculateCapacityAtGivenTD(decTD, Convert.ToDecimal(dtvEvaporators.Rows[0]["CapacityMultiplied"]), intQuantityOfEvaporator, decSaturatedSuctionTemperature, bolIsStandard);

                        dtvEvaporators.Rows.Add(drModel.ItemArray);
                    }
                }
            }

            return dtvEvaporators;
        }

        private DataTable FilterModelInformations(DataTable dtvEvaporators, string strModel, int intVoltageID, int intFPI, decimal decSaturatedSuctionTemperature)
        {
            //add columns
            dtvEvaporators.Columns.Add("TD_FOR_CAPACITY", typeof(decimal));
            dtvEvaporators.Columns.Add("CAPACITY_FOR_TD", typeof(decimal));

            //search
            DataRow[] drvEvaporators = dtvEvaporators.Copy().Select("EvaporatorID = '" + strModel + "' AND VoltageID = " + intVoltageID + " AND CurrentFPI = " + intFPI + " AND SSucTemp <= " + decSaturatedSuctionTemperature + " AND FSucTemp >= " + decSaturatedSuctionTemperature);

            //clear the table
            dtvEvaporators.Clear();

            //add all result to the new table
            for (int intLoopSelectedResult = 0;
                     intLoopSelectedResult < drvEvaporators.Length;
                     intLoopSelectedResult++)
            {
                //add row to the table
                dtvEvaporators.Rows.Add(drvEvaporators[intLoopSelectedResult].ItemArray);
            }

            return dtvEvaporators;
        }

        public decimal GetRefrigerantChargeMultiplier(DataTable dtCondenserRefrigerant, string refrigerant)
        {
            decimal decRefrigerantChargeMultiplier = 0m;

            DataTable dtCharge = Public.SelectAndSortTable(dtCondenserRefrigerant, "RefrigerantID = '" + refrigerant + "'", "");

            if (dtCharge.Rows.Count > 0)
            {
                decRefrigerantChargeMultiplier = Convert.ToDecimal(dtCondenserRefrigerant.Rows[0]["EvapChargeMultiplier"]);
            }

            return decRefrigerantChargeMultiplier;
        }

        public decimal GetElectricHeaterKilowatts(int heaterQuantity, decimal heaterWatts, decimal wattsMultiplier)
        {
            return (heaterQuantity * heaterWatts * wattsMultiplier) / 1000m;
        }

        public decimal GetElectricHeaterFLA(int heaterQuantity, decimal heaterWatts, decimal flaMultiplier, int volts, int phase)
        {
            //2011-05-19 : Simon saying this formula is wrong it should not use the fla multiplier
            //return (HeaterQuantity * HeaterWatts * FLAMultiplier) / ((decimal)Math.Sqrt((double)Phase) * (decimal)Volts);
           
            //Checked with Fred, Simon & gaetan.  When it's on 240 volts triple phase, wattage should be boosted by a third.
            if (volts == 240 && phase == 3)
            {
                heaterWatts *= Convert.ToDecimal(4/3);
            }


            return (heaterQuantity * heaterWatts) / ((decimal)Math.Sqrt(phase) * volts);
        }

        public decimal GetMCA(int fanQuantity, decimal motorFLA, int heaterQuantity, decimal heaterFLA)
        {
            decimal decMCA;

            if (heaterQuantity == 0)
            {
                decMCA = (1.25m * motorFLA) + ((fanQuantity - 1m) * motorFLA);
            }
            else
            {
                decMCA = (1.25m * heaterFLA);
            }

            return decMCA;
        }

        public decimal GetMotorMCA(int fanQuantity, decimal motorFLA)
        {
            decimal decMCA = (1.25m * motorFLA) + ((fanQuantity - 1m) * motorFLA);

            return decMCA;
        }

        public decimal GetHeaterMCA(decimal heaterFLA)
        {
            decimal decMCA = (1.25m * heaterFLA);

            return decMCA;
        }

        public decimal GetMotorMOP(int fanQuantity, decimal motorFLA)
        {
            decimal decMOP = (2.25m * motorFLA) + ((fanQuantity - 1m) * motorFLA);

            return decMOP;
        }

        public decimal GetMotorFuseSize(DataTable dtFuseSize, decimal mca, decimal mop)
        {
            DataTable dtSelectedMCAFuse = Public.SelectAndSortTable(dtFuseSize, "FuseSize > " + mca, "FuseSize ASC");
            DataTable dtSelectedMOPFuse = Public.SelectAndSortTable(dtFuseSize, "FuseSize < " + mop + " OR FuseSize = 15", "FuseSize DESC");

            decimal decFuse = Convert.ToDecimal(Convert.ToDecimal(dtSelectedMOPFuse.Rows[0]["FuseSize"]) <= mca ? dtSelectedMCAFuse.Rows[0]["FuseSize"] : dtSelectedMOPFuse.Rows[0]["FuseSize"]);


            return decFuse;
        }

        public decimal GetHeaterFuseSize(DataTable dtFuseSize, decimal mca)
        {
            DataTable dtSelectedFuse = Public.SelectAndSortTable(dtFuseSize, "FuseSize * 0.8 >= " + mca, "FuseSize ASC");

            decimal decFuse = Convert.ToDecimal(dtSelectedFuse.Rows[0]["FuseSize"]);

            return decFuse;
        }

        public decimal GetFinMaterialPrice(DataTable dtCoilFinMaterial, DataTable dtCoilCasingMaterial, DataTable dtCoilTubeMaterial, DataTable dtvCoilFinDefaults, string strFinType, string strFinPattern, int intStandardFPI, int intCurrentFPI, decimal decRows, decimal decFinHeight, decimal decFinLength, string strFinMaterial)
        {
            var qcc = new QuickCoil.QuickCoilCode();
            //Get Price of Standard Coil Without Anything
            var sc = new StandardCoil(
            strFinType,
            2m,
            decRows,
            intStandardFPI,
            decFinHeight,
            decFinLength,
            0.5m,
            Convert.ToDecimal("0" + qcc.FinThicknessDefault(dtvCoilFinDefaults, strFinType, strFinPattern, intCurrentFPI, "1")),
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

            sc = new StandardCoil(
                strFinType,
                2m,
                decRows,
                intCurrentFPI,
                decFinHeight,
                decFinLength,
                0.5m,
                Convert.ToDecimal("0" + qcc.FinThicknessDefault(dtvCoilFinDefaults, strFinType, strFinPattern, intCurrentFPI, Public.SelectAndSortTable(dtCoilFinMaterial, "FinMaterial = '" + strFinMaterial + "'", "").Rows[0]["UniqueID"].ToString())),
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

        public decimal GetCoilFinHeight(DataTable dtCoilFinType, string coilModel, int numberOfTubes)
        {
            decimal decFinHeight = 0m;

            DataTable dtFinType = Public.SelectAndSortTable(dtCoilFinType, "FinType = '" + coilModel.Substring(1, 1) + "'", "");

            if (dtFinType.Rows.Count > 0)
            {
                decFinHeight = numberOfTubes * Convert.ToDecimal(dtFinType.Rows[0]["FaceTube"]);
            }

            dtFinType.Dispose();

            return decFinHeight;
        }
    }
}
