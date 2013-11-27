using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace RefplusWebtoolsUpdater
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
            string urlPath = "WebServiceConfig.xml";
            DataTable dtUrl = new DataTable("WebServiceConfig");
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
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Error while getting connection information.");
                    Environment.Exit(0);
                    return url;
                }
            }
            return url;
        }
        public static DataTable Select(string TSQL)
        {
            if (Public.bolOnline) //if online
            {
                //online feature only
                //declare good class
                Online WorkMode = new Online();
                //call the function
                DataSet dsSelect = WorkMode.Select(TSQL);
                //close and disposed correctly everything
                WorkMode = null;

                return dsSelect.Tables[0];
            }
            else
            {
                return null;
            }
        }
    }
}
