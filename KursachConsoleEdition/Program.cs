using System;
using System.IO;

namespace KursachConsoleEdition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            DirectoryInfo dirInfo = new DirectoryInfo("data/");
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            //File.Create(dirInfo + "users_data.json");
            UserModel user = new UserModel();
            /*user.Id = 1;
            user.FirstName = "Пупка";
            user.LastName = "Залупка";
            user.Phone = "987654321";
            */
                

            UserData userData = new UserData();
            //userData.CreateUserData(user); 

            //userData.ChangeSingleUserData(2, "Поспать", false);
            //userData.DeleteSingleUserData(1);
            //userData.ShowSingleUserData(1);

            //userData.ChangeSingleUserData(1, "Бельчич крутой", false);
            //userData.ShowAllUsersData();

            //Admin admin = new Admin();
            //admin.CreateUser("четвертый юзер", "pipez", "rksi", "1488999");
            Menu();

            void Menu()
            {
                Admin admin = new Admin();
                bool checkExit = false;

                
                while(!checkExit)
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
                Console.WriteLine("4 - Номер телефона");
                Console.WriteLine("5 - Номер телефона");
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
                Console.WriteLine("Номер телефона: ");
                data[3] = Console.ReadLine();
                return data;
            }
            
        }
    }
}
