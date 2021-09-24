using System;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class Exercise
    {
        #region Властивостi
        /// <summary>
        /// Дата початку розминки.
        /// </summary>
        public DateTime Start { get; }

        /// <summary>
        /// Дата кiнця розминки.
        /// </summary>
        public DateTime Finish { get;  }

        /// <summary>
        /// Вправа яку виконував.
        /// </summary>
        public Activity Activity { get; }

        /// <summary>
        /// Користувач який займався розминкою.
        /// </summary>
        public User User { get; }
        #endregion

        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            //TODO: Провiрка
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
    }
}
