using QLib;
using System;
using Newtonsoft.Json;
using xNet;

namespace Qiwi_Desktop_Manager_Console
{
    class Tickets
    {
        static string token = Helper.token(MyStrings.AutoLogin, MyStrings.token);
        public static string Get()
        {
            string Name = "ContentType";
            HttpRequest req = new HttpRequest();

            string f;

            var NMP = Helper.Proxy();

            if (NMP.Length > 0)
            {
                var proxyClient = ProxyClient.Parse(ProxyType.Http, NMP);
                req.Proxy = proxyClient;
            }

            req.AddHeader("Accept", "application/json");
            req.AddHeader(Name, "application/json");
            req.AddHeader("Authorization", string.Format("Bearer {0}", token));
            string text = req.Get("https://edge.qiwi.com/payment-history/v2/persons/" + MyStrings.PNum + "/payments?rows=10", null).ToString();
            req.Close();

            myjs.RootObject newQiwi = JsonConvert.DeserializeObject<myjs.RootObject>(text);

            f = "<Чеки>" + Environment.NewLine;
            foreach (var ck in newQiwi.data)
            {
                f += "ID операции:" + ck.trmTxnId + "\r\nСтатус:" + ck.statusText + "\r\nСумма:" + ck.sum.amount + " " + ck.sum.MSC() + "\r\nТип: " + ck.MS() + ck.mcomment() + "\r\n----------------------" + Environment.NewLine;
            }            
            return f;
        }
    }
}
