using System;
using System.Data;

namespace RefplusWebtools.QuickFluidCooler
{
    class FluidCoolerReport
    {
        public static string GenerateDataReport(DataTable dtFluidCooler, DataTable dtControlPanel, DataTable dtPump, DataTable dtSecondaryOption, bool openReport, int quoteID, string quoteRevisionText)
        {
            var dsFluidCooler = new DataSet("FluidCoolerDATA");
            dsFluidCooler.Tables.Add(dtFluidCooler.Copy());
            //dsFluidCooler.WriteXmlSchema("FluidCoolerXSD.xsd");

            var dsControlPanel = new DataSet("ControlPanelDATA");
            dsControlPanel.Tables.Add(dtControlPanel.Copy());
            //dsControlPanel.WriteXmlSchema("ControlPanelXSD.xsd");

            var dsPumpInputs = new DataSet("PumpInputsDATA");
            dsPumpInputs.Tables.Add(dtPump);
            //dsPumpInputs.WriteXmlSchema("PumpInputsXSD.xsd");

            var dsSecondaryOptions = new DataSet("SecondaryOptionsDATA");
            dsSecondaryOptions.Tables.Add(dtSecondaryOption.Copy());
            //dsSecondaryOptions.WriteXmlSchema("SecondaryOptionsXSD.xsd");

            var rptSpecReport = new DLLFluidCoolerReport.QuickFluidCoolerSpec();

            //set datasource
            rptSpecReport.SetDataSource(dsFluidCooler);
            rptSpecReport.Subreports["ControlPanelReport.rpt"].SetDataSource(dsControlPanel);
            rptSpecReport.Subreports["PumpReport.rpt"].SetDataSource(dsPumpInputs);
            rptSpecReport.Subreports["SecondaryOptions.rpt"].SetDataSource(dsSecondaryOptions);

            //pass the version
            rptSpecReport.SetParameterValue("DLLVersion", Public.KFRefplus_VERSION());
            rptSpecReport.SetParameterValue("Version", Public.ApplicationVersion);
            rptSpecReport.SetParameterValue("Site", UserInformation.CurrentSite);
            rptSpecReport.SetParameterValue("CustomLogo", Reg.Get(Reg.Key.CustomLogo));
            rptSpecReport.SetParameterValue("CustomAddress", Reg.Get(Reg.Key.CustomAddress));
            rptSpecReport.SetParameterValue("QuoteID", quoteID);
            rptSpecReport.SetParameterValue("QuoteRevisionText", quoteRevisionText);

            //translate the report
            DLLFluidCoolerReport.FluidCoolerReportTranslation.translateReport(rptSpecReport, Public.Language);
            DLLFluidCoolerReport.CPTranslation.translateReport(rptSpecReport.Subreports["ControlPanelReport.rpt"], Public.Language);
            DLLFluidCoolerReport.PumpReportTranslation.translateReport(rptSpecReport.Subreports["PumpReport.rpt"], Public.Language);
            DLLFluidCoolerReport.FCSecondaryOptionsTranslator.translateReport(rptSpecReport.Subreports["SecondaryOptions.rpt"], Public.Language);

            //export to pdf
            string strFileNamePath = Public.ExportReportToFormat(rptSpecReport, "tmpSpecReport", "PDF", openReport);

            //dispose object
            rptSpecReport.Dispose();

            //call garbage collector to clean out crystal report
            GC.Collect();

            return strFileNamePath;
        }
    }
}
