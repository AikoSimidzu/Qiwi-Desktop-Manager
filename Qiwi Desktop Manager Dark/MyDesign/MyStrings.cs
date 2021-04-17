using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDesign
{
    class MyStrings
    {
        public static string MFolder = Application.StartupPath.ToString() + @"\";
        public static string MHash = MFolder + "Hash.txt";
        public static string AutoLogin = MFolder + "Auto Login.txt";
        public static string checks = MFolder + "Tickets.txt";
        public static string PList = MFolder + @"\Proxy.txt";
    }
}
