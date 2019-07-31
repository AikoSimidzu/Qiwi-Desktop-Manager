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
            Console.WriteLine("3. Перевод денег на карту");
            Console.WriteLine("4. Получить чеки");
            Console.WriteLine("5. Сохранить чеки");
            Console.WriteLine("6. Выйти");
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
                    SendCC();
                    Open();
                    break;

                case "4":
                    Set();
                    Open();
                    break;

                case "5":
                    Save();
                    Open();
                    break;

                case "6":
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

        static void SendCC()
        {
            Console.WriteLine("Выберите тип карты:");
            Console.WriteLine("1. MasterCard (СНГ) \n2. Visa (СНГ) \n3. Мир \n4. Visa \n5. MasterCard \n6. Вирт. QIWI");
            string CT = Console.ReadLine();

            string id = "";
            if (CT == "4")
            {
                id = "1963";
            }
            else
            {
                if (CT == "5")
                {
                    id = "21013";
                }
                else
                {
                    if (CT == "6")
                    {
                        id = "22351";
                    }
                    else
                    {
                        if (CT == "2")
                        {
                            id = "1960";
                        }
                        else
                        {
                            if (CT == "1")
                            {
                                id = "21012";
                            }
                            else
                            {
                                if (CT == "3")
                                {
                                    id = "31652";
                                }
                                else
                                {
                                    MessageBox.Show("Тип карты не выбран!");
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Введите номер карты: ");
            string cc = Console.ReadLine();

            Console.WriteLine("Введите сумму: ");
            string sum = Console.ReadLine();

            SendMoney.CC(id, cc, sum);

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
