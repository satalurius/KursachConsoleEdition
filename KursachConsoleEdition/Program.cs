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

            Menu();

            void Menu()
            {
                Admin admin = new Admin();



                Console.WriteLine("Выберите действие");
                Console.WriteLine("1 - просмотр пользователей");
                Console.WriteLine("2 - просмотр одного пользователя");
                Console.WriteLine("3 - изменить данные пользователя");
                Console.WriteLine("4 - удалить пользователя");
                var item = Convert.ToInt32(Console.ReadLine());
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
                                checkId = admin.ShowSingleUserData(id);
                            }
                        }
                        var change = WhatToChangeInUser();

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
                    default:
                        break;

                }
            }

            int WhatToChangeInUser()
            {
                Console.WriteLine("Выберите, что изменить");
                Console.WriteLine("1 - Имя");
                Console.WriteLine("2 - Фамилия");
                Console.WriteLine("3 - Адрес");
                Console.WriteLine("4 - Номер телефона");
                int change = Convert.ToInt32(Console.ReadLine());
                return change;
            }
       
        }
    }
}
