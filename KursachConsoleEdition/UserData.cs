using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;
namespace KursachConsoleEdition
{

    // Поток Fstream почекать
    // свич кейс, там где парам bool, когда будет несколько аргументов, ну вернее сейчас сделать бы

    public class UserData
    {
        string path = "data/";

        

        public void CreateUserData(UserModel user)
        {
            List<UserModel> us_json = ReadUsersData();
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

        private List<UserModel> ReadUsersData()
        {
           
            var read = File.ReadAllText(path + "users_data.json");
            List<UserModel> userData = JsonConvert.DeserializeObject<List<UserModel>>(read);
            
            return userData;
        }

        public void ShowAllUsersData()
        {
            List<UserModel> usersData = ReadUsersData();

           foreach (var user in usersData)
            {
                Console.WriteLine($"{user.Id},  {user.FirstName}");
            }
        }

        public void ShowSingleUserData(int id)
        {
            List<UserModel> usersData = ReadUsersData();
            
            foreach (var user in usersData)
            {
                if(user.Id == id)
                {
                    Console.WriteLine($"{user.Id},  {user.FirstName}");
                }
            }
        }

        public void DeleteSingleUserData(int id)
        {
            List<UserModel> usersData = ReadUsersData();

            for(int i = 0; i < usersData.Count; i++)
            {
                if (usersData[i].Id == id) usersData.RemoveAt(i); 
            }
            string json = JsonConvert.SerializeObject(usersData);
            File.WriteAllText(path + "users_data.json", json);
        }

        public void ChangeSingleUserData(int id, string parameter, bool secondNameOrFirst )
        {
            List<UserModel> usersData = ReadUsersData();
            
            var test = usersData.FirstOrDefault(x => x.Id == id);
            // Меняю или Имя или Фамилия
            if(secondNameOrFirst == true)
            {
                test.FirstName = parameter;
            }
            else
            {
                test.LastName = parameter;
            }

            string json = JsonConvert.SerializeObject(usersData);
            File.WriteAllText(path + "users_data.json", json);
        }


        public void ChangeSingleUserTest(int id, UserModel usModel)
        {
            List<UserModel> usersData = ReadUsersData();

            for (int i = 0; i < usersData.Count; i++)
            {
                if (usersData[i].Id == id)
                {
                    usersData[i].Id = id;
                    usersData[i].FirstName = usModel.FirstName;
                }
            }

            string json = JsonConvert.SerializeObject(usersData);
            File.WriteAllText(path + "users_data.json", json);
        }

    }
}
