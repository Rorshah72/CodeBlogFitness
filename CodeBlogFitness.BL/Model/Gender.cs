using System;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]

    /// <summary>
    /// Стать.
    /// </summary>
    public class Gender
    {
        public int Id { get; set; }

        /// <summary>
        /// Назва.
        /// </summary>
        public string Name { get; set; }

        public Gender() { }

        /// <summary>
        /// Створити нову стать.
        /// </summary>
        /// <param name="name">Назва статi.</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("iмя статi не може бути пустим або нуль", nameof(name));
            }

            Name = name;
        }
        /// <summary>
        /// Перевизначення методу ToString.
        /// </summary>
        /// <returns>Назву статi</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
