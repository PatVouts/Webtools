using CrystalDecisions.CrystalReports.Engine;

namespace DLLOEMCoil
{
    public class OEMFlareTranslation
    {
        public static void translateReport(ReportDocument report, string language)
        {
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtFlareFittings"]).Text = language == "EN" ? "Flare Fittings" : "Raccords pour tube évasé";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtQty"]).Text = language == "EN" ? "QTY" : "QTÉ";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtFlare"]).Text = language == "EN" ? "Flare" : "Tube Évasé";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtModel"]).Text = language == "EN" ? "Model" : "Modèle";
        }
    }
}
