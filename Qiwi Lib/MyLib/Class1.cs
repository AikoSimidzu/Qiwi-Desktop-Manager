using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;

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

        public static string Proxy()
        {
            string PList = Application.StartupPath.ToString() + @"\Proxy.txt";
            string NMP = "";

            if (File.Exists(PList))
            {

                FileStream stream = new FileStream(PList, FileMode.Open);
                StreamReader reader = new StreamReader(stream);
                string ppr = reader.ReadToEnd();
                stream.Close();
                
                if (ppr.Length > 0)
                {
                    NMP = ppr;
                }
                else
                {
                }
            }
            else
            {
                File.WriteAllText(PList ,"");
            }
            return NMP;
        }

        public static string token(string x, string z) //
        {
            string tok = "";
            if (File.Exists(x))
            {
                FileStream stream = new FileStream(x, FileMode.Open);
                StreamReader reader = new StreamReader(stream);
                string ppr = reader.ReadToEnd();
                stream.Close();
                if (ppr == "Yes")
                {
                    tok = DeHash();
                    z = DeHash();
                }
                else
                {
                    tok = z;
                }
            }
            else
            {
                tok = Console.ReadLine();
            }
            return tok;
        }

        public static string Pars(string strSource, string strStart, string strEnd, int startPos = 0, string error = null)
        {
            string result;
            try
            {
                int length = strStart.Length;
                string text = "";
                int num = strSource.IndexOf(strStart, startPos);
                int num2 = strSource.IndexOf(strEnd, num + length);
                bool flag = num != -1 & num2 != -1;
                if (flag)
                {
                    text = strSource.Substring(num + length, num2 - (num + length));
                }
                result = text;
            }
            catch
            {
                result = error;
            }
            return result;
        }


    }
}
