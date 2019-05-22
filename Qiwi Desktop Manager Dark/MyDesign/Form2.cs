using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Forms;
using MetroFramework;
using xNet;
using Newtonsoft.Json;
using QLib;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace MyDesign
{
    public partial class Form2 : Form
    {
        private HttpRequest req = new HttpRequest();
        private new string Name = "Content-type";

        public Form2()
        {
            InitializeComponent();           
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

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panel1_Paint(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var NMP = Helper.Proxy();

            if (NMP.Length > 0)
            {
                var proxyClient = HttpProxyClient.Parse(NMP);
                req.Proxy = proxyClient;
            }

            req.AddHeader("Accept", "application/json");
            req.AddHeader(Name, "application/json");
            req.AddHeader("Authorization", string.Format("Bearer {0}", Helper.DeHash()));
            string text = req.Get("https://edge.qiwi.com/person-profile/v1/profile/current", null).ToString();
            req.Close();

            string arg = Pars(text, "{\"contractId\":", ",", 0, null);
            PNum.Text += string.Format("{0}", arg);

            string arg2 = Pars(text, "\"boundEmail\":", ",", 0, null);
            string[] strs = arg2.Split(new[] { '"', '"' }, StringSplitOptions.RemoveEmptyEntries);
            Mail.Text += string.Format("{0}", strs);

            string arg4 = Pars(text, "\"identificationLevel\":", ",", 0, null);
            string[] strs2 = arg4.Split(new[] { '"', '"' }, StringSplitOptions.RemoveEmptyEntries);
            lvl.Text += string.Format("{0}", strs2);


            Task.Run(() =>
            {
                while (true)
                {

                    if (NMP.Length > 0)
                    {
                        var proxyClient = HttpProxyClient.Parse(NMP);
                        req.Proxy = proxyClient;
                    }

                    req.AddHeader("Accept", "application/json");
                    req.AddHeader(Name, "application/json");
                    req.AddHeader("Authorization", string.Format("Bearer {0}", Helper.DeHash()));
                    string text3 = req.Get("https://edge.qiwi.com/funding-sources/v2/persons/" + arg + "/accounts", null).ToString();

                    string arg3 = Pars(text3, "{\"amount\":", ",", 0, null);

                    string arg32 = Pars(text3, "},\"currency\":", ",", 0, null);

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

                    balance.Text = string.Format("{0}" + " " + wal, arg3);
                    req.Close();
                    Thread.Sleep(5000);
                }
            });

            string[] met = { "Visa", "MasterCard", "Вирт. QIWI", "Visa (СНГ)", "MasterCard (СНГ)", "МИР" };
            comboBox1.Items.AddRange(met);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            var NMP = Helper.Proxy();

            if (NMP.Length > 0)
            {
                var proxyClient = HttpProxyClient.Parse(NMP);
                req.Proxy = proxyClient;
            }

            req.AddHeader("Accept", "application/json");
            req.AddHeader(Name, "application/json");
            req.AddHeader("Authorization", string.Format("Bearer {0}", Helper.DeHash()));
            string text = req.Get("https://edge.qiwi.com/payment-history/v2/persons/" + PNum.Text + "/payments?rows=10", null).ToString();
            req.Close();

            myjs.RootObject newQiwi = JsonConvert.DeserializeObject<myjs.RootObject>(text);

            richTextBox1.Text = "<Чеки>" + Environment.NewLine;
            foreach (var ck in newQiwi.data)
            {
                richTextBox1.Text += "ID операции:" + ck.trmTxnId + "\r\nСтатус:" + ck.statusText + "\r\nСумма:" + ck.sum.amount + " " + ck.sum.MSC() + "\r\nТип: " + ck.MS() + "\r\n----------------------" + Environment.NewLine;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.WriteAllText(MyStrings.checks, richTextBox1.Text);
            MessageBox.Show("Чеки успешно сохранены!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double a = int.Parse(Sum.Text);
            double b = (a / 100) * 2;
            double result = a + b;

            string url = "https://edge.qiwi.com/sinap/api/v2/terms/99/payments";

            DateTime foo = DateTime.UtcNow;
            long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();
            var id = 1000 * unixTime;

            string res = Regex.Replace(balance.Text, "[0-9].", "", RegexOptions.IgnoreCase);

            DialogResult MSG = MessageBox.Show("Вы уверены, что хотите перевести " + Sum.Text + res + " пользователю, с номером'" + Wallet.Text + "' ? " + "С учетом комиссии будет списана суммма: " + result + res, "Подтверждение", MessageBoxButtons.YesNo);

            if (MSG == DialogResult.Yes)
            {
                var NMP = Helper.Proxy();

                if (NMP.Length > 0)
                {
                    var proxyClient = HttpProxyClient.Parse(NMP);
                    req.Proxy = proxyClient;
                }

                req.AddHeader("Authorization", "Bearer " + Helper.DeHash());
                string json = "{\"id\":\"" + id + "\",\"sum\":{\"amount\":" + Sum.Text + ", \"currency\":\"643\"}, \"paymentMethod\":{\"type\":\"Account\", \"accountId\":\"643\"}, \"fields\":{\"account\":\"" + Wallet.Text + "\"}}";
                string content = req.Post(url, json, "application/json").ToString();

                string arg32 = Pars(content, "{\"code\":", "}", 0, null);

                if (arg32 == "\"Accepted\"")
                {
                    richTextBox1.Text = "Перевод на номер " + Wallet.Text + " успешно выполнен! Код операции:" + id;
                }
                else
                {
                    richTextBox1.Text = "Что то пошло не так! Попробуйте попытку снова.";
                }

                req.Close();
            }
            else
            {
                req.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string CT = richTextBox1.Text;

            DateTime foo = DateTime.UtcNow;
            long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();
            var idt = 1000 * unixTime;

            var NMP = Helper.Proxy();

            if (NMP.Length > 0)
            {
                var proxyClient = HttpProxyClient.Parse(NMP);
                req.Proxy = proxyClient;
            }

            req.AddHeader("Authorization", "Bearer " + Helper.DeHash());
            string json = "{\"id\":\"" + idt + "\",\"sum\":{\"amount\":" + CSum.Text + ", \"currency\":\"643\"}, \"paymentMethod\":{\"type\":\"Account\", \"accountId\":\"643\"}, \"fields\":{\"account\":\"" + Card.Text + "\"}}";

            string id = "";
            if (CT == "Visa")
            {
                id = "1963";
            }
            else
            {
                if (CT == "MasterCard")
                {
                    id = "21013";
                }
                else
                {
                    if (CT == "Вирт. QIWI")
                    {
                        id = "22351";
                    }
                    else
                    {
                        if (CT == "Visa (СНГ)")
                        {
                            id = "1960";
                        }
                        else
                        {
                            if (CT == "MasterCard (СНГ)")
                            {
                                id = "21012";
                            }
                            else
                            {
                                if (CT == "МИР")
                                {
                                    id = "31652";
                                }
                                else
                                {
                                    MessageBox.Show("Тип карты не выбран!");
                                }
                            }
                        }
                    }
                }
            }
            string url = "https://edge.qiwi.com/sinap/api/v2/terms/" + id + "/payments";
            string content = req.Post(url, json, "application/json").ToString();
            req.Close();
            richTextBox1.Text = content;
        }
    }
}
