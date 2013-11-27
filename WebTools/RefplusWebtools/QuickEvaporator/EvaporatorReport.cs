using System;
using System.Data;

namespace RefplusWebtools.QuickEvaporator
{
    class EvaporatorReport
    {
        public static string GenerateDataReport(DataTable dtEvap, DataTable dtOptions, bool openReport, int quoteID, string quoteRevisionText)
        {
            var dsEvap = new DataSet("EvaporatorDATA");
            dsEvap.Tables.Add(dtEvap.Copy());
            //dsEvap.WriteXmlSchema("EvaporatorXSD.xsd");

            var dsOption = new DataSet("EvaporatorOptionDATA");
            dsOption.Tables.Add(dtOptions.Copy());
            //dsOption.WriteXmlSchema("EvaporatorOptionXSD.xsd");

            //instanciate the report
            var rptSpecReport = new DLLEvaporatorReport.QuickEvapSpec();

            //set datasource
            rptSpecReport.SetDataSource(dsEvap);
            rptSpecReport.Subreports["EvaporatorOption.rpt"].SetDataSource(dsOption);

            rptSpecReport.SetParameterValue("DLLVersion", Public.KFRefplus_VERSION());
            rptSpecReport.SetParameterValue("Version", Public.ApplicationVersion);
            rptSpecReport.SetParameterValue("Site", UserInformation.CurrentSite);
            rptSpecReport.SetParameterValue("CustomLogo", Reg.Get(Reg.Key.CustomLogo));
            rptSpecReport.SetParameterValue("CustomAddress", Reg.Get(Reg.Key.CustomAddress));
            rptSpecReport.SetParameterValue("QuoteID", quoteID);
            rptSpecReport.SetParameterValue("QuoteRevisionText", quoteRevisionText);

            //translate the report
            DLLEvaporatorReport.EvapSpecReportTranslation.translateReport(rptSpecReport, Public.Language);

            //export to pdf
            string strFileNamePath = Public.ExportReportToFormat(rptSpecReport, Public.GenerateFileNameAndPath("SpecReport", "pdf"), "PDF", openReport);

            //dispose object
            rptSpecReport.Dispose();

            //call garbage collector to clean out crystal report
            GC.Collect();

            return strFileNamePath;
        }

        public static string GenerateTechReport(DataTable dtEvap, bool openReport)
        {
            var dsEvap = new DataSet("EvaporatorDATA");
            dsEvap.Tables.Add(dtEvap.Copy());

            //instanciate the report
            var rptTechReport = new DLLEvaporatorReport.EvapTechnical();

            //set datasource
            rptTechReport.SetDataSource(dsEvap);

            rptTechReport.SetParameterValue("DLLVersion", Public.KFRefplus_VERSION());
            rptTechReport.SetParameterValue("Version", Public.ApplicationVersion);
            rptTechReport.SetParameterValue("Site", UserInformation.CurrentSite);
            rptTechReport.SetParameterValue("CustomLogo", Reg.Get(Reg.Key.CustomLogo));
            rptTechReport.SetParameterValue("CustomAddress", Reg.Get(Reg.Key.CustomAddress));

            //translate the report
            DLLEvaporatorReport.EvapTechnicalReportTranslation.translateReport(rptTechReport, Public.Language);

            //export to pdf
            string strFileNamePath = Public.ExportReportToFormat(rptTechReport, Public.GenerateFileNameAndPath("TechReport", "pdf"), "PDF", openReport);

            //dispose object
            rptTechReport.Dispose();

            //call garbage collector to clean out crystal report
            GC.Collect();

            return strFileNamePath;
        }
    }
}
