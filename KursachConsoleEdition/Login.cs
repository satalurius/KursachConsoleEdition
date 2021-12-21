using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;


namespace KursachConsoleEdition
{
    internal class Login
    {
        string path = "data/";

        List<AdminLoginModel> GetAdminLoginData()
        {
            var read = File.ReadAllText(path + "admin_login.json");
            List<AdminLoginModel> json = JsonConvert.DeserializeObject<List<AdminLoginModel>>(read);
            return json;
        }

        public bool CheckCorrectAdminData(string login, string password)
        {

            var loginData = GetAdminLoginData();

            var loginInput = loginData.FirstOrDefault(x => x.Login == login && x.Password == password);

            if (loginInput != null)
            {
                Console.WriteLine("Успешно");
                return true;
            }
            return false;
        }
    }
}
