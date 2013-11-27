using CrystalDecisions.CrystalReports.Engine;

namespace DLLCondenserReport
{
    public class RefrigerantCircuitTranslation
    {
        public static void translateReport(ReportDocument report, string language)
        {
            ((TextObject)report.ReportDefinition.Sections[1].ReportObjects["txtCircuiting"]).Text = language == "EN" ? "Circuiting" : "Circuit";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtRefrigerant"]).Text = language == "EN" ? "Refrigerant" : "R�frig�rant";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtCondTemp"]).Text = language == "EN" ? "Condenser Temperature" : "Temp�rature du condenseur";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtTempDiff"]).Text = language == "EN" ? "Temperature Difference" : "Diff�rence de temp�rature";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtTHRPerTD"]).Text = language == "EN" ? "THR per TD" : "THR par TD";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtNumCircuits"]).Text = language == "EN" ? "Quantity of circuits" : "Quantit� de circuits";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtCapacity"]).Text = language == "EN" ? "Capacity" : "Capacit�";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtConnDischarge"]).Text = language == "EN" ? "Connection Discharge" : "D�charge de connexion";
            ((TextObject)report.ReportDefinition.Sections[2].ReportObjects["txtConnLiquid"]).Text = language == "EN" ? "Connection Liquid" : "Liquide de connexion";

            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtHRRefrigerant"]).Text = language == "EN" ? "Refrigerant" : "R�frig�rant";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtHRCondTemp"]).Text = language == "EN" ? "Condenser Temperature" : "Temp�rature du condenseur";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtHRTempDiff"]).Text = language == "EN" ? "Temperature Difference" : "Diff�rence de temp�rature";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtHRTHRPerTD"]).Text = language == "EN" ? "THR per TD" : "THR par TD";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtHRNumCircuits"]).Text = language == "EN" ? "Quantity of circuits" : "Quantit� de circuits";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtHRCapacity"]).Text = language == "EN" ? "Reclaim Capacity" : "Capacit� R�clamer";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtHRTHR"]).Text = "THR";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtHRReclaimPercent"]).Text = language == "EN" ? "Reclaim %" : "% R�clamer";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtHRConnDischarge"]).Text = language == "EN" ? "Connection Discharge" : "D�charge de connexion";
            ((TextObject)report.ReportDefinition.Sections[3].ReportObjects["txtHRConnLiquid"]).Text = language == "EN" ? "Connection Liquid" : "Liquide de connexion";
        }
    }
}
