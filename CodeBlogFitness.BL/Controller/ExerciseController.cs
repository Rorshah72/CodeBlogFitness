using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlogFitness.BL.Controller
{
    public class ExerciseController : ControllerBase
    {
        private readonly User user;
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }

        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Користувач не може бути пустим", nameof(user));
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }


        /// <summary>
        /// Додавання нових розминок.
        /// </summary>
        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);

            if (act == null)
            {
                Activities.Add(activity);

                var exercise = new Exercise(begin, end, activity, user);
                Exercises.Add(exercise);



            }
            else
            {
                var exercise = new Exercise(begin, end, act, user);
                Exercises.Add(exercise);


            }

            Save();
        }

        /// <summary>
        /// Зчитування вправ з файлу.
        /// </summary>
        /// <returns>Список вправ</returns>
        private List<Activity> GetAllActivities()
        {
            return Load<Activity>() ?? new List<Activity>();
        }

        /// <summary>
        /// Зчитування розминок з файлу.
        /// </summary>
        /// <returns>Список розминок.</returns>
        private List<Exercise> GetAllExercises()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }

        /// <summary>
        /// Запис спискiв розминок та вправ у файл.
        /// </summary>
        private void Save()
        {
            Save(Activities);
            Save(Exercises);
        }
    }
}
