using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Aisoftware.Tracker.UseCases.Tools
{
    public static class EncryptionHandler
    {
        public static string Encrypt(string value)
        {
            byte[] buffer = Encoding.Default.GetBytes(value);
            SHA1CryptoServiceProvider cryptoServiceProvider = new SHA1CryptoServiceProvider();
            string hash = BitConverter.ToString(cryptoServiceProvider.ComputeHash(buffer)).Replace("-", "").ToLower();

            return hash;
        }
    }
}
