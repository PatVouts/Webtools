using System;
using System.Globalization;

namespace RefplusWebtools.Tools
{
    class Fraction
    {
        string _strFraction = "";
        decimal _decFraction;

        public Fraction(decimal decValue)
        {
            _decFraction = decValue;
            DecimalToFraction(decValue);
        }

        public Fraction(string strValue)
        {
            _strFraction = strValue;
            FractionToDecimal(_strFraction);
        }

        public decimal Number
        {
            get { return _decFraction; }
        }

        public string Text
        {
            get { return _strFraction; }
        }

        private void FractionToDecimal(string strFraction)
        {
            if (strFraction.Contains("/"))
            {
                string[] strSplitFraction = strFraction.Split(Convert.ToChar(" "));
                string[] strSplitDecimals = strSplitFraction[strSplitFraction.Length - 1].Split(Convert.ToChar("/"));

                decimal decEntier = (strSplitFraction.Length > 1 ? Convert.ToDecimal(strSplitFraction[0]) : 0m);

                decimal decNumerateur = Convert.ToDecimal(strSplitDecimals[0]);
                decimal decDenominateur = Convert.ToDecimal(strSplitDecimals[1]);

                _decFraction = decEntier + (decNumerateur / decDenominateur);
            }
            else
            {
                _decFraction = Convert.ToDecimal(strFraction);
            }
        }

        private bool IsContainingOnlyNumber(string strValue, int intContains)
        {
            bool bolOnlyContain = true;

            if (intContains == 0)
            {
                bolOnlyContain = !(strValue.Contains("1") || strValue.Contains("2") || strValue.Contains("3") || strValue.Contains("4") || strValue.Contains("5") || strValue.Contains("6") || strValue.Contains("7") || strValue.Contains("8") || strValue.Contains("9"));
            }
            else if (intContains == 1)
            {
                bolOnlyContain = !(strValue.Contains("0") || strValue.Contains("2") || strValue.Contains("3") || strValue.Contains("4") || strValue.Contains("5") || strValue.Contains("6") || strValue.Contains("7") || strValue.Contains("8") || strValue.Contains("9"));
            }
            else if (intContains == 2)
            {
                bolOnlyContain = !(strValue.Contains("0") || strValue.Contains("1") || strValue.Contains("3") || strValue.Contains("4") || strValue.Contains("5") || strValue.Contains("6") || strValue.Contains("7") || strValue.Contains("8") || strValue.Contains("9"));
            }
            else if (intContains == 3)
            {
                bolOnlyContain = !(strValue.Contains("0") || strValue.Contains("1") || strValue.Contains("2") || strValue.Contains("4") || strValue.Contains("5") || strValue.Contains("6") || strValue.Contains("7") || strValue.Contains("8") || strValue.Contains("9"));
            }
            else if (intContains == 4)
            {
                bolOnlyContain = !(strValue.Contains("0") || strValue.Contains("1") || strValue.Contains("2") || strValue.Contains("3") || strValue.Contains("5") || strValue.Contains("6") || strValue.Contains("7") || strValue.Contains("8") || strValue.Contains("9"));
            }
            else if (intContains == 5)
            {
                bolOnlyContain = !(strValue.Contains("0") || strValue.Contains("1") || strValue.Contains("2") || strValue.Contains("3") || strValue.Contains("4") || strValue.Contains("6") || strValue.Contains("7") || strValue.Contains("8") || strValue.Contains("9"));
            }
            else if (intContains == 6)
            {
                bolOnlyContain = !(strValue.Contains("0") || strValue.Contains("1") || strValue.Contains("2") || strValue.Contains("3") || strValue.Contains("4") || strValue.Contains("5") || strValue.Contains("7") || strValue.Contains("8") || strValue.Contains("9"));
            }
            else if (intContains == 7)
            {
                bolOnlyContain = !(strValue.Contains("0") || strValue.Contains("1") || strValue.Contains("2") || strValue.Contains("3") || strValue.Contains("4") || strValue.Contains("5") || strValue.Contains("6") || strValue.Contains("8") || strValue.Contains("9"));
            }
            else if (intContains == 8)
            {
                bolOnlyContain = !(strValue.Contains("0") || strValue.Contains("1") || strValue.Contains("2") || strValue.Contains("3") || strValue.Contains("4") || strValue.Contains("5") || strValue.Contains("6") || strValue.Contains("7") || strValue.Contains("9"));
            }
            else if (intContains == 9)
            {
                bolOnlyContain = !(strValue.Contains("0") || strValue.Contains("1") || strValue.Contains("2") || strValue.Contains("3") || strValue.Contains("4") || strValue.Contains("5") || strValue.Contains("6") || strValue.Contains("7") || strValue.Contains("8"));
            }

            return bolOnlyContain;
        }

        private void DecimalToFraction(decimal decValue)
        {
            bool bolError = false;

            decimal decEntier = Math.Floor(decValue);
            decimal decReste = decValue - decEntier;

            if (decEntier > 0)
            {
                _strFraction = Convert.ToInt32(decEntier).ToString(CultureInfo.InvariantCulture);
            }

            //2009-07-08 modified by Domenico
            //you must verify if the length of the string will permit you to check for the third character!!!
            string strReste = "";
            if (decReste > 0m)
            {
                strReste = decReste.ToString(CultureInfo.InvariantCulture).Substring(2);
            }

            if (strReste.Length > 4)
            {
                strReste = strReste.Substring(0, 4);
            }

            if (IsContainingOnlyNumber(strReste, 3) && strReste.Length >= 2)
            {
                _strFraction += " 1/3";
            }
            else if (IsContainingOnlyNumber(strReste, 6) && strReste.Length >= 2)
            {
                _strFraction += " 2/3";
            }
            else if (decReste > 0m)
            {
                if (decEntier > 0)
                {
                    _strFraction += " ";
                }

                decimal decNumerator;
                decimal decDenominator = 1;

                do
                {
                    decNumerator = decDenominator * decReste;

                    ++decDenominator;

                    //if we reach denominator of 1000 it's too much we
                    //just show the decimal value instead (prevent infinit loop)
                    if (decDenominator > 1000m)
                    {
                        bolError = true;

                        break;
                    }

                } while (decNumerator % 1 != 0);

                --decDenominator;

                _strFraction += Convert.ToInt32(decNumerator) + "/" + Convert.ToInt32(decDenominator);
            }

            if (bolError)
            {
                _strFraction = decValue.ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}
