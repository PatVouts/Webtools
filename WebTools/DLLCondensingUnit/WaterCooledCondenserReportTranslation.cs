using CrystalDecisions.CrystalReports.Engine;

namespace DLLCondensingUnit
{
    public class WaterCooledCondenserReportTranslation
    {
        public static void translateReport(ReportDocument report, string language)
        {
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtWaterCooledCondenser"]).Text = language == "EN" ? "Water Cooled Condenser" : "Condenseur à eau";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtWaterCooledCondenserNum"]).Text = language == "EN" ? "Water Cooled Condenser #" : "# du condenseur à eau";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["Text2"]).Text = language == "EN" ? "Model" : "Modèle";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["Text3"]).Text = language == "EN" ? "Pump Down Capacity" : "Capacité de pompe bas";
        }
    }
}
