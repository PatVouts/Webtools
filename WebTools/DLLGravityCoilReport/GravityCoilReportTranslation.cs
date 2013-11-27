
namespace DLLGravityCoilReport
{
    public class GravityCoilReportTranslation
    {
        public static void translateReport(QuickGravityCoilSpec report, string language)
        {
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section2.ReportObjects["txtQuoteNumberTitle1"]).Text = language == "EN" ? "Quote #" : "# de soumission";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.PageHeaderSection1.ReportObjects["txtQuoteNumberTitle2"]).Text = language == "EN" ? "Quote #" : "# de soumission";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtTag"]).Text = language == "EN" ? "Tag" : "Étiquette";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtDesignParams"]).Text = language == "EN" ? "Input Parameters" : "Paramètres d'entrée";
            //((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFaceTubes"]).Text = language == "EN" ? "Face Tubes" : "Tubes Facial";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtRefrigerant"]).Text = language == "EN" ? "Refrigerant" : "Réfrigérant";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtSST"]).Text = "SST";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtTD"]).Text = "TD";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtRoomTemperature"]).Text = language == "EN" ? "Room Temperature" : "Température ambiante";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCapacityInput"]).Text = language == "EN" ? "Capacity Requested" : "Capacité requise";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtPerformanceData"]).Text = language == "EN" ? "Performance Data" : "Les données de performance";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCapacity"]).Text = language == "EN" ? "Capacity" : "Capacité";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtRefCharge"]).Text = language == "EN" ? "Refrigerant Charge" : "Charge de réfrigérant";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtGeneralData"]).Text = language == "EN" ? "General Data" : "Données générales";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtShipWeight"]).Text = language == "EN" ? "Shipping Weight" : "Poid à la livraison";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFPI"]).Text = "FPI";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCoilCoating"]).Text = language == "EN" ? "Coil Coating" : "Revêtement du Serpentin";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtSlab"]).Text = language == "EN" ? "Slab" : "Dalle";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFinPattern"]).Text = language == "EN" ? "Fin Pattern" : "Modèle d'ailettes";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFinLength"]).Text = language == "EN" ? "Fin Length" : "Longueur d'ailettes";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtDepth"]).Text = language == "EN" ? "Depth" : "Épaisseur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtHeight"]).Text = language == "EN" ? "Height" : "Hauteur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtWidth"]).Text = language == "EN" ? "Width" : "Largeur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCoilFaceTubes"]).Text = language == "EN" ? "Face Tubes" : "Tubes Facial";

            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtDimDwg"]).Text = language == "EN" ? "Dimension Dwg" : "Croquis dimension";
        }
    }
}
