using System;
using System.Collections.Generic;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }

        /// <summary>
        /// Назва врпави.
        /// </summary>
        public string Name { get; set; }

        public virtual ICollection<Exercise> Exercise { get; set; }

        /// <summary>
        /// Кiлькiсть калорiй якi сгорають пiд час вправи за одну хвилину.
        /// </summary>
        public double CalloriesPerMinute { get; set; }

        public Activity() { }

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
