using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]

    /// <summary>
    /// Вживання їди.
    /// </summary>
    public class Eating
    {
        /// <summary>
        /// Час вживання їжі.
        /// </summary>
        public DateTime Moment { get; }

        /// <summary>
        /// Список продуктів.
        /// </summary>
        public Dictionary<Food, double > Foods { get; }

        /// <summary>
        /// Користувач який вживає їжу.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Прийом їди.
        /// </summary>
        /// <param name="user">Користувач який прийня їду.</param>
        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Користувач не може бути пустим.",  nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        /// <summary>
        /// Добавлення продукту до раціону.
        /// </summary>
        /// <param name="food">Продукт.</param>
        /// <param name="weight">Вага продукту.</param>
        public void Add(Food food, double weight)
        {            
           var product =  Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if(product == null)
            {
                Foods.Add(food, weight);
            }
            else 
            {
                Foods[product] += weight;
            }
        }
    }
}
