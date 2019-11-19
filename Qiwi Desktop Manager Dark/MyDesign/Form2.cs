using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;
using Newtonsoft.Json;
using QLib;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using FElements;
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
            try
            {
                var NMP = Helper.Proxy();

                if (NMP.Length > 0)
                {
                    var proxyClient = HttpProxyClient.Parse(NMP);
                    req.Proxy = proxyClient;
                }

                req.AddHeader("Accept", "application/json");
                req.AddHeader(Name, "application/json");
                req.AddHeader("Authorization", string.Format("Bearer {0}", Helper.token(MyStrings.AutoLogin, Form1.token)));
                string text = req.Get("https://edge.qiwi.com/person-profile/v1/profile/current", null).ToString();
                req.Close();

                string arg = Helper.Pars(text, "{\"contractId\":", ",", 0, null);
                PNum.Text += string.Format("{0}", arg);

                string arg2 = Helper.Pars(text, "\"boundEmail\":", ",", 0, null);
                string[] strs = arg2.Split(new[] { '"', '"' }, StringSplitOptions.RemoveEmptyEntries);
                Mail.Text += string.Format("{0}", strs);

                string arg4 = Helper.Pars(text, "\"identificationLevel\":", ",", 0, null);
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
                        req.AddHeader("Authorization", string.Format("Bearer {0}", Helper.token(MyStrings.AutoLogin, Form1.token)));
                        string text3 = req.Get("https://edge.qiwi.com/funding-sources/v2/persons/" + arg + "/accounts", null).ToString();
                        req.Close();

                        string arg3 = Helper.Pars(text3, "{\"amount\":", ",", 0, null);

                        string arg32 = Helper.Pars(text3, "},\"currency\":", ",", 0, null);

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
                        Thread.Sleep(5000);
                    }
                });

                string[] met = { "Visa", "MasterCard", "Вирт. QIWI", "Visa (СНГ)", "MasterCard (СНГ)", "МИР" };
                comboBox1.Items.AddRange(met);
            }
            catch (Exception ex)
            {
                File.WriteAllText(MyStrings.MFolder + "Error Log.txt", ex.ToString());
                MessageBox.Show("Лог был сохранен в папку с программой. \nОтправьте мне его для получения помощи. \nTelegram: @AikoSimidzu", "Ошибка!");
                Application.Exit();
            }
        }

        private void GetTicket_Click(object sender, EventArgs e)
        {
            try
            {
                var NMP = Helper.Proxy();

                if (NMP.Length > 0)
                {
                    var proxyClient = HttpProxyClient.Parse(NMP);
                    req.Proxy = proxyClient;
                }

                req.AddHeader("Accept", "application/json");
                req.AddHeader(Name, "application/json");
                req.AddHeader("Authorization", string.Format("Bearer {0}", Helper.token(MyStrings.AutoLogin, Form1.token)));
                string text = req.Get("https://edge.qiwi.com/payment-history/v2/persons/" + PNum.Text + "/payments?rows=10", null).ToString();
                req.Close();

                myjs.RootObject newQiwi = JsonConvert.DeserializeObject<myjs.RootObject>(text);

                richTextBox1.Text += "<Чеки>" + Environment.NewLine;
                foreach (var ck in newQiwi.data)
                {
                    richTextBox1.Text += "ID операции:" + ck.trmTxnId + "\r\nСтатус:" + ck.statusText + "\r\nСумма:" + ck.sum.amount + " " + ck.sum.MSC() + "\r\nТип: " + ck.MS() + ck.mcomment() + "\r\n----------------------" + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                File.WriteAllText(MyStrings.MFolder + "Log " + DateTime.Now + ".txt", ex.ToString());
            }
        }

        private void SaveTicket_Click(object sender, EventArgs e)
        {
            try
            {
                string cont;
                richTextBox1.Clear();

                var NMP = Helper.Proxy();

                if (NMP.Length > 0)
                {
                    var proxyClient = HttpProxyClient.Parse(NMP);
                    req.Proxy = proxyClient;
                }

                req.AddHeader("Accept", "application/json");
                req.AddHeader(Name, "application/json");
                req.AddHeader("Authorization", string.Format("Bearer {0}", Helper.token(MyStrings.AutoLogin, Form1.token)));
                string text = req.Get("https://edge.qiwi.com/payment-history/v2/persons/" + PNum.Text + "/payments?rows=10", null).ToString();
                req.Close();

                myjs.RootObject newQiwi = JsonConvert.DeserializeObject<myjs.RootObject>(text);

                cont = "<Чеки>" + Environment.NewLine;
                foreach (var ck in newQiwi.data)
                {
                    cont += "ID операции:" + ck.trmTxnId + "\r\nСтатус:" + ck.statusText + "\r\nСумма:" + ck.sum.amount + " " + ck.sum.MSC() + "\r\nТип: " + ck.MS() + ck.mcomment() + "\r\n----------------------" + Environment.NewLine;
                }
                File.WriteAllText(MyStrings.checks, cont);
                MessageBox.Show("Чеки были сохранены в папке с программой!");
            }
            catch (Exception ex)
            {
                File.WriteAllText(MyStrings.MFolder + "Log " + DateTime.Now + ".txt", ex.ToString());
            }
        }

        private void ellipseButton1_Click(object sender, EventArgs e)
        {
            try
            {
                double a = int.Parse(Sum.Text);
                double b = (a / 100) * 2;
                double result = a + b;

                string url = "https://edge.qiwi.com/sinap/api/v2/terms/99/payments";

                DateTime foo = DateTime.UtcNow;
                long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();
                var id = 1000 * unixTime;

                string res = Regex.Replace(balance.Text, "[0-9]", ".", RegexOptions.IgnoreCase);

                DialogResult MSG = MessageBox.Show("Вы уверены, что хотите перевести " + Sum.Text + res + " пользователю, с номером'" + Wallet.Text + "' ? " + "С учетом комиссии будет списана суммма: " + result + res, "Подтверждение", MessageBoxButtons.YesNo);

                if (MSG == DialogResult.Yes)
                {
                    var NMP = Helper.Proxy();

                    if (NMP.Length > 0)
                    {
                        var proxyClient = HttpProxyClient.Parse(NMP);
                        req.Proxy = proxyClient;
                    }

                    req.AddHeader("Authorization", "Bearer " + Helper.token(MyStrings.AutoLogin, Form1.token));

                    string json;
                    if (Comment.Text.Length == 0)
                    {
                        json = "{\"id\":\"" + id + "\",\"sum\":{\"amount\":" + Sum.Text + ", \"currency\":\"643\"}, \"paymentMethod\":{\"type\":\"Account\", \"accountId\":\"643\"}, \"fields\":{\"account\":\"" + Wallet.Text + "\"}}";
                    }
                    else
                    {
                        json = "{\"id\":\"" + id + "\",\"sum\":{\"amount\":" + Sum.Text + ", \"currency\":\"643\"}, \"paymentMethod\":{\"type\":\"Account\", \"accountId\":\"643\"}, \"comment\":\"" + Comment.Text + "\", \"fields\":{\"account\":\"" + Wallet.Text + "\"}}";
                    }

                    string content = req.Post(url, json, "application/json").ToString();

                    string arg32 = Helper.Pars(content, "{\"code\":", "}", 0, null);

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
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! Лог с подробностями об ошибке был сохранен в папке с программой.");
                File.WriteAllText(MyStrings.MFolder + "Error Log.txt", ex.ToString());
            }
        }

        private void ellipseButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string CT = comboBox1.Text;

                DateTime foo = DateTime.UtcNow;
                long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();
                var idt = 1000 * unixTime;

                var NMP = Helper.Proxy();

                if (NMP.Length > 0)
                {
                    var proxyClient = HttpProxyClient.Parse(NMP);
                    req.Proxy = proxyClient;
                }

                req.AddHeader("Authorization", "Bearer " + Helper.token(MyStrings.AutoLogin, Form1.token));
                string json = "{\"id\":\"" + idt + "\",\"sum\":{\"amount\":" + CSum.Text + ", \"currency\":\"643\"}, \"paymentMethod\":{\"type\":\"Account\", \"accountId\":\"643\"}, \"fields\":{\"account\":\"" + Card.Text + "\"}}";

                string id = " ";
                if (CT != "")
                {
                    if (CT == "Visa")
                    {
                        id = "1963";
                    }

                    if (CT == "MasterCard")
                    {
                        id = "21013";
                    }

                    if (CT == "Вирт. QIWI")
                    {
                        id = "22351";
                    }

                    if (CT == "Visa (СНГ)")
                    {
                        id = "1960";
                    }

                    if (CT == "MasterCard (СНГ)")
                    {
                        id = "21012";
                    }

                    if (CT == "МИР")
                    {
                        id = "31652";
                    }

                    string url = "https://edge.qiwi.com/sinap/api/v2/terms/" + id + "/payments";
                    string content = req.Post(url, json, "application/json").ToString();
                    req.Close();
                    richTextBox1.Text = content;
                }
                else
                {
                    MessageBox.Show("Тип карты не выбран!");
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! Лог с подробностями об ошибке был сохранен в папке с программой.");
                File.WriteAllText(MyStrings.MFolder + "Error Log.txt", ex.ToString());
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ellipseButton3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length != 0)
            {
                File.WriteAllText(MyStrings.MFolder + "Логи.txt", richTextBox1.Text);
                MessageBox.Show("Логи сохранены в папке с программой!");
            }
            else
            {
                MessageBox.Show("Логи пусты!");
            }
        }
    }
}
