using System;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools.QuickCondenser
{
    class CondenserReport
    {
        public static string GenerateDataReport(DataTable dtCondenser, DataTable dtRefrigerantCircuit, DataTable dtControlPanel, DataTable dtReveiver, DataTable dtSecondaryOption, bool openReport, int quoteID, string quoteRevisionText)
        {
            string strFileNamePath = "";
            try
            {
                var dsCondenser = new DataSet("CondenserDATA");
                dsCondenser.Tables.Add(dtCondenser.Copy());
                //dsCondenser.WriteXmlSchema("CondenserXSD.xsd");

                var dsRefrigerantCircuit = new DataSet("RefrigerantCircuitDATA");
                dsRefrigerantCircuit.Tables.Add(dtRefrigerantCircuit.Copy());
                //dsRefrigerantCircuit.WriteXmlSchema("RefrigerantCircuitXSD.xsd");

                var dsControlPanel = new DataSet("ControlPanelDATA");
                dsControlPanel.Tables.Add(dtControlPanel.Copy());
                //dsControlPanel.WriteXmlSchema("ControlPanelXSD.xsd");

                var dsReceiver = new DataSet("ReceiverDATA");
                dsReceiver.Tables.Add(dtReveiver.Copy());
                //dsReceiver.WriteXmlSchema("ReceiverXSD.xsd");

                var dsSecondaryOptions = new DataSet("SecondaryOptionsDATA");
                dsSecondaryOptions.Tables.Add(dtSecondaryOption.Copy());
                //dsSecondaryOptions.WriteXmlSchema("SecondaryOptionsXSD.xsd");

                //instanciate the report
                var rptSpecReport = new DLLCondenserReport.QuickCondenserDataReport();

                //set datasource
                rptSpecReport.SetDataSource(dsCondenser);
                rptSpecReport.Subreports["ControlPanelReport.rpt"].SetDataSource(dsControlPanel);
                rptSpecReport.Subreports["ReceiverReport.rpt"].SetDataSource(dsReceiver);
                rptSpecReport.Subreports["SecondaryOptions.rpt"].SetDataSource(dsSecondaryOptions);
                rptSpecReport.Subreports["RefrigerantCircuit.rpt"].SetDataSource(dsRefrigerantCircuit);

                rptSpecReport.SetParameterValue("DLLVersion", Public.KFRefplus_VERSION());
                rptSpecReport.SetParameterValue("Version", Public.ApplicationVersion);
                rptSpecReport.SetParameterValue("Site", UserInformation.CurrentSite);
                rptSpecReport.SetParameterValue("CustomLogo", Reg.Get(Reg.Key.CustomLogo));
                rptSpecReport.SetParameterValue("CustomAddress", Reg.Get(Reg.Key.CustomAddress));
                rptSpecReport.SetParameterValue("QuoteID", quoteID);
                rptSpecReport.SetParameterValue("QuoteRevisionText", quoteRevisionText);

                //translate report            
                DLLCondenserReport.CondenserDataReportTranslation.translateReport(rptSpecReport, Public.Language);
                DLLCondenserReport.ControlPanelReportTranslation.translateReport(rptSpecReport.Subreports["ControlPanelReport.rpt"], Public.Language);
                DLLCondenserReport.ReceiverReportTranslation.translateReport(rptSpecReport.Subreports["ReceiverReport.rpt"], Public.Language);
                DLLCondenserReport.RefrigerantCircuitTranslation.translateReport(rptSpecReport.Subreports["RefrigerantCircuit.rpt"], Public.Language);
                DLLCondenserReport.SecondaryOptionsTranslator.translateReport(rptSpecReport.Subreports["SecondaryOptions.rpt"], Public.Language);

                //export to pdf
                strFileNamePath = Public.ExportReportToFormat(rptSpecReport, Public.GenerateFileNameAndPath("SpecReport", "pdf"), "PDF", openReport);

                //dispose object
                rptSpecReport.Dispose();

                //call garbage collector to clean out crystal report
                GC.Collect();

                return strFileNamePath;
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"CondenserReport GenerateDataReport");
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
                return strFileNamePath;
            }
        }
    }
}
