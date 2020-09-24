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

            string ppr = File.ReadAllText(MFolder);

            string decrypted = encryptDecrypt(ppr);
            var enTextBytes = Convert.FromBase64String(decrypted);
            string deText = Encoding.UTF8.GetString(enTextBytes);
            return deText;
        }

        public static string Proxy()
        {
            string PList = Application.StartupPath.ToString() + @"\Proxy.txt";
            string NMP = string.Empty;

            if (File.Exists(PList))
            {                
                string ppr = File.ReadAllText(PList);
                
                if (ppr.Length > 0)
                {
                    NMP = ppr;
                }
            }
            else
            {
                File.WriteAllText(PList ,"");
            }
            return NMP;
        }

        public static string token(string Path, string Token)
        {
            string tok = string.Empty;
            if (File.Exists(Path))
            {
                string ppr = File.ReadAllText(Path);
                if (ppr == "Yes")
                {
                    tok = DeHash();                    
                }
                else
                {
                    tok = Token;
                }
            }
            else
            {
                tok = Token;
            }
            return tok;
        }

        public static string Pars(string strSource, string strStart, string strEnd, int startPos = 0)
        {
            string result = string.Empty;
            try
            {
                int length = strStart.Length,
                    num = strSource.IndexOf(strStart, startPos),
                    num2 = strSource.IndexOf(strEnd, num + length);
                if (num != -1 & num2 != -1)
                    result = strSource.Substring(num + length, num2 - (num + length));
            }
            catch (Exception ex) { File.WriteAllText("ParsError.txt", ex.Message); }
            return result;
        }
    }
}
