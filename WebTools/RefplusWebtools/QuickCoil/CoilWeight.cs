using System;

namespace RefplusWebtools.QuickCoil
{
    public class CoilWeight
    {


        //calculate the total weight of the coil.
        public decimal GetCoilTotalWeight(decimal decFinHeight, decimal decFinLength, decimal decFaceTube, decimal decTubeDiameter, decimal decTubeRow, decimal decNumberOfRow, decimal decFPI, decimal decCasingDensity, decimal decCasingThickness, decimal decFinDensity, decimal decFinThickness, decimal decTubeDensity, decimal decTubeThickness, decimal decHeaderPoundsPerSquareFoot)
        {
            decimal decFinWeight = GetFinWeight(decFinHeight, decFinLength, decFinDensity, decNumberOfRow, decTubeRow, decFPI, decFinThickness);
            decimal decTubeWeight = GetTubeWeight(decFinHeight, decFinLength, decNumberOfRow, decFaceTube, decTubeDiameter, decTubeThickness, decTubeDensity);
            decimal decEndPlateWeight = GetPlateWeight(decCasingDensity, decCasingThickness, GetEndPlateHeight(decFinHeight), GetEndPlateWidth(decTubeRow, decNumberOfRow));
            decimal decCenterPlateWeight = GetPlateWeight(decCasingDensity, decCasingThickness, GetCenterPlateHeight(decFinHeight), GetCenterPlateWidth(decTubeRow, decNumberOfRow));
            decimal decBottomPlateWeight = GetPlateWeight(decCasingDensity, decCasingThickness, GetTopBottomPlateHeight(decFinLength), GetTopBottomPlateWidth(decTubeRow, decNumberOfRow));
            decimal decTopPlateWeight = GetPlateWeight(decCasingDensity, decCasingThickness, GetTopBottomPlateHeight(decFinLength), GetTopBottomPlateWidth(decTubeRow, decNumberOfRow));
            decimal decHeaderWeight = GetHeaderWeight(GetHeaderLength(decFinHeight), decHeaderPoundsPerSquareFoot);

            return CalculateCoilWeight(decFinWeight, decTubeWeight, decEndPlateWeight, decCenterPlateWeight, decBottomPlateWeight, decTopPlateWeight, decHeaderWeight);
        }

        private static decimal GetHeaderLength(decimal decFinHeight)
        {
            return Math.Ceiling((decFinHeight + 6m) * 10m) / 10m;
        }

        private static decimal GetFinWeight(decimal decFinHeight, decimal decFinLength, decimal decFinDensity, decimal decNumberOfRow, decimal decTubeRow, decimal decFPI, decimal decFinThickness)
        {
            return decFinHeight * decFinLength * decFinDensity * decNumberOfRow * decTubeRow * decFPI * decFinThickness;
        }

        private static decimal GetTubeSurface(decimal decTubeDiameter, decimal decTubeThickness)
        {
            return ((decimal)Math.Pow((double)decTubeDiameter, 2d) - (decimal)Math.Pow((double)decTubeDiameter - (2d * (double)decTubeThickness), 2d)) * (decimal)Math.PI / 4m;
        }

        private static decimal GetTubeLength(decimal decFinHeight, decimal decFinLength, decimal decNumberOfRow, decimal decFaceTube)
        {
            return (decFinHeight / decFaceTube) * decNumberOfRow * (decFinLength + ((decimal)Math.PI * decFaceTube / 4m + 0.25m));
        }

        private decimal GetTubeWeight(decimal decFinHeight, decimal decFinLength, decimal decNumberOfRow, decimal decFaceTube, decimal decTubeDiameter, decimal decTubeThickness, decimal decTubeDensity)
        {
            return GetTubeLength(decFinHeight, decFinLength, decNumberOfRow, decFaceTube) * GetTubeSurface(decTubeDiameter, decTubeThickness) * decTubeDensity;
        }

        private static decimal GetPlateWeight(decimal decCasingDensity, decimal decCasingThickness, decimal decPlateHeight, decimal decPlateWidth)
        {
            return decCasingDensity * decCasingThickness * decPlateHeight * decPlateWidth;
        }

        private static decimal GetEndPlateWidth(decimal decTubeRow, decimal decNumberOfRow)
        {
            return Math.Ceiling((decNumberOfRow * decTubeRow + 5m) * 10m) / 10m;
        }

        private static decimal GetTopBottomPlateWidth(decimal decTubeRow, decimal decNumberOfRow)
        {
            return Math.Ceiling((decNumberOfRow * decTubeRow + 5m) * 10m) / 10m;
        }

        private static decimal GetCenterPlateWidth(decimal decTubeRow, decimal decNumberOfRow)
        {
            return Math.Ceiling((decNumberOfRow * decTubeRow + 5m) * 10m) / 10m;
        }

        private static decimal GetEndPlateHeight(decimal decFinHeight)
        {
            return Math.Ceiling((decFinHeight + 3m) * 10m) / 10m;
        }

        private static decimal GetTopBottomPlateHeight(decimal decFinLength)
        {
            return Math.Ceiling((decFinLength + 1.5m) * 10m) / 10m;
        }

        private static decimal GetCenterPlateHeight(decimal decFinHeight)
        {
            return Math.Ceiling((decFinHeight + 3m) * 10m) / 10m;
        }

        private static decimal GetHeaderWeight(decimal decHeaderLength, decimal decHeaderPoundsPerSquareFoot)
        {
            return decHeaderLength * decHeaderPoundsPerSquareFoot / 12m;
        }

        private decimal CalculateCoilWeight(decimal decFinWeight, decimal decTubeWeight, decimal decEndPlateWeight, decimal decCenterPlateWeight, decimal decBottomPlateWeight, decimal decTopPlateWeight, decimal decHeaderWeight)
        {
            //1.4 is just an adjustement.  Something is wrong with the weight, and Simon wanted to have an extra 40% to make sure there won't be issues.
            return 1.4m *(decFinWeight + decTubeWeight + decEndPlateWeight + decCenterPlateWeight + decBottomPlateWeight + decTopPlateWeight + decHeaderWeight);
        }
    }
}
