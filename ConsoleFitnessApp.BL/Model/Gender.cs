using System;

namespace ConsoleFitnessApp.BL.Model
{
    [Serializable]

    public class Gender
    {
        /// <summary>
        /// Наименование пола 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Конструктор 
        /// </summary>
        /// <param name="name">Наименование пола</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) 
            Name = name;
        }


        public override string ToString()
        {
            return $"Gender Name {Name}"; 
        }
    }
}