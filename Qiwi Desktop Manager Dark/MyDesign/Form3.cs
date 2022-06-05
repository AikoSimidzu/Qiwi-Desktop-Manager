using QLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MyDesign
{
    public partial class Form3 : Form
    {
        List<string> ls = new List<string>();

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath.ToString() + @"\MultiAcc.txt"))
            {
                foreach (string str in File.ReadAllLines(Application.StartupPath.ToString() + @"\MultiAcc.txt"))
                {
                    if (UserData.OldToken != string.Empty)
                    {
                        listView1.Items.Add(new ListViewItem(new String[] { UserData.OldToken, "MainToken" }));
                    }
                    ls.Add(str);
                    string tok = Helper.Pars(str, "Token:", ":");
                    string descr = Helper.Pars(str, "Description:", ":Proxy");
                    string proxy = Helper.Pars(str, ":Proxy:", "]");

                    string[] dat = { tok, descr, proxy};
                    listView1.Items.Add(new ListViewItem(dat));
                }
            }
        }

        private void ellipseButton1_Click(object sender, EventArgs e) // вход
        {
            foreach (ListViewItem items in listView1.SelectedItems)
            {
                if (UserData.OldToken == null || UserData.OldToken == String.Empty)
                {
                    UserData.OldToken = UserData.Token;
                    listView1.Items.Add(new ListViewItem(new string[] { UserData.Token, "Main Token" }));
                }
                UserData.Proxy = items.SubItems[2].Text != string.Empty || items.SubItems[2].Text != "null" || items.SubItems[2].Text != null ? items.SubItems[2].Text : string.Empty;
                UserData.Token = items.Text;
            }
        }

        private void ellipseButton2_Click(object sender, EventArgs e) // добавить
        {
            ls.Add(Format(textBox1.Text, textBox2.Text, textBox3.Text));
            File.AppendAllText(Application.StartupPath.ToString() + @"\MultiAcc.txt", Format(textBox1.Text, textBox2.Text, textBox3.Text) + "\n"); // запись           

            string[] dat = { textBox1.Text, textBox2.Text, textBox3.Text };
            listView1.Items.Add(new ListViewItem(dat));

            string Format(string token, string description = null, string proxy = null)
            {
                string sProxy = proxy == null || proxy == "Proxy" ? "null" : proxy;
                return $"[Token:{token}:Description:{description}:Proxy:{sProxy}]";
            }
        }

        private void ellipseButton3_Click(object sender, EventArgs e) // удалить
        {
            int i = 0;

            foreach (ListViewItem items in listView1.SelectedItems)
            {
                foreach (string str in File.ReadAllLines(Application.StartupPath.ToString() + @"\MultiAcc.txt"))
                {
                    listView1.Items.Remove(items);
                    if (str.Contains(items.Text))
                    {
                        ++i;
                        ls.Remove(str);
                    }
                }
            }
            if (i > 0)
            {
                File.Delete(Application.StartupPath.ToString() + @"\MultiAcc.txt");
                File.AppendAllLines(Application.StartupPath.ToString() + @"\MultiAcc.txt", ls);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle);
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }
        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
        }
        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = string.Empty;
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem items in listView1.SelectedItems)
            {
                if (UserData.OldToken == null || UserData.OldToken == String.Empty)
                {
                    UserData.OldToken = UserData.Token;
                    listView1.Items.Add(new ListViewItem(new string[] { UserData.Token, "Main Token" }));
                }
                UserData.Token = items.Text;
            }
        }
    }
}
