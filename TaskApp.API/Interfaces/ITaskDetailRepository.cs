using TaskApp.API.Models;

namespace TaskApp.API.Interfaces;

public interface ITaskDetailRepository
{
    IEnumerable<TaskDetails> GetAllTasks(int userId);
    TaskDetails? GetTaskById(int id);
    void CreateTask(TaskDetails task, int userId);
    void UpdateTask(TaskDetails task);
    void DeleteTask(int id);
}
