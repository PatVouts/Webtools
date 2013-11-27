using CrystalDecisions.CrystalReports.Engine;

namespace DLLCondenserReport
{
    public class ReceiverReportTranslation
    {
        public static void translateReport(ReportDocument report, string language)
        {
            report.DataDefinition.FormulaFields["ReceiverInstall"].Text = language == "EN" ? "\"Receiver Information - \" & totext({ReceiverInputs.ReceiverInstall})" : "\"Information du receveur - \" & totext({ReceiverInputs.ReceiverInstall})";
            //((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtReceiverInfo"]).Text = language == "EN" ? ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtReceiverInfo"]).Text.Replace("sReceiver Informations", "Receiver Information") : ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtReceiverInfo"]).Text.Replace("sReceiver Informations", "Information du receveur");
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtReceiver1"]).Text = language == "EN" ? "Receiver #1" : "Receveur #1";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtDiameter1"]).Text = language == "EN" ? "Diameter" : "Diamètre";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtLength1"]).Text = language == "EN" ? "Length" : "Longeur";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtFloodingValve1"]).Text = language == "EN" ? "Flooding Valve" : "Valves de pression de tête";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtPatchHeater1"]).Text = language == "EN" ? "Patch Heater" : "Chauffe-patch";
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtWeight1"]).Text = language == "EN" ? "Weight (lbs)" : "Poids (lbs)";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtReceiver2"]).Text = language == "EN" ? "Receiver #2" : "Receveur #2";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtDiameter2"]).Text = language == "EN" ? "Diameter" : "Diamètre";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtLength2"]).Text = language == "EN" ? "Length" : "Longeur";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtFloodingValve2"]).Text = language == "EN" ? "Flooding Valve" : "Valves de pression de tête";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtPatchHeater2"]).Text = language == "EN" ? "Patch Heater" : "Chauffe-patch";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtWeight2"]).Text = language == "EN" ? "Weight (lbs)" : "Poids (lbs)";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtTransformer1"]).Text = language == "EN" ? "Transformer #1" : "Transformateur #1";
            ((TextObject)report.ReportDefinition.Sections[4].ReportObjects["txtTransformer2"]).Text = language == "EN" ? "Transformer #2" : "Transformateur #2";
            ((TextObject)report.ReportDefinition.Sections[5].ReportObjects["txtReinforcedBase"]).Text = language == "EN" ? "Reinforced Base" : "Base renforcée";
            ((TextObject)report.ReportDefinition.Sections[5].ReportObjects["txtBaseWeight"]).Text = language == "EN" ? "Weight (lbs)" : "Poids (lbs)";
            ((TextObject)report.ReportDefinition.Sections[6].ReportObjects["txtExtraReceiverWeight"]).Text = language == "EN" ? "Total Extra Weight from Receiver(s) (lbs)" : "Total poids supplémentaire de récepteur(s) (lbs)";
        }
    }
}
