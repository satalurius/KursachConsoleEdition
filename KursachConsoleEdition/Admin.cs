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
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
                Console.WriteLine($" {item.Id} | {item.FirstName} | {item.LastName} | {item.Address} | {item.Phone} | {item.Tariff} | {item.CreatedDate} | ");
            }
        }


        public UserModel CheckUser(int id)
        {
            List<UserModel> usersData = ReadUsersData();
            var userById = usersData.FirstOrDefault(x => x.Id == id);
            if(userById != null)
            {
                return userById;
            }
            return null;
        }


        public bool ShowSingleUserData(int id)
        {
          
            bool check = false;

            var userById = CheckUser(id);

            if (userById != null)
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
            var userById = CheckUser(id);
            bool check = false;



            if (userById != null)
            {
                usersData.Remove(usersData.FirstOrDefault(x => x.Id == id));

                ConvertToJson(usersData);

                check = true;
                return check;
            }
            else
            {
                Console.WriteLine("Введено пустое значение");
                return check;
            }
        }


        public void ChangeSingleUserData(int id, int whatChange, string parameter)
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

        public void CreateUser(string firstName, string lastName, string address, string phone, int tariffType)
        {
            UserModel user = new UserModel();

            List<UserModel> usersData = ReadUsersData();
            var usersCount = usersData.Count;
            if(usersCount == 0)
            {
                user.Id = 1;
            }
            else
            {
            var userById = usersData.Last();
            user.Id = userById.Id + 1;
            }
            string tariff = "";

            switch(tariffType)
            {
                case 1:
                    tariff = "Семейная близость";
                    break;
                case 2:
                    tariff = "Единоличник";
                    break;
                case 3:
                    tariff = "Вседоступный";
                    break;
            }


            user.FirstName = firstName;
            user.LastName = lastName;
            user.Address = address;
            user.Phone = phone;
            user.Tariff = tariff;
            user.CreatedDate = DateTime.Now;
            CreateUserData(user);
        }


    }
}
