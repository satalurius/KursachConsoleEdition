using System;
using System.IO;


namespace KursachConsoleEdition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dirInfo = new DirectoryInfo("data/");
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            string existUserData = "data/users_data.json";
            string existAdmin = "data/admin_login.json";
            string dataForLogin = "checkForData.txt";

            //Создание json для юзера
            CreateDefaultTextFile(existUserData, "[]");

            //Создание json для админа 
            CreateDefaultTextFile(existAdmin, "[{\"login\": \"admin1\", \"password\": \"passw0rd\"}, {\"login\": \"admin2\", \"password\": \"parol\"}]");

            CreateDefaultTextFile(dataForLogin, "Данные для первого админа: admin1 passw0rd. \n Для второго: admin2 parol");

            Console.WriteLine("Данные для входа хранятся файле checkfordata (^.^)/");
            Menu menu = new Menu();
            menu.LoginMenu();
            menu.AdminMenu();

            void CreateDefaultTextFile(string filePath, string text)
            {
                if (!File.Exists(filePath))
                {
                    using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
                    {
                        byte[] array = System.Text.Encoding.Default.GetBytes(text);
                        fileStream.Write(array, 0, array.Length);
                    }
                }

            }
        }
    }
}
