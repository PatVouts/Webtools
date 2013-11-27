using CrystalDecisions.CrystalReports.Engine;

namespace DLLOEMCoil
{
    public class OEMDistributorTranslation
    {
        public static void translateReport(ReportDocument report, string language)
        {
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtDistributor"]).Text = language == "EN" ? "Distributor" : "Distributeur";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtCircuits"]).Text = "Circuits";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtLines"]).Text = language == "EN" ? "Lines" : "Chaînes";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtSpigots"]).Text = language == "EN" ? "Spigots" : "Robinets";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtBrand"]).Text = language == "EN" ? "Brand" : "Marque";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtModel"]).Text = language == "EN" ? "Model" : "Modèle";
        }
    }
}
