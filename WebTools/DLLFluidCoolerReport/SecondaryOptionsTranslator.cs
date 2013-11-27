using System;
using System.Collections.Generic;
using System.Text;

namespace DLLFluidCoolerReport
{
    public class SecondaryOptionsTranslator
    {
        public void translateReport(SecondaryOptions report, string language)
        {
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtOptions"]).Text = language == "EN" ? "Construction Options" : "Options de construction";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFinMaterial"]).Text = language == "EN" ? "Fin Material" : "Matériaux des Ailettes";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtTubeMaterial"]).Text = language == "EN" ? "Tube Material" : "Matériaux des tubes";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCoilCoating"]).Text = language == "EN" ? "Coil Coating" : "Revêtement du Serpentin";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCasingFinish"]).Text = language == "EN" ? "Casing Finish" : "Fini du Boitier";
        }
    }
}
