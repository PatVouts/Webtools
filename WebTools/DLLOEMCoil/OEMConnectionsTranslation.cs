using CrystalDecisions.CrystalReports.Engine;

namespace DLLOEMCoil
{
    public class OEMConnectionsTranslation
    {
        public static void translateReport(ReportDocument report, string language)
        {
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtPerformanceData"]).Text = language == "EN" ? "Header Information" : "Information de collecteur";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtDiameter"]).Text = language == "EN" ? "Diameter" : "Diamètre";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtLength"]).Text = language == "EN" ? "Length" : "Longueur";
        }
    }
}
