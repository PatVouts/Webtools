using System;
using System.Data;

namespace RefplusWebtools.QuickCustomUnit
{
    class CustomUnitReport
    {
        public static string GenerateDataReport(DataTable dtCusUnit, bool openReport, int quoteID, string quoteRevisionText)
        {
            //create dataset to pass to report
            var dsCustomUnit = new DataSet("CustomUnitDATA");

            //add the table format to it
            dsCustomUnit.Tables.Add(dtCusUnit.Copy());
            //dsCustomUnit.WriteXmlSchema("QuickCustomUnitXSD.xsd");

            //instanciate the report
            var rptSpecReport = new DLLCustomUnit.CustomUnitSpec();
            //set datasource
            rptSpecReport.SetDataSource(dsCustomUnit);
            rptSpecReport.SetParameterValue("CustomLogo", Reg.Get(Reg.Key.CustomLogo));
            rptSpecReport.SetParameterValue("CustomAddress", Reg.Get(Reg.Key.CustomAddress));
            rptSpecReport.SetParameterValue("QuoteID", quoteID);
            rptSpecReport.SetParameterValue("QuoteRevisionText", quoteRevisionText);

            //translate report   
            DLLCustomUnit.CustomReportTranslation.translateReport(rptSpecReport, Public.Language);

            //export to pdf
            string strFilePath = Public.ExportReportToFormat(rptSpecReport, "tmpSpecReport", "PDF", openReport);

            //dispose object
            rptSpecReport.Dispose();
            //call garbage collector to clean out crystal report
            GC.Collect();
            return strFilePath;
        }


    }
}
