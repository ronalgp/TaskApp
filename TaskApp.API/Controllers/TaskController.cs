using Microsoft.AspNetCore.Mvc;
using TaskApp.API.Models;
using TaskApp.API.Repositories;

namespace TaskApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController(ITaskDetailRepository taskDetailRepository) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTasks()
        {
            var tasks = taskDetailRepository.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTask(int id)
        {
            var task = taskDetailRepository.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }
        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskDetails task)
        {
            taskDetailRepository.CreateTask(task);
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] TaskDetails updatedTask)
        {
            var task = taskDetailRepository.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            taskDetailRepository.UpdateTask(updatedTask);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = taskDetailRepository.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            taskDetailRepository.DeleteTask(id);
            return NoContent();
        }
    }
}
