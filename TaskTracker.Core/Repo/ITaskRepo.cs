using System.Collections.Generic;

using TaskTracker.Core.Model;

namespace TaskTracker.Core.Repo
{
    public interface ITaskRepo
    {
        List<Task> GetAllTasks();
        Task GetTask(string Name);

        void SaveTask(Task task);

        void DeleteTask(Task task);


    }
}
