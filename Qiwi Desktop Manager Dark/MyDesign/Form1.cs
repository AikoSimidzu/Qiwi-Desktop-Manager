namespace MyDesign
{
    using QLib;
    using System;
    using System.IO;
    using System.Windows.Forms;
    using xNet;

    public partial class Form1 : Form
    {
        private new string Name = "Content-type";
        private HttpRequest req = new HttpRequest();

        public Form1()
        {
            InitializeComponent();
            Animator.Start();
        }
              
        private void Form1_Load(object sender, EventArgs e)
        {            
            try
            {
                if (File.Exists(MyStrings.AutoLogin))
                {
                    FileStream stream = new FileStream(MyStrings.AutoLogin, FileMode.Open);
                    StreamReader reader = new StreamReader(stream);
                    string ppr = reader.ReadToEnd();
                    stream.Close();

                    UserData.Proxy = Helper.Proxy();                    

                    if (ppr == "Yes")
                    {
                        if (UserData.Proxy != string.Empty)
                        {
                            var proxyClient = ProxyClient.Parse(ProxyType.Http, UserData.Proxy);
                            req.Proxy = proxyClient;
                        }
                        req.AddHeader("Accept", "application/json");
                        req.AddHeader(Name, "application/json");
                        req.AddHeader("Authorization", string.Format("Bearer {0}", Helper.DeHash()));
                        UserData.Token = Helper.DeHash();
                        req.Get("https://edge.qiwi.com/person-profile/v1/profile/current", null).ToString();
                        req.Close();

                        Form2 f2 = new Form2();
                        Opacity = 0;
                        ShowInTaskbar = false;
                        f2.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при входе! Попробуйте войти вручную. Лог с подробностями об ошибке был сохранен в папке с программой.");
                File.WriteAllText(MyStrings.MFolder + "Error Log.txt", ex.ToString());
            }
        }    

        private void panel1_Paint(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle);
            }
        }

        private void Enter_Click(object sender, EventArgs e)
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
                req.AddHeader("Authorization", string.Format("Bearer {0}", textBox1.Text));
                req.Get("https://edge.qiwi.com/person-profile/v1/profile/current", null).ToString();

                if (AEnter.Checked)
                {
                    string hash = Helper.Hash(textBox1.Text);

                    File.WriteAllText(MyStrings.MHash, hash);
                    File.WriteAllText(MyStrings.AutoLogin, "Yes");
                }
                else
                {
                    UserData.Token = textBox1.Text;
                }
                req.Close();

                Form2 cr = new Form2();
                Opacity = 0;
                ShowInTaskbar = false;
                cr.Show();
            }
            catch
            {
                MessageBox.Show("Неправильный токен!");
            }
        }
        private void textBox1_TextChanged(object sender, MouseEventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
