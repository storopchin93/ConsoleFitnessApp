using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFitnessApp.BL.Model
{
    /// <summary>
    /// Прием пищи.
    /// </summary>
    [Serializable]
    public class Eating
    {
        /// <summary>
        /// Время приема пищи.
        /// </summary>
        public DateTime Moment { get; }

        /// <summary>
        /// Список продуктов.
        /// </summary>
        public Dictionary<Food, double> Foods { get; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Создание приема пищи.
        /// </summary>
        /// <param name="user">Пользователь</param>
        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException($"Поле пользователя не может быть пустым {nameof(user)}");
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        /// <summary>
        /// Добавление продукта.
        /// </summary>
        /// <param name="food">Продукт.</param>
        /// <param name="wieght">Количество.</param>
        public void AddFoodToEating(Food food, float wieght)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (product == null)
            {
                Foods.Add(food, wieght);
            }
            else
            {
                Foods[product] += wieght;
            }

        }

    }
}
