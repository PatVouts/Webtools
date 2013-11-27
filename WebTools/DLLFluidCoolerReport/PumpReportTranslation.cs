using CrystalDecisions.CrystalReports.Engine;

namespace DLLFluidCoolerReport
{
    public class PumpReportTranslation
    {
        public static void translateReport(ReportDocument report, string language)
        {
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtModel"]).Text = language == "EN" ? "Model" : "Modèle";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtHP"]).Text = "HP";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtFrame"]).Text = language == "EN" ? "Frame" : "Cadre";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtImpellar"]).Text = language == "EN" ? "Impellar" : "Impulseur";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtFLA"]).Text = "FLA";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtMinAmpacity"]).Text = language == "EN" ? "Min Ampacity" : "Courant admissible minimum";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtMaxMainFuse"]).Text = language == "EN" ? "Max Main Fuse" : "Fusible principal max";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtRPM"]).Text = "RPM";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtDrawing"]).Text = language == "EN" ? "Drawing" : "Dessin";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtTotalFTOfH2O"]).Text = language == "EN" ? "Total FT of H2O" : "Pieds H2O total";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtNumPumps"]).Text = language == "EN" ? "Number of Pumps" : "Nombre de pompes";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtExpansion"]).Text = language == "EN" ? "Expansion Tank Kit" : "Trousse réservoir d'expansion";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtExpansionModel"]).Text = language == "EN" ? "Model" : "Modèle";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtValve"]).Text = "Valve";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtValveType"]).Text = language == "EN" ? "Valve Type" : "Type de valve";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtValveCV"]).Text = "Valve CV";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtValveConn"]).Text = language == "EN" ? "Valve Connection" : "Connexion du valve";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtLineSize"]).Text = language == "EN" ? "Line Size" : "Taille de la ligne";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtPumpDrawing"]).Text = language == "EN" ? "Pump Box Drawing" : "Dessin du boite de pompe";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtPumpOptions"]).Text = language == "EN" ? "Pump Options" : "Options du pompe";

        }
    }
}
