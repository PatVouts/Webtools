using System.Collections.Generic;

namespace RefplusWebtools.Balancing
{
    class CompressorBalancing
    {
        //This uses the balancing data class to return a list of balancing data.  Simply using the constructor of the balancing data class returns the correct values, so we just, in order, input every
        //condensing and suction temperature, from min to max, and run the balancing data's calculation algorithm on the data.
        public static List<BalancingData> GetBalancingData(decimal condensingMin,decimal condensingMax,decimal sstMin,decimal sstMax,List<Compressor> listOfCompressors)
        {
            var balancingResults = new List<BalancingData>();

            for (decimal currentCondensing = condensingMin; currentCondensing <= condensingMax; currentCondensing++)
            {
                for (decimal currentSST = sstMin; currentSST <= sstMax; currentSST++)
                {
                    balancingResults.Add(new BalancingData(TotalBTUH(currentCondensing, currentSST, listOfCompressors), TotalKilowatts(currentCondensing, currentSST, listOfCompressors), 0m, currentSST, currentCondensing, 0m));
                }
            }
            return balancingResults;
        }

        //Function to return total killowatts from a list of compressors, depending on the suction temp and condensing temp (using the class Compressor)
        private static decimal TotalKilowatts(decimal condensing,decimal sst,IEnumerable<Compressor> listOfCompressors)
        {
            decimal decTotalKw = 0m;
            //Gets the killowatt from one compressor and adds it to our total
            foreach (Compressor c in listOfCompressors)
            {
                decTotalKw += c.KW(sst, condensing);
            }
            return decTotalKw;
        }

        //Function to return total BTUH from a list of compressors, depending on the suction temp and condensing temp (using the class Compressor)
        private static decimal TotalBTUH(decimal condensing,decimal sst,IEnumerable<Compressor> listOfCompressors)
        {
            decimal decTotalBtuh = 0m;
            //Gets the BTUH from one compressor and adds it to our total
            foreach (Compressor c in listOfCompressors)
            {
                decTotalBtuh += (c.EVAP_MBH(sst, condensing) * 1000m);
            }
            return decTotalBtuh;
        }
    }
}