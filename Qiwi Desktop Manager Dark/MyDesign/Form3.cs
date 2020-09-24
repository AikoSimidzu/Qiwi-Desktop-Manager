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
                    ls.Add(str);
                    string tok = Helper.Pars(str, "Token:", ":");
                    string descr = Helper.Pars(str, "Description:", "]");

                    string[] dat = { tok, descr};
                    listView1.Items.Add(new ListViewItem(dat));
                }
            }
        }

        private void ellipseButton1_Click(object sender, EventArgs e) // вход
        {
            foreach (ListViewItem items in listView1.SelectedItems)
            {
                if (File.Exists(MyStrings.AutoLogin))
                {
                    string ppr = File.ReadAllText(MyStrings.AutoLogin);
                    if (ppr == "Yes")
                    {
                        string hash = Helper.Hash(items.Text);

                        File.WriteAllText(MyStrings.MHash, hash);
                    }
                    else
                    {
                        Form1.token = items.Text;
                    }
                }
                else
                {
                    Form1.token = items.Text;
                }                
            }
        }

        private void ellipseButton2_Click(object sender, EventArgs e) // добавить
        {
            ls.Add(Format(textBox1.Text, textBox2.Text));
            File.AppendAllText(Application.StartupPath.ToString() + @"\MultiAcc.txt", Format(textBox1.Text, textBox2.Text) + "\n"); // запись           

            string[] dat = { textBox1.Text, textBox2.Text };
            listView1.Items.Add(new ListViewItem(dat));

            string Format(string token, string description = null)
            {
                return $"[Token:{token}:Description:{description}]";
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

        public const int WM_NCLBUTTONDOWN = 0xA1, HT_CAPTION = 0x2;
        private void panel1_Paint(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
