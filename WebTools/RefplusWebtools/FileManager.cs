using System;
using System.IO;

namespace RefplusWebtools
{
    class FileManager
    {
        /// <summary>
        /// Transform a file from a certain location to a byte array
        /// </summary>
        /// <param name="filename">Filename including path</param>
        /// <returns>Return null array if file don't exist or error occured</returns>
        public static byte[] FiletoByteArray(string filename)
        {
            try
            {
                if (File.Exists(filename))
                {
                    //put in file stream the file
                    FileStream fs = File.OpenRead(filename);

                    //will containt the read byte
                    int b1;

                    //memory stream object is perfect for transfering to byte
                    var tempStream = new MemoryStream();

                    //fill the memory stream with what the file stream contains
                    while ((b1 = fs.ReadByte()) != -1)
                    {
                        tempStream.WriteByte(((byte)b1));
                    }

                    //here the memory stream magical transfert to byte array
                    byte[] bFile = tempStream.ToArray();

                    //return the byte array
                    return bFile;
                }
                return null;
            }
            catch(Exception ex)
            {
                Public.PushLog(ex.ToString(), "fileManager FiletoByteArray");
                return null;
            }
        }

        /// <summary>
        /// Transform a byte array of a file into an actual file on a hard disk (or other data media)
        /// </summary>
        /// <param name="bFile"></param>
        /// <param name="filename">Filename inluding the path where the file will be created</param>
        /// <returns>Return if the creation of the file was a success or not</returns>
        public static bool ByteArrayToFile(byte[] bFile, string filename)
        {
            try
            {
                //memory stream is perfect for handling byte array
                //so we load the byte into the stream
                var ms = new MemoryStream(bFile);

                //open a write to save the file somewhere
                Stream sw = new FileStream(filename, FileMode.Create);

                //memory stream can write in 1 shot into a stream writer
                ms.WriteTo(sw);

                //close the writer to save the file
                //and close the rest and disposed
                sw.Close();
                ms.Close();
                sw.Dispose();
                ms.Dispose();

                //simple verification to see if the saving actually worked properly
                if (File.Exists(filename))
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                Public.PushLog(ex.ToString(),"FileManager ByteArrayToFile");
                return false;
            }

        }
    }
}
