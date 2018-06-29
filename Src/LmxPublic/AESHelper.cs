using System;
using System.Security.Cryptography;
using System.Text;

namespace LmxPublic
{
    // ReSharper disable once InconsistentNaming
    public static class AESHelper
    {
        //备注,使用下面的加密方法之前,先看以下文字:
        /*
        待加密的字符串是:6226620620140212|张三|310101199001021212
         
        密码:1234567890abcdef(必须是16位或者16位的倍数)
          
        那么,如果我们要通过C#的AES加密的结果跟JAVA一致,那么需要把密码:1234567890abcdef通过java的这个方法:
          
        JAVA代码生成密钥(见下方)
          
        算出一个加密的字符串,这里算出来的事是:x6/tQjkwYk9J8tVobwWgGw==
          
        接着,在通过C#的方法AESEncode()来加密,那么得出的就是跟java一样的了.
        */


        /*
        //JAVA代码生成密钥,在java里面运行这个
        String encyKey="1234567890abcdef";//合作伙伴提供的密钥,这里为:1234567890abcdef
        KeyGenerator kgen = KeyGenerator.getInstance("AES");
        java.security.SecureRandom random = java.security.SecureRandom.getInstance("SHA1PRNG");
        random.setSeed(encyKey.getBytes());
        kgen.init(128, random); 
        SecretKey secretKey = kgen.generateKey();
        byte[] enCodeFormat = secretKey.getEncoded();
        BASE64Encoder coder = new BASE64Encoder();       
        System.out.println(coder.encode(enCodeFormat));
        */

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="encryptString">待加密字符串</param>
        /// <param name="encryptKey">密码</param>
        /// <returns></returns>
        public static string AESEncode(string encryptString, string encryptKey)
        {
            if (string.IsNullOrEmpty(encryptString)) return null;
            Byte[] toEncryptArray = Encoding.UTF8.GetBytes(encryptString);
            RijndaelManaged rm = new RijndaelManaged
            {
                Key = Convert.FromBase64String(encryptKey),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = rm.CreateEncryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            String HexCryptString = Hex_2To16(resultArray);
            return HexCryptString;
            //return Convert.ToBase64String(resultArray, 0, resultArray.Length);//如果java的转了base64,那么就用这个转回去
        }

        /// <summary>
        ///  AES 解密
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string AesDecrypt(string str, string key)
        {
            if (string.IsNullOrEmpty(str)) return null;
            Byte[] toEncryptArray = Convert.FromBase64String(str);//如果java没用base64,则这里应该不需要,这个方法尚未验证,先留着

            System.Security.Cryptography.RijndaelManaged rm = new System.Security.Cryptography.RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = System.Security.Cryptography.CipherMode.ECB,
                Padding = System.Security.Cryptography.PaddingMode.PKCS7
            };

            System.Security.Cryptography.ICryptoTransform cTransform = rm.CreateDecryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Encoding.UTF8.GetString(resultArray);
        }

        /// <summary>  
        /// 2进制转16进制  
        /// </summary>  
        public static String Hex_2To16(Byte[] bytes)
        {
            String hexString = String.Empty;
            Int32 iLength = 65535;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();

                if (bytes.Length < iLength)
                {
                    iLength = bytes.Length;
                }

                for (int i = 0; i < iLength; i++)
                {
                    strB.Append(bytes[i].ToString("X2"));
                }
                hexString = strB.ToString();
            }
            return hexString;
        }

        /// <summary>  
        /// 16进制转2进制  
        /// </summary>  
        public static Byte[] Hex_16To2(String hexString)
        {
            if ((hexString.Length % 2) != 0)
            {
                hexString += " ";
            }
            Byte[] returnBytes = new Byte[hexString.Length / 2];
            for (Int32 i = 0; i < returnBytes.Length; i++)
            {
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            return returnBytes;
        }



        /// <summary>
        /// AES加密(有向量)
        /// </summary>
        /// <param name="text">加密字符</param>
        /// <param name="password">加密的密码</param>
        /// <param name="iv">向量</param>
        /// <returns></returns>
        public static string AESEncrypt(string text, string password, string iv)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Mode = CipherMode.CBC;
            rijndaelCipher.Padding = PaddingMode.PKCS7;
            rijndaelCipher.KeySize = 128;
            rijndaelCipher.BlockSize = 128;
            byte[] pwdBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] keyBytes = new byte[16];
            int len = pwdBytes.Length;
            if (len > keyBytes.Length) len = keyBytes.Length;
            System.Array.Copy(pwdBytes, keyBytes, len);
            rijndaelCipher.Key = keyBytes;
            byte[] ivBytes = System.Text.Encoding.UTF8.GetBytes(iv);
            rijndaelCipher.IV = new byte[16];
            ICryptoTransform transform = rijndaelCipher.CreateEncryptor();
            byte[] plainText = Encoding.UTF8.GetBytes(text);
            byte[] cipherBytes = transform.TransformFinalBlock(plainText, 0, plainText.Length);
            return Convert.ToBase64String(cipherBytes);
        }
        /// <summary>
        /// AES解密(有向量)
        /// </summary>
        /// <param name="text">加密字符</param>
        /// <param name="password">加密的密码</param>
        /// <param name="iv">向量</param>
        /// <returns></returns>
        public static string AESDecrypt(string text, string password, string iv)
        {
            byte[] EncryptedBytes = Convert.FromBase64String(text);

            //Setup the AES provider for decrypting.            
            AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider();
            //aesProvider.Key = System.Text.Encoding.ASCII.GetBytes(strKey);
            //aesProvider.IV = System.Text.Encoding.ASCII.GetBytes(strIV);
            aesProvider.BlockSize = 128;
            aesProvider.KeySize = 256;
            //My key and iv that i have used in openssl
            aesProvider.Key = System.Text.Encoding.ASCII.GetBytes(password);
            aesProvider.IV = System.Text.Encoding.ASCII.GetBytes(iv);
            aesProvider.Padding = PaddingMode.Zeros;
            aesProvider.Mode = CipherMode.CBC;


            ICryptoTransform cryptoTransform = aesProvider.CreateDecryptor(aesProvider.Key, aesProvider.IV);
            byte[] DecryptedBytes = cryptoTransform.TransformFinalBlock(EncryptedBytes, 0, EncryptedBytes.Length);
            return System.Text.Encoding.ASCII.GetString(DecryptedBytes);
        }


    }
}
