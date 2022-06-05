using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;
using Newtonsoft.Json;
using QLib;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Media;
using System.Net;

namespace MyDesign
{
    public partial class Form2 : Form
    {
        private HttpRequest req = new HttpRequest();

        public Form2()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                metroTabControl1.SelectTab(0);
                richTextBox1.Text = "QDM by Aiko\nGitHub: https://github.com/AikoSimidzu \n\n";

                Task.Run(() =>
                {
                    while (true)
                    {
                        try
                        {
                            if (UserData.Proxy != string.Empty)
                            {
                                var proxyClient = ProxyClient.Parse(ProxyType.Http, UserData.Proxy);
                                req.Proxy = proxyClient;
                            }

                            req.AddHeader("Accept", "application/json");
                            req.AddHeader("Authorization", string.Format("Bearer {0}", UserData.Token));
                            string text = req.Get("https://edge.qiwi.com/person-profile/v1/profile/current").ToString();
                            req.Close();

                            // Получение номера телефона
                            UserData.UserProfile.PhoneNumber = Helper.Pars(text, "{\"contractId\":", ",");
                            PNum.Invoke(new Action(() => PNum.Text = UserData.UserProfile.PhoneNumber));

                            // Получение емэйла
                            UserData.UserProfile.Email = Helper.Pars(text, "\"boundEmail\":", ",").Split(new[] { '"', '"' }, StringSplitOptions.RemoveEmptyEntries)[0];
                            Mail.Invoke(new Action(() => Mail.Text = UserData.UserProfile.Email));

                            // Получение уровня идентификации
                            UserData.UserProfile.IdentificationLevel = Helper.Pars(text, "\"identificationLevel\":", ",").Split(new[] { '"', '"' }, StringSplitOptions.RemoveEmptyEntries)[0];
                            lvl.Invoke(new Action(() => lvl.Text = UserData.UserProfile.IdentificationLevel));

                            // Получение статуса блокировки
                            UserData.UserProfile.Ban = Helper.Pars(text, "\"blocked\":", "},");
                            AcBlock.Invoke(new Action(() => AcBlock.Text = "Блокировка: " + UserData.UserProfile.Ban));

                            // Получение ника
                            UserData.UserProfile.UserName = Helper.Pars(text, "{\"nickname\":", ",");
                            MyNick.Invoke(new Action(() => MyNick.Text = "Ник: " + UserData.UserProfile.UserName));
                        }
                        catch {}

                        Thread.Sleep(1000);
                    }
                });

                if (!File.Exists(Application.StartupPath.ToString() +  @"\telegram.txt"))
                {
                    File.Create(Application.StartupPath.ToString() + @"\telegram.txt");
                }

                UserData.TelegramChatID = File.ReadAllText(Application.StartupPath.ToString() + @"\telegram.txt");
                chatId.Text = UserData.TelegramChatID;

                Task.Run(() =>
                {
                    while (true)
                    {
                        try
                        {
                            if (UserData.UserProfile.PhoneNumber == null)
                            {
                                continue;
                            }

                            if (UserData.Proxy != string.Empty)
                            {
                                var proxyClient = ProxyClient.Parse(ProxyType.Http, UserData.Proxy);
                                req.Proxy = proxyClient;
                            }

                            req.AddHeader("Accept", "application/json");
                            req.AddHeader("Authorization", string.Format("Bearer {0}", UserData.Token));
                            string text3 = req.Get("https://edge.qiwi.com/funding-sources/v2/persons/" + UserData.UserProfile.PhoneNumber + "/accounts").ToString();
                            req.Close();

                            string arg3 = Helper.Pars(text3, "{\"amount\":", ",");

                            string arg32 = Helper.Pars(text3, "},\"currency\":", ",");

                            string wal = string.Empty;

                            switch (arg32)
                            {
                                case "643":
                                    wal = "RUB";
                                    break;

                                case "840":
                                    wal = "USD";
                                    break;

                                case "978":
                                    wal = "EUR";
                                    break;

                                case "398":
                                    wal = "KZT";
                                    break;

                                default:
                                    wal = "UNKNOWN";
                                    break;
                            }
                            string NewBalnce = string.Format(arg3, " ", wal);

                            if (balance.Text != NewBalnce)
                            {
                                balance.Invoke(new Action(() => balance.Text = NewBalnce));

                                try
                                {
                                    if (notifyIcon1.Visible)
                                    {
                                        notifyIcon1.BalloonTipText = "New payment!\nBalance: " + NewBalnce;
                                        notifyIcon1.ShowBalloonTip(3500);
                                    }

                                    WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
                                    wplayer.URL = Application.StartupPath.ToString() + @"\Notify.mp3";
                                    wplayer.controls.play();

                                    if (UserData.TelegramChatID != string.Empty)
                                    {
                                        using (WebClient wc = new WebClient())
                                        {
                                            wc.DownloadString(String.Concat("http://malwaregate.site/QDM/notify.php?id=", UserData.TelegramChatID, "&trsum=", NewBalnce, "&date=", DateTime.Now.ToString()));
                                        }
                                    }
                                }
                                catch { }
                            }
                        }
                        catch { }

                        Thread.Sleep(5000);
                    }
                });
            }
            catch (Exception ex)
            {
                string Log = String.Concat(ex.ToString(), "\n", "Для получения помощи отправьте лог в Telegram: @AikoSimidzu\n----------------------------\n");
                File.WriteAllText(MyStrings.MFolder + "Error Log.txt", Log);
            }
        }

        private void GetTicket_Click(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() =>
                {
                    var NMP = Helper.Proxy();

                    if (NMP.Length > 0)
                    {
                        var proxyClient = ProxyClient.Parse(ProxyType.Http, NMP);
                        req.Proxy = proxyClient;
                    }

                    req.AddHeader("Accept", "application/json");
                    req.AddHeader("Authorization", string.Format("Bearer {0}", UserData.Token));
                    string text = req.Get("https://edge.qiwi.com/payment-history/v2/persons/" + UserData.UserProfile.PhoneNumber + "/payments?rows=10").ToString();
                    req.Close();

                    myjs.RootObject newQiwi = JsonConvert.DeserializeObject<myjs.RootObject>(text);

                    richTextBox1.Invoke(new Action(() => richTextBox1.AppendText("<Чеки>" + Environment.NewLine)));
                    foreach (var ck in newQiwi.data)
                    {
                        richTextBox1.Invoke(new Action(() => richTextBox1.AppendText($"ID операции: {ck.trmTxnId}\r\nСтатус: {ck.statusText}\r\nСумма: {ck.sum.amount} {ck.sum.MSC()}\r\nТип: {ck.MS() + ck.mcomment()}\r\n----------------------\r\n")));
                    }
                });
                metroTabControl1.SelectTab(2);
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
                    var proxyClient = ProxyClient.Parse(ProxyType.Http, NMP);
                    req.Proxy = proxyClient;
                }

                req.AddHeader("Accept", "application/json");
                req.AddHeader("Authorization", string.Format("Bearer {0}", UserData.Token));
                string text = req.Get("https://edge.qiwi.com/payment-history/v2/persons/" + UserData.UserProfile.PhoneNumber + "/payments?rows=10", null).ToString();
                req.Close();

                myjs.RootObject newQiwi = JsonConvert.DeserializeObject<myjs.RootObject>(text);

                cont = "<Чеки>" + Environment.NewLine;
                foreach (var ck in newQiwi.data)
                {
                    cont += "ID операции: " + ck.trmTxnId + "\r\nСтатус: " + ck.statusText + "\r\nСумма: " + ck.sum.amount + " " + ck.sum.MSC() + "\r\nТип: " + ck.MS() + ck.mcomment() + "\r\n----------------------" + Environment.NewLine;
                }
                File.WriteAllText(Path.Combine(Application.StartupPath.ToString(), MyStrings.checks), cont);
                MessageBox.Show("Чеки были сохранены в папке с программой!");
            }
            catch (Exception ex)
            {
                File.WriteAllText(MyStrings.MFolder + "LogError.txt", ex.ToString());
            }
        }

        private void ellipseButton1_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(Sum.Text.Replace(".", ","));
                double b = (a / 100) * 2;
                double result = a + b;

                string url = "https://edge.qiwi.com/sinap/api/v2/terms/99/payments";

                DateTime foo = DateTime.UtcNow;
                long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();
                var id = 1000 * unixTime;

                string res = Regex.Replace(balance.Text, "[0-9]", ".", RegexOptions.IgnoreCase);

                DialogResult MSG = MessageBox.Show("Вы уверены, что хотите перевести " + Sum.Text + res + " пользователю, с номером'" + Wallet.Text + "' ? " + "С учетом комиссии будет списана суммма: " + result + res, "Подтверждение", MessageBoxButtons.YesNo);

                string _wallet = string.Empty;
                if (Wallet.Text.StartsWith("+"))
                {
                    _wallet = Wallet.Text.Remove(0, 1);
                }
                else if (Wallet.Text.StartsWith("8"))
                {
                    _wallet = $"7{Wallet.Text.Remove(0, 1)}";
                }

                if (MSG == DialogResult.Yes)
                {
                    var NMP = Helper.Proxy();

                    if (NMP.Length > 0)
                    {
                        var proxyClient = HttpProxyClient.Parse(NMP);
                        req.Proxy = proxyClient;
                    }

                    req.AddHeader("Authorization", "Bearer " + UserData.Token);

                    string json;
                    if (Comment.Text.Length == 0)
                    {
                        json = string.Concat("{\"id\":\"", id, "\",\"sum\":{\"amount\":", Sum.Text.Replace(",", "."), ", \"currency\":\"643\"}, \"paymentMethod\":{\"type\":\"Account\", \"accountId\":\"643\"}, \"fields\":{\"account\":\"", _wallet, "\"}}");
                    }
                    else
                    {
                        json = string.Concat("{\"id\":\"", id, "\",\"sum\":{\"amount\":", Sum.Text.Replace(",", "."), ", \"currency\":\"643\"}, \"paymentMethod\":{\"type\":\"Account\", \"accountId\":\"643\"}, \"comment\":\"", Comment.Text + "\", \"fields\":{\"account\":\"", _wallet + "\"}}");
                    }

                    string content = req.Post(url, json, "application/json").ToString();

                    string arg32 = Helper.Pars(content, "{\"code\":", "}");

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
                    var proxyClient = ProxyClient.Parse(ProxyType.Http, NMP);
                    req.Proxy = proxyClient;
                }

                req.AddHeader("Authorization", "Bearer " + UserData.Token);
                string json = "{\"id\":\"" + idt + "\",\"sum\":{\"amount\":" + CSum.Text + ", \"currency\":\"643\"}, \"paymentMethod\":{\"type\":\"Account\", \"accountId\":\"643\"}, \"fields\":{\"account\":\"" + Card.Text + "\"}}";

                string id = " ";
                if (CT != "")
                {
                    switch (CT)
                    {
                        case "Visa":
                            id = "1963";
                            break;

                        case "MasterCard":
                            id = "21013";
                            break;

                        case "Вирт. QIWI":
                            id = "22351";
                            break;

                        case "Visa (СНГ)":
                            id = "1960";
                            break;

                        case "MasterCard (СНГ)":
                            id = "21012";
                            break;

                        case "МИР":
                            id = "31652";
                            break;
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

        private void label9_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            Hide();

            try
            {
                notifyIcon1.BalloonTipText = "Hide in tray";
                notifyIcon1.ShowBalloonTip(1500);
            }
            catch { }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon1.Visible = false;
            Show();
        }

        private void ellipseButton4_Click(object sender, EventArgs e)
        {
            UserData.TelegramChatID = chatId.Text;
            File.WriteAllText(Application.StartupPath.ToString() + @"\telegram.txt", UserData.TelegramChatID);
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
