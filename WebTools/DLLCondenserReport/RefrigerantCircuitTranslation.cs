using CrystalDecisions.CrystalReports.Engine;

namespace DLLCondenserReport
{
    public class RefrigerantCircuitTranslation
    {
        public static void translateReport(ReportDocument report, string language)
        {
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtCircuiting"]).Text = language == "EN" ? "Circuiting" : "Circuit";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtRefrigerant"]).Text = language == "EN" ? "Refrigerant" : "Réfrigérant";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtCondTemp"]).Text = language == "EN" ? "Condenser Temperature" : "Température du condenseur";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtTempDiff"]).Text = language == "EN" ? "Temperature Difference" : "Différence de température";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtTHRPerTD"]).Text = language == "EN" ? "THR per TD" : "THR par TD";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtNumCircuits"]).Text = language == "EN" ? "Quantity of circuits" : "Quantité de circuits";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtCapacity"]).Text = language == "EN" ? "Capacity" : "Capacité";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtConnDischarge"]).Text = language == "EN" ? "Connection Discharge" : "Décharge de connexion";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtConnLiquid"]).Text = language == "EN" ? "Connection Liquid" : "Liquide de connexion";

            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtHRRefrigerant"]).Text = language == "EN" ? "Refrigerant" : "Réfrigérant";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtHRCondTemp"]).Text = language == "EN" ? "Condenser Temperature" : "Température du condenseur";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtHRTempDiff"]).Text = language == "EN" ? "Temperature Difference" : "Différence de température";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtHRTHRPerTD"]).Text = language == "EN" ? "THR per TD" : "THR par TD";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtHRNumCircuits"]).Text = language == "EN" ? "Quantity of circuits" : "Quantité de circuits";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtHRCapacity"]).Text = language == "EN" ? "Reclaim Capacity" : "Capacité Réclamer";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtHRTHR"]).Text = "THR";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtHRReclaimPercent"]).Text = language == "EN" ? "Reclaim %" : "% Réclamer";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtHRConnDischarge"]).Text = language == "EN" ? "Connection Discharge" : "Décharge de connexion";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtHRConnLiquid"]).Text = language == "EN" ? "Connection Liquid" : "Liquide de connexion";
        }
    }
}
