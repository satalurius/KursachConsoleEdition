using System;
using System.IO;

namespace KursachConsoleEdition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DirectoryInfo dirInfo = new DirectoryInfo("data/");
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            //File.Create(dirInfo + "users_data.json");
            UserModel user = new UserModel();
            user.Id = 10000;
            user.FirstName = "Zalupaaaa";
            Admin admin = new Admin();
            admin.CreateUserData(user);

            UserData userData = new UserData();
            var test = userData.ReadUserData();
            foreach (var item in test)
            {
                Console.WriteLine($"{item.Id},  {item.FirstName}");
            }
  
        }
    }
}
