using System;
using System.Data;

namespace RefplusWebtools.OEMCoil
{
    class OEMReport
    {
        public static string GenerateDataReport(DataTable dtOEMCoil, DataTable dtOEMCoilConnections, DataTable dtOEMCoilFlareFittings, DataTable dtOEMCoilDistributors, DataTable dtOEMCoilPrice, bool openReport, bool internalVersion)
        {
            var dsOEMCoil = new DataSet("OEMCoilDATA");
            dsOEMCoil.Tables.Add(dtOEMCoil.Copy());
            //dsOEMCoil.WriteXmlSchema("OEMCoilXSD.xsd");

            var dsOEMCoilConnections = new DataSet("OEMCoilConnectionsDATA");
            dsOEMCoilConnections.Tables.Add(dtOEMCoilConnections.Copy());
            //dsOEMCoilConnections.WriteXmlSchema("OEMCoilConnectionsXSD.xsd");

            var dsOEMCoilFlareFittings = new DataSet("OEMCoilFlareFittingsDATA");
            dsOEMCoilFlareFittings.Tables.Add(dtOEMCoilFlareFittings.Copy());
            //dsOEMCoilFlareFittings.WriteXmlSchema("OEMCoilFlareFittingsXSD.xsd");

            var dsOEMCoilDistributors = new DataSet("OEMCoilDistributorsDATA");
            dsOEMCoilDistributors.Tables.Add(dtOEMCoilDistributors.Copy());
            //dsOEMCoilDistributors.WriteXmlSchema("OEMCoilDistributorsXSD.xsd");

            var dsOEMCoilPrice = new DataSet("OEMCoilPriceDATA");
            dsOEMCoilPrice.Tables.Add(dtOEMCoilPrice.Copy());
            //dsOEMCoilPrice.WriteXmlSchema("OEMCoilPriceXSD.xsd");

            //instanciate the report
            var rptSpecReport = new DLLOEMCoil.OEMSpec();

            //set datasource
            rptSpecReport.SetDataSource(dsOEMCoil);
            rptSpecReport.Subreports["OEMConnections.rpt"].SetDataSource(dsOEMCoilConnections);
            rptSpecReport.Subreports["OEMFlare.rpt"].SetDataSource(dsOEMCoilFlareFittings);
            rptSpecReport.Subreports["OEMDistributor.rpt"].SetDataSource(dsOEMCoilDistributors);
           

            rptSpecReport.SetParameterValue("DLLVersion", Public.KFRefplus_VERSION());
            rptSpecReport.SetParameterValue("Version", Public.ApplicationVersion);
            rptSpecReport.SetParameterValue("Site", UserInformation.CurrentSite);
            rptSpecReport.SetParameterValue("CustomLogo", Reg.Get(Reg.Key.CustomLogo));
            rptSpecReport.SetParameterValue("CustomAddress", Reg.Get(Reg.Key.CustomAddress));

            rptSpecReport.SetParameterValue("Internal", internalVersion);

            //translate report
            DLLOEMCoil.OEMReportTranslation.translateReport(rptSpecReport, Public.Language);
            DLLOEMCoil.OEMConnectionsTranslation.translateReport(rptSpecReport.Subreports["OEMConnections.rpt"], Public.Language);
            DLLOEMCoil.OEMFlareTranslation.translateReport(rptSpecReport.Subreports["OEMFlare.rpt"], Public.Language);
            DLLOEMCoil.OEMDistributorTranslation.translateReport(rptSpecReport.Subreports["OEMDistributor.rpt"], Public.Language);
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
