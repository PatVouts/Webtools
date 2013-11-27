using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RefplusWebtools
{
    class TempCreateFluidCoolerWeight
    {
        private string[] strTableList = { "CoilFinType", "v_CoilfinDefaults", "v_CoilTubeDefaults", "CoilFinShape", "v_CoilFinTypeDefaults", "CoilType", "CoilFinMaterial", "CoilfinThickness", "CoilTubeMaterial", "CoilTubeThickness", "CoilFluidType", "v_CoilCasingMaterialDefaults", "CoilCasingThickness", "v_CoilHeaderDiameter", "Weather", "FreezingPointEthylene", "FreezingPointPropylene", "CoilFinTypeShape", "ElectroFinAdjustement", "HeresiteSafety", "CoilSteamMPTConnection", "ConnectionSize_Condenser", "ConnectionSize_DX", "ConnectionSize_FluidHeating_FluidCooling", "ConnectionSize_HeatReclaim", "ConnectionSize_PoundsPerFoot", "StandardConnectionCondenserInlet", "StandardConnectionCondenserOutlet", "StandardConnectionDXInlet", "StandardConnectionDXOutlet", "CoilFrameSize", "v_SelectFluidCooler", "CondenserModel", "FluidCoolerXref" };
        public void CreateFC()
        {
            Query.LoadTables(strTableList);

            Public.dsDATABASE.Tables["v_SelectFluidCooler"].Columns.Add("Weight", typeof(decimal));
            Public.dsDATABASE.Tables["v_SelectFluidCooler"].Columns.Add("RefplusModel", typeof(string));
            Public.dsDATABASE.Tables["v_SelectFluidCooler"].Columns.Add("DectronModel", typeof(string));
            Public.dsDATABASE.Tables["v_SelectFluidCooler"].Columns.Add("CondenserCoilWeight", typeof(decimal));
            Public.dsDATABASE.Tables["v_SelectFluidCooler"].Columns.Add("CondenserCasingWeight", typeof(decimal));
            Public.dsDATABASE.Tables["v_SelectFluidCooler"].Columns.Add("FluidCoolerCoilWeight", typeof(decimal));

            foreach (DataColumn dc in Public.dsDATABASE.Tables["CondenserModel"].Columns)
            {
                Public.dsDATABASE.Tables["v_SelectFluidCooler"].Columns.Add("Condenser_" + dc.ColumnName, dc.DataType);
            }

            QuickCoil.CoilWeight cw = new QuickCoil.CoilWeight();

            decimal CasingDensity = 0.29m; //galvanized steel
            decimal CasingThickness = 0.064m;// STD thickness
            decimal FinDensity = 0.09751m;//AL
            decimal FinThikness = 0.008m;//STD AL
            decimal TubeDensity = 0.323m;//copper
            decimal TubeThickness = 0.016m;//copper STD
            decimal HeaderPoundsPerSquareFoot = 1.63m;//1 1/8 header

            foreach (DataRow dr in Public.dsDATABASE.Tables["v_SelectFluidCooler"].Rows)
            {
                string Motor = dr["Motor"].ToString();
                string CoilArr = dr["CoilArr"].ToString();

                string strFilter = "Motor = '" + dr["Motor"].ToString()
                        + "' AND CoilArr = '" + dr["Coilarr"].ToString()
                        + "' AND FanWide = " + dr["FanWide"].ToString()
                        + " AND FanLong = " + dr["FanLong"].ToString()
                        + " AND Row = " + dr["Row"].ToString()
                        + " AND FPI = " + dr["FPI"].ToString()
                        + " AND AirFlow = 'V'";
                DataTable dtModelName = Public.SelectAndSortTable(Public.dsDATABASE.Tables["FluidCoolerXref"], strFilter, "");

                if (dtModelName.Rows.Count > 0)
                {
                    dr["RefplusModel"] = dtModelName.Rows[0]["REFPLUS_FluidXRefModel"].ToString();
                    dr["DectronModel"] = dtModelName.Rows[0]["DECTRON_FluidXRefModel"].ToString();
                }

                dtModelName.Dispose();

                if (Motor + CoilArr == "VV")
                {
                    Motor = "V";
                    CoilArr = "X";
                }
                else if (Motor + CoilArr == "VD")
                {
                    Motor = "V";
                    CoilArr = "R";
                }
                else if (Motor + CoilArr == "NV")
                {
                    Motor = "N";
                    CoilArr = "X";
                }
                else if (Motor + CoilArr == "ND")
                {
                    Motor = "N";
                    CoilArr = "R";
                }
                else if (Motor + CoilArr == "LD")
                {
                    Motor = "L";
                    CoilArr = "R";
                }
                else if (Motor + CoilArr == "LV")
                {
                    Motor = "L";
                    CoilArr = "X";
                }
                else if (Motor + CoilArr == "SD")
                {
                    Motor = "S";
                    CoilArr = "R";
                }
                else if (Motor + CoilArr == "SV")
                {
                    Motor = "S";
                    CoilArr = "X";
                }

                //find corresponding condenser
                DataTable dtCorrespondingCondenser = Public.SelectAndSortTable(Public.dsDATABASE.Tables["CondenserModel"], "CondenserType ='C' AND Motor ='" + Motor + "' AND CoilArr = '" + CoilArr + "' AND FanWide = " + dr["FanWide"].ToString() + " AND FanLong = " + dr["FanLong"].ToString(), "Row DESC");

                //if we have found a corresponding condenser
                if (dtCorrespondingCondenser.Rows.Count > 0)
                {
                    //calculate the coil weight
                    decimal decCondenserCoilWeight = cw.GetCoilTotalWeight(Convert.ToDecimal(dtCorrespondingCondenser.Rows[0]["FinHeight"]), Convert.ToDecimal(dtCorrespondingCondenser.Rows[0]["FinLength"]), CoilFinType(dtCorrespondingCondenser.Rows[0]["FinType"].ToString(), CoilFinTypeData.FaceTube), CoilFinType(dtCorrespondingCondenser.Rows[0]["FinType"].ToString(), CoilFinTypeData.TubeDiameter), CoilFinType(dtCorrespondingCondenser.Rows[0]["FinType"].ToString(), CoilFinTypeData.TubeRow), Convert.ToDecimal(dtCorrespondingCondenser.Rows[0]["Row"]), Convert.ToDecimal(dtCorrespondingCondenser.Rows[0]["FPI"]), CasingDensity, CasingThickness, FinDensity, FinThikness, TubeDensity, TubeThickness, HeaderPoundsPerSquareFoot);
                    dr["CondenserCoilWeight"] = decCondenserCoilWeight;
                    decimal decCasingWeight = Convert.ToDecimal(dtCorrespondingCondenser.Rows[0]["ShipWeight"]) - decCondenserCoilWeight;
                    dr["CondenserCasingWeight"] = decCasingWeight;
                    decimal decFluidCoolerCoilWeight = cw.GetCoilTotalWeight(Convert.ToDecimal(dr["FinHeight"]), Convert.ToDecimal(dr["CoilLength"]), CoilFinType(dr["Fin"].ToString(), CoilFinTypeData.FaceTube), CoilFinType(dr["Fin"].ToString(), CoilFinTypeData.TubeDiameter), CoilFinType(dr["Fin"].ToString(), CoilFinTypeData.TubeRow), Convert.ToDecimal(dr["Row"]), Convert.ToDecimal(dr["FPI"]), CasingDensity, CasingThickness, FinDensity, FinThikness, TubeDensity, TubeThickness, HeaderPoundsPerSquareFoot); ;
                    dr["FluidCoolerCoilWeight"] = decFluidCoolerCoilWeight;
                    decimal decFluidCoolerTotalWeight = decCasingWeight + decFluidCoolerCoilWeight;

                    foreach (DataColumn dc in dtCorrespondingCondenser.Columns)
                    {
                        dr["Condenser_" + dc.ColumnName] = dtCorrespondingCondenser.Rows[0][dc.ColumnName];
                    }

                    dr["Weight"] = decFluidCoolerTotalWeight;
                }

                dtCorrespondingCondenser.Dispose();
                
            }
            cw = null;

            Public.dsDATABASE.Tables["v_SelectFluidCooler"].WriteXml("C:\\test.xml", XmlWriteMode.WriteSchema);
        }

        private enum CoilFinTypeData { TubeDiameter = 0, FaceTube = 1, TubeRow = 2 };

        private decimal CoilFinType(string FinType, CoilFinTypeData data)
        {
            decimal value =0m;
            switch (FinType)
            {
                case "A":
                    switch (data)
                    {
                        case CoilFinTypeData.FaceTube:
                            value = 1.5m;
                            break;
                        case CoilFinTypeData.TubeDiameter:
                            value = 0.625m;
                            break;
                        case CoilFinTypeData.TubeRow:
                            value = 1.5m;
                            break;
                    }
                    break;
                case "C":
                    switch (data)
                    {
                        case CoilFinTypeData.FaceTube:
                            value = 1m;
                            break;
                        case CoilFinTypeData.TubeDiameter:
                            value = 0.375m;
                            break;
                        case CoilFinTypeData.TubeRow:
                            value = 0.75m;
                            break;
                    }
                    break;
                case "D":
                    switch (data)
                    {
                        case CoilFinTypeData.FaceTube:
                            value = 1.25m;
                            break;
                        case CoilFinTypeData.TubeDiameter:
                            value = 0.375m;
                            break;
                        case CoilFinTypeData.TubeRow:
                            value = 1.083m;
                            break;
                    }
                    break;
                case "E":
                    switch (data)
                    {
                        case CoilFinTypeData.FaceTube:
                            value = 1.25m;
                            break;
                        case CoilFinTypeData.TubeDiameter:
                            value = 0.5m;
                            break;
                        case CoilFinTypeData.TubeRow:
                            value = 1.083m;
                            break;
                    }
                    break;
                case "F":
                    switch (data)
                    {
                        case CoilFinTypeData.FaceTube:
                            value = 1.5m;
                            break;
                        case CoilFinTypeData.TubeDiameter:
                            value = 0.5m;
                            break;
                        case CoilFinTypeData.TubeRow:
                            value = 1.299m;
                            break;
                    }
                    break;
                case "G":
                    switch (data)
                    {
                        case CoilFinTypeData.FaceTube:
                            value = 1.5m;
                            break;
                        case CoilFinTypeData.TubeDiameter:
                            value = 0.625m;
                            break;
                        case CoilFinTypeData.TubeRow:
                            value = 1.299m;
                            break;
                    }
                    break;
                case "H":
                    switch (data)
                    {
                        case CoilFinTypeData.FaceTube:
                            value = 1m;
                            break;
                        case CoilFinTypeData.TubeDiameter:
                            value = 0.375m;
                            break;
                        case CoilFinTypeData.TubeRow:
                            value = 0.866m;
                            break;
                    }
                    break;
                case "P":
                    switch (data)
                    {
                        case CoilFinTypeData.FaceTube:
                            value = 3m;
                            break;
                        case CoilFinTypeData.TubeDiameter:
                            value = 1.125m;
                            break;
                        case CoilFinTypeData.TubeRow:
                            value = 2.165m;
                            break;
                    }
                    break; 
            }

            return value;
        }
    }
}
