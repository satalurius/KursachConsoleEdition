using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KursachConsoleEdition
{
    internal class Menu
    {
        public void LoginMenu(int role)
        {
            bool checkLogin = false;

            Login login = new Login();
            while (!checkLogin)
            {
                if (!checkLogin)
                {

                    Console.WriteLine("Введите логин");
                    var login_console = Console.ReadLine();
                    Console.WriteLine("Введите пароль");
                    var password = Console.ReadLine();

                    if(role == 1)
                    {
                        checkLogin = login.CheckCorrectUserData(login_console, password);
                    }
                    else
                    {
                        checkLogin = login.CheckCorrectAdminData(login_console, password);
                    }

                }
            }
        }
        public void MenuMethod()
        {
            Admin admin = new Admin();
            bool checkExit = false;


            while (!checkExit)
            {
                Console.WriteLine("\nВыберите действие");
                Console.WriteLine("1 - просмотр пользователей");
                Console.WriteLine("2 - просмотр одного пользователя");
                Console.WriteLine("3 - изменить данные пользователя");
                Console.WriteLine("4 - удалить пользователя");
                Console.WriteLine("5 - добавить пользователя");
                Console.WriteLine("6 - выход");

                var item = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");

                switch (item)
                {
                    case 1:
                        admin.ShowUsersData();
                        break;
                    case 2:
                        bool checkId = false;
                        while (!checkId)
                        {
                            if (!checkId)
                            {
                                Console.WriteLine("Введите id пользователя");
                                int id = Convert.ToInt32(Console.ReadLine());
                                checkId = admin.ShowSingleUserData(id);
                            }
                        }
                        break;
                    case 3:
                        checkId = false;
                        while (!checkId)
                        {
                            if (!checkId)
                            {
                                Console.WriteLine("Введите id пользователя");
                                int id = Convert.ToInt32(Console.ReadLine());
                                var userId = admin.CheckUser(id);
                                if (userId != null)
                                {
                                    checkId = true;
                                }
                                var change = WhatToChangeInUser();
                                Console.WriteLine("Введите значение: ");
                                var textChange = Console.ReadLine();
                                admin.ChangeSingleUserData(id, change, textChange);
                            }
                        }
                        break;
                    case 4:
                        checkId = false;
                        while (!checkId)
                        {
                            if (!checkId)
                            {
                                Console.WriteLine("Введите id пользователя");
                                int id = Convert.ToInt32(Console.ReadLine());
                                checkId = admin.DeleteSingleUserData(id);
                            }
                        }
                        break;
                    case 5:
                        var data = InputToCreateUser();
                        admin.CreateUser(data[0], data[1], data[2], data[3]);
                        break;
                    case 6:
                    default:
                        checkExit = true;
                        break;
                }
            }
        }

        int WhatToChangeInUser()
        {
            Console.WriteLine("Выберите, что изменить");
            Console.WriteLine("1 - Имя");
            Console.WriteLine("2 - Фамилия");
            Console.WriteLine("3 - Адрес");
            Console.WriteLine("4 - Номер телефона (8)");
            int change = Convert.ToInt32(Console.ReadLine());
            return change;
        }

        string[] InputToCreateUser()
        {
            string[] data = new string[4];
            Console.WriteLine("Имя: ");
            data[0] = Console.ReadLine();
            Console.WriteLine("Фамилия: ");
            data[1] = Console.ReadLine();
            Console.WriteLine("Адрес: ");
            data[2] = Console.ReadLine();

            bool checkNumber = false;

            while (!checkNumber)
            {
                Console.WriteLine("Номер телефона: ");
                data[3] = Console.ReadLine();

                if (!Regex.IsMatch(data[3], @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$"))
                {
                    Console.WriteLine("Неправильно введен номер");
                    Console.WriteLine("Повторите попытку");
                    data[3] = Console.ReadLine();
                }
                else
                    checkNumber = true;
            }

            return data;
        }

    }
}
