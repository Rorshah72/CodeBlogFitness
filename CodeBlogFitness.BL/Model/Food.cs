using System;


namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class Food
    {
        #region
        /// <summary>
        /// Назва продукту.
        /// </summary>
        public string Name{ get; }

        /// <summary>
        /// Бiлки за  грам продукту.
        /// </summary>
        public double Proteins  { get; }

        /// <summary>
        /// Жири за  грам продукту.
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Вуглеводи за  грам продукту.
        /// </summary>
        public double Carbohydrates { get; }
        

        /// <summary>
        /// Калорiї за  грам продукта .
        /// </summary>
        public double Callories { get; }

        #endregion

        public Food(string name): this(name, 0, 0, 0, 0){ }

        /// <summary>
        /// Добавлення продукту до каталогу.
        /// </summary>
        /// <param name="name">Імя продукту.</param>
        /// <param name="proteins">Білки.</param>
        /// <param name="fats">Жири.</param>
        /// <param name="carbohydrates">Вуглеводи.</param>
        /// <param name="callories">Калорії.</param>
        public Food(string name, double proteins, double fats, double carbohydrates, double callories)
        {
            //TODO : провірка
            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats /100.0;
            Carbohydrates = carbohydrates / 100.0;
            Callories = callories / 100.0;
        }

        /// <summary>
        /// Перевизначення ToString для їжі.
        /// </summary>
        /// <returns>Назву продукту.</returns>
        public override string ToString()
        {
            return Name + " ";
            //return "Назва: " + Name + " Бiлки: " + Proteins + " Жири: " + Fats + " Вуглеводи: " + Carbohydrates + " Калорiї: " + Callories + "  ";
        }
    }
}
