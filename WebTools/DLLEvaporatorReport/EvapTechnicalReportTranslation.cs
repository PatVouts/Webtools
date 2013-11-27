
namespace DLLEvaporatorReport
{
    public class EvapTechnicalReportTranslation
    {
        public static void translateReport(EvapTechnical report, string language)
        {
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtDesignParams"]).Text = language == "EN" ? "Technical Information" : "Informations techniques";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtModel"]).Text = language == "EN" ? "Model" : "Modèle";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtEvapInfo"]).Text = language == "EN" ? "Evaporator Information" : "Informations évaporateur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtType"]).Text = "Type";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtStyle"]).Text = "Style";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtDefrostType"]).Text = language == "EN" ? "Defrost Type" : "Type de dégivrage";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCapacityInfo"]).Text = language == "EN" ? "Capacity Info" : "Informations évaporateur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLiquidConnSize"]).Text = language == "EN" ? "Liquid Connection Size" : "Taille de raccordement liquide";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtSuctionConnSize"]).Text = language == "EN" ? "Suction Connection Size" : "Taille de raccordement d'aspiration";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtGasConnSize"]).Text = language == "EN" ? "Hot Gas Connection Size" : "Taille de raccordement au gaz chaud";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtEvapCFM"]).Text = language == "EN" ? "Evaporator CFM" : "CFM d'évaporateur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtRefrigerant"]).Text = language == "EN" ? "Refrigerant" : "Réfrigérant";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtRefCharge"]).Text = language == "EN" ? "Refrigerant Charge" : "Charge de réfrigérant";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtShipWeight"]).Text = language == "EN" ? "Ship Weight" : "Poid à la livraison";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtSuctionTempRange"]).Text = language == "EN" ? "Suction Temperature Range" : "Température d'aspiration";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFan"]).Text = language == "EN" ? "Fan" : "Ventilateur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtQuantity"]).Text = language == "EN" ? "Quantity" : "Quantité";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtArrangement"]).Text = "Arrangement";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFanBlade"]).Text = language == "EN" ? "Fan Blade" : "La lame du ventilateur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFanName"]).Text = language == "EN" ? "Model" : "Modèle";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFanQuantity"]).Text = language == "EN" ? "Quantity" : "Quantité";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFanDiameter"]).Text = language == "EN" ? "Diameter" : "Diamètre";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtRotationType"]).Text = language == "EN" ? "Rotation Type" : "Type de rotation";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFanComposition"]).Text = "Composition";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtPitch"]).Text = "Pitch";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFanGuard"]).Text = language == "EN" ? "Fan Guard" : "Protecteur de ventilateur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFanGuardModel"]).Text = language == "EN" ? "Model" : "Modèle";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFanGuardDiameter"]).Text = language == "EN" ? "Diameter" : "Diamètre";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFanGuardComposition"]).Text = "Composition";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtMotor"]).Text = language == "EN" ? "Motor" : "Moteur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtMotorModel"]).Text = language == "EN" ? "Model" : "Modèle";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtStrength"]).Text = language == "EN" ? "Strength" : "Résistance";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtSpeed"]).Text = language == "EN" ? "Speed" : "Vitesse";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtMotorRotationType"]).Text = language == "EN" ? "Rotation Type" : "Type de rotation";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFrameType"]).Text = language == "EN" ? "Frame Type" : "Type de cadre";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtShaftLength"]).Text = language == "EN" ? "Shaft Length" : "Longueur de l'arbre";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtMotorFLA"]).Text = "FLA";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtMotorMount"]).Text = language == "EN" ? "Motor Mount" : "Montage du moteur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtMotorMountModel"]).Text = language == "EN" ? "Model" : "Modèle";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtMotorMountDiameter"]).Text = language == "EN" ? "Diameter" : "Diamètre";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFrameSize"]).Text = language == "EN" ? "Frame Size" : "Taille de cadre";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtMotorMountComposition"]).Text = "Composition";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtHeater"]).Text = language == "EN" ? "Heater" : "Chauffe";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtHeaterModel"]).Text = language == "EN" ? "Model" : "Modèle";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtHeaterQuantity"]).Text = language == "EN" ? "Quantity" : "Quantité";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtDescription"]).Text = "Description";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtKilowatts"]).Text = "Kilowatts";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtHeaterFLA"]).Text = "FLA";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCoil"]).Text = language == "EN" ? "Coil" : "Serpentin";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCoilModel"]).Text = language == "EN" ? "Model" : "Modèle";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtElecInfo"]).Text = language == "EN" ? "Electrical Information" : "Informations électriques";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtVoltage"]).Text = "Voltage";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtMCA"]).Text = "MCA";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtMOP"]).Text = "MOP";
        }
    }
}
