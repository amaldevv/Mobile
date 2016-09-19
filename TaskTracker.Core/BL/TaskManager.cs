using System.Collections.Generic;
using TaskTracker.Core.Model;
using TaskTracker.Core.Repo;

namespace TaskTracker.Core.BL
{
    public class TaskManager
    {
        private readonly ITaskRepo _taskRepo = null;

        public TaskManager()
        {
            _taskRepo = new TaskRepo();

        }

        public List<Task> GetTasks()
        {
            return _taskRepo.GetAllTasks();
        }

        public Task GetTask(string name)
        {
            return _taskRepo.GetTask(name);

        }

        public void SaveTask(Task task)
        {
            _taskRepo.SaveTask(task);
        }

        public void DeleteTask(Task task)
        {
            _taskRepo.DeleteTask(task);
        }


    }
}
