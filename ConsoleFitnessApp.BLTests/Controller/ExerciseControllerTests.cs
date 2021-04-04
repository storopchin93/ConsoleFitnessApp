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
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var nameUser = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            Random random = new Random();
            UserController userController = new UserController(nameUser);
            ExerciseController exerciseController = new ExerciseController(userController.CurrentUser);
            Activity activity = new Activity(activityName, random.Next(500));

            //Act

            exerciseController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1));

            //Assert

            Assert.AreEqual(activityName, exerciseController.Activities.First().Name);
        }
    }
}