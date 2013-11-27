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
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtFinMaterial"]).Text = language == "EN" ? "Fin Material" : "Mat�riaux des Ailettes";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtTubeMaterial"]).Text = language == "EN" ? "Tube Material" : "Mat�riaux des tubes";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCoilCoating"]).Text = language == "EN" ? "Coil Coating" : "Rev�tement du Serpentin";
            ((CrystalDecisions.CrystalReports.Engine.TextObject)report.Section3.ReportObjects["txtCasingFinish"]).Text = language == "EN" ? "Casing Finish" : "Fini du Boitier";
        }
    }
}
