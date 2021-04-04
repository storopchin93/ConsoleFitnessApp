using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFitnessApp.BL.Model
{
    /// <summary>
    /// Активность пользователя.
    /// </summary>
    [Serializable]
    public class Activity
    {
        /// <summary>
        /// Название активности.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Кол-во сжигаемых калорий в ед. времени.
        /// </summary>
        public float CaloriesPerMinute { get; }

        /// <summary>
        /// Создать новую активность.
        /// </summary>
        /// <param name="name">Имя активности.</param>
        /// <param name="caloriesPerMinute">Кол-во сжигаемых калорий в ед. времени.</param>
        public Activity(string name, float caloriesPerMinute)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString()
        {
            return Name;     
        }
    }
}
