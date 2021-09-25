using System;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class Exercise
    {
        #region Властивостi
        public int Id { get; set; }

        /// <summary>
        /// Дата початку розминки.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Дата кiнця розминки.
        /// </summary>
        public DateTime Finish { get; set; }

        public int ActivityId { get; set; }

        /// <summary>
        /// Вправа яку виконував.
        /// </summary>
        public virtual Activity Activity { get; set; }

        public int UserId { get; set; }

        /// <summary>
        /// Користувач який займався розминкою.
        /// </summary>
        public virtual User User { get; set; }
        #endregion
         
        public Exercise() { }

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
