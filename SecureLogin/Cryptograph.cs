using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography;

namespace AesSec
{
    class Cryptograph
    {
        public static string IV = "qo1lc3sjd8zpt9cx";
       public static string Key = "ow7dxys8glfor9tnc2ansdfo1etkfjcv";

     //  public static string Key = "EeR5c2dys8gfseVyJdR8*^oKed&/25";

        public static string crypt(string decryption)
        {
            byte[] bytEn = ASCIIEncoding.ASCII.GetBytes(decryption);
            AesCryptoServiceProvider encod = new AesCryptoServiceProvider();
            encod.BlockSize = 128;
            encod.KeySize = 256;
            encod.Key= ASCIIEncoding.ASCII.GetBytes(Key);
            encod.IV= ASCIIEncoding.ASCII.GetBytes(IV);
            encod.Padding = PaddingMode.PKCS7;
            encod.Mode = CipherMode.CBC;
            ICryptoTransform trns = encod.CreateEncryptor(encod.Key,encod.IV);

            byte[] enc = trns.TransformFinalBlock(bytEn, 0 , bytEn.Length);
            trns.Dispose();

            return Convert.ToBase64String(enc);
        }

        public static string Decrp(string Encrpt)
        {
            byte[] bytdec = Convert.FromBase64String(Encrpt);
            AesCryptoServiceProvider encod = new AesCryptoServiceProvider();
            encod.BlockSize = 128;
            encod.KeySize = 256;
            encod.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            encod.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            encod.Padding = PaddingMode.PKCS7;
            encod.Mode = CipherMode.CBC;
            ICryptoTransform trns = encod.CreateDecryptor(encod.Key, encod.IV);

            byte[] dcrt = trns.TransformFinalBlock(bytdec, 0, bytdec.Length);
            trns.Dispose();

            return ASCIIEncoding.ASCII.GetString(dcrt);
        }
    }

   
}
