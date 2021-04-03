using ConsoleFitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFitnessApp.BL.Controller
{
    /// <summary>
    /// Контроллер приема пищи.
    /// </summary>
    public class EatingController : ControllerBase
    {
        private const string FOODS_FILE_NAME = "foods.bin";
        private const string EATINGS_FILE_NAME = "eatings.bin";

        /// <summary>
        /// Пользователь.
        /// </summary>
        private readonly User user;
        /// <summary>
        /// Продукты.
        /// </summary>
        public List<Food> Foods { get; }
        /// <summary>
        /// Cписок приемов пищи.
        /// </summary>
        public Eating Eating { get; }

        /// <summary>
        /// Создание нового контроллера приема пищи.
        /// </summary>
        /// <param name="user">Пользователь.</param> 
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException($"Имя пользователя должно быть заполнено{nameof(user)}");
            Foods = GetAllFoods();
            Eating = GetEating();
        }

        /// <summary>
        /// Добавление продукта.
        /// </summary>
        /// <param name="foodName">Наименование продукта.</param>
        /// <param name="wieght">Вес продукта.</param>

        public void AddFood(Food food, float weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.AddFoodToEating(food, weight);
                SetAll();
            }
            else
            {
                Eating.AddFoodToEating(product, weight);
                SetAll();
            }
        }


        /// <summary>
        /// Получить прием пищи.
        /// </summary>
        /// <returns>Прием пищи.</returns>
        private Eating GetEating()
        {
            return GetData<Eating>(EATINGS_FILE_NAME) ?? new Eating(user);
        }

        /// <summary>
        /// Получить все продукты.
        /// </summary>
        /// <returns>Списаок продуктов.</returns>
        private List<Food> GetAllFoods()
        {
            return GetData<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
        }

        /// <summary>
        /// Записать продукты и примем пищи.
        /// </summary>
        private void SetAll()
        {
            SetData(FOODS_FILE_NAME, Foods);
            SetData(EATINGS_FILE_NAME, Eating);
        }
    }
}
