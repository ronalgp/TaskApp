using TaskApp.API.Data;
using TaskApp.API.Interfaces;
using TaskApp.API.Models;

namespace TaskApp.API.Repositories;

public class TaskDetailRepository(AppDbContext context) : ITaskDetailRepository
{
    public void CreateTask(TaskDetails task, int userId)
    {
        task.UserId = userId;
        context.Tasks.Add(task);
        context.SaveChanges();
    }

    public void DeleteTask(int id)
    {
        var task = context.Tasks.Find(id);
        if (task != null)
        {
            context.Tasks.Remove(task);
            context.SaveChanges();
        }
    }

    public IEnumerable<TaskDetails> GetAllTasks(int userId)
    {
        return context.Tasks.Where(x => x.UserId == userId).ToList();
    }

    public TaskDetails? GetTaskById(int id)
    {
        return context.Tasks.Find(id);
    }

    public void UpdateTask(TaskDetails task)
    {
        var existingTask = context.Tasks.Find(task.Id);
        if (existingTask != null)
        {
            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.DueDate = task.DueDate;
            existingTask.Status = task.Status;
            context.SaveChanges();
        }
    }
}
