using System;

namespace ConsoleFitnessApp.BL.Model
{
    /// <summary>
    /// Пол.
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Наименование пола.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Конструктор пола. 
        /// </summary>
        /// <param name="name">Наименование пола</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException($"Имя пола должно быть заполнено {nameof(name)}");
            Name = name;
        }


        public override string ToString()
        {
            return $"Gender Name {Name}"; 
        }
    }
}