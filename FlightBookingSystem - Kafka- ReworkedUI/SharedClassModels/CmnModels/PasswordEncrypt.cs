using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SharedClassModels.CmnModels
{
    public class PasswordEncrypt
    {
        public string EncryptPwd(string pwd)
        {
            try
            {
                using (SHA512 sha512hash = SHA512.Create())
                {
                    byte[] sourceBytes = Encoding.UTF8.GetBytes(pwd);
                    byte[] hashBytes = sha512hash.ComputeHash(sourceBytes);
                    string hashedPassword = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

                    string Pwd = hashedPassword;
                    return Pwd;
                }
            }   
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
