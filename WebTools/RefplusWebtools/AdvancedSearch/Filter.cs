using System;
using System.Data;

namespace RefplusWebtools.AdvancedSearch
{
    //This class is used to build a proper filter for the query to check the quotes.  It is used in conjunction with frmAdvancedSearch, building up a row in the table "v_advancedSearch" before using said
    //table to build an actual filter
    internal class Filter
    {
        private readonly DataRow _drFilterData;
        private readonly int _id = -1;

        //Standard constructor, fetching the info on the field in the database table "advanced search"
        public Filter(int id)
        {
            _id = id;
            _drFilterData =
                Public.SelectAndSortTable(Public.DSDatabase.Tables["AdvancedSearch"], "ID = " + _id, "").Rows[0];
        }

        //Returns the filterData 
        public DataRow GetFilterData()
        {
            return _drFilterData;
        }

        //Returns the ID of the filter
        public int GetID()
        {
            return _id;
        }

        //Returns the table name from the datatable
        public string GetTableName()
        {
            return _drFilterData["TableName"].ToString();
        }

        //Returns the correct string, depending on the text of the user, to show the name of the field searched.
        public string GetLanguageRelatedText()
        {
            return Public.LanguageString(_drFilterData["EnglishText"].ToString(), _drFilterData["FrenchText"].ToString());
        }

        //Returns the correct field type for the attribute needed.
        public Type GetFieldType()
        {
            //if it's not from the table advancedSearchQUote, means it's looking at a model from another table, so it's a string by default.
            if (GetTableName() == "v_AdvancedSearchQuote")
            {
                if (Tables.QuoteTable().Columns[_drFilterData["Value"].ToString()] == null)
                {
                    return typeof (string);
                }
                return Tables.QuoteTable().Columns[_drFilterData["Value"].ToString()].DataType;
            }
            return typeof (string);
        }

        //Function to build an actual filter for the advanced search (builds an = or a like if String, and an =, <, > for the rest
        public string GetFilter(string sValue, string sSymbol)
        {
            Type t = GetFieldType();

            if (t == typeof (string))
            {
                if (sSymbol == "=")
                {
                    return _drFilterData["Value"] + " = '" + sValue + "'";
                }
                return _drFilterData["Value"] + " LIKE '%" + sValue + "%'";
            }
            if (t == typeof (DateTime))
            {
                return _drFilterData["Value"] + " " + sSymbol + " convert(datetime,'" + sValue + "')";
            }
            return _drFilterData["Value"] + " " + sSymbol + " " + sValue + "";
        }
    }
}