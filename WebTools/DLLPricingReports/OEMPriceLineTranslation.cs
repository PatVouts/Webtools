using CrystalDecisions.CrystalReports.Engine;

namespace DLLPricingReports
{
    public class OEMPriceLineTranslation
    {
        public static void translateReport(ReportDocument report, string language)
        {
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtRange"]).Text = language == "EN" ? "For {Input_From} to {Input_To} Coils" : "Pour {Input_From} à {Input_To} Serpentins";
        }
    }
}
