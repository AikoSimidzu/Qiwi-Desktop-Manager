using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qiwi_Desktop_Manager_Console
{
    class Menu
    {
        static public void Open()
        {
            Console.WriteLine("\n1. Перевод денег");
            Console.WriteLine("2. Перевод денег с комментарием");
            Console.WriteLine("3. Получить чеки");
            Console.WriteLine("4. Сохранить чеки");
            Console.WriteLine("5. Выйти");
            Console.WriteLine("Пожалуйста, выберите меню.");           

            string g = Console.ReadLine();
            
            switch (g)
            {
                case "1":
                    Send();
                    Open();
                    break;

                case "2":
                    SendC();
                    Open();
                    break;

                case "3":
                    Set();
                    Open();
                    break;

                case "4":
                    Save();
                    Open();
                    break;

                case "5":
                    Exit();
                    Open();
                    break;

                default:
                    Console.WriteLine("Данного пункта меню не существует");
                    Open();
                    break;
            }

        }

        static void Send()
        {
            Console.WriteLine("Введите номер счета: ");
            MyStrings.transp = Console.ReadLine();

            Console.WriteLine("Введите сумму: ");
            string sum = Console.ReadLine();

            SendMoney.Send(MyStrings.transp, sum);
        }

        static void SendC()
        {
            Console.WriteLine("Введите номер счета: ");
            MyStrings.transp = Console.ReadLine();

            Console.WriteLine("Введите сумму: ");
            string sum = Console.ReadLine();

            Console.WriteLine("Введите коментарий: ");
            string com = Console.ReadLine();

            SendMoney.Send(MyStrings.transp, sum, com);
        }

        static void Set()
        {
            Console.WriteLine(Tickets.Get());
        }

        static void Save()
        {
            File.WriteAllText(MyStrings.checks, Tickets.Get());
        }

        static void Exit()
        {
            Application.Exit();
        }
    }
}
