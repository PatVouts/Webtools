using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using System.Data;

namespace RefplusWebtools.QuickWaterEvaporator
{
    class QuickWaterEvaporatorCode
    {
        /// <summary>
        /// fill the fin material according to the coil of the evap model
        /// </summary>
        /// <param name="cboFinMaterial"></param>
        /// <param name="cboModel"></param>
        /// <param name="cboFPI"></param>
        /// <param name="dtvEvaporators"></param>
        /// <param name="dtCoilFinType"></param>
        /// <param name="dtCoilFinMaterial"></param>
        /// <param name="dtvCoilFinDefaults"></param>
        public void FillFinMaterial(ComboBox cboFinMaterial, ComboBox cboModel, ComboBox cboFPI, DataTable dtvEvaporators, DataTable dtCoilFinType, DataTable dtCoilFinMaterial, DataTable dtvCoilFinDefaults)
        {
            cboFinMaterial.Items.Clear();

            if (cboFPI.SelectedIndex >= 0)
            {
                DataTable dtModelInfo = GetModelInfoByModel(cboModel, dtvEvaporators);

                string finType = "";
                string finShape = "";
                decimal finHeight = 0m;
                decimal finLength = 0m;
                int rows = 0;

                StripCoilModel(ref finType, ref finShape, ref finHeight, ref finLength, ref rows, dtModelInfo, dtCoilFinType);

                foreach (DataRow drFinMaterial in dtCoilFinMaterial.Rows)
                {
                    if (IsFinMaterialAvailable(dtvCoilFinDefaults, finType, finShape, Convert.ToInt32(ComboBoxControl.IndexInformation(cboFPI)), drFinMaterial["UniqueID"].ToString()))
                    {
                        string strIndex = drFinMaterial["UniqueID"].ToString();
                        string strText = drFinMaterial["FinMaterial"].ToString();
                        ComboBoxControl.AddItem(cboFinMaterial, strIndex, strText);
                    }
                }

                if (cboFinMaterial.Items.Count > 0)
                {
                    cboFinMaterial.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// return the fin material parameter
        /// </summary>
        /// <param name="cboFinMaterial"></param>
        /// <param name="dtCoilFinMaterial"></param>
        /// <returns></returns>
        private static string GetFinMaterialParameter(ComboBox cboFinMaterial, DataTable dtCoilFinMaterial)
        {
            return ComboBoxControl.ItemInformations(cboFinMaterial, dtCoilFinMaterial, "UniqueID")[0]["FinMaterialParameter"].ToString();
        }

        /// <summary>
        /// tell if the fin material available for that coil
        /// </summary>
        /// <param name="dtvCoilFinDefaults"></param>
        /// <param name="strFinType"></param>
        /// <param name="strFinShape"></param>
        /// <param name="intFPI"></param>
        /// <param name="strFinMaterial"></param>
        /// <returns></returns>
        private bool IsFinMaterialAvailable(DataTable dtvCoilFinDefaults, string strFinType, string strFinShape, int intFPI, string strFinMaterial)
        {
            //check is the fin material is available for the specific conditions
            if (dtvCoilFinDefaults.Select("FinType = '" + strFinType + "' AND FinShape = '" + strFinShape + "' AND FPI_MIN <= " + intFPI + " AND FPI_MAX >= " + intFPI + " AND FinMaterialID = " + strFinMaterial).Length > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// validate the inputs of the user
        /// </summary>
        /// <param name="cboFluidType"></param>
        /// <param name="numConcentration"></param>
        /// <param name="numEDB"></param>
        /// <param name="numEWB"></param>
        /// <param name="numELT"></param>
        /// <param name="cboGPMLLT"></param>
        /// <param name="numLLT"></param>
        /// <param name="dtCoilFluidType"></param>
        /// <param name="dtFreezingPointEthylene"></param>
        /// <param name="dtFreezingPointPropylene"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        private bool ValidateInputs(ComboBox cboFluidType, NumericUpDown numConcentration, NumericUpDown numEDB, NumericUpDown numEWB, NumericUpDown numELT, ComboBox cboGPMLLT, NumericUpDown numLLT, DataTable dtCoilFluidType, DataTable dtFreezingPointEthylene, DataTable dtFreezingPointPropylene, ref string errorMessage)
        {
            bool bolReturnValue = true;

            decimal decMinEDBEWB = 0m;
            decimal decMaxEDBEWB = 0m;
            decimal decFreezingPoint = 0m;

            switch (GetFluidTypeParameter(cboFluidType, dtCoilFluidType))
            {
                case "WTR":
                    decFreezingPoint = 34m;
                    decMinEDBEWB = 44m;
                    decMaxEDBEWB = 350m;
                    break;
                case "EG":
                    decFreezingPoint = GetFreezingPoint(dtFreezingPointEthylene, Convert.ToInt32(numConcentration.Value));
                    decMinEDBEWB = decFreezingPoint + 10m;
                    decMaxEDBEWB = 350m;
                    break;
                case "PG":
                    decFreezingPoint = GetFreezingPoint(dtFreezingPointPropylene, Convert.ToInt32(numConcentration.Value));
                    decMinEDBEWB = decFreezingPoint + 10m;
                    decMaxEDBEWB = 350m;
                    break;
            }
            //validations
            if (numEDB.Value < decMinEDBEWB || numEDB.Value > decMaxEDBEWB)
            {
                bolReturnValue = false;
                errorMessage = Public.LanguageString("EDB must be between " + decMinEDBEWB + " and " + decMaxEDBEWB, "EDB doit être entre " + decMinEDBEWB + " et " + decMaxEDBEWB);
            }
            else if (numELT.Value > numEDB.Value - 1m || numELT.Value < decFreezingPoint)
            {
                bolReturnValue = false;
                errorMessage = Public.LanguageString("ELT must be between " + decFreezingPoint + " and " + Convert.ToDecimal(numEDB.Value - 1m), "ELT doit être entre " + decFreezingPoint + " et " + Convert.ToDecimal(numEDB.Value - 1m));
            }
            else if (numEWB.Value > numEDB.Value)
            {
                bolReturnValue = false;
                errorMessage = Public.LanguageString("EWB must be smaller or equal to EDB", "EWB doit être plus petit ou égal à l'EDB");
            }
            else if (cboGPMLLT.Text != @"USGPM" && numLLT.Value < numELT.Value)
            {
                bolReturnValue = false;
                errorMessage = Public.LanguageString("LLT must be bigger or equal to ELT", "LTL doit être plus grand ou égal à l'ELT");
            }
            else if (cboGPMLLT.Text != @"USGPM" && numLLT.Value >= numEDB.Value)
            {
                bolReturnValue = false;
                errorMessage = Public.LanguageString("LLT must be smaller than EDB", "LLT doit être plus petit que l'EDB");
            }

            return bolReturnValue;
        }

        /// <summary>
        /// get the freezing piont of the fluid used
        /// </summary>
        /// <param name="dtFluidFreezingPointTable"></param>
        /// <param name="intConcentration"></param>
        /// <returns></returns>
        public decimal GetFreezingPoint(DataTable dtFluidFreezingPointTable, int intConcentration)
        {
            return Convert.ToDecimal(dtFluidFreezingPointTable.Select("Concentration = " + intConcentration)[0]["FreezingPoint"]);
        }

        /// <summary>
        /// accept sequence to save
        /// </summary>
        /// <param name="quoteform"></param>
        /// <param name="dsQuoteData"></param>
        /// <param name="bolQuoteSelection"></param>
        /// <param name="intIndex"></param>
        /// <param name="coolingCoil"></param>
        /// <param name="txtTag"></param>
        /// <param name="numQuantity"></param>
        /// <param name="cboModel"></param>
        /// <param name="cboVoltage"></param>
        /// <param name="numEDB"></param>
        /// <param name="numEWB"></param>
        /// <param name="numAltitude"></param>
        /// <param name="cboFluidType"></param>
        /// <param name="numConcentration"></param>
        /// <param name="numELT"></param>
        /// <param name="cboGPMLLT"></param>
        /// <param name="numGPM"></param>
        /// <param name="numLLT"></param>
        /// <param name="cboNumberOfCircuits"></param>
        /// <param name="cboFPI"></param>
        /// <param name="cboFinMaterial"></param>
        /// <param name="cboCoating"></param>
        /// <param name="dtvEvaporators"></param>
        /// <param name="dtCoilFinMaterial"></param>
        /// <param name="dtCoilCasingMaterial"></param>
        /// <param name="dtCoilTubeMaterial"></param>
        /// <param name="dtvCoilFinDefaults"></param>
        /// <param name="dtFuseSize"></param>
        /// <param name="dtEvaporatorDrawingManager" />
        /// <param name="closeFormOnSuccess"></param>
        /// <returns></returns>
        public bool Accept(Quotes.FrmQuotes quoteform, DataSet dsQuoteData, bool bolQuoteSelection, int intIndex, Coil.CoolingCoil coolingCoil, TextBox txtTag, NumericUpDown numQuantity, ComboBox cboModel, ComboBox cboVoltage, NumericUpDown numEDB, NumericUpDown numEWB, NumericUpDown numAltitude, ComboBox cboFluidType, NumericUpDown numConcentration, NumericUpDown numELT, ComboBox cboGPMLLT, NumericUpDown numGPM, NumericUpDown numLLT, ComboBox cboNumberOfCircuits, ComboBox cboFPI, ComboBox cboFinMaterial, ComboBox cboCoating, DataTable dtvEvaporators, DataTable dtCoilFinMaterial, DataTable dtCoilCasingMaterial, DataTable dtCoilTubeMaterial, DataTable dtvCoilFinDefaults, DataTable dtFuseSize, DataTable dtEvaporatorDrawingManager, ref bool closeFormOnSuccess)
        {
            bool acceptSuccess = false;

            if (coolingCoil.IsValid)
            {
                if (SelectCoating(cboCoating))
                {
                    DataTable dtOptions = null;

                    if (SelectOptions(dsQuoteData, bolQuoteSelection, intIndex, cboModel, ref dtOptions, dtvEvaporators))
                    {
                        if (SaveData(quoteform, dsQuoteData, bolQuoteSelection, intIndex, coolingCoil, txtTag, numQuantity, cboModel, cboVoltage, numEDB, numEWB, numAltitude, cboFluidType, numConcentration, numELT, cboGPMLLT, numGPM, numLLT, cboNumberOfCircuits, cboFPI, cboFinMaterial, cboCoating, dtOptions, dtvEvaporators, dtCoilFinMaterial, dtCoilCasingMaterial, dtCoilTubeMaterial, dtvCoilFinDefaults, dtFuseSize, dtEvaporatorDrawingManager, ref closeFormOnSuccess))
                        {
                            acceptSuccess = true;
                        }
                    }
                }
            }

            return acceptSuccess;
        }

        /// <summary>
        /// select the options of the evap
        /// </summary>
        /// <param name="dsQuoteData"></param>
        /// <param name="bolQuoteSelection"></param>
        /// <param name="intIndex"></param>
        /// <param name="cboModel"></param>
        /// <param name="dtOptions"></param>
        /// <param name="dtvEvaporators"></param>
        /// <returns></returns>
        private bool SelectOptions(DataSet dsQuoteData, bool bolQuoteSelection, int intIndex, ComboBox cboModel, ref DataTable dtOptions, DataTable dtvEvaporators)
        {

            string strModel = ComboBoxControl.IndexInformation(cboModel);
            DataTable dtModelInfo = GetModelInfoByModel(cboModel, dtvEvaporators);

            var options = new FrmWaterEvaporatorOption(
                bolQuoteSelection,
                strModel.Substring(0, 1),
                strModel.Substring(1, 1),
                strModel.Substring(2, 1),
              Convert.ToDecimal(dtModelInfo.Rows[0]["CapacityAt10TD"]),
                 dtModelInfo.Rows[0]["VoltageID"].ToString(),
                dsQuoteData,
                intIndex);

            if (options.ShowDialog() == DialogResult.OK)
            {
                dtOptions = options.OptionInput;
                return true;
            }

            return false;
        }

        /// <summary>
        ///  get the table with data to save.
        /// </summary>
        /// <param name="coolingCoil"></param>
        /// <param name="txtTag"></param>
        /// <param name="numQuantity"></param>
        /// <param name="cboModel"></param>
        /// <param name="cboVoltage"></param>
        /// <param name="numEDB"></param>
        /// <param name="numEWB"></param>
        /// <param name="numAltitude"></param>
        /// <param name="cboFluidType"></param>
        /// <param name="numConcentration"></param>
        /// <param name="numELT"></param>
        /// <param name="cboGPMLLT"></param>
        /// <param name="numGPM"></param>
        /// <param name="numLLT"></param>
        /// <param name="cboNumberOfCircuits"></param>
        /// <param name="cboFPI"></param>
        /// <param name="cboFinMaterial"></param>
        /// <param name="cboCoating"></param>
        /// <param name="dtvEvaporators"></param>
        /// <param name="dtCoilFinMaterial"></param>
        /// <param name="dtCoilCasingMaterial"></param>
        /// <param name="dtCoilTubeMaterial"></param>
        /// <param name="dtvCoilFinDefaults"></param>
        /// <param name="dtFuseSize"></param>
        /// <param name="dtEvaporatorDrawingManager"></param>
        /// <returns></returns>
        private DataTable GetSaveTable(Coil.CoolingCoil coolingCoil, TextBox txtTag, NumericUpDown numQuantity, ComboBox cboModel, ComboBox cboVoltage, NumericUpDown numEDB, NumericUpDown numEWB, NumericUpDown numAltitude, ComboBox cboFluidType, NumericUpDown numConcentration, NumericUpDown numELT, ComboBox cboGPMLLT, NumericUpDown numGPM, NumericUpDown numLLT, ComboBox cboNumberOfCircuits, ComboBox cboFPI, ComboBox cboFinMaterial, ComboBox cboCoating, DataTable dtvEvaporators, DataTable dtCoilFinMaterial, DataTable dtCoilCasingMaterial, DataTable dtCoilTubeMaterial, DataTable dtvCoilFinDefaults, DataTable dtFuseSize, DataTable dtEvaporatorDrawingManager)
        {
            DataTable dtSaveTable = Tables.DtQuickWaterEvaporator();

            DataRow drSaveTable = dtSaveTable.NewRow();
            //header
            drSaveTable["QuoteID"] = 0;
            drSaveTable["QuoteRevision"] = 0;
            drSaveTable["QuoteRevisionText"] = "";
            drSaveTable["ItemType"] = Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.WaterEvaporator);
            drSaveTable["ItemID"] = 0;
            drSaveTable["Username"] = "";

            drSaveTable["Tag"] = txtTag.Text;
            drSaveTable["Quantity"] = Convert.ToInt32(numQuantity.Value);
            drSaveTable["EvaporatorID"] = ComboBoxControl.IndexInformation(cboModel);
            drSaveTable["Input_VoltageID"] = ComboBoxControl.IndexInformation(cboVoltage);
            drSaveTable["Input_VoltDescription"] = cboVoltage.Text;
            drSaveTable["Input_EDB"] = numEDB.Value;
            drSaveTable["Input_EWB"] = numEWB.Value;
            drSaveTable["Input_Altitude"] = numAltitude.Value;
            drSaveTable["Input_FluidTypeID"] = ComboBoxControl.IndexInformation(cboFluidType);
            drSaveTable["Input_FluidType"] = cboFluidType.Text;
            drSaveTable["Input_Concentration"] = numConcentration.Value;
            drSaveTable["Input_EnteringLiquidTemperature"] = numELT.Value;
            drSaveTable["Input_GPM_LLT"] = cboGPMLLT.Text;
            drSaveTable["Input_GPM"] = numGPM.Value;
            drSaveTable["Input_LeavingLiquidTemperature"] = numLLT.Value;
            drSaveTable["Input_NumberOfCircuits"] = cboNumberOfCircuits.Text;
            drSaveTable["Input_FPI"] = Convert.ToDecimal(cboFPI.Text);
            drSaveTable["Input_FinMaterialID"] = ComboBoxControl.IndexInformation(cboFinMaterial);
            drSaveTable["Input_FinMaterialText"] = cboFinMaterial.Text;
            drSaveTable["Input_CoilCoatingID"] = ComboBoxControl.IndexInformation(cboCoating);
            drSaveTable["Input_CoilCoatingText"] = cboCoating.Text;

            DataTable dtModelInfo = GetModelInfoByModelSpecificVoltage(cboModel, cboVoltage, dtvEvaporators);

            drSaveTable["CapacityAt10TD"] = Convert.ToDecimal(dtModelInfo.Rows[0]["CapacityAt10TD"]);
            drSaveTable["EvaporatorWeight"] = Convert.ToDecimal(dtModelInfo.Rows[0]["EvaporatorWeight"]);
            drSaveTable["EvaporatorCoilQty"] = Convert.ToDecimal(dtModelInfo.Rows[0]["EvaporatorCoilQty"]);
            drSaveTable["EvaporatorFanQty"] = Convert.ToDecimal(dtModelInfo.Rows[0]["EvaporatorFanQty"]);
            drSaveTable["EvaporatorHeaterQTY"] = Convert.ToDecimal(dtModelInfo.Rows[0]["EvaporatorHeaterQTY"]);
            drSaveTable["EvaporatorCFM"] = Convert.ToDecimal(dtModelInfo.Rows[0]["EvaporatorCFM"]);
            drSaveTable["EvaporatorPrice"] = Convert.ToDecimal(dtModelInfo.Rows[0]["EvaporatorPrice"]);
            drSaveTable["FanArrangement"] = Convert.ToDecimal(dtModelInfo.Rows[0]["FanArrangement"]);
            drSaveTable["DefrostTypeID"] = dtModelInfo.Rows[0]["DefrostTypeID"].ToString();
            drSaveTable["DefrostTypeDescription"] = dtModelInfo.Rows[0]["DefrostTypeDescription"].ToString();

            drSaveTable["VoltsValue"] = Convert.ToDecimal(dtModelInfo.Rows[0]["VoltsValue"]);
            drSaveTable["PhaseNumber"] = Convert.ToDecimal(dtModelInfo.Rows[0]["PhaseNumber"]);
            drSaveTable["WattMultiplier"] = Convert.ToDecimal(dtModelInfo.Rows[0]["WattMultiplier"]);
            drSaveTable["HeaterFLAMultiplier"] = Convert.ToDecimal(dtModelInfo.Rows[0]["HeaterFLAMultiplier"]);

            drSaveTable["Motor"] = dtModelInfo.Rows[0]["Motor"].ToString();
            drSaveTable["MotorHP"] = Convert.ToDecimal(dtModelInfo.Rows[0]["MotorHP"]);
            drSaveTable["MotorRPM"] = Convert.ToDecimal(dtModelInfo.Rows[0]["MotorRPM"]);
            drSaveTable["MotorRotType"] = dtModelInfo.Rows[0]["MotorRotType"].ToString();
            drSaveTable["MotorFrameType"] = dtModelInfo.Rows[0]["MotorFrameType"].ToString();
            drSaveTable["MotorShaftLength"] = Convert.ToDecimal(dtModelInfo.Rows[0]["MotorShaftLength"]);
            drSaveTable["MotorPrice"] = Convert.ToDecimal(dtModelInfo.Rows[0]["MotorPrice"]);
            drSaveTable["MotorFLA"] = Convert.ToDecimal(dtModelInfo.Rows[0]["MotorFLA"]);

            drSaveTable["MotorMount"] = dtModelInfo.Rows[0]["MotorMount"].ToString();
            drSaveTable["MotorMountFanSize"] = Convert.ToDecimal(dtModelInfo.Rows[0]["MotorMountFanSize"]);
            drSaveTable["MotorMountFrameSize"] = Convert.ToDecimal(dtModelInfo.Rows[0]["MotorMountFrameSize"]);
            drSaveTable["MotorMountComposition"] = dtModelInfo.Rows[0]["MotorMountComposition"].ToString();
            drSaveTable["MotorMountPrice"] = Convert.ToDecimal(dtModelInfo.Rows[0]["MotorMountPrice"]);

            drSaveTable["Fan"] = dtModelInfo.Rows[0]["Fan"].ToString();
            drSaveTable["FanDiameter"] = Convert.ToDecimal(dtModelInfo.Rows[0]["FanDiameter"]);
            drSaveTable["FanBladeQuantity"] = Convert.ToInt32(dtModelInfo.Rows[0]["FanBladeQuantity"]);
            drSaveTable["FanRotationType"] = dtModelInfo.Rows[0]["FanRotationType"].ToString();
            drSaveTable["FanComposition"] = dtModelInfo.Rows[0]["FanComposition"].ToString();
            drSaveTable["FanPitch"] = Convert.ToDecimal(dtModelInfo.Rows[0]["FanPitch"]);
            drSaveTable["FanPrice"] = Convert.ToDecimal(dtModelInfo.Rows[0]["FanPrice"]);

            drSaveTable["FanGuard"] = dtModelInfo.Rows[0]["FanGuard"].ToString();
            drSaveTable["FanGuardFanSize"] = Convert.ToDecimal(dtModelInfo.Rows[0]["FanGuardFanSize"]);
            drSaveTable["FanGuardComposition"] = dtModelInfo.Rows[0]["FanGuardComposition"].ToString();

            drSaveTable["DefrostHeater"] = dtModelInfo.Rows[0]["DefrostHeater"].ToString();
            drSaveTable["DefrostHeaterType"] = dtModelInfo.Rows[0]["DefrostHeaterType"].ToString();
            drSaveTable["DefrostHeaterVolt"] = Convert.ToInt32(dtModelInfo.Rows[0]["DefrostHeaterVolt"]);
            drSaveTable["DefrostHeaterWatt"] = Convert.ToInt32(dtModelInfo.Rows[0]["DefrostHeaterWatt"]);
            drSaveTable["DefrostHeaterDesc"] = dtModelInfo.Rows[0]["DefrostHeaterDesc"].ToString();
            drSaveTable["DefrostHeaterPrice"] = Convert.ToDecimal(dtModelInfo.Rows[0]["DefrostHeaterPrice"]);
            drSaveTable["DefrostHeaterKilowatts"] = GetElectricHeaterKilowatts(Convert.ToInt32(drSaveTable["EvaporatorHeaterQty"]), Convert.ToDecimal(drSaveTable["DefrostHeaterWatt"]), Convert.ToDecimal(drSaveTable["WattMultiplier"]));

            drSaveTable["FinType"] = coolingCoil.FinType;
            drSaveTable["FinShape"] = coolingCoil.FinShape;
            drSaveTable["FinHeight"] = coolingCoil.CoilHeight;
            drSaveTable["FinLength"] = coolingCoil.CoilLength;
            drSaveTable["Row"] = coolingCoil.NumberOfRows;

            drSaveTable["CoilFaceArea"] = coolingCoil.CoilFaceArea;
            drSaveTable["FaceVelocity"] = coolingCoil.FaceVelocity;
            drSaveTable["AirPressureDrop"] = coolingCoil.AirPressureDrop;
            drSaveTable["LeavingDryBulb"] = coolingCoil.LeavingDryBulb;
            drSaveTable["LeavingWetBulb"] = coolingCoil.LeavingWetBulb;
            drSaveTable["TotalHeat"] = coolingCoil.TotalHeat;
            drSaveTable["SensibleHeat"] = coolingCoil.SensibleHeat;
            drSaveTable["LeavingLiquidTemperature"] = coolingCoil.LeavingLiquidTemperature;
            drSaveTable["RefrigerantPressureDrop"] = coolingCoil.RefrigerantPressureDrop;
            drSaveTable["GPM"] = coolingCoil.GPM;
            drSaveTable["WaterVelocity"] = coolingCoil.WaterVelocity;

            drSaveTable["MotorMCA"] = GetMotorMCA(Convert.ToInt32(drSaveTable["EvaporatorFanQty"]), Convert.ToDecimal(drSaveTable["MotorFLA"]));
            drSaveTable["MotorMOP"] = GetMotorMOP(Convert.ToInt32(drSaveTable["EvaporatorFanQty"]), Convert.ToDecimal(drSaveTable["MotorFLA"]));
            drSaveTable["MotorFUSE"] = GetMotorFuseSize(dtFuseSize, Convert.ToDecimal(drSaveTable["MotorMCA"]), Convert.ToDecimal(drSaveTable["MotorMOP"]));

            drSaveTable["HeaterFLA"] = GetElectricHeaterFLA(Convert.ToInt32(drSaveTable["EvaporatorHeaterQty"]), Convert.ToDecimal(drSaveTable["DefrostHeaterWatt"]), Convert.ToInt32(drSaveTable["VoltsValue"]), Convert.ToInt32(drSaveTable["PhaseNumber"]));
            drSaveTable["HeaterMCA"] = GetHeaterMCA(Convert.ToDecimal(drSaveTable["HeaterFLA"]));
            drSaveTable["HeaterFUSE"] = GetHeaterFuseSize(dtFuseSize, Convert.ToDecimal(drSaveTable["HeaterMCA"]));

            drSaveTable["FinMaterialPrice"] = GetFinMaterialPrice(coolingCoil.FinType, coolingCoil.FinShape, Convert.ToInt32(coolingCoil.FinsPerInch), Convert.ToDecimal(coolingCoil.NumberOfRows), Convert.ToDecimal(coolingCoil.CoilHeight), Convert.ToDecimal(coolingCoil.CoilLength), drSaveTable["Input_FinMaterialText"].ToString(), dtCoilFinMaterial, dtCoilCasingMaterial, dtCoilTubeMaterial, dtvCoilFinDefaults);
            drSaveTable["CoilCoatingPrice"] = GetCoilCoatingPrice(cboCoating, Convert.ToDecimal(coolingCoil.NumberOfRows), Convert.ToDecimal(coolingCoil.FinsPerInch), Convert.ToDecimal(coolingCoil.CoilHeight), Convert.ToDecimal(coolingCoil.CoilLength), Convert.ToDecimal(dtModelInfo.Rows[0]["BlygoldPrice"]));

            //2012-05-23 : #1355 : adding dwg name to all reports
            string strSerie = drSaveTable["EvaporatorID"].ToString().Substring(0, 1) +
                              drSaveTable["EvaporatorID"].ToString().Substring(1, 1) +
                              drSaveTable["EvaporatorID"].ToString().Substring(2, 1);

            string strDrawingName = DrawingManager.GetDrawingName_Evaporator(
                 dtEvaporatorDrawingManager,
                 strSerie,
                 Convert.ToDecimal(drSaveTable["CapacityAt10TD"]),
                 drSaveTable["Input_VoltageID"].ToString());

            drSaveTable["ApprovalDrawing"] = strDrawingName;

            drSaveTable["Description"] = "Water Evaporator : " + drSaveTable["EvaporatorID"] + "-" + drSaveTable["Input_VoltageID"] + "-W"
                + Environment.NewLine + drSaveTable["Input_VoltDescription"]
                + Environment.NewLine + Convert.ToDecimal(Convert.ToDecimal(coolingCoil.TotalHeat) * Convert.ToDecimal(drSaveTable["EvaporatorCoilQty"])).ToString("N0") + " BTU/H";

            dtSaveTable.Rows.Add(drSaveTable);

            return dtSaveTable;
        }

        /// <summary>
        /// get teh heater killowatts
        /// </summary>
        /// <param name="heaterQuantity"></param>
        /// <param name="heaterWatts"></param>
        /// <param name="wattsMultiplier"></param>
        /// <returns></returns>
        private decimal GetElectricHeaterKilowatts(int heaterQuantity, decimal heaterWatts, decimal wattsMultiplier)
        {
            return (heaterQuantity * heaterWatts * wattsMultiplier) / 1000m;
        }

        /// <summary>
        /// get electric heater fla
        /// </summary>
        /// <param name="heaterQuantity"></param>
        /// <param name="heaterWatts"></param>
        /// <param name="volts"></param>
        /// <param name="phase"></param>
        /// <returns></returns>
        private decimal GetElectricHeaterFLA(int heaterQuantity, decimal heaterWatts, int volts, int phase)
        {
            return (heaterQuantity * heaterWatts) / ((decimal)Math.Sqrt(phase) * volts);
        }

        /// <summary>
        /// get the motor fla
        /// </summary>
        /// <param name="fanQuantity"></param>
        /// <param name="motorFLA"></param>
        /// <returns></returns>
        private decimal GetMotorMCA(int fanQuantity, decimal motorFLA)
        {
            decimal decMCA = (1.25m * motorFLA) + ((fanQuantity - 1m) * motorFLA);

            return decMCA;
        }

        /// <summary>
        /// get the heater mca
        /// </summary>
        /// <param name="heaterFLA"></param>
        /// <returns></returns>
        private decimal GetHeaterMCA(decimal heaterFLA)
        {
            decimal decMCA = (1.25m * heaterFLA);

            return decMCA;
        }

        /// <summary>
        /// get motor mop
        /// </summary>
        /// <param name="fanQuantity"></param>
        /// <param name="motorFLA"></param>
        /// <returns></returns>
        private decimal GetMotorMOP(int fanQuantity, decimal motorFLA)
        {
            decimal decMOP = (2.25m * motorFLA) + ((fanQuantity - 1m) * motorFLA);

            return decMOP;
        }

        /// <summary>
        /// get the motor fuse size
        /// </summary>
        /// <param name="dtFuseSize"></param>
        /// <param name="mca"></param>
        /// <param name="mop"></param>
        /// <returns></returns>
        private decimal GetMotorFuseSize(DataTable dtFuseSize, decimal mca, decimal mop)
        {
            DataTable dtSelectedMCAFuse = Public.SelectAndSortTable(dtFuseSize, "FuseSize > " + mca, "FuseSize ASC");
            DataTable dtSelectedMOPFuse = Public.SelectAndSortTable(dtFuseSize, "FuseSize < " + mop + " OR FuseSize = 15", "FuseSize DESC");

            decimal decFuse = Convert.ToDecimal(Convert.ToDecimal(dtSelectedMOPFuse.Rows[0]["FuseSize"]) <= mca ? dtSelectedMCAFuse.Rows[0]["FuseSize"] : dtSelectedMOPFuse.Rows[0]["FuseSize"]);


            return decFuse;
        }

        /// <summary>
        /// get the heater use size
        /// </summary>
        /// <param name="dtFuseSize"></param>
        /// <param name="mca"></param>
        /// <returns></returns>
        private decimal GetHeaterFuseSize(DataTable dtFuseSize, decimal mca)
        {
            DataTable dtSelectedFuse = Public.SelectAndSortTable(dtFuseSize, "FuseSize * 0.8 >= " + mca, "FuseSize ASC");

            return Convert.ToDecimal(dtSelectedFuse.Rows[0]["FuseSize"]);
        }

        /// <summary>
        /// get the price of the fin material
        /// </summary>
        /// <param name="strFinType"></param>
        /// <param name="strFinShape"></param>
        /// <param name="intFPI"></param>
        /// <param name="decRows"></param>
        /// <param name="decFinHeight"></param>
        /// <param name="decFinLength"></param>
        /// <param name="strFinMaterial"></param>
        /// <param name="dtCoilFinMaterial"></param>
        /// <param name="dtCoilCasingMaterial"></param>
        /// <param name="dtCoilTubeMaterial"></param>
        /// <param name="dtvCoilFinDefaults"></param>
        /// <returns></returns>
        private decimal GetFinMaterialPrice(string strFinType, string strFinShape, int intFPI, decimal decRows, decimal decFinHeight, decimal decFinLength, string strFinMaterial, DataTable dtCoilFinMaterial, DataTable dtCoilCasingMaterial, DataTable dtCoilTubeMaterial, DataTable dtvCoilFinDefaults)
        {
            //Get Price of Standard Coil Without Anything
            var sc = new Pricing.StandardCoil(
            strFinType,
            2m,
            decRows,
            intFPI,
            decFinHeight,
            decFinLength,
            0.5m,
            Convert.ToDecimal("0" + GetFinThicknessDefault(strFinType, strFinShape, intFPI, "1", dtvCoilFinDefaults)),
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
                intFPI,
                decFinHeight,
                decFinLength,
                0.5m,
                Convert.ToDecimal("0" + GetFinThicknessDefault(strFinType, strFinShape, intFPI, Public.SelectAndSortTable(dtCoilFinMaterial, "FinMaterial = '" + strFinMaterial + "'", "").Rows[0]["UniqueID"].ToString(), dtvCoilFinDefaults)),
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

        /// <summary>
        /// get the coating price of the coil
        /// </summary>
        /// <param name="cboCoilCoating"></param>
        /// <param name="rows"></param>
        /// <param name="fpi"></param>
        /// <param name="finHeight"></param>
        /// <param name="finLength"></param>
        /// <param name="blygoldPrice"></param>
        /// <returns></returns>
        private decimal GetCoilCoatingPrice(ComboBox cboCoilCoating, decimal rows, decimal fpi, decimal finHeight, decimal finLength, decimal blygoldPrice)
        {
            decimal decCoatingPrice = 0m;

            switch (cboCoilCoating.Text)
            {
                case "Blygold":
                    //set value
                    decCoatingPrice = blygoldPrice;

                    break;
                case "ElectroFin":
                    var electroFinCoating = new Pricing.ElectroFinCoating(1m, rows, fpi, finHeight, finLength);

                    //set value
                    decCoatingPrice = electroFinCoating.Price;

                    //dispose

                    break;
                case "Heresite":
                    var heresiteCoating = new Pricing.HeresiteCoating(1m, rows, finHeight, finLength);

                    //set value
                    decCoatingPrice = heresiteCoating.Price;

                    //dispose

                    break;
            }

            return decCoatingPrice;
        }

        /// <summary>
        /// load the form with what was previously selected
        /// </summary>
        /// <param name="dsQuoteData"></param>
        /// <param name="intIndex"></param>
        /// <param name="txtTag"></param>
        /// <param name="numQuantity"></param>
        /// <param name="cboModel"></param>
        /// <param name="cboVoltage"></param>
        /// <param name="numEDB"></param>
        /// <param name="numEWB"></param>
        /// <param name="numAltitude"></param>
        /// <param name="cboFluidType"></param>
        /// <param name="numConcentration"></param>
        /// <param name="numELT"></param>
        /// <param name="cboGPMLLT"></param>
        /// <param name="numGPM"></param>
        /// <param name="numLLT"></param>
        /// <param name="cboNumberOfCircuits"></param>
        /// <param name="cboFPI"></param>
        /// <param name="cboFinMaterial"></param>
        /// <param name="cboCoating"></param>
        /// <returns></returns>
        public void LoadData(DataSet dsQuoteData, int intIndex, TextBox txtTag, NumericUpDown numQuantity, ComboBox cboModel, ComboBox cboVoltage, NumericUpDown numEDB, NumericUpDown numEWB, NumericUpDown numAltitude, ComboBox cboFluidType, NumericUpDown numConcentration, NumericUpDown numELT, ComboBox cboGPMLLT, NumericUpDown numGPM, NumericUpDown numLLT, ComboBox cboNumberOfCircuits, ComboBox cboFPI, ComboBox cboFinMaterial, ComboBox cboCoating)
        {
            DataTable dtSavedInfo = Public.SelectAndSortTable(dsQuoteData.Tables["QuickWaterEvaporator"], "ItemType = " + Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.WaterEvaporator) + " AND ItemID = " + intIndex, "");
            DataRow drSavedInfo = dtSavedInfo.NewRow();
            drSavedInfo.ItemArray = dtSavedInfo.Rows[0].ItemArray;

            txtTag.Text = drSavedInfo["Tag"].ToString();

            numQuantity.Value = Convert.ToDecimal(drSavedInfo["Quantity"]);

            ComboBoxControl.SetIDDefaultValue(cboModel, drSavedInfo["EvaporatorID"].ToString());

            ComboBoxControl.SetIDDefaultValue(cboVoltage, drSavedInfo["Input_VoltageID"].ToString());

            numEDB.Value = Convert.ToDecimal(drSavedInfo["Input_EDB"]);

            numEWB.Value = Convert.ToDecimal(drSavedInfo["Input_EWB"]);

            numAltitude.Value = Convert.ToDecimal(drSavedInfo["Input_Altitude"]);

            ComboBoxControl.SetIDDefaultValue(cboFluidType, drSavedInfo["Input_FluidTypeID"].ToString());

            numConcentration.Value = Convert.ToDecimal(drSavedInfo["Input_Concentration"]);

            numELT.Value = Convert.ToDecimal(drSavedInfo["Input_EnteringLiquidTemperature"]);

            cboGPMLLT.SelectedIndex = cboGPMLLT.FindString(drSavedInfo["Input_GPM_LLT"].ToString());

            if (drSavedInfo["Input_GPM_LLT"].ToString().Contains("GPM"))
            {
                numGPM.Value = Convert.ToDecimal(drSavedInfo["Input_GPM"]);
            }
            else
            {
                numLLT.Value = Convert.ToDecimal(drSavedInfo["Input_LeavingLiquidTemperature"]);
            }

            ComboBoxControl.SetIDDefaultValue(cboNumberOfCircuits, drSavedInfo["Input_NumberOfCircuits"].ToString());

            ComboBoxControl.SetIDDefaultValue(cboFPI, drSavedInfo["Input_FPI"].ToString());

            ComboBoxControl.SetIDDefaultValue(cboFinMaterial, drSavedInfo["Input_FinMaterialID"].ToString());

            ComboBoxControl.SetIDDefaultValue(cboCoating, drSavedInfo["Input_CoilCoatingID"].ToString());
        }

        /// <summary>
        /// saves the data
        /// </summary>
        /// <param name="quoteform"></param>
        /// <param name="dsQuoteData"></param>
        /// <param name="bolQuoteSelection"></param>
        /// <param name="intIndex"></param>
        /// <param name="coolingCoil"></param>
        /// <param name="txtTag"></param>
        /// <param name="numQuantity"></param>
        /// <param name="cboModel"></param>
        /// <param name="cboVoltage"></param>
        /// <param name="numEDB"></param>
        /// <param name="numEWB"></param>
        /// <param name="numAltitude"></param>
        /// <param name="cboFluidType"></param>
        /// <param name="numConcentration"></param>
        /// <param name="numELT"></param>
        /// <param name="cboGPMLLT"></param>
        /// <param name="numGPM"></param>
        /// <param name="numLLT"></param>
        /// <param name="cboNumberOfCircuits"></param>
        /// <param name="cboFPI"></param>
        /// <param name="cboFinMaterial"></param>
        /// <param name="cboCoating"></param>
        /// <param name="dtOptions"></param>
        /// <param name="dtvEvaporators"></param>
        /// <param name="dtCoilFinMaterial"></param>
        /// <param name="dtCoilCasingMaterial"></param>
        /// <param name="dtCoilTubeMaterial"></param>
        /// <param name="dtvCoilFinDefaults"></param>
        /// <param name="dtFuseSize"></param>
        /// <param name="dtEvaporatorDrawingManager"></param>
        /// <param name="closeFormOnSuccess"></param>
        /// <returns></returns>
// ReSharper disable RedundantAssignment
        private bool SaveData(Quotes.FrmQuotes quoteform, DataSet dsQuoteData, bool bolQuoteSelection, int intIndex, Coil.CoolingCoil coolingCoil, TextBox txtTag, NumericUpDown numQuantity, ComboBox cboModel, ComboBox cboVoltage, NumericUpDown numEDB, NumericUpDown numEWB, NumericUpDown numAltitude, ComboBox cboFluidType, NumericUpDown numConcentration, NumericUpDown numELT, ComboBox cboGPMLLT, NumericUpDown numGPM, NumericUpDown numLLT, ComboBox cboNumberOfCircuits, ComboBox cboFPI, ComboBox cboFinMaterial, ComboBox cboCoating, DataTable dtOptions, DataTable dtvEvaporators, DataTable dtCoilFinMaterial, DataTable dtCoilCasingMaterial, DataTable dtCoilTubeMaterial, DataTable dtvCoilFinDefaults, DataTable dtFuseSize, DataTable dtEvaporatorDrawingManager, ref bool closeFormOnSuccess)
// ReSharper restore RedundantAssignment
        {
            Form currentForm;
            //if press when form loaded from quote form
            if (bolQuoteSelection)
            {
                currentForm = Form.ActiveForm;
                ThreadProcess.Start(Public.LanguageString("Adding Water Evaporator to quote", "Ajout de l'Évaporateur à l'eau à la soumission"));
                DataTable dtSave = GetSaveTable(coolingCoil, txtTag, numQuantity, cboModel, cboVoltage, numEDB, numEWB, numAltitude, cboFluidType, numConcentration, numELT, cboGPMLLT, numGPM, numLLT, cboNumberOfCircuits, cboFPI, cboFinMaterial, cboCoating, dtvEvaporators, dtCoilFinMaterial, dtCoilCasingMaterial, dtCoilTubeMaterial, dtvCoilFinDefaults, dtFuseSize, dtEvaporatorDrawingManager);
                //DataSet dsWaterEvapData = new DataSet("WaterEvaporatorDATA");
                //dsWaterEvapData.Tables.Add(dtSave.Copy());
                //dsWaterEvapData.WriteXmlSchema("WaterEvaporatorXSD.xsd");
                int newIndexToPush = 0;
                //we need create new record
                if (intIndex != -1)
                {
                    var savingoption = new FrmSavingOption();

                    ThreadProcess.Stop();
                    if (currentForm != null)
                    {
                        currentForm.Focus();
                        if (savingoption.ShowDialog() == DialogResult.Yes)
                        {//if he want to overwrite

                            //change below to water evap when it's done
                            quoteform.DeleteFromQuoteWaterEvaporator(intIndex);
                            newIndexToPush = intIndex;
                            quoteform.UpdateAdditionalItems(intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.WaterEvaporator), newIndexToPush);
                        }
                        else
                        {
                            //since we actually always recreate the record
                            // save as new is simple, all i have to do is copy the additionnal items
                            //if reused the update function to instead duplicate record.
                            newIndexToPush = quoteform.GetNextID("QuickWaterEvaporator");
                            quoteform.CopyAdditionalItems(intIndex, Quotes.QuoteItem.ItemTypeToValue(Quotes.QuoteItem.ItemType.WaterEvaporator), newIndexToPush);

                        }
                    }
                    currentForm = Form.ActiveForm;
                    ThreadProcess.Start(Public.LanguageString("Adding to quote", "Ajout à la soumission"));
                }
                else
                {
                    newIndexToPush = quoteform.GetNextID("QuickWaterEvaporator");
                }
                quoteform.GetNextID("QuickWaterEvaporator");
                dtSave.Rows[0]["ItemID"] = newIndexToPush;
                dsQuoteData.Tables["QuickWaterEvaporator"].Rows.Add(dtSave.Rows[0].ItemArray);

                foreach (DataRow drOptions in dtOptions.Rows)
                {
                    drOptions["ItemType"] = dtSave.Rows[0]["ItemType"];
                    drOptions["ItemID"] = dtSave.Rows[0]["ItemID"];
                    dsQuoteData.Tables["WaterEvaporatorOption"].Rows.Add(drOptions.ItemArray);
                }

                DataTable copy = dsQuoteData.Tables["QuickWaterEvaporator"].Copy();
                DataRow[] list = copy.Select("", "itemID");

                dsQuoteData.Tables["QuickWaterEvaporator"].Rows.Clear();
                foreach (DataRow row in list)
                {
                    dsQuoteData.Tables["QuickWaterEvaporator"].Rows.Add(row["QuoteID"], row["QuoteRevision"], row["QuoteRevisionText"], row["ItemType"], row["ItemID"], row["Username"], row["Tag"], row["Quantity"], row["EvaporatorID"], row["Description"], row["Input_VoltageID"], row["Input_VoltDescription"], row["Input_EDB"], row["Input_EWB"], row["Input_Altitude"], row["Input_FluidTypeID"], row["Input_FluidType"], row["Input_Concentration"], row["Input_EnteringLiquidTemperature"], row["Input_GPM_LLT"], row["Input_GPM"], row["Input_LeavingLiquidTemperature"], row["Input_NumberOfCircuits"], row["Input_FPI"], row["Input_FinMaterialID"], row["Input_FinMaterialText"], row["Input_CoilCoatingID"], row["Input_CoilCoatingText"], row["CapacityAt10TD"], row["EvaporatorWeight"], row["EvaporatorCoilQty"], row["EvaporatorFanQty"], row["EvaporatorHeaterQTY"], row["EvaporatorCFM"], row["EvaporatorPrice"], row["FanArrangement"], row["DefrostTypeID"], row["DefrostTypeDescription"], row["VoltsValue"], row["PhaseNumber"], row["WattMultiplier"], row["HeaterFLAMultiplier"], row["Motor"], row["MotorHP"], row["MotorRPM"], row["MotorRotType"], row["MotorFrameType"], row["MotorShaftLength"], row["MotorPrice"], row["MotorFLA"], row["MotorMount"], row["MotorMountFanSize"], row["MotorMountFrameSize"], row["MotorMountComposition"], row["MotorMountPrice"], row["Fan"], row["FanDiameter"], row["FanBladeQuantity"], row["FanRotationType"], row["FanComposition"], row["FanPitch"], row["FanPrice"], row["FanGuard"], row["FanGuardFanSize"], row["FanGuardComposition"], row["DefrostHeater"], row["DefrostHeaterType"], row["DefrostHeaterVolt"], row["DefrostHeaterWatt"], row["DefrostHeaterDesc"], row["DefrostHeaterPrice"], row["DefrostHeaterKilowatts"], row["FinType"], row["FinShape"], row["FinHeight"], row["FinLength"], row["Row"], row["CoilFaceArea"], row["FaceVelocity"], row["AirPressureDrop"], row["LeavingDryBulb"], row["LeavingWetBulb"], row["TotalHeat"], row["SensibleHeat"], row["LeavingLiquidTemperature"], row["RefrigerantPressureDrop"], row["GPM"], row["WaterVelocity"], row["MotorMCA"], row["MotorMOP"], row["MotorFUSE"], row["HeaterFLA"], row["HeaterMCA"], row["HeaterFUSE"], row["FinMaterialPrice"], row["CoilCoatingPrice"], row["ApprovalDrawing"]);
                }

                //here call refresh of quote form
                quoteform.RefreshBasketList();
                quoteform.SetQuoteIsModified(true);

                closeFormOnSuccess = true;

                ThreadProcess.Stop();
                if (currentForm != null) currentForm.Focus();
            }
            else
            {
                DataTable dtSave = GetSaveTable(coolingCoil, txtTag, numQuantity, cboModel, cboVoltage, numEDB, numEWB, numAltitude, cboFluidType, numConcentration, numELT, cboGPMLLT, numGPM, numLLT, cboNumberOfCircuits, cboFPI, cboFinMaterial, cboCoating, dtvEvaporators, dtCoilFinMaterial, dtCoilCasingMaterial, dtCoilTubeMaterial, dtvCoilFinDefaults, dtFuseSize, dtEvaporatorDrawingManager);
                currentForm = Form.ActiveForm;
                ThreadProcess.Start(Public.LanguageString("Generating Report", "Création du rapport"));

                WaterEvaporatorReport.GenerateDataReport(dtSave, dtOptions, true, 0, "");

                ThreadProcess.Stop();
                if (currentForm != null) currentForm.Focus();
                closeFormOnSuccess = false;
            }

            return true;
        }

        /// <summary>
        /// open the window and do the coating selection
        /// </summary>
        /// <param name="cboCoating"></param>
        /// <returns></returns>
        private bool SelectCoating(ComboBox cboCoating)
        {
            bool bolSelectionIsComplete = false;

            var evapcoating = new FrmWaterEvaporatorCoating(cboCoating);

            if (evapcoating.ShowDialog() == DialogResult.OK)
            {
                cboCoating.SelectedIndex = cboCoating.FindString(evapcoating.GetSelectedCoating());
                bolSelectionIsComplete = true;
            }

            return bolSelectionIsComplete;
        }

        /// <summary>
        /// this actually fill the cooling coil object and run the performance of it
        /// </summary>
        /// <param name="cboModel"></param>
        /// <param name="numAltitude"></param>
        /// <param name="cboFluidType"></param>
        /// <param name="numConcentration"></param>
        /// <param name="numELT"></param>
        /// <param name="numEDB"></param>
        /// <param name="numEWB"></param>
        /// <param name="cboGPMLLT"></param>
        /// <param name="numGPM"></param>
        /// <param name="numLLT"></param>
        /// <param name="cboNumberOfCircuit"></param>
        /// <param name="numQuantity"></param>
        /// <param name="cboFPI"></param>
        /// <param name="cboFinMaterial"></param>
        /// <param name="dtvEvaporators"></param>
        /// <param name="dtCoilFinType"></param>
        /// <param name="dtCoilFluidType"></param>
        /// <param name="dtCoilFinMaterial"></param>
        /// <param name="dtCoilTubeMaterial"></param>
        /// <param name="dtvCoilFinDefaults"></param>
        /// <param name="dtvCoilTubeDefaults"></param>
        /// <param name="dtFreezingPointEthylene"></param>
        /// <param name="dtFreezingPointPropylene"></param>
        /// <returns></returns>
        public Coil.CoolingCoil GetCoilSelection(ComboBox cboModel, NumericUpDown numAltitude, ComboBox cboFluidType, NumericUpDown numConcentration, NumericUpDown numELT, NumericUpDown numEDB, NumericUpDown numEWB, ComboBox cboGPMLLT, NumericUpDown numGPM, NumericUpDown numLLT, ComboBox cboNumberOfCircuit, NumericUpDown numQuantity, ComboBox cboFPI, ComboBox cboFinMaterial, DataTable dtvEvaporators, DataTable dtCoilFinType, DataTable dtCoilFluidType, DataTable dtCoilFinMaterial, DataTable dtCoilTubeMaterial, DataTable dtvCoilFinDefaults, DataTable dtvCoilTubeDefaults, DataTable dtFreezingPointEthylene, DataTable dtFreezingPointPropylene)
        {
            var cCoil = new Coil.CoolingCoil();

            string errorMessage = "";
            if (ValidateInputs(cboFluidType, numConcentration, numEDB, numEWB, numELT, cboGPMLLT, numLLT, dtCoilFluidType, dtFreezingPointEthylene, dtFreezingPointPropylene, ref errorMessage))
            {
                DataTable dtModelInfo = GetModelInfoByModel(cboModel, dtvEvaporators);

                cCoil.Altitude = (float)numAltitude.Value;
                cCoil.CFM = float.Parse(dtModelInfo.Rows[0]["EvaporatorCFM"].ToString()) / (float)Convert.ToDecimal(dtModelInfo.Rows[0]["EvaporatorCoilQty"]);

                string finType = "";
                string finShape = "";
                decimal finHeight = 0m;
                decimal finLength = 0m;
                int rows = 0;

                StripCoilModel(ref finType, ref finShape, ref finHeight, ref finLength, ref rows, dtModelInfo, dtCoilFinType);

                cCoil.CoilHeight = (float)finHeight;
                cCoil.CoilLength = (float)finLength;
                cCoil.RefrigerantType = GetFluidTypeParameter(cboFluidType, dtCoilFluidType);
                cCoil.Concentration = (float)numConcentration.Value;
                cCoil.ConnectionSize = "10";
                cCoil.EnteringDryBulb = (float)numEDB.Value;
                cCoil.EnteringWetBulb = (float)numEWB.Value;
                cCoil.EnteringLiquidTemperature = (float)numELT.Value;

                cCoil.DifferenceBetweenEnteringAndLeaving = (float)Math.Abs(numELT.Value - numLLT.Value);
                cCoil.GPM = (IsGPMMode(cboGPMLLT) ? (float)numGPM.Value : 0f);

                cCoil.FinType = finType;
                cCoil.FinShape = finShape;

                cCoil.NumberOfCircuits = float.Parse(ComboBoxControl.IndexInformation(cboNumberOfCircuit));
                cCoil.NumberOfRows = rows;
                cCoil.FinsPerInch = float.Parse(ComboBoxControl.IndexInformation(cboFPI));

                cCoil.FinMaterial = GetFinMaterialParameter(cboFinMaterial, dtCoilFinMaterial);
                cCoil.FinThickness = (float)GetFinThicknessDefault(finType, finShape, Convert.ToInt32(ComboBoxControl.IndexInformation(cboFPI)), ComboBoxControl.IndexInformation(cboFinMaterial), dtvCoilFinDefaults);
                cCoil.TubeMaterial = "CU";
                cCoil.TubeThickness = (float)GetTubeThicknessDefault(finType, "1", dtvCoilTubeDefaults);
                cCoil.Turbulator = "N";

                cCoil.Type = "R";

                cCoil.RunPerformance();
            }
            else
            {
                cCoil.ErrorMessage = errorMessage;
            }

            return cCoil;
        }

        /// <summary>
        /// fill coating depending on the model selected
        /// </summary>
        /// <param name="cboCoilCoating"></param>
        /// <param name="cboModel"></param>
        /// <param name="cboFPI"></param>
        /// <param name="dtvEvaporators"></param>
        /// <param name="dtElectroFinAdjustement"></param>
        /// <param name="dtHeresiteSafety"></param>
        /// <param name="dtCoilFinType"></param>
        public void FillCoilCoating(ComboBox cboCoilCoating, ComboBox cboModel, ComboBox cboFPI, DataTable dtvEvaporators, DataTable dtElectroFinAdjustement, DataTable dtHeresiteSafety, DataTable dtCoilFinType)
        {
            //clear the list
            cboCoilCoating.Items.Clear();

            ComboBoxControl.AddItem(cboCoilCoating, "1", "None");
            ComboBoxControl.AddItem(cboCoilCoating, "2", "Blygold");

            DataTable dtModelInfo = GetModelInfoByModel(cboModel, dtvEvaporators);

            string finType = "";
            string finShape = "";
            decimal finHeight = 0m;
            decimal finLength = 0m;
            int rows = 0;

            StripCoilModel(ref finType, ref finShape, ref finHeight, ref finLength, ref rows, dtModelInfo, dtCoilFinType);

            //check if electro fin available, if yes add it
            if (Query.IsElectroFinAvailable(dtElectroFinAdjustement, rows, Convert.ToInt32(ComboBoxControl.IndexInformation(cboFPI))))
            {
                ComboBoxControl.AddItem(cboCoilCoating, "3", "ElectroFin");
            }

            //check if heresite available, if yes add it
            if (Query.IsHeresiteAvailable(dtHeresiteSafety, finHeight, finLength))
            {
                ComboBoxControl.AddItem(cboCoilCoating, "4", "Heresite");
            }

            //select none as default
            cboCoilCoating.SelectedIndex = 0;
        }

        /// <summary>
        /// return the default fin thickness for the current selected option
        /// </summary>
        /// <param name="strFinType"></param>
        /// <param name="strFinShape"></param>
        /// <param name="intFPI"></param>
        /// <param name="strFinMaterialID"></param>
        /// <param name="dtvCoilFinDefaults"></param>
        /// <returns></returns>
        private static decimal GetFinThicknessDefault(string strFinType, string strFinShape, int intFPI, string strFinMaterialID, DataTable dtvCoilFinDefaults)
        {
            decimal decDefaultThickness = 0m;

            DataTable dtDefaults = Public.SelectAndSortTable(dtvCoilFinDefaults, "FinType = '" + strFinType + "' AND FinShape = '" + strFinShape + "' AND FPI_MIN <= " + intFPI + " AND FPI_MAX >= " + intFPI + " AND FinMaterialID = " + strFinMaterialID + " AND DefaultValue = 1", "");

            if (dtDefaults.Rows.Count > 0)
            {
                decDefaultThickness = Convert.ToDecimal(dtDefaults.Rows[0]["FinThickness"]);
            }

            return decDefaultThickness;
        }

        /// <summary>
        /// return the default tube thickness for the current selected option
        /// </summary>
        /// <param name="strFinType"></param>
        /// <param name="strTubeMaterialID"></param>
        /// <param name="dtvCoilTubeDefaults"></param>
        /// <returns></returns>
        private static decimal GetTubeThicknessDefault(string strFinType, string strTubeMaterialID, DataTable dtvCoilTubeDefaults)
        {
            decimal decDefaultThickness = 0m;

            DataTable dtDefaults = Public.SelectAndSortTable(dtvCoilTubeDefaults, "UniqueID = " + strTubeMaterialID + " AND CoilType = 'FC' AND FinType = '" + strFinType + "' AND DefaultValue = 1", "");

            if (dtDefaults.Rows.Count > 0)
            {
                decDefaultThickness = Convert.ToDecimal(dtDefaults.Rows[0]["TubeSize"]);
            }

            return decDefaultThickness;
        }

        /// <summary>
        /// from the model prefiltered it take out the model of the coil from the table record.
        /// since fpi is selected by the user it is not available here
        /// </summary>
        /// <param name="finType"></param>
        /// <param name="finShape"></param>
        /// <param name="finHeight"></param>
        /// <param name="finLength"></param>
        /// <param name="rows"></param>
        /// <param name="dtModelInfo"></param>
        /// <param name="dtCoilFinType"></param>
// ReSharper disable RedundantAssignment
        private void StripCoilModel(ref string finType, ref string finShape, ref decimal finHeight, ref decimal finLength, ref int rows, DataTable dtModelInfo, DataTable dtCoilFinType)
// ReSharper restore RedundantAssignment
        {
            finType = dtModelInfo.Rows[0]["CoilType"].ToString().Substring(1, 1);
            finShape = dtModelInfo.Rows[0]["CoilType"].ToString().Substring(2, 1);

            DataTable dtFinTypeInfo = GetFinTypeInfo(finType, dtCoilFinType);

            finHeight = Convert.ToDecimal(dtFinTypeInfo.Rows[0]["FaceTube"]) * Convert.ToDecimal(dtModelInfo.Rows[0]["CoilTubes"]);
            finLength = Convert.ToDecimal(dtModelInfo.Rows[0]["CoilLength"]);
            rows = Convert.ToInt32(dtModelInfo.Rows[0]["CoilRow"]);
        }

        /// <summary>
        /// Right now it's used only once but other value may be usefull later on
        /// so this will limitate the need of copy paste of code
        /// </summary>
        /// <param name="finType"></param>
        /// <param name="dtCoilFinType"></param>
        /// <returns></returns>
        private static DataTable GetFinTypeInfo(string finType, DataTable dtCoilFinType)
        {
            return Public.SelectAndSortTable(dtCoilFinType, "FinType = '" + finType + "'", "");
        }

        /// <summary>
        /// filter to get the model info for a specific voltage
        /// </summary>
        /// <param name="cboModel"></param>
        /// <param name="cboVoltage"></param>
        /// <param name="dtvEvaporators"></param>
        /// <returns></returns>
        private DataTable GetModelInfoByModelSpecificVoltage(ComboBox cboModel, ComboBox cboVoltage, DataTable dtvEvaporators)
        {
            return Public.SelectAndSortTable(GetModelInfoByModel(cboModel, dtvEvaporators), "VoltageID = " + ComboBoxControl.IndexInformation(cboVoltage), "");
        }

        /// <summary>
        /// filter used often so i made a function to limitate the copy pasting
        /// </summary>
        /// <param name="cboModel"></param>
        /// <param name="dtvEvaporators"></param>
        /// <returns></returns>
        private static DataTable GetModelInfoByModel(ComboBox cboModel, DataTable dtvEvaporators)
        {
            return Public.SelectAndSortTable(dtvEvaporators, "EvaporatorID = '" + ComboBoxControl.IndexInformation(cboModel) + "'", "");
        }

        /// <summary>
        /// retreive the fluid type parameter that is required on few sorting and selection
        /// </summary>
        /// <param name="cboFluidType"></param>
        /// <param name="dtCoilFluidType"></param>
        /// <returns></returns>
        private static string GetFluidTypeParameter(ComboBox cboFluidType, DataTable dtCoilFluidType)
        {
            return ComboBoxControl.ItemInformations(cboFluidType, dtCoilFluidType, "UniqueID")[0]["FluidTypeParameter"].ToString();
        }

        /// <summary>
        /// validate min max and default value of the concentration depending on the
        /// actual fluid type that the user selected
        /// </summary>
        /// <param name="cboFluidType"></param>
        /// <param name="numConcentration"></param>
        /// <param name="dtCoilFluidType"></param>
        public void ValidateConcentration(ComboBox cboFluidType, NumericUpDown numConcentration, DataTable dtCoilFluidType)
        {
            switch (GetFluidTypeParameter(cboFluidType, dtCoilFluidType))
            {
                case "WTR": //water is 100% and cannot be changed
                    numConcentration.Minimum = 0;
                    numConcentration.Maximum = 100;
                    numConcentration.Value = 100;
                    numConcentration.Enabled = false;
                    break;
                case "EG":
                case "PG"://PG and EG are default to 40 and the range is 10-60 and we can
                    numConcentration.Value = 40;
                    numConcentration.Minimum = 10;
                    numConcentration.Maximum = 60;
                    numConcentration.Enabled = true;
                    break;
            }
        }

        /// <summary>
        /// know if it's running in gpm mode or llt
        /// </summary>
        /// <param name="cboGPMLLT"></param>
        /// <returns></returns>
        private bool IsGPMMode(ComboBox cboGPMLLT)
        {
            return cboGPMLLT.Text == @"USGPM";
        }

        /// <summary>
        /// this control the visibility and use of the gpm and llt
        /// </summary>
        /// <param name="cboGPMLLT"></param>
        /// <param name="numGPM"></param>
        /// <param name="numLLT"></param>
        public void ValidateGPM_LLT(ComboBox cboGPMLLT, NumericUpDown numGPM, NumericUpDown numLLT)
        {
            if (IsGPMMode(cboGPMLLT))
            {
                numGPM.Visible = true;
                numLLT.Visible = false;
            }
            else
            {
                numGPM.Visible = false;
                numLLT.Visible = true;
            }
        }

        /// <summary>
        /// fill the list of evap that are can be selected as water mode
        /// </summary>
        /// <param name="cboModel"></param>
        /// <param name="dtEvaporators"></param>
        public void FillModel(ComboBox cboModel, DataTable dtEvaporators)
        {
            cboModel.Items.Clear();

            DataTable dtListValidModel = Public.SelectAndSortTable(dtEvaporators, "WaterCoilSelection = 1", "EvaporatorID");

            foreach (DataRow drModel in dtListValidModel.Rows)
            {
                string strIndex = drModel["EvaporatorID"].ToString();
                string strText = drModel["EvaporatorID"].ToString();
                ComboBoxControl.AddItem(cboModel, strIndex, strText);
            }
        }

        /// <summary>
        /// fill fluid type. we exclude other refrigerant at the moment
        /// </summary>
        /// <param name="cboFluidType"></param>
        /// <param name="dtCoilFluidType"></param>
        public void FillFluidType(ComboBox cboFluidType, DataTable dtCoilFluidType)
        {
            cboFluidType.Items.Clear();

            DataTable dtFluidType = Public.SelectAndSortTable(dtCoilFluidType, "FluidTypeParameter <> 'OTHER'", "");

            foreach (DataRow drFluidType in dtFluidType.Rows)
            {
                string strIndex = drFluidType["UniqueID"].ToString();
                string strText = drFluidType["FluidType"].ToString();
                ComboBoxControl.AddItem(cboFluidType, strIndex, strText);
            }
        }

        /// <summary>
        /// fill the possible voltage for the current model
        /// </summary>
        /// <param name="cboVoltage"></param>
        /// <param name="cboModel"></param>
        /// <param name="dtvEvaporators"></param>
        /// <param name="dtEvaporatorVoltage"></param>
        public void FillVoltage(ComboBox cboVoltage, ComboBox cboModel, DataTable dtvEvaporators, DataTable dtEvaporatorVoltage)
        {
            cboVoltage.Items.Clear();

            DataTable dtVoltages = Public.SelectAndSortTable(dtEvaporatorVoltage, GetValidVoltagesFilter(cboModel, dtvEvaporators), "VoltDescription");

            foreach (DataRow drVoltage in dtVoltages.Rows)
            {
                string strIndex = drVoltage["VoltageID"].ToString();
                string strText = drVoltage["VoltDescription"].ToString();
                ComboBoxControl.AddItem(cboVoltage, strIndex, strText);
            }

            cboVoltage.SelectedIndex = 0;
        }

        /// <summary>
        /// fill the possible circuit for the current evaporator model
        /// </summary>
        /// <param name="cboNumberOfCircuits"></param>
        /// <param name="cboModel"></param>
        /// <param name="dtvEvaporators"></param>
        public void FillNumberOfCircuits(ComboBox cboNumberOfCircuits, ComboBox cboModel, DataTable dtvEvaporators)
        {
            cboNumberOfCircuits.Items.Clear();

            DataTable dtModelInfo = GetModelInfoByModel(cboModel, dtvEvaporators);

            if (dtModelInfo.Rows.Count > 0)
            {
                IEnumerable<int> listofcircuits = GetPossibleCircuits(2, 350, Convert.ToInt32(dtModelInfo.Rows[0]["CoilTubes"]) * Convert.ToInt32(dtModelInfo.Rows[0]["CoilRow"]));

                foreach (int circ in listofcircuits)
                {
                    string strIndex = circ.ToString(CultureInfo.InvariantCulture);
                    string strText = circ.ToString(CultureInfo.InvariantCulture);
                    ComboBoxControl.AddItem(cboNumberOfCircuits, strIndex, strText);
                }
            }

            cboNumberOfCircuits.SelectedIndex = 0;
        }

        /// <summary>
        /// fill the fpi control according to list availaible for the current 
        /// evaporator model and auto default the default fpi
        /// </summary>
        /// <param name="cboFPI"></param>
        /// <param name="cboModel"></param>
        /// <param name="dtvEvaporators"></param>
        public void FillFPI(ComboBox cboFPI, ComboBox cboModel, DataTable dtvEvaporators)
        {
            cboFPI.Items.Clear();
            string strDefaultFPI = "";
            IEnumerable<int> validFPI = GetValidFPI(cboModel, dtvEvaporators, ref strDefaultFPI);

            foreach (int fpi in validFPI)
            {
                string strIndex = fpi.ToString(CultureInfo.InvariantCulture);
                string strText = fpi.ToString(CultureInfo.InvariantCulture);
                ComboBoxControl.AddItem(cboFPI, strIndex, strText);
            }

            ComboBoxControl.SetDefaultValue(cboFPI, strDefaultFPI);
        }

        /// <summary>
        /// this return the distinct list of available FPI for that model in ascending order
        /// </summary>
        /// <param name="cboModel"></param>
        /// <param name="dtvEvaporators"></param>
        /// <param name="defaultFPI">returned to get the standard because it's what we want to defualt to</param>
        /// <returns></returns>
        private IEnumerable<int> GetValidFPI(ComboBox cboModel, DataTable dtvEvaporators, ref string defaultFPI)
        {
            var validFPI = new List<int>();

            DataTable dtModelInfo = GetModelInfoByModel(cboModel, dtvEvaporators);

            for (int i = 0; i < dtModelInfo.Rows.Count; i++)
            {
                int currentFPI = Convert.ToInt32(dtModelInfo.Rows[i]["CurrentFPI"]);

                if (currentFPI == -99)
                {
                    defaultFPI = dtModelInfo.Rows[i]["StandardFPI"].ToString();
                }
                else
                {
                    bool fpiExist = false;

                    for (int ifpi = 0; ifpi < validFPI.Count; ifpi++)
                    {
                        if (validFPI[ifpi] == currentFPI)
                        {
                            fpiExist = true;
                            ifpi = validFPI.Count;
                        }
                    }

                    if (!fpiExist) validFPI.Add(currentFPI);
                }
            }

            return validFPI;
        }

        /// <summary>
        /// get the filtered list of voltages possible for that model
        /// </summary>
        /// <param name="cboModel"></param>
        /// <param name="dtvEvaporators"></param>
        /// <returns></returns>
        private string GetValidVoltagesFilter(ComboBox cboModel, DataTable dtvEvaporators)
        {
            string strFilter = "";

            DataTable dtGetModelVoltages = GetModelInfoByModel(cboModel, dtvEvaporators);

            for (int i = 0; i < dtGetModelVoltages.Rows.Count; i++)
            {
                strFilter += "," + dtGetModelVoltages.Rows[i]["VoltageID"];
            }

            if (strFilter.Length > 0)
            {
                strFilter = "VoltageID IN (" + strFilter.Substring(1) + ")";
            }

            return strFilter;
        }


        /// <summary>
        /// return all the possible circuit between min and max given.
        /// </summary>
        /// <param name="minCircuits">min is inclusive</param>
        /// <param name="maxCircuits">max is inclusive</param>
        /// <param name="totalNumberOfTubes">technically : face tubes x rows</param>
        /// <returns></returns>
        private IEnumerable<int> GetPossibleCircuits(int minCircuits, int maxCircuits, int totalNumberOfTubes)
        {
            var iCircuit = new List<int>();

            //loop to find all possible circuits
            for (int intCircuits = maxCircuits; intCircuits >= minCircuits; intCircuits--)
            {
                decimal decTubesPerCircuits = Convert.ToDecimal(totalNumberOfTubes) / Convert.ToDecimal(intCircuits);

                if (decTubesPerCircuits == Math.Floor(decTubesPerCircuits))
                {
                    iCircuit.Add(intCircuits);
                }
            }

            iCircuit.Reverse();

            return iCircuit;
        }

        /// <summary>
        /// Will fill up and refresh the grid with the data from the selection
        /// </summary>
        /// <param name="lstDisplay">glacial list with 3 columns to fill</param>
        /// <param name="coolingCoil">Cooling coil to display</param>
        /// <param name="numQuantity"></param>
        /// <param name="cboModel"></param>
        /// <param name="dtvEvaporators"></param>
        public void DisplayResult(GlacialComponents.Controls.GlacialList lstDisplay, Coil.CoolingCoil coolingCoil, NumericUpDown numQuantity, ComboBox cboModel, DataTable dtvEvaporators)
        {
            if (coolingCoil.IsValid)
            {
                FillDisplayResult(lstDisplay, GetDataForDisplay(coolingCoil, numQuantity, cboModel, dtvEvaporators));
            }
            else
            {
                ClearPerformanceDisplay(lstDisplay);
                MessageBox.Show(coolingCoil.ErrorMessage);
            }
        }

        /// <summary>
        /// clear the list of previously ran perfromance
        /// </summary>
        /// <param name="lstDisplay"></param>
        public void ClearPerformanceDisplay(GlacialComponents.Controls.GlacialList lstDisplay)
        {
            lstDisplay.Items.Clear();
            lstDisplay.Refresh();
        }

        /// <summary>
        /// this function is the one that actually fill the list and refreshes it
        /// </summary>
        /// <param name="lstDisplay">glacial list with 3 columns to fill</param>
        /// <param name="dataToDisplay">formated array of the data to fill the list with see getDataForDisplay()</param>
        private void FillDisplayResult(GlacialComponents.Controls.GlacialList lstDisplay, IEnumerable<string[]> dataToDisplay)
        {
            lstDisplay.Items.Clear();

            foreach (string[] strData in dataToDisplay)
            {
                var myItem = new GlacialComponents.Controls.GLItem(lstDisplay);

                myItem.SubItems[0].Text = strData[0];
                myItem.SubItems[1].Text = strData[1];
                myItem.SubItems[2].Text = strData[2];

                lstDisplay.Items.Add(myItem);
            }

            lstDisplay.Refresh();
        }

        /// <summary>
        /// this format the data to display in the list
        /// </summary>
        /// <param name="coolingCoil">Cooling coil to display</param>
        /// <param name="numQuantity"></param>
        /// <param name="cboModel"></param>
        /// <param name="dtvEvaporators"></param>
        /// <returns></returns>
        private IEnumerable<string[]> GetDataForDisplay(Coil.CoolingCoil coolingCoil, NumericUpDown numQuantity, ComboBox cboModel, DataTable dtvEvaporators)
        {
            var data = new List<string[]>();

            decimal decCoilQTY = Convert.ToDecimal(GetModelInfoByModel(cboModel, dtvEvaporators).Rows[0]["EvaporatorCoilQty"]);

            //if there's only one coil in the evap, there is no need to add all the "per coil" values.
            if (decCoilQTY == 1)
            {

                data.Add(new [] { Public.LanguageString("Total Heat (per Evap/ Total)", "Chaleur Totale (par Évap/ Total)"),  Convert.ToDecimal(coolingCoil.TotalHeat * (float)decCoilQTY).ToString("###,###,###") + " / " + Convert.ToDecimal(coolingCoil.TotalHeat * (float)decCoilQTY * (float)numQuantity.Value).ToString("###,###,###"), "Btu/hr" });
                data.Add(new [] { Public.LanguageString("Sensible Heat (per Evap/ Total)", "Chaleur sensible (par Évap/ Total)"), Convert.ToDecimal(coolingCoil.SensibleHeat * (float)decCoilQTY).ToString("###,###,###") + " / " + Convert.ToDecimal(coolingCoil.SensibleHeat * (float)decCoilQTY * (float)numQuantity.Value).ToString("###,###,###"), "Btu/hr" });
                data.Add(new [] { Public.LanguageString("Leaving Dry Bulb", "Bulbe Sec à la sortie"), Convert.ToDecimal(coolingCoil.LeavingDryBulb).ToString("N1"), "°F" });
                data.Add(new [] { Public.LanguageString("Leaving Wet Bulb", "Bulbe Humide à la sortie"), Convert.ToDecimal(coolingCoil.LeavingWetBulb).ToString("N1"), "°F" });
                data.Add(new [] { Public.LanguageString("Air Pressure Drop", "Perte pression de l'air"), Convert.ToDecimal(coolingCoil.AirPressureDrop).ToString("N2"), "in-wg" });
                data.Add(new [] { Public.LanguageString("Face Velocity", "Vélocité façade"), Convert.ToDecimal(coolingCoil.FaceVelocity).ToString("N0"), "FPM" });
                data.Add(new [] { Public.LanguageString("Leaving Liquid Temperature", "Temp. de liquide à la sortie"), Convert.ToDecimal(coolingCoil.LeavingLiquidTemperature).ToString("N2"), "°F" });
                data.Add(new [] { Public.LanguageString("GPM", "GPM"), Convert.ToDecimal(coolingCoil.GPM).ToString("N2"), "" });
                data.Add(new [] { Public.LanguageString("Liquid Velocity", "Vélocité liquide"), Convert.ToDecimal(coolingCoil.WaterVelocity).ToString("N2"), "ft/sec" });
                data.Add(new [] { Public.LanguageString("Liquid Pressure Drop", "Chute de pression de liquide"), Convert.ToDecimal(coolingCoil.RefrigerantPressureDrop).ToString("N2") + " PSI / " + Convert.ToDecimal(Convert.ToDecimal(coolingCoil.RefrigerantPressureDrop) * Convert.ToDecimal(2.306666666666)).ToString("N2") + " FT(H2O)", "" });
                data.Add(new [] { Public.LanguageString("# of Circuits (per Evap)", "# de Circuits (par Évap)"), Convert.ToDecimal(coolingCoil.NumberOfCircuits * (float)decCoilQTY).ToString("N0"), "" });
            }
            else
            {
                data.Add(new [] { Public.LanguageString("Total Heat (per Coil/per Evap/ Total)", "Chaleur Totale (par Serpentin/par Évap/ Total)"), Convert.ToDecimal(coolingCoil.TotalHeat).ToString("###,###,###") + " / " + Convert.ToDecimal(coolingCoil.TotalHeat * (float)decCoilQTY).ToString("###,###,###") + " / " + Convert.ToDecimal(coolingCoil.TotalHeat * (float)decCoilQTY * (float)numQuantity.Value).ToString("###,###,###"), "Btu/hr" });
                data.Add(new [] { Public.LanguageString("Sensible Heat (per Coil/per Evap/ Total)", "Chaleur sensible (par Serpentin/par Évap/ Total)"), Convert.ToDecimal(coolingCoil.SensibleHeat).ToString("###,###,###") + " / " + Convert.ToDecimal(coolingCoil.SensibleHeat * (float)decCoilQTY).ToString("###,###,###") + " / " + Convert.ToDecimal(coolingCoil.SensibleHeat * (float)decCoilQTY * (float)numQuantity.Value).ToString("###,###,###"), "Btu/hr" });
                data.Add(new [] { Public.LanguageString("Leaving Dry Bulb", "Bulbe Sec à la sortie"), Convert.ToDecimal(coolingCoil.LeavingDryBulb).ToString("N1"), "°F" });
                data.Add(new [] { Public.LanguageString("Leaving Wet Bulb", "Bulbe Humide à la sortie"), Convert.ToDecimal(coolingCoil.LeavingWetBulb).ToString("N1"), "°F" });
                data.Add(new [] { Public.LanguageString("Air Pressure Drop", "Perte pression de l'air"), Convert.ToDecimal(coolingCoil.AirPressureDrop).ToString("N2"), "in-wg" });
                data.Add(new [] { Public.LanguageString("Face Velocity", "Vélocité façade"), Convert.ToDecimal(coolingCoil.FaceVelocity).ToString("N0"), "FPM" });
                data.Add(new [] { Public.LanguageString("Leaving Liquid Temperature", "Temp. de liquide à la sortie"), Convert.ToDecimal(coolingCoil.LeavingLiquidTemperature).ToString("N2"), "°F" });
                data.Add(new [] { Public.LanguageString("GPM", "GPM"), Convert.ToDecimal(coolingCoil.GPM).ToString("N2"), "" });
                data.Add(new [] { Public.LanguageString("Liquid Velocity", "Vélocité liquide"), Convert.ToDecimal(coolingCoil.WaterVelocity).ToString("N2"), "ft/sec" });
                data.Add(new [] { Public.LanguageString("Liquid Pressure Drop", "Chute de pression de liquide"), Convert.ToDecimal(coolingCoil.RefrigerantPressureDrop).ToString("N2") + " PSI / " + Convert.ToDecimal(Convert.ToDecimal(coolingCoil.RefrigerantPressureDrop) * Convert.ToDecimal(2.306666666666)).ToString("N2") + " FT(H2O)", "" });
                data.Add(new [] { Public.LanguageString("# of Circuits (per Coil/per Evap)", "# de Circuits (par Serpentin/par Évap)"), Convert.ToDecimal(coolingCoil.NumberOfCircuits).ToString("N0") + " / " + Convert.ToDecimal(coolingCoil.NumberOfCircuits * (float)decCoilQTY).ToString("N0"), "" });
            }
            return data;
        }
    }
}
