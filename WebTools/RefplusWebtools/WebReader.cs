using System;
using System.IO;
using System.Windows.Forms;

namespace RefplusWebtools
{
    class WebReader
    {
        private readonly string _onlineText = "";
        
        //simple getter to have the text online.
        public string GetOnlineText()
        {
            return _onlineText;
        }


        public WebReader(String strLocation,String strFile)
        {
            Stream strm = null;
            StreamReader myReader = null;

            try
            {
                // Download the web page.
                strm = GetUrlStream("http://" + strLocation +"/" + strFile);
                if (strm != null)
                {
                    // We have a stream, let's attach a byte reader.
                    var strBuffer = new char[3001];

                    myReader = new StreamReader(strm);

                    // Read 3,000 bytes at a time until we get the whole file.
                    string strLine = "";
                    while (myReader.Read(strBuffer, 0, 3000) > 0)
                    {
                        strLine += new string(strBuffer);
                        
                    }
                    _onlineText = strLine;
                }
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(), "WebReader WebReader");
                Console.WriteLine(@"Error: " + ex.Message);
            }
            finally
            {
                // Clean up and close the stream, no matter what happened
                if (myReader != null)
                {
                    myReader.Close();
                }

                if (strm != null)
                {
                strm.Close();
                }
            }
        }
        public Stream GetUrlStream(string strUrl)
        {
            System.Net.WebResponse objResponse = null;

            try
            {
                System.Net.WebRequest objRequest = System.Net.WebRequest.Create(strUrl);
                objRequest.Timeout = 5000;
               

                objResponse = objRequest.GetResponse();
                Stream objStreamReceive = objResponse.GetResponseStream();

                return objStreamReceive;
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(), "WebReader GetURLStream");
                Console.WriteLine(ex.Message);
                if (objResponse != null) objResponse.Close();

                return null;
            }
        }

        public void ReadWriteStream(Stream readStream, Stream writeStream, int currentVersion, long bytesCompleted)
        {
            const int length = 2048;
            var buffer = new Byte[length];
            int bytesRead = readStream.Read(buffer, 0, length);
            // write the required bytes
            while (bytesRead > 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, length);
                Application.DoEvents();
            }
            readStream.Close();
            writeStream.Close();
        }
    }
}
