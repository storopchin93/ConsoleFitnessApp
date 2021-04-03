using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFitnessApp.BL.Model
{
    /// <summary>
    /// Продукт питания.
    /// </summary>
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Наименование продукта.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Жиры.
        /// </summary>
        public float Fats { get; }

        /// <summary>
        /// Белки.
        /// </summary>
        public float Proteins { get; }

        /// <summary>
        /// Углеводы.
        /// </summary>
        public float Carbohydrates { get; }


        /// <summary>
        /// Калорий на 100 гр. продукта
        /// </summary>
        public float Calories { get; }


        public float FatsOneGram { get { return Fats / 100; } }

        public float ProteinsOneGram { get { return Proteins / 100; } }

        public float CarbohydratesOneGram { get { return Carbohydrates / 100; } }

        public float CaloriesOneGram { get { return Calories / 100; } }


        public Food(string name) : this(name, 0, 0, 0, 0)
        {
            //Проверка
        }

        public Food(string name, float calories, float fats, float proteins, float carbohydrates)
        {
            //Проверка
            Name = name;
            Fats = fats;
            Proteins = proteins;
            Carbohydrates = carbohydrates;
            Calories = calories;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
