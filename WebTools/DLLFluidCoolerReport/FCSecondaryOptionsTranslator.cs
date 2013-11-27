using CrystalDecisions.CrystalReports.Engine;

namespace DLLFluidCoolerReport
{
    public class FCSecondaryOptionsTranslator
    {
        public static void translateReport(ReportDocument report, string language)
        {
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtOptions"]).Text = language == "EN" ? "Construction Options" : "Options de construction";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtFinMaterial"]).Text = language == "EN" ? "Fin Material" : "Matériaux des Ailettes";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtTubeMaterial"]).Text = language == "EN" ? "Tube Material" : "Matériaux des tubes";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtCoilCoating"]).Text = language == "EN" ? "Coil Coating" : "Revêtement du Serpentin";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtCasingFinish"]).Text = language == "EN" ? "Casing Finish" : "Fini du Boitier";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["Text1"]).Text = language == "EN" ? "Legs" : "Pattes";
        }
    }
}
