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
    public class UserController
    {
        private User user;

        /// <summary>
        /// Пользователь
        /// </summary>
        public User User
        {
            get { return user; }
            private set { user = value; }
        }

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        public UserController(string userName, string genderName, DateTime dateBirthday, float wieght, float hieght)
        {
            User = new User(userName, new Gender(genderName), dateBirthday, wieght, hieght);
           
        }

        public UserController()
        {
            var binaryFormatter = new BinaryFormatter();
            using (var saveStream = new FileStream(@"users.bin", FileMode.OpenOrCreate))
            {
                if (binaryFormatter.Deserialize(saveStream) is User user)
                {
                    User = user;
                }
            }
        }


        public void Save()
        {
            var binaryFormatter = new BinaryFormatter();
            using (var saveStream = new FileStream(@"users.bin", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(saveStream, user);
            }
        }



    }
}
