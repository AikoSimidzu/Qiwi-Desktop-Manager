using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qiwi_Desktop_Manager_Console
{
    class MyStrings
    {
        public static string token = ""; //Токен
        public static string PNum = ""; //Свой номер счета
        public static string balance = ""; //Баланс
        public static string transp = ""; //Номер счета для отправки

        public static string MFolder = Application.StartupPath.ToString() + @"\";
        public static string MHash = MFolder + "Hash.txt";
        public static string AutoLogin = MFolder + "Auto Login.txt";
        public static string checks = MFolder + "Чеки.txt";
        public static string PList = MFolder + @"\Proxy.txt";
    }
}
