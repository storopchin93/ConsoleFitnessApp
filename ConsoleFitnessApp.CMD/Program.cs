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


            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                var dateBirthDay = ParseDateTime("дату рождения", "даты");
                var wieght = ParseFloat("вес", "веса");
                var hieght = ParseFloat("рост", "роста");

                userController.SetNewUsersDate(gender, dateBirthDay, wieght, hieght);

            }
            Console.WriteLine(userController.CurrentUser);
            Console.ReadKey();
        }

        /// <summary>
        /// Обработка ввода значения с плавующей запятой.
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
        /// Обработка ввода даты.
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
