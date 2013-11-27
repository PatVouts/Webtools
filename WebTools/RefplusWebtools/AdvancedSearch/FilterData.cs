namespace RefplusWebtools.AdvancedSearch
{
    class FilterData
    {
        private readonly Filter _selectedFilter;
        private readonly string _symbol = "";
        private readonly string _value = "";

        //Builder assigning filter, symbol and value to the correct values
        public FilterData(Filter filter, string sSymbol, string sValue)
        {
            _selectedFilter = filter;
            _symbol = sSymbol;
            _value = sValue;
        }

        //Returns the filter
        public Filter GetFilter()
        {
            return _selectedFilter;
        }

        //Returns the boolean symbol used
        public string GetSymbol()
        {
            return _symbol;
        }

        //Returns the value searched
        public string GetValue()
        {
            return _value;
        }
    }
}