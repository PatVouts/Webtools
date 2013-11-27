using System;
using System.Windows.Forms;
using System.IO;

namespace RefplusWebtools
{
    class SoundRatingManager
    {
        public static byte[] GetSoundRating(string strSoundRatingNameWithExtension)
        {
            var ws = new WebService.Service();
            
            byte[] bSoundRating = ws.GetSoundRating(strSoundRatingNameWithExtension, Encryption.WebServiceEncryptKey());

            return bSoundRating;
        }

        public static void UploadSoundRating(string fileNameWithPath)
        {
            byte[] bFile = FileManager.FiletoByteArray(fileNameWithPath);

            //connect to webservice
            var ws = new WebService.Service();

            string fileName = fileNameWithPath.Split('\\')[fileNameWithPath.Split('\\').Length - 1];

            ws.SendSoundRating(bFile, fileName, Encryption.WebServiceEncryptKey());
        }

        public static string SaveSoundRatingToDisk(byte[] bFile, string fileName)
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
                Public.PushLog(ex.ToString(),"SoundRatingManager SaveSoundRatingToDisk");
                return null;
            }
        }
    }
}
