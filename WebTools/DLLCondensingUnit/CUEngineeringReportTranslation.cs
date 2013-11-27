
namespace DLLCondensingUnit
{
    public class CUEngineeringReportTranslation
    {
        public static void translateReport(CUEngineeringReport report, string language)
        {
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtUnitType"]).Text = language == "EN" ? "Unit Type" : "Type d'unité";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCompressorType"]).Text = language == "EN" ? "Compressor Type" : "Type de compresseur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCompressorManufacturer"]).Text = language == "EN" ? "Compressor Manufacturer" : "Fabricant de compresseurs";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtApplication"]).Text = "Application";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtRefrigerant"]).Text = language == "EN" ? "Refrigerant" : "Réfrigérant";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtVoltage"]).Text = "Voltage";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtHP"]).Text = "HP";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtOptions"]).Text = "Options (0 = none)";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtNumCompressors"]).Text = language == "EN" ? "# of Compressors" : "# de Compresseurs";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtMinTemp"]).Text = language == "EN" ? "Minimum Temp." : "Temp. minimum";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtMaxTemp"]).Text = language == "EN" ? "Maximum Temp." : "Temp. maximum";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtMinSST"]).Text = language == "EN" ? "Minimum SST" : "SST minimum";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtMaxSST"]).Text = language == "EN" ? "Maximum SST" : "SST maximum";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtRefrigerantMinCondensing"]).Text = language == "EN" ? "Refrigerant Min Condensing" : "Condensation min de réfrigérant";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtRefrigerantMaxCondensing"]).Text = language == "EN" ? "Refrigerant Max Condensing" : "Condensation max de réfrigérant";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtRefCapacityFactor"]).Text = language == "EN" ? "Refrigerant Receiver Capacity Factor" : "Facteur de capacité de réfrigération récepteur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtBalancingType"]).Text = language == "EN" ? "Balancing Type" : "Type d'équilibrage";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCoilPresent"]).Text = language == "EN" ? "Coil Present" : "Serpentin présente";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtPrice"]).Text = language == "EN" ? "Price" : "Prix";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtWeight"]).Text = language == "EN" ? "Weight" : "Poids";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCoilModel"]).Text = language == "EN" ? "Coil Model" : "Modèle de serpentin";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCFM"]).Text = "CFM";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCoilType"]).Text = language == "EN" ? "Coil Type" : "Type de serpentin";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFinType"]).Text = language == "EN" ? "Fin Type" : "Type d'ailettes";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFinShape"]).Text = language == "EN" ? "Fin Shape" : "Forme d'ailettes";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtTubes"]).Text = "Tubes";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtRow"]).Text = language == "EN" ? "Row" : "Ligne";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFPI"]).Text = "FPI";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCircuit"]).Text = "Circuit";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFinHeight"]).Text = language == "EN" ? "Fin Height" : "Hauteur d'ailettes";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFinLength"]).Text = language == "EN" ? "Fin Length" : "Longueur d'ailettes";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFinMaterial"]).Text = language == "EN" ? "Fin Material" : "Matériel d'ailettes";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFinThickness"]).Text = language == "EN" ? "Fin Thickness" : "Épaisseur d'ailette";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtTubeMaterial"]).Text = language == "EN" ? "Tube Material" : "Matériaux des tubes";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtTubeThickness"]).Text = language == "EN" ? "Tube Thickness" : "Épaisseur du tube";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFanWide"]).Text = language == "EN" ? "Fan Wide" : "Ventilateur de large";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFanLong"]).Text = language == "EN" ? "Fan Long" : "Ventilateur de long";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtMotorModel"]).Text = language == "EN" ? "Motor Model" : "Modèle de moteur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtHP1"]).Text = "HP";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtRPM"]).Text = "RPM";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtRotationType"]).Text = language == "EN" ? "Rotation Type" : "Type de rotation";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtFrameType"]).Text = language == "EN" ? "Frame Type" : "Type de cadre";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtShaftLength"]).Text = language == "EN" ? "Shaft Length" : "Longueur de l'arbre";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtFLA"]).Text = "FLA";
            /*            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtDiameter"]).Text = language == "EN" ? "Diameter" : "Diamètre";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtBladeQuantity"]).Text = language == "EN" ? "Blade Quantity" : "Quantité lame";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtRotationType1"]).Text = language == "EN" ? "Rotation Type" : "Type de rotation";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtComposition"]).Text = "Composition";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtPitch"]).Text = "Pitch";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtMotorMount"]).Text = language == "EN" ? "Motor Mount" : "Montage de moteur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtFanSize"]).Text = language == "EN" ? "Fan Size" : "Taille du ventilateur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtFrameSize"]).Text = language == "EN" ? "Frame Size" : "Taille du cadre";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtComposition1"]).Text = "Composition";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtFanGuardModel"]).Text = language == "EN" ? "Fan Guard Model" : "Modèle de capot de ventilateur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtSize"]).Text = language == "EN" ? "Size" : "Taille";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.DetailSection4.ReportObjects["txtComposition2"]).Text = "Composition";*/
        }
    }
}
