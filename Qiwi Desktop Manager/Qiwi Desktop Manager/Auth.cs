using System;
using xNet;
using System.Text;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using System.IO;
using QLib;
using System.Security.Cryptography;

namespace Qiwi_Desktop_Manager
{
    
    public partial class Auth : MaterialForm
    {
        private new string Name = "Content-type";
        private HttpRequest req = new HttpRequest();

        public Auth()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Orange400, Primary.Blue300, Primary.Purple200, Accent.Orange200, TextShade.WHITE);
        }

        private void Auth_Load(object sender, EventArgs e)
        {
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
                        var proxyClient = HttpProxyClient.Parse(NMP);
                        req.Proxy = proxyClient;
                    }
                    req.AddHeader("Accept", "application/json");
                    req.AddHeader(Name, "application/json");
                    req.AddHeader("Authorization", string.Format("Bearer {0}", Helper.DeHash()));
                    req.Get("https://edge.qiwi.com/person-profile/v1/profile/current", null).ToString();

                    Qiwi f1 = new Qiwi();
                    Hide();
                    f1.ShowDialog();
                    Close();

                }                               
            }
        }

        public static string token = "";
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {               
                req.AddHeader("Accept", "application/json");
                req.AddHeader(Name, "application/json");
                req.AddHeader("Authorization", string.Format("Bearer {0}", textBox1.Text));
                req.Get("https://edge.qiwi.com/person-profile/v1/profile/current", null).ToString();

                if (checkBox1.Checked)
                {
                    string hash = Helper.Hash(textBox1.Text);

                    File.WriteAllText(MyStrings.MHash, hash);
                    File.WriteAllText(MyStrings.AutoLogin, "Yes");
                }
                else
                {
                }

                token = textBox1.Text;
                Qiwi f1 = new Qiwi();
                Hide();
                f1.ShowDialog();                
                this.Close();
             
            }

            catch (Exception)
            {
                MessageBox.Show("Неправильный токен!");
            }
        }
       
    }
}