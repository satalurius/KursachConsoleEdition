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
            Console.WriteLine("Выберите роль");
            Console.WriteLine("1 - Пользователь");
            Console.WriteLine("2 - Администратор");
            int role = Convert.ToInt32(Console.ReadLine());

            Menu menu = new Menu();
            menu.LoginMenu(role);
            menu.MenuMethod();

        }
    }
}
