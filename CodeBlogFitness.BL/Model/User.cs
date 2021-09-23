using System;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Користувач.
    /// </summary>
    public class User
    {
        #region Властивості.
        /// <summary>
        /// Імя.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Стать.
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// Дата народження.
        /// </summary>
        public DateTime BirthDate { get; }

        /// <summary>
        /// Вага.
        /// </summary>
        public double Weigth { get; set; }

        /// <summary>
        /// Ріст.
        /// </summary>
        public double Heigth { get; set; }
        #endregion

        /// <summary>
        /// Створити нового користувача.
        /// </summary>
        /// <param name="name"> Імя. </param>
        /// <param name="gender"> Стать .</param>
        /// <param name="birthDate"> Дата народження. </param>
        /// <param name="weigth"> Вага. </param>
        /// <param name="heigth"> Ріст. </param>
        public User( string name, 
                     Gender gender, 
                     DateTime birthDate, 
                     double weigth, 
                     double heigth)
        {
            #region Провірка умов
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Імя  користувача не може бути пустим або нулем. ", nameof(name));
            }

            if(gender == null)
            {
                throw new ArgumentNullException("Стать не може бути нулем. ", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Неможлива дата народження. ", nameof(birthDate));
            }

            if(weigth <= 0)
            {
                throw new ArgumentException(" Вес не може бути меньшим або рівним нулю.", nameof(weigth) );
            }

            if(heigth <= 0 )
            {
                throw new ArgumentException(" Ріст не може бути меньшим або рівним нулю.", nameof(heigth));
            }
            #endregion


            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weigth = weigth;
            Heigth = heigth;
        }

        /// <summary>
        /// Перевизначення методу ToString.
        /// </summary>
        /// <returns>Імя користувача.</returns>
        public override string ToString()
        {
            return Name;
        }

    }
}
