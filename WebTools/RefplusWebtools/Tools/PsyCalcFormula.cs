using System;
using System.Runtime.InteropServices;

namespace RefplusWebtools.Tools
{
    class PsyCalcFormula
    {
        [DllImport("PsyLib32.dll")]
        private static extern float LCWBTOGR(float temp, float tempWet, int feet);
        [DllImport("PsyLib32.dll")]
        private static extern float LCRH(float db, float gr, int alt);
        [DllImport("PsyLib32.dll")]
        private static extern float LCSATGRAINS(float db, int alt);
        [DllImport("PsyLib32.dll")]
        private static extern float LCWETBULB(float db, float grains, int alt);
        [DllImport("PsyLib32.dll")]
        private static extern float LCDENSITY(float db, float grains, int alt);
        [DllImport("PsyLib32.dll")]
        private static extern float LCDEWPOINT(float grains, int alt);
        [DllImport("PsyLib32.dll")]
        private static extern float LCRHTOGR(float db, float rh, int alt);
        [DllImport("PsyLib32.dll")]
        private static extern float LCENTHALPY(float db, float grains);
         
        public static float Density(float dryBulb, float grains, int altitude)
        {
            return LCDENSITY(dryBulb, (float)Convert.ToDecimal(Convert.ToDecimal(Math.Floor(grains * 100f)) / 100m), altitude);
        }

        public static float SaturationHumidityRatio(float dryBulbOrDewPoint, int altitude)
        {
            return LCSATGRAINS(dryBulbOrDewPoint, altitude);
        }

        public static float RelativeHumidity(float dryBulb, float grains, int altitude)
        {
            return LCRH(dryBulb, grains, altitude);
        }

        public static float Grains(float dryBulb, float rh, int altitude)
        {
            return LCRHTOGR(dryBulb, (rh > 1 ? rh / 100f : rh), altitude);
        }

        public static float DewPoint(float grains, int altitude)
        {
            return LCDEWPOINT(grains, altitude);
        }

        public static float WetBulb(float dryBulb, float grains, int altitude)
        {
            return LCWETBULB(dryBulb, grains, altitude);
        }

        public static float WetBulbToGrains(float dryBulb, float wetBulb, int altitude)
        {
            return LCWBTOGR(dryBulb, wetBulb, altitude);
        }

        public static float EnthalpyBtuPerPound(float dryBulb, float grains)
        {
            return LCENTHALPY(dryBulb, grains);
        }

        public static float AirDensityRatio(int altitude)
        {
            //2010-02-17 : Alois said to use 70/50 for
            //calculating the ratio because he think the 1.08 is based on these
            //temperature anyway

            const float dryBulb = 70f;
            const float rh = 0.50f;

            //get density at sea level (0ft)
            float seaLevelDensity = Density(dryBulb, Grains(dryBulb, rh, 0), 0);
            //get density at given altitude
            float altitudeDensity = Density(dryBulb, Grains(dryBulb, rh, altitude), altitude);
            //make the ratio
            float fltAirDensityRatio = altitudeDensity / seaLevelDensity;

            return fltAirDensityRatio;
        }

    }
}
