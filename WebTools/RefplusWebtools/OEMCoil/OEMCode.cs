using System;

namespace RefplusWebtools.OEMCoil
{
    class OEMCode
    {
        public decimal GetDefaultEndPlateHeight(decimal finHeight)
        {
            //vb6 : INT((FaceTubes * CoilFaceTube + 3) * 10 + 0.5) /10
            return Math.Floor((finHeight + 3m) * 10m + 0.5m) / 10m;
        }

        public decimal GetDefaultEndPlateWidth(decimal coilTubeRow, int rows)
        {
            //vb6 : INT((Rows * CoilTubeRow + 5) * 10 + 0.5) /10
            return Math.Floor((rows * coilTubeRow + 5m) * 10m + 0.5m) / 10m;
        }

        public decimal GetDefaultTopAndBottomPlateHeight(decimal finLength)
        {
            //vb6 : INT((FinLength + 1.5) * 10 + 0.5) /10
            return Math.Floor((finLength + 1.5m) * 10m + 0.5m) / 10m;
        }

        public decimal GetDefaultTopAndBottomPlateWidth(decimal coilTubeRow, int rows)
        {
            //vb6 : INT((FinLength + 1.5) * 10 + 0.5) /10
            return Math.Floor((rows * coilTubeRow + 5m) * 10m + 0.5m) / 10m;
        }

        public decimal GetDefaultCenterPlateHeight(decimal finHeight)
        {
            //vb6 : INT((FinHeight + 3) * 10 + 0.5) /10
            return Math.Floor((finHeight + 3m) * 10m + 0.5m) / 10m;
        }

        public decimal GetDefaultCenterPlateWidth(decimal coilTubeRow, int rows)
        {
            //vb6 : INT((FinLength + 1.5) * 10 + 0.5) /10
            return Math.Floor((rows * coilTubeRow + 5m) * 10m + 0.5m) / 10m;
        }

        public int GetReturnBendsQty(string finType, int faceTubes, int rows, string tubeMaterial, decimal finLength)
        {
            int qtyOfReturnBends = GetExpansionType(finType, faceTubes, rows, tubeMaterial, finLength) == ExpansionType.Horizontal ? Convert.ToInt32( Math.Floor(faceTubes * (decimal)rows * 0.9m + 0.9m)) : Convert.ToInt32((faceTubes * (decimal)rows) / 2m);

            return qtyOfReturnBends;
        }

        public decimal GetHeaderLength(decimal finHeight)
        {
            //vb6 : INT((FinHeight + 6) * 10 + 0.5) /10
            return Math.Floor((finHeight + 6m) * 10m + 0.5m) / 10m;
        }

        public enum ExpansionType { Horizontal, Vertical };

        public ExpansionType GetExpansionType(string finType, int faceTubes, int rows, string tubeMaterial, decimal finLength)
        {
            ExpansionType expType;

            if (tubeMaterial.Contains("Stainless Steel"))
            {
                expType = ExpansionType.Horizontal;
            }
            else if (finType == "G" || finType == "A" || finType == "F" || finType == "P" || rows == 1)
            {
                expType = ExpansionType.Horizontal;
            }
            else if ((finType == "C" || finType == "H" || finType == "K") && faceTubes <= 30 && (rows >= 2 && rows <= 6) && finLength <= 48)
            {
                expType = ExpansionType.Vertical;
            }
            else if ((finType == "E" || finType == "D") && faceTubes <= 24 && (rows >= 2 && rows <= 6) && finLength <= 48)
            {
                expType = ExpansionType.Vertical;
            }
            else
            {
                expType = ExpansionType.Horizontal;
            }

            return expType;
        }
    }
}
