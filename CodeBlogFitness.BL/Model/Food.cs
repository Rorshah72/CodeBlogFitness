using System;


namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class Food
    {
        #region Властивості
        public int Id { get; set; }

        /// <summary>
        /// Назва продукту.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Бiлки за  грам продукту.
        /// </summary>
        public double Proteins { get; set; }

        /// <summary>
        /// Жири за  грам продукту.
        /// </summary>
        public double Fats { get; set; }

        /// <summary>
        /// Вуглеводи за  грам продукту.
        /// </summary>
        public double Carbohydrates { get; set; }


        /// <summary>
        /// Калорiї за  грам продукта .
        /// </summary>
        public double Callories { get; set; }

        #endregion

        public Food() { }

        public Food(string name) : this(name, 0, 0, 0, 0) { }

        /// <summary>
        /// Добавлення продукту до каталогу.
        /// </summary>
        /// <param name="name">iмя продукту.</param>
        /// <param name="proteins">Бiлки.</param>
        /// <param name="fats">Жири.</param>
        /// <param name="carbohydrates">Вуглеводи.</param>
        /// <param name="callories">Калорiї.</param>
        public Food(string name, double proteins, double fats, double carbohydrates, double callories)
        {
            //TODO : провiрка
            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Callories = callories / 100.0;
        }

        /// <summary>
        /// Перевизначення ToString для їжi.
        /// </summary>
        /// <returns>Назву продукту.</returns>
        public override string ToString()
        {
            return Name + " ";
            //return "Назва: " + Name + " Бiлки: " + Proteins + " Жири: " + Fats + " Вуглеводи: " + Carbohydrates + " Калорiї: " + Callories + "  ";
        }
    }
}
