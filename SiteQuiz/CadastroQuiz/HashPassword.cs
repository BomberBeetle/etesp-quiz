using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;


    class PasswordHasher
    {
        public static string hash(string pass, string salt)
        {
            SHA256 mySHA256 = SHA256.Create();
            return BitConverter.ToString(mySHA256.ComputeHash(Encoding.Default.GetBytes(pass + salt))).Replace("-", "");
        }

    }

