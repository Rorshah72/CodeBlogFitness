using System;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class Activity
    {
        /// <summary>
        /// Назва врпави.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Кiлькiсть калорiй якi сгорають пiд час вправи за одну хвилину.
        /// </summary>
        public double CalloriesPerMinute { get; }

        /// <summary>
        /// Створення нової вправи.
        /// </summary>
        /// <param name="name">Назва вправи.</param>
        /// <param name="calloriesPerMinute">Кiлькiсть калорiй якi сгорають пiд час вправи за одну хвилину.</param>
        public Activity(string name, double calloriesPerMinute)
        {
            //TODO: Провiрка

            Name = name;
            CalloriesPerMinute = calloriesPerMinute;
        }

        public override string ToString()
        {
            return " Назва вправи " + Name + "   Кiлькiсть калорiй якi спалюються за хвилину   " + CalloriesPerMinute + "  ";
        }
    }
}
