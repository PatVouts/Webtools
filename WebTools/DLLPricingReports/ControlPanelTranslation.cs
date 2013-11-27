using CrystalDecisions.CrystalReports.Engine;

namespace DLLPricingReports
{
    public class ControlPanelTranslation
    {
        public static void translateReport(ReportDocument report, string language)
        {
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtControlPanel"]).Text = language == "EN" ? "CONTROL PANEL" : "PANNEAU DE CONTRÔLE";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtNomenclature"]).Text = "Nomenclature";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtPanel"]).Text = language == "EN" ? "Panel" : "Panneau";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtOptions"]).Text = "Options";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtControlVoltage"]).Text = language == "EN" ? "Control Voltage" : "Tension de commande";
        }
    }
}
