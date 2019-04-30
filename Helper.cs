using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;

namespace Qiwi_Desktop_Manager
{
    class Helper
    {

        public static string encryptDecrypt(string input)
        {
            char[] key = { 'K', 'C', 'Q' };
            char[] output = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                output[i] = (char)(input[i] ^ key[i % key.Length]);
            }
            return new string(output);
        }

        public static string RHash()
        {
            FileStream stream = new FileStream(MyStrings.MHash, FileMode.Open);
            StreamReader reader = new StreamReader(stream);
            string ppr = reader.ReadToEnd();
            stream.Close();

            string decrypted = encryptDecrypt(ppr);

            var enTextBytes = Convert.FromBase64String(decrypted);
            string deText = Encoding.UTF8.GetString(enTextBytes);
            return deText;
        }        

    }
}