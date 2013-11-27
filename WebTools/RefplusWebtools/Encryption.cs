using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace RefplusWebtools
{
    class Encryption
    {
        public static string WebServiceEncryptKey()
        {
            try
            {
                const string keyword = "RefplusWebtoolsWS";
                byte[] inputByteArray = Encoding.UTF8.GetBytes(keyword);
                var des = new DESCryptoServiceProvider();
                var uTF8Encoding = new UTF8Encoding();
                des.Key = uTF8Encoding.GetBytes("12345678");
                des.IV = des.Key;
                var ms = new MemoryStream();
                var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(),"Encryption WebServiceEncryptKey");
                return ex.Message;
            }
        }
    }
}
