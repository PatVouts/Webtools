using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace UpdatePusher
{
    class Online
    {
        /// <summary>
        /// This Function download a specific table locally using the name
        /// of the table in sql. It put everything in the XML file of the same name
        /// </summary>
        /// <param name="strSQLTableName"></param>
       


        public DataSet Select(string TSQL)
        {
           try
            {
                //connect to webservice
                WebService.Service ws = new WebService.Service();

                //create dataset that will hold the values
                DataSet dsTable = (DataSet)Compression.DeCompress(ws.CompressTable(TSQL, Encryption.WebServiceEncryptKey()));

                ws.Dispose();
                ws = null;

                return dsTable;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public bool Execute(string TSQL)
        {
            try
            {
                //connect to webservice
                WebService.Service ws = new WebService.Service();
                string value = ws.GetVersion(DataEncryption.EncryptKeyWord());
                //create dataset that will hold the values
                bool bolExecute = ws.Execute(TSQL, Encryption.WebServiceEncryptKey());

                ws.Dispose();
                ws = null;

                return bolExecute;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
    }
}
