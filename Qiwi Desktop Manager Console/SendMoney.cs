using QLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;

namespace Qiwi_Desktop_Manager_Console
{
    class SendMoney
    {
        static string url = "https://edge.qiwi.com/sinap/api/v2/terms/99/payments";
        static string res = Regex.Replace(MyStrings.balance, "[0-9].", "", RegexOptions.IgnoreCase);
        static string Name = "ContentType";
        static string token = Helper.token(MyStrings.AutoLogin, MyStrings.token);

        public static void Send(string x, string y) // x- номер телефона, y- сумма
        {
            HttpRequest req = new HttpRequest();

            double a = int.Parse(y);
            double b = (a / 100) * 2;
            double result = a + b;

            DateTime foo = DateTime.UtcNow;
            long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();
            var id = 1000 * unixTime;

            DialogResult MSG = MessageBox.Show("Вы уверены, что хотите перевести " + y + res + " пользователю, с номером'" + x + "' ? " + "С учетом комиссии будет списана суммма: " + result + res, "Подтверждение", MessageBoxButtons.YesNo);

            if (MSG == DialogResult.Yes)
            {
                var NMP = Helper.Proxy();

                if (NMP.Length > 0)
                {
                    var proxyClient = HttpProxyClient.Parse(NMP);
                    req.Proxy = proxyClient;
                }

                req.AddHeader("Authorization", "Bearer " + token);
                string json = "{\"id\":\"" + id + "\",\"sum\":{\"amount\":" + y + ", \"currency\":\"643\"}, \"paymentMethod\":{\"type\":\"Account\", \"accountId\":\"643\"}, \"fields\":{\"account\":\"" + x + "\"}}";
                string content = req.Post(url, json, "application/json").ToString();

                string arg32 = Helper.Pars(content, "{\"code\":", "}", 0, null);
                if (arg32 == "\"Accepted\"")
                {
                    Console.WriteLine("Перевод на номер " + x + " успешно выполнен! Код операции:" + id);
                }
                else
                {
                    Console.WriteLine("Что то пошло не так! Попробуйте попытку снова.");
                }
                req.Close();
            }
            else
            {
            }
        }

        public static void Send(string x, string y, string z)  // z- комментарий
        {
            HttpRequest req = new HttpRequest();

            double a = int.Parse(y);
            double b = (a / 100) * 2;
            double result = a + b;

            DateTime foo = DateTime.UtcNow;
            long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();
            var id = 1000 * unixTime;

            DialogResult MSG = MessageBox.Show("Вы уверены, что хотите перевести " + y + res + " пользователю, с номером'" + x + "' ? " + "С учетом комиссии будет списана суммма: " + result + res, "Подтверждение", MessageBoxButtons.YesNo);

            if (MSG == DialogResult.Yes)
            {
                var NMP = Helper.Proxy();

                if (NMP.Length > 0)
                {
                    var proxyClient = HttpProxyClient.Parse(NMP);
                    req.Proxy = proxyClient;
                }

                req.AddHeader("Authorization", "Bearer " + token);
                string json = "{\"id\":\"" + id + "\",\"sum\":{\"amount\":" + y + ", \"currency\":\"643\"}, \"paymentMethod\":{\"type\":\"Account\", \"accountId\":\"643\"}, \"comment\":\"" + z + "\", \"fields\":{\"account\":\"" + x + "\"}}";
                string content = req.Post(url, json, "application/json").ToString();

                string arg32 = Helper.Pars(content, "{\"code\":", "}", 0, null);
                if (arg32 == "\"Accepted\"")
                {
                    Console.WriteLine("Перевод на номер " + x + " успешно выполнен! Код операции:" + id);
                }
                else
                {
                    Console.WriteLine("Что то пошло не так! Попробуйте попытку снова.");
                }
                req.Close();
            }
            else
            {
            }
        }
    }
}
