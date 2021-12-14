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
            //Console.WriteLine("Выберите роль");
            //Console.WriteLine("Администратор");
            //Console.WriteLine("Пользователь");

            Menu menu = new Menu();
            menu.LoginMenu();
            menu.MenuMethod();

        }
    }
}
