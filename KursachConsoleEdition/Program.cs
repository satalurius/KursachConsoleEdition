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
            userData.ShowAllUsersData();
        }
    }
}
