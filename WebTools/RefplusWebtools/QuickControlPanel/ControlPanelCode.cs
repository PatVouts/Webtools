using System;
using System.Collections.Generic;
using System.Data;

namespace RefplusWebtools.QuickControlPanel
{
    class ControlPanelCode
    {
        //this constant is use in code to mean N/A. in database it's stored that way also
        private const decimal PriceNotAvailable = -1000000m;

        public DataTable GetListOfOptions(DataTable dtControlPanelOptions, DataTable dtControlPanelOptionsSelection, DataTable dtControlPanelPanelOptionPrices, DataTable dtControlPanelPanelPrices, string strPanel, int unitVoltageID, FrmQuickControlPanel.CoolerType ct, int fanWide, int fanLong, string motorCoilArr)
        {
            string filterForOption = GetFilterForOptions(GetDistinctOptionsExcludingUnavailablePrice(dtControlPanelPanelOptionPrices, GetValidDistinctOptions(dtControlPanelOptionsSelection, ct, fanWide, motorCoilArr), strPanel, unitVoltageID, fanWide, fanLong));

            DataTable dtGoodOptions = Public.SelectAndSortTable(dtControlPanelOptions, filterForOption, "PanelOption ASC");

            return dtGoodOptions;

        }

        private static string GetFilterForOptions(List<string> strOptions)
        {
            string strFilter = "";

            for (int i = 0; i < strOptions.Count; i++)
            {
                strFilter += " OR PanelOption = '" + strOptions[i] + "'";
            }

            strFilter = strFilter.Length > 0 ? strFilter.Substring(4) : "PanelOption = ''";

            return strFilter;
        }

        private List<string> GetDistinctOptionsExcludingUnavailablePrice(DataTable dtControlPanelPanelOptionPrices, IEnumerable<string> distinctOptions,string strPanel, int unitVoltageID, int fanWide, int fanLong)
        {
            var validDistinctOption = new List<string>();

            foreach (string sOption in distinctOptions)
            {
                if (GetOptionPrice(dtControlPanelPanelOptionPrices, strPanel, sOption,unitVoltageID, fanWide, fanLong) != PriceNotAvailable)
                {
                    validDistinctOption.Add(sOption);
                }
            }

            return validDistinctOption;
        }

        private IEnumerable<string> GetValidDistinctOptions(DataTable dtControlPanelOptionsSelection, FrmQuickControlPanel.CoolerType ct, int fanWide, string motorCoilArr)
        {
            var strOptions = new List<string>();

            DataTable dtPreSelection = Public.SelectAndSortTable(dtControlPanelOptionsSelection, "CoolerType = '" + (ct == FrmQuickControlPanel.CoolerType.Condenser ? "COND" : "FC") + "' AND MinFanWide <= " + fanWide + " AND MaxFanWide >= " + fanWide + " AND MotorCoilArr LIKE '%" + motorCoilArr + "%'", "");

            for (int iSelection = 0; iSelection < dtPreSelection.Rows.Count; iSelection++)
            {
                string strOption = dtPreSelection.Rows[iSelection]["PanelOption"].ToString();

                if (!StringExist(strOptions, strOption))
                {
                    strOptions.Add(strOption);
                }
            }

            return strOptions;
        }

        private IEnumerable<string> GetValidDistinctPanels(DataTable dtControlPanelPanelsSelection, FrmQuickControlPanel.CoolerType ct,int fanWide, int numberOfCircuit, bool circuitCapacityEqual, string motorCoilArr)
        {
            var strPanels = new List<string>();

            DataTable dtPreSelection = Public.SelectAndSortTable(dtControlPanelPanelsSelection, "CoolerType = '" + (ct == FrmQuickControlPanel.CoolerType.Condenser ? "COND" : "FC") + "' AND MinFanWide <= " + fanWide + " AND MaxFanWide >= " + fanWide + " AND MinCircuits <= " + numberOfCircuit + " AND MaxCircuits >= " + numberOfCircuit + " AND EqualCapacity = " + (circuitCapacityEqual ? "1" : "0") + " AND MotorCoilArr LIKE '%" + motorCoilArr + "%'", "");

            for (int iSelection = 0; iSelection < dtPreSelection.Rows.Count; iSelection++)
            {
                string strPanel = dtPreSelection.Rows[iSelection]["Panel"].ToString();

                if (!StringExist(strPanels, strPanel))
                {
                    strPanels.Add(strPanel);
                }
            }

            return strPanels;
        }

        private List<string> GetDistinctPanelExcludingUnavailablePrice(DataTable dtControlPanelPanelPrices, IEnumerable<string> distinctPanel, int fanWide, int fanLong)
        {
            var validDistinctPanel = new List<string>();

            foreach (string spanel in distinctPanel)
            {
                if (GetPanelPrice(dtControlPanelPanelPrices, spanel, fanWide, fanLong) != PriceNotAvailable)
                {
                    validDistinctPanel.Add(spanel);
                }
            }

            return validDistinctPanel;
        }

        public bool IsPanelPriceSpecial(DataTable dtControlPanelSpecialPrice, string strPanel, int fanWide, int fanLong)
        {
            bool isSpecialPrice = (Convert.ToInt32(Public.SelectAndSortTable(dtControlPanelSpecialPrice, "Panel = '" + strPanel + "' AND FanWide = " + fanWide + " AND FanLong = " + fanLong, "").Rows[0]["SpecialPrice"]) == 1);

            return isSpecialPrice;
        }

        public decimal GetPanelPrice(DataTable dtControlPanelPanelPrices, string strPanel, int fanWide, int fanLong)
        {
            decimal decPrice = Convert.ToDecimal(Public.SelectAndSortTable(dtControlPanelPanelPrices, "Panel = '" + strPanel + "' AND FanWide = " + fanWide + " AND FanLong = " + fanLong, "").Rows[0]["Price"]);

            return decPrice;
        }

        public decimal GetOptionPrice(DataTable dtControlPanelPanelOptionPrices, string strPanel, string option, int unitVoltageID, int fanWide, int fanLong)
        {
            decimal decPrice = Convert.ToDecimal(Public.SelectAndSortTable(dtControlPanelPanelOptionPrices, "Panel = '" + strPanel + "' AND Options = '" + option + "' AND VoltageID = " + unitVoltageID + " AND FanWide = " + fanWide + " AND FanLong = " + fanLong, "").Rows[0]["Price"]);

            return decPrice;
        }

        public DataTable GetListOfControlVoltage(DataTable dtControlPanelPanelVoltage, string strPanel, DataTable dtControlPanelPanelsSelection, FrmQuickControlPanel.CoolerType ct, int fanWide, int numberOfCircuit, bool circuitCapacityEqual, string motorCoilArr)
        {
            DataTable dtPreSelection = Public.SelectAndSortTable(dtControlPanelPanelsSelection, "Panel = '" + strPanel + "' AND CoolerType = '" + (ct == FrmQuickControlPanel.CoolerType.Condenser ? "COND" : "FC") + "' AND MinFanWide <= " + fanWide + " AND MaxFanWide >= " + fanWide + " AND MinCircuits <= " + numberOfCircuit + " AND MaxCircuits >= " + numberOfCircuit + " AND EqualCapacity = " + (circuitCapacityEqual ? "1" : "0") + " AND MotorCoilArr LIKE '%" + motorCoilArr + "%'", "");

            string strVoltageFilter = GetFilterForVoltage(dtPreSelection.Rows[0]["Voltages"].ToString().Split(','));

            DataTable dtFilteredVoltage = Public.SelectAndSortTable(dtControlPanelPanelVoltage, strVoltageFilter, "Voltage");

            return dtFilteredVoltage;
        }

        private static string GetFilterForVoltage(string[] strVoltages)
        {
            string strFilter = "";

            for (int i = 0; i < strVoltages.Length; i++)
            {
                if (strVoltages[i] != "")
                {
                    strFilter += " OR VoltageParameter = '" + strVoltages[i] + "'";
                }
            }

            if (strFilter.Length > 0)
            {//this remove the first extra OR statement
                strFilter = strFilter.Substring(4);
            }

            return strFilter;
        }

        public DataTable GetListOfPanels(DataTable dtControlPanelPanels, DataTable dtControlPanelPanelsSelection, DataTable dtControlPanelPanelOptionPrices, DataTable dtControlPanelPanelPrices, FrmQuickControlPanel.CoolerType ct, int fanWide, int fanLong, int numberOfCircuit, bool circuitCapacityEqual, string motorCoilArr)
        {
            string filterForPanel = GetFilterForPanels(GetDistinctPanelExcludingUnavailablePrice(dtControlPanelPanelPrices, GetValidDistinctPanels(dtControlPanelPanelsSelection, ct, fanWide, numberOfCircuit, circuitCapacityEqual, motorCoilArr), fanWide, fanLong));

            DataTable dtGoodPanels = Public.SelectAndSortTable(dtControlPanelPanels, filterForPanel, "Panel ASC");

            return dtGoodPanels;
        }

        private static string GetFilterForPanels(List<string> strPanels)
        {
            string strFilter = "";

            for (int i = 0; i < strPanels.Count; i++)
            {
                strFilter += " OR Panel = '" + strPanels[i] + "'";
            }

            strFilter = strFilter.Length > 0 ? strFilter.Substring(4) : "Panel = ''";

            return strFilter;
        }

        private bool StringExist(List<string> sourceList, string stringToCheck)
        {
            bool bolStringExist = false;

            for (int i = 0; i < sourceList.Count; i++)
            {
                if (sourceList[i] == stringToCheck)
                {
                    bolStringExist = true;
                    i = sourceList.Count;
                }
            }

            return bolStringExist;
        }

        //return the group of the pump item
        public int PumpOptionGrouping(DataTable dtPumpOption, int intUniqueID)
        {
            //select the group
            DataRow[] drOptionInformations = dtPumpOption.Copy().Select("UniqueID = " + intUniqueID);

            int intGroupID = Convert.ToInt32(drOptionInformations[0]["Grouping"].ToString());
            

            //return the group id
            return intGroupID;
        }

  
        public DataTable FilteredPumpOptions(DataTable dtPumpOptions, string strPumpType)
        {
            //datatable to be returned
            DataTable dtSelectPumpOption = dtPumpOptions.Clone();

            //filter string
            string strFilter = "";

            //motor filter
            strFilter = strFilter + "PumpType LIKE '%" + strPumpType + "%'";

            //select filter
            DataRow[] drFilteredPumpOption = dtPumpOptions.Select(strFilter);

            //for each result add row to the return table
            for (int intRow = 0; intRow < drFilteredPumpOption.Length; intRow++)
            {
                dtSelectPumpOption.Rows.Add(drFilteredPumpOption[intRow].ItemArray);
            }

            //remove inactive options and sort
            DataView dvSelectPumpOption = Query.RemoveInactiveRecords(dtSelectPumpOption).DefaultView;

            dvSelectPumpOption.Sort = "UniqueID ASC";

            return dvSelectPumpOption.ToTable();
        }
      
        public DataTable GetReceiverModels(DataTable dtReceiverModel, decimal decRefrigerantWinterChargeWithRatioApplied)
        {
            //get the list of possible models
            DataRow[] drReceiverModel = dtReceiverModel.Select("Max > " + decRefrigerantWinterChargeWithRatioApplied);

            //clone the tabel to add back what we neeb
            DataTable dtReceiverModelReturn = dtReceiverModel.Clone();

            //add the result to the output table
            for (int intRow = 0; intRow < drReceiverModel.Length; intRow++)
            {
                dtReceiverModelReturn.Rows.Add(drReceiverModel[intRow].ItemArray);
            }

            //create a view to sort the models
            DataView dvReceiverModelReturn = dtReceiverModelReturn.DefaultView;

            //sort
            dvReceiverModelReturn.Sort = "Min ASC";

            //put back the sorted value into the return table
            dtReceiverModelReturn = dvReceiverModelReturn.ToTable();

            return dtReceiverModelReturn;
        }

        public decimal GetHeatRejectionFactor(DataTable dtHeatRejectionFactor, decimal decSST, decimal decCondensingTemp)
        {
            decimal decFactor = 0m;

            DataTable dtFactor = Public.SelectAndSortTable(dtHeatRejectionFactor, "SST = " + decSST, "");

            if (dtFactor.Rows.Count > 0)
            {
                decFactor = Convert.ToDecimal(dtFactor.Rows[0]["COND_" + Convert.ToInt32(decCondensingTemp)]);
            }

            return decFactor;
        }

        public DataTable GetValveList(DataTable dtReceiverValve, string strRefrigerantType, decimal decHeatRejectionFactor, decimal decCircuitCapacity)
        {
            //the tonnage of the circuit
            int intTonnage = Convert.ToInt32(Math.Ceiling(Tools.Conversion.Btu_Tons(decCircuitCapacity / decHeatRejectionFactor)));

            //select the valve possible for the tonnage of the circuit and refrigerant
            DataRow[] drReceiverValve = dtReceiverValve.Select("tons = " + intTonnage + " AND Refrigerant LIKE '%" + strRefrigerantType + "%'");

            //table that will be return
            DataTable dtReceiverValveReturn = dtReceiverValve.Clone();

            //for each result add it to the table
            for (int intRow = 0; intRow < drReceiverValve.Length; intRow++)
            {
                //put tha variable to false
                bool bolValveExist = false;

                //loop to check if the manufacturer vale already in the list
                foreach (DataRow drReceiverValveReturn in dtReceiverValveReturn.Rows)
                {
                    if (drReceiverValveReturn["Manufacturer"].ToString() == drReceiverValve[intRow]["Manufacturer"].ToString())
                    {
                        //manufacturere already in the list
                        bolValveExist = true;
                    }
                }

                //if it's false it mean the manufacturere isn't in the list yet so add it
                if (!bolValveExist)
                {
                    //add the manufacturer
                    dtReceiverValveReturn.Rows.Add(drReceiverValve[intRow].ItemArray);
                }
            }

            //dataview to sort
            DataView dvReceiverValveReturn = dtReceiverValveReturn.DefaultView;

            //sort
            dvReceiverValveReturn.Sort = "Manufacturer DESC";

            //put back the sorted value in the return table
            dtReceiverValveReturn = dvReceiverValveReturn.ToTable();

            //dispose
            dvReceiverValveReturn.Dispose();

            return dtReceiverValveReturn;
        }

        public decimal GetReinforcedBasePrice(DataTable dtReceiverReinforcedBasePrice, string strMotor, string strCoilArr, int fanWide, int fanLong)
        {
            decimal decPrice = -999999m;

            DataTable dtReinforcedPrice = Public.SelectAndSortTable(dtReceiverReinforcedBasePrice, "CondenserSeries like '%" + strMotor + strCoilArr + "%' AND FanWide = " + fanWide + " AND FanLong = " + fanLong, "");

            if (dtReinforcedPrice.Rows.Count > 0)
            {
                decPrice = Convert.ToDecimal(dtReinforcedPrice.Rows[0]["Price"]);
            }

            return decPrice;
        }

        public decimal GetReinforcedBaseWeight(DataTable dtReceiverReinforcedBasePrice, string strMotor, string strCoilArr, int fanWide, int fanLong)
        {
            decimal decWeight = -999999m;

            DataTable dtReinforced = Public.SelectAndSortTable(dtReceiverReinforcedBasePrice, "CondenserSeries like '%" + strMotor + strCoilArr + "%' AND FanWide = " + fanWide + " AND FanLong = " + fanLong, "");

            if (dtReinforced.Rows.Count > 0)
            {
                decWeight = Convert.ToDecimal(dtReinforced.Rows[0]["Weight"]);
            }

            return decWeight;
        }
    }
}
