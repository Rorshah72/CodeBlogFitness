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
        private readonly IDataSaver manager = new SerializeDataSaver();
        //private readonly IDataSaver manager = new DatabaseDataSaver();

        protected void Save<T>(List<T> item) where T : class
        {
            manager.Save(item);
        }

        protected List<T> Load<T>() where T : class
        {
           return manager.Load<T>();
        }

      
    }
}
