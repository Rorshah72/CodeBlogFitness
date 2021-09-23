using CodeBlogFitness.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller
{

    /// <summary>
    /// Контролер користувача.
    /// </summary>
    public class UserController
    {

        /// <summary>
        /// Користувач додатку.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Створення нового користувача.
        /// </summary>
        /// <param name="user"> данi користувача</param>
        public UserController(string userName, string genderName,DateTime birthDate, double weight, double height )
        {
            //TODO: Провiрка.

            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDate, weight, height);
                
            // User = user ?? throw new ArgumentNullException("Користувач не буди рiвний нулю.", nameof(user));
        }

        /// <summary>
        /// Получити данi користувача.
        /// </summary>
        /// <returns>Користувач додатку. </returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {

                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }

                //TODO: Що робити якщо користувачане прочитали?

            }

        }

        /// <summary>
        /// Зберегти данi користувача.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }


        
    }
}
