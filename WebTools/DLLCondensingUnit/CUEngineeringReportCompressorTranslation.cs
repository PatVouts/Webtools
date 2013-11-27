using CrystalDecisions.CrystalReports.Engine;

namespace DLLCondensingUnit
{
    public class CUEngineeringReportCompressorTranslation
    {
        public static void translateReport(ReportDocument report, string language)
        {
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtCompressorModel"]).Text = language == "EN" ? "Compressor Model" : "Modèle de compresseur";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtManufacturer"]).Text = language == "EN" ? "Manufacturer" : "Fabricant";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtType"]).Text = "Type";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtLiquid"]).Text = language == "EN" ? "Liquid" : "Liquide";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtSuction"]).Text = "Suction";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtDischarge"]).Text = language == "EN" ? "Discharge" : "Décharge";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtLRA"]).Text = "LRA";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtRLA"]).Text = "RLA";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtReceiverModel"]).Text = language == "EN" ? "Receiver Model" : "Modèle de récepteur";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtReceiverPumpDowmCapacity"]).Text = language == "EN" ? "Receiver Pump Down Capacity" : "Récepteur de la pompe à la capacité";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtReceiverCoilCapacityRatio"]).Text = language == "EN" ? "Receiver Coil Capacity Ratio" : "Ratio de la capacité du récepteur serpentin";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtCapacity"]).Text = language == "EN" ? "Capacity" : "Capacité";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtPower"]).Text = language == "EN" ? "Power" : "Énergie";
        }
    }
}
