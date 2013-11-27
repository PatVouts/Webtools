using System;
using System.Data;

namespace RefplusWebtools.QuickCondensingUnit
{
    class CondensingUnitReport
    {
        public static string GenerateDataReport(DataTable dtCondensingUnit, DataTable dtCondensingUnitCompressors, DataTable dtCondensingUnitWaterCooledCondensers, DataTable dtCondensingUnitOptions, bool openReport, int quoteID, string quoteRevisionText)
        {
            var dsCondensingUnit = new DataSet("CondensingUnitDATA");
            dsCondensingUnit.Tables.Add(dtCondensingUnit.Copy());
            //dsCondensingUnit.WriteXmlSchema("CondensingUnitXSD.xsd");

            var dsCondensingUnitCompressors = new DataSet("CondensingUnitCompressorsDATA");
            dsCondensingUnitCompressors.Tables.Add(dtCondensingUnitCompressors.Copy());
            //dsCondensingUnitCompressors.WriteXmlSchema("CondensingUnitCompressorsXSD.xsd");

            var dsCondensingUnitWaterCooledCondensers = new DataSet("CondensingUnitWaterCooledCondensersDATA");
            dsCondensingUnitWaterCooledCondensers.Tables.Add(dtCondensingUnitWaterCooledCondensers.Copy());
            //dsCondensingUnitWaterCooledCondensers.WriteXmlSchema("CondensingUnitWaterCooledCondensersXSD.xsd");

            var dsCondensingUnitOptions = new DataSet("CondensingUnitOptionsDATA");
            dsCondensingUnitOptions.Tables.Add(dtCondensingUnitOptions.Copy());
            //dsCondensingUnitOptions.WriteXmlSchema("CondensingUnitOptionsXSD.xsd");

            //instanciate the report
            var rptSpecReport = new DLLCondensingUnit.QuickCondensingUnitSpec();

            //set datasource
            rptSpecReport.SetDataSource(dsCondensingUnit);
            rptSpecReport.Subreports["Compressor.rpt"].SetDataSource(dsCondensingUnitCompressors);
            rptSpecReport.Subreports["WaterCooledCondenser.rpt"].SetDataSource(dsCondensingUnitWaterCooledCondensers);
            rptSpecReport.Subreports["CondensingUnitOptions.rpt"].SetDataSource(dsCondensingUnitOptions);
          
            rptSpecReport.SetParameterValue("DLLVersion", Public.KFRefplus_VERSION());
            rptSpecReport.SetParameterValue("Version", Public.ApplicationVersion);
            rptSpecReport.SetParameterValue("Site", UserInformation.CurrentSite);
            rptSpecReport.SetParameterValue("CustomLogo", Reg.Get(Reg.Key.CustomLogo));
            rptSpecReport.SetParameterValue("CustomAddress", Reg.Get(Reg.Key.CustomAddress));
            rptSpecReport.SetParameterValue("QuoteID", quoteID);
            rptSpecReport.SetParameterValue("QuoteRevisionText", quoteRevisionText);

            //translate report            
            DLLCondensingUnit.CondensingUnitReportTranslation.translateReport(rptSpecReport, Public.Language);
            DLLCondensingUnit.CompressorReportTranslation.translateReport(rptSpecReport.Subreports["Compressor.rpt"], Public.Language);
            DLLCondensingUnit.WaterCooledCondenserReportTranslation.translateReport(rptSpecReport.Subreports["WaterCooledCondenser.rpt"], Public.Language);
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
