using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Контролер для роботи з даними.
    /// </summary>
     public abstract class ControllerBase
    {

        /// <summary>
        /// Зберiгання даних у файл.
        /// </summary>
        /// <param name="fileName">Назва файлу.</param>
        /// <param name="item">Обєкт який потрiбно зберегти.</param>
        protected void Save(string fileName, object item)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }

        /// <summary>
        /// Зчитування даних.
        /// </summary>
        /// <typeparam name="T">Ти даних який зчитуємо.</typeparam>
        /// <param name="fileName">Назва файлу з вiдки зчитуємо.</param>
        /// <returns>Обєкти записанi в файл.</returns>
        protected T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();
            
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
             
                if (fs.Length > 0 && formatter.Deserialize(fs) is T items)
                {
                    return items;
                }
                else
                {
                    return default(T);
                }
            }


        }
    }
}
