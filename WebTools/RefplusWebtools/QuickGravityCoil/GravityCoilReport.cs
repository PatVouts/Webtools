using System;
using System.Data;

namespace RefplusWebtools.QuickGravityCoil
{
    class GravityCoilReport
    {
        public static string GenerateDataReport(DataTable dtGravityCoil, bool openReport, int quoteID, string quoteRevisionText)
        {
            var dsGravCoil = new DataSet("GravityCoilDATA");
            dsGravCoil.Tables.Add(dtGravityCoil.Copy());
            //dsGravCoil.WriteXmlSchema("GravityCoilXSD.xsd");

            //instanciate the report
            var rptSpecReport = new DLLGravityCoilReport.QuickGravityCoilSpec();
            //set datasource
            rptSpecReport.SetDataSource(dsGravCoil);

            rptSpecReport.SetParameterValue("DLLVersion", Public.KFRefplus_VERSION());
            rptSpecReport.SetParameterValue("Version", Public.ApplicationVersion);
            rptSpecReport.SetParameterValue("Site", UserInformation.CurrentSite);
            rptSpecReport.SetParameterValue("CustomLogo", Reg.Get(Reg.Key.CustomLogo));
            rptSpecReport.SetParameterValue("CustomAddress", Reg.Get(Reg.Key.CustomAddress));
            rptSpecReport.SetParameterValue("QuoteID", quoteID);
            rptSpecReport.SetParameterValue("QuoteRevisionText", quoteRevisionText);

            //translate the report
            DLLGravityCoilReport.GravityCoilReportTranslation.translateReport(rptSpecReport, Public.Language);

            //export to pdf
            string strFileNamePath = Public.ExportReportToFormat(rptSpecReport, Public.GenerateFileNameAndPath("SpecReport", "pdf"), "PDF", openReport);

            //dispose object
            rptSpecReport.Dispose();

            //call garbage collector to clean out crystal report
            GC.Collect();

            return strFileNamePath;
        }
    }
}
