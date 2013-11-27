using CrystalDecisions.CrystalReports.Engine;

namespace DLLCondensingUnit
{
    public class CUEngineeringReportCompressorTranslation
    {
        public static void translateReport(ReportDocument report, string language)
        {
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtCompressorModel"]).Text = language == "EN" ? "Compressor Model" : "Mod�le de compresseur";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtManufacturer"]).Text = language == "EN" ? "Manufacturer" : "Fabricant";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtType"]).Text = "Type";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtLiquid"]).Text = language == "EN" ? "Liquid" : "Liquide";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtSuction"]).Text = "Suction";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtDischarge"]).Text = language == "EN" ? "Discharge" : "D�charge";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtLRA"]).Text = "LRA";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtRLA"]).Text = "RLA";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtReceiverModel"]).Text = language == "EN" ? "Receiver Model" : "Mod�le de r�cepteur";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtReceiverPumpDowmCapacity"]).Text = language == "EN" ? "Receiver Pump Down Capacity" : "R�cepteur de la pompe � la capacit�";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtReceiverCoilCapacityRatio"]).Text = language == "EN" ? "Receiver Coil Capacity Ratio" : "Ratio de la capacit� du r�cepteur serpentin";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtCapacity"]).Text = language == "EN" ? "Capacity" : "Capacit�";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtPower"]).Text = language == "EN" ? "Power" : "�nergie";
        }
    }
}
