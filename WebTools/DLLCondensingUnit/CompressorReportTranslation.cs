using CrystalDecisions.CrystalReports.Engine;

namespace DLLCondensingUnit
{
    public class CompressorReportTranslation
    {
        public static void translateReport(ReportDocument report, string language)
        {
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtCompressorNum"]).Text = language == "EN" ? "Refrigerant Cir #" : "# du circuit de refrig�rant";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtCompressorModel"]).Text = language == "EN" ? "Model" : "Mod�le";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtRLA"]).Text = "RLA";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtLRA"]).Text = "LRA";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtReceiverModel"]).Text = language == "EN" ? "Receiver Model" : "Mod�le de r�servoir";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtReceiverCharge"]).Text = language == "EN" ? "Receiver Charge" : "Charge de r�servoir";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtLiquidConnection"]).Text = language == "EN" ? "Liquid Connection" : "Raccordement de liquide";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtSuctionConnection"]).Text = language == "EN" ? "Suction Connection" : "Raccordement d'aspiration";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtDischargeConnection"]).Text = language == "EN" ? "Discharge Connection" : "Raccordement de D�charge";
        }
    }
}
