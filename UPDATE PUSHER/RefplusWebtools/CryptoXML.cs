using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Data;
using System.Security;
using System.Security.Cryptography;
using System.Xml;

namespace UpdatePusher
{
	/// <summary>
	/// Summary:
	/// --------
	/// The XMLEncryptor class provides methods to save and read a DataSet as an encrypted XML file.
	/// 
	/// Main functionality:
	/// -------------------
	/// 1. Save any DataSet to an encrypted XML file.
	/// 2. Read the encrypted XML file back and present it to any program as a DataSet, 
	///    without creating temporary files in the process
	/// 3. The encrypted XML files are marked with a signature that identifies them as being encrypted files.
	/// 
	/// Limitations:
	/// ------------
	/// 1. The class uses a user name and password to generate a combined key which is used for encryption. 
	///    No methods are provided to manage the secure storage of these data.
	/// 2. Theoretically, the class can handle files up to 2GB in size. In practice, since conversions 
	///    are handled in memory to avoid having temporary (decrypted) files being written to the drive, 
	///    the practical size may be limited by available system resources.
	/// </summary>
    public class XMLEncryptor
    {
        private const string USERNAME = "GA6frer0we7w5w567g";
        private const string PASSWORD = "fn4Afsf4yu7Aatet45";

        private byte[] signature;
        //private string username, password;
        const int BIN_SIZE = 4096;
        private byte[] md5Key, md5IV;
        private bool validParameters;

        public XMLEncryptor(/*string username, string password*/)
        {
            //this.username = username;
            //this.password = password;
            if (USERNAME.Length + PASSWORD.Length < 6)
            {
                validParameters = false;
                // abort the constructor. Calls to public functions will not work.
                return;
            }
            else
            {
                validParameters = true;
            }
            GenerateSignature();
            GenerateKey();
            GenerateIV();
        }

        #region Helper functions called from constructor only
        /// <summary>
        /// Generates a standard signature for the file. The signature may be longer than 16 bytes if deemed necessary.
        /// The signature, which is NOT ENCRYPTED, serves two purposes. 
        /// 1. It allows to recognize the file as one that has been encrypted with the XMLEncryptor class.
        /// 2. The first bytes of each XML file are quite similar (<?xml version="1.0" encoding="utf-8" ?>).
        ///	 This can be exploite to "guess" the key the file has been encrypted with. Adding a signature of a reasonably
        ///	 large number of bytes can be used to overcome this limitation.
        /// </summary>
        private void GenerateSignature()
        {
            signature = new byte[16] {
												 123,	078,	099,	166,
												 000,	043,	244,	008,
												 005,	089,	239,	255,
												 045,	188,	007,	033
											 };
        }
        /// <summary>
        /// Generates an MD5 key for encryption/decryption. This method is only called during construction.
        /// </summary>
        private void GenerateKey()
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            StringBuilder hash = new StringBuilder(USERNAME + PASSWORD);

            // Manipulate the hash string - not strictly necessary.
            for (int i = 1; i < hash.Length; i += 2)
            {
                char c = hash[i - 1];
                hash[i - 1] = hash[i];
                hash[i] = c;
            }

            // Convert the string into a byte array.
            Encoding unicode = Encoding.Unicode;
            byte[] unicodeBytes = unicode.GetBytes(hash.ToString());
            // Compute the key from the byte array
            md5Key = md5.ComputeHash(unicodeBytes);
        }
        /// <summary>
        /// Generates an MD5 Initiakization Vector for encryption/decryption. This method is only called during construction.
        /// </summary>
        private void GenerateIV()
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            string hash = PASSWORD + USERNAME;

            // Convert the string into a byte array.
            Encoding unicode = Encoding.Unicode;
            byte[] unicodeBytes = unicode.GetBytes(hash);

            // Compute the IV from the byte array
            md5IV = md5.ComputeHash(unicodeBytes);
        }


        #endregion

        #region Methods to write and verify the signature
        private void WriteSignature(FileStream fOut)
        {
            fOut.Position = 0;
            fOut.Write(signature, 0, 16);
        }
        private bool VerifySignature(FileStream fIn)
        {
            byte[] bin = new byte[16];
            fIn.Read(bin, 0, 16);
            for (int i = 0; i < 16; i++)
            {
                if (bin[i] != signature[i])
                {
                    return false;
                }
            }
            // Reset file pointer.
            fIn.Position = 0;
            return true;
        }


        #endregion

        #region Public Functions
        /// <summary>
        /// Reads an encrypted XML file into a DataSet.
        /// </summary>
        /// <param name="fileName">The path to the XML file.</param>
        /// <returns>The DataSet, or null if an error occurs.</returns>
        public DataSet ReadEncryptedXML(string fileName)
        {
            FileInfo fi = new FileInfo(fileName);
            FileStream inFile;

            #region Check for possible errors (includes verification of the signature).
            if (!validParameters)
            {
                Trace.WriteLine("Invalid parameters - cannot perform requested action");
                return null;
            }
            if (!fi.Exists)
            {
                Trace.WriteLine("Cannot perform decryption: File " + fileName + " does not exist.");
                return null;
            }
            if (fi.Length > Int32.MaxValue)
            {
                Trace.WriteLine("This decryption method can only handle files up to 2GB in size.");
                return null;
            }

            try
            {
                inFile = new FileStream(fi.ToString(), FileMode.Open);
            }
            catch (Exception exc)
            {
                Trace.WriteLine(exc.Message + "Cannot perform decryption");
                return null;
            }
            if (!VerifySignature(inFile))
            {
                Trace.WriteLine("Invalid signature - file was not encrypted using this program");
                return null;
            }
            #endregion

            RijndaelManaged rijn = new RijndaelManaged();
            rijn.Padding = PaddingMode.Zeros;
            ICryptoTransform decryptor = rijn.CreateDecryptor(md5Key, md5IV);
            // Allocate byte array buffer to read only the xml part of the file (ie everything following the signature).
            byte[] encryptedXmlData = new byte[(int)fi.Length - signature.Length];
            inFile.Position = signature.Length;
            inFile.Read(encryptedXmlData, 0, encryptedXmlData.Length);

            // Convert the byte array to a MemoryStream object so that it can be passed on to the CryptoStream
            MemoryStream encryptedXmlStream = new MemoryStream(encryptedXmlData);
            // Create a CryptoStream, bound to the MemoryStream containing the encrypted xml data
            CryptoStream csDecrypt = new CryptoStream(encryptedXmlStream, decryptor, CryptoStreamMode.Read);

            // Read in the DataSet from the CryptoStream
            DataSet data = new DataSet();
            try
            {
                data.ReadXml(csDecrypt, XmlReadMode.Auto);
            }
            catch (Exception exc)
            {
                Trace.WriteLine(exc.Message, "Error decrypting XML");
                return null;
            }

            // flush & close files.
            encryptedXmlStream.Flush();
            encryptedXmlStream.Close();
            inFile.Close();
            return data;
        }

        /// <summary>
        /// Writes a DataSet to an encrypted XML file.
        /// </summary>
        /// <param name="dataset">The DataSet to encrypt.</param>
        /// <param name="encFileName">The name of the encrypted file. Existing files will be overwritten.</param>
        public void WriteEncryptedXML(DataSet dataset, string encFileName)
        {
            FileStream fOut;

            #region Check for possible errors
            if (!validParameters)
            {
                Trace.WriteLine("Invalid parameters - cannot perform requested action");
                return;
            }
            #endregion
            // Create a MemoryStream and write the DataSet to it.
            MemoryStream xmlStream = new MemoryStream();
            dataset.WriteXml(xmlStream, XmlWriteMode.WriteSchema);
            // Reset the pointer of the MemoryStream (which is at the EOF after the WriteXML function).
            xmlStream.Position = 0;

            if(File.Exists(encFileName))
            {
                File.Delete(encFileName);
            }

            // Create a write FileStream and write the signature to it (unencrypted).
            fOut = new FileStream(encFileName, FileMode.Create);
            WriteSignature(fOut);

            #region Encryption objects
            RijndaelManaged rijn = new RijndaelManaged();
            rijn.Padding = PaddingMode.Zeros;
            ICryptoTransform encryptor = rijn.CreateEncryptor(md5Key, md5IV);
            CryptoStream csEncrypt = new CryptoStream(fOut, encryptor, CryptoStreamMode.Write);
            #endregion
            //Create variables to help with read and write.
            byte[] bin = new byte[BIN_SIZE];			// Intermediate storage for the encryption.
            int rdlen = 0;									// The total number of bytes written.
            int totlen = (int)xmlStream.Length;	// The total length of the input stream.
            int len;											// The number of bytes to be written at a time.

            //Read from the input file, then encrypt and write to the output file.
            while (rdlen < totlen)
            {
                len = xmlStream.Read(bin, 0, bin.Length);
                if (len == 0 && rdlen == 0)
                {
                    Trace.WriteLine("No read");
                    break;
                }
                csEncrypt.Write(bin, 0, len);
                rdlen += len;
            }
            csEncrypt.FlushFinalBlock();
            csEncrypt.Close();
            fOut.Close();
            xmlStream.Close();
        }

        public void WriteEncryptedXML(DataTable datatable, string encFileName)
        {
            DataSet data = new DataSet();
            data.Tables.Add(datatable);

            WriteEncryptedXML(data,encFileName);
        }

        #endregion
    }
}
