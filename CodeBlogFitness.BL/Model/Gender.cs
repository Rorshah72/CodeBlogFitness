using System;
using System.Collections.Generic;ks;

namespace CodeBlogFitness.BL.Model
{

    /// <summary>
    /// Стать.
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Назва.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Створити нову стать.
        /// </summary>
        /// <param name="name">Назва статі.</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Імя статі не може бути пустим або нуль", nameof(name));
            }

            Name = name;
        }
        /// <summary>
        /// Перевизначення методу ToString.
        /// </summary>
        /// <returns>Назву статі</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
