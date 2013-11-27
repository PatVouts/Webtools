
namespace DLLOEMCoil
{
    public class OEMReportTranslation
    {
        public static void translateReport(OEMSpec report, string language)
        {
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtPerformanceData"]).Text = language == "EN" ? "Coil Materials & Weight" : "Mat�riaux de la serpentin et le poids";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtMaterial"]).Text = language == "EN" ? "Material" : "Mat�riel";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtThickness"]).Text = language == "EN" ? "Thickness" : "�paisseur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCustomerDrawingNo"]).Text = language == "EN" ? "Customer Drawing #" : "# de dessin du client";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtRefplusDrawingNo"]).Text = language == "EN" ? "RefPlus Drawing #" : "# de dessin de RefPlus";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFin"]).Text = language == "EN" ? "Fin" : "Ailette";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtTube"]).Text = "Tube";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCasing"]).Text = language == "EN" ? "Casing" : "Boitier";

            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection12.ReportObjects["txtQuantity"]).Text = language == "EN" ? "Quantity" : "Quantit�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection12.ReportObjects["txtHeight"]).Text = language == "EN" ? "Height" : "Hauteur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection12.ReportObjects["txtWidth"]).Text = language == "EN" ? "Width" : "Largeur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection12.ReportObjects["txtReturnBends"]).Text = language == "EN" ? "Return Bends" : "Coudes de retour";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection12.ReportObjects["txtEndPlates"]).Text = language == "EN" ? "End Plates" : "Plaques d'extr�mit�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection12.ReportObjects["txtTopPlate"]).Text = language == "EN" ? "Top Plate" : "Plaque sup�rieure";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection12.ReportObjects["txtBottomPlate"]).Text = language == "EN" ? "Bottom Plate" : "Plaque de fond";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection12.ReportObjects["txtCenterPlate"]).Text = language == "EN" ? "Center Plate" : "Plaque centre";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection12.ReportObjects["txtWeldedCasing"]).Text = language == "EN" ? "Welded Casing" : "Bo�tier soud�s";

            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection8.ReportObjects["txtThreadedConnection"]).Text = language == "EN" ? "Threaded Connection" : "Raccordement filet�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection8.ReportObjects["txtThreadedQty"]).Text = language == "EN" ? "QTY" : "QT�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection8.ReportObjects["txtVents"]).Text = language == "EN" ? "Vents" : "�vents";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection8.ReportObjects["txtVentsQty"]).Text = language == "EN" ? "QTY" : "QT�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection8.ReportObjects["txtSpigots"]).Text = language == "EN" ? "Spigots" : "Robinets";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection8.ReportObjects["txtSpigotsQty"]).Text = language == "EN" ? "QTY" : "QT�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection9.ReportObjects["txtSpigots"]).Text = language == "EN" ? "Spigots" : "Robinets";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection9.ReportObjects["txtSpigotQuantity2"]).Text = language == "EN" ? "QTY" : "QT�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection3.ReportObjects["txtAuxSideConnectors"]).Text = language == "EN" ? "Aux. Side Connectors" : "Connecteurs c�t� aux.";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection3.ReportObjects["txtAuxSideConnectorsQty"]).Text = language == "EN" ? "QTY" : "QT�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtWeldNuts"]).Text = language == "EN" ? "Weld Nuts" : "�crous � souder";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtWeldNutsQty"]).Text = language == "EN" ? "QTY" : "QT�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection5.ReportObjects["txtDrainPan"]).Text = language == "EN" ? "Drain Pan" : "�gouttoir";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection5.ReportObjects["txtDrainPanQty"]).Text = language == "EN" ? "QTY" : "QT�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection5.ReportObjects["txtDrainPanMaterial"]).Text = language == "EN" ? "Material" : "Mat�riel";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection7.ReportObjects["txtDamperQty"]).Text = language == "EN" ? "QTY" : "QT�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection7.ReportObjects["txtDamper"]).Text = language == "EN" ? "Damper" : "Amortisseur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection6.ReportObjects["txtSpecialCustomFittings"]).Text = language == "EN" ? "Special Custom Fittings" : "Raccords sp�cial personnalis�";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection10.ReportObjects["txtEstimatedCoilWeight"]).Text = language == "EN" ? "Estimated Coil Weight" : "Estimation de poids de serpentin";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection10.ReportObjects["txtAdditionalInfo"]).Text = language == "EN" ? "Additional Information" : "Information additionnelle";
        }
    }
}
