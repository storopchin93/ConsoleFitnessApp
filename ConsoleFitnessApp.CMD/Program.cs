using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleFitnessApp.BL.Controller;
using ConsoleFitnessApp.BL.Model;

namespace ConsoleFitnessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите имя пользователя:  ");
            var name = Console.ReadLine();
            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);


            CreateNewUser(userController);
            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Что вы хотите сделать");
            Console.WriteLine("1 - Ввести прием пищи");
            var key = Console.ReadKey();
            Console.WriteLine();

            while (true)
            {
                if (key.Key == ConsoleKey.D1)
                {
                    var foods = EnterEating();
                    eatingController.AddFood(foods.Food,foods.Weight);


                    foreach (var item in eatingController.Eating.Foods)
                    {
                        Console.WriteLine($"\t{ item.Key} - {item.Value}");
                    }
                    break;
                }    
            } 
            Console.ReadKey();
        }

        /// <summary>
        /// Ввести прием пищи.
        /// </summary>
        /// <returns>Продукт, вес продукта.</returns>
        private static (Food Food, float Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var foodName = Console.ReadLine();
            var calories = ParseFloat("калорийность", "поля - калории");
            var proteins = ParseFloat("кол-во протеинов", "поля - протеины");
            var fats = ParseFloat("кол-во жиров", "поля - жиры");
            var carbohydrates = ParseFloat("кол-во углеводов", "поля - углеводы");
            var weight = ParseFloat("вес порции", "веса");

            return ((new Food(foodName,calories,fats,proteins,carbohydrates)), weight);

        }


        /// <summary>
        /// Добавить нового пользователя
        /// </summary>
        /// <param name="userController">Контроллер пользователя</param>
        private static void CreateNewUser(UserController userController)
        {
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                var dateBirthDay = ParseDateTime("дату рождения", "даты");
                var wieght = ParseFloat("вес", "веса");
                var hieght = ParseFloat("рост", "роста");

                userController.SetNewUsersDate(gender, dateBirthDay, wieght, hieght);
            }
        }
        /// <summary>
        /// Обработать ввод значения с плавующей запятой.
        /// </summary>
        /// <param name="name">Наименование значения.</param>
        /// <param name="exceptionFormat">Наменование при ошибке.</param>
        /// <returns>Значение с плавующей запятой.</returns>
        private static float ParseFloat(string name, string exceptionFormat)
        {
            Console.Write($"Введите {name}: ");
            float value;
            while (true)
            {
                if (Single.TryParse(Console.ReadLine(), out value)) break;
                else Console.WriteLine($"Неправильный формат {exceptionFormat}");
            }
            return value;
        }
        /// <summary>
        /// Обработать ввод даты.
        /// </summary>
        /// <param name="name">Наименование значения.</param>
        /// <param name="exceptionFormat">Наменование при ошибке.</param>
        /// <returns>Дата.</returns>
        private static DateTime ParseDateTime(string name, string exceptionFormat)
        {
            Console.Write($"Введите {name}: ");
            DateTime value;
            while (true)
            {

                if (DateTime.TryParse(Console.ReadLine(), out value)) break;
                else Console.WriteLine($"Неправильный формат {exceptionFormat}");
            }
            return value;
        }
    }
}
