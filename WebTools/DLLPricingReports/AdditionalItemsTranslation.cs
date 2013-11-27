using CrystalDecisions.CrystalReports.Engine;

namespace DLLPricingReports
{
    public class AdditionalItemsTranslation
    {
        public static void translateReport(ReportDocument report, string language)
        {
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtAddItems"]).Text = language == "EN" ? "ADDITIONAL ITEMS" : "ARTICLES SUPPLÉMENTAIRES";
        }
    }
}
