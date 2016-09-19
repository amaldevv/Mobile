using System.Collections.Generic;
using System.Linq;

using TaskTracker.Core.DL;
using TaskTracker.Core.Model;

namespace TaskTracker.Core.Repo
{
    public class TaskRepo : ITaskRepo
    {
        private static List<Task> _tasks = XmlDataStore.ReadFromDataStore();

        #region Public Methods


        public List<Task> GetAllTasks()
        {
            return _tasks;
        }

        public Task GetTask(string name)
        {
            var task = _tasks != null ? _tasks.FirstOrDefault((x) => x.Name.Equals(name)) : null;
            return task;
        }



        public void DeleteTask(Task task)
        {
            if (task != null)
            {
                _tasks.Remove(task);
            }
            SaveTasks();

        }

        public void SaveTask(Task task)
        {
            if (task == null)
                return;
            if (GetTask(task.Name) != null)
            {
                _tasks.Remove(task);
            }
            _tasks.Add(task);
            SaveTasks();
        }

        #endregion

        #region Private Methods
        private void SaveTasks()
        {
            XmlDataStore.WriteToDataStore(_tasks);
        }
        #endregion
    }
}
