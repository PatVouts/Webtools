using System;
using System.Windows.Forms;

namespace RefplusWebtools.QuickHeatPipe
{
    //heat pipe object that you set the values and you can get properties
    class HeatPipe
    {
        private const double DblFaceTubeDistance = 2.125d;

        //2008-09-22: the bar in the middle for circulaire is 3"
        //so 1.5" each side
        private const double DblFinLenghtSideAdjustement = 1.5d;
        //the middle bar is 4 inch wide so if the lenght is 84
        //we actually have 2 X 40 inch fins and 4 inch of sheet metal
        //in between.
        //private const double dblFinLenghtSideAdjustement = 2d;
        
        //all variable
        private short _faceTubes;
        private readonly double _faceTubesSize;
        private double _finLength;
        private double _airFlowVelocity;
        private double _finLengthOnSupplySide;
        private double _finLengthOnReturnSide;
        private short _fpi;
        private short _numberOfRows;
        private double _outsideAirDryBulb;
        private double _returnAirDryBulb;
        private double _supplyDryBulb;
        private double _returnDryBulb;
        private double _outsideAirRelativeHumidity;
        private bool _coating;
        private double _defrostSetPoint;
        private bool _symmetrical;
        private double _altitude;
        private double _weight;
        private double _heatPipeCapacity;
        private double _condensate;
        private double _pressureDropExhaustSide;
        private double _sensibleEffectiveness ;
        private double _latentEffectiveness ;
        private double _totalEffectiveness ;
        private double _sensibleCoolingCoilEffectiveness ;
        private double _totalCoolingCoilEffectiveness ;
        private double _exhaustAirRelativeHumidity ;
        private double _supplyAirRelativeHumidity ;
        private double _airFlowExhaust ;
        private double _airFlowSupply ;
        private double _returnAirRelativeHumidity ;
        private short _finsIndex;
        private double _pressureDropSupplySide ;
        private double _outsideAirWetBulb ;
        private double _returnAirWetBulb ;
        private double _returnWetBulb ;
        private double _supplyWetBulb ;
        private double _outsideAirGrains ;
        private double _returnAirGrains ;
        private double _returnGrains ;
        private double _supplyGrains ;
        private double _outsideAirEnthalpy ;
        private double _returnAirEnthalpy ;
        private double _returnEnthalpy ;
        private double _supplyEnthalpy ;
        private double _mixingAirFlowSupplyTemperature ;
        private bool _shape ;
        private double _atmosphericPressure ;
        private double _airFlowSupplyBypass ;
        private double _supplyAirVelocity ;
        private double _exhaustAirVelocity ;
        private bool _parallelFlow ;
        private double _tiltAngle ;
        private bool _showWarningMessage ;
        public enum WeatherConditionType { Summer, Winter };
        private readonly WeatherConditionType _weatherCondition = WeatherConditionType.Summer;

        //the property of the heat pipe (aka front end of the object)
        public short FaceTubes
        {
            get { return _faceTubes; }
        }
        public double FinLength
        {
            get { return _finLength; }
        }
        public double AirFlowVelocity
        {
            get { return _airFlowVelocity; }
        }
        public double FinLengthOnSupplySide
        {
            get { return _finLengthOnSupplySide; }
        }
        public double FinLengthOnReturnSide
        {
            get { return _finLengthOnReturnSide; }
        }
        public short FPI
        {
            get { return _fpi; }
        }
        public short NumberOfRows
        {
            get { return _numberOfRows; }
        }
        public double OutsideAirDryBulb
        {
            get { return _outsideAirDryBulb; }
        }
        public double ReturnAirDryBulb
        {
            get { return _returnAirDryBulb; }
        }
        public double SupplyDryBulb
        {
            get { return _supplyDryBulb; }
        }
        public double ReturnDryBulb
        {
            get { return _returnDryBulb; }
        }
        public double OutsideAirRelativeHumidity
        {
            get { return _outsideAirRelativeHumidity; }
        }
        public bool Coating
        {
            get { return _coating; }
        }
        public double DefrostSetPoint
        {
            get { return _defrostSetPoint; }
        }
        public bool Symmetrical
        {
            get { return _symmetrical; }
        }
        public double Altitude
        {
            get { return _altitude; }
        }
        public double Weight
        {
            get { return _weight; }
        }
        public double HeatPipeCapacity
        {
            get { return _heatPipeCapacity; }
        }
        public double Condensate
        {
            get { return _condensate; }
        }
        public double PressureDropExhaustSide
        {
            get { return _pressureDropExhaustSide; }
        }
        public double SensibleEffectiveness
        {
            get { return _sensibleEffectiveness; }
        }
        public double LatentEffectiveness
        {
            get { return _latentEffectiveness; }
        }
        public double TotalEffectiveness
        {
            get { return _totalEffectiveness; }
        }
        public double SensibleCoolingCoilEffectiveness
        {
            get { return _sensibleCoolingCoilEffectiveness; }
        }
        public double TotalCoolingCoilEffectiveness
        {
            get { return _totalCoolingCoilEffectiveness; }
        }
        public double ExhaustAirRelativeHumidity
        {
            get { return _exhaustAirRelativeHumidity; }
        }
        public double SupplyAirRelativeHumidity
        {
            get { return _supplyAirRelativeHumidity; }
        }
        public double AirFlowExhaust
        {
            get { return _airFlowExhaust; }
        }
        public double AirFlowSupply
        {
            get { return _airFlowSupply; }
        }
        public double ReturnAirRelativeHumidity
        {
            get { return _returnAirRelativeHumidity; }
        }
        public short FinsIndex
        {
            get { return _finsIndex; }
        }
        public double PressureDropSupplySide
        {
            get { return _pressureDropSupplySide; }
        }
        public double OutsideAirWetBulb
        {
            get { return _outsideAirWetBulb; }
        }
        public double ReturnAirWetBulb
        {
            get { return _returnAirWetBulb; }
        }
        public double ReturnWetBulb
        {
            get { return _returnWetBulb; }
        }
        public double SupplyWetBulb
        {
            get { return _supplyWetBulb; }
        }
        public double OutsideAirGrains
        {
            get { return _outsideAirGrains; }
        }
        public double ReturnAirGrains
        {
            get { return _returnAirGrains; }
        }
        public double ReturnGrains
        {
            get { return _returnGrains; }
        }
        public double SupplyGrains
        {
            get { return _supplyGrains; }
        }
        public double OutsideAirEnthalpy
        {
            get { return _outsideAirEnthalpy; }
        }
        public double ReturnAirEnthalpy
        {
            get { return _returnAirEnthalpy; }
        }
        public double ReturnEnthalpy
        {
            get { return _returnEnthalpy; }
        }
        public double SupplyEnthalpy
        {
            get { return _supplyEnthalpy; }
        }
        public double MixingAirFlowSupplyTemperature
        {
            get { return _mixingAirFlowSupplyTemperature; }
        }
        public bool Shape
        {
            get { return _shape; }
        }
        public double AtmosphericPressure
        {
            get { return _atmosphericPressure; }
        }
        public double AirFlowSupplyBypass
        {
            get { return _airFlowSupplyBypass; }
        }
        public double SupplyAirVelocity
        {
            get { return _supplyAirVelocity; }
        }
        public double ExhaustAirVelocity
        {
            get { return _exhaustAirVelocity; }
        }
        public bool ParallelFlow
        {
            get { return _parallelFlow; }
        }
        public double TiltAngle
        {
            get { return _tiltAngle; }
        }
        public bool ShowWarningMessage
        {
            get { return _showWarningMessage; }
        }
        public WeatherConditionType WeatherCondition
        {
            get { return _weatherCondition; }
        }



        public HeatPipe(WeatherConditionType wtcWeatherCondition, short shtFaceTubes, double dblFaceTubesSize, double dblFinLength, short shtFPI, short shtNumberOfRows, double dblOutsideAirDryBulb, double dblReturnAirDryBulb, double dblOutsideAirRelativeHumidity, double dblReturnAirRelativeHumidity, bool bolCoating, double dblDefrostSetPoint, bool bolSymmetrical, double dblAltitude, double dblAirFlowExhaust, double dblAirFlowSupply, short shtFinsIndex, double dblOutsideAirWetBulb, double dblReturnAirWetBulb, bool bolShape, double dblAtmosphericPressure, bool bolParallelFlow, double dblTiltAngle, bool bolShowWarningMessage)
        {
            //this value return the ratio to apply to the length so we calculate
            //correctly since our face tube distance are different that the one
            //the dll use
            double dblRatioAdjustement = CalculateRatioAdjustement(dblFaceTubesSize);
            
            //set the variable
            _weatherCondition = wtcWeatherCondition;
            _faceTubes = shtFaceTubes;
            _faceTubesSize = dblFaceTubesSize;
            //factor adjustement
            _finLength = dblFinLength * dblRatioAdjustement;
            _fpi = shtFPI;
            _numberOfRows = shtNumberOfRows;
            _outsideAirDryBulb = dblOutsideAirDryBulb;
            _returnAirDryBulb = dblReturnAirDryBulb;
            _outsideAirRelativeHumidity = dblOutsideAirRelativeHumidity;
            _returnAirRelativeHumidity = dblReturnAirRelativeHumidity;
            _coating = bolCoating;
            _defrostSetPoint = dblDefrostSetPoint;
            _symmetrical = bolSymmetrical;
            _altitude = dblAltitude;
            _airFlowExhaust = dblAirFlowExhaust;
            _airFlowSupply = dblAirFlowSupply;
            _finsIndex = shtFinsIndex;
            _outsideAirWetBulb = dblOutsideAirWetBulb;
            _returnAirWetBulb = dblReturnAirWetBulb;
            _shape = bolShape;
            _atmosphericPressure = dblAtmosphericPressure;
            _parallelFlow = bolParallelFlow;
            _tiltAngle = dblTiltAngle;
            _showWarningMessage = bolShowWarningMessage;

            //run the heat pipe selection
            RunSelection();

            //2009-02-10: sometime capacity is negative so we absolute it.
            //fix capacity being negative
            _heatPipeCapacity = Math.Abs(_heatPipeCapacity);

            //fix the return variable
            FixReturnVariable(dblRatioAdjustement, dblFinLength);

            FixWinterWetBuld();
        }

        private void FixWinterWetBuld()
        {
            if (WeatherCondition == WeatherConditionType.Winter)
            {
                _supplyWetBulb = Tools.PsyCalcFormula.WetBulb((float)SupplyDryBulb, (float)SupplyGrains, Convert.ToInt32(Altitude));
                _supplyAirRelativeHumidity = Tools.PsyCalcFormula.RelativeHumidity((float)SupplyDryBulb, (float)SupplyGrains, Convert.ToInt32(Altitude));
            }
        }

        //fix the return variable
        private void FixReturnVariable(double dblRatioAdjustement, double dblFinLength)
        {
            //set the fin leght return side to be the rest between
            //full coil length minus the supply side length.
            _finLengthOnReturnSide = _finLength - _finLengthOnSupplySide;

            //put back the value that is supposed to be there
            _finLength = dblFinLength;

            //finally use the ratio to fix the lengthof both sides
            _finLengthOnSupplySide = Convert.ToDouble(Math.Round(_finLengthOnSupplySide / dblRatioAdjustement,3));
            _finLengthOnReturnSide = Convert.ToDouble(Math.Round(_finLengthOnReturnSide / dblRatioAdjustement,3));

            //2008-09-22: The Adjustement seems to not apply anymore. in the drawing circulaire
            //use, it is not counting the middle plate.
            //now take the adjustement of the sheet metal in the middle and apply it to
            //both sides
            //_FinLengthOnSupplySide = _FinLengthOnSupplySide - dblFinLenghtSideAdjustement;
            //_FinLengthOnReturnSide = _FinLengthOnReturnSide - dblFinLenghtSideAdjustement;

            //2010-08-17 : fix the velocity being wrong
            _supplyAirVelocity = _airFlowSupply / (((_finLengthOnSupplySide - DblFinLenghtSideAdjustement) * (_faceTubes * _faceTubesSize)) / 144d);
            _exhaustAirVelocity = _airFlowExhaust / (((_finLengthOnReturnSide - DblFinLenghtSideAdjustement) * (_faceTubes * _faceTubesSize)) / 144d);
        }

        //calculate the ratio adjustement
        private double CalculateRatioAdjustement(double dblFaceTubesSize)
        {
            return dblFaceTubesSize / DblFaceTubeDistance;
        }

        //run the heat pipe selection from dll function Calculs()
        private void RunSelection()
        {
            //instanciate the dll class we need
            var clsHeatPipe = new Pipes.clsHeatPipesClass();

            //2 variable that are use for error handling
            bool bolError = false;
            string strErrorMessage = "";

            //calculate everything
            try
            {
                clsHeatPipe.Calculs(ref _faceTubes, ref _finLength, ref _airFlowVelocity, ref _finLengthOnSupplySide, ref _fpi, ref _numberOfRows, ref _outsideAirDryBulb, ref _returnAirDryBulb, ref _supplyDryBulb, ref _returnDryBulb, ref _outsideAirRelativeHumidity, ref _coating, ref _defrostSetPoint, ref _symmetrical, ref _altitude, ref _weight, ref _heatPipeCapacity, ref _condensate, ref _pressureDropExhaustSide, ref _sensibleEffectiveness, ref _latentEffectiveness, ref _totalEffectiveness, ref _sensibleCoolingCoilEffectiveness, ref _totalCoolingCoilEffectiveness, ref _exhaustAirRelativeHumidity, ref _supplyAirRelativeHumidity, ref _airFlowExhaust, ref _airFlowSupply, ref _returnAirRelativeHumidity, ref _finsIndex, ref _pressureDropSupplySide, ref _outsideAirWetBulb, ref _returnAirWetBulb, ref _returnWetBulb, ref _supplyWetBulb, ref _outsideAirGrains, ref _returnAirGrains, ref _returnGrains, ref _supplyGrains, ref _outsideAirEnthalpy, ref _returnAirEnthalpy, ref _returnEnthalpy, ref _supplyEnthalpy, ref _mixingAirFlowSupplyTemperature, ref _shape, ref _atmosphericPressure, ref _airFlowSupplyBypass, ref _supplyAirVelocity, ref _exhaustAirVelocity, ref _parallelFlow, ref _tiltAngle, ref _showWarningMessage, ref bolError, ref strErrorMessage);
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"HeatPipe RunSelection");
                MessageBox.Show(ex.Message + @"
" + strErrorMessage);
            }
        }
    }
}
