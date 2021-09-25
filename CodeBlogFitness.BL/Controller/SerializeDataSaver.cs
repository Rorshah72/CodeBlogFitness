
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller
{
    class SerializeDataSaver : IDataSaver
    {
        /// <summary>
        /// Зчитування даних.
        /// </summary>
        /// <typeparam name="T">Ти даних який зчитуємо.</typeparam>
        /// <param name="fileName">Назва файлу з вiдки зчитуємо.</param>
        /// <returns>Обєкти записанi в файл.</returns>             
        public List<T> Load<T>() where T: class
        {
            var formatter = new BinaryFormatter();
            var fileName = typeof(T).Name ;

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {

                if (fs.Length > 0 && formatter.Deserialize(fs) is List<T> items)
                {
                    return items;
                }
                else
                {
                    return new List<T>();
                }
            }

        }

        /// <summary>
        /// Зберiгання даних у файл.
        /// </summary>
        /// <param name="fileName">Назва файлу.</param>
        /// <param name="item">Обєкт який потрiбно зберегти.</param>
        public void Save<T>(List<T> item) where T : class
        {
            var formatter = new BinaryFormatter();
            var fileName = typeof(T).Name;
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
    }

        
}

