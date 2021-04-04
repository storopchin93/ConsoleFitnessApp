using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFitnessApp.BL.Model
{
    /// <summary>
    /// Упражнение.
    /// </summary>
    [Serializable]
    public class Exercise
    {
        /// <summary>
        /// Время старта упражнения.
        /// </summary>
        /// 
        public DateTime Start { get; }
        /// <summary>
        /// Время окончания упражнения.
        /// </summary>
        public DateTime Finish { get; }
        /// <summary>
        /// Активность.
        /// </summary>
        public Activity Activity { get; }
        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Создать 
        /// </summary>
        /// <param name="start">Время старта упражнения.</param>
        /// <param name="finish">Время окончания упражнения.</param>
        /// <param name="activity">Активность.</param>
        /// <param name="user">Пользователь.</param>
        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {

            Start = start;
            Finish = finish;
            Activity = activity ?? throw new ArgumentNullException(nameof(activity));
            User = user ?? throw new ArgumentNullException(nameof(user));
        }



    }
}
