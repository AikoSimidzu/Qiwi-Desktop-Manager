﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qiwi_Desktop_Manager
{
    class MyStrings
    {
        public static string MFolder = Application.StartupPath.ToString() + @"\";
        public static string MHash = MFolder + "Hash.txt";
        public static string AutoLogin = MFolder + "Auto Login.txt";
        public static string checks = MFolder + "Чеки.txt";
    }
}
