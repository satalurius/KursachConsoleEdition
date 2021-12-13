using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace KursachConsoleEdition
{
    public class UserData
    {
        public List<UserModel> ReadUserData()
        {
            var path = "data/";
            var read = File.ReadAllText(path + "users_data.json");
            List<UserModel> userData = JsonConvert.DeserializeObject<List<UserModel>>(read);
            
            return userData;
        }
    }
}
