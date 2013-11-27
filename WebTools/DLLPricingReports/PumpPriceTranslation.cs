using CrystalDecisions.CrystalReports.Engine;

namespace DLLPricingReports
{
    public class PumpPriceTranslation
    {
        public static void translateReport(ReportDocument report, string language)
        {
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtPumpTitle"]).Text = language == "EN" ? "PUMP" : "POMPE";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtPumpModel"]).Text = language == "EN" ? "Pump" : "Pompe";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtNomenclature"]).Text = "Nomenclature";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtPump"]).Text = language == "EN" ? "Pump" : "Pompe";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtOptions"]).Text = "Options";
        }
    }
}
