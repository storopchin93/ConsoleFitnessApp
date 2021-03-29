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


        #region Свойства
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Пол полбзователя.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Дата рождения пользователя.
        /// </summary>
        public DateTime DateBirthday { get; set; } //Переделать свойства

        /// <summary>
        /// Возраст пользователя.
        /// </summary>
        public int Age
        {
            get
            {
                var diffDate = ((DateTime.Parse(DateTime.Now.ToShortDateString()).Subtract(DateBirthday))).Days.ToString();
                return (Int32.Parse(diffDate)) / 365;
            }
        }

        /// <summary>
        /// Вес пользователя.
        /// </summary>
        public float Wieght { get; set; } //Переделать свойства

        /// <summary>
        /// Рост пользователя.
        /// </summary>
        public float Hieght { get; set; } //Переделать свойства
        #endregion

        /// <summary>
        ///Создать нового пользователя только с именем.
        /// </summary>
        /// <param name="name">Имя.</param>
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException($"Имя пользователя должно быть заполнено{nameof(name)}");
            Name = name;
        }

        /// <summary>
        /// Создать нового пользователя со всеми параметрами.
        /// </summary>
        /// <param name="name">Имя. </param>
        /// <param name="gender">Пол.</param>
        /// <param name="dateBirthday">Дата рождения.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="wieght">Вес.</param>
        /// <param name="hieght">Рост.</param>
        public User(string name, Gender gender, DateTime dateBirthday, float wieght, float hieght)
        {
            #region Проверка
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException($"Имя пользователя должно быть заполнено{nameof(name)}");
            if (gender == null) throw new ArgumentNullException($"Имя пола должно быть заполнено {nameof(gender)}");
            if (dateBirthday < DateTime.Parse("01.01.1900") || dateBirthday >= DateTime.Now) throw new ArgumentException($"Дата рождения не должна быть меньше 01.01.1900 {nameof(dateBirthday)}");
            if (wieght <= 0 || wieght >= 200) throw new ArgumentException($"Вес не может быть меньше 0 или больше 200 {nameof(gender)}");
            if (hieght <= 0 || wieght >= 250) throw new ArgumentException($"Рост не может быть меньше 0 или больше 250 {nameof(gender)}");
            #endregion

            Name = name;
            Gender = gender;
            Wieght = wieght;
            Hieght = hieght;
        }


        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
