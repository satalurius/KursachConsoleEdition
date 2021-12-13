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
            //user.Id = 2;
            //user.FirstName = "Бельчич";

            UserData userData = new UserData();
            //userData.CreateUserData(user); 

            //userData.ChangeSingleUserData(2, "Шмельчич");
            //userData.DeleteSingleUserData(1);
            //userData.ShowSingleUserData(1);
            
            userData.ChangeSingleUserData(1, "Бельчич крутой", false);
            userData.ShowAllUsersData();
        }
    }
}
