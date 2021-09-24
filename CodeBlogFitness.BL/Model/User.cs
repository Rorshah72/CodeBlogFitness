using System;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]

    /// <summary>
    /// Користувач.
    /// </summary>
    public class User
    {
        #region Властивостi.
        /// <summary>
        /// iмя.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Стать.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Дата народження.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Вага.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Рiст.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Вiк.
        /// </summary>
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        #endregion

        /// <summary>
        /// Створити нового користувача.
        /// </summary>
        /// <param name="name"> iмя. </param>
        /// <param name="gender"> Стать .</param>
        /// <param name="birthDate"> Дата народження. </param>
        /// <param name="weight"> Вага. </param>
        /// <param name="height"> Рiст. </param>
        public User( string name, 
                     Gender gender, 
                     DateTime birthDate, 
                     double weight, 
                     double height)
        {
            #region Провiрка умов
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("iмя  користувача не може бути пустим або нулем. ", nameof(name));
            }

            if(gender == null)
            {
                throw new ArgumentNullException("Стать не може бути нулем. ", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Неможлива дата народження. ", nameof(birthDate));
            }

            if(weight <= 0)
            {
                throw new ArgumentException(" Вес не може бути меньшим або рiвним нулю.", nameof(weight) );
            }

            if(height <= 0 )
            {
                throw new ArgumentException(" Рiст не може бути меньшим або рiвним нулю.", nameof(height));
            }
            #endregion


            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("iмя  користувача не може бути пустим або нулем. ", nameof(name));
            }

            Name = name;
        }

        /// <summary>
        /// Перевизначення методу ToString.
        /// </summary>
        /// <returns>iмя користувача.</returns>
        public override string ToString()
        {
            return "Iмя:" + Name + " Вik: " + Age + " Стать: " + Gender + " Рiст: " + Height + " Вага: " + Weight;
        }

    }
}
