using System;
using System.Data;

namespace RefplusWebtools.QuickHeatPipe
{
    class HeatPipeReport
    {
        public static string GenerateDataReport(DataTable dtQuickHeatPipe, bool openReport, int quoteID, string quoteRevisionText)
        {
            string strFileNamePath = "";

            var dsHeatPipe = new DataSet("HeatPipeDATA");
            dsHeatPipe.Tables.Add(dtQuickHeatPipe);

            //make sure we have a table and a row
            if (dsHeatPipe.Tables.Count > 0)
            {
                if (dsHeatPipe.Tables[0].Rows.Count > 0)
                {
                    //dsHeatPipe.WriteXmlSchema("HeatPipeXSD.xsd");

                    //create report document
                    var rptSpecReport = new DLLHeatPipeReport.HeatPipeSpec();

                    //set datasource
                    rptSpecReport.SetDataSource(dsHeatPipe);

                    //set varaible
                    rptSpecReport.SetParameterValue("Version", Public.ApplicationVersion);
                    rptSpecReport.SetParameterValue("Site", UserInformation.CurrentSite);
                    rptSpecReport.SetParameterValue("CustomLogo", Reg.Get(Reg.Key.CustomLogo));
                    rptSpecReport.SetParameterValue("CustomAddress", Reg.Get(Reg.Key.CustomAddress));
                    rptSpecReport.SetParameterValue("QuoteID", quoteID);
                    rptSpecReport.SetParameterValue("QuoteRevisionText", quoteRevisionText);

                    ////translate the report
                    DLLHeatPipeReport.HeatPipeReportTranslation.setReportLanguage(rptSpecReport, Public.Language);

                    //export report to pdf
                    strFileNamePath = Public.ExportReportToFormat(rptSpecReport, "SpecReport", "PDF", openReport);

                    //dispose object
                    rptSpecReport.Dispose();

                    //call garbage collector to clean out crystal report
                    GC.Collect();

                }
            }

            return strFileNamePath;
        }
    }
}
