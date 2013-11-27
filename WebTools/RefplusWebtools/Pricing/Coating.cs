using System;
using System.Data;
using RefplusWebtools.Tools;

namespace RefplusWebtools.Pricing
{
    class BlyGoldCoating
    {
        //width of the coil
        private decimal _decCoilWidthInMeter;

        //Length of the coil
        private decimal _decCoilLengthInMeter;

        //Depth of the coil
        private decimal _decCoilDepth;

        //the following are variable that will be used along the process
        //they are filled by passign them as reference to the function SetSpecialVariables
        private decimal _decPolualCosts ;
        private decimal _decPolualCoverage ;
        private decimal _decPreTreatmentCost ;
        private decimal _decPreTreatmentCoverage ;
        private decimal _decSafeCost ;
        private decimal _decSafeCoverage ;
        private decimal _decLaborCost ;
        private decimal _decFacedAreaOutput ;
        private decimal _decUsd ;
        private decimal _decExchange ;
        private decimal _decSundry ;
        private decimal _decReturnBends ;
        private decimal _decTransportProducts ;

        //blygold constant, don't ask about the name
        //this is the name of the table column and i don't know
        //what it is exactly, i just know it's used in the calculation
        decimal _decBlyGoldConstant ;

        //Finned Area In Square Meter
        decimal _decFinnedAreaInSquareMeter ;

        //Faced Area
        decimal _decFacedArea ;

        //Total Variables
        decimal _decPolualTotal ;
        decimal _decPreTreatmentTotal ;
        decimal _decSafeTotal ;
        decimal _decMaterialTotal ;
        decimal _decLaborTotal ;
        decimal _decApplicationCostTotal ;
        decimal _decSundryTotal ;
        decimal _decTransportProductsTotal ;
        decimal _decReturnBendsTotal ;
        decimal _decPreTotalPrice ;
        decimal _decSellingUsPrice ;
        decimal _decSellingCanadianPrice ;

        //variable that hold the final total
        private decimal _decTotalPrice ;

        //constructor of the class
        public BlyGoldCoating(string strFinType, decimal decCoilQuantity, decimal decNumberOfRows, decimal decFPI, decimal decFinHeight, decimal decFinLength)
        {
            try
            {
                //load up the table we need
                Query.LoadTables(new[] { "CoilFinType", "PricingCoilBlyGold", "PricingCoilSetting" });

                //set the blygold constant
                SetBlyGoldConstant(strFinType);

                //set the special blygold variables
                SetSpecialVariables();

                //set the coil measurement variables
                SetCoilMeasurementVariables(decFinHeight, decFinLength, decNumberOfRows);

                //set Finned Area In Square Meter
                SetFinnedAreaInSquareMeter(_decCoilWidthInMeter, _decCoilLengthInMeter, _decCoilDepth, decFPI);

                //Set the Faced Area
                SetFacedArea();

                //calculate polual Material
                CalculatePolual(decNumberOfRows);

                //Calculate PreTreatment
                CalculatePreTreatment();

                //Calculate Safe
                CalculateSafe();

                //Calculate Material Total
                CalculateMaterialTotal();

                //Calculate Labor Total
                CalculateLaborTotal();

                //Calculate Application Cost Total
                CalculateApplicationCostTotal();

                //Calculate Sundry Total
                CalculateSundryTotal();

                //Calculate Transport Products total
                CalculateTransportProductTotal();

                //Calculate Return Bends total
                CalculateReturnBendsTotal();

                //Calculate Pre Total Price
                CalculatePreTotalPrice(decCoilQuantity);

                //Calculate Selling US Price
                CalculateSellingUSPrice();

                //Calculate Selling Canadian Price
                CalculateSellingCanadianPrice();

                //Calculate Total Price
                CalculateTotalPrice(decCoilQuantity);
            }
            catch(Exception ex)
            {
                Public.PushLog(ex.ToString(), "Coating BlyGoldCoating");
                _decTotalPrice = 0m;
            }
        }

        //Calculate Total Price
        private void CalculateTotalPrice(decimal decCoilQuantity)
        {
            _decTotalPrice = Math.Ceiling(_decSellingCanadianPrice / Convert.ToDecimal(Public.DSDatabase.Tables["PricingCoilSetting"].Rows[0]["ListPriceMult"]));
            if (_decTotalPrice < 105m)
            {
                _decTotalPrice = 105m;
            }

            //get the price per coil
            _decTotalPrice = _decTotalPrice / decCoilQuantity;

            //round up
            _decTotalPrice = Math.Ceiling(_decTotalPrice * 100m) / 100m;
        }

        //Calculate Selling Canadian Price
        private void CalculateSellingCanadianPrice()
        {
            _decSellingCanadianPrice = (_decSellingUsPrice * Conversion.SquareMeters_SquareFeet(_decFacedArea)) * _decExchange;
        }

        //Calculate Selling US Price
        private void CalculateSellingUSPrice()
        {
            _decSellingUsPrice = (_decPreTotalPrice / Conversion.SquareMeters_SquareFeet(_decFacedArea)) / (1 - _decUsd);
        }

        //Calculate Pre Total Price
        private void CalculatePreTotalPrice(decimal decCoilQuantity)
        {
            _decPreTotalPrice = (_decApplicationCostTotal + _decSundryTotal + _decTransportProductsTotal + _decReturnBendsTotal) * decCoilQuantity;
        }

        //Calculate Return Bends total
        private void CalculateReturnBendsTotal()
        {
            _decReturnBendsTotal = _decReturnBends * _decApplicationCostTotal;
        }

        //Calculate Transport Products total
        private void CalculateTransportProductTotal()
        {
            _decTransportProductsTotal = _decTransportProducts * _decApplicationCostTotal;
        }

        //Calculate Sundry Total
        private void CalculateSundryTotal()
        {
            _decSundryTotal = _decSundry * _decApplicationCostTotal;
        }

        //Calculate Application Cost Total
        private void CalculateApplicationCostTotal()
        {
            _decApplicationCostTotal = _decMaterialTotal + _decLaborTotal;
        }

        //Calculate Labor Total
        private void CalculateLaborTotal()
        {
            _decLaborTotal = (_decFacedArea / _decFacedAreaOutput) * _decLaborCost;
        }

        //Calculate Material Total
        private void CalculateMaterialTotal()
        {
            _decMaterialTotal = _decPolualTotal + _decPreTreatmentTotal + _decSafeTotal;
        }

        //Calculate Safe
        private void CalculateSafe()
        {
            _decSafeTotal = _decFinnedAreaInSquareMeter * _decSafeCost * _decSafeCoverage;
        }

        //Calculate PreTreatment
        private void CalculatePreTreatment()
        {
            _decPreTreatmentTotal = _decFinnedAreaInSquareMeter * _decPreTreatmentCost * _decPreTreatmentCoverage;
        }

        //calculate polual Material
        private void CalculatePolual(decimal decNumberOfRows)
        {
            //the default multipler we will add
            decimal decMultipler = 1m;

            //if we have 2 rows or less then the multiplier change
            if (decNumberOfRows <= 2)
            {
                decMultipler = 1.25m;
            }

            _decPolualTotal = (_decFinnedAreaInSquareMeter * _decPolualCosts * _decPolualCoverage) * decMultipler;
            
        }

        //Set the Faced Area
        private void SetFacedArea()
        {
            //Set the Faced Area
            _decFacedArea = _decCoilWidthInMeter * _decCoilLengthInMeter;
        }

        //Set Coil Measurement Variables
        private void SetCoilMeasurementVariables(decimal decFinHeight, decimal decFinLength, decimal decNumberOfRows)
        {
            //width of the coil
            _decCoilWidthInMeter = Conversion.Inches_Meters(decFinHeight);
            //Length of the coil
            _decCoilLengthInMeter = Conversion.Inches_Meters(decFinLength);
            //Depth of the coil
            _decCoilDepth = decNumberOfRows * _decBlyGoldConstant;
        }

        //set Blygold Variable
        private void SetSpecialVariables()
        {
            //set all the reference values
            _decPolualCosts = Convert.ToDecimal(Public.DSDatabase.Tables["PricingCoilBlyGold"].Rows[0]["PolualCosts"]);
            _decPolualCoverage = Convert.ToDecimal(Public.DSDatabase.Tables["PricingCoilBlyGold"].Rows[0]["PolualCoverage"]);
            _decPreTreatmentCost = Convert.ToDecimal(Public.DSDatabase.Tables["PricingCoilBlyGold"].Rows[0]["PreTreatmentCosts"]);
            _decPreTreatmentCoverage = Convert.ToDecimal(Public.DSDatabase.Tables["PricingCoilBlyGold"].Rows[0]["PreTreatmentCoverage"]);
            _decSafeCost = Convert.ToDecimal(Public.DSDatabase.Tables["PricingCoilBlyGold"].Rows[0]["SafeCosts"]);
            _decSafeCoverage = Convert.ToDecimal(Public.DSDatabase.Tables["PricingCoilBlyGold"].Rows[0]["SafeCoverage"]);
            _decLaborCost = Convert.ToDecimal(Public.DSDatabase.Tables["PricingCoilBlyGold"].Rows[0]["LaborCost"]);
            _decFacedAreaOutput = Convert.ToDecimal(Public.DSDatabase.Tables["PricingCoilBlyGold"].Rows[0]["FacedAreaOutput"]);
            _decUsd = Convert.ToDecimal(Public.DSDatabase.Tables["PricingCoilBlyGold"].Rows[0]["USD"]);
            _decExchange = Convert.ToDecimal(Public.DSDatabase.Tables["PricingCoilBlyGold"].Rows[0]["Exchange"]);
            _decSundry = Convert.ToDecimal(Public.DSDatabase.Tables["PricingCoilBlyGold"].Rows[0]["Sundry"]);
            _decReturnBends = Convert.ToDecimal(Public.DSDatabase.Tables["PricingCoilBlyGold"].Rows[0]["ReturnBends"]);
            _decTransportProducts = Convert.ToDecimal(Public.DSDatabase.Tables["PricingCoilBlyGold"].Rows[0]["TransportProducts"]);
        }

        //get the BlyGoldConstant
        private void SetBlyGoldConstant(string strFinType)
        {
            //variable used to return a value
            decimal decReturnValue = 1;

            //sort filter the table
            DataRow[] drResult = Public.DSDatabase.Tables["CoilFinType"].Copy().Select("FinType = '" + strFinType + "'");

            //if we have a result store the value
            if (drResult.Length > 0)
            {
                decReturnValue = Convert.ToDecimal(drResult[0]["BlyGoldConstant"]);
            }



            _decBlyGoldConstant = decReturnValue;
        }

        //Get Finned Area In Square Meter
        private void SetFinnedAreaInSquareMeter(decimal decCoilWidthInMeter, decimal decCoilLengthInMeter, decimal decCoilDepth, decimal decFPI)
        {
            // the X 2 at the end is that the coating is applied to both side
            //of the sheet of metal.
            _decFinnedAreaInSquareMeter = (decCoilWidthInMeter * decCoilLengthInMeter * decCoilDepth * ((decFPI / 2.54m) * 100m)) * 2m;
        }

        //return the price
        public decimal Price
        {
            get { return _decTotalPrice; }
        }

    }

    class HeresiteCoating
    {
        //variable that hold the final total
        private readonly decimal _decTotalPrice;

        public HeresiteCoating(decimal decCoilQuantity, decimal decNumberOfRows, decimal decFinHeight, decimal decFinLength)
        {
            try
            {
                //load up the table we need
                Query.LoadTables(new[] { "PricingMadocRate", "PricingCoilSetting" });

                //calculate square footage
                decimal decSquareFeetArea = ((decFinHeight + 3m) * (decFinLength + 12m)) / 144m;

                //get the madoc rate
                decimal decMadocRate = GetMadocRate(decNumberOfRows);

                //get the list price multipler
                decimal decListPriceMultiplier = GetListPriceMultiplier();

                //calculate everything
                _decTotalPrice = Math.Ceiling((decSquareFeetArea * decMadocRate * decCoilQuantity * 2m) / decListPriceMultiplier);
                
                //get the price by coil
                _decTotalPrice = _decTotalPrice / decCoilQuantity;

                //round up
                _decTotalPrice = Math.Ceiling(_decTotalPrice * 100m) / 100m;
            }
            catch(Exception ex)
            {
                Public.PushLog(ex.ToString(), "Coating HeresiteCoating");
                _decTotalPrice = 0m;
            }
        }

        //return the list price multiplier
        private decimal GetListPriceMultiplier()
        {
            return Convert.ToDecimal(Public.DSDatabase.Tables["PricingCoilSetting"].Rows[0]["ListPriceMult"]);
        }

        //return the madoc rate
        private decimal GetMadocRate(decimal decNumberOfRows)
        {
            return Convert.ToDecimal(Public.DSDatabase.Tables["PricingMadocRate"].Select("Row = " + decNumberOfRows)[0]["Price"]);
        }

        //return the price
        public decimal Price
        {
            get { return _decTotalPrice; }
        }
    }

    class ElectroFinCoating
    {
        //variable that hold the final total
        private readonly decimal _decTotalPrice;

        public ElectroFinCoating(decimal decCoilQuantity, decimal decNumberOfRows, decimal decFPI, decimal decFinHeight, decimal decFinLength)
        {
            try
            {
                //load up the table we need
                Query.LoadTables(new[] { "PricingElectroFinRate", "PricingCoilBlyGold", "PricingCoilSetting" });

                //calculate square footage
                decimal decSquareFeetArea = ((decFinHeight + 3m) * (decFinLength + 12m)) / 144m;

                //blygold exchange
                decimal decBlyGoldExchange = Convert.ToDecimal(Public.DSDatabase.Tables["PricingCoilBlyGold"].Rows[0]["Exchange"]);

                //get the list price multipler
                decimal decListPriceMultiplier = GetListPriceMultiplier();

                //variable pass as reference
                decimal decElectroFinRate = 0m;
                decimal decElectroFinMin = 0m;

                //set the reference values
                SetElectroFinRate(decNumberOfRows, decFPI, ref decElectroFinRate, ref decElectroFinMin);

                //get teh base cost
                decimal decBaseCost = Math.Ceiling(((decSquareFeetArea * decElectroFinRate) * decCoilQuantity * 2));

                //if base cost smaller than the min, bump it up to the min
                if (decBaseCost < decElectroFinMin)
                {
                    decBaseCost = decElectroFinMin;
                }

                //calculate everything
                _decTotalPrice = Math.Ceiling((decBaseCost * decBlyGoldExchange * 2m) / decListPriceMultiplier);

                //get the price by coil
                _decTotalPrice = _decTotalPrice / decCoilQuantity;

                //round up
                _decTotalPrice = Math.Ceiling(_decTotalPrice * 100m) / 100m;
            }
            catch(Exception ex)
            {
                Public.PushLog(ex.ToString(), "Coating ElectroFinCoating");
                _decTotalPrice = 0m;
            }
        }

        //return the list price multiplier
        private decimal GetListPriceMultiplier()
        {
            return Convert.ToDecimal(Public.DSDatabase.Tables["PricingCoilSetting"].Rows[0]["ListPriceMult"]);
        }

        //thie set the electro fin rate value we need for calculation
        // ReSharper disable RedundantAssignment
        private void SetElectroFinRate(decimal decNumberOfRows, decimal decFPI, ref decimal decRate, ref decimal decMin)
        // ReSharper restore RedundantAssignment
        {
            //select what we want
            DataRow[] drPricingElectroFinRate = Public.DSDatabase.Tables["PricingElectroFinRate"].Copy().Select("Row >= " + decNumberOfRows + " AND FPI >= " + decFPI);

            //clone table
            DataTable dtPricingElectroFinRate = Public.DSDatabase.Tables["PricingElectroFinRate"].Clone();
            
            //add to temp table the result
            for (int intResult = 0; intResult < drPricingElectroFinRate.Length; intResult++)
            {
                dtPricingElectroFinRate.Rows.Add(drPricingElectroFinRate[intResult].ItemArray);
            }

            //create a view to be able to sort it
            DataView dvPricingElectroFinRate = dtPricingElectroFinRate.DefaultView;

            //sort
            dvPricingElectroFinRate.Sort = "Row ASC, FPI ASC";

            //set values
            decRate = Convert.ToDecimal(dvPricingElectroFinRate.ToTable().Rows[0]["Rate"]);
            decMin = Convert.ToDecimal(dvPricingElectroFinRate.ToTable().Rows[0]["Min"]);

            //dispose
            dvPricingElectroFinRate.Dispose();
            dtPricingElectroFinRate.Dispose();
        }

        //return the price
        public decimal Price
        {
            get { return _decTotalPrice; }
        }
    }

}
