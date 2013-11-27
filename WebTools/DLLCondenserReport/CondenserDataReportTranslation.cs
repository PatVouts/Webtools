
namespace DLLCondenserReport
{
    public class CondenserDataReportTranslation
    {
        public static void translateReport(QuickCondenserDataReport report, string language)
        {
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section1.ReportObjects["txtQuoteNumberTitle1"]).Text = language == "EN" ? "Quote #" : "# de soumission";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection1.ReportObjects["txtQuoteNumberTitle2"]).Text = language == "EN" ? "Quote #" : "# de soumission";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection2.ReportObjects["txtCondModel"]).Text = language == "EN" ? "Condenser Model" : "Mod�le du Condenseur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtCondInfo"]).Text = language == "EN" ? "Condenser Information" : "Information du Condenseur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtTag"]).Text = language == "EN" ? "Tag" : "�tiquette";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtSystem"]).Text = language == "EN" ? "System" : "Syst�me";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtCondSpecs"]).Text = language == "EN" ? "Condenser Specifications" : "Sp�cifications du Condenseur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtFinalAmbientTemp"]).Text = language == "EN" ? "Adjusted Ambient Temp." : "Temp. ambiant ajust�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtAltitude"]).Text = "Altitude";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtVoltage"]).Text = "Voltage";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtFanArr"]).Text = language == "EN" ? "Fan Arrangement" : "Arrangement des ventilateurs";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtNumCircuits"]).Text = language == "EN" ? "Quantity of circuits" : "Quantit� de circuits";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtMotorHP"]).Text = language == "EN" ? "Motor HP" : "HP du moteur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtMotorFLA"]).Text = language == "EN" ? "Motor FLA" : "FLA du moteur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtMotorRPM"]).Text = language == "EN" ? "Motor RPM" : "RPM du moteur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtMCA"]).Text = "MCA";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtMOP"]).Text = "MOP";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtTHR"]).Text = language == "EN" ? "THR at 1 �F" : "THR � 1 �F";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtAdjCapacity"]).Text = language == "EN" ? "Adjusted Capacity" : "Capacit� ajust�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtCapCircuit"]).Text = language == "EN" ? "Capacity / Circuit" : "Capacit� / Circuit";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtAirFlow"]).Text = language == "EN" ? "Air Flow" : "D�bit d'air";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtSummerCharge"]).Text = language == "EN" ? "Summer Charge" : "Charge d'�t�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtWinterCharge"]).Text = language == "EN" ? "Winter Charge" : "Charge d'hiver";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtShipWeight"]).Text = language == "EN" ? "Ship Weight" : "Poids d'�quipe";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtDimDwg"]).Text = language == "EN" ? "Dimension Dwg" : "Croquis dimension";
            

        }
    }
}
