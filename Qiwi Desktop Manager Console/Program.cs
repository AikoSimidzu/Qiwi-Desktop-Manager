using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLib;
using xNet;

namespace Qiwi_Desktop_Manager_Console
{
    class Program
    {             
        static void Main(string[] args)
        {
            Console.Title = "Qiwi Desktop Manager";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Official page: https://github.com/AikoSimidzu/Qiwi-Desktop-Manager");
            Console.ForegroundColor = ConsoleColor.White;

            AutoLogin.Auth();
            if (AutoLogin.Status == "OK")
            {
                AutoLoginAuth.INF();
            }
            else
            {
                Console.WriteLine("\nСохранить токен?");
                Console.WriteLine("1. Да");
                Console.WriteLine("2. Нет");

                string g = Console.ReadLine();

                switch (g)
                {
                    case "1":
                        loginS();                        
                        break;

                    case "2":
                        login();                        
                        break;
                }
                
            }

            while (Console.ReadLine() != "exit")
            {
                
            }
        }

        static void login()
        {
            string tok = MyStrings.token;
            Console.WriteLine("Введите токен: ");
            tok = Console.ReadLine();
            Auth.Login();
        }

        static void loginS()
        {
            Console.WriteLine("Введите токен: ");
            MyStrings.token = Console.ReadLine();  
            
            string hash = Helper.Hash(MyStrings.token);
            File.WriteAllText(MyStrings.MHash, hash);
            File.WriteAllText(MyStrings.AutoLogin, "Yes");
            Auth.Login();
        }
    }
}
