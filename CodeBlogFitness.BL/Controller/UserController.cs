using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CodeBlogFitness.BL.Controller
{

    /// <summary>
    /// Контролер користувача.
    /// </summary>
    public class UserController: ControllerBase
    {
        private const string USERS_FILE_NAME = "users.dat";

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

           return Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();                               
            
        }


        /// <summary>
        /// Доповнення даних нового користувача.
        /// </summary>
        /// <param name="genderName">Iмя.</param>
        /// <param name="birthDate">Дата народження.</param>
        /// <param name="weight">Вага.</param>
        /// <param name="height">Рiст.</param>
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
            Save(USERS_FILE_NAME, Users);
                        
        }


        
    }
}
