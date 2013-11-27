using System;
using System.Data;

namespace RefplusWebtools.Pricing
{
    class BoosterCoil
    {
        //variable that hold the final total
        private readonly decimal _decTotalPrice;

        //variable from the fin type
        private decimal _decTubeDiameter;
        private decimal _decFaceTube;
        private decimal _decTubeRow;
        private decimal _decReturnBendsCost;
        private decimal _decRowWidth;
        private decimal _decPressStrokeMin;

        //Coil Quantity Range
        private decimal _decCoilQuantityMinRange;
        private decimal _decCoilQuantityMaxRange;

        //constructor
        public BoosterCoil(string strFinType, decimal decCoilQuantity, decimal decNumberOfRows, decimal decFPI, decimal decFinHeight, decimal decFinLength, decimal decHeaderDiameter, decimal decFinThickness, string strTubeMaterial, decimal decTubeThickness, decimal decCasingThickness, decimal decFinDensity, decimal decFinPricePerLbs, decimal decCasingDensity, decimal decCasingPricePerLbs, decimal decTubeDensity, decimal decTubePricePerLbs, decimal decHeaderQuantity)
        {
            try
            {
                //load tables we need
                Query.LoadTables(new[] { "CoilFinType", "PricingCoilSetting", "StraightTubeCuttingFactor", "PricingCoilHeader", "PricingCoilQuantityRange", "PricingCoilSetup" });

                //set fin type variables
                SetFinTypeVariables(strFinType);

                decimal decTubeExtra = (decimal)Math.PI * ((_decFaceTube / 2m) / 2m) + 0.25m;

                decimal decFinalReturnBendPrice = GetReturnBendsPrice(strTubeMaterial);

                decimal decFinMaterialQty = decFinHeight * decNumberOfRows * _decTubeRow * decFPI * decFinLength * decFinThickness;

                decimal decFinWeight = decFinMaterialQty * decFinDensity;

                decimal decTubeLength = (decFinHeight / _decFaceTube) * decNumberOfRows * (decFinLength + decTubeExtra);

                decimal decSurfaceSection = ((decimal)Math.Pow((double)_decTubeDiameter, 2d) - (decimal)Math.Pow((double)(_decTubeDiameter - (2m * decTubeThickness)), 2d)) * (decimal)Math.PI / 4m;

                decimal decTubeWeight = decTubeLength * decSurfaceSection * decTubeDensity;

                decimal decTotalCostForFinMaterial = decFinWeight * decFinPricePerLbs;

                decimal decTotalCostForTubeMaterial = decTubeWeight * decTubePricePerLbs;

                decimal decTotalCostForReturnBends = (decFinHeight / _decFaceTube) * decNumberOfRows * decFinalReturnBendPrice;

                decimal decTotalForCrossOver = Convert.ToDecimal(CoilPriceOption("CrossOverQty")) * Convert.ToDecimal(CoilPriceOption("CrossOverPrice"));

                decimal decCasingHeight = decFinHeight + 3m;

                decimal decCasingWidth = _decTubeRow * decNumberOfRows + 5m;

                decimal decTotalCostForEndPlates = Convert.ToDecimal(CoilPriceOption("EndPlateQty")) * decCasingPricePerLbs * decCasingHeight * decCasingWidth * decCasingDensity * decCasingThickness;

                decimal decTopBottomPlateHeight = decFinLength + 3m;

                decimal decTotalCostForTopBottomPlates = Convert.ToDecimal(CoilPriceOption("TopBottomPlatesQty")) * decCasingPricePerLbs * decTopBottomPlateHeight * decCasingWidth * decCasingDensity * decCasingThickness;

                decimal decTotalCostForCenterPlates = GetQuantityOfCenterPlate(decFinLength) * decCasingPricePerLbs * decCasingHeight * decCasingWidth * decCasingDensity * decCasingThickness;

                const decimal decCopperHeaderLength = 10m;

                decimal decTotalCostForCopperHeader = decHeaderQuantity * decCopperHeaderLength * GetHeaderPrice(decHeaderDiameter) / 12m;

                decimal decSecondCopperHeaderLength = decFinHeight + 6m;

                decimal decTotalCostForSecondCopperHeader = Convert.ToDecimal(CoilPriceOption("SecondCopperHeaderQty")) * decSecondCopperHeaderLength * GetHeaderPrice(Convert.ToDecimal(CoilPriceOption("SecondCopperHeaderDiam"))) / 12m;

                const decimal decTotalCostForRedBrassConn = 0m;

                decimal decTotalCostForVents = Convert.ToDecimal(CoilPriceOption("VentQty")) * Convert.ToDecimal(CoilPriceOption("VentLen"));

                decimal decTotalCostForSpigots = ((decFinHeight / _decFaceTube) * 1m) * Convert.ToDecimal(CoilPriceOption("SpigotLen")) * GetHeaderPrice(_decTubeDiameter) / 12m;

                decimal decTotalCostForDistributor = Convert.ToDecimal(CoilPriceOption("DistributorQty")) * Convert.ToDecimal(CoilPriceOption("DistributorPrice"));

                decimal decTotalCostForDistributorLine = Convert.ToDecimal(CoilPriceOption("DistributorLineQty")) * Convert.ToDecimal(CoilPriceOption("DistributorLineLen")) * GetHeaderPrice(Convert.ToDecimal(CoilPriceOption("DistributorLineDiam")));

                decimal decTotalCostForAuxSide = Convert.ToDecimal(CoilPriceOption("AuxSideQty")) * Convert.ToDecimal(CoilPriceOption("AuxSidePrice"));

                decimal decTotalCostForFitting = Convert.ToDecimal(CoilPriceOption("FittingQty")) * Convert.ToDecimal(CoilPriceOption("FittingPrice"));

                decimal decCostBeforeCrafting = decTotalCostForFitting + decTotalCostForAuxSide + decTotalCostForDistributorLine + decTotalCostForDistributor + decTotalCostForSpigots + decTotalCostForVents + decTotalCostForRedBrassConn + decTotalCostForSecondCopperHeader + decTotalCostForCopperHeader + decTotalCostForEndPlates + decTotalCostForCenterPlates + decTotalCostForTopBottomPlates + decTotalCostForFinMaterial + decTotalCostForReturnBends + decTotalCostForTubeMaterial + decTotalForCrossOver;

                decimal decCostBeforeScrap = decTotalCostForSecondCopperHeader + decTotalCostForCopperHeader + decTotalCostForEndPlates + decTotalCostForCenterPlates + decTotalCostForTopBottomPlates + decTotalCostForFinMaterial + decTotalCostForReturnBends + decTotalCostForTubeMaterial + decTotalForCrossOver;

                decimal decTotalCostForCrafting = Convert.ToDecimal(CoilPriceOption("Crating")) * decCostBeforeCrafting;

                decimal decTotalCostForScrap = Convert.ToDecimal(CoilPriceOption("Scrap")) * decCostBeforeScrap;

                decimal decTotalCostForMaterial = decCostBeforeCrafting + decTotalCostForScrap + decTotalCostForCrafting;

                decimal decLaborPressPunching = ((decFinHeight / _decFaceTube) * decNumberOfRows * decFPI * decFinLength) / 2m / _decPressStrokeMin / _decRowWidth / 0.33m * GetLaborPressPunchingMultiplierForEvenOrOddTubes(decFinHeight, _decFaceTube);

                decimal decLaborTubeCutting = (decFinHeight / _decFaceTube) * decNumberOfRows * GetStraightTubeCuttingFactor(decFinLength);

                decimal decLaborEndPlate = (2m + ((decFinHeight / _decFaceTube) * decNumberOfRows * 0.045m)) * Convert.ToDecimal(CoilPriceOption("EndPlateQty")) / 2m;

                decimal decLaborCenterPlate = (2m + ((decFinHeight / _decFaceTube) * decNumberOfRows * 0.045m)) * GetQuantityOfCenterPlate(decFinLength) / 2m;

                decimal decLaborSidePlate = (2m + ((decNumberOfRows * 0.035m) * (decFinLength / 2m))) * Convert.ToDecimal(CoilPriceOption("TopBottomPlatesQty")) / 2m;

                decimal decLaborCoilAssembly = decNumberOfRows * (decFinHeight / _decFaceTube) * decFinLength * 0.03m;

                decimal decLaborExpansion = GetLaborExpansion(strFinType, decNumberOfRows, decFinLength, decFinHeight);

                decimal decLaborWeldedCasing = GetLaborWeldedCasing();

                decimal decLaborHeaderCuttingPuncher = 2m * (decHeaderQuantity + Convert.ToDecimal(CoilPriceOption("SecondCopperHeaderQty")));

                decimal decLaborDistributorLineAssembly = (Convert.ToDecimal(CoilPriceOption("DistributorLineQty")) * 0.6m) + (Convert.ToDecimal(CoilPriceOption("DistributorQty")) * 4m) + (Convert.ToDecimal(CoilPriceOption("DistributorLineQty")) * 0.25m * 2m);

                decimal decLaborReturnBendAssembly = ((decFinHeight / _decFaceTube) * decNumberOfRows + Convert.ToDecimal(CoilPriceOption("CrossOverQty"))) * 0.33m;

                decimal decLaborReturnBendBrazing = ((decFinHeight / _decFaceTube) * decNumberOfRows + Convert.ToDecimal(CoilPriceOption("CrossOverQty"))) * 0.45m;

                decimal decLaborBrazingSpigotHeadersCoils = (((decFinHeight / _decFaceTube) * 1m) * 0.35m) * 2m;

                decimal decLaborTesting = GetLaborTesting(decFinLength);

                decimal decLaborCrafting = (decFinHeight / _decFaceTube) * decNumberOfRows * decFinLength * 0.0025m;

                decimal decCostOfLaborBeforeMisc = decLaborBrazingSpigotHeadersCoils + decLaborCenterPlate + decLaborCoilAssembly + decLaborCrafting + decLaborDistributorLineAssembly + decLaborEndPlate + decLaborExpansion + decLaborHeaderCuttingPuncher + decLaborPressPunching + decLaborReturnBendAssembly + decLaborReturnBendBrazing + decLaborSidePlate + decLaborTesting + decLaborTubeCutting + decLaborWeldedCasing;

                decimal decLaborMisc = decCostOfLaborBeforeMisc * Convert.ToDecimal(CoilPriceOption("MiscLaborMargin"));

                decimal decTotalLaborCost = decCostOfLaborBeforeMisc + decLaborMisc;

                decimal decTotalCorrectedLaborCost = decTotalLaborCost * Convert.ToDecimal(CoilPriceOption("LaborCorr"));

                decimal decNetCost = decTotalCostForMaterial + decTotalCorrectedLaborCost * (Convert.ToDecimal(CoilPriceOption("LaborSalary")) / 60m) + (Convert.ToDecimal(CoilPriceOption("Burden")) * 100m) * (Convert.ToDecimal(CoilPriceOption("LaborSalary")) / 60m) * decTotalCorrectedLaborCost;

                decimal decMarkUpCost = decNetCost / (1 - Convert.ToDecimal(CoilPriceOption("Profit")));

                decimal decBrokerageFees = decMarkUpCost * Convert.ToDecimal(CoilPriceOption("Brokerage"));

                decimal decExchangeRate = ((decBrokerageFees + decMarkUpCost) * Convert.ToDecimal(CoilPriceOption("Exchange"))) - decMarkUpCost - decBrokerageFees;

                decimal decTotalNetCost = decMarkUpCost + decBrokerageFees + decExchangeRate;

                SetCoilQuantityMinMaxRange(decCoilQuantity);

                decimal decTotalCostOfTheCoil = (GetSetupValue("BOOSTER") / ((_decCoilQuantityMinRange + _decCoilQuantityMaxRange) / 2m)) + decTotalNetCost;

                _decTotalPrice = Math.Ceiling(Math.Floor(((decTotalCostOfTheCoil / Convert.ToDecimal(CoilPriceOption("ListPriceMult"))) * 100m) + 0.5m) / 100m);
            }
            catch(Exception ex)
            {
                Public.PushLog(ex.ToString(), "BoosterCoil  BoosterCoil");
                _decTotalPrice = 0m;
            }
        }

        //return the multiplier for labor press for even/odd tubes
        private decimal GetLaborPressPunchingMultiplierForEvenOrOddTubes(decimal decFinHeight, decimal decFaceTube)
        {
            decimal decOddOrEven = decFinHeight/decFaceTube/2m;
            return decOddOrEven > Math.Floor(decOddOrEven) ? 2m : 1m;
        }


        //get the setup value
        private decimal GetSetupValue(string strSetupType)
        {
            return Convert.ToDecimal(Public.DSDatabase.Tables["PricingCoilSetup"].Copy().Select("Setup = '" + strSetupType + "'")[0]["Value"]);
        }

        //Set Coil Quantity Min Max Range
        private void SetCoilQuantityMinMaxRange(decimal decCoilQuantity)
        {
            //select the min max
            DataRow[] drPricingCoilQuantityRange = Public.DSDatabase.Tables["PricingCoilQuantityRange"].Copy().Select("QuantityMin <= " + decCoilQuantity + " AND QuantityMax >= " + decCoilQuantity);

            //set value
            _decCoilQuantityMinRange = Convert.ToDecimal(drPricingCoilQuantityRange[0]["QuantityMin"]);
            _decCoilQuantityMaxRange = Convert.ToDecimal(drPricingCoilQuantityRange[0]["QuantityMax"]);

            //dispose
        }

        //Get Labor Testing
        private decimal GetLaborTesting(decimal decFinLength)
        {
            return Convert.ToDecimal(CoilPriceOption("RedBrassConnQty")) > 0m ||
                   Convert.ToDecimal(CoilPriceOption("DistributorQty")) > 0m
                ? 2m + (2m + (decFinLength*0.2m))
                : 2m + (decFinLength*0.15m);
        }


        //Get Labor Welded Casing
        private decimal GetLaborWeldedCasing()
        {
            return CoilPriceOption("Welding") != "False" ? 45m : 0m;
        }

        //return labor expansion
        private decimal GetLaborExpansion(string strFinType, decimal decNumberOfRows, decimal decFinLength, decimal decFinHeight)
        {
            if (CoilPriceOption("VertExpan") != "False")
            {
                return 0m;
            }
            if (strFinType == "Z" || strFinType == "A")
            {
                return (decFinHeight / _decFaceTube) * decNumberOfRows / 2m * decFinLength * 0.011m;
            }
            if (Convert.ToDecimal(CoilPriceOption("TopBottomPlatesQty")) == 0m && decNumberOfRows <= 6m && (decFinHeight / _decFaceTube) <= 18m)
            {
                return (decFinHeight / _decFaceTube) * decNumberOfRows / 2m * decFinLength * 0.011m;
            }
            return (decFinHeight / _decFaceTube) * decNumberOfRows / 6m * decFinLength * 0.0037m;
        }


        //Get Straight Tube Cutting Factor
        private decimal GetStraightTubeCuttingFactor(decimal decFinLength)
        {
            //returned value

            //select what we want
            DataRow[] drStraightTubeCuttingFactor = Public.DSDatabase.Tables["StraightTubeCuttingFactor"].Copy().Select("FinLength <=" + decFinLength);

            //clone the table
            DataTable dtStraightTubeCuttingFactor = Public.DSDatabase.Tables["StraightTubeCuttingFactor"].Clone();

            //for each result add it to the temp table
            for (int intResult = 0; intResult < drStraightTubeCuttingFactor.Length; intResult++)
            {
                dtStraightTubeCuttingFactor.Rows.Add(drStraightTubeCuttingFactor[intResult].ItemArray);
            }

            //need to sort
            DataView dvStraightTubeCuttingFactor = dtStraightTubeCuttingFactor.DefaultView;
            dvStraightTubeCuttingFactor.Sort = "FinLength DESC";

            //set value
            decimal decReturnValue = Convert.ToDecimal(dvStraightTubeCuttingFactor.ToTable().Rows[0]["FinFactor"]);

            //dispose
            dvStraightTubeCuttingFactor.Dispose();
            dtStraightTubeCuttingFactor.Dispose();

            return decReturnValue;
        }


        //return header price
        private decimal GetHeaderPrice(decimal decHeaderDiameter)
        {
            return Convert.ToDecimal(Public.DSDatabase.Tables["PricingCoilHeader"].Copy().Select("HeaderDiameter = " + decHeaderDiameter)[0]["CostPerFoot"]);
        }

        //Get Quantity Of Center Plate
        private decimal GetQuantityOfCenterPlate(decimal decFinLength)
        {
            return decFinLength <= 48m ? 0m : 1m;
        }

        //return the value of the column of PricingCoilSetting, i used
        //the name CoilPriceOption because it refer to the array in the old
        //refplus quotes program. It return a string, so it still need to be converted
        private string CoilPriceOption(string strColumn)
        {
            return Public.DSDatabase.Tables["PricingCoilSetting"].Rows[0][strColumn].ToString();
        }

        //Get Return Bends Price
        private decimal GetReturnBendsPrice(string strTubeMaterial)
        {
            return strTubeMaterial == "CU-NI" ? 2m : _decReturnBendsCost;
        }

        //set fin type variables
        private void SetFinTypeVariables(string strFinType)
        {
            //select the good fin type
            DataRow[] drCoilFinType = Public.DSDatabase.Tables["CoilFinType"].Copy().Select("FinType = '" + strFinType + "'");

            //fill the variable
            _decTubeDiameter = Convert.ToDecimal(drCoilFinType[0]["TubeDiameter"]);
            _decFaceTube = Convert.ToDecimal(drCoilFinType[0]["FaceTube"]);
            _decTubeRow = Convert.ToDecimal(drCoilFinType[0]["TubeRow"]);
            _decReturnBendsCost = Convert.ToDecimal(drCoilFinType[0]["ReturnBendCost"]);
            _decRowWidth = Convert.ToDecimal(drCoilFinType[0]["RowWidth"]);
            _decPressStrokeMin = Convert.ToDecimal(drCoilFinType[0]["PressStrokeMin"]);

            //dispose the object
        }

        //return the price
        public decimal Price
        {
            get { return _decTotalPrice; }
        }
    }
}