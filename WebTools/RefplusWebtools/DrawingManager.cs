using System;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace RefplusWebtools
{
    public class DrawingManager
    {
        public enum DrawingCategory { FluidCooler, Condenser, Evaporator, CondensingUnit, GravityCoil };

        public static string GetCategory(DrawingCategory dc)
        {
            string strCategory = "";

            switch (dc)
            {
                case DrawingCategory.Condenser:
                    strCategory = "CONDENSER";
                    break;
                case DrawingCategory.CondensingUnit:
                    strCategory = "CONDENSING_UNIT";
                    break;
                case DrawingCategory.Evaporator:
                    strCategory = "EVAPORATOR";
                    break;
                case DrawingCategory.FluidCooler:
                    strCategory = "FLUID_COOLER";
                    break;
                case DrawingCategory.GravityCoil:
                    strCategory = "GRAVITY_COIL";
                    break;
            }

            return strCategory;
        }
        public static byte[] GetDrawingFile(string strDrawingNameWithExtension, string company)
        {
            //connect to webservice
            var ws = new WebService.Service();

            byte[] bDrawing = ws.GetDrawing(strDrawingNameWithExtension, company, Encryption.WebServiceEncryptKey());

            return bDrawing;
        }

        public static byte[] GetDrawingFile(string strDrawingNameWithExtension, string company, DrawingCategory dc)
        {
            //connect to webservice
            var ws = new WebService.Service();

            byte[] bDrawing = ws.GetDrawing_NEW(strDrawingNameWithExtension, company, GetCategory(dc), Encryption.WebServiceEncryptKey());

            return bDrawing;
        }

        public static string[] GetListOfDrawings(string company)
        {
            //connect to webservice
            var ws = new WebService.Service();

            string[] listOfDrawings = ws.GetDrawingList(company, Encryption.WebServiceEncryptKey());

            return listOfDrawings;
        }

        public static string[] GetListOfDrawings(string company, DrawingCategory dc)
        {
            //connect to webservice
            var ws = new WebService.Service();

            string[] listOfDrawings = ws.GetDrawingList_NEW(company, GetCategory(dc), Encryption.WebServiceEncryptKey());

            return listOfDrawings;
        }


        public static string SaveDrawingToDisk(byte[] bFile, string fileName)
        {
            try
            {
                //randomize number
                long lngRandomizeNumber = DateTime.Now.Ticks;

                //create the temp folder if not exist
                if (!Directory.Exists(Application.StartupPath + @"\temp"))
                {
                    Public.ClearAndRecreateTempFolder();
                }

                string strFilePath = Application.StartupPath + @"\temp\" + fileName.Split('.')[0] + "_" + lngRandomizeNumber + "." + fileName.Split('.')[1];

                FileManager.ByteArrayToFile(bFile, strFilePath);

                return strFilePath;
            }
            catch(Exception ex)
            {
                Public.PushLog(ex.ToString(),"DrawingManager SaveDrawingToDisk");
                return null;
            }
        }

        public static void UploadFile(string fileNameWithPath, string company)
        {

            byte[] bFile = FileManager.FiletoByteArray(fileNameWithPath);

            //connect to webservice
            var ws = new WebService.Service();

            string fileName = fileNameWithPath.Split('\\')[fileNameWithPath.Split('\\').Length - 1];

            ws.SendDrawing(bFile, fileName, company, Encryption.WebServiceEncryptKey());
           
        }

        public static void UploadFile(string fileNameWithPath, string company, DrawingCategory dc)
        {

            byte[] bFile = FileManager.FiletoByteArray(fileNameWithPath);

            //connect to webservice
            var ws = new WebService.Service();

            string fileName = fileNameWithPath.Split('\\')[fileNameWithPath.Split('\\').Length - 1];

            ws.SendDrawing_NEW(bFile, fileName, company, GetCategory(dc), Encryption.WebServiceEncryptKey());

        }

        public static string GetDrawingName(DataTable dtDrawings, string model)
        {
            DataTable dtModel = Public.SelectAndSortTable(dtDrawings, "Model = '" + model + "'", "Revision DESC, UpdateDate DESC");

            return dtModel.Rows.Count > 0 ? dtModel.Rows[0]["DrawingName"].ToString() : null;
        }

        public static string GetDrawingName(DrawingCategory dc, string model)
        {
            DataTable dtModel = Query.Select("SELECT * FROM DrawingManager_" + GetCategory(dc) + " WHERE Model = '" + model + "'");
                
            return dtModel.Rows.Count > 0 ? dtModel.Rows[0]["Filename"].ToString() : null;
        }

        public static string GetDrawingName_CondensingUnit(DataTable dtCondensingUnitDrawingManager, string unitType, string airFlow, string compressorType, string hp, string numberOfCompressor, string compressorManufacturer, string application, string refrigerantType, string voltageID, string unitOptions)
        {
            if (unitOptions == null) throw new ArgumentNullException("unitOptions");
            string strDrawingName = "";

            string strOptionFilter = "";

            string[] strOptionList = unitOptions.Split(',');

            for (int i = 0; i < strOptionList.Length; i++)
            {
                if (strOptionList[i] != "")
                {
                    //2012-02-17 : #1957 : Simon wnat to change the way the drawing selection
                    //is done, he want to be pick by combo
                    strOptionFilter += " AND Options LIKE '%" + strOptionList[i] + "%' ";
                    ////2011-07-13 : Simon wnat ot change the way drawing selection is done
                    ////we now change o pick per letter and not as combo
                    //strOptionFilter += " OR Options LIKE '%" + strOptionList[i] + "%' ";
                    ////strOptionFilter += " AND Options LIKE '%" + strOptionList[i] + "%' ";
                }
            }

            strOptionFilter = " AND (" + strOptionFilter.Substring(4) + ")";

            DataTable dtDrawings = Public.SelectAndSortTable(dtCondensingUnitDrawingManager, "FirstPart LIKE '%" + unitType + airFlow + compressorType + "%' AND MinHP <= " + hp + " AND MaxHP >= " + hp + " AND Compressor LIKE '%" + numberOfCompressor.PadLeft(2, '0') + "%' AND ThirdPart LIKE '%" + compressorManufacturer + application + refrigerantType + "%' AND Voltage LIKE '%" + voltageID + "%' " + strOptionFilter, "Description");

            if (dtDrawings.Rows.Count > 0)
            {
                strDrawingName = dtDrawings.Rows[0]["Drawing"].ToString();
            }

            return strDrawingName;
        }

        public static string GetDrawingName_Evaporator(DataTable dtEvaporatorDrawingManager, string serie, decimal capacity, string voltageID)
        {
            string strDrawingName = "";

            DataTable dtDrawings = Public.SelectAndSortTable(dtEvaporatorDrawingManager, "Serie LIKE '%" + serie + "%' AND MinCapacity <= " + capacity + " AND MaxCapacity >= " + capacity + " AND  Voltage LIKE '%" + voltageID + "%'", "Description");

            if (dtDrawings.Rows.Count > 0)
            {
                strDrawingName = dtDrawings.Rows[0]["Drawing"].ToString();
            }

            return strDrawingName;
        }
    }
}
