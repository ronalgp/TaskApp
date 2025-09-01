using TaskApp.API.Models;

namespace TaskApp.API.Interfaces;

public interface ITaskDetailRepository
{
    IEnumerable<TaskDetails> GetAllTasks();
    TaskDetails? GetTaskById(int id);
    void CreateTask(TaskDetails task);
    void UpdateTask(TaskDetails task);
    void DeleteTask(int id);
}
