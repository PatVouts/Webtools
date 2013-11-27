
namespace DLLWaterEvaporatorReport
{
    public class WaterEvapSpecTranslationReport
    {
        public static void translateReport(QuickWaterEvapSpec report, string language)
        {
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section2.ReportObjects["txtQuoteNumberTitle1"]).Text = language == "EN" ? "Quote #" : "# de soumission";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.PageHeaderSection1.ReportObjects["txtQuoteNumberTitle2"]).Text = language == "EN" ? "Quote #" : "# de soumission";
           ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtElectricalData"]).Text = language == "EN" ? "Electrical Data" : "Les données électriques";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtVoltage"]).Text = "Voltage";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtMotorFLA"]).Text = language == "EN" ? "Motor FLA" : "FLA du moteur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtMCA"]).Text = language == "EN" ? "Motor MCA" : "MCA du moteur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFuse"]).Text = language == "EN" ? "Motor Fuse" : "Fusible du moteur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtHeaterFLA"]).Text = language == "EN" ? "Heater FLA" : "FLA de chauffage";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtHeaterMCA"]).Text = language == "EN" ? "Heater MCA" : "MCA de chauffage";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtHeaterFuse"]).Text = language == "EN" ? "Heater Fuse" : "Fusible de chauffage";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtMotorData"]).Text = language == "EN" ? "Motor Data" : "Les données de moteur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtMotorHP"]).Text = language == "EN" ? "Motor HP" : "HP du moteur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtMotorRPM"]).Text = language == "EN" ? "Motor RPM" : "RPM du moteur";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtHeaterData"]).Text = language == "EN" ? "Heater Data" : "Les données de chauffage";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtHeaterKW"]).Text = language == "EN" ? "Heater Kilowatts" : "Kilowatts de chauffage";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtPerformanceData"]).Text = language == "EN" ? "Performance Data" : "Les données de performance";

            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtPerCoil"]).Text = language == "EN" ? "Per Coil" : "Par Serpentin";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtPerEvap"]).Text = language == "EN" ? "Per Evap" : "Par Évap";
            //((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCFM"]).Text = language == "EN" ? "CFM" : "PCM";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtEDB"]).Text = language == "EN" ? "EDB (°F)" : "BSE (°F)";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtEWB"]).Text = language == "EN" ? "EWB (°F)" : "BHE (°F)";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtAltitude"]).Text = "Altitude (FT)";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFluidType"]).Text = language == "EN" ? "Fluid Type" : "Type de Liquide";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtConcentration"]).Text = "Concentration (%)";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtELT"]).Text = language == "EN" ? "ELT (°F)" : "TLE (°F)";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLLT"]).Text = language == "EN" ? "LLT (°F)" : "TLS (°F)";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtGPM"]).Text = "GPM";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCircuits"]).Text = "Circuits";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFPI"]).Text = language == "EN" ? "Fins/Inch" : "Ailette/Pouce";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtTotalHeat"]).Text = language == "EN" ? "Total Heat" : "Chaleur totale";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtSensibleHeat"]).Text = language == "EN" ? "Sensible Heat" : "Chaleur sensible";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtAPD"]).Text = language == "EN" ? "Air Pressure Drop" : "Perte Press. Air";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLDB"]).Text = language == "EN" ? "LDB" : "BSS";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLWB"]).Text = language == "EN" ? "LWB" : "BHS";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLPD"]).Text = language == "EN" ? "LPD" : "Perte Press. Liq.";

            
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtGeneralData"]).Text = language == "EN" ? "General Data" : "Données générales";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFanArrangement"]).Text = language == "EN" ? "Fan Arrangement" : "Arrangement des hélices";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtShipWeight"]).Text = language == "EN" ? "Ship Weight" : "Poid à la livraison";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFinMaterial"]).Text = language == "EN" ? "Fin Material" : "Matériaux des ailettes";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCoilCoating"]).Text = language == "EN" ? "Coil Coating" : "Revêtement du serpentin";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtLiquidVelocity"]).Text = language == "EN" ? "Liquid Velocity" : "Vélocité liquide";

            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtDimDwg"]).Text = language == "EN" ? "Dimension Dwg" : "Croquis dimension";
            
            //if (language == "EN")
            //{
            //    report.DataDefinition.FormulaFields["EqualizerNote"].Text = "select mid({QuickWaterEvaporator.EvaporatorID}, 1, 6) case \"USA450\": \"Externally equalized expansion valve is required with these models\" case \"USA550\": \"Externally equalized expansion valve is required with these models\" case \"ESA452\": \"Externally equalized expansion valve is required with these models\" case \"ESA552\": \"Externally equalized expansion valve is required with these models\" default: \"Internally equalized expansion valve is required\"";
            //}
            //else
            //{
            //    report.DataDefinition.FormulaFields["EqualizerNote"].Text = "select mid({QuickWaterEvaporator.EvaporatorID}, 1, 6) case \"USA450\": \"Vanne d'expansion thermostatique avec ligne égalisatrice est requise avec ces modèles\" case \"USA550\": \"Vanne d'expansion thermostatique avec ligne égalisatrice est requise avec ces modèles\" case \"ESA452\": \"Vanne d'expansion thermostatique avec ligne égalisatrice est requise avec ces modèles\" case \"ESA552\": \"Vanne d'expansion thermostatique avec ligne égalisatrice est requise avec ces modèles\" default: \"Vanne d'expansion thermostatique sans ligne égalisatrice est requise\"";
            //}
        }
    }
}
