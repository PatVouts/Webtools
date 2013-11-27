using System;
using System.Collections.Generic;
using System.Text;

namespace DLLFluidCoolerReport
{
    public class ControlPanelTranslation
    {
        public void translateReport(ControlPanelReport report, string language)
        {
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.PageHeaderSection1.ReportObjects["txtControlPanelInfo"]).Text = language == "EN" ? ((CrystalDecisions.CrystalReports.Engine.TextObject)report.PageHeaderSection1.ReportObjects["txtControlPanelInfo"]).Text.Replace("sControl Panel Informations", "Control Panel Information") : ((CrystalDecisions.CrystalReports.Engine.TextObject)report.PageHeaderSection1.ReportObjects["txtControlPanelInfo"]).Text.Replace("sControl Panel Informations", "Information du panneau de contrôle");
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.PageHeaderSection1.ReportObjects["txtPanel"]).Text = language == "EN" ? "Panel" : "Panneau";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.PageHeaderSection1.ReportObjects["txtControlVoltage"]).Text = language == "EN" ? "Control Voltage" : "Voltage de Contrôle";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtOptions"]).Text = "Options";
        }
    }
}
