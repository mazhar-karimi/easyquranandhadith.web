using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace eqwh.web.Common
{
    internal sealed class DataAccess
    {
        public static string gUnZip(byte[] gzBuffer)
        {
            string @string;
            using (GZipStream gZipStream = new GZipStream(new MemoryStream(gzBuffer), CompressionMode.Decompress))
            {
                byte[] buffer = new byte[4096];
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    int num;
                    do
                    {
                        num = gZipStream.Read(buffer, 0, 4096);
                        if (num > 0)
                        {
                            memoryStream.Write(buffer, 0, num);
                        }
                    }
                    while (num > 0);
                    @string = Encoding.UTF8.GetString(memoryStream.ToArray());
                }
            }
            return @string;
        }

        public static byte[] gDecrypt(byte[] inputArray, byte[] key)
        {
            TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
            tripleDESCryptoServiceProvider.Key = key;
            tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
            tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
            ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateDecryptor();
            byte[] result = cryptoTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDESCryptoServiceProvider.Clear();
            return result;
        }


    }   
}