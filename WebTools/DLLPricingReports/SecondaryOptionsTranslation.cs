using CrystalDecisions.CrystalReports.Engine;

namespace DLLPricingReports
{
    public class SecondaryOptionsTranslation
    {
        public static void translateReport(ReportDocument report, string language)
        {
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtSecondaryOptions"]).Text = language == "EN" ? "SECONDARY OPTIONS" : "OPTIONS SECONDAIRES";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtFinMaterial"]).Text = language == "EN" ? "Fin Material" : "Mat�riaux des Ailettes";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtTubeMaterial"]).Text = language == "EN" ? "Tube Material" : "Mat�riaux des tubes";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtCoilCoating"]).Text = language == "EN" ? "Coil Coating" : "Rev�tement du Serpentin";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtCasingFinish"]).Text = language == "EN" ? "Casing Finish" : "Fini du Boitier";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtLegs"]).Text = language == "EN" ? "Legs" : "Pattes";
        }
    }
}