using System;

namespace RefplusWebtools.QuickControlPanel
{
    public class Valve
    {
        private readonly int _iStartGPM;
        private readonly int _iStopGPM;
        private readonly float _fConnSize;
        private readonly float _fCvValue;
        private readonly string _strModel="";
        private readonly string _strValveType = "";
        private float _fPressureDrop;
        private readonly float _fPSI;
        private readonly int _iStartMBH;
        private readonly int _iStopMBH;

        public Valve(int parIStartGPM, int parIStopGPM, float parFConnSize, float parFCvValue, string parStrModel,string parStrValveType,float parFgpm)
        {
            _iStartGPM = parIStartGPM;
            _iStopGPM = parIStopGPM;
            _fConnSize = parFConnSize;
            _fCvValue = parFCvValue;
            _strModel = parStrModel;
            _strValveType = parStrValveType;
            SetPressureDrop(parFgpm);
        }

        public Valve(int parIStartMBH, int parIStopMBH, float parFConnSize, string parStrModel, string parStrValveType, int parFpsi)
        {
            _iStartMBH = parIStartMBH;
            _iStopMBH = parIStopMBH;
            _fConnSize = parFConnSize;
            _strModel = parStrModel;
            _strValveType = parStrValveType;
            _fPSI = parFpsi;
            _fPressureDrop = 1.6f;
            if (parFpsi > 2.0f)
            {
                _fPressureDrop = 4.0f;
            }
        }

        public bool IsMBHinRange(int parImbh,int parIpsi)
        {
// ReSharper disable once CompareOfFloatsByEqualityOperator
            bool bRetVal = parImbh >= GetStartMBH() && parImbh <= GetStopMBH() && parIpsi==GetPSI();
            return bRetVal;
        }

        public bool IsGPMinRange(float parFgpm)
        {
            return parFgpm >= GetStartGPM() && parFgpm <= GetStopGPM();
        }

        public int GetStartMBH()
        {
            return _iStartMBH;
        }

        public int GetStopMBH()
        {
            return _iStopMBH;
        }

        public int GetStartGPM()
        {
            return _iStartGPM;
        }

        public int GetStopGPM()
        {
            return _iStopGPM;
        }

        public string GetValveType()
        {
            return _strValveType;
        }

        public float GetDecimalRepresentationOfConn()
        {
            return _fConnSize;
        }

        public string GetFractionRepresentationOfConn()
        {
            string strFract;

            switch ((int)(_fConnSize*100)){
                case 25:
                    strFract="1/4\"";
                    break;
                case 50:
                    strFract = "1/2\"";
                    break;
                case 75:
                    strFract = "3/4\"";
                    break;
                case 100:
                    strFract = "1\"";
                    break;
                case 125:
                    strFract = "1-1/4\"";
                    break;
                case 150:
                    strFract = "1-1/2\"";
                    break;
                case 175:
                    strFract = "1-3/4\"";
                    break;
                case 200:
                    strFract = "2\"";
                    break;
                case 225:
                    strFract = "2-1/4\"";
                    break;
                case 250:
                    strFract = "2-1/2\"";
                    break;
                case 275:
                    strFract = "2-3/4\"";
                    break;
                case 300:
                    strFract = "3\"";
                    break;
                case 350:
                    strFract = "3-1/2\"";
                    break;
                case 400:
                    strFract = "4\"";
                    break;
                case 500:
                    strFract = "5\"";
                    break;
                default:
                    strFract="n/a";
                    break;
            }
            return strFract;
        }

        public float GetCvValue()
        {
// ReSharper disable once CompareOfFloatsByEqualityOperator
            if (_fCvValue == 0f)
            {
                return 1f;
            }
            return _fCvValue;
        }

        public string GetValveModel()
        {
            return _strModel;
        }

        public float GetPressureDrop()
        {
            return _fPressureDrop;
        }
        public float GetPSI()
        {
            return _fPSI;
        }

        private void SetPressureDrop(float parFgpm)
        {
            _fPressureDrop= (float)Math.Pow(parFgpm/GetCvValue(), 2d);
        }
        public string OutputString()
        {
            string strOutPut = _iStartGPM + " , " + _iStopGPM + " , " + _iStartMBH + " , " + _iStopMBH + " , " + GetFractionRepresentationOfConn() + " , " + _fCvValue + " , " + _strModel + " , " + _strValveType + " , " + _fPressureDrop;
            return strOutPut;
        }
    }
}
