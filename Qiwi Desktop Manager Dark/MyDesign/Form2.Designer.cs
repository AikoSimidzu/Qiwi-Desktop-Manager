namespace MyDesign
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.lvl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.balance = new System.Windows.Forms.Label();
            this.PNum = new System.Windows.Forms.Label();
            this.Mail = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.Comment = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Sum = new System.Windows.Forms.TextBox();
            this.CSum = new System.Windows.Forms.TextBox();
            this.Card = new System.Windows.Forms.TextBox();
            this.Wallet = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ellipseButton3 = new MyDesign.EllipseButton();
            this.SaveTicket = new MyDesign.EllipseButton();
            this.GetTicket = new MyDesign.EllipseButton();
            this.ellipseButton2 = new MyDesign.EllipseButton();
            this.ellipseButton1 = new MyDesign.EllipseButton();
            this.panel1.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(23)))), ((int)(((byte)(32)))));
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 10);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_Paint);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(429, -9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 25);
            this.label7.TabIndex = 1;
            this.label7.Text = "-";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(448, -4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "X";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Location = new System.Drawing.Point(12, 16);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(440, 182);
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Red;
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabControl1.UseSelectable = true;
            this.metroTabControl1.UseStyleColors = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.metroTabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.metroTabPage1.Controls.Add(this.ellipseButton3);
            this.metroTabPage1.Controls.Add(this.SaveTicket);
            this.metroTabPage1.Controls.Add(this.GetTicket);
            this.metroTabPage1.Controls.Add(this.label5);
            this.metroTabPage1.Controls.Add(this.lvl);
            this.metroTabPage1.Controls.Add(this.label4);
            this.metroTabPage1.Controls.Add(this.label3);
            this.metroTabPage1.Controls.Add(this.label2);
            this.metroTabPage1.Controls.Add(this.balance);
            this.metroTabPage1.Controls.Add(this.PNum);
            this.metroTabPage1.Controls.Add(this.Mail);
            this.metroTabPage1.Controls.Add(this.label1);
            this.metroTabPage1.ForeColor = System.Drawing.SystemColors.Control;
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(432, 140);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Информация";
            this.metroTabPage1.UseCustomBackColor = true;
            this.metroTabPage1.UseStyleColors = true;
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "История платежей:";
            // 
            // lvl
            // 
            this.lvl.AutoSize = true;
            this.lvl.Location = new System.Drawing.Point(138, 81);
            this.lvl.Name = "lvl";
            this.lvl.Size = new System.Drawing.Size(10, 13);
            this.lvl.TabIndex = 3;
            this.lvl.Text = " ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Уровень идентификации:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Баланс:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Номер телефона:";
            // 
            // balance
            // 
            this.balance.AutoSize = true;
            this.balance.Location = new System.Drawing.Point(56, 58);
            this.balance.Name = "balance";
            this.balance.Size = new System.Drawing.Size(10, 13);
            this.balance.TabIndex = 3;
            this.balance.Text = " ";
            // 
            // PNum
            // 
            this.PNum.AutoSize = true;
            this.PNum.Location = new System.Drawing.Point(98, 35);
            this.PNum.Name = "PNum";
            this.PNum.Size = new System.Drawing.Size(10, 13);
            this.PNum.TabIndex = 3;
            this.PNum.Text = " ";
            // 
            // Mail
            // 
            this.Mail.AutoSize = true;
            this.Mail.Location = new System.Drawing.Point(85, 10);
            this.Mail.Name = "Mail";
            this.Mail.Size = new System.Drawing.Size(10, 13);
            this.Mail.TabIndex = 3;
            this.Mail.Text = " ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Адресс почты:";
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.metroTabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.metroTabPage2.Controls.Add(this.ellipseButton2);
            this.metroTabPage2.Controls.Add(this.ellipseButton1);
            this.metroTabPage2.Controls.Add(this.label8);
            this.metroTabPage2.Controls.Add(this.Comment);
            this.metroTabPage2.Controls.Add(this.comboBox1);
            this.metroTabPage2.Controls.Add(this.panel7);
            this.metroTabPage2.Controls.Add(this.panel6);
            this.metroTabPage2.Controls.Add(this.panel5);
            this.metroTabPage2.Controls.Add(this.panel4);
            this.metroTabPage2.Controls.Add(this.panel3);
            this.metroTabPage2.Controls.Add(this.Sum);
            this.metroTabPage2.Controls.Add(this.CSum);
            this.metroTabPage2.Controls.Add(this.Card);
            this.metroTabPage2.Controls.Add(this.Wallet);
            this.metroTabPage2.Controls.Add(this.label12);
            this.metroTabPage2.Controls.Add(this.label11);
            this.metroTabPage2.Controls.Add(this.label16);
            this.metroTabPage2.Controls.Add(this.label15);
            this.metroTabPage2.Controls.Add(this.label14);
            this.metroTabPage2.Controls.Add(this.label13);
            this.metroTabPage2.Controls.Add(this.label10);
            this.metroTabPage2.ForeColor = System.Drawing.SystemColors.Control;
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(432, 140);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Перевод денег";
            this.metroTabPage2.UseCustomBackColor = true;
            this.metroTabPage2.UseStyleColors = true;
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Комментарий:";
            // 
            // Comment
            // 
            this.Comment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Comment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Comment.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Comment.Location = new System.Drawing.Point(89, 75);
            this.Comment.Name = "Comment";
            this.Comment.Size = new System.Drawing.Size(100, 13);
            this.Comment.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(292, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel7.Location = new System.Drawing.Point(89, 90);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(100, 1);
            this.panel7.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel6.Location = new System.Drawing.Point(54, 67);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(100, 1);
            this.panel6.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel5.Location = new System.Drawing.Point(273, 90);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(125, 1);
            this.panel5.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel4.Location = new System.Drawing.Point(304, 64);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(100, 1);
            this.panel4.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3.Location = new System.Drawing.Point(85, 42);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(100, 1);
            this.panel3.TabIndex = 2;
            // 
            // Sum
            // 
            this.Sum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Sum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Sum.ForeColor = System.Drawing.SystemColors.Control;
            this.Sum.Location = new System.Drawing.Point(54, 52);
            this.Sum.Name = "Sum";
            this.Sum.Size = new System.Drawing.Size(100, 13);
            this.Sum.TabIndex = 3;
            // 
            // CSum
            // 
            this.CSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.CSum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CSum.ForeColor = System.Drawing.SystemColors.Control;
            this.CSum.Location = new System.Drawing.Point(273, 75);
            this.CSum.Name = "CSum";
            this.CSum.Size = new System.Drawing.Size(125, 13);
            this.CSum.TabIndex = 3;
            // 
            // Card
            // 
            this.Card.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Card.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Card.ForeColor = System.Drawing.SystemColors.Control;
            this.Card.Location = new System.Drawing.Point(304, 49);
            this.Card.Name = "Card";
            this.Card.Size = new System.Drawing.Size(125, 13);
            this.Card.TabIndex = 3;
            // 
            // Wallet
            // 
            this.Wallet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Wallet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Wallet.ForeColor = System.Drawing.SystemColors.Control;
            this.Wallet.Location = new System.Drawing.Point(85, 27);
            this.Wallet.Name = "Wallet";
            this.Wallet.Size = new System.Drawing.Size(100, 13);
            this.Wallet.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Сумма:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Номер счета:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(223, 78);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Сумма:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(223, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "Номер карты:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(223, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Тип карты:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(223, 4);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Перевод на карту:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label10.Location = new System.Drawing.Point(4, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Перевод на счет киви:";
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.metroTabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.metroTabPage3.Controls.Add(this.richTextBox1);
            this.metroTabPage3.ForeColor = System.Drawing.SystemColors.Control;
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(432, 140);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Логи";
            this.metroTabPage3.UseCustomBackColor = true;
            this.metroTabPage3.UseStyleColors = true;
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.Location = new System.Drawing.Point(4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(425, 133);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Location = new System.Drawing.Point(12, 204);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(440, 1);
            this.panel2.TabIndex = 2;
            // 
            // ellipseButton3
            // 
            this.ellipseButton3.Location = new System.Drawing.Point(226, 92);
            this.ellipseButton3.Name = "ellipseButton3";
            this.ellipseButton3.Size = new System.Drawing.Size(127, 25);
            this.ellipseButton3.TabIndex = 8;
            this.ellipseButton3.Text = "Сохранить логи";
            this.ellipseButton3.Click += new System.EventHandler(this.ellipseButton3_Click);
            // 
            // SaveTicket
            // 
            this.SaveTicket.Location = new System.Drawing.Point(226, 61);
            this.SaveTicket.Name = "SaveTicket";
            this.SaveTicket.Size = new System.Drawing.Size(127, 25);
            this.SaveTicket.TabIndex = 7;
            this.SaveTicket.Text = "Сохранить чеки";
            this.SaveTicket.Click += new System.EventHandler(this.SaveTicket_Click);
            // 
            // GetTicket
            // 
            this.GetTicket.ForeColor = System.Drawing.Color.White;
            this.GetTicket.Location = new System.Drawing.Point(226, 30);
            this.GetTicket.Name = "GetTicket";
            this.GetTicket.Size = new System.Drawing.Size(127, 25);
            this.GetTicket.TabIndex = 6;
            this.GetTicket.Text = "Получить чеки";
            this.GetTicket.Click += new System.EventHandler(this.GetTicket_Click);
            // 
            // ellipseButton2
            // 
            this.ellipseButton2.ForeColor = System.Drawing.Color.White;
            this.ellipseButton2.Location = new System.Drawing.Point(226, 97);
            this.ellipseButton2.Name = "ellipseButton2";
            this.ellipseButton2.Size = new System.Drawing.Size(178, 23);
            this.ellipseButton2.TabIndex = 9;
            this.ellipseButton2.Text = "Перевести";
            this.ellipseButton2.Click += new System.EventHandler(this.ellipseButton2_Click);
            // 
            // ellipseButton1
            // 
            this.ellipseButton1.ForeColor = System.Drawing.Color.White;
            this.ellipseButton1.Location = new System.Drawing.Point(7, 97);
            this.ellipseButton1.Name = "ellipseButton1";
            this.ellipseButton1.Size = new System.Drawing.Size(178, 23);
            this.ellipseButton1.TabIndex = 8;
            this.ellipseButton1.Text = "Перевести";
            this.ellipseButton1.Click += new System.EventHandler(this.ellipseButton1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(464, 217);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Qiwi Desktop Manager";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.metroTabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lvl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label balance;
        private System.Windows.Forms.Label PNum;
        private System.Windows.Forms.Label Mail;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private System.Windows.Forms.TextBox Sum;
        private System.Windows.Forms.TextBox Wallet;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox CSum;
        private System.Windows.Forms.TextBox Card;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Comment;
        private System.Windows.Forms.Panel panel7;
        private EllipseButton SaveTicket;
        private EllipseButton GetTicket;
        private EllipseButton ellipseButton1;
        private EllipseButton ellipseButton2;
        private EllipseButton ellipseButton3;
    }
}