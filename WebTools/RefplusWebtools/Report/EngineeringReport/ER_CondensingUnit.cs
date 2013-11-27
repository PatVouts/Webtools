using System;
using System.Data;

namespace RefplusWebtools.Report.EngineeringReport
{
    public class ErCondensingUnit
    {
        public static string Generate(string model, bool openReport)
        {
            //this one containt nearly all data. condensing unit data + motor, coil fan name it
            DataTable dtCondensingUnit =
                Query.Select(@"SELECT cum.*, cur.*, v.*, cua.*, cucm.*, cuct.*, cut.*,
                               cucl.*, mm.*, mmf.*
                               FROM CondensingUnitModel as cum
                               LEFT JOIN CondensingUnitRefrigerant as cur ON
                               cum.RefrigerantID = cur.RefrigerantParameter
                               LEFT JOIN Voltage as v ON
                               cum.VoltageID = v.VoltageID
                               LEFT JOIN CondensingUnitApplication as cua ON
                               cum.[Application] = cua.[Parameter]
                               LEFT JOIN CondensingUnitCompressorManufacturer as cucm ON
                               cum.CompressorManufacturer = cucm.CompressorManufacturerParameter
                               LEFT JOIN CondensingUnitCompressorType as cuct ON
                               cum.CompressorType = cuct.CompressorTypeParameter
                               LEFT JOIN CondensingUnitType as cut ON
                               cum.UnitType + cum.AirFlow = cut.TypeParameter 
                               LEFT JOIN CondensingUnitCoilLink as cucl ON
                               cum.Model = cucl.Model 
                               LEFT JOIN MotorModel as mm ON
                               cucl.MotorModel = mm.MotorID
                               LEFT JOIN MotorModelFLA as mmf ON
                               mm.MotorID = mmf.MotorID AND
                               cum.VoltageID = mmf.VoltageID
                               WHERE cum.Model = '" + model + "'"                               
                               );
           
            //this one containt the compressors and the receiver
            DataTable dtCompressorAndReceiver = 
                Query.Select(@"SELECT cucrl.*, cd.*, cur.* FROM 
                             CondensingUnitCompressorReceiverLink as cucrl 
                             LEFT JOIN CompressorData as cd ON 
                             cucrl.CompressorModel = cd.Compressor AND
                             cucrl.VoltageID = cd.VoltageID AND
                             cucrl.RefrigerantID = cd.RefrigerantID
                             LEFT JOIN CondensingUnitReceiver as cur ON
                             cucrl.ReceiverModel = cur.ReceiverModel
                             WHERE Model = '" + model + @"'
                             ORDER BY cucrl.Model, CompressorNumber");

            //containt water cooled
            DataTable dtWaterCooled =
               Query.Select(@"SELECT cuwccl.*, cuwcc.* FROM 
                             CondensingUnitWaterCooledCondenserLink as cuwccl 
                             LEFT JOIN CondensingUnitWaterCooledCondenser as cuwcc ON 
                             cuwccl.WaterCooledModel = cuwcc.WaterCooledModel
                             WHERE Model = '" + model + @"'
                             ORDER BY cuwccl.Model, WaterCooledNumber");

            //containt the balancing which will be used in a crosstab to display in crystal report
            DataTable dtBalancing = Query.Select("SELECT * FROM CondensingUnitBalancing WHERE Model = '" + model + "' ORDER BY Balancing, SST");

            dtCondensingUnit.TableName = "CUMain";
            dtCompressorAndReceiver.TableName = "CUCompressorReceiver";
            dtWaterCooled.TableName = "CUWaterCooled";
            dtBalancing.TableName = "CUBalancing";

            var dsCondensingUnit = new DataSet("CUMainDATA");
            var dsCompressorAndReceiver = new DataSet("CUCompressorReceiverDATA");
            var dsWaterCooled = new DataSet("CUWaterCooledDATA");
            var dsBalancing = new DataSet("CUBalancingDATA");

            dsCondensingUnit.Tables.Add(dtCondensingUnit.Copy());
            dsCompressorAndReceiver.Tables.Add(dtCompressorAndReceiver.Copy());
            dsWaterCooled.Tables.Add(dtWaterCooled.Copy());
            dsBalancing.Tables.Add(dtBalancing.Copy());

            //dsCondensingUnit.WriteXmlSchema("CUMainXSD.xsd");
            //dsCompressorAndReceiver.WriteXmlSchema("CUCompressorReceiverXSD.xsd");
            //dsWaterCooled.WriteXmlSchema("CUWaterCooledXSD.xsd");
            //dsBalancing.WriteXmlSchema("CUBalancingXSD.xsd");

            //instanciate the report
            var rpt = new DLLCondensingUnit.CUEngineeringReport();

            //set datasource
            rpt.SetDataSource(dsCondensingUnit);
            rpt.Subreports["CUEngineeringReportCompressor.rpt"].SetDataSource(dsCompressorAndReceiver);
            rpt.Subreports["CUEngineeringReportWaterCooledCondenser.rpt"].SetDataSource(dsWaterCooled);
            rpt.Subreports["CUEngineeringReportBalancing.rpt"].SetDataSource(dsBalancing);
            rpt.Subreports["CUEngineeringReportBalancing.rpt"].SetDataSource(dsBalancing);
            rpt.Subreports["CUEngineeringReportBalancing.rpt - 01"].SetDataSource(dsBalancing);


            rpt.SetParameterValue("DLLVersion", Public.KFRefplus_VERSION());
            rpt.SetParameterValue("Version", Public.ApplicationVersion);
            rpt.SetParameterValue("Site", UserInformation.CurrentSite);
            rpt.SetParameterValue("CustomLogo", Reg.Get(Reg.Key.CustomLogo));
            rpt.SetParameterValue("CustomAddress", Reg.Get(Reg.Key.CustomAddress));

            //translate report            
            DLLCondensingUnit.CUEngineeringReportTranslation.translateReport(rpt, Public.Language);
            DLLCondensingUnit.CUEngineeringReportCompressorTranslation.translateReport(rpt.Subreports["CUEngineeringReportCompressor.rpt"], Public.Language);
            DLLCondensingUnit.CUWaterCoolerCondenserReportTranslation.translateReport(rpt.Subreports["CUEngineeringReportWaterCooledCondenser.rpt"], Public.Language);

            //export to pdf
            string strFileNamePath = Public.ExportReportToFormat(rpt, Public.GenerateFileNameAndPath("EngineeringReport", "pdf"), "PDF", openReport);

            //dispose object
            rpt.Dispose();

            //call garbage collector to clean out crystal report
            GC.Collect();

            return strFileNamePath;
        }
    }
}
