using CrystalDecisions.CrystalReports.Engine;

namespace DLLPricingReports
{
    public class ReceiverPriceTranslation
    {
        public static void translateReport(ReportDocument report, string language)
        {
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtReceiverTitle"]).Text = language == "EN" ? "RECEIVER" : "RECEVEUR";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtReceiverInstall"]).Text = language == "EN" ? "Receiver" : "Receveur";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtReceiver1"]).Text = language == "EN" ? "Receiver #1" : "Receveur #1";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtValve1"]).Text = "Valve #1";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtPatchHeater1"]).Text = language == "EN" ? "Patch Heater #1" : "Chauffe-patch #1";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtInsulation1"]).Text = language == "EN" ? "Insulation #1" : "Isolation #1";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtReliefValve1"]).Text = language == "EN" ? "Relief Valve #1" : "Valve de sureté";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtSightGlass1"]).Text = language == "EN" ? "Sight Glass #1" : "Voyant de liquide";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtReceiver2"]).Text = language == "EN" ? "Receiver #2" : "Receveur #2";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtValve2"]).Text = "Valve #2";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtPatchHeater2"]).Text = language == "EN" ? "Patch Heater #2" : "Chauffe-patch #2";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtInsulation2"]).Text = language == "EN" ? "Insulation #2" : "Isolation #2";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtReliefValve2"]).Text = language == "EN" ? "Relief Valve #2" : "Valve de sureté";
            ((TextObject)report.ReportDefinition.Sections[4].ReportObjects["txtSightGlass2"]).Text = language == "EN" ? "Sight Glass #2" : "Voyant de liquide";
            ((TextObject)report.ReportDefinition.Sections[5].ReportObjects["txtTransformer1"]).Text = language == "EN" ? "Transformer #1" : "Transformateur #1";
            ((TextObject)report.ReportDefinition.Sections[6].ReportObjects["txtTransformer2"]).Text = language == "EN" ? "Transformer #2" : "Transformateur #2";
            ((TextObject)report.ReportDefinition.Sections[7].ReportObjects["txtReinforcedBase"]).Text = language == "EN" ? "Re-Inforced Base" : "Base renforcée";
            ((TextObject)report.ReportDefinition.Sections[8].ReportObjects["txtReceiver"]).Text = language == "EN" ? "Receiver" : "Receveur";
        }
    }
}
