using System;

namespace RefplusWebtools.QuickCondenser
{
    public class CondenserReceiverCharge
    {
        private const decimal R22SummerLiquid = 70.89m;
        private const decimal R22SummerVapor = 3.922m;
        private const decimal R22WinterLiquid = 84.21m;
        private const decimal R22WinterVapor = 0.651m;

        private const decimal R134ASummerLiquid = 72.16m;
        private const decimal R134ASummerVapor = 2.933m;
        private const decimal R134AWinterLiquid = 86.32m;
        private const decimal R134AWinterVapor = 0.29027m;

        private const decimal R404ASummerLiquid = 61.09m;
        private const decimal R404ASummerVapor = 5.988m;
        private const decimal R404AWinterLiquid = 79.19m;
        private const decimal R404AWinterVapor = 0.713m;

        private const decimal R407CSummerLiquid = 67.46m;
        private const decimal R407CSummerVapor = 4.587m;
        private const decimal R407CWinterLiquid = 83.37m;
        private const decimal R407CWinterVapor = 0.54m;

        private const decimal R410ASummerLiquid = 61.94m;
        private const decimal R410ASummerVapor = 6.024m;
        private const decimal R410AWinterLiquid = 79.7m;
        private const decimal R410AWinterVapor = 0.69m;

        private const decimal R507SummerLiquid = 61.21m;
        private const decimal R507SummerVapor = 6.25m;
        private const decimal R507WinterLiquid = 78.69m;
        private const decimal R507WinterVapor = 0.737m;

        private const decimal SummerLiquidConcentration = 0.3m;
        private const decimal SummerVaporConcentration = 0.7m;
        private const decimal WinterLiquidConcentration = 0.9m;
        private const decimal WinterVaporConcentration = 0.1m;

        public static Charge GetCharge(string strRefrigerant, string finType, int numberOfFaceTubes, int numberOfRows, decimal finLength, decimal decCircuitChargePercentage)
        {
            decimal decTubeInsideDiameter = GetTubeInsideDiameter(finType);

            decimal decTubeAreaInFT2 = GetTubeAreaInFT2(decTubeInsideDiameter);

            decimal decTubeTotalLengthInFT = GetTotalTubeLengthInFT(numberOfFaceTubes, numberOfRows, finLength);

            decimal decTubeInternalVolume = decTubeAreaInFT2 * decTubeTotalLengthInFT;

            decimal decSumLiq = GetRefrigerantSummerLiquidLBperFT3(strRefrigerant) * SummerLiquidConcentration * decTubeInternalVolume * decCircuitChargePercentage;
            decimal decSumVap = GetRefrigerantSummerVaporLBperFT3(strRefrigerant) * SummerVaporConcentration * decTubeInternalVolume * decCircuitChargePercentage;
            decimal decWinLiq = GetRefrigerantWinterLiquidLBperFT3(strRefrigerant) * WinterLiquidConcentration * decTubeInternalVolume * decCircuitChargePercentage;
            decimal decWinVap = GetRefrigerantWinterVaporLBperFT3(strRefrigerant) * WinterVaporConcentration * decTubeInternalVolume * decCircuitChargePercentage;

            return new Charge(decSumLiq, decSumVap, decWinLiq, decWinVap);
        }

        private static decimal GetRefrigerantSummerLiquidLBperFT3(string strRefrigerant)
        {
            decimal decReturnValue = 0m;
            if (strRefrigerant.ToUpper() == "R-22")
            {
                decReturnValue = R22SummerLiquid;
            }
            else if (strRefrigerant.ToUpper() == "R-134A")
            {
                decReturnValue = R134ASummerLiquid;
            }
            else if (strRefrigerant.ToUpper() == "R-404A")
            {
                decReturnValue = R404ASummerLiquid;
            }
            else if (strRefrigerant.ToUpper() == "R-407C")
            {
                decReturnValue = R407CSummerLiquid;
            }
            else if (strRefrigerant.ToUpper() == "R-410A")
            {
                decReturnValue = R410ASummerLiquid;
            }
            else if (strRefrigerant.ToUpper() == "R-507")
            {
                decReturnValue = R507SummerLiquid;
            }
            return decReturnValue;
        }

        private static decimal GetRefrigerantSummerVaporLBperFT3(string strRefrigerant)
        {
            decimal decReturnValue = 0m;
            if (strRefrigerant.ToUpper() == "R-22")
            {
                decReturnValue = R22SummerVapor;
            }
            else if (strRefrigerant.ToUpper() == "R-134A")
            {
                decReturnValue = R134ASummerVapor;
            }
            else if (strRefrigerant.ToUpper() == "R-404A")
            {
                decReturnValue = R404ASummerVapor;
            }
            else if (strRefrigerant.ToUpper() == "R-407C")
            {
                decReturnValue = R407CSummerVapor;
            }
            else if (strRefrigerant.ToUpper() == "R-410A")
            {
                decReturnValue = R410ASummerVapor;
            }
            else if (strRefrigerant.ToUpper() == "R-507")
            {
                decReturnValue = R507SummerVapor;
            }
            return decReturnValue;
        }

        private static decimal GetRefrigerantWinterLiquidLBperFT3(string strRefrigerant)
        {
            decimal decReturnValue = 0m;
            if (strRefrigerant.ToUpper() == "R-22")
            {
                decReturnValue = R22WinterLiquid;
            }
            else if (strRefrigerant.ToUpper() == "R-134A")
            {
                decReturnValue = R134AWinterLiquid;
            }
            else if (strRefrigerant.ToUpper() == "R-404A")
            {
                decReturnValue = R404AWinterLiquid;
            }
            else if (strRefrigerant.ToUpper() == "R-407C")
            {
                decReturnValue = R407CWinterLiquid;
            }
            else if (strRefrigerant.ToUpper() == "R-410A")
            {
                decReturnValue = R410AWinterLiquid;
            }
            else if (strRefrigerant.ToUpper() == "R-507")
            {
                decReturnValue = R507WinterLiquid;
            }
            return decReturnValue;
        }

        private static decimal GetRefrigerantWinterVaporLBperFT3(string strRefrigerant)
        {
            decimal decReturnValue = 0m;
            if (strRefrigerant.ToUpper() == "R-22")
            {
                decReturnValue = R22WinterVapor;
            }
            else if (strRefrigerant.ToUpper() == "R-134A")
            {
                decReturnValue = R134AWinterVapor;
            }
            else if (strRefrigerant.ToUpper() == "R-404A")
            {
                decReturnValue = R404AWinterVapor;
            }
            else if (strRefrigerant.ToUpper() == "R-407C")
            {
                decReturnValue = R407CWinterVapor;
            }
            else if (strRefrigerant.ToUpper() == "R-410A")
            {
                decReturnValue = R410AWinterVapor;
            }
            else if (strRefrigerant.ToUpper() == "R-507")
            {
                decReturnValue = R507WinterVapor;
            }
            return decReturnValue;
        }

        private static decimal GetTotalTubeLengthInFT(int numberOfFaceTubes, int numberOfRows, decimal finLength)
        {
            return numberOfFaceTubes * (decimal)numberOfRows * ((finLength + 5m) / 12m);
        }

        private static decimal GetTubeAreaInFT2(decimal decTubeInsideDiameter)
        {
            return Convert.ToDecimal((double)(decTubeInsideDiameter / 12 / 2) * (double)(decTubeInsideDiameter / 12 / 2) * Math.PI);
        }

        private static decimal GetTubeInsideDiameter(string strFinType)
        {
            decimal decTubeInsideDiameter = 0m;

            if (strFinType == "F")
            {
                decTubeInsideDiameter = 0.474m;
            }
            else if (strFinType == "D")
            {
                decTubeInsideDiameter = 0.359m;
            }

            return decTubeInsideDiameter;
        }

    }

    public class Charge
    {
        public Charge(decimal sumLiquid,decimal sumVapor,decimal winLiquid,decimal winVapor)
        {
            SummerLiquid = sumLiquid;
            SummerVapor = sumVapor;
            WinterLiquid = winLiquid;
            WinterVapor = winVapor;
        }

        public decimal SummerLiquid { get; private set; }

        public decimal SummerVapor { get; private set; }

        public decimal WinterLiquid { get; private set; }

        public decimal WinterVapor { get; private set; }
    }
}
