using QLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;

namespace Qiwi_Desktop_Manager_Console
{
    class AutoLogin
    {
        public static string Status = "";

        public static void Auth()
        {
            string name = "ContentType";
            HttpRequest req = new HttpRequest();

            if (File.Exists(MyStrings.AutoLogin))
            {
                FileStream stream = new FileStream(MyStrings.AutoLogin, FileMode.Open);
                StreamReader reader = new StreamReader(stream);
                string ppr = reader.ReadToEnd();
                stream.Close();

                var NMP = Helper.Proxy();

                if (ppr == "Yes")
                {
                    if (NMP.Length > 0)
                    {
                        var proxyClient = ProxyClient.Parse(ProxyType.Http, NMP);
                        req.Proxy = proxyClient;
                    }

                    try
                    {
                        req.AddHeader("Accept", "application/json");
                        req.AddHeader(name, "application/json");
                        req.AddHeader("Authorization", string.Format("Bearer {0}", Helper.DeHash()));
                        req.Get("https://edge.qiwi.com/person-profile/v1/profile/current", null).ToString();
                        req.Close();
                        Status = "OK";
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine("Возникла ошибка, повторите попытку позже. " + ex);
                    }

                }
            }

            else
            {

            }

        }
    }
}
