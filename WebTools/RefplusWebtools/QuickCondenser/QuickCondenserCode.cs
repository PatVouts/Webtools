using System;
using System.Data;
using System.Drawing;

namespace RefplusWebtools.QuickCondenser
{
    class QuickCondenserCode
    {
        //Calculate the Circuit TD (Temperature Difference)
        private decimal Circuit_TD(decimal decCondenserTemperature, decimal decAmbientTemperature)
        {
            return decCondenserTemperature - decAmbientTemperature;
        }

        // Calculate the THR per TD (temperature difference)
        private decimal Circuit_THR_PER_TD(decimal decTHR, decimal decCircuitTD)
        {
            return decTHR / decCircuitTD;
        }

        //this formula is for the first condition test
        public decimal Circuit_Formula_1(decimal decCircuitTHRPerTD, decimal decCondenserCapacityPerCircuit, decimal decRefrigerantCapacityAdjustement, decimal decAltitudeCapacityAdjustment, decimal decHertzCapacityAdjustement)
        {
            return Math.Floor(
                                decCircuitTHRPerTD /
                                (
                                    decCondenserCapacityPerCircuit *
                                   (decRefrigerantCapacityAdjustement *
                                    decAltitudeCapacityAdjustment *
                                    decHertzCapacityAdjustement)
                                 )
                                * 100m
                              )
                              / 100m;
        }

        //this formula is for the first condition test
        private decimal Condenser_Circuit_Formula_1(decimal decCircuitTHRPerTD, decimal decCondenserCapacityPerCircuit, decimal decRefrigerantCapacityAdjustement, decimal decAltitudeCapacityAdjustment, decimal decHertzCapacityAdjustement)
        {
            return Math.Floor(
                                decCircuitTHRPerTD /
                                (
                                    decCondenserCapacityPerCircuit *
                                   (decRefrigerantCapacityAdjustement *
                                    decAltitudeCapacityAdjustment *
                                    decHertzCapacityAdjustement)
                                 )
                //* 100m
                              );
        }

        //this formula is for the second condition test
        private decimal Circuit_Formula_2(decimal decCircuitTHRPerTd, decimal decCondenserCapacityPerCircuit, decimal decRefrigerantCapacityAdjustement, decimal decAltitudeCapacityAdjustment, decimal decHertzCapacityAdjustement)
        {
            return Circuit_Formula_1(decCircuitTHRPerTd, decCondenserCapacityPerCircuit, decRefrigerantCapacityAdjustement, decAltitudeCapacityAdjustment, decHertzCapacityAdjustement) 
                / Math.Floor(Circuit_Formula_1(decCircuitTHRPerTd, decCondenserCapacityPerCircuit, decRefrigerantCapacityAdjustement, decAltitudeCapacityAdjustment, decHertzCapacityAdjustement));
        }

        //this result we need if formula 2 condition is true
        private decimal Circuit_Formula_2_TRUE(decimal decCircuitTHRPerTd, decimal decCondenserCapacityPerCircuit, decimal decRefrigerantCapacityAdjustement, decimal decAltitudeCapacityAdjustment, decimal decHertzCapacityAdjustement)
        {
            return Math.Floor(
                                (
                                    decCircuitTHRPerTd /
                                    (
                                        decCondenserCapacityPerCircuit *
                                        decRefrigerantCapacityAdjustement *
                                        decAltitudeCapacityAdjustment *
                                        decHertzCapacityAdjustement
                                    )
                                    + 0.9m
                                )
                                * 100m
                             )
                             / 100m;
        }

        //this result we need if formula 2 condition is true
        private decimal Condenser_Circuit_Formula_2_TRUE(decimal decCircuitTHRPerTd, decimal decCondenserCapacityPerCircuit, decimal decRefrigerantCapacityAdjustement, decimal decAltitudeCapacityAdjustment, decimal decHertzCapacityAdjustement)
        {
            return Math.Floor(
                                (
                                    decCircuitTHRPerTd /
                                    (
                                        decCondenserCapacityPerCircuit *
                                        decRefrigerantCapacityAdjustement *
                                        decAltitudeCapacityAdjustment *
                                        decHertzCapacityAdjustement
                                    )
                                    + 0.9m
                                )
                //* 100m
                             );
        }

       
        //this result give the number of circuits for the coil 
        //for the specific refrigerant circuit
        public decimal Circuit_NumberOfCoilCircuits(decimal decCircuitTHRPerTd, decimal decCondenserCapacityPerCircuit, decimal decRefrigerantCapacityAdjustement, decimal decAltitudeCapacityAdjustment, decimal decHertzCapacityAdjustement)
        {
            if (Circuit_Formula_1(decCircuitTHRPerTd, decCondenserCapacityPerCircuit, decRefrigerantCapacityAdjustement, decAltitudeCapacityAdjustment, decHertzCapacityAdjustement) < 1m)
            {//if the formula < 1
                return 1m;
            }
            if (Math.Round(Circuit_Formula_2(decCircuitTHRPerTd, decCondenserCapacityPerCircuit, decRefrigerantCapacityAdjustement, decAltitudeCapacityAdjustment, decHertzCapacityAdjustement), 2) > 1.10m)
            {//if the formula 2 > 1.1 (10% more)
                //return the TRUE condition result
                return Circuit_Formula_2_TRUE(decCircuitTHRPerTd, decCondenserCapacityPerCircuit, decRefrigerantCapacityAdjustement, decAltitudeCapacityAdjustment, decHertzCapacityAdjustement);
            }
            //return the FALSE condition result
            return Math.Floor(Circuit_Formula_1(decCircuitTHRPerTd, decCondenserCapacityPerCircuit, decRefrigerantCapacityAdjustement, decAltitudeCapacityAdjustment, decHertzCapacityAdjustement));
        }

        //this result give the number of circuits for the coil 
        //for the specific refrigerant circuit
        public int Condenser_Circuit_NumberOfCoilCircuits(decimal decCircuitTHRPerTd, decimal decCondenserCapacityPerCircuit, decimal decRefrigerantCapacityAdjustement, decimal decAltitudeCapacityAdjustment, decimal decHertzCapacityAdjustement)
        {
            if (Condenser_Circuit_Formula_1(decCircuitTHRPerTd, decCondenserCapacityPerCircuit, decRefrigerantCapacityAdjustement, decAltitudeCapacityAdjustment, decHertzCapacityAdjustement) < 1m)
            {//if the formula < 1
                return 1;
            }
            if (Circuit_Formula_2(decCircuitTHRPerTd, decCondenserCapacityPerCircuit, decRefrigerantCapacityAdjustement, decAltitudeCapacityAdjustment, decHertzCapacityAdjustement) > 1.1m)
            {//if the formula 2 > 1.1 (10% more)
                //return the TRUE condition result
                return Convert.ToInt32(Condenser_Circuit_Formula_2_TRUE(decCircuitTHRPerTd, decCondenserCapacityPerCircuit, decRefrigerantCapacityAdjustement, decAltitudeCapacityAdjustment, decHertzCapacityAdjustement));
            }
            //return the FALSE condition result
            return Convert.ToInt32(Math.Floor(Condenser_Circuit_Formula_1(decCircuitTHRPerTd, decCondenserCapacityPerCircuit, decRefrigerantCapacityAdjustement, decAltitudeCapacityAdjustment, decHertzCapacityAdjustement)));
        }

        //this return the Altitude Capacity Adjustment
        public decimal AltitudeCapacityAdjustment(decimal decAltitude)
        {
            return (1000m - (0.02085m * decAltitude)) / 1000m;
        }

       

        //refresh the refrigerant and select condenser models
        public DataTable GetCondenserModels(DataTable dtRefrigerantCircuits, DataTable dtCondenserModel, DataTable dtCondenserModelCrossReference, decimal decHertzCapacityAdjustment, int intVoltageID, string strVoltageDescription, decimal decAltitude, decimal decAmbientTemperature, string strTypeOfCondenser, string strFanArrangement, string[] strMotor, string[] strCoilArr, string[] strVoltageMotor, string[] strVoltageCoilArr, string strAirFlowTypeFilter, decimal decTotalHeatRecoveryPercentage, string strFPIParameter, string strRatingModelParameter)
        {
            //2010-07-12 : Email from Simon Trepanier confirm that he want to remove the
            //restriction on the models of condenser for R-410A
            //bool bolIsThereR410A = false;

            //foreach (DataRow drRefrigerantCircuits in dtRefrigerantCircuits.Rows)
            //{
            //    if (drRefrigerantCircuits["RefrigerantType"].ToString() == "R-410a")
            //    {
            //        bolIsThereR410A = true;
            //    }
            //}

            //filter the list of condenser to speed up the selection
            dtCondenserModel = FilterCondenserModels(dtCondenserModel, strTypeOfCondenser, strFanArrangement, strMotor, strCoilArr, strVoltageMotor, strVoltageCoilArr,ref strAirFlowTypeFilter, strFPIParameter, strRatingModelParameter/*, bolIsThereR410A*/);

            //add new column to the condenser table
            //dtCondenserModel.Columns.Add("Capacity", typeof(decimal));
            //dtCondenserModel.Columns.Add("MinCapacity", typeof(decimal));
            //dtCondenserModel.Columns.Add("MinCirc", typeof(decimal));
            //dtCondenserModel.Columns.Add("OrderByValue", typeof(decimal));
            //dtCondenserModel.Columns.Add("MatchExtraField1", typeof(decimal));
            //dtCondenserModel.Columns.Add("OversizeExtraField1", typeof(decimal));
            //dtCondenserModel.Columns.Add("UndersizeExtraField1", typeof(decimal));
            //dtCondenserModel.Columns.Add("TotalCircQuantity", typeof(int));
            dtCondenserModel.Columns.Add("CondenserSelectionType", typeof(int));
            //dtCondenserModel.Columns.Add("Adjusted_TD", typeof(decimal));
            //dtCondenserModel.Columns.Add("Adjusted_Ambient_Temperature", typeof(decimal));
            //dtCondenserModel.Columns.Add("Capacity_Current", typeof(decimal));
            //dtCondenserModel.Columns.Add("Capacity_Adjusted", typeof(decimal));
            dtCondenserModel.Columns.Add("CondenserModel", typeof(string));
            dtCondenserModel.Columns.Add("VoltageID", typeof(int));
            dtCondenserModel.Columns.Add("VoltageDescription", typeof(string));
            dtCondenserModel.Columns.Add("AirFlowType", typeof(string));
            dtCondenserModel.Columns.Add("TotalHeatRecoveryPercentage", typeof(decimal));
            dtCondenserModel.Columns.Add("Altitude", typeof(decimal));
            dtCondenserModel.Columns.Add("MotorFLA", typeof(decimal));
            dtCondenserModel.Columns.Add("MotorHP", typeof(string));
            dtCondenserModel.Columns.Add("MotorRPM", typeof(string));

            dtCondenserModel.Columns.Add("MotorID", typeof(string));
            dtCondenserModel.Columns.Add("MotorHPNumber", typeof(decimal));
            dtCondenserModel.Columns.Add("MotorRPMNumber", typeof(decimal));
            dtCondenserModel.Columns.Add("MotorRotType", typeof(string));
            dtCondenserModel.Columns.Add("MotorFrameType", typeof(string));
            dtCondenserModel.Columns.Add("MotorShaftLength", typeof(decimal));
            dtCondenserModel.Columns.Add("MotorMount", typeof(string));
            dtCondenserModel.Columns.Add("MotorMountFanSize", typeof(decimal));
            dtCondenserModel.Columns.Add("MotorMountFrameSize", typeof(decimal));
            dtCondenserModel.Columns.Add("MotorMountComposition", typeof(string));
            dtCondenserModel.Columns.Add("Fan", typeof(string));
            dtCondenserModel.Columns.Add("FanDiameter", typeof(decimal));
            dtCondenserModel.Columns.Add("FanBladeQuantity", typeof(int));
            dtCondenserModel.Columns.Add("FanRotationType", typeof(string));
            dtCondenserModel.Columns.Add("FanComposition", typeof(string));
            dtCondenserModel.Columns.Add("FanPitch", typeof(decimal));
            dtCondenserModel.Columns.Add("FanGuard", typeof(string));
            dtCondenserModel.Columns.Add("FanGuardFanSize", typeof(decimal));
            dtCondenserModel.Columns.Add("FanGuardComposition", typeof(string));
            dtCondenserModel.Columns.Add("CoilModel", typeof(string));
            dtCondenserModel.Columns.Add("MCA", typeof(decimal));
            dtCondenserModel.Columns.Add("MOP", typeof(decimal));
            dtCondenserModel.Columns.Add("FUSE", typeof(decimal));

            //new fields for the new way of calculating
            dtCondenserModel.Columns.Add("RatioTD", typeof(decimal));
            dtCondenserModel.Columns.Add("TargetCapacity", typeof(decimal));
            dtCondenserModel.Columns.Add("CurrentCapacity", typeof(decimal));
            dtCondenserModel.Columns.Add("Target_TD_Per_Condenser", typeof(decimal));
            dtCondenserModel.Columns.Add("TDDifference", typeof(decimal));
            dtCondenserModel.Columns.Add("Target_Ambient", typeof(decimal));
            //dtCondenserModel.Columns.Add("CurrentCircuit", typeof(int));
            //dtCondenserModel.Columns.Add("TargetCircuit", typeof(int));
            dtCondenserModel.Columns.Add("Final_Ambient", typeof(decimal));
            dtCondenserModel.Columns.Add("Final_CapacityPerTD", typeof(decimal));
            dtCondenserModel.Columns.Add("Final_Capacity", typeof(decimal));
            dtCondenserModel.Columns.Add("Final_Circuit", typeof(int));
            dtCondenserModel.Columns.Add("Final_CircuitCondenserTHRPerTDDifference", typeof(decimal));
            dtCondenserModel.Columns.Add("Final_AmbientTD", typeof(decimal));

            //for each condenser model
            foreach (DataRow drCondenserModel in dtCondenserModel.Rows)
            {
                //this variable will total up the thr/td of all circuits
                decimal decTotalTHRPerTd = 0m;

                //this variable will total up the circuit quantity of all circuits
                int intTotalCircQuantity = 0;

                //this variable will total the THR of all circuit (in BTUH)
                decimal decTotalCircuitsThrinBTUH = 0m;

                //for each refrigerant circuit
                foreach (DataRow drRefrigerantCircuits in dtRefrigerantCircuits.Rows)
                {
                    //save the altitude adjustment
                    drRefrigerantCircuits["AltitudeAdjustment"] = AltitudeCapacityAdjustment(decAltitude);

                    //save the hertz adjustment
                    drRefrigerantCircuits["HertzAdjustment"] = decHertzCapacityAdjustment;

                    //fill the quantity of circuits
                    drRefrigerantCircuits["Circ_Quantity"] = Condenser_Circuit_NumberOfCoilCircuits(Convert.ToDecimal(drRefrigerantCircuits["THR_PER_TD"]), Convert.ToDecimal(drCondenserModel["Capacity_per_circuit"]), Convert.ToDecimal(drRefrigerantCircuits["RefrigerantMultiplier"]), Convert.ToDecimal(drRefrigerantCircuits["AltitudeAdjustment"]), Convert.ToDecimal(drRefrigerantCircuits["HertzAdjustment"]));

                    //total up the THR
                    decTotalCircuitsThrinBTUH = decTotalCircuitsThrinBTUH + Convert.ToDecimal(drRefrigerantCircuits["THR"]);

                    //add up the Circ_Quantity so we can have the total
                    intTotalCircQuantity = intTotalCircQuantity + Convert.ToInt32(drRefrigerantCircuits["Circ_Quantity"]);

                    //running total
                    drRefrigerantCircuits["Circ_Quantity_Total"] = intTotalCircQuantity;

                    //add up the thr per TD so we can have the total
                    decTotalTHRPerTd = decTotalTHRPerTd + Convert.ToDecimal(drRefrigerantCircuits["THR_PER_TD"]);

                    //if (drRefrigerantCircuits["RefrigerantType"].ToString() == "R-410a")
                    //{
                    //    bolIsThereR410A = true;
                    //}
                }

                decimal decRatioTD = 0m;
                //again to calculate the ratio TD
                foreach (DataRow drRefrigerantCircuits in dtRefrigerantCircuits.Rows)
                {
                    decRatioTD = decRatioTD + (Convert.ToDecimal(drRefrigerantCircuits["TD"]) * (Convert.ToDecimal(drRefrigerantCircuits["THR"]) / decTotalCircuitsThrinBTUH));
                }

                decimal decTargetCapacity = decTotalTHRPerTd * decRatioTD;

                decimal decCurrentCapacity = (Convert.ToDecimal(drCondenserModel["THR_at_1F"]) * 1000m) * decRatioTD;

                decimal decTargetTDPerCondenser = decTargetCapacity / (Convert.ToDecimal(drCondenserModel["THR_at_1F"]) * 1000m);

                decimal decTDDifference = decRatioTD - decTargetTDPerCondenser;

                decimal decTargetAmbient = decTDDifference + decAmbientTemperature;

                decimal decAmbientLoopSetPoint = Math.Round(decTargetAmbient - 10m, 2);
                decimal decFinalCapacityPerTD = 0m;
                decimal decFinalAmbient = 0m;
                int intFinalCircuit=0;
                bool bolLooping =true;
                while (bolLooping)
                {
                    intFinalCircuit = 0;
                    decFinalCapacityPerTD = 0m;
                    foreach (DataRow drRefrigerantCircuits in dtRefrigerantCircuits.Rows)
                    {
                        if (Convert.ToDecimal(drRefrigerantCircuits["CondenserTemperature"]) - decAmbientLoopSetPoint <= 0m)
                        {
                            intFinalCircuit = intFinalCircuit + 0;
                            decFinalCapacityPerTD = decFinalCapacityPerTD + 0m;
                        }
                        else
                        {
                            decFinalCapacityPerTD = decFinalCapacityPerTD + ((Convert.ToDecimal(drRefrigerantCircuits["THR"]) / (Convert.ToDecimal(drRefrigerantCircuits["CondenserTemperature"]) - decAmbientLoopSetPoint)) / 1000m);
                            decimal decCircuitQuantity = Circuit_Formula_1(Convert.ToDecimal(drRefrigerantCircuits["THR"]) / (Convert.ToDecimal(drRefrigerantCircuits["CondenserTemperature"]) - decAmbientLoopSetPoint), Convert.ToDecimal(drCondenserModel["Capacity_per_circuit"]), Convert.ToDecimal(drRefrigerantCircuits["RefrigerantMultiplier"]), Convert.ToDecimal(drRefrigerantCircuits["AltitudeAdjustment"]), Convert.ToDecimal(drRefrigerantCircuits["HertzAdjustment"]));

                            intFinalCircuit = intFinalCircuit + GetCircuitAmount(decCircuitQuantity);
                        }
                    }
                    
                    if (intFinalCircuit > Convert.ToInt32(drCondenserModel["CondenserCircQty"]) || decFinalCapacityPerTD >= Convert.ToDecimal(drCondenserModel["THR_at_1F"]))
                    //if (intFinalCircuit > Convert.ToInt32(drCondenserModel["CondenserCircQty"]) || decFinalCapacityPerTD >= (Math.Floor(decTotal_THR_PER_TD) / 1000m))
                    {
                        bolLooping = false;
                        if(intFinalCircuit > Convert.ToInt32(drCondenserModel["CondenserCircQty"]))
                        {
                            decAmbientLoopSetPoint = decAmbientLoopSetPoint - 0.01m;
                        }
                        decFinalCapacityPerTD = 0m;
                        intFinalCircuit = 0;
                        foreach (DataRow drRefrigerantCircuits in dtRefrigerantCircuits.Rows)
                        {
                            if (Convert.ToDecimal(drRefrigerantCircuits["CondenserTemperature"]) - decAmbientLoopSetPoint <= 0m)
                            {
                                intFinalCircuit = intFinalCircuit + 0;
                                decFinalCapacityPerTD = decFinalCapacityPerTD + 0m;
                            }
                            else
                            {
                                decFinalCapacityPerTD = decFinalCapacityPerTD + ((Convert.ToDecimal(drRefrigerantCircuits["THR"]) / (Convert.ToDecimal(drRefrigerantCircuits["CondenserTemperature"]) - decAmbientLoopSetPoint)) / 1000m);
                                decimal decCircuitQuantity = Circuit_Formula_1(Convert.ToDecimal(drRefrigerantCircuits["THR"]) / (Convert.ToDecimal(drRefrigerantCircuits["CondenserTemperature"]) - decAmbientLoopSetPoint), Convert.ToDecimal(drCondenserModel["Capacity_per_circuit"]), Convert.ToDecimal(drRefrigerantCircuits["RefrigerantMultiplier"]), Convert.ToDecimal(drRefrigerantCircuits["AltitudeAdjustment"]), Convert.ToDecimal(drRefrigerantCircuits["HertzAdjustment"]));

                                intFinalCircuit = intFinalCircuit + GetCircuitAmount(decCircuitQuantity);
                            }
                        }
                        decFinalAmbient = decAmbientLoopSetPoint;
                    }
                    else
                    {
                        decAmbientLoopSetPoint = decAmbientLoopSetPoint + 0.01m;
                    }

                    //if the loop is going to be infinite
                    if (decAmbientLoopSetPoint >= 400)
                    {
                        bolLooping = false;
                    }
                }

                //if the loop as been going infinite
                if (decAmbientLoopSetPoint >= 400)
                {
                    drCondenserModel["RatioTD"] = 1000000000;
                    drCondenserModel["TargetCapacity"] = 1000000000;
                    drCondenserModel["CurrentCapacity"] = 1000000000;
                    drCondenserModel["Target_TD_Per_Condenser"] = 1000000000;
                    drCondenserModel["TDDifference"] = 1000000000;
                    drCondenserModel["Target_Ambient"] = 1000000000;

                    drCondenserModel["Final_Ambient"] = 1000000000;
                    drCondenserModel["Final_CapacityPerTD"] = 1000000000;
                    drCondenserModel["Final_Capacity"] = 1000000000;
                    drCondenserModel["Final_Circuit"] = 1000000000;

                    drCondenserModel["Final_CircuitCondenserTHRPerTDDifference"] = 1000000000;
                    drCondenserModel["Final_AmbientTD"] = 1000000000;
                    
                    drCondenserModel["CondenserSelectionType"] = 0;
                    drCondenserModel["CondenserModel"] = "";
                    drCondenserModel["VoltageID"] = intVoltageID;
                    drCondenserModel["VoltageDescription"] = strVoltageDescription;
                    drCondenserModel["AirFlowType"] = strAirFlowTypeFilter;
                    drCondenserModel["TotalHeatRecoveryPercentage"] = 1000000000;
                    drCondenserModel["Altitude"] = decAltitude;
                }
                else
                {

                    decimal decFinalCapacity = 0m;
                    foreach (DataRow drRefrigerantCircuits in dtRefrigerantCircuits.Rows)
                    {
                        decFinalCapacity = decFinalCapacity + ((Convert.ToDecimal(drCondenserModel["THR_at_1F"]) * 1000m) * ((Convert.ToDecimal(drRefrigerantCircuits["CondenserTemperature"]) - decFinalAmbient) * (Convert.ToDecimal(drRefrigerantCircuits["THR"]) / decTotalCircuitsThrinBTUH)));
                    }

                    drCondenserModel["RatioTD"] = decRatioTD;
                    drCondenserModel["TargetCapacity"] = decTargetCapacity;
                    drCondenserModel["CurrentCapacity"] = decCurrentCapacity;
                    drCondenserModel["Target_TD_Per_Condenser"] = decTargetTDPerCondenser;
                    drCondenserModel["TDDifference"] = decTDDifference;
                    drCondenserModel["Target_Ambient"] = decTargetAmbient;

                    drCondenserModel["Final_Ambient"] = decFinalAmbient;
                    drCondenserModel["Final_CapacityPerTD"] = Math.Round(decFinalCapacityPerTD, 3);
                    drCondenserModel["Final_Capacity"] = decFinalCapacity;
                    drCondenserModel["Final_Circuit"] = intFinalCircuit;

                    drCondenserModel["Final_CircuitCondenserTHRPerTDDifference"] = Math.Round(decFinalCapacityPerTD - (decTotalTHRPerTd / 1000m), 3);
                    drCondenserModel["Final_AmbientTD"] = decFinalAmbient - decAmbientTemperature;

                    //calculate and fill the new columns of the modenser models
                    //drCondenserModel["Capacity"] = Condenser_Capacity(decTotal_THR_PER_TD, Convert.ToDecimal(drCondenserModel["CondenserCircQty"]));
                    //drCondenserModel["MinCapacity"] = Condenser_MinimumCapacity(Convert.ToDecimal(drCondenserModel["Capacity_Per_Circuit"]), Convert.ToDecimal(drCondenserModel["Capacity"]));
                    //drCondenserModel["MinCirc"] = Condenser_MinimumNumberOfCircuit(Convert.ToDecimal(drCondenserModel["CondenserCircQty"]), decTotal_THR_PER_TD, Convert.ToDecimal(drCondenserModel["Capacity_Per_Circuit"]));
                    //drCondenserModel["OrderByValue"] = Condenser_OrderByValue(Convert.ToDecimal(drCondenserModel["Capacity_Per_Circuit"]), decTotal_THR_PER_TD, Convert.ToDecimal(drCondenserModel["CondenserCircQty"]));
                    //drCondenserModel["MatchExtraField1"] = Condenser_MatchExtraField1(Convert.ToDecimal(drCondenserModel["Capacity_Per_Circuit"]), Convert.ToDecimal(drCondenserModel["Capacity"]));
                    //drCondenserModel["OversizeExtraField1"] = Condenser_OversizeExtraField1(Convert.ToDecimal(drCondenserModel["Capacity_Per_Circuit"]), Convert.ToDecimal(drCondenserModel["Capacity"]));
                    //drCondenserModel["UndersizeExtraField1"] = Condenser_UndersizeExtraField1(Convert.ToDecimal(drCondenserModel["Capacity_Per_Circuit"]), Convert.ToDecimal(drCondenserModel["Capacity"]));
                    //drCondenserModel["TotalCircQuantity"] = intTotal_Circ_Quantity;
                    drCondenserModel["CondenserSelectionType"] = 0;
                    //drCondenserModel["Adjusted_TD"] = Condenser_Adjusted_TD(Convert.ToDecimal(drCondenserModel["THR_at_1F"]) * 1000m, decTotal_Circuits_THR_In_BTUH);
                    //drCondenserModel["Adjusted_Ambient_Temperature"] = Condenser_Adjusted_Ambient_Temperature(Convert.ToDecimal(dtRefrigerantCircuits.Rows[0]["CondenserTemperature"]), Convert.ToDecimal(drCondenserModel["Adjusted_TD"]));
                    //drCondenserModel["Capacity_Current"] = Condenser_Current_Capacity(Convert.ToDecimal(dtRefrigerantCircuits.Rows[0]["TD"]), Convert.ToDecimal(drCondenserModel["THR_at_1F"]) * 1000m);
                    //drCondenserModel["Capacity_Adjusted"] = Condenser_Adjusted_Capacity(Convert.ToDecimal(drCondenserModel["THR_at_1F"]) * 1000m, Convert.ToDecimal(drCondenserModel["Adjusted_TD"]));
                    drCondenserModel["CondenserModel"] = "";
                    drCondenserModel["VoltageID"] = intVoltageID;
                    drCondenserModel["VoltageDescription"] = strVoltageDescription;
                    drCondenserModel["AirFlowType"] = strAirFlowTypeFilter;
                    drCondenserModel["TotalHeatRecoveryPercentage"] = decTotalHeatRecoveryPercentage;
                    drCondenserModel["Altitude"] = decAltitude;
                }
            }
            //dtCondenserModel.WriteXml(@"test.xml");
            //return the filter over the condenser table

            //select good condensers
            dtCondenserModel = SelectUndersize_BestMatch_OverSize(dtCondenserModel, decAmbientTemperature);
            //go fill their model xref name
            dtCondenserModel = AddCondenserModelName(dtCondenserModel, dtCondenserModelCrossReference, strAirFlowTypeFilter);

            return dtCondenserModel;
            //return SelectCondenserModels(dtCondenserModel, dtCondenserModelCrossReference, strTypeOfCondenser, strFanArrangement, strMotor, strCoilArr, strVoltageMotor, strVoltageCoilArr, strAirFlowTypeFilter, strFPIParameter, strRatingModelParameter, bolIsThereR410A);
        }

        public int GetCircuitAmount(decimal decCircuitAmount)
        {
            if (decCircuitAmount < 1)
            {
                return 1;
            }
            if (Math.Round(decCircuitAmount / Math.Floor(decCircuitAmount), 2) > 1.10m)
            {
                return Convert.ToInt32(Math.Ceiling(decCircuitAmount));
            }
            return Convert.ToInt32(Math.Floor(decCircuitAmount));
        }

        private DataTable FilterCondenserModels(DataTable dtCondenserModel, string strTypeOfCondenser, string strFanArrangement, string[] strMotor, string[] strCoilArr, string[] strVoltageMotor, string[] strVoltageCoilArr,ref string strAirFlowTypeFilter, string strFPIParameter, string strRatingModelParameter/*, bool bolIsThereR410A*/)
        {
            string strFilter = "";

            ////if there is R410A we cannot have F fins
            //if (bolIsThereR410A)
            //{
            //    strFilter = strFilter + " AND FinType <> 'F'";
            //}

            if (strRatingModelParameter != "ALL")
            {
                string[] strRatingModelSplit = strRatingModelParameter.Split(Convert.ToChar(","));
                strFilter = strFilter + " AND CondenserType = '" + strRatingModelSplit[0] + "'";
                strFilter = strFilter + " AND Motor = '" + strRatingModelSplit[1] + "'";
                strFilter = strFilter + " AND CoilArr = '" + strRatingModelSplit[2] + "'";
                strFilter = strFilter + " AND FanWide = " + strRatingModelSplit[3];
                strFilter = strFilter + " AND FanLong = " + strRatingModelSplit[4];
                strFilter = strFilter + " AND Row = " + strRatingModelSplit[5];
                strFilter = strFilter + " AND FPI = " + strRatingModelSplit[6];

                //overwrite the airflow
                strAirFlowTypeFilter = strRatingModelSplit[7];


            }
            else
            {
                strFilter = strFilter + " AND CondenserType LIKE '" + strTypeOfCondenser + "%'";

                if (strFanArrangement != "ALL")
                {
                    strFilter = strFilter + " AND FanWide = " + strFanArrangement.Split(Convert.ToChar("x"))[0] + " AND FanLong = " + strFanArrangement.Split(Convert.ToChar("x"))[1];
                }

                //will ocntaint the motor coil arr condition
                string strMotorCoilArr = "";

                //for each motor add the condition
                for (int intMotorCoilArr = 0; intMotorCoilArr < strMotor.Length; intMotorCoilArr++)
                {
                    strMotorCoilArr = strMotorCoilArr + " OR (Motor = '" + strMotor[intMotorCoilArr] + "' AND CoilArr = '" + strCoilArr[intMotorCoilArr] + "')";
                }

                //add parentesis is case other filter applied
                strMotorCoilArr = " AND (" + strMotorCoilArr.Substring(4) + ")";

                //add the motors
                strFilter = strFilter + strMotorCoilArr;

                //will ocntaint the motor coil arr condition
                strMotorCoilArr = "";

                //for each motor add the condition
                for (int intMotorCoilArr = 0; intMotorCoilArr < strVoltageMotor.Length; intMotorCoilArr++)
                {
                    strMotorCoilArr = strMotorCoilArr + " OR (Motor = '" + strVoltageMotor[intMotorCoilArr] + "' AND CoilArr = '" + strVoltageCoilArr[intMotorCoilArr] + "')";
                }

                //add parentesis is case other filter applied
                strMotorCoilArr = " AND (" + strMotorCoilArr.Substring(4) + ")";

                //add the motors
                strFilter = strFilter + strMotorCoilArr;

                //split on comma the fpi
                string[] strFPISplit = strFPIParameter.Split(Convert.ToChar(","));

                //the first one is special
                string strFPIFilter = " AND (FPI = " + strFPISplit[0];

                //for each subsequent possible FPI add them to the condition
                for (int intSplit = 1; intSplit < strFPISplit.Length; intSplit++)
                {
                    strFPIFilter = strFPIFilter + " OR FPI = " + strFPISplit[intSplit];
                }

                //finally close the parenthesis
                strFPIFilter = strFPIFilter + ")";

                //add the fpi to the condition
                strFilter = strFilter + strFPIFilter;
            }

            strFilter = strFilter.Substring(4);
            //clone the condenser table into the return table
            DataTable dtCondenserModelReturn = dtCondenserModel.Clone();
            DataRow[] drCondenserModelResult = dtCondenserModel.Select(strFilter);

            //for each row, add it to the result table
            foreach (DataRow drFilter in drCondenserModelResult)
            {
                dtCondenserModelReturn.Rows.Add(drFilter.ItemArray);
            }

            return dtCondenserModelReturn;
        }

        //select the 3 model we want
        private DataTable SelectUndersize_BestMatch_OverSize(DataTable dtCondenserModel, decimal decAmbientTemperature)
        {
            DataTable dtResults = dtCondenserModel.Clone();

            //select undersize
            DataTable dtUndersize = Public.SelectAndSortTable(dtCondenserModel, "Final_Ambient < " + decAmbientTemperature + " AND RatioTD <> 1000000000", "Final_Ambient DESC");
            if (dtUndersize.Rows.Count > 0)
            {
                dtResults.Rows.Add(dtUndersize.Rows[0].ItemArray);
                dtResults.Rows[dtResults.Rows.Count - 1]["CondenserSelectionType"] = CondenserSelectionType.Undersize;
            }
            dtUndersize.Dispose();

            //select best match and oversize
            DataTable dtBestMatchAndOversize = Public.SelectAndSortTable(dtCondenserModel, "Final_Ambient >= " + decAmbientTemperature + " AND RatioTD <> 1000000000", "Final_Ambient ASC");
            if (dtBestMatchAndOversize.Rows.Count > 0)
            {
                //add best
                dtResults.Rows.Add(dtBestMatchAndOversize.Rows[0].ItemArray);
                dtResults.Rows[dtResults.Rows.Count - 1]["CondenserSelectionType"] = CondenserSelectionType.PerfectMatch;
                if (dtBestMatchAndOversize.Rows.Count > 1)
                {
                    //add over size
                    dtResults.Rows.Add(dtBestMatchAndOversize.Rows[1].ItemArray);
                    dtResults.Rows[dtResults.Rows.Count - 1]["CondenserSelectionType"] = CondenserSelectionType.Oversize;
                }
            }
            dtBestMatchAndOversize.Dispose();

            return dtResults;
        }

        //add the condenser model name
        private DataTable AddCondenserModelName(DataTable dtCondenserModel, DataTable dtCondenserModelCrossReference, string strAirFlowTypeFilter)
        {
            foreach (DataRow drCondenserModel in dtCondenserModel.Rows)
            {
                //select the model
                DataRow[] drModelName = dtCondenserModelCrossReference.Copy().Select("CondenserType ='" + drCondenserModel["CondenserType"] + "' AND Motor  ='" + drCondenserModel["Motor"] + "' AND CoilArr  ='" + drCondenserModel["CoilArr"] + "' AND FanWide  =" + drCondenserModel["FanWide"] + " AND FanLong  =" + drCondenserModel["FanLong"] + " AND Row  =" + drCondenserModel["Row"] + " AND FPI  =" + drCondenserModel["FPI"] + " AND AirFlow = '" + strAirFlowTypeFilter + "'");
                
                //if it found a model
                if (drModelName.Length > 0)
                {
                    drCondenserModel["CondenserModel"] = drModelName[0][UserInformation.CurrentSite + "_condenserXRefModel"].ToString();
                    drCondenserModel["CoilModel"] = drModelName[0]["CoilModel"].ToString();
                    drCondenserModel["CondenserPrice"] = Convert.ToInt32(drModelName[0]["Price"]);
                }
            }

            return RemoveNonExistingModels(dtCondenserModel);
        }

        //Remove Non Existing Models
        private DataTable RemoveNonExistingModels(DataTable dtCondenserModel)
        {
            //filter only existing reference
            DataRow[] drCondenserModel = dtCondenserModel.Select("CondenserModel <> ''");

            //clone table to be returned
            DataTable dtCondenserModelClone = dtCondenserModel.Clone();

            //for each result add it to the clone
            for (int intResult = 0; intResult < drCondenserModel.Length; intResult++)
            {
                dtCondenserModelClone.Rows.Add(drCondenserModel[intResult].ItemArray);
            }

            //added extra sorting
            dtCondenserModelClone = Public.SelectAndSortTable(dtCondenserModelClone, "", "CondenserSelectionType ASC");

            return dtCondenserModelClone;
        }

      


        //this function add a circuit
        public void AddCircuit(DataTable dtRefrigerantCircuits, DataTable dtStandardConnectionCondenserInlet, DataTable dtStandardConnectionCondenserOutlet, string strRefrigerantType, decimal decCondenserTemperature, decimal decTHR, decimal decRefrigerantCapacityMultiplier, decimal decAmbientTemperature, string circuitType, decimal decNonConvertedCapacity, string strCompressorType, decimal decSST)
        {
            if (decCondenserTemperature > decAmbientTemperature)
            {
                //create new row
                DataRow drRefrigerantCircuits = dtRefrigerantCircuits.NewRow();

                drRefrigerantCircuits["QuoteID"] = 0;
                drRefrigerantCircuits["QuoteRevision"] = 0;
                drRefrigerantCircuits["QuoteRevisionText"] = "";
                drRefrigerantCircuits["ItemType"] = 0;
                drRefrigerantCircuits["ItemID"] = 0;
                drRefrigerantCircuits["Username"] = "";

                //set new values
                drRefrigerantCircuits["RefrigerantType"] = strRefrigerantType;
                drRefrigerantCircuits["CondenserTemperature"] = decCondenserTemperature;
                drRefrigerantCircuits["THR"] = decTHR;
                drRefrigerantCircuits["RefrigerantMultiplier"] = decRefrigerantCapacityMultiplier;

                drRefrigerantCircuits["CircuitType"] = circuitType;
                drRefrigerantCircuits["NonConvertedTHR"] = decNonConvertedCapacity;
                drRefrigerantCircuits["CompressorType"] = strCompressorType;
                drRefrigerantCircuits["SST"] = decSST;

                drRefrigerantCircuits["AmbientTemperature"] = decAmbientTemperature;
                drRefrigerantCircuits["Calculated"] = 0m;
                drRefrigerantCircuits["Circ_Capacity"] = 0m;
                

                //2012-02-17 : #1846 : need to use THR to get connection size and since
                //the THR field had to be change and can contain NRE we cannon use it anymore, 
                //we need to use the non convertedTHR field now
                var qc = new QuickCoil.QuickCoilCode();
                drRefrigerantCircuits["Inlet"] = qc.GetConnectionSizeHRInlet(dtStandardConnectionCondenserInlet, decNonConvertedCapacity * decRefrigerantCapacityMultiplier, 100m, strRefrigerantType.ToUpper());
                drRefrigerantCircuits["Outlet"] = qc.GetConnectionSizeHROutlet(dtStandardConnectionCondenserOutlet, decNonConvertedCapacity * decRefrigerantCapacityMultiplier, 100m, strRefrigerantType.ToUpper());

                //add the row
                dtRefrigerantCircuits.Rows.Add(drRefrigerantCircuits);

                //dispose

                //recalculate all circuit values
                RecalculateCircuits(dtRefrigerantCircuits, decAmbientTemperature);
            }
            else
            {
                ThreadProcess.Stop();
               
                Public.LanguageBox("Could not create/balance circuit(s) !\nThe condensing temperature must always be greather than the ambient temperature.", "Impossible de créer/balancer le/les citcuit(s) !\nLa température de condensation doit toujours etre supérieure à la température ambiente.");
            }

        }

        public decimal GetLowestCondensingTemperature(DataTable dtRefrigerantCircuits)
        {
            decimal decLowestCT = 300m;

            //for each refrigerant circuits
            foreach (DataRow drRefrigerantCircuits in dtRefrigerantCircuits.Rows)
            {
                decLowestCT = Math.Min(Convert.ToDecimal(drRefrigerantCircuits["CondenserTemperature"]), decLowestCT);
            }

            return decLowestCT;
        }

        //recalculate all circuit values
        public void RecalculateCircuits(DataTable dtRefrigerantCircuits, decimal decAmbientTemperature)
        {
            //for each refrigerant circuits
            foreach (DataRow drRefrigerantCircuits in dtRefrigerantCircuits.Rows)
            {
                drRefrigerantCircuits["TD"] = Circuit_TD(Convert.ToDecimal(drRefrigerantCircuits["CondenserTemperature"]), decAmbientTemperature);
                drRefrigerantCircuits["AmbientTemperature"] = decAmbientTemperature;
                drRefrigerantCircuits["THR_PER_TD"] = Circuit_THR_PER_TD(Convert.ToDecimal(drRefrigerantCircuits["THR"]), Convert.ToDecimal(drRefrigerantCircuits["TD"]));
            }
        }

        public void RemoveCircuit(DataTable dtRefrigerantCircuits, int intRow, decimal decAmbientTemperature)
        {
            //remove the row
            dtRefrigerantCircuits.Rows.RemoveAt(intRow);

            //recalculate
            RecalculateCircuits(dtRefrigerantCircuits, decAmbientTemperature);
        }

        //this function build up 1 table out of the condenser row and refrigerant table
        //that is built in 1 dataset.
        //it is used to show up on the report so we need return a dataset object
        public DataSet GetSpecificationReportTable(DataRow drCondenserResultRow, DataTable dtRefrigrantCircuit)
        {
            //create a table that is a copy of refrigerant table. later ill add
            //the columns of the condenser to it
            DataTable dtRefrigerantCircuitCopy = dtRefrigrantCircuit.Copy();

            //now add all columns inside CondenserResult row to the copy table
            foreach (DataColumn dcCondenser in drCondenserResultRow.Table.Columns)
            {
                dtRefrigerantCircuitCopy.Columns.Add(new DataColumn(dcCondenser.ColumnName, dcCondenser.DataType));
            }

            //now for each row in the copy table add the condenser information to it.
            foreach (DataRow drRefrigerantCircuitCopy in dtRefrigerantCircuitCopy.Rows)
            {
                //for each column of the refrigerant that come from the condenser row
                //set it's value equal to the condenser row value
                //this will duplicate the condenser information on each 
                //refrigeranct circuit rows. It will allow me to put the
                //condenser info on the header of the report and the details will
                //automaticly repeat for the number of circuits
                foreach (DataColumn dcCondenser in drCondenserResultRow.Table.Columns)
                {
                    drRefrigerantCircuitCopy[dcCondenser.ColumnName] = drCondenserResultRow[dcCondenser.ColumnName];
                }
            }

            //change the name of the table to be sure we have something unique
            dtRefrigerantCircuitCopy.TableName = "DATA";

            //the dataset that will hold all informations
            var dsCondenserSpec = new DataSet("CondenserSpec");

            //add the table to it
            dsCondenserSpec.Tables.Add(dtRefrigerantCircuitCopy);

            ////write xsd
            //dsCondenserSpec.WriteXmlSchema("CondenserSpec.xsd");

            return dsCondenserSpec;
        }

        public decimal GetConvertedNRECapacityToTHR(DataTable dtCondenserNREHermeticFactor, DataTable dtCondenserNREOpenDriveFactor,decimal capacity, decimal condensingTemperature, decimal suctionTemperature, string compressorType)
        {
            decimal decCapacityNRE = -9999m;

            //2012-02-17 : #1485 : added rounding to no decimal to prevent such issue of not finding
            //when the user put stupidly decimal point condensing/suction temp
            DataTable dtSelection = Public.SelectAndSortTable((compressorType == "H" ? dtCondenserNREHermeticFactor : dtCondenserNREOpenDriveFactor), "CondensingTemp = " + Math.Round(condensingTemperature, 0) + " AND SuctionTemp = " + Math.Round(suctionTemperature, 0), "");

            if (dtSelection.Rows.Count > 0)
            {
                decCapacityNRE = capacity * Convert.ToDecimal(dtSelection.Rows[0]["Factor"]);
            }

            if (decCapacityNRE == -9999m)
            {
                Public.LanguageBox("No factor available to convert NRE into THR for these temperature.", "Aucun facteur de conversion de NRE à THR n'est disponible pour ces températures.");
            }

            return decCapacityNRE;

        }

    }
    
    //class for condenser selection Type (undersize,normal,oversize)
    class CondenserSelectionType
    {
        //Identification, these can be used to instanciate the class
        //or can be used to save the integer value instead.
        public const int Undersize = 1;
        public const int PerfectMatch = 2;
        public const int Oversize = 3;

        //colors
        public static Color ColorUndersize = Color.LightBlue;
        public static Color ColorPerfectMatch = Color.LightGreen;
        public static Color ColorOversize = Color.LightPink;

        //hold the object selected parameter
        private readonly int _identification;
        private Color _color = Color.White;
        private string _text = "";

        //constructor, we pass the condenser selection type so the object
        //set his parameter
        public CondenserSelectionType(int intCondenserSelectionType)
        {
            //first it load up the type
            _identification = intCondenserSelectionType;

            //set the color attributed to the type
            SetColor();

            //set the text attributed to the type
            SetText();
        }

        //return the type
        public int Identification
        {
            get { return _identification; }
        }

        //return the color
        public Color Color
        {
            get { return _color; }
        }

        //return the text
        public string Text
        {
            get { return _text; }
        }

        //set the color attributed to the type
        private void SetColor()
        {
            if (_identification == Undersize)
            {
                _color = ColorUndersize;
            }
            else if (_identification == PerfectMatch)
            {
                _color = ColorPerfectMatch;
            }
            else if (_identification == Oversize)
            {
                _color = ColorOversize;
            }
            else
            {
                _color = Color.White;
            }
        }

        //set the text attributed to the type
        private void SetText()
        {
            if (_identification == Undersize)
            {
                _text = "Undersize";
            }
            else if (_identification == PerfectMatch)
            {
                _text = "Best Match";
            }
            else if (_identification == Oversize)
            {
                _text = "Oversize";
            }
            else
            {
                _text = "";
            }
        }
    }
}
