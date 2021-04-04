using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleFitnessApp.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFitnessApp.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {

        [TestMethod()]
        public void SetNewUsersDateTest()
        {
            //arrange
            var userName = Guid.NewGuid().ToString();
            DateTime birthDate = DateTime.Now.AddYears(-30);
            float wieght = 90;
            float hieght = 170;
            var userController = new UserController(userName);
            var gender = "man";

            //act

            userController.SetNewUsersDate(gender, birthDate, wieght, hieght);
            //assert
            Assert.AreEqual(userName, userController.CurrentUser.Name);
            Assert.AreEqual(gender, userController.CurrentUser.Gender.Name);
            Assert.AreEqual(birthDate, userController.CurrentUser.DateBirthday);
            Assert.AreEqual(wieght, userController.CurrentUser.Wieght);
            Assert.AreEqual(hieght, userController.CurrentUser.Hieght);
        }

        [TestMethod()]
        public void SaveTest()
        {
            var userName = Guid.NewGuid().ToString();
            var userController = new UserController(userName);
            Assert.AreEqual(userName, userController.CurrentUser.Name);
        }
    }
}