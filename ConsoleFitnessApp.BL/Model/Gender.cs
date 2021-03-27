using System;

namespace ConsoleFitnessApp.BL.Model
{
    [Serializable]

    public class Gender
    {
        private string name;

        /// <summary>
        /// Наименование пола 
        /// </summary>
        public string Name
        {
            get { return name; }
            private set
            {
                if (value is String) { name = value; }
                else throw new Exception($"Некорректный тип {nameof(Name)}");
            }
        }

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
            return $"Gender Name {name}"; 
        }
    }
}