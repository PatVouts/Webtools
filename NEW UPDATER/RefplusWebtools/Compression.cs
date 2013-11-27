using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace RefplusWebtoolsUpdater
{
    class Compression
    {
        //for multi object support we would need to loop until EOF on GetNextEntry()
        //so we can read each object one after each other


        //this function compress an object to a byte[]
        //this code support 1 object only per compression
        public static byte[] Compress(object objMyObject)
        {
            //type of serialization
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            //will use memory stream to read the dataset
            using (System.IO.MemoryStream msObject = new MemoryStream())
            {
                //serialize the object intop the stream we just created
                binaryFormatter.Serialize(msObject, objMyObject);

                //this is important to go back to begining of the stream
                msObject.Position = 0;

                //this stream is the one that we will return in this function
                //but we will need to compress first
                MemoryStream msObjectOutput = new MemoryStream();

                //ZipOutputStream actually compress a stream or filestream into
                //a Zipped stream (dll object)
                ZipOutputStream zOutStream = new ZipOutputStream(msObjectOutput);

                //this is the level of compression. for dataset 5 should be the best
                zOutStream.SetLevel(5);

                //create an entry for our new zip. It's a kind of registery pointer
                //for zip file. it tell you where the file begin and ends. it's essensial
                ZipEntry zeEntry = new ZipEntry(Guid.NewGuid().ToString());

                //give it datetime of now so when we extract if it's a file we can
                //keep the created date original to the file
                zeEntry.DateTime = DateTime.Now;

                //this is adding our entry after the file
                zOutStream.PutNextEntry(zeEntry);

                //now we write all that down in the output stream
                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while (true)
                {
                    bytesRead = msObject.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                        zOutStream.Write(buffer, 0, bytesRead);
                    else
                        break;
                }
                
                //close our stream and disposed cache
                zOutStream.Finish();
                zOutStream.Flush();
                msObject.Flush();

                byte[] bytMyByte = msObjectOutput.GetBuffer();

                //return the zipped result
                return bytMyByte;
            }

        }

        //this function decompress a byte[] into an object
        //only decompress 1 object
        //don't forget to cast teh object before using it.
        public static Object DeCompress(byte[] bytMyByte)
        {
            MemoryStream sObjectStream = new MemoryStream(bytMyByte);

            //type of serialization
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            //this is very important, in the stream is not position 0 (aka begining of file)
            //we wont be able to read the entry object so we will see a file size but with
            //no fil in it.
            sObjectStream.Position = 0;

            //now we use inputstream because we want to unzip
            ZipInputStream zInStream = new ZipInputStream((Stream)sObjectStream);

            //get our next entry, Entry is a kind of registery pointer
            //for zip file. it tell you where the file begin and ends. it's essensial
            ZipEntry zEntry = zInStream.GetNextEntry();

            //this is the stream we will output too
            MemoryStream msObjectOutput = new MemoryStream();

            //now that it's unzipped we read from the the unzipped
            //stream and put in our new stream
            byte[] buffer = new byte[1024];
            int bytesRead = 0;
            while ((bytesRead = zInStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                msObjectOutput.Write(buffer, 0, bytesRead);
            }

            //clear cache
            zInStream.Flush();

            //go back to begining of the stream
            msObjectOutput.Position = 0;

            //deserialize the stream into and object (since we can't know the type
            //we will need to cast the object before using it)
            object objMyObject = binaryFormatter.Deserialize(msObjectOutput);

            //we have the object so we can dispose && close everything
            msObjectOutput.Close();
            zInStream.Close();

            //return the object
            return objMyObject;
        }

    }
}
