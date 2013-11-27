using CrystalDecisions.CrystalReports.Engine;

namespace DLLFluidCoolerReport
{
    public class CPTranslation
    {
        public static void translateReport(ReportDocument report, string language)
        {
            report.DataDefinition.FormulaFields["ControlPanelNomenclature"].Text = language == "EN" ? "\"Control Panel Information \" &  totext({ControlPanelInputs.ControlPanelNomenclature})" : "\"Information du panneau de contrôle \" &  totext({ControlPanelInputs.ControlPanelNomenclature})";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtPanel"]).Text = language == "EN" ? "Panel" : "Panneau";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtControlVoltage"]).Text = language == "EN" ? "Control Voltage" : "Voltage de Contrôle";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtOptions"]).Text = "Options";
        }
    }
}
