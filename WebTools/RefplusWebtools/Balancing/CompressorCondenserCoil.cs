using System;
using System.Collections.Generic;

namespace RefplusWebtools.Balancing
{
    class CompressorCondenserCoil
    {
        public static List<BalancingData> GetBalancingData(
            decimal ambientMin,
            decimal ambientMax,
            decimal sstMin,
            decimal sstMax,
            List<Compressor> listOfCompressors,
            string coilType,
            decimal coilFinHeight,
            decimal coilFinLength,
            decimal cfm,
            string refrigerant,
            decimal fpi,
            int circuit,
            decimal rows,
            string finMaterial,
            decimal finThickness,
            string tubeMaterial,
            decimal tubeThickness,
            string tubeType)
        {
            return GetBalancingData(ambientMin,
            ambientMax,
            1m,
            sstMin,
            sstMax,
            1m,
           listOfCompressors,
            coilType,
            coilFinHeight,
            coilFinLength,
            cfm,
            refrigerant,
            fpi,
            circuit,
            rows,
            finMaterial,
            finThickness,
            tubeMaterial,
            tubeThickness,
            tubeType);
        }

        public static List<BalancingData> GetBalancingData(
           decimal ambientMin,
           decimal ambientMax,
           decimal ambientTicks,
           decimal sstMin,
           decimal sstMax,
           decimal sstTicks,
           List<Compressor> listOfCompressors,
           string coilType,
           decimal coilFinHeight,
           decimal coilFinLength,
           decimal cfm,
           string refrigerant,
           decimal fpi,
           int circuit,
           decimal rows,
           string finMaterial,
           decimal finThickness,
           string tubeMaterial,
           decimal tubeThickness,
           string tubeType)
        {
            //variable which contain the current values we are running with.
            decimal currentAmbient;
            decimal currentLiquidPressureDrop = 0m;

            var balancingResults = new List<BalancingData>();

            //2012-09-11 : #3361 : needed to override the function to run wiht ticks now
            //because simon want by specific increment sometime.
            for (currentAmbient = ambientMin; currentAmbient <= ambientMax; currentAmbient += ambientTicks)
            {
                decimal currentSST;
                for (currentSST = sstMin; currentSST <= sstMax; currentSST += sstTicks)
                {
                    //get the condensing at which it balance
                    decimal currentCondensing = GetMatchingCondensing(currentAmbient, currentSST, listOfCompressors, coilType, coilFinHeight, coilFinLength, cfm, refrigerant, fpi, circuit, rows, finMaterial, finThickness, tubeMaterial, tubeThickness, tubeType, ref currentLiquidPressureDrop);

                    //if we get a match
                    balancingResults.Add(currentCondensing != -999m
                        ? new BalancingData(
                            TotalBTUHIncludingSubCooling(currentCondensing, currentSST,
                                ((currentCondensing - currentAmbient)/2m), listOfCompressors),
                            TotalKilowatts(currentCondensing, currentSST, listOfCompressors), currentAmbient, currentSST,
                            currentCondensing, currentLiquidPressureDrop)
                        : new BalancingData(0m, 0m, currentAmbient, currentSST, currentCondensing, 0m));
                }
            }

            return balancingResults;
        }

        private static decimal TotalKilowatts(
            decimal condensing,
            decimal sst,
            IEnumerable<Compressor> listOfCompressors)
        {
            decimal decTotalKw = 0m;

            foreach (Compressor c in listOfCompressors)
            {
                decTotalKw += c.KW(sst, condensing);
            }

            return decTotalKw;
        }

        private static decimal TotalBTUHIncludingSubCooling(
           decimal condensing,
           decimal sst,
            decimal subCooling,
           IEnumerable<Compressor> listOfCompressors)
        {
            decimal decTotalBtuh = 0m;

            foreach (Compressor c in listOfCompressors)
            {
                decTotalBtuh += (c.EVAP_MBH(sst, condensing) * 1000m) + c.SubCoolingCapacityAdjustment(sst, condensing, subCooling);
            }

            return decTotalBtuh;
        }

        private static decimal TotalTHRBTUHIncludingSubCooling(
          decimal condensing,
          decimal sst,
           decimal subCooling,
          IEnumerable<Compressor> listOfCompressors)
        {
            decimal decTotalBtuh = 0m;

            foreach (Compressor c in listOfCompressors)
            {
                decTotalBtuh += (c.THR_MBH(sst, condensing) * 1000m) + c.SubCoolingCapacityAdjustment(sst, condensing, subCooling);
            }

            return decTotalBtuh;
        }

        private static decimal GetMatchingCondensing(
            decimal ambient,
            decimal sst,
            List<Compressor> listOfCompressors,
            string coilType,
            decimal coilFinHeight,
            decimal coilFinLength,
            decimal cfm,
            string refrigerant,
            decimal fpi,
            int circuit,
            decimal rows,
            string finMaterial,
            decimal finThickness,
            string tubeMaterial,
            decimal tubeThickness,
            string tubeType,
            ref decimal currentLiquidPressureDrop)
        {
            try
            {

                decimal currentCondensing = ambient + 30m;
                decimal currentSubCooling = (currentCondensing - ambient) / 2m;

                //increment for the looping
                var increment = new[] { 5m, 2.5m, 1m, 0.5m, 0.1m, 0.05m, 0.01m, 0.001m };
                //index for increment to use
                int incrementIndex;

                for (incrementIndex = 0; incrementIndex < increment.Length; incrementIndex++)
                {
                    if (GetCoilCapacity(coilType, coilFinHeight, coilFinLength, cfm, ambient, currentCondensing, sst, refrigerant, fpi, circuit, rows, finMaterial, finThickness, tubeMaterial, tubeThickness, tubeType, ref currentLiquidPressureDrop) > TotalTHRBTUHIncludingSubCooling(currentCondensing, sst, currentSubCooling, listOfCompressors))
                    {
                        //if coil cap greater than compressor we need to decrease the condensing
                        while (GetCoilCapacity(coilType, coilFinHeight, coilFinLength, cfm, ambient, currentCondensing, sst, refrigerant, fpi, circuit, rows, finMaterial, finThickness, tubeMaterial, tubeThickness, tubeType, ref currentLiquidPressureDrop) > TotalTHRBTUHIncludingSubCooling(currentCondensing, sst, currentSubCooling, listOfCompressors))
                        {
                            currentCondensing -= increment[incrementIndex];
                            currentSubCooling = (currentCondensing - ambient) / 2m;
                        }
                        currentCondensing += increment[incrementIndex];
                        currentSubCooling = (currentCondensing - ambient) / 2m;
                    }
                    else
                    {
                        //we need to increase the condensing
                        while (GetCoilCapacity(coilType, coilFinHeight, coilFinLength, cfm, ambient, currentCondensing, sst, refrigerant, fpi, circuit, rows, finMaterial, finThickness, tubeMaterial, tubeThickness, tubeType, ref currentLiquidPressureDrop) < TotalTHRBTUHIncludingSubCooling(currentCondensing, sst, currentSubCooling, listOfCompressors))
                        {
                            currentCondensing += increment[incrementIndex];
                            currentSubCooling = (currentCondensing - ambient) / 2m;
                        }

                        //if last increment do not reduce the condensing
                        //because we want the coil to be higher than the compressor
                        if (incrementIndex != increment.Length - 1)
                        {
                            currentCondensing -= increment[incrementIndex];
                            currentSubCooling = (currentCondensing - ambient) / 2m;
                        }
                    }
                }

                return currentCondensing;
            }
            catch(Exception ex)
            {
                Public.PushLog(ex.ToString(), "CompressorCondenserCoil GetMatchingCondensing");
                return -999m;
            }
        }

        private static decimal GetCoilCapacity(
            string coilType,
            decimal coilFinHeight,
            decimal coilFinLength,
            decimal cfm,
            decimal edb,
            decimal condensing,
            decimal suction,
            string refrigerant,
            decimal fpi,
            int circuit,
            decimal rows,
            string finMaterial,
            decimal finThickness,
            string tubeMaterial,
            decimal tubeThickness,
            string tubeType,
            ref decimal currentLiquidPressureDrop)
        {
            decimal coilCapacity = 0m;
            bool error = false;

            CondenserCoil.CondenserCoil condenserCoil = GetCondenserCoil(coilType, coilFinHeight, coilFinLength, cfm, edb, condensing, suction, refrigerant, fpi, circuit, rows, finMaterial, finThickness, tubeMaterial, tubeThickness, tubeType);
            
            if (condenserCoil != null)
            {
                coilCapacity = Convert.ToDecimal(condenserCoil.SHAZ);
                currentLiquidPressureDrop = Convert.ToDecimal(condenserCoil.DP1Z);
            }
            else
            {
                error = true;
            }

            return (error ? -999m : coilCapacity);

        }

        private static CondenserCoil.CondenserCoil GetCondenserCoil(
            string coilType,
            decimal coilFinHeight,
            decimal coilFinLength,
            decimal cfm,
            decimal edb,
            decimal condensing,
            decimal suction,
            string refrigerant,
            decimal fpi,
            int circuit,
            decimal rows,
            string finMaterial,
            decimal finThickness,
            string tubeMaterial,
            decimal tubeThickness,
            string tubeType)
        {
            var cond = new CondenserCoil.CondenserCoil
            {
                CHO = "R",
                CH = (float) coilFinHeight,
                CL = (float) coilFinLength,
                CFM = (float) cfm,
                DBE = (float) edb,
                COND = (float) condensing,
                SUCT = (float) suction,
                FL = refrigerant,
                CIR = circuit,
                FPI = (float) fpi,
                FM = finMaterial,
                YF = (float) finThickness,
                TM = tubeMaterial,
                Row = (float) rows,
                TT = (float) tubeThickness,
                CTYP = coilType,
                FFO = 0f,
                ALTD = 0f,
                CFMT = "A"
            };


            cond.ODDF = cond.Row % 2.0F > 0 ? "Y" : "N";
            cond.TTYP = tubeType; //Tube Type
            cond.DES = "C"; //Coil Design
            cond.SB = "N"; //sub cooler

            try
            {
                cond.DESIGN(Public.CoilDllKey);
                return cond;

            }
            catch (Exception)
            {
                //an error happen while selecting a coil, return false... would love to deprogram that useless error, but Ravi's DLL works that way....
                return null;
            }
        }
    }
}
