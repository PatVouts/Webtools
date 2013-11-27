using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools
{
    class Online
    {
        /// <summary>
        /// This Function download a specific table locally using the name
        /// of the table in sql. It put everything in the XML file of the same name
        /// </summary>
        /// <param name="strSQLTableName"></param>
        public void DownloadTable(string strSQLTableName)
        {
            //connect to webservice
            var ws = new WebService.Service();
            //create dataset that will hold the values
            //sql query
            string strSqlQuery = "SELECT * FROM [" + strSQLTableName + "]";

            //select what we need
            var dsDownloadTable = (DataSet)Compression.DeCompress(ws.CompressTable(strSqlQuery, Encryption.WebServiceEncryptKey()));

            var encrypt = new XMLEncryptor();

            encrypt.WriteEncryptedXML(dsDownloadTable, FolderManager.Resources + "\\" + strSQLTableName + ".xml");


            dsDownloadTable.Dispose();

            ws.Dispose();
        }


        public DataSet Select(string tsql)
        {
           try
            {
                //connect to webservice
                var ws = new WebService.Service();

                //create dataset that will hold the values
                var dsTable = (DataSet)Compression.DeCompress(ws.CompressTable(tsql, Encryption.WebServiceEncryptKey()));

                ws.Dispose();

                return dsTable;
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(), "Online select");
                return null;
            }
        }

        public bool Execute(string tsql)
        {
            try
            {
                //connect to webservice
                var ws = new WebService.Service();
                //create dataset that will hold the values
                bool bolExecute = ws.Execute(tsql, Encryption.WebServiceEncryptKey());

                ws.Dispose();

                return bolExecute;
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(), "Online execute");
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public string GetSessionID()
        {
            try
            {
                //connect to webservice
                var ws = new WebService.Service();

                string strSessionID = ws.ObtainSessionID();

                ws.Dispose();

                return strSessionID;
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(), "Online GetSessionID");
                return null;
            }
        }

        public string GetWanIP()
        {
            try
            {
                //connect to webservice
                var ws = new WebService.Service();

                string strWanIP = ws.GetWanIP();

                ws.Dispose();

                return strWanIP;
            }
            catch (Exception ex)
            {
                
                Public.PushLog(ex.ToString(), "Online GetWanIP");
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        
    }
}
