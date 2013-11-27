
namespace DLLFluidCoolerReport
{
    public class FluidCoolerReportTranslation
    {
        public static void translateReport(QuickFluidCoolerSpec report, string language)
        {
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section2.ReportObjects["txtQuoteNumberTitle1"]).Text = language == "EN" ? "Quote #" : "# de Soumission";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.PageHeaderSection1.ReportObjects["txtQuoteNumberTitle2"]).Text = language == "EN" ? "Quote #" : "# de soumission";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtDesignParams"]).Text = language == "EN" ? "Design Parameters" : "Param�tres de conception";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtEDB"]).Text = language == "EN" ? "Entering Dry Bulb" : "Bulbe Seche a l'Entr�e";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtELT"]).Text = language == "EN" ? "Entering Liquid Temp." : "Temp. du liquide a l'entr�e";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLLT"]).Text = language == "EN" ? "Leaving Liquid Temp." : "Temp du liquide de sortie";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtGPM"]).Text = "GPM";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtAltitude"]).Text = "Altitude";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtElecInfo"]).Text = language == "EN" ? "Electrical Info" : "Info �lectriques";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtVoltage"]).Text = "Voltage";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFanMotorHP"]).Text = language == "EN" ? "Fan Motor HP" : "Puissance du moteur de l�h�lice";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFanMotorRPM"]).Text = language == "EN" ? "Fan Motor RPM" : "Vitesse du moteur de l�h�lice";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFLA"]).Text = "FLA";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtMinAmpacity"]).Text = language == "EN" ? "Minimum Ampacity" : "Courant admissible minimum";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtMaxMainFuse"]).Text = language == "EN" ? "Maximum Main Fuse" : "Fusible principal maximum";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtPerformanceData"]).Text = language == "EN" ? "Performance Data" : "Les donn�es de performance";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtTotalHeat"]).Text = language == "EN" ? "Total Heat" : "Chaleur total";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFluidType"]).Text = language == "EN" ? "Fluid Type" : "Type de fluide";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtConcentration"]).Text = "Concentration";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtSpecificHeat"]).Text = language == "EN" ? "Specific Heat" : "Chaleur sp�cifique";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtDensity"]).Text = language == "EN" ? "Density" : "Densit�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtViscosity"]).Text = language == "EN" ? "Viscosity" : "Viscosit�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtThermConduct"]).Text = language == "EN" ? "Thermal Conductivity" : "Conductivit� thermique";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtPressureDrop"]).Text = language == "EN" ? "Pressure Drop" : "Chute de pression";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLiquidVelocity"]).Text = language == "EN" ? "Liquid Velocity" : "V�locit� du liquide";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtInVolume"]).Text = language == "EN" ? "Internal Volume" : "Volume interne";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFluidVolume"]).Text = language == "EN" ? "Fluid Volume" : "Volume de fluide";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtGeneralData"]).Text = language == "EN" ? "General Data" : "Donn�es g�n�rales";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtHeaderSize"]).Text = language == "EN" ? "Header Size" : "Taille de collecteur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFanArr"]).Text = language == "EN" ? "Fan Arrangement" : "Arrangement des h�lices";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtShipWeight"]).Text = language == "EN" ? "Ship Weight" : "Poid � la livraison";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtDimDwg"]).Text = language == "EN" ? "Dimension Dwg" : "Croquis dimension";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtAirFlow"]).Text = language == "EN" ? "Air Flow" : "D�bit d'air";


        }
    }
}
