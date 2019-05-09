using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLib
{
    public class Helper
    {

        static string encryptDecrypt(string input)
        {
            char[] key = { 'K', 'C', 'Q' };
            char[] output = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                output[i] = (char)(input[i] ^ key[i % key.Length]);
            }
            return new string(output);
        }

        public static string Hash(string txt)
        {
            var ET = Encoding.UTF8.GetBytes(txt);
            string enText = Convert.ToBase64String(ET);
            string encrypted = encryptDecrypt(enText);
            return encrypted;
        }

        public static string DeHash()
        {
            string MFolder = Application.StartupPath.ToString() + @"\Hash.txt";

            FileStream stream = new FileStream(MFolder, FileMode.Open);
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
