
namespace DLLCustomUnit
{
    public class CustomReportTranslation
    {
        public static void translateReport(CustomUnitSpec report, string language)
        {
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section1.ReportObjects["txtQuoteNumberTitle1"]).Text = language == "EN" ? "Quote #" : "# de soumission";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection1.ReportObjects["txtQuoteNumberTitle2"]).Text = language == "EN" ? "Quote #" : "# de soumission";
        }
    }
}
