using System;
using System.Runtime.InteropServices;

namespace RefplusWebtools.Tools
{
    class Formula
    {
        //this dll function gives the Grain (WETBULB to RH)
        [DllImport("PsyLib32.dll")]
        public static extern float LCWBTOGR(float fltDryBulb, float fltWetBulb, int intAltitude);

        //this dll function gives the RH but need the grain (WETBULB to RH)
        [DllImport("PsyLib32.dll")]
        public static extern float LCRH(float fltDryBulb, float fltGrain, int intAltitude);

        //this dll function gives the Grain (RH to WETBULB)
        [DllImport("PsyLib32.dll")]
        public static extern float LCRHTOGR(float fltDryBulb, float fltRH, int intAltitude);

        //this dll function gives the WETBULB but need the grain (RH to WETBULB)
        [DllImport("PsyLib32.dll")]
        public static extern float LCWETBULB(float fltDryBulb, float fltGrain, int intAltitude);

        public static decimal WETBULB_To_RH(decimal decDryBulb, decimal decWetBulb, decimal decAltitude)
        {
            return Convert.ToDecimal(LCRH(Convert.ToSingle(decDryBulb), LCWBTOGR(Convert.ToSingle(decDryBulb), Convert.ToSingle(decWetBulb), Convert.ToInt32(decAltitude)), Convert.ToInt32(decAltitude)));
        }

        public static decimal RH_To_WETBULB(decimal decDryBulb, decimal decRH, decimal decAltitude)
        {
            return Convert.ToDecimal(LCWETBULB(Convert.ToSingle(decDryBulb), LCRHTOGR(Convert.ToSingle(decDryBulb), Convert.ToSingle(decRH / 100m), Convert.ToInt32(decAltitude)), Convert.ToInt32(decAltitude)));
        }
    }
}
