using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFitnessApp.BL.Model
{
    [Serializable]
    public class User
    {
        private string name;
        private Gender gender;
        private DateTime dateBirthday;
        private int age;
        private float wieght;
        private float hieght;

        #region Свойства
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        /// <summary>
        /// Пол полбзователя.
        /// </summary>
        public Gender Gender
        {
            get { return gender; }
            private set { gender = value; }
        }

        /// <summary>
        /// Дата рождения пользователя.
        /// </summary>
        public DateTime DateBirthday
        {
            get { return dateBirthday; }
            //private set { dateBirthday = value; }
        }

        /// <summary>
        /// Возраст пользователя.
        /// </summary>
        public int Age
        {
            get { return age; }
            private set { age = value; }
        }

        /// <summary>
        /// Вес пользователя.
        /// </summary>
        public float Wieght
        {
            get { return wieght; }
            set { wieght = value; }
        }

        /// <summary>
        /// Рост пользователя.
        /// </summary>
        public float Hieght
        {
            get { return hieght; }
            set { hieght = value; }
        }
        #endregion

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name">Имя </param>
        /// <param name="gender">Пол.</param>
        /// <param name="dateBirthday">Дата рождения.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="wieght">Вес.</param>
        /// <param name="hieght">Рост.</param>
        public User(string name, Gender gender, DateTime dateBirthday, float wieght, float hieght)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException($"Имя пользователя должно быть заполнено{nameof(name)}");
            if (dateBirthday < DateTime.Parse("01.01.1900") || dateBirthday >= DateTime.Now) throw new ArgumentException($"Дата рождения не должна быть меньше 01.01.1900 {nameof(gender)}");
            if (wieght <= 0 || wieght >= 200) throw new ArgumentException($"Вес не может быть меньше 0 или больше 200 {nameof(gender)}");
            if (hieght <= 0 || wieght >= 250) throw new ArgumentException($"Рост не может быть меньше 0 или больше 250 {nameof(gender)}");

            Name = name;
            Gender = gender ?? throw new ArgumentNullException($"Имя пола должно быть заполнено {nameof(gender)}");
            Wieght = wieght;
            Hieght = hieght;
        }

    }
}
