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
            Console.Write("Введите имя пользователя");

            var name = Console.ReadLine();

            Console.Write("Введите пол: ");
            var gender = Console.ReadLine();

            Console.Write("Введите дату рождения: ");
            var dateBirthDay = DateTime.Parse(Console.ReadLine());

            Console.Write("Введите вес: ");
            var wieght = Single.Parse(Console.ReadLine());

            Console.Write("Введите рост: ");
            var hieght = Single.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, dateBirthDay, wieght, hieght);
            userController.Save();




            Console.ReadKey();
        }
    }
}
