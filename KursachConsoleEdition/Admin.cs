using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KursachConsoleEdition
{
    internal class Admin
    {
        //new List<User> list = new List<User>();

      /*  new User user = new User() {Id = 1, FirstName = "Pupa" };

        new User user2 = new User() { Id = 2, FirstName = "Zalupa" };


        public void Users_Data()
        {
            var path = "data/";
            var read = File.ReadAllText(path + "users_data.json");
            List<User> us_json = JsonConvert.DeserializeObject<List<User>>(read);

            if (us_json == null)
            {
                List<User> _data = new List<User>();
                _data.Add(user2);
                String json = JsonConvert.SerializeObject(_data.ToArray());
                File.WriteAllText(path + "users_data.json", json);
            }
            else
            {
                us_json.Add(user);
                String json = JsonConvert.SerializeObject(us_json);
                File.WriteAllText(path + "users_data.json", json);
            }
            *//* list.Add(user);*/
            /* list.Add(user2);*/

            /*            JsonSerializer serializer = new JsonSerializer();
            */
            /* using (StreamWriter sw = new StreamWriter(@".\test.json"))
             using (JsonWriter writer = new JsonTextWriter(sw))
             {
                 serializer.Serialize(writer, list);

             }*//*
        }*/


        public void CreateUserData(UserModel user)
        {
            var path = "data/";
            var read = File.ReadAllText(path + "users_data.json");
            List<UserModel> us_json = JsonConvert.DeserializeObject<List<UserModel>>(read);

            if (us_json == null)
            {
                List<UserModel> _data = new List<UserModel>();
                _data.Add(user);
                String json = JsonConvert.SerializeObject(_data.ToArray());
                File.WriteAllText(path + "users_data.json", json);
            }
            else
            {
                us_json.Add(user);
                String json = JsonConvert.SerializeObject(us_json);
                File.WriteAllText(path + "users_data.json", json);
            }
            
        }

    }
}
