using System;
using System.Data;

namespace RefplusWebtools.Report.EngineeringReport
{
    class ErCondenser
    {
        public static string Generate(string model, string voltageID, bool openReport)
        {
            DataTable dtCondenser =
                Query.Select(@"SELECT Xref.*, cm.*, cs.*, v.*, m.*, MotorModel.*, mm.*, MotorFLA.*, MotorMountModel.*, f.*, FanModel.*, fg.*, FanGuardModel.* FROM CondenserXref AS Xref
                               LEFT JOIN CondenserModel AS cm ON
                               Xref.CondenserType = cm.CondenserType AND
                               Xref.Motor = cm.Motor AND
                               Xref.CoilArr = cm.CoilArr AND
                               Xref.FanLong = cm.FanLong AND
                               Xref.FanWide = cm.FanWide AND
                               Xref.Row = cm.Row AND
                               Xref.FPI = cm.FPI
                               
                               LEFT JOIN CondenserSerie AS cs ON
                               Xref.Motor = cs.Motor AND
                               Xref.CoilArr = cs.CoilArr
                               
                               LEFT JOIN Voltage as v ON
                               v.MotorCoilArr LIKE '%' + Xref.Motor + Xref.CoilArr + '%'
                               
                               LEFT JOIN CondenserMotor AS m ON
                               Xref.Motor = m.Motor AND
                               Xref.CoilArr = m.CoilArr AND
                               v.VoltageID = m.VoltageID
                               
                               LEFT JOIN MotorFLA ON
                               MotorFLA.Motor = Xref.Motor AND
                               MotorFLA.CoilArr = Xref.CoilArr AND
                               MotorFLA.VoltageID = v.VoltageID
                               
                               LEFT JOIN CondenserMotorMount AS mm ON
                               Xref.Motor = mm.Motor AND
                               Xref.CoilArr = mm.CoilArr AND
                               v.VoltageID = mm.VoltageID
                               
                               LEFT JOIN CondenserFan AS f ON
                               Xref.Motor = f.Motor AND
                               Xref.CoilArr = f.CoilArr AND
                               v.VoltageID = f.VoltageID
                               
                               LEFT JOIN CondenserFanGuard AS fg ON
                               Xref.Motor = fg.Motor AND
                               Xref.CoilArr = fg.CoilArr AND
                               v.VoltageID = fg.VoltageID
                               
                               LEFT JOIN MotorModel ON
                               MotorModel.MotorID = m.MotorID
                               
                               LEFT JOIN MotorMountModel ON
                               MotorMountModel.MotorMountID = mm.MotorMountID
                               
                               LEFT JOIN FanModel ON
                               FanModel.FanID = f.FanID
                               
                               LEFT JOIN FanGuardModel ON
                               FanGuardModel.FanGuardID = fg.FanGuardID
                               
                               WHERE (Xref.REFPLUS_CondenserXrefModel = '" + model + @"'
                               OR Xref.ECOSAIRE_CondenserXrefModel = '" + model + @"'
                               OR Xref.DECTRON_CondenserXrefModel = '" + model + @"'
                               OR Xref.CIRCULAIRE_CondenserXrefModel = '" + model + @"')
                               AND v.VoltageID = " + voltageID + @"

                               ORDER BY 
                               Xref.CondenserType,
                               Xref.Motor,
                               Xref.CoilArr,
                               Xref.FanLong,
                               Xref.FanWide,
                               Xref.Row,
                               Xref.FPI ");


            dtCondenser.TableName = "CondenserMain";

            var dsCondenser = new DataSet("CondenserMainDATA");

            dsCondenser.Tables.Add(dtCondenser.Copy());

            //dsCondenser.WriteXmlSchema("CondenserMainXSD.xsd");

            //instanciate the report
            var rpt = new DLLCondenserReport.CondenserEngineeringReport();

            //set datasource
            rpt.SetDataSource(dsCondenser);

            rpt.SetParameterValue("DLLVersion", Public.KFRefplus_VERSION());
            rpt.SetParameterValue("Version", Public.ApplicationVersion);
            rpt.SetParameterValue("Site", UserInformation.CurrentSite);
            rpt.SetParameterValue("CustomLogo", Reg.Get(Reg.Key.CustomLogo));
            rpt.SetParameterValue("CustomAddress", Reg.Get(Reg.Key.CustomAddress));

            //translate report            
            DLLCondenserReport.CondenserEngineeringReportTranslation.translateReport(rpt, Public.Language);
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
