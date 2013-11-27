using System;
using System.Data;
using System.Data.OleDb;

namespace RefplusWebtools.DataManager.CondensingUnit
{
    class RefplusQuotesExcelDatabase
    {
        private const string ExcelDataBaseLocation = "P:\\Refplus\\Rpapps\\DataBase\\Refplus Quotes Condensing Unit\\";


        public DataTable GetTable(string tableName)
        {
            try
            {
                var objConn = new OleDbConnection(GetConnectionString(tableName));
                objConn.Open();
                var adp = new OleDbDataAdapter("SELECT * FROM " + tableName, objConn);
                var ds = new DataSet();
                adp.Fill(ds);
                objConn.Close();
                return ds.Tables[0];
            }
            catch(Exception ex)
            {
                Public.PushLog(ex.ToString(), "RefplusQuotesExcelDatabase GetTable");
                return null;
            }
        }

        private string GetConnectionString(string tableName)
        {
            return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ExcelDataBaseLocation + tableName + ".xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";

        }
    }
}
