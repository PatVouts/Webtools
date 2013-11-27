using System;
using System.Data;

namespace RefplusWebtools.QuickWaterEvaporator
{
    class WaterEvaporatorReport
    {
        public static string GenerateDataReport(DataTable dtWaterEvap, DataTable dtOptions, bool openReport, int quoteID, string quoteRevisionText)
        {
            var dsWaterEvap = new DataSet("WaterEvaporatorDATA");
            dsWaterEvap.Tables.Add(dtWaterEvap.Copy());
            //dsWaterEvap.WriteXmlSchema("WaterEvaporatorXSD.xsd");

            var dsOption = new DataSet("WaterEvaporatorOptionDATA");
            dsOption.Tables.Add(dtOptions.Copy());
            //dsOption.WriteXmlSchema("WaterEvaporatorOptionXSD.xsd");

            //instanciate the report
            var rptSpecReport = new DLLWaterEvaporatorReport.QuickWaterEvapSpec();

            //set datasource
            rptSpecReport.SetDataSource(dsWaterEvap);
            rptSpecReport.Subreports["EvaporatorOption.rpt"].SetDataSource(dsOption);

            rptSpecReport.SetParameterValue("DLLVersion", Public.KFRefplus_VERSION());
            rptSpecReport.SetParameterValue("Version", Public.ApplicationVersion);
            rptSpecReport.SetParameterValue("Site", UserInformation.CurrentSite);
            rptSpecReport.SetParameterValue("CustomLogo", Reg.Get(Reg.Key.CustomLogo));
            rptSpecReport.SetParameterValue("CustomAddress", Reg.Get(Reg.Key.CustomAddress));
            rptSpecReport.SetParameterValue("QuoteID", quoteID);
            rptSpecReport.SetParameterValue("QuoteRevisionText", quoteRevisionText);

            //translate the report
            DLLWaterEvaporatorReport.WaterEvapSpecTranslationReport.translateReport(rptSpecReport, Public.Language);

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
