using System;
using System.IO;
using System.Windows.Forms;

namespace RefplusWebtools
{
    class PublicityManager
    {
        public static string[] GetPublicityList()
        {
            var ws = new WebService.Service();

            string[] publicityList = ws.GetPublicityList(Encryption.WebServiceEncryptKey());

            return publicityList;
        }

        public static string SavePublicityToDisk(byte[] bFile, string fileName)
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
                Public.PushLog(ex.ToString(),"PublicityManager SavePublicityToDisk");
                return null;
            }
        }

        public static void UploadPublicity(string fileNameWithPath)
        {
            byte[] bFile = FileManager.FiletoByteArray(fileNameWithPath);

            //connect to webservice
            var ws = new WebService.Service();

            string fileName = fileNameWithPath.Split('\\')[fileNameWithPath.Split('\\').Length - 1];

            ws.SendPublicity(bFile, fileName, Encryption.WebServiceEncryptKey());
        }

        public static byte[] GetPublicity(string strDrawingNameWithExtension)
        {
            //connect to webservice
            var ws = new WebService.Service();

            byte[] bPublicity = ws.GetPublicity(strDrawingNameWithExtension, Encryption.WebServiceEncryptKey());

            return bPublicity;
        }
    }
}
