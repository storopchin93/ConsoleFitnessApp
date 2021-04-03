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
    /// Контроллер пользователя.
    /// </summary>
    public class UserController : ControllerBase
    {
        private const string USERS_FILE_NAME = "users.bin";
        /// <summary>
        /// Список пользователей.
        /// </summary>
        public List<User> Users { get; private set; }
        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        public User CurrentUser { get; private set; }
        /// <summary>
        /// Флаг нового пользователя.
        /// </summary>
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Создание контроллера пользователя.
        /// </summary>
        /// <param name="userName">Имя пользователя.</param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName)) throw new ArgumentNullException($"Имя пользователя должно быть заполнено{nameof(userName)}");
            Users = GetUsersData();
    
            CurrentUser = Users.SingleOrDefault(user => user.Name == userName);
            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        /// <summary>
        /// Записать в БД нового пользователя.
        /// </summary>
        /// <param name="genderName">Имя пола.</param>
        /// <param name="dateBirthday">Дата раждения.</param>
        /// <param name="wieght">Вес.</param>
        /// <param name="hieght">Рост.</param>
        public void SetNewUsersDate(string genderName, DateTime dateBirthday, float wieght = 1, float hieght = 1)
        {
            if (String.IsNullOrWhiteSpace(genderName)) throw new ArgumentNullException($"Имя пола должно быть заполнено {nameof(genderName)}");
            if (dateBirthday < DateTime.Parse("01.01.1900") || dateBirthday >= DateTime.Now) throw new ArgumentException($"Дата рождения не должна быть меньше 01.01.1900 {nameof(dateBirthday)}");

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.DateBirthday = dateBirthday;
            CurrentUser.Wieght = wieght;
            CurrentUser.Hieght = hieght;
            SetData("users.bin", Users);
        }

        /// <summary>
        /// Получить сохраненный список пользователей. 
        /// </summary>
        /// <returns>Список пользователей.</returns>
        private List<User> GetUsersData()
        {
            return GetData<List<User>>(USERS_FILE_NAME) ?? new List<User>();
        }

        /// <summary>
        /// Сохранение пользователей.
        /// </summary>
        public void Save()
        {
            SetData(USERS_FILE_NAME, Users);
        }


    }
} 
