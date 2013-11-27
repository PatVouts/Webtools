using System;
using System.Data;

namespace RefplusWebtools.QuickCoil
{
    class CoilInternalVolume
    {
        private readonly string[] _strTableList = { "CoilFinType" };

        private decimal _internalVolume;

        public CoilInternalVolume(string finType, decimal tubeThickness, decimal finHeight, decimal finLength, int rows)
        {
            Query.LoadTables(_strTableList);

            CalculateInternalVolume(finType, tubeThickness, finHeight, finLength, rows);
        }

        private void CalculateInternalVolume(string finType, decimal tubeThickness, decimal finHeight, decimal finLength, int rows)
        {
            DataTable dtFinType = Public.SelectAndSortTable(Public.DSDatabase.Tables["CoilFinType"], "FinType = '" + finType + "'", "");

            decimal faceTube = Convert.ToDecimal(dtFinType.Rows[0]["FaceTube"]);
            decimal tubeDiameter = Convert.ToDecimal(dtFinType.Rows[0]["TubeDiameter"]);

            dtFinType.Dispose();

            decimal diameterOfInnerTube = (tubeDiameter - (2m * tubeThickness));
            decimal rayOfInnerTube = diameterOfInnerTube / 2m;

            decimal tubeAreaFt2 = Convert.ToDecimal(((double)rayOfInnerTube / 12d) * ((double)rayOfInnerTube / 12d) * Math.PI);

            decimal totalTubeLengthInFt = (finHeight / faceTube) * rows * ((finLength + 5m) / 12m);

            _internalVolume = tubeAreaFt2 * totalTubeLengthInFt;
        }

        public decimal GetInternalVolume()
        {
            return _internalVolume;
        }
    }
}
