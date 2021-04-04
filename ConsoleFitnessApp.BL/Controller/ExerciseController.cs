using ConsoleFitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFitnessApp.BL.Controller
{
    /// <summary>
    /// Контроллер упражнений.
    /// </summary>
    public class ExerciseController : ControllerBase
    {
        private readonly string EXERCISES_FILE_NAME = "exercises.bin";
        private readonly string ACTIVITIES_FILE_NAME = "activities.bin";
        /// <summary>
        /// Пользователь.
        /// </summary>
        private readonly User user;
        /// <summary>
        /// Список упражнений.
        /// </summary>
        public List<Exercise> Exercises;
        /// <summary>
        /// Список активностей.
        /// </summary>
        public List<Activity> Activities;

        /// <summary>
        /// Создать контроллер упражнений.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        /// <summary>
        /// Добавить упражнение.
        /// </summary>
        /// <param name="activity">Активность.</param>
        /// <param name="start">Начало упражнения.</param>
        /// <param name="finish">Окончание упражнения.</param>
        public void Add(Activity activity, DateTime start, DateTime finish)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            if(act == null)
            {
                Activities.Add(activity);
                Exercises.Add(new Exercise(start, finish, activity, user));
            }
            else
            {
                Exercises.Add(new Exercise(start, finish, activity, user));
            }
            SetAll();
        }

        /// <summary>
        /// Получить все упражнения.
        /// </summary>
        /// <returns>Список упаржнений.</returns>
        private List<Exercise> GetAllExercises()
        {
            return GetData<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }

        /// <summary>
        /// Получить всю активность.
        /// </summary>
        /// <returns>Список активности.</returns>
        private List<Activity> GetAllActivities()
        {
            return GetData<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        }

        /// <summary>
        /// Записать все упражнения и активности.
        /// </summary>
        private void SetAll()
        {
            SetData(EXERCISES_FILE_NAME, Exercises);
            SetData(ACTIVITIES_FILE_NAME, Activities);

        }

    }
}
