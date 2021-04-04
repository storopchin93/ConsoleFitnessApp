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
    /// Базовый контроллер
    /// </summary>
    public abstract class ControllerBase
    {
        /// <summary>
        /// Записать данные.
        /// </summary>
        /// <param name="fileName">Название файла.</param>
        /// <param name="value">Тип файла.</param>
        protected void SetData (string fileName, object value)
        {
            var binaryFormatter = new BinaryFormatter();
            using (var saveStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(saveStream, value);
            }
        }

        /// <summary>
        /// Получить данные
        /// </summary>
        /// <typeparam name="T">Тип параметра.</typeparam>
        /// <param name="fileName">Название файла.</param>
        /// <returns></returns>
        protected T GetData<T> (string fileName)
        {
            var binaryFormatter = new BinaryFormatter();
            using (var loadStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (loadStream.Length > 0 && binaryFormatter.Deserialize(loadStream) is T data)
                {
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }



    }
}
