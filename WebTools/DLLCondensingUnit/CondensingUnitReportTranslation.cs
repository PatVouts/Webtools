
namespace DLLCondensingUnit
{
    public class CondensingUnitReportTranslation
    {
        public static void translateReport(QuickCondensingUnitSpec report, string language)
        {
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section2.ReportObjects["txtQuoteNumberTitle1"]).Text = language == "EN" ? "Quote #" : "# de soumission";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.PageHeaderSection1.ReportObjects["txtQuoteNumberTitle2"]).Text = language == "EN" ? "Quote #" : "# de soumission";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtPerformanceData"]).Text = language == "EN" ? "Performance Data" : "Les donn�es de performance";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtAmbientTemperature"]).Text = language == "EN" ? "Ambient Temperature" : "Temp�rature ambiante";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCondensingTemperature"]).Text = language == "EN" ? "Condensing Temperature" : "Temp�rature de condensation";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtSST"]).Text = language == "EN" ? "Saturated Suction Temp." : "Temp�rature d'aspiration satur�e";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtRefrigerantType"]).Text = language == "EN" ? "Refrigerant Type" : "Type de r�frig�rant";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtDimDwg"]).Text = language == "EN" ? "Dimension Dwg" : "Croquis dimension";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCapacity"]).Text = language == "EN" ? "Capacity" : "Capacit�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtWeight"]).Text = language == "EN" ? "Weight" : "Poids";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtTotalSummerCharge"]).Text = language == "EN" ? "Total Summer Charge" : "Charge totale de l'�t�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtTotalWinterCharge"]).Text = language == "EN" ? "Total Winter Charge" : "Charge totale de l'hiver";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtFanArrangement"]).Text = language == "EN" ? "Fan Arrangement" : "Arrangement des ventilateurs";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtFanMotorHP"]).Text = language == "EN" ? "Fan Motor HP" : "Moteur HP des ventilateurs";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtFanMotorFLA"]).Text = language == "EN" ? "Fan Motor FLA" : "Moteur FLA des ventilateurs";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtFinMaterial"]).Text = language == "EN" ? "Fin Material" : "Mat�riaux des Ailettes";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtCoating"]).Text = language == "EN" ? "Coating" : "Rev�tement";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtTubeMaterial"]).Text = language == "EN" ? "Tube Material" : "Mat�riaux des tubes";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection7.ReportObjects["txtElectricalData"]).Text = language == "EN" ? "Electrical Data" : "Caract�ristiques �lectriques";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection7.ReportObjects["txtVoltage"]).Text = language == "EN" ? "Electrical Data" : "Caract�ristiques �lectriques";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection7.ReportObjects["txtVoltage"]).Text = "Voltage";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection7.ReportObjects["txtUnitMCA"]).Text = language == "EN" ? "Unit MCA" : "MCA de l'unit�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection7.ReportObjects["txtUnitMOP"]).Text = language == "EN" ? "Unit MOP" : "MOP de l'unit�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection7.ReportObjects["txtUnitFUSE"]).Text = language == "EN" ? "Unit FUSE" : "FUSE de l'unit�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection7.ReportObjects["txtCompressorData"]).Text = language == "EN" ? "Compressor Data" : "Les donn�es de compresseur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection7.ReportObjects["txtManufacturer"]).Text = language == "EN" ? "Manufacturer" : "Fabricant";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection7.ReportObjects["txtTotalHP"]).Text = language == "EN" ? "Total HP" : "HP totale";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection7.ReportObjects["txtType"]).Text = "Type";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection7.ReportObjects["txtCompressorAmount"]).Text = language == "EN" ? "Compressor System" : "Syst�mes de Compresseurs";
        }
    }
}
