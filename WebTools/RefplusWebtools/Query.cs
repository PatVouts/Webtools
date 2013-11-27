using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace RefplusWebtools
{
    //this class is used to query Online or Offline depending on the mode
    /// <summary>
    /// This Class will use the Online or Offline class depending on the needs
    /// It's also used to download and retreive tables. And finally
    /// It's used to manipulate genirec data
    /// </summary>
    class Query
    {
        //return webservice url
        public static string GetWebServiceUrl()
        {
            string url = "";
            // Get the path of the webservice xml file (url).
            const string urlPath = "WebServiceConfig.xml";
            var dtUrl = new DataTable("WebServiceConfig");
            dtUrl.Columns.Add("url", typeof(string));
            // if the web service url file exist.
            if (File.Exists(urlPath))
            {
                try
                {
                    // Read the path from the xml file.
                    dtUrl.ReadXml(urlPath);
                    if (dtUrl.Rows.Count > 0)
                    {
                        //put the path in the variable
                            url = dtUrl.Rows[0][0].ToString();
                    }
                }
                catch(Exception ex)
                {
                    Public.PushLog(ex.ToString(), "Query GetWebServiceURL");
                    MessageBox.Show(@"Error while getting connection information.");
                    Environment.Exit(0);
                }
            }
            return url;
        }

        public static void CreateLog(DataTable dtTableWithData, string logTableName, string description)
        {
            foreach (DataRow dr in dtTableWithData.Rows)
            {
                string tsql = "INSERT INTO " + logTableName + " (";

                string columns = "";

                foreach (DataColumn dc in dtTableWithData.Columns)
                {
                    columns += "," + dc.ColumnName;
                }

                columns += ",Username,Description";

                tsql += columns.Substring(1) + ") VALUES (";

                string values = "";

                foreach (DataColumn dc in dtTableWithData.Columns)
                {
                    if (dc.DataType == typeof(string) || dc.DataType == typeof(DateTime))
                    {
                        values += ",'" + dr[dc] + "'";
                    }
                    else
                    {
                        values += "," + dr[dc];
                    }
                }
                values += ",'" + UserInformation.UserName + "','" + description + "'";

                tsql += values.Substring(1) + ")";

                Execute(tsql);
            }

        }

        public static void Set_FluidCoolerModel(DataTable dtFluidCoolerModel)
        {
            //if the column Cap (the first we add) don't exist we can add the
            //new columns, else that mean it already been added so we have nothing to do
            if (dtFluidCoolerModel.Columns["Cap"] == null)
            {
                //add the columns we need to work with
                dtFluidCoolerModel.Columns.Add("Cap", typeof(decimal));
                dtFluidCoolerModel.Columns.Add("LeavingLiquid", typeof(decimal));
                dtFluidCoolerModel.Columns.Add("PressureDrop", typeof(decimal));
                dtFluidCoolerModel.Columns.Add("LeavingAir", typeof(decimal));
                dtFluidCoolerModel.Columns.Add("LiquidVelocity", typeof(decimal));
                dtFluidCoolerModel.Columns.Add("GPM", typeof(decimal));
                dtFluidCoolerModel.Columns.Add("FluidCoolerModel", typeof(string));
                //2011-01-31 : this column name has been change because we are
                //changing the fluid cooler selection and the new table we are using
                //alreayd contain a column named price.
                dtFluidCoolerModel.Columns.Add("FluidCoolerPrice", typeof(decimal));
                dtFluidCoolerModel.Columns.Add("ConnectionSize", typeof(decimal));
                dtFluidCoolerModel.Columns.Add("CoilFaceArea", typeof(decimal));
                dtFluidCoolerModel.Columns.Add("FaceVelocity", typeof(decimal));
                dtFluidCoolerModel.Columns.Add("AirPressureDrop", typeof(decimal));
                dtFluidCoolerModel.Columns.Add("EnteringDryBulb", typeof(decimal));
                dtFluidCoolerModel.Columns.Add("EnteringLiquidTemperature", typeof(decimal));
                dtFluidCoolerModel.Columns.Add("FluidType", typeof(string));
                dtFluidCoolerModel.Columns.Add("Concentration", typeof(decimal));
                dtFluidCoolerModel.Columns.Add("Altitude", typeof(decimal));
                dtFluidCoolerModel.Columns.Add("PowerSupply", typeof(string));
                dtFluidCoolerModel.Columns.Add("SpecificHeat", typeof(decimal));
                dtFluidCoolerModel.Columns.Add("Density", typeof(decimal));
                dtFluidCoolerModel.Columns.Add("Viscosity", typeof(decimal));
                dtFluidCoolerModel.Columns.Add("ThermalConductivity", typeof(decimal));
                dtFluidCoolerModel.Columns.Add("FluidTypeName", typeof(string));
                dtFluidCoolerModel.Columns.Add("VoltageID", typeof(int));
                dtFluidCoolerModel.Columns.Add("AirFlowType", typeof(string));
                dtFluidCoolerModel.Columns.Add("FLA", typeof(decimal));
                dtFluidCoolerModel.Columns.Add("PumpFLA", typeof(decimal));
                dtFluidCoolerModel.Columns.Add("ShipWeight", typeof(decimal));
                dtFluidCoolerModel.Columns.Add("Dwg", typeof(string));
                dtFluidCoolerModel.Columns.Add("FanHP", typeof(string));
                dtFluidCoolerModel.Columns.Add("FanRPM", typeof(string));
            }
        }

        public static void DownloadTable(string strSQLTableName)
        {
            if (Public.BolOnline) //if online
            {
                //online feature only
                //declare good class
                var workMode = new Online();
                //call the function
                workMode.DownloadTable(strSQLTableName);
                //close and disposed correctly everything
            }
        }

 

        public static DataSet SelectDS(string tsql)
        {
            if (Public.BolOnline) //if online
            {
                //online feature only
                //declare good class
                var workMode = new Online();
                //call the function
                DataSet dsSelect = workMode.Select(tsql);
                //close and disposed correctly everything

                return dsSelect;
            }
            return null;
        }


        public static DataTable Select(string tsql)
        {
            if (Public.BolOnline) //if online
            {
                //online feature only
                //declare good class
                var workMode = new Online();
                //call the function
                DataSet dsSelect = workMode.Select(tsql);
                return dsSelect.Tables[0];
            }
            return null;
        }

        public static bool UpdateServerTableVersion(string strTableName)
        {
            return Execute("UPDATE ServerTableVersion SET Version = Version + 1 WHERE Name = '" + strTableName + "'");
        }

        public static bool Execute(string tsql)
        {
            if (Public.BolOnline) //if online
            {
                //online feature only
                //declare good class
                var workMode = new Online();
                //call the function

                bool bolExecute = workMode.Execute(tsql);

                return bolExecute;
            }
            return false;
        }

        public static string GetSessionID()
        {
            if (Public.BolOnline) //if online
            {
                //online feature only
                //declare good class
                var workMode = new Online();
                //call the function
                string strSessionID = workMode.GetSessionID();
                //close and disposed correctly everything

                return strSessionID;
            }
            return null;
        }

        public static string GetWanIP()
        {
            if (Public.BolOnline) //if online
            {
                //online feature only
                //declare good class
                var workMode = new Online();
                //call the function
                string strWanIP = workMode.GetWanIP();
                //close and disposed correctly everything

                return strWanIP;
            }
            return null;
        }

        //unload one or multiple tables
        public static void UnloadTables(string[] strTables)
        {
            for (int intTables = 0; intTables < strTables.Length; intTables++)
            {
                if (Public.DSDatabase.Tables[strTables[intTables]] != null)
                {
                    Public.DSDatabase.Tables.Remove(strTables[intTables]);
                }
            }
        }


        public static void LoadTables(string[] strTables)
        {
            string errorMessages = "";

            //Make Sure TableVersion Exist Locally
            MakeSureTableVersionExistLocally();

            //client table version
            DataTable dtClientTableVersion = GetTable("TableVersion");

            //server table version
            DataTable dtServerTableVersion = Select("SELECT * FROM ServerTableVersion");

            for (int intTables = 0; intTables < strTables.Length; intTables++)
            {
                DataRow[] drClientTableVersion = dtClientTableVersion.Select("Name = '" + strTables[intTables] + "'");
                DataTable dtServer = Public.SelectAndSortTable(dtServerTableVersion, "Name = '" + strTables[intTables] + "'", "");

                if (dtServer.Rows.Count == 0)
                {
                    errorMessages += "Table " + strTables[intTables] + " not contained in server table version" + Environment.NewLine;
                }
                else
                {
                    if (drClientTableVersion.Length == 0)
                    {
                        //client doesnt have table

                        for (int i = 0; i < 3; i++)
                        {//3 try loop to download and save table
                            try
                            {
                                //get dataset
                                DataSet dsTable = SelectDS("SELECT * FROM [" + strTables[intTables] + "]");

                                //save to disk
                                SaveTableToDisk(dsTable, strTables[intTables]);

                                //add the new one
                                dtClientTableVersion.Rows.Add(dtServer.Rows[0].ItemArray);

                                //if it went here it work so no need to retry
                                i = 3;
                            }
                            catch (Exception ex)
                            {
                                Public.PushLog(ex.ToString(),"Query LoadTables catch1");
                                if (i == 2)
                                {
                                    errorMessages += ex.Message + Environment.NewLine;
                                }
                            }
                        }
                    }
                    else
                    {
                        //client have table

                        //the the client version is older then download the table
                        //and remove from the client the table nad add the new reference
                        //sicne update is tricky on datatable it's easier to remove
                        //a row and add a new one than looping and update
                           if (Convert.ToInt32(drClientTableVersion[0]["Version"]) < Convert.ToInt32(dtServer.Rows[0]["Version"]))
                        {
                            for (int i = 0; i < 3; i++)
                            {//3 try loop to download and save table
                                try
                                {
                                    //get dataset
                                    DataSet dsTable = SelectDS("SELECT * FROM [" + strTables[intTables] + "]");

                                    //save to disk
                                    SaveTableToDisk(dsTable, strTables[intTables]);

                                    //remove the row in client table to put new one
                                    dtClientTableVersion.Rows.Remove(drClientTableVersion[0]);

                                    //add the new one
                                    dtClientTableVersion.Rows.Add(dtServer.Rows[0].ItemArray);

                                    //if it went here it work so no need to retry
                                    i = 3;
                                }
                                catch (Exception ex)
                                {
                                    Public.PushLog(ex.ToString(), "Query LoadTables catch2");
                                    if (i == 2)
                                    {
                                        errorMessages += ex.Message + Environment.NewLine;
                                    }
                                }
                            }
                        }

                    }

                    //if table exist
                    if (Public.DSDatabase.Tables[strTables[intTables]] != null)
                    {
                        //remove table
                        Public.DSDatabase.Tables.Remove(strTables[intTables]);
                    }

                    //add the table
                    Public.DSDatabase.Tables.Add(GetTable(strTables[intTables]));
                }
            }



            if (errorMessages != "")
            {
                MessageBox.Show(errorMessages);
            }
            else
            {
                //save client version table
                var encrypt = new XMLEncryptor();
                encrypt.WriteEncryptedXML(dtClientTableVersion, FolderManager.Resources + "\\TableVersion.xml");
            }
        }

        //load tables into the main dataset dsDATABASE for readability
        //everywhere
        public static void LoadTables_OLD(string[] strTables)
        {
            //Make Sure TableVersion Exist Locally
            MakeSureTableVersionExistLocally();

            //load TableVersion (client)
            DataTable dtTableVersion = GetTable("TableVersion");

            //download latest server table version
            DownloadTable("ServerTableVersion");

            //load the file in memory
            DataTable dtTableVersionServer = GetTable("ServerTableVersion");

            //loop for all tables we are looking for
            for (int intTables = 0; intTables < strTables.Length; intTables++)
            {
                if (Public.BolOnline) //if online
                {
                    //boolean that tell if the talbe has been updated or not
                    //it's used to know if we have to delete and reload the table
                    //if dsDATABASE if it was existing, because if no new table downloaded
                    //we have no need to realod it.
                    bool bolTableUpdated = false;

                    //find the table in both tableversion
                    DataRow[] drTableVersion = dtTableVersion.Select("Name = '" + strTables[intTables] + "'");
                    DataRow[] drTableVersionServer = dtTableVersionServer.Select("Name = '" + strTables[intTables] + "'");

                    //if we find it on client then compare versions
                    if (drTableVersion.Length > 0)
                    {
                        //the the client version is older then download the table
                        //and remove from the client the table nad add the new reference
                        //sicne update is tricky on datatable it's easier to remove
                        //a row and add a new one than looping and update
                        if (Convert.ToInt32(drTableVersion[0]["Version"]) < Convert.ToInt32(drTableVersionServer[0]["Version"]))
                        {
                            //download the table
                            DownloadTable(strTables[intTables]);

                            //remove the row
                            dtTableVersion.Rows.Remove(drTableVersion[0]);

                            //add the new one
                            dtTableVersion.Rows.Add(drTableVersionServer[0].ItemArray);

                            //put the table update to true we need to reload that
                            //table i nthe dataset
                            bolTableUpdated = true;
                        }
                    }
                    else // no existing on client
                    {
                        //download the table
                        DownloadTable(strTables[intTables]);

                        //add the table to the list
                        dtTableVersion.Rows.Add(drTableVersionServer[0].ItemArray);
                    }

                    //if table exist AND the table has been updated
                    if (Public.DSDatabase.Tables[strTables[intTables]] != null)
                    {
                        if (bolTableUpdated)
                        {
                            //remove table
                            Public.DSDatabase.Tables.Remove(strTables[intTables]);
                            //add the table
                            Public.DSDatabase.Tables.Add(GetTable(strTables[intTables]));
                        }
                    }
                    else
                    {
                        //add the table
                        Public.DSDatabase.Tables.Add(GetTable(strTables[intTables]));
                    }
                }
                else //if offline
                {
                    //if table don't exist exist
                    if (Public.DSDatabase.Tables[strTables[intTables]] == null)
                    {
                        //add the table
                        Public.DSDatabase.Tables.Add(GetTable(strTables[intTables]));
                    }
                    //no else because the table already there and we are not
                    //online so we can't have a different version
                }
            }

            if (Public.BolOnline) //if online
            {
                var encrypt = new XMLEncryptor();

                encrypt.WriteEncryptedXML(dtTableVersion, FolderManager.Resources + "\\TableVersion.xml");

            }

            //disposing object
            dtTableVersion.Dispose();
            dtTableVersionServer.Dispose();
        }
        
        //Make Sure Table Version Exist Locally
        private static void MakeSureTableVersionExistLocally()
        {
            var encrypt = new XMLEncryptor();

            //the dataset is null if the file don't exist or not encrypted

            DataSet dsTest = encrypt.ReadEncryptedXML(FolderManager.Resources + "\\TableVersion.xml");

            if (dsTest == null)
            {
                DataTable dtTableVersion = Tables.DtTableVersion();

                encrypt.WriteEncryptedXML(dtTableVersion, FolderManager.Resources + "\\TableVersion.xml");

                dtTableVersion.Dispose();
            }


        }

        //this return a datatable containing the table informations
        //the tablename is the name of we pass to it.
        //it should at 99.9% reflect the name of the XML file and the name of the
        //corresponding Table/View in SQL
        private static DataTable GetTable(string strTable)
        {
            var dtTable = new DataTable(strTable);
            //if the file exist
            if (File.Exists(FolderManager.Resources + "\\" + strTable + ".xml"))
            {
                var encrypt = new XMLEncryptor();

                //load the xml and return it
                DataSet dsTable = encrypt.ReadEncryptedXML(FolderManager.Resources + "\\" + strTable + ".xml");

                //put the result in the table
                dtTable = dsTable.Tables[0].Copy();

                //rename the table
                dtTable.TableName = strTable;

                //dispose
                dsTable.Dispose();

                return dtTable;
            }
            return dtTable;
        }
      
        /// <summary>
        /// Passing the ElectroFinAdjustement Table and Rows and FPI it will return True if Electrofin Available and False if it's not
        /// </summary>
        /// <param name="dtElectroFinAdjustement"></param>
        /// <param name="intNumberOfRows"></param>
        /// <param name="intFPI"></param>
        /// <returns></returns>
        public static bool IsElectroFinAvailable(DataTable dtElectroFinAdjustement, int intNumberOfRows, int intFPI)
        {
            if (dtElectroFinAdjustement.Select("Rows = " + intNumberOfRows + " AND FPI = " + intFPI).Length > 0)
            {//if we found a record we can have electrofin
                return true;
            }
            //no record found so we don't have electrofin
            return false;
        }

        /// <summary>
        /// Passing the HeresiteSafety Table and the CoilHeight and CoilLength it 
        /// return True if the Coil can be Herisite and False if it cannot
        /// </summary>
        /// <param name="dtHeresiteSafety"></param>
        /// <param name="fltCoilHeight"></param>
        /// <param name="fltCoilLength"></param>
        /// <returns></returns>
        public static bool IsHeresiteAvailable(DataTable dtHeresiteSafety, decimal fltCoilHeight, decimal fltCoilLength)
        {
            //if the (Coil Height + Safety <= Bath Height) AND (Coil Length + Safety <= Bath Length)
            if ((fltCoilHeight + Convert.ToDecimal(dtHeresiteSafety.Rows[0]["HeightSafety"]) <= Convert.ToDecimal(dtHeresiteSafety.Rows[0]["BathHeight"])) && (fltCoilHeight + Convert.ToDecimal(dtHeresiteSafety.Rows[0]["LengthSafety"]) <= Convert.ToDecimal(dtHeresiteSafety.Rows[0]["BathLength"])))
            {//we can have Heresite
                return true;
            }
            //We cannot have Heresite
            return false;
        }

        //this function remove inactive from a table
        public static DataTable RemoveInactiveRecords(DataTable dtRemoveInactive)
        {
            //table to return
            DataTable dtReturnTable = dtRemoveInactive.Clone();

            //select active only
            DataRow[] drRemoveInactive = dtRemoveInactive.Select("Active = 1");

            //for each result add row to the return table
            for (int intRow = 0; intRow < drRemoveInactive.Length; intRow++)
            {
                dtReturnTable.Rows.Add(drRemoveInactive[intRow].ItemArray);
            }

            return dtReturnTable;
        }

        public static string BuildInsertQuery(DataTable dt, string tableToInsertIn)
        {
            string strSQLStart = " INSERT INTO " + tableToInsertIn + " (";
            const string strSQLMiddle = ") VALUES (";
            const string strSQLEnd = ") ";

            string strFinalQuery = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strSQLFields = "";
                string strSQLValues = "";

                foreach (DataColumn dc in dt.Columns)
                {
                    if (!ExcludeColumn(tableToInsertIn, dc.ColumnName))
                    {
                        strSQLFields += "," + "[" + dc.ColumnName + "]";

                        if (dc.DataType == typeof(string))
                        {
                            strSQLValues += ",'" + dt.Rows[i][dc.ColumnName].ToString().Replace("'", "''") + "'";
                            
                        }
                        else if (dc.DataType == typeof(DateTime))
                        {
                            if (dt.Rows[i][dc.ColumnName].ToString() == "")
                            {
                                strSQLValues += ", null ";
                            }
                            else
                            {
                                strSQLValues += ",'" + dt.Rows[i][dc.ColumnName] + "'";
                            }
                        }
                        else if (dc.DataType == typeof(bool))
                        {
                           strSQLValues += "," + (Convert.ToBoolean(dt.Rows[i][dc.ColumnName]) ? 1 : 0);
                        }
                        else
                        {
                            if (dt.Rows[i][dc.ColumnName].ToString() == "")
                            {
                                strSQLValues += ", null ";
                            }
                            else
                            {
                                strSQLValues += "," + dt.Rows[i][dc.ColumnName];
                            }
                        }
                    }
                }

                strFinalQuery += strSQLStart;
                strFinalQuery += strSQLFields.Substring(1);
                strFinalQuery += strSQLMiddle;
                strFinalQuery += strSQLValues.Substring(1);
                strFinalQuery += strSQLEnd;
            }

            return strFinalQuery;
        }

        public static string BuildInsertQueryPerRow(DataTable dt, int row, string tableToInsertIn)
        {
            string strSQLStart = " INSERT INTO " + tableToInsertIn + " (";
            const string strSQLMiddle = ") VALUES (";
            const string strSQLEnd = ") ";

            string strFinalQuery = "";

            string strSQLFields = "";
            string strSQLValues = "";

            foreach (DataColumn dc in dt.Columns)
            {
                strSQLFields += "," + "[" + dc.ColumnName + "]";

                if (dc.DataType == typeof(string))
                {
                    strSQLValues += ",'" + dt.Rows[row][dc.ColumnName].ToString().Replace("'", "''") + "'";
                }
                else if (dc.DataType == typeof(DateTime))
                {
                    strSQLValues += ",'" + dt.Rows[row][dc.ColumnName] + "'";
                }
                else if (dc.DataType == typeof(bool))
                {
                    strSQLValues += "," + (Convert.ToBoolean(dt.Rows[row][dc.ColumnName]) ? 1 : 0);
                }
                else
                {
                    strSQLValues += "," + dt.Rows[row][dc.ColumnName];
                }
            }

            strFinalQuery += strSQLStart;
            strFinalQuery += strSQLFields.Substring(1);
            strFinalQuery += strSQLMiddle;
            strFinalQuery += strSQLValues.Substring(1);
            strFinalQuery += strSQLEnd;


            return strFinalQuery;
        }

        public static void SaveTableToDisk(DataSet ds, string tableName)
        {

            var encrypt = new XMLEncryptor();

            encrypt.WriteEncryptedXML(ds, FolderManager.Resources + "\\" + tableName + ".xml");
        }

        private static bool ExcludeColumn(string tableToInsertIn, string columnName)
        {
            return tableToInsertIn == "QuoteData" && columnName == "QuotationDate";
        }
    }
}
