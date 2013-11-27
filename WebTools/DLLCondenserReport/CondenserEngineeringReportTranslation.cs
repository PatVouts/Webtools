
namespace DLLCondenserReport
{
    public class CondenserEngineeringReportTranslation
    {
        public static void translateReport(CondenserEngineeringReport report, string language)
        {
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection2.ReportObjects["txtCondModel"]).Text = language == "EN" ? "Condenser Model" : "Modèle de condenseur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtCondSpecs"]).Text = language == "EN" ? "Condenser Specifications" : "Spécifications condenseur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtFanArrangement"]).Text = language == "EN" ? "Fan Arrangement" : "Arrangement des ventilateurs";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtAirFlow"]).Text = language == "EN" ? "Air Flow" : "Flux d'air";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtCoilModel"]).Text = language == "EN" ? "Coil Model" : "Modèle de serpentin";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtFinHeight"]).Text = language == "EN" ? "Fin Height" : "Hauteur d'Ailettes";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtFinLength"]).Text = language == "EN" ? "Fin Length" : "Longueur d'Ailettes";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtRow"]).Text = language == "EN" ? "Row" : "Ligne";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtFPI"]).Text = "FPI";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtWeight"]).Text = language == "EN" ? "Weight" : "Poids";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtVoltage"]).Text = "Voltage";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtCircuitQuantity"]).Text = language == "EN" ? "Circuit Quantity" : "Quantité Circuit";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtCapacityPerCircuit"]).Text = language == "EN" ? "Capacity per Circuit" : "Capacité par circuit";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtTHR"]).Text = language == "EN" ? "THR at 1°F" : "THR à 1°F";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtConnections"]).Text = language == "EN" ? "Connections" : "Raccordements";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtDischarge"]).Text = language == "EN" ? "Discharge" : "Décharge";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtLiquid"]).Text = language == "EN" ? "Liquid" : "Liquide";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtQuantity"]).Text = language == "EN" ? "Quantity" : "Quantité";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtRefSummerCharge"]).Text = language == "EN" ? "Ref. Summer Charge" : "Ref. charge d'été";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtRefWinterCharge"]).Text = language == "EN" ? "Ref. Winter Charge" : "Ref. charge d'hiver";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtMotorModel"]).Text = language == "EN" ? "Motor Model" : "Modèle de moteur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtHP"]).Text = "HP";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtRPM"]).Text = "RPM";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtRotationType"]).Text = language == "EN" ? "Rotation Type" : "Type de rotation";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtFrameType"]).Text = language == "EN" ? "Frame Type" : "Type de cadre";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtShaftLength"]).Text = language == "EN" ? "Shaft Length" : "Longueur de l'arbre";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtFLA"]).Text = "FLA";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtFanModel"]).Text = language == "EN" ? "Fan Model" : "Modèle de ventilateur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtDiameter"]).Text = language == "EN" ? "Diameter" : "Diamètre";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtBladeQuantity"]).Text = language == "EN" ? "Blade Quantity" : "Quantité lame";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtOtherRotationType"]).Text = language == "EN" ? "Rotation Type" : "Type de rotation";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtComposition"]).Text = "Composition";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtPitch"]).Text = "Pitch";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtMotorMount"]).Text = language == "EN" ? "Motor Mount" : "Montage de moteur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtFanSize"]).Text = language == "EN" ? "Fan Size" : "Taille du ventilateur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtFrameSize"]).Text = language == "EN" ? "Frame Size" : "Taille du cadre";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtComposition1"]).Text = "Composition";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtFanGuardModel"]).Text = language == "EN" ? "Fan Guard Model" : "Modèle de capot de ventilateur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtSize"]).Text = language == "EN" ? "Size" : "Taille";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.ReportHeaderSection5.ReportObjects["txtComposition2"]).Text = "Composition";
        }
    }
}
