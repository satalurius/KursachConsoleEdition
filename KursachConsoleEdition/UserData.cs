using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KursachConsoleEdition
{
    public class UserData
    {
        string path = "data/";

        protected virtual void CreateUserData(UserModel user)
        {
            List<UserModel> us_json = ReadUsersData();
            if (us_json == null)
            {
                List<UserModel> _data = new List<UserModel>();
                _data.Add(user);
                string json = JsonConvert.SerializeObject(_data.ToArray());
                File.WriteAllText(path + "users_data.json", json);
            }
            else
            {
                us_json.Add(user);
                string json = JsonConvert.SerializeObject(us_json);
                File.WriteAllText(path + "users_data.json", json);
            }

        }

        protected List<UserModel> ReadUsersData()
        {
           
            var read = File.ReadAllText(path + "users_data.json");
            List<UserModel> userData = JsonConvert.DeserializeObject<List<UserModel>>(read);
            
            return userData;
        }

        protected void ConvertToJson(List<UserModel> userData)
        {
            string json = JsonConvert.SerializeObject(userData);
            File.WriteAllText(path + "users_data.json", json);
        }
    }
}
