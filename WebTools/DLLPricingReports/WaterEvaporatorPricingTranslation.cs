
namespace DLLPricingReports
{
    public class WaterEvaporatorPricingTranslation
    {
        public static void translateReport(WaterEvaporatorPricing report, string language)
        {
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection2.ReportObjects["txtQuotation"]).Text = language == "EN" ? "Quotation" : "Soumission";
            //((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section1.ReportObjects["txtProjectName"]).Text = language == "EN" ? ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section1.ReportObjects["txtProjectName"]).Text.Replace("sProject Name", "Project Name") : ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section1.ReportObjects["txtProjectName"]).Text.Replace("sProject Name", "Nom du projet");
            report.DataDefinition.FormulaFields["ProjectName"].Text = language == "EN" ? "\"Project Name : \" & totext({?ProjectName})" : "\"Nom du projet : \" & totext({?ProjectName})";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection2.ReportObjects["txtQuotationDate"]).Text = language == "EN" ? "Quotation Date :" : "Date de soumission :";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection2.ReportObjects["txtQuotationBy"]).Text = language == "EN" ? "Quotation By :" : "Soumission par :";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection2.ReportObjects["txtTerms"]).Text = language == "EN" ? "Terms :" : "Termes :";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection2.ReportObjects["txtDelivery"]).Text = language == "EN" ? "Delivery :" : "Livraison :";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection2.ReportObjects["txtTo"]).Text = language == "EN" ? "To :" : "À :";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section2.ReportObjects["txtTag"]).Text = language == "EN" ? "TAG" : "ÉTIQUETTE";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section2.ReportObjects["txtDescription"]).Text = "DESCRIPTION";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section2.ReportObjects["txtQuantity"]).Text = language == "EN" ? "QTY" : "QTÉ";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section2.ReportObjects["txtUnitPrice"]).Text = language == "EN" ? "UNIT PRICE" : "PRIX UNITAIRE";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section2.ReportObjects["txtTotalPrice"]).Text = language == "EN" ? "TOTAL PRICE" : "PRIX TOTAL";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtMainVoltage"]).Text = language == "EN" ? "Main Voltage" : "Tension principale";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCoilCoating"]).Text = language == "EN" ? "Coil Coating" : "Revêtement du Serpentin";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFinMaterial"]).Text = language == "EN" ? "Fin Material" : "Matériaux des Ailettes";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFPI"]).Text = language == "EN" ? "Fins Per Inch" : "Ailettes par pouce";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section5.ReportObjects["txtAddNote1"]).Text = language == "EN" ? "This quote is valid for 30 days." : "Cette soumission est valable pour 30 jours.";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section5.ReportObjects["txtAddNote2"]).Text = language == "EN" ? "Prices are net. All applicable taxes extra" : "Les prix sont nets. Taxes en sus";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section5.ReportObjects["txtAddNote3"]).Text = language == "EN" ? "F.O.B plant in St-Hubert, Quebec, Canada" : "usine F.O.B à St-Hubert, Québec, Canada";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section5.ReportObjects["txtAddNote4"]).Text = language == "EN" ? "Freight Extra." : "De transport supplémentaires.";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section5.ReportObjects["txtAddNote5"]).Text = language == "EN" ? "if you did not receive all pages. please call 450-641-2665" : "Si vous n'avez pas reçu toutes les pages. S'il vous plaît appelez 450-641-2665";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section5.ReportObjects["txtTotal"]).Text = "Total";
        }
    }
}
