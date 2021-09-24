using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller
{

    /// <summary>
    /// Контролер користувача.
    /// </summary>
    public class UserController
    {

        /// <summary>
        /// Список користовачiв додатку.
        /// </summary>
        public List<User> Users { get; }

        /// <summary>
        /// Авторизованний користувач.
        /// </summary>
        public User CurrentUser { get; }

        /// <summary>
        /// Перевiрка на нового користувача.
        /// </summary>
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Створення нового користувача.
        /// </summary>
        /// <param name="user"> данi користувача</param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Iмя користувача не може бути пустим. ", nameof(userName));
            }

            Users =  GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
           
        }

        /// <summary>
        /// Получити збережений список користувачiв.
        /// </summary>
        /// <returns>Список користувасiв. </returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {

                if (formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }


        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            //TODO: Proverka

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;

            Save();

        }

        /// <summary>
        /// Зберегти данi користувача.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }


        
    }
}
