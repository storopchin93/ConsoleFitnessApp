using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleFitnessApp.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleFitnessApp.BL.Model;

namespace ConsoleFitnessApp.BL.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddFoodTest()
        {
            //Arrange
            var nameUser = "User";
            var nameFood = "My product";
            var random = new Random(DateTime.Now.Millisecond);
            UserController userController = new UserController(nameUser);
            EatingController eatingController = new EatingController(userController.CurrentUser);
            Food food = new Food(nameFood, random.Next(30, 200), random.Next(30, 200), random.Next(30, 200), random.Next(30, 200));

            //Act

            eatingController.AddFood(food, 100);

            //Assert

            Assert.AreEqual(food.Name, eatingController.Eating.Foods.First().Key.Name);
        }
    }
}