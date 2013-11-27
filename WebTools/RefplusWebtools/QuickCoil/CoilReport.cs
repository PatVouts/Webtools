using System;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;

namespace RefplusWebtools.QuickCoil
{
    class CoilReport
    {
        private static readonly string[] StrTableList = { "CoilFrameSize", "ConnectionSize_FluidHeating_FluidCooling" };

        public static string GenerateDataReport(DataTable dtQuickCoil, bool openReport, int quoteID, string quoteRevisionText)
        {
            Query.LoadTables(StrTableList);

            //create the dataset to be passed to the report
            var dsBuildReport = new DataSet("CoilDATA");
            dsBuildReport.Tables.Add(dtQuickCoil.Copy());
            //dsBuildReport.WriteXmlSchema("CoilXSD.xsd");
        
            // run the application to view image in report 
            //instanciate the report
            ReportDocument rptSpecReport = new DLLCoilReport.QuickCoilSpec();
            //set datasource
            rptSpecReport.SetDataSource(dsBuildReport);
            //pass the version
            rptSpecReport.SetParameterValue("Version", Public.ApplicationVersion);
            rptSpecReport.SetParameterValue("DLLVersion", Public.KFRefplus_VERSION());
            rptSpecReport.SetParameterValue("Site", UserInformation.CurrentSite);
            rptSpecReport.SetParameterValue("Dimension_A", 0);
            rptSpecReport.SetParameterValue("Dimension_B", 0);
            rptSpecReport.SetParameterValue("Dimension_F", 0);
            rptSpecReport.SetParameterValue("Dimension_G", 0);
            rptSpecReport.SetParameterValue("Dimension_J", 0);
            rptSpecReport.SetParameterValue("Dimension_K", 0);
            rptSpecReport.SetParameterValue("Dimension_MPT", 0);
            rptSpecReport.SetParameterValue("Dimension_OFFSET", 0);
            rptSpecReport.SetParameterValue("Dimension_OVERALL", 0);
            rptSpecReport.SetParameterValue("Dimension_Q", 0);
            rptSpecReport.SetParameterValue("Dimension_R", 0);
            rptSpecReport.SetParameterValue("Dimension_X", 0);
            rptSpecReport.SetParameterValue("Dimension_Y", 0);
            rptSpecReport.SetParameterValue("Dimension_Z", 0);
            rptSpecReport.SetParameterValue("Dimension_OVERALLA", 0);
            rptSpecReport.SetParameterValue("Dimension_OVERALLB", 0);
            rptSpecReport.SetParameterValue("FH_EDBMin", 0);


            rptSpecReport.SetParameterValue("CustomLogo", Reg.Get(Reg.Key.CustomLogo));
            rptSpecReport.SetParameterValue("CustomAddress", Reg.Get(Reg.Key.CustomAddress));
            rptSpecReport.SetParameterValue("QuoteID", quoteID);
            rptSpecReport.SetParameterValue("QuoteRevisionText", quoteRevisionText);

            switch (dtQuickCoil.Rows[0]["CoilType"].ToString())
            {
                case "DX":
                    var dimensionDX = new DXDimensions(Public.DSDatabase.Tables["CoilFrameSize"], Convert.ToDecimal(dtQuickCoil.Rows[0]["FinHeight"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["FinLength"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["FaceTube"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["TubeRow"]), dtQuickCoil.Rows[0]["FinType"].ToString(), Convert.ToDecimal(dtQuickCoil.Rows[0]["Row"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["DXConnectionSizeOut"]));
                    rptSpecReport.SetParameterValue("Dimension_G", dimensionDX.G);
                    rptSpecReport.SetParameterValue("Dimension_J", dimensionDX.J);
                    rptSpecReport.SetParameterValue("Dimension_K", dimensionDX.K);
                    rptSpecReport.SetParameterValue("Dimension_Q", dimensionDX.Q);
                    rptSpecReport.SetParameterValue("Dimension_Y", dimensionDX.Y);
                    rptSpecReport.SetParameterValue("Dimension_Z", dimensionDX.Z);
                    rptSpecReport.SetParameterValue("Dimension_OFFSET", dimensionDX.Offset);
                    rptSpecReport.SetParameterValue("Dimension_OVERALL", dimensionDX.OVERALL);
                    break;
                case "HR":
                    var dimensionHR = new HRDimensions(Public.DSDatabase.Tables["CoilFrameSize"], Convert.ToDecimal(dtQuickCoil.Rows[0]["FinHeight"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["FinLength"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["FaceTube"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["TubeRow"]), dtQuickCoil.Rows[0]["FinType"].ToString(), Convert.ToDecimal(dtQuickCoil.Rows[0]["Row"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["HRConnectionSizeIn"]));
                    rptSpecReport.SetParameterValue("Dimension_G", dimensionHR.G);
                    rptSpecReport.SetParameterValue("Dimension_J", dimensionHR.J);
                    rptSpecReport.SetParameterValue("Dimension_K", dimensionHR.K);
                    rptSpecReport.SetParameterValue("Dimension_Q", dimensionHR.Q);
                    rptSpecReport.SetParameterValue("Dimension_R", dimensionHR.R);
                    rptSpecReport.SetParameterValue("Dimension_X", dimensionHR.X);
                    rptSpecReport.SetParameterValue("Dimension_Y", dimensionHR.Y);
                    rptSpecReport.SetParameterValue("Dimension_Z", dimensionHR.Z);
                    rptSpecReport.SetParameterValue("Dimension_OFFSET", dimensionHR.OFFSET);
                    rptSpecReport.SetParameterValue("Dimension_OVERALL", dimensionHR.OVERALL);
                    break;
                case "FC":
                    var dimensionFC = new FCFHDimensions(Public.DSDatabase.Tables["CoilFrameSize"], Public.DSDatabase.Tables["ConnectionSize_FluidHeating_FluidCooling"], Convert.ToDecimal(dtQuickCoil.Rows[0]["FinHeight"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["FinLength"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["FaceTube"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["TubeRow"]), dtQuickCoil.Rows[0]["FinType"].ToString(), Convert.ToDecimal(dtQuickCoil.Rows[0]["Row"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["FCConnectionSizeIn"]), (dtQuickCoil.Rows[0]["FCDesignType"].ToString() == "Standard" ? DesignType.Standard : DesignType.Booster));
                    rptSpecReport.SetParameterValue("Dimension_F", dimensionFC.F);
                    rptSpecReport.SetParameterValue("Dimension_G", dimensionFC.G);
                    rptSpecReport.SetParameterValue("Dimension_J", dimensionFC.J);
                    rptSpecReport.SetParameterValue("Dimension_K", dimensionFC.K);
                    rptSpecReport.SetParameterValue("Dimension_Q", dimensionFC.Q);
                    rptSpecReport.SetParameterValue("Dimension_R", dimensionFC.R);
                    rptSpecReport.SetParameterValue("Dimension_X", dimensionFC.X);
                    rptSpecReport.SetParameterValue("Dimension_Y", dimensionFC.Y);
                    rptSpecReport.SetParameterValue("Dimension_Z", dimensionFC.Z);
                    rptSpecReport.SetParameterValue("Dimension_MPT", dimensionFC.MPT);
                    rptSpecReport.SetParameterValue("Dimension_OFFSET", dimensionFC.OFFSET);
                    rptSpecReport.SetParameterValue("Dimension_OVERALL", dimensionFC.OVERALL);
                    rptSpecReport.SetParameterValue("Dimension_OVERALLA", dimensionFC.OVERALLA);
                    rptSpecReport.SetParameterValue("Dimension_OVERALLB", dimensionFC.OVERALLB);
                    break;
                case "FH":
                    var dimensionFH = new FCFHDimensions(Public.DSDatabase.Tables["CoilFrameSize"], Public.DSDatabase.Tables["ConnectionSize_FluidHeating_FluidCooling"], Convert.ToDecimal(dtQuickCoil.Rows[0]["FinHeight"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["FinLength"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["FaceTube"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["TubeRow"]), dtQuickCoil.Rows[0]["FinType"].ToString(), Convert.ToDecimal(dtQuickCoil.Rows[0]["Row"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["FHConnectionSizeIn"]), (dtQuickCoil.Rows[0]["FHDesignType"].ToString() == "Standard" ? DesignType.Standard : DesignType.Booster));
                    rptSpecReport.SetParameterValue("Dimension_F", dimensionFH.F);
                    rptSpecReport.SetParameterValue("Dimension_G", dimensionFH.G);
                    rptSpecReport.SetParameterValue("Dimension_J", dimensionFH.J);
                    rptSpecReport.SetParameterValue("Dimension_K", dimensionFH.K);
                    rptSpecReport.SetParameterValue("Dimension_Q", dimensionFH.Q);
                    rptSpecReport.SetParameterValue("Dimension_R", dimensionFH.R);
                    rptSpecReport.SetParameterValue("Dimension_X", dimensionFH.X);
                    rptSpecReport.SetParameterValue("Dimension_Y", dimensionFH.Y);
                    rptSpecReport.SetParameterValue("Dimension_Z", dimensionFH.Z);
                    rptSpecReport.SetParameterValue("Dimension_MPT", dimensionFH.MPT);
                    rptSpecReport.SetParameterValue("Dimension_OFFSET", dimensionFH.OFFSET);
                    rptSpecReport.SetParameterValue("Dimension_OVERALL", dimensionFH.OVERALL);
                    rptSpecReport.SetParameterValue("Dimension_OVERALLA", dimensionFH.OVERALLA);
                    rptSpecReport.SetParameterValue("Dimension_OVERALLB", dimensionFH.OVERALLB);
                    rptSpecReport.SetParameterValue("FH_EDBMin", Convert.ToDecimal(dtQuickCoil.Rows[0]["FHFreezeStat"]));
                    break;
                case "ST":
                    var dimensionSteam = new STEAMDimensions(Public.DSDatabase.Tables["CoilFrameSize"], Convert.ToDecimal(dtQuickCoil.Rows[0]["FinHeight"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["FinLength"]), dtQuickCoil.Rows[0]["FinType"].ToString(), Convert.ToDecimal(dtQuickCoil.Rows[0]["Row"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["STEAMCondensateConnection"]));
                    rptSpecReport.SetParameterValue("Dimension_G", dimensionSteam.G);
                    rptSpecReport.SetParameterValue("Dimension_J", dimensionSteam.J);
                    rptSpecReport.SetParameterValue("Dimension_K", dimensionSteam.K);
                    rptSpecReport.SetParameterValue("Dimension_A", dimensionSteam.A);
                    rptSpecReport.SetParameterValue("Dimension_B", dimensionSteam.B);
                    rptSpecReport.SetParameterValue("Dimension_F", dimensionSteam.F);
                    rptSpecReport.SetParameterValue("Dimension_Z", dimensionSteam.Z);
                    rptSpecReport.SetParameterValue("Dimension_OVERALL", dimensionSteam.OVERALL);
                    break;
                case "GC":
                    var dimensionGas = new GasDimensions(Public.DSDatabase.Tables["CoilFrameSize"], Convert.ToDecimal(dtQuickCoil.Rows[0]["FinHeight"]), Convert.ToDecimal(dtQuickCoil.Rows[0]["FinLength"]), dtQuickCoil.Rows[0]["FinType"].ToString(), Convert.ToDecimal(dtQuickCoil.Rows[0]["Row"]));
                    rptSpecReport.SetParameterValue("Dimension_G", dimensionGas.G);
                    rptSpecReport.SetParameterValue("Dimension_J", dimensionGas.J);
                    rptSpecReport.SetParameterValue("Dimension_K", dimensionGas.K);
                    rptSpecReport.SetParameterValue("Dimension_A", dimensionGas.A);
                    rptSpecReport.SetParameterValue("Dimension_B", dimensionGas.B);
                    rptSpecReport.SetParameterValue("Dimension_F", dimensionGas.F);
                    rptSpecReport.SetParameterValue("Dimension_Z", dimensionGas.Z);
                    rptSpecReport.SetParameterValue("Dimension_OVERALL", dimensionGas.OVERALL);
                    break;
            }

            //translate report
            DLLCoilReport.CoilReportTranslation.translateReport((DLLCoilReport.QuickCoilSpec)rptSpecReport, Public.Language);

            //export to pdf
            string strFileNamePath = Public.ExportReportToFormat(rptSpecReport, "SpecReport", "PDF", openReport);

            //dispose object
            rptSpecReport.Dispose();

            //call garbage collector to clean out crystal report
            GC.Collect();

            return strFileNamePath;
        }
    }
}
