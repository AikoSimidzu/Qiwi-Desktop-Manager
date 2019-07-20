using QLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using xNet;

namespace Qiwi_Desktop_Manager_Console
{
    class AutoLoginAuth
    {
        static string token = Helper.token(MyStrings.AutoLogin, MyStrings.token);

        public static void INF()
        {
            string name = "ContentType";
            HttpRequest req = new HttpRequest();

            var NMP = Helper.Proxy();

            if (NMP.Length > 0)
            {
                var proxyClient = HttpProxyClient.Parse(NMP);
                req.Proxy = proxyClient;
            }            

            if (NMP.Length > 0)
            {
                var proxyClient = HttpProxyClient.Parse(NMP);
                req.Proxy = proxyClient;
            }
            
            req.AddHeader("Accept", "application/json");
            req.AddHeader(name, "application/json");
            req.AddHeader("Authorization", string.Format("Bearer {0}", token));
            string text = req.Get("https://edge.qiwi.com/person-profile/v1/profile/current", null).ToString();
            req.Close();

            string arg = Helper.Pars(text, "{\"contractId\":", ",", 0, null); // Номер кошелька


            string arg2 = Helper.Pars(text, "\"boundEmail\":", ",", 0, null);
            string[] strs = arg2.Split(new[] { '"', '"' }, StringSplitOptions.RemoveEmptyEntries); // Почта


            req.AddHeader("Accept", "application/json");
            req.AddHeader(name, "application/json");
            req.AddHeader("Authorization", string.Format("Bearer {0}", token));
            string text3 = req.Get("https://edge.qiwi.com/funding-sources/v2/persons/" + arg + "/accounts", null).ToString();

            string arg3 = Helper.Pars(text3, "{\"amount\":", ",", 0, null); // Баланс

            string arg32 = Helper.Pars(text3, "},\"currency\":", ",", 0, null); // Валюта

            string wal = "";

            if (arg32 == "643")
            {
                wal = "RUB";
            }
            else
            {
                if (arg32 == "840")
                {
                    wal = "USD";
                }
                else
                {
                    if (arg32 == "978")
                    {
                        wal = "EUR";
                    }
                    else
                    {
                        if (arg32 == "398")
                        {
                            wal = "KZT";
                        }
                        else
                        {

                        }
                    }
                }
            }

            string arg4 = Helper.Pars(text, "\"identificationLevel\":", ",", 0, null);
            string[] strs2 = arg4.Split(new[] { '"', '"' }, StringSplitOptions.RemoveEmptyEntries);
            req.Close();
            
            Console.WriteLine(string.Format("Номер кошелька: {0}", arg));
            Console.WriteLine(string.Format("Почта: {0}", strs));
            Console.WriteLine(string.Format("Баланс: {0} " + wal, arg3));
            Console.WriteLine(string.Format("Статус кошелька: {0}", strs2));

            WalletRef.BalanceNow = arg3;
            MyStrings.PNum = arg;
            MyStrings.balance = wal + " " + arg3;

            Task.Run(() => WalletRef.Ref());
            Menu.Open();                        
        }
    }
}
