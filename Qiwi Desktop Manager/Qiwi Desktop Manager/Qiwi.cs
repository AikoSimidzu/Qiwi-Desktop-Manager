using System;
using xNet;
using System.Text;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using MetroFramework.Components;
using System.IO;

namespace Qiwi_Desktop_Manager
{
    public partial class Qiwi : MaterialForm
    {
        private HttpRequest req = new HttpRequest();
        private new string Name = "Content-type";

        public Qiwi()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Orange400, Primary.Blue300, Primary.Purple200, Accent.Orange200, TextShade.WHITE);
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

        private void Qiwi_Load(object sender, EventArgs e)
        {
            req.AddHeader("Accept", "application/json");
            req.AddHeader(Name, "application/json");
            req.AddHeader("Authorization", string.Format("Bearer {0}", Helper.RHash()));
            string text = req.Get("https://edge.qiwi.com/person-profile/v1/profile/current", null).ToString();        
            string arg = Pars(text, "{\"contractId\":", ",", 0, null);
            PNum.Text += string.Format("{0}", arg);
            req.Close();

            req.AddHeader("Accept", "application/json");
            req.AddHeader(Name, "application/json");
            req.AddHeader("Authorization", string.Format("Bearer {0}", Helper.RHash()));
            string arg2 = Pars(text, "\"boundEmail\":", ",", 0, null);
            string[] strs = arg2.Split(new[] { '"', '"' }, StringSplitOptions.RemoveEmptyEntries);
            Mail.Text += string.Format("{0}", strs);
            req.Close();

            req.AddHeader("Accept", "application/json");
            req.AddHeader(Name, "application/json");
            req.AddHeader("Authorization", string.Format("Bearer {0}", Helper.RHash()));
            string text3 = req.Get("https://edge.qiwi.com/funding-sources/v2/persons/" + arg + "/accounts", null).ToString();
            string arg3 = Pars(text3, "{\"amount\":", ",", 0, null);

            string arg32 = Pars(text3, "},\"currency\":", ",", 0, null);
            File.WriteAllText(MyStrings.MoneyCode, arg32);

                if (Helper.MCode() == "643")
                {
                    File.WriteAllText(MyStrings.MoneyCode, "RUB");
                }
                else
                {
                    if (arg3 == "840")
                    {
                        File.WriteAllText(MyStrings.MoneyCode, "USD");
                    }
                    else
                    {
                        if (arg3 == "978")
                        {
                            File.WriteAllText(MyStrings.MoneyCode, "EUR");
                        }
                        else
                        {
                            if (arg3 == "398")
                            {
                                File.WriteAllText(MyStrings.MoneyCode, "KZT");
                            }
                            else
                            {

                            }
                        }
                    }
                }        

            balance.Text += string.Format("{0}" + " " + Helper.MCode(), arg3);           
            req.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://edge.qiwi.com/sinap/api/v2/terms/99/payments";

            DateTime foo = DateTime.UtcNow;
            long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();
            var id = 1000 * unixTime;

            DialogResult MSG = MessageBox.Show("Вы уверены, что хотите перевести " + Sum.Text + " " + Helper.MCode() + " пользователю, с номером'" + Wallet.Text + "' ?" );

            if (MSG == DialogResult.Yes)
            {
                req.AddHeader("Authorization", "Bearer " + Helper.RHash());
                string json = "{\"id\":\"" + id + "\",\"sum\":{\"amount\":" + Sum.Text + ", \"currency\":\"643\"}, \"paymentMethod\":{\"type\":\"Account\", \"accountId\":\"643\"}, \"fields\":{\"account\":\"" + Wallet.Text + "\"}}";
                string content = req.Post(url, json, "application/json").ToString();
                string arg32 = Pars(content, "{\"code\":", "}", 0, null);                                
            }
            else
            { }

        }
    }
}
