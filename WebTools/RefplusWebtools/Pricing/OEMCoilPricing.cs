using System;
using System.Collections.Generic;
using System.Data;

namespace RefplusWebtools.Pricing
{
    class OEMCoilPricing
    {
        private readonly string[] _strTableList = { "CoilFinMaterial", "CoilCasingMaterial", "CoilTubeMaterial", "PricingReturnBendCost", "PricingMISCSETTING", "CoilCasingMaterial", "HeaderInformation", "Distributor", "FlareFittings", "Relation_Distributor_AuxiliarySideConnection", "AuxiliarySideConneciton", "CorrectionFactors" };

        private decimal _priceCoil;
        private decimal _horPrice;
        private decimal _decNetCostOfCoilWithProfitMargin;
        private decimal _decNetCostOfHorizontalWithProfitMargin;

        private decimal _materialCost;
        private decimal _labourCalculated;
        private decimal _labourCalculatedWithCorrection;
        private decimal _manufacturingOverhead;
        private decimal _hourlyRate;
        private decimal _netCostOfOEMCoil;

        private decimal _weightOfCoil;

        public OEMCoilPricing(
            decimal exchangeRate,
            decimal profit,
            string coilType,
            string finType,
            decimal tubeRow,
            decimal tubeDiameter,
            decimal faceTubeSize,
            decimal pressStrokeMin,
            decimal rowWidth,
            int faceTubes,
            decimal finHeight,
            decimal finLength,
            int rows,
            int fpi,
            string finMaterial,
            decimal finThickness,
            string tubeMaterial,
            decimal tubeThickness,
            string casingMaterial,
            decimal casingThickness,
            int endPlateQuantity,
            decimal endPlateHeight,
            decimal endPlateWidth,
            int topPlateQuantity,
            decimal topPlateHeight,
            decimal topPlateWidth,
            int bottomPlateQuantity,
            decimal bottomPlateHeight,
            decimal bottomPlateWidth,
            int centerPlateQuantity,
            decimal centerPlateHeight,
            decimal centerPlateWidth,
            int returnBendsQty,
            int drainPanQuantity,
            string drainPanMaterial,
            decimal drainPanHeight,
            decimal drainPanWidth,
            int damperQuantity,
            decimal damperHeight,
            decimal damperWidth,
            bool selectedThreadedConnection,
            int threadedConnectionQuantity,
            decimal threadedConnectionDiameter,
            int ventsQuantity,
            int spigotQuantity,
            List<Headers> connections,
            bool selectedDistributor,
            List<Distributor> distributors,
            bool selectedFlareFitting,
            IEnumerable<FlareFitting> flareFittings,
            bool selectedAuxiliarySideConnection,
            bool selectedWeldNuts,
            int weldNutQuantity,
            bool selectedSpecialCustomFitting,
            decimal specialCustomFittingPrice,
            bool selectedWeldCasing,
            bool selectedDrainPan,
            bool selectedDamper,
            bool overheadRemoved)
        {
            Query.LoadTables(_strTableList);

            CalculatePrice(
                 exchangeRate, 
                 profit,
                 coilType,
                 finType,
                 tubeRow,
                 tubeDiameter,
                 faceTubeSize,
                 pressStrokeMin,
                 rowWidth,
                 faceTubes,
                 finHeight,
                 finLength,
                 rows,
                 fpi,
                 finMaterial,
                 finThickness,
                 tubeMaterial,
                 tubeThickness,
                 casingMaterial,
                 casingThickness,
                 endPlateQuantity,
                 endPlateHeight,
                 endPlateWidth,
                 topPlateQuantity,
                 topPlateHeight,
                 topPlateWidth,
                 bottomPlateQuantity,
                 bottomPlateHeight,
                 bottomPlateWidth,
                 centerPlateQuantity,
                 centerPlateHeight,
                 centerPlateWidth,
                 returnBendsQty,
                 drainPanQuantity,
                 drainPanMaterial,
                 drainPanHeight,
                 drainPanWidth,
                 damperQuantity,
                 damperHeight,
                 damperWidth,
                 selectedThreadedConnection,
                 threadedConnectionQuantity,
                 threadedConnectionDiameter,
                 ventsQuantity,
                 spigotQuantity,
                 connections,
                 selectedDistributor,
                 distributors,
                 selectedFlareFitting,
                 flareFittings,
                 selectedAuxiliarySideConnection,
                 selectedWeldNuts,
                 weldNutQuantity,
                 selectedSpecialCustomFitting,
                 specialCustomFittingPrice,
                 selectedWeldCasing,
                 selectedDrainPan,
                 selectedDamper,
                 overheadRemoved);

            CalculateWeight(coilType,
               tubeRow,
               tubeDiameter,
               faceTubeSize,
               faceTubes,
               finHeight,
               finLength,
               rows,
               fpi,
               finMaterial,
               finThickness,
               tubeMaterial,
               tubeThickness,
               casingMaterial,
               casingThickness,
               endPlateQuantity,
               endPlateHeight,
               endPlateWidth,
               topPlateQuantity,
               topPlateHeight,
               topPlateWidth,
               bottomPlateQuantity,
               bottomPlateHeight,
               bottomPlateWidth,
               centerPlateQuantity,
               centerPlateHeight,
               centerPlateWidth,
               drainPanQuantity,
               drainPanMaterial,
               drainPanHeight,
               drainPanWidth,
               connections,
               selectedDrainPan,
               selectedDamper);
        }

        public decimal GetPriceCoil()
        {
            return _priceCoil;
        }

        public decimal GetHorPrice()
        {
            return _horPrice;
        }

        public decimal getNetCostOfCoil_WithProfitMargin()
        {
            return _decNetCostOfCoilWithProfitMargin;
        }

        public decimal getNetCostOfHorizontal_WithProfitMargin()
        {
            return _decNetCostOfHorizontalWithProfitMargin;
        }

        public decimal GetMaterialCost()
        {
            return _materialCost;
        }

        public decimal GetLabourCalculated()
        {
            return _labourCalculated;
        }

        public decimal GetLabourCalculatedWithCorrection()
        {
            return _labourCalculatedWithCorrection;
        }

        public decimal GetManufacturingOverhead()
        {
            return _manufacturingOverhead;
        }

        public decimal GetHourlyRate()
        {
            return _hourlyRate;
        }

        public decimal GetNetCostOfOEMCoil()
        {
            return _netCostOfOEMCoil;
        }

        public decimal GetWeight()
        {
            return _weightOfCoil;
        }

        private void CalculateWeight(string coilType,
            decimal tubeRow,
            decimal tubeDiameter,
            decimal faceTubeSize,
            int faceTubes,
            decimal finHeight,
            decimal finLength,
            int rows,
            int fpi,
            string finMaterial,
            decimal finThickness,
            string tubeMaterial,
            decimal tubeThickness,
            string casingMaterial,
            decimal casingThickness,
            int endPlateQuantity,
            decimal endPlateHeight,
            decimal endPlateWidth,
            int topPlateQuantity,
            decimal topPlateHeight,
            decimal topPlateWidth,
            int bottomPlateQuantity,
            decimal bottomPlateHeight,
            decimal bottomPlateWidth,
            int centerPlateQuantity,
            decimal centerPlateHeight,
            decimal centerPlateWidth,
            int drainPanQuantity,
            string drainPanMaterial,
            decimal drainPanHeight,
            decimal drainPanWidth,
            IEnumerable<Headers> connections,
            bool selectedDrainPan,
            bool selectedDamper)
        {
            _weightOfCoil = 0m;

            _weightOfCoil += GetWeightOfFin(finHeight, finLength, rows, fpi, tubeRow, finMaterial, finThickness);

            _weightOfCoil += GetTubeWeight(coilType, faceTubeSize, faceTubes, rows, finLength, tubeDiameter, tubeMaterial, tubeThickness);

            _weightOfCoil += GetWeightOfCasing(casingMaterial, casingThickness, bottomPlateQuantity, bottomPlateHeight, bottomPlateWidth);

            _weightOfCoil += GetWeightOfCasing(casingMaterial, casingThickness, centerPlateQuantity, centerPlateHeight, centerPlateWidth);

            _weightOfCoil += GetWeightOfCasing(casingMaterial, casingThickness, topPlateQuantity, topPlateHeight, topPlateWidth);

            _weightOfCoil += GetWeightOfCasing(casingMaterial, casingThickness, endPlateQuantity, endPlateHeight, endPlateWidth);

            if (coilType == "W" || coilType == "B" || coilType == "S" || coilType == "N" || coilType == "D")
            {
                if (selectedDrainPan)
                {
                    _weightOfCoil += GetWeightOfCasing(ParseDrainPanMaterial(drainPanMaterial), casingThickness, drainPanQuantity, drainPanHeight, drainPanWidth);
                }

                if (selectedDamper)
                {
                    _weightOfCoil += GetWeightOfCasing(casingMaterial, casingThickness, drainPanQuantity, drainPanHeight, drainPanWidth);
                }
            }

            foreach (Headers h in connections)
            {
                _weightOfCoil += GetWeightOfHeader(h.Diameter, h.Length);
            }

            _weightOfCoil += GetScrappedWeight(_weightOfCoil);
        }

        private string ParseDrainPanMaterial(string drainPanMaterial)
        {
            if (drainPanMaterial == "GALV. STEEL")
            {
                return "Galvanized Steel";
            }
            if (drainPanMaterial == "ST. STEEL 304")
            {
                return "Stainless Steel 304";
            }
            if (drainPanMaterial == "ST. STEEL 316")
            {
                return "Stainless Steel 316";
            }

            return drainPanMaterial;
        }

        private decimal GetScrappedWeight(decimal weight)
        {
            return weight * (GetMiscSettingPrice(7) / 100m);
        }

        private decimal GetWeightOfHeader(decimal headerDiameter, decimal headerLength)
        {
            return headerLength * GetHeaderDiameterWeight(headerDiameter) / 12m; 
        }

        private static decimal GetHeaderDiameterWeight(decimal headerDiameter)
        {
            return Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["HeaderInformation"], "CopperHeaderDiameter = " + headerDiameter, "").Rows[0]["LBSft"]);
        }

        private decimal GetWeightOfCasing(string casingMaterial, decimal casingThickness, int quanity, decimal height, decimal width)
        {
            return quanity * casingThickness * height * width * GetCasingMaterialDensity(casingMaterial);
        }

        private decimal GetTubeWeight(string coilType, decimal faceTubeSize, int faceTubes, int rows, decimal finLength, decimal tubeDiameter, string tubeMaterial, decimal tubeThickness)
        {
            decimal tubeWeight = 0m;

            if (coilType == "N")
            {
                tubeWeight += GetTubeLength(faceTubes, rows, finLength, faceTubeSize) * GetTubeSurfaceSection(tubeDiameter, tubeThickness) * GetTubeMaterialDensity(tubeMaterial);
                tubeWeight += GetTubeLength(faceTubes, rows, finLength, faceTubeSize) * GetTubeSurfaceSection(0.375m, tubeThickness) * GetTubeMaterialDensity(tubeMaterial);
            }
            else
            {
                tubeWeight += GetTubeLength(faceTubes, rows, finLength, faceTubeSize) * GetTubeSurfaceSection(tubeDiameter, tubeThickness) * GetTubeMaterialDensity(tubeMaterial);
            }

            return tubeWeight;
        }

        private decimal GetWeightOfFin(decimal finHeight, decimal finLength, int rows, int fpi, decimal tubeRow, string finMaterial, decimal finThickness)
        {
            decimal materialDensity = Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilFinMaterial"], "FinMaterial = '" + finMaterial + "'", "").Rows[0]["MaterialDensity"]);

            return materialDensity * GetQtyOfFin(finHeight, finLength, rows, fpi, tubeRow, finThickness);
        }

        private static decimal GetQtyOfFin(decimal finHeight, decimal finLength, int rows, int fpi, decimal tubeRow, decimal finThickness)
        {
            return finHeight * rows * tubeRow * finLength * fpi * finThickness;
        }

        private void CalculatePrice(
            decimal exchangeRate, 
            decimal profit,
            string coilType,
            string finType,
            decimal tubeRow,
            decimal tubeDiameter,
            decimal faceTubeSize,
            decimal pressStrokeMin,
            decimal rowWidth,
            int faceTubes,
            decimal finHeight,
            decimal finLength,
            int rows,
            int fpi,
            string finMaterial,
            decimal finThickness,
            string tubeMaterial,
            decimal tubeThickness,
            string casingMaterial,
            decimal casingThickness,
            int endPlateQuantity,
            decimal endPlateHeight,
            decimal endPlateWidth,
            int topPlateQuantity,
            decimal topPlateHeight,
            decimal topPlateWidth,
            int bottomPlateQuantity,
            decimal bottomPlateHeight,
            decimal bottomPlateWidth,
            int centerPlateQuantity,
            decimal centerPlateHeight,
            decimal centerPlateWidth,
            int returnBendsQty,
            int drainPanQuantity,
            string drainPanMaterial,
            decimal drainPanHeight,
            decimal drainPanWidth,
            int damperQuantity,
            decimal damperHeight,
            decimal damperWidth,
            bool selectedThreadedConnection,
            int threadedConnectionQuantity,
            decimal threadedConnectionDiameter,
            int ventsQuantity,
            int spigotQuantity,
            List<Headers> connections,
            bool selectedDistributor,
            List<Distributor> distributors,
            bool selectedFlareFitting,
            IEnumerable<FlareFitting> flareFittings,
            bool selectedAuxiliarySideConnection,
            bool selectedWeldNuts,
            int weldNutQuantity,
            bool selectedSpecialCustomFitting,
            decimal specialCustomFittingPrice,
            bool selectedWeldCasing,
            bool selectedDrainPan,
            bool selectedDamper,
            bool overheadRemoved)
        {
         
            decimal costFins = GetFinCost(finMaterial, finHeight, rows, tubeRow, finLength, fpi, finThickness);

            decimal costCopperTube = GetTubeCost(finType, tubeMaterial, tubeDiameter, tubeThickness, faceTubes, rows, finLength, faceTubeSize);

            decimal costReturnBends = GetCostOfReturnBends(returnBendsQty, finType, tubeMaterial);

            const decimal costCrossover = 0m;

            decimal costEndPlates = endPlateQuantity * GetCostOfEndPlate(casingMaterial, casingThickness, endPlateHeight, endPlateWidth);

            decimal costTopPlate = topPlateQuantity * GetCostOfTopBottomPlate(casingMaterial, casingThickness, topPlateHeight, topPlateWidth);

            decimal costBottomPlate = bottomPlateQuantity * GetCostOfTopBottomPlate(casingMaterial, casingThickness, bottomPlateHeight, bottomPlateWidth);

            decimal costCenterPlate = centerPlateQuantity * GetCostOfCenterPlate(casingMaterial, casingThickness, centerPlateHeight, centerPlateWidth);

            decimal costDrainPan = 0m;
            decimal costDamper = 0m;
            decimal costThreadedConnection = 0m;
            decimal costVents = 0m;
            decimal costSpigots;

            switch (coilType)
            {
                case "W":
                case "B":
                case "S":
                case "N":

                    if (selectedDrainPan)
                    {
                        costDrainPan = getCostOfDrainPan_Damper(drainPanQuantity, drainPanMaterial, drainPanHeight, drainPanWidth);
                    }

                    if (selectedDamper)
                    {
                        costDamper = damperQuantity * GetCostOfTopBottomPlate(casingMaterial, casingThickness, damperHeight, damperWidth);
                    }

                    if (selectedThreadedConnection)
                    {
                        costThreadedConnection = GetCostOfThreadedConnection(tubeMaterial, threadedConnectionQuantity, threadedConnectionDiameter);

                        costVents = GetCostOfVents(ventsQuantity);
                    }
                    costSpigots = GetCostOfSpigots(tubeMaterial, spigotQuantity, tubeDiameter);

                    break;
                case "D":

                    if (selectedDrainPan)
                    {
                        costDrainPan = getCostOfDrainPan_Damper(drainPanQuantity, drainPanMaterial, drainPanHeight, drainPanWidth);
                    }

                    if (selectedDamper)
                    {
                        costDamper = damperQuantity * GetCostOfTopBottomPlate(casingMaterial, casingThickness, damperHeight, damperWidth);
                    }

                    costSpigots = GetCostOfSpigots(tubeMaterial, spigotQuantity, tubeDiameter);

                    break;
                default:

                    costSpigots = GetCostOfSpigots(tubeMaterial, spigotQuantity, tubeDiameter);

                    break;
            }

            var costHeaders = new List<decimal>();

            foreach (Headers h in connections)
            {
                costHeaders.Add(GetCostOfHeader(tubeMaterial, h.Diameter, h.Length));
            }

            var costDistributors = new List<decimal>();
            var costDistributorLines = new List<decimal>();

            if (selectedDistributor)
            {
                foreach (Distributor dist in distributors)
                {
                    costDistributors.Add(GetCostOfDistributor(dist.Model));
                    costDistributorLines.Add(GetCostOfDistributorLine(dist.Model, tubeMaterial));
                }
            }

            if (coilType == "D" && selectedDistributor)
            {
                costSpigots = GetCostOfSpigots(tubeMaterial, Convert.ToInt32(GetNumberOfSpigotsForEvapCoil(distributors[distributors.Count - 1].Model)), tubeDiameter);
            }
            else if (coilType == "D" && !selectedDistributor)
            {
                costSpigots = GetCostOfSpigots(tubeMaterial, Convert.ToInt32(GetNumberOfSpigots(faceTubes)), tubeDiameter);
            }

            costSpigots = Math.Floor((costSpigots * 100m) + 0.5m) / 100m;

            decimal costFlareFittings = 0m;

            if (selectedFlareFitting)
            {
                foreach (FlareFitting fitting in flareFittings)
                {
                    costFlareFittings += fitting.Quantity * GetCostOfFlareFitting(fitting.Model);
                }
            }

            decimal costAsc = 0m;

            if (selectedAuxiliarySideConnection)
            {
                foreach (Distributor dist in distributors)
                {
                    costAsc += GetCostOfASC(dist.Model);
                }
            }

            decimal costWeldNuts = 0m;

            if (selectedWeldNuts)
            {
                costWeldNuts = GetCostOfWeldNut(weldNutQuantity);
            }

            decimal totalCosts = 0m;

            totalCosts += costFins +
                          costCopperTube +
                          costReturnBends +
                          costCrossover +
                          costEndPlates +
                          costTopPlate +
                          costBottomPlate +
                          costCenterPlate +
                          costDrainPan +
                          costDamper;

            foreach (decimal d in costHeaders)
            {
                totalCosts += d;
            }

            totalCosts += costThreadedConnection +
                          costVents +
                          costSpigots;

            foreach (decimal d in costDistributors)
            {
                totalCosts += d;
            }

            foreach (decimal d in costDistributorLines)
            {
                totalCosts += d;
            }

            totalCosts += costFlareFittings +
                          costAsc +
                          costWeldNuts;

            if (selectedSpecialCustomFitting)
            {
                totalCosts += specialCustomFittingPrice;
            }

            decimal costCrating = GetCostOfCrating(finMaterial, tubeMaterial, totalCosts);

            decimal costScrap = GetCostOfScrap(finMaterial, tubeMaterial, totalCosts);

            decimal costTotalMaterialCost = totalCosts + 
                                            costCrating + 
                                            costScrap;

            decimal labourFinPressPunching = GetLabourOfFinPressPunching(finMaterial, finLength, fpi, faceTubes, rows, pressStrokeMin, rowWidth);

            decimal labourCopperTubeCutting = GetLabourOfCopperTubeCutting(coilType, finType, faceTubes, rows, tubeMaterial, finLength);

            decimal labourSheetMetalTop = GetLabourOfTopBottomSheetMetal(topPlateQuantity, rows, finLength);

            decimal labourSheetMetalBottom = GetLabourOfTopBottomSheetMetal(bottomPlateQuantity, rows, finLength);

            decimal labourSheetMetalEnd = GetLabourOfEndSheetMetal(endPlateQuantity, faceTubes, rows);

            decimal labourSheetMetalCenter = GetLabourOfCenterSheetMetal(centerPlateQuantity, faceTubes, rows);

            decimal labourCoilAssembly = GetLabourOfCoilAssembly(finType, faceTubes, rows, finMaterial, tubeMaterial, finLength);

            decimal labourExpansion = GetLabourOfCoilExpansion(topPlateQuantity, coilType, finType, faceTubes, rows, tubeMaterial, finLength);

            decimal labourWeldedCassing = GetLabourOfCaseWelding(selectedWeldCasing);

            decimal labourWeldingweldnut = GetLabourOfWeldingNut(weldNutQuantity);

            decimal laboutHeaderCuttingPunching = GetLabourOfHeaderCuttingPunching(finMaterial, tubeMaterial, connections.Count);

            decimal qSpigots = 0m;
            decimal labourDistributorLineAssembly = 0m;

            if (coilType == "D")
            {
                if (selectedDistributor)
                {
                    foreach (Distributor dist in distributors)
                    {
                        qSpigots += GetNumberOfSpigotsForEvapCoil(dist.Model);
                    }

                    labourDistributorLineAssembly = GetLabourOfDistributorAndLineAssembly(connections.Count, qSpigots);
                }
                else
                {
                    qSpigots = connections.Count == 0 ? spigotQuantity : GetNumberOfSpigots(faceTubes);
                }
            }
            else
            {
                qSpigots = spigotQuantity;
            }

            decimal labourReturnBendFlyCutFlareAssembly = GetLabourOfReturnBendFlyCutFlareAssembly(finType, faceTubes, rows, tubeMaterial, finLength);

            decimal labourReturnBendBrazing = GetLabourOfReturnBendBrazing(finType, faceTubes, rows, tubeMaterial, finLength);

            decimal labourBrazingSpigots = GetLabourOfBrazingSpigots(connections, qSpigots);

            decimal labourTesting = GetLabourOfTesting(finMaterial, tubeMaterial, finLength, selectedThreadedConnection, selectedDistributor, selectedFlareFitting);

            decimal labourCRATING = GetLabourOfCrating(faceTubes, rows, finLength);

            decimal totalLabour = labourFinPressPunching +
                                  labourCopperTubeCutting +
                                  labourSheetMetalTop +
                                  labourSheetMetalBottom +
                                  labourSheetMetalEnd +
                                  labourSheetMetalCenter +
                                  labourCoilAssembly +
                                  labourExpansion +
                                  labourWeldedCassing +
                                  labourWeldingweldnut +
                                  laboutHeaderCuttingPunching +
                                  labourDistributorLineAssembly +
                                  labourReturnBendFlyCutFlareAssembly +
                                  labourReturnBendBrazing +
                                  labourBrazingSpigots +
                                  labourTesting +
                                  labourCRATING;

            decimal totalHorLabor = labourFinPressPunching +
                                    GetLabourOfCopperTubeCutting(coilType, finType, faceTubes, rows, tubeMaterial, finLength, true) +
                                    labourSheetMetalTop +
                                    labourSheetMetalBottom +
                                    labourSheetMetalEnd +
                                    labourSheetMetalCenter +
                                    GetLabourOfCoilAssembly(finType, faceTubes, rows, finMaterial, tubeMaterial, finLength, true) +
                                    GetLabourOfCoilExpansion(topPlateQuantity, coilType, finType, faceTubes, rows, tubeMaterial, finLength, true) +
                                    labourWeldedCassing +
                                    labourWeldingweldnut +
                                    laboutHeaderCuttingPunching +
                                    labourDistributorLineAssembly +
                                    GetLabourOfReturnBendFlyCutFlareAssembly(faceTubes, rows, OEMCoil.OEMCode.ExpansionType.Horizontal) +
                                    GetLabourOfReturnBendBrazing(faceTubes, rows, tubeMaterial, OEMCoil.OEMCode.ExpansionType.Horizontal) +
                                    labourBrazingSpigots +
                                    labourTesting +
                                    labourCRATING;

            decimal labourMisc = GetLabourOfMisc(totalLabour);
            decimal labourTotalLabourCost = (totalLabour + labourMisc) * GetCorrectionFactor(coilType, finType, faceTubes, rows, tubeMaterial, finLength, finMaterial, selectedWeldCasing, selectedDistributor);

            decimal totalHorLabourCosts = (totalHorLabor + GetLabourOfMisc(totalHorLabor)) * GetCorrectionFactor(coilType, finType, faceTubes, rows, tubeMaterial, finLength, finMaterial, selectedWeldCasing, selectedDistributor);

            _priceCoil = costTotalMaterialCost + (labourTotalLabourCost * GetLabourHourlyRateInMinutes()) + (overheadRemoved ? (0) : labourTotalLabourCost * GetLabourHourlyRateInMinutes() * GetLabourBurden(finMaterial, tubeMaterial));

            _horPrice = costTotalMaterialCost + (totalHorLabourCosts * GetLabourHourlyRateInMinutes()) + (overheadRemoved ? (0) : labourTotalLabourCost * GetLabourHourlyRateInMinutes() * GetLabourBurden(finMaterial, tubeMaterial));//totalHorLabourCosts * GetLabourHourlyRateInMinutes() * GetLabourBurden(finMaterial, tubeMaterial));

            if (exchangeRate != 1)
            {
                _decNetCostOfCoilWithProfitMargin = (_priceCoil / (2m - (profit / 100m)));
                _decNetCostOfHorizontalWithProfitMargin = (_horPrice / (2m - (profit / 100m)));

                decimal duty = _decNetCostOfCoilWithProfitMargin * GetDutyFactor();

                _decNetCostOfCoilWithProfitMargin = duty + (_decNetCostOfCoilWithProfitMargin * exchangeRate);
                _decNetCostOfHorizontalWithProfitMargin = (_decNetCostOfHorizontalWithProfitMargin * GetDutyFactor()) + (_decNetCostOfHorizontalWithProfitMargin * exchangeRate);
            }
            else
            {
                _decNetCostOfCoilWithProfitMargin = (_priceCoil / (2m - (profit / 100m)));
                _decNetCostOfHorizontalWithProfitMargin = (_horPrice / (2m - (profit / 100m)));
            }

            _materialCost = costTotalMaterialCost;
            _labourCalculated = labourTotalLabourCost / GetCorrectionFactor(coilType, finType, faceTubes, rows, tubeMaterial, finLength, finMaterial, selectedWeldCasing, selectedDistributor) * GetLabourHourlyRateInMinutes();
            _labourCalculatedWithCorrection = labourTotalLabourCost * GetLabourHourlyRateInMinutes();
            _manufacturingOverhead = (overheadRemoved
                ? (0)
                : labourTotalLabourCost*GetLabourHourlyRateInMinutes()*GetLabourBurden(finMaterial, tubeMaterial));
            _hourlyRate = GetLabourHourlyRateInMinutes() * 60m;
            _netCostOfOEMCoil = labourTotalLabourCost * GetLabourHourlyRateInMinutes() + _manufacturingOverhead + costTotalMaterialCost;
        }

        private decimal GetDutyFactor()
        {
            return GetMiscSettingPrice(13) / 100m;
        }

        private decimal GetLabourBurden(string finMaterial, string tubeMaterial)
        {
            return GetMiscSettingPrice(!IsStainlessSteel(finMaterial, tubeMaterial) ? 12 : 15);
        }

        private decimal GetLabourHourlyRateInMinutes()
        {
            return GetMiscSettingPrice(11) / 60m;
        }

        private decimal GetCorrectionFactor(string coilType, string finType, int faceTubes, int rows, string tubeMaterial, decimal finLength, string finMaterial, bool selectedWeldCasing, bool selectedDistributor)
        {
            var code = new OEMCoil.OEMCode();

            string expType = (code.GetExpansionType(finType, faceTubes, rows, tubeMaterial, finLength) == OEMCoil.OEMCode.ExpansionType.Horizontal ? "HORIZONTAL" : "VERTICAL");

            DataTable dtCorrectionFactor = Public.SelectAndSortTable(Public.DSDatabase.Tables["CorrectionFactors"], "", "CoilType,ExpansionType,WeldedCasing, Distributor");

            int currentRecord = 0;

            for (int i = currentRecord; i < dtCorrectionFactor.Rows.Count; i++)
            {
                if (dtCorrectionFactor.Rows[i]["CoilType"].ToString() == coilType)
                {
                    currentRecord = i;
                    i = dtCorrectionFactor.Rows.Count;
                }
            }

            for (int i = currentRecord; i < dtCorrectionFactor.Rows.Count; i++)
            {
                if (dtCorrectionFactor.Rows[i]["ExpansionType"].ToString() == expType)
                {
                    currentRecord = i;
                    i = dtCorrectionFactor.Rows.Count;
                }
            }

            for (int i = currentRecord; i < dtCorrectionFactor.Rows.Count; i++)
            {
                if (dtCorrectionFactor.Rows[i]["WeldedCasing"].ToString() == (selectedWeldCasing ? "YES" : "NO"))
                {
                    currentRecord = i;
                    i = dtCorrectionFactor.Rows.Count;
                }
            }

            for (int i = currentRecord; i < dtCorrectionFactor.Rows.Count; i++)
            {
                if (dtCorrectionFactor.Rows[i]["Distributor"].ToString() == (selectedDistributor ? "YES" : "NO"))
                {
                    currentRecord = i;
                    i = dtCorrectionFactor.Rows.Count;
                }
            }



            return IsStainlessSteel(finMaterial, tubeMaterial) ? 1.5m : Convert.ToDecimal(dtCorrectionFactor.Rows[currentRecord]["CorrectionFactor"]);
        }

        private decimal GetLabourOfMisc(decimal totalLabour)
        {
            return totalLabour * (GetMiscSettingPrice(10) / 100m);
        }

        private static decimal GetLabourOfCrating(int faceTubes, int rows, decimal finLength)
        {
            return faceTubes * (decimal)rows * finLength * 0.0025m;
        }

        private decimal GetLabourOfTesting(string finMaterial, string tubeMaterial, decimal finLength, bool selectedThreadedConnection, bool selectedDistributor, bool selectedFlareFitting)
        {
            decimal labourOfTesting;

            if (IsStainlessSteel(finMaterial, tubeMaterial))
            {
                if (selectedThreadedConnection || selectedFlareFitting)
                {
                    labourOfTesting = 2m + (2m + (finLength * 0.2m));
                }
                else
                {
                    labourOfTesting = 2m + (finLength * 0.15m);
                }
            }
            else
            {
                if (selectedThreadedConnection || selectedDistributor || selectedFlareFitting)
                {
                    labourOfTesting = 2m + (2m + (finLength * 0.15m));
                }
                else
                {
                    labourOfTesting = 2m + (finLength * 0.1m);
                }
            }

            return labourOfTesting;
        }

        private decimal GetLabourOfBrazingSpigots(List<Headers> connections, decimal qSpigots)
        {
            decimal labourOfBrazingSpigots;

            if (CheckLengthForSpigotBrazing(connections))
            {
                labourOfBrazingSpigots = connections.Count * qSpigots * 0.43m;
            }
            else
            {
                labourOfBrazingSpigots = connections.Count * qSpigots * 0.616m;
            }

            return labourOfBrazingSpigots;
        }

        private static bool CheckLengthForSpigotBrazing(IEnumerable<Headers> connections)
        {
            bool lengthForSpigotBrazing = false;

            foreach (Headers h in connections)
            {
                if (h.Length <= 6m)
                {
                    lengthForSpigotBrazing = true;
                }
            }

            return lengthForSpigotBrazing;
        }

        private decimal GetLabourOfReturnBendBrazing(string finType, int faceTubes, int rows, string tubeMaterial, decimal finLength)
        {
            var code = new OEMCoil.OEMCode();

            return GetLabourOfReturnBendBrazing(faceTubes, rows, tubeMaterial, code.GetExpansionType(finType, faceTubes, rows, tubeMaterial, finLength));
        }

        private decimal GetLabourOfReturnBendBrazing(int faceTubes, int rows, string tubeMaterial, OEMCoil.OEMCode.ExpansionType expType)
        {
            if (expType == OEMCoil.OEMCode.ExpansionType.Vertical)
            {
                return faceTubes * (decimal)rows / 2m * 0.3m;
            }
            if (!tubeMaterial.StartsWith("Stainless Steel"))
            {
                return faceTubes * (decimal)rows * 0.45m;
            }
            return faceTubes * (decimal)rows * 0.55m;
        }

        private decimal GetLabourOfReturnBendFlyCutFlareAssembly(string finType, int faceTubes, int rows, string tubeMaterial, decimal finLength)
        {
            var code = new OEMCoil.OEMCode();
            return GetLabourOfReturnBendFlyCutFlareAssembly(faceTubes, rows, code.GetExpansionType(finType, faceTubes, rows, tubeMaterial, finLength));
        }

        private decimal GetLabourOfReturnBendFlyCutFlareAssembly(int faceTubes, int rows, OEMCoil.OEMCode.ExpansionType expType)
        {
            if (expType == OEMCoil.OEMCode.ExpansionType.Vertical)
            {
                return faceTubes * (decimal)rows / 2m * 0.2m;
            }
                return faceTubes * (decimal)rows * 0.33m;
        }

        private static decimal GetLabourOfDistributorAndLineAssembly(int numberOfHeaders, decimal qSPIGOTS)
        {
            return (qSPIGOTS * 0.6m) + (numberOfHeaders * 4m) + (qSPIGOTS * 0.25m * 2m);
        }

        private static decimal GetNumberOfSpigots(int faceTubes)
        {
            return Math.Floor(faceTubes * 2m);
        }

        private static decimal GetNumberOfSpigotsForEvapCoil(string distributorModel)
        {
            return Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["Distributor"], "DistributorModel LIKE '" + distributorModel + "%'", "").Rows[0]["NumberOfCircuits"]);
        }

        private decimal GetLabourOfHeaderCuttingPunching(string finMaterial, string tubeMaterial, int numberOfHeaders)
        {
            if (IsStainlessSteel(finMaterial, tubeMaterial))
            {
                return  10m * numberOfHeaders;
            }
                return 2m * numberOfHeaders;
            
        }

        private static decimal GetLabourOfWeldingNut(int weldNutQuantity)
        {
            return weldNutQuantity * 0.3m;
        }

        private decimal GetLabourOfCaseWelding(bool selectedWeldCasing)
        {

            if (selectedWeldCasing)
            {
                return GetMiscSettingPrice(9);
            }
                return 0m;


            
        }

        private decimal GetLabourOfCoilExpansion(int topPlateQuantity, string coilType, string finType, int faceTubes, int rows, string tubeMaterial, decimal finLength, bool forceHorizontal = false)
        {
            decimal coilExpansion;

            decimal eTime = coilType == "N" ? 2m : 1m;

            var code = new OEMCoil.OEMCode();

            if (forceHorizontal || code.GetExpansionType(finType, faceTubes, rows, tubeMaterial, finLength) == OEMCoil.OEMCode.ExpansionType.Horizontal)
            {
                if (finType == "G" || finType == "A" || (topPlateQuantity == 0 && rows == 6 && faceTubes <= 18))
                {
                    
                    coilExpansion = faceTubes * (decimal)rows / 2m * finLength * 0.011m;
                }
                else
                {
                    coilExpansion = faceTubes * (decimal)rows / 6m * finLength * 0.0037m;
                }
            }
            else
            {
                coilExpansion = finLength <= 15 ? 2.5m : 5m;
            }

            coilExpansion = coilExpansion * eTime;

            return coilExpansion;
        }

        private decimal GetLabourOfCoilAssembly(string finType, int faceTubes, int rows, string finMaterial, string tubeMaterial, decimal finLength, bool forceHorizontal = false)
        {
            decimal coilAssembly;

            var code = new OEMCoil.OEMCode();

            if (forceHorizontal || code.GetExpansionType(finType, faceTubes, rows, tubeMaterial, finLength) == OEMCoil.OEMCode.ExpansionType.Horizontal)
            {
                if (IsStainlessSteel(finMaterial, tubeMaterial))
                {
                    coilAssembly = rows * (decimal)faceTubes * finLength * 0.005m;
                }
                else
                {
                    coilAssembly = rows * (decimal)faceTubes * finLength * 0.0038m;
                }
            }
            else
            {
                coilAssembly = 0m;
            }

            return coilAssembly;
        }

        private static decimal GetLabourOfCenterSheetMetal(int centerPlateQuantity, int faceTubes, int rows)
        {
            return (2m + (faceTubes * (decimal)rows * 0.045m)) * centerPlateQuantity / 2m;
        }

        private static decimal GetLabourOfEndSheetMetal(int endPlateQuantity, int faceTubes, int rows)
        {
            return (2m + (faceTubes * (decimal)rows * 0.045m)) * endPlateQuantity / 2m;
        }

        private static decimal GetLabourOfTopBottomSheetMetal(int topBottomPlateQuantity, int rows, decimal finLength)
        {
            return (2m + ((rows * 0.035m) * (finLength / 2m))) * topBottomPlateQuantity / 2m;
        }

        private decimal GetLabourOfCopperTubeCutting(string coilType, string finType, int faceTubes, int rows, string tubeMaterial, decimal finLength,bool forceHorizontal = false)
        {
            decimal tubeCutting;

            decimal cutTimes = coilType == "N" ? 2m : 1m;

            var code = new OEMCoil.OEMCode();

            if (forceHorizontal || code.GetExpansionType(finType, faceTubes, rows, tubeMaterial, finLength) == OEMCoil.OEMCode.ExpansionType.Horizontal)
            {
                decimal sctf = cutTimes * StraightTubeCuttingFactor(finLength);
                tubeCutting = Math.Floor(faceTubes * (decimal)rows * sctf * 100m + 0.5m) / 100m;
            }
            else
            {
                decimal sctf = cutTimes * HairpinCuttingFactor(finType, finLength);
                tubeCutting = Math.Floor(faceTubes * (decimal)rows * sctf * 100m + 0.5m) / 100m;
            }

            return tubeCutting;
        }

        private decimal HairpinCuttingFactor(string finType, decimal finLength)
        {
            decimal cuttingFactor;
            
            //2012-09-26 : #3400 : adding pricing for K fin type
            if (finType == "C" || finType == "H" || finType == "D" || finType == "K")
            {
                if (finLength < 11)
                {
                    cuttingFactor = 0.043m;
                }
                else if (finLength < 21)
                {
                    cuttingFactor = 0.06m;
                }
                else if (finLength < 31)
                {
                    cuttingFactor = 0.075m;
                }
                else
                {
                    cuttingFactor = 0.1m;
                }
            }
            else
            {
                if (finLength < 11)
                {
                    cuttingFactor = 0.142m;
                }
                else if (finLength < 21)
                {
                    cuttingFactor = 0.246m;
                }
                else if (finLength < 31)
                {
                    cuttingFactor = 0.25m;
                }
                else
                {
                    cuttingFactor = 0.342m;
                }
            }

            return cuttingFactor;
        }

        private decimal StraightTubeCuttingFactor(decimal finLength)
        {
            decimal cuttingFactor;

            if (finLength < 31)
            {
                cuttingFactor = 0.06m;
            }
            else if (finLength < 71)
            {
                cuttingFactor = 0.13m;
            }
            else if (finLength < 102)
            {
                cuttingFactor = 0.2m;
            }
            else if (finLength < 132)
            {
                cuttingFactor = 0.27m;
            }
            else if (finLength < 360)
            {
                cuttingFactor = 0.34m;
            }
            else
            {
                cuttingFactor = 0.5m;
            }

            return cuttingFactor;
        }

        private decimal GetLabourOfFinPressPunching(string finMaterial,decimal finLength, int fpi, int faceTubes, int rows, decimal pressStrokeMin, decimal rowWidth)
        {
            return Math.Floor(faceTubes * (decimal)rows * finLength * fpi / GetFinPressProgressionType(finMaterial, fpi, faceTubes) / pressStrokeMin / rowWidth / 0.33m * 100m + 0.5m) / 100m;
        }

        private static decimal GetFinPressProgressionType(string finMaterial, int fpi, int faceTubes)
        {
            decimal finPressProgressionType;

            if (!finMaterial.StartsWith("Stainless Steel"))
            {
                if (fpi <= 6)
                {
                    finPressProgressionType = 6;
                }
                else
                {
                    finPressProgressionType = Math.Floor(faceTubes / 2m) == ((decimal)faceTubes / 2m) ? 2 : 1;
                }
            }
            else
            {
                finPressProgressionType = 1;
            }

            return finPressProgressionType;
        }

        private decimal GetCostOfScrap(string finMaterial, string tubeMaterial, decimal totalCosts)
        {

            if (IsStainlessSteel(finMaterial, tubeMaterial))
            {
                return (GetMiscSettingPrice(17) / 100m) * totalCosts;
            }
            
                return (GetMiscSettingPrice(8) / 100m) * totalCosts;
            

        }

        private decimal GetCostOfCrating(string finMaterial, string tubeMaterial,decimal totalCosts)
        {

            if (IsStainlessSteel(finMaterial, tubeMaterial))
            {
                return (GetMiscSettingPrice(16) / 100m) * totalCosts;
            }
                return (GetMiscSettingPrice(7) / 100m) * totalCosts;
            
        }

        private bool IsStainlessSteel(string finMaterial, string tubeMaterial)
        {
            return (finMaterial.StartsWith("Stainless Steel") || tubeMaterial.StartsWith("Stainless Steel"));
        }

        private decimal GetCostOfWeldNut(int weldNutQuantity)
        {
            return weldNutQuantity * GetMiscSettingPrice(6);
        }

        private static decimal GetCostOfASC(string distributorModel)
        {
            DataTable dtGetDistributorAuxConn = Public.SelectAndSortTable(Public.DSDatabase.Tables["Relation_Distributor_AuxiliarySideConnection"], "DistributorModel = '" + distributorModel + "'", "");
            DataTable dtGetAuxiliarySideConnection = Public.SelectAndSortTable(Public.DSDatabase.Tables["AuxiliarySideConneciton"], "PN = '" + dtGetDistributorAuxConn.Rows[0]["AuxiliarySideConnectionModel"] + "'", "");

            return Convert.ToDecimal(dtGetAuxiliarySideConnection.Rows[0]["Price"]);
        }

        private static decimal GetCostOfFlareFitting(string flareFittingModel)
        {
            return Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["FlareFittings"], "Model = '" + flareFittingModel + "'", "").Rows[0]["Price"]);
        }

        private decimal GetCostOfDistributorLine(string distributorModel, string tubeMaterial)
        {
            DataTable dtDistributor = Public.SelectAndSortTable(Public.DSDatabase.Tables["Distributor"], "DistributorModel LIKE '" + distributorModel + "%'", "");

            return Convert.ToDecimal(dtDistributor.Rows[0]["NumberOfCircuits"]) * GetMiscSettingPrice(5) * FindCostOfHeader(tubeMaterial, Math.Max(Convert.ToDecimal(dtDistributor.Rows[0]["SizeOfLine"]), 0.25m), false) / 12m;
        }

        private decimal GetCostOfDistributor(string distributorModel)
        {
            return Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["Distributor"], "DistributorModel LIKE '" + distributorModel + "%'", "").Rows[0]["Price"]) + GetMiscSettingPrice(3);
        }

        private decimal GetCostOfHeader(string tubeMaterial, decimal headerDiameter, decimal headerLength)
        {
            return headerLength * FindCostOfHeader(tubeMaterial, headerDiameter, false) / 12m;
        }

        private decimal GetCostOfSpigots(string tubeMaterial, int spigotQuantity, decimal tubeDiameter)
        {
            return spigotQuantity * GetMiscSettingPrice(2) * FindCostOfHeader(tubeMaterial, tubeDiameter, false) / 12m;
        }

        private decimal GetCostOfVents(int ventsQuantity)
        {
            return ventsQuantity * GetMiscSettingPrice(1);
        }

        private decimal GetCostOfThreadedConnection(string tubeMaterial, int threadedConnectionQuantity, decimal threadedConnectionDiameter)
        {
            return threadedConnectionQuantity * FindCostOfHeader(tubeMaterial, threadedConnectionDiameter, true);
        }

        private static decimal FindCostOfHeader(string tubeMaterial, decimal diameter, bool threadedConnection)
        {
            DataTable dtOrderedHeadet = Public.SelectAndSortTable(Public.DSDatabase.Tables["HeaderInformation"], "", "CopperHeaderDiameter");
            diameter = Math.Max(diameter, Convert.ToDecimal(dtOrderedHeadet.Rows[0]["CopperHeaderDiameter"]));

            DataTable dtGoodHeader = Public.SelectAndSortTable(Public.DSDatabase.Tables["HeaderInformation"], "CopperHeaderDiameter = " + diameter, "");

            decimal headerCost = !tubeMaterial.StartsWith("Stainless Steel") ? Convert.ToDecimal(threadedConnection ? dtGoodHeader.Rows[0]["TCCOST"] : dtGoodHeader.Rows[0]["CostPerFoot"]) : Convert.ToDecimal(dtGoodHeader.Rows[0]["StainlessSteelCostPerFoot"]);

            return headerCost;
        }

        private decimal getCostOfDrainPan_Damper(int drainPanQuantity, string drainPanMaterial, decimal drainPanHeight, decimal drainPanWidth)
        {
            return Math.Floor(drainPanQuantity * GetDrainPanDensity(drainPanMaterial) * GetMiscSettingPrice(4) * drainPanHeight * drainPanWidth * GetDrainPanCostPerLbs(drainPanMaterial) * 100m + 0.5m) / 100m;
        }

        private static decimal GetDrainPanCostPerLbs(string drainPanMaterial)
        {
            return Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["MaterialInformation"], "CoilFinMaterial ='" + drainPanMaterial + "'", "").Rows[0]["DrainPanCostPerLbs"]);
        }

        private static decimal GetDrainPanDensity(string drainPanMaterial)
        {
            return Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["MaterialInformation"], "CoilFinMaterial ='" + drainPanMaterial + "'", "").Rows[0]["MaterialDensity"]);
        }

        private decimal GetCostOfCenterPlate(string casingMaterial, decimal casingThickness, decimal centerPlateHeight, decimal centerPlateWidth)
        {
            return casingThickness * GetCasingMaterialPricePerLbs(casingMaterial) * centerPlateHeight * centerPlateWidth * GetCasingMaterialDensity(casingMaterial);
        }

        private decimal GetCostOfTopBottomPlate(string casingMaterial, decimal casingThickness, decimal topBottomPlateHeight, decimal topBottomPlateWidth)
        {
            return casingThickness * GetCasingMaterialPricePerLbs(casingMaterial) * topBottomPlateHeight * topBottomPlateWidth * GetCasingMaterialDensity(casingMaterial);
        }

        private decimal GetCostOfEndPlate(string casingMaterial,decimal casingThickness, decimal endPlateHeight, decimal endPlateWidth)
        {
            return casingThickness * GetCasingMaterialPricePerLbs(casingMaterial) * endPlateHeight * endPlateWidth * GetCasingMaterialDensity(casingMaterial);
        }

        private static decimal GetCasingMaterialPricePerLbs(string casingMaterial)
        {
            return Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilCasingMaterial"], "CasingMaterial ='" + casingMaterial + "'", "").Rows[0]["PricePerLbs"]);
        }

        private static decimal GetCasingMaterialDensity(string casingMaterial)
        {
            return Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilCasingMaterial"], "CasingMaterial ='" + casingMaterial + "'", "").Rows[0]["MaterialDensity"]);
        }

        private decimal GetCostOfReturnBends(int returnBendsQty, string finType, string tubeMaterial)
        {

            if (tubeMaterial.StartsWith("Stainless Steel"))
            {
                return returnBendsQty * GetMiscSettingPrice(18);
            }
            if (tubeMaterial.StartsWith("CU-NI"))
            {
                return returnBendsQty * GetMiscSettingPrice(19);
            }
            return returnBendsQty * GetStandardReturnBendPrice(finType);
        }

        private static decimal GetStandardReturnBendPrice(string finType)
        {
            return Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["PricingReturnBendCost"], "FinType = '" + finType + "'", "").Rows[0]["ReturnBendCost"]);
        }
        
        private static decimal GetMiscSettingPrice(int id)
        {
            return Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["PricingMISCSETTING"], "ID = " + id, "").Rows[0]["Price"]);
        }

        private decimal GetTubeCost(string finType, string tubeMaterial, decimal tubeDiameter, decimal tubeThickness, int faceTubes, int rows, decimal finLength, decimal faceTubeSize)
        {
            decimal costPerLbs = Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilTubeMaterial"], "TubeMaterial = '" + tubeMaterial + "'", "").Rows[0]["PricePerLbs"]);

            return Math.Floor(costPerLbs * GetTubeWeight(finType, tubeMaterial, tubeDiameter, tubeThickness, faceTubes, rows, finLength, faceTubeSize) * 100m + 0.5m) / 100m;
        }

        private decimal GetTubeWeight(string finType, string tubeMaterial, decimal tubeDiameter, decimal tubeThickness, int faceTubes, int rows, decimal finLength, decimal faceTubeSize)
        {
            decimal tubeWeight = GetTubeLength(faceTubes, rows, finLength, faceTubeSize) * GetTubeSurfaceSection(tubeDiameter, tubeThickness) * GetTubeMaterialDensity(tubeMaterial);
           
            //if fintype "N" there and extra added to the original weight
            if (finType == "N")
            {
                tubeWeight = tubeWeight + (GetTubeLength(faceTubes, rows, finLength, faceTubeSize) * GetTubeSurfaceSection(0.375m, tubeThickness) * GetTubeMaterialDensity(tubeMaterial));
            }

            return tubeWeight;
        }

        private static decimal GetTubeMaterialDensity(string tubeMaterial)
        {
            return Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilTubeMaterial"], "TubeMaterial ='" + tubeMaterial + "'", "").Rows[0]["MaterialDensity"]);
        }

        //get tube surface section
        private static decimal GetTubeSurfaceSection(decimal tubeDiameter, decimal tubeThickness)
        {
            return ((decimal)Math.Pow((double)tubeDiameter, 2d) - (decimal)Math.Pow((double)tubeDiameter - (2d * (double)tubeThickness), 2d)) * (decimal)Math.PI / 4m;
        }

        //get the tube length
        private decimal GetTubeLength(int faceTubes, int rows, decimal finLength, decimal faceTubeSize)
        {
            return faceTubes * (decimal)rows * (finLength + GetTubeExtra(faceTubeSize));
        }
       
        //get an extra used for the tube length
        private static decimal GetTubeExtra(decimal faceTubeSize)
        {
            return ((decimal)Math.PI * faceTubeSize / 2m) / 2m + 0.25m;
        }

        //from the weight of material we can know how much it cost per lbs.
        private decimal GetFinCost(string finMaterial, decimal finHeight, int rows, decimal tubeRow, decimal finLength, int fpi, decimal finThickness)
        {
            decimal costPerLbs = Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilFinMaterial"], "FinMaterial = '" + finMaterial + "'", "").Rows[0]["PricePerLbs"]);

            return Math.Floor(costPerLbs * GetFinMaterialWeight(finMaterial, finHeight, rows, tubeRow, finLength, fpi, finThickness) * 100m + 0.5m) / 100m;
        }

        //get the weight of all the fins for a certain material
        private decimal GetFinMaterialWeight(string finMaterial, decimal finHeight, int rows, decimal tubeRow, decimal finLength, int fpi, decimal finThickness)
        {
            decimal materialDensity = Convert.ToDecimal(Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilFinMaterial"], "FinMaterial = '" + finMaterial + "'", "").Rows[0]["MaterialDensity"]);

            return materialDensity * GetFinsMaterialCubicInches(finHeight, rows, tubeRow, finLength, fpi, finThickness);
        }

        //get the cubic inches of all the fins
        private decimal GetFinsMaterialCubicInches(decimal finHeight, int rows, decimal tubeRow, decimal finLength, int fpi, decimal finThickness)
        {
            return GetAmountOfFins(finLength, fpi) * GetFinSurfaceArea(finHeight, rows, tubeRow) * finThickness;
        }

        //return the quantity of fins on the coil
        private static decimal GetAmountOfFins(decimal finLength, int fpi)
        {
            return finLength * fpi;
        }

        //return the surface area of the fin in square inches
        private static decimal GetFinSurfaceArea(decimal finHeight, int rows, decimal tubeRow)
        {
            return finHeight * (rows * tubeRow);
        }
    }

    public class Headers
    {
        public Headers(decimal diameter, decimal length)
        {
            Diameter = diameter;
            Length = length;
        }

        public decimal Diameter { get; private set; }

        public decimal Length { get; private set; }
    }

    public class Distributor
    {
        public Distributor(decimal numberOfCircuit, decimal line, decimal spigot, string brand, string model)
        {
            NumberOfCircuit = numberOfCircuit;
            Line = line;
            Spigot = spigot;
            Brand = brand;
            Model = model;
        }


        public decimal NumberOfCircuit { get; private set; }
        public decimal Line { get; private set; }
        public decimal Spigot { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
    }

    public class FlareFitting
    {
        public FlareFitting(int quantity, string type, string model)
        {
            Quantity = quantity;
            Type = type;
            Model = model;
        }

        public int Quantity { get; private set; }
        public string Type { get; private set; }
        public string Model { get; private set; }
    }
}
