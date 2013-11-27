using CrystalDecisions.CrystalReports.Engine;

namespace DLLCondensingUnit
{
    public class CUWaterCoolerCondenserReportTranslation
    {
        public static void translateReport(ReportDocument report, string language)
        {
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtModel"]).Text = language == "EN" ? "Model" : "Modèle";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtPumpDownCapacity"]).Text = language == "EN" ? "Pump Down Capacity" : "Pompe à la capacité";
        }
    }
}
