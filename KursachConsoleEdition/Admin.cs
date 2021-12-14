using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KursachConsoleEdition
{
    // Чтобы напрямую не работать с userdata, admin будет посредником
    public class Admin : UserData
    {
        
        //UserData userData = new UserData();
        public void ShowUsersData()
        {
            var data = ReadUsersData();
            
            foreach (var item in data)
            {
                Console.WriteLine($"{item.Id}, {item.FirstName}, {item.LastName}, {item.Address}, {item.Phone}, {item.CreatedDate}");
            }
        }



        public bool ShowSingleUserData(int id)
        {
            List<UserModel> usersData = ReadUsersData();
            bool check = false;

            var userById = usersData.FirstOrDefault(x => x.Id == id);

            if(userById != null)
             {
                Console.WriteLine($"{userById.Id}, {userById.FirstName}, {userById.LastName}," +
                                $" {userById.Address}, {userById.Phone}, {userById.CreatedDate}");
                return check = true;
            }
               else
                {
                    Console.WriteLine("Пользователь не найден");
                    return check;
                }
        }

        public bool DeleteSingleUserData(int id)
        {
            List<UserModel> usersData = ReadUsersData();
            bool check = false;

            var userById = usersData.FirstOrDefault(x => x.Id == id);
            if (userById != null)
            {
                usersData.Remove(userById);
                ConvertToJson(usersData);
                return check = true;
            }
            else
            {
                Console.WriteLine("Введено пустое значение");
                return check;
            }
        }


        public void ChangeSingleUserData(int id, string parameter, int whatChange)
        {
            List<UserModel> usersData = ReadUsersData();

            var userById = usersData.FirstOrDefault(x => x.Id == id);
            // Меняю или Имя или Фамилия
            switch (whatChange)
            {
                case 1:
                    userById.FirstName = parameter;
                    break;
                case 2:
                    userById.LastName = parameter;
                    break;
                case 3:
                    userById.Address = parameter;
                    break;
                case 4:
                    userById.Phone = parameter;
                    break;
                default:
                    Console.WriteLine("Выбрано неверное значение");
                    break;
            }
           ConvertToJson(usersData);
        }



    }
}
