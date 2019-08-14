using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Servicios.Secure
{
    public class CryptoHelper : ICryptoHelper
    {
        public SymmetricAlgorithm saEnc = new RijndaelManaged();
        public string sKey = "1y2+OeNPEmhzo6dF6HYmpk0VWCmlyq7FCWdJ4IFwm4Q=";
        public string Decrypt(string sEncriptedText)
        {
            saEnc.Key = Convert.FromBase64String(sKey);
            saEnc.Mode = CipherMode.ECB;
            ICryptoTransform decryptor = saEnc.CreateDecryptor();
            byte[] data = Convert.FromBase64String(sEncriptedText);
            byte[] dataDecrypted = decryptor.TransformFinalBlock(data, 0, data.Length);
            return Encoding.Unicode.GetString(dataDecrypted);
        }

        public string Encrypt(string sOriginalText)
        {
            saEnc.Key = Convert.FromBase64String(sKey);
            saEnc.Mode = CipherMode.ECB;
            ICryptoTransform encryptor = saEnc.CreateEncryptor();
            byte[] data = Encoding.Unicode.GetBytes(sOriginalText);
            byte[] dataEncrypted = encryptor.TransformFinalBlock(data, 0, data.Length);
            return Convert.ToBase64String(dataEncrypted);
        }

        public string GeneratePassword(int length)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }
    }
}
