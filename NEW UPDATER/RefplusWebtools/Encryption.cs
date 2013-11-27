using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace RefplusWebtoolsUpdater
{
    class Encryption
    {
        public static string WebServiceEncryptKey()
        {
            try
            {
                string keyword = "RefplusWebtoolsWS";
                byte[] InputByteArray = System.Text.Encoding.UTF8.GetBytes(keyword);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                UTF8Encoding uTF8Encoding = new UTF8Encoding();
                des.Key = uTF8Encoding.GetBytes("12345678");
                des.IV = des.Key;
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(InputByteArray, 0, InputByteArray.Length);
                cs.FlushFinalBlock();
                string test = Convert.ToBase64String(ms.ToArray());
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
